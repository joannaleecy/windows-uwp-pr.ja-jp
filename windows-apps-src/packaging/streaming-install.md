---
author: laurenhughes
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.author: lahugh
ms.date: 04/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、インストール、ストリーミング ストリーミング uwp アプリをインストールします。
ms.localizationpriority: medium
ms.openlocfilehash: 087226cad4bcf7ea0294d8878564c345d6cfb9d0
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608797"
---
# <a name="uwp-app-streaming-install"></a><span data-ttu-id="d9496-105">UWP アプリ ストリーミング インストール</span><span class="sxs-lookup"><span data-stu-id="d9496-105">UWP App Streaming Install</span></span>
<span data-ttu-id="d9496-106">ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="d9496-106">Universal Windows Platform (UWP) App Streaming Install enables you to specify which parts of your app you would like the Microsoft Store to download first.</span></span> <span data-ttu-id="d9496-107">アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。</span><span class="sxs-lookup"><span data-stu-id="d9496-107">When the essential files of the app are downloaded first, the user can launch and interact with the app while the rest of it finishes downloading in the background.</span></span> 

<span data-ttu-id="d9496-108">アプリをインストールするストリーミング UWP を使用するには、アプリのファイルをセクションに分割する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9496-108">To use UWP App Streaming Install you'll need to divide your app's files into sections.</span></span> <span data-ttu-id="d9496-109">これを行うには、されますマップを作成するコンテンツ グループ、アプリ パッケージ化されている XML ファイルには、ダウンロードの優先度を設定して順序ができるようにします。</span><span class="sxs-lookup"><span data-stu-id="d9496-109">To do this, you'll create a content group map, which is an XML file that's packaged with your app, allowing you to set download priority and order.</span></span> <span data-ttu-id="d9496-110">詳細については、下にあるリンクのトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d9496-110">See the topic linked below for more information.</span></span>

<span data-ttu-id="d9496-111">アプリをインストールするストリーミング UWP UWP アプリの追加の完了については、この[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)を確認します。</span><span class="sxs-lookup"><span data-stu-id="d9496-111">For a complete guide on adding UWP App Streaming Install to your UWP app, check out this [blog series](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/).</span></span>

| <span data-ttu-id="d9496-112">トピック</span><span class="sxs-lookup"><span data-stu-id="d9496-112">Topic</span></span> | <span data-ttu-id="d9496-113">説明</span><span class="sxs-lookup"><span data-stu-id="d9496-113">Description</span></span> | 
|-------|-------------|
| [<span data-ttu-id="d9496-114">ソース コンテンツ グループ マップの作成と変換</span><span class="sxs-lookup"><span data-stu-id="d9496-114">Create and convert a source content group map</span></span>](create-cgm.md) | <span data-ttu-id="d9496-115">ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9496-115">To get your Universal Windows Platform (UWP) app ready for UWP App Streaming Install, you'll need to create a content group map.</span></span> <span data-ttu-id="d9496-116">この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。</span><span class="sxs-lookup"><span data-stu-id="d9496-116">This article will help you with the specifics of creating and converting a content group map while providing some tips and tricks along the way.</span></span> |