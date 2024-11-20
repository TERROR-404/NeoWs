namespace NeoWs.Views;

public partial class AsteroidPage : ContentPage
{
	public static string asterName;
    public static string asterDanger;
    public static string asterBody;
    public static string asterVelocity;
    public static string asterRadius;
    public static string asterFirst;
    public static string asterNext;
    public static string asterFrequency;
    public AsteroidPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        AsterName.Text += asterName;
        AsterDanger.Text += asterDanger;
        AsterBody.Text += asterBody;
        AsterRadius.Text += asterRadius;
        AsterFirst.Text += asterFirst;
        AsterNext.Text += asterNext;
        AsterFrequency.Text += asterFrequency;
        AsterVelocity.Text += asterVelocity;
    }
}