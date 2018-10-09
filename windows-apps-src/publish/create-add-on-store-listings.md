---
author: jnHs
Description: When submitting an add-on, the info you provide in the Store listings step will be displayed to your customers.
title: アドオンの Store 登録情報の作成
ms.assetid: 07178278-A18A-4F73-A660-0047DAAE49B5
ms.author: wdg-dev-content
ms.date: 01/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d6132c2ede9f14cd1f4d29195916c8b484abfe9f
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4429085"
---
# <a name="create-add-on-store-listings"></a><span data-ttu-id="7ad9e-103">アドオンのストア登録情報の作成</span><span class="sxs-lookup"><span data-stu-id="7ad9e-103">Create add-on Store listings</span></span>


<span data-ttu-id="7ad9e-104">**ストア登録情報**の手順で入力した情報は、アドオンを申請する際、アドオンを入手するためのオプションを表示したときにユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-104">When submitting an add-on, the info you provide in the **Store listings** step will be displayed to your customers when they see the option to acquire your add-on.</span></span> <span data-ttu-id="7ad9e-105">ストア登録情報は、ユーザーを最も引きつける方法でアドオンを正確に表すように慎重に検討してください。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-105">Make sure to consider the Store listing info carefully in order to represent your add-on accurately in a way that makes it appealing to customers.</span></span> <span data-ttu-id="7ad9e-106">また、このストア登録情報は、さまざまな言語でカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-106">You can provide customized Store listings for different languages.</span></span>

> [!TIP]
> <span data-ttu-id="7ad9e-107">ダッシュボードで直接ストア登録情報を入力するのではなく、.csv ファイルを使ってオフラインで登録情報を入力する場合は、アドオンの[ストア登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-107">You can also [import and export Store listings](import-and-export-store-listings.md) for your add-on if you'd like to enter your listing info offline in a .csv file, rather than providing this info directly in the dashboard.</span></span> <span data-ttu-id="7ad9e-108">これは、多数の言語の登録情報を作成するときに、特に便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-108">This may be especially convenient when creating listings in many languages.</span></span> <span data-ttu-id="7ad9e-109">ただし、インポート/エクスポート機能を使うのではなく、いつでもダッシュボードで直接情報を入力できます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-109">However, you can always enter your info directly in the dashboard rather than using the import/export feature.</span></span>


## <a name="store-listing-languages"></a><span data-ttu-id="7ad9e-110">ストア登録情報の言語</span><span class="sxs-lookup"><span data-stu-id="7ad9e-110">Store listing languages</span></span>

<span data-ttu-id="7ad9e-111">ストア登録情報を入力する前に、1 つ以上の[言語](supported-languages.md)を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-111">Before you can enter Store listing info, you need to specify one or more [languages](supported-languages.md).</span></span> <span data-ttu-id="7ad9e-112">少なくとも 1 つの言語の **[ストア登録情報]** ページを完成させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-112">You must complete the **Store listing** page for at least one language.</span></span> <span data-ttu-id="7ad9e-113">アプリがサポートするすべての言語でストア登録情報を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-113">We recommend providing Store listings for every language your app supports.</span></span>

<span data-ttu-id="7ad9e-114">アドオンの申請の **[ストア登録情報]** セクションで、**[言語の追加/削除]** をクリックし、次のページで **[言語の管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-114">Under the **Store listing** section of your add-on's submission, click **Add/remove languages**, then click **Manage languages** on the next page.</span></span> <span data-ttu-id="7ad9e-115">追加する言語のチェック ボックスをクリックし、**[更新]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-115">Check the boxes for the languages that you’d like to add, then click **Update**.</span></span> <span data-ttu-id="7ad9e-116">選択した言語が、ページの **[ストア登録情報の言語]** セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-116">The languages that you’ve selected will be displayed in the **Store listing languages** section of the page.</span></span>

<span data-ttu-id="7ad9e-117">言語を削除するには、**[削除]** をクリックします (または、**[言語の管理]** をクリックし、削除する言語のチェック ボックスをオフにします)。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-117">To remove a language, click **Remove** (or click **Manage languages** and uncheck the box for languages you’d like to remove).</span></span> 

<span data-ttu-id="7ad9e-118">選択が終了したら **[保存]** をクリックして、申請の概要ページに戻ります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-118">When you have finished making your selections, click **Save** to return to the submission overview page.</span></span>

<span data-ttu-id="7ad9e-119">ストア登録情報を編集するには、アドオンの申請の概要ページで言語名をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-119">To edit a Store listing, click the language name from the add-on submission overview page.</span></span> <span data-ttu-id="7ad9e-120">言語ごとに入力できる情報は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-120">The info you can enter for each language is described below.</span></span>

## <a name="title"></a><span data-ttu-id="7ad9e-121">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="7ad9e-121">Title</span></span>

<span data-ttu-id="7ad9e-122">ここにはタイトルを入力します。これは、このアドオンの名前としてユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-122">You must provide a title here, which is the name your customers will see for this add-on.</span></span> <span data-ttu-id="7ad9e-123">タイトルは、最大 100 文字入力できます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-123">Your title can be up to 100 characters.</span></span>

## <a name="description"></a><span data-ttu-id="7ad9e-124">説明</span><span class="sxs-lookup"><span data-stu-id="7ad9e-124">Description</span></span>

<span data-ttu-id="7ad9e-125">タイトルより多くの情報を表示する場合、ここに最大 200 文字入力することができます。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-125">If you'd like to display more info than just a title, you can enter up to 200 characters here.</span></span> <span data-ttu-id="7ad9e-126">このフィールドは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-126">This field is optional.</span></span>

## <a name="icon"></a><span data-ttu-id="7ad9e-127">アイコン</span><span class="sxs-lookup"><span data-stu-id="7ad9e-127">Icon</span></span>

<span data-ttu-id="7ad9e-128">ユーザーに表示できる画像を指定するオプションもあります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-128">You also have the option to provide an image that may be displayed to the customer.</span></span> <span data-ttu-id="7ad9e-129">このアイコンには、300 x 300 ピクセルの .png ファイルを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ad9e-129">This icon must be a .png file that measures exactly 300 x 300 pixels.</span></span>

 

 




