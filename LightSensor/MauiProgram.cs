namespace LightSensor;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Courier.ttf","Courier");
				fonts.AddFont("Latinotype-IgnaSansBold.otf","IgnaSansBold");
                fonts.AddFont("Latinotype-IgnaSansMedium.otf", "IgnaSansMedium");
                fonts.AddFont("Latinotype-IgnaSansRegular.otf", "IgnaSansRegular");
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                fonts.AddFont("Roboto-Italic.ttf", "RobotoItalic");
                fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
            });

		return builder.Build();
	}
}
