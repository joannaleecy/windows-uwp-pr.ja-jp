---
title: コントローラー サポートを Xbox Live プレハブに追加する
description: Xbox Live Unity プラグインを使用して、コントローラー サポートを Xbox Live プレハブに追加する
ms.assetid: ''
ms.date: 07/14/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, コントローラー サポート
ms.localizationpriority: medium
ms.openlocfilehash: 4d32ec62b8beec10256ed9a695866c2fd9bdd03e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622877"
---
# <a name="add-controller-support-to-xbox-live-prefabs"></a>コントローラー サポートを Xbox Live プレハブに追加する

> [!IMPORTANT]
> Xbox Live Unity プラグインでは、実績とオンライン マルチプレイヤーがサポートされていないため、[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。

Xbox Live Unity プラグインのすべてのプレハブでは、インスペクターにコントローラーの入力を指定することができます。

たとえば、`UserProfile1` と呼ばれるゲーム オブジェクトがあり、`UserProfile` プレハブに基づいているとします。 このゲーム オブジェクトをプレイヤー 1 に関連付け、Xbox コント ローラーの `A` ボタンでサインインできるようにするには、インスペクターの `Input Controller Button` フィールドに `joystick 1 button 0` と記述するだけです。

  ![UserProfile プレハブでのコントローラー サポート](../images/unity/controller-support-example.png)

## <a name="all-prefab-controller-input-fields"></a>プレハブのすべてのコントローラー入力フィールド
### <a name="userprofile-prefab"></a>UserProfile プレハブ
- **コント ローラーの入力ボタンをクリックします。** 追加し、ユーザーが Xbox Live にサインインします。

### <a name="social-prefab"></a>Social プレハブ
- **トグル フィルター コント ローラー ボタン:**'All' の友人、または 'オンライン' 友人を表示するフィルターを切り替えます。

### <a name="leaderboard-prefab"></a>Leaderboard プレハブ
- **最初のコント ローラー ボタン:** ランキング エントリの最初のページに player がかかります。
- **最後のコント ローラー ボタン:** ランキング エントリの最後のページに player がかかります。
- **コント ローラーの [次へ] ボタン:** ランキング エントリの次のページに player がかかります。
- **Prev コント ローラー ボタンをクリックします。** ランキング エントリの前のページに player がかかります。
- **コント ローラーのボタンを更新します。** ランキング ビューを更新します。


### <a name="game-save-ui-prefab"></a>Game Save UI プレハブ
- **新しいコント ローラーのボタンを生成します。** データを保存する新しい整数が生成されます。
- **データのコント ローラー ボタンを保存します。** 接続されている記憶域には、現在のデータを保存します。
- **データのコント ローラー ボタンを読み込みます。** 現在接続されている記憶域に保存されているデータを読み込みます。
- **コント ローラー [情報] ボタンを取得します。** 接続されている記憶域に保存されているコンテナーに関する情報を取得します。
- **コンテナーのコント ローラー ボタンを削除します。** 接続されている記憶域から保存されているコンテナーを削除します。

## <a name="xbox-controller-button-mappings"></a>Xbox コントローラー ボタンのマッピング

Unity での Xbox コントローラー ボタンのマッピングについては、[Unity コントローラーに関する Wiki ページ](https://wiki.unity3d.com/index.php?title=Xbox360Controller)をご覧ください。
