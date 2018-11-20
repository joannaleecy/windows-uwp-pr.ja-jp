---
author: jnHs
Description: Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.
title: アプリ パッケージ管理のガイダンス
ms.assetid: 55405D0B-5C1E-43C8-91A1-4BFDD336E6AB
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e625522b0e9fd03fda49eb28bbedb20c00c15634
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7289818"
---
# <a name="guidance-for-app-package-management"></a><span data-ttu-id="15fee-103">アプリ パッケージ管理のガイダンス</span><span class="sxs-lookup"><span data-stu-id="15fee-103">Guidance for app package management</span></span>

<span data-ttu-id="15fee-104">アプリのパッケージをユーザーが使用できるようになるしくみと、特定のパッケージ シナリオを管理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="15fee-104">Learn how your app's packages are made available to your customers, and how to manage specific package scenarios.</span></span>

-   [<span data-ttu-id="15fee-105">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="15fee-105">OS versions and package distribution</span></span>](#os-versions-and-package-distribution)
-   [<span data-ttu-id="15fee-106">以前に公開したアプリに Windows 10 用のパッケージを追加する</span><span class="sxs-lookup"><span data-stu-id="15fee-106">Adding packages for Windows 10 to a previously-published app</span></span>](#adding-packages-for-windows-10-to-a-previously-published-app)
-   [<span data-ttu-id="15fee-107">Windows Phone 8.1 に対するパッケージの互換性を維持する</span><span class="sxs-lookup"><span data-stu-id="15fee-107">Maintaining package compatibility for Windows Phone 8.1</span></span>](#maintaining-package-compatibility-for-windows-phone-81)
-   [<span data-ttu-id="15fee-108">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="15fee-108">Removing an app from the Store</span></span>](#removing-an-app-from-the-store)
-   [<span data-ttu-id="15fee-109">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="15fee-109">Removing packages for a previously-supported device family</span></span>](#removing-packages-for-a-previously-supported-device-family)


## <a name="os-versions-and-package-distribution"></a><span data-ttu-id="15fee-110">OS のバージョンとパッケージの配布</span><span class="sxs-lookup"><span data-stu-id="15fee-110">OS versions and package distribution</span></span>

<span data-ttu-id="15fee-111">さまざまなオペレーティング システムで異なる種類のパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="15fee-111">Different operating systems can run different types of packages.</span></span> <span data-ttu-id="15fee-112">ユーザーのデバイスで複数のパッケージを実行できる場合、Microsoft Store は使用可能な最適のパッケージを提供します。</span><span class="sxs-lookup"><span data-stu-id="15fee-112">If more than one of your packages can run on a customer's device, the Microsoft Store will provide the best available match.</span></span>

<span data-ttu-id="15fee-113">一般に、新しい OS バージョンでは、同じデバイス ファミリの以前の OS バージョンを対象にしたパッケージを実行できます。</span><span class="sxs-lookup"><span data-stu-id="15fee-113">Generally speaking, later OS versions can run packages that target previous OS versions for the same device family.</span></span> <span data-ttu-id="15fee-114">Windows 10 デバイスでは、以前サポートされている OS バージョンをすべて (ごとにデバイス ファミリ) を実行できます。</span><span class="sxs-lookup"><span data-stu-id="15fee-114">Windows10 devices can run all previous supported OS versions (per device family).</span></span> <span data-ttu-id="15fee-115">Windows 10 デスクトップ デバイスで Windows8.1 または Windows8; 用に構築されたアプリを実行できます。Windows 10 モバイル デバイスが Windows Phone 8.1、WindowsPhone8、およびも Windows Phone 用に構築されたアプリを実行できる 7.x します。</span><span class="sxs-lookup"><span data-stu-id="15fee-115">Windows10 desktop devices can run apps that were built for Windows8.1 or Windows8; Windows10 mobile devices can run apps that were built for Windows Phone 8.1, WindowsPhone8, and even Windows Phone 7.x.</span></span> <span data-ttu-id="15fee-116">ただし、アプリには、適用可能なデバイス ファミリを対象とする UWP パッケージが含まれていない場合、Windows 10 のユーザーはそれらのパッケージを取得のみです。</span><span class="sxs-lookup"><span data-stu-id="15fee-116">However, customers on Windows 10 will only get those packages if the app doesn't include UWP packages targeting the applicable device family.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="15fee-117">2018 年 10 月 31 日の時点で、新しく作成した製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。</span><span class="sxs-lookup"><span data-stu-id="15fee-117">As of October 31, 2018, newly-created products cannot include packages targeting Windows 8.x/Windows Phone 8.x or earlier.</span></span> <span data-ttu-id="15fee-118">詳しくは、この[ブログ記事](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="15fee-118">For more info, see this [blog post](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/).</span></span>


## <a name="removing-an-app-from-the-store"></a><span data-ttu-id="15fee-119">アプリをストアから削除する</span><span class="sxs-lookup"><span data-stu-id="15fee-119">Removing an app from the Store</span></span>

<span data-ttu-id="15fee-120">ユーザーへのアプリの提供を停止し、事実上 "非公開" にする必要が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="15fee-120">At times, you may want to stop offering an app to customers, effectively "unpublishing" it.</span></span> <span data-ttu-id="15fee-121">これを行うには、**[アプリの概要]** ページで **[アプリの提供を停止する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="15fee-121">To do so, click **Make app unavailable** from the **App overview** page.</span></span> <span data-ttu-id="15fee-122">アプリを入手不可にすることを確認すると、そのアプリは数時間以内に Store に表示されなくなり、([プロモーション コード](generate-promotional-codes.md)があり、Windows 10 デバイスを使用している場合を除き) 新しいユーザーがアプリを入手することはできなくなります。</span><span class="sxs-lookup"><span data-stu-id="15fee-122">After you confirm that you want to make the app unavailable, within a few hours it will no longer be visible in the Store, and no new customers will be able to get it (unless they have a [promotional code](generate-promotional-codes.md) and are using a Windows 10 device).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="15fee-123">このオプションは、申請時に選択した[表示](choose-visibility-options.md#discoverability)設定よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="15fee-123">This option will override any [visibility](choose-visibility-options.md#discoverability) settings that you have selected in your submissions.</span></span> 

<span data-ttu-id="15fee-124">このオプションは、申請を作成し、**[購入の停止]** オプションと同時に **[この製品を Microsoft Store で提供しますが、検索はできないようにします]** を選択した場合と同じ効果があります。</span><span class="sxs-lookup"><span data-stu-id="15fee-124">This option has the same effect as if you created a submission and chose **Make this product available but not discoverable in the Store** with the **Stop acquisition** option.</span></span> <span data-ttu-id="15fee-125">ただし、新しい申請を作成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="15fee-125">However, it does not require you to create a new submission.</span></span>

<span data-ttu-id="15fee-126">アプリを既に持っているユーザーは使用し続けることができ、もう一度アプリをダウンロードできることに注意してください (後で新しいパッケージを申請した場合には更新プログラムを入手することもできます)。</span><span class="sxs-lookup"><span data-stu-id="15fee-126">Note that any customers who already have the app will still be able to use it and can download it again (and could even get updates if you submit new packages later).</span></span>

<span data-ttu-id="15fee-127">アプリ入手不可にした後でも表示されますがパートナー センターで。</span><span class="sxs-lookup"><span data-stu-id="15fee-127">After making the app unavailable, you'll still see it in Partner Center.</span></span> <span data-ttu-id="15fee-128">アプリをもう一度ユーザーに提供する場合は、[アプリの概要] ページで **[アプリを提供する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="15fee-128">If you decide to offer the app to customers again, you can click **Make app available** from the App overview page.</span></span> <span data-ttu-id="15fee-129">確認後、数時間以内に新しいユーザーがアプリを入手できるようになります (前回の申請時の設定により制限されている場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="15fee-129">After you confirm, the app will be available to new customers (unless restricted by the settings in your last submission) within a few hours.</span></span>

> [!NOTE]
> <span data-ttu-id="15fee-130">アプリの提供は継続しながら、特定の OS バージョンで新しいユーザーへの提供を終了する場合は、新しい申請を作成して、新規の取得を許可しない OS バージョン用のパッケージをすべて削除できます。</span><span class="sxs-lookup"><span data-stu-id="15fee-130">If you want to keep your app available, but don't want to continuing offering it to new customers on a particular OS version, you can create a new submission and remove all packages for the OS version on which you want to prevent new acquisitions.</span></span> <span data-ttu-id="15fee-131">たとえば、Windows Phone 8.1 と windows 10 では、パッケージを持っていた WindowsPhone8.1 の新しいユーザーに、アプリの提供を継続したくない場合は、すべて WindowsPhone8.1 パッケージの申請から削除します。</span><span class="sxs-lookup"><span data-stu-id="15fee-131">For example, if you previously had packages for Windows Phone 8.1 and Windows10, and you don't want to keep offering the app to new customers on WindowsPhone8.1, remove all of your WindowsPhone8.1 packages from the submission.</span></span> <span data-ttu-id="15fee-132">更新プログラムが公開されると、WindowsPhone8.1 で新しいユーザーできなくなりますを既に持っているユーザーは使い続けることも、アプリを入手する)。</span><span class="sxs-lookup"><span data-stu-id="15fee-132">After the update is published, no new customers on WindowsPhone8.1 will be able to acquire the app though customers who already have it can continue to use it).</span></span> <span data-ttu-id="15fee-133">ただし、アプリも新しいユーザーに windows 10 で利用できます。</span><span class="sxs-lookup"><span data-stu-id="15fee-133">However, the app will still be available for new customers on Windows10.</span></span>


## <a name="removing-packages-for-a-previously-supported-device-family"></a><span data-ttu-id="15fee-134">これまでサポートされていたデバイス ファミリ用のパッケージを削除する</span><span class="sxs-lookup"><span data-stu-id="15fee-134">Removing packages for a previously-supported device family</span></span>

<span data-ttu-id="15fee-135">場合は、特定の[デバイス ファミリ](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)アプリ以前サポートされている、ように求められますこれが、目的**のパッケージ**] ページで、変更を保存する前に確認するためのすべてのパッケージを削除します。</span><span class="sxs-lookup"><span data-stu-id="15fee-135">If you remove all packages for a certain [device family](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview) that your app previously supported, you'll be prompted to confirm that this is your intention before you can save your changes on the **Packages** page.</span></span>

<span data-ttu-id="15fee-136">すべてのアプリでサポートされていたデバイス ファミリで実行できるパッケージを削除する申請を公開するときは、新しいユーザーはそのデバイス ファミリでアプリを入手できません。</span><span class="sxs-lookup"><span data-stu-id="15fee-136">When you publish a submission that removes all of the packages that could run on a device family that your app previously supported, new customers will not be able to acquire the app on that device family.</span></span> <span data-ttu-id="15fee-137">そのデバイス ファミリ向けのパッケージを提供するための別の更新プログラムは、後でいつでも公開することができます。</span><span class="sxs-lookup"><span data-stu-id="15fee-137">You can always publish another update later to provide packages for that device family again.</span></span>

<span data-ttu-id="15fee-138">特定のデバイス ファミリをサポートするパッケージをすべて削除した場合でも、該当する種類のデバイスにアプリを既にインストールしているユーザーは、そのアプリを使うことができますが、後で提供される更新プログラムを入手することになります。</span><span class="sxs-lookup"><span data-stu-id="15fee-138">Be aware that even if you remove all of the packages that support a certain device family, any existing customers who have already installed the app on that type of device can still use it, and they will get any updates you provide later.</span></span>


<a name="adding-packages-for-windows-10-to-a-previously-published-app"></a>

## <a name="adding-packages-for-windows10-to-a-previously-published-app"></a><span data-ttu-id="15fee-139">Windows 10 のパッケージを公開したアプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="15fee-139">Adding packages for Windows10 to a previously-published app</span></span>

<span data-ttu-id="15fee-140">For Windows パッケージしか含まれているストアでアプリがあるかどうかは 8.x や Windows Phone 8.x をし、windows 10 向けアプリの更新プログラム、新しい申請を作成および[パッケージ](upload-app-packages.md)手順中に、UWP .msixupload または .appxupload パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="15fee-140">If you have an app in the Store that only included packages for Windows 8.x and/or Windows Phone 8.x, and you want to update your app for Windows10, create a new submission and add your UWP .msixupload or .appxupload package(s) during the [Packages](upload-app-packages.md) step.</span></span> <span data-ttu-id="15fee-141">アプリが認定プロセスと、UWP パッケージもできるようになります windows 10 のユーザーが新規取得用です。</span><span class="sxs-lookup"><span data-stu-id="15fee-141">After your app goes through the certification process, the UWP package will also be available for new acquisitions by customers on Windows10.</span></span>

> [!NOTE]
> <span data-ttu-id="15fee-142">Windows 10 のユーザーが UWP パッケージを取得した後は、パッケージを使用して、以前の OS バージョン用にそのユーザーをロールバックことはできません。</span><span class="sxs-lookup"><span data-stu-id="15fee-142">Once a customer on Windows10 gets your UWP package, you can't roll that customer back to using a package for any previous OS version.</span></span> 

<span data-ttu-id="15fee-143">Windows 10 パッケージのバージョン番号を使用した Windows8 や Windows8.1、Windows Phone 8.1 のパッケージよりも高いにする必要のあるに注意してください。</span><span class="sxs-lookup"><span data-stu-id="15fee-143">Note that the version number of your Windows10 packages must be higher than those for any Windows8, Windows8.1, and/or Windows Phone 8.1 packages you have used.</span></span> <span data-ttu-id="15fee-144">詳しくは、「[パッケージ バージョンの番号付け](package-version-numbering.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15fee-144">For more info, see [Package version numbering](package-version-numbering.md).</span></span>

<span data-ttu-id="15fee-145">Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15fee-145">For more info about packaging UWP apps for the Store, see [Packaging apps](../packaging/index.md).</span></span>
