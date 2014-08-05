using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iCat.Generate.Model
{
    public class Project
    {
        #region 项目文件模板
        public const string _CsprojTemplate = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Project ToolsVersion=""12.0"" DefaultTargets=""Build"" xmlns=""http://schemas.microsoft.com/developer/msbuild/2003"">
  <Import Project=""$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props"" Condition=""Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')"" />
  <PropertyGroup>
    <Configuration Condition="" '$(Configuration)' == '' "">Debug</Configuration>
    <Platform Condition="" '$(Platform)' == '' "">AnyCPU</Platform>
    <ProjectGuid>{{{0}}}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>{1}</RootNamespace>
    <AssemblyName>{2}</AssemblyName>
    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition="" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' "">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include=""System"" />
    <Reference Include=""System.Core"" />
    <Reference Include=""System.Xml.Linq"" />
    <Reference Include=""System.Data.DataSetExtensions"" />
    <Reference Include=""Microsoft.CSharp"" />
    <Reference Include=""System.Data"" />
    <Reference Include=""System.Xml"" />
  </ItemGroup>
  <ItemGroup>
{3}
    <Compile Include=""Properties\AssemblyInfo.cs"" />
  </ItemGroup>
  <ItemGroup>
{4}
  </ItemGroup>
  <Import Project=""$(MSBuildToolsPath)\Microsoft.CSharp.targets"" />
</Project>";
        #endregion

        #region 程序集说明文件模板
        public const string _AssemblyTemplate = @"using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle(""{0}"")]
[assembly: AssemblyDescription("""")]
[assembly: AssemblyConfiguration("""")]
[assembly: AssemblyCompany("""")]
[assembly: AssemblyProduct(""{1}"")]
[assembly: AssemblyCopyright(""Copyright ©  2014"")]
[assembly: AssemblyTrademark("""")]
[assembly: AssemblyCulture("""")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid(""{2}"")]

// 程序集的版本信息由下面四个值组成: 
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: 
// [assembly: AssemblyVersion(""1.0.*"")]
[assembly: AssemblyVersion(""1.0.0.*"")]
[assembly: AssemblyFileVersion(""1.0.0.0"")]";
        #endregion

        private Guid _guid;

        public Guid _Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }

        private string _folderName;

        public string _FolderName
        {
            get { return _folderName; }
        }
        private string _name;

        public string _Name
        {
            get { return _name; }
            set { 
                _name = value;
                _assemblyName = _name;
                _folderName = _name;
                _namespace = _name;
            }
        }

        private string _assemblyName;

        public string _AssemblyName
        {
            get { return _assemblyName; }
        }
        private string _namespace;

        public string _Namespace
        {
            get { return _namespace; }
        }

        private IList<string> _referenceNSpace;

        public IList<string> _ReferenceNSpace
        {
            get { return _referenceNSpace; }
            set { _referenceNSpace = value; }
        }
        
    }
}
