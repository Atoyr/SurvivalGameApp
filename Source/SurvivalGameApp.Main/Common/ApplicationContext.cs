using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SurvivalGameApp.Main.Common
{
    [DataContract]
    public class ApplicationContext
    {
        [DataMember(Name ="Width")]
        public double Width { set; get; } = 100d;

        [DataMember(Name = "Height")]
        public double Height { set; get; } = 100d;

        [DataMember(Name = "Topmost")]
        public bool Topmost { set; get; } = false;

        [DataMember(Name = "Title")]
        public string Title { set; get; } = string.Empty;

        [DataMember(Name = "Background")]
        public string Background { set; get; } = string.Empty;
    }
}
