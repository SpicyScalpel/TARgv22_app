using System;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Entry addressEntry;
        string[] lehed = new string[6] { "https://moodle.edu.ee", "https://www.tthk.ee/", "https://thk.edupage.org/timetable/view.php?fulscreen=1", "https://tahvel.edu.ee", "https://karinakulakova22.thkit.ee/wp/home/", "https://www.google.com/search?client=firefox-b-d&q=translate" };
        int currentNavigationIndex = 0;

        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Veebilehed"
            };
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Tunniplaan");
            picker.Items.Add("Tahvel");
            picker.Items.Add("Minu Wordpress");
            picker.Items.Add("Tõlkija");
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView { };
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;

            Frame frame = new Frame
            {
                BorderColor = Color.SkyBlue,
                BackgroundColor = Color.SeaShell,
            };
            frame.GestureRecognizers.Add(swipe);

            addressEntry = new Entry
            {
                Placeholder = "Sisesta URL",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            addressEntry.Completed += AddressEntry_Completed;

            Button kodulehtButton = new Button
            {
                Text = "Koduleht",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.LightBlue
            };
            kodulehtButton.Clicked += KodulehtButton_Clicked;

            Button tagasiButton = new Button
            {
                Text = "Tagasi",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.LightBlue
            };
            tagasiButton.Clicked += TagasiButton_Clicked;

            Button edasiButton = new Button
            {
                Text = "Edasi",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.LightBlue
            };
            edasiButton.Clicked += EdasiButton_Clicked;

            st = new StackLayout { Children = { picker, frame, addressEntry, kodulehtButton, tagasiButton, edasiButton } };
            Content = st;
        }

        private void AddressEntry_Completed(object sender, EventArgs e)
        {
            string enteredUrl = addressEntry.Text;
            Preferences.Set("link", enteredUrl);
            LoadUrl(enteredUrl);
            Console.WriteLine($"Entered URL: {enteredUrl}");
        }


        private void KodulehtButton_Clicked(object sender, EventArgs e)
        {
            LoadUrl(lehed[0]);
        }

        private void TagasiButton_Clicked(object sender, EventArgs e)
        {
            if (currentNavigationIndex > 0)
            {
                currentNavigationIndex--;
                string previousUrl = lehed[currentNavigationIndex];
                LoadUrl(previousUrl);
            }
            else
            {
                // Если находимся на первой странице, переходим на последнюю
                currentNavigationIndex = lehed.Length - 1;
                string lastUrl = lehed[currentNavigationIndex];
                LoadUrl(lastUrl);
            }
        }

        private void EdasiButton_Clicked(object sender, EventArgs e)
        {
            if (currentNavigationIndex < lehed.Length - 1)
            {
                currentNavigationIndex++;
                string forwardUrl = lehed[currentNavigationIndex];
                LoadUrl(forwardUrl);
            }
            else
            {
                // Если достигнута последняя ссылка, перейдите на первую
                currentNavigationIndex = 0;
                string firstUrl = lehed[currentNavigationIndex];
                LoadUrl(firstUrl);
            }
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            if (currentNavigationIndex > 0)
            {
                currentNavigationIndex--;
                string previousUrl = lehed[currentNavigationIndex];
                LoadUrl(previousUrl);
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);

            // Обновляем индекс навигации
            currentNavigationIndex = picker.SelectedIndex;
        }

        private void LoadUrl(string url)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }

            if (!url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                url = "https://" + url;
            }

            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = url },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            st.Children.Add(webView);

            Console.WriteLine($"Loading URL: {url}");
        }
    }
}
