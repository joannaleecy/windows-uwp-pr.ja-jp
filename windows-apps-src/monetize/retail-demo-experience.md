---
author: joannaleecy
title: 市販デモ (RDX) 機能をアプリに追加します。
description: 市販デモ モード、製品版の販売現場でアプリを広く告知を支援するには、アプリを準備します。
ms.assetid: f83f950f-7fdd-4f18-8127-b92a8f400061
ms.author: joanlee
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, UWP, 市販デモ アプリ
ms.localizationpriority: medium
ms.openlocfilehash: ee0344d521b4c31449a2291517b20a09280818fc
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5698635"
---
# <a name="add-retail-demo-rdx-features-to-your-app"></a><span data-ttu-id="fb103-104">市販デモ (RDX) 機能をアプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="fb103-104">Add retail demo (RDX) features to your app</span></span>

<span data-ttu-id="fb103-105">Pc やデバイス販売フロアに試すお客様にすぐに、Windows アプリで、市販デモ モードが含まれます。</span><span class="sxs-lookup"><span data-stu-id="fb103-105">Include a retail demo mode in your Windows app so customers who try out PCs and devices on the sales floor can jump right in.</span></span>

<span data-ttu-id="fb103-106">小売店でお客様と、Pc やデバイスのデモを試すことができることを期待します。</span><span class="sxs-lookup"><span data-stu-id="fb103-106">When customers are in a retail store, they expect to be able to try out demos of PCs and devices.</span></span> <span data-ttu-id="fb103-107">多くはか、[市販デモ エクスペリエンス (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)を通じて、アプリを時間のします。</span><span class="sxs-lookup"><span data-stu-id="fb103-107">They often spend a considerable chunk of their time playing around with apps through the [retail demo experience (RDX)](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience).</span></span>

<span data-ttu-id="fb103-108">_標準_または_リテール_モードでのさまざまなエクスペリエンスを提供するアプリを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="fb103-108">You can set up your app to provide different experiences while in _normal_ or _retail_ modes.</span></span> <span data-ttu-id="fb103-109">たとえば、アプリは、セットアップ プロセスを起動する場合は、リテール モードで飛ばしてをで直接ジャンプできるように、アプリのサンプル データと既定の設定を事前設定があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-109">For example, if your app starts with a setup process, you might skip past it in retail mode, and prepopulate the app with sample data and default settings so they can jump right in.</span></span>

<span data-ttu-id="fb103-110">お客様の観点から、アプリを 1 つがあります。</span><span class="sxs-lookup"><span data-stu-id="fb103-110">From our customers' perspective, there is only one app.</span></span> <span data-ttu-id="fb103-111">区別できるように、2 つのモードをお勧めしますリテール モードでは、アプリが、その表示される単語「市販」目立つように、タイトル バーまたは適切な場所。</span><span class="sxs-lookup"><span data-stu-id="fb103-111">To help customers distinguish between the two modes, we recommend that while your app is in retail mode, it shows the word "Retail" prominently in the title bar or in a suitable location.</span></span>

<span data-ttu-id="fb103-112">アプリの Microsoft Store の要件に加え RDX 認識アプリの RDX セットアップ、整理、および、小売店で、常に肯定的なエクスペリエンスをユーザーがあることを確認する更新プログラムのプロセスとの互換性も場合があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-112">In addition to the Microsoft Store requirements for apps, RDX-aware apps must also be compatible with the RDX setup, cleanup, and update processes to ensure that customers have a consistently positive experience at the retail store.</span></span>

## <a name="design-principles"></a><span data-ttu-id="fb103-113">設計原則</span><span class="sxs-lookup"><span data-stu-id="fb103-113">Design principles</span></span>

* <span data-ttu-id="fb103-114">**メリットを提示**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-114">**Show your best**.</span></span> <span data-ttu-id="fb103-115">ショーケース アプリ岩理由を市販デモ エクスペリエンスを使用します。</span><span class="sxs-lookup"><span data-stu-id="fb103-115">Use the retail demo experience to showcase why your app rocks.</span></span> <span data-ttu-id="fb103-116">これは、問題は発生初めて顧客のため最適な部分を表示して、アプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-116">This is likely the first time your customer will see your app, so show them the best piece!</span></span>

* <span data-ttu-id="fb103-117">**高速に表示**されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-117">**Show it fast**.</span></span> <span data-ttu-id="fb103-118">お客様に見ていただける時間は限られています。アプリの真価がすぐに実感できるように構成してください。</span><span class="sxs-lookup"><span data-stu-id="fb103-118">Customers can be impatient - The faster a user can experience the real value of your app, the better.</span></span>

* <span data-ttu-id="fb103-119">**シンプルなストーリー**をします。</span><span class="sxs-lookup"><span data-stu-id="fb103-119">**Keep the story simple**.</span></span> <span data-ttu-id="fb103-120">市販デモ エクスペリエンスは、アプリの値の真価です。</span><span class="sxs-lookup"><span data-stu-id="fb103-120">The retail demo experience is an elevator pitch for your app’s value.</span></span>

* <span data-ttu-id="fb103-121">**エクスペリエンスにフォーカス**を移動します。</span><span class="sxs-lookup"><span data-stu-id="fb103-121">**Focus on the experience**.</span></span> <span data-ttu-id="fb103-122">お客様がコンテンツを理解する時間を設けましょう。</span><span class="sxs-lookup"><span data-stu-id="fb103-122">Give the user time to digest your content.</span></span> <span data-ttu-id="fb103-123">魅力的な部分をすばやく伝えることは重要ですが、適切な空白時間を設けることでエクスペリエンスがさらに向上します。</span><span class="sxs-lookup"><span data-stu-id="fb103-123">While getting them to the best part fast is important, designing suitable pauses can help them to fully enjoy the experience.</span></span>

## <a name="technical-requirements"></a><span data-ttu-id="fb103-124">技術的要件</span><span class="sxs-lookup"><span data-stu-id="fb103-124">Technical requirements</span></span>

<span data-ttu-id="fb103-125">認識 RDX アプリは、小売顧客にアプリの来店に置き換わるものは、技術的要件を満たしているし、Microsoft Store を持つすべての市販デモ エクスペリエンス アプリ定めるプライバシー規則に従っている必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-125">As RDX-aware apps are meant to showcase the best of your app to retail customers, they must meet technical requirements and adhere to privacy regulations that the Microsoft Store has for all retail demo experience apps.</span></span>

<span data-ttu-id="fb103-126">テスト プロセスの明確化と、検証プロセスの準備に役立つチェックリストとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="fb103-126">This can be used as a checklist to help you prepare for the validation process and to provide clarity in the testing process.</span></span> <span data-ttu-id="fb103-127">これらの要件は、検証プロセスだけでなく、アプリが市販デモ デバイスで実行される限り、市販デモ エクスペリエンス アプリのライフタイム全体にわたって満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-127">Note that these requirements have to be maintained, not just for the validation process, but for the entire lifetime of the retail demo experience app; as long as your app stays running on the retail demo devices.</span></span>

### <a name="critical-requirements"></a><span data-ttu-id="fb103-128">重要な要件</span><span class="sxs-lookup"><span data-stu-id="fb103-128">Critical requirements</span></span>

<span data-ttu-id="fb103-129">これらの必須要件を満たしていない RDX 対応のアプリは、できるだけ早くすべての市販デモ デバイスから削除されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-129">RDX-aware apps that do not meet these critical requirements will be removed from all retail demo devices as soon as possible.</span></span>

* <span data-ttu-id="fb103-130">**個人情報 (PII) を求めないように**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-130">**Don't ask for personal identifiable information (PII)**.</span></span> <span data-ttu-id="fb103-131">ここではログイン情報、Microsoft アカウントの情報、または連絡先の詳細です。</span><span class="sxs-lookup"><span data-stu-id="fb103-131">This includes login info, Microsoft account info, or contact details.</span></span>

* <span data-ttu-id="fb103-132">**エラーのないが発生**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-132">**Error-free experience**.</span></span> <span data-ttu-id="fb103-133">アプリは、エラーなしで動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-133">Your app must run with no errors.</span></span> <span data-ttu-id="fb103-134">また市販デモ デバイスを使うお客様に、エラー ポップアップやエラー通知を表示してはなりません。</span><span class="sxs-lookup"><span data-stu-id="fb103-134">Additionally, no error pop ups or notifications should be shown to customers using the retail demo devices.</span></span> <span data-ttu-id="fb103-135">エラーは、自体、ブランド、デバイスのブランド、デバイスの製造元のブランド、および Microsoft のブランドに、アプリの悪影響反映されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-135">Errors reflect negatively on the app itself, your brand, the device's brand, the device's manufacturer's brand, and Microsoft's brand.</span></span>

* <span data-ttu-id="fb103-136">**有料アプリの試用モード必要があります**。</span><span class="sxs-lookup"><span data-stu-id="fb103-136">**Paid apps must have a trial mode**.</span></span> <span data-ttu-id="fb103-137">アプリはか無料または[試用モード](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app)を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-137">Your app either needs to be a free or include a [trial mode](https://msdn.microsoft.com/windows/uwp/monetize/exclude-or-limit-features-in-a-trial-version-of-your-app).</span></span> <span data-ttu-id="fb103-138">お客様は小売店での試用に料金を支払うことは想定していません。</span><span class="sxs-lookup"><span data-stu-id="fb103-138">Customers aren't looking to pay for an experience in a retail store.</span></span>

### <a name="high-priority-requirements"></a><span data-ttu-id="fb103-139">優先度の高い要件</span><span class="sxs-lookup"><span data-stu-id="fb103-139">High-priority requirements</span></span>

<span data-ttu-id="fb103-140">これらの優先順位の高い要件を満たしていない RDX 対応のアプリは、すぐに修正プログラムを調査する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-140">RDX-aware apps that do not meet these high priority requirements need to be investigated for a fix immediately.</span></span> <span data-ttu-id="fb103-141">直ちに修正されない場合、このアプリをすべての市販デモ デバイスから削除することがあります。</span><span class="sxs-lookup"><span data-stu-id="fb103-141">If no immediate fix is found, this app may be removed from all retail demo devices.</span></span>

* <span data-ttu-id="fb103-142">**オフライン エクスペリエンス Memorable**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-142">**Memorable offline experience**.</span></span> <span data-ttu-id="fb103-143">アプリは、小売拠点でデバイスの約 50% がオフラインに優れたオフライン エクスペリエンスを示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-143">Your app needs to demonstrate a great offline experience as about 50% of the devices are offline at retail locations.</span></span> <span data-ttu-id="fb103-144">この要件は、お客様がオフラインでアプリを操作する場合でも、意味のある肯定的なエクスペリエンスを保証することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="fb103-144">This is to ensure that customers interacting with your app offline are still able to have a meaningful and positive experience.</span></span>

* <span data-ttu-id="fb103-145">**最新のコンテンツ エクスペリエンス**。</span><span class="sxs-lookup"><span data-stu-id="fb103-145">**Updated content experience**.</span></span> <span data-ttu-id="fb103-146">アプリは、オンラインの場合、更新プログラムの入力を求めるしない場合があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-146">Your app should never be prompt for updates when online.</span></span> <span data-ttu-id="fb103-147">更新プログラムが必要な場合サイレント モードで実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-147">If updates are needed, they should be performed silently.</span></span>

* <span data-ttu-id="fb103-148">**匿名通信の禁止**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-148">**No anonymous communication**.</span></span> <span data-ttu-id="fb103-149">市販デモ デバイスを使用して顧客は、匿名ユーザーであるため、すべきメッセージやコンテンツの共有をデバイスからです。</span><span class="sxs-lookup"><span data-stu-id="fb103-149">Because a customer using a retail demo device is an anonymous user, they should not be able to message or share content from the device.</span></span>

* <span data-ttu-id="fb103-150">**クリーンアップ処理を使用して、一貫したエクスペリエンスを提供**します。</span><span class="sxs-lookup"><span data-stu-id="fb103-150">**Deliver consistent experiences by using the cleanup process**.</span></span> <span data-ttu-id="fb103-151">市販デモ デバイスは、使用開始にあたってすべてのお客様に同じエクスペリエンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-151">Every customer should have the same experience when they walk up to a retail demo device.</span></span> <span data-ttu-id="fb103-152">アプリは、[クリーンアップ処理](#clean-up-process)を使用する必要があります、使用後、同じ既定の状態に戻ります。</span><span class="sxs-lookup"><span data-stu-id="fb103-152">Your app should use [clean up process](#clean-up-process) to return to the same default state after each use.</span></span> <span data-ttu-id="fb103-153">次のお客様にどのような前のお客様の背後にあるたいしないでください。</span><span class="sxs-lookup"><span data-stu-id="fb103-153">We don't want the next customer to see what the last customer left behind.</span></span> <span data-ttu-id="fb103-154">これには、スコアボード、達成度、ロック解除が含まれます。</span><span class="sxs-lookup"><span data-stu-id="fb103-154">This includes scoreboards, achievements, and unlocks.</span></span>

* <span data-ttu-id="fb103-155">**年齢に応じた適切なコンテンツ**です。</span><span class="sxs-lookup"><span data-stu-id="fb103-155">**Age appropriate content**.</span></span> <span data-ttu-id="fb103-156">アプリのすべてのコンテンツがある必要があります、ティーン区分します。</span><span class="sxs-lookup"><span data-stu-id="fb103-156">All app content needs to be assigned a Teen or lower rating category.</span></span> <span data-ttu-id="fb103-157">詳細については、[アプリが iarc 評価の取得](https://www.globalratings.com/for-developers.aspx)と[ESRB 評価に関するページ](https://www.esrb.org/ratings/ratings_guide.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fb103-157">To learn more, see [Getting your app rated by IARC](https://www.globalratings.com/for-developers.aspx) and [ESRB ratings](https://www.esrb.org/ratings/ratings_guide.aspx).</span></span>

### <a name="medium-priority-requirements"></a><span data-ttu-id="fb103-158">中程度の要件</span><span class="sxs-lookup"><span data-stu-id="fb103-158">Medium-priority requirements</span></span>

<span data-ttu-id="fb103-159">Windows リテール ストア チームは、これらの問題の修正方法について、直接開発者に連絡して話し合いの場を設けることがあります。</span><span class="sxs-lookup"><span data-stu-id="fb103-159">The Windows Retail Store team may reach out to developers directly to set up a discussion on how to fix these issues.</span></span>

* <span data-ttu-id="fb103-160">**多様なデバイスで正常に実行することができます**。</span><span class="sxs-lookup"><span data-stu-id="fb103-160">**Ability to run successfully over a range of devices**.</span></span> <span data-ttu-id="fb103-161">アプリは、ローエンド仕様のデバイスを含むすべてのデバイスで適切に実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-161">Apps must run well on all devices, including devices with low-end specifications.</span></span> <span data-ttu-id="fb103-162">最小要件を満たしていないデバイスでアプリをインストールする場合、アプリをこれについてユーザーに明確に通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-162">If the app is installed on devices that did not meet the minimum specifications, the app needs to clearly inform the user about this.</span></span> <span data-ttu-id="fb103-163">アプリが常に高いパフォーマンスで動作できるように、最小のデバイス要件を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-163">Minimum device requirements has to be made known so that the app can always run with high performance.</span></span>

* <span data-ttu-id="fb103-164">**小売店用アプリ サイズ要件を満たしている**ください。</span><span class="sxs-lookup"><span data-stu-id="fb103-164">**Meet retail store app size requirements**.</span></span> <span data-ttu-id="fb103-165">アプリのサイズは、800 MB 未満である必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb103-165">The app must be smaller than 800MB.</span></span> <span data-ttu-id="fb103-166">RDX に対応して、アプリがサイズ要件を満たしていない場合は、Windows リテール ストア チーム詳細については直接問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="fb103-166">Contact the Windows Retail Store team directly for further discussion if your RDX-aware app does not meet the size requirements.</span></span>

## <a name="retailinfo-api-preparing-your-code-for-demo-mode"></a><span data-ttu-id="fb103-167">RetailInfo API: デモ モードのコードを準備します。</span><span class="sxs-lookup"><span data-stu-id="fb103-167">RetailInfo API: Preparing your code for demo mode</span></span>

### <a name="isdemomodeenabled"></a><span data-ttu-id="fb103-168">IsDemoModeEnabled</span><span class="sxs-lookup"><span data-stu-id="fb103-168">IsDemoModeEnabled</span></span>
<span data-ttu-id="fb103-169">これは、Windows 10 SDK に[Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile)名前空間の一部、 [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo)ユーティリティ クラスで[**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled)プロパティは - でアプリを実行するコード パスを指定するブール インジケーターとして使用_法線_モードまたは_リテール_モードです。</span><span class="sxs-lookup"><span data-stu-id="fb103-169">The [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) property in the [**RetailInfo**](https://docs.microsoft.com/uwp/api/Windows.System.Profile.RetailInfo) utility class, which is part of the [Windows.System.Profile](https://docs.microsoft.com/uwp/api/windows.system.profile) namespace in the Windows 10 SDK, is used as a Boolean indicator to specify which code path your app runs on - the _normal_ mode or the _retail_ mode.</span></span>

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

### <a name="retailinfoproperties"></a><span data-ttu-id="fb103-170">RetailInfo.Properties</span><span class="sxs-lookup"><span data-stu-id="fb103-170">RetailInfo.Properties</span></span>

<span data-ttu-id="fb103-171">[**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) から true が返されたら、[**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) を使ってデバイスに関する一連のプロパティを照会することで、さらにカスタマイズした市販デモ エクスペリエンスを構築できます。</span><span class="sxs-lookup"><span data-stu-id="fb103-171">When [**IsDemoModeEnabled**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.isdemomodeenabled) returns true, you can query for a set of properties about the device using [**RetailInfo.Properties**](https://docs.microsoft.com/uwp/api/windows.system.profile.retailinfo.properties) to build a more customized retail demo experience.</span></span> <span data-ttu-id="fb103-172">これらのプロパティには、[**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername)、[**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize)、[**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="fb103-172">These properties include [**ManufacturerName**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.manufacturername), [**Screensize**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.screensize), [**Memory**](https://docs.microsoft.com/uwp/api/windows.system.profile.knownretailinfoproperties.memory) and so on.</span></span>

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

#### <a name="idl"></a><span data-ttu-id="fb103-173">IDL</span><span class="sxs-lookup"><span data-stu-id="fb103-173">IDL</span></span>

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

## <a name="cleanup-process"></a><span data-ttu-id="fb103-174">クリーンアップ処理</span><span class="sxs-lookup"><span data-stu-id="fb103-174">Cleanup process</span></span>

<span data-ttu-id="fb103-175">クリーンアップ、買い物では、デバイスとのやり取りが停止したら、2 分が開始されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-175">Cleanup begins two minutes after a shopper stops interacting with the device.</span></span> <span data-ttu-id="fb103-176">市販デモの再生中、Windows では、連絡先、写真、および他のアプリのサンプル データがすべてのリセットが開始されます。</span><span class="sxs-lookup"><span data-stu-id="fb103-176">The retail demo plays, and Windows begins resetting any sample data in the contacts, photos, and other apps.</span></span> <span data-ttu-id="fb103-177">デバイスに応じてが完全にすべての情報を正常にリセットする 1 ~ 5 分間かかります。</span><span class="sxs-lookup"><span data-stu-id="fb103-177">Depending on the device, this could take between 1-5 minutes to fully reset everything back to normal.</span></span> <span data-ttu-id="fb103-178">これにより、小売店でのすべてのユーザーがデバイスに手順について説明し、デバイスを操作するとき、同じエクスペリエンスがあることができます。</span><span class="sxs-lookup"><span data-stu-id="fb103-178">This ensures that every customer in the retail store can walk up to a device and have the same experience when interacting with the device.</span></span>

<span data-ttu-id="fb103-179">手順 1: クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="fb103-179">Step 1: Cleanup</span></span>
* <span data-ttu-id="fb103-180">すべての Win32 アプリとストア アプリが終了します</span><span class="sxs-lookup"><span data-stu-id="fb103-180">All Win32 and store apps are closed</span></span>
* <span data-ttu-id="fb103-181">__ピクチャ__、__ビデオ__、__ミュージック__、__ドキュメント__、__保存済みの写真__、__カメラロール__、__デスクトップ__、__ダウンロード__フォルダーなどのすべての既知のフォルダーが削除されます</span><span class="sxs-lookup"><span data-stu-id="fb103-181">All files in known folders like __Pictures__, __Videos__, __Music__, __Documents__, __SavedPictures__, __CameraRoll__, __Desktop__ and __Downloads__ folders are deleted</span></span>
* <span data-ttu-id="fb103-182">構造化されていないローミング状態と構造化されたローミング状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="fb103-182">Unstructured and structured roaming states are deleted</span></span>
* <span data-ttu-id="fb103-183">構造化されたローカル状態が削除されます</span><span class="sxs-lookup"><span data-stu-id="fb103-183">Structured local states are deleted</span></span>

<span data-ttu-id="fb103-184">手順 2: セットアップ</span><span class="sxs-lookup"><span data-stu-id="fb103-184">Step 2:  Setup</span></span>
* <span data-ttu-id="fb103-185">オフライン デバイスの場合: フォルダーは空のままです</span><span class="sxs-lookup"><span data-stu-id="fb103-185">For offline devices: Folders remain empty</span></span>
* <span data-ttu-id="fb103-186">オンライン デバイスの場合: Microsoft Store から市販デモ アセットがデバイスにプッシュされます</span><span class="sxs-lookup"><span data-stu-id="fb103-186">For online devices: Retail demo assets can be pushed to the device from the Microsoft Store</span></span>

### <a name="store-data-across-user-sessions"></a><span data-ttu-id="fb103-187">ユーザー セッション間でデータを保存します。</span><span class="sxs-lookup"><span data-stu-id="fb103-187">Store data across user sessions</span></span>

<span data-ttu-id="fb103-188">ユーザー セッション間でデータを保存するには、と、既定のクリーンアップ処理がこのフォルダー内のデータを自動的に削除されません__ApplicationData.Current.TemporaryFolder__で情報を格納することができます。</span><span class="sxs-lookup"><span data-stu-id="fb103-188">To store data across user sessions, you can store information in __ApplicationData.Current.TemporaryFolder__ as the default cleanup process does not automatically delete data in this folder.</span></span> <span data-ttu-id="fb103-189">クリーンアップ処理中に*LocalState*を使用して格納されている情報が削除されたことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="fb103-189">Note that information stored using *LocalState* is deleted during the cleanup process.</span></span>

### <a name="customize-the-cleanup-process"></a><span data-ttu-id="fb103-190">クリーンアップ処理をカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="fb103-190">Customize the cleanup process</span></span>

<span data-ttu-id="fb103-191">クリーンアップ処理をカスタマイズするには、実装、`Microsoft-RetailDemo-Cleanup`アプリ サービスをアプリにします。</span><span class="sxs-lookup"><span data-stu-id="fb103-191">To customize the cleanup process, implement the `Microsoft-RetailDemo-Cleanup` app service into your app.</span></span>

<span data-ttu-id="fb103-192">カスタムのクリーンアップ ロジックが必要なシナリオには、ダウンロードしキャッシュ データ、またはいない*LocalState*データを削除しようとしている、広範なセットアップの実行が含まれています。</span><span class="sxs-lookup"><span data-stu-id="fb103-192">Scenarios where a custom cleanup logic is needed includes running an extensive setup, downloading and caching data, or not wanting *LocalState* data to be deleted.</span></span>

<span data-ttu-id="fb103-193">手順 1: アプリ マニフェスト内の_Microsoft のクリーンアップ RetailDemo_サービスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="fb103-193">Step 1: Declare the _Microsoft-RetailDemo-Cleanup_ service in your app manifest.</span></span>
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

<span data-ttu-id="fb103-194">手順 2: は、次のサンプル テンプレートを使用して_AppdataCleanup_ケース関数の下にカスタムのクリーンアップ ロジックを実装します。</span><span class="sxs-lookup"><span data-stu-id="fb103-194">Step 2: Implement your custom cleanup logic under the _AppdataCleanup_ case function using the sample template below.</span></span>
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

## <a name="related-links"></a><span data-ttu-id="fb103-195">関連リンク</span><span class="sxs-lookup"><span data-stu-id="fb103-195">Related links</span></span>

* [<span data-ttu-id="fb103-196">アプリ データの保存と取得</span><span class="sxs-lookup"><span data-stu-id="fb103-196">Store and retrieve app data</span></span>](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)
* [<span data-ttu-id="fb103-197">アプリ サービスの作成と利用の方法</span><span class="sxs-lookup"><span data-stu-id="fb103-197">How to create and consume an app service</span></span>](https://msdn.microsoft.com/windows/uwp/launch-resume/how-to-create-and-consume-an-app-service)
* [<span data-ttu-id="fb103-198">グローバリゼーションとローカライズ</span><span class="sxs-lookup"><span data-stu-id="fb103-198">Localizing app contents</span></span>](https://msdn.microsoft.com/windows/uwp/globalizing/globalizing-portal)
* [<span data-ttu-id="fb103-199">市販デモ エクスペリエンス (RDX)</span><span class="sxs-lookup"><span data-stu-id="fb103-199">Retail demo experience (RDX)</span></span>](https://docs.microsoft.com/windows-hardware/customize/desktop/retail-demo-experience)
