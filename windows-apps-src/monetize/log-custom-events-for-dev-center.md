---
Description: UWP アプリからカスタム イベントを記録し、パートナー センターでの使用状況レポートでこれらのイベントを確認できます。
title: パートナー センターのカスタム イベントをログに記録する
ms.date: 06/01/2018
ms.topic: article
keywords: windows 10, uwp, Microsoft Store Services SDK, イベントをログ記録
ms.assetid: 4aa591e0-c22a-4c90-b316-0b5d0410af19
ms.localizationpriority: medium
ms.openlocfilehash: d7b338fd3b34d530ad365b0377d6b6c6c65398b7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604237"
---
# <a name="log-custom-events-for-partner-center"></a><span data-ttu-id="244bb-104">パートナー センターのカスタム イベントをログに記録する</span><span class="sxs-lookup"><span data-stu-id="244bb-104">Log custom events for Partner Center</span></span>

<span data-ttu-id="244bb-105">[使用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)でパートナー センター、ユニバーサル Windows プラットフォーム (UWP) アプリで定義したカスタム イベントに関する情報を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="244bb-105">The [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) in Partner Center lets you get info about custom events that you've defined in your Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="244bb-106">カスタムイベントは、アプリ内のイベントやアクティビティを表す任意の文字列です。</span><span class="sxs-lookup"><span data-stu-id="244bb-106">A custom event is an arbitrary string that represents an event or activity in your app.</span></span> <span data-ttu-id="244bb-107">たとえば、ゲームで *firstLevelPassed*、*secondLevelPassed* という名前のカスタム イベントを定義して、ユーザーがゲームの各レベルをクリアしたときに記録されるようにできます。</span><span class="sxs-lookup"><span data-stu-id="244bb-107">For example, a game might define custom events named *firstLevelPassed*, *secondLevelPassed*, and so on, which are logged when the user passes each level in the game.</span></span>

<span data-ttu-id="244bb-108">アプリからのカスタム イベントをログに記録するには、カスタム イベントの文字列を Microsoft Store Services SDK で提供されている [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="244bb-108">To log a custom event from your app, pass the custom event string to the [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method provided by the Microsoft Store Services SDK.</span></span> <span data-ttu-id="244bb-109">カスタム イベントの合計出現回数を確認することができます、**カスタム イベント**のセクション、[使用状況レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)パートナー センターでします。</span><span class="sxs-lookup"><span data-stu-id="244bb-109">You can review the total occurrences for your custom events in the **Custom events** section of the [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) in Partner Center.</span></span>

> [!NOTE]
> <span data-ttu-id="244bb-110">パートナー センターにログインするカスタム イベントに関連しない[Windows イベント](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx)には表示されませんし**イベント ビューアー**します。</span><span class="sxs-lookup"><span data-stu-id="244bb-110">Custom events that you log to Partner Center are unrelated to [Windows events](https://msdn.microsoft.com/library/windows/desktop/aa964766.aspx), and they do not appear in **Event Viewer**.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="244bb-111">前提条件</span><span class="sxs-lookup"><span data-stu-id="244bb-111">Prerequisites</span></span>

<span data-ttu-id="244bb-112">カスタム ログのイベントを確認する前に、**使用状況レポート**、パートナー センターでアプリのアプリをストアに公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="244bb-112">Before you can review custom logging events in the **Usage report** for your app in Partner Center, your app must be published in the Store.</span></span>

## <a name="how-to-log-custom-events"></a><span data-ttu-id="244bb-113">カスタム イベントをログに記録する方法</span><span class="sxs-lookup"><span data-stu-id="244bb-113">How to log custom events</span></span>

1. <span data-ttu-id="244bb-114">Microsoft Store Services SDK を開発用コンピューターにインストールしていない場合には、[Microsoft Store Services SDK をインストール](microsoft-store-services-sdk.md#install-the-sdk)します。</span><span class="sxs-lookup"><span data-stu-id="244bb-114">If you have not done so already, [Install the Microsoft Store Services SDK](microsoft-store-services-sdk.md#install-the-sdk) on your development computer.</span></span>

2. <span data-ttu-id="244bb-115">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="244bb-115">Open your project in Visual Studio.</span></span>

3. <span data-ttu-id="244bb-116">ソリューション エクスプローラーで、プロジェクトの **[参照設定]** ノードを右クリックし、**[参照の追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="244bb-116">In Solution Explorer, right-click the **References** node for your project and click **Add Reference**.</span></span>

4. <span data-ttu-id="244bb-117">**[参照マネージャー]** で、**[ユニバーサル Windows]** を展開し、**[拡張機能]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="244bb-117">In **Reference Manager**, expand **Universal Windows** and click **Extensions**.</span></span>

5. <span data-ttu-id="244bb-118">SDK の一覧で、**[Microsoft Engagement Framework]** の横にあるチェック ボックスをオンにして、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="244bb-118">In the list of SDKs, click the check box next to **Microsoft Engagement Framework** and click **OK**.</span></span>

6. <span data-ttu-id="244bb-119">カスタム イベントを記録する各コード ファイルの先頭に、次のステートメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="244bb-119">Add the following statement to the top of each code file where you want to log custom events.</span></span>
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#EngagementNamespace)]

7. <span data-ttu-id="244bb-120">カスタム イベントのログを記録するコードの各セクションで、[StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) オブジェクトを取得し、[Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="244bb-120">In each section of your code where you want to log a custom event, get a [StoreServicesCustomEventLogger](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) object and then call the [Log](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log) method.</span></span> <span data-ttu-id="244bb-121">カスタム イベント文字列をメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="244bb-121">Pass your custom event string to the method.</span></span>
    [!code-cs[EventLogger](./code/StoreSDKSamples/cs/LogEvents.cs#Log)]

    > [!NOTE]
    > <span data-ttu-id="244bb-122">アプリで長い名前を持つ多くのカスタム イベントをログに記録する場合は、[[使用状況] レポート](https://msdn.microsoft.com/windows/uwp/publish/usage-report)の読み込みに時間がかかることもあります。</span><span class="sxs-lookup"><span data-stu-id="244bb-122">The [Usage report](https://msdn.microsoft.com/windows/uwp/publish/usage-report) may take a long time to load if your app logs many custom events with long names.</span></span> <span data-ttu-id="244bb-123">カスタム イベントには簡単な名前を使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="244bb-123">We recommend that you use brief names for your custom events.</span></span> 

## <a name="related-topics"></a><span data-ttu-id="244bb-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="244bb-124">Related topics</span></span>

* [<span data-ttu-id="244bb-125">利用状況レポート</span><span class="sxs-lookup"><span data-stu-id="244bb-125">Usage report</span></span>](https://msdn.microsoft.com/windows/uwp/publish/usage-report)
* [<span data-ttu-id="244bb-126">Log メソッド</span><span class="sxs-lookup"><span data-stu-id="244bb-126">Log method</span></span>](https://docs.microsoft.com/uwp/api/microsoft.services.store.engagement.storeservicescustomeventlogger.log)
* [<span data-ttu-id="244bb-127">Microsoft Store Services SDK</span><span class="sxs-lookup"><span data-stu-id="244bb-127">Microsoft Store Services SDK</span></span>](https://msdn.microsoft.com/windows/uwp/monetize/microsoft-store-services-sdk)
