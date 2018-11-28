---
ms.assetid: 7bb9fd81-8ab5-4f8d-a854-ce285b0669a4
description: ネットワークと Web サービスにアクセスするためのテクノロジ。
title: ネットワークと Web サービス
ms.date: 11/26/2017
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 26324637fdf54b48fa441d28065bf437fbf74b26
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7845013"
---
# <a name="networking-and-web-services"></a><span data-ttu-id="5c492-104">ネットワークと Web サービス</span><span class="sxs-lookup"><span data-stu-id="5c492-104">Networking and web services</span></span>

<span data-ttu-id="5c492-105">ユニバーサル Windows プラットフォーム (UWP) 開発者は、次のネットワークと Web サービス テクノロジを利用できます。</span><span class="sxs-lookup"><span data-stu-id="5c492-105">The following networking and web services technologies are available for Universal Windows Platform (UWP) developers.</span></span>

| <span data-ttu-id="5c492-106">トピック</span><span class="sxs-lookup"><span data-stu-id="5c492-106">Topic</span></span> | <span data-ttu-id="5c492-107">説明</span><span class="sxs-lookup"><span data-stu-id="5c492-107">Description</span></span> |
| - | - |
| [<span data-ttu-id="5c492-108">ネットワークの基本</span><span class="sxs-lookup"><span data-stu-id="5c492-108">Networking basics</span></span>](networking-basics.md) | <span data-ttu-id="5c492-109">ネットワーク対応アプリで実行する必要がある事柄について説明します。</span><span class="sxs-lookup"><span data-stu-id="5c492-109">Things you must do for any network-enabled app.</span></span> |
| [<span data-ttu-id="5c492-110">アプリに適したネットワーク テクノロジ</span><span class="sxs-lookup"><span data-stu-id="5c492-110">Which networking technology?</span></span>](which-networking-technology.md) | <span data-ttu-id="5c492-111">UWP 開発者が利用できるネットワーク テクノロジの概要と、アプリに適したテクノロジを選ぶヒントを説明します。</span><span class="sxs-lookup"><span data-stu-id="5c492-111">A quick overview of the networking technologies available for a UWP developer, with suggestions on how to choose the technologies that are right for your app.</span></span> |
| [<span data-ttu-id="5c492-112">バックグラウンドでのネットワーク通信</span><span class="sxs-lookup"><span data-stu-id="5c492-112">Network communications in the background</span></span>](network-communications-in-the-background.md) | <span data-ttu-id="5c492-113">バックグラウンドでないときにネットワーク通信を続けるため、アプリはバックグラウンド タスクを使うことができます。ソケット ブローカーまたはコントロール チャネルがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="5c492-113">To continue network communication while it's not in the background, an app can use background tasks and either socket broker or control channel triggers.</span></span> |
| [<span data-ttu-id="5c492-114">ソケット</span><span class="sxs-lookup"><span data-stu-id="5c492-114">Sockets</span></span>](sockets.md) | <span data-ttu-id="5c492-115">ソケットは、下位レベルのデータ転送テクノロジであり、多くのネットワーク プロトコルがこの上に実装されています。</span><span class="sxs-lookup"><span data-stu-id="5c492-115">Sockets are a low-level data transfer technology on top of which many networking protocols are implemented.</span></span> <span data-ttu-id="5c492-116">UWP は、接続が長期間維持されるか、確立された接続が必要あるかどうかに関係なく、クライアント/サーバー アプリケーションまたは ピア ツー ピア アプリケーションの TCP および UDP ソケット クラスを提供します。</span><span class="sxs-lookup"><span data-stu-id="5c492-116">UWP offers TCP and UDP socket classes for client-server or peer-to-peer applications, whether connections are long-lived or an established connection is not required.</span></span> |
| [<span data-ttu-id="5c492-117">WebSocket</span><span class="sxs-lookup"><span data-stu-id="5c492-117">WebSockets</span></span>](websockets.md) | <span data-ttu-id="5c492-118">WebSocket は、クライアントとサーバー間の高速で安全な双方向通信を、HTTP(S) を使った Web 経由で実現するメカニズムを提供し、UTF-8 メッセージとバイナリ メッセージの両方をサポートします。</span><span class="sxs-lookup"><span data-stu-id="5c492-118">WebSockets provide a mechanism for fast, secure, two-way communication between a client and a server over the web using HTTP(S), and supporting both UTF-8 and binary messages.</span></span> |
| [<span data-ttu-id="5c492-119">HttpClient</span><span class="sxs-lookup"><span data-stu-id="5c492-119">HttpClient</span></span>](httpclient.md) | <span data-ttu-id="5c492-120">HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、[Windows.Web.Http](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間 API を使います。</span><span class="sxs-lookup"><span data-stu-id="5c492-120">Use [Windows.Web.Http](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace API to send and receive information using the HTTP 2.0 and HTTP 1.1 protocols.</span></span> |
| [<span data-ttu-id="5c492-121">RSS/Atom フィード</span><span class="sxs-lookup"><span data-stu-id="5c492-121">RSS/Atom feeds</span></span>](web-feeds.md) | <span data-ttu-id="5c492-122">[Windows.Web.Syndication](https://msdn.microsoft.com/library/windows/apps/br243632) 名前空間の機能を利用し、RSS や Atom の標準に従って生成される概要フィードを使って、最新の人気の高い Web コンテンツを取得または作成します。</span><span class="sxs-lookup"><span data-stu-id="5c492-122">Retrieve or create the most current and popular Web content using syndicated feeds generated according to the RSS and Atom standards using features in the [Windows.Web.Syndication](https://msdn.microsoft.com/library/windows/apps/br243632) namespace.</span></span> |
| [<span data-ttu-id="5c492-123">バックグラウンド転送</span><span class="sxs-lookup"><span data-stu-id="5c492-123">Background transfers</span></span>](background-transfers.md) | <span data-ttu-id="5c492-124">ネットワーク経由でファイルを確実にコピーするには、バックグラウンド転送 API を使います。</span><span class="sxs-lookup"><span data-stu-id="5c492-124">Use the background transfer API to copy files reliably over the network.</span></span> |
