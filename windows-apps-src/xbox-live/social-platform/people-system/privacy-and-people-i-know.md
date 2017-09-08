---
title: "プライバシーと知り合いのユーザー"
author: KevinAsgari
description: "Xbox Live ソーシャル プラットフォーム サービスのプライバシー モデルについて説明します。"
ms.assetid: 9031ca37-bab7-44b1-ae40-fca7459f5f59
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ソーシャル プラットフォーム, プライバシー, 匿名"
ms.openlocfilehash: 2b78adfc10822c6e05ffdf488f4e27c648f92784
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="privacy-and-people-i-know"></a><span data-ttu-id="e40e1-104">プライバシーと知り合いのユーザー</span><span class="sxs-lookup"><span data-stu-id="e40e1-104">Privacy and People I know</span></span>

<span data-ttu-id="e40e1-105">新しい People システムのコア機能では、匿名関係と非匿名関係の両方が提供されます。ユーザーは、実名のフレンドに加えて、Xbox Live で出会って自分のユーザー リストに登録したランダムなゲーマータグの関係を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="e40e1-105">A core feature of the new People system is that it provides for both anonymous and non-anonymous relationships; users can have real-name friends as well as random Gamertag relationships they've encountered on Xbox Live that they put on their People list.</span></span> <span data-ttu-id="e40e1-106">つまり、サポートする必要がある 2 種類のセットの権限があります。一方は、信頼できる現実世界の友人が機密情報を表示できるもので、2 番目は、ユーザーが匿名のゲーマータグ関係を追加できるもので、機密性の高い情報を表示しないので安心感があります。</span><span class="sxs-lookup"><span data-stu-id="e40e1-106">This means there are two different sets of rights that must be supported: one to allow trusted real-world friends to see sensitive information, and a second to enable users to add random Gamertag relationships yet feel safe they won't reveal anything sensitive.</span></span>

<span data-ttu-id="e40e1-107">以前の Xbox Live プライバシー モデルでは、3 種類に分ける方法に基づいてアカウントに関する情報へのアクセスを制限する機能が提供されていました。つまり、オンライン状態などの任意の設定を "すべての人"、"フレンドのみ"、または "ブロック" に設定できました。</span><span class="sxs-lookup"><span data-stu-id="e40e1-107">The prior Xbox Live privacy model provided the ability to restrict access to information about an account based on a 3-bucket system; a given setting such as online status could be set to "Everyone", "Friends Only", or "Blocked".</span></span> <span data-ttu-id="e40e1-108">たとえば、14 歳の女の子が Xbox Live を利用中だとします。</span><span class="sxs-lookup"><span data-stu-id="e40e1-108">For example, think of a 14 year old girl on Xbox Live.</span></span> <span data-ttu-id="e40e1-109">彼女には、完全に信頼している学校の友達が 1 組いて、Halo を数ラウンド分プレイした後に、ほとんど知らないランダムなプレイヤー仲間を数人追加しました。</span><span class="sxs-lookup"><span data-stu-id="e40e1-109">She's got a set of her school friends that she completely trusts, and then she's added some random guys she barely knows after playing a few rounds of Halo with them.</span></span> <span data-ttu-id="e40e1-110">以前のモデルでは、彼女のリストに追加された全員が同じレベルのアクセスを与えられることになり、彼女が追加したほとんど知らない人には情報を公開することなく、学校の友達のみに彼女の自己紹介やゲームプレイの履歴を見せる方法はありませんでした。そして、他のユーザーと共有する事柄について慎重になったり、リストに追加するユーザーを決められなくなったりします。</span><span class="sxs-lookup"><span data-stu-id="e40e1-110">The previous model meant that everyone on her list could only be given the same level of access; there was no way to let her school friends see her bio or gameplay history without also exposing that to the people she's added that she barely knows; it ends up forcing conservatism with what is shared with others, or hesitation about who is added to the list.</span></span>

<span data-ttu-id="e40e1-111">新しいプライバシー モデルは、構造的には同じままですが、"すべての人"、"リストに記載の人"、"知り合いのユーザー"、または "ブロック" の 4 種類に分けるシステムに移行します。</span><span class="sxs-lookup"><span data-stu-id="e40e1-111">The new privacy model remains structurally the same, but moves to a 4-bucket system: "Everyone", "People on my List", "People I Know", or "Blocked".</span></span> <span data-ttu-id="e40e1-112">"知り合いのユーザー" 種類には、そのユーザーが実際の情報へのアクセスを許可するユーザーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e40e1-112">The "People I Know" bucket contains people the user allows to access real-name information.</span></span> <span data-ttu-id="e40e1-113">"知り合いのユーザー" 用のプライバシーの権利は、"リストに記載の人" の厳密なサブセットになっています。言い換えれば、"リストに記載の人" に権利を与えることは、"知り合いのユーザー" に権利を与えることにもなります。</span><span class="sxs-lookup"><span data-stu-id="e40e1-113">Privacy rights for "People I Know" are a strict subset of "People on my List"; in other words, granting rights to the latter also gives the rights to the former.</span></span>
