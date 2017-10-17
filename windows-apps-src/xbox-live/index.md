---
author: KevinAsgari
title: Xbox Live developer guide
description: Learn how to use Xbox Live services to connect your game to the Xbox Live gaming network.
ms.author: kevinasg
ms.date: 08/22/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, Xbox, Xbox Live"
ms.openlocfilehash: fbdaf391b382415d8da8c9ef495a5847ef1e8a99
ms.sourcegitcommit: ee52999173f1197836075f7e5fb8fe3c1fce88c5
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/28/2017
---
# <a name="what-is-xbox-live"></a>Xbox Live とは

Xbox Live is a premier gaming network that connects millions of gamers across the world. You can add Xbox Live to your Windows 10 or Xbox One game in order to take advantage of the Xbox Live features and services.

With the Xbox Live Creators Program, anyone with a Windows Dev Center account can build an Xbox Live enabled Universal Windows Platform (UWP) game that can run on both Windows 10 PCs and Xbox One consoles.

For game developers that want to take advantage of the full Xbox Live experience, including multiplayer, achievements, and native Xbox console development, there are additional developer programs which are detailed in the [Developer Program Overview](developer-program-overview.md).

以下に、Xbox Live をゲームに追加する理由をいくつか示します。

- Xbox Live unites gamers across Xbox One and Windows 10, so gamers can play with their friends and connect with a massive community of players.
- Xbox Live lets players build a gaming legacy by unlocking achievements, sharing epic game clips, amassing Gamerscore, and perfecting their avatar.
- Xbox Live lets gamers play and pick up where they left off on another Xbox One or PC, bringing all their saves from another device.
- With over 1 billion multiplayer matches played each month, Xbox Live is built for performance, speed and reliability.
- クロスデバイス マルチプレイヤーでは、ゲーマーは Xbox One または Windows 10 PC のどちらを使うフレンドとでもプレイできます。

> [!note]
> これらのトピックは、ゲームに Xbox Live のサポートを追加しようとしているゲーム開発者を対象としています。 コンシューマー向けの Xbox Live の情報を探している場合は、[Xbox Live](http://www.xbox.com/live/) のサイトをご覧ください。

## <a name="how-xbox-live-works"></a>Xbox Live のしくみ

技術的な観点から見ると、Xbox Live は、プロフィール、フレンドとプレゼンス、統計、ランキング、実績、マルチプレイヤー、マッチメイキングなどの Xbox Live の機能を公開するマイクロサービスの集合体です。 Xbox Live データはクラウドに格納され、REST エンドポイントと、ゲーム開発者向けに設計された一連のクライアント側 API からアクセス可能な、セキュリティで保護された WebSocket を使ってアクセスできます。

REST API に加えて、REST 機能をラップするクライアント側 API もあります。 詳しくは、「[Xbox Live API の概要](introduction-to-xbox-live-apis.md)」をご覧ください。

### <a name="get-started-with-xbox-live"></a>Xbox Live の概要

The following guides can help you get started with Xbox Live development, regardless of whether you are a UWP or Xbox console developer.  There are also guides for getting setup with game engines.

| Topic                                                                                                                                             | 説明                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [開発者プログラムの概要](developer-program-overview.md) | Discusses the various developer programs that enable Xbox Live development. |
| [Get started with Xbox Live Creators Program](get-started-with-creators/get-started-with-xbox-live-creators.md) | How to get started with Xbox Live in the Xbox Live Creators Program. |
| [Get started with Xbox Live as an ID@Xbox or managed  developer](get-started-with-partner/get-started-with-xbox-live-partner.md) | How to get started with Xbox Live as a developer in the ID@Xbox Program. |

### <a name="using-xbox-live"></a>Using Xbox Live

Once you have a title created and the fundamentals working, this section provides necessary background before you jump in and start coding.

| Topic                                                                                                                                             | Description                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [Using Xbox Live](using-xbox-live/using-xbox-live.md) | Once you've setup your title and integrated the Xbox Live SDK, you are ready to implement sign-in and learn more about Xbox Live programming.
| [Best practices for calling Xbox Live](using-xbox-live/best-practices/best-practices-for-calling-xbox-live.md) | Familiarize yourself with the basics on Xbox Live calling patterns and best-practices to ensure your title performs well and doesn't get rate limited.
| [Troubleshooting the Xbox Live Services API](using-xbox-live/troubleshooting/troubleshooting-the-xbox-live-services-api.md) | Common issues you may encounter and suggestions on how to fix them.

### <a name="xbox-live-social-platform"></a>Xbox Live Social Platform

Xbox Live social features can organically grow your audience, spreading awareness to over 55 million active users.  This section describes how to get started with the Xbox Live social features.

| Topic                                                                                                                                             | Description                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [Xbox Live Social Platform](social-platform/social-platform.md) | If you can sign-in a user, then you can start using Xbox Live's social features, such as utilizing a user's social graph, Rich Presence, and others. |

### <a name="xbox-live-data-platform"></a>Xbox Live Data Platform

The Xbox Live Data Platform drives the usage of player stats, achievements, and leaderboards.  Read this series of topics to learn more about how to use these in your title.

| Topic                                                                                                                                             | Description                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [Xbox Live Data Platform](data-platform/data-platform.md) | A brief overview of the Data Platform, as well as guidance on how to best incorporate stats, leaderboards, and achievements into your title.
| [Player Stats](leaderboards-and-stats-2017/player-stats.md) | Stats are the foundation of leaderboards.  Learn how to define and use them here.
| [Leaderboards](leaderboards-and-stats-2017/leaderboards.md) | Bring out your users' competitive sides by intelligently incorporating leaderboards.
| [Achievements](achievements-2017/achievements.md) | Achievements are one of the most well known features in Xbox Live, and a great driver of player engagement. Learn how to use them in your title.

### <a name="xbox-live-multiplayer-platform"></a>Xbox Live Multiplayer Platform

Multiplayer is a great way to extend the lifetime of your title and keep gameplay experiences fresh.  Xbox Live provides extensive multiplayer and matchmaking features.  You also have several options of API that provide varying levels of simplicity vs flexibility.

| Topic                                                                                                                                             | Description                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [Xbox Live Multiplayer Platform](multiplayer/multiplayer-intro.md) | If you are new to Xbox Live multiplayer development, or are unfamiliar with new APIs such as Multiplayer Manager and Xbox Integrated Multiplayer (XIM), then start here. |
| [Multiplayer scenarios](multiplayer/multiplayer-scenarios.md) | Suggestions and guidance on how you might incorporate multiplayer into your title. |
| [Xbox Integrated Multiplayer](multiplayer/xbox-integrated-multiplayer-overview.md) | Xbox Integrated Multiplayer (XIM) is an easy self-contained interface for adding multiplayer, real-time networking, and chat to your title. |
| [Multiplayer Manager](multiplayer/multiplayer-manager.md) | Multiplayer Manager provides an API focused on common multiplayer scenarios. |

### <a name="xbox-live-storage-platform"></a>Xbox Live Storage Platform

The Xbox Live Storage Platform provides both Title Storage and Connected Storage.  These are two different but complementary services.  Connected Storage allows you to implement game saves in the cloud, that will roam across devices regardless of where a user is signed-in.  Title Storage lets you store blobs of data that can be per user or per title and shared across different users.

| Topic                                                                                                                                             | Description                                                                                                   |
|:--------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------|
| [Xbox Live Storage Platform](storage-platform/storage-platform.md) | Use the Xbox Live storage services for storing game saves, instant replays, user preferences, and other data in the cloud. |
| [Connected Storage](storage-platform/connected-storage/connected-storage-technical-overview.md) | An overview and programming guide on Connected Storage. |
| [Title Storage](storage-platform/xbox-live-title-storage/xbox-live-title-storage.md) | An overview and programming guide on Title Storage. |
