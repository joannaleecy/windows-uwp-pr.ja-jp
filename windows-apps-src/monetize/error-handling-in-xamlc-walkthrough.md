---
author: Xansky
ms.assetid: cf0d2709-21a1-4d56-9341-d4897e405f5d
description: アプリで AdControl エラーをキャッチする方法について説明します。
title: XAML/C# ウォークスルーでのエラー処理
ms.author: mhopkins
ms.date: 05/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, エラー処理, XAML, C#
ms.localizationpriority: medium
ms.openlocfilehash: e4387ccb8ef7eb02cb0043530a4e683f7917f421
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5473492"
---
# <a name="error-handling-in-xamlc-walkthrough"></a><span data-ttu-id="f7202-104">XAML/C# ウォークスルーでのエラー処理</span><span class="sxs-lookup"><span data-stu-id="f7202-104">Error handling in XAML/C# walkthrough</span></span>

<span data-ttu-id="f7202-105">このチュートリアルでは、アプリで広告関連のエラーをキャッチする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f7202-105">This walkthrough demonstrates how to catch ad-related errors in your app.</span></span> <span data-ttu-id="f7202-106">このチュートリアルでは、[AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) を使用してバナー広告を表示していますが、その中の一般的な概念はスポット広告やネイティブ広告にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="f7202-106">This walkthrough uses an [AdControl](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol) to display a banner ad, but the general concepts in it also apply to interstitial ads and native ads.</span></span>

<span data-ttu-id="f7202-107">これらの例は、**AdControl** を含む XAML/C# アプリがあることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="f7202-107">These examples assume that you have a XAML/C# app that contains an **AdControl**.</span></span> <span data-ttu-id="f7202-108">アプリに **AdControl** を追加する方法を示す具体的な手順については、「[XAML および .NET の AdControl](adcontrol-in-xaml-and--net.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f7202-108">For step-by-step instructions that demonstrate how to add an **AdControl** to your app, see [AdControl in XAML and .NET](adcontrol-in-xaml-and--net.md).</span></span> 

1.  <span data-ttu-id="f7202-109">MainPage.xaml ファイルで、**AdControl** の定義を見つけます。</span><span class="sxs-lookup"><span data-stu-id="f7202-109">In your MainPage.xaml file, locate the definition for the **AdControl**.</span></span> <span data-ttu-id="f7202-110">コードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f7202-110">That code looks like this.</span></span>
    ``` xml
    <UI:AdControl
      ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
      AdUnitId="test"
      HorizontalAlignment="Left"
      Height="250"
      Margin="10,10,0,0"
      VerticalAlignment="Top"
      Width="300" />
    ```

2.   <span data-ttu-id="f7202-111">**Width** プロパティの後、終了タグの前で、エラー イベント ハンドラーの名前を [ErrorOccurred](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.erroroccurred) イベントに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="f7202-111">After the **Width** property, but before the closing tag, assign a name of an error event handler to the [ErrorOccurred](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.erroroccurred) event.</span></span> <span data-ttu-id="f7202-112">このウォークスルーでは、エラー イベント ハンドラーの名前は **OnAdError** です。</span><span class="sxs-lookup"><span data-stu-id="f7202-112">In this walkthrough, the name of the error event handler is **OnAdError**.</span></span>
    ``` xml
    <UI:AdControl
      ApplicationId="3f83fe91-d6be-434d-a0ae-7351c5a997f1"
      AdUnitId="test"
      HorizontalAlignment="Left"
      Height="250"
      Margin="10,10,0,0"
      VerticalAlignment="Top"
      Width="300"
      ErrorOccurred="OnAdError"/>
    ```

3.  <span data-ttu-id="f7202-113">実行時にエラーを生成するために、2 つ目の **AdControl** を異なるアプリケーション ID を使って作成します。</span><span class="sxs-lookup"><span data-stu-id="f7202-113">To generate an error at runtime, create a second **AdControl** with a different application ID.</span></span> <span data-ttu-id="f7202-114">アプリ内のすべての **AdControl** オブジェクトは同じアプリケーション ID を使う必要があるため、追加の **AdControl** を異なるアプリケーション ID を使って作成するとエラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="f7202-114">Because all **AdControl** objects in an app must use the same application ID, creating an additional **AdControl** with a different application id will throw an error.</span></span>

    <span data-ttu-id="f7202-115">MainPage.xaml で、最初の **AdControl** の直後に 2 つ目の **AdControl** を定義し、[ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) プロパティをゼロ (“0”) に設定します。</span><span class="sxs-lookup"><span data-stu-id="f7202-115">Define a second **AdControl** in MainPage.xaml just after the first **AdControl**, and set the [ApplicationId](https://docs.microsoft.com/uwp/api/microsoft.advertising.winrt.ui.adcontrol.applicationid) property to zero (“0”).</span></span>
    ``` xml
    <UI:AdControl
        ApplicationId="0"
        AdUnitId="test"
        HorizontalAlignment="Left"
        Height="250"
        Margin="10,265,0,0"
        VerticalAlignment="Top"
        Width="300"
        ErrorOccurred="OnAdError" />
    ```

4.  <span data-ttu-id="f7202-116">MainPage.xaml.cs で、次の **OnAdError** イベント ハンドラーを **MainPage** クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="f7202-116">In MainPage.xaml.cs, add the following **OnAdError** event handler to the **MainPage** class.</span></span> <span data-ttu-id="f7202-117">このイベント ハンドラーは、Visual Studio の **[出力]** ウィンドウに情報を書き込みます。</span><span class="sxs-lookup"><span data-stu-id="f7202-117">This event handler writes information to the Visual Studio **Output** window.</span></span>
    ``` csharp
    private void OnAdError(object sender, AdErrorEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("AdControl error (" + ((AdControl)sender).Name +
            "): " + e.ErrorMessage + " ErrorCode: " + e.ErrorCode.ToString());
    }
    ```

4.  <span data-ttu-id="f7202-118">プロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="f7202-118">Build and run the project.</span></span> <span data-ttu-id="f7202-119">アプリの実行後に、次のようなメッセージが Visual Studio の **[出力]** ウィンドウに表示されます。</span><span class="sxs-lookup"><span data-stu-id="f7202-119">After the app is running, you will see a message similar to the one below in the **Output** window of Visual Studio.</span></span>
    ```
    AdControl error (): MicrosoftAdvertising.Shared.AdException: all ad requests must use the same application ID within a single application (0, d25517cb-12d4-4699-8bdc-52040c712cab) ErrorCode: ClientConfiguration
    ```

## <a name="related-topics"></a><span data-ttu-id="f7202-120">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f7202-120">Related topics</span></span>

* [<span data-ttu-id="f7202-121">GitHub の広告サンプル</span><span class="sxs-lookup"><span data-stu-id="f7202-121">Advertising samples on GitHub</span></span>](http://aka.ms/githubads)
