---
title: 乱数の生成
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。
ms.assetid: 15746824-F93A-4DC7-836E-EBA916D2CFD3
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: da60dd982ab378bc71ecbc1f485ca3127cefc9dd
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1689228"
---
# <a name="create-random-numbers"></a><span data-ttu-id="a1968-104">乱数の生成</span><span class="sxs-lookup"><span data-stu-id="a1968-104">Create random numbers</span></span>



<span data-ttu-id="a1968-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="a1968-105">This example code shows how to create a random number or buffer for use in cryptography in an Universal Windows Platform (UWP) app.</span></span>

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