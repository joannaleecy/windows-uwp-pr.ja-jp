---
Description: In this scenario, we'll make a new app to represent our custom build system. We'll create a resource indexer and add strings and other kinds of resources to it. Then we'll generate and dump a PRI file.
title: シナリオ 1 文字列リソースとアセット ファイルから PRI ファイルを生成する
template: detail.hbs
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 9b14e413a5629dfb5447750e32c42c4efafef8fa
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7695684"
---
# <a name="scenario-1-generate-a-pri-file-from-string-resources-and-asset-files"></a>シナリオ 1: 文字列リソースとアセット ファイルから PRI ファイルを生成する
このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してカスタム ビルド システムを表す新しいアプリを作成します。 このカスタム ビルド システムの目的は、対象の UWP アプリの PRI ファイルを作成することです。 そのため、このチュートリアルの一部として、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルを作成します。

## <a name="new-project"></a>新しいプロジェクト
まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 **Visual C++ Windows コンソール アプリケーション** プロジェクトを作成し、*CBSConsoleApp* ("カスタム ビルド システムのコンソール アプリ" を表す) という名前を付けます。

**[ソリューション プラットフォーム]** ドロップダウンから *[x64]* を選択します。

## <a name="headers-static-library-and-dll"></a>ヘッダー、静的ライブラリ、dll
PRI API は、MrmResourceIndexer.h ヘッダー ファイル (`%ProgramFiles(x86)%\Windows Kits\10\Include\<WindowsTargetPlatformVersion>\um\` にインストールされます) で宣言されています。 ファイル `CBSConsoleApp.cpp` を開き、そのヘッダーと、その他の必要になるいくつかのヘッダーを含めます。

```cppwinrt
#include <string>
#include <windows.h>
#include <MrmResourceIndexer.h>
```

API は MrmSupport.dll に実装されています。MrmSupport.dll には、静的ライブラリ MrmSupport.lib にリンクすることでアクセスします。 プロジェクトの **[プロパティ]** を開き、**[リンカー]** > **[入力]** の順にクリックし、**AdditionalDependencies** を編集して `MrmSupport.lib` を追加します。

ソリューションをビルドし、`MrmSupport.dll` を `C:\Program Files (x86)\Windows Kits\10\bin\<WindowsTargetPlatformVersion>\x64\` からビルドの出力フォルダー (`C:\Users\%USERNAME%\source\repos\CBSConsoleApp\x64\Debug\` など) にコピーします。

次のヘルパー関数が必要になるため、`CBSConsoleApp.cpp` に追加します。

```cppwinrt
inline void ThrowIfFailed(HRESULT hr)
{
    if (FAILED(hr))
    {
        // Set a breakpoint on this line to catch Win32 API errors.
        throw new std::exception();
    }
}
```

`main()` 関数で、呼び出しを追加し、COM の初期化と初期化解除を行います。

```cppwinrt
int main()
{
    ::ThrowIfFailed(::CoInitializeEx(nullptr, COINIT_MULTITHREADED));
    
    // More code will go here.
    
    ::CoUninitialize();
}
```

## <a name="resource-files-belonging-to-the-target-uwp-app"></a>対象の UWP アプリに属するリソース ファイル
ここでは、その対象とする UWP アプリのリソースを表す、(文字列、およびその他の種類のリソースを含む) サンプルのリソース ファイルが必要になります。 これらは、もちろん、ファイル システム上の任意の場所に配置することができます。 ただし、このチュートリアルでは、すべてを 1 か所にまとめるために、CBSConsoleApp のプロジェクト フォルダーにそれらのファイルを配置すると便利です。 それらのリソース ファイルをファイル システムに追加するだけです。CBSConsoleApp プロジェクトには追加しません。

`CBSConsoleApp.vcxproj` を含む同じフォルダー内には、`UWPAppProjectRootFolder` という名前の新しいサブフォルダーを追加します。 新しいサブフォルダー内には、次のサンプル リソース ファイルを作成します。

### <a name="uwpappprojectrootfoldersample-imagepng"></a>\UWPAppProjectRootFolder\sample-image.png
このファイルには、任意の PNG 画像を含めることができます。

### <a name="uwpappprojectrootfolderresourcesresw"></a>\UWPAppProjectRootFolder\resources.resw
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString1">
        <value>LocalizedString1-neutral</value>
    </data>
    <data name="LocalizedString2">
        <value>LocalizedString2-neutral</value>
    </data>
    <data name="NeutralOnlyString">
        <value>NeutralOnlyString-neutral</value>
    </data>
</root>
```

### <a name="uwpappprojectrootfolderde-deresourcesresw"></a>\UWPAppProjectRootFolder\de-DE\resources.resw
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString2">
        <value>LocalizedString2-de-DE</value>
    </data>
</root>
```

### <a name="uwpappprojectrootfolderen-usresourcesresw"></a>\UWPAppProjectRootFolder\en-US\resources.resw
```xml
<?xml version="1.0"?>
<root>
    <data name="LocalizedString1">
        <value>LocalizedString1-en-US</value>
    </data>
    <data name="EnOnlyString">
        <value>EnOnlyString-en-US</value>
    </data>
</root>
```

## <a name="index-the-resources-and-create-a-pri-file"></a>リソースにインデックスを付け、PRI ファイルを作成する
`main()` 関数で、COM を初期化するための呼び出しの前に、必要となるいくつかの文字列を宣言します。また、PRI ファイルを生成する出力フォルダーも作成します。

```cppwinrt
std::wstring projectRootFolderUWPApp{ L"UWPAppProjectRootFolder" };
std::wstring generatedPRIsFolder{ projectRootFolderUWPApp + L"\\Generated PRIs" };
std::wstring filePathPRI{ generatedPRIsFolder + L"\\resources.pri" };
std::wstring filePathPRIDumpBasic{ generatedPRIsFolder + L"\\resources-pri-dump-basic.xml" };

::CreateDirectory(generatedPRIsFolder.c_str(), nullptr);
```

COM を初期化するための呼び出しの直後に、リソース インデクサー ハンドルを宣言し、[**MrmCreateResourceIndexer**]() を呼び出してリソース インデクサーを作成します。

```cppwinrt
MrmResourceIndexerHandle indexer;
::ThrowIfFailed(::MrmCreateResourceIndexer(
    L"OurUWPApp",
    projectRootFolderUWPApp.c_str(),
    MrmPlatformVersion::MrmPlatformVersion_Windows10_0_0_0,
    L"language-en_scale-100_contrast-standard",
    &indexer));
```

**MrmCreateResourceIndexer** に渡される引数について、以下に示します。

- 後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップ名として使用する、対象の UWP アプリのパッケージ ファミリ名です。
- 対象の UWP アプリのプロジェクト ルートです。 つまり、リソース ファイルのパスです。 これは、同じリソース インデクサーへの以降の API 呼び出しでそのルートの相対パスを指定できるようにするために指定します。
- 対象にする Windows のバージョンです。
- 既定のリソース修飾子の一覧です。
- 関数で設定できるようにするための、リソース インデクサー ハンドルへのポインターです。

次の手順では、先ほど作成したリソース インデクサーにリソースを追加します。 `resources.resw`  は、対象の UWP アプリの中立的な文字列を含むリソース ファイル (.resw) です。 その内容を表示する場合は、(このトピック内で) 上方向にスクロールします。 `de-DE\resources.resw`  にはドイツ語の文字列、`en-US\resources.resw` には英語の文字列が含まれます。 リソース ファイル内の文字列リソースをリソース インデクサーに追加するには、[**MrmIndexResourceContainerAutoQualifiers**]() を呼び出します。 3 番目に、[**MrmIndexFile**]() 関数を呼び出して、中立的なイメージ リソースを含むファイルをリソース インデクサーに追加します。

```cppwinrt
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"de-DE\\resources.resw"));
::ThrowIfFailed(::MrmIndexResourceContainerAutoQualifiers(indexer, L"en-US\\resources.resw"));
::ThrowIfFailed(::MrmIndexFile(indexer, L"ms-resource:///Files/sample-image.png", L"sample-image.png", L""));
```

**MrmIndexFile** の呼び出しで、値 L"ms-resource:///Files/sample-image.png" はリソース uri です。 最初のパス セグメントは "Files" で、これが後でこのリソース インデクサーから PRI ファイルを生成したときにリソース マップのサブツリー名として使用されます。

リソース ファイルに関するリソース インデクサーの概要を説明したので、[**MrmCreateResourceFile**]() 関数を呼び出してディスクに PRI ファイルを自動的に生成できるようにしましょう。

```cppwinrt
::ThrowIfFailed(::MrmCreateResourceFile(indexer, MrmPackagingModeStandaloneFile, MrmPackagingOptionsNone, generatedPRIsFolder.c_str()));
```

この時点で、`resources.pri` という名前の PRI ファイルが `Generated PRIs` という名前のフォルダー内に作成されました。 これで、リソース インデクサーの作業が完了したので、[**MrmDestroyIndexerAndMessages**]() を呼び出して、そのハンドルを破棄し、割り当てられたマシン リソースをリリースします。

```cppwinrt
::ThrowIfFailed(::MrmDestroyIndexerAndMessages(indexer));
```

PRI ファイルはバイナリであるため、バイナリ PRI ファイルをそれに対応する XML にダンプすると、先ほど生成したものを表示するのが簡単になります。 [**MrmDumpPriFile**]() の呼び出しによりこれが行われます。

```cppwinrt
::ThrowIfFailed(::MrmDumpPriFile(filePathPRI.c_str(), nullptr, MrmDumpType::MrmDumpType_Basic, filePathPRIDumpBasic.c_str()));
```

**MrmDumpPriFile** に渡される引数について、以下に示します。

- ダンプする PRI ファイルのパス。 この呼び出しでリソース インデクサーは使用しません (先ほどそれを破棄しました)。そのため完全なファイル パスを指定する必要があります。
- スキーマ ファイルはありません。 スキーマの概要については、後のトピックで説明します。
- 単なる基本情報です。
- 作成する XML ファイルのパスです。

これは、ここで XML にダンプされる PRI ファイルに含まれる内容です。

```xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<PriInfo>
    <ResourceMap name="OurUWPApp" version="1.0" primary="true">
        <Qualifiers>
            <Language>en-US,de-DE</Language>
        </Qualifiers>
        <ResourceMapSubtree name="Files">
            <NamedResource name="sample-image.png" uri="ms-resource://OurUWPApp/Files/sample-image.png">
                <Candidate type="Path">
                    <Value>sample-image.png</Value>
                </Candidate>
            </NamedResource>
        </ResourceMapSubtree>
        <ResourceMapSubtree name="resources">
            <NamedResource name="EnOnlyString" uri="ms-resource://OurUWPApp/resources/EnOnlyString">
                <Candidate qualifiers="Language-en-US" isDefault="true" type="String">
                    <Value>EnOnlyString-en-US</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="LocalizedString1" uri="ms-resource://OurUWPApp/resources/LocalizedString1">
                <Candidate qualifiers="Language-en-US" isDefault="true" type="String">
                    <Value>LocalizedString1-en-US</Value>
                </Candidate>
                <Candidate type="String">
                    <Value>LocalizedString1-neutral</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="LocalizedString2" uri="ms-resource://OurUWPApp/resources/LocalizedString2">
                <Candidate qualifiers="Language-de-DE" type="String">
                    <Value>LocalizedString2-de-DE</Value>
                </Candidate>
                <Candidate type="String">
                    <Value>LocalizedString2-neutral</Value>
                </Candidate>
            </NamedResource>
            <NamedResource name="NeutralOnlyString" uri="ms-resource://OurUWPApp/resources/NeutralOnlyString">
                <Candidate type="String">
                    <Value>NeutralOnlyString-neutral</Value>
                </Candidate>
            </NamedResource>
        </ResourceMapSubtree>
    </ResourceMap>
</PriInfo>
```

情報は、対象の UWP アプリのパッケージ ファミリ名が付いたリソース マップから始まります。 リソース マップで囲まれているのは 2 つのリソース マップ サブツリーです。1 つはインデックスを作成したファイル リソース用で、もう 1 つは文字列リソース用です。 パッケージ ファミリ名がすべてのリソース URI に挿入されているのがわかります。

最初の文字列リソースは、`en-US\resources.resw` の *EnOnlyString* で候補が 1 つだけあります (その候補は *language-en-US* 修飾子に一致します)。 次のリソースは、`resources.resw` および `en-US\resources.resw` の *LocalizedString1* です。 そのため、*language-en-US* に一致する候補と、任意のコンテキストに一致するフォールバックの中立の候補の 2 つの候補があります。 同様に、*LocalizedString2* には、*language-de-DE* と中立の 2 つの候補があります。 最後に、*NeutralOnlyString* は中立の形式だけに存在します。 その名前を指定して、そのリソースがローカライズされるものではないということを明確にしています。

## <a name="summary"></a>まとめ
このシナリオでは、[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用してリソース インデクサーを作成する方法を示しました。 文字列リソースとアセット ファイルをリソース インデクサーに追加しました。 次に、リソース インデクサーを使用して、バイナリ PRI ファイルを生成しました。 最後に、期待した情報が含まれていることを確認できるように、XML の形式でバイナリ PRI ファイルをダンプしました。

## <a name="important-apis"></a>重要な API
* [パッケージ リソース インデックス (PRI) リファレンス](https://msdn.microsoft.com/library/windows/desktop/mt845690)

## <a name="related-topics"></a>関連トピック
* [パッケージ リソース インデックス (PRI) API とカスタム ビルド システム](pri-apis-custom-build-systems.md)
