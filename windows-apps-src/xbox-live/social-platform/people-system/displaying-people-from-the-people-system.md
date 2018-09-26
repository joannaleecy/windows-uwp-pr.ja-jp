---
title: People システムからの人物の表示
author: KevinAsgari
description: Xbox Live People システムを使ってユーザーを表示するコード フローについて説明します。
ms.assetid: c97b699f-ebc2-4f65-8043-e99cca8cbe0c
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: fc6fd23d9113c4d0e3dbac6d3cf0c880fc71d6a9
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4212933"
---
# <a name="display-people-from-the-people-system"></a>People システムからの人物の表示

Xbox Live を横断するサービスは、そのサービスが保有するデータのみを返し、ユーザーへの XUID 参照のみを返します。たとえば People サービスは、ユーザーの People リストに存在する XUID と、それらの各 XUID に関する一部のごく基本的な情報 (お気に入りの状態など) のみを保有し、また返します。 プレゼンス サービスは XUID のオンライン状態情報に関するデータを保有します。 ランキング サービスは XUID のリストのランキング情報を保有します。 表示名およびゲーマータグの情報はプロフィール サービス以外のどのサービスからも返されないので、エクスペリエンス内の人のリストを表示するには複数のサービスが必要です。

サービス API の一般的な呼び出しパターンでは、1 回目のラウンド トリップで、リストの最適なフィルター処理または並べ替えを実行できるサービスから XUID のリストを最初に取得します。次に、各 XUID に必要な追加のメタデータを取得するために必要な他のサービスに対して同時にラウンド トリップ呼び出しを行います。 画像の場合、画像の URL から画像を取得するために、3 回目のラウンド トリップ呼び出しが必要な場合があります。

ユーザーの People リストに関するデータの取得に必要なラウンド トリップ回数を減らすために、People *モニカー*が関連サービスに導入されつつあります。 この新しい機能により、呼び出し元は、ユーザーの People のリストを People サービスから取得すること、また、戻り値のスコープを設定するためにその XUID のセットを使用することをプライマリー サービスに対して抽象的に表明することができます。

以下に、タイトルで People 関連のサービスからデータを取得する方法を示す呼び出しフローのシナリオをいくつか例示します。

-   ゲームに参加中のユーザーのリスト
-   現在のユーザーの People に含まれるオンライン ユーザーのリスト
-   ランダムなユーザーを含むグローバル ランキング
-   ユーザーの People のランキング


## <a name="list-of-users-currently-in-game"></a>ゲームに参加中のユーザーのリスト

| タイトルが保持しているもの  | 目標  | 表示するフィールド  | 呼び出しフロー
|-------------------------------------------------|----------------------------------------------------|--------------------|--------------------------------------|
| ゲームに参加している他のユーザーのランダムな XUID のリスト | 他の各ユーザーについて最小限の情報を表示する | GameDisplayName  \[プロフィール\] | XUID のリストを使用してプロフィールを呼び出す。 |


## <a name="list-of-the-current-users-people-who-are-online"></a>現在のユーザーの People に含まれるオンライン ユーザーのリスト

## <a name="title-has"></a>タイトルが保持しているもの:
現在のユーザーの XUID

## <a name="goal"></a>目標
現在のユーザーの People リストに含まれているオンライン ユーザーのリッチ リストを表示する

## <a name="field-to-render-owning-service"></a>表示するフィールド \[保有するサービス\]
* お気に入りインジケーター [People]
* 表示用画像 [プロフィール]
* GameDisplayName [プロフィール]
* 基本オンライン状態 (緑のボール) [プレゼンス]

## <a name="call-flow"></a>呼び出しフロー
1. People モニカーを渡してプレゼンスを呼び出し、ユーザーの People に含まれる各ユーザーの XUID とオンライン状態を取得する。
1. 並行して:
 1. XUID のリスト全体を渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。
 1. XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。
1. プロフィールの呼び出し後:
 1. 各画像 URL の画像を取得する。

## <a name="global-leaderboard-containing-random-users"></a>ランダムなユーザーを含むグローバル ランキング

## <a name="title-has"></a>タイトルが保持しているもの:
ランキングの ID/名前

## <a name="goal"></a>目標
ランキング上の各ユーザーの基本情報を表示する

## <a name="field-to-render-owning-service"></a>表示するフィールド [保有するサービス]
* お気に入りインジケーター [People]
* GameDisplayName [プロフィール]
* ランク [ランキング]
* スコア [ランキング]

## <a name="call-flow"></a>呼び出しフロー
1. ランキングを呼び出して特定のランキングの XUID、ランク、スコアを取得する。
1. 並行して:
 1. XUID のリストを渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。
 1. XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。

## <a name="leaderboard-of-users-people"></a>ユーザーの People のランキング

## <a name="title-has"></a>タイトルが保持しているもの:
* ランキングの ID/名前
* 現在のユーザーの XUID

## <a name="goal"></a>目標
ランキング上の各ユーザーの基本情報を表示する

## <a name="field-to-render-owning-service"></a>表示するフィールド [保有するサービス]
* お気に入りインジケーター [People]
* GameDisplayName [プロフィール]
* ランク [ランキング]
* スコア [ランキング]

## <a name="call-flow"></a>呼び出しフロー
1. People モニカーを渡してランキングを呼び出し、ユーザーの People リストに限定した特定のランキングの XUID、ランク、スコアを取得する。
1. 並行して:
 1. XUID のリストを渡してプロフィールを呼び出し、各ユーザーの表示名と画像 URL を取得する。
 1. XUID のリストを渡して People を呼び出し、ユーザーのお気に入りがいるかどうか調べる。
