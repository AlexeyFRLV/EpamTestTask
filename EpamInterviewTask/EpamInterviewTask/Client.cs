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
}
