using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OCL1_1S2020_Proyecto_I
{
    class Tokens
    {
        DataTable T = new DataTable();
        public Tokens()
        {
            T.Columns.Add("token", typeof(string));
            T.Columns.Add("lexema", typeof(string));
            T.Columns.Add("fila", typeof(int));
            T.Columns.Add("columna", typeof(int));
        }


        public void agregarT(string token, string lexema, int fila, int columna)
        {
            T.Rows.Add(token, lexema, fila, columna);
        }

        public void imprimirTabla()
        {
            foreach(DataRow row in T.Rows)
            {
                Console.WriteLine("T " + row.Field<string>(0) + " L " + row.Field<string>(1) + " F" + row.Field<int>(2) + " C" + row.Field<int>(3));
            }
        }

    }
}
