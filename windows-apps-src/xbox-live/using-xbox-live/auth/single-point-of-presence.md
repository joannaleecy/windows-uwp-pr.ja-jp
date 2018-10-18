---
title: Single Point of Presence (SPOP)
author: KevinAsgari
description: Xbox Live Single Point of Presence (SPOP) を使ってタイトルが一度に 1 台のデバイスでのみ再生されるようにする方法について説明します。
ms.assetid: 40f19319-9ccc-4d35-85eb-4749c2cf5ef8
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, spop, single point of presence
ms.localizationpriority: medium
ms.openlocfilehash: 1ad187ea8645138d3076892e893cb0b770236ae8
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4752714"
---
# <a name="single-point-of-presence-spop"></a>Single Point of Presence (SPOP)

## <a name="overview"></a>概要
Single Point of Presence (SPOP) は、一度に 1 つのデバイスでのみタイトルを再生できるように、Xbox Live が適用する状態です。 これは、任意のデバイス上の Xbox One XDK および UWP タイトルに適用されます。
Xbox Live タイトルは、デバイスに関係なく、別の Xbox One または Windows 10 デバイス上のタイトルにサインインしているユーザーをキックできます。

## <a name="how-to-handle-spop"></a>SPOP を処理する方法
SPOP は、他の種類のサインアウト イベントと同じ方法でタイトルによって処理されるはずです。 ユーザーは、SPOP を開始するアクションを行うときは常に、タイトルが他のデバイスで切断されることを望んでいることを確認するように UI から通知されます。

* XDK タイトルでは、これが発生するときに `User::SignOutCompleted` イベントがトリガーされます。
* UWP タイトルでは、`xbox_live_user` クラスから `sign_out_complete` ハンドラーによってサインアウトが通知されます。 詳細については、「[UWP プロジェクトの認証](authentication-for-UWP-projects.md)」を参照してください
