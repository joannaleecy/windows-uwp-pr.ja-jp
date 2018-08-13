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
# <a name="constant-buffer-view-cbv"></a>定数バッファー ビュー (CBV)


定数バッファーには、シェーダーの定数データが含まれます。 それらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることです。

定数バッファーの一般的なデータは、ワールド、プロジェクション、およびビュー マトリックスです。これらは、1 つのフレームの描画全体を通して一定のままです。

定数バッファーのレイアウトは、HLSL レイアウトと一致する必要があります ([定数変数のパッキング規則](https://msdn.microsoft.com/library/windows/desktop/bb509632.aspx)をご覧ください)。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ビュー](views.md)

 

 




