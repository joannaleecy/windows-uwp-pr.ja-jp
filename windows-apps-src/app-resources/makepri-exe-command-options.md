---
author: stevewhims
Description: MakePri.exe has the set of commands createconfig, dump, new, resourcepack, and versioned. This topic details their use.
title: MakePri.exe のコマンド ライン オプション
template: detail.hbs
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: c0a3892348baff56bbef8d40dd9aade4e612c50d
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4148651"
---
# <a name="makepriexe-command-line-options"></a>MakePri.exe のコマンド ライン オプション

[MakePri.exe](compile-resources-manually-with-makepri.md) には、`createconfig`、`dump`、`new`、`resourcepack`、`versioned` コマンドのセットが含まれます。 このトピックでは、コマンド ライン オプションの使用について説明します。

> [!NOTE]
> MakePri.exe は、Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションを確認する場合にインストールされます。 パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダーの)。 たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。

## <a name="makepri-commands"></a>MakePri のコマンド

`MakePri.exe help` を実行すると、MakePri.exe で使用できるコマンドが表示されます。

```
C:\>makepri help

Usage:
------
    MakePri.exe <command> [options]

Example:
--------
    MakePri.exe new /cf C:\MyApp\priconfig.xml /pr C:\MyApp\src\ /in PackageName

Description:
------------
    Creates, dumps, and performs utility functions on a PRI file. A PRI file is 
    an index of application resources, such as strings and image files.

Command Options:
----------------
    MakePri.exe createconfig   Creates a PRI config file for use with other
                               commands
    MakePri.exe dump           Dumps the contents of a PRI file
    MakePri.exe new            Creates a new PRI file from scratch
    MakePri.exe resourcepack   Creates a PRI file that contains additional
                               resource variants for a base PRI file
    MakePri.exe versioned      Creates a PRI file based on a previous version

Help:
-----
    MakePri.exe help           Show this help page
    MakePri.exe <command> /?   Shows detailed help for <command>

    For example,
    MakePri.exe createconfig /?
```

## <a name="createconfig-command"></a>Createconfig コマンド

`createconfig` コマンドは、指定した修飾子の既定値を定義する、新しい、初期化された PRI 構成ファイルを作成します。 `MakePri.exe createconfig /?` を実行すると、このコマンドの詳しいヘルプが表示されます。

```
C:\>makepri createconfig /?

Usage:
------
    MakePri.exe createconfig /cf <config file destination> /dq
    <default qualifiers> [options]

Example:
--------
    MakePri.exe createconfig /cf C:\MyApp\priconfig.xml /dq lang-en-US /o /pv 10.0.0

Description:
------------
    Creates a PRI configuration file at <config file destination> with default 
    qualifiers specified by <default qualifiers>. Multiple qualifiers are separated 
    by underscores (_)

Required Parameters:
--------------------
    /ConfigXml(cf)    : <FILEPATH> Configuration file output location
    /Default(dq)      : <QUALIFIERS> The default qualifiers to set in the
                        configuration file. A language qualifier is required

Options:
--------
    /ExtensionDll(ex) : <FILEPATH> Location of the Resource Management System
                        environment extension DLL. This DLL must be signed by
                        a Microsoft-issued certificate. Default is an empty path
                        (no DLL will be used)
    /Overwrite(o)     : Overwrite an existing output file of the same name
                        without prompting
    /Platform(pv)     : <VERSION> Platform version to use for generated
                        configuration file

    FILEPATH          - a path to a file, either relative to the current
                        directory or absolute
    QUALIFIERS        - a valid qualifier token
                        (for example, lang-en-US_scale-100_contrast-high)

Help:
-----
    /Help(h, ?)       : Display the usage help text
```

## <a name="dump-command"></a>Dump コマンド

`dump` コマンドは、指定された PRI ファイル内のすべてのリソースの一覧を含む、ダンプされた xml ファイルを出力します。 `MakePri.exe dump /?` を実行すると、このコマンドの詳しいヘルプが表示されます。

> [!NOTE]
> スキーマのないリソース パックは、PRI 構成ファイルで *omitSchemaFromResourcePacks* スイッチを使用して作成されたものです。 スキーマのないリソース パックを出力するには、`/es <main_package_PRI_file>` スイッチを使用します。 メイン ファイルを指定しない場合、"*The resources.pri in the package was corrupted so encryption failed (error PRI222: 0xdef0000f - Unspecified error occurred)*" (パッケージ内の resources.pri が破損していたため、暗号化できませんでした (エラー PRI222: 0xdef0000f - 特定できないエラーが発生しました)。

```
C:\>makepri dump /?

Usage:
------
    MakePri.exe dump [options]

Example:
--------
    MakePri.exe dump /if C:\MyApp\resources.pri /of C:\resources.pri.xml

Description:
------------
    Outputs a dumped xml file at <output file> containing a list of all 
    resources in <index file>.

Options:
--------
    /DumpType(dt)       : <STRING> Format of the dumped file, default is
                          Basic
    /ExtensionDll(ex)   : <FILEPATH> Location of the Resource Management System
                          environment extension DLL. This DLL must be signed by a
                          Microsoft-issued certificate. Default is an empty path
                          (no DLL will be used)
    /ExternalSchema(es) : <FILEPATH> Location of the external schema file
    /IndexFile(if)      : <FILEPATH> Location of the PRI file to dump from.
                          Default is .\resources.pri
    /OutputFile(of)     : <FILEPATH> Output location of the dump file, default
                          is .\[indexfile].xml
    /OutputOptions(oo)  : <OPTIONS> Options to provide detailed control over
                          contents of XML output files.
    /Overwrite(o)       : Overwrite an existing output file of the same name
                          without prompting
    /Verbose(v)         : Causes verbose messages to be output to the console

    Dump Type:
        Either 'Basic', 'Detailed', 'Schema', or 'Summary'

    FILEPATH            - a path to a file, either relative to the current
                          directory or absolute
Help:
-----
    /Help(h, ?)         : Display the usage help text
```

## <a name="new-command"></a>New コマンド

`new` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、新しい PRI ファイルを作成します。 `MakePri.exe new /?` を実行すると、このコマンドの詳しいヘルプが表示されます。

```
C:\>makepri new /?

Usage:
------
    MakePri.exe new /cf <config file> /pr <project root> [options]

Example:
--------
    MakePri.exe new /cf C:\MyApp\priconfig.xml /pr C:\MyApp\src\ 
    /mn C:\MyApp\AppXManifest.xml /o /of C:\MyApp\src\resources.pri

Description:
------------
    Creates a PRI file at <output file> by indexing all files in
    <project root> and its subdirectories as directed by <config file>. The
    index will be assigned <index name> to reference resources in the app

Required Parameters:
--------------------
    /ConfigXml(cf)    : <FILEPATH> Configuration file location. Use the
                        'Makepri.exe createconfig' command to generate one
    /ProjectRoot(pr)  : <FOLDERPATH> Root location of project files

Options:
--------
    /AutoMerge(am)    : This flag is not recommended for normal use with AppX
                        packages. It causes Makepri.exe to set the auto
                        merge flag within the PRI file. Default is not set.
    /ExtensionDll(ex) : <FILEPATH> Location of the Resource Management System
                        environment extension DLL. This DLL must be signed by
                        a Microsoft-issued certificate. Default is an empty path
                        (no DLL will be used)
    /IndexLog(il)     : <FILEPATH> XML Log of indexed resources, no file
                        generated by default
    /IndexName(in)    : <STRING> Name for the generated index of resources.
                        Typically matches the AppX package name, class library
                        simple name, etc. May be supplied via the
                        [manifest] parameter.
    /IndexOptions(io) : <OPTIONS> Options to provide detailed control over
                        behavior of resource indexers.
    /Manifest(mn)     : <FILEPATH> Location of the application or component's
                        manifest. This parameter is ignored if [indexname]
                        is given. Default is [projectroot]\AppXManifest.xml
    /MappingFile(mf)  : <MAPPINGFILETYPE> Generate a mapping file in the given
                        file format.
    /OutputFile(of)   : <FILEPATH> Output location of PRI file, default is
                        .\resources.pri
    /Overwrite(o)     : Overwrite an existing output file of the same name
                        without prompting
    /ReverseMap(rm)   : Generate a reverse mapping section in the PRI file
                        which can be used for debugging purposes.
    /SchemaFile(sf)   : <FILEPATH> Output location of XML resource schema
                        description.
    /Verbose(v)       : Causes verbose messages to be output to the console
    /VersionMajor(vma): <INTEGER> [Deprecated] Major version number for
                        index, default is 1

    FOLDERPATH        - a path to a folder
    FILEPATH          - a path to a file, either relative to the current
                        directory or absolute
    MAPPINGFILETYPE   - Supported File type(s): 'AppX'

Help:
-----
    /Help(h, ?)        : Display the usage help text
```

## <a name="resourcepack-command"></a>ResourcePack コマンド

`resourcepack` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、新しい PRI ファイルを作成します。 リソース パック PRI ファイルには、既存の PRI ファイルで既に指定されているリソースの追加バリエーションのみが含まれます。 `MakePri.exe resourcepack /?` を実行すると、このコマンドの詳しいヘルプが表示されます。

```
C:\>makepri resourcepack /?

Usage:
------
    MakePri.exe resourcepack /pr <project root> /cf <config file> [options]

Example:
--------
    MakePri.exe resourcepack /cf C:\MyAppEs\priconfig.xml /pr C:\MyAppEs\src\ 
    /if C:\MyApp\1.2\resources.pri /o /of C:\MyAppEs\resources.pri

Description:
------------
    Creates a PRI file at <output file> by indexing all files in 
    <project root> and its subdirectories as directed by <config file>. A 
    resource pack PRI file contains only additional variants of resources 
    already specified in <index file>.

Required Parameters:
--------------------
    /ConfigXml(cf)    : <FILEPATH> Configuration file location. Use
                        'Makepri.exe createconfig' command to generate one
    /ProjectRoot(pr)  : <FOLDERPATH> Root location of project files

Options:
--------
    /AutoMerge(am)    : This flag is not recommended for normal use with AppX
                        packages. It causes Makepri.exe to set the auto
                        merge flag within the PRI file. By default it is set
                        to same as the base PRI file.
    /ExtensionDll(ex) : <FILEPATH> Location of the Resource Management System
                        environment extension DLL. This DLL must be signed by
                        a Microsoft-issued certificate. Default is an empty path
                        (no DLL will be used)
    /IndexFile(if)    : <FILEPATH> Location of the base PRI or XML schema file.
                        Default is <ProjectRoot>\resources.pri
    /IndexLog(il)     : <FILEPATH> XML Log of indexed resources, no file
                        generated by default
    /IndexOptions(io) : <OPTIONS> Options to provide detailed control over
                        behavior of resource indexers.
    /MappingFile(mf)  : <MAPPINGFILETYPE> Generate a mapping file in the given
                        file format.
    /OutputFile(of)   : <FILEPATH> Output location of PRI file, default is
                        .\resources.pri
    /Overwrite(o)     : Overwrite an existing output file of the same name
                        without prompting
    /ReverseMap(rm)   : Generate a reverse mapping section in the PRI file
                        which can be used for debugging purposes.
    /SchemaFile(sf)   : <FILEPATH> Output location of XML resource schema
                        description.
    /Verbose(v)       : Causes verbose messages to be output to the console

    FOLDERPATH        - a path to a folder
    FILEPATH          - a path to a file, either relative to the current
                        directory or absolute
    MAPPINGFILETYPE   - Supported File type(s): 'AppX'

Help:
-----
    /Help(h, ?)        : Display the usage help text
```

## <a name="versioned-command"></a>Versioned コマンド

`versioned` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、バージョン管理された PRI ファイルを作成します。 `MakePri.exe versioned /?` を実行すると、このコマンドの詳しいヘルプが表示されます。

```
C:\>makepri versioned /?

Usage:
------
    MakePri.exe versioned /cf <config file> /pr <project root> [options]

Example:
--------
    MakePri.exe versioned /cf C:\MyApp\priconfig.xml /pr C:\MyApp\src 
    /if C:\MyApp\1.2\resources.pri /o /of C:\MyApp\src\resources.pri /o

Description:
------------
    Creates a versioned PRI file at <output file> by indexing all files in 
    <project root> and its subdirectories as directed by <config file>.

Required Parameters:
--------------------
    /ConfigXml(cf)    : <FILEPATH> Configuration file location. Use
                        'Makepri.exe createconfig' command to generate one
    /ProjectRoot(pr)  : <FOLDERPATH> Root location of project files

Options:
--------
    /AutoMerge(am)    : This flag is not recommended for normal use with AppX
                        packages. It causes Makepri.exe to set the auto
                        merge flag within the PRI file. By default it is set
                        to same as the base PRI file.
    /ExtensionDll(ex) : <FILEPATH> Location of the Resource Management System
                        environment extension DLL. This DLL must be signed by
                        a Microsoft-issued certificate. Default is an empty path
                        (no DLL will be used)
    /IndexFile(if)    : <FILEPATH> Location of the base PRI or XML schema file
                        to version from. Default is <ProjectRoot>\resources.pri
    /IndexLog(il)     : <FILEPATH> XML Log of indexed resources, no file
                        generated by default
    /IndexOptions(io) : <OPTIONS> Options to provide detailed control over
                        behavior of resource indexers.
    /MappingFile(mf)  : <MAPPINGFILETYPE> Generate a mapping file in the given
                        file format.
    /OutputFile(of)   : <FILEPATH> Output location of PRI file, default is
                        [current directory]\resources.pri
    /Overwrite(o)     : Overwrite an existing output file of the same name
                        without prompting
    /ReverseMap(rm)   : Generate a reverse mapping section in the PRI file
                        which can be used for debugging purposes.
    /SchemaFile(sf)   : <FILEPATH> Output location of XML resource schema
                        description.
    /Verbose(v)       : Causes verbose messages to be output to the console

    FOLDERPATH        - a path to a folder
    FILEPATH          - a path to a file, either relative to the current
                        directory or absolute
    MAPPINGFILETYPE   - Supported File type(s): 'AppX'

Help:
-----
    /Help(h, ?)        : Display the usage help text
```

## <a name="47extensiondllex"></a>&#47;ExtensionDll(ex)

拡張 DLL オプション (/ex) を `createconfig`、`dump`、`new`、`resourcepack`、`versioned` と共に使用して、リソース管理システム環境拡張 DLL の場所を指定します。

## <a name="logging47metadata-file"></a>ログ記録&#47;メタデータ ファイル

MakePri は、インデクサーのメタデータ ファイルにリソース パックに固有の情報を含めることができます。 `resources.pri` のログ ファイルと、リソース PRI ファイル `german.pri` と `highresolution.pri` の例を次に示します。

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<root>
  <package filename="resources.pri">
    <instance itemname="Files\logo.jpg" qualifiers="Scale-100" src="" type="Path">
      <value>logo.scale-100.jpg</value>
    </instance>
    <instance itemname="resources\string2" qualifiers="Language-en-us" src="C:\Users\alias\Desktop\repro\app4\project\en-us\resources.resw" type="String">
      <value>value2</value>
    </instance>
    <instance itemname="resources\string1" qualifiers="Language-en-us" src="C:\Users\alias\Desktop\repro\app4\project\en-us\resources.resw" type="String">
      <value>value1</value>
    </instance>
  </package>
  <package filename="german.pri">
    <instance itemname="resources\string2" qualifiers="Language-de-de" src="C:\Users\alias\Desktop\repro\app4\project\de-de\resources.resw" type="String">
      <value>value2</value>
    </instance>
    <instance itemname="resources\string1" qualifiers="Language-de-de" src="C:\Users\alias\Desktop\repro\app4\project\de-de\resources.resw" type="String">
      <value>value1</value>
    </instance>
  </package>
  <package filename="highresolution.pri">
    <instance itemname="Files\logo.jpg" qualifiers="Scale-200" src="" type="Path">
      <value>logo.scale-200.jpg</value>
    </instance>
  </package>
</root>
```

## <a name="47indexfileif-option"></a>& #47;IndexFile(if) オプション

インデックス ファイルのオプション (/if) を、`dump`、`resourcepack`、`versioned` と共に使用して、入力 PRI ファイルを指定します。

`resourcepack` と `versioned` の場合、/IndexFile(if) の入力パラメーターとして PRI ファイルを指定する代わりに、スキーマ ファイルを指定できます。

```
/IndexFile(if) <FILEPATH>
```

**FILEPATH** は、入力 PRI ファイルまたは PRI スキーマ ファイルの場所を指定するトークンです。

## <a name="47mappingfilemf-option"></a>&#47;MappingFile(mf) オプション

マッピング ファイル オプション (/mf) を、`new`、`resourcepack`、`versioned` と共に使用して、マッピング ファイルを生成します。 [MakeAppx.exe](../packaging/create-app-package-with-makeappx-tool.md) は、マッピング ファイルを使ってアプリ パッケージを生成します。

```
/MappingFile(mf) <MAPPINGFILETYPE>
```

**MAPPINGFILETYPE** は、マッピング ファイルの形式を指定するトークンです。 サポートされる有効な形式は `appx` のみです。

```
/mf appx
```

これは、メインのマッピング ファイルの内容の例です。

```
"ResourceDimensions"                   "language-de-de"
```

また、これは、リソース パックのマッピング ファイルの内容の例です。

```
"ResourceId"                           "Resources184.la5decaf08"
"ResourceDimensions"                   "language-de-de"
```

## <a name="output-summary"></a>出力の概要

リソース パックが作成される場合、MakePRI.exe からの出力の概要は、より詳細な形式です。 次に例を示します。

```
Index Pass Completed: ResourcePackTests\TestApp_ResourcePack
Language Qualifiers: fr-FR, de-DE

Finished building
Version: 1.0
Resource Map Name: AppTest
Named Resources: 11

Resource PRI: fr-FR.pri
Version: 1.0
Resource Candidates: 4
Language: fr-FR

Resource PRI: de-DE.pri
Version: 1.0
Resource Candidates: 4
Language: de-DE

Output File(s) at TempTestResults
Successfully Completed
```

## <a name="47overwriteo-option"></a>&#47;Overwrite(o) オプション

上書きオプション (/o) が指定されておらず、指定した出力ファイルが既に存在する場合、MakePri.exe は上書きする前に確認を求めます。

```
Following file(s) already exist at output location:
<file(s)>
Overwrite these file(s)? [Y]es (any other key to cancel):
```

## <a name="47outputfileof-option"></a>&#47;OutputFile(of) オプション

出力ファイル オプション (/of) を、`dump`、`new`、`resourcepack`、`versioned` と共に使用して、出力場所と生成される PRI ファイルの名前を指定します。 MakePri.exe で複数のリソース PRI ファイルを生成する場合、ファイルはターゲット ファイルの親フォルダーに格納されます。 たとえば、`/of MyParentFolder\TargetFile.pri` を指定した場合、MakePri.exe は `TargetFile.language-en.pri` と `TargetFile.scale-100.pri` を、`TargetFile.pri` と共に、`ParentFolder` に生成します。

エラー状況の例と対応するエラー メッセージを次に示します。

| エラー状況 | エラー メッセージ |
| --------------- | ------------- |
| 構成に含まれるリソース パック名の 1 つと同じ出力ファイル名が指定された。 | 無効な構成: リソース パック名 <resource pack name> を出力ファイル <outputfilename.pri> と同じにすることはできません。 |

## <a name="reversemaprm-option"></a>/ReverseMap(rm) オプション

逆マップ オプション (/rm) を、`new`、`resourcepack`、`versioned` と共に使用して、PRI ファイルに逆マッピング セクションを生成し、デバッグに利用できるようになりました。

## <a name="47schemafilesf-option"></a>&#47;SchemaFile(sf) オプション

スキーマ ファイル オプション (/sf) を、`new`、`resourcepack`、`versioned` と共に使用して、指定された場所にスキーマ ファイルを書き込みます。

`resourcepack` と `versioned` の場合、/IndexFile(if) の入力パラメーターとして PRI ファイルを指定する代わりに、スキーマ ファイルを指定できます。

```
/SchemaFile(sf) <FILEPATH>
```

**FILEPATH** は、スキーマ ファイルを書き込む場所を指定するトークンです。

スキーマ ファイルの例を次に示します。

```xml
<PriInfo>
    <ResourceMap name="IndexName" resourceVersion="1.0"> 
        <ResourceMapSubtree name="Resources" index="1">
            <NamedResource name="String1" index="1"/>
            <NamedResource name="String2" index="1"/>
        </ResourceMapSubtree>
        <ResourceMapSubtree name="Files" index="2">
            <NamedResource name="logo.png" index="2"/>
            <ResourceMapSubtree name="images" index="3">
                <NamedResource name="success.png" index="3"/>
                <NamedResource name="error.png" index="3"/>
            </ResourceMapSubtree>
        </ResourceMapSubtree>
    </ResourceMap>
</PriInfo>
```

## <a name="47versionmajorvma-is-deprecated"></a>&#47;VersionMajor(vma) は非推奨

メジャー バージョン (/vma) オプション (`new` コマンド用) は推奨されなくなり、これを使用すると次の警告メッセージが表示されます。

```
'VersionMajor (vma)' input parameter has been deprecated. Please specify major version in the configuration file using 'majorVersion' attribute on 'resources' node.
```

メジャー バージョン番号を指定するには、構成ファイルで [resources@majorVersion](makepri-exe-configuration.md) 属性を使用します。

## <a name="related-topics"></a>関連トピック

* [MakePri.exe](compile-resources-manually-with-makepri.md)
