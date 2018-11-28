---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトを使用して別のアプリから共有されたコンテンツを受け取る方法について説明します。 共有コントラクトを使うと、ユーザーが共有機能を呼び出したときに、アプリをオプションとして提示できます。
title: データの受信
ms.assetid: 0AFF9E0D-DFF4-4018-B393-A26B11AFDB41
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e17b9ddd5833899a83e24d24c74f9c620a28f5c8
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7969135"
---
# <a name="receive-data"></a><span data-ttu-id="13f86-105">データの受信</span><span class="sxs-lookup"><span data-stu-id="13f86-105">Receive data</span></span>



<span data-ttu-id="13f86-106">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトを使用して別のアプリから共有されたコンテンツを受け取る方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="13f86-106">This article explains how to receive content in your Universal Windows Platform (UWP) app shared from another app by using Share contract.</span></span> <span data-ttu-id="13f86-107">共有コントラクトを使うと、ユーザーが共有機能を呼び出したときに、アプリをオプションとして提示できます。</span><span class="sxs-lookup"><span data-stu-id="13f86-107">This Share contract allows your app to be presented as an option when the user invokes Share.</span></span>

## <a name="declare-your-app-as-a-share-target"></a><span data-ttu-id="13f86-108">アプリを共有ターゲットとして宣言する</span><span class="sxs-lookup"><span data-stu-id="13f86-108">Declare your app as a share target</span></span>

<span data-ttu-id="13f86-109">ユーザーが共有を選択すると、ターゲット アプリの一覧が表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f86-109">The system displays a list of possible target apps when a user invokes Share.</span></span> <span data-ttu-id="13f86-110">アプリを一覧に表示するには、そのアプリが共有コントラクトをサポートしていることを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-110">In order to appear on the list, your app needs to declare that it supports the Share contract.</span></span> <span data-ttu-id="13f86-111">こうすることで、そのアプリでコンテンツを受け取ることができるとシステムに通知できます。</span><span class="sxs-lookup"><span data-stu-id="13f86-111">This lets the system know that your app is available to receive content.</span></span>

1.  <span data-ttu-id="13f86-112">マニフェスト ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="13f86-112">Open the manifest file.</span></span> <span data-ttu-id="13f86-113">マニフェスト ファイルは **package.appxmanifest** のような名前になっています。</span><span class="sxs-lookup"><span data-stu-id="13f86-113">It should be called something like **package.appxmanifest**.</span></span>
2.  <span data-ttu-id="13f86-114">**[宣言]** タブを開きます。</span><span class="sxs-lookup"><span data-stu-id="13f86-114">Open the **Declarations** tab.</span></span>
3.  <span data-ttu-id="13f86-115">**[使用可能な宣言]** ボックスの一覧の **[共有ターゲット]** を選び、**[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="13f86-115">Choose **Share Target** from the **Available Declarations** list, and then select **Add**.</span></span>

## <a name="choose-file-types-and-formats"></a><span data-ttu-id="13f86-116">ファイルの種類と形式を選択する</span><span class="sxs-lookup"><span data-stu-id="13f86-116">Choose file types and formats</span></span>

<span data-ttu-id="13f86-117">次に、サポートするファイルの種類とデータ形式を決定します。</span><span class="sxs-lookup"><span data-stu-id="13f86-117">Next, decide what file types and data formats you support.</span></span> <span data-ttu-id="13f86-118">共有 API では、テキスト、HTML、ビットマップなど複数の標準形式がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="13f86-118">The Share APIs support several standard formats, such as Text, HTML, and Bitmap.</span></span> <span data-ttu-id="13f86-119">カスタムのファイルの種類とデータ形式を指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="13f86-119">You can also specify custom file types and data formats.</span></span> <span data-ttu-id="13f86-120">これを行う場合は、その種類と形式をソース アプリが認識している必要があります。そうしないと、ソース アプリはその形式を使ってデータを共有できません。</span><span class="sxs-lookup"><span data-stu-id="13f86-120">If you do, remember that source apps have to know what those types and formats are; otherwise, those apps can't use the formats to share data.</span></span>

<span data-ttu-id="13f86-121">アプリで処理できる形式のみを登録してください。</span><span class="sxs-lookup"><span data-stu-id="13f86-121">Only register for formats that your app can handle.</span></span> <span data-ttu-id="13f86-122">ユーザーが共有を選択すると、共有されるデータをサポートしているターゲット アプリだけが表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f86-122">Only target apps that support the data being shared appear when the user invokes Share.</span></span>

<span data-ttu-id="13f86-123">ファイルの種類を設定するには:</span><span class="sxs-lookup"><span data-stu-id="13f86-123">To set file types:</span></span>

1.  <span data-ttu-id="13f86-124">マニフェスト ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="13f86-124">Open the manifest file.</span></span> <span data-ttu-id="13f86-125">マニフェスト ファイルは **package.appxmanifest** のような名前になっています。</span><span class="sxs-lookup"><span data-stu-id="13f86-125">It should be called something like **package.appxmanifest**.</span></span>
2.  <span data-ttu-id="13f86-126">**[宣言]** ページの **[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="13f86-126">In the **Supported File Types** section of the **Declarations** page, select **Add New**.</span></span>
3.  <span data-ttu-id="13f86-127">サポートするファイル名拡張子を入力します。たとえば、「.docx」と入力します。</span><span class="sxs-lookup"><span data-stu-id="13f86-127">Type the file name extension that you want to support, for example, ".docx."</span></span> <span data-ttu-id="13f86-128">ピリオドを忘れないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="13f86-128">You need to include the period.</span></span> <span data-ttu-id="13f86-129">すべてのファイルの種類をサポートする場合は、**SupportsAnyFileType** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="13f86-129">If you want to support all file types, select the **SupportsAnyFileType** check box.</span></span>

<span data-ttu-id="13f86-130">データ形式を設定するには:</span><span class="sxs-lookup"><span data-stu-id="13f86-130">To set data formats:</span></span>

1.  <span data-ttu-id="13f86-131">マニフェスト ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="13f86-131">Open the manifest file.</span></span>
2.  <span data-ttu-id="13f86-132">**[宣言]** ページの **[データ形式]** セクションを開き、**[新規追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="13f86-132">Open the **Data Formats** section of the **Declarations** page, and then select **Add New**.</span></span>
3.  <span data-ttu-id="13f86-133">サポートすデータ形式の名前を入力します。たとえば、「テキスト」と入力します。</span><span class="sxs-lookup"><span data-stu-id="13f86-133">Type the name of the data format you support, for example, "Text."</span></span>

## <a name="handle-share-activation"></a><span data-ttu-id="13f86-134">共有のアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="13f86-134">Handle share activation</span></span>

<span data-ttu-id="13f86-135">ユーザーが (通常は共有 UI の使用可能なターゲット アプリの一覧から) アプリを選ぶと、[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Application.OnShareTargetActivated(Windows.ApplicationModel.Activation.ShareTargetActivatedEventArgs)) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="13f86-135">When a user selects your app (usually by selecting it from a list of available target apps in the share UI), an [**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Application.OnShareTargetActivated(Windows.ApplicationModel.Activation.ShareTargetActivatedEventArgs)) event is raised.</span></span> <span data-ttu-id="13f86-136">アプリはこのイベントを処理して、ユーザーが共有するデータを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-136">Your app needs to handle this event to process the data that the user wants to share.</span></span>

<!-- For some reason, the snippets in this file are all inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    // Code to handle activation goes here. 
} 
```

<span data-ttu-id="13f86-137">ユーザーが共有するデータは、[**ShareOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation) オブジェクトに格納されています。</span><span class="sxs-lookup"><span data-stu-id="13f86-137">The data that the user wants to share is contained in a [**ShareOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation) object.</span></span> <span data-ttu-id="13f86-138">このオブジェクトを使うと、オブジェクトに格納されているデータの形式を調べることができます。</span><span class="sxs-lookup"><span data-stu-id="13f86-138">You can use this object to check the format of the data it contains.</span></span>

```cs
ShareOperation shareOperation = args.ShareOperation;
if (shareOperation.Data.Contains(StandardDataFormats.Text))
{
    string text = await shareOperation.Data.GetTextAsync();

    // To output the text from this example, you need a TextBlock control
    // with a name of "sharedContent".
    sharedContent.Text = "Text: " + text;
} 
```

## <a name="report-sharing-status"></a><span data-ttu-id="13f86-139">共有状態の報告</span><span class="sxs-lookup"><span data-stu-id="13f86-139">Report sharing status</span></span>

<span data-ttu-id="13f86-140">場合によっては、ユーザーが共有するデータをアプリが処理するのに時間がかかることがあります。</span><span class="sxs-lookup"><span data-stu-id="13f86-140">In some cases, it can take time for your app to process the data it wants to share.</span></span> <span data-ttu-id="13f86-141">たとえば、ファイルまたは画像のコレクションを共有する場合などです。</span><span class="sxs-lookup"><span data-stu-id="13f86-141">Examples include users sharing collections of files or images.</span></span> <span data-ttu-id="13f86-142">このような項目は単純なテキスト文字列より大きいため、処理に時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="13f86-142">These items are larger than a simple text string, so they take longer to process.</span></span>

```cs
shareOperation.ReportStarted(); 
```

<span data-ttu-id="13f86-143">[**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted) を呼び出した後、ユーザーはアプリをそれ以上操作できなくなります。</span><span class="sxs-lookup"><span data-stu-id="13f86-143">After calling [**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted), don't expect any more user interaction with your app.</span></span> <span data-ttu-id="13f86-144">したがって、このオブジェクトの呼び出しは、ユーザーがアプリを閉じても問題がない状況でのみ行ってください。</span><span class="sxs-lookup"><span data-stu-id="13f86-144">As a result, you shouldn't call it unless your app is at a point where it can be dismissed by the user.</span></span>

<span data-ttu-id="13f86-145">長時間共有が行われている状況では、アプリが DataPackage オブジェクトからすべてのデータを取得する前に、ユーザーがソース アプリを閉じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-145">With an extended share, it's possible that the user might dismiss the source app before your app has all the data from the DataPackage object.</span></span> <span data-ttu-id="13f86-146">そのため、アプリが必要なデータを取得したタイミングをシステムに通知することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f86-146">As a result, we recommend that you let the system know when your app has acquired the data it needs.</span></span> <span data-ttu-id="13f86-147">こうすると、システムは必要に応じてソース アプリを中断または終了できます。</span><span class="sxs-lookup"><span data-stu-id="13f86-147">This way, the system can suspend or terminate the source app as necessary.</span></span>

```cs
shareOperation.ReportSubmittedBackgroundTask(); 
```

<span data-ttu-id="13f86-148">問題が発生した場合には、[**ReportError**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportError(System.String)) を呼び出して、エラー メッセージをシステムに送信します。</span><span class="sxs-lookup"><span data-stu-id="13f86-148">If something goes wrong, call [**ReportError**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportError(System.String)) to send an error message to the system.</span></span> <span data-ttu-id="13f86-149">ユーザーは、共有の状態を確認したときにこのメッセージを目にします。</span><span class="sxs-lookup"><span data-stu-id="13f86-149">The user will see the message when they check on the status of the share.</span></span> <span data-ttu-id="13f86-150">その時点で、アプリがシャットダウンし、共有が終了します。</span><span class="sxs-lookup"><span data-stu-id="13f86-150">At that point, your app is shut down and the share is ended.</span></span> <span data-ttu-id="13f86-151">この場合、ユーザーはアプリでのコンテンツの共有をやり直す必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-151">The user will need to start again to share the content to your app.</span></span> <span data-ttu-id="13f86-152">エラーの中にはそれほど重大ではないものも含まれ、シナリオによっては、共有操作を終了しなくても済む場合もあります。</span><span class="sxs-lookup"><span data-stu-id="13f86-152">Depending on your scenario, you may decide that a particular error isn't serious enough to end the share operation.</span></span> <span data-ttu-id="13f86-153">その場合は、**ReportError** を呼び出さずに、共有を続けることができます。</span><span class="sxs-lookup"><span data-stu-id="13f86-153">In that case, you can choose to not call **ReportError** and to continue with the share.</span></span>

```cs
shareOperation.ReportError("Could not reach the server! Try again later."); 
```

<span data-ttu-id="13f86-154">最後に、アプリによる共有コンテンツの処理が正常に完了したときは、[**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted) を呼び出してシステムに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-154">Finally, when your app has successfully processed the shared content, you should call [**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted) to let the system know.</span></span>

```cs
shareOperation.ReportCompleted();
```

<span data-ttu-id="13f86-155">これらのメソッドを使う場合は、通常、前に説明した順序で呼び出し、2 回以上呼び出さないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="13f86-155">When you use these methods, you usually call them in the order just described, and you don't call them more than once.</span></span> <span data-ttu-id="13f86-156">ただし、ターゲット アプリが [**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted) の前に [**ReportDataRetrieved**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportDataRetrieved) を呼び出すことができる場合があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-156">However, there are times when a target app can call [**ReportDataRetrieved**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportDataRetrieved) before [**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted).</span></span> <span data-ttu-id="13f86-157">たとえば、アプリがアクティブ化ハンドラーのタスクの一部としてデータを受信できるが、ユーザーが **[共有]** ボタンをクリックするまで **ReportStarted** を呼び出さない場合です。</span><span class="sxs-lookup"><span data-stu-id="13f86-157">For example, the app might retrieve the data as part of a task in the activation handler, but not call **ReportStarted** until the user selects a **Share** button.</span></span>

## <a name="return-a-quicklink-if-sharing-was-successful"></a><span data-ttu-id="13f86-158">共有が成功した場合に QuickLink を返す</span><span class="sxs-lookup"><span data-stu-id="13f86-158">Return a QuickLink if sharing was successful</span></span>

<span data-ttu-id="13f86-159">ユーザーがアプリでコンテンツを受け取ることを選んだときは、[**QuickLink**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.QuickLink) を作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="13f86-159">When a user selects your app to receive content, we recommend that you create a [**QuickLink**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.QuickLink).</span></span> <span data-ttu-id="13f86-160">**QuickLink** は、情報をアプリと簡単に共有できるようにするショートカットのようなものです。</span><span class="sxs-lookup"><span data-stu-id="13f86-160">A **QuickLink** is like a shortcut that makes it easier for users to share information with your app.</span></span> <span data-ttu-id="13f86-161">たとえば、あらかじめ友人のメール アドレスが構成された新しいメール メッセージを開く **QuickLink** を作成できます。</span><span class="sxs-lookup"><span data-stu-id="13f86-161">For example, you could create a **QuickLink** that opens a new mail message pre-configured with a friend's email address.</span></span>

<span data-ttu-id="13f86-162">**QuickLink** には、タイトル、アイコン、ID が必要です。タイトル ("母へのメール" など) とアイコンは、ユーザーが共有チャームをタップすると表示されます。</span><span class="sxs-lookup"><span data-stu-id="13f86-162">A **QuickLink** must have a title, an icon, and an Id. The title (like "Email Mom") and icon appear when the user taps the Share charm.</span></span> <span data-ttu-id="13f86-163">ID は、アプリがメール アドレスやログイン資格情報などのカスタム情報にアクセスするために使われます。</span><span class="sxs-lookup"><span data-stu-id="13f86-163">The Id is what your app uses to access any custom information, such as an email address or login credentials.</span></span> <span data-ttu-id="13f86-164">アプリは、**QuickLink** を作成すると、[**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted) を呼び出して **QuickLink** をシステムに返します。</span><span class="sxs-lookup"><span data-stu-id="13f86-164">When your app creates a **QuickLink**, the app returns the **QuickLink** to the system by calling [**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted).</span></span>

<span data-ttu-id="13f86-165">**QuickLink** には、実際にデータが格納されているわけではなく、</span><span class="sxs-lookup"><span data-stu-id="13f86-165">A **QuickLink** does not actually store data.</span></span> <span data-ttu-id="13f86-166">識別子だけが含まれています。選択されたときにその識別子がアプリに送られます。</span><span class="sxs-lookup"><span data-stu-id="13f86-166">Instead, it contains an identifier that, when selected, is sent to your app.</span></span> <span data-ttu-id="13f86-167">**QuickLink** の ID と対応するユーザー データは、アプリで格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="13f86-167">Your app is responsible for storing the Id of the **QuickLink** and the corresponding user data.</span></span> <span data-ttu-id="13f86-168">ユーザーが **QuickLink** をタップすると、[**QuickLinkId**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.QuickLinkId) プロパティを介してその ID を取得できます。</span><span class="sxs-lookup"><span data-stu-id="13f86-168">When the user taps the **QuickLink**, you can get its Id through the [**QuickLinkId**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.QuickLinkId) property.</span></span>

```cs
async void ReportCompleted(ShareOperation shareOperation, string quickLinkId, string quickLinkTitle)
{
    QuickLink quickLinkInfo = new QuickLink
    {
        Id = quickLinkId,
        Title = quickLinkTitle,

        // For quicklinks, the supported FileTypes and DataFormats are set 
        // independently from the manifest
        SupportedFileTypes = { "*" },
        SupportedDataFormats = { StandardDataFormats.Text, StandardDataFormats.Uri, 
                StandardDataFormats.Bitmap, StandardDataFormats.StorageItems }
    };

    StorageFile iconFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync(
            "assets\\user.png", CreationCollisionOption.OpenIfExists);
    quickLinkInfo.Thumbnail = RandomAccessStreamReference.CreateFromFile(iconFile);
    shareOperation.ReportCompleted(quickLinkInfo);
}
```

## <a name="see-also"></a><span data-ttu-id="13f86-169">参照</span><span class="sxs-lookup"><span data-stu-id="13f86-169">See also</span></span> 

* [<span data-ttu-id="13f86-170">アプリ間通信</span><span class="sxs-lookup"><span data-stu-id="13f86-170">App-to-app communication</span></span>](index.md)
* [<span data-ttu-id="13f86-171">データの共有</span><span class="sxs-lookup"><span data-stu-id="13f86-171">Share data</span></span>](share-data.md)
* [<span data-ttu-id="13f86-172">OnShareTargetActivated</span><span class="sxs-lookup"><span data-stu-id="13f86-172">OnShareTargetActivated</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onsharetargetactivated.aspx)
* [<span data-ttu-id="13f86-173">ReportStarted</span><span class="sxs-lookup"><span data-stu-id="13f86-173">ReportStarted</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportstarted.aspx)
* [<span data-ttu-id="13f86-174">ReportError</span><span class="sxs-lookup"><span data-stu-id="13f86-174">ReportError</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reporterror.aspx)
* [<span data-ttu-id="13f86-175">ReportCompleted</span><span class="sxs-lookup"><span data-stu-id="13f86-175">ReportCompleted</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportcompleted.aspx)
* [<span data-ttu-id="13f86-176">ReportDataRetrieved</span><span class="sxs-lookup"><span data-stu-id="13f86-176">ReportDataRetrieved</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportdataretrieved.aspx)
* [<span data-ttu-id="13f86-177">ReportStarted</span><span class="sxs-lookup"><span data-stu-id="13f86-177">ReportStarted</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportstarted.aspx)
* [<span data-ttu-id="13f86-178">QuickLink</span><span class="sxs-lookup"><span data-stu-id="13f86-178">QuickLink</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.quicklink.aspx)
* [<span data-ttu-id="13f86-179">QuickLInkId</span><span class="sxs-lookup"><span data-stu-id="13f86-179">QuickLInkId</span></span>](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.quicklink.id.aspx)
