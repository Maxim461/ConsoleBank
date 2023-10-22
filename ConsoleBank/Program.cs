using System;

class Program
{
    static double BalanceRub = 0;
    static double BalanceDollar = 0;
    static double BalanceEuro = 0;
    static int[,] CurrencyExchangeRate = new int[3, 10];
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        for (int i = 0; i < CurrencyExchangeRate.GetLength(0); i++)
        {
            for (int j = 0; j < CurrencyExchangeRate.GetLength(1); j++)
            {
                CurrencyExchangeRate[i, j] = rnd.Next(100);
            }
        }

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
                    Console.WriteLine($"На вашем счету {BalanceRub:f2} рублей;");
                    Console.WriteLine($"На вашем счету {BalanceDollar:f2} долларов;");
                    Console.WriteLine($"На вашем счету {BalanceEuro:f2} евро;");
                    Console.WriteLine("Нажмите Enter для выхода.");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("В какой валюте вы хотите пополнить баланс?");
                    Console.WriteLine("Нажмите:");
                    Console.WriteLine("1 для пополнения в Рублях;\n2 для пополнения в Долларах;\n3 для пополнения в Евро.");
                    int VarUser = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите сумму для пополнения баланса:");
                    double Amount = double.Parse(Console.ReadLine());
                    if (VarUser == 1)
                    {
                        BalanceRub += Amount;
                    }
                    else if (VarUser == 2)
                    {
                        BalanceDollar += Amount;
                    }
                    else if (VarUser == 3)
                    {
                        BalanceEuro += Amount;
                    }
                    else
                    {
                        Console.WriteLine("Вы не правильно выбрали способ пополнения баланса.");
                    }
                    Console.Clear();
                    Console.WriteLine("Нажмите на Enter.");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D3:
                    Console.Clear();
                    PrintCurrencyExchangeRates();
                    Console.WriteLine("Нажмите на Enter.");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D4:
                    Console.Clear();

                    Console.WriteLine("Выберите из какой валюты вы хотите перевести:\n1 - Рубли;\n2 - Доллары;\n3 - Евро:");
                    int SourceCurrency = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Выберите в какую валюту вы хотите перевести:\n1 - Рубли;\n2 - Доллары;\n3 - Евро:");
                    int TargetCurrency = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Введите сумму перевода:");
                    double AmountToConvert = double.Parse(Console.ReadLine());

                    double ExchangeRate = CurrencyExchangeRate[SourceCurrency - 1, TargetCurrency - 1];
                    double ConvertedAmount = ConvertCurrency(AmountToConvert, ExchangeRate);

                    UpdateBalances(SourceCurrency, TargetCurrency, AmountToConvert, ConvertedAmount);

                    Console.WriteLine($"Конвертировано: {AmountToConvert} {GetCurrencyName(SourceCurrency)} -> {ConvertedAmount} {GetCurrencyName(TargetCurrency)}");
                    Console.WriteLine("Нажмите на Enter.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void PrintCurrencyExchangeRates()
    {
        Console.Clear();
        Console.WriteLine("Курсы валют:");
        for (int i = 0; i < CurrencyExchangeRate.GetLength(0); i++)
        {
            for (int j = 0; j < CurrencyExchangeRate.GetLength(1); j++)
            {
                Console.Write(CurrencyExchangeRate[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static double ConvertCurrency(double amount, double exchangeRate)
    {
        return amount / exchangeRate;
    }

    static string GetCurrencyName(int currencyCode)
    {
        switch (currencyCode)
        {
            case 1:
                return "рублей";
            case 2:
                return "долларов";
            case 3:
                return "евро";
            default:
                return "неверной валюты";
        }
    }

    static void UpdateBalances(int sourceCurrency, int targetCurrency, double sourceAmount, double targetAmount)
    {
        if (sourceCurrency == 1)
        {
            BalanceRub -= sourceAmount;
        }
        else if (sourceCurrency == 2)
        {
            BalanceDollar -= sourceAmount;
        }
        else if (sourceCurrency == 3)
        {
            BalanceEuro -= sourceAmount;
        }

        if (targetCurrency == 1)
        {
            BalanceRub += targetAmount;
        }
        else if (targetCurrency == 2)
        {
            BalanceDollar += targetAmount;
        }
        else if (targetCurrency == 3)
        {
            BalanceEuro += targetAmount;
        }
    }
}