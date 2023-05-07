namespace ANASAYFA;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MENÜ(); //new AppShell();
	}
}
