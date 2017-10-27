---
author: jnHs
Description: "アプリのストア登録情報は、デベロッパー センター ダッシュボードを使わなくても、登録情報を .csv ファイルにエクスポートして情報と資産を入力し、更新したファイルをインポートして作成できます。"
title: "ストア登録情報のインポートとエクスポート"
ms.author: wdg-dev-content
ms.date: 08/03/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 691074727bab67e616541b393468eb70f0b20a05
ms.sourcegitcommit: 968187e803a866b60cda0528718a3d31f07dc54c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/03/2017
---
# <a name="import-and-export-store-listings"></a><span data-ttu-id="4ec06-104">ストア登録情報のインポートとエクスポート</span><span class="sxs-lookup"><span data-stu-id="4ec06-104">Import and export Store listings</span></span>

<span data-ttu-id="4ec06-105">アプリの[ストア登録情報](create-app-store-listings.md)は、デベロッパー センター ダッシュボードを使わなくても、登録情報を .csv ファイルにエクスポートして情報と資産を入力し、更新したファイルをインポートして作成できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-105">You can create [Store listings](create-app-store-listings.md) for your apps without using the Dev Center dashboard by exporting your listings in a .csv file, entering your info and assets, and then importing the updated file.</span></span> <span data-ttu-id="4ec06-106">この方法を使うと、登録情報を最初から作成することも、既に作成している登録情報を更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-106">You can use this method to create listings from scratch or to update listings you’ve already created.</span></span> 

<span data-ttu-id="4ec06-107">ただし、この方法では、アプリの[プラットフォーム固有のストア登録情報](create-platform-specific-store-listings.md)を作成することはできません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-107">Note that you can’t use this method to create or update [platform-specific Store listings](create-platform-specific-store-listings.md) for your app.</span></span>

> [!TIP]
> <span data-ttu-id="4ec06-108">この機能は、アドオンのストア登録情報のインポートとエクスポートにも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-108">You can also use this feature to import and export Store listing details for an add-on.</span></span> <span data-ttu-id="4ec06-109">アドオンの場合、プロセスは同じですが、[アドオンに関係のあるフィールドしか](#add-ons)含まれません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-109">For add-ons, the process works the same except that [only the fields relevant to add-ons](#add-ons) are included.</span></span>

## <a name="export-listings"></a><span data-ttu-id="4ec06-110">登録情報のエクスポート</span><span class="sxs-lookup"><span data-stu-id="4ec06-110">Export listings</span></span>

<span data-ttu-id="4ec06-111">アプリの申請の概要ページで、**[登録情報のエクスポート]** (**[ストア登録情報]** セクション) をクリックして、エンコード形式を UTF-8 にして .csv ファイルを生成します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-111">On the submission overview page for an app, click **Export listing** (in the **Store listings** section) to generate a .csv file encoded in UTF-8.</span></span> <span data-ttu-id="4ec06-112">このファイルを、自分のコンピューターの任意のフォルダーに保存します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-112">Save this file to a location on your computer.</span></span>

<span data-ttu-id="4ec06-113">このファイルは、Microsoft Excel などの CSV エディターを使って編集できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-113">You can use Microsoft Excel or another editor to edit this file.</span></span> <span data-ttu-id="4ec06-114">Office 365 バージョンの Excel では .csv ファイルを **CSV UTF-8 (カンマ区切り) (*.csv)** 形式で保存できますが、その他のバージョンではこれはサポートされていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-114">note that Office 365 versions of Excel will let you save a .csv file as **CSV UTF-8 (Comma-delimited) (*.csv)**, but other versions may not support this.</span></span> <span data-ttu-id="4ec06-115">どの Excel のバージョンがこの機能をサポートしているかについて詳しくは、[Excel 2016 の新機能情報](https://support.office.com/en-us/article/What-s-new-in-Excel-2016-for-Windows-5fdb9208-ff33-45b6-9e08-1f5cdb3a6c73)をご覧ください。各種エディターの UTF-8 形式でのエンコードについて詳しくは、[こちら](https://help.surveygizmo.com/help/encode-an-excel-file-to-utf-8-or-utf-16)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-115">You can find details about which versions of Excel support this feature at the [Excel 2016 New features bulletin](https://support.office.com/en-us/article/What-s-new-in-Excel-2016-for-Windows-5fdb9208-ff33-45b6-9e08-1f5cdb3a6c73), and more info about encoding as UTF-8 in various editors [here](https://help.surveygizmo.com/help/encode-an-excel-file-to-utf-8-or-utf-16).</span></span>
      
<span data-ttu-id="4ec06-116">製品の登録情報をまだ作成していない場合は、エクスポートした .csv ファイルにはカスタム データは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-116">If you haven’t created any listings for your product yet, the .csv file you exported will not contain any custom data.</span></span> <span data-ttu-id="4ec06-117">**[フィールド]**、**[ID]**、**[種類]**、**[既定値]** の列と、ストア登録情報に表示される各項目に対応する行が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-117">You’ll see columns for **Field**, **ID**, **Type**, and **default**, and rows which correspond to every item that can appear in a Store listing.</span></span>

<span data-ttu-id="4ec06-118">既に登録情報を作成している (またはパッケージをアップロードしている) 場合は、作成済みの登録情報の言語 (またはパッケージから検出された言語) に対応する ”言語-ロケール” のコードを使った見出しの列と、以前に提供している登録情報の列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-118">If you have already created listings (or have uploaded packages), you’ll also see columns labelled with language-locale codes that correspond to the language for each listing that you’ve created (or that we’ve detected in your packages), as well as any listing info that you’ve previously provided.</span></span>
     
<span data-ttu-id="4ec06-119">エクスポートされた .csv ファイルの各列に含まれる情報の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-119">Here’s an overview of what’s contained in each of the columns in the exported .csv file:</span></span>
- <span data-ttu-id="4ec06-120">**[フィールド]** 列には、ストア登録情報のすべての項目に関連付けられている名前が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-120">The **Field** column contains a name that is associated with every part of a Store listing.</span></span> <span data-ttu-id="4ec06-121">これらは、ダッシュボードでストア登録情報を作成したときに指定できるものと同じ項目に対応していますが、若干名前が異なっているものもあります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-121">These correspond to the same items you can provide when creating Store listings in the dashboard, although some of the names are slightly different.</span></span> <span data-ttu-id="4ec06-122">同じ種類の項目で複数の情報を入力できるものについては、指定できる最大数以下で、複数の行が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-122">For items where you can enter more than one of the same type of item, you’ll see multiple rows, up to the maximum number that you can provide.</span></span> <span data-ttu-id="4ec06-123">たとえば、**[アプリの機能]** には **Feature1**、**Feature2**、～最大で **Feature20** までが含まれます (アプリの機能は最大で 20 個まで指定できるため)。</span><span class="sxs-lookup"><span data-stu-id="4ec06-123">For example, for **App features** you will see **Feature1**, **Feature2**, etc., going up to **Feature20** (since you can provide up to 20 app features).</span></span>
- <span data-ttu-id="4ec06-124">**[ID]** 列には、デベロッパー センターで各フィールドに関連付けられている番号が含まれます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-124">The **ID** column contains a number that Dev Center associates with each field.</span></span> 
- <span data-ttu-id="4ec06-125">**[種類]** 列には、**テキスト**や**相対パス (またはデベロッパー センターのファイルへの URL)** など、各フィールドに指定する情報の種類について、全般的なガイドが示されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-125">The **Type** column provides general guidance about what type of info to provide for that field, such as **Text** or **Relative path (or URL to file in Dev Center)**.</span></span> 
- <span data-ttu-id="4ec06-126">**[既定]** 列 (と "言語-ロケール" のコードで見出しが付いた列) は、ストア登録情報の各項目に関連付けられているテキストや資産を示します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-126">The **default** column (and any columns labelled with language-locale codes) represent the text or assets associated with each part of the Store listing.</span></span> <span data-ttu-id="4ec06-127">これらの列のフィールドを編集して、ストア登録情報を更新できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-127">You can edit the fields in these columns to make updates to your Store listings.</span></span>

>[!IMPORTANT]
> <span data-ttu-id="4ec06-128">**[フィールド]**、**[ID]**、または **[種類]** 列の情報は、変更しないでください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-128">Don’t change any of the info in the **Field**, **ID**, or **Type** columns.</span></span> <span data-ttu-id="4ec06-129">これらの列の情報は、インポートするファイルを処理するために、そのままの状態で維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-129">The info in these columns must remain unchanged in order for your imported file to be processed.</span></span>

## <a name="update-listing-info"></a><span data-ttu-id="4ec06-130">登録情報の更新</span><span class="sxs-lookup"><span data-stu-id="4ec06-130">Update listing info</span></span>

<span data-ttu-id="4ec06-131">登録情報をエクスポートして .csv ファイルを保存したら、.csv ファイルで直接登録情報を編集できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-131">Once you’ve exported your listings and saved your .csv file, you can edit your listing info directly in the .csv file.</span></span> 

<span data-ttu-id="4ec06-132">**[既定]** 列のほかに、登録情報を作成した言語ごとに専用の列が作成されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-132">Along with the **default** column, each language for which you’ve created a listing has its own column.</span></span> <span data-ttu-id="4ec06-133">ある列内の変更は、その言語の説明に適用されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-133">The changes you make in a column will be applied to your description in that language.</span></span> <span data-ttu-id="4ec06-134">次の空の列の先頭行に "言語-ロケール" のコードを追加すると、新しい言語の登録情報を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-134">You can create listings for new languages by adding the language-locale code into the next empty column in the top row.</span></span> <span data-ttu-id="4ec06-135">有効な "言語-ロケール" コードの一覧については、「[サポートされている言語](supported-languages.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-135">For a list of valid language-locale codes, see [Supported languages](supported-languages.md).</span></span>

<span data-ttu-id="4ec06-136">**[既定]** 列には、アプリのすべての説明で共通して使いたい情報を入力できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-136">You can use the **default** column to enter info that you want to share across all of your app’s descriptions.</span></span> <span data-ttu-id="4ec06-137">特定の言語のフィールドを空白のままにすると、その言語には [既定] 列の情報が使われます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-137">If the field for a given language is left blank, the info from the default column will be used for that language.</span></span> <span data-ttu-id="4ec06-138">特定の言語について、そのフィールドを上書きしたい場合は、その言語用に別の情報を入力します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-138">You can override that field for a particular language by entering different info for that language.</span></span>

<span data-ttu-id="4ec06-139">ほとんどのストア登録情報フィールドは、省略可能です。</span><span class="sxs-lookup"><span data-stu-id="4ec06-139">Most of the Store listing fields are optional.</span></span> <span data-ttu-id="4ec06-140">各登録情報の必須項目は **[説明]** とスクリーンショット 1 つです。関連パッケージがない言語については、**[タイトル]** も指定して、その登録情報に使う予約済みアプリ名を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-140">The **Description** and one screenshot are required for each listing; for languages which don’t have associated packages, you will also need to provide a **Title** to indicate which of your reserved app names should be used for that listing.</span></span> <span data-ttu-id="4ec06-141">その他のフィールドについては、登録情報に含めたくない場合、空のままでかまいません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-141">For all other fields, you can leave the field empty if you don’t want to include it in your listing.</span></span> <span data-ttu-id="4ec06-142">ただし、特定の言語でフィールドに何も指定しないと、[既定] 列の対応するフィールドに情報がないかどうかが確認されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-142">Remember that if you leave a field for a given language blank, we’ll check to see if there is info in that field in the default column.</span></span> <span data-ttu-id="4ec06-143">情報があった場合は、その情報が使われます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-143">If so, that info will be used.</span></span> 

<span data-ttu-id="4ec06-144">たとえば、次の例について考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="4ec06-144">For instance, consider the following example:</span></span> 

![エクスポートした登録情報の例](images/listingimport.png)
     
- <span data-ttu-id="4ec06-146">“Default description” (既定の説明) というテキストが en-us と fr-fr の **[説明]** フィールドに使用されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-146">The text “Default description” will be used for the **Description** field in the en-us and fr-fr listings.</span></span> <span data-ttu-id="4ec06-147">しかし、es-es の登録情報の **[説明]** フィールドには、“Spanish description” (スペイン語の説明) というテキストが使われます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-147">However, the **Description** field in the es-es listing would use the text “Spanish description”.</span></span> 
- <span data-ttu-id="4ec06-148">**[ReleaseNotes]** フィールドでは、en-us には “English release notes” (英語のリリース ノート) というテキストが使われ、fr-fr には “French release notes” (フランス語のリリース ノート) というテキストが使われます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-148">For the **ReleaseNotes** field, the text “English release notes” will be used for en-us, and the text “French release notes” will be used for fr-fr.</span></span> <span data-ttu-id="4ec06-149">しかし、es-es にはどの "release notes" (リリース ノート) も表示されません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-149">However, no release notes will appear for es-es.</span></span>

<span data-ttu-id="4ec06-150">特定のフィールドで何も編集したくない場合は、スプレッドシートから対応する列全体を削除できます。**ただし、トレーラーとトレーラーの関連サムネールの行は削除できません**。</span><span class="sxs-lookup"><span data-stu-id="4ec06-150">If you don’t want to make any edits to a particular field, you can delete the entire row from the spreadsheet, **with the exception of the rows for trailers and their associated thumbnails and titles**.</span></span> <span data-ttu-id="4ec06-151">それ以外の項目については、行を削除しても、登録情報内のそのフィールドに関連付けられているデータには何の影響もありません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-151">Other than for these items, deleting a row will not impact the data associated with that field in your listings.</span></span> <span data-ttu-id="4ec06-152">したがって、編集しない行があれば削除して、変更するフィールドの処理に集中できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-152">This lets you remove any rows which you don’t intend to edit, so you can focus on the fields in which you’re making changes.</span></span>

<span data-ttu-id="4ec06-153">行全体ではなく、特定の言語について任意のフィールドの情報を削除する場合は、フィールドによって動作が異なります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-153">Deleting the info in a field for one language, without removing the entire row, works differently, depending on the field.</span></span> <span data-ttu-id="4ec06-154">**[種類]** が **[テキスト]** のフィールドは、任意のフィールドの情報を削除すると、単純にその言語の登録情報から該当するエントリーが削除されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-154">For fields whose **Type** is **Text**, deleting the info in a field will simply remove that entry from the listing in that language.</span></span>  <span data-ttu-id="4ec06-155">しかし、スクリーンショットやロゴなど、画像のフィールドの情報を削除する場合は、何も変更されません。デベロッパー センターで直接編集して削除しない限り、以前の画像が引き続き使用されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-155">However, deleting the info in a field for an image, such as a screenshot or logo, will not have any effect; the previous image will still be used unless you remove it by editing directly in Dev Center.</span></span> <span data-ttu-id="4ec06-156">ただし、トレーラーのフィールドについては情報を削除すると、デベロッパー センターからそのトレーラーが削除されるため、削除する前に必要なファイルのコピーを保存しておいてください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-156">Deleting the info for a trailer field will actually remove that trailer from Dev Center, so be sure you have a copy of any needed files before you do so.</span></span>

<span data-ttu-id="4ec06-157">エクスポートした登録情報のフィールドの多くは、上の例の **[説明]** や **[ReleaseNotes]** のように、テキスト入力が必要です。</span><span class="sxs-lookup"><span data-stu-id="4ec06-157">Many of the fields in your exported listings require text entry, such as the ones in the example above, **Description** and **ReleaseNotes**.</span></span> <span data-ttu-id="4ec06-158">この種類のフィールドでは、各言語のフィールドに適切なテキストを入力してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-158">For these types of fields, simply enter the appropriate text into the field for each language.</span></span> <span data-ttu-id="4ec06-159">必ず、各フィールドの長さやその他の要件に従ってください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-159">Be sure to follow the length and other requirements for each field.</span></span> <span data-ttu-id="4ec06-160">その他の要件について詳しくは、「[アプリのストア登録情報の作成](create-app-store-listings.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-160">For more info on these requirements, see [Create app Store listings](create-app-store-listings.md).</span></span>

<span data-ttu-id="4ec06-161">画像やトレーラーなどの資産に対応するフィールドへの情報の入力は、少し複雑です。</span><span class="sxs-lookup"><span data-stu-id="4ec06-161">Providing info for fields that correspond to assets, such as images and trailers, are a bit more complicated.</span></span> <span data-ttu-id="4ec06-162">これらの資産の**種類**は、**テキスト**ではなく、**相対パス (またはデベロッパー センターのファイルへの URL)** になります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-162">Rather than **Text**, the **Type** for these assets is **Relative path (or URL to file in Dev Center)**.</span></span> 
     
<span data-ttu-id="4ec06-163">既にストア登録情報の資産をアップロードしている場合、これらの資産は URL で表されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-163">If you’ve already uploaded assets for your Store listings, these assets will then be represented by a URL.</span></span> <span data-ttu-id="4ec06-164">この URL は、1 製品の複数の説明で再利用できるだけでなく、同じ開発者アカウント内の複数の製品で再利用することもできます。したがって、必要に応じて、これらの URL をコピーして、別のフィールドで再利用できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-164">These URLs can be reused in multiple descriptions for a product, or even across different products within the same developer account, so you can copy these URLs to reuse them in a different field if you’d like.</span></span>

> [!TIP]
> <span data-ttu-id="4ec06-165">URL に対応している資産を確認するには、URL をブラウザーに入力して画像を表示 (またはトレーラー ビデオをダウンロード) できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-165">To confirm which asset corresponds to a URL, you can enter the URL into a browser to view the image (or download the trailer video).</span></span>  <span data-ttu-id="4ec06-166">この URL が機能するには、デベロッパー センター アカウントにサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-166">You must be signed in to your Dev Center account in order for this URL to work.</span></span>

<span data-ttu-id="4ec06-167">これまでにデベロッパー センターに追加していない新しい資産を使いたい場合は、単一の .csv ファイルではなく、フォルダーとして登録情報をインポートします。</span><span class="sxs-lookup"><span data-stu-id="4ec06-167">If you want to use a new asset that you haven’t previously added to Dev Center, you can do so by importing your listings as a folder, rather than as a single .csv file.</span></span> <span data-ttu-id="4ec06-168">.csv ファイルを含むフォルダを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-168">You’ll need to create a folder that contains your .csv file.</span></span> <span data-ttu-id="4ec06-169">次に、その同じフォルダーのルート フォルダーまたはサブフォルダーに画像を追加します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-169">Then, add your images that same folder, either in the root folder or in a subfolder.</span></span> <span data-ttu-id="4ec06-170">フィールドには、ルート フォルダー名を含む完全なパスを入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-170">You’ll need to enter the full path, including the root folder name, in the field.</span></span>

> [!TIP]
> <span data-ttu-id="4ec06-171">フォルダーとして登録情報をインポートした場合に最適な結果が得られるように、必ず Microsoft Edge、Chrome、または Firefox の最新バージョンを使用してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-171">For best results when importing your listings as a folder, be sure you are using the latest version of either Microsoft Edge, Chrome, or Firefox.</span></span>

<span data-ttu-id="4ec06-172">たとえば、ルート フォルダー名が **my_folder** で、**screenshot1.png** という名前の画像を **DesktopScreenshot1** に使う場合、screenshot1.png をそのフォルダーのルートに追加して、**[DesktopScreenshot1]** フィールドに「**my_folder/screenshot1.png**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-172">For example, if your root folder is named **my_folder**, and you want to use an image called **screenshot1.png** for **DesktopScreenshot1**, you could add screenshot1.png to the root of that folder, then enter **my_folder/screenshot1.png** in the **DesktopScreenshot1** field.</span></span> <span data-ttu-id="4ec06-173">ルートフォルダー内に images フォルダーを作成して、そこに screenshot1.jpg を格納した場合は、「**my_folder/images/screenshot1.png**」と入力します。</span><span class="sxs-lookup"><span data-stu-id="4ec06-173">If you created an images folder within your root folder and then placed screenshot1.jpg there, you would enter **my_folder/images/screenshot1.png**.</span></span> <span data-ttu-id="4ec06-174">フォルダーを使って登録情報のインポートが完了したら、次に登録情報をエクスポートするときは、画像へのパスがデベロッパー センター内のファイルへの URL に変換されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-174">Note that after you import your listings using a folder, paths to your images will be converted to URLs to the files in Dev Center the next time you export your listings.</span></span> <span data-ttu-id="4ec06-175">この URL はコピーして貼り付けることで、再利用できます (登録情報の複数の言語で同じ資産を使用する場合など)。</span><span class="sxs-lookup"><span data-stu-id="4ec06-175">You can copy and paste these URLs to use them again (for example, to use the same assets in several listing languages).</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="4ec06-176">エクスポートした登録情報にトレーラーが含まれている場合、トレーラーやそのサムネイル画像への URL を .csv ファイルから削除すると、そのファイルはダッシュボードから完全に削除され、ダッシュボードからはアクセスできなくなります (そのファイルが別の登録情報でも使用されていて、そこで削除されていない場合はアクセスできます)。</span><span class="sxs-lookup"><span data-stu-id="4ec06-176">If your exported listing includes trailers, be aware that deleting the URL to the trailer or its thumbnail image from your .csv file will completely remove the deleted file from your dashboard, and you will no longer be able to access it there (unless it is also used in another listing where it hasn’t been deleted).</span></span> 

## <a name="import-listings"></a><span data-ttu-id="4ec06-177">登録情報のインポート</span><span class="sxs-lookup"><span data-stu-id="4ec06-177">Import listings</span></span>

<span data-ttu-id="4ec06-178">.csv ファイルにすべての変更を入力し (アップロードする資産も含め) たら、アップロードする前に、必ずファイルを保存してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-178">Once you have entered all of your changes into the .csv file (and included any assets you want to upload), you’ll need to save your file before uploading it.</span></span> <span data-ttu-id="4ec06-179">エンコード形式に UTF-8 をサポートしているバージョンの Microsoft Excel を使っている場合は、必ず **[名前を付けて保存]** を選び、**[CSV UTF-8 (カンマ区切り) (*.csv)]** 形式を使ってください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-179">If you're using a version of Microsoft Excel that supports UTF-8 encoding, be sure to select **Save as** and use the **CSV UTF-8 (Comma-delimited) (*.csv)** format.</span></span> <span data-ttu-id="4ec06-180">別のエディターを使って .csv ファイルを表示および編集している場合は、アップロードする前に .csv ファイルが UTF-8 形式でエンコードされていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-180">If you use a different editor to view and edit your .csv file, make sure the .csv file is encoded in UTF-8 before you upload.</span></span>

<span data-ttu-id="4ec06-181">更新した .csv ファイルをアップロードして、登録情報データをインポートできる状態になったら、申請の概要ページで **[登録情報のインポート]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-181">When you’re ready to upload the updated .csv file and import your listing data, select **Import listings** on your submission overview page.</span></span> <span data-ttu-id="4ec06-182">.csv ファイルのみをインポートする場合は、**[インポート .csv]** を選んでファイルを参照し、**[開く]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4ec06-182">If you’re only importing a .csv file, choose **Import .csv**, browse to your file, and click **Open**.</span></span> <span data-ttu-id="4ec06-183">画像ファイルを含むフォルダーをインポートをする場合は、[Import folder] (フォルダーのインポート) を選んでフォルダーを参照し、**[フォルダーの選択]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="4ec06-183">If you’re importing a folder with image files, choose Import folder, browse to your folder, and click **Select folder**.</span></span> <span data-ttu-id="4ec06-184">フォルダー内には、アップロードする資産と、.csv ファイルが 1 つだけ含まれるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-184">Make sure there is only one .csv file in your folder, along with any assets you’re uploading.</span></span> 

<span data-ttu-id="4ec06-185">インポートする .csv ファイルの処理中は、インポートと検証の状態を表す進行状況バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-185">As we process your imported .csv file, you’ll see a progress bar reflecting the import and validation status.</span></span> <span data-ttu-id="4ec06-186">この処理は、登録情報や画像ファイルが多い場合は特に、時間がかかる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-186">This can take some time, especially if you have a lot of listings and/or image files.</span></span> 

<span data-ttu-id="4ec06-187">何か問題が見つかった場合は、必要な更新を行い、もう一度アップロードするように求めるコメントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-187">If we detect any problems, you’ll see a note indicating that you’ll need to make any needed updates and try again.</span></span> <span data-ttu-id="4ec06-188">**[エラーの表示]** リンクを選び、無効なフィールドとその理由を確認してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-188">Select the **View errors** link to see which fields are invalid and why.</span></span> <span data-ttu-id="4ec06-189">.csv ファイル内で見つかった問題を修正 (または無効な資産を置換) して、もう一度登録情報をインポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="4ec06-189">You’ll need to correct these issues in your .csv file (or replace any invalid assets) and then import your listings again.</span></span>

> [!TIP]
> <span data-ttu-id="4ec06-190">後でこの情報に再びアクセスするには、**[最新のインポートに関するエラーの表示]** リンクを使います。</span><span class="sxs-lookup"><span data-stu-id="4ec06-190">You can access this info again later via the **View errors for last import** link.</span></span>

<span data-ttu-id="4ec06-191">ファイル内のエラーがすべて解決しないと、.csv ファイルの情報は、エラーのないフィールドも含めて、デベロッパー センターにまったく保存されません。</span><span class="sxs-lookup"><span data-stu-id="4ec06-191">None of the info from your .csv file will be saved in Dev Center until all of the errors in your file have been resolved, even for fields without errors.</span></span> <span data-ttu-id="4ec06-192">エラーのない .csv ファイルがインポートされると、用意した登録情報がデベロッパー センターに保存され、該当する申請に使用されます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-192">Once you have imported a .csv file that has no errors, the listing info you’ve provided will be saved in Dev Center, and will be used for that submission.</span></span>

<span data-ttu-id="4ec06-193">更新した別の .csv ファイルをインポートするか、デベロッパー センターで直接変更を行うことで、登録情報は引き続き更新できます。</span><span class="sxs-lookup"><span data-stu-id="4ec06-193">You can continue to make updates to your listings either by  importing another updated .csv file, or by making changes directly in Dev Center.</span></span>

## <a name="add-ons"></a><span data-ttu-id="4ec06-194">アドオン</span><span class="sxs-lookup"><span data-stu-id="4ec06-194">Add-ons</span></span>

<span data-ttu-id="4ec06-195">アドオンの場合、ストア登録情報のインポートとエクスポートのプロセスは上記と同じですが、対象になるフィールドは [アドオンのストア登録情報](create-add-on-store-listings.md)に関連する **[説明]**、**[タイトル]**、**[StoreLogo300x300]** (デベロッパー センターのストア登録情報ページでは **[アイコン]**) の 3 フィールドのみです。</span><span class="sxs-lookup"><span data-stu-id="4ec06-195">For add-ons, importing and exporting Store listings uses the same process described above, except that you'll only see the three fields relevant to [add-on Store listings](create-add-on-store-listings.md): **Description**, **Title**, and **StoreLogo300x300** (referred to as **Icon** in the Store listing page in Dev Center).</span></span> <span data-ttu-id="4ec06-196">**[タイトル]** フィールドは必須で、その他の 2 フィールドは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="4ec06-196">The **Title** field is required, and the other two fields are optional.</span></span>

<span data-ttu-id="4ec06-197">アプリのアドオンのストア登録情報のインポートとエクスポートは個別に実行する必要があります。申請の概要ページから対象のアドオンを処理してください。</span><span class="sxs-lookup"><span data-stu-id="4ec06-197">Note that you must import and export Store listings separately for each add-on in your app by navigating to the submission overview page for the add-on.</span></span>

