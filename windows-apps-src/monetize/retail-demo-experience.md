---
title: 小売デモ (RDX) 機能をアプリに追加します。
description: 小売販売部門でアプリを支援小売デモ モードでアプリを準備します。
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, UWP, 市販デモ アプリ
ms.localizationpriority: medium
ms.openlocfilehash: b66435dd7c94762874461b48e19e9a60224f287b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596757"
---
# <a name="add-retail-demo-rdx-features-to-your-app"></a><span data-ttu-id="254fd-104">小売デモ (RDX) 機能をアプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="254fd-104">Add retail demo (RDX) features to your app</span></span>

<span data-ttu-id="254fd-105">販売フロアで PC やデバイスを試しているユーザーがすぐに開始できるように、Windows アプリに小売デモ モードを含めます。</span><span class="sxs-lookup"><span data-stu-id="254fd-105">Include a retail demo mode in your Windows app so customers who try out PCs and devices on the sales floor can jump right in.</span></span>

<span data-ttu-id="254fd-106">お客様は、小売店が、Pc とデバイスのデモを試すことができるものと考えます。</span><span class="sxs-lookup"><span data-stu-id="254fd-106">When customers are in a retail store, they expect to be able to try out demos of PCs and devices.</span></span> <span data-ttu-id="254fd-107">利用してアプリでいろいろ試して、時間のかなりのチャンクを割くこと多くの場合、[デモ エクスペリエンス (RDX) の小売](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)します。</span><span class="sxs-lookup"><span data-stu-id="254fd-107">They often spend a considerable chunk of their time playing around with apps through the [retail demo experience (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience).</span></span>

<span data-ttu-id="254fd-108">アプリをセットアップするには、中にさまざまなエクスペリエンスを提供する_通常_または_小売_モード。</span><span class="sxs-lookup"><span data-stu-id="254fd-108">You can set up your app to provide different experiences while in _normal_ or _retail_ modes.</span></span> <span data-ttu-id="254fd-109">たとえば、アプリは、セットアップ プロセスを起動する場合小売モードでスキップし、ですぐできるようにサンプル データと既定の設定でアプリを事前可能性があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-109">For example, if your app starts with a setup process, you might skip past it in retail mode, and prepopulate the app with sample data and default settings so they can jump right in.</span></span>

<span data-ttu-id="254fd-110">お客様の観点からは、1 つだけのアプリです。</span><span class="sxs-lookup"><span data-stu-id="254fd-110">From our customers' perspective, there is only one app.</span></span> <span data-ttu-id="254fd-111">2 つのモードを区別する顧客のため、お勧めしますリテール モードでは、アプリが、表示される、単語"Retail"目立つようタイトル バーで、または適切な場所。</span><span class="sxs-lookup"><span data-stu-id="254fd-111">To help customers distinguish between the two modes, we recommend that while your app is in retail mode, it shows the word "Retail" prominently in the title bar or in a suitable location.</span></span>

<span data-ttu-id="254fd-112">アプリの Microsoft Store の要件だけでなく RDX に対応するアプリの RDX セットアップ、クリーンアップ、および更新プログラムのプロセスを肯定的なエクスペリエンスは、小売店でに顧客との互換性も場合があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-112">In addition to the Microsoft Store requirements for apps, RDX-aware apps must also be compatible with the RDX setup, cleanup, and update processes to ensure that customers have a consistently positive experience at the retail store.</span></span>

## <a name="design-principles"></a><span data-ttu-id="254fd-113">設計原則</span><span class="sxs-lookup"><span data-stu-id="254fd-113">Design principles</span></span>

* <span data-ttu-id="254fd-114">**最善の表示**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-114">**Show your best**.</span></span> <span data-ttu-id="254fd-115">Showcase アプリ rocks 理由に、小売デモ エクスペリエンスを使用します。</span><span class="sxs-lookup"><span data-stu-id="254fd-115">Use the retail demo experience to showcase why your app rocks.</span></span> <span data-ttu-id="254fd-116">最初に、顧客が表示されます、最適なピースをもらうために、アプリを可能性があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-116">This is likely the first time your customer will see your app, so show them the best piece!</span></span>

* <span data-ttu-id="254fd-117">**高速表示**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-117">**Show it fast**.</span></span> <span data-ttu-id="254fd-118">お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。</span><span class="sxs-lookup"><span data-stu-id="254fd-118">Customers can be impatient - The faster a user can experience the real value of your app, the better.</span></span>

* <span data-ttu-id="254fd-119">**単純なストーリー**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-119">**Keep the story simple**.</span></span> <span data-ttu-id="254fd-120">小売デモ操作では、アプリの値、概要です。</span><span class="sxs-lookup"><span data-stu-id="254fd-120">The retail demo experience is an elevator pitch for your app’s value.</span></span>

* <span data-ttu-id="254fd-121">**エクスペリエンスに注目**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-121">**Focus on the experience**.</span></span> <span data-ttu-id="254fd-122">お客様がコンテンツを理解する時間を設けましょう。</span><span class="sxs-lookup"><span data-stu-id="254fd-122">Give the user time to digest your content.</span></span> <span data-ttu-id="254fd-123">魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。</span><span class="sxs-lookup"><span data-stu-id="254fd-123">While getting them to the best part fast is important, designing suitable pauses can help them to fully enjoy the experience.</span></span>

## <a name="technical-requirements"></a><span data-ttu-id="254fd-124">技術的要件</span><span class="sxs-lookup"><span data-stu-id="254fd-124">Technical requirements</span></span>

<span data-ttu-id="254fd-125">RDX に対応するアプリは、小売り店へのアプリのベストを紹介するものとは技術的な要件を満たしている必要があります、小売デモ エクスペリエンスのすべてのアプリを Microsoft Store を含むプライバシー規制を遵守します。</span><span class="sxs-lookup"><span data-stu-id="254fd-125">As RDX-aware apps are meant to showcase the best of your app to retail customers, they must meet technical requirements and adhere to privacy regulations that the Microsoft Store has for all retail demo experience apps.</span></span>

<span data-ttu-id="254fd-126">検証プロセスの準備に役立つとわかりやすくするためのテストのプロセスを提供するチェックリストとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="254fd-126">This can be used as a checklist to help you prepare for the validation process and to provide clarity in the testing process.</span></span> <span data-ttu-id="254fd-127">これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-127">Note that these requirements have to be maintained, not just for the validation process, but for the entire lifetime of the retail demo experience app; as long as your app stays running on the retail demo devices.</span></span>

### <a name="critical-requirements"></a><span data-ttu-id="254fd-128">重要な要件</span><span class="sxs-lookup"><span data-stu-id="254fd-128">Critical requirements</span></span>

<span data-ttu-id="254fd-129">これらの重要な要件を満たしていない RDX に対応するアプリは、できるだけ早く製品デモのすべてのデバイスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="254fd-129">RDX-aware apps that do not meet these critical requirements will be removed from all retail demo devices as soon as possible.</span></span>

* <span data-ttu-id="254fd-130">**個人情報 (PII) のメッセージを表示しない**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-130">**Don't ask for personal identifiable information (PII)**.</span></span> <span data-ttu-id="254fd-131">これはログイン情報、Microsoft アカウント情報、または連絡先が含まれます。 詳細情報。</span><span class="sxs-lookup"><span data-stu-id="254fd-131">This includes login info, Microsoft account info, or contact details.</span></span>

* <span data-ttu-id="254fd-132">**エラーのない経験**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-132">**Error-free experience**.</span></span> <span data-ttu-id="254fd-133">アプリは、エラーなしで動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-133">Your app must run with no errors.</span></span> <span data-ttu-id="254fd-134">また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。</span><span class="sxs-lookup"><span data-stu-id="254fd-134">Additionally, no error pop ups or notifications should be shown to customers using the retail demo devices.</span></span> <span data-ttu-id="254fd-135">エラーは、自体、ブランド、デバイスのブランド、デバイスの製造元のブランド、および Microsoft のブランドに、アプリの悪影響を及ぼす反映されます。</span><span class="sxs-lookup"><span data-stu-id="254fd-135">Errors reflect negatively on the app itself, your brand, the device's brand, the device's manufacturer's brand, and Microsoft's brand.</span></span>

* <span data-ttu-id="254fd-136">**有料のアプリは試用版モードで必要があります**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-136">**Paid apps must have a trial mode**.</span></span> <span data-ttu-id="254fd-137">無料または含めるか、アプリで必要な[試用版モード](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)します。</span><span class="sxs-lookup"><span data-stu-id="254fd-137">Your app either needs to be a free or include a [trial mode](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app).</span></span> <span data-ttu-id="254fd-138">お客様は小売店での試用に料金を支払うことは想定していません。</span><span class="sxs-lookup"><span data-stu-id="254fd-138">Customers aren't looking to pay for an experience in a retail store.</span></span>

### <a name="high-priority-requirements"></a><span data-ttu-id="254fd-139">優先度の高い要件</span><span class="sxs-lookup"><span data-stu-id="254fd-139">High-priority requirements</span></span>

<span data-ttu-id="254fd-140">これらの優先度の高い要件を満たしていない RDX に対応するアプリは、修正プログラムを直ちに調査する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-140">RDX-aware apps that do not meet these high priority requirements need to be investigated for a fix immediately.</span></span> <span data-ttu-id="254fd-141">直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。</span><span class="sxs-lookup"><span data-stu-id="254fd-141">If no immediate fix is found, this app may be removed from all retail demo devices.</span></span>

* <span data-ttu-id="254fd-142">**覚えやすいオフライン エクスペリエンス**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-142">**Memorable offline experience**.</span></span> <span data-ttu-id="254fd-143">アプリを販売店で、デバイスの約 50% がオフライン、優れたオフライン エクスペリエンスを示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-143">Your app needs to demonstrate a great offline experience as about 50% of the devices are offline at retail locations.</span></span> <span data-ttu-id="254fd-144">この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="254fd-144">This is to ensure that customers interacting with your app offline are still able to have a meaningful and positive experience.</span></span>

* <span data-ttu-id="254fd-145">**更新コンテンツ エクスペリエンス**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-145">**Updated content experience**.</span></span> <span data-ttu-id="254fd-146">アプリは、オンラインの場合、更新プログラムの入力を求めるしない場合があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-146">Your app should never be prompt for updates when online.</span></span> <span data-ttu-id="254fd-147">更新プログラムが必要な場合、サイレント モードで実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-147">If updates are needed, they should be performed silently.</span></span>

* <span data-ttu-id="254fd-148">**匿名の通信がありません**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-148">**No anonymous communication**.</span></span> <span data-ttu-id="254fd-149">小売デモ デバイスを使用して、顧客は、匿名ユーザーであるため、すべきメッセージまたは共有のコンテンツをデバイスから。</span><span class="sxs-lookup"><span data-stu-id="254fd-149">Because a customer using a retail demo device is an anonymous user, they should not be able to message or share content from the device.</span></span>

* <span data-ttu-id="254fd-150">**クリーンアップ プロセスを使用して一貫したエクスペリエンスを提供**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-150">**Deliver consistent experiences by using the cleanup process**.</span></span> <span data-ttu-id="254fd-151">市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-151">Every customer should have the same experience when they walk up to a retail demo device.</span></span> <span data-ttu-id="254fd-152">アプリで使用する必要があります[クリーンアップ処理](#cleanup-process)使用後に同じ既定の状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="254fd-152">Your app should use [clean up process](#cleanup-process) to return to the same default state after each use.</span></span> <span data-ttu-id="254fd-153">残されたどのような最終顧客を表示する次の顧客をほしくありません。</span><span class="sxs-lookup"><span data-stu-id="254fd-153">We don't want the next customer to see what the last customer left behind.</span></span> <span data-ttu-id="254fd-154">これには、スコアボード、達成度、ロック解除が含まれます。</span><span class="sxs-lookup"><span data-stu-id="254fd-154">This includes scoreboards, achievements, and unlocks.</span></span>

* <span data-ttu-id="254fd-155">**適切なコンテンツの年齢**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-155">**Age appropriate content**.</span></span> <span data-ttu-id="254fd-156">すべてのアプリ コンテンツがある必要があります楽しむ十代のお子様または低い評価カテゴリに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="254fd-156">All app content needs to be assigned a Teen or lower rating category.</span></span> <span data-ttu-id="254fd-157">詳細についてを参照してください。 [IARC により、規制、アプリを取得する](https://www.globalratings.com/for-developers.aspx)と[ESRB 評価](https://www.esrb.org/ratings/ratings_guide.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="254fd-157">To learn more, see [Getting your app rated by IARC](https://www.globalratings.com/for-developers.aspx) and [ESRB ratings](https://www.esrb.org/ratings/ratings_guide.aspx).</span></span>

### <a name="medium-priority-requirements"></a><span data-ttu-id="254fd-158">中程度の要件</span><span class="sxs-lookup"><span data-stu-id="254fd-158">Medium-priority requirements</span></span>

<span data-ttu-id="254fd-159">Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。</span><span class="sxs-lookup"><span data-stu-id="254fd-159">The Windows Retail Store team may reach out to developers directly to set up a discussion on how to fix these issues.</span></span>

* <span data-ttu-id="254fd-160">**さまざまなデバイスで正常に実行するための機能**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-160">**Ability to run successfully over a range of devices**.</span></span> <span data-ttu-id="254fd-161">アプリは、ローエンドの仕様でデバイスを含め、すべてのデバイスで適切に実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-161">Apps must run well on all devices, including devices with low-end specifications.</span></span> <span data-ttu-id="254fd-162">最小要件を満たしていないデバイスでアプリがインストールされている場合、アプリを明らかにこのユーザーに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-162">If the app is installed on devices that did not meet the minimum specifications, the app needs to clearly inform the user about this.</span></span> <span data-ttu-id="254fd-163">アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-163">Minimum device requirements has to be made known so that the app can always run with high performance.</span></span>

* <span data-ttu-id="254fd-164">**小売ストア アプリのサイズ要件を満たす**します。</span><span class="sxs-lookup"><span data-stu-id="254fd-164">**Meet retail store app size requirements**.</span></span> <span data-ttu-id="254fd-165">アプリのサイズは、800 MB 未満である必要があります。</span><span class="sxs-lookup"><span data-stu-id="254fd-165">The app must be smaller than 800MB.</span></span> <span data-ttu-id="254fd-166">RDX に対応したアプリがサイズ要件を満たしていない場合の議論を直接 Windows 小売店のチームに問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="254fd-166">Contact the Windows Retail Store team directly for further discussion if your RDX-aware app does not meet the size requirements.</span></span>

## <a name="retailinfo-api-preparing-your-code-for-demo-mode"></a><span data-ttu-id="254fd-167">RetailInfo API:デモ モードのコードを準備します。</span><span class="sxs-lookup"><span data-stu-id="254fd-167">RetailInfo API: Preparing your code for demo mode</span></span>

### <a name="isdemomodeenabled"></a><span data-ttu-id="254fd-168">IsDemoModeEnabled</span><span class="sxs-lookup"><span data-stu-id="254fd-168">IsDemoModeEnabled</span></span>
<span data-ttu-id="254fd-169">[ **IsDemoModeEnabled** ](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled)プロパティ、 [ **RetailInfo** ](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo)ユーティリティ クラスは、一部の[Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) - でアプリを実行するコード パスを指定する、Windows 10 SDK で名前空間を示すブール値として使用される、_通常_モードまたは_小売_モード。</span><span class="sxs-lookup"><span data-stu-id="254fd-169">The [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) property in the [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo) utility class, which is part of the [Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) namespace in the Windows 10 SDK, is used as a Boolean indicator to specify which code path your app runs on - the _normal_ mode or the _retail_ mode.</span></span>

``` csharp
using Windows.Storage;

StorageFolder folder = ApplicationData.Current.LocalFolder;

if (Windows.System.Profile.RetailInfo.IsDemoModeEnabled) 
{
    // Use the demo specific directory
    folder = await folder.GetFolderAsync(“demo”);
}

StorageFile file = await folder.GetFileAsync(“hello.txt”);
// Now read from file
```

``` cpp
using namespace Windows::Storage;

StorageFolder^ localFolder = ApplicationData::Current->LocalFolder;

if (Windows::System::Profile::RetailInfo::IsDemoModeEnabled) 
{
    // Use the demo specific directory
    create_task(localFolder->GetFolderAsync(“demo”).then([this](StorageFolder^ demoFolder)
    {
        return demoFolder->GetFileAsync(“hello.txt”);
    }).then([this](task<StorageFile^> fileTask)
    {
        StorageFile^ file = fileTask.get();
    });
    // Do something with file
}
else
{
    create_task(localFolder->GetFileAsync(“hello.txt”).then([this](StorageFile^ file)
    {
        // Do something with file
    });
}
```

``` javascript
if (Windows.System.Profile.retailInfo.isDemoModeEnabled) {
    console.log(“Retail mode is enabled.”);
} else {
    Console.log(“Retail mode is not enabled.”);
}
```

### <a name="retailinfoproperties"></a><span data-ttu-id="254fd-170">RetailInfo.Properties</span><span class="sxs-lookup"><span data-stu-id="254fd-170">RetailInfo.Properties</span></span>

<span data-ttu-id="254fd-171">[  **IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) から true が返されたら、[**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="254fd-171">When [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) returns true, you can query for a set of properties about the device using [**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) to build a more customized retail demo experience.</span></span> <span data-ttu-id="254fd-172">これらのプロパティには、[**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername)、[**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize)、[**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="254fd-172">These properties include [**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername), [**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize), [**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) and so on.</span></span>

```csharp
using Windows.UI.Xaml.Controls;
using Windows.System.Profile

TextBlock priceText = new TextBlock();
priceText.Text = RetailInfo.Properties[KnownRetailInfo.Price];
// Assume infoPanel is a StackPanel declared in XAML
this.infoPanel.Children.Add(priceText);
```

```cpp
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::System::Profile;

TextBlock ^manufacturerText = ref new TextBlock();
manufacturerText.set_Text(RetailInfo::Properties[KnownRetailInfoProperties::Price]);
// Assume infoPanel is a StackPanel declared in XAML
this->infoPanel->Children->Add(manufacturerText);
```

```javascript
var pro = Windows.System.Profile;
console.log(pro.retailInfo.properties[pro.KnownRetailInfoProperties.price);
```

#### <a name="idl"></a><span data-ttu-id="254fd-173">IDL</span><span class="sxs-lookup"><span data-stu-id="254fd-173">IDL</span></span>

```
//  Copyright (c) Microsoft Corporation. All rights reserved.
//
//  WindowsRuntimeAPISet

import "oaidl.idl";
import "inspectable.idl";
import "Windows.Foundation.idl";
#include <sdkddkver.h>

namespace Windows.System.Profile
{
    runtimeclass RetailInfo;
    runtimeclass KnownRetailInfoProperties;

    [version(NTDDI_WINTHRESHOLD), uuid(0712C6B8-8B92-4F2A-8499-031F1798D6EF), exclusiveto(RetailInfo)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    interface IRetailInfoStatics : IInspectable
    {
        [propget] HRESULT IsDemoModeEnabled([out, retval] boolean *value);
        [propget] HRESULT Properties([out, retval, hasvariant] Windows.Foundation.Collections.IMapView<HSTRING, IInspectable *> **value);
    }

    [version(NTDDI_WINTHRESHOLD), uuid(50BA207B-33C4-4A5C-AD8A-CD39F0A9C2E9), exclusiveto(KnownRetailInfoProperties)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    interface IKnownRetailInfoPropertiesStatics : IInspectable
    {
        [propget] HRESULT RetailAccessCode([out, retval] HSTRING *value);
        [propget] HRESULT ManufacturerName([out, retval] HSTRING *value);
        [propget] HRESULT ModelName([out, retval] HSTRING *value);
        [propget] HRESULT DisplayModelName([out, retval] HSTRING *value);
        [propget] HRESULT Price([out, retval] HSTRING *value);
        [propget] HRESULT IsFeatured([out, retval] HSTRING *value);
        [propget] HRESULT FormFactor([out, retval] HSTRING *value);
        [propget] HRESULT ScreenSize([out, retval] HSTRING *value);
        [propget] HRESULT Weight([out, retval] HSTRING *value);
        [propget] HRESULT DisplayDescription([out, retval] HSTRING *value);
        [propget] HRESULT BatteryLifeDescription([out, retval] HSTRING *value);
        [propget] HRESULT ProcessorDescription([out, retval] HSTRING *value);
        [propget] HRESULT Memory([out, retval] HSTRING *value);
        [propget] HRESULT StorageDescription([out, retval] HSTRING *value);
        [propget] HRESULT GraphicsDescription([out, retval] HSTRING *value);
        [propget] HRESULT FrontCameraDescription([out, retval] HSTRING *value);
        [propget] HRESULT RearCameraDescription([out, retval] HSTRING *value);
        [propget] HRESULT HasNfc([out, retval] HSTRING *value);
        [propget] HRESULT HasSdSlot([out, retval] HSTRING *value);
        [propget] HRESULT HasOpticalDrive([out, retval] HSTRING *value);
        [propget] HRESULT IsOfficeInstalled([out, retval] HSTRING *value);
        [propget] HRESULT WindowsVersion([out, retval] HSTRING *value);
    }

    [version(NTDDI_WINTHRESHOLD), static(IRetailInfoStatics, NTDDI_WINTHRESHOLD)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone), static(IRetailInfoStatics, NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    [threading(both)]
    [marshaling_behavior(agile)]
    runtimeclass RetailInfo
    {
    }

    [version(NTDDI_WINTHRESHOLD), static(IKnownRetailInfoPropertiesStatics, NTDDI_WINTHRESHOLD)]
    [version(NTDDI_WINTHRESHOLD, Platform.WindowsPhone), static(IKnownRetailInfoPropertiesStatics, NTDDI_WINTHRESHOLD, Platform.WindowsPhone)]
    [threading(both)]
    [marshaling_behavior(agile)]
    runtimeclass KnownRetailInfoProperties
    {
    }
}
```

## <a name="cleanup-process"></a><span data-ttu-id="254fd-174">クリーンアップ プロセス</span><span class="sxs-lookup"><span data-stu-id="254fd-174">Cleanup process</span></span>

<span data-ttu-id="254fd-175">クリーンアップは、買い物客は、デバイスとのやり取りが停止した後、2 分を開始します。</span><span class="sxs-lookup"><span data-stu-id="254fd-175">Cleanup begins two minutes after a shopper stops interacting with the device.</span></span> <span data-ttu-id="254fd-176">小売デモを再生し、Windows は、連絡先、写真、およびその他のアプリ内のサンプル データのリセットを開始します。</span><span class="sxs-lookup"><span data-stu-id="254fd-176">The retail demo plays, and Windows begins resetting any sample data in the contacts, photos, and other apps.</span></span> <span data-ttu-id="254fd-177">デバイスによっては、完全にすべてを正常にリセットする 1 ~ 5 分間かかります。</span><span class="sxs-lookup"><span data-stu-id="254fd-177">Depending on the device, this could take between 1-5 minutes to fully reset everything back to normal.</span></span> <span data-ttu-id="254fd-178">これにより、小売店ですべての顧客がデバイスに方法について説明し、デバイスと対話するときに、同じエクスペリエンスがあることができます。</span><span class="sxs-lookup"><span data-stu-id="254fd-178">This ensures that every customer in the retail store can walk up to a device and have the same experience when interacting with the device.</span></span>

<span data-ttu-id="254fd-179">手順 1:クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="254fd-179">Step 1: Cleanup</span></span>
* <span data-ttu-id="254fd-180">すべての Win32 アプリとストア アプリが終了します</span><span class="sxs-lookup"><span data-stu-id="254fd-180">All Win32 and store apps are closed</span></span>
* <span data-ttu-id="254fd-181">__ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます</span><span class="sxs-lookup"><span data-stu-id="254fd-181">All files in known folders like __Pictures__, __Videos__, __Music__, __Documents__, __SavedPictures__, __CameraRoll__, __Desktop__ and __Downloads__ folders are deleted</span></span>
* <span data-ttu-id="254fd-182">構造化されていないローミング状態と構造化されたローミング状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="254fd-182">Unstructured and structured roaming states are deleted</span></span>
* <span data-ttu-id="254fd-183">構造化されたローカル状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="254fd-183">Structured local states are deleted</span></span>

<span data-ttu-id="254fd-184">手順 2:セットアップ</span><span class="sxs-lookup"><span data-stu-id="254fd-184">Step 2:  Setup</span></span>
* <span data-ttu-id="254fd-185">オフライン デバイス。フォルダーは空のまま</span><span class="sxs-lookup"><span data-stu-id="254fd-185">For offline devices: Folders remain empty</span></span>
* <span data-ttu-id="254fd-186">オンライン デバイス。小売デモ資産は、Microsoft Store からデバイスにプッシュできます。</span><span class="sxs-lookup"><span data-stu-id="254fd-186">For online devices: Retail demo assets can be pushed to the device from the Microsoft Store</span></span>

### <a name="store-data-across-user-sessions"></a><span data-ttu-id="254fd-187">ユーザー セッション間でデータの格納</span><span class="sxs-lookup"><span data-stu-id="254fd-187">Store data across user sessions</span></span>

<span data-ttu-id="254fd-188">ユーザー セッション間でデータを格納するには、情報を格納できる__ApplicationData.Current.TemporaryFolder__既定値としてクリーンアップ プロセスは自動的に削除されませんこのフォルダー内のデータ。</span><span class="sxs-lookup"><span data-stu-id="254fd-188">To store data across user sessions, you can store information in __ApplicationData.Current.TemporaryFolder__ as the default cleanup process does not automatically delete data in this folder.</span></span> <span data-ttu-id="254fd-189">使用して格納されている情報に注意してください*LocalState*クリーンアップ プロセス中に削除されます。</span><span class="sxs-lookup"><span data-stu-id="254fd-189">Note that information stored using *LocalState* is deleted during the cleanup process.</span></span>

### <a name="customize-the-cleanup-process"></a><span data-ttu-id="254fd-190">クリーンアップ プロセスをカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="254fd-190">Customize the cleanup process</span></span>

<span data-ttu-id="254fd-191">クリーンアップ プロセスをカスタマイズするには、実装、`Microsoft-RetailDemo-Cleanup`をアプリにアプリ サービス。</span><span class="sxs-lookup"><span data-stu-id="254fd-191">To customize the cleanup process, implement the `Microsoft-RetailDemo-Cleanup` app service into your app.</span></span>

<span data-ttu-id="254fd-192">カスタム クリーンアップ ロジックが必要なシナリオには、ダウンロードし、データをキャッシュまたは突っ立ったの広範なセットアップの実行が含まれています*LocalState*データを削除します。</span><span class="sxs-lookup"><span data-stu-id="254fd-192">Scenarios where a custom cleanup logic is needed includes running an extensive setup, downloading and caching data, or not wanting *LocalState* data to be deleted.</span></span>

<span data-ttu-id="254fd-193">手順 1:宣言、 _Microsoft のクリーンアップ RetailDemo_アプリケーション マニフェストでサービス。</span><span class="sxs-lookup"><span data-stu-id="254fd-193">Step 1: Declare the _Microsoft-RetailDemo-Cleanup_ service in your app manifest.</span></span>
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

<span data-ttu-id="254fd-194">手順 2:カスタム クリーンアップ ロジックを実装、 _AppdataCleanup_以下のサンプル テンプレートを使用する大文字と小文字の関数。</span><span class="sxs-lookup"><span data-stu-id="254fd-194">Step 2: Implement your custom cleanup logic under the _AppdataCleanup_ case function using the sample template below.</span></span>
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

## <a name="related-links"></a><span data-ttu-id="254fd-195">関連リンク</span><span class="sxs-lookup"><span data-stu-id="254fd-195">Related links</span></span>

* [<span data-ttu-id="254fd-196">アプリ データの格納と取得</span><span class="sxs-lookup"><span data-stu-id="254fd-196">Store and retrieve app data</span></span>](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [<span data-ttu-id="254fd-197">作成し、app service を使用する方法</span><span class="sxs-lookup"><span data-stu-id="254fd-197">How to create and consume an app service</span></span>](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [<span data-ttu-id="254fd-198">アプリの内容をローカライズします。</span><span class="sxs-lookup"><span data-stu-id="254fd-198">Localizing app contents</span></span>](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)
* [<span data-ttu-id="254fd-199">小売デモ エクスペリエンス (RDX)</span><span class="sxs-lookup"><span data-stu-id="254fd-199">Retail demo experience (RDX)</span></span>](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)
