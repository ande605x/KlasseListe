using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace KlasseListe.Model
{
    public class HovedKlasseListe : ObservableCollection<KlasseInfo>
    {
        public HovedKlasseListe():base()
        {
            this.Add(new KlasseInfo() { Fornavn = "Anders", Efternavn="Thomsen", MobilNr=29932466,Email= "ande605x@edu.easj.dk", GitNavn="ande605x"});
            this.Add(new KlasseInfo() { Fornavn = "Benjamin", Efternavn = "Brobæk Lindgaard", MobilNr = 30112203, Email = "Benjaminlindgaard@ka-net.dk", GitNavn = "BenjiiBoy" });

        }

    }
}
