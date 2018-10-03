---
author: andrewleader
Description: Learn how to use headers to visually group your toast notifications in Action Center.
title: トースト ヘッダー
label: Toast headers
template: detail.hbs
ms.author: mijacobs
ms.date: 12/7/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト, ヘッダー, トースト ヘッダー, 通知, トーストのグループ化, アクション センター
ms.localizationpriority: medium
ms.openlocfilehash: 0b3c92a41832729b5a60411308d010c3cbb4470a
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/02/2018
ms.locfileid: "4259435"
---
# <a name="toast-headers"></a><span data-ttu-id="f700e-103">トースト ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f700e-103">Toast headers</span></span>

<span data-ttu-id="f700e-104">通知に対してトースト ヘッダーを使用して、アクション センター内の互いに関連する複数の通知を視覚的にグループ化することができます。</span><span class="sxs-lookup"><span data-stu-id="f700e-104">You can visually group a set of related notifications inside Action Center by using a toast header on your notifications.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f700e-105">**デスクトップ版の Creators Update と Notifications ライブラリ 1.4.0 が必要**: トースト ヘッダーを表示するには、デスクトップ版ビルド 15063 以上を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="f700e-105">**Requires Desktop Creators Update and 1.4.0 of Notifications library**: You must be running Desktop build 15063 or higher to see toast headers.</span></span> <span data-ttu-id="f700e-106">トーストのコンテンツ内にヘッダーを作成するには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f700e-106">You must use version 1.4.0 or higher of the [UWP Community Toolkit Notifications NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to construct the header in your toast's content.</span></span> <span data-ttu-id="f700e-107">ヘッダーはデスクトップでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f700e-107">Headers are only supported on Desktop.</span></span>

<span data-ttu-id="f700e-108">以下に示すように、このグループの会話は "Camping!!" という 1 つのヘッダーの下にまとめられています。</span><span class="sxs-lookup"><span data-stu-id="f700e-108">As seen below, this group conversation is unified under a single header, "Camping!!".</span></span> <span data-ttu-id="f700e-109">会話内の個々のメッセージは、同じトースト ヘッダーを共有する別個のトースト通知です。</span><span class="sxs-lookup"><span data-stu-id="f700e-109">Each individual message in the conversation is a separate toast notification sharing the same toast header.</span></span>

<img alt="Toasts with header" src="images/toast-headers-action-center.png" width="396"/>

<span data-ttu-id="f700e-110">通知は、カテゴリに基づいて視覚的にグループ化することもできます。たとえば、搭乗便のリマインダー、荷物の追跡などのカテゴリーを使用できます。</span><span class="sxs-lookup"><span data-stu-id="f700e-110">You can also choose to visually group your notifications by category too, like flight reminders, package tracking, and more.</span></span>

## <a name="add-a-header-to-a-toast"></a><span data-ttu-id="f700e-111">トーストへのヘッダーの追加</span><span class="sxs-lookup"><span data-stu-id="f700e-111">Add a header to a toast</span></span>

<span data-ttu-id="f700e-112">トースト通知にヘッダーを追加する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="f700e-112">Here's how you add a header to a toast notification.</span></span>

> [!NOTE]
> <span data-ttu-id="f700e-113">ヘッダーはデスクトップでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f700e-113">Headers are only supported on Desktop.</span></span> <span data-ttu-id="f700e-114">ヘッダーをサポートしないデバイスでは、ヘッダーが無視されます。</span><span class="sxs-lookup"><span data-stu-id="f700e-114">Devices that don't support headers will simply ignore the header.</span></span>

```csharp
ToastContent toastContent = new ToastContent()
{
    Header = new ToastHeader()
    {
        Id = "6289",
        Title = "Camping!!",
        Arguments = "action=openConversation&id=6289",
    },

    Visual = new ToastVisual() { ... }
};
```

```xml
<toast>

    <header
        id="6289"
        title="Camping!!"
        arguments="action=openConversation&amp;id=6289"/>

    <visual>
        ...
    </visual>

</toast>
```

<span data-ttu-id="f700e-115">以上をまとめると次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f700e-115">In summary...</span></span>

1. <span data-ttu-id="f700e-116">**Header** を **ToastContent** に追加します。</span><span class="sxs-lookup"><span data-stu-id="f700e-116">Add the **Header** to your **ToastContent**</span></span>
2. <span data-ttu-id="f700e-117">必要な **Id**、**Title**、**Arguments** プロパティを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="f700e-117">Assign the required **Id**, **Title**, and **Arguments** properties</span></span>
3. <span data-ttu-id="f700e-118">通知を送信します ([詳細情報](send-local-toast.md))。</span><span class="sxs-lookup"><span data-stu-id="f700e-118">Send your notification ([learn more](send-local-toast.md))</span></span>
4. <span data-ttu-id="f700e-119">別の通知で同じヘッダー ID (**Id**) を使用して、それらの通知を同じヘッダーの下にまとめます。</span><span class="sxs-lookup"><span data-stu-id="f700e-119">On another notification, use the same header **Id** to unify them under the header.</span></span> <span data-ttu-id="f700e-120">**Id** は複数の通知をグループ化するかどうかの判断に使用される唯一のプロパティであり、これが同じであれば、**Title** や **Arguments** が異なっていても同じグループに分類されます。</span><span class="sxs-lookup"><span data-stu-id="f700e-120">The **Id** is the only property used to determine whether the notifications should be grouped, meaning the **Title** and **Arguments** can be different.</span></span> <span data-ttu-id="f700e-121">**Title** と **Arguments** は、グループ内の最新の通知のタイトルと引数が使用されます。</span><span class="sxs-lookup"><span data-stu-id="f700e-121">The **Title** and **Arguments** from the most recent notification within a group are used.</span></span> <span data-ttu-id="f700e-122">その最新の通知が削除された場合、2 番目に新しい通知が繰り上がって最新となり、その通知の **Title** と **Arguments** が使用されます。</span><span class="sxs-lookup"><span data-stu-id="f700e-122">If that notification gets removed, then the **Title** and **Arguments** falls back to the next most recent notification.</span></span>


## <a name="handle-activation-from-a-header"></a><span data-ttu-id="f700e-123">ヘッダーからのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="f700e-123">Handle activation from a header</span></span>

<span data-ttu-id="f700e-124">ヘッダーはクリック可能です。ユーザーはヘッダーをクリックしてアプリから詳細情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="f700e-124">Headers are clickable by users, so that the user can click the header to find out more from your app.</span></span>

<span data-ttu-id="f700e-125">そのため、アプリではトースト自体の起動引数に似た **Arguments** をヘッダーに設定できます。</span><span class="sxs-lookup"><span data-stu-id="f700e-125">Therefore, apps can provide **Arguments** on the header, similar to the launch arguments on the toast itself.</span></span>

<span data-ttu-id="f700e-126">アクティブ化は、[通常のトーストのアクティブ化](send-local-toast.md#handling-activation-1)と同じ方法で処理されるため、ユーザーがトースト本体やトーストのボタンをクリックした場合と同様、`App.xaml.cs` の **OnActivated** メソッドでこれらの引数を取得できます。</span><span class="sxs-lookup"><span data-stu-id="f700e-126">Activation is handled identical to [normal toast activation](send-local-toast.md#handling-activation-1), meaning you can retrieve these arguments in the **OnActivated** method of `App.xaml.cs` just like you do when the user clicks the body of your toast or a button on your toast.</span></span>

```csharp
protected override void OnActivated(IActivatedEventArgs e)
{
    // Handle toast activation
    if (e is ToastNotificationActivatedEventArgs)
    {
        // Arguments specified from the header
        string arguments = (e as ToastNotificationActivatedEventArgs).Argument;
    }
}
```


## <a name="additional-info"></a><span data-ttu-id="f700e-127">追加情報</span><span class="sxs-lookup"><span data-stu-id="f700e-127">Additional info</span></span>

<span data-ttu-id="f700e-128">ヘッダーは複数の通知を視覚的に分類し、グループ化します。</span><span class="sxs-lookup"><span data-stu-id="f700e-128">The header visually separates and groups notifications.</span></span> <span data-ttu-id="f700e-129">アプリが保持できる通知の最大数 (20) や、先入れ先出し法による通知の一覧の処理など、その他のしくみはヘッダーを使用しても変わりません。</span><span class="sxs-lookup"><span data-stu-id="f700e-129">It doesn't change any other logistics about the maximum number of notifications an app can have (20) and the first-in-first-out behavior of the notifications list.</span></span>

<span data-ttu-id="f700e-130">ヘッダー内で通知が表示される順序は、アプリごとに、そのアプリの最新の通知 (ヘッダーの一部である場合は、ヘッダー グループ全体) が最初に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f700e-130">The order of notifications within headers are as follows... For a given app, the most recent notification from the app (and the entire header group if part of a header) will appear first.</span></span>

<span data-ttu-id="f700e-131">**Id** には、任意の文字列を設定できます。</span><span class="sxs-lookup"><span data-stu-id="f700e-131">The **Id** can be any string you choose.</span></span> <span data-ttu-id="f700e-132">**ToastHeader** のどのプロパティにも、長さや文字の制限はありません。</span><span class="sxs-lookup"><span data-stu-id="f700e-132">There are no length or character restrictions on any of the properties in **ToastHeader**.</span></span> <span data-ttu-id="f700e-133">唯一の制限は、XML トースト コンテンツ全体の上限が 5 KB ということのみです。</span><span class="sxs-lookup"><span data-stu-id="f700e-133">The only constraint is that your entire XML toast content cannot be larger than 5 KB.</span></span>

<span data-ttu-id="f700e-134">ヘッダーを作成しても、[詳細を表示] ボタンが表示される前に、アクション センター内に表示される通知の数は変わりません (この数は既定で 3 ですが、ユーザーが設定で [システム] を選択して、通知についてアプリごとに構成できます)。</span><span class="sxs-lookup"><span data-stu-id="f700e-134">Creating headers doesn't change the number of notifications shown inside Action Center before the "See more" button appears (this number is 3 by default and can be configured by the user for each app in system Settings for notifications).</span></span>

<span data-ttu-id="f700e-135">アプリのタイトルをクリックした場合と同様、ヘッダーをクリックしても、このヘッダーに属する通知は消去されません (関連の通知を消去するには、アプリでトースト API を使用する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="f700e-135">Clicking on the header, just like clicking on the app title, does not clear any notifications belonging to this header (your app should use the toast APIs to clear the relevant notifications).</span></span>


## <a name="related-topics"></a><span data-ttu-id="f700e-136">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f700e-136">Related topics</span></span>

- [<span data-ttu-id="f700e-137">ローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="f700e-137">Send a local toast and handle activation</span></span>](send-local-toast.md)
- [<span data-ttu-id="f700e-138">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="f700e-138">Toast content documentation</span></span>](adaptive-interactive-toasts.md)