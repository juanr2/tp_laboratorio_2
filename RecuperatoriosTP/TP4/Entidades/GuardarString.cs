using System;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            string path = string.Format(@"{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);
            File.AppendAllText(path, texto);

            return true;
        }
    }
}
