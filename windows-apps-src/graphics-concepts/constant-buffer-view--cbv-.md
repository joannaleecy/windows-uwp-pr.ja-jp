---
title: 定数バッファー ビュー (CBV)
description: 定数バッファーには、シェーダーの定数データが含まれます。 それらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることです。
ms.assetid: 99AEC6B0-A43B-4B61-8C3A-ECC8DE1B69A7
keywords:
- 定数バッファー ビュー (CBV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9e26a446bdd1e5a692e826d2c0ba303688bbd3d7
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044201"
---
# <a name="constant-buffer-view-cbv"></a><span data-ttu-id="6c514-105">定数バッファー ビュー (CBV)</span><span class="sxs-lookup"><span data-stu-id="6c514-105">Constant buffer view (CBV)</span></span>


<span data-ttu-id="6c514-106">定数バッファーには、シェーダーの定数データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6c514-106">Constant buffers contain shader constant data.</span></span> <span data-ttu-id="6c514-107">それらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることです。</span><span class="sxs-lookup"><span data-stu-id="6c514-107">The value of them is that the data persists, and can be accessed by any GPU shader, until it is necessary to change the data.</span></span>

<span data-ttu-id="6c514-108">定数バッファーの一般的なデータは、ワールド、プロジェクション、およびビュー マトリックスです。これらは、1 つのフレームの描画全体を通して一定のままです。</span><span class="sxs-lookup"><span data-stu-id="6c514-108">Typical data for a constant buffer would be world, projection and view matrices, which remain constant throughout the drawing of one frame.</span></span>

<span data-ttu-id="6c514-109">定数バッファーのレイアウトは、HLSL レイアウトと一致する必要があります ([定数変数のパッキング規則](https://msdn.microsoft.com/library/windows/desktop/bb509632.aspx)をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="6c514-109">Constant buffer layout should match the HLSL layout (refer to [Packing Rules for Constant Variables](https://msdn.microsoft.com/library/windows/desktop/bb509632.aspx)).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6c514-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6c514-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6c514-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="6c514-111">Views</span></span>](views.md)

 

 




