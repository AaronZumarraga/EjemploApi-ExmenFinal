using Ejemplo.ViewModels;

namespace Ejemplo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

}

