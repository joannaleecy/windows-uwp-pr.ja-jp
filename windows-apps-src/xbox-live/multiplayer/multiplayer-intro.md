---
title: Xbox Live Multiplayer Platform
author: KevinAsgari
description: Learn about the multiplayer platforms that are support by Xbox Live.
ms.assetid: 958b94b3-dccd-479a-bf52-54f7ff1656fa
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, multiplayer
ms.openlocfilehash: fd6e9935153dd6531bc2a639d366f5027708d398
ms.sourcegitcommit: 698650216533c20cb7b9773bb51ece9b5ef7d761
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/25/2017
---
# <a name="xbox-live-multiplayer-platform"></a>Xbox Live Multiplayer Platform

The Xbox Live Multiplayer Platform empowers your game to bring Xbox Live players together over the Internet and can dramatically extend the life and usage of a title beyond typical solo play.

By building a great multiplayer experience for your audience, you can leverage the large social network of Xbox Live gamers to increase the user base for your game and promote a sustained community of dedicated fans playing together.


## <a name="what-is-the-xbox-live-multiplayer-platform"></a>What is the Xbox Live Multiplayer Platform?

The Xbox Live Multiplayer Platform is a set of client APIs that you can use to implement real-time multiplayer gameplay. The major sub-systems in the API suite are:

-   The **Xbox Live Multiplayer Session Directory (MPSD)** service. The MPSD service works with integrated UI experiences to facilitate users finding and inviting each other for play. Integration with Xbox Live's services also allows customers to use Xbox Live Party Chat to assemble.
-   **Simple and advanced matchmaking facilities.** Xbox Live provides traditional quickmatch capabilities, but also session browse and support for highly customized matchmaking scenarios. Xbox Live Looking for Group (LFG) also allows players to find each other, rally in Party Chat, and then play your game.
-   **Peer to peer and client-server networking APIs** provide secure real-time communication leveraging modern Internet standards and actively monitored by Xbox Live. Standardization and integration with the Xbox Live network troubleshooting experiences allow users to quickly remediate connectivity issues.  
-   **Integrated voice and text chat solutions** that facilitate safe in-game communication leveraging the Xbox Live social graph, media services, and specialized encoding hardware on Xbox One devices.

For an overview of some of the most common multiplayer scenarios, and which Xbox Live functionality can help implement those scenarios, see [Multiplayer Levels](multiplayer-scenarios.md).

## <a name="how-can-i-implement-xbox-live-multiplayer-in-my-game"></a>How can I implement Xbox Live Multiplayer in my game?
Depending on your scenario, the Xbox Live Multiplayer Platform provides several approaches to implementing Xbox Live Multiplayer in your game.

### <a name="xbox-integrated-multiplayer-xim"></a>Xbox Integrated Multiplayer (XIM)
XIM is an turnkey solution for adding real-time multiplayer networking and communication to your game through the power of Xbox Live services. The goal of XIM is to make it easier than ever to build high quality peer-to-peer (P2P) multiplayer games on Xbox One & Windows 10.

XIM provides the following functionality:
- Support for game invitations and simple matchmaking.
- A simple and secure real-time network that is transparently augmented by the Xbox Live Multiplayer Relay Service.
- Simple voice and text chat, with facilities for transcribing and narrating communication for a more accessible end-user experience.
- Aides for detecting and managing network congestion, as well as for migrating game state.

XIM is the simplest multiplayer solution available through the Xbox Live Multiplayer Platform, but also the least customizable and is only suited for P2P games. For more information about XIM, see [Xbox Integrated Multiplayer](xbox-integrated-multiplayer-overview.md).

### <a name="xbox-multiplayer-manager"></a>Xbox Multiplayer Manager
Xbox Multiplayer Manager (MPM) は、Xbox Live のマルチプレイヤー セッション ディレクトリ、招待、マッチメイキング サービスに柔軟にアクセスできるクライアント API です。

It implements many common multiplayer scenarios in an efficient manner that follows best practices, and also handles many of the Xbox Requirements (XRs) that your game must implement in order to pass certification.

Xbox Multiplayer Manager does not implement a networking or chat layer. MPM は、Windows.Networking.XboxLive を通じて実装される安全なネットワーク層と対になる、柔軟ながらもシンプルで統合されたゲーム用マルチプレイヤー管理 API として設計されています。 [ゲーム チャット 2](chat/game-chat-2-overview.md) API または XIM Chat Reservations によってゲーム内通信を追加できます。 ネットワークおよびゲーム チャット 2 API のドキュメントは、Xbox One XDK と Xbox Live Platform Extensions SDK に含まれています。

If you are hosting dedicated servers for your multiplayer game, MPM is the best choice. MPM is also well-suited for advanced scenarios such as integration with Xbox Live Tournaments. For more information on MPM, see  [Introduction to Multiplayer Manager](multiplayer-manager/multiplayer-manager-api-overview.md).

To use Multiplayer Manager, you must configure the Xbox Live service for your multiplayer scenarios. For more information on this configuration, see [Configure the Multiplayer service](service-configuration/configure-the-multiplayer-service.md).

>Multiplayer Manager does not currently support session browse. For information see [Multiplayer Session Browse](session-browse.md).

### <a name="api-capabilites"></a>API Capabilites

Functionality | Xbox Integrated Multiplayer| Multiplayer Manager
--  | -- | --
Visibility |  XIM is provided as a compiled library without source.  | MPM is provided with source, so you may customize behavior by directly interacting with Xbox Live services or with XSAPI.
Session and Matchmaking | XIM provides simple pre-configured matchmaking rules and does not require multiplayer configuration. | MPM [requires configuring the Multiplayer service](service-configuration/configure-the-multiplayer-service.md), which enables sophisticated specification of matchmaking and session behavior.
Networking | XIM provides a simple & secure player to player network, backed by the Xbox Live Relay service when required. | MPM is designed so you can plug in your own secure networking solution using Windows.Networking.XboxLive.
ゲーム チャット | XIM provides integrated voice and text chat. | ゲーム チャット 2 API または XIM の帯域外予約を使ってゲーム内通信を実装し、MPM が管理する名簿に登録された参加者によるチャットを有効にできます。
