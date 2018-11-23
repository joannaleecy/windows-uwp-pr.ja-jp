---
title: リッチ プレゼンスのベスト プラクティス
author: KevinAsgari
description: Xbox Live のリッチ プレゼンスを使うためのベスト プラクティスについて説明します。
ms.assetid: 51a84137-37e4-4f98-b3d3-5ae70e27753d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス, ベスト プラクティス
ms.localizationpriority: medium
ms.openlocfilehash: 4b671ef58850fde91f2bf19167672cc20157959a
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7564548"
---
# <a name="rich-presence-best-practices"></a><span data-ttu-id="6a9bf-104">リッチ プレゼンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="6a9bf-104">Rich Presence best practices</span></span>

<span data-ttu-id="6a9bf-105">次に、ゲームでリッチ プレゼンスを活用するためのヒントを示します。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-105">The following tips will help you get the most from Rich Presence in your game.</span></span> <span data-ttu-id="6a9bf-106">多くのリッチ プレゼンス文字列を定義すれば、他のゲーマーがそのゲームをプレイするプレイヤーを見つけたときに得る情報が増えます。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-106">Keep in mind that the more Rich Presence strings you define, the richer the experience of other gamers who discover people playing your game.</span></span>

-   <span data-ttu-id="6a9bf-107">文字列で統計を使用すると、文字列を設定することができ、文字列について心配する必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-107">Use your stats in your strings, to allow you to set your string and then not worry about it.</span></span>

    <span data-ttu-id="6a9bf-108">文字列にマップ名が含まれていて、CurrentMap 統計を使用して空白に入力する場合は、プレイヤーがゲーム内でマップを切り替えると、サービスによって文字列が適切に更新されます。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-108">If your string has the map name in it, and you're using the CurrentMap stat to fill in the blank, then the service will update your string appropriately, as your players travel from Map to Map in the game.</span></span> <span data-ttu-id="6a9bf-109">この方法により、タイトルがデータ プラットフォームに適切なイベントを送信している限り、文字列を最新状態に保つことについて心配しなくて済みます。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-109">This approach enables you not to worry about keeping the string up-to-date, as long as your title is sending the proper events to the data platform.</span></span>

    <span data-ttu-id="6a9bf-110">タイトルでは、プレゼンス サービスを使用してリッチ プレゼンス基本文字列を定期的に設定することによって、ユーザーのリッチ プレゼンス情報が正確であり、サービスが正しい基本文字列を使用していることを確実にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-110">Your title should set the Rich Presence base string with the presence service periodically, to make sure the Rich Presence information for a user is accurate and the service is using the correct base string.</span></span>

-   <span data-ttu-id="6a9bf-111">リッチ プレゼンスを使用することで、新しい会話の機会が生まれます。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-111">Use Rich Presence to open up new conversation opportunities.</span></span> <span data-ttu-id="6a9bf-112">文字列を適切に設定すると、そのゲームをプレイしたことがないプレイヤーの関心を引くことができます。さらに、そのゲームをプレイしたことがあるものの、最初にプレイしたときに何かを見落としてしまったプレイヤーの関心を引く可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-112">Create strings that are likely to generate interest in a game for new players as well as casual players who might have missed a special feature.</span></span>

-   <span data-ttu-id="6a9bf-113">プレイヤーにアクションを促すリッチ プレゼンス文字列を作成します。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-113">Create Rich Presence strings that motivate players to take action.</span></span> <span data-ttu-id="6a9bf-114">たとえば "霊廟でプレイ中" と表示するかわりに、"助けを求む : 霊廟の防衛" と表示します。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-114">For example, instead of saying "Playing on Mausoleum," say, "Requests assistance; Defending Mausoleum."</span></span> <span data-ttu-id="6a9bf-115">このリッチ プレゼンス ステートを使用することで、ゲームに途中で参加するようなシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-115">Use the Rich Presence state to enable cool scenarios, such as joining a game in progress.</span></span> <span data-ttu-id="6a9bf-116">他のだれかが参加し、助けてくれるのです。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-116">Then another gamer can join and help.</span></span>

-   <span data-ttu-id="6a9bf-117">レベルの到達状況や、隠れたエリアの発見など、ゲーマーが自分の実績を発表できるリッチ プレゼンス文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-117">Create Rich Presence strings that empower gamers to show off their achievements, such as completion of levels or discovery of secret areas.</span></span>

-   <span data-ttu-id="6a9bf-118">リッチ プレゼンス文字列と、関連するパラメーターをローカライズすることで、育てているコミュニティに対する一体感を世界中の Xbox ゲーマーに与えることができます。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-118">Localize your Rich Presence strings and their associated parameters so that Xbox gamers around the world can be a part of the community you are fostering.</span></span>

-   <span data-ttu-id="6a9bf-119">一部のパラメーターは迅速に変更されますが、新しいリッチ プレゼンス データがフレンドに表示されるまでに時間がかかる場合があります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-119">Some parameters change rapidly, but it can take time for new Rich Presence data to show up for a friend.</span></span> <span data-ttu-id="6a9bf-120">文字列に "現在の武器" が含まれていて、プレイヤーがピストルとライフルを簡単に切り替えることができる場合、リッチ プレゼンス文字列は常に正確であるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-120">If your string contains "current weapon" and the player has the ability to switch back and forth between their pistol and rifle, their Rich Presence string may not be completely accurate at any given time.</span></span> <span data-ttu-id="6a9bf-121">ただし、これが問題にはならいないことがあります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-121">However, in some cases, that isn't a problem.</span></span> <span data-ttu-id="6a9bf-122">リッチ プレゼンス文字列に倒した敵の合計数が含まれていて、数秒の間、値が 1 か 2 ずれていることがあっても、シナリオで問題にならない場合があります。</span><span class="sxs-lookup"><span data-stu-id="6a9bf-122">If your Rich Presence string contains the value for total enemies defeated, and the value is off by 1 or 2 for a few seconds, that may be ok for your scenario.</span></span>
