---
title: ゲームのネットワーク
description: ネットワーク機能を開発し、DirectX ゲームに組み込む方法について説明します。
ms.assetid: 212eee15-045c-8ba1-e274-4532b2120c55
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ネットワーク, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 2697564e703cfe290e33f204125346f3e8bad8ac
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7841797"
---
# <a name="networking-for-games"></a>ゲームのネットワーク



ネットワーク機能を開発し、DirectX ゲームに組み込む方法について説明します。

## <a name="concepts-at-a-glance"></a>概要


単純なスタンドアロン ゲームか多人数のマルチプレイヤー ゲームかにかかわらず、DirectX ゲームには、さまざまなネットワーク機能を使うことができます。 ネットワークの最も単純な用途は、一元的なネットワーク サーバーにユーザー名とゲーム スコアを保存することです。

Networking API は、インフラストラクチャ (クライアント サーバーまたはインターネット ピア ツー ピア) モデルを使うマルチプレイヤー ゲームや、アドホック (ローカル ピア ツー ピア) ゲームに必要です。 サーバー ベースのマルチプレイヤー ゲームでは、ゲーム操作のほとんどを通常はセントラル ゲーム サーバーで処理し、入力、グラフィックス表示、オーディオ再生などの機能にクライアント ゲーム アプリを使います。 ネットワーク転送の速度と待機時間は、満足度の高いゲーム エクスペリエンスを実現するための課題です。

ピア ツー ピア ゲームでは、各プレイヤーのアプリで、入力とグラフィックスを処理します。 ほとんどの場合、各ゲーム プレイヤーはきわめて近い場所にいるため、ネットワーク待機時間は長くありませんが、重要度に変わりはありません。 ピアの検出と接続の確立も、重要事項です。

単一プレイヤーのゲームでは、ユーザー名、ゲームのスコア、その他のさまざまな情報を保存するために、セントラル Web サーバーまたはサービスがよく使われます。 これらのゲームでは、直接ゲーム操作に影響しないため、ネットワーク転送の速度と待機時間はそれほど大きな問題ではありません。

ネットワークの状態はいつでも変化する可能性があり、Networking API を使うゲームでは、発生する可能性のあるネットワーク例外を処理できるようにしておく必要があります。 ネットワーク例外の処理について詳しくは、「[ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)」をご覧ください。

ファイアウォールと Web プロキシは一般的で、ネットワーク機能の使用に影響する可能性があります。 ネットワークを使うゲームでは、ファイアウォールとプロキシを適切に処理できるようにしておく必要があります。

モバイル デバイスでは、ローミングまたはデータのコストが大きい従量制課金接続を使う場合、利用できるネットワーク リソースを監視し、それに従って動作することが重要です。

ネットワーク分離は、Windows で採用されているアプリ セキュリティ モデルの一部です。 Windows がネットワークの境界を能動的に検出し、ネットワーク アクセスの制限を強制的に適用することによって、ネットワーク分離が実現されています。 アプリがネットワーク アクセスのスコープを定義するには、ネットワーク分離機能を宣言する必要があります。 この機能を宣言しないと、アプリはネットワーク リソースにアクセスできません。 Windows でアプリにネットワーク分離が適用されるしくみについて詳しくは、「[ネットワーク分離機能を構成する方法](https://msdn.microsoft.com/library/windows/apps/hh770532)」をご覧ください。

## <a name="design-considerations"></a>設計時の考慮事項


DirectX ゲームに使うことのできる Networking API は、多数あります。 このため、適切な API を選ぶことが重要です。 Windows では、アプリがインターネットまたはプライベート ネットワーク上で他のコンピューターやデバイスと通信するために使うことができるさまざまな Networking API がサポートされています。 最初のステップは、アプリに必要なネットワーク機能を理解することです。

ゲームに使うことができる主要なネットワーク API には、次のようなものがあります。

-   TCP とソケット - 信頼性の高い接続を実現します。 TCP は、セキュリティを必要としないゲーム操作に使います。 TCP を使うとサーバーの規模変更が容易であるため、インフラストラクチャ (クライアント サーバーまたはインターネット ピア ツー ピア) モデルのゲームでよく使われます。 TCP は、Wi-Fi Direct と Bluetooth を経由したアドホック (ローカル ピア ツー ピア) ゲームでも使うことができます。 TCP は一般的に、ゲーム オブジェクトの動き、文字操作、テキスト チャットなどの操作に使います。 [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)クラスは、Microsoft Store ゲームで使用できる TCP ソケットを提供します。 **StreamSocket** クラスは、[**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間の関連クラスと共に使われます。
-   SSL を使う TCP とソケット - 信頼性の高い接続を提供して改ざんを防ぎます。 SSL を伴う TCP 接続は、セキュリティを必要とするゲーム操作で使います。 SSL の暗号化とオーバーヘッドにより、待機時間とパフォーマンスのコストが増加するため、セキュリティが必要な場合にのみ使うようにします。 一般的に、SSL を伴う TCP は、ログイン、アセットの購入とトレーディング、ゲーム キャラクターの作成と管理に使います。 SSL をサポートする TCP ソケットは、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスで提供されます。
-   UDP とソケット - 信頼性の低いネットワーク転送を低いオーバーヘッドで提供します。 UDP は、待機時間を短くする必要があり、ある程度のパケット損失を許容できるゲーム操作に使われます。 これは、ファイティング ゲーム、シューティング、トレーサー、ネットワーク オーディオ、ボイス チャットなどによく使われます。 [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)クラスは、Microsoft Store ゲームで使用できる UDP ソケットを提供します。 **DatagramSocket** クラスは、[**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間の関連クラスと共に使われます。
-   HTTP クライアント - HTTP サーバーへの、信頼性の高い接続を実現します。 最も一般的なネットワーク シナリオは、Web サイトにアクセスして情報を取得または保存することです。 単純な例としては、Web サイトを使ってユーザー情報とゲームのスコアを保存するゲームが考えられます。 HTTP クライアントは、SSL と組み合わせてセキュリティを強化すると、ログイン、購入、アセットのトレーディング、ゲーム キャラクターの作成、管理に使うことができます。 [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)クラスは、最新の HTTP クライアント API の使用では、Microsoft Store ゲームを提供します。 **HttpClient** クラスは、[**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間の関連クラスと共に使われます。

## <a name="handling-network-exceptions-in-your-directx-game"></a>DirectX ゲームでのネットワーク例外の処理


DirectX ゲームでのネットワーク例外の発生は、重大な問題やエラーを示します。 Networking API を使う場合、例外はさまざまな理由で発生します。 リモート ホストやサーバー側でネットワーク接続を変更したなど、ネットワークの問題のために例外が発生することもよくあります。

Networking API を使う場合の例外の理由には、次のようなものがあります。

-   ホスト名や URI のユーザー入力にエラーがあり有効ではない
-   ホスト名または URI の参照時の名前解決の失敗
-   ネットワーク接続の切断または変更
-   ソケットと HTTP クライアント API を使っているネットワーク接続の失敗
-   ネットワーク サーバーまたはリモート エンドポイントのエラー
-   その他のネットワーク エラー

ネットワークのエラーによる例外 (たとえば、接続の切断または変更、接続エラー、サーバー エラー) は、いつでも発生する場合があります。 これらのエラーが起きると、例外がスローされます。 例外がアプリによって処理されない場合、ランタイムによってアプリ全体が終了されることがあります。

非同期ネットワーク メソッドの多くは、呼び出す場合、例外を処理するようにコードを記述する必要があります。 例外の発生時に、場合によっては、問題を解決するためにネットワーク メソッドが再試行されることがあります。 また、ネットワーク接続なしで、以前にキャッシュされたデータを使ってアプリを継続するように計画しなければならない場合もあります。

ユニバーサル Windows プラットフォーム (UWP) アプリは、一般に、1 つの例外をスローします。 エラーについてよく理解し、適切な判断ができるように、例外ハンドラーは例外の原因についての詳しい情報を取得できます。

例外が UWP アプリである DirectX ゲームで発生すると、エラーの原因の **HRESULT** 値を取得できます。 *Winerror.h* インクルード ファイルには、ネットワーク エラーを含む、出力される可能性がある **HRESULT** 値の大きなリストが格納されています。

Networking API は、例外の原因についての詳しい情報を取得するために、さまざまなメソッドをサポートしています。

-   例外の原因となったエラーの **HRESULT** 値を取得するメソッド。 可能な **HRESULT** 値の一覧はサイズが大きく指定されていません。 Networking API の 1 つを使っている場合は **HRESULT** の値を取得できます。
-   **HRESULT** 値を列挙値に変換するヘルパー メソッド。 可能な列挙値の一覧は指定されていて、比較的小さいサイズです。 [**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 内のソケット クラスにヘルパー メソッドを使うことができます。

### <a name="exceptions-in-windowsnetworkingsockets"></a>Windows.Networking.Sockets の例外

ソケットと共に使われる [**HostName**](https://msdn.microsoft.com/library/windows/apps/br207113) クラスのコンストラクターは、有効なホスト名ではない (ホスト名に使うことができない文字が含まれている) 文字列が渡された場合に例外をスローすることができます。 アプリがゲームのピア接続用にユーザーから **HostName** の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。 例外がスローされた場合、アプリは、ユーザーに通知し、新しいホスト名を要求することができます。

ユーザーが指定したホスト名の文字列を検証するコードの追加

```cpp

    // Define some variables at the class level.
    Windows::Networking::HostName^ remoteHost;

    bool isHostnameFromUser = false;
    bool isHostnameValid = false;

    ///...

    // If the value of 'remoteHostname' is set by the user in a control as input 
    // and is therefore untrusted input and could contain errors. 
    // If we can't create a valid hostname, we notify the user in statusText 
    // about the incorrect input.

    String ^hostString = remoteHostname;

    try 
    {
        remoteHost = ref new Windows::Networking:Host(hostString);
        isHostnameValid = true;
    }
    catch (InvalidArgumentException ^ex)
    {
        statusText->Text = "You entered a bad hostname, please re-enter a valid hostname.";
        return;
    }

    isHostnameFromUser = true;


    // ... Continue with code to execute with a valid hostname.
```

[**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) 名前空間には、ソケットを使う場合のエラー処理に便利なヘルパー メソッドと列挙があります。 これは、アプリで特定のネットワーク例外を異なる方法で処理する場合に役立つことがあります。

スローされた例外の [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)、[**StreamSocketListener**](https://msdn.microsoft.com/library/windows/apps/br226906) の操作結果で発生したエラー。 例外の原因は、**HRESULT** として表現されるエラー値です。 [**SocketError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701462) メソッドは、ネットワーク エラーをソケット操作から [**SocketErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh701457) 列挙値に変換するために使われます。 ほとんどの **SocketErrorStatus** 列挙値は、ネイティブ Windows ソケット操作から返されるエラーに対応しています。 アプリは特定の **SocketErrorStatus** 列挙値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

パラメーター検証エラーの場合、アプリは例外からの **HRESULT** を使って、その例外の原因となったエラーの詳細情報を確認することもできます。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。

ストリーム ソケット接続の実行時に発生する例外を処理するコードの追加

```cpp
using namespace Windows::Networking;
using namespace Windows::Networking::Sockets;

    
    // Define some more variables at the class level.

    bool isSocketConnected = false
    bool retrySocketConnect = false;

    // The number of times we have tried to connect the socket.
    unsigned int retryConnectCount = 0;

    // The maximum number of times to retry a connect operation.
    unsigned int maxRetryConnectCount = 5; 
    ///...

    // We pass in a valid remoteHost and serviceName parameter.
    // The hostname can contain a name or an IP address.
    // The servicename can contain a string or a TCP port number.

    StreamSocket ^ socket = ref new StreamSocket();
    SocketErrorStatus errorStatus; 
    HResult hr;

    // Save the socket, so any subsequent steps can use it.
    CoreApplication::Properties->Insert("clientSocket", socket);

    // Connect to the remote server. 
    create_task(socket->ConnectAsync(
            remoteHost,
            serviceName,
            SocketProtectionLevel::PlainSocket)).then([this] (task<void> previousTask)
    {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.get();

            isSocketConnected = true;
            // Mark the socket as connected. We do not really care about the value of the property, but the mere 
            // existence of  it means that we are connected.
            CoreApplication::Properties->Insert("connected", nullptr);
        }
        catch (Exception^ ex)
        {
            hr = ex.HResult;
            errorStatus = SocketStatus::GetStatus(hr); 
            if (errorStatus != Unknown)
            {
                                                                switch (errorStatus) 
                   {
                    case HostNotFound:
                        // If the hostname is from the user, this may indicate a bad input.
                        // Set a flag to ask the user to re-enter the hostname.
                        isHostnameValid = false;
                        return;
                        break;
                    case ConnectionRefused:
                        // The server might be temporarily busy.
                        retrySocketConnect = true;
                        return;
                        break; 
                    case NetworkIsUnreachable: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    case UnreachableHost: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    case NetworkIsDown: 
                        // This could be a connectivity issue.
                        retrySocketConnect = true;
                        break;
                    // Handle other errors. 
                    default: 
                        // The connection failed and no options are available.
                        // Try to use cached data if it is available. 
                        // You may want to tell the user that the connect failed.
                        break;
                }
                }
                else 
                {
                    // Received an Hresult that is not mapped to an enum.
                    // This could be a connectivity issue.
                    retrySocketConnect = true;
                }
            }
        });
    }

```

### <a name="exceptions-in-windowswebhttp"></a>Windows.Web.Http の例外

[**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と共に使われる [**Windows::Foundation::Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) クラスのコンストラクターは、有効な URI ではない (URI に使うことができない文字が含まれている) 文字列が渡された場合に例外をスローすることができます。 C++ では、URI として渡される文字列を試行して解析するメソッドはありません。 アプリがユーザーから **Windows::Foundation::Uri** の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。 例外がスローされた場合、アプリは、ユーザーに通知して、新しい URI を要求することができます。

アプリでは、URI 内のスキーマが HTTP または HTTPS であることも確認する必要があります。[**Windows::Web::Http::HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) では、これらのスキーマしかサポートされていないためです。

ユーザーが指定した URI の文字列を検証するコードの追加

```cpp

    // Define some variables at the class level.
    Windows::Foundation::Uri^ resourceUri;

    bool isUriFromUser = false;
    bool isUriValid = false;

    ///...

    // If the value of 'inputUri' is set by the user in a control as input 
    // and is therefore untrusted input and could contain errors. 
    // If we can't create a valid hostname, we notify the user in statusText 
    // about the incorrect input.

    String ^uriString = inputUri;

    try 
    {
        isUriValid = false;
        resourceUri = ref new Windows::Foundation:Uri(uriString);

        if (resourceUri->SchemeName != "http" && resourceUri->SchemeName != "https")
        {
            statusText->Text = "Only 'http' and 'https' schemes supported. Please re-enter URI";
            return;
        }
        isUriValid = true;
    }
    catch (InvalidArgumentException ^ex)
    {
        statusText->Text = "You entered a bad URI, please re-enter Uri to continue.";
        return;
    }

    isUriFromUser = true;


    // ... Continue with code to execute with a valid URI.
```

[**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/windows.web.http.aspx) 名前空間には便利な関数がありません。 そのため、この名前空間の [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と他のクラスを使うアプリは、**HRESULT** 値を使う必要があります。

C++ を使うアプリでは、アプリの実行中に例外が発生したときに、[**Platform::Exception**](https://msdn.microsoft.com/library/windows/apps/hh755825.aspx) がエラーを表します。 [**Platform::Exception::HResult**](https://msdn.microsoft.com/library/windows/apps/hh763371.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。 [**Platform::Exception::Message**](https://msdn.microsoft.com/library/windows/apps/hh763375.aspx) プロパティは、**HRESULT** 値に関連付けられた、システムが提供する文字列を返します。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。 一部の無効なメソッド呼び出しでは、返される **HRESULT** は **E\_ILLEGAL\_METHOD\_CALL** です。

[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) を使って HTTP サーバーに接続するときに発生する例外を処理するコードの追加

```cpp
using namespace Windows::Foundation;
using namespace Windows::Web::Http;
    
    // Define some more variables at the class level.

    bool isHttpClientConnected = false
    bool retryHttpClient = false;

    // The number of times we have tried to connect the socket
    unsigned int retryConnectCount = 0;

    // The maximum number of times to retry a connect operation.
    unsigned int maxRetryConnectCount = 5; 
    ///...

    // We pass in a valid resourceUri parameter.
    // The URI must contain a scheme and a name or an IP address.

    HttpClient ^ httpClient = ref new HttpClient();
    HResult hr;

    // Save the httpClient, so any subsequent steps can use it.
    CoreApplication::Properties->Insert("httpClient", httpClient);

    // Send a GET request to the HTTP server. 
    create_task(httpClient->GetAsync(resourceUri)).then([this] (task<void> previousTask)
    {
        try
        {
            // Try getting all exceptions from the continuation chain above this point.
            previousTask.get();

            isHttpClientConnected = true;
            // Mark the HttClient as connected. We do not really care about the value of the property, but the mere 
            // existence of  it means that we are connected.
            CoreApplication::Properties->Insert("connected", nullptr);
        }
        catch (Exception^ ex)
        {
            hr = ex.HResult;
                                                switch (errorStatus) 
               {
                case WININET_E_NAME_NOT_RESOLVED:
                    // If the Uri is from the user, this may indicate a bad input.
                    // Set a flag to ask user to re-enter the Uri.
                    isUriValid = false;
                    return;
                    break;
                case WININET_E_CANNOT_CONNECT:
                    // The server might be temporarily busy.
                    retryHttpClientConnect = true;
                    return;
                    break; 
                case WININET_E_CONNECTION_ABORTED: 
                    // This could be a connectivity issue.
                    retryHttpClientConnect = true;
                    break;
                case WININET_E_CONNECTION_RESET: 
                    // This could be a connectivity issue.
                    retryHttpClientConnect = true;
                    break;
                case INET_E_RESOURCE_NOT_FOUND: 
                    // The server cannot locate the resource specified in the uri.
                    // If the Uri is from user, this may indicate a bad input.
                    // Set a flag to ask the user to re-enter the Uri
                    isUriValid = false;
                    return;
                    break;
                // Handle other errors. 
                default: 
                    // The connection failed and no options are available.
                    // Try to use cached data if it is available. 
                    // You may want to tell the user that the connect failed.
                    break;
            }
            else 
            {
                // Received an Hresult that is not mapped to an enum.
                // This could be a connectivity issue.
                retrySocketConnect = true;
            }
        }
    });
    

```

## <a name="related-topics"></a>関連トピック


**その他のリソース**

* [データグラム ソケットを使った接続](https://msdn.microsoft.com/library/windows/apps/xaml/jj635238)
* [ストリーム ソケットによるネットワーク リソースへの接続](https://msdn.microsoft.com/library/windows/apps/xaml/jj150599)
* [ネットワーク サービスへの接続](https://msdn.microsoft.com/library/windows/apps/xaml/hh452976)
* [Web サービスへの接続](https://msdn.microsoft.com/library/windows/apps/xaml/hh761504)
* [ネットワークの基本](https://msdn.microsoft.com/library/windows/apps/mt280233)
* [ネットワーク分離機能を構成する方法](https://msdn.microsoft.com/library/windows/apps/hh770532)
* [ループバックを有効にする方法とネットワーク分離のトラブルシューティングを行う方法](https://msdn.microsoft.com/library/windows/apps/hh780593)

**リファレンス**

* [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319)
* [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)
* [**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882)
* [**Windows::Web::Http**](https://msdn.microsoft.com/library/windows/apps/dn279692)
* [**Windows::Networking::Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960)

**サンプル**

* [DatagramSocket のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=243037)
* [HttpClient のサンプル]( http://go.microsoft.com/fwlink/p/?linkid=242550)
* [近接通信のサンプル](http://go.microsoft.com/fwlink/p/?linkid=245082)
* [StreamSocket のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=243037)
