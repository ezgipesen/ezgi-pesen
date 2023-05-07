using Anasayfa;
using System.ComponentModel;

namespace ANASAYFA;

public partial class MENÜ : FlyoutPage
{
	public MENÜ()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        Detail = new MainPage();
    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Detail = new VücutKitle();
    }
    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Detail = new kredi_faiz_oranı();
    }
    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Detail = new renkSeçici();
    }
    private void Button_Clicked_4(object sender, EventArgs e)
    {
        Detail = new yapılacaklar();
    }
}