using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace forms_ap_love_calculator
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void OnCalculate(object sender, EventArgs e)
		{
			var loveResult = Core.ApLove.ToNumber(person1nameText.Text, person2nameText.Text);
			if (loveResult == "infinity")
			{
				loveResultLabel.Text = "Your love is incalculable";
			}
			else
			{
				loveResultLabel.Text = loveResult + "%";
			}
		}

	}
}
