---
title: エラー処理
description: Xbox Live サービス呼び出しを行ったときのエラーを処理する方法について説明します。
ms.assetid: e433dfbd-488b-44ff-8333-1dcf0329cd60
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, エラー, サービス呼び出し
ms.localizationpriority: medium
ms.openlocfilehash: 637b9da84ef3ae50ea6235ca86e6318ae62acd11
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337937"
---
# <a name="error-handling"></a>エラー処理

サービス呼び出しを行うとき、開発者は特別な注意を払う必要があります。 タイトルでは、ネットワーク呼び出しを行うときは常にエラーを処理する必要があります。 開発中に一貫して機能していたサービス呼び出しであっても、現実世界の環境では、さまざまな理由によってサービス呼び出しが失敗する可能性があります。 たとえば、以下の理由によって呼び出しが失敗する場合があります。

* ネットワークが使用できない。
* サービスがビジー状態で 503 HTTP ステータス コードが返される。
* 要求が無効で 400 HTTP ステータス コードが返される。
* ユーザーが適切なアクセス許可を持っていないため、403 HTTP ステータス コードが返される。
* ユーザーが禁止されているため 401 HTTP ステータス コードが返される。
WinRT サービス API によって呼び出される IXMLHTTPRequest2 が要求を送信できない (ERROR_TIMEOUT、RPC_S_CALL_FAILED_DNE など)。
* 上記のリストは完全ではありません。 これらの問題の大部分は、サービス API レイヤーから例外がスローされるという結果になります。 タイトルはこれらの例外をキャプチャーして適切に処理する必要があります。

Xbox Services API (XSAPI) には、使用している API に応じて、2 種類のエラー処理のスタイルがあります。

「[C++ API のエラー処理](error-handling-cpp.md)」を参照してください。

「[WinRT API のエラー処理](error-handling-winrt.md)」を参照してください。
