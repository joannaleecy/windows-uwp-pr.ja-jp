---
author: andrewleader
Description: Learn how to use a progress bar within your toast notification.
title: トーストの進行状況バーとデータ バインディング
label: Toast progress bar and data binding
template: detail.hbs
ms.author: mijacobs
ms.date: 12/7/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, トースト, 進行状況バー, トーストの進行状況バー, 通知, トーストのデータ バインディング
ms.localizationpriority: medium
ms.openlocfilehash: b99c2479bef3c10ecc82707e475f49fd2b9014ec
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4461045"
---
# <a name="toast-progress-bar-and-data-binding"></a><span data-ttu-id="10b8f-103">トーストの進行状況バーとデータ バインディング</span><span class="sxs-lookup"><span data-stu-id="10b8f-103">Toast progress bar and data binding</span></span>

<span data-ttu-id="10b8f-104">トースト通知内に進行状況バーを使用すると、ダウンロード、ビデオ レンダリング、一連の作業など、長い時間を要する処理の進行状況を表示できます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-104">Using a progress bar inside your toast notification allows you to convey the status of long-running operations to the user, like downloads, video rendering, exercise goals, and more.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="10b8f-105">**Creators Update と Notifications ライブラリ 1.4.0 が必要**: トーストで進行状況バーを使用するには、SDK 15063 をターゲットとし、ビルド 15063 以上を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-105">**Requires Creators Update and 1.4.0 of Notifications library**: You must target SDK 15063 and be running build 15063 or higher to use progress bars on toasts.</span></span> <span data-ttu-id="10b8f-106">トーストのコンテンツ内に進行状況バーを作成するには、[UWP コミュニティ ツールキットの Notifications NuGet ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)、バージョン 1.4.0 以上を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-106">You must use version 1.4.0 or higher of the [UWP Community Toolkit Notifications NuGet library](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) to construct the progress bar in your toast's content.</span></span>

<span data-ttu-id="10b8f-107">トースト内の進行状況バーには、特定の値が表示されず、単に処理中であることをアニメーションのドットによって示す "不確定型" と、完了した処理の割合 (60% など) をバーの塗りつぶしによって示すを示す ”確定型” があります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-107">A progress bar inside a toast can either be "indetermindate" (no specific value, animated dots indicate an operation is occurring) or "determinate" (a specific percent of the bar is filled, like 60%).</span></span>

> <span data-ttu-id="10b8f-108">**重要な API**: [NotificationData クラス](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationdata)、[ToastNotifier.Update メソッド](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update)、[ToastNotification クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)</span><span class="sxs-lookup"><span data-stu-id="10b8f-108">**Important APIs**: [NotificationData class](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationdata), [ToastNotifier.Update method](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update), [ToastNotification class](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotification)</span></span>

> [!NOTE]
> <span data-ttu-id="10b8f-109">トースト通知での進行状況バーは、デスクトップでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="10b8f-109">Only Desktop supports progress bars in toast notifications.</span></span> <span data-ttu-id="10b8f-110">他のデバイスでは、進行状況バーが通知から削除されます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-110">On other devices, the progress bar will be dropped from your notification.</span></span>

<span data-ttu-id="10b8f-111">下の図では、確定型の進行状況バーと、それに対応するすべてのプロパティのラベルを示します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-111">The picture below shows a determinate progress bar with all of its corresponding properties labeled.</span></span>

<img alt="Toast with progress bar properties labeled" src="images/toast-progressbar-annotated.png" width="626"/>

| <span data-ttu-id="10b8f-112">プロパティ</span><span class="sxs-lookup"><span data-stu-id="10b8f-112">Property</span></span> | <span data-ttu-id="10b8f-113">型</span><span class="sxs-lookup"><span data-stu-id="10b8f-113">Type</span></span> | <span data-ttu-id="10b8f-114">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="10b8f-114">Required</span></span> | <span data-ttu-id="10b8f-115">説明</span><span class="sxs-lookup"><span data-stu-id="10b8f-115">Description</span></span> |
|---|---|---|---|
| **<span data-ttu-id="10b8f-116">Title</span><span class="sxs-lookup"><span data-stu-id="10b8f-116">Title</span></span>** | <span data-ttu-id="10b8f-117">string または [BindableString](toast-schema.md#bindablestring)</span><span class="sxs-lookup"><span data-stu-id="10b8f-117">string or [BindableString](toast-schema.md#bindablestring)</span></span> | <span data-ttu-id="10b8f-118">false</span><span class="sxs-lookup"><span data-stu-id="10b8f-118">false</span></span> | <span data-ttu-id="10b8f-119">タイトルの文字列 (オプション) を取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-119">Gets or sets an optional title string.</span></span> <span data-ttu-id="10b8f-120">データ バインディングをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="10b8f-120">Supports data binding.</span></span> |
| **<span data-ttu-id="10b8f-121">Value</span><span class="sxs-lookup"><span data-stu-id="10b8f-121">Value</span></span>** | <span data-ttu-id="10b8f-122">double または [AdaptiveProgressBarValue](toast-schema.md#adaptiveprogressbarvalue) か [BindableProgressBarValue](toast-schema.md#bindableprogressbarvalue)</span><span class="sxs-lookup"><span data-stu-id="10b8f-122">double or [AdaptiveProgressBarValue](toast-schema.md#adaptiveprogressbarvalue) or [BindableProgressBarValue](toast-schema.md#bindableprogressbarvalue)</span></span> | <span data-ttu-id="10b8f-123">false</span><span class="sxs-lookup"><span data-stu-id="10b8f-123">false</span></span> | <span data-ttu-id="10b8f-124">進行状況バーの値を取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-124">Gets or sets the value of the progress bar.</span></span> <span data-ttu-id="10b8f-125">データ バインディングをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="10b8f-125">Supports data binding.</span></span> <span data-ttu-id="10b8f-126">既定値は 0 です。</span><span class="sxs-lookup"><span data-stu-id="10b8f-126">Defaults to 0.</span></span> <span data-ttu-id="10b8f-127">0.0 ～ 1.0 の double 型または `AdaptiveProgressBarValue.Indeterminate` か `new BindableProgressBarValue("myProgressValue")` です。</span><span class="sxs-lookup"><span data-stu-id="10b8f-127">Can either be a double between 0.0 and 1.0, `AdaptiveProgressBarValue.Indeterminate`, or `new BindableProgressBarValue("myProgressValue")`.</span></span> |
| **<span data-ttu-id="10b8f-128">ValueStringOverride</span><span class="sxs-lookup"><span data-stu-id="10b8f-128">ValueStringOverride</span></span>** | <span data-ttu-id="10b8f-129">string または [BindableString](toast-schema.md#bindablestring)</span><span class="sxs-lookup"><span data-stu-id="10b8f-129">string or [BindableString](toast-schema.md#bindablestring)</span></span> | <span data-ttu-id="10b8f-130">false</span><span class="sxs-lookup"><span data-stu-id="10b8f-130">false</span></span> | <span data-ttu-id="10b8f-131">割合を示す既定の文字列に代わって表示される文字列 (オプション) を取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-131">Gets or sets an optional string to be displayed instead of the default percentage string.</span></span> <span data-ttu-id="10b8f-132">これを指定しない場合は、"70%" などの文字が表示されます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-132">If this isn't provided, something like "70%" will be displayed.</span></span> |
| **<span data-ttu-id="10b8f-133">Status</span><span class="sxs-lookup"><span data-stu-id="10b8f-133">Status</span></span>** | <span data-ttu-id="10b8f-134">string または [BindableString](toast-schema.md#bindablestring)</span><span class="sxs-lookup"><span data-stu-id="10b8f-134">string or [BindableString](toast-schema.md#bindablestring)</span></span> | <span data-ttu-id="10b8f-135">true</span><span class="sxs-lookup"><span data-stu-id="10b8f-135">true</span></span> | <span data-ttu-id="10b8f-136">進行状況バーの下の左側に表示されるステータス文字列 (必須) を取得または設定します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-136">Gets or sets a status string (required), which is displayed underneath the progress bar on the left.</span></span> <span data-ttu-id="10b8f-137">この文字列は、"ダウンロード中..." や "インストール中..." などのように、操作の状態を反映する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-137">This string should reflect the status of the operation, like "Downloading..." or "Installing..."</span></span> |


<span data-ttu-id="10b8f-138">以下では、上に示した通知を生成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-138">Here's how you would generate the notification seen above...</span></span>

```csharp
ToastContent content = new ToastContent()
{
    Visual = new ToastVisual()
    {
        BindingGeneric = new ToastBindingGeneric()
        {
            Children =
            {
                new AdaptiveText()
                {
                    Text = "Downloading your weekly playlist..."
                },
 
                new AdaptiveProgressBar()
                {
                    Title = "Weekly playlist",
                    Value = 0.6,
                    ValueStringOverride = "15/26 songs",
                    Status = "Downloading..."
                }
            }
        }
    }
};
```

```xml
<toast>
    <visual>
        <binding template="ToastGeneric">
            <text>Downloading your weekly playlist...</text>
            <progress
                title="Weekly playlist"
                value="0.6"
                valueStringOverride="15/26 songs"
                status="Downloading..."/>
        </binding>
    </visual>
</toast>
```

<span data-ttu-id="10b8f-139">ただし、進行状況バーが実際にリアルタイムに機能するには、バーの値を動的に更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-139">However, you'll need to dynamically update the values of the progress bar for it to actually be "live".</span></span> <span data-ttu-id="10b8f-140">これは、データ バインディングを使用してトーストを更新することで実現します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-140">This can be done by using data binding to update the toast.</span></span>


## <a name="using-data-binding-to-update-a-toast"></a><span data-ttu-id="10b8f-141">データ バインディングを使用したトーストの更新</span><span class="sxs-lookup"><span data-stu-id="10b8f-141">Using data binding to update a toast</span></span>

<span data-ttu-id="10b8f-142">データ バインディングの使用は、以下の手順で行われます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-142">Using data binding involves the following steps...</span></span>

1. <span data-ttu-id="10b8f-143">データ バインドしたフィールドを使用してトースト コンテンツを作成する</span><span class="sxs-lookup"><span data-stu-id="10b8f-143">Construct toast content that utilizes data bound fields</span></span>
2. <span data-ttu-id="10b8f-144">アプリの **ToastNotification** に **Tag** (およびオプションで **Group**) を割り当てる</span><span class="sxs-lookup"><span data-stu-id="10b8f-144">Assign a **Tag** (and optionally a **Group**) to your **ToastNotification**</span></span>
3. <span data-ttu-id="10b8f-145">アプリの **ToastNotification** で **Data** の初期値を定義する</span><span class="sxs-lookup"><span data-stu-id="10b8f-145">Define your initial **Data** values on your **ToastNotification**</span></span>
4. <span data-ttu-id="10b8f-146">トースト通知を送信する</span><span class="sxs-lookup"><span data-stu-id="10b8f-146">Send the toast</span></span>
5. <span data-ttu-id="10b8f-147">**Tag** と **Group** を利用して、**Data** の値を新しい値に更新する</span><span class="sxs-lookup"><span data-stu-id="10b8f-147">Utilize **Tag** and **Group** to update the **Data** values with new values</span></span>

<span data-ttu-id="10b8f-148">以下のコード スニペットでは、これらの手順 1 ～ 4 を示します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-148">The following code snippet shows steps 1-4.</span></span> <span data-ttu-id="10b8f-149">次のスニペットは、トーストの **Data** の値を更新する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="10b8f-149">The next snippet will show how to update the toast **Data** values.</span></span>

```csharp
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
 
public void SendUpdatableToastWithProgress()
{
    // Define a tag (and optionally a group) to uniquely identify the notification, in order update the notification data later;
    string tag = "weekly-playlist";
    string group = "downloads";
 
    // Construct the toast content with data bound fields
    var content = new ToastContent()
    {
        Visual = new ToastVisual()
        {
            BindingGeneric = new ToastBindingGeneric()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Downloading your weekly playlist..."
                    },
    
                    new AdaptiveProgressBar()
                    {
                        Title = "Weekly playlist",
                        Value = new BindableProgressBarValue("progressValue"),
                        ValueStringOverride = new BindableString("progressValueString"),
                        Status = new BindableString("progressStatus")
                    }
                }
            }
        }
    };
 
    // Generate the toast notification
    var toast = new ToastNotification(content.GetXml());
 
    // Assign the tag and group
    toast.Tag = tag;
    toast.Group = group;
 
    // Assign initial NotificationData values
    // Values must be of type string
    toast.Data = new NotificationData();
    toast.Data.Values["progressValue"] = "0.6";
    toast.Data.Values["progressValueString"] = "15/26 songs";
    toast.Data.Values["progressStatus"] = "Downloading...";
 
    // Provide sequence number to prevent out-of-order updates, or assign 0 to indicate "always update"
    toast.Data.SequenceNumber = 1;
 
    // Show the toast notification to the user
    ToastNotificationManager.CreateToastNotifier().Show(toast);
}
```

<span data-ttu-id="10b8f-150">次に、**Data** の値を変更するときは、[**Update**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update) メソッドを使用して、トーストのペイロード全体を再作成することなく、新しいデータを提供します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-150">Then, when you want to change your **Data** values, use the [**Update**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.ToastNotifier.Update) method to provide the new data without re-constructing the entire toast payload.</span></span>

```csharp
using Windows.UI.Notifications;
 
public void UpdateProgress()
{
    // Construct a NotificationData object;
    string tag = "weekly-playlist";
    string group = "downloads";
 
    // Create NotificationData and make sure the sequence number is incremented
    // since last update, or assign 0 for updating regardless of order
    var data = new NotificationData
    {
        SequenceNumber = 2
    };

    // Assign new values
    // Note that you only need to assign values that changed. In this example
    // we don't assign progressStatus since we don't need to change it
    data.Values["progressValue"] = "0.7";
    data.Values["progressValueString"] = "18/26 songs";

    // Update the existing notification's data by using tag/group
    ToastNotificationManager.CreateToastNotifier().Update(data, tag, group);
}
```

<span data-ttu-id="10b8f-151">トースト全体を置き換えるのではなく、**Update** メソッドを使用することで、トースト通知がアクション センターの同じ位置に固定され、上下に移動することがなくなります。</span><span class="sxs-lookup"><span data-stu-id="10b8f-151">Using the **Update** method rather than replacing the entire toast also ensures that the toast notification stays in the same position in Action Center and doesn't move up or down.</span></span> <span data-ttu-id="10b8f-152">進行状況バーが進む間、アクション センターで数秒ごとにトーストが最上位に移動すると、ユーザーに大きな混乱をもたらします。</span><span class="sxs-lookup"><span data-stu-id="10b8f-152">It would be quite confusing to the user if the toast kept jumping to the top of Action Center every few seconds while the progress bar filled!</span></span>

<span data-ttu-id="10b8f-153">**Update** メソッドは、列挙値 [**NotificationUpdateResult**](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationupdateresult) を返します。この列挙値により、更新が正常に完了したかどうかを確認でき、また通知が見つからなかった場合 (おそらく、ユーザーが通知を無視したためであり、その通知に対しては更新の送信を停止する必要があります) を確認できます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-153">The **Update** method returns an enum, [**NotificationUpdateResult**](https://docs.microsoft.com/uwp/api/windows.ui.notifications.notificationupdateresult), which lets you know whether the update succeeded or whether the notification couldn't be found (which means the user has likely dismissed your notification and you should stop sending updates to it).</span></span> <span data-ttu-id="10b8f-154">進行状況バーの操作が完了するまで (ダウンロードが完了するなど)、別のトーストを表示しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="10b8f-154">We do not recommend popping another toast until your progress operation has been completed (like when the download completes).</span></span>


## <a name="elements-that-support-data-binding"></a><span data-ttu-id="10b8f-155">データ バインディングをサポートする要素</span><span class="sxs-lookup"><span data-stu-id="10b8f-155">Elements that support data binding</span></span>
<span data-ttu-id="10b8f-156">トースト通知の中で、データ バインディングをサポートする要素は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="10b8f-156">The following elements in toast notifications support data binding</span></span>

- <span data-ttu-id="10b8f-157">**AdaptiveProgress** のすべてのプロパティ</span><span class="sxs-lookup"><span data-stu-id="10b8f-157">All properties on **AdaptiveProgress**</span></span>
- <span data-ttu-id="10b8f-158">最上位レベルの **AdaptiveText** 要素の **Text** プロパティ</span><span class="sxs-lookup"><span data-stu-id="10b8f-158">The **Text** property on the top-level **AdaptiveText** elements</span></span>


## <a name="update-or-replace-a-notification"></a><span data-ttu-id="10b8f-159">通知の更新と置換</span><span class="sxs-lookup"><span data-stu-id="10b8f-159">Update or replace a notification</span></span>

<span data-ttu-id="10b8f-160">Windows 10 以降では、同じ **Tag** と **Group** を使って新しいトーストを送信することで、いつでも通知を**置き換える**ことができます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-160">Since Windows 10, you could always **replace** a notification by sending a new toast with the same **Tag** and **Group**.</span></span> <span data-ttu-id="10b8f-161">以下では、トーストの**置換**とトーストのデータの**更新**の違いを示します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-161">So what's the difference between **replacing** the toast and **updating** the toast's data?</span></span>

| | <span data-ttu-id="10b8f-162">置換</span><span class="sxs-lookup"><span data-stu-id="10b8f-162">Replacing</span></span> | <span data-ttu-id="10b8f-163">更新</span><span class="sxs-lookup"><span data-stu-id="10b8f-163">Updating</span></span> |
| -- | -- | --
| **<span data-ttu-id="10b8f-164">アクション センター内での位置</span><span class="sxs-lookup"><span data-stu-id="10b8f-164">Position in Action Center</span></span>** | <span data-ttu-id="10b8f-165">通知がアクション センターの一番上に移動します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-165">Moves the notification to the top of Action Center.</span></span> | <span data-ttu-id="10b8f-166">アクション センター内の同じ位置に通知が固定されます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-166">Leaves the notification in place within Action Center.</span></span> |
| **<span data-ttu-id="10b8f-167">コンテンツの変更</span><span class="sxs-lookup"><span data-stu-id="10b8f-167">Modifying content</span></span>** | <span data-ttu-id="10b8f-168">トーストのすべてのコンテンツやレイアウトを完全に変更できます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-168">Can completely change all content/layout of the toast</span></span> | <span data-ttu-id="10b8f-169">データ バインディングをサポートするプロパティ (進行状況バーと最上位のテキスト) のみ変更できます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-169">Can only change properties that support data binding (progress bar and top-level text)</span></span> |
| **<span data-ttu-id="10b8f-170">ポップアップとしての再表示</span><span class="sxs-lookup"><span data-stu-id="10b8f-170">Reappearing as popup</span></span>** | <span data-ttu-id="10b8f-171">**SuppressPopup** を `false` に設定したままの場合は、トースト ポップアップとして再表示できます (true に設定するとサイレント モードでアクション センターに送信されます)。</span><span class="sxs-lookup"><span data-stu-id="10b8f-171">Can reappear as a toast popup if you leave **SuppressPopup** set to `false` (or set to true to silently send it to Action Center)</span></span> | <span data-ttu-id="10b8f-172">ポップアップとしては再表示されません。アクション センター内でトーストのデータがサイレント モードで更新されます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-172">Won't reappear as a popup; the toast's data is silently updated within Action Center</span></span> |
| **<span data-ttu-id="10b8f-173">ユーザーによる無視</span><span class="sxs-lookup"><span data-stu-id="10b8f-173">User dismissed</span></span>** | <span data-ttu-id="10b8f-174">ユーザーがそれまでの通知を無視しても、置換トーストは常に送信されます。</span><span class="sxs-lookup"><span data-stu-id="10b8f-174">Regardless of whether user dismissed your previous notification, your replacement toast will always be sent</span></span> | <span data-ttu-id="10b8f-175">ユーザーがトーストを無視すると、トーストの更新は失敗します。</span><span class="sxs-lookup"><span data-stu-id="10b8f-175">If the user dismissed your toast, the toast update will fail</span></span> |

<span data-ttu-id="10b8f-176">一般に、**更新が便利**なのは以下の場合です。</span><span class="sxs-lookup"><span data-stu-id="10b8f-176">In general, **updating is useful for...**</span></span>

- <span data-ttu-id="10b8f-177">短時間で頻繁に変更され、ユーザーに最優先で注目される必要がない情報</span><span class="sxs-lookup"><span data-stu-id="10b8f-177">Information that frequently changes in a short period of time and doesn't require being brought to the front of the user's attention</span></span>
- <span data-ttu-id="10b8f-178">トーストのコンテンツに大きな変更がない場合 (50% ～ 65% 程度の変更率)</span><span class="sxs-lookup"><span data-stu-id="10b8f-178">Subtle changes to your toast content, like changing 50% to 65%</span></span>

<span data-ttu-id="10b8f-179">多くの場合、更新のシーケンスが完了した後 (ファイルのダウンロード後など) の最終手順では、置換の使用をお勧めします。理由は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="10b8f-179">Often times, after your sequence of updates have completed (like the file has been downloaded), we recommend replacing for the final step, because...</span></span>

- <span data-ttu-id="10b8f-180">最後の通知は大幅なレイアウト変更を伴う場合が多い (進行状況バーの削除や、新しいボタンの追加など)</span><span class="sxs-lookup"><span data-stu-id="10b8f-180">Your final notification likely has drastic layout changes, like removal of the progress bar, addition of new buttons, etc</span></span>
- <span data-ttu-id="10b8f-181">ユーザーにとってダウンロードの進行状況は重要でなく、保留中の進行状況通知を無視することがあるが、操作完了時にはポップアップ トーストによる通知を望んでいるため</span><span class="sxs-lookup"><span data-stu-id="10b8f-181">The user might have dismissed your pending progress notification since they don't care about watching it download, but still want to be notified with a popup toast when the operation is completed</span></span>


## <a name="related-topics"></a><span data-ttu-id="10b8f-182">関連トピック</span><span class="sxs-lookup"><span data-stu-id="10b8f-182">Related topics</span></span>

- [<span data-ttu-id="10b8f-183">GitHub での完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="10b8f-183">Full code sample on GitHub</span></span>](https://github.com/WindowsNotifications/quickstart-toast-progress-bar)
- [<span data-ttu-id="10b8f-184">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="10b8f-184">Toast content documentation</span></span>](adaptive-interactive-toasts.md)