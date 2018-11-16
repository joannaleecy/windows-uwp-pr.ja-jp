---
title: PermissionId 列挙型
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
author: KevinAsgari
description: " PermissionId 列挙型"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c0f1d0b27e0d9448240f20addb96188a03581f9c
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837589"
---
# <a name="permissionid-enumeration"></a>PermissionId 列挙型
PermissionId 列挙型をについて説明します。
アクセス許可の検証の Url とアクセス許可の Id を使用できます。

   * [GET (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [POST (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

これらの Id には、ユーザーは、ターゲットまたは 1 つの特権アクターの 1 つのプライバシー設定の確認など、特定の設定に対して直接チェックが含まれます。 さらに、Id をアクセス許可の API で使用できるし、特定のユーザー操作のための複数の設定に対してチェックを組み込むためのアクセス許可があります。

<a id="ID4EIB"></a>


## <a name="permissions"></a>アクセス許可

これらは、呼び出し元が特定の操作を実行できるかどうかを確認に使用できる値です。 上記の設定とは異なり、これらはサービスによって定義されたポリシーをカプセル化し、直接変更できないユーザー、ポリシーが 1 つまたは複数の設定値を持つがユーザーによって定義された最上位に構築ほとんどの場合も。 これらは、上記で定義した 1 つ以上の設定に対して通常コンポジット チェックです。 例: <b>ViewProfile</b>アクセス許可では、ターゲットの<b>ShareProfile</b>プライバシー設定と、送信者の<b>AllowProfileViewing</b>権限のチェックします。

一般に、呼び出し元が直接プライバシー設定と権限を確認するのではなく、オンにする必要がある操作のためのアクセス許可の ID を要求することをお勧めします。 これにより、新しいチェックが組み込まれているように、サービスの間で一貫して変更するプライバシー ポリシーができます。

| アクセス許可名| 説明|
| --- | --- |
| CommunicateUsingText| ユーザーが対象ユーザーにテキスト コンテンツが含まれるメッセージを送信できるかどうかを確認します。|
| CommunicateUsingVideo| ターゲット ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。|
| CommunicateUsingVoice| ターゲット ユーザーと音声を使用して、ユーザーが通信できるかどうかを確認します。|
| ViewTargetProfile| ユーザーが対象ユーザーのプロファイルを表示するかどうかを確認します。|
| ViewTargetGameHistory| ユーザーが対象ユーザーのゲームの履歴を表示できるかどうかを確認します。|
| ViewTargetVideoHistory| ユーザーが対象ユーザーの詳細なビデオの視聴履歴を表示できるかどうかを確認します。|
| ViewTargetMusicHistory| ユーザーが対象ユーザーの詳細な音楽の聞き取り履歴を表示できるかどうかを確認します。|
| ViewTargetExerciseInfo| ユーザーが対象ユーザーの作業で情報を表示できるかどうかを確認します。|
| ViewTargetPresence| ユーザーが対象ユーザーのオンライン状態を表示するかどうかを確認します。|
| ViewTargetVideoStatus| ユーザーがターゲット ビデオ ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetMusicStatus| ユーザーがターゲット音楽ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetUserCreatedContent| ユーザーが他のユーザーのユーザーが作成したコンテンツを表示するかどうかを確認します。|
