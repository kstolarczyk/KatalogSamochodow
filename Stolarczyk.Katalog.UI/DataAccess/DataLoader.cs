using System;
using System.Collections.Generic;
using System.Text;

namespace Stolarczyk.Katalog.UI.DataAccess
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Options;

    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.INTERFACES;

    public class DataLoader : IDataLoader
    {
        private AppSettings _settings;

        private Assembly _assembly;

        private IDataProvider _dataProvider;

        public DataLoader(IOptions<AppSettings> options)
        {
            _settings = options.Value;
            _assembly = Assembly.UnsafeLoadFrom(_settings.CarsLibrary);
            var type = _assembly.GetTypes().SingleOrDefault(t => typeof(IDataProvider).IsAssignableFrom(t));
            if(type != null)
            {
                _dataProvider = Activator.CreateInstance(type) as IDataProvider;
            }
        }

        public IEnumerable<ICar> GetCars(string filterText, FuelType fuelType, IManufacturer manufacturer)
        {
            var result = _dataProvider.GetCars().Where(c => c.Contains(filterText));
            if(fuelType != 0)
            {
                result = result.Where(c => c.FuelType == fuelType);
            }
            if (manufacturer != null)
            {
                result = result.Where(c => c.Manufacturer == manufacturer);
            }
            return result;
        }

        public IEnumerable<IManufacturer> GetManufacturers()
        {
            return _dataProvider.GetManufacturers().ToList();
        }

        public void AddCar(ICar car)
        {
            _dataProvider.AddCar(car);
        }

        public void SaveCars(IEnumerable<ICar> cars)
        {
            _dataProvider.SaveCars(cars);
        }
        public bool RemoveCar(int id)
        {
            var car = _dataProvider.GetCars().FirstOrDefault(c => c.Id == id);
            if (car == null) return false;
            return _dataProvider.RemoveCar(car);
        }
    }
}
