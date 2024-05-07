using System;

namespace ChainOfResponsibilityPattern
{
    public abstract class Handler
    {
        protected Handler _nextHandler;

        public Handler SetNext(Handler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public abstract void HandleRequest(string request);
    }

    public class SaleHandler : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "sprzedaż")
            {
                Console.WriteLine("Sprzedano produkt.");
            }
            else
            {
                _nextHandler?.HandleRequest(request);
            }
        }
    }

    public class InternetHandler : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "internet")
            {
                Console.WriteLine("Naprawiono problem z internetem.");
            }
            else
            {
                _nextHandler?.HandleRequest(request);
            }
        }
    }

    // Konkretny handler dla obsługi telefonu
    public class PhoneHandler : Handler
    {
        public override void HandleRequest(string request)
        {
            if (request == "telefon")
            {
                Console.WriteLine("Naprawiono problem z telefonem.");
            }
            else
            {
                _nextHandler?.HandleRequest(request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie łańcucha obsługi
            var saleHandler = new SaleHandler();
            var internetHandler = new InternetHandler();
            var phoneHandler = new PhoneHandler();

            saleHandler.SetNext(internetHandler).SetNext(phoneHandler);


            saleHandler.HandleRequest("telefon");
            saleHandler.HandleRequest("internet");
            saleHandler.HandleRequest("sprzedaż");
            saleHandler.HandleRequest("inny problem");

        }
    }
}

