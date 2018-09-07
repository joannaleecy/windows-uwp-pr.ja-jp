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
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: cc7119ba2d97bfc6e1fb3f1a519b6d650027b1a3
ms.sourcegitcommit: 00d27738325d6db5b5e481911ae7fac0711b05eb
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/07/2018
ms.locfileid: "3659473"
---
# <a name="copy-to-and-from-byte-arrays"></a><span data-ttu-id="2ccf0-104">バイト配列間のコピー</span><span class="sxs-lookup"><span data-stu-id="2ccf0-104">Copy to and from byte arrays</span></span>



<span data-ttu-id="2ccf0-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバイト配列をコピーする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="2ccf0-105">This example code shows how to copy to and from byte arrays in an Universal Windows Platform (UWP) app.</span></span>

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