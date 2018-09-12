---
title: JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス
assetID: 8efcc6f3-d88a-1b15-bcfc-d79a24581b0a
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-json.html
author: KevinAsgari
description: " JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e65936d20923ecbdc2d9cfb0a0ec52bb7504b885
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881949"
---
# <a name="javascript-object-notation-json-object-reference"></a>JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス
 
JavaScript Object Notation (JSON) では、web 上のデータをカプセル化するための軽量な標準ベース、オブジェクト指向に沿った表記です。
 
Xbox Live サービスは、要求と、サービスからの応答で使用される JSON オブジェクトを定義します。 このセクションでは、Xbox Live サービスで使う各 JSON オブジェクトに関するリファレンス情報を提供します。
 
<a id="ID4EHB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[実績 (JSON)](json-achievementv2.md)

&nbsp;&nbsp;実績オブジェクト (バージョン 2)。

[ActivityRecord (JSON)](json-activityrecord.md)

&nbsp;&nbsp;1 つまたは複数のユーザーのリッチ プレゼンスの形式とローカライズされた文字列です。

[ActivityRequest (JSON)](json-activityrequest.md)

&nbsp;&nbsp;1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。

[AggregateSessionsResponse (JSON)](json-aggregatesessionsresponse.md)

&nbsp;&nbsp;ユーザーの適合性のセッションは、集計されたデータが含まれています。

[BatchRequest (JSON)](json-batchrequest.md)

&nbsp;&nbsp;ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理するためのプロパティの配列です。

[DeviceEndpoint (JSON)](json-deviceendpoint.md)

[DeviceRecord (JSON)](json-devicerecord.md)

&nbsp;&nbsp;、その種類と、タイトルでアクティブななど、デバイスに関する情報。

[フィードバック (JSON)](json-feedback.md)

&nbsp;&nbsp;プレイヤーに関するフィードバックの情報が含まれています。

[ゲーム クリップだった (JSON)](json-gameclip.md)

[GameClipsServiceErrorResponse (JSON)](json-gameclipsserviceerrorresponse.md)

&nbsp;&nbsp;/Users/{ownerId}/scids/{scid}/clips/{gameClipId} への応答の省略可能な部分/uri 形式/{gameClipUriType} API。

[GameClipThumbnail (JSON)](json-gameclipthumbnail.md)

&nbsp;&nbsp;個々 のサムネイルに関連する情報が含まれています。 1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。

[GameClipUri (JSON)](json-gameclipuri.md)

[GameMessage (JSON)](json-gamemessage.md)

&nbsp;&nbsp;ゲーム セッションのメッセージ キューにメッセージのデータを定義する JSON オブジェクトを返します。

[GameResult (JSON)](json-gameresult.md)

&nbsp;&nbsp;ゲーム セッションの結果を示すデータを表す JSON オブジェクト。

[GameSession (JSON)](json-gamesession.md)

&nbsp;&nbsp;マルチプレイヤー セッションのゲーム データを表す JSON オブジェクト。

[GameSessionSummary (JSON)](json-gamesessionsummary.md)

&nbsp;&nbsp;ゲーム セッションの集計データを表す JSON オブジェクト。

[GetClipResponse (JSON)](json-getclipresponse.md)

&nbsp;&nbsp;ゲーム クリップをラップします。

[HopperStatsResults (JSON)](json-hopperstatsresults.md)

&nbsp;&nbsp;ホッパーの統計情報を表す JSON オブジェクト。

[InitialUploadRequest (JSON)](json-initialuploadrequest.md)

&nbsp;&nbsp;POST ゲーム クリップだったの本文は、要求をアップロードします。

[InitialUploadResponse (JSON)](json-initialuploadresponse.md)

[inventoryItem (JSON)](json-inventoryitem.md)

&nbsp;&nbsp;コアのインベントリ項目の権利を付与できる標準の項目を表します。

[LastSeenRecord (JSON)](json-lastseenrecord.md)

&nbsp;&nbsp;利用できるは、ユーザーには、有効な DeviceRecord があるないと、ユーザーが前回、システムに表示されていた場合について説明します。

[MatchTicket (JSON)](json-matchticket.md)

&nbsp;&nbsp;プレイヤーがマルチプレイヤー セッション ディレクトリ (MPSD) を通じて他のプレイヤーを検索に使用するマッチ チケットを表す JSON オブジェクト。

[MediaAsset (JSON)](json-mediaasset.md)

&nbsp;&nbsp;実績やそのリワードに関連付けられているメディア アセット。

[MediaRecord (JSON)](json-mediarecord.md)

[MediaRequest (JSON)](json-mediarequest.md)

[MultiplayerActivityDetails (JSON)](json-multiplayeractivitydetails.md)

&nbsp;&nbsp;**Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**を表す JSON オブジェクト。

[MultiplayerSessionReference (JSON)](json-multiplayersessionreference.md)

&nbsp;&nbsp;**MultiplayerSessionReference**を表す JSON オブジェクト。 

[MultiplayerSessionRequest (JSON)](json-multiplayersessionrequest.md)

&nbsp;&nbsp;**MultiplayerSession**オブジェクトで操作の要求の JSON オブジェクトが渡されます。

[MultiplayerSession (JSON)](json-multiplayersession.md)

&nbsp;&nbsp;**MultiplayerSession**を表す JSON オブジェクト。 

[PagingInfo (JSON)](json-paginginfo.md)

&nbsp;&nbsp;データのページで返される結果のページング情報が含まれています。

[PeopleList (JSON)](json-peoplelist.md)

&nbsp;&nbsp;[ユーザー](json-person.md)オブジェクトのコレクションです。

[PermissionCheckBatchRequest (JSON)](json-permissioncheckbatchrequest.md)

&nbsp;&nbsp;PermissionCheckBatchRequest オブジェクトのコレクションです。

[PermissionCheckBatchResponse (JSON)](json-permissioncheckbatchresponse.md)

&nbsp;&nbsp;バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。

[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)

&nbsp;&nbsp;バッチのアクセス許可の理由は、1 つのターゲット ユーザーのアクセス許可の値の一覧を確認します。

[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)

&nbsp;&nbsp;1 つのターゲットのユーザーからの 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。

[PermissionCheckResult (JSON)](json-permissioncheckresult.md)

&nbsp;&nbsp;1 つのターゲットのユーザーからの 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。

[ユーザー (JSON)](json-person.md)

&nbsp;&nbsp;People システムで 1 人のユーザーに関するメタデータ。

[PersonSummary (JSON)](json-personsummary.md)

&nbsp;&nbsp;[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。

[プレイヤー (JSON)](json-player.md)

&nbsp;&nbsp;ゲーム セッションにプレイヤーのデータが含まれています。

[Presencerecord を要求して (JSON)](json-presencerecord.md)

&nbsp;&nbsp;1 人のユーザーのオンライン プレゼンスに関するデータ。

[プロファイル (JSON)](json-profile.md)

&nbsp;&nbsp;ユーザーの個人用プロファイル設定します。

[進行状況 (JSON)](json-progression.md)

&nbsp;&nbsp;実績をロック解除に向けたユーザーの進行します。

[プロパティ (JSON)](json-property.md)

&nbsp;&nbsp;マッチメイ キング要求条件のクライアントによって提供されるプロパティのデータが含まれています。

[QueryClipsResponse (JSON)](json-queryclipsresponse.md)

&nbsp;&nbsp;一覧のページング情報と共にゲーム クリップの戻り値の一覧をラップします。

[quotaInfo (JSON)](json-quota.md)

&nbsp;&nbsp;クォータのタイトル グループについてを説明します。

[要件 (JSON)](json-requirement.md)

&nbsp;&nbsp;実績とそれらに対応するための距離、ユーザーがロック解除の条件。

[ResetReputation (JSON)](json-resetreputation.md)

&nbsp;&nbsp;ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。

[リワード (JSON)](json-reward.md)

&nbsp;&nbsp;実績に関連付けられたリワードです。

[RichPresenceRequest (JSON)](json-richpresencerequest.md)

&nbsp;&nbsp;リッチ プレゼンス情報の使用に関する情報を要求します。

[ServiceError (JSON)](json-serviceerror.md)

&nbsp;&nbsp;サービスに呼び出しが失敗したときに返されるエラーに関する情報が含まれています。

[ServiceErrorResponse (JSON)](json-serviceerrorresponse.md)

&nbsp;&nbsp;サービスのエラーが発生したとき、適切な HTTP エラー コードに戻ります。 必要に応じて、以下に定義されている、サービスは ServiceErrorResponse オブジェクトを含めるも可能性があります。 運用環境での低いデータが含まれているあります。

[SessionEntry (JSON)](json-sessionentry.md)

&nbsp;&nbsp;フィットネス セッションは、データが含まれています。

[TitleAssociation (JSON)](json-titleassociation.md)

&nbsp;&nbsp;実績に関連付けられているタイトルです。

[TitleBlob (JSON)](json-titleblob.md)

&nbsp;&nbsp;記憶域からのタイトルに関する情報が含まれています。

[TitleRecord (JSON)](json-titlerecord.md)

&nbsp;&nbsp;最終更新タイムスタンプとその名前を含む、タイトルに関する情報。

[TitleRequest (JSON)](json-titlerequest.md)

&nbsp;&nbsp;タイトルに関する情報を要求します。

[UpdateMetadataRequest (JSON)](json-updatemetadatarequest.md)

&nbsp;&nbsp;このメタデータは、クリップを更新する必要があります。

[ユーザー (JSON)](json-user.md)

&nbsp;&nbsp;ユーザーのランキング データが含まれています。

[UserClaims (JSON)](json-userclaims.md)

&nbsp;&nbsp;現在の認証されたユーザーに関する情報を返します。

[UserList (JSON)](json-userlist.md)

&nbsp;&nbsp;[ユーザー](json-user.md)オブジェクトのコレクションです。

[ユーザー (JSON)](json-usersettings.md)

&nbsp;&nbsp;現在の認証されたユーザーの設定を返します。

[ユーザーのタイトル (JSON)](json-usertitlev2.md)

&nbsp;&nbsp;ユーザーのタイトル データが含まれています。

[VerifyStringResult (JSON)](json-verifystringresult.md)

&nbsp;&nbsp;各文字列に[/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)提出に対応する結果コード。

[XuidList (JSON)](json-xuidlist.md)

&nbsp;&nbsp;操作を実行するに Xuid のリスト。
 
<a id="ID4ENH"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EPH"></a>

 
##### <a name="parent"></a>Parent 

[Xbox Live サービス RESTful リファレンス](../atoc-xboxlivews-reference.md)

  
<a id="ID4EZH"></a>

 
##### <a name="external-links-ecma-international-standard-262-ecmascript-language-specificationhttpwwwecma-internationalorgpublicationsfilesecma-stecma-262pdf"></a>外部リンク[ECMA 国際標準 262: ECMAScript 言語仕様](http://www.ecma-international.org/publications/files/ECMA-ST/ECMA-262.pdf)

   