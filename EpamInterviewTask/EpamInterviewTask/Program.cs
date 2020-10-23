using System;

namespace EpamInterviewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Client[] clients =
{
                new Client
                {
                    LastName = "Doe",
                    FirstName = "John",
                    BirthDate = new DateTime(1990,10,4),
                    ElEnergy = 250,
                    Status = TypeOfClient.limited
                },
                new Client
                {
                    LastName = "Smith",
                    FirstName = "Bob",
                    BirthDate = new DateTime(1988,12,1),
                    ElEnergy = 490,
                    Status = TypeOfClient.normal
                },
                new Client
                {
                    LastName = "Fox",
                    FirstName = "Dorian",
                    BirthDate = new DateTime(1978,2,14),
                    ElEnergy = 300,
                    Status = TypeOfClient.withBenifits1
                },
                new Client
                {
                    LastName = "Landwood",
                    FirstName = "Alice",
                    BirthDate = new DateTime(1980,3,15),
                    ElEnergy = 1000,
                    Status = TypeOfClient.withBenifits2
                },
                new Client
                {
                    LastName = "Scofield",
                    FirstName = "Jane",
                    BirthDate = new DateTime(1977,4,12),
                    ElEnergy = 429,
                    Status = TypeOfClient.limited
                },
                new Client
                {
                    LastName = "Fernandes",
                    FirstName = "Samuel",
                    BirthDate = new DateTime(1970,10,12),
                    ElEnergy = 659,
                    Status = TypeOfClient.normal
                },
                new Client
                {
                    LastName = "Dunlo",
                    FirstName = "Oliver",
                    BirthDate = new DateTime(1962,7,22),
                    ElEnergy = 130,
                    Status = TypeOfClient.limited
                },
                new Client
                {
                    LastName = "Jackson",
                    FirstName = "Ryan",
                    BirthDate = new DateTime(1990,8,12),
                    ElEnergy = 20,
                    Status = TypeOfClient.withBenifits2
                },
                new Client
                {
                    LastName = "De Maria",
                    FirstName = "Santos",
                    BirthDate = new DateTime(1959,9,2),
                    ElEnergy = 630,
                    Status = TypeOfClient.withBenifits2
                },
                new Client
                {
                    LastName = "Scrum",
                    FirstName = "Ethan",
                    BirthDate = new DateTime(1979,6,10),
                    ElEnergy = 305,
                    Status = TypeOfClient.withBenifits1
                },
                new Client
                {
                    LastName = "Ferdinand",
                    FirstName = "Austin",
                    BirthDate = new DateTime(1977,4,29),
                    ElEnergy = 429,
                    Status = TypeOfClient.normal
                },
                new Client
                {
                    LastName = "Kruse",
                    FirstName = "Connor",
                    BirthDate = new DateTime(1988,7,1),
                    ElEnergy = 541,
                    Status = TypeOfClient.withBenifits1
                }
            };
            //Задаем тариф на еденицу эл. энергии
            Client.Tariff = 0.15m;

            ElectricitySupply elSupply = new ElectricitySupply(clients);

            //Рассчитываем сумму платежей
            foreach (Client item in elSupply)
            {
                item.PaymentCalculation();
            }

            //автоподстройка ширины каждого столбца таблицы
            for (int i = 0; i < clients.Length; i++)
            {
                Table.widthCol1 = Table.widthCol1 < clients[i].LastName.Length ? clients[i].LastName.Length + 2 : Table.widthCol1;
                Table.widthCol2 = Table.widthCol2 < clients[i].FirstName.Length ? clients[i].FirstName.Length + 2 : Table.widthCol2;
                Table.widthCol3 = Table.widthCol3 < clients[i].BirthDate.ToShortDateString().Length ? clients[i].BirthDate.ToShortDateString().Length + 2 : Table.widthCol3;
                Table.widthCol4 = Table.widthCol4 < clients[i].ConvertStatus().Length ? clients[i].ConvertStatus().Length + 2 : Table.widthCol4;
                Table.widthCol5 = Table.widthCol5 < clients[i].ElEnergy.ToString().Length ? clients[i].ElEnergy.ToString().Length + 2 : Table.widthCol5;
                Table.widthCol6 = Table.widthCol6 < clients[i].Payment.ToString().Length ? clients[i].Payment.ToString().Length + 2 : Table.widthCol6;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\tCписок клиентов");
            Console.ResetColor();
            Table.Head();
            for (int i = 0; i < clients.Length; i++)
            {
                Table.Line(clients[i]);
                if (i != clients.Length - 1)
                    Table.afterLine();
            }
            Table.End();
            Console.WriteLine();

            //Сортивока по количеству потребленной клиентами энергии по убыванию
            elSupply.Sort();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Отсортированный список клиентов по количеству потребленной клиентами энергии в порядке убывания");
            Console.ResetColor();
            Table.Head();
            for (int i = 0; i < clients.Length; i++)
            {
                Table.Line(clients[i]);
                if (i != clients.Length - 1)
                    Table.afterLine();
            }
            Table.End();
            Console.WriteLine();

            //Сортировка по величине оплаты клиентами по возрастанию
            elSupply.Sort(new PaymentComparer());
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\tСортировка по величине платежей по возрастанию");
            Console.ResetColor();
            Table.Head();
            for (int i = 0; i < clients.Length; i++)
            {
                Table.Line(clients[i]);
                if (i != clients.Length - 1)
                    Table.afterLine();
            }
            Table.End();
            Console.WriteLine();

            //Упорядочиваем массив по типу клиентов
            elSupply.StatusSort(new StatusComparer());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t\t\t\tУпорядочиваем по типу клиентов");
            Console.ResetColor();
            Table.Head();
            for (int i = 0; i < clients.Length; i++)
            {
                Table.Line(clients[i]);
                if (i != clients.Length - 1)
                    Table.afterLine();
            }
            Table.End();
            Console.WriteLine();

            //Общая сумма оплаты всех клиентов за потреблённую энергию
            elSupply.TotalAmount();
            Console.WriteLine($"Общая сумма платежей всех клиентов : {elSupply.SUM} руб.");
            Console.WriteLine();

            //Общая размер льготы
            elSupply.TotalBenifits();
            Console.WriteLine($"Общий размер льготы: {elSupply.LG} руб.");
            Console.WriteLine();
        }
    }
}
