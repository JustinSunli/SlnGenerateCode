using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Service
{
    public class GenFileServiceBase
    {
        protected string StrcatUsing(
            IList<string> usings)
        {
            #region
            StringBuilder strusings = new StringBuilder();
            for (int i = 0; i < usings.Count; i++)
                strusings.AppendLine(
                    string.Format("using {0}",
                    usings[i]));
            return strusings.ToString();
            #endregion

        }
    }
}
