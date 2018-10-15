---
author: stevewhims
Description: This topic describes the schema of the MakePri.exe XML configuration file.
title: MakePri.exe 構成ファイル
template: detail.hbs
ms.author: stwhi
ms.date: 10/18/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 512880b7a7ea955a45697762cbbdb7f74ac70102
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615281"
---
# <a name="makepriexe-configuration-file"></a><span data-ttu-id="3e7b4-103">MakePri.exe 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="3e7b4-103">MakePri.exe configuration file</span></span>

<span data-ttu-id="3e7b4-104">ここでは、[MakePri.exe](compile-resources-manually-with-makepri.md) XML 構成ファイル (PRI 構成ファイルとも呼ばれる) のスキーマについて説明します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-104">This topic describes the schema of the [MakePri.exe](compile-resources-manually-with-makepri.md) XML configuration file; also known as a PRI config file.</span></span> <span data-ttu-id="3e7b4-105">MakePri.exe ツールには、新しい、初期化された PRI 構成ファイルを作成するために使用できる [createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-105">The MakePri.exe tool has a [createconfig command](makepri-exe-command-options.md#createconfig-command) that you can use to create a new, initialized PRI config file.</span></span>

> [!NOTE]
> <span data-ttu-id="3e7b4-106">MakePri.exe は、Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションを確認する場合にインストールされます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-106">MakePri.exe is installed when you check the **Windows SDK for UWP Managed Apps** option while installing the Windows Software Development Kit.</span></span> <span data-ttu-id="3e7b4-107">パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダーの)。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-107">It is installed to the path `%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe` (as well as in folders named for the other architectures).</span></span> <span data-ttu-id="3e7b4-108">たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-108">For example, `C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe`.</span></span>

<span data-ttu-id="3e7b4-109">PRI 構成ファイルは、どのリソースをどのようにインデックス化するかを制御します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-109">The PRI config file controls what resources are indexed, and how.</span></span> <span data-ttu-id="3e7b4-110">構成 XML は、次のスキーマに準拠する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-110">The configuration XML must conform to the following schema.</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>
<xs:schema attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="resources">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="packaging" maxOccurs="1" minOccurs="0">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="autoResourcePackage" maxOccurs="unbounded" minOccurs="0">
                <xs:complexType>
                  <xs:attribute name="qualifier" type="xs:string" use="required" />
                </xs:complexType>
              </xs:element>
              <xs:element name="resourcePackage" maxOccurs="unbounded" minOccurs="0">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element name="qualifierSet" maxOccurs="unbounded" minOccurs="0">
                      <xs:complexType>
                        <xs:attribute name="definition" type="xs:string" use="required" />
                      </xs:complexType>
                    </xs:element>
                  </xs:sequence>
                  <xs:attribute name="name" type="xs:string" use="required" />
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
        <xs:element maxOccurs="unbounded" name="index">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="qualifiers" minOccurs="0" maxOccurs="unbounded">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element minOccurs="1" maxOccurs="unbounded" name="qualifier">
                      <xs:complexType>
                        <xs:attribute name="name" type="xs:string" use="required" />
                        <xs:attribute name="value" type="xs:string" use="required" />
                      </xs:complexType>
                    </xs:element>
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
              <xs:element name="default" minOccurs="0" maxOccurs="unbounded">
                <xs:complexType>
                  <xs:sequence>
                    <xs:element minOccurs="1" maxOccurs="unbounded" name="qualifier">
                      <xs:complexType>
                        <xs:attribute name="name" type="xs:string" use="required" />
                        <xs:attribute name="value" type="xs:string" use="required" />
                      </xs:complexType>
                    </xs:element>
                  </xs:sequence>
                </xs:complexType>
              </xs:element>
              <xs:element name="indexer-config" minOccurs="0" maxOccurs="unbounded">
                <xs:complexType>
                  <xs:sequence>
                    <xs:any minOccurs="0" maxOccurs="unbounded" processContents="skip"/>
                  </xs:sequence>
                  <xs:attribute name="type" type="xs:string" use="required" />
                  <xs:anyAttribute processContents="skip"/>
                </xs:complexType>
              </xs:element>
            </xs:sequence>
            <xs:attribute name="root" type="xs:string" use="required" />
            <xs:attribute name="startIndexAt" type="xs:string" use="required" />
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name="isDeploymentMergeable" type="xs:boolean" use="optional" />
      <xs:attribute name="majorVersion" type="xs:positiveInteger" use="optional" />
      <xs:attribute name="targetOsVersion" type="xs:string" use="optional" />
    </xs:complexType>
  </xs:element>
</xs:schema>
```

- <span data-ttu-id="3e7b4-111">`default` 要素は、実行時コンテキストがどのリソース候補にも一致しないときにリソースを解決するために使う必要があるコンテキスト (言語、スケール、コントラストなど) を指定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-111">The `default` element specifies the context (language, scale, contrast, etc.) that should be used to resolve resources when the runtime context does not match any resource candidates.</span></span> <span data-ttu-id="3e7b4-112">このコンテキストはビルド時に指定され、変更されないため、リソースは、修飾子が作成されるときにこのコンテキストに解決されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-112">Because this context is specified at build time and does not change, resources are resolved to this context as qualifiers are created.</span></span> <span data-ttu-id="3e7b4-113">一致したスコアは、ビルド時に格納されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-113">The matched score is stored at build time.</span></span> <span data-ttu-id="3e7b4-114">すべての修飾子には値が指定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-114">Every qualifier must have some value specified.</span></span> <span data-ttu-id="3e7b4-115">リソースの選択方法について詳しくは、「[ResourceContext](resource-management-system.md#resourcecontext)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-115">See [ResourceContext](resource-management-system.md#resourcecontext) for details on how resources are chosen.</span></span>
- <span data-ttu-id="3e7b4-116">`index` 要素は、アセットに対して実行される別個のインデックス化パスを定義します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-116">The `index` element defines discrete indexing passes that are done over the assets.</span></span> <span data-ttu-id="3e7b4-117">それぞれのインデックス化パスは、どの[形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)を使うか、どのリソースをインデックス化するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-117">Each indexing pass determines the [format-specific indexers](makepri-exe-format-specific-indexers.md) to use, and which resources to index.</span></span>
- <span data-ttu-id="3e7b4-118">`qualifiers` 要素は、他のリソースの継承元となる最初のファイルまたはフォルダーの初期修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-118">The `qualifiers` element sets the initial qualifiers for the first file or folder that other resources inherit.</span></span> <span data-ttu-id="3e7b4-119">それぞれの修飾子要素は、有効な名前と値を持つ必要があります (「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-119">Each qualifier element must have a valid name and value (see [Tailor your resources for language, scale, high contrast, and other qualifiers](tailor-resources-lang-scale-contrast.md)).</span></span>
- <span data-ttu-id="3e7b4-120">`root` 属性は、インデックス パスの物理ファイルのパス ルートです。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-120">The `root` attribute is the path root of the physical file for the index pass.</span></span> <span data-ttu-id="3e7b4-121">この属性には、相対値または絶対値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-121">It can be relative or absolute.</span></span> <span data-ttu-id="3e7b4-122">相対値を指定した場合、値はコマンド ラインで指定したプロジェクト ルートの前に付加されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-122">If relative, it is appended to the project root that you provide in the command line.</span></span> <span data-ttu-id="3e7b4-123">絶対値を指定した場合、値はインデックス パス ルートとして直接使用されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-123">If absolute, it is directly used as the index pass root.</span></span> <span data-ttu-id="3e7b4-124">バックスラッシュまたはスラッシュを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-124">Back or forward slashes are acceptable.</span></span> <span data-ttu-id="3e7b4-125">末尾のスラッシュは削除されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-125">Trailing slashes are trimmed.</span></span> <span data-ttu-id="3e7b4-126">インデックス パスのルートは、すべてのリソースが相対的であると見なされるフォルダーを決定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-126">The root of the index pass determines the folder to which all resources are considered relative.</span></span>
- <span data-ttu-id="3e7b4-127">`startIndexAt` 属性は、インデックス化に使用される初期シード ファイルまたはフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-127">The `startIndexAt` attribute is the initial seed file or folder used in indexing.</span></span> <span data-ttu-id="3e7b4-128">これは、インデックス パス ルートに対する相対値です。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-128">It is relative to the index pass root.</span></span> <span data-ttu-id="3e7b4-129">空の値は、インデックス パス ルート フォルダーと見なされます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-129">An empty value assumes the index pass root folder.</span></span>

## <a name="default-pri-config-file"></a><span data-ttu-id="3e7b4-130">既定の PRI 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="3e7b4-130">Default PRI config file</span></span>

<span data-ttu-id="3e7b4-131">MakePri.exe は、[createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が発行されたときに、この新しい、初期化された PRI 構成ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-131">MakePri.exe generates this new, initialized PRI config file when the [createconfig command](makepri-exe-command-options.md#createconfig-command) is issued.</span></span>

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<resources targetOsVersion="10.0.0" majorVersion="1">
  <packaging>
    <autoResourcePackage qualifier="Language"/>
    <autoResourcePackage qualifier="Scale"/>
    <autoResourcePackage qualifier="DXFeatureLevel"/>
  </packaging>
  <index root="\" startIndexAt="\">
    <default>
      <qualifier name="Language" value="en-US"/>
      <qualifier name="Contrast" value="standard"/>
      <qualifier name="Scale" value="100"/>
      <qualifier name="HomeRegion" value="001"/>
      <qualifier name="TargetSize" value="256"/>
      <qualifier name="LayoutDirection" value="LTR"/>
      <qualifier name="Theme" value="dark"/>
      <qualifier name="AlternateForm" value=""/>
      <qualifier name="DXFeatureLevel" value="DX9"/>
      <qualifier name="Configuration" value=""/>
      <qualifier name="DeviceFamily" value="Universal"/>
      <qualifier name="Custom" value=""/>
    </default>
    <indexer-config type="folder" foldernameAsQualifier="true" filenameAsQualifier="true" qualifierDelimiter="."/>
    <indexer-config type="resw" convertDotsToSlashes="true" initialPath=""/>
    <indexer-config type="resjson" initialPath=""/>
    <indexer-config type="PRI"/>
  </index>
  <!--<index startIndexAt="Start Index Here" root="Root Here">-->
  <!--        <indexer-config type="resfiles" qualifierDelimiter="."/>-->
  <!--        <indexer-config type="priinfo" emitStrings="true" emitPaths="true" emitEmbeddedData="true"/>-->
  <!--</index>-->
</resources>
```

## <a name="packaging-element"></a><span data-ttu-id="3e7b4-132">Packaging 要素</span><span class="sxs-lookup"><span data-stu-id="3e7b4-132">Packaging element</span></span>

<span data-ttu-id="3e7b4-133">`packaging` 要素は PRI 分割情報を定義します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-133">The `packaging` element defines PRI split information.</span></span> <span data-ttu-id="3e7b4-134">`packaging` 要素のスキーマは、自動構成 (特定の次元に沿った `autoResourcePackage` のサポート) と手動構成の両方に対して定義します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-134">The schema for the `packaging` element is defined for both automatic (support for `autoResourcePackage` along a specific dimension), and manual configuration.</span></span>

<span data-ttu-id="3e7b4-135">この例は、特定の次元に沿った `autoResourcePackage` の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-135">This example shows how to use `autoResourcePackage` along a specific dimension.</span></span>

```xml
    <packaging>
        <autoResourcePackage qualifier="Language"/>
        <autoResourcePackage qualifier="Scale"/>
        <autoResourcePackage qualifier="DXFeatureLevel"/>
    </packaging>
```

<span data-ttu-id="3e7b4-136">この例は、手動での `resourcePackage` の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-136">This example shows how to use manual `resourcePackage`.</span></span>

```xml
  <packaging>
    <resourcePackage name="Germany">
      <qualifierSet definition="lang-de-de"/>
      <qualifierSet definition="lang-es-es"/>
    </resourcePackage>  
    <resourcePackage name="France">
      <qualifierSet definition="lang-fr-fr"/>
    </resourcePackage>  
    <resourcePackage name="HighRes1">
      <qualifierSet definition="scale-200"/>
    </resourcePackage>
    <resourcePackage name="HighRes2">
      <qualifierSet definition="scale-400"/>
    </resourcePackage>
  </packaging>
```

<span data-ttu-id="3e7b4-137">MakePri.exe では、特定の次元に沿ったリソース PRI ファイルの生成が明示的にブロックされません。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-137">MakePri.exe doesn't explicitly block generation of resource PRI files along any specific dimension.</span></span> <span data-ttu-id="3e7b4-138">特定の次元セットに沿った制限は、MakeAppx.exe やパイプライン内の他のツールによって外部的に定義および実装します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-138">Restrictions along a certain set of dimensions are defined and implemented externally by either MakeAppx.exe or other tools in the pipeline.</span></span>

<span data-ttu-id="3e7b4-139">MakePri.exe は、すべての `index` ノードの後に `packaging` ノードを解析して、すべての既定の修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-139">MakePri.exe parses the `packaging` element after all the `index` nodes to populate all the default qualifiers.</span></span> <span data-ttu-id="3e7b4-140">MakePri.exe は、解析された情報をこれらのデータ構造に収集します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-140">MakePri.exe collects parsed info in these data structures.</span></span>

```csharp
enum ResourcePackageMode
{
    None,
    AutoPackQualifier,
    ManualPack
}

ResourcePackageMode eResourcePackageMode;
list<string> RPQualifierList; // To store AutoResourcePackage Qualifiers
map<string, list<string>> RPNameToQSIMap; // To store ResourcePackage name to QualifierSet list mapping.
```

## <a name="resourcesisdeploymentmergeable-attribute"></a><span data-ttu-id="3e7b4-141">resources@isDeploymentMergeable 属性</span><span class="sxs-lookup"><span data-stu-id="3e7b4-141">resources@isDeploymentMergeable attribute</span></span>

<span data-ttu-id="3e7b4-142">この属性は、次の操作を実行するフラグを PRI ファイル内に設定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-142">This attribute sets a flag in the PRI file that causes</span></span>

- <span data-ttu-id="3e7b4-143">展開のマージで、この PRI ファイルがマージできることを識別する。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-143">Deployment merge to identify that this PRI file can merge.</span></span>
- <span data-ttu-id="3e7b4-144">このフラグが設定され、リソース マネージャーがファイルによって所期されている場合、GetFullyQualifiedReference がエラーを返す。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-144">GetFullyQualifiedReference to return an error in case this flag is set and the resource manager has been initialized with a file.</span></span>

<span data-ttu-id="3e7b4-145">この属性の既定値は `true` です。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-145">The default value of this attribute is `true`.</span></span> <span data-ttu-id="3e7b4-146">Windows 10 をターゲットにする場合、MakePri.exe は PRI にフラグを設定するのみです。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-146">MakePri.exe only sets the flag in PRI if you target Windows 10.</span></span>

<span data-ttu-id="3e7b4-147">Windows 10 をターゲットにする場合、リソース パックの作成時に `isDeploymentMergeable` を省略する (または明示的に `true` に設定する) ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-147">We recommend that you omit `isDeploymentMergeable` (or set it explicitly to `true`) for resource pack creation if you target Windows 10.</span></span>

<span data-ttu-id="3e7b4-148">`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `isDeploymentMergeable` の値をダンプ ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-148">MakePri.exe adds the value of `isDeploymentMergeable` to the dump file if `makepri dump` is run with the `/dt detailed` option.</span></span>

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<PriInfo>
    <PriHeader>
        ...
        <IsDeploymentMergeable>true</IsDeploymentMergeable>
        ...
    </PriHeader>
  ...
</PriInfo>
```

## <a name="resourcesmajorversion-attribute"></a><span data-ttu-id="3e7b4-149">resources@majorVersion 属性</span><span class="sxs-lookup"><span data-stu-id="3e7b4-149">resources@majorVersion attribute</span></span>

<span data-ttu-id="3e7b4-150">この属性の既定値は 1 です。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-150">The default value for this attribute is 1.</span></span> <span data-ttu-id="3e7b4-151">明示的な値を指定し、MakePri.exe ツールの推奨されなくなった `/VersionMajor(vma)` コマンド ライン オプションも使用している場合、構成ファイル内の値が優先されます。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-151">If you provide an explicit value, and you also use the deprecated `/VersionMajor(vma)` command-line option for the MakePri.exe tool, then the value in the config file takes precedence.</span></span>

<span data-ttu-id="3e7b4-152">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-152">Here's an example.</span></span>

```xml
<resources majorVersion="2">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

## <a name="resourcestargetosversion-attribute"></a><span data-ttu-id="3e7b4-153">resources@targetOsVersion 属性</span><span class="sxs-lookup"><span data-stu-id="3e7b4-153">resources@targetOsVersion attribute</span></span>

<span data-ttu-id="3e7b4-154">ターゲット オペレーティング システムのバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-154">Indicates the target operating system version.</span></span> <span data-ttu-id="3e7b4-155">次の表は、サポートされている値を示しています。既定値は 6.3.0 です。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-155">The table below shows the values that are supported; the default value is 6.3.0.</span></span>

| <span data-ttu-id="3e7b4-156">値</span><span class="sxs-lookup"><span data-stu-id="3e7b4-156">Value</span></span> | <span data-ttu-id="3e7b4-157">意味</span><span class="sxs-lookup"><span data-stu-id="3e7b4-157">Meaning</span></span> |
| ----- | ------- |
| <span data-ttu-id="3e7b4-158">10.0.0</span><span class="sxs-lookup"><span data-stu-id="3e7b4-158">10.0.0</span></span> | <span data-ttu-id="3e7b4-159">Windows 10</span><span class="sxs-lookup"><span data-stu-id="3e7b4-159">Windows 10</span></span> |
| <span data-ttu-id="3e7b4-160">6.3.0 (既定)</span><span class="sxs-lookup"><span data-stu-id="3e7b4-160">6.3.0 (default)</span></span> | <span data-ttu-id="3e7b4-161">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="3e7b4-161">Windows 8.1</span></span> |
| <span data-ttu-id="3e7b4-162">6.2.1</span><span class="sxs-lookup"><span data-stu-id="3e7b4-162">6.2.1</span></span> | <span data-ttu-id="3e7b4-163">Windows 8</span><span class="sxs-lookup"><span data-stu-id="3e7b4-163">Windows 8</span></span> |

<span data-ttu-id="3e7b4-164">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-164">Here's an example.</span></span>

```xml
<resources targetOsVersion="10.0.0">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

<span data-ttu-id="3e7b4-165">**注** Windows は PRI ファイルに関しては下位互換性がありますが、常に上位互換性があるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-165">**Note** Windows is backward compatible with respect to PRI files; but not always forward compatible.</span></span>

<span data-ttu-id="3e7b4-166">`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `targetOsVersion` の値をダンプ ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-166">MakePri.exe adds the value of `targetOsVersion` to the dump file if `makepri dump` is run with the `/dt detailed` option.</span></span>

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<PriInfo>
    <PriHeader>
        ...
        <TargetOS version="10.0.0"/>
        ...
    </PriHeader>
  ...
</PriInfo>
```

## <a name="validation-error-messages"></a><span data-ttu-id="3e7b4-167">検証エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="3e7b4-167">Validation error messages</span></span>

<span data-ttu-id="3e7b4-168">エラー状況の例と対応するエラー メッセージを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-168">Here are some example error conditions, and the corresponding error message.</span></span>

| <span data-ttu-id="3e7b4-169">状況</span><span class="sxs-lookup"><span data-stu-id="3e7b4-169">Condition</span></span> | <span data-ttu-id="3e7b4-170">重大度</span><span class="sxs-lookup"><span data-stu-id="3e7b4-170">Severity</span></span> | <span data-ttu-id="3e7b4-171">メッセージ</span><span class="sxs-lookup"><span data-stu-id="3e7b4-171">Message</span></span> |
| --------- | -------- | ------- |
| <span data-ttu-id="3e7b4-172">サポートされる値のいずれか以外の targetOsVersion が指定されている。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-172">A targetOsVersion other than one of the supported values is specified.</span></span> | <span data-ttu-id="3e7b4-173">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-173">Error</span></span> | <span data-ttu-id="3e7b4-174">Invalid Configuration: Invalid targetOsVersion specified.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-174">Invalid Configuration: Invalid targetOsVersion specified.</span></span> |
| <span data-ttu-id="3e7b4-175">targetOsVersion "6.2.1" が指定されており、`packaging` 要素が存在する。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-175">A targetOsVersion of "6.2.1" is specified and a `packaging` element is present.</span></span> | <span data-ttu-id="3e7b4-176">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-176">Error</span></span> | <span data-ttu-id="3e7b4-177">Invalid Configuration: 'Packaging' node is not supported with this targetOsVersion.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-177">Invalid Configuration: 'Packaging' node is not supported with this targetOsVersion.</span></span> |
| <span data-ttu-id="3e7b4-178">構成内に複数のモードが見つかった。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-178">More than one mode found in the configuration.</span></span> <span data-ttu-id="3e7b4-179">たとえば、Manual と AutoResourcePackage が指定されている。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-179">For example, Manual and AutoResourcePackage specified.</span></span> | <span data-ttu-id="3e7b4-180">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-180">Error</span></span> | <span data-ttu-id="3e7b4-181">Invalid Configuration: 'packaging' node cannot have more than one mode of operation.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-181">Invalid Configuration: 'packaging' node cannot have more than one mode of operation.</span></span> |
| <span data-ttu-id="3e7b4-182">既定の修飾子がリソース パッケージの下にリストされている。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-182">A default qualifier is listed under resource package.</span></span> | <span data-ttu-id="3e7b4-183">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-183">Error</span></span> | <span data-ttu-id="3e7b4-184">Invalid Configuration: <Qualifiername>=<QualifierValue> is a default qualifier and its candidates cannot be added to a resource package.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-184">Invalid Configuration: <Qualifiername>=<QualifierValue> is a default qualifier and its candidates cannot be added to a resource package.</span></span> |
| <span data-ttu-id="3e7b4-185">AutoResourcePackage 修飾子に複数の修飾子が含まれる。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-185">AutoResourcePackage qualifier contains multiple qualifiers.</span></span> <span data-ttu-id="3e7b4-186">たとえば、language_scale。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-186">For example, language_scale.</span></span> | <span data-ttu-id="3e7b4-187">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-187">Error</span></span> | <span data-ttu-id="3e7b4-188">Invalid Configuration : AutoResourcePackage with multiple qualifiers is not supported.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-188">Invalid Configuration : AutoResourcePackage with multiple qualifiers is not supported.</span></span> |
| <span data-ttu-id="3e7b4-189">ResourcePackage QualifierSet に複数の修飾子が含まれる。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-189">ResourcePackage QualifierSet contains multiple qualifiers.</span></span> <span data-ttu-id="3e7b4-190">たとえば、language-en-us_scale-100。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-190">For example, language-en-us_scale-100</span></span> | <span data-ttu-id="3e7b4-191">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-191">Error</span></span> | <span data-ttu-id="3e7b4-192">Invalid Configuration : QualifierSet with multiple qualifiers is not supported.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-192">Invalid Configuration : QualifierSet with multiple qualifiers is not supported.</span></span> |
| <span data-ttu-id="3e7b4-193">重複するリソース パック名が見つかる。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-193">Duplicate resourcepack name found.</span></span> | <span data-ttu-id="3e7b4-194">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-194">Error</span></span> | <span data-ttu-id="3e7b4-195">Invalid Configuration : Duplicate resource pack name <rpname>.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-195">Invalid Configuration : Duplicate resource pack name <rpname>.</span></span> |
| <span data-ttu-id="3e7b4-196">2 つのリソース パッケージに同じ修飾子セットが定義されている。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-196">Same qualifier set defined in two resource packages.</span></span> | <span data-ttu-id="3e7b4-197">エラー</span><span class="sxs-lookup"><span data-stu-id="3e7b4-197">Error</span></span> | <span data-ttu-id="3e7b4-198">Invalid Configuration: Multiple instances of QualifierSet "<qualifier tags>" found.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-198">Invalid Configuration: Multiple instances of QualifierSet "<qualifier tags>" found.</span></span> |
| <span data-ttu-id="3e7b4-199">'ResourcePackage' ノードに対してリストされた QualifierSet の候補が見つからない。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-199">No candidates are found for the QualifierSet listed for 'ResourcePackage' node.</span></span> | <span data-ttu-id="3e7b4-200">警告</span><span class="sxs-lookup"><span data-stu-id="3e7b4-200">Warning</span></span> | <span data-ttu-id="3e7b4-201">Invalid Configuration: No candidates found for <Resource Package Name>.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-201">Invalid Configuration: No candidates found for <Resource Package Name>.</span></span> |
| <span data-ttu-id="3e7b4-202">'AutoResourcePackage' ノードの下にリストされた修飾子の候補が見つからない。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-202">No candidates found for qualifier listed under ‘AutoResourcePackage’ node.</span></span> | <span data-ttu-id="3e7b4-203">警告</span><span class="sxs-lookup"><span data-stu-id="3e7b4-203">Warning</span></span> | <span data-ttu-id="3e7b4-204">Invalid Configuration: No candidates found for qualifier <qualifier name>.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-204">Invalid Configuration: No candidates found for qualifier <qualifier name>.</span></span> <span data-ttu-id="3e7b4-205">Resource Package not generated.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-205">Resource Package not generated.</span></span> |
| <span data-ttu-id="3e7b4-206">モードが見つからない。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-206">None of the modes are found.</span></span> <span data-ttu-id="3e7b4-207">つまり、空の 'packaging' ノードが見つかる。</span><span class="sxs-lookup"><span data-stu-id="3e7b4-207">That is, empty 'packaging' node found.</span></span> | <span data-ttu-id="3e7b4-208">警告</span><span class="sxs-lookup"><span data-stu-id="3e7b4-208">Warning</span></span> | <span data-ttu-id="3e7b4-209">Invalid Configuration: No packaging mode specified.</span><span class="sxs-lookup"><span data-stu-id="3e7b4-209">Invalid Configuration: No packaging mode specified.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="3e7b4-210">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3e7b4-210">Related topics</span></span>

* [<span data-ttu-id="3e7b4-211">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="3e7b4-211">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
* [<span data-ttu-id="3e7b4-212">MakePri.exe のコマンド ライン オプション: createconfig コマンド</span><span class="sxs-lookup"><span data-stu-id="3e7b4-212">MakePri.exe command-line options&mdash;createconfig command</span></span>](makepri-exe-command-options.md#createconfig-command)
* [<span data-ttu-id="3e7b4-213">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="3e7b4-213">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="3e7b4-214">リソース管理システム: ResourceContext</span><span class="sxs-lookup"><span data-stu-id="3e7b4-214">Resource Management System&mdash;ResourceContext</span></span>](resource-management-system.md#resourcecontext)