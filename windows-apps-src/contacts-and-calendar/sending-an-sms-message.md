---
description: このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: SMS メッセージの送信
ms.assetid: 4D7B509B-1CF0-4852-9691-E96D8352A4D6
keywords: 連絡先, SMS, 送信
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 427eb1b895269727d82e42d5abc3ae1f1da1a35d
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8791847"
---
# <a name="send-an-sms-message"></a>SMS メッセージの送信

このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。

このコードを呼び出すと、パッケージ マニフェスト内**チャット**、 **smsSend**、および**chatSystem**機能を宣言します。 これらは、[制限付き機能](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#special-and-restricted-capabilities)がアプリで使うことができます。 ストアにアプリを公開する場合は、承認を作成する必要があります。 [アカウントの種類、場所、および料金](https://docs.microsoft.com/windows/uwp/publish/account-types-locations-and-fees)を参照してください。

## <a name="launch-the-compose-sms-dialog"></a>SMS の作成ダイアログの起動

新しい [**ChatMessage**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessage) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。 ダイアログを表示するには、[**ShowComposeSmsMessageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.chatmessagemanager.showcomposesmsmessageasync) を呼び出します。

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

次のコードを使用して、アプリを実行しているデバイスが SMS メッセージを送信できるかどうかを判断することができます。

```csharp
if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.ApplicationModel.Chat"))
{
   // Call code here.
}
```

## <a name="summary-and-next-steps"></a>要約と次のステップ

このトピックでは、SMS の作成ダイアログの起動方法を示しました。 SMS メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。 バックグラウンド タスクを使用して SMS メッセージを送受信する方法の例については、GitHub から [ユニバーサル Windows アプリのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619979) をダウンロードしてください。

## <a name="related-topics"></a>関連トピック

* [連絡先の選択](selecting-contacts.md)
