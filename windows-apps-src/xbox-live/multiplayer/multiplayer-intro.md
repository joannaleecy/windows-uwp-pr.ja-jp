---
title: Xbox Live マルチプレイヤー プラットフォーム
author: KevinAsgari
description: Xbox Live でサポートされているマルチプレイヤー プラットフォームについて説明します。
ms.assetid: 958b94b3-dccd-479a-bf52-54f7ff1656fa
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: 27b91376bfdb58bd474f7d291fa9f650455461c0
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3962525"
---
# <a name="xbox-live-multiplayer-platform"></a>Xbox Live マルチプレイヤー プラットフォーム

Xbox Live マルチプレイヤー プラットフォームにより、ゲームは Xbox Live プレイヤー同士をインターネット経由で結び付けて、タイトルの寿命と使用量を一般的なソロ プレイより大幅に拡張することができます。

ユーザーのために優れたマルチプレイヤー エクスペリエンスを作成することで、Xbox Live ゲーマーの大規模なソーシャル ネットワークを利用して、ゲームのユーザー ベースを拡大し、一緒にプレイするファンのコミュニティを形成および持続させることができます。


## <a name="what-is-the-xbox-live-multiplayer-platform"></a>Xbox Live マルチプレイヤー プラットフォームとは

Xbox Live マルチプレイヤー プラットフォームは、リアルタイム マルチプレイヤー ゲームプレイを実装するために使用できるクライアント API のセットです。 API スイートの主要なサブシステムは次のとおりです。

-   **Xbox Live マルチプレイヤー セッション ディレクトリ (MPSD)** サービス。 MPSD サービスは統合された UI エクスペリエンスと連携して、ユーザーによるプレイのための相互の検索と招待を容易にします。 Xbox Live のサービスとの統合により、ユーザーは集合に Xbox Live パーティー チャットを使用することもできます。
-   **シンプルかつ高度なマッチメイキング機能。** Xbox Live は従来のクイック マッチ機能を提供しますが、高度にカスタマイズされたマッチメイキング シナリオのためのセッション参照とサポートも提供します。 Xbox Live グループを検索 (Looking for Group: LFG) により、プレイヤーは相互を検索し、パーティー チャットでやり取りして、ゲームをプレイすることもできます。
-   **ピア ツー ピアおよびクライアント サーバー ネットワーク API** は、最新のインターネット規格を利用し、Xbox Live によってアクティブに監視される、安全なリアルタイムの通信を提供します。 標準化および Xbox Live ネットワーク トラブルシューティング エクスペリエンスとの統合により、ユーザーは接続の問題を短時間で解決できます。  
-   **統合された音声およびテキスト チャット ソリューション**は、Xbox Live のソーシャル グラフ、メディア サービス、Xbox One デバイス上の専用エンコード ハードウェアを利用して、安全なゲーム内通信を促進します。

最も一般的なマルチプレイヤー シナリオの概要およびそれらのシナリオの実装に役立つ Xbox Live の機能については、「[マルチプレイヤーのレベル](multiplayer-scenarios.md)」を参照してください。

## <a name="how-can-i-implement-xbox-live-multiplayer-in-my-game"></a>ゲームに Xbox Live マルチプレイヤーを実装する方法
Xbox Live マルチプレイヤー プラットフォームには、シナリオに応じてゲームに Xbox Live マルチプレイヤーを実装する複数のアプローチが用意されています。

### <a name="xbox-integrated-multiplayer-xim"></a>Xbox Integrated Multiplayer (XIM)
XIM は、Xbox Live サービスを利用してゲームにリアルタイムのマルチプレイヤー ネットワークと通信を追加するためのターンキー ソリューションです。 XIM の目的は、Xbox One および Windows 10 での高品質なピア ツー ピア (P2P) マルチプレイヤー ゲームの開発をこれまでよりはるかに簡単にすることです。

XIM は以下の機能を提供します。
- ゲームへの招待と簡単なマッチメイキングのサポート。
- Xbox Live マルチプレイヤー リレー サービスによって透過的に拡張される簡単で安全なリアルタイム ネットワーク。
- コミュニケーションのテキスト変換や読み上げの機能を備えた簡単な音声およびテキスト チャットによる、アクセシビリティに優れたエンド ユーザー エクスペリエンス。
- ネットワーク輻輳の検出と管理およびゲーム状態の移行の補助。

XIM は Xbox Live マルチプレイヤー プラットフォームで利用できる最も簡単なマルチプレイヤー ソリューションですが、カスタマイズできる範囲は最も小さく、P2P ゲームに対してのみ適しています。 XIM について詳しくは、「[Xbox Integrated Multiplayer](xbox-integrated-multiplayer.md)」をご覧ください。

### <a name="xbox-multiplayer-manager"></a>Xbox Multiplayer Manager
Xbox Multiplayer Manager (MPM) は、Xbox Live のマルチプレイヤー セッション ディレクトリ、招待、マッチメイキング サービスに柔軟にアクセスできるクライアント API です。

多くの一般的なマルチプレイヤー シナリオを、ベスト プラクティスに従った効率的な方法で実装し、認定に合格するためにゲームが実装する必要のある多くの Xbox 要件 (XR) にも対応しています。

Xbox Multiplayer Manager は、ネットワーク層またはチャット層を実装していません。 MPM は、Windows.Networking.XboxLive を通じて実装される安全なネットワーク層と対になる、柔軟ながらもシンプルで統合されたゲーム用マルチプレイヤー管理 API として設計されています。 [ゲーム チャット 2](chat/game-chat-2-overview.md) API または XIM Chat Reservations によってゲーム内通信を追加できます。 ネットワークおよびゲーム チャット 2 API のドキュメントは、Xbox One XDK と Xbox Live Platform Extensions SDK に含まれています。

マルチプレイヤー ゲーム専用のサーバーをホストしている場合は、MPM が最善の選択です。 MPM は、Xbox Live トーナメントとの統合のような高度なシナリオにも適しています。 MPM について詳しくは、「[Multiplayer Manager の概要](multiplayer-manager/multiplayer-manager-api-overview.md)」をご覧ください。

Multiplayer Manager を使用するには、マルチプレイヤー シナリオ用に Xbox Live サービスを構成する必要があります。 この構成について詳しくは、「[マルチプレイヤー サービスを構成する](service-configuration/configure-the-multiplayer-service.md)」をご覧ください。

>現在、Multiplayer Manager はセッション参照をサポートしていません。 詳しくは、「[マルチプレイヤーのセッション参照](session-browse.md)」をご覧ください。

### <a name="api-capabilites"></a>API の機能

機能 | Xbox Integrated Multiplayer| Multiplayer Manager
--  | -- | --
表示 |  XIM はソースなしのコンパイル済みライブラリとして提供されます。  | MPM はソースと共に提供されるため、Xbox Live サービスまたは XSAPI と直接やり取りして動作をカスタマイズできます。
セッションとマッチメイキング | XIM は、シンプルな事前構成済みのマッチメイキング ルールを提供し、マルチプレイヤーの構成を必要としません。 | MPM では、[マルチプレイヤー サービスを構成する](service-configuration/configure-the-multiplayer-service.md)必要があります。これにより、高度な仕様のマッチメイキングとセッション動作が可能になります。
ネットワーキング | XIM は、必要に応じて Xbox Live リレー サービスによってサポートされる、セキュリティで保護されたシンプルなプレイヤー間ネットワークを提供します。 | MPM は、Windows.Networking.XboxLive を使用して、セキュリティで保護された独自のネットワーク ソリューションに接続できるように設計されています。
ゲーム チャット | XIM は、統合された音声およびテキスト チャットを提供します。 | ゲーム チャット 2 API または XIM の帯域外予約を使ってゲーム内通信を実装し、MPM が管理する名簿に登録された参加者によるチャットを有効にできます。
