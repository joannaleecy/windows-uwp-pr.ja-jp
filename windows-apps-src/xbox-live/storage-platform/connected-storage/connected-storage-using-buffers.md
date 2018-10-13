---
title: 接続ストレージのバッファーの操作
author: KevinAsgari
description: 接続ストレージのバッファーの操作について説明します。
ms.assetid: 1d9d1b52-4bfe-4cd9-8b80-50ca6c0e9ae1
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: cc1f3d828908eeb57503d68b567ae4b69318b23a
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4570624"
---
# <a name="working-with-connected-storage-buffers"></a>接続ストレージのバッファーの操作

接続ストレージ API では、**Windows::Storage::Streams::Buffer** インスタンスを使用してアプリケーションとデータを受け渡しします。 WinRT 型は RAW ポインターを公開できないため、Buffer インスタンスのデータへのアクセスは **DataReader** および **DataWriter** クラスを通して行います。 ただし、**Buffer** は COM インターフェイス **IBufferByteAccess** も実装し、バッファー データの直接ポインターを取得することを可能にしています。

### <a name="to-get-a-pointer-to-a-buffer-instances-data"></a>Buffer インスタンスのデータへのポインターを取得するには

1.  **reinterpret\_cast** を使用して Buffer インスタンスを **IUnknown** にキャストします。

```cpp
        IUnknown* unknown = reinterpret_cast<IUnknown*>(buffer);
```

2.  **IUnknown** インターフェイスをクエリし、**IBufferByteAccess** COM インターフェイスを取得します。

```cpp
        Microsoft::WRL::ComPtr<IBufferByteAccess> bufferByteAccess;
        HRESULT hr = unknown->QueryInterface(_uuidof(IBufferByteAccess), &bufferByteAccess);
        if (FAILED(hr))
        return nullptr;
```

3.  **IBufferByteAccess::Buffer** を使用して、バッファーのデータの直接ポインターを取得します。

```cpp
        byte* bytes = nullptr;
        bufferByteAccess->Buffer(&bytes);
```

たとえば、次のコード例では、現在のシステム時刻を保持するバッファーを作成する方法を示しています。 バッファーには独立した容量と長さの値があるため、容量と長さの両方を明示的に設定する必要があります。 既定では、長さは 0 です。

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
