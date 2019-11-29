namespace Stolarczyk.Katalog.DAO
{
    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.INTERFACES;

    public class Car : ICar
    {
        public int Id {get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Mileage {get; set; }

        public FuelType FuelType { get; set; }

        public int Displacement { get; set; }

        public int MaxPower { get; set; }

        public int TopSpeed { get; set; }

        public float Acceleration { get; set; }

        public IManufacturer Manufacturer { get; set; }

        private string SearchField => Brand + Model + Year;
        public bool Contains(string filterText)
        {
            return SearchField.ToLower().Replace(" ", string.Empty).Contains(filterText.ToLower().Replace(" ", string.Empty));
        }
    }
}
