---
title: 乱数の生成
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。
ms.assetid: 15746824-F93A-4DC7-836E-EBA916D2CFD3
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: a128535617c97e73b5a389db827fcf8c579b7f13
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6658354"
---
# <a name="create-random-numbers"></a><span data-ttu-id="6b1c6-104">乱数の生成</span><span class="sxs-lookup"><span data-stu-id="6b1c6-104">Create random numbers</span></span>



<span data-ttu-id="6b1c6-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6b1c6-105">This example code shows how to create a random number or buffer for use in cryptography in an Universal Windows Platform (UWP) app.</span></span>

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