---
author: QuinnRadich
title: "Windows 10 SDK Preview Build 16190 の新機能 - UWP アプリの開発"
description: "Windows 10 SDK Preview Build 16190 では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスが引き続き提供されます。"
keywords: "新着情報, 新機能, 更新, 更新プログラム, 機能, 新規, Windows 10, ビルド, カンファレンス, Insider, フライト, 最新, 16190"
ms.author: quradic
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
msdn.assetid: 0fdde031-97a5-430c-91af-846c5fbb028f
ms.openlocfilehash: 78a2f69cc82899de946f5815f7dc9f07c279d69d
ms.sourcegitcommit: 512a82a782775795e301d6235d0c977c0a9e9c74
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/11/2017
---
# <a name="whats-new-in-windows-10-at-microsoft-build-2017"></a><span data-ttu-id="796db-104">Microsoft Build 2017 で発表された Windows 10 の新機能</span><span class="sxs-lookup"><span data-stu-id="796db-104">What's New in Windows 10 at Microsoft Build 2017</span></span>

<span data-ttu-id="796db-105">[Microsoft Build 2017 開発者カンファレンス](https://developer.microsoft.com/windows/projects/events/build/2017?ocid=wdgbld17_intreferral_devcenterhp_null_null_devcenter_hppost&utm_campaign=wdgbld17&utm_medium=internalreferral&utm_source=devcenterhp&utm_content=devcenter_hppost)でリリースされた Windows 10 SDK Preview Build 16190 では、ユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスが引き続き提供されます。</span><span class="sxs-lookup"><span data-stu-id="796db-105">Released to accompany the [Microsoft Build 2017 developer conference](https://developer.microsoft.com/windows/projects/events/build/2017?ocid=wdgbld17_intreferral_devcenterhp_null_null_devcenter_hppost&utm_campaign=wdgbld17&utm_medium=internalreferral&utm_source=devcenterhp&utm_content=devcenter_hppost), Windows 10 SDK Preview Build 16190 will continue to provide the tools, features, and experiences powered by the Universal Windows Platform.</span></span> <span data-ttu-id="796db-106">Windows 10 の[ツールと SDK をインストール](http://go.microsoft.com/fwlink/?LinkId=821431)すると、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)がどのように使えるかを試したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="796db-106">[Install the tools and SDK](http://go.microsoft.com/fwlink/?LinkId=821431) on Windows 10 and you’re ready to either [create a new Universal Windows app](https://msdn.microsoft.com/library/windows/apps/bg124288) or explore how you can use your [existing app code on Windows](https://msdn.microsoft.com/library/windows/apps/mt238321).</span></span>

<span data-ttu-id="796db-107">以下の機能紹介とチュートリアルの多くは、Build 2017 カンファレンスで SDK Preview Build と共にリリースされた内容ですが、プレビュー ビルドの使用は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="796db-107">Many of the below features and tutorials have been released alongside the SDK Preview Build at the Build 2017 conference, but do not require the preview build to be used.</span></span> <span data-ttu-id="796db-108">特定の変更内容について詳しくは、[このプレビュー ビルドで追加または更新された API 名前空間のプレリリース ドキュメントをご覧ください](windows-10-build-16190-api-diff.md)。</span><span class="sxs-lookup"><span data-stu-id="796db-108">For more information on the specific changes, you can [explore prerelease documentation for new and updated API namespaces in this preview build.](windows-10-build-16190-api-diff.md)</span></span>

<span data-ttu-id="796db-109">この更新および他の Windows 更新プログラムでの注目すべき機能について詳しくは、「[Windows 10 の優れた機能](http://go.microsoft.com/fwlink/?LinkId=823181)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="796db-109">For more information on the highlighted features of this and other Windows updates, see [What's cool in Windows 10](http://go.microsoft.com/fwlink/?LinkId=823181).</span></span> <span data-ttu-id="796db-110">また、Windows プラットフォームに過去に追加された機能と今後追加される機能の概要については、[Windows 開発者向けプラットフォーム機能に関するページ](https://developer.microsoft.com/windows/platform/features)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="796db-110">In addition, see [Windows Developer Platform features](https://developer.microsoft.com/windows/platform/features) for a high-level overview of both past and future additions to the Windows platform.</span></span>

## <a name="new-features"></a><span data-ttu-id="796db-111">新機能</span><span class="sxs-lookup"><span data-stu-id="796db-111">New Features</span></span>

### <a name="effects"></a><span data-ttu-id="796db-112">効果</span><span class="sxs-lookup"><span data-stu-id="796db-112">Effects</span></span>

<span data-ttu-id="796db-113">これらの新しい効果では、重要な UI 要素にユーザーが専念できるように、深度、視点、および動きが使用されています。</span><span class="sxs-lookup"><span data-stu-id="796db-113">These new effects use depth, perspective, and movement to help users focus on important UI elements.</span></span> <span data-ttu-id="796db-114">これらは SDK Preview Build のみで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="796db-114">They are only available in the SDK Preview Build.</span></span>

<span data-ttu-id="796db-115">[アクリル素材](../style/acrylic.md)は、透明なテクスチャを作成できる、ブラシの種類です。</span><span class="sxs-lookup"><span data-stu-id="796db-115">[Acrylic material](../style/acrylic.md) is a type of brush that creates transparent textures.</span></span> 

![淡色テーマのアクリル](../style/images/Acrylic_DarkTheme_Base.png)

<span data-ttu-id="796db-117">[視差効果](../style/parallax.md)を使用すると、3 次元の深度と視点をアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="796db-117">The [Parallax effect](../style/parallax.md) adds three-dimensional depth and perspective to your app.</span></span>

![リストと背景画像を使用した視差の例](../style/images/_Parallax_v2.gif)

<span data-ttu-id="796db-119">[表示](../style/reveal.md)を使用すると、アプリの重要な要素を強調できます。</span><span class="sxs-lookup"><span data-stu-id="796db-119">[Reveal](../style/reveal.md) highlights important elements of your app.</span></span> 

![表示のビジュアル効果](../style/images/Nav_Reveal_Animation.gif)


### <a name="controls"></a><span data-ttu-id="796db-121">コントロール</span><span class="sxs-lookup"><span data-stu-id="796db-121">Controls</span></span>

<span data-ttu-id="796db-122">新しいコントロールを使用すると、優れた外観の UI をすばやく簡単に作成できます。</span><span class="sxs-lookup"><span data-stu-id="796db-122">These new controls make it easier to quickly build a great looking UI.</span></span> <span data-ttu-id="796db-123">これらは SDK Preview Build のみで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="796db-123">They are only available in the SDK Preview Build.</span></span>

<span data-ttu-id="796db-124">ユーザーは[カラー ピッカー コントロール](../controls-and-patterns/color-picker.md)を使って、色を自由に確認し、選択できます。</span><span class="sxs-lookup"><span data-stu-id="796db-124">The [color picker control](../controls-and-patterns/color-picker.md) enables users to browse through and select colors.</span></span>  

![既定のカラー ピッカー](../controls-and-patterns/images/color-picker-default.png)

<span data-ttu-id="796db-126">[ナビゲーション ビュー コントロール](../controls-and-patterns/navigationview.md)を使うと、トップレベルのナビゲーションを簡単にアプリに追加できます。</span><span class="sxs-lookup"><span data-stu-id="796db-126">The [navigation view control](../controls-and-patterns/navigationview.md) makes it easy to add top-level navigation to your app.</span></span>  

![ナビゲーション ビューのセクション](../controls-and-patterns/images/navview_sections.png)

<span data-ttu-id="796db-128">[ユーザー画像コントロール](../controls-and-patterns/person-picture.md)では、人物のアバター画像を表示できます。</span><span class="sxs-lookup"><span data-stu-id="796db-128">The [person picture control](../controls-and-patterns/person-picture.md) displays the avatar image for a person.</span></span>

![ユーザー画像コントロール](../controls-and-patterns/images/person-picture/person-picture_hero.png)

<span data-ttu-id="796db-130">[評価コントロール](../controls-and-patterns/rating.md)では、ユーザーが評価の確認と設定を簡単に行うことができます。評価には、コンテンツやサービスに関する満足度が反映されます。</span><span class="sxs-lookup"><span data-stu-id="796db-130">The [rating control](../controls-and-patterns/rating.md) enables users to easily view and set ratings that reflect degrees of satisfaction with content and services.</span></span>

![評価コントロールの例](../controls-and-patterns/images/rating_rs2_doc_ratings_intro.png)

<span data-ttu-id="796db-132">[ツリー ビュー コントロール](../controls-and-patterns/tree-view.md)では、階層リストが作成され、入れ子になった項目を含むノードを展開したり、折りたたんだりすることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="796db-132">The [tree view control](../controls-and-patterns/tree-view.md) creates a hierarchical list with expanding and collapsing nodes that contain nested items.</span></span>

![ツリー ビューでの山形記号アイコンの使用](../controls-and-patterns/images/treeview_chevron.png)
 

#### <a name="keyboard"></a><span data-ttu-id="796db-134">キーボード</span><span class="sxs-lookup"><span data-stu-id="796db-134">Keyboard</span></span>

<span data-ttu-id="796db-135">「[キーボード操作](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-interactions)」では、キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に考えられる最適なエクスペリエンスを提供できるように、UWP アプリを設計および最適化する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="796db-135">With [Keyboard interactions](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-interactions), design and optimize your UWP apps so they provide the best experience possible for both keyboard power users and those with disabilities and other accessibility requirements.</span></span>

<span data-ttu-id="796db-136">Windows アプリの使いやすさとアクセシビリティの両方を高めるには、「[アクセス キー](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/access-keys)」を使います。</span><span class="sxs-lookup"><span data-stu-id="796db-136">Use [Access keys](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/access-keys) to improve both the usability and the accessibility of your Windows app.</span></span> <span data-ttu-id="796db-137">アクセス キーの使用は、ポインター デバイス (タッチやマウスなど) の代わりにキーボードを使ってアプリに表示される UI をすばやく移動して操作する直感的な方法です。</span><span class="sxs-lookup"><span data-stu-id="796db-137">Access keys provide an intuitive way for users to quickly navigate and interact with an app's visible UI through a keyboard instead of a pointer device (such as touch or mouse).</span></span>

<span data-ttu-id="796db-138">「[カスタムのキーボード操作](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/custom-keyboard-interactions)」では、キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に対して、総合的で一貫性のあるキーボード エクスペリエンスを UWP アプリやカスタム コントロールで提供する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="796db-138">[Custom keyboard interactions](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/custom-keyboard-interactions) provide comprehensive and consistent keyboard interaction experiences in your UWP apps and custom controls for both keyboard power users and those with disabilities and other accessibility requirements.</span></span>

<span data-ttu-id="796db-139">「[キーボード イベント](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-events)」トピックでは、ハードウェア キーボードとタッチ キーボードの両方について、キーボード イベントを追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="796db-139">The [Keyboard events](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/keyboard-events) topic details how to add keyboard events for both hardware and touch keyboards.</span></span>

#### <a name="remote-sessions-apis-project-rome"></a><span data-ttu-id="796db-140">リモート セッション API (Project Rome)</span><span class="sxs-lookup"><span data-stu-id="796db-140">Remote Sessions APIs (Project Rome)</span></span>

<span data-ttu-id="796db-141">Project Rome チームは、UWP 開発者用にリモート セッション SDK をリリースしました ([RemoteSystemSession](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems.remotesystemsession) クラスなど、[RemoteSystems](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems) 名前空間の新しいメンバーをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="796db-141">The Project Rome team has released the remote sessions SDK for UWP developers (see the new members in the [RemoteSystems](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems) namespace, such as the [RemoteSystemSession](https://docs.microsoft.com/en-us/uwp/api/windows.system.remotesystems.remotesystemsession) class).</span></span> <span data-ttu-id="796db-142">Windows アプリでは、"共有エクスペリエンス" と通じてデバイスどうしを接続できるようになりました。"共有エクスペリエンス" では、デバイスは排他的双方向通信チャネルに参加します。</span><span class="sxs-lookup"><span data-stu-id="796db-142">Windows apps can now connect devices through "shared experiences," in which devices become participants in an exclusive two-way communication channel.</span></span> <span data-ttu-id="796db-143">チャネルに参加している他のデバイスの一部またはすべてにデータ パケットを送信できるため、リモート アプリ メッセージングなど、新しいさまざまなクロス デバイス シナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="796db-143">Data packets can be sent to any or all of the other participants in the channel, enabling a number of new cross-device scenarios such as remote app messaging.</span></span>

<span data-ttu-id="796db-144">SDK のリモート セッション機能は、Windows SDK Preview Build のみで利用可能です。</span><span class="sxs-lookup"><span data-stu-id="796db-144">The remote sessions SDK features are only available in the Windows SDK Preview build.</span></span>

#### <a name="project-rome-for-ios"></a><span data-ttu-id="796db-145">Project Rome for iOS</span><span class="sxs-lookup"><span data-stu-id="796db-145">Project Rome for iOS</span></span>
<span data-ttu-id="796db-146">Microsoft の Project Rome 機能が iOS のプラットフォームにデビューしました。</span><span class="sxs-lookup"><span data-stu-id="796db-146">Microsoft's Project Rome feature has debuted on the iOS platform.</span></span> <span data-ttu-id="796db-147">新しいプレビュー SDK を使うと、リモートでアプリを起動してユーザーの Windows デバイスでタスクを続行するような iOS アプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="796db-147">With the new preview SDK, developers can write iOS apps that remotely launch apps and continue tasks on users' Windows devices.</span></span> <span data-ttu-id="796db-148">この機能を使い始めるには、公式の[クロスプラットフォーム シナリオ向け Project Rome リポジトリ](https://github.com/Microsoft/project-rome)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="796db-148">See the official [Project Rome repo for cross-platform scenarios](https://github.com/Microsoft/project-rome) to get started.</span></span>

#### <a name="windows-ink"></a><span data-ttu-id="796db-149">Windows Ink</span><span class="sxs-lookup"><span data-stu-id="796db-149">Windows Ink</span></span>

<span data-ttu-id="796db-150">「[Windows Ink でのストロークのテキスト認識](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/convert-ink-to-text)」トピックでは、[Windows Ink 分析エンジン](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis)を使用した豊富な認識機能について説明しています。</span><span class="sxs-lookup"><span data-stu-id="796db-150">The [Recognize Windows Ink strokes as text and shapes](https://docs.microsoft.com/en-us/windows/uwp/input-and-devices/convert-ink-to-text) topic contains details on rich recognition with the [Windows Ink analysis engine](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.analysis).</span></span> <span data-ttu-id="796db-151">一連のストロークをテキストまたは図形として分類、分析、および認識する方法についても示します (ドキュメントの構造、箇条書き、および汎用的な描画の認識にも Ink の分析を使用できます)。</span><span class="sxs-lookup"><span data-stu-id="796db-151">We demonstrate how to classify, analyze, and recognize a set of strokes as text or shapes (ink analysis can also be used to recognize document structure, bullet lists, and generic drawings).</span></span>

## <a name="samples-and-tutorials"></a><span data-ttu-id="796db-152">サンプルとチュートリアル</span><span class="sxs-lookup"><span data-stu-id="796db-152">Samples and Tutorials</span></span>

#### <a name="high-dpi"></a><span data-ttu-id="796db-153">高 DPI</span><span class="sxs-lookup"><span data-stu-id="796db-153">High DPI</span></span>

<span data-ttu-id="796db-154">[Per-window DPI Awareness サンプル](https://github.com/Microsoft/Windows-classic-samples/tree/master/Samples/DPIAwarenessPerWindow) が更新され、Creators Update で新しく追加された Per-Monitor v2 DPI 対応コンテキスト モードがサポートされるようになりました。</span><span class="sxs-lookup"><span data-stu-id="796db-154">Updates have been made to the [Per-window DPI Awareness sample](https://github.com/Microsoft/Windows-classic-samples/tree/master/Samples/DPIAwarenessPerWindow), supporting the new Per-Monitor v2 DPI awareness context mode added in the Creators Update.</span></span> <span data-ttu-id="796db-155">このサンプルでは、単一のデスクトップ アプリケーション プロセスで、さまざまなトップレベル ウィンドウにさまざまな DPI 対応モードを割り当てる方法を示し、モードによる動作の違いを説明しています。</span><span class="sxs-lookup"><span data-stu-id="796db-155">This sample shows how to assign different DPI awareness modes to different top-level windows within a single desktop application process, and showcases the behavioral differences between those modes.</span></span>

#### <a name="radialcontroller"></a><span data-ttu-id="796db-156">RadialController</span><span class="sxs-lookup"><span data-stu-id="796db-156">RadialController</span></span>

<span data-ttu-id="796db-157">[UWP アプリによる Surface Dial (およびその他のホイール デバイス) のサポート](https://docs.microsoft.com/en-us/windows/uwp/get-started/radialcontroller-walkthrough)に関するチュートリアルがリリースされました。</span><span class="sxs-lookup"><span data-stu-id="796db-157">The [Support the Surface Dial (and other wheel devices) in your UWP app](https://docs.microsoft.com/en-us/windows/uwp/get-started/radialcontroller-walkthrough) tutorial has been released.</span></span> <span data-ttu-id="796db-158">RadialController API を使用してサンプル アプリのダイヤル エクスペリエンスをカスタマイズする方法が示されています。</span><span class="sxs-lookup"><span data-stu-id="796db-158">It steps through how to use the RadialController APIs to customize the Dial experience in a sample app.</span></span>

#### <a name="webvr"></a><span data-ttu-id="796db-159">WebVR</span><span class="sxs-lookup"><span data-stu-id="796db-159">WebVR</span></span>

<span data-ttu-id="796db-160">[3D Babylon.js ゲームに WebVR サポートを追加する方法](https://docs.microsoft.com/en-us/windows/uwp/get-started/adding-webvr-to-a-babylonjs-game)に関するチュートリアルがリリースされました。</span><span class="sxs-lookup"><span data-stu-id="796db-160">The [Adding WebVR support to a 3D Babylon.js game](https://docs.microsoft.com/en-us/windows/uwp/get-started/adding-webvr-to-a-babylonjs-game) tutorial has been released.</span></span> <span data-ttu-id="796db-161">このチュートリアルを進めるには、Windows Mixed Reality ヘッドセットが必要になります。動作する Babylon.js ゲームを使い、WebVR 用に構成する方法のプロセスを順に説明します。</span><span class="sxs-lookup"><span data-stu-id="796db-161">You'll need a Windows Mixed Reality headset in order to follow the tutorial, which begins with a working Babylon.js game and steps through the process of how to configure it for WebVR.</span></span>

#### <a name="windows-ink"></a><span data-ttu-id="796db-162">Windows Ink</span><span class="sxs-lookup"><span data-stu-id="796db-162">Windows Ink</span></span>

<span data-ttu-id="796db-163">[UWP による Ink のサポート](https://docs.microsoft.com/en-us/windows/uwp/get-started/ink-walkthrough)に関するチュートリアルがリリースされました。</span><span class="sxs-lookup"><span data-stu-id="796db-163">The [Support ink in your UWP app](https://docs.microsoft.com/en-us/windows/uwp/get-started/ink-walkthrough) tutorial has been released.</span></span> <span data-ttu-id="796db-164">Windows Ink を使った描画と手書きをサポートする基本的な UWP アプリの作成方法を順に説明します。</span><span class="sxs-lookup"><span data-stu-id="796db-164">It steps through how to create a basic UWP app that supports writing and drawing with Windows Ink.</span></span>