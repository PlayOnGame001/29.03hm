using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29._03hm
{
    interface Rece
    {
        Rece SetNext(Rece receiver);
        object Handle(object request);
    }
    abstract class Client_Pay : Rece
    {
        private Rece client_Pay;

        public Rece SetNext(Rece receiver)
        {
            client_Pay = receiver;
            return receiver;
        }
        public virtual object Handle(object request)
        {
            if (this.client_Pay != null)
            {
                return this.client_Pay.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
    class Money_Client : Client_Pay
    {
        public override object Handle(object request)
        {
            if (request as string == "Деньги")
            {
                return "Деньги клиента";
            }
            else
            {
                return base.Handle(request); ;
            }
        }
    }
    class Privat_Client : Client_Pay
    {
        public override object Handle(object request)
        {
            if (request as string == "Привет")
            {
                return "Приват клиент";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    class Tottal_Money_client : Client_Pay
    {
        public override object Handle(object request)
        {
            if (request as string == "Счет")
            {
                return "Счет клиента";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    class Client
    {
        public void ClientCode(Client_Pay ph)
        {
            foreach (var payment in new List<string> { "Деньги", "Счет", "Приват" })
            {
                Console.WriteLine($"Клиент которому нуждны средства - {payment}?");
                var result = ph.Handle(payment);
                if (result != null)
                {
                    Console.Write($"    {result}\n");
                }
                else { Console.WriteLine($"   {payment} - Средства одобрены."); }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var money = new Money_Client();
            var privat = new Privat_Client();
            var score = new Tottal_Money_client();
            money.SetNext(privat).SetNext(score);
            Client client = new Client();
            client.ClientCode(money);
        }
    }
}