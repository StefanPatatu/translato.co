//author: futz
//helpers:
//last_checked: futz@13.12.2015

using ENUM;
using System;
using System.Threading;
using System.Transactions;
using TranslatoServiceLibrary.DAL;
using TranslatoServiceLibrary.MODEL;
using TranslatoServiceLibrary.X;

namespace TranslatoServiceLibrary.BLL
{
    internal sealed class CtrUser
    {
        //returns [int >= TRANSLATO_DATABASE_SEED] if successful
        //returns [int < TRANSLATO_DATABASE_SEED] if not
        internal int insertUser(User user)
        {
            int returnCode = (int)CODE.ZERO;
            int result = (int)CODE.MINUS_ONE;

            //validate userName 
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(user.userName) ||
                !Validate.isAlphaNumericWithUnderscore(user.userName) ||
                !Validate.hasMinLength(user.userName, 5) ||
                !Validate.hasMaxLength(user.userName, 15)
               ) { returnCode = (int)CODE.CTRUSER_INSERTUSER_INVALID_USERNAME; result = (int)CODE.ZERO; }
            //validate password(stored in the hashedPassword field at this point. Will be replaced with hash + salt later)
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(user.hashedPassword) ||
                !Validate.hasMinLength(user.hashedPassword, 8) ||
                !Validate.hasMaxLength(user.hashedPassword, 100)
               ) { returnCode = (int)CODE.CTRUSER_INSERTUSER_INVALID_PASSWORD; result = (int)CODE.ZERO; }
            //validate firstName 
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(user.firstName) ||
                !Validate.hasMinLength(user.firstName, 2) ||
                !Validate.hasMaxLength(user.firstName, 20)
               ) { returnCode = (int)CODE.CTRUSER_INSERTUSER_INVALID_FIRSTNAME; result = (int)CODE.ZERO; }
            //validate lastName 
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(user.lastName) ||
                !Validate.hasMinLength(user.lastName, 2) ||
                !Validate.hasMaxLength(user.lastName, 20)
               ) { returnCode = (int)CODE.CTRUSER_INSERTUSER_INVALID_LASTNAME; result = (int)CODE.ZERO; }
            //validate email 
            if (
                result == (int)CODE.ZERO ||
                returnCode != (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(user.email) ||
                !Validate.hasMinLength(user.email, 5) ||
                !Validate.hasMaxLength(user.email, 50) ||
                !user.email.Contains("@")
               ) { returnCode = (int)CODE.CTRUSER_INSERTUSER_INVALID_EMAIL; result = (int)CODE.ZERO; }
            if (returnCode == (int)CODE.ZERO && result != (int)CODE.ZERO)//safe to proceed
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
                        returnCode = _DbUsers.insertUser(user);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    returnCode = (int)CODE.CTRUSER_INSERTUSER_EXCEPTION;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    returnCode = (int)CODE.CTRUSER_INSERTUSER_EXCEPTION;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    returnCode = (int)CODE.CTRUSER_INSERTUSER_EXCEPTION;
                    Log.Add(ex.ToString());
                }
            }
            else {  }
            return returnCode;
        }

        //returns "MODEL.User" object if successful/found
        //returns "null" if not
        internal User findUserByUserId(int userId)
        {
            int result = (int)CODE.MINUS_ONE;
            User user = null;

            //validate userId
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(userId.ToString()) ||
                !Validate.isAllNumbers(userId.ToString()) ||
                !Validate.integerIsBiggerThan(userId, (int)CODE.TRANSLATO_DATABASE_SEED - 1)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserByUserId(userId);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || user == null) { return null; }
            else { return user; }
        }

        //returns "MODEL.User" object if successful/found
        //returns "null" if not
        internal User findUserByUserName(string userName)
        {
            int result = (int)CODE.MINUS_ONE;
            User user = null;

            //validate userName
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(userName) ||
                !Validate.isAlphaNumericWithUnderscore(userName) ||
                !Validate.hasMinLength(userName, 5) ||
                !Validate.hasMaxLength(userName, 15)
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserByUserName(userName);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || user == null) { return null; }
            else { return user; }
        }

        //returns "MODEL.User" object if successful/found
        //returns "null" if not
        internal User findUserByEmail(string email)
        {
            int result = (int)CODE.MINUS_ONE;
            User user = null;

            //validate email 
            if (
                result == (int)CODE.ZERO ||
                string.IsNullOrWhiteSpace(email) ||
                !Validate.hasMinLength(email, 5) ||
                !Validate.hasMaxLength(email, 50) ||
                !email.Contains("@")
               ) { result = (int)CODE.ZERO; }
            if (result != (int)CODE.ZERO)//safe to proceed
            {
                IUsers _DbUsers = new DbUsers();

                try
                {
                    using (var trScope = TransactionScopeBuilder.CreateSerializable())
                    {
                        user = _DbUsers.findUserByEmail(email);

                        trScope.Complete();
                    }
                }
                catch (TransactionAbortedException taEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(taEx.ToString());
                }
                catch (ApplicationException aEx)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(aEx.ToString());
                }
                catch (Exception ex)
                {
                    result = (int)CODE.ZERO;
                    Log.Add(ex.ToString());
                }
            }
            else { result = (int)CODE.ZERO; }

            if (result == (int)CODE.ZERO || user == null) { return null; }
            else { return user; }
        }

        //returns "CTRUSER_LOGINUSER_SUCCESS" if successful
        //returns "CTRUSER_LOGINUSER_FAILURE_[...]" if not
        internal int loginUser(string userNameOrEmail, string HRpassword)
        {
            int returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INITIAL;
            //check if userName
            bool isPossibleUserName = false;
            Thread checkIsPossibleUserNameThread = new Thread(
                new ThreadStart(() =>
                {
                    if (
                        !string.IsNullOrWhiteSpace(userNameOrEmail) &&
                        Validate.isAlphaNumericWithUnderscore(userNameOrEmail) &&
                        Validate.hasMinLength(userNameOrEmail, 5) &&
                        Validate.hasMaxLength(userNameOrEmail, 15)
                       )
                    { isPossibleUserName = true; }
                })); 
            //check if email
            bool isPossibleEmail = false;
            Thread checkIsPossibleEmailThread = new Thread(
                new ThreadStart(() =>
                {
                    if (
                        !string.IsNullOrWhiteSpace(userNameOrEmail) &&
                        Validate.hasMinLength(userNameOrEmail, 5) &&
                        Validate.hasMaxLength(userNameOrEmail, 50) &&
                        userNameOrEmail.Contains("@")
                       )
                    { isPossibleEmail = true; }
                }));
            try
            {
                checkIsPossibleUserNameThread.Start();
                checkIsPossibleEmailThread.Start();
                checkIsPossibleUserNameThread.Join();
                checkIsPossibleEmailThread.Join();
            }
            catch (ThreadAbortException taEx)
            {
                isPossibleEmail = false;
                isPossibleUserName = false;
                Log.Add(taEx.ToString());
            }
            catch (Exception ex)
            {
                isPossibleEmail = false;
                isPossibleUserName = false;
                Log.Add(ex.ToString());
            }
        
            //authenticate by case
            bool isTheSamePassword = false;
            if (isPossibleUserName || isPossibleEmail)
            {
                User user;

                if (isPossibleUserName && !isPossibleEmail)
                {//authenticate by userName
                    user = findUserByUserName(userNameOrEmail);
                    if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                    else returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INVALID_USERNAME;
                }
                else if (!isPossibleUserName && isPossibleEmail)
                {//authenticate by email
                    user = findUserByEmail(userNameOrEmail);
                    if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                    else returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INVALID_EMAIL;
                }
                else
                {//means it matches both
                    if (isTheSamePassword == false)
                    {//try authenticate by email
                        user = findUserByEmail(userNameOrEmail);
                        if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                        else returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INVALID_EMAIL;
                    }
                    if (isTheSamePassword == false)
                    {//try authenticate by userName
                        user = findUserByUserName(userNameOrEmail);
                        if (user != null) isTheSamePassword = Security.checkPassword(user.hashedPassword, HRpassword);
                        else returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INVALID_USERNAME;
                    }
                }
            }
            else
            {//means it matches none
                isTheSamePassword = false;
                returnCode = (int)CODE.CTRUSER_LOGINUSER_FAILURE_INVALID_USERNAME_AND_EMAIL;
            }
            if (isTheSamePassword) returnCode = (int)CODE.CTRUSER_LOGINUSER_SUCCESS;
            return returnCode;         
        }
    }
}
