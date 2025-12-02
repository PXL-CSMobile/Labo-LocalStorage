using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PieShop.App.Models;
using PieShop.App.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.App.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public double Total => Math.Round(CartItems.Sum(i => i.Quantity * i.Price), 2);

        private readonly ICartRepository _repository;

        public ObservableCollection<CartItem> CartItems { get; set; } = new ObservableCollection<CartItem>();

        public CartViewModel(ICartRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        private async Task OnLoadData()
        {
            foreach(var item in await _repository.GetAllItemsAsync())
            {
                CartItems.Add(item);
            }

            OnPropertyChanged(nameof(Total));
        }
    }
}
