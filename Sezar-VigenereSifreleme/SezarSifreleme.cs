using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sezar_VigenereSifreleme
{

    public static class SezarSifreleme
    {
        public static ListView lw_cozumler;
        public static RichTextBox rchTxt_sifreliMetin;

        public static string Encoding(string text, int key)
        {
            text = text.ToLower();

            char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z'};

            char[] chText = text.ToCharArray();

            string encodedText = string.Empty;

            for (int i = 0; i < chText.Length; i++)
            {
                if (chText[i] == ' ')
                {
                    encodedText = encodedText + ' ';
                    i++;
                }
                for (int j = 0; i < alfabe.Length; j++)
                {
                    if (chText[i] == alfabe[j])
                    {
                        encodedText = encodedText + alfabe[(j + key) % 29];
                        break;
                    }
                }
            }
            return encodedText;
        }

        public static void Decoding()
        {
            string text = rchTxt_sifreliMetin.Text;
            text = text.ToLower();

            string[] words = text.Split(' ');
            string[,] decodedWords = new string[29, words.Length];

            char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z'};

           
            for (int i = 0; i < words.Length; i++)
            {
                int x = 0;
                int syc = 1;
                string decodedCh = string.Empty;
                char[] chText = words[i].ToCharArray();

                for (int l = 29; l > 0; l--)
                {
                    decodedCh = string.Empty;
                    for (int k = 0; k < chText.Length; k++)
                    {
                        for (int j = 0; j < alfabe.Length; j++)
                        {
                            if (chText[k] == alfabe[j])
                            {
                                x = j;
                                break;
                            }
                        }
                        if (x - syc < 0)
                        {
                            x += 29;
                        }
                        decodedCh = decodedCh + alfabe[x-syc];                        
                    }
                    decodedWords[syc - 1,i] = decodedCh;                     
                    syc++;
                    x--;
                }
            }
            
            for (int i = 0; i < 29; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < words.Length; j++)
                {
                    line = line + ' ' + decodedWords[i, j];
                }
                string[] item = { (i + 1).ToString(), line };
                lw_cozumler.Items.Add(new ListViewItem(item));
            }
        }
    }
}
