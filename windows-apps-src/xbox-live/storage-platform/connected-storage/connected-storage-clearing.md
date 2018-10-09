---
title: ローカル ストレージのクリア
author: KevinAsgari
description: 接続ストレージ データのローカル ストレージをクリアする方法について説明します。
ms.assetid: 0701b03e-88e4-4720-9744-ca174f3c947d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: low
ms.openlocfilehash: aeb42afbed4be764134b0a5b1a7581c109a80aa0
ms.sourcegitcommit: 79f09d32ee89b32fac12fb1849df991b2d6c3c0a
ms.translationtype: Auto
ms.contentlocale: ja-JP
ms.lasthandoff: 03/07/2018
ms.locfileid: "1635763"
---
# <a name="clearing-local-storage"></a>ローカル ストレージのクリア

接続ストレージ API を使用して書き込まれるすべてのデータは、開発キット上のストレージ ボリュームに保存されます。 接続ストレージを工場出荷時の状態にリセットするには、*xbstorage* を使用してローカル保存されたデータを削除できます。

### <a name="to-clear-local-storage"></a>ローカル ストレージをクリアするには

1.  クリアするデータに関連付けられているアプリケーションを終了します。
2.  *xbstorage* ツールを、**reset** コマンドおよび **/force** スイッチを指定して実行します。

        xbstorage reset /force

3.  本体を再起動します。
