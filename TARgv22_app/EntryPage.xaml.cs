﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Label label;
        public EntryPage()
        {
            Editor editor = new Editor()
            {
                Placeholder="Sisesta siia tekst",
                BackgroundColor=Color.White,
                TextColor=Color.Black,
            };

            editor.TextChanged += Editor_TextChanged;

            label = new Label
            {
                Text="Pealkiri",
                HorizontalOptions= LayoutOptions.Start,
                VerticalOptions= LayoutOptions.Center,
                TextColor = Color.DarkBlue,
                BackgroundColor=Color.AntiqueWhite
            };

            Button b = new Button()
            {
                Text="To start page",
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center,
            };

            b.Clicked += B_Clicked;

            StackLayout st= new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = { label, editor, b},
                BackgroundColor= Color.BurlyWood
            };

            Content= st;
        }

        int i=0; 
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            char key = e.NewTextValue?.LastOrDefault() ?? ' '; //?
            if (key == 'A')
            {
                i++;
                label.Text=key.ToString() + ": "+i.ToString();
            }
        }

        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}