---
title: GameClipState 列挙型
assetID: 97fe5c1e-f7b5-537e-69eb-8284b69cd3e1
permalink: en-us/docs/xboxlive/rest/gvr-enum-gameclipstate.html
description: " GameClipState 列挙型"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f7b20224eeab1b98c7c80f0e4b551420b5a15e7d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630717"
---
# <a name="gameclipstate-enumeration"></a>GameClipState 列挙型
GameClipState 列挙体をについて説明します。 
<a id="ID4ET"></a>

 
## <a name="gameclipstate"></a>GameClipState
 
| <b>列挙子</b>| <b>説明</b>| 
| --- | --- | 
| なし | ゲームのクリップのサービスの状態が、不明なまたは設定されていません。| 
| PendingUpload | ゲームのクリップのサービスは、資産のアップロードを待機しています。| 
| PendingDelete | ゲームのクリップは、キューの削除です。 (実質的には、「削除」)。| 
| 処理 | ゲームのクリップには、すべての処理が完了しました。| 
| Processing| ゲームのクリップが処理される (エンコード、サムネイルなど。)。| 
| 公開| クリップのゲーム アセットが公開されています。| 
| 公開済み| クリップのゲーム アセットを発行 – この状態は、すべてのセットを表示することを示します。| 
| フラグが設定されました。| 強制ゲーム クリップ フラグが設定されています。| 
| 禁止されています| ゲームのクリップが禁止されましたが、削除されていません。| 
| Uploaded| ゲームのクリップには、アップロードが完了しました。| 
| 削除済み| ゲームのクリップが削除されました。| 
| エラー| ゲームのクリップがエラー状態と使用できなくなります。| 
  