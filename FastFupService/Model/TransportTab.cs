using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFupService.Model
{
    public class TransportTab
    {
        private int _id;
        private string _lastbil;
        private string _chaufførnavn;
        private string _dato;
        private double _antalKm;
        private double _gennemsnit;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Lastbil
        {
            get { return _lastbil; }
            set { _lastbil = value; }

        }
        public string ChaufførNavn
        {
            get { return _chaufførnavn; }
            set { _chaufførnavn = value; }
        }
        public string Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }
        public double AntalKm
        {
            get { return _antalKm; }
            set { _antalKm = value; }
        }

        public double Gennsmsnit
        {
            get { return _gennemsnit; }
            set { _gennemsnit = value; }
        }

        public TransportTab(int id, string lastbil, string chaufførNavn, string dato, double antalKm, double gennemsnit)
        {
            _id = id;
            _lastbil = lastbil;
            _chaufførnavn = chaufførNavn;
            _dato = dato;
            _antalKm = antalKm;
            _gennemsnit = gennemsnit;
        }

        public TransportTab()
        {

        }
    }
}
