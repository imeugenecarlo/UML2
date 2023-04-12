namespace UML2
{
    public class Pizza
    {

        public int Number { get; set; }
        public string Name { get; set; }

        // Hvis jeg skal have en description
        //public string Description { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Nr.{Number}  {Name} Pris:{Price}kr";
        }
    }
}