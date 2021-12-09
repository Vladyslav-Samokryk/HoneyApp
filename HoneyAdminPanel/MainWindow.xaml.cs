
using HoneyDataBace;
using HoneyDataBace.Services;
using HoneyDataBace.Services.Interfaces;
using System.Diagnostics;
using System.Linq;
using System.Windows;

using System.Windows.Input;
using System.Windows.Navigation;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace HoneyAdminPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly HoneyDbContext _honeyDbContext;
        private readonly IProviderService _providerService;
        private readonly IHoneyService _honeyService;
       
        public MainWindow()
        {
            InitializeComponent();
            _honeyDbContext =  ((App)Application.Current).HoneyDbContext;
            _providerService = new ProviderService(_honeyDbContext);
            _honeyService = new HoneyService(_honeyDbContext);
        
            honeys.ItemsSource = _honeyService.GetAll().ToList();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

           // honeys.SelectedItem as Honey
            


        }
        private void AddHoney_Click(object sender, RoutedEventArgs e)
        {
            var navW = new NavigationWindow()
            {
                ShowsNavigationUI = false
            };
            var page = new AddHoneyPage(_providerService, _honeyService, navW);
            navW.Content = page;
            navW.Show();
           
        }

        private void AddPrivider_Click(object sender, RoutedEventArgs e)
        {
            var navW = new NavigationWindow()
            {
                Height = 400,
                Width = 500,
                ShowsNavigationUI = false
            };
            var page = new AddProviderPage(_providerService, navW);
            navW.Content = page;
            navW.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = @"C:\Users\malyn\OneDrive\Рабочий стол\Наказ.docx";
            var d = DocX.Load(fileName);
            d.Tables.First().Rows[1].Cells[1].Paragraphs[0].Append("Мед звичайний", new Xceed.Document.NET.Formatting() { FontFamily = new Font("Times New Roman"), Size = 14 });
            d.Tables.First().Rows[1].Cells[2].Paragraphs[0].Append("110", new Xceed.Document.NET.Formatting() { FontFamily = new Font("Times New Roman"), Size = 14 });
            d.Tables.First().RemoveRow();
            d.Tables.First().RemoveRow();
            d.Tables.First().RemoveRow();
            d.Tables.First().RemoveRow();
            d.ReplaceText("№__", "11 ");
            d.ReplaceText("«__»______", "21 жовтня");
            d.ReplaceText("закупку_______", "партії меду ");
            d.ReplaceText("_(постачальник)_", "ROZETKA");
            d.ReplaceText("___(дата)___", "25.10.2021");
            d.ReplaceText("_____.", "Кузьмич В.Ф.");
            //var doc = DocX.Create(fileName);

            //doc.InsertParagraph("Hello Word");

            //doc.Save();
            d.Save();
            //Process.Start("WINWORD.EXE", fileName);
        }
    }
}
