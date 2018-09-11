---
title: データ保護
description: この記事では、Windows.Security.Cryptography.DataProtection 名前空間の DataProtectionProvider クラスを使って、UWP アプリでデジタル データの暗号化と暗号化解除を行う方法について説明します。
ms.assetid: 9EE3CC45-5C44-4196-BD8B-1D64EFC5C509
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 6ef50675ec7741c067cbe5641321ae5711ff335b
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3845516"
---
# <a name="data-protection"></a><span data-ttu-id="09d57-104">データ保護</span><span class="sxs-lookup"><span data-stu-id="09d57-104">Data protection</span></span>



<span data-ttu-id="09d57-105">この記事では、[**Windows.Security.Cryptography.DataProtection**](https://msdn.microsoft.com/library/windows/apps/br241585) 名前空間の [**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) クラスを使って、UWP アプリでデジタル データの暗号化と暗号化解除を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="09d57-105">This article explains how to use the [**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) class in the [**Windows.Security.Cryptography.DataProtection**](https://msdn.microsoft.com/library/windows/apps/br241585) namespace to encrypt and decrypt digital data in a UWP app.</span></span>

<span data-ttu-id="09d57-106">データ保護 API はさまざまな方法で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="09d57-106">You can use the data protection APIs in multiple ways:</span></span>

-   <span data-ttu-id="09d57-107">Active Directory (AD) グループなどの AD セキュリティ プリンシパルに対するデータを保護します。</span><span class="sxs-lookup"><span data-stu-id="09d57-107">To protect data to an Active Directory (AD) security principal like an AD group.</span></span> <span data-ttu-id="09d57-108">このグループのすべてのメンバーがデータを暗号化解除できます。</span><span class="sxs-lookup"><span data-stu-id="09d57-108">Any member of the group can decrypt the data.</span></span>
-   <span data-ttu-id="09d57-109">X.509 証明書に含まれている公開キーでデータを保護します。</span><span class="sxs-lookup"><span data-stu-id="09d57-109">To protect data to the public key contained in an X.509 certificate.</span></span> <span data-ttu-id="09d57-110">秘密キーの所有者がデータを暗号化解除できます。</span><span class="sxs-lookup"><span data-stu-id="09d57-110">The owner of the private key can decrypt the data.</span></span>
-   <span data-ttu-id="09d57-111">対称キーを使ってデータを保護します。</span><span class="sxs-lookup"><span data-stu-id="09d57-111">To protect data by using a symmetric key.</span></span> <span data-ttu-id="09d57-112">この方法は、たとえば、Live ID のような非 AD プリンシパルに対するデータを保護する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="09d57-112">This works, for example, to protect data to a non-AD principal such as Live ID.</span></span>
-   <span data-ttu-id="09d57-113">Web サイトへのログオン時に使われる資格情報 (パスワード) でデータを保護できます。</span><span class="sxs-lookup"><span data-stu-id="09d57-113">To protect data to the credentials (password) used during logon to a website.</span></span>

<span data-ttu-id="09d57-114">データを保護するには、[**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) オブジェクトを作成するときに、保護記述子を指定してから [**ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/br241563) または [**ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241564) を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="09d57-114">To protect data, when you create a [**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) object you must specify a protection descriptor before calling [**ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/br241563) or [**ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241564).</span></span> <span data-ttu-id="09d57-115">保護記述子の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="09d57-115">The following example shows possible sample protection descriptors.</span></span>

## <a name="protecting-static-data"></a><span data-ttu-id="09d57-116">静的データの保護</span><span class="sxs-lookup"><span data-stu-id="09d57-116">Protecting static data</span></span>


<span data-ttu-id="09d57-117">次の例に、[**ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/br241563) メソッドと [**UnprotectAsync**](https://msdn.microsoft.com/library/windows/apps/br241565) メソッドを使って、現在のユーザーの SID に対する静的データを非同期に保護する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="09d57-117">The following example shows how to use the [**ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/br241563) and [**UnprotectAsync**](https://msdn.microsoft.com/library/windows/apps/br241565) methods to asynchronously protect static data to the current user's SID.</span></span>

```cs
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage.Streams;
using System.Threading.Tasks;

namespace SampleProtectAsync
{
    sealed partial class StaticDataProtectionApp : Application
    {
        public StaticDataProtectionApp()
        {
            // Initialize the application.
            this.InitializeComponent();

            // Protect data asynchronously.
            this.Protect();
        }

        public async void Protect()
        {
            // Initialize function arguments.
            String strMsg = "This is a message to be protected.";
            String strDescriptor = "LOCAL=user";
            BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;

            // Protect a message to the local user.
            IBuffer buffProtected = await this.SampleProtectAsync(
                strMsg,
                strDescriptor,
                encoding);

            // Decrypt the previously protected message.
            String strDecrypted = await this.SampleUnprotectData(
                buffProtected,
                encoding);
        }

        public async Task<IBuffer> SampleProtectAsync(
            String strMsg,
            String strDescriptor,
            BinaryStringEncoding encoding)
        {
            // Create a DataProtectionProvider object for the specified descriptor.
            DataProtectionProvider Provider = new DataProtectionProvider(strDescriptor);

            // Encode the plaintext input message to a buffer.
            encoding = BinaryStringEncoding.Utf8;
            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(strMsg, encoding);

            // Encrypt the message.
            IBuffer buffProtected = await Provider.ProtectAsync(buffMsg);

            // Execution of the SampleProtectAsync function resumes here
            // after the awaited task (Provider.ProtectAsync) completes.
            return buffProtected;
        }

        public async Task<String> SampleUnprotectData(
            IBuffer buffProtected,
            BinaryStringEncoding encoding)
        {
            // Create a DataProtectionProvider object.
            DataProtectionProvider Provider = new DataProtectionProvider();

            // Decrypt the protected message specified on input.
            IBuffer buffUnprotected = await Provider.UnprotectAsync(buffProtected);

            // Execution of the SampleUnprotectData method resumes here
            // after the awaited task (Provider.UnprotectAsync) completes
            // Convert the unprotected message from an IBuffer object to a string.
            String strClearText = CryptographicBuffer.ConvertBinaryToString(encoding, buffUnprotected);

            // Return the plaintext string.
            return strClearText;
        }
    }
}
```

## <a name="protecting-stream-data"></a><span data-ttu-id="09d57-118">ストリーム データの保護</span><span class="sxs-lookup"><span data-stu-id="09d57-118">Protecting stream data</span></span>


<span data-ttu-id="09d57-119">次の例に、[**ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241564) メソッドと [**UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241566) メソッドを使って、現在のユーザーの SID に対するストリーム データを非同期に保護する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="09d57-119">The following example shows how to use the [**ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241564) and [**UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/br241566) methods to asynchronously protect stream data to the current user's SID.</span></span>

```cs
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;
using Windows.Storage.Streams;
using System.Threading.Tasks;

namespace SampleProtectStreamAsync
{

    sealed partial class StreamDataProtectionApp : Application
    {
        public StreamDataProtectionApp()
        {
            // Initialize the application.
            this.InitializeComponent();

            // Protect a stream synchronously
            this.ProtectData();
         }

        public async void ProtectData()
        {
            // Initialize function arguments.
            String strDescriptor = "LOCAL=user";
            String strLoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse elementum "
                + "ullamcorper eros, vitae gravida nunc consequat sollicitudin. Vivamus lacinia, "
                + "diam a molestie porttitor, sapien neque volutpat est, non suscipit leo dolor "
                + "sit amet nisl. Praesent tincidunt tincidunt quam ut pharetra. Sed tincidunt "
                + "sit amet nisl. Praesent tincidunt tincidunt quam ut pharetra. Sed tincidunt "
                + "porttitor massa, at convallis dolor dictum suscipit. Nullam vitae lectus in "
                + "lorem scelerisque convallis sed scelerisque orci. Praesent sed ligula vel erat "
                + "eleifend tempus. Nullam dignissim aliquet mauris a aliquet. Nulla augue justo, "
                + "posuere a consectetur ut, suscipit et sem. Proin eu libero ut felis tincidunt "
                + "interdum. Curabitur vulputate eros nec sapien elementum ut dapibus eros "
                + "dapibus. Suspendisse quis dui dolor, non imperdiet leo. In consequat, odio nec "
                + "aliquam tincidunt, magna enim ultrices massa, ac pharetra est urna at arcu. "
                + "Nunc suscipit, velit non interdum suscipit, lectus lectus auctor tortor, quis "
                + "ultrices orci felis in dolor. Etiam congue pretium libero eu vestibulum. "
                + "Mauris bibendum erat eleifend nibh consequat eu pharetra metus convallis. "
                + "Morbi sem eros, venenatis vel vestibulum consequat, hendrerit rhoncus purus.";
            BinaryStringEncoding encoding = BinaryStringEncoding.Utf16BE;

            // Encrypt the data as a stream.
            IBuffer buffProtected = await this.SampleDataProtectionStream(
                strDescriptor,
                strLoremIpsum,
                encoding);

            // Decrypt a data stream.
            String strUnprotected = await this.SampleDataUnprotectStream(
                buffProtected,
                encoding);
        }

        public async Task<IBuffer> SampleDataProtectionStream(
            String descriptor,
            String strMsg,
            BinaryStringEncoding encoding)
        {
            // Create a DataProtectionProvider object for the specified descriptor.
            DataProtectionProvider Provider = new DataProtectionProvider(descriptor);

            // Convert the input string to a buffer.
            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(strMsg, encoding);

            // Create a random access stream to contain the plaintext message.
            InMemoryRandomAccessStream inputData = new InMemoryRandomAccessStream();

            // Create a random access stream to contain the encrypted message.
            InMemoryRandomAccessStream protectedData = new InMemoryRandomAccessStream();

            // Retrieve an IOutputStream object and fill it with the input (plaintext) data.
            IOutputStream outputStream = inputData.GetOutputStreamAt(0);
            DataWriter writer = new DataWriter(outputStream);
            writer.WriteBuffer(buffMsg);
            await writer.StoreAsync();
            await outputStream.FlushAsync();

            // Retrieve an IInputStream object from which you can read the input data.
            IInputStream source = inputData.GetInputStreamAt(0);

            // Retrieve an IOutputStream object and fill it with encrypted data.
            IOutputStream dest = protectedData.GetOutputStreamAt(0);
            await Provider.ProtectStreamAsync(source, dest);
            await dest.FlushAsync();

            //Verify that the protected data does not match the original
            DataReader reader1 = new DataReader(inputData.GetInputStreamAt(0));
            DataReader reader2 = new DataReader(protectedData.GetInputStreamAt(0));
            await reader1.LoadAsync((uint)inputData.Size);
            await reader2.LoadAsync((uint)protectedData.Size);
            IBuffer buffOriginalData = reader1.ReadBuffer((uint)inputData.Size);
            IBuffer buffProtectedData = reader2.ReadBuffer((uint)protectedData.Size);

            if (CryptographicBuffer.Compare(buffOriginalData, buffProtectedData))
            {
                throw new Exception("ProtectStreamAsync returned unprotected data");
            }

            // Return the encrypted data.
            return buffProtectedData;
        }

        public async Task<String> SampleDataUnprotectStream(
            IBuffer buffProtected,
            BinaryStringEncoding encoding)
        {
            // Create a DataProtectionProvider object.
            DataProtectionProvider Provider = new DataProtectionProvider();

            // Create a random access stream to contain the encrypted message.
            InMemoryRandomAccessStream inputData = new InMemoryRandomAccessStream();

            // Create a random access stream to contain the decrypted data.
            InMemoryRandomAccessStream unprotectedData = new InMemoryRandomAccessStream();

            // Retrieve an IOutputStream object and fill it with the input (encrypted) data.
            IOutputStream outputStream = inputData.GetOutputStreamAt(0);
            DataWriter writer = new DataWriter(outputStream);
            writer.WriteBuffer(buffProtected);
            await writer.StoreAsync();
            await outputStream.FlushAsync();

            // Retrieve an IInputStream object from which you can read the input (encrypted) data.
            IInputStream source = inputData.GetInputStreamAt(0);

            // Retrieve an IOutputStream object and fill it with decrypted data.
            IOutputStream dest = unprotectedData.GetOutputStreamAt(0);
            await Provider.UnprotectStreamAsync(source, dest);
            await dest.FlushAsync();

            // Write the decrypted data to an IBuffer object.
            DataReader reader2 = new DataReader(unprotectedData.GetInputStreamAt(0));
            await reader2.LoadAsync((uint)unprotectedData.Size);
            IBuffer buffUnprotectedData = reader2.ReadBuffer((uint)unprotectedData.Size);

            // Convert the IBuffer object to a string using the same encoding that was
            // used previously to conver the plaintext string (before encryption) to an
            // IBuffer object.
            String strUnprotected = CryptographicBuffer.ConvertBinaryToString(encoding, buffUnprotectedData);

            // Return the decrypted data.
            return strUnprotected;
        }
    }
}
```