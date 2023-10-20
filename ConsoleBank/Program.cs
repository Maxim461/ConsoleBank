double BalanceRub = 0;
double BalanceDollar = 0;
double BalanceEuro = 0;
int[,] CurrencyExchangeRate = new int[2, 10];
bool VarName = false;
Random rnd = new Random();

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
            Console.WriteLine("1 для пополнения в Рублях;");
            Console.WriteLine("2 для пополнения в Долларах;");
            Console.WriteLine("3 для пополнения в Евро.");
            Console.WriteLine("Далее нажмите Enter.");
            int VarUser = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму для пополнения баланса:");
            if (VarUser == 1)
            {
                BalanceRub = int.Parse(Console.ReadLine());
            }
            else if (VarUser == 2)
            {
                BalanceDollar = int.Parse(Console.ReadLine());
            }
            else if (VarUser == 3)
            {
                BalanceEuro = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Вы не правильно выбрали способ пополнения баланса.");
            }
            Console.WriteLine("Нажмите на Enter.");
            break;

        case ConsoleKey.D3:

            Console.Clear();
               
            SortRows(CurrencyExchangeRate);
            
            for (int i = 0; i < CurrencyExchangeRate.GetLength(0); i++)
            {
                for (int j = 0; j < CurrencyExchangeRate.GetLength(1); j++)
                {
                    Console.Write(CurrencyExchangeRate[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Нажмите на Enter.");
            Console.ReadLine();
            break;

        case ConsoleKey.D4:
            Console.Clear();
            Console.WriteLine("Выберите во что вы хотите перевести:");
            Console.WriteLine("1 - Из рублей в доллары;");
            Console.WriteLine("2 - Из рубей в евро;");
            Console.WriteLine("3 - Из долларов в рубли;");
            Console.WriteLine("4 - Из долларов в евро;");
            Console.WriteLine("5 - Из евро в рубли;");
            Console.WriteLine("6 - Из евро в доллары.");
            Console.WriteLine("Нажмите Enter для выхода.");

            int UserVar = int.Parse(Console.ReadLine());
            Console.Clear();
            double minDol = CurrencyExchangeRate[0, 0];
            double minEuro = CurrencyExchangeRate[0, 0];
            double minRub = CurrencyExchangeRate[0, 0];
            if (UserVar == 1)
            {
                BalanceDollar = BalanceRub / minDol;
                BalanceRub = 0;
            }
            else if (UserVar == 2)
            {
                BalanceEuro = BalanceRub / minEuro;
                BalanceRub = 0;
            }
            else if (UserVar == 3)
            {
                BalanceRub = BalanceDollar / minRub;
                BalanceDollar = 0;
            }
            else if (UserVar == 4)
            {
                BalanceEuro = BalanceDollar / minEuro;
                BalanceDollar = 0;
            }
            else if (UserVar == 5)
            {
                BalanceRub = BalanceEuro / minRub;
                BalanceEuro = 0;
            }
            else if (UserVar == 6)
            {
                BalanceDollar = BalanceEuro / minDol;
                BalanceEuro = 0;
            }
            Console.WriteLine("Операция успешно выполнена.");
            Console.ReadLine();
            break;
    }
}
    
static void SortRows(int[,] CurrencyExchangeRate)
{
    int Rows = CurrencyExchangeRate.GetLength(0);
    int Columns = CurrencyExchangeRate.GetLength(1);

    for (int i = 0; i < Rows; i++)
    {
        // Создаем временный массив для сортировки строки
        int[] TempRow = new int[Columns];
        for (int j = 0; j < Columns; j++)
        {
            TempRow[j] = CurrencyExchangeRate[i, j];
        }

        // Сортируем временный массив
        Array.Sort(TempRow);

        // Копируем отсортированные значения обратно в исходную строку
        for (int j = 0; j < Columns; j++)
        {
            CurrencyExchangeRate[i, j] = TempRow[j];
        }
    }
}