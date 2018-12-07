---
title: Xbox Integrated Multiplayer リリース ノート
description: Xbox Integrated Multiplayer に関するリリース ノートが含まれています。
ms.assetid: 38df7a49-71b9-4d86-9c49-683ffa7308d6
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Integrated Multiplayer
ms.localizationpriority: medium
ms.openlocfilehash: 8d7bef69d9a14455d10af3745533c26e5fb54332
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8793947"
---
# <a name="xbox-integrated-multiplayer-release-notes"></a>Xbox Integrated Multiplayer リリース ノート

更新日: 2016 年 12 月 14 日

以下のメソッドは、このリリースの Xbox Integrated Multiplayer (XIM) では使用できません。

-   `xim_authority::set_authority_reconciled_data()`
-   `xim_authority::set_authority_reconciliation_data()`
-   `xim_authority::send_data_to_players()`
-   `xim_authority::network_path_information()`
-   `xim_player::xim_local::send_data_to_authority()`

以下の状態変化は、このリリースの XIM では提供されません。

-   `xim_state_change_type::player_to_authority_data_received`
-   `xim_state_change_type::authority_to_player_data_received`
-   `xim_state_change_type::authority_reconciling`
-   `xim_state_change_type::authority_reconciled_local`
-   `xim_state_change_type::authority_reconciled_remote`
-   `xim_state_change_type::send_queue_alert_triggered`
