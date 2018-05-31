---
author: mcleanbyron
description: UWP アプリにネイティブ広告を追加する方法について説明します。
title: ネイティブ広告
ms.author: mcleans
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, Advertising, 広告コントロール, ネイティブ広告
ms.localizationpriority: medium
ms.openlocfilehash: ff7c9249989526a454ffd702f3f95d1ebc4b4566
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1690548"
---
# <a name="native-ads"></a><span data-ttu-id="020e9-104">ネイティブ広告</span><span class="sxs-lookup"><span data-stu-id="020e9-104">Native ads</span></span>

<span data-ttu-id="020e9-105">ネイティブ広告は、コンポーネント ベースの広告形式で、各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が個々の要素としてアプリに配信されます。</span><span class="sxs-lookup"><span data-stu-id="020e9-105">A native ad is a component-based ad format where each piece of the ad creative (such as the title, image, description, and call-to-action text) is delivered to your app as an individual element.</span></span> <span data-ttu-id="020e9-106">これらの要素は、独自のフォント、色、アニメーション、その他の UI コンポーネントを使ってアプリに統合して、アプリの外観に合った控えめなユーザー エクスペリエンスを組み込むことができるうえに、広告から高収益を獲得できます。</span><span class="sxs-lookup"><span data-stu-id="020e9-106">You can integrate these elements into your app using your own fonts, colors, animations, and other UI components to stitch together an unobtrusive user experience that fits the look and feel of your app while also earning high yield from the ads.</span></span>

<span data-ttu-id="020e9-107">広告主のために、ネイティブ広告では高パフォーマンスの配置が提供されます。広告エクスペリエンスがアプリに密接に統合されることで、ユーザーがこのような種類の広告と対話しやすくなる傾向があるためです。</span><span class="sxs-lookup"><span data-stu-id="020e9-107">For advertisers, native ads provide high-performing placements, because the ad experience is tightly integrated into the app and users therefore tend to interact more with these types of ads.</span></span>

> [!NOTE]
> <span data-ttu-id="020e9-108">ネイティブ広告を Store 内の公開バージョンのアプリに提供するには、デベロッパー センター ダッシュボードの **[収益化]** &gt; **[アプリ内広告]** ページから、**ネイティブ**の広告ユニットを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="020e9-108">To serve native ads to the public version of your app in the Store, you must create a **Native** ad unit from the **Monetize** &gt; **In-app ads** page in the Dev Center dashboard.</span></span> <span data-ttu-id="020e9-109">**ネイティブ**広告ユニットを作成する機能は、現在はパイロット プログラムに参加している開発者だけが利用できますが、まもなくすべての開発者がこの機能を利用できるようにする予定です。</span><span class="sxs-lookup"><span data-stu-id="020e9-109">The ability to create **Native** ad units is currently available only to select developers who are participating in a pilot program, but we intend to make  this feature available to all developers soon.</span></span> <span data-ttu-id="020e9-110">パイロット プログラムへの参加に関心がある方は、aiacare@microsoft.com までお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="020e9-110">If you are interested in joining our pilot program, reach out to us at aiacare@microsoft.com.</span></span>

> [!NOTE]
> <span data-ttu-id="020e9-111">ネイティブ広告は現在、XAML ベースの Windows 10 用 UWP アプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="020e9-111">Native ads are currently supported only for XAML-based UWP apps for Windows 10.</span></span> <span data-ttu-id="020e9-112">HTML と JavaScript を使って作成された UWP アプリについては、今後リリースされる Microsoft Advertising SDK でサポートされる予定です。</span><span class="sxs-lookup"><span data-stu-id="020e9-112">Support for UWP apps written using HTML and JavaScript is planned for a future release of the Microsoft Advertising SDK.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="020e9-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="020e9-113">Prerequisites</span></span>

* <span data-ttu-id="020e9-114">Visual Studio 2015 以降の Visual Studio のリリースと共に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="020e9-114">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) with Visual Studio 2015 or a later release of Visual Studio.</span></span> <span data-ttu-id="020e9-115">インストール手順については、[この記事](install-the-microsoft-advertising-libraries.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="020e9-115">For installation instructions, see [this article](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="integrate-a-native-ad-into-your-app"></a><span data-ttu-id="020e9-116">ネイティブ広告をアプリに統合する</span><span class="sxs-lookup"><span data-stu-id="020e9-116">Integrate a native ad into your app</span></span>

<span data-ttu-id="020e9-117">次の手順に従って、ネイティブ広告をアプリに統合し、ネイティブ広告の実装によってテスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="020e9-117">Follow these instructions to integrate a native ad into your app and confirm that your native ad implementation shows a test ad.</span></span>

1. <span data-ttu-id="020e9-118">Visual Studio でプロジェクトを開くか、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="020e9-118">In Visual Studio, open your project or create a new project.</span></span>
    > [!NOTE]
    > <span data-ttu-id="020e9-119">既存のプロジェクトを使用している場合、プロジェクトの Package.appxmanifest ファイルを開き、**インターネット (クライアント)** 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="020e9-119">If you're using an existing project, open the Package.appxmanifest file in your project and ensure that the **Internet (Client)** capability is selected.</span></span> <span data-ttu-id="020e9-120">アプリでは、テスト広告やライブ広告を受信するためにこの機能が必要になります。</span><span class="sxs-lookup"><span data-stu-id="020e9-120">Your app needs this capability to receive test ads and live ads.</span></span>

2. <span data-ttu-id="020e9-121">プロジェクトのターゲットが **[任意の CPU]** になっている場合は、アーキテクチャ固有のビルド出力 (たとえば、**[x86]**) を使うようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="020e9-121">If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="020e9-122">プロジェクトのターゲットが **[Any CPU]** (任意の CPU) になっていると、次の手順で Microsoft Advertising SDK への参照を正常に追加できません。</span><span class="sxs-lookup"><span data-stu-id="020e9-122">If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft Advertising SDK in the following steps.</span></span> <span data-ttu-id="020e9-123">詳しくは、「[プロジェクトのターゲットを "任意の CPU" に設定すると参照エラーが発生する](known-issues-for-the-advertising-libraries.md#reference_errors)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="020e9-123">For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).</span></span>

3. <span data-ttu-id="020e9-124">プロジェクトで Microsoft Advertising SDK への参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="020e9-124">Add a reference to the Microsoft Advertising SDK in your project:</span></span>

    1. <span data-ttu-id="020e9-125">**[ソリューション エクスプローラー]** ウィンドウで、**[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="020e9-125">From the **Solution Explorer** window, right click **References**, and select **Add Reference…**</span></span>
    2.  <span data-ttu-id="020e9-126">**[参照マネージャー]** で、**[Universal Windows]** を展開し、**[拡張]** をクリックして、**[Microsoft Advertising SDK for XAML]** (バージョン 10.0) の横にあるチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="020e9-126">In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for XAML** (Version 10.0).</span></span>
    3.  <span data-ttu-id="020e9-127">**[参照マネージャー]** で、[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="020e9-127">In **Reference Manager**, click OK.</span></span>

4. <span data-ttu-id="020e9-128">アプリの適切なコード ファイル (たとえば、MainPage.xaml.cs またはその他のページのコード ファイル) に、次の名前空間の参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="020e9-128">In the appropriate code file in your app (for example, in MainPage.xaml.cs or a code file for some other page), add the following namespace references.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#Namespaces)]

5.  <span data-ttu-id="020e9-129">アプリの適切な場所 (たとえば、```MainPage``` またはその他のページ) で、[NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.aspx) オブジェクトと、ネイティブ広告のアプリケーション ID および広告ユニット ID を表す複数の文字列フィールドを宣言します。</span><span class="sxs-lookup"><span data-stu-id="020e9-129">In an appropriate location in your app (for example, in ```MainPage``` or some other page), declare a [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.aspx) object and several string fields that represent the application ID and ad unit ID for your native ad.</span></span> <span data-ttu-id="020e9-130">次のコード例は、`myAppId` と `myAdUnitId`フィールドに、ネイティブ広告の setup-ad-units-in-your-app.md#live-ad-units を割り当てます。</span><span class="sxs-lookup"><span data-stu-id="020e9-130">The following code example assigns the `myAppId` and `myAdUnitId` fields to the set-up-ad-units-in-your-app.md#live-ad-units for native ads.</span></span>
    > [!NOTE]
    > <span data-ttu-id="020e9-131">各 **NativeAdsManager** に、対応する*広告ユニット*があります。広告ユニットは、ネイティブ広告コントロールに広告を提供するためにサービスで使われます。すべての広告ユニットは、*広告ユニット ID* と*アプリケーション ID* で構成されます。</span><span class="sxs-lookup"><span data-stu-id="020e9-131">Every **NativeAdsManager** has a corresponding *ad unit* that is used by our services to serve ads to the native ad control, and every ad unit consists of an *ad unit ID* and *application ID*.</span></span> <span data-ttu-id="020e9-132">ここでは、広告ユニット ID とアプリケーション ID のテスト値をコントロールに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="020e9-132">In these steps, you assign test ad unit ID and application ID values to your control.</span></span> <span data-ttu-id="020e9-133">これらのテスト値は、テスト バージョンのアプリでのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="020e9-133">These test values can only be used in a test version of your app.</span></span> <span data-ttu-id="020e9-134">Microsoft Store にアプリを公開する前に、[これらのテスト値を Windows デベロッパー センターから取得した実際の値に置き換える](#release)必要があります。</span><span class="sxs-lookup"><span data-stu-id="020e9-134">Before you publish your app to the Store, you must [replace these test values with live values](#release) from Windows Dev Center.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#Variables)]

6.  <span data-ttu-id="020e9-135">起動時に実行されるコード (たとえば、ページのコンストラクター) 内で、**NativeAdsManager** オブジェクトをインスタンス化し、このオブジェクトの [AdReady](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.adready.aspx) イベントと [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.erroroccurred.aspx) イベント用のイベント ハンドラーを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="020e9-135">In code that runs on startup (for example, in the constructor for the page), instantiate the **NativeAdsManager** object and wire up event handlers for the [AdReady](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.adready.aspx) and [ErrorOccurred](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.erroroccurred.aspx) events of the object.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#ConfigureNativeAd)]

7.  <span data-ttu-id="020e9-136">ネイティブ広告を表示する準備ができたら、[RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.requestad.aspx) メソッドを呼び出して、広告を取得します。</span><span class="sxs-lookup"><span data-stu-id="020e9-136">When you're ready to show a native ad, call the [RequestAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.requestad.aspx) method to fetch an ad.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#RequestAd)]

8.  <span data-ttu-id="020e9-137">アプリ用にネイティブ広告の準備ができたら、**AdReady** イベント ハンドラーが呼び出され、ネイティブ広告を表す [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) オブジェクトが *e* パラメーターに渡されます。</span><span class="sxs-lookup"><span data-stu-id="020e9-137">When a native ad is ready for your app, your **AdReady** event handler is called, and a [NativeAd](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.aspx) object that represents the native ad is passed to the *e* parameter.</span></span> <span data-ttu-id="020e9-138">**NativeAd** プロパティを使ってネイティブ広告の各要素を取得し、ページ上にそれらの要素を表示します。</span><span class="sxs-lookup"><span data-stu-id="020e9-138">Use the **NativeAd** properties to get each element of the native ad and display these elements on your page.</span></span> <span data-ttu-id="020e9-139">また、[RegisterAdContainer](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.registeradcontainer.aspx) メソッドを呼び出して、ネイティブ広告のコンテナーとして機能する UI 要素を登録してください。広告インプレッションと広告クリックを適切に追跡するために必要です。</span><span class="sxs-lookup"><span data-stu-id="020e9-139">Be sure to also call the [RegisterAdContainer](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativead.registeradcontainer.aspx) method to register the UI element that acts as a container for the native ad; this is required to properly track ad impressions and clicks.</span></span>
    > [!NOTE]
    > <span data-ttu-id="020e9-140">ネイティブ広告の一部の要素は必須であり、アプリに常に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="020e9-140">Some elements of the native ad are required and must always be shown in your app.</span></span> <span data-ttu-id="020e9-141">詳しくは、「[ネイティブ広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-native-ads)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="020e9-141">For more information, see our [guidelines for native ads](ui-and-user-experience-guidelines.md#guidelines-for-native-ads).</span></span>

    <span data-ttu-id="020e9-142">たとえば、アプリに次のような **StackPanel** を持つ ```MainPage``` (またはその他のページ) が含まれているとします。</span><span class="sxs-lookup"><span data-stu-id="020e9-142">For example, assume that your app contains a ```MainPage``` (or some other page) with the following **StackPanel**.</span></span> <span data-ttu-id="020e9-143">この **StackPanel** には、ネイティブ広告のさまざまな要素 (タイトル、説明、画像、*スポンサー* テキスト、*行動喚起*テキストを表示するボタンなど) を表示する一連のコントロールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="020e9-143">This **StackPanel** contains a series of controls that display different elements of a native ad, including the title, description, images, *sponsored by* text, and a button that will show the *call to action* text.</span></span>

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

    <span data-ttu-id="020e9-144">次のコード例は、**StackPanel** のコントロールにネイティブ広告の各要素を表示してから、**RegisterAdContainer** メソッドを呼び出して **StackPanel** を登録する **AdReady** イベント ハンドラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="020e9-144">The following code example demonstrates an **AdReady** event handler that displays each element of the native ad in the controls in the **StackPanel** and then calls the **RegisterAdContainer** method to register the **StackPanel**.</span></span> <span data-ttu-id="020e9-145">このコードでは、**StackPanel** が含まれているページの分離コード ファイルから実行されることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="020e9-145">This code assumes that it is run from the code-behind file for the page that contains the **StackPanel**.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#AdReady)]

9.  <span data-ttu-id="020e9-146">**ErrorOccurred** イベントのイベント ハンドラーを定義して、ネイティブ広告に関連するエラーを処理します。</span><span class="sxs-lookup"><span data-stu-id="020e9-146">Define an event handler for the **ErrorOccurred** event to handle errors related to the native ad.</span></span> <span data-ttu-id="020e9-147">次の例では、テスト中に Visual Studio の **[出力]** ウィンドウにエラー情報を書き込みます。</span><span class="sxs-lookup"><span data-stu-id="020e9-147">The following example writes error information to the Visual Studio **Output** window during testing.</span></span>

    [!code-cs[NativeAd](./code/AdvertisingSamples/NativeAdSamples/cs/MainPage.xaml.cs#ErrorOccurred)]

10.  <span data-ttu-id="020e9-148">アプリをコンパイルして実行し、テスト広告が表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="020e9-148">Compile and run the app to see it with a test ad.</span></span>

<span id="release" />

## <a name="release-your-app-with-live-ads"></a><span data-ttu-id="020e9-149">ライブ広告を表示するアプリをリリースする</span><span class="sxs-lookup"><span data-stu-id="020e9-149">Release your app with live ads</span></span>

<span data-ttu-id="020e9-150">ネイティブ広告の実装によってテスト広告が正常に表示されることを確認したら、次の手順に従って、実際の広告を表示するようにアプリを構成し、更新したアプリをストアに提出します。</span><span class="sxs-lookup"><span data-stu-id="020e9-150">After you confirm that your native ad implementation successfully shows a test ad, follow these instructions to configure your app to show real ads and submit your updated app to the Store.</span></span>

1.  <span data-ttu-id="020e9-151">ネイティブ広告の実装が[ネイティブ広告のガイドライン](ui-and-user-experience-guidelines.md#guidelines-for-native-ads)に従っていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="020e9-151">Make sure that your native ad implementation follows our [guidelines for native ads](ui-and-user-experience-guidelines.md#guidelines-for-native-ads).</span></span>

2.  <span data-ttu-id="020e9-152">デベロッパー センター ダッシュボードで、[[アプリ内広告]](../publish/in-app-ads.md) ページに移動し、[広告ユニットを作成](set-up-ad-units-in-your-app.md#live-ad-units)します。</span><span class="sxs-lookup"><span data-stu-id="020e9-152">In the Dev Center dashboard, go to the [In-app ads](../publish/in-app-ads.md) page and [create an ad unit](set-up-ad-units-in-your-app.md#live-ad-units).</span></span> <span data-ttu-id="020e9-153">広告ユニットの種類として、**[ネイティブ]** を指定します。</span><span class="sxs-lookup"><span data-stu-id="020e9-153">For the ad unit type, specify **Native**.</span></span> <span data-ttu-id="020e9-154">広告ユニット ID とアプリケーション ID の両方を書き留めておきます。</span><span class="sxs-lookup"><span data-stu-id="020e9-154">Make note of both the ad unit ID and the application ID.</span></span>
    > [!NOTE]
    > <span data-ttu-id="020e9-155">テスト広告ユニットとライブ UWP 広告ユニットでは、アプリケーション ID の値の形式が異なります。</span><span class="sxs-lookup"><span data-stu-id="020e9-155">The application ID values for test ad units and live UWP ad units have different formats.</span></span> <span data-ttu-id="020e9-156">テスト アプリケーション ID の値は GUID です。</span><span class="sxs-lookup"><span data-stu-id="020e9-156">Test application ID values are GUIDs.</span></span> <span data-ttu-id="020e9-157">ダッシュボードでライブ UWP 広告ユニットを作成する場合、広告ユニットのアプリケーション ID の値は常にアプリの Store ID に一致します (Store ID 値は、たとえば 9NBLGGH4R315 のようになります)。</span><span class="sxs-lookup"><span data-stu-id="020e9-157">When you create a live UWP ad unit in the dashboard, the application ID value for the ad unit always matches the Store ID for your app (an example Store ID value looks like 9NBLGGH4R315).</span></span>

3. <span data-ttu-id="020e9-158">必要に応じて、[[アプリ内広告]](../publish/in-app-ads.md) ページの [[仲介設定]](../publish/in-app-ads.md#mediation) セクションで設定を構成することで、ネイティブ広告の広告仲介を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="020e9-158">You can optionally enable ad mediation for the native ad by configuring the settings in the [Mediation settings](../publish/in-app-ads.md#mediation) section on the [In-app ads](../publish/in-app-ads.md) page.</span></span> <span data-ttu-id="020e9-159">広告仲介を利用すると、複数の広告ネットワークから広告を表示して、広告収益とアプリ プロモーションの機能を最大限に引き出すことができます。</span><span class="sxs-lookup"><span data-stu-id="020e9-159">Ad mediation enables you to maximize your ad revenue and app promotion capabilities by displaying ads from multiple ad networks.</span></span>

4.  <span data-ttu-id="020e9-160">コードで、広告ユニットのテスト値 ([NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) コンストラクターの *applicationId* パラメーターと *adUnitId* パラメーター) を、デベロッパー センターで生成した実際の値に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="020e9-160">In your code, replace the test ad unit values (that is, the *applicationId* and *adUnitId* parameters of the [NativeAdsManager](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.nativeadsmanager.nativeadsmanager.aspx) constructor) with the live values you generated in Dev Center.</span></span>

5.  <span data-ttu-id="020e9-161">デベロッパー センター ダッシュボードを使用して、ストアに[アプリを申請](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="020e9-161">[Submit your app](../publish/app-submissions.md) to the Store using the Dev Center dashboard.</span></span>

6.  <span data-ttu-id="020e9-162">デベロッパー センター ダッシュボードで[広告パフォーマンス レポート](../publish/advertising-performance-report.md)を確認します。</span><span class="sxs-lookup"><span data-stu-id="020e9-162">Review your [advertising performance reports](../publish/advertising-performance-report.md) in the Dev Center dashboard.</span></span>

## <a name="manage-ad-units-for-multiple-native-ads-in-your-app"></a><span data-ttu-id="020e9-163">アプリで複数のネイティブ広告の広告ユニットを管理する</span><span class="sxs-lookup"><span data-stu-id="020e9-163">Manage ad units for multiple native ads in your app</span></span>

<span data-ttu-id="020e9-164">1 つのアプリで複数のネイティブ広告を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="020e9-164">You can use multiple native ad placements in a single app.</span></span> <span data-ttu-id="020e9-165">このシナリオでは、各ネイティブ広告の配置に異なる広告ユニットを割り当てることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="020e9-165">In this scenario, we recommend that you assign a different ad unit to each native ad placements.</span></span> <span data-ttu-id="020e9-166">各コントロールに異なるネイティブ広告ユニットを使用することで、別々に[仲介の設定を構成](../publish/in-app-ads.md#mediation)して、個別の[報告データ](../publish/advertising-performance-report.md)を取得できます。</span><span class="sxs-lookup"><span data-stu-id="020e9-166">Using different ad units for native ad enables you to separately [configure the mediation settings](../publish/in-app-ads.md#mediation) and get discrete [reporting data](../publish/advertising-performance-report.md) for each control.</span></span> <span data-ttu-id="020e9-167">また、これにより、Microsoft のサービスはアプリに提供する広告を最適化できます。</span><span class="sxs-lookup"><span data-stu-id="020e9-167">This also enables our services to better optimize the ads we serve to your app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="020e9-168">各広告ユニットは 1 つのアプリのみで使用できます。</span><span class="sxs-lookup"><span data-stu-id="020e9-168">You can use each ad unit in only one app.</span></span> <span data-ttu-id="020e9-169">複数のアプリで広告ユニットを使うと、広告ユニットに広告が提供されません。</span><span class="sxs-lookup"><span data-stu-id="020e9-169">If you use an ad unit in more than one app, ads will not be served for that ad unit.</span></span>

## <a name="related-topics"></a><span data-ttu-id="020e9-170">関連トピック</span><span class="sxs-lookup"><span data-stu-id="020e9-170">Related topics</span></span>

* [<span data-ttu-id="020e9-171">ネイティブ広告のガイドライン</span><span class="sxs-lookup"><span data-stu-id="020e9-171">Guidelines for native ads</span></span>](ui-and-user-experience-guidelines.md#guidelines-for-native-ads)
* [<span data-ttu-id="020e9-172">アプリ内広告</span><span class="sxs-lookup"><span data-stu-id="020e9-172">In-app ads</span></span>](../publish/in-app-ads.md)
* [<span data-ttu-id="020e9-173">アプリの広告ユニットをセットアップする</span><span class="sxs-lookup"><span data-stu-id="020e9-173">Set up ad units for your app</span></span>](set-up-ad-units-in-your-app.md)
