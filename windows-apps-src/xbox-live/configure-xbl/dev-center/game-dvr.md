---
title: ゲーム DVR
author: shrutimundra
description: Windows デベロッパー センター 2017 で Xbox Live Game DVR 文字列を構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム DVR, Windows デベロッパー センター
ms.openlocfilehash: d3d50dff4f8fc09f4c9303fa68172bd4a46eb2fa
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4206013"
---
# <a name="configuring-game-dvr-on-windows-dev-center"></a>Windows デベロッパー センターでのゲーム DVR の構成

Xbox One で最もよく使われる機能の 1 つにゲーム DVR があります。この機能を使うと、ゲーマーが最高の瞬間を簡単に録画、編集、共有できます。 ゲーム DVR 文字列は、タイトルに開発者が作成した DVR クリップのタイトルとして表示されます。 サービスで文字列を構成すると、そのクリップが取り上げられているアプリに、その文字列の適切なローカライズ バージョンが表示されます。 たとえば、ユーザーがタイトルのラスト ボスを倒したときにクリップを作成する場合、まず "ボス バトル" という文字列を構成します。 タイトル コードで呼び出しを行ってクリップを作成するとき、ID を参照します。

[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)を使い、ゲームに関連付けられたゲーム DVR 文字列を構成できます。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[ゲーム DVR]** の順に選択して、**[ゲーム DVR]** セクションに移動します。
2. **[新しい文字列の作成]** ボタンをクリックします。
3. ポップアップ表示されるモーダルで、ゲーム DVR 文字列を入力します。 完了したら、**[確認]** をクリックします。

![新しいゲーム DVR 文字列のダイアログ ボックスの画像](../../images/dev-center/game-dvr/game-dvr-1.png)
