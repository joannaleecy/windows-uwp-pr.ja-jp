---
title: "Unity でユーザー特権の設定を確認する"
author: StaceyHaffner
description: "ログイン済みの Xbox Live アカウントに設定された特権の確認方法を説明します。"
ms.assetid: 
ms.author: sthaff
ms.date: 10/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP. Windows 10, Xbox One, アカウント, テスト アカウント, 保護者による制限, ユーザー特権, Enforcement チームによる禁止, アップセル"
ms.openlocfilehash: 45c5785899dcdda596fe66bb76930a781d50b77d
ms.sourcegitcommit: d5f74029f9844603914e8e46a8d4dfe078c2a90a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2017
---
# <a name="check-user-privilege-settings-in-unity"></a>Unity でユーザー特権の設定を確認する
Xbox Live では、すべての認証済みユーザーのアカウントに特権が関連付けられています。 特権によって、任意の時点でユーザーがアクセスできる Xbox Live の機能が制御されます。 システムで制御される機能に関する特権もあれば、特定のゲームやサブスクリプション レベルでのみ利用できる特権もあります。 さらに、保護者による制限や Xbox Live Enforcement チームによる禁止措置によって、ユーザー特権が制限されることもあります。 これらの特権は、マルチプレイヤー、ユーザー作成コンテンツへのアクセス、チャット、ストリーミング ビデオなど、数多くの一般的なシナリオを対象としています。 ゲームでは、この情報を使用してアクセス制御とカスタマイズの判断を行います。 

## <a name="prerequisites"></a>前提条件
ユーザー特権の設定を判断するには、Xbox Live での認証に対応するようにゲームを構成し、ユーザーのサインインを適切に処理する必要があります。 これらの手順の概要は、次の記事で説明されています。

* [Unity で Xbox Live を構成する](check-user-privileges-in-unity.md)
* [Unity で Xbox Live にサインインする](sign-in-to-xbox-live-in-unity.md)

## <a name="determine-privileges"></a>特権の判断
ユーザーの特権は、認証時に受け取るトークンによって伝達されます。 Unity では、ユーザーが正常にサインインした後、ユーザーが持つ特権の一覧に `XboxLiveUser` クラスでアクセスできます。 特権は、スペースで区切られた 1 つの文字列として保存されています。 たとえば、ユーザーには、次のような形式で特権が設定されています。

```csharp
public XboxLiveUserInfo XboxLiveUser;

//sign in is done and the user has been successfully signed in

Debug.Log(XboxLiveUser.User.Privileges);

//Console would read:
// Privileges: "188 191 192 193 194 195 196 198 199 200 201 203 204 205 206 207 208 211 214 215 216 217 220 224 227 228 235 238 245 247 249 252 254 255"
```

特定のアクセス許可について判断する場合は、`Privileges` プロパティにそれに関連するコードが含まれているかどうかを確認します。

```csharp
public XboxLiveUserInfo XboxLiveUser;

//sign in is done and the user has been successfully signed in

if (XboxLiveUser.User.Privileges.Contains("247"))
{
    Debug.Log("User has the user_created_content privilege");
}
```

## <a name="privilege-codes"></a>特権コード
次の一覧に、返される特権コードを示します。

| コード  | 特権  | 説明   |
|------ |-----------------------------  |-------------------    |
| 190   | broadcast             | ライブ ゲームプレイを配信できます。     |
| 197   | view_friends_list     | 他のユーザーのフレンド リストを表示できます。   |
| 198   | game_dvr              | 記録したゲーム内ビデオをクラウドにアップロードできます。      |
| 199   | share_kinect_content          | Kinect で記録されたコンテンツをクラウドにアップロードして、だれでもアクセスできるように提供できます。 |
| 203   | multiplayer_parties           | パーティー セッションに参加できます。     |
| 205   | communication_voice_ingame    | パーティー時およびマルチプレイヤー ゲーム セッション時にボイス チャットに参加できます。    |
| 206   | communication_voice_skype     | Xbox One 上で Skype を使って音声によるコミュニケーションができます。   |
| 207   | cloud_gaming_manage_session   | ホストされたゲーム セッション用にクラウド コンピューティング クラスターを割り当てて管理できます。    |
| 208   | cloud_gaming_join_session     | クラウド コンピューティング セッションに参加できます。     |
| 209   | cloud_saved_games     | クラウド タイトル ストレージにゲームを保存できます。    |
| 211   | share_content     | 他のユーザーにコンテンツを公開できます。    |
| 214   | premium_content   | Xbox Live ゴールド サブスクリプションで提供されている有料コンテンツを購入、ダウンロード、起動できます。     |
| 219   | subscription_content  | プレミアム サブスクリプション コンテンツを購入およびダウンロードしたり、プレミアム サブスクリプション機能を利用したりできます。     |
| 220   | social_network_sharing    | 進行状況の情報をソーシャル ネットワーク上で公開できます。    |
| 224   | premium_video     | プレミアム ビデオ サービスにアクセスできます。    |
| 235   | purchase_content  | コンテンツを購入できます。     |
| 247   | user_created_content  | オンラインのユーザー作成コンテンツをダウンロードおよび表示できます。    |
| 249   | profile_viewing   | 他のユーザーのプロフィールを表示できます。   |
| 252   | communications    | だれとでもテキスト メッセージングを利用できます。    |
| 254   | multiplayer_sessions  | ゲームのマルチプレイヤー セッションに参加できます。   |
| 255   | add_friend    | 他の Xbox Live ユーザーをフォローでき、Xbox Live フレンドを追加できます。   |
 
