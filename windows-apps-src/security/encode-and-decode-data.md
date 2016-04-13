---
title: データのエンコードとデコード
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリで base64 データと 16 進データをエンコードおよびデコードする方法を示しています。
ms.assetid: 2CC23863-E840-48F4-B087-0479045743AC
author: awkoren
---

# データのエンコードとデコード


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリで base64 データと 16 進データをエンコードおよびデコードする方法を示しています。

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


<!--HONumber=Mar16_HO5-->


