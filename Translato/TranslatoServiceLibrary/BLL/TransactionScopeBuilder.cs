//author: futz
//helpers:
//last_checked: futz@30.11.2015

using System.Transactions;

namespace TranslatoServiceLibrary.BLL
{
    public class TransactionScopeBuilder
    {
        public static TransactionScope CreateSerializable()
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
