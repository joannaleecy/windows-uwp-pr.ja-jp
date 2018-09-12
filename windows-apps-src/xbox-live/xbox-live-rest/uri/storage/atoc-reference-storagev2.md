---
title: タイトル ストレージ Uri
assetID: 32bba1e4-0980-785e-c098-a96cd88a8e5f
permalink: en-us/docs/xboxlive/rest/atoc-reference-storagev2.html
author: KevinAsgari
description: " タイトル ストレージ Uri"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5a188c3406ad0ca3bfca78d6b45c548c72bf791e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882083"
---
# <a name="title-storage-uris"></a>タイトル ストレージ Uri
 
このセクションでは、*タイトル ストレージ*の Xbox Live サービスからユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細情報を提供します。
 
どのプラットフォームで実行されるゲームでも、このサービスを使用できます。
 
これらの Uri のドメインは、titlestorage.xboxlive.com です。
 
<a id="ID4EFB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[グローバル///}](uri-globalscidsscid.md)

&nbsp;&nbsp;このストレージの種類でクォータ情報を取得します。

[グローバル///}/data/{path}](uri-globalscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/global/scids/{scid}/data/{pathAndFileName},{type}](uri-globalscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[ユーザー/json//{scid}/{scid}/data}、json をバッチ処理/](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/json/users/xuid({xuid})/scids/{scid}](uri-jsonusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類でクォータ情報を取得します。

[/json/users/xuid({xuid})/scids/{scid}/data/{path}](uri-jsonusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/json/users/xuid({xuid})/scids/{scid} {scid}/data}、json](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。

[/sessions/{sessionId}/scids/{scid}](uri-sessionssessionidscidsscid.md)

&nbsp;&nbsp;このストレージの種類でクォータ情報を取得します。

[/sessions/{sessionId}/scids/{scid}/data/{path}](uri-sessionssessionidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/sessions/{sessionId}/scids/{scid}/data {{pathandfilename}, {type}](uri-sessionssessionidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[ユーザー/trustedplatform//{scid}/{scid}/data}, {type} をバッチ処理/](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/trustedplatform/users/xuid({xuid})/scids/{scid}](uri-trustedplatformusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類でクォータ情報を取得します。

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}](uri-trustedplatformusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。

[ユーザー/untrustedplatform//{scid}/{scid}/data}, {type} をバッチ処理/](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/untrustedplatform/users/xuid({xuid})/scids/{scid}](uri-untrustedplatformusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類でクォータ情報を取得します。

[/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{path}](uri-untrustedplatformusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/untrustedplatform/users/xuid({xuid})/scids/{scid}/data {{pathandfilename}, {type}](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) の参照](../atoc-xboxlivews-reference-uris.md)

   