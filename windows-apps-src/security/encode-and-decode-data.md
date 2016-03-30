---
xxxxx: Xxxxxx xxx xxxxxx xxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxx xxx xxxxxx xxxxYY xxx xxxxxxxxxxx xxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xx.xxxxxxx: YXXYYYYY-XYYY-YYXY-XYYY-YYYYYYYYYYXX
---

# Xxxxxx xxx xxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxx xxx xxxxxx xxxxYY xxx xxxxxxxxxxx xxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

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

 

 




<!--HONumber=Mar16_HO1-->
