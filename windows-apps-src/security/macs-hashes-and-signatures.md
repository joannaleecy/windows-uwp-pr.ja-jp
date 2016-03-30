---
xxxxx: XXXx, xxxxxx, xxx xxxxxxxxxx
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx), xxxxxx, xxx xxxxxxxxxx xxx xx xxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xx xxxxxx xxxxxxx xxxxxxxxx.
xx.xxxxxxx: XYYYYYYX-YYYY-YYXY-YYXY-XYYYXYYXYXYX
---

# XXXx, xxxxxx, xxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx), xxxxxx, xxx xxxxxxxxxx xxx xx xxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xx xxxxxx xxxxxxx xxxxxxxxx.

## Xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx)


Xxxxxxxxxx xxxxx xxxxxxx xx xxxxxxxxxxxx xxxxxxxxxx xxxx xxxxxxx x xxxxxxx, xxx xx xxxx xxx xxxxxxx xxxx xxxxxxxxxx xxxx xxxxxxxxx xxxx xxx xxxxxxx. Xx xxxxxxx xxxxxxx, xxxx xx xxx xxxxxxxxxx xxxxxxx xx xxxxxxx xxx xxxxxxxx, xxx xxxx xxxx xxxxx. X xxxxxxx xxxxxxxxxxxxxx xxxx (XXX) xxxxx xxxxxxx xxxxxxx xxxxxxxxx. Xxx xxxxxxx, xxxxxxxx xxx xxxxxxxxx xxxxxxxx:

-   Xxx xxx Xxxxx xxxxx x xxxxxx xxx xxx xxxxx xx x XXX xxxxxxxx xx xxx.
-   Xxx xxxxxxx x xxxxxxx xxx xxxxxx xxx xxxxxxx xxx xxx xxxxxx xxx xxxx x XXX xxxxxxxx xx xxxxxxxx x XXX xxxxx.
-   Xxx xxxxx xxx \[xxxxxxxxxxx\] xxxxxxx xxx xxx XXX xxxxx xx Xxxxx xxxx x xxxxxxx.
-   Xxxxx xxxx xxx xxxxxx xxx xxx xxx xxxxxxx xx xxxxx xx xxx XXX xxxxxxxx. Xxx xxxxxxxx xxx xxxxxxxxx XXX xxxxx xx xxx XXX xxxxx xxxx xx Xxx. Xx xxxx xxx xxx xxxx, xxx xxxxxxx xxx xxx xxxxxxx xx xxxxxxx.

Xxxx xxxx Xxx, x xxxxx xxxxx xxxxxxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxx Xxx xxx Xxxxx, xxxxxx xxxxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxx xxxx xxx xxxx xxxxxx xx xxx xxxxxxx xxx xxx xxxxxx, xxxxxxxxx, xxxxxx x XXX xxxxx xxxxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xxxxxx xxxxxxxxxx xx Xxxxx.

Xxxxxxxx x xxxxxxx xxxxxxxxxxxxxx xxxx xxxxxxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxx xxx xxxxxxx xxx, xx xxxxx x xxxxxx xxxxxx xxx, xxxx xxx xxxxxxx xxxx xxx xxxxxx xx xxxxxxx xxxx xxxxxx xx xxxx xxxxxxx xxx.

Xxx xxx xxx xxx [**XxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241530) xx xxxxxxxxx xxx xxxxxxxxx XXX xxxxxxxxxx xxx xxxxxxxx x xxxxxxxxx xxx. Xxx xxx xxx xxxxxx xxxxxxx xx xxx [**XxxxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241490) xxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxx xxx XXX xxxxx.

Xxxxxxx xxxxxxxxxx xxx xxx xxxxxx xxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx). Xxxxxxxx XXXx xxx xxxxxxx xxxx xx xxxxxx x xxxxxxx xxxxxxxxx xx xxxxxx xxxx x xxxxxxx xxx xxx xxxx xxxxxxx xxxxxx xxxxxxxxxxxx, xxxxxxxxxx xxx x xxxxxxx/xxxxxx xxx xxxx.

Xxxx xxxxxxx xxxx xxxxx xxx xx xxx xxx [**XxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241530) xxxxx xx xxxxxx x xxxxxx xxxxxxx xxxxxxxxxxxxxx xxxx (XXXX).

```cs
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace SampleMacAlgorithmProvider
{
    sealed partial class MacAlgProviderApp : Application
    {
        public MacAlgProviderApp()
        {
            // Initialize the application.
            this.InitializeComponent();

            // Initialize the hashing process.
            String strMsg = "This is a message to be authenticated";
            String strAlgName = MacAlgorithmNames.HmacSha384;
            IBuffer buffMsg;
            CryptographicKey hmacKey;
            IBuffer buffHMAC;

            // Create a hashed message authentication code (HMAC)
            this.CreateHMAC(
                strMsg,
                strAlgName,
                out buffMsg,
                out hmacKey,
                out buffHMAC);

            // Verify the HMAC.
            this.VerifyHMAC(
                buffMsg,
                hmacKey,
                buffHMAC);
        }

        void CreateHMAC(
            String strMsg,
            String strAlgName,
            out IBuffer buffMsg,
            out CryptographicKey hmacKey,
            out IBuffer buffHMAC)
        {
            // Create a MacAlgorithmProvider object for the specified algorithm.
            MacAlgorithmProvider objMacProv = MacAlgorithmProvider.OpenAlgorithm(strAlgName);

            // Demonstrate how to retrieve the name of the algorithm used.
            String strNameUsed = objMacProv.AlgorithmName;

            // Create a buffer that contains the message to be signed.
            BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
            buffMsg = CryptographicBuffer.ConvertStringToBinary(strMsg, encoding);

            // Create a key to be signed with the message.
            IBuffer buffKeyMaterial = CryptographicBuffer.GenerateRandom(objMacProv.MacLength);
            hmacKey = objMacProv.CreateKey(buffKeyMaterial);

            // Sign the key and message together.
            buffHMAC = CryptographicEngine.Sign(hmacKey, buffMsg);

            // Verify that the HMAC length is correct for the selected algorithm
            if (buffHMAC.Length != objMacProv.MacLength)
            {
                throw new Exception("Error computing digest");
            }
         }

        public void VerifyHMAC(
            IBuffer buffMsg,
            CryptographicKey hmacKey,
            IBuffer buffHMAC)
        {
            // The input key must be securely shared between the sender of the HMAC and 
            // the recipient. The recipient uses the CryptographicEngine.VerifySignature() 
            // method as follows to verify that the message has not been altered in transit.
            Boolean IsAuthenticated = CryptographicEngine.VerifySignature(hmacKey, buffMsg, buffHMAC);
            if (!IsAuthenticated)
            {
                throw new Exception("The message cannot be verified.");
            }
        }
    }
}
```

## Xxxxxx


X xxxxxxxxxxxxx xxxx xxxxxxxx xxxxx xx xxxxxxxxxxx xxxx xxxxx xx xxxx xxx xxxxxxx x xxxxx-xxxx xxx xxxxxx. Xxxx xxxxxxxxx xxx xxxxxxxxx xxxx xxxx xxxxxxx xxxx. Xxxxxxx xxxx xxxxxx xxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxxxxxxxxx xxxxxxxxx, xx xx xxxxxxxxx xxxx xxxxxxxxx xx xxxx (xxxxxxx) x xxxxxxx xxxx xxxx xx xx xx xxxx xxx xxxxxxxx xxxxxxx. Xxx xxxxxxxxx xxxxxxxxx xxxxxxxxxx x xxxxxx, xxxxxx xxxxxxxxxx, xxxxxxxx:

-   Xxx xxx Xxxxx xxxxx x xxxxxx xxx xxx xxxxx xx x XXX xxxxxxxx xx xxx.
-   Xxx xxxxxxx x xxxxxxx xxx xxxxxx xxx xxxxxxx xxx xxx xxxxxx xxx xxxx x XXX xxxxxxxx xx xxxxxxxx x XXX xxxxx.
-   Xxx xxxxx xxx \[xxxxxxxxxxx\] xxxxxxx xxx xxx XXX xxxxx xx Xxxxx xxxx x xxxxxxx.
-   Xxxxx xxxx xxx xxxxxx xxx xxx xxx xxxxxxx xx xxxxx xx xxx XXX xxxxxxxx. Xxx xxxxxxxx xxx xxxxxxxxx XXX xxxxx xx xxx XXX xxxxx xxxx xx Xxx. Xx xxxx xxx xxx xxxx, xxx xxxxxxx xxx xxx xxxxxxx xx xxxxxxx.

Xxxx xxxx Xxxxx xxxx xx xxxxxxxxxxx xxxxxxx. Xxxx xxx xxxx xxx xxxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxx xxx xxxxxxx xxx, xx xxxxx Xxxxx'x xxxxxx xxx, xxxx xxx xxxxxxx xxxx xxx xxxxxx xx xxxxxxx xxxx xxxxxx xx Xxxxx'x xxxxxxx xxx, xxxxxxxxxx Xxxxx.

Xxx xxx xxx xxx [**XxxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241511) xxxxx xx xxxxxxxxx xxx xxxxxxxxx xxxx xxxxxxxxxx xxx xxxxxx x [**XxxxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br241498) xxxxx.

Xxxxxxx xxxxxxxxxx xxx xxx xxxxxx xxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx). Xxxxxxx XXXx xxx xxxxxxx xxxx xx xxxxxx x xxxxxxx xxxxxxxxx xx xxxxxx xxxx x xxxxxxx xxx xxx xxxx xxxxxxx xxxxxx xxxxxxxxxxxx, xxxxxxxxxx xxx x xxxxxxx/xxxxxx xxx xxxx.

Xxx [**XxxxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br241498) xxxxxx xxx xx xxxx xx xxxxxxxxxx xxxx xxxxxxxxx xxxx xxxxxxx xxxxxx xx xx-xxxxxx xxx xxxxxx xxx xxxx xxx. Xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241499) xxxxxx xxxx xxx xxxx xx x xxxxxx xx xx xxxxxx. Xxx [**XxxXxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701376) xxxxxx xxxxxx xxx xxxx xxx xxxxxx xxx xxxxxx xxx xxxxxxx xxx. Xxxx xx xxxxx xx xxx xxxxxxxxx xxxxxxx.

```cs
public void SampleReusableHash()
{
    // Create a string that contains the name of the hashing algorithm to use.
    String strAlgName = HashAlgorithmNames.Sha512;

    // Create a HashAlgorithmProvider object.
    HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);

    // Create a CryptographicHash object. This object can be reused to continually
    // hash new messages.
    CryptographicHash objHash = objAlgProv.CreateHash();

    // Hash message 1.
    String strMsg1 = "This is message 1.";
    IBuffer buffMsg1 = CryptographicBuffer.ConvertStringToBinary(strMsg1, BinaryStringEncoding.Utf16BE);
    objHash.Append(buffMsg1);
    IBuffer buffHash1 = objHash.GetValueAndReset();

    // Hash message 2.
    String strMsg2 = "This is message 2.";
    IBuffer buffMsg2 = CryptographicBuffer.ConvertStringToBinary(strMsg2, BinaryStringEncoding.Utf16BE);
    objHash.Append(buffMsg2);
    IBuffer buffHash2 = objHash.GetValueAndReset();

    // Hash message 3.
    String strMsg3 = "This is message 3.";
    IBuffer buffMsg3 = CryptographicBuffer.ConvertStringToBinary(strMsg3, BinaryStringEncoding.Utf16BE);
    objHash.Append(buffMsg3);
    IBuffer buffHash3 = objHash.GetValueAndReset();

    // Convert the hashes to string values (for display);
    String strHash1 = CryptographicBuffer.EncodeToBase64String(buffHash1);
    String strHash2 = CryptographicBuffer.EncodeToBase64String(buffHash2);
    String strHash3 = CryptographicBuffer.EncodeToBase64String(buffHash3);
}

```

## Xxxxxxx xxxxxxxxxx


Xxxxxxx xxxxxxxxxx xxx xxx xxxxxx xxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxx xxxxxxxxxxxxxx xxxxx (XXXx). Xxxxxxx XXXx xxx xxxxxxx xxxx xx xxxxxx x xxxxxxx xxxxxxxxx xx xxxxxx xxxx x xxxxxxx xxx xxx xxxx xxxxxxx xxxxxx xxxxxxxxxxxx, xxxxxxxxxx xxx x xxxxxxx/xxxxxx xxx xxxx.

Xxxxxxx xxxx xxxxxx xxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxxxxxxxxx xxxxxxxxx, xxxxxxx, xx xx xxxxxxxxx xxxx xxxxxxxxx xx xxxx (xxxxxxx) x xxxxxxx xxxx xxxx xx xx xx xxxx xxx xxxxxxxx xxxxxxx. Xxx xxxxxx xxxxxxx x xxxxxxx xxxx, xxxxx xx, xxx xxxxx xxxx xxx xxxxxxxxx xxx xxx (xxxxxxxxxxx) xxxxxxx. Xxx xxxxxxxxx xxxxxxxxxx x xxxx xxxx xxx xxxxxxx, xxxxxxxx xxx xxxxxxxxx, xxx xxxxxxxx xxx xxxxxxxxx xxxxxxxxx xx xxx xxxx xxxxx. Xx xxxx xxxxx, xxx xxxxxxxxx xxx xx xxxxxx xxxxxxx xxxx xxx xxxxxxx xxx, xx xxxx, xxxx xxxx xxx xxxxxx xxx xxx xxx xxxxxxx xxxxxx xxxxxxxxxxxx.

Xxxxxxx xxxxxxx xxxx xxxx xxx xxxxxxxx xxxxxxx xxx xxx xxxxxxx xxx, xx xxxxx xxx xxxxxx'x xxxxxx xxx, xxxx xxx xxxxxxx xxxx xxx xxxxxx xx xxxxxxx xxxx xxxxxx xx xxx xxxxxxx xxx.

Xxx xxx xxx xx [**XxxxxxxxxxXxxXxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241478) xxxxxx xx xxxxxxxxx xxx xxxxxxxxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxx xx xxxxxx x xxx xxxx. Xxx xxx xxx xxxxxx xxxxxxx xx xxx [**XxxxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br241498) xxxxx xx xxxx x xxxxxxx xx xxxxxx x xxxxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
