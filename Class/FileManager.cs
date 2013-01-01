using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileManager.Class
{
    class FileManager
    {
        public Boolean deleteFile(string path)
        {
            if (!File.Exists(path))
            {
                return true;
            }
            File.Delete(path);
            return true;
        }
    }
}
