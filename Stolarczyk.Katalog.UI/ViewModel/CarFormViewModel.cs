namespace Stolarczyk.Katalog.UI.ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;

    using Prism.Commands;

    using Stolarczyk.Katalog.BL;
    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.INTERFACES;

    class CarFormViewModel
    {
        public CarFormViewModel(ICar car, IEnumerable<IManufacturer> manufacturers)
        {
            Car = new CarWrapper(car);
            Manufacturers = manufacturers;
            FuelTypes = typeof(FuelType).GetEnumValues();
            Car.PropertyChanged += Car_PropertyChanged;
        }

        private void Car_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Car.HasErrors))
            {
                (Window.ZapiszButton.Command as DelegateCommand)?.RaiseCanExecuteChanged();
            }
        }

        public IEnumerable FuelTypes { get; set; }

        public IEnumerable<IManufacturer> Manufacturers { get; set; }

        public CarWrapper Car { get; set; }

        public bool CanSave() => !Car.HasErrors;

        public FormWindow Window { get; set; }
    }
}
