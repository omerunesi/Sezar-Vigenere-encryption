using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sezar_VigenereSifreleme
{
    public static class VigenereSifreleme
    {
        public static string Encoding(string text, string key)
        {
            text = text.ToLower();

            key = key.ToLower();

            char[] alfabe = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z'};

            char[] chText = text.ToCharArray();
            char[] chKey = key.ToCharArray();

            string encodedText = string.Empty;

            int textValue = -1;
            int keyValue = -1;

            for (int i = 0; i < chText.Length; i++)
            {
                if (chText[i] == ' ')
                {
                    encodedText = encodedText + ' ';
                    i++;
                }

                for (int j = 0; j < alfabe.Length; j++)
                {
                    if (alfabe[j] == chText[i])
                    {
                        textValue = j + 1;
                    }
                    if (alfabe[j] == chKey[i % chKey.Length])
                    {
                        keyValue = j + 1;
                    }
                }
                encodedText = encodedText + alfabe[(textValue + keyValue - 1) % 29];
            }
            return encodedText;
        }
    }
}
