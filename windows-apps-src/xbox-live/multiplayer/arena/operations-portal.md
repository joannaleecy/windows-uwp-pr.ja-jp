---
title: Xbox アリーナ操作ポータル
author: KevinAsgari
description: 操作のポータルを使用して、Xbox のトーナメントを管理する方法について説明します。
ms.author: kevinasg
ms.date: 06-18-2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム、uwp、windows 10, xbox one、アリーナ、トーナメント、操作, ポータル
ms.localizationpriority: medium
ms.openlocfilehash: 84b2deb0a192d7e7b8d8360ec703d4eb5d3a0a23
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209479"
---
# <a name="xbox-arena-operations-portal"></a><span data-ttu-id="38ddd-104">Xbox アリーナ操作ポータル</span><span class="sxs-lookup"><span data-stu-id="38ddd-104">Xbox Arena Operations Portal</span></span>



<span data-ttu-id="38ddd-105">Xbox アリーナ操作ポータルを作成し、正式な Xbox アリーナと統合されているタイトルからトーナメントを管理できます。</span><span class="sxs-lookup"><span data-stu-id="38ddd-105">The Xbox Arena Operations Portal allows you to create and manage official tournaments for titles that are integrated with Xbox Arena.</span></span> <span data-ttu-id="38ddd-106">公式のトーナメント タイトルによって実行でき、開発者カスタマイズ機能と管理のトーナメントを作成したユーザーよりも高い。</span><span class="sxs-lookup"><span data-stu-id="38ddd-106">Official tournaments are run by the title and allow the developer a greater degree of customizability and manageability than user created tournaments.</span></span>

<span data-ttu-id="38ddd-107">このポータルでは、ビルドして、タイトルに合わせてカスタマイズされたトーナメント エクスペリエンスを実行できます。</span><span class="sxs-lookup"><span data-stu-id="38ddd-107">This portal gives you the opportunity to build and run tournament experiences that are tailored for your title.</span></span>

> [!IMPORTANT]  
> <span data-ttu-id="38ddd-108">Xbox アリーナ操作ポータルは、マネージ パートナーが利用できるのみとID@Xboxメンバーです。</span><span class="sxs-lookup"><span data-stu-id="38ddd-108">Xbox Arena Operations Portal is only available to managed partners and ID@Xbox members.</span></span> <span data-ttu-id="38ddd-109">Xbox Live クリエーターズ プログラムでは利用できません。</span><span class="sxs-lookup"><span data-stu-id="38ddd-109">It is not available to the Xbox Live Creators Program.</span></span>

## <a name="features"></a><span data-ttu-id="38ddd-110">機能</span><span class="sxs-lookup"><span data-stu-id="38ddd-110">Features</span></span>

<span data-ttu-id="38ddd-111">Xbox アリーナ ポータルには、トーナメントのプレイヤーが作成した以外の機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="38ddd-111">The Xbox Arena portal offers features beyond those of player-created tournaments.</span></span> <span data-ttu-id="38ddd-112">次の表は、トーナメントを作成したプレイヤー経由で提供される追加の機能を示しています。</span><span class="sxs-lookup"><span data-stu-id="38ddd-112">The following lists outline the additional features offered over player created tournaments:</span></span>

#### <a name="tournament-creation-features"></a><span data-ttu-id="38ddd-113">トーナメントの作成機能:</span><span class="sxs-lookup"><span data-stu-id="38ddd-113">Tournament creation features:</span></span>

* <span data-ttu-id="38ddd-114">招待のみのトーナメントを作成します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-114">Create invitation-only tournaments</span></span>
* <span data-ttu-id="38ddd-115">トーナメントに参加できるどの国と地域を指定します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-115">Specify which countries and regions can participate in the tournament</span></span>
* <span data-ttu-id="38ddd-116">選択は、デベロッパー センター経由で公開され、追加のアート資産をカスタマイズします。</span><span class="sxs-lookup"><span data-stu-id="38ddd-116">Select customized art assets published via Dev Center</span></span>
* <span data-ttu-id="38ddd-117">Prizing フラグ (トーナメントが、受賞歴のある用を報いるプレイヤーに示すアイコン) と位トーナメントの使用条件を設定します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-117">Set a prizing flag (an icon that indicates to players that the tournament rewards a prize for winning) and the terms of use for prize tournaments</span></span>
* <span data-ttu-id="38ddd-118">タイトルまたはマッチを設定するために関連付けられているタイトル サービスによって解釈されるゲーム モードのカスタマイズを作成します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-118">Create customized game modes to be interpreted by the title or associated title services for setting up a match</span></span>
* <span data-ttu-id="38ddd-119">開発サンド ボックス内でトーナメントを作成します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-119">Create tournaments in developer sandboxes</span></span>

#### <a name="tournament-management-features"></a><span data-ttu-id="38ddd-120">トーナメントの管理機能:</span><span class="sxs-lookup"><span data-stu-id="38ddd-120">Tournament management features:</span></span>

* <span data-ttu-id="38ddd-121">一時停止し、アクティブなトーナメントのプレイ</span><span class="sxs-lookup"><span data-stu-id="38ddd-121">Pause and play active tournaments</span></span>
* <span data-ttu-id="38ddd-122">結果を上書き</span><span class="sxs-lookup"><span data-stu-id="38ddd-122">Override results</span></span>
* <span data-ttu-id="38ddd-123">トーナメントのプレイヤーと配置のビュー全体名簿</span><span class="sxs-lookup"><span data-stu-id="38ddd-123">View entire roster of tournament players and placement</span></span>

## <a name="get-setup-with-the-xbox-arena-operations-portal"></a><span data-ttu-id="38ddd-124">Xbox アリーナ操作ポータルを使用してセットアップを取得します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-124">Get setup with the Xbox Arena Operations portal</span></span>

<span data-ttu-id="38ddd-125">セットアップを取得するのには、ポータルの携帯電話会社によるとしてへのサインアップする方法の詳細については、Microsoft アカウント マネージャーにお問い合わせが必要があります。</span><span class="sxs-lookup"><span data-stu-id="38ddd-125">In order to get setup, you'll need to reach out to your Microsoft account manager for more details about how to sign up as an operator on the portal.</span></span> <span data-ttu-id="38ddd-126">チームのメンバーは自分の Microsoft アカウントを使用してサインインに使用できるリンクを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="38ddd-126">They can provide a link that a member of your team can use to sign in by using their Microsoft Account.</span></span>

<span data-ttu-id="38ddd-127">サインインすると、Microsoft アカウント マネージャーは、お客様に代わって作成された演算子を取得する手順を移動します。</span><span class="sxs-lookup"><span data-stu-id="38ddd-127">Once signed in, your Microsoft account manager will go through the steps to get an operator created on your behalf.</span></span> <span data-ttu-id="38ddd-128">そこから、初期サインイン プロセスを通過すると、チームからユーザーを追加できるされます。</span><span class="sxs-lookup"><span data-stu-id="38ddd-128">From there, you’ll be able to add additional users from your team once they go through the initial sign-in process.</span></span> <span data-ttu-id="38ddd-129">ポータルのロールの管理」セクションで、チームのメンバーごとに個別にアクセスを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="38ddd-129">You can also set individualized access for each member of your team via the roles management section of the portal.</span></span>

> [!IMPORTANT]  
> <span data-ttu-id="38ddd-130">複数のユーザー間で共有アカウントを作成することはできません、各ユーザーは、独自の個々 の資格情報でログインします。</span><span class="sxs-lookup"><span data-stu-id="38ddd-130">You cannot create shared accounts across multiple users, each user must login with their own individual credentials.</span></span>
