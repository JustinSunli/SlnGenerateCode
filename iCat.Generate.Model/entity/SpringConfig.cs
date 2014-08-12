using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class SpringConfig
    {
        public const string DITemplate = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<objects xmlns=""http://www.springframework.net""
         xmlns:db=""http://www.springframework.net/database"">
{0}

{1}
</objects>";

        public const string AppconfigTemplate = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
  <configSections>
    <sectionGroup name=""spring"">
      <section name=""context"" type=""Spring.Context.Support.ContextHandler, Spring.Core""/>
      <section name=""objects"" type=""Spring.Context.Support.DefaultSectionHandler, Spring.Core""/>
    </sectionGroup>
  </configSections>

  <spring>
    <context>
      <resource uri=""DBConfig.xml""></resource>
      <resource uri=""DIConfig.xml""></resource>
    </context>
  </spring>
</configuration>";

        public const string DBTemplate = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<objects xmlns=""http://www.springframework.net""
         xmlns:db=""http://www.springframework.net/database""
         xmlns:tx=""http://www.springframework.net/tx"">
<!--default connect database config-->
  <db:provider id=""dbProvider_dbsystem""
                provider=""SqlServer-2.0""
                connectionString=""Data Source=.;Initial Catalog=DevOrder;Persist Security Info=True;User ID=sa;Password=longhope""/>
  
  <object id=""adoTemplate"" type=""Spring.Data.Core.AdoTemplate, Spring.Data"">
    <property name=""DbProvider"" ref=""dbProvider_dbsystem""/>
    <property name=""DataReaderWrapperType"" value=""Spring.Data.Support.NullMappingDataReader, Spring.Data""/>
  </object>

  <!-- Transaction Manager if using more than two databases。 -->
  <object id=""transactionManager""
          type=""Spring.Data.Core.ServiceDomainPlatformTransactionManager, Spring.Data"">
  </object>
  <!-- Transaction aspect -->
  <tx:attribute-driven/>

</objects>";

    }
}
