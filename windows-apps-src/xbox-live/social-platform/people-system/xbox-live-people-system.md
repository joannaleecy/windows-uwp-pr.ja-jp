---
title: "Xbox Live People システム"
author: KevinAsgari
description: "Xbox Live People システムについて説明します。"
ms.assetid: f1881a52-8e65-4364-9937-d2b8b8476cbf
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, ソーシャル, People システム, フレンド"
ms.openlocfilehash: bddafe769bd00d311df0a54aac0bdc13638f1c3f
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="xbox-live-people-system"></a>Xbox Live People システム

Xbox One のリリースから、Xbox Live は、Xbox Live のソーシャル ファブリックを発展するために、以前の Xbox 360 _フレンド_ システムから新しい _People_ システムに移行しています。 People システムの目的は次のとおりです。

- ユーザーが自分の知っている人物を見つけやすくします。

  すべてのエクスペリエンスで実名を使用できます。実名は、匿名ではない対話関係を築くための基礎となります。

- 既存の Xbox Live の関係を Xbox One に移行します。

  Xbox 360 で追加したフレンドを持つユーザーは、最新のエクスペリエンスを使用するときにリストがリセットされません。

- ゲーマータグによる匿名の関係も引き続きサポートします。

  マッチメイキング サービスによって作成されたマッチからのすばらしいゲームプレイ セッションの後、ユーザーはその人を自分のユーザー リストに追加し、後で簡単にアクセスできます。

- 長いユーザー リストを簡便な方法で管理できるようにします。

  ユーザーは人々をお気に入りとしてマークして、Xbox One エクスペリエンスでそれらの人々を最初に表示できます。

- Xbox Live のプライバシー システムを進化させて、ユーザーが信頼する実世界の関係により多くの権利を与え、匿名 (ゲーマータグのみ) の関係に与える権利を減らすことができるようにします。
- 下位互換性を確保します。

  従来のクライアントおよび従来のサービス コードは、新しいシステムに移行しなくても、引き続き以前のソーシャル インフラストラクチャに対する処理を実行します。

## <a name="identity-and-display-of-real-names-on-xbox-one"></a>Xbox One での実名の識別と表示
Xbox One 上のユーザーは Microsoft アカウント ID で認証されます。 ユーザーが自分の Microsoft アカウントを使用して本体にサインインすると、シェル全体を通じて、そのユーザーに関連付けられている名前と画像が表示されます。 ユーザーは、実名を提供する外部のソーシャル ネットワークに Xbox Live のプロフィールをリンクしていない場合、システムではゲーマータグとゲーマーアイコンによって表されます (そして、以前の Xbox Live ゲーマータグによる関係は Xbox One に移行されます)。

外部ネットワークにリンクすることが推奨されますが、必須ではありません。 ユーザーがプロフィールを外部のソーシャル ネットワークにリンクしているときに、そのネットワークの他のフレンドが Xbox Live アカウントを持っていてプロフィールもリンクしている場合、フレンドは本体では Microsoft アカウント名と画像によって、外部ネットワークで接続を共有するフレンドに対して表されます。 一方、この方法で接続されているユーザーは、外部ネットワークで接続されていない人々に対しては、引き続きゲーマータグとゲーマーアイコンで表されます。

このセクションの後のトピックでは、これらの関係について説明します。 関連する API については、「**Microsoft.Xbox.Services.Social 名前空間**」を参照してください。

## <a name="in-this-section"></a>このセクションの内容
[一方向の関係](one-way-relationships.md)  
Xbox Live People システムの一方向関係モデルについて説明します。

[People システムでのゲーマータグと実名](gamertags-and-real-names.md)  
Xbox Live People システムは、知り合いのユーザーに対しては実名の表示が可能なように設計されています。これは、新しい Xbox Live エクスペリエンスではどの場所でもコンテキストにかかわらず一貫して可能であり、FPS オンライン ゲームでキャラクターがマップ上を走り回っているときの頭上にも表示できます。

[お気に入りユーザー](favorite-people.md)  
Xbox Live People システムでのお気に入り。

[People システムからの人物の表示](displaying-people-from-the-people-system.md)  
Xbox Live People システムから返される人を表示する方法。

[Xbox 360 フレンドの下位互換性](xbox-360-friends-backward-compatibility.md)  
新しい Xbox Live People システムでの Xbox 360 のフレンドの取り扱い方法について説明します。

[プライバシーと知り合いのユーザー](privacy-and-people-i-know.md)  
People システムでプライバシーを保護します。

[評判](reputation.md)  
評判システムを使用してプレイヤーのユーザー レポートを集計し、Xbox のサービスで高品質のゲームプレイと行動への動機付けを提供できるようにする方法について説明します。

[タイトルからのプレイヤー フィードバックの送信](sending-player-feedback-from-your-title.md)  
タイトルがどのように、ユーザーの評判に影響を与えるフィードバックを提供する助けとなるかを説明します。

[Xbox Live ソーシャル サービスのプログラミング](programming-social-services.md)  
Xbox Live で提供されるソーシャル サービスの使用方法について説明します。
