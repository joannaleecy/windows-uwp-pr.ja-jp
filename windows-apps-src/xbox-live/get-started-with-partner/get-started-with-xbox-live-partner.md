---
title: Get started with Xbox Live as a partner
author: KevinAsgari
description: Provides links to help a managed partner or ID@Xbox member get started with Xbox Live development.
ms.assetid: 69ab75d1-c0e7-4bad-bf8f-5df5cfce13d5
ms.author: kevinasg
ms.date: 06-07-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, partner, ID@Xbox
ms.openlocfilehash: c39f0dfd07fd3e5d932c11391e58194268b64e6e
ms.sourcegitcommit: 2aa04e1ef925a6c2025b9ec2edc1d784d02eb94e
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2017
---
# <a name="get-started-with-xbox-live-as-a-managed-partner-or-an-idxbox-developer"></a>対象パートナーまたは ID@Xbox 開発者として Xbox Live の利用を開始する

This section covers getting started with Xbox Live as a managed partner or as an ID@Xbox developer. Partners and ID developers can access the full range of Xbox Live features, including achievements, multiplayer, and more.

Managed partners and ID@Xbox developers can develop Xbox Live titles for both the Universal Windows Platform (UWP) or the Xbox Developer Kit (XDK) platform.

In addition to the content available here, there is also additional documentation that is available to partners with an authorized Dev Center account. You can access that content here: [Xbox Live partner content](https://developer.microsoft.com/en-us/games/xbox/docs/xboxlive/xbox-live-partners/partner-content).

## <a name="why-should-you-use-xbox-live"></a>Why should you use Xbox Live?

Xbox Live offers an array of features designed to help promote your game and keep gamers engaged:

- Xbox Live social platform lets gamers connect with friends and talk about your game.
- Xbox Live achievements helps your game get popular by giving your game free promotion to the Xbox Live social graph when gamers unlock achievements.
- Xbox Live leaderboards helps drive engagement of your game by letting gamers compete to beat their friends and move up the ranks.
- Xbox Live multiplayer lets gamers play with their friends or a get matched with other players to compete or cooperate in your game.
- Xbox Live connected storage offers free save game roaming between devices so gamers can easily continue game progress between Xbox One and Windows PC.

## <a name="1-choose-a-platform"></a>1. プラットフォームを選択する
Xbox 開発キット (XDK)、ユニバーサル Windows プラットフォーム (UWP)、またはクロスプレイ ゲームのどれを作成するかを決定します。

- XDK ベースのゲームは Xbox One 本体でのみ動作します。
- UWP games can target any Windows platform such as Windows PC, Windows Phone, or Xbox One
  - For Xbox One, see [UWP on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/index) and specifically [System resources for UWP apps and games on Xbox One](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/system-resource-allocation)
- クロスプレイ ゲームは、通常、XDK と UWP の両方のパスを使用する Xbox One と Windows PC を対象とするゲームです。

## <a name="2-ensure-that-you-have-a-title-created-on-dev-center-or-xdp"></a>2. デベロッパー センターまたは XDP でタイトルが作成されていることを確認する
Every Xbox Live title must be defined on Dev Center or the Xbox Developer Portal (XDP) before you will be able to sign-in and make Xbox Live Service calls.  これを行う方法は、「[新しいタイトルの作成](create-a-new-title.md)」で説明します。

## <a name="3-follow-the-appropriate-guide-to-setup-your-ide-or-game-engine"></a>3. 適切なガイドに従って IDE やゲーム エンジンをセットアップする
You can follow the appropriate Getting Started guide for your platform and engine and learn the basics of Xbox Live as you go along.

* [Getting started using Visual Studio for UWP games](get-started-with-visual-studio-and-uwp.md) will show you how to link your Visual Studio project with your Xbox Live configuration on Dev Center.
* [Getting started using Unity for UWP games](partner-add-xbox-live-to-unity-uwp.md) will show you how to create a new Xbox Live enabled Unity title, add features such as Leaderboards to your title, and generate a native Visual Studio project.
* [Getting started using Visual Studio for XDK based games](xdk-developers.md) will show you how to get your Visual Studio project setup if you are making an Xbox One title using the XDK.
* [Getting started making a cross-play game](get-started-with-cross-play-games.md) explains how to make a product that is an XDK based game for Xbox One and a UWP based game for Windows 10 PC.

## <a name="4-xbox-live-concepts"></a>4. Xbox Live の概念
タイトルを作成したら、タイトルの開発エクスペリエンスに影響を与える Xbox Live の概念について理解する必要があります。

- [Xbox Live のサンドボックス](../xbox-live-sandboxes.md)
- [Xbox Live test accounts](../xbox-live-test-accounts.md)
- [Introduction to Xbox Live APIs](../introduction-to-xbox-live-apis.md)

## <a name="5-add-xbox-live-features"></a>5. Add Xbox Live Features

Add Xbox Live features to your game:

- [Xbox Live Social Platform - Profile, Friends, Presence](../social-platform/social-platform.md)
- [Xbox Live Data Platform - Stats, Leaderboards, Achievements](../data-platform/data-platform.md)
- [Xbox Live Multiplayer Platform - Invite, Matchmaking, Tournaments](../multiplayer/multiplayer-intro.md)
- [Xbox Live Storage Platform - Connected Storage, Title Storage](../storage-platform/storage-platform.md)
- [Contextual Search](../contextual-search/introduction-to-contextual-search.md)

## <a name="6-release-your-title"></a>6. タイトルをリリースする

ID@Xbox および対象パートナーは、タイトルをリリースする前に認定プロセスに合格する必要があります。  この理由は、タイトルがオンライン マルチプレイヤー、実績、リッチ プレゼンスなどの追加機能にアクセスする場合があるためです。  タイトルをリリースする準備ができたら、Microsoft の担当者に申請とリリースのプロセスに関する詳細をお問い合わせください。
