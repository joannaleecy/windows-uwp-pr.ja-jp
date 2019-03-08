---
title: Device Portal の SSH ピン API のリファレンス
description: 信頼されているすべての SSH ピンをプログラムで削除する方法について説明します。
ms.localizationpriority: medium
ms.topic: article
ms.date: 02/08/2017
ms.openlocfilehash: 2c7dc6fab021c11c98276ee53af161bea25601a9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57663357"
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
**使用可能なデバイス ファミリ**

* Windows Xbox

