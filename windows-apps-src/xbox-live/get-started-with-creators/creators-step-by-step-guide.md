---
title: Xbox Live クリエーターズ向けステップ バイ ステップ ガイド
author: KevinAsgari
description: クリエーターズ プログラム向けに Xbox Live を統合するための手順に関するガイドラインについて説明します。
ms.assetid: 7f9d093e-479a-4ad4-9965-a4ea6f0b2ac3
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター
ms.localizationpriority: medium
ms.openlocfilehash: bca840455af68b8584901476de2e8e26973b9b0f
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4502177"
---
# <a name="step-by-step-guide-to-integrate-xbox-live-creators-program"></a><span data-ttu-id="184d6-104">Xbox Live クリエーターズ プログラムを統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="184d6-104">Step by step guide to integrate Xbox Live Creators Program</span></span>

<span data-ttu-id="184d6-105">このセクションは、Xbox Live でタイトルを開始し実行する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="184d6-105">This section will help you get your title up and running with Xbox Live:</span></span>

## <a name="1-ensure-you-have-a-title-created-on-dev-center"></a><span data-ttu-id="184d6-106">1. デベロッパー センターで作成されたタイトルがあることを確認する</span><span class="sxs-lookup"><span data-stu-id="184d6-106">1. Ensure you have a title created on Dev Center</span></span>
<span data-ttu-id="184d6-107">すべての Xbox Live タイトルは、サインインして Xbox Live サービスを呼び出すことができるようにするために、デベロッパー センターで定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="184d6-107">Every Xbox Live title must be defined on Dev Center before you will be able to sign-in and make Xbox Live Service calls.</span></span>  <span data-ttu-id="184d6-108">これを行う方法は、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="184d6-108">[Creating a new Creators title](create-and-test-a-new-creators-title.md) will show you how to do this.</span></span>

## <a name="2-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a><span data-ttu-id="184d6-109">2. 適切なガイドに従って、IDE やゲーム エンジンをセットアップする</span><span class="sxs-lookup"><span data-stu-id="184d6-109">2. Follow the appropriate guide to setup your IDE or Game Engine</span></span>
<span data-ttu-id="184d6-110">プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。</span><span class="sxs-lookup"><span data-stu-id="184d6-110">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span></span>

* <span data-ttu-id="184d6-111">「[Visual Studio を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-visual-studio.md)」では、デベロッパー センターで Visual Studio プロジェクトを Xbox Live 構成にリンクする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="184d6-111">[Develop a Creators title with Visual Studio](develop-creators-title-with-visual-studio.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.</span></span>

* <span data-ttu-id="184d6-112">「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="184d6-112">[Develop a Creators title with Unity](develop-creators-title-with-unity.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span></span>

## <a name="3-xbox-live-concepts"></a><span data-ttu-id="184d6-113">3. Xbox Live の概念</span><span class="sxs-lookup"><span data-stu-id="184d6-113">3. Xbox Live Concepts</span></span>
<span data-ttu-id="184d6-114">タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="184d6-114">Once you have a title created, you should learn about the Xbox Live concepts that will affect your experience developing titles.</span></span>

- [<span data-ttu-id="184d6-115">Xbox Live のテスト環境</span><span class="sxs-lookup"><span data-stu-id="184d6-115">Xbox Live test environment</span></span>](../xbox-live-sandboxes.md)
- [<span data-ttu-id="184d6-116">Xbox Live アカウントを承認する</span><span class="sxs-lookup"><span data-stu-id="184d6-116">Authorize Xbox Live accounts</span></span>](authorize-xbox-live-accounts.md)

## <a name="4-add-xbox-live-features"></a><span data-ttu-id="184d6-117">4. Xbox Live の機能を追加する</span><span class="sxs-lookup"><span data-stu-id="184d6-117">4. Add Xbox Live Features</span></span>

<span data-ttu-id="184d6-118">Xbox Live の機能をゲームに追加します。</span><span class="sxs-lookup"><span data-stu-id="184d6-118">Add Xbox Live features to your game:</span></span>

- [<span data-ttu-id="184d6-119">Xbox Live ソーシャル プラットフォーム - プロフィール、フレンド、プレゼンス</span><span class="sxs-lookup"><span data-stu-id="184d6-119">Xbox Live Social Platform - Profile, Friends, Presence</span></span>](../social-platform/social-platform.md)
- [<span data-ttu-id="184d6-120">Xbox Live データ プラットフォーム - 統計、ランキング、実績</span><span class="sxs-lookup"><span data-stu-id="184d6-120">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>](../data-platform/data-platform.md)
- [<span data-ttu-id="184d6-121">Xbox Live ストレージ プラットフォーム - 接続ストレージ、タイトル ストレージ</span><span class="sxs-lookup"><span data-stu-id="184d6-121">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>](../storage-platform/storage-platform.md)

## <a name="5-release-your-title"></a><span data-ttu-id="184d6-122">5. タイトルをリリースする</span><span class="sxs-lookup"><span data-stu-id="184d6-122">5. Release Your Title</span></span>

<span data-ttu-id="184d6-123">Xbox Live クリエーターズ プログラムを使用している場合、このリリースのプロセスは他の UWP のリリースとまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="184d6-123">If you are using the Xbox Live Creators Program, then the process is no different than releasing any other UWP.</span></span>  <span data-ttu-id="184d6-124">プロセスについて詳しくは、「[Windows アプリを公開する](https://developer.microsoft.com/en-us/store/publish-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="184d6-124">For details on the process, you can see [Publish Windows apps](https://developer.microsoft.com/en-us/store/publish-apps).</span></span>
