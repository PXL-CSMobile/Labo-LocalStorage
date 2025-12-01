using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.App.Services
{
    public  interface INavigationService
    {
      //  Task InitializeAsync();

        Task GoToAsync(string route, IDictionary<string, object> routeParameters = null);

        Task GoBackAsync();
    }
}
