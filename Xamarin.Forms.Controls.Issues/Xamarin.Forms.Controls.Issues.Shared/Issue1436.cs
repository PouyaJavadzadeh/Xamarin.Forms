﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using System.Reflection;

#if UITEST
using Xamarin.Forms.Core.UITests;
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 9991436, "Button border not drawn on Android without a BorderRadius", PlatformAffected.Android)]
	public class Issue1436 : TestContentPage
	{
		protected override void Init()
		{
			var grid = new Grid
			{
				ColumnDefinitions = { new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } },
				RowDefinitions = { new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, new RowDefinition { Height = new GridLength(1, GridUnitType.Star) } }
			};

			grid.Children.Add(new Button
			{
				Text = "Button",
				HorizontalOptions = LayoutOptions.End,
				BorderColor = Color.AliceBlue,
				BorderWidth = 5
			}, 0, 0);

			grid.Children.Add(new Button
			{
				Text = "Button",
				HorizontalOptions = LayoutOptions.Start,
				BackgroundColor = Color.Gray
			}, 1, 1);

			grid.Children.Add(new Button
			{
				Text = "Button",
				HorizontalOptions = LayoutOptions.End,
			}, 0, 1);

			grid.Children.Add(new Button
			{
				Text = "Button",

				HorizontalOptions = LayoutOptions.Start,
			}, 1, 0);

			StackLayout stackLayout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label{ Text = "The following four buttons should all be the same size. One has a ridiculous border. One has a darker background. One is the default button." },
					grid,
					new Label{ Text = "The following three buttons should all have a red border." },
					new Button {
						Text = "BorderWidth = 1, BorderRadius = [default],",
						HorizontalOptions = LayoutOptions.Center,
						BorderColor = Color.Red,
						BorderWidth = 1,
					},
					new Button {
						Text = "BorderWidth = 1, BorderRadius = 0",
						HorizontalOptions = LayoutOptions.Center,
						BackgroundColor = Color.Blue,
						BorderColor = Color.Red,
						BorderWidth = 1,
						BorderRadius = 0,
						TextColor = Color.White
					},
					new Button {
						Text = "BorderWidth = 1, BorderRadius = 1",
						HorizontalOptions = LayoutOptions.Center,
						BackgroundColor = Color.Black,
						BorderColor = Color.Red,
						BorderWidth = 1,
						BorderRadius = 1,
						TextColor = Color.White
					}
				},
			};

			Content = stackLayout;
		}

#if UITEST
		[Test]
		[Category(UITestCategories.ManualReview)]
		public void Issue1Test()
		{
			RunningApp.Screenshot("I am at Issue 1436");
		}
#endif
	}
}