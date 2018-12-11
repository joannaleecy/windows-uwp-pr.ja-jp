---
description: サポートされている最新の Microsoft Advertising ライブラリを使用し、アプリで引き続きバナー広告を受信できるように、アプリを更新する方法について説明します。
title: バナー広告用の最新の Advertising ライブラリを使用するようにアプリを更新する
ms.date: 08/23/2017
ms.topic: article
keywords: Windows 10, UWP, 広告, 宣伝, AdControl, AdMediatorControl, 移行
ms.assetid: f8d5b2ad-fcdb-4891-bd68-39eeabdf799c
ms.localizationpriority: medium
ms.openlocfilehash: adac5cfdb1b4a10674fb7173e5b84a86b509f130
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8920169"
---
# <a name="update-your-app-to-the-latest-advertising-libraries-for-banner-ads"></a><span data-ttu-id="5d42f-104">バナー広告用の最新の Advertising ライブラリを使用するようにアプリを更新する</span><span class="sxs-lookup"><span data-stu-id="5d42f-104">Update your app to the latest advertising libraries for banner ads</span></span>

<span data-ttu-id="5d42f-105">2017 年 4 月 1 日の時点で、サポートされていない広告 SDK リリースを使うアプリにはバナー広告が提供されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="5d42f-105">As of April 1, 2017, we no longer serve banner ads to apps that use an unsupported advertising SDK release.</span></span> <span data-ttu-id="5d42f-106">ユニバーサル Windows プラットフォーム (UWP) アプリで **AdControl** を使用してバナー広告を表示している場合、この記事の情報を使用して、サポートされていない広告 SDK を使用しているかどうかを判断し、アプリをサポートされる SDK に移行します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-106">If you use **AdControl** to display banner ads in your Universal Windows Platform (UWP) app, use the information in this article to determine whether you are using an unsupported advertising SDK and migrate your app to a supported SDK.</span></span>

## <a name="overview"></a><span data-ttu-id="5d42f-107">概要</span><span class="sxs-lookup"><span data-stu-id="5d42f-107">Overview</span></span>

<span data-ttu-id="5d42f-108">バナー広告を表示する UWP アプリでは、[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) で配布されている Advertising ライブラリの **AdControl** を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-108">UWP apps that show banner ads must use **AdControl** from the advertising libraries that are distributed in the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span> <span data-ttu-id="5d42f-109">この SDK では、Interactive Advertising Bureau (IAB) の [Mobile Rich-media Ad Interface Definitions (MRAID) 1.0 仕様](http://www.iab.com/wp-content/uploads/2015/08/IAB_MRAID_VersionOne.pdf)を通じた HTML5 リッチ メディアの提供機能など、最小限の広告機能セットがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5d42f-109">This SDK supports a minimum set of advertising capabilities, including the ability to serve HTML5 rich media via the [Mobile Rich-media Ad Interface Definitions (MRAID) 1.0 specification](http://www.iab.com/wp-content/uploads/2015/08/IAB_MRAID_VersionOne.pdf) from the Interactive Advertising Bureau (IAB).</span></span> <span data-ttu-id="5d42f-110">多くの広告主様がこれらの機能を必要とされており、Microsoft ではアプリ開発者にこれらのいずれかの SDK リリースの使用を求めることで、より魅力的なアプリのエコシステムを広告主様に提供し、開発者様の収益アップを図ります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-110">Many of our advertisers seek these capabilities, and we require app developers to use one of these SDK releases to help make our app ecosystem more attractive to advertisers and ultimately drive more revenue to you.</span></span>

<span data-ttu-id="5d42f-111">この SDK をリリースする前に、いくつかの古い広告 SDK リリースで **AdControl** クラスを提供していました。</span><span class="sxs-lookup"><span data-stu-id="5d42f-111">Before this SDK was released, we previously provided the **AdControl** class in several older advertising SDK releases.</span></span> <span data-ttu-id="5d42f-112">これらの以前の広告 SDK リリースは、上記で説明した最小限の広告機能をサポートしていないため、サポートされなくなりました。</span><span class="sxs-lookup"><span data-stu-id="5d42f-112">These older advertising SDK releases are no longer supported because they do not support the minimum advertising capabilities described above.</span></span> <span data-ttu-id="5d42f-113">2017 年 4 月 1 日の時点で、サポートされていない広告 SDK リリースを使うアプリにはバナー広告が提供されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="5d42f-113">As of April 1, 2017, we no longer serve banner ads to apps that use an unsupported advertising SDK release.</span></span> <span data-ttu-id="5d42f-114">サポートされていない広告 SDK リリースを使うアプリがまだある場合、次の動作が発生します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-114">If you have an app that still uses an unsupported advertising SDK release, you will see the following behavior:</span></span>

* <span data-ttu-id="5d42f-115">アプリ内の **AdControl** コントロールにバナー広告が提供されず、これらのコントロールから広告収入を得ることができなくなります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-115">Banner ads will no longer be served to any **AdControl** in your app, and you will no longer earn advertising revenue from those controls.</span></span>

* <span data-ttu-id="5d42f-116">アプリ内の **AdControl** から新しい広告が要求されると、コントロールの **ErrorOccurred** イベントが発生し、イベント引数の **ErrorCode** プロパティに **NoAdAvailable** という値が設定されます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-116">When the **AdControl** in your app requests a new ad, the **ErrorOccurred** event of the control will be raised and the **ErrorCode** property of the event args will have the value **NoAdAvailable**.</span></span>

* <span data-ttu-id="5d42f-117">そのアプリに関連付けられているすべての広告ユニットが非アクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-117">Any ad units that are associated with your app will be deactivated.</span></span> <span data-ttu-id="5d42f-118">これらの非アクティブ化された広告ユニットは、DePartnerv センター アカウントから削除することはできません。</span><span class="sxs-lookup"><span data-stu-id="5d42f-118">You cannot remove these deactivated ad units from your DePartnerv Center account.</span></span> <span data-ttu-id="5d42f-119">アプリを更新して [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) を使う場合、これらの広告ユニットを無視して新しい広告ユニットを作成します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-119">If you update your app to use the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp), ignore these ad units and create new ones.</span></span>

* <span data-ttu-id="5d42f-120">複数のアプリで使われている広告ユニットにも、バナー広告が提供されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="5d42f-120">Banner ads will also no longer be served for any ad unit that is used in more than one app.</span></span> <span data-ttu-id="5d42f-121">広告ユニットがそれぞれ 1 つのアプリだけで使われるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="5d42f-121">Make sure that your ad units are each used in only one app.</span></span>

<span data-ttu-id="5d42f-122">**AdControl** を使ってバナーを表示するアプリ (Microsoft Store に公開済みまたは開発中) が既にあり、アプリにより使われている広告 SDK がわからない場合は、この記事の手順に従って、アプリをサポートされている SDK に更新する必要があるかどうかを判断してください。</span><span class="sxs-lookup"><span data-stu-id="5d42f-122">If you have an existing app (already in the Store or still under development) that displays banner ads using **AdControl** and you aren't sure which advertising SDK is being used by your app, follow the instructions in this article to determine whether you need to update your app to a supported SDK.</span></span> <span data-ttu-id="5d42f-123">問題が発生した場合やサポートが必要な場合は、[サポートにお問い合わせください](http://go.microsoft.com/fwlink/?LinkId=393643)。</span><span class="sxs-lookup"><span data-stu-id="5d42f-123">If you encounter any issues or you need assistance, please [contact support](http://go.microsoft.com/fwlink/?LinkId=393643).</span></span>

> [!NOTE]
> <span data-ttu-id="5d42f-124">アプリが既に [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (UWP アプリ用) を使用している場合、アプリをさらに変更を加える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5d42f-124">If your app already uses the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) (for UWP apps), you do not need to make any further changes to your app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="5d42f-125">前提条件</span><span class="sxs-lookup"><span data-stu-id="5d42f-125">Prerequisites</span></span>

* <span data-ttu-id="5d42f-126">**AdControl** を使用しているアプリの完全なソース コードおよび Visual Studio プロジェクト ファイル。</span><span class="sxs-lookup"><span data-stu-id="5d42f-126">The complete source code and Visual Studio project files for your app that uses **AdControl**.</span></span>
* <span data-ttu-id="5d42f-127">アプリの .appx パッケージ。</span><span class="sxs-lookup"><span data-stu-id="5d42f-127">The .appx package for your app.</span></span>

> [!NOTE]
> <span data-ttu-id="5d42f-128">アプリの .appx パッケージがなくなっていても、このアプリの構築に使用したバージョンの Visual Studio と Advertising SDK がインストールされた状態の開発用コンピューターがあれば、Visual Studio で .appx パッケージを再生成できます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-128">If you no longer have the .appx package for your app but you do still have a development computer with the version of Visual Studio and the advertising SDK that was used to build your app, you can regenerate the .appx package in Visual Studio.</span></span>

<span id="part-1" />

## <a name="part-1-determine-whether-you-need-to-update-your-uwp-app"></a><span data-ttu-id="5d42f-129">パート 1: UWP アプリを更新する必要があるかどうかを決定する</span><span class="sxs-lookup"><span data-stu-id="5d42f-129">Part 1: Determine whether you need to update your UWP app</span></span>

<span data-ttu-id="5d42f-130">以下のセクションの手順に従い、アプリの更新が必要かどうかを調べます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-130">Follow the instructions in the following sections to determine if you need to update your app.</span></span>

1. <span data-ttu-id="5d42f-131">元のファイルを損なわないようにアプリの .appx パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-131">Create a copy of the .appx package for your app so you do not disturb the original, rename the copy so it has a .zip extension, and extract the contents of the file.</span></span>

2. <span data-ttu-id="5d42f-132">アプリ パッケージから抽出した内容を確認します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-132">Check the extracted contents of your app package:</span></span>
  * <span data-ttu-id="5d42f-133">Microsoft.Advertising.dll ファイルがある場合は、アプリで以前の SDK が使用されているため、以下のセクションの手順に従ってプロジェクトを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-133">If you see a Microsoft.Advertising.dll file, your app uses an old SDK and you must update your project by following the instructions in the sections below.</span></span> <span data-ttu-id="5d42f-134">[パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-134">Proceed to [Part 2](update-your-app-to-the-latest-advertising-libraries.md#part-2).</span></span>
  * <span data-ttu-id="5d42f-135">Microsoft.Advertising.dll ファイルがない場合は、最新の利用可能な Advertising SDK が既に UWP アプリで使用されているため、プロジェクトに変更を加える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="5d42f-135">If you do not see a Microsoft.Advertising.dll file, your UWP app already uses the latest available advertising SDK and you do not need to make any changes to your project.</span></span>


<span id="part-2" />

## <a name="part-2-install-the-latest-sdk"></a><span data-ttu-id="5d42f-136">パート 2: 最新の SDK をインストールする</span><span class="sxs-lookup"><span data-stu-id="5d42f-136">Part 2: Install the latest SDK</span></span>

<span data-ttu-id="5d42f-137">アプリで以前の SDK リリースが使用されている場合は、次の手順に従って、開発用コンピューターに最新の SDK がインストールされているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-137">If your app uses an old SDK release, follow these instructions to make sure you have the latest SDK on your development computer.</span></span>

1. <span data-ttu-id="5d42f-138">開発用コンピューターに Visual Studio 2015 以降のリリースがインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-138">Make sure your development computer has Visual Studio 2015 or a later release installed.</span></span>
    > [!NOTE]
    > <span data-ttu-id="5d42f-139">開発用コンピューターで Visual Studio が開いている場合は、閉じてから、以下の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-139">If Visual Studio is open on your development computer, close it before you perform the following steps.</span></span>

1.  <span data-ttu-id="5d42f-140">開発用コンピューターから、以前のバージョンの Microsoft Advertising SDK および Ad Mediator SDK をアンインストールします。</span><span class="sxs-lookup"><span data-stu-id="5d42f-140">Uninstall all prior versions of the Microsoft Advertising SDK and Ad Mediator SDK from your development computer.</span></span>

2.  <span data-ttu-id="5d42f-141">**コマンド プロンプト** ウィンドウを開き、次のコマンドを実行することによって、Visual Studio と共にインストールされている以前の SDK のバージョンをすべて削除します。これらのバージョンは、コンピューターにインストールされているプログラムの一覧には表示されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-141">Open a **Command Prompt** window and run these commands to clean out any SDK versions that may have been installed with Visual Studio, but which may not appear in the list of installed programs on your computer:</span></span>
    ```syntax
    MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
    MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
    MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
    ```

3.  <span data-ttu-id="5d42f-142">[Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="5d42f-142">Install the [Microsoft Advertising SDK](http://aka.ms/ads-sdk-uwp).</span></span>

## <a name="part-3-update-your-project"></a><span data-ttu-id="5d42f-143">パート 3: プロジェクトを更新する</span><span class="sxs-lookup"><span data-stu-id="5d42f-143">Part 3: Update your project</span></span>

<span data-ttu-id="5d42f-144">プロジェクトから Microsoft Advertising ライブラリへの既存の参照をすべて削除し、[これらの手順](install-the-microsoft-advertising-libraries.md#reference)に従って、必要な参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-144">Remove all existing references to the Microsoft advertising libraries from the project and follow [these instructions](install-the-microsoft-advertising-libraries.md#reference) to add the required references.</span></span> <span data-ttu-id="5d42f-145">これにより、プロジェクトで適切なライブラリが確実に使用されるようになります。</span><span class="sxs-lookup"><span data-stu-id="5d42f-145">This will ensure that your project uses the correct libraries.</span></span> <span data-ttu-id="5d42f-146">既存のマークアップとコードを保持することもできます。</span><span class="sxs-lookup"><span data-stu-id="5d42f-146">You can preserve your existing markup and code.</span></span>

## <a name="part-4-test-and-republish-your-app"></a><span data-ttu-id="5d42f-147">パート 4: アプリのテストと再公開を行う</span><span class="sxs-lookup"><span data-stu-id="5d42f-147">Part 4: Test and republish your app</span></span>

<span data-ttu-id="5d42f-148">アプリをテストし、バナーが正常に提供されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-148">Test your app to make sure it displays banner ads as expected.</span></span>

<span data-ttu-id="5d42f-149">アプリの以前のバージョンがある場合既にストアにアプリを再公開するパートナー センターで、更新されたアプリの[新しい申請を作成](../publish/app-submissions.md)します。</span><span class="sxs-lookup"><span data-stu-id="5d42f-149">If the previous version of your app is already available in the Store, [create a new submission](../publish/app-submissions.md) for your updated app in Partner Center to republish your app.</span></span>
