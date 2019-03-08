---
title: Xbox Live の [概要] ページ
description: 概要ビューの Xbox Live を活用する方法について説明します。
ms.assetid: ''
ms.date: 10/19/2018
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox live、Xbox、ゲーム、uwp、windows 10、Xbox、xbox live 概要、要約すると、発行、xbox live の履歴、コマンド バー、[履歴] タブ、概要テーブル
ms.openlocfilehash: 289b472939c721e5bfb373d4de62ed800840bf57
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605987"
---
# <a name="the-xbox-live-configuration-summary-page"></a><span data-ttu-id="4cd90-104">Xbox Live 構成の概要ページ</span><span class="sxs-lookup"><span data-stu-id="4cd90-104">The Xbox Live configuration summary page</span></span>

<span data-ttu-id="4cd90-105">使用することができます[パートナー センター](https://developer.microsoft.com/dashboard) Xbox Live、タイトル用に構成します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-105">You can use [Partner Center](https://developer.microsoft.com/dashboard) to configure Xbox Live for your title.</span></span> <span data-ttu-id="4cd90-106">パートナー センターでは、タイトルのサンド ボックスの各サービスの構成を管理することになります。</span><span class="sxs-lookup"><span data-stu-id="4cd90-106">With Partner Center you will be able to manage the service configuration for each of your title's sandboxes.</span></span>
<span data-ttu-id="4cd90-107">タイトルの Xbox Live 面を構成、Xbox Live、タイトルのセクションに移動するために下にある**サービス** > **Xbox Live**します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-107">In order to configure the Xbox Live aspects of your title, navigate to the Xbox Live section for your title, located under **Services** > **Xbox Live**.</span></span> <span data-ttu-id="4cd90-108">このページで、選択したサンド ボックスで、現在の構成のスナップショットが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-108">On this page, you will find a snapshot of your current configuration on the selected sandbox.</span></span> <span data-ttu-id="4cd90-109">何が構成され、同様のサンド ボックスに公開の詳細な内訳も紹介します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-109">You will also find a detailed breakdown of what has been configured and published to the sandbox as well.</span></span>

## <a name="sandbox-selector"></a><span data-ttu-id="4cd90-110">サンド ボックス セレクター</span><span class="sxs-lookup"><span data-stu-id="4cd90-110">Sandbox selector</span></span>

 <span data-ttu-id="4cd90-111">[サンド ボックス](../../xbox-live-sandboxes.md)が最上位レベルのナビゲーションの項目間の切り替え、選択項目で展開したりできます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-111">[Sandboxes](../../xbox-live-sandboxes.md) are now a top-level navigation item you can switch between or expand by selection.</span></span> <span data-ttu-id="4cd90-112">UI は、上部にあるタブとして、タイトルのサンド ボックスを表示します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-112">The UI displays the title's sandboxes at the top as tabs.</span></span> <span data-ttu-id="4cd90-113">各タブに表示される情報が関連付けられているサンド ボックスのコンテキストです。</span><span class="sxs-lookup"><span data-stu-id="4cd90-113">The information shown in each tab is in the context of the associated sandbox.</span></span>  

![サンド ボックスのタブの切り替えの画像](../../images/summary/sandbox-tabs1.gif)

 <span data-ttu-id="4cd90-115">追加のサンド ボックスを選択して追加することができます、「+」は、ダイアログ ボックスが表示される構成をコピーするかから構成をコピーするにはどのサンド ボックスとどのサンド ボックスを指定する場合。</span><span class="sxs-lookup"><span data-stu-id="4cd90-115">You can add additional sandboxes by selecting the "+" which will present you with a dialog where you specify which sandbox you would like to copy the config from and which sandbox you would like to copy the config to.</span></span>  

 ![イメージの新しいサンド ボックス タブに拡張](../../images/summary/sandbox-tabs2.gif)

## <a name="command-bar"></a><span data-ttu-id="4cd90-117">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="4cd90-117">Command bar</span></span>

<span data-ttu-id="4cd90-118">上記で説明したように表示されるページは常に、サンド ボックスのコンテキスト内でそのため、コマンド バーのすぐ下の公開は、特定のサンド ボックスで実行できるすべてのアクションを示します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-118">As mentioned above the page displayed is always within the context of a sandbox, therefore the command bar exposed just below it shows all the actions you can perform in your given sandbox.</span></span> <span data-ttu-id="4cd90-119">使用できるコマンドは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="4cd90-119">The commands available to you are:</span></span>  

* <span data-ttu-id="4cd90-120">**エクスポート**-サンド ボックス内のすべての構成済みのドキュメントを含む zip ファイルを提供しています。</span><span class="sxs-lookup"><span data-stu-id="4cd90-120">**Export** - Which provides you a zip file that contains all configured documents within the sandbox.</span></span>
* <span data-ttu-id="4cd90-121">**インポート**-有効な XBL を含むドキュメントがアップロードされた zip ファイルは、サンド ボックスで利用できますを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-121">**Import** - Allows you to provide a zip file containing valid XBL documents that once uploaded will be available in the sandbox.</span></span>
* <span data-ttu-id="4cd90-122">**認定**-認定サンド ボックスに、現在の構成を発行します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-122">**Certify** - Publishes your current configuration to the certification sandbox.</span></span>  <span data-ttu-id="4cd90-123">*[発行] ボタンを使用し、これを実現する証明書を変換先を変更できます。*</span><span class="sxs-lookup"><span data-stu-id="4cd90-123">*You can also use the publish button and change the destination to CERT to accomplish this.*</span></span>
* <span data-ttu-id="4cd90-124">**履歴**-いつ何を作成したユーザーに関する情報を表示するタブが開きます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-124">**History** - Opens a tab that displays information on who created what and when.</span></span> <span data-ttu-id="4cd90-125">いずれかのページには、このタブを開き、そのページで作成されたオブジェクトがフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-125">You can open this tab on any page and it will filter to the objects created on that page.</span></span>
* <span data-ttu-id="4cd90-126">**発行**-サンド ボックスのソースと変換先を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-126">**Publish** - Allows you to choose your source sandbox and destination.</span></span> <span data-ttu-id="4cd90-127">選択すると、検証が実行され、構成で発行することができるかどうかを把握することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-127">Once selected a validation will run letting you know if you can publish the configuration.</span></span> <span data-ttu-id="4cd90-128">許可された場合はの発行を選択すると、サンド ボックス用の構成を設定中に、適切なサンド ボックスを使用してこの構成をテストすることがあります。</span><span class="sxs-lookup"><span data-stu-id="4cd90-128">If allowed, selecting publish will set your configuration for the sandbox so that you may test this configuration while using the appropriate sandbox.</span></span>  
  
  
![コマンド バーの画像](../../images/summary/command-bar.png)  

## <a name="summary-table"></a><span data-ttu-id="4cd90-130">概要テーブル</span><span class="sxs-lookup"><span data-stu-id="4cd90-130">Summary table</span></span>

<span data-ttu-id="4cd90-131">UI は、意味のあるロールをすべての異なる構成のすることができますが、構成されている内容、新機能、省略可能な製品版を公開する前に必要なものの概要 ビュー。</span><span class="sxs-lookup"><span data-stu-id="4cd90-131">The UI now provides a meaningful roll up of all your different configurations, allowing for an at a glance view of what has been configured, what is optional, and what is still required before publishing to retail.</span></span>  

* <span data-ttu-id="4cd90-132">**詳細**– (作成されたが、まだパブリッシュされているオブジェクトを含む) 現在のサンド ボックス内で特定の機能の構成されている内容について説明します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-132">**Detail** – Describes what has been configured for a particular feature within the current sandbox (this includes the objects that you have created but not yet published)</span></span>
* <span data-ttu-id="4cd90-133">**最後の発行以降**– 自分のテスト用サンド ボックスに公開されていないを作成した新しい構成を確認します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-133">**Since Last Publish** – This will let you know what new configurations you have created that have not been published to your sandbox for testing</span></span>
* <span data-ttu-id="4cd90-134">**ステータス**– この機能が製品版に発行する準備ができているかどうかを通知します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-134">**Status** – Informs you whether this feature is ready to be published to retail.</span></span> <span data-ttu-id="4cd90-135">「製品版には未対応」というラベルの付いた何も行う必要がありますが、開発者の裁量で"Optional"にマークされている行。</span><span class="sxs-lookup"><span data-stu-id="4cd90-135">Anything labeled "Not ready for retail" must be addressed, rows marked "Optional" are at the discretion of the developer.</span></span>

<span data-ttu-id="4cd90-136">*以前は、「テスト ボタン」を選択すると、検証を実行するには、のみについて知るには; を修正するのに必要な問題であればがこの、そのプロセスを合理化し、さらに優れた UX を作成します。*</span><span class="sxs-lookup"><span data-stu-id="4cd90-136">*Previously, once you selected the “Test button”, validation would run, and only then would you know if you had an issue you needed to correct; this streamlines that process, and creates a better UX*</span></span>  
  
![コマンド バーの画像](../../images/summary/summary-table.png)  

## <a name="history-pane"></a><span data-ttu-id="4cd90-138">履歴ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="4cd90-138">History pane</span></span>

<span data-ttu-id="4cd90-139">履歴ウィンドウは、サンド ボックスでどのようなオブジェクトが作成されたが表示され、者を示すとします。</span><span class="sxs-lookup"><span data-stu-id="4cd90-139">The history pane displays what objects were created in the sandbox and indicates by whom and when.</span></span> <span data-ttu-id="4cd90-140">概要のページですべてのオブジェクトが作成され、サンド ボックスで実行されるアクションを発行、履歴ウィンドウは表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-140">When on the summary page, the history pane will show all objects created and publish actions made on the sandbox.</span></span> <span data-ttu-id="4cd90-141">ただし、アチーブメントのような特定のページには、このウィンドウを開いたときに、履歴検索を簡単にフィルター処理できるようにアチーブメント履歴のみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-141">However, when you open this pane on a specific page like achievements you will see only achievement history allowing you to easily filter your history search.</span></span>  

![履歴ウィンドウの画像](../../images/summary/history.png)  

## <a name="best-practices"></a><span data-ttu-id="4cd90-143">ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="4cd90-143">Best practices</span></span>

* <span data-ttu-id="4cd90-144">保つには、テスト アカウントとデバイス上でライブでいくつかの編集を行った後は、サンド ボックスに変更を発行します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-144">Publish your changes to your sandbox after you have made a few edits to ensure they are live on your test accounts and devices.</span></span>
* <span data-ttu-id="4cd90-145">新しいタブ ビュー、概要テーブルを使用し、新機能をすばやく識別するための履歴ウィンドウは、場所を公開します。</span><span class="sxs-lookup"><span data-stu-id="4cd90-145">Use the new tab view, summary table, and history pane to help you quickly identify what is published where.</span></span>
* <span data-ttu-id="4cd90-146">サンド ボックスを使用することができますの間での XML の比較を実行する必要がある極端なケースでは、両方を取得する両方のサンド ボックスのエクスポート機能はについて説明し、Beyond Compare などのツールで開きます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-146">In extreme cases where you need to do XML comparisons between sandboxes you can use the export feature of both sandboxes to get both documents and then open them up with a tool like Beyond Compare.</span></span>
* <span data-ttu-id="4cd90-147">ソース管理にコミットできるファイルのローカル バージョンを取得するエクスポートを使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-147">Export can be used to get a local version of files that can be committed to your own source control.</span></span> <span data-ttu-id="4cd90-148">これにより場合をすべて実際に紛失したしない任意の構成が失われます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-148">That way, if you every lose any configuration you don’t actually lose it.</span></span> <span data-ttu-id="4cd90-149">ソース管理から、ローカルの構成を実行して、サンド ボックスにインポートできます。</span><span class="sxs-lookup"><span data-stu-id="4cd90-149">You can take your local configuration out of your source control and import it back into the sandbox.</span></span>