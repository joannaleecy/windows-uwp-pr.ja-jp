---
author: mcleanbyron
ms.assetid: 1f970d38-2338-470e-b5ba-811402752fc4
description: "Microsoft Store Engagement and Monetization SDK の Microsoft Advertising ライブラリを使って Windows 10、Windows 8.1、または Windows Phone 8.1 アプリにスポット広告を組み込む方法について説明します。"
title: "スポット広告"
ms.sourcegitcommit: cf695b5c20378f7bbadafb5b98cdd3327bcb0be6
ms.openlocfilehash: 0f159409bb584aacaf66550efe8d147cd8fddd50

---

# スポット広告


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

このチュートリアルでは、Microsoft Store Engagement and Monetization SDK の Microsoft Advertising ライブラリを使って Windows 10、Windows 8.1、または Windows Phone 8.1 アプリにスポット広告を組み込む方法について説明します。

C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

<span id="whatareinterstitialads10"/>
## スポット広告とは

スポット広告 (または*スポット*) は、バナー広告とは異なり、アプリの画面全体に表示されます。 通常、ゲームでは、2 つの基本的な形式が使用されます。

* *ペイウォール*広告の場合、ユーザーは一定の間隔で広告を視聴する必要があります。 たとえば、ゲームのレベル間に表示される広告が該当します。

    ![whatisaninterstitial](images/13-ed0a333b-0fc8-4ca9-a4c8-11e8b4392831.png)

* *報酬ベース*の広告の場合、ユーザーは明示的に特定のメリット (レベルを完了するためのヒントや追加の時間など) を求めていて、アプリのユーザー インターフェイスからビデオ広告を初期化します。

    この SDK ではビデオの再生時を除いて特定のユーザー インターフェイスを処理できないことに注意してください。 スポット広告をアプリに統合する方法を検討するときは、何をすべきであり何をすべきでないかに関するガイドラインとして、[スポットのベスト プラクティス](ui-and-user-experience-guidelines.md#interstitialbestpractices10)をご覧ください。

## スポット広告を含むアプリのビルド


### 前提条件

1.  [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) を Visual Studio 2015 または Visual Studio 2013 と共にインストールします。

2.  Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。

### コード開発

* [XAML/.NET アプリ用の手順](#interstitialadsxaml10)

* [HTML/JavaScript 用の手順](#interstitialadshtml10)

* [C++ (DirectX Interop) 用の手順](#interstitialadsdirectx10)

<span id="interstitialadsxaml10"/>
### スポット広告 (XAML/.NET)

> 
            **注**  ここでは C# の例を紹介していますが、Visual Basic と C++ もサポートされています。
 
1. Visual Studio でプロジェクトを開きます。
2. **参照マネージャー**で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

    -   Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

3.  アプリ コードで、次の名前空間の参照を含めます。

    ``` syntax
    using Microsoft.Advertising.WinRT.UI;
    ```

4.  `MyAppId` プロパティと `MyAdUnitId` プロパティを宣言します。

    ``` syntax
    var MyAppId = "<your app id for windows>";
    var MyAdUnitId = "<your adunit for windows";

    // if your code is in a universal solution and resides in the shared project
    // you can opt to use #if WINDOWS_APP or WINDOWS_PHONE_APP to override with different
    // identifiers for each
#if WINDOWS_PHONE_APP
    MyAppId = "<your app id for phone>";
    MyAdUnitId = "<your adunit for phone>";
#endif
    ```

    > 
            **注**  申請のためにアプリを提出する前に、テスト値を実際の値に置き換えてください。

5.  [InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) をインスタンス化し、すべてのイベント ハンドラーを関連付け、広告を要求します。

    ``` syntax
    // instantiate an InterstitialAd
    InterstitialAd MyVideoAd = new InterstitialAd();

    // wire up all 4 events, see below for function templates
    MyVideoAd.AdReady += MyVideoAd_AdReady;
    MyVideoAd.ErrorOccurred += MyVideoAd_ErrorOccurred;
    MyVideoAd.Completed += MyVideoAd_Completed;
    MyVideoAd.Cancelled += MyVideoAd_Cancelled;

    // pre-fetch an ad 30-60 seconds before you need it
    MyVideoAd.RequestAd(AdType.Video, MyAppId, MyAdUnitId);
    ```

6.  コードの広告を表示するポイントで、広告が準備されていることを確認し、広告を表示します。

    ``` syntax
    if ((InterstitialAdState.Ready) == (MyVideoAd.State))
    {
      MyVideoAd.Show();
    }
    ```

7.  イベントを定義してコードを記述します。

    ``` syntax
    void MyVideoAd_AdReady(object sender, object e)
    {
      // code
    }

    void MyVideoAd_ErrorOccurred(object sender, AdErrorEventArgs e)
    {
      // code
    }

    void MyVideoAd_Completed(object sender, object e)
    {  
      // code
    }

    void MyVideoAd_Cancelled(object sender, object e)
    {
      // code
    }
    ```

8.  `MyAppId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    var MyAppId = "d25517cb-12d4-4699-8bdc-52040c712cab";
    ```

9.  `MyAdUnitId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    var MyAdUnitId = "11389925";
    ```

10.  アプリをビルドした後テストして、テスト広告が表示されることを確認します。

<span id="interstitialadshtml10"/>
### スポット広告 (HTML/JavaScript)

このサンプルでは、Visual Studio 2015 で JavaScript 用ユニバーサル アプリ プロジェクトを作成済みであり、特定の CPU をターゲットとしているものと想定しています。

1. Visual Studio でプロジェクトを開きます。
2.  **参照マネージャー**で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

3.  HTML で、次のスクリプト参照を含めます。

    ``` syntax
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    ```

4.  `myAppId` プロパティと `myAdUnitId` プロパティを宣言します。

    ``` syntax
    <script>
      var myAppId = "<your app id>";
      var myAdUnitId = "<your adunit id>";
    </script>
    ```

5.  **InterstitialAd** をインスタンス化し、すべてのイベント ハンドラーを関連付け、広告を要求します。

    ``` syntax
    // instantiate an InterstitialAd
    window.interstitialAd = new MicrosoftNSJS.Advertising.InterstitialAd();

    // wire up all 4 events, see below for function templates
    window.interstitialAd.onAdReady = readyHandler;
    window.interstitialAd.onErrorOccurred = errorHandler;
    window.interstitialAd.onCompleted = completeHandler;
    window.interstitialAd.onCancelled = cancelHandler;

    // pre-fetch an ad 30-60 seconds before you need it
    var myAdType = MicrosoftNSJS.Advertising.InterstitialAdType.video;
    window.interstitialAd.requestAd(myAdType, myAppId, myAdUnitId);
    ```

6.  コードの広告を表示するポイントで、広告が準備されていることを確認し、広告を表示します。

    ``` syntax
    if ((MicrosoftNSJS.Advertising.InterstitialAdState.ready) == (window.interstitialAd.state)) {
             window.interstitialAd.show();
    }
    ```

7.  イベントを定義してコードを記述します。

    ``` syntax
    function readyHandler(sender) {
      // code
    }

    function errorHandler(sender, args) {
      // code
    }

    function completeHandler(sender) {
      // code
    }

    function cancelHandler(sender) {
      // code
    }
    ```

7.  `MyAppId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    var MyAppId = "d25517cb-12d4-4699-8bdc-52040c712cab";
    ```

8.  `MyAdUnitId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    var MyAdUnitId = "11389925";
    ```

9.  アプリをビルドした後テストして、テスト広告が表示されることを確認します。

<span id="interstitialadsdirectx10"/>
### スポット広告 (C++ および DirectX と XAML の相互運用機能)

このサンプルでは、Visual Studio 2015 で XAML 用ユニバーサル アプリ プロジェクトを作成済みであり、特定の CPU アーキテクチャをターゲットとしているものと想定しています。

> 
            **重要**  このコードは、DirectX の要件により C++ で記述されています。

 
1. Visual Studio でプロジェクトを開きます。
1.  **参照マネージャー**で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

    -   ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。

    -   Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

    -   Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

2.  アプリの適切なヘッダー ファイルで、スポット広告オブジェクトとそれに関連するプロパティまたはメソッドを宣言します。

    ``` syntax
    Microsoft::Advertising::WinRT::UI::InterstitialAd^ m_ia;
    void OnAdReady(Object^ sender, Object^ args);
    void OnAdCompleted(Object^ sender, Object^ args);
    void OnAdCancelled(Object^ sender, Object^ args);
    void OnAdError (Object^ sender,  Microsoft::Advertising::WinRT::UI::AdErrorEventArgs^ args);
    ```

3.  `AppId` プロパティと `AdUnitId` プロパティを宣言します。

    ``` syntax
    #if WINDOWS_PHONE_APP
    static Platform::String^ IA_APPID = L"<your app id for phone>";
    static Platform::String^ IA_ADUNITID = L"<your ad unit for phone>";
    #endif

    #if WINDOWS_APP
    static Platform::String^ IA_APPID = L"<your app id for windows>";
    static Platform::String^ IA_ADUNITID = L"<your ad unit for windows>";
    #endif
    ```

4.  .cpp ファイルで、名前空間の参照を追加します。

    ``` syntax
    using namespace Microsoft::Advertising::WinRT::UI;
    ```

5.  **InterstitialAd** をインスタンス化し、すべてのイベント ハンドラーを関連付け、広告を要求します。

    ``` syntax
    // Instantiate an InterstitialAd.
    m_ia = ref new InterstitialAd();

    // Wire up all 4 events, see below for function templates.            
    m_ia->AdReady += ref new Windows::Foundation::EventHandler<Platform::Object ^>
        (this, &Simple3DGameXaml::DirectXPage::OnAdReady);
    m_ia->Completed += ref new Windows::Foundation::EventHandler<Platform::Object ^>
        (this, &Simple3DGameXaml::DirectXPage::OnAdCompleted);
    m_ia->Cancelled += ref new Windows::Foundation::EventHandler<Platform::Object ^>
        (this, &Simple3DGameXaml::DirectXPage::OnAdCancelled);
    m_ia->ErrorOccurred += ref new
        Windows::Foundation::EventHandler<Microsoft::Advertising::WinRT::UI::AdErrorEventArgs ^>
            (this, &Simple3DGameXaml::DirectXPage::OnAdError);

    // Pre-fetch an ad 30-60 seconds before you need it.
    m_ia->RequestAd(AdType::Video, IA_APPID, IA_ADUNITID);
    ```

6.  コードの広告を表示するポイントで、広告が準備されていることを確認し、広告を表示します。

    ``` syntax
    if ((InterstitialAdState::Ready == m_ia->State))
    {
        m_ia->Show();
    }
    ```

7.  イベントを定義してコードを記述します。

    ``` syntax
    void DirectXPage::OnAdReady(Object^ sender, Object^ args)
    {
      // code
    }

    void DirectXPage::OnAdCompleted(Object^ sender, Object^ args)
    {
      // code
    }

    void DirectXPage::OnAdCancelled(Object^ sender, Object^ args)
    {
      // code
    }

    void DirectXPage::OnAdError
      (Object^ sender, Microsoft::Advertising::WinRT::UI::AdErrorEventArgs^ args)
    {
      // code
    }
    ```

8.  `AppId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    static Platform::String^ IA_APPID = L"d25517cb-12d4-4699-8bdc-52040c712cab";
    ```

9.  `AdUnitId` プロパティを、「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てます。 この値はテストのみに使います。アプリを公開する前にこの値を適切な値に置き換えてください。

    ``` syntax
    static Platform::String^ IA_ADUNITID = L"11389925";
    ```

10. アプリをビルドした後テストして、テスト広告が表示されることを確認します。

### Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする

1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** をクリックして **[広告で収入を増やす]** ページに移動し、[スタンドアロン Microsoft Advertising ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[ビデオ (スポット)]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、テスト広告ユニット値を、デベロッパー センターで生成したライブ値に置き換えます。

3.  
            Windows デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

<span id="interstitialbestpractices10"/>
## スポット広告に関するベスト プラクティス


スポット広告を効果的に使用する方法については、「[UI とユーザー エクスペリエンスのガイドライン](ui-and-user-experience-guidelines.md)」をご覧ください。

<span id="targetplatform10"/>
## 参照エラーの解決: 特定の CPU プラットフォームをターゲットにする (XAML と HTML)


Microsoft Advertising ライブラリを使う場合、プロジェクトで **"Any CPU"** をターゲットにすることはできません。 プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。 この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。

## 関連トピック


* [C# を使ったスポット広告のサンプル コード#](interstitial-ad-sample-code-in-c.md)
* [JavaScript を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-javascript.md)
* [GitHub の広告サンプル](http://aka.ms/githubads)

 

 



<!--HONumber=Jun16_HO4-->


