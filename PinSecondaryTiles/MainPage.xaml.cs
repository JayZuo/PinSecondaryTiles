using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PinSecondaryTiles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Parameter.ToString()))
            {
                Message.Text = e.Parameter.ToString();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri Squarelogo = new Uri("ms-appx:///TileImages/150x150.png");
            Uri Widelogo = new Uri("ms-appx:///TileImages/310x150.png");
            Uri smalllogo = new Uri("ms-appx:///TileImages/30x30.png");

            var tileActivationArguments = "MySecondaryTile Was Pinned At " + DateTime.Now.ToLocalTime().ToString();

            SecondaryTile secondaryTile = new SecondaryTile("MySecondaryTile", "Secondary Tile Test", tileActivationArguments, Squarelogo, TileSize.Square150x150);

            secondaryTile.VisualElements.ForegroundText = ForegroundText.Light;
            secondaryTile.VisualElements.Wide310x150Logo = Widelogo;
            secondaryTile.VisualElements.Square310x310Logo = Squarelogo;
            secondaryTile.VisualElements.Square30x30Logo = smalllogo;
            secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            secondaryTile.VisualElements.ShowNameOnWide310x150Logo = true;

            await secondaryTile.RequestCreateAsync();

            Message.Text = "SecondaryTile Was Pinned!";
        }
    }
}