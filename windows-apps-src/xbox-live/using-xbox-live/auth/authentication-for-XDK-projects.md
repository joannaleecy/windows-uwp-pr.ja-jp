---
title: XDK プロジェクトの認証
author: KevinAsgari
description: Xbox 開発キット (XDK) タイトルで Xbox Live ユーザーをサインインする方法について説明します。
ms.assetid: 713bb2e3-80c5-4ac9-8697-257525f243d3
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 594c966ab3d1e70d5a423da0e4681ecfca22f4b0
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5442711"
---
# <a name="authentication-for-xdk-projects"></a><span data-ttu-id="ebe20-104">XDK プロジェクトの認証</span><span class="sxs-lookup"><span data-stu-id="ebe20-104">Authentication for XDK projects</span></span>

<span data-ttu-id="ebe20-105">ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebe20-105">To take advantage of Xbox Live features in games, a user needs to create an Xbox Live profile to identify themselves in the Xbox Live community.</span></span>  <span data-ttu-id="ebe20-106">Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。</span><span class="sxs-lookup"><span data-stu-id="ebe20-106">Xbox Live services keep track of game related activities using that Xbox Live profile, such as the user's gamertag and gamer picture, who the user's gaming friends are, what games the user has played, what achievements the user has unlocked, where the user stands on the leaderboard for a particular game, etc.</span></span>

<span data-ttu-id="ebe20-107">大まかには、以下の手順に従って Xbox Live API を使用します。</span><span class="sxs-lookup"><span data-stu-id="ebe20-107">At a high level, you use the Xbox Live APIs by following these steps:</span></span>
1. <span data-ttu-id="ebe20-108">対話しているユーザーを識別する</span><span class="sxs-lookup"><span data-stu-id="ebe20-108">Identify the interacting user</span></span>
2. <span data-ttu-id="ebe20-109">ユーザーに基づいて Xbox Live コンテキストを作成する</span><span class="sxs-lookup"><span data-stu-id="ebe20-109">Create an Xbox Live context based on the user</span></span>
3. <span data-ttu-id="ebe20-110">作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする</span><span class="sxs-lookup"><span data-stu-id="ebe20-110">Use the Xbox Live context to access Xbox Live services</span></span>
4. <span data-ttu-id="ebe20-111">ゲームが終了またはユーザーがサインアウトしたら、XboxLiveContext オブジェクトを null に設定して解放する</span><span class="sxs-lookup"><span data-stu-id="ebe20-111">When the game exits or the user signs-out, release the XboxLiveContext object by setting it to null</span></span>

### <a name="creating-an-xboxliveuser-object"></a><span data-ttu-id="ebe20-112">XboxLiveUser オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="ebe20-112">Creating an XboxLiveUser object</span></span>
<span data-ttu-id="ebe20-113">ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。</span><span class="sxs-lookup"><span data-stu-id="ebe20-113">Most of the Xbox Live activities are related to the Xbox Live Users.</span></span>  <span data-ttu-id="ebe20-114">ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebe20-114">As a game developer, you need to first create an XboxLiveUser object to represent the local user.</span></span>

<span data-ttu-id="ebe20-115">C++:</span><span class="sxs-lookup"><span data-stu-id="ebe20-115">C++:</span></span>
```
Windows::Xbox::System::User^ user; // the interacting user.  From User::Users, etc
std::shared_ptr<xbox::services::xbox_live_context> xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>( user );
```

<span data-ttu-id="ebe20-116">WinRT:</span><span class="sxs-lookup"><span data-stu-id="ebe20-116">WinRT:</span></span>
```
Windows::Xbox::System::User^ user; // the interacting user.  From User::Users, etc
Microsoft::Xbox::Services::XboxLiveContext^ xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext( user );
```
