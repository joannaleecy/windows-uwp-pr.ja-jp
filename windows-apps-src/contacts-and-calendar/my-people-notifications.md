---
title: マイ連絡先の通知
description: 新しい種類のトーストである、マイ連絡先の通知を作成して使用する方法について説明します。
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: db25954b7fc6541ac5f5900236e61cb8da488be6
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8193337"
---
# <a name="my-people-notifications"></a><span data-ttu-id="87284-104">マイ連絡先の通知</span><span class="sxs-lookup"><span data-stu-id="87284-104">My People notifications</span></span>

<span data-ttu-id="87284-105">マイ連絡先の通知は、ユーザーが大切な人たちとつながるための、すばやい表現のジェスチャによる、新しい方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="87284-105">My People notifications provide a new way for users to connect with the people they care about, through quick expressive gestures.</span></span> <span data-ttu-id="87284-106">この記事では、アプリケーションでマイ連絡先の通知を設計および実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="87284-106">This article shows how to design and implement My People notifications in your application.</span></span> <span data-ttu-id="87284-107">完全な実装については、「[マイ連絡先の通知のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/MyPeopleNotifications)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87284-107">For complete implementations, see the [My People Notifications Sample.](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/MyPeopleNotifications)</span></span>

![ハート絵文字通知](images/heart-emoji-notification-small.gif)

## <a name="requirements"></a><span data-ttu-id="87284-109">要件</span><span class="sxs-lookup"><span data-stu-id="87284-109">Requirements</span></span>

+ <span data-ttu-id="87284-110">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="87284-110">Windows 10 and Microsoft Visual Studio 2017.</span></span> <span data-ttu-id="87284-111">インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87284-111">For installation details, see [Get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="87284-112">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="87284-112">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="87284-113">C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="87284-113">To get started with C#, see [Create a "Hello, world" app](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="how-it-works"></a><span data-ttu-id="87284-114">しくみ</span><span class="sxs-lookup"><span data-stu-id="87284-114">How it works</span></span>

<span data-ttu-id="87284-115">汎用のトースト通知の代わりに、マイ連絡先の機能を使って、通知を送信できます。これによって、さらにパーソナルなエクスペリエンスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="87284-115">As an alternative to generic toast notifications, you can now send notifications through the My People feature to provide a more personal experience to users.</span></span> <span data-ttu-id="87284-116">これは、ユーザーのタスク バーにピン留めされた連絡先からマイ連絡先機能を使用して送信される、新しい種類のトーストです。</span><span class="sxs-lookup"><span data-stu-id="87284-116">This is a new kind of toast, sent from a contact pinned on the user's taskbar with the My People feature.</span></span> <span data-ttu-id="87284-117">通知を受信すると、通知が開始されていることを知らせるため、送信者の連絡先の写真がタスク バー上でアニメーションされ、サウンドが再生されます。</span><span class="sxs-lookup"><span data-stu-id="87284-117">When the notification is received, the sender’s contact picture will animate in the taskbar and a sound will play, signaling that the notification is starting.</span></span> <span data-ttu-id="87284-118">アニメーションまたはペイロードで指定された画像が 5 秒間表示されます (または、ペイロードが 5 秒以下のアニメーションの場合、5 秒までループされます)。</span><span class="sxs-lookup"><span data-stu-id="87284-118">The animation or image specified in the payload will be displayed for 5 seconds (or, if the payload is an animation less than 5 seconds long, it will loop until 5 seconds have passed).</span></span>

## <a name="supported-image-types"></a><span data-ttu-id="87284-119">サポートされるイメージの種類</span><span class="sxs-lookup"><span data-stu-id="87284-119">Supported image types</span></span>

+ <span data-ttu-id="87284-120">GIF</span><span class="sxs-lookup"><span data-stu-id="87284-120">GIF</span></span>
+ <span data-ttu-id="87284-121">静的な画像 (JPEG、PNG)</span><span class="sxs-lookup"><span data-stu-id="87284-121">Static Image (JPEG, PNG)</span></span>
+ <span data-ttu-id="87284-122">Spritesheet (垂直方向のみ)</span><span class="sxs-lookup"><span data-stu-id="87284-122">Spritesheet (vertical only)</span></span>

> [!NOTE]
> <span data-ttu-id="87284-123">Spritesheet は、静的な画像 (JPEG または PNG) から派生したアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="87284-123">A spritesheet is an animation derived from a static image (JPEG or PNG).</span></span> <span data-ttu-id="87284-124">個々のフレームは、最初のフレームが上になるように、垂直方向に配置されます (ただし、トースト ペイロードで、別の開始フレームを指定することもできます)。</span><span class="sxs-lookup"><span data-stu-id="87284-124">Individual frames are arranged vertically, such that the first frame is on top (though you can specify a different starting frame in the toast payload).</span></span> <span data-ttu-id="87284-125">各フレームの高さは同じである必要があります。プログラムはこれをループして、アニメーション シーケンスを (ページが垂直方向に配置されているフリップブックのように) 作成します。</span><span class="sxs-lookup"><span data-stu-id="87284-125">Each frame must have the same height, which the program loops through to create an animated sequence (like a flipbook with its pages laid out vertically).</span></span> <span data-ttu-id="87284-126">Spritesheet の例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="87284-126">An example of a spritesheet is shown below.</span></span>

![レインボー Spritesheet](images/shoulder-tap-rainbow-spritesheet.png)

## <a name="notification-parameters"></a><span data-ttu-id="87284-128">通知パラメーター</span><span class="sxs-lookup"><span data-stu-id="87284-128">Notification parameters</span></span>
<span data-ttu-id="87284-129">マイ連絡先の通知は、[トースト通知](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)フレームワークを使用しますが、トースト ペイロードには追加のバインド ノードが必要です。</span><span class="sxs-lookup"><span data-stu-id="87284-129">My People notifications use the [toast notification](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md) framework, but require an additional binding node in the toast payload.</span></span> <span data-ttu-id="87284-130">2 つ目のバインドには、次のパラメーターを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-130">This second binding must include the following parameter:</span></span>

```xml
experienceType=”shoulderTap”
```

<span data-ttu-id="87284-131">これは、トーストをマイ連絡先の通知として扱う必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="87284-131">This indicates that the toast should be treated as a My People notification.</span></span>

<span data-ttu-id="87284-132">バインド内のイメージ ノードには、次のパラメーターを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-132">The image node inside the binding should include the following parameters:</span></span>

+ **<span data-ttu-id="87284-133">src</span><span class="sxs-lookup"><span data-stu-id="87284-133">src</span></span>**
    + <span data-ttu-id="87284-134">アセットの URI。</span><span class="sxs-lookup"><span data-stu-id="87284-134">The URI of the asset.</span></span> <span data-ttu-id="87284-135">HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="87284-135">This can be either HTTP/HTTPS web URI, an msappx URI, or a path to a local file.</span></span>
+ **<span data-ttu-id="87284-136">spritesheet-src</span><span class="sxs-lookup"><span data-stu-id="87284-136">spritesheet-src</span></span>**
    + <span data-ttu-id="87284-137">アセットの URI。</span><span class="sxs-lookup"><span data-stu-id="87284-137">The URI of the asset.</span></span> <span data-ttu-id="87284-138">HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="87284-138">This can be either HTTP/HTTPS web URI, an msappx URI, or a path to a local file.</span></span> <span data-ttu-id="87284-139">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="87284-139">Only required for spritesheet animations.</span></span>
+ **<span data-ttu-id="87284-140">spritesheet-height</span><span class="sxs-lookup"><span data-stu-id="87284-140">spritesheet-height</span></span>**
    + <span data-ttu-id="87284-141">フレームの高さ (ピクセル単位)。</span><span class="sxs-lookup"><span data-stu-id="87284-141">The frame height (in pixels).</span></span> <span data-ttu-id="87284-142">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="87284-142">Only required for spritesheet animations.</span></span>
+ **<span data-ttu-id="87284-143">spritesheet-fps</span><span class="sxs-lookup"><span data-stu-id="87284-143">spritesheet-fps</span></span>**
    + <span data-ttu-id="87284-144">1 秒あたりのフレーム数 (FPS)。</span><span class="sxs-lookup"><span data-stu-id="87284-144">Frames per second (FPS).</span></span> <span data-ttu-id="87284-145">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="87284-145">Only required for spritesheet animations.</span></span> <span data-ttu-id="87284-146">1 ～ 120 の値のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="87284-146">Only values 1-120 are supported.</span></span>
+ **<span data-ttu-id="87284-147">spritesheet-startingFrame</span><span class="sxs-lookup"><span data-stu-id="87284-147">spritesheet-startingFrame</span></span>**
    + <span data-ttu-id="87284-148">アニメーションを開始するフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="87284-148">The frame number to begin the animation.</span></span> <span data-ttu-id="87284-149">Spritesheet アニメーションの場合のみ使用されます。指定されていない場合は、既定値は 0 となります。</span><span class="sxs-lookup"><span data-stu-id="87284-149">Only used for spritesheet animations and defaults to 0 if not provided.</span></span>
+ **<span data-ttu-id="87284-150">alt</span><span class="sxs-lookup"><span data-stu-id="87284-150">alt</span></span>**
    + <span data-ttu-id="87284-151">スクリーン リーダー ナレーションに使用されるテキスト文字列。</span><span class="sxs-lookup"><span data-stu-id="87284-151">Text string used for screen reader narration.</span></span>

> [!NOTE]
> <span data-ttu-id="87284-152">アニメーションの通知を行うときでも、"src" パラメーターで静的な画像を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-152">When making an animated notification, you should still specify a static image in the "src" parameter.</span></span> <span data-ttu-id="87284-153">これは、アニメーションの表示に失敗した場合のフォールバックとして使用されます。</span><span class="sxs-lookup"><span data-stu-id="87284-153">It will be used as a fall-back if the animation fails to display.</span></span>

<span data-ttu-id="87284-154">さらに、トップ レベルのトースト ノードには、**hint-people** パラメーターを含めて、送信連絡先を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-154">In addition, the top-level toast node must include the **hint-people** parameter to specify the sending contact.</span></span> <span data-ttu-id="87284-155">このパラメーターは次の値を取ることができます。</span><span class="sxs-lookup"><span data-stu-id="87284-155">This parameter can have any the following values:</span></span>

+ **<span data-ttu-id="87284-156">メール アドレス</span><span class="sxs-lookup"><span data-stu-id="87284-156">Email address</span></span>** 
    + <span data-ttu-id="87284-157">例:</span><span class="sxs-lookup"><span data-stu-id="87284-157">E.g.</span></span> <span data-ttu-id="87284-158">mailto:johndoe@mydomain.com</span><span class="sxs-lookup"><span data-stu-id="87284-158">mailto:johndoe@mydomain.com</span></span>
+ **<span data-ttu-id="87284-159">電話番号</span><span class="sxs-lookup"><span data-stu-id="87284-159">Telephone number</span></span>** 
    + <span data-ttu-id="87284-160">例:</span><span class="sxs-lookup"><span data-stu-id="87284-160">E.g.</span></span> <span data-ttu-id="87284-161">tel:888-888-8888</span><span class="sxs-lookup"><span data-stu-id="87284-161">tel:888-888-8888</span></span>
+ **<span data-ttu-id="87284-162">リモート ID</span><span class="sxs-lookup"><span data-stu-id="87284-162">Remote ID</span></span>** 
    + <span data-ttu-id="87284-163">例:</span><span class="sxs-lookup"><span data-stu-id="87284-163">E.g.</span></span> <span data-ttu-id="87284-164">remoteid:1234</span><span class="sxs-lookup"><span data-stu-id="87284-164">remoteid:1234</span></span>

> [!NOTE]
> <span data-ttu-id="87284-165">[ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) を使ったアプリで [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact.RemoteId) プロパティを使い、PC に保存されている連絡先とリモートに保存されている連絡先とを関連付ける場合、RemoteId プロパティの値は不変かつ一意であることが不可欠です。</span><span class="sxs-lookup"><span data-stu-id="87284-165">If your app uses the [ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) and uses the [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact.RemoteId) property to link contacts stored on the PC with contacts stored remotely, it is essential that the value for the RemoteId property is both stable and unique.</span></span> <span data-ttu-id="87284-166">つまり、リモート ID は、PC にある他の連絡先 (他のアプリが所有する連絡先も含む) のリモート ID と決して競合しないよう、常に同じユーザー アカウントを一意に識別し、固有のタグを保持している必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-166">This means that the remote ID must consistently identify a single user account, and should contain a unique tag to guarantee that it does not conflict with the remote IDs of other contacts on the PC, including contacts that are owned by other apps.</span></span>
> <span data-ttu-id="87284-167">アプリで使われるリモート ID の不変性と一意性に確証がない場合、[RemoteIdHelper クラス](https://msdn.microsoft.com/en-us/library/windows/apps/jj207024(v=vs.105).aspx#BKMK_UsingtheRemoteIdHelperclass)を使うと、システムに追加するすべてのリモート ID にあらかじめ一意のタグを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="87284-167">If the remote IDs used by your app are not guaranteed to be stable and unique, you can use the [RemoteIdHelper class](https://msdn.microsoft.com/en-us/library/windows/apps/jj207024(v=vs.105).aspx#BKMK_UsingtheRemoteIdHelperclass) in order to add a unique tag to all of your remote IDs before you add them to the system.</span></span> <span data-ttu-id="87284-168">または、RemoteId プロパティを一切使わない代わりに、カスタムの拡張プロパティを作成し、そこに連絡先のリモート ID を格納する方法もあります。</span><span class="sxs-lookup"><span data-stu-id="87284-168">Alternatively, you can choose to not use the RemoteId property at all, and instead create a custom extended property in which to store remote IDs for your contacts.</span></span>

<span data-ttu-id="87284-169">2 番目のバインドとペイロードだけでなく、フォールバック トーストの最初のバインドに別のペイロードを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-169">In addition to the second binding and payload, you must include another payload in the first binding for the fallback toast.</span></span> <span data-ttu-id="87284-170">標準のトーストに強制的に戻される場合に、通知でこれが使用されます (詳細については、[この記事の最後](https://review.docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-notifications#falling-back-to-toast)を参照)。</span><span class="sxs-lookup"><span data-stu-id="87284-170">The notification will use this if it is forced to revert to a regular toast (explained further at the [end of this article](https://review.docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-notifications#falling-back-to-toast)).</span></span>

## <a name="creating-the-notification"></a><span data-ttu-id="87284-171">通知を作成する</span><span class="sxs-lookup"><span data-stu-id="87284-171">Creating the notification</span></span>
<span data-ttu-id="87284-172">[トースト通知](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)と同様に、マイ連絡先通知テンプレートを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="87284-172">You can create a My People notification template just like you would a [toast notification](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md).</span></span>

<span data-ttu-id="87284-173">静的な画像のペイロードを使用してマイ連絡先の通知を作成する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="87284-173">Here's an example of how to create a My People notification with a static image payload:</span></span>

```xml
<toast hint-people="mailto:johndoe@mydomain.com">
    <visual lang="en-US">
        <binding template="ToastGeneric">
            <text hint-style="body">Toast fallback</text>
            <text>Add your fallback toast content here</text>
        </binding>
        <binding template="ToastGeneric" experienceType="shoulderTap">
            <image src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-static-payload.png"/>
        </binding>
    </visual>
</toast>
```

<span data-ttu-id="87284-174">通知を開始すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="87284-174">When you start the notification, it should look like this:</span></span>

![静的な画像通知](images/static-image-notification-small.gif)

<span data-ttu-id="87284-176">アニメーション化された Spritesheet ペイロードを使用して通知を作成する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="87284-176">Here's an example of how to create a notification with an animated spritesheet payload.</span></span> <span data-ttu-id="87284-177">この Spritesheet ではフレームの高さが 80 ピクセルです。1 秒あたり 25 フレームでアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="87284-177">This spritesheet has a frame-height of 80 pixels, which we'll animate at 25 frames per second.</span></span> <span data-ttu-id="87284-178">開始フレームを 15 に設定し、静的なフォールバック画像を "src" パラメーターで指定します。</span><span class="sxs-lookup"><span data-stu-id="87284-178">We set the starting frame to 15 and provide it with a static fallback image in the “src” parameter.</span></span> <span data-ttu-id="87284-179">フォールバック画像は、Spritesheet アニメーションの表示に失敗した場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="87284-179">The fallback image is used if the spritesheet animation fails to display.</span></span>

```xml
<toast hint-people="mailto:johndoe@mydomain.com">
    <visual lang="en-US">
        <binding template="ToastGeneric">
            <text hint-style="body">Toast fallback</text>
            <text>Add your fallback toast content here</text>
        </binding>
        <binding template="ToastGeneric" experienceType="shoulderTap">
            <image src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-pizza-static.png"
                spritesheet-src="https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/images/shoulder-tap-pizza-spritesheet.png"
                spritesheet-height='80' spritesheet-fps='25' spritesheet-startingFrame='15'/>
        </binding>
    </visual>
</toast>
```

<span data-ttu-id="87284-180">通知を開始すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="87284-180">When you start the notification, it should look like this:</span></span>

![Spritesheet 通知](images/pizza-notification-small.gif)

## <a name="starting-the-notification"></a><span data-ttu-id="87284-182">通知を開始する</span><span class="sxs-lookup"><span data-stu-id="87284-182">Starting the notification</span></span>
<span data-ttu-id="87284-183">マイ連絡先の通知を開始するには、トースト テンプレートを [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) オブジェクトに変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="87284-183">To start a My People notification, we need to convert the toast template into an [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) object.</span></span> <span data-ttu-id="87284-184">トーストを (ここでは "content.xml" という名前の) XML ファイル内で定義すると、次のコードを使用して開始できます。</span><span class="sxs-lookup"><span data-stu-id="87284-184">When you have defined the toast in an XML file (here named "content.xml"), you can use this code to start it:</span></span>

```CSharp
string xmlText = File.ReadAllText("content.xml");
XmlDocument xmlContent = new XmlDocument();
xmlContent.LoadXml(xmlText);
```

<span data-ttu-id="87284-185">これで次のコードを使ってトーストを作成して送信できます。</span><span class="sxs-lookup"><span data-stu-id="87284-185">You can then use this code to create and send the toast:</span></span>

```CSharp
ToastNotification notification = new ToastNotification(xmlContent);
ToastNotificationManager.CreateToastNotifier().Show(notification);
```

## <a name="falling-back-to-toast"></a><span data-ttu-id="87284-186">トーストにフォールバックする</span><span class="sxs-lookup"><span data-stu-id="87284-186">Falling back to toast</span></span>
<span data-ttu-id="87284-187">マイ連絡先の通知が標準のトースト通知として表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="87284-187">There are some cases when a My People notification will instead display as a regular toast notification.</span></span> <span data-ttu-id="87284-188">次の条件下では、マイ連絡先の通知はトーストにフォールバックします。</span><span class="sxs-lookup"><span data-stu-id="87284-188">A My People notification will fall back to toast under the following conditions:</span></span>

+ <span data-ttu-id="87284-189">通知の表示に失敗した</span><span class="sxs-lookup"><span data-stu-id="87284-189">The notification fails to display</span></span>
+ <span data-ttu-id="87284-190">受信者で、マイ連絡先の通知が有効化されていない</span><span class="sxs-lookup"><span data-stu-id="87284-190">My People notifications are not enabled by the recipient</span></span>
+ <span data-ttu-id="87284-191">送信者の連絡先が、受信者のタスク バーにピン留めされていない</span><span class="sxs-lookup"><span data-stu-id="87284-191">The sender’s contact is not pinned to the receiver’s taskbar</span></span>

<span data-ttu-id="87284-192">マイ連絡先の通知がトーストにフォールバックすると、2 番目のマイ連絡先固有のバインドは無視され、1 番目のバインドのみが使用されて、トーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="87284-192">If a My People notification falls back to toast, the second My-People-specific binding is ignored, and only the first binding is used to display the toast.</span></span> <span data-ttu-id="87284-193">これは、最初のトースト バインドでフォールバック ペイロードを指定することが重要である理由です。</span><span class="sxs-lookup"><span data-stu-id="87284-193">This is why it is critical to provide a fallback payload in the first toast binding.</span></span>

## <a name="see-also"></a><span data-ttu-id="87284-194">関連項目</span><span class="sxs-lookup"><span data-stu-id="87284-194">See also</span></span>
+ [<span data-ttu-id="87284-195">マイ連絡先の通知のサンプル</span><span class="sxs-lookup"><span data-stu-id="87284-195">My People Notifications Sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/MyPeopleNotifications)
+ [<span data-ttu-id="87284-196">マイ連絡先のサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="87284-196">Adding My People support</span></span>](my-people-support.md)
+ [<span data-ttu-id="87284-197">アダプティブ トースト通知</span><span class="sxs-lookup"><span data-stu-id="87284-197">Adaptive toast notifications</span></span>](../design/shell/tiles-and-notifications/adaptive-interactive-toasts.md)
+ [<span data-ttu-id="87284-198">ToastNotification クラス</span><span class="sxs-lookup"><span data-stu-id="87284-198">ToastNotification Class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification)