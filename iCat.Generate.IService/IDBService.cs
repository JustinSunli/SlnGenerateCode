﻿using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.IService
{
    public interface IDBService
    {
        bool IsSuccessConnectDB(Connection connection);

        DBStructure GetDBStructure(
            Model.Connection connection);
    }
}
