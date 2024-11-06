using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.Setting
{
    //Creating an interface for maintenance
    public interface ISettingService
    {
        Task ToggleMaintenence();

        bool GetMaintenanceState();
    }
}
