---
title: コントローラー サポートを Xbox Live プレハブに追加する
author: KevinAsgari
description: Xbox Live Unity プラグインを使用して、コントローラー サポートを Xbox Live プレハブに追加する
ms.assetid: ''
ms.author: heba
ms.date: 07/14/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, コントローラー サポート
ms.localizationpriority: medium
ms.openlocfilehash: 29b9dcc18d3930300354d2fdcef78d68314f6514
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3960857"
---
# <a name="add-controller-support-to-xbox-live-prefabs"></a><span data-ttu-id="c9e3d-104">コントローラー サポートを Xbox Live プレハブに追加する</span><span class="sxs-lookup"><span data-stu-id="c9e3d-104">Add controller support to Xbox Live prefabs</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c9e3d-105">Xbox Live Unity プラグインでは、実績とオンライン マルチプレイヤーがサポートされていないため、[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-105">The Xbox Live Unity plugin does not support achievements or online multiplayer and is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members.</span></span>

<span data-ttu-id="c9e3d-106">Xbox Live Unity プラグインのすべてのプレハブでは、インスペクターにコントローラーの入力を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-106">All of the Xbox Live Unity Plugin Prefabs support specifying controller input in the inspector.</span></span>

<span data-ttu-id="c9e3d-107">たとえば、`UserProfile1` と呼ばれるゲーム オブジェクトがあり、`UserProfile` プレハブに基づいているとします。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-107">For example, let's say you have a game object called `UserProfile1` which is based on the `UserProfile` prefab.</span></span> <span data-ttu-id="c9e3d-108">このゲーム オブジェクトをプレイヤー 1 に関連付け、Xbox コント ローラーの `A` ボタンでサインインできるようにするには、インスペクターの `Input Controller Button` フィールドに `joystick 1 button 0` と記述するだけです。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-108">If you would like to tie this game object to Player 1 and have them sign in with the `A` button on their Xbox Controller, simply write `joystick 1 button 0` in the `Input Controller Button` field in the inspector.</span></span>

  ![UserProfile プレハブでのコントローラー サポート](../images/unity/controller-support-example.png)

## <a name="all-prefab-controller-input-fields"></a><span data-ttu-id="c9e3d-110">プレハブのすべてのコントローラー入力フィールド</span><span class="sxs-lookup"><span data-stu-id="c9e3d-110">All Prefab Controller Input Fields</span></span>
### <a name="userprofile-prefab"></a><span data-ttu-id="c9e3d-111">UserProfile プレハブ</span><span class="sxs-lookup"><span data-stu-id="c9e3d-111">UserProfile prefab</span></span>
- <span data-ttu-id="c9e3d-112">**Input Controller Button (入力コントローラー ボタン):** Xbox Live ユーザーの追加とサインインを行います。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-112">**Input Controller Button:** Adds and signs in an Xbox Live user.</span></span>

### <a name="social-prefab"></a><span data-ttu-id="c9e3d-113">Social プレハブ</span><span class="sxs-lookup"><span data-stu-id="c9e3d-113">Social prefab</span></span>
- <span data-ttu-id="c9e3d-114">**Toggle Filter Controller Button (フィルターの切り替えコントローラー ボタン):** "すべての" フレンドまたは "オンライン" フレンド のどちらかを表示するためのフィルターを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-114">**Toggle Filter Controller Button:** Toggles the filter to show either 'All' friends or 'Online' friends.</span></span>

### <a name="leaderboard-prefab"></a><span data-ttu-id="c9e3d-115">Leaderboard プレハブ</span><span class="sxs-lookup"><span data-stu-id="c9e3d-115">Leaderboard prefab</span></span>
- <span data-ttu-id="c9e3d-116">**First Controller Button ("最初へ" コントローラー ボタン):** プレイヤーをランキング エントリの最初のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-116">**First Controller Button:** Takes the player to the first page of leaderboard entries.</span></span>
- <span data-ttu-id="c9e3d-117">**Last Controller Button ("最後へ" コントローラー ボタン):** プレイヤーをランキング エントリの最後のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-117">**Last Controller Button:** Takes the player to the last page of leaderboard entries.</span></span>
- <span data-ttu-id="c9e3d-118">**Next Controller Button ("次へ" コントローラー ボタン):** プレイヤーをランキング エントリの次のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-118">**Next Controller Button:** Takes the player to the next page of leaderboard entries.</span></span>
- <span data-ttu-id="c9e3d-119">**Prev Controller Button ("前へ" コントローラー ボタン):** プレイヤーをランキング エントリの前のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-119">**Prev Controller Button:** Takes the player to the previous page of leaderboard entries.</span></span>
- <span data-ttu-id="c9e3d-120">**Refresh Controller Button (更新コントローラー ボタン):** ランキング ビューを更新します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-120">**Refresh Controller Button:** Refreshes the leaderboard view.</span></span>


### <a name="game-save-ui-prefab"></a><span data-ttu-id="c9e3d-121">Game Save UI プレハブ</span><span class="sxs-lookup"><span data-stu-id="c9e3d-121">Game Save UI prefab</span></span>
- <span data-ttu-id="c9e3d-122">**Generate New Controller Button (新規生成コントローラー ボタン):** 新しい整数型のセーブ データを生成します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-122">**Generate New Controller Button:** Generates a new integer save data.</span></span>
- <span data-ttu-id="c9e3d-123">**Save Data Controller Button (データの保存コントローラー ボタン):** 現在のデータを接続ストレージに保存します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-123">**Save Data Controller Button:** Saves the current data into the Connected Storage.</span></span>
- <span data-ttu-id="c9e3d-124">**Load Data Controller Button (データの読み込みコントローラー ボタン):** 接続ストレージに現在保存されているデータを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-124">**Load Data Controller Button:** Loads data currently saved in the Connected Storage.</span></span>
- <span data-ttu-id="c9e3d-125">**Get Info Controller Button (情報の取得コントローラー ボタン):** 接続ストレージに保存されているコンテナーに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-125">**Get Info Controller Button:** Retrieves information about saved containers in the Connected Storage.</span></span>
- <span data-ttu-id="c9e3d-126">**Delete Container Controller Button (コンテナーの削除コントローラー ボタン):** 保存されているコンテナーを接続ストレージから削除します。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-126">**Delete Container Controller Button:** Deletes the saved container from the Connected Storage</span></span>

## <a name="xbox-controller-button-mappings"></a><span data-ttu-id="c9e3d-127">Xbox コントローラー ボタンのマッピング</span><span class="sxs-lookup"><span data-stu-id="c9e3d-127">Xbox Controller Button Mappings</span></span>

<span data-ttu-id="c9e3d-128">Unity での Xbox コントローラー ボタンのマッピングについては、[Unity コントローラーに関する Wiki ページ](http://wiki.unity3d.com/index.php?title=Xbox360Controller)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c9e3d-128">For the Xbox Controller Button Mappings in Unity, check out this [Unity Controller Wiki page](http://wiki.unity3d.com/index.php?title=Xbox360Controller).</span></span>
