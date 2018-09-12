---
author: aablackm
title: Xbox One 本体上でのテスト
description: Xbox Live の本体で Xbox Live サービスをテストする方法について説明します
ms.author: aablackm
ms.date: 08/15/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, ゲーム、xbox、xbox live, xbox one
ms.localizationpriority: low
ms.openlocfilehash: 5500f6f396d6dae179e434283097c34274d9b829
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881712"
---
# <a name="testing-on-the-xbox-one-console"></a><span data-ttu-id="4eb67-104">Xbox One 本体上でのテスト</span><span class="sxs-lookup"><span data-stu-id="4eb67-104">Testing on the Xbox One console</span></span>

<span data-ttu-id="4eb67-105">本体の Xbox One ファミリのタイトルを開発するときは、自然タイトルと実際の本体で Xbox Live の機能をテストすることができるようにすることはのみ。</span><span class="sxs-lookup"><span data-stu-id="4eb67-105">When developing your title for the Xbox One family of consoles it is only natural that you would want to be able to test your title and Xbox Live features on an actual console.</span></span> <span data-ttu-id="4eb67-106">ハードウェアでタイトルをテストするためのいくつかのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4eb67-106">There are a few options for testing your title on hardware.</span></span> <span data-ttu-id="4eb67-107">本体の開発者モードのアクティブ化をユニバーサル Windows プラットフォーム (UWP) のタイトルやアプリをテストするのに、製品版の Xbox One 本体を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="4eb67-107">You can use any retail Xbox One Console to test a Universal Windows Platform (UWP) title or app by activating the console's developer mode.</span></span> <span data-ttu-id="4eb67-108">このオプションはすべての開発者にアクセスできるように、Xbox Live クリエーターズ プログラムの開発者の唯一のオプションです。</span><span class="sxs-lookup"><span data-stu-id="4eb67-108">This option is accessible to all developers and is the only option for Xbox Live Creators Program Developers.</span></span> <span data-ttu-id="4eb67-109">ID@Xboxおよび対象パートナーに順序と Xbox 開発キットを使用するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4eb67-109">ID@Xbox and managed partners have the option of ordering and using an Xbox Development Kit.</span></span>

## <a name="retail-console-testing-xbox-live-creators"></a><span data-ttu-id="4eb67-110">製品版の本体のテスト: Xbox Live クリエーターズ</span><span class="sxs-lookup"><span data-stu-id="4eb67-110">Retail console testing: Xbox Live Creators</span></span>

<span data-ttu-id="4eb67-111">市販の Xbox One 本体で開発者モードをアクティブ化は Visual Studio のビルドとペアリングすることによって、Xbox One 本体に UWP タイトルとアプリを展開できます。</span><span class="sxs-lookup"><span data-stu-id="4eb67-111">Activating developer mode on an Xbox One retail console will allow you to deploy UWP titles and apps to the Xbox One Console by pairing it with a Visual Studio build.</span></span> <span data-ttu-id="4eb67-112">これは、Xbox Live クリエーターズ プログラム開発者向けのオプションのテスト コンソールです。</span><span class="sxs-lookup"><span data-stu-id="4eb67-112">This is the console testing option for Xbox Live Creators Program Developers.</span></span> <span data-ttu-id="4eb67-113">製品版の Xbox One 本体で XDK ゲームをテストすることはできません。</span><span class="sxs-lookup"><span data-stu-id="4eb67-113">You will not be able to test XDK games on a retail Xbox One console.</span></span>

* <span data-ttu-id="4eb67-114">開発製品版の本体でテストできるようにする[開発者モードのアクティブ化手順](../xbox-apps/devkit-activation.md)に従います。</span><span class="sxs-lookup"><span data-stu-id="4eb67-114">Follow the [developer mode activation instructions](../xbox-apps/devkit-activation.md) to allow development testing on your retail console.</span></span>  
* <span data-ttu-id="4eb67-115">次の[設定 Xbox One の指示](../xbox-apps/development-environment-setup.md#setting-up-your-xbox-one)に従って、Xbox One にタイトルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="4eb67-115">Load your title onto the Xbox One by following the [Setting up your Xbox One instructions](../xbox-apps/development-environment-setup.md#setting-up-your-xbox-one).</span></span>  
* <span data-ttu-id="4eb67-116">本体をリテール モードに戻す、または製品版の本体で開発環境をアンインストールする[開発者モードの非アクティブ化手順](../xbox-apps/devkit-deactivation.md)に従います。</span><span class="sxs-lookup"><span data-stu-id="4eb67-116">Follow the [developer mode deactivation instructions](../xbox-apps/devkit-deactivation.md) to put your console back into retail mode or uninstall the development environment on your retail console.</span></span>  
* <span data-ttu-id="4eb67-117">本体が開発者モードではアクセスできますがリモートでお使いの PC で[Xbox 用の Windows デバイス ポータル](../debug-test-perf/device-portal-xbox.md)を使用しています。</span><span class="sxs-lookup"><span data-stu-id="4eb67-117">While your console is in developer mode you can access it remotely through your PC by using the [Windows Devices portal for Xbox](../debug-test-perf/device-portal-xbox.md).</span></span>  

## <a name="xbox-development-kit-testing-idxbox-and-managed-partners"></a><span data-ttu-id="4eb67-118">Xbox 開発キットのテスト:ID@Xboxおよび対象パートナー</span><span class="sxs-lookup"><span data-stu-id="4eb67-118">Xbox Development kit testing: ID@Xbox and Managed Partners</span></span>

<span data-ttu-id="4eb67-119">対象パートナーとID@Xbox開発者になるだけがアクセスできる管理対象の開発者アカウントを持つ、 [Xbox デベロッパー ストア](https://gamedevstore.partners.extranet.microsoft.com/)から、Xbox 開発キットを購入するオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="4eb67-119">Managed partners and ID@Xbox developers have the option to purchase an Xbox developer kit from the [Xbox Dev Store](https://gamedevstore.partners.extranet.microsoft.com/), which is only accessible to those with managed developer accounts.</span></span> <span data-ttu-id="4eb67-120">Xbox 開発キットすることが XDK を読み込み、コンソールにゲームをテストするため、UWP ゲームを開発キットを調べることもできます。</span><span class="sxs-lookup"><span data-stu-id="4eb67-120">Xbox developer kits will allow you to load XDK games to the console for testing, UWP games can also be tested by dev kit.</span></span> <span data-ttu-id="4eb67-121">開発キットは、ハードウェア オプションとより詳細なパフォーマンスのテストと本体の管理を使用するテスト機能が付属します。</span><span class="sxs-lookup"><span data-stu-id="4eb67-121">Developer kits come with hardware options and testing features that allow for more in-depth performance testing and console management.</span></span>

<span data-ttu-id="4eb67-122">Xbox 開発者とへの取り組みを開始するには、キットは、 [Xbox One の開発の記事をはじめ](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-getting-started)対象パートナーのドキュメントのサイトをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4eb67-122">To begin your journey with the Xbox developer kit read the [Getting Started with Xbox One Development article](https://developer.microsoft.com/en-us/games/xbox/docs/xdk/atoc-getting-started) on the managed partner documentation site.</span></span> <span data-ttu-id="4eb67-123">このドキュメントは、承認された開発者にアクセスできるようにのみ、ID@Xboxプログラムおよび対象パートナーです。</span><span class="sxs-lookup"><span data-stu-id="4eb67-123">This documentation is only accessible to authorized developers in the ID@Xbox program and managed partners.</span></span>