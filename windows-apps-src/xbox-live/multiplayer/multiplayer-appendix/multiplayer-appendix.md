---
title: マルチプレイヤーの付録
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 サービスの詳細情報へのリンクがあります。
ms.assetid: 412ae5f4-6975-4a8b-9cc2-9747e093ec4d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 051a81f68440b293d7198dcdd68479cf3f28e22a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5549934"
---
# <a name="multiplayer-appendix"></a>マルチプレイヤーの付録

Xbox One のマルチプレイヤー システムにより、ゲーム プレイやゲーム プレイヤーをグループにまとめることができます。 このシステムは、安全で、使いやすく、柔軟であるため、シンプルな機能をすばやく作成できるだけでなく、さらに複雑な機能を作成し、独自のサービスを組み込むこともできます。

> **注意**  
ここでは、API の高度な使用方法を示します。  まず最初に、開発が大幅に簡素化される [Multiplayer Manager API](../multiplayer-manager.md) を参照してください。  Multiplayer Manager でサポートされていないシナリオが見つかった場合は、担当の DAM までご連絡ください。

マルチプレイヤー システムの現在のバージョンは 2015 マルチプレイヤーです。 このバージョンは、"ゲーム パーティー" の概念を抽象化し、マルチプレイヤー セッション ディレクトリ (MPSD) を使用してゲーム セッションを制御します。

> **注意**  
マルチプレイヤー システムの以前のバージョンは 2014 マルチプレイヤーです。 このバージョンは、ゲーム パーティーの概念およびパーティーを通じてのゲームへの参加に基づいています。 このバージョンは、ソース コードが XDK で提供されていますが、現在は非推奨となっています。 2014 マルチプレイヤーのマニュアルは、XDK に付属しなくなりました。 このドキュメントを使用する場合は、2014 年のリリースの XDK を使用してください。


## <a name="in-this-section"></a>このセクションの内容

[概要](introduction-to-the-multiplayer-system.md)  
マルチプレイヤー システムについて説明します。

[マルチプレイヤー セッション ディレクトリ (MPSD)](multiplayer-session-directory.md)  
すべてのタイトルにわたってゲームのマルチプレイヤー API メタデータを一元化し、ゲーム セッションを管理するマルチプレイヤー セッション ディレクトリ (MPSD) について説明します。

[MPSD セッションの詳細](mpsd-session-details.md)  
MPSD セッションの詳細について説明します。

[タイトルを 2015 マルチプレイヤーに適合させるときの一般的な問題](common-issues-when-adapting-multiplayer.md)  
2015 マルチプレイヤーで動作するようにタイトルを適合させるときに考慮する一般的な問題について説明します。

[SmartMatch マッチメイキング](smartmatch-matchmaking.md)  
Xbox Live によって使用されるマッチメイキング システムについて説明します。

[アービターの移行](migrating-an-arbiter.md)  
MPSD のアービター移行プロセスについて説明します。

[SmartMatch マッチメイキングの使用](using-smartmatch-matchmaking.md)  
SmartMatch マッチメイキングを使用する方法について説明します。

[マルチプレイヤーの実行方法](multiplayer-how-tos.md)  
タイトルで 2015 マルチプレイヤーを使用するための手順を説明します。

[マルチプレイヤー セッション ステータス コード](multiplayer-session-status-codes.md)  
Xbox One のマルチプレイヤー セッション ステータス コードを定義します。

[2015 マルチプレイヤーの FAQ とトラブルシューティング](multiplayer-2015-faq.md)  
マルチプレイヤーの FAQ とトラブルシューティングを定義します。

[Xbox One マルチプレイヤー セッション ディレクトリ](xbox-one-multiplayer-session-directory.md): 新しい Xbox One マルチプレイヤー セッション ディレクトリ (MPSD) サービスを使用するマルチプレイヤー セッション作成の概要を示します。

[マルチプレイヤー ゲームへの招待に関するフロー](flows-for-multiplayer-game-invites.md): 別のプレイヤーをマルチプレイヤー ゲームに招待する際に伴うエクスペリエンスのフローを説明します。

[ゲーム セッションおよびゲーム パーティーの可視性と参加可能性](game-session-and-game-party-visibility-and-joinability.md): マルチプレイヤー ゲーム セッションに関連する可視性と参加可能性の相違点を説明します。
