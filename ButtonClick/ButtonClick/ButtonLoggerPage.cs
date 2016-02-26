using System;

using Xamarin.Forms;

namespace ButtonClick
{
	public class ButtonLoggerPage : ContentPage
	{
		StackLayout loggerLayout = new StackLayout();

		public ButtonLoggerPage ()
		{

			Button button = new Button {

				Text = "Log the Click Time"
			};

			button.Clicked += OnButtonClicked;

			Content = new StackLayout {

				Children ={

					button,
					new ScrollView{

						VerticalOptions = LayoutOptions.StartAndExpand,
						Content = loggerLayout
					}
				}
			};

		}

		void OnButtonClicked(object sender, EventArgs args)
		{
			loggerLayout.Children.Add (new Label{

				Text = "Button clicked at " + DateTime.Now.ToString("T")
			});
				
		}
	}
}