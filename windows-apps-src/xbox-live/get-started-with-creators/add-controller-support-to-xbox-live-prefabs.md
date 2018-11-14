---
title: コントローラー サポートを Xbox Live プレハブに追加する
author: KevinAsgari
description: Xbox Live Unity プラグインを使用して、コントローラー サポートを Xbox Live プレハブに追加する
ms.assetid: ''
ms.author: heba
ms.date: 07/14/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, コントローラー サポート
ms.localizationpriority: medium
ms.openlocfilehash: b4fb8f710a04b2243f32daadc652aca8404d4577
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6280301"
---
# <a name="add-controller-support-to-xbox-live-prefabs"></a>コントローラー サポートを Xbox Live プレハブに追加する

> [!IMPORTANT]
> Xbox Live Unity プラグインでは、実績とオンライン マルチプレイヤーがサポートされていないため、[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。

Xbox Live Unity プラグインのすべてのプレハブでは、インスペクターにコントローラーの入力を指定することができます。

たとえば、`UserProfile1` と呼ばれるゲーム オブジェクトがあり、`UserProfile` プレハブに基づいているとします。 このゲーム オブジェクトをプレイヤー 1 に関連付け、Xbox コント ローラーの `A` ボタンでサインインできるようにするには、インスペクターの `Input Controller Button` フィールドに `joystick 1 button 0` と記述するだけです。

  ![UserProfile プレハブでのコントローラー サポート](../images/unity/controller-support-example.png)

## <a name="all-prefab-controller-input-fields"></a>プレハブのすべてのコントローラー入力フィールド
### <a name="userprofile-prefab"></a>UserProfile プレハブ
- **Input Controller Button (入力コントローラー ボタン):** Xbox Live ユーザーの追加とサインインを行います。

### <a name="social-prefab"></a>Social プレハブ
- **Toggle Filter Controller Button (フィルターの切り替えコントローラー ボタン):** "すべての" フレンドまたは "オンライン" フレンド のどちらかを表示するためのフィルターを切り替えます。

### <a name="leaderboard-prefab"></a>Leaderboard プレハブ
- **First Controller Button ("最初へ" コントローラー ボタン):** プレイヤーをランキング エントリの最初のページに移動します。
- **Last Controller Button ("最後へ" コントローラー ボタン):** プレイヤーをランキング エントリの最後のページに移動します。
- **Next Controller Button ("次へ" コントローラー ボタン):** プレイヤーをランキング エントリの次のページに移動します。
- **Prev Controller Button ("前へ" コントローラー ボタン):** プレイヤーをランキング エントリの前のページに移動します。
- **Refresh Controller Button (更新コントローラー ボタン):** ランキング ビューを更新します。


### <a name="game-save-ui-prefab"></a>Game Save UI プレハブ
- **Generate New Controller Button (新規生成コントローラー ボタン):** 新しい整数型のセーブ データを生成します。
- **Save Data Controller Button (データの保存コントローラー ボタン):** 現在のデータを接続ストレージに保存します。
- **Load Data Controller Button (データの読み込みコントローラー ボタン):** 接続ストレージに現在保存されているデータを読み込みます。
- **Get Info Controller Button (情報の取得コントローラー ボタン):** 接続ストレージに保存されているコンテナーに関する情報を取得します。
- **Delete Container Controller Button (コンテナーの削除コントローラー ボタン):** 保存されているコンテナーを接続ストレージから削除します。

## <a name="xbox-controller-button-mappings"></a>Xbox コントローラー ボタンのマッピング

Unity での Xbox コントローラー ボタンのマッピングについては、[Unity コントローラーに関する Wiki ページ](http://wiki.unity3d.com/index.php?title=Xbox360Controller)をご覧ください。
