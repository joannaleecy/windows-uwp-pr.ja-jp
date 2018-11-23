---
title: 評判
author: KevinAsgari
description: Xbox Live が評判サービスを使って前向きなゲームプレイを推進している方法について説明します。
ms.assetid: f8966184-5db7-4cab-93ca-9a0250a6077d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 評判, ソーシャル プラットフォーム
ms.localizationpriority: medium
ms.openlocfilehash: 5b3ff2d546dc142331406f198848e9d7a7077b3d
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7553021"
---
# <a name="reputation"></a>評判

評判は、他と同じようにユーザー統計であり、すべてのユーザー統計を取得し、それらをレポートや追跡で使用するための呼び出しに含まれます。 評判自体は **Reputation クラス**によって表されます。 **ReputationService クラス**は、評判サービスを表します。 対応する URI については、「**評判 URI**」を参照してください。

> [!IMPORTANT]
> 評判の統計情報は、サービス全体が対象であり、特定のタイトルに結び付けられてはいません。 このサービスのサービス構成 ID (SCID) は、評判統計へのアクセスに使用されるグローバル SCID です。


## <a name="features-of-the-reputation-service"></a>評判サービスの機能

評判サービスには以下の機能があります。

-   良い評価と悪い評価を同じ方法で処理します。 エンティティがユーザーのフィードバックを送信すると、このフィードバックはユーザーの評判に影響します。 このフィードバックはその後、さらなる措置のために執行チームに転送される場合もあります。
-   ユーザーは他のユーザーに関するフィードバックを提供できます。 タイトルはフィードバックを自動的に送信できます。
-   タイトルは API に直接アクセスできます。 ユーザーは、ゲーム内から、また、ユーザーが現在いるゲーム領域のコンテキスト内から、フィードバックを直接送信できます。
-   評判が低くなると、ユーザーが Xbox Live 上やタイトル内で実行できる内容に影響するように処理します。 したがって、ユーザーは、自分の評判を常に意識し、オンライン プレイでより適切な振る舞いをする必要があります。
-   悪い評価だけでなく、良い評価も受け入れます。 Xbox コミュニティまたはタイトルのコミュニティに貢献するユーザーには、その労力に見合ったリワードを与えることができ、特別な権限を与えることもできます。
-   **Reputation.OverallReputation プロパティ**によって表される、単一の総合的な評判を導出します。 次の評判の種類から導出されます。

    -   フェア プレイ。 **Reputation.CommunicationsReputation プロパティ**によって表されます。
    -   通信。 **Reputation.CommunicationsReputation プロパティ**によって表されます。
    -   ユーザー作成コンテンツ (UGC)。 **Reputation.UserGeneratedContentReputation プロパティ**によって表されます。

詳細については、「**ResetReputation (JSON)**」を参照してください。


## <a name="usage-flow-for-the-reputation-service"></a>評判サービスの使用フロー

評判サービスの全体的なフローには、評判のレポートと、評判でフィルター処理されたマッチメイキングの 2 つのフェーズがあります。


## <a name="reporting-reputation"></a>評判のレポート

特定のユーザーについて十分な数の悪い評価がレポートされると、タイトルはそのユーザーの **Reputation.OverallReputation プロパティ**を悪い評判を示すように設定します (JSON 属性 OverallReputationIsBad)。 一定の時間、悪い評価がないと、ユーザーの評判はゆっくりと改善し、一度悪い評判になったユーザーが良い評判を再び得ることもできます。


## <a name="reputation-filtered-matchmaking"></a>評判でフィルター処理されたマッチメイキング

Xbox 要件 (XR) で指定されている、評判でフィルター処理されたマッチメイキングの場合は、タイトルはプレイヤーの **Reputation.OverallReputation プロパティ**の値を取得します。 この値は、プレイヤーの総合的な評価の状態を示すスコアです。

> [!NOTE]
> タイトルは、JSON ファイルで OverallReputationIsBad 属性を検索して見つからない場合、ユーザーの評判が良いものと仮定しても安全です。 これは、新しいアカウントで、ユーザーのフィードバックが処理されるまでに発生する可能性があります。 他のユーザーからのフィードバックがあったプレイヤーには必ず評判の統計情報があり、**Reputation.OverallReputation** プロパティに値が設定されています。


## <a name="reputation-as-an-indicator-of-behavior"></a>振る舞いの指標としての評判

評判はユーザーがシステム上でどのような振る舞いをしているかの指標を提供します。 たとえば、その人はフレンドリーなプレイヤーでしょうか。 プレイヤーの評判は、他のセッション メンバーからのフィードバックによって決まります。 個々のユーザーが持つ評判スコアは、Xbox One のあらゆる場所でその人に随伴します。 評判スコアはフレンドから見えるソーシャルな場所に目立つように公開されるため、より良い振る舞いをするよう、フレンドがプレイヤーにプレッシャーを与える効果があります。 次に、例を示します。

-   評価スコアは各ユーザーのプロフィール カードに表示されます。 システム内のすべてのユーザーが、クリック 1 つでそのユーザーのプロフィールを見ることができます。
-   評価スコアはマルチプレイヤー ゲームで表示されます。 ユーザーどうしがオンラインで一緒にプレイするとき、グループ内で最も評判の低いプレイヤーの評判がグループの評判になります。 グループは評判が近い他のグループとしかマッチングされません。 他のプレイヤーは評判により、どのようなプレイヤーがそのゲームにいるかを判断し、ゲームに参加したいかどうかを判断します。


## <a name="key-elements-of-reputation"></a>評判の重要な要素

タイトルでは、ユーザーがフェアプレイ、コミュニケーション、またはユーザー作成コンテンツ (UGC) カテゴリーで敬遠対象レベルに達したかどうかを判定できます。 次のいずれかのプロパティが 1 に設定されている場合、ユーザーは関連するカテゴリーについて "敬遠対象" に達しています。

-   **Reputation.OverallReputation プロパティ**。 関連付けられた JSON 属性は OverallReputationIsBad です。
-   **Reputation.FairplayReputation プロパティ**。 関連付けられた JSON 属性は FairplayReputationIsBad です。
-   **Reputation.CommunicationsReputation プロパティ**。 関連付けられた JSON 属性は CommsReputationIsBad です。
-   **Reputation.UserGeneratedContentReputation プロパティ**。 関連付けられた JSON 属性は UserContentReputationIsBad です。


## <a name="good-game-reports"></a>楽しかったゲームのレポート

ユーザーの不適切な行為の報告に加えて、ユーザーどうしが楽しかったゲームのレポートを送信することもできます。これはタイトル内で最優秀プレイヤーへの投票として作成できます。


## <a name="feedback-history"></a>フィードバック履歴

フィードバック履歴は、そのユーザーについて最後に報告されたのはいつか、そのユーザーのどんなことが報告されたのかなどの情報をレポートします。たとえば、"コミュニケーション方法に関して最近送信されたフィードバック" などがあります。


## <a name="xbox-requirement-for-reputation"></a>評判に関する Xbox 要件

Xbox 要件 (XR) 068、評判によるマッチメイキングのフィルタリングでは、悪い評判のプレイヤーを良い評判のプレイヤーから分離する必要があります。 これは、プレイヤーの **Reputation.OverallReputation** の値と、ユーザー統計でのプレイヤーの OverallReputationIsBad 属性を見ることによって行われます。

**UserStatisticsService.GetSingleUserStatisticsAsync メソッド (String, String, String)** の *statisticName* パラメーターに "OverallReputation" を渡すことによって、ユーザーの評判を取得できます。 WinRT メソッドは、次の JSON 本文に示されているように、**GET (/users/xuid({xuid})/scids/{scid}/stats)** を呼び出します。

```json
    {
      "requestedusers": [
        "2533274792693551"
      ],
      "requestedscids": [
        {
          "scid": "7492baca-c1b4-440d-a391-b7ef364a8d40",
          "requestedstats": [
            "OverallReputationIsBad",
            "FairplayReputationIsBad",
            "CommsReputationIsBad",
            "UserContentReputationIsBad"
          ]
        }
      ]
    }
```

他のプレイヤーからのフィードバックが低レベルに達すると、そのユーザーの OverallReputationIsBad は 1 に設定されます。 **Reputation.OverallReputation** が 1 である対象ユーザーは **OverallReputation** が 1 に設定された人物とのみマッチングする必要があります。 既定では、一般的なユーザーがマッチングの際に評判の低いユーザーとマッチングされることはありません。 タイトルでは、良い評判のプレイヤーが評判の低いプレイヤーとマッチングすることを許容するオプションを設けることができます。

評判に適用される XR の最新版については、Game Developer Network (GDN) の [Xbox 要件](https://developer.xboxlive.com/en-us/platform/certification/requirements/Pages/home.aspx)を参照してください。


## <a name="creating-users-with-bad-overall-reputation-for-testing"></a>テスト用の、総合的な評判の低いユーザーの作成

非常に評判の低いユーザーをテスト用にセットアップし、タイトルのマッチ フィルターの実装をテストできます。 ユーザーに特定の値を設定するには、テスト用のタイトルまたはツールで、**POST (/users/xuid({xuid})/resetreputation)** を呼び出し、ユーザーの特定の評判値を設定する JSON ファイルを指定します。 詳細については、「**ResetReputation (JSON)**」を参照してください。

たとえば、次の JSON 本文は、ユーザーのフェア プレイの評判を非常に低い値に設定します。

```json
    {
      "fairplayReputation": 5,
      "commsReputation": 75,
      "userContentReputation": 75
    }
```

パートナーは RETAIL を除くすべてのサンドボックスに対してこの呼び出しを実行できます。 この要求はユーザーの基本評判スコアを設定し、プレイヤーの良い評価の重みをすべて消去します。この呼び出しの後のユーザーの実際の評判は、この基本スコアにプレイヤーのアンバサダー ボーナスとプレイヤーのフォロワー ボーナスを加えたものになります。 このメカニズムにより、マッチ フィルター XR をテストするための、低スコアかつ **Reputation.OverallReputation** が 1 に設定されたユーザーが作成されます。 このトピックの「評判に関する Xbox 要件」セクションで説明したように、タイトルはユーザーの評判スコアをユーザー統計サービスから取得できます。


## <a name="resetting-a-users-reputation-to-the-defaults"></a>ユーザーの評判の既定値へのリセット

タイトルは、OverallReputationIsBad 属性を設定して、ユーザーの評判が良いことを示します。 **POST (/users/me/resetreputation)** を呼び出し、すべての値を 75 に設定します。 **/users/xuid({xuid})/deleteuserdata** を 1 回呼び出すだけで、複数の Xbox ユーザー ID をリセットできます。 要求本文は次のようになります。

```json
    {
      "xuids": [
        "2814659110958830"
      ]
    }
```

## <a name="sending-feedback-from-titles"></a>タイトルからのフィードバックの送信

タイトルはマッチからプレイヤーのフェアプレイに関するフィードバックを送信できます。 これを行うには、タイトルから直接送信するか、またはタイトル サービスからバッチで送信します。 タイトルでは、**ReputationService.SubmitReputationFeedbackAsync メソッド**か、または次に示す直接の REST メソッドを使用できます。

|                      |                                                             |
|----------------------|-------------------------------------------------------------|
| Client POST          | https://reputation.xboxlive.com/users/xuid{XUID}/feedback |
| サービス (バッチ) の POST | https://reputation.xboxlive.com:10443/users/batchfeedback   |

提出用の JSON 本文のサンプルおよび許可されるフィールドの定義については、「**Feedback (JSON)**」を参照してください。


## <a name="types-of-feedback-allowed"></a>許可されるフィードバックの種類

送信できるフィードバックのカテゴリーについては、「**Feedback (JSON)**」を参照してください。


## <a name="when-titles-should-send-feedback"></a>タイトルがフィードバックを送信する必要がある場合

ゲームでのプレイヤー エクスペリエンスに悪影響を与える状況が発生した場合、タイトルは否定的なフィードバックを送信する必要があります。 一般的な規則として、タイトルは、プレイされたラウンドごとに、1 つの種類につき 1 つだけフィードバックを送信します。 たとえば、タイトルでは以下のようにする必要があります。

1.  プレイヤーが 3 人以上のチームメイトを倒した場合は、チームメイトを倒すたびにイベントを送信するのではなく、全体に対して 1 つだけ FairPlayKillsTeammates フィードバック項目を送信します。
2.  だれかが意図的に早くマッチを終了したときは、FairplayQuitter フィードバック項目を送信します。
3.  ユーザーがレーシング ゲームで逆方向に走行したときは、レースごとに 1 回、FairplayUnsporting フィードバック項目を送信します。
