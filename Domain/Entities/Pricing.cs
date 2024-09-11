namespace SerwisMotoryzacyjny.Domain.Entities
{
    public class Pricing
    {
        public int Id { get; set; } // Identyfikator usługi
        public string ServiceName { get; set; } // Nazwa usługi
        public decimal ServicePrice { get; set; } // Cena usługi
    }
}
