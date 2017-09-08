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
# <a name="clearing-local-storage"></a>ローカル ストレージのクリア

接続ストレージ API を使用して書き込まれるすべてのデータは、開発キット上のストレージ ボリュームに保存されます。 接続ストレージを工場出荷時の状態にリセットするには、*xbstorage* を使用してローカル保存されたデータを削除できます。

### <a name="to-clear-local-storage"></a>ローカル ストレージをクリアするには

1.  クリアするデータに関連付けられているアプリケーションを終了します。
2.  *xbstorage* ツールを、**reset** コマンドおよび **/force** スイッチを指定して実行します。

        xbstorage reset /force

3.  本体を再起動します。
