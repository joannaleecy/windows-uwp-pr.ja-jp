---
author: jnHs
Description: The Packages page is where you upload all of the package files (.appxupload, .appx, .appxbundle, and/or .xap) for the app that you're submitting.
title: アプリ パッケージのアップロード
ms.assetid: B1BB810D-3EAA-4FB5-B03C-1F01AFB2DE36
ms.author: wdg-dev-content
ms.date: 5/10/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, パッケージ, アップロード, パッケージのアップロード
ms.localizationpriority: medium
ms.openlocfilehash: 6013a238cff8db3b85dd98af58cccaf344a72f51
ms.sourcegitcommit: 7efffcc715a4be26f0cf7f7e249653d8c356319b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/30/2018
ms.locfileid: "3123119"
---
# <a name="upload-app-packages"></a><span data-ttu-id="635c6-103">アプリ パッケージのアップロード</span><span class="sxs-lookup"><span data-stu-id="635c6-103">Upload app packages</span></span>

<span data-ttu-id="635c6-104">**[パッケージ]** ページは、提出するアプリのすべてのパッケージ ファイル (.appx、.appxupload、.appxbundle、.xap) をアップロードする場所です。</span><span class="sxs-lookup"><span data-stu-id="635c6-104">The **Packages** page is where you upload all of the package files (.appx, .appxupload, .appxbundle, and/or .xap) for the app that you're submitting.</span></span> <span data-ttu-id="635c6-105">この手順では、アプリがターゲットとしているすべてのオペレーティング システムのパッケージをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="635c6-105">You can upload packages for any operating system that your app targets in this step.</span></span> <span data-ttu-id="635c6-106">ユーザーがアプリをダウンロードするとき、ストアはユーザーのデバイスで最適に動作するパッケージを各ユーザーに自動的に提供します。</span><span class="sxs-lookup"><span data-stu-id="635c6-106">When a customer downloads your app, the Store will automatically provide each customer with the package that works best for their device.</span></span> <span data-ttu-id="635c6-107">開発者がパッケージをアップロードした後は、[特定の Windows 10 デバイス ファミリ (および該当する場合は以前の OS バージョン) に対して提供されるパッケージ](#device-family-availability)をランキング順に示すテーブルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-107">After you upload your packages, you’ll see a table indicating [which packages will be offered to specific Windows 10 device families](#device-family-availability) (and earlier OS versions, if applicable) in ranked order.</span></span>

<span data-ttu-id="635c6-108">パッケージに含まれる内容やパッケージの構成方法について詳しくは、「[アプリ パッケージの要件](app-package-requirements.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="635c6-108">For details about what a package includes and how it must be structured, see [App package requirements](app-package-requirements.md).</span></span> <span data-ttu-id="635c6-109">[特定のユーザーに配信されるバージョン番号がパッケージにに対する影響](package-version-numbering.md)や、[さまざまなオペレーティング システムにパッケージを配布する方法](guidance-for-app-package-management.md)について説明 こともあります。</span><span class="sxs-lookup"><span data-stu-id="635c6-109">You'll also want to learn about [how version numbers may impact which packages are delivered to specific customers](package-version-numbering.md) and [how packages are distributed to different operating systems](guidance-for-app-package-management.md).</span></span>

## <a name="uploading-packages-to-your-submission"></a><span data-ttu-id="635c6-110">申請へのパッケージのアップロード</span><span class="sxs-lookup"><span data-stu-id="635c6-110">Uploading packages to your submission</span></span>

<span data-ttu-id="635c6-111">パッケージをアップロードするには、アップロード フィールドにパッケージをドラッグするか、クリックしてファイルを参照します。</span><span class="sxs-lookup"><span data-stu-id="635c6-111">To upload packages, drag them into the upload field or click to browse your files.</span></span> <span data-ttu-id="635c6-112">**[パッケージ]** ページでは、.xap、.appx、.appxupload、.appxbundle ファイルをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="635c6-112">The **Packages** page will let you upload .xap, .appx, .appxupload, and/or .appxbundle files.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="635c6-113">Windows 10 の場合、ここでは .appx や .appxbundle ではなく、.appxupload ファイルをアップロードすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="635c6-113">For Windows 10, we recommend uploading the .appxupload file here rather than an .appx or .appxbundle.</span></span>  <span data-ttu-id="635c6-114">ストア用の UWP アプリのパッケージ化について詳しくは、「[Visual Studio での UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="635c6-114">For more info about packaging UWP apps for the Store, see [Packaging a UWP app with Visual Studio](../packaging/packaging-uwp-apps.md).</span></span>

<span data-ttu-id="635c6-115">アプリの[パッケージ フライト](package-flights.md)を作成すると、いずれかのパッケージ フライトからパッケージをコピーするオプションがドロップダウンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-115">If you have created any [package flights](package-flights.md) for your app, you’ll see a drop-down with the option to copy packages from one of your package flights.</span></span> <span data-ttu-id="635c6-116">必要なパッケージが含まれているパッケージ フライトを選びます。</span><span class="sxs-lookup"><span data-stu-id="635c6-116">Select the package flight that has the packages you want to pull in.</span></span> <span data-ttu-id="635c6-117">その後で、いずれかまたはすべてのパッケージを選んで、この申請に含めることができます。</span><span class="sxs-lookup"><span data-stu-id="635c6-117">You can then select any or all of its packages to include in this submission.</span></span>

<span data-ttu-id="635c6-118">検証中には、パッケージのエラーを検出する場合は問題を通知するメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-118">If we detect errors with a package while validating it, we'll display a message to let you know what's wrong.</span></span> <span data-ttu-id="635c6-119">パッケージを削除して、問題を修正してから、もう一度アップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="635c6-119">You'll need to remove the package, fix the issue, and then try uploading it again.</span></span> <span data-ttu-id="635c6-120">また、問題を引き起こす可能性はあるが、申請の続行は妨げない事柄について通知する警告が表示されることもあります。</span><span class="sxs-lookup"><span data-stu-id="635c6-120">You may also see warnings to let you know about issues that may cause problems but won't block you from continuing with your submission.</span></span>


## <a name="device-family-availability"></a><span data-ttu-id="635c6-121">デバイス ファミリの利用可否</span><span class="sxs-lookup"><span data-stu-id="635c6-121">Device family availability</span></span>

<span data-ttu-id="635c6-122">パッケージのアップロードが正常に行われると、**[Device family availability]** (デバイス ファミリの利用可否) セクションに、特定の Windows 10 デバイス ファミリ (および該当する場合は以前の OS バージョン) に対して提供されるパッケージをランキング順に示すテーブルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-122">After your packages have been successfully uploaded, the **Device family availability** section will display a table that indicates which packages will be offered to specific Windows 10 device families (and earlier OS versions, if applicable), in ranked order.</span></span> <span data-ttu-id="635c6-123">このセクションでは、申請するアプリを特定の Windows 10 デバイス ファミリのユーザーに提供するかどうかも選択できます。</span><span class="sxs-lookup"><span data-stu-id="635c6-123">This section also lets you choose whether or not to offer the submission to customers on specific Windows 10 device families.</span></span>

<span data-ttu-id="635c6-124">詳しくは、「[デバイス ファミリの利用可否](device-family-availability.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="635c6-124">For more info, see [Device family availability](device-family-availability.md).</span></span>


## <a name="package-details"></a><span data-ttu-id="635c6-125">パッケージの詳細</span><span class="sxs-lookup"><span data-stu-id="635c6-125">Package details</span></span>

<span data-ttu-id="635c6-126">アップロードしたパッケージがここに記載されて、ターゲット オペレーティング システムによってグループ化します。</span><span class="sxs-lookup"><span data-stu-id="635c6-126">Your uploaded packages are listed here, grouped by target operating system.</span></span> <span data-ttu-id="635c6-127">パッケージの名前、バージョン、アーキテクチャが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-127">The name, version, and architecture of the package will be displayed.</span></span> <span data-ttu-id="635c6-128">各パッケージのサポートされる言語、アプリの機能、ファイル サイズなどの詳しい情報については、**[詳細の表示]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="635c6-128">For more info such as the supported languages, app capabilities, and file size for each package, click **Show details**.</span></span>

<span data-ttu-id="635c6-129">提出からパッケージを削除する必要がある場合は、各パッケージの **[詳細]** セクションの下部にある **[削除]** リンクをクリックします。</span><span class="sxs-lookup"><span data-stu-id="635c6-129">If you need to remove a package from your submission, click the **Remove** link at the bottom of each package's **Details** section.</span></span>


## <a name="removing-redundant-packages"></a><span data-ttu-id="635c6-130">冗長なパッケージの削除</span><span class="sxs-lookup"><span data-stu-id="635c6-130">Removing redundant packages</span></span>

<span data-ttu-id="635c6-131">1 つ以上のパッケージが重複している場合、この申請から冗長なパッケージを削除することを提案する警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-131">If we detect that one or more of your packages is redundant, we'll display a warning suggesting that you remove the redundant packages from this submission.</span></span> <span data-ttu-id="635c6-132">これは多くの場合、以前にパッケージをアップロードした後で、同じユーザーをサポートする新しいバージョンのパッケージを提供するときに発生します。</span><span class="sxs-lookup"><span data-stu-id="635c6-132">Often this happens when you have previously uploaded packages, and now you are providing higher-versioned packages that support the same set of customers.</span></span> <span data-ttu-id="635c6-133">この場合、これらのユーザーをサポートするより良い (より高いバージョンの) パッケージがあるため、ユーザーが冗長なパッケージを取得することはありません。</span><span class="sxs-lookup"><span data-stu-id="635c6-133">In this case, no customers would ever get the redundant package, because you now have a better (higher-versioned) package to support these customers.</span></span>

<span data-ttu-id="635c6-134">冗長なパッケージが存在することが検出された場合、すべての冗長なパッケージをこの申請から自動的に削除するオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="635c6-134">When we detect that you have redundant packages, we'll provide an option to remove all of the redundant packages from this submission automatically.</span></span> <span data-ttu-id="635c6-135">必要に応じて、パッケージを申請から個別に削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="635c6-135">You can also remove packages from the submission individually if you prefer.</span></span>


## <a name="gradual-package-rollout"></a><span data-ttu-id="635c6-136">段階的なパッケージのロールアウト</span><span class="sxs-lookup"><span data-stu-id="635c6-136">Gradual package rollout</span></span>

<span data-ttu-id="635c6-137">申請が前に公開したアプリに対する更新プログラムの場合は、**[Roll out update gradually after this submission is published (to Windows 10 customers only)]** (この申請が公開された後で段階的に更新プログラムをロールアウトする (Windows 10 ユーザーのみ)) チェック ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-137">If your submission is an update to a previously published app, you'll see a checkbox that says **Roll out update gradually after this submission is published (to Windows 10 customers only)**.</span></span> <span data-ttu-id="635c6-138">これにより、申請からパッケージを取得するユーザーの割合を選択でき、フィードバックや分析データを監視して、自信を持って更新プログラムのロールアウト範囲を広げることができます。</span><span class="sxs-lookup"><span data-stu-id="635c6-138">This allows you to choose a percentage of customers who will get the packages from the submission so that you can monitor feedback and analytic data  to make sure you’re confident about the update before rolling it out more broadly.</span></span> <span data-ttu-id="635c6-139">この割合は、新しい申請を作成することなく、いつでも増やす (または更新を停止する) ことができます。</span><span class="sxs-lookup"><span data-stu-id="635c6-139">You can increase the percentage (or halt the update) any time without having to create a new submission.</span></span> 

<span data-ttu-id="635c6-140">詳しくは、「[段階的なパッケージのロールアウト](gradual-package-rollout.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="635c6-140">For more info, see [Gradual package rollout](gradual-package-rollout.md).</span></span>


## <a name="mandatory-update"></a><span data-ttu-id="635c6-141">必須の更新プログラム</span><span class="sxs-lookup"><span data-stu-id="635c6-141">Mandatory update</span></span>

<span data-ttu-id="635c6-142">申請が以前に公開したアプリに対する更新プログラムの場合、**[Make this update mandatory]** (この更新プログラムを必須にする) チェック ボックスが表示されます。</span><span class="sxs-lookup"><span data-stu-id="635c6-142">If your submission is an update to a previously published app, you'll see a checkbox that says **Make this update mandatory**.</span></span> <span data-ttu-id="635c6-143">Windows.Services.Store API を使うことで、アプリがプログラムでパッケージの更新プログラムを確認し、更新されたパッケージをダウンロードしてインストールできるようにしてある場合は、このチェック ボックスをオンにすると、必須の更新の日時を設定できます。</span><span class="sxs-lookup"><span data-stu-id="635c6-143">This allows you to set the date and time for a mandatory update, assuming you have used the Windows.Services.Store APIs to allow your app to programmatically check for package updates and download and install the updated packages.</span></span> <span data-ttu-id="635c6-144">このオプションを使うには、アプリの対象を Windows 10 Version 1607 以降にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="635c6-144">Your app must target Windows 10, version 1607 or later in order to use this option.</span></span>

<span data-ttu-id="635c6-145">詳しくは、「[アプリのパッケージの更新をダウンロードしてインストールする](../packaging/self-install-package-updates.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="635c6-145">For more info, see [Download and install package updates for your app](../packaging/self-install-package-updates.md).</span></span>

 




