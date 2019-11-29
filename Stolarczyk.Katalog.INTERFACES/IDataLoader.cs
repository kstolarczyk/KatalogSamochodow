namespace Stolarczyk.Katalog.INTERFACES
{
    using System.Collections.Generic;

    using Stolarczyk.Katalog.CORE;

    public interface IDataLoader
    {
        IEnumerable<ICar> GetCars(string filterText, FuelType fuelType, IManufacturer manufacturer);

        IEnumerable<IManufacturer> GetManufacturers();

        void AddCar(ICar car);

        bool RemoveCar(int id);
        void SaveCars(IEnumerable<ICar> cars);
    }
}