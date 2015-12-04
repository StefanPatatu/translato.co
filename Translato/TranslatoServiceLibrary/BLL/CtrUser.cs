//author: futz
//helpers:
//last_checked: futz@04.12.2015

using System;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrUser
    {
        //returns "1" if successful
        //returns "0" if not
        internal int insertUser(User user)
        {
            int result = -1;

            //validate userName 
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(user.userName) ||
                !Validate.isAlphaNumericWithUnderscore(user.userName) ||
                !Validate.hasMinLength(user.userName, 5) ||
                !Validate.hasMaxLength(user.userName, 15)
               ) { result = 0; }
            //validate password(stored in the HashedPassword field at this point. Will be replaced with hash + salt later)
            if (
                result == 0 ||
                !Validate.hasMinLength(user.hashedPassword, 8) ||
                !Validate.hasMaxLength(user.hashedPassword, 100)
               ) { result = 0; }
            //validate firstName 
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(user.firstName) ||
                !Validate.hasMinLength(user.firstName, 2) ||
                !Validate.hasMaxLength(user.firstName, 20)
               ) { result = 0; }
            //validate lastName 
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(user.lastName) ||
                !Validate.hasMinLength(user.lastName, 2) ||
                !Validate.hasMaxLength(user.lastName, 20)
               ) { result = 0; }
            //validate email 
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(user.email) ||
                !Validate.hasMinLength(user.email, 5) ||
                !Validate.hasMaxLength(user.email, 50) ||
                !user.email.Contains("@")
               ) { result = 0; }
            if (result != 0)//safe to proceed
            {
                user.userName = user.userName;
                user.hashedPassword = Security.hashPassword(user.hashedPassword);
                user.firstName = user.firstName;
                user.lastName = user.lastName;
                user.email = user.email;
                user.newsletterOptOut = user.newsletterOptOut;
                user.createdOn = DateTimeOffset.Now;

                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        result = _DbUsers.insertUser(user);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }
            return result;
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        internal User findUserById(int userId)
        {
            int result = -1;
            User user = null;

            //validate userId
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(userId.ToString()) ||
                !Validate.isAllNumbers(userId.ToString()) ||
                !Validate.isBiggerThan(userId, 0)
               ) { result = 0; }
            if (result != 0)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserById(userId);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }

            if (result == 0 || user == null) { return null; }
            else { return user; }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        internal User findUserByUserName(string userName)
        {
            int result = -1;
            User user = null;

            //validate userName
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(userName) ||
                !Validate.isAlphaNumericWithUnderscore(userName) ||
                !Validate.hasMinLength(userName, 5) ||
                !Validate.hasMaxLength(userName, 15)
               )
            { result = 0; }
            if (result != 0)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserByUserName(userName);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }

            if (result == 0 || user == null) { return null; }
            else { return user; }
        }

        //returns "MODEL.User" object if successful
        //returns "null" if not
        internal User findUserByEmail(string email)
        {
            int result = -1;
            User user = null;

            //validate email 
            if (
                result == 0 ||
                string.IsNullOrWhiteSpace(email) ||
                !Validate.hasMinLength(email, 5) ||
                !Validate.hasMaxLength(email, 50) ||
                !email.Contains("@")
               )
            { result = 0; }
            if (result != 0)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserByEmail(email);

                        trScope.Complete();
                        trScope.Dispose();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = 0;
                    DEBUG.Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = 0;
                    DEBUG.Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = 0;
                    DEBUG.Log.Add(ex.ToString());
                }
            }
            else { result = 0; }

            if (result == 0 || user == null) { return null; }
            else { return user; }
        }

        //returns "true" if successful
        //returns "false" if not
        internal bool loginUser(string userNameOrEmail, string HRpassword)
        {
            //check if userName
            bool isUsername = false; 
            if (
                !string.IsNullOrWhiteSpace(userNameOrEmail) &&
                Validate.isAlphaNumericWithUnderscore(userNameOrEmail) &&
                Validate.hasMinLength(userNameOrEmail, 5) &&
                Validate.hasMaxLength(userNameOrEmail, 15)
               )
            { isUsername = true; }
            //check if email
            bool isEmail = false;
            if (
                !string.IsNullOrWhiteSpace(userNameOrEmail) &&
                Validate.hasMinLength(userNameOrEmail, 5) &&
                Validate.hasMaxLength(userNameOrEmail, 50) &&
                userNameOrEmail.Contains("@")
               )
            { isEmail = true; }

            //authenticate by case
            bool isTheSamePassword = false;
            if (isUsername || isEmail)
            {
                User user;

                if (isUsername && !isEmail)
                {//authenticate by userName
                    user = findUserByUserName(userNameOrEmail);
                    if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                }
                else if (!isUsername && isEmail)
                {//authenticate by email
                    user = findUserByEmail(userNameOrEmail);
                    if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                }
                else
                {//means it matches both
                    if (isTheSamePassword == false)
                    {//try authenticate by email
                        user = findUserByEmail(userNameOrEmail);
                        if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                    }
                    else if (isTheSamePassword == false)
                    {//try authenticate by userName
                        user = findUserByUserName(userNameOrEmail);
                        if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                    }
                    else
                    {
                        //give up; wrong credentials
                    }
                }
            }
            else
            {//means it matches none
                isTheSamePassword = false;
            }
            return isTheSamePassword;         
        }
    }
}
