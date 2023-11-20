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
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new EntryPage(), new BoxView_Page(), new TimerPage(), new DateTimePage(), new StepperSliderPage(), new FrameGridPage(), new ImagePage() };
        List<string> teksts = new List<string> { "Ava Entry leht", "Ava BoxView leht", "Ava Timer leht", "Ava DateTime leht", "Ava Stepper", "Ava Grid leht", "Ava Image leht" };
        StackLayout st;
        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Green,
            };
            for (int i = 0; i< pages.Count; i++) 
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.Red,
                    TextColor = Color.Green,
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn= (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}