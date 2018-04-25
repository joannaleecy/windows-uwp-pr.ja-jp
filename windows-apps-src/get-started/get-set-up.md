---
author: GrantMeStrength
ms.assetid: 7D5EED8A-0742-4E12-A806-40FBAEFE6ABF
title: 準備
description: 準備は、思っているよりも簡単です。 次の手順に従って、Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリの作成を開始してください。
ms.author: jken
ms.date: 03/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: high
ms.openlocfilehash: 85c949307183cf71f8b770d190d983db28b61a9f
ms.sourcegitcommit: cceaf2206ec53a3e9155f97f44e4795a7b6a1d78
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/03/2018
---
# <a name="get-set-up"></a><span data-ttu-id="add59-105">準備</span><span class="sxs-lookup"><span data-stu-id="add59-105">Get set up</span></span>

![Visual Studio を使用する準備を行う](images/VisualStudio2017Hero_ImageXL-LG.png)


<span data-ttu-id="add59-107">準備は、思っているよりも簡単です。</span><span class="sxs-lookup"><span data-stu-id="add59-107">It's easier than you think to get going.</span></span> <span data-ttu-id="add59-108">次の手順に従って、Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリの作成を開始してください。</span><span class="sxs-lookup"><span data-stu-id="add59-108">Follow these instructions and start creating Universal Windows Platform (UWP) apps for Windows 10.</span></span>

## <a name="1-get-windows-10"></a><span data-ttu-id="add59-109">1. Windows 10 の入手</span><span class="sxs-lookup"><span data-stu-id="add59-109">1. Get Windows 10</span></span>

<span data-ttu-id="add59-110">UWP アプリを開発するには、Windows の最新バージョンが必要です。</span><span class="sxs-lookup"><span data-stu-id="add59-110">To develop UWP apps, you need the latest version of Windows.</span></span>

-   [<span data-ttu-id="add59-111">Windows 10 をオンラインで入手する</span><span class="sxs-lookup"><span data-stu-id="add59-111">Get Windows 10 online</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619312)

<span data-ttu-id="add59-112">MSDN サブスクリプション会員の方は、</span><span class="sxs-lookup"><span data-stu-id="add59-112">Are you an MSDN subscriber?</span></span> <span data-ttu-id="add59-113">ISO をここからダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="add59-113">You can get ISO downloads here:</span></span>

-   <span data-ttu-id="add59-114">Windows 10 は、[MSDN サブスクライバー ダウンロード](http://go.microsoft.com/fwlink/p/?LinkId=266384)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="add59-114">Get Windows 10 from [MSDN Subscriber Downloads](http://go.microsoft.com/fwlink/p/?LinkId=266384)</span></span>


## <a name="2-download-or-update-visual-studio"></a><span data-ttu-id="add59-115">2. Visual Studio のダウンロードまたは更新</span><span class="sxs-lookup"><span data-stu-id="add59-115">2. Download or update Visual Studio</span></span>

<span data-ttu-id="add59-116">Microsoft Visual Studio 2017 は、アプリの設計、コード化、テスト、デバッグに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="add59-116">Microsoft Visual Studio 2017 helps you design, code, test, and debug your apps.</span></span>

<span data-ttu-id="add59-117">Visual Studio 2017 をまだお持ちでない場合は、Microsoft Visual Studio Community 2017 を無料でインストールできます。</span><span class="sxs-lookup"><span data-stu-id="add59-117">If you don't already have Visual Studio 2017, you can install the free Microsoft Visual Studio Community 2017.</span></span> <span data-ttu-id="add59-118">このダウンロードには、アプリのテスト用としてデバイスのシミュレーターが含まれています。</span><span class="sxs-lookup"><span data-stu-id="add59-118">This download includes device simulators for testing your apps:</span></span>

-   [<span data-ttu-id="add59-119">Windows 10 開発者ツールをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="add59-119">Download Windows 10 developer tools</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=534189)

<span data-ttu-id="add59-120">Visual Studio をインストールする場合は、次のように [ユニバーサル Windows アプリ開発ツール] オプションを必ず選択してください。</span><span class="sxs-lookup"><span data-stu-id="add59-120">When you install Visual Studio, make sure to select the Universal Windows App Development Tools option, as shown here:</span></span>

![UWP 用の Visual Studio ツール](images/vs-2017-community-setup.png)

<span data-ttu-id="add59-122">Visual Studio に関するヘルプが必要な場合は、</span><span class="sxs-lookup"><span data-stu-id="add59-122">Need some help with Visual Studio?</span></span> <span data-ttu-id="add59-123">[Visual Studio の概要に関するページ](https://www.visualstudio.com/vs/getting-started)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="add59-123">See [Get Started with Visual Studio](https://www.visualstudio.com/vs/getting-started).</span></span>

<span data-ttu-id="add59-124">既に Visual Studio の使用を開始していて、一部のコンポーネントがないことがわかった場合は、*[新しいプロジェクト]* ダイアログ ボックスでインストーラーをもう一度起動できます。</span><span class="sxs-lookup"><span data-stu-id="add59-124">If you have already started using Visual Studio, but discover you are missing some components, you can launch the installer again from the *New project* dialog:</span></span>

   ![インストール プロセスを繰り返す方法](images/win10-cs-install.png)


## <a name="3-enable-your-device-for-development"></a><span data-ttu-id="add59-126">3. デバイスを開発用に有効にする</span><span class="sxs-lookup"><span data-stu-id="add59-126">3. Enable your device for development</span></span>

<span data-ttu-id="add59-127">UWP アプリのテストは実際の PC と電話で行うことが重要です。</span><span class="sxs-lookup"><span data-stu-id="add59-127">It’s important to test your UWP apps on real PCs and phones.</span></span> <span data-ttu-id="add59-128">PC または Windows Phone にアプリを展開するには、PC または電話を開発用に有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="add59-128">Before you can deploy apps to your PC or Windows Phone, you have to enable it for development.</span></span>

-   <span data-ttu-id="add59-129">詳しい手順については、「[デバイスを開発用に有効にする](enable-your-device-for-development.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="add59-129">For detailed instructions, see [Enable your device for development](enable-your-device-for-development.md).</span></span>

## <a name="4-register-as-an-app-developer"></a><span data-ttu-id="add59-130">4. アプリ開発者としての登録</span><span class="sxs-lookup"><span data-stu-id="add59-130">4. Register as an app developer</span></span>

<span data-ttu-id="add59-131">アプリの開発をすぐに開始できますが、ストアへの提出前に開発者アカウントが必要です。</span><span class="sxs-lookup"><span data-stu-id="add59-131">You can start developing apps now, but before you can submit them to the store, you need a developer account.</span></span>

-   <span data-ttu-id="add59-132">開発者アカウントを取得するには、[サインアップ](sign-up.md) ページに移動します。</span><span class="sxs-lookup"><span data-stu-id="add59-132">To get a developer account, go to the [Sign up](sign-up.md) page.</span></span>

## <a name="whats-next"></a><span data-ttu-id="add59-133">次の手順</span><span class="sxs-lookup"><span data-stu-id="add59-133">What's next?</span></span>

<span data-ttu-id="add59-134">ツールをインストールしてデバイスで開発できるようにしたら、チュートリアルを使って最初のアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="add59-134">After you've installed the tools and enabled your device for development, use our tutorials to create your first app:</span></span>

-   <span data-ttu-id="add59-135">[初めてのアプリの作成](your-first-app.md)のチュートリアル</span><span class="sxs-lookup"><span data-stu-id="add59-135">[Create your first app](your-first-app.md) tutorials</span></span>

## <a name="want-more-tools-and-downloads"></a><span data-ttu-id="add59-136">その他のツールとダウンロード</span><span class="sxs-lookup"><span data-stu-id="add59-136">Want more tools and downloads?</span></span>

<span data-ttu-id="add59-137">ツールとダウンロードの一覧については、[ダウンロード ページ](http://go.microsoft.com/fwlink/p/?linkid=285935)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="add59-137">For the complete list of tools and downloads, see [Downloads](http://go.microsoft.com/fwlink/p/?linkid=285935).</span></span>


## <a name="see-also"></a><span data-ttu-id="add59-138">関連項目</span><span class="sxs-lookup"><span data-stu-id="add59-138">See Also</span></span>

* [<span data-ttu-id="add59-139">初めてのアプリ</span><span class="sxs-lookup"><span data-stu-id="add59-139">Your first app</span></span>](your-first-app.md)
* <span data-ttu-id="add59-140">[UWP アプリを公開する](https://developer.microsoft.com/store/publish-apps)</span><span class="sxs-lookup"><span data-stu-id="add59-140">[Publishing your UWP app](https://developer.microsoft.com/store/publish-apps).</span></span>
* [<span data-ttu-id="add59-141">UWP アプリの開発に関するハウツー記事</span><span class="sxs-lookup"><span data-stu-id="add59-141">How-to articles on developing UWP apps</span></span>](https://developer.microsoft.com/windows/apps/develop)
* [<span data-ttu-id="add59-142">UWP 開発者向けコード サンプル</span><span class="sxs-lookup"><span data-stu-id="add59-142">Code Samples for UWP developers</span></span>](https://developer.microsoft.com/windows/samples)
* [<span data-ttu-id="add59-143">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="add59-143">What's a UWP app?</span></span>](universal-application-platform-guide.md)
* [<span data-ttu-id="add59-144">Windows アカウントのサインアップ</span><span class="sxs-lookup"><span data-stu-id="add59-144">Sign up for Windows account</span></span>](sign-up.md)
