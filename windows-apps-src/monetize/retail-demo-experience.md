---
author: joannaleecy
title: 市販デモ エクスペリエンス (RDX) アプリを作成する
description: 単一のアプリで市販デモ モードと通常モードの両方を起動できる市販デモ エクスペリエンス (RDX) アプリの作成
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
ms.author: joanlee
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP, 市販デモ アプリ
ms.localizationpriority: medium
ms.openlocfilehash: 19a22e09484943d63988cef6bb6a7e7c09e016dd
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1691018"
---
#  <a name="create-a-retail-demo-experience-rdx-app"></a><span data-ttu-id="a2f93-104">市販デモ エクスペリエンス (RDX) アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="a2f93-104">Create a Retail Demo Experience (RDX) app</span></span>

<span data-ttu-id="a2f93-105">小売店や小売拠点を訪れるお客様は、展示されている最新の PC や携帯電話を見るためにご来店になります。展示されているこれらのデバイスは、市販デモ デバイスと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-105">When customers walk into a retail store or location, they expect to find the latest PCs and mobile phones on display and these devices on display are known as retail demo devices.</span></span>
<span data-ttu-id="a2f93-106">お客様の多くはかなりの時間をこれらのデバイスの試用に費やすため、このような市販デモ デバイスやそれらにインストールされているコンテンツは、店舗におけるお客様のエクスペリエンスに大きな影響を与えます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-106">Retail demo devices and content installed on them are largely responsible for the customer experience at the stores because customers often spend a considerable chunk of their time playing around with these devices.</span></span>

<span data-ttu-id="a2f93-107">小売店でこれらの PC や携帯電話にインストールするアプリには、市販デモ エクスペリエンス (RDX) アプリを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-107">Apps that are installed on these PCs and mobile phones in the retail stores must be a retail demo experience (RDX) app.</span></span> <span data-ttu-id="a2f93-108">この記事では、小売店で PC や携帯電話のデモ デバイスにインストールする市販デモ バージョンのアプリを設計および開発する方法について概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-108">This article provides an overview of how to design and develop a retail demo version of an app to be installed on PCs and mobile demo devices at a retail store.</span></span>

<span data-ttu-id="a2f93-109">市販デモ エクスペリエンス アプリは、単一のビルドで _通常_モードと_市販_モードの 2 つの異なるモードで起動できます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-109">A retail demo experience app comes in a single build that can be launched in one of the two different modes- _normal_ or _retail_.</span></span>
<span data-ttu-id="a2f93-110">お客様は 2 つのモードが存在することをご存じないため、2 つのバージョンを区別できるように、市販モードで実行されるアプリにはタイトル バーなどの適切な場所に "市販" とわかりやすく表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a2f93-110">From our customers' perspective, there is only one app and to help our customers distinguish between the two versions, it is recommended that your app running in retail mode display the words "Retail" prominently in the title bar or in a suitable location.</span></span>

<span data-ttu-id="a2f93-111">RDX アプリは、ご来店のお客様に常に肯定的なエクスペリエンスを提供できるように、アプリのストア要件に加え、市販デモ デバイスの設定、クリーンアップ、システム更新に完全に対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-111">In addition to the Store requirements for apps, RDX apps must also be fully compatible with the retail demo devices set up, clean up, and update system to ensure that customers have a consistently positive experience at the retail store.</span></span>

## <a name="design-principles"></a><span data-ttu-id="a2f93-112">設計原則</span><span class="sxs-lookup"><span data-stu-id="a2f93-112">Design principles</span></span>

### <a name="show-your-best"></a><span data-ttu-id="a2f93-113">最大のメリットを提示</span><span class="sxs-lookup"><span data-stu-id="a2f93-113">Show your best</span></span>

<span data-ttu-id="a2f93-114">市販デモ モードは、アプリケーションのメリットを伝えるために使ってください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-114">Use the retail demo experience to showcase why your application rocks.</span></span>  <span data-ttu-id="a2f93-115">多くの場合、これはお客様がこのアプリケーションに触れる最初の機会です。最も魅力的な部分をアピールしましょう。</span><span class="sxs-lookup"><span data-stu-id="a2f93-115">This is likely the first time your customer will see your application, so show them the best piece!</span></span>

### <a name="show-it-fast"></a><span data-ttu-id="a2f93-116">スピーディな伝達</span><span class="sxs-lookup"><span data-stu-id="a2f93-116">Show it fast</span></span>

<span data-ttu-id="a2f93-117">お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-117">Customers can be impatient - The faster a user can experience the real value of your app, the better.</span></span>

### <a name="keep-the-story-simple"></a><span data-ttu-id="a2f93-118">シンプルなストーリー</span><span class="sxs-lookup"><span data-stu-id="a2f93-118">Keep the story simple</span></span>

<span data-ttu-id="a2f93-119">市販デモ モードは、ごく限られた時間でアプリの真価を伝えるチャンスであることを常に意識してください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-119">Remember that the retail demo experience is an elevator pitch for your app’s value.</span></span>

### <a name="focus-on-the-experience"></a><span data-ttu-id="a2f93-120">エクスペリエンスを重視</span><span class="sxs-lookup"><span data-stu-id="a2f93-120">Focus on the experience</span></span>

<span data-ttu-id="a2f93-121">お客様がコンテンツを理解する時間を設けましょう。</span><span class="sxs-lookup"><span data-stu-id="a2f93-121">Give the user time to digest your content.</span></span>  <span data-ttu-id="a2f93-122">魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-122">While getting them to the best part fast is important, designing suitable pauses can help them to fully enjoy the experience.</span></span>

## <a name="technical-requirements"></a><span data-ttu-id="a2f93-123">技術的要件</span><span class="sxs-lookup"><span data-stu-id="a2f93-123">Technical requirements</span></span>

<span data-ttu-id="a2f93-124">市販デモ エクスペリエンス アプリは、ご来店のお客様にアプリの真価をご理解いただくことを目的としているため、次の技術的要件を満たすと共に、すべての市販デモ エクスペリエンス アプリに関してストアが定めるプライバシー規則に従うことが重要です。</span><span class="sxs-lookup"><span data-stu-id="a2f93-124">As retail demo experience apps are meant to showcase the best of your app to retail customers, it is essential that they meet these technical requirements and adhere to privacy regulations that the Store has for all retail demo experience apps.</span></span>
<span data-ttu-id="a2f93-125">以下はチェックリストとして利用して、検証プロセスの準備や、テスト プロセスの明確化に役立てることもできます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-125">This can also be used as a checklist to help you prepare for the validation process and to provide clarity in the testing process.</span></span> <span data-ttu-id="a2f93-126">これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-126">Note that these requirements have to be maintained, not just for the validation process, but for the entire lifetime of the retail demo experience app; as long as your app stays running on the retail demo devices.</span></span>

### <a name="critical-level-requirements"></a><span data-ttu-id="a2f93-127">必須レベルの要件</span><span class="sxs-lookup"><span data-stu-id="a2f93-127">Critical level requirements</span></span>

<span data-ttu-id="a2f93-128">これらの必須要件を満たしていない RDX アプリは、可能な限り速やかにすべての市販デモ デバイスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-128">RDX apps that do not meet these critical requirements will be removed from all retail demo devices as soon as possible.</span></span>

* <span data-ttu-id="a2f93-129">個人を特定できる情報 (PII) を尋ねない</span><span class="sxs-lookup"><span data-stu-id="a2f93-129">No asking for Personal Identifiable Information (PII)</span></span>

    <span data-ttu-id="a2f93-130">アプリは、お客様個人を特定できる情報を尋ねてはなりません。</span><span class="sxs-lookup"><span data-stu-id="a2f93-130">The app is not allowed to ask customers for any personal identifiable information.</span></span>  <span data-ttu-id="a2f93-131">これにはすべての Microsoft アカウント情報や詳細な連絡先などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-131">This includes all Microsoft account information, contact details etc.</span></span>

* <span data-ttu-id="a2f93-132">エラーのないエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="a2f93-132">Error free experience</span></span>

    <span data-ttu-id="a2f93-133">アプリは、エラーなしで動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-133">Your app must run with no errors.</span></span> <span data-ttu-id="a2f93-134">また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。</span><span class="sxs-lookup"><span data-stu-id="a2f93-134">Additionally, no error pop ups or notifications should be shown to customers using the retail demo devices.</span></span> <span data-ttu-id="a2f93-135">デモではお客様に製品の魅力をアピールすることが重要であり、エラーがないことはその絶対条件です。</span><span class="sxs-lookup"><span data-stu-id="a2f93-135">This is important as we want to showcase our best to customers and the best should be error free.</span></span>
    <span data-ttu-id="a2f93-136">またエラーによって、アプリ自体、アプリの開発者のブランド、アプリが動作するデバイス、デバイスの製造者、Microsoft のイメージが損なわれます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-136">Another reason is that errors reflect negatively on the app itself, your brand, the device which the app is running on, the device's manufacturer's brand, and Microsoft's brand as well.</span></span>

* <span data-ttu-id="a2f93-137">試用モード (有料アプリの場合)</span><span class="sxs-lookup"><span data-stu-id="a2f93-137">Paid apps must have a Trial mode</span></span>

    <span data-ttu-id="a2f93-138">市販デモ デバイスにアプリをインストールするには、アプリが無料アプリであるか、正式な試用モードを持つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-138">In order for apps to be installed on retail demo devices, your app either needs to be a free app or have an established Trial mode.</span></span>  <span data-ttu-id="a2f93-139">お客様は小売店での試用に料金を支払うことは想定していません。</span><span class="sxs-lookup"><span data-stu-id="a2f93-139">Customers aren't looking to pay for an experience in a retail store.</span></span> <span data-ttu-id="a2f93-140">詳しくは、「[試用版での機能の除外または制限](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-140">For more information, see [Exclude or limit features in a trial version](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)</span></span>

### <a name="high-priority-requirements"></a><span data-ttu-id="a2f93-141">優先度の高い要件</span><span class="sxs-lookup"><span data-stu-id="a2f93-141">High priority requirements</span></span>

<span data-ttu-id="a2f93-142">これらの優先度の高い要件を満たしていない RDX アプリは、直ちに調査して修正する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-142">RDX apps that do not meet these high priority requirements need to be investigated for a fix immediately.</span></span> <span data-ttu-id="a2f93-143">直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-143">If no immediate fix is found, this app may be removed from all retail demo devices.</span></span>

* <span data-ttu-id="a2f93-144">優れたオフライン エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="a2f93-144">Memorable offline experience</span></span>

    <span data-ttu-id="a2f93-145">小売拠点に展示されているデバイスの約 50% がオフラインであるため、市販デモ エクスペリエンス アプリは優れたオフライン エクスペリエンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-145">Your retail demo experience app needs to demonstrate a great offline experience as about 50% of the devices are offline at retail locations.</span></span> <span data-ttu-id="a2f93-146">この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="a2f93-146">This is to ensure that customers interacting with your app offline are still able to have a meaningful and positive experience.</span></span>

* <span data-ttu-id="a2f93-147">更新済みのコンテンツ エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="a2f93-147">Updated content experience</span></span>

    <span data-ttu-id="a2f93-148">優れたエクスペリエンスを提供するためには、アプリがオンラインの場合に、お客様にアプリケーションの更新を求めるメッセージが表示されないように、アプリを常に最新の状態に保つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-148">To deliver a great experience, your app needs to be always up to date and customers should never be prompted for application updates when your app is online.</span></span>

* <span data-ttu-id="a2f93-149">匿名通信の禁止</span><span class="sxs-lookup"><span data-stu-id="a2f93-149">No anonymous communication</span></span>

    <span data-ttu-id="a2f93-150">市販デモ デバイスを使うお客様は匿名ユーザーであるため、デバイスからのメッセージ送信やコンテンツの共有を抑制する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-150">Since a customer using a retail demo device is an anonymous user, they should not be able to message or share content from the device.</span></span>

* <span data-ttu-id="a2f93-151">クリーンアップ処理を利用した一貫したエクスペリエンスの提供</span><span class="sxs-lookup"><span data-stu-id="a2f93-151">Deliver consistent experience by utilizing the clean up process</span></span>

    <span data-ttu-id="a2f93-152">市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-152">Every customer should have the same experience when they walk up to a retail demo device.</span></span> <span data-ttu-id="a2f93-153">前のお客様の操作結果が次のお客様に表示されないように、使用が終了するたびにアプリで[クリーンアップ処理](#clean-up-process)を利用して、同じ既定の状態に戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-153">Your app should utilize [clean up process](#clean-up-process) to return to the same default state after each use as we do not want the next customer to see what the last customer left behind.</span></span>  <span data-ttu-id="a2f93-154">これには、スコアボード、達成度、ロック解除が含まれます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-154">This includes scoreboards, achievements, and unlocks.</span></span>

* <span data-ttu-id="a2f93-155">年齢に応じた適切なコンテンツ</span><span class="sxs-lookup"><span data-stu-id="a2f93-155">Age appropriate content</span></span>

    <span data-ttu-id="a2f93-156">すべての市販デモ エクスペリエンス アプリのコンテンツは、ティーン以下の年齢区分向けでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="a2f93-156">All retail demo experience app content needs to be assigned a Teen or lower rating category.</span></span> <span data-ttu-id="a2f93-157">詳しくは、[アプリの評価に関する IARC のページ](https://www.globalratings.com/for-developers.aspx)および「[ESRB 評価に関するページ](https://www.esrb.org/ratings/ratings_guide.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-157">For more information, see [Getting your app rated by IARC](https://www.globalratings.com/for-developers.aspx) and [ESRB ratings](https://www.esrb.org/ratings/ratings_guide.aspx).</span></span>

### <a name="medium-priority-requirements"></a><span data-ttu-id="a2f93-158">中程度の優先度の要件</span><span class="sxs-lookup"><span data-stu-id="a2f93-158">Medium priority requirements</span></span>

<span data-ttu-id="a2f93-159">Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-159">The Windows Retail Store team may reach out to developers directly to set up a discussion on how to fix these issues.</span></span>

* <span data-ttu-id="a2f93-160">多様なデバイスで正常に動作する能力</span><span class="sxs-lookup"><span data-stu-id="a2f93-160">Ability to run successfully over a range of devices</span></span>

    <span data-ttu-id="a2f93-161">市販デモ エクスペリエンス アプリは、ローエンド仕様のデバイスを含む、すべてのデバイスで適切に動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-161">Retail demo experience apps must run well on all devices, including devices with low-end specifications.</span></span> <span data-ttu-id="a2f93-162">そのアプリで要求される最小限の仕様を満たさないデバイスに市販デモ エクスペリエンス アプリをインストールする場合は、そのことをアプリで明確に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-162">If the retail demo experience app is installed on devices that did not meet the minimum specifications to run the app, the app needs to clearly inform the user about this.</span></span> <span data-ttu-id="a2f93-163">アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-163">Minimum device requirements has to be made known so that the app can always run with high performance.</span></span>

* <span data-ttu-id="a2f93-164">小売店用アプリ サイズ要件への適合</span><span class="sxs-lookup"><span data-stu-id="a2f93-164">Meet retail store app size requirements</span></span>

    <span data-ttu-id="a2f93-165">アプリのサイズは、800 MB 未満である必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-165">The app must be smaller than 800MB.</span></span> <span data-ttu-id="a2f93-166">市販デモ エクスペリエンス アプリがこのサイズ要件を満たしていない場合は、Windows リテール ストア チームに直接お問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-166">Contact the Windows Retail Store team directly for further discussion if your retail demo experience app do not meet the size requirements.</span></span>

## <a name="preparing-codebase-for-retail-demo-mode-development"></a><span data-ttu-id="a2f93-167">市販デモ モード開発用のコードベースの準備</span><span class="sxs-lookup"><span data-stu-id="a2f93-167">Preparing codebase for Retail Demo Mode development</span></span>

<span data-ttu-id="a2f93-168">アプリケーションを_通常_モードと_市販_モードのどちらのコード パスで実行するかを指定するブール インジケーターには、Windows 10 SDK の [Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) 名前空間に含まれる [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo) ユーティリティ クラスの [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-168">The [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) property in the [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo) utility class, which is part of the [Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) namespace in the Windows 10 SDK, is used as a Boolean indicator to specify which code path your application runs on - the _normal_ mode or the _retail_ mode.</span></span>

<span data-ttu-id="a2f93-169">[**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) から true が返されたら、[**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-169">When [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) returns true, you can query for a set of properties about the device using [**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) to build a more customized retail demo experience.</span></span> <span data-ttu-id="a2f93-170">これらのプロパティには、[**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername)、[**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize)、[**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-170">These properties include [**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername), [**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize), [**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) and so on.</span></span>


## <a name="clean-up-process"></a><span data-ttu-id="a2f93-171">クリーンアップ処理</span><span class="sxs-lookup"><span data-stu-id="a2f93-171">Clean up process</span></span>

<span data-ttu-id="a2f93-172">一定時間デバイスの操作がない場合は、クリーンアップ処理を使って市販デモ デバイスを元の既定の設定に自動的にリセットします。</span><span class="sxs-lookup"><span data-stu-id="a2f93-172">The clean up process is used to automatically reset retail demo devices back to original default settings when there is no interaction with the device for fixed duration.</span></span> <span data-ttu-id="a2f93-173">この処理により、小売店でお客様がデバイスの試用を開始するとき、デバイスを操作するすべてのお客様に対して、既定のエクスペリエンスが適切に提供されます。</span><span class="sxs-lookup"><span data-stu-id="a2f93-173">This is to ensure that every user in the retail store can walk up to a device and have the exact default intended experience when interacting with the device.</span></span> <span data-ttu-id="a2f93-174">市販デモ エクスペリエンス アプリの開発にあたっては、クリーンアップ処理を開始するタイミングと方法に加え、既定のクリーンアップ処理で行う動作を理解することが重要です。また目的の市販デモ エクスペリエンスの要件に応じて、このクリーンアップ処理をカスタマイズする方法を把握する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-174">When developing a retail demo experience app, it is important to understand when and how the clean up process is triggered, what happens during the default clean up process, and learn how to customize this clean up process according to the requirements of your intended retail demo experience.</span></span>

### <a name="when-does-clean-up-begin"></a><span data-ttu-id="a2f93-175">クリーンアップ処理を開始するタイミング</span><span class="sxs-lookup"><span data-stu-id="a2f93-175">When does clean up begin?</span></span>

<span data-ttu-id="a2f93-176">クリーンアップ シーケンスは、デバイスのアイドル時間が一定の長さに達した後に開始します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-176">The clean up sequence begins after certain amount of device idle time.</span></span> <span data-ttu-id="a2f93-177">アイドル時間は、タッチ、マウス、デバイス上のキーボード入力がない場合に、カウントを開始します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-177">Idle time begins count when there is no input from touch, mouse, and keyboard on the device.</span></span>

#### <a name="desktoppc"></a><span data-ttu-id="a2f93-178">デスクトップ/PC</span><span class="sxs-lookup"><span data-stu-id="a2f93-178">Desktop/PC</span></span>

<span data-ttu-id="a2f93-179">120 秒のアイドル時間の後、アイドル状態を予告するアプリ ビデオがデバイス上で再生を開始します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-179">After 120 seconds of idle time, the idle attract app video will start playing on the device.</span></span> <span data-ttu-id="a2f93-180">5 秒後、クリーンアップ処理が開始します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-180">5 seconds later, the cleanup process kicks in.</span></span>

#### <a name="phone"></a><span data-ttu-id="a2f93-181">携帯電話</span><span class="sxs-lookup"><span data-stu-id="a2f93-181">Phone</span></span>

<span data-ttu-id="a2f93-182">60 秒のアイドル時間の後、アイドル状態を予告するアプリ ビデオがデバイス上で再生を開始し、即座にクリーンアップ処理が開始します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-182">After 60 seconds of idle time, the idle attract app video will start playing on the device and the cleanup process kicks in immediately.</span></span>

### <a name="what-happens-during-a-default-clean-up-process"></a><span data-ttu-id="a2f93-183">既定のクリーンアップ処理の動作</span><span class="sxs-lookup"><span data-stu-id="a2f93-183">What happens during a default clean up process?</span></span>

#### <a name="step-1-clean-up"></a><span data-ttu-id="a2f93-184">手順 1: クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="a2f93-184">Step 1: clean up</span></span>
* <span data-ttu-id="a2f93-185">すべての Win32 アプリとストア アプリが終了します</span><span class="sxs-lookup"><span data-stu-id="a2f93-185">All Win32 and store apps are closed</span></span>
* <span data-ttu-id="a2f93-186">__ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます</span><span class="sxs-lookup"><span data-stu-id="a2f93-186">All files in known folders like __Pictures__, __Videos__, __Music__, __Documents__, __SavedPictures__, __CameraRoll__, __Desktop__ and __Downloads__ folders are deleted</span></span>
* <span data-ttu-id="a2f93-187">構造化されていないローミング状態と構造化されたローミング状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="a2f93-187">Unstructured and structured roaming states are deleted</span></span>
* <span data-ttu-id="a2f93-188">構造化されたローカル状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="a2f93-188">Structured local states are deleted</span></span>

#### <a name="step-2-set-up"></a><span data-ttu-id="a2f93-189">手順2: 設定</span><span class="sxs-lookup"><span data-stu-id="a2f93-189">Step 2: Set up</span></span>
* <span data-ttu-id="a2f93-190">オフライン デバイスの場合: フォルダーは空のままです</span><span class="sxs-lookup"><span data-stu-id="a2f93-190">For offline devices: Folders remain empty</span></span>
* <span data-ttu-id="a2f93-191">オンライン デバイスの場合: Microsoft Store から市販デモ アセットがデバイスにプッシュされます</span><span class="sxs-lookup"><span data-stu-id="a2f93-191">For online devices: Retail demo assets can be pushed to the device from the Microsoft Store</span></span>

### <a name="how-to-store-data-across-user-sessions"></a><span data-ttu-id="a2f93-192">ユーザー セッション間でデータを保存する方法</span><span class="sxs-lookup"><span data-stu-id="a2f93-192">How to store data across user sessions?</span></span>

<span data-ttu-id="a2f93-193">ユーザー セッション間でデータを保存する場合は、情報を __ApplicationData.Current.TemporaryFolder__ に格納します。このフォルダーのデータは、既定のクリーンアップ処理によって自動的に削除されません。</span><span class="sxs-lookup"><span data-stu-id="a2f93-193">If you want to store data across user sessions, you can store information in __ApplicationData.Current.TemporaryFolder__ as the default clean up process does not automatically delete data in this folder.</span></span> <span data-ttu-id="a2f93-194">*LocalState* を使って保存した情報は、クリーンアップ処理中に削除されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="a2f93-194">Note that information stored using *LocalState* is deleted during the clean up process.</span></span>

### <a name="how-to-customize-the-clean-up-process"></a><span data-ttu-id="a2f93-195">クリーンアップ処理をカスタマイズする方法</span><span class="sxs-lookup"><span data-stu-id="a2f93-195">How to customize the clean up process?</span></span>

<span data-ttu-id="a2f93-196">クリーンアップ処理をカスタマイズする場合は、`Microsoft-RetailDemo-Cleanup` アプリ サービスをアプリに実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-196">If you wish to customize the clean up process, you need to implement the `Microsoft-RetailDemo-Cleanup` app service into your app.</span></span>

<span data-ttu-id="a2f93-197">カスタムのクリーンアップ ロジックが必要なシナリオには、負荷の高いセットアップの実行、データのダウンロードとキャッシュ、*LocalState* データを削除したくない場合などがあります。</span><span class="sxs-lookup"><span data-stu-id="a2f93-197">Scenarios where a custom clean up logic is needed includes running an expensive setup, downloading and caching data or not wanting *LocalState* data to be deleted.</span></span>

<span data-ttu-id="a2f93-198">手順 1: アプリケーション マニフェストで _Microsoft-RetailDemo-Cleanup_ サービスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-198">Step 1: Declare the _Microsoft-RetailDemo-Cleanup_ service in your application manifest.</span></span>
``` CSharp
  <Applications>
      <Extensions>
        <uap:Extension Category="windows.appService" EntryPoint="MyCompany.MyApp.RDXCustomCleanupTask">
          <uap:AppService Name="Microsoft-RetailDemo-Cleanup" />
        </uap:Extension>
      </Extensions>
   </Application>
  </Applications>

```

<span data-ttu-id="a2f93-199">手順 2: 下のサンプル テンプレートを使って、_AppdataCleanup_ ケース関数の下に、カスタムのクリーンアップ ロジックを実装します。</span><span class="sxs-lookup"><span data-stu-id="a2f93-199">Step 2: Implement your custom clean up logic under the _AppdataCleanup_ case function using the sample template below.</span></span>
``` CSharp
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace MyCompany.MyApp
{
    public sealed class RDXCustomCleanupTask : IBackgroundTask
    {
        BackgroundTaskCancellationReason _cancelReason = BackgroundTaskCancellationReason.Abort;
        BackgroundTaskDeferral _deferral = null;
        IBackgroundTaskInstance _taskInstance = null;
        AppServiceConnection _appServiceConnection = null;

        const string MessageCommand = "Command";

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Get the deferral object from the task instance, and take a reference to the taskInstance;
            _deferral = taskInstance.GetDeferral();
            _taskInstance = taskInstance;
            _taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);

            AppServiceTriggerDetails appService = _taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if ((appService != null) && (appService.Name == "Microsoft-RetailDemo-Cleanup"))
            {
                _appServiceConnection = appService.AppServiceConnection;
                _appServiceConnection.RequestReceived += _appServiceConnection_RequestReceived;
                _appServiceConnection.ServiceClosed += _appServiceConnection_ServiceClosed;
            }
            else
            {
                _deferral.Complete();
            }
        }

        void _appServiceConnection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
        }

        async void _appServiceConnection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            //Get a deferral because we will be calling async code
            AppServiceDeferral requestDeferral = args.GetDeferral();
            string command = null;
            var returnData = new ValueSet();

            try
            {
                ValueSet message = args.Request.Message;
                if (message.ContainsKey(MessageCommand))
                {
                    command = message[MessageCommand] as string;
                }

                if (command != null)
                {
                    switch (command)
                    {
                        case "AppdataCleanup":
                            {
                                // Do custom clean up logic here
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                requestDeferral.Complete();
                // Also release the task deferral since we only process one request per instance.
                _deferral.Complete();
            }
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _cancelReason = reason;
        }
    }
}
```

## <a name="related-links"></a><span data-ttu-id="a2f93-200">関連リンク</span><span class="sxs-lookup"><span data-stu-id="a2f93-200">Related links</span></span>

* [<span data-ttu-id="a2f93-201">アプリ データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="a2f93-201">Store and retrieve app data</span></span>](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [<span data-ttu-id="a2f93-202">アプリ サービスの作成と利用の方法</span><span class="sxs-lookup"><span data-stu-id="a2f93-202">How to create and consume an app service</span></span>](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [<span data-ttu-id="a2f93-203">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="a2f93-203">Localizing app contents</span></span>](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)


 

 
