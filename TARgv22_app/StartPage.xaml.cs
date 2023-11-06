using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Ent_btn = new Button
            {
                Text= "Entry page",
                BackgroundColor= Color.LightSkyBlue,
            };

            Button Time_btn = new Button
            {
                Text = "Timer page",
                BackgroundColor = Color.LightSkyBlue,
            };

            StackLayout st= new StackLayout 
            { 
               Children= {Ent_btn, Time_btn}, //vse elementi, kotorije hotim videtj na stranice
               BackgroundColor= Color.DarkBlue,
            };

            Content= st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}