using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface ISlnCreatorService
    {
        void Generate(
            Copyright copyright, 
            Namespace nameSpace, 
            DBStructure dbStructure, 
            string dir);
    }
}
