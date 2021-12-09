using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyAdminPanel.ViewModels
{
    public class DbViewModel<T> : INotifyPropertyChanged where T : class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<T> Items { get; set; }


        public DbViewModel(List<T> list)
        {
            Items = list;
        }
    }
}
