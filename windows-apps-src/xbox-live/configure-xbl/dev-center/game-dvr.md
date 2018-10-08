---
title: ゲーム DVR
author: shrutimundra
description: Windows デベロッパー センター 2017 で Xbox Live Game DVR 文字列を構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム DVR, Windows デベロッパー センター
ms.openlocfilehash: d3d50dff4f8fc09f4c9303fa68172bd4a46eb2fa
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4431049"
---
# <a name="configuring-game-dvr-on-windows-dev-center"></a><span data-ttu-id="41f9d-104">Windows デベロッパー センターでのゲーム DVR の構成</span><span class="sxs-lookup"><span data-stu-id="41f9d-104">Configuring Game DVR on Windows Dev Center</span></span>

<span data-ttu-id="41f9d-105">Xbox One で最もよく使われる機能の 1 つにゲーム DVR があります。この機能を使うと、ゲーマーが最高の瞬間を簡単に録画、編集、共有できます。</span><span class="sxs-lookup"><span data-stu-id="41f9d-105">On Xbox One, one of the most popular features is Game DVR, which allows gamers easy access to recording, editing and sharing their most epic gaming moments.</span></span> <span data-ttu-id="41f9d-106">ゲーム DVR 文字列は、タイトルに開発者が作成した DVR クリップのタイトルとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="41f9d-106">The Game DVR strings will appear as the title for any developer-created game DVR clips in your title.</span></span> <span data-ttu-id="41f9d-107">サービスで文字列を構成すると、そのクリップが取り上げられているアプリに、その文字列の適切なローカライズ バージョンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="41f9d-107">Configuring the string in the service will ensure that the correct localized version of that string shows up in any apps where that clip is featured.</span></span> <span data-ttu-id="41f9d-108">たとえば、ユーザーがタイトルのラスト ボスを倒したときにクリップを作成する場合、まず "ボス バトル" という文字列を構成します。</span><span class="sxs-lookup"><span data-stu-id="41f9d-108">For example, if you wanted to create a clip when a user beats the final boss of your title, you would start by configuring a string called 'Boss Battle'.</span></span> <span data-ttu-id="41f9d-109">タイトル コードで呼び出しを行ってクリップを作成するとき、ID を参照します。</span><span class="sxs-lookup"><span data-stu-id="41f9d-109">When making the call in your title code to create the clip, you would reference the ID.</span></span>

<span data-ttu-id="41f9d-110">[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)を使い、ゲームに関連付けられたゲーム DVR 文字列を構成できます。</span><span class="sxs-lookup"><span data-stu-id="41f9d-110">You can use [Windows Dev Center](https://developer.microsoft.com/dashboard) to configure Game DVR strings that are associated with your game.</span></span> <span data-ttu-id="41f9d-111">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="41f9d-111">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="41f9d-112">**[サービス]** > **[Xbox Live]** > **[ゲーム DVR]** の順に選択して、**[ゲーム DVR]** セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="41f9d-112">Navigate to the **Game DVR** section for your title, located under **Services** > **Xbox Live** > **Game DVR**.</span></span>
2. <span data-ttu-id="41f9d-113">**[新しい文字列の作成]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="41f9d-113">Click the **Create new string** button.</span></span>
3. <span data-ttu-id="41f9d-114">ポップアップ表示されるモーダルで、ゲーム DVR 文字列を入力します。</span><span class="sxs-lookup"><span data-stu-id="41f9d-114">In the modal that pops up, enter the Game DVR string.</span></span> <span data-ttu-id="41f9d-115">完了したら、**[確認]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="41f9d-115">Once completed, click **Confirm**.</span></span>

![新しいゲーム DVR 文字列のダイアログ ボックスの画像](../../images/dev-center/game-dvr/game-dvr-1.png)
