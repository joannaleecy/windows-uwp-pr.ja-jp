---
author: jnHs
Description: "Windows デベロッパー センター ダッシュボードでアプリの広告キャンペーンを管理します。"
title: "広告キャンペーンの管理"
ms.assetid: 42A9457E-15BD-4A61-B828-1C51D0FC9DA0
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 40d82d9b3ed1b450972d69e04df511496de31f67
ms.sourcegitcommit: fadde8afee46238443ec1cb71846d36c91db9fb9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/21/2017
---
# <a name="manage-your-ad-campaign"></a><span data-ttu-id="24f12-104">広告キャンペーンの管理</span><span class="sxs-lookup"><span data-stu-id="24f12-104">Manage your ad campaign</span></span>


<span data-ttu-id="24f12-105">アプリのキャンペーンを管理するには、ダッシュボードの左側のナビゲーション メニューで **[ユーザーへのアピール]** を展開して、**[広告キャンペーン]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="24f12-105">To manage ad campaigns for your app, expand **Attract** in the dashboard's left navigation menu and then select **Ad campaigns**.</span></span> <span data-ttu-id="24f12-106">アプリに関連付けられたすべての広告キャンペーンが、各広告キャンペーンのインプレッション数、クリック数、インストール数と合わせて表示されます。</span><span class="sxs-lookup"><span data-stu-id="24f12-106">You'll see all of the ad campaigns associated with your apps, along with the impressions, clicks, and installs for each ad campaign.</span></span> <span data-ttu-id="24f12-107">インプレッション数、クリック数、インストール数について詳しくは、「[[広告キャンペーン] レポート](promote-your-app-report.md)」でこれらの用語の定義をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24f12-107">For more information about impressions, clicks, and installs, see the definitions for these terms in [Ad campaign report](promote-your-app-report.md).</span></span>

<span data-ttu-id="24f12-108">広告キャンペーンの一覧をフィルター処理するには、**[セクション フィルター]** ドロップダウンをクリックし、次のフィルターから選びます。</span><span class="sxs-lookup"><span data-stu-id="24f12-108">To filter the list of ad campaigns, click the **Section filters** drop-down and choose from the following filters:</span></span>

-   <span data-ttu-id="24f12-109">**日付**: 広告キャンペーンに関連付けられているインプレッション数、クリック数、インストール数の日付範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="24f12-109">**Date**: This specifies the data range for impressions, clicks, and installs that are associated with the ad campaigns.</span></span>
-   <span data-ttu-id="24f12-110">**状態**: 広告キャンペーンの状態を指定します。</span><span class="sxs-lookup"><span data-stu-id="24f12-110">**Status**: This specifies the status of the ad campaigns:</span></span>
    -   <span data-ttu-id="24f12-111">**[アクティブ]** は、広告キャンペーンが実行されており、データを処理していることを示します。</span><span class="sxs-lookup"><span data-stu-id="24f12-111">**Active** indicates that the ad campaign is running and processing data.</span></span> <span data-ttu-id="24f12-112">広告キャンペーンを一時的に停止するには、広告キャンペーン テーブルの **[アクション]** 列で **[一時停止]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="24f12-112">To temporarily pause an ad campaign, click **Pause** in the **Action** column of the ad campaigns table.</span></span>
    -   <span data-ttu-id="24f12-113">**[一時停止]** は、広告キャンペーンが一時的に保留になっており、データを処理していないことを示します。</span><span class="sxs-lookup"><span data-stu-id="24f12-113">**Paused** indicates that the ad campaign is temporarily on hold and not processing data.</span></span> <span data-ttu-id="24f12-114">広告キャンペーンを再開するには、広告キャンペーン テーブルの **[アクション]** 列で **[再開]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="24f12-114">To resume an ad campaign, click **Resume** in the **Action** column of the ad campaigns table.</span></span>
    -   <span data-ttu-id="24f12-115">**[終了]** は、広告キャンペーンの作成時または最終更新時に指定した終了日に広告キャンペーンが到達したことを示します。</span><span class="sxs-lookup"><span data-stu-id="24f12-115">**Ended** indicates that the ad campaign has reached the end date you specified when you created or last modified the ad campaign.</span></span>
    -   <span data-ttu-id="24f12-116">**[ご注意ください]** は、広告キャンペーンに注意が必要な問題があることを示します (課金エラーや、検証に失敗したカスタム広告デザインなど)。</span><span class="sxs-lookup"><span data-stu-id="24f12-116">**Needs attention** indicates that the ad campaign has issues that need your attention, such as a billing failure or a custom ad design that failed validation.</span></span> <span data-ttu-id="24f12-117">問題を修正するには、広告キャンペーン テーブルの **[アクション]** 列のテキストをクリックします。</span><span class="sxs-lookup"><span data-stu-id="24f12-117">To fix the issues, click the text in the **Action** column of the ad campaigns table.</span></span>
-   <span data-ttu-id="24f12-118">**キャンペーンの種類**: 広告キャンペーンを有料と[自社](about-house-ads.md)のどちらにするかを指定します。</span><span class="sxs-lookup"><span data-stu-id="24f12-118">**Campaign type**: This specifies whether to display paid or [house](about-house-ads.md) ad campaigns.</span></span>

## <a name="reporting"></a><span data-ttu-id="24f12-119">レポート</span><span class="sxs-lookup"><span data-stu-id="24f12-119">Reporting</span></span>


<span data-ttu-id="24f12-120">このページには、レポートの詳細が表示されます。</span><span class="sxs-lookup"><span data-stu-id="24f12-120">Reporting details are shown on this page.</span></span> <span data-ttu-id="24f12-121">詳しくは、「[[広告キャンペーン] レポート](promote-your-app-report.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24f12-121">For more info, see [Ad campaign report](promote-your-app-report.md).</span></span>


## <a name="edit-an-ad-campaign"></a><span data-ttu-id="24f12-122">広告キャンペーンの編集</span><span class="sxs-lookup"><span data-stu-id="24f12-122">Edit an ad campaign</span></span>

<span data-ttu-id="24f12-123">広告キャンペーンに変更を加えるには、その名前をクリックし、その広告キャンペーンの詳細ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="24f12-123">To make changes to an ad campaign, click its name to go to the details page for that ad campaign.</span></span> <span data-ttu-id="24f12-124">変更を加えたら、**[レビュー]** をクリックして詳細を確認し、**[確認]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="24f12-124">After you make changes, click **Review**, review the details, and then click **Confirm**.</span></span>


## <a name="related-topics"></a><span data-ttu-id="24f12-125">関連トピック</span><span class="sxs-lookup"><span data-stu-id="24f12-125">Related topics</span></span>


* [<span data-ttu-id="24f12-126">アプリの広告キャンペーンの作成</span><span class="sxs-lookup"><span data-stu-id="24f12-126">Create an ad campaign for your app</span></span>](create-an-ad-campaign-for-your-app.md)
* [<span data-ttu-id="24f12-127">自社広告について</span><span class="sxs-lookup"><span data-stu-id="24f12-127">About house ads</span></span>](about-house-ads.md)
* [<span data-ttu-id="24f12-128">[アプリ インストール広告] レポート</span><span class="sxs-lookup"><span data-stu-id="24f12-128">App install ads report</span></span>](app-install-ads-reports.md)
* [<span data-ttu-id="24f12-129">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="24f12-129">Common questions</span></span>](common-questions.md)
 

 




