---
title: PermissionId 列挙型
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
author: KevinAsgari
description: " PermissionId 列挙型"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f58c2d0f68e1f65820104928e45a09ccfdb259cb
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4615175"
---
# <a name="permissionid-enumeration"></a>PermissionId 列挙型
PermissionId 列挙型をについて説明します。
アクセス許可の検証の Url とアクセス許可の Id を使用できます。

   * [GET (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [POST (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

これらの Id には、ユーザーは、ターゲット、または 1 つの特権アクターの 1 つのプライバシー設定の確認などの特定の設定に対して直接チェックが含まれます。 さらに、アクセス許可の API で使用できるし、特定のユーザー操作の複数の設定に対してチェックを組み込む Id のアクセス許可があります。

<a id="ID4EIB"></a>


## <a name="permissions"></a>アクセス許可

これらは、呼び出し元が特定の操作を実行できるかどうかをチェックに使用できる値です。 上記の設定とは異なりはこれらサービスによって定義されているポリシーをカプセル化し、ポリシーが 1 つ以上の設定値を持つがユーザーによって定義された最上位に構築ほとんどの場合もに、ユーザーが直接変更されたことはできません。 これらは、上記で定義した 1 つ以上の設定に対して通常複合チェックです。 例: <b>ViewProfile</b>アクセス許可では、ターゲットの<b>ShareProfile</b>プライバシー設定と、送信者の<b>AllowProfileViewing</b>特権をチェックします。

一般に、呼び出し元がプライバシー設定と権限を直接チェックではなく、オンにする必要がある操作のためのアクセス許可の ID を要求することをお勧めします。 これにより、新しいチェックが組み込まれているように、サービスの間で一貫して変更するプライバシー ポリシーができます。

| アクセス許可名| 説明|
| --- | --- |
| CommunicateUsingText| ユーザーが対象ユーザーにテキスト コンテンツが含まれるメッセージを送信できるかどうかを確認します。|
| CommunicateUsingVideo| ターゲット ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。|
| CommunicateUsingVoice| ターゲット ユーザーと音声を使用して、ユーザーが通信できるかどうかを確認します。|
| ViewTargetProfile| ユーザーが対象ユーザーのプロファイルを表示するかどうかを確認します。|
| ViewTargetGameHistory| ユーザーが対象ユーザーのゲームの履歴を表示できるかどうかを確認します。|
| ViewTargetVideoHistory| ユーザーが対象ユーザーの詳細なビデオの視聴履歴を表示できるかどうかを確認します。|
| ViewTargetMusicHistory| ユーザーが対象ユーザーの詳細な音楽リッスン履歴を表示できるかどうかを確認します。|
| ViewTargetExerciseInfo| ユーザーが対象ユーザーの作業で情報を表示できるかどうかを確認します。|
| ViewTargetPresence| ユーザーが対象ユーザーのオンライン状態を表示するかどうかを確認します。|
| ViewTargetVideoStatus| ユーザーがターゲット ビデオ ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetMusicStatus| ユーザーがターゲット音楽ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetUserCreatedContent| ユーザーが他のユーザーのユーザーが作成したコンテンツを表示するかどうかを確認します。|
