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
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2801249"
---
# <a name="makepriexe-configuration-file"></a>MakePri.exe 構成ファイル

ここでは、[MakePri.exe](compile-resources-manually-with-makepri.md) XML 構成ファイル (PRI 構成ファイルとも呼ばれる) のスキーマについて説明します。 MakePri.exe ツールには、新しい、初期化された PRI 構成ファイルを作成するために使用できる [createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が含まれています。

> [!NOTE]
> Windows ソフトウェア開発キットのインストール中に**Windows SDK** UWP 管理アプリのオプションをオンにすると、MakePri.exe がインストールされています。 パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびフォルダーの他のアーキテクチャの名前の)。 たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。

PRI 構成ファイルは、どのリソースをどのようにインデックス化するかを制御します。 構成 XML は、次のスキーマに準拠する必要があります。

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

- `default` 要素は、実行時コンテキストがどのリソース候補にも一致しないときにリソースを解決するために使う必要があるコンテキスト (言語、スケール、コントラストなど) を指定します。 このコンテキストはビルド時に指定され、変更されないため、リソースは、修飾子が作成されるときにこのコンテキストに解決されます。 一致したスコアは、ビルド時に格納されます。 すべての修飾子には値が指定されている必要があります。 リソースの選択方法について詳しくは、「[ResourceContext](resource-management-system.md#resourcecontext)」をご覧ください。
- `index` 要素は、アセットに対して実行される別個のインデックス化パスを定義します。 それぞれのインデックス化パスは、どの[形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)を使うか、どのリソースをインデックス化するかを決定します。
- `qualifiers` 要素は、他のリソースの継承元となる最初のファイルまたはフォルダーの初期修飾子を設定します。 それぞれの修飾子要素は、有効な名前と値を持つ必要があります (「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください)。
- `root` 属性は、インデックス パスの物理ファイルのパス ルートです。 この属性には、相対値または絶対値を指定できます。 相対値を指定した場合、値はコマンド ラインで指定したプロジェクト ルートの前に付加されます。 絶対値を指定した場合、値はインデックス パス ルートとして直接使用されます。 バックスラッシュまたはスラッシュを使うことができます。 末尾のスラッシュは削除されます。 インデックス パスのルートは、すべてのリソースが相対的であると見なされるフォルダーを決定します。
- `startIndexAt` 属性は、インデックス化に使用される初期シード ファイルまたはフォルダーです。 これは、インデックス パス ルートに対する相対値です。 空の値は、インデックス パス ルート フォルダーと見なされます。

## <a name="default-pri-config-file"></a>既定の PRI 構成ファイル

MakePri.exe は、[createconfig コマンド](makepri-exe-command-options.md#createconfig-command)が発行されたときに、この新しい、初期化された PRI 構成ファイルを生成します。

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

## <a name="packaging-element"></a>Packaging 要素

`packaging` 要素は PRI 分割情報を定義します。 `packaging` 要素のスキーマは、自動構成 (特定の次元に沿った `autoResourcePackage` のサポート) と手動構成の両方に対して定義します。

この例は、特定の次元に沿った `autoResourcePackage` の使い方を示しています。

```xml
    <packaging>
        <autoResourcePackage qualifier="Language"/>
        <autoResourcePackage qualifier="Scale"/>
        <autoResourcePackage qualifier="DXFeatureLevel"/>
    </packaging>
```

この例は、手動での `resourcePackage` の使い方を示しています。

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

MakePri.exe では、特定の次元に沿ったリソース PRI ファイルの生成が明示的にブロックされません。 特定の次元セットに沿った制限は、MakeAppx.exe やパイプライン内の他のツールによって外部的に定義および実装します。

MakePri.exe は、すべての `index` ノードの後に `packaging` ノードを解析して、すべての既定の修飾子を設定します。 MakePri.exe は、解析された情報をこれらのデータ構造に収集します。

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

## <a name="resourcesisdeploymentmergeable-attribute"></a>resources@isDeploymentMergeable 属性

この属性は、次の操作を実行するフラグを PRI ファイル内に設定します。

- 展開のマージで、この PRI ファイルがマージできることを識別する。
- このフラグが設定され、リソース マネージャーがファイルによって所期されている場合、GetFullyQualifiedReference がエラーを返す。

この属性の既定値は `true` です。 Windows 10 をターゲットにする場合、MakePri.exe は PRI にフラグを設定するのみです。

Windows 10 をターゲットにする場合、リソース パックの作成時に `isDeploymentMergeable` を省略する (または明示的に `true` に設定する) ことをお勧めします。

`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `isDeploymentMergeable` の値をダンプ ファイルに追加します。

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

## <a name="resourcesmajorversion-attribute"></a>resources@majorVersion 属性

この属性の既定値は 1 です。 明示的な値を指定し、MakePri.exe ツールの推奨されなくなった `/VersionMajor(vma)` コマンド ライン オプションも使用している場合、構成ファイル内の値が優先されます。

次に例を示します。

```xml
<resources majorVersion="2">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

## <a name="resourcestargetosversion-attribute"></a>resources@targetOsVersion 属性

ターゲット オペレーティング システムのバージョンを指定します。 次の表は、サポートされている値を示しています。既定値は 6.3.0 です。

| 値 | 意味 |
| ----- | ------- |
| 10.0.0 | Windows 10 |
| 6.3.0 (既定) | Windows 8.1 |
| 6.2.1 | Windows 8 |

次に例を示します。

```xml
<resources targetOsVersion="10.0.0">
  <packaging ... />
  <index root="\" startIndexAt="\">
    ...
  </index>
</resources>
```

**注** Windows は PRI ファイルに関しては下位互換性がありますが、常に上位互換性があるわけではありません。

`makepri dump` を `/dt detailed` オプションを指定して実行する場合、MakePri.exe は `targetOsVersion` の値をダンプ ファイルに追加します。

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

## <a name="validation-error-messages"></a>検証エラー メッセージ

エラー状況の例と対応するエラー メッセージを次に示します。

| 状況 | 重大度 | メッセージ |
| --------- | -------- | ------- |
| サポートされる値のいずれか以外の targetOsVersion が指定されている。 | エラー | Invalid Configuration: Invalid targetOsVersion specified. |
| targetOsVersion "6.2.1" が指定されており、`packaging` 要素が存在する。 | エラー | Invalid Configuration: 'Packaging' node is not supported with this targetOsVersion. |
| 構成内に複数のモードが見つかった。 たとえば、Manual と AutoResourcePackage が指定されている。 | エラー | Invalid Configuration: 'packaging' node cannot have more than one mode of operation. |
| 既定の修飾子がリソース パッケージの下にリストされている。 | エラー | Invalid Configuration: <Qualifiername>=<QualifierValue> is a default qualifier and its candidates cannot be added to a resource package. |
| AutoResourcePackage 修飾子に複数の修飾子が含まれる。 たとえば、language_scale。 | エラー | Invalid Configuration : AutoResourcePackage with multiple qualifiers is not supported. |
| ResourcePackage QualifierSet に複数の修飾子が含まれる。 たとえば、language-en-us_scale-100。 | エラー | Invalid Configuration : QualifierSet with multiple qualifiers is not supported. |
| 重複するリソース パック名が見つかる。 | エラー | Invalid Configuration : Duplicate resource pack name <rpname>. |
| 2 つのリソース パッケージに同じ修飾子セットが定義されている。 | エラー | Invalid Configuration: Multiple instances of QualifierSet "<qualifier tags>" found. |
| 'ResourcePackage' ノードに対してリストされた QualifierSet の候補が見つからない。 | 警告 | Invalid Configuration: No candidates found for <Resource Package Name>. |
| 'AutoResourcePackage' ノードの下にリストされた修飾子の候補が見つからない。 | 警告 | Invalid Configuration: No candidates found for qualifier <qualifier name>. Resource Package not generated. |
| モードが見つからない。 つまり、空の 'packaging' ノードが見つかる。 | 警告 | Invalid Configuration: No packaging mode specified. |

## <a name="related-topics"></a>関連トピック

* [MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)
* [MakePri.exe のコマンド ライン オプション: createconfig コマンド](makepri-exe-command-options.md#createconfig-command)
* [言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)
* [リソース管理システム: ResourceContext](resource-management-system.md#resourcecontext)