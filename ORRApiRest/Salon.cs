namespace ORRApiRest
{
    public class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car>? CarList { get; set; }
    }
}
