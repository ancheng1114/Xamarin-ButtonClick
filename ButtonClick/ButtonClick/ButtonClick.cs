using System;

using Xamarin.Forms;

namespace ButtonClick
{
	public class App : Application
	{
		const string displayLabelText = "displayLabelText";
		public string DisplayLabelText { set; get; }

		public App ()
		{
			// The root page of your application
//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms!"
//						}
//					}
//				}
//			};

			if (Properties.ContainsKey (displayLabelText)) {

				DisplayLabelText = (string)Properties [displayLabelText];
			}

			MainPage = new SimplestKeypadPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps

			Properties [displayLabelText] = DisplayLabelText;
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
