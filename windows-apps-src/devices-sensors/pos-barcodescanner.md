---
author: TerryWarwick
title: バーコード スキャナー
description: この記事では、UWP アプリで使用可能なバーコード スキャナー機能と、その使用方法を示すハウツー記事へのリンクを示します。
ms.author: jken
ms.date: 08/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 1cd6f8391de9375ddd1c20471dd10c37e99f782f
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4506864"
---
# <a name="barcode-scanner"></a><span data-ttu-id="248a8-104">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="248a8-104">Barcode scanner</span></span>

<span data-ttu-id="248a8-105">このセクションでは、バーコード スキャナーを使用するユニバーサル Windows プラットフォーム (UWP) アプリを作成するための指針を示します。</span><span class="sxs-lookup"><span data-stu-id="248a8-105">This section provides guidance for creating Universal Windows Platform (UWP) apps that use a barcode scanner.</span></span>

## <a name="in-this-section"></a><span data-ttu-id="248a8-106">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="248a8-106">In this section</span></span>

|<span data-ttu-id="248a8-107">トピック</span><span class="sxs-lookup"><span data-stu-id="248a8-107">Topic</span></span> |<span data-ttu-id="248a8-108">説明</span><span class="sxs-lookup"><span data-stu-id="248a8-108">Description</span></span> |
|------|------------|
| [<span data-ttu-id="248a8-109">バーコード スキャナーの構成</span><span class="sxs-lookup"><span data-stu-id="248a8-109">Configure a barcode scanner</span></span>](../devices-sensors/pos-barcodescanner-configure.md)  | <span data-ttu-id="248a8-110">目的の用途のバーコード スキャナーを構成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="248a8-110">Learn how to configure a barcode scanner for the intended application.</span></span> |
| [<span data-ttu-id="248a8-111">ソフトウェア トリガーの使用</span><span class="sxs-lookup"><span data-stu-id="248a8-111">Use a software trigger</span></span>](../devices-sensors/pos-barcodescanner-software-trigger.md) | <span data-ttu-id="248a8-112">ソフトウェアからスキャンの動作を制御する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="248a8-112">Learn how to control the act of scanning from software.</span></span> |
| [<span data-ttu-id="248a8-113">シンボル体系の操作</span><span class="sxs-lookup"><span data-stu-id="248a8-113">Working with symbologies</span></span>](pos-barcodescanner-symbologies.md) | <span data-ttu-id="248a8-114">バーコード スキャナーがサポートするバーコードの種類を特定し、アプリケーションからバーコード スキャナーで認識されるバーコードの種類を制御する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="248a8-114">Learn how to determine the  barcode types a barcode scanner supports and control which barcode types are recognized by the barcode scanner from your application.</span></span> |
| [<span data-ttu-id="248a8-115">バーコード データの取得と理解</span><span class="sxs-lookup"><span data-stu-id="248a8-115">Obtain and understand barcode data</span></span>](pos-barcodescanner-scan-data.md) | <span data-ttu-id="248a8-116">取得し、データを解釈しバーコードをスキャンする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="248a8-116">Learn how to obtain and interpret the barcode data that you scan.</span></span> |
| [<span data-ttu-id="248a8-117">カメラ バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="248a8-117">Camera Barcode Scanner</span></span>](pos-camerabarcode.md) | <span data-ttu-id="248a8-118">ユニバーサル Windows プラットフォーム アプリケーションから標準のカメラ レンズでバーコードを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="248a8-118">Read barcodes through a standard camera lens from a Universal Windows Platform application.</span></span> <span data-ttu-id="248a8-119">Windows 10 April 2018 Update (ビルド 17134 以降) が必要です。</span><span class="sxs-lookup"><span data-stu-id="248a8-119">Requires Windows 10 April 2018 Update (build 17134 or later).</span></span> |
|
 
