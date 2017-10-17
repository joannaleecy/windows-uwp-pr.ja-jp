---
title: Introduction to Xbox Live APIs
author: KevinAsgari
description: Learn about the various API models that you can use to interact with the Xbox Live service.
ms.assetid: 5918c3a2-6529-4f07-b44d-51f9861f91ec
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one
ms.openlocfilehash: ebf37e9e7f75fc72dd2e1234e10006daebc07356
ms.sourcegitcommit: b73a57142b9847b09ebb00e81396f2655bbc26ec
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2017
---
# <a name="introduction-to-xbox-live-apis"></a><span data-ttu-id="09ea0-104">Introduction to Xbox Live APIs</span><span class="sxs-lookup"><span data-stu-id="09ea0-104">Introduction to Xbox Live APIs</span></span>

## <a name="use-xbox-live-services"></a><span data-ttu-id="09ea0-105">Use Xbox Live services</span><span class="sxs-lookup"><span data-stu-id="09ea0-105">Use Xbox Live services</span></span>

<span data-ttu-id="09ea0-106">There are two ways to get information from the Xbox Live services:</span><span class="sxs-lookup"><span data-stu-id="09ea0-106">There are two ways to get information from the Xbox Live services:</span></span>

- <span data-ttu-id="09ea0-107">Use a client side API called Xbox Live Services API (**XSAPI**)</span><span class="sxs-lookup"><span data-stu-id="09ea0-107">Use a client side API called Xbox Live Services API (**XSAPI**)</span></span>
- <span data-ttu-id="09ea0-108">Call the **Xbox Live REST endpoints** directly</span><span class="sxs-lookup"><span data-stu-id="09ea0-108">Call the **Xbox Live REST endpoints** directly</span></span>

<span data-ttu-id="09ea0-109">The advantages of using the Xbox Live Services API (**XSAPI**) include:</span><span class="sxs-lookup"><span data-stu-id="09ea0-109">The advantages of using the Xbox Live Services API (**XSAPI**) include:</span></span>

- <span data-ttu-id="09ea0-110">Details of authentication, encoding, and HTTP sending and receiving are taken care of for you.</span><span class="sxs-lookup"><span data-stu-id="09ea0-110">Details of authentication, encoding, and HTTP sending and receiving are taken care of for you.</span></span>
- <span data-ttu-id="09ea0-111">Arguments to, and data returned from, the wrapper API is handled in native data types; so, you don't need to perform JSON encoding and decoding.</span><span class="sxs-lookup"><span data-stu-id="09ea0-111">Arguments to, and data returned from, the wrapper API is handled in native data types; so, you don't need to perform JSON encoding and decoding.</span></span>
- <span data-ttu-id="09ea0-112">Calling web services directly involves multiple asynchronous steps, which the wrapper API encapsulates; this makes title code easier to read and write.</span><span class="sxs-lookup"><span data-stu-id="09ea0-112">Calling web services directly involves multiple asynchronous steps, which the wrapper API encapsulates; this makes title code easier to read and write.</span></span>
- <span data-ttu-id="09ea0-113">Some functionality, such as writing game events, is only available in XSAPI.</span><span class="sxs-lookup"><span data-stu-id="09ea0-113">Some functionality, such as writing game events, is only available in XSAPI.</span></span>

<span data-ttu-id="09ea0-114">The advantages of using the **Xbox Live REST endpoints** directly include:</span><span class="sxs-lookup"><span data-stu-id="09ea0-114">The advantages of using the **Xbox Live REST endpoints** directly include:</span></span>

- <span data-ttu-id="09ea0-115">Able to call Xbox Live endpoints from a web service</span><span class="sxs-lookup"><span data-stu-id="09ea0-115">Able to call Xbox Live endpoints from a web service</span></span>
- <span data-ttu-id="09ea0-116">Able to call endpoints which aren't included in XSAPI.</span><span class="sxs-lookup"><span data-stu-id="09ea0-116">Able to call endpoints which aren't included in XSAPI.</span></span>  <span data-ttu-id="09ea0-117">XSAPI only includes APIs that we believe games will use, so if there's anything missing you need to call let us know via the forums.</span><span class="sxs-lookup"><span data-stu-id="09ea0-117">XSAPI only includes APIs that we believe games will use, so if there's anything missing you need to call let us know via the forums.</span></span>
- <span data-ttu-id="09ea0-118">Some functionality available via the REST endpoints may not have a corresponding XSAPI wrapper.</span><span class="sxs-lookup"><span data-stu-id="09ea0-118">Some functionality available via the REST endpoints may not have a corresponding XSAPI wrapper.</span></span>

<span data-ttu-id="09ea0-119">Your games and apps are not limited to using just one of these methods.</span><span class="sxs-lookup"><span data-stu-id="09ea0-119">Your games and apps are not limited to using just one of these methods.</span></span> <span data-ttu-id="09ea0-120">You can use the XSAPI wrapper and still call the REST endpoints directly if needed.</span><span class="sxs-lookup"><span data-stu-id="09ea0-120">You can use the XSAPI wrapper and still call the REST endpoints directly if needed.</span></span>

## <a name="xbox-live-services-api-overview"></a><span data-ttu-id="09ea0-121">Xbox Live Services API Overview</span><span class="sxs-lookup"><span data-stu-id="09ea0-121">Xbox Live Services API Overview</span></span> ##

<span data-ttu-id="09ea0-122">The Xbox Live Services API (**XSAPI**) exposes two sets of client side APIs that support a wide range of customer scenarios:</span><span class="sxs-lookup"><span data-stu-id="09ea0-122">The Xbox Live Services API (**XSAPI**) exposes two sets of client side APIs that support a wide range of customer scenarios:</span></span>

- <span data-ttu-id="09ea0-123">XSAPI WinRT API</span><span class="sxs-lookup"><span data-stu-id="09ea0-123">XSAPI WinRT API</span></span>
- <span data-ttu-id="09ea0-124">XSAPI C++11 based API</span><span class="sxs-lookup"><span data-stu-id="09ea0-124">XSAPI C++11 based API</span></span>

<span data-ttu-id="09ea0-125">Comparing the two APIs:</span><span class="sxs-lookup"><span data-stu-id="09ea0-125">Comparing the two APIs:</span></span>

**<span data-ttu-id="09ea0-126">XSAPI WinRT based API</span><span class="sxs-lookup"><span data-stu-id="09ea0-126">XSAPI WinRT based API</span></span>**

- <span data-ttu-id="09ea0-127">Supports applications written with C++/CX, C#, and JavaScript.</span><span class="sxs-lookup"><span data-stu-id="09ea0-127">Supports applications written with C++/CX, C#, and JavaScript.</span></span>
    - <span data-ttu-id="09ea0-128">C++/CX is a Microsoft C++ extension to make WinRT programming easy for example using ^ as WinRT pointers.</span><span class="sxs-lookup"><span data-stu-id="09ea0-128">C++/CX is a Microsoft C++ extension to make WinRT programming easy for example using ^ as WinRT pointers.</span></span>
- <span data-ttu-id="09ea0-129">Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="09ea0-129">Supports applications targeting Xbox One XDK platform, and Universal Windows Platform (UWP) x86, x64 and ARM architectures.</span></span>
- <span data-ttu-id="09ea0-130">Errors are handled via exceptions in all languages including C++/CX.</span><span class="sxs-lookup"><span data-stu-id="09ea0-130">Errors are handled via exceptions in all languages including C++/CX.</span></span>
- <span data-ttu-id="09ea0-131">C++/WinRT is also supported.</span><span class="sxs-lookup"><span data-stu-id="09ea0-131">C++/WinRT is also supported.</span></span>  <span data-ttu-id="09ea0-132">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span><span class="sxs-lookup"><span data-stu-id="09ea0-132">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span></span>

<span data-ttu-id="09ea0-133">Here's an example of calling the XSAPI WinRT API using C++/WinRT:</span><span class="sxs-lookup"><span data-stu-id="09ea0-133">Here's an example of calling the XSAPI WinRT API using C++/WinRT:</span></span>

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```

<span data-ttu-id="09ea0-134">If you want to mix C++/CX and C++/WinRT as you are migrating code you can do this too but is a little more complex.</span><span class="sxs-lookup"><span data-stu-id="09ea0-134">If you want to mix C++/CX and C++/WinRT as you are migrating code you can do this too but is a little more complex.</span></span>  
<span data-ttu-id="09ea0-135">Here's an example of calling the XSAPI WinRT API using C++/WinRT given C++/CX User^ object.</span><span class="sxs-lookup"><span data-stu-id="09ea0-135">Here's an example of calling the XSAPI WinRT API using C++/WinRT given C++/CX User^ object.</span></span>

```c++
::Windows::Xbox::System::User^ user1 = ::Windows::Xbox::System::User::Users->GetAt(0);
winrt::Windows::Xbox::System::User cppWinrtUser(nullptr);
winrt::copy_from(cppWinrtUser, reinterpret_cast<winrt::ABI::Windows::Xbox::System::IUser*>(user1));
winrt::Microsoft::Xbox::Services::XboxLiveContext xblContext(cppWinrtUser);
```


**<span data-ttu-id="09ea0-136">XSAPI C++11 based API</span><span class="sxs-lookup"><span data-stu-id="09ea0-136">XSAPI C++11 based API</span></span>**

- <span data-ttu-id="09ea0-137">Uses cross platform ISO standard C++11</span><span class="sxs-lookup"><span data-stu-id="09ea0-137">Uses cross platform ISO standard C++11</span></span>
- <span data-ttu-id="09ea0-138">Supports applications written with C++</span><span class="sxs-lookup"><span data-stu-id="09ea0-138">Supports applications written with C++</span></span>
- <span data-ttu-id="09ea0-139">Xbox One XDK プラットフォーム、および x86、x64、ARM の各アーキテクチャのユニバーサル Windows プラットフォーム (UWP) をターゲットにしたアプリケーションをサポートします。</span><span class="sxs-lookup"><span data-stu-id="09ea0-139">Supports applications targeting Xbox One XDK platform, and Universal Windows Platform (UWP) x86, x64 and ARM architectures.</span></span> 
- <span data-ttu-id="09ea0-140">Errors are handled via std::error_code.</span><span class="sxs-lookup"><span data-stu-id="09ea0-140">Errors are handled via std::error_code.</span></span>
- <span data-ttu-id="09ea0-141">The C++11 based API is the recommended API to use for C++ game engines for better performance, and better debugging.</span><span class="sxs-lookup"><span data-stu-id="09ea0-141">The C++11 based API is the recommended API to use for C++ game engines for better performance, and better debugging.</span></span>
- <span data-ttu-id="09ea0-142">If you are in the Xbox Live Creators Program, before including the XSAPI header define XBOX_LIVE_CREATORS_SDK.</span><span class="sxs-lookup"><span data-stu-id="09ea0-142">If you are in the Xbox Live Creators Program, before including the XSAPI header define XBOX_LIVE_CREATORS_SDK.</span></span> <span data-ttu-id="09ea0-143">This limits the API surface area to only those that are usable by developers in the Xbox Live Creators Program and changes the sign-in method to work for titles in the Creators program.</span><span class="sxs-lookup"><span data-stu-id="09ea0-143">This limits the API surface area to only those that are usable by developers in the Xbox Live Creators Program and changes the sign-in method to work for titles in the Creators program.</span></span>  <span data-ttu-id="09ea0-144">For example:</span><span class="sxs-lookup"><span data-stu-id="09ea0-144">For example:</span></span>

```c++
#define XBOX_LIVE_CREATORS_SDK
#include "xsapi\services.h"
```

- <span data-ttu-id="09ea0-145">C++/WinRT is also supported.</span><span class="sxs-lookup"><span data-stu-id="09ea0-145">C++/WinRT is also supported.</span></span>  <span data-ttu-id="09ea0-146">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span><span class="sxs-lookup"><span data-stu-id="09ea0-146">More information about C++/WinRT can be found at [https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/](https://moderncpp.com/2016/10/13/cppwinrt-available-on-github/)</span></span>

<span data-ttu-id="09ea0-147">To use C++/WinRT with the XSAPI C++ API, before including the XSAPI header define XSAPI_CPPWINRT.</span><span class="sxs-lookup"><span data-stu-id="09ea0-147">To use C++/WinRT with the XSAPI C++ API, before including the XSAPI header define XSAPI_CPPWINRT.</span></span>  <span data-ttu-id="09ea0-148">For example:</span><span class="sxs-lookup"><span data-stu-id="09ea0-148">For example:</span></span>

```c++
#define XSAPI_CPPWINRT
#include "xsapi\services.h"
```

<span data-ttu-id="09ea0-149">Here's an example of calling the XSAPI C++ API using C++/WinRT:</span><span class="sxs-lookup"><span data-stu-id="09ea0-149">Here's an example of calling the XSAPI C++ API using C++/WinRT:</span></span>

```c++
winrt::Windows::Xbox::System::User cppWinrtUser = winrt::Windows::Xbox::System::User::Users().GetAt(0);
std::shared_ptr<xbox::services::xbox_live_context> xboxLiveContext = std::make_shared<xbox::services::xbox_live_context>(cppWinrtUser);
```
