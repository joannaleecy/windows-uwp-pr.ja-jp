---
title: スマート カード
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでセキュリティで保護されたネットワーク サービスにスマート カードを使って、ユーザーを接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの PIN のリセット方法、スマート カードを削除または切断する方法などについて説明します。
ms.assetid: 86524267-50A0-4567-AE17-35C4B6D24745
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 14f5c416fff63ba5a14480f804b9382c27f7e53a
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5840486"
---
# <a name="smart-cards"></a><span data-ttu-id="cd068-104">スマート カード</span><span class="sxs-lookup"><span data-stu-id="cd068-104">Smart cards</span></span>




<span data-ttu-id="cd068-105">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでセキュリティで保護されたネットワーク サービスにスマート カードを使って、ユーザーを接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの Pin のリセット方法、スマート カードを削除または切断する方法などについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cd068-105">This topic explains how Universal Windows Platform (UWP) apps can use smart cards to connect users to secure network services, including how to access physical smart card readers, create virtual smart cards, communicate with smart cards, authenticate users, reset user PINs, and remove or disconnect smart cards.</span></span> 

## <a name="configure-the-app-manifest"></a><span data-ttu-id="cd068-106">アプリ マニフェストの構成</span><span class="sxs-lookup"><span data-stu-id="cd068-106">Configure the app manifest</span></span>


<span data-ttu-id="cd068-107">アプリでスマート カードや仮想スマート カードを使ってユーザーを認証するには、あらかじめプロジェクトの Package.appxmanifest ファイルで、**共有ユーザー証明書**機能を設定しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd068-107">Before your app can authenticate users using smart cards or virtual smart cards, you must set the **Shared User Certificates** capability in the project Package.appxmanifest file.</span></span>

## <a name="access-connected-card-readers-and-smart-cards"></a><span data-ttu-id="cd068-108">接続されているカード リーダーとスマート カードへのアクセス</span><span class="sxs-lookup"><span data-stu-id="cd068-108">Access connected card readers and smart cards</span></span>


<span data-ttu-id="cd068-109">[**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) に指定されているデバイス ID を [**SmartCardReader.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn263890) メソッドに渡すと、リーダーや装着されているスマート カードを照会することができます。</span><span class="sxs-lookup"><span data-stu-id="cd068-109">You can query for readers and attached smart cards by passing the device ID (specified in [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393)) to the [**SmartCardReader.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn263890) method.</span></span> <span data-ttu-id="cd068-110">返されたリーダー デバイスに現在装着されているスマート カードにアクセスするには、[**SmartCardReader.FindAllCardsAsync**](https://msdn.microsoft.com/library/windows/apps/dn263887) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="cd068-110">To access the smart cards currently attached to the returned reader device, call [**SmartCardReader.FindAllCardsAsync**](https://msdn.microsoft.com/library/windows/apps/dn263887).</span></span>

```cs
string selector = SmartCardReader.GetDeviceSelector();
DeviceInformationCollection devices =
    await DeviceInformation.FindAllAsync(selector);

foreach (DeviceInformation device in devices)
{
    SmartCardReader reader =
        await SmartCardReader.FromIdAsync(device.Id);

    // For each reader, we want to find all the cards associated
    // with it.  Then we will create a SmartCardListItem for
    // each (reader, card) pair.
    IReadOnlyList<SmartCard> cards =
        await reader.FindAllCardsAsync();
}
```

<span data-ttu-id="cd068-111">また、カードが挿入されたときのアプリの動作を処理するメソッドを実装して、アプリによる [**CardAdded**](https://msdn.microsoft.com/library/windows/apps/dn263866) イベントの監視を有効にする必要もあります。</span><span class="sxs-lookup"><span data-stu-id="cd068-111">You should also enable your app to observe for [**CardAdded**](https://msdn.microsoft.com/library/windows/apps/dn263866) events by implementing a method to handle app behavior on card insertion.</span></span>

```cs
private void reader_CardAdded(SmartCardReader sender, CardAddedEventArgs args)
{
  // A card has been inserted into the sender SmartCardReader.
}
```

<span data-ttu-id="cd068-112">その後、返された各 [**SmartCard**](https://msdn.microsoft.com/library/windows/apps/dn297565) オブジェクトを [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) に渡すことで、その構成へのアクセスやカスタマイズを行うメソッドを使えるようになります。</span><span class="sxs-lookup"><span data-stu-id="cd068-112">You can then pass each returned [**SmartCard**](https://msdn.microsoft.com/library/windows/apps/dn297565) object to [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) to access the methods that allow your app to access and customize its configuration.</span></span>

## <a name="create-a-virtual-smart-card"></a><span data-ttu-id="cd068-113">仮想スマート カードの作成</span><span class="sxs-lookup"><span data-stu-id="cd068-113">Create a virtual smart card</span></span>


<span data-ttu-id="cd068-114">アプリで [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) を使って仮想スマート カードを作成するには、まずフレンドリ名、管理者キー、[**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642) を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd068-114">To create a virtual smart card using [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801), your app will first need to provide a friendly name, an admin key, and a [**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642).</span></span> <span data-ttu-id="cd068-115">通常、フレンドリ名は既にアプリに用意されている可能性がありますが、アプリではさらに、管理者キーを提供し、現在の **SmartCardPinPolicy** のインスタンスを生成する必要があります。その後、これらの 3 つの値をすべて [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) に渡します。</span><span class="sxs-lookup"><span data-stu-id="cd068-115">The friendly name is generally something provided to the app, but your app will still need to provide an admin key and generate an instance of the current **SmartCardPinPolicy** before passing all three values to [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830).</span></span>

1.  <span data-ttu-id="cd068-116">[**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642) の新しいインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="cd068-116">Create a new instance of a [**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642)</span></span>
2.  <span data-ttu-id="cd068-117">サービスまたは管理ツールから提供された管理者キーの値に対して [**CryptographicBuffer.GenerateRandom**](https://msdn.microsoft.com/library/windows/apps/br241392) を呼び出して、管理者キーの値を生成します。</span><span class="sxs-lookup"><span data-stu-id="cd068-117">Generate the admin key value by calling [**CryptographicBuffer.GenerateRandom**](https://msdn.microsoft.com/library/windows/apps/br241392) on the admin key value provided by the service or management tool.</span></span>
3.  <span data-ttu-id="cd068-118">これらの値と *FriendlyNameText* 文字列を [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) に渡します。</span><span class="sxs-lookup"><span data-stu-id="cd068-118">Pass these values along with the *FriendlyNameText* string to [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830).</span></span>

```cs
SmartCardPinPolicy pinPolicy = new SmartCardPinPolicy();
pinPolicy.MinLength = 6;

IBuffer adminkey = CryptographicBuffer.GenerateRandom(24);

SmartCardProvisioning provisioning = await
     SmartCardProvisioning.RequestVirtualSmartCardCreationAsync(
          "Card friendly name",
          adminkey,
          pinPolicy);
```

<span data-ttu-id="cd068-119">関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトが [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) から返されたら、仮想スマート カードのプロビジョニングが完了し、使う準備ができたことになります。</span><span class="sxs-lookup"><span data-stu-id="cd068-119">Once [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) has returned the associated [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) object, the virtual smart card is provisioned and ready for use.</span></span>

## <a name="handle-authentication-challenges"></a><span data-ttu-id="cd068-120">認証チャレンジの処理</span><span class="sxs-lookup"><span data-stu-id="cd068-120">Handle authentication challenges</span></span>


<span data-ttu-id="cd068-121">スマート カードや仮想スマート カードを使って認証するには、カードに格納されている管理者キーのデータと、認証サーバーまたは管理ツールによって管理されている管理者キーのデータとの間で、チャレンジを完了する動作をアプリに実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd068-121">To authenticate with smart cards or virtual smart cards, your app must provide the behavior to complete challenges between the admin key data stored on the card, and the admin key data maintained by the authentication server or management tool.</span></span>

<span data-ttu-id="cd068-122">次のコードは、サービスのスマート カード認証をサポートする方法、または物理カードや仮想カードの詳細を変更する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="cd068-122">The following code shows how to support smart card authentication for services or modification of physical or virtual card details.</span></span> <span data-ttu-id="cd068-123">カードの管理者キーを使って生成されたデータ ("challenge") が、サーバーまたは管理者ツールから提供された管理者キーのデータ ("adminkey") と一致すれば、認証は成功します。</span><span class="sxs-lookup"><span data-stu-id="cd068-123">If the data generated using the admin key on the card ("challenge") is the same as the admin key data provided by the server or management tool ("adminkey"), authentication is successful.</span></span>

```cs
static class ChallengeResponseAlgorithm
{
    public static IBuffer CalculateResponse(IBuffer challenge, IBuffer adminkey)
    {
        if (challenge == null)
            throw new ArgumentNullException("challenge");
        if (adminkey == null)
            throw new ArgumentNullException("adminkey");

        SymmetricKeyAlgorithmProvider objAlg = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.TripleDesCbc);
        var symmetricKey = objAlg.CreateSymmetricKey(adminkey);
        var buffEncrypted = CryptographicEngine.Encrypt(symmetricKey, challenge, null);
        return buffEncrypted;
    }
}
```

<span data-ttu-id="cd068-124">このコードは、このトピックの残りの部分で説明する、認証操作を完了する方法や、スマート カードまたは仮想スマート カードの情報に変更を適用する方法の中で使われます。</span><span class="sxs-lookup"><span data-stu-id="cd068-124">You will see this code referenced throughout the remainder of this topic was we review how to complete an authentication action, and how to apply changes to smart card and virtual smart card information.</span></span>

## <a name="verify-smart-card-or-virtual-smart-card-authentication-response"></a><span data-ttu-id="cd068-125">スマート カードまたは仮想スマート カード認証の応答の確認</span><span class="sxs-lookup"><span data-stu-id="cd068-125">Verify smart card or virtual smart card authentication response</span></span>


<span data-ttu-id="cd068-126">これで認証チャレンジのロジックが定義されたので、リーダーと通信してスマート カードにアクセスするか、その代わりに仮想スマート カードにアクセスして、認証を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="cd068-126">Now that we have the logic for authentication challenges defined, we can communicate with the reader to access the smart card, or alternatively, access a virtual smart card for authentication.</span></span>

1.  <span data-ttu-id="cd068-127">チャレンジを始めるには、スマート カードに関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトから [**GetChallengeContextAsync**](https://msdn.microsoft.com/library/windows/apps/dn263811) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="cd068-127">To begin the challenge, call [**GetChallengeContextAsync**](https://msdn.microsoft.com/library/windows/apps/dn263811) from the [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) object associated with the smart card.</span></span> <span data-ttu-id="cd068-128">これにより、[**SmartCardChallengeContext**](https://msdn.microsoft.com/library/windows/apps/dn297570) のインスタンスが生成されます。このインスタンスには、カードの [**Challenge**](https://msdn.microsoft.com/library/windows/apps/dn297578) 値が含まれています。</span><span class="sxs-lookup"><span data-stu-id="cd068-128">This will generate an instance of [**SmartCardChallengeContext**](https://msdn.microsoft.com/library/windows/apps/dn297570), which contains the card's [**Challenge**](https://msdn.microsoft.com/library/windows/apps/dn297578) value.</span></span>

2.  <span data-ttu-id="cd068-129">次に、カードのチャレンジ値とサービスまたは管理ツールから提供された管理者キーを、前の例で定義した **ChallengeResponseAlgorithm** に渡します。</span><span class="sxs-lookup"><span data-stu-id="cd068-129">Next, pass the card's challenge value and the admin key provided by the service or management tool to the **ChallengeResponseAlgorithm** that we defined in the previous example.</span></span>

3.  <span data-ttu-id="cd068-130">[**VerifyResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn297627) 認証に成功すると **true** を返します。</span><span class="sxs-lookup"><span data-stu-id="cd068-130">[**VerifyResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn297627) will return **true** if authentication is successful.</span></span>

```cs
bool verifyResult = false;
SmartCard card = await rootPage.GetSmartCard();
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

using (SmartCardChallengeContext context =
       await provisioning.GetChallengeContextAsync())
{
    IBuffer response = ChallengeResponseAlgorithm.CalculateResponse(
        context.Challenge,
        rootPage.AdminKey);

    verifyResult = await context.VerifyResponseAsync(response);
}
```

## <a name="change-or-reset-a-user-pin"></a><span data-ttu-id="cd068-131">ユーザー PIN の変更またはリセット</span><span class="sxs-lookup"><span data-stu-id="cd068-131">Change or reset a user PIN</span></span>


<span data-ttu-id="cd068-132">スマート カードに関連付けられている PIN を変更するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="cd068-132">To change the PIN associated with a smart card:</span></span>

1.  <span data-ttu-id="cd068-133">カードにアクセスし、関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="cd068-133">Access the card and generate the associated [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) object.</span></span>
2.  <span data-ttu-id="cd068-134">[**RequestPinChangeAsync**](https://msdn.microsoft.com/library/windows/apps/dn263823) を呼び出して、この操作を完了するための UI をユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="cd068-134">Call [**RequestPinChangeAsync**](https://msdn.microsoft.com/library/windows/apps/dn263823) to display a UI to the user to complete this operation.</span></span>
3.  <span data-ttu-id="cd068-135">PIN が正しく変更された場合は、呼び出しから **true** が返されます。</span><span class="sxs-lookup"><span data-stu-id="cd068-135">If the PIN was successfully changed the call will return **true**.</span></span>

```cs
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

bool result = await provisioning.RequestPinChangeAsync();
```

<span data-ttu-id="cd068-136">PIN のリセットを要求するには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="cd068-136">To request a PIN reset:</span></span>

1.  <span data-ttu-id="cd068-137">[**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) を呼び出して操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="cd068-137">Call [**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) to initiate the operation.</span></span> <span data-ttu-id="cd068-138">この呼び出しには、スマート カードと PIN のリセット要求を表す [**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) メソッドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="cd068-138">This call includes a [**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) method that represents the smart card and the pin reset request.</span></span>
2.  <span data-ttu-id="cd068-139">[**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) [**SmartCardPinResetDeferra**](https://msdn.microsoft.com/library/windows/apps/dn297693) 呼び出しにラップされた **ChallengeResponseAlgorithm** で、カードのチャレンジ値と、サービスまたは管理ツールから提供された管理者キーを比較して要求を認証するための、情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="cd068-139">[**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) provides information that our **ChallengeResponseAlgorithm**, wrapped in a [**SmartCardPinResetDeferral**](https://msdn.microsoft.com/library/windows/apps/dn297693) call, uses to compare the card's challenge value and the admin key provided by the service or management tool to authenticate the request.</span></span>

3.  <span data-ttu-id="cd068-140">チャレンジが成功すると、[**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) の呼び出しが完了し、PIN が正しくリセットされた場合は **true** が返されます。</span><span class="sxs-lookup"><span data-stu-id="cd068-140">If the challenge is successful, the [**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) call is completed; returning **true** if the PIN was successfully reset.</span></span>

```cs
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

bool result = await provisioning.RequestPinResetAsync(
    (pinResetSender, request) =>
    {
        SmartCardPinResetDeferral deferral =
            request.GetDeferral();

        try
        {
            IBuffer response =
                ChallengeResponseAlgorithm.CalculateResponse(
                    request.Challenge,
                    rootPage.AdminKey);
            request.SetResponse(response);
        }
        finally
        {
            deferral.Complete();
        }
    });
}
```

## <a name="remove-a-smart-card-or-virtual-smart-card"></a><span data-ttu-id="cd068-141">スマート カードまたは仮想スマート カードの取り外し</span><span class="sxs-lookup"><span data-stu-id="cd068-141">Remove a smart card or virtual smart card</span></span>


<span data-ttu-id="cd068-142">物理スマート カードが取り外されると、カードの削除時に [**CardRemoved**](https://msdn.microsoft.com/library/windows/apps/dn263875) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="cd068-142">When a physical smart card is removed a [**CardRemoved**](https://msdn.microsoft.com/library/windows/apps/dn263875) event will fire when the card is deleted.</span></span>

<span data-ttu-id="cd068-143">カード リーダーでこのイベントが発生したときのイベント ハンドラーとして、カードまたはリーダーが取り外されたときのアプリの動作を定義するメソッドを関連付けます。</span><span class="sxs-lookup"><span data-stu-id="cd068-143">Associate the firing of this event with the card reader with the method that defines your app's behavior on card or reader removal as an event handler.</span></span> <span data-ttu-id="cd068-144">この動作は、カードが取り外されたことをユーザーに通知するといった単純なものでかまいません。</span><span class="sxs-lookup"><span data-stu-id="cd068-144">This behavior can be something as simply as providing notification to the user that the card was removed.</span></span>

```cs
reader = card.Reader;
reader.CardRemoved += HandleCardRemoved;
```

<span data-ttu-id="cd068-145">仮想スマート カードの削除はプログラムによって行います。まずカードを取得し、次に [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) によって返されたオブジェクトから [**RequestVirtualSmartCardDeletionAsync**](https://msdn.microsoft.com/library/windows/apps/dn263850) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="cd068-145">The removal of a virtual smart card is handled programmatically by first retrieving the card and then calling [**RequestVirtualSmartCardDeletionAsync**](https://msdn.microsoft.com/library/windows/apps/dn263850) from the [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) returned object.</span></span>

```cs
bool result = await SmartCardProvisioning
    .RequestVirtualSmartCardDeletionAsync(card);
```