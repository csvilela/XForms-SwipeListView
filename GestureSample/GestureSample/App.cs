﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GestureSample.Views;

using Xamarin.Forms;

namespace GestureSample
{
	public class App : Application
	{
		public static NavigationPage MainNavigation;

		public App()
		{
			var mainPage = new MainPage();
			MainPage = MainNavigation = new NavigationPage(mainPage);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
