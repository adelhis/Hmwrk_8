

namespace Domashka
{
    class Dz_Tumak
    {
        static void Main()
        {
            Zadanie1();
            Zadanie2();
            Zadanie3();
            Zadanie4();
        }
        static void Zadanie1()
        {
            /*Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
            конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
            для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
            банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
            счета.*/
            Console.WriteLine("Упражнение 9.1 Создание кострукторов в классе BankTumak");
            BankTumak bank1 = new BankTumak();//Строка 30
            BankTumak bank2 = new BankTumak((decimal)2154215.12512);//строка 37
            BankTumak bank3 = new BankTumak((decimal)21412512.2151, Bank.Сберегательный);//строка 44
            bank1.PrintInfoShet();
            bank2.PrintInfoShet();
            bank3.PrintInfoShet();
        }
        static void Zadanie2()
        {
            /*Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
            о всех банковских операциях. При изменении баланса счета создается новый объект класса
            BankTransaction, который содержит текущую дату и время, добавленную или снятую со
            счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
            передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа
            System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
            данного банковского счета; изменить методы снятия со счета и добавления на счет так,
            чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
            переменную типа System.Collections.Queue.*/
            Console.WriteLine("Упражнение 9.2. Создание класса BankTransaction для отслеживания операций");
            BankTumak bank1 = new BankTumak((decimal)21421512.124125);
            Console.WriteLine("\nПример 1\n");
            bank1.PrintInfoShet();
            bank1.TakeBalanceShet();
            bank1.GiveBalanceShet();
            bank1.PrintTransactions();

            Console.WriteLine("\nПример 2\n");
            BankTumak bank2 = new BankTumak((decimal)2121512.124125);
            bank2.PrintInfoShet();
            bank2.GiveBalanceShet();
            bank2.TakeBalanceShet();
            bank2.PrintTransactions();
        }
        static void Zadanie3()
        {
            /*Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
            проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
            GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
            завершения для указанного объекта.*/
            Console.WriteLine("Упражнение 9.3. Метод Dispose в классе BankTumak");//строка 117
            BankTumak bank1 = new BankTumak((decimal)21421512.124125);
            bank1.PrintInfoShet();
            bank1.TakeBalanceShet();
            bank1.GiveBalanceShet();
            bank1.PrintTransactions();

            bank1.Dispose();
        }
        static void Zadanie4()
        {
            /*Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
            конструкторы:
            1) параметры конструктора – название и автор песни, указатель на предыдущую песню
            инициализировать null.
            2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
            создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
            следующим образом: Song mySong = new Song(); ?
            Исправьте ошибку, создав необходимый конструктор.*/
            Console.WriteLine("Домашнее задание 9.1. В класс Song добавить кострукторы");
            Song mySong = new Song();
            Song mySong1 = new Song("Блабла", "Блаблатор");
            Song mySong2 = new Song("Парампам", "Парампатор", mySong1);
            Console.WriteLine("\nИнформация о песне с пустым коструктором");
            mySong.SongInfo();
            Console.WriteLine("\nИнформация о песне с коструктором (name, author");
            mySong1.SongInfo();
            Console.WriteLine("\nИнформация о песне с коструктором (name, author, prev");
            mySong2.SongInfo();
            Console.WriteLine("\nИнформация о песне, которая идет до mySong2(т.е. mySong1");
            mySong2.prev.SongInfo();

        }
    }
}