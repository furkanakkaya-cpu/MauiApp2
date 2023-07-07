using MauiApp2.Models;

namespace MauiApp2.Views;

public partial class HaberlerDetay : ContentPage
{
    public partial class HaberDetay : ContentPage
    {
        public HaberDetay(Item haber)
        {
            //InitializeComponent();
            BindingContext = haber;
        }

        private void DevaminiOkuButton_Clicked(object sender, EventArgs e)
        {
            // Ýlgili haberin tamamýný okuma iþlemi yapýlabilir
        }
    }
}