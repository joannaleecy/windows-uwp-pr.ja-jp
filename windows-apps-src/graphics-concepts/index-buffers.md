---
title: インデックス バッファー
description: インデックス バッファー は、インデックス データを格納するメモリ バッファーです。インデックス データは頂点バッファーへの整数オフセットで、プリミティブのレンダリングに使われます。
ms.assetid: 14D3DEC5-CF74-488B-BE41-16BF5E3201BE
keywords:
- インデックス バッファー
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0df56ebeefdbdabe5904547d77e90077549422c2
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6459374"
---
# <a name="index-buffers"></a><span data-ttu-id="1d3be-104">インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="1d3be-104">Index buffers</span></span>


<span data-ttu-id="1d3be-105">*インデックス バッファー*は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。</span><span class="sxs-lookup"><span data-stu-id="1d3be-105">*Index buffers* are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span>

<span data-ttu-id="1d3be-106">インデックス バッファーは、インデックス データを含むメモリ バッファーです。</span><span class="sxs-lookup"><span data-stu-id="1d3be-106">Index buffers are memory buffers that contain index data.</span></span> <span data-ttu-id="1d3be-107">インデックス データ (つまり、インデックス) は、頂点バッファーへの整数オフセットであり、プリミティブのレンダリングに使用されます。</span><span class="sxs-lookup"><span data-stu-id="1d3be-107">Index data, or indices, are integer offsets into vertex buffers and are used to render primitives.</span></span>

<span data-ttu-id="1d3be-108">頂点バッファーには、頂点が含まれているため、インデックス化されたプリミティブがあってもなくても頂点バッファーを描画できます。</span><span class="sxs-lookup"><span data-stu-id="1d3be-108">A vertex buffer contains vertices; therefore, you can draw a vertex buffer either with or without indexed primitives.</span></span> <span data-ttu-id="1d3be-109">ただし、インデックス バッファーにはインデックスが含まれているため、対応する頂点バッファーがなければインデックス バッファーを使うことができません。</span><span class="sxs-lookup"><span data-stu-id="1d3be-109">However, because an index buffer contains indices, you cannot use an index buffer without a corresponding vertex buffer.</span></span>

## <a name="span-idindexbufferdescriptionspanspan-idindexbufferdescriptionspanspan-idindexbufferdescriptionspanindex-buffer-description"></a><span data-ttu-id="1d3be-110"><span id="Index_Buffer_Description"></span><span id="index_buffer_description"></span><span id="INDEX_BUFFER_DESCRIPTION"></span>インデックス バッファーの記述</span><span class="sxs-lookup"><span data-stu-id="1d3be-110"><span id="Index_Buffer_Description"></span><span id="index_buffer_description"></span><span id="INDEX_BUFFER_DESCRIPTION"></span>Index Buffer Description</span></span>


<span data-ttu-id="1d3be-111">インデックス バッファーは、メモリ内のどこに存在するか、読み取りと書き込みをサポートするかどうか、含めることができるインデックスの種類と数など、機能の観点から記述されます。</span><span class="sxs-lookup"><span data-stu-id="1d3be-111">An index buffer is described in terms of its capabilities, such as where it exists in memory, whether it supports reading and writing, and the type and number of indices it can contain.</span></span>

<span data-ttu-id="1d3be-112">インデックス バッファーの記述は、既存のバッファーがどのように作成されたかをアプリケーションに示します。</span><span class="sxs-lookup"><span data-stu-id="1d3be-112">Index buffer descriptions tell your application how an existing buffer was created.</span></span> <span data-ttu-id="1d3be-113">以前に作成されたインデックス バッファーを埋めるには、システムに空の記述構造を提供します。</span><span class="sxs-lookup"><span data-stu-id="1d3be-113">You provide an empty description structure for the system to fill with the capabilities of a previously created index buffer.</span></span>

## <a name="span-idindexprocessingrequirementsspanspan-idindexprocessingrequirementsspanspan-idindexprocessingrequirementsspanindex-processing-requirements"></a><span data-ttu-id="1d3be-114"><span id="Index_Processing_Requirements"></span><span id="index_processing_requirements"></span><span id="INDEX_PROCESSING_REQUIREMENTS"></span>インデックス処理の要件</span><span class="sxs-lookup"><span data-stu-id="1d3be-114"><span id="Index_Processing_Requirements"></span><span id="index_processing_requirements"></span><span id="INDEX_PROCESSING_REQUIREMENTS"></span>Index Processing Requirements</span></span>


<span data-ttu-id="1d3be-115">インデックス処理操作のパフォーマンスは、インデックス バッファーがメモリ内のどこに存在するかと、使われるレンダリング デバイスの種類に大きく依存します。</span><span class="sxs-lookup"><span data-stu-id="1d3be-115">The performance of index processing operations depends heavily on where the index buffer exists in memory and what type of rendering device is being used.</span></span> <span data-ttu-id="1d3be-116">アプリケーションは、インデックス バッファーの作成時にそのメモリ割り当てを制御します。</span><span class="sxs-lookup"><span data-stu-id="1d3be-116">Applications control the memory allocation for index buffers when they are created.</span></span>

<span data-ttu-id="1d3be-117">アプリケーションは、ドライバー用に最適化されたメモリに割り当てられたインデックス バッファーにインデックスを直接書き込みます。</span><span class="sxs-lookup"><span data-stu-id="1d3be-117">The application can directly write indices to a index buffer allocated in driver-optimal memory.</span></span> <span data-ttu-id="1d3be-118">この手法を使うと、後で冗長コピー操作を実行できなくなります。</span><span class="sxs-lookup"><span data-stu-id="1d3be-118">This technique prevents a redundant copy operation later.</span></span> <span data-ttu-id="1d3be-119">アプリケーションがインデックス バッファーからデータを読み戻す場合、この手法は適切に機能しません。ドライバー用に最適化されたメモリからホストにより実行される読み取り操作は非常に遅いためです。</span><span class="sxs-lookup"><span data-stu-id="1d3be-119">This technique does not work well if your application reads data back from an index buffer, because read operations done by the host from driver-optimal memory can be very slow.</span></span> <span data-ttu-id="1d3be-120">したがって、アプリケーションがデータの処理時に読み取りを行う必要がある場合や、バッファーにデータを不規則に書き込む場合、システム メモリ インデックス バッファーの方が適しています。</span><span class="sxs-lookup"><span data-stu-id="1d3be-120">Therefore, if your application needs to read during processing or writes data to the buffer erratically, a system-memory index buffer is a better choice.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1d3be-121"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1d3be-121"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1d3be-122">頂点バッファーとインデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="1d3be-122">Vertex and index buffers</span></span>](vertex-and-index-buffers.md)

 

 




