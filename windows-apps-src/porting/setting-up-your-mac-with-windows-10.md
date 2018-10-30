---
author: stevewhims
description: 現在の Mac コンピューターを使用して、Windows 用アプリを開発します。
title: Windows 10 を使用するための Mac のセットアップ
ms.assetid: 6D520610-5DE0-476E-A792-AA57E002D309
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 661c324fbe7a80a6ff150da06536879a25c0c0c2
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5756187"
---
# <a name="setting-up-your-mac-with-windows-10"></a><span data-ttu-id="250d2-104">Windows 10 を使用するための Mac のセットアップ</span><span class="sxs-lookup"><span data-stu-id="250d2-104">Setting up your Mac with Windows 10</span></span>


<span data-ttu-id="250d2-105">現在の Mac コンピューターを使用して、Windows 用アプリを開発します。</span><span class="sxs-lookup"><span data-stu-id="250d2-105">Use your current Mac computer to develop apps for Windows.</span></span>

## <a name="run-windows-on-your-mac-and-use-visual-studio"></a><span data-ttu-id="250d2-106">Mac で Windows を実行し、Visual Studio を使う</span><span class="sxs-lookup"><span data-stu-id="250d2-106">Run Windows on your Mac and use Visual Studio</span></span>

<span data-ttu-id="250d2-107">ユニバーサル Windows アプリの開発を始める準備は整っているのに、PC が手元にない、そういう方でも</span><span class="sxs-lookup"><span data-stu-id="250d2-107">Are you ready to start developing Universal Windows apps, but you don't have a PC handy?</span></span> <span data-ttu-id="250d2-108">大丈夫です。Mac を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="250d2-108">That's okay — you can use your Mac!</span></span> <span data-ttu-id="250d2-109">Apple Boot Camp や Oracle VirtualBox、VMware Fusion、Parallels Desktop のような人気のサードパーティ ソリューションは、windows 10 と Microsoft Visual Studio を Apple コンピューターにインストールできます。</span><span class="sxs-lookup"><span data-stu-id="250d2-109">With popular third-party solutions like Apple Boot Camp, Oracle VirtualBox, VMware Fusion, and Parallels Desktop, you can install Windows10 and Microsoft Visual Studio on your Apple computer.</span></span>

<span data-ttu-id="250d2-110">**注:** ディスクまたは USB フラッシュ ドライブ上の windows 10 のブート イメージが必要になります。</span><span class="sxs-lookup"><span data-stu-id="250d2-110">**Note**You will need a Windows10 bootable image on disk or USB flash drive.</span></span> <span data-ttu-id="250d2-111">MSDN サブスクライバーである場合は、MSDN サブスクライバー ダウンロード センターからインストール イメージをダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="250d2-111">If you are a MSDN Subscriber, you can download the install image from the MSDN Subscriber Downloads center.</span></span> <span data-ttu-id="250d2-112">サブスクライバーでない場合は、 [Microsoft Store](http://apps.microsoft.com/windows/app)からインストーラーを購入できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-112">If you aren't a subscriber, the installer can be purchased from the [Microsoft Store](http://apps.microsoft.com/windows/app).</span></span> <span data-ttu-id="250d2-113">[この場所](http://go.microsoft.com/fwlink/?LinkId=623906)からダウンロードすることもできます。これは、Windows を既に実行中でありアップグレードする場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="250d2-113">You can also download it from [this location](http://go.microsoft.com/fwlink/?LinkId=623906), which is useful if you are already running Windows and wish to upgrade.</span></span>

<span data-ttu-id="250d2-114">Windows を実行しているしたら、 [windows 10 用のダウンロードとツール](https://developer.microsoft.com/en-us/windows/downloads)から Visual Studio の最新リリースをインストールし、アプリの作成を開始!</span><span class="sxs-lookup"><span data-stu-id="250d2-114">Once you have Windows running, you can then install the latest release of Visual Studio from [Developer downloads for Windows10](https://developer.microsoft.com/en-us/windows/downloads) and start writing apps!</span></span>

<span data-ttu-id="250d2-115">**注:** Visual Studio のデバイスのエミュレーターを使用する場合は、64 ビット (x64) バージョンの windows 10 Pro 以上をインストール**する必要があります**。</span><span class="sxs-lookup"><span data-stu-id="250d2-115">**Note**If you plan to use the Visual Studio device emulators, you **must** install a 64-bit (x64) version of Windows10 Pro or better.</span></span> <span data-ttu-id="250d2-116">ただし、以前の Mac では 64 ビット版の Windows を実行できない場合があります。</span><span class="sxs-lookup"><span data-stu-id="250d2-116">Unfortunately, some older Macs cannot run 64-bit Windows.</span></span> <span data-ttu-id="250d2-117">この [Apple サポート ページ](http://go.microsoft.com/fwlink/p/?LinkID=397959)で、お使いのハードウェアに互換性があるかどうかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="250d2-117">Please check with Apple if your hardware is compatible on this[Apple support page](http://go.microsoft.com/fwlink/p/?LinkID=397959).</span></span>

## <a name="apple-boot-camp"></a><span data-ttu-id="250d2-118">Apple Boot Camp</span><span class="sxs-lookup"><span data-stu-id="250d2-118">Apple Boot Camp</span></span>

<span data-ttu-id="250d2-119">Boot Camp アシスタント アプリは最近のすべての Mac にプリインストールされて起動しては windows 10 をインストールするプロセス。</span><span class="sxs-lookup"><span data-stu-id="250d2-119">The Boot Camp Assistant app is pre-installed on every recent Mac, and launching it will walk you through the process of installing Windows10.</span></span> <span data-ttu-id="250d2-120">必要なのもは、上記のソースからダウンロードした Windows のコピーと 30 Gb 以上の空きディスク領域だけです。</span><span class="sxs-lookup"><span data-stu-id="250d2-120">All you need is a copy of Windows (from the sources listed above) and at least 30 Gb of free disk space.</span></span> <span data-ttu-id="250d2-121">インストールしたら、Mac OSX と Windows 10 のどちらを起動するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-121">Once installed, you can choose to boot into Mac OSX or Windows 10.</span></span> <span data-ttu-id="250d2-122">詳しくは、Apple の [Boot Camp に関するページ](http://go.microsoft.com/fwlink/?LinkId=623912)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="250d2-122">For more info, see Apple's [Boot Camp instructions page](http://go.microsoft.com/fwlink/?LinkId=623912).</span></span>

## <a name="parallels-desktop"></a><span data-ttu-id="250d2-123">Parallels Desktop</span><span class="sxs-lookup"><span data-stu-id="250d2-123">Parallels Desktop</span></span>

<span data-ttu-id="250d2-124">Parallels Desktop 11 を使用すると、Visual Studio と Cortana など、Windows アプリと既存の Mac アプリケーションを並べて実行できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-124">Using Parallels Desktop 11, you can run Windows apps side-by-side with existing Mac applications, including Visual Studio and Cortana.</span></span> <span data-ttu-id="250d2-125">強化されたデバッグや Docker と Jenkins のサポートなど、開発者向けの追加機能を含むプロ バージョンを利用できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-125">A pro version is available that includes extra features for developers, including improved debugging, and support for Docker and Jenkins.</span></span> <span data-ttu-id="250d2-126">詳しい情報、および無料試用版については、[Parallels Desktop に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=281827)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="250d2-126">For more info, and a free trial version, see [Parallels Desktop](http://go.microsoft.com/fwlink/p/?LinkId=281827).</span></span>

## <a name="vmware-fusion"></a><span data-ttu-id="250d2-127">VMWare Fusion</span><span class="sxs-lookup"><span data-stu-id="250d2-127">VMWare Fusion</span></span>

<span data-ttu-id="250d2-128">VMWare の Fusion 8 を使うと、Mac デスクトップで Visual Studio を実行できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-128">Fusion 8 from VMWare will let you run Visual Studio right on your Mac desktop.</span></span> <span data-ttu-id="250d2-129">vSphere サポートなど、いくつかの高度な機能を開発者に提供するプロ バージョンを利用できます。</span><span class="sxs-lookup"><span data-stu-id="250d2-129">A pro version is available to offer developers some more advanced features such as vSphere support.</span></span> <span data-ttu-id="250d2-130">詳しい情報、および無料試用版については、「[VMware Fusion](http://go.microsoft.com/fwlink/p/?LinkId=281826)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="250d2-130">For more info, and a free trial version, see [VMware Fusion](http://go.microsoft.com/fwlink/p/?LinkId=281826).</span></span>

## <a name="oracle-virtualbox"></a><span data-ttu-id="250d2-131">Oracle VirtualBox</span><span class="sxs-lookup"><span data-stu-id="250d2-131">Oracle VirtualBox</span></span>

<span data-ttu-id="250d2-132">VirtualBox は、お使いのコンピューター上で仮想マシンを実行するための無料アプリケーションであり、Mac での Windows の実行をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="250d2-132">VirtualBox is a free application for running virtual machines on your computer, and it supports running Windows on Mac.</span></span> <span data-ttu-id="250d2-133">余分な機能を省いたバージョンですが、価格は魅力的です。</span><span class="sxs-lookup"><span data-stu-id="250d2-133">It is a no-frills option, but the price is appealing.</span></span> <span data-ttu-id="250d2-134">詳しくは、「[VirtualBox](http://go.microsoft.com/fwlink/p/?LinkId=280599)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="250d2-134">For more info, see [VirtualBox](http://go.microsoft.com/fwlink/p/?LinkId=280599).</span></span>

