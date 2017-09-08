---
title: "ツール"
author: KevinAsgari
description: "Xbox Live 対応タイトルを開発およびテストするために用意されているツールについて説明します。"
ms.assetid: 380a29bf-41a7-4817-9c57-f48f2b824b52
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ツール"
ms.openlocfilehash: 0f41f81596ece36a03605ca58e5f521c036f4e0e
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="tools"></a><span data-ttu-id="57b7e-104">ツール</span><span class="sxs-lookup"><span data-stu-id="57b7e-104">Tools</span></span>

<span data-ttu-id="57b7e-105">ここでは、Xbox Live を使用するときに便利な、さまざまなツールについて説明します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-105">This section covers various tools that you can use to help you use Xbox Live.</span></span>

[<span data-ttu-id="57b7e-106">Xbox Live Trace Analyzer</span><span class="sxs-lookup"><span data-stu-id="57b7e-106">Xbox Live Trace Analyzer</span></span>](analyze-service-calls.md)  
<span data-ttu-id="57b7e-107">Xbox Live Services API では、タイトル デベロッパーがすべてのサービス呼び出しをキャプチャーし、呼び出しパターンに違反がないかオフラインで分析できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="57b7e-107">The Xbox Live Services API now allows title developers to capture all service calls and then analyze them offline for any violations in calling patterns.</span></span> <span data-ttu-id="57b7e-108">サービス呼び出しトレースをアクティベーションするには、xbtrace コマンド ライン ツールで利用できる新しい機能を使用するか、またはより高度なシナリオ向けのプロトコル アクティベーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-108">Service call tracing can be activated by using new functionality available in the xbtrace command line tool, or through protocol activation for more advanced scenarios.</span></span> <span data-ttu-id="57b7e-109">また、タイトル コードから直接サービス呼び出しトレースをアクティベーションすることもできます。</span><span class="sxs-lookup"><span data-stu-id="57b7e-109">Activating service call tracking directly from title code is also supported.</span></span> <span data-ttu-id="57b7e-110">Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe) と呼ばれるオフライン分析ツールは Game Developer Network で入手できます。</span><span class="sxs-lookup"><span data-stu-id="57b7e-110">The offline analysis tool, called the Xbox Live Trace Analyzer (XBLTraceAnalyzer.exe), is available on Game Developer Network.</span></span>

[<span data-ttu-id="57b7e-111">Xbox Live Account Tool</span><span class="sxs-lookup"><span data-stu-id="57b7e-111">Xbox Live Account Tool</span></span>](xbox-live-account-tool.md)   
<span data-ttu-id="57b7e-112">Xbox Live Account Tool は、タイトル デベロッパーが既存のデベロッパー アカウントをゲーム シナリオのテスト用にセットアップするときに使用できるように作られています。</span><span class="sxs-lookup"><span data-stu-id="57b7e-112">The Xbox Live Account Tool is a tool designed to help title developers set up existing dev accounts for testing game scenarios.</span></span> <span data-ttu-id="57b7e-113">たとえば、Xbox Live Account Tool を使用すると、デベロッパー アカウントのゲーマータグを変更したり、アカウントのフレンド リストに 1000 人のフォロワーをすばやく追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="57b7e-113">For example, you can use Xbox Live Account Tool to change a dev account's gamertag, or quickly add 1000 followers to an account's friends list.</span></span>

[<span data-ttu-id="57b7e-114">Xbox Live PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="57b7e-114">Xbox Live PowerShell Module</span></span>](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md)  
<span data-ttu-id="57b7e-115">XboxlivePSModule には、Xbox Live 開発に役立つさまざまなユーティリティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="57b7e-115">XboxlivePSModule contains various utilities to help Xbox Live development.</span></span>
* <span data-ttu-id="57b7e-116">[PowerShell ギャラリー](https://www.powershellgallery.com/packages/XboxlivePSModule)からこのモジュールを使うには、PowerShell ウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="57b7e-116">To consume it from [PowerShell Gallery](https://www.powershellgallery.com/packages/XboxlivePSModule), open a PowerShell window:</span></span>
    1. <span data-ttu-id="57b7e-117">次のコマンドを実行して、モジュールをダウンロードしてインストールします。</span><span class="sxs-lookup"><span data-stu-id="57b7e-117">Download and install the module:</span></span> `Install-Module XboxlivePSModule -Scope CurrentUser`
    2. <span data-ttu-id="57b7e-118">次のコマンドを実行して使用を開始します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-118">Start using by running</span></span> `Import-Module XboxlivePSModule`
    3. <span data-ttu-id="57b7e-119">コマンドレット Set-XblSandbox XDKS.1、Get-XblSandbox を実行します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-119">Run cmdlets, i.e. Set-XblSandbox XDKS.1, Get-XblSandbox</span></span>

* <span data-ttu-id="57b7e-120">ダウンロードした zip ファイルを使うには、PowerShell ウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="57b7e-120">To consume it from downloaded zip file, open a PowerShell window,</span></span>
    1. <span data-ttu-id="57b7e-121">以下のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-121">Run</span></span> `Import-Module <path to unzipped folder>\XboxLivePsModule\XboxLivePsModule.psd1`
    2. <span data-ttu-id="57b7e-122">コマンドレット Set-XblSandbox XDKS.1、Get-XblSandbox を実行します。</span><span class="sxs-lookup"><span data-stu-id="57b7e-122">Run cmdlets, i.e. Set-XblSandbox XDKS.1, Get-XblSandbox</span></span>

<span data-ttu-id="57b7e-123">使用可能なコマンドレットと使用方法について詳しくは、[github](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md) のオンライン ドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="57b7e-123">For more details for available cmdlets and usage, please visit online doc from [github](https://github.com/Microsoft/xbox-live-powershell-module/blob/master/docs/XboxLivePsModule.md)</span></span>
