
namespace Domashka
{
    internal class BankTumak
    {
        static private long idShet = 2200000000000000;
        private long tekIdShet { get; }
        private decimal balanceShet;
        private Bank typeShet = Bank.Сберегательный;
        private Queue<BankTransaction> bankTransactions = new Queue<BankTransaction>();
        private void Next()
        {
            idShet++;
        }    
        public BankTumak()
        {
            Next();
            this.tekIdShet = idShet;
            this.balanceShet = 0;
            this.typeShet = Bank.Необозначенный;
        }
        public BankTumak(decimal balanceShet)
        {
            Next();
            this.balanceShet = balanceShet;
            this.tekIdShet = idShet;
            this.typeShet = Bank.Необозначенный;
        }
        public BankTumak(decimal balanceShet, Bank typeShet)
        {
            Next();
            this.balanceShet = balanceShet;
            this.tekIdShet = idShet;
            this.typeShet = typeShet;
        }
        public void PrintInfoShet()
        {
            Console.WriteLine($"Номер счета: {tekIdShet}\nБаланс счета: {balanceShet}\nТип счета: {typeShet}");
        }
        /// <summary>
        /// Выводит в консоль все транзакции текущего счета
        /// </summary>
        public void PrintTransactions()
        {
            foreach (BankTransaction trans in bankTransactions)
            {
                Console.WriteLine($"\nСумма: {trans.sum}\nТип транзакции: {trans.transactionType}\nДата: {trans.dateTrans}\n");
            }
        }

        //к упражнению 7.3
        public void TakeBalanceShet()
        {
            Console.Write("Введите сумму которую хотите снять:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal takenBalanceShet);
            if (isDecimal)
            {
                if (takenBalanceShet < this.balanceShet)
                {
                    balanceShet = balanceShet - takenBalanceShet;
                    Console.WriteLine($"Вы успешно сняли со счета\nТекущий баланс: {balanceShet}");
                    BankTransaction bankTrans = new BankTransaction(takenBalanceShet);
                    bankTrans.transactionType = TransactionType.Списание;
                    bankTransactions.Enqueue(bankTrans);
                }
                else
                {
                    Console.WriteLine("У вас недостаточно средств");
                }
            }
            else
            {
                Console.WriteLine("Вы вввели не сумму");
            }
        }
        public void GiveBalanceShet()
        {
            Console.Write("Введите сумму которую хотите положить:");
            bool isDecimal = decimal.TryParse(Console.ReadLine(), out decimal givenBalanceShet);
            if (isDecimal)
            {
                balanceShet = balanceShet + givenBalanceShet;
                Console.WriteLine($"Вы успешно пополнили счет\nТекущий баланс счета:{balanceShet}");
                BankTransaction bankTrans = new BankTransaction(givenBalanceShet);
                bankTrans.transactionType = TransactionType.Пополнение;
                bankTransactions.Enqueue(bankTrans);
            }
            else
            {
                Console.WriteLine("Вы вввели не сумму");
            }
        }

        public void Perevod(BankTumak toShet, decimal sum)
        {
            if (this.balanceShet >= sum)
            {
                this.balanceShet = this.balanceShet - sum;
                toShet.balanceShet = toShet.balanceShet + sum;
            }
            else
            {
                throw new Exception("Недостаточно средств");
            }
        }
        /// <summary>
        /// Сохраняет все операции в bankTransactions в файл transactions.txt
        /// </summary>
        public void Dispose()
        {
            string target = Path.GetFullPath("transactions.txt").Replace("bin\\Debug\\net8.0\\", "files\\");

            foreach (BankTransaction trans in bankTransactions)
            {
                File.AppendAllText(target, $"Сумма:{trans.sum}| Тип транзакции: {trans.transactionType} | Дата: {trans.dateTrans}\n");
            }
            GC.SuppressFinalize(this);
        }
    }
    enum Bank
    {
        Сберегательный,
        Текущий,
        Необозначенный
    }

}
