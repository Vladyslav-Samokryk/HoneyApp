using HoneyDataBace.Services.Interfaces;
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

namespace HoneyAdminPanel
{
    /// <summary>
    /// Логика взаимодействия для AddProviderPage.xaml
    /// </summary>
    public partial class AddProviderPage : Page
    {
        private readonly IProviderService _providerService;
        private readonly NavigationWindow _correct;
        public AddProviderPage(IProviderService providerService, NavigationWindow navigationWindow)
        {
            InitializeComponent();
            _providerService = providerService;
            _correct = navigationWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _providerService.AddProvider(new HoneyDataBace.Models.Provider() { Name = nameOfProvider.Text });
            NavigationService.Navigate(null);
            _correct.Close();
        }
    }
}
