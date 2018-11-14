---
title: Xbox Live サービス API のトラブルシューティング
author: KevinAsgari
description: Xbox Live API の問題をトラブルシューティングするときに追加のエラー情報を記録する方法について説明します。
ms.assetid: 3827bba1-902f-4f2d-ad51-af09bd9354c4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング, エラー, ログ
ms.localizationpriority: medium
ms.openlocfilehash: fad6a36c3678a6b3c48dcbd78d9c19ed843a118f
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6195783"
---
# <a name="troubleshooting-the-xbox-live-apis"></a>Xbox Live API のトラブルシューティング

## <a name="code"></a>コード

Xbox Live Services API レイヤーからのエラーだけを使用して障害を診断することは困難です。 サーバーでは、すべての RESTful 呼び出しのログなど、他のエラー情報を使用できる場合があります。 このデータをリッスンするには、応答ロガーをフックし、デバッグ トレースを有効にします。 応答ログを使用すると、HTTP トラフィックや Web サービスの応答コードを確認できます。これは、Fiddler トレースと同じくらい役立つことがよくあります。

### <a name="c"></a>C++

以下のコード例では、応答ログを有効にし、デバッグ エラー レベルを Verbose に設定しています (デバッグ エラー レベルは、失敗した呼び出しのトレースのみを表示する Error や、トレースを無効にする Off に設定することもできます)。 Visual Studio でプロジェクトを実行すると、結果のデバッグ出力は [出力] ペインに送信されます。  

```cpp

        // Set up debug tracing to the Output window in Visual Studio.
            xbox::services::system::xbox_live_services_settings::get_singleton_instance()->set_diagnostics_trace_level(
                xbox_services_diagnostics_trace_level::verbose
                );
```

次のように、デバッグ出力を独自のログ ファイルにリダイレクトすることもできます。

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
