---
author: normesta
description: メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: メールの送信
ms.assetid: 74511E90-9438-430E-B2DE-24E196A111E5
keywords: 連絡先, メール, 送信
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: bfeec341b0b4e63b4fe37118c1f7daac67929018
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
ms.locfileid: "665386"
---
# <a name="send-email"></a>メールの送信

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。

**この記事の内容**

-   [メールの作成ダイアログの起動](#launch-the-compose-email-dialog)
-   [要約と次のステップ](#summary-and-next-steps)
-   [関連トピック](#related-topics)

## <a name="launch-the-compose-email-dialog"></a>メールの作成ダイアログの起動

新しい [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。 ダイアログを表示するには、[**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) を呼び出します。

``` cs
private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
    string messageBody,
    StorageFile attachmentFile)
{
    var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
    emailMessage.Body = messageBody;

    if (attachmentFile != null)
    {
        var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

        var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
            attachmentFile.Name,
            stream);

        emailMessage.Attachments.Add(attachment);
    }

    var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
    if (email != null)
    {
        var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
        emailMessage.To.Add(emailRecipient);
    }

    await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);

}
```

## <a name="summary-and-next-steps"></a>要約と次のステップ

このトピックでは、メールの作成ダイアログの起動方法を示しました。 メール メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。 電子メールの添付ファイルとして使用するファイルの選択については、「[**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [連絡先の選択](selecting-contacts.md)
* [ファイル ピッカーの呼び出し後に Windows Phone アプリを続行する方法](https://msdn.microsoft.com/library/windows/apps/xaml/Dn614994)
 

 
