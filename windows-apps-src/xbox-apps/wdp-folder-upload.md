---
author: WilliamsJason
title: "Device Portal のフォルダー アップロード API のリファレンス"
description: "フォルダー アップロード API にプログラムでアクセスする方法について説明します。"
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: e1a2c7f0-0040-4ce7-94de-17224736e20b
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 8c2251c5c78fed10959b89de0d81ff563d0fa3e3
ms.lasthandoff: 02/08/2017

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


