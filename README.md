# Kinugasa

My Library for .NET

# Porpose
* For sutudy code design.
* For study english.
* For study .NET & C#
* Try to use CI services.

# CI Statuses

|Porpose|Service|Status|Remark|
|---|---|---|---|
|Build & Test|AppVeyor|[![Build status](https://ci.appveyor.com/api/projects/status/mk3thjjapkd1u444/branch/master?svg=true)](https://ci.appveyor.com/project/YoshinoriN/kinugasa)|* Build all projects. <br> * Check test code. <br> * Crete coverage report and send it to CodeCov.|
|Static Code Analysis|CodeClimate|[![Issue Count](https://codeclimate.com/github/YoshinoriN/Kinugasa/badges/issue_count.svg)](https://codeclimate.com/github/YoshinoriN/Kinugasa)|Only check Markdown syntax and code's comments.|
|Coverage|CodeCov|[![codecov](https://codecov.io/gh/YoshinoriN/Kinugasa/branch/master/graph/badge.svg)](https://codecov.io/gh/YoshinoriN/Kinugasa)|Receive test coverage report from AppVeyor.|

# Releases & Development plan & Compatibility

Please see [releases page](https://github.com/YoshinoriN/Kinugasa/releases), if you want to see deteal.

## Compatibility

* Classic can use PCL assembly. But can not use UWP assembly.
* UWP can use PCL assembly. But can not use classic assembly.

|NameSpace|Classic|PCL|UWP|Overview|Document|
|---|---|---|---|---|---|
|EnumExtention|-|[![](https://img.shields.io/badge/release-v1.0.0-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.EnumExtension.v1.0.0)|-|Enum Extentions libarary.||
|Mvvm|-|[![](https://img.shields.io/badge/release-v1.1.0-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.Mvvm.v1.1.0)|[![](https://img.shields.io/badge/release-v1.1.0-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.Mvvm.v1.1.0)|Minimum MVVM library.|[Document](/Document/Mvvm.md)|
|Map|-|[![](https://img.shields.io/badge/release-v1.0.0-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.Map.v1.0.0)|-|Values mapping libarary.||
|UI|![](https://img.shields.io/badge/Canditate-TDB-yellow.svg)|[![](https://img.shields.io/badge/release-v1.0.1-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.UI.v1.0.1)|-|User interface library.||
|Web|-|-|[![](https://img.shields.io/badge/release-v1.0.0-blue.svg)](https://github.com/YoshinoriN/Kinugasa/releases/tag/Kinugasa.Uwp.Web.v1.0.0)|Web service operation library.|[Document](/Document/Web.md)|

# Development
* C# 6
* Visual Studio Community 2015
* MSTest (On Visual Studio Community 2015)

# Dependency library

|Name|Type|Porpose|
|---|---|---|
|[OpenCover v4.6.519](https://github.com/OpenCover/opencover)|Nuget|Measure of test code coverage.|


# Build path
All project's assemblies will output to `root/bin/` directoy.

# LICENSE

[![License](https://img.shields.io/github/license/YoshinoriN/kinugasa.svg?style=flat-square)](https://github.com/YoshinoriN/kinugasa/blob/master/LICENSE)

* [MIT License (MIT)](LICENSE)
