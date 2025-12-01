using PieShop.App.ViewModels;

namespace PieShop.App.Views;

public partial class PieOverviewView : ContentPage
{
	public PieOverviewView(PieOverviewViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}