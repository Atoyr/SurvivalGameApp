using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGameApp.Main.Util
{
    public static class IOUtil
    {
        public static string ReadTextFile(string filePath)
        {
            return ReadTextFile(filePath, Encoding.Default);
        }

        public static string ReadTextFile(string filePath,Encoding encoding )
        {
            string strValue = string.Empty;
            if (File.Exists(filePath))
            {
                strValue = File.ReadAllText(filePath,encoding);
            }
            return strValue;
        }

        public static void MakeDirectory(string directoryPath)
        {
            try
            {
                DirectoryInfo di = Directory.CreateDirectory(directoryPath);
            }
            catch ( IOException e)
            {
                throw new Exception("Directory Exists", e);
            }
            catch ( UnauthorizedAccessException e)
            {
                throw new Exception("No Access Authority", e);
            }
        }

        public static bool WriteTextFile(string contents, string filePath,Encoding encoding, bool isOverwrite)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                try
                {
                    MakeDirectory(Path.GetDirectoryName(filePath));
                }
                catch
                {
                    return false;
                }
            }

            if (File.Exists(filePath) && !isOverwrite)
            {
                return false;
            }

            File.WriteAllText(filePath, contents,encoding);
            return true;
        }
    }
}
