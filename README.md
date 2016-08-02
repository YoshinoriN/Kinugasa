# Kinugasa 

My Library for .NET

# Porpose
* For sutudy code design.
* For study english.
* For study .NET Framework & C#
* Try to use CI services.

# CI Statuses

|Porpose|Service|Status|Remark|
|---|---|---|---|
|Build & Test|AppVeyor|[![Build status](https://ci.appveyor.com/api/projects/status/mk3thjjapkd1u444/branch/master?svg=true)](https://ci.appveyor.com/project/YoshinoriN/kinugasa)|UWP projects doesn't build. AppVeyor can't build these projects.|
|Build for mono|TravisCI|Planning||
|Static Code Analysis|CodeClimate|[![Issue Count](https://codeclimate.com/github/YoshinoriN/Kinugasa/badges/issue_count.svg)](https://codeclimate.com/github/YoshinoriN/Kinugasa)|Only check Markdown syntax and code's comments.|
|Static Code Analysis|SonarQube|Planning||
|Coverage|Coveralls|[![Coverage Status](https://coveralls.io/repos/github/YoshinoriN/Kinugasa/badge.svg?branch=master)](https://coveralls.io/github/YoshinoriN/Kinugasa?branch=master)|Only create project on Caveralls.|

# Releases

Please see [releases page.](https://github.com/YoshinoriN/Kinugasa/releases)

|Assembly|Type|Version|Remark|
|---|---|---|---|
|Kinugasa.Mvvm|PCL|![](https://img.shields.io/badge/Kinugasa.Mvvm-v1.1.0-blue.svg)|MVVM Library|
|Kinugasa.Uwp.Mvvm|Windows10|![](https://img.shields.io/badge/Kinugasa.Mvvm-v1.1.0-blue.svg)|MVVM Library for Windows10|

# Development
* C# 6
* Visual Studio Community 2015
* MSTest (On Visual Studio Community 2015)

# Dependent library
Currently nothing.

# Build path
All project's assemblies will output to `root/bin/` directoy.
