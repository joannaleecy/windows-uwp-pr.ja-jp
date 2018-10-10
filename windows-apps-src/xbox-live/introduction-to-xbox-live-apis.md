---
title: Xbox Live API の概要
author: KevinAsgari
description: Xbox Live サービスとのやり取りに使用できる、さまざまな API モデルについて説明します。
ms.assetid: 5918c3a2-6529-4f07-b44d-51f9861f91ec
ms.author: kevinasg
ms.date: 06/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one
ms.localizationpriority: medium
ms.openlocfilehash: 1f295c1f1b432f90e12d3e628cd35a54412812ec
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4470304"
---
# <a name="introduction-to-xbox-live-apis"></a><span data-ttu-id="6cf6d-104">Xbox Live API の概要</span><span class="sxs-lookup"><span data-stu-id="6cf6d-104">Introduction to Xbox Live APIs</span></span>

## <a name="use-xbox-live-services"></a><span data-ttu-id="6cf6d-105">Xbox Live サービスの使用</span><span class="sxs-lookup"><span data-stu-id="6cf6d-105">Use Xbox Live services</span></span>

<span data-ttu-id="6cf6d-106">Xbox Live サービスから情報を取得する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-106">There are two ways to get information from the Xbox Live services:</span></span>

- <span data-ttu-id="6cf6d-107">Xbox Live Services API (**XSAPI**) と呼ばれるクライアント側 API を使用する</span><span class="sxs-lookup"><span data-stu-id="6cf6d-107">Use a client side API called Xbox Live Services API (**XSAPI**)</span></span>
- <span data-ttu-id="6cf6d-108">**Xbox Live REST エンドポイント**を直接呼び出す</span><span class="sxs-lookup"><span data-stu-id="6cf6d-108">Call the **Xbox Live REST endpoints** directly</span></span>

<span data-ttu-id="6cf6d-109">Xbox Live Services API (**XSAPI**) を使用する方法には、以下のような利点があります。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-109">The advantages of using the Xbox Live Services API (**XSAPI**) include:</span></span>

- <span data-ttu-id="6cf6d-110">認証、エンコーディング、および HTTP 送受信の詳細が自動的に処理されます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-110">Details of authentication, encoding, and HTTP sending and receiving are taken care of for you.</span></span>
- <span data-ttu-id="6cf6d-111">ラッパー API への引数およびラッパー API から返されるデータは、ネイティブのデータ型で処理されるため、JSON エンコーディングおよびデコーディングを実行する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-111">Arguments to, and data returned from, the wrapper API is handled in native data types; so, you don't need to perform JSON encoding and decoding.</span></span>
- <span data-ttu-id="6cf6d-112">Web サービスの直接呼び出しに、ラッパー API でカプセル化される複数の非同期手順が含まれます。これにより、タイトル コードの読み書きが容易になります。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-112">Calling web services directly involves multiple asynchronous steps, which the wrapper API encapsulates; this makes title code easier to read and write.</span></span>
- <span data-ttu-id="6cf6d-113">ゲーム イベントの書き込みなどの一部機能は XSAPI でのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-113">Some functionality, such as writing game events, is only available in XSAPI.</span></span>

<span data-ttu-id="6cf6d-114">**Xbox Live REST エンドポイント**を直接使用する方法には、以下の利点があります。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-114">The advantages of using the **Xbox Live REST endpoints** directly include:</span></span>

- <span data-ttu-id="6cf6d-115">Xbox Live エンドポイントを Web サービスから呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-115">The ability to call Xbox Live endpoints from a web service</span></span>
- <span data-ttu-id="6cf6d-116">XSAPI に含まれていないエンドポイントを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-116">The ability to call endpoints which aren't included in XSAPI.</span></span>  <span data-ttu-id="6cf6d-117">XSAPI には、ゲームで使用すると思われる API のみが含まれています。API が不足している場合は、フォーラムからお知らせください。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-117">XSAPI only includes APIs that we believe games will use, so if there's anything missing let us know via the forums.</span></span>
- <span data-ttu-id="6cf6d-118">REST エンドポイント経由で利用できる一部の機能には、対応する XSAPI ラッパーが存在しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-118">Some functionality available via the REST endpoints may not have a corresponding XSAPI wrapper.</span></span>

<span data-ttu-id="6cf6d-119">ゲームおよびアプリで、以上のどちらかの方法しか使用できないということはありません。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-119">Your games and apps are not limited to using just one of these methods.</span></span> <span data-ttu-id="6cf6d-120">XSAPI ラッパーを使用しつつ、必要な場合は REST エンドポイントを直接呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-120">You can use the XSAPI wrapper and still call the REST endpoints directly if needed.</span></span>

## <a name="xbox-live-services-api-overview"></a><span data-ttu-id="6cf6d-121">Xbox Live Services API の概要</span><span class="sxs-lookup"><span data-stu-id="6cf6d-121">Xbox Live Services API Overview</span></span> ##

<span data-ttu-id="6cf6d-122">Xbox Live Services API (**XSAPI**) は、次の 3 つのセットのクライアント側広範なユーザー シナリオをサポートする Api を公開します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-122">The Xbox Live Services API (**XSAPI**) exposes three sets of client side APIs that support a wide range of customer scenarios:</span></span>

- [<span data-ttu-id="6cf6d-123">XSAPI WinRT API</span><span class="sxs-lookup"><span data-stu-id="6cf6d-123">XSAPI WinRT API</span></span>](#xsapi-winrt-based-api)
- [<span data-ttu-id="6cf6d-124">XSAPI C++11 ベース API</span><span class="sxs-lookup"><span data-stu-id="6cf6d-124">XSAPI C++11 based API</span></span>](#xsapi-c++11-based-api)
- <span data-ttu-id="6cf6d-125">[XSAPI C ベース API](#xsapi-c-based-api)(**2018 6 月の時点で新しい**)</span><span class="sxs-lookup"><span data-stu-id="6cf6d-125">[XSAPI C based API](#xsapi-c-based-api) (**New as of June 2018**)</span></span>

<span data-ttu-id="6cf6d-126">Api を比較するには。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-126">Comparing the APIs:</span></span>

### <a name="xsapi-winrt-based-api"></a><span data-ttu-id="6cf6d-127">XSAPI WinRT ベース API</span><span class="sxs-lookup"><span data-stu-id="6cf6d-127">XSAPI WinRT based API</span></span>

- <span data-ttu-id="6cf6d-128">C++/CX、C#、および JavaScript で記述されたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-128">Supports applications written with C++/CX, C#, and JavaScript.</span></span>
    - <span data-ttu-id="6cf6d-129">C++/CX はマイクロソフトの C++ 拡張であり、^ を WinRT ポインターとして使用するなど、WinRT プログラミングを容易にします。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-129">C++/CX is a Microsoft C++ extension to make WinRT programming easy for example using ^ as WinRT pointers.</span></span>
- <span data-ttu-id="6cf6d-130">Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-130">Supports applications targeting Xbox One XDK platform, and Universal Windows Platform (UWP) x86, x64 and ARM architectures.</span></span>
- <span data-ttu-id="6cf6d-131">C++/CX を含むすべての言語で、エラーは例外を使用して処理されます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-131">Errors are handled via exceptions in all languages including C++/CX.</span></span>
- <span data-ttu-id="6cf6d-132">C++/WinRT もサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-132">C++/WinRT is also supported.</span></span>  <span data-ttu-id="6cf6d-133">詳細については、C++/cli で WinRT を入手できます[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span><span class="sxs-lookup"><span data-stu-id="6cf6d-133">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span></span>

<span data-ttu-id="6cf6d-134">C++/WinRT を使用する XSAPI WinRT API の呼び出しの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-134">Here's an example of calling the XSAPI WinRT API using C++/WinRT:</span></span>

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```

<span data-ttu-id="6cf6d-135">コードの移行時に C++/CX と C++/WinRT を混在したい場合は、このようにすることもできますが、少し複雑です。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-135">If you want to mix C++/CX and C++/WinRT as you are migrating code you can do this too but is a little more complex.</span></span>  
<span data-ttu-id="6cf6d-136">C++/WinRT を使用する C++/CX User^ オブジェクトが指定された XSAPI WinRT API の呼び出しの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-136">Here's an example of calling the XSAPI WinRT API using C++/WinRT given C++/CX User^ object.</span></span>

```c++
::Windows::Xbox::System::User^ user1 = ::Windows::Xbox::System::User::Users->GetAt(0);
winrt::Windows::Xbox::System::User cppWinrtUser(nullptr);
winrt::copy_from(cppWinrtUser, reinterpret_cast<winrt::ABI::Windows::Xbox::System::IUser*>(user1));
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```


### <a name="xsapi-c11-based-api"></a><span data-ttu-id="6cf6d-137">XSAPI C++11 ベース API</span><span class="sxs-lookup"><span data-stu-id="6cf6d-137">XSAPI C++11 based API</span></span>

- <span data-ttu-id="6cf6d-138">クロス プラットフォームの ISO 標準 C++11 を使用します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-138">Uses cross platform ISO standard C++11</span></span>
- <span data-ttu-id="6cf6d-139">C++ で記述されたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-139">Supports applications written with C++</span></span>
- <span data-ttu-id="6cf6d-140">Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-140">Supports applications targeting Xbox One XDK platform, and Universal Windows Platform (UWP) x86, x64 and ARM architectures.</span></span>
- <span data-ttu-id="6cf6d-141">エラーは std::error_code を使用して処理されます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-141">Errors are handled via std::error_code.</span></span>
- <span data-ttu-id="6cf6d-142">パフォーマンスとデバッグの向上のため、C++ のゲーム エンジンを使用する場合は C++11 ベースの API が推奨されます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-142">The C++11 based API is the recommended API to use for C++ game engines for better performance, and better debugging.</span></span>
- <span data-ttu-id="6cf6d-143">Xbox Live クリエーターズ プログラムに参加している場合、XSAPI ヘッダーをインクルードする前に XBOX_LIVE_CREATORS_SDK を定義します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-143">If you are in the Xbox Live Creators Program, before including the XSAPI header define XBOX_LIVE_CREATORS_SDK.</span></span> <span data-ttu-id="6cf6d-144">これによって、API サーフェイス領域は Xbox Live Creators Program の開発者が使用できるもののみに制限されます。また、Xbox Live クリエーターズ プログラムのタイトルで機能するサインイン メソッドが変更されます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-144">This limits the API surface area to only those that are usable by developers in the Xbox Live Creators Program and changes the sign-in method to work for titles in the Creators program.</span></span>  <span data-ttu-id="6cf6d-145">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-145">For example:</span></span>

```c++
#define XBOX_LIVE_CREATORS_SDK
#include "xsapi\services.h"
```

- <span data-ttu-id="6cf6d-146">C++/WinRT もサポートされます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-146">C++/WinRT is also supported.</span></span>  <span data-ttu-id="6cf6d-147">詳細については、C++/cli で WinRT を入手できます[https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span><span class="sxs-lookup"><span data-stu-id="6cf6d-147">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span></span>

<span data-ttu-id="6cf6d-148">C++/WinRT と XSAPI C++ API を使うには、XSAPI ヘッダーをインクルードする前に XSAPI_CPPWINRT を定義します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-148">To use C++/WinRT with the XSAPI C++ API, before including the XSAPI header define XSAPI_CPPWINRT.</span></span>  <span data-ttu-id="6cf6d-149">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-149">For example:</span></span>

```c++
#define XSAPI_CPPWINRT
#include "xsapi\services.h"
```

<span data-ttu-id="6cf6d-150">C++/WinRT を使用した XSAPI C++ API の呼び出しの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-150">Here's an example of calling the XSAPI C++ API using C++/WinRT:</span></span>

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
std::shared_ptr<xbox::services::xbox_live_context> xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>(cppWinrtUser);
```

### <a name="xsapi-c-based-api"></a><span data-ttu-id="6cf6d-151">XSAPI C ベース API</span><span class="sxs-lookup"><span data-stu-id="6cf6d-151">XSAPI C based API</span></span>

- <span data-ttu-id="6cf6d-152">タイトルを XSAPI を呼び出すと、メモリ割り当てを制御できます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-152">Allows titles to control the memory allocations when calling XSAPI.</span></span>
- <span data-ttu-id="6cf6d-153">タイトル XSAPI を呼び出すときの処理スレッドの完全な制御を取得できます。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-153">Allows titles to gain full control of thread handling when calling XSAPI.</span></span>
- <span data-ttu-id="6cf6d-154">新しい HTTP ライブラリ、libHttpClient、ゲーム開発者向けに設計されたを使用します。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-154">Uses a new HTTP library, libHttpClient, designed for game developers.</span></span>

<span data-ttu-id="6cf6d-155">詳細については、 [Xbox Live C Api の概要](xsapi-flat-c.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6cf6d-155">For more information, see [Introduction to the Xbox Live C APIs](xsapi-flat-c.md).</span></span>
