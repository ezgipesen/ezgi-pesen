using System.ComponentModel;

namespace Anasayfa
{
    public partial class renkSe�ici : ContentPage
    {
        public renkSe�ici()
        {
            InitializeComponent();
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            // Rastgele bir renk olu�tur
            Random random = new Random();
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));

            // Arka plan rengini de�i�tir
            this.BackgroundColor = randomColor;
        }
    }
}