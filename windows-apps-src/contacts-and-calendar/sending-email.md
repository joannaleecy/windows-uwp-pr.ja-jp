---
description: メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: メールの送信
ms.assetid: 74511E90-9438-430E-B2DE-24E196A111E5
keywords: 連絡先, メール, 送信
ms.date: 10/11/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1593ab8b547a464492a35aa7d49d38f667a8210b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57626487"
---
# <a name="send-email"></a>メールの送信

メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。

**この記事では**

-   [電子メールの作成 ダイアログを起動します。](#launch-the-compose-email-dialog)
-   [概要と次の手順](#summary-and-next-steps)
-   [関連トピック](#related-topics)

## <a name="launch-the-compose-email-dialog"></a>メールの作成ダイアログの起動

新しい [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。 ダイアログを表示するには、[**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) を呼び出します。

``` cs
private async Task ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient,
    string subject, string messageBody)
{
    var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
    emailMessage.Body = messageBody;

    var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
    if (email != null)
    {
        var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
        emailMessage.To.Add(emailRecipient);
        emailMessage.Subject = subject;
    }

    await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
}
```

>[!NOTE]
> 添付ファイルを使用して電子メールに追加する、 [EmailAttachment](https://docs.microsoft.com/uwp/api/windows.applicationmodel.email.emailattachment)クラスは、メール アプリでのみ表示されます。 ユーザーがその既定のプログラムとして構成されているその他のメール プログラムを使用している場合、添付ファイルなし、compose ウィンドウが表示されます。 これは既知の問題です。

## <a name="summary-and-next-steps"></a>要約と次のステップ

このトピックでは、メールの作成ダイアログの起動方法を示しました。 メール メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。 電子メールの添付ファイルとして使用するファイルの選択については、「[**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [連絡先を選択](selecting-contacts.md)
* [ファイル ピッカーを呼び出した後、Windows Phone アプリを継続する方法](https://msdn.microsoft.com/library/windows/apps/xaml/Dn614994)
 

 
