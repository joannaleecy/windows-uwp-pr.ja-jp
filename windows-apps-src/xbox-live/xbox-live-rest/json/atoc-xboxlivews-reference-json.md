---
title: JavaScript Object Notation (JSON) オブジェクト リファレンス
assetID: 8efcc6f3-d88a-1b15-bcfc-d79a24581b0a
permalink: en-us/docs/xboxlive/rest/atoc-xboxlivews-reference-json.html
description: " JavaScript Object Notation (JSON) オブジェクト リファレンス"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c46557e3fb837bebccbb1039fb416f3e9787af2a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57626557"
---
# <a name="javascript-object-notation-json-object-reference"></a>JavaScript Object Notation (JSON) オブジェクト リファレンス
 
JavaScript Object Notation (JSON) は、web 上のデータをカプセル化するための軽量な標準ベースのオブジェクト指向の表記です。
 
Xbox Live サービスは、要求と、サービスからの応答で使用される JSON オブジェクトを定義します。 このセクションでは、Xbox Live サービスで使用される各 JSON オブジェクトに関するリファレンス情報を提供します。
 
<a id="ID4EHB"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[アチーブメントが獲得されました (JSON)](json-achievementv2.md)

&nbsp;&nbsp;アチーブメント オブジェクト (バージョン 2)。

[ActivityRecord (JSON)](json-activityrecord.md)

&nbsp;&nbsp;1 つまたは複数のユーザーのプレゼンスの書式設定とローカライズされた文字列。

[ActivityRequest (JSON)](json-activityrequest.md)

&nbsp;&nbsp;1 つまたは複数のユーザーのプレゼンス情報の要求。

[AggregateSessionsResponse (JSON)](json-aggregatesessionsresponse.md)

&nbsp;&nbsp;ユーザーのフィットネス セッションの集計データが含まれています。

[BatchRequest (JSON)](json-batchrequest.md)

&nbsp;&nbsp;ユーザー、デバイス、およびタイトルなどのプレゼンス情報をフィルター処理に使用するプロパティの配列。

[DeviceEndpoint (JSON)](json-deviceendpoint.md)

[DeviceRecord (JSON)](json-devicerecord.md)

&nbsp;&nbsp;その型およびその上でアクティブなタイトルを含む、デバイスに関する情報。

[フィードバック (JSON)](json-feedback.md)

&nbsp;&nbsp;プレーヤーのフィードバックについてを説明します。

[ゲームのクリップだった (JSON)](json-gameclip.md)

[GameClipsServiceErrorResponse (JSON)](json-gameclipsserviceerrorresponse.md)

&nbsp;&nbsp;/Users/{ownerId} {scid}/scids//clips/{gameClipId} への応答のオプションの一部と uri の形式/{gameClipUriType} API。

[GameClipThumbnail (JSON)](json-gameclipthumbnail.md)

&nbsp;&nbsp;個々 のサムネイルに関連する情報が含まれています。 1 つのクリップ、複数のサイズがあり、表示するための適切な 1 つを選択するクライアントの責任です。

[GameClipUri (JSON)](json-gameclipuri.md)

[GameMessage (JSON)](json-gamemessage.md)

&nbsp;&nbsp;ゲーム セッションのメッセージ キューでメッセージのデータを定義する JSON オブジェクト。

[GameResult (JSON)](json-gameresult.md)

&nbsp;&nbsp;ゲーム セッションの結果を説明するデータを表す JSON オブジェクトです。

[GameSession (JSON)](json-gamesession.md)

&nbsp;&nbsp;マルチ プレーヤーのセッションのゲーム データを表す JSON オブジェクトです。

[GameSessionSummary (JSON)](json-gamesessionsummary.md)

&nbsp;&nbsp;ゲーム セッションの集計データを表す JSON オブジェクトです。

[GetClipResponse (JSON)](json-getclipresponse.md)

&nbsp;&nbsp;ゲームのクリップをラップします。

[HopperStatsResults (JSON)](json-hopperstatsresults.md)

&nbsp;&nbsp;Hopper の統計情報を表す JSON オブジェクトです。

[InitialUploadRequest (JSON)](json-initialuploadrequest.md)

&nbsp;&nbsp;要求の POST ゲームのクリップだったの本文にアップロードします。

[InitialUploadResponse (JSON)](json-initialuploadresponse.md)

[inventoryItem (JSON)](json-inventoryitem.md)

&nbsp;&nbsp;Core の在庫品目は、権利を許可できる標準の項目を表します。

[LastSeenRecord (JSON)](json-lastseenrecord.md)

&nbsp;&nbsp;システムが最終ユーザー、ユーザーが有効な DeviceRecord を持たないときに使用できるを見た場合について説明します。

[MatchTicket (JSON)](json-matchticket.md)

&nbsp;&nbsp;一致するチケット、プレイヤー、マルチ プレーヤーのセッション ディレクトリ (MPSD) を介して他のプレーヤーを見つけたりするために使用を表す JSON オブジェクトです。

[MediaAsset (JSON)](json-mediaasset.md)

&nbsp;&nbsp;実績またはその報酬に関連付けられたメディア資産。

[MediaRecord (JSON)](json-mediarecord.md)

[MediaRequest (JSON)](json-mediarequest.md)

[MultiplayerActivityDetails (JSON)](json-multiplayeractivitydetails.md)

&nbsp;&nbsp;表す JSON オブジェクト、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**します。

[MultiplayerSessionReference (JSON)](json-multiplayersessionreference.md)

&nbsp;&nbsp;表す JSON オブジェクト、 **MultiplayerSessionReference**します。 

[MultiplayerSessionRequest (JSON)](json-multiplayersessionrequest.md)

&nbsp;&nbsp;操作の要求の JSON オブジェクトが渡される、 **MultiplayerSession**オブジェクト。

[MultiplayerSession (JSON)](json-multiplayersession.md)

&nbsp;&nbsp;表す JSON オブジェクト、 **MultiplayerSession**します。 

[PagingInfo (JSON)](json-paginginfo.md)

&nbsp;&nbsp;ページのデータで返される結果のページング情報が含まれています。

[PeopleList (JSON)](json-peoplelist.md)

&nbsp;&nbsp;コレクション[Person](json-person.md)オブジェクト。

[PermissionCheckBatchRequest (JSON)](json-permissioncheckbatchrequest.md)

&nbsp;&nbsp;PermissionCheckBatchRequest オブジェクトのコレクション。

[PermissionCheckBatchResponse (JSON)](json-permissioncheckbatchresponse.md)

&nbsp;&nbsp;バッチのアクセス許可の結果は、複数のユーザーのアクセス許可の値の一覧を確認します。

[PermissionCheckBatchUserResponse (JSON)](json-permissioncheckbatchuserresponse.md)

&nbsp;&nbsp;バッチのアクセス許可の理由は、1 つのターゲット ユーザーのアクセス許可の値の一覧を確認します。

[PermissionCheckResponse (JSON)](json-permissioncheckresponse.md)

&nbsp;&nbsp;1 つのターゲット ユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。

[PermissionCheckResult (JSON)](json-permissioncheckresult.md)

&nbsp;&nbsp;1 つのターゲット ユーザーに対して 1 つのアクセス許可の設定の 1 人のユーザーからのチェックの結果。

[Person (JSON)](json-person.md)

&nbsp;&nbsp;ユーザーのシステムで 1 人のユーザーに関するメタデータ。

[PersonSummary (JSON)](json-personsummary.md)

&nbsp;&nbsp;コレクション[人 (JSON)](json-person.md)オブジェクト。

[プレーヤー (JSON)](json-player.md)

&nbsp;&nbsp;プレーヤーのゲームのセッションでデータを格納します。

[PresenceRecord (JSON)](json-presencerecord.md)

&nbsp;&nbsp;1 人のユーザーのオンラインかどうかに関するデータ。

[プロファイル (JSON)](json-profile.md)

&nbsp;&nbsp;ユーザーの個人プロファイルの設定。

[進行状況 (JSON)](json-progression.md)

&nbsp;&nbsp;ユーザーの行程アチーブメントのロックを解除します。

[プロパティ (JSON)](json-property.md)

&nbsp;&nbsp;マッチメイ キング要求条件、クライアントによって提供されるプロパティのデータが含まれています。

[QueryClipsResponse (JSON)](json-queryclipsresponse.md)

&nbsp;&nbsp;ゲームの一覧のページング情報と共にクリップの戻り値の一覧をラップします。

[quotaInfo (JSON)](json-quota.md)

&nbsp;&nbsp;タイトルのグループのクォータについてを説明します。

[要件 (JSON)](json-requirement.md)

&nbsp;&nbsp;実績とそれらに対応するため、ユーザーは、どの程度のロック解除の条件。

[ResetReputation (JSON)](json-resetreputation.md)

&nbsp;&nbsp;ユーザーの既存のスコアを変更する必要があります新しい基本評価スコアが含まれています。

[Reward (JSON)](json-reward.md)

&nbsp;&nbsp;実績に関連付けられている特典です。

[RichPresenceRequest (JSON)](json-richpresencerequest.md)

&nbsp;&nbsp;豊富なプレゼンス情報の使用についての情報を要求します。

[サービス エラー (JSON)](json-serviceerror.md)

&nbsp;&nbsp;サービスへの呼び出しが失敗したときに返されるエラーについてを説明します。

[ServiceErrorResponse (JSON)](json-serviceerrorresponse.md)

&nbsp;&nbsp;サービスのエラーが発生した場合に適切な HTTP エラー コードが返されます。 必要に応じて、以下に定義されている、サービスは ServiceErrorResponse オブジェクトを含めることもできます。 運用環境での低いデータを含めることができます。

[SessionEntry (JSON)](json-sessionentry.md)

&nbsp;&nbsp;フィットネス セッションにはデータが含まれます。

[TitleAssociation (JSON)](json-titleassociation.md)

&nbsp;&nbsp;実績に関連付けられているタイトルです。

[TitleBlob (JSON)](json-titleblob.md)

&nbsp;&nbsp;ストレージから、タイトルに関する情報が含まれています。

[TitleRecord (JSON)](json-titlerecord.md)

&nbsp;&nbsp;タイトル、名前、最終変更タイムスタンプなどについて説明します。

[TitleRequest (JSON)](json-titlerequest.md)

&nbsp;&nbsp;タイトルに関する情報を要求します。

[UpdateMetadataRequest (JSON)](json-updatemetadatarequest.md)

&nbsp;&nbsp;このメタデータは、クリップを更新する必要があります。

[ユーザー (JSON)](json-user.md)

&nbsp;&nbsp;ユーザーのランキング データが含まれています。

[UserClaims (JSON)](json-userclaims.md)

&nbsp;&nbsp;現在の認証済みユーザーに関する情報を返します。

[UserList (JSON)](json-userlist.md)

&nbsp;&nbsp;コレクション[ユーザー](json-user.md)オブジェクト。

[UserSettings (JSON)](json-usersettings.md)

&nbsp;&nbsp;現在の認証済みユーザーの設定を返します。

[ユーザーのタイトル (JSON)](json-usertitlev2.md)

&nbsp;&nbsp;ユーザーのタイトルのデータが含まれています。

[VerifyStringResult (JSON)](json-verifystringresult.md)

&nbsp;&nbsp;送信された各文字列に対応するコードを結果[/system/strings/validate](../uri/stringserver/uri-systemstringsvalidate.md)します。

[XuidList (JSON)](json-xuidlist.md)

&nbsp;&nbsp;操作を実行する Xuid の一覧です。
 
<a id="ID4ENH"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EPH"></a>

 
##### <a name="parent"></a>Parent 

[Xbox Live Services RESTful のリファレンス](../atoc-xboxlivews-reference.md)

  
<a id="ID4EZH"></a>

 
##### <a name="external-links-ecma-international-standard-262-ecmascript-language-specificationhttpswwwecma-internationalorgpublicationsfilesecma-stecma-262pdf"></a>外部リンク[ECMA International Standard 262。ECMAScript 言語仕様](https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-262.pdf)

   