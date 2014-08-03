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
            {
                string temp = string.Format("using {0};",
                    usings[i]);
                if (i == usings.Count-1)
                    strusings.Append(temp);
                else
                    strusings.AppendLine(temp);
            }
            return strusings.ToString();
            #endregion

        }
    }
}
