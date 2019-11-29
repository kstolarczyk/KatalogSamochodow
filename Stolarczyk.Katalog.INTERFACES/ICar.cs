namespace Stolarczyk.Katalog.INTERFACES
{
    using Stolarczyk.Katalog.CORE;

    public interface ICar
    {
        int Id { get; set; }

        string Brand { get; set; }

        string Model { get; set; }

        int Year { get; set; }

        int Mileage { get; set; }

        FuelType FuelType { get; set; }

        int Displacement { get; set; }

        int MaxPower { get; set; }

        int TopSpeed { get; set; }

        float Acceleration { get; set; }

        IManufacturer Manufacturer { get; set; }

        bool Contains(string filterText);
    }
}