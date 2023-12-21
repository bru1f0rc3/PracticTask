using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    public partial class MainPage : ContentPage
    {
        public Entry CXX, CYY;
        public Label Answer;
        public MainPage()
        {
            Grid grid = new Grid()
            {
                RowSpacing = 5,
                RowDefinitions =
                {
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 200 },
                    new RowDefinition { Height = 43 },
                    new RowDefinition { Height = 43 },
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = 50 }
                },
                ColumnDefinitions =
                {
                   new ColumnDefinition {Width = 100},
                   new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) },
                }
            };
            Label title = new Label()
            {
                Text = "Домашние задание",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                Margin = 5,
                HorizontalOptions = LayoutOptions.Center
            };
            Label CX = new Label()
            {
                Text = "Коорд. X:",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            Label CY = new Label()
            {
                Text = "Коорд. Y:",
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                Margin = 10
            };
            Answer = new Label()
            {
                Text = "Ответ: ",
                FontSize = 15,
                Margin = 10
            };

            grid.Children.Add(title, 0, 0);
            Grid.SetColumnSpan(title, 2);

            grid.Children.Add(CX, 0, 3);
            grid.Children.Add(CY, 0, 4);

            grid.Children.Add(Answer, 0, 5);
            Grid.SetColumnSpan(Answer, 2);

            CXX = new Entry();
            CYY = new Entry();
            grid.Children.Add(CXX, 1, 3);
            grid.Children.Add(CYY, 1, 4);

            StackLayout stack = new StackLayout();
            stack.Orientation = StackOrientation.Horizontal;
            stack.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Button OK_Button = new Button()
            {
                Text = "OK",
            };
            OK_Button.Clicked += OK_Button_Clicked;

            Button Cancel_Button = new Button()
            {
                Text = "Cancel",
            };
            Cancel_Button.Clicked += Cancel_Button_Clicked;

            Image ImageBox = new Image();
            ImageBox.Source = ImageSource.FromFile("smile3.png");

            grid.Children.Add(ImageBox, 0, 1);
            Grid.SetColumnSpan(ImageBox, 2);
            stack.Children.Add(OK_Button);
            stack.Children.Add(Cancel_Button);
            grid.Children.Add(stack, 0, 6);
            Grid.SetColumnSpan(stack, 2);

            Content = grid;
        }

        private void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void OK_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                double x = double.Parse(CXX.Text);
                double y = double.Parse(CYY.Text);
                if (x > -23 && x < 0 && y > x && y < 0)
                {
                    Answer.Text = "Ответ: Вы в области D";
                }
                else
                {
                    Answer.Text = "Ответ: Вы не в области D";
                }
            }
            catch 
            {
                await DisplayAlert("Ошибка", "Вы должны ввести число", "OK");
            }
        }
    }
}
