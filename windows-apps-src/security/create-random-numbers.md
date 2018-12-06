---
title: 乱数の生成
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。
ms.assetid: 15746824-F93A-4DC7-836E-EBA916D2CFD3
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: f36e50f2de36df39177370d688b9add5591403e1
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8751136"
---
# <a name="create-random-numbers"></a><span data-ttu-id="97627-104">乱数の生成</span><span class="sxs-lookup"><span data-stu-id="97627-104">Create random numbers</span></span>



<span data-ttu-id="97627-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="97627-105">This example code shows how to create a random number or buffer for use in cryptography in an Universal Windows Platform (UWP) app.</span></span>

```cs
public string GenerateRandomData()
{
    // Define the length, in bytes, of the buffer.
    uint length = 32;

    // Generate random data and copy it to a buffer.
    IBuffer buffer = CryptographicBuffer.GenerateRandom(length);

    // Encode the buffer to a hexadecimal string (for display).
    string randomHex = CryptographicBuffer.EncodeToHexString(buffer);

    return randomHex;
}

public uint GenerateRandomNumber()
{
    // Generate a random number.
    uint random = CryptographicBuffer.GenerateRandomNumber();
    return random;
}
```