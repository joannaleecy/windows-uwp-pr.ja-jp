---
author: QuinnRadich
title: 年 2018年 8 月で Windows ドキュメントの新機能 - UWP アプリの開発
description: Windows 10 年 2018年 8 月開発ドキュメント、新機能、ビデオ、サンプル、および開発者向けのガイダンスが追加されました。
keywords: 新機能、更新、機能、開発については、Windows 10、年 8 月
ms.author: quradic
ms.date: 8/9/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 06eef0c115675ba9673a81459c91e0f08f6fab71
ms.sourcegitcommit: be5b71a8ec7b686d5f93d56d10cb9a50c3c5bb4a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2018
ms.locfileid: "2748872"
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2018"></a>年 2018年 8 月では、Windows の開発ドキュメントの新機能します。

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能の概要、開発者向けのガイダンスやビデオが行われました 8 月で利用できます。

Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="design"></a>設計

次の機能に追加された、Windows の内部のプレビュー ビルド、 [Windows の内部](https://insider.windows.com/)プログラムを使用します。

* [Windows の UI ライブラリ](https://aka.ms/winui-docs)は、UWP アプリのコントロールとその他のユーザーの interfact 要素を提供する NuGet パッケージのセットです。 これらのパッケージも、以前のバージョンの Windows 10 の場合は、互換アプリには、ユーザーは、最新の OS のバージョンを持っていない場合でもようにします。

* [DropDownButton、分割ボタンと ToggleSplitButton](../design/controls-and-patterns/buttons.md)ボタン コントロールのアプリのユーザー エクスペリエンスを強化するために特殊な機能を提供します。

* 今すぐ、NavigationView は、アプリをナビゲーション オプションの数を減らして場合の[上部のナビゲーション](../design/controls-and-patterns/navigationview.md)をサポートしていて、アプリのコンテンツのスペースを要求します。

* ツリー ビューがサポートする強化[データ バインド、項目テンプレート、およびドラゴンおよびドロップ](../design/controls-and-patterns/tree-view.md)。

![背景色を選ぶための分割] ボタン](../design/controls-and-patterns/images/split-button-rtb.png)

### <a name="package-support-framework"></a>パッケージのサポート フレームワーク

パッケージのサポート フレームワークが、修正を適用、win32 アプリケーションいないときに、ソース コードへのアクセスを MSIX コンテナーで実行できるようにするために役立つ、ファイルを開くキットします。  

詳細については、[適用ランタイム修正パッケージ サポート フレームワークを使用して MSIX パッケージを](../porting/package-support-framework.md)参照してください。

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="web-api-extensions"></a>Web API 拡張

ブラウザーの間の web 開発 Mozilla 開発ネットワークのマニュアルを[従来の Microsoft API 拡張子](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)の一覧が追加されました。 これらの API 拡張機能は、Internet Explorer または Microsoft Edge に固有 MDN の web ドキュメントの互換性とブラウザーのサポートについての既存の情報を追加します。従来の Microsoft [CSS 拡張子](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript 拡張](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)機能が、およびリッチ web MDN から API 情報の提示で見つかることが[Visual Studio コード](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)。

### <a name="cwinrt-code-examples"></a>C + +/WinRT コードの例

250 が追加されました[C + +/WinRT](../cpp-and-winrt-apis/index.md)コード スニペットのトピックで、ドキュメント、記録されている既存の C + +/CX コードの例です。

### <a name="project-rome"></a>Project Rome

[プロジェクト ローマ ドキュメント](https://docs.microsoft.com/windows/project-rome/)サイトは、機能のアプローチを再編成されました。 これは、ため、開発者が探している情報を検索して、複数のプラットフォームの任意の機能を実装するために簡単に、必要があります。

## <a name="videos"></a>ビデオ

### <a name="xbox-live-unity-plugin"></a>Xbox Live Unity プラグイン

Unity の Xbox Live プラグインには、タイトルに Xbox Live のサインイン、統計、友人リスト、クラウド ストレージ、およびスコアボードを追加するためのサポートが含まれています。 詳しくは、[ビデオを見る](https://youtu.be/fVQZ-YgwNpY)を [ [GitHub パッケージのダウンロード](https://aka.ms/UnityPlugin)を開始するのにはします。

### <a name="one-dev-question"></a>1 つの開発質問

1 つの開発質問ビデオ シリーズでは、長い Microsoft 開発者は、一連の Windows の開発、チームのカルチャと履歴に関する質問を説明します。 回答を最新の質問は、次のとおりです。

Raymond 氏チェンの場合:

* [カーネル情報はどのビデオ ドライバーを再起動する場合ですか。](https://youtu.be/3SNAdyO1l5c)

ラリー Osterman:

* [Windows の Burgermaster オブジェクトの背面にあるストーリーとは何ですか。](https://youtu.be/0TDSbyAIvX0)