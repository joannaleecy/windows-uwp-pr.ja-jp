---
author: normesta
Description: "ユニバーサル Windows プラットフォーム (UWP) API を使用して Windows 10 ユーザー向けデスクトップ アプリを強化します。"
Search.Product: eADQiWindows 10XVcnh
title: "Windows 10 向けのデスクトップ アプリを強化する"
ms.author: normesta
ms.date: 07/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 9f1522527825d6580ddf4fc36599352a9ca8a243
ms.sourcegitcommit: f93e887fbab6c1f824a8f762ba848f64c7f77c49
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/03/2017
---
# <a name="enhance-your-desktop-application-for-windows-10"></a><span data-ttu-id="6abec-104">Windows 10 向けのデスクトップ アプリを強化する</span><span class="sxs-lookup"><span data-stu-id="6abec-104">Enhance your desktop application for Windows 10</span></span>

<span data-ttu-id="6abec-105">UWP API を使用して、Windows 10 ユーザーの利便性を高める最新のエクスペリエンスを追加できます。</span><span class="sxs-lookup"><span data-stu-id="6abec-105">You can use UWP APIs to add modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="6abec-106">最初に、プロジェクトをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="6abec-106">First, set up your project.</span></span> <span data-ttu-id="6abec-107">次に、Windows 10 エクスペリエンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-107">Then, add Windows 10 experiences.</span></span> <span data-ttu-id="6abec-108">Windows 10 ユーザー向けに個別にビルドすることも、実行する Windows のバージョンに関係なくすべてのユーザー向けにまったく同じバイナリを配布することもできます。</span><span class="sxs-lookup"><span data-stu-id="6abec-108">You can build separately for Windows 10 users or distribute the same exact binaries to all users regardless of which version of Windows they run.</span></span>

## <a name="first-set-up-your-project"></a><span data-ttu-id="6abec-109">最初に、プロジェクトをセットアップする</span><span class="sxs-lookup"><span data-stu-id="6abec-109">First, set up your project</span></span>

<span data-ttu-id="6abec-110">UWP API を使用するには、プロジェクトにいくつかの変更を加える必要があります。</span><span class="sxs-lookup"><span data-stu-id="6abec-110">You'll have to make a few changes to your project to use UWP APIs.</span></span>

### <a name="modify-a-net-project-to-use-uwp-apis"></a><span data-ttu-id="6abec-111">UWP API を使用するために .NET プロジェクトを変更する</span><span class="sxs-lookup"><span data-stu-id="6abec-111">Modify a .NET project to use UWP APIs</span></span>

<span data-ttu-id="6abec-112">**[参照マネージャー]** ダイアログ ボックスを開き、**[参照]** ボタンを選択して、**[すべてのファイル]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="6abec-112">Open the **Reference Manager** dialog box, choose the **Browse** button, and then select  **All Files**.</span></span>

![[参照の追加] ダイアログ ボックス](images/desktop-to-uwp/browse-references.png)

<span data-ttu-id="6abec-114">次に、これらのファイルへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-114">Then, add a reference to these files.</span></span>

|<span data-ttu-id="6abec-115">ファイル</span><span class="sxs-lookup"><span data-stu-id="6abec-115">File</span></span>|<span data-ttu-id="6abec-116">場所</span><span class="sxs-lookup"><span data-stu-id="6abec-116">Location</span></span>|
|--|--|
|<span data-ttu-id="6abec-117">System.Runtime.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="6abec-117">System.Runtime.WindowsRuntime</span></span>|<span data-ttu-id="6abec-118">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="6abec-118">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="6abec-119">System.Runtime.WindowsRuntime.UI.Xaml</span><span class="sxs-lookup"><span data-stu-id="6abec-119">System.Runtime.WindowsRuntime.UI.Xaml</span></span>|<span data-ttu-id="6abec-120">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="6abec-120">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="6abec-121">System.Runtime.InteropServices.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="6abec-121">System.Runtime.InteropServices.WindowsRuntime</span></span>|<span data-ttu-id="6abec-122">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="6abec-122">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="6abec-123">Windows.winmd</span><span class="sxs-lookup"><span data-stu-id="6abec-123">Windows.winmd</span></span>|<span data-ttu-id="6abec-124">C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Facade</span><span class="sxs-lookup"><span data-stu-id="6abec-124">C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Facade</span></span>|
|<span data-ttu-id="6abec-125">Windows.Foundation.UniversalApiContract.winmd</span><span class="sxs-lookup"><span data-stu-id="6abec-125">Windows.Foundation.UniversalApiContract.winmd</span></span>|<span data-ttu-id="6abec-126">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="6abec-126">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span></span>|
|<span data-ttu-id="6abec-127">Windows.Foundation.FoundationContract.winmd</span><span class="sxs-lookup"><span data-stu-id="6abec-127">Windows.Foundation.FoundationContract.winmd</span></span>|<span data-ttu-id="6abec-128">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="6abec-128">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span></span>|

<span data-ttu-id="6abec-129">**[プロパティ]** ウィンドウで、**Windows.winmd** ファイルと **Windows.Foundation.FoundationContract.winmd** ファイルの **[ローカルにコピー]** フィールドを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="6abec-129">In the **Properties** window, set the **Copy Local** field of the **Windows.winmd** and **Windows.Foundation.FoundationContract.winmd** files to **False**.</span></span>

![[ローカルにコピー] フィールド](images/desktop-to-uwp/copy-local-field.png)

### <a name="modify-a-c-project-to-use-uwp-apis"></a><span data-ttu-id="6abec-131">UWP API を使用するために C++ プロジェクトを変更する</span><span class="sxs-lookup"><span data-stu-id="6abec-131">Modify a C++ project to use UWP APIs</span></span>

<span data-ttu-id="6abec-132">プロジェクトのプロパティ ページを開きます。</span><span class="sxs-lookup"><span data-stu-id="6abec-132">Open the property pages of your project.</span></span>

<span data-ttu-id="6abec-133">**[C/C++]** 設定グループの **[全般]** 設定で、**[Windows ランタイム拡張機能の使用]** フィールドを **[はい (/ZW)]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="6abec-133">In the **General** settings of the **C/C++** settings group, set the **Consume Windows Runtime Extension** field to **Yes(/ZW)**.</span></span>

   ![Windows ランタイム拡張機能の使用](images/desktop-to-uwp/enable-winrt-objects.png)

<span data-ttu-id="6abec-135">**[追加の #using ディレクトリ]** ダイアログ ボックスを開き、次のディレクトリを追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-135">Open the **Additional #using Directories** dialog box, and add these directories.</span></span>

* <span data-ttu-id="6abec-136">C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcpackages</span><span class="sxs-lookup"><span data-stu-id="6abec-136">C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcpackages</span></span>
* <span data-ttu-id="6abec-137">C:\Program Files (x86)\Windows Kits\10\UnionMetadata</span><span class="sxs-lookup"><span data-stu-id="6abec-137">C:\Program Files (x86)\Windows Kits\10\UnionMetadata</span></span>
* <span data-ttu-id="6abec-138">C:\Program Files (x86)\Windows Kits\10\References\Windows.Foundation.UniversalApiContract\<*latest version*></span><span class="sxs-lookup"><span data-stu-id="6abec-138">C:\Program Files (x86)\Windows Kits\10\References\Windows.Foundation.UniversalApiContract\<*latest version*></span></span>
* <span data-ttu-id="6abec-139">C:\Program Files (x86)\Windows Kits\10\References\Windows.Foundation.FoundationContract\<*latest version*></span><span class="sxs-lookup"><span data-stu-id="6abec-139">C:\Program Files (x86)\Windows Kits\10\References\Windows.Foundation.FoundationContract\<*latest version*></span></span>

![追加の using ディレクトリ](images/desktop-to-uwp/additional-using.png)

<span data-ttu-id="6abec-141">**[追加のインクルード ディレクトリ]** ダイアログ ボックスを開き、ディレクトリ C:\Program Files (x86)\Windows Kits\10\Include\<*latest version*>\um を追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-141">Open the **Additional Include Directories** dialog box, and add this directory: C:\Program Files (x86)\Windows Kits\10\Include\<*latest version*>\um</span></span>

![追加のインクルード ディレクトリ](images/desktop-to-uwp/additional-include.png)

<span data-ttu-id="6abec-143">**[C/C++]** 設定グループの **[コード生成]** 設定で、**[最小リビルドを有効にする]** 設定を **[いいえ (/GM-)]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="6abec-143">In the **Code Generation** settings of the **C/C++** settings group, set the **Enable Minimal Rebuild** setting to **No(/GM-)**.</span></span>

![最小リビルドを有効にする](images/desktop-to-uwp/disable-min-build.png)


## <a name="add-windows-10-experiences"></a><span data-ttu-id="6abec-145">Windows 10 エクスペリエンスの追加</span><span class="sxs-lookup"><span data-stu-id="6abec-145">Add Windows 10 experiences</span></span>

<span data-ttu-id="6abec-146">これで、Windows 10 でアプリケーションをユーザーが実行する際に便利になる最新のエクスペリエンスを追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="6abec-146">Now you're ready to add modern experiences that light up when users run your application on Windows 10.</span></span> <span data-ttu-id="6abec-147">次の設計フローを使用します。</span><span class="sxs-lookup"><span data-stu-id="6abec-147">Use this design flow.</span></span>

<span data-ttu-id="6abec-148">:white_check_mark: **追加するエクスペリエンスを最初に決定する**</span><span class="sxs-lookup"><span data-stu-id="6abec-148">:white_check_mark: **First, decide what experiences you want to add**</span></span>

<span data-ttu-id="6abec-149">選択肢はたくさんあります。</span><span class="sxs-lookup"><span data-stu-id="6abec-149">There's lots to choose from.</span></span> <span data-ttu-id="6abec-150">たとえば、収益化 API を使用して発注フローを簡略化できます。また、ユーザーが投稿した新しい写真など共有すべき興味深いコンテンツがある場合に、アプリに注目を促すことができます。</span><span class="sxs-lookup"><span data-stu-id="6abec-150">For example, you can simplify your purchase order flow by using monetization APIs, or direct attention to your app when you have something interesting to share, such as a new picture that another user has posted.</span></span>

![トースト](images/desktop-to-uwp/toast.png)

<span data-ttu-id="6abec-152">ユーザーがメッセージを無視したり、非表示にした場合でも、ユーザーはアクション センターで再度メッセージを表示し、クリックすることで、アプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="6abec-152">Even if users ignore or dismiss your message, they can see it again in the action center, and then click on the message to open your app.</span></span> <span data-ttu-id="6abec-153">このようにすると、アプリの利用度が高まります。さらに、アプリが OS と密接に統合されているように見えるというメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="6abec-153">This increases engagement with your app and has the added bonus of making your app appear deeply integrated with the operating system.</span></span> <span data-ttu-id="6abec-154">このエクスペリエンスのコードについては、少し後で紹介します。</span><span class="sxs-lookup"><span data-stu-id="6abec-154">We'll show you the code for that experience a bit later.</span></span>

<span data-ttu-id="6abec-155">さまざまなアイデアを[デベロッパー センター](https://developer.microsoft.com/windows)で参照してください。</span><span class="sxs-lookup"><span data-stu-id="6abec-155">Visit our [developer center](https://developer.microsoft.com/windows) for ideas.</span></span>

<span data-ttu-id="6abec-156">:white_check_mark: **強化するのか、拡張するのかを決定する**</span><span class="sxs-lookup"><span data-stu-id="6abec-156">:white_check_mark: **Decide whether to enhance or extend**</span></span>

<span data-ttu-id="6abec-157">マイクロソフトでは「強化」と「拡張」という用語をよく使用しています。ここで、少し時間を使って、それぞれの用語が厳密にどのような意味なのかを説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="6abec-157">You'll often hear us use the terms "enhance" and "extend" so we'll take a moment to explain exactly what each of these terms mean.</span></span>

<span data-ttu-id="6abec-158">「強化」という用語は、デスクトップ アプリケーションから直接呼び出せる UWP API を説明する場合に使用しています。</span><span class="sxs-lookup"><span data-stu-id="6abec-158">We use the term "enhance" to describe UWP APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="6abec-159">Windows 10 エクスペリエンスを選択した場合、エクスペリエンスの作成に必要な API を特定して、その API がこの[一覧](desktop-to-uwp-supported-api.md)にあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6abec-159">When you've chosen a Windows 10 experience, identify the APIs that you need to create it, and then see if that API appears in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="6abec-160">これは、デスクトップ アプリケーションから直接呼び出せる API の一覧です。</span><span class="sxs-lookup"><span data-stu-id="6abec-160">This is a list of APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="6abec-161">API がこの一覧に表示されていない場合、その API に関連付けられている機能が UWP プロセス内でしか実行できないことが理由です。</span><span class="sxs-lookup"><span data-stu-id="6abec-161">If your API does not appear in this list, that's because the functionality associated with that API can run only within a UWP process.</span></span> <span data-ttu-id="6abec-162">多くの場合、そのような API は、UWP マップ コントロールや Windows Hello のセキュリティの確認など、最新の UI を表示する機能があります。</span><span class="sxs-lookup"><span data-stu-id="6abec-162">Often times, these include APIs that show modern UIs such as a UWP map control or a Windows Hello security prompt.</span></span>

<span data-ttu-id="6abec-163">しかし、このようなエクスペリエンスをアプリケーションに含める場合は、ソリューションに UWP プロジェクトを追加して、アプリケーションを「拡張」するようにします。</span><span class="sxs-lookup"><span data-stu-id="6abec-163">That said, if you want to include those experiences in your application, just "extend" the application by adding a UWP project to your solution.</span></span> <span data-ttu-id="6abec-164">デスクトップ プロジェクトがアプリケーションのエントリ ポイントであることに変わりはありませんが、UWP プロジェクトを追加することで、この[一覧](desktop-to-uwp-supported-api.md)にないすべての API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="6abec-164">The desktop project is still the entry point of your application, but the UWP project gives you access to all of the APIs that do not appear in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="6abec-165">デスクトップ アプリケーションは、アプリ サービスを利用して UWP プロセスと通信できます。そのセットアップ方法については、多数のガイダンスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6abec-165">The desktop application can communicate with the UWP process by using a an app service and we have lots of guidance on how to set that up.</span></span> <span data-ttu-id="6abec-166">UWP プロジェクトが必要なエクスペリエンスを追加するには、「[UWP による拡張](desktop-to-uwp-extend.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6abec-166">If you want to add an experience that requires a UWP project, see [Extend with UWP](desktop-to-uwp-extend.md).</span></span>

<span data-ttu-id="6abec-167">:white_check_mark: **API コントラクトを参照する**</span><span class="sxs-lookup"><span data-stu-id="6abec-167">:white_check_mark: **Reference API contracts**</span></span>

<span data-ttu-id="6abec-168">デスクトップ アプリケーションから API を直接呼び出せる場合は、ブラウザーを開き、その API のリファレンス トピックを検索します。</span><span class="sxs-lookup"><span data-stu-id="6abec-168">If you can call the API directly from your desktop application, open a browser and search for the reference topic for that API.</span></span>
<span data-ttu-id="6abec-169">API の概要の下に、その API の API コントラクトを説明する表があります。</span><span class="sxs-lookup"><span data-stu-id="6abec-169">Beneath the summary of the API, you'll find a table that describes the API contract for that API.</span></span> <span data-ttu-id="6abec-170">以下に表の例を示します。</span><span class="sxs-lookup"><span data-stu-id="6abec-170">Here's an example of that table:</span></span>

![API コントラクト表](images/desktop-to-uwp/contract-table.png)

<span data-ttu-id="6abec-172">.NET ベースのデスクトップ アプリの場合、その API コントラクトへの参照を追加します。その後、そのファイルの **[ローカルにコピー]** プロパティを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="6abec-172">If you have a .NET-based desktop app, add a reference to that API contract, and then set the **Copy Local** property of that file to **False**.</span></span> <span data-ttu-id="6abec-173">C++ ベースのプロジェクトの場合、**[追加のインクルード ディレクトリ]** に、このコントラクトを含むフォルダーのパスを追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-173">If you have a C++-based project, add to your **Additional Include Directories**, a path to the folder that contains this contract.</span></span>

<span data-ttu-id="6abec-174">:white_check_mark: **エクスペリエンスを追加するための API を呼び出す**</span><span class="sxs-lookup"><span data-stu-id="6abec-174">:white_check_mark: **Call the APIs to add your experience**</span></span>

<span data-ttu-id="6abec-175">以下に、前述の通知ウィンドウの表示に使用するコードを示します。</span><span class="sxs-lookup"><span data-stu-id="6abec-175">Here's the code that you'd use to show the notification window that we looked at earlier.</span></span> <span data-ttu-id="6abec-176">これらの API はこの[一覧](desktop-to-uwp-supported-api.md)にあるため、このコードをデスクトップ アプリケーションに追加してすぐに実行できます。</span><span class="sxs-lookup"><span data-stu-id="6abec-176">These APIs appear in this [list](desktop-to-uwp-supported-api.md) so you can add this code to your desktop application and run it right now.</span></span>

```csharp
using Windows.Foundation;
using Windows.System;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
...

private void ShowToast()
{
    string title = "featured picture of the day";
    string content = "beautiful scenery";
    string image = "https://unsplash.it/360/180?image=104";
    string logo = "https://unsplash.it/64?image=883";

    string xmlString =
    $@"<toast><visual>
       <binding template='ToastGeneric'>
       <text>{title}</text>
       <text>{content}</text>
       <image src='{image}'/>
       <image src='{logo}' placement='appLogoOverride' hint-crop='circle'/>
       </binding>
      </visual></toast>";

    XmlDocument toastXml = new XmlDocument();
    toastXml.LoadXml(xmlString);

    ToastNotification toast = new ToastNotification(toastXml);

    ToastNotificationManager.CreateToastNotifier().Show(toast);
}
```

```C++
using namespace Windows::Foundation;
using namespace Windows::System;
using namespace Windows::UI::Notifications;
using namespace Windows::Data::Xml::Dom;

void UWP::ShowToast()
{
    Platform::String ^title = "featured picture of the day";
    Platform::String ^content = "beautiful scenery";
    Platform::String ^image = "https://unsplash.it/360/180?image=104";
    Platform::String ^logo = "https://unsplash.it/64?image=883";

    Platform::String ^xmlString =
        L"<toast><visual><binding template='ToastGeneric'>" +
        L"<text>" + title + "</text>" +
        L"<text>"+ content + "</text>" +
        L"<image src='" + image + "'/>" +
        L"<image src='" + logo + "'" +
        L" placement='appLogoOverride' hint-crop='circle'/>" +
        L"</binding></visual></toast>";

    XmlDocument ^toastXml = ref new XmlDocument();

    toastXml->LoadXml(xmlString);

    ToastNotificationManager::CreateToastNotifier()->Show(ref new ToastNotification(toastXml));
}
```
<span data-ttu-id="6abec-177">通知の詳細については、「[アダプティブ トースト通知と対話型トースト通知](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6abec-177">To learn more about notifications, see [Adaptive and Interactive toast notifications](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts).</span></span>

## <a name="support-windows-xp-windows-vista-and-windows-78-install-bases"></a><span data-ttu-id="6abec-178">Windows XP、Windows Vista、および Windows 7/8 インストール ベースのサポート</span><span class="sxs-lookup"><span data-stu-id="6abec-178">Support Windows XP, Windows Vista, and Windows 7/8 install bases</span></span>

<span data-ttu-id="6abec-179">新しいブランチを作成して個別のコード ベースを保守しなくても、Windows 10 向けにアプリを現代化できます。</span><span class="sxs-lookup"><span data-stu-id="6abec-179">You can modernize your app for Windows 10 without having to create a new branch and maintain separate code bases.</span></span>

<span data-ttu-id="6abec-180">Windows 10 ユーザー向けに個別のバイナリをビルドする場合は、条件付きコンパイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="6abec-180">If you want to build separate binaries for Windows 10 users, use conditional compilation.</span></span> <span data-ttu-id="6abec-181">すべての Windows ユーザーに対して 1 組のバイナリをビルドして展開する場合は、ランタイム チェックを使用します。</span><span class="sxs-lookup"><span data-stu-id="6abec-181">If you'd prefer to build one set of binaries that you deploy to all Windows users, use runtime checks.</span></span>

<span data-ttu-id="6abec-182">各オプションを簡単に見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="6abec-182">Let's take a quick look at each option.</span></span>

### <a name="conditional-compilation"></a><span data-ttu-id="6abec-183">条件付きコンパイル</span><span class="sxs-lookup"><span data-stu-id="6abec-183">Conditional compilation</span></span>

<span data-ttu-id="6abec-184">1 つのコードベースを維持して、Windows 10 ユーザー向けだけに一連のバイナリをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="6abec-184">You can keep one code base and compile a set of binaries just for Windows 10 users.</span></span>

<span data-ttu-id="6abec-185">最初に、新しいビルド構成をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-185">First, add a new build configuration to your project.</span></span>

![ビルド構成](images/desktop-to-uwp/build-config.png)

<span data-ttu-id="6abec-187">このビルド構成に対して、UWP API を呼び出すコードを識別する定数を作成します。</span><span class="sxs-lookup"><span data-stu-id="6abec-187">For that build configuration, create a constant that to identify code that calls UWP APIs.</span></span>  

<span data-ttu-id="6abec-188">.NET ベースのプロジェクトの場合、この定数は**条件付きコンパイル定数**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6abec-188">For .NET-based projects, the constant is called a **Conditional Compilation Constant**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/compilation-constants.png)

<span data-ttu-id="6abec-190">C++ ベースのプロジェクトの場合、この定数は**プリプロセッサ定義**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6abec-190">For C++-based projects, the constant is called a **Preprocessor Definition**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/pre-processor.png)

<span data-ttu-id="6abec-192">この定数を、任意の UWP コードのブロックの前に追加します。</span><span class="sxs-lookup"><span data-stu-id="6abec-192">Add that constant before any block of UWP code.</span></span>

```csharp

[System.Diagnostics.Conditional("_UWP")]
private void ShowToast()
{
 ...
}

```

```C++

#if _UWP
void UWP::ShowToast()
{
 ...
}
#endif

```

<span data-ttu-id="6abec-193">この定数がアクティブなビルド構成で定義されている場合のみ、コンパイラでこのコードがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="6abec-193">The compiler builds that code only if that constant is defined in your active build configuration.</span></span>

### <a name="runtime-checks"></a><span data-ttu-id="6abec-194">ランタイム チェック</span><span class="sxs-lookup"><span data-stu-id="6abec-194">Runtime checks</span></span>

<span data-ttu-id="6abec-195">ユーザーが実行する Windows のバージョンに関係なく、1 組のバイナリをすべての Windows ユーザー向けにコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="6abec-195">You can compile one set of binaries for all of your Windows users regardless of which version of Windows they run.</span></span> <span data-ttu-id="6abec-196">ユーザーが Windows 10 でパッケージ アプリとしてアプリを実行した場合にのみ、アプリで UWP API が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6abec-196">Your app calls UWP APIs only if the user is runs your app as a packaged app on Windows 10.</span></span>

<span data-ttu-id="6abec-197">コードにランタイム チェックを追加する最も簡単な方法は、[Desktop Bridge Helpers](https://www.nuget.org/packages/DesktopBridge.Helpers/) という Nuget パッケージをインストールしてから、``IsRunningAsUWP()`` メソッドを使用して、すべての UWP コードを利用することです。</span><span class="sxs-lookup"><span data-stu-id="6abec-197">The easiest way to add runtime checks to your code is to install this Nuget package: [Desktop Bridge Helpers](https://www.nuget.org/packages/DesktopBridge.Helpers/) and then use the ``IsRunningAsUWP()`` method to gate off all UWP code.</span></span> <span data-ttu-id="6abec-198">詳細については、[デスクトップ ブリッジを使用したアプリケーションのコンテキストの特定](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/)に関するブログ記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6abec-198">see this blog post for more details: [Desktop Bridge - Identify the application's context](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/).</span></span>

## <a name="related-video"></a><span data-ttu-id="6abec-199">関連ビデオ</span><span class="sxs-lookup"><span data-stu-id="6abec-199">Related Video</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Use-UWP-APIs-in-Your-Code-3d78c6WhD_9506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="related-samples"></a><span data-ttu-id="6abec-200">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="6abec-200">Related Samples</span></span>

* [<span data-ttu-id="6abec-201">Hello World サンプル</span><span class="sxs-lookup"><span data-stu-id="6abec-201">Hello World Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/HelloWorldSample)
* [<span data-ttu-id="6abec-202">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="6abec-202">Secondary Tile</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SecondaryTileSample)
* [<span data-ttu-id="6abec-203">ストア API サンプル</span><span class="sxs-lookup"><span data-stu-id="6abec-203">Store API Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/StoreSample)
* [<span data-ttu-id="6abec-204">UWP UpdateTask を実装する WinForms アプリ</span><span class="sxs-lookup"><span data-stu-id="6abec-204">WinForms app that implements a UWP UpdateTask</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinFormsUpdateTaskSample)
* [<span data-ttu-id="6abec-205">デスクトップ アプリから UWP へのブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="6abec-205">Desktop app bridge to UWP Samples</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)


## <a name="support-and-feedback"></a><span data-ttu-id="6abec-206">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="6abec-206">Support and feedback</span></span>

**<span data-ttu-id="6abec-207">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="6abec-207">Find answers to specific questions</span></span>**

<span data-ttu-id="6abec-208">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="6abec-208">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="6abec-209">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="6abec-209">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="6abec-210">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6abec-210">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial)</span></span>

**<span data-ttu-id="6abec-211">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="6abec-211">Give feedback about this article</span></span>**

<span data-ttu-id="6abec-212">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="6abec-212">Use the comments section below.</span></span>
