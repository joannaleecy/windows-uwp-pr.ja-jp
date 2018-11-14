---
author: stevewhims
Description: MakePri.exe has the set of commands createconfig, dump, new, resourcepack, and versioned. This topic details their use.
title: MakePri.exe のコマンド ライン オプション
template: detail.hbs
ms.author: stwhi
ms.date: 04/10/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: c777996dceeb443c25fcf526e3a029fca00047c1
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6279825"
---
# <a name="makepriexe-command-line-options"></a><span data-ttu-id="8d5f7-103">MakePri.exe のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-103">MakePri.exe command-line options</span></span>

<span data-ttu-id="8d5f7-104">[MakePri.exe](compile-resources-manually-with-makepri.md) には、`createconfig`、`dump`、`new`、`resourcepack`、`versioned` コマンドのセットが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-104">[MakePri.exe](compile-resources-manually-with-makepri.md) has the set of commands `createconfig`, `dump`, `new`, `resourcepack`, and `versioned`.</span></span> <span data-ttu-id="8d5f7-105">このトピックでは、コマンド ライン オプションの使用について説明します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-105">This topic details the command-line options for their use.</span></span>

> [!NOTE]
> <span data-ttu-id="8d5f7-106">MakePri.exe は、Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションを確認する場合にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-106">MakePri.exe is installed when you check the **Windows SDK for UWP Managed Apps** option while installing the Windows Software Development Kit.</span></span> <span data-ttu-id="8d5f7-107">パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダーの)。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-107">It is installed to the path `%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe` (as well as in folders named for the other architectures).</span></span> <span data-ttu-id="8d5f7-108">たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-108">For example, `C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe`.</span></span>

## <a name="getting-help-from-the-command-line"></a><span data-ttu-id="8d5f7-109">コマンドラインからヘルプを取得します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-109">Getting help from the command-line</span></span>

<span data-ttu-id="8d5f7-110">実行できる`MakePri.exe help`または`MakePri.exe /?`MakePri.exe を使用して使用できるコマンドを表示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-110">You can run `MakePri.exe help` or `MakePri.exe /?` to see the commands that you can use with MakePri.exe.</span></span> <span data-ttu-id="8d5f7-111">発行することもできます`MakePri.exe <command> /?`コマンドについてと、非常にまれなケースで詳細を表示する場合でも`MakePri.exe <command> <option>`オプションの詳細を確認します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-111">You can also issue `MakePri.exe <command> /?` to see specifics about a command and, in very rare cases, even `MakePri.exe <command> <option>` to see specifics about an option.</span></span>

## <a name="makepri-commands"></a><span data-ttu-id="8d5f7-112">MakePri のコマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-112">MakePri commands</span></span>

```console
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

## <a name="createconfig-command"></a><span data-ttu-id="8d5f7-113">Createconfig コマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-113">Createconfig command</span></span>

<span data-ttu-id="8d5f7-114">`createconfig` コマンドは、指定した修飾子の既定値を定義する、新しい、初期化された PRI 構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-114">The `createconfig` command creates a new, initialized PRI config file defining the qualifier defaults that you specify.</span></span> <span data-ttu-id="8d5f7-115">`MakePri.exe createconfig /?` を実行すると、このコマンドの詳しいヘルプが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-115">Run `MakePri.exe createconfig /?` to see detailed help for this command.</span></span>

```console
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

## <a name="dump-command"></a><span data-ttu-id="8d5f7-116">Dump コマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-116">Dump command</span></span>

<span data-ttu-id="8d5f7-117">`dump` コマンドは、指定された PRI ファイル内のすべてのリソースの一覧を含む、ダンプされた xml ファイルを出力します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-117">The `dump` command outputs a dumped xml file containing a list of all resources in a specified PRI file.</span></span> <span data-ttu-id="8d5f7-118">`MakePri.exe dump /?` を実行すると、このコマンドの詳しいヘルプが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-118">Run `MakePri.exe dump /?` to see detailed help for this command.</span></span>

> [!NOTE]
> <span data-ttu-id="8d5f7-119">スキーマのないリソース パックは、PRI 構成ファイルで *omitSchemaFromResourcePacks* スイッチを使用して作成されたものです。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-119">A schema-free resource pack is one that was created with the *omitSchemaFromResourcePacks* switch in the PRI config file.</span></span> <span data-ttu-id="8d5f7-120">スキーマのないリソース パックを出力するには、`/es <main_package_PRI_file>` スイッチを使用します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-120">To dump a schema-free resource pack, use the switch `/es <main_package_PRI_file>`.</span></span> <span data-ttu-id="8d5f7-121">メイン ファイルを指定しない場合、"*The resources.pri in the package was corrupted so encryption failed (error PRI222: 0xdef0000f - Unspecified error occurred)*" (パッケージ内の resources.pri が破損していたため、暗号化できませんでした (エラー PRI222: 0xdef0000f - 特定できないエラーが発生しました)。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-121">If you don't specify the main file then you'll see the error message "*The resources.pri in the package was corrupted so encryption failed (error PRI222: 0xdef0000f - Unspecified error occurred)*".</span></span>

```console
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

## <a name="new-command"></a><span data-ttu-id="8d5f7-122">New コマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-122">New command</span></span>

<span data-ttu-id="8d5f7-123">`new` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、新しい PRI ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-123">The `new` command creates a new PRI file by indexing the files in your project as directed by your configuration file.</span></span> <span data-ttu-id="8d5f7-124">`MakePri.exe new /?` を実行すると、このコマンドの詳しいヘルプが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-124">Run `MakePri.exe new /?` to see detailed help for this command.</span></span>

```console
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

## <a name="resourcepack-command"></a><span data-ttu-id="8d5f7-125">ResourcePack コマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-125">ResourcePack command</span></span>

<span data-ttu-id="8d5f7-126">`resourcepack` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、新しい PRI ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-126">The `resourcepack` command creates a new PRI file by indexing the files in your project as directed by your configuration file.</span></span> <span data-ttu-id="8d5f7-127">リソース パック PRI ファイルには、既存の PRI ファイルで既に指定されているリソースの追加バリエーションのみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-127">A resource pack PRI file contains only additional variants of resources already specified in an existing PRI file.</span></span> <span data-ttu-id="8d5f7-128">`MakePri.exe resourcepack /?` を実行すると、このコマンドの詳しいヘルプが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-128">Run `MakePri.exe resourcepack /?` to see detailed help for this command.</span></span>

```console
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

## <a name="versioned-command"></a><span data-ttu-id="8d5f7-129">Versioned コマンド</span><span class="sxs-lookup"><span data-stu-id="8d5f7-129">Versioned command</span></span>

<span data-ttu-id="8d5f7-130">`versioned` コマンドは、構成ファイルの指示に従ってプロジェクト内のファイルのインデックスを作成することにより、バージョン管理された PRI ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-130">The `versioned` command creates a versioned PRI file by indexing the files in your project as directed by your configuration file.</span></span> <span data-ttu-id="8d5f7-131">`MakePri.exe versioned /?` を実行すると、このコマンドの詳しいヘルプが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-131">Run `MakePri.exe versioned /?` to see detailed help for this command.</span></span>

```console
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

## <a name="47extensiondllex"></a><span data-ttu-id="8d5f7-132">&#47;ExtensionDll(ex)</span><span class="sxs-lookup"><span data-stu-id="8d5f7-132">&#47;ExtensionDll(ex)</span></span>

<span data-ttu-id="8d5f7-133">拡張 DLL オプション (/ex) を `createconfig`、`dump`、`new`、`resourcepack`、`versioned` と共に使用して、リソース管理システム環境拡張 DLL の場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-133">You use the extension DLL option (/ex) with `createconfig`, `dump`, `new`, `resourcepack`, and `versioned` to specify the location of the Resource Management System environment extension DLL.</span></span>

## <a name="logging47metadata-file"></a><span data-ttu-id="8d5f7-134">ログ記録&#47;メタデータ ファイル</span><span class="sxs-lookup"><span data-stu-id="8d5f7-134">Logging&#47;metadata file</span></span>

<span data-ttu-id="8d5f7-135">MakePri は、インデクサーのメタデータ ファイルにリソース パックに固有の情報を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-135">MakePri can include info specific to a resource pack in the indexer metadata file.</span></span> <span data-ttu-id="8d5f7-136">`resources.pri` のログ ファイルと、リソース PRI ファイル `german.pri` と `highresolution.pri` の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-136">Here is an example of a log file for `resources.pri` with resource PRI files `german.pri` and `highresolution.pri`.</span></span>

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

## <a name="47indexfileif-option"></a><span data-ttu-id="8d5f7-137">& #47;IndexFile(if) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-137">&#47;IndexFile(if) option</span></span>

<span data-ttu-id="8d5f7-138">インデックス ファイルのオプション (/if) を、`dump`、`resourcepack`、`versioned` と共に使用して、入力 PRI ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-138">You use the index file option (/if) with `dump`, `resourcepack`, and `versioned` to specify an input PRI file.</span></span>

<span data-ttu-id="8d5f7-139">`resourcepack` と `versioned` の場合、/IndexFile(if) の入力パラメーターとして PRI ファイルを指定する代わりに、スキーマ ファイルを指定できます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-139">For `resourcepack` and `versioned`, instead of providing a PRI file as the input parameter for /IndexFile(if), you can instead provide a schema file.</span></span>

```console
/IndexFile(if) <FILEPATH>
```

<span data-ttu-id="8d5f7-140">**FILEPATH** は、入力 PRI ファイルまたは PRI スキーマ ファイルの場所を指定するトークンです。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-140">**FILEPATH** is a token that that specifies the location of the input PRI file or PRI schema file.</span></span>

## <a name="47indexoptionsio-option"></a><span data-ttu-id="8d5f7-141">& #47;IndexOptions(io) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-141">&#47;IndexOptions(io) option</span></span>

<span data-ttu-id="8d5f7-142">インデックスのオプションを使用する (/io) で`new`、 `resourcepack`、および`versioned`リソース インデクサーの動作の詳細に制御を提供するオプションを指定します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-142">You use the index options option (/io) with `new`, `resourcepack`, and `versioned` to specify options that provide detailed control over the behavior of resource indexers.</span></span> <span data-ttu-id="8d5f7-143">既定では、インデックスのオプションが無効になります。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-143">Index options are disabled by default.</span></span>

```console
/IndexOptions(io) <OPTIONS>
```

<span data-ttu-id="8d5f7-144">**オプション**では、次のオプションの構成、コンマ区切りの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-144">**OPTIONS** is a comma-separated list comprised of the following options.</span></span>

- <span data-ttu-id="8d5f7-145">HiddenFiles(hf) +/。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-145">+/-HiddenFiles(hf).</span></span> <span data-ttu-id="8d5f7-146">インデックス (+) または (-) を無視するファイルとフォルダーの非表示になります。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-146">Index (+) or ignore (-) hidden files and folders.</span></span>
- <span data-ttu-id="8d5f7-147">LinkedFiles(lf) +/。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-147">+/-LinkedFiles(lf).</span></span> <span data-ttu-id="8d5f7-148">インデックス (+) または (-) を無視するファイルやフォルダーをリンクします。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-148">Index (+) or ignore (-) linked files and folders.</span></span>

## <a name="47mappingfilemf-option"></a><span data-ttu-id="8d5f7-149">&#47;MappingFile(mf) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-149">&#47;MappingFile(mf) option</span></span>

<span data-ttu-id="8d5f7-150">マッピング ファイル オプション (/mf) を、`new`、`resourcepack`、`versioned` と共に使用して、マッピング ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-150">You use the mapping file option (/mf) with `new`, `resourcepack`, and `versioned` to generate a mapping file.</span></span> <span data-ttu-id="8d5f7-151">[MakeAppx.exe](../packaging/create-app-package-with-makeappx-tool.md) は、マッピング ファイルを使ってアプリ パッケージを生成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-151">[MakeAppx.exe](../packaging/create-app-package-with-makeappx-tool.md) uses the mapping file to generate app packages.</span></span>

```console
/MappingFile(mf) <MAPPINGFILETYPE>
```

<span data-ttu-id="8d5f7-152">**MAPPINGFILETYPE** は、マッピング ファイルの形式を指定するトークンです。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-152">**MAPPINGFILETYPE** is a token that specifies the format of the mapping file.</span></span> <span data-ttu-id="8d5f7-153">サポートされる有効な形式は `appx` のみです。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-153">The only valid supported format is `appx`.</span></span>

```console
/mf appx
```

<span data-ttu-id="8d5f7-154">これは、メインのマッピング ファイルの内容の例です。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-154">This is an example contents of a main mapping file.</span></span>

```console
"ResourceDimensions"                   "language-de-de"
```

<span data-ttu-id="8d5f7-155">また、これは、リソース パックのマッピング ファイルの内容の例です。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-155">And this is an example contents of a resource pack mapping file.</span></span>

```console
"ResourceId"                           "Resources184.la5decaf08"
"ResourceDimensions"                   "language-de-de"
```

## <a name="output-summary"></a><span data-ttu-id="8d5f7-156">出力の概要</span><span class="sxs-lookup"><span data-stu-id="8d5f7-156">Output summary</span></span>

<span data-ttu-id="8d5f7-157">リソース パックが作成される場合、MakePRI.exe からの出力の概要は、より詳細な形式です。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-157">If resource packs are created, the output summary from MakePRI.exe is of more verbose form.</span></span> <span data-ttu-id="8d5f7-158">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-158">Here's an example.</span></span>

```console
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

## <a name="47overwriteo-option"></a><span data-ttu-id="8d5f7-159">&#47;Overwrite(o) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-159">&#47;Overwrite(o) option</span></span>

<span data-ttu-id="8d5f7-160">上書きオプション (/o) が指定されておらず、指定した出力ファイルが既に存在する場合、MakePri.exe は上書きする前に確認を求めます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-160">If the over-write option (/o) is not provided, and the specified output file(s) already exist(s), then MakePri.exe requires a confirmation before overwriting.</span></span>

```console
Following file(s) already exist at output location:
<file(s)>
Overwrite these file(s)? [Y]es (any other key to cancel):
```

## <a name="47outputfileof-option"></a><span data-ttu-id="8d5f7-161">&#47;OutputFile(of) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-161">&#47;OutputFile(of) option</span></span>

<span data-ttu-id="8d5f7-162">出力ファイル オプション (/of) を、`dump`、`new`、`resourcepack`、`versioned` と共に使用して、出力場所と生成される PRI ファイルの名前を指定します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-162">You use the output file option (/of) with `dump`, `new`, `resourcepack`, and `versioned` to specify the output location and name of the PRI file to be generated.</span></span> <span data-ttu-id="8d5f7-163">MakePri.exe で複数のリソース PRI ファイルを生成する場合、ファイルはターゲット ファイルの親フォルダーに格納されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-163">If MakePri.exe generates more than one resource PRI file, it places them in the parent folder of the target file.</span></span> <span data-ttu-id="8d5f7-164">たとえば、`/of MyParentFolder\TargetFile.pri` を指定した場合、MakePri.exe は `TargetFile.language-en.pri` と `TargetFile.scale-100.pri` を、`TargetFile.pri` と共に、`ParentFolder` に生成します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-164">For example, if you specify `/of MyParentFolder\TargetFile.pri` then MakePri.exe generates `TargetFile.language-en.pri` and `TargetFile.scale-100.pri` alongside `TargetFile.pri` under `ParentFolder`.</span></span>

<span data-ttu-id="8d5f7-165">エラー状況の例と対応するエラー メッセージを次に示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-165">Here is an example error condition and the corresponding error message.</span></span>

| <span data-ttu-id="8d5f7-166">エラー状況</span><span class="sxs-lookup"><span data-stu-id="8d5f7-166">Error condition</span></span> | <span data-ttu-id="8d5f7-167">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="8d5f7-167">Error message</span></span> |
| --------------- | ------------- |
| <span data-ttu-id="8d5f7-168">構成に含まれるリソース パック名の 1 つと同じ出力ファイル名が指定された。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-168">The output file name is the same as one of the resource pack names in the configuration.</span></span> | <span data-ttu-id="8d5f7-169">無効な構成: リソース パック名 <resource pack name> を出力ファイル <outputfilename.pri> と同じにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-169">Invalid Configuration: Resource Pack name <resource pack name> cannot be the same as the output file <outputfilename.pri>.</span></span> |

## <a name="reversemaprm-option"></a><span data-ttu-id="8d5f7-170">/ReverseMap(rm) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-170">/ReverseMap(rm) option</span></span>

<span data-ttu-id="8d5f7-171">逆マップ オプション (/rm) を、`new`、`resourcepack`、`versioned` と共に使用して、PRI ファイルに逆マッピング セクションを生成し、デバッグに利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-171">You use the reverse map option (/rm) with `new`, `resourcepack`, and `versioned` to generate a reverse-mapping section in the PRI file, which can be used for debugging.</span></span>

## <a name="47schemafilesf-option"></a><span data-ttu-id="8d5f7-172">&#47;SchemaFile(sf) オプション</span><span class="sxs-lookup"><span data-stu-id="8d5f7-172">&#47;SchemaFile(sf) option</span></span>

<span data-ttu-id="8d5f7-173">スキーマ ファイル オプション (/sf) を、`new`、`resourcepack`、`versioned` と共に使用して、指定された場所にスキーマ ファイルを書き込みます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-173">You use the schema file option (/sf) with `new`, `resourcepack`, and `versioned` to write a schema file at the specified location.</span></span>

<span data-ttu-id="8d5f7-174">`resourcepack` と `versioned` の場合、/IndexFile(if) の入力パラメーターとして PRI ファイルを指定する代わりに、スキーマ ファイルを指定できます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-174">For `resourcepack` and `versioned`, instead of providing a PRI file as the input parameter for /IndexFile(if), you can instead provide a schema file.</span></span>

```console
/SchemaFile(sf) <FILEPATH>
```

<span data-ttu-id="8d5f7-175">**FILEPATH** は、スキーマ ファイルを書き込む場所を指定するトークンです。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-175">**FILEPATH** is a token that that specifies where to write the schema file.</span></span>

<span data-ttu-id="8d5f7-176">スキーマ ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-176">This is an example of a schema file.</span></span>

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

## <a name="47versionmajorvma-is-deprecated"></a><span data-ttu-id="8d5f7-177">&#47;VersionMajor(vma) は非推奨</span><span class="sxs-lookup"><span data-stu-id="8d5f7-177">&#47;VersionMajor(vma) is deprecated</span></span>

<span data-ttu-id="8d5f7-178">メジャー バージョン (/vma) オプション (`new` コマンド用) は推奨されなくなり、これを使用すると次の警告メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-178">The major version (/vma) option (for the `new` command) is deprecated, and using it results in this warning message.</span></span>

```console
'VersionMajor (vma)' input parameter has been deprecated. Please specify major version in the configuration file using 'majorVersion' attribute on 'resources' node.
```

<span data-ttu-id="8d5f7-179">メジャー バージョン番号を指定するには、構成ファイルで [resources@majorVersion](makepri-exe-configuration.md) 属性を使用します。</span><span class="sxs-lookup"><span data-stu-id="8d5f7-179">To provide the major version number, use the [resources@majorVersion](makepri-exe-configuration.md) attribute in your configuration file.</span></span>

## <a name="related-topics"></a><span data-ttu-id="8d5f7-180">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8d5f7-180">Related topics</span></span>

* [<span data-ttu-id="8d5f7-181">MakePri.exe</span><span class="sxs-lookup"><span data-stu-id="8d5f7-181">MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
