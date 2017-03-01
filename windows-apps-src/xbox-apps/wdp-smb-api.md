---
author: payzer
title: "Device Portal の SMB API のリファレンス"
description: "SMB API にプログラムでアクセスする方法について説明します。"
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 1f0eb76e-fe3e-4674-a27e-229beec7e63d
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: fc52bd3d326a20d0b561ad06b9f4245e7b557f82
ms.lasthandoff: 02/08/2017

---

# <a name="developer-folder-api-reference"></a>開発者向けフォルダー API のリファレンス   
標準的なエクスプローラーを使って、Xbox One の開発に関連するファイルにアクセスできます。 これにより、ファイルを簡単に表示したり、PC から本体に置き換えることができます。

**要求**

次の要求を使用して、開発者向けフォルダーにアクセスできます。 要求によって次の情報が返されます。    
* ファイル共有の場所。 この場所は、エクスプローラーのアドレス バーに入力できます。
* ファイル共有へのアクセスで使うユーザー名。
* ファイル共有へのアクセスで使うパスワード。

メソッド      | 要求 URI
:------     | :-----
GET | /ext/smb/developerfolder
<br />
**URI パラメーター**

- なし

**要求ヘッダー**

- なし

**要求本文**

- なし

**応答**   
Path: 開発者向けファイル共有にあるファイルのパス。   
Username: 開発者向けファイル共有にアクセスするために必要なユーザー名。   
Password: 開発者向けファイル共有にアクセスするために必要なパスワード。   

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | ファイル共有の資格情報にアクセスする要求が許可されました。
4XX | エラー コード
5XX | エラー コード
<br />
**利用可能なデバイス ファミリ**

* Windows Xbox

