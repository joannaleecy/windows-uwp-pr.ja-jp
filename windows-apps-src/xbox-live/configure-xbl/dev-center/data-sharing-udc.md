---
title: デベロッパー センターでのデータ共有の構成
author: KevinAsgari
description: デベロッパー センターでデータ共有を構成して他のアプリ、ゲーム、サービスが Xbox Live の設定にアクセスすることを許可する方法について説明します。
ms.assetid: ''
ms.author: kevinasg
ms.date: 02/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: low
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター
ms.openlocfilehash: 46ad77cd5e966e4e48ec13d64684580df82a52e9
ms.sourcegitcommit: 0ee9c6848cb9d624f15cdab1d0c5991ca7245e70
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/12/2018
---
# <a name="configure-data-sharing-on-dev-center"></a><span data-ttu-id="4d779-104">デベロッパー センターでのデータ共有の構成</span><span class="sxs-lookup"><span data-stu-id="4d779-104">Configure data sharing on Dev Center</span></span>

<span data-ttu-id="4d779-105">[Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)を使うと、他のサービス、ゲーム、アプリがタイトルの Xbox Live 設定とデータにアクセスすることを許可できます。</span><span class="sxs-lookup"><span data-stu-id="4d779-105">You can use [Windows Dev Center](https://developer.microsoft.com/dashboard/windows/overview) to allow other services, games, and apps to access your title's Xbox Live settings and data.</span></span> <span data-ttu-id="4d779-106">たとえば、Web サイトでのランキングを Web サービスに表示したり、ゲームのタイトル ストレージにアクセスしてセーブされたゲーム データを表示または変更できる比較アプリを作成したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="4d779-106">For example, you may want a web service to display leaderboards on your website, or you may have a companion app that can access the game's title storage to view or modify saved game data.</span></span>

<span data-ttu-id="4d779-107">既定では、タイトル自体のみが Xbox Live サービスに保存された設定とデータにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="4d779-107">By default, only the title itself can access the settings and data stored on the Xbox Live service.</span></span> <span data-ttu-id="4d779-108">これは、デベロッパー センターでデータ共有を構成することによって変更できます。</span><span class="sxs-lookup"><span data-stu-id="4d779-108">You can change this by configuring data sharing on the Dev Center.</span></span>

> [!NOTE]
> <span data-ttu-id="4d779-109">このトピックは、Xbox Live クリエーターズ プログラムのタイトルには適用されません。</span><span class="sxs-lookup"><span data-stu-id="4d779-109">This topic does not apply to titles in the Xbox Live Creators Program.</span></span>

<span data-ttu-id="4d779-110">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="4d779-110">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="4d779-111">[デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)でタイトルを選択したら、**[サービス]** > **[Xbox Live]** に移動します。</span><span class="sxs-lookup"><span data-stu-id="4d779-111">After selecting your title in [Dev Center](https://developer.microsoft.com/dashboard/windows/overview), navigate to **Services** > **Xbox Live**.</span></span>

2. <span data-ttu-id="4d779-112">**データ共有**へのリンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d779-112">Click on the link to **Data sharing**.</span></span>

3. <span data-ttu-id="4d779-113">アクセスを許可する設定をクリックし、アプリ/サービスの追加ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="4d779-113">Click on the setting you want to grant access to, and click the Add app/service button.</span></span> <span data-ttu-id="4d779-114">その設定にアクセスできるように構成されたアプリ/サービスの一覧の下に新しい行が追加されます。</span><span class="sxs-lookup"><span data-stu-id="4d779-114">This will add a new row to the bottom of the list of apps/services configured to access that setting.</span></span>

4. <span data-ttu-id="4d779-115">ドロップダウン ボックスでアプリまたはサービスの種類を選択し、詳細ボックスに入力して、データにアクセスするアプリやサービスのアプリ、タイトル ID、サービス ID を指定します。</span><span class="sxs-lookup"><span data-stu-id="4d779-115">Select the type of app or service in the dropdown box, and fill in the detail box to indicate the app, title id, or service id of the app or service that will access the data.</span></span>

5. <span data-ttu-id="4d779-116">アプリまたはサービスがデータを読み取るだけなのか、データにフル アクセスするのかを選択します。</span><span class="sxs-lookup"><span data-stu-id="4d779-116">Select if the app or service can only read the data, or if it has full access to the data.</span></span>

6. <span data-ttu-id="4d779-117">設定ごと、およびそれらの設定へのアクセスが必要なアプリやサービスごとに繰り返します。</span><span class="sxs-lookup"><span data-stu-id="4d779-117">Repeat for each setting, and for each app or service that needs access to those settings.</span></span> <span data-ttu-id="4d779-118">**[削除]** をクリックすると配列を削除できます。</span><span class="sxs-lookup"><span data-stu-id="4d779-118">You can click **Delete** to remove an entry.</span></span>

7. <span data-ttu-id="4d779-119">作業が完了したら、**[保存]** ボタンをクリックして変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="4d779-119">When you are finished, click the **Save** button to save your changes.</span></span>

![データ共有、アプリやサービスの追加画面](../../images/dev-center/data-sharing-2.png)
