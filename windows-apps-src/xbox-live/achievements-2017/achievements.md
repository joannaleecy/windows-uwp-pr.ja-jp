---
title: Achievements
author: KevinAsgari
description: Achievements
ms.assetid: 35e055c2-3c84-4d73-bb86-fc776327d901
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one
ms.openlocfilehash: 3e1e91bd6bdb4740af71b403a4db9fe931cab319
ms.sourcegitcommit: b73a57142b9847b09ebb00e81396f2655bbc26ec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2017
---
# <a name="achievements"></a>Achievements

In 2005, Xbox LIVE introduced the gaming industry to the notion of an achievement, a system-wide mechanism for directing and rewarding users' in-game actions in a consistent manner across all games.

With Xbox One, the achievement system expands to engage users across a broader range of activities, devices, and scenarios. Achievements are now more inclusive, more social, and more engaging than ever before! 開発者と発行者は、ゲーマースコアに勝る、新しい実績の種類とリワードを持つ実績を作成できます。 Gamerscore is still a key reward, however, so developers can now add more achievements and gamerscore over the lifetime of the title, even without a new content release. Xbox One の実績は、サービスのような柔軟性をタイトルに提供できるように全面的に見直されました。

## <a name="feature-summary"></a>Feature Summary ##
This list provides a summary of the key features and components that contribute to the achievement system on Xbox One.

Feature | Description
--- | ---
Persistent Achievements (achievements) | この種類の実績は、タイトルの有効期間中ずっと存在します。 Users may unlock them at any time. A persistent achievement’s required activity must always be available for users to complete and its reward must always be earnable.
Challenge Achievements (challenges) | This type of achievement is only available for a limited time. The publisher determines the dates during which a challenge achievement is available to unlock, and users must unlock it within that predefined timeframe to receive the recognition and its reward.
公開後の実績 | Add achievements after title launch with no additional code required.
Achievement Progression | Now users can see how far along they are toward unlocking the achievement, even from the dashboard, giving them more reasons to fire up your title.
具体的なリワードのロック解除 | Xbox ゲーム体験の重要な要素であるゲーマースコアに加えて、Xbox One ユーザーは、Xbox Live の実績を通じて、デジタル アートワーク、新しいマップ、ロック解除可能なキャラクター、一時的なステータス ブーストなどのゲーム関連の特別なリワードをロック解除できます。
実績アクティビティ フィード | ユーザーは、フレンドの間で最近人気の高い実績や獲得されているリワードを簡単に把握することができます。
単一のゲーマースコア | 従来のプラットフォームまたは最新プラットフォームでユーザーが獲得するゲーマースコアは、単一のゲーマースコアに加算されます。

## <a name="making-achievements-work-well-with-the-guide-ui"></a>実績をガイド UI と適切に連動させる ##
Xbox One 本体のガイド UI では、ユーザーの実績アクティビティがリアルタイムで強調表示されます。 この組み込み機能を最大限に活用するには、実績のロック解除に向けたユーザーの進行状況に関する更新情報をタイトルから送信する必要があります。 実績の進行状況の追跡をサポートしているタイトルでは、そのタイトルの各実績のロック解除に向けたユーザーの現在の進行状況を、より詳しく便利に表示するビューが提供されます。 また、ガイド UI では、タイトルの実績が自動的に進行状況の割合順に並べ替えられます。このため、ユーザーは、次回のプレイ セッションですぐにでも達成できる可能性のある実績はどれかを簡単に知ることができます。
