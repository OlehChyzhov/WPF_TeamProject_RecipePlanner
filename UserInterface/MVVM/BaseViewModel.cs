// <copyright file="BaseViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    using System.ComponentModel;

    /// <summary>
    /// Base ViewModel class for all the other ones.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that tells binded objects to update their data.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Method to fire PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Name of the property changed.</param>
        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
