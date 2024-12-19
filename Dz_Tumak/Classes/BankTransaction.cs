
namespace Domashka
{
    internal class BankTransaction
    {
        public readonly DateTime dateTrans;
        public readonly decimal sum;
        public TransactionType transactionType {  get; set; }
        public BankTransaction(decimal sum)
        {
            dateTrans = DateTime.Now;
            this.sum = sum;
        }
    }
    enum TransactionType { Пополнение, Списание}

}
