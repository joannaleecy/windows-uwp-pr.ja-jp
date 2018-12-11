---
Description: Learn how to create customer segments so you can target a subset of your customer base for promotional or engagement purposes.
title: ユーザー セグメントを作成する
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, セグメント, セグメント, 対象グループ, ユーザー
ms.assetid: 58185f6c-d61f-478b-ab24-753d8986cd5a
ms.localizationpriority: medium
ms.openlocfilehash: d0df23f0da4efe01877c45e5b2b6b5f4e2142a92
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8829845"
---
# <a name="create-customer-segments"></a><span data-ttu-id="09bd9-103">ユーザー セグメントを作成する</span><span class="sxs-lookup"><span data-stu-id="09bd9-103">Create customer segments</span></span>

<span data-ttu-id="09bd9-104">プロモーションやエンゲージメントの目的で、ユーザー ベースのサブセットをターゲットに設定する場合があります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-104">There are times when you may want to target a subset of your customer base for promotional and engagement purposes.</span></span> <span data-ttu-id="09bd9-105">[パートナー センター](https://partner.microsoft.com/dashboard)で[顧客グループ](create-customer-groups.md)を人口統計データを満たす Windows 10 のユーザーまたは選択した収益条件を含む、*セグメント*と呼ばれるの型を作成して、これを実現できます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-105">You can accomplish this in [Partner Center](https://partner.microsoft.com/dashboard) by creating a type of [customer group](create-customer-groups.md) known as a *segment* that includes the Windows 10 customers who meet the demographic or revenue criteria that you choose.</span></span>

<span data-ttu-id="09bd9-106">たとえば、50 歳以上のユーザーや、Microsoft Store で 10 ドル以上を費やしたユーザーのみを含む、セグメントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-106">For example, you could create a segment that includes only customers who are age 50 or older, or that includes customers who’ve spent more than $10 in the Microsoft Store.</span></span> <span data-ttu-id="09bd9-107">また、これらの条件を組み合わせて、Windows ストアで 10 ドル以上を費やした 50 歳以上のすべてのユーザーを含むセグメントを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-107">You could also combine these criteria and create a segment that includes all customers over 50 who have spent more than $10 in the Store.</span></span> 

<span data-ttu-id="09bd9-108">まず使って見るために役立つ、いくつかのセグメント テンプレートが用意されていますが、必要な条件を自由に定義して組み合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-108">We provide a few segment templates to help get you started, but you can define and combine the criteria however you'd like.</span></span>

> [!TIP]
> <span data-ttu-id="09bd9-109">セグメントは、エンゲージメント キャンペーンの一環で、[ターゲット通知](send-push-notifications-to-your-apps-customers.md)や[対象のプラン](use-targeted-offers-to-maximize-engagement-and-conversions.md)を特定のユーザーに送信するために使うことができます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-109">Segments can be used to send [targeted notifications](send-push-notifications-to-your-apps-customers.md) or [targeted offers](use-targeted-offers-to-maximize-engagement-and-conversions.md) to a group of customers as part of your engagement campaigns.</span></span>

<span data-ttu-id="09bd9-110">ユーザー セグメントについては、次の点を考慮します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-110">Things to keep in mind about customer segments:</span></span>
- <span data-ttu-id="09bd9-111">セグメントが[ターゲット プッシュ通知](send-push-notifications-to-your-apps-customers.md)で使用可能になるまでには、セグメントの保存後、24 時間ほどかかります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-111">After you save a segment, it takes 24 hours before you’ll be able to use it for [targeted push notifications](send-push-notifications-to-your-apps-customers.md).</span></span>
- <span data-ttu-id="09bd9-112">セグメントの結果は 1 日ごとに更新されます。ユーザーのセグメント条件への一致状況の変化により、セグメントに含まれるユーザー数は変化する場合があります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-112">Segment results are refreshed daily, so you may see the total count of customers in a segment change from day to day as customers drop in or out of the segment criteria.</span></span>
- <span data-ttu-id="09bd9-113">ほとんどのセグメント属性は、すべての履歴データを使用して計算されますが、いくつか例外があります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-113">Most segment attributes are calculated using all historical data, although there are some exceptions.</span></span> <span data-ttu-id="09bd9-114">たとえば、**[アプリの取得日]**、**[キャンペーン ID]**、**[ストア ページ ビューの日付]**、**[参照元の URI ドメイン]** は過去 90 日間で収集されたデータに限定されます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-114">For example, **App acquisition date**, **Campaign ID**, **Store page view date**, and **Referrer URI domain** are limited to the last 90 days of data.</span></span>
- <span data-ttu-id="09bd9-115">セグメントには、Windows 10 を使い、有効な Microsoft アカウントを使ってサインインした状態でアプリを取得したユーザーのみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-115">Segments only include customers who acquired your app on Windows 10 while signed in with a valid Microsoft account.</span></span> 
- <span data-ttu-id="09bd9-116">17 歳以下のユーザーはセグメントには含まれません。</span><span class="sxs-lookup"><span data-stu-id="09bd9-116">Segments do not include any customers who are younger than 17 years old.</span></span>

## <a name="to-create-a-customer-segment"></a><span data-ttu-id="09bd9-117">ユーザー セグメントを作成するには</span><span class="sxs-lookup"><span data-stu-id="09bd9-117">To create a customer segment</span></span>

1.  <span data-ttu-id="09bd9-118">[パートナー センター](https://partner.microsoft.com/dashboard)では、左側のナビゲーション メニューで**利用率の引き上げ**を展開し、**ユーザー グループ**を選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-118">In [Partner Center](https://partner.microsoft.com/dashboard), expand **Engage** in the left navigation menu and then select **Customer groups**.</span></span>
2.  <span data-ttu-id="09bd9-119">**[ユーザー グループ]** ページで、次のいずれかの手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-119">On the **Customer groups** page, do one of the following:</span></span>
 - <span data-ttu-id="09bd9-120">**[自分のユーザー グループ]** セクションで、**[新しいグループの作成]** を選択して、セグメントを最初から定義します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-120">In the **My customer groups** section, select **Create new group** to define a segment from scratch.</span></span> <span data-ttu-id="09bd9-121">次のページで、**[セグメント]** ラジオ ボタンを選びます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-121">On the next page, select the **Segment** radio button.</span></span>
 - <span data-ttu-id="09bd9-122">**[テンプレート セグメント**] セクションで、定義済みのセグメントの 1 つの横に表示された **[コピー]** を選びます (定義済みのセグメントは、そのまま使用することも、必要に合わせて変更することもできます)。</span><span class="sxs-lookup"><span data-stu-id="09bd9-122">In the **Segment templates** section, select **Copy** next to one of the predefined segments (that you can use as is or modify to suit your needs).</span></span>
3.  <span data-ttu-id="09bd9-123">**[グループ名]** のボックスで、セグメントの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-123">In the **Group name** box, enter a name for your segment.</span></span>
4.  <span data-ttu-id="09bd9-124">**[このアプリからユーザーを含める]** のリストで、対象とするアプリの 1 つを選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-124">In the **Include customers from this app** list, select one of your apps to target.</span></span>
5.  <span data-ttu-id="09bd9-125">**[包含条件の定義]** セクションで、セグメントのフィルター条件を指定します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-125">In the **Define inclusion conditions** section, specify the filter criteria for the segment.</span></span>

    <span data-ttu-id="09bd9-126">さまざまなフィルター条件は、**取得\*\*\*\*取得元**、**統計データ**、**評価**、**チャーン予測入力**、**ストアの購入**、**ストアの取得数**、および**ストアから選択できます。費やす**します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-126">You can choose from a variety of filter criteria, including **Acquisitions**, **Acquisition source**, **Demographic**, **Rating**, **Churn prediction**, **Store purchases**, **Store acquisitions**, and **Store spend**.</span></span>

    <span data-ttu-id="09bd9-127">たとえば、18 ～ 24 歳のアプリ ユーザーのみを含むセグメントを作成する場合には、フィルター条件としてドロップダウン リストから **[統計データ]**、**[年齢グループ]**、**[次の値に一致する]**、**[18 ～ 24]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-127">For example, if you wanted to create a segment that only included your app customers who are 18- to 24-years old, you’d select the filter criteria [**Demographic**] [**Age group**] [**is**] [**18 to 24**] from the drop-down lists.</span></span>

    <span data-ttu-id="09bd9-128">AND / OR クエリを使用して、より複雑なセグメントを作成し、さまざまな属性に基づいてユーザーを含めたり除外したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-128">You can build more complex segments by using AND/OR queries to include or exclude customers based on various attributes.</span></span> <span data-ttu-id="09bd9-129">OR 条件のクエリを追加するには、**[+ OR ステートメント]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-129">To add an OR query, select **+ OR statement**.</span></span> <span data-ttu-id="09bd9-130">AND 条件のクエリを追加するには、**[別のフィルターを追加する]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-130">To add an ADD query, select **Add another filter**.</span></span>

    <span data-ttu-id="09bd9-131">指定した年齢範囲内にある男性のユーザーのみを含むセグメントに絞り込む場合には、**[別のフィルターを追加する]** を選択し、追加のフィルター条件として **[統計データ]**、**[性別]**、**[次の値に一致する]**、**[男性]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-131">So, if you wanted to refine that segment to only include male customers who are in the specified age range, you would select **Add another filter** and then select the additional filter criteria [**Demographic**] [**Gender**] [**is**] [**Male**].</span></span> <span data-ttu-id="09bd9-132">この例では、**[セグメント定義]** には **[年齢グループ == 18 ～ 24 && 性別 == 男性]** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-132">For this example, the **Segment definition** would display **Age group == 18 to 24 && Gender == Male**.</span></span>

    ![セグメントのフィルター条件の例](images/create-segment-inclusions.png)
6. <span data-ttu-id="09bd9-134">**[保存]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-134">Select **Save**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="09bd9-135">含まれるユーザーの数が少なすぎるセグメントを使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="09bd9-135">You won't be able to use a segment that includes too few customers.</span></span> <span data-ttu-id="09bd9-136">セグメント定義に十分なユーザーが含まれていない場合は、セグメント条件を調整するか、またはアプリがセグメント条件を満たすユーザーをさらに獲得した後で再度行ってください。</span><span class="sxs-lookup"><span data-stu-id="09bd9-136">If your segment definition does not include enough customers, you can adjust the segment criteria, or try again later, when your app may have acquired more customers that meet your segment criteria.</span></span>


## <a name="app-statistics"></a><span data-ttu-id="09bd9-137">アプリの統計情報</span><span class="sxs-lookup"><span data-stu-id="09bd9-137">App statistics</span></span>

<span data-ttu-id="09bd9-138">セグメントの **[アプリの統計情報]** セクションには、アプリについての情報と作成したセグメントのサイズが表示されます。</span><span class="sxs-lookup"><span data-stu-id="09bd9-138">The **App statistics** section on the segment provides some info about your app, as well as the size of the segment you just created.</span></span>

<span data-ttu-id="09bd9-139">**[アプリの有効ユーザー数]** は、アプリを取得した実際のユーザー数ではなく、セグメントに含めることができるユーザー数 (つまり、年齢要件を満たし、Windows 10 でアプリを取得し、有効な Microsoft アカウントに関連付けられているユーザー) を示していることに留意します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-139">Note that **Available app customers** does not reflect the actual number of customers who have acquired your app, but only the number of customers that are available to be included in segments (that is, customers that we can determine meet age requirements, have acquired your app on Windows 10, and who are associated with a valid Microsoft account).</span></span>

<span data-ttu-id="09bd9-140">結果を表示したときに **[このセグメントのユーザー数]** に **[小]** と表示される場合には、セグメントには十分なユーザーが含まれず、セグメントは非アクティブなります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-140">If you view the results and **Customers in this segment** says **Small**, the segment doesn't include enough customers and the segment is marked as inactive.</span></span> <span data-ttu-id="09bd9-141">非アクティブなセグメントでは、通知やその他の機能を使用できません。</span><span class="sxs-lookup"><span data-stu-id="09bd9-141">Inactive segments can't be used for notifications or other features.</span></span> <span data-ttu-id="09bd9-142">次のいずれかの方法でセグメントをアクティブ化して使用できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="09bd9-142">You might be able to activate and use a segment by doing one of the following:</span></span>

- <span data-ttu-id="09bd9-143">**[包含条件の定義]** セクションで、より多くのユーザーがセグメントに含まれるように、フィルター条件を調整します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-143">In the **Define inclusion conditions** section, adjust the filter criteria so the segment includes more customers.</span></span>
- <span data-ttu-id="09bd9-144">**[ユーザー グループ]** ページの **[非アクティブのセグメント]** セクションで **[更新]** を選び、十分な数のユーザーがセグメントに含まれているかどうか (たとえば、セグメント作成後に、アプリをダウンロードしているセグメント条件に一致するユーザーが増えているかや、セグメントの条件に一致する既存のユーザーが増えているか) を確認します。</span><span class="sxs-lookup"><span data-stu-id="09bd9-144">On the **Customer groups** page, in the **Inactive segments** section, select **Refresh** to see if the segment now contains enough customers (for example, if more customers who meet your segment criteria have downloaded your app since you first created the segment, or if more existing customers now meet your segment criteria).</span></span>
