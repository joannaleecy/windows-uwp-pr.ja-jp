---
title: 8 月の 2018 年に Windows Docs の新 - UWP アプリを開発します。
description: Windows 10 の開発者向けドキュメント 2018 の年 8 月の新機能、ビデオ、サンプル、および開発者向けガイダンスが追加されました。
keywords: 新機能については、更新、機能、開発者向けガイダンスについては、Windows 10、8 月
ms.date: 08/14/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9922aa1ad2442153dcc2c13d05520c05c3b56d31
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616487"
---
# <a name="whats-new-in-the-windows-developer-docs-in-august-2018"></a>新機能については、Windows 開発者向けドキュメントで 2018 の年 8 月です。

Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。 次の機能の概要、開発者ガイド、およびビデオが 8 月以降の月の使用可能な加えられました。

Windows 10 の[ツールと SDK をインストール](https://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/create-uwp-apps.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。

## <a name="features"></a>機能

### <a name="design"></a>設計

次の機能に加え、Windows Insider Preview ビルドの利用、 [Windows Insider](https://insider.windows.com/)プログラム。

* [Windows UI ライブラリ](https://aka.ms/winui-docs)は UWP アプリ用、interfact 要素でコントロールおよびその他のユーザーが提供する NuGet パッケージのセットです。 これらのパッケージは以前のバージョンの Windows 10 では、プレリリースではも、ユーザーは最新の OS バージョンがあるない場合でも、アプリが動作するようにします。

* [DropDownButton](../design/controls-and-patterns/buttons.md#create-a-drop-down-button)、 [SplitButton](../design/controls-and-patterns/buttons.md#create-a-split-button)、および[ToggleSplitButton](../design/controls-and-patterns/buttons.md#create-a-toggle-split-button)ボタン コントロールをアプリのユーザー インターフェイスを強化するために特別な機能を提供します。

![前景色を選択するための分割ボタン](../design/controls-and-patterns/images/split-button-rtb.png)

* NavigationView ようになりました[トップ ナビゲーション](../design/controls-and-patterns/navigationview.md)、ケースをアプリが、少数のナビゲーション オプションと、アプリのコンテンツの空き領域が必要です。

* ツリー ビューがサポートするために強化されました[データ バインディング、項目テンプレート、およびドラッグ アンド ドロップします。](../design/controls-and-patterns/tree-view.md)

### <a name="package-support-framework"></a>パッケージのサポートのフレームワーク

パッケージのサポート、フレームワークは、修正プログラムを適用、win32 アプリケーションに、ソース コードへのアクセス権がないときに、MSIX コンテナーで実行できるようにするのに役立つオープン ソース キット。

詳細についてを参照してください。[パッケージ サポートのフレームワークを使用して、MSIX パッケージに修正プログラム適用ランタイム](../porting/package-support-framework.md)します。

## <a name="developer-guidance"></a>開発者向けガイダンス

### <a name="web-api-extensions"></a>Web API の拡張機能

一連の[従来の Microsoft API 拡張機能](https://developer.mozilla.org/docs/Web/API/Microsoft_API_extensions)クロスブラウザー web 開発用 Mozilla Developer Network のドキュメントに追加されました。 これらの API 拡張機能は Internet Explorer または Microsoft Edge、一意であり、MDN の web ドキュメントの互換性とブラウザーのサポートに関する既存の情報を補完します。レガシの Microsoft [CSS の拡張機能](https://developer.mozilla.org/docs/Web/CSS/Microsoft_Extensions)と[JavaScript 拡張](https://developer.mozilla.org/docs/Web/JavaScript/Microsoft_JavaScript_extensions)も利用してリッチな web API については、MDN の表示で直接を検索できます[Visual Studio Code。](https://code.visualstudio.com/updates/v1_25#_new-css-pseudo-selectors-and-pseudo-elements-from-mdn)

### <a name="cwinrt-code-examples"></a>C +/cli WinRT のコード例

250 を追加しました[C +/cli WinRT](../cpp-and-winrt-apis/index.md)コード、既存の C + に付属する、ドキュメントのトピックを一覧/cli CX のコード例です。

### <a name="project-rome"></a>Project Rome

[プロジェクト ローマ docs](https://docs.microsoft.com/windows/project-rome/)機能優先のアプローチにサイトが再編成されました。 これは、ため、開発者が探しているものを検索して、複数のプラットフォームでの任意の機能を実装するために簡単に、必要があります。

## <a name="videos"></a>ビデオ

### <a name="xbox-live-unity-plugin"></a>Xbox Live の Unity プラグイン

Unity の Xbox Live プラグインには、タイトルを署名 Xbox Live、統計、フレンド リスト、クラウドの記憶域、およびスコアボードを追加するためのサポートが含まれています。 [ビデオを見る](https://youtu.be/fVQZ-YgwNpY)、詳細については、 [GitHub パッケージをダウンロード](https://aka.ms/UnityPlugin)を開始します。

### <a name="one-dev-question"></a>開発用の 1 つの質問

開発用の 1 つの質問のビデオ シリーズでは、マイクロソフトのベテランの開発者は、一連の Windows の開発、チームのカルチャ、および履歴に関する質問を説明します。 お答えした最新の質問を次に示します。

Raymond Chen:

* [カーネルを認識する方法、ビデオ ドライバーを再起動するタイミングですか。](https://youtu.be/3SNAdyO1l5c)

Larry Osterman の場合:

* [Windows で Burgermaster オブジェクトの背後にあるストーリーとは何ですか。](https://youtu.be/0TDSbyAIvX0)