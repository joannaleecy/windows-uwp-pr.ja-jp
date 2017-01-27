---
author: mcleanbyron
ms.assetid: 1f970d38-2338-470e-b5ba-811402752fc4
description: "Microsoft Store Services SDK の Microsoft Advertising ライブラリを使って Windows 10、Windows 8.1、または Windows Phone 8.1 アプリにスポット広告を組み込む方法について説明します。"
title: "スポット広告"
translationtype: Human Translation
ms.sourcegitcommit: 2b5dbf872dd7aad48373f6a6df3dffbcbaee8090
ms.openlocfilehash: fae0fc57eca3477bf46a6f3ac43ec35781241a6e

---

# <a name="interstitial-ads"></a>スポット広告

このチュートリアルでは、Microsoft Store Services SDK の Microsoft Advertising ライブラリを使って Windows 10、Windows 8.1、または Windows Phone 8.1 アプリにスポット広告を組み込む方法について説明します。

C# と C++ を使って JavaScript/HTML アプリと XAML アプリにスポット広告を追加する方法を示す完全なサンプル プロジェクトについては、[GitHub の広告サンプル](http://aka.ms/githubads)をご覧ください。

<span id="whatareinterstitialads10"/>
## <a name="what-are-interstitial-ads"></a>スポット広告とは

スポット広告 (または*スポット*) は、バナー広告とは異なり、アプリの画面全体に表示されます。 通常、ゲームでは、2 つの基本的な形式が使用されます。

* *ペイウォール*広告の場合、ユーザーは一定の間隔で広告を視聴する必要があります。 たとえば、ゲームのレベル間に表示される広告が該当します。

    ![whatisaninterstitial](images/13-ed0a333b-0fc8-4ca9-a4c8-11e8b4392831.png)

* *報酬ベース*の広告の場合、ユーザーは明示的に特定のメリット (レベルを完了するためのヒントや追加の時間など) を求めていて、アプリのユーザー インターフェイスからビデオ広告を初期化します。

    この SDK ではビデオの再生時を除いて特定のユーザー インターフェイスを処理できないことに注意してください。 スポット広告をアプリに統合する方法を検討するときは、何をすべきであり何をすべきでないかに関するガイドラインとして、[スポットのベスト プラクティス](ui-and-user-experience-guidelines.md#interstitialbestpractices10)をご覧ください。

## <a name="build-an-app-with-interstitial-ads"></a>スポット広告を含むアプリの構築

アプリでスポット広告を表示するには、次のプロジェクトの種類の指示に従います。

* [XAML/.NET](#interstitialadsxaml10)
* [HTML/JavaScript](#interstitialadshtml10)
* [C++ (DirectX Interop)](#interstitialadsdirectx10)

<span/>
### <a name="prerequisites"></a>前提条件

* UWP アプリ: Visual Studio 2015 と共に [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) をインストールします。
* Windows 8.1 アプリまたは Windows Phone 8.1 アプリ: Visual Studio 2015 または Visual Studio 2013 と共に [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。

<span id="interstitialadsxaml10"/>
###<a name="xamlnet"></a>XAML/.NET

ここでは C# の例を紹介していますが、XAML/.NET プロジェクトでは Visual Basic と C++ もサポートされています。 完全な C# コードの例については、「[C# を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-c.md)」をご覧ください。

1. Visual Studio でプロジェクトを開きます。

2. **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

  * ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。

  * Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

  * Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

3.  アプリの適切なコード ファイル (たとえば、MainPage.xaml.cs またはその他のページのコード ファイル) に、次の名前空間の参照を追加します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet1)]

4.  アプリの適切な場所 (たとえば、```MainPage``` またはその他のページ) で、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を表す複数の文字列フィールドを宣言します。 次のコード例では、`myAppId` フィールドおよび `myAdUnitId` フィールドを「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てています。 これらの値はテストにのみ使用されるため、アプリを公開する前に、これらの値を Windows デベロッパー センターから取得した実際の値に置き換える必要があります。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet2)]

5.  起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet3)]

6.  スポット広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。 これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet4)]

6.  広告を表示するコード内のポイントで、**InterstitialAd** の表示準備が整っていることを確認した後、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet5)]

7.  **InterstitialAd** オブジェクトのイベント ハンドラーを定義します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cs[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cs/MainPage.xaml.cs#Snippet6)]

8.  アプリをビルドした後テストして、テスト広告が表示されることを確認します。

<span id="interstitialadshtml10"/>
###<a name="htmljavascript"></a>HTML/JavaScript

次の手順では、Visual Studio 2015 で JavaScript 用のユニバーサル Windows プロジェクトを作成済みであり、特定の CPU をターゲットとしているものと想定しています。 完全なコード サンプルについては、「[JavaScript を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-javascript.md)」をご覧ください。

1. Visual Studio でプロジェクトを開きます。

2.  **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

  * ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for JavaScript]** (Version 10.0) の横のチェック ボックスをオンにします。

  * Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

  * Windows 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for Windows Phone 8.1 Native (JS)]** の横のチェック ボックスをオンにします。

3.  プロジェクト内の HTML ファイルの **&lt;head&gt;** セクションで、プロジェクトの default.css と default.js の JavaScript 参照の後に ad.js への参照を追加します。 UWP プロジェクトでは、次の参照を追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
  ```

  Windows 8.1 または Windows Phone 8.1 のプロジェクトでは、次の参照を追加します。

  > [!div class="tabbedCodeSnippets"]
  ``` html
  <script src="/MSAdvertisingJS/ads/ad.js"></script>
  ```

4.  プロジェクト内の .js ファイルで、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと、スポット広告のアプリケーション ID および広告ユニット ID を含む複数のフィールドを宣言します。 次のコード例では、`applicationId` フィールドおよび `adUnitId` フィールドを「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てています。 これらの値はテストにのみ使用されるため、アプリを公開する前に、これらの値を Windows デベロッパー センターから取得した実際の値に置き換える必要があります。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet1)]

5.  起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント ハンドラーを関連付けます。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet2)]

5. スポット広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。 これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/script.js#Snippet3)]

6.  広告を表示するコード内のポイントで、**InterstitialAd** の表示準備が整っていることを確認した後、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet4)]

7.  **InterstitialAd** オブジェクトのイベント ハンドラーを定義します。

  > [!div class="tabbedCodeSnippets"]
  [!code-javascript[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/js/samples.js#Snippet5)]

9.  アプリをビルドした後テストして、テスト広告が表示されることを確認します。

<span id="interstitialadsdirectx10"/>
###<a name="c-directx-interop"></a>C++ (DirectX Interop)

このサンプルでは、Visual Studio 2015 で C++ **DirectX および XAML アプリ (ユニバーサル Windows)** プロジェクトを作成済みであり、特定の CPU アーキテクチャをターゲットとしているものと想定しています。
 
1. Visual Studio でプロジェクトを開きます。

1.  **[参照マネージャー]** で、プロジェクトの種類に応じて次のいずれかの参照を選択します。

  * ユニバーサル Windows プラットフォーム (UWP) プロジェクトの場合: **[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。次に、**[Microsoft Advertising SDK for XAML]** (Version 10.0) の横のチェック ボックスをオンにします。

  * Windows 8.1 プロジェクトの場合: **[Windows 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

  * Windows Phone 8.1 プロジェクトの場合: **[Windows Phone 8.1]** を展開し、**[拡張機能]** をクリックします。次に、**[Ad Mediator SDK for Windows Phone 8.1 XAML]** の横のチェック ボックスをオンにします。 この場合、Microsoft Advertising ライブラリと広告メディエーター ライブラリの両方がプロジェクトに追加されますが、広告メディエーター ライブラリは無視してかまいません。

2.  アプリの適切なヘッダー ファイル (例: DirectXPage.xaml.h) 内で、[InterstitialAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.aspx) オブジェクトと関連するイベント ハンドラー メソッドを宣言します。  

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet1)]

3.  同じヘッダー ファイル内で、スポット広告のアプリケーション ID と広告ユニット ID を表す複数の文字列フィールドを宣言します。 次のコード例では、`myAppId` フィールドおよび `myAdUnitId` フィールドを「[テスト モードの値](test-mode-values.md)」で提供されているテスト値に割り当てています。 これらの値はテストにのみ使用されるため、アプリを公開する前に、これらの値を Windows デベロッパー センターから取得した実際の値に置き換える必要があります。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.h#Snippet2)]

4.  スポット広告を表示するためのコードを追加する .cpp file に、次の名前空間の参照を追加します。 次の例では、アプリの DirectXPage.xaml.cpp ファイルにそのコードを追加しているものと想定しています。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet3)]

6.  起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**InterstitialAd** オブジェクトをインスタンス化し、このオブジェクトのイベント用のイベント ハンドラーを関連付けます。 次の例では、```InterstitialAdSamplesCpp``` がプロジェクトの名前空間です。コードでは、必要に応じてこの名前を変更します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet4)]

7. スポット広告が必要になる約 30 ～ 60 秒前に、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.requestad.aspx) メソッドを使用して事前に広告を取得しておきます。 これにより、広告を表示する前に、その広告を要求して準備するための十分な時間が与えられます。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet5)]

7.  広告を表示するコード内のポイントで、**InterstitialAd** の表示準備が整っていることを確認した後、[Show](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.interstitialad.show.aspx) メソッドを使用して広告を表示します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet6)]

8.  **InterstitialAd** オブジェクトのイベント ハンドラーを定義します。

  > [!div class="tabbedCodeSnippets"]
  [!code-cpp[InterstitialAd](./code/AdvertisingSamples/InterstitialAdSamples/cpp/DirectXPage.xaml.cpp#Snippet7)]

9. アプリをビルドした後テストして、テスト広告が表示されることを確認します。

<span/>
### <a name="release-your-app-with-live-ads-using-windows-dev-center"></a>Windows デベロッパー センターを使用して、ライブ広告を表示するアプリをリリースする

1.  デベロッパー センターのダッシュボードで、アプリの **[収益化]** &gt; **[広告で収入を増やす]** ページに移動し、[広告ユニットを作成](../publish/monetize-with-ads.md)します。 広告ユニットの種類として、**[ビデオ (スポット)]** を指定します。 広告ユニット ID とアプリケーション ID の両方をメモしておきます。

2.  コードで、テスト広告ユニット値を、デベロッパー センターで生成したライブ値に置き換えます。

3.  Windows デベロッパー センター ダッシュボードを使用して、ストアに[アプリを提出](../publish/app-submissions.md)します。

4.  デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。

<span id="interstitialbestpractices10"/>
## <a name="interstitial-best-practices-and-policies"></a>スポットのベスト プラクティスとポリシー


スポット広告を効果的に使用する方法と、実行する必要があるポリシーについて詳しくは、「[スポットのベスト プラクティスとポリシー](ui-and-user-experience-guidelines.md#interstitialbestpractices10)」をご覧ください。

<span id="targetplatform10"/>
## <a name="remove-reference-errors-target-a-specific-cpu-platform-xaml-and-html"></a>参照エラーの解決: 特定の CPU プラットフォームをターゲットにする (XAML と HTML)


Microsoft Advertising ライブラリを使う場合、プロジェクトで **"Any CPU"** をターゲットにすることはできません。 プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。 この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。 詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック


* [C# を使ったスポット広告のサンプル コード#](interstitial-ad-sample-code-in-c.md)
* [JavaScript を使ったスポット広告のサンプル コード](interstitial-ad-sample-code-in-javascript.md)
* [GitHub の広告サンプル](http://aka.ms/githubads)

 

 



<!--HONumber=Dec16_HO2-->


