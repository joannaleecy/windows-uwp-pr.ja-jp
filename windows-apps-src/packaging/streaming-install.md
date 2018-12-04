---
ms.assetid: df4d227c-21f9-4f99-9e95-3305b149d9c5
title: UWP アプリ ストリーミング インストール
description: ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。 アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。
ms.date: 04/05/2017
ms.topic: article
keywords: windows 10, uwp, ストリーミング インストールでは、uwp アプリ ストリーミング インストールします。
ms.localizationpriority: medium
ms.openlocfilehash: 3fa33410be31b1732a04c51d14dbbd114e1f5e0c
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8466982"
---
# <a name="uwp-app-streaming-install"></a><span data-ttu-id="04af0-105">UWP アプリ ストリーミング インストール</span><span class="sxs-lookup"><span data-stu-id="04af0-105">UWP App Streaming Install</span></span>
<span data-ttu-id="04af0-106">ユニバーサル Windows プラットフォーム (UWP) アプリ ストリーミング インストールでは、Microsoft Store からアプリのどの部分を最初にダウンロードするかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="04af0-106">Universal Windows Platform (UWP) App Streaming Install enables you to specify which parts of your app you would like the Microsoft Store to download first.</span></span> <span data-ttu-id="04af0-107">アプリの基本的なファイルを先にダウンロードすると、残りの部分のダウンロードをバックグラウンドで完了している間に、ユーザーはアプリを起動して操作できます。</span><span class="sxs-lookup"><span data-stu-id="04af0-107">When the essential files of the app are downloaded first, the user can launch and interact with the app while the rest of it finishes downloading in the background.</span></span> 

<span data-ttu-id="04af0-108">UWP アプリ ストリーミング インストールを使用するには、セクションでは、アプリのファイルに分割する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04af0-108">To use UWP App Streaming Install you'll need to divide your app's files into sections.</span></span> <span data-ttu-id="04af0-109">これを行うにはセットのダウンロードの優先順位と順序を許可するが、アプリをパッケージ化されている XML ファイルで、コンテンツ グループ マップ作成します。</span><span class="sxs-lookup"><span data-stu-id="04af0-109">To do this, you'll create a content group map, which is an XML file that's packaged with your app, allowing you to set download priority and order.</span></span> <span data-ttu-id="04af0-110">詳細については下のリンクのトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="04af0-110">See the topic linked below for more information.</span></span>

<span data-ttu-id="04af0-111">UWP アプリに UWP アプリ ストリーミング インストールを追加する完全なについては、この[ブログ シリーズ](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/)ご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04af0-111">For a complete guide on adding UWP App Streaming Install to your UWP app, check out this [blog series](https://blogs.msdn.microsoft.com/appinstaller/2017/03/15/uwp-streaming-app-installation/).</span></span>

| <span data-ttu-id="04af0-112">トピック</span><span class="sxs-lookup"><span data-stu-id="04af0-112">Topic</span></span> | <span data-ttu-id="04af0-113">説明</span><span class="sxs-lookup"><span data-stu-id="04af0-113">Description</span></span> | 
|-------|-------------|
| [<span data-ttu-id="04af0-114">ソース コンテンツ グループ マップの作成と変換</span><span class="sxs-lookup"><span data-stu-id="04af0-114">Create and convert a source content group map</span></span>](create-cgm.md) | <span data-ttu-id="04af0-115">ユニバーサル Windows プラットフォーム (UWP) アプリを UWP アプリ ストリーミング インストールに対応させるには、コンテンツ グループ マップを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04af0-115">To get your Universal Windows Platform (UWP) app ready for UWP App Streaming Install, you'll need to create a content group map.</span></span> <span data-ttu-id="04af0-116">この記事では、コンテンツ グループ マップの作成と変換に関する詳細情報と、それに伴うヒントやコツを示します。</span><span class="sxs-lookup"><span data-stu-id="04af0-116">This article will help you with the specifics of creating and converting a content group map while providing some tips and tricks along the way.</span></span> |