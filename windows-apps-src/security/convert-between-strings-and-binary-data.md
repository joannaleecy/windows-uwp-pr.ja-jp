---
xxxxx: Xxxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xx.xxxxxxx: XXXYXYYX-XYYX-YYYY-XXYX-YYXXXXYXXYYX
---

# Xxxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxx xxxx xxxxx xxx xx xxxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxx xx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

```cs
public void ConvertData()
{
    // Create a string to convert.
    String strIn = "Input String";

    // Convert the string to UTF16BE binary data.
    IBuffer buffUTF16BE = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf16BE);

    // Convert the string to UTF16LE binary data.
    IBuffer buffUTF16LE = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf16LE);

    // Convert the string to UTF8 binary data.
    IBuffer buffUTF8 = CryptographicBuffer.ConvertStringToBinary(strIn, BinaryStringEncoding.Utf8);
}
```

 

 




<!--HONumber=Mar16_HO1-->
