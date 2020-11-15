using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoLibrary;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int maxNumber = 0;
        private int currentNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            nextImageButton.IsEnabled = false;
        }

        private async Task loadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LaodComic(imageNumber);

            if (imageNumber == 0)
            {
                maxNumber = comic.Num;
            }

            currentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await loadImage();
        }

        private async void PreviousImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (currentNumber > 1)
            {
                currentNumber -= 1;
                nextImageButton.IsEnabled = true;
                await loadImage(currentNumber);

                if (currentNumber == 1)
                {
                    previousImageButton.IsEnabled = false;
                }
            }
        }

        private async void NextImageButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (currentNumber < maxNumber)
            {
                currentNumber += 1;
                previousImageButton.IsEnabled = true;
                await loadImage(currentNumber);

                if (currentNumber == maxNumber)
                {
                    nextImageButton.IsEnabled = false;
                }
            }
        }
    }
}
