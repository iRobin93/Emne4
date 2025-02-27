using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayerApp.Model
{
    public static class CommonModel
    {
        public static readonly HttpClient client = new HttpClient();
    }
}
