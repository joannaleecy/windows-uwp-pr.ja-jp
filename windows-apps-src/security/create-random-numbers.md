---
title: 乱数の生成
description: 次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでの暗号化に使用する乱数やバッファーを作成する方法を示しています。
ms.assetid: 15746824-F93A-4DC7-836E-EBA916D2CFD3
author: awkoren
---

# 乱数の生成


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

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

<!--HONumber=Mar16_HO5-->


