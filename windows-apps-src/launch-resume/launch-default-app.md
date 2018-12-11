---
title: URI に応じた既定のアプリの起動
description: URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。 URI を使うと、別のアプリを起動して特定の作業を実行できます。 また、Windows に組み込まれている多くの URI スキームの概要についても説明します。
ms.assetid: 7B0D0AF5-D89E-4DB0-9B79-90201D79974F
ms.date: 06/26/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 143aa8310cdfe9dd5f0be29bf07f03c23293a647
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8919037"
---
# <a name="launch-the-default-app-for-a-uri"></a><span data-ttu-id="7e157-106">URI に応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="7e157-106">Launch the default app for a URI</span></span>


**<span data-ttu-id="7e157-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="7e157-107">Important APIs</span></span>**

- [**<span data-ttu-id="7e157-108">LaunchUriAsync</span><span class="sxs-lookup"><span data-stu-id="7e157-108">LaunchUriAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701476)
- [**<span data-ttu-id="7e157-109">PreferredApplicationPackageFamilyName</span><span class="sxs-lookup"><span data-stu-id="7e157-109">PreferredApplicationPackageFamilyName</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh965482)
- [**<span data-ttu-id="7e157-110">DesiredRemainingView</span><span class="sxs-lookup"><span data-stu-id="7e157-110">DesiredRemainingView</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn298314)

<span data-ttu-id="7e157-111">URI (Uniform Resource Identifier) に応じて既定のアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7e157-111">Learn how to launch the default app for a Uniform Resource Identifier (URI).</span></span> <span data-ttu-id="7e157-112">URI を使うと、別のアプリを起動して特定の作業を実行できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-112">URIs allow you to launch another app to perform a specific task.</span></span> <span data-ttu-id="7e157-113">また、Windows に組み込まれている多くの URI スキームの概要についても説明します。</span><span class="sxs-lookup"><span data-stu-id="7e157-113">This topic also provides an overview of the many URI schemes built into Windows.</span></span> <span data-ttu-id="7e157-114">カスタム URI も起動することができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-114">You can launch custom URIs too.</span></span> <span data-ttu-id="7e157-115">カスタム URI スキームを登録する方法と URI のアクティブ化を処理する方法について詳しくは、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-115">For more info about registering a custom URI scheme and handling URI activation, see [Handle URI activation](handle-uri-activation.md).</span></span>

<span data-ttu-id="7e157-116">URI スキームでは、ハイパーリンクをクリックしてアプリを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-116">URI schemes let you open apps by clicking hyperlinks.</span></span> <span data-ttu-id="7e157-117">**mailto:** を使って新しいメールの作成を開始できるのと同様に、**http:** を使って既定の Web ブラウザーを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-117">Just as you can start a new email using **mailto:**, you can open the default web browser using **http:**</span></span>

<span data-ttu-id="7e157-118">このトピックでは、Windows に組み込まれている以下の URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7e157-118">This topic describes the following URI schemes built into Windows:</span></span>

| <span data-ttu-id="7e157-119">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-119">URI Scheme</span></span> | <span data-ttu-id="7e157-120">起動対象</span><span class="sxs-lookup"><span data-stu-id="7e157-120">Launches</span></span> |
| ----------:|----------|
|[<span data-ttu-id="7e157-121">bingmaps:、ms-drive-to:、ms-walk-to:</span><span class="sxs-lookup"><span data-stu-id="7e157-121">bingmaps:, ms-drive-to:, and ms-walk-to:</span></span> ](#maps-app-uri-schemes) | <span data-ttu-id="7e157-122">マップ アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-122">Maps app</span></span> |
|[<span data-ttu-id="7e157-123">http:</span><span class="sxs-lookup"><span data-stu-id="7e157-123">http:</span></span>](#http-uri-scheme) | <span data-ttu-id="7e157-124">既定の Web ブラウザー</span><span class="sxs-lookup"><span data-stu-id="7e157-124">Default web browser</span></span> |
|[<span data-ttu-id="7e157-125">mailto:</span><span class="sxs-lookup"><span data-stu-id="7e157-125">mailto:</span></span>](#email-uri-scheme) | <span data-ttu-id="7e157-126">既定のメール アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-126">Default email app</span></span> |
|[<span data-ttu-id="7e157-127">ms-call:</span><span class="sxs-lookup"><span data-stu-id="7e157-127">ms-call:</span></span>](#call-app-uri-scheme) |  <span data-ttu-id="7e157-128">通話アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-128">Call app</span></span> |
|[<span data-ttu-id="7e157-129">ms-chat:</span><span class="sxs-lookup"><span data-stu-id="7e157-129">ms-chat:</span></span>](#messaging-app-uri-scheme) | <span data-ttu-id="7e157-130">メッセージング アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-130">Messaging app</span></span> |
|[<span data-ttu-id="7e157-131">ms-people:</span><span class="sxs-lookup"><span data-stu-id="7e157-131">ms-people:</span></span>](#people-app-uri-scheme) | <span data-ttu-id="7e157-132">People アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-132">People app</span></span> |
|[<span data-ttu-id="7e157-133">ms-photos:</span><span class="sxs-lookup"><span data-stu-id="7e157-133">ms-photos:</span></span>](#photos-app-uri-scheme) | <span data-ttu-id="7e157-134">フォト アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-134">Photos app</span></span> |
|[<span data-ttu-id="7e157-135">ms-settings:</span><span class="sxs-lookup"><span data-stu-id="7e157-135">ms-settings:</span></span>](#settings-app-uri-scheme) | <span data-ttu-id="7e157-136">設定アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-136">Settings app</span></span> |
|[<span data-ttu-id="7e157-137">ms-store:</span><span class="sxs-lookup"><span data-stu-id="7e157-137">ms-store:</span></span>](#store-app-uri-scheme)  | <span data-ttu-id="7e157-138">ストア アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-138">Store app</span></span> |
|[<span data-ttu-id="7e157-139">ms-tonepicker:</span><span class="sxs-lookup"><span data-stu-id="7e157-139">ms-tonepicker:</span></span>](#tone-picker-uri-scheme) | <span data-ttu-id="7e157-140">トーンの選択コントロール</span><span class="sxs-lookup"><span data-stu-id="7e157-140">Tone picker</span></span> |
|[<span data-ttu-id="7e157-141">ms-yellowpage:</span><span class="sxs-lookup"><span data-stu-id="7e157-141">ms-yellowpage:</span></span>](#nearby-numbers-app-uri-scheme) | <span data-ttu-id="7e157-142">近隣の施設検索アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-142">Nearby Numbers app</span></span> |
|[<span data-ttu-id="7e157-143">msnweather:</span><span class="sxs-lookup"><span data-stu-id="7e157-143">msnweather:</span></span>](#weather-app-uri-scheme) | <span data-ttu-id="7e157-144">天気予報アプリ</span><span class="sxs-lookup"><span data-stu-id="7e157-144">Weather app</span></span> |

<br>
<span data-ttu-id="7e157-145">たとえば、次の URI は既定のブラウザーを開き、Bing の Web サイトを表示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-145">For example, the following URI opens the default browser and displays the Bing web site.</span></span>

`http://bing.com`

<span data-ttu-id="7e157-146">カスタム URI スキームを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="7e157-146">You can also launch custom URI schemes too.</span></span> <span data-ttu-id="7e157-147">その URI を処理するアプリがインストールされていない場合は、ユーザーにインストールするアプリを推奨することができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-147">If there is no app installed to handle that URI, you can recommend an app for the user to install.</span></span> <span data-ttu-id="7e157-148">詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-148">For more info, see [Recommend an app if one is not available to handle the URI](#recommend-an-app-if-one-is-not-available-to-handle-the-uri).</span></span>

<span data-ttu-id="7e157-149">一般的に、起動するアプリをアプリが選ぶことはできません。</span><span class="sxs-lookup"><span data-stu-id="7e157-149">In general, your app can't select the app that is launched.</span></span> <span data-ttu-id="7e157-150">どのアプリを起動するかはユーザーが決めます。</span><span class="sxs-lookup"><span data-stu-id="7e157-150">The user determines which app is launched.</span></span> <span data-ttu-id="7e157-151">同じ URI スキームを処理するために、複数のアプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-151">More than one app can register to handle the same URI scheme.</span></span> <span data-ttu-id="7e157-152">この例外として、予約済みの URI スキームがあります。</span><span class="sxs-lookup"><span data-stu-id="7e157-152">The exception to this is for reserved URI schemes.</span></span> <span data-ttu-id="7e157-153">予約済みの URI スキームの登録は無視されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-153">Registrations of reserved URI schemes are ignored.</span></span> <span data-ttu-id="7e157-154">予約済みの URI スキームの一覧については、「[URI のアクティブ化の処理](handle-uri-activation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-154">For the full list of reserved URI schemes, see [Handle URI activation](handle-uri-activation.md).</span></span> <span data-ttu-id="7e157-155">複数のアプリが同じ URI スキームを登録している可能性がある場合は、アプリで特定のアプリを起動することを推奨できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-155">In cases where more than one app may have registered the same URI scheme, your app can recommend a specific app to be launched.</span></span> <span data-ttu-id="7e157-156">詳しくは、「[URI を処理するアプリがない場合にアプリを推奨](#recommend-an-app-if-one-is-not-available-to-handle-the-uri)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-156">For more info, see [Recommend an app if one is not available to handle the URI](#recommend-an-app-if-one-is-not-available-to-handle-the-uri).</span></span>

### <a name="call-launchuriasync-to-launch-a-uri"></a><span data-ttu-id="7e157-157">LaunchUriAsync を呼び出して URI を起動</span><span class="sxs-lookup"><span data-stu-id="7e157-157">Call LaunchUriAsync to launch a URI</span></span>

<span data-ttu-id="7e157-158">URI を起動するには、[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="7e157-158">Use the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch a URI.</span></span> <span data-ttu-id="7e157-159">このメソッドを呼び出すとき、アプリはユーザーに表示されるフォアグラウンド アプリである必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e157-159">When you call this method, your app must be the foreground app, that is, it must be visible to the user.</span></span> <span data-ttu-id="7e157-160">この要件は、ユーザーが制御を維持するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="7e157-160">This requirement helps ensure that the user remains in control.</span></span> <span data-ttu-id="7e157-161">この要件を満たすために、すべての URI 起動がアプリの UI に直接結び付けられていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7e157-161">To meet this requirement, make sure that you tie all URI launches directly to the UI of your app.</span></span> <span data-ttu-id="7e157-162">URI 起動を開始するには、常にユーザーがなんらかの操作を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e157-162">The user must always take some action to initiate a URI launch.</span></span> <span data-ttu-id="7e157-163">URI を起動しようとしたときにアプリがフォアグラウンドにない場合、起動は失敗し、エラー コールバックが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-163">If you attempt to launch a URI and your app isn't in the foreground, the launch will fail and your error callback will be invoked.</span></span>

<span data-ttu-id="7e157-164">最初に URI を表す [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/system.uri.aspx) オブジェクトを作成し、それを [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="7e157-164">First create a [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/system.uri.aspx) object to represent the URI, then pass that to the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method.</span></span> <span data-ttu-id="7e157-165">次の例のように、返される結果を使って呼び出しが成功したかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="7e157-165">Use the return result to see if the call succeeded, as shown in the following example.</span></span>

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

<span data-ttu-id="7e157-166">場合によって、ユーザーが実際にアプリを切り替えようとしているかどうかを確認するダイアログがオペレーティング システムにより表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-166">In some cases, the operating system will prompt the user to see if they actually want to switch apps.</span></span>

![灰色で表示されたアプリの背景にオーバーレイで表示された警告ダイアログ。](images/warningdialog.png)

<span data-ttu-id="7e157-170">この確認ダイアログを常に表示する場合は、[**Windows.System.LauncherOptions.TreatAsUntrusted**](https://msdn.microsoft.com/library/windows/apps/hh701442) プロパティを使って、オペレーティング システムが警告を表示することを指定します。</span><span class="sxs-lookup"><span data-stu-id="7e157-170">If you always want this prompt to occur, use the [**Windows.System.LauncherOptions.TreatAsUntrusted**](https://msdn.microsoft.com/library/windows/apps/hh701442) property to tell the operating system to display a warning.</span></span>

```cs
// The URI to launch
var uriBing = new Uri(@"http://www.bing.com");

// Set the option to show a warning
var promptOptions = new Windows.System.LauncherOptions();
promptOptions.TreatAsUntrusted = true;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
```

### <a name="recommend-an-app-if-one-is-not-available-to-handle-the-uri"></a><span data-ttu-id="7e157-171">URI を処理するアプリがない場合にアプリを推奨</span><span class="sxs-lookup"><span data-stu-id="7e157-171">Recommend an app if one is not available to handle the URI</span></span>

<span data-ttu-id="7e157-172">場合によっては、起動中の URI を処理するアプリがインストールされていないこともあります。</span><span class="sxs-lookup"><span data-stu-id="7e157-172">In some cases, the user might not have an app installed to handle the URI that you are launching.</span></span> <span data-ttu-id="7e157-173">既定では、オペレーティング システムによってストア上の適切なアプリを検索するリンクが表示されて、これらのケースは対処されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-173">By default, the operating system handles these cases by providing the user with a link to search for an appropriate app on the store.</span></span> <span data-ttu-id="7e157-174">このシナリオで入手する必要のあるアプリに関する特定の推奨事項を示す場合は、起動中の URI と共に推奨事項を渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-174">If you want to give the user a specific recommendation for which app to acquire in this scenario, you can do so by passing that recommendation along with the URI that you are launching.</span></span>

<span data-ttu-id="7e157-175">推奨事項は、URI スキームを処理するアプリが複数登録されているときにも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="7e157-175">Recommendations are also useful when more than one app has registered to handle a URI scheme.</span></span> <span data-ttu-id="7e157-176">特定のアプリを推奨すると、そのアプリが既にインストールされている場合、Windows はそのアプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="7e157-176">By recommending a specific app, Windows will open that app if it is already installed.</span></span>

<span data-ttu-id="7e157-177">アプリを推奨するには、[**LauncherOptions.preferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) を推奨するストア内のアプリのパッケージ ファミリ名に設定して、[**Windows.System.Launcher.LaunchUriAsync(Uri, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701484) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7e157-177">To make a recommendation, call the [**Windows.System.Launcher.LaunchUriAsync(Uri, LauncherOptions)**](https://msdn.microsoft.com/library/windows/apps/hh701484) method with [**LauncherOptions.preferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482) set to the package family name of the app in the store that you want to recommend.</span></span> <span data-ttu-id="7e157-178">オペレーティング システムではこの情報を使って、ストア内のアプリを検索する一般的なオプションを、ストアから推奨アプリを入手する固有のオプションに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7e157-178">The operating system uses this info to replace the general option to search for an app in the store with a specific option to acquire the recommended app from the store.</span></span>

```cs
// Set the recommended app
var options = new Windows.System.LauncherOptions();
options.PreferredApplicationPackageFamilyName = "Contoso.URIApp_8wknc82po1e";
options.PreferredApplicationDisplayName = "Contoso URI Ap";

// Launch the URI and pass in the recommended app
// in case the user has no apps installed to handle the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

### <a name="set-remaining-view-preference"></a><span data-ttu-id="7e157-179">残りの表示の基本設定</span><span class="sxs-lookup"><span data-stu-id="7e157-179">Set remaining view preference</span></span>

<span data-ttu-id="7e157-180">[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) を呼び出すソース アプリは、URI の起動後も画面上に留まることを要求できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-180">Source apps that call [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) can request that they remain on screen after a URI launch.</span></span> <span data-ttu-id="7e157-181">既定では、利用可能なスペース全体がソース アプリと URI を処理するターゲット アプリとで均等に共有されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-181">By default, Windows attempts to share all available space equally between the source app and the target app that handles the URI.</span></span> <span data-ttu-id="7e157-182">ソース アプリでは、[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) プロパティを使って、利用可能なスペースをソース アプリのウィンドウがどの程度占めるかをオペレーティング システムに指示できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-182">Source apps can use the [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) property to indicate to the operating system that they prefer their app window to take up more or less of the available space.</span></span> <span data-ttu-id="7e157-183">この **DesiredRemainingView** では、URI の起動後にソース アプリが画面上に留まる必要がなく、ターゲット アプリに完全に置き換わっても良いことも示せます。</span><span class="sxs-lookup"><span data-stu-id="7e157-183">**DesiredRemainingView** can also be used to indicate that the source app doesn't need to remain on screen after the URI launch and can be completely replaced by the target app.</span></span> <span data-ttu-id="7e157-184">このプロパティは呼び出し元アプリの優先ウィンドウのサイズだけを指定します。</span><span class="sxs-lookup"><span data-stu-id="7e157-184">This property only specifies the preferred window size of the calling app.</span></span> <span data-ttu-id="7e157-185">画面に同時に表示されている可能性のある他のアプリの動作は指定しません。</span><span class="sxs-lookup"><span data-stu-id="7e157-185">It doesn't specify the behavior of other apps that may happen to also be on screen at the same time.</span></span>

<span data-ttu-id="7e157-186">**注:** Windows では考慮複数の異なる要素など、ソース アプリの最終的なウィンドウのサイズを決定する場合、ソース アプリの基本設定、画面、画面の向き、上のアプリの数。</span><span class="sxs-lookup"><span data-stu-id="7e157-186">**Note**Windows takes into account multiple different factors when it determines the source app's final window size, for example, the preference of the source app, the number of apps on screen, the screen orientation, and so on.</span></span> <span data-ttu-id="7e157-187">[**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314) を設定しても、ソース アプリの特定のウィンドウ動作が保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="7e157-187">By setting [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314), you aren't guaranteed a specific windowing behavior for the source app.</span></span>

```cs
// Set the desired remaining view.
var options = new Windows.System.LauncherOptions();
options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

## <a name="uri-schemes"></a><span data-ttu-id="7e157-188">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-188">URI Schemes</span></span> ##

<span data-ttu-id="7e157-189">各種 URI スキームについて以下に説明します。</span><span class="sxs-lookup"><span data-stu-id="7e157-189">The various URI schemes are described below.</span></span>

### <a name="call-app-uri-scheme"></a><span data-ttu-id="7e157-190">通話アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-190">Call app URI scheme</span></span>

<span data-ttu-id="7e157-191">**ms-call:** URI スキームを使って、通話アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-191">Use the **ms-call:** URI scheme to launch the Call app.</span></span>

| <span data-ttu-id="7e157-192">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-192">URI Scheme</span></span>       | <span data-ttu-id="7e157-193">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-193">Result</span></span>                   |
|------------------|--------------------------|
| <span data-ttu-id="7e157-194">ms-call:settings</span><span class="sxs-lookup"><span data-stu-id="7e157-194">ms-call:settings</span></span> | <span data-ttu-id="7e157-195">アプリ設定のページを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7e157-195">Calls app settings page.</span></span> |

### <a name="email-uri-scheme"></a><span data-ttu-id="7e157-196">メールの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-196">Email URI scheme</span></span>

<span data-ttu-id="7e157-197">**mailto:** URI スキームを使って、既定のメール アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-197">Use the **mailto:** URI scheme to launch the default mail app.</span></span>

| <span data-ttu-id="7e157-198">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-198">URI Scheme</span></span> |<span data-ttu-id="7e157-199">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-199">Results</span></span>                          |
|------------|---------------------------------|
| <span data-ttu-id="7e157-200">mailto:</span><span class="sxs-lookup"><span data-stu-id="7e157-200">mailto:</span></span>    | <span data-ttu-id="7e157-201">既定のメール アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-201">Launches the default email app.</span></span> |
| <span data-ttu-id="7e157-202">mailto:\[email address\]</span><span class="sxs-lookup"><span data-stu-id="7e157-202">mailto:\[email address\]</span></span> | <span data-ttu-id="7e157-203">メール アプリを起動し、宛先行で指定されているメール アドレスを使用して新しいメッセージを作成します。</span><span class="sxs-lookup"><span data-stu-id="7e157-203">Launches the email app and creates a new message with the specified email address on the To line.</span></span> <span data-ttu-id="7e157-204">メールは、ユーザーが [送信] をタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="7e157-204">Note that the email is not sent until the user taps send.</span></span> |

### <a name="http-uri-scheme"></a><span data-ttu-id="7e157-205">HTTP の URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-205">HTTP URI scheme</span></span>

<span data-ttu-id="7e157-206">**http:** URI スキームを使って、既定の Web ブラウザーを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-206">Use the **http:** URI scheme to launch the default web browser.</span></span>

| <span data-ttu-id="7e157-207">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-207">URI Scheme</span></span> | <span data-ttu-id="7e157-208">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-208">Results</span></span>                           |
|------------|-----------------------------------|
| <span data-ttu-id="7e157-209">http:</span><span class="sxs-lookup"><span data-stu-id="7e157-209">http:</span></span>      | <span data-ttu-id="7e157-210">既定の Web ブラウザーを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-210">Launches the default web browser.</span></span> |

### <a name="maps-app-uri-schemes"></a><span data-ttu-id="7e157-211">マップ アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-211">Maps app URI schemes</span></span>

<span data-ttu-id="7e157-212">**bingmaps:**、**ms-drive-to:**、**ms-walk-to:** の各 URI スキームを使って、[Windows マップ アプリを起動し](launch-maps-app.md)、特定の地図、ルート案内、検索結果を表示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-212">Use the **bingmaps:**, **ms-drive-to:**, and **ms-walk-to:** URI schemes to [launch the Windows Maps app](launch-maps-app.md) to specific maps, directions, and search results.</span></span> <span data-ttu-id="7e157-213">たとえば、次の URI は、Windows マップ アプリを開き、ニューヨークを中心とした地図を表示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-213">For example, the following URI opens the Windows Maps app and displays a map centered over New York City.</span></span>

`bingmaps:?cp=40.726966~-74.006076`

![Windows マップ アプリの例。](images/mapnyc.png)

<span data-ttu-id="7e157-215">詳しくは、「[Windows マップ アプリの起動](launch-maps-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-215">For more info, see [Launch the Windows Maps app](launch-maps-app.md).</span></span> <span data-ttu-id="7e157-216">独自のアプリでマップ コントロールを使うには、「[2D、3D、Streetside ビューでの地図の表示](https://msdn.microsoft.com/library/windows/apps/mt219695)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-216">To use the map control in your own app, see [Display maps with 2D, 3D, and Streetside views](https://msdn.microsoft.com/library/windows/apps/mt219695).</span></span>

### <a name="messaging-app-uri-scheme"></a><span data-ttu-id="7e157-217">メッセージング アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-217">Messaging app URI scheme</span></span>

<span data-ttu-id="7e157-218">**ms-chat:** URI スキームを使って、Windows メッセージング アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-218">Use the **ms-chat:** URI scheme to launch the Windows Messaging app.</span></span>

| <span data-ttu-id="7e157-219">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-219">URI scheme</span></span> |<span data-ttu-id="7e157-220">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-220">Results</span></span> |
|------------|--------|
| <span data-ttu-id="7e157-221">ms-chat:</span><span class="sxs-lookup"><span data-stu-id="7e157-221">ms-chat:</span></span>   | <span data-ttu-id="7e157-222">メッセージング アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-222">Launches the Messaging app.</span></span> |
| <span data-ttu-id="7e157-223">ms-chat:?ContactID={contacted}</span><span class="sxs-lookup"><span data-stu-id="7e157-223">ms-chat:?ContactID={contacted}</span></span>  |  <span data-ttu-id="7e157-224">特定の連絡先の情報を使ってメッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="7e157-224">Allows the messaging application to be launched with a particular contact’s information.</span></span>   |
| <span data-ttu-id="7e157-225">ms-chat:?Body={body}</span><span class="sxs-lookup"><span data-stu-id="7e157-225">ms-chat:?Body={body}</span></span> | <span data-ttu-id="7e157-226">メッセージの内容として使用する文字列を使ってメッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="7e157-226">Allows the messaging application to be launched with a string to use as the content of the message.</span></span>|
| <span data-ttu-id="7e157-227">ms-chat:?Addresses={address}&Body={body}</span><span class="sxs-lookup"><span data-stu-id="7e157-227">ms-chat:?Addresses={address}&Body={body}</span></span> | <span data-ttu-id="7e157-228">特定のアドレスの情報とメッセージの内容として使用する文字列を使って、メッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="7e157-228">Allows the messaging application to be launched with a particular addresses' information, and with a string to use as the content of the message.</span></span> <span data-ttu-id="7e157-229">注: アドレスは連結することができます。</span><span class="sxs-lookup"><span data-stu-id="7e157-229">Note: Addresses can be concatenated.</span></span> |
| <span data-ttu-id="7e157-230">ms-chat:?TransportId={transportId}</span><span class="sxs-lookup"><span data-stu-id="7e157-230">ms-chat:?TransportId={transportId}</span></span>  | <span data-ttu-id="7e157-231">特定のトランスポート ID を使ってメッセージング アプリケーションを起動することを許可します。</span><span class="sxs-lookup"><span data-stu-id="7e157-231">Allows the messaging application to be launched with a particular transport ID.</span></span> |

### <a name="tone-picker-uri-scheme"></a><span data-ttu-id="7e157-232">トーンの選択コントロールの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-232">Tone picker URI scheme</span></span>

<span data-ttu-id="7e157-233">**ms-tonepicker:** URI スキームを使って、トーン、アラーム、システム音を選択します。</span><span class="sxs-lookup"><span data-stu-id="7e157-233">Use the **ms-tonepicker:** URI scheme to choose ringtones, alarms, and system tones.</span></span> <span data-ttu-id="7e157-234">また、新しいトーンを保存したり、トーンの名前を表示したりできます。</span><span class="sxs-lookup"><span data-stu-id="7e157-234">You can also save new ringtones and get the display name of a tone.</span></span>

| <span data-ttu-id="7e157-235">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-235">URI Scheme</span></span> | <span data-ttu-id="7e157-236">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-236">Results</span></span> |
|------------|---------|
| <span data-ttu-id="7e157-237">ms-tonepicker:</span><span class="sxs-lookup"><span data-stu-id="7e157-237">ms-tonepicker:</span></span> | <span data-ttu-id="7e157-238">トーン、アラーム、システム音を選択します。</span><span class="sxs-lookup"><span data-stu-id="7e157-238">Pick ringtones, alarms, and system tones.</span></span> |

<span data-ttu-id="7e157-239">パラメーターは [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を介して LaunchURI API に渡されます。</span><span class="sxs-lookup"><span data-stu-id="7e157-239">Parameters are passed via a [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) to the LaunchURI API.</span></span> <span data-ttu-id="7e157-240">詳しくは、「[ms-tonepicker URI スキームを使ったトーンの選択と保存](launch-ringtone-picker.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-240">See [Choose and save tones using the ms-tonepicker URI scheme](launch-ringtone-picker.md) for details.</span></span>

### <a name="nearby-numbers-app-uri-scheme"></a><span data-ttu-id="7e157-241">近隣の施設検索アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-241">Nearby Numbers app URI scheme</span></span>

<span data-ttu-id="7e157-242">**ms-yellowpage:** URI スキームを使って、近隣の施設検索アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-242">Use the **ms-yellowpage:** URI scheme to launch the Nearby Numbers app.</span></span>

| <span data-ttu-id="7e157-243">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-243">URI Scheme</span></span> | <span data-ttu-id="7e157-244">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-244">Results</span></span> |
|------------|---------|
| <span data-ttu-id="7e157-245">ms-yellowpage:?input=\[keyword\]&method=\[String または T9\]</span><span class="sxs-lookup"><span data-stu-id="7e157-245">ms-yellowpage:?input=\[keyword\]&method=\[String or T9\]</span></span> | <span data-ttu-id="7e157-246">近隣の施設検索アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-246">Launches the Nearby Numbers app.</span></span><br>`input` <span data-ttu-id="7e157-247">検索するキーワードを指定します。</span><span class="sxs-lookup"><span data-stu-id="7e157-247">refers to the keyword you want to search.</span></span><br>`method` <span data-ttu-id="7e157-248">検索の種類 (文字列検索か T9 検索) を指定します。</span><span class="sxs-lookup"><span data-stu-id="7e157-248">refers to the type of search (string or T9 search).</span></span><br><span data-ttu-id="7e157-249">`method` が `T9` (キーボードの種類) である場合、`keyword` は T9 キーボードの文字にマップされた数字の検索文字列になります。</span><span class="sxs-lookup"><span data-stu-id="7e157-249">If `method` is `T9` (a type of keyboard) then `keyword` should be a numeric string that maps to the T9 keyboard letters to search for.</span></span><br><span data-ttu-id="7e157-250">`method` が `String` の場合は、`keyword` は検索するキーワードになります。</span><span class="sxs-lookup"><span data-stu-id="7e157-250">If `method` is `String` then `keyword` is the keyword to search for.</span></span> |

### <a name="people-app-uri-scheme"></a><span data-ttu-id="7e157-251">People アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-251">People app URI scheme</span></span>

<span data-ttu-id="7e157-252">**ms-people:** URI スキームを使って、People アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-252">Use the **ms-people:** URI scheme to launch the People app.</span></span>
<span data-ttu-id="7e157-253">詳しくは、「[People アプリの起動](launch-people-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-253">For more info, see [Launch the People app](launch-people-apps.md).</span></span>

### <a name="photos-app-uri-scheme"></a><span data-ttu-id="7e157-254">フォト アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-254">Photos app URI scheme</span></span>

<span data-ttu-id="7e157-255">**ms-photos:** URI スキームを使ってフォト アプリを起動し、イメージを表示したり、ビデオを編集したりします。</span><span class="sxs-lookup"><span data-stu-id="7e157-255">Use the **ms-photos:** URI scheme to launch the Photos app to view an image or edit a video.</span></span> <span data-ttu-id="7e157-256">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-256">For example:</span></span>  
<span data-ttu-id="7e157-257">イメージを表示するには:</span><span class="sxs-lookup"><span data-stu-id="7e157-257">To view an image:</span></span> `ms-photos:viewer?fileName=c:\users\userName\Pictures\image.jpg`  
<span data-ttu-id="7e157-258">または、ビデオを編集するには:</span><span class="sxs-lookup"><span data-stu-id="7e157-258">Or to edit a video:</span></span> `ms-photos:videoedit?InputToken=123abc&Action=Trim&StartTime=01:02:03`  

> [!NOTE]
> <span data-ttu-id="7e157-259">ビデオを編集したり画像を表示するための URI は、デスクトップでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="7e157-259">The URIs to edit a video or display an image are only available on desktop.</span></span>

| <span data-ttu-id="7e157-260">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-260">URI scheme</span></span> |<span data-ttu-id="7e157-261">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-261">Results</span></span> |
|------------|--------|
| <span data-ttu-id="7e157-262">ms-photos:viewer?fileName={filename}</span><span class="sxs-lookup"><span data-stu-id="7e157-262">ms-photos:viewer?fileName={filename}</span></span> | <span data-ttu-id="7e157-263">フォト アプリを起動して指定したイメージを表示します。ここで、{filename} は完全修飾パス名です。</span><span class="sxs-lookup"><span data-stu-id="7e157-263">Launches the Photos app to view the specified image where {filename} is a fully-qualified path name.</span></span> <span data-ttu-id="7e157-264">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-264">For example:</span></span> `c:\users\userName\Pictures\ImageToView.jpg` |
| <span data-ttu-id="7e157-265">ms-photos:videoedit?InputToken={input token}</span><span class="sxs-lookup"><span data-stu-id="7e157-265">ms-photos:videoedit?InputToken={input token}</span></span> | <span data-ttu-id="7e157-266">ファイルのトークンで表されるファイルのビデオ編集モードでフォト アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-266">Launches the Photos app in video editing mode for the file represented by the file token.</span></span> <span data-ttu-id="7e157-267">**InputToken** は必須です。</span><span class="sxs-lookup"><span data-stu-id="7e157-267">**InputToken** is required.</span></span> <span data-ttu-id="7e157-268">[SharedStorageAccessManager](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager) を使用してファイルのトークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="7e157-268">Use the  [SharedStorageAccessManager](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.DataTransfer.SharedStorageAccessManager) to get a token for a file.</span></span> |
| <span data-ttu-id="7e157-269">ms-photos:videoedit?Action={action}</span><span class="sxs-lookup"><span data-stu-id="7e157-269">ms-photos:videoedit?Action={action}</span></span> | <span data-ttu-id="7e157-270">指定したビデオ編集モードでPhotosアプリケーションを開くオプションのパラメータ-で、{action} は次のいずれかです: **SlowMotion**、**FrameExtraction**、**トリム**、**表示**、**インク**します。</span><span class="sxs-lookup"><span data-stu-id="7e157-270">An optional parameter that opens the Photos app in the specified video editing mode where {action} is one of: **SlowMotion**, **FrameExtraction**, **Trim**, **View**, **Ink**.</span></span> <span data-ttu-id="7e157-271">何も指定しない場合の既定値は**表示**です。</span><span class="sxs-lookup"><span data-stu-id="7e157-271">If not specified, defaults to **View**</span></span> |
| <span data-ttu-id="7e157-272">ms-photos:videoedit?StartTime={timespan}</span><span class="sxs-lookup"><span data-stu-id="7e157-272">ms-photos:videoedit?StartTime={timespan}</span></span> | <span data-ttu-id="7e157-273">ビデオの再生を開始する場所を指定するオプションのパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="7e157-273">An optional parameter that specifies where to start playing the video.</span></span> `{timespan}` <span data-ttu-id="7e157-274">形式は `"hh:mm:ss.ffff"` を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7e157-274">must be in the format `"hh:mm:ss.ffff"`.</span></span> <span data-ttu-id="7e157-275">指定しない場合、既定で以下のようになります。</span><span class="sxs-lookup"><span data-stu-id="7e157-275">If not specified, defaults to</span></span> `00:00:00.0000` |

### <a name="settings-app-uri-scheme"></a><span data-ttu-id="7e157-276">設定アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-276">Settings app URI scheme</span></span>

<span data-ttu-id="7e157-277">**ms-settings:** URI スキームを使って、[Windows 設定アプリを起動](launch-settings-app.md)します。</span><span class="sxs-lookup"><span data-stu-id="7e157-277">Use the **ms-settings:** URI scheme to [launch the Windows Settings app](launch-settings-app.md).</span></span> <span data-ttu-id="7e157-278">設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。</span><span class="sxs-lookup"><span data-stu-id="7e157-278">Launching to the Settings app is an important part of writing a privacy-aware app.</span></span> <span data-ttu-id="7e157-279">アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7e157-279">If your app can't access a sensitive resource, we recommend providing the user a convenient link to the privacy settings for that resource.</span></span> <span data-ttu-id="7e157-280">たとえば、次の URI は設定アプリを開き、カメラのプライバシー設定を表示します。</span><span class="sxs-lookup"><span data-stu-id="7e157-280">For example, the following URI opens the Settings app and displays the camera privacy settings.</span></span>

`ms-settings:privacy-webcam`

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

<span data-ttu-id="7e157-282">詳しくは、「[Windows 設定アプリの起動](launch-settings-app.md)」と「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-282">For more info, see [Launch the Windows Settings app](launch-settings-app.md) and [Guidelines for privacy-aware apps](https://msdn.microsoft.com/library/windows/apps/hh768223).</span></span>

### <a name="store-app-uri-scheme"></a><span data-ttu-id="7e157-283">ストア アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-283">Store app URI scheme</span></span>

<span data-ttu-id="7e157-284">**ms-windows-store:** URI スキームを使って、[UWP アプリ](launch-store-app.md) を起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-284">Use the **ms-windows-store:** URI scheme to [Launch the UWP app](launch-store-app.md).</span></span> <span data-ttu-id="7e157-285">製品の詳細ページ、製品のレビュー ページ、検索ページなどを開きます。たとえば、次の URI は、UWP アプリを開き、Store のホーム ページを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-285">Open product detail pages, product review pages, and search pages, etc. For example, the following URI opens the UWP app and launches the home page of the Store.</span></span>

`ms-windows-store://home/`

<span data-ttu-id="7e157-286">詳しくは、「[UWP アプリの起動](launch-store-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7e157-286">For more info, see [Launch the UWP app](launch-store-app.md).</span></span>

### <a name="weather-app-uri-scheme"></a><span data-ttu-id="7e157-287">天気予報アプリの URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-287">Weather app URI scheme</span></span>

<span data-ttu-id="7e157-288">使用して、 **msnweather:** 天気予報アプリを起動する URI スキームします。</span><span class="sxs-lookup"><span data-stu-id="7e157-288">Use the **msnweather:** URI scheme to launch the Weather app.</span></span>

| <span data-ttu-id="7e157-289">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="7e157-289">URI Scheme</span></span> | <span data-ttu-id="7e157-290">結果</span><span class="sxs-lookup"><span data-stu-id="7e157-290">Results</span></span> |
|------------|---------|
| <span data-ttu-id="7e157-291">msnweather://forecast?la= \[latitude\] & lo = \ [longitude\]</span><span class="sxs-lookup"><span data-stu-id="7e157-291">msnweather://forecast?la=\[latitude\]&lo=\[longitude\]</span></span> | <span data-ttu-id="7e157-292">場所の地理的な座標に基づく予測ページで、天気予報アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="7e157-292">Launches the Weather app in the Forecast page based on a location geographic coordinates.</span></span><br>`latitude` <span data-ttu-id="7e157-293">場所の緯度を指します。</span><span class="sxs-lookup"><span data-stu-id="7e157-293">refers to the latitude of the location.</span></span><br> `longitude` <span data-ttu-id="7e157-294">場所の経度を指します。</span><span class="sxs-lookup"><span data-stu-id="7e157-294">refers to the longitude of the location.</span></span><br> |
