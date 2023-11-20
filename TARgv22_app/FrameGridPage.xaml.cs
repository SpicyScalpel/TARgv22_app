using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrameGridPage : ContentPage
    {
        Frame frame;
        Grid grid;
        Random rnd;
        Label label;
        Button button;
        Color currentColor;

        public FrameGridPage()
        {
            rnd = new Random();
            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Blue,
            };
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    button = new Button
                    {
                        Text = i.ToString() + j.ToString(),
                        CornerRadius = 10,
                        BackgroundColor = GetRandomColor(),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };

                    button.Clicked += Button_Clicked;

                    grid.Children.Add(button, j, i);
                }
            }

            label = new Label { Text = "Tekst" };

            grid.Children.Add(label, 0, 3);
            Grid.SetColumnSpan(label, 2);

            Content = grid;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.BackgroundColor == Color.Red)
            {
                // Если цвет красный, установите случайный цвет
                button.BackgroundColor = GetRandomColor();
            }
            else
            {
                // Иначе установите цвет красный
                button.BackgroundColor = Color.Red;
            }

            label.Text = button.Text;
        }

        private Color GetRandomColor()
        {
            return Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}
