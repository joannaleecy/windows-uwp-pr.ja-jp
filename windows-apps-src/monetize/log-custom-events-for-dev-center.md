---
author: Xansky
Description: You can log custom events from your UWP app and review those events in the Usage report in Partner Center.
title: パートナー センターのカスタム イベントをログに記録する
ms.author: mhopkins
ms.date: 06/01/2018
ms.topic: article
keywords: Windows 10, UWP, Microsoft Store Services SDK, イベントをログ記録
ms.assetid: 4aa591e0-c22a-4c90-b316-0b5d0410af19
ms.localizationpriority: medium
ms.openlocfilehash: 47c1eb02434dc71cb7da949d58ec38cf3b4cf65a
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7419154"
---
# <a name="log-custom-events-for-partner-center"></a><span data-ttu-id="4024d-103">パートナー センターのカスタム イベントをログに記録する</span><span class="sxs-lookup"><span data-stu-id="4024d-103">Log custom events for Partner Center</span></span>

<span data-ttu-id="4024d-104">パートナー センターでの[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)では、ユニバーサル Windows プラットフォーム (UWP) アプリで定義したカスタム イベントに関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="4024d-104">The [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) in Partner Center lets you get info about custom events that you've defined in your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="4024d-105">カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。</span><span class="sxs-lookup"><span data-stu-id="4024d-105">A custom event is an arbitrary string that represents an event or activity in your app.</span></span> <span data-ttu-id="4024d-106">たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="4024d-106">For example, a game might define custom events named *firstLevelPassed*, *secondLevelPassed*, and so on, which are logged when the user passes each level in the game.</span></span>

<span data-ttu-id="4024d-107">アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="4024d-107">To log a custom event from your app, pass the custom event string to the [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method provided by the Microsoft Store Services SDK.</span></span> <span data-ttu-id="4024d-108">パートナー センターでの[利用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の**カスタム イベント**のセクションで、カスタム イベントした合計回数を確認できます。</span><span class="sxs-lookup"><span data-stu-id="4024d-108">You can review the total occurrences for your custom events in the **Custom events** section of the [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) in Partner Center.</span></span>

> [!NOTE]
> <span data-ttu-id="4024d-109">パートナー センターに記録したカスタムのイベントは、 [Windows イベント](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx)に関連して、**イベント ビューアー**には表示されません。</span><span class="sxs-lookup"><span data-stu-id="4024d-109">Custom events that you log to Partner Center are unrelated to [Windows events](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx), and they do not appear in **Event Viewer**.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="4024d-110">前提条件</span><span class="sxs-lookup"><span data-stu-id="4024d-110">Prerequisites</span></span>

<span data-ttu-id="4024d-111">**使用状況] レポート**でカスタム ログ イベントを確認するにはパートナー センターでのアプリの前に、ストアでアプリを公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4024d-111">Before you can review custom logging events in the **Usage report** for your app in Partner Center, your app must be published in the Store.</span></span>

## <a name="how-to-log-custom-events"></a><span data-ttu-id="4024d-112">カスタム イベントをログに記録する方法</span><span class="sxs-lookup"><span data-stu-id="4024d-112">How to log custom events</span></span>

1. <span data-ttu-id="4024d-113">Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。</span><span class="sxs-lookup"><span data-stu-id="4024d-113">If you have not done so already, [Install the Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) on your development computer.</span></span>

2. <span data-ttu-id="4024d-114">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="4024d-114">Open your project in Visual Studio.</span></span>

3. <span data-ttu-id="4024d-115">ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4024d-115">In Solution Explorer, right-click the **References** node for your project and click **Add Reference**.</span></span>

4. <span data-ttu-id="4024d-116">**[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4024d-116">In **Reference Manager**, expand **Universal Windows** and click **Extensions**.</span></span>

5. <span data-ttu-id="4024d-117">SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4024d-117">In the list of SDKs, click the check box next to **Microsoft Engagement Framework** and click **OK**.</span></span>

6. <span data-ttu-id="4024d-118">カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="4024d-118">Add the following statement to the top of each code file where you want to log custom events.</span></span>
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#EngagementNamespace)]

7. <span data-ttu-id="4024d-119">カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) オブジェクトを取得し、[Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="4024d-119">In each section of your code where you want to log a custom event, get a [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) object and then call the [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method.</span></span> <span data-ttu-id="4024d-120">カスタム イベント文字列をメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="4024d-120">Pass your custom event string to the method.</span></span>
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#Log)]

    > [!NOTE]
    > <span data-ttu-id="4024d-121">アプリで長い名前を持つ多くのカスタム イベントをログに記録する場合は、[[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の読み込みに時間がかかることもあります。</span><span class="sxs-lookup"><span data-stu-id="4024d-121">The [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) may take a long time to load if your app logs many custom events with long names.</span></span> <span data-ttu-id="4024d-122">カスタム イベントには簡単な名前を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4024d-122">We recommend that you use brief names for your custom events.</span></span> 

## <a name="related-topics"></a><span data-ttu-id="4024d-123">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4024d-123">Related topics</span></span>

* [<span data-ttu-id="4024d-124">利用状況レポート</span><span class="sxs-lookup"><span data-stu-id="4024d-124">Usage report</span></span>](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [<span data-ttu-id="4024d-125">Log メソッド</span><span class="sxs-lookup"><span data-stu-id="4024d-125">Log method</span></span>](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log)
* [<span data-ttu-id="4024d-126">Microsoft Store Services SDK</span><span class="sxs-lookup"><span data-stu-id="4024d-126">Microsoft Store Services SDK</span></span>](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)
