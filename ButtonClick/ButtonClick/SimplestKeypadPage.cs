﻿using System;

using Xamarin.Forms;

namespace ButtonClick
{
	public class SimplestKeypadPage : ContentPage
	{
		Label displayLabel;
		Button backspaceButton;

		public SimplestKeypadPage ()
		{

			StackLayout mainStack = new StackLayout {

				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			displayLabel = new Label {

				FontSize = Device.GetNamedSize(NamedSize.Large , typeof(Label)),
				VerticalOptions = LayoutOptions.Center,
				XAlign = TextAlignment.End
			};
					
			mainStack.Children.Add (displayLabel);

			backspaceButton = new Button {

				Text = "\u21E6",
				FontSize = Device.GetNamedSize(NamedSize.Large ,typeof(Label)),
				IsEnabled = true
			};

			backspaceButton.Clicked += OnBackspaceButtonClicked;
			mainStack.Children.Add (backspaceButton);


			StackLayout rowStack = null;

			for (int num = 1; num <= 10 ; num +=1)
			{
				if ((num - 1) % 3 == 0) {

					rowStack = new StackLayout {

						Orientation = StackOrientation.Horizontal
					};

					mainStack.Children.Add (rowStack);
				}

				Button digitButton = new Button {

					Text = (num % 10).ToString(),
					FontSize = Device.GetNamedSize(NamedSize.Large ,typeof(Button)),
					StyleId = (num % 10).ToString()
				};

				digitButton.Clicked += onDigitButtonClicked;

				if (num == 10) {

					digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
				}

				rowStack.Children.Add (digitButton);
			}

			this.Content = mainStack;

			// New code for loading previous keypad text.

			App app = Application.Current as App;
			displayLabel.Text = app.DisplayLabelText;
			backspaceButton.IsEnabled = displayLabel.Text != null && displayLabel.Text.Length > 0;
		}

		void OnBackspaceButtonClicked(object sender , EventArgs args)
		{
			string text = displayLabel.Text;
			displayLabel.Text = text.Substring(0, text.Length - 1);
			backspaceButton.IsEnabled = displayLabel.Text.Length > 0;

			App app = Application.Current as App;
			app.DisplayLabelText = displayLabel.Text;
		}

		void onDigitButtonClicked(object sender , EventArgs args)
		{
			Button button = (Button)sender;
			displayLabel.Text += (string)button.StyleId;
			backspaceButton.IsEnabled = true;

			App app = Application.Current as App;
			app.DisplayLabelText = displayLabel.Text;
		}
	}
}
	