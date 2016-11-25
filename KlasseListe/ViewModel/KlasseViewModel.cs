using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using System.IO;
using Windows.Storage;

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

        public DeleteElevCommand DeleteElevCommand { get; set; }

        StorageFolder localfolder = null;

        private readonly string filnavn = "JsonText.json";

        public RelayCommand GemDataCommand { get; set; }

        public RelayCommand HentDataCommand { get; set; }

        public RelayCommand ClearListeCommand { get; set; }


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
            Model.KlasseInfo TempKlasseInfo = new Model.KlasseInfo();
            TempKlasseInfo.Fornavn = nyElev.Fornavn;
            TempKlasseInfo.Efternavn = nyElev.Efternavn;
            TempKlasseInfo.Email = nyElev.Email;
            TempKlasseInfo.GitNavn = nyElev.GitNavn;
            TempKlasseInfo.MobilNr = nyElev.MobilNr;
            Listen.Add(TempKlasseInfo);
        }

        public void DeleteElev()
        {
            Listen.Remove(selectedElev);

        }

        public void ClearListe()
        {
            Listen.Clear();
        }

        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.Listen.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file,jsonText);
        }

        public async void HentDataFromDiskAsync()
        {
            this.Listen.Clear();
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            Listen.InsertJson(jsonText);

        }
        //

        public KlasseViewModel()
        {
            Listen = new Model.HovedKlasseListe();
            SelectedElev = new Model.KlasseInfo();
            // AddElevCommand = new RelayCommand(AddNyElev);
            AddElevCommand = new ViewModel.AddElevCommand(AddNyElev);
            DeleteElevCommand = new DeleteElevCommand(DeleteElev);
            nyElev = new Model.KlasseInfo();
            GemDataCommand = new RelayCommand(GemDataTilDiskAsync);
            HentDataCommand = new KlasseListe.RelayCommand(HentDataFromDiskAsync);
            localfolder = ApplicationData.Current.LocalFolder;

            ClearListeCommand = new RelayCommand(ClearListe);

        }
    }
}
