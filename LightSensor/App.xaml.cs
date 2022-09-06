using Firebase.Database;

namespace LightSensor;

public partial class App : Application
{

	public static FirebaseClient firebasClient = new FirebaseClient("https://smartsensor-96350-default-rtdb.firebaseio.com/");

	public App()
	{
		InitializeComponent();
		Application.Current.UserAppTheme = AppTheme.Light;
		MainPage = new AppShell();
	}
}
