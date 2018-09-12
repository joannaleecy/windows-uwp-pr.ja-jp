---
title: POST (/users/xuid({xuid})/deleteuserdata)
assetID: 8be13ff9-5d42-43a1-f2fa-d550d845a552
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdatapost.html
author: KevinAsgari
description: " POST (/users/xuid({xuid})/deleteuserdata)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7bcb7b1c6c23f39846084ba4e6583553e2ff04a1
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882023"
---
# <a name="post-usersxuidxuiddeleteuserdata"></a>POST (/users/xuid({xuid})/deleteuserdata)
テスト ユーザーの評判のデータを完全にリセットします。 テストのみです。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4E5)
  * [Authorization](#ID4EJB)
  * [必要な要求ヘッダー](#ID4E3B)
  * [HTTP ステータス コード](#ID4EHC)
  * [応答本文](#ID4EJF)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

この API を呼び出すと、ユーザーからすべてのフィードバック項目と評判のデータが削除されます。 パートナーは、Retail を除くすべてのサンド ボックスに対してこの API を呼び出す場合があります。 執行チームは、すべてのサンド ボックス ID を持つには、この API を呼び出すことがあります。

これらの Uri のドメインが`reputation.xboxlive.com`します。 この URI は、常にポート 10443 で呼び出されます。

<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 型| 説明|
| --- | --- | --- |
| xuid| 64 ビットの符号なし整数| Xbox ユーザー ID (XUID)、ユーザーがデータが削除されているのです。|

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

Retail サンド ボックスで、執行チームから**PartnerClaim**します。

すべてのサンド ボックスに対して、 **PartnerClaim**と**SandboxIdClaim**。

<a id="ID4E3B"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

**コンテンツの種類: アプリケーション/json**と**X Xbl コントラクト バージョン**(現在のバージョンは 101)。

<a id="ID4EHC"></a>


## <a name="http-status-codes"></a>HTTP ステータス コード

サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。

| コード| 理由フレーズ| 説明|
| --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得されます。|
| 400| Bad Request| サービスは、形式が正しくない要求を理解していない可能性があります。 通常、無効なパラメーターです。|
| 401| 権限がありません| 要求には、ユーザー認証が必要です。|
| 404| Not Found します。| 指定されたリソースは見つかりませんでした。|
| 500| 内部サーバー エラー| サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。|
| 503| Service Unavailable| 要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度要求を行ってください。|

<a id="ID4EJF"></a>


## <a name="response-body"></a>応答本文

成功した場合はなしそれ以外の場合、 [ServiceError (JSON)](../../json/json-serviceerror.md)ドキュメントです。

<a id="ID4EWF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EYF"></a>


##### <a name="parent"></a>Parent

[/users/xuid({xuid})/deleteuserdata](uri-usersxuiddeleteuserdata.md)
