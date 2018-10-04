---
author: stevewhims
Description: This topic describes the format-specific indexers used by the MakePri.exe tool to generate its index of resources.
title: MakePri.exe の形式に固有のインデクサー
template: detail.hbs
ms.author: stwhi
ms.date: 10/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 8ec6b2a31f4f577de30dac1c96a411c6aee6e9dc
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4352351"
---
# <a name="makepriexe-format-specific-indexers"></a><span data-ttu-id="0bb9e-103">MakePri.exe の形式に固有のインデクサー</span><span class="sxs-lookup"><span data-stu-id="0bb9e-103">MakePri.exe format-specific indexers</span></span>

<span data-ttu-id="0bb9e-104">このトピックでは、リソースのインデックスを生成するために [MakePri.exe](compile-resources-manually-with-makepri.md) ツールによって使われる形式に固有のインデクサーについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-104">This topic describes the format-specific indexers used by the [MakePri.exe](compile-resources-manually-with-makepri.md) tool to generate its index of resources.</span></span>

> [!NOTE]
> <span data-ttu-id="0bb9e-105">MakePri.exe は、Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションを確認する場合にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-105">MakePri.exe is installed when you check the **Windows SDK for UWP Managed Apps** option while installing the Windows Software Development Kit.</span></span> <span data-ttu-id="0bb9e-106">パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダー)。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-106">It is installed to the path `%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe` (as well as in folders named for the other architectures).</span></span> <span data-ttu-id="0bb9e-107">たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-107">For example, `C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe`.</span></span>

<span data-ttu-id="0bb9e-108">MakePri.exe は、通常、`new`、`versioned`、`resourcepack` コマンドと共に使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-108">MakePri.exe is typically used with the `new`, `versioned`, or `resourcepack` commands.</span></span> <span data-ttu-id="0bb9e-109">「[MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-109">See [MakePri.exe command-line options](makepri-exe-command-options.md).</span></span> <span data-ttu-id="0bb9e-110">これらのオプションを使うと、ソース ファイルがインデックス化され、リソースのインデックスが生成されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-110">In those cases it indexes source files to generate an index of resources.</span></span> <span data-ttu-id="0bb9e-111">MakePri.exe は、さまざまな別個のインデクサーを使って異なるソース リソース ファイルまたはリソースのコンテナーを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-111">MakePri.exe uses various individual indexers to read different source resource files or containers for resources.</span></span> <span data-ttu-id="0bb9e-112">最も単純なインデクサーは、`.jpg` 画像 や `.png` 画像などのフォルダーの内容をインデックス化するフォルダー インデクサーです。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-112">The simplest indexer is the folder indexer, which indexes the contents of a folder, such as `.jpg` or `.png` images.</span></span>

<span data-ttu-id="0bb9e-113">形式に固有のインデクサーは、[MakePri.exe 構成ファイル](makepri-exe-configuration.md)の `<index>` 要素内で `<indexer-config>` 要素を指定することによって識別します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-113">You identify format-specific indexers by specifying `<indexer-config>` elements within an `<index>` element of the [MakePri.exe configuration file](makepri-exe-configuration.md).</span></span> <span data-ttu-id="0bb9e-114">`type` 属性は、使われる形式に固有のインデクサーを識別します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-114">The `type` attribute identifies the format-specific indexer that is used.</span></span>

<span data-ttu-id="0bb9e-115">インデックス化の処理中にリソース コンテナーが検出されると、その内容がインデックス化されます (コンテナー自体はインデックスに追加されません)。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-115">Resource containers encountered during indexing usually get their contents indexed rather than being added to the index themselves.</span></span> <span data-ttu-id="0bb9e-116">たとえば、フォルダー インデクサーによって検出された `.resjson` ファイルは `.resjson` インデクサーによってインデックス化されます。このとき、`.resjson` ファイル自体はインデックスに表示されません。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-116">For example, `.resjson` files that the folder indexer finds may be further indexed by a `.resjson` indexer, in which case the `.resjson` file itself does not appear in the index.</span></span> <span data-ttu-id="0bb9e-117">**注** こうした状態になるには、そのコンテナーに関連付けられたインデクサーの `<indexer-config>` 要素が構成ファイルに記述されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-117">**Note** an `<indexer-config>` element for the indexer associated with that container must be included in the configuration file for that to happen.</span></span>

<span data-ttu-id="0bb9e-118">通常、フォルダーや `.resw` ファイルなどのコンテナー エンティティで検出された修飾子は、コンテナー エンティティ内のすべてのリソース (フォルダー内のファイルや `.resw` ファイル内の文字列など) に適用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-118">Typically, qualifiers found on a containing entity&mdash;such as a folder or a `.resw` file&mdash;are applied to all resources within it, such as the files within the folder, or the strings within the `.resw` file.</span></span>

## <a name="folder"></a><span data-ttu-id="0bb9e-119">フォルダー</span><span class="sxs-lookup"><span data-stu-id="0bb9e-119">Folder</span></span>

<span data-ttu-id="0bb9e-120">フォルダー インデクサーは、`type` 属性 FOLDER で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-120">The folder indexer is identified by a `type` attribute of FOLDER.</span></span> <span data-ttu-id="0bb9e-121">フォルダーの内容をインデックス化し、フォルダー名とファイル名からリソース修飾子を決定します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-121">It indexes the contents of a folder, and determines resource qualifiers from the folder and filenames.</span></span> <span data-ttu-id="0bb9e-122">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-122">Its configuration element conforms to the following schema.</span></span>

```xml
<xs:schema attributeFormDefault=\"unqualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">\
    <xs:simpleType name=\"ExclusionTypeList\">\
        <xs:restriction base=\"xs:string\">\
            <xs:enumeration value=\"path\"/>\
            <xs:enumeration value=\"extension\"/>\
            <xs:enumeration value=\"name\"/>\
            <xs:enumeration value=\"tree\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:complexType name=\"FolderExclusionType\">\
        <xs:attribute name=\"type\" type=\"ExclusionTypeList\" use=\"required\"/>\
        <xs:attribute name=\"value\" type=\"xs:string\" use=\"required\"/>\
        <xs:attribute name=\"doNotTraverse\" type=\"xs:boolean\" use=\"required\"/>\
        <xs:attribute name=\"doNotIndex\" type=\"xs:boolean\" use=\"required\"/>\
    </xs:complexType>\
    <xs:simpleType name=\"IndexerConfigFolderType\">\
        <xs:restriction base=\"xs:string\">\
            <xs:pattern value=\"((f|F)(o|O)(l|L)(d|D)(e|E)(r|R))\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:element name=\"indexer-config\">\
        <xs:complexType>\
            <xs:sequence>\
                <xs:element name=\"exclude\" type=\"FolderExclusionType\" minOccurs=\"0\" maxOccurs=\"unbounded\"/>\
            </xs:sequence>\
            <xs:attribute name=\"type\" type=\"IndexerConfigFolderType\" use=\"required\"/>\
            <xs:attribute name=\"foldernameAsQualifier\" type=\"xs:boolean\" use=\"required\"/>\
            <xs:attribute name=\"filenameAsQualifier\" type=\"xs:boolean\" use=\"required\"/>\
            <xs:attribute name=\"qualifierDelimiter\" type=\"xs:string\" use=\"required\"/>\
        </xs:complexType>\
    </xs:element>\
</xs:schema>
```

<span data-ttu-id="0bb9e-123">`qualifierDelimiter` 属性は、拡張子を除いてファイル名に指定される修飾子の前の文字を指定します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-123">The `qualifierDelimiter` attribute specifies the character after which qualifiers are specified in a filename, ignoring the extension.</span></span> <span data-ttu-id="0bb9e-124">既定値は "." です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-124">The default is ".".</span></span>

## <a name="pri"></a><span data-ttu-id="0bb9e-125">PRI</span><span class="sxs-lookup"><span data-stu-id="0bb9e-125">PRI</span></span>

<span data-ttu-id="0bb9e-126">PRI インデクサーは、`type` 属性 PRI で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-126">The PRI indexer is identified by a `type` attribute of PRI.</span></span> <span data-ttu-id="0bb9e-127">PRI ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-127">It indexes the contents of a PRI file.</span></span> <span data-ttu-id="0bb9e-128">通常、別のアセンブリ、DLL、SDK、またはクラス ライブラリ内に格納されたリソースをアプリの PRI にインデックス化する場合にこのインデクサーを使います。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-128">You typically use it when indexing the resource contained within another assembly, DLL, SDK, or class library into the app's PRI.</span></span>

<span data-ttu-id="0bb9e-129">PRI ファイルに含まれるすべてのリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-129">All resource names, qualifiers and values contained in the PRI file are directly maintained in the new PRI file.</span></span> <span data-ttu-id="0bb9e-130">ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-130">The top level resource map, however is not maintained in the final PRI.</span></span> <span data-ttu-id="0bb9e-131">リソース マップはマージされます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-131">Resource Maps are merged.</span></span>

```xml
<xs:schema id=\"prifile\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\">\
    <xs:simpleType name=\"IndexerConfigPriType\">\
        <xs:restriction base=\"xs:string\">\
            <xs:pattern value=\"((p|P)(r|R)(i|I))\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:element name=\"indexer-config\">\
        <xs:complexType>\
            <xs:attribute name=\"type\" type=\"IndexerConfigPriType\" use=\"required\"/>\
        </xs:complexType>\
    </xs:element>\
</xs:schema>\
```

## <a name="priinfo"></a><span data-ttu-id="0bb9e-132">PriInfo</span><span class="sxs-lookup"><span data-stu-id="0bb9e-132">PriInfo</span></span>

<span data-ttu-id="0bb9e-133">PriInfo インデクサーは、`type` 属性 PRIINFO で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-133">The PriInfo indexer is identified by a `type` attribute of PRIINFO.</span></span> <span data-ttu-id="0bb9e-134">詳細ダンプ ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-134">It indexes the contents of a detailed dump file.</span></span> <span data-ttu-id="0bb9e-135">詳細なダンプ ファイルを生成するには、`/dt detailed` オプションを指定して `makepri dump` を実行します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-135">You produce a detailed dump file by running `makepri dump` with the `/dt detailed` option.</span></span> <span data-ttu-id="0bb9e-136">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-136">The configuration element for the indexer conforms to the following schema.</span></span>

```xml
<xs:schema id="priinfo" xmlns:xs="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified">
  <xs:simpleType name="IndexerConfigPriInfoType">
    <xs:restriction base="xs:string">
      <xs:pattern value="((p|P)(r|R)(i|I)(i|I)(n|N)(f|F)(o|O))"/>
    </xs:restriction>
  </xs:simpleType>
  <xs:element name="indexer-config">
    <xs:complexType>
      <xs:attribute name="type" type="IndexerConfigPriInfoType" use="required"/>
      <xs:attribute name="emitStrings" type="xs:boolean" use="optional"/>
      <xs:attribute name="emitPaths" type="xs:boolean" use="optional"/>
    </xs:complexType>
  </xs:element>
</xs:schema>
```

<span data-ttu-id="0bb9e-137">この構成要素では、オプションの属性を使って、PriInfo インデクサーの動作を構成できます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-137">This configuration element allows for optional attributes to configure the behavior of the PriInfo indexer.</span></span> <span data-ttu-id="0bb9e-138">`emitStrings` と `emitPaths` の既定値は `true` です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-138">The default value of `emitStrings` and `emitPaths` is `true`.</span></span> <span data-ttu-id="0bb9e-139">`emitStrings` が `true` である場合、`type` 属性が "String" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-139">If `emitStrings` is `true` then resource candidates with the `type` attribute set to "String" are be included in the index, otherwise they are excluded.</span></span> <span data-ttu-id="0bb9e-140">'emitPaths' が `true` である場合、`type` 属性が "Path" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-140">If 'emitPaths' is `true` then resource candidates with the `type` attribute set to "Path" are included in the index, otherwise they are excluded.</span></span>

<span data-ttu-id="0bb9e-141">次に示す構成例では、種類が String のリソースを含める一方で Path のリソースをスキップしています。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-141">Here is an example configuration that includes String resource types but skips Path resource types.</span></span>

```xml
<indexer-config type="priinfo" emitStrings="true" emitPaths="false" />
```

<span data-ttu-id="0bb9e-142">インデックス化する場合、ダンプ ファイルは拡張子 `.pri.xml` で終了し、次のスキーマに準拠する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-142">To be indexed, a dump file must end with the extension `.pri.xml`, and must conform to the following schema.</span></span>

```xml
<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified" >\
  <xs:simpleType name="candidateType">\
    <xs:restriction base="xs:string">\
      <xs:pattern value="Path|String"/>\
    </xs:restriction>\
  </xs:simpleType>\
  <xs:complexType name="scopeType">\
    <xs:sequence>\
      <xs:element name="ResourceMapSubtree" type="scopeType" minOccurs="0" maxOccurs="unbounded"/>\
      <xs:element name="NamedResource" minOccurs="0" maxOccurs="unbounded">\
        <xs:complexType>\
          <xs:sequence>\
            <xs:element name="Decision" minOccurs="0" maxOccurs="unbounded">\
              <xs:complexType>\
                <xs:sequence>\
                  <xs:any processContents="skip" minOccurs="0" maxOccurs="unbounded"/>\
                </xs:sequence>\
                <xs:anyAttribute processContents="skip" />\
              </xs:complexType>\
            </xs:element>\
            <xs:element name="Candidate" minOccurs="0" maxOccurs="unbounded">\
              <xs:complexType>\
                <xs:sequence>\
                  <xs:element name="QualifierSet" minOccurs="0" maxOccurs="unbounded">\
                    <xs:complexType>\
                      <xs:sequence>\
                        <xs:element name="Qualifier" minOccurs="0" maxOccurs="unbounded">\
                          <xs:complexType>\
                            <xs:attribute name="name" type="xs:string" use="required" />\
                            <xs:attribute name="value" type="xs:string" use="required" />\
                            <xs:attribute name="priority" type="xs:integer" use="required" />\
                            <xs:attribute name="scoreAsDefault" type="xs:decimal" use="required" />\
                            <xs:attribute name="index" type="xs:integer" use="required" />\
                          </xs:complexType>\
                        </xs:element>\
                      </xs:sequence>\
                      <xs:anyAttribute processContents="skip" />\
                    </xs:complexType>\
                  </xs:element>\
                  <xs:element name="Value" type="xs:string"  minOccurs="0" maxOccurs="unbounded"/>\
                </xs:sequence>\
                <xs:attribute name="type" type="candidateType" use="required" />\
              </xs:complexType>\
            </xs:element>\
          </xs:sequence>\
          <xs:attribute name="name" use="required" type="xs:string" />\
          <xs:anyAttribute processContents="skip" />\
        </xs:complexType>\
      </xs:element>\
    </xs:sequence>\
    <xs:attribute name="name" use="required" type="xs:string" />\
    <xs:anyAttribute processContents="skip" />\
  </xs:complexType>\
  <xs:element name="PriInfo">\
    <xs:complexType>\
      <xs:sequence>\
        <xs:element name="PriHeader" >\
          <xs:complexType>\
            <xs:sequence>\
              <xs:any minOccurs ="0" maxOccurs="unbounded" processContents="skip" />\
            </xs:sequence>\
            <xs:anyAttribute processContents="skip" />\
          </xs:complexType>\
        </xs:element>\
        <xs:element name="QualifierInfo">\
          <xs:complexType>\
            <xs:sequence>\
              <xs:any minOccurs="0" maxOccurs="unbounded" processContents="skip" />\
            </xs:sequence>\
          </xs:complexType>\
        </xs:element>\
        <xs:element name="ResourceMap">\
          <xs:complexType>\
            <xs:sequence>\
              <xs:element name="VersionInfo">\
                <xs:complexType>\
                  <xs:anyAttribute processContents="skip" />\
                </xs:complexType>\
              </xs:element>\
              <xs:element minOccurs="0" maxOccurs="unbounded" name="ResourceMapSubtree" type="scopeType" />\
            </xs:sequence>\
            <xs:attribute name="name" type="xs:string" use="required" />\
            <xs:anyAttribute processContents="skip" />\
          </xs:complexType>\
        </xs:element>\
      </xs:sequence>\
    </xs:complexType>\
  </xs:element>\
</xs:schema>
```

<span data-ttu-id="0bb9e-143">MakePri.exe では、'Basic'、'Detailed'、'Schema'、'Summary' のダンプの種類がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-143">MakePri.exe supports dump types 'Basic', 'Detailed', 'Schema', and 'Summary'.</span></span> <span data-ttu-id="0bb9e-144">PriInfo インデクサーが読み取ることができる種類のダンプが生成されるように MakePri.exe を構成するには、`dump` コマンドを使うときに "/DumpType Detailed" を指定します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-144">To configure MakePri.exe to emit the dump type that the PriInfo indexer can read, include "/DumpType Detailed" when using the `dump` command.</span></span>

<span data-ttu-id="0bb9e-145">`.pri.xml` ファイルのいくつかの要素は MakePri.exe でスキップされます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-145">Several elements of the `.pri.xml` file are skipped by MakePri.exe.</span></span> <span data-ttu-id="0bb9e-146">これらの要素は、インデックスの作成中に計算されるか、MakePri.exe 構成ファイル内で指定されています。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-146">These elements are either computed during indexing, or are specified in the MakePri.exe configuration file.</span></span> <span data-ttu-id="0bb9e-147">ダンプ ファイルに含まれるリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-147">Resource names, qualifiers, and values that are contained within the dump file are directly maintained in the new PRI file.</span></span> <span data-ttu-id="0bb9e-148">ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-148">The top-level resource map, however, is not maintained in the final PRI.</span></span> <span data-ttu-id="0bb9e-149">リソース マップは、インデックス化の一部としてマージされます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-149">Resource Maps are merged as part of the indexing.</span></span>

<span data-ttu-id="0bb9e-150">これは、ダンプ ファイルの有効な String 型リソースの例です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-150">This is an example of a valid String type resource from a dump file.</span></span>

```xml
<NamedResource name="SampleString " index="96" uri="ms-resource://SampleApp/resources/SampleString ">
  <Decision index="2">
    <QualifierSet index="1">
      <Qualifier name="Language" value="EN-US" priority="900" scoreAsDefault="1.0" index="1"/>
    </QualifierSet>
  </Decision>
  <Candidate type="String">
    <QualifierSet index="1">
      <Qualifier name="Language" value="EN-US" priority="900" scoreAsDefault="1.0" index="1"/>
    </QualifierSet>
    <Value>A Sample String Value</Value>
  </Candidate>
</NamedResource>
```

<span data-ttu-id="0bb9e-151">これは、ダンプ ファイルの、2 つの候補が含まれた有効な Path 型リソースの例です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-151">This is an example of a valid Path type resource with two candidates from a dump file.</span></span>

```xml
<NamedResource name="Sample.png" index="77" uri="ms-resource://SampleApp/Files/Images/Sample.png">
  <Decision index="2">
    <QualifierSet index="1">
      <Qualifier name="Scale" value="180" priority="500" scoreAsDefault="1.0" index="1"/>
    </QualifierSet>
    <QualifierSet index="2">
      <Qualifier name="Scale" value="140" priority="500" scoreAsDefault="0.7" index="2"/>
    </QualifierSet>
  </Decision>
  <Candidate type="Path">
    <QualifierSet index="1">
      <Qualifier name="Scale" value="180" priority="500" scoreAsDefault="1.0" index="1"/>
    </QualifierSet>
    <Value>Images\Sample.scale-180.png</Value>
  </Candidate>
  <Candidate type="Path">
    <QualifierSet index="2">
      <Qualifier name="Scale" value="140" priority="500" scoreAsDefault="1.0" index="1"/>
    </QualifierSet>
    <Value>Images\Sample.scale-140.png</Value>
  </Candidate>
</NamedResource>
```

## <a name="resfiles"></a><span data-ttu-id="0bb9e-152">ResFiles</span><span class="sxs-lookup"><span data-stu-id="0bb9e-152">ResFiles</span></span>

<span data-ttu-id="0bb9e-153">ResFiles インデクサーは、`type` 属性 RESFILES で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-153">The ResFiles indexer is identified by a `type` attribute of RESFILES.</span></span> <span data-ttu-id="0bb9e-154">`.resfiles` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-154">It indexes the contents of a `.resfiles` file.</span></span> <span data-ttu-id="0bb9e-155">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-155">Its configuration element conforms to the following schema.</span></span>

```xml
<xs:schema id=\"resx\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\">\
    <xs:simpleType name=\"IndexerConfigResFilesType\">\
        <xs:restriction base=\"xs:string\">\
            <xs:pattern value=\"((r|R)(e|E)(s|S)(f|F)(i|I)(l|L)(e|E)(s|S))\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:element name=\"indexer-config\">\
        <xs:complexType>\
            <xs:attribute name=\"type\" type=\"IndexerConfigResFilesType\" use=\"required\"/>\
            <xs:attribute name=\"qualifierDelimiter\" type=\"xs:string\" use=\"required\"/>\
        </xs:complexType>\
    </xs:element>\
</xs:schema>\
```

<span data-ttu-id="0bb9e-156">`.resfiles` ファイルは、ファイル パスのフラットな一覧が格納されたテキスト ファイルです。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-156">A `.resfiles` file is a text file containing a flat list of file paths.</span></span> <span data-ttu-id="0bb9e-157">`.resfiles` ファイルには、"//" コメントを格納できます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-157">A `.resfiles` file can contain "//" comments.</span></span> <span data-ttu-id="0bb9e-158">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-158">Here's an example.</span></span>

```
Strings\component1\fr\elements.resjson
Images\logo.scale-100.png
Images\logo.scale-140.png
Images\logo.scale-180.png
```

## <a name="resjson"></a><span data-ttu-id="0bb9e-159">ResJSON</span><span class="sxs-lookup"><span data-stu-id="0bb9e-159">ResJSON</span></span>

<span data-ttu-id="0bb9e-160">ResJSON インデクサーは、`type` 属性 RESJSON で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-160">The ResJSON indexer is identified by a `type` attribute of RESJSON.</span></span> <span data-ttu-id="0bb9e-161">文字列リソース ファイルである `.resjson` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-161">It indexes the contents of a `.resjson` file, which is a string resource file.</span></span> <span data-ttu-id="0bb9e-162">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-162">Its configuration element conforms to the following schema.</span></span>

```xml
<xs:schema id=\"resjson\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\">\
    <xs:simpleType name=\"IndexerConfigResJsonType\">\
        <xs:restriction base=\"xs:string\">\
            <xs:pattern value=\"((r|R)(e|E)(s|S)(j|J)(s|S)(o|O)(n|N))\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:element name=\"indexer-config\">\
        <xs:complexType>\
            <xs:attribute name=\"type\" type=\"IndexerConfigResJsonType\" use=\"required\"/>\
            <xs:attribute name=\"initialPath\" type=\"xs:string\" use=\"optional\"/>\
        </xs:complexType>\
    </xs:element>\
</xs:schema>\
```

<span data-ttu-id="0bb9e-163">`.resjson` ファイルは JSON テキストを格納します ([JavaScript Object Notation (JSON) の application/json メディア型に関するページ](http://www.ietf.org/rfc/rfc4627.txt)を参照)。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-163">A `.resjson` file contains JSON text (see [The application/json Media Type for JavaScript Object Notation (JSON)](http://www.ietf.org/rfc/rfc4627.txt)).</span></span> <span data-ttu-id="0bb9e-164">ファイルには、階層プロパティを持つ単一の JSON オブジェクトが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-164">The file must contain a single JSON object with hierarchical properties.</span></span> <span data-ttu-id="0bb9e-165">それぞれのプロパティは、別の JSON オブジェクトか、文字列値である必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-165">Each property must either be another JSON object or a string value.</span></span>

<span data-ttu-id="0bb9e-166">名前が下線 ("_") で始まる JSON プロパティは最終的な PRI ファイルにコンパイルされませんが、ログ ファイル内で保持されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-166">JSON properties with names that begin with an underscore ("_") are not compiled into the final PRI file, but are maintained in the log file.</span></span>

<span data-ttu-id="0bb9e-167">ファイルには "//" コメントを格納できます。これらのコメントは、解析時に無視されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-167">The file can also contain "//" comments which are ignored during parsing.</span></span>

<span data-ttu-id="0bb9e-168">`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-168">The `initialPath` attribute places all resources under this initial path by prepending it to the name of the resource.</span></span> <span data-ttu-id="0bb9e-169">通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-169">You would typically use this when indexing class library resources.</span></span> <span data-ttu-id="0bb9e-170">既定は空白です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-170">The default is blank.</span></span>

## <a name="resw"></a><span data-ttu-id="0bb9e-171">ResW</span><span class="sxs-lookup"><span data-stu-id="0bb9e-171">ResW</span></span>

<span data-ttu-id="0bb9e-172">ResW インデクサーは、`type` 属性 RESW で識別されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-172">The ResW indexer is identified by a `type` attribute of RESW.</span></span> <span data-ttu-id="0bb9e-173">文字列リソース ファイルである `.resw` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-173">It indexes the contents of a `.resw` file, which is a string resource file.</span></span> <span data-ttu-id="0bb9e-174">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-174">Its configuration element conforms to the following schema.</span></span>

```xml
<xs:schema id=\"resw\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\">\
    <xs:simpleType name=\"IndexerConfigResxType\">\
        <xs:restriction base=\"xs:string\">\
            <xs:pattern value=\"((r|R)(e|E)(s|S)(w|W))\"/>\
        </xs:restriction>\
    </xs:simpleType>\
    <xs:element name=\"indexer-config\">\
        <xs:complexType>\
            <xs:attribute name=\"type\" type=\"IndexerConfigResxType\" use=\"required\"/>\
            <xs:attribute name=\"convertDotsToSlashes\" type=\"xs:boolean\" use=\"required\"/>\
            <xs:attribute name=\"initialPath\" type=\"xs:string\" use=\"optional\"/>\
        </xs:complexType>\
    </xs:element>\
</xs:schema>\
```

<span data-ttu-id="0bb9e-175">`.resw` ファイルは、次のスキーマに準拠する XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-175">A `.resw` file is an XML file that conforms to the following schema.</span></span>

```xml
  <xsd:schema id="root" xmlns="" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xsd:import namespace="http://www.w3.org/XML/1998/namespace" />
    <xsd:element name="root" msdata:IsDataSet="true">
      <xsd:complexType>
        <xsd:choice maxOccurs="unbounded">
          <xsd:element name="metadata">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" />
              </xsd:sequence>
              <xsd:attribute name="name" use="required" type="xsd:string" />
              <xsd:attribute name="type" type="xsd:string" />
              <xsd:attribute name="mimetype" type="xsd:string" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="assembly">
            <xsd:complexType>
              <xsd:attribute name="alias" type="xsd:string" />
              <xsd:attribute name="name" type="xsd:string" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="data">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
                <xsd:element name="comment" type="xsd:string" minOccurs="0" msdata:Ordinal="2" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" msdata:Ordinal="1" />
              <xsd:attribute name="type" type="xsd:string" msdata:Ordinal="3" />
              <xsd:attribute name="mimetype" type="xsd:string" msdata:Ordinal="4" />
              <xsd:attribute ref="xml:space" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name="resheader">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name="value" type="xsd:string" minOccurs="0" msdata:Ordinal="1" />
              </xsd:sequence>
              <xsd:attribute name="name" type="xsd:string" use="required" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
  </xsd:schema>
```

<span data-ttu-id="0bb9e-176">`convertDotsToSlashes` 属性は、リソース名 (データ要素名属性) に見つかったすべてのドット (".") 文字をスラッシュ ("/") に変換します (ただし、"[" と "]" の間に配置されたドット文字は除きます)。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-176">The `convertDotsToSlashes` attribute converts all dot (".") characters found in resource names (data element name attributes) to a forward slash "/", except when the dot characters are between a "[" and "]".</span></span>

<span data-ttu-id="0bb9e-177">`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-177">The `initialPath` attribute places all resources under this initial path by prepending it to the name of the resource.</span></span> <span data-ttu-id="0bb9e-178">通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-178">You typically use this when indexing class library resources.</span></span> <span data-ttu-id="0bb9e-179">既定は空白です。</span><span class="sxs-lookup"><span data-stu-id="0bb9e-179">The default is blank.</span></span>

## <a name="related-topics"></a><span data-ttu-id="0bb9e-180">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0bb9e-180">Related topics</span></span>

* [<span data-ttu-id="0bb9e-181">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="0bb9e-181">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
* [<span data-ttu-id="0bb9e-182">MakePri.exe のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="0bb9e-182">MakePri.exe command-line options</span></span>](makepri-exe-command-options.md)
* [<span data-ttu-id="0bb9e-183">MakePri.exe 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="0bb9e-183">MakePri.exe configuration file</span></span>](makepri-exe-configuration.md)
* [<span data-ttu-id="0bb9e-184">JavaScript Object Notation (JSON) の application/json メディア型に関するページ</span><span class="sxs-lookup"><span data-stu-id="0bb9e-184">The application/json Media Type for JavaScript Object Notation (JSON)</span></span>](http://www.ietf.org/rfc/rfc4627.txt)