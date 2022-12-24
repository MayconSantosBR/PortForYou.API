using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PortForYou.Test.Project.Helpers
{
    public static class ClientHelper
    {
        public static StringContent GenerateBody(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, Application.Json);
        }
    }
}
