using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lamp.Plugin;
using Xamarin.Forms;

namespace forms_ap_love_calculator
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async void OnCalculate(object sender, EventArgs e)
		{
			var loveResult = Core.ApLove.ToNumber(person1nameText.Text, person2nameText.Text);
			if (loveResult == "infinity")
			{
				loveResultLabel.Text = "Your love is incalculable";
			}
	        else
	        {
	            loveResultLabel.Text = loveResult + "%";
	            int loveResultPercentage = 0;
	            if (int.TryParse(loveResult, out loveResultPercentage) && loveResultPercentage > 50)
	            {
	                await Blink();
	            }
	        }
	    }


	    async Task Blink()
	    {
	        for (int i = 0; i < 25; i++)
	        {
	            if (i % 2 == 0)
	            {
	                CrossLamp.Current.TurnOn();
	            }
	            else
	            {
	                CrossLamp.Current.TurnOff();
	            }
	            await Task.Delay(700);
	        }
            CrossLamp.Current.TurnOff();
	    }

    }
}
