using NeoWs.Models;

namespace NeoWs.Views;

public partial class KeyPage : ContentPage
{
	public KeyPage()
	{
		InitializeComponent();
	}
	public void Save_Clicked(object sender, EventArgs e)
	{
		AsteroidList.ApiKey = apiKeyInput.Text;
    }
}