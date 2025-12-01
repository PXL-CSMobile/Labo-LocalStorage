using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PieShop.App.Message;
using PieShop.App.Models;
using PieShop.App.Services;
using System.Collections.ObjectModel;


namespace PieShop.App.ViewModels
{
    public partial class PieOverviewViewModel : ObservableObject, 
        IRecipient<PieCreatedMessage>, IRecipient<PieUpdatedMessage>
    {
        public ObservableCollection<Pie> Pies { get; private set; } = new ObservableCollection<Pie>();

        private IPieRepository _repository;
        private readonly INavigationService _navigation;

        public PieOverviewViewModel(IPieRepository pieRepository, INavigationService navigation, IMessenger messenger) 
        {
            _repository = pieRepository;
            _navigation = navigation;
            
            messenger.Register<PieCreatedMessage>(this);
            messenger.Register<PieUpdatedMessage>(this);
        }

        [RelayCommand]
        private void OnAddPieToCart(Pie pie)
        {
            //TODO:
            //Add Pie to CartRepository
            //Show Toast
        }

        [RelayCommand]
        private async Task OnPieSelected(Pie pie)
        {
            await _navigation.GoToAsync("PieDetailView", new Dictionary<string, object> { { "selectedPie", pie } });
        }

        [RelayCommand]
        public async Task OnLoad()
        {
            try
            {
                this.Pies.Clear();
                foreach (Pie pie in await _repository.GetAllPies())
                {
                    this.Pies.Add(pie);
                }
            }
            catch (Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
        }

        [RelayCommand]
        public async Task OnAdd()
        {
            await _navigation.GoToAsync("PieDetailView");
        }

        public void Receive(PieCreatedMessage message)
        {
            this.Pies.Add(message.Value);
        }

        public void Receive(PieUpdatedMessage message)
        {
            var updatedPie = message.Value;
            var existingPie = this.Pies.FirstOrDefault(p => p.Id == updatedPie.Id);

            if (existingPie is null)
                return;

            this.Pies[this.Pies.IndexOf(existingPie)] = updatedPie;
        }
    }
}
