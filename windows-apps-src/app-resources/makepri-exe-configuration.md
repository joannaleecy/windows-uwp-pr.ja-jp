---
Description: ここでは、MakePri.exe XML 構成ファイルのスキーマについて説明します。
title: MakePri.exe 構成ファイル
template: detail.hbs
ms.date: 10/18/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: ef0e8834310e77084c0bb4a8aad22786a89fb312
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607797"
---
# <a name="makepriexe-configuration-file"></a><span data-ttu-id="8d52b-104">MakePri.exe 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="8d52b-104">MakePri.exe configuration file</span></span>

<span data-ttu-id="8d52b-105">ここでは、[MakePri.exe](compile-resources-manually-with-makepri.md) XML 構成ファイル (PRI 構成ファイルとも呼ばれる) のスキーマについて説明します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-105">This topic describes the schema of the [MakePri.exe](compile-resources-manually-with-makepri.md) XML configuration file; also known as a PRI config file.</span></span> <span data-ttu-id="8d52b-106">MakePri.exe ツールには、新しい、初期化された PRI 構成ファイルを作成するために使用できる [createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が含まれています。</span><span class="sxs-lookup"><span data-stu-id="8d52b-106">The MakePri.exe tool has a [createconfig command](makepri-exe-command-options.md#createconfig-command) that you can use to create a new, initialized PRI config file.</span></span>

> [!NOTE]
> <span data-ttu-id="8d52b-107">チェックするときに MakePri.exe がインストールされている、**管理されているアプリの UWP 用 Windows SDK** Windows ソフトウェア開発キットのインストール中にオプション。</span><span class="sxs-lookup"><span data-stu-id="8d52b-107">MakePri.exe is installed when you check the **Windows SDK for UWP Managed Apps** option while installing the Windows Software Development Kit.</span></span> <span data-ttu-id="8d52b-108">パスにインストールされて`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャのという名前のフォルダーの)。</span><span class="sxs-lookup"><span data-stu-id="8d52b-108">It is installed to the path `%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe` (as well as in folders named for the other architectures).</span></span> <span data-ttu-id="8d52b-109">たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-109">For example, `C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe`.</span></span>

<span data-ttu-id="8d52b-110">PRI 構成ファイルは、どのリソースをどのようにインデックス化するかを制御します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-110">The PRI config file controls what resources are indexed, and how.</span></span> <span data-ttu-id="8d52b-111">構成 XML は、次のスキーマに準拠する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8d52b-111">The configuration XML must conform to the following schema.</span></span>

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

- <span data-ttu-id="8d52b-112">`default` 要素は、実行時コンテキストがどのリソース候補にも一致しないときにリソースを解決するために使う必要があるコンテキスト (言語、スケール、コントラストなど) を指定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-112">The `default` element specifies the context (language, scale, contrast, etc.) that should be used to resolve resources when the runtime context does not match any resource candidates.</span></span> <span data-ttu-id="8d52b-113">このコンテキストはビルド時に指定され、変更されないため、リソースは、修飾子が作成されるときにこのコンテキストに解決されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-113">Because this context is specified at build time and does not change, resources are resolved to this context as qualifiers are created.</span></span> <span data-ttu-id="8d52b-114">一致したスコアは、ビルド時に格納されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-114">The matched score is stored at build time.</span></span> <span data-ttu-id="8d52b-115">すべての修飾子には値が指定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="8d52b-115">Every qualifier must have some value specified.</span></span> <span data-ttu-id="8d52b-116">リソースの選択方法について詳しくは、「[ResourceContext](resource-management-system.md#resourcecontext)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8d52b-116">See [ResourceContext](resource-management-system.md#resourcecontext) for details on how resources are chosen.</span></span>
- <span data-ttu-id="8d52b-117">`index` 要素は、アセットに対して実行される別個のインデックス化パスを定義します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-117">The `index` element defines discrete indexing passes that are done over the assets.</span></span> <span data-ttu-id="8d52b-118">それぞれのインデックス化パスは、どの[形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)を使うか、どのリソースをインデックス化するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-118">Each indexing pass determines the [format-specific indexers](makepri-exe-format-specific-indexers.md) to use, and which resources to index.</span></span>
- <span data-ttu-id="8d52b-119">`qualifiers` 要素は、他のリソースの継承元となる最初のファイルまたはフォルダーの初期修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-119">The `qualifiers` element sets the initial qualifiers for the first file or folder that other resources inherit.</span></span> <span data-ttu-id="8d52b-120">それぞれの修飾子要素は、有効な名前と値を持つ必要があります (「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="8d52b-120">Each qualifier element must have a valid name and value (see [Tailor your resources for language, scale, high contrast, and other qualifiers](tailor-resources-lang-scale-contrast.md)).</span></span>
- <span data-ttu-id="8d52b-121">`root` 属性は、インデックス パスの物理ファイルのパス ルートです。</span><span class="sxs-lookup"><span data-stu-id="8d52b-121">The `root` attribute is the path root of the physical file for the index pass.</span></span> <span data-ttu-id="8d52b-122">この属性には、相対値または絶対値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-122">It can be relative or absolute.</span></span> <span data-ttu-id="8d52b-123">相対値を指定した場合、値はコマンド ラインで指定したプロジェクト ルートの前に付加されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-123">If relative, it is appended to the project root that you provide in the command line.</span></span> <span data-ttu-id="8d52b-124">絶対値を指定した場合、値はインデックス パス ルートとして直接使用されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-124">If absolute, it is directly used as the index pass root.</span></span> <span data-ttu-id="8d52b-125">バックスラッシュまたはスラッシュを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-125">Back or forward slashes are acceptable.</span></span> <span data-ttu-id="8d52b-126">末尾のスラッシュは削除されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-126">Trailing slashes are trimmed.</span></span> <span data-ttu-id="8d52b-127">インデックス パスのルートは、すべてのリソースが相対的であると見なされるフォルダーを決定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-127">The root of the index pass determines the folder to which all resources are considered relative.</span></span>
- <span data-ttu-id="8d52b-128">`startIndexAt` 属性は、インデックス化に使用される初期シード ファイルまたはフォルダーです。</span><span class="sxs-lookup"><span data-stu-id="8d52b-128">The `startIndexAt` attribute is the initial seed file or folder used in indexing.</span></span> <span data-ttu-id="8d52b-129">これは、インデックス パス ルートに対する相対値です。</span><span class="sxs-lookup"><span data-stu-id="8d52b-129">It is relative to the index pass root.</span></span> <span data-ttu-id="8d52b-130">空の値は、インデックス パス ルート フォルダーと見なされます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-130">An empty value assumes the index pass root folder.</span></span>

## <a name="default-pri-config-file"></a><span data-ttu-id="8d52b-131">既定の PRI 構成ファイル</span><span class="sxs-lookup"><span data-stu-id="8d52b-131">Default PRI config file</span></span>

<span data-ttu-id="8d52b-132">MakePri.exe は、[createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が発行されたときに、この新しい、初期化された PRI 構成ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-132">MakePri.exe generates this new, initialized PRI config file when the [createconfig command](makepri-exe-command-options.md#createconfig-command) is issued.</span></span>

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

## <a name="packaging-element"></a><span data-ttu-id="8d52b-133">Packaging 要素</span><span class="sxs-lookup"><span data-stu-id="8d52b-133">Packaging element</span></span>

<span data-ttu-id="8d52b-134">`packaging` 要素は PRI 分割情報を定義します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-134">The `packaging` element defines PRI split information.</span></span> <span data-ttu-id="8d52b-135">`packaging` 要素のスキーマは、自動構成 (特定の次元に沿った `autoResourcePackage` のサポート) と手動構成の両方に対して定義します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-135">The schema for the `packaging` element is defined for both automatic (support for `autoResourcePackage` along a specific dimension), and manual configuration.</span></span>

<span data-ttu-id="8d52b-136">この例は、特定の次元に沿った `autoResourcePackage` の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="8d52b-136">This example shows how to use `autoResourcePackage` along a specific dimension.</span></span>

```xml
    <packaging>
        <autoResourcePackage qualifier="Language"/>
        <autoResourcePackage qualifier="Scale"/>
        <autoResourcePackage qualifier="DXFeatureLevel"/>
    </packaging>
```

<span data-ttu-id="8d52b-137">この例は、手動での `resourcePackage` の使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="8d52b-137">This example shows how to use manual `resourcePackage`.</span></span>

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

<span data-ttu-id="8d52b-138">MakePri.exe では、特定の次元に沿ったリソース PRI ファイルの生成が明示的にブロックされません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-138">MakePri.exe doesn't explicitly block generation of resource PRI files along any specific dimension.</span></span> <span data-ttu-id="8d52b-139">特定の次元セットに沿った制限は、MakeAppx.exe やパイプライン内の他のツールによって外部的に定義および実装します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-139">Restrictions along a certain set of dimensions are defined and implemented externally by either MakeAppx.exe or other tools in the pipeline.</span></span>

<span data-ttu-id="8d52b-140">MakePri.exe は、すべての `index` ノードの後に `packaging` ノードを解析して、すべての既定の修飾子を設定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-140">MakePri.exe parses the `packaging` element after all the `index` nodes to populate all the default qualifiers.</span></span> <span data-ttu-id="8d52b-141">MakePri.exe は、解析された情報をこれらのデータ構造に収集します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-141">MakePri.exe collects parsed info in these data structures.</span></span>

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

## <a name="resourcesisdeploymentmergeable-attribute"></a><span data-ttu-id="8d52b-142">resources@isDeploymentMergeable 属性</span><span class="sxs-lookup"><span data-stu-id="8d52b-142">resources@isDeploymentMergeable attribute</span></span>

<span data-ttu-id="8d52b-143">この属性は、次の操作を実行するフラグを PRI ファイル内に設定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-143">This attribute sets a flag in the PRI file that causes</span></span>

- <span data-ttu-id="8d52b-144">展開のマージで、この PRI ファイルがマージできることを識別する。</span><span class="sxs-lookup"><span data-stu-id="8d52b-144">Deployment merge to identify that this PRI file can merge.</span></span>
- <span data-ttu-id="8d52b-145">このフラグが設定され、リソース マネージャーがファイルによって所期されている場合、GetFullyQualifiedReference がエラーを返す。</span><span class="sxs-lookup"><span data-stu-id="8d52b-145">GetFullyQualifiedReference to return an error in case this flag is set and the resource manager has been initialized with a file.</span></span>

<span data-ttu-id="8d52b-146">この属性の既定値は `true` です。</span><span class="sxs-lookup"><span data-stu-id="8d52b-146">The default value of this attribute is `true`.</span></span> <span data-ttu-id="8d52b-147">Windows 10 をターゲットにする場合、MakePri.exe は PRI にフラグを設定するのみです。</span><span class="sxs-lookup"><span data-stu-id="8d52b-147">MakePri.exe only sets the flag in PRI if you target Windows 10.</span></span>

<span data-ttu-id="8d52b-148">Windows 10 をターゲットにする場合、リソース パックの作成時に `isDeploymentMergeable` を省略する (または明示的に `true` に設定する) ことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8d52b-148">We recommend that you omit `isDeploymentMergeable` (or set it explicitly to `true`) for resource pack creation if you target Windows 10.</span></span>

<span data-ttu-id="8d52b-149">`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `isDeploymentMergeable` の値をダンプ ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-149">MakePri.exe adds the value of `isDeploymentMergeable` to the dump file if `makepri dump` is run with the `/dt detailed` option.</span></span>

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

## <a name="resourcesmajorversion-attribute"></a><span data-ttu-id="8d52b-150">resources@majorVersion 属性</span><span class="sxs-lookup"><span data-stu-id="8d52b-150">resources@majorVersion attribute</span></span>

<span data-ttu-id="8d52b-151">この属性の既定値は 1 です。</span><span class="sxs-lookup"><span data-stu-id="8d52b-151">The default value for this attribute is 1.</span></span> <span data-ttu-id="8d52b-152">明示的な値を指定し、MakePri.exe ツールの推奨されなくなった `/VersionMajor(vma)` コマンド ライン オプションも使用している場合、構成ファイル内の値が優先されます。</span><span class="sxs-lookup"><span data-stu-id="8d52b-152">If you provide an explicit value, and you also use the deprecated `/VersionMajor(vma)` command-line option for the MakePri.exe tool, then the value in the config file takes precedence.</span></span>

<span data-ttu-id="8d52b-153">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-153">Here's an example.</span></span>

```xml
<resources majorVersion="2">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

## <a name="resourcestargetosversion-attribute"></a><span data-ttu-id="8d52b-154">resources@targetOsVersion 属性</span><span class="sxs-lookup"><span data-stu-id="8d52b-154">resources@targetOsVersion attribute</span></span>

<span data-ttu-id="8d52b-155">ターゲット オペレーティング システムのバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-155">Indicates the target operating system version.</span></span> <span data-ttu-id="8d52b-156">次の表は、サポートされている値を示しています。既定値は 6.3.0 です。</span><span class="sxs-lookup"><span data-stu-id="8d52b-156">The table below shows the values that are supported; the default value is 6.3.0.</span></span>

| <span data-ttu-id="8d52b-157">Value</span><span class="sxs-lookup"><span data-stu-id="8d52b-157">Value</span></span> | <span data-ttu-id="8d52b-158">意味</span><span class="sxs-lookup"><span data-stu-id="8d52b-158">Meaning</span></span> |
| ----- | ------- |
| <span data-ttu-id="8d52b-159">10.0.0</span><span class="sxs-lookup"><span data-stu-id="8d52b-159">10.0.0</span></span> | <span data-ttu-id="8d52b-160">Windows 10</span><span class="sxs-lookup"><span data-stu-id="8d52b-160">Windows 10</span></span> |
| <span data-ttu-id="8d52b-161">6.3.0 (既定)</span><span class="sxs-lookup"><span data-stu-id="8d52b-161">6.3.0 (default)</span></span> | <span data-ttu-id="8d52b-162">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="8d52b-162">Windows 8.1</span></span> |
| <span data-ttu-id="8d52b-163">6.2.1</span><span class="sxs-lookup"><span data-stu-id="8d52b-163">6.2.1</span></span> | <span data-ttu-id="8d52b-164">Windows 8</span><span class="sxs-lookup"><span data-stu-id="8d52b-164">Windows 8</span></span> |

<span data-ttu-id="8d52b-165">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-165">Here's an example.</span></span>

```xml
<resources targetOsVersion="10.0.0">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

<span data-ttu-id="8d52b-166">**注** Windows は PRI ファイルに関しては下位互換性がありますが、常に上位互換性があるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-166">**Note** Windows is backward compatible with respect to PRI files; but not always forward compatible.</span></span>

<span data-ttu-id="8d52b-167">`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `targetOsVersion` の値をダンプ ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-167">MakePri.exe adds the value of `targetOsVersion` to the dump file if `makepri dump` is run with the `/dt detailed` option.</span></span>

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

## <a name="validation-error-messages"></a><span data-ttu-id="8d52b-168">検証エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="8d52b-168">Validation error messages</span></span>

<span data-ttu-id="8d52b-169">エラー状況の例と対応するエラー メッセージを次に示します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-169">Here are some example error conditions, and the corresponding error message.</span></span>

| <span data-ttu-id="8d52b-170">条件</span><span class="sxs-lookup"><span data-stu-id="8d52b-170">Condition</span></span> | <span data-ttu-id="8d52b-171">重大度</span><span class="sxs-lookup"><span data-stu-id="8d52b-171">Severity</span></span> | <span data-ttu-id="8d52b-172">メッセージ</span><span class="sxs-lookup"><span data-stu-id="8d52b-172">Message</span></span> |
| --------- | -------- | ------- |
| <span data-ttu-id="8d52b-173">サポートされる値のいずれか以外の targetOsVersion が指定されている。</span><span class="sxs-lookup"><span data-stu-id="8d52b-173">A targetOsVersion other than one of the supported values is specified.</span></span> | <span data-ttu-id="8d52b-174">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-174">Error</span></span> | <span data-ttu-id="8d52b-175">構成が無効です。無効な targetOsVersion を指定します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-175">Invalid Configuration: Invalid targetOsVersion specified.</span></span> |
| <span data-ttu-id="8d52b-176">targetOsVersion "6.2.1" が指定されており、`packaging` 要素が存在する。</span><span class="sxs-lookup"><span data-stu-id="8d52b-176">A targetOsVersion of "6.2.1" is specified and a `packaging` element is present.</span></span> | <span data-ttu-id="8d52b-177">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-177">Error</span></span> | <span data-ttu-id="8d52b-178">構成が無効です。'パッケージ' ノードがこの targetOsVersion でサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-178">Invalid Configuration: 'Packaging' node is not supported with this targetOsVersion.</span></span> |
| <span data-ttu-id="8d52b-179">構成内に複数のモードが見つかった。</span><span class="sxs-lookup"><span data-stu-id="8d52b-179">More than one mode found in the configuration.</span></span> <span data-ttu-id="8d52b-180">たとえば、Manual と AutoResourcePackage が指定されている。</span><span class="sxs-lookup"><span data-stu-id="8d52b-180">For example, Manual and AutoResourcePackage specified.</span></span> | <span data-ttu-id="8d52b-181">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-181">Error</span></span> | <span data-ttu-id="8d52b-182">Invalid Configuration: 'packaging' node cannot have more than one mode of operation.</span><span class="sxs-lookup"><span data-stu-id="8d52b-182">Invalid Configuration: 'packaging' node cannot have more than one mode of operation.</span></span> |
| <span data-ttu-id="8d52b-183">既定の修飾子がリソース パッケージの下にリストされている。</span><span class="sxs-lookup"><span data-stu-id="8d52b-183">A default qualifier is listed under resource package.</span></span> | <span data-ttu-id="8d52b-184">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-184">Error</span></span> | <span data-ttu-id="8d52b-185">Invalid Configuration: <Qualifiername>=<QualifierValue> is a default qualifier and its candidates cannot be added to a resource package.</span><span class="sxs-lookup"><span data-stu-id="8d52b-185">Invalid Configuration: <Qualifiername>=<QualifierValue> is a default qualifier and its candidates cannot be added to a resource package.</span></span> |
| <span data-ttu-id="8d52b-186">AutoResourcePackage 修飾子に複数の修飾子が含まれる。</span><span class="sxs-lookup"><span data-stu-id="8d52b-186">AutoResourcePackage qualifier contains multiple qualifiers.</span></span> <span data-ttu-id="8d52b-187">たとえば、language_scale。</span><span class="sxs-lookup"><span data-stu-id="8d52b-187">For example, language_scale.</span></span> | <span data-ttu-id="8d52b-188">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-188">Error</span></span> | <span data-ttu-id="8d52b-189">構成が無効です。AutoResourcePackage を複数の修飾子ではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-189">Invalid Configuration : AutoResourcePackage with multiple qualifiers is not supported.</span></span> |
| <span data-ttu-id="8d52b-190">ResourcePackage QualifierSet に複数の修飾子が含まれる。</span><span class="sxs-lookup"><span data-stu-id="8d52b-190">ResourcePackage QualifierSet contains multiple qualifiers.</span></span> <span data-ttu-id="8d52b-191">たとえば、language-en-us_scale-100。</span><span class="sxs-lookup"><span data-stu-id="8d52b-191">For example, language-en-us_scale-100</span></span> | <span data-ttu-id="8d52b-192">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-192">Error</span></span> | <span data-ttu-id="8d52b-193">構成が無効です。QualifierSet を複数の修飾子ではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-193">Invalid Configuration : QualifierSet with multiple qualifiers is not supported.</span></span> |
| <span data-ttu-id="8d52b-194">重複するリソース パック名が見つかる。</span><span class="sxs-lookup"><span data-stu-id="8d52b-194">Duplicate resourcepack name found.</span></span> | <span data-ttu-id="8d52b-195">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-195">Error</span></span> | <span data-ttu-id="8d52b-196">構成が無効です。重複するリソース パック名<rpname>します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-196">Invalid Configuration : Duplicate resource pack name <rpname>.</span></span> |
| <span data-ttu-id="8d52b-197">2 つのリソース パッケージに同じ修飾子セットが定義されている。</span><span class="sxs-lookup"><span data-stu-id="8d52b-197">Same qualifier set defined in two resource packages.</span></span> | <span data-ttu-id="8d52b-198">エラー</span><span class="sxs-lookup"><span data-stu-id="8d52b-198">Error</span></span> | <span data-ttu-id="8d52b-199">構成が無効です。QualifierSet の複数のインスタンス"<qualifier tags>"が見つかりません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-199">Invalid Configuration: Multiple instances of QualifierSet "<qualifier tags>" found.</span></span> |
| <span data-ttu-id="8d52b-200">'ResourcePackage' ノードに対してリストされた QualifierSet の候補が見つからない。</span><span class="sxs-lookup"><span data-stu-id="8d52b-200">No candidates are found for the QualifierSet listed for 'ResourcePackage' node.</span></span> | <span data-ttu-id="8d52b-201">Warning</span><span class="sxs-lookup"><span data-stu-id="8d52b-201">Warning</span></span> | <span data-ttu-id="8d52b-202">構成が無効です。候補が検出されない<Resource Package Name>します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-202">Invalid Configuration: No candidates found for <Resource Package Name>.</span></span> |
| <span data-ttu-id="8d52b-203">'AutoResourcePackage' ノードの下にリストされた修飾子の候補が見つからない。</span><span class="sxs-lookup"><span data-stu-id="8d52b-203">No candidates found for qualifier listed under ‘AutoResourcePackage’ node.</span></span> | <span data-ttu-id="8d52b-204">Warning</span><span class="sxs-lookup"><span data-stu-id="8d52b-204">Warning</span></span> | <span data-ttu-id="8d52b-205">構成が無効です。修飾子の候補が検出されない<qualifier name>します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-205">Invalid Configuration: No candidates found for qualifier <qualifier name>.</span></span> <span data-ttu-id="8d52b-206">Resource Package not generated.</span><span class="sxs-lookup"><span data-stu-id="8d52b-206">Resource Package not generated.</span></span> |
| <span data-ttu-id="8d52b-207">モードが見つからない。</span><span class="sxs-lookup"><span data-stu-id="8d52b-207">None of the modes are found.</span></span> <span data-ttu-id="8d52b-208">つまり、空の 'packaging' ノードが見つかる。</span><span class="sxs-lookup"><span data-stu-id="8d52b-208">That is, empty 'packaging' node found.</span></span> | <span data-ttu-id="8d52b-209">Warning</span><span class="sxs-lookup"><span data-stu-id="8d52b-209">Warning</span></span> | <span data-ttu-id="8d52b-210">構成が無効です。パッケージ化モードが指定されていません。</span><span class="sxs-lookup"><span data-stu-id="8d52b-210">Invalid Configuration: No packaging mode specified.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="8d52b-211">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8d52b-211">Related topics</span></span>

* [<span data-ttu-id="8d52b-212">MakePri.exe で手動でのリソースをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="8d52b-212">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
* [<span data-ttu-id="8d52b-213">MakePri.exe のコマンド ライン オプション&mdash;createconfig コマンド</span><span class="sxs-lookup"><span data-stu-id="8d52b-213">MakePri.exe command-line options&mdash;createconfig command</span></span>](makepri-exe-command-options.md#createconfig-command)
* [<span data-ttu-id="8d52b-214">言語、スケール、ハイ コントラスト、およびその他の修飾子のためのリソースを調整します。</span><span class="sxs-lookup"><span data-stu-id="8d52b-214">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="8d52b-215">リソース管理システム&mdash;ResourceContext</span><span class="sxs-lookup"><span data-stu-id="8d52b-215">Resource Management System&mdash;ResourceContext</span></span>](resource-management-system.md#resourcecontext)