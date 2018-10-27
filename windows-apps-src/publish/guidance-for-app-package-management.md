---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 10/02/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: dd775b1fa653df5aca9b4738249757c052c181ed
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5700085"
---
# <a name="guidance-for-app-package-management"></a><span data-ttu-id="02465-103">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="02465-103">Guidance for app package management</span></span>

<span data-ttu-id="02465-104">アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="02465-104">Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.</span></span>

-   [<span data-ttu-id="02465-105">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="02465-105">OS versions and package distribution</span></span>](#os-versions-and-package-distribution)
-   [<span data-ttu-id="02465-106">以前に公開したアプリに Windows 10 用のパッケージを追加する</span><span class="sxs-lookup"><span data-stu-id="02465-106">Adding packages for Windows 10 to a previously-published app</span></span>](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [<span data-ttu-id="02465-107">Windows Phone 8.1 に対するパッケージの互換性を維持する</span><span class="sxs-lookup"><span data-stu-id="02465-107">Maintaining package compatibility for Windows Phone 8.1</span></span>](#maintaining-package-compatibility-for-windows-phone-81)
-   [<span data-ttu-id="02465-108">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="02465-108">Removing an app from the Store</span></span>](#removing-an-app-from-the-store)
-   [<span data-ttu-id="02465-109">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="02465-109">Removing packages for a previously-supported device family</span></span>](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a><span data-ttu-id="02465-110">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="02465-110">OS versions and package distribution</span></span>

<span data-ttu-id="02465-111">さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="02465-111">Different operating systems can run different types of packages.</span></span> <span data-ttu-id="02465-112">ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。</span><span class="sxs-lookup"><span data-stu-id="02465-112">If more than one of your packages can run on a customer's device, the Microsoft Store will provide the best available match.</span></span>

<span data-ttu-id="02465-113">一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="02465-113">Generally speaking, later OS versions can run packages that target previous OS versions for the same device family.</span></span> <span data-ttu-id="02465-114">ただし、アプリには、現在の OS バージョンをターゲットとするパッケージが含まれていない場合、ユーザーはそれらのパッケージを取得限られます。</span><span class="sxs-lookup"><span data-stu-id="02465-114">However, customers will only get those packages if the app doesn't include a package that targets their current OS version.</span></span>

<span data-ttu-id="02465-115">たとえば、windows 10 デバイスでは、以前サポートされている OS バージョンをすべて (ごとにデバイス ファミリ) を実行できます。</span><span class="sxs-lookup"><span data-stu-id="02465-115">For example, Windows10 devices can run all previous supported OS versions (per device family).</span></span> <span data-ttu-id="02465-116">Windows 10 デスクトップ デバイスで Windows8.1 または Windows8; 用に構築されたアプリを実行できます。Windows 10 モバイル デバイスで Windows Phone 8.1、WindowsPhone8、およびも Windows Phone 用に構築されたアプリを実行できる 7.x します。</span><span class="sxs-lookup"><span data-stu-id="02465-116">Windows10 desktop devices can run apps that were built for Windows8.1 or Windows8; Windows10 mobile devices can run apps that were built for Windows Phone 8.1, WindowsPhone8, and even Windows Phone 7.x.</span></span> 

<span data-ttu-id="02465-117">以下の例では、複数の OS バージョンをターゲットとするパッケージなど、アプリのさまざまなシナリオについて説明します。ただし、パッケージ特有の制約によって、ここに示したすべての OS バージョンとデバイスの種類で実行できないことがあります (デバイスでパッケージのアーキテクチャが特定のものである必要がある場合など)。</span><span class="sxs-lookup"><span data-stu-id="02465-117">The following examples illustrate various scenarios for an app that includes packages targeting different OS versions (unless specific constraints of your packages don't allow them to run on every OS version/device type listed here; for example, the package's architecture must be appropriate for the device).</span></span> 

### <a name="example-app-1"></a><span data-ttu-id="02465-118">アプリ例 1</span><span class="sxs-lookup"><span data-stu-id="02465-118">Example app 1</span></span>

| <span data-ttu-id="02465-119">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-119">Package's targeted operating system</span></span> | <span data-ttu-id="02465-120">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-120">Operating systems that will get this package</span></span> |
|-------------------------------------|----------------------------------------------|
| <span data-ttu-id="02465-121">Windows8.1</span><span class="sxs-lookup"><span data-stu-id="02465-121">Windows8.1</span></span>                         | <span data-ttu-id="02465-122">Windows 10 デスクトップ デバイスを Windows8.1</span><span class="sxs-lookup"><span data-stu-id="02465-122">Windows10 desktop devices, Windows8.1</span></span>      |
| <span data-ttu-id="02465-123">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="02465-123">Windows Phone 8.1</span></span>                   | <span data-ttu-id="02465-124">Windows 10 モバイル デバイス、Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="02465-124">Windows10 mobile devices, Windows Phone 8.1</span></span> |
| <span data-ttu-id="02465-125">WindowsPhone8</span><span class="sxs-lookup"><span data-stu-id="02465-125">WindowsPhone8</span></span>                     | <span data-ttu-id="02465-126">WindowsPhone8</span><span class="sxs-lookup"><span data-stu-id="02465-126">WindowsPhone8</span></span>                              |
| <span data-ttu-id="02465-127">Windows Phone 7.1</span><span class="sxs-lookup"><span data-stu-id="02465-127">Windows Phone 7.1</span></span>                   | <span data-ttu-id="02465-128">Windows Phone 7.x</span><span class="sxs-lookup"><span data-stu-id="02465-128">Windows Phone 7.x</span></span>                            |

<span data-ttu-id="02465-129">アプリ例 1、アプリはまだありませんは具体的には、windows 10 デバイス用に構築されたユニバーサル Windows プラットフォーム (UWP) パッケージが windows 10 のユーザー、アプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="02465-129">In example app 1, the app does not yet have Universal Windows Platform (UWP) packages that are specifically built for Windows10 devices, but customers on Windows10 can still get the app.</span></span> <span data-ttu-id="02465-130">ユーザーはデバイスの種類で使用できる最適なパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="02465-130">Those customers will get the best packages available for their device type.</span></span>

### <a name="example-app-2"></a><span data-ttu-id="02465-131">アプリ例 2</span><span class="sxs-lookup"><span data-stu-id="02465-131">Example app 2</span></span>

| <span data-ttu-id="02465-132">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-132">Package's targeted operating system</span></span>  | <span data-ttu-id="02465-133">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-133">Operating systems that will get this package</span></span> |
|--------------------------------------|----------------------------------------------|
| <span data-ttu-id="02465-134">Windows 10 (ユニバーサル デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="02465-134">Windows10 (universal device family)</span></span> | <span data-ttu-id="02465-135">Windows 10 (すべてのデバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="02465-135">Windows10 (all device families)</span></span>             |
| <span data-ttu-id="02465-136">Windows8.1</span><span class="sxs-lookup"><span data-stu-id="02465-136">Windows8.1</span></span>                          | <span data-ttu-id="02465-137">Windows8.1</span><span class="sxs-lookup"><span data-stu-id="02465-137">Windows8.1</span></span>                                  |
| <span data-ttu-id="02465-138">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="02465-138">Windows Phone 8.1</span></span>                    | <span data-ttu-id="02465-139">Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="02465-139">Windows Phone 8.1</span></span>                            |
| <span data-ttu-id="02465-140">Windows Phone 7.1</span><span class="sxs-lookup"><span data-stu-id="02465-140">Windows Phone 7.1</span></span>                    | <span data-ttu-id="02465-141">Windows Phone 7.x、WindowsPhone8</span><span class="sxs-lookup"><span data-stu-id="02465-141">Windows Phone 7.x, WindowsPhone8</span></span>           |

<span data-ttu-id="02465-142">アプリ例 2、Windows8 で実行できるパッケージはありません。</span><span class="sxs-lookup"><span data-stu-id="02465-142">In example app 2, there is no package that can run on Windows8.</span></span> <span data-ttu-id="02465-143">他のすべての OS バージョンを実行しているユーザーは、アプリを入手できます。</span><span class="sxs-lookup"><span data-stu-id="02465-143">Customers who are running any other OS version can get the app.</span></span> <span data-ttu-id="02465-144">Windows 10 でのすべてのお客様は、同じパッケージを取得します。</span><span class="sxs-lookup"><span data-stu-id="02465-144">All customers on Windows 10 will get the same package.</span></span>

### <a name="example-app-3"></a><span data-ttu-id="02465-145">アプリ例 3</span><span class="sxs-lookup"><span data-stu-id="02465-145">Example app 3</span></span>

| <span data-ttu-id="02465-146">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-146">Package's targeted operating system</span></span> | <span data-ttu-id="02465-147">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-147">Operating systems that will get this package</span></span>                  |
|-------------------------------------|---------------------------------------------------------------|
| <span data-ttu-id="02465-148">Windows 10 (デスクトップ デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="02465-148">Windows10 (desktop device family)</span></span>  | <span data-ttu-id="02465-149">Windows 10 デスクトップ デバイス</span><span class="sxs-lookup"><span data-stu-id="02465-149">Windows10 desktop devices</span></span>                                    |
| <span data-ttu-id="02465-150">WindowsPhone8</span><span class="sxs-lookup"><span data-stu-id="02465-150">WindowsPhone8</span></span>                     | <span data-ttu-id="02465-151">Windows 10 モバイル デバイス、WindowsPhone8、Windows Phone 8.1</span><span class="sxs-lookup"><span data-stu-id="02465-151">Windows10 mobile devices, WindowsPhone8, Windows Phone 8.1</span></span> |

<span data-ttu-id="02465-152">アプリ例 3 で、モバイル デバイス ファミリを対象にした UWP パッケージがないため windows 10 モバイル デバイスのユーザーは、パッケージを取得 WindowsPhone8 します。</span><span class="sxs-lookup"><span data-stu-id="02465-152">In example app 3, since there is no UWP package that targets the mobile device family, customers on Windows10 mobile devices will get the WindowsPhone8 package.</span></span> <span data-ttu-id="02465-153">このアプリは、後で、モバイル デバイス ファミリ (またはユニバーサル デバイス ファミリ) を対象にしたパッケージを追加する場合、パッケージが提供されます WindowsPhone8 パッケージではなく、windows 10 モバイル デバイスのユーザーにします。</span><span class="sxs-lookup"><span data-stu-id="02465-153">If this app later adds a package that targets the mobile device family (or the universal device family), that package will then be available to customers on Windows10 mobile devices instead of the WindowsPhone8 package.</span></span>

<span data-ttu-id="02465-154">また、このアプリ例には Windows Phone 7.x で実行可能なパッケージが含まれていない点にも注目してください。</span><span class="sxs-lookup"><span data-stu-id="02465-154">Also note that this example app does not include any package that can run on Windows Phone 7.x.</span></span>

### <a name="example-app-4"></a><span data-ttu-id="02465-155">アプリ例 4</span><span class="sxs-lookup"><span data-stu-id="02465-155">Example app 4</span></span>

| <span data-ttu-id="02465-156">パッケージの対象オペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-156">Package's targeted operating system</span></span>  | <span data-ttu-id="02465-157">このパッケージを取得するオペレーティング システム</span><span class="sxs-lookup"><span data-stu-id="02465-157">Operating systems that will get this package</span></span> |
|--------------------------------------|----------------------------------------------|
| <span data-ttu-id="02465-158">Windows 10 (ユニバーサル デバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="02465-158">Windows10 (universal device family)</span></span> | <span data-ttu-id="02465-159">Windows 10 (すべてのデバイス ファミリ)</span><span class="sxs-lookup"><span data-stu-id="02465-159">Windows10 (all device families)</span></span>             |

<span data-ttu-id="02465-160">アプリ例 4 のでは、windows 10 を実行している任意のデバイスは、アプリを入手できますが、それ以前の OS バージョンのユーザーに利用できなくなります。</span><span class="sxs-lookup"><span data-stu-id="02465-160">In example app 4, any device that is running Windows10 can get the app, but it will not be available to customers on any previous OS version.</span></span> <span data-ttu-id="02465-161">UWP パッケージがユニバーサル デバイス ファミリを対象としているために、すべての windows 10 デバイス (ごとに、[デバイス ファミリの利用可否選択](device-family-availability.md)) を利用可能ななります。</span><span class="sxs-lookup"><span data-stu-id="02465-161">Because the UWP package targets the universal device family, it will be available to any Windows10 device (per your [device family availability selections](device-family-availability.md)).</span></span>


## <a name="removing-an-app-from-the-store"></a><span data-ttu-id="02465-162">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="02465-162">Removing an app from the Store</span></span>

<span data-ttu-id="02465-163">ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="02465-163">At times, you may want to stop offering an app to customers, effectively "unpublishing" it.</span></span> <span data-ttu-id="02465-164">これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="02465-164">To do so, click **Make app unavailable** from the **App overview** page.</span></span> <span data-ttu-id="02465-165">アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。</span><span class="sxs-lookup"><span data-stu-id="02465-165">After you confirm that you want to make the app unavailable, within a few hours it will no longer be visible in the Store, and no new customers will be able to get it (unless they have a [promotional code](generate-promotional-codes.md) and are using a Windows 10 device).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="02465-166">このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="02465-166">This option will override any [visibility](choose-visibility-options.md#discoverability) settings that you have selected in your submissions.</span></span> 

<span data-ttu-id="02465-167">このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。</span><span class="sxs-lookup"><span data-stu-id="02465-167">This option has the same effect as if you created a submission and chose **Make this product available but not discoverable in the Store** with the **Stop acquisition** option.</span></span> <span data-ttu-id="02465-168">ただし、新しい申請を作成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="02465-168">However, it does not require you to create a new submission.</span></span>

<span data-ttu-id="02465-169">アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。</span><span class="sxs-lookup"><span data-stu-id="02465-169">Note that any customers who already have the app will still be able to use it and can download it again (and could even get updates if you submit new packages later).</span></span>

<span data-ttu-id="02465-170">アプリを入手不可にした後も、ダッシュボードには引き続き表示されます。</span><span class="sxs-lookup"><span data-stu-id="02465-170">After making the app unavailable, you'll still see it in your dashboard.</span></span> <span data-ttu-id="02465-171">アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="02465-171">If you decide to offer the app to customers again, you can click **Make app available** from the App overview page.</span></span> <span data-ttu-id="02465-172">確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="02465-172">After you confirm, the app will be available to new customers (unless restricted by the settings in your last submission) within a few hours.</span></span>

> [!NOTE]
> <span data-ttu-id="02465-173">アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。</span><span class="sxs-lookup"><span data-stu-id="02465-173">If you want to keep your app available, but don't want to continuing offering it to new customers on a particular OS version, you can create a new submission and remove all packages for the OS version on which you want to prevent new acquisitions.</span></span> <span data-ttu-id="02465-174">たとえば、Windows Phone 8.1 と windows 10 では、パッケージを持っていた WindowsPhone8.1 で新しいユーザーへのアプリの提供を継続したくない場合は、すべて WindowsPhone8.1 パッケージの申請から削除します。</span><span class="sxs-lookup"><span data-stu-id="02465-174">For example, if you previously had packages for Windows Phone 8.1 and Windows10, and you don't want to keep offering the app to new customers on WindowsPhone8.1, remove all of your WindowsPhone8.1 packages from the submission.</span></span> <span data-ttu-id="02465-175">更新プログラムが公開されると、WindowsPhone8.1 で新しいユーザーできなくなりますを既に持っているユーザーは、それを使い続けることができますが、アプリを入手する)。</span><span class="sxs-lookup"><span data-stu-id="02465-175">After the update is published, no new customers on WindowsPhone8.1 will be able to acquire the app though customers who already have it can continue to use it).</span></span> <span data-ttu-id="02465-176">ただし、アプリも新しいユーザーに windows 10 で利用できます。</span><span class="sxs-lookup"><span data-stu-id="02465-176">However, the app will still be available for new customers on Windows10.</span></span>


## <a name="removing-packages-for-a-previously-supported-device-family"></a><span data-ttu-id="02465-177">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="02465-177">Removing packages for a previously-supported device family</span></span>

<span data-ttu-id="02465-178">場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますことを確認するこれによって、意図を **[パッケージ**] ページで、変更を保存する前にすべてのパッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="02465-178">If you remove all packages for a certain [device family](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview) that your app previously supported, you'll be prompted to confirm that this is your intention before you can save your changes on the **Packages** page.</span></span>

<span data-ttu-id="02465-179">すべてのアプリが以前にサポートされているデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。</span><span class="sxs-lookup"><span data-stu-id="02465-179">When you publish a submission that removes all of the packages that could run on a device family that your app previously supported, new customers will not be able to acquire the app on that device family.</span></span> <span data-ttu-id="02465-180">そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。</span><span class="sxs-lookup"><span data-stu-id="02465-180">You can always publish another update later to provide packages for that device family again.</span></span>

<span data-ttu-id="02465-181">特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。</span><span class="sxs-lookup"><span data-stu-id="02465-181">Be aware that even if you remove all of the packages that support a certain device family, any existing customers who have already installed the app on that type of device can still use it, and they will get any updates you provide later.</span></span>


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a><span data-ttu-id="02465-182">Windows 10 の以前に公開されたアプリ パッケージに追加します。</span><span class="sxs-lookup"><span data-stu-id="02465-182">Adding packages for Windows10 to a previously-published app</span></span>

<span data-ttu-id="02465-183">For Windows パッケージしか含まれているストアにアプリがあるかどうかは 8.x や Windows Phone 8.x をし、windows 10 向けアプリの更新プログラム、新しい申請を作成および[パッケージ](upload-app-packages.md)手順中に、UWP の .msixupload または .appxupload パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="02465-183">If you have an app in the Store that only included packages for Windows 8.x and/or Windows Phone 8.x, and you want to update your app for Windows10, create a new submission and add your UWP .msixupload or .appxupload package(s) during the [Packages](upload-app-packages.md) step.</span></span> <span data-ttu-id="02465-184">アプリが認定プロセスと、UWP パッケージもできるようになります windows 10 のユーザーが新規取得用です。</span><span class="sxs-lookup"><span data-stu-id="02465-184">After your app goes through the certification process, the UWP package will also be available for new acquisitions by customers on Windows10.</span></span>

> [!NOTE]
> <span data-ttu-id="02465-185">Windows 10 のユーザーが UWP パッケージを取得した後は、パッケージを使用して、以前の OS バージョン用にそのユーザーをロールバックことはできません。</span><span class="sxs-lookup"><span data-stu-id="02465-185">Once a customer on Windows10 gets your UWP package, you can't roll that customer back to using a package for any previous OS version.</span></span> 

<span data-ttu-id="02465-186">Windows 10 パッケージのバージョン番号を使用した Windows8 や Windows8.1、Windows Phone 8.1 のパッケージよりもする必要があることに注意します。</span><span class="sxs-lookup"><span data-stu-id="02465-186">Note that the version number of your Windows10 packages must be higher than those for any Windows8, Windows8.1, and/or Windows Phone 8.1 packages you have used.</span></span> <span data-ttu-id="02465-187">詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02465-187">For more info, see [Package version numbering](package-version-numbering.md).</span></span>

<span data-ttu-id="02465-188">Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="02465-188">For more info about packaging UWP apps for the Store, see [Packaging apps](../packaging/index.md).</span></span>
