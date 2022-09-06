using LightSensor.Helpers;
using LightSensor.Models;

namespace LightSensor.Views;

public partial class DashboardDetails : ContentPage
{
    FirebaseHelper firebaseHelper = new FirebaseHelper();
	bool IsManual = false;
	Esp context=new Esp();
    public DashboardDetails()
	{
		InitializeComponent();

	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		context = (Esp)BindingContext;
		IsManual = context.Manual=="1";
        LightSwitch.IsEnabled = IsManual;
    }

	private async void Switch_Toggled(object sender, ToggledEventArgs e)
	{
		var manualMode = e.Value;
		IsManual = manualMode;
		LightSwitch.IsEnabled = IsManual;
		context.Manual = manualMode==true?1.ToString():0.ToString();
		await firebaseHelper.SwitchToManual("1",context);
	}

	private async void Switch_Toggled_1(object sender, ToggledEventArgs e)
	{
        var manualMode = e.Value;
        context.HasLight = manualMode == true ? 1.ToString() : 0.ToString();
        var manualLight = e.Value.ToString();
		await firebaseHelper.ManualSwitchLight("1", context);
	}
}