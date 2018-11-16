---
author: stevewhims
Description: At build time, the Resource Management System creates an index of all the different variants of the resources that are packaged up with your app. At run-time, the system detects the user and machine settings that are in effect and loads the resources that are the best match for those settings.
title: リソース管理システム
template: detail.hbs
ms.author: stwhi
ms.date: 10/20/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: b80eda57ff700d732ba2402582ed6402acca4fc6
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6985798"
---
# <a name="resource-management-system"></a>リソース管理システム
リソース管理システムには、ビルド時と実行時の両方の機能があります。 ビルド時に、システムは、アプリとしてパッケージ化されているリソースのさまざまなバリエーションすべてのインデックスを作成します。 このインデックスがパッケージ リソース インデックス (PRI) であり、アプリのパッケージにも含まれています。 実行時に、システムは、有効になっているユーザーやコンピューターの設定を検出し、PRI でその情報を参照して、それらの設定に最適なリソースを自動的に読み込みます。

## <a name="package-resource-index-pri-file"></a>パッケージ リソース インデックス (PRI) ファイル
すべてのアプリ パッケージには、アプリ内のリソースのバイナリ インデックスが格納されている必要があります。 このインデックスはビルド時に作成され、1 つまたは複数のパッケージ リソース インデックス (PRI) ファイルに含まれています。

- PRI ファイルには、実際の文字列リソースと、パッケージ内のさまざまなファイルを参照するファイル パスのインデックス付きセットが格納されます。
- パッケージには、通常、言語ごとに 1 つの、resources.pri という名前の PRI ファイルが含まれます。
- 各パッケージのルートにある resources.pri ファイルは、[**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) がインスタンス化されたときに自動的に読み込まれます。
- PRI ファイルを作成したりダンプしたりするには、[MakePRI.exe](compile-resources-manually-with-makepri.md) というツールを使います。
- 既に Visual Studio のコンパイル ワークフローに統合されているため、一般的なアプリの開発では、MakePRI.exe は必要ありません。 また、Visual Studio は専用の UI で PRI ファイルの編集をサポートしています。 ただし、ローカライズ担当者やローカライズ担当者が使うツールでは、MakePRI.exe が必要になる場合があります。
- 各 PRI ファイルは、リソース マップと呼ばれる、リソースの名前付きコレクションを含みます。 パッケージの PRI ファイルが読み込まれたときに、リソース マップ名がパッケージ識別名と一致するかが確認されます。
- PRI ファイルにはデータのみが格納され、移植可能な実行可能ファイル (PE) 形式は使用されません。 PRI ファイルは、Windows 向けのリソース形式としてデータ専用に設計されています。 PRI ファイルは、Win32 アプリ モデルの DLL に含まれていたリソースに代わるものです。
- PRI ファイルのサイズ制限は、64 キロバイトです。

## <a name="uwp-api-access-to-app-resources"></a>アプリ リソースへの UWP API のアクセス

### <a name="basic-functionality-resourceloader"></a>基本機能 (ResourceLoader)
プログラムによってアプリ リソースにアクセスする最も簡単な方法は、[**Windows.ApplicationModel.Resources**](/uwp/api/windows.applicationmodel.resources?branch=live) 名前空間と [**ResourceLoader**](/uwp/api/windows.applicationmodel.resources.resourceloader?branch=live) クラスを使う方法です。 **ResourceLoader** を使うと、一連のリソース ファイル、参照ライブラリ、または他のパッケージの文字列リソースへの基本的なアクセスが可能になります。

### <a name="advanced-functionality-resourcemanager"></a>高度な機能 (ResourceManager)
[**Windows.ApplicationModel.Resources.Core**](/uwp/api/windows.applicationmodel.resources.core?branch=live) 名前空間の [**ResourceManager**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live) クラスは、リソースに関する追加情報 (列挙、検査など) を提供します。 このクラスは、**ResourceLoader** クラスが提供する情報よりも多くの情報を提供します。

[**NamedResource**](/uwp/api/windows.applicationmodel.resources.core.namedresource?branch=live) オブジェクトは、複数の言語またはその他の修飾されたバリアントを持つ個別の論理リソースです。 `Header1` などの文字列リソース識別子や、`logo.jpg` などのリソース ファイル名を持つ、アセットやリソースの論理ビューを記述します。

[**ResourceCandidate**](/uwp/api/windows.applicationmodel.resources.core.resourcecandidate?branch=live) オブジェクトは、英語向けの文字列 "Hello World" や **scale-100** 解像度に固有の修飾子付きのイメージ リソースである "logo.scale-100.jpg" など、単一の具象リソース値と修飾子の組み合わせです。

アプリで使うことができるリソースは、[**ResourceMap**](/uwp/api/windows.applicationmodel.resources.core.resourcemap?branch=live) オブジェクトを使ってアクセスできる階層コレクションに格納されます。 **ResourceManager** クラスを使うと、アプリで使われる各種のトップレベルの **ResourceMap** インスタンスにアクセスできます。これらのインスタンスは、アプリのさまざまなパッケージに対応しています。 [**MainResourceMap**](/uwp/api/windows.applicationmodel.resources.core.resourcemanager.MainResourceMap) の値は、参照されているフレームワーク パッケージではなく現在のアプリ パッケージのリソース マップに対応しています。 それぞれの **ResourceMap** には、パッケージのマニフェストに指定されたパッケージ名に基づく名前が付けられます。 **ResourceMap** には、**NamedResource** オブジェクトが格納されているサブツリー (「[**ResourceMap.GetSubtree**](/uwp/api/windows.applicationmodel.resources.core.resourcemap.getsubtree?branch=live)」をご覧ください) が含まれています。 通常、サブツリーは、リソースが含まれるリソース ファイルに対応します。 詳しくは、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](localize-strings-ui-manifest.md)と[表示倍率、テーマ、ハイ コントラスト、その他の設定に合わせた画像とアセットの読み込み](images-tailored-for-scale-theme-contrast.md)」をご覧ください。

次に例を示します。

```csharp
// using Windows.ApplicationModel.Resources.Core;
ResourceMap resourceMap =  ResourceManager.Current.MainResourceMap.GetSubtree("Resources");
ResourceContext resourceContext = ResourceContext.GetForCurrentView()
var str = resourceMap.GetValue("String1", resourceContext).ValueAsString;
```

**注** リソース識別子は、URI (Uniform Resource Identifier) セマンティクスに応じて URI フラグメントとして処理されます。 たとえば、`GetValue("Caption%20")` は `GetValue("Caption ")` として処理されます。 リソース識別子で "?" や "#" を使うとリソース パスの評価がそこで中断されるので、使わないでください。 たとえば、"MyResource?3" は "MyResource" として扱われます。

**ResourceManager** は、アプリの文字列リソースへのアクセスをサポートするだけでなく、さまざまなファイル リソースを列挙し検査する機能も保持します。 ファイルとその他のリソース (ファイル内から提供されるリソース) との衝突を回避するために、すべてのインデックス付きファイル パスは、予約済みの "Files" **ResourceMap** サブツリーに配置されます。 たとえば、ファイル `\Images\logo.png` は、リソース名 `Files/images/logo.png` に対応します。

[**StorageFile**](/uwp/api/Windows.Storage.StorageFile?branch=live) API は、リソースとしてのファイルへの参照を透過的に処理するため、一般的な用法のシナリオに適しています。 **ResourceManager** は、現在のコンテキストをオーバーライドする必要がある場合など、高度なシナリオについてのみ使用してください。

### <a name="resourcecontext"></a>ResourceContext
リソース候補は、リソース修飾子の値 (言語、スケール、コントラストなど) のコレクションである特定の [**ResourceContext**](/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext?branch=live) に基づいて選ばれます。 既定のコンテキストでは、上書きされない限り、それぞれの修飾子の値に対してアプリの現在の構成が使われます。 たとえば、画像などのリソースはスケールで修飾することができます。スケールはモニターごとに異なり、したがってアプリケーション ビューごとに異なります。 この理由から、アプリケーション ビューはそれぞれ別個の既定のコンテキストを持ちます。 特定のビューの既定のコンテキストは [**ResourceContext.GetForCurrentView**](/uwp/api/windows.applicationmodel.resources.core.resourcecontext.GetForCurrentView) を使って取得することができます。 リソース候補を取得するときは常に **ResourceContext** インスタンスを渡して、特定のビューに最も適した値を取得する必要があります。

## <a name="important-apis"></a>重要な API
* [ResourceLoader](/uwp/api/windows.applicationmodel.resources.resourceloader?branch=live)
* [ResourceManager](/uwp/api/windows.applicationmodel.resources.core.resourcemanager?branch=live)
* [ResourceContext](/uwp/api/windows.applicationmodel.resources.core.resourcecontext?branch=live)

## <a name="related-topics"></a>関連トピック
* [UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](localize-strings-ui-manifest.md)
* [表示倍率、テーマ、ハイ コントラスト、その他の設定に合わせた画像とアセットの読み込み](images-tailored-for-scale-theme-contrast.md)
