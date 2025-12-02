using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
        private readonly ICartRepository _cartRepository;
        private readonly INavigationService _navigation;

        public PieOverviewViewModel(IPieRepository pieRepository, ICartRepository cartRepository, INavigationService navigation, IMessenger messenger) 
        {
            _repository = pieRepository;
            _cartRepository = cartRepository;
            _navigation = navigation;
            
            messenger.Register<PieCreatedMessage>(this);
            messenger.Register<PieUpdatedMessage>(this);
        }

        [RelayCommand]
        private async Task OnAddPieToCart(Pie pie)
        {
            //TODO:
            //Add Pie to CartRepository
            await _cartRepository.AddToCartAsync(pie);
            //Show Snackbar
            ShowSnackbar(pie);
        }

        private async Task ShowSnackbar(Pie pie)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            App.Current.Resources.TryGetValue("BethanysGreenColor", out var background);

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = (Color)(background ?? Colors.Blue),
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.Gray,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14),
                ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14),
                //CharacterSpacing = 0.5
            };

            string text = $"{pie.PieName} werd toegevoegd";
            string actionButtonText = "Toon winkelwagen";
            Action action = async () => await GotoCart();
            TimeSpan duration = TimeSpan.FromSeconds(5);

            var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
        }

        [RelayCommand]
        private async Task GotoCart()
        {
            await _navigation.GoToAsync("CartView");
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
