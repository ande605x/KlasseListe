using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KlasseListe.ViewModel
{
    public class KlasseViewModel:INotifyPropertyChanged
    {
        public Model.HovedKlasseListe Listen { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public AddElevCommand AddElevCommand { get; set; }

        private Model.KlasseInfo selectedElev;

        public Model.KlasseInfo SelectedElev
        {
            get { return selectedElev; }
            set
            { 
                selectedElev = value;
                this.OnPropertyChanged(nameof(SelectedElev));
            }
        }

        public Model.KlasseInfo nyElev
        {   get;
            set;
        }

        //public RelayCommand AddElevCommand { get; set; }

        public void AddNyElev()
        {
            Listen.Add(nyElev);
        }

        //

        public KlasseViewModel()
        {
            Listen = new Model.HovedKlasseListe();
            SelectedElev = new Model.KlasseInfo();
            // AddElevCommand = new RelayCommand(AddNyElev);
            AddElevCommand = new ViewModel.AddElevCommand(AddNyElev);
            nyElev = new Model.KlasseInfo();

        }
    }
}
