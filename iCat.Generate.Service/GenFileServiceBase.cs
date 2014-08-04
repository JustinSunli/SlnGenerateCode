using iCat.Generate.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        protected delegate object[] DLGetIterParams(
            CodeIneration iter,
            int colsRowIndex,
            TableStructure table);

        protected DLGetIterParams _dlGetIterParams;
        protected void AppendCodeInerationsByTable(
            TableStructure table, 
            List<CodeIneration> strIterations)
        {
            #region
            DataRowCollection drs = table._Columns.Tables[0].Rows;
            for (int i = 0; i < drs.Count; i++)
            {
                foreach (CodeIneration iter in strIterations)
                {
                    string temp = string.Format(iter._Template,
                    _dlGetIterParams(iter, i, table));

                    if (i == drs.Count - 1)
                        iter._Returns.Append(temp);
                    else
                        iter._Returns.AppendLine(temp);
                }
            }
            #endregion
        }
    }
}
