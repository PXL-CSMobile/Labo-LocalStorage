using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PieShop.App.Message;
using PieShop.App.Models;
using PieShop.App.Services;

namespace PieShop.App.ViewModels
{
    [QueryProperty(nameof(SelectedPie),"selectedPie")]
    public partial class PieDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private Pie selectedPie = new Pie();

        private IPieRepository _repository;
        private readonly INavigationService _navigation;
        private readonly IMessenger _messenger;

        // public ICommand SaveCommand { get; }

        public PieDetailViewModel(IPieRepository pieRepository, INavigationService navigation, IMessenger messenger) 
        {
            _repository = pieRepository;
            _navigation = navigation;
            _messenger = messenger;
        }

        [RelayCommand]
        private async Task OnSave()
        {
            if (SelectedPie.Id == Guid.Empty)
            {
                await _repository.AddPie(SelectedPie);
                _messenger.Send(new PieCreatedMessage(SelectedPie));
            }
            else
            {
                await _repository.UpdatePie(SelectedPie);
                _messenger.Send(new PieUpdatedMessage(SelectedPie));
            }

            await _navigation.GoBackAsync();
        }
    }
}
