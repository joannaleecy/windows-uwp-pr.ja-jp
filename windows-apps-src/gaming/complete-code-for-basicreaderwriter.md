---
title: BasicReaderWriter のコード一式
description: バイナリ データ ファイル全般の読み書きを行うクラスとメソッドのコード一式です。
ms.assetid: af968edd-df5c-b8e6-479e-bfa9689380fc
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、BasicReaderWriter
ms.localizationpriority: medium
ms.openlocfilehash: 60c2bf74de1e56004f1f705f317bc6bd1bb34b26
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8787641"
---
# <a name="complete-code-for-basicreaderwriter"></a><span data-ttu-id="a438e-104">BasicReaderWriter のコード一式</span><span class="sxs-lookup"><span data-stu-id="a438e-104">Complete code for BasicReaderWriter</span></span>



<span data-ttu-id="a438e-105">バイナリ データ ファイル全般の読み書きを行うクラスとメソッドのコード一式です。</span><span class="sxs-lookup"><span data-stu-id="a438e-105">Complete code for a class and methods for reading and writing binary data files in general.</span></span> <span data-ttu-id="a438e-106">[BasicLoader](complete-code-for-basicloader.md) クラスで使われます。</span><span class="sxs-lookup"><span data-stu-id="a438e-106">Used by the [BasicLoader](complete-code-for-basicloader.md) class.</span></span>

<span data-ttu-id="a438e-107">このトピックは次のセクションで構成されます。</span><span class="sxs-lookup"><span data-stu-id="a438e-107">This topic contains these sections:</span></span>

-   [<span data-ttu-id="a438e-108">テクノロジ</span><span class="sxs-lookup"><span data-stu-id="a438e-108">Technologies</span></span>](#technologies)
-   [<span data-ttu-id="a438e-109">必要条件</span><span class="sxs-lookup"><span data-stu-id="a438e-109">Requirements</span></span>](#requirements)
-   [<span data-ttu-id="a438e-110">コードの表示 (C++)</span><span class="sxs-lookup"><span data-stu-id="a438e-110">View the code (C++)</span></span>](#view-the-code-c)


## <a name="download-location"></a><span data-ttu-id="a438e-111">ダウンロード場所</span><span class="sxs-lookup"><span data-stu-id="a438e-111">Download location</span></span>

<span data-ttu-id="a438e-112">このサンプルはダウンロードできません。</span><span class="sxs-lookup"><span data-stu-id="a438e-112">This sample is not available for download.</span></span>


## <a name="technologies"></a><span data-ttu-id="a438e-113">テクノロジ</span><span class="sxs-lookup"><span data-stu-id="a438e-113">Technologies</span></span>

<span data-ttu-id="a438e-114">**プログラミング言語** - C++</span><span class="sxs-lookup"><span data-stu-id="a438e-114">**Programming languages** -  C++</span></span>  
<span data-ttu-id="a438e-115">**プログラミング モデル** - Windows ランタイム</span><span class="sxs-lookup"><span data-stu-id="a438e-115">**Programming models** - Windows Runtime</span></span>


## <a name="requirements"></a><span data-ttu-id="a438e-116">要件</span><span class="sxs-lookup"><span data-stu-id="a438e-116">Requirements</span></span>

 <span data-ttu-id="a438e-117">**サポートされている最小のクライアント** - Windows 10</span><span class="sxs-lookup"><span data-stu-id="a438e-117">**Minimum supported client** - Windows 10</span></span>       
 <span data-ttu-id="a438e-118">**サポートされている最小のサーバー** - Windows Server 2016 Technical Preview</span><span class="sxs-lookup"><span data-stu-id="a438e-118">**Minimum supported server** - Windows Server 2016 Technical Preview</span></span> 

## <a name="view-the-code-c"></a><span data-ttu-id="a438e-119">コードの表示 (C++)</span><span class="sxs-lookup"><span data-stu-id="a438e-119">View the code (C++)</span></span>


## <a name="basicreaderwriterh"></a><span data-ttu-id="a438e-120">BasicReaderWriter.h</span><span class="sxs-lookup"><span data-stu-id="a438e-120">BasicReaderWriter.h</span></span>


```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include <ppltasks.h>

// A simple reader/writer class that provides support for reading and writing
// files on disk. Provides synchronous and asynchronous methods.
ref class BasicReaderWriter
{
private:
    Windows::Storage::StorageFolder^ m_location;
    Platform::String^ m_locationPath;

internal:
    BasicReaderWriter();
    BasicReaderWriter(
        _In_ Windows::Storage::StorageFolder^ folder
        );

    Platform::Array<byte>^ ReadData(
        _In_ Platform::String^ filename
        );

    concurrency::task<Platform::Array<byte>^> ReadDataAsync(
        _In_ Platform::String^ filename
        );

    uint32 WriteData(
        _In_ Platform::String^ filename,
        _In_ const Platform::Array<byte>^ fileData
        );

    concurrency::task<void> WriteDataAsync(
        _In_ Platform::String^ filename,
        _In_ const Platform::Array<byte>^ fileData
        );
};
```

## <a name="basicreaderwritercpp"></a><span data-ttu-id="a438e-121">BasicReaderWriter.cpp</span><span class="sxs-lookup"><span data-stu-id="a438e-121">BasicReaderWriter.cpp</span></span>


```cpp
using namespace Microsoft::WRL;
using namespace Windows::Storage;
using namespace Windows::Storage::FileProperties;
using namespace Windows::Storage::Streams;
using namespace Windows::Foundation;
using namespace Windows::ApplicationModel;
using namespace concurrency;

BasicReaderWriter::BasicReaderWriter()
{
    m_location = Package::Current->InstalledLocation;
    m_locationPath = Platform::String::Concat(m_location->Path, "\\");
}

BasicReaderWriter::BasicReaderWriter(
    _In_ Windows::Storage::StorageFolder^ folder
    )
{
    m_location = folder;
    Platform::String^ path = m_location->Path;
    if (path->Length() == 0)
    {
        // Applications are not permitted to access certain
        // folders, such as the Documents folder, using this
        // code path.  In such cases, the Path property for
        // the folder will be an empty string.
        throw ref new Platform::FailureException();
    }
    m_locationPath = Platform::String::Concat(path, "\\");
}

Platform::Array<byte>^ BasicReaderWriter::ReadData(
    _In_ Platform::String^ filename
    )
{
    CREATEFILE2_EXTENDED_PARAMETERS extendedParams = {0};
    extendedParams.dwSize = sizeof(CREATEFILE2_EXTENDED_PARAMETERS);
    extendedParams.dwFileAttributes = FILE_ATTRIBUTE_NORMAL;
    extendedParams.dwFileFlags = FILE_FLAG_SEQUENTIAL_SCAN;
    extendedParams.dwSecurityQosFlags = SECURITY_ANONYMOUS;
    extendedParams.lpSecurityAttributes = nullptr;
    extendedParams.hTemplateFile = nullptr;

    Wrappers::FileHandle file(
        CreateFile2(
            Platform::String::Concat(m_locationPath, filename)->Data(),
            GENERIC_READ,
            FILE_SHARE_READ,
            OPEN_EXISTING,
            &extendedParams
            )
        );
    if (file.Get() == INVALID_HANDLE_VALUE)
    {
        throw ref new Platform::FailureException();
    }

    FILE_STANDARD_INFO fileInfo = {0};
    if (!GetFileInformationByHandleEx(
        file.Get(),
        FileStandardInfo,
        &fileInfo,
        sizeof(fileInfo)
        ))
    {
        throw ref new Platform::FailureException();
    }

    if (fileInfo.EndOfFile.HighPart != 0)
    {
        throw ref new Platform::OutOfMemoryException();
    }

    Platform::Array<byte>^ fileData = ref new Platform::Array<byte>(fileInfo.EndOfFile.LowPart);

    if (!ReadFile(
        file.Get(),
        fileData->Data,
        fileData->Length,
        nullptr,
        nullptr
        ))
    {
        throw ref new Platform::FailureException();
    }

    return fileData;
}

task<Platform::Array<byte>^> BasicReaderWriter::ReadDataAsync(
    _In_ Platform::String^ filename
    )
{
    return task<StorageFile^>(m_location->GetFileAsync(filename)).then([=](StorageFile^ file)
    {
        return FileIO::ReadBufferAsync(file);
    }).then([=](IBuffer^ buffer)
    {
        auto fileData = ref new Platform::Array<byte>(buffer->Length);
        DataReader::FromBuffer(buffer)->ReadBytes(fileData);
        return fileData;
    });
}

uint32 BasicReaderWriter::WriteData(
    _In_ Platform::String^ filename,
    _In_ const Platform::Array<byte>^ fileData
    )
{
    CREATEFILE2_EXTENDED_PARAMETERS extendedParams = {0};
    extendedParams.dwSize = sizeof(CREATEFILE2_EXTENDED_PARAMETERS);
    extendedParams.dwFileAttributes = FILE_ATTRIBUTE_NORMAL;
    extendedParams.dwFileFlags = FILE_FLAG_SEQUENTIAL_SCAN;
    extendedParams.dwSecurityQosFlags = SECURITY_ANONYMOUS;
    extendedParams.lpSecurityAttributes = nullptr;
    extendedParams.hTemplateFile = nullptr;

    Wrappers::FileHandle file(
        CreateFile2(
            Platform::String::Concat(m_locationPath, filename)->Data(),
            GENERIC_WRITE,
            0,
            CREATE_ALWAYS,
            &extendedParams
            )
        );
    if (file.Get() == INVALID_HANDLE_VALUE)
    {
        throw ref new Platform::FailureException();
    }

    DWORD numBytesWritten;
    if (
        !WriteFile(
            file.Get(),
            fileData->Data,
            fileData->Length,
            &numBytesWritten,
            nullptr
            ) ||
        numBytesWritten != fileData->Length
        )
    {
        throw ref new Platform::FailureException();
    }

    return numBytesWritten;
}

task<void> BasicReaderWriter::WriteDataAsync(
    _In_ Platform::String^ filename,
    _In_ const Platform::Array<byte>^ fileData
    )
{
    return task<StorageFile^>(m_location->CreateFileAsync(filename, CreationCollisionOption::ReplaceExisting)).then([=](StorageFile^ file)
    {
        FileIO::WriteBytesAsync(file, fileData);
    });
}
```

 

 




