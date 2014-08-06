using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IDao
{
    public interface IConnect
    {
        void SetConnection(Connection connection);
    }
}
