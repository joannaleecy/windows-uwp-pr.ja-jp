---
xxxxx: Xxxx xx xxx xxxx xxxx xxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxx xxxxx xxx xx xxxx xx xxx xxxx xxxx xxxxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xx.xxxxxxx: XYYYXYYX-YXXY-YYXX-YXXY-YXXYXYYYXYXY
---

# Xxxx xx xxx xxxx xxxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxx xxxx xxxxx xxx xx xxxx xx xxx xxxx xxxx xxxxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

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

 

 




<!--HONumber=Mar16_HO1-->
