using System.Collections.Generic;
using System.Text;

namespace MessageApplication.Web
{
    public static class Transliteration
    {
        private static readonly Dictionary<string, string> Dictionary = new Dictionary<string, string>();
        static Transliteration()
        {
            Dictionary.Add("А", "A");
            Dictionary.Add("а", "a");
            Dictionary.Add("Б", "B");
            Dictionary.Add("б", "b");
            Dictionary.Add("В", "V");
            Dictionary.Add("в", "v");
            Dictionary.Add("Г", "G");
            Dictionary.Add("г", "g");
            Dictionary.Add("Д", "D");
            Dictionary.Add("д", "d");
            Dictionary.Add("Е", "E");
            Dictionary.Add("е", "e");
            Dictionary.Add("Ё", "E");
            Dictionary.Add("ё", "e");
            Dictionary.Add("Ж", "Zh");
            Dictionary.Add("ж", "zh");
            Dictionary.Add("З", "Z");
            Dictionary.Add("з", "z");
            Dictionary.Add("И", "I");
            Dictionary.Add("и", "i");
            Dictionary.Add("Й", "I");
            Dictionary.Add("й", "i");
            Dictionary.Add("К", "K");
            Dictionary.Add("к", "k");
            Dictionary.Add("Л", "L");
            Dictionary.Add("л", "l");
            Dictionary.Add("М", "M");
            Dictionary.Add("м", "m");
            Dictionary.Add("Н", "N");
            Dictionary.Add("н", "n");
            Dictionary.Add("О", "O");
            Dictionary.Add("о", "o");
            Dictionary.Add("П", "P");
            Dictionary.Add("п", "p");
            Dictionary.Add("Р", "R");
            Dictionary.Add("р", "r");
            Dictionary.Add("С", "S");
            Dictionary.Add("с", "s");
            Dictionary.Add("Т", "T");
            Dictionary.Add("т", "t");
            Dictionary.Add("У", "U");
            Dictionary.Add("у", "u");
            Dictionary.Add("Ф", "F");
            Dictionary.Add("ф", "f");
            Dictionary.Add("Х", "Kh");
            Dictionary.Add("х", "kh");
            Dictionary.Add("Ц", "Ts");
            Dictionary.Add("ц", "ts");
            Dictionary.Add("Ч", "Ch");
            Dictionary.Add("ч", "ch");
            Dictionary.Add("Ш", "Sh");
            Dictionary.Add("ш", "sh");
            Dictionary.Add("Щ", "Shch");
            Dictionary.Add("щ", "shch");
            Dictionary.Add("Ъ", "Ie");
            Dictionary.Add("ъ", "ie");
            Dictionary.Add("Ы", "Y");
            Dictionary.Add("ы", "y");
            Dictionary.Add("Ь", "");
            Dictionary.Add("ь", "");
            Dictionary.Add("Э", "E");
            Dictionary.Add("э", "e");
            Dictionary.Add("Ю", "Iu");
            Dictionary.Add("ю", "iu");
            Dictionary.Add("Я", "Ia");
            Dictionary.Add("я", "ia");
        }

        public static string CyrillicToLatin(string cyrillicString)
        {
            if (string.IsNullOrEmpty(cyrillicString))
            {
                return string.Empty;
            }

            var builder = new StringBuilder(cyrillicString);

            foreach (KeyValuePair<string, string> key in Dictionary)
            {
                builder.Replace(key.Key, key.Value);
            }

            return builder.ToString();
        }
    }
}
