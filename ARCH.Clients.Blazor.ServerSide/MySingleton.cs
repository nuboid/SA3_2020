using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARCH.Clients.Blazor.ServerSide
{
    public class MySingleton
    {
        private string _data;
        public void SetData(string data)
        {
            _data = data;
            TheEvent(_data);
        }
        public string GetData()
        {
            return _data;
        }

        public Action<String> TheEvent;
    }
}
 