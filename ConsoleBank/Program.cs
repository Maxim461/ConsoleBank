class Program
{
    

    static void Main()
    {
        double BalanceRub = 0;
        double BalanceDollar = 0;
        double BalanceEuro = 0;
        double[] ExchangeRatу = { 97.35, 102.75 };
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите, если вы хотите:");
            Console.WriteLine("1 - Выполнить отображение баланса во всех валютах;");
            Console.WriteLine("2 - Выполнить пополнение баланса;");
            Console.WriteLine("3 - Выполнить отображение курсов валют;");
            Console.WriteLine("4 - Выполнить перевод из одной валюты в другую.");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine($"На вашем счету {BalanceRub} RUB;");
                    Console.WriteLine($"На вашем счету {BalanceDollar} DOLLAR;");
                    Console.WriteLine($"На вашем счету {BalanceEuro} EURO;");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Введите сумму на которую вы хотите пополнить баланс в рублях:");
                    BalanceRub = double.Parse(Console.ReadLine());
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine($"Курс доллара: {ExchangeRatу[0]}");
                    Console.WriteLine($"Курс доллара: {ExchangeRatу[1]}");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D4:
                    Console.Clear();
                    double [] one = TransferringMoneyFromOneCurrencyToAnother(BalanceRub, ExchangeRatу, BalanceEuro, BalanceDollar);
                    BalanceDollar = one[0];
                    BalanceEuro = one[1];
                    BalanceRub = one[2];
                    break;
            }
        }
    }
    static double[] TransferringMoneyFromOneCurrencyToAnother(double BalanceRub, double[] ExchangeRatу, double BalanceEuro, double BalanceDollar)
        {
            Console.WriteLine("Выберите во что вы хотите перевести:");
            Console.WriteLine("1 - В DOLLAR");
            Console.WriteLine("2 - В EURO");
            int UserVar = int.Parse(Console.ReadLine());
            if (UserVar == 1)
            {
            
             BalanceDollar = BalanceRub / ExchangeRatу[0];
            BalanceRub = 0;
        }
            else if (UserVar == 2)
            {
                 BalanceEuro = BalanceRub / ExchangeRatу[1];
            BalanceRub = 0;
        }
            else
            {
                Console.WriteLine("Error!!!");
            }
            return new double[] { BalanceDollar, BalanceEuro, BalanceRub };
        }
    
}