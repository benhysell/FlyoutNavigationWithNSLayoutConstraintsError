using FlyoutNavigation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample
{
    public class MyViewController : UIViewController
    {
        UIButton button;
        int numClicks = 0;
        float buttonWidth = 200;
        float buttonHeight = 50;

        public MyViewController()
        {
        }

        public MyViewController(FlyoutNavigationController navigation)
            : base()
		{
			//this.weightRepository = weightRepository;
			//TODO change this icon to something different, lines in a box for all view controllers

			this.NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action , delegate
			{
				navigation.ToggleMenu();
			});
			//InitializeView ();    

		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.Red;
            button = UIButton.FromType(UIButtonType.RoundedRect);
            
            button.SetTitle("Click me", UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) =>
            {
                button.SetTitle(String.Format("clicked {0} times", numClicks++), UIControlState.Normal);
            };
            
            View.AddSubview(button);
            const int ButtonWidth = 75;
            const int HPadding = 22;
            const int VPadding = 44;
            View.ConstrainLayout(() =>
                                  button.Frame.Width == ButtonWidth &&
                button.Frame.Left == View.Frame.Left + HPadding &&
                button.Frame.Top == View.Frame.Top + VPadding);
        }

    }
}
