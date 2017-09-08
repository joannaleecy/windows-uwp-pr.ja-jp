---
title: "ローカル ストレージのクリア"
author: KevinAsgari
description: "接続ストレージ データのローカル ストレージをクリアする方法について説明します。"
ms.assetid: 0701b03e-88e4-4720-9744-ca174f3c947d
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ"
ms.openlocfilehash: f6f0b45751148c12306ea225c56a578aea11be83
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="clearing-local-storage"></a><span data-ttu-id="db0b0-104">ローカル ストレージのクリア</span><span class="sxs-lookup"><span data-stu-id="db0b0-104">Clearing local storage</span></span>

<span data-ttu-id="db0b0-105">接続ストレージ API を使用して書き込まれるすべてのデータは、開発キット上のストレージ ボリュームに保存されます。</span><span class="sxs-lookup"><span data-stu-id="db0b0-105">All data written using the Connected Storage API is saved to the storage volume on development kits.</span></span> <span data-ttu-id="db0b0-106">接続ストレージを工場出荷時の状態にリセットするには、*xbstorage* を使用してローカル保存されたデータを削除できます。</span><span class="sxs-lookup"><span data-stu-id="db0b0-106">The locally stored data can be deleted using the *xbstorage* tool to perform a factory reset of connected storage.</span></span>

### <a name="to-clear-local-storage"></a><span data-ttu-id="db0b0-107">ローカル ストレージをクリアするには</span><span class="sxs-lookup"><span data-stu-id="db0b0-107">To clear local storage</span></span>

1.  <span data-ttu-id="db0b0-108">クリアするデータに関連付けられているアプリケーションを終了します。</span><span class="sxs-lookup"><span data-stu-id="db0b0-108">Terminate the app associated with the data you want to clear.</span></span>
2.  <span data-ttu-id="db0b0-109">*xbstorage* ツールを、**reset** コマンドおよび **/force** スイッチを指定して実行します。</span><span class="sxs-lookup"><span data-stu-id="db0b0-109">Run the *xbstorage* tool specifying the **reset** command and the **/force** switch.</span></span>

        xbstorage reset /force

3.  <span data-ttu-id="db0b0-110">本体を再起動します。</span><span class="sxs-lookup"><span data-stu-id="db0b0-110">Reboot the console.</span></span>
