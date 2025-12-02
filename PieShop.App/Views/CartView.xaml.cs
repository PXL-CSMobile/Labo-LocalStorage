using PieShop.App.ViewModels;

namespace PieShop.App.Views;

public partial class CartView : ContentPage
{
	public CartView(CartViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}