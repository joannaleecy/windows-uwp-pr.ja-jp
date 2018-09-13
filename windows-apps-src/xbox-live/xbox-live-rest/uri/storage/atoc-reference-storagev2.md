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
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3957125"
---
# <a name="title-storage-uris"></a>タイトル ストレージ Uri
 
このセクションでは、*タイトル ストレージ*用の Xbox Live サービスからの詳細については、ユニバーサル Resource Identifier (URI) アドレスと関連付けられたハイパー テキスト トランスポート プロトコル (HTTP) メソッドを提供します。
 
どのプラットフォームで実行されるゲームでも、このサービスを使用できます。
 
これらの Uri のドメインは、titlestorage.xboxlive.com です。
 
<a id="ID4EFB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[グローバル//global/scids/{scid}](uri-globalscidsscid.md)

&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。

[グローバル//global/scids/{scid}/data/{パス}](uri-globalscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/global/scids/{scid}/data/{pathAndFileName},{type}](uri-globalscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[json/ユーザー//global/scids/{scid}/data/{pathAndFileName} json をバッチ処理](uri-jsonusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/json/users/xuid({xuid})/scids/{scid}](uri-jsonusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。

[/json/users/xuid({xuid})/scids/{scid}/data/{パス}](uri-jsonusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName} json](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。

[/sessions/{sessionId}/scids/{scid}](uri-sessionssessionidscidsscid.md)

&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。

[/sessions/{sessionId} {scid}/scids//data/{パス}](uri-sessionssessionidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/sessions/{sessionId} {scid}/scids//data/{pathAndFileName} {型}](uri-sessionssessionidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ファイルをダウンロードします。

[ユーザー/trustedplatform//global/scids/{scid}/data/{pathAndFileName} {の種類} をバッチ処理/](uri-trustedplatformusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/trustedplatform/users/xuid({xuid})/scids/{scid}](uri-trustedplatformusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{パス}](uri-trustedplatformusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。

[ユーザー/untrustedplatform//global/scids/{scid}/data/{pathAndFileName} {の種類} をバッチ処理/](uri-untrustedplatformusersbatchscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;同じファイル名を持つ複数のユーザーからは、複数のファイルをダウンロードします。

[/untrustedplatform/users/xuid({xuid})/scids/{scid}](uri-untrustedplatformusersxuidscidsscid.md)

&nbsp;&nbsp;このストレージの種類のクォータ情報を取得します。

[/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{パス}](uri-untrustedplatformusersxuidscidssciddatapath.md)

&nbsp;&nbsp;指定されたパスのファイル情報の一覧を示します。 

[/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName} {型}](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

&nbsp;&nbsp;ダウンロード、アップロード、またはファイルを削除します。
 
<a id="ID4E5C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EAD"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   