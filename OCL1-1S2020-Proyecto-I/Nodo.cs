using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCL1_1S2020_Proyecto_I
{
    class Nodo
    {
        private string token;
        private string lexema;
        private int columna;
        private int fila;
        private Nodo siguiente;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public string Lexema
        {
            get { return lexema; }
            set { lexema = value; }
        }

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }

    }
}
