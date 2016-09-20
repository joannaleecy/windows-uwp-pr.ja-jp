---
title: "バイト配列間のコピー"
description: "次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバイト配列をコピーする方法を示しています。"
ms.assetid: C343B08C-1FA1-40FD-8CA5-7FC9B707C5E3
author: awkoren
ms.sourcegitcommit: b41fc8994412490e37053d454929d2f7cc73b6ac
ms.openlocfilehash: db1691421cf4e540c9593efb4bbf2a608426c0ed

---

# バイト配列間のコピー


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]

次のコード例は、ユニバーサル Windows プラットフォーム (UWP) アプリでバイト配列をコピーする方法を示しています。

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


<!--HONumber=Jun16_HO4-->


