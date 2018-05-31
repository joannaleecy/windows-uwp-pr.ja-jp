---
title: バイト配列間のコピー
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバイト配列をコピーする方法を示しています。
ms.assetid: C343B08C-1FA1-40FD-8CA5-7FC9B707C5E3
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 066ce6f058bae42144be0ba9523db72716544543
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
ms.locfileid: "1689008"
---
# <a name="copy-to-and-from-byte-arrays"></a><span data-ttu-id="b563f-104">バイト配列間のコピー</span><span class="sxs-lookup"><span data-stu-id="b563f-104">Copy to and from byte arrays</span></span>



<span data-ttu-id="b563f-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバイト配列をコピーする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b563f-105">This example code shows how to copy to and from byte arrays in an Universal Windows Platform (UWP) app.</span></span>

```cs
public void ByteArrayCopy()
{
    // Initialize a byte array.
    byte[] bytes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    // Create a buffer from the byte array.
    IBuffer buffer = CryptographicBuffer.CreateFromByteArray(bytes);

    // Encode the buffer into a hexadecimal string (for display);
    string hex = CryptographicBuffer.EncodeToHexString(buffer);

    // Copy the buffer back into a new byte array.
    byte[] newByteArray;
    CryptographicBuffer.CopyToByteArray(buffer, out newByteArray);
}
```