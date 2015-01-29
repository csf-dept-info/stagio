using System.IO;
using System.Linq;

namespace Stagio.TestUtilities
{
    public class FileUtilities
    {
        public static string GetPathFromFileName(string fileName)
        {
            var threeFoldersUp = Path.GetFullPath("../../../");
            var testFilesPath = Directory.GetDirectories(threeFoldersUp, "TestFiles", SearchOption.AllDirectories).FirstOrDefault();
            
            return Path.Combine(testFilesPath, fileName);
        }
    }
}
