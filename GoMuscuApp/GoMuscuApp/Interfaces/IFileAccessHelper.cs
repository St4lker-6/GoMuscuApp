using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMuscuApp.Interfaces
{
    public interface IFileAccessHelper
    {
        string GetLocalFilePath(string fileName);

        bool CheckFileExists(string filePath);
    }
}
