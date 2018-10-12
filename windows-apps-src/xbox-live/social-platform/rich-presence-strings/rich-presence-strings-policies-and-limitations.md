---
title: リッチ プレゼンスのポリシーと制限
author: KevinAsgari
description: Xbox Live リッチ プレゼンス システムのポリシーと制限事項について説明します。
ms.assetid: 0ad21a75-0524-45a8-8d8a-0dec0f7d6d6f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス, ポリシー
ms.localizationpriority: medium
ms.openlocfilehash: 02c5a39dadd50326b7008d73ff6f47e1b4faeb7b
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4563543"
---
# <a name="rich-presence-policies-and-limitations"></a><span data-ttu-id="ef559-104">リッチ プレゼンスのポリシーと制限</span><span class="sxs-lookup"><span data-stu-id="ef559-104">Rich Presence policies and limitations</span></span>

<span data-ttu-id="ef559-105">タイトルにリッチ プレゼンスを実装するときは、以下のポリシーと制限に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-105">When you implement Rich Presence for your title, you must adhere to the following policies and limits.</span></span>

-   <span data-ttu-id="ef559-106">各タイトルに少なくとも 1 つの文字列セットを用意する必要がありますが、設定できる文字列セット数の上限はありません。</span><span class="sxs-lookup"><span data-stu-id="ef559-106">Each title must have at least 1 string-set, but there is no upper limit on how many strings-sets you can have.</span></span>
-   <span data-ttu-id="ef559-107">列挙ごと、およびリッチ プレゼンス文字列ごとに、既定の文字列とカルチャーに依存しない文字列を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-107">You must define a default string as well as culture neutral strings for each enumeration and for each Rich Presence string.</span></span>
-   <span data-ttu-id="ef559-108">数値または文字列の統計情報を使用して、文字列内のパラメーターに入力できます。</span><span class="sxs-lookup"><span data-stu-id="ef559-108">You can use numerical or string statistics to fill in the parameters in your strings.</span></span> <span data-ttu-id="ef559-109">DateTime 統計情報は使用できません。</span><span class="sxs-lookup"><span data-stu-id="ef559-109">You can't use DateTime statistics.</span></span>
-   <span data-ttu-id="ef559-110">リッチ プレゼンス文字列で統計情報を使用する場合は、それらの統計情報 (統計情報の列挙を含む) が同じ SCID およびサンドボックスで使用できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-110">If you're using statistics in your Rich Presence strings, then those statistics (including any enumerations for statistics) must be available in the same SCID & Sandbox.</span></span>
-   <span data-ttu-id="ef559-111">合計 44 文字 (パラメーターの値を含む) の 1 つの行を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ef559-111">You have 1 line of 44 characters total (including the values of the parameters).</span></span> <span data-ttu-id="ef559-112">これは、Xbox 360 のリッチ プレゼンスの制限と同様です。</span><span class="sxs-lookup"><span data-stu-id="ef559-112">This is similar to Xbox 360 Rich Presence limits.</span></span> <span data-ttu-id="ef559-113">クライアントと協力して、文字列の長さを増やすことができるかどうかを検討中です。</span><span class="sxs-lookup"><span data-stu-id="ef559-113">We will be working with the client to see if the length of the string can grow.</span></span> <span data-ttu-id="ef559-114">文字列を長くできる場合は発表します。</span><span class="sxs-lookup"><span data-stu-id="ef559-114">There will be an announcement if the string can be longer.</span></span>
    -   <span data-ttu-id="ef559-115">Unicode 文字が必須であり、UTF-8 エンコーディングで表示できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-115">Unicode characters are required and must be able to work with UTF-8 encoding for display.</span></span>
-   <span data-ttu-id="ef559-116">フレンドリ名は以下の規則に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-116">Your friendly names must follow these rules:</span></span>
    -   <span data-ttu-id="ef559-117">使用できる文字は、'A' ～ 'Z'、'a' ～ 'z'、アンダー スコア ('\_')、および '0' ～ '9' です。</span><span class="sxs-lookup"><span data-stu-id="ef559-117">The allowed characters are 'A' through 'Z', 'a' through 'z', underscore ('\_'), and '0' through '9'.</span></span>

        <span data-ttu-id="ef559-118">文字数の制限はありません。</span><span class="sxs-lookup"><span data-stu-id="ef559-118">There is no character limit.</span></span>

-   <span data-ttu-id="ef559-119">文字列の検証は実行されません。スペル チェックなどの文字列検証を実行し、文字列が正しくローカライズされていることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-119">No string verification is done on your strings; you must do any string verification, such as spellcheck and verifying that the string has been localized properly.</span></span>
    -   <span data-ttu-id="ef559-120">文字列セットが不適切である (暴力的または攻撃的な言葉使いなど) と思われる場合、Microsoft は、要件を満たすように文字列が更新されるまで、タイトルでのリッチ プレゼンスの使用を禁止します。</span><span class="sxs-lookup"><span data-stu-id="ef559-120">If we feel a string-set is inappropriate (such as abusive or offensive language), Microsoft prevents titles from using Rich Presence until strings have been updated to our satisfaction.</span></span>
-   <span data-ttu-id="ef559-121">タイトルがデータ プラットフォームと統合されていない場合、統計情報を文字列内のパラメーターとして使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="ef559-121">If your title isn't integrating with the data platform, there are no options for using statistics as parameters in your strings.</span></span>
    -   <span data-ttu-id="ef559-122">すべての文字列を完全に事前定義する必要があります (トークンは使用できません)。</span><span class="sxs-lookup"><span data-stu-id="ef559-122">All strings must be completely predefined in that case (no tokens are allowed).</span></span>
-   <span data-ttu-id="ef559-123">列挙名はすべての列挙において一意である必要があり、統計情報名に対して一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="ef559-123">Enumeration names must be unique across all enumerations and must be unique to statistic names.</span></span>
-   <span data-ttu-id="ef559-124">1 行に表示できる文字数を超え、改行がある場合、行は自動的に切り捨てられます。</span><span class="sxs-lookup"><span data-stu-id="ef559-124">If a line exceeds the number of characters that can be shown, and there is a line break, the line is automatically truncated.</span></span>
