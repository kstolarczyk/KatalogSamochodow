namespace Stolarczyk.Katalog.BL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.INTERFACES;

    public class CarWrapper : BaseWrapper
    {
        public ICar Car { get; private set; }

        public CarWrapper(ICar car)
        {
            Car = car;
            brand = car.Brand;
            model = car.Model;
            year = car.Year.ToString();
            mileage = car.Mileage.ToString();
            acceleration = car.Acceleration.ToString(CultureInfo.InvariantCulture);
            topspeed = car.TopSpeed.ToString();
            maxpower = car.MaxPower.ToString();
            displacement = car.Displacement.ToString();
            manufacturer = Car.Manufacturer;
            foreach (var propertyInfo in typeof(CarWrapper).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                ValidateDataAnnotation(propertyInfo.GetValue(this), propertyInfo.Name);
            }
        }


        private string brand;

        [Required]
        public string Brand
        {
            get => brand;
            set
            {
                brand = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Brand = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private string model;
        [Required]
        public string Model 
        {
            get => model;
            set
            {
                model = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Model = value;
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private string year;
        [Required]
        [RegularExpression(@"\d+")]
        public string Year
        {
            get => year;
            set
            {
                year = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Year = int.Parse(value);
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private string mileage;
        [Required]
        [RegularExpression(@"\d+")]
        public string Mileage
        {
            get => mileage;
            set
            {
                mileage = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Mileage = int.Parse(value);
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        [Required]
        public FuelType FuelType
        {
            get => Car.FuelType;
            set
            {
                Car.FuelType = value;
                OnPropertyChanged();
            }
        }

        private string maxpower;
        [Required]
        [RegularExpression(@"\d+")]
        public string MaxPower
        {
            get => maxpower;
            set
            {
                maxpower = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.MaxPower = int.Parse(value);
                    ClearErrors();
                }

                OnPropertyChanged();
            }
        }

        private string displacement;
        [Required]
        [RegularExpression(@"\d+")]
        public string Displacement
        {
            get => displacement;
            set
            {
                displacement = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Displacement = int.Parse(value);
                    ClearErrors();
                }
                OnPropertyChanged();
            }
        }

        private string acceleration;
        [Required]
        [RegularExpression(@"\d+(\.\d+)?")]
        public string Acceleration
        {
            get => acceleration;
            set
            {
                acceleration = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Acceleration = float.Parse(value, CultureInfo.InvariantCulture);
                    ClearErrors();
                }
                OnPropertyChanged();
            }
        }

        private string topspeed;
        [Required]
        [RegularExpression(@"\d+")]
        public string TopSpeed
        {
            get => topspeed;
            set
            {
                topspeed = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.TopSpeed = int.Parse(value);
                    ClearErrors();
                }
                OnPropertyChanged();
            }
        }

        private IManufacturer manufacturer;
        [Required]
        public IManufacturer Manufacturer
        {
            get => manufacturer;
            set
            {
                manufacturer = value;
                if (ValidateDataAnnotation(value))
                {
                    Car.Manufacturer = value;
                    ClearErrors();
                }
                OnPropertyChanged();
            }
        }
    }
}