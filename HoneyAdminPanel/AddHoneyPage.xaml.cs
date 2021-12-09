using Enums;
using HoneyDataBace.Models;
using HoneyDataBace.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

namespace HoneyAdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AddHoneyPage.xaml
    /// </summary>
    public partial class AddHoneyPage : Page
    {

        private const string IMAGE_FOLDER_PATH = "C:\\Users\\malyn\\OneDrive\\Рабочий стол\\HoneyApp\\Images";
        private readonly IProviderService _providerService;
        private readonly IHoneyService _honeyService;
        private readonly NavigationWindow _correct;
        private Honey _honey;
        private string _fullImage;
        public AddHoneyPage(IProviderService providerService, IHoneyService honeyService, NavigationWindow navigationWindow)
        {
            InitializeComponent();
            _correct = navigationWindow;
            _providerService = providerService;
            _honeyService = honeyService;
          
            HoneyKinds.ItemsSource = Enum.GetValues(typeof(HoneyKind)).Cast<HoneyKind>();
            HoneyKinds.SelectionChanged += HoneyKinds_SelectionChanged;

            Providers.ItemsSource = _providerService.GetAll().ToList();
            Providers.DisplayMemberPath = nameof(Provider.Name);
            Providers.SelectionChanged += Providers_SelectionChanged;

        
           _honey = new Honey();
        }

        private void Providers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            _honey.ProviderId = (comboBox.SelectedItem as Provider).Id;
        }

        private void HoneyKinds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
           _honey.Kind  = (HoneyKind)comboBox.SelectedItem;           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                honeyImage.Source = bitmap;
                _fullImage = selectedFileName;
                using (Bitmap _fullIcon = (Bitmap)System.Drawing.Image.FromFile(selectedFileName))
                {
                    using (Bitmap newBitmap = new Bitmap(_fullIcon, new System.Drawing.Size(300, 300)))
                    {
                        _honey.Icon = ImageToByte(newBitmap);

                    }
                }
            }
        }
        public static byte[] ImageToByte(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _honey.Name = name.Text;
            _honey.Amount = float.Parse(almount.Text);
            _honey.Price = int.Parse(price.Text);
            _honey.Description = description.Text;
           
            _honeyService.CreateNewWare(_honey);
            var newPath = Directory.GetCurrentDirectory() + "\\Images\\" + _honey.Id + ".jpg";
            File.Copy(_fullImage, newPath);
            _honey.ImagePath = newPath;
            _honeyService.Update(_honey);
          
            _correct.Close();
        }
    }
}
