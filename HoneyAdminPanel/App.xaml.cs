using HoneyDataBace;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HoneyAdminPanel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public  HoneyDbContext HoneyDbContext { get; init ; }
        public App()
        {
           HoneyDbContext = new HoneyDbContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HoneyAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
