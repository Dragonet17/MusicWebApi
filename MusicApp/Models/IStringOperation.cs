using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    interface IStringOperation
    {
        string CutString(string name, int numberofchars);

        string EncodeStringUtf8(string name);
    }
}
