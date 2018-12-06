---
title: デバイス ポータル展開情報 API リファレンス
description: 展開情報 API にプログラムでアクセスする方法について説明します。
ms.localizationpriority: medium
ms.openlocfilehash: c44089313b100880b419e9b55a26101e877496f3
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8758242"
---
# <a name="requests-deployment-information-for-one-or-more-installed-packages"></a>1 つ以上のインストール パッケージの展開情報を要求します。

**要求**

メソッド      | 要求 URI
:------     | :------
POST | /ext/app/deployinfo
<br />
**URI パラメーター**

 - なし

**要求ヘッダー**

- なし

**要求本文**

次の形式の JSON 配列。

* DeployInfo
  * PackageFullName - 情報を要求するパッケージの名前。
  * OverlayFolder - この機能を使用する場合の、オーバーレイ フォルダーのパスへのオプションのパス。

###<a name="response"></a>応答

**応答本文**

次の形式での JSON 配列 (一部のフィールドは省略可能)。

* DeployInfo
  * PackageFullName - 情報を受け取るパッケージの名前。
  * DeployType - 展開の種類。
  * DeployPathOrSpecifiers - ルーズ展開の展開パスまたはパッケージ化された展開のインストール済み指定子。
  * DeployDrive - 該当する展開の種類のパッケージが展開されているドライブです。
  * DeploySizeInBytes - 該当する展開の種類のパッケージのサイズ (バイト単位) です。
  * OverlayFolder - この機能をサポートする展開のオーバーレイ フォルダーです。

**状態コード**

この API では次の状態コードが返される可能性があります。

HTTP 状態コード      | 説明
:------     | :-----
200 | 成功
4XX | エラー コード
5XX | エラー コード
<br />

**利用可能なデバイス ファミリ**

* Windows Xbox