---
title: ゲーム DVR
description: パートナー センターで Xbox Live ゲーム DVR 文字列を構成する方法を説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.date: 10/30/2017
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox live, Xbox, ゲーム, uwp, windows 10, Xbox one, ゲーム DVR, パートナー センター
ms.openlocfilehash: 4e40bbfd18947a99c488dc2b27dc2a23c99643a5
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8788116"
---
# <a name="configuring-game-dvr-in-partner-center"></a><span data-ttu-id="58a48-104">パートナー センターでのゲーム DVR の構成</span><span class="sxs-lookup"><span data-stu-id="58a48-104">Configuring Game DVR in Partner Center</span></span>

<span data-ttu-id="58a48-105">Xbox One で最もよく使われる機能の 1 つにゲーム DVR があります。この機能を使うと、ゲーマーが最高の瞬間を簡単に録画、編集、共有できます。</span><span class="sxs-lookup"><span data-stu-id="58a48-105">On Xbox One, one of the most popular features is Game DVR, which allows gamers easy access to recording, editing and sharing their most epic gaming moments.</span></span> <span data-ttu-id="58a48-106">ゲーム DVR 文字列は、タイトルに開発者が作成した DVR クリップのタイトルとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="58a48-106">The Game DVR strings will appear as the title for any developer-created game DVR clips in your title.</span></span> <span data-ttu-id="58a48-107">サービスで文字列を構成すると、そのクリップが取り上げられているアプリに、その文字列の適切なローカライズ バージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="58a48-107">Configuring the string in the service will ensure that the correct localized version of that string shows up in any apps where that clip is featured.</span></span> <span data-ttu-id="58a48-108">たとえば、ユーザーがタイトルのラスト ボスを倒したときにクリップを作成する場合、まず "ボス バトル" という文字列を構成します。</span><span class="sxs-lookup"><span data-stu-id="58a48-108">For example, if you wanted to create a clip when a user beats the final boss of your title, you would start by configuring a string called 'Boss Battle'.</span></span> <span data-ttu-id="58a48-109">タイトル コードで呼び出しを行ってクリップを作成するとき、ID を参照します。</span><span class="sxs-lookup"><span data-stu-id="58a48-109">When making the call in your title code to create the clip, you would reference the ID.</span></span>

<span data-ttu-id="58a48-110">[パートナー センター](https://partner.microsoft.com/dashboard)を使用して、ゲームに関連付けられているゲーム DVR 文字列を構成することができます。</span><span class="sxs-lookup"><span data-stu-id="58a48-110">You can use [Partner Center](https://partner.microsoft.com/dashboard) to configure Game DVR strings that are associated with your game.</span></span> <span data-ttu-id="58a48-111">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="58a48-111">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="58a48-112">**[サービス]** > **[Xbox Live]** > **[ゲーム DVR]** の順に選択して、**[ゲーム DVR]** セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="58a48-112">Navigate to the **Game DVR** section for your title, located under **Services** > **Xbox Live** > **Game DVR**.</span></span>
2. <span data-ttu-id="58a48-113">**[新しい文字列の作成]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="58a48-113">Click the **Create new string** button.</span></span>
3. <span data-ttu-id="58a48-114">ポップアップ表示されるモーダルで、ゲーム DVR 文字列を入力します。</span><span class="sxs-lookup"><span data-stu-id="58a48-114">In the modal that pops up, enter the Game DVR string.</span></span> <span data-ttu-id="58a48-115">完了したら、**[確認]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="58a48-115">Once completed, click **Confirm**.</span></span>

![新しいゲーム DVR 文字列のダイアログ ボックスの画像](../../images/dev-center/game-dvr/game-dvr-1.png)
