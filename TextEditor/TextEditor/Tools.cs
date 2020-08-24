using System;

namespace TextEditor
{
    class Tools
    {
        public static string deletePunctuation( string fileText, string mark)
        {
            fileText = fileText.Replace(mark, "");
            return fileText;
        }
        public static string deleteWords(string msg, int sup)
        {
            char[] chars = new char[msg.Length];

            int index = 0;
            int count = 0;
            for (int i = 0; i < msg.Length; ++i)
            {
                if (Char.IsLetter(msg[i]))
                    ++count;
                else
                {
                    if (count <= sup)
                        index -= count;
                    count = 0;
                }
                chars[index++] = msg[i];
            }
            return new String(chars, 0, index);
        }
    }
}
