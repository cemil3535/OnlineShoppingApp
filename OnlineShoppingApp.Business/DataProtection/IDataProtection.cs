using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.DataProtection
{

    //Defining the necessary interface for DataProtection
    public interface IDataProtection
    {
        string Protect(string text);

        string UnProtect(string protectedText);
    }
}
