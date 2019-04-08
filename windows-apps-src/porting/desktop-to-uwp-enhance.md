---
Description: ユニバーサル Windows プラットフォーム (UWP) Api を使用して、Windows 10 ユーザー向けのデスクトップ アプリケーションを強化します。
Search.Product: eADQiWindows 10XVcnh
title: Windows 10 向けのデスクトップ アプリを強化する
ms.date: 10/15/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 0e06de7d33604981e0055d9d57f774d280753db2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628037"
---
# <a name="enhance-your-desktop-application-for-windows-10"></a><span data-ttu-id="62b90-104">Windows 10 向けのデスクトップ アプリを強化する</span><span class="sxs-lookup"><span data-stu-id="62b90-104">Enhance your desktop application for Windows 10</span></span>

<span data-ttu-id="62b90-105">Windows ランタイム Api を使用して、Windows 10 ユーザー向けに磨きをかける最新のエクスペリエンスを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="62b90-105">You can use Windows Runtime APIs to add modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="62b90-106">最初に、プロジェクトをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="62b90-106">First, set up your project.</span></span> <span data-ttu-id="62b90-107">次に、Windows 10 エクスペリエンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="62b90-107">Then, add Windows 10 experiences.</span></span> <span data-ttu-id="62b90-108">Windows 10 ユーザー向けに個別にビルドすることも、実行する Windows のバージョンに関係なくすべてのユーザー向けにまったく同じバイナリを配布することもできます。</span><span class="sxs-lookup"><span data-stu-id="62b90-108">You can build separately for Windows 10 users or distribute the same exact binaries to all users regardless of which version of Windows they run.</span></span>

## <a name="first-set-up-your-project"></a><span data-ttu-id="62b90-109">最初に、プロジェクトをセットアップする</span><span class="sxs-lookup"><span data-stu-id="62b90-109">First, set up your project</span></span>

<span data-ttu-id="62b90-110">UWP API を使用するには、プロジェクトにいくつかの変更を加える必要があります。</span><span class="sxs-lookup"><span data-stu-id="62b90-110">You'll have to make a few changes to your project to use UWP APIs.</span></span>

### <a name="modify-a-net-project-to-use-windows-runtime-apis"></a><span data-ttu-id="62b90-111">Windows ランタイム Api を使用する .NET プロジェクトを変更します。</span><span class="sxs-lookup"><span data-stu-id="62b90-111">Modify a .NET project to use Windows Runtime APIs</span></span>

<span data-ttu-id="62b90-112">**[参照マネージャー]** ダイアログ ボックスを開き、**[参照]** ボタンを選択して、**[すべてのファイル]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="62b90-112">Open the **Reference Manager** dialog box, choose the **Browse** button, and then select  **All Files**.</span></span>

![[参照の追加] ダイアログ ボックス](images/desktop-to-uwp/browse-references.png)

<span data-ttu-id="62b90-114">次に、これらのファイルへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="62b90-114">Then, add a reference to these files.</span></span>

|<span data-ttu-id="62b90-115">ファイル</span><span class="sxs-lookup"><span data-stu-id="62b90-115">File</span></span>|<span data-ttu-id="62b90-116">Location</span><span class="sxs-lookup"><span data-stu-id="62b90-116">Location</span></span>|
|--|--|
|<span data-ttu-id="62b90-117">System.Runtime.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="62b90-117">System.Runtime.WindowsRuntime</span></span>|<span data-ttu-id="62b90-118">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span><span class="sxs-lookup"><span data-stu-id="62b90-118">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span></span>|
|<span data-ttu-id="62b90-119">System.Runtime.WindowsRuntime.UI.Xaml</span><span class="sxs-lookup"><span data-stu-id="62b90-119">System.Runtime.WindowsRuntime.UI.Xaml</span></span>|<span data-ttu-id="62b90-120">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span><span class="sxs-lookup"><span data-stu-id="62b90-120">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span></span>|
|<span data-ttu-id="62b90-121">System.Runtime.InteropServices.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="62b90-121">System.Runtime.InteropServices.WindowsRuntime</span></span>|<span data-ttu-id="62b90-122">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span><span class="sxs-lookup"><span data-stu-id="62b90-122">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span></span>|
|<span data-ttu-id="62b90-123">Windows.Foundation.UniversalApiContract.winmd</span><span class="sxs-lookup"><span data-stu-id="62b90-123">Windows.Foundation.UniversalApiContract.winmd</span></span>|<span data-ttu-id="62b90-124">C:\Program Files (x86) \Windows Kits\10\References\<*sdk バージョン*> \Windows.Foundation.UniversalApiContract\<*バージョン*></span><span class="sxs-lookup"><span data-stu-id="62b90-124">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span></span>|
|<span data-ttu-id="62b90-125">Windows.Foundation.FoundationContract.winmd</span><span class="sxs-lookup"><span data-stu-id="62b90-125">Windows.Foundation.FoundationContract.winmd</span></span>|<span data-ttu-id="62b90-126">C:\Program Files (x86) \Windows Kits\10\References\<*sdk バージョン*> \Windows.Foundation.FoundationContract\<*バージョン*></span><span class="sxs-lookup"><span data-stu-id="62b90-126">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span></span>|

<span data-ttu-id="62b90-127">**[プロパティ]** ウィンドウで、各 *.winmd* ファイルの **[ローカルにコピー]** フィールドを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="62b90-127">In the **Properties** window, set the **Copy Local** field of each *.winmd* file to **False**.</span></span>

![[ローカルにコピー] フィールド](images/desktop-to-uwp/copy-local-field.png)

### <a name="modify-a-c-project-to-use-windows-runtime-apis"></a><span data-ttu-id="62b90-129">Windows ランタイム Api を使用する C++ プロジェクトを変更します。</span><span class="sxs-lookup"><span data-stu-id="62b90-129">Modify a C++ project to use Windows Runtime APIs</span></span>

<span data-ttu-id="62b90-130">使用[C +/cli WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/) Windows ランタイム Api を使用します。</span><span class="sxs-lookup"><span data-stu-id="62b90-130">Use [C++/WinRT](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/) to consume Windows Runtime APIs.</span></span> <span data-ttu-id="62b90-131">C++/WinRT は Windows ランタイム (WinRT) API の標準的な最新の C++17 言語プロジェクションで、ヘッダー ファイル ベースのライブラリとして実装され、最新の Windows API への最上位アクセス権を提供するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="62b90-131">C++/WinRT is an entirely standard modern C++17 language projection for Windows Runtime (WinRT) APIs, implemented as a header-file-based library, and designed to provide you with first-class access to the modern Windows API.</span></span>

<span data-ttu-id="62b90-132">C++ プロジェクトを構成する/cli WinRT を参照してください[C + を追加する Windows デスクトップ アプリケーション プロジェクトを変更する/cli WinRT サポート](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support)します。</span><span class="sxs-lookup"><span data-stu-id="62b90-132">To configure your project for C++/WinRT, See [Modify a Windows Desktop application project to add C++/WinRT support](https://docs.microsoft.com/windows/uwp/cpp-and-winrt-apis/get-started#modify-a-windows-desktop-application-project-to-add-cwinrt-support).</span></span>

## <a name="add-windows-10-experiences"></a><span data-ttu-id="62b90-133">Windows 10 エクスペリエンスの追加</span><span class="sxs-lookup"><span data-stu-id="62b90-133">Add Windows 10 experiences</span></span>

<span data-ttu-id="62b90-134">これで、Windows 10 でアプリケーションをユーザーが実行する際に便利になる最新のエクスペリエンスを追加する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="62b90-134">Now you're ready to add modern experiences that light up when users run your application on Windows 10.</span></span> <span data-ttu-id="62b90-135">次の設計フローを使用します。</span><span class="sxs-lookup"><span data-stu-id="62b90-135">Use this design flow.</span></span>

<span data-ttu-id="62b90-136">:white_check_mark:**最初に、追加するどのようなエクスペリエンスを決定します。**</span><span class="sxs-lookup"><span data-stu-id="62b90-136">:white_check_mark: **First, decide what experiences you want to add**</span></span>

<span data-ttu-id="62b90-137">選択肢はたくさんあります。</span><span class="sxs-lookup"><span data-stu-id="62b90-137">There's lots to choose from.</span></span> <span data-ttu-id="62b90-138">たとえば、収益化 Api、またはアプリケーションに直接の注意を別のユーザーが投稿する新しい画像などを共有するには興味深いものがある場合を使用して、購買注文の流れを簡略化できます。</span><span class="sxs-lookup"><span data-stu-id="62b90-138">For example, you can simplify your purchase order flow by using monetization APIs, or direct attention to your application when you have something interesting to share, such as a new picture that another user has posted.</span></span>

![トースト](images/desktop-to-uwp/toast.png)

<span data-ttu-id="62b90-140">ユーザーがメッセージを無視したり、非表示にした場合でも、ユーザーはアクション センターで再度メッセージを表示し、クリックすることで、アプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="62b90-140">Even if users ignore or dismiss your message, they can see it again in the action center, and then click on the message to open your app.</span></span> <span data-ttu-id="62b90-141">これにより、アプリケーションで engagement を向上し、アプリケーションをオペレーティング システムに深く統合表示の追加されたボーナスが。</span><span class="sxs-lookup"><span data-stu-id="62b90-141">This increases engagement with your application and has the added bonus of making your application appear deeply integrated with the operating system.</span></span> <span data-ttu-id="62b90-142">このエクスペリエンスのコードについては、少し後で紹介します。</span><span class="sxs-lookup"><span data-stu-id="62b90-142">We'll show you the code for that experience a bit later.</span></span>

<span data-ttu-id="62b90-143">さまざまなアイデアを[デベロッパー センター](https://developer.microsoft.com/windows)で参照してください。</span><span class="sxs-lookup"><span data-stu-id="62b90-143">Visit our [developer center](https://developer.microsoft.com/windows) for ideas.</span></span>

<span data-ttu-id="62b90-144">:white_check_mark:**強化または拡張するかどうかを決定します。**</span><span class="sxs-lookup"><span data-stu-id="62b90-144">:white_check_mark: **Decide whether to enhance or extend**</span></span>

<span data-ttu-id="62b90-145">マイクロソフトでは「強化」と「拡張」という用語をよく使用しています。ここで、少し時間を使って、それぞれの用語が厳密にどのような意味なのかを説明しましょう。</span><span class="sxs-lookup"><span data-stu-id="62b90-145">You'll often hear us use the terms "enhance" and "extend" so we'll take a moment to explain exactly what each of these terms mean.</span></span>

<span data-ttu-id="62b90-146">使用して、用語「拡張」デスクトップ アプリケーションから直接呼び出すことができる Windows ランタイム Api について説明します。</span><span class="sxs-lookup"><span data-stu-id="62b90-146">We use the term "enhance" to describe Windows Runtime APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="62b90-147">Windows 10 エクスペリエンスを選択した場合、エクスペリエンスの作成に必要な API を特定して、その API がこの[一覧](desktop-to-uwp-supported-api.md)にあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="62b90-147">When you've chosen a Windows 10 experience, identify the APIs that you need to create it, and then see if that API appears in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="62b90-148">これは、デスクトップ アプリケーションから直接呼び出せる API の一覧です。</span><span class="sxs-lookup"><span data-stu-id="62b90-148">This is a list of APIs that you can call directly from your desktop application.</span></span> <span data-ttu-id="62b90-149">API がこの一覧に表示されていない場合、その API に関連付けられている機能が UWP プロセス内でしか実行できないことが理由です。</span><span class="sxs-lookup"><span data-stu-id="62b90-149">If your API does not appear in this list, that's because the functionality associated with that API can run only within a UWP process.</span></span> <span data-ttu-id="62b90-150">多くの場合、そのような API は、UWP マップ コントロールや Windows Hello のセキュリティの確認など、最新の UI を表示する機能があります。</span><span class="sxs-lookup"><span data-stu-id="62b90-150">Often times, these include APIs that show modern UIs such as a UWP map control or a Windows Hello security prompt.</span></span>

<span data-ttu-id="62b90-151">しかし、このようなエクスペリエンスをアプリケーションに含める場合は、ソリューションに UWP プロジェクトを追加して、アプリケーションを「拡張」するようにします。</span><span class="sxs-lookup"><span data-stu-id="62b90-151">That said, if you want to include those experiences in your application, just "extend" the application by adding a UWP project to your solution.</span></span> <span data-ttu-id="62b90-152">デスクトップ プロジェクトがアプリケーションのエントリ ポイントであることに変わりはありませんが、UWP プロジェクトを追加することで、この[一覧](desktop-to-uwp-supported-api.md)にないすべての API を利用できます。</span><span class="sxs-lookup"><span data-stu-id="62b90-152">The desktop project is still the entry point of your application, but the UWP project gives you access to all of the APIs that do not appear in this [list](desktop-to-uwp-supported-api.md).</span></span> <span data-ttu-id="62b90-153">デスクトップ アプリケーションは、アプリ サービスを利用して UWP プロセスと通信できます。そのセットアップ方法については、多数のガイダンスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="62b90-153">The desktop application can communicate with the UWP process by using a an app service and we have lots of guidance on how to set that up.</span></span> <span data-ttu-id="62b90-154">UWP プロジェクトが必要なエクスペリエンスを追加するには、「[UWP による拡張](desktop-to-uwp-extend.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62b90-154">If you want to add an experience that requires a UWP project, see [Extend with UWP](desktop-to-uwp-extend.md).</span></span>

<span data-ttu-id="62b90-155">:white_check_mark:**参照 API コントラクト**</span><span class="sxs-lookup"><span data-stu-id="62b90-155">:white_check_mark: **Reference API contracts**</span></span>

<span data-ttu-id="62b90-156">デスクトップ アプリケーションから API を直接呼び出せる場合は、ブラウザーを開き、その API のリファレンス トピックを検索します。</span><span class="sxs-lookup"><span data-stu-id="62b90-156">If you can call the API directly from your desktop application, open a browser and search for the reference topic for that API.</span></span>
<span data-ttu-id="62b90-157">API の概要の下に、その API の API コントラクトを説明する表があります。</span><span class="sxs-lookup"><span data-stu-id="62b90-157">Beneath the summary of the API, you'll find a table that describes the API contract for that API.</span></span> <span data-ttu-id="62b90-158">以下に表の例を示します。</span><span class="sxs-lookup"><span data-stu-id="62b90-158">Here's an example of that table:</span></span>

![API コントラクト表](images/desktop-to-uwp/contract-table.png)

<span data-ttu-id="62b90-160">.NET ベースのデスクトップ アプリの場合、その API コントラクトへの参照を追加します。その後、そのファイルの **[ローカルにコピー]** プロパティを **[False]** に設定します。</span><span class="sxs-lookup"><span data-stu-id="62b90-160">If you have a .NET-based desktop app, add a reference to that API contract, and then set the **Copy Local** property of that file to **False**.</span></span> <span data-ttu-id="62b90-161">C++ ベースのプロジェクトの場合、**[追加のインクルード ディレクトリ]** に、このコントラクトを含むフォルダーのパスを追加します。</span><span class="sxs-lookup"><span data-stu-id="62b90-161">If you have a C++-based project, add to your **Additional Include Directories**, a path to the folder that contains this contract.</span></span>

<span data-ttu-id="62b90-162">:white_check_mark:**お客様のエクスペリエンスを追加する Api を呼び出す**</span><span class="sxs-lookup"><span data-stu-id="62b90-162">:white_check_mark: **Call the APIs to add your experience**</span></span>

<span data-ttu-id="62b90-163">以下に、前述の通知ウィンドウの表示に使用するコードを示します。</span><span class="sxs-lookup"><span data-stu-id="62b90-163">Here's the code that you'd use to show the notification window that we looked at earlier.</span></span> <span data-ttu-id="62b90-164">これらの API はこの[一覧](desktop-to-uwp-supported-api.md)にあるため、このコードをデスクトップ アプリケーションに追加してすぐに実行できます。</span><span class="sxs-lookup"><span data-stu-id="62b90-164">These APIs appear in this [list](desktop-to-uwp-supported-api.md) so you can add this code to your desktop application and run it right now.</span></span>

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
<span data-ttu-id="62b90-165">通知の詳細については、「[アダプティブ トースト通知と対話型トースト通知](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/adaptive-interactive-toasts)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62b90-165">To learn more about notifications, see [Adaptive and Interactive toast notifications](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/adaptive-interactive-toasts).</span></span>

## <a name="support-windows-xp-windows-vista-and-windows-78-install-bases"></a><span data-ttu-id="62b90-166">Windows XP、Windows Vista、および Windows 7/8 インストール ベースのサポート</span><span class="sxs-lookup"><span data-stu-id="62b90-166">Support Windows XP, Windows Vista, and Windows 7/8 install bases</span></span>

<span data-ttu-id="62b90-167">新しいブランチを作成し、別のコード ベースを管理することがなく、Windows 10 用のアプリケーションを最新化することができます。</span><span class="sxs-lookup"><span data-stu-id="62b90-167">You can modernize your application for Windows 10 without having to create a new branch and maintain separate code bases.</span></span>

<span data-ttu-id="62b90-168">Windows 10 ユーザー向けに個別のバイナリをビルドする場合は、条件付きコンパイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="62b90-168">If you want to build separate binaries for Windows 10 users, use conditional compilation.</span></span> <span data-ttu-id="62b90-169">すべての Windows ユーザーに対して 1 組のバイナリをビルドして展開する場合は、ランタイム チェックを使用します。</span><span class="sxs-lookup"><span data-stu-id="62b90-169">If you'd prefer to build one set of binaries that you deploy to all Windows users, use runtime checks.</span></span>

<span data-ttu-id="62b90-170">各オプションを簡単に見ていきましょう。</span><span class="sxs-lookup"><span data-stu-id="62b90-170">Let's take a quick look at each option.</span></span>

### <a name="conditional-compilation"></a><span data-ttu-id="62b90-171">条件付きコンパイル</span><span class="sxs-lookup"><span data-stu-id="62b90-171">Conditional compilation</span></span>

<span data-ttu-id="62b90-172">1 つのコードベースを維持して、Windows 10 ユーザー向けだけに一連のバイナリをコンパイルします。</span><span class="sxs-lookup"><span data-stu-id="62b90-172">You can keep one code base and compile a set of binaries just for Windows 10 users.</span></span>

<span data-ttu-id="62b90-173">最初に、新しいビルド構成をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="62b90-173">First, add a new build configuration to your project.</span></span>

![ビルド構成](images/desktop-to-uwp/build-config.png)

<span data-ttu-id="62b90-175">そのビルド構成の定数を作成する Windows ランタイム Api を呼び出すコードを識別するためにします。</span><span class="sxs-lookup"><span data-stu-id="62b90-175">For that build configuration, create a constant that to identify code that calls Windows Runtime APIs.</span></span>  

<span data-ttu-id="62b90-176">.NET ベースのプロジェクトの場合、この定数は**条件付きコンパイル定数**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="62b90-176">For .NET-based projects, the constant is called a **Conditional Compilation Constant**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/compilation-constants.png)

<span data-ttu-id="62b90-178">C++ ベースのプロジェクトの場合、この定数は**プリプロセッサ定義**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="62b90-178">For C++-based projects, the constant is called a **Preprocessor Definition**.</span></span>

![プリプロセッサ](images/desktop-to-uwp/pre-processor.png)

<span data-ttu-id="62b90-180">この定数を、任意の UWP コードのブロックの前に追加します。</span><span class="sxs-lookup"><span data-stu-id="62b90-180">Add that constant before any block of UWP code.</span></span>

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

<span data-ttu-id="62b90-181">この定数がアクティブなビルド構成で定義されている場合のみ、コンパイラでこのコードがビルドされます。</span><span class="sxs-lookup"><span data-stu-id="62b90-181">The compiler builds that code only if that constant is defined in your active build configuration.</span></span>

### <a name="runtime-checks"></a><span data-ttu-id="62b90-182">ランタイム チェック</span><span class="sxs-lookup"><span data-stu-id="62b90-182">Runtime checks</span></span>

<span data-ttu-id="62b90-183">ユーザーが実行する Windows のバージョンに関係なく、1 組のバイナリをすべての Windows ユーザー向けにコンパイルできます。</span><span class="sxs-lookup"><span data-stu-id="62b90-183">You can compile one set of binaries for all of your Windows users regardless of which version of Windows they run.</span></span> <span data-ttu-id="62b90-184">アプリケーションは Windows ランタイム Api、ユーザーが実行する場合にのみアプリケーションをパッケージ化されたアプリケーションとして Windows 10</span><span class="sxs-lookup"><span data-stu-id="62b90-184">Your application calls Windows Runtime APIs only if the user is runs your application as a packaged application on Windows 10.</span></span>

<span data-ttu-id="62b90-185">ランタイム チェックをコードに追加する最も簡単な方法では、この Nuget パッケージをインストールします。[デスクトップ ブリッジ ヘルパー](https://www.nuget.org/packages/DesktopBridge.Helpers/)しを使用して、``IsRunningAsUWP()``メソッド ゲートを Windows ランタイム Api を呼び出すコードをすべてオフにします。</span><span class="sxs-lookup"><span data-stu-id="62b90-185">The easiest way to add runtime checks to your code is to install this Nuget package: [Desktop Bridge Helpers](https://www.nuget.org/packages/DesktopBridge.Helpers/) and then use the ``IsRunningAsUWP()`` method to gate off all code that calls Windows Runtime APIs.</span></span> <span data-ttu-id="62b90-186">このブログの詳細については投稿を参照してください。[デスクトップ ブリッジ - アプリケーションのコンテキストを識別する](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/)します。</span><span class="sxs-lookup"><span data-stu-id="62b90-186">see this blog post for more details: [Desktop Bridge - Identify the application's context](https://blogs.msdn.microsoft.com/appconsult/2016/11/03/desktop-bridge-identify-the-applications-context/).</span></span>

## <a name="related-video"></a><span data-ttu-id="62b90-187">関連ビデオ</span><span class="sxs-lookup"><span data-stu-id="62b90-187">Related Video</span></span>

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Use-UWP-APIs-in-Your-Code-3d78c6WhD_9506218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="related-samples"></a><span data-ttu-id="62b90-188">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="62b90-188">Related Samples</span></span>

* [<span data-ttu-id="62b90-189">Hello World サンプル</span><span class="sxs-lookup"><span data-stu-id="62b90-189">Hello World Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/HelloWorldSample)
* [<span data-ttu-id="62b90-190">セカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="62b90-190">Secondary Tile</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SecondaryTileSample)
* [<span data-ttu-id="62b90-191">ストア API サンプル</span><span class="sxs-lookup"><span data-stu-id="62b90-191">Store API Sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/StoreSample)
* [<span data-ttu-id="62b90-192">WinForms アプリケーション UWP UpdateTask を実装します。</span><span class="sxs-lookup"><span data-stu-id="62b90-192">WinForms application that implements a UWP UpdateTask</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/WinFormsUpdateTaskSample)
* [<span data-ttu-id="62b90-193">UWP サンプルへのブリッジのデスクトップ アプリ</span><span class="sxs-lookup"><span data-stu-id="62b90-193">Desktop app bridge to UWP Samples</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)


## <a name="support-and-feedback"></a><span data-ttu-id="62b90-194">サポートとフィードバック</span><span class="sxs-lookup"><span data-stu-id="62b90-194">Support and feedback</span></span>

<span data-ttu-id="62b90-195">**質問の回答を検索**</span><span class="sxs-lookup"><span data-stu-id="62b90-195">**Find answers to your questions**</span></span>

<span data-ttu-id="62b90-196">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="62b90-196">Have questions?</span></span> <span data-ttu-id="62b90-197">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="62b90-197">Ask us on Stack Overflow.</span></span> <span data-ttu-id="62b90-198">Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="62b90-198">Our team monitors these [tags](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="62b90-199">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="62b90-199">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

<span data-ttu-id="62b90-200">**ご意見や機能を提案します。**</span><span class="sxs-lookup"><span data-stu-id="62b90-200">**Give feedback or make feature suggestions**</span></span>

<span data-ttu-id="62b90-201">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62b90-201">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
