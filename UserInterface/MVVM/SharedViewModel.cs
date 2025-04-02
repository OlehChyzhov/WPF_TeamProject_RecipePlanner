// <copyright file="SharedViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    /// <summary>
    /// View model to share simular AccountViewModel.
    /// </summary>
    public class SharedViewModel : BaseViewModel
    {
        /// <summary>
        /// Shared AccountViewModel.
        /// </summary>
        private AccountViewModel accountVM = new AccountViewModel();

        /// <summary>
        /// Gets or sets AccountViewModel.
        /// </summary>
        public AccountViewModel AccountVM
        {
            get => this.accountVM;
            set
            {
                this.accountVM = value;
            }
        }
    }
}
