namespace Stolarczyk.Katalog.DAO
{
    using System.Collections.Generic;
    using System.Linq;

    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.INTERFACES;

    public class DaoMock : IDataProvider
    {

        private static int currentCarId = 8;

        private static int currentManufacturerId = 4;

        private static List<IManufacturer> Manufacturers = new List<IManufacturer>()
        {
            new Manufacturer() {Id = 1, Name = "Volkswagen Group"},
            new Manufacturer() {Id = 2,Name = "Ford Motor Company"},
            new Manufacturer() {Id = 3, Name = "Groupe PSA"},
            new Manufacturer() {Id = 4, Name = "Toyota Motor Corporation"}
        };

        private static List<ICar> Cars = new List<ICar>() 
                                      {
             new Car() {Id = 1, Brand = "Audi", Model = "A4", Year = 2004, Manufacturer = Manufacturers[0], Mileage = 250000, FuelType = FuelType.DIESEL, MaxPower = 131, Displacement = 1896, Acceleration = 10.1f, TopSpeed = 208},
             new Car() {Id = 2, Brand = "Volkswagen", Model = "Passat", Year = 2008, Manufacturer = Manufacturers[0], Mileage = 310000, FuelType = FuelType.PETROL, MaxPower = 160, Displacement = 1798, Acceleration = 8.6f, TopSpeed = 220},
             new Car() {Id = 3, Brand = "Ford", Model = "Mondeo", Year = 2012, Manufacturer = Manufacturers[1], Mileage = 160000, FuelType = FuelType.DIESEL, MaxPower = 115, Displacement = 1560, Acceleration = 11.9f, TopSpeed = 190},
             new Car() {Id = 4, Brand = "Ford", Model = "Mondeo", Year = 2019, Manufacturer = Manufacturers[1], Mileage = 2500, FuelType = FuelType.HYBRID, MaxPower = 187, Displacement = 1999, Acceleration = 9.4f, TopSpeed = 187},
             new Car() {Id = 5, Brand = "Peugeot", Model = "407", Year = 2007, Manufacturer = Manufacturers[2], Mileage = 280000, FuelType = FuelType.PETROL, MaxPower = 140, Displacement = 1997, Acceleration = 9.5f, TopSpeed = 209},
             new Car() {Id = 6, Brand = "Peugeot", Model = "E-209", Year = 2019, Manufacturer = Manufacturers[2], Mileage = 1000, FuelType = FuelType.ELECTRIC, MaxPower = 136, Displacement = 0, Acceleration = 8.1f, TopSpeed = 150},
             new Car() {Id = 7, Brand = "Toyota", Model = "Corolla", Year = 2019, Manufacturer = Manufacturers[3], Mileage = 2000, FuelType = FuelType.HYBRID, MaxPower = 180, Displacement = 1987, Acceleration = 7.9f, TopSpeed = 180},
             new Car() {Id = 8, Brand = "Toyota", Model = "Celica", Year = 2005, Manufacturer = Manufacturers[3], Mileage = 190000, FuelType = FuelType.GAS, MaxPower = 192, Displacement = 1796, Acceleration = 7.4f, TopSpeed = 225}
         };
        public IEnumerable<ICar> GetCars()
        {
            return Cars;
        }

        public IEnumerable<IManufacturer> GetManufacturers()
        {
            return Manufacturers;
        }

        public void SaveCars(IEnumerable<ICar> cars)
        {
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }

        public void SaveManufacturers(IEnumerable<IManufacturer> manufacturers)
        {
            Manufacturers.Clear();
            foreach (var manufacturer in manufacturers)
            {
                Manufacturers.Add(manufacturer);
            }
        }

        public void AddCar(ICar car)
        {
            car.Id = ++currentCarId;
            Cars.Add(car);
        }

        public void AddManufacturer(IManufacturer manufacturer)
        {
            manufacturer.Id = ++currentManufacturerId;
            Manufacturers.Add(manufacturer);
        }

        public bool RemoveCar(ICar car)
        {
            return Cars.Remove(car);
        }

        public bool RemoveManufacturer(IManufacturer manufacturer)
        {
            return Manufacturers.Remove(manufacturer);
        }
    }
}