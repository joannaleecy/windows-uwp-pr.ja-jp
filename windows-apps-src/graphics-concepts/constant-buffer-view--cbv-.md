---
title: 定数バッファー ビュー (CBV)
description: 定数バッファーには、シェーダーの定数データが含まれます。 それらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることです。
ms.assetid: 99AEC6B0-A43B-4B61-8C3A-ECC8DE1B69A7
keywords:
- 定数バッファー ビュー (CBV)
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 33e850ba16be7a8d2621f061015d39c8b334cab2
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7976602"
---
# <a name="constant-buffer-view-cbv"></a>定数バッファー ビュー (CBV)


定数バッファーには、シェーダーの定数データが含まれます。 それらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることです。

定数バッファーの一般的なデータは、ワールド、プロジェクション、およびビュー マトリックスです。これらは、1 つのフレームの描画全体を通して一定のままです。

定数バッファーのレイアウトは、HLSL レイアウトと一致する必要があります ([定数変数のパッキング規則](https://msdn.microsoft.com/library/windows/desktop/bb509632.aspx)をご覧ください)。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ビュー](views.md)

 

 




