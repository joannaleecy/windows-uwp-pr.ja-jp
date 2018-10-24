---
title: エラー処理
author: KevinAsgari
description: Xbox Live サービス呼び出しを行ったときのエラーを処理する方法について説明します。
ms.assetid: e433dfbd-488b-44ff-8333-1dcf0329cd60
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, エラー, サービス呼び出し
ms.localizationpriority: medium
ms.openlocfilehash: c322239e65d019695b879e71032eee94dbcadc14
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5437051"
---
# <a name="error-handling"></a><span data-ttu-id="2f02f-104">エラー処理</span><span class="sxs-lookup"><span data-stu-id="2f02f-104">Error handling</span></span>

<span data-ttu-id="2f02f-105">サービス呼び出しを行うとき、開発者は特別な注意を払う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-105">Developers should take special care when making a service call.</span></span> <span data-ttu-id="2f02f-106">タイトルでは、ネットワーク呼び出しを行うときは常にエラーを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-106">Your title should always handle errors when making network calls.</span></span> <span data-ttu-id="2f02f-107">開発中に一貫して機能していたサービス呼び出しであっても、現実世界の環境では、さまざまな理由によってサービス呼び出しが失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-107">Even for service calls that have been working consistently during development, service calls can fail in real world environments for a number of different reasons.</span></span> <span data-ttu-id="2f02f-108">たとえば、以下の理由によって呼び出しが失敗する場合があります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-108">For example, your call may fail due to:</span></span>

* <span data-ttu-id="2f02f-109">ネットワークが使用できない。</span><span class="sxs-lookup"><span data-stu-id="2f02f-109">The network is not available.</span></span>
* <span data-ttu-id="2f02f-110">サービスがビジー状態で 503 HTTP ステータス コードが返される。</span><span class="sxs-lookup"><span data-stu-id="2f02f-110">The service is too busy, returning a 503 HTTP status code.</span></span>
* <span data-ttu-id="2f02f-111">要求が無効で 400 HTTP ステータス コードが返される。</span><span class="sxs-lookup"><span data-stu-id="2f02f-111">The request is not valid, returning a 400 HTTP status code.</span></span>
* <span data-ttu-id="2f02f-112">ユーザーが適切なアクセス許可を持っていないため、403 HTTP ステータス コードが返される。</span><span class="sxs-lookup"><span data-stu-id="2f02f-112">The user does not have the right permissions, returning a 403 HTTP status code.</span></span>
* <span data-ttu-id="2f02f-113">ユーザーが禁止されているため 401 HTTP ステータス コードが返される。</span><span class="sxs-lookup"><span data-stu-id="2f02f-113">The user has been banned, returning a 401 HTTP status code.</span></span>
<span data-ttu-id="2f02f-114">WinRT サービス API によって呼び出される IXMLHTTPRequest2 が要求を送信できない (ERROR_TIMEOUT、RPC_S_CALL_FAILED_DNE など)。</span><span class="sxs-lookup"><span data-stu-id="2f02f-114">IXMLHTTPRequest2, which is called by the WinRT service APIs, is unable to send the request (ERROR_TIMEOUT, RPC_S_CALL_FAILED_DNE, etc.)</span></span>
* <span data-ttu-id="2f02f-115">上記のリストは完全ではありません。</span><span class="sxs-lookup"><span data-stu-id="2f02f-115">The list above is not exhaustive.</span></span> <span data-ttu-id="2f02f-116">これらの問題の大部分は、サービス API レイヤーから例外がスローされるという結果になります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-116">The majority of these issues will result in an exception being thrown from the Services API layer.</span></span> <span data-ttu-id="2f02f-117">タイトルはこれらの例外をキャプチャーして適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-117">Your title should capture these exceptions and handle them appropriately.</span></span>

<span data-ttu-id="2f02f-118">Xbox Services API (XSAPI) には、使用している API に応じて、2 種類のエラー処理のスタイルがあります。</span><span class="sxs-lookup"><span data-stu-id="2f02f-118">There a two different styles of error handling in Xbox Services API (XSAPI) depending on the API you are using:</span></span>

<span data-ttu-id="2f02f-119">「[C++ API のエラー処理](error-handling-cpp.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2f02f-119">See [C++ API Error Handling](error-handling-cpp.md).</span></span>

<span data-ttu-id="2f02f-120">「[WinRT API のエラー処理](error-handling-winrt.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2f02f-120">See [WinRT API Error Handling](error-handling-winrt.md).</span></span>
