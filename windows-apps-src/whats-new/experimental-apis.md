---
author: TylerMSFT
title: 試験的な API
description: 試験的な API について
ms.author: twhitney
ms.date: 11/13/2017
ms.topic: article
keywords: windows 10, uwp, 試験的, api
ms.localizationpriority: medium
ms.openlocfilehash: fe5fa437c5a1e564be07b7277de0f190d6eab862
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6042694"
---
# <a name="experimental-apis"></a><span data-ttu-id="27c88-104">試験的な API</span><span class="sxs-lookup"><span data-stu-id="27c88-104">Experimental APIs</span></span>

<span data-ttu-id="27c88-105">試験的な API は、設計の初期段階で使用され、所有者がフィードバックを反映したり、他のシナリオに対するサポートを追加したりする場合に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="27c88-105">Experimental APIs are in the early stages of design and are likely to change as the owners incorporate feedback and add support for additional scenarios.</span></span>

<span data-ttu-id="27c88-106">これらの API は、[Windows Insider SDK](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) を利用して、外部でフライトされます。そのため、API が正式なプラットフォームに組み込まれる前に、開発者は API を試したり、フィードバックを提供したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="27c88-106">These APIs are flighted externally using [Windows Insider SDKs](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) so that developers can try them out and provide feedback before they become part of the official platform.</span></span> <span data-ttu-id="27c88-107">これらの API がフライトされている場合は、安定性や問題への対応は保証されません。</span><span class="sxs-lookup"><span data-stu-id="27c88-107">While they are flighted, there is no promise of stability or commitment.</span></span>

## <a name="consuming-experimental-apis"></a><span data-ttu-id="27c88-108">試験的な API の使用</span><span class="sxs-lookup"><span data-stu-id="27c88-108">Consuming experimental APIs</span></span>
<span data-ttu-id="27c88-109">Intellisense を利用すると、API が試験的なものであるかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="27c88-109">Intellisense will let you know if an API is experimental.</span></span> <span data-ttu-id="27c88-110">また、試験的な API を使用したときに、"評価のみを目的としており、今後の更新プログラムで変更または削除されることがあります" などのコンパイラの警告が表示されます。</span><span class="sxs-lookup"><span data-stu-id="27c88-110">You will also get a compiler warning when you use an experimental API such as "... is for evaluation purposes only and is subject to change or removal in future updates".</span></span>

<span data-ttu-id="27c88-111">これらの警告は、実稼働プロジェクトで試験的な API に対する依存関係を作成するを防ぐ場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="27c88-111">These warnings help protect you from creating dependencies on experimental APIs in production projects.</span></span> <span data-ttu-id="27c88-112">試験的なロジェクトでは、これらの警告を無視したり、無効にしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="27c88-112">For experimental projects, you can ignore or disable these warnings.</span></span>

<span data-ttu-id="27c88-113">既定では、これらの API は実行時に無効になっており、これらの API を呼び出すとランタイム例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="27c88-113">By default, these APIs are disabled at runtime and calling them will result in a runtime exception.</span></span> <span data-ttu-id="27c88-114">このもう一つのセーフガードにより、不注意による依存関係の作成や、試験的な API を使用するアプリの広範な配布を防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="27c88-114">This is another safeguard to help prevent inadvertent dependencies and broad distribution of apps that consume experimental APIs.</span></span>

<span data-ttu-id="27c88-115">これらの API を試験用に有効にするには、[Windows デバイス ポータル (WDP)](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal) 機能のプラグインをターゲット デバイスで使用し、呼び出す API に対応する機能を有効にします。</span><span class="sxs-lookup"><span data-stu-id="27c88-115">To enable these APIs for experimentation, use the [Windows Device Portal (WDP)](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal) Features plug-in on the target device to enable the feature corresponding to the API you want to call.</span></span>

<span data-ttu-id="27c88-116">特定の試験的な API に関するドキュメントは、API を所有するチームの裁量に任されています。</span><span class="sxs-lookup"><span data-stu-id="27c88-116">Documentation for a particular experimental API is at the discretion of the team that owns it.</span></span>

## <a name="providing-feedback"></a><span data-ttu-id="27c88-117">フィードバックの提供</span><span class="sxs-lookup"><span data-stu-id="27c88-117">Providing feedback</span></span>

<span data-ttu-id="27c88-118">試験的な API を試し、フィードバックを提供する場合は、[Windows フィードバック Hub](https://support.microsoft.com/en-us/help/4021566/windows-10-send-feedback-to-microsoft-with-feedback-hub-app) の **"開発者向けプラットフォーム"** カテゴリをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="27c88-118">If you've tried an experimental API and would like to provide feedback, use the **Developer Platform** category in the [Windows Feedback Hub](https://support.microsoft.com/en-us/help/4021566/windows-10-send-feedback-to-microsoft-with-feedback-hub-app).</span></span>