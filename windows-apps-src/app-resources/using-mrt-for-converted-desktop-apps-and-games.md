---
author: ptorr-msft
title: 変換されたデスクトップ アプリとゲームに MRT を使用する
description: .NET または Win32 アプリやゲームを AppX パッケージとしてパッケージ化することにより、リソース管理システムを活用して実行時のコンテキストに合わせたアプリ リソースを読み込むことができます。 この詳細なトピックでは、この手法について説明します。
ms.author: ptorr
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10, UWP, MRT, PRI,  リソース, ゲーム, Centennial, Desktop App Converter, MUI, サテライト アセンブリ
ms.localizationpriority: medium
ms.openlocfilehash: 927e0c5438ea11b751fba40cb76210d0bce112d4
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5689229"
---
# <a name="use-the-windows-10-resource-management-system-in-a-legacy-app-or-game"></a><span data-ttu-id="80a44-106">レガシ アプリやゲームで Windows 10 のリソース管理システムを使用する</span><span class="sxs-lookup"><span data-stu-id="80a44-106">Use the Windows 10 Resource Management System in a legacy app or game</span></span>

## <a name="overview"></a><span data-ttu-id="80a44-107">概要</span><span class="sxs-lookup"><span data-stu-id="80a44-107">Overview</span></span>

<span data-ttu-id="80a44-108">.NET アプリや Win32 アプリは多くの場合、対象市場を拡大するため、さまざまな言語にローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="80a44-108">.NET and Win32 apps and games are often localized into different languages to expand their total addressable market.</span></span> <span data-ttu-id="80a44-109">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../design/globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-109">For more info about the value proposition of localizing your app, see [Globalization and localization](../design/globalizing/globalizing-portal.md).</span></span> <span data-ttu-id="80a44-110">.NET または Win32 アプリやゲームを AppX パッケージとしてパッケージ化することにより、リソース管理システムを活用して実行時のコンテキストに合わせたアプリ リソースを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-110">By packaging your .NET or Win32 app or game as an AppX package, you can leverage the Resource Management System to load app resources tailored to the run-time context.</span></span> <span data-ttu-id="80a44-111">この詳細なトピックでは、この手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="80a44-111">This in-depth topic describes the techniques.</span></span>

<span data-ttu-id="80a44-112">従来の Win32 アプリケーションをローカライズする方法はたくさんありますが、Windows 8 では[新しいリソース管理システム](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)が導入されました。このリソース管理システムは、さまざまなプログラミング言語やさまざまな種類のアプリケーションで動作し、ローカライズ機能を簡素化するだけでなく、さまざまな機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="80a44-112">There are many ways to localize a traditional Win32 application, but Windows 8 introduced a [new resource-management system](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx) that works across programming languages, across application types, and provides functionality over and above simple localization.</span></span> <span data-ttu-id="80a44-113">このトピックでは、このシステムを "MRT" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="80a44-113">This system will be referred to as "MRT" in this topic.</span></span> <span data-ttu-id="80a44-114">「モダン」という用語の使用は停止されましたが、MRT は従来 "Modern Resource Technology" を表していました。</span><span class="sxs-lookup"><span data-stu-id="80a44-114">Historically, that stood for "Modern Resource Technology" but the term "Modern" has been discontinued.</span></span> <span data-ttu-id="80a44-115">リソース マネージャーは、MRM (モダン リソース マネージャー) または PRI (パッケージ リソース インデックス) としても知られています。</span><span class="sxs-lookup"><span data-stu-id="80a44-115">The resource manager might also be known as MRM (Modern Resource Manager) or PRI (Package Resource Index).</span></span>

<span data-ttu-id="80a44-116">AppX ベースの展開 (Microsoft Store を使った展開など) と組み合わせることにより、MRT はユーザーとデバイスに最適なリソースを自動的に配布します。これにより、アプリケーションのダウンロードとインストールのサイズを最小化することができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-116">Combined with AppX-based deployment (for example, from the Microsoft Store), MRT can automatically deliver the most-applicable resources for a given user / device which minimizes the download and install size of your application.</span></span> <span data-ttu-id="80a44-117">ローカライズ コンテンツのサイズが大きなアプリケーションでは、これによって大きなサイズ削減効果があり、高度なゲームの場合では、数*ギガバイト*にも及ぶ削減効果となることがあります。</span><span class="sxs-lookup"><span data-stu-id="80a44-117">This size reduction can be significant for applications with a large amount of localized content, perhaps on the order of several *gigabytes* for AAA games.</span></span> <span data-ttu-id="80a44-118">さらに、Windows シェルと Microsoft Store でローカライズされて表示されることや、ユーザーの使用言語と利用可能なリソースが一致しない場合の自動フォールバック ロジックなども、MRT によるメリットの例です。</span><span class="sxs-lookup"><span data-stu-id="80a44-118">Additional benefits of MRT include localized listings in the Windows Shell and the Microsoft Store, automatic fallback logic when a user's preferred language doesn't match your available resources.</span></span>

<span data-ttu-id="80a44-119">このドキュメントでは、MRT のアーキテクチャの概要を説明し、レガシの Win32 アプリケーションを最小限のコード変更で MRT に移行するためのガイドを示します。</span><span class="sxs-lookup"><span data-stu-id="80a44-119">This document describes the high-level architecture of MRT and provides a porting guide to help move legacy Win32 applications to MRT with minimal code changes.</span></span> <span data-ttu-id="80a44-120">MRT への移行により、開発者にはさまざまなメリット (スケール ファクターやシステム テーマを使ったリソースのセグメント化など) があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-120">Once the move to MRT is made, additional benefits (such as the ability to segment resources by scale factor or system theme) become available to the developer.</span></span> <span data-ttu-id="80a44-121">MRT ベースのローカライズは、UWP アプリケーションと、デスクトップ ブリッジ ("Centennial") によって処理される Win32 アプリケーションの両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="80a44-121">Note that MRT-based localization works for both UWP applications and Win32 applications processed by the Desktop Bridge (aka "Centennial").</span></span>

<span data-ttu-id="80a44-122">多くの場合、既存のローカライズ形式とソース コードを引き続き使用しながら、MRT との統合を行い、実行時にリソースを解決して、ダウンロード サイズを最小化することができます。これはオールオアナッシングのアプローチではありません。</span><span class="sxs-lookup"><span data-stu-id="80a44-122">In many situations, you can continue to use your existing localization formats and source code whilst integrating with MRT for resolving resources at runtime and minimizing download sizes - it's not an all-or-nothing approach.</span></span> <span data-ttu-id="80a44-123">各段階での作業とメリット、推定コストを次の表にまとめて示します。</span><span class="sxs-lookup"><span data-stu-id="80a44-123">The following table summarizes the work and estimated cost/benefit of each stage.</span></span> <span data-ttu-id="80a44-124">この表には、高解像度またはハイ コントラストのアプリケーション アイコンの提供などの、ローカライズ以外のタスクは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="80a44-124">This table doesn't include non-localization tasks, such as providing high-resolution or high-contrast application icons.</span></span> <span data-ttu-id="80a44-125">タイル、アイコンなどへの複数のアセットの提供について詳しくは、「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-125">For more info about providing multiple assets for tiles, icons, etc., See [Tailor your resources for language, scale, high contrast, and other qualifiers](tailor-resources-lang-scale-contrast.md).</span></span>

<table>
<tr>
<th><span data-ttu-id="80a44-126">作業</span><span class="sxs-lookup"><span data-stu-id="80a44-126">Work</span></span></th>
<th><span data-ttu-id="80a44-127">メリット</span><span class="sxs-lookup"><span data-stu-id="80a44-127">Benefit</span></span></th>
<th><span data-ttu-id="80a44-128">推定コスト</span><span class="sxs-lookup"><span data-stu-id="80a44-128">Estimated cost</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="80a44-129">AppX マニフェストをローカライズする</span><span class="sxs-lookup"><span data-stu-id="80a44-129">Localize AppX manifest</span></span></td>
<td><span data-ttu-id="80a44-130">Windows シェルと Microsoft Store でローカライズ コンテンツが表示されるために必要な最小限の作業</span><span class="sxs-lookup"><span data-stu-id="80a44-130">Bare minimum work required to have your localized content appear in the Windows Shell and in the Microsoft Store</span></span></td>
<td><span data-ttu-id="80a44-131">小</span><span class="sxs-lookup"><span data-stu-id="80a44-131">Small</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="80a44-132">MRT を使ってリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="80a44-132">Use MRT to identify and locate resources</span></span></td>
<td><span data-ttu-id="80a44-133">ダウンロードとインストールのサイズの最小化や、言語の自動フォールバックの前提条件</span><span class="sxs-lookup"><span data-stu-id="80a44-133">Pre-requisite to minimizing download and install sizes; automatic language fallback</span></span></td>
<td><span data-ttu-id="80a44-134">中</span><span class="sxs-lookup"><span data-stu-id="80a44-134">Medium</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="80a44-135">リソース パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-135">Build resource packs</span></span></td>
<td><span data-ttu-id="80a44-136">ダウンロードとインストールのサイズを最小化するための最後の手順</span><span class="sxs-lookup"><span data-stu-id="80a44-136">Final step to minimize download and install sizes</span></span></td>
<td><span data-ttu-id="80a44-137">小</span><span class="sxs-lookup"><span data-stu-id="80a44-137">Small</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="80a44-138">MRT リソース形式と API へ移行する</span><span class="sxs-lookup"><span data-stu-id="80a44-138">Migrate to MRT resource formats and APIs</span></span></td>
<td><span data-ttu-id="80a44-139">大幅に小さなファイル サイズ (既存のリソース テクノロジによる)</span><span class="sxs-lookup"><span data-stu-id="80a44-139">Significantly smaller file sizes (depending on existing resource technology)</span></span></td>
<td><span data-ttu-id="80a44-140">大</span><span class="sxs-lookup"><span data-stu-id="80a44-140">Large</span></span></td>
</tr>
</table>

## <a name="introduction"></a><span data-ttu-id="80a44-141">はじめに</span><span class="sxs-lookup"><span data-stu-id="80a44-141">Introduction</span></span>

<span data-ttu-id="80a44-142">多くのアプリケーションには通常、アプリケーション コードから分離された、*リソース*と呼ばれるユーザー インターフェイス要素が含まれています (一方、値を*ハードコード*する場合は、ソース コード自体に記述されます)。</span><span class="sxs-lookup"><span data-stu-id="80a44-142">Most non-trivial applications contain user-interface elements known as *resources* that are decoupled from the application's code (contrasted with *hard-coded values* that are authored in the source code itself).</span></span> <span data-ttu-id="80a44-143">ハードコードしないで、リソースを使用することが好ましい理由はいろいろあります。たとえば、開発者以外でも編集が容易であることもその 1 つです。最も重要なメリットの 1 つは、アプリケーションが実行時に、同じ論理リソースの異なる表現を選択できることです。</span><span class="sxs-lookup"><span data-stu-id="80a44-143">There are several reasons to prefer resources over hard-coded values - ease of editing by non-developers, for example - but one of the key reasons is to enable the application to pick different representations of the same logical resource at runtime.</span></span> <span data-ttu-id="80a44-144">たとえば、ボタンに表示するテキスト (またはアイコンに表示するイメージ) が、ユーザーの使用言語や、表示デバイスの種類、使用している支援技術などによって、異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-144">For example, the text to display on a button (or the image to display in an icon) might differ depending on the language(s) the user understands, the characteristics of the display device, or whether the user has any assistive technologies enabled.</span></span>

<span data-ttu-id="80a44-145">したがって、リソース管理テクノロジの主な目的は、実行時に、論理またはシンボリックな*リソース名* (`SAVE_BUTTON_LABEL`など) の要求を、一連の*候補* (たとえば、「Save」、「Speichern」、「保存」) の中から、実際に最適な*値* (たとえば「保存」) に変換することです。</span><span class="sxs-lookup"><span data-stu-id="80a44-145">Thus the primary purpose of any resource-management technology is to translate, at runtime, a request for a logical or symbolic *resource name* (such as `SAVE_BUTTON_LABEL`) into the best possible actual *value* (eg, "Save") from a set of possible *candidates* (eg, "Save", "Speichern", or "저장").</span></span> <span data-ttu-id="80a44-146">MRT はそのための機能を提供し、アプリケーションは、*修飾子*と呼ばれる、ユーザーの言語、ディスプレイのスケール ファクター、ユーザーが選択したテーマ、その他の環境の要因などの、さまざまな属性を使って、リソースの候補を識別することができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-146">MRT provides such a function, and enables applications to identify resource candidates using a wide variety of attributes, called *qualifiers*, such as the user's language, the display scale-factor, the user's selected theme, and other environmental factors.</span></span> <span data-ttu-id="80a44-147">さらに MRT は、アプリケーションが必要とする、カスタムの修飾子をサポートします (たとえば、アプリケーションが、ゲスト ユーザーとアカウントを使ってログインしたユーザーに対して、別のグラフィック アセットを提供することができます。これを、アプリケーションのあらゆる部分にチェックのロジックを追加することなく、行えます)。</span><span class="sxs-lookup"><span data-stu-id="80a44-147">MRT even supports custom qualifiers for applications that need it (for example, an application could provide different graphic assets for users that had logged in with an account vs. guest users, without explicitly adding this check into every part of their application).</span></span> <span data-ttu-id="80a44-148">MRT は、文字列リソースとファイル ベースのリソース (外部データ、つまりファイル自体への参照として実装されている場合) の両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="80a44-148">MRT works with both string resources and file-based resources, where file-based resources are implemented as references to the external data (the files themselves).</span></span> 

### <a name="example"></a><span data-ttu-id="80a44-149">例</span><span class="sxs-lookup"><span data-stu-id="80a44-149">Example</span></span>

<span data-ttu-id="80a44-150">2 つのボタン (`openButton` と `saveButton`) 上のテキスト ラベルと、ロゴ (`logoImage`) に使用する PNG ファイルを持つアプリケーションでの、簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="80a44-150">Here's a simple example of an application that has text labels on two buttons (`openButton` and `saveButton`) and a PNG file used for a logo (`logoImage`).</span></span> <span data-ttu-id="80a44-151">テキスト ラベルは英語とドイツ語にローカライズされ、ロゴは通常のデスクトップ (100% スケール ファクター) と高解像度の電話 (300% スケール ファクター) 用に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="80a44-151">The text labels are localized into English and German, and the logo is optimized for normal desktop displays (100% scale factor) and high-resolution phones (300% scale factor).</span></span> <span data-ttu-id="80a44-152">この図は、モデルの概念と概要を説明するためのものであり、実装に正確に対応するものではないことにご注意ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-152">Note that this diagram presents a high-level, conceptual view of the model; it does not map exactly to implementation.</span></span>

<p><img src="images\conceptual-resource-model.png"/></p>

<span data-ttu-id="80a44-153">この図で、アプリケーション コードは 3 つの論理リソース名を参照しています。</span><span class="sxs-lookup"><span data-stu-id="80a44-153">In the graphic, the application code references the three logical resource names.</span></span> <span data-ttu-id="80a44-154">実行時に、擬似関数 `GetResource` は、MRT を使用して、リソース テーブル (PRI ファイルと呼ばれます) で、そのリソース名を検索し、環境条件 (ユーザーの言語とディスプレイのスケール ファクター) に基づいて、最適な候補を見つけます。</span><span class="sxs-lookup"><span data-stu-id="80a44-154">At runtime, the `GetResource` pseudo-function uses MRT to look those resource names up in the resource table (known as PRI file) and find the most appropriate candidate based on the ambient conditions (the user's language and the display's scale-factor).</span></span> <span data-ttu-id="80a44-155">ラベルの場合は、文字列が直接使用されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-155">In the case of the labels, the strings are used directly.</span></span> <span data-ttu-id="80a44-156">ロゴ イメージの場合は、文字列がファイル名として解釈され、ファイルがディスクから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="80a44-156">In the case of the logo image, the strings are interpreted as filenames and the files are read off disk.</span></span> 

<span data-ttu-id="80a44-157">ユーザーの言語が英語とドイツ語以外の場合、またディスプレイのスケール ファクターが 100% と 300% 以外の場合は、MRT はフォールバック規則のセットに基づいて、最も「近い」候補を選びます (詳しくは、[MSDN の**リソース管理システム**のトピック](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-157">If the user speaks a language other than English or German, or has a display scale-factor other than 100% or 300%, MRT picks the "closest" matching candidate based on a set of fallback rules (see [the **Resource Management System** topic on MSDN](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx) for more background).</span></span> 

<span data-ttu-id="80a44-158">MRT は複数の修飾子に合わせてカスタマイズされたリソースをサポートします。たとえば、ロゴ イメージに埋め込みのテキストが含まれ、そのテキストをローカライズする必要がある場合には、そのロゴは 4 つの候補 (EN/スケール-100、DE/スケール-100、EN/スケール-300、DE/スケール-300) を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-158">Note that MRT supports resources that are tailored to more than one qualifier - for example, if the logo image contained embedded text that also needed to be localized, the logo would have four candidates: EN/Scale-100, DE/Scale-100, EN/Scale-300 and DE/Scale-300.</span></span>

### <a name="sections-in-this-document"></a><span data-ttu-id="80a44-159">このドキュメントのセクション</span><span class="sxs-lookup"><span data-stu-id="80a44-159">Sections in this document</span></span>

<span data-ttu-id="80a44-160">以下のセクションでは、アプリケーションを MRT と統合するために必要なタスクの概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="80a44-160">The following sections outline the high-level tasks required to integrate MRT with your application.</span></span>

**<span data-ttu-id="80a44-161">フェーズ 0: アプリケーション パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-161">Phase 0: Build an application package</span></span>**

<span data-ttu-id="80a44-162">このセクションでは、既存のデスクトップ アプリケーションを、アプリケーション パッケージとしてビルドする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="80a44-162">This section outlines how to get your existing Desktop application building as an application package.</span></span> <span data-ttu-id="80a44-163">この段階では、MRT の機能は使用しません。</span><span class="sxs-lookup"><span data-stu-id="80a44-163">No MRT features are used at this stage.</span></span>

**<span data-ttu-id="80a44-164">フェーズ 1: アプリケーション マニフェストをローカライズする</span><span class="sxs-lookup"><span data-stu-id="80a44-164">Phase 1: Localize the application manifest</span></span>**

<span data-ttu-id="80a44-165">このセクションでは、アプリケーションのマニフェストをローカライズする (これにより Windows Shell に正しく表示されるようになります) 方法について説明します。この段階では、引き続き、レガシのリソース形式と API を使用して、リソースのパッケージ化と検索を行っています。</span><span class="sxs-lookup"><span data-stu-id="80a44-165">This section outlines how to localize your application's manifest (so that it appears correctly in the Windows Shell) whilst still using your legacy resource format and API to package and locate resources.</span></span> 

**<span data-ttu-id="80a44-166">フェーズ 2: MRT を使用してリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="80a44-166">Phase 2: Use MRT to identify and locate resources</span></span>**

<span data-ttu-id="80a44-167">このセクションでは、アプリケーション コード (および場合によってリソース レイアウト) を変更し、MRT を使用してリソースを検索する方法について説明します。この段階では、引き続き、既存のリソース形式と API を使用して、リソースの読み込みと使用を行っています。</span><span class="sxs-lookup"><span data-stu-id="80a44-167">This section outlines how to modify your application code (and possibly resource layout) to locate resources using MRT, whilst still using your existing resource formats and APIs to load and consume the resources.</span></span> 

**<span data-ttu-id="80a44-168">フェーズ 3: リソース パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-168">Phase 3: Build resource packs</span></span>**

<span data-ttu-id="80a44-169">このセクションでは、リソースを別の*リソース パッケージ*に分離して、アプリのダウンロード (およびインストール) のサイズを最小化するために必要な、最終的な変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="80a44-169">This section outlines the final changes needed to separate your resources into separate *resource packs*, minimizing the download (and install) size of your app.</span></span>

### <a name="not-covered-in-this-document"></a><span data-ttu-id="80a44-170">このドキュメントで扱わない内容</span><span class="sxs-lookup"><span data-stu-id="80a44-170">Not covered in this document</span></span>

<span data-ttu-id="80a44-171">フェーズ 0 ～ 3 を完了すると、Microsoft Store に提出できる、アプリケーション「バンドル」が作成されます。これにより、ユーザーは不要なリソース (たとえば、使用しない言語) を省略でき、ダウンロードとインストールのサイズを最小化できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-171">After completing Phases 0-3 above, you will have an application "bundle" that can be submitted to the Microsoft Store and that will minimize the download & install size for users by omitting the resources they don't need (eg, languages they don't speak).</span></span> <span data-ttu-id="80a44-172">次の最後の手順を実行すると、アプリケーションのサイズと機能をさらに向上することができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-172">Further improvements in application size and functionality can be made by taking one final step.</span></span> 

**<span data-ttu-id="80a44-173">フェーズ 4: MRT リソース形式と API に移行する</span><span class="sxs-lookup"><span data-stu-id="80a44-173">Phase 4: Migrate to MRT resource formats and APIs</span></span>**

<span data-ttu-id="80a44-174">このフェーズは、このドキュメントの対象範囲外です。このフェーズでは、MUI DLL や .NET リソース アセンブリなどの、レガシのリソース形式から、PRI ファイルに、リソース (特に文字列) を移行します。</span><span class="sxs-lookup"><span data-stu-id="80a44-174">This phase is beyond the scope of this document; it entails moving your resources (particularly strings) from legacy formats such as MUI DLLs or .NET resource assemblies into PRI files.</span></span> <span data-ttu-id="80a44-175">これにより、ダウンロードとインストールのサイズをさらに節約できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-175">This can lead to further space savings for download & install sizes.</span></span> <span data-ttu-id="80a44-176">さらに、MRT の他の機能を活用でき、たとえば、スケール ファクターや、アクセシビリティ設定などに基づいて、イメージ ファイルのダウンロードとインストールを最小化できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-176">It also allows use of other MRT features such as minimizing the download and install of image files by based on scale factor, accessibility settings, and so on.</span></span>

- - -

## <a name="phase-0-build-an-application-package"></a><span data-ttu-id="80a44-177">フェーズ 0: アプリケーション パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-177">Phase 0: Build an application package</span></span>

<span data-ttu-id="80a44-178">アプリケーションのリソースへの変更を行う前にまず、現在使っているパッケージ化とインストールのテクノロジを、UWP の標準のパッケージ化と展開のテクノロジに置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-178">Before you make any changes to your application's resources, you must first replace your current packaging and installation technology with the standard UWP packaging and deployment technology.</span></span> <span data-ttu-id="80a44-179">これには 3 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-179">There are three ways to do this:</span></span>

0. <span data-ttu-id="80a44-180">複雑なインストーラーを備えた大規模なデスクトップ アプリケーションの場合、または多くの OS 拡張ポイントを利用している場合、Desktop App Converter ツールを使用して、既存のアプリ インストーラー (たとえば MSI) から、UWP ファイル レイアウトとマニフェスト情報を生成できます</span><span class="sxs-lookup"><span data-stu-id="80a44-180">If you have a large Desktop application with a complex installer or you utilize lots of OS extensibility points, you can use the Desktop App Converter tool to generate the UWP file layout and manifest information from your existing app installer (eg, an MSI)</span></span>
0. <span data-ttu-id="80a44-181">比較的少ないファイルを扱う小規模なデスクトップ アプリケーションの場合、または拡張フックを使用しないシンプルなインストーラーの場合、手動でファイル レイアウトとマニフェスト情報を作成できます</span><span class="sxs-lookup"><span data-stu-id="80a44-181">If you have a smaller Desktop application with relatively few files or a simple installer and no extensibility hooks, you can create the file layout and manifest information manually</span></span>
0. <span data-ttu-id="80a44-182">ソースからのリビルドを行って、アプリを「純粋な」UWP アプリケーションに更新する場合は、Visual Studio で新しいプロジェクトを作成し、IDE を活用して多くの作業を行うことができます</span><span class="sxs-lookup"><span data-stu-id="80a44-182">If you're rebuilding from source and want to update your app to be a "pure" UWP application, you can create a new project in Visual Studio and rely on the IDE to do much of the work for you</span></span>

<span data-ttu-id="80a44-183">[Desktop App Converter](https://aka.ms/converter) を使用する場合、変換プロセスについて詳しくは [MSDN の**Desktop から UWP ブリッジ: Desktop App Converter** のトピック](https://aka.ms/converterdocs)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-183">If you want to use the [Desktop App Converter](https://aka.ms/converter), please refer to [the **Desktop to UWP Bridge: Desktop App Converter** topic on MSDN](https://aka.ms/converterdocs) for more information on the conversion process.</span></span> <span data-ttu-id="80a44-184">Desktop Converter のサンプルの完全なセットは、[GitHub リポジトリの **Desktop Bridge to UWP サンプル**](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)にあります。</span><span class="sxs-lookup"><span data-stu-id="80a44-184">A complete set of Desktop Converter samples can be found on [the **Desktop Bridge to UWP samples** GitHub repo](https://github.com/Microsoft/DesktopBridgeToUWP-Samples).</span></span>

<span data-ttu-id="80a44-185">パッケージを手動で作成する場合は、すべてのアプリケーション ファイル (実行可能ファイルとコンテンツを含む、ソース コードは含まない) と `AppXManifest.xml` ファイルを含む、ディレクトリ構造を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-185">If you want to manually create the package, you will need to create a directory structure that includes all your application's files (executables and content, but not source code) and an `AppXManifest.xml` file.</span></span> <span data-ttu-id="80a44-186">例として [GitHub サンプルの **Hello, World**](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/HelloWorldSample/CentennialPackage/AppxManifest.xml) をご覧ください。デスクトップの実行可能ファイル `ContosoDemo.exe` を実行する、基本的な `AppXManifest.xml` ファイルは次のとおりです。<span style="background-color: yellow">強調表示されているテキスト</span>を置き換えて使うことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-186">An example can be found in [the **Hello, World** GitHub sample](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/HelloWorldSample/CentennialPackage/AppxManifest.xml), but a basic `AppXManifest.xml` file that runs the Desktop executable named `ContosoDemo.exe` is as follows, where the <span style="background-color: yellow">highlighted text</span> would be replaced by your own values:</span></span>

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8" ?&gt;
&lt;Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
         xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
         IgnorableNamespaces="uap mp rescap"&gt;
    &lt;Identity Name="<span style="background-color: yellow">Contoso.Demo</span>"
              Publisher="<span style="background-color: yellow">CN=Contoso.Demo</span>"
              Version="<span style="background-color: yellow">1.0.0.0</span>" /&gt;
    &lt;Properties&gt;
    &lt;DisplayName&gt;<span style="background-color: yellow">Contoso App</span>&lt;/DisplayName&gt;
    &lt;PublisherDisplayName&gt;<span style="background-color: yellow">Contoso, Inc</span>&lt;/PublisherDisplayName&gt;
    &lt;Logo&gt;Assets\StoreLogo.png&lt;/Logo&gt;
  &lt;/Properties&gt;
    &lt;Dependencies&gt;
    &lt;TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.0" 
                        MaxVersionTested="10.0.14393.0" /&gt;
  &lt;/Dependencies&gt;
    &lt;Resources&gt;
    &lt;Resource Language="<span style="background-color: yellow">en-US</span>" /&gt;
  &lt;/Resources&gt;
    &lt;Applications&gt;
    &lt;Application Id="<span style="background-color: yellow">ContosoDemo</span>" Executable="<span style="background-color: yellow">ContosoDemo.exe</span>" 
                 EntryPoint="Windows.FullTrustApplication"&gt;
    &lt;uap:VisualElements DisplayName="<span style="background-color: yellow">Contoso Demo</span>" BackgroundColor="#777777" 
                        Square150x150Logo="Assets\Square150x150Logo.png" 
                        Square44x44Logo="Assets\Square44x44Logo.png" 
        Description="<span style="background-color: yellow">Contoso Demo</span>"&gt;
      &lt;/uap:VisualElements&gt;
    &lt;/Application&gt;
  &lt;/Applications&gt;
    &lt;Capabilities&gt;
    &lt;rescap:Capability Name="runFullTrust" /&gt;
  &lt;/Capabilities&gt;
&lt;/Package&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-187">`AppXManifest.xml` ファイルとパッケージ レイアウトについて詳しくは、[MSDN の**アプリ パッケージ マニフェスト**のトピック](https://msdn.microsoft.com/en-us/library/windows/apps/br211474.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-187">For more information about the `AppXManifest.xml` file and package layout, see [the **App package manifest** topic on MSDN](https://msdn.microsoft.com/en-us/library/windows/apps/br211474.aspx).</span></span>

<span data-ttu-id="80a44-188">最後に、Visual Studio を使って新しいプロジェクトを作成し、既存のコード全体を移行するには、[新しい UWP プロジェクトをビルドするための MSDN ドキュメント](https://msdn.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-188">Finally, if you're using Visual Studio to create a new project and migrate your existing code across, see [the MSDN documentation for building a new UWP project](https://msdn.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span> <span data-ttu-id="80a44-189">既存のコードを新しいプロジェクトに含めることはできますが、「純粋な」UWP として実行するためには、相当なコードの変更 (特にユーザー インターフェイス) が必要となる場合があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-189">You can include your existing code into the new project, but you will likely have to make significant code changes (particularly in the user interface) in order to run as a "pure" UWP.</span></span> <span data-ttu-id="80a44-190">それらの変更は、このドキュメントの対象範囲外です。</span><span class="sxs-lookup"><span data-stu-id="80a44-190">These changes are outside the scope of this document.</span></span>

***

## <a name="phase-1-localize-the-application-manifest"></a><span data-ttu-id="80a44-191">フェーズ 1: アプリケーション マニフェストをローカライズする</span><span class="sxs-lookup"><span data-stu-id="80a44-191">Phase 1: Localize the application manifest</span></span>

### <a name="step-11-update-strings--assets-in-the-appxmanifest"></a><span data-ttu-id="80a44-192">手順 1.1: AppXManifest の文字列とアセットを更新する</span><span class="sxs-lookup"><span data-stu-id="80a44-192">Step 1.1: Update strings & assets in the AppXManifest</span></span>

<span data-ttu-id="80a44-193">フェーズ 0 でアプリケーションのための、基本的な `AppXManifest.xml` ファイルを (コンバーターに提供された値に基づき、または MSI ファイルから抽出し、またはマニフェストに手動で入力して) 作成しましたが、これにはローカライズされた情報は含まれていません。また、高解像度用のスタート画面のタイルのアセットなど、追加機能のサポートも含まれません。</span><span class="sxs-lookup"><span data-stu-id="80a44-193">In Phase 0 you created a basic `AppXManifest.xml` file for your application (based on values provided to the converter, extracted from the MSI, or manually entered into the manifest) but it will not contain localized information, nor will it support additional features like high-resolution Start tile assets, etc.</span></span> 

<span data-ttu-id="80a44-194">アプリケーションの名前と説明が正しくローカライズされるためには、リソース ファイルのセットでリソースを定義し、AppX マニフェストを更新して、それらを参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-194">To ensure your application's name and description are correctly localized, you must define some resources in a set of resource files, and update the AppX Manifest to reference them.</span></span>

**<span data-ttu-id="80a44-195">既定のリソース ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="80a44-195">Creating a default resource file</span></span>**

<span data-ttu-id="80a44-196">最初の手順では、既定の言語 (たとえば、英語 (米国)) で既定のリソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-196">The first step is to create a default resource file in your default language (eg, US English).</span></span> <span data-ttu-id="80a44-197">これは、テキスト エディターを使って手動で作成するか、または Visual Studio のリソース デザイナーによって行うことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-197">You can do this either manually with a text editor, or via the Resource Designer in Visual Studio.</span></span>

<span data-ttu-id="80a44-198">リソースを手動で作成する場合には:</span><span class="sxs-lookup"><span data-stu-id="80a44-198">If you want to create the resources manually:</span></span>

0. <span data-ttu-id="80a44-199">`resources.resw` という XML ファイルを作成して、プロジェクトの `Strings\en-us` サブフォルダーに配置します。</span><span class="sxs-lookup"><span data-stu-id="80a44-199">Create an XML file named `resources.resw` and place it in a `Strings\en-us` subfolder of your project.</span></span> 
 * <span data-ttu-id="80a44-200">既定の言語が英語 (米国) 以外の場合には、適切な BCP-47 コードを使用します。</span><span class="sxs-lookup"><span data-stu-id="80a44-200">Use the appropriate BCP-47 code if your default language is not US English</span></span> 
0. <span data-ttu-id="80a44-201">XML ファイルに次のコンテンツを追加します。使用する既定の言語で、<span style="background-color: yellow">強調表示されたテキスト</span>を、アプリのために適切なテキストに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="80a44-201">In the XML file, add the following content, where the <span style="background-color: yellow">highlighted text</span> is replaced with the appropriate text for your app, in your default language.</span></span>

<span data-ttu-id="80a44-202">**注** これらの文字列の一部については、長さに制限があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-202">**Note** There are restrictions on the lengths of some of these strings.</span></span> <span data-ttu-id="80a44-203">詳しくは、「[VisualElements](/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements?branch=live)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-203">For more info, see [VisualElements](/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements?branch=live).</span></span>

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;root&gt;
  &lt;data name="ApplicationDescription"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo app with localized resources (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="ApplicationDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Sample (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PackageDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Package (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PublisherDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Samples, USA</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="TileShortName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso (EN)</span>&lt;/value&gt;
  &lt;/data&gt;
&lt;/root&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-204">Visual Studio でデザイナーを使用する場合は:</span><span class="sxs-lookup"><span data-stu-id="80a44-204">If you want to use the designer in Visual Studio:</span></span>

0. <span data-ttu-id="80a44-205">プロジェクトで `Strings\en-us` (または必要に応じてその他の言語の) フォルダーを作成します。プロジェクトのルート フォルダーに、次の既定の名前を使って、**新しい項目**を追加します:</span><span class="sxs-lookup"><span data-stu-id="80a44-205">Create the `Strings\en-us` folder (or other language as appropriate) in your project and add a **New Item** to the root folder of your project, using the default name of</span></span> `resources.resw`
 * <span data-ttu-id="80a44-206">**リソース ディクショナリ**ではなく、必ず**リソース ファイル (.resw)** を選択します。リソース ディクショナリは、XAML アプリケーションで使われるファイルです。</span><span class="sxs-lookup"><span data-stu-id="80a44-206">Be sure to choose **Resources File (.resw)** and not **Resource Dictionary** - a Resource Dictionary is a file used by XAML applications</span></span>
0. <span data-ttu-id="80a44-207">デザイナーを使って次の文字列を入力します (同じ `Names` を使用し、`Values` をアプリケーションのために適切なテキストに置き換えます)。</span><span class="sxs-lookup"><span data-stu-id="80a44-207">Using the designer, enter the following strings (use the same `Names` but replace the `Values` with the appropriate text for your application):</span></span>

<img src="images\editing-resources-resw.png"/>

<span data-ttu-id="80a44-208">注: Visual Studio デザイナーで開始する場合は、`F7` キーを押すと、いつでも XML を直接編集できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-208">Note: if you start with the Visual Studio designer, you can always edit the XML directly by pressing `F7`.</span></span> <span data-ttu-id="80a44-209">ただし、最小限の XML ファイルで開始する場合、さまざまな追加のメタデータが含まれていないため、*デザイナーは、ファイルを認識しません*。手動で編集する XML ファイルに、デザイナーが生成したファイルからスケルトンの XSD 情報をコピーすると、この問題を解決できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-209">But if you start with a minimal XML file, *the designer will not recognize the file* because it's missing a lot of additional metadata; you can fix this by copying the boilerplate XSD information from a designer-generated file into your hand-edited XML file.</span></span> 

**<span data-ttu-id="80a44-210">マニフェストを更新してリソースを参照する</span><span class="sxs-lookup"><span data-stu-id="80a44-210">Update the manifest to reference the resources</span></span>**

<span data-ttu-id="80a44-211">`.resw`ファイルで値を定義したら、次にマニフェストを更新して、文字列リソースを参照します。</span><span class="sxs-lookup"><span data-stu-id="80a44-211">Once you have the values defined in the `.resw` file, the next step is to update the manifest to reference the resource strings.</span></span> <span data-ttu-id="80a44-212">ここでも、XML ファイルを直接編集するか、Visual Studio のマニフェスト デザイナーを利用できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-212">Again, you can edit an XML file directly, or rely on the Visual Studio Manifest Designer.</span></span>

<span data-ttu-id="80a44-213">XML を直接編集する場合は、`AppxManifest.xml` ファイルを開き、<span style="background-color: lightgreen">強調表示された値</span>に次の変更を行います。これは、アプリケーション固有ではなく、このテキストを*そのまま*使用します。</span><span class="sxs-lookup"><span data-stu-id="80a44-213">If you are editing XML directly, open the `AppxManifest.xml` file and make the following changes to the <span style="background-color: lightgreen">highlighted values</span> - use this *exact* text, not text specific to your application.</span></span> <span data-ttu-id="80a44-214">これらのリソース名をそのまま使用する必要はありません。独自の名前を使用できますが、それは `.resw` ファイル内の名前と正確に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-214">There is no requirement to use these exact resource names&mdash;you can choose your own&mdash;but whatever you choose must exactly match whatever is in the `.resw` file.</span></span> <span data-ttu-id="80a44-215">これらの名前は `.resw` ファイルで作成した `Names` と一致し、`ms-resource:` スキームと `Resources/` 名前空間のプレフィックスが付く必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-215">These names should match the `Names` you created in the `.resw` file, prefixed with the `ms-resource:` scheme and the `Resources/` namespace.</span></span> 

*<span data-ttu-id="80a44-216">注: このスニペットでは、多くのマニフェストの要素が省略されています。何も削除しないでください。</span><span class="sxs-lookup"><span data-stu-id="80a44-216">Note: many elements of the manifest have been omitted from this snippet - do not delete anything!</span></span>*

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;Package&gt;
  &lt;Properties&gt;
    &lt;DisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/PackageDisplayName</span>&lt;/DisplayName&gt;
    &lt;PublisherDisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/PublisherDisplayName</span>&lt;/PublisherDisplayName&gt;
  &lt;/Properties&gt;
  &lt;Applications&gt;
    &lt;Application&gt;
      &lt;uap:VisualElements DisplayName="<span style="background-color: lightgreen">ms-resource:Resources/ApplicationDisplayName</span>"
        Description="<span style="background-color: lightgreen">ms-resource:Resources/ApplicationDescription</span>"&gt;
        &lt;uap:DefaultTile ShortName="<span style="background-color: lightgreen">ms-resource:Resources/TileShortName</span>"&gt;
          &lt;uap:ShowNameOnTiles&gt;
            &lt;uap:ShowOn Tile="square150x150Logo" /&gt;
          &lt;/uap:ShowNameOnTiles&gt;
        &lt;/uap:DefaultTile&gt;
      &lt;/uap:VisualElements&gt;
    &lt;/Application&gt;
  &lt;/Applications&gt;
&lt;/Package&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-217">Visual Studio のマニフェスト デザイナーを使っている場合は、`Package.appxmanifest` ファイルを開き、`Application` タブと `Packaging` タブ で、<span style="background-color: lightgreen">強調表示された値</span>を変更します。</span><span class="sxs-lookup"><span data-stu-id="80a44-217">If you are using the Visual Studio manifest designer, open the `Package.appxmanifest` file and change the <span style="background-color: lightgreen">highlighted values</span> values in the `Application` tab and the `Packaging` tab:</span></span>

<img src="images\editing-application-info.png"/>
<img src="images\editing-packaging-info.png"/>

### <a name="step-12-build-pri-file-make-an-appx-package-and-verify-its-working"></a><span data-ttu-id="80a44-218">手順 1.2: PRI ファイルをビルドし、AppX パッケージを作成して、動作を確認する</span><span class="sxs-lookup"><span data-stu-id="80a44-218">Step 1.2: Build PRI file, make an AppX package, and verify it's working</span></span>

<span data-ttu-id="80a44-219">`.pri` ファイルをビルドし、アプリケーションを展開して、(既定の言語で) 正しい情報がスタート メニューに表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="80a44-219">You should now be able to build the `.pri` file and deploy the application to verify that the correct information (in your default language) is appearing in the Start Menu.</span></span> 

<span data-ttu-id="80a44-220">Visual Studio でビルドを行う場合は、`Ctrl+Shift+B` を押すとプロジェクトをビルドできます。次にプロジェクトを右クリックして、コンテキスト メニューから `Deploy` を選択します。</span><span class="sxs-lookup"><span data-stu-id="80a44-220">If you're building in Visual Studio, simply press `Ctrl+Shift+B` to build the project and then right-click on the project and choose `Deploy` from the context menu.</span></span> 

<span data-ttu-id="80a44-221">手動でビルドを行う場合は、次の手順に従って、`MakePRI` ツールの構成ファイルを作成し、`.pri` ファイル自体を生成します (詳しくは、[MSDN の**手動によるアプリのパッケージ化**のトピック](https://docs.microsoft.com/en-us/windows/uwp/packaging/manual-packaging-root)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-221">If you're building manually, follow these steps to create a configuration file for `MakePRI` tool and to generate the `.pri` file itself (more information can be found in [the **Manual app packaging** topic on MSDN](https://docs.microsoft.com/en-us/windows/uwp/packaging/manual-packaging-root)):</span></span>

0. <span data-ttu-id="80a44-222">スタート メニューの `Visual Studio 2015` フォルダーで、開発者用コマンド プロンプトを開きます</span><span class="sxs-lookup"><span data-stu-id="80a44-222">Open a developer command prompt from the `Visual Studio 2015` folder in the Start menu</span></span>
0. <span data-ttu-id="80a44-223">プロジェクトのルート ディレクトリに切り替えます (`AppxManifest.xml` ファイルと `Strings` フォルダーが含まれます)</span><span class="sxs-lookup"><span data-stu-id="80a44-223">Switch to the project root directory (the one that contains the `AppxManifest.xml` file and the `Strings` folder)</span></span>
0. <span data-ttu-id="80a44-224">"Contoso_demo.xml" をプロジェクトに適した名前に置き換え、"en-US" をアプリの既定の言語に置き換えて (または必要に応じて "en-US" のままとして)、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="80a44-224">Type the following command, replacing "contoso_demo.xml" with a name suitable for your project, and "en-US" with the default language of your app (or keep it en-US if applicable).</span></span> <span data-ttu-id="80a44-225">xml ファイルは (プロジェクト ディレクトリ**ではなく**) 親ディレクトリに作成されることに注意してください。これはアプリケーションの一部ではないためです (他の任意のディレクトリを選択できますが、それ以降のコマンドで必ず、名前を変更してください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-225">Note the xml file is created in the parent directory (**not** in the project directory) since it's not part of the application (you can choose any other directory you want, but be sure to substitute that in future commands).</span></span>

```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o
```

0. <span data-ttu-id="80a44-226">「`makepri createconfig /?`」と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="80a44-226">You can type `makepri createconfig /?` to see what each parameter does, but in summary:</span></span>
 * `/cf` <span data-ttu-id="80a44-227">構成ファイル名 (このコマンドの出力) を設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-227">sets the Configuration Filename (the output of this command)</span></span>
 * `/dq` <span data-ttu-id="80a44-228">既定の修飾子を設定します。この場合は次の言語です:</span><span class="sxs-lookup"><span data-stu-id="80a44-228">sets the Default Qualifiers, in this case the language</span></span> `en-US`
 * `/pv` <span data-ttu-id="80a44-229">プラットフォームのバージョンを設定します。この場合は Windows 10 です</span><span class="sxs-lookup"><span data-stu-id="80a44-229">sets the Platform Version, in this case Windows 10</span></span>
 * `/o` <span data-ttu-id="80a44-230">出力ファイルが存在する場合、上書きします</span><span class="sxs-lookup"><span data-stu-id="80a44-230">sets it to Overwrite the output file if it exists</span></span>
0. <span data-ttu-id="80a44-231">構成ファイルが作成されました。`MakePRI` を再度実行して、ディスクにあるリソースを検索し、それを PRI ファイルにパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="80a44-231">Now you have a configuration file, run `MakePRI` again to actually search the disk for resources and package them into a PRI file.</span></span> <span data-ttu-id="80a44-232">"Contoso_demop.xml" を、前の手順で使った XML ファイル名に置き換えます。入力と出力の両方に、必ず親ディレクトリを指定します。</span><span class="sxs-lookup"><span data-stu-id="80a44-232">Replace "contoso_demop.xml" with the XML filename you used in the previous step, and be sure to specify the parent directory for both input and output:</span></span> 

    `makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o`
0. <span data-ttu-id="80a44-233">`makepri new /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="80a44-233">You can type `makepri new /?` to see what each parameter does, but in a nutshell:</span></span>
 * `/pr` <span data-ttu-id="80a44-234">プロジェクトのルートを設定します (この場合は、現在のディレクトリです)</span><span class="sxs-lookup"><span data-stu-id="80a44-234">sets the Project Root (in this case, the current directory)</span></span>
 * `/cf` <span data-ttu-id="80a44-235">前の手順で作成した、構成ファイル名を設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-235">sets the Configuration Filename, created in the previous step</span></span>
 * `/of` <span data-ttu-id="80a44-236">出力ファイルを設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-236">sets the Output File</span></span> 
 * `/mf` <span data-ttu-id="80a44-237">マッピング ファイルを作成します (後の手順で、パッケージからファイルを除外できるようにします)</span><span class="sxs-lookup"><span data-stu-id="80a44-237">creates a Mapping File (so we can exclude files in the package in a later step)</span></span>
 * `/o` <span data-ttu-id="80a44-238">出力ファイルが存在する場合、上書きします</span><span class="sxs-lookup"><span data-stu-id="80a44-238">sets it to Overwrite the output file if it exists</span></span>
0. <span data-ttu-id="80a44-239">既定の言語リソース (たとえば en-US) を持つ `.pri` が作成されました。</span><span class="sxs-lookup"><span data-stu-id="80a44-239">Now you have a `.pri` file with the default language resources (eg, en-US).</span></span> <span data-ttu-id="80a44-240">次のコマンドを実行して、正しく動作することを確認します。</span><span class="sxs-lookup"><span data-stu-id="80a44-240">To verify that it worked correctly, you can run the following command:</span></span>

    `makepri dump /if ..\resources.pri /of ..\resources /o`
0. <span data-ttu-id="80a44-241">`makepri dump /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="80a44-241">You can type `makepri dump /?` to see what each parameter does, but in a nutshell:</span></span>
 * `/if` <span data-ttu-id="80a44-242">入力ファイル名を設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-242">sets the Input Filename</span></span> 
 * `/of` <span data-ttu-id="80a44-243">出力ファイル名を設定します (`.xml` は自動的に追加されます)</span><span class="sxs-lookup"><span data-stu-id="80a44-243">sets the Output Filename (`.xml` will be appended automatically)</span></span>
 * `/o` <span data-ttu-id="80a44-244">出力ファイルが存在する場合、上書きします</span><span class="sxs-lookup"><span data-stu-id="80a44-244">sets it to Overwrite the output file if it exists</span></span>
0. <span data-ttu-id="80a44-245">最後に、`..\resources.xml` をテキスト エディターで開き、`<NamedResource>` の値 (`ApplicationDescription` や `PublisherDisplayName` など) が含まれること、さらに選択した既定の言語の `<Candidate>` が含まれることを確認します (ファイルの先頭には、その他のコンテンツがありますが、ここでは無視してください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-245">Finally, you can open `..\resources.xml` in a text editor and verify it lists your `<NamedResource>` values (like `ApplicationDescription` and `PublisherDisplayName`) along with `<Candidate>` values for your chosen default language (there will be other content in the beginning of the file; ignore that for now).</span></span>

<span data-ttu-id="80a44-246">必要な場合は、マッピング ファイル `..\resources.map.txt` を開いて、プロジェクトに必要なファイル (PRI ファイルを含みます。これはプロジェクトのディレクトリの一部ではありません) が含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="80a44-246">If you like, you can open the mapping file `..\resources.map.txt` to verify it contains the files needed for your project (including the PRI file, which is not part of the project's directory).</span></span> <span data-ttu-id="80a44-247">マッピング ファイルには、`resources.resw` ファイルへの参照は含まれて*いません*。これは重要です。そのファイルの内容は既に PRI ファイルに埋め込まれているためです。</span><span class="sxs-lookup"><span data-stu-id="80a44-247">Importantly, the mapping file will *not* include a reference to your `resources.resw` file because the contents of that file have already been embedded in the PRI file.</span></span> <span data-ttu-id="80a44-248">ただし、イメージのファイル名などの他のリソースは含まれています。</span><span class="sxs-lookup"><span data-stu-id="80a44-248">It will, however, contain other resources like the filenames of your images.</span></span>

**<span data-ttu-id="80a44-249">パッケージをビルドして署名する</span><span class="sxs-lookup"><span data-stu-id="80a44-249">Building and signing the package</span></span>**

<span data-ttu-id="80a44-250">PRI ファイルがビルドされました。次はパッケージをビルドして署名します。</span><span class="sxs-lookup"><span data-stu-id="80a44-250">Now the PRI file is built, you can build and sign the package:</span></span>

0. <span data-ttu-id="80a44-251">アプリ パッケージを作成するには、作成する AppX ファイルの名前で `contoso_demo.appx` を置き換えて、次のコマンドを実行します。`.AppX` ファイルに別のディレクトリを選択するようにします (このサンプルでは親ディレクトリを使用しています。任意のディレクトリを指定できますが、プロジェクト ディレクトリ**以外**を指定する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="80a44-251">To create the app package, run the following command replacing `contoso_demo.appx` with the name of the AppX file you want to create and making sure to choose a different directory for the `.AppX` file (this sample uses the parent directory; it can be anywhere but should **not** be the project directory):</span></span>

    `makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o`
0. <span data-ttu-id="80a44-252">`makeappx pack /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="80a44-252">You can type `makeappx pack /?` to see what each parameter does, but in a nutshell:</span></span>
 * `/m` <span data-ttu-id="80a44-253">使用するマニフェスト ファイルを設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-253">sets the Manifest file to use</span></span>
 * `/f` <span data-ttu-id="80a44-254">(前の手順で作成された) 使用するマッピング ファイルを設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-254">sets the mapping File to use (created in the previous step)</span></span> 
 * `/p` <span data-ttu-id="80a44-255">出力パッケージの名前を設定します</span><span class="sxs-lookup"><span data-stu-id="80a44-255">sets the output Package name</span></span>
 * `/o` <span data-ttu-id="80a44-256">出力ファイルが存在する場合、上書きします</span><span class="sxs-lookup"><span data-stu-id="80a44-256">sets it to Overwrite the output file if it exists</span></span>
0. <span data-ttu-id="80a44-257">パッケージが作成されたら、それに署名する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-257">Once the package is created, it must be signed.</span></span> <span data-ttu-id="80a44-258">署名証明書を取得する最も簡単な方法は、Visual Studio で空のユニバーサル Windows プロジェクトを作成し、コピー、`.pfx`が作成されるファイルは 1 つを使って手動で作成できます、`MakeCert`と`Pvk2Pfx`ユーティリティ」の説明に従って [、**を作成する方法アプリ パッケージの署名証明書**MSDN のトピック] (https://msdn.microsoft.com/en-us/library/windows/desktop/jj835832(v=vs.85).aspx)します。</span><span class="sxs-lookup"><span data-stu-id="80a44-258">The easiest way to get a signing certificate is by creating an empty Universal Windows project in Visual Studio and copying the `.pfx` file it creates, but you can create one manually using the `MakeCert` and `Pvk2Pfx` utilities as described in [the **How to create an app package signing certificate** topic on MSDN] (https://msdn.microsoft.com/en-us/library/windows/desktop/jj835832(v=vs.85).aspx).</span></span> 
 * <span data-ttu-id="80a44-259">**重要:** 署名証明書を手動で作成した場合、必ずソース プロジェクトまたはパッケージ ソースとは別のディレクトリにファイルを配置します。そうしない場合、秘密キーも含めてパッケージに含まれてしまう場合があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-259">**Important:** If you manually create a signing certificate, make sure you place the files in a different directory than your source project or your package source, otherwise it might get included as part of the package, including the private key!</span></span>
0. <span data-ttu-id="80a44-260">パッケージに署名するには、次のコマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="80a44-260">To sign the package, use the following command.</span></span> <span data-ttu-id="80a44-261">`AppxManifest.xml` の `Identity` 要素で指定されている `Publisher` は、証明書の `Subject` と一致する必要があります (これは `<PublisherDisplayName>` 要素では**ありません**。それはユーザーに表示されるローカライズされた表示名です)。</span><span class="sxs-lookup"><span data-stu-id="80a44-261">Note that the `Publisher` specified in the `Identity` element of the `AppxManifest.xml` must match the `Subject` of the certificate (this is **not** the `<PublisherDisplayName>` element, which is the localized display name to show to users).</span></span> <span data-ttu-id="80a44-262">通常と同様に、`contoso_demo...` のファイル名をプロジェクトに適した名前で置き換えます。さらに `.pfx` ファイルが現在のディレクトリにないことを確認します (**これは非常に重要です**。そうしない場合、プライベート署名キーを含めて、パッケージの一部として作成されてしまいます)。</span><span class="sxs-lookup"><span data-stu-id="80a44-262">As usual, replace the `contoso_demo...` filenames with the names appropriate for your project, and (**very important**) make sure the `.pfx` file is not in the current directory (otherwise it would have been created as part of your package, including the private signing key!):</span></span>

    `signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appx`
0. <span data-ttu-id="80a44-263">`signtool sign /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="80a44-263">You can type `signtool sign /?` to see what each parameter does, but in a nutshell:</span></span>
 * `/fd` <span data-ttu-id="80a44-264">ファイル ダイジェスト アルゴリズムを設定します (AppX の既定は SHA256 です)</span><span class="sxs-lookup"><span data-stu-id="80a44-264">sets the File Digest algorithm (SHA256 is the default for AppX)</span></span>
 * `/a` <span data-ttu-id="80a44-265">最適な証明書を自動的に選択します</span><span class="sxs-lookup"><span data-stu-id="80a44-265">will Automatically select the best certificate</span></span>
 * `/f` <span data-ttu-id="80a44-266">署名証明書を含む入力ファイルを指定します</span><span class="sxs-lookup"><span data-stu-id="80a44-266">specifies the input File that contains the signing certificate</span></span>

<span data-ttu-id="80a44-267">最後に、`.appx` ファイルをダブルクリックしてインストールします。またはコマンド ラインを使用する場合には、PowerShell プロンプトを開き、パッケージを含むディレクトリへ移動し、次のように入力します (`contoso_demo.appx` を使用するパッケージ名に置き換えます)。</span><span class="sxs-lookup"><span data-stu-id="80a44-267">Finally, you can now double-click on the `.appx` file to install it, or if you prefer the command-line you can open a PowerShell prompt, change to the directory containing the package, and type the following (replacing `contoso_demo.appx` with your package name):</span></span>

```CMD
    add-appxpackage contoso_demo.appx
```

<span data-ttu-id="80a44-268">証明書が信頼されていないというエラーが発生した場合、証明書が (ユーザー ストア**ではなく**) コンピューターのストアに追加されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="80a44-268">If you receive errors about the certificate not being trusted, make sure it is added to the machine store (**not** the user store).</span></span> <span data-ttu-id="80a44-269">コンピューターのストアに証明書を追加するには、コマンドライン、または Windows エクスプローラーを使用します。</span><span class="sxs-lookup"><span data-stu-id="80a44-269">To add the certificate to the machine store, you can either use the command-line or Windows Explorer.</span></span>

<span data-ttu-id="80a44-270">コマンドラインを使用する場合:</span><span class="sxs-lookup"><span data-stu-id="80a44-270">To use the command-line:</span></span>

0. <span data-ttu-id="80a44-271">Visual Studio 2015 コマンド プロンプトを管理者として実行します。</span><span class="sxs-lookup"><span data-stu-id="80a44-271">Run a Visual Studio 2015 command prompt as an Administrator.</span></span>
0. <span data-ttu-id="80a44-272">`.cer` ファイルを含むディレクトリに移動します (このディレクトリが、ソース ディレクトリまたはプロジェクト ディレクトリではないことを確認してください)</span><span class="sxs-lookup"><span data-stu-id="80a44-272">Switch to the directory that contains the `.cer` file (remember to ensure this is outside of your source or project directories!)</span></span>
0. <span data-ttu-id="80a44-273">`contoso_demo.cer` を使用するファイル名と置き換えて、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="80a44-273">Type the following command, replacing `contoso_demo.cer` with your filename:</span></span>

    `certutil -addstore TrustedPeople contoso_demo.cer`
0. <span data-ttu-id="80a44-274">`certutil -addstore /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="80a44-274">You can run `certutil -addstore /?` to see what each parameter does, but in a nutshell:</span></span>
 * `-addstore` <span data-ttu-id="80a44-275">証明書ストアに証明書を追加します</span><span class="sxs-lookup"><span data-stu-id="80a44-275">adds a certificate to a certificate store</span></span>
 * `TrustedPeople` <span data-ttu-id="80a44-276">証明書が配置されたストアを示します</span><span class="sxs-lookup"><span data-stu-id="80a44-276">indicates the store into which the certificate is placed</span></span>

<span data-ttu-id="80a44-277">Windows エクスプローラーを使用する場合:</span><span class="sxs-lookup"><span data-stu-id="80a44-277">To use Windows Explorer:</span></span>

0. <span data-ttu-id="80a44-278">`.pfx` ファイルが含まれているフォルダーに移動します</span><span class="sxs-lookup"><span data-stu-id="80a44-278">Navigate to the folder that contains the `.pfx` file</span></span>
0. <span data-ttu-id="80a44-279">`.pfx` ファイルをダブルクリックすると、**証明書インポート ウィザード**が表示されます</span><span class="sxs-lookup"><span data-stu-id="80a44-279">Double-click on the `.pfx` file and the **Certicicate Import Wizard** should appear</span></span>
0. <span data-ttu-id="80a44-280">`Local Machine` を選択して、</span><span class="sxs-lookup"><span data-stu-id="80a44-280">Choose `Local Machine` and click</span></span> `Next`
0. <span data-ttu-id="80a44-281">ユーザー アカウント制御の管理者の昇格プロンプトが表示されたら同意して、</span><span class="sxs-lookup"><span data-stu-id="80a44-281">Accept the User Account Control admin elevation prompt, if it appears, and click</span></span> `Next`
0. <span data-ttu-id="80a44-282">秘密キーのパスワードがある場合には入力して、</span><span class="sxs-lookup"><span data-stu-id="80a44-282">Enter the password for the private key, if there is one, and click</span></span> `Next`
0. <span data-ttu-id="80a44-283">次を選択します: </span><span class="sxs-lookup"><span data-stu-id="80a44-283">Select</span></span> `Place all certificates in the following store`
0. <span data-ttu-id="80a44-284">`Browse` をクリックして、(「信頼された発行元」**ではなく**) `Trusted People` フォルダーを選択します</span><span class="sxs-lookup"><span data-stu-id="80a44-284">Click `Browse`, and choose the `Trusted People` folder (**not** "Trusted Publishers")</span></span>
0. <span data-ttu-id="80a44-285">`Next` をクリックして、次に </span><span class="sxs-lookup"><span data-stu-id="80a44-285">Click `Next` and then</span></span> `Finish`

<span data-ttu-id="80a44-286">`Trusted People` ストアに証明書を追加したら、もう一度パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="80a44-286">After adding the certificate to the `Trusted People` store, try installing the package again.</span></span>

<span data-ttu-id="80a44-287">これでアプリは、`.resw` / `.pri` ファイルの正しい情報を使って、スタート メニューの [すべてのアプリ] のリストに表示されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-287">You should now see your app appear in the Start Menu's "All Apps" list, with the correct information from the `.resw` / `.pri` file.</span></span> <span data-ttu-id="80a44-288">空の文字列または `ms-resource:...` の文字列が表示された場合には、何かが間違っています。編集を再度確認し、すべて正しいかどうか確認します。</span><span class="sxs-lookup"><span data-stu-id="80a44-288">If you see a blank string or the string `ms-resource:...` then something has gone wrong - double check your edits and make sure they're correct.</span></span> <span data-ttu-id="80a44-289">スタート メニューでアプリを右クリックすると、タイルとしてピン留めすることができ、さらに適切な情報が表示されることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-289">If you right-click on your app in the Start Menu, you can Pin it as a tile and verify the correct information is displayed there also.</span></span>

### <a name="step-13-add-more-supported-languages"></a><span data-ttu-id="80a44-290">手順 1.3: サポート言語を追加する</span><span class="sxs-lookup"><span data-stu-id="80a44-290">Step 1.3: Add more supported languages</span></span>

<span data-ttu-id="80a44-291">AppX マニフェストに変更が加えられ、初期の `resources.resw` ファイルが作成されたら、追加の言語を容易に追加できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-291">Once the changes have been made to the AppX manifest and the initial `resources.resw` file has been created, adding additional languages is easy.</span></span>

**<span data-ttu-id="80a44-292">追加のローカライズ リソースを作成する</span><span class="sxs-lookup"><span data-stu-id="80a44-292">Create additional localized resources</span></span>**

<span data-ttu-id="80a44-293">最初に、追加のローカライズ リソースの値を作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-293">First, create the additional localized resource values.</span></span> 

<span data-ttu-id="80a44-294">`Strings` フォルダーで、適切な BCP-47 コードを使って、サポートする各言語のための、追加のフォルダーを作成します (たとえば、`Strings\de-DE`)。</span><span class="sxs-lookup"><span data-stu-id="80a44-294">Within the `Strings` folder, create additional folders for each language you support using the appropriate BCP-47 code (for example, `Strings\de-DE`).</span></span> <span data-ttu-id="80a44-295">各フォルダー内に、(XML エディターまたは Visual Studio デザイナーを使用して) 翻訳されたリソースの値を含む `resources.resw` ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-295">Within each of these folders, create a `resources.resw` file (using either an XML editor or the Visual Studio designer) that includes the translated resource values.</span></span> <span data-ttu-id="80a44-296">ここでは、既にローカライズされた文字列が利用可能であり、それを `.resw` ファイルにコピーして利用できるものと想定します。このドキュメントでは、翻訳の手順そのものは扱いません。</span><span class="sxs-lookup"><span data-stu-id="80a44-296">It is assumed you already have the localized strings available somewhere, and you just need to copy them into the `.resw` file; this document does not cover the translation step itself.</span></span> 

<span data-ttu-id="80a44-297">たとえば、`Strings\de-DE\resources.resw`ファイルは、次のようになります。<span style="background-color: yellow">強調表示されたテキスト</span>は `en-US` から変更されました。</span><span class="sxs-lookup"><span data-stu-id="80a44-297">For example, the `Strings\de-DE\resources.resw` file might look like this, with the <span style="background-color: yellow">highlighted text</span> changed from `en-US`:</span></span>

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;root&gt;
  &lt;data name="ApplicationDescription"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo app with localized resources (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="ApplicationDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Sample (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PackageDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Package (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PublisherDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Samples, DE</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="TileShortName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso (DE)</span>&lt;/value&gt;
  &lt;/data&gt;
&lt;/root&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-298">次の手順では、`de-DE` と `fr-FR` の両方のリソースを追加したものと想定します。他の言語でも同じパターンで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-298">The following steps assume you added resources for both `de-DE` and `fr-FR`, but the same pattern can be followed for any language.</span></span>

**<span data-ttu-id="80a44-299">AppX マニフェストを更新してサポート言語をリストする</span><span class="sxs-lookup"><span data-stu-id="80a44-299">Update AppX manifest to list supported languages</span></span>**

<span data-ttu-id="80a44-300">AppX マニフェストを更新して、アプリがサポートする言語をリストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-300">The AppX manifest must be updated to list the languages supported by the app.</span></span> <span data-ttu-id="80a44-301">Desktop App Converter は、既定の言語を追加しますが、他の言語は明示的に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-301">The Desktop App Converter adds the default language, but the others must be added explicitly.</span></span> <span data-ttu-id="80a44-302">`AppxManifest.xml` ファイルを直接編集する場合、`Resources` ノードを次のように更新します。必要な要素を追加し、<span style="background-color: yellow">サポートする適切な言語</span>を置き換え、一覧の最初のエントリが既定の (フォールバック) 言語となるようにします。</span><span class="sxs-lookup"><span data-stu-id="80a44-302">If you're editing the `AppxManifest.xml` file directly, update the `Resources` node as follows, adding as many elements as you need, and substituting the <span style="background-color: yellow">appropriate languages you support</span> and making sure the first entry in the list is the default (fallback) language.</span></span> <span data-ttu-id="80a44-303">この例では、既定値は英語 (米国) で、ドイツ語 (ドイツ)、フランス語 (フランス) が追加でサポートされます。</span><span class="sxs-lookup"><span data-stu-id="80a44-303">In this example, the default is English (US) with additional support for both German (Germany) and French (France):</span></span>

<blockquote>
<pre>
&lt;Resources&gt;
  &lt;Resource Language="<span style="background-color: yellow">EN-US</span>" /&gt;
  &lt;Resource Language="<span style="background-color: yellow">DE-DE</span>" /&gt;
  &lt;Resource Language="<span style="background-color: yellow">FR-FR</span>" /&gt;
&lt;/Resources&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-304">Visual Studio を使っている場合、何もする必要はありません。`Package.appxmanifest` には、特別な <span style="background-color: yellow">x-generate</span> 値が含まれます。これによってビルド プロセスで、プロジェクトに含まれる (BCP-47 コードを使った名前のフォルダーに基づく) 言語が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-304">If you are using Visual Studio, you shouldn't need to do anything; if you look at `Package.appxmanifest` you should see the special <span style="background-color: yellow">x-generate</span> value, which causes the build process to insert the languages it finds in your project (based on the folders named with BCP-47 codes).</span></span> <span data-ttu-id="80a44-305">これは実際の Appx マニフェストでは有効な値ではないことに注意してください。これは Visual Studio プロジェクトでのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="80a44-305">Note that this is not a valid value for a real Appx Manifest; it only works for Visual Studio projects:</span></span>

<blockquote>
<pre>
&lt;Resources&gt;
  &lt;Resource Language="<span style="background-color: yellow">x-generate</span>" /&gt;
&lt;/Resources&gt;
</pre>
</blockquote>

**<span data-ttu-id="80a44-306">ローカライズされた値でリビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-306">Re-build with the localized values</span></span>**

<span data-ttu-id="80a44-307">ここで再度、アプリケーションのビルドを行ってデプロイすることができます。Windows で言語の選択を変更すると、新たにローカライズされた値がスタート メニューに表示されます (言語を変更する方法については、以下で説明します)。</span><span class="sxs-lookup"><span data-stu-id="80a44-307">Now you can build and deploy your application, again, and if you change your language preference in Windows you should see the newly-localized values appear in the Start menu (instructions for how to change your language are below).</span></span>

<span data-ttu-id="80a44-308">ここでも、Visual Studio では `Ctrl+Shift+B` を使ってビルドを行い、プロジェクトで右クリックして `Deploy` できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-308">For Visual Studio, again you can just use `Ctrl+Shift+B` to build, and right-click the project to `Deploy`.</span></span>

<span data-ttu-id="80a44-309">プロジェクトを手動でビルドする場合は、上記と同じ手順に従いますが、構成ファイルを作成する際に、既定の修飾子の一覧 (`/dq`) にアンダー スコアで区切られた追加の言語を追加します。</span><span class="sxs-lookup"><span data-stu-id="80a44-309">If you're manually building the project, follow the same steps as above but add the additional languages, separated by underscores, to the default qualifiers list (`/dq`) when creating the configuration file.</span></span> <span data-ttu-id="80a44-310">たとえば、前の手順で追加された、英語、ドイツ語、フランス語のリソースをサポートするには:</span><span class="sxs-lookup"><span data-stu-id="80a44-310">For example, to support the English, German, and French resources added in the previous step:</span></span>

```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_fr-FR /pv 10.0 /o
```

<span data-ttu-id="80a44-311">これにより、指定されたすべての言語を含む PRI ファイルが作成され、それをテスト用に簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-311">This will create a PRI file that contains all the specified languagesthat you can easily use for testing.</span></span> <span data-ttu-id="80a44-312">リソースの合計サイズが小さい場合、または少数の言語のみをサポートする場合は、配布するアプリとしてこれで十分である場合もあります。リソースのインストールとダウンロードのサイズを最小化するメリットを必要とする場合のみ、言語ごとの個別の言語パックをビルドする追加の作業を行います。</span><span class="sxs-lookup"><span data-stu-id="80a44-312">If the total size of your resources is small, or you only support a small number of languages, this might be acceptable for your shipping app; it's only if you want the benefits of minimizing install / download size for your resources that you need to do the additional work of building separate language packs.</span></span>

**<span data-ttu-id="80a44-313">ローカライズされた値をテストする</span><span class="sxs-lookup"><span data-stu-id="80a44-313">Test with the localized values</span></span>**

<span data-ttu-id="80a44-314">新しくローカライズされた変更をテストするには、使用する新しい UI 言語を Windows に追加します。</span><span class="sxs-lookup"><span data-stu-id="80a44-314">To test the new localized changes, you simply add a new preferred UI language to Windows.</span></span> <span data-ttu-id="80a44-315">言語パックをダウンロードしたり、システムを再起動したり、Windows UI 全体を他言語で表示させたりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="80a44-315">There is no need to download language packs, reboot the system, or have your entire Windows UI appear in a foreign language.</span></span> 

0. <span data-ttu-id="80a44-316">`Settings` アプリを実行します (`Windows + I`)</span><span class="sxs-lookup"><span data-stu-id="80a44-316">Run the `Settings` app (`Windows + I`)</span></span>
0. <span data-ttu-id="80a44-317">次の場所に移動します: </span><span class="sxs-lookup"><span data-stu-id="80a44-317">Go to</span></span> `Time & language`
0. <span data-ttu-id="80a44-318">次の場所に移動します: </span><span class="sxs-lookup"><span data-stu-id="80a44-318">Go to</span></span> `Region & language`
0. <span data-ttu-id="80a44-319">次をクリックします: </span><span class="sxs-lookup"><span data-stu-id="80a44-319">Click</span></span> `Add a language`
0. <span data-ttu-id="80a44-320">必要な言語を入力 (または選択) します (たとえば `Deutsch` または `German`)</span><span class="sxs-lookup"><span data-stu-id="80a44-320">Type (or select) the language you want (eg `Deutsch` or `German`)</span></span>
 * <span data-ttu-id="80a44-321">サブ言語がある場合は、必要なものを選びます (たとえば `Deutsch / Deutschland`)</span><span class="sxs-lookup"><span data-stu-id="80a44-321">If there are sub-languages, choose the one you want (eg, `Deutsch / Deutschland`)</span></span>
0. <span data-ttu-id="80a44-322">言語の一覧で新しい言語を選択します</span><span class="sxs-lookup"><span data-stu-id="80a44-322">Select the new language in the language list</span></span>
0. <span data-ttu-id="80a44-323">次をクリックします: </span><span class="sxs-lookup"><span data-stu-id="80a44-323">Click</span></span> `Set as default`

<span data-ttu-id="80a44-324">スタート メニューを開き、作成したアプリケーションを検索します。選択した言語のローカライズされた値が表示されます (他のアプリもローカライズされて表示される場合があります)。</span><span class="sxs-lookup"><span data-stu-id="80a44-324">Now open the Start menu and search for your application, and you should see the localized values for the selected language (other apps might also appear localized).</span></span> <span data-ttu-id="80a44-325">ローカライズされた名前がすぐに表示されない場合は、スタート メニューのキャッシュが更新されるまで、数分待機します。</span><span class="sxs-lookup"><span data-stu-id="80a44-325">If you don't see the localized name right away, wait a few minutes until the Start Menu's cache is refreshed.</span></span> <span data-ttu-id="80a44-326">元の言語に戻すには、言語の一覧で既定の言語を変更します。</span><span class="sxs-lookup"><span data-stu-id="80a44-326">To return to your native language, just make it the default language in the language list.</span></span> 

### <a name="step-14-localizing-more-parts-of-the-appx-manifest-optional"></a><span data-ttu-id="80a44-327">手順 1.4: AppX マニフェストの他の部分をローカライズする (省略可能)</span><span class="sxs-lookup"><span data-stu-id="80a44-327">Step 1.4: Localizing more parts of the AppX manifest (optional)</span></span>

<span data-ttu-id="80a44-328">AppX マニフェストの他のセクションをローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-328">Other sections of the AppX Manifest can be localized.</span></span> <span data-ttu-id="80a44-329">たとえば、アプリがファイル拡張子を処理する場合、マニフェストに `windows.fileTypeAssociation` 拡張があります。<span style="background-color: lightgreen">緑の強調表示のテキスト</span>を表示されているとおりに使い (これはリソースの参照です)、<span style="background-color: yellow">黄色の強調表示のテキスト</span>をアプリに固有の情報で置き換えます。</span><span class="sxs-lookup"><span data-stu-id="80a44-329">For example, if your application handles file-extensions then it should have a `windows.fileTypeAssociation` extension in the manifest, using the <span style="background-color: lightgreen">green highlighted text</span> exactly as shown (since it will refer to resources), and replacing the <span style="background-color: yellow">yellow highlighted text</span> with information specific to your application:</span></span>

<blockquote>
<pre>
&lt;Extensions&gt;
  &lt;uap:Extension Category="windows.fileTypeAssociation"&gt;
    &lt;uap:FileTypeAssociation Name="default"&gt;
      &lt;uap:DisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/FileTypeDisplayName</span>&lt;/uap:DisplayName&gt;
      &lt;uap:Logo&gt;<span style="background-color: yellow">Assets\StoreLogo.png</span>&lt;/uap:Logo&gt;
      &lt;uap:InfoTip&gt;<span style="background-color: lightgreen">ms-resource:Resources/FileTypeInfoTip</span>&lt;/uap:InfoTip&gt;
      &lt;uap:SupportedFileTypes&gt;
        &lt;uap:FileType ContentType="<span style="background-color: yellow">application/x-contoso</span>"&gt;<span style="background-color: yellow">.contoso</span>&lt;/uap:FileType&gt;
      &lt;/uap:SupportedFileTypes&gt;
    &lt;/uap:FileTypeAssociation&gt;
  &lt;/uap:Extension&gt;
&lt;/Extensions&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-330">Visual Studio のマニフェスト デザイナーを使って、この情報を追加することもできます。`Declarations` タブを使い、<span style="background-color: lightgreen">強調表示の値</span>を記録します。</span><span class="sxs-lookup"><span data-stu-id="80a44-330">You can also add this information using the Visual Studio Manifest Designer, using the `Declarations` tab, taking note of the <span style="background-color: lightgreen">highlighted values</span>:</span></span>

<p><img src="images\editing-declarations-info.png"/></p>

<span data-ttu-id="80a44-331">対応するリソース名を、各 `.resw` ファイルに追加し、<span style="background-color: yellow">強調表示のテキスト</span>をアプリに適切なテキストで置き換えます (*サポートされているそれぞれの言語*で行います)。</span><span class="sxs-lookup"><span data-stu-id="80a44-331">Now add the corresponding resource names to each of your `.resw` files, replacing the <span style="background-color: yellow">highlighted text</span> with the appropriate text for your app (remember to do this for *each supported language!*):</span></span>

<blockquote>
<pre>
... existing content...

&lt;data name="FileTypeDisplayName"&gt;
  &lt;value&gt;<span style="background-color: yellow">Contoso Demo File</span>&lt;/value&gt;
&lt;/data&gt;
&lt;data name="FileTypeInfoTip"&gt;
  &lt;value&gt;<span style="background-color: yellow">Files used by Contoso Demo App</span>&lt;/value&gt;
&lt;/data&gt;
</pre>
</blockquote>

<span data-ttu-id="80a44-332">これは、エクスプローラーなどの Windows シェルの一部で表示されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-332">This will then show up in parts of the Windows shell, such as File Explorer:</span></span>

<p><img src="images\file-type-tool-tip.png"/></p>

<span data-ttu-id="80a44-333">再び、ビルドを行い、パッケージをテストして、新しい UI 文字列が表示される新しいシナリオを試します。</span><span class="sxs-lookup"><span data-stu-id="80a44-333">Build and test the package as before, exercising any new scenarios that should show the new UI strings.</span></span>

- - -

## <a name="phase-2-use-mrt-to-identify-and-locate-resources"></a><span data-ttu-id="80a44-334">フェーズ 2: MRT を使用してリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="80a44-334">Phase 2: Use MRT to identify and locate resources</span></span>

<span data-ttu-id="80a44-335">前のセクションでは、MRT を使用してアプリのマニフェスト ファイルをローカライズする方法を紹介しました。これによって、Windows シェルに、アプリの名前とその他のメタデータを正しく表示できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="80a44-335">The previous section showed how to use MRT to localize your app's manifest file so that the Windows Shell can correctly display the app's name and other metadata.</span></span> <span data-ttu-id="80a44-336">これにはコードの変更は必要なく、`.resw` ファイルとその他のいくつかのツールのみを必要としました。</span><span class="sxs-lookup"><span data-stu-id="80a44-336">No code changes were required for this; it simply required the use of `.resw` files and some additional tools.</span></span> <span data-ttu-id="80a44-337">このセクションでは、MRT を使用して、既存のリソース形式のリソースを検索し、既存のリソース処理コードを最小限の変更で使用する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="80a44-337">This section will show how to use MRT to locate resources in your existing resource formats and using your existing resource-handling code with minimal changes.</span></span>

### <a name="assumptions-about-existing-file-layout--application-code"></a><span data-ttu-id="80a44-338">既存のファイル レイアウトとアプリケーションのコードについての想定</span><span class="sxs-lookup"><span data-stu-id="80a44-338">Assumptions about existing file layout & application code</span></span>

<span data-ttu-id="80a44-339">Win32 デスクトップ アプリをローカライズする方法は多数あるため、このホワイトペーパーでは、既存のアプリケーションの構造について、いつかの簡単な想定を置きます。この想定と実際のアプリの環境をマッピングしながら利用してください。</span><span class="sxs-lookup"><span data-stu-id="80a44-339">Because there are many ways to localize Win32 Desktop apps, this paper will make some simplifying assumptions about the existing application's structure that you will need to map to your specific environment.</span></span> <span data-ttu-id="80a44-340">MRT の要件に準拠するため、既存のコードベースやリソース レイアウトを変更する必要がある場合があります。それらの多くは、このドキュメントの対象範囲外となります。</span><span class="sxs-lookup"><span data-stu-id="80a44-340">You might need to make some changes to your existing codebase or resource layout to conform to the requirements of MRT, and those are largely out of scope for this document.</span></span>

**<span data-ttu-id="80a44-341">リソース ファイルのレイアウト</span><span class="sxs-lookup"><span data-stu-id="80a44-341">Resource file layout</span></span>**

<span data-ttu-id="80a44-342">このホワイト ペーパーでは、ローカライズされたリソースのすべてが同じファイル名を持ち (たとえば `contoso_demo.exe.mui`、`contoso_strings.dll`、`contoso.strings.xml`)、それらは BCP-47 名を持つ別のフォルダーに配置されている (`en-US`、`de-DE`など) と想定します。</span><span class="sxs-lookup"><span data-stu-id="80a44-342">This whitepaper assumes your localized resources all have the same filenames (eg, `contoso_demo.exe.mui` or `contoso_strings.dll` or `contoso.strings.xml`) but that they are placed in different folders with BCP-47 names (`en-US`, `de-DE`, etc.).</span></span> <span data-ttu-id="80a44-343">使用するリソース ファイルの数、名前、ファイル形式、関連付けられている API などは問題とはなりません。すべての*論理*リソースが同じファイル名である (そして異なる*物理*ディレクトリに配置されている) ことのみが問題となります。</span><span class="sxs-lookup"><span data-stu-id="80a44-343">It doesn't matter how many resource files you have, what their names are, what their file-formats / associated APIs are, etc. The only thing that matters is that every *logical* resource has the same filename (but placed in a different *physical* directory).</span></span> 

<span data-ttu-id="80a44-344">反対の例として、アプリケーションがフラットなファイル構造を使用していて、1 つの `Resources` ディレクトリに、`english_strings.dll` と `french_strings.dll` が含まれている場合には、これは MRT にうまくマッピングされません。</span><span class="sxs-lookup"><span data-stu-id="80a44-344">As a counter-example, if your application uses a flat file-structure with a single `Resources` directory containing the files `english_strings.dll` and `french_strings.dll`, it would not map well to MRT.</span></span> <span data-ttu-id="80a44-345">望ましい構造は、`Resources` ディレクトリにサブディレクトリがあり、そこにファイルが配置されている (たとえば `en\strings.dll` や `fr\strings.dll`) 構造です。</span><span class="sxs-lookup"><span data-stu-id="80a44-345">A better structure would be a `Resources` directory with subdirectories and files `en\strings.dll` and `fr\strings.dll`.</span></span> <span data-ttu-id="80a44-346">`strings.lang-en.dll` や `strings.lang-fr.dll` などのように、同じ基本ファイル名を使用して、修飾子を埋め込むことも可能ですが、言語コードと同じディレクトリの使用がコンセプトとしてシンプルであり、ここではそれを使います。</span><span class="sxs-lookup"><span data-stu-id="80a44-346">It's also possible to use the same base filename but with embedded qualifiers, such as `strings.lang-en.dll` and `strings.lang-fr.dll`, but using directories with the language codes is conceptually simpler so it's what we'll focus on.</span></span>

<span data-ttu-id="80a44-347">**注** この名前付け規則に従わない場合でも、MRT を使って AppX パッケージのメリットを活用することは可能ですが、より多くの作業が必要となります。</span><span class="sxs-lookup"><span data-stu-id="80a44-347">**Note** It is still possible to use MRT and the benefits of AppX packaging even if you can't follow this filenaming convention; it just requires more work.</span></span>

<span data-ttu-id="80a44-348">たとえば、アプリケーションが、<span style="background-color: yellow">ui.txt</span> という名前の単純なテキスト ファイルに含まれる、(ボタンのラベルなどに使用される) カスタムの UI コマンドのセットを持ち、<span style="background-color: yellow">UICommands</span> フォルダーの下に配置される場合があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-348">For example, the application might have a set of custom UI commands (used for button labels etc.) in a simple text file named <span style="background-color: yellow">ui.txt</span>, laid out under a <span style="background-color: yellow">UICommands</span> folder:</span></span>

<blockquote>
<pre>
+ ProjectRoot
|--+ Strings
|  |--+ en-US
|  |  \--- resources.resw
|  \--+ de-DE
|     \--- resources.resw
|--+ <span style="background-color: yellow">UICommands</span>
|  |--+ en-US
|  |  \--- <span style="background-color: yellow">ui.txt</span>
|  \--+ de-DE
|     \--- <span style="background-color: yellow">ui.txt</span>
|--- AppxManifest.xml
|--- ...rest of project...
</pre>
</blockquote>

**<span data-ttu-id="80a44-349">リソースの読み込みコード</span><span class="sxs-lookup"><span data-stu-id="80a44-349">Resource loading code</span></span>**

<span data-ttu-id="80a44-350">このホワイトペーパーでは、コードの中のいずれかの時点で、ローカライズ リソースを含むファイルを検索し、読み込み、使用すると想定しています。</span><span class="sxs-lookup"><span data-stu-id="80a44-350">This whitepaper assumes that at some point in your code you want to locate the file that contains a localized resource, load it, and then use it.</span></span> <span data-ttu-id="80a44-351">リソースを読み込むために使用する API や、リソースを抽出するために使用する API などは重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="80a44-351">The APIs used to load the resources, the APIs used to extract the resources, etc. are not important.</span></span> <span data-ttu-id="80a44-352">この疑似コードでは、基本的に 3 つの手順があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-352">In pseudocode, there are basically three steps:</span></span>

```
set userLanguage = GetUsersPreferredLanguage()
set resourceFile = FindResourceFileForLanguage(MY_RESOURCE_NAME, userLanguage)
set resource = LoadResource(resourceFile) 
    
// now use 'resource' however you want
```

<span data-ttu-id="80a44-353">MRT では、このプロセスの最初の 2 つの手順のみを変更する必要があります。つまり、必要なリソース候補の決定と、その検索です。</span><span class="sxs-lookup"><span data-stu-id="80a44-353">MRT only requires changing the first two steps in this process - how you determine the best candidate resources and how you locate them.</span></span> <span data-ttu-id="80a44-354">リソースの読み込みと使用については、変更する必要はありません (ただし、それらを活用する場合は、それを行える機能を提供しています)。</span><span class="sxs-lookup"><span data-stu-id="80a44-354">It doesn't require you to change how you load or use the resources (although it provides facilities for doing that if you want to take advantage of them).</span></span>
 
<span data-ttu-id="80a44-355">たとえば、アプリケーションは、Win32 API `GetUserPreferredUILanguages`、CRT 関数 `sprintf`、Win32 API `CreateFile` を使用して、上記の 3 つの疑似コードの関数を置き換え、次にテキスト ファイルを手動で解析して、`name=value` のペアを検索できます。</span><span class="sxs-lookup"><span data-stu-id="80a44-355">For example, the application might use the Win32 API `GetUserPreferredUILanguages`, the CRT function `sprintf`, and the Win32 API `CreateFile` to replace the three pseudocode functions above, then manually parse the text file looking for `name=value` pairs.</span></span> <span data-ttu-id="80a44-356">(この詳細は重要ではありません。MRT は、リソースが検索された後の、リソースの処理に使用する手法には影響がないことを示すために説明しました)。</span><span class="sxs-lookup"><span data-stu-id="80a44-356">(The details are not important; this is merely to illustrate that MRT has no impact on the techniques used to handle resources once they have been located).</span></span>

### <a name="step-21-code-changes-to-use-mrt-to-locate-files"></a><span data-ttu-id="80a44-357">手順 2.1: MRT を使ってファイルを検索するためのコードの変更</span><span class="sxs-lookup"><span data-stu-id="80a44-357">Step 2.1: Code changes to use MRT to locate files</span></span>

<span data-ttu-id="80a44-358">リソースの検索に MRT を使用するため、コードを切り替えることは難しくはありません。</span><span class="sxs-lookup"><span data-stu-id="80a44-358">Switching your code to use MRT for locating resources is not difficult.</span></span> <span data-ttu-id="80a44-359">いくつかの WinRT の種類と数行のコードを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-359">It requires using a handful of WinRT types and a few lines of code.</span></span> <span data-ttu-id="80a44-360">主に使用される種類は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="80a44-360">The main types that you will use are as follows:</span></span>

* <span data-ttu-id="80a44-361">[ResourceContext](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext) 現在アクティブな修飾子の値のセット (言語、スケール ファクターなど) をカプセル化します</span><span class="sxs-lookup"><span data-stu-id="80a44-361">[ResourceContext](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext), which encapsulates the currently active set of qualifier values (language, scale factor, etc.)</span></span>
* <span data-ttu-id="80a44-362">[ResourceManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemanager) (.NETバージョンではなく、WinRT バージョン) PRI ファイルからすべてのリソースへのアクセスを実現します</span><span class="sxs-lookup"><span data-stu-id="80a44-362">[ResourceManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemanager) (the WinRT version, not the .NET version), which enables access to all the resources from the PRI file</span></span>
* <span data-ttu-id="80a44-363">[ResourceMap](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemap) PRI ファイル内のリソースの特定のサブセット (この例では、文字列リソースではなく、ファイル ベースのリソース) を表します</span><span class="sxs-lookup"><span data-stu-id="80a44-363">[ResourceMap](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemap), which represents a specific subset of the resources in the PRI file (in this example, the file-based resources vs. the string resources)</span></span>
* <span data-ttu-id="80a44-364">[NamedResource](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource) 論理リソースとそのすべての候補を表します</span><span class="sxs-lookup"><span data-stu-id="80a44-364">[NamedResource](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource), which represents a logical resource and all its possible candidates</span></span>
* <span data-ttu-id="80a44-365">[ResourceCandidate](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcecandidate) 1 つの具体的な候補リソースを表す</span><span class="sxs-lookup"><span data-stu-id="80a44-365">[ResourceCandidate](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcecandidate), which represents a single concrete candidate resource</span></span> 

<span data-ttu-id="80a44-366">あるリソースのファイル名 (たとえば、上のサンプルの `UICommands\ui.txt` など) を解決する方法は、疑似コードでは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="80a44-366">In pseudo-code, the way you would resolve a given resource file name (like `UICommands\ui.txt` in the sample above) is as follows:</span></span>

```
// Get the ResourceContext that applies to this app
set resourceContext = ResourceContext.GetForViewIndependentUse()
    
// Get the current ResourceManager (there's one per app)
set resourceManager = ResourceManager.Current
    
// Get the "Files" ResourceMap from the ResourceManager
set fileResources = resourceManager.MainResourceMap.GetSubtree("Files")
    
// Find the NamedResource with the logical filename we're looking for,
// by indexing into the ResourceMap
set desiredResource = fileResources["UICommands\ui.txt"]
    
// Get the ResourceCandidate that best matches our ResourceContext
set bestCandidate = desiredResource.Resolve(resourceContext)
   
// Get the string value (the filename) from the ResourceCandidate
set absoluteFileName = bestCandidate.ValueAsString
```

<span data-ttu-id="80a44-367">このコードでは、(実際のディスク上のファイルの配置にかかわらず) 特定の言語のフォルダー (`UICommands\en-US\ui.txt` など) を要求して**いない**ことに、特に注意してください。</span><span class="sxs-lookup"><span data-stu-id="80a44-367">Note in particular that the code does **not** request a specific language folder - like `UICommands\en-US\ui.txt` - even though that is how the files exist on-disk.</span></span> <span data-ttu-id="80a44-368">代わりに*論理*ファイル名 `UICommands\ui.txt` を要求して、ディスク上の言語ディレクトリからの適切なファイルの選択を MRT に依存しています。</span><span class="sxs-lookup"><span data-stu-id="80a44-368">Instead, it asks for the *logical* filename `UICommands\ui.txt` and relies on MRT to find the appropriate on-disk file in one of the language directories.</span></span>

<span data-ttu-id="80a44-369">これ以降、サンプル アプリは以前と同様に、`CreateFile` を使って `absoluteFileName` を読み込み、`name=value` ペアを解析できます。アプリ内のロジックの変更はまったく必要ありません。</span><span class="sxs-lookup"><span data-stu-id="80a44-369">From here, the sample app could continue to use `CreateFile` to load the `absoluteFileName` and parse the `name=value` pairs just as before; none of that logic needs to change in the app.</span></span> <span data-ttu-id="80a44-370">C# または C++/CX で記述している場合、実際のコードは、この擬似コード以上にそれほど複雑になることはありません (さらに多くの中間変数は省略できます)。下記の **.NET リソースを読み込む**のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-370">If you are writing in C# or C++/CX, the actual code is not much more complicated than this (and in fact many of the intermediate variables can be elided) - see the section on **Loading .NET resources**, below.</span></span> <span data-ttu-id="80a44-371">C++/WRL ベースのアプリケーションでは、WinRT API のアクティブ化と呼び出しに使用される低レベルの COM ベースの API によってより複雑になりますが、基本的な手順は同じです。下記の **Win32 MUI リソースを読み込む**のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-371">C++/WRL-based applications will be more complex due to the low-level COM-based APIs used to activate and call the WinRT APIs, but the fundamental steps you take are the same - see the section on **Loading Win32 MUI resources**, below.</span></span>

**<span data-ttu-id="80a44-372">.NET リソースを読み込む</span><span class="sxs-lookup"><span data-stu-id="80a44-372">Loading .NET resources</span></span>**

<span data-ttu-id="80a44-373">.NET には、リソースを検索して読み込むための組み込みのメカニズム (「サテライト アセンブリ」と呼ばれます) があるため、上記の合成の例のように、明示的なコードの置き換えは必要ありません。.NET では、適切なディレクトリにリソース DLL が存在することのみが必要であり、それらは自動的に検索されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-373">Because .NET has a built-in mechanism for locating and loading resources (known as "Satellite Assemblies"), there is no explicit code to replace as in the synthetic example above - in .NET you just need your resource DLLs in the appropriate directories and they are automatically located for you.</span></span> <span data-ttu-id="80a44-374">リソース パッケージを使ってアプリが AppX としてパッケージ化された場合は、ディレクトリ構造はいくらか異なります。リソース ディレクトリは、メイン アプリケーション ディレクトリのサブディレクトリとして存在するのではなく、ピアとして存在します (または、ユーザーが使用する言語を指定していない場合には、まったく存在しません)。</span><span class="sxs-lookup"><span data-stu-id="80a44-374">When an app is packaged as an AppX using resource packs, the directory structure is somewhat different - rather than having the resource directories be subdirectories of the main application directory, they are peers of it (or not present at all if the user doesn't have the language listed in their preferences).</span></span> 

<span data-ttu-id="80a44-375">たとえば、次のレイアウトを持つ .NET アプリケーションを考えます。ここでは、すべてのファイルが `MainApp` フォルダーの下に存在しています。</span><span class="sxs-lookup"><span data-stu-id="80a44-375">For example, imagine a .NET application with the following layout, where all the files exist under the `MainApp` folder:</span></span>

<blockquote>
<pre>
+ MainApp
|--+ en-us
|  \--- MainApp.resources.dll
|--+ de-de
|  \--- MainApp.resources.dll
|--+ fr-fr
|  \--- MainApp.resources.dll
\--- MainApp.exe
</pre>
</blockquote>

<span data-ttu-id="80a44-376">AppX への変換後、レイアウトはこのようになります。ここでは、`en-US` が既定の言語で、言語リストにドイツ語とフランス語が記載されています。</span><span class="sxs-lookup"><span data-stu-id="80a44-376">After conversion to AppX, the layout will look something like this, assuming `en-US` was the default language and the user has both German and French listed in their language list:</span></span>

<blockquote>
<pre>
+ WindowsAppsRoot
|--+ MainApp_neutral
|  |--+ en-us
|  |  \--- <span style="background-color: yellow">MainApp.resources.dll</span>
|  \--- MainApp.exe
|--+ MainApp_neutral_resources.language_de
|  \--+ de-de
|     \--- <span style="background-color: yellow">MainApp.resources.dll</span>
\--+ MainApp_neutral_resources.language_fr
   \--+ fr-fr
      \--- <span style="background-color: yellow">MainApp.resources.dll</span>
</pre>
</blockquote>

<span data-ttu-id="80a44-377">ローカライズ リソースが、メイン実行可能ファイルのインストール場所の下のサブディレクトリに存在しないため、組み込みの .NET リソースの解決が失敗します。</span><span class="sxs-lookup"><span data-stu-id="80a44-377">Because the localized resources no longer exist in sub-directories underneath the main executable's install location, the built-in .NET resource resolution fails.</span></span> <span data-ttu-id="80a44-378">さいわい、.NET は、失敗したアセンブリの読み込みの試行を処理するための、明確に定義されたメカニズムである、`AssemblyResolve` イベントを備えています。</span><span class="sxs-lookup"><span data-stu-id="80a44-378">Luckily, .NET has a well-defined mechanism for handling failed assembly load attempts - the `AssemblyResolve` event.</span></span> <span data-ttu-id="80a44-379">MRT を使用する .NET アプリは、このイベントに登録して、見つからなかったアセンブリを .NET リソース サブシステムに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-379">A .NET app using MRT must register for this event and provide the missing assembly for the .NET resource subsystem.</span></span> 

<span data-ttu-id="80a44-380">WinRT API を使用して、.NET で使われるサテライト アセンブリを検索する方法の簡単な例は次のとおりです。このコードは、最小限の実装を示すように、意図的に圧縮されていますが、上記の疑似コードによく対応しています。ここでは、渡されている `ResolveEventArgs` が検索する必要があるアセンブリの名前を提供します。</span><span class="sxs-lookup"><span data-stu-id="80a44-380">A concise example of how to use the WinRT APIs to locate satellite assemblies used by .NET is as follows; the code as-presented is intentionally compressed to show a minimal implementation, although you can see it maps closely to the pseudo-code above, with the passed-in `ResolveEventArgs` providing the name of the assembly we need to locate.</span></span> <span data-ttu-id="80a44-381">このコードの実行可能なバージョン (詳細なコメントとエラー処理を含む) は、[GitHub の **.NET アセンブリ リゾルバー** サンプル](https://aka.ms/fvgqt4) の `PriResourceRsolver.cs` にあります。</span><span class="sxs-lookup"><span data-stu-id="80a44-381">A runnable version of this code (with detailed comments and error-handling) can be found in the file `PriResourceRsolver.cs` in [the **.NET Assembly Resolver** sample on GitHub](https://aka.ms/fvgqt4).</span></span>

```C#
static class PriResourceResolver
{
  internal static Assembly ResolveResourceDll(object sender, ResolveEventArgs args)
  {
    var fullAssemblyName = new AssemblyName(args.Name);
    var fileName = string.Format(@"{0}.dll", fullAssemblyName.Name);

    var resourceContext = ResourceContext.GetForViewIndependentUse();
    resourceContext.Languages = new[] { fullAssemblyName.CultureName };

    var resource = ResourceManager.Current.MainResourceMap.GetSubtree("Files")[fileName];

    // Note use of 'UnsafeLoadFrom' - this is required for apps installed with AppX, but
    // in general is discouraged. The full sample provides a safer wrapper of this method
    return Assembly.UnsafeLoadFrom(resource.Resolve(resourceContext).ValueAsString);
  }
}
```

<span data-ttu-id="80a44-382">上記のクラスでは、次のコードを事前にアプリケーションのスタートアップ コードのどこかに (いずれかのローカライズ リソースを読み込む前に) 追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-382">Given the class above, you would add the following somewhere early-on in your application's startup code (before any localized resources would need to load):</span></span>

```C#
void EnableMrtResourceLookup()
{
  AppDomain.CurrentDomain.AssemblyResolve += PriResourceResolver.ResolveResourceDll;
}
```

<span data-ttu-id="80a44-383">.NET ランタイムは、リソース DLL が見つからない場合には、`AssemblyResolve` イベントを発生させます。その場合、提供されたイベント ハンドラーは、MRT を使って必要なファイルを検索し、アセンブリを返します。</span><span class="sxs-lookup"><span data-stu-id="80a44-383">The .NET runtime will raise the `AssemblyResolve` event whenever it can't find the resource DLLs, at which point the provided event handler will locate the desired file via MRT and return the assembly.</span></span>

<span data-ttu-id="80a44-384">**注** アプリが既に `AssemblyResolve` ハンドラーを他の目的で使用している場合、リソース解決のコードを、既存のコードと統合する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-384">**Note** If your app already has an `AssemblyResolve` handler for other purposes, you will need to integrate the resource-resolving code with your existing code.</span></span>

**<span data-ttu-id="80a44-385">Win32 MUI リソースを読み込む</span><span class="sxs-lookup"><span data-stu-id="80a44-385">Loading Win32 MUI resources</span></span>**

<span data-ttu-id="80a44-386">Win32 MUI リソースの読み込みは、.NET サテライト アセンブリの読み込みと基本的には同じですが、C++/CX または C++/WRL コードを使います。</span><span class="sxs-lookup"><span data-stu-id="80a44-386">Loading Win32 MUI resources is essentially the same as loading .NET Satellite Assemblies, but using either C++/CX or C++/WRL code instead.</span></span> <span data-ttu-id="80a44-387">C++/CX を使うと、コードがよりシンプルになり、上記の C# にとても近くなりますが、C++ 言語拡張、コンパイラ スイッチ、その他のランタイム オーバーヘッドを使うため、これはあまり望ましくない場合があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-387">Using C++/CX allows for much simpler code that closely matches the C# code above, but it uses C++ language extensions, compiler switches, and additional runtime overheard you might wish to avoid.</span></span> <span data-ttu-id="80a44-388">その場合は、C++/WRL を使うと、コードは冗長になりますが、影響のより小さいソリューションとなります。</span><span class="sxs-lookup"><span data-stu-id="80a44-388">If that is the case, using C++/WRL provides a much lower-impact solution at the cost of more verbose code.</span></span> <span data-ttu-id="80a44-389">それでも、ATL プログラミング (または COM 一般) に慣れている場合には、WRL がなじみやすい選択となります。</span><span class="sxs-lookup"><span data-stu-id="80a44-389">Nevertheless, if you are familiar with ATL programming (or COM in general) then WRL should feel familiar.</span></span> 

<span data-ttu-id="80a44-390">次のサンプル関数は、C++/WRL を使って、特定のリソース DLL を読み込み、`HINSTANCE` を返します。これにより、通常の Win32 リソース API を使って、さらにリソースを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-390">The following sample function shows how to use C++/WRL to load a specific resource DLL and return an `HINSTANCE` that can be used to load further resources using the usual Win32 resource APIs.</span></span> <span data-ttu-id="80a44-391">.NET ランタイムに要求された言語を使って明示的に `ResourceContext` を初期化する C# のサンプルとは異なり、このコードはユーザーの現在の言語に依存しています。</span><span class="sxs-lookup"><span data-stu-id="80a44-391">Note that unlike the C# sample that explicitly initializes the `ResourceContext` with the language requested by the .NET runtime, this code relies on the user's current language.</span></span>

```CPP
#include <roapi.h>
#include <wrl\client.h>
#include <wrl\wrappers\corewrappers.h>
#include <Windows.ApplicationModel.resources.core.h>
#include <Windows.Foundation.h>
   
#define IF_FAIL_RETURN(hr) if (FAILED((hr))) return hr;
    
HRESULT GetMrtResourceHandle(LPCWSTR resourceFilePath,  HINSTANCE* resourceHandle)
{
  using namespace Microsoft::WRL;
  using namespace Microsoft::WRL::Wrappers;
  using namespace ABI::Windows::ApplicationModel::Resources::Core;
  using namespace ABI::Windows::Foundation;
    
  *resourceHandle = nullptr;
  HRESULT hr{ S_OK };
  RoInitializeWrapper roInit{ RO_INIT_SINGLETHREADED };
  IF_FAIL_RETURN(roInit);
    
  // Get Windows.ApplicationModel.Resources.Core.ResourceManager statics
  ComPtr<IResourceManagerStatics> resourceManagerStatics;
  IF_FAIL_RETURN(GetActivationFactory(
    HStringReference(
    RuntimeClass_Windows_ApplicationModel_Resources_Core_ResourceManager).Get(),
    &resourceManagerStatics));
    
  // Get .Current property
  ComPtr<IResourceManager> resourceManager;
  IF_FAIL_RETURN(resourceManagerStatics->get_Current(&resourceManager));
    
  // get .MainResourceMap property
  ComPtr<IResourceMap> resourceMap;
  IF_FAIL_RETURN(resourceManager->get_MainResourceMap(&resourceMap));
    
  // Call .GetValue with supplied filename
  ComPtr<IResourceCandidate> resourceCandidate;
  IF_FAIL_RETURN(resourceMap->GetValue(HStringReference(resourceFilePath).Get(),
    &resourceCandidate));
    
  // Get .ValueAsString property
  HString resolvedResourceFilePath;
  IF_FAIL_RETURN(resourceCandidate->get_ValueAsString(
    resolvedResourceFilePath.GetAddressOf()));
    
  // Finally, load the DLL and return the hInst.
  *resourceHandle = LoadLibraryEx(resolvedResourceFilePath.GetRawBuffer(nullptr),
    nullptr, LOAD_LIBRARY_AS_DATAFILE | LOAD_LIBRARY_AS_IMAGE_RESOURCE);
    
  return S_OK;
}
```

## <a name="phase-3-building-resource-packs"></a><span data-ttu-id="80a44-392">フェーズ 3: リソース パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="80a44-392">Phase 3: Building resource packs</span></span>

<span data-ttu-id="80a44-393">これで、すべてのリソースを含む "ファット" パッケージができました。ダウンロードとインストールのサイズを最小化するために、メイン パッケージとリソース パッケージを分離してビルドするには、2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-393">Now that you have a "fat pack" that contains all resources, there are two paths towards building separate main package and resource packages in order to minimize download and install sizes:</span></span>

0. <span data-ttu-id="80a44-394">既存のファット パッケージを使い、[Bundle Generator ツール](https://aka.ms/bundlegen)を実行して、自動的にリソース パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-394">Take an existing fat pack and run it through [the Bundle Generator tool](https://aka.ms/bundlegen) to automatically create resource packs.</span></span> <span data-ttu-id="80a44-395">これは、既にファット パッケージを作成するビルド システムがあり、ポスト プロセスとしてリソース パッケージを生成する場合に、推奨されるアプローチです。</span><span class="sxs-lookup"><span data-stu-id="80a44-395">This is the preferred approach if you have a build system that already produces a fat pack and you want to post-process it to generate the resource packs.</span></span>
0. <span data-ttu-id="80a44-396">直接、個々のリソース パッケージを作成し、それらをビルドしてバンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-396">Directly produce the individual resource packages and build them into a bundle.</span></span> <span data-ttu-id="80a44-397">これは、ビルド システムをより細かく制御して、パッケージを直接作成する場合に、推奨されるアプローチです。</span><span class="sxs-lookup"><span data-stu-id="80a44-397">This is the preferred approach if you have more control over your build system and can build the packages directly.</span></span>

### <a name="step-31-creating-the-bundle"></a><span data-ttu-id="80a44-398">手順 3.1: バンドルを作成する</span><span class="sxs-lookup"><span data-stu-id="80a44-398">Step 3.1: Creating the bundle</span></span>

**<span data-ttu-id="80a44-399">Bundle Generator ツールを使用する</span><span class="sxs-lookup"><span data-stu-id="80a44-399">Using the Bundle Generator tool</span></span>**

<span data-ttu-id="80a44-400">Bundle Generator ツールを使用するには、パッケージ用に作成した PRI 構成ファイルを手動で更新して、`<packaging>` セクションを削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-400">In order to use the Bundle Generator tool, the PRI config file created for the package needs to be manually updated to remove the `<packaging>` section.</span></span>

<span data-ttu-id="80a44-401">Visual Studio を使っている場合には、`priconfig.packaging.xml` ファイルと `priconfig.default.xml` ファイルを作成して、すべての言語をメイン パッケージにビルドする方法について詳しくは、[MSDN の **Windows 8.1 ストア アプリ: デバイスにリソースが必要かどうかにかかわらず、必ずリソースをデバイスにインストールする**のトピック](https://msdn.microsoft.com/en-us/library/dn482043.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="80a44-401">If you're using Visual Studio, refer to [the **Ensure that resources are installed...** topic on MSDN](https://msdn.microsoft.com/en-us/library/dn482043.aspx) for information on how to build all languages into the main package by creating the files `priconfig.packaging.xml` and `priconfig.default.xml`.</span></span>

<span data-ttu-id="80a44-402">ファイルを手動で編集する場合は、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="80a44-402">If you're manually editing files, follow these steps:</span></span> 

0. <span data-ttu-id="80a44-403">正しいパス、ファイル名、言語を置き換えて、以前と同じ方法で構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-403">Create the config file the same way as before, substituting the correct path, file name and languages:</span></span>

    `makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_es-MX /pv 10.0 /o`
0. <span data-ttu-id="80a44-404">作成された `.xml` ファイルを手動で開き、`&lt;packaging&rt;` セクション全体を削除します (それ以外はそのまま残します)。</span><span class="sxs-lookup"><span data-stu-id="80a44-404">Manually open the created `.xml` file and delete the entire `&lt;packaging&rt;` section (but keep everything else intact):</span></span>

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="UTF-8" standalone="yes" ?&gt; 
&lt;resources targetOsVersion="10.0.0" majorVersion="1"&gt;
  &lt;!-- Packaging section has been deleted... --&gt;
  &lt;index root="\" startIndexAt="\"&gt;
    &lt;default&gt;
    ...
    ...
</pre>
</blockquote>

0. <span data-ttu-id="80a44-405">更新された構成ファイルと適切なディレクトリとファイル名を使って、以前と同じ方法で `.pri` ファイルと `.appx` パッケージをビルドします (これらのコマンドについて詳しくは上記をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-405">Build the `.pri` file and the `.appx` package as before, using the updated configuration file and the appropriate directory and file names (see above for more information on these commands):</span></span>

```CMD
makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o
makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o
```

0. <span data-ttu-id="80a44-406">パッケージが作成されたら、適切なディレクトリとファイル名を使用して、次のコマンドを使用してバンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-406">Once the package has been created, use the following command to create the bundle, using the appropriate directory and file names:</span></span>

    `BundleGenerator.exe -Package ..\contoso_demo.appx -Destination ..\bundle -BundleName contoso_demo`

<span data-ttu-id="80a44-407">これで、最後の手順に進むことができます。最後の手順は署名です (下をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="80a44-407">Now you can move to the final step, which is Signing (see below).</span></span>

**<span data-ttu-id="80a44-408">手動でリソース パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="80a44-408">Manually creating resource packages</span></span>**

<span data-ttu-id="80a44-409">リソース パッケージを手動で作成する場合は、やや異なるコマンドのセットを実行して、別の `.pri` ファイルと `.appx` ファイルをビルドする必要があります。これらはすべて、上でファット パッケージの作成に使用したコマンドに似ていますので、簡単な説明にとどめます。</span><span class="sxs-lookup"><span data-stu-id="80a44-409">Manually creating resource packages requires running a slightly different set of commands to build separate `.pri` and `.appx` files - these are all similar to the commands used above to create fat packages, so minimal explanation is given.</span></span> <span data-ttu-id="80a44-410">注: すべてのコマンドでは、現在のディレクトリは `AppXManifest.xml` ファイルを含むディレクトリであると想定していますが、すべてのファイルは親ディレクトリに配置されます (必要な場合は、別のディレクトリを使用できますが、プロジェクト ディレクトリはクリーンに保ち、これらのファイルを配置しないようにします)。</span><span class="sxs-lookup"><span data-stu-id="80a44-410">Note: All the commands assume that the current directory is the directory containing the `AppXManifest.xml` file, but all files are placed into the parent directory (you can use a different directory, if necessary, but you shouldn't pollute the project directory with any of these files).</span></span> <span data-ttu-id="80a44-411">いつもと同様に、"Contoso" のファイル名を独自のファイル名で置き換えます。</span><span class="sxs-lookup"><span data-stu-id="80a44-411">As always, replace the "Contoso" filenames with your own file names.</span></span>

0. <span data-ttu-id="80a44-412">次のコマンドを使用して、既定の言語**のみ**を既定の修飾子として命名する、構成ファイルを作成します。この場合では `en-US` です。</span><span class="sxs-lookup"><span data-stu-id="80a44-412">Use the following command to create a config file that names **only** the default language as the default qualifier - in this case, `en-US`:</span></span>

    `makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o`
0. <span data-ttu-id="80a44-413">次のコマンドを使って、メイン パッケージの既定の `.pri` ファイルと`.map.txt` ファイルを作成し、さらにプロジェクトの各言語の追加のファイルのセットを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-413">Create a default `.pri` and `.map.txt` file for the main package, plus an additional set of files for each language found in your project, with the following command:</span></span>

    `makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o`
0. <span data-ttu-id="80a44-414">次のコマンドを使って、メイン パッケージを作成します (これには実行可能コードと既定の言語リソースが含まれています)。</span><span class="sxs-lookup"><span data-stu-id="80a44-414">Use the following command to create the main package (which contains the executable code and default language resources).</span></span> <span data-ttu-id="80a44-415">いつもと同様に、必要に応じて名前を変更します。後でバンドルの作成が容易になるように、パッケージは別のディレクトリに配置する必要があります (この例では、`..\bundle` ディレクトリを使います)。</span><span class="sxs-lookup"><span data-stu-id="80a44-415">As always, change the name as you see fit, although you should put the package in a separate directory to make creating the bundle easier later (this example uses the `..\bundle` directory):</span></span>

    `makeappx pack /m .\AppXManifest.xml /f ..\resources.map.txt /p ..\bundle\contoso_demo.main.appx /o`
0. <span data-ttu-id="80a44-416">メイン パッケージが作成されたら、次のコマンドを追加言語ごとに 1 回ずつ使います (つまり、前の手順で生成された各言語マップ ファイルに、このコマンドを繰り返します)。</span><span class="sxs-lookup"><span data-stu-id="80a44-416">After the main package has been created, use the following command once for each additional language (ie, repeat this command for each language map file generated in the previous step).</span></span> <span data-ttu-id="80a44-417">ここでも、出力は別のディレクトリ (メイン パッケージと同じディレクトリ) にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="80a44-417">Again, the output should be in a separate directory (the same one as the main package).</span></span> <span data-ttu-id="80a44-418">言語が `/f` オプションと `/p` オプションの **両方** で指定されていることに注意してください。また、新しい `/r` 引数の使い方 (リソース パッケージが必要であることを指定します) に注意してください。</span><span class="sxs-lookup"><span data-stu-id="80a44-418">Note the language is specified **both** in the `/f` option and the `/p` option, and the use of the new `/r` argument (which indicates a Resource Package is desired):</span></span>

    `makeappx pack /r /m .\AppXManifest.xml /f ..\resources.language-de.map.txt /p ..\bundle\contoso_demo.de.appx /o`
0. <span data-ttu-id="80a44-419">バンドル ディレクトリからのすべてのパッケージをまとめて、1 つの `.appxbundle` ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="80a44-419">Combine all the packages from the bundle directory into a single `.appxbundle` file.</span></span> <span data-ttu-id="80a44-420">新しい `/d` オプションは、バンドル内のすべてのファイルが使用するディレクトリを指定します (前の手順で `.appx` ファイルを別のディレクトリに配置したのはこのためです)。</span><span class="sxs-lookup"><span data-stu-id="80a44-420">The new `/d` option specifies the directory to use for all the files in the bundle (this is why the `.appx` files are put into a separate directory in the previous step):</span></span>

    `makeappx bundle /d ..\bundle /p ..\contoso_demo.appxbundle /o`

<span data-ttu-id="80a44-421">パッケージのビルドの最後の手順は、署名です。</span><span class="sxs-lookup"><span data-stu-id="80a44-421">The final step to building the package is Signing.</span></span>

### <a name="step-32-signing-the-bundle"></a><span data-ttu-id="80a44-422">手順 3.2: バンドルに署名する</span><span class="sxs-lookup"><span data-stu-id="80a44-422">Step 3.2: Signing the bundle</span></span>

<span data-ttu-id="80a44-423">(Bundle Generator ツールを使うか、または手動で) `.appxbundle` を作成したら、メイン パッケージとすべてのリソース パッケージを含む、1 つのファイルが作成されます。 </span><span class="sxs-lookup"><span data-stu-id="80a44-423">Once you have created the `.appxbundle` file (either through the Bundle Generator tool or manually) you will have a single file that contains the main package plus all the resource packages.</span></span> <span data-ttu-id="80a44-424">最後の手順は、ファイルに署名を行い、Windows がインストールできるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="80a44-424">The final step is to sign the file so that Windows will install it:</span></span>

    signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appxbundle

<span data-ttu-id="80a44-425">これによって、メイン パッケージとすべての言語固有のリソース パッケージを含む、署名済みの `.appxbundle` ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="80a44-425">This will produce a signed `.appxbundle` file that contains the main package plus all the language-specific resource packages.</span></span> <span data-ttu-id="80a44-426">これはパッケージ ファイルと同様にダブルクリックでき、それによって、アプリに加えて、ユーザーの Windows の言語設定に基づく適切な言語をインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="80a44-426">It can be double-clicked just like a package file to install the app plus any appropriate language(s) based on the user's Windows language preferences.</span></span>

## <a name="related-topics"></a><span data-ttu-id="80a44-427">関連トピック</span><span class="sxs-lookup"><span data-stu-id="80a44-427">Related topics</span></span>

* [<span data-ttu-id="80a44-428">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="80a44-428">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)