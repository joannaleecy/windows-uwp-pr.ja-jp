---
author: Xansky
ms.assetid: 7a38a352-6e54-4949-87b1-992395a959fd
description: アプリ内広告の UI とユーザー エクスペリエンスのガイドラインについて説明します。
title: 広告の UI とユーザー エクスペリエンスのガイドライン
ms.author: mhopkins
ms.date: 05/11/2018
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, ガイドライン, ベスト プラクティス
ms.localizationpriority: medium
ms.openlocfilehash: 4d502c721f98269c1256510a6f91f8c6dc8cd0fb
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6649816"
---
# <a name="ui-and-user-experience-guidelines-for-ads"></a>広告の UI とユーザー エクスペリエンスのガイドライン

この記事では、アプリ内のバナー広告、スポット広告、ネイティブ広告を使って優れたエクスペリエンスを提供するためのガイドラインを示します。 アプリの外観を設計する方法については、「[設計および UI](https://developer.microsoft.com/windows/apps/design)」をご覧ください。

> [!IMPORTANT]
> アプリ内での広告の使用は、Microsoft Store ポリシーに準拠している必要があります。準拠するポリシーには、[ポリシー 10.10](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) (広告行為と広告コンテンツ) などがありますが、これに限定されるわけではありません。 特に、アプリ内のバナー広告またはスポット広告の実装は、Microsoft Store ポリシー、[ポリシー 10.10.1](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) の要件を満たしている必要があります。 この記事では、このポリシーに違反する実装の例を示します。 これらの例は、このポリシーの適切な理解を助ける手段として、情報提供のみを目的として提供されています。 これらの例は、すべてを網羅しているわけではありません。ここに記載されていなくても、Microsoft Store ポリシーに違反する例は多数存在する可能性があります。

## <a name="general-best-practices"></a>一般的なベスト プラクティス

この記事のさまざまな種類の広告のガイドラインを確認する前に、まずこれらの一般的なベスト プラクティスを確認し、広告収益を向上させてください。

* [広告の配置を慎重に計画します](https://blogs.windows.com/buildingapps/2017/04/10/monetizing-app-advertisement-placement/)。 [広告ユニットのビューアビリティの最適化](optimize-ad-unit-viewability.md)に関する関連するガイダンスを参照してください。
* [スポット ビデオ広告のフォールバックとしてスポット バナー広告を使用します](https://blogs.windows.com/buildingapps/2017/04/17/monetizing-app-use-interstitial-banner-fallback-interstitial-video)。
* [ユーザーを把握して、より良いターゲット広告を提供します](https://blogs.windows.com/buildingapps/2017/05/17/monetize-app-know-user-serve-better-targeted-ads/)。
* [最新の Advertising ライブラリを使用します](https://blogs.windows.com/buildingapps/2017/05/22/earn-money-moving-latest-advertising-libraries/)。
* [アプリの適切な COPPA 設定を設定します](https://blogs.windows.com/buildingapps/2017/06/21/monetizing-app-set-coppa-settings-app)。


## <a name="guidelines-for-banner-ads"></a>バナー広告のガイドライン

以下のセクションでは、[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) を使ってアプリ内で[バナー広告](banner-ads.md)を実装する場合の推奨事項と、Microsoft Store ポリシーの[ポリシー 10.10.1](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) に違反する実装の例を紹介します。

### <a name="best-practices"></a>ベスト プラクティス

アプリにバナー広告を実装するときは、以下のベスト プラクティスに従うことをお勧めします。

* デバイスのレイアウトに適合する [Interactive Advertising Bureau のサイズを使用します](https://blogs.windows.com/buildingapps/2017/04/03/monetizing-app-use-interactive-advertising-bureau-ad-sizes)。

* アプリの UI のほとんどを機能するコントロールとコンテンツに充てます。

* 広告をエクスペリエンスに組み込んで設計します。 広告がどのように表示されるかを計画するための広告のサンプルをデザイナーに提供します。 適切に計画されたアプリ内広告の 2 つの例は、コンテンツとしての広告のレイアウトと分割レイアウトです。

  さまざまなサイズの広告が、開発およびテスト段階でアプリ内でどのように表示され、どのように機能するかを確認するには、[テスト広告ユニット](set-up-ad-units-in-your-app.md#test-ad-units) を利用できます。 テストが完了したら、認定を受けるためにアプリを提出する前に、[ライブ広告ユニットでアプリを更新する](set-up-ad-units-in-your-app.md#live-ad-units)ことを忘れないでください。

* 広告を利用できない場合の対応を計画します。 広告がアプリに送信されないタイミングがあります。 ページに広告が表示される場合も、表示されない場合も、適切に表示されるようにページをレイアウトします。 詳しくは、「[広告のエラー処理](error-handling-with-advertising-libraries.md)」をご覧ください。

* オーバーレイを使って最も効果的に対応できるユーザーへの通知シナリオがある場合、オーバーレイを表示しながら [AdControl.Suspend](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.suspend) を呼び出し、通知シナリオが完了したら [AdControl.Resume](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.resume) を呼び出します。

### <a name="practices-to-avoid"></a>避けるプラクティス

アプリ内にバナー広告を実装する際は、以下のプラクティスを避けることをお勧めします。

* 空いている領域に広告を固定しないでください。 広告スペースは、画面上で最初に見つかる空き領域に配置しないでください。 広告スペースはアプリの全体的な設計に組み込む必要があります。

* 多くの広告を表示してアプリを飽和状態にしないでください。 アプリに表示する広告が多すぎると、アプリの外観と操作性を損ねます。 広告を使って収入を得ることは望んでも、アプリ自体を犠牲にしないでください。

* ユーザーが中心的なタスクに集中するのを妨げないでください。 主要項目は常にアプリに表示されている必要があります。 広告スペースは 2 次的な項目として組み込まれている必要があります。

### <a name="examples-of-policy-violations"></a>ポリシー違反の例

このセクションでは、Microsoft Store ポリシーの[ポリシー 10.10.1](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) に違反するバナー広告シナリオの例を示します。 これらの例は、このポリシーの適切な理解を助ける手段として、説明目的にのみ提供されています。 これらの例は、すべてを網羅しているわけではありません。ここに記載されていなくても、ポリシー 10.10.1 に違反する例は多数存在する可能性があります。

* [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) の不透明度を変更したり、(最初に [AdControl.Suspend](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.suspend) を呼び出さずに) **AdControl**の上に他のコントロールを配置するなど、バナー広告をユーザーが表示する能力を妨げる操作を行う。

* ユーザーがアプリでタスクを実行するにはバナーをクリックする必要がある。またはアプリの設計結果として、ユーザーにバナー広告を強制的にクリックさせる。

* [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) オブジェクトのスワップ、またはユーザー操作を伴わない強制的なページ更新など、任意の手段でバナー広告の組み込み最短更新タイマーを回避する。

* ライブ広告ユニット (つまり、パートナー センターから取得する広告ユニット) を使用して、開発およびテスト中、またはエミュレーターでします。

* アプリのコンテキストで実行している Microsoft Advertising ライブラリ以外の手段で広告サービスを呼び出すコードを記述または配布する。

* ドキュメントに記載されていないインターフェイスや、Microsoft Advertising ライブラリで作成された、**WebView** や **MediaElement** などの子オブジェクトを操作する。

<span id="interstitialbestpractices10" />

## <a name="guidelines-for-interstitial-ads"></a>スポット広告のガイドライン

洗練された方法で[スポット広告](interstitial-ads.md)を使うと、ユーザー満足度を損なうことなく、アプリの収益を飛躍的に向上させることができます。 使い方が不適切だと、スポット広告は逆効果になる可能性があります。

以下のセクションでは、[InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) を使ってアプリにビデオ スポット広告やバナー スポット広告を実装する場合の推奨事項と、Microsoft Store ポリシーの[ポリシー 10.10.1](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) に違反する実装の例を紹介します。 ポリシーに関連する問題を除き、アプリについて最もよく理解しているのは開発者の皆様であるため、ベスト プラクティスに関する最終的な判断は開発者の皆様に委ねています。 留意する最も重要な点は、アプリの評価と収益が密接に結びついていることです。

### <a name="best-practices"></a>ベスト プラクティス

アプリにスポット広告を実装するときは、以下のベスト プラクティスに従うことをお勧めします。

* ゲームのレベルの合間など、アプリの自然な流れの中にスポット広告を配置します。

* 次のように、広告を具体的なメリットに関連付けます。

    * レベル完了のためのヒント。

    * レベルを再試行するための追加の時間。

    * タトゥーや帽子などのカスタム アバター機能。

* アプリでビデオ スポット広告を最後まで視聴することを要求する場合は、ユーザーが閉じるボタンを押したときにエラー メッセージに驚かないように、事前にルールを説明しておきます。

* 可能であれば広告の表示が必要になる 30 ～ 60 秒前に ([InterstitialAd.RequestAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.requestad) を呼び出して) 広告を事前に取得しておきます。

* [InterstitialAd](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad) クラスで公開されている 4 つのイベント (**Canceled**、**Completed**、**AdReady**、**ErrorOccurred**) をすべてサブスクライブし、それらを使用して、アプリに適切な意思決定を行います。

* サーバーが提供する広告の代わりに使用する機能をあらかじめ用意しておきます。 これは次のようなシナリオで役に立ちます。

    * オフライン モード。広告サーバーにアクセスできない場合。

    * **ErrorOccurred** イベントが発生した場合。

    * [ConnectionProfile](https://docs.microsoft.com/uwp/api/Windows.Networking.Connectivity.ConnectionProfile) に基づいてユーザーの帯域幅を節約することを選択する場合、**ConnectionProfile** クラスに便利な API があります。

* 他の値に設定する妥当な理由がない限り、既定のタイムアウト (30 秒) を使います。他の値に設定する場合、10 秒未満には設定しないでください。 特に高速接続を利用できない市場では、スポット広告は標準のバナー広告よりもダウンロードにかかる時間が大幅に長くなります。

* ユーザーのデータ通信プランに留意してください。 たとえば、データ通信量上限に近づいているモバイル デバイスや上限を超えているモバイル デバイスで、ビデオ スポット広告を表示する前に、何も表示しないか、ユーザーに警告するかを決定します。 [ConnectionProfile](https://docs.microsoft.com/uwp/api/Windows.Networking.Connectivity.ConnectionProfile) クラスには、これに役立つ API があります。

* 最初の申請後に、アプリを継続的に改善します。 [広告レポート](../publish/advertising-performance-report.md)を確認し、フィル レートとビデオ スポット広告の完了率が向上するように設計を変更します。

### <a name="practices-to-avoid"></a>避けるプラクティス

アプリ内にスポット広告を実装する際は、以下のプラクティスを避けることをお勧めします。

* 過剰に表示しないでください。 ユーザーがゲームをプレイするだけでなく、広告についてオプションの具体的なメリットを明確に感じている場合を除き、5 分ごとよりも頻繁に広告を強制的に表示しないでください。

* アプリの起動時にスポット広告を表示しないでください。ユーザーは、誤ったタイルをクリックしたと考える可能性があります。

* 終了時にスポット広告を表示しないでください。 完了率がほぼゼロになるため、これは不適切なインベントリです。

* 2 つ以上のスポット広告を連続して表示しないでください。 ユーザーは広告の進行状況バーが開始点にリセットされるのを見ると苛立ちを感じます。 多くのユーザーは、これがコーディングまたは広告提供のバグであると考えます。

* [InterstitialAd.Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) を呼び出す 5 分以上前にビデオ スポット広告を取得しないでください。 適切なインベントリでは、事前に取得された広告から請求可能なインプレッションへのコンバージョンが最大化されます。

* 利用可能な広告がないなど、広告を提供できなかった場合に、ユーザーに不利益をもたらさないようにしてください。 たとえば、[広告を視聴して *xxx* を取得する] という UI オプションを表示する場合、ユーザーが責任を果たしたら、*xxx* を提供する必要があります。 2 つのオプションを検討してください。

    * [InterstitialAd.AdReady](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.adready) イベントが発生するまでこのオプションを表示しない。

    * 実際の広告と同じ利点が得られるように、あらかじめ用意された機能をアプリに含める。

* マルチプレーヤー ゲームでユーザーが優位性を確保できるようなスポット広告を使用しないでください。 たとえば、スポット広告が表示されると、ファーストパーソン シューティング ゲームで高性能な銃が手に入るような方法でユーザーを惹きつけてはいけません。 プレーヤーのアバターのシャツをカスタマイズ可能にすることは、カモフラージュ機能がなければ問題ありません。

### <a name="examples-of-policy-violations"></a>ポリシー違反の例

このセクションでは、Microsoft Store ポリシーの[ポリシー 10.10.1](https://docs.microsoft.com/legal/windows/agreements/store-policies#1010-advertising-conduct-and-content) に違反するスポット広告シナリオの例を示します。 これらの例は、このポリシーの適切な理解を助ける手段として、説明目的にのみ提供されています。 これらの例は、すべてを網羅しているわけではありません。ここに記載されていなくても、ポリシー 10.10.1 に違反する例は多数存在する可能性があります。

* スポット広告コンテナー上に UI 要素を配置する。

* ユーザーがアプリを使用している間に [InterstitialAd.Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) を呼び出す。

* スポット広告を使って、通貨として消費できるものや、他のユーザーと取引できるものを取得できるようにする。

* [InterstitialAd.ErrorOccurred](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.erroroccurred) イベントのイベント ハンドラーのコンテキストで新しいスポット広告を要求する。 これにより、無限ループが発生して、広告サービスの操作上の問題の原因となります。

* 連鎖的な広告の単なるバックアップとして、スポット広告を要求する。 スポット広告を要求し、[InterstitialAd.AdReady](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.adready) イベントを受信した場合、アプリに表示できる次のスポット広告は、[InterstitialAd.Show](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.interstitialad.show) メソッド経由で表示できる必要があります。

* ライブ広告ユニット (つまり、パートナー センターから取得する広告ユニット) を使用して、開発およびテスト中、またはエミュレーターでします。

* アプリのコンテキストで実行している Microsoft Advertising ライブラリ以外の手段で広告サービスを呼び出すコードを記述または配布する。

* ドキュメントに記載されていないインターフェイスや、Microsoft Advertising ライブラリで作成された、**WebView** や **MediaElement** などの子オブジェクトを操作する。

## <a name="guidelines-for-native-ads"></a>ネイティブ広告のガイドライン

[ネイティブ広告](native-ads.md)では、ユーザーに広告コンテンツを表示する方法を非常に細かく制御できます。 次の要件とガイドラインに従って、広告主のメッセージがユーザーに届くようにし、さらにネイティブ広告の混乱するエクスペリエンスがユーザーに提供されないようにします。

### <a name="register-the-container-for-your-native-ad"></a>ネイティブ広告のコンテナーを登録する

コードで、[NativeAdV2](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.nativeadv2) オブジェクトの [RegisterAdContainer](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.nativeadv2.registeradcontainer) メソッドを呼び出して、ネイティブ広告のコンテナーとして機能する UI 要素と、必要に応じて広告のクリック可能なターゲットとして登録する特定のコントロールを登録する必要があります。 これは、広告インプレッションと広告クリックを適切に追跡するために必要です。

**RegisterAdContainer** メソッドには、次の 2 つのオーバーロードを使用できます。

* コンテナー全体で個別のネイティブ広告要素をすべてクリック可能にする必要がある場合、**RegisterAdContainer(FrameworkElement)** メソッドを呼び出して、そのメソッドにコンテナー コントロールを渡します。 たとえば、**StackPanel** ですべてホストされている個別のコントロールにすべてのネイティブ広告要素を表示し、**StackPanel** 全体をクリック可能にする必要がある場合、このメソッドに **StackPanel** を渡します。

* 特定のネイティブ広告要素のみをクリック可能にする必要がある場合は、**RegisterAdContainer(FrameworkElement, IVector(FrameworkElement))** メソッドを呼び出します。 2 つ目のパラメーターに渡すコントロールだけがクリック可能になります。

### <a name="required-native-ad-elements"></a>必須のネイティブ広告要素

少なくとも、ネイティブ広告デザインで、ユーザーに [NativeAdV2](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.nativeadv2) オブジェクトのプロパティで提供される次のネイティブ広告要素を常に表示する必要があります。 これらの要素を含めておかないと、広告ユニットのパフォーマンスが低下し収益が少なくなることがあります。

1. ネイティブ広告のタイトルを常に表示します (**Title** プロパティで使用できます)。 25 文字以上表示できる十分な領域を用意します。 タイトルがそれ以上長い場合は、その分のテキストを省略記号で置き換えます。
2. 次の要素のうち少なくとも 1 つを常に表示して、ネイティブ広告のエクスペリエンスをアプリの残りの部分と区別し、コンテンツが広告主によって提供されていることを明確に示します。
    * 識別できる*広告*アイコン (**AdIcon** プロパティで使用できます)。 このアイコンは Microsoft によって提供されます。
    * *スポンサー* テキスト (**SponsoredBy** プロパティで使用できます)。 このテキストは広告主によって提供されます。
    * *スポンサー* テキストの代わりに、ネイティブ広告エクスペリエンスをアプリの残りの部分と区別する他のテキストとして "スポンサー付きコンテンツ"、"プロモーション コンテンツ"、"おすすめのコンテンツ" などを表示することもできます。

### <a name="user-experience"></a>ユーザー エクスペリエンス

ネイティブ広告をアプリの残りの部分から明確に線引きして、その周囲に領域を確保することで誤ってクリックされないようにする必要があります。 境界線やさまざまな背景、その他の UI を使って、広告コンテンツをアプリの残りの部分と区別します。 誤って広告がクリックされることは、長い目で見ると広告ベースの収益やエンド ユーザー エクスペリエンスに有益ではないことに注意してください。

### <a name="description"></a>説明

広告の説明 (**NativeAdV2** オブジェクトの **Description** プロパティで使用できます) を表示する場合、75 文字以上表示できる十分な領域を用意します。 アニメーションを使って広告の説明の全コンテンツを表示することをお勧めします。

### <a name="call-to-action"></a>行動喚起

*行動喚起*テキスト (**NativeAdV2** オブジェクトの **CallToAction** プロパティで使用できます) は、広告の重要なコンポーネントです。 このテキストを表示する場合、次のガイドラインに従います。

* ボタンやハイパーリンクなどのクリック可能なコントロールにユーザーへの*行動喚起*テキストを常に表示する。
* *行動喚起*テキスト全体を常に表示する。
* *行動喚起*テキストが、広告主が提供する残りのプロモーション テキストと区別されるようにする。
