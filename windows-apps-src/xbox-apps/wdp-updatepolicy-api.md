---
author: payzer
title: "Device Portal Xbox Developer 開発機更新ポリシー API リファレンス"
description: "プログラムで本体の更新ポリシーを設定する方法について説明します。"
ms.openlocfilehash: f9313d3c8b93ba13074c547f1f63c9f3204f0f58
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
注: この API は、次の Developer Preview で予定されています。

# <a name="system-update-policy-api-reference"></a>システム更新ポリシー API リファレンス   
この API を使うと、本体に適用されている更新ポリシーを確認し、新しい更新ポリシーに変更できます。

重要: ほとんどの本体は、この API を呼び出そうとすると "アクセス拒否" 応答を受信します。 これは、更新ポリシーを変更できない開発用本体があるためです。

この API は、製品版の本体ではなく、開発者モードの本体の更新ポリシーを変更します。

## <a name="get-the-console-update-policy"></a>本体の更新ポリシーを取得する

**要求**

次の要求を使って、本体の更新ポリシーを取得できます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/update/policy
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**   
応答は、本体のシステム更新グループのメンバーシップを含む JSON 配列です。 各オブジェクトには次のフィールドがあります。   

Id - (String) 更新グループの ID です。   
Friendly Name - (String) 更新グループの表示名です。   
Description - (String) 更新グループの説明です。
IsDevKitGroup - (true | false) 更新グループが開発者ビルド用かどうかを示します。
ResourceSetID - (String) 無視 - システム更新インフラストラクチャによって使用されます。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
5XX | エラー コード

## <a name="set-a-consoles-system-update-policy"></a>本体のシステム更新ポリシーを設定する
この API を使うと、本体のシステム更新グループのメンバーシップを切り替えることができます。

注: 本体が属することのできるシステム更新グループは一度に 1 つだけです。

**要求**

次の要求を使って、本体のシステム更新グループのメンバーシップを設定できます。

メソッド      | 要求 URI
:------     | :-----
POST | /ext/update/policy
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**   
要求本文は、次のフィールドを含む JSON オブジェクトです。   
GroupIdToJoin - (String) 本体を所属させるシステム更新グループの ID です。  
GroupIdToLeave - (String) 本体を抜けさせるシステム更新グループの ID です。

すべてのフィールドは必須です。

指定できる GroupID は次のとおりです。   
* 更新なし - "b2dbed33-2845-44cc-a7a1-4a9afb29d8d9"   
* 最新の運用回復 - "7432ae99-8c09-48dd-99f9-a2697499e240"   
* 最新のプレビュー回復 - "a8153054-1a1b-47cc-acc9-9aed90c1f8db"    

**応答**   

- なし

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 要求は成功しました
4XX | エラー コード
5XX | エラー コード

<br />
**利用可能なデバイス ファミリ**

* Windows Xbox

