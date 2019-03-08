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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594687"
---
# <a name="permissionid-enumeration"></a>PermissionId 列挙型
PermissionId 列挙体をについて説明します。
アクセス許可の検証 Url でアクセス許可 Id を使用できます。

   * [GET (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidateget.md)
   * [POST (/users/{requestorId}/permission/validate)](../uri/privacy/uri-privacyusersrequestoridpermissionvalidatepost.md)

これらの Id には、ターゲット、または 1 つの特権のあるアクターの 1 つのプライバシー設定の確認など、ユーザーに対して特定の設定に対して直接チェックが含まれます。 さらに、API アクセス許可で使用できる、特定のユーザー操作に対して複数の設定に対してチェックを組み込む Id アクセス許可があります。

<a id="ID4EIB"></a>


## <a name="permissions"></a>アクセス許可

これらは、特定のアクションを実行できるかどうかを確認する呼び出し元を使用する値です。 上記の設定とは異なりはこれらサービスによって定義されたポリシーをカプセル化し、直接では変更できません、ユーザーが、ほとんどの場合、ポリシーをユーザーが値を持つが定義されている 1 つ以上の設定の上に構築します。 これらは、上記で定義された 1 つ以上の設定に対して、通常は複合チェックです。 以下に例を示します。<b>ViewProfile</b>アクセス許可には、ターゲットのチェックを<b>ShareProfile</b>プライバシー設定と、要求元の<b>AllowProfileViewing</b>特権。

一般に、呼び出し元が直接プライバシーの設定および権限のチェックではなく、確認する必要のあるアクションのアクセス許可 ID を要求することをお勧めします。 これにより、新しいチェックが組み込まれるように、サービス間で一貫して変更するプライバシー ポリシーができます。

| アクセス許可の名前| 説明|
| --- | --- |
| CommunicateUsingText| 対象ユーザーに、ユーザーがテキスト コンテンツを含むメッセージを送信できるかどうかを確認します。|
| CommunicateUsingVideo| 対象ユーザーとビデオを使用して、ユーザーが通信できるかどうかを確認します。|
| CommunicateUsingVoice| 対象ユーザーに音声を使用して、ユーザーが通信できるかどうかを確認します。|
| ViewTargetProfile| ターゲット ユーザーのプロファイルを表示できるかどうかを確認します。|
| ViewTargetGameHistory| ユーザーが対象ユーザーのゲーム履歴を表示できるかどうかを確認します。|
| ViewTargetVideoHistory| ターゲット ユーザーの詳細なビデオ監視履歴を表示できるかどうかを確認します。|
| ViewTargetMusicHistory| ユーザーが対象ユーザーの詳細な音楽リッスンしている履歴を表示できるかどうかを確認します。|
| ViewTargetExerciseInfo| ユーザーが対象ユーザーの演習の情報を表示できるかどうかを確認します。|
| ViewTargetPresence| ユーザーがターゲット ユーザーのオンライン ステータスを確認できるかどうかを確認します。|
| ViewTargetVideoStatus| ユーザーがターゲット ビデオ状態 (オンライン プレゼンスの拡張) の詳細を表示できるかどうかを確認します。|
| ViewTargetMusicStatus| ユーザーがターゲット音楽状態 (オンライン プレゼンスの拡張) の詳細を表示できるかどうかを確認します。|
| ViewTargetUserCreatedContent| ユーザーが他のユーザーのユーザーが作成したコンテンツを表示できるかどうかを確認します。|
