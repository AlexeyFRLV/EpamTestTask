using System;

namespace EpamInterviewTask
{
    static class Table
    {
            static public int widthCol1 { get; set; }
            static public int widthCol2 { get; set; }
            static public int widthCol3 { get; set; }
            static public int widthCol4 { get; set; }
            static public int widthCol5 { get; set; }
            static public int widthCol6 { get; set; }

            static private string nameCols1;
            static private string nameCols2;
            static private string nameCols3;
            static private string nameCols4;
            static private string nameCols5;
            static private string nameCols6;

            static Table()
            {
                nameCols1 = "Фамилия";
                nameCols2 = "Имя";
                nameCols3 = "Дата рождения";
                nameCols4 = "Статус";
                nameCols5 = "Кол-во эл. энергии";
                nameCols6 = "Сумма платежа";

                widthCol1 = 0;
                widthCol2 = 0;
                widthCol3 = nameCols3.Length;
                widthCol4 = 0;
                widthCol5 = nameCols5.Length;
                widthCol6 = nameCols6.Length;
            }
            public static void Head()     //Вывод шапки
            {
                Console.Write("┌");
                Console.Write(new string('─', widthCol1));
                Console.Write("┬");
                Console.Write(new string('─', widthCol2));
                Console.Write("┬");
                Console.Write(new string('─', widthCol3));
                Console.Write("┬");
                Console.Write(new string('─', widthCol4));
                Console.Write("┬");
                Console.Write(new string('─', widthCol5));
                Console.Write("┬");
                Console.Write(new string('─', widthCol6));
                Console.WriteLine("┐");

                string s = "|{0,-" + widthCol1.ToString() + "}|{1,-" + widthCol2.ToString() + "}|{2,-" + widthCol3.ToString() + "}|{3,-" + widthCol4.ToString() + "}|{4,-" + widthCol5.ToString() + "}|{5,-" + widthCol6.ToString() + "}|";
                Console.WriteLine(s, nameCols1, nameCols2, nameCols3, nameCols4, nameCols5, nameCols6);

                Console.Write("├");
                Console.Write(new string('─', widthCol1));
                Console.Write("┼");
                Console.Write(new string('─', widthCol2));
                Console.Write("┼");
                Console.Write(new string('─', widthCol3));
                Console.Write("┼");
                Console.Write(new string('─', widthCol4));
                Console.Write("┼");
                Console.Write(new string('─', widthCol5));
                Console.Write("┼");
                Console.Write(new string('─', widthCol6));
                Console.WriteLine("┤");
            }

            public static void Line(Client client)                   //Вывод строки
            {
                string s = "|{0,-" + widthCol1.ToString() + "}|{1,-" + widthCol2.ToString() + "}|{2,-" + widthCol3.ToString() + "}|{3,-" + widthCol4.ToString() + "}|{4,-" + widthCol5.ToString() + "}|{5,-" + widthCol6.ToString() + "}|";
                Console.WriteLine(s, client.LastName, client.FirstName, client.BirthDate.ToShortDateString(), client.ConvertStatus(), client.ElEnergy, client.Payment);
            }

            public static void afterLine()
            {
                Console.Write("├");
                Console.Write(new string('─', widthCol1));
                Console.Write("┼");
                Console.Write(new string('─', widthCol2));
                Console.Write("┼");
                Console.Write(new string('─', widthCol3));
                Console.Write("┼");
                Console.Write(new string('─', widthCol4));
                Console.Write("┼");
                Console.Write(new string('─', widthCol5));
                Console.Write("┼");
                Console.Write(new string('─', widthCol6));
                Console.WriteLine("┤");
            }

            public static void End()              //Вывод основания
            {
                Console.Write("└");
                Console.Write(new string('─', widthCol1));
                Console.Write("┴");
                Console.Write(new string('─', widthCol2));
                Console.Write("┴");
                Console.Write(new string('─', widthCol3));
                Console.Write("┴");
                Console.Write(new string('─', widthCol4));
                Console.Write("┴");
                Console.Write(new string('─', widthCol5));
                Console.Write("┴");
                Console.Write(new string('─', widthCol6));
                Console.WriteLine("┘");
            }
    }
}
