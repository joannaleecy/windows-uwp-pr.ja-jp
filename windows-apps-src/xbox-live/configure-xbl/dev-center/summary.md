---
title: Xbox Live の概要] ページ
author: KevinAsgari
description: Xbox Live の概要ビューを利用する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 10/19/2018
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox live, Xbox、ゲーム, uwp, windows 10, Xbox one、xbox live 概要を要約すると、公開をまとめた表、xbox live 履歴、コマンド バー、[履歴] タブ
ms.openlocfilehash: ef146e77a12c3c658e4e55cf468b3dae433e6f9b
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6209803"
---
# <a name="the-xbox-live-configuration-summary-page"></a><span data-ttu-id="11387-104">Xbox Live 構成の概要] ページ</span><span class="sxs-lookup"><span data-stu-id="11387-104">The Xbox Live configuration summary page</span></span>

<span data-ttu-id="11387-105">[パートナー センター](https://developer.microsoft.com/dashboard)を使用して、タイトルの Xbox Live を構成することができます。</span><span class="sxs-lookup"><span data-stu-id="11387-105">You can use [Partner Center](https://developer.microsoft.com/dashboard) to configure Xbox Live for your title.</span></span> <span data-ttu-id="11387-106">パートナー センターでタイトルのサンド ボックスごとのサービス構成を管理できるようにできます。</span><span class="sxs-lookup"><span data-stu-id="11387-106">With Partner Center you will be able to manage the service configuration for each of your title's sandboxes.</span></span>
<span data-ttu-id="11387-107">**サービス**の下にあるタイトルの Xbox Live の側面を構成、タイトルの Xbox Live のセクションに移動するために > **Xbox Live**します。</span><span class="sxs-lookup"><span data-stu-id="11387-107">In order to configure the Xbox Live aspects of your title, navigate to the Xbox Live section for your title, located under **Services** > **Xbox Live**.</span></span> <span data-ttu-id="11387-108">このページで選択されているサンド ボックスで、現在の構成のスナップショットが表示されます。</span><span class="sxs-lookup"><span data-stu-id="11387-108">On this page, you will find a snapshot of your current configuration on the selected sandbox.</span></span> <span data-ttu-id="11387-109">また、何が構成され、同様のサンド ボックスに公開の詳細な内訳もあります。</span><span class="sxs-lookup"><span data-stu-id="11387-109">You will also find a detailed breakdown of what has been configured and published to the sandbox as well.</span></span>

## <a name="sandbox-selector"></a><span data-ttu-id="11387-110">サンド ボックスのセレクター</span><span class="sxs-lookup"><span data-stu-id="11387-110">Sandbox selector</span></span>

 <span data-ttu-id="11387-111">[サンド ボックス](../../xbox-live-sandboxes.md)は、トップレベルのナビゲーション項目間で切り替えるまたは選択して展開できます。</span><span class="sxs-lookup"><span data-stu-id="11387-111">[Sandboxes](../../xbox-live-sandboxes.md) are now a top-level navigation item you can switch between or expand by selection.</span></span> <span data-ttu-id="11387-112">UI には、タブとして、上部にあるタイトルのサンド ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="11387-112">The UI displays the title's sandboxes at the top as tabs.</span></span> <span data-ttu-id="11387-113">各タブに表示される情報は、関連付けられているサンド ボックスのコンテキストでです。</span><span class="sxs-lookup"><span data-stu-id="11387-113">The information shown in each tab is in the context of the associated sandbox.</span></span>  

![サンド ボックスのタブの切り替えの画像](../../images/summary/sandbox-tabs1.gif)

 <span data-ttu-id="11387-115">追加サンド ボックスを追加するには選択することによって、「+」のダイアログ ボックスが表示される構成をコピーしたいから構成をコピーするにはどのサンド ボックスとどのサンド ボックスを指定する場合。</span><span class="sxs-lookup"><span data-stu-id="11387-115">You can add additional sandboxes by selecting the "+" which will present you with a dialog where you specify which sandbox you would like to copy the config from and which sandbox you would like to copy the config to.</span></span>  

 ![新しいサンド ボックス] タブに展開の画像](../../images/summary/sandbox-tabs2.gif)

## <a name="command-bar"></a><span data-ttu-id="11387-117">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="11387-117">Command bar</span></span>

<span data-ttu-id="11387-118">前述した表示されるページは常に、サンド ボックス内のコンテキスト内でためすぐ下に公開されるコマンド バーは、特定のサンド ボックスで実行できるすべてのアクションを示します。</span><span class="sxs-lookup"><span data-stu-id="11387-118">As mentioned above the page displayed is always within the context of a sandbox, therefore the command bar exposed just below it shows all the actions you can perform in your given sandbox.</span></span> <span data-ttu-id="11387-119">使用するコマンドは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="11387-119">The commands available to you are:</span></span>  

* <span data-ttu-id="11387-120">**エクスポート**のサンド ボックス内で構成されているすべてのドキュメントを含む zip ファイルを提供します。</span><span class="sxs-lookup"><span data-stu-id="11387-120">**Export** - Which provides you a zip file that contains all configured documents within the sandbox.</span></span>
* <span data-ttu-id="11387-121">**インポート**- では、1 回アップロードが使用できるサンド ボックスで、有効な XBL ドキュメントを含む zip ファイルを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="11387-121">**Import** - Allows you to provide a zip file containing valid XBL documents that once uploaded will be available in the sandbox.</span></span>
* <span data-ttu-id="11387-122">**Certify** - では、認定のサンド ボックスに、現在の構成を公開しています。</span><span class="sxs-lookup"><span data-stu-id="11387-122">**Certify** - Publishes your current configuration to the certification sandbox.</span></span>  *<span data-ttu-id="11387-123">[発行] ボタンを使用し、これを行うための証明書を発行先を変更できます。</span><span class="sxs-lookup"><span data-stu-id="11387-123">You can also use the publish button and change the destination to CERT to accomplish this.</span></span>*
* <span data-ttu-id="11387-124">**履歴**- 内容と時期を作成したユーザーに関する情報を表示する] タブを開きます。</span><span class="sxs-lookup"><span data-stu-id="11387-124">**History** - Opens a tab that displays information on who created what and when.</span></span> <span data-ttu-id="11387-125">任意のページでは、このタブを開き、ページで作成されたオブジェクトにフィルター処理することができます。</span><span class="sxs-lookup"><span data-stu-id="11387-125">You can open this tab on any page and it will filter to the objects created on that page.</span></span>
* <span data-ttu-id="11387-126">**発行**- では、サンド ボックスのソースとレプリケーション先を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="11387-126">**Publish** - Allows you to choose your source sandbox and destination.</span></span> <span data-ttu-id="11387-127">1 回選択したかどうかは、構成を公開することができますがわかるように、検証が実行されます。</span><span class="sxs-lookup"><span data-stu-id="11387-127">Once selected a validation will run letting you know if you can publish the configuration.</span></span> <span data-ttu-id="11387-128">選択の公開は、許可されている場合、サンド ボックス用の構成を設定できるように、適切なサンド ボックスの使用中には、この構成をテストすることがあります。</span><span class="sxs-lookup"><span data-stu-id="11387-128">If allowed, selecting publish will set your configuration for the sandbox so that you may test this configuration while using the appropriate sandbox.</span></span>  
  
  
![コマンド バーの画像](../../images/summary/command-bar.png)  

## <a name="summary-table"></a><span data-ttu-id="11387-130">要約テーブル</span><span class="sxs-lookup"><span data-stu-id="11387-130">Summary table</span></span>

<span data-ttu-id="11387-131">UI が追加されました意味のあるロールをすべてのさまざまな構成のため、何が構成されている、どのようなオプションですが、retail に公開する前にまだ必要なの概要ビュー。</span><span class="sxs-lookup"><span data-stu-id="11387-131">The UI now provides a meaningful roll up of all your different configurations, allowing for an at a glance view of what has been configured, what is optional, and what is still required before publishing to retail.</span></span>  

* <span data-ttu-id="11387-132">**詳細**: は、(作成しますが、まだ公開されているオブジェクトを含む) の現在のサンド ボックス内で特定の機能の内容が構成されているについて説明します。</span><span class="sxs-lookup"><span data-stu-id="11387-132">**Detail** – Describes what has been configured for a particular feature within the current sandbox (this includes the objects that you have created but not yet published)</span></span>
* <span data-ttu-id="11387-133">**最後の公開後**– これにより、どのような新しい構成を作成したテスト サンド ボックスに公開されていないかがわかります</span><span class="sxs-lookup"><span data-stu-id="11387-133">**Since Last Publish** – This will let you know what new configurations you have created that have not been published to your sandbox for testing</span></span>
* <span data-ttu-id="11387-134">**状態**: は、この機能は retail に公開する準備ができているかどうかを通知します。</span><span class="sxs-lookup"><span data-stu-id="11387-134">**Status** – Informs you whether this feature is ready to be published to retail.</span></span> <span data-ttu-id="11387-135">何も「for retail いない準備完了」というラベルに対処する必要がありますが、開発者の裁量「オプション」がマークされている行。</span><span class="sxs-lookup"><span data-stu-id="11387-135">Anything labeled "Not ready for retail" must be addressed, rows marked "Optional" are at the discretion of the developer.</span></span>

*<span data-ttu-id="11387-136">以前は、"テスト button"を選択すると、検証を実行するには、その後にのみがわかっている; を修正する必要があるがの問題があったかどうかこれ、そのプロセスを効率化し、優れたユーザー エクスペリエンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="11387-136">Previously, once you selected the “Test button”, validation would run, and only then would you know if you had an issue you needed to correct; this streamlines that process, and creates a better UX</span></span>*  
  
![コマンド バーの画像](../../images/summary/summary-table.png)  

## <a name="history-pane"></a><span data-ttu-id="11387-138">履歴] ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="11387-138">History pane</span></span>

<span data-ttu-id="11387-139">履歴ウィンドウ、サンド ボックス内でどのようなオブジェクトが作成された表示を示し、者とタイミング。</span><span class="sxs-lookup"><span data-stu-id="11387-139">The history pane displays what objects were created in the sandbox and indicates by whom and when.</span></span> <span data-ttu-id="11387-140">すべてのオブジェクトが作成され、サンド ボックス内での操作を公開するときの概要ページで、履歴ウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="11387-140">When on the summary page, the history pane will show all objects created and publish actions made on the sandbox.</span></span> <span data-ttu-id="11387-141">ただし、実績などの特定のページでは、このウィンドウを開くときは、実績の履歴、履歴の検索を簡単にフィルター処理することのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="11387-141">However, when you open this pane on a specific page like achievements you will see only achievement history allowing you to easily filter your history search.</span></span>  

![履歴ウィンドウの画像](../../images/summary/history.png)  

## <a name="best-practices"></a><span data-ttu-id="11387-143">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="11387-143">Best practices</span></span>

* <span data-ttu-id="11387-144">テスト アカウントとデバイスにライブことができるいくつかの編集を行った後に、変更内容をサンド ボックスに公開します。</span><span class="sxs-lookup"><span data-stu-id="11387-144">Publish your changes to your sandbox after you have made a few edits to ensure they are live on your test accounts and devices.</span></span>
* <span data-ttu-id="11387-145">新しいタブ ビューをまとめた表を使用し、新機能を迅速に識別するのに役立つ履歴ウィンドウが場所を公開します。</span><span class="sxs-lookup"><span data-stu-id="11387-145">Use the new tab view, summary table, and history pane to help you quickly identify what is published where.</span></span>
* <span data-ttu-id="11387-146">使用できるサンド ボックス間の XML の比較を実行する必要がある極端なケースで両方を取得する両方のサンド ボックスのエクスポート機能はドキュメントし、を超えて比較などのツールを使った開きます。</span><span class="sxs-lookup"><span data-stu-id="11387-146">In extreme cases where you need to do XML comparisons between sandboxes you can use the export feature of both sandboxes to get both documents and then open them up with a tool like Beyond Compare.</span></span>
* <span data-ttu-id="11387-147">エクスポートを使用して、ソース コントロールにコミットされることができるファイルのローカル バージョンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="11387-147">Export can be used to get a local version of files that can be committed to your own source control.</span></span> <span data-ttu-id="11387-148">これにより場合、するすべての構成が実際に失われないが失われます。</span><span class="sxs-lookup"><span data-stu-id="11387-148">That way, if you every lose any configuration you don’t actually lose it.</span></span> <span data-ttu-id="11387-149">ローカル構成を取り出して、ソース コントロールし、サンド ボックスにもう一度それをインポートできます。</span><span class="sxs-lookup"><span data-stu-id="11387-149">You can take your local configuration out of your source control and import it back into the sandbox.</span></span>