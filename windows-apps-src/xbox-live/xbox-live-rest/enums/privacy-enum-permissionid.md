---
title: PermissionId 列挙型
assetID: 3e7ee317-4946-1105-ecd7-1e26346deccb
permalink: en-us/docs/xboxlive/rest/privacy-enum-permissionid.html
description: " PermissionId 列挙型"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: aff463e2268af972536984a00e29348bf0a6859e
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8877828"
---
# <a name="permissionid-enumeration"></a>PermissionId 列挙型
PermissionId 列挙型をについて説明します。
アクセス許可の検証の Url とアクセス許可の Id を使用できます。

   * [GET (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [POST (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

これらの Id には、ユーザーは、ターゲットまたは 1 つの特権アクターの 1 つのプライバシー設定の確認など、特定の設定に対して直接チェックが含まれます。 さらに、Id を API アクセス許可を持つことができ、特定のユーザー操作の複数の設定に対してチェックを組み込むためのアクセス許可があります。

<a id="ID4EIB"></a>


## <a name="permissions"></a>アクセス許可

これらは、特定の操作を実行できるかどうかを確認する、呼び出し元が使用できる値です。 上記の設定とは異なりはこれらサービスによって定義されたポリシーをカプセル化し、ポリシーが 1 つまたは複数の設定値を持つがユーザーによって定義された最上位に構築ほとんどの場合もに、ユーザーが直接変更されたことはできません。 これらは、上記で定義した 1 つ以上の設定に対して通常複合チェックです。 例: <b>ViewProfile</b>アクセス許可では、ターゲットの<b>ShareProfile</b>プライバシー設定と、送信者の<b>AllowProfileViewing</b>特権をチェックします。

一般に、呼び出し元がプライバシー設定と権限を直接チェックではなく、オンにする必要がある操作のためのアクセス許可の ID を要求することをお勧めします。 これにより、新しいチェックが組み込まれているように、サービスの間で一貫して変更するプライバシー ポリシーができます。

| アクセス許可名| 説明|
| --- | --- |
| CommunicateUsingText| ユーザーが対象ユーザーにテキスト コンテンツが含まれるメッセージを送信できるかどうかを確認します。|
| CommunicateUsingVideo| ターゲット ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。|
| CommunicateUsingVoice| ターゲット ユーザーと音声を使用して、ユーザーが通信できるかどうかを確認します。|
| ViewTargetProfile| ユーザーが対象ユーザーのプロファイルを表示するかどうかを確認します。|
| ViewTargetGameHistory| ユーザーが対象ユーザーのゲームの履歴を表示できるかどうかを確認します。|
| ViewTargetVideoHistory| ユーザーが対象ユーザーの詳細なビデオの視聴履歴を表示するかどうかを確認します。|
| ViewTargetMusicHistory| ユーザーが対象ユーザーの詳細な音楽の聞き取り履歴を表示できるかどうかを確認します。|
| ViewTargetExerciseInfo| ユーザーが対象ユーザーの作業で情報を表示できるかどうかを確認します。|
| ViewTargetPresence| ユーザーが対象ユーザーのオンライン状態を表示するかどうかを確認します。|
| ViewTargetVideoStatus| ユーザーがターゲット ビデオ ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetMusicStatus| ユーザーがターゲット音楽ステータス (拡張のオンライン プレゼンス) の詳細を表示できるかどうかを確認します。|
| ViewTargetUserCreatedContent| ユーザーが他のユーザーのユーザーが作成したコンテンツを表示するかどうかを確認します。|
