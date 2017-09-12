---
author: mcleanbyron
description: "UWP アプリにネイティブ広告を追加する方法について説明します。"
title: "ネイティブ広告"
ms.author: mcleans
ms.date: 06/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, Advertising, 広告コントロール, ネイティブ広告"
ms.openlocfilehash: 47a69e48f04c670a462c34083af1117d2c7908d8
ms.sourcegitcommit: 8c4d50ef819ed1a2f8cac4eebefb5ccdaf3fa898
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/27/2017
---
# <a name="native-ads"></a>ネイティブ広告

ネイティブ広告は、コンポーネント ベースの広告形式で、各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が個々の要素としてアプリに配信されます。 これらの要素は、独自のフォント、色、アニメーション、その他の UI コンポーネントを使ってアプリに統合して、アプリの外観に合った控えめなユーザー エクスペリエンスを組み込むことができるうえに、広告から高収益を獲得できます。

広告主のために、ネイティブ広告では高パフォーマンスの配置が提供されます。広告エクスペリエンスがアプリに密接に統合されることで、ユーザーがこのような種類の広告と対話しやすくなる傾向があるためです。

> [!NOTE]
> ネイティブ広告をストア内の公開バージョンのアプリに提供するには、デベロッパー センター ダッシュボードの **[広告で収入を増やす]** ページから**ネイティブ**広告ユニットを作成する必要があります。 **ネイティブ**広告ユニットを作成する機能は、現在はパイロット プログラムに参加している開発者だけが利用できますが、まもなくすべての開発者がこの機能を利用できるようにする予定です。 パイロット プログラムへの参加に関心がある方は、aiacare@microsoft.com までお問い合わせください。

> [!NOTE]
> ネイティブ広告は現在、XAML ベースの Windows 10 用 UWP アプリでのみサポートされています。 HTML と JavaScript を使って作成された UWP アプリについては、今後リリースされる Microsoft Advertising SDK でサポートされる予定です。

## <a name="prerequisites"></a>前提条件

* [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (バージョン 10.0.4 以降) を Visual Studio 2015 またはそれ以降にリリースされた Visual Studio と共にインストールします。 インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。 SDK は MSI インストーラーを使って開発用コンピューターにインストールするか、NuGet パッケージから特定のプロジェクトで使うためにインストールすることができます。

## <a name="integrate-a-native-ad-into-your-app"></a>ネイティブ広告をアプリに統合する

次の手順に従って、ネイティブ広告をアプリに統合し、ネイティブ広告の実装によってテスト広告が表示されることを確認します。

1. Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

2. プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。 プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising SDK への参照を正常に追加できません。 詳しくは、「[プロジェクトのターゲットを "Any CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。

3.  **[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。

4.  **[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。

5.  **[参照マネージャー]** で、[OK] をクリックします。

6. アプリの適切なコード ファイル (たとえば、MainPage.xaml.cs またはその他のページのコード ファイル) に、次の名前空間の参照を追加します。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#Namespaces)]

7.  アプリの適切な場所 (たとえば、```MainPage``` またはその他のページ) で、[NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.aspx) オブジェクトと、ネイティブ広告のアプリケーション ID および広告ユニット ID を表す複数の文字列フィールドを宣言します。 次のコード例では、`myAppId` フィールドと `myAdUnitId` フィールドをネイティブ広告の[テスト値](test-mode-values.md)に割り当てています。

    > [!NOTE]
    > 各 **NativeAdsManager** に、対応する*広告ユニット*があります。広告ユニットは、ネイティブ広告コントロールに広告を提供するためにサービスで使われます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。 ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。 これらのテスト値は、テスト バージョンのアプリでのみ使用できます。 ストアにアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release) 必要があります。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#Variables)]

8.  起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**NativeAdsManager** オブジェクトをインスタンス化し、このオブジェクトの [AdReady](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.adready.aspx) イベントと [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.erroroccurred.aspx) イベント用のイベント ハンドラーを関連付けます。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#ConfigureNativeAd)]

9.  ネイティブ広告を表示する準備ができたら、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.requestad.aspx) メソッドを呼び出して、広告を取得します。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#RequestAd)]

10.  アプリ用にネイティブ広告の準備ができたら、**AdReady** イベント ハンドラーが呼び出され、ネイティブ広告を表す [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) オブジェクトが *e* パラメーターに渡されます。 **NativeAd** プロパティを使ってネイティブ広告の各要素を取得し、ページ上にそれらの要素を表示します。 また、[RegisterAdContainer](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.registeradcontainer.aspx) メソッドを呼び出して、ネイティブ広告のコンテナーとして機能する UI 要素を登録してください。広告インプレッションと広告クリックを適切に追跡するために必要です。
  > [!NOTE]
  > ネイティブ広告の一部の要素は必須であり、アプリに常に表示する必要があります。 詳しくは、「[要件とガイドライン](#requirements-and-guidelines)」をご覧ください。

    たとえば、アプリに次のような **StackPanel** を持つ ```MainPage``` (またはその他のページ) が含まれているとします。 この **StackPanel** には、ネイティブ広告のさまざまな要素 (タイトル、説明、画像、*スポンサー* テキスト、*行動喚起*テキストを表示するボタンなど) を表示する一連のコントロールが含まれています。

    ``` xml
    <StackPanel x:Name="NativeAdContainer" Background="#555555" Width="Auto" Height="Auto"
                Orientation="Vertical">
        <Image x:Name="AdIconImage" HorizontalAlignment="Left" VerticalAlignment="Center"
               Margin="20,20,20,20"/>
        <TextBlock x:Name="TitleTextBlock" HorizontalAlignment="Left" VerticalAlignment="Center"
               Text="The ad title will go here" FontSize="24" Foreground="White" Margin="20,0,0,10"/>
        <TextBlock x:Name="DescriptionTextBlock" HorizontalAlignment="Left" VerticalAlignment="Center"
                   Foreground="White" TextWrapping="Wrap" Text="The ad description will go here"
                   Margin="20,0,0,0" Visibility="Collapsed"/>
        <Image x:Name="MainImageImage" HorizontalAlignment="Left"
               VerticalAlignment="Center" Margin="20,20,20,20" Visibility="Collapsed"/>
        <Button x:Name="CallToActionButton" Background="Gray" Foreground="White"
                HorizontalAlignment="Left" VerticalAlignment="Center" Width="Auto" Height="Auto"
                Content="The call to action text will go here" Margin="20,20,20,20"
                Visibility="Collapsed"/>
        <StackPanel x:Name="SponsoredByStackPanel" Orientation="Horizontal" Margin="20,20,20,20">
            <TextBlock x:Name="SponsoredByTextBlock" Text="The ad sponsored by text will go here"
                       FontSize="24" Foreground="White" Margin="20,0,0,0" HorizontalAlignment="Left"
                       VerticalAlignment="Center" Visibility="Collapsed"/>
            <Image x:Name="IconImageImage" Margin="40,20,20,20" HorizontalAlignment="Left"
                   VerticalAlignment="Center" Visibility="Collapsed"/>
        </StackPanel>
    </StackPanel>
    ```

    次のコード例は、**StackPanel** のコントロールにネイティブ広告の各要素を表示してから、**RegisterAdContainer** メソッドを呼び出して **StackPanel** を登録する **AdReady** イベント ハンドラーを示しています。 このコードでは、**StackPanel** が含まれているページの分離コード ファイルから実行されることを想定しています。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#AdReady)]

11.  **ErrorOccurred** イベントのイベント ハンドラーを定義して、ネイティブ広告に関連するエラーを処理します。 次の例では、テスト中に Visual Studio の **[出力]**ウィンドウにエラー情報を書き込みます。

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#ErrorOccurred)]

12.  アプリをコンパイルして実行し、テスト広告が表示されることを確認します。

<span id="release" />
## <a name="release-your-app-with-live-ads"></a>ライブ広告を表示するアプリをリリースする

ネイティブ広告の実装によってテスト広告が正常に表示されることを確認したら、次の手順に従って、実際の広告を表示するようにアプリを構成し、更新したアプリをストアに提出します。

1.  ネイティブ広告の実装がネイティブ広告の[要件とガイドライン](#requirements-and-guidelines)に従っていることを確認してください。

2.  デベロッパー センターのダッシュボードで、アプリの [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページに移動し、[広告ユニットを作成](../monetize/set-up-ad-units-in-your-app.md)します。 広告ユニットの種類として、**[ネイティブ]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。
    > [!IMPORTANT]
    > 各広告ユニットは 1 つのアプリのみで使用できます。 複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。

3. [[広告で収入を増やす]](../publish/monetize-with-ads.md) ページの [[広告仲介]](../publish/monetize-with-ads.md#mediation) セクションで設定を構成することにより、必要に応じてネイティブ広告の広告仲介を有効にできます。 広告仲介を利用すると、複数の広告ネットワークから広告を表示することにより、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。

4.  コードで、広告ユニットのテスト値 ([NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーター) を、デベロッパー センターで生成した実際の値に置き換えます。

5.  デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。

6.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

<span id="requirements-and-guidelines" />
## <a name="requirements-and-guidelines"></a>要件とガイドライン

ネイティブ広告では、ユーザーに広告コンテンツを表示する方法を非常に細かく制御できます。 次の要件とガイドラインに従って、広告主のメッセージがユーザーに届くようにし、さらにネイティブ広告の混乱するエクスペリエンスがユーザーに提供されないようにします。

### <a name="register-the-container-for-your-native-ad"></a>ネイティブ広告のコンテナーを登録する

コードで、**NativeAd** オブジェクトの [RegisterAdContainer](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.registeradcontainer.aspx) メソッドを呼び出して、ネイティブ広告のコンテナーとして機能する UI 要素と、必要に応じて広告のクリック可能なターゲットとして登録する特定のコントロールを登録する必要があります。 これは、広告インプレッションと広告クリックを適切に追跡するために必要です。

**RegisterAdContainer** メソッドには、次の 2 つのオーバーロードを使用できます。

* コンテナー全体で個別のネイティブ広告要素をすべてクリック可能にする必要がある場合、[RegisterAdContainer(FrameworkElement)](https://msdn.microsoft.com/library/windows/apps/mt809188.aspx) メソッドを呼び出して、そのメソッドにコンテナー コントロールを渡します。 たとえば、**StackPanel** ですべてホストされている個別のコントロールにすべてのネイティブ広告要素を表示し、**StackPanel** 全体をクリック可能にする必要がある場合、このメソッドに **StackPanel** を渡します。

* 特定のネイティブ広告要素のみをクリック可能にする必要がある場合は、[RegisterAdContainer(FrameworkElement, IVector(FrameworkElement))](https://msdn.microsoft.com/library/windows/apps/mt809189.aspx) メソッドを呼び出します。 2 つ目のパラメーターに渡すコントロールだけがクリック可能になります。

### <a name="required-native-ad-elements"></a>必須のネイティブ広告要素

少なくとも、ネイティブ広告デザインで、ユーザーに次のネイティブ広告要素を常に表示する必要があります。 これらの要素を含めておかないと、広告ユニットのパフォーマンスが低下し収益が少なくなることがあります。

1. ネイティブ広告のタイトルを常に表示します (**NativeAd** オブジェクトの [Title](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.title.aspx) プロパティで使用できます)。 25 文字以上表示できる十分な領域を用意します。 タイトルがそれ以上長い場合は、その分のテキストを省略記号で置き換えます。
2. 次の要素のうち少なくとも 1 つを常に表示して、ネイティブ広告のエクスペリエンスをアプリの残りの部分と区別し、コンテンツが広告主によって提供されていることを明確に示します。
  * 識別できる*広告*アイコン (**NativeAd** オブジェクトの [AdIcon](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.adicon.aspx) プロパティで使用できます)。 このアイコンは Microsoft によって提供されます。
  * *スポンサー* テキスト (**NativeAd** オブジェクトの [SponsoredBy](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.sponsoredby.aspx) プロパティで使用できます)。 このテキストは広告主によって提供されます。
  * *スポンサー* テキストの代わりに、ネイティブ広告エクスペリエンスをアプリの残りの部分と区別する他のテキストとして "スポンサー付きコンテンツ"、"プロモーション コンテンツ"、"おすすめのコンテンツ" などを表示することもできます。

### <a name="user-experience"></a>ユーザー エクスペリエンス

ネイティブ広告をアプリの残りの部分から明確に線引きして、その周囲に領域を確保することで誤ってクリックされないようにする必要があります。 境界線やさまざまな背景、その他の UI を使って、広告コンテンツをアプリの残りの部分と区別します。 誤って広告がクリックされることは、長い目で見ると広告ベースの収益やエンド ユーザー エクスペリエンスに有益ではないことに注意してください。

### <a name="description"></a>説明

広告の説明 (**NativeAd** オブジェクトの [Description](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.description.aspx) プロパティで使用できます) を表示する場合、75 文字以上表示できる十分な領域を用意します。 アニメーションを使って広告の説明の全コンテンツを表示することをお勧めします。

### <a name="call-to-action"></a>行動喚起

*行動喚起*テキスト (**NativeAd** オブジェクトの [CallToAction](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.calltoaction.aspx) プロパティで使用できます) は、広告の重要なコンポーネントです。 このテキストを表示する場合、次のガイドラインに従います。

* ボタンやハイパーリンクなどのクリック可能なコントロールにユーザーへの*行動喚起*テキストを常に表示する。
* *行動喚起*テキスト全体を常に表示する。
* *行動喚起*テキストが、広告主が提供する残りのプロモーション テキストと区別されるようにする。

### <a name="learn-and-optimize"></a>学習し最適化する

アプリでネイティブ広告の配置ごとに異なる広告ユニットを作成して使うことをお勧めします。 これにより、ネイティブ広告の配置ごとに個別のレポート データを取得できるため、このデータを使ってネイティブ広告の配置ごとのパフォーマンスを最適化する変更を加えることができます。

## <a name="related-topics"></a>関連トピック

* [広告による収益獲得](../publish/monetize-with-ads.md)
* [アプリの広告ユニットをセットアップする](../monetize/set-up-ad-units-in-your-app.md)
