---
title: Xbox Live SDK の新規事項 - August 2015
description: Xbox Live SDK の新規事項 - August 2015
ms.assetid: a034867b-7cc0-4b97-89d5-3486e95a80b4
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: a454b7339035475416934c2f921dae65283c340c
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8796541"
---
# <a name="whats-new-for-the-xbox-live-sdk---august-2015"></a><span data-ttu-id="27766-104">Xbox Live SDK の新規事項 - August 2015</span><span class="sxs-lookup"><span data-stu-id="27766-104">What's new for the Xbox Live SDK - August 2015</span></span>

<span data-ttu-id="27766-105">June 2015 リリースで追加された内容については、「[新規事項 - June 2015](1506-whats-new.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="27766-105">Please see the [What's New - June 2015](1506-whats-new.md) article for what was added in the June 2015 release.</span></span>

<span data-ttu-id="27766-106">Xbox Live SDK の August リリースには以下の更新が含まれます。</span><span class="sxs-lookup"><span data-stu-id="27766-106">The August release of the Xbox Live SDK includes the following updates:</span></span>

## <a name="os-and-tool-support"></a><span data-ttu-id="27766-107">OS とツールのサポート</span><span class="sxs-lookup"><span data-stu-id="27766-107">OS and tool support</span></span>
<span data-ttu-id="27766-108">Xbox Live SDK で、Windows 10 RTM [バージョン 10.0.10240] と Visual Studio 2015 RTM [バージョン 14.0.23107.0] がサポートされるようになりました。</span><span class="sxs-lookup"><span data-stu-id="27766-108">The Xbox Live SDK now supports Windows 10 RTM [Version 10.0.10240] and Visual Studio 2015 RTM [Version 14.0.23107.0].</span></span>

## <a name="multiplayer-manager-winrt-apis"></a><span data-ttu-id="27766-109">Multiplayer Manager WinRT API</span><span class="sxs-lookup"><span data-stu-id="27766-109">Multiplayer Manager WinRT APIs</span></span>
<span data-ttu-id="27766-110">Multiplayer Manager (experimental 名前空間内) は、WinRT API を (C++ API に加えて) サポートするようになりました</span><span class="sxs-lookup"><span data-stu-id="27766-110">Multiplayer Manager (in the experimental namespace) now supports WinRT APIs (in addition to C++ APIs)</span></span>

## <a name="submit-batch-feedback-from-a-title"></a><span data-ttu-id="27766-111">タイトルからバッチ フィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="27766-111">Submit batch feedback from a title</span></span>
<span data-ttu-id="27766-112">タイトルから多数のフィードバック項目を一度に送信します。</span><span class="sxs-lookup"><span data-stu-id="27766-112">Submits a number of feedback items at once from a title.</span></span>

## <a name="newupdated-documentation"></a><span data-ttu-id="27766-113">新しい/更新されたドキュメント</span><span class="sxs-lookup"><span data-stu-id="27766-113">New/Updated documentation</span></span>
<span data-ttu-id="27766-114">Xbox Live SDK パッケージに "Docs" フォルダーが追加されました。このフォルダーには、更新された API リファレンスと新しい「Xbox Live プログラミング ガイド」が含まれています。</span><span class="sxs-lookup"><span data-stu-id="27766-114">The Xbox Live SDK package now includes a "Docs" folder, contains updated API references and the new "Xbox Live programming guide".</span></span>

<span data-ttu-id="27766-115">バグ修正:</span><span class="sxs-lookup"><span data-stu-id="27766-115">Bug fixes:</span></span>

* <span data-ttu-id="27766-116">リアルタイム アクティビティ サービスでサブスクリプションを削除するときにクラッシュする</span><span class="sxs-lookup"><span data-stu-id="27766-116">Crash while removing subscriptions in Real Time Activity Service</span></span>
* <span data-ttu-id="27766-117">ゲスト アカウントでのログイン時にクラッシュする</span><span class="sxs-lookup"><span data-stu-id="27766-117">Crash when logging in with a guest account</span></span>
* <span data-ttu-id="27766-118">ネットワーク ケーブルを取り外したときのアクセス違反</span><span class="sxs-lookup"><span data-stu-id="27766-118">Access violation when unplugging the network cable</span></span>
* <span data-ttu-id="27766-119">トンネル障害により C++ API でエラー コードが生成されるようになった</span><span class="sxs-lookup"><span data-stu-id="27766-119">Tunnel failures now give an error code in the C++ APIs</span></span>
* <span data-ttu-id="27766-120">TitleStorageService::DownloadBlobAsync による ETag の問題</span><span class="sxs-lookup"><span data-stu-id="27766-120">ETag issue with TitleStorageService::DownloadBlobAsync</span></span>
* <span data-ttu-id="27766-121">サンプル アプリのさまざまなバグ修正</span><span class="sxs-lookup"><span data-stu-id="27766-121">Various bug fixes for sample apps.</span></span>
