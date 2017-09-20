using System.Collections.Generic;
using System.IO;

namespace ControleEstoque.Helpers {
    public class ArquivoTxt {

        public static string lerArquivo(string caminho) {
            StreamReader stream = new StreamReader(caminho);
            string arquivoLido = stream.ReadToEnd();
            stream.Close();
            return arquivoLido;
        }

        public static void escreverArquivo(string caminho, string texto) {
            StreamWriter stream = new StreamWriter(caminho, false, System.Text.Encoding.UTF8);
            stream.Write(texto);
            stream.Close();
        }

    }
}