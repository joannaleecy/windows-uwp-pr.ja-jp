---
title: リッチ プレゼンス
author: KevinAsgari
description: Xbox Live リッチ プレゼンスがタイトルの販売促進にどのように役立つかついて説明します。
ms.assetid: 00042359-f877-4b26-9067-58834590b1dd
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス
ms.localizationpriority: medium
ms.openlocfilehash: 280df5a5fb2ffda28117d7e49196f2a19fc4ecd6
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5819258"
---
# <a name="rich-presence"></a><span data-ttu-id="08151-104">リッチ プレゼンス</span><span class="sxs-lookup"><span data-stu-id="08151-104">Rich Presence</span></span>

<span data-ttu-id="08151-105">リッチ プレゼンスにより、ゲームでプレイヤーの現在のプレイ状況を公開できます。</span><span class="sxs-lookup"><span data-stu-id="08151-105">By using Rich Presence, your game can advertise what a player is doing right now.</span></span> <span data-ttu-id="08151-106">たとえば、リッチ プレゼンス文字列を使って、*不在*などのプレイヤーの状態を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="08151-106">For example, your game can use Rich Presence strings to show all gamers the status of your game's players, such as *Away*.</span></span> <span data-ttu-id="08151-107">リッチ プレゼンス情報は、Xbox Live に接続している他のゲーマーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="08151-107">Rich Presence information is visible to gamers connected to Xbox Live.</span></span> <span data-ttu-id="08151-108">理想としては、プレイヤーがゲーム内のどこで、何をしているのかを、リッチ プレゼンス文字列を使用して他の Xbox Live ゲーマーに通知します。</span><span class="sxs-lookup"><span data-stu-id="08151-108">Ideally, a Rich Presence string tells other Xbox Live gamers what a player is doing, and where in your game the player is doing it.</span></span> <span data-ttu-id="08151-109">Xbox One でのリッチ プレゼンス文字列の概念は、Xbox 360 での概念と同じですが、新しい実装はサービス イニシアティブとしてのエンターテインメントに従います。</span><span class="sxs-lookup"><span data-stu-id="08151-109">The concept of Rich Presence strings is the same on Xbox One as it was on Xbox 360, but the new implementation follows the Entertainment as a Service initiative.</span></span> <span data-ttu-id="08151-110">このセクションのトピックでは、リッチ プレゼンス文字列の構成方法と、タイトルをプレイしているユーザー用に文字列を設定する方法について説明しています。</span><span class="sxs-lookup"><span data-stu-id="08151-110">The topics in this section describe how to configure your Rich Presence strings and then how to set the string for a user playing your title.</span></span>


## <a name="definitions"></a><span data-ttu-id="08151-111">定義</span><span class="sxs-lookup"><span data-stu-id="08151-111">Definitions</span></span>

**<span data-ttu-id="08151-112">列挙</span><span class="sxs-lookup"><span data-stu-id="08151-112">Enumerations</span></span>**  
<span data-ttu-id="08151-113">列挙は、何らかのゲーム内ディメンションのリストです。</span><span class="sxs-lookup"><span data-stu-id="08151-113">An enumeration is a list of some in-game dimension.</span></span> <span data-ttu-id="08151-114">これらのゲーム内ディメンションの例としては、武器、キャラクター クラス、マップなどがあります。</span><span class="sxs-lookup"><span data-stu-id="08151-114">Examples of these in-game dimensions are weapons, character classes, maps, and so on.</span></span> <span data-ttu-id="08151-115">ゲーム内で使用可能な武器のリスト、使用可能なすべてのキャラクター クラスまたはマップのリストなどを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="08151-115">We want to see a list of the possible weapons in your game, a list of all the possible character classes or maps, and so on.</span></span>

**<span data-ttu-id="08151-116">ロケールと文字列のペア</span><span class="sxs-lookup"><span data-stu-id="08151-116">Locale-string pair</span></span>**  
<span data-ttu-id="08151-117">使用可能なすべてのリッチ プレゼンス文字列に、その文字列をどのロケールで使用できるのか/使用する必要があるのかを示すロケールが関連付けられている必要があります。</span><span class="sxs-lookup"><span data-stu-id="08151-117">Every possible Rich Presence string must have a locale associated with it to specify in what locales the string can/should be used.</span></span> <span data-ttu-id="08151-118">各列挙も、ロケールと文字列のペアのセットを持ちます。</span><span class="sxs-lookup"><span data-stu-id="08151-118">Each enumeration will also have a set of locale-string pairs as well.</span></span>

**<span data-ttu-id="08151-119">文字列セット</span><span class="sxs-lookup"><span data-stu-id="08151-119">String-set</span></span>**  
<span data-ttu-id="08151-120">文字列セットは、ロケールと文字列のペアのグループで構成されます。</span><span class="sxs-lookup"><span data-stu-id="08151-120">A string set is made up of a group of locale-string pairs.</span></span> <span data-ttu-id="08151-121">このセットは、使用可能なすべてのロケールのリッチ プレゼンス文字列の利用可能な値、または使用可能なすべてのロケールの列挙の利用可能な値を定義します。</span><span class="sxs-lookup"><span data-stu-id="08151-121">This set defines the possible values of a Rich Presence string for all possible locales or the possible values for an enumeration for all possible locales.</span></span>

**<span data-ttu-id="08151-122">フレンドリ名</span><span class="sxs-lookup"><span data-stu-id="08151-122">Friendly Names</span></span>**  
<span data-ttu-id="08151-123">2 種類のフレンドリ名があります。</span><span class="sxs-lookup"><span data-stu-id="08151-123">There are two types of friendly names:</span></span>

**<span data-ttu-id="08151-124">リッチ プレゼンス文字列</span><span class="sxs-lookup"><span data-stu-id="08151-124">Rich Presence string</span></span>**  
<span data-ttu-id="08151-125">文字列セットのフレンドリ名は、文字列セットを参照するために使用する文字列形式の一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="08151-125">The friendly name for a string-set is a unique identifier in the form of a string used to reference a string-set.</span></span>

**<span data-ttu-id="08151-126">列挙値</span><span class="sxs-lookup"><span data-stu-id="08151-126">Enumeration</span></span>**  
<span data-ttu-id="08151-127">これらのフレンドリ名は、武器の列挙やキャラクター クラスの列挙などの特定の列挙を一意に識別するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="08151-127">These friendly names are used to uniquely identify a particular enumeration like the weapons enumeration or the character class enumeration.</span></span>


## <a name="in-this-section"></a><span data-ttu-id="08151-128">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="08151-128">In this section</span></span>

[<span data-ttu-id="08151-129">リッチ プレゼンスの構成</span><span class="sxs-lookup"><span data-stu-id="08151-129">Rich Presence configuration</span></span>](rich-presence-strings-configuration.md)  
<span data-ttu-id="08151-130">タイトルで使用するためにリッチ プレゼンスを構成する方法。</span><span class="sxs-lookup"><span data-stu-id="08151-130">How to configure Rich Presence for use in your title.</span></span>

[<span data-ttu-id="08151-131">リッチ プレゼンスの文字列の更新</span><span class="sxs-lookup"><span data-stu-id="08151-131">Rich Presence updating strings</span></span>](rich-presence-strings-updating-strings.md)  
<span data-ttu-id="08151-132">タイトルのリッチ プレゼンス文字列を更新する方法。</span><span class="sxs-lookup"><span data-stu-id="08151-132">How to update Rich Presence Strings from your title.</span></span>

[<span data-ttu-id="08151-133">リッチ プレゼンスのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="08151-133">Rich Presence best practices</span></span>](rich-presence-strings-best-practices.md)  
<span data-ttu-id="08151-134">タイトル内でのリッチ プレゼンスの使用に関するベスト プラクティス。</span><span class="sxs-lookup"><span data-stu-id="08151-134">Best practices for use of Rich Presence in your title.</span></span>

[<span data-ttu-id="08151-135">リッチ プレゼンスのポリシーと制限</span><span class="sxs-lookup"><span data-stu-id="08151-135">Rich Presence policies and limitations</span></span>](rich-presence-strings-policies-and-limitations.md)  
<span data-ttu-id="08151-136">タイトルでのリッチ プレゼンスの使用に関するポリシー。</span><span class="sxs-lookup"><span data-stu-id="08151-136">The policies about using Rich Presence in your title.</span></span>

[<span data-ttu-id="08151-137">リッチ プレゼンスの付録</span><span class="sxs-lookup"><span data-stu-id="08151-137">Rich Presence appendix</span></span>](rich-presence-strings-appendix.md)  
<span data-ttu-id="08151-138">リッチ プレゼンスに関連するデータ プラットフォームの詳細とサンプル。</span><span class="sxs-lookup"><span data-stu-id="08151-138">Additional examples and details about the Data Platform relevant to Rich Presence.</span></span>

[<span data-ttu-id="08151-139">Xbox Live リッチ プレゼンスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="08151-139">Programming Xbox Live Rich Presence</span></span>](programming-rich-presence.md)  
<span data-ttu-id="08151-140">Xbox Live でリッチ プレゼンスを使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="08151-140">Demonstrates how to use Rich Presence with Xbox Live.</span></span>
