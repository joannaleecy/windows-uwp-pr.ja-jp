---
title: アプリケーションの新元号対応
description: 2019 年 5 月に行われる改元と、アプリケーションでの対応方法について説明します。
ms.assetid: 5A945F9A-8632-4038-ADD6-C0568091EF27
ms.date: 12/7/2018
ms.topic: article
keywords: Windows 10, UWP, ローカライズの可否, ローカライズ, 日本, 元号
ms.localizationpriority: high
ms.openlocfilehash: 0d5de4c1713ab80afcdf2e028d39340aebcc018b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57617657"
---
# <a name="prepare-your-application-for-the-japanese-era-change"></a><span data-ttu-id="a3ea8-104">アプリケーションの新元号対応</span><span class="sxs-lookup"><span data-stu-id="a3ea8-104">Prepare your application for the Japanese era change</span></span>

<span data-ttu-id="a3ea8-105">和暦には元号が使用されており、現在のコンピューター時代のほとんどは平成に含まれていました。この元号が、2019 年 5 月 1 日から新元号に変更されます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-105">The Japanese calendar is divided into eras, and for most of the modern age of computing, we've been in the Heisei era; however on May 1, 2019, a new era will begin.</span></span> <span data-ttu-id="a3ea8-106">元号が変わるのは約 30 年ぶりであるため、和暦をサポートしているソフトウェアについてはテストを行い、新元号になっても正しく動作するか確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-106">Because this is the first time in decades for an era to change, software that supports the Japanese calendar will need to be tested to ensure it will function properly when the new era begins.</span></span>

<span data-ttu-id="a3ea8-107">以下の各セクションでは、新元号への対応としてアプリケーションの準備とテストを実施する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-107">In the following sections, you will learn what you can do to prepare and test your application for the upcoming new era.</span></span>

> [!NOTE]
> <span data-ttu-id="a3ea8-108">テストに使用する変更内容はコンピューター全体の動作に影響するため、テストにはテスト用コンピューターの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-108">We recommend that you use a test machine for this, because the changes you make will impact the behavior of the entire machine.</span></span>

## <a name="add-a-registry-key-for-the-new-era"></a><span data-ttu-id="a3ea8-109">新元号のレジストリ キーを追加する</span><span class="sxs-lookup"><span data-stu-id="a3ea8-109">Add a registry key for the new era</span></span>

<span data-ttu-id="a3ea8-110">元号が新しくなる前に、互換性の問題が発生しないかテストしておくことが重要です。元号名のプレースホルダーを使用して、今からテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-110">It is important to test for compatibility problems before the era has changed, and you can do so now using a placeholder name.</span></span> <span data-ttu-id="a3ea8-111">これを行うには、**レジストリ エディター**を使用して、新元号のレジストリ キーを追加します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-111">To do this, add a registry key for the new era using **Registry Editor**:</span></span>

1. <span data-ttu-id="a3ea8-112">**Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\Calendars\Japanese\Eras** に移動します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-112">Navigate to **Computer\HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\Calendars\Japanese\Eras**.</span></span>
2. <span data-ttu-id="a3ea8-113">**[編集] > [新規] > [文字列値]** を選択し、「**2019 05 01**」という名前をつけます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-113">Select **Edit > New > String Value**, and give it the name **2019 05 01**.</span></span>
3. <span data-ttu-id="a3ea8-114">キーを右クリックし、**[修正]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-114">Right-click the key and select **Modify**.</span></span>
4. <span data-ttu-id="a3ea8-115">**値データ**フィールドに、入力**でしょうか。?\_でしょうか。\_??????\_?**</span><span class="sxs-lookup"><span data-stu-id="a3ea8-115">In the **Value data** field, enter **？？\_？\_??????\_?**</span></span> <span data-ttu-id="a3ea8-116">(ここからコピーして貼り付けると簡単です)。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-116">(you can copy and paste from here to make it easier).</span></span>

<span data-ttu-id="a3ea8-117">これらのレジストリ キーの書式については、「[和暦での元号処理](https://docs.microsoft.com/windows/desktop/Intl/era-handling-for-the-japanese-calendar)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-117">See [Era Handling for the Japanese Calendar](https://docs.microsoft.com/windows/desktop/Intl/era-handling-for-the-japanese-calendar) to read more about the format for these registry keys.</span></span>

<span data-ttu-id="a3ea8-118">新しい元号が発表されると、サポートされている Windows バージョンでは新しいレジストリ キーを伴う更新プログラムにこの元号が反映されるため、アプリケーションで正しく処理できるかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-118">Once the new era name is announced, an update with a new registry key for supported Windows versions will contain the name, and you can validate that your application handles it properly.</span></span> <span data-ttu-id="a3ea8-119">この更新は、Windows 10 だけでなく Windows 8 および 7 の以前のサポート対象リリースにも反映されます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-119">This update will be propagated to supported earlier releases of Windows 10, as well as Windows 8 and 7.</span></span>

<span data-ttu-id="a3ea8-120">プレースホルダーを使用したレジストリ キーは、アプリケーションのテストが終了したら削除できます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-120">You can delete your placeholder registry key once you're finished testing your application.</span></span> <span data-ttu-id="a3ea8-121">削除しておくと、Windows の更新時に追加される新しいレジストリ キーに干渉する心配がなくなります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-121">This will ensure it doesn't interfere with the new registry key that will be added when Windows is updated.</span></span>

## <a name="change-your-devices-calendar-format"></a><span data-ttu-id="a3ea8-122">デバイスのカレンダー形式を変更する</span><span class="sxs-lookup"><span data-stu-id="a3ea8-122">Change your device's calendar format</span></span>

<span data-ttu-id="a3ea8-123">新元号のレジストリ キーを追加したら、和暦が使用されるようにデバイスを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-123">Once you've added the registry key for the new era, you need to configure your device to use the Japanese calendar.</span></span> <span data-ttu-id="a3ea8-124">これを行うために日本語のデバイスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-124">You don't need to have a Japanese-language device to do this.</span></span> <span data-ttu-id="a3ea8-125">綿密なテストを行うためには日本語の言語パックをインストールすることもできますが、基本的なテスト用には必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-125">For thorough testing, you may want to install the Japanese language pack as well, but it isn't required for basic testing.</span></span>

<span data-ttu-id="a3ea8-126">和暦が使用されるようにデバイスを構成するには:</span><span class="sxs-lookup"><span data-stu-id="a3ea8-126">To configure your device to use the Japanese calendar:</span></span>

1. <span data-ttu-id="a3ea8-127">**intl.cpl** (Windows 検索バーで検索してください) を開きます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-127">Open **intl.cpl** (search for it from the Windows search bar).</span></span>
2. <span data-ttu-id="a3ea8-128">**[形式]** ドロップダウンから **[日本語 (日本)]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-128">From the **Format** dropdown, select **Japanese (Japan)**.</span></span>
3. <span data-ttu-id="a3ea8-129">**[追加の設定]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-129">Select **Additional settings**.</span></span>
4. <span data-ttu-id="a3ea8-130">**[日付]** タブを選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-130">Select the **Date** tab.</span></span>
5. <span data-ttu-id="a3ea8-131">**[カレンダーの種類]** ドロップダウンで、**[和暦]** ("*和暦*" とは日本のカレンダーの意味) を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-131">From the **Calendar type** dropdown, select **和暦** (*wareki*, the Japanese calendar).</span></span> <span data-ttu-id="a3ea8-132">2 番目のオプションが [和暦] です</span><span class="sxs-lookup"><span data-stu-id="a3ea8-132">It should be the second option.</span></span>
6. <span data-ttu-id="a3ea8-133">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-133">Click **OK**.</span></span>
7. <span data-ttu-id="a3ea8-134">**[地域]** ウィンドウで **[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-134">Click **OK** in the **Region** window.</span></span>

<span data-ttu-id="a3ea8-135">デバイスは和暦を使用するように構成され、レジストリにある元号が反映されます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-135">Your device should now be configured to use the Japanese calendar, and it will reflect whichever eras are in the registry.</span></span> <span data-ttu-id="a3ea8-136">以下は、画面の右下に表示される日付形式の例です。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-136">Below is an example of what you might see now in the lower-right corner of the screen:</span></span>

![和暦形式の日付と時刻](images/japanese-calendar-format.png)

## <a name="adjust-your-devices-clock"></a><span data-ttu-id="a3ea8-138">デバイスのクロックを調整する</span><span class="sxs-lookup"><span data-stu-id="a3ea8-138">Adjust your device's clock</span></span>

<span data-ttu-id="a3ea8-139">アプリケーションが新元号に対応していることをテストするには、コンピューターのクロックを 2019 年 5 月 1日以降に進める必要があります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-139">To test that your application works with the new era, you must advance your computer's clock to May 1, 2019 or later.</span></span> <span data-ttu-id="a3ea8-140">次の手順は Windows 10 用ですが、Windows 8 および 7 でも同様の手順になります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-140">The following instructions are for Windows 10, but Windows 8 and 7 should work similarly:</span></span>

1. <span data-ttu-id="a3ea8-141">画面の右下隅にある日付と時刻の領域を右クリックします。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-141">Right-click the date and time area in the lower-right corner of the screen.</span></span>
2. <span data-ttu-id="a3ea8-142">**[日付と時刻の調整]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-142">Select **Adjust date/time**.</span></span>
3. <span data-ttu-id="a3ea8-143">設定アプリの **[日付と時刻を変更する]** で、**[変更]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-143">In the Settings app, under **Change date and time**, select **Change**.</span></span>
4. <span data-ttu-id="a3ea8-144">日付を 2019 年 5 月 1 日以降に変更します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-144">Change the date to on or after May 1, 2019.</span></span>

> [!NOTE]
> <span data-ttu-id="a3ea8-145">組織の設定に基づいて日付を変更することはできません。この場合する場合、。 管理者にお問い合わせまたは、既に渡された日付を使用して、プレース ホルダーのレジストリ キーを編集できます。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-145">You may not be able to change the date based on organization settings; if this is the case, talk to your admin. Alternatively, you can edit your placeholder registry key to have a date that has already passed.</span></span>

## <a name="test-your-application"></a><span data-ttu-id="a3ea8-146">アプリケーションをテストする</span><span class="sxs-lookup"><span data-stu-id="a3ea8-146">Test your application</span></span>

<span data-ttu-id="a3ea8-147">では、アプリケーションで新元号を処理できるかどうかをテストしましょう。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-147">Now, test out how your application handles the new era.</span></span> <span data-ttu-id="a3ea8-148">タイムスタンプや日付の選択コントロールなど、日付が表示される場所で表示を確認します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-148">Check places where the date is displayed, such as timestamps and date pickers.</span></span> <span data-ttu-id="a3ea8-149">5 月 1日 2019 (平成、平成) 前に、と後に (、時代 (年号) が正しいことを確認します。?)。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-149">Make sure that the era is correct before May 1, 2019 (Heisei, 平成) and after (？？).</span></span>

### <a name="gannen-"></a><span data-ttu-id="a3ea8-150">*元年*</span><span class="sxs-lookup"><span data-stu-id="a3ea8-150">*Gannen* (元年)</span></span>

<span data-ttu-id="a3ea8-151">日本語のカレンダーの形式は、通常**&lt;時代 (年号) の名前&gt;&lt;時代 (年号) の年&gt;** します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-151">The format for the Japanese calendar is generally **&lt;Era name&gt; &lt;Year of era&gt;**.</span></span> <span data-ttu-id="a3ea8-152">たとえば、2018 年は "**平成 30 年**" です。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-152">For example, the year 2018 is **Heisei 30** (平成30年).</span></span>  <span data-ttu-id="a3ea8-153">ただし、各元号の最初の年には特殊な表記法を使用し、"**&lt;元号&gt; 1 年**" ではなく "**&lt;元号&gt; 元年**" *と表記します*。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-153">However, the first year of an era is special; instead of being **&lt;Era name&gt; 1**, it is **&lt;Era name&gt; 元年** (*gannen*).</span></span> <span data-ttu-id="a3ea8-154">このため、平成の最初の年は "*平成元年*" となります。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-154">So, the first year of the Heisei era would be 平成元年 (*Heisei gannen*).</span></span> <span data-ttu-id="a3ea8-155">アプリケーションが新しい時代 (年号) の最初の年を適切に処理し、正しく出力するようにしますか。? 元年します。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-155">Make sure that your application properly handles the first year of the new era, and correctly outputs ？？元年.</span></span>

## <a name="related-apis"></a><span data-ttu-id="a3ea8-156">関連する API</span><span class="sxs-lookup"><span data-stu-id="a3ea8-156">Related APIs</span></span>

<span data-ttu-id="a3ea8-157">いくつかの WinRT、.NET、Win32 API は、改元を処理できるよう更新されるため、これらを使用する場合にはそれほど心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-157">There are several WinRT, .NET, and Win32 APIs that will be updated to handle the era change, so if you use them, you shouldn't have to worry too much.</span></span> <span data-ttu-id="a3ea8-158">ただし、全面的にこれらの API を使用している場合も (解析などの特殊処理を行う場合は特に)、アプリケーションをテストして、動作に問題がないか確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-158">However, even if you do rely entirely on these APIs, it's still a good idea to test your application and make sure you get the desired behavior, especially if you are doing anything special with them like parsing.</span></span>

<span data-ttu-id="a3ea8-159">OS および SDK の最新情報については、「[2019 年 5 月の新元号への変更に関する更新](https://support.microsoft.com/help/4470918/updates-for-may-2019-japan-era-change)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-159">You can follow along with updates to the OS and SDK's at [Updates for May 2019 Japan Era Change](https://support.microsoft.com/help/4470918/updates-for-may-2019-japan-era-change).</span></span>

<span data-ttu-id="a3ea8-160">影響を受けるのは次の API です。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-160">The following APIs will be impacted:</span></span>

### <a name="winrt"></a><span data-ttu-id="a3ea8-161">WinRT</span><span class="sxs-lookup"><span data-stu-id="a3ea8-161">WinRT</span></span>

* [<span data-ttu-id="a3ea8-162">Windows.Globalization Namespace</span><span class="sxs-lookup"><span data-stu-id="a3ea8-162">Windows.Globalization Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization)
    * [<span data-ttu-id="a3ea8-163">Calendar クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-163">Calendar Class</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar)
        * [<span data-ttu-id="a3ea8-164">AddDays メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-164">AddDays Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.adddays)
        * [<span data-ttu-id="a3ea8-165">AddEras メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-165">AddEras Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.adderas)
        * [<span data-ttu-id="a3ea8-166">AddHours メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-166">AddHours Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addhours)
        * [<span data-ttu-id="a3ea8-167">AddMinutes メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-167">AddMinutes Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addminutes)
        * [<span data-ttu-id="a3ea8-168">AddMonths メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-168">AddMonths Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addmonths)
        * [<span data-ttu-id="a3ea8-169">AddNanoseconds メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-169">AddNanoseconds Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addnanoseconds)
        * [<span data-ttu-id="a3ea8-170">AddPeriods メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-170">AddPeriods Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addperiods)
        * [<span data-ttu-id="a3ea8-171">AddSeconds メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-171">AddSeconds Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addseconds)
        * [<span data-ttu-id="a3ea8-172">AddWeeks メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-172">AddWeeks Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addweeks)
        * [<span data-ttu-id="a3ea8-173">AddYears メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-173">AddYears Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.addyears)
        * [<span data-ttu-id="a3ea8-174">時代 (年号) のプロパティ</span><span class="sxs-lookup"><span data-stu-id="a3ea8-174">Era Property</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.era)
        * [<span data-ttu-id="a3ea8-175">EraAsString メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-175">EraAsString Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.eraasstring)
        * [<span data-ttu-id="a3ea8-176">FirstYearInThisEra プロパティ</span><span class="sxs-lookup"><span data-stu-id="a3ea8-176">FirstYearInThisEra Property</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.firstyearinthisera)
        * [<span data-ttu-id="a3ea8-177">LastEra プロパティ</span><span class="sxs-lookup"><span data-stu-id="a3ea8-177">LastEra Property</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.lastera)
        * [<span data-ttu-id="a3ea8-178">LastYearInThisEra プロパティ</span><span class="sxs-lookup"><span data-stu-id="a3ea8-178">LastYearInThisEra Property</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.lastyearinthisera)
        * [<span data-ttu-id="a3ea8-179">NumberOfYearsInThisEra プロパティ</span><span class="sxs-lookup"><span data-stu-id="a3ea8-179">NumberOfYearsInThisEra Property</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.calendar.numberofyearsinthisera)     
* [<span data-ttu-id="a3ea8-180">Windows.Globalization.DateTimeFormatting Namespace</span><span class="sxs-lookup"><span data-stu-id="a3ea8-180">Windows.Globalization.DateTimeFormatting Namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting)
    * [<span data-ttu-id="a3ea8-181">DateTimeFormatter クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-181">DateTimeFormatter Class</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting.datetimeformatter)
        * [<span data-ttu-id="a3ea8-182">Format メソッド</span><span class="sxs-lookup"><span data-stu-id="a3ea8-182">Format Method</span></span>](https://docs.microsoft.com/uwp/api/windows.globalization.datetimeformatting.datetimeformatter.format)

### <a name="net"></a><span data-ttu-id="a3ea8-183">.NET</span><span class="sxs-lookup"><span data-stu-id="a3ea8-183">.NET</span></span>

* [<span data-ttu-id="a3ea8-184">System Namespace</span><span class="sxs-lookup"><span data-stu-id="a3ea8-184">System Namespace</span></span>](https://docs.microsoft.com/dotnet/api/system)
    * [<span data-ttu-id="a3ea8-185">DateTime 構造体</span><span class="sxs-lookup"><span data-stu-id="a3ea8-185">DateTime Struct</span></span>](https://docs.microsoft.com/dotnet/api/system.datetime)
    * [<span data-ttu-id="a3ea8-186">DateTimeOffset 構造体</span><span class="sxs-lookup"><span data-stu-id="a3ea8-186">DateTimeOffset Struct</span></span>](https://docs.microsoft.com/dotnet/api/system.datetimeoffset)
* [<span data-ttu-id="a3ea8-187">System.Globalization Namespace</span><span class="sxs-lookup"><span data-stu-id="a3ea8-187">System.Globalization Namespace</span></span>](https://docs.microsoft.com/dotnet/api/system.globalization)
    * [<span data-ttu-id="a3ea8-188">Calendar クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-188">Calendar Class</span></span>](https://docs.microsoft.com/dotnet/api/system.globalization.calendar)
    * [<span data-ttu-id="a3ea8-189">DateTimeFormatInfo クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-189">DateTimeFormatInfo Class</span></span>](https://docs.microsoft.com/dotnet/api/system.globalization.datetimeformatinfo)
    * [<span data-ttu-id="a3ea8-190">JapaneseCalendar クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-190">JapaneseCalendar Class</span></span>](https://docs.microsoft.com/dotnet/api/system.globalization.japanesecalendar)
    * [<span data-ttu-id="a3ea8-191">JapaneseLunisolarCalendar クラス</span><span class="sxs-lookup"><span data-stu-id="a3ea8-191">JapaneseLunisolarCalendar Class</span></span>](https://docs.microsoft.com/dotnet/api/system.globalization.japaneselunisolarcalendar)

### <a name="win32"></a><span data-ttu-id="a3ea8-192">Win32</span><span class="sxs-lookup"><span data-stu-id="a3ea8-192">Win32</span></span>

* [<span data-ttu-id="a3ea8-193">datetimeapi.h ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a3ea8-193">datetimeapi.h header</span></span>](https://docs.microsoft.com/windows/desktop/api/datetimeapi/)
    * [<span data-ttu-id="a3ea8-194">GetDateFormatA 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-194">GetDateFormatA function</span></span>](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformata)
    * [<span data-ttu-id="a3ea8-195">GetDateFormatEx 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-195">GetDateFormatEx function</span></span>](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformatex)
    * [<span data-ttu-id="a3ea8-196">GetDateFormatW 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-196">GetDateFormatW function</span></span>](https://docs.microsoft.com/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformatw)
* [<span data-ttu-id="a3ea8-197">winnls.h ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a3ea8-197">winnls.h header</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/)
    * [<span data-ttu-id="a3ea8-198">EnumDateFormatsA 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-198">EnumDateFormatsA function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsa)
    * [<span data-ttu-id="a3ea8-199">EnumDateFormatsExA 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-199">EnumDateFormatsExA function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexa)
    * [<span data-ttu-id="a3ea8-200">EnumDateFormatsExEx 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-200">EnumDateFormatsExEx function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexex)
    * [<span data-ttu-id="a3ea8-201">EnumDateFormatsExW 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-201">EnumDateFormatsExW function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsexw)
    * [<span data-ttu-id="a3ea8-202">EnumDateFormatsW 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-202">EnumDateFormatsW function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-enumdateformatsw)
    * [<span data-ttu-id="a3ea8-203">GetCalendarInfoA 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-203">GetCalendarInfoA function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfoa)
    * [<span data-ttu-id="a3ea8-204">GetCalendarInfoEx 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-204">GetCalendarInfoEx function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfoex)
    * [<span data-ttu-id="a3ea8-205">GetCalendarInfoW 関数</span><span class="sxs-lookup"><span data-stu-id="a3ea8-205">GetCalendarInfoW function</span></span>](https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcalendarinfow)

## <a name="see-also"></a><span data-ttu-id="a3ea8-206">関連項目</span><span class="sxs-lookup"><span data-stu-id="a3ea8-206">See also</span></span>

* [<span data-ttu-id="a3ea8-207">日本語のカレンダーの処理に時代 (年号)。</span><span class="sxs-lookup"><span data-stu-id="a3ea8-207">Era Handling for the Japanese Calendar</span></span>](https://docs.microsoft.com/windows/desktop/Intl/era-handling-for-the-japanese-calendar)
* [<span data-ttu-id="a3ea8-208">日本語のカレンダーの Y2K 時点</span><span class="sxs-lookup"><span data-stu-id="a3ea8-208">The Japanese Calendar’s Y2K Moment</span></span>](https://blogs.msdn.microsoft.com/shawnste/2018/04/12/the-japanese-calendars-y2k-moment/)
* [<span data-ttu-id="a3ea8-209">レジストリを使用して、Windows の新しい日本語時代 (年号) をテストするには</span><span class="sxs-lookup"><span data-stu-id="a3ea8-209">Using the Registry to Test the New Japanese Era on Windows</span></span>](https://blogs.msdn.microsoft.com/shawnste/2018/08/07/using-the-registry-to-test-the-new-japanese-era-on-windows/)
* [<span data-ttu-id="a3ea8-210">元年 vs Ichinen</span><span class="sxs-lookup"><span data-stu-id="a3ea8-210">Gannen vs Ichinen</span></span>](https://blogs.msdn.microsoft.com/shawnste/2018/11/12/gannen-vs-ichinen/)
* [<span data-ttu-id="a3ea8-211">更新プログラムの可能性があります 2019年日本の時代 (年号) の変更</span><span class="sxs-lookup"><span data-stu-id="a3ea8-211">Updates for May 2019 Japan Era Change</span></span>](https://support.microsoft.com/help/4470918/updates-for-may-2019-japan-era-change)
* [<span data-ttu-id="a3ea8-212">.NET での日本語のカレンダーで新しい時代 (年号) の処理</span><span class="sxs-lookup"><span data-stu-id="a3ea8-212">Handling a new era in the Japanese calendar in .NET</span></span>](https://blogs.msdn.microsoft.com/dotnet/2018/11/14/handling-a-new-era-in-the-japanese-calendar-in-net/)