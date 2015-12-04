//author: futz
//helpers:
//last_checked: futz@04.12.2015

using System.Transactions;

namespace TranslatoServiceLibrary.BLL
{
    internal static class TransactionScopeBuilder
    {
        internal static TransactionScope CreateSerializable()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable,
                Timeout = TransactionManager.DefaultTimeout
            };
            return new TransactionScope(TransactionScopeOption.Required, options);
        }
    }
}
