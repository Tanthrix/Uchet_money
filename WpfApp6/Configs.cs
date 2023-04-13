using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    public static class Configs
    {
        public static string dpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string notepath = dpath + "/notes.json";
        public static string typepath = dpath + "/types.json";
    }
}
