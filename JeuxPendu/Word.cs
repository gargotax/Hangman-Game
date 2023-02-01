using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxPendu
{
    public class Word
    {
        public string Text { get; set; }
        public int Length { get; }

        public Word(string Text)
        {
            this.Text = Text.ToUpper();
            this.Length = Text.Length;
        }

        public int GetIndexOf(char letter)
        {
            return this.Text.IndexOf(letter);
        }

    }

}
