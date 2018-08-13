---
author: normesta
description: このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: SMS メッセージの送信
ms.assetid: 4D7B509B-1CF0-4852-9691-E96D8352A4D6
keywords: 連絡先, SMS, 送信
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: e5c3678e6c12a65b6821d2fc2a54e0710f7dcef3
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
ms.locfileid: "665356"
---
# <a name="send-an-sms-message"></a><span data-ttu-id="af001-106">SMS メッセージの送信</span><span class="sxs-lookup"><span data-stu-id="af001-106">Send an SMS message</span></span>

<span data-ttu-id="af001-107">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="af001-107">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="af001-108">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="af001-108">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="af001-109">このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="af001-109">This topic shows you how to launch the compose SMS dialog to allow the user to send an SMS message.</span></span> <span data-ttu-id="af001-110">ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="af001-110">You can pre-populate the fields of the SMS with data before showing the dialog.</span></span> <span data-ttu-id="af001-111">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="af001-111">The message will not be sent until the user taps the send button.</span></span>

## <a name="launch-the-compose-sms-dialog"></a><span data-ttu-id="af001-112">SMS の作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="af001-112">Launch the compose SMS dialog</span></span>

<span data-ttu-id="af001-113">新しい [**ChatMessage**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessage) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="af001-113">Create a new [**ChatMessage**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessage) object and set the data that you want to be pre-populated in the compose email dialog.</span></span> <span data-ttu-id="af001-114">ダイアログを表示するには、[**ShowComposeSmsMessageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessagemanager.showcomposesmsmessageasync) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="af001-114">Call [**ShowComposeSmsMessageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessagemanager.showcomposesmsmessageasync) to show the dialog.</span></span>

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

## <a name="summary-and-next-steps"></a><span data-ttu-id="af001-115">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="af001-115">Summary and next steps</span></span>

<span data-ttu-id="af001-116">このトピックでは、SMS の作成ダイアログの起動方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="af001-116">This topic has shown you how to launch the compose SMS dialog.</span></span> <span data-ttu-id="af001-117">SMS メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="af001-117">For information on selecting contacts to use as recipients for an SMS message, see [Select contacts](selecting-contacts.md).</span></span> <span data-ttu-id="af001-118">バックグラウンド タスクを使用して SMS メッセージを送受信する方法の例については、GitHub から [ユニバーサル Windows アプリのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619979) をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="af001-118">Download the [Universal Windows app samples](http://go.microsoft.com/fwlink/p/?linkid=619979) from GitHub to see more examples of how to send and receive SMS messages by using a background task.</span></span>

## <a name="related-topics"></a><span data-ttu-id="af001-119">関連トピック</span><span class="sxs-lookup"><span data-stu-id="af001-119">Related topics</span></span>

* [<span data-ttu-id="af001-120">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="af001-120">Select contacts</span></span>](selecting-contacts.md)
