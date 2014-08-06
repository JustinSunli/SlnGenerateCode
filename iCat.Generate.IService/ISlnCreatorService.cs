using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface ISlnCreatorService
    {
        void Generate();
        void GenerateAll(Copyright _copyright, Namespace _nameSpace, DBStructure _dbStructure, string dir);
    }
}
