using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbatoio_D_Acqua
{
    internal class Serbatoio
    {
        private string _numeroseriale;
        private string _modello;
        private string _produttore;
        private float _quantmax;
        private float _quantmin;
        private float _livelloattuale;

        public Serbatoio (string numeroseriale, string modello, string produttore, float quantmax, float quantmin, float livelloattuale)
        {
            this.Numeroseriale = numeroseriale;
            this.Modello = modello;
            this.Produttore = produttore;
            this.Quantmax = quantmax;
            this.Quantmin = quantmin;
            this.Livelloattuale = livelloattuale;
        }


        public string Numeroseriale
        {
            set 
            {
                if (_numeroseriale == null)
                {
                    throw new Exception("numero seriale non valido");
                }
                else
                _numeroseriale = value; 
            }
            get { return _numeroseriale; }
        }
        public string Modello
        {
            set 
            { 
                if (_modello == null)
                {
                    throw new Exception("modello invalido");
                }
                _modello = value; 
            }
            get { return _modello; }
        }
        public string Produttore
        {
            set 
            { 
                if (_produttore== null)
                {
                    throw new Exception("produttore non valido");
                }else
                _produttore = value; 
            }
            get { return _produttore; }
        }
        public float Quantmax
        {
            set 
            {
                if (value < 0)
                {
                    throw new Exception("quantità massima superata");
                }else
                _quantmax = value; 
            }
            get { return _quantmax; }
        }
        public float Quantmin
        {
            set 
            {
                if (value <0)
                {
                    throw new Exception("quantità minima superata");
                }
                else
                _quantmin = value; 
            }
            get { return _quantmin; }
        }
        public float Livelloattuale
        {
            set
            {
                if (_quantmax < value || value < _quantmin)
                {
                    throw new Exception("livello attuale troppo alto o basso");
                }
                else
                _livelloattuale = value;
            }
            get { return _livelloattuale; }
        }


        public void aggiungi(float delta)
        {
            if (delta <= 0)
            {
                throw new Exception("l' acqua aggiunta non è abbastanza");
            }
            else if (delta + _livelloattuale > _quantmax)
            {
                throw new Exception("livello massimo oltrepassato");
            }
            else
                delta +=_livelloattuale;
        }
        public void rimuovi(float gamma)
        {
            if (gamma <= 0)
            {
                throw new Exception("l' acqua aggiunta non è abbastanza");
            }
            else if (gamma - _livelloattuale < _quantmin)
            {
                throw new Exception("livello minimo superato");
            }
            else
                gamma -= _livelloattuale;
        }
        public string visualizza(float livello)
        {
            return livello.ToString();
        }
        public string ToString()
        {
            return Numeroseriale + " " + Modello + " " + Produttore + " " + Quantmax + " " + Quantmin + " " + Livelloattuale;
        }
        public float confronta(Serbatoio s2)
        {
            return this.Livelloattuale - s2.Livelloattuale;
        }
        public float svuota(Serbatoio s2)
        {
            float svuota = 0;
            svuota = this.Livelloattuale - this.Quantmin;
            this.Livelloattuale = this.Quantmin;
            if (s2.Livelloattuale+svuota > s2.Quantmax)
            {
                s2.Livelloattuale = s2.Quantmax;
            }
            else
            {
                s2.Livelloattuale += svuota;
            }
            return svuota;
        }
        public string partiziona(float numero)
        {
            float svuota = 0;
            svuota = this.Livelloattuale - this.Quantmin;
            this.Livelloattuale = this.Quantmin;
            svuota =svuota / numero;
            return "il tuo serbatoio è stato svuotato e altri "+numero+"sono stati riempiti con "+svuota +" litri";
        }


    }
}
