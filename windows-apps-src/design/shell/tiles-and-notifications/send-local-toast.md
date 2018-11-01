---
author: andrewleader
Description: Learn how to send a local toast notification and handle the user clicking the toast.
title: ローカル トースト通知の送信
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Send a local toast notification
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp, トースト通知の送信, 通知, 通知の送信, トースト通知, 方法, クイックスタート, 作業の開始, コード サンプル, チュートリアル
ms.localizationpriority: medium
ms.openlocfilehash: 95f72180038b6ccbed5f399c2cd58081915baf2c
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5941786"
---
# <a name="send-a-local-toast-notification"></a><span data-ttu-id="b7a82-103">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="b7a82-103">Send a local toast notification</span></span>


<span data-ttu-id="b7a82-104">トースト通知は、ユーザーが現在アプリ内にいないときに、アプリが作成してユーザーに配信できるメッセージです。</span><span class="sxs-lookup"><span data-stu-id="b7a82-104">A toast notification is a message that an app can construct and deliver to the user while they are not currently inside your app.</span></span> <span data-ttu-id="b7a82-105">このクイック スタートでは、新しいアダプティブ テンプレートと対話型の操作を使って Windows 10 のトースト通知を作成、配信、表示する手順について紹介します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-105">This Quickstart walks you through the steps to create, deliver, and display a Windows 10 toast notification with the new adaptive templates and interactive actions.</span></span> <span data-ttu-id="b7a82-106">これらの操作をローカル通知を使って説明します。これは、最も簡単に実装できる通知です。</span><span class="sxs-lookup"><span data-stu-id="b7a82-106">These actions are demonstrated through a local notification, which is the simplest notification to implement.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b7a82-107">デスクトップ アプリケーション (デスクトップ ブリッジと従来の Win32) では、通知の送信とアクティブ化の処理の手順が以下とは異なります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-107">Desktop applications (both Desktop Bridge and classic Win32) have different steps for sending notifications and handling activation.</span></span> <span data-ttu-id="b7a82-108">トーストを実装する方法については、「[デスクトップ アプリ](toast-desktop-apps.md)」のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-108">Please see the [Desktop apps](toast-desktop-apps.md) documentation to learn how to implement toasts.</span></span>

<span data-ttu-id="b7a82-109">ここでは、次の操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-109">We will go through the following things:</span></span>

### <a name="sending-a-toast"></a><span data-ttu-id="b7a82-110">トーストの送信</span><span class="sxs-lookup"><span data-stu-id="b7a82-110">Sending a toast</span></span>

* <span data-ttu-id="b7a82-111">通知の視覚的に訴える部分 (テキストと画像) を作成する</span><span class="sxs-lookup"><span data-stu-id="b7a82-111">Constructing the visual part (text and image) of the notification</span></span>
* <span data-ttu-id="b7a82-112">通知に操作を追加する</span><span class="sxs-lookup"><span data-stu-id="b7a82-112">Adding actions to the notification</span></span>
* <span data-ttu-id="b7a82-113">トーストに有効期限を設定する</span><span class="sxs-lookup"><span data-stu-id="b7a82-113">Setting an expiration time on the toast</span></span>
* <span data-ttu-id="b7a82-114">後でトーストの置き換えや削除を実行できるように、タグやグループを設定する</span><span class="sxs-lookup"><span data-stu-id="b7a82-114">Setting tag/group so you can replace/remove the toast at a later time</span></span>
* <span data-ttu-id="b7a82-115">ローカル API を使ってトーストを送信する</span><span class="sxs-lookup"><span data-stu-id="b7a82-115">Sending your toast using the local APIs</span></span>

### <a name="handling-activation"></a><span data-ttu-id="b7a82-116">アクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="b7a82-116">Handling activation</span></span>

* <span data-ttu-id="b7a82-117">本文またはボタンがクリックされたときにアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-117">Handling activation when the body or buttons are clicked</span></span>
* <span data-ttu-id="b7a82-118">フォアグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-118">Handling foreground activation</span></span>
* <span data-ttu-id="b7a82-119">バックグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-119">Handling background activation</span></span>

> <span data-ttu-id="b7a82-120">**重要な API**: [ToastNotification クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)、[ToastNotificationActivatedEventArgs クラス](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs)</span><span class="sxs-lookup"><span data-stu-id="b7a82-120">**Important APIs**: [ToastNotification Class](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification), [ToastNotificationActivatedEventArgs Class](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs)</span></span>


## <a name="prerequisites"></a><span data-ttu-id="b7a82-121">前提条件</span><span class="sxs-lookup"><span data-stu-id="b7a82-121">Prerequisites</span></span>

<span data-ttu-id="b7a82-122">このトピックを十分に理解するには、次のものが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-122">To fully understand this topic, the following will be helpful...</span></span>

* <span data-ttu-id="b7a82-123">トースト通知に関する用語と概念についての実用的知識。</span><span class="sxs-lookup"><span data-stu-id="b7a82-123">A working knowledge of toast notification terms and concepts.</span></span> <span data-ttu-id="b7a82-124">詳細については、[トーストとアクション センターの概要](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/toast-notification-and-action-center-overview-for-windows-10/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-124">For more information, see[Toast and action center overview](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/toast-notification-and-action-center-overview-for-windows-10/).</span></span>
* <span data-ttu-id="b7a82-125">Windows 10 のトースト通知のコンテンツに関する知識。</span><span class="sxs-lookup"><span data-stu-id="b7a82-125">A familiarity with Windows 10 toast notification content.</span></span> <span data-ttu-id="b7a82-126">詳しくは、[トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-126">For more information, see [toast content documentation](adaptive-interactive-toasts.md).</span></span>
* <span data-ttu-id="b7a82-127">Windows 10 UWP アプリ プロジェクト</span><span class="sxs-lookup"><span data-stu-id="b7a82-127">A Windows 10 UWP app project</span></span>

> [!NOTE]
> <span data-ttu-id="b7a82-128">Windows 8/8.1 とは異なり、アプリがトースト通知を表示できることをアプリのマニフェストで宣言する必要はなくなりました。</span><span class="sxs-lookup"><span data-stu-id="b7a82-128">Unlike Windows 8/8.1, you no longer need to declare in your app's manifest that your app is capable of showing toast notifications.</span></span> <span data-ttu-id="b7a82-129">すべてのアプリがトースト通知を送信して表示できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-129">All apps are capable of sending and displaying toast notifications.</span></span>

> [!NOTE]
> <span data-ttu-id="b7a82-130">**Windows 8/8.1 アプリ**: [アーカイブ ドキュメント](https://msdn.microsoft.com/library/windows/apps/xaml/hh868254.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-130">**Windows 8/8.1 apps**: Please use the [archived documentation](https://msdn.microsoft.com/library/windows/apps/xaml/hh868254.aspx).</span></span>


## <a name="install-nuget-packages"></a><span data-ttu-id="b7a82-131">NuGet パッケージをインストールする</span><span class="sxs-lookup"><span data-stu-id="b7a82-131">Install NuGet packages</span></span>

<span data-ttu-id="b7a82-132">プロジェクトに次の 2 つの NuGet パッケージをインストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b7a82-132">We recommend installing the two following NuGet packages to your project.</span></span> <span data-ttu-id="b7a82-133">今回のコード サンプルではそれらのパッケージを使います。</span><span class="sxs-lookup"><span data-stu-id="b7a82-133">Our code sample will use these packages.</span></span> <span data-ttu-id="b7a82-134">このページの最後に、NuGet パッケージを使わない "古典的な" コード スニペットを示します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-134">At the end of the article we'll provide the "Vanilla" code snippets that don't use any NuGet packages.</span></span>

* <span data-ttu-id="b7a82-135">[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/): 生の XML ではなく、オブジェクトを通じてトーストのペイロードを生成します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-135">[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/): Generate toast payloads via objects instead of raw XML.</span></span>
* <span data-ttu-id="b7a82-136">[QueryString.NET](https://www.nuget.org/packages/QueryString.NET/): C# を使ってクエリ文字列を生成、解析します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-136">[QueryString.NET](https://www.nuget.org/packages/QueryString.NET/): Generate and parse query strings with C#</span></span>


## <a name="add-namespace-declarations"></a><span data-ttu-id="b7a82-137">名前空間宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="b7a82-137">Add namespace declarations</span></span>

`Windows.UI.Notifications` <span data-ttu-id="b7a82-138">にはトースト API が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-138">includes the toast APIs.</span></span>

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET
```


## <a name="send-a-toast"></a><span data-ttu-id="b7a82-139">トーストを送信する</span><span class="sxs-lookup"><span data-stu-id="b7a82-139">Send a toast</span></span>

<span data-ttu-id="b7a82-140">Windows 10 では、トースト通知のコンテンツは、通知の外観にすばらしい柔軟性を持たせることができるアダプティブ言語を使って表されます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-140">In Windows 10, your toast notification content is described using an adaptive language that allows great flexibility with how your notification looks.</span></span> <span data-ttu-id="b7a82-141">詳しくは、[トースト コンテンツのドキュメント](adaptive-interactive-toasts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-141">See the [toast content documentation](adaptive-interactive-toasts.md) for more information.</span></span>

### <a name="constructing-the-visual-part-of-the-content"></a><span data-ttu-id="b7a82-142">コンテンツの視覚的に訴える部分を作成する</span><span class="sxs-lookup"><span data-stu-id="b7a82-142">Constructing the visual part of the content</span></span>

<span data-ttu-id="b7a82-143">まずは、コンテンツの視覚的に訴える部分を作成しましょう。これには、ユーザーに表示するテキストと画像が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-143">Let's start by constructing the visual part of the content, which includes the text and images you want the user to see.</span></span>

<span data-ttu-id="b7a82-144">Notifications ライブラリのおかげ XML コンテンツを生成するは簡単です。</span><span class="sxs-lookup"><span data-stu-id="b7a82-144">Thanks to the Notifications library, generating the XML content is straightforward.</span></span> <span data-ttu-id="b7a82-145">NuGet から Notifications ライブラリをインストールしていない場合は、XML を手動で作成する必要があるので、エラーが残ってしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-145">If you don't install the Notifications library from NuGet, you have to construct the XML manually, which leaves room for errors.</span></span>

> [!NOTE]
> <span data-ttu-id="b7a82-146">画像は、アプリのパッケージ、アプリのローカル ストレージ、または Web から使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-146">Images can be used from the app's package, the app's local storage, or from the web.</span></span> <span data-ttu-id="b7a82-147">Fall Creators Update の時点で、Web 画像の上限は通常の接続で 3 MB、従量制課金接続で 1 MB です。</span><span class="sxs-lookup"><span data-stu-id="b7a82-147">As of the Fall Creators Update, web images can be up to 3 MB on normal connections and 1 MB on metered connections.</span></span> <span data-ttu-id="b7a82-148">まだ Fall Creators Update を実行していないデバイスでは、Web イメージは 200 KB を上限とします。</span><span class="sxs-lookup"><span data-stu-id="b7a82-148">On devices not yet running the Fall Creators Update, web images must be no larger than 200 KB.</span></span>

```csharp
// In a real app, these would be initialized with actual data
string title = "Andrew sent you a picture";
string content = "Check this out, Happy Canyon in Utah!";
string image = "https://picsum.photos/360/202?image=883";
string logo = "ms-appdata:///local/Andrew.jpg";
 
// Construct the visuals of the toast
ToastVisual visual = new ToastVisual()
{
    BindingGeneric = new ToastBindingGeneric()
    {
        Children =
        {
            new AdaptiveText()
            {
                Text = title
            },
 
            new AdaptiveText()
            {
                Text = content
            },
 
            new AdaptiveImage()
            {
                Source = image
            }
        },
 
        AppLogoOverride = new ToastGenericAppLogo()
        {
            Source = logo,
            HintCrop = ToastGenericAppLogoCrop.Circle
        }
    }
};
```


### <a name="constructing-actions-part-of-the-content"></a><span data-ttu-id="b7a82-149">コンテンツの操作部分を作成する</span><span class="sxs-lookup"><span data-stu-id="b7a82-149">Constructing actions part of the content</span></span>

<span data-ttu-id="b7a82-150">次に、コンテンツに操作を追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="b7a82-150">Now let's add actions to the content.</span></span>

<span data-ttu-id="b7a82-151">以下の例には、ユーザーがテキストを入力できる入力要素が含まれています。ユーザーはテキストを入力し、ユーザーがボタンの 1 つまたはトースト自体をクリックしたときに、それがアプリに返されます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-151">In the below example, we included an input element that allows the user to input text, which is returned to the app when the user clicks one of the buttons or the toast itself.</span></span>

<span data-ttu-id="b7a82-152">次に、2 つのボタンが追加され、それぞれのボタンには、個別にアクティブ化の種類、コンテンツ、引数が指定されています。</span><span class="sxs-lookup"><span data-stu-id="b7a82-152">We then added two buttons, each with its own activation type, content, and arguments.</span></span>
* <span data-ttu-id="b7a82-153">**ActivationType** は、ユーザーがこの操作を実行したときに、アプリをアクティブ化する方法を指定するために使われています。</span><span class="sxs-lookup"><span data-stu-id="b7a82-153">**ActivationType** is used to specify how your app wants to be activated when this action is performed by the user.</span></span> <span data-ttu-id="b7a82-154">フォアグラウンドでアプリを起動するか、バックグラウンド タスクを起動するか、別のアプリをプロトコル起動するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-154">You can choose to launch your app in the foreground, launch a background task, or protocol launch another app.</span></span> <span data-ttu-id="b7a82-155">アプリでフォアグラウンドかバックグラウンドのいずれを選択するかに関係なく、ユーザー入力と指定した引数が常に提供されるため、アプリはメッセージの送信や会話の開始など、正しいアクションを実行できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-155">Whether your app chooses foreground or background, you will always receive the user input and the arguments you specified, so your app can perform the correct action, like sending the message or opening a conversation.</span></span>

```csharp
// In a real app, these would be initialized with actual data
int conversationId = 384928;
 
// Construct the actions for the toast (inputs and buttons)
ToastActionsCustom actions = new ToastActionsCustom()
{
    Inputs =
    {
        new ToastTextBox("tbReply")
        {
            PlaceholderContent = "Type a response"
        }
    },
 
    Buttons =
    {
        new ToastButton("Reply", new QueryString()
        {
            { "action", "reply" },
            { "conversationId", conversationId.ToString() }
 
        }.ToString())
        {
            ActivationType = ToastActivationType.Background,
            ImageUri = "Assets/Reply.png",
 
            // Reference the text box's ID in order to
            // place this button next to the text box
            TextBoxId = "tbReply"
        },
 
        new ToastButton("Like", new QueryString()
        {
            { "action", "like" },
            { "conversationId", conversationId.ToString() }
 
        }.ToString())
        {
            ActivationType = ToastActivationType.Background
        },
 
        new ToastButton("View", new QueryString()
        {
            { "action", "viewImage" },
            { "imageUrl", image }
 
        }.ToString())
    }
};
```


### <a name="combining-the-above-to-construct-the-full-content"></a><span data-ttu-id="b7a82-156">上記を組み合わせてコンテンツを完成させる</span><span class="sxs-lookup"><span data-stu-id="b7a82-156">Combining the above to construct the full content</span></span>

<span data-ttu-id="b7a82-157">これでコンテンツの作成は完了です。作成したコンテンツを使用して [**ToastNotification**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification) オブジェクトをインスタンス化できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-157">The construction of the content is now complete, and we can use it to instantiate your [**ToastNotification**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification) object.</span></span>

<span data-ttu-id="b7a82-158">**注**: ユーザーがトースト通知の本文をタップしたときにどの種類のアクティブ化が必要なのかを指定するために、ルート要素にアクティブ化の種類を提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-158">**Note**: you can also provide an activation type inside the root element, to specify what type of activation needs to happen when the user taps on the body of the toast notification.</span></span> <span data-ttu-id="b7a82-159">通常、トーストの本文がタップされたら、一貫性したユーザー エクスペリエンスを作成するためにフォアグラウンドでアプリを起動する必要がありますが、ユーザーに適した特定のシナリオに合うように他のアクティブ化の種類を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-159">Normally, tapping the body of the toast should launch your app in the foreground to create a consistent user experience, but you can use other activation types to fit your specific scenario where it makes most sense to the user.</span></span>

<span data-ttu-id="b7a82-160">ユーザーがトーストの本文をタップしたときや、アプリが起動したときに、どのコンテンツを表示するかをアプリが判断できるように、**Launch** プロパティは常に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-160">You should always set the **Launch** property, so when user taps the body of the toast and your app is launched, your app knows what content it should display.</span></span>

```csharp
// Now we can construct the final toast content
ToastContent toastContent = new ToastContent()
{
    Visual = visual,
    Actions = actions,
 
    // Arguments when the user taps body of toast
    Launch = new QueryString()
    {
        { "action", "viewConversation" },
        { "conversationId", conversationId.ToString() }
 
    }.ToString()
};
 
// And create the toast notification
var toast = new ToastNotification(toastContent.GetXml());
```


## <a name="set-an-expiration-time"></a><span data-ttu-id="b7a82-161">有効期限を設定する</span><span class="sxs-lookup"><span data-stu-id="b7a82-161">Set an expiration time</span></span>

<span data-ttu-id="b7a82-162">Windows 10 では、ユーザーが閉じるか無視したすべてのトースト通知はアクション センター に送られるため、ユーザーはポップアップが消えた後も通知を表示できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-162">In Windows 10, all toast notifications go in Action Center after they are dismissed or ignored by the user, so users can look at your notification after the popup is gone.</span></span>

<span data-ttu-id="b7a82-163">ただし、通知に含まれているメッセージが一定期間だけ関係する場合は、トースト通知に有効期限を設定して、アプリからユーザーに古い情報が表示されないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-163">However, if the message in your notification is only relevant for a period of time, you should set an expiration time on the toast notification so the users do not see stale information from your app.</span></span> <span data-ttu-id="b7a82-164">たとえば、12 時間限りのキャンペーンの場合は、有効期限を 12 時間に設定します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-164">For example, if a promotion is only valid for 12 hours, set the expiration time to 12 hours.</span></span> <span data-ttu-id="b7a82-165">以下のコードでは、有効期限が 2 日間に設定されています。</span><span class="sxs-lookup"><span data-stu-id="b7a82-165">In the code below, we set the expiration time to be 2 days.</span></span>

> [!NOTE]
> <span data-ttu-id="b7a82-166">ローカル トースト通知の既定の最長有効期限は 3 日間です。</span><span class="sxs-lookup"><span data-stu-id="b7a82-166">The default and maximum expiration time for local toast notifications is 3 days.</span></span>

```csharp
toast.ExpirationTime = DateTime.Now.AddDays(2);
```


## <a name="provide-a-primary-key-for-your-toast"></a><span data-ttu-id="b7a82-167">トーストの主キーを提供する</span><span class="sxs-lookup"><span data-stu-id="b7a82-167">Provide a primary key for your toast</span></span>

<span data-ttu-id="b7a82-168">送信した通知をプログラムで削除するか差し替える必要がある場合、Tag プロパティ (および必要に応じて Group プロパティ) を使って通知の主キーを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-168">If you want to programmatically remove or replace the notification you send, you need to use the Tag property (and optionally the Group property) to provide a primary key for your notification.</span></span> <span data-ttu-id="b7a82-169">そうすると、今後この主キーを使って、通知の削除や差し替えができるようになります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-169">Then, you can use this primary key in the future to remove or replace the notification.</span></span>

<span data-ttu-id="b7a82-170">既に配信されたトースト通知の差し替えと削除の方法について詳しくは、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-170">To see more details on replacing/removing already delivered toast notifications, please see [Quickstart: Managing toast notifications in action center (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx).</span></span>

<span data-ttu-id="b7a82-171">Tag と Group を組み合わせると、復号主キーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-171">Tag and Group combined act as a composite primary key.</span></span> <span data-ttu-id="b7a82-172">Group はより汎用的な ID で、"wallPosts"、"messages"、"friendRequests" などのグループを割り当てることができます。Tag はグループ内から通知自体を一意に識別する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-172">Group is the more generic identifier, where you can assign groups like "wallPosts", "messages", "friendRequests", etc. And then Tag should uniquely identify the notification itself from within the group.</span></span> <span data-ttu-id="b7a82-173">汎用グループを使うことで、[RemoveGroup API](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使ってそのグループからすべての通知を削除できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-173">By using a generic group, you can then remove all notifications from that group by using the [RemoveGroup API](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_).</span></span>

```csharp
toast.Tag = "18365";
toast.Group = "wallPosts";
```


## <a name="send-the-notification"></a><span data-ttu-id="b7a82-174">通知を送信する</span><span class="sxs-lookup"><span data-stu-id="b7a82-174">Send the notification</span></span>

<span data-ttu-id="b7a82-175">トーストを初期化した後は、[ToastNotifier](https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotifier) を作成し、トースト通知を渡して Show() を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="b7a82-175">Once you have initialized your toast, simply create a [ToastNotifier](https://docs.microsoft.com/uwp/api/windows.ui.notifications.toastnotifier) and call Show(), passing in your toast notification.</span></span>

```csharp
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


## <a name="clear-your-notifications"></a><span data-ttu-id="b7a82-176">通知を消去する</span><span class="sxs-lookup"><span data-stu-id="b7a82-176">Clear your notifications</span></span>

<span data-ttu-id="b7a82-177">UWP アプリが独自の通知の削除と消去を行います。</span><span class="sxs-lookup"><span data-stu-id="b7a82-177">UWP apps are responsible for removing and clearing their own notifications.</span></span> <span data-ttu-id="b7a82-178">アプリを起動したときに、通知が自動的に消去されることはありません。</span><span class="sxs-lookup"><span data-stu-id="b7a82-178">When your app is launched, we do NOT automatically clear your notifications.</span></span>

<span data-ttu-id="b7a82-179">Windows では、ユーザーが明示的に通知をクリックした場合のみ、通知を自動的に削除します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-179">Windows will only automatically remove a notification if the user explicitly clicks the notification.</span></span>

<span data-ttu-id="b7a82-180">メッセージング アプリの処理の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-180">Here's an example of what a messaging app should do…</span></span>

1. <span data-ttu-id="b7a82-181">ユーザーが会話の中で新しいメッセージに関する複数のトーストを受け取る</span><span class="sxs-lookup"><span data-stu-id="b7a82-181">User receives multiple toasts about new messages in a conversation</span></span>
2. <span data-ttu-id="b7a82-182">ユーザーがそれらのトーストのいずれかをタップして会話を開く</span><span class="sxs-lookup"><span data-stu-id="b7a82-182">User taps one of those toasts to open the conversation</span></span>
3. <span data-ttu-id="b7a82-183">アプリが会話を開き、その会話のすべてのトーストを消去する (その会話用にアプリが提供するグループで [RemoveGroup](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使う)</span><span class="sxs-lookup"><span data-stu-id="b7a82-183">The app opens the conversation and then clears all toasts for that conversation (by using [RemoveGroup](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) on the app-supplied group for that conversation)</span></span>
4. <span data-ttu-id="b7a82-184">ユーザーのアクション センターが通知の状態を正しく反映して、その会話の古い通知がアクション センターに残らないように処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-184">User's Action Center now properly reflects the notification state, since there are no stale notifications for that conversation left in Action Center.</span></span>

<span data-ttu-id="b7a82-185">すべての通知を消去する方法または特定の通知を削除する方法については、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-185">To learn about clearing all notifications or removing specific notifications, see [Quickstart: Managing toast notifications in action center (XAML)](https://msdn.microsoft.com/library/windows/apps/xaml/dn631260.aspx).</span></span>


## <a name="handling-activation"></a><span data-ttu-id="b7a82-186">アクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-186">Handling activation</span></span>

<span data-ttu-id="b7a82-187">Windows 10 では、ユーザーがトーストをクリックしたときに、次の 2 つの方法でトーストにアプリをアクティブ化させることができます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-187">In Windows 10, when the user clicks on your toast, you can have the toast activate your app in two different ways...</span></span>

* <span data-ttu-id="b7a82-188">フォアグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="b7a82-188">Foreground activation</span></span>
* <span data-ttu-id="b7a82-189">バックグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="b7a82-189">Background activation</span></span>

> [!NOTE]
> <span data-ttu-id="b7a82-190">Windows 8.1 のレガシのトースト テンプレートを使っている場合は、**OnActivated** の代わりに、**OnLaunched** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-190">If you are using the legacy toast templates from Windows 8.1, **OnLaunched** will be called instead of **OnActivated**.</span></span> <span data-ttu-id="b7a82-191">次のドキュメントは、Notifications ライブラリ (生の XML を使っている場合は ToastGeneric テンプレート) を使っている Windows 10 の最新の通知のみに該当します。</span><span class="sxs-lookup"><span data-stu-id="b7a82-191">The following documentation only applies to modern Windows 10 notifications utilizing the Notifications library (or the ToastGeneric template if using raw XML).</span></span>


### <a name="handling-foreground-activation"></a><span data-ttu-id="b7a82-192">フォアグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-192">Handling foreground activation</span></span>

<span data-ttu-id="b7a82-193">Windows 10 では、ユーザーが最新のトースト (またはトースト上のボタン) をクリックすると、**OnLaunched** ではなく、**OnActivated** が新しいアクティブ化の種類 **ToastNotification** を使って呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-193">In Windows 10, when a user clicks a modern toast (or a button on the toast), **OnActivated** is invoked instead of **OnLaunched**, with a new activation kind – **ToastNotification**.</span></span> <span data-ttu-id="b7a82-194">したがって、開発者はトーストのアクティブ化を簡単に識別し、それに応じてタスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-194">Thus, the developer is able to easily distinguish a toast activation and perform tasks accordingly.</span></span>

<span data-ttu-id="b7a82-195">次の例では、トースト コンテンツに最初に指定した arguments の文字列を取得できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-195">In the example you see below, you can retrieve the arguments string you initially provided in the toast content.</span></span> <span data-ttu-id="b7a82-196">また、ユーザーがテキスト ボックスと選択ボックスで指定した入力も取得できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-196">You can also retrieve the input the user provided in your text boxes and selection boxes.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="b7a82-197">**OnLaunched** コードと同様に、フレームを初期化してウィンドウをアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b7a82-197">You must initialize your frame and activate your window just like your **OnLaunched** code.</span></span> <span data-ttu-id="b7a82-198">**OnLaunched は、ユーザーがトーストをクリックしても呼び出されません**。アプリが閉じられてから初めて起動している場合も同様です。</span><span class="sxs-lookup"><span data-stu-id="b7a82-198">**OnLaunched is NOT called if the user clicks on your toast**, even if your app was closed and is launching for the first time.</span></span> <span data-ttu-id="b7a82-199">通常は、**OnLaunched** と **OnActivated** を組み合わせて独自の `OnLaunchedOrActivated` メソッドにまとめることをお勧めします。これは、両方で同じ初期化を実行する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="b7a82-199">We often recommend combining **OnLaunched** and **OnActivated** into your own `OnLaunchedOrActivated` method since the same initialization needs to occur in both.</span></span>

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    // Get the root frame
    Frame rootFrame = Window.Current.Content as Frame;
 
    // TODO: Initialize root frame just like in OnLaunched
 
    // Handle toast activation
    if (e is ToastNotificationActivatedEventArgs)
    {
        var toastActivationArgs = e as ToastNotificationActivatedEventArgs;
                 
        // Parse the query string (using QueryString.NET)
        QueryString args = QueryString.Parse(toastActivationArgs.Argument);
 
        // See what action is being requested 
        switch (args["action"])
        {
            // Open the image
            case "viewImage":
 
                // The URL retrieved from the toast args
                string imageUrl = args["imageUrl"];
 
                // If we're already viewing that image, do nothing
                if (rootFrame.Content is ImagePage && (rootFrame.Content as ImagePage).ImageUrl.Equals(imageUrl))
                    break;
 
                // Otherwise navigate to view it
                rootFrame.Navigate(typeof(ImagePage), imageUrl);
                break;
                             
 
            // Open the conversation
            case "viewConversation":
 
                // The conversation ID retrieved from the toast args
                int conversationId = int.Parse(args["conversationId"]);
 
                // If we're already viewing that conversation, do nothing
                if (rootFrame.Content is ConversationPage && (rootFrame.Content as ConversationPage).ConversationId == conversationId)
                    break;
 
                // Otherwise navigate to view it
                rootFrame.Navigate(typeof(ConversationPage), conversationId);
                break;
        }
 
        // If we're loading the app for the first time, place the main page on
        // the back stack so that user can go back after they've been
        // navigated to the specific page
        if (rootFrame.BackStack.Count == 0)
            rootFrame.BackStack.Add(new PageStackEntry(typeof(MainPage), null, null));
    }
 
    // TODO: Handle other types of activation
 
    // Ensure the current window is active
    Window.Current.Activate();
}
```


## <a name="handling-background-activation"></a><span data-ttu-id="b7a82-200">バックグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="b7a82-200">Handling background activation</span></span>

<span data-ttu-id="b7a82-201">トースト (またはトースト内のボタンで) でバックグラウンドのアクティブ化を指定すると、フォアグラウンド アプリがアクティブ化されるのではなく、バックグラウンド タスクが実行されます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-201">When you specify background activation on your toast (or on a button inside the toast), your background task will be executed instead of activating your foreground app.</span></span>

<span data-ttu-id="b7a82-202">バックグラウンド タスクについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](/launch-resume/support-your-app-with-background-tasks.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-202">For more information on background tasks, please see [Support your app with background tasks](/launch-resume/support-your-app-with-background-tasks.md).</span></span>

<span data-ttu-id="b7a82-203">ビルド 14393 以降をターゲットとしている場合、インプロセス バックグラウンド タスクを使用できるため、大幅に簡略化できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-203">If you are targeting build 14393 or higher, you can use in-process background tasks, which greatly simplify things.</span></span> <span data-ttu-id="b7a82-204">インプロセス バックグラウンド タスクは古いバージョンの Windows では実行できないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b7a82-204">Note that in-process background tasks will fail to run on older versions of Windows.</span></span> <span data-ttu-id="b7a82-205">次のコード サンプルでは、インプロセス バックグラウンド タスクが使用されています。</span><span class="sxs-lookup"><span data-stu-id="b7a82-205">We'll use an in-process background task in this code sample.</span></span>

```csharp
const string taskName = "ToastBackgroundTask";

// If background task is already registered, do nothing
if (BackgroundTaskRegistration.AllTasks.Any(i => i.Value.Name.Equals(taskName)))
    return;

// Otherwise request access
BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();

// Create the background task
BackgroundTaskBuilder builder = new BackgroundTaskBuilder()
{
    Name = taskName
};

// Assign the toast action trigger
builder.SetTrigger(new ToastNotificationActionTrigger());

// And register the task
BackgroundTaskRegistration registration = builder.Register();
```


<span data-ttu-id="b7a82-206">App.xaml.cs で、フォアグラウンドのアクティブ化と同様、定義済みの arguments とユーザー入力を取得できる OnBackgroundActivated メソッドをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="b7a82-206">Then in your App.xaml.cs, override the OnBackgroundActivated method you can retrieve the pre-defined arguments and user input, similar to the foreground activation.</span></span>

```csharp
protected override async void OnBackgroundActivated(BackgroundActivatedEventArgs args)
{
    var deferral = args.TaskInstance.GetDeferral();
 
    switch (args.TaskInstance.Task.Name)
    {
        case "ToastBackgroundTask":
            var details = args.TaskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
            if (details != null)
            {
                string arguments = details.Argument;
                var userInput = details.UserInput;

                // Perform tasks
            }
            break;
    }
 
    deferral.Complete();
}
```



## <a name="plain-vanilla-code-snippets"></a><span data-ttu-id="b7a82-207">シンプルで "古典的な" のコード スニペット</span><span class="sxs-lookup"><span data-stu-id="b7a82-207">Plain "Vanilla" code snippets</span></span>

<span data-ttu-id="b7a82-208">NuGet から Notifications ライブラリを使っていない場合、次のように手動で XML を構築して [ToastNotification](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification) を作成できます。</span><span class="sxs-lookup"><span data-stu-id="b7a82-208">If you're not using the Notifications library from NuGet, you can manually construct your XML as seen below to create a [ToastNotification](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification).</span></span>

```csharp
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

// In a real app, these would be initialized with actual data
string title = "Andrew sent you a picture";
string content = "Check this out, Happy Canyon in Utah!";
string image = "http://blogs.msdn.com/cfs-filesystemfile.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-71-81-permanent/2727.happycanyon1_5B00_1_5D00_.jpg";
string logo = "ms-appdata:///local/Andrew.jpg";
 
// TODO: all values need to be XML escaped
 
// Construct the visuals of the toast
string toastVisual =
$@"<visual>
  <binding template='ToastGeneric'>
    <text>{title}</text>
    <text>{content}</text>
    <image src='{image}'/>
    <image src='{logo}' placement='appLogoOverride' hint-crop='circle'/>
  </binding>
</visual>";

// In a real app, these would be initialized with actual data
int conversationId = 384928;
 
// Generate the arguments we'll be passing in the toast
string argsReply = $"action=reply&conversationId={conversationId}";
string argsLike = $"action=like&conversationId={conversationId}";
string argsView = $"action=viewImage&imageUrl={Uri.EscapeDataString(image)}";
 
// TODO: all args need to be XML escaped
 
string toastActions =
$@"<actions>
 
  <input
      type='text'
      id='tbReply'
      placeHolderContent='Type a response'/>
 
  <action
      content='Reply'
      arguments='{argsReply}'
      activationType='background'
      imageUri='Assets/Reply.png'
      hint-inputId='tbReply'/>
 
  <action
      content='Like'
      arguments='{argsLike}'
      activationType='background'/>
 
  <action
      content='View'
      arguments='{argsView}'/>
 
</actions>";

// Now we can construct the final toast content
string argsLaunch = $"action=viewConversation&conversationId={conversationId}";
 
// TODO: all args need to be XML escaped
 
string toastXmlString =
$@"<toast launch='{argsLaunch}'>
    {toastVisual}
    {toastActions}
</toast>";
 
// Parse to XML
XmlDocument toastXml = new XmlDocument();
toastXml.LoadXml(toastXmlString);
 
// Generate toast
var toast = new ToastNotification(toastXml);
```


## <a name="resources"></a><span data-ttu-id="b7a82-209">リソース</span><span class="sxs-lookup"><span data-stu-id="b7a82-209">Resources</span></span>

* [<span data-ttu-id="b7a82-210">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="b7a82-210">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-sending-local-toast)
* [<span data-ttu-id="b7a82-211">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="b7a82-211">Toast content documentation</span></span>](adaptive-interactive-toasts.md)
* [<span data-ttu-id="b7a82-212">ToastNotification クラス</span><span class="sxs-lookup"><span data-stu-id="b7a82-212">ToastNotification Class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)
* [<span data-ttu-id="b7a82-213">ToastNotificationActivatedEventArgs クラス</span><span class="sxs-lookup"><span data-stu-id="b7a82-213">ToastNotificationActivatedEventArgs Class</span></span>](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Activation.ToastNotificationActivatedEventArgs)
