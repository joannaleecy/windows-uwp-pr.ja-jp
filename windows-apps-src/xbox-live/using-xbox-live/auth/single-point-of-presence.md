---
title: Single Point of Presence (SPOP)
description: Xbox Live Single Point of Presence (SPOP) を使ってタイトルが一度に 1 台のデバイスでのみ再生されるようにする方法について説明します。
ms.assetid: 40f19319-9ccc-4d35-85eb-4749c2cf5ef8
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, spop, single point of presence
ms.localizationpriority: medium
ms.openlocfilehash: f1503a6168a50175e861e17027e8b642d1b7834d
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8331169"
---
# <a name="single-point-of-presence-spop"></a>Single Point of Presence (SPOP)

## <a name="overview"></a>概要
Single Point of Presence (SPOP) は、一度に 1 つのデバイスでのみタイトルを再生できるように、Xbox Live が適用する状態です。 これは、任意のデバイス上の Xbox One XDK および UWP タイトルに適用されます。
Xbox Live タイトルは、デバイスに関係なく、別の Xbox One または Windows 10 デバイス上のタイトルにサインインしているユーザーをキックできます。

## <a name="how-to-handle-spop"></a>SPOP を処理する方法
SPOP は、他の種類のサインアウト イベントと同じ方法でタイトルによって処理されるはずです。 ユーザーは、SPOP を開始するアクションを行うときは常に、タイトルが他のデバイスで切断されることを望んでいることを確認するように UI から通知されます。

* XDK タイトルでは、これが発生するときに `User::SignOutCompleted` イベントがトリガーされます。
* UWP タイトルでは、`xbox_live_user` クラスから `sign_out_complete` ハンドラーによってサインアウトが通知されます。 詳細については、「[UWP プロジェクトの認証](authentication-for-UWP-projects.md)」を参照してください
