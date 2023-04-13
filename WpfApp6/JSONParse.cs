using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace WpfApp6
{
    public static class JSONParse
    {
        public static void Ser(string path, object obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
        public static T Des<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}
