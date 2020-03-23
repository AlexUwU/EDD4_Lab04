using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace nombreFacil.Models
{
    public class Implementacion
    {
        
        public string path="";
        public string root = "";
      
        public Implementacion(string path, string root)
        {
            this.path = path;
            this.root = root;

        }

        public void Comprimir()
        {
            string root2 = root;
            root = root + @"\\Upload\\Escritoriovpn.hdef";
            HuffmanEncodeFile hef = new HuffmanEncodeFile(@path, @root);
            byte[] b = hef.Encode();
            root = root2 + @"\\Upload\\Comprimido.huff";
            File.WriteAllBytes(@root, b);
        }

        public void Descomporimir()
        {
            string root2 = root;
            string root3 = root;
            root = root + @"\\Upload\\Comprimido.huff";
            byte[] fileBytes = FileHelper.GetArchivoBytes(@root);
            root3 = root3 + @"\\Upload\\Escritoriovpn.hdef";
            string bb = HuffmanEncodeFile.Decode(fileBytes, @root3);
            root = root2 + @"\\Upload\\descomprimidoHuff.txt";
            File.WriteAllText(@root, bb);
        }
    }
}
