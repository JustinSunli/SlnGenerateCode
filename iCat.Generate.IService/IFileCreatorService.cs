using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface IFileCreatorService
    {
        void Generate();

        string GetCode(
            TableStructure table,
            Namespace nSpace,
            Copyright copyright);
    }
}
