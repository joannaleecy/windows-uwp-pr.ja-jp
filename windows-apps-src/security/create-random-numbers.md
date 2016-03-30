---
xxxxx: Xxxxxx xxxxxx xxxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxx x xxxxxx xxxxxx xx xxxxxx xxx xxx xx xxxxxxxxxxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xx.xxxxxxx: YYYYYYYY-XYYX-YXXY-YYYX-XXXYYYXYXXXY
---

# Xxxxxx xxxxxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxx x xxxxxx xxxxxx xx xxxxxx xxx xxx xx xxxxxxxxxxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

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

 

 




<!--HONumber=Mar16_HO1-->
