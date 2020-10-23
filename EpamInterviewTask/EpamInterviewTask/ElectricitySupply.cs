using System;
using System.Collections;

namespace EpamInterviewTask
{
    class ElectricitySupply : IEnumerable
    {
        Client[] clients;                                                               //список клиентов
        public decimal SUM { get; set; } = 0;                                           //общая сумма платежей всех клиентов
        public decimal LG { get; set; } = 0;                                            //общий размер льготы


        public ElectricitySupply(Client[] clients)
        {
            this.clients = clients;
        }

        //Метод сортировки клиентов по количесвту потребленной эл. энергии
        public void Sort()
        {
            Array.Sort(clients);
        }

        //Метод сортировки клиентов по величине платежа
        public void Sort(IComparer comparer)
        {
            Array.Sort(clients, comparer);
        }

        //Метод сортировки клиентов по типу клиентов
        public void StatusSort(IComparer comparer)
        {
            Array.Sort(clients, comparer);
        }

        //Общая сумма платежей всех клиентов
        public void TotalAmount()
        {
            foreach (Client item in clients)
            {
                SUM += item.Payment;
            }
        }

        //Общий размер льготы
        public void TotalBenifits()
        {
            decimal sum0 = 0.0m;
            foreach (Client item in clients)
            {
                sum0 += item.ElEnergy * Client.Tariff;
            }
            LG = sum0 - SUM;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return clients.GetEnumerator();
        }
    }

    //Вспомогательный класс интерфейса IComparer для перегрузки сортировки по "Платежам"
    class PaymentComparer : IComparer
    {
        public int Compare(object ob1, object ob2)
        {
            if (ob1 is Client && ob2 is Client)
            {
                return (int)Math.Round(((ob1 as Client).Payment - (ob2 as Client).Payment), MidpointRounding.AwayFromZero);
            }
            throw new NotImplementedException();
        }
    }

    //Вспомогательный класс интерфейса IComparer для упорядочивания по типу клиентов
    class StatusComparer : IComparer
    {
        public int Compare(object ob1, object ob2)
        {
            if (ob1 is Client && ob2 is Client)
            {
                return (ob1 as Client).Status - (ob2 as Client).Status;
            }
            throw new NotImplementedException();
        }
    }

}
