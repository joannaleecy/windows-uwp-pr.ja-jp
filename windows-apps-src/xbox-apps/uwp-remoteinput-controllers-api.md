---
author: WilliamsJason
title: デバイス ポータル コントローラー API リファレンス
description: 接続された物理コントローラーの数を取得し、プログラムでオフにする方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 5e0b85293ada8619246c3c23ef2103ead5f40c23
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5989372"
---
# <a name="controller-api-reference"></a>コントローラー API のリファレンス   
接続された物理コントローラーの数を取得し、REST API を使用してオフにすることができます。

## <a name="determine-the-number-of-attached-physical-controllers"></a>接続された物理コントローラーの数の決定

**要求**

次の要求を使用して、デバイス上に接続された物理コントローラーの数を確認することができます。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/remoteinput/controllers
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**   

- なし

**応答**   

- 接続された物理コントローラーの数を指定する JSON 数値プロパティ ConnectedControllerCount です。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 成功
4XX | エラー コード
5XX | エラー コード

## <a name="disconnect-all-physical-controllers-on-the-devkit"></a>開発キット上のすべての物理コントローラーの切断

**要求**

次の要求を使って、デバイス上のすべての物理コントローラーを切断することができます。

メソッド      | 要求 URI
:------     | :-----
DELETE | /ext/remoteinput/controllers
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
204 | コントローラーを接続する要求が成功しました。
4XX | エラー コード
5XX | エラー コード

<br />
**利用可能なデバイス ファミリ**

* Windows Xbox
