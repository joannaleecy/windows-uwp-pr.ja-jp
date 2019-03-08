---
title: XDK プロジェクトの認証
description: Xbox 開発キット (XDK) タイトルで Xbox Live ユーザーをサインインする方法について説明します。
ms.assetid: 713bb2e3-80c5-4ac9-8697-257525f243d3
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 597b3becfa2083955d8bd4e0adc91e4ae9b827a1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613497"
---
# <a name="authentication-for-xdk-projects"></a>XDK プロジェクトの認証

ゲームで Xbox Live の機能を利用するために、ユーザーは Xbox Live プロフィールを作成し、Xbox Live コミュニティで自らの身元を明らかにする必要があります。  Xbox Live サービスは、ユーザーの Xbox Live プロフィール (ユーザーのゲーマータグやゲーマーアイコン、ユーザーが一緒にゲームをするフレンド、ユーザーがプレイしたゲーム、ユーザーがロック解除した実績、特定のゲームにおけるユーザーのランキング順位など) を使用してゲーム関連のアクティビティを追跡します。

大まかには、以下の手順に従って Xbox Live API を使用します。
1. 対話しているユーザーを識別する
2. ユーザーに基づいて Xbox Live コンテキストを作成する
3. 作成した Xbox Live コンテキストを使用して Xbox Live サービスにアクセスする
4. ゲームが終了またはユーザーがサインアウトしたら、XboxLiveContext オブジェクトを null に設定して解放する

### <a name="creating-an-xboxliveuser-object"></a>XboxLiveUser オブジェクトの作成
ほとんどの Xbox Live アクティビティは Xbox Live ユーザーに関連します。  ゲーム デベロッパーは、まずローカル ユーザーを表す XboxLiveUser オブジェクトを作成する必要があります。

C++:
```
Windows::Xbox::System::User^ user; // the interacting user.  From User::Users, etc
std::shared_ptr<xbox::services::xbox_live_context> xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>( user );
```

WinRT:
```
Windows::Xbox::System::User^ user; // the interacting user.  From User::Users, etc
Microsoft::Xbox::Services::XboxLiveContext^ xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext( user );
```
