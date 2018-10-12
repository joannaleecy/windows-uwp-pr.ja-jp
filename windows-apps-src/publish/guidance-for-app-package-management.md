---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 10/02/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a43f3b4c5684d93ea6986c4d1f1e4dae46c1a959
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4540106"
---
# <a name="guidance-for-app-package-management"></a><span data-ttu-id="22315-103">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="22315-103">Guidance for app package management</span></span>

<span data-ttu-id="22315-104">アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="22315-104">Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.</span></span>

-   [<span data-ttu-id="22315-105">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="22315-105">OS versions and package distribution</span></span>](#os-versions-and-package-distribution)
-   [<span data-ttu-id="22315-106">以前に公開したアプリに Windows 10 用のパッケージを追加する</span><span class="sxs-lookup"><span data-stu-id="22315-106">Adding packages for Windows 10 to a previously-published app</span></span>](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [<span data-ttu-id="22315-107">Windows Phone 8.1 に対するパッケージの互換性を維持する</span><span class="sxs-lookup"><span data-stu-id="22315-107">Maintaining package compatibility for Windows Phone 8.1</span></span>](#maintaining-package-compatibility-for-windows-phone-81)
-   [<span data-ttu-id="22315-108">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="22315-108">Removing an app from the Store</span></span>](#removing-an-app-from-the-store)
-   [<span data-ttu-id="22315-109">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="22315-109">Removing packages for a previously-supported device family</span></span>](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a><span data-ttu-id="22315-110">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="22315-110">OS versions and package distribution</span></span>

<span data-ttu-id="22315-111">さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="22315-111">Different operating systems can run different types of packages.</span></span> <span data-ttu-id="22315-112">ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。</span><span class="sxs-lookup"><span data-stu-id="22315-112">If more than one of your packages can run on a customer's device, the Microsoft Store will provide the best available match.</span></span>

<span data-ttu-id="22315-113">一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="22315-113">Generally speaking, later OS versions can run packages that target previous OS versions for the same device family.</span></span> <span data-ttu-id="22315-114">ただし、アプリには、現在の OS バージョンをターゲットとするパッケージが含まれていない場合、ユーザーはそれらのパッケージを取得のみです。</span><span class="sxs-lookup"><span data-stu-id="22315-114">However, customers will only get those packages if the app doesn't include a package that targets their current OS version.</span></span>

<span data-ttu-id="22315-115">たとえば、Windows 10 デバイスでは、(デバイス ファミリごとに) サポートされている以前の OS のバージョンをすべて実行できます。</span><span class="sxs-lookup"><span data-stu-id="22315-115">For example, Windows 10 devices can run all previous supported OS versions (per device family).</span></span> <span data-ttu-id="22315-116">Windows 10 のデスクトップ デバイスでは Windows 8.1 または Windows 8 用に構築されたアプリを実行でき、Windows 10 のモバイル デバイスでは Windows Phone 8.1、Windows Phone 8、さらには Windows Phone 7.x 用に構築されたアプリまで実行できます。</span><span class="sxs-lookup"><span data-stu-id="22315-116">Windows 10 desktop devices can run apps that were built for Windows 8.1 or Windows 8; Windows 10 mobile devices can run apps that were built for Windows Phone 8.1, Windows Phone 8, and even Windows Phone 7.x.</span></span> 

<span data-ttu-id="22315-117">以下の例では、複数の OS バージョンをターゲットとするパッケージなど、アプリのさまざまなシナリオについて説明します。ただし、パッケージ特有の制約によって、ここに示したすべての OS バージョンとデバイスの種類で実行できないことがあります (デバイスでパッケージのアーキテクチャが特定のものである必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="22315-117">The following examples illustrate various scenarios for an app that includes packages targeting different OS versions (unless specific constraints of your packages don't allow them to run on every OS version/device type listed here; for example, the package's architecture must be appropriate for the device).</span></span> 

### <a name="example-app-1"></a><span data-ttu-id="22315-118">アプリ例 1</span><span class="sxs-lookup"><span data-stu-id="22315-118">Example app 1</span></span>

| <span data-ttu-id="22315-119">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-119">Package's targeted operating system</span></span> | <span data-ttu-id="22315-120">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-120">Operating systems that will get this package</span></span> |
|-------------------------------------|----------------------------------------------|
| <span data-ttu-id="22315-121">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-121">Windows 8.1</span></span>                         | <span data-ttu-id="22315-122">Windows 10 デスクトップ デバイス、Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-122">Windows 10 desktop devices, Windows 8.1</span></span>      |
| <span data-ttu-id="22315-123">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-123">Windows Phone 8.1</span></span>                   | <span data-ttu-id="22315-124">Windows 10 モバイル デバイス、Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-124">Windows 10 mobile devices, Windows Phone 8.1</span></span> |
| <span data-ttu-id="22315-125">Windows Phone 8</span><span class="sxs-lookup"><span data-stu-id="22315-125">Windows Phone 8</span></span>                     | <span data-ttu-id="22315-126">Windows Phone 8</span><span class="sxs-lookup"><span data-stu-id="22315-126">Windows Phone 8</span></span>                              |
| <span data-ttu-id="22315-127">Windows Phone 7.1</span><span class="sxs-lookup"><span data-stu-id="22315-127">Windows Phone 7.1</span></span>                   | <span data-ttu-id="22315-128">Windows Phone 7.x</span><span class="sxs-lookup"><span data-stu-id="22315-128">Windows Phone 7.x</span></span>                            |

<span data-ttu-id="22315-129">アプリ例 1 のアプリには Windows 10 デバイス用に特別に構築されたユニバーサル Windows プラットフォーム (UWP) パッケージがまだありませんが、Windows 10 のユーザーはこのアプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="22315-129">In example app 1, the app does not yet have Universal Windows Platform (UWP) packages that are specifically built for Windows 10 devices, but customers on Windows 10 can still get the app.</span></span> <span data-ttu-id="22315-130">ユーザーはデバイスの種類で使用できる最適なパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="22315-130">Those customers will get the best packages available for their device type.</span></span>

### <a name="example-app-2"></a><span data-ttu-id="22315-131">アプリ例 2</span><span class="sxs-lookup"><span data-stu-id="22315-131">Example app 2</span></span>

| <span data-ttu-id="22315-132">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-132">Package's targeted operating system</span></span>  | <span data-ttu-id="22315-133">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-133">Operating systems that will get this package</span></span> |
|--------------------------------------|----------------------------------------------|
| <span data-ttu-id="22315-134">Windows 10 (ユニバーサル デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="22315-134">Windows 10 (universal device family)</span></span> | <span data-ttu-id="22315-135">Windows 10 (すべてのデバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="22315-135">Windows 10 (all device families)</span></span>             |
| <span data-ttu-id="22315-136">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-136">Windows 8.1</span></span>                          | <span data-ttu-id="22315-137">Windows 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-137">Windows 8.1</span></span>                                  |
| <span data-ttu-id="22315-138">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-138">Windows Phone 8.1</span></span>                    | <span data-ttu-id="22315-139">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-139">Windows Phone 8.1</span></span>                            |
| <span data-ttu-id="22315-140">Windows Phone 7.1</span><span class="sxs-lookup"><span data-stu-id="22315-140">Windows Phone 7.1</span></span>                    | <span data-ttu-id="22315-141">Windows Phone 7.x、Windows Phone 8</span><span class="sxs-lookup"><span data-stu-id="22315-141">Windows Phone 7.x, Windows Phone 8</span></span>           |

<span data-ttu-id="22315-142">アプリ例 2 では、Windows 8 で実行可能なパッケージはありません。</span><span class="sxs-lookup"><span data-stu-id="22315-142">In example app 2, there is no package that can run on Windows 8.</span></span> <span data-ttu-id="22315-143">他のすべての OS バージョンを実行しているユーザーは、アプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="22315-143">Customers who are running any other OS version can get the app.</span></span> <span data-ttu-id="22315-144">Windows 10 でのすべてのお客様は、同じパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="22315-144">All customers on Windows 10 will get the same package.</span></span>

### <a name="example-app-3"></a><span data-ttu-id="22315-145">アプリ例 3</span><span class="sxs-lookup"><span data-stu-id="22315-145">Example app 3</span></span>

| <span data-ttu-id="22315-146">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-146">Package's targeted operating system</span></span> | <span data-ttu-id="22315-147">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-147">Operating systems that will get this package</span></span>                  |
|-------------------------------------|---------------------------------------------------------------|
| <span data-ttu-id="22315-148">Windows 10 (デスクトップ デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="22315-148">Windows 10 (desktop device family)</span></span>  | <span data-ttu-id="22315-149">Windows 10 デスクトップ デバイス</span><span class="sxs-lookup"><span data-stu-id="22315-149">Windows 10 desktop devices</span></span>                                    |
| <span data-ttu-id="22315-150">Windows Phone 8</span><span class="sxs-lookup"><span data-stu-id="22315-150">Windows Phone 8</span></span>                     | <span data-ttu-id="22315-151">Windows 10 モバイル デバイス、Windows Phone 8、Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="22315-151">Windows 10 mobile devices, Windows Phone 8, Windows Phone 8.1</span></span> |

<span data-ttu-id="22315-152">アプリ例 3 では、モバイル デバイス ファミリを対象にした UWP パッケージがないため、Windows 10 モバイル デバイスのユーザーは Windows Phone 8 パッケージを取得することになります。</span><span class="sxs-lookup"><span data-stu-id="22315-152">In example app 3, since there is no UWP package that targets the mobile device family, customers on Windows 10 mobile devices will get the Windows Phone 8 package.</span></span> <span data-ttu-id="22315-153">モバイル デバイス ファミリ (またはユニバーサル デバイス ファミリ) を対象とするパッケージがこのアプリに後で追加される場合、Windows Phone 8 パッケージの代わりにそのパッケージが Windows 10 モバイル デバイスのユーザーに提供されます。</span><span class="sxs-lookup"><span data-stu-id="22315-153">If this app later adds a package that targets the mobile device family (or the universal device family), that package will then be available to customers on Windows 10 mobile devices instead of the Windows Phone 8 package.</span></span>

<span data-ttu-id="22315-154">また、このアプリ例には Windows Phone 7.x で実行可能なパッケージが含まれていない点にも注目してください。</span><span class="sxs-lookup"><span data-stu-id="22315-154">Also note that this example app does not include any package that can run on Windows Phone 7.x.</span></span>

### <a name="example-app-4"></a><span data-ttu-id="22315-155">アプリ例 4</span><span class="sxs-lookup"><span data-stu-id="22315-155">Example app 4</span></span>

| <span data-ttu-id="22315-156">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-156">Package's targeted operating system</span></span>  | <span data-ttu-id="22315-157">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="22315-157">Operating systems that will get this package</span></span> |
|--------------------------------------|----------------------------------------------|
| <span data-ttu-id="22315-158">Windows 10 (ユニバーサル デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="22315-158">Windows 10 (universal device family)</span></span> | <span data-ttu-id="22315-159">Windows 10 (すべてのデバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="22315-159">Windows 10 (all device families)</span></span>             |

<span data-ttu-id="22315-160">アプリ例 4 では、Windows 10 を実行しているデバイスではアプリを入手することができますが、以前の OS バージョンのユーザーは利用できません。</span><span class="sxs-lookup"><span data-stu-id="22315-160">In example app 4, any device that is running Windows 10 can get the app, but it will not be available to customers on any previous OS version.</span></span> <span data-ttu-id="22315-161">UWP パッケージがユニバーサル デバイス ファミリを対象としているために、すべての Windows 10 デバイス (ごとに、[デバイス ファミリの利用可否選択](device-family-availability.md)) を利用可能ななります。</span><span class="sxs-lookup"><span data-stu-id="22315-161">Because the UWP package targets the universal device family, it will be available to any Windows 10 device (per your [device family availability selections](device-family-availability.md)).</span></span>


## <a name="removing-an-app-from-the-store"></a><span data-ttu-id="22315-162">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="22315-162">Removing an app from the Store</span></span>

<span data-ttu-id="22315-163">ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="22315-163">At times, you may want to stop offering an app to customers, effectively "unpublishing" it.</span></span> <span data-ttu-id="22315-164">これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22315-164">To do so, click **Make app unavailable** from the **App overview** page.</span></span> <span data-ttu-id="22315-165">アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。</span><span class="sxs-lookup"><span data-stu-id="22315-165">After you confirm that you want to make the app unavailable, within a few hours it will no longer be visible in the Store, and no new customers will be able to get it (unless they have a [promotional code](generate-promotional-codes.md) and are using a Windows 10 device).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="22315-166">このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="22315-166">This option will override any [visibility](choose-visibility-options.md#discoverability) settings that you have selected in your submissions.</span></span> 

<span data-ttu-id="22315-167">このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。</span><span class="sxs-lookup"><span data-stu-id="22315-167">This option has the same effect as if you created a submission and chose **Make this product available but not discoverable in the Store** with the **Stop acquisition** option.</span></span> <span data-ttu-id="22315-168">ただし、新しい申請を作成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="22315-168">However, it does not require you to create a new submission.</span></span>

<span data-ttu-id="22315-169">アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。</span><span class="sxs-lookup"><span data-stu-id="22315-169">Note that any customers who already have the app will still be able to use it and can download it again (and could even get updates if you submit new packages later).</span></span>

<span data-ttu-id="22315-170">アプリを入手不可にした後も、ダッシュボードには引き続き表示されます。</span><span class="sxs-lookup"><span data-stu-id="22315-170">After making the app unavailable, you'll still see it in your dashboard.</span></span> <span data-ttu-id="22315-171">アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="22315-171">If you decide to offer the app to customers again, you can click **Make app available** from the App overview page.</span></span> <span data-ttu-id="22315-172">確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="22315-172">After you confirm, the app will be available to new customers (unless restricted by the settings in your last submission) within a few hours.</span></span>

> [!NOTE]
> <span data-ttu-id="22315-173">アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。</span><span class="sxs-lookup"><span data-stu-id="22315-173">If you want to keep your app available, but don't want to continuing offering it to new customers on a particular OS version, you can create a new submission and remove all packages for the OS version on which you want to prevent new acquisitions.</span></span> <span data-ttu-id="22315-174">たとえば、以前に Windows Phone 8.1 と Windows 10 用のパッケージを提供していて、Windows Phone 8.1 の新しいユーザーへのアプリの提供を終了する場合は、申請から Windows Phone 8.1 用のパッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="22315-174">For example, if you previously had packages for Windows Phone 8.1 and Windows 10, and you don't want to keep offering the app to new customers on Windows Phone 8.1, remove all of your Windows Phone 8.1 packages from the submission.</span></span> <span data-ttu-id="22315-175">更新プログラムの公開後、Windows Phone 8.1 では新しいユーザーがアプリを入手できなくなります (ただし、既に取得しているユーザーは使い続けることができます)。</span><span class="sxs-lookup"><span data-stu-id="22315-175">After the update is published, no new customers on Windows Phone 8.1 will be able to acquire the app though customers who already have it can continue to use it).</span></span> <span data-ttu-id="22315-176">ただし、Windows 10 では、引き続き新しいユーザーにアプリが提供されます。</span><span class="sxs-lookup"><span data-stu-id="22315-176">However, the app will still be available for new customers on Windows 10.</span></span>


## <a name="removing-packages-for-a-previously-supported-device-family"></a><span data-ttu-id="22315-177">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="22315-177">Removing packages for a previously-supported device family</span></span>

<span data-ttu-id="22315-178">場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますことを確認するこれによって、意図**パッケージ**] ページで、変更を保存する前にすべてのパッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="22315-178">If you remove all packages for a certain [device family](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview) that your app previously supported, you'll be prompted to confirm that this is your intention before you can save your changes on the **Packages** page.</span></span>

<span data-ttu-id="22315-179">すべてのアプリが以前にサポートされているデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。</span><span class="sxs-lookup"><span data-stu-id="22315-179">When you publish a submission that removes all of the packages that could run on a device family that your app previously supported, new customers will not be able to acquire the app on that device family.</span></span> <span data-ttu-id="22315-180">そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。</span><span class="sxs-lookup"><span data-stu-id="22315-180">You can always publish another update later to provide packages for that device family again.</span></span>

<span data-ttu-id="22315-181">特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。</span><span class="sxs-lookup"><span data-stu-id="22315-181">Be aware that even if you remove all of the packages that support a certain device family, any existing customers who have already installed the app on that type of device can still use it, and they will get any updates you provide later.</span></span>


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows-10-to-a-previously-published-app"></a><span data-ttu-id="22315-182">以前に公開したアプリに Windows 10 用のパッケージを追加する</span><span class="sxs-lookup"><span data-stu-id="22315-182">Adding packages for Windows 10 to a previously-published app</span></span>

<span data-ttu-id="22315-183">For Windows パッケージのみ含まれているストアにアプリがあるかどうかは 8.x や Windows Phone 8.x をし、Windows 10 向けアプリの更新プログラム、新しい申請を作成および[パッケージ](upload-app-packages.md)手順中に、UWP の .msixupload または .appxupload パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="22315-183">If you have an app in the Store that only included packages for Windows 8.x and/or Windows Phone 8.x, and you want to update your app for Windows 10, create a new submission and add your UWP .msixupload or .appxupload package(s) during the [Packages](upload-app-packages.md) step.</span></span> <span data-ttu-id="22315-184">アプリが認定プロセスが、UWP パッケージは Windows 10 のユーザーが新規取得用に利用可能なあります。</span><span class="sxs-lookup"><span data-stu-id="22315-184">After your app goes through the certification process, the UWP package will also be available for new acquisitions by customers on Windows 10.</span></span>

> [!NOTE]
> <span data-ttu-id="22315-185">Windows 10 のユーザーが UWP パッケージを入手した場合、以前の OS バージョン用のパッケージを使うようにそのユーザーをロールバックすることはできません。</span><span class="sxs-lookup"><span data-stu-id="22315-185">Once a customer on Windows 10 gets your UWP package, you can't roll that customer back to using a package for any previous OS version.</span></span> 

<span data-ttu-id="22315-186">使用した Windows 8、Windows 8.1、または Windows Phone 8.1 のパッケージよりも高い Windows 10 パッケージのバージョン番号である必要がありますに注意してください。</span><span class="sxs-lookup"><span data-stu-id="22315-186">Note that the version number of your Windows 10 packages must be higher than those for any Windows 8, Windows 8.1, and/or Windows Phone 8.1 packages you have used.</span></span> <span data-ttu-id="22315-187">詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="22315-187">For more info, see [Package version numbering](package-version-numbering.md).</span></span>

<span data-ttu-id="22315-188">Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="22315-188">For more info about packaging UWP apps for the Store, see [Packaging apps](../packaging/index.md).</span></span>
