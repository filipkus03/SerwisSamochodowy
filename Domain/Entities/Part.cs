namespace SerwisMotoryzacyjny.Domain.Entities
{
    public class Part
    {
        public int Id { get; set; }  // Klucz główny w bazie danych
        public string Name { get; set; }  // Nazwa części
        public string Description { get; set; }  // Opis części
        public decimal Price { get; set; }  // Cena części
        public int Quantity { get; set; }  // Ilość w magazynie
    }
}
