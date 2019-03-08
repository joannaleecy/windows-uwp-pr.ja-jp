---
title: Xbox Live クリエーターズ向けステップ バイ ステップ ガイド
description: クリエーターズ プログラム向けに Xbox Live を統合するための手順に関するガイドラインについて説明します。
ms.assetid: 7f9d093e-479a-4ad4-9965-a4ea6f0b2ac3
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, クリエーター
ms.localizationpriority: medium
ms.openlocfilehash: ae02fe412e6300ac74b3f1106cdf6a5bb304d36b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628307"
---
# <a name="step-by-step-guide-to-integrate-xbox-live-creators-program"></a><span data-ttu-id="62d5b-104">Xbox Live クリエーターズ プログラムを統合するためのステップ バイ ステップ ガイド</span><span class="sxs-lookup"><span data-stu-id="62d5b-104">Step by step guide to integrate Xbox Live Creators Program</span></span>

<span data-ttu-id="62d5b-105">このセクションは、Xbox Live でタイトルを開始し実行する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="62d5b-105">This section will help you get your title up and running with Xbox Live:</span></span>

## <a name="1-ensure-you-have-a-title-created-in-partner-center"></a><span data-ttu-id="62d5b-106">1. パートナー センターで作成したタイトルがあることを確認します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-106">1. Ensure you have a title created in Partner Center</span></span>
<span data-ttu-id="62d5b-107">Xbox Live のすべてのタイトルを定義する必要があります[パートナー センター](https://partner.microsoft.com/dashboard)前に、サインインし、Xbox Live サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="62d5b-107">Every Xbox Live title must be defined in [Partner Center](https://partner.microsoft.com/dashboard) before you will be able to sign-in and make Xbox Live Service calls.</span></span>  <span data-ttu-id="62d5b-108">これを行う方法は、「[新しいクリエーターズ タイトルの作成](create-and-test-a-new-creators-title.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-108">[Creating a new Creators title](create-and-test-a-new-creators-title.md) will show you how to do this.</span></span>

## <a name="2-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a><span data-ttu-id="62d5b-109">2. IDE、ゲーム エンジンを設定する適切なガイドに従ってください。</span><span class="sxs-lookup"><span data-stu-id="62d5b-109">2. Follow the appropriate guide to setup your IDE or Game Engine</span></span>
<span data-ttu-id="62d5b-110">プラットフォームやエンジンに関する適切なファースト ステップ ガイドに従い、それに沿って学習することで、Xbox Live の基本を習得することができます。</span><span class="sxs-lookup"><span data-stu-id="62d5b-110">You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.</span></span>

* <span data-ttu-id="62d5b-111">[Visual Studio を使用した Creators タイトルを開発](develop-creators-title-with-visual-studio.md)はパートナー センターで、Xbox Live の構成と、Visual Studio プロジェクトをリンクする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-111">[Develop a Creators title with Visual Studio](develop-creators-title-with-visual-studio.md) will show you how to link your Visual Studio project with your Xbox Live configuration in Partner Center.</span></span>

* <span data-ttu-id="62d5b-112">「[Unity を使用してクリエーターズ タイトルを開発する](develop-creators-title-with-unity.md)」では、Xbox Live 対応の新しい Unity タイトルを作成する方法、ランキングなどの機能をタイトルに追加する方法、およびネイティブの Visual Studio プロジェクトを生成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-112">[Develop a Creators title with Unity](develop-creators-title-with-unity.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.</span></span>

## <a name="3-xbox-live-concepts"></a><span data-ttu-id="62d5b-113">3.Xbox Live の概念</span><span class="sxs-lookup"><span data-stu-id="62d5b-113">3. Xbox Live Concepts</span></span>
<span data-ttu-id="62d5b-114">タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="62d5b-114">Once you have a title created, you should learn about the Xbox Live concepts that will affect your experience developing titles.</span></span>

- [<span data-ttu-id="62d5b-115">テスト環境の Xbox Live</span><span class="sxs-lookup"><span data-stu-id="62d5b-115">Xbox Live test environment</span></span>](../xbox-live-sandboxes.md)
- [<span data-ttu-id="62d5b-116">Xbox Live アカウントを承認します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-116">Authorize Xbox Live accounts</span></span>](authorize-xbox-live-accounts.md)

## <a name="4-add-xbox-live-features"></a><span data-ttu-id="62d5b-117">4。Xbox Live 機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-117">4. Add Xbox Live Features</span></span>

<span data-ttu-id="62d5b-118">Xbox Live の機能をゲームに追加します。</span><span class="sxs-lookup"><span data-stu-id="62d5b-118">Add Xbox Live features to your game:</span></span>

- [<span data-ttu-id="62d5b-119">Xbox Live ソーシャル プラットフォームのプロファイル、友人、プレゼンス</span><span class="sxs-lookup"><span data-stu-id="62d5b-119">Xbox Live Social Platform - Profile, Friends, Presence</span></span>](../social-platform/social-platform.md)
- [<span data-ttu-id="62d5b-120">Xbox Live データ プラットフォーム - Stats、ランキング、実績</span><span class="sxs-lookup"><span data-stu-id="62d5b-120">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>](../data-platform/data-platform.md)
- [<span data-ttu-id="62d5b-121">Xbox の記憶域のライブ プラットフォーム - 接続された記憶域、タイトルのストレージ</span><span class="sxs-lookup"><span data-stu-id="62d5b-121">Xbox Live Storage Platform - Connected Storage, Title Storage</span></span>](../storage-platform/storage-platform.md)

## <a name="5-release-your-title"></a><span data-ttu-id="62d5b-122">5。リリースのタイトル</span><span class="sxs-lookup"><span data-stu-id="62d5b-122">5. Release Your Title</span></span>

<span data-ttu-id="62d5b-123">Xbox Live クリエーターズ プログラムを使用している場合、このリリースのプロセスは他の UWP のリリースとまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="62d5b-123">If you are using the Xbox Live Creators Program, then the process is no different than releasing any other UWP.</span></span>  <span data-ttu-id="62d5b-124">プロセスについて詳しくは、「[Windows アプリを公開する](https://developer.microsoft.com/en-us/store/publish-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="62d5b-124">For details on the process, you can see [Publish Windows apps](https://developer.microsoft.com/en-us/store/publish-apps).</span></span>
