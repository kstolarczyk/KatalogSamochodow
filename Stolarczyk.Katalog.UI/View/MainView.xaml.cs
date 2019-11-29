﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stolarczyk.Katalog.UI.View
{
    using Stolarczyk.Katalog.UI.ViewModel;

    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {

        public MainView()
        {
            InitializeComponent();
            Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.Load();
            }
        }
    }
}
