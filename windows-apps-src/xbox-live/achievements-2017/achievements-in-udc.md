---
title: Achievements 2017
author: StaceyHaffner
description: "UDC で実績を構成してリワードを提供する方法について説明します。"
ms.assetid: 
ms.author: sthaff
ms.date: 07-11-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, UDC, ユニバーサル デベロッパー センター"
ms.openlocfilehash: eef41656b76db57cf68b3247285ac7b875370778
ms.sourcegitcommit: a9e4be98688b3a6125fd5dd126190fcfcd764f95
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/21/2017
---
# <a name="configure-achievements-2017-on-dev-center"></a>デベロッパー センターでの Achievements 2017 の構成

> [!IMPORTANT]
> 実績は、ID@Xbox または対象パートナーにのみ適用されます。 Xbox Live クリエーターズ プログラムに参加しているゲームはサポートされません。

ユニバーサル デベロッパー センター (UDC) を使用して、ゲームに関連付けられている [Achievements 2017](simplified-achievements.md) を構成することができます。 次の手順に従って新しい実績を追加します。

1. [`Services`] -> [`Xbox Live`] -> [`Achievements`] の順に選択して、タイトルの実績セクションに移動します。
2. [`New Achievement`] ボタンをクリックし、フォームに記入します。  完了したら、[`Save`] をクリックします。

![](../images/udc/achievements_1.png)

## <a name="description"></a>Description (説明)
説明セクションに、名前やロック状態/ロック解除状態での説明など、実績の基本情報を入力します。 UDC で [`Localized Strings`] サービス構成セクションにアクセスして、実績にローカライゼーション サポートを追加することができます。

![](../images/udc/achievements_2.png)

[`Achievement Name`] フィールドには、実績の一般向けの名前を入力します。

[`Locked Description`] フィールドには、実績のロックを解除していないときにプレイヤーに表示される説明を入力します。 これには 100 文字の制限があります。

[`Unlocked Description`] フィールドには、実績のロックを解除しているときにプレイヤーに表示される説明を入力します。 これには 100 文字の制限があります。

## <a name="details"></a>Details (詳細)
詳細セクションは、イメージ、実績の種類、ゲーマー スコア リワード (ある場合)、ロックを解除するまで実績を非表示にするかどうかなどの重要な情報を関連付けるために使用します。

![](../images/udc/achievements_3.png)

[`Image Icon`] フィールドでは、実績と一緒に表示されるイメージを指定します。 これは、1920 x 1080 ピクセルの .png ファイルである必要があります。

`Base Achievements`  は、最初のゲームのリリース時にプレイヤーが使用できます。 `Non-Base Achievements`  は、最初のゲームのリリース後に利用できます (新しい DLC コンテンツなどで)。

[`Gamerscore`] フィールドには、ロックが解除されたときに実績で提供されるゲーマースコア ポイント数を指定します。 各実績で 0 ～ 200 ポイントのリワードを提供することができます。  

`Public`  実績は、実績のロックを解除しているかどうかに関係なく、すべてのプレイヤーに表示されます。 `Secret`  実績は、ロックが解除されるまで表示されません。

`Achievement deep link` は、実績から戻るパラメーターを取得するための方法です。これによって、実績を獲得できるゲーム内のスポットにリンクすることができます。 ディープ リンクは GET API の応答で返されます。 指定する URL には、`ms-xbl-{titleID}://` プレフィックスを含める必要があります。

> [!TIP]
> 実績のディープ リンクには、ゲームの 16 進の TitleId が必要です。 これは UDC の [`Xbox Live Setup`] 画面に表示されます。 

## <a name="additional-rewards"></a>Additional Rewards (追加リワード)
場合によっては、プレイヤーが実績のロックを解除したときに、ゲーム内リワードやアートワークを提供することもできます。 [`Additional Rewards`] セクションで、実績に関連付けられたリワード (ある場合) を定義できます。 実績には 2 つの追加リワードを含めることができます (リワードの種類ごとに 1 つ)。 詳しくは、「[実績のリワード](achievement-rewards.md)」の記事をご覧ください。

新しいリワードを作成するには、[`Additional Rewards`] セクションの [`Add Reward`] ボタンをクリックし、フォームに記入します。

![](../images/udc/achievements_4.png)

### <a name="reward-details"></a>Reward Details (リワードの詳細)
[Reward Details] に記入して、新しいリワードを関連付けます。 完了したら、[`Add`] をクリックします。

![](../images/udc/achievements_5.png)

作成できる実績のリワードには 2 つの種類があります。 次の 2 つです。 

1. `Art` タイプは、高解像度のコンセプト アート、初期のデザイン画、特別に作成されたアート アセット、その他のデジタル アート アセットなどを使用するプレイヤーにリワードを提供する場合に使用できます。 アート アセットは、Xbox One ダッシュ ボード内に表示されます。実績サービスをクエリすることで、コンパニオン エクスペリエンスに表示することもできます。
2. `In-Game` タイプは、タイトルを更新せずにカスタムのゲーム内リワードをプレイヤーに提供する場合に使用できます。 考えられるシナリオには、特別なゲーム内通貨/ポイントや、特別なキャラクター、武器、マップの使用などがあります。

[`Display Name`] フィールドには、プレイヤーに表示されるリワードの名前を指定します。 これには 57 文字の制限があります。

[`Description`] フィールドには、プレイヤーに表示されるリワードの説明を入力します。説明には引き換え手順を含める必要があります。 これには 90 文字の制限があります。

[`Image`] または [`Art`] フィールドには、リワードに関連付けられるイメージを指定します。 種類が Art に設定されている場合、これはリワードの対象になるアートワークです。 そうでない場合、これはプレイヤーが受け取るゲーム内リワードを表します。 このイメージは、1920 x 1080 ピクセルの .png ファイルである必要があります。

[`In-game value`] フィールドが表示されるは、リワードの種類として [`In-game`] を選択した場合のみです。 これは、ゲーム内リワードのロックを解除するために使用できるゲームのコードに渡される値を指定するために使用されます。