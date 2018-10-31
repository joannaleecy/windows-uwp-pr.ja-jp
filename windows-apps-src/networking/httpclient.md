---
author: stevewhims
description: HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、HttpClient とその他の Windows.Web.Http 名前空間 API を使います。
title: HttpClient
ms.assetid: EC9820D3-3A46-474F-8A01-AE1C27442750
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c874c690826dfa74b8dcb2312204cd549db3db2b
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5824015"
---
# <a name="httpclient"></a><span data-ttu-id="e88cd-104">HttpClient</span><span class="sxs-lookup"><span data-stu-id="e88cd-104">HttpClient</span></span>


**<span data-ttu-id="e88cd-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="e88cd-105">Important APIs</span></span>**

-   [**<span data-ttu-id="e88cd-106">HttpClient</span><span class="sxs-lookup"><span data-stu-id="e88cd-106">HttpClient</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn298639)
-   [**<span data-ttu-id="e88cd-107">Windows.Web.Http</span><span class="sxs-lookup"><span data-stu-id="e88cd-107">Windows.Web.Http</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn279692)
-   [**<span data-ttu-id="e88cd-108">Windows.Web.Http.HttpResponseMessage</span><span class="sxs-lookup"><span data-stu-id="e88cd-108">Windows.Web.Http.HttpResponseMessage</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn279631)

<span data-ttu-id="e88cd-109">HTTP 2.0 プロトコルと HTTP 1.1 プロトコルを使って情報を送受信するには、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) とその他の [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間 API を使います。</span><span class="sxs-lookup"><span data-stu-id="e88cd-109">Use [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) and the rest of the [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace API to send and receive information using the HTTP 2.0 and HTTP 1.1 protocols.</span></span>

## <a name="overview-of-httpclient-and-the-windowswebhttp-namespace"></a><span data-ttu-id="e88cd-110">HttpClient と Windows.Web.Http 名前空間の概要</span><span class="sxs-lookup"><span data-stu-id="e88cd-110">Overview of HttpClient and the Windows.Web.Http namespace</span></span>

<span data-ttu-id="e88cd-111">[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間、関連する [**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) 名前空間、[**Windows.Web.Http.Filters**](https://msdn.microsoft.com/library/windows/apps/dn298623) 名前空間のクラスには、基本的な GET 要求を実行したり、次のようなさらに高度な HTTP 機能を実装したりするための HTTP クライアントとして動作する、ユニバーサル Windows プラットフォーム (UWP) アプリ用のプログラミング インターフェイスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-111">The classes in the [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace and the related [**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) and [**Windows.Web.Http.Filters**](https://msdn.microsoft.com/library/windows/apps/dn298623) namespaces provide a programming interface for Universal Windows Platform (UWP) apps that act as an HTTP client to perform basic GET requests or implement more advanced HTTP functionality listed below.</span></span>

-   <span data-ttu-id="e88cd-112">一般的な動詞 (**DELETE**、**GET**、**PUT**、**POST**) に対応するメソッド。</span><span class="sxs-lookup"><span data-stu-id="e88cd-112">Methods for common verbs (**DELETE**, **GET**, **PUT**, and **POST**).</span></span> <span data-ttu-id="e88cd-113">これらの各要求は、非同期操作として送られます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-113">Each of these requests are sent as an asynchronous operation.</span></span>

-   <span data-ttu-id="e88cd-114">一般的な認証設定とパターンのサポート。</span><span class="sxs-lookup"><span data-stu-id="e88cd-114">Support for common authentication settings and patterns.</span></span>

-   <span data-ttu-id="e88cd-115">トランスポートに関する Secure Sockets Layer (SSL) 詳細へのアクセス。</span><span class="sxs-lookup"><span data-stu-id="e88cd-115">Access to Secure Sockets Layer (SSL) details on the transport.</span></span>

-   <span data-ttu-id="e88cd-116">カスタマイズされたフィルターを高度なアプリに含める機能。</span><span class="sxs-lookup"><span data-stu-id="e88cd-116">Ability to include customized filters in advanced apps.</span></span>

-   <span data-ttu-id="e88cd-117">Cookie を取得、設定、削除する機能。</span><span class="sxs-lookup"><span data-stu-id="e88cd-117">Ability to get, set, and delete cookies.</span></span>

-   <span data-ttu-id="e88cd-118">非同期メソッドで利用可能な HTTP 要求の進行状況情報。</span><span class="sxs-lookup"><span data-stu-id="e88cd-118">HTTP Request progress info available on asynchronous methods.</span></span>

<span data-ttu-id="e88cd-119">[**Windows.Web.Http.HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) クラスは、[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) から送られた HTTP 要求メッセージを表します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-119">The [**Windows.Web.Http.HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) class represents an HTTP request message sent by [**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639).</span></span> <span data-ttu-id="e88cd-120">[**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) クラスは、HTTP 要求から受け取った HTTP 応答メッセージを表します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-120">The [**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) class represents an HTTP response message received from an HTTP request.</span></span> <span data-ttu-id="e88cd-121">HTTP メッセージは、IETF によって [RFC 2616](http://go.microsoft.com/fwlink/p/?linkid=241642) で規定されています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-121">HTTP messages are defined in [RFC 2616](http://go.microsoft.com/fwlink/p/?linkid=241642) by the IETF.</span></span>

<span data-ttu-id="e88cd-122">[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間は、クッキーを含む HTTP エンティティ ボディおよびヘッダーとして HTTP コンテンツを表します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-122">The [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace represents HTTP content as the HTTP entity body and headers including cookies.</span></span> <span data-ttu-id="e88cd-123">HTTP コンテンツは、HTTP 要求または HTTP 応答に関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-123">HTTP content can be associated with an HTTP request or an HTTP response.</span></span> <span data-ttu-id="e88cd-124">**Windows.Web.Http** 名前空間には、HTTP コンテンツを表す多数のさまざまなクラスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-124">The **Windows.Web.Http** namespace provides a number of different classes to represent HTTP content.</span></span>

-   <span data-ttu-id="e88cd-125">[**HttpBufferContent**](https://msdn.microsoft.com/library/windows/apps/dn298625)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-125">[**HttpBufferContent**](https://msdn.microsoft.com/library/windows/apps/dn298625).</span></span> <span data-ttu-id="e88cd-126">バッファーとしてのコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="e88cd-126">Content as a buffer</span></span>
-   <span data-ttu-id="e88cd-127">[**HttpFormUrlEncodedContent**](https://msdn.microsoft.com/library/windows/apps/dn298685)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-127">[**HttpFormUrlEncodedContent**](https://msdn.microsoft.com/library/windows/apps/dn298685).</span></span> <span data-ttu-id="e88cd-128">**application/x-www-form-urlencoded** MIME タイプでエンコードされた名前と値の組としてのコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="e88cd-128">Content as name and value tuples encoded with the **application/x-www-form-urlencoded** MIME type</span></span>
-   <span data-ttu-id="e88cd-129">[**HttpMultipartContent**](https://msdn.microsoft.com/library/windows/apps/dn298708)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-129">[**HttpMultipartContent**](https://msdn.microsoft.com/library/windows/apps/dn298708).</span></span> <span data-ttu-id="e88cd-130">**multipart/\*** MIME タイプ形式のコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="e88cd-130">Content in the form of the **multipart/\*** MIME type.</span></span>
-   <span data-ttu-id="e88cd-131">[**HttpMultipartFormDataContent**](https://msdn.microsoft.com/library/windows/apps/dn279596)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-131">[**HttpMultipartFormDataContent**](https://msdn.microsoft.com/library/windows/apps/dn279596).</span></span> <span data-ttu-id="e88cd-132">**multipart/form-data** MIME タイプとしてエンコードされているコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="e88cd-132">Content that is encoded as the **multipart/form-data** MIME type.</span></span>
-   <span data-ttu-id="e88cd-133">[**HttpStreamContent**](https://msdn.microsoft.com/library/windows/apps/dn279649)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-133">[**HttpStreamContent**](https://msdn.microsoft.com/library/windows/apps/dn279649).</span></span> <span data-ttu-id="e88cd-134">ストリームとしてのコンテンツ (この内部タイプは、HTTP GET メソッドでのデータの受信、および HTTP POST メソッドでのデータのアップロードに使われます)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-134">Content as a stream (the internal type is used by the HTTP GET method to receive data and the HTTP POST method to upload data)</span></span>
-   <span data-ttu-id="e88cd-135">[**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661)。</span><span class="sxs-lookup"><span data-stu-id="e88cd-135">[**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661).</span></span> <span data-ttu-id="e88cd-136">文字列としてのコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="e88cd-136">Content as a string.</span></span>
-   <span data-ttu-id="e88cd-137">[**IHttpContent**](https://msdn.microsoft.com/library/windows/apps/dn279684) - 開発者が独自のコンテンツ オブジェクトを作成するための基本インターフェイス</span><span class="sxs-lookup"><span data-stu-id="e88cd-137">[**IHttpContent**](https://msdn.microsoft.com/library/windows/apps/dn279684) - A base interface for developers to create their own content objects</span></span>

<span data-ttu-id="e88cd-138">「HTTP 経由でシンプルな GET 要求を送信する」セクションのコード スニペットでは、[**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661) クラスを使って、HTTP GET 要求からの HTTP 応答を文字列として表しています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-138">The code snippet in the "Send a simple GET request over HTTP" section uses the [**HttpStringContent**](https://msdn.microsoft.com/library/windows/apps/dn279661) class to represent the HTTP response from an HTTP GET request as a string.</span></span>

<span data-ttu-id="e88cd-139">[**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) 名前空間では、HTTP ヘッダーと Cookie の作成がサポートされます。これらはプロパティとして、[**HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) オブジェクトと [**HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) オブジェクトに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-139">The [**Windows.Web.Http.Headers**](https://msdn.microsoft.com/library/windows/apps/dn252713) namespace supports creation of HTTP headers and cookies, which are then associated as properties with [**HttpRequestMessage**](https://msdn.microsoft.com/library/windows/apps/dn279617) and [**HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) objects.</span></span>

## <a name="send-a-simple-get-request-over-http"></a><span data-ttu-id="e88cd-140">HTTP 経由でシンプルな GET 要求を送信する</span><span class="sxs-lookup"><span data-stu-id="e88cd-140">Send a simple GET request over HTTP</span></span>

<span data-ttu-id="e88cd-141">この記事の中で既に説明したように、[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間は、UWP アプリで GET 要求を送信できるようにします。</span><span class="sxs-lookup"><span data-stu-id="e88cd-141">As mentioned earlier in this article, the [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) namespace allows UWP apps to send GET requests.</span></span> <span data-ttu-id="e88cd-142">次のコード スニペットは、GET 要求を送信する方法を示しています。 http://www.contoso.com GET 要求から応答を読み取る[**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639)クラスと[**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631)クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-142">The following code snippet demonstrates how to send a GET request to http://www.contoso.com using the [**Windows.Web.Http.HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) class and the [**Windows.Web.Http.HttpResponseMessage**](https://msdn.microsoft.com/library/windows/apps/dn279631) class to read the response from the GET request.</span></span>

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

## <a name="exceptions-in-windowswebhttp"></a><span data-ttu-id="e88cd-143">Windows.Web.Http の例外</span><span class="sxs-lookup"><span data-stu-id="e88cd-143">Exceptions in Windows.Web.Http</span></span>

<span data-ttu-id="e88cd-144">Uniform Resource Identifier (URI) として無効な文字列が、[**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) オブジェクトのコンストラクターに渡されると、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-144">An exception is thrown when an invalid string for a the Uniform Resource Identifier (URI) is passed to the constructor for the [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) object.</span></span>

<span data-ttu-id="e88cd-145">**.NET:** [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998)形式では、c# と VB. [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx)として表示されます</span><span class="sxs-lookup"><span data-stu-id="e88cd-145">**.NET:** The [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) type appears as [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) in C# and VB.</span></span>

<span data-ttu-id="e88cd-146">C# や Visual Basic では、.NET 4.5 の [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) クラスと、[**System.Uri.TryCreate**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.trycreate.aspx) メソッドの 1 つを使って、URI が作成される前にユーザーから受け取った文字列をテストすることによって、このエラーを回避できます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-146">In C# and Visual Basic, this error can be avoided by using the [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) class in the .NET 4.5 and one of the [**System.Uri.TryCreate**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.trycreate.aspx) methods to test the string received from a user before the URI is constructed.</span></span>

<span data-ttu-id="e88cd-147">C++ では、URI として渡される文字列を試行して解析するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="e88cd-147">In C++, there is no method to try and parse a string to a URI.</span></span> <span data-ttu-id="e88cd-148">アプリがユーザーから [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) の入力を取得する場合、このコンストラクターを try/catch ブロックに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e88cd-148">If an app gets input from the user for the [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998), the constructor should be in a try/catch block.</span></span> <span data-ttu-id="e88cd-149">例外がスローされた場合、アプリは、ユーザーに通知し、新しいホスト名を要求することができます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-149">If an exception is thrown, the app can notify the user and request a new hostname.</span></span>

<span data-ttu-id="e88cd-150">[**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) には便利な関数がありません。</span><span class="sxs-lookup"><span data-stu-id="e88cd-150">The [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) lacks a convenience function.</span></span> <span data-ttu-id="e88cd-151">そのため、この名前空間の [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) と他のクラスを使うアプリは、**HRESULT** 値を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e88cd-151">So an app using [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) and other classes in this namespace needs to use the **HRESULT** value.</span></span>

<span data-ttu-id="e88cd-152">アプリでは、c#、VB.NET、 [System.Exception](http://msdn.microsoft.com/library/system.exception.aspx) .NET Framework4.5 を使用してエラーを表しますアプリの実行中に例外が発生した場合。</span><span class="sxs-lookup"><span data-stu-id="e88cd-152">In apps using the .NET Framework4.5 in C#, VB.NET, the [System.Exception](http://msdn.microsoft.com/library/system.exception.aspx) represents an error during app execution when an exception occurs.</span></span> <span data-ttu-id="e88cd-153">[System.Exception.HResult](http://msdn.microsoft.com/library/system.exception.hresult.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-153">The [System.Exception.HResult](http://msdn.microsoft.com/library/system.exception.hresult.aspx) property returns the **HRESULT** assigned to the specific exception.</span></span> <span data-ttu-id="e88cd-154">[System.Exception.Message](http://msdn.microsoft.com/library/system.exception.message.aspx) プロパティは、例外を説明するメッセージを返します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-154">The [System.Exception.Message](http://msdn.microsoft.com/library/system.exception.message.aspx) property returns the message that describes the exception.</span></span> <span data-ttu-id="e88cd-155">使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-155">Possible **HRESULT** values are listed in the *Winerror.h* header file.</span></span> <span data-ttu-id="e88cd-156">アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-156">An app can filter on specific **HRESULT** values to modify app behavior depending on the cause of the exception.</span></span>

<span data-ttu-id="e88cd-157">Managed C++ を使うアプリでは、アプリの実行中に例外が発生したときに、[Platform::Exception](http://msdn.microsoft.com/library/windows/apps/hh755825.aspx) がエラーを表します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-157">In apps using managed C++, the [Platform::Exception](http://msdn.microsoft.com/library/windows/apps/hh755825.aspx) represents an error during app execution when an exception occurs.</span></span> <span data-ttu-id="e88cd-158">[Platform::Exception::HResult](http://msdn.microsoft.com/library/windows/apps/hh763371.aspx) プロパティは、特定の例外に割り当てられた **HRESULT** を返します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-158">The [Platform::Exception::HResult](http://msdn.microsoft.com/library/windows/apps/hh763371.aspx) property returns the **HRESULT** assigned to the specific exception.</span></span> <span data-ttu-id="e88cd-159">[Platform::Exception::Message](http://msdn.microsoft.com/library/windows/apps/hh763375.aspx) プロパティは、**HRESULT** 値に関連付けられた、システムが提供する文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="e88cd-159">The [Platform::Exception::Message](http://msdn.microsoft.com/library/windows/apps/hh763375.aspx) property returns the system-provided string that is associated with the **HRESULT** value.</span></span> <span data-ttu-id="e88cd-160">使うことができる **HRESULT** 値は、*Winerror.h* ヘッダー ファイルに記載されています。</span><span class="sxs-lookup"><span data-stu-id="e88cd-160">Possible **HRESULT** values are listed in the *Winerror.h* header file.</span></span> <span data-ttu-id="e88cd-161">アプリは特定の **HRESULT** 値に対するフィルター処理を行い、例外の原因に応じてアプリの動作を変更できます。</span><span class="sxs-lookup"><span data-stu-id="e88cd-161">An app can filter on specific **HRESULT** values to modify app behavior depending on the cause of the exception.</span></span>

<span data-ttu-id="e88cd-162">ほとんどのパラメーター検証エラーの場合、返される **HRESULT** は **E\_INVALIDARG** です。</span><span class="sxs-lookup"><span data-stu-id="e88cd-162">For most parameter validation errors, the **HRESULT** returned is **E\_INVALIDARG**.</span></span> <span data-ttu-id="e88cd-163">一部の無効なメソッド呼び出しでは、返される **HRESULT** は **E\_ILLEGAL\_METHOD\_CALL** です。</span><span class="sxs-lookup"><span data-stu-id="e88cd-163">For some illegal method calls, the **HRESULT** returned is **E\_ILLEGAL\_METHOD\_CALL**.</span></span>

