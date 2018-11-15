---
author: normesta
description: このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: SMS メッセージの送信
ms.assetid: 4D7B509B-1CF0-4852-9691-E96D8352A4D6
keywords: 連絡先, SMS, 送信
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 06d84646685c6944ab0e816b42cf6fb2125f8a57
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6674503"
---
# <a name="send-an-sms-message"></a><span data-ttu-id="3d42e-106">SMS メッセージの送信</span><span class="sxs-lookup"><span data-stu-id="3d42e-106">Send an SMS message</span></span>

<span data-ttu-id="3d42e-107">このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3d42e-107">This topic shows you how to launch the compose SMS dialog to allow the user to send an SMS message.</span></span> <span data-ttu-id="3d42e-108">ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="3d42e-108">You can pre-populate the fields of the SMS with data before showing the dialog.</span></span> <span data-ttu-id="3d42e-109">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="3d42e-109">The message will not be sent until the user taps the send button.</span></span>

<span data-ttu-id="3d42e-110">このコードを呼び出すと、パッケージ マニフェスト内**チャット**、 **smsSend**、 **chatSystem**機能を宣言します。</span><span class="sxs-lookup"><span data-stu-id="3d42e-110">To call this code, declare the **chat**, **smsSend**, and **chatSystem** capabilities in your package manifest.</span></span> <span data-ttu-id="3d42e-111">これらは、[制限付き機能](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities)がアプリで使うことができます。</span><span class="sxs-lookup"><span data-stu-id="3d42e-111">These are [restricted capabilities](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities) but you can use them in your app.</span></span> <span data-ttu-id="3d42e-112">ストアにアプリを公開する場合は、承認を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3d42e-112">You need approval only if you intend to publish your app to the Store.</span></span> <span data-ttu-id="3d42e-113">[アカウントの種類、場所、および料金](https://docs.microsoft.com/windows/uwp/publish/account-types-locations-and-fees)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3d42e-113">See [Account types, locations, and fees](https://docs.microsoft.com/windows/uwp/publish/account-types-locations-and-fees).</span></span>

## <a name="launch-the-compose-sms-dialog"></a><span data-ttu-id="3d42e-114">SMS の作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="3d42e-114">Launch the compose SMS dialog</span></span>

<span data-ttu-id="3d42e-115">新しい [**ChatMessage**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessage) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="3d42e-115">Create a new [**ChatMessage**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessage) object and set the data that you want to be pre-populated in the compose email dialog.</span></span> <span data-ttu-id="3d42e-116">ダイアログを表示するには、[**ShowComposeSmsMessageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessagemanager.showcomposesmsmessageasync) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="3d42e-116">Call [**ShowComposeSmsMessageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessagemanager.showcomposesmsmessageasync) to show the dialog.</span></span>

```cs
private async void ComposeSms(Windows.ApplicationModel.Contacts.Contact recipient,
    string messageBody,
    StorageFile attachmentFile,
    string mimeType)
{
    var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
    chatMessage.Body = messageBody;

    if (attachmentFile != null)
    {
        var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

        var attachment = new Windows.ApplicationModel.Chat.ChatMessageAttachment(
            mimeType,
            stream);

        chatMessage.Attachments.Add(attachment);
    }

    var phone = recipient.Phones.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactPhone>();
    if (phone != null)
    {
        chatMessage.Recipients.Add(phone.Number);
    }
    await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
}
```

<span data-ttu-id="3d42e-117">次のコードを使用して、アプリを実行しているデバイスが SMS メッセージを送信できるかどうかを判断することができます。</span><span class="sxs-lookup"><span data-stu-id="3d42e-117">You can use the following code to determine whether the device that is running your app is able to send SMS messages.</span></span>

```csharp
if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Chat"))
{
   // Call code here.
}
```

## <a name="summary-and-next-steps"></a><span data-ttu-id="3d42e-118">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="3d42e-118">Summary and next steps</span></span>

<span data-ttu-id="3d42e-119">このトピックでは、SMS の作成ダイアログの起動方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="3d42e-119">This topic has shown you how to launch the compose SMS dialog.</span></span> <span data-ttu-id="3d42e-120">SMS メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3d42e-120">For information on selecting contacts to use as recipients for an SMS message, see [Select contacts](selecting-contacts.md).</span></span> <span data-ttu-id="3d42e-121">バックグラウンド タスクを使用して SMS メッセージを送受信する方法の例については、GitHub から [ユニバーサル Windows アプリのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619979) をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="3d42e-121">Download the [Universal Windows app samples](http://go.microsoft.com/fwlink/p/?linkid=619979) from GitHub to see more examples of how to send and receive SMS messages by using a background task.</span></span>

## <a name="related-topics"></a><span data-ttu-id="3d42e-122">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3d42e-122">Related topics</span></span>

* [<span data-ttu-id="3d42e-123">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="3d42e-123">Select contacts</span></span>](selecting-contacts.md)
