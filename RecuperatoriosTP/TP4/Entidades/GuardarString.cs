using System;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {   
        //Este método recibe un texto y el nombre del archivo y se encarga de abrir archivo,le anexa  la cadena string y, a continuación, cierra el archivo.
        public static bool Guardar(this string texto, string archivo)
        {
            string path = string.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
            File.AppendAllText(path, texto);

            return true;
        }
    }
}
