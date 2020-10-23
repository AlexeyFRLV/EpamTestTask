using System;

namespace EpamInterviewTask
{
    class ElectricitySupply
    {
        Client[] clients;                                                               //список клиентов
        public decimal SUM { get; set; } = 0;                                           //общая сумма платежей всех клиентов
        public decimal LG { get; set; } = 0;                                            //общий размер льготы


        public ElectricitySupply(Client[] clients)
        {
            this.clients = clients;
        }

    }
}
