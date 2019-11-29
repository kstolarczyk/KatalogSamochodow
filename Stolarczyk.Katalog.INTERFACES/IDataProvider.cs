namespace Stolarczyk.Katalog.INTERFACES
{
    using System.Collections.Generic;

    public interface IDataProvider
    {
        IEnumerable<ICar> GetCars();

        IEnumerable<IManufacturer> GetManufacturers();

        void SaveCars(IEnumerable<ICar> cars);

        void SaveManufacturers(IEnumerable<IManufacturer> manufacturers);

        void AddCar(ICar car);

        void AddManufacturer(IManufacturer manufacturer);

        bool RemoveCar(ICar car);

        bool RemoveManufacturer(IManufacturer manufacturer);

    }
}