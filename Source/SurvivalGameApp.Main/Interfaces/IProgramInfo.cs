using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SurvivalGameApp.Main.Interfaces
{
    public interface IProgramInfo
    {
        string MenuName { set; get; }
        Image MenuImage { set; get; }
        string MenuDtil { set; get; }
        string NavigationSource { set; get; }
        string UriParam { set; get; }
        NavigationParameters NavigationParameter { set; get; }
    }
}
