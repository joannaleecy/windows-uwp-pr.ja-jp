---
title: Xbox Live サービス API のトラブルシューティング
author: KevinAsgari
description: Xbox Live API の問題をトラブルシューティングするときに追加のエラー情報を記録する方法について説明します。
ms.assetid: 3827bba1-902f-4f2d-ad51-af09bd9354c4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング, エラー, ログ
ms.localizationpriority: medium
ms.openlocfilehash: dabc6458254c6ceec7995baa466de6dbddd76e18
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5395233"
---
# <a name="troubleshooting-the-xbox-live-apis"></a><span data-ttu-id="e9e78-104">Xbox Live API のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="e9e78-104">Troubleshooting the Xbox Live APIs</span></span>

## <a name="code"></a><span data-ttu-id="e9e78-105">コード</span><span class="sxs-lookup"><span data-stu-id="e9e78-105">Code</span></span>

<span data-ttu-id="e9e78-106">Xbox Live Services API レイヤーからのエラーだけを使用して障害を診断することは困難です。</span><span class="sxs-lookup"><span data-stu-id="e9e78-106">It is difficult to diagnose a failure using only the error from the Xbox Live Services API layer.</span></span> <span data-ttu-id="e9e78-107">サーバーでは、すべての RESTful 呼び出しのログなど、他のエラー情報を使用できる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e9e78-107">Extra error information—such as logging of all RESTful calls—could be available to the server.</span></span> <span data-ttu-id="e9e78-108">このデータをリッスンするには、応答ロガーをフックし、デバッグ トレースを有効にします。</span><span class="sxs-lookup"><span data-stu-id="e9e78-108">To listen to this data, hook up the response logger and enable debug tracing.</span></span> <span data-ttu-id="e9e78-109">応答ログを使用すると、HTTP トラフィックや Web サービスの応答コードを確認できます。これは、Fiddler トレースと同じくらい役立つことがよくあります。</span><span class="sxs-lookup"><span data-stu-id="e9e78-109">Response logging allows you to see HTTP traffic and web service response codes, which is often as useful as a Fiddler trace.</span></span>

### <a name="c"></a><span data-ttu-id="e9e78-110">C++</span><span class="sxs-lookup"><span data-stu-id="e9e78-110">C++</span></span>

<span data-ttu-id="e9e78-111">以下のコード例では、応答ログを有効にし、デバッグ エラー レベルを Verbose に設定しています (デバッグ エラー レベルは、失敗した呼び出しのトレースのみを表示する Error や、トレースを無効にする Off に設定することもできます)。</span><span class="sxs-lookup"><span data-stu-id="e9e78-111">The following code example enables response logging and sets the debug error level to Verbose (you can also set the debug error level to Error to show only trace failed calls, or to Off to disable tracing).</span></span> <span data-ttu-id="e9e78-112">Visual Studio でプロジェクトを実行すると、結果のデバッグ出力は [出力] ペインに送信されます。</span><span class="sxs-lookup"><span data-stu-id="e9e78-112">The resulting debug output is sent to the Output pane when running your project in Visual Studio.</span></span>  

```cpp

        // Set up debug tracing to the Output window in Visual Studio.
            xbox::services::system::xbox_live_services_settings::get_singleton_instance()->set_diagnostics_trace_level(
                xbox_services_diagnostics_trace_level::verbose
                );
```

<span data-ttu-id="e9e78-113">次のように、デバッグ出力を独自のログ ファイルにリダイレクトすることもできます。</span><span class="sxs-lookup"><span data-stu-id="e9e78-113">You can also choose to redirect debug output to your own log file like so:</span></span>

```cpp

        // Set up debug tracing of the Xbox Live Services API traffic to the game UI.
        m_xboxLiveContext->Settings->EnableServiceCallRoutedEvents = true;
        m_xboxLiveContext->Settings->ServiceCallRouted += ref new
        Windows::Foundation::EventHandler<Microsoft::Xbox::Services::XboxServiceCallRoutedEventArgs^>(
            [=] ( Platform::Object^, Microsoft::Xbox::Services::XboxServiceCallRoutedEventArgs^ args )
            {
                gameUI->Log(L"[URL]: " + args->HttpMethod + " " + args->Url->AbsoluteUri);
                gameUI->Log(L"");
                gameUI->Log(L"[Response]: " + args->HttpStatus.ToString() + " " + args->ResponseBody);
            });

```
