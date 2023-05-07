using System;
using System.Globalization;


namespace ANASAYFA
{
    public partial class kredi_faiz_oranı : ContentPage
    {
        private readonly CultureInfo culture = new CultureInfo("tr-TR");

        public kredi_faiz_oranı()
        {
            InitializeComponent();
        }

        public static (double, double) GetKkdfAndBsmv(string krediTuru)
        {
            double kkdfOrani = 0;
            double bsmvOrani = 0;

            if (krediTuru == "İhtiyaç Kredisi")
            {
                kkdfOrani = 0.15;
                bsmvOrani = 0.1;
            }
            else if (krediTuru == "Konut Kredisi")
            {
                kkdfOrani = 0;
                bsmvOrani = 0;
            }
            else if (krediTuru == "Taşıt Kredisi" || krediTuru == "Ticari Kredi")
            {
                kkdfOrani = 0.15;
                bsmvOrani = 0.05;
            }
            else
            {
                throw new ArgumentException("Geçersiz kredi türü.");
            }

            return (kkdfOrani, bsmvOrani);
        }

        private void OnHesaplaClicked(object sender, EventArgs e)
        {
            var krediTuru = "";
            if (krediTuruPicker.SelectedItem != null)
            {
                krediTuru = krediTuruPicker.SelectedItem.ToString();
            }
            var tutar = 0.0;
            var faizOrani = 0.0;
            var vade = 0;

            if (double.TryParse(tutarEntry.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out tutar) && double.TryParse(faizEntry.Text, out faizOrani) && int.TryParse(vadeEntry.Text, out vade))
            {
                var (taksit, toplam, toplamFaiz) = Hesapla(krediTuru, tutar, faizOrani, vade);
                taksitLabel.Text = taksit.ToString("C2");
                toplamLabel.Text = toplam.ToString("C2");
                faizLabel.Text = toplamFaiz.ToString("C2");
            }
            else
            {
                DisplayAlert("Hata", "Lütfen geçerli bir tutar, faiz oranı ve vade girin.", "Tamam");
            }
        }

        public static (double, double, double) Hesapla(string krediTuru, double tutar, double faizOrani, int vade)
        {
            var (kkdfOrani, bsmvOrani) = GetKkdfAndBsmv(krediTuru);

            // Brüt faiz oranını hesapla
            var brutFaiz = ((faizOrani + (faizOrani * bsmvOrani) + (faizOrani * kkdfOrani)) / 100);

            // Aylık taksit tutarını hesapla
            var taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;

            // Toplam ödeme tutarını hesapla
            var toplam = taksit * vade;

            // Toplam faiz tutarını hesapla
            var toplamFaiz = toplam - tutar;

            // Sonuçları tuple olarak döndür
            return (taksit, toplam, toplamFaiz);
        }
    }
}

