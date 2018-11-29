---
title: Device Portal の SSH ピン API のリファレンス
description: 信頼されているすべての SSH ピンをプログラムで削除する方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: 1ddf15d3cdb4089a8ef010a4ae46d247a06a10d7
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7991245"
---
# <a name="ssh-pins-api-reference"></a>SSH ピン API リファレンス
この REST API を使用して、開発キットで信頼されているすべての SSH ピンを削除することができます。

## <a name="remove-trusted-ssh-pins"></a>信頼されている SSH ピンの削除

**要求**

メソッド      | 要求 URI
:------     | :-----
DELETE | /ext/app/sshpins
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**   

- なし

**応答**   

- なし 

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
204 | ピンをクリアする要求が成功しました。
4XX | エラー コード
5XX | エラー コード

<br />
**利用可能なデバイス ファミリ**

* Windows Xbox

