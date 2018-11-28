---
ms.assetid: 70667353-152B-4B18-92C1-0178298052D4
title: 書式設定における Epson ESC/POS
description: POS プリンターで、ESC/POS コマンド言語を使用して、太字、倍角文字など、テキストの書式を設定する方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 11467a45021da7898c2b617e3b1b01312c795c4c
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7967063"
---
# <a name="epson-escpos-with-formatting"></a><span data-ttu-id="0edce-104">書式設定における Epson ESC/POS</span><span class="sxs-lookup"><span data-stu-id="0edce-104">Epson ESC/POS with formatting</span></span>


**<span data-ttu-id="0edce-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="0edce-105">Important APIs</span></span>**

-   [**<span data-ttu-id="0edce-106">PointofService プリンター</span><span class="sxs-lookup"><span data-stu-id="0edce-106">PointofService Printer</span></span>**](https://msdn.microsoft.com/library/windows/apps/Mt426652)
-   [**<span data-ttu-id="0edce-107">Windows.Devices.PointOfService</span><span class="sxs-lookup"><span data-stu-id="0edce-107">Windows.Devices.PointOfService</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn298071)

<span data-ttu-id="0edce-108">POS プリンターで、ESC/POS コマンド言語を使用して、太字、倍角文字など、テキストの書式を設定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0edce-108">Learn how to use the ESC/POS command language to format text, such as bold and double size characters, for your Point of Service printer.</span></span>

## <a name="escpos-usage"></a><span data-ttu-id="0edce-109">ESC/POS の使い方</span><span class="sxs-lookup"><span data-stu-id="0edce-109">ESC/POS usage</span></span>

<span data-ttu-id="0edce-110">Windows Point of Service (POS) では、Epson の TM シリーズのプリンターなど、さまざまなプリンターを使用できます。サポートされているプリンターの完全な一覧は、[PointofService プリンター](https://msdn.microsoft.com/library/windows/apps/Mt426652)のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0edce-110">Windows Point of Service provides use of a variety of printers, including several Epson TM series printers (for a full list of supported printers, see the [PointofService Printer](https://msdn.microsoft.com/library/windows/apps/Mt426652) page).</span></span> <span data-ttu-id="0edce-111">Windows では、ESC/POS プリンター制御言語を使用した印刷をサポートしています。この制御言語により、お使いのプリンターと通信するときに、効率的で実用的なコマンドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0edce-111">Windows supports printing through the ESC/POS printer control language, which provides efficient and functional commands for communicating with your printer.</span></span>

<span data-ttu-id="0edce-112">ESC/POS は、Epson が開発したコマンド システムで、広範囲の POS プリンター システムで使用されています。どのプリンターにも適用可能にすることで、コマンド セットの非互換性を回避することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="0edce-112">ESC/POS is a command system created by Epson used across a wide range of POS printer systems, aimed at avoiding incompatible command sets by providing universal applicability.</span></span> <span data-ttu-id="0edce-113">現在のほとんどのプリンターでは、ESC/POS がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0edce-113">Most modern printers support ESC/POS.</span></span>

<span data-ttu-id="0edce-114">すべてのコマンドは、ESC 文字 (ASCII 27、16 進の 1B) または GS (ASCII 29、16 進の 1D) で始まり、その後にコマンドを指定する別の文字が続きます。</span><span class="sxs-lookup"><span data-stu-id="0edce-114">All commands start with the ESC character (ASCII 27, HEX 1B) or GS (ASCII 29, HEX 1D), followed by another character that specifies the command.</span></span> <span data-ttu-id="0edce-115">通常のテキストは単純にプリンターに送信され、改行で区切られます。</span><span class="sxs-lookup"><span data-stu-id="0edce-115">Normal text is simply sent to the printer, separated by line breaks.</span></span>

<span data-ttu-id="0edce-116">[**Windows PointOfService API**](https://msdn.microsoft.com/library/windows/apps/Dn298071) では、その機能の大半を **Print()** または **PrintLine()** メソッドを通して提供します。</span><span class="sxs-lookup"><span data-stu-id="0edce-116">The [**Windows PointOfService API**](https://msdn.microsoft.com/library/windows/apps/Dn298071) provides much of that functionality for you via the **Print()** or **PrintLine()** methods.</span></span> <span data-ttu-id="0edce-117">ただし、特定の書式を設定する、または特定のコマンドを送信するには、ESC/POS コマンドを使用して文字列として作成し、プリンターに送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0edce-117">However, to get certain formatting or to send specific commands, you must use ESC/POS commands, built as a string and sent to the printer.</span></span>

## <a name="example-using-bold-and-double-size-characters"></a><span data-ttu-id="0edce-118">文字および倍角文字を使用する例</span><span class="sxs-lookup"><span data-stu-id="0edce-118">Example using bold and double size characters</span></span>

<span data-ttu-id="0edce-119">次の例は、ESC/POS コマンドを使用して、太字および倍角文字で印刷する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0edce-119">The example below shows how to use ESC/POS commands to print in bold and double sized characters.</span></span> <span data-ttu-id="0edce-120">各コマンドが文字列として作成され、印刷ジョブの呼び出しに挿入されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="0edce-120">Note that each command is built as a string, then inserted into the printJob calls.</span></span>

```csharp
// … prior plumbing code removed for brevity
// this code assumed you've already created a receipt print job (printJob)
// and also that you've already checked the PosPrinter Capabilities to
// verify that the printer supports Bold and DoubleHighDoubleWide print modes

const string ESC = "\u001B";
const string GS = "\u001D";
const string InitializePrinter = ESC + "@";
const string BoldOn = ESC + "E" + "\u0001";
const string BoldOff = ESC + "E" + "\0";
const string DoubleOn = GS + "!" + "\u0011";  // 2x sized text (double-high + double-wide)
const string DoubleOff = GS + "!" + "\0";

printJob.Print(InitializePrinter);
printJob.PrintLine("Here is some normal text.");
printJob.PrintLine(BoldOn + "Here is some bold text." + BoldOff);
printJob.PrintLine(DoubleOn + "Here is some large text." + DoubleOff);

printJob.ExecuteAsync();
```

<span data-ttu-id="0edce-121">利用可能なコマンドなど、ESC/POS について詳しくは、[Epson ESC/POS に関する FAQ](http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0edce-121">For more information on ESC/POS, including available commands, check out the [Epson ESC/POS FAQ](http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf).</span></span> <span data-ttu-id="0edce-122">[**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/Dn298071) と利用可能な機能について詳しくは、MSDN の「[PointofService プリンター](https://msdn.microsoft.com/library/windows/apps/Mt426652)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0edce-122">For details on [**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/Dn298071) and all the available functionality, see [PointofService Printer](https://msdn.microsoft.com/library/windows/apps/Mt426652) on MSDN.</span></span>
