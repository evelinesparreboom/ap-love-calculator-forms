using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lamp.Plugin;
using Plugin.Contacts;
using Plugin.Contacts.Abstractions;
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
                this.loveResultLabel.Text = "Your love is incalculable";
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
	        for (int i = 0; i < 30; i++)
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
	    }

        async void BtnGetFromContacts_OnClicked(object sender, EventArgs e)
	    {
            if (await CrossContacts.Current.RequestPermission())
	        {

	            List<Contact> contacts = null;
	            CrossContacts.Current.PreferContactAggregation = false;//recommended
	            //run in background
	            await Task.Run(() =>
	            {
	                if (CrossContacts.Current.Contacts == null)
	                    return;

	                contacts = CrossContacts.Current.Contacts.ToList();



	            });

	            if (contacts != null)
	            {
	                contactPicker.ItemsSource = contacts
	                    .Select(contact => $"{contact.FirstName} {contact.LastName}")
	                    .ToList();
	                contactPicker.IsVisible = true;
	                contactPicker.Focus();
	            }
	        }
        }

	    async void Person1Focussed(object sender, FocusEventArgs e)
	    {
            btnGetFromContacts.IsVisible = true;
            await btnGetFromContacts.FadeTo(1, 100);
	    }

	    void ContactPicker_OnSelectedIndexChanged(object sender, EventArgs e)
	    {
	        person1nameText.Text = contactPicker.SelectedItem.ToString();
	    }

	    private void ContactPicker_OnUnfocused(object sender, FocusEventArgs e)
	    {
	        contactPicker.IsVisible = false;
	    }
	}
}
