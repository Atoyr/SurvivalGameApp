﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SurvivalGameApp.Main.Util;

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

        [DataMember(Name = "Module")] 
        public List<ModuleInfo> ModuleList { set; get; }

        public static ApplicationContext RoadSetting(string path)
        {
            try
            {
                return JsonUtil.DeserializeJson<ApplicationContext>( IOUtil.ReadTextFile(path));
            }
            catch
            {
                return new ApplicationContext();
            }
        }

        public bool SaveSetting(string path)
        {
            try
            {
                return IOUtil.WriteTextFile(JsonUtil.SerializeJson<ApplicationContext>(this),path);
            }
            catch
            {
                return false;
            }
        }
    }

    [DataContract]
    public class ModuleInfo
    {
        [DataMember(Name = "Assembly")]
        string AssemblyName { set; get; } = string.Empty;
        [DataMember(Name = "Namespace")]
        string Namespace { set; get; } = string.Empty;
        [DataMember(Name = "Module")]
        string MainModuleClassName { set; get; } = string.Empty;
        [DataMember(Name = "ProgramInfo")]
        string ProgramInfoClassName { set; get; } = string.Empty;
    }
}
