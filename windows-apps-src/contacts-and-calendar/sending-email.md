---
author: normesta
description: "メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。"
title: "メールの送信"
ms.assetid: 74511E90-9438-430E-B2DE-24E196A111E5
keywords: "連絡先, メール, 送信"
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: bfeec341b0b4e63b4fe37118c1f7daac67929018
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="send-email"></a><span data-ttu-id="b9ee5-106">メールの送信</span><span class="sxs-lookup"><span data-stu-id="b9ee5-106">Send email</span></span>

<span data-ttu-id="b9ee5-107">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-107">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="b9ee5-108">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="b9ee5-108">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="b9ee5-109">メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-109">Shows how to launch the compose email dialog to allow the user to send an email message.</span></span> <span data-ttu-id="b9ee5-110">ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-110">You can pre-populate the fields of the email with data before showing the dialog.</span></span> <span data-ttu-id="b9ee5-111">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-111">The message will not be sent until the user taps the send button.</span></span>

**<span data-ttu-id="b9ee5-112">この記事の内容</span><span class="sxs-lookup"><span data-stu-id="b9ee5-112">In this article</span></span>**

-   [<span data-ttu-id="b9ee5-113">メールの作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="b9ee5-113">Launch the compose email dialog</span></span>](#launch-the-compose-email-dialog)
-   [<span data-ttu-id="b9ee5-114">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="b9ee5-114">Summary and next steps</span></span>](#summary-and-next-steps)
-   [<span data-ttu-id="b9ee5-115">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b9ee5-115">Related topics</span></span>](#related-topics)

## <a name="launch-the-compose-email-dialog"></a><span data-ttu-id="b9ee5-116">メールの作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="b9ee5-116">Launch the compose email dialog</span></span>

<span data-ttu-id="b9ee5-117">新しい [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-117">Create a new [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) object and set the data that you want to be pre-populated in the compose email dialog.</span></span> <span data-ttu-id="b9ee5-118">ダイアログを表示するには、[**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-118">Call [**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) to show the dialog.</span></span>

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

## <a name="summary-and-next-steps"></a><span data-ttu-id="b9ee5-119">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="b9ee5-119">Summary and next steps</span></span>

<span data-ttu-id="b9ee5-120">このトピックでは、メールの作成ダイアログの起動方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-120">This topic has shown you how to launch the compose email dialog.</span></span> <span data-ttu-id="b9ee5-121">メール メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-121">For information on selecting contacts to use as recipients for an email message, see [Select contacts](selecting-contacts.md).</span></span> <span data-ttu-id="b9ee5-122">電子メールの添付ファイルとして使用するファイルの選択については、「[**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b9ee5-122">See [**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275) to select a file to use as an email attachment.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b9ee5-123">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b9ee5-123">Related topics</span></span>

* [<span data-ttu-id="b9ee5-124">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="b9ee5-124">Selecting contacts</span></span>](selecting-contacts.md)
* [<span data-ttu-id="b9ee5-125">ファイル ピッカーの呼び出し後に Windows Phone アプリを続行する方法</span><span class="sxs-lookup"><span data-stu-id="b9ee5-125">How to continue your Windows Phone app after calling a file picker</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/Dn614994)
 

 
