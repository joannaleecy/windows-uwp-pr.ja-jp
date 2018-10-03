---
title: データのエンコードとデコード
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリで base64 データと 16 進データをエンコードおよびデコードする方法を示しています。
ms.assetid: 2CC23863-E840-48F4-B087-0479045743AC
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: a9177061f70419e2a3b0e3b47f933af75a11ad68
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/02/2018
ms.locfileid: "4263235"
---
# <a name="encode-and-decode-data"></a><span data-ttu-id="8a844-104">データのエンコードとデコード</span><span class="sxs-lookup"><span data-stu-id="8a844-104">Encode and decode data</span></span>



<span data-ttu-id="8a844-105">次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリで base64 データと 16 進データをエンコードおよびデコードする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="8a844-105">This example code shows how to encode and decode base64 and hexadecimal data in an Universal Windows Platform (UWP) app.</span></span>

```cs
public void EncodeDecodeBase64()
{
    // Define a Base64 encoded string.
    String strBase64 = "uiwyeroiugfyqcajkds897945234==";

    // Decoded the string from Base64 to binary.
    IBuffer buffer = CryptographicBuffer.DecodeFromBase64String(strBase64);

    // Encode the buffer back into a Base64 string.
    String strBase64New = CryptographicBuffer.EncodeToBase64String(buffer);
}

public void EncodeDecodeHex()
{
    // Define a hexadecimal string.
    String strHex = "30310AFF";

    // Decode a hexadecimal string to binary.
    IBuffer buffer = CryptographicBuffer.DecodeFromHexString(strHex);

    // Encode the buffer back into a hexadecimal string.
    String strHexNew = CryptographicBuffer.EncodeToHexString(buffer);
}
```
