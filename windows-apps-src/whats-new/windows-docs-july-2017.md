---
author: QuinnRadich
title: Windows ドキュメントの最新情報、2017 年 7 月 - UWP アプリの開発
description: 2017 年 7 月版の Windows 10 開発者向けドキュメントには、新しい機能、サンプル、開発者向けガイダンスが追加されました
keywords: 最新情報, 更新, 機能, 開発者向けガイダンス, Windows 10
ms.author: quradic
ms.date: 07/05/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 62afbef1cc1f47bbc88c45a166572deca28d47a4
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7279997"
---
# <a name="whats-new-in-the-windows-developer-docs-in-july-2017"></a><span data-ttu-id="93926-104">Windows 開発者向けドキュメントの最新情報、2017 年 7 月</span><span class="sxs-lookup"><span data-stu-id="93926-104">What's New in the Windows Developer Docs in July 2017</span></span>

<span data-ttu-id="93926-105">Windows 開発者向けドキュメントは、Windows プラットフォームで開発者に提供される新機能の情報を反映して継続的に更新されています。</span><span class="sxs-lookup"><span data-stu-id="93926-105">The Windows Developer Documentation is constantly being updated with information on new features available to developers across the Windows platform.</span></span> <span data-ttu-id="93926-106">ここに示す機能概要、開発者向けガイダンス、コード サンプルは最近公開されたもので、Windows 開発者向けの新しい情報や更新情報を含んでいます。</span><span class="sxs-lookup"><span data-stu-id="93926-106">The following feature overviews, developer guidance, and code samples have recently been made available, containing new and updated information for Windows developers.</span></span>

<span data-ttu-id="93926-107">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](../get-started/your-first-app.md)したり、[Windows の既存のアプリ コード](../porting/index.md)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="93926-107">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](../get-started/your-first-app.md) or explore how you can use your [existing app code on Windows](../porting/index.md).</span></span>

## <a name="features"></a><span data-ttu-id="93926-108">機能</span><span class="sxs-lookup"><span data-stu-id="93926-108">Features</span></span>

### <a name="fluent-design"></a><span data-ttu-id="93926-109">Fluent Design</span><span class="sxs-lookup"><span data-stu-id="93926-109">Fluent Design</span></span>

<span data-ttu-id="93926-110">次の効果は、[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されます。これらの新しい効果は、深度、視点、動きを使って、重要な UI 要素にユーザーが集中できるようにします。</span><span class="sxs-lookup"><span data-stu-id="93926-110">Available to [Windows Insiders](https://insider.windows.com/) in SDK Preview Builds, these new effects use depth, perspective, and movement to help users focus on important UI elements.</span></span>

<span data-ttu-id="93926-111">[アクリル素材](../design/style/acrylic.md)は、透明なテクスチャを作成できる、ブラシの種類の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="93926-111">[Acrylic material](../design/style/acrylic.md) is a type of brush that creates transparent textures.</span></span> 

![淡色テーマのアクリル](../design/style/images/Acrylic_DarkTheme_Base.png)

<span data-ttu-id="93926-113">[視差効果](../design/motion/parallax.md)を使用すると、3 次元の深度と視点をアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="93926-113">The [Parallax effect](../design/motion/parallax.md) adds three-dimensional depth and perspective to your app.</span></span>

![リストと背景画像を使用した視差の例](../design/style/images/_Parallax_v2.gif)

<span data-ttu-id="93926-115">[表示](../design/style/reveal.md)を使用すると、アプリの重要な要素を強調できます。</span><span class="sxs-lookup"><span data-stu-id="93926-115">[Reveal](../design/style/reveal.md) highlights important elements of your app.</span></span> 

![表示のビジュアル効果](../design/style/images/Nav_Reveal_Animation.gif)

### <a name="ui-controls"></a><span data-ttu-id="93926-117">UI コントロール</span><span class="sxs-lookup"><span data-stu-id="93926-117">UI Controls</span></span>

<span data-ttu-id="93926-118">次のコントロールは、[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されます。これらの新しいコントロールを使うと、優れた外観の UI をすばやく簡単に作成できます。</span><span class="sxs-lookup"><span data-stu-id="93926-118">Available to [Windows Insiders](https://insider.windows.com/) in SDK Preview Builds, these new controls make it easier to quickly build a great looking UI.</span></span>

<span data-ttu-id="93926-119">[カラー ピッカー コントロール](../design/controls-and-patterns/color-picker.md)では、ユーザーが色を自由に確認しながら選択できます。</span><span class="sxs-lookup"><span data-stu-id="93926-119">The [color picker control](../design/controls-and-patterns/color-picker.md) enables users to browse through and select colors.</span></span>  

![既定のカラー ピッカー](../design/controls-and-patterns/images/color-picker-default.png)

<span data-ttu-id="93926-121">[ナビゲーション ビュー コントロール](../design/controls-and-patterns/navigationview.md)を使うと、トップレベルのナビゲーションを簡単にアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="93926-121">The [navigation view control](../design/controls-and-patterns/navigationview.md) makes it easy to add top-level navigation to your app.</span></span>

![ナビゲーション ビューのセクション](../design/controls-and-patterns/images/navview_sections.png)

<span data-ttu-id="93926-123">[ユーザー画像コントロール](../design/controls-and-patterns/person-picture.md)では、人物のアバター画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="93926-123">The [person picture control](../design/controls-and-patterns/person-picture.md) displays the avatar image for a person.</span></span>

![ユーザー画像コントロール](../design/controls-and-patterns/images/person-picture/person-picture_hero.png)

<span data-ttu-id="93926-125">[評価コントロール](../design/controls-and-patterns/rating.md)では、ユーザーが評価の確認と設定を簡単に行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。</span><span class="sxs-lookup"><span data-stu-id="93926-125">The [rating control](../design/controls-and-patterns/rating.md) enables users to easily view and set ratings that reflect degrees of satisfaction with content and services.</span></span>

![評価コントロールの例](../design/controls-and-patterns/images/rating_rs2_doc_ratings_intro.png)

### <a name="design-toolkits"></a><span data-ttu-id="93926-127">設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="93926-127">Design Toolkits</span></span>

<span data-ttu-id="93926-128">[UWP アプリ用の設計ツールキットとリソース](../design/downloads/index.md)が拡張され、スケッチ ツールキットと Adobe XD ツールキットが追加されました。</span><span class="sxs-lookup"><span data-stu-id="93926-128">The [design toolkits and resources for UWP apps](../design/downloads/index.md) have been expanded with the addition of the Sketch and Adobe XD toolkits.</span></span> <span data-ttu-id="93926-129">既存のツールキットも刷新され、より堅牢なコントロールとレイアウト テンプレートが UWP アプリに提供されます。</span><span class="sxs-lookup"><span data-stu-id="93926-129">The previously-existing toolkits have also been updated and revamped, providing more robust controls and layout templates for your UWP apps.</span></span>

### <a name="dashboard-monetization-and-store-services"></a><span data-ttu-id="93926-130">ダッシュボード、収益化、ストア サービス</span><span class="sxs-lookup"><span data-stu-id="93926-130">Dashboard, monetization and Store services</span></span>

<span data-ttu-id="93926-131">次の新機能が利用可能になりました。</span><span class="sxs-lookup"><span data-stu-id="93926-131">The following new features are now available:</span></span>

* <span data-ttu-id="93926-132">Microsoft Advertising SDK で、アプリ内に[ネイティブ広告](../monetize/native-ads.md)を表示できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="93926-132">The Microsoft Advertising SDK now enables you to show [native ads](../monetize/native-ads.md) in your apps.</span></span> <span data-ttu-id="93926-133">ネイティブ広告は、コンポーネント ベースの広告形式で、各広告クリエイティブ (タイトル、画像、説明、行動喚起テキストなど) が個々の要素としてアプリに配信されます。</span><span class="sxs-lookup"><span data-stu-id="93926-133">A native ad is a component-based ad format where each piece of the ad creative (such as the title, image, description, and call-to-action text) is delivered to your app as an individual element.</span></span> <span data-ttu-id="93926-134">ネイティブ広告は、現在はパイロット プログラムに参加している開発者にのみ提供されますが、まもなくすべての開発者がこの機能を利用できるようになる予定です。</span><span class="sxs-lookup"><span data-stu-id="93926-134">Native ads are currently only available to developers who join a pilot program, but we intend to make this feature available to all developers soon.</span></span>

* <span data-ttu-id="93926-135">[Microsoft Store 分析 API](../monetize/access-analytics-data-using-windows-store-services.md) に、[アプリのエラーの CAB ファイルをダウンロード](../monetize/download-the-cab-file-for-an-error-in-your-app.md)するために使用できるメソッドが追加されました。</span><span class="sxs-lookup"><span data-stu-id="93926-135">The [Microsoft Store analytics API](../monetize/access-analytics-data-using-windows-store-services.md) now provides a method you can use to [download the CAB file for an error in your app](../monetize/download-the-cab-file-for-an-error-in-your-app.md).</span></span>

* <span data-ttu-id="93926-136">[ターゲット オファー](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)では、特定のユーザー セグメントをターゲットに設定し、ユーザーに合わせた魅力的なコンテンツを提供して、エンゲージメント、ユーザー維持率、収益性を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="93926-136">[Targeted offers](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md) let you target specific segments of your customers with attractive, personalized content to increase engagement, retention, and monetization.</span></span> 

* <span data-ttu-id="93926-137">アプリのストア登録情報に[ビデオ トレーラー](../publish/app-screenshots-and-images.md#trailers)を含めることができるようになりました。</span><span class="sxs-lookup"><span data-stu-id="93926-137">Your app's Store listing can now include [video trailers](../publish/app-screenshots-and-images.md#trailers).</span></span>

* <span data-ttu-id="93926-138">新しい価格と利用可能状況のオプションでは、[価格変更のスケジュール](../publish/set-and-schedule-app-pricing.md)や[正確なリリース日の設定](..//publish/configure-precise-release-scheduling.md)を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="93926-138">New pricing and availability options let you [schedule price changes](../publish/set-and-schedule-app-pricing.md) and [set precise release dates](..//publish/configure-precise-release-scheduling.md).</span></span>

* <span data-ttu-id="93926-139">[ストア登録情報のインポートとエクスポート](../publish/import-and-export-store-listings.md)を使うと、更新にかかる時間を短縮できます。これは特に、登録情報を多数の言語で提供している場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="93926-139">You can [import and export Store listings](../publish/import-and-export-store-listings.md) to make updates faster, especially if you have listings in many languages.</span></span>

### <a name="my-people"></a><span data-ttu-id="93926-140">マイ連絡先</span><span class="sxs-lookup"><span data-stu-id="93926-140">My People</span></span>

<span data-ttu-id="93926-141">[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供されるマイ連絡先機能を使うと、アプリケーションからユーザーのタスク バーに連絡先を直接ピン留めすることができます。</span><span class="sxs-lookup"><span data-stu-id="93926-141">Available to [Windows Insiders](https://insider.windows.com/) in SDK Preview Builds, the upcoming My People feature allows users to pin contacts from an application directly to their taskbar.</span></span> [<span data-ttu-id="93926-142">アプリケーションにマイ連絡先のサポートを追加する方法については、こちらをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93926-142">Learn how to add My People support to your application.</span></span>](../contacts-and-calendar/my-people-support.md)

![マイ連絡先の連絡先パネル](images/my-people.png)

<span data-ttu-id="93926-144">[マイ連絡先の共有](../contacts-and-calendar/my-people-sharing.md)では、アプリケーションを通じて、ユーザーがタスク バーから直接ファイルを共有できます。</span><span class="sxs-lookup"><span data-stu-id="93926-144">[My People sharing](../contacts-and-calendar/my-people-sharing.md) allows users to share files through your application, right from the taskbar.</span></span>

![マイ連絡先の共有](images/my-people-sharing.png)

<span data-ttu-id="93926-146">[マイ連絡先の通知](../contacts-and-calendar/my-people-support.md)は、ピン留めした連絡先にユーザーが通知を送信できる新しい種類のトースト通知です。</span><span class="sxs-lookup"><span data-stu-id="93926-146">[My People notifications](../contacts-and-calendar/my-people-support.md) are a new kind of toast notification that users can send to their pinned contacts.</span></span>

![マイ連絡先の通知](images/my-people-notification.png)

### <a name="pin-to-taskbar"></a><span data-ttu-id="93926-148">タスク バーにピン留め</span><span class="sxs-lookup"><span data-stu-id="93926-148">Pin to Taskbar</span></span>

<span data-ttu-id="93926-149">[Windows Insider](https://insider.windows.com/) を対象に SDK Preview Build で提供される新しい TaskbarManager クラスでは、[アプリをタスク バーにピン留めする](../design/shell/pin-to-taskbar.md)ようにユーザーに勧めることができます。</span><span class="sxs-lookup"><span data-stu-id="93926-149">Available to [Windows Insiders](https://insider.windows.com/) in SDK Preview Builds, the new TaskbarManager class allows you to ask your user to [pin your app to the taskbar](../design/shell/pin-to-taskbar.md).</span></span>

## <a name="developer-guidance"></a><span data-ttu-id="93926-150">開発者向けガイダンス</span><span class="sxs-lookup"><span data-stu-id="93926-150">Developer Guidance</span></span>

### <a name="media-playback"></a><span data-ttu-id="93926-151">メディア再生</span><span class="sxs-lookup"><span data-stu-id="93926-151">Media Playback</span></span>

<span data-ttu-id="93926-152">メディア再生の基本について説明する記事に、新しいセクション「[MediaPlayer を使ったオーディオとビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」が追加されました。</span><span class="sxs-lookup"><span data-stu-id="93926-152">New sections have been added to the basic media playback article, [Play audio and video with MediaPlayer](../audio-video-camera/play-audio-and-video-with-mediaplayer.md).</span></span> <span data-ttu-id="93926-153">「[MediaPlayer を使った球面ビデオの再生](../audio-video-camera/play-audio-and-video-with-mediaplayer.md)」セクションでは、球状にエンコードされたビデオの再生方法を示します。サポートされる形式に合わせて視野やビューの向きを調整する方法についても説明しています。</span><span class="sxs-lookup"><span data-stu-id="93926-153">The section [Play spherical video with MediaPlayer](../audio-video-camera/play-audio-and-video-with-mediaplayer.md) shows you how to playback spherically encodeded video, including adjusting the field of view and view orientation for supported formats.</span></span> <span data-ttu-id="93926-154">「[フレーム サーバー モードでの MediaPlayer の使用](../audio-video-camera/play-audio-and-video-with-mediaplayer.md#use-mediaplayer-in-frame-server-mode)」セクションでは、[MediaPlayer](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlayer) で再生されるメディアから Direct3D サーフェスにフレームをコピーする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="93926-154">The section [Use MediaPlayer in frame server mode](../audio-video-camera/play-audio-and-video-with-mediaplayer.md#use-mediaplayer-in-frame-server-mode) shows you how to copy frames from media played back with [MediaPlayer](https://docs.microsoft.com/uwp/api/Windows.Media.Playback.MediaPlayer) to a Direct3D surface.</span></span> <span data-ttu-id="93926-155">これにより、ピクセル シェーダーを使ってリアルタイムの効果を適用するといったシナリオを実現できます。</span><span class="sxs-lookup"><span data-stu-id="93926-155">This enables scenarios such as applying real-time effects with pixel shaders.</span></span> <span data-ttu-id="93926-156">コード例では、Win2D を使ってビデオ再生にぼかし効果を適用する簡単な実装を紹介しています。</span><span class="sxs-lookup"><span data-stu-id="93926-156">The example code shows a quick implementation of a blur effect for video playback using Win2D.</span></span>

### <a name="media-capture"></a><span data-ttu-id="93926-157">メディア キャプチャ</span><span class="sxs-lookup"><span data-stu-id="93926-157">Media Capture</span></span>

<span data-ttu-id="93926-158">「[MediaFrameReader を使ったメディア フレームの処理](../audio-video-camera/process-media-frames-with-mediaframereader.md)」が更新され、新しい [MultiSourceMediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader) クラスの使用方法が追加されました。このクラスを使うと、複数のメディア ソースから時間相関フレームを取得できます。</span><span class="sxs-lookup"><span data-stu-id="93926-158">The article [Process media frames with MediaFrameReader](../audio-video-camera/process-media-frames-with-mediaframereader.md) has been updated to show the usage of the new [MultiSourceMediaFrameReader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader) class, which allows you to obtain time-correlated frames from multiple media sources.</span></span> <span data-ttu-id="93926-159">これは、深度カメラやカラー カメラなどのさまざまなソースからのフレームを処理する必要があり、各ソースからのフレームが時間的に近くなるようにキャプチャする必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="93926-159">This is useful if you need to process frames from different sources, such as a depth camera and an color camera, and you need to make sure that the frames from each source were captured close to each other in time.</span></span> <span data-ttu-id="93926-160">詳しくは、[MultiSourceMediaFrameReader を使った複数のソースからの時間相関フレームの取得](../audio-video-camera/process-media-frames-with-mediaframereader.md#use-multisourcemediaframereader-to-get-time-corellated-frames-from-multiple-sources)に関するセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93926-160">For more information, see [Use MultiSourceMediaFrameReader to get time-corellated frames from multiple sources](../audio-video-camera/process-media-frames-with-mediaframereader.md#use-multisourcemediaframereader-to-get-time-corellated-frames-from-multiple-sources).</span></span>

### <a name="scoped-search"></a><span data-ttu-id="93926-161">スコープを指定した検索</span><span class="sxs-lookup"><span data-stu-id="93926-161">Scoped Search</span></span>

<span data-ttu-id="93926-162">docs.microsoft.com の [UWP の概念](../get-started/universal-application-platform-guide.md)と [API リファレンス](https://docs.microsoft.com/en-us/uwp/api/)のドキュメントに、"UWP" というスコープが追加されました。</span><span class="sxs-lookup"><span data-stu-id="93926-162">A "UWP" scope has been added to the [UWP conceptual](../get-started/universal-application-platform-guide.md) and [API reference](https://docs.microsoft.com/en-us/uwp/api/) documentation on docs.microsoft.com.</span></span> <span data-ttu-id="93926-163">このスコープを解除しない限り、これらの領域から検索を行うと UWP のドキュメントだけが返されます。</span><span class="sxs-lookup"><span data-stu-id="93926-163">Unless this scope is deactivated, searches made from within these areas will return UWP docs only.</span></span>

![スコープを指定した検索](images/scoped-search.png)

### <a name="test-your-windows-app-for-windows-10-s"></a><span data-ttu-id="93926-165">Windows アプリの Windows 10 S 対応のテスト</span><span class="sxs-lookup"><span data-stu-id="93926-165">Test your Windows app for Windows 10 S</span></span>

<span data-ttu-id="93926-166">Windows アプリをテストして、Windows S を実行するデバイスで正しく動作することを確認します。方法については、[新しいガイド](../porting/desktop-to-uwp-test-windows-s.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="93926-166">Test your Windows app to ensure that it will operate correctly on devices that run Windows S. Use [this new guide](../porting/desktop-to-uwp-test-windows-s.md) to learn how.</span></span> 

## <a name="samples"></a><span data-ttu-id="93926-167">サンプル</span><span class="sxs-lookup"><span data-stu-id="93926-167">Samples</span></span>

### <a name="annotated-audio-app-sample"></a><span data-ttu-id="93926-168">注釈付きオーディオ アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="93926-168">Annotated audio app sample</span></span>

<span data-ttu-id="93926-169">[オーディオ、インク、OneDrive データ ローミングのシナリオを紹介するミニ アプリのサンプル](https://github.com/Microsoft/Windows-appsample-annotated-audio)です。</span><span class="sxs-lookup"><span data-stu-id="93926-169">[A mini-app sample that demonstrates audio, ink, and OneDrive data roaming scenarios](https://github.com/Microsoft/Windows-appsample-annotated-audio).</span></span> <span data-ttu-id="93926-170">このサンプルでは、オーディオを録音しながらインク注釈を同期的キャプチャする例を示します。これにより、メモを取ったときに何が議論されていたかを後で思い出すことができます。</span><span class="sxs-lookup"><span data-stu-id="93926-170">This sample records audio while allowing the synchronized capture of ink annotations so that you can later recall what was being discussed at the time a note was taken.</span></span>

![注釈付きオーディオ アプリのサンプルのスクリーンショット](images/Playback.png)  

### <a name="shopping-app-sample"></a><span data-ttu-id="93926-172">ショッピング アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="93926-172">Shopping app sample</span></span>

<span data-ttu-id="93926-173">[ユーザーが絵文字を購入できる基本的なショッピング エクスペリエンスを提供するミニ アプリ](https://github.com/Microsoft/Windows-appsample-shopping)です。</span><span class="sxs-lookup"><span data-stu-id="93926-173">[A mini-app that presents a basic shopping experience where a user can buy emoji](https://github.com/Microsoft/Windows-appsample-shopping).</span></span> <span data-ttu-id="93926-174">このアプリは、[支払い要求 API](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments) を使ってチェックアウト処理を実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="93926-174">This app shows how to use the [Payment Request APIs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments) to implement the checkout experience.</span></span>

![ショッピング アプリのサンプルのスクリーンショット](images/shoppingcart.png)  

## <a name="videos"></a><span data-ttu-id="93926-176">ビデオ</span><span class="sxs-lookup"><span data-stu-id="93926-176">Videos</span></span>

### <a name="accessibility"></a><span data-ttu-id="93926-177">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="93926-177">Accessibility</span></span>

<span data-ttu-id="93926-178">アプリにアクセシビリティ機能を組み込むと、より幅広いユーザー層をターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="93926-178">Building accessibility into your apps opens them up to a much wider audience.</span></span> <span data-ttu-id="93926-179">まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Developing-Apps-for-Accessibility)をご覧になってから、「[アクセシビリティのためのアプリ開発](https://developer.microsoft.com/en-us/windows/accessible-apps)」で詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="93926-179">[Watch the video](https://channel9.msdn.com/Blogs/One-Dev-Minute/Developing-Apps-for-Accessibility), then learn more about [developing apps for accessibility](https://developer.microsoft.com/en-us/windows/accessible-apps).</span></span>

### <a name="payments-request-api"></a><span data-ttu-id="93926-180">支払い要求 API</span><span class="sxs-lookup"><span data-stu-id="93926-180">Payments Request API</span></span>

<span data-ttu-id="93926-181">支払い要求 API は、顧客と販売者がオンライン チェック アウト プロセスをシームレスに完了できるように支援します。</span><span class="sxs-lookup"><span data-stu-id="93926-181">The Payment Request API helps custoemrs and sellers seamlessly complete the online checkout process.</span></span> <span data-ttu-id="93926-182">まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API)をご覧になってから、[支払い要求のドキュメント](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API)で詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="93926-182">[Watch the video](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API), then explore the [Payment Request documentation](https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-the-Payments-Request-API).</span></span>

### <a name="windows-10-iot-core"></a><span data-ttu-id="93926-183">Windows 10 IoT Core</span><span class="sxs-lookup"><span data-stu-id="93926-183">Windows 10 IoT Core</span></span>

<span data-ttu-id="93926-184">Windows 10 IoT Core とユニバーサル Windows プラットフォームを利用すると、視覚情報とコンポーネントを連携させるプロジェクトのプロトタイプ作成と構築をすばやく行うことができます。たとえば、ペットを認識して開閉するドアを実現できます。</span><span class="sxs-lookup"><span data-stu-id="93926-184">With Windows 10 IoT Core and the Universal Windows Platform, you can quickly protoype and build projects with vision and component connections, such as this Pet Recognition Door.</span></span> <span data-ttu-id="93926-185">まずは[ビデオ](https://channel9.msdn.com/Blogs/One-Dev-Minute/Building-a-Pet-Recognition-Door-Using-Windows-10-IoT-Core)をご覧になってから、[Windows 10 IoT Core を使い始める](https://developer.microsoft.com/en-us/windows/iot)方法の詳細を確認してください。</span><span class="sxs-lookup"><span data-stu-id="93926-185">[Watch the video](https://channel9.msdn.com/Blogs/One-Dev-Minute/Building-a-Pet-Recognition-Door-Using-Windows-10-IoT-Core), then learn more about how to [get started with Windows 10 IoT Core](https://developer.microsoft.com/en-us/windows/iot).</span></span>