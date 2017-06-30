using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var file1 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Images/IMG_3163.JPG"));
            var file2 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Images/IMG_3163.CR2"));
            await GetExifValues(file1);
            await GetExifValues(file2);
        }

        public async Task GetExifValues(StorageFile file_)
        {
            ImageProperties props = await file_.Properties.GetImagePropertiesAsync();
            var requests = new System.Collections.Generic.List<string>();
            requests.Add("System.Photo.DateTaken");
            requests.Add("System.Photo.FNumber");
            requests.Add("System.Photo.ExposureTimeNumerator");
            requests.Add("System.Photo.ExposureTimeDenominator");
            requests.Add("System.Photo.ISOSpeed");
            requests.Add("System.Photo.Orientation");

            IDictionary<string, object> retrievedProps = await props.RetrievePropertiesAsync(requests);

            Debug.WriteLine("Parsing Exif from: " + file_.Path.ToString());

            if (retrievedProps.ContainsKey("System.Photo.DateTaken")) Debug.WriteLine("Exif_DateTaken: " + (DateTimeOffset)retrievedProps["System.Photo.DateTaken"]);
            if (retrievedProps.ContainsKey("System.Photo.FNumber")) Debug.WriteLine("Exif_FNumber: " + (double)retrievedProps["System.Photo.FNumber"]);
            if (retrievedProps.ContainsKey("System.Photo.ExposureTimeNumerator")) Debug.WriteLine("Exif_ExposureTimeNumerator: " + (uint)retrievedProps["System.Photo.ExposureTimeNumerator"]);
            if (retrievedProps.ContainsKey("System.Photo.ExposureTimeDenominator")) Debug.WriteLine("Exif_ExposureTimeDenominator: " + (uint)retrievedProps["System.Photo.ExposureTimeDenominator"]);
            if (retrievedProps.ContainsKey("System.Photo.ISOSpeed")) Debug.WriteLine("Exif_ISOSpeed: " + (ushort)retrievedProps["System.Photo.ISOSpeed"]);
            if (retrievedProps.ContainsKey("System.Photo.Orientation")) Debug.WriteLine("Exif_Orientation: " + (ushort)retrievedProps["System.Photo.Orientation"]);

            Debug.WriteLine("_______________________________");
        }
    }
}
