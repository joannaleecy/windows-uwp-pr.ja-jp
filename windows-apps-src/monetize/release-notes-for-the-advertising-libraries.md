---
author: Xansky
ms.assetid: ca92bed1-ad9e-4947-ad91-87d12de727c0
description: Microsoft Advertising ライブラリのリリース ノートを確認します。
title: Advertising ライブラリのリリース ノート
ms.author: mhopkins
ms.date: 08/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 広告, 宣伝, リリース ノート
ms.localizationpriority: medium
ms.openlocfilehash: 37a5cafcc5f768e90d4ee3997f92a62a9903fc9a
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4961131"
---
# <a name="release-notes-for-the-advertising-libraries"></a><span data-ttu-id="a2399-104">Advertising ライブラリのリリース ノート</span><span class="sxs-lookup"><span data-stu-id="a2399-104">Release notes for the advertising libraries</span></span>




<span data-ttu-id="a2399-105">このセクションでは、Microsoft Advertising ライブラリの現在のリリースのリリース ノートを示します。</span><span class="sxs-lookup"><span data-stu-id="a2399-105">This section provides release notes for the current release of the Microsoft advertising libraries.</span></span> <span data-ttu-id="a2399-106">これらのライブラリは、Windows 10、Windows 8.1、Windows Phone 8.1、Windows Phone 8 用の XAML アプリと JavaScript/HTML アプリをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a2399-106">These libraries support XAML and JavaScript/HTML apps for Windows 10, Windows 8.1, Windows Phone 8.1 and Windows Phone 8.</span></span>

## <a name="installation"></a><span data-ttu-id="a2399-107">インストール</span><span class="sxs-lookup"><span data-stu-id="a2399-107">Installation</span></span>


<span data-ttu-id="a2399-108">Microsoft Advertising ライブラリは、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) の一部として利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="a2399-108">The Microsoft advertising libraries are available as part of the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span> <span data-ttu-id="a2399-109">SDK のインストールについて詳しくは、「[Microsoft Advertising SDK のインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2399-109">For more information about installing the SDK, see [Install the Microsoft Advertising SDK](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="uninstall-previous-versions"></a><span data-ttu-id="a2399-110">以前のバージョンのアンインストール</span><span class="sxs-lookup"><span data-stu-id="a2399-110">Uninstall previous versions</span></span>

<span data-ttu-id="a2399-111">最新の Microsoft Advertising SDK をインストールする前に、SDK の以前のインスタンスをすべてアンインストールすることを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2399-111">Before you install the latest Microsoft Advertising SDK, it is highly recommended that you uninstall all prior instances of the SDK.</span></span> <span data-ttu-id="a2399-112">詳しくは、「[Microsoft Advertising SDK のインストール](install-the-microsoft-advertising-libraries.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2399-112">For more information, see [Install the Microsoft Advertising SDK](install-the-microsoft-advertising-libraries.md).</span></span>

## <a name="target-architecture-specific-build-outputs"></a><span data-ttu-id="a2399-113">ターゲット アーキテクチャ固有のビルドの出力</span><span class="sxs-lookup"><span data-stu-id="a2399-113">Target architecture-specific build outputs</span></span>

<span data-ttu-id="a2399-114">Microsoft Advertising ライブラリを使う場合、プロジェクトで **Any CPU** をターゲットにすることはできません。</span><span class="sxs-lookup"><span data-stu-id="a2399-114">When using the Microsoft advertising libraries, you cannot target **Any CPU** in your project.</span></span> <span data-ttu-id="a2399-115">プロジェクトでのターゲットを **Any CPU** プラットフォームに設定している場合は、Microsoft Advertising ライブラリに参照を追加した後で警告メッセージが表示される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a2399-115">If your project targets the **Any CPU** platform, you may see a warning in your project after you add a reference to the Microsoft advertising libraries.</span></span> <span data-ttu-id="a2399-116">この警告を解決するには、アーキテクチャ固有のビルド出力 (たとえば、**x86**) を使用するようにプロジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="a2399-116">To remove this warning, update your project to use an architecture-specific build output (for example, **x86**).</span></span> <span data-ttu-id="a2399-117">詳しくは、「[既知の問題](known-issues-for-the-advertising-libraries.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2399-117">For more information, see [Known issues](known-issues-for-the-advertising-libraries.md).</span></span>

## <a name="c-support"></a><span data-ttu-id="a2399-118">C++ のサポート</span><span class="sxs-lookup"><span data-stu-id="a2399-118">C++ Support</span></span>

<span data-ttu-id="a2399-119">Microsoft Advertising ライブラリ (**AdControl** クラスと **InterstitialAd** クラスが含まれる) は、Windows ランタイムの相互運用性 (*相互運用機能*) を使用して C++ および DirectX で記述されたアプリをサポートします。</span><span class="sxs-lookup"><span data-stu-id="a2399-119">The Microsoft advertising libraries (which include the **AdControl** and **InterstitialAd** classes) support apps written in C++ and DirectX using Windows Runtime Interoperability (*interop*).</span></span> <span data-ttu-id="a2399-120">XAML と C++ を使ったプログラミングの詳細情報と例については、「[型システム](https://docs.microsoft.com/cpp/cppcx/type-system-c-cx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2399-120">For more information and examples about programming using XAML and C++, see [Type System](https://docs.microsoft.com/cpp/cppcx/type-system-c-cx).</span></span>

## <a name="no-toolbox-control"></a><span data-ttu-id="a2399-121">ツールボックス コントロールはない</span><span class="sxs-lookup"><span data-stu-id="a2399-121">No toolbox control</span></span>

<span data-ttu-id="a2399-122">[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) に含まれる Microsoft Advertising ライブラリの現在のリリースには、**AdControl** や **InterstitialAd** をアプリのデザイン サーフェイスにドラッグするためのツールボックス コントロールはありません。</span><span class="sxs-lookup"><span data-stu-id="a2399-122">In the current release of the Microsoft advertising libraries in the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp), there is no toolbox control for dragging an **AdControl** or **InterstitialAd** to a design surface in your app.</span></span> <span data-ttu-id="a2399-123">マークアップとコードでこれらのコントロールを追加する方法については、[開発者向けのチュートリアル](developer-walkthroughs.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2399-123">For instructions about adding these controls in your markup and code, see the [developer walkthroughs](developer-walkthroughs.md).</span></span>

## <a name="latitude-and-longitude-properties-no-longer-available"></a><span data-ttu-id="a2399-124">使用できなくなった緯度と経度のプロパティ</span><span class="sxs-lookup"><span data-stu-id="a2399-124">Latitude and longitude properties no longer available</span></span>

<span data-ttu-id="a2399-125">**AdControl**クラスに、UWP アプリ用の **Latitude** プロパティと **Longitude** プロパティは含まれなくなりました。</span><span class="sxs-lookup"><span data-stu-id="a2399-125">The **AdControl** class no longer has **Latitude** and **Longitude** properties for UWP apps.</span></span> <span data-ttu-id="a2399-126">代わりに、広告コントロールに組み込まれているコードが、アプリに代わってこれらの値を検出し、広告サーバーに送信します。</span><span class="sxs-lookup"><span data-stu-id="a2399-126">Instead, code built into the ad control will detect and send these values to the ad servers on the app’s behalf.</span></span>


 

 
