using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public interface IEntity
    {
        void Get(DataRow dr);
    }
}
