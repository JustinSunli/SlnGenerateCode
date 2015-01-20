using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class CodeIneration
    {
        private string _template;

        public string _Template
        {
            get { return _template; }
            set { _template = value; }
        }

        private StringBuilder _returns;

        public StringBuilder _Returns
        {
            get { return _returns; }
            set { _returns = value; }
        }
        private EnumStrIteration _iterType;

        public EnumStrIteration _IterType
        {
            get { return _iterType; }
            set { _iterType = value; }
        }

        public CodeIneration()
        {
            if (_returns == null)
                _returns = new StringBuilder();
        }
    }
    public enum EnumStrIteration
    {
        EntityFields,
        EntityAssigns,
        DataColumnsAdd,
        AshxAssign,
        DataAssigns,
        DataFields,
        SlnProjects,
        SlnCompiles,
        SpringDIDao,
        SpringDIService,
        SpringKeys
    }

}
