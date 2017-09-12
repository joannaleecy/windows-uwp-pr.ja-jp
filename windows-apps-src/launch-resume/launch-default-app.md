---
author: TylerMSFT
title: "URI に応じた既定のアプリの起動"
description: "URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。"
ms.assetid: 7B0D0AF5-D89E-4DB0-9B79-90201D79974F
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 0fe93670739a89c9416fdbfc28117a794a6a345d
ms.sourcegitcommit: ca060f051e696da2c1e26e9dd4d2da3fa030103d
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/03/2017
---
# <a name="launch-the-default-app-for-a-uri"></a><span data-ttu-id="6763f-106">URI に応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="6763f-106">Launch the default app for a URI</span></span>

<span data-ttu-id="6763f-107">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="6763f-107">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="6763f-108">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="6763f-108">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="6763f-109">重要な API</span><span class="sxs-lookup"><span data-stu-id="6763f-109">Important APIs</span></span>**

- [**<span data-ttu-id="6763f-110">LaunchUriAsync</span><span class="sxs-lookup"><span data-stu-id="6763f-110">LaunchUriAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-  [**<span data-ttu-id="6763f-111">PreferredApplicationPackageFamilyName</span><span class="sxs-lookup"><span data-stu-id="6763f-111">PreferredApplicationPackageFamilyName</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh965482)
- [**<span data-ttu-id="6763f-112">DesiredRemainingView</span><span class="sxs-lookup"><span data-stu-id="6763f-112">DesiredRemainingView</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn298314)

<span data-ttu-id="6763f-113">URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="6763f-113">Learn how to launch the default app for a Uniform Resource Identifier (URI).</span></span> <span data-ttu-id="6763f-114">URI を使うと、別のアプリを起動して特定の作業を実行できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-114">URIs allow you to launch another app to perform a specific task.</span></span> <span data-ttu-id="6763f-115">また、Windows に組み込まれている多くの URI スキームの概要についても説明します。</span><span class="sxs-lookup"><span data-stu-id="6763f-115">This topic also provides an overview of the many URI schemes built into Windows.</span></span> <span data-ttu-id="6763f-116">カスタム URI も起動することができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-116">You can launch custom URIs too.</span></span> <span data-ttu-id="6763f-117">カスタム URI スキームを登録する方法と URI のアクティブ化を処理する方法について詳しくは、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-117">For more info about registering a custom URI scheme and handling URI activation, see [Handle URI activation](handle-uri-activation.md).</span></span>


<span data-ttu-id="6763f-118">URI スキームでは、ハイパーリンクをクリックしてアプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-118">URI schemes let you open apps by clicking hyperlinks.</span></span> <span data-ttu-id="6763f-119">**mailto:** を使って新しいメールの作成を開始できるのと同様に、**http:** を使って既定の Web ブラウザーを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-119">Just as you can start a new email using **mailto:**, you can open the default web browser using **http:**</span></span>

<span data-ttu-id="6763f-120">このトピックでは、Windows に組み込まれている以下の URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6763f-120">This topic describes the following URI schemes built into Windows:</span></span>

| <span data-ttu-id="6763f-121">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-121">URI Scheme</span></span> | <span data-ttu-id="6763f-122">起動対象</span><span class="sxs-lookup"><span data-stu-id="6763f-122">Launches</span></span> |
| -------|--------------|
|[<span data-ttu-id="6763f-123">bingmaps:、ms-drive-to:、ms-walk-to:</span><span class="sxs-lookup"><span data-stu-id="6763f-123">bingmaps:, ms-drive-to:, and ms-walk-to:</span></span> ](#maps-app-uri-schemes) | <span data-ttu-id="6763f-124">マップ アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-124">Maps app</span></span> |
|[<span data-ttu-id="6763f-125">http:</span><span class="sxs-lookup"><span data-stu-id="6763f-125">http:</span></span>](#http-uri-scheme) | <span data-ttu-id="6763f-126">既定の Web ブラウザー</span><span class="sxs-lookup"><span data-stu-id="6763f-126">Default web browser</span></span> |
|[<span data-ttu-id="6763f-127">mailto:</span><span class="sxs-lookup"><span data-stu-id="6763f-127">mailto:</span></span>](#email-uri-scheme) | <span data-ttu-id="6763f-128">既定のメール アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-128">Default email app</span></span> |
|[<span data-ttu-id="6763f-129">ms-call:</span><span class="sxs-lookup"><span data-stu-id="6763f-129">ms-call:</span></span>](#call-app-uri-scheme) |  <span data-ttu-id="6763f-130">通話アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-130">Call app</span></span> |
|[<span data-ttu-id="6763f-131">ms-chat:</span><span class="sxs-lookup"><span data-stu-id="6763f-131">ms-chat:</span></span>](#messaging-app-uri-scheme) | <span data-ttu-id="6763f-132">メッセージング アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-132">Messaging app</span></span> |
|[<span data-ttu-id="6763f-133">ms-people:</span><span class="sxs-lookup"><span data-stu-id="6763f-133">ms-people:</span></span>](#people-app-uri-scheme) | <span data-ttu-id="6763f-134">People アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-134">People app</span></span> |
|[<span data-ttu-id="6763f-135">ms-settings:</span><span class="sxs-lookup"><span data-stu-id="6763f-135">ms-settings:</span></span>](#settings-app-uri-scheme) | <span data-ttu-id="6763f-136">設定アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-136">Settings app</span></span> |
|[<span data-ttu-id="6763f-137">ms-store:</span><span class="sxs-lookup"><span data-stu-id="6763f-137">ms-store:</span></span>](#store-app-uri-scheme)  | <span data-ttu-id="6763f-138">ストア アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-138">Store app</span></span> |
|[<span data-ttu-id="6763f-139">ms-tonepicker:</span><span class="sxs-lookup"><span data-stu-id="6763f-139">ms-tonepicker:</span></span>](#tone-picker-uri-scheme) | <span data-ttu-id="6763f-140">トーンの選択コントロール</span><span class="sxs-lookup"><span data-stu-id="6763f-140">Tone picker</span></span> |
|[<span data-ttu-id="6763f-141">ms-yellowpage:</span><span class="sxs-lookup"><span data-stu-id="6763f-141">ms-yellowpage:</span></span>](#nearby-numbers-app-uri-scheme) | <span data-ttu-id="6763f-142">近隣の施設検索アプリ</span><span class="sxs-lookup"><span data-stu-id="6763f-142">Nearby Numbers app</span></span> |

<br> <span data-ttu-id="6763f-143">たとえば、次の URI は既定のブラウザーを開き、Bing の Web サイトを表示します。</span><span class="sxs-lookup"><span data-stu-id="6763f-143">For example, the following URI opens the default browser and displays the Bing web site.</span></span>

`http://bing.com`

<span data-ttu-id="6763f-144">カスタム URI スキームを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="6763f-144">You can also launch custom URI schemes too.</span></span> <span data-ttu-id="6763f-145">その URI を処理するアプリがインストールされていない場合は、ユーザーにインストールするアプリを推奨することができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-145">If there is no app installed to handle that URI, you can recommend an app for the user to install.</span></span> <span data-ttu-id="6763f-146">詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-146">For more info, see [Recommend an app if one is not available to handle the URI](#recommend-an-app-if-one-is-not-available-to-handle-the-uri).</span></span>

<span data-ttu-id="6763f-147">一般的に、起動するアプリをアプリが選ぶことはできません。</span><span class="sxs-lookup"><span data-stu-id="6763f-147">In general, your app can't select the app that is launched.</span></span> <span data-ttu-id="6763f-148">どのアプリを起動するかはユーザーが決めます。</span><span class="sxs-lookup"><span data-stu-id="6763f-148">The user determines which app is launched.</span></span> <span data-ttu-id="6763f-149">同じ URI スキームを処理するために、複数のアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-149">More than one app can register to handle the same URI scheme.</span></span> <span data-ttu-id="6763f-150">この例外として、予約済みの URI スキームがあります。</span><span class="sxs-lookup"><span data-stu-id="6763f-150">The exception to this is for reserved URI schemes.</span></span> <span data-ttu-id="6763f-151">予約済みの URI スキームの登録は無視されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-151">Registrations of reserved URI schemes are ignored.</span></span> <span data-ttu-id="6763f-152">予約済みの URI スキームの一覧については、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-152">For the full list of reserved URI schemes, see [Handle URI activation](handle-uri-activation.md).</span></span> <span data-ttu-id="6763f-153">複数のアプリが同じ URI スキームを登録している可能性がある場合は、アプリで特定のアプリを起動することを推奨できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-153">In cases where more than one app may have registered the same URI scheme, your app can recommend a specific app to be launched.</span></span> <span data-ttu-id="6763f-154">詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-154">For more info, see [Recommend an app if one is not available to handle the URI](#recommend-an-app-if-one-is-not-available-to-handle-the-uri).</span></span>

### <a name="call-launchuriasync-to-launch-a-uri"></a><span data-ttu-id="6763f-155">LaunchUriAsync を呼び出して URI を起動</span><span class="sxs-lookup"><span data-stu-id="6763f-155">Call LaunchUriAsync to launch a URI</span></span>

<span data-ttu-id="6763f-156">URI を起動するには、[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="6763f-156">Use the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch a URI.</span></span> <span data-ttu-id="6763f-157">このメソッドを呼び出すとき、アプリはユーザーに表示されるフォアグラウンド アプリである必要があります。</span><span class="sxs-lookup"><span data-stu-id="6763f-157">When you call this method, your app must be the foreground app, that is, it must be visible to the user.</span></span> <span data-ttu-id="6763f-158">この要件は、ユーザーが制御を維持するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="6763f-158">This requirement helps ensure that the user remains in control.</span></span> <span data-ttu-id="6763f-159">この要件を満たすために、すべての URI 起動がアプリの UI に直接結び付けられていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="6763f-159">To meet this requirement, make sure that you tie all URI launches directly to the UI of your app.</span></span> <span data-ttu-id="6763f-160">URI 起動を開始するには、常にユーザーがなんらかの操作を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6763f-160">The user must always take some action to initiate a URI launch.</span></span> <span data-ttu-id="6763f-161">URI を起動しようとしたときにアプリがフォアグラウンドにない場合、起動は失敗し、エラー コールバックが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-161">If you attempt to launch a URI and your app isn't in the foreground, the launch will fail and your error callback will be invoked.</span></span>

<span data-ttu-id="6763f-162">最初に URI を表す [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/system.uri.aspx) オブジェクトを作成し、それを [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="6763f-162">First create a [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/system.uri.aspx) object to represent the URI, then pass that to the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method.</span></span> <span data-ttu-id="6763f-163">次の例のように、返される結果を使って呼び出しが成功したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="6763f-163">Use the return result to see if the call succeeded, as shown in the following example.</span></span>

```cs
private async void launchURI_Click(object sender, RoutedEventArgs e)
{
   // The URI to launch
   var uriBing = new Uri(@"http://www.bing.com");

   // Launch the URI
   var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);

   if (success)
   {
      // URI launched
   }
   else
   {
      // URI launch failed
   }
}
```

<span data-ttu-id="6763f-164">場合によって、ユーザーが実際にアプリを切り替えようとしているかどうかを確認するダイアログがオペレーティング システムにより表示されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-164">In some cases, the operating system will prompt the user to see if they actually want to switch apps.</span></span>

![灰色で表示されたアプリの背景にオーバーレイで表示された警告ダイアログ。](images/warningdialog.png)

<span data-ttu-id="6763f-168">この確認ダイアログを常に表示する場合は、[**Windows.System.LauncherOptions.TreatAsUntrusted**](https://msdn.microsoft.com/library/windows/apps/hh701442) プロパティを使って、オペレーティング システムが警告を表示することを指定します。</span><span class="sxs-lookup"><span data-stu-id="6763f-168">If you always want this prompt to occur, use the [**Windows.System.LauncherOptions.TreatAsUntrusted**](https://msdn.microsoft.com/library/windows/apps/hh701442) property to tell the operating system to display a warning.</span></span>

```cs
// The URI to launch
var uriBing = new Uri(@"http://www.bing.com");

// Set the option to show a warning
var promptOptions = new Windows.System.LauncherOptions();
promptOptions.TreatAsUntrusted = true;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
```

### <a name="recommend-an-app-if-one-is-not-available-to-handle-the-uri"></a><span data-ttu-id="6763f-169">URI を処理するアプリがない場合にアプリを推奨</span><span class="sxs-lookup"><span data-stu-id="6763f-169">Recommend an app if one is not available to handle the URI</span></span>

<span data-ttu-id="6763f-170">場合によっては、起動中の URI を処理するアプリがインストールされていないこともあります。</span><span class="sxs-lookup"><span data-stu-id="6763f-170">In some cases, the user might not have an app installed to handle the URI that you are launching.</span></span> <span data-ttu-id="6763f-171">既定では、オペレーティング システムによってストア上の適切なアプリを検索するリンクが表示されて、これらのケースは対処されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-171">By default, the operating system handles these cases by providing the user with a link to search for an appropriate app on the store.</span></span> <span data-ttu-id="6763f-172">このシナリオで入手する必要のあるアプリに関する特定の推奨事項を示す場合は、起動中の URI と共に推奨事項を渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-172">If you want to give the user a specific recommendation for which app to acquire in this scenario, you can do so by passing that recommendation along with the URI that you are launching.</span></span>

<span data-ttu-id="6763f-173">推奨事項は、URI スキームを処理するアプリが複数登録されているときにも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="6763f-173">Recommendations are also useful when more than one app has registered to handle a URI scheme.</span></span> <span data-ttu-id="6763f-174">特定のアプリを推奨すると、そのアプリが既にインストールされている場合、Windows はそのアプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="6763f-174">By recommending a specific app, Windows will open that app if it is already installed.</span></span>

<span data-ttu-id="6763f-175">アプリを推奨するには、[**LauncherOptions.preferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) を推奨するストア内のアプリのパッケージ ファミリ名に設定して、[**Windows.System.Launcher.LaunchUriAsync(Uri, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701484) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6763f-175">To make a recommendation, call the [**Windows.System.Launcher.LaunchUriAsync(Uri, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701484) method with [**LauncherOptions.preferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) set to the package family name of the app in the store that you want to recommend.</span></span> <span data-ttu-id="6763f-176">オペレーティング システムではこの情報を使って、ストア内のアプリを検索する一般的なオプションを、ストアから推奨アプリを入手する固有のオプションに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="6763f-176">The operating system uses this info to replace the general option to search for an app in the store with a specific option to acquire the recommended app from the store.</span></span>

```cs
// Set the recommended app
var options = new Windows.System.LauncherOptions();
options.PreferredApplicationPackageFamilyName = "Contoso.URIApp_8wknc82po1e";
options.PreferredApplicationDisplayName = "Contoso URI Ap";

// Launch the URI and pass in the recommended app
// in case the user has no apps installed to handle the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

### <a name="set-remaining-view-preference"></a><span data-ttu-id="6763f-177">残りの表示の基本設定</span><span class="sxs-lookup"><span data-stu-id="6763f-177">Set remaining view preference</span></span>

<span data-ttu-id="6763f-178">[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) を呼び出すソース アプリは、URI の起動後も画面上に留まることを要求できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-178">Source apps that call [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) can request that they remain on screen after a URI launch.</span></span> <span data-ttu-id="6763f-179">既定では、利用可能なスペース全体がソース アプリと URI を処理するターゲット アプリとで均等に共有されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-179">By default, Windows attempts to share all available space equally between the source app and the target app that handles the URI.</span></span> <span data-ttu-id="6763f-180">ソース アプリでは、[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) プロパティを使って、利用可能なスペースをソース アプリのウィンドウがどの程度占めるかをオペレーティング システムに指示できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-180">Source apps can use the [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) property to indicate to the operating system that they prefer their app window to take up more or less of the available space.</span></span> <span data-ttu-id="6763f-181">この **DesiredRemainingView** では、URI の起動後にソース アプリが画面上に留まる必要がなく、ターゲット アプリに完全に置き換わっても良いことも示せます。</span><span class="sxs-lookup"><span data-stu-id="6763f-181">**DesiredRemainingView** can also be used to indicate that the source app doesn't need to remain on screen after the URI launch and can be completely replaced by the target app.</span></span> <span data-ttu-id="6763f-182">このプロパティは呼び出し元アプリの優先ウィンドウのサイズだけを指定します。</span><span class="sxs-lookup"><span data-stu-id="6763f-182">This property only specifies the preferred window size of the calling app.</span></span> <span data-ttu-id="6763f-183">画面に同時に表示されている可能性のある他のアプリの動作は指定しません。</span><span class="sxs-lookup"><span data-stu-id="6763f-183">It doesn't specify the behavior of other apps that may happen to also be on screen at the same time.</span></span>

<span data-ttu-id="6763f-184">**注**  ソース アプリの最終的なウィンドウ サイズは、複数の異なる要素が考慮されて決定されます。たとえば、ソース アプリの設定、画面上のアプリの数、画面の向きなどです。</span><span class="sxs-lookup"><span data-stu-id="6763f-184">**Note**  Windows takes into account multiple different factors when it determines the source app's final window size, for example, the preference of the source app, the number of apps on screen, the screen orientation, and so on.</span></span> <span data-ttu-id="6763f-185">[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) を設定しても、ソース アプリの特定のウィンドウ動作が保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="6763f-185">By setting [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314), you aren't guaranteed a specific windowing behavior for the source app.</span></span>

```cs
// Set the desired remaining view.
var options = new Windows.System.LauncherOptions();
options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

## <a name="uri-schemes"></a><span data-ttu-id="6763f-186">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-186">URI Schemes</span></span> ##

<span data-ttu-id="6763f-187">各種 URI スキームについて以下に説明します。</span><span class="sxs-lookup"><span data-stu-id="6763f-187">The various URI schemes are described below.</span></span>
<br>

### <a name="call-app-uri-scheme"></a><span data-ttu-id="6763f-188">通話アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-188">Call app URI scheme</span></span>

<span data-ttu-id="6763f-189">アプリで **ms-call:** URI スキームを使って、通話アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-189">Your app can use the **ms-call:** URI scheme to launch the Call app.</span></span>

| <span data-ttu-id="6763f-190">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-190">URI Scheme</span></span>       | <span data-ttu-id="6763f-191">結果</span><span class="sxs-lookup"><span data-stu-id="6763f-191">Result</span></span>                   |
|------------------|--------------------------|
| <span data-ttu-id="6763f-192">ms-call:settings</span><span class="sxs-lookup"><span data-stu-id="6763f-192">ms-call:settings</span></span> | <span data-ttu-id="6763f-193">アプリ設定のページを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6763f-193">Calls app settings page.</span></span> | 
<br>
### <a name="email-uri-scheme"></a><span data-ttu-id="6763f-194">メールの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-194">Email URI scheme</span></span>

<span data-ttu-id="6763f-195">アプリで **mailto:** URI スキームを使って、既定のメール アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-195">Your app can use the **mailto:** URI scheme to launch the default mail app.</span></span>

| <span data-ttu-id="6763f-196">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-196">URI Scheme</span></span>               | <span data-ttu-id="6763f-197">結果</span><span class="sxs-lookup"><span data-stu-id="6763f-197">Results</span></span>                                                                                                                                                     |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6763f-198">mailto:</span><span class="sxs-lookup"><span data-stu-id="6763f-198">mailto:</span></span>                  | <span data-ttu-id="6763f-199">既定のメール アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="6763f-199">Launches the default email app.</span></span>                                                                                                                             |
| <span data-ttu-id="6763f-200">mailto:\[email address\]</span><span class="sxs-lookup"><span data-stu-id="6763f-200">mailto:\[email address\]</span></span> | <span data-ttu-id="6763f-201">メール アプリを起動し、宛先行で指定されているメール アドレスを使用して新しいメッセージを作成します。</span><span class="sxs-lookup"><span data-stu-id="6763f-201">Launches the email app and creates a new message with the specified email address on the To line.</span></span> <span data-ttu-id="6763f-202">メールは、ユーザーが [送信] をタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="6763f-202">Note that the email is not sent until the user taps send.</span></span> |
<br>
### <a name="http-uri-scheme"></a><span data-ttu-id="6763f-203">HTTP の URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-203">HTTP URI scheme</span></span>

<span data-ttu-id="6763f-204">アプリで **http:** URI スキームを使って、既定の Web ブラウザーを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-204">Your app can use the **http:** URI scheme to launch the default web browser.</span></span>

| <span data-ttu-id="6763f-205">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-205">URI Scheme</span></span> | <span data-ttu-id="6763f-206">結果</span><span class="sxs-lookup"><span data-stu-id="6763f-206">Results</span></span>                           |
|------------|-----------------------------------|
| <span data-ttu-id="6763f-207">http:</span><span class="sxs-lookup"><span data-stu-id="6763f-207">http:</span></span>      | <span data-ttu-id="6763f-208">既定の Web ブラウザーを起動します。</span><span class="sxs-lookup"><span data-stu-id="6763f-208">Launches the default web browser.</span></span> |
<br>
### <a name="maps-app-uri-schemes"></a><span data-ttu-id="6763f-209">マップ アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-209">Maps app URI schemes</span></span>

<span data-ttu-id="6763f-210">アプリで **bingmaps:**、**ms-drive-to:**、**ms-walk-to:** の各 URI スキームを使って、[Windows マップ アプリを起動し](launch-maps-app.md)、特定の地図、ルート案内、検索結果を表示できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-210">Your app can use the **bingmaps:**, **ms-drive-to:**, and **ms-walk-to:** URI schemes to [launch the Windows Maps app](launch-maps-app.md) to specific maps, directions, and search results.</span></span> <span data-ttu-id="6763f-211">たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="6763f-211">For example, the following URI opens the Windows Maps app and displays a map centered over New York City.</span></span>

`bingmaps:?cp=40.726966~-74.006076`

![Windows マップ アプリの例。](images/mapnyc.png)

<span data-ttu-id="6763f-213">詳しくは、「[Windows マップ アプリの起動](launch-maps-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-213">For more info, see [Launch the Windows Maps app](launch-maps-app.md).</span></span> <span data-ttu-id="6763f-214">独自のアプリでマップ コントロールを使うには、「[2D、3D、Streetside ビューでの地図の表示](https://msdn.microsoft.com/library/windows/apps/mt219695)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-214">To use the map control in your own app, see [Display maps with 2D, 3D, and Streetside views](https://msdn.microsoft.com/library/windows/apps/mt219695).</span></span>
<br>
### <a name="messaging-app-uri-scheme"></a><span data-ttu-id="6763f-215">メッセージング アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-215">Messaging app URI scheme</span></span>

<span data-ttu-id="6763f-216">アプリで **ms-chat:** URI スキームを使って、Windows メッセージング アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-216">Your app can use the **ms-chat:** URI scheme to launch the Windows Messaging app.</span></span>

<span data-ttu-id="6763f-217">| URI スキーム |結果 | |-- ---------|--------| | ms-chat:   | メッセージング アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="6763f-217">| URI scheme |Results | |-- ---------|--------| | ms-chat:   | Launches the Messaging app.</span></span> <span data-ttu-id="6763f-218">| | ms-chat:?ContactID={contacted}  |  特定の連絡先の情報を使ってメッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="6763f-218">| | ms-chat:?ContactID={contacted}  |  Allows the messaging application to be launched with a particular contact’s information.</span></span>   <span data-ttu-id="6763f-219">| | ms-chat:?Body={body} | メッセージの内容として使用する文字列を使ってメッセージング アプリケーションを起動することを許可します。| | ms-chat:?Addresses={address}&Body={body} | 特定のアドレスの情報とメッセージの内容として使用する文字列を使って、メッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="6763f-219">| | ms-chat:?Body={body} | Allows the messaging application to be launched with a string to use as the content of the message.| | ms-chat:?Addresses={address}&Body={body} | Allows the messaging application to be launched with a particular addresses' information, and with a string to use as the content of the message.</span></span> <span data-ttu-id="6763f-220">注: アドレスは連結することができます。</span><span class="sxs-lookup"><span data-stu-id="6763f-220">Note: Addresses can be concatenated.</span></span> <span data-ttu-id="6763f-221">| | ms-chat:?TransportId={transportId}  | 特定のトランスポート ID を使ってメッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="6763f-221">| | ms-chat:?TransportId={transportId}  | Allows the messaging application to be launched with a particular transport ID.</span></span> |
<br>
### <a name="tone-picker-uri-scheme"></a><span data-ttu-id="6763f-222">トーンの選択コントロールの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-222">Tone picker URI scheme</span></span>

<span data-ttu-id="6763f-223">アプリで **ms-tonepicker:** URI スキームを使って、トーン、アラーム、システム音を選択できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-223">Your app can use the **ms-tonepicker:** URI scheme to choose ringtones, alarms, and system tones.</span></span> <span data-ttu-id="6763f-224">また、新しいトーンを保存したり、トーンの名前を表示したりできます。</span><span class="sxs-lookup"><span data-stu-id="6763f-224">You can also save new ringtones and get the display name of a tone.</span></span>

| <span data-ttu-id="6763f-225">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-225">URI Scheme</span></span> | <span data-ttu-id="6763f-226">結果</span><span class="sxs-lookup"><span data-stu-id="6763f-226">Results</span></span> |
|------------|---------|
| <span data-ttu-id="6763f-227">ms-tonepicker:</span><span class="sxs-lookup"><span data-stu-id="6763f-227">ms-tonepicker:</span></span> | <span data-ttu-id="6763f-228">トーン、アラーム、システム音を選択します。</span><span class="sxs-lookup"><span data-stu-id="6763f-228">Pick ringtones, alarms, and system tones.</span></span> |

<span data-ttu-id="6763f-229">パラメーターは [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を介して LaunchURI API に渡されます。</span><span class="sxs-lookup"><span data-stu-id="6763f-229">Parameters are passed via a [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) to the LaunchURI API.</span></span> <span data-ttu-id="6763f-230">詳しくは、「[ms-tonepicker URI スキームを使ったトーンの選択と保存](launch-ringtone-picker.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-230">See [Choose and save tones using the ms-tonepicker URI scheme](launch-ringtone-picker.md) for details.</span></span>

### <a name="nearby-numbers-app-uri-scheme"></a><span data-ttu-id="6763f-231">近隣の施設検索アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-231">Nearby Numbers app URI scheme</span></span>
<br>
<span data-ttu-id="6763f-232">アプリで **ms-yellowpage:** URI スキームを使って、近隣の施設検索アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-232">Your app can use the **ms-yellowpage:** URI scheme to launch the Nearby Numbers app.</span></span>

| <span data-ttu-id="6763f-233">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-233">URI Scheme</span></span> | <span data-ttu-id="6763f-234">結果</span><span class="sxs-lookup"><span data-stu-id="6763f-234">Results</span></span> |
|------------|---------|
| <span data-ttu-id="6763f-235">ms-yellowpage:?input=\[keyword\]&method=\[String または T9\]</span><span class="sxs-lookup"><span data-stu-id="6763f-235">ms-yellowpage:?input=\[keyword\]&method=\[String or T9\]</span></span> | <span data-ttu-id="6763f-236">近隣の施設検索アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="6763f-236">Launches the Nearby Numbers app.</span></span> `input` <span data-ttu-id="6763f-237">検索するキーワードを指定します。</span><span class="sxs-lookup"><span data-stu-id="6763f-237">refers to the keyword you want to search.</span></span> `method` <span data-ttu-id="6763f-238">検索の種類 (文字列検索か T9 検索) を指定します。</span><span class="sxs-lookup"><span data-stu-id="6763f-238">refers to the type of search (string or T9 search).</span></span> <br> <span data-ttu-id="6763f-239">`method` が `T9` (キーボードの種類) である場合、`keyword` は T9 キーボードの文字にマップされた数字の検索文字列になります。</span><span class="sxs-lookup"><span data-stu-id="6763f-239">If `method` is `T9` (a type of keyboard) then `keyword` should be a numeric string that maps to the T9 keyboard letters to search for.</span></span><br><span data-ttu-id="6763f-240">`method` が `String` の場合は、`keyword` は検索するキーワードになります。</span><span class="sxs-lookup"><span data-stu-id="6763f-240">If `method` is `String` then `keyword` is the keyword to search for.</span></span> |
 
<br>
### <a name="people-app-uri-scheme"></a><span data-ttu-id="6763f-241">People アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-241">People app URI scheme</span></span>

<span data-ttu-id="6763f-242">アプリで **ms-people:** URI スキームを使って、People アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-242">Your app can use the **ms-people:** URI scheme to launch the People app.</span></span>
<span data-ttu-id="6763f-243">詳しくは、「[People アプリの起動](launch-people-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-243">For more info, see [Launch the People app](launch-people-apps.md).</span></span>

<br>
### <a name="settings-app-uri-scheme"></a><span data-ttu-id="6763f-244">設定アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-244">Settings app URI scheme</span></span>

<span data-ttu-id="6763f-245">アプリで **ms-settings:** URI スキームを使って、[Windows 設定アプリを起動](launch-settings-app.md)できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-245">Your app can use the **ms-settings:** URI scheme to [launch the Windows Settings app](launch-settings-app.md).</span></span> <span data-ttu-id="6763f-246">設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。</span><span class="sxs-lookup"><span data-stu-id="6763f-246">Launching to the Settings app is an important part of writing a privacy-aware app.</span></span> <span data-ttu-id="6763f-247">アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6763f-247">If your app can't access a sensitive resource, we recommend providing the user a convenient link to the privacy settings for that resource.</span></span> <span data-ttu-id="6763f-248">たとえば、次の URI は設定アプリを開き、カメラのプライバシー設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="6763f-248">For example, the following URI opens the Settings app and displays the camera privacy settings.</span></span>

`ms-settings:privacy-webcam`

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

<span data-ttu-id="6763f-250">詳しくは、「[Windows 設定アプリの起動](launch-settings-app.md)」と「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-250">For more info, see [Launch the Windows Settings app](launch-settings-app.md) and [Guidelines for privacy-aware apps](https://msdn.microsoft.com/library/windows/apps/hh768223).</span></span>

<br>
### <a name="store-app-uri-scheme"></a><span data-ttu-id="6763f-251">ストア アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="6763f-251">Store app URI scheme</span></span>

<span data-ttu-id="6763f-252">アプリで **ms-windows-store:** URI スキームを使って、[Windows ストア アプリを起動](launch-store-app.md)できます。</span><span class="sxs-lookup"><span data-stu-id="6763f-252">Your app can use the **ms-windows-store:** URI scheme to [Launch the Windows Store app](launch-store-app.md).</span></span> <span data-ttu-id="6763f-253">製品の詳細ページ、製品のレビュー ページ、検索ページなどを開きます。たとえば、次の URI は、Windows ストア アプリを開き、ストアのホーム ページを起動します。</span><span class="sxs-lookup"><span data-stu-id="6763f-253">Open product detail pages, product review pages, and search pages, etc. For example, the following URI opens the Windows Store app and launches the home page of the Store.</span></span>

`ms-windows-store://home/`

<span data-ttu-id="6763f-254">詳しくは、「[Windows ストア アプリの起動](launch-store-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6763f-254">For more info, see [Launch the Windows Store app](launch-store-app.md).</span></span>
