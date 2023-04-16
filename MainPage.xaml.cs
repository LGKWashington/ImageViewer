using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace ImageViewer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            List<NavigationViewItemBase> _Navs = new List<NavigationViewItemBase>();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
                {
                    IRandomAccessStream ir = await file.OpenAsync(FileAccessMode.Read);
                    BitmapImage bi = new BitmapImage();
                    await bi.SetSourceAsync(ir);
                    IMG.Source = bi;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NB.Value *= 1.1;
            NB.Value = (int)NB.Value;
            IMG.Width = 600;
            IMG.Height /= (IMG.Width / 600);
            IMG.Width *= (double)(NB.Value / 100);
            IMG.Height *= (double)(NB.Value / 100);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NB.Value /= 1.1;
            NB.Value = (int)NB.Value;
            IMG.Width = 600;
            IMG.Height /= (IMG.Width / 600);
            IMG.Width *= (double)(NB.Value / 100);
            IMG.Height *= (double)(NB.Value / 100);
        }
        double imagesiz(double x)
        {
            IMG.Width = 600;
            IMG.Height /= (IMG.Width / 600);
            IMG.Height *= (double)(NB.Value / 100);
            return (double)(NB.Value / 100) * 600;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NB.Value = 100;
        }
    }
}
