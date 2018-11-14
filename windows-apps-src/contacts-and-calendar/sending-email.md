---
author: normesta
description: メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。 ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。 メッセージは、ユーザーが送信ボタンをタップするまで送信されません。
title: メールの送信
ms.assetid: 74511E90-9438-430E-B2DE-24E196A111E5
keywords: 連絡先, メール, 送信
ms.author: normesta
ms.date: 10/11/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0a28809210f71bf523e3cc5f9c8da1db9fbcc90c
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6467111"
---
# <a name="send-email"></a><span data-ttu-id="612be-106">メールの送信</span><span class="sxs-lookup"><span data-stu-id="612be-106">Send email</span></span>

<span data-ttu-id="612be-107">メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="612be-107">Shows how to launch the compose email dialog to allow the user to send an email message.</span></span> <span data-ttu-id="612be-108">ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="612be-108">You can pre-populate the fields of the email with data before showing the dialog.</span></span> <span data-ttu-id="612be-109">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="612be-109">The message will not be sent until the user taps the send button.</span></span>

**<span data-ttu-id="612be-110">この記事の内容</span><span class="sxs-lookup"><span data-stu-id="612be-110">In this article</span></span>**

-   [<span data-ttu-id="612be-111">メールの作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="612be-111">Launch the compose email dialog</span></span>](#launch-the-compose-email-dialog)
-   [<span data-ttu-id="612be-112">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="612be-112">Summary and next steps</span></span>](#summary-and-next-steps)
-   [<span data-ttu-id="612be-113">関連トピック</span><span class="sxs-lookup"><span data-stu-id="612be-113">Related topics</span></span>](#related-topics)

## <a name="launch-the-compose-email-dialog"></a><span data-ttu-id="612be-114">メールの作成ダイアログの起動</span><span class="sxs-lookup"><span data-stu-id="612be-114">Launch the compose email dialog</span></span>

<span data-ttu-id="612be-115">新しい [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) オブジェクトを作成し、メールの作成ダイアログに事前に入力するデータを設定します。</span><span class="sxs-lookup"><span data-stu-id="612be-115">Create a new [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/Dn631270) object and set the data that you want to be pre-populated in the compose email dialog.</span></span> <span data-ttu-id="612be-116">ダイアログを表示するには、[**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="612be-116">Call [**ShowComposeNewEmailAsync**](https://msdn.microsoft.com/library/windows/apps/Dn631269) to show the dialog.</span></span>

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
> <span data-ttu-id="612be-117">[EmailAttachment](https://docs.microsoft.com/uwp/api/windows.applicationmodel.email.emailattachment)クラスを使用して、メールに追加するための添付ファイルは、メール アプリでのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="612be-117">Attachments that you add to an email by using the [EmailAttachment](https://docs.microsoft.com/uwp/api/windows.applicationmodel.email.emailattachment) class will appear only in the Mail app.</span></span> <span data-ttu-id="612be-118">ユーザーがその既定のプログラムとして構成されているその他のメール プログラムを使用している場合、添付することがなく作成ウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="612be-118">If users have any other mail program configured as their default mail program, the compose window will appear without the attachment.</span></span> <span data-ttu-id="612be-119">これは、既知の問題です。</span><span class="sxs-lookup"><span data-stu-id="612be-119">This is a known issue.</span></span>

## <a name="summary-and-next-steps"></a><span data-ttu-id="612be-120">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="612be-120">Summary and next steps</span></span>

<span data-ttu-id="612be-121">このトピックでは、メールの作成ダイアログの起動方法を示しました。</span><span class="sxs-lookup"><span data-stu-id="612be-121">This topic has shown you how to launch the compose email dialog.</span></span> <span data-ttu-id="612be-122">メール メッセージの受信者として使う連絡先を選ぶ方法については、「[連絡先の選択](selecting-contacts.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="612be-122">For information on selecting contacts to use as recipients for an email message, see [Select contacts](selecting-contacts.md).</span></span> <span data-ttu-id="612be-123">電子メールの添付ファイルとして使用するファイルの選択については、「[**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="612be-123">See [**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/JJ635275) to select a file to use as an email attachment.</span></span>

## <a name="related-topics"></a><span data-ttu-id="612be-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="612be-124">Related topics</span></span>

* [<span data-ttu-id="612be-125">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="612be-125">Selecting contacts</span></span>](selecting-contacts.md)
* [<span data-ttu-id="612be-126">ファイル ピッカーの呼び出し後に Windows Phone アプリを続行する方法</span><span class="sxs-lookup"><span data-stu-id="612be-126">How to continue your Windows Phone app after calling a file picker</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/Dn614994)
 

 
