---
title: Device Portal のフォルダー アップロード API のリファレンス
description: フォルダー アップロード API にプログラムでアクセスする方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: e1a2c7f0-0040-4ce7-94de-17224736e20b
ms.localizationpriority: medium
ms.openlocfilehash: 0805dbeedcf66bc3596f3d284f51e8f177608396
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7980843"
---
# <a name="upload-a-folder-to-the-development-directory"></a>開発ディレクトリにフォルダーをアップロードする

**要求**

フォルダー全体を DevelopmentFiles の既知のフォルダー ID (またはそのフォルダーのサブフォルダー) に一度にアップロードできます。

メソッド      | 要求 URI
:------     | :------
POST | /api/app/packagemanager/upload 
<br />
**URI パラメーター**

次の追加パラメーターを要求 URI に指定できます。

URI パラメーター      | 説明
:------     | :-----
destinationFolder (必須) | アップロードするフォルダーのターゲット フォルダー名です。 このフォルダーは、本体の d:\developmentfiles\LooseApps に配置されます。 フォルダーが LooseApps の下のサブフォルダーである場合、フォルダー名にパスの区切り文字が含まれる可能性があるため、このフォルダー名は base64 でエンコードされている必要があります。
<br />

**要求ヘッダー**

- なし

**要求本文**

- ディレクトリ コンテンツの原則に従ったマルチパートの http 本文。

**応答**

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

