﻿namespace Stolarczyk.Katalog.UI.Services
{
    using System;
    using System.Windows.Controls;

    using Stolarczyk.Katalog.UI.ViewModel;

    public interface IFormWindowService
    {
        FormWindow CreateWindow<TView>(string title, object viewModel, Action save, Func<bool> canSave) where TView : UserControl, new();
    }
}