namespace ORRApiRest
{
    public class SalonWithCars
    {
        public SalonWithCars(int id, string name, List<Car> salonCars)
        {
            Id = id;
            Name = name;
            CarList = salonCars;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> CarList { get; set; }
    }
}
