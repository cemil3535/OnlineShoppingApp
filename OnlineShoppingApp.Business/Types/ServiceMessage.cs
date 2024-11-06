using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Types
{
    // messages to return whether the transaction was successful or unsuccessful

    public class ServiceMessage
    {
        public bool IsSucceed { get; set; }

        public string Message { get; set; }
    }

    public class ServiceMessage<T>
    {
        public bool IsSucceed { get; set; }

        public string Message { get; set; }

        public T? Data { get; set; }
    }
}
