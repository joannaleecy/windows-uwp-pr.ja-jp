---
title: POST (/users/xuid({xuid})/deleteuserdata)
assetID: 8be13ff9-5d42-43a1-f2fa-d550d845a552
permalink: en-us/docs/xboxlive/rest/uri-usersxuiddeleteuserdatapost.html
description: " POST (/users/xuid({xuid})/deleteuserdata)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dab43079dbba3729ff39f3a2116c377c3b73142a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57604067"
---
# <a name="post-usersxuidxuiddeleteuserdata"></a>POST (/users/xuid({xuid})/deleteuserdata)
テスト ユーザーの評価データを完全にリセットします。 テスト目的専用です。

  * [注釈](#ID4EQ)
  * [URI パラメーター](#ID4E5)
  * [承認](#ID4EJB)
  * [必要な要求ヘッダー](#ID4E3B)
  * [HTTP 状態コード](#ID4EHC)
  * [応答本文](#ID4EJF)

<a id="ID4EQ"></a>


## <a name="remarks"></a>注釈

この API を呼び出すと、ユーザーから、すべてのフィードバック項目と評価データの設定が削除されます。 パートナーは、製品版を除く任意のサンド ボックスに対してこの API を呼び出すことができます。 強制チームは、サンド ボックス id には、この API を呼び出すことができます。

これらの Uri のドメインが`reputation.xboxlive.com`します。 この URI は常にポート 10443 で呼び出されます。

<a id="ID4E5"></a>


## <a name="uri-parameters"></a>URI パラメーター

| パラメーター| 種類| 説明|
| --- | --- | --- |
| xuid| 64 ビット符号なし整数| Xbox ユーザー ID (XUID) のデータが削除されるユーザーです。|

<a id="ID4EJB"></a>


## <a name="authorization"></a>Authorization

小売サンド ボックスの**PartnerClaim**強制チームから。

他のすべてのサンド ボックスの**PartnerClaim**と**SandboxIdClaim**します。

<a id="ID4E3B"></a>


## <a name="required-request-headers"></a>必要な要求ヘッダー

**コンテンツの種類: アプリケーション/json**と**X Xbl コントラクト バージョン**(現在のバージョンでは 101 です)。

<a id="ID4EHC"></a>


## <a name="http-status-codes"></a>HTTP 状態コード

サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。 Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。

| コード| 理由語句| 説明|
| --- | --- | --- | --- | --- | --- |
| 200| OK| セッションが正常に取得します。|
| 400| 要求が正しくありません| サービスは、形式が正しくない要求を理解できませんでした。 通常、無効なパラメーター。|
| 401| 権限がありません| 要求には、ユーザー認証が必要です。|
| 404| 検出不可| 指定されたリソースが見つかりませんでした。|
| 500| 内部サーバー エラー| サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。|
| 503| サービス利用不可| 要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。|

<a id="ID4EJF"></a>


## <a name="response-body"></a>応答本文

成功した場合は noneそれ以外の場合、[サービス エラー (JSON)](../../json/json-serviceerror.md)ドキュメント。

<a id="ID4EWF"></a>


## <a name="see-also"></a>関連項目

<a id="ID4EYF"></a>


##### <a name="parent"></a>Parent

[/users/xuid({xuid})/deleteuserdata](uri-usersxuiddeleteuserdata.md)
