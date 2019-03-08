---
title: パートナー センターでのアクセス ポリシーを構成します。
description: パートナー センターの他のアプリ、ゲーム、および Xbox Live の設定にアクセスするサービスを許可するアクセス ポリシーを構成する方法について説明します。
ms.assetid: ''
ms.date: 02/21/2018
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター
ms.openlocfilehash: ae26c18abdac30ff988e90ee5c56f178bf14b74a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658217"
---
# <a name="configure-access-policies-in-partner-center"></a><span data-ttu-id="bde47-104">パートナー センターでのアクセス ポリシーを構成します。</span><span class="sxs-lookup"><span data-stu-id="bde47-104">Configure access policies in Partner Center</span></span>

<span data-ttu-id="bde47-105">使用することができます[パートナー センター](https://partner.microsoft.com/dashboard)他のサービス、ゲーム、およびタイトルの Xbox Live の設定とデータにアクセスするアプリを許可します。</span><span class="sxs-lookup"><span data-stu-id="bde47-105">You can use [Partner Center](https://partner.microsoft.com/dashboard) to allow other services, games, and apps to access your title's Xbox Live settings and data.</span></span> <span data-ttu-id="bde47-106">たとえば、Web サイトでのランキングを Web サービスに表示したり、ゲームのタイトル ストレージにアクセスしてセーブされたゲーム データを表示または変更できる比較アプリを作成したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="bde47-106">For example, you may want a web service to display leaderboards on your website, or you may have a companion app that can access the game's title storage to view or modify saved game data.</span></span>

<span data-ttu-id="bde47-107">既定では、タイトル自体のみが Xbox Live サービスに保存された設定とデータにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="bde47-107">By default, only the title itself can access the settings and data stored on the Xbox Live service.</span></span> <span data-ttu-id="bde47-108">これは、パートナー センターでアクセス ポリシーを構成することで変更できます。</span><span class="sxs-lookup"><span data-stu-id="bde47-108">You can change this by configuring access policies in Partner Center.</span></span>

> [!NOTE]
> <span data-ttu-id="bde47-109">このトピックは、Xbox Live クリエーターズ プログラムのタイトルには適用されません。</span><span class="sxs-lookup"><span data-stu-id="bde47-109">This topic does not apply to titles in the Xbox Live Creators Program.</span></span>

<span data-ttu-id="bde47-110">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="bde47-110">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="bde47-111">タイトルを選択した後は[パートナー センター](https://partner.microsoft.com/dashboard)に移動します**サービス** > **Xbox Live**します。</span><span class="sxs-lookup"><span data-stu-id="bde47-111">After selecting your title in [Partner Center](https://partner.microsoft.com/dashboard), navigate to **Services** > **Xbox Live**.</span></span>

2. <span data-ttu-id="bde47-112">リンクをクリックして**アクセス ポリシー**します。</span><span class="sxs-lookup"><span data-stu-id="bde47-112">Click on the link to **access policies**.</span></span>

3. <span data-ttu-id="bde47-113">アクセスを許可する設定をクリックし、アプリ/サービスの追加ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="bde47-113">Click on the setting you want to grant access to, and click the Add app/service button.</span></span> <span data-ttu-id="bde47-114">その設定にアクセスできるように構成されたアプリ/サービスの一覧の下に新しい行が追加されます。</span><span class="sxs-lookup"><span data-stu-id="bde47-114">This will add a new row to the bottom of the list of apps/services configured to access that setting.</span></span>

4. <span data-ttu-id="bde47-115">ドロップダウン ボックスでアプリまたはサービスの種類を選択し、詳細ボックスに入力して、データにアクセスするアプリやサービスのアプリ、タイトル ID、サービス ID を指定します。</span><span class="sxs-lookup"><span data-stu-id="bde47-115">Select the type of app or service in the dropdown box, and fill in the detail box to indicate the app, title id, or service id of the app or service that will access the data.</span></span>

5. <span data-ttu-id="bde47-116">アプリまたはサービスがデータを読み取るだけなのか、データにフル アクセスするのかを選択します。</span><span class="sxs-lookup"><span data-stu-id="bde47-116">Select if the app or service can only read the data, or if it has full access to the data.</span></span>

6. <span data-ttu-id="bde47-117">設定ごと、およびそれらの設定へのアクセスが必要なアプリやサービスごとに繰り返します。</span><span class="sxs-lookup"><span data-stu-id="bde47-117">Repeat for each setting, and for each app or service that needs access to those settings.</span></span> <span data-ttu-id="bde47-118">**[削除]** をクリックすると配列を削除できます。</span><span class="sxs-lookup"><span data-stu-id="bde47-118">You can click **Delete** to remove an entry.</span></span>

7. <span data-ttu-id="bde47-119">作業が完了したら、**[保存]** ボタンをクリックして変更を保存します。</span><span class="sxs-lookup"><span data-stu-id="bde47-119">When you are finished, click the **Save** button to save your changes.</span></span>

![アクセス ポリシーはアプリやサービスの画面を追加します。](../../images/dev-center/data-sharing-2.png)
