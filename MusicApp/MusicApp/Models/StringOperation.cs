using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MusicApp.Models
{
    public class StringOperation : IStringOperation
    {
       
        public  string CutString(string name, int numberofchars)
        {
            if (name.Length > numberofchars)
            {

                name = name.Remove(numberofchars, name.Length - numberofchars);
            }
            return name;
        }

        public  string EncodeStringUtf8(string name)
        {
            byte[] artistBytes = new byte[100];

            artistBytes = Encoding.Default.GetBytes(name);
            var encodingString = Encoding.UTF8.GetString(artistBytes);

            return encodingString;
        }


      
    }
}