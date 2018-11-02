---
title: 接続ストレージのバッファーの操作
author: KevinAsgari
description: 接続ストレージのバッファーの操作について説明します。
ms.assetid: 1d9d1b52-4bfe-4cd9-8b80-50ca6c0e9ae1
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 95a265644897ce9469914782484796a622dcf971
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5918455"
---
# <a name="working-with-connected-storage-buffers"></a><span data-ttu-id="abdb0-104">接続ストレージのバッファーの操作</span><span class="sxs-lookup"><span data-stu-id="abdb0-104">Working with Connected Storage buffers</span></span>

<span data-ttu-id="abdb0-105">接続ストレージ API では、**Windows::Storage::Streams::Buffer** インスタンスを使用してアプリケーションとデータを受け渡しします。</span><span class="sxs-lookup"><span data-stu-id="abdb0-105">The Connected Storage API uses **Windows::Storage::Streams::Buffer** instances to pass data to and from an application.</span></span> <span data-ttu-id="abdb0-106">WinRT 型は RAW ポインターを公開できないため、Buffer インスタンスのデータへのアクセスは **DataReader** および **DataWriter** クラスを通して行います。</span><span class="sxs-lookup"><span data-stu-id="abdb0-106">Because WinRT types cannot expose raw pointers, access to the data of a Buffer instance occurs through **DataReader** and **DataWriter** classes.</span></span> <span data-ttu-id="abdb0-107">ただし、**Buffer** は COM インターフェイス **IBufferByteAccess** も実装し、バッファー データの直接ポインターを取得することを可能にしています。</span><span class="sxs-lookup"><span data-stu-id="abdb0-107">However, **Buffer** also implements the COM interface **IBufferByteAccess**, which makes it possible to obtain a pointer directly to the buffer data.</span></span>

### <a name="to-get-a-pointer-to-a-buffer-instances-data"></a><span data-ttu-id="abdb0-108">Buffer インスタンスのデータへのポインターを取得するには</span><span class="sxs-lookup"><span data-stu-id="abdb0-108">To get a pointer to a Buffer instance's data</span></span>

1.  <span data-ttu-id="abdb0-109">**reinterpret\_cast** を使用して Buffer インスタンスを **IUnknown** にキャストします。</span><span class="sxs-lookup"><span data-stu-id="abdb0-109">Use **reinterpret\_cast** to cast the Buffer instance as **IUnknown**.</span></span>

```cpp
        IUnknown* unknown = reinterpret_cast<IUnknown*>(buffer);
```

2.  <span data-ttu-id="abdb0-110">**IUnknown** インターフェイスをクエリし、**IBufferByteAccess** COM インターフェイスを取得します。</span><span class="sxs-lookup"><span data-stu-id="abdb0-110">Query the **IUnknown** interface for the **IBufferByteAccess** COM interface.</span></span>

```cpp
        Microsoft::WRL::ComPtr<IBufferByteAccess> bufferByteAccess;
        HRESULT hr = unknown->QueryInterface(_uuidof(IBufferByteAccess), &bufferByteAccess);
        if (FAILED(hr))
        return nullptr;
```

3.  <span data-ttu-id="abdb0-111">**IBufferByteAccess::Buffer** を使用して、バッファーのデータの直接ポインターを取得します。</span><span class="sxs-lookup"><span data-stu-id="abdb0-111">Use **IBufferByteAccess::Buffer** to get a pointer directly to the buffer's data.</span></span>

```cpp
        byte* bytes = nullptr;
        bufferByteAccess->Buffer(&bytes);
```

<span data-ttu-id="abdb0-112">たとえば、次のコード例では、現在のシステム時刻を保持するバッファーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="abdb0-112">For example, the following code sample shows how to create a buffer that holds the current system time.</span></span> <span data-ttu-id="abdb0-113">バッファーには独立した容量と長さの値があるため、容量と長さの両方を明示的に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="abdb0-113">Since buffers have a separate capacity and length value it is necessary to explicitly set both the capacity and length.</span></span> <span data-ttu-id="abdb0-114">既定では、長さは 0 です。</span><span class="sxs-lookup"><span data-stu-id="abdb0-114">By default, the length is 0.</span></span>

```cpp
    inline byte* GetBufferData(Windows::Storage::Streams::IBuffer^ buffer)
    {
        using namespace Windows::Storage::Streams;
        IUnknown* unknown = reinterpret_cast<IUnknown*>(buffer);
        Microsoft::WRL::ComPtr<IBufferByteAccess> bufferByteAccess;
        HRESULT hr = unknown->QueryInterface(_uuidof(IBufferByteAccess), &bufferByteAccess);
        if (FAILED(hr))
        return nullptr;
        byte* bytes = nullptr;
        bufferByteAccess->Buffer(&bytes);
        return bytes;
    }

    IBuffer^ WrapRawBuffer( void* ptr, size_t size )
    {
        using namespace Windows::Storage::Streams;

        //uint32 size = sizeof(FILETIME);
        Buffer^ buffer = ref new Buffer(size);
        buffer->Length = size;

        memcpy(GetBufferData(buffer),ptr,size);


        return buffer;

    };
```
