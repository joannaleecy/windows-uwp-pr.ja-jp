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
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4749688"
---
# <a name="makepriexe-format-specific-indexers"></a>MakePri.exe の形式に固有のインデクサー

このトピックでは、リソースのインデックスを生成するために [MakePri.exe](compile-resources-manually-with-makepri.md) ツールによって使われる形式に固有のインデクサーについて説明します。

> [!NOTE]
> MakePri.exe は、Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションを確認する場合にインストールされます。 パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダーの)。 たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。

MakePri.exe は、通常、`new`、`versioned`、`resourcepack` コマンドと共に使用されます。 「[MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)」をご覧ください。 これらのオプションを使うと、ソース ファイルがインデックス化され、リソースのインデックスが生成されます。 MakePri.exe は、さまざまな別個のインデクサーを使って異なるソース リソース ファイルまたはリソースのコンテナーを読み取ります。 最も単純なインデクサーは、`.jpg` 画像 や `.png` 画像などのフォルダーの内容をインデックス化するフォルダー インデクサーです。

形式に固有のインデクサーは、[MakePri.exe 構成ファイル](makepri-exe-configuration.md)の `<index>` 要素内で `<indexer-config>` 要素を指定することによって識別します。 `type` 属性は、使われる形式に固有のインデクサーを識別します。

インデックス化の処理中にリソース コンテナーが検出されると、その内容がインデックス化されます (コンテナー自体はインデックスに追加されません)。 たとえば、フォルダー インデクサーによって検出された `.resjson` ファイルは `.resjson` インデクサーによってインデックス化されます。このとき、`.resjson` ファイル自体はインデックスに表示されません。 **注** こうした状態になるには、そのコンテナーに関連付けられたインデクサーの `<indexer-config>` 要素が構成ファイルに記述されている必要があります。

通常、フォルダーや `.resw` ファイルなどのコンテナー エンティティで検出された修飾子は、コンテナー エンティティ内のすべてのリソース (フォルダー内のファイルや `.resw` ファイル内の文字列など) に適用されます。

## <a name="folder"></a>フォルダー

フォルダー インデクサーは、`type` 属性 FOLDER で識別されます。 フォルダーの内容をインデックス化し、フォルダー名とファイル名からリソース修飾子を決定します。 このインデクサーの構成要素は、次のスキーマに準拠します。

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

`qualifierDelimiter` 属性は、拡張子を除いてファイル名に指定される修飾子の前の文字を指定します。 既定値は "." です。

## <a name="pri"></a>PRI

PRI インデクサーは、`type` 属性 PRI で識別されます。 PRI ファイルの内容をインデックス化します。 通常、別のアセンブリ、DLL、SDK、またはクラス ライブラリ内に格納されたリソースをアプリの PRI にインデックス化する場合にこのインデクサーを使います。

PRI ファイルに含まれるすべてのリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。 ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。 リソース マップはマージされます。

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

## <a name="priinfo"></a>PriInfo

PriInfo インデクサーは、`type` 属性 PRIINFO で識別されます。 詳細ダンプ ファイルの内容をインデックス化します。 詳細なダンプ ファイルを生成するには、`/dt detailed` オプションを指定して `makepri dump` を実行します。 このインデクサーの構成要素は、次のスキーマに準拠します。

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

この構成要素では、オプションの属性を使って、PriInfo インデクサーの動作を構成できます。 `emitStrings` と `emitPaths` の既定値は `true` です。 `emitStrings` が `true` である場合、`type` 属性が "String" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。 'emitPaths' が `true` である場合、`type` 属性が "Path" に設定されているリソース候補がインデックスに含められます。それ以外の場合、リソース候補は除外されます。

次に示す構成例では、種類が String のリソースを含める一方で Path のリソースをスキップしています。

```xml
<indexer-config type="priinfo" emitStrings="true" emitPaths="false" />
```

インデックス化する場合、ダンプ ファイルは拡張子 `.pri.xml` で終了し、次のスキーマに準拠する必要があります。

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

MakePri.exe では、'Basic'、'Detailed'、'Schema'、'Summary' のダンプの種類がサポートされます。 PriInfo インデクサーが読み取ることができる種類のダンプが生成されるように MakePri.exe を構成するには、`dump` コマンドを使うときに "/DumpType Detailed" を指定します。

`.pri.xml` ファイルのいくつかの要素は MakePri.exe でスキップされます。 これらの要素は、インデックスの作成中に計算されるか、MakePri.exe 構成ファイル内で指定されています。 ダンプ ファイルに含まれるリソース名、修飾子、値は、新しい PRI ファイルに直接保持されます。 ただし、トップ レベルのリソース マップは最終的な PRI に保持されません。 リソース マップは、インデックス化の一部としてマージされます。

これは、ダンプ ファイルの有効な String 型リソースの例です。

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

これは、ダンプ ファイルの、2 つの候補が含まれた有効な Path 型リソースの例です。

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

## <a name="resfiles"></a>ResFiles

ResFiles インデクサーは、`type` 属性 RESFILES で識別されます。 `.resfiles` ファイルの内容をインデックス化します。 このインデクサーの構成要素は、次のスキーマに準拠します。

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

`.resfiles` ファイルは、ファイル パスのフラットな一覧が格納されたテキスト ファイルです。 `.resfiles` ファイルには、"//" コメントを格納できます。 次に例を示します。

```
Strings\component1\fr\elements.resjson
Images\logo.scale-100.png
Images\logo.scale-140.png
Images\logo.scale-180.png
```

## <a name="resjson"></a>ResJSON

ResJSON インデクサーは、`type` 属性 RESJSON で識別されます。 文字列リソース ファイルである `.resjson` ファイルの内容をインデックス化します。 このインデクサーの構成要素は、次のスキーマに準拠します。

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

`.resjson` ファイルは JSON テキストを格納します ([JavaScript Object Notation (JSON) の application/json メディア型に関するページ](http://www.ietf.org/rfc/rfc4627.txt)を参照)。 ファイルには、階層プロパティを持つ単一の JSON オブジェクトが含まれている必要があります。 それぞれのプロパティは、別の JSON オブジェクトか、文字列値である必要があります。

名前が下線 ("_") で始まる JSON プロパティは最終的な PRI ファイルにコンパイルされませんが、ログ ファイル内で保持されます。

ファイルには "//" コメントを格納できます。これらのコメントは、解析時に無視されます。

`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。 通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。 既定は空白です。

## <a name="resw"></a>ResW

ResW インデクサーは、`type` 属性 RESW で識別されます。 文字列リソース ファイルである `.resw` ファイルの内容をインデックス化します。 このインデクサーの構成要素は、次のスキーマに準拠します。

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

`.resw` ファイルは、次のスキーマに準拠する XML ファイルです。

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

`convertDotsToSlashes` 属性は、リソース名 (データ要素名属性) に見つかったすべてのドット (".") 文字をスラッシュ ("/") に変換します (ただし、"[" と "]" の間に配置されたドット文字は除きます)。

`initialPath` 属性を指定すると、リソース名の前にこの初期パスが追加され、すべてのリソースがこの初期パスに配置されます。 通常、クラス ライブラリ リソースをインデックス化する場合にこの属性を使います。 既定は空白です。

## <a name="related-topics"></a>関連トピック

* [MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)
* [MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)
* [MakePri.exe 構成ファイル](makepri-exe-configuration.md)
* [JavaScript Object Notation (JSON) の application/json メディア型に関するページ](http://www.ietf.org/rfc/rfc4627.txt)