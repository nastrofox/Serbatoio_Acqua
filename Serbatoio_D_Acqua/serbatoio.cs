using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serbatoio_D_Acqua
{
    internal class serbatoio
    {
        private string _numeroseriale;
        private string _modello;
        private string _produttore;
        private float _quantmax;
        private float _quantmin;
        private float _livelloattuale;

        public serbatoio (string numeroseriale, string modello, string produttore, float quantmax, float quantmin, float livelloattuale)
        {
            this.Numeroseriale = numeroseriale;
            this.Modello = modello;
            this.Produttore = produttore;
            this._quantmax = quantmax;
            this._quantmin = quantmin;
            this._livelloattuale = livelloattuale;
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
                if (_quantmax < _livelloattuale)
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
                if (_livelloattuale < _quantmin)
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
                if (_quantmax < _livelloattuale || _livelloattuale < _quantmin)
                {
                    throw new Exception("livello attuale troppo alto");
                }
                else
                _livelloattuale = value;
            }
            get { return _livelloattuale; }
        }
    }
}
