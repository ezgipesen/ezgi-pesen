using System.ComponentModel;

namespace Anasayfa
{
    public partial class renkSeçici : ContentPage
    {
        public renkSeçici()
        {
            InitializeComponent();
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            // Rastgele bir renk oluþtur
            Random random = new Random();
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));

            // Arka plan rengini deðiþtir
            this.BackgroundColor = randomColor;
        }
    }
}