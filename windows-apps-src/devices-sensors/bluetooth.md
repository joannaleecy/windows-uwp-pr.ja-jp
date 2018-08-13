---
author: msatranjr
ms.assetid: 404783BA-8859-4BFB-86E3-3DD2042E66F5
title: Bluetooth
description: このセクションでは、RFCOMM、GATT、低エネルギー (LE) アドバタイズを使う方法を含め、ユニバーサル Windows プラットフォーム (UWP) アプリに Bluetooth を統合する方法に関する記事を取り上げています。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: da12a9121cf54334cef1eccf8b41b43683126eff
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "299716"
---
# <a name="bluetooth"></a><span data-ttu-id="f5234-104">Bluetooth</span><span class="sxs-lookup"><span data-stu-id="f5234-104">Bluetooth</span></span>
<span data-ttu-id="f5234-105">このセクションには、どこからでも Windows プラットフォーム (UWP) アプリに Bluetooth を統合する方法についての記事が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f5234-105">This section contains articles on how to integrate Bluetooth into Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="f5234-106">アプリの管理を実装することもできますが 2 つの異なる bluetooth テクノロジがあります。</span><span class="sxs-lookup"><span data-stu-id="f5234-106">There are two different bluetooth technologies that you can choose to implement in your app.</span></span>

## <a name="classic-bluetooth-rfcomm"></a><span data-ttu-id="f5234-107">クラシック Bluetooth (RFCOMM)</span><span class="sxs-lookup"><span data-stu-id="f5234-107">Classic Bluetooth (RFCOMM)</span></span>
<span data-ttu-id="f5234-108">Bluetooth 者の前にデバイスよく使われるこのプロトコル Bluetooth を使って通信します。</span><span class="sxs-lookup"><span data-stu-id="f5234-108">Before Bluetooth LE, devices commonly used this protocol to communicate using Bluetooth.</span></span> <span data-ttu-id="f5234-109">このプロトコルはシンプルな省の必要はありません。 デバイスとデバイス通信に便利です。</span><span class="sxs-lookup"><span data-stu-id="f5234-109">This protocol is simple and useful for device-to-device communication without the need of energy savings.</span></span> <span data-ttu-id="f5234-110">サンプルのコードを含む、このプロトコルの詳細については、 [Bluetooth RFCOMM](send-or-receive-files-with-rfcomm.md)トピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f5234-110">For more information about this protocol, including code samples, see the [Bluetooth RFCOMM](send-or-receive-files-with-rfcomm.md) topic.</span></span>

## <a name="bluetooth-low-energy-le"></a><span data-ttu-id="f5234-111">Bluetooth 低エネルギー (LE)</span><span class="sxs-lookup"><span data-stu-id="f5234-111">Bluetooth Low-Energy (LE)</span></span>
<span data-ttu-id="f5234-112">Bluetooth 低エネルギー (LE) は、プロトコルの検出を効率的に使用エネルギーの使用状況の条件を持つデバイス間の通信を定義する仕様です。</span><span class="sxs-lookup"><span data-stu-id="f5234-112">Bluetooth Low Energy (LE) is a specification that defines protocols for discovery and communication between devices that have an efficient energy usage requirement.</span></span> <span data-ttu-id="f5234-113">サンプル コードなどの詳細については、 [Bluetooth 低エネルギー](bluetooth-low-energy-overview.md)トピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f5234-113">For more information including code samples, see the [Bluetooth Low Energy](bluetooth-low-energy-overview.md) topic.</span></span>

## <a name="see-also"></a><span data-ttu-id="f5234-114">関連項目</span><span class="sxs-lookup"><span data-stu-id="f5234-114">See Also</span></span>
- [<span data-ttu-id="f5234-115">Bluetooth に関する開発者向け FAQ</span><span class="sxs-lookup"><span data-stu-id="f5234-115">Bluetooth developer FAQ</span></span>](bluetooth-dev-faq.md)