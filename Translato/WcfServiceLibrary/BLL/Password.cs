//author: futz
//helpers:
//last_checked: futz@20.11.2015

using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNet.Cryptography.KeyDerivation;

namespace WcfServiceLibrary.BLL
{
    public class Password
    {
        /*
         * Version 3.futz:
         * PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 20000 iterations.
         * Format: { 0x01, prf (UInt32), iter count(UInt32), salt length(UInt32), salt, subkey }
         * (All UInt32s are stored big-endian.)
         */
        public static string hashPassword(string password)
        {
            var prf = KeyDerivationPrf.HMACSHA256;
            var rng = RandomNumberGenerator.Create();
            const int iterCount = 20000;
            const int saltSize = 128 / 8;
            const int numBytesRequested = 256 / 8;
            //produce a version 3 (see comment above) text hash
            var salt = new byte[saltSize];
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);
            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; //format marker
            writeNetworkByteOrder(outputBytes, 1, (uint)prf);
            writeNetworkByteOrder(outputBytes, 5, iterCount);
            writeNetworkByteOrder(outputBytes, 9, saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return Convert.ToBase64String(outputBytes);
        }
        public static bool verifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);
            //wrong version
            if (decodedHashedPassword[0] != 0x01)
                return false;
            //read header information
            var prf = (KeyDerivationPrf)readNetworkByteOrder(decodedHashedPassword, 1);
            var iterCount = (int)readNetworkByteOrder(decodedHashedPassword, 5);
            var saltLength = (int)readNetworkByteOrder(decodedHashedPassword, 9);
            //read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            var salt = new byte[saltLength];
            Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);
            //read the subkey (the rest of the payload): must be >= 128 bits
            var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            var expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);
            //hash the incoming password and verify it
            var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
            return actualSubkey.SequenceEqual(expectedSubkey);
        }
        private static void writeNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }
        private static uint readNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }
    }
}
