---
title: "バッファーの比較"
description: "次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバッファーを比較する方法を示しています。"
ms.assetid: CB086E51-544A-470D-B7C8-C055271CD615
author: awkoren
ms.author: alkoren
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: d5f84ce00026c9e2381e7b90213b3dcdd8aad9ff
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="compare-buffers"></a>バッファーの比較


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバッファーを比較する方法を示しています。

```cs
public void CompareBuffers()
{
    // Create a hexadecimal string.
    String strHex = "30310aff";

    // Create a Base64 string that is equivalent to strHex.
    String strBase64v1 = "MDEK/w==";

    // Create a Base64 string that is not equivalent to strHex.
    String strBase64v2 = "KEDM/w==";

    // Decode strHex to a buffer.
    IBuffer buff1 = CryptographicBuffer.DecodeFromHexString(strHex);

    // Decode strBase64v1 to a buffer.
    IBuffer buff2 = CryptographicBuffer.DecodeFromBase64String(strBase64v1);

    // Decode strBase64v2 to a buffer.
    IBuffer buff3 = CryptographicBuffer.DecodeFromBase64String(strBase64v2);

    // Compare the hexadecimal-decoded buff1 to the Base64-decoded buff2.
    // The code points in the two buffers are equal, and the Boolean value
    // is true.
    Boolean bVal_1 = CryptographicBuffer.Compare(buff1, buff2);

    // Compare the hexadecimal-decoded buff1 to the Base64-decoded buff3.
    // The code points in the two buffers are not equal, and the Boolean value
    // is false.
    Boolean bVal_2 = CryptographicBuffer.Compare(buff1, buff3);
}
```