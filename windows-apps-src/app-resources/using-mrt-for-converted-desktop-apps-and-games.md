---
title: 変換されたデスクトップ アプリとゲームに MRT を使用する
description: .NET または Win32 アプリやゲームを AppX パッケージとしてパッケージ化することにより、リソース管理システムを活用して実行時のコンテキストに合わせたアプリ リソースを読み込むことができます。 この詳細なトピックでは、この手法について説明します。
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10、UWP、MRT、PRI。 リソース、ゲーム、Centennial、Desktop App Converter、MUI、サテライト アセンブリ
ms.localizationpriority: medium
ms.openlocfilehash: b17dffec37a5cadb450e93ea15508becfd7b9233
ms.sourcegitcommit: 46890e7f3c1287648631c5e318795f377764dbd9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58320635"
---
# <a name="use-the-windows-10-resource-management-system-in-a-legacy-app-or-game"></a><span data-ttu-id="24c20-106">レガシ アプリやゲームで Windows 10 のリソース管理システムを使用する</span><span class="sxs-lookup"><span data-stu-id="24c20-106">Use the Windows 10 Resource Management System in a legacy app or game</span></span>

<span data-ttu-id="24c20-107">.NET アプリや Win32 アプリは多くの場合、対象市場を拡大するため、さまざまな言語にローカライズされます。</span><span class="sxs-lookup"><span data-stu-id="24c20-107">.NET and Win32 apps and games are often localized into different languages to expand their total addressable market.</span></span> <span data-ttu-id="24c20-108">アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../design/globalizing/globalizing-portal.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-108">For more info about the value proposition of localizing your app, see [Globalization and localization](../design/globalizing/globalizing-portal.md).</span></span> <span data-ttu-id="24c20-109">.NET や Win32 のアプリやゲーム MSIX または AppX パッケージとしてパッケージ化、実行時のコンテキストに合わせたアプリのリソースを読み込むリソース管理システムを活用できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-109">By packaging your .NET or Win32 app or game as an MSIX or AppX package, you can leverage the Resource Management System to load app resources tailored to the run-time context.</span></span> <span data-ttu-id="24c20-110">この詳細なトピックでは、この手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="24c20-110">This in-depth topic describes the techniques.</span></span>

<span data-ttu-id="24c20-111">従来の Win32 アプリケーションをローカライズする方法はたくさんありますが、Windows 8 では[新しいリソース管理システム](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)が導入されました。このリソース管理システムは、さまざまなプログラミング言語やさまざまな種類のアプリケーションで動作し、ローカライズ機能を簡素化するだけでなく、さまざまな機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="24c20-111">There are many ways to localize a traditional Win32 application, but Windows 8 introduced a [new resource-management system](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx) that works across programming languages, across application types, and provides functionality over and above simple localization.</span></span> <span data-ttu-id="24c20-112">このトピックでは、このシステムを "MRT" と呼びます。</span><span class="sxs-lookup"><span data-stu-id="24c20-112">This system will be referred to as "MRT" in this topic.</span></span> <span data-ttu-id="24c20-113">「モダン」という用語の使用は停止されましたが、MRT は従来 "Modern Resource Technology" を表していました。</span><span class="sxs-lookup"><span data-stu-id="24c20-113">Historically, that stood for "Modern Resource Technology" but the term "Modern" has been discontinued.</span></span> <span data-ttu-id="24c20-114">リソース マネージャーは、MRM (モダン リソース マネージャー) または PRI (パッケージ リソース インデックス) としても知られています。</span><span class="sxs-lookup"><span data-stu-id="24c20-114">The resource manager might also be known as MRM (Modern Resource Manager) or PRI (Package Resource Index).</span></span>

<span data-ttu-id="24c20-115">(たとえば、Microsoft Store) から MSIX ベースまたは AppX ベースの展開と組み合わせると、MRT 自動的に提供できる、特定のユーザーのほとんどの適用可能なリソース/デバイス、ダウンロードを最小化して、アプリケーションのサイズをインストールします。</span><span class="sxs-lookup"><span data-stu-id="24c20-115">Combined with MSIX-based or AppX-based deployment (for example, from the Microsoft Store), MRT can automatically deliver the most-applicable resources for a given user / device which minimizes the download and install size of your application.</span></span> <span data-ttu-id="24c20-116">ローカライズ コンテンツのサイズが大きなアプリケーションでは、これによって大きなサイズ削減効果があり、高度なゲームの場合では、数*ギガバイト*にも及ぶ削減効果となることがあります。</span><span class="sxs-lookup"><span data-stu-id="24c20-116">This size reduction can be significant for applications with a large amount of localized content, perhaps on the order of several *gigabytes* for AAA games.</span></span> <span data-ttu-id="24c20-117">さらに、Windows シェルと Microsoft Store でローカライズされて表示されることや、ユーザーの使用言語と利用可能なリソースが一致しない場合の自動フォールバック ロジックなども、MRT によるメリットの例です。</span><span class="sxs-lookup"><span data-stu-id="24c20-117">Additional benefits of MRT include localized listings in the Windows Shell and the Microsoft Store, automatic fallback logic when a user's preferred language doesn't match your available resources.</span></span>

<span data-ttu-id="24c20-118">このドキュメントでは、MRT のアーキテクチャの概要を説明し、レガシの Win32 アプリケーションを最小限のコード変更で MRT に移行するためのガイドを示します。</span><span class="sxs-lookup"><span data-stu-id="24c20-118">This document describes the high-level architecture of MRT and provides a porting guide to help move legacy Win32 applications to MRT with minimal code changes.</span></span> <span data-ttu-id="24c20-119">MRT への移行により、開発者にはさまざまなメリット (スケール ファクターやシステム テーマを使ったリソースのセグメント化など) があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-119">Once the move to MRT is made, additional benefits (such as the ability to segment resources by scale factor or system theme) become available to the developer.</span></span> <span data-ttu-id="24c20-120">MRT ベースのローカライズは、UWP アプリケーションと、デスクトップ ブリッジ ("Centennial") によって処理される Win32 アプリケーションの両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="24c20-120">Note that MRT-based localization works for both UWP applications and Win32 applications processed by the Desktop Bridge (aka "Centennial").</span></span>

<span data-ttu-id="24c20-121">多くの場合、既存のローカライズ形式とソース コードを引き続き使用しながら、MRT との統合を行い、実行時にリソースを解決して、ダウンロード サイズを最小化することができます。これはオールオアナッシングのアプローチではありません。</span><span class="sxs-lookup"><span data-stu-id="24c20-121">In many situations, you can continue to use your existing localization formats and source code whilst integrating with MRT for resolving resources at runtime and minimizing download sizes - it's not an all-or-nothing approach.</span></span> <span data-ttu-id="24c20-122">各段階での作業とメリット、推定コストを次の表にまとめて示します。</span><span class="sxs-lookup"><span data-stu-id="24c20-122">The following table summarizes the work and estimated cost/benefit of each stage.</span></span> <span data-ttu-id="24c20-123">この表には、高解像度またはハイ コントラストのアプリケーション アイコンの提供などの、ローカライズ以外のタスクは含まれていません。</span><span class="sxs-lookup"><span data-stu-id="24c20-123">This table doesn't include non-localization tasks, such as providing high-resolution or high-contrast application icons.</span></span> <span data-ttu-id="24c20-124">タイル、アイコンなどへの複数のアセットの提供について詳しくは、「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-124">For more info about providing multiple assets for tiles, icons, etc., See [Tailor your resources for language, scale, high contrast, and other qualifiers](tailor-resources-lang-scale-contrast.md).</span></span>

<table>
<tr>
<th><span data-ttu-id="24c20-125">仕事用</span><span class="sxs-lookup"><span data-stu-id="24c20-125">Work</span></span></th>
<th><span data-ttu-id="24c20-126">メリット</span><span class="sxs-lookup"><span data-stu-id="24c20-126">Benefit</span></span></th>
<th><span data-ttu-id="24c20-127">推定コスト</span><span class="sxs-lookup"><span data-stu-id="24c20-127">Estimated cost</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="24c20-128">パッケージ マニフェストをローカライズします。</span><span class="sxs-lookup"><span data-stu-id="24c20-128">Localize package manifest</span></span></td>
<td><span data-ttu-id="24c20-129">Windows シェルと Microsoft Store でローカライズ コンテンツが表示されるために必要な最小限の作業</span><span class="sxs-lookup"><span data-stu-id="24c20-129">Bare minimum work required to have your localized content appear in the Windows Shell and in the Microsoft Store</span></span></td>
<td><span data-ttu-id="24c20-130">小さな</span><span class="sxs-lookup"><span data-stu-id="24c20-130">Small</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="24c20-131">MRT を使ってリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="24c20-131">Use MRT to identify and locate resources</span></span></td>
<td><span data-ttu-id="24c20-132">ダウンロードとインストールのサイズの最小化や、言語の自動フォールバックの前提条件</span><span class="sxs-lookup"><span data-stu-id="24c20-132">Pre-requisite to minimizing download and install sizes; automatic language fallback</span></span></td>
<td><span data-ttu-id="24c20-133">中</span><span class="sxs-lookup"><span data-stu-id="24c20-133">Medium</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="24c20-134">リソース パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="24c20-134">Build resource packs</span></span></td>
<td><span data-ttu-id="24c20-135">ダウンロードとインストールのサイズを最小化するための最後の手順</span><span class="sxs-lookup"><span data-stu-id="24c20-135">Final step to minimize download and install sizes</span></span></td>
<td><span data-ttu-id="24c20-136">小さな</span><span class="sxs-lookup"><span data-stu-id="24c20-136">Small</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="24c20-137">MRT リソース形式と API へ移行する</span><span class="sxs-lookup"><span data-stu-id="24c20-137">Migrate to MRT resource formats and APIs</span></span></td>
<td><span data-ttu-id="24c20-138">大幅に小さなファイル サイズ (既存のリソース テクノロジによる)</span><span class="sxs-lookup"><span data-stu-id="24c20-138">Significantly smaller file sizes (depending on existing resource technology)</span></span></td>
<td><span data-ttu-id="24c20-139">大規模です</span><span class="sxs-lookup"><span data-stu-id="24c20-139">Large</span></span></td>
</tr>
</table>

## <a name="introduction"></a><span data-ttu-id="24c20-140">概要</span><span class="sxs-lookup"><span data-stu-id="24c20-140">Introduction</span></span>

<span data-ttu-id="24c20-141">多くのアプリケーションには通常、アプリケーション コードから分離された、*リソース*と呼ばれるユーザー インターフェイス要素が含まれています (一方、値を*ハードコード*する場合は、ソース コード自体に記述されます)。</span><span class="sxs-lookup"><span data-stu-id="24c20-141">Most non-trivial applications contain user-interface elements known as *resources* that are decoupled from the application's code (contrasted with *hard-coded values* that are authored in the source code itself).</span></span> <span data-ttu-id="24c20-142">ハードコードしないで、リソースを使用することが好ましい理由はいろいろあります。たとえば、開発者以外でも編集が容易であることもその 1 つです。最も重要なメリットの 1 つは、アプリケーションが実行時に、同じ論理リソースの異なる表現を選択できることです。</span><span class="sxs-lookup"><span data-stu-id="24c20-142">There are several reasons to prefer resources over hard-coded values - ease of editing by non-developers, for example - but one of the key reasons is to enable the application to pick different representations of the same logical resource at runtime.</span></span> <span data-ttu-id="24c20-143">たとえば、ボタンに表示するテキスト (またはアイコンに表示するイメージ) が、ユーザーの使用言語や、表示デバイスの種類、使用している支援技術などによって、異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-143">For example, the text to display on a button (or the image to display in an icon) might differ depending on the language(s) the user understands, the characteristics of the display device, or whether the user has any assistive technologies enabled.</span></span>

<span data-ttu-id="24c20-144">したがって、リソース管理テクノロジの主な目的は、実行時に、論理またはシンボリックな*リソース名* (`SAVE_BUTTON_LABEL`など) の要求を、一連の*候補* (たとえば、「Save」、「Speichern」、「保存」) の中から、実際に最適な*値* (たとえば「保存」) に変換することです。</span><span class="sxs-lookup"><span data-stu-id="24c20-144">Thus the primary purpose of any resource-management technology is to translate, at runtime, a request for a logical or symbolic *resource name* (such as `SAVE_BUTTON_LABEL`) into the best possible actual *value* (eg, "Save") from a set of possible *candidates* (eg, "Save", "Speichern", or "저장").</span></span> <span data-ttu-id="24c20-145">MRT はそのための機能を提供し、アプリケーションは、*修飾子*と呼ばれる、ユーザーの言語、ディスプレイのスケール ファクター、ユーザーが選択したテーマ、その他の環境の要因などの、さまざまな属性を使って、リソースの候補を識別することができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-145">MRT provides such a function, and enables applications to identify resource candidates using a wide variety of attributes, called *qualifiers*, such as the user's language, the display scale-factor, the user's selected theme, and other environmental factors.</span></span> <span data-ttu-id="24c20-146">さらに MRT は、アプリケーションが必要とする、カスタムの修飾子をサポートします (たとえば、アプリケーションが、ゲスト ユーザーとアカウントを使ってログインしたユーザーに対して、別のグラフィック アセットを提供することができます。これを、アプリケーションのあらゆる部分にチェックのロジックを追加することなく、行えます)。</span><span class="sxs-lookup"><span data-stu-id="24c20-146">MRT even supports custom qualifiers for applications that need it (for example, an application could provide different graphic assets for users that had logged in with an account vs. guest users, without explicitly adding this check into every part of their application).</span></span> <span data-ttu-id="24c20-147">MRT は、文字列リソースとファイル ベースのリソース (外部データ、つまりファイル自体への参照として実装されている場合) の両方で動作します。</span><span class="sxs-lookup"><span data-stu-id="24c20-147">MRT works with both string resources and file-based resources, where file-based resources are implemented as references to the external data (the files themselves).</span></span>

### <a name="example"></a><span data-ttu-id="24c20-148">例</span><span class="sxs-lookup"><span data-stu-id="24c20-148">Example</span></span>

<span data-ttu-id="24c20-149">2 つのボタン (`openButton` と `saveButton`) 上のテキスト ラベルと、ロゴ (`logoImage`) に使用する PNG ファイルを持つアプリケーションでの、簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="24c20-149">Here's a simple example of an application that has text labels on two buttons (`openButton` and `saveButton`) and a PNG file used for a logo (`logoImage`).</span></span> <span data-ttu-id="24c20-150">テキスト ラベルは英語とドイツ語にローカライズされ、ロゴは通常のデスクトップ (100% スケール ファクター) と高解像度の電話 (300% スケール ファクター) 用に最適化されています。</span><span class="sxs-lookup"><span data-stu-id="24c20-150">The text labels are localized into English and German, and the logo is optimized for normal desktop displays (100% scale factor) and high-resolution phones (300% scale factor).</span></span> <span data-ttu-id="24c20-151">この図は、モデルの概念と概要を説明するためのものであり、実装に正確に対応するものではないことにご注意ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-151">Note that this diagram presents a high-level, conceptual view of the model; it does not map exactly to implementation.</span></span>

<p><img src="images\conceptual-resource-model.png"/></p>

<span data-ttu-id="24c20-152">この図で、アプリケーション コードは 3 つの論理リソース名を参照しています。</span><span class="sxs-lookup"><span data-stu-id="24c20-152">In the graphic, the application code references the three logical resource names.</span></span> <span data-ttu-id="24c20-153">実行時に、擬似関数 `GetResource` は、MRT を使用して、リソース テーブル (PRI ファイルと呼ばれます) で、そのリソース名を検索し、環境条件 (ユーザーの言語とディスプレイのスケール ファクター) に基づいて、最適な候補を見つけます。</span><span class="sxs-lookup"><span data-stu-id="24c20-153">At runtime, the `GetResource` pseudo-function uses MRT to look those resource names up in the resource table (known as PRI file) and find the most appropriate candidate based on the ambient conditions (the user's language and the display's scale-factor).</span></span> <span data-ttu-id="24c20-154">ラベルの場合は、文字列が直接使用されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-154">In the case of the labels, the strings are used directly.</span></span> <span data-ttu-id="24c20-155">ロゴ イメージの場合は、文字列がファイル名として解釈され、ファイルがディスクから読み取られます。</span><span class="sxs-lookup"><span data-stu-id="24c20-155">In the case of the logo image, the strings are interpreted as filenames and the files are read off disk.</span></span> 

<span data-ttu-id="24c20-156">ユーザーが英語またはドイツ語以外の言語を話す場合、または 100% または 300% 以外、表示スケール ファクターが場合 MRT はフォールバック規則のセットに基づいて、「最も近い」一致する候補を取得 (を参照してください[リソース管理システム](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)詳細バック グラウンド)。</span><span class="sxs-lookup"><span data-stu-id="24c20-156">If the user speaks a language other than English or German, or has a display scale-factor other than 100% or 300%, MRT picks the "closest" matching candidate based on a set of fallback rules (see [Resource Management System](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx) for more background).</span></span>

<span data-ttu-id="24c20-157">ロゴのイメージにもローカライズするために必要な埋め込みのテキストが含まれている場合に、MRT がなどの 1 つ以上の修飾子に対応したリソースをサポートしているメモ、ロゴは、次の 4 つの候補があります。EN/スケール 100、DE/スケール 100、EN/スケール-300、300-DE/スケール。</span><span class="sxs-lookup"><span data-stu-id="24c20-157">Note that MRT supports resources that are tailored to more than one qualifier - for example, if the logo image contained embedded text that also needed to be localized, the logo would have four candidates: EN/Scale-100, DE/Scale-100, EN/Scale-300 and DE/Scale-300.</span></span>

### <a name="sections-in-this-document"></a><span data-ttu-id="24c20-158">このドキュメントのセクション</span><span class="sxs-lookup"><span data-stu-id="24c20-158">Sections in this document</span></span>

<span data-ttu-id="24c20-159">以下のセクションでは、アプリケーションを MRT と統合するために必要なタスクの概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="24c20-159">The following sections outline the high-level tasks required to integrate MRT with your application.</span></span>

#### <a name="phase-0-build-an-application-package"></a><span data-ttu-id="24c20-160">フェーズ 0:アプリケーション パッケージをビルドします。</span><span class="sxs-lookup"><span data-stu-id="24c20-160">Phase 0: Build an application package</span></span>

<span data-ttu-id="24c20-161">このセクションでは、既存のデスクトップ アプリケーションを、アプリケーション パッケージとしてビルドする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="24c20-161">This section outlines how to get your existing Desktop application building as an application package.</span></span> <span data-ttu-id="24c20-162">この段階では、MRT の機能は使用しません。</span><span class="sxs-lookup"><span data-stu-id="24c20-162">No MRT features are used at this stage.</span></span>

#### <a name="phase-1-localize-the-application-manifest"></a><span data-ttu-id="24c20-163">フェーズ 1:アプリケーション マニフェストをローカライズします。</span><span class="sxs-lookup"><span data-stu-id="24c20-163">Phase 1: Localize the application manifest</span></span>

<span data-ttu-id="24c20-164">このセクションでは、アプリケーションのマニフェストをローカライズする (これにより Windows Shell に正しく表示されるようになります) 方法について説明します。この段階では、引き続き、レガシのリソース形式と API を使用して、リソースのパッケージ化と検索を行っています。</span><span class="sxs-lookup"><span data-stu-id="24c20-164">This section outlines how to localize your application's manifest (so that it appears correctly in the Windows Shell) whilst still using your legacy resource format and API to package and locate resources.</span></span> 

#### <a name="phase-2-use-mrt-to-identify-and-locate-resources"></a><span data-ttu-id="24c20-165">フェーズ 2:MRT を使ってリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="24c20-165">Phase 2: Use MRT to identify and locate resources</span></span>

<span data-ttu-id="24c20-166">このセクションでは、アプリケーション コード (および場合によってリソース レイアウト) を変更し、MRT を使用してリソースを検索する方法について説明します。この段階では、引き続き、既存のリソース形式と API を使用して、リソースの読み込みと使用を行っています。</span><span class="sxs-lookup"><span data-stu-id="24c20-166">This section outlines how to modify your application code (and possibly resource layout) to locate resources using MRT, whilst still using your existing resource formats and APIs to load and consume the resources.</span></span> 

#### <a name="phase-3-build-resource-packs"></a><span data-ttu-id="24c20-167">フェーズ 3:リソース パッケージをビルドする</span><span class="sxs-lookup"><span data-stu-id="24c20-167">Phase 3: Build resource packs</span></span>

<span data-ttu-id="24c20-168">このセクションでは、リソースを別の*リソース パッケージ*に分離して、アプリのダウンロード (およびインストール) のサイズを最小化するために必要な、最終的な変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="24c20-168">This section outlines the final changes needed to separate your resources into separate *resource packs*, minimizing the download (and install) size of your app.</span></span>

### <a name="not-covered-in-this-document"></a><span data-ttu-id="24c20-169">このドキュメントで扱わない内容</span><span class="sxs-lookup"><span data-stu-id="24c20-169">Not covered in this document</span></span>

<span data-ttu-id="24c20-170">上記の 0 ~ 3 のフェーズを完了すると、アプリケーション「バンドル」を Microsoft Store に送信できるし、するが、ダウンロードを最小限に抑える必要のないリソースを省略することでユーザーのサイズをインストールする必要が (例: 言語、話すこと)。</span><span class="sxs-lookup"><span data-stu-id="24c20-170">After completing Phases 0-3 above, you will have an application "bundle" that can be submitted to the Microsoft Store and that will minimize the download and install size for users by omitting the resources they don't need (eg, languages they don't speak).</span></span> <span data-ttu-id="24c20-171">次の最後の手順を実行すると、アプリケーションのサイズと機能をさらに向上することができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-171">Further improvements in application size and functionality can be made by taking one final step.</span></span>

#### <a name="phase-4-migrate-to-mrt-resource-formats-and-apis"></a><span data-ttu-id="24c20-172">フェーズ 4:MRT リソース形式と API へ移行する</span><span class="sxs-lookup"><span data-stu-id="24c20-172">Phase 4: Migrate to MRT resource formats and APIs</span></span>

<span data-ttu-id="24c20-173">このフェーズは、このドキュメントの対象範囲外です。このフェーズでは、MUI DLL や .NET リソース アセンブリなどの、レガシのリソース形式から、PRI ファイルに、リソース (特に文字列) を移行します。</span><span class="sxs-lookup"><span data-stu-id="24c20-173">This phase is beyond the scope of this document; it entails moving your resources (particularly strings) from legacy formats such as MUI DLLs or .NET resource assemblies into PRI files.</span></span> <span data-ttu-id="24c20-174">これにより、ダウンロードとインストールのサイズをさらに節約できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-174">This can lead to further space savings for download & install sizes.</span></span> <span data-ttu-id="24c20-175">さらに、MRT の他の機能を活用でき、たとえば、スケール ファクターや、アクセシビリティ設定などに基づいて、イメージ ファイルのダウンロードとインストールを最小化できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-175">It also allows use of other MRT features such as minimizing the download and install of image files by based on scale factor, accessibility settings, and so on.</span></span>

## <a name="phase-0-build-an-application-package"></a><span data-ttu-id="24c20-176">フェーズ 0:アプリケーション パッケージをビルドします。</span><span class="sxs-lookup"><span data-stu-id="24c20-176">Phase 0: Build an application package</span></span>

<span data-ttu-id="24c20-177">アプリケーションのリソースへの変更を行う前にまず、現在使っているパッケージ化とインストールのテクノロジを、UWP の標準のパッケージ化と展開のテクノロジに置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-177">Before you make any changes to your application's resources, you must first replace your current packaging and installation technology with the standard UWP packaging and deployment technology.</span></span> <span data-ttu-id="24c20-178">これには 3 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-178">There are three ways to do this:</span></span>

* <span data-ttu-id="24c20-179">複雑なインストーラーでの大規模なデスクトップ アプリケーションがあったり、多数の OS の機能拡張ポイントを使用する場合は、UWP ファイル レイアウトを生成し、既存のアプリ インストーラー (MSI など) から情報をマニフェストに、Desktop App Converter ツールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-179">If you have a large desktop application with a complex installer or you utilize lots of OS extensibility points, you can use the Desktop App Converter tool to generate the UWP file layout and manifest information from your existing app installer (for example, an MSI).</span></span>
* <span data-ttu-id="24c20-180">小さいのデスクトップ アプリケーション比較的少数のファイルまたは簡単なインストーラーとなしの拡張性フックを使用した場合は、ファイルのレイアウトを作成して、マニフェスト情報を手動で。</span><span class="sxs-lookup"><span data-stu-id="24c20-180">If you have a smaller desktop application with relatively few files or a simple installer and no extensibility hooks, you can create the file layout and manifest information manually.</span></span>
* <span data-ttu-id="24c20-181">ソースから再構築しているアプリケーションを純粋な UWP アプリケーションを更新する場合は、Visual Studio で新しいプロジェクトを作成し、作業の多くを自動的に実行するための IDE に依存します。</span><span class="sxs-lookup"><span data-stu-id="24c20-181">If you're rebuilding from source and want to update your app to be a pure UWP application, you can create a new project in Visual Studio and rely on the IDE to do much of the work for you.</span></span>

<span data-ttu-id="24c20-182">使用する場合、 [Desktop App Converter](https://aka.ms/converter)を参照してください[、Desktop App Converter を使用してデスクトップ アプリケーションをパッケージ化](https://aka.ms/converterdocs)変換プロセスの詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="24c20-182">If you want to use the [Desktop App Converter](https://aka.ms/converter), see [Package a desktop application using the Desktop App Converter](https://aka.ms/converterdocs) for more information on the conversion process.</span></span> <span data-ttu-id="24c20-183">デスクトップ コンバーター サンプルの完全なセットが見つかります[UWP にデスクトップ ブリッジ サンプル GitHub リポジトリ](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)します。</span><span class="sxs-lookup"><span data-stu-id="24c20-183">A complete set of Desktop Converter samples can be found on [the Desktop Bridge to UWP samples GitHub repo](https://github.com/Microsoft/DesktopBridgeToUWP-Samples).</span></span>

<span data-ttu-id="24c20-184">パッケージを手動で作成する場合は、アプリケーションのすべてのファイル (実行可能ファイルと、コンテンツがソース コードではなく) とパッケージ マニフェスト ファイル (.appxmanifest) が含まれるディレクトリ構造を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-184">If you want to manually create the package, you will need to create a directory structure that includes all your application's files (executables and content, but not source code) and a package manifest file (.appxmanifest).</span></span> <span data-ttu-id="24c20-185">例が記載されて[こんにちは, World GitHub サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/HelloWorldSample/CentennialPackage/AppxManifest.xml)、という名前の実行可能ファイルのデスクトップを実行する基本的なパッケージ マニフェスト ファイルが、`ContosoDemo.exe`は次のように、場所、<span style="background-color: yellow">テキストを強調表示されている</span>なります独自の値で置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="24c20-185">An example can be found in [the Hello, World GitHub sample](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/HelloWorldSample/CentennialPackage/AppxManifest.xml), but a basic package manifest file that runs the desktop executable named `ContosoDemo.exe` is as follows, where the <span style="background-color: yellow">highlighted text</span> would be replaced by your own values.</span></span>

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
         xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
         IgnorableNamespaces="uap mp rescap">
    <Identity Name="Contoso.Demo"
              Publisher="CN=Contoso.Demo"
              Version="1.0.0.0" />
    <Properties>
    <DisplayName>Contoso App</DisplayName>
    <PublisherDisplayName>Contoso, Inc</PublisherDisplayName>
    <Logo>Assets\StoreLogo.png</Logo>
  </Properties>
    <Dependencies>
    <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.0" 
                        MaxVersionTested="10.0.14393.0" />
  </Dependencies>
    <Resources>
    <Resource Language="en-US" />
  </Resources>
    <Applications>
    <Application Id="ContosoDemo" Executable="ContosoDemo.exe" 
                 EntryPoint="Windows.FullTrustApplication">
    <uap:VisualElements DisplayName="Contoso Demo" BackgroundColor="#777777" 
                        Square150x150Logo="Assets\Square150x150Logo.png" 
                        Square44x44Logo="Assets\Square44x44Logo.png" 
        Description="Contoso Demo">
      </uap:VisualElements>
    </Application>
  </Applications>
    <Capabilities>
    <rescap:Capability Name="runFullTrust" />
  </Capabilities>
</Package>
```

<span data-ttu-id="24c20-186">パッケージ マニフェスト ファイルとパッケージのレイアウトの詳細については、次を参照してください。[アプリ パッケージのマニフェスト](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest)します。</span><span class="sxs-lookup"><span data-stu-id="24c20-186">For more information about the package manifest file and package layout, see [App package manifest](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appx-package-manifest).</span></span>

<span data-ttu-id="24c20-187">最後に、Visual Studio を新しいプロジェクトを作成し、既存のコード間で移行を使用している場合について[作成「こんにちは, world」アプリ](https://msdn.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)します。</span><span class="sxs-lookup"><span data-stu-id="24c20-187">Finally, if you're using Visual Studio to create a new project and migrate your existing code across, see [Create a "Hello, world" app](https://msdn.microsoft.com/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span> <span data-ttu-id="24c20-188">新しいプロジェクトの場合に、既存のコードを含めることができますが、純粋な UWP アプリとして実行するには、(特に、ユーザー インターフェイス) に大幅なコードの変更する必要があります可能性があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-188">You can include your existing code into the new project, but you will likely have to make significant code changes (particularly in the user interface) in order to run as a pure UWP app.</span></span> <span data-ttu-id="24c20-189">それらの変更は、このドキュメントの対象範囲外です。</span><span class="sxs-lookup"><span data-stu-id="24c20-189">These changes are outside the scope of this document.</span></span>

## <a name="phase-1-localize-the-manifest"></a><span data-ttu-id="24c20-190">フェーズ 1:マニフェストをローカライズします。</span><span class="sxs-lookup"><span data-stu-id="24c20-190">Phase 1: Localize the manifest</span></span>

### <a name="step-11-update-strings--assets-in-the-manifest"></a><span data-ttu-id="24c20-191">手順 1.1:文字列の更新 (&)、マニフェスト内の資産</span><span class="sxs-lookup"><span data-stu-id="24c20-191">Step 1.1: Update strings & assets in the manifest</span></span>

<span data-ttu-id="24c20-192">フェーズ 0 (値コンバーターを提供、MSI から抽出された、または、マニフェストに手動で入力に基づく)、アプリケーションの基本的なパッケージ マニフェスト (.appxmanifest) ファイルを作成したのローカライズされた情報は含まれませんもサポートされます。高解像度の開始などの追加機能には、資産などが並べて表示します。</span><span class="sxs-lookup"><span data-stu-id="24c20-192">In Phase 0 you created a basic package manifest (.appxmanifest) file for your application (based on values provided to the converter, extracted from the MSI, or manually entered into the manifest) but it will not contain localized information, nor will it support additional features like high-resolution Start tile assets, etc.</span></span>

<span data-ttu-id="24c20-193">アプリケーションの名前と説明が正しくローカライズされたことを確認するには、するには、リソース ファイルのセット内の一部のリソースを定義し、それらを参照するパッケージのマニフェストを更新します。</span><span class="sxs-lookup"><span data-stu-id="24c20-193">To ensure your application's name and description are correctly localized, you must define some resources in a set of resource files, and update the package manifest to reference them.</span></span>

#### <a name="creating-a-default-resource-file"></a><span data-ttu-id="24c20-194">既定のリソース ファイルを作成する</span><span class="sxs-lookup"><span data-stu-id="24c20-194">Creating a default resource file</span></span>

<span data-ttu-id="24c20-195">最初の手順では、既定の言語 (たとえば、英語 (米国)) で既定のリソース ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-195">The first step is to create a default resource file in your default language (eg, US English).</span></span> <span data-ttu-id="24c20-196">これは、テキスト エディターを使って手動で作成するか、または Visual Studio のリソース デザイナーによって行うことができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-196">You can do this either manually with a text editor, or via the Resource Designer in Visual Studio.</span></span>

<span data-ttu-id="24c20-197">リソースを手動で作成する場合には:</span><span class="sxs-lookup"><span data-stu-id="24c20-197">If you want to create the resources manually:</span></span>

1. <span data-ttu-id="24c20-198">`resources.resw` という XML ファイルを作成して、プロジェクトの `Strings\en-us` サブフォルダーに配置します。</span><span class="sxs-lookup"><span data-stu-id="24c20-198">Create an XML file named `resources.resw` and place it in a `Strings\en-us` subfolder of your project.</span></span> <span data-ttu-id="24c20-199">既定の言語が英語 (米国) がない場合は、BCP 47 に適切なコードを使用します。</span><span class="sxs-lookup"><span data-stu-id="24c20-199">Use the appropriate BCP-47 code if your default language is not US English.</span></span>
2. <span data-ttu-id="24c20-200">XML ファイルに次のコンテンツを追加します。使用する既定の言語で、<span style="background-color: yellow">強調表示されたテキスト</span>を、アプリのために適切なテキストに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24c20-200">In the XML file, add the following content, where the <span style="background-color: yellow">highlighted text</span> is replaced with the appropriate text for your app, in your default language.</span></span>

> [!NOTE]
> <span data-ttu-id="24c20-201">これらの文字列の一部の長の制限があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-201">There are restrictions on the lengths of some of these strings.</span></span> <span data-ttu-id="24c20-202">詳しくは、「[VisualElements](/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-202">For more info, see [VisualElements](/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements).</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="ApplicationDescription">
    <value>Contoso Demo app with localized resources (English)</value>
  </data>
  <data name="ApplicationDisplayName">
    <value>Contoso Demo Sample (English)</value>
  </data>
  <data name="PackageDisplayName">
    <value>Contoso Demo Package (English)</value>
  </data>
  <data name="PublisherDisplayName">
    <value>Contoso Samples, USA</value>
  </data>
  <data name="TileShortName">
    <value>Contoso (EN)</value>
  </data>
</root>
```

<span data-ttu-id="24c20-203">Visual Studio でデザイナーを使用する場合は:</span><span class="sxs-lookup"><span data-stu-id="24c20-203">If you want to use the designer in Visual Studio:</span></span>

1. <span data-ttu-id="24c20-204">作成、`Strings\en-us`プロジェクトのフォルダー (またはその他の言語は、必要に応じて) を追加し、**新しい項目の**、プロジェクトのルート フォルダーへの既定の名前を使用して`resources.resw`。</span><span class="sxs-lookup"><span data-stu-id="24c20-204">Create the `Strings\en-us` folder (or other language as appropriate) in your project and add a **New Item** to the root folder of your project, using the default name of `resources.resw`.</span></span> <span data-ttu-id="24c20-205">選択してください**リソース ファイル (.resw)** なく**リソース ディクショナリ**-リソース ディクショナリは、XAML アプリケーションによって使用されるファイル。</span><span class="sxs-lookup"><span data-stu-id="24c20-205">Be sure to choose **Resources File (.resw)** and not **Resource Dictionary** - a Resource Dictionary is a file used by XAML applications.</span></span>
2. <span data-ttu-id="24c20-206">デザイナーを使って次の文字列を入力します (同じ `Names` を使用し、`Values` をアプリケーションのために適切なテキストに置き換えます)。</span><span class="sxs-lookup"><span data-stu-id="24c20-206">Using the designer, enter the following strings (use the same `Names` but replace the `Values` with the appropriate text for your application):</span></span>

<img src="images\editing-resources-resw.png"/>

> [!NOTE]
> <span data-ttu-id="24c20-207">常に直接キーを押して、XML を編集することができます、Visual Studio デザイナーを起動した場合`F7`します。</span><span class="sxs-lookup"><span data-stu-id="24c20-207">If you start with the Visual Studio designer, you can always edit the XML directly by pressing `F7`.</span></span> <span data-ttu-id="24c20-208">ただし、最小限の XML ファイルで開始する場合、さまざまな追加のメタデータが含まれていないため、*デザイナーは、ファイルを認識しません*。手動で編集する XML ファイルに、デザイナーが生成したファイルからスケルトンの XSD 情報をコピーすると、この問題を解決できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-208">But if you start with a minimal XML file, *the designer will not recognize the file* because it's missing a lot of additional metadata; you can fix this by copying the boilerplate XSD information from a designer-generated file into your hand-edited XML file.</span></span>

#### <a name="update-the-manifest-to-reference-the-resources"></a><span data-ttu-id="24c20-209">マニフェストを更新してリソースを参照する</span><span class="sxs-lookup"><span data-stu-id="24c20-209">Update the manifest to reference the resources</span></span>

<span data-ttu-id="24c20-210">定義されている値を取得したら、`.resw`ファイル、次の手順は、リソース文字列を参照するマニフェストを更新します。</span><span class="sxs-lookup"><span data-stu-id="24c20-210">After you have the values defined in the `.resw` file, the next step is to update the manifest to reference the resource strings.</span></span> <span data-ttu-id="24c20-211">ここでも、XML ファイルを直接編集するか、Visual Studio のマニフェスト デザイナーを利用できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-211">Again, you can edit an XML file directly, or rely on the Visual Studio Manifest Designer.</span></span>

<span data-ttu-id="24c20-212">XML を直接編集する場合は、`AppxManifest.xml` ファイルを開き、<span style="background-color: lightgreen">強調表示された値</span>に次の変更を行います。これは、アプリケーション固有ではなく、このテキストを*そのまま*使用します。</span><span class="sxs-lookup"><span data-stu-id="24c20-212">If you are editing XML directly, open the `AppxManifest.xml` file and make the following changes to the <span style="background-color: lightgreen">highlighted values</span> - use this *exact* text, not text specific to your application.</span></span> <span data-ttu-id="24c20-213">これらのリソースの正確な名前を使用する必要はありません&mdash;独自に選択することができます&mdash;が内容に関係なく正確に一致する必要があります何であれ、`.resw`ファイル。</span><span class="sxs-lookup"><span data-stu-id="24c20-213">There is no requirement to use these exact resource names&mdash;you can choose your own&mdash;but whatever you choose must exactly match whatever is in the `.resw` file.</span></span> <span data-ttu-id="24c20-214">これらの名前は `.resw` ファイルで作成した `Names` と一致し、`ms-resource:` スキームと `Resources/` 名前空間のプレフィックスが付く必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-214">These names should match the `Names` you created in the `.resw` file, prefixed with the `ms-resource:` scheme and the `Resources/` namespace.</span></span> 

> [!NOTE]
> <span data-ttu-id="24c20-215">このスニペットから、マニフェストの多くの要素は省略されています - 何も削除しないでください。</span><span class="sxs-lookup"><span data-stu-id="24c20-215">Many elements of the manifest have been omitted from this snippet - do not delete anything!</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package>
  <Properties>
    <DisplayName>ms-resource:Resources/PackageDisplayName</DisplayName>
    <PublisherDisplayName>ms-resource:Resources/PublisherDisplayName</PublisherDisplayName>
  </Properties>
  <Applications>
    <Application>
      <uap:VisualElements DisplayName="ms-resource:Resources/ApplicationDisplayName"
        Description="ms-resource:Resources/ApplicationDescription">
        <uap:DefaultTile ShortName="ms-resource:Resources/TileShortName">
          <uap:ShowNameOnTiles>
            <uap:ShowOn Tile="square150x150Logo" />
          </uap:ShowNameOnTiles>
        </uap:DefaultTile>
      </uap:VisualElements>
    </Application>
  </Applications>
</Package>
```

<span data-ttu-id="24c20-216">.Appxmanifest ファイルを開くし、変更、Visual Studio のマニフェスト デザイナーを使用している場合、<span style="background-color: lightgreen">値を強調表示されている</span>値、**アプリケーション* タブおよび*パッケージ\* タブ。</span><span class="sxs-lookup"><span data-stu-id="24c20-216">If you are using the Visual Studio manifest designer, open the .appxmanifest file and change the <span style="background-color: lightgreen">highlighted values</span> values in the \**Application* tab and the *Packaging* tab:</span></span>

<img src="images\editing-application-info.png"/>
<img src="images\editing-packaging-info.png"/>

### <a name="step-12-build-pri-file-make-an-msix-package-and-verify-its-working"></a><span data-ttu-id="24c20-217">手順 1.2:PRI ファイルをビルド、MSIX パッケージでは、および確認することが動作</span><span class="sxs-lookup"><span data-stu-id="24c20-217">Step 1.2: Build PRI file, make an MSIX package, and verify it's working</span></span>

<span data-ttu-id="24c20-218">`.pri` ファイルをビルドし、アプリケーションを展開して、(既定の言語で) 正しい情報がスタート メニューに表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="24c20-218">You should now be able to build the `.pri` file and deploy the application to verify that the correct information (in your default language) is appearing in the Start Menu.</span></span>

<span data-ttu-id="24c20-219">Visual Studio でビルドを行う場合は、`Ctrl+Shift+B` を押すとプロジェクトをビルドできます。次にプロジェクトを右クリックして、コンテキスト メニューから `Deploy` を選択します。</span><span class="sxs-lookup"><span data-stu-id="24c20-219">If you're building in Visual Studio, simply press `Ctrl+Shift+B` to build the project and then right-click on the project and choose `Deploy` from the context menu.</span></span>

<span data-ttu-id="24c20-220">手動で、構築する場合は、次の手順の構成ファイルを作成するをに従って`MakePRI`ツールを生成して、`.pri`ファイル自体 (詳細が記載されて[手動アプリケーションのパッケージ化](https://docs.microsoft.com/en-us/windows/uwp/packaging/manual-packaging-root))。</span><span class="sxs-lookup"><span data-stu-id="24c20-220">If you're building manually, follow these steps to create a configuration file for `MakePRI` tool and to generate the `.pri` file itself (more information can be found in [Manual app packaging](https://docs.microsoft.com/en-us/windows/uwp/packaging/manual-packaging-root)):</span></span>

1. <span data-ttu-id="24c20-221">開発者コマンド プロンプトを開き、 **Visual Studio 2017**または**Visual Studio 2019** [スタート] メニューのフォルダー。</span><span class="sxs-lookup"><span data-stu-id="24c20-221">Open a developer command prompt from the **Visual Studio 2017** or **Visual Studio 2019** folder in the Start menu.</span></span>
2. <span data-ttu-id="24c20-222">プロジェクトのルート ディレクトリに切り替えます (.appxmanifest ファイルを格納して、**文字列**フォルダー)。</span><span class="sxs-lookup"><span data-stu-id="24c20-222">Switch to the project root directory (the one that contains the .appxmanifest file and the **Strings** folder).</span></span>
3. <span data-ttu-id="24c20-223">"Contoso_demo.xml" をプロジェクトに適した名前に置き換え、"en-US" をアプリの既定の言語に置き換えて (または必要に応じて "en-US" のままとして)、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="24c20-223">Type the following command, replacing "contoso_demo.xml" with a name suitable for your project, and "en-US" with the default language of your app (or keep it en-US if applicable).</span></span> <span data-ttu-id="24c20-224">親ディレクトリに XML ファイルが作成されたに注意してください (**いない**プロジェクト ディレクトリ内) (他のディレクトリに必ず置き換えてください後でコマンドを選択することができます)、アプリケーションの一部ではないためです。</span><span class="sxs-lookup"><span data-stu-id="24c20-224">Note the XML file is created in the parent directory (**not** in the project directory) since it's not part of the application (you can choose any other directory you want, but be sure to substitute that in future commands).</span></span>

    ```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o
    ```

    <span data-ttu-id="24c20-225">「`makepri createconfig /?`」と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="24c20-225">You can type `makepri createconfig /?` to see what each parameter does, but in summary:</span></span>
      * <span data-ttu-id="24c20-226">`/cf` 構成ファイル名 (このコマンドの出力) を設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-226">`/cf` sets the Configuration Filename (the output of this command)</span></span>
      * <span data-ttu-id="24c20-227">`/dq` ここでは、言語、既定の修飾子を設定します。 `en-US`</span><span class="sxs-lookup"><span data-stu-id="24c20-227">`/dq` sets the Default Qualifiers, in this case the language `en-US`</span></span>
      * <span data-ttu-id="24c20-228">`/pv` このケースの Windows 10 では、プラットフォームのバージョンを設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-228">`/pv` sets the Platform Version, in this case Windows 10</span></span>
      * <span data-ttu-id="24c20-229">`/o` 存在する場合は、出力ファイルを上書きするように設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-229">`/o` sets it to Overwrite the output file if it exists</span></span>

4. <span data-ttu-id="24c20-230">構成ファイルが作成されました。`MakePRI` を再度実行して、ディスクにあるリソースを検索し、それを PRI ファイルにパッケージ化します。</span><span class="sxs-lookup"><span data-stu-id="24c20-230">Now you have a configuration file, run `MakePRI` again to actually search the disk for resources and package them into a PRI file.</span></span> <span data-ttu-id="24c20-231">"Contoso_demop.xml" を、前の手順で使った XML ファイル名に置き換えます。入力と出力の両方に、必ず親ディレクトリを指定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-231">Replace "contoso_demop.xml" with the XML filename you used in the previous step, and be sure to specify the parent directory for both input and output:</span></span> 

    ```CMD
    makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o
    ```

    <span data-ttu-id="24c20-232">`makepri new /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="24c20-232">You can type `makepri new /?` to see what each parameter does, but in a nutshell:</span></span>
      * <span data-ttu-id="24c20-233">`/pr` (この例では、現在のディレクトリ) では、プロジェクトのルートを設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-233">`/pr` sets the Project Root (in this case, the current directory)</span></span>
      * <span data-ttu-id="24c20-234">`/cf` 前の手順で作成、構成ファイル名を設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-234">`/cf` sets the Configuration Filename, created in the previous step</span></span>
      * <span data-ttu-id="24c20-235">`/of` 出力ファイルを設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-235">`/of` sets the Output File</span></span> 
      * <span data-ttu-id="24c20-236">`/mf` マッピング ファイルを作成します (そのため、後の手順でパッケージ内のファイルを除外しましたできます)</span><span class="sxs-lookup"><span data-stu-id="24c20-236">`/mf` creates a Mapping File (so we can exclude files in the package in a later step)</span></span>
      * <span data-ttu-id="24c20-237">`/o` 存在する場合は、出力ファイルを上書きするように設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-237">`/o` sets it to Overwrite the output file if it exists</span></span>

5. <span data-ttu-id="24c20-238">既定の言語リソース (たとえば en-US) を持つ `.pri` が作成されました。</span><span class="sxs-lookup"><span data-stu-id="24c20-238">Now you have a `.pri` file with the default language resources (eg, en-US).</span></span> <span data-ttu-id="24c20-239">次のコマンドを実行して、正しく動作することを確認します。</span><span class="sxs-lookup"><span data-stu-id="24c20-239">To verify that it worked correctly, you can run the following command:</span></span>

    ```CMD
    makepri dump /if ..\resources.pri /of ..\resources /o
    ```

    <span data-ttu-id="24c20-240">`makepri dump /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="24c20-240">You can type `makepri dump /?` to see what each parameter does, but in a nutshell:</span></span>
      * <span data-ttu-id="24c20-241">`/if` 入力ファイル名を設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-241">`/if` sets the Input Filename</span></span> 
      * <span data-ttu-id="24c20-242">`/of` 出力ファイル名を設定 (`.xml`が自動的に追加されます)</span><span class="sxs-lookup"><span data-stu-id="24c20-242">`/of` sets the Output Filename (`.xml` will be appended automatically)</span></span>
      * <span data-ttu-id="24c20-243">`/o` 存在する場合は、出力ファイルを上書きするように設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-243">`/o` sets it to Overwrite the output file if it exists</span></span>

6. <span data-ttu-id="24c20-244">最後に、 `.\resources.xml` をテキスト エディターで開き、`<NamedResource>` の値 (`ApplicationDescription` や `PublisherDisplayName` など) が含まれること、さらに選択した既定の言語の `<Candidate>` が含まれることを確認します (ファイルの先頭には、その他のコンテンツがありますが、ここでは無視してください)。</span><span class="sxs-lookup"><span data-stu-id="24c20-244">Finally, you can open `..\resources.xml` in a text editor and verify it lists your `<NamedResource>` values (like `ApplicationDescription` and `PublisherDisplayName`) along with `<Candidate>` values for your chosen default language (there will be other content in the beginning of the file; ignore that for now).</span></span>

<span data-ttu-id="24c20-245">マッピング ファイルを開くことができます`.\resources.map.txt`(プロジェクトのディレクトリの一部ではない PRI ファイルを含む)、プロジェクトに必要なファイルが含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="24c20-245">You can open the mapping file `..\resources.map.txt` to verify it contains the files needed for your project (including the PRI file, which is not part of the project's directory).</span></span> <span data-ttu-id="24c20-246">マッピング ファイルには、 `resources.resw` ファイルへの参照は含まれて*いません*。これは重要です。そのファイルの内容は既に PRI ファイルに埋め込まれているためです。</span><span class="sxs-lookup"><span data-stu-id="24c20-246">Importantly, the mapping file will *not* include a reference to your `resources.resw` file because the contents of that file have already been embedded in the PRI file.</span></span> <span data-ttu-id="24c20-247">ただし、イメージのファイル名などの他のリソースは含まれています。</span><span class="sxs-lookup"><span data-stu-id="24c20-247">It will, however, contain other resources like the filenames of your images.</span></span>

#### <a name="building-and-signing-the-package"></a><span data-ttu-id="24c20-248">パッケージをビルドして署名する</span><span class="sxs-lookup"><span data-stu-id="24c20-248">Building and signing the package</span></span> 

<span data-ttu-id="24c20-249">PRI ファイルがビルドされました。次はパッケージをビルドして署名します。</span><span class="sxs-lookup"><span data-stu-id="24c20-249">Now the PRI file is built, you can build and sign the package:</span></span>

1. <span data-ttu-id="24c20-250">アプリ パッケージを作成するには、次のコマンドの置換を実行`contoso_demo.appx`MSIX/AppX の名前を持つファイルを作成して、ファイルを別のディレクトリを選択することを確認 (このサンプルは、親ディレクトリを使用しては、任意の場所必要がありますが可能にできます**いない**プロジェクト ディレクトリにあります)。</span><span class="sxs-lookup"><span data-stu-id="24c20-250">To create the app package, run the following command replacing `contoso_demo.appx` with the name of the MSIX/AppX file you want to create and making sure to choose a different directory for the file (this sample uses the parent directory; it can be anywhere but should **not** be the project directory).</span></span>

    ```CMD
    makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o
    ```

    <span data-ttu-id="24c20-251">`makeappx pack /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="24c20-251">You can type `makeappx pack /?` to see what each parameter does, but in a nutshell:</span></span>
      * <span data-ttu-id="24c20-252">`/m` 使用するマニフェスト ファイルを設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-252">`/m` sets the Manifest file to use</span></span>
      * <span data-ttu-id="24c20-253">`/f` (前の手順で作成) を使用するファイルのマッピングを設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-253">`/f` sets the mapping File to use (created in the previous step)</span></span> 
      * <span data-ttu-id="24c20-254">`/p` 出力を設定するパッケージ名</span><span class="sxs-lookup"><span data-stu-id="24c20-254">`/p` sets the output Package name</span></span>
      * <span data-ttu-id="24c20-255">`/o` 存在する場合は、出力ファイルを上書きするように設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-255">`/o` sets it to Overwrite the output file if it exists</span></span>

2. <span data-ttu-id="24c20-256">パッケージを作成すると、署名する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-256">After the package is created, it must be signed.</span></span> <span data-ttu-id="24c20-257">署名証明書を取得する最も簡単な方法は、Visual Studio で空のユニバーサル Windows プロジェクトを作成し、コピーは、`.pfx`が作成されるファイルを使用して手動で作成できます、`MakeCert`と`Pvk2Pfx` 」の説明に従ってユーティリティ[アプリ パッケージが署名証明書を作成する方法](https://docs.microsoft.com/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate)します。</span><span class="sxs-lookup"><span data-stu-id="24c20-257">The easiest way to get a signing certificate is by creating an empty Universal Windows project in Visual Studio and copying the `.pfx` file it creates, but you can create one manually using the `MakeCert` and `Pvk2Pfx` utilities as described in [How to create an app package signing certificate](https://docs.microsoft.com/windows/desktop/appxpkg/how-to-create-a-package-signing-certificate).</span></span>

    > [!IMPORTANT]
    > <span data-ttu-id="24c20-258">署名証明書を手動で作成する場合は、ソース プロジェクトや、パッケージのソース、それ以外の場合、秘密キーを含む、パッケージの一部として含める取得可能性がありますよりも、別のディレクトリに、ファイルを配置することを確認してください!</span><span class="sxs-lookup"><span data-stu-id="24c20-258">If you manually create a signing certificate, make sure you place the files in a different directory than your source project or your package source, otherwise it might get included as part of the package, including the private key!</span></span>

3. <span data-ttu-id="24c20-259">パッケージに署名するには、次のコマンドを使用します。</span><span class="sxs-lookup"><span data-stu-id="24c20-259">To sign the package, use the following command.</span></span> <span data-ttu-id="24c20-260">`AppxManifest.xml` の `Identity` 要素で指定されている `Publisher` は、証明書の `Subject` と一致する必要があります (これは `<PublisherDisplayName>` 要素では**ありません**。それはユーザーに表示されるローカライズされた表示名です)。</span><span class="sxs-lookup"><span data-stu-id="24c20-260">Note that the `Publisher` specified in the `Identity` element of the `AppxManifest.xml` must match the `Subject` of the certificate (this is **not** the `<PublisherDisplayName>` element, which is the localized display name to show to users).</span></span> <span data-ttu-id="24c20-261">通常と同様に、`contoso_demo...` のファイル名をプロジェクトに適した名前で置き換えます。さらに `.pfx` ファイルが現在のディレクトリにないことを確認します (**これは非常に重要です**。そうしない場合、プライベート署名キーを含めて、パッケージの一部として作成されてしまいます)。</span><span class="sxs-lookup"><span data-stu-id="24c20-261">As usual, replace the `contoso_demo...` filenames with the names appropriate for your project, and (**very important**) make sure the `.pfx` file is not in the current directory (otherwise it would have been created as part of your package, including the private signing key!):</span></span>

    ```CMD
    signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appx
    ```

    <span data-ttu-id="24c20-262">`signtool sign /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="24c20-262">You can type `signtool sign /?` to see what each parameter does, but in a nutshell:</span></span>
      * <span data-ttu-id="24c20-263">`/fd` ファイルのダイジェスト アルゴリズム (SHA256 は AppX の既定値) を設定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-263">`/fd` sets the File Digest algorithm (SHA256 is the default for AppX)</span></span>
      * <span data-ttu-id="24c20-264">`/a` 最適な証明書が自動的に選択します。</span><span class="sxs-lookup"><span data-stu-id="24c20-264">`/a` will Automatically select the best certificate</span></span>
      * <span data-ttu-id="24c20-265">`/f` 署名証明書を含む入力ファイルを指定します</span><span class="sxs-lookup"><span data-stu-id="24c20-265">`/f` specifies the input File that contains the signing certificate</span></span>

<span data-ttu-id="24c20-266">最後に、`.appx` ファイルをダブルクリックしてインストールします。またはコマンド ラインを使用する場合には、PowerShell プロンプトを開き、パッケージを含むディレクトリへ移動し、次のように入力します (`contoso_demo.appx` を使用するパッケージ名に置き換えます)。</span><span class="sxs-lookup"><span data-stu-id="24c20-266">Finally, you can now double-click on the `.appx` file to install it, or if you prefer the command-line you can open a PowerShell prompt, change to the directory containing the package, and type the following (replacing `contoso_demo.appx` with your package name):</span></span>

```CMD
add-appxpackage contoso_demo.appx
```

<span data-ttu-id="24c20-267">証明書が信頼されていないというエラーが発生した場合、証明書が (ユーザー ストア**ではなく**) コンピューターのストアに追加されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="24c20-267">If you receive errors about the certificate not being trusted, make sure it is added to the machine store (**not** the user store).</span></span> <span data-ttu-id="24c20-268">コンピューターのストアに証明書を追加するには、コマンドライン、または Windows エクスプローラーを使用します。</span><span class="sxs-lookup"><span data-stu-id="24c20-268">To add the certificate to the machine store, you can either use the command-line or Windows Explorer.</span></span>

<span data-ttu-id="24c20-269">コマンドラインを使用する場合:</span><span class="sxs-lookup"><span data-stu-id="24c20-269">To use the command-line:</span></span>

1. <span data-ttu-id="24c20-270">Visual Studio 2017 または Visual Studio 2019 のコマンド プロンプトを管理者として実行します。</span><span class="sxs-lookup"><span data-stu-id="24c20-270">Run a Visual Studio 2017 or Visual Studio 2019 command prompt as an Administrator.</span></span>
2. <span data-ttu-id="24c20-271">`.cer` ファイルを含むディレクトリに移動します (このディレクトリが、ソース ディレクトリまたはプロジェクト ディレクトリではないことを確認してください)</span><span class="sxs-lookup"><span data-stu-id="24c20-271">Switch to the directory that contains the `.cer` file (remember to ensure this is outside of your source or project directories!)</span></span>
3. <span data-ttu-id="24c20-272">`contoso_demo.cer` を使用するファイル名と置き換えて、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="24c20-272">Type the following command, replacing `contoso_demo.cer` with your filename:</span></span>
    ```CMD
    certutil -addstore TrustedPeople contoso_demo.cer
    ```
    
    <span data-ttu-id="24c20-273">`certutil -addstore /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:</span><span class="sxs-lookup"><span data-stu-id="24c20-273">You can run `certutil -addstore /?` to see what each parameter does, but in a nutshell:</span></span>
      * <span data-ttu-id="24c20-274">`-addstore` 証明書ストアに証明書を追加します。</span><span class="sxs-lookup"><span data-stu-id="24c20-274">`-addstore` adds a certificate to a certificate store</span></span>
      * <span data-ttu-id="24c20-275">`TrustedPeople` ストアの証明書を配置することを示します</span><span class="sxs-lookup"><span data-stu-id="24c20-275">`TrustedPeople` indicates the store into which the certificate is placed</span></span>

<span data-ttu-id="24c20-276">Windows エクスプローラーを使用する場合:</span><span class="sxs-lookup"><span data-stu-id="24c20-276">To use Windows Explorer:</span></span>

1. <span data-ttu-id="24c20-277">`.pfx` ファイルが含まれているフォルダーに移動します</span><span class="sxs-lookup"><span data-stu-id="24c20-277">Navigate to the folder that contains the `.pfx` file</span></span>
2. <span data-ttu-id="24c20-278">`.pfx` ファイルをダブルクリックすると、**証明書インポート ウィザード**が表示されます</span><span class="sxs-lookup"><span data-stu-id="24c20-278">Double-click on the `.pfx` file and the **Certicicate Import Wizard** should appear</span></span>
3. <span data-ttu-id="24c20-279">選択`Local Machine` をクリック `Next`</span><span class="sxs-lookup"><span data-stu-id="24c20-279">Choose `Local Machine` and click `Next`</span></span>
4. <span data-ttu-id="24c20-280">表示されたら、クリックすると、ユーザー アカウント制御管理者の昇格時のプロンプトを受け入れる `Next`</span><span class="sxs-lookup"><span data-stu-id="24c20-280">Accept the User Account Control admin elevation prompt, if it appears, and click `Next`</span></span>
5. <span data-ttu-id="24c20-281">、1 つを使用する必要がある場合は、秘密キーのパスワードを入力し、をクリックしてください `Next`</span><span class="sxs-lookup"><span data-stu-id="24c20-281">Enter the password for the private key, if there is one, and click `Next`</span></span>
6. <span data-ttu-id="24c20-282">選択します `Place all certificates in the following store`</span><span class="sxs-lookup"><span data-stu-id="24c20-282">Select `Place all certificates in the following store`</span></span>
7. <span data-ttu-id="24c20-283">`Browse` をクリックして、(「信頼された発行元」**ではなく**) `Trusted People` フォルダーを選択します</span><span class="sxs-lookup"><span data-stu-id="24c20-283">Click `Browse`, and choose the `Trusted People` folder (**not** "Trusted Publishers")</span></span>
8. <span data-ttu-id="24c20-284">クリック`Next`し `Finish`</span><span class="sxs-lookup"><span data-stu-id="24c20-284">Click `Next` and then `Finish`</span></span>

<span data-ttu-id="24c20-285">`Trusted People` ストアに証明書を追加したら、もう一度パッケージをインストールします。</span><span class="sxs-lookup"><span data-stu-id="24c20-285">After adding the certificate to the `Trusted People` store, try installing the package again.</span></span>

<span data-ttu-id="24c20-286">これでアプリは、`.resw` / `.pri` ファイルの正しい情報を使って、スタート メニューの [すべてのアプリ] のリストに表示されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-286">You should now see your app appear in the Start Menu's "All Apps" list, with the correct information from the `.resw` / `.pri` file.</span></span> <span data-ttu-id="24c20-287">空の文字列または `ms-resource:...` の文字列が表示された場合には、何かが間違っています。編集を再度確認し、すべて正しいかどうか確認します。</span><span class="sxs-lookup"><span data-stu-id="24c20-287">If you see a blank string or the string `ms-resource:...` then something has gone wrong - double check your edits and make sure they're correct.</span></span> <span data-ttu-id="24c20-288">スタート メニューでアプリを右クリックすると、タイルとしてピン留めすることができ、さらに適切な情報が表示されることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-288">If you right-click on your app in the Start Menu, you can Pin it as a tile and verify the correct information is displayed there also.</span></span>

### <a name="step-13-add-more-supported-languages"></a><span data-ttu-id="24c20-289">手順 1.3:サポートされている複数の言語を追加します。</span><span class="sxs-lookup"><span data-stu-id="24c20-289">Step 1.3: Add more supported languages</span></span>

<span data-ttu-id="24c20-290">パッケージ マニフェストと、最初に、変更を加えた後`resources.resw`ファイルが作成されたら、その他の言語の追加は簡単です。</span><span class="sxs-lookup"><span data-stu-id="24c20-290">After the changes have been made to the package manifest and the initial `resources.resw` file has been created, adding additional languages is easy.</span></span>

#### <a name="create-additional-localized-resources"></a><span data-ttu-id="24c20-291">追加のローカライズ リソースを作成する</span><span class="sxs-lookup"><span data-stu-id="24c20-291">Create additional localized resources</span></span>

<span data-ttu-id="24c20-292">最初に、追加のローカライズ リソースの値を作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-292">First, create the additional localized resource values.</span></span> 

<span data-ttu-id="24c20-293">`Strings` フォルダーで、適切な BCP-47 コードを使って、サポートする各言語のための、追加のフォルダーを作成します (たとえば、`Strings\de-DE`)。</span><span class="sxs-lookup"><span data-stu-id="24c20-293">Within the `Strings` folder, create additional folders for each language you support using the appropriate BCP-47 code (for example, `Strings\de-DE`).</span></span> <span data-ttu-id="24c20-294">各フォルダー内に、(XML エディターまたは Visual Studio デザイナーを使用して) 翻訳されたリソースの値を含む `resources.resw` ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-294">Within each of these folders, create a `resources.resw` file (using either an XML editor or the Visual Studio designer) that includes the translated resource values.</span></span> <span data-ttu-id="24c20-295">ここでは、既にローカライズされた文字列が利用可能であり、それを `.resw` ファイルにコピーして利用できるものと想定します。このドキュメントでは、翻訳の手順そのものは扱いません。</span><span class="sxs-lookup"><span data-stu-id="24c20-295">It is assumed you already have the localized strings available somewhere, and you just need to copy them into the `.resw` file; this document does not cover the translation step itself.</span></span> 

<span data-ttu-id="24c20-296">たとえば、`Strings\de-DE\resources.resw`ファイルは、次のようになります。<span style="background-color: yellow">強調表示されたテキスト</span>は `en-US` から変更されました。</span><span class="sxs-lookup"><span data-stu-id="24c20-296">For example, the `Strings\de-DE\resources.resw` file might look like this, with the <span style="background-color: yellow">highlighted text</span> changed from `en-US`:</span></span>

```xml
<?xml version="1.0" encoding="utf-8"?>
<root>
  <data name="ApplicationDescription">
    <value>Contoso Demo app with localized resources (German)</value>
  </data>
  <data name="ApplicationDisplayName">
    <value>Contoso Demo Sample (German)</value>
  </data>
  <data name="PackageDisplayName">
    <value>Contoso Demo Package (German)</value>
  </data>
  <data name="PublisherDisplayName">
    <value>Contoso Samples, DE</value>
  </data>
  <data name="TileShortName">
    <value>Contoso (DE)</value>
  </data>
</root>
```

<span data-ttu-id="24c20-297">次の手順では、`de-DE` と `fr-FR` の両方のリソースを追加したものと想定します。他の言語でも同じパターンで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-297">The following steps assume you added resources for both `de-DE` and `fr-FR`, but the same pattern can be followed for any language.</span></span>

#### <a name="update-the-package-manifest-to-list-supported-languages"></a><span data-ttu-id="24c20-298">パッケージ マニフェストの言語のサポートされている一覧を更新します。</span><span class="sxs-lookup"><span data-stu-id="24c20-298">Update the package manifest to list supported languages</span></span>

<span data-ttu-id="24c20-299">パッケージ マニフェストは、アプリによって言語がサポートされている一覧を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-299">The package manifest must be updated to list the languages supported by the app.</span></span> <span data-ttu-id="24c20-300">Desktop App Converter は、既定の言語を追加しますが、他の言語は明示的に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-300">The Desktop App Converter adds the default language, but the others must be added explicitly.</span></span> <span data-ttu-id="24c20-301">`AppxManifest.xml` ファイルを直接編集する場合、`Resources` ノードを次のように更新します。必要な要素を追加し、<span style="background-color: yellow">サポートする適切な言語</span>を置き換え、一覧の最初のエントリが既定の (フォールバック) 言語となるようにします。</span><span class="sxs-lookup"><span data-stu-id="24c20-301">If you're editing the `AppxManifest.xml` file directly, update the `Resources` node as follows, adding as many elements as you need, and substituting the <span style="background-color: yellow">appropriate languages you support</span> and making sure the first entry in the list is the default (fallback) language.</span></span> <span data-ttu-id="24c20-302">この例では、既定値は英語 (米国) で、ドイツ語 (ドイツ)、フランス語 (フランス) が追加でサポートされます。</span><span class="sxs-lookup"><span data-stu-id="24c20-302">In this example, the default is English (US) with additional support for both German (Germany) and French (France):</span></span>

```xml
<Resources>
  <Resource Language="EN-US" />
  <Resource Language="DE-DE" />
  <Resource Language="FR-FR" />
</Resources>
```

<span data-ttu-id="24c20-303">Visual Studio を使っている場合、何もする必要はありません。`Package.appxmanifest` には、特別な <span style="background-color: yellow">x-generate</span> 値が含まれます。これによってビルド プロセスで、プロジェクトに含まれる (BCP-47 コードを使った名前のフォルダーに基づく) 言語が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-303">If you are using Visual Studio, you shouldn't need to do anything; if you look at `Package.appxmanifest` you should see the special <span style="background-color: yellow">x-generate</span> value, which causes the build process to insert the languages it finds in your project (based on the folders named with BCP-47 codes).</span></span> <span data-ttu-id="24c20-304">実際のパッケージ マニフェストの有効な値ではないことに注意してください。Visual Studio プロジェクトでのみ動作します。</span><span class="sxs-lookup"><span data-stu-id="24c20-304">Note that this is not a valid value for a real package manifest; it only works for Visual Studio projects:</span></span>

```xml
<Resources>
  <Resource Language="x-generate" />
</Resources>
```

#### <a name="re-build-with-the-localized-values"></a><span data-ttu-id="24c20-305">ローカライズされた値でリビルドする</span><span class="sxs-lookup"><span data-stu-id="24c20-305">Re-build with the localized values</span></span>

<span data-ttu-id="24c20-306">ここで再度、アプリケーションのビルドを行ってデプロイすることができます。Windows で言語の選択を変更すると、新たにローカライズされた値がスタート メニューに表示されます (言語を変更する方法については、以下で説明します)。</span><span class="sxs-lookup"><span data-stu-id="24c20-306">Now you can build and deploy your application, again, and if you change your language preference in Windows you should see the newly-localized values appear in the Start menu (instructions for how to change your language are below).</span></span>

<span data-ttu-id="24c20-307">ここでも、Visual Studio では `Ctrl+Shift+B` を使ってビルドを行い、プロジェクトで右クリックして `Deploy` できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-307">For Visual Studio, again you can just use `Ctrl+Shift+B` to build, and right-click the project to `Deploy`.</span></span>

<span data-ttu-id="24c20-308">プロジェクトを手動でビルドする場合は、上記と同じ手順に従いますが、構成ファイルを作成する際に、既定の修飾子の一覧 (`/dq`) にアンダー スコアで区切られた追加の言語を追加します。</span><span class="sxs-lookup"><span data-stu-id="24c20-308">If you're manually building the project, follow the same steps as above but add the additional languages, separated by underscores, to the default qualifiers list (`/dq`) when creating the configuration file.</span></span> <span data-ttu-id="24c20-309">たとえば、前の手順で追加された、英語、ドイツ語、フランス語のリソースをサポートするには:</span><span class="sxs-lookup"><span data-stu-id="24c20-309">For example, to support the English, German, and French resources added in the previous step:</span></span>

```CMD
makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_fr-FR /pv 10.0 /o
```

<span data-ttu-id="24c20-310">これにより、指定されたすべての言語を含む PRI ファイルが作成され、それをテスト用に簡単に使用できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-310">This will create a PRI file that contains all the specified languagesthat you can easily use for testing.</span></span> <span data-ttu-id="24c20-311">リソースの合計サイズが小さい場合、または少数の言語のみをサポートする場合は、配布するアプリとしてこれで十分である場合もあります。リソースのインストールとダウンロードのサイズを最小化するメリットを必要とする場合のみ、言語ごとの個別の言語パックをビルドする追加の作業を行います。</span><span class="sxs-lookup"><span data-stu-id="24c20-311">If the total size of your resources is small, or you only support a small number of languages, this might be acceptable for your shipping app; it's only if you want the benefits of minimizing install / download size for your resources that you need to do the additional work of building separate language packs.</span></span>

#### <a name="test-with-the-localized-values"></a><span data-ttu-id="24c20-312">ローカライズされた値をテストする</span><span class="sxs-lookup"><span data-stu-id="24c20-312">Test with the localized values</span></span>

<span data-ttu-id="24c20-313">新しくローカライズされた変更をテストするには、使用する新しい UI 言語を Windows に追加します。</span><span class="sxs-lookup"><span data-stu-id="24c20-313">To test the new localized changes, you simply add a new preferred UI language to Windows.</span></span> <span data-ttu-id="24c20-314">言語パックをダウンロードしたり、システムを再起動したり、Windows UI 全体を他言語で表示させたりする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="24c20-314">There is no need to download language packs, reboot the system, or have your entire Windows UI appear in a foreign language.</span></span> 

1. <span data-ttu-id="24c20-315">`Settings` アプリを実行します (`Windows + I`)</span><span class="sxs-lookup"><span data-stu-id="24c20-315">Run the `Settings` app (`Windows + I`)</span></span>
2. <span data-ttu-id="24c20-316">行きます `Time & language`</span><span class="sxs-lookup"><span data-stu-id="24c20-316">Go to `Time & language`</span></span>
3. <span data-ttu-id="24c20-317">行きます `Region & language`</span><span class="sxs-lookup"><span data-stu-id="24c20-317">Go to `Region & language`</span></span>
4. <span data-ttu-id="24c20-318">をクリックします。 `Add a language`</span><span class="sxs-lookup"><span data-stu-id="24c20-318">Click `Add a language`</span></span>
5. <span data-ttu-id="24c20-319">必要な言語を入力 (または選択) します (たとえば `Deutsch` または `German`)</span><span class="sxs-lookup"><span data-stu-id="24c20-319">Type (or select) the language you want (eg `Deutsch` or `German`)</span></span>
 * <span data-ttu-id="24c20-320">サブ言語がある場合は、必要なものを選びます (たとえば `Deutsch / Deutschland`)</span><span class="sxs-lookup"><span data-stu-id="24c20-320">If there are sub-languages, choose the one you want (eg, `Deutsch / Deutschland`)</span></span>
6. <span data-ttu-id="24c20-321">言語の一覧で新しい言語を選択します</span><span class="sxs-lookup"><span data-stu-id="24c20-321">Select the new language in the language list</span></span>
7. <span data-ttu-id="24c20-322">をクリックします。 `Set as default`</span><span class="sxs-lookup"><span data-stu-id="24c20-322">Click `Set as default`</span></span>

<span data-ttu-id="24c20-323">スタート メニューを開き、作成したアプリケーションを検索します。選択した言語のローカライズされた値が表示されます (他のアプリもローカライズされて表示される場合があります)。</span><span class="sxs-lookup"><span data-stu-id="24c20-323">Now open the Start menu and search for your application, and you should see the localized values for the selected language (other apps might also appear localized).</span></span> <span data-ttu-id="24c20-324">ローカライズされた名前がすぐに表示されない場合は、スタート メニューのキャッシュが更新されるまで、数分待機します。</span><span class="sxs-lookup"><span data-stu-id="24c20-324">If you don't see the localized name right away, wait a few minutes until the Start Menu's cache is refreshed.</span></span> <span data-ttu-id="24c20-325">元の言語に戻すには、言語の一覧で既定の言語を変更します。</span><span class="sxs-lookup"><span data-stu-id="24c20-325">To return to your native language, just make it the default language in the language list.</span></span> 

### <a name="step-14-localizing-more-parts-of-the-package-manifest-optional"></a><span data-ttu-id="24c20-326">手順 1.4:(省略可能) パッケージ マニフェストの他のパーツをローカライズします。</span><span class="sxs-lookup"><span data-stu-id="24c20-326">Step 1.4: Localizing more parts of the package manifest (optional)</span></span>

<span data-ttu-id="24c20-327">パッケージ マニフェストの他のセクションをローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-327">Other sections of the package manifest can be localized.</span></span> <span data-ttu-id="24c20-328">たとえば、アプリがファイル拡張子を処理する場合、マニフェストに `windows.fileTypeAssociation` 拡張があります。<span style="background-color: lightgreen">緑の強調表示のテキスト</span>を表示されているとおりに使い (これはリソースの参照です)、<span style="background-color: yellow">黄色の強調表示のテキスト</span>をアプリに固有の情報で置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24c20-328">For example, if your application handles file-extensions then it should have a `windows.fileTypeAssociation` extension in the manifest, using the <span style="background-color: lightgreen">green highlighted text</span> exactly as shown (since it will refer to resources), and replacing the <span style="background-color: yellow">yellow highlighted text</span> with information specific to your application:</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.fileTypeAssociation">
    <uap:FileTypeAssociation Name="default">
      <uap:DisplayName>ms-resource:Resources/FileTypeDisplayName</uap:DisplayName>
      <uap:Logo>Assets\StoreLogo.png</uap:Logo>
      <uap:InfoTip>ms-resource:Resources/FileTypeInfoTip</uap:InfoTip>
      <uap:SupportedFileTypes>
        <uap:FileType ContentType="application/x-contoso">.contoso</uap:FileType>
      </uap:SupportedFileTypes>
    </uap:FileTypeAssociation>
  </uap:Extension>
</Extensions>
```

<span data-ttu-id="24c20-329">Visual Studio のマニフェスト デザイナーを使って、この情報を追加することもできます。`Declarations` タブを使い、<span style="background-color: lightgreen">強調表示の値</span>を記録します。</span><span class="sxs-lookup"><span data-stu-id="24c20-329">You can also add this information using the Visual Studio Manifest Designer, using the `Declarations` tab, taking note of the <span style="background-color: lightgreen">highlighted values</span>:</span></span>

<p><img src="images\editing-declarations-info.png"/></p>

<span data-ttu-id="24c20-330">対応するリソース名を、各 `.resw` ファイルに追加し、<span style="background-color: yellow">強調表示のテキスト</span>をアプリに適切なテキストで置き換えます (*サポートされているそれぞれの言語*で行います)。</span><span class="sxs-lookup"><span data-stu-id="24c20-330">Now add the corresponding resource names to each of your `.resw` files, replacing the <span style="background-color: yellow">highlighted text</span> with the appropriate text for your app (remember to do this for *each supported language!*):</span></span>

```xml
... existing content...
<data name="FileTypeDisplayName">
  <value>Contoso Demo File</value>
</data>
<data name="FileTypeInfoTip">
  <value>Files used by Contoso Demo App</value>
</data>
```

<span data-ttu-id="24c20-331">これは、エクスプローラーなどの Windows シェルの一部で表示されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-331">This will then show up in parts of the Windows shell, such as File Explorer:</span></span>

<p><img src="images\file-type-tool-tip.png"/></p>

<span data-ttu-id="24c20-332">再び、ビルドを行い、パッケージをテストして、新しい UI 文字列が表示される新しいシナリオを試します。</span><span class="sxs-lookup"><span data-stu-id="24c20-332">Build and test the package as before, exercising any new scenarios that should show the new UI strings.</span></span>

## <a name="phase-2-use-mrt-to-identify-and-locate-resources"></a><span data-ttu-id="24c20-333">フェーズ 2:MRT を使ってリソースを識別して検索する</span><span class="sxs-lookup"><span data-stu-id="24c20-333">Phase 2: Use MRT to identify and locate resources</span></span>

<span data-ttu-id="24c20-334">前のセクションでは、MRT を使用してアプリのマニフェスト ファイルをローカライズする方法を紹介しました。これによって、Windows シェルに、アプリの名前とその他のメタデータを正しく表示できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="24c20-334">The previous section showed how to use MRT to localize your app's manifest file so that the Windows Shell can correctly display the app's name and other metadata.</span></span> <span data-ttu-id="24c20-335">これにはコードの変更は必要なく、`.resw` ファイルとその他のいくつかのツールのみを必要としました。</span><span class="sxs-lookup"><span data-stu-id="24c20-335">No code changes were required for this; it simply required the use of `.resw` files and some additional tools.</span></span> <span data-ttu-id="24c20-336">このセクションでは、MRT を使用して、既存のリソース形式のリソースを検索し、既存のリソース処理コードを最小限の変更で使用する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="24c20-336">This section will show how to use MRT to locate resources in your existing resource formats and using your existing resource-handling code with minimal changes.</span></span>

### <a name="assumptions-about-existing-file-layout--application-code"></a><span data-ttu-id="24c20-337">既存のファイル レイアウトとアプリケーションのコードについての想定</span><span class="sxs-lookup"><span data-stu-id="24c20-337">Assumptions about existing file layout & application code</span></span>

<span data-ttu-id="24c20-338">Win32 デスクトップ アプリをローカライズする方法は多数あるため、このホワイトペーパーでは、既存のアプリケーションの構造について、いつかの簡単な想定を置きます。この想定と実際のアプリの環境をマッピングしながら利用してください。</span><span class="sxs-lookup"><span data-stu-id="24c20-338">Because there are many ways to localize Win32 Desktop apps, this paper will make some simplifying assumptions about the existing application's structure that you will need to map to your specific environment.</span></span> <span data-ttu-id="24c20-339">MRT の要件に準拠するため、既存のコードベースやリソース レイアウトを変更する必要がある場合があります。それらの多くは、このドキュメントの対象範囲外となります。</span><span class="sxs-lookup"><span data-stu-id="24c20-339">You might need to make some changes to your existing codebase or resource layout to conform to the requirements of MRT, and those are largely out of scope for this document.</span></span>

#### <a name="resource-file-layout"></a><span data-ttu-id="24c20-340">リソース ファイルのレイアウト</span><span class="sxs-lookup"><span data-stu-id="24c20-340">Resource file layout</span></span>

<span data-ttu-id="24c20-341">この記事では、すべてのローカライズされたリソースは、同じファイル名がある前提としています (例:`contoso_demo.exe.mui`または`contoso_strings.dll`または`contoso.strings.xml`) BCP 47 の名前を持つ別のフォルダーに配置されますが、(`en-US`、`de-DE`など。)。</span><span class="sxs-lookup"><span data-stu-id="24c20-341">This article assumes your localized resources all have the same filenames (eg, `contoso_demo.exe.mui` or `contoso_strings.dll` or `contoso.strings.xml`) but that they are placed in different folders with BCP-47 names (`en-US`, `de-DE`, etc.).</span></span> <span data-ttu-id="24c20-342">問題があるリソース ファイルの数、その名前とは、どのようなファイルの形式ではありませんが、/Api が関連付けられているなど。すべての重要なことだけ*論理*リソースが同じファイル名 (別の配置が*物理*ディレクトリ)。</span><span class="sxs-lookup"><span data-stu-id="24c20-342">It doesn't matter how many resource files you have, what their names are, what their file-formats / associated APIs are, etc. The only thing that matters is that every *logical* resource has the same filename (but placed in a different *physical* directory).</span></span> 

<span data-ttu-id="24c20-343">反対の例として、アプリケーションがフラットなファイル構造を使用していて、1 つの `Resources` ディレクトリに、`english_strings.dll` と `french_strings.dll` が含まれている場合には、これは MRT にうまくマッピングされません。</span><span class="sxs-lookup"><span data-stu-id="24c20-343">As a counter-example, if your application uses a flat file-structure with a single `Resources` directory containing the files `english_strings.dll` and `french_strings.dll`, it would not map well to MRT.</span></span> <span data-ttu-id="24c20-344">望ましい構造は、`Resources` ディレクトリにサブディレクトリがあり、そこにファイルが配置されている (たとえば `en\strings.dll` や `fr\strings.dll`) 構造です。</span><span class="sxs-lookup"><span data-stu-id="24c20-344">A better structure would be a `Resources` directory with subdirectories and files `en\strings.dll` and `fr\strings.dll`.</span></span> <span data-ttu-id="24c20-345">`strings.lang-en.dll` や `strings.lang-fr.dll` などのように、同じ基本ファイル名を使用して、修飾子を埋め込むことも可能ですが、言語コードと同じディレクトリの使用がコンセプトとしてシンプルであり、ここではそれを使います。</span><span class="sxs-lookup"><span data-stu-id="24c20-345">It's also possible to use the same base filename but with embedded qualifiers, such as `strings.lang-en.dll` and `strings.lang-fr.dll`, but using directories with the language codes is conceptually simpler so it's what we'll focus on.</span></span>

>[!NOTE]
> <span data-ttu-id="24c20-346">名前付け規則です。 このファイルを利用できない場合でも、MRT およびパッケージ化の利点を使用することも可能になります多くの作業が必要です。</span><span class="sxs-lookup"><span data-stu-id="24c20-346">It is still possible to use MRT and the benefits of packaging even if you can't follow this file naming convention; it just requires more work.</span></span>

<span data-ttu-id="24c20-347">たとえば、アプリケーションが、<span style="background-color: yellow">ui.txt</span> という名前の単純なテキスト ファイルに含まれる、(ボタンのラベルなどに使用される) カスタムの UI コマンドのセットを持ち、<span style="background-color: yellow">UICommands</span> フォルダーの下に配置される場合があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-347">For example, the application might have a set of custom UI commands (used for button labels etc.) in a simple text file named <span style="background-color: yellow">ui.txt</span>, laid out under a <span style="background-color: yellow">UICommands</span> folder:</span></span>

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

#### <a name="resource-loading-code"></a><span data-ttu-id="24c20-348">リソースの読み込みコード</span><span class="sxs-lookup"><span data-stu-id="24c20-348">Resource loading code</span></span>

<span data-ttu-id="24c20-349">この記事では、ローカライズされたリソースを含むファイルを読み込んでしてそれを使用するコードのある時点で仮定します。</span><span class="sxs-lookup"><span data-stu-id="24c20-349">This article assumes that at some point in your code you want to locate the file that contains a localized resource, load it, and then use it.</span></span> <span data-ttu-id="24c20-350">リソースを読み込むために使用する API や、リソースを抽出するために使用する API などは重要ではありません。</span><span class="sxs-lookup"><span data-stu-id="24c20-350">The APIs used to load the resources, the APIs used to extract the resources, etc. are not important.</span></span> <span data-ttu-id="24c20-351">この疑似コードでは、基本的に 3 つの手順があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-351">In pseudocode, there are basically three steps:</span></span>

<blockquote>
<pre>
set userLanguage = GetUsersPreferredLanguage()
set resourceFile = FindResourceFileForLanguage(MY_RESOURCE_NAME, userLanguage)
set resource = LoadResource(resourceFile) 
    
// now use 'resource' however you want
</pre>
</blockquote>

<span data-ttu-id="24c20-352">MRT では、このプロセスの最初の 2 つの手順のみを変更する必要があります。つまり、必要なリソース候補の決定と、その検索です。</span><span class="sxs-lookup"><span data-stu-id="24c20-352">MRT only requires changing the first two steps in this process - how you determine the best candidate resources and how you locate them.</span></span> <span data-ttu-id="24c20-353">リソースの読み込みと使用については、変更する必要はありません (ただし、それらを活用する場合は、それを行える機能を提供しています)。</span><span class="sxs-lookup"><span data-stu-id="24c20-353">It doesn't require you to change how you load or use the resources (although it provides facilities for doing that if you want to take advantage of them).</span></span>

<span data-ttu-id="24c20-354">たとえば、アプリケーションは、Win32 API `GetUserPreferredUILanguages`、CRT 関数 `sprintf`、Win32 API `CreateFile` を使用して、上記の 3 つの疑似コードの関数を置き換え、次にテキスト ファイルを手動で解析して、`name=value` のペアを検索できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-354">For example, the application might use the Win32 API `GetUserPreferredUILanguages`, the CRT function `sprintf`, and the Win32 API `CreateFile` to replace the three pseudocode functions above, then manually parse the text file looking for `name=value` pairs.</span></span> <span data-ttu-id="24c20-355">(この詳細は重要ではありません。MRT は、リソースが検索された後の、リソースの処理に使用する手法には影響がないことを示すために説明しました)。</span><span class="sxs-lookup"><span data-stu-id="24c20-355">(The details are not important; this is merely to illustrate that MRT has no impact on the techniques used to handle resources once they have been located).</span></span>

### <a name="step-21-code-changes-to-use-mrt-to-locate-files"></a><span data-ttu-id="24c20-356">手順 2.1:MRT を使用してファイルを検索するコードの変更</span><span class="sxs-lookup"><span data-stu-id="24c20-356">Step 2.1: Code changes to use MRT to locate files</span></span>

<span data-ttu-id="24c20-357">リソースの検索に MRT を使用するため、コードを切り替えることは難しくはありません。</span><span class="sxs-lookup"><span data-stu-id="24c20-357">Switching your code to use MRT for locating resources is not difficult.</span></span> <span data-ttu-id="24c20-358">いくつかの WinRT の種類と数行のコードを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-358">It requires using a handful of WinRT types and a few lines of code.</span></span> <span data-ttu-id="24c20-359">主に使用される種類は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="24c20-359">The main types that you will use are as follows:</span></span>

* <span data-ttu-id="24c20-360">[ResourceContext](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext) 現在アクティブな修飾子の値のセット (言語、スケール ファクターなど) をカプセル化します</span><span class="sxs-lookup"><span data-stu-id="24c20-360">[ResourceContext](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext), which encapsulates the currently active set of qualifier values (language, scale factor, etc.)</span></span>
* <span data-ttu-id="24c20-361">[ResourceManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemanager) (.NETバージョンではなく、WinRT バージョン) PRI ファイルからすべてのリソースへのアクセスを実現します</span><span class="sxs-lookup"><span data-stu-id="24c20-361">[ResourceManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemanager) (the WinRT version, not the .NET version), which enables access to all the resources from the PRI file</span></span>
* <span data-ttu-id="24c20-362">[ResourceMap](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemap) PRI ファイル内のリソースの特定のサブセット (この例では、文字列リソースではなく、ファイル ベースのリソース) を表します</span><span class="sxs-lookup"><span data-stu-id="24c20-362">[ResourceMap](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemap), which represents a specific subset of the resources in the PRI file (in this example, the file-based resources vs. the string resources)</span></span>
* <span data-ttu-id="24c20-363">[NamedResource](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource) 論理リソースとそのすべての候補を表します</span><span class="sxs-lookup"><span data-stu-id="24c20-363">[NamedResource](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource), which represents a logical resource and all its possible candidates</span></span>
* <span data-ttu-id="24c20-364">[ResourceCandidate](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcecandidate) 1 つの具体的な候補リソースを表す</span><span class="sxs-lookup"><span data-stu-id="24c20-364">[ResourceCandidate](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcecandidate), which represents a single concrete candidate resource</span></span> 

<span data-ttu-id="24c20-365">あるリソースのファイル名 (たとえば、上のサンプルの `UICommands\ui.txt` など) を解決する方法は、疑似コードでは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="24c20-365">In pseudo-code, the way you would resolve a given resource file name (like `UICommands\ui.txt` in the sample above) is as follows:</span></span>

<blockquote>
<pre>
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
</blockquote>
</pre>

<span data-ttu-id="24c20-366">このコードでは、(実際のディスク上のファイルの配置にかかわらず) 特定の言語のフォルダー (`UICommands\en-US\ui.txt` など) を要求して**いない**ことに、特に注意してください。</span><span class="sxs-lookup"><span data-stu-id="24c20-366">Note in particular that the code does **not** request a specific language folder - like `UICommands\en-US\ui.txt` - even though that is how the files exist on-disk.</span></span> <span data-ttu-id="24c20-367">代わりに*論理*ファイル名 `UICommands\ui.txt` を要求して、ディスク上の言語ディレクトリからの適切なファイルの選択を MRT に依存しています。</span><span class="sxs-lookup"><span data-stu-id="24c20-367">Instead, it asks for the *logical* filename `UICommands\ui.txt` and relies on MRT to find the appropriate on-disk file in one of the language directories.</span></span>

<span data-ttu-id="24c20-368">これ以降、サンプル アプリは以前と同様に、`CreateFile` を使って `absoluteFileName` を読み込み、`name=value` ペアを解析できます。アプリ内のロジックの変更はまったく必要ありません。</span><span class="sxs-lookup"><span data-stu-id="24c20-368">From here, the sample app could continue to use `CreateFile` to load the `absoluteFileName` and parse the `name=value` pairs just as before; none of that logic needs to change in the app.</span></span> <span data-ttu-id="24c20-369">C# または C++/CX で記述している場合、実際のコードは、この擬似コード以上にそれほど複雑になることはありません (さらに多くの中間変数は省略できます)。下記の **.NET リソースを読み込む**のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-369">If you are writing in C# or C++/CX, the actual code is not much more complicated than this (and in fact many of the intermediate variables can be elided) - see the section on **Loading .NET resources**, below.</span></span> <span data-ttu-id="24c20-370">C++/WRL ベースのアプリケーションでは、WinRT API のアクティブ化と呼び出しに使用される低レベルの COM ベースの API によってより複雑になりますが、基本的な手順は同じです。下記の **Win32 MUI リソースを読み込む**のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24c20-370">C++/WRL-based applications will be more complex due to the low-level COM-based APIs used to activate and call the WinRT APIs, but the fundamental steps you take are the same - see the section on **Loading Win32 MUI resources**, below.</span></span>

#### <a name="loading-net-resources"></a><span data-ttu-id="24c20-371">.NET リソースを読み込む</span><span class="sxs-lookup"><span data-stu-id="24c20-371">Loading .NET resources</span></span>

<span data-ttu-id="24c20-372">.NET には、リソースを検索して読み込むための組み込みのメカニズム (「サテライト アセンブリ」と呼ばれます) があるため、上記の合成の例のように、明示的なコードの置き換えは必要ありません.NET では、適切なディレクトリにリソース DLL が存在することのみが必要であり、それらは自動的に検索されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-372">Because .NET has a built-in mechanism for locating and loading resources (known as "Satellite Assemblies"), there is no explicit code to replace as in the synthetic example above - in .NET you just need your resource DLLs in the appropriate directories and they are automatically located for you.</span></span> <span data-ttu-id="24c20-373">アプリは、MSIX としてパッケージ化または AppX リソース パックを使用して、ディレクトリ構造は若干異なるのではなくリソース ディレクトリは、メイン アプリケーション ディレクトリのサブディレクトリとそのピア (またはされるに存在しない場合、すべてのユーザー言語一覧に示された、ユーザー設定)。</span><span class="sxs-lookup"><span data-stu-id="24c20-373">When an app is packaged as an MSIX or AppX using resource packs, the directory structure is somewhat different - rather than having the resource directories be subdirectories of the main application directory, they are peers of it (or not present at all if the user doesn't have the language listed in their preferences).</span></span> 

<span data-ttu-id="24c20-374">たとえば、次のレイアウトを持つ .NET アプリケーションを考えます。ここでは、すべてのファイルが `MainApp` フォルダーの下に存在しています。</span><span class="sxs-lookup"><span data-stu-id="24c20-374">For example, imagine a .NET application with the following layout, where all the files exist under the `MainApp` folder:</span></span>

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

<span data-ttu-id="24c20-375">AppX への変換後、レイアウトはこのようになります。ここでは、`en-US` が既定の言語で、言語リストにドイツ語とフランス語が記載されています。</span><span class="sxs-lookup"><span data-stu-id="24c20-375">After conversion to AppX, the layout will look something like this, assuming `en-US` was the default language and the user has both German and French listed in their language list:</span></span>

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

<span data-ttu-id="24c20-376">ローカライズ リソースが、メイン実行可能ファイルのインストール場所の下のサブディレクトリに存在しないため、組み込みの .NET リソースの解決が失敗します。</span><span class="sxs-lookup"><span data-stu-id="24c20-376">Because the localized resources no longer exist in sub-directories underneath the main executable's install location, the built-in .NET resource resolution fails.</span></span> <span data-ttu-id="24c20-377">さいわい、.NET は、失敗したアセンブリの読み込みの試行を処理するための、明確に定義されたメカニズムである、`AssemblyResolve` イベントを備えています。</span><span class="sxs-lookup"><span data-stu-id="24c20-377">Luckily, .NET has a well-defined mechanism for handling failed assembly load attempts - the `AssemblyResolve` event.</span></span> <span data-ttu-id="24c20-378">MRT を使用する .NET アプリは、このイベントに登録して、見つからなかったアセンブリを .NET リソース サブシステムに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-378">A .NET app using MRT must register for this event and provide the missing assembly for the .NET resource subsystem.</span></span> 

<span data-ttu-id="24c20-379">WinRT API を使用して、.NET で使われるサテライト アセンブリを検索する方法の簡単な例は次のとおりです。このコードは、最小限の実装を示すように、意図的に圧縮されていますが、上記の疑似コードによく対応しています。ここでは、渡されている `ResolveEventArgs` が検索する必要があるアセンブリの名前を提供します。</span><span class="sxs-lookup"><span data-stu-id="24c20-379">A concise example of how to use the WinRT APIs to locate satellite assemblies used by .NET is as follows; the code as-presented is intentionally compressed to show a minimal implementation, although you can see it maps closely to the pseudo-code above, with the passed-in `ResolveEventArgs` providing the name of the assembly we need to locate.</span></span> <span data-ttu-id="24c20-380">このコードの実行可能なバージョン (詳細なコメントとエラー処理を含む) は、[GitHub の **.NET アセンブリ リゾルバー** サンプル](https://aka.ms/fvgqt4) の `PriResourceRsolver.cs` にあります。</span><span class="sxs-lookup"><span data-stu-id="24c20-380">A runnable version of this code (with detailed comments and error-handling) can be found in the file `PriResourceRsolver.cs` in [the **.NET Assembly Resolver** sample on GitHub](https://aka.ms/fvgqt4).</span></span>

```csharp
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

<span data-ttu-id="24c20-381">上記のクラスでは、次のコードを事前にアプリケーションのスタートアップ コードのどこかに (いずれかのローカライズ リソースを読み込む前に) 追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-381">Given the class above, you would add the following somewhere early-on in your application's startup code (before any localized resources would need to load):</span></span>

```csharp
void EnableMrtResourceLookup()
{
  AppDomain.CurrentDomain.AssemblyResolve += PriResourceResolver.ResolveResourceDll;
}
```

<span data-ttu-id="24c20-382">.NET ランタイムは、リソース DLL が見つからない場合には、`AssemblyResolve` イベントを発生させます。その場合、提供されたイベント ハンドラーは、MRT を使って必要なファイルを検索し、アセンブリを返します。</span><span class="sxs-lookup"><span data-stu-id="24c20-382">The .NET runtime will raise the `AssemblyResolve` event whenever it can't find the resource DLLs, at which point the provided event handler will locate the desired file via MRT and return the assembly.</span></span>

> [!NOTE]
> <span data-ttu-id="24c20-383">アプリが既にある場合、`AssemblyResolve`ハンドラーなどの目的に、既存のコードとリソース解決のコードを統合する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-383">If your app already has an `AssemblyResolve` handler for other purposes, you will need to integrate the resource-resolving code with your existing code.</span></span>

#### <a name="loading-win32-mui-resources"></a><span data-ttu-id="24c20-384">Win32 MUI リソースを読み込む</span><span class="sxs-lookup"><span data-stu-id="24c20-384">Loading Win32 MUI resources</span></span>

<span data-ttu-id="24c20-385">Win32 MUI リソースの読み込みは、.NET サテライト アセンブリの読み込みと基本的には同じですが、C++/CX または C++/WRL コードを使います。</span><span class="sxs-lookup"><span data-stu-id="24c20-385">Loading Win32 MUI resources is essentially the same as loading .NET Satellite Assemblies, but using either C++/CX or C++/WRL code instead.</span></span> <span data-ttu-id="24c20-386">C++/CX を使うと、コードがよりシンプルになり、上記の C# にとても近くなりますが、C++ 言語拡張、コンパイラ スイッチ、その他のランタイム オーバーヘッドを使うため、これはあまり望ましくない場合があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-386">Using C++/CX allows for much simpler code that closely matches the C# code above, but it uses C++ language extensions, compiler switches, and additional runtime overheard you might wish to avoid.</span></span> <span data-ttu-id="24c20-387">その場合は、C++/WRL を使うと、コードは冗長になりますが、影響のより小さいソリューションとなります。</span><span class="sxs-lookup"><span data-stu-id="24c20-387">If that is the case, using C++/WRL provides a much lower-impact solution at the cost of more verbose code.</span></span> <span data-ttu-id="24c20-388">それでも、ATL プログラミング (または COM 一般) に慣れている場合には、WRL がなじみやすい選択となります。</span><span class="sxs-lookup"><span data-stu-id="24c20-388">Nevertheless, if you are familiar with ATL programming (or COM in general) then WRL should feel familiar.</span></span> 

<span data-ttu-id="24c20-389">次のサンプル関数は、C++/WRL を使って、特定のリソース DLL を読み込み、`HINSTANCE` を返します。これにより、通常の Win32 リソース API を使って、さらにリソースを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-389">The following sample function shows how to use C++/WRL to load a specific resource DLL and return an `HINSTANCE` that can be used to load further resources using the usual Win32 resource APIs.</span></span> <span data-ttu-id="24c20-390">.NET ランタイムに要求された言語を使って明示的に `ResourceContext` を初期化する C# のサンプルとは異なり、このコードはユーザーの現在の言語に依存しています。</span><span class="sxs-lookup"><span data-stu-id="24c20-390">Note that unlike the C# sample that explicitly initializes the `ResourceContext` with the language requested by the .NET runtime, this code relies on the user's current language.</span></span>

```cpp
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

## <a name="phase-3-building-resource-packs"></a><span data-ttu-id="24c20-391">フェーズ 3:リソース パックの構築</span><span class="sxs-lookup"><span data-stu-id="24c20-391">Phase 3: Building resource packs</span></span>

<span data-ttu-id="24c20-392">これで、すべてのリソースを含む "ファット" パッケージができました。ダウンロードとインストールのサイズを最小化するために、メイン パッケージとリソース パッケージを分離してビルドするには、2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-392">Now that you have a "fat pack" that contains all resources, there are two paths towards building separate main package and resource packages in order to minimize download and install sizes:</span></span>

* <span data-ttu-id="24c20-393">既存のファット パッケージを使い、[Bundle Generator ツール](https://aka.ms/bundlegen)を実行して、自動的にリソース パッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-393">Take an existing fat pack and run it through [the Bundle Generator tool](https://aka.ms/bundlegen) to automatically create resource packs.</span></span> <span data-ttu-id="24c20-394">これは、既にファット パッケージを作成するビルド システムがあり、ポスト プロセスとしてリソース パッケージを生成する場合に、推奨されるアプローチです。</span><span class="sxs-lookup"><span data-stu-id="24c20-394">This is the preferred approach if you have a build system that already produces a fat pack and you want to post-process it to generate the resource packs.</span></span>
* <span data-ttu-id="24c20-395">直接、個々のリソース パッケージを作成し、それらをビルドしてバンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-395">Directly produce the individual resource packages and build them into a bundle.</span></span> <span data-ttu-id="24c20-396">これは、ビルド システムをより細かく制御して、パッケージを直接作成する場合に、推奨されるアプローチです。</span><span class="sxs-lookup"><span data-stu-id="24c20-396">This is the preferred approach if you have more control over your build system and can build the packages directly.</span></span>

### <a name="step-31-creating-the-bundle"></a><span data-ttu-id="24c20-397">手順 3.1:バンドルの作成</span><span class="sxs-lookup"><span data-stu-id="24c20-397">Step 3.1: Creating the bundle</span></span>

#### <a name="using-the-bundle-generator-tool"></a><span data-ttu-id="24c20-398">Bundle Generator ツールを使用する</span><span class="sxs-lookup"><span data-stu-id="24c20-398">Using the Bundle Generator tool</span></span>

<span data-ttu-id="24c20-399">Bundle Generator ツールを使用するには、パッケージ用に作成した PRI 構成ファイルを手動で更新して、`<packaging>` セクションを削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-399">In order to use the Bundle Generator tool, the PRI config file created for the package needs to be manually updated to remove the `<packaging>` section.</span></span>

<span data-ttu-id="24c20-400">Visual Studio を使用している場合を参照してください[リソースがデバイスでの必要かどうかに関係なく、デバイスにインストールされていることを確認](https://docs.microsoft.com/en-us/previous-versions/dn482043(v=vs.140))ファイルを作成して、メインのパッケージにすべての言語を構築する方法については`priconfig.packaging.xml`と`priconfig.default.xml`します。</span><span class="sxs-lookup"><span data-stu-id="24c20-400">If you're using Visual Studio, refer to [Ensure that resources are installed on a device regardless of whether a device requires them](https://docs.microsoft.com/en-us/previous-versions/dn482043(v=vs.140)) for information on how to build all languages into the main package by creating the files `priconfig.packaging.xml` and `priconfig.default.xml`.</span></span>

<span data-ttu-id="24c20-401">ファイルを手動で編集する場合は、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="24c20-401">If you're manually editing files, follow these steps:</span></span> 

1. <span data-ttu-id="24c20-402">正しいパス、ファイル名、言語を置き換えて、以前と同じ方法で構成ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-402">Create the config file the same way as before, substituting the correct path, file name and languages:</span></span>

    ```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_es-MX /pv 10.0 /o
    ```

2. <span data-ttu-id="24c20-403">作成された `.xml` ファイルを手動で開き、`&lt;packaging&rt;` セクション全体を削除します (それ以外はそのまま残します)。</span><span class="sxs-lookup"><span data-stu-id="24c20-403">Manually open the created `.xml` file and delete the entire `&lt;packaging&rt;` section (but keep everything else intact):</span></span>

    ```xml
    <?xml version="1.0" encoding="UTF-8" standalone="yes" ?> 
    <resources targetOsVersion="10.0.0" majorVersion="1">
      <!-- Packaging section has been deleted... -->
      <index root="\" startIndexAt="\">
        <default>
        ...
        ...
    ```

3. <span data-ttu-id="24c20-404">更新された構成ファイルと適切なディレクトリとファイル名を使って、以前と同じ方法で `.pri` ファイルと `.appx` パッケージをビルドします (これらのコマンドについて詳しくは上記をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="24c20-404">Build the `.pri` file and the `.appx` package as before, using the updated configuration file and the appropriate directory and file names (see above for more information on these commands):</span></span>

    ```CMD
    makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o
    makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o
    ```

4. <span data-ttu-id="24c20-405">パッケージが作成された後は、次のコマンドを使用して、適切なディレクトリとファイル名を使用して、バンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-405">AFter the package has been created, use the following command to create the bundle, using the appropriate directory and file names:</span></span>

    ```CMD
    BundleGenerator.exe -Package ..\contoso_demo.appx -Destination ..\bundle -BundleName contoso_demo
    ```

<span data-ttu-id="24c20-406">今すぐ署名 (以下参照)、最後の手順に移動できます。</span><span class="sxs-lookup"><span data-stu-id="24c20-406">Now you can move to the final step, signing (see below).</span></span>

#### <a name="manually-creating-resource-packages"></a><span data-ttu-id="24c20-407">手動でリソース パッケージを作成する</span><span class="sxs-lookup"><span data-stu-id="24c20-407">Manually creating resource packages</span></span>

<span data-ttu-id="24c20-408">リソース パッケージを手動で作成する場合は、やや異なるコマンドのセットを実行して、別の `.pri` ファイルと `.appx` ファイルをビルドする必要があります。これらはすべて、上でファット パッケージの作成に使用したコマンドに似ていますので、簡単な説明にとどめます。</span><span class="sxs-lookup"><span data-stu-id="24c20-408">Manually creating resource packages requires running a slightly different set of commands to build separate `.pri` and `.appx` files - these are all similar to the commands used above to create fat packages, so minimal explanation is given.</span></span> <span data-ttu-id="24c20-409">注:すべてのコマンドは、現在のディレクトリにディレクトリがある前提としています格納している、`AppXManifest.xml`ファイルがすべてのファイルは、(を使用できますの別のディレクトリが必要に応じて、プロジェクト ディレクトリのいずれかを煩雑べきではない場合、親ディレクトリに配置されます。これらのファイル)。</span><span class="sxs-lookup"><span data-stu-id="24c20-409">Note: All the commands assume that the current directory is the directory containing the `AppXManifest.xml` file, but all files are placed into the parent directory (you can use a different directory, if necessary, but you shouldn't pollute the project directory with any of these files).</span></span> <span data-ttu-id="24c20-410">いつもと同様に、"Contoso" のファイル名を独自のファイル名で置き換えます。</span><span class="sxs-lookup"><span data-stu-id="24c20-410">As always, replace the "Contoso" filenames with your own file names.</span></span>

1. <span data-ttu-id="24c20-411">次のコマンドを使用して、既定の言語**のみ**を既定の修飾子として命名する、構成ファイルを作成します。この場合では `en-US` です。</span><span class="sxs-lookup"><span data-stu-id="24c20-411">Use the following command to create a config file that names **only** the default language as the default qualifier - in this case, `en-US`:</span></span>

    ```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o
    ```

2. <span data-ttu-id="24c20-412">次のコマンドを使って、メイン パッケージの既定の `.pri` ファイルと`.map.txt` ファイルを作成し、さらにプロジェクトの各言語の追加のファイルのセットを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-412">Create a default `.pri` and `.map.txt` file for the main package, plus an additional set of files for each language found in your project, with the following command:</span></span>

    ```CMD
    makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o
    ```

3. <span data-ttu-id="24c20-413">次のコマンドを使って、メイン パッケージを作成します (これには実行可能コードと既定の言語リソースが含まれています)。</span><span class="sxs-lookup"><span data-stu-id="24c20-413">Use the following command to create the main package (which contains the executable code and default language resources).</span></span> <span data-ttu-id="24c20-414">いつもと同様に、必要に応じて名前を変更します。後でバンドルの作成が容易になるように、パッケージは別のディレクトリに配置する必要があります (この例では、 `.\bundle` ディレクトリを使います)。</span><span class="sxs-lookup"><span data-stu-id="24c20-414">As always, change the name as you see fit, although you should put the package in a separate directory to make creating the bundle easier later (this example uses the `..\bundle` directory):</span></span>

    ```CMD
    makeappx pack /m .\AppXManifest.xml /f ..\resources.map.txt /p ..\bundle\contoso_demo.main.appx /o
    ```

4. <span data-ttu-id="24c20-415">メイン パッケージが作成されたら、次のコマンドを追加言語ごとに 1 回ずつ使います (つまり、前の手順で生成された各言語マップ ファイルに、このコマンドを繰り返します)。</span><span class="sxs-lookup"><span data-stu-id="24c20-415">After the main package has been created, use the following command once for each additional language (ie, repeat this command for each language map file generated in the previous step).</span></span> <span data-ttu-id="24c20-416">ここでも、出力は別のディレクトリ (メイン パッケージと同じディレクトリ) にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="24c20-416">Again, the output should be in a separate directory (the same one as the main package).</span></span> <span data-ttu-id="24c20-417">言語が `/f` オプションと `/p` オプションの **両方** で指定されていることに注意してください。また、新しい `/r` 引数の使い方 (リソース パッケージが必要であることを指定します) に注意してください。</span><span class="sxs-lookup"><span data-stu-id="24c20-417">Note the language is specified **both** in the `/f` option and the `/p` option, and the use of the new `/r` argument (which indicates a Resource Package is desired):</span></span>

    ```CMD
    makeappx pack /r /m .\AppXManifest.xml /f ..\resources.language-de.map.txt /p ..\bundle\contoso_demo.de.appx /o
    ```

5. <span data-ttu-id="24c20-418">バンドル ディレクトリからのすべてのパッケージをまとめて、1 つの `.appxbundle` ファイルを作成します。</span><span class="sxs-lookup"><span data-stu-id="24c20-418">Combine all the packages from the bundle directory into a single `.appxbundle` file.</span></span> <span data-ttu-id="24c20-419">新しい `/d` オプションは、バンドル内のすべてのファイルが使用するディレクトリを指定します (前の手順で `.appx` ファイルを別のディレクトリに配置したのはこのためです)。</span><span class="sxs-lookup"><span data-stu-id="24c20-419">The new `/d` option specifies the directory to use for all the files in the bundle (this is why the `.appx` files are put into a separate directory in the previous step):</span></span>

    ```CMD
    makeappx bundle /d ..\bundle /p ..\contoso_demo.appxbundle /o
    ```

<span data-ttu-id="24c20-420">パッケージを構築するための最後の手順を署名します。</span><span class="sxs-lookup"><span data-stu-id="24c20-420">The final step to building the package is signing.</span></span>

### <a name="step-32-signing-the-bundle"></a><span data-ttu-id="24c20-421">手順 3.2:バンドルの署名</span><span class="sxs-lookup"><span data-stu-id="24c20-421">Step 3.2: Signing the bundle</span></span>

<span data-ttu-id="24c20-422">(Bundle Generator ツールを使うか、または手動で) `.appxbundle` を作成したら、メイン パッケージとすべてのリソース パッケージを含む、1 つのファイルが作成されます。 </span><span class="sxs-lookup"><span data-stu-id="24c20-422">Once you have created the `.appxbundle` file (either through the Bundle Generator tool or manually) you will have a single file that contains the main package plus all the resource packages.</span></span> <span data-ttu-id="24c20-423">最後の手順は、ファイルに署名を行い、Windows がインストールできるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="24c20-423">The final step is to sign the file so that Windows will install it:</span></span>

```CMD
signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appxbundle
```

<span data-ttu-id="24c20-424">これによって、メイン パッケージとすべての言語固有のリソース パッケージを含む、署名済みの `.appxbundle` ファイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="24c20-424">This will produce a signed `.appxbundle` file that contains the main package plus all the language-specific resource packages.</span></span> <span data-ttu-id="24c20-425">これはパッケージ ファイルと同様にダブルクリックでき、それによって、アプリに加えて、ユーザーの Windows の言語設定に基づく適切な言語をインストールすることができます。</span><span class="sxs-lookup"><span data-stu-id="24c20-425">It can be double-clicked just like a package file to install the app plus any appropriate language(s) based on the user's Windows language preferences.</span></span>

## <a name="related-topics"></a><span data-ttu-id="24c20-426">関連トピック</span><span class="sxs-lookup"><span data-stu-id="24c20-426">Related topics</span></span>

* [<span data-ttu-id="24c20-427">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="24c20-427">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)