---
title: "マイ連絡先の通知"
description: "新しい種類のトーストである、マイ連絡先の通知を作成して使用する方法について説明します。"
author: mukin
ms.author: mukin
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b1fbba8b8cea3edd51dc9b60cae1ea3853f39dd1
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
---
# <a name="my-people-notifications"></a><span data-ttu-id="e04e0-104">マイ連絡先の通知</span><span class="sxs-lookup"><span data-stu-id="e04e0-104">My People notifications</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e04e0-105">**プレリリース | Fall Creators Update が必要**: マイ連絡先 API を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-105">**PRERELEASE | Requires Fall Creators Update**: You must target [Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) and be running [Insider build 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) or higher to use the My People APIs.</span></span>

<span data-ttu-id="e04e0-106">マイ連絡先の通知は、ユーザーやユーザーにとって大切な人たちを重視した、新しい種類のジェスチャです。</span><span class="sxs-lookup"><span data-stu-id="e04e0-106">My People notifications are a new kind of gesture that put people first.</span></span> <span data-ttu-id="e04e0-107">ユーザーが大切な人たちとつながるための、すばやく手軽な表現のジェスチャによる、新しい方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-107">They provide a new way for users to connect with the people they care about through quick, lightweight expressive gestures.</span></span>

![ハート絵文字通知](images/heart-emoji-notification-small.gif)

## <a name="requirements"></a><span data-ttu-id="e04e0-109">要件</span><span class="sxs-lookup"><span data-stu-id="e04e0-109">Requirements</span></span>

+ <span data-ttu-id="e04e0-110">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="e04e0-110">Windows 10 and Microsoft Visual Studio 2017.</span></span> <span data-ttu-id="e04e0-111">インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e04e0-111">For installation details, see [Get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="e04e0-112">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="e04e0-112">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="e04e0-113">C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e04e0-113">To get started with C#, see [Create a "Hello, world" app](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="how-it-works"></a><span data-ttu-id="e04e0-114">しくみ</span><span class="sxs-lookup"><span data-stu-id="e04e0-114">How it works</span></span>

<span data-ttu-id="e04e0-115">アプリケーション開発者は、汎用のトースト通知に代わり、マイ連絡先の機能を使って、通知を送信できます。これによって、さらにパーソナルなエクスペリエンスをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-115">As an alternative to generic toast notifications, application developers can now send notifications through the My People feature, to provide a more personal experience to users.</span></span> <span data-ttu-id="e04e0-116">これは、ユーザーのタスク バーにピン留めされた連絡先から送信される、新しい種類のトーストです。</span><span class="sxs-lookup"><span data-stu-id="e04e0-116">This is a new kind of toast, sent from a contact pinned to the user's taskbar.</span></span> <span data-ttu-id="e04e0-117">通知を受信すると、マイ連絡先の通知が開始されていることを知らせるため、送信者の連絡先の写真がタスク バー上でアニメーションされ、サウンドが再生されます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-117">When the notification is received, the sender’s contact picture will animate in the taskbar and a sound will play, signaling that a My People notification is starting.</span></span> <span data-ttu-id="e04e0-118">アニメーションまたはペイロードで指定された画像が 5 秒間表示されます (ペイロードが 5 秒以下のアニメーションの場合、5 秒までループされます)。</span><span class="sxs-lookup"><span data-stu-id="e04e0-118">Then the animation or image specified in the payload will be displayed for 5 seconds (if the payload is an animation that lasts less than 5 seconds, it will loop until 5 seconds have passed).</span></span>

## <a name="supported-image-types"></a><span data-ttu-id="e04e0-119">サポートされるイメージの種類</span><span class="sxs-lookup"><span data-stu-id="e04e0-119">Supported image types</span></span>

+ <span data-ttu-id="e04e0-120">GIF</span><span class="sxs-lookup"><span data-stu-id="e04e0-120">GIF</span></span>
+ <span data-ttu-id="e04e0-121">静的な画像 (JPEG、PNG)</span><span class="sxs-lookup"><span data-stu-id="e04e0-121">Static Image (JPEG, PNG)</span></span>
+ <span data-ttu-id="e04e0-122">Spritesheet (垂直方向のみ)</span><span class="sxs-lookup"><span data-stu-id="e04e0-122">Spritesheet (vertical only)</span></span>

> [!NOTE]
> <span data-ttu-id="e04e0-123">Spritesheet は、静的な画像 (JPEG または PNG) から派生したアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="e04e0-123">A spritesheet is an animation derived from a static image (JPEG or PNG).</span></span> <span data-ttu-id="e04e0-124">個々のフレームは、最初のフレームが上になるように、垂直方向に配置されます (トースト ペイロードで、別の開始フレームを指定することもできます)。</span><span class="sxs-lookup"><span data-stu-id="e04e0-124">Individual frames are arranged vertically, such that the first frame is on top (you can specify a different starting frame in the toast payload).</span></span> <span data-ttu-id="e04e0-125">各フレームの高さは同じである必要があります。プログラムはこれをループして、アニメーション シーケンスを (すべてのページが垂直方向に配置されているフリップブックのように) 作成します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-125">Each frame must have the same height, which the program loops through to create an animated sequence (like a flipbook with all the pages laid out vertically).</span></span> <span data-ttu-id="e04e0-126">以下に Spritesheet の例を示します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-126">Shown below is an example of a spritesheet.</span></span>

![レインボー Spritesheet](images/shoulder-tap-rainbow-spritesheet.png)

## <a name="notification-parameters"></a><span data-ttu-id="e04e0-128">通知パラメーター</span><span class="sxs-lookup"><span data-stu-id="e04e0-128">Notification parameters</span></span>
<span data-ttu-id="e04e0-129">マイ連絡先の通知は、Windows 10 の[トースト通知](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)フレームワークを使用します。トースト ペイロードには追加のバインド ノードが必要です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-129">My People notifications use the [toast notification](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md) framework in Windows 10 and require an additional binding node in the toast payload.</span></span> <span data-ttu-id="e04e0-130">つまり、マイ連絡先による通知には、1 つではなく 2 つのバインドがある必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-130">This means notifications through My People must have two bindings instead of one.</span></span> <span data-ttu-id="e04e0-131">2 つ目のバインドには、次のパラメーターを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-131">This second binding must include the following parameter:</span></span>

```xml
experienceType=”shoulderTap”
```

<span data-ttu-id="e04e0-132">これは、トーストをマイ連絡先の通知として扱う必要があることを示します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-132">This indicates that the toast should be treated as a My People notifications.</span></span>

<span data-ttu-id="e04e0-133">バインド内のイメージ ノードには、次のパラメーターを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-133">The image node inside the binding should include the following parameters:</span></span>

+ **<span data-ttu-id="e04e0-134">src</span><span class="sxs-lookup"><span data-stu-id="e04e0-134">src</span></span>**
    + <span data-ttu-id="e04e0-135">アセットの URI。</span><span class="sxs-lookup"><span data-stu-id="e04e0-135">The URI of the asset.</span></span> <span data-ttu-id="e04e0-136">HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-136">This can be either HTTP/HTTPS web URI, an msappx URI, or a path to a local file.</span></span>
+ **<span data-ttu-id="e04e0-137">spritesheet-src</span><span class="sxs-lookup"><span data-stu-id="e04e0-137">spritesheet-src</span></span>**
    + <span data-ttu-id="e04e0-138">アセットの URI。</span><span class="sxs-lookup"><span data-stu-id="e04e0-138">The URI of the asset.</span></span> <span data-ttu-id="e04e0-139">HTTP/HTTPS Web URI、msappx URI、またはローカル ファイルへのパスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-139">This can be either HTTP/HTTPS web URI, an msappx URI, or a path to a local file.</span></span> <span data-ttu-id="e04e0-140">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-140">Only required for spritesheet animations.</span></span>
+ **<span data-ttu-id="e04e0-141">spritesheet-height</span><span class="sxs-lookup"><span data-stu-id="e04e0-141">spritesheet-height</span></span>**
    + <span data-ttu-id="e04e0-142">フレームの高さ (ピクセル単位)。</span><span class="sxs-lookup"><span data-stu-id="e04e0-142">The frame height (in pixels).</span></span> <span data-ttu-id="e04e0-143">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-143">Only required for spritesheet animations.</span></span>
+ **<span data-ttu-id="e04e0-144">spritesheet-fps</span><span class="sxs-lookup"><span data-stu-id="e04e0-144">spritesheet-fps</span></span>**
    + <span data-ttu-id="e04e0-145">1 秒あたりのフレーム数。</span><span class="sxs-lookup"><span data-stu-id="e04e0-145">Frames per second.</span></span> <span data-ttu-id="e04e0-146">Spritesheet アニメーションの場合のみ必要です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-146">Only required for spritesheet animations.</span></span>
+ **<span data-ttu-id="e04e0-147">spritesheet-startingFrame</span><span class="sxs-lookup"><span data-stu-id="e04e0-147">spritesheet-startingFrame</span></span>**
    + <span data-ttu-id="e04e0-148">アニメーションを開始するフレーム番号です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-148">The frame number to begin the animation.</span></span> <span data-ttu-id="e04e0-149">Spritesheet アニメーションの場合のみ使用されます。指定されていない場合は、既定値は 0 となります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-149">Only used for spritesheet animations and defaults to 0 if not provided.</span></span>
+ **<span data-ttu-id="e04e0-150">alt</span><span class="sxs-lookup"><span data-stu-id="e04e0-150">alt</span></span>**
    + <span data-ttu-id="e04e0-151">スクリーン リーダー ナレーションに使用されるテキスト文字列。</span><span class="sxs-lookup"><span data-stu-id="e04e0-151">Text string used for screen reader narration.</span></span>

> [!NOTE]
> <span data-ttu-id="e04e0-152">Spritesheet を使用している場合でも、アニメーションの表示に失敗した場合のフォールバックとして、静的な画像を "src" パラメーターに指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-152">Even if you're using a spritesheet, you should still specify a static image in the "src" parameter as a fall-back in case the animation fails to display.</span></span>

<span data-ttu-id="e04e0-153">さらに、トップ レベルのトースト ノードには、**hint-people** パラメーターを含めて、送信連絡先を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-153">In addition, the top-level toast node must include the **hint-people** parameter to indicate the sending contact.</span></span> <span data-ttu-id="e04e0-154">このパラメーターは次の値を取ることができます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-154">This parameter can have any the following values:</span></span>

+ **<span data-ttu-id="e04e0-155">メール アドレス</span><span class="sxs-lookup"><span data-stu-id="e04e0-155">Email address</span></span>** 
    + <span data-ttu-id="e04e0-156">例:</span><span class="sxs-lookup"><span data-stu-id="e04e0-156">E.g.</span></span> <span data-ttu-id="e04e0-157">mailto:johndoe@mydomain.com</span><span class="sxs-lookup"><span data-stu-id="e04e0-157">mailto:johndoe@mydomain.com</span></span>
+ **<span data-ttu-id="e04e0-158">電話番号</span><span class="sxs-lookup"><span data-stu-id="e04e0-158">Telephone number</span></span>** 
    + <span data-ttu-id="e04e0-159">例:</span><span class="sxs-lookup"><span data-stu-id="e04e0-159">E.g.</span></span> <span data-ttu-id="e04e0-160">tel:888-888-8888</span><span class="sxs-lookup"><span data-stu-id="e04e0-160">tel:888-888-8888</span></span>
+ **<span data-ttu-id="e04e0-161">リモート ID</span><span class="sxs-lookup"><span data-stu-id="e04e0-161">Remote ID</span></span>** 
    + <span data-ttu-id="e04e0-162">例:</span><span class="sxs-lookup"><span data-stu-id="e04e0-162">E.g.</span></span> <span data-ttu-id="e04e0-163">remoteid:1234</span><span class="sxs-lookup"><span data-stu-id="e04e0-163">remoteid:1234</span></span>

> [!NOTE]
> <span data-ttu-id="e04e0-164">[ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) を使ったアプリで [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact#Windows_Phone_PersonalInformation_StoredContact_RemoteId) プロパティを使い、PC に保存されている連絡先とリモートに保存されている連絡先とを関連付ける場合、RemoteId プロパティの値は不変かつ一意であることが不可欠です。</span><span class="sxs-lookup"><span data-stu-id="e04e0-164">If your app uses the [ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) and uses the [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact#Windows_Phone_PersonalInformation_StoredContact_RemoteId) property to link contacts stored on the PC with contacts stored remotely, it is essential that the value for the RemoteId property is both stable and unique.</span></span> <span data-ttu-id="e04e0-165">つまり、リモート ID は、PC にある他の連絡先 (他のアプリが所有する連絡先も含む) のリモート ID と決して競合しないよう、常に同じユーザー アカウントを一意に識別し、固有のタグを保持している必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-165">This means that the remote ID must consistently identify a single user account and should contain a unique tag to guarantee that it does not conflict with the remote IDs of other contacts on the PC, including contacts that are owned by other apps.</span></span>
> <span data-ttu-id="e04e0-166">アプリで使われるリモート ID の不変性と一意性に確証がない場合、このトピックの中で後述する RemoteIdHelper クラスを使うと、システムに追加するすべてのリモート ID にあらかじめ一意のタグを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-166">If the remote IDs used by your app are not guaranteed to be stable and unique, you can use the RemoteIdHelper class shown later in this topic in order to add a unique tag to all of your remote IDs before you add them to the system.</span></span> <span data-ttu-id="e04e0-167">または、RemoteId プロパティを一切使わない代わりに、カスタムの拡張プロパティを作成し、そこに連絡先のリモート ID を格納する方法もあります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-167">Or you can choose to not use the RemoteId property at all and instead you create a custom extended property in which to store remote IDs for your contacts.</span></span>

<span data-ttu-id="e04e0-168">2 番目のバインドとペイロードだけでなく、最初のバインドにフォールバックのトースト用の別のペイロードを含める必要があります (強制的に標準のトーストに戻された場合にはこれが使用されます)。</span><span class="sxs-lookup"><span data-stu-id="e04e0-168">In addition to the second binding and payload, you MUST include another payload in the first binding for the fallback toast (which the notification will use if it is forced to revert to a regular toast).</span></span> <span data-ttu-id="e04e0-169">これは、最後のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-169">This is explained in more detail in the final section.</span></span>

## <a name="creating-the-notification"></a><span data-ttu-id="e04e0-170">通知を作成する</span><span class="sxs-lookup"><span data-stu-id="e04e0-170">Creating the notification</span></span>
<span data-ttu-id="e04e0-171">[トースト通知](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)と同様に、マイ連絡先通知テンプレートを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-171">You can create a My People notification template just like you would a [toast notification](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md).</span></span>

<span data-ttu-id="e04e0-172">静的な画像を使用して、マイ連絡先の通知を作成する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-172">Here's an example of how to create a My People notification using a static image:</span></span>

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

<span data-ttu-id="e04e0-173">通知を開始すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-173">If you start the notification, it should look like this:</span></span>

![静的な画像通知](images/static-image-notification-small.gif)

<span data-ttu-id="e04e0-175">次にアニメーションの Spritesheet を使用して、通知を作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-175">Next we'll show how to create a notification using an animated spritesheet.</span></span> <span data-ttu-id="e04e0-176">この Spritesheet ではフレームの高さが 80 ピクセルです。1 秒あたり 25 フレームでアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-176">This spritesheet has a frame-height of 80 pixels, which we'll animate at 25 frames per second.</span></span> <span data-ttu-id="e04e0-177">開始フレームを 15 に設定し、静的なフォールバック画像を "src" パラメーターで指定します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-177">We set the starting frame to 15 and provide it with a static fallback image in the “src” parameter.</span></span> <span data-ttu-id="e04e0-178">フォールバック画像は、Spritesheet アニメーションの表示に失敗した場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-178">The fallback image is used if the spritesheet animation fails to display.</span></span>

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

<span data-ttu-id="e04e0-179">通知を開始すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-179">If you start the notification, it should look like this:</span></span>

![Spritesheet 通知](images/pizza-notification-small.gif)

## <a name="starting-the-notification"></a><span data-ttu-id="e04e0-181">通知を開始する</span><span class="sxs-lookup"><span data-stu-id="e04e0-181">Starting the notification</span></span>
<span data-ttu-id="e04e0-182">マイ連絡先の通知を開始するには、トースト テンプレートを [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) オブジェクトに変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-182">To start a My People notification, we need to convert the toast template into an [XmlDocument](https://msdn.microsoft.com/en-us/library/windows/apps/windows.data.xml.dom.xmldocument.aspx) object.</span></span> <span data-ttu-id="e04e0-183">トーストを (ここでは content.xml という名前の) XML ファイル内で定義する場合、次の C# コードを使用して、開始できます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-183">Assuming you defined the toast in an XML file (here named "content.xml"), you can use this C# code to start it:</span></span>

```CSharp
string xmlText = File.ReadAllText("content.xml");
XmlDocument xmlContent = new XmlDocument();
xmlContent.LoadXml(xmlText);
```

<span data-ttu-id="e04e0-184">これで次のコードを使ってトーストを作成して送信できます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-184">You can then use this code to create and send the toast:</span></span>

```CSharp
ToastNotification notification = new ToastNotification(xmlContent);
ToastNotificationManager.CreateToastNotifier().Show(notification);
```

## <a name="falling-back-to-toast"></a><span data-ttu-id="e04e0-185">トーストにフォールバックする</span><span class="sxs-lookup"><span data-stu-id="e04e0-185">Falling back to toast</span></span>
<span data-ttu-id="e04e0-186">マイ連絡先の通知としてコーディングされた通知が、標準のトーストとして表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="e04e0-186">There are some cases when a notification coded as a My People notification will instead display as a regular toast.</span></span> <span data-ttu-id="e04e0-187">次の条件下では、マイ連絡先の通知はトーストにフォールバックします。</span><span class="sxs-lookup"><span data-stu-id="e04e0-187">A My People notification will fall back to toast under the following conditions:</span></span>

+ <span data-ttu-id="e04e0-188">通知の表示に失敗した</span><span class="sxs-lookup"><span data-stu-id="e04e0-188">The notification fails to display</span></span>
+ <span data-ttu-id="e04e0-189">受信者で、マイ連絡先の通知が有効化されていない</span><span class="sxs-lookup"><span data-stu-id="e04e0-189">My People notifications are not enabled by the recipient</span></span>
+ <span data-ttu-id="e04e0-190">送信者の連絡先が、受信者のタスク バーにピン留めされていない</span><span class="sxs-lookup"><span data-stu-id="e04e0-190">The sender’s contact is not pinned to the receiver’s taskbar</span></span>

<span data-ttu-id="e04e0-191">マイ連絡先の通知がトーストにフォールバックすると、2 番目のマイ連絡先固有のバインドは無視され、1 番目のバインドのみが使用されて、トーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e04e0-191">If a My People notification falls back to toast, the second My-People-specific binding is ignored, and only the first binding is used to display the toast.</span></span> <span data-ttu-id="e04e0-192">これは、前述のように、最初のトースト バインドでフォールバック ペイロードを指定する必要があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="e04e0-192">This means that, as stated before, a fallback payload must be provided in the first toast binding.</span></span>

## <a name="see-also"></a><span data-ttu-id="e04e0-193">関連項目</span><span class="sxs-lookup"><span data-stu-id="e04e0-193">See also</span></span>
+ [<span data-ttu-id="e04e0-194">マイ連絡先のサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="e04e0-194">Adding My People support</span></span>](my-people-support.md)
+ [<span data-ttu-id="e04e0-195">アダプティブ トースト通知</span><span class="sxs-lookup"><span data-stu-id="e04e0-195">Adaptive toast notifications</span></span>](../controls-and-patterns/tiles-and-notifications-adaptive-interactive-toasts.md)
+ [<span data-ttu-id="e04e0-196">ToastNotification クラス</span><span class="sxs-lookup"><span data-stu-id="e04e0-196">ToastNotification Class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.notifications.toastnotification)