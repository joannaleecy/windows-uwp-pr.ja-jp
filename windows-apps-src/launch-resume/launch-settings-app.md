---
author: TylerMSFT
title: "Windows 設定アプリの起動"
description: "アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。"
ms.assetid: C84D4BEE-1FEE-4648-AD7D-8321EAC70290
ms.author: twhitney
ms.date: 06/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2a30e14f7c275c48f52253157fc9c67bf05d259e
ms.sourcegitcommit: 00c3f5a1208bd0125f5b275f972cf2a82d8eb9b6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/13/2017
---
# <a name="launch-the-windows-settings-app"></a><span data-ttu-id="408a7-106">Windows 設定アプリの起動</span><span class="sxs-lookup"><span data-stu-id="408a7-106">Launch the Windows Settings app</span></span>

<span data-ttu-id="408a7-107">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="408a7-107">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="408a7-108">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="408a7-108">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="408a7-109">重要な API</span><span class="sxs-lookup"><span data-stu-id="408a7-109">Important APIs</span></span>**

-   [**<span data-ttu-id="408a7-110">LaunchUriAsync</span><span class="sxs-lookup"><span data-stu-id="408a7-110">LaunchUriAsync</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**<span data-ttu-id="408a7-111">PreferredApplicationPackageFamilyName</span><span class="sxs-lookup"><span data-stu-id="408a7-111">PreferredApplicationPackageFamilyName</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**<span data-ttu-id="408a7-112">DesiredRemainingView</span><span class="sxs-lookup"><span data-stu-id="408a7-112">DesiredRemainingView</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn298314)

<span data-ttu-id="408a7-113">アプリから Windows 設定アプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="408a7-113">Learn how to launch the Windows Settings app from your app.</span></span> <span data-ttu-id="408a7-114">ここでは、**ms-settings:** URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="408a7-114">This topic describes the **ms-settings:** URI scheme.</span></span> <span data-ttu-id="408a7-115">Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。</span><span class="sxs-lookup"><span data-stu-id="408a7-115">Use this URI scheme to launch the Windows Settings app to specific settings pages.</span></span>

<span data-ttu-id="408a7-116">設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。</span><span class="sxs-lookup"><span data-stu-id="408a7-116">Launching to the Settings app is an important part of writing a privacy-aware app.</span></span> <span data-ttu-id="408a7-117">アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="408a7-117">If your app can't access a sensitive resource, we recommend providing the user a convenient link to the privacy settings for that resource.</span></span> <span data-ttu-id="408a7-118">詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="408a7-118">For more info, see [Guidelines for privacy-aware apps](https://msdn.microsoft.com/library/windows/apps/hh768223).</span></span>

## <a name="how-to-launch-the-settings-app"></a><span data-ttu-id="408a7-119">設定アプリを起動する方法</span><span class="sxs-lookup"><span data-stu-id="408a7-119">How to launch the Settings app</span></span>

<span data-ttu-id="408a7-120">**設定**アプリを起動するには、次の例に示されているように `ms-settings:` URI スキームを使います。</span><span class="sxs-lookup"><span data-stu-id="408a7-120">To launch the **Settings** app, use the `ms-settings:` URI scheme as shown in the following examples.</span></span>

<span data-ttu-id="408a7-121">この例では、ハイパーリンク XAML コントロールで `ms-settings:privacy-microphone` URI を使って、マイクのプライバシー設定ページを起動します。</span><span class="sxs-lookup"><span data-stu-id="408a7-121">In this example, a Hyperlink XAML control is used to launch the privacy settings page for the microphone using the `ms-settings:privacy-microphone` URI.</span></span>

```xml
<!--Set Visibility to Visible when access to the microphone is denied -->  
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic"
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access the microphone. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-microphone">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the microphone privacy settings."/>
</TextBlock>
```

<span data-ttu-id="408a7-122">また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="408a7-122">Alternatively, your app can call the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method to launch the **Settings** app from code.</span></span> <span data-ttu-id="408a7-123">次の例は、`ms-settings:privacy-webcam` URI を使って、カメラのプライバシー設定ページを起動する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="408a7-123">This example shows how to launch to the privacy settings page for the camera using the `ms-settings:privacy-webcam` URI.</span></span>

```cs
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
```

<span data-ttu-id="408a7-124">上記のコードでは、カメラのプライバシー設定ページが起動されます。</span><span class="sxs-lookup"><span data-stu-id="408a7-124">The code above launches the privacy settings page for the camera:</span></span>

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

<span data-ttu-id="408a7-126">URI の起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="408a7-126">For more info about launching URIs, see [Launch the default app for a URI](launch-default-app.md).</span></span>

## <a name="ms-settings-uri-scheme-reference"></a><span data-ttu-id="408a7-127">ms-settings: URI スキーム リファレンス</span><span class="sxs-lookup"><span data-stu-id="408a7-127">ms-settings: URI scheme reference</span></span>

<span data-ttu-id="408a7-128">設定アプリのさまざまなページ開くには、次の URI を使います。</span><span class="sxs-lookup"><span data-stu-id="408a7-128">Use the following URIs to open various pages of the Settings app.</span></span>

> <span data-ttu-id="408a7-129">設定ページを使用できるかどうかは、Windows の SKU によって異なることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="408a7-129">Note that whether a settings page is available varies by Windows SKU.</span></span> <span data-ttu-id="408a7-130">デスクトップの Windows 10 で利用可能な設定ページのすべてを Windows 10 Mobile で利用できるとは限りません。またその逆も同様です。</span><span class="sxs-lookup"><span data-stu-id="408a7-130">Not all settings page available on Windows 10 for desktop are available on Windows 10 Mobile, and vice-versa.</span></span> <span data-ttu-id="408a7-131">注の列には、ページが利用可能となるための追加の要件も記されています。</span><span class="sxs-lookup"><span data-stu-id="408a7-131">The notes column also captures additional requirements that must be met for a page to be available.</span></span>

<table border="1">
 <tr>
  <th><span data-ttu-id="408a7-132">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="408a7-132">Category</span></span></th>
  <th><span data-ttu-id="408a7-133">設定ページ</span><span class="sxs-lookup"><span data-stu-id="408a7-133">Settings page</span></span></th>
  <th><span data-ttu-id="408a7-134">URI</span><span class="sxs-lookup"><span data-stu-id="408a7-134">URI</span></span></th>
  <th><span data-ttu-id="408a7-135">注</span><span class="sxs-lookup"><span data-stu-id="408a7-135">Notes</span></span></th>
 </tr>
 <tr>
  <td rowspan="6"><span data-ttu-id="408a7-136">アカウント</span><span class="sxs-lookup"><span data-stu-id="408a7-136">Accounts</span></span></td>
  <td><span data-ttu-id="408a7-137">職場または学校にアクセスする</span><span class="sxs-lookup"><span data-stu-id="408a7-137">Access work or school</span></span></td>
  <td><span data-ttu-id="408a7-138">ms-settings:workplace</span><span class="sxs-lookup"><span data-stu-id="408a7-138">ms-settings:workplace</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-139">メール & アプリのアカウント</span><span class="sxs-lookup"><span data-stu-id="408a7-139">Email & app accounts</span></span></td>
  <td><span data-ttu-id="408a7-140">ms-settings:emailandaccounts</span><span class="sxs-lookup"><span data-stu-id="408a7-140">ms-settings:emailandaccounts</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-141">家族とその他のユーザー</span><span class="sxs-lookup"><span data-stu-id="408a7-141">Family & other people</span></span></td>
  <td><span data-ttu-id="408a7-142">ms-settings:otherusers</span><span class="sxs-lookup"><span data-stu-id="408a7-142">ms-settings:otherusers</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-143">サインイン オプション</span><span class="sxs-lookup"><span data-stu-id="408a7-143">Sign-in options</span></span></td>
  <td><span data-ttu-id="408a7-144">ms-settings:signinoptions</span><span class="sxs-lookup"><span data-stu-id="408a7-144">ms-settings:signinoptions</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-145">設定の同期</span><span class="sxs-lookup"><span data-stu-id="408a7-145">Sync your settings</span></span></td>
  <td><span data-ttu-id="408a7-146">ms-settings:sync</span><span class="sxs-lookup"><span data-stu-id="408a7-146">ms-settings:sync</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-147">ユーザーの情報</span><span class="sxs-lookup"><span data-stu-id="408a7-147">Your info</span></span></td>
  <td><span data-ttu-id="408a7-148">ms-settings:yourinfo</span><span class="sxs-lookup"><span data-stu-id="408a7-148">ms-settings:yourinfo</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="4"><span data-ttu-id="408a7-149">アプリ</span><span class="sxs-lookup"><span data-stu-id="408a7-149">Apps</span></span></td>
  <td><span data-ttu-id="408a7-150">アプリと機能</span><span class="sxs-lookup"><span data-stu-id="408a7-150">Apps & Features</span></span></td>
  <td><span data-ttu-id="408a7-151">ms-settings:appsfeatures</span><span class="sxs-lookup"><span data-stu-id="408a7-151">ms-settings:appsfeatures</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-152">Web サイト用のアプリ</span><span class="sxs-lookup"><span data-stu-id="408a7-152">Apps for websites</span></span></td>
  <td><span data-ttu-id="408a7-153">ms-settings:appsforwebsites</span><span class="sxs-lookup"><span data-stu-id="408a7-153">ms-settings:appsforwebsites</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-154">既定のアプリ</span><span class="sxs-lookup"><span data-stu-id="408a7-154">Default apps</span></span></td>
  <td><span data-ttu-id="408a7-155">ms-settings:defaultapps</span><span class="sxs-lookup"><span data-stu-id="408a7-155">ms-settings:defaultapps</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-156">アプリと機能</span><span class="sxs-lookup"><span data-stu-id="408a7-156">Apps & features</span></span></td>
  <td><span data-ttu-id="408a7-157">ms-settings:optionalfeatures</span><span class="sxs-lookup"><span data-stu-id="408a7-157">ms-settings:optionalfeatures</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="12"><span data-ttu-id="408a7-158">デバイス</span><span class="sxs-lookup"><span data-stu-id="408a7-158">Devices</span></span></td>
  <td><span data-ttu-id="408a7-159">USB</span><span class="sxs-lookup"><span data-stu-id="408a7-159">USB</span></span></td>
  <td><span data-ttu-id="408a7-160">ms-settings:usb</span><span class="sxs-lookup"><span data-stu-id="408a7-160">ms-settings:usb</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-161">オーディオと音声認識</span><span class="sxs-lookup"><span data-stu-id="408a7-161">Audio and speech</span></span></td>
  <td><span data-ttu-id="408a7-162">ms-settings:holographic-audio</span><span class="sxs-lookup"><span data-stu-id="408a7-162">ms-settings:holographic-audio</span></span></td>
  <td><span data-ttu-id="408a7-163">Mixed Reality ポータル アプリ (Windows ストアで入手可能) がインストールされている場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-163">Only available if the Mixed Reality Portal app is installed (available in the Windows Store)</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-164">自動再生</span><span class="sxs-lookup"><span data-stu-id="408a7-164">AutoPlay</span></span></td>
  <td><span data-ttu-id="408a7-165">ms-settings:autoplay</span><span class="sxs-lookup"><span data-stu-id="408a7-165">ms-settings:autoplay</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-166">タッチパッド</span><span class="sxs-lookup"><span data-stu-id="408a7-166">Touchpad</span></span></td>
  <td><span data-ttu-id="408a7-167">ms-settings:devices-touchpad</span><span class="sxs-lookup"><span data-stu-id="408a7-167">ms-settings:devices-touchpad</span></span></td>
  <td><span data-ttu-id="408a7-168">タッチパッドのハードウェアが存在する場合にのみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-168">Only available if touchpad hardware is present</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-169">ペンと Windows Ink</span><span class="sxs-lookup"><span data-stu-id="408a7-169">Pen & Windows Ink</span></span></td>
  <td><span data-ttu-id="408a7-170">ms-settings:pen</span><span class="sxs-lookup"><span data-stu-id="408a7-170">ms-settings:pen</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-171">プリンターとスキャナー</span><span class="sxs-lookup"><span data-stu-id="408a7-171">Printers & scanners</span></span></td>
  <td><span data-ttu-id="408a7-172">ms-settings:printers</span><span class="sxs-lookup"><span data-stu-id="408a7-172">ms-settings:printers</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-173">入力</span><span class="sxs-lookup"><span data-stu-id="408a7-173">Typing</span></span></td>
  <td><span data-ttu-id="408a7-174">ms-settings:typing</span><span class="sxs-lookup"><span data-stu-id="408a7-174">ms-settings:typing</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-175">ホイール</span><span class="sxs-lookup"><span data-stu-id="408a7-175">Wheel</span></span></td>
  <td><span data-ttu-id="408a7-176">ms-settings:wheel</span><span class="sxs-lookup"><span data-stu-id="408a7-176">ms-settings:wheel</span></span></td>
  <td><span data-ttu-id="408a7-177">Dial がペアリングされている場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-177">Only available if Dial is paired</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-178">既定のカメラ</span><span class="sxs-lookup"><span data-stu-id="408a7-178">Default camera</span></span></td>
  <td><span data-ttu-id="408a7-179">ms-settings:camera</span><span class="sxs-lookup"><span data-stu-id="408a7-179">ms-settings:camera</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-180">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="408a7-180">Bluetooth</span></span></td>
  <td><span data-ttu-id="408a7-181">ms-settings:bluetooth</span><span class="sxs-lookup"><span data-stu-id="408a7-181">ms-settings:bluetooth</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-182">接続されたデバイス</span><span class="sxs-lookup"><span data-stu-id="408a7-182">Connected Devices</span></span></td>
  <td><span data-ttu-id="408a7-183">ms-settings:connecteddevices</span><span class="sxs-lookup"><span data-stu-id="408a7-183">ms-settings:connecteddevices</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-184">マウスとタッチパッド</span><span class="sxs-lookup"><span data-stu-id="408a7-184">Mouse & touchpad</span></span></td>
  <td><span data-ttu-id="408a7-185">ms-settings:mousetouchpad</span><span class="sxs-lookup"><span data-stu-id="408a7-185">ms-settings:mousetouchpad</span></span></td>
  <td><span data-ttu-id="408a7-186">タッチパット設定は、タッチパッドが搭載されているデバイスでのみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-186">Touchpad settings only available on devices that have a touchpad</span></span></td>
 </tr>
 <tr>
  <td rowspan="7"><span data-ttu-id="408a7-187">コンピューターの簡単操作</span><span class="sxs-lookup"><span data-stu-id="408a7-187">Ease of Access</span></span></td>
  <td><span data-ttu-id="408a7-188">ナレーター</span><span class="sxs-lookup"><span data-stu-id="408a7-188">Narrator</span></span></td>
  <td><span data-ttu-id="408a7-189">ms-settings:easeofaccess-narrator</span><span class="sxs-lookup"><span data-stu-id="408a7-189">ms-settings:easeofaccess-narrator</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-190">拡大鏡</span><span class="sxs-lookup"><span data-stu-id="408a7-190">Magnifier</span></span></td>
  <td><span data-ttu-id="408a7-191">ms-settings:easeofaccess-magnifier</span><span class="sxs-lookup"><span data-stu-id="408a7-191">ms-settings:easeofaccess-magnifier</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-192">ハイ コントラスト</span><span class="sxs-lookup"><span data-stu-id="408a7-192">High contrast</span></span></td>
  <td><span data-ttu-id="408a7-193">ms-settings:easeofaccess-highcontrast</span><span class="sxs-lookup"><span data-stu-id="408a7-193">ms-settings:easeofaccess-highcontrast</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-194">字幕</span><span class="sxs-lookup"><span data-stu-id="408a7-194">Closed captions</span></span></td>
  <td><span data-ttu-id="408a7-195">ms-settings:easeofaccess-closedcaptioning</span><span class="sxs-lookup"><span data-stu-id="408a7-195">ms-settings:easeofaccess-closedcaptioning</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-196">キーボード</span><span class="sxs-lookup"><span data-stu-id="408a7-196">Keyboard</span></span></td>
  <td><span data-ttu-id="408a7-197">ms-settings:easeofaccess-keyboard</span><span class="sxs-lookup"><span data-stu-id="408a7-197">ms-settings:easeofaccess-keyboard</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-198">マウス</span><span class="sxs-lookup"><span data-stu-id="408a7-198">Mouse</span></span></td>
  <td><span data-ttu-id="408a7-199">ms-settings:easeofaccess-mouse</span><span class="sxs-lookup"><span data-stu-id="408a7-199">ms-settings:easeofaccess-mouse</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-200">その他のオプション</span><span class="sxs-lookup"><span data-stu-id="408a7-200">Other options</span></span></td>
  <td><span data-ttu-id="408a7-201">ms-settings:easeofaccess-otheroptions</span><span class="sxs-lookup"><span data-stu-id="408a7-201">ms-settings:easeofaccess-otheroptions</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-202">Extras</span><span class="sxs-lookup"><span data-stu-id="408a7-202">Extras</span></span></td>
  <td><span data-ttu-id="408a7-203">Extras</span><span class="sxs-lookup"><span data-stu-id="408a7-203">Extras</span></span></td>
  <td><span data-ttu-id="408a7-204">ms-settings:extras</span><span class="sxs-lookup"><span data-stu-id="408a7-204">ms-settings:extras</span></span></td>
  <td><span data-ttu-id="408a7-205">(サード パーティなどによる) "設定アプリ" がインストールされている場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-205">Only available if "settings apps" are installed (e.g. by 3rd party)</span></span></td>
 </tr>
 <tr>
  <td rowspan="4"><span data-ttu-id="408a7-206">ゲーム</span><span class="sxs-lookup"><span data-stu-id="408a7-206">Gaming</span></span></td>
  <td><span data-ttu-id="408a7-207">ブロードキャスト</span><span class="sxs-lookup"><span data-stu-id="408a7-207">Broadcasting</span></span></td>
  <td><span data-ttu-id="408a7-208">ms-settings:gaming-broadcasting</span><span class="sxs-lookup"><span data-stu-id="408a7-208">ms-settings:gaming-broadcasting</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-209">ゲーム バー</span><span class="sxs-lookup"><span data-stu-id="408a7-209">Game bar</span></span></td>
  <td><span data-ttu-id="408a7-210">ms-settings:gaming-gamebar</span><span class="sxs-lookup"><span data-stu-id="408a7-210">ms-settings:gaming-gamebar</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-211">ゲーム DVR</span><span class="sxs-lookup"><span data-stu-id="408a7-211">Game DVR</span></span></td>
  <td><span data-ttu-id="408a7-212">ms-settings:gaming-gamedvr</span><span class="sxs-lookup"><span data-stu-id="408a7-212">ms-settings:gaming-gamedvr</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-213">ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="408a7-213">Game Mode</span></span></td>
  <td><span data-ttu-id="408a7-214">ms-settings:gaming-gamemode</span><span class="sxs-lookup"><span data-stu-id="408a7-214">ms-settings:gaming-gamemode</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-215">ホーム ページ</span><span class="sxs-lookup"><span data-stu-id="408a7-215">Home page</span></span></td>
  <td><span data-ttu-id="408a7-216">設定のランディング ページ</span><span class="sxs-lookup"><span data-stu-id="408a7-216">Landing page for Settings</span></span></td>
  <td><span data-ttu-id="408a7-217">ms-settings:</span><span class="sxs-lookup"><span data-stu-id="408a7-217">ms-settings:</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="10"><span data-ttu-id="408a7-218">ネットワークとインターネット</span><span class="sxs-lookup"><span data-stu-id="408a7-218">Network & internet</span></span></td>
  <td><span data-ttu-id="408a7-219">イーサネット</span><span class="sxs-lookup"><span data-stu-id="408a7-219">Ethernet</span></span></td>
  <td><span data-ttu-id="408a7-220">ms-settings:network-ethernet</span><span class="sxs-lookup"><span data-stu-id="408a7-220">ms-settings:network-ethernet</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-221">VPN</span><span class="sxs-lookup"><span data-stu-id="408a7-221">VPN</span></span></td>
  <td><span data-ttu-id="408a7-222">ms-settings:network-vpn</span><span class="sxs-lookup"><span data-stu-id="408a7-222">ms-settings:network-vpn</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-223">ダイヤルアップ</span><span class="sxs-lookup"><span data-stu-id="408a7-223">Dial-up</span></span></td>
  <td><span data-ttu-id="408a7-224">ms-settings:network-dialup</span><span class="sxs-lookup"><span data-stu-id="408a7-224">ms-settings:network-dialup</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-225">DirectAccess</span><span class="sxs-lookup"><span data-stu-id="408a7-225">DirectAccess</span></span></td>
  <td><span data-ttu-id="408a7-226">ms-settings:network-directaccess</span><span class="sxs-lookup"><span data-stu-id="408a7-226">ms-settings:network-directaccess</span></span></td>
  <td><span data-ttu-id="408a7-227">DirectAccess が有効な場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-227">Only available if DirectAccess is enabled</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-228">Wi-Fi 通話</span><span class="sxs-lookup"><span data-stu-id="408a7-228">Wi-Fi Calling</span></span></td>
  <td><span data-ttu-id="408a7-229">ms-settings:network-wificalling</span><span class="sxs-lookup"><span data-stu-id="408a7-229">ms-settings:network-wificalling</span></span></td>
  <td><span data-ttu-id="408a7-230">Wi-Fi 通話が有効な場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-230">Only available if Wi-Fi calling is enabled</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-231">データ使用状況</span><span class="sxs-lookup"><span data-stu-id="408a7-231">Data usage</span></span></td>
  <td><span data-ttu-id="408a7-232">ms-settings:datausage</span><span class="sxs-lookup"><span data-stu-id="408a7-232">ms-settings:datausage</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-233">携帯ネットワーク & SIM</span><span class="sxs-lookup"><span data-stu-id="408a7-233">Cellular & SIM</span></span></td>
  <td><span data-ttu-id="408a7-234">ms-settings:network-cellular</span><span class="sxs-lookup"><span data-stu-id="408a7-234">ms-settings:network-cellular</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-235">モバイル ホットスポット</span><span class="sxs-lookup"><span data-stu-id="408a7-235">Mobile hotspot</span></span></td>
  <td><span data-ttu-id="408a7-236">ms-settings:network-mobilehotspot</span><span class="sxs-lookup"><span data-stu-id="408a7-236">ms-settings:network-mobilehotspot</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-237">プロキシ</span><span class="sxs-lookup"><span data-stu-id="408a7-237">Proxy</span></span></td>
  <td><span data-ttu-id="408a7-238">ms-settings:network-proxy</span><span class="sxs-lookup"><span data-stu-id="408a7-238">ms-settings:network-proxy</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-239">状態</span><span class="sxs-lookup"><span data-stu-id="408a7-239">Status</span></span></td>
  <td><span data-ttu-id="408a7-240">ms-settings:network-status</span><span class="sxs-lookup"><span data-stu-id="408a7-240">ms-settings:network-status</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-241">既知のネットワークの管理</span><span class="sxs-lookup"><span data-stu-id="408a7-241">Manage known networks</span></span></td>
  <td><span data-ttu-id="408a7-242">ms-settings:network-wifisettings</span><span class="sxs-lookup"><span data-stu-id="408a7-242">ms-settings:network-wifisettings</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="3"><span data-ttu-id="408a7-243">ネットワークとワイヤレス</span><span class="sxs-lookup"><span data-stu-id="408a7-243">Network & wireless</span></span></td>
  <td><span data-ttu-id="408a7-244">NFC</span><span class="sxs-lookup"><span data-stu-id="408a7-244">NFC</span></span></td>
  <td><span data-ttu-id="408a7-245">ms-settings:nfctransactions</span><span class="sxs-lookup"><span data-stu-id="408a7-245">ms-settings:nfctransactions</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-246">Wi-Fi</span><span class="sxs-lookup"><span data-stu-id="408a7-246">Wi-Fi</span></span></td>
  <td><span data-ttu-id="408a7-247">ms-settings:network-wifi</span><span class="sxs-lookup"><span data-stu-id="408a7-247">ms-settings:network-wifi</span></span></td>
  <td><span data-ttu-id="408a7-248">デバイスに WiFi アダプターがある場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-248">Only available if the device has a wifi adaptor</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-249">機内モード</span><span class="sxs-lookup"><span data-stu-id="408a7-249">Airplane mode</span></span></td>
  <td><span data-ttu-id="408a7-250">ms-settings:network-airplanemode</span><span class="sxs-lookup"><span data-stu-id="408a7-250">ms-settings:network-airplanemode</span></span></td>
  <td><span data-ttu-id="408a7-251">Windows 8.x では ms-settings:proximity を使用する</span><span class="sxs-lookup"><span data-stu-id="408a7-251">Use ms-settings:proximity on Windows 8.x</span></span></td>
 </tr>
 <tr>
  <td rowspan="10"><span data-ttu-id="408a7-252">パーソナル設定</span><span class="sxs-lookup"><span data-stu-id="408a7-252">Personalization</span></span></td>
  <td><span data-ttu-id="408a7-253">スタート</span><span class="sxs-lookup"><span data-stu-id="408a7-253">Start</span></span></td>
  <td><span data-ttu-id="408a7-254">ms-settings:personalization-start</span><span class="sxs-lookup"><span data-stu-id="408a7-254">ms-settings:personalization-start</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-255">テーマ</span><span class="sxs-lookup"><span data-stu-id="408a7-255">Themes</span></span></td>
  <td><span data-ttu-id="408a7-256">ms-settings:themes</span><span class="sxs-lookup"><span data-stu-id="408a7-256">ms-settings:themes</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-257">概要</span><span class="sxs-lookup"><span data-stu-id="408a7-257">Glance</span></span></td>
  <td><span data-ttu-id="408a7-258">ms-settings:personalization-glance</span><span class="sxs-lookup"><span data-stu-id="408a7-258">ms-settings:personalization-glance</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-259">ナビゲーション バー</span><span class="sxs-lookup"><span data-stu-id="408a7-259">Navigation bar</span></span></td>
  <td><span data-ttu-id="408a7-260">ms-settings:personalization-navbar</span><span class="sxs-lookup"><span data-stu-id="408a7-260">ms-settings:personalization-navbar</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-261">個人用設定 (カテゴリ)</span><span class="sxs-lookup"><span data-stu-id="408a7-261">Personalization (category)</span></span></td>
   <td><span data-ttu-id="408a7-262">ms-settings:personalization</span><span class="sxs-lookup"><span data-stu-id="408a7-262">ms-settings:personalization</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-263">背景</span><span class="sxs-lookup"><span data-stu-id="408a7-263">Background</span></span></td>
   <td><span data-ttu-id="408a7-264">ms-settings:personalization-background</span><span class="sxs-lookup"><span data-stu-id="408a7-264">ms-settings:personalization-background</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-265">画面の色</span><span class="sxs-lookup"><span data-stu-id="408a7-265">Colors</span></span></td>
   <td><span data-ttu-id="408a7-266">ms-settings:personalization-colors</span><span class="sxs-lookup"><span data-stu-id="408a7-266">ms-settings:personalization-colors</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-267">サウンド</span><span class="sxs-lookup"><span data-stu-id="408a7-267">Sounds</span></span></td>
   <td><span data-ttu-id="408a7-268">ms-settings:sounds</span><span class="sxs-lookup"><span data-stu-id="408a7-268">ms-settings:sounds</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-269">ロック画面</span><span class="sxs-lookup"><span data-stu-id="408a7-269">Lock screen</span></span></td>
   <td><span data-ttu-id="408a7-270">ms-settings:lockscreen</span><span class="sxs-lookup"><span data-stu-id="408a7-270">ms-settings:lockscreen</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-271">タスク バー</span><span class="sxs-lookup"><span data-stu-id="408a7-271">Task Bar</span></span></td>
   <td><span data-ttu-id="408a7-272">ms-settings:taskbar</span><span class="sxs-lookup"><span data-stu-id="408a7-272">ms-settings:taskbar</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td rowspan="22"><span data-ttu-id="408a7-273">プライバシー</span><span class="sxs-lookup"><span data-stu-id="408a7-273">Privacy</span></span></td>
  <td><span data-ttu-id="408a7-274">アプリの診断</span><span class="sxs-lookup"><span data-stu-id="408a7-274">App diagnostics</span></span></td>
   <td><span data-ttu-id="408a7-275">ms-settings:privacy-appdiagnostics</span><span class="sxs-lookup"><span data-stu-id="408a7-275">ms-settings:privacy-appdiagnostics</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-276">通知</span><span class="sxs-lookup"><span data-stu-id="408a7-276">Notifications</span></span></td>
   <td><span data-ttu-id="408a7-277">ms-settings:privacy-notifications</span><span class="sxs-lookup"><span data-stu-id="408a7-277">ms-settings:privacy-notifications</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-278">タスク</span><span class="sxs-lookup"><span data-stu-id="408a7-278">Tasks</span></span></td>
   <td><span data-ttu-id="408a7-279">ms-settings:privacy-tasks</span><span class="sxs-lookup"><span data-stu-id="408a7-279">ms-settings:privacy-tasks</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-280">全般</span><span class="sxs-lookup"><span data-stu-id="408a7-280">General</span></span></td>
   <td><span data-ttu-id="408a7-281">ms-settings:privacy-general</span><span class="sxs-lookup"><span data-stu-id="408a7-281">ms-settings:privacy-general</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-282">アクセサリ用アプリ</span><span class="sxs-lookup"><span data-stu-id="408a7-282">Accessory apps</span></span></td>
   <td><span data-ttu-id="408a7-283">ms-settings:privacy-accessoryapps</span><span class="sxs-lookup"><span data-stu-id="408a7-283">ms-settings:privacy-accessoryapps</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-284">広告識別子</span><span class="sxs-lookup"><span data-stu-id="408a7-284">Advertising ID</span></span></td>
   <td><span data-ttu-id="408a7-285">ms-settings:privacy-advertisingid</span><span class="sxs-lookup"><span data-stu-id="408a7-285">ms-settings:privacy-advertisingid</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-286">通話</span><span class="sxs-lookup"><span data-stu-id="408a7-286">Phone calls</span></span></td>
   <td><span data-ttu-id="408a7-287">ms-settings:privacy-phonecall</span><span class="sxs-lookup"><span data-stu-id="408a7-287">ms-settings:privacy-phonecall</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-288">場所</span><span class="sxs-lookup"><span data-stu-id="408a7-288">Location</span></span></td>
   <td><span data-ttu-id="408a7-289">ms-settings:privacy-location</span><span class="sxs-lookup"><span data-stu-id="408a7-289">ms-settings:privacy-location</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-290">カメラ</span><span class="sxs-lookup"><span data-stu-id="408a7-290">Camera</span></span></td>
   <td><span data-ttu-id="408a7-291">ms-settings:privacy-webcam</span><span class="sxs-lookup"><span data-stu-id="408a7-291">ms-settings:privacy-webcam</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-292">マイク</span><span class="sxs-lookup"><span data-stu-id="408a7-292">Microphone</span></span></td>
   <td><span data-ttu-id="408a7-293">ms-settings:privacy-microphone</span><span class="sxs-lookup"><span data-stu-id="408a7-293">ms-settings:privacy-microphone</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-294">モーション</span><span class="sxs-lookup"><span data-stu-id="408a7-294">Motion</span></span></td>
   <td><span data-ttu-id="408a7-295">ms-settings:privacy-motion</span><span class="sxs-lookup"><span data-stu-id="408a7-295">ms-settings:privacy-motion</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-296">音声認識、手描き入力、入力の設定</span><span class="sxs-lookup"><span data-stu-id="408a7-296">Speech, inking & typing</span></span></td>
   <td><span data-ttu-id="408a7-297">ms-settings:privacy-speechtyping</span><span class="sxs-lookup"><span data-stu-id="408a7-297">ms-settings:privacy-speechtyping</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-298">アカウント情報</span><span class="sxs-lookup"><span data-stu-id="408a7-298">Account info</span></span></td>
   <td><span data-ttu-id="408a7-299">ms-settings:privacy-accountinfo</span><span class="sxs-lookup"><span data-stu-id="408a7-299">ms-settings:privacy-accountinfo</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-300">連絡先</span><span class="sxs-lookup"><span data-stu-id="408a7-300">Contacts</span></span></td>
   <td><span data-ttu-id="408a7-301">ms-settings:privacy-contacts</span><span class="sxs-lookup"><span data-stu-id="408a7-301">ms-settings:privacy-contacts</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-302">カレンダー</span><span class="sxs-lookup"><span data-stu-id="408a7-302">Calendar</span></span></td>
   <td><span data-ttu-id="408a7-303">ms-settings:privacy-calendar</span><span class="sxs-lookup"><span data-stu-id="408a7-303">ms-settings:privacy-calendar</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-304">通話履歴</span><span class="sxs-lookup"><span data-stu-id="408a7-304">Call history</span></span></td>
   <td><span data-ttu-id="408a7-305">ms-settings:privacy-callhistory</span><span class="sxs-lookup"><span data-stu-id="408a7-305">ms-settings:privacy-callhistory</span></span></td>
   <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-306">メール</span><span class="sxs-lookup"><span data-stu-id="408a7-306">Email</span></span></td>
  <td><span data-ttu-id="408a7-307">ms-settings:privacy-email</span><span class="sxs-lookup"><span data-stu-id="408a7-307">ms-settings:privacy-email</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-308">メッセージング</span><span class="sxs-lookup"><span data-stu-id="408a7-308">Messaging</span></span></td>
    <td><span data-ttu-id="408a7-309">ms-settings:privacy-messaging</span><span class="sxs-lookup"><span data-stu-id="408a7-309">ms-settings:privacy-messaging</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-310">無線</span><span class="sxs-lookup"><span data-stu-id="408a7-310">Radios</span></span></td>
    <td><span data-ttu-id="408a7-311">ms-settings:privacy-radios</span><span class="sxs-lookup"><span data-stu-id="408a7-311">ms-settings:privacy-radios</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-312">バックグラウンド アプリ</span><span class="sxs-lookup"><span data-stu-id="408a7-312">Background Apps</span></span></td>
    <td><span data-ttu-id="408a7-313">ms-settings:privacy-backgroundapps</span><span class="sxs-lookup"><span data-stu-id="408a7-313">ms-settings:privacy-backgroundapps</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-314">他のデバイス</span><span class="sxs-lookup"><span data-stu-id="408a7-314">Other devices</span></span></td>
    <td><span data-ttu-id="408a7-315">ms-settings:privacy-customdevices</span><span class="sxs-lookup"><span data-stu-id="408a7-315">ms-settings:privacy-customdevices</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-316">フィードバックと診断</span><span class="sxs-lookup"><span data-stu-id="408a7-316">Feedback & diagnostics</span></span></td>
    <td><span data-ttu-id="408a7-317">ms-settings:privacy-feedback</span><span class="sxs-lookup"><span data-stu-id="408a7-317">ms-settings:privacy-feedback</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="5"><span data-ttu-id="408a7-318">Surface Hub</span><span class="sxs-lookup"><span data-stu-id="408a7-318">Surface Hub</span></span></td>
  <td><span data-ttu-id="408a7-319">アカウント</span><span class="sxs-lookup"><span data-stu-id="408a7-319">Accounts</span></span></td>
    <td><span data-ttu-id="408a7-320">ms-settings:surfacehub-accounts</span><span class="sxs-lookup"><span data-stu-id="408a7-320">ms-settings:surfacehub-accounts</span></span></td>
      <td></td>
  </tr>
  <tr>
    <td><span data-ttu-id="408a7-321">チーム会議</span><span class="sxs-lookup"><span data-stu-id="408a7-321">Team Conferencing</span></span></td>
      <td><span data-ttu-id="408a7-322">ms-settings:surfacehub-calling</span><span class="sxs-lookup"><span data-stu-id="408a7-322">ms-settings:surfacehub-calling</span></span></td>
      <td></td>
  </tr>
  <tr>
    <td><span data-ttu-id="408a7-323">チーム デバイス管理</span><span class="sxs-lookup"><span data-stu-id="408a7-323">Team device management</span></span></td>
      <td><span data-ttu-id="408a7-324">ms-settings:surfacehub-devicemanagenent</span><span class="sxs-lookup"><span data-stu-id="408a7-324">ms-settings:surfacehub-devicemanagenent</span></span></td>
      <td></td>
  </tr>
  <tr>
    <td><span data-ttu-id="408a7-325">セッションのクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="408a7-325">Session cleanup</span></span></td>
      <td><span data-ttu-id="408a7-326">ms-settings:surfacehub-sessioncleanup</span><span class="sxs-lookup"><span data-stu-id="408a7-326">ms-settings:surfacehub-sessioncleanup</span></span></td>
      <td></td>
  </tr>
  <tr>
    <td><span data-ttu-id="408a7-327">ようこそ画面</span><span class="sxs-lookup"><span data-stu-id="408a7-327">Welcome screen</span></span></td>
      <td><span data-ttu-id="408a7-328">ms-settings:surfacehub-welcome</span><span class="sxs-lookup"><span data-stu-id="408a7-328">ms-settings:surfacehub-welcome</span></span></td>
      <td></td>
  </tr>
    <td rowspan="19"><span data-ttu-id="408a7-329">システム</span><span class="sxs-lookup"><span data-stu-id="408a7-329">System</span></span></td>
    <td><span data-ttu-id="408a7-330">共有エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="408a7-330">Shared experiences</span></span></td>
      <td><span data-ttu-id="408a7-331">ms-settings:crossdevice</span><span class="sxs-lookup"><span data-stu-id="408a7-331">ms-settings:crossdevice</span></span></td>
    <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-332">ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="408a7-332">Display</span></span></td>
    <td><span data-ttu-id="408a7-333">ms-settings:display</span><span class="sxs-lookup"><span data-stu-id="408a7-333">ms-settings:display</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-334">マルチタスク</span><span class="sxs-lookup"><span data-stu-id="408a7-334">Multitasking</span></span></td>
    <td><span data-ttu-id="408a7-335">ms-settings:multitasking</span><span class="sxs-lookup"><span data-stu-id="408a7-335">ms-settings:multitasking</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-336">この PC へのプロジェクション</span><span class="sxs-lookup"><span data-stu-id="408a7-336">Projecting to this PC</span></span></td>
    <td><span data-ttu-id="408a7-337">ms-settings:project</span><span class="sxs-lookup"><span data-stu-id="408a7-337">ms-settings:project</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-338">タブレット モード</span><span class="sxs-lookup"><span data-stu-id="408a7-338">Tablet mode</span></span></td>
    <td><span data-ttu-id="408a7-339">ms-settings:tabletmode</span><span class="sxs-lookup"><span data-stu-id="408a7-339">ms-settings:tabletmode</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-340">タスク バー</span><span class="sxs-lookup"><span data-stu-id="408a7-340">Taskbar</span></span></td>
    <td><span data-ttu-id="408a7-341">ms-settings:taskbar</span><span class="sxs-lookup"><span data-stu-id="408a7-341">ms-settings:taskbar</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-342">電話</span><span class="sxs-lookup"><span data-stu-id="408a7-342">Phone</span></span></td>
    <td><span data-ttu-id="408a7-343">ms-settings:phone-defaultapps</span><span class="sxs-lookup"><span data-stu-id="408a7-343">ms-settings:phone-defaultapps</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-344">ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="408a7-344">Display</span></span></td>
    <td><span data-ttu-id="408a7-345">ms-settings:screenrotation</span><span class="sxs-lookup"><span data-stu-id="408a7-345">ms-settings:screenrotation</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-346">通知とアクション</span><span class="sxs-lookup"><span data-stu-id="408a7-346">Notifications & actions</span></span></td>
    <td><span data-ttu-id="408a7-347">ms-settings:notifications</span><span class="sxs-lookup"><span data-stu-id="408a7-347">ms-settings:notifications</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-348">電話</span><span class="sxs-lookup"><span data-stu-id="408a7-348">Phone</span></span></td>
    <td><span data-ttu-id="408a7-349">ms-settings:phone</span><span class="sxs-lookup"><span data-stu-id="408a7-349">ms-settings:phone</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-350">メッセージング</span><span class="sxs-lookup"><span data-stu-id="408a7-350">Messaging</span></span></td>
    <td><span data-ttu-id="408a7-351">ms-settings:messaging</span><span class="sxs-lookup"><span data-stu-id="408a7-351">ms-settings:messaging</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-352">バッテリー節約機能</span><span class="sxs-lookup"><span data-stu-id="408a7-352">Battery Saver</span></span></td>
  <td><span data-ttu-id="408a7-353">ms-settings:batterysaver</span><span class="sxs-lookup"><span data-stu-id="408a7-353">ms-settings:batterysaver</span></span></td>
  <td><span data-ttu-id="408a7-354">タブレットなど、バッテリーを搭載したデバイスでのみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-354">Only available on devices that have a battery, such as a tablet</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-355">バッテリーの使用状況</span><span class="sxs-lookup"><span data-stu-id="408a7-355">Battery use</span></span></td>
  <td><span data-ttu-id="408a7-356">ms-settings:batterysaver-usagedetails</span><span class="sxs-lookup"><span data-stu-id="408a7-356">ms-settings:batterysaver-usagedetails</span></span></td>
  <td><span data-ttu-id="408a7-357">タブレットなど、バッテリーを搭載したデバイスでのみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-357">Only available on devices that have a battery, such as a tablet</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-358">電源とスリープ</span><span class="sxs-lookup"><span data-stu-id="408a7-358">Power & sleep</span></span></td>
  <td><span data-ttu-id="408a7-359">ms-settings:powersleep</span><span class="sxs-lookup"><span data-stu-id="408a7-359">ms-settings:powersleep</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-360">バージョン情報</span><span class="sxs-lookup"><span data-stu-id="408a7-360">About</span></span></td>
    <td><span data-ttu-id="408a7-361">ms-settings:about</span><span class="sxs-lookup"><span data-stu-id="408a7-361">ms-settings:about</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-362">ストレージ</span><span class="sxs-lookup"><span data-stu-id="408a7-362">Storage</span></span></td>
    <td><span data-ttu-id="408a7-363">ms-settings:storagesense</span><span class="sxs-lookup"><span data-stu-id="408a7-363">ms-settings:storagesense</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-364">ストレージ センサー</span><span class="sxs-lookup"><span data-stu-id="408a7-364">Storage Sense</span></span></td>
    <td><span data-ttu-id="408a7-365">ms-settings:storagepolicies</span><span class="sxs-lookup"><span data-stu-id="408a7-365">ms-settings:storagepolicies</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-366">暗号化</span><span class="sxs-lookup"><span data-stu-id="408a7-366">Encryption</span></span></td>
    <td><span data-ttu-id="408a7-367">ms-settings:deviceencryption</span><span class="sxs-lookup"><span data-stu-id="408a7-367">ms-settings:deviceencryption</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-368">オフライン マップ</span><span class="sxs-lookup"><span data-stu-id="408a7-368">Offline Maps</span></span></td>
    <td><span data-ttu-id="408a7-369">ms-settings:maps</span><span class="sxs-lookup"><span data-stu-id="408a7-369">ms-settings:maps</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="5"><span data-ttu-id="408a7-370">時刻と言語</span><span class="sxs-lookup"><span data-stu-id="408a7-370">Time and language</span></span></td>
  <td><span data-ttu-id="408a7-371">日付と時刻</span><span class="sxs-lookup"><span data-stu-id="408a7-371">Date & time</span></span></td>
    <td><span data-ttu-id="408a7-372">ms-settings:dateandtime</span><span class="sxs-lookup"><span data-stu-id="408a7-372">ms-settings:dateandtime</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-373">地域と言語</span><span class="sxs-lookup"><span data-stu-id="408a7-373">Region & language</span></span></td>
    <td><span data-ttu-id="408a7-374">ms-settings:regionlanguage</span><span class="sxs-lookup"><span data-stu-id="408a7-374">ms-settings:regionlanguage</span></span></td>
  <td></td>
 </tr>
 <tr>
     <td><span data-ttu-id="408a7-375">音声認識の言語</span><span class="sxs-lookup"><span data-stu-id="408a7-375">Speech Language</span></span></td>
     <td><span data-ttu-id="408a7-376">ms-settings:speech</span><span class="sxs-lookup"><span data-stu-id="408a7-376">ms-settings:speech</span></span></td>
     <td></td>
 </tr>
 <tr>
     <td><span data-ttu-id="408a7-377">Pinyin キーボード</span><span class="sxs-lookup"><span data-stu-id="408a7-377">Pinyin keyboard</span></span></td>
     <td><span data-ttu-id="408a7-378">ms-settings:regionlanguage-chsime-pinyin</span><span class="sxs-lookup"><span data-stu-id="408a7-378">ms-settings:regionlanguage-chsime-pinyin</span></span></td>
     <td><span data-ttu-id="408a7-379">Microsoft Pinyin IME がインストールされている場合に利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-379">Available if the Microsoft Pinyin input method editor is installed</span></span></td>
 </tr>
 <tr>
     <td><span data-ttu-id="408a7-380">Wubi 入力モード</span><span class="sxs-lookup"><span data-stu-id="408a7-380">Wubi input mode</span></span></td>
     <td><span data-ttu-id="408a7-381">ms-settings:regionlanguage-chsime-wubi</span><span class="sxs-lookup"><span data-stu-id="408a7-381">ms-settings:regionlanguage-chsime-wubi</span></span></td>
     <td><span data-ttu-id="408a7-382">Microsoft Wubi IME がインストールされている場合に利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-382">Available if the Microsoft Wubi input method editor is installed</span></span></td>
 </tr>
 <tr>
  <td rowspan="13"><span data-ttu-id="408a7-383">更新とセキュリティ</span><span class="sxs-lookup"><span data-stu-id="408a7-383">Update & security</span></span></td>
  <td><span data-ttu-id="408a7-384">Windows Hello セットアップ</span><span class="sxs-lookup"><span data-stu-id="408a7-384">Windows Hello setup</span></span></td>
    <td><span data-ttu-id="408a7-385">ms-settings:signinoptions-launchfaceenrollment</span><span class="sxs-lookup"><span data-stu-id="408a7-385">ms-settings:signinoptions-launchfaceenrollment</span></span><br><span data-ttu-id="408a7-386">ms-settings:signinoptions-launchfingerprintenrollment</span><span class="sxs-lookup"><span data-stu-id="408a7-386">ms-settings:signinoptions-launchfingerprintenrollment</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="408a7-387">バックアップ</span><span class="sxs-lookup"><span data-stu-id="408a7-387">Backup</span></span></td>
      <td><span data-ttu-id="408a7-388">ms-settings:backup</span><span class="sxs-lookup"><span data-stu-id="408a7-388">ms-settings:backup</span></span></td>
    <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-389">デバイスの検索</span><span class="sxs-lookup"><span data-stu-id="408a7-389">Find My Device</span></span></td>
    <td><span data-ttu-id="408a7-390">ms-settings:findmydevice</span><span class="sxs-lookup"><span data-stu-id="408a7-390">ms-settings:findmydevice</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-391">Windows Insider Program</span><span class="sxs-lookup"><span data-stu-id="408a7-391">Windows Insider Program</span></span></td>
  <td><span data-ttu-id="408a7-392">ms-settings:windowsinsider</span><span class="sxs-lookup"><span data-stu-id="408a7-392">ms-settings:windowsinsider</span></span></td>
  <td><span data-ttu-id="408a7-393">ユーザーが Windows Insider Program に登録されている場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-393">Only present if user is enrolled in WIP</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-394">Windows Update</span><span class="sxs-lookup"><span data-stu-id="408a7-394">Windows Update</span></span></td>
  <td><span data-ttu-id="408a7-395">ms-settings:windowsupdate</span><span class="sxs-lookup"><span data-stu-id="408a7-395">ms-settings:windowsupdate</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-396">Windows Update</span><span class="sxs-lookup"><span data-stu-id="408a7-396">Windows Update</span></span></td>
    <td><span data-ttu-id="408a7-397">ms-settings:windowsupdate-history</span><span class="sxs-lookup"><span data-stu-id="408a7-397">ms-settings:windowsupdate-history</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-398">Windows Update</span><span class="sxs-lookup"><span data-stu-id="408a7-398">Windows Update</span></span></td>
    <td><span data-ttu-id="408a7-399">ms-settings:windowsupdate-options</span><span class="sxs-lookup"><span data-stu-id="408a7-399">ms-settings:windowsupdate-options</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-400">Windows Update</span><span class="sxs-lookup"><span data-stu-id="408a7-400">Windows Update</span></span></td>
    <td><span data-ttu-id="408a7-401">ms-settings:windowsupdate-restartoptions</span><span class="sxs-lookup"><span data-stu-id="408a7-401">ms-settings:windowsupdate-restartoptions</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-402">Windows Update</span><span class="sxs-lookup"><span data-stu-id="408a7-402">Windows Update</span></span></td>
    <td><span data-ttu-id="408a7-403">ms-settings:windowsupdate-action</span><span class="sxs-lookup"><span data-stu-id="408a7-403">ms-settings:windowsupdate-action</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-404">ライセンス認証</span><span class="sxs-lookup"><span data-stu-id="408a7-404">Activation</span></span></td>
    <td><span data-ttu-id="408a7-405">ms-settings:activation</span><span class="sxs-lookup"><span data-stu-id="408a7-405">ms-settings:activation</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-406">回復</span><span class="sxs-lookup"><span data-stu-id="408a7-406">Recovery</span></span></td>
    <td><span data-ttu-id="408a7-407">ms-settings:recovery</span><span class="sxs-lookup"><span data-stu-id="408a7-407">ms-settings:recovery</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-408">トラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="408a7-408">Troubleshoot</span></span></td>
    <td><span data-ttu-id="408a7-409">ms-settings:troubleshoot</span><span class="sxs-lookup"><span data-stu-id="408a7-409">ms-settings:troubleshoot</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-410">Windows Defender</span><span class="sxs-lookup"><span data-stu-id="408a7-410">Windows Defender</span></span></td>
    <td><span data-ttu-id="408a7-411">ms-settings:windowsdefender</span><span class="sxs-lookup"><span data-stu-id="408a7-411">ms-settings:windowsdefender</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-412">開発者向け</span><span class="sxs-lookup"><span data-stu-id="408a7-412">For developers</span></span></td>
    <td><span data-ttu-id="408a7-413">ms-settings:developers</span><span class="sxs-lookup"><span data-stu-id="408a7-413">ms-settings:developers</span></span></td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="2"><span data-ttu-id="408a7-414">ユーザー アカウント</span><span class="sxs-lookup"><span data-stu-id="408a7-414">User  Accounts</span></span></td>
  <td><span data-ttu-id="408a7-415">Windows Anywhere</span><span class="sxs-lookup"><span data-stu-id="408a7-415">Windows Anywhere</span></span></td>
  <td><span data-ttu-id="408a7-416">ms-settings:windowsanywhere</span><span class="sxs-lookup"><span data-stu-id="408a7-416">ms-settings:windowsanywhere</span></span></td>
  <td><span data-ttu-id="408a7-417">デバイスが Windows Anywhere に対応している必要がある</span><span class="sxs-lookup"><span data-stu-id="408a7-417">Device must be Windows Anywhere-capable</span></span></td>
 </tr>
 <tr>
  <td><span data-ttu-id="408a7-418">プロビジョニング</span><span class="sxs-lookup"><span data-stu-id="408a7-418">Provisioning</span></span></td>
  <td><span data-ttu-id="408a7-419">ms-settings:workplace-provisioning</span><span class="sxs-lookup"><span data-stu-id="408a7-419">ms-settings:workplace-provisioning</span></span></td>
  <td><span data-ttu-id="408a7-420">企業でプロビジョニング パッケージが展開されている場合のみ利用可能</span><span class="sxs-lookup"><span data-stu-id="408a7-420">Only available if enterprise has deployed a provisioning package</span></span></td>
 </tr>
</table><br/>  
