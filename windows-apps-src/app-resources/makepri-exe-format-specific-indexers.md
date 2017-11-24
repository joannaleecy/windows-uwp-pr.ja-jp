---
author: stevewhims
Description: "このトピックでは、リソースのインデックスを生成するために MakePri.exe ツールによって使われる形式に固有のインデクサーについて説明します。"
title: "MakePri.exe の形式に固有のインデクサー"
template: detail.hbs
ms.author: stwhi
ms.date: 10/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子"
localizationpriority: medium
ms.openlocfilehash: d0ab502a4735ac028a4d2869824378d69314eb72
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

# <a name="makepriexe-format-specific-indexers"></a><span data-ttu-id="7f111-104">MakePri.exe の形式に固有のインデクサー</span><span class="sxs-lookup"><span data-stu-id="7f111-104">MakePri.exe format-specific indexers</span></span>

<span data-ttu-id="7f111-105">このトピックでは、リソースのインデックスを生成するために [MakePri.exe](compile-resources-manually-with-makepri.md) ツールによって使われる形式に固有のインデクサーについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7f111-105">This topic describes the format-specific indexers used by the [MakePri.exe](compile-resources-manually-with-makepri.md) tool to generate its index of resources.</span></span>

<span data-ttu-id="7f111-106">MakePri.exe は、通常、`new`、`versioned`、`resourcepack` コマンドと共に使用されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-106">MakePri.exe is typically used with the `new`, `versioned`, or `resourcepack` commands.</span></span> <span data-ttu-id="7f111-107">「[MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f111-107">See [MakePri.exe command-line options](makepri-exe-command-options.md).</span></span> <span data-ttu-id="7f111-108">これらのオプションを使うと、ソース ファイルがインデックス化され、リソースのインデックスが生成されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-108">In those cases it indexes source files to generate an index of resources.</span></span> <span data-ttu-id="7f111-109">MakePri.exe は、さまざまな別個のインデクサーを使って異なるソース リソース ファイルまたはリソースのコンテナーを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="7f111-109">MakePri.exe uses various individual indexers to read different source resource files or containers for resources.</span></span> <span data-ttu-id="7f111-110">最も単純なインデクサーは、`.jpg` 画像 や `.png` 画像などのフォルダーの内容をインデックス化するフォルダー インデクサーです。</span><span class="sxs-lookup"><span data-stu-id="7f111-110">The simplest indexer is the folder indexer, which indexes the contents of a folder, such as `.jpg` or `.png` images.</span></span>

<span data-ttu-id="7f111-111">形式に固有のインデクサーは、[MakePri.exe 構成ファイル](makepri-exe-configuration.md)の `<index>` 要素内で `<indexer-config>` 要素を指定することによって識別します。</span><span class="sxs-lookup"><span data-stu-id="7f111-111">You identify format-specific indexers by specifying `<indexer-config>` elements within an `<index>` element of the [MakePri.exe configuration file](makepri-exe-configuration.md).</span></span> <span data-ttu-id="7f111-112">`type` 属性は、使われる形式に固有のインデクサーを識別します。</span><span class="sxs-lookup"><span data-stu-id="7f111-112">The `type` attribute identifies the format-specific indexer that is used.</span></span>

<span data-ttu-id="7f111-113">インデックス化の処理中にリソース コンテナーが検出されると、その内容がインデックス化されます (コンテナー自体はインデックスに追加されません)。</span><span class="sxs-lookup"><span data-stu-id="7f111-113">Resource containers encountered during indexing usually get their contents indexed rather than being added to the index themselves.</span></span> <span data-ttu-id="7f111-114">たとえば、フォルダー インデクサーによって検出された `.resjson` ファイルは `.resjson` インデクサーによってインデックス化されます。このとき、`.resjson` ファイル自体はインデックスに表示されません。</span><span class="sxs-lookup"><span data-stu-id="7f111-114">For example, `.resjson` files that the folder indexer finds may be further indexed by a `.resjson` indexer, in which case the `.resjson` file itself does not appear in the index.</span></span> <span data-ttu-id="7f111-115">**注** こうした状態になるには、そのコンテナーに関連付けられたインデクサーの `<indexer-config>` 要素が構成ファイルに記述されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f111-115">**Note** an `<indexer-config>` element for the indexer associated with that container must be included in the configuration file for that to happen.</span></span>

<span data-ttu-id="7f111-116">通常、フォルダーや `.resw` ファイルなどのコンテナー エンティティで検出された修飾子は、コンテナー エンティティ内のすべてのリソース (フォルダー内のファイルや `.resw` ファイル内の文字列など) に適用されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-116">Typically, qualifiers found on a containing entity&mdash;such as a folder or a `.resw` file&mdash;are applied to all resources within it, such as the files within the folder, or the strings within the `.resw` file.</span></span>

## <a name="folder"></a><span data-ttu-id="7f111-117">フォルダー</span><span class="sxs-lookup"><span data-stu-id="7f111-117">Folder</span></span>

<span data-ttu-id="7f111-118">フォルダー インデクサーは、`type` 属性 FOLDER で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-118">The folder indexer is identified by a `type` attribute of FOLDER.</span></span> <span data-ttu-id="7f111-119">フォルダーの内容をインデックス化し、フォルダー名とファイル名からリソース修飾子を決定します。</span><span class="sxs-lookup"><span data-stu-id="7f111-119">It indexes the contents of a folder, and determines resource qualifiers from the folder and filenames.</span></span> <span data-ttu-id="7f111-120">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="7f111-120">Its configuration element conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-121">`qualifierDelimiter` 属性は、拡張子を除いてファイル名に指定される修飾子の前の文字を指定します。</span><span class="sxs-lookup"><span data-stu-id="7f111-121">The `qualifierDelimiter` attribute specifies the character after which qualifiers are specified in a filename, ignoring the extension.</span></span> <span data-ttu-id="7f111-122">既定値は "." です。</span><span class="sxs-lookup"><span data-stu-id="7f111-122">The default is ".".</span></span>

## <a name="pri"></a><span data-ttu-id="7f111-123">PRI</span><span class="sxs-lookup"><span data-stu-id="7f111-123">PRI</span></span>

<span data-ttu-id="7f111-124">PRI インデクサーは、`type` 属性 PRI で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-124">The PRI indexer is identified by a `type` attribute of PRI.</span></span> <span data-ttu-id="7f111-125">PRI ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="7f111-125">It indexes the contents of a PRI file.</span></span> <span data-ttu-id="7f111-126">通常、別のアセンブリ、DLL、SDK、またはクラス ライブラリ内に格納されたリソースをアプリの PRI にインデックス化する場合にこのインデクサーを使います。</span><span class="sxs-lookup"><span data-stu-id="7f111-126">You typically use it when indexing the resource contained within another assembly, DLL, SDK, or class library into the app's PRI.</span></span>

<span data-ttu-id="7f111-127">PRI ファイルに含まれるすべてのリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-127">All resource names, qualifiers and values contained in the PRI file are directly maintained in the new PRI file.</span></span> <span data-ttu-id="7f111-128">ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。</span><span class="sxs-lookup"><span data-stu-id="7f111-128">The top level resource map, however is not maintained in the final PRI.</span></span> <span data-ttu-id="7f111-129">リソース マップはマージされます。</span><span class="sxs-lookup"><span data-stu-id="7f111-129">Resource Maps are merged.</span></span>

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

## <a name="priinfo"></a><span data-ttu-id="7f111-130">PriInfo</span><span class="sxs-lookup"><span data-stu-id="7f111-130">PriInfo</span></span>

<span data-ttu-id="7f111-131">PriInfo インデクサーは、`type` 属性 PRIINFO で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-131">The PriInfo indexer is identified by a `type` attribute of PRIINFO.</span></span> <span data-ttu-id="7f111-132">詳細ダンプ ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="7f111-132">It indexes the contents of a detailed dump file.</span></span> <span data-ttu-id="7f111-133">詳細なダンプ ファイルを生成するには、`/dt detailed` オプションを指定して `makepri dump` を実行します。</span><span class="sxs-lookup"><span data-stu-id="7f111-133">You produce a detailed dump file by running `makepri dump` with the `/dt detailed` option.</span></span> <span data-ttu-id="7f111-134">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="7f111-134">The configuration element for the indexer conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-135">この構成要素では、オプションの属性を使って、PriInfo インデクサーの動作を構成できます。</span><span class="sxs-lookup"><span data-stu-id="7f111-135">This configuration element allows for optional attributes to configure the behavior of the PriInfo indexer.</span></span> <span data-ttu-id="7f111-136">`emitStrings` と `emitPaths` の既定値は `true` です。</span><span class="sxs-lookup"><span data-stu-id="7f111-136">The default value of `emitStrings` and `emitPaths` is `true`.</span></span> <span data-ttu-id="7f111-137">`emitStrings` が `true` である場合、`type` 属性が "String" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-137">If `emitStrings` is `true` then resource candidates with the `type` attribute set to "String" are be included in the index, otherwise they are excluded.</span></span> <span data-ttu-id="7f111-138">'emitPaths' が `true` である場合、`type` 属性が "Path" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-138">If 'emitPaths' is `true` then resource candidates with the `type` attribute set to "Path" are included in the index, otherwise they are excluded.</span></span>

<span data-ttu-id="7f111-139">次に示す構成例では、種類が String のリソースを含める一方で Path のリソースをスキップしています。</span><span class="sxs-lookup"><span data-stu-id="7f111-139">Here is an example configuration that includes String resource types but skips Path resource types.</span></span>

```xml
<indexer-config type="priinfo" emitStrings="true" emitPaths="false" />
```

<span data-ttu-id="7f111-140">インデックス化する場合、ダンプ ファイルは拡張子 `.pri.xml` で終了し、次のスキーマに準拠する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f111-140">To be indexed, a dump file must end with the extension `.pri.xml`, and must conform to the following schema.</span></span>

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

<span data-ttu-id="7f111-141">MakePri.exe では、'Basic'、'Detailed'、'Schema'、'Summary' のダンプの種類がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="7f111-141">MakePri.exe supports dump types 'Basic', 'Detailed', 'Schema', and 'Summary'.</span></span> <span data-ttu-id="7f111-142">PriInfo インデクサーが読み取ることができる種類のダンプが生成されるように MakePri.exe を構成するには、`dump` コマンドを使うときに "/DumpType Detailed" を指定します。</span><span class="sxs-lookup"><span data-stu-id="7f111-142">To configure MakePri.exe to emit the dump type that the PriInfo indexer can read, include "/DumpType Detailed" when using the `dump` command.</span></span>

<span data-ttu-id="7f111-143">`.pri.xml` ファイルのいくつかの要素は MakePri.exe でスキップされます。</span><span class="sxs-lookup"><span data-stu-id="7f111-143">Several elements of the `.pri.xml` file are skipped by MakePri.exe.</span></span> <span data-ttu-id="7f111-144">これらの要素は、インデックスの作成中に計算されるか、MakePri.exe 構成ファイル内で指定されています。</span><span class="sxs-lookup"><span data-stu-id="7f111-144">These elements are either computed during indexing, or are specified in the MakePri.exe configuration file.</span></span> <span data-ttu-id="7f111-145">ダンプ ファイルに含まれるリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-145">Resource names, qualifiers, and values that are contained within the dump file are directly maintained in the new PRI file.</span></span> <span data-ttu-id="7f111-146">ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。</span><span class="sxs-lookup"><span data-stu-id="7f111-146">The top-level resource map, however, is not maintained in the final PRI.</span></span> <span data-ttu-id="7f111-147">リソース マップは、インデックス化の一部としてマージされます。</span><span class="sxs-lookup"><span data-stu-id="7f111-147">Resource Maps are merged as part of the indexing.</span></span>

<span data-ttu-id="7f111-148">これは、ダンプ ファイルの有効な String 型リソースの例です。</span><span class="sxs-lookup"><span data-stu-id="7f111-148">This is an example of a valid String type resource from a dump file.</span></span>

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

<span data-ttu-id="7f111-149">これは、ダンプ ファイルの、2 つの候補が含まれた有効な Path 型リソースの例です。</span><span class="sxs-lookup"><span data-stu-id="7f111-149">This is an example of a valid Path type resource with two candidates from a dump file.</span></span>

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

## <a name="resfiles"></a><span data-ttu-id="7f111-150">ResFiles</span><span class="sxs-lookup"><span data-stu-id="7f111-150">ResFiles</span></span>

<span data-ttu-id="7f111-151">ResFiles インデクサーは、`type` 属性 RESFILES で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-151">The ResFiles indexer is identified by a `type` attribute of RESFILES.</span></span> <span data-ttu-id="7f111-152">`.resfiles` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="7f111-152">It indexes the contents of a `.resfiles` file.</span></span> <span data-ttu-id="7f111-153">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="7f111-153">Its configuration element conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-154">`.resfiles` ファイルは、ファイル パスのフラットな一覧が格納されたテキスト ファイルです。</span><span class="sxs-lookup"><span data-stu-id="7f111-154">A `.resfiles` file is a text file containing a flat list of file paths.</span></span> <span data-ttu-id="7f111-155">`.resfiles` ファイルには、"//" コメントを格納できます。</span><span class="sxs-lookup"><span data-stu-id="7f111-155">A `.resfiles` file can contain "//" comments.</span></span> <span data-ttu-id="7f111-156">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="7f111-156">Here's an example.</span></span>

```
Strings\component1\fr\elements.resjson
Images\logo.scale-100.png
Images\logo.scale-140.png
Images\logo.scale-180.png
```

## <a name="resjson"></a><span data-ttu-id="7f111-157">ResJSON</span><span class="sxs-lookup"><span data-stu-id="7f111-157">ResJSON</span></span>

<span data-ttu-id="7f111-158">ResJSON インデクサーは、`type` 属性 RESJSON で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-158">The ResJSON indexer is identified by a `type` attribute of RESJSON.</span></span> <span data-ttu-id="7f111-159">文字列リソース ファイルである `.resjson` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="7f111-159">It indexes the contents of a `.resjson` file, which is a string resource file.</span></span> <span data-ttu-id="7f111-160">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="7f111-160">Its configuration element conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-161">`.resjson` ファイルは JSON テキストを格納します ([JavaScript Object Notation (JSON) の application/json メディア型に関するページ](http://www.ietf.org/rfc/rfc4627.txt)を参照)。</span><span class="sxs-lookup"><span data-stu-id="7f111-161">A `.resjson` file contains JSON text (see [The application/json Media Type for JavaScript Object Notation (JSON)](http://www.ietf.org/rfc/rfc4627.txt)).</span></span> <span data-ttu-id="7f111-162">ファイルには、階層プロパティを持つ単一の JSON オブジェクトが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f111-162">The file must contain a single JSON object with hierarchical properties.</span></span> <span data-ttu-id="7f111-163">それぞれのプロパティは、別の JSON オブジェクトか、文字列値である必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f111-163">Each property must either be another JSON object or a string value.</span></span>

<span data-ttu-id="7f111-164">名前が下線 ("_") で始まる JSON プロパティは最終的な PRI ファイルにコンパイルされませんが、ログ ファイル内で保持されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-164">JSON properties with names that begin with an underscore ("_") are not compiled into the final PRI file, but are maintained in the log file.</span></span>

<span data-ttu-id="7f111-165">ファイルには "//" コメントを格納できます。これらのコメントは、解析時に無視されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-165">The file can also contain "//" comments which are ignored during parsing.</span></span>

<span data-ttu-id="7f111-166">`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-166">The `initialPath` attribute places all resources under this initial path by prepending it to the name of the resource.</span></span> <span data-ttu-id="7f111-167">通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="7f111-167">You would typically use this when indexing class library resources.</span></span> <span data-ttu-id="7f111-168">既定は空白です。</span><span class="sxs-lookup"><span data-stu-id="7f111-168">The default is blank.</span></span>

## <a name="resw"></a><span data-ttu-id="7f111-169">ResW</span><span class="sxs-lookup"><span data-stu-id="7f111-169">ResW</span></span>

<span data-ttu-id="7f111-170">ResW インデクサーは、`type` 属性 RESW で識別されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-170">The ResW indexer is identified by a `type` attribute of RESW.</span></span> <span data-ttu-id="7f111-171">文字列リソース ファイルである `.resw` ファイルの内容をインデックス化します。</span><span class="sxs-lookup"><span data-stu-id="7f111-171">It indexes the contents of a `.resw` file, which is a string resource file.</span></span> <span data-ttu-id="7f111-172">このインデクサーの構成要素は、次のスキーマに準拠します。</span><span class="sxs-lookup"><span data-stu-id="7f111-172">Its configuration element conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-173">`.resw` ファイルは、次のスキーマに準拠する XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="7f111-173">A `.resw` file is an XML file that conforms to the following schema.</span></span>

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

<span data-ttu-id="7f111-174">`convertDotsToSlashes` 属性は、リソース名 (データ要素名属性) に見つかったすべてのドット (".") 文字をスラッシュ ("/") に変換します (ただし、"[" と "]" の間に配置されたドット文字は除きます)。</span><span class="sxs-lookup"><span data-stu-id="7f111-174">The `convertDotsToSlashes` attribute converts all dot (".") characters found in resource names (data element name attributes) to a forward slash "/", except when the dot characters are between a "[" and "]".</span></span>

<span data-ttu-id="7f111-175">`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。</span><span class="sxs-lookup"><span data-stu-id="7f111-175">The `initialPath` attribute places all resources under this initial path by prepending it to the name of the resource.</span></span> <span data-ttu-id="7f111-176">通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。</span><span class="sxs-lookup"><span data-stu-id="7f111-176">You typically use this when indexing class library resources.</span></span> <span data-ttu-id="7f111-177">既定は空白です。</span><span class="sxs-lookup"><span data-stu-id="7f111-177">The default is blank.</span></span>

## <a name="related-topics"></a><span data-ttu-id="7f111-178">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7f111-178">Related topics</span></span>

* [<span data-ttu-id="7f111-179">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="7f111-179">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
* [<span data-ttu-id="7f111-180">MakePri.exe のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="7f111-180">MakePri.exe command-line options</span></span>](makepri-exe-command-options.md)
* [<span data-ttu-id="7f111-181">MakePri.exe 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="7f111-181">MakePri.exe configuration file</span></span>](makepri-exe-configuration.md)
* [<span data-ttu-id="7f111-182">JavaScript Object Notation (JSON) の application/json メディア型に関するページ</span><span class="sxs-lookup"><span data-stu-id="7f111-182">The application/json Media Type for JavaScript Object Notation (JSON)</span></span>](http://www.ietf.org/rfc/rfc4627.txt)