---
author: normesta
Description: Enhance your desktop application for Windows 10 users by using Universal Windows Platform (UWP) APIs.
Search.Product: eADQiWindows 10XVcnh
title: Windows 10 向けのデスクトップ アプリを強化する
ms.author: normesta
ms.date: 10/15/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 5e76d3d517be73417777eb31dfc3994f92186522
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5976175"
---
# <a name="enhance-your-desktop-application-for-windows-10"></a><span data-ttu-id="2e64e-103">Windows 10 向けのデスクトップ アプリを強化する</span><span class="sxs-lookup"><span data-stu-id="2e64e-103">Enhance your desktop application for Windows 10</span></span>

<span data-ttu-id="2e64e-104">Windows ランタイム Api を使用して、Windows 10 ユーザーの利便最新のエクスペリエンスを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-104">You can use Windows Runtime APIs to add modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="2e64e-105">最初に、プロジェクトをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="2e64e-105">First, set up your project.</span></span> <span data-ttu-id="2e64e-106">次に、Windows 10 エクスペリエンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-106">Then, add Windows 10 experiences.</span></span> <span data-ttu-id="2e64e-107">Windows 10 ユーザー向けに個別にビルドすることも、実行する Windows のバージョンに関係なくすべてのユーザー向けにまったく同じバイナリを配布することもできます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-107">You can build separately for Windows 10 users or distribute the same exact binaries to all users regardless of which version of Windows they run.</span></span>

## <a name="first-set-up-your-project"></a><span data-ttu-id="2e64e-108">最初に、プロジェクトをセットアップする</span><span class="sxs-lookup"><span data-stu-id="2e64e-108">First, set up your project</span></span>

<span data-ttu-id="2e64e-109">UWP API を使用するには、プロジェクトにいくつかの変更を加える必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e64e-109">You'll have to make a few changes to your project to use UWP APIs.</span></span>

### <a name="modify-a-net-project-to-use-windows-runtime-apis"></a><span data-ttu-id="2e64e-110">Windows ランタイム Api を使用する .NET プロジェクトを変更します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-110">Modify a .NET project to use Windows Runtime APIs</span></span>

<span data-ttu-id="2e64e-111">**[参照マネージャー]** ダイアログ ボックスを開き、**[参照]** ボタンを選択して、**[すべてのファイル]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-111">Open the **Reference Manager** dialog box, choose the **Browse** button, and then select  **All Files**.</span></span>

![[参照の追加] ダイアログ ボックス](images/desktop-to-uwp/browse-references.png)

<span data-ttu-id="2e64e-113">次に、これらのファイルへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-113">Then, add a reference to these files.</span></span>

|<span data-ttu-id="2e64e-114">ファイル</span><span class="sxs-lookup"><span data-stu-id="2e64e-114">File</span></span>|<span data-ttu-id="2e64e-115">場所</span><span class="sxs-lookup"><span data-stu-id="2e64e-115">Location</span></span>|
|--|--|
|<span data-ttu-id="2e64e-116">System.Runtime.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="2e64e-116">System.Runtime.WindowsRuntime</span></span>|<span data-ttu-id="2e64e-117">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="2e64e-117">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="2e64e-118">System.Runtime.WindowsRuntime.UI.Xaml</span><span class="sxs-lookup"><span data-stu-id="2e64e-118">System.Runtime.WindowsRuntime.UI.Xaml</span></span>|<span data-ttu-id="2e64e-119">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="2e64e-119">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="2e64e-120">System.Runtime.InteropServices.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="2e64e-120">System.Runtime.InteropServices.WindowsRuntime</span></span>|<span data-ttu-id="2e64e-121">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span><span class="sxs-lookup"><span data-stu-id="2e64e-121">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\\.NETCore\v4.5</span></span>|
|<span data-ttu-id="2e64e-122">Windows.winmd</span><span class="sxs-lookup"><span data-stu-id="2e64e-122">Windows.winmd</span></span>|<span data-ttu-id="2e64e-123">C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Facade</span><span class="sxs-lookup"><span data-stu-id="2e64e-123">C:\Program Files (x86)\Windows Kits\10\UnionMetadata\Facade</span></span>|
|<span data-ttu-id="2e64e-124">Windows.Foundation.UniversalApiContract.winmd</span><span class="sxs-lookup"><span data-stu-id="2e64e-124">Windows.Foundation.UniversalApiContract.winmd</span></span>|<span data-ttu-id="2e64e-125">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="2e64e-125">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span></span>|
|<span data-ttu-id="2e64e-126">Windows.Foundation.FoundationContract.winmd</span><span class="sxs-lookup"><span data-stu-id="2e64e-126">Windows.Foundation.FoundationContract.winmd</span></span>|<span data-ttu-id="2e64e-127">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="2e64e-127">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span></span>|

<span data-ttu-id="2e64e-128">**[プロパティ]** ウィンドウで、各 *.winmd* ファイルの **[ローカルにコピー]** フィールドを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-128">In the **Properties** window, set the **Copy Local** field of each *.winmd* file to **False**.</span></span>

![[ローカルにコピー] フィールド](images/desktop-to-uwp/copy-local-field.png)

### <a name="modify-a-c-project-to-use-windows-runtime-apis"></a><span data-ttu-id="2e64e-130">Windows ランタイム Api を使用する C++ プロジェクトを変更します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-130">Modify a C++ project to use Windows Runtime APIs</span></span>

<span data-ttu-id="2e64e-131">使用[、C++/WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/)を Windows ランタイム Api を利用します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-131">Use [C++/WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/) to consume Windows Runtime APIs.</span></span> <span data-ttu-id="2e64e-132">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="2e64e-132">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span>

<span data-ttu-id="2e64e-133">C++ プロジェクトを構成する/WinRT、」をご覧ください[を追加するには、C++ の Windows デスクトップ アプリケーション プロジェクトを変更する/WinRT サポート](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-133">To configure your project for C++/WinRT, See [Modify a Windows Desktop application project to add C++/WinRT support](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

## <a name="add-windows-10-experiences"></a><span data-ttu-id="2e64e-134">Windows 10 エクスペリエンスの追加</span><span class="sxs-lookup"><span data-stu-id="2e64e-134">Add Windows 10 experiences</span></span>

<span data-ttu-id="2e64e-135">これで、Windows 10 でアプリケーションをユーザーが実行する際に便利になる最新のエクスペリエンスを追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="2e64e-135">Now you're ready to add modern experiences that light up when users run your application on Windows 10.</span></span> <span data-ttu-id="2e64e-136">次の設計フローを使用します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-136">Use this design flow.</span></span>

<span data-ttu-id="2e64e-137">:white_check_mark: **追加するエクスペリエンスを最初に決定する**</span><span class="sxs-lookup"><span data-stu-id="2e64e-137">:white_check_mark: **First, decide what experiences you want to add**</span></span>

<span data-ttu-id="2e64e-138">選択肢はたくさんあります。</span><span class="sxs-lookup"><span data-stu-id="2e64e-138">There's lots to choose from.</span></span> <span data-ttu-id="2e64e-139">たとえば、別のユーザーが投稿した新しい写真など共有に関心のあるものがある場合は、収益化 Api をまたはアプリケーションに注目を使用して、発注フローを簡略化できます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-139">For example, you can simplify your purchase order flow by using monetization APIs, or direct attention to your application when you have something interesting to share, such as a new picture that another user has posted.</span></span>

![トースト](images/desktop-to-uwp/toast.png)

<span data-ttu-id="2e64e-141">ユーザーがメッセージを無視したり、非表示にした場合でも、ユーザーはアクション センターで再度メッセージを表示し、クリックすることで、アプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-141">Even if users ignore or dismiss your message, they can see it again in the action center, and then click on the message to open your app.</span></span> <span data-ttu-id="2e64e-142">これにより、アプリケーションとのエンゲージメントを向上し、オペレーティング システムと密接に統合表示されるアプリケーションの特典が。</span><span class="sxs-lookup"><span data-stu-id="2e64e-142">This increases engagement with your application and has the added bonus of making your application appear deeply integrated with the operating system.</span></span> <span data-ttu-id="2e64e-143">このエクスペリエンスのコードについては、少し後で紹介します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-143">We'll show you the code for that experience a bit later.</span></span>

<span data-ttu-id="2e64e-144">さまざまなアイデアを[デベロッパー センター](https://developer.microsoft.com/windows)で参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-144">Visit our [developer center](https://developer.microsoft.com/windows) for ideas.</span></span>

<span data-ttu-id="2e64e-145">:white_check_mark: **強化するのか、拡張するのかを決定する**</span><span class="sxs-lookup"><span data-stu-id="2e64e-145">:white_check_mark: **Decide whether to enhance or extend**</span></span>

<span data-ttu-id="2e64e-146">マイクロソフトでは「強化」と「拡張」という用語をよく使用しています。ここで、少し時間を使って、それぞれの用語が厳密にどのような意味なのかを説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="2e64e-146">You'll often hear us use the terms "enhance" and "extend" so we'll take a moment to explain exactly what each of these terms mean.</span></span>

<span data-ttu-id="2e64e-147">という用語は、「強化」を使ってデスクトップ アプリケーションから直接呼び出すことができる Windows ランタイム Api について説明します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-147">We use the term "enhance" to describe Windows Runtime APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="2e64e-148">Windows 10 エクスペリエンスを選択した場合、エクスペリエンスの作成に必要な API を特定して、その API がこの[一覧](desktop-to-uwp-supported-api.md)にあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-148">When you've chosen a Windows 10 experience, identify the APIs that you need to create it, and then see if that API appears in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="2e64e-149">これは、デスクトップ アプリケーションから直接呼び出せる API の一覧です。</span><span class="sxs-lookup"><span data-stu-id="2e64e-149">This is a list of APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="2e64e-150">API がこの一覧に表示されていない場合、その API に関連付けられている機能が UWP プロセス内でしか実行できないことが理由です。</span><span class="sxs-lookup"><span data-stu-id="2e64e-150">If your API does not appear in this list, that's because the functionality associated with that API can run only within a UWP process.</span></span> <span data-ttu-id="2e64e-151">多くの場合、そのような API は、UWP マップ コントロールや Windows Hello のセキュリティの確認など、最新の UI を表示する機能があります。</span><span class="sxs-lookup"><span data-stu-id="2e64e-151">Often times, these include APIs that show modern UIs such as a UWP map control or a Windows Hello security prompt.</span></span>

<span data-ttu-id="2e64e-152">しかし、このようなエクスペリエンスをアプリケーションに含める場合は、ソリューションに UWP プロジェクトを追加して、アプリケーションを「拡張」するようにします。</span><span class="sxs-lookup"><span data-stu-id="2e64e-152">That said, if you want to include those experiences in your application, just "extend" the application by adding a UWP project to your solution.</span></span> <span data-ttu-id="2e64e-153">デスクトップ プロジェクトがアプリケーションのエントリ ポイントであることに変わりはありませんが、UWP プロジェクトを追加することで、この[一覧](desktop-to-uwp-supported-api.md)にないすべての API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-153">The desktop project is still the entry point of your application, but the UWP project gives you access to all of the APIs that do not appear in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="2e64e-154">デスクトップ アプリケーションは、アプリ サービスを利用して UWP プロセスと通信できます。そのセットアップ方法については、多数のガイダンスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="2e64e-154">The desktop application can communicate with the UWP process by using a an app service and we have lots of guidance on how to set that up.</span></span> <span data-ttu-id="2e64e-155">UWP プロジェクトが必要なエクスペリエンスを追加するには、「[UWP による拡張](desktop-to-uwp-extend.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-155">If you want to add an experience that requires a UWP project, see [Extend with UWP](desktop-to-uwp-extend.md).</span></span>

<span data-ttu-id="2e64e-156">:white_check_mark: **API コントラクトを参照する**</span><span class="sxs-lookup"><span data-stu-id="2e64e-156">:white_check_mark: **Reference API contracts**</span></span>

<span data-ttu-id="2e64e-157">デスクトップ アプリケーションから API を直接呼び出せる場合は、ブラウザーを開き、その API のリファレンス トピックを検索します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-157">If you can call the API directly from your desktop application, open a browser and search for the reference topic for that API.</span></span>
<span data-ttu-id="2e64e-158">API の概要の下に、その API の API コントラクトを説明する表があります。</span><span class="sxs-lookup"><span data-stu-id="2e64e-158">Beneath the summary of the API, you'll find a table that describes the API contract for that API.</span></span> <span data-ttu-id="2e64e-159">以下に表の例を示します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-159">Here's an example of that table:</span></span>

![API コントラクト表](images/desktop-to-uwp/contract-table.png)

<span data-ttu-id="2e64e-161">.NET ベースのデスクトップ アプリの場合、その API コントラクトへの参照を追加します。その後、そのファイルの **[ローカルにコピー]** プロパティを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-161">If you have a .NET-based desktop app, add a reference to that API contract, and then set the **Copy Local** property of that file to **False**.</span></span> <span data-ttu-id="2e64e-162">C++ ベースのプロジェクトの場合、**[追加のインクルード ディレクトリ]** に、このコントラクトを含むフォルダーのパスを追加します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-162">If you have a C++-based project, add to your **Additional Include Directories**, a path to the folder that contains this contract.</span></span>

<span data-ttu-id="2e64e-163">:white_check_mark: **エクスペリエンスを追加するための API を呼び出す**</span><span class="sxs-lookup"><span data-stu-id="2e64e-163">:white_check_mark: **Call the APIs to add your experience**</span></span>

<span data-ttu-id="2e64e-164">以下に、前述の通知ウィンドウの表示に使用するコードを示します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-164">Here's the code that you'd use to show the notification window that we looked at earlier.</span></span> <span data-ttu-id="2e64e-165">これらの API はこの[一覧](desktop-to-uwp-supported-api.md)にあるため、このコードをデスクトップ アプリケーションに追加してすぐに実行できます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-165">These APIs appear in this [list](desktop-to-uwp-supported-api.md) so you can add this code to your desktop application and run it right now.</span></span>

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
    string image = "https://picsum.photos/360/180?image=104";
    string logo = "https://picsum.photos/64?image=883";

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
    Platform::String ^image = "https://picsum.photos/360/180?image=104";
    Platform::String ^logo = "https://picsum.photos/64?image=883";

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
<span data-ttu-id="2e64e-166">通知の詳細については、「[アダプティブ トースト通知と対話型トースト通知](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/adaptive-interactive-toasts)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-166">To learn more about notifications, see [Adaptive and Interactive toast notifications](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/adaptive-interactive-toasts).</span></span>

## <a name="support-windows-xp-windows-vista-and-windows-78-install-bases"></a><span data-ttu-id="2e64e-167">Windows XP、Windows Vista、および Windows 7/8 インストール ベースのサポート</span><span class="sxs-lookup"><span data-stu-id="2e64e-167">Support Windows XP, Windows Vista, and Windows 7/8 install bases</span></span>

<span data-ttu-id="2e64e-168">新しいブランチを作成し、個別のコード ベースを保守しなくても、Windows 10 向けアプリを現代化できます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-168">You can modernize your application for Windows 10 without having to create a new branch and maintain separate code bases.</span></span>

<span data-ttu-id="2e64e-169">Windows 10 ユーザー向けに個別のバイナリをビルドする場合は、条件付きコンパイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-169">If you want to build separate binaries for Windows 10 users, use conditional compilation.</span></span> <span data-ttu-id="2e64e-170">すべての Windows ユーザーに対して 1 組のバイナリをビルドして展開する場合は、ランタイム チェックを使用します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-170">If you'd prefer to build one set of binaries that you deploy to all Windows users, use runtime checks.</span></span>

<span data-ttu-id="2e64e-171">各オプションを簡単に見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="2e64e-171">Let's take a quick look at each option.</span></span>

### <a name="conditional-compilation"></a><span data-ttu-id="2e64e-172">条件付きコンパイル</span><span class="sxs-lookup"><span data-stu-id="2e64e-172">Conditional compilation</span></span>

<span data-ttu-id="2e64e-173">1 つのコードベースを維持して、Windows 10 ユーザー向けだけに一連のバイナリをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="2e64e-173">You can keep one code base and compile a set of binaries just for Windows 10 users.</span></span>

<span data-ttu-id="2e64e-174">最初に、新しいビルド構成をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-174">First, add a new build configuration to your project.</span></span>

![ビルド構成](images/desktop-to-uwp/build-config.png)

<span data-ttu-id="2e64e-176">ビルド構成に対して、定数を作成する Windows ランタイム Api を呼び出すコードを識別します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-176">For that build configuration, create a constant that to identify code that calls Windows Runtime APIs.</span></span>  

<span data-ttu-id="2e64e-177">.NET ベースのプロジェクトの場合、この定数は**条件付きコンパイル定数**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-177">For .NET-based projects, the constant is called a **Conditional Compilation Constant**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/compilation-constants.png)

<span data-ttu-id="2e64e-179">C++ ベースのプロジェクトの場合、この定数は**プリプロセッサ定義**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-179">For C++-based projects, the constant is called a **Preprocessor Definition**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/pre-processor.png)

<span data-ttu-id="2e64e-181">この定数を、任意の UWP コードのブロックの前に追加します。</span><span class="sxs-lookup"><span data-stu-id="2e64e-181">Add that constant before any block of UWP code.</span></span>

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

<span data-ttu-id="2e64e-182">この定数がアクティブなビルド構成で定義されている場合のみ、コンパイラでこのコードがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-182">The compiler builds that code only if that constant is defined in your active build configuration.</span></span>

### <a name="runtime-checks"></a><span data-ttu-id="2e64e-183">ランタイム チェック</span><span class="sxs-lookup"><span data-stu-id="2e64e-183">Runtime checks</span></span>

<span data-ttu-id="2e64e-184">ユーザーが実行する Windows のバージョンに関係なく、1 組のバイナリをすべての Windows ユーザー向けにコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-184">You can compile one set of binaries for all of your Windows users regardless of which version of Windows they run.</span></span> <span data-ttu-id="2e64e-185">アプリケーション Windows ランタイム Api を呼び出す、ユーザーが実行される場合にのみ、アプリケーションをパッケージ化されたアプリケーションとして Windows 10 でします。</span><span class="sxs-lookup"><span data-stu-id="2e64e-185">Your application calls Windows Runtime APIs only if the user is runs your application as a packaged application on Windows 10.</span></span>

<span data-ttu-id="2e64e-186">ランタイム チェック コードを追加する最も簡単な方法は、この Nuget パッケージをインストールする: [Desktop Bridge Helpers](https://www.nuget.org/packages/DesktopBridge.Helpers/)し、使用して、``IsRunningAsUWP()``メソッドが通過しなければならない関門を Windows ランタイム Api を呼び出すコードをすべて無効にします。</span><span class="sxs-lookup"><span data-stu-id="2e64e-186">The easiest way to add runtime checks to your code is to install this Nuget package: [Desktop Bridge Helpers](https://www.nuget.org/packages/DesktopBridge.Helpers/) and then use the ``IsRunningAsUWP()`` method to gate off all code that calls Windows Runtime APIs.</span></span> <span data-ttu-id="2e64e-187">詳細については、[デスクトップ ブリッジを使用したアプリケーションのコンテキストの特定](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/)に関するブログ記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-187">see this blog post for more details: [Desktop Bridge - Identify the application's context](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/).</span></span>

## <a name="related-video"></a><span data-ttu-id="2e64e-188">関連ビデオ</span><span class="sxs-lookup"><span data-stu-id="2e64e-188">Related Video</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Use-UWP-APIs-in-Your-Code-3d78c6WhD_9506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="related-samples"></a><span data-ttu-id="2e64e-189">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="2e64e-189">Related Samples</span></span>

* [<span data-ttu-id="2e64e-190">Hello World サンプル</span><span class="sxs-lookup"><span data-stu-id="2e64e-190">Hello World Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/HelloWorldSample)
* [<span data-ttu-id="2e64e-191">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="2e64e-191">Secondary Tile</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SecondaryTileSample)
* [<span data-ttu-id="2e64e-192">ストア API サンプル</span><span class="sxs-lookup"><span data-stu-id="2e64e-192">Store API Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/StoreSample)
* [<span data-ttu-id="2e64e-193">UWP UpdateTask を実装する WinForms アプリケーション</span><span class="sxs-lookup"><span data-stu-id="2e64e-193">WinForms application that implements a UWP UpdateTask</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinFormsUpdateTaskSample)
* [<span data-ttu-id="2e64e-194">デスクトップ アプリから UWP へのブリッジのサンプル</span><span class="sxs-lookup"><span data-stu-id="2e64e-194">Desktop app bridge to UWP Samples</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)


## <a name="support-and-feedback"></a><span data-ttu-id="2e64e-195">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="2e64e-195">Support and feedback</span></span>

**<span data-ttu-id="2e64e-196">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="2e64e-196">Find answers to your questions</span></span>**

<span data-ttu-id="2e64e-197">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="2e64e-197">Have questions?</span></span> <span data-ttu-id="2e64e-198">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-198">Ask us on Stack Overflow.</span></span> <span data-ttu-id="2e64e-199">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="2e64e-199">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="2e64e-200">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="2e64e-200">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="2e64e-201">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="2e64e-201">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="2e64e-202">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2e64e-202">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
