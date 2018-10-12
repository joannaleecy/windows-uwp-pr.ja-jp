---
title: マルチプレイヤー用に AppXManifest を構成する
author: KevinAsgari
description: Xbox Live のマルチプレイヤー間の招待が有効になるように UWP AppXManifest を構成する方法について説明します。
ms.assetid: 72f179e7-4705-4161-9b8a-4d6a1a05b8f7
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プロトコルのアクティブ化, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: bc20d183a16bd0f5be418699c8e7eb3b02ba889c
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4566699"
---
# <a name="configure-your-appxmanifest-for-multiplayer"></a><span data-ttu-id="bb8d3-104">マルチプレイヤー用に AppXManifest を構成する</span><span class="sxs-lookup"><span data-stu-id="bb8d3-104">Configure your AppXManifest for Multiplayer</span></span>

<span data-ttu-id="bb8d3-105">次の条件に該当する場合、Visual Studio プロジェクトで .appxmanifest ファイルにいくつかの更新を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-105">You need to make some updates to the .appxmanifest file in your Visual Studio project if the following conditions are true:</span></span>
- <span data-ttu-id="bb8d3-106">UWP を開発している</span><span class="sxs-lookup"><span data-stu-id="bb8d3-106">You are developing a UWP</span></span>
- <span data-ttu-id="bb8d3-107">プレイヤーが他のユーザーをタイトルに招待できる機能を実装する</span><span class="sxs-lookup"><span data-stu-id="bb8d3-107">You want to implement the ability for players to invite other users to your title</span></span>

<span data-ttu-id="bb8d3-108">この手順を実行しなかった場合、受信者のプレイヤーがプレイの招待を受け入れても、タイトルによってプロトコルがアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-108">If you don't do this step, then your title will not get  protocol activated when a recipient player accepts an invitation to play.</span></span>

## <a name="open-your-packageappxmanifest"></a><span data-ttu-id="bb8d3-109">Package.appxmanifest を開く</span><span class="sxs-lookup"><span data-stu-id="bb8d3-109">Open your Package.appxmanifest</span></span>

<span data-ttu-id="bb8d3-110">Package.appxmanifest ファイルは通常、Visual Studio プロジェクトのソリューション ファイルと同じディレクトリに置かれています。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-110">Your Package.appxmanifest file is typically located in the same directory as your Visual Studio project's solution file.</span></span>  <span data-ttu-id="bb8d3-111">ソリューション エクスプローラーで検索することもできます。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-111">Or you can find it in the solution explorer.</span></span>

![](../../images/multiplayer/multiplayer_open_appxmanifest.png)

## <a name="add-new-entry"></a><span data-ttu-id="bb8d3-112">新しいエントリを追加する</span><span class="sxs-lookup"><span data-stu-id="bb8d3-112">Add new entry</span></span>

<span data-ttu-id="bb8d3-113">Package.appxmanifest ファイルの ```<Applications>``` 内にある ```<Extensions>``` 要素に以下のコードを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-113">You will need to add the following to the ```<Extensions>``` element under ```<Applications>``` in your Package.appxmanifest file</span></span>

```
<Extensions>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-xbl-multiplayer" />
  </uap:Extension>
</Extensions>
```

<span data-ttu-id="bb8d3-114">例:</span><span class="sxs-lookup"><span data-stu-id="bb8d3-114">Eg:</span></span>

![](../../images/multiplayer/multiplayer_appxmanifest_changes.png)

<span data-ttu-id="bb8d3-115">タイトルを保存してリビルドします。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-115">Save and rebuild your title.</span></span>  <span data-ttu-id="bb8d3-116">Multiplayer Manager を使用してタイトルにプレイヤーを招待する機能を実装する方法については、「[フレンドとのマルチプレイヤーのプレイ](../multiplayer-manager/play-multiplayer-with-friends.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bb8d3-116">To learn how to use the Multiplayer Manager to implement the ability to invite players to your title, please see [Play Multiplayer With Friends](../multiplayer-manager/play-multiplayer-with-friends.md)</span></span>
