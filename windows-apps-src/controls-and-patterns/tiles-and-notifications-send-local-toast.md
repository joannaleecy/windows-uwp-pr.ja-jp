---
author: mijacobs
Description: "ローカル トースト通知を送信し、トーストをクリックしてユーザーを処理する方法について説明します。"
title: "ローカル トースト通知の送信"
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Send a local toast notification
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 7f21c6a72c00ae2677adb0c1196030997ed48491
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="send-a-local-toast-notification"></a><span data-ttu-id="c2824-104">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="c2824-104">Send a local toast notification</span></span>

<span data-ttu-id="c2824-105">トースト通知は、ユーザーが現在アプリ内にいないときに、アプリが作成してユーザーに配信できるメッセージです。</span><span class="sxs-lookup"><span data-stu-id="c2824-105">A toast notification is a message that an app can construct and deliver to the user while he/she is not currently inside your app.</span></span> <span data-ttu-id="c2824-106">このクイック スタートでは、新しいアダプティブ テンプレートと対話型の操作を使って Windows 10 のトースト通知を作成、配信、表示する手順について紹介します。</span><span class="sxs-lookup"><span data-stu-id="c2824-106">This Quickstart walks you through the steps to create, deliver, and display a Windows 10 toast notification with the new adaptive templates and interactive actions.</span></span> <span data-ttu-id="c2824-107">これらの操作をローカル通知を使って説明します。これは、最も簡単に実装できる通知です。</span><span class="sxs-lookup"><span data-stu-id="c2824-107">These actions are demonstrated through a local notification, which is the simplest notification to implement.</span></span> <span data-ttu-id="c2824-108">ここでは、次の操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="c2824-108">We will go through the following things:</span></span>

### <a name="sending-a-toast"></a><span data-ttu-id="c2824-109">トーストの送信</span><span class="sxs-lookup"><span data-stu-id="c2824-109">Sending a toast</span></span>

* <span data-ttu-id="c2824-110">通知の視覚的に訴える部分 (テキストと画像) を作成する</span><span class="sxs-lookup"><span data-stu-id="c2824-110">Constructing the visual part (text and image) of the notification</span></span>
* <span data-ttu-id="c2824-111">通知に操作を追加する</span><span class="sxs-lookup"><span data-stu-id="c2824-111">Adding actions to the notification</span></span>
* <span data-ttu-id="c2824-112">トーストに有効期限を設定する</span><span class="sxs-lookup"><span data-stu-id="c2824-112">Setting an expiration time on the toast</span></span>
* <span data-ttu-id="c2824-113">後でトーストの置き換えや削除を実行できるように、タグやグループを設定する</span><span class="sxs-lookup"><span data-stu-id="c2824-113">Setting tag/group so you can replace/remove the toast at a later time</span></span>
* <span data-ttu-id="c2824-114">ローカル API を使ってトーストを送信する</span><span class="sxs-lookup"><span data-stu-id="c2824-114">Sending your toast using the local APIs</span></span>

### <a name="handling-activation"></a><span data-ttu-id="c2824-115">アクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="c2824-115">Handling activation</span></span>

* <span data-ttu-id="c2824-116">本文またはボタンがクリックされたときにアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-116">Handling activation when the body or buttons are clicked</span></span>
* <span data-ttu-id="c2824-117">フォアグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-117">Handling foreground activation</span></span>
* <span data-ttu-id="c2824-118">バックグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-118">Handling background activation</span></span>


## <a name="prerequisites"></a><span data-ttu-id="c2824-119">前提条件</span><span class="sxs-lookup"><span data-stu-id="c2824-119">Prerequisites</span></span>

<span data-ttu-id="c2824-120">このトピックを十分に理解するには、次のものが役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c2824-120">To fully understand this topic, the following will be helpful...</span></span>

* <span data-ttu-id="c2824-121">トースト通知に関する用語と概念についての実用的知識。</span><span class="sxs-lookup"><span data-stu-id="c2824-121">A working knowledge of toast notification terms and concepts.</span></span> <span data-ttu-id="c2824-122">詳しくは、[トーストとアクション センターの概要](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/toast-notification-and-action-center-overview-for-windows-10/)に関するブログをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-122">For more information, see [Toast and action center overview](https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/toast-notification-and-action-center-overview-for-windows-10/).</span></span>
* <span data-ttu-id="c2824-123">Windows 10 のトースト通知のコンテンツに関する知識。</span><span class="sxs-lookup"><span data-stu-id="c2824-123">A familiarity with Windows 10 toast notification content.</span></span> <span data-ttu-id="c2824-124">詳しくは、[トースト コンテンツのドキュメント](tiles-and-notifications-adaptive-interactive-toasts.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-124">For more information, see [toast content documentation](tiles-and-notifications-adaptive-interactive-toasts.md).</span></span>
* <span data-ttu-id="c2824-125">Windows 10 UWP アプリ プロジェクト</span><span class="sxs-lookup"><span data-stu-id="c2824-125">A Windows 10 UWP app project</span></span>

<span data-ttu-id="c2824-126">**注**: Windows 8/8.1 とは異なり、アプリがトースト通知を表示できることをアプリのマニフェストで宣言する必要はなくなりました。</span><span class="sxs-lookup"><span data-stu-id="c2824-126">**Note**: Unlike Windows 8/8.1, you no longer need to declare in your app’s manifest that your app is capable of showing toast notifications.</span></span> <span data-ttu-id="c2824-127">すべてのアプリがトースト通知を送信して表示できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-127">All apps are capable of sending and displaying toast notifications.</span></span>

<span data-ttu-id="c2824-128">**Windows 8/8.1 アプリ**: 代わりに、[アーカイブ ドキュメント](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868254.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-128">**Windows 8/8.1 apps**: Please instead use the [archived documentation](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868254.aspx).</span></span>


## <a name="install-nuget-packages"></a><span data-ttu-id="c2824-129">NuGet パッケージをインストールする</span><span class="sxs-lookup"><span data-stu-id="c2824-129">Install NuGet packages</span></span>

<span data-ttu-id="c2824-130">プロジェクトに次の 2 つの NuGet パッケージをインストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c2824-130">We recommend installing the two following NuGet packages to your project.</span></span> <span data-ttu-id="c2824-131">今回のコード サンプルではそれらのパッケージを使います。</span><span class="sxs-lookup"><span data-stu-id="c2824-131">Our code sample will use these packages.</span></span> <span data-ttu-id="c2824-132">記事の最後に、NuGet パッケージを使わない "古典的な" コード スニペットを提供します。</span><span class="sxs-lookup"><span data-stu-id="c2824-132">At the end of the article we’ll provide the “Vanilla” code snippets that don’t use any NuGet packages.</span></span>

* <span data-ttu-id="c2824-133">[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/): 生の XML ではなく、オブジェクトを通じてトーストのペイロードを生成します。</span><span class="sxs-lookup"><span data-stu-id="c2824-133">[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/): Generate toast payloads via objects instead of raw XML.</span></span>
* <span data-ttu-id="c2824-134">[QueryString.NET](https://www.nuget.org/packages/QueryString.NET/): C# を使ってクエリ文字列を生成、解析します。</span><span class="sxs-lookup"><span data-stu-id="c2824-134">[QueryString.NET](https://www.nuget.org/packages/QueryString.NET/): Generate and parse query strings with C#</span></span>


## <a name="add-namespace-declarations"></a><span data-ttu-id="c2824-135">名前空間宣言を追加する</span><span class="sxs-lookup"><span data-stu-id="c2824-135">Add namespace declarations</span></span>

<span data-ttu-id="c2824-136">Windows.UI.Notifications にはトースト API が存在します。</span><span class="sxs-lookup"><span data-stu-id="c2824-136">Windows.UI.Notifications includes the toast APIs.</span></span>

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; // Notifications library
using Microsoft.QueryStringDotNET; // QueryString.NET
```


## <a name="send-a-toast"></a><span data-ttu-id="c2824-137">トーストを送信する</span><span class="sxs-lookup"><span data-stu-id="c2824-137">Send a toast</span></span>

<span data-ttu-id="c2824-138">Windows 10 では、トースト通知のコンテンツは、通知の外観にすばらしい柔軟性を持たせることができるアダプティブ言語を使って表されます。</span><span class="sxs-lookup"><span data-stu-id="c2824-138">In Windows 10, your toast notification content is described using an adaptive language that allows great flexibility with how your notification looks.</span></span> <span data-ttu-id="c2824-139">詳しくは、[トースト コンテンツのドキュメント](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/07/02/adaptive-and-interactive-toast-notifications-for-windows-10.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-139">See the [toast content documentation](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/07/02/adaptive-and-interactive-toast-notifications-for-windows-10.aspx) for more information.</span></span>

### <a name="constructing-the-visual-part-of-the-content"></a><span data-ttu-id="c2824-140">コンテンツの視覚的に訴える部分を作成する</span><span class="sxs-lookup"><span data-stu-id="c2824-140">Constructing the visual part of the content</span></span>

<span data-ttu-id="c2824-141">まずは、コンテンツの視覚的に訴える部分を作成しましょう。これには、ユーザーに表示するテキストと画像コンテンツが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c2824-141">Let’s start by constructing the visual part of the content, which includes the text and image content you want the user to see.</span></span>

<span data-ttu-id="c2824-142">Notifications ライブラリのおかげで、XML コンテンツを簡単に生成できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-142">Thanks to the the Notifications library, generating the XML content is straightforward.</span></span> <span data-ttu-id="c2824-143">NuGet から Notifications ライブラリをインストールしていない場合は、XML を手動で作成する必要があるので、エラーが残ってしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-143">If you don’t install the Notifications library from NuGet, you have to construct the XML manually, which leaves room for errors.</span></span>

<span data-ttu-id="c2824-144">注: 画像は、アプリのパッケージ、アプリのローカル ストレージ、または Web から使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c2824-144">Note: Images can be used from the app’s package, the app’s local storage, or from the web.</span></span> <span data-ttu-id="c2824-145">Web 画像のサイズは 200 KB 未満にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-145">Web images must be less than 200 KB in size.</span></span>

```csharp
// In a real app, these would be initialized with actual data
string title = "Andrew sent you a picture";
string content = "Check this out, Happy Canyon in Utah!";
string image = "https://unsplash.it/360/202?image=883";
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


### <a name="constructing-actions-part-of-the-content"></a><span data-ttu-id="c2824-146">コンテンツの操作部分を作成する</span><span class="sxs-lookup"><span data-stu-id="c2824-146">Constructing actions part of the content</span></span>

<span data-ttu-id="c2824-147">次に、コンテンツに操作を追加しましょう。</span><span class="sxs-lookup"><span data-stu-id="c2824-147">Now let’s add actions to the content.</span></span>

<span data-ttu-id="c2824-148">次の例では、ユーザーがテキストを入力できる入力要素を含めています。各操作に対して対話的操作がどのように定義されているかに応じて、アプリがフォアグラウンドまたはバックグラウンドでアクティブ化されると、入力要素の ID を使ってアプリから入力要素が取得されます。</span><span class="sxs-lookup"><span data-stu-id="c2824-148">In the below example, we included an input element that allows the user to input text, which can then be retrieved by the app using its id, once it is activated in the foreground or background – depending on how the interactions are defined for each of the actions.</span></span>

<span data-ttu-id="c2824-149">次に、2 つのボタンを作成しました。それぞれに、独自のアクティブ化の種類、コンテンツ、引数を指定しています。</span><span class="sxs-lookup"><span data-stu-id="c2824-149">We then created two buttons, each specifying its own activation type, content, and arguments.</span></span>
* <span data-ttu-id="c2824-150">ActivationType は、ユーザーがこの操作を実行したときに、アプリをアクティブ化する方法を指定するために使われます。</span><span class="sxs-lookup"><span data-stu-id="c2824-150">ActivationType is used to specify how the app wants to be activated when this action is performed by the user.</span></span> <span data-ttu-id="c2824-151">フォアグラウンドでアプリを起動するのか、バックグラウンド タスクを起動するのか、別のアプリをプロトコル起動するのかを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="c2824-151">You can choose to launch your app in the foreground, launch a background task, or protocol launch another app.</span></span> <span data-ttu-id="c2824-152">アプリがアクティブ化の種類にフォアグラウンドとバックグラウンドのどちらを選んだ場合も、ユーザー入力を取得できる方法と arguments 属性で事前に定義した引数があるため、ユーザーが通知にどのように反応したのかの完全なコンテキストを保持しています。</span><span class="sxs-lookup"><span data-stu-id="c2824-152">Whether your app chooses the activation type to be foreground or background, there is always a way for you to retrieve the user input, as well as the args you pre-defined in the arguments attribute, so you have the full context of what the user did to the notification.</span></span>

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


### <a name="combining-the-above-to-construct-the-full-content"></a><span data-ttu-id="c2824-153">上記を組み合わせて完全なコンテンツを作成する</span><span class="sxs-lookup"><span data-stu-id="c2824-153">Combining the above to construct the full content</span></span>

<span data-ttu-id="c2824-154">コンテンツの作成が完了したので、そのコンテンツを使って ToastNotification オブジェクトをインスタンス化できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-154">The construction of the content is now complete, and we can use it to instantiate your ToastNotification object.</span></span>

<span data-ttu-id="c2824-155">**注**: ユーザーがトースト通知の本文をタップしたときにどの種類のアクティブ化が必要なのかを指定するために、ルート要素にアクティブ化の種類を提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="c2824-155">**Note**: you can also provide an activation type inside the root element, to specify what type of activation needs to happen when the user taps on the body of the toast notification.</span></span> <span data-ttu-id="c2824-156">通常、トーストの本文がタップされたら、一貫性したユーザー エクスペリエンスを作成するためにフォアグラウンドでアプリを起動する必要がありますが、ユーザーに適した特定のシナリオに合うように他のアクティブ化の種類を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="c2824-156">Normally, tapping the body of the toast should launch your app in the foreground to create a consistent user experience, but you can use other activation types to fit your specific scenario where it makes most sense to the user.</span></span>

<span data-ttu-id="c2824-157">これまでと同様に、ルート要素に起動パラメーターを追加でき、またそうする必要があるため、ユーザーがトーストの本文をタップしたときに、アプリは通知のコンテンツに関連するビューを使って起動することができます。</span><span class="sxs-lookup"><span data-stu-id="c2824-157">Just like before, you can and should always add a launch parameter to the root element, so when user taps the body of the toast, your app can still be launched with a view that relates to the content of the notification.</span></span>

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


## <a name="set-an-expiration-time"></a><span data-ttu-id="c2824-158">有効期限を設定する</span><span class="sxs-lookup"><span data-stu-id="c2824-158">Set an expiration time</span></span>

<span data-ttu-id="c2824-159">Windows 10 では、どのトースト通知もユーザーによって閉じられたか無視された後でアクション センター (以前は電話でのみ利用できましたが、現在はすべての Windows デバイスで利用できます) に送られるため、ユーザーはポップアップが消えた後に通知を見ることができます。</span><span class="sxs-lookup"><span data-stu-id="c2824-159">In Windows 10, all toast notifications go in Action Center (which was previously only available on phone, but now available on all Windows devices) after they are dismissed or ignored by the user, so users can look at your notification after the popup is gone.</span></span>

<span data-ttu-id="c2824-160">ただし、通知に含まれているメッセージが一定期間だけ関係する場合は、トースト通知に有効期限を設定して、アプリからユーザーに古い情報が表示されないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-160">However, if the message in your notification is only relevant for a period of time, you should set an expiration time on the toast notification so the users do not see stale information from your app.</span></span> <span data-ttu-id="c2824-161">次のコードでは、有効期限を 2 日間に設定しています。</span><span class="sxs-lookup"><span data-stu-id="c2824-161">In the code below we set the expiration time to be 2 days.</span></span>

<span data-ttu-id="c2824-162">**注**: ローカル トースト通知の既定の最長有効期限は 3 日間です。</span><span class="sxs-lookup"><span data-stu-id="c2824-162">**Note**: The default and maximum expiration time for local toast notifications is 3 days.</span></span>

```csharp
toast.ExpirationTime = DateTime.Now.AddDays(2);
```


## <a name="provide-a-primary-key-for-your-toast"></a><span data-ttu-id="c2824-163">トーストの主キーを提供する</span><span class="sxs-lookup"><span data-stu-id="c2824-163">Provide a primary key for your toast</span></span>

<span data-ttu-id="c2824-164">送信した通知をプログラムで削除するか差し替える必要がある場合、Tag プロパティ (および必要に応じて Group プロパティ) を使って通知の主キーを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-164">If you ever want to programmatically remove or replace the notification you send, you need to use the Tag property (and optionally the Group property) to provide a primary key for your notification.</span></span> <span data-ttu-id="c2824-165">そうすると、今後この主キーを使って、通知の削除や差し替えができるようになります。</span><span class="sxs-lookup"><span data-stu-id="c2824-165">Then, you can use this primary key in the future to remove or replace the notification.</span></span>

<span data-ttu-id="c2824-166">既に配信されたトースト通知の差し替えと削除の方法について詳しくは、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-166">To see more details on replacing/removing already delivered toast notifications, please see [Quickstart: Managing toast notifications in action center (XAML)](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn631260.aspx).</span></span>

<span data-ttu-id="c2824-167">Tag と Group を組み合わせると、復号主キーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="c2824-167">Tag and Group combined act as a composite primary key.</span></span> <span data-ttu-id="c2824-168">Group はより汎用的な ID で、"wallPosts"、"messages"、"friendRequests" などのグループを割り当てることができます。Tag はグループ内から通知自体を一意に識別する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-168">Group is the more generic identifier, where you can assign groups like "wallPosts", "messages", "friendRequests", etc. And then Tag should uniquely identify the notification itself from within the group.</span></span> <span data-ttu-id="c2824-169">汎用グループを使うことで、[RemoveGroup API](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使ってそのグループからすべての通知を削除できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-169">By using a generic group, you can then remove all notifications from that group by using the [RemoveGroup API](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_).</span></span>

```csharp
toast.Tag = "18365";
toast.Group = "wallPosts";
```


## <a name="send-the-notification"></a><span data-ttu-id="c2824-170">通知を送信する</span><span class="sxs-lookup"><span data-stu-id="c2824-170">Send the notification</span></span>

<span data-ttu-id="c2824-171">トーストを作成したら、ToastNotifier を作成し、Show() を呼び出してトースト通知に渡すだけです。</span><span class="sxs-lookup"><span data-stu-id="c2824-171">Once you have your toast constructed, simply create a ToastNotifier and call Show(), passing in your toast notification.</span></span>

```
ToastNotificationManager.CreateToastNotifier().Show(toast);
```


## <a name="clear-your-notifications"></a><span data-ttu-id="c2824-172">通知を消去する</span><span class="sxs-lookup"><span data-stu-id="c2824-172">Clear your notifications</span></span>

<span data-ttu-id="c2824-173">UWP アプリが独自の通知の削除と消去を行います。</span><span class="sxs-lookup"><span data-stu-id="c2824-173">UWP apps are responsible for removing and clearing their own notifications.</span></span> <span data-ttu-id="c2824-174">アプリを起動したときに、通知が自動的に消去されることはありません。</span><span class="sxs-lookup"><span data-stu-id="c2824-174">When your app is launched, we do NOT automatically clear your notifications.</span></span>

<span data-ttu-id="c2824-175">Windows では、ユーザーが明示的に通知をクリックした場合のみ、通知を自動的に削除します。</span><span class="sxs-lookup"><span data-stu-id="c2824-175">Windows will only automatically remove a notification if the user explicitly clicks the notification.</span></span>

<span data-ttu-id="c2824-176">メッセージング アプリが行うべきことの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c2824-176">Here’s an example of what a messaging app should do…</span></span>

1. <span data-ttu-id="c2824-177">ユーザーが会話の中で新しいメッセージに関する複数のトーストを受け取る</span><span class="sxs-lookup"><span data-stu-id="c2824-177">User receives multiple toasts about new messages in a conversation</span></span>
2. <span data-ttu-id="c2824-178">ユーザーがそれらのトーストのいずれかをタップして会話を開く</span><span class="sxs-lookup"><span data-stu-id="c2824-178">User taps one of those toasts to open the conversation</span></span>
3. <span data-ttu-id="c2824-179">アプリが会話を開き、その会話のすべてのトーストを消去する (その会話用にアプリが提供するグループで [RemoveGroup](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) を使う)</span><span class="sxs-lookup"><span data-stu-id="c2824-179">The app opens the conversation and then clears all toasts for that conversation (by using [RemoveGroup](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Notifications.ToastNotificationHistory#Windows_UI_Notifications_ToastNotificationHistory_RemoveGroup_System_String_) on the app-supplied group for that conversation)</span></span>
4. <span data-ttu-id="c2824-180">ユーザーのアクション センターが通知の状態を正しく反映して、その会話の古い通知がアクション センターに残らないようにする</span><span class="sxs-lookup"><span data-stu-id="c2824-180">User’s Action Center now properly reflects the notification state, since there are no stale notifications for that conversation left in Action Center.</span></span>

<span data-ttu-id="c2824-181">すべての通知を消去する方法または特定の通知を削除する方法については、「[クイック スタート: アクション センターでのトースト通知の管理 (XAML)](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn631260.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-181">To learn about clearing all notifications or removing specific notifications, see [Quickstart: Managing toast notifications in action center (XAML)](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn631260.aspx).</span></span>


## <a name="handling-activation"></a><span data-ttu-id="c2824-182">アクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-182">Handling activation</span></span>

<span data-ttu-id="c2824-183">Windows 10 では、ユーザーがトーストをクリックしたときに、次の 2 つの方法でトーストにアプリをアクティブ化させることができます。</span><span class="sxs-lookup"><span data-stu-id="c2824-183">In Windows 10, when the user clicks on your toast, you can have the toast activate your app in two different ways...</span></span>

* <span data-ttu-id="c2824-184">フォアグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="c2824-184">Foreground activation</span></span>
* <span data-ttu-id="c2824-185">バックグラウンドのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="c2824-185">Background activation</span></span>

<span data-ttu-id="c2824-186">**注**: Windows 8.1 の従来のトースト テンプレートを使っている場合は、代わりに、OnLaunched が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c2824-186">**Note**: If you are using the legacy toast templates from Windows 8.1, OnLaunched will be called instead.</span></span> <span data-ttu-id="c2824-187">次のドキュメントは、Notifications ライブラリ (生の XML を使っている場合は ToastGeneric テンプレート) を使っている Windows 10 の最新の通知のみに該当します。</span><span class="sxs-lookup"><span data-stu-id="c2824-187">The following documentation only applies to modern Windows 10 notifications utilizing the Notifications library (or the ToastGeneric template if using raw XML).</span></span>


### <a name="handling-foreground-activation"></a><span data-ttu-id="c2824-188">フォアグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-188">Handling foreground activation</span></span>

<span data-ttu-id="c2824-189">Windows 10 では、ユーザーが最新のトースト (またはトースト上のボタン) をクリックすると、OnLaunched ではなく、OnActivated が新しいアクティブ化の種類 ToastNotification を使って呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="c2824-189">In Windows 10, when a user clicks a modern toast (or a button on the toast), OnActivated is invoked instead of OnLaunched, with a new activation kind – ToastNotification.</span></span> <span data-ttu-id="c2824-190">したがって、開発者はトーストのアクティブ化を簡単に識別し、それに応じてタスクを実行できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-190">Thus, the developer is able to easily distinguish a toast activation and perform tasks accordingly.</span></span>

<span data-ttu-id="c2824-191">次の例では、トースト コンテンツに最初に指定した arguments の文字列を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-191">In the example you see below, you can retrieve the arguments string you initially provided in the toast content.</span></span> <span data-ttu-id="c2824-192">また、ユーザーがテキスト ボックスと選択ボックスで指定した入力も取得できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-192">You can also retrieve the input the user provided in your text boxes and selection boxes.</span></span>

<span data-ttu-id="c2824-193">**注**: OnLaunched コードと同様に、フレームを初期化してウィンドウをアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2824-193">**Note**: You must initialize your frame and activate your window just like your OnLaunched code.</span></span> <span data-ttu-id="c2824-194">**OnLaunched は、ユーザーがトーストをクリックしても呼び出されません**。アプリが閉じられてから初めて起動している場合も同様です。</span><span class="sxs-lookup"><span data-stu-id="c2824-194">**OnLaunched is NOT called if the user clicks on your toast**, even if your app was closed and is launching for the first time.</span></span> <span data-ttu-id="c2824-195">多くの場合、OnLaunched と OnActivated を組み合わせて独自の OnLaunchedOrActivated メソッドにまとめることをお勧めします。これは、両方で同じ初期化を実行する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="c2824-195">We often recommend combining OnLaunched and OnActivated into your own OnLaunchedOrActivated method since the same initialization needs to occur in both.</span></span>

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


## <a name="handling-background-activation"></a><span data-ttu-id="c2824-196">バックグラウンドのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c2824-196">Handling background activation</span></span>

<span data-ttu-id="c2824-197">トースト (またはトースト内のボタンで) でバックグラウンドのアクティブ化を指定すると、フォアグラウンド アプリがアクティブ化されるのではなく、バックグラウンド タスクが実行されます。</span><span class="sxs-lookup"><span data-stu-id="c2824-197">When you specify background activation on your toast (or on a button inside the toast), your background task will be executed instead of activating your foreground app.</span></span>

<span data-ttu-id="c2824-198">バックグラウンド タスクについて詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/support-your-app-with-background-tasks)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c2824-198">For more information on background tasks, please see [Support your app with background tasks](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/support-your-app-with-background-tasks).</span></span>

<span data-ttu-id="c2824-199">ビルド 14393 以降をターゲットとしている場合、インプロセス バックグラウンド タスクを使用できるため、大幅に簡略化できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-199">If you are targeting build 14393 or higher, you can use in-process background tasks, which greatly simplify things.</span></span> <span data-ttu-id="c2824-200">インプロセス バックグラウンド タスクは古いコンピューターでは失敗することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c2824-200">Note that in-process background tasks will fail to run on older machines.</span></span> <span data-ttu-id="c2824-201">次のコード サンプルでは、インプロセス バックグラウンド タスクを使います。</span><span class="sxs-lookup"><span data-stu-id="c2824-201">We'll use an in-process background task in this code sample.</span></span>

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
    Name = "MyToastNotificationActionTrigger",
};

// Assign the toast action trigger
builder.SetTrigger(new ToastNotificationActionTrigger());

// And register the task
BackgroundTaskRegistration registration = builder.Register();
```


<span data-ttu-id="c2824-202">App.xaml.cs で、フォアグラウンドのアクティブ化と同様、定義済みの arguments とユーザー入力を取得できる OnBackgroundActivated メソッドをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="c2824-202">Then in your App.xaml.cs, override the OnBackgroundActivated method you can retrieve the pre-defined arguments and user input, similar to the foreground activation.</span></span>

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



## <a name="plain-vanilla-code-snippets"></a><span data-ttu-id="c2824-203">シンプルで "古典的な" のコード スニペット</span><span class="sxs-lookup"><span data-stu-id="c2824-203">Plain "Vanilla" code snippets</span></span>

<span data-ttu-id="c2824-204">NuGet から Notifications ライブラリを使っていない場合、次のように手動で XML を構築して ToastNotification を作成できます。</span><span class="sxs-lookup"><span data-stu-id="c2824-204">If you're not using the Notifications library from NuGet, you can manually construct your XML as seen below to create a ToastNotification.</span></span>

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


## <a name="resources"></a><span data-ttu-id="c2824-205">リソース</span><span class="sxs-lookup"><span data-stu-id="c2824-205">Resources</span></span>

* [<span data-ttu-id="c2824-206">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="c2824-206">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-sending-local-toast)
* [<span data-ttu-id="c2824-207">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="c2824-207">Toast content documentation</span></span>](tiles-and-notifications-adaptive-interactive-toasts.md)