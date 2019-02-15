---
description: HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、HttpClient とその他の Windows.Web.Http 名前空間 API を使います。
title: HttpClient
ms.assetid: EC9820D3-3A46-474F-8A01-AE1C27442750
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: dd4b8c137d65339701b40027bb3230162e2c2456
ms.sourcegitcommit: fde2d41ef4b5658785723359a8c4b856beae8f95
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/15/2019
ms.locfileid: "9079210"
---
# <a name="httpclient"></a>HttpClient

**重要な API**

-   [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)
-   [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692)
-   [**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631)

HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) とその他の [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間 API を使います。

## <a name="overview-of-httpclient-and-the-windowswebhttp-namespace"></a>HttpClient と Windows.Web.Http 名前空間の概要

[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間、関連する [**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) 名前空間、[**Windows.Web.Http.Filters**](https://msdn.microsoft.com/library/windows/apps/dn298623) 名前空間のクラスには、基本的な GET 要求を実行したり、次のようなさらに高度な HTTP 機能を実装したりするための HTTP クライアントとして動作する、ユニバーサル Windows プラットフォーム (UWP) アプリ用のプログラミング インターフェイスが用意されています。

-   一般的な動詞 (**DELETE**、**GET**、**PUT**、**POST**) に対応するメソッド。 これらの各要求は、非同期操作として送られます。

-   一般的な認証設定とパターンのサポート。

-   トランスポートに関する Secure Sockets Layer (SSL) 詳細へのアクセス。

-   カスタマイズされたフィルターを高度なアプリに含める機能。

-   Cookie を取得、設定、削除する機能。

-   非同期メソッドで利用可能な HTTP 要求の進行状況情報。

[**Windows.Web.Http.HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) クラスは、[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) から送られた HTTP 要求メッセージを表します。 [**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) クラスは、HTTP 要求から受け取った HTTP 応答メッセージを表します。 HTTP メッセージは、IETF によって [RFC 2616](https://go.microsoft.com/fwlink/p/?linkid=241642) で規定されています。

[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間は、クッキーを含む HTTP エンティティ ボディおよびヘッダーとして HTTP コンテンツを表します。 HTTP コンテンツは、HTTP 要求または HTTP 応答に関連付けることができます。 **Windows.Web.Http** 名前空間には、HTTP コンテンツを表す多数のさまざまなクラスが用意されています。

-   [**HttpBufferContent**](https://msdn.microsoft.com/library/windows/apps/dn298625)。 バッファーとしてのコンテンツ。
-   [**HttpFormUrlEncodedContent**](https://msdn.microsoft.com/library/windows/apps/dn298685)。 **application/x-www-form-urlencoded** MIME タイプでエンコードされた名前と値の組としてのコンテンツ。
-   [**HttpMultipartContent**](https://msdn.microsoft.com/library/windows/apps/dn298708)。 **multipart/\*** MIME タイプ形式のコンテンツ。
-   [**HttpMultipartFormDataContent**](https://msdn.microsoft.com/library/windows/apps/dn279596)。 **multipart/form-data** MIME タイプとしてエンコードされているコンテンツ。
-   [**HttpStreamContent**](https://msdn.microsoft.com/library/windows/apps/dn279649)。 ストリームとしてのコンテンツ (この内部タイプは、HTTP GET メソッドでのデータの受信、および HTTP POST メソッドでのデータのアップロードに使われます)。
-   [**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661)。 文字列としてのコンテンツ。
-   [**IHttpContent**](https://msdn.microsoft.com/library/windows/apps/dn279684) - 開発者が独自のコンテンツ オブジェクトを作成するための基本インターフェイス

「HTTP 経由でシンプルな GET 要求を送信する」セクションのコード スニペットでは、[**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661) クラスを使って、HTTP GET 要求からの HTTP 応答を文字列として表しています。

[**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) 名前空間では、HTTP ヘッダーと Cookie の作成がサポートされます。これらはプロパティとして、[**HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) オブジェクトと [**HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) オブジェクトに関連付けられます。

## <a name="send-a-simple-get-request-over-http"></a>HTTP 経由でシンプルな GET 要求を送信する

この記事の中で既に説明したように、[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間は、UWP アプリで GET 要求を送信できるようにします。 次のコード スニペットは、GET 要求を送信する方法を示しています。 http://www.contoso.com GET 要求から応答を読み取る[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)クラスと[**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631)クラスを使用します。

```csharp
//Create an HTTP client object
Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

//Add a user-agent header to the GET request. 
var headers = httpClient.DefaultRequestHeaders;

//The safe way to add a header value is to use the TryParseAdd method and verify the return value is true,
//especially if the header value is coming from user input.
string header = "ie";
if (!headers.UserAgent.TryParseAdd(header))
{
    throw new Exception("Invalid header value: " + header);
}

header = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
if (!headers.UserAgent.TryParseAdd(header))
{
    throw new Exception("Invalid header value: " + header);
}

Uri requestUri = new Uri("http://www.contoso.com");

//Send the GET request asynchronously and retrieve the response as a string.
Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
string httpResponseBody = "";

try
{
    //Send the GET request
    httpResponse = await httpClient.GetAsync(requestUri);
    httpResponse.EnsureSuccessStatusCode();
    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
}
catch (Exception ex)
{
    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
}
```

```cppwinrt
// pch.h
#pragma once
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Web.Http.Headers.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
#include <iostream>
using namespace winrt;
using namespace Windows::Foundation;

int main()
{
    init_apartment();

    // Create an HttpClient object.
    Windows::Web::Http::HttpClient httpClient;

    // Add a user-agent header to the GET request.
    auto headers{ httpClient.DefaultRequestHeaders() };

    // The safe way to add a header value is to use the TryParseAdd method, and verify the return value is true.
    // This is especially important if the header value is coming from user input.
    std::wstring header{ L"ie" };
    if (!headers.UserAgent().TryParseAdd(header))
    {
        throw L"Invalid header value: " + header;
    }

    header = L"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
    if (!headers.UserAgent().TryParseAdd(header))
    {
        throw L"Invalid header value: " + header;
    }

    Uri requestUri{ L"http://www.contoso.com" };

    // Send the GET request asynchronously, and retrieve the response as a string.
    Windows::Web::Http::HttpResponseMessage httpResponseMessage;
    std::wstring httpResponseBody;

    try
    {
        // Send the GET request.
        httpResponseMessage = httpClient.GetAsync(requestUri).get();
        httpResponseMessage.EnsureSuccessStatusCode();
        httpResponseBody = httpResponseMessage.Content().ReadAsStringAsync().get();
    }
    catch (winrt::hresult_error const& ex)
    {
        httpResponseBody = ex.message();
    }
    std::wcout << httpResponseBody;
}
```

## <a name="post-binary-data-over-http"></a>HTTP 経由でデータをポスト バイナリ

[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis)フォーム データと POST 要求を使用して、web サーバーへのファイルのアップロードとして少量のバイナリ データを送信する次のコード例を示しています。 コードでは、バイナリのデータを表す[**HttpBufferContent**](/uwp/api/windows.web.http.httpbuffercontent)クラスとマルチパート フォーム データを表す[**HttpMultipartFormDataContent**](/uwp/api/windows.web.http.httpmultipartformdatacontent)クラスを使用します。

> [!NOTE]
> (次のコード例に示す) よう、**取得**を呼び出すことが適切でない UI スレッドにします。 その場合に使用する、適切な手法では、次を参照してください。[同時実行と非同期操作において、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/concurrency)します。

```cppwinrt
// pch.h
#pragma once
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Security.Cryptography.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.Web.Http.Headers.h>

// main.cpp : Defines the entry point for the console application.
#include "pch.h"
#include <iostream>
#include <sstream>
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::Storage::Streams;

int main()
{
    init_apartment();

    Windows::Web::Http::HttpClient httpClient;

    Uri requestUri{ L"https://www.contoso.com/post" };

    Windows::Web::Http::HttpMultipartFormDataContent postContent;
    Windows::Web::Http::Headers::HttpContentDispositionHeaderValue disposition{ L"form-data" };
    postContent.Headers().ContentDisposition(disposition);
    // The 'name' directive contains the name of the form field representing the data.
    disposition.Name(L"fileForUpload");
    // Here, the 'filename' directive is used to indicate to the server a file name
    // to use to save the uploaded data.
    disposition.FileName(L"file.dat");

    auto buffer{
        Windows::Security::Cryptography::CryptographicBuffer::ConvertStringToBinary(
            L"A sentence of text to encode into binary to serve as sample data.",
            Windows::Security::Cryptography::BinaryStringEncoding::Utf8
        )
    };
    Windows::Web::Http::HttpBufferContent binaryContent{ buffer };
    // You can use the 'image/jpeg' content type to represent any binary data;
    // it's not necessarily an image file.
    binaryContent.Headers().Append(L"Content-Type", L"image/jpeg");

    postContent.Add(binaryContent); // Add the binary data content as a part of the form data content.

    // Send the POST request asynchronously, and retrieve the response as a string.
    Windows::Web::Http::HttpResponseMessage httpResponseMessage;
    std::wstring httpResponseBody;

    try
    {
        // Send the POST request.
        httpResponseMessage = httpClient.PostAsync(requestUri, postContent).get();
        httpResponseMessage.EnsureSuccessStatusCode();
        httpResponseBody = httpResponseMessage.Content().ReadAsStringAsync().get();
    }
    catch (winrt::hresult_error const& ex)
    {
        httpResponseBody = ex.message();
    }
    std::wcout << httpResponseBody;
}
```

(上記で使用する明示的なバイナリ データではなく) 実際のバイナリ ファイルの内容を投稿するを確認して[HttpStreamContent](/uwp/api/windows.web.http.httpstreamcontent)オブジェクトを使いやすくします。 1 つを作成して、そのコンス トラクターの引数として渡す[StorageFile.OpenReadAsync](/uwp/api/windows.storage.storagefile.openreadasync)への呼び出しから返される値。 そのメソッドは、バイナリ ファイル内のデータのストリームを返します。

お勧めします (約 10 MB を超える) 場合は、大きなファイルをアップロードしている場合は、[Windows ランタイムの[バック グラウンド転送](/uwp/api/windows.networking.backgroundtransfer)Api を使います。

## <a name="exceptions-in-windowswebhttp"></a>Windows.Web.Http の例外

Uniform Resource Identifier (URI) として無効な文字列が、[**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) オブジェクトのコンストラクターに渡されると、例外がスローされます。

**.NET:** [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998)形式では、c# と VB. [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx)として表示されます

C# や Visual Basic では、.NET 4.5 の [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) クラスと、[**System.Uri.TryCreate**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.trycreate.aspx) メソッドの 1 つを使って、URI が作成される前にユーザーから受け取った文字列をテストすることによって、このエラーを回避できます。

C++ では、URI として渡される文字列を試行して解析するメソッドはありません。 アプリがユーザーから [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。 例外がスローされた場合、アプリは、ユーザーに通知し、新しいホスト名を要求することができます。

[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) には便利な関数がありません。 そのため、この名前空間の [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と他のクラスを使うアプリは、**HRESULT** 値を使う必要があります。

アプリでは、c#、VB.NET、 [System.Exception](https://msdn.microsoft.com/library/system.exception.aspx) .NET Framework4.5 を使用してエラーを表しますアプリの実行中に例外が発生した場合。 [System.Exception.HResult](https://msdn.microsoft.com/library/system.exception.hresult.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。 [System.Exception.Message](https://msdn.microsoft.com/library/system.exception.message.aspx) プロパティは、例外を説明するメッセージを返します。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

Managed C++ を使うアプリでは、アプリの実行中に例外が発生したときに、[Platform::Exception](https://msdn.microsoft.com/library/windows/apps/hh755825.aspx) がエラーを表します。 [Platform::Exception::HResult](https://msdn.microsoft.com/library/windows/apps/hh763371.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。 [Platform::Exception::Message](https://msdn.microsoft.com/library/windows/apps/hh763375.aspx) プロパティは、**HRESULT** 値に関連付けられた、システムが提供する文字列を返します。 使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。 アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。

ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。 一部の無効なメソッド呼び出しでは、返される **HRESULT** は **E\_ILLEGAL\_METHOD\_CALL** です。

