using System;

namespace EpamInterviewTask
{
    enum TypeOfClient
    {
        normal, limited, withBenifits1, withBenifits2
    }


    class Client : Human, IComparable
    {
        public int ElEnergy { get; set; }                                               //количество потребленной эл. энергии клиентом
        public TypeOfClient Status { get; set; }                                        //тип клиента
        public decimal Payment { get; set; }                                            //сумма платежа
        public static decimal Tariff { get; set; }                                      //тариф на эл. энергию

        //сортировка клиентов по количеству потребленной эл. энергии в порядке убывания
        public int CompareTo(object obj)
        {
            if (obj is Client)
                return ~ElEnergy.CompareTo((obj as Client).ElEnergy);                   // '-' нужен для того, чтобы сортировать по убыванию
            throw new NotImplementedException();
        }

        //Вычисление суммы платежа за затраченную эл. энергию
        public void PaymentCalculation()
        {
            switch (Status)
            {
                case TypeOfClient.normal:
                    Payment = Math.Round(ElEnergy * Tariff, 2);
                    break;
                case TypeOfClient.limited:
                    if (ElEnergy <= 150)
                        Payment = Math.Round(ElEnergy * Tariff, 2);
                    if (ElEnergy > 150)
                        Payment = Math.Round(150 * Tariff + ((ElEnergy - 150) * (Tariff + Tariff * 0.33m)), 2);
                    break;
                case TypeOfClient.withBenifits1:
                    Payment = Math.Round(ElEnergy * Tariff * 0.66m, 2);
                    break;
                case TypeOfClient.withBenifits2:
                    if (ElEnergy <= 50)
                        Payment = 0.0m;
                    if (ElEnergy > 50)
                        Payment = Math.Round((ElEnergy - 50) * Tariff, 2);
                    break;
            }
        }

        //Конвертирование перечислимого типа в строку для вывода типа клиентов
        public string ConvertStatus()
        {
            string temp = "";
            switch (Status)
            {
                case TypeOfClient.normal:
                    temp = "Стандарт";
                    break;
                case TypeOfClient.limited:
                    temp = "Лимитированный";
                    break;
                case TypeOfClient.withBenifits1:
                    temp = "Льготный 1";
                    break;
                case TypeOfClient.withBenifits2:
                    temp = "Льготный 2";
                    break;
            }
            return temp;
        }

        public override string ToString()
        {
            return base.ToString() + $"\tСтатус: {ConvertStatus()}\tКол-во эл. энергии: {ElEnergy}\tСумма платежа: {Payment} руб.";
        }
    }

}