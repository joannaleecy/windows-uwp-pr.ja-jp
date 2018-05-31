---
author: TerryWarwick
title: カメラ バーコード スキャナー
description: この記事では、UWP アプリで使用可能なカメラ バーコード スキャナー機能と、その使用方法を示すハウツー記事へのリンクを示します。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: dff05e8909c2afd2bac055eead87f4b66892109b
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1833245"
---
# <a name="camera-barcode-scanner"></a><span data-ttu-id="e4188-104">カメラ バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="e4188-104">Camera barcode scanner</span></span>
<span data-ttu-id="e4188-105">カメラ バーコード スキャナーは、Windows によって、コンピューターに接続されているカメラとソフトウェア デコーダーがペアリングされたときに動的に作成されます。</span><span class="sxs-lookup"><span data-stu-id="e4188-105">A camera barcode scanner is created dynamically as Windows pairs the camera(s) attached to your computer with a software decoder.</span></span>  <span data-ttu-id="e4188-106">カメラとデコーダーのペアはそれぞれ完全な機能を持つバーコード スキャナーです。</span><span class="sxs-lookup"><span data-stu-id="e4188-106">Each camera - decoder pair is a fully functional barcode scanner.</span></span>   

## <a name="in-this-section"></a><span data-ttu-id="e4188-107">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="e4188-107">In this section</span></span>
|<span data-ttu-id="e4188-108">トピック</span><span class="sxs-lookup"><span data-stu-id="e4188-108">Topic</span></span> |<span data-ttu-id="e4188-109">説明</span><span class="sxs-lookup"><span data-stu-id="e4188-109">Description</span></span> |
|------|------------|
| [<span data-ttu-id="e4188-110">システム要件</span><span class="sxs-lookup"><span data-stu-id="e4188-110">System Requirements</span></span>](pos-camerabarcode-system-requirements.md)  | <span data-ttu-id="e4188-111">カメラ バーコード スキャナーをサポートする Windows エディションと、バーコードを正常に読み取るためのカメラの要件の一覧です。</span><span class="sxs-lookup"><span data-stu-id="e4188-111">List of Windows editions that support camera barcode scanner as well as camera requirements to successfully read barcodes.</span></span> |
| [<span data-ttu-id="e4188-112">概要</span><span class="sxs-lookup"><span data-stu-id="e4188-112">Getting Started</span></span>](pos-camerabarcode-get-started.md)              | <span data-ttu-id="e4188-113">カメラ バーコード スキャナーを使用する手順の概要です。</span><span class="sxs-lookup"><span data-stu-id="e4188-113">Step by step introduction to camera barcode scanner</span></span> |
| [<span data-ttu-id="e4188-114">プレビューのホスト</span><span class="sxs-lookup"><span data-stu-id="e4188-114">Hosting Preview</span></span>](pos-camerabarcode-hosting-preview.md)          | <span data-ttu-id="e4188-115">アプリケーションでカメラ バーコード スキャナーのプレビューをホストする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e4188-115">Learn how to host the preview for camera barcode scanner in your application</span></span> |
| [<span data-ttu-id="e4188-116">有効化または無効化</span><span class="sxs-lookup"><span data-stu-id="e4188-116">Enable or Disable</span></span>](pos-camerabarcode-enable-disable.md)         | <span data-ttu-id="e4188-117">Windows 10 に付属する既定のソフトウェア デコーダーを有効または無効にする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e4188-117">Learn how to enable or disable the default software decoder that ships with Windows 10</span></span> |
| [<span data-ttu-id="e4188-118">サポートされているシンボル体系。</span><span class="sxs-lookup"><span data-stu-id="e4188-118">Supported Symbologies</span></span>](pos-camerabarcode-symbologies.md) | <span data-ttu-id="e4188-119">このトピックでは、Windows 10 に付属しているソフトウェア バーコード デコーダーでサポートされている各シンボル体系のサンプル バーコードを示します。UPC/EAN、Code 39、Code 128、Interleaved 2 of 5、Databar Omnidirectional、Databar Stacked、QR コード、GS1DWCode などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e4188-119">This topic provides sample barcodes for each of the symbologies supported by the software barcode decoder that ships with Windows 10, including: UPC/EAN, Code 39, Code 128, Interleaved 2 of 5, Databar Omnidirectional, Databar Stacked, QR Code and GS1DWCode.</span></span> |
| 

> [!NOTE]
> <span data-ttu-id="e4188-120">Windows 10 に付属するソフトウェア デコーダーは、[*Digimarc Corporation*](https://www.digimarc.com/) から無料で提供されています。</span><span class="sxs-lookup"><span data-stu-id="e4188-120">The software decoder built into Windows 10 is provided courtesy of  [*Digimarc Corporation*](https://www.digimarc.com/)</span></span>
