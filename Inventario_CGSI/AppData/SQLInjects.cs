using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario_CGSI.AppData
{
    public class SQLInjects
    {
        public string Remover(string Texto)
        {
            string temp = "";
            for (int i = 0; i < Texto.Length; i++)
            {
                if (Texto[i] == '\'' || Texto[i] == ';' ||
                    Texto[i] == '%' || Texto[i] == '\"' ||
                    Texto[i] == '\\' || Texto[i] == '/' ||
                    Texto[i] == '|')
                    i++;
                if (i < Texto.Length)
                    temp += Texto[i];
            }

            return temp;
        }
    }
}