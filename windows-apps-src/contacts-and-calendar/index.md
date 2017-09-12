---
author: normesta
description: "UWP アプリで連絡先とカレンダーの情報を使う方法。"
title: "連絡先とカレンダー"
ms.assetid: b7e53ab5-2828-4fb7-8656-2bec70b3467f
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 連絡先, カレンダー, 予定, メール メッセージ"
ms.openlocfilehash: 2d90823c60f9a86bcff2228763911aaf7f5049a1
ms.sourcegitcommit: 378382419f1fda4e4df76ffa9c8cea753d271e6a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2017
---
# <a name="contacts-and-calendar"></a><span data-ttu-id="de25d-104">連絡先とカレンダー</span><span class="sxs-lookup"><span data-stu-id="de25d-104">Contacts and calendar</span></span>

<span data-ttu-id="de25d-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="de25d-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="de25d-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="de25d-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="de25d-107">ユーザーどうしがコンテンツ、メール、カレンダー情報、メッセージを共有したり、提供された機能を活用したりできるように、連絡先と予定へのアクセスを有効にします。</span><span class="sxs-lookup"><span data-stu-id="de25d-107">You can let your users access their contacts and appointments so they can share content, email, calendar info, or messages with each other, or whatever functionality you design.</span></span>

<span data-ttu-id="de25d-108">アプリで連絡先と予定にアクセスする方法については、次のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="de25d-108">To see a few different ways in which your app can access contacts and appointments, see these topics:</span></span>

| <span data-ttu-id="de25d-109">トピック</span><span class="sxs-lookup"><span data-stu-id="de25d-109">Topic</span></span> | <span data-ttu-id="de25d-110">説明</span><span class="sxs-lookup"><span data-stu-id="de25d-110">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="de25d-111">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="de25d-111">Select contacts</span></span>](selecting-contacts.md) | <span data-ttu-id="de25d-112">[<strong>Windows.ApplicationModel.Contacts</strong>](https://msdn.microsoft.com/library/windows/apps/BR225002) 名前空間では、複数の方法で連絡先を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="de25d-112">Through the [<strong>Windows.ApplicationModel.Contacts</strong>](https://msdn.microsoft.com/library/windows/apps/BR225002) namespace, you have several options for selecting contacts.</span></span> <span data-ttu-id="de25d-113">ここでは、1 つまたは複数の連絡先を選ぶ方法について説明します。また、アプリで必要な連絡先情報だけを取得するように連絡先ピッカーを構成する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="de25d-113">Here, we'll show you how to select a single contact or multiple contacts, and we'll show you how to configure the contact picker to retrieve only the contact information that your app needs.</span></span> |
| [<span data-ttu-id="de25d-114">メールの送信</span><span class="sxs-lookup"><span data-stu-id="de25d-114">Send email</span></span>](sending-email.md) | <span data-ttu-id="de25d-115">メールの作成ダイアログを起動して、ユーザーがメール メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="de25d-115">Shows how to launch the compose email dialog to allow the user to send an email message.</span></span> <span data-ttu-id="de25d-116">ダイアログを表示する前に、メールの各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="de25d-116">You can pre-populate the fields of the email with data before showing the dialog.</span></span> <span data-ttu-id="de25d-117">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="de25d-117">The message will not be sent until the user taps the send button.</span></span> |
| [<span data-ttu-id="de25d-118">SMS メッセージの送信</span><span class="sxs-lookup"><span data-stu-id="de25d-118">Send an SMS message</span></span>](sending-an-sms-message.md) | <span data-ttu-id="de25d-119">このトピックでは、SMS の作成ダイアログを起動して、ユーザーが SMS メッセージを送信できるようにする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="de25d-119">This topic shows you how to launch the compose SMS dialog to allow the user to send an SMS message.</span></span> <span data-ttu-id="de25d-120">ダイアログを表示する前に、SMS の各フィールドにデータを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="de25d-120">You can pre-populate the fields of the SMS with data before showing the dialog.</span></span> <span data-ttu-id="de25d-121">メッセージは、ユーザーが送信ボタンをタップするまで送信されません。</span><span class="sxs-lookup"><span data-stu-id="de25d-121">The message will not be sent until the user taps the send button.</span></span> |
| [<span data-ttu-id="de25d-122">予定の管理</span><span class="sxs-lookup"><span data-stu-id="de25d-122">Manage appointments</span></span>](managing-appointments.md) | <span data-ttu-id="de25d-123">[<strong>Windows.ApplicationModel.Appointments</strong>](https://msdn.microsoft.com/library/windows/apps/Dn263359) 名前空間を使うと、ユーザーのカレンダー アプリで予定の作成と管理を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="de25d-123">Through the [<strong>Windows.ApplicationModel.Appointments</strong>](https://msdn.microsoft.com/library/windows/apps/Dn263359) namespace, you can create and manage appointments in a user's calendar app.</span></span> <span data-ttu-id="de25d-124">ここでは、予定を作成してカレンダー アプリに追加し、カレンダー アプリで置換して、カレンダー アプリから削除する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="de25d-124">Here, we'll show you how to create an appointment, add it to a calendar app, replace it in the calendar app, and remove it from the calendar app.</span></span> <span data-ttu-id="de25d-125">さらに、カレンダー アプリの一定の期間を表示し、予定の繰り返しオブジェクトを作る方法も示します。</span><span class="sxs-lookup"><span data-stu-id="de25d-125">We'll also show how to display a time span for a calendar app and create an appointment-recurrence object.</span></span> |
| [<span data-ttu-id="de25d-126">アプリを連絡先カードの操作に接続する</span><span class="sxs-lookup"><span data-stu-id="de25d-126">Connect your app to actions on a contact card</span></span>](integrating-with-contacts.md) | <span data-ttu-id="de25d-127">アプリを連絡先カードまたはミニ連絡先カードの操作の横に表示する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="de25d-127">Shows how to make your app appear next to actions on a contact card or mini contact card.</span></span> <span data-ttu-id="de25d-128">ユーザーは、プロファイル ページを開く、通話を行う、メッセージを送信するなど、操作を実行するアプリを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="de25d-128">Users can choose your app to perform an action such as open a profile page, place a call, or send a message.</span></span> |

 

## <a name="related-topics"></a><span data-ttu-id="de25d-129">関連トピック</span><span class="sxs-lookup"><span data-stu-id="de25d-129">Related topics</span></span>

* [<span data-ttu-id="de25d-130">予定 API のサンプル</span><span class="sxs-lookup"><span data-stu-id="de25d-130">Appointments API sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=309836)
* [<span data-ttu-id="de25d-131">連絡先マネージャー API のサンプル</span><span class="sxs-lookup"><span data-stu-id="de25d-131">Contact manager API sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=310079)
* [<span data-ttu-id="de25d-132">連絡先ピッカー アプリのサンプル</span><span class="sxs-lookup"><span data-stu-id="de25d-132">Contact Picker app sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=231575)
* [<span data-ttu-id="de25d-133">連絡先に関連する操作の処理のサンプル</span><span class="sxs-lookup"><span data-stu-id="de25d-133">Handling Contact Actions sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=320151)
* [<span data-ttu-id="de25d-134">連絡先カードの統合のサンプル</span><span class="sxs-lookup"><span data-stu-id="de25d-134">Contact Card Integration Sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration)
