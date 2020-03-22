using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LZW_Compression_Decompression.Models
{
    public class ImpelmentacionLZW
    {
      string ruta = @"C:\Users\Rodrigo\Desktop\comprimido2.lzw";
            string text = System.IO.File.ReadAllText(@"C:\Users\Rodrigo\Desktop\prueba.txt");
            string descomprimido = "";
            List<int> comprimido = new List<int>();
            comprimido = LZW.Compresion(text);

            List<char> bytecompress = new List<char>();

            foreach (int numero in comprimido)
            {
                bytecompress.Add((char)numero);
            }
            using (StreamWriter outputFile = new StreamWriter(ruta))
            {
                foreach (char caracter in bytecompress)
                {
                    outputFile.Write(caracter.ToString());
                }
            }
            //
            const int bufferLength = 100;
            List<int> bytedecompress = new List<int>();

            var buffer = new char[bufferLength];
            using (var file = new FileStream(ruta, FileMode.Open))
            {
                using (var reader = new BinaryReader(file))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        buffer = reader.ReadChars(bufferLength);
                        foreach (var item in buffer)
                        {
                            //Console.Write((char)item);
                            bytedecompress.Add((int)Convert.ToChar(item));
                        }

                        //Console.ReadKey();
                    }

                }

            }
            //
            descomprimido  = LZW.Descompresion(bytedecompress);

            File.WriteAllText(@"C:\Users\Rodrigo\Desktop\descomprimido.txt", descomprimido);
            int a = 0;
            
        
    }
}
