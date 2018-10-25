---
title: Xbox Integrated Multiplayer リリース ノート
author: KevinAsgari
description: Xbox Integrated Multiplayer に関するリリース ノートが含まれています。
ms.assetid: 38df7a49-71b9-4d86-9c49-683ffa7308d6
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Integrated Multiplayer
ms.localizationpriority: medium
ms.openlocfilehash: 07c3094b5308bb0062d046440f83b45b842eb820
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5474186"
---
# <a name="xbox-integrated-multiplayer-release-notes"></a><span data-ttu-id="30567-104">Xbox Integrated Multiplayer リリース ノート</span><span class="sxs-lookup"><span data-stu-id="30567-104">Xbox Integrated Multiplayer Release Notes</span></span>

<span data-ttu-id="30567-105">更新日: 2016 年 12 月 14 日</span><span class="sxs-lookup"><span data-stu-id="30567-105">Updated December 14, 2016</span></span>

<span data-ttu-id="30567-106">以下のメソッドは、このリリースの Xbox Integrated Multiplayer (XIM) では使用できません。</span><span class="sxs-lookup"><span data-stu-id="30567-106">The following methods are not available in this release of Xbox Integrated Multiplayer (XIM):</span></span>

-   `xim_authority::set_authority_reconciled_data()`
-   `xim_authority::set_authority_reconciliation_data()`
-   `xim_authority::send_data_to_players()`
-   `xim_authority::network_path_information()`
-   `xim_player::xim_local::send_data_to_authority()`

<span data-ttu-id="30567-107">以下の状態変化は、このリリースの XIM では提供されません。</span><span class="sxs-lookup"><span data-stu-id="30567-107">The following state changes are not provided in this release of XIM:</span></span>

-   `xim_state_change_type::player_to_authority_data_received`
-   `xim_state_change_type::authority_to_player_data_received`
-   `xim_state_change_type::authority_reconciling`
-   `xim_state_change_type::authority_reconciled_local`
-   `xim_state_change_type::authority_reconciled_remote`
-   `xim_state_change_type::send_queue_alert_triggered`
