---
title: スマート カード
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでセキュリティで保護されたネットワーク サービスにスマート カードを使って、ユーザーを接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの PIN のリセット方法、スマート カードを削除または切断する方法などについて説明します。
ms.assetid: 86524267-50A0-4567-AE17-35C4B6D24745
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: dda2b580a82c72ad2e31c771a9c76f8d770049ec
ms.sourcegitcommit: 2c4daa36fb9fd3e8daa83c2bd0825f3989d24be8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5519913"
---
# <a name="smart-cards"></a>スマート カード




このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリでセキュリティで保護されたネットワーク サービスにスマート カードを使って、ユーザーを接続する方法のほか、物理スマート カード リーダーにアクセスする方法、仮想スマート カードの作成方法、スマート カードとの通信方法、ユーザーの認証方法、ユーザーの Pin のリセット方法、スマート カードを削除または切断する方法などについて説明します。 

## <a name="configure-the-app-manifest"></a>アプリ マニフェストの構成


アプリでスマート カードや仮想スマート カードを使ってユーザーを認証するには、あらかじめプロジェクトの Package.appxmanifest ファイルで、**共有ユーザー証明書**機能を設定しておく必要があります。

## <a name="access-connected-card-readers-and-smart-cards"></a>接続されているカード リーダーとスマート カードへのアクセス


[**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) に指定されているデバイス ID を [**SmartCardReader.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn263890) メソッドに渡すと、リーダーや装着されているスマート カードを照会することができます。 返されたリーダー デバイスに現在装着されているスマート カードにアクセスするには、[**SmartCardReader.FindAllCardsAsync**](https://msdn.microsoft.com/library/windows/apps/dn263887) を呼び出します。

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

また、カードが挿入されたときのアプリの動作を処理するメソッドを実装して、アプリによる [**CardAdded**](https://msdn.microsoft.com/library/windows/apps/dn263866) イベントの監視を有効にする必要もあります。

```cs
private void reader_CardAdded(SmartCardReader sender, CardAddedEventArgs args)
{
  // A card has been inserted into the sender SmartCardReader.
}
```

その後、返された各 [**SmartCard**](https://msdn.microsoft.com/library/windows/apps/dn297565) オブジェクトを [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) に渡すことで、その構成へのアクセスやカスタマイズを行うメソッドを使えるようになります。

## <a name="create-a-virtual-smart-card"></a>仮想スマート カードの作成


アプリで [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) を使って仮想スマート カードを作成するには、まずフレンドリ名、管理者キー、[**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642) を提供する必要があります。 通常、フレンドリ名は既にアプリに用意されている可能性がありますが、アプリではさらに、管理者キーを提供し、現在の **SmartCardPinPolicy** のインスタンスを生成する必要があります。その後、これらの 3 つの値をすべて [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) に渡します。

1.  [**SmartCardPinPolicy**](https://msdn.microsoft.com/library/windows/apps/dn297642) の新しいインスタンスを作成します。
2.  サービスまたは管理ツールから提供された管理者キーの値に対して [**CryptographicBuffer.GenerateRandom**](https://msdn.microsoft.com/library/windows/apps/br241392) を呼び出して、管理者キーの値を生成します。
3.  これらの値と *FriendlyNameText* 文字列を [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) に渡します。

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

関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトが [**RequestVirtualSmartCardCreationAsync**](https://msdn.microsoft.com/library/windows/apps/dn263830) から返されたら、仮想スマート カードのプロビジョニングが完了し、使う準備ができたことになります。

## <a name="handle-authentication-challenges"></a>認証チャレンジの処理


スマート カードや仮想スマート カードを使って認証するには、カードに格納されている管理者キーのデータと、認証サーバーまたは管理ツールによって管理されている管理者キーのデータとの間で、チャレンジを完了する動作をアプリに実装する必要があります。

次のコードは、サービスのスマート カード認証をサポートする方法、または物理カードや仮想カードの詳細を変更する方法の例を示します。 カードの管理者キーを使って生成されたデータ ("challenge") が、サーバーまたは管理者ツールから提供された管理者キーのデータ ("adminkey") と一致すれば、認証は成功します。

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

このコードは、このトピックの残りの部分で説明する、認証操作を完了する方法や、スマート カードまたは仮想スマート カードの情報に変更を適用する方法の中で使われます。

## <a name="verify-smart-card-or-virtual-smart-card-authentication-response"></a>スマート カードまたは仮想スマート カード認証の応答の確認


これで認証チャレンジのロジックが定義されたので、リーダーと通信してスマート カードにアクセスするか、その代わりに仮想スマート カードにアクセスして、認証を行うことができます。

1.  チャレンジを始めるには、スマート カードに関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトから [**GetChallengeContextAsync**](https://msdn.microsoft.com/library/windows/apps/dn263811) を呼び出します。 これにより、[**SmartCardChallengeContext**](https://msdn.microsoft.com/library/windows/apps/dn297570) のインスタンスが生成されます。このインスタンスには、カードの [**Challenge**](https://msdn.microsoft.com/library/windows/apps/dn297578) 値が含まれています。

2.  次に、カードのチャレンジ値とサービスまたは管理ツールから提供された管理者キーを、前の例で定義した **ChallengeResponseAlgorithm** に渡します。

3.  [**VerifyResponseAsync**](https://msdn.microsoft.com/library/windows/apps/dn297627) 認証に成功すると **true** を返します。

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

## <a name="change-or-reset-a-user-pin"></a>ユーザー PIN の変更またはリセット


スマート カードに関連付けられている PIN を変更するには、次の手順に従います。

1.  カードにアクセスし、関連付けられた [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) オブジェクトを生成します。
2.  [**RequestPinChangeAsync**](https://msdn.microsoft.com/library/windows/apps/dn263823) を呼び出して、この操作を完了するための UI をユーザーに表示します。
3.  PIN が正しく変更された場合は、呼び出しから **true** が返されます。

```cs
SmartCardProvisioning provisioning =
    await SmartCardProvisioning.FromSmartCardAsync(card);

bool result = await provisioning.RequestPinChangeAsync();
```

PIN のリセットを要求するには、次の手順に従います。

1.  [**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) を呼び出して操作を開始します。 この呼び出しには、スマート カードと PIN のリセット要求を表す [**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) メソッドが含まれます。
2.  [**SmartCardPinResetHandler**](https://msdn.microsoft.com/library/windows/apps/dn297701) [**SmartCardPinResetDeferra**](https://msdn.microsoft.com/library/windows/apps/dn297693) 呼び出しにラップされた **ChallengeResponseAlgorithm** で、カードのチャレンジ値と、サービスまたは管理ツールから提供された管理者キーを比較して要求を認証するための、情報を提供します。

3.  チャレンジが成功すると、[**RequestPinResetAsync**](https://msdn.microsoft.com/library/windows/apps/dn263825) の呼び出しが完了し、PIN が正しくリセットされた場合は **true** が返されます。

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

## <a name="remove-a-smart-card-or-virtual-smart-card"></a>スマート カードまたは仮想スマート カードの取り外し


物理スマート カードが取り外されると、カードの削除時に [**CardRemoved**](https://msdn.microsoft.com/library/windows/apps/dn263875) イベントが発生します。

カード リーダーでこのイベントが発生したときのイベント ハンドラーとして、カードまたはリーダーが取り外されたときのアプリの動作を定義するメソッドを関連付けます。 この動作は、カードが取り外されたことをユーザーに通知するといった単純なものでかまいません。

```cs
reader = card.Reader;
reader.CardRemoved += HandleCardRemoved;
```

仮想スマート カードの削除はプログラムによって行います。まずカードを取得し、次に [**SmartCardProvisioning**](https://msdn.microsoft.com/library/windows/apps/dn263801) によって返されたオブジェクトから [**RequestVirtualSmartCardDeletionAsync**](https://msdn.microsoft.com/library/windows/apps/dn263850) を呼び出します。

```cs
bool result = await SmartCardProvisioning
    .RequestVirtualSmartCardDeletionAsync(card);
```