---
title: マルチプレイヤー セッション ステータス コード
description: マルチプレイヤー セッションを要求したときに Xbox Live サービスから返されるステータス コードについて説明します。
ms.assetid: 4ab320d6-8050-41a9-9f00-faaad3b128fd
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー 2015, ステータス コード, セッション
ms.localizationpriority: medium
ms.openlocfilehash: 8fbddd0070eb24d6fc050c59fa2a0197f98ee08c
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8941486"
---
# <a name="multiplayer-session-status-codes"></a>マルチプレイヤー セッション ステータス コード

ここでは、セッションに関するマルチプレイヤー ステータス コードを示します。

| 注意                                                                                                         |
|---------------------------------------------------------------------------------------------------------------------------|
| URI がセッションの要素を指す場合でも、セッションを返す 4xx ステータス コードは常にセッション全体を返します。 |


| ステータス コード | 文字列              | Content-Type     | 本文    | 説明 |
|----|
| 200         | OK                  | application/json | セッション | 読み取り (GET) または更新 (PUT) に成功しました。                                                                                                                                                                                                                                                                                                             |
| 201         | Created             | application/json | セッション | 正常に作成されました。                                                                                                                                                                                                                                                                                                                                 |
| 202         | Accepted            | text/plain       | なし    | 要求は受け入れられましたが、まだ完了していません。                                                                                                                                                                                                                                                                                             |
| 204         | No content          |                  |         | セッションに対する GET の実行時に、セッションが存在しません。 セッション要素に対する GET の実行時に、セッションは存在しますが、要素が存在しません。 セッションに対する PUT の実行時に、PUT 操作の結果としてセッションが削除されました。 セッション要素に対する PUT または DELETE の実行時に、操作の開始時点ではセッションが存在していましたが、セッションまたは要素のどちらかがもう存在しません。 |
| 304         | Not modified        |                  |         | If-None-Match ヘッダーを伴った GET の実行時に、セッションは変化していません。                                                                                                                                                                                                                                                                                        |
| 400         | Bad request         | text/plain       | メッセージ | 要求は、最初の調査で無効であると見なされました。 必須フィールドがないか、または JSON ファイル形式が正しくありません。 本文に追加の詳細が含まれています。                                                                                                                                                                                        |
| 403         | Forbidden           | text/plain       | メッセージ | 要求はコンテキストによっては有効である可能性がありますが、そのコンテキストでは無効です。 承認が失敗しました。                                                                                                                                                                                                                                                |
|             |                     | application/json | セッション | ユーザーによるセッションの更新はできませんが、読み取りは可能です。                                                                                                                                                                                                                                                                                           |
| 404         | Not found           | text/plain       | メッセージ | 次のいずれかの理由によりセッションにアクセスできません。URI が無効です。ハンドル、SCID、またはセッション テンプレートが見つかりません。ホッパーが見つかりません。セッションが存在しないためセッションの要素にアクセスできません。または、セッションに対して要素のルックアップが無効です。                                                                                 |
| 405         | Method not allowed  | text/plain       | メッセージ | 要求の URI は妥当ですが、動詞が誤っています。 たとえば、PUT 操作が必要なときに要求が POST 操作向けです。                                                                                                                                                                                                                 |
| 409         | Conflict            | text/plain       | メッセージ | 要求にセッションとの互換性がないため、セッションを更新できませんでした。 たとえば、要求の定数と、セッションまたはセッション テンプレートの定数が競合します。または、呼び出し元以外のメンバーが大規模なセッションに追加または削除されました。                                                                         |
| 412         | Precondition failed |                  |         | If-Match ヘッダーまたは If-None-Match ヘッダー (GET 以外の操作が対象) を満たすことができませんでした。                                                                                                                                                                                                                                           |
|             |                     | application/json | セッション | 既存のセッションに対する PUT または DELETE 操作で If-Match ヘッダーを満たすことができませんでした。 セッションの現在の状態は現在の ETag 値と共に返されます。                                                                                                                                                                      |
| 429 | Too many requests | application/json | メッセージ | きめ細かなレート制限を超えるため、サービスの呼び出しはスロットリングされました。 詳しくは、「[きめ細かなレート制限](../../using-xbox-live/best-practices/fine-grained-rate-limiting.md)」をご覧ください。 |
| 503         | Service unavailable | text/plain       | なし    | サービスがオーバーロードされ、要求を後で再試行する必要があります。 このコードには、クライアントが受け入れる必要がある Retry-After ヘッダーが含まれています。                                                                                                                                                                                                              |
