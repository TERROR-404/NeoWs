using NeoWs.Models;
using Newtonsoft.Json;
using System.Net.Http;
namespace NeoWs.Views;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
        BindingContext = new Models.AsteroidList();
    }
	private async void UpdateClicked(object sender, EventArgs e)
    {
        try
        {
            await ((Models.AsteroidList)BindingContext).LoadAsteroids();
            connection.Text = "API key is entered";
        }
        catch (Exception ex)
        {
            connection.Text = "Internet connection is not working or API key is not valid";
        }
    }
    private async void Asteroid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var current = (e.CurrentSelection.FirstOrDefault() as Asteroid);
        AsteroidPage.asterName = current.Name;
        AsteroidPage.asterDanger = current.IsDangerous;
        AsteroidPage.asterBody = current.OrbitingBody;
        AsteroidPage.asterRadius = current.EstimatedDiameter.Kilometers.Max.ToString();
        AsteroidPage.asterVelocity = current.RelativeVelocity;
        AsteroidPage.asterFirst = current.FirstAppearance;
        AsteroidPage.asterNext = current.NextApproach;
        AsteroidPage.asterFrequency = current.NextApproach.ToString();
        await Console.Out.WriteLineAsync(current.RelativeVelocity);
        await Console.Out.WriteLineAsync(AsteroidPage.asterVelocity);
        await Shell.Current.GoToAsync(nameof(AsteroidPage));
    }
}