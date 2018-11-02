---
title: MAC、ハッシュ、および署名
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリでメッセージ認証コード (MAC)、ハッシュ、署名を使ってメッセージの改ざんを検出する方法について説明します。
ms.assetid: E674312F-6678-44C5-91D9-B489F49C4D3C
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: b472a7209ddb9e67f7bb7c00e967295892568a29
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5997541"
---
# <a name="macs-hashes-and-signatures"></a><span data-ttu-id="fdc62-104">MAC、ハッシュ、および署名</span><span class="sxs-lookup"><span data-stu-id="fdc62-104">MACs, hashes, and signatures</span></span>




<span data-ttu-id="fdc62-105">この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリでメッセージ認証コード (MAC)、ハッシュ、署名を使ってメッセージの改ざんを検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-105">This article discusses how message authentication codes (MACs), hashes, and signatures can be used in Universal Windows Platform (UWP) apps to detect message tampering.</span></span>

## <a name="message-authentication-codes-macs"></a><span data-ttu-id="fdc62-106">メッセージ認証コード (MAC)</span><span class="sxs-lookup"><span data-stu-id="fdc62-106">Message authentication codes (MACs)</span></span>


<span data-ttu-id="fdc62-107">暗号化は、承認されていない個人によるメッセージの読み取りを防止できますが、その個人によるメッセージの改ざんを防止することはできません。</span><span class="sxs-lookup"><span data-stu-id="fdc62-107">Encryption helps prevent an unauthorized individual from reading a message, but it does not prevent that individual from tampering with the message.</span></span> <span data-ttu-id="fdc62-108">メッセージが改ざんされたことにより、そのメッセージが無意味な内容にすぎない場合であっても、実際にコストが発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="fdc62-108">An altered message, even if the alteration results in nothing but nonsense, can have real costs.</span></span> <span data-ttu-id="fdc62-109">メッセージ認証コード (MAC) は、メッセージの改ざんを防止します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-109">A message authentication code (MAC) helps prevent message tampering.</span></span> <span data-ttu-id="fdc62-110">たとえば、次のシナリオについて考えてみます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-110">For example, consider the following scenario:</span></span>

-   <span data-ttu-id="fdc62-111">ボブとアリスは秘密鍵を共有し、MAC 関数を使うことに同意しています。</span><span class="sxs-lookup"><span data-stu-id="fdc62-111">Bob and Alice share a secret key and agree on a MAC function to use.</span></span>
-   <span data-ttu-id="fdc62-112">ボブはメッセージを作成し、そのメッセージと秘密鍵を MAC 関数に入力して MAC 値を取得します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-112">Bob creates a message and inputs the message and the secret key into a MAC function to retrieve a MAC value.</span></span>
-   <span data-ttu-id="fdc62-113">ボブは \[暗号化されていない\] メッセージと MAC 値をネットワーク経由でアリスに送ります。</span><span class="sxs-lookup"><span data-stu-id="fdc62-113">Bob sends the \[unencrypted\] message and the MAC value to Alice over a network.</span></span>
-   <span data-ttu-id="fdc62-114">アリスは秘密鍵とメッセージを使って MAC 関数に入力します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-114">Alice uses the secret key and the message as input to the MAC function.</span></span> <span data-ttu-id="fdc62-115">アリスは、生成された MAC 値とボブから受け取った MAC 値を比較します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-115">She compares the generated MAC value to the MAC value sent by Bob.</span></span> <span data-ttu-id="fdc62-116">両者が同じものである場合、メッセージは転送中に変更されていません。</span><span class="sxs-lookup"><span data-stu-id="fdc62-116">If they are the same, the message was not changed in transit.</span></span>

<span data-ttu-id="fdc62-117">ボブとアリスの通信を傍受する第三者のイブは、メッセージを効果的に操作できません。</span><span class="sxs-lookup"><span data-stu-id="fdc62-117">Note that Eve, a third party eavesdropping on the conversation between Bob and Alice, cannot effectively manipulate the message.</span></span> <span data-ttu-id="fdc62-118">イブは秘密キーにアクセスできないため、アリスに対して改ざんされたメッセージが本物であるかのように見せる MAC 値を作成することができません。</span><span class="sxs-lookup"><span data-stu-id="fdc62-118">Eve does not have access to the private key and cannot, therefore, create a MAC value which would make the tampered message appear legitimate to Alice.</span></span>

<span data-ttu-id="fdc62-119">メッセージ認証コードの作成によって保証されるのは、元のメッセージが改ざんされていないことと、共有の秘密鍵を使ったことから、その秘密鍵にアクセスできる人物によってメッセージ ハッシュへの署名が行われたことのみです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-119">Creating a message authentication code ensures only that the original message was not altered and, by using a shared secret key, that the message hash was signed by someone with access to that private key.</span></span>

<span data-ttu-id="fdc62-120">[**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) を使って、利用可能な MAC アルゴリズムを列挙して対称キーを生成することができます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-120">You can use the [**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) to enumerate the available MAC algorithms and generate a symmetric key.</span></span> <span data-ttu-id="fdc62-121">[**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) クラスで静的メソッドを使って、MAC 値を作成する必要な暗号化を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-121">You can use static methods on the [**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) class to perform the necessary encryption that creates the MAC value.</span></span>

<span data-ttu-id="fdc62-122">デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-122">Digital signatures are the public key equivalent of private key message authentication codes (MACs).</span></span> <span data-ttu-id="fdc62-123">MAC ではメッセージが転送中に改ざんされなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。</span><span class="sxs-lookup"><span data-stu-id="fdc62-123">Although MACs use private keys to enable a message recipient to verify that a message has not been altered during transmission, signatures use a private/public key pair.</span></span>

<span data-ttu-id="fdc62-124">次のコード例は、[**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) クラスを使ってハッシュ メッセージ認証コード (HMAC) を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fdc62-124">This example code shows how to use the [**MacAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241530) class to create a hashed message authentication code (HMAC).</span></span>

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

## <a name="hashes"></a><span data-ttu-id="fdc62-125">ハッシュ</span><span class="sxs-lookup"><span data-stu-id="fdc62-125">Hashes</span></span>


<span data-ttu-id="fdc62-126">暗号化ハッシュ関数は任意の長さのデータ ブロックを受け取り、固定ビット サイズの文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-126">A cryptographic hash function takes an arbitrarily long block of data and returns a fixed-size bit string.</span></span> <span data-ttu-id="fdc62-127">通常、ハッシュ関数はデータへの署名時に使われます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-127">Hash functions are typically used when signing data.</span></span> <span data-ttu-id="fdc62-128">多くの公開キー署名操作は負荷が高いため、通常は元のメッセージに署名 (暗号化) するよりもメッセージのハッシュに署名する方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="fdc62-128">Because most public key signature operations are computationally intensive, it is typically more efficient to sign (encrypt) a message hash than it is to sign the original message.</span></span> <span data-ttu-id="fdc62-129">次の手順では、一般的なシナリオを簡略化して説明します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-129">The following procedure represents a common, albeit simplified, scenario:</span></span>

-   <span data-ttu-id="fdc62-130">ボブとアリスは秘密鍵を共有し、MAC 関数を使うことに同意しています。</span><span class="sxs-lookup"><span data-stu-id="fdc62-130">Bob and Alice share a secret key and agree on a MAC function to use.</span></span>
-   <span data-ttu-id="fdc62-131">ボブはメッセージを作成し、そのメッセージと秘密鍵を MAC 関数に入力して MAC 値を取得します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-131">Bob creates a message and inputs the message and the secret key into a MAC function to retrieve a MAC value.</span></span>
-   <span data-ttu-id="fdc62-132">ボブは \[暗号化されていない\] メッセージと MAC 値をネットワーク経由でアリスに送ります。</span><span class="sxs-lookup"><span data-stu-id="fdc62-132">Bob sends the \[unencrypted\] message and the MAC value to Alice over a network.</span></span>
-   <span data-ttu-id="fdc62-133">アリスは秘密鍵とメッセージを使って MAC 関数に入力します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-133">Alice uses the secret key and the message as input to the MAC function.</span></span> <span data-ttu-id="fdc62-134">アリスは、生成された MAC 値とボブから受け取った MAC 値を比較します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-134">She compares the generated MAC value to the MAC value sent by Bob.</span></span> <span data-ttu-id="fdc62-135">両者が同じものである場合、メッセージは転送中に変更されていません。</span><span class="sxs-lookup"><span data-stu-id="fdc62-135">If they are the same, the message was not changed in transit.</span></span>

<span data-ttu-id="fdc62-136">アリスは暗号化されていないメッセージを送信したことに注目してください。</span><span class="sxs-lookup"><span data-stu-id="fdc62-136">Note that Alice sent an unencrypted message.</span></span> <span data-ttu-id="fdc62-137">ハッシュが暗号化されただけです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-137">Only the hash was encrypted.</span></span> <span data-ttu-id="fdc62-138">この手順によって保証されるのは、元のメッセージが改変されていないことと、アリスの公開キーが使われていることから、アリスの秘密キーにアクセスできるだれか、おそらくアリス本人によってメッセージのハッシュが署名されたことだけです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-138">The procedure ensures only that the original message was not altered and, by using Alice's public key, that the message hash was signed by someone with access to Alice's private key, presumably Alice.</span></span>

<span data-ttu-id="fdc62-139">[**HashAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241511) クラスを使って利用できるハッシュ アルゴリズムを列挙し、[**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) 値を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-139">You can use the [**HashAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241511) class to enumerate the available hash algorithms and create a [**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) value.</span></span>

<span data-ttu-id="fdc62-140">デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-140">Digital signatures are the public key equivalent of private key message authentication codes (MACs).</span></span> <span data-ttu-id="fdc62-141">MAC ではメッセージが転送中に改変されなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。</span><span class="sxs-lookup"><span data-stu-id="fdc62-141">Whereas MACs use private keys to enable a message recipient to verify that a message has not been altered during transmission, signatures use a private/public key pair.</span></span>

<span data-ttu-id="fdc62-142">[**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) オブジェクトを使うと、その都度オブジェクトを作らなくても、異なるデータを繰り返しハッシュできます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-142">The [**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) object can be used to repeatedly hash different data without having to re-create the object for each use.</span></span> <span data-ttu-id="fdc62-143">[**Append**](https://msdn.microsoft.com/library/windows/apps/br241499) メソッドは、ハッシュ対象のバッファーに、新しいデータを追加します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-143">The [**Append**](https://msdn.microsoft.com/library/windows/apps/br241499) method adds new data to a buffer to be hashed.</span></span> <span data-ttu-id="fdc62-144">[**GetValueAndReset**](https://msdn.microsoft.com/library/windows/apps/hh701376) メソッドは、データをハッシュし、次の使用のためにオブジェクトをリセットします。</span><span class="sxs-lookup"><span data-stu-id="fdc62-144">The [**GetValueAndReset**](https://msdn.microsoft.com/library/windows/apps/hh701376) method hashes the data and resets the object for another use.</span></span> <span data-ttu-id="fdc62-145">この例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-145">This is shown by the following example.</span></span>

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

## <a name="digital-signatures"></a><span data-ttu-id="fdc62-146">デジタル署名</span><span class="sxs-lookup"><span data-stu-id="fdc62-146">Digital signatures</span></span>


<span data-ttu-id="fdc62-147">デジタル署名は、秘密キーによるメッセージ認証コード (MAC) と等価の公開キーのコードです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-147">Digital signatures are the public key equivalent of private key message authentication codes (MACs).</span></span> <span data-ttu-id="fdc62-148">MAC ではメッセージが転送中に改変されなかったことをメッセージの受信者が確認するのに秘密キーを使いますが、署名では秘密キーと公開キーのペアを使います。</span><span class="sxs-lookup"><span data-stu-id="fdc62-148">Whereas MACs use private keys to enable a message recipient to verify that a message has not been altered during transmission, signatures use a private/public key pair.</span></span>

<span data-ttu-id="fdc62-149">多くの公開キー署名操作は負荷が高いため、通常は元のメッセージに署名 (暗号化) するよりもメッセージのハッシュに署名する方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="fdc62-149">Because most public key signature operations are computationally intensive, however, it is typically more efficient to sign (encrypt) a message hash than it is to sign the original message.</span></span> <span data-ttu-id="fdc62-150">送信者はメッセージのハッシュを作成してそれに署名し、署名と (暗号化されていない) メッセージの両方を送ります。</span><span class="sxs-lookup"><span data-stu-id="fdc62-150">The sender creates a message hash, signs it, and sends both the signature and the (unencrypted) message.</span></span> <span data-ttu-id="fdc62-151">受信者はメッセージのハッシュを計算し、署名の暗号化を解除し、暗号化を解除した署名を計算したハッシュ値と比較します。</span><span class="sxs-lookup"><span data-stu-id="fdc62-151">The recipient calculates a hash over the message, decrypts the signature, and compares the decrypted signature to the hash value.</span></span> <span data-ttu-id="fdc62-152">これらが一致する場合、メッセージが本当に送信者からのものであり、転送中に改変されていないことを受信者は確信できます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-152">If they match, the recipient can be fairly certain that the message did, in fact, come from the sender and was not altered during transmission.</span></span>

<span data-ttu-id="fdc62-153">署名によって保証されるのは、元のメッセージが改変されていないことと、送信者の公開キーが使われていることから、秘密キーにアクセスできる人によってメッセージのハッシュが署名されたことだけです。</span><span class="sxs-lookup"><span data-stu-id="fdc62-153">Signing ensures only that the original message was not altered and, by using the sender's public key, that the message hash was signed by someone with access to the private key.</span></span>

<span data-ttu-id="fdc62-154">[**AsymmetricKeyAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241478) オブジェクトを使って、利用できる署名アルゴリズムを列挙したり、キー ペアを生成またはインポートしたりできます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-154">You can use an [**AsymmetricKeyAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241478) object to enumerate the available signature algorithms and generate or import a key pair.</span></span> <span data-ttu-id="fdc62-155">[**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) クラスの静的メソッドを使って、メッセージに署名したり、署名を検証したりできます。</span><span class="sxs-lookup"><span data-stu-id="fdc62-155">You can use static methods on the [**CryptographicHash**](https://msdn.microsoft.com/library/windows/apps/br241498) class to sign a message or verify a signature.</span></span>