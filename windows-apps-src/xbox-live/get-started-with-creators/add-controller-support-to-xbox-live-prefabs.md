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
# <a name="add-controller-support-to-xbox-live-prefabs"></a><span data-ttu-id="1082f-104">コントローラー サポートを Xbox Live プレハブに追加する</span><span class="sxs-lookup"><span data-stu-id="1082f-104">Add controller support to Xbox Live prefabs</span></span>

> [!IMPORTANT]
> <span data-ttu-id="1082f-105">Xbox Live Unity プラグインでは、実績とオンライン マルチプレイヤーがサポートされていないため、[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。</span><span class="sxs-lookup"><span data-stu-id="1082f-105">The Xbox Live Unity plugin does not support achievements or online multiplayer and is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members.</span></span>

<span data-ttu-id="1082f-106">Xbox Live Unity プラグインのすべてのプレハブでは、インスペクターにコントローラーの入力を指定することができます。</span><span class="sxs-lookup"><span data-stu-id="1082f-106">All of the Xbox Live Unity Plugin Prefabs support specifying controller input in the inspector.</span></span>

<span data-ttu-id="1082f-107">たとえば、`UserProfile1` と呼ばれるゲーム オブジェクトがあり、`UserProfile` プレハブに基づいているとします。</span><span class="sxs-lookup"><span data-stu-id="1082f-107">For example, let's say you have a game object called `UserProfile1` which is based on the `UserProfile` prefab.</span></span> <span data-ttu-id="1082f-108">このゲーム オブジェクトをプレイヤー 1 に関連付け、Xbox コント ローラーの `A` ボタンでサインインできるようにするには、インスペクターの `Input Controller Button` フィールドに `joystick 1 button 0` と記述するだけです。</span><span class="sxs-lookup"><span data-stu-id="1082f-108">If you would like to tie this game object to Player 1 and have them sign in with the `A` button on their Xbox Controller, simply write `joystick 1 button 0` in the `Input Controller Button` field in the inspector.</span></span>

  ![UserProfile プレハブでのコントローラー サポート](../images/unity/controller-support-example.png)

## <a name="all-prefab-controller-input-fields"></a><span data-ttu-id="1082f-110">プレハブのすべてのコントローラー入力フィールド</span><span class="sxs-lookup"><span data-stu-id="1082f-110">All Prefab Controller Input Fields</span></span>
### <a name="userprofile-prefab"></a><span data-ttu-id="1082f-111">UserProfile プレハブ</span><span class="sxs-lookup"><span data-stu-id="1082f-111">UserProfile prefab</span></span>
- <span data-ttu-id="1082f-112">**コント ローラーの入力ボタンをクリックします。** 追加し、ユーザーが Xbox Live にサインインします。</span><span class="sxs-lookup"><span data-stu-id="1082f-112">**Input Controller Button:** Adds and signs in an Xbox Live user.</span></span>

### <a name="social-prefab"></a><span data-ttu-id="1082f-113">Social プレハブ</span><span class="sxs-lookup"><span data-stu-id="1082f-113">Social prefab</span></span>
- <span data-ttu-id="1082f-114">**トグル フィルター コント ローラー ボタン:**'All' の友人、または 'オンライン' 友人を表示するフィルターを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="1082f-114">**Toggle Filter Controller Button:** Toggles the filter to show either 'All' friends or 'Online' friends.</span></span>

### <a name="leaderboard-prefab"></a><span data-ttu-id="1082f-115">Leaderboard プレハブ</span><span class="sxs-lookup"><span data-stu-id="1082f-115">Leaderboard prefab</span></span>
- <span data-ttu-id="1082f-116">**最初のコント ローラー ボタン:** ランキング エントリの最初のページに player がかかります。</span><span class="sxs-lookup"><span data-stu-id="1082f-116">**First Controller Button:** Takes the player to the first page of leaderboard entries.</span></span>
- <span data-ttu-id="1082f-117">**最後のコント ローラー ボタン:** ランキング エントリの最後のページに player がかかります。</span><span class="sxs-lookup"><span data-stu-id="1082f-117">**Last Controller Button:** Takes the player to the last page of leaderboard entries.</span></span>
- <span data-ttu-id="1082f-118">**コント ローラーの [次へ] ボタン:** ランキング エントリの次のページに player がかかります。</span><span class="sxs-lookup"><span data-stu-id="1082f-118">**Next Controller Button:** Takes the player to the next page of leaderboard entries.</span></span>
- <span data-ttu-id="1082f-119">**Prev コント ローラー ボタンをクリックします。** ランキング エントリの前のページに player がかかります。</span><span class="sxs-lookup"><span data-stu-id="1082f-119">**Prev Controller Button:** Takes the player to the previous page of leaderboard entries.</span></span>
- <span data-ttu-id="1082f-120">**コント ローラーのボタンを更新します。** ランキング ビューを更新します。</span><span class="sxs-lookup"><span data-stu-id="1082f-120">**Refresh Controller Button:** Refreshes the leaderboard view.</span></span>


### <a name="game-save-ui-prefab"></a><span data-ttu-id="1082f-121">Game Save UI プレハブ</span><span class="sxs-lookup"><span data-stu-id="1082f-121">Game Save UI prefab</span></span>
- <span data-ttu-id="1082f-122">**新しいコント ローラーのボタンを生成します。** データを保存する新しい整数が生成されます。</span><span class="sxs-lookup"><span data-stu-id="1082f-122">**Generate New Controller Button:** Generates a new integer save data.</span></span>
- <span data-ttu-id="1082f-123">**データのコント ローラー ボタンを保存します。** 接続されている記憶域には、現在のデータを保存します。</span><span class="sxs-lookup"><span data-stu-id="1082f-123">**Save Data Controller Button:** Saves the current data into the Connected Storage.</span></span>
- <span data-ttu-id="1082f-124">**データのコント ローラー ボタンを読み込みます。** 現在接続されている記憶域に保存されているデータを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="1082f-124">**Load Data Controller Button:** Loads data currently saved in the Connected Storage.</span></span>
- <span data-ttu-id="1082f-125">**コント ローラー [情報] ボタンを取得します。** 接続されている記憶域に保存されているコンテナーに関する情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="1082f-125">**Get Info Controller Button:** Retrieves information about saved containers in the Connected Storage.</span></span>
- <span data-ttu-id="1082f-126">**コンテナーのコント ローラー ボタンを削除します。** 接続されている記憶域から保存されているコンテナーを削除します。</span><span class="sxs-lookup"><span data-stu-id="1082f-126">**Delete Container Controller Button:** Deletes the saved container from the Connected Storage</span></span>

## <a name="xbox-controller-button-mappings"></a><span data-ttu-id="1082f-127">Xbox コントローラー ボタンのマッピング</span><span class="sxs-lookup"><span data-stu-id="1082f-127">Xbox Controller Button Mappings</span></span>

<span data-ttu-id="1082f-128">Unity での Xbox コントローラー ボタンのマッピングについては、[Unity コントローラーに関する Wiki ページ](https://wiki.unity3d.com/index.php?title=Xbox360Controller)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1082f-128">For the Xbox Controller Button Mappings in Unity, check out this [Unity Controller Wiki page](https://wiki.unity3d.com/index.php?title=Xbox360Controller).</span></span>
