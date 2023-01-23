using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbatoio_D_Acqua
{
    public class Serbatoio
    {
        private string _numeroseriale;
        private string _modello;
        private string _produttore;
        private float _quantmax;
        private float _quantmin;
        private float _livelloattuale;

        public Serbatoio (string numeroseriale, string modello, string produttore, float quantmax, float quantmin, float livelloattuale)
        {
            this._numeroseriale = numeroseriale;
            this._modello = modello;
            this._produttore = produttore;
            this._quantmax = quantmax;
            this._quantmin = quantmin;
            this._livelloattuale = livelloattuale;
        }

        public Serbatoio()
        {

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
                if (_quantmin >= _quantmax)
                {
                    throw new Exception("Quantità massima minore della quantità minima");
                }
                else if (value < 0)
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
                if (_quantmin >= _quantmax)
                {
                    throw new Exception("Quantità massima minore della quantità minima");
                }
                else if (value <0)
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
            else if (delta + Livelloattuale > Quantmax)
            {
                throw new Exception("livello massimo oltrepassato");
            }
            else
                Livelloattuale += delta;
        }
        public void rimuovi(float gamma)
        {
            if (gamma <= 0)
            {
                throw new Exception("l' acqua aggiunta non è abbastanza");
            }
            else if (gamma - Livelloattuale < Quantmin)
            {
                throw new Exception("livello minimo superato");
            }
            else
                Livelloattuale -= gamma;
        }
        public string visualizza()
        {
            return ToString2();
        }
        public string ToString()
        {
            return Numeroseriale + " " + Modello + " " + Produttore + " " + Quantmax + " " + Quantmin + " " + Livelloattuale;
        }
        public string ToString2()
        {
            return  "" + Livelloattuale;
        }
        public string confronta(Serbatoio s2)
        {
            string armeno = "";
            if (this.Livelloattuale - s2.Livelloattuale == 0)
                armeno = "Il livello dei due serbatoi è uguale";
            else if (this.Livelloattuale - s2.Livelloattuale>0)
                armeno = "Il livello del primo serbatoio è maggiore";
            else if (this.Livelloattuale - s2.Livelloattuale < 0)
                armeno = "Il livello del primo serbatoio è minore";
            return armeno;
        }
        public void svuota(Serbatoio s2)
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
        }
        public string partiziona(Serbatoio[] serb)
        {
            float acqua = this.Livelloattuale;
            float svuota = 0;
            svuota = this.Livelloattuale - this.Quantmin;
            this.Livelloattuale = this.Quantmin;
            svuota = svuota / serb.Length;
            for(int i =0; i < serb.Length; i++)
            {
                serb[i].Livelloattuale += svuota;
            }
            return "il tuo serbatoio è stato svuotato e altri "+serb.Length+"sono stati riempiti con "+svuota +" litri";
        }


    }
}
