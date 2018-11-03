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
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5981569"
---
# <a name="create-random-numbers"></a>乱数の生成



次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。

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