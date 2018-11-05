---
author: WilliamsJason
title: メディア キャプチャ API のリファレンス
description: メディア キャプチャ API にプログラムでアクセスする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 3f92c8fd-4096-4972-97da-01ae5db6423c
ms.localizationpriority: medium
ms.openlocfilehash: f58fa4c3a9a1abd407f635f27de3a545c3aafc6c
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "5983693"
---
# <a name="media-capture-api-reference"></a>メディア キャプチャ API のリファレンス #

**要求**

次の要求形式を使用して、現在の画面の PNG 画像を取得できます。

| メソッド        | 要求 URI     | 
| ------------- |-----------------|
| GET           | /ext/screenshot |
<br>

**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。


| URI パラメーター      | 説明     | 
| ------------------ |-----------------|
| download (省略可能)| ホスト ブラウザーでスクリーンショットをブラウザーにレンダリングするのではなく添付ファイルとしてダウンロードする必要があることを、HTTP 応答ヘッダーで設定する必要があるかどうかを示すブール値。  |
<br>

**要求ヘッダー**

* なし

**要求本文**

* なし

###<a name="response"></a>応答番号

**状態コード**

この API では次の状態コードが返される可能性があります。

| HTTP 状態コード   | 説明     | 
| ------------------ |-----------------|
| 200                | スクリーンショットの要求が成功し、キャプチャが返される |
| 5XX                | 予期しないエラーのエラー コード |
<br>

**利用可能なデバイス ファミリ**

* Windows Xbox

