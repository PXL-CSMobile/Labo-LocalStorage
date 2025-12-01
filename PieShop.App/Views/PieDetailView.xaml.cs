using PieShop.App.ViewModels;

namespace PieShop.App.Views;

public partial class PieDetailView : ContentPage
{
	public PieDetailView(PieDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}