---
Description: アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c75eb1a4b28b015b83557f74957a3370f478a26e
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63790774"
---
# <a name="guidance-for-app-package-management"></a><span data-ttu-id="d85a8-104">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="d85a8-104">Guidance for app package management</span></span>

<span data-ttu-id="d85a8-105">アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-105">Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.</span></span>

-   [<span data-ttu-id="d85a8-106">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="d85a8-106">OS versions and package distribution</span></span>](#os-versions-and-package-distribution)
-   [<span data-ttu-id="d85a8-107">以前に発行アプリを Windows 10 用のパッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-107">Adding packages for Windows 10 to a previously-published app</span></span>](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [<span data-ttu-id="d85a8-108">Windows Phone 8.1 用パッケージの互換性の維持</span><span class="sxs-lookup"><span data-stu-id="d85a8-108">Maintaining package compatibility for Windows Phone 8.1</span></span>](#maintaining-package-compatibility-for-windows-phone-81)
-   [<span data-ttu-id="d85a8-109">ストアからアプリを削除します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-109">Removing an app from the Store</span></span>](#removing-an-app-from-the-store)
-   [<span data-ttu-id="d85a8-110">以前でサポートされているデバイス ファミリ用のパッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-110">Removing packages for a previously-supported device family</span></span>](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a><span data-ttu-id="d85a8-111">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="d85a8-111">OS versions and package distribution</span></span>

<span data-ttu-id="d85a8-112">さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-112">Different operating systems can run different types of packages.</span></span> <span data-ttu-id="d85a8-113">ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-113">If more than one of your packages can run on a customer's device, the Microsoft Store will provide the best available match.</span></span>

<span data-ttu-id="d85a8-114">一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-114">Generally speaking, later OS versions can run packages that target previous OS versions for the same device family.</span></span> <span data-ttu-id="d85a8-115">Windows 10 デバイスは、すべてサポートされている OS バージョン (デバイス ファミリ) ごとに実行できます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-115">Windows 10 devices can run all previous supported OS versions (per device family).</span></span> <span data-ttu-id="d85a8-116">Windows 10 デスクトップ デバイスは、Windows 8.1 または Windows 8 用にビルドしたアプリを実行できます。Windows 10 mobile デバイスは、Windows Phone 8.1、Windows Phone 8、およびでも Windows Phone 用にビルドしたアプリを実行できる 7.x。</span><span class="sxs-lookup"><span data-stu-id="d85a8-116">Windows 10 desktop devices can run apps that were built for Windows 8.1 or Windows 8; Windows 10 mobile devices can run apps that were built for Windows Phone 8.1, Windows Phone 8, and even Windows Phone 7.x.</span></span> <span data-ttu-id="d85a8-117">ただし、アプリに適用可能なデバイス ファミリを対象とする UWP パッケージが含まれていない場合、Windows 10 でのお客様はそれらのパッケージを取得のみです。</span><span class="sxs-lookup"><span data-stu-id="d85a8-117">However, customers on Windows 10 will only get those packages if the app doesn't include UWP packages targeting the applicable device family.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d85a8-118">2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。</span><span class="sxs-lookup"><span data-stu-id="d85a8-118">As of October 31, 2018, newly-created products cannot include packages targeting Windows 8.x/Windows Phone 8.x or earlier.</span></span> <span data-ttu-id="d85a8-119">詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/)します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-119">For more info, see this [blog post](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/).</span></span>


## <a name="removing-an-app-from-the-store"></a><span data-ttu-id="d85a8-120">アプリを Microsoft Store から削除する</span><span class="sxs-lookup"><span data-stu-id="d85a8-120">Removing an app from the Store</span></span>

<span data-ttu-id="d85a8-121">ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="d85a8-121">At times, you may want to stop offering an app to customers, effectively "unpublishing" it.</span></span> <span data-ttu-id="d85a8-122">これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d85a8-122">To do so, click **Make app unavailable** from the **App overview** page.</span></span> <span data-ttu-id="d85a8-123">アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。</span><span class="sxs-lookup"><span data-stu-id="d85a8-123">After you confirm that you want to make the app unavailable, within a few hours it will no longer be visible in the Store, and no new customers will be able to get it (unless they have a [promotional code](generate-promotional-codes.md) and are using a Windows 10 device).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d85a8-124">このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-124">This option will override any [visibility](choose-visibility-options.md#discoverability) settings that you have selected in your submissions.</span></span> 

<span data-ttu-id="d85a8-125">このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。</span><span class="sxs-lookup"><span data-stu-id="d85a8-125">This option has the same effect as if you created a submission and chose **Make this product available but not discoverable in the Store** with the **Stop acquisition** option.</span></span> <span data-ttu-id="d85a8-126">ただし、新しい申請を作成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="d85a8-126">However, it does not require you to create a new submission.</span></span>

<span data-ttu-id="d85a8-127">アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。</span><span class="sxs-lookup"><span data-stu-id="d85a8-127">Note that any customers who already have the app will still be able to use it and can download it again (and could even get updates if you submit new packages later).</span></span>

<span data-ttu-id="d85a8-128">アプリを利用できないようにした後でもわかります、パートナー センターで。</span><span class="sxs-lookup"><span data-stu-id="d85a8-128">After making the app unavailable, you'll still see it in Partner Center.</span></span> <span data-ttu-id="d85a8-129">アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d85a8-129">If you decide to offer the app to customers again, you can click **Make app available** from the App overview page.</span></span> <span data-ttu-id="d85a8-130">確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="d85a8-130">After you confirm, the app will be available to new customers (unless restricted by the settings in your last submission) within a few hours.</span></span>

> [!NOTE]
> <span data-ttu-id="d85a8-131">アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-131">If you want to keep your app available, but don't want to continuing offering it to new customers on a particular OS version, you can create a new submission and remove all packages for the OS version on which you want to prevent new acquisitions.</span></span> <span data-ttu-id="d85a8-132">たとえば、Windows Phone 8.1 および Windows 10 では、パッケージが以前アプリケーションを Windows Phone 8.1 で新規のお客様に提供を保持したくない場合は、すべての Windows Phone 8.1 パッケージから削除、送信します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-132">For example, if you previously had packages for Windows Phone 8.1 and Windows 10, and you don't want to keep offering the app to new customers on Windows Phone 8.1, remove all of your Windows Phone 8.1 packages from the submission.</span></span> <span data-ttu-id="d85a8-133">更新プログラムがパブリッシュされると、Windows Phone 8.1 で新規のお客様はされないことを既にお持ちのお客様を引き続き使用できますが、アプリを取得できません)。</span><span class="sxs-lookup"><span data-stu-id="d85a8-133">After the update is published, no new customers on Windows Phone 8.1 will be able to acquire the app though customers who already have it can continue to use it).</span></span> <span data-ttu-id="d85a8-134">ただし、アプリは Windows 10 の新しいお客様に利用できます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-134">However, the app will still be available for new customers on Windows 10.</span></span>


## <a name="removing-packages-for-a-previously-supported-device-family"></a><span data-ttu-id="d85a8-135">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="d85a8-135">Removing packages for a previously-supported device family</span></span>

<span data-ttu-id="d85a8-136">特定のすべてのパッケージを削除する場合[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされていることを求められますの変更を保存する前に、意図したものは、このことを確認する、**パッケージ**ページ。</span><span class="sxs-lookup"><span data-stu-id="d85a8-136">If you remove all packages for a certain [device family](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview) that your app previously supported, you'll be prompted to confirm that this is your intention before you can save your changes on the **Packages** page.</span></span>

<span data-ttu-id="d85a8-137">すべてのアプリは以前はサポートされているデバイス ファミリで実行できるパッケージを削除するための送信を発行するときに、新規のお客様はそのデバイス ファミリでアプリを取得できません。</span><span class="sxs-lookup"><span data-stu-id="d85a8-137">When you publish a submission that removes all of the packages that could run on a device family that your app previously supported, new customers will not be able to acquire the app on that device family.</span></span> <span data-ttu-id="d85a8-138">そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。</span><span class="sxs-lookup"><span data-stu-id="d85a8-138">You can always publish another update later to provide packages for that device family again.</span></span>

<span data-ttu-id="d85a8-139">特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。</span><span class="sxs-lookup"><span data-stu-id="d85a8-139">Be aware that even if you remove all of the packages that support a certain device family, any existing customers who have already installed the app on that type of device can still use it, and they will get any updates you provide later.</span></span>


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a><span data-ttu-id="d85a8-140">以前に発行アプリを Windows 10 用のパッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="d85a8-140">Adding packages for Windows 10 to a previously-published app</span></span>

<span data-ttu-id="d85a8-141">Windows 用のみのパッケージに含まれるストアにアプリがあるかどうか 8.x および Windows Phone 8.x、し、Windows 10 用のアプリを更新し、新しい提出パッケージを作成し、UWP .msixupload または .appxupload パッケージ中を追加する、[パッケージ](upload-app-packages.md)手順。</span><span class="sxs-lookup"><span data-stu-id="d85a8-141">If you have an app in the Store that only included packages for Windows 8.x and/or Windows Phone 8.x, and you want to update your app for Windows 10, create a new submission and add your UWP .msixupload or .appxupload package(s) during the [Packages](upload-app-packages.md) step.</span></span> <span data-ttu-id="d85a8-142">アプリが認定プロセスを通過した後は、UWP パッケージは Windows 10 でのお客様が新しい取得に使用可能なあります。</span><span class="sxs-lookup"><span data-stu-id="d85a8-142">After your app goes through the certification process, the UWP package will also be available for new acquisitions by customers on Windows 10.</span></span>

> [!NOTE]
> <span data-ttu-id="d85a8-143">Windows 10 で、顧客が、UWP パッケージを取得すると、以前の OS バージョンのパッケージを使用するようにその顧客をロールすることはできません。</span><span class="sxs-lookup"><span data-stu-id="d85a8-143">Once a customer on Windows 10 gets your UWP package, you can't roll that customer back to using a package for any previous OS version.</span></span> 

<span data-ttu-id="d85a8-144">Windows 10 パッケージのバージョン番号を使用した Windows 8、Windows 8.1、および Windows Phone 8.1 のパッケージの場合よりも高いでなければならないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d85a8-144">Note that the version number of your Windows 10 packages must be higher than those for any Windows 8, Windows 8.1, and/or Windows Phone 8.1 packages you have used.</span></span> <span data-ttu-id="d85a8-145">詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d85a8-145">For more info, see [Package version numbering](package-version-numbering.md).</span></span>

<span data-ttu-id="d85a8-146">Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d85a8-146">For more info about packaging UWP apps for the Store, see [Packaging apps](../packaging/index.md).</span></span>
