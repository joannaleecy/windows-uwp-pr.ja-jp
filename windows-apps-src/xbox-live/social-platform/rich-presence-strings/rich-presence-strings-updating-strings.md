---
title: リッチ プレゼンスの文字列の更新
description: Xbox Live のリッチ プレゼンス文字列を更新する方法について説明します。
ms.assetid: eb2bb82e-8730-4d74-9b33-95d133360e44
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リッチ プレゼンス
ms.localizationpriority: medium
ms.openlocfilehash: ac4549301c60eafb935dab0ac9c5b5028452edfb
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8879377"
---
# <a name="rich-presence-updating-strings"></a>リッチ プレゼンスの文字列の更新

タイトルでリッチ プレゼンス文字列を更新するために、JSON オブジェクトで適切なパラメーターを指定して Write Title URI を呼び出すことができます。 この RESTful 呼び出しは Xbox Service API によってもラップされます。 関連する API については「**Microsoft.Xbox.Services.Presence 名前空間**」を参照してください。

URI は次のように表示されます。

          POST /users/xuid({xuid})/devices/current/titles/current

以下では、リッチ プレゼンス文字列を設定するためのフィールドのみを示しています。 ここに示されていない、タイトルのプレゼンスの記述に関連するその他のオプションのフィールドもあります。

## <a name="titlerequest-object"></a>TitleRequest オブジェクト

プロパティ | 種類 | 必須 | 説明
---|---|---|---
Activity|ActivityRequest|N|タイトル内情報 (リッチ プレゼンスおよびメディア情報 (使用可能な場合)) を記述するレコード

## <a name="activityrequest-object"></a>ActivityRequest オブジェクト

プロパティ | 種類 | 必須 | 説明
---|---|---|---
richPresence|RichPresenceRequest|N|使用するリッチ プレゼンス文字列のフレンドリ名。

## <a name="richpresencerequest-object"></a>RichPresenceRequest オブジェクト

プロパティ | 種類 | 必須 | 説明
---|---|---|---
ID|String|Y|使用するリッチ プレゼンス文字列のフレンドリ名
Scid|String|Y|リッチ プレゼンス文字列が定義されている場所を示す scid

たとえば、xuid が 12345 のユーザーのリッチ プレゼンスを更新する場合、呼び出しは次のようになります。

          POST /users/xuid(12345)/devices/current/titles/current


次のような JSON 本文があるものとします。

```json
          {
            activity:
            {
              richPresence:
              {
                id:"playingMap",
                scid:"0000-0000-0000-0000-01010101"
              }
            }
          }
```

ラッパー API を使用することで、これは **PresenceService.SetPresenceAsync メソッド**の呼び出しになります。

データ プラットフォームを最新の状態に維持している場合、空白に入力されるデータが変更されるたびにリッチ プレゼンス文字列をリセットする必要はありません。 上記の例では、現在のマップを使用することがわかっています。 ユーザーが文字列を読み取ろうとしたときに、プレゼンスがデータ プラットフォームのデータをルックアップして、現在の値を入力します。 そのため、プレイヤーがマップを切り替えた場合でも、適切なイベントをデータ プラットフォームに送信している限り、ゲームのリッチ プレゼンス文字列をリセットする必要はありません。 データがデータ プラットフォームに送信されるまで数秒かかる場合がある点に留意してください。

そして、だれかがユーザー 12345 のリッチ プレゼンスを読み取ろうとすると、サービスが、どのロケールが要求されているかを調べ、文字列を返す前に適切な書式を設定します。

ここでは、ユーザーが en-US の文字列を読み取ろうとしているものとします。 リッチ プレゼンスの読み取りは次のようになります (この呼び出しの詳細については、「**GET (/users/xuid({xuid}))**」を参照してください)。

          GET /users/xuid(12345)?level=all

これのラッパー API は **PresenceService.GetPresenceAsync メソッド**です。

ここでは、xuid が 12345 である、ユーザーの PresenceRecord を要求しています。 さらにその詳細レベルを "all" にすることを要求しています。 "all" が指定されなかった場合、リッチ プレゼンスは返されません。

JSON 応答で以下が返されます。

```json
          {
            xuid:"12345",
            state:"online",
            devices:
            [
              {
                type:"D",
                titles:
                [
                  {
                    id:"12345",
                    name:"Buckets are Awesome",
                    lastModified:"2012-09-17T07:15:23.4930000",
                    placement: "full",
                    state:"active",
                    activity:
                    {
                      richPresence:"Playing on map:Mountains"
                    }
                  }
                ]
              }
            ]
          }
```
