---
title: MAC、ハッシュ、および署名
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリでメッセージ認証コード (MAC)、ハッシュ、署名を使ってメッセージの改ざんを検出する方法について説明します。
ms.assetid: E674312F-6678-44C5-91D9-B489F49C4D3C
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: e7b345e520b848a3637a44fa3c3b26172c7afef0
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5444439"
---
# <a name="macs-hashes-and-signatures"></a>MAC、ハッシュ、および署名




この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリでメッセージ認証コード (MAC)、ハッシュ、署名を使ってメッセージの改ざんを検出する方法について説明します。

## <a name="message-authentication-codes-macs"></a>メッセージ認証コード (MAC)


暗号化は、承認されていない個人によるメッセージの読み取りを防止できますが、その個人によるメッセージの改ざんを防止することはできません。 メッセージが改ざんされたことにより、そのメッセージが無意味な内容にすぎない場合であっても、実際にコストが発生する場合があります。 メッセージ認証コード (MAC) は、メッセージの改ざんを防止します。 たとえば、次のシナリオについて考えてみます。

-   ボブとアリスは秘密鍵を共有し、MAC 関数を使うことに同意しています。
-   ボブはメッセージを作成し、そのメッセージと秘密鍵を MAC 関数に入力して MAC 値を取得します。
-   ボブは \[暗号化されていない\] メッセージと MAC 値をネットワーク経由でアリスに送ります。
-   アリスは秘密鍵とメッセージを使って MAC 関数に入力します。 アリスは、生成された MAC 値とボブから受け取った MAC 値を比較します。 両者が同じものである場合、メッセージは転送中に変更されていません。

ボブとアリスの通信を傍受する第三者のイブは、メッセージを効果的に操作できません。 イブは秘密キーにアクセスできないため、アリスに対して改ざんされたメッセージが本物であるかのように見せる MAC 値を作成することができません。

メッセージ認証コードの作成によって保証されるのは、元のメッセージが改ざんされていないことと、共有の秘密鍵を使ったことから、その秘密鍵にアクセスできる人物によってメッセージ ハッシュへの署名が行われたことのみです。

[**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) を使って、利用可能な MAC アルゴリズムを列挙して対称キーを生成することができます。 [**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) クラスで静的メソッドを使って、MAC 値を作成する必要な暗号化を実行することができます。

デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。 MAC ではメッセージが転送中に改ざんされなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。

次のコード例は、[**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) クラスを使ってハッシュ メッセージ認証コード (HMAC) を作成する方法を示しています。

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

## <a name="hashes"></a>ハッシュ


暗号化ハッシュ関数は任意の長さのデータ ブロックを受け取り、固定ビット サイズの文字列を返します。 通常、ハッシュ関数はデータへの署名時に使われます。 多くの公開キー署名操作は負荷が高いため、通常は元のメッセージに署名 (暗号化) するよりもメッセージのハッシュに署名する方が効率的です。 次の手順では、一般的なシナリオを簡略化して説明します。

-   ボブとアリスは秘密鍵を共有し、MAC 関数を使うことに同意しています。
-   ボブはメッセージを作成し、そのメッセージと秘密鍵を MAC 関数に入力して MAC 値を取得します。
-   ボブは \[暗号化されていない\] メッセージと MAC 値をネットワーク経由でアリスに送ります。
-   アリスは秘密鍵とメッセージを使って MAC 関数に入力します。 アリスは、生成された MAC 値とボブから受け取った MAC 値を比較します。 両者が同じものである場合、メッセージは転送中に変更されていません。

アリスは暗号化されていないメッセージを送信したことに注目してください。 ハッシュが暗号化されただけです。 この手順によって保証されるのは、元のメッセージが改変されていないことと、アリスの公開キーが使われていることから、アリスの秘密キーにアクセスできるだれか、おそらくアリス本人によってメッセージのハッシュが署名されたことだけです。

[**HashAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241511) クラスを使って利用できるハッシュ アルゴリズムを列挙し、[**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) 値を作成することができます。

デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。 MAC ではメッセージが転送中に改変されなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。

[**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) オブジェクトを使うと、その都度オブジェクトを作らなくても、異なるデータを繰り返しハッシュできます。 [**Append**](https://msdn.microsoft.com/library/windows/apps/br241499) メソッドは、ハッシュ対象のバッファーに、新しいデータを追加します。 [**GetValueAndReset**](https://msdn.microsoft.com/library/windows/apps/hh701376) メソッドは、データをハッシュし、次の使用のためにオブジェクトをリセットします。 この例を次に示します。

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

## <a name="digital-signatures"></a>デジタル署名


デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。 MAC ではメッセージが転送中に改変されなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。

多くの公開キー署名操作は負荷が高いため、通常は元のメッセージに署名 (暗号化) するよりもメッセージのハッシュに署名する方が効率的です。 送信者はメッセージのハッシュを作成してそれに署名し、署名と (暗号化されていない) メッセージの両方を送ります。 受信者はメッセージのハッシュを計算し、署名の暗号化を解除し、暗号化を解除した署名を計算したハッシュ値と比較します。 これらが一致する場合、メッセージが本当に送信者からのものであり、転送中に改変されていないことを受信者は確信できます。

署名によって保証されるのは、元のメッセージが改変されていないことと、送信者の公開キーが使われていることから、秘密キーにアクセスできる人によってメッセージのハッシュが署名されたことだけです。

[**AsymmetricKeyAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241478) オブジェクトを使って、利用できる署名アルゴリズムを列挙したり、キー ペアを生成またはインポートしたりできます。 [**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) クラスの静的メソッドを使って、メッセージに署名したり、署名を検証したりできます。