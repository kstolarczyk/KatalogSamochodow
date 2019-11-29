namespace Stolarczyk.Katalog.UI.ViewModel
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Microsoft.Extensions.DependencyInjection;

    using Prism.Commands;

    using Stolarczyk.Katalog.CORE;
    using Stolarczyk.Katalog.DAO;
    using Stolarczyk.Katalog.INTERFACES;
    using Stolarczyk.Katalog.UI.Services;
    using Stolarczyk.Katalog.UI.View;

    public class MainViewModel : INotifyPropertyChanged
    {
        private IDataLoader _dataLoader;

        private string filterText;

        private IFormWindowService _formWindowService;

        private IServiceProvider _serviceProvider;

        private IManufacturer selectedManufacturer;
        private FuelType selectedFuelType;

        public MainViewModel(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
            _serviceProvider = (App.Current as App).ServiceProvider;
            _formWindowService = _serviceProvider.GetRequiredService<IFormWindowService>();
            Cars = new ObservableCollection<ICar>();
            Manufacturers = new ObservableCollection<IManufacturer>();
            LoadManufacturers();
            FuelTypes = new ObservableCollection<FuelType>(typeof(FuelType).GetEnumValues().Cast<FuelType>());
            PropertyChanged += MainViewModel_PropertyChanged;
            AddCarCommand = new DelegateCommand(AddCar);
            RemoveCarCommand = new DelegateCommand<int?>(RemoveCar);
            EditCarCommand = new DelegateCommand<int?>(EditCar);
            ClearFiltersCommand = new DelegateCommand(ClearFilters);
        }

        private void ClearFilters()
        {
            SelectedFuelType = 0;
            SelectedManufacturer = null;
        }

        private void LoadManufacturers()
        {
            var manufacturers = _dataLoader.GetManufacturers();
            Manufacturers.Clear();
            foreach (var manufacturer in manufacturers)
            {
                Manufacturers.Add(manufacturer);
            }
        }

        public ICommand EditCarCommand { get; set; }
        
        public ICommand AddCarCommand { get; set; }

        public ICommand RemoveCarCommand { get; set; }
        public ICommand ClearFiltersCommand { get; set; }


        public ObservableCollection<ICar> Cars { get; set; }
        public ObservableCollection<IManufacturer> Manufacturers { get; set; }
        public ObservableCollection<FuelType> FuelTypes { get; set; }

        public IManufacturer SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                OnPropertyChanged();
            }
        }


        public FuelType SelectedFuelType
        {
            get => selectedFuelType;
            set
            {
                selectedFuelType = value;
                OnPropertyChanged();
            }
        }

        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                OnPropertyChanged();
            }
        }
        private void RemoveCar(int? id)
        {
            if (id != null
                && MessageBox.Show(
                    messageBoxText: "Czy na pewno chcesz usunąć ten samochód?",
                    "Usuwanie elementu",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _dataLoader.RemoveCar((int)id);
                Load();
            }
        }

        private void EditCar(int? id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);

            if (car != null)
            {
                var carVm = new CarFormViewModel(car, _dataLoader.GetManufacturers());
                var wnd = _formWindowService.CreateWindow<CarFormView>(
                    $"Edycja samochodu {car.Brand} {car.Model}",
                    carVm,
                    () =>
                        {
                            _dataLoader.SaveCars(Cars);
                            Load();
                        },
                    carVm.CanSave);
                carVm.Window = wnd;
                wnd.Show();
            }
            
        }

        private void AddCar()
        {
            var carVm = new CarFormViewModel(new Car(), _dataLoader.GetManufacturers());
            var wnd = _formWindowService.CreateWindow<CarFormView>(
                "Dodaj samochód",
                carVm,
                () =>
                    {
                        _dataLoader.AddCar(carVm.Car.Car);
                        Load();
                    },
                carVm.CanSave);
            carVm.Window = wnd;
            wnd.Show();
        }

        private void MainViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FilterText) || e.PropertyName == nameof(SelectedFuelType) || e.PropertyName == nameof(SelectedManufacturer))
            {
                Load();
            }
        }

        public void Load()
        {
            var cars = _dataLoader.GetCars(FilterText, SelectedFuelType, SelectedManufacturer);
            Cars.Clear();
            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}