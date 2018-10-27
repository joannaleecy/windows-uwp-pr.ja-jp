---
title: Xbox Live Trace Analyzer
author: KevinAsgari
description: Xbox Live Trace Analyzer を使ってタイトルにより行われるサービス呼び出しを確認する方法について説明します。
ms.assetid: b4490fae-d554-403d-bbbc-601af38af0ef
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス呼び出し, テスト, trace analyzer
ms.localizationpriority: medium
ms.openlocfilehash: 0eaec6d830dece484d3300ea244f05bf2add5a60
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5683142"
---
# <a name="xbox-live-trace-analyzer"></a><span data-ttu-id="045f8-104">Xbox Live Trace Analyzer</span><span class="sxs-lookup"><span data-stu-id="045f8-104">Xbox Live Trace Analyzer</span></span>

<span data-ttu-id="045f8-105">Xbox Live Services API では、タイトル デベロッパーがすべてのサービス呼び出しをキャプチャーし、呼び出しパターンに違反がないかオフラインで分析できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="045f8-105">The Xbox Live Services API now allows title developers to capture all service calls and then analyze them offline for any violations in calling patterns.</span></span> <span data-ttu-id="045f8-106">サービス呼び出しトレースをアクティベーションするには、xbtrace コマンド ライン ツールで利用できる新しい機能を使用するか、またはより高度なシナリオ向けのプロトコル アクティベーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="045f8-106">Service call tracing can be activated by using new functionality available in the xbtrace command line tool, or through protocol activation for more advanced scenarios.</span></span> <span data-ttu-id="045f8-107">また、タイトル コードから直接サービス呼び出しトレースをアクティベーションすることもできます。</span><span class="sxs-lookup"><span data-stu-id="045f8-107">Activating service call tracking directly from title code is also supported.</span></span> <span data-ttu-id="045f8-108">Xbox Live ツール パッケージの一部として Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe) と呼ばれるオフライン分析ツールが見つかりません[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools)します。</span><span class="sxs-lookup"><span data-stu-id="045f8-108">The offline analysis tool, called the Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe) can be found as part of the Xbox Live Tools package from [https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools).</span></span>


## <a name="gather-logs-and-analyze-the-service-calls"></a><span data-ttu-id="045f8-109">ログの収集とサービス呼び出しの分析</span><span class="sxs-lookup"><span data-stu-id="045f8-109">Gather logs and analyze the service calls</span></span>

<span data-ttu-id="045f8-110">サービス呼び出しの記録を含むログを収集し、Xbox Live Trace Analyzer を使用してそれらを分析するために必要な手順は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="045f8-110">The following steps are required to gather the logs that contain the record of your service calls and analyze them using Xbox Live Trace Analyzer.</span></span>

1.  <span data-ttu-id="045f8-111">Xbox 開発キット (XDK) の July 2015 以降に含まれているバージョンの Xbox Live Services API を使用してタイトルをビルドします。</span><span class="sxs-lookup"><span data-stu-id="045f8-111">Build your title using the version of the Xbox Live Services API that is included in the July 2015 or newer version of the Xbox Developer Kit (XDK).</span></span>
2.  <span data-ttu-id="045f8-112">後述の説明に従って、タイトルを変更してトレースを有効にします。</span><span class="sxs-lookup"><span data-stu-id="045f8-112">Modify your title to enable tracing as described below.</span></span>
3.  <span data-ttu-id="045f8-113">タイトルを配置します。</span><span class="sxs-lookup"><span data-stu-id="045f8-113">Deploy your title.</span></span>
4.  <span data-ttu-id="045f8-114">タイトルを起動して、Xbox Live Services API を初期化するために Xbox Live サービスを少なくとも 1 回呼び出します。</span><span class="sxs-lookup"><span data-stu-id="045f8-114">Launch the title and make at least one call to Xbox Live Services in order to initialize the Xbox Live Services API.</span></span>
5.  <span data-ttu-id="045f8-115">タイトル内の分析したいポイントからトレースを開始します。</span><span class="sxs-lookup"><span data-stu-id="045f8-115">Start tracing at the point in your title you'd like to analyze.</span></span>
6.  <span data-ttu-id="045f8-116">トレースを停止します。</span><span class="sxs-lookup"><span data-stu-id="045f8-116">Stop tracing.</span></span>
7.  <span data-ttu-id="045f8-117">開発用 PC で Xbox Live Trace Analyzer ツールを実行し、出力を確認します。</span><span class="sxs-lookup"><span data-stu-id="045f8-117">Run the Xbox Live Trace Analyzer tool on your development PC and view the output.</span></span>

## <a name="starting-and-stopping-tracing"></a><span data-ttu-id="045f8-118">トレースの開始と停止</span><span class="sxs-lookup"><span data-stu-id="045f8-118">Starting and stopping tracing</span></span>

<span data-ttu-id="045f8-119">トレースを開始および停止するには以下の 3 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="045f8-119">There are three ways to start and stop tracing:</span></span>

1.  <span data-ttu-id="045f8-120">一連の Xbox Live Services API をタイトルから直接呼び出す。</span><span class="sxs-lookup"><span data-stu-id="045f8-120">You can call a set of Xbox Live Services APIs directly from your title.</span></span>
2.  <span data-ttu-id="045f8-121">*xbtrace* コマンド ライン ツールを使用する。</span><span class="sxs-lookup"><span data-stu-id="045f8-121">You can use the *xbtrace* command line tool.</span></span>
3.  <span data-ttu-id="045f8-122">*アプリケーション管理 (xbapp.exe)* コマンド ライン ツールを通じてプロトコル アクティベーションを使用する。</span><span class="sxs-lookup"><span data-stu-id="045f8-122">You can use protocol activation through the *Application Management (xbapp.exe)* command line tool.</span></span>


### <a name="starting-and-stopping-tracing-directly-from-your-title"></a><span data-ttu-id="045f8-123">タイトルから直接トレースを開始および停止する</span><span class="sxs-lookup"><span data-stu-id="045f8-123">Starting and stopping tracing directly from your title</span></span>

<span data-ttu-id="045f8-124">タイトルから直接トレースを開始および停止するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="045f8-124">To start tracing directly from your title, you must do the following:</span></span>

1.  <span data-ttu-id="045f8-125">`Microsoft::Xbox::Services::Experimental` 名前空間で、`EnableServiceCallTracking` クラスの `ServiceCallTrackerSettings` プロパティを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="045f8-125">In the `Microsoft::Xbox::Services::Experimental` namespace, set the `EnableServiceCallTracking` property of the `ServiceCallTrackerSettings` class to true.</span></span>
2.  <span data-ttu-id="045f8-126">`StartServiceCallTracking()` を呼び出して、サービス呼び出しトレースを開始します。</span><span class="sxs-lookup"><span data-stu-id="045f8-126">Call `StartServiceCallTracking()` to start tracing service calls.</span></span>
3.  <span data-ttu-id="045f8-127">`StopServiceCallTracking()` を呼び出して、サービス呼び出しトレースを停止します。</span><span class="sxs-lookup"><span data-stu-id="045f8-127">Call `StopServiceCallTracking()` to stop tracing service calls.</span></span>
4.  <span data-ttu-id="045f8-128">トレースの停止後、Xbox Live Trace Analyzer を使用して分析するために、*ファイル コピー (xbcp.exe)* または *Xbox One Neighborhood* を使用して、結果のトレース ファイルを本体のデベロッパー スクラッチ ドライブから PC にコピーします。</span><span class="sxs-lookup"><span data-stu-id="045f8-128">After tracing is stopped, copy the resulting trace file from the developer scratch drive on the console back to your PC by using either *File Copy (xbcp.exe)* or the *Xbox One Neighborhood* in order to analyze it by using Xbox Live Trace Analyzer.</span></span>

### <a name="starting-and-stopping-tracing-by-using-the-xbtrace-command-line-tool"></a><span data-ttu-id="045f8-129">xbtrace コマンド ライン ツールを使用してトレースを開始および停止する</span><span class="sxs-lookup"><span data-stu-id="045f8-129">Starting and stopping tracing by using the xbtrace command line tool</span></span>

<span data-ttu-id="045f8-130">トレースを開始する最も簡便な方法は、トレースの種類に xboxliveservices を指定して xbtrace コマンド ライン ツールを使用することです。</span><span class="sxs-lookup"><span data-stu-id="045f8-130">The most convenient and straightforward way to start tracing is to use the xbtrace command line tool with the xboxliveservices trace type.</span></span> <span data-ttu-id="045f8-131">xbTrace を使用する場合、結果のトレース ファイルは自動的に PC にコピーされます。</span><span class="sxs-lookup"><span data-stu-id="045f8-131">When you use xbTrace, the resulting trace file is copied back to your PC for you.</span></span>

<span data-ttu-id="045f8-132">xbtrace によるトレースの開始と停止はプロトコル アクティベーションに依存します。</span><span class="sxs-lookup"><span data-stu-id="045f8-132">Starting and stopping traces using xbtrace relies on protocol activation.</span></span> <span data-ttu-id="045f8-133">xbtrace を使用してトレースを開始および停止する前に、`RegisterForProtcolActivation` クラスで `ServiceCallTrackerSettings` メソッドを呼び出してプロトコル アクティベーションを初期化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="045f8-133">Before using xbtrace to start and stop tracing, you must initialize protocol activation by calling the `RegisterForProtcolActivation` method on the `ServiceCallTrackerSettings` class.</span></span>

<span data-ttu-id="045f8-134">次の例は、xbTrace を使用して Xbox Live サービスのトレースを開始および停止する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="045f8-134">The following example shows how to start and stop an Xbox Live Services trace by using xbTrace:</span></span>

    xbtrace start xboxliveservices
    xbtrace stop


<span data-ttu-id="045f8-135">xbtrace でトレースを開始および停止するには、タイトルが実行されており、プロトコル アクティベーションが初期化されている必要があることを忘れないでください。</span><span class="sxs-lookup"><span data-stu-id="045f8-135">Remember that your title must be running and protocol activation must be initialized before you can start and stop tracing with xbtrace.</span></span> <span data-ttu-id="045f8-136">トレースの停止後、xbtrace によってトレース ファイルが開発用 PC にコピーされ、"xbtrace" とタイムスタンプを含む名前のディレクトリに配置されます。</span><span class="sxs-lookup"><span data-stu-id="045f8-136">After tracing is stopped, xbtrace copies the trace file to your development PC and places it in a directory whose name includes "xbtrace" and a timestamp.</span></span> <span data-ttu-id="045f8-137">このディレクトリの名前は、xbtrace の \[etlfile\] オプションを使用して変更することができます。</span><span class="sxs-lookup"><span data-stu-id="045f8-137">The name of this directory can be overridden using \[etlfile\] option to xbtrace.</span></span>

<a name="starting-and-stopping-tracing-by-using-protocol-activation"></a><span data-ttu-id="045f8-138">プロトコル アクティベーションを使用してトレースを開始および停止する</span><span class="sxs-lookup"><span data-stu-id="045f8-138">Starting and stopping tracing by using protocol activation</span></span>
----------------------------------------------------------

<span data-ttu-id="045f8-139">"xbApp launch" のプロトコル アクティベーション機能を使用してトレースを制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="045f8-139">Tracing can also be controlled by using the protocol activation features of "xbApp launch".</span></span> <span data-ttu-id="045f8-140">プロトコル アクティベーションを通じてトレースを開始および停止するには、タイトルの titleid がわかっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="045f8-140">You must know your title's titleid to start and stop tracing via protocol activation.</span></span> <span data-ttu-id="045f8-141">titleid はタイトルのマニフェスト ファイル内にあります。</span><span class="sxs-lookup"><span data-stu-id="045f8-141">You can find your title id in your title's manifest file.</span></span> <span data-ttu-id="045f8-142">"serviceCallTracking" パラメーターを含む URI を通じてトレースを制御できます。</span><span class="sxs-lookup"><span data-stu-id="045f8-142">Tracing is controlled through URIs that contain "serviceCallTracking" parameter.</span></span> <span data-ttu-id="045f8-143">次の例は、titleid が 12345678 のタイトルのトレースを開始および停止する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="045f8-143">The following examples show how to start and stop tracing for a title whose title id is 12345678:</span></span>

    xbapp launch "ms-xbl-12345678://serviceCallTracking?state=start"
    xbapp launch "ms-xbl-12345678://serviceCallTracking?state=stop"

<span data-ttu-id="045f8-144">プロトコル アクティベーションを使用する場合、結果のトレース ファイルは本体のデベロッパー スクラッチ ドライブに保存されます。</span><span class="sxs-lookup"><span data-stu-id="045f8-144">When you use protocol activation, the resulting trace file is stored on the developer scratch drive on the console.</span></span> <span data-ttu-id="045f8-145">そのファイルを、xbcp または Xbox One Neighborhood を使用して PC にコピーする必要があります。</span><span class="sxs-lookup"><span data-stu-id="045f8-145">You'll need to copy the file back to your PC using either xbcp or the Xbox One Neighborhood.</span></span> <span data-ttu-id="045f8-146">xbtrace を使用する場合のようにファイルが自動的に PC にコピーされることはありません。</span><span class="sxs-lookup"><span data-stu-id="045f8-146">The file is not automatically copied back to the PC as it is when using xbtrace.</span></span>

<span data-ttu-id="045f8-147">プロトコル アクティベーションでは、verbosity などの追加のトレース パラメーターを設定できます。</span><span class="sxs-lookup"><span data-stu-id="045f8-147">Protocol activation allows you to set additional trace parameters, such as a verbosity.</span></span> <span data-ttu-id="045f8-148">verbosity には quiet、diagnostic、detailed、minimal の 4 つのレベルを設定できます。</span><span class="sxs-lookup"><span data-stu-id="045f8-148">Four levels of verbosity are supported: quiet, diagnostic, detailed and minimal.</span></span> <span data-ttu-id="045f8-149">次の例は、verbosity のレベルを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="045f8-149">The following example shows how to set a verbosity level:</span></span>

    xbapp launch "ms-xbl-12345678://serviceCallTracking?verbosity=diagnostic"

## <a name="analyze-the-trace-file"></a><span data-ttu-id="045f8-150">トレース ファイルを分析する</span><span class="sxs-lookup"><span data-stu-id="045f8-150">Analyze the trace file</span></span>

<span data-ttu-id="045f8-151">トレース ファイルが PC にコピーされたら、GNDP の Xbox Live Trace Analyzer ツールを使用して、タイトルでの Xbox Live サービスの使用状況を分析できます。</span><span class="sxs-lookup"><span data-stu-id="045f8-151">After the trace file has been copied back to your PC, you can use the Xbox Live Trace Analyzer tool on GNDP to analyze your title's use of Xbox Live Services.</span></span> <span data-ttu-id="045f8-152">Xbox Live Trace Analyzer ツールを呼び出してその出力を解釈する方法の詳細については、Game Developer Network でこのツールに付属するドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="045f8-152">See the documentation included with the Xbox Live Trace Analyzer tool on Game Developer Network for a description of how to invoke the tool and interpret its output.</span></span> <span data-ttu-id="045f8-153">また、コマンド ライン オプションの -? </span><span class="sxs-lookup"><span data-stu-id="045f8-153">You can also run XBLTraceAnalyzer.exe with the command line option of -?</span></span> <span data-ttu-id="045f8-154">または -h を指定して XBLTraceAnalyzer.exe を実行することによって、コマンド ライン ヘルプを参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="045f8-154">or -h to view command line help.</span></span>
