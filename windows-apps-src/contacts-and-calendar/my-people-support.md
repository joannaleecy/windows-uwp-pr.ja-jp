---
title: "アプリケーションにマイ連絡先のサポートを追加する"
description: "アプリケーションにマイ連絡先のサポートを追加する方法と、連絡先をピン留めする方法およびピン留めを外す方法について説明します。"
author: mukin
ms.author: mukin
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 61f73fd2fc0d14d0d1d478d67763c9b0e252cd36
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
---
# <a name="adding-my-people-support-to-an-application"></a><span data-ttu-id="cded6-104">アプリケーションにマイ連絡先のサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="cded6-104">Adding My People support to an application</span></span>

> [!IMPORTANT]
> <span data-ttu-id="cded6-105">**プレリリース | Fall Creators Update が必要**: マイ連絡先 API を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-105">**PRERELEASE | Requires Fall Creators Update**: You must target [Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) and be running [Insider build 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) or higher to use the My People APIs.</span></span>

<span data-ttu-id="cded6-106">マイ連絡先の機能を使うと、ユーザーは、アプリケーションから直接、連絡先をタスク バーにピン留めすることができます。これにより、いろいろな方法で操作できる新しい連絡先オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="cded6-106">The My People feature allows users to pin contacts from an application directly to their taskbar, which creates a new contact object that they can interact with in several ways.</span></span> <span data-ttu-id="cded6-107">この記事では、この機能のサポートを追加して、ユーザーがアプリから直接を連絡先をピン留めできるようにする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="cded6-107">This article shows how you can add support for this feature, allowing users to pin contacts directly from your app.</span></span> <span data-ttu-id="cded6-108">連絡先をピン留めすると、[マイ連絡先の共有](my-people-sharing.md)や[通知](my-people-notifications.md)など、ユーザーは新しい種類の操作を利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="cded6-108">When contacts are pinned, new types of user interaction become available, such as [My People sharing](my-people-sharing.md) and [notifications](my-people-notifications.md).</span></span>

![マイ連絡先のチャット](images/my-people-chat.png)

## <a name="requirements"></a><span data-ttu-id="cded6-110">要件</span><span class="sxs-lookup"><span data-stu-id="cded6-110">Requirements</span></span>

+ <span data-ttu-id="cded6-111">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="cded6-111">Windows 10 and Microsoft Visual Studio 2017.</span></span> <span data-ttu-id="cded6-112">インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cded6-112">For installation details, see [Get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="cded6-113">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="cded6-113">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="cded6-114">C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cded6-114">To get started with C#, see [Create a "Hello, world" app](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="overview"></a><span data-ttu-id="cded6-115">概要</span><span class="sxs-lookup"><span data-stu-id="cded6-115">Overview</span></span>

<span data-ttu-id="cded6-116">アプリケーションでマイ連絡先の機能を使えるようにするには、3 つの手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-116">There are three things you need to do to enable your application to use the My People feature:</span></span>

1. [<span data-ttu-id="cded6-117">アプリケーション マニフェストで shareTarget アクティブ化コントラクトのサポートを宣言します。</span><span class="sxs-lookup"><span data-stu-id="cded6-117">Declare support for the shareTarget activation contract in your application manifest.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#declaring-support-for-the-share-contract)
2. [<span data-ttu-id="cded6-118">ユーザーがアプリを使用して共有できる連絡先に注釈を付けます。</span><span class="sxs-lookup"><span data-stu-id="cded6-118">Annotate the contacts that the users can share to using your app.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#annotating-contacts)
3.  <span data-ttu-id="cded6-119">アプリケーションの複数インスタンスの同時実行をサポートします。</span><span class="sxs-lookup"><span data-stu-id="cded6-119">Support multiple instances of your application running at the same time.</span></span> <span data-ttu-id="cded6-120">ユーザーは、連絡先パネルでアプリケーションを使いながら、アプリケーションの通常版を操作できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-120">Users must be able to interact with a full version of your application while using it in a contact panel.</span></span>  <span data-ttu-id="cded6-121">ユーザーは複数の連絡先パネルを同時に使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="cded6-121">They may even use it in multiple contact panels at once.</span></span>  <span data-ttu-id="cded6-122">これをサポートするには、アプリケーションが複数のビューを同時に実行できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-122">To support this, your application needs to be able to run multiple views simultaneously.</span></span> <span data-ttu-id="cded6-123">これを行う方法については、「["アプリの複数のビューの表示](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cded6-123">To learn how to do this, see the article ["show multiple views for an app"](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views).</span></span>

<span data-ttu-id="cded6-124">これを行うと、アプリケーションは、注釈付きの連絡先のための、連絡先のパネルに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cded6-124">When you’ve done this, your application will appear in the contact panel for annotated contacts.</span></span>

## <a name="declaring-support-for-the-contract"></a><span data-ttu-id="cded6-125">コントラクトのサポートを宣言する</span><span class="sxs-lookup"><span data-stu-id="cded6-125">Declaring support for the contract</span></span>

<span data-ttu-id="cded6-126">マイ連絡先のコントラクトのサポートを宣言するには、Visual Studio でアプリケーションを開きます。</span><span class="sxs-lookup"><span data-stu-id="cded6-126">To declare support for the My People contract, open your application in Visual Studio.</span></span> <span data-ttu-id="cded6-127">**ソリューション エクスプローラー** で **Package.appxmanifest** を右クリックして、[**プログラムから開く**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="cded6-127">From the **Solution Explorer**, right click **Package.appxmanifest** and select **Open With**.</span></span> <span data-ttu-id="cded6-128">メニューをから [**XML (テキスト) エディター**] を選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="cded6-128">From the menu, select **XML (Text) Editor)** and click **OK**.</span></span> <span data-ttu-id="cded6-129">マニフェストを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="cded6-129">Make the following changes to the manifest:</span></span>

**<span data-ttu-id="cded6-130">変更前</span><span class="sxs-lookup"><span data-stu-id="cded6-130">Before</span></span>**

```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10">

    <Applications>
        <Application Id="MyApp"
          Executable="$targetnametoken$.exe"
          EntryPoint="My.App">
        </Application>
    </Applications>

```

**<span data-ttu-id="cded6-131">変更後</span><span class="sxs-lookup"><span data-stu-id="cded6-131">After</span></span>**

```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4">

    <Applications>
        <Application Id="MyApp"
          Executable="$targetnametoken$.exe"
          EntryPoint="My.App">
          <Extensions>
            <uap4:Extension Category="windows.contactPanel" />
          </Extensions>
        </Application>
    </Applications>

```

<span data-ttu-id="cded6-132">この追加により、アプリケーションは **windows.ContactPanel** コントラクトから起動できるようになります。これにより、連絡先パネルで操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="cded6-132">With this addition, your application can now be launched through the **windows.ContactPanel** contract, which allows you to interact with contact panels.</span></span>

## <a name="annotating-contacts"></a><span data-ttu-id="cded6-133">連絡先に注釈を付ける</span><span class="sxs-lookup"><span data-stu-id="cded6-133">Annotating contacts</span></span>

<span data-ttu-id="cded6-134">アプリケーションの連絡先がタスク バーからマイ連絡先ウィンドウに表示されるようにするには、連絡先を Windows 連絡先ストアに書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-134">To allow contacts from your application to appear in the taskbar via the My People pane, you need to write them to the Windows contact store.</span></span>  <span data-ttu-id="cded6-135">連絡先を書き込む方法については、「[連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cded6-135">To learn how to write contacts, see the [Contact Card sample](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration).</span></span>

<span data-ttu-id="cded6-136">さらにアプリケーションは、各連絡先に注釈を書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-136">Your application must also write an annotation to each contact.</span></span> <span data-ttu-id="cded6-137">注釈は、連絡先に関連付けられた、アプリケーションからのデータの一部です。</span><span class="sxs-lookup"><span data-stu-id="cded6-137">Annotations are pieces of data from your application that are associated with a contact.</span></span> <span data-ttu-id="cded6-138">注釈は、必要なビューに対応する、アクティブ化可能なクラスを、**ProviderProperties** メンバーに含む必要があります。また **ContactProfile** 操作のサポートを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-138">The annotation must contain the activatable class corresponding to your desired view in its **ProviderProperties** member, and declare support for the **ContactProfile** operation.</span></span>

<span data-ttu-id="cded6-139">アプリが実行されている任意の時点で連絡先に注釈を付けることができますが、一般には、連絡先がWindows 連絡先ストアに追加されたらすぐに連絡先に注釈を付けるようにします。</span><span class="sxs-lookup"><span data-stu-id="cded6-139">You can annotate contacts at any point while your app is running, but generally you should annotate contacts as soon as they are added to the Windows contact store.</span></span>

```Csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    // Create a new contact annotation
    ContactAnnotation annotation = new ContactAnnotation();
    annotation.ContactId = myContact.Id;

    // Add appId and contact panel support to the annotation
    String appId = "MyApp_vqvv5s4y3scbg!App";
    annotation.ProviderProperties.Add("ContactPanelAppID", appId);
    annotation.SupportedOperations = ContactAnnotationOperations::ContactProfile;

    // Save annotation to contact annotation list
    // Windows.ApplicationModel.Contacts.ContactAnnotationList 
    await contactAnnotationList.TrySaveAnnotationAsync(annotation));
}
```

<span data-ttu-id="cded6-140">“appId” はパッケージ ファミリ名の最後に ‘!’ と</span><span class="sxs-lookup"><span data-stu-id="cded6-140">The “appId” is the Package Family Name, followed by ‘!’</span></span> <span data-ttu-id="cded6-141">アクティブ化可能なクラス ID を付けたものです。</span><span class="sxs-lookup"><span data-stu-id="cded6-141">and the activatable class ID.</span></span> <span data-ttu-id="cded6-142">パッケージ ファミリー名を見つけるには、既定のエディターを使って **Package.appxmanifest** を開き、“Packaging” タブを検索します。</span><span class="sxs-lookup"><span data-stu-id="cded6-142">To find your Package Family Name, open **Package.appxmanifest** using the default editor, and look in the “Packaging” tab.</span></span> <span data-ttu-id="cded6-143">ここで、"App"は、アプリケーションのスタートアップ ビューに対応する、アクティブ化可能なクラスです。</span><span class="sxs-lookup"><span data-stu-id="cded6-143">Here, “App” is the activatable class corresponding to the application startup view.</span></span>

## <a name="allow-contacts-to-invite-new-potential-users"></a><span data-ttu-id="cded6-144">連絡先が新しい潜在的なユーザーを招待できるようにする</span><span class="sxs-lookup"><span data-stu-id="cded6-144">Allow contacts to invite new potential users</span></span>

<span data-ttu-id="cded6-145">既定では、アプリケーションは、具体的に注釈を付けた連絡先の連絡先パネルのみに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cded6-145">By default, your application will only appear in the contact panel for contacts that you have specifically annotated.</span></span>  <span data-ttu-id="cded6-146">これはアプリから操作を行えない連絡先との混同を避けるためです。</span><span class="sxs-lookup"><span data-stu-id="cded6-146">This is to avoid confusion with contacts that can’t be interacted with through your app.</span></span>  <span data-ttu-id="cded6-147">アプリケーションが認識していない連絡先にもアプリケーションが表示されるようにする (たとえば、アカウントに連絡先を追加するようにユーザーを招待するためなど) には、マニフェストに以下を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="cded6-147">If you want your application to appear for contacts that your application doesn’t know about (to invite users to add that contact to their account, for instance), you can add the following to your manifest:</span></span>

**<span data-ttu-id="cded6-148">変更前</span><span class="sxs-lookup"><span data-stu-id="cded6-148">Before</span></span>**

```Csharp
<Applications>
    <Application Id="MyApp"
      Executable="$targetnametoken$.exe"
      EntryPoint="My.App">
      <Extensions>
        <uap4:Extension Category="windows.contactPanel" />
      </Extensions>
    </Application>
</Applications>
```

**<span data-ttu-id="cded6-149">変更後</span><span class="sxs-lookup"><span data-stu-id="cded6-149">After</span></span>**

```Csharp
<Applications>
    <Application Id="MyApp"
      Executable="$targetnametoken$.exe"
      EntryPoint="My.App">
      <Extensions>
        <uap4:Extension Category="windows.contactPanel">
            <uap4:ContactPanel SupportsUnknownContacts="true" />
        </uap4:Extension>
      </Extensions>
    </Application>
</Applications>
```

<span data-ttu-id="cded6-150">この変更により、ユーザーがピン留めしたすべての連絡先で、利用可能なオプションとして、連絡先パネルにアプリケーションが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="cded6-150">With this change, your application will appear as an available option in the contact panel for all contacts that the user has pinned.</span></span>  <span data-ttu-id="cded6-151">連絡先パネル コントラクトを使用してアプリケーションがアクティブ化されている場合には、連絡先はアプリケーションが認識しているものであるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-151">When your application is activated using the contact panel contract, you should check to see if the contact is one your application knows about.</span></span>  <span data-ttu-id="cded6-152">アプリケーションが認識していない連絡先では、アプリの新しいユーザー エクスペリエンスを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-152">If not, you should show your app’s new user experience.</span></span>

![マイ連絡先の連絡先パネル](images/my-people.png)

## <a name="support-for-email-apps"></a><span data-ttu-id="cded6-154">メール アプリでのサポート</span><span class="sxs-lookup"><span data-stu-id="cded6-154">Support for email apps</span></span>

<span data-ttu-id="cded6-155">メール アプリを作成する場合、すべての連絡先に手動で注釈を付ける必要はありません。</span><span class="sxs-lookup"><span data-stu-id="cded6-155">If you are writing an email app, you don’t need to annotate every contact manually.</span></span>  <span data-ttu-id="cded6-156">連絡先ウィンドウおよび mailto: プロトコルのサポートを宣言すると、メール アドレスを持つユーザーで、アプリケーションが自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cded6-156">If you declare support for the contact pane and for the mailto: protocol, your application will automatically appear for users with an email address.</span></span>

## <a name="running-in-the-contact-panel"></a><span data-ttu-id="cded6-157">連絡先パネルで実行する</span><span class="sxs-lookup"><span data-stu-id="cded6-157">Running in the contact panel</span></span>

<span data-ttu-id="cded6-158">ユーザーの一部またはすべての連絡先パネルにアプリケーションが表示されたので、連絡先パネル コントラクトのアクティブ化の処理を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-158">Now that your application appears in the contact panel for some or all users, you need to handle activation with the contact panel contract.</span></span>

```Csharp
override protected void OnActivated(IActivatedEventArgs e)
{
    if (e.Kind == ActivationKind.ContactPanel)
    {
        // Create a Frame to act as the navigation context and navigate to the first page
        var rootFrame = new Frame();

        // Place the frame in the current Window
        Window.Current.Content = rootFrame;

        // Navigate to the page that shows the Contact UI.
        rootFrame.Navigate(typeof(ContactPage), e);

        // Ensure the current window is active
        Window.Current.Activate();
    }
}
```

<span data-ttu-id="cded6-159">コントラクトを使ってアプリケーションがアクティブ化されると、[ContactPanelActivatedEventArgs オブジェクト](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.contactpanelactivatedeventargs)を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="cded6-159">When your application is activated with this contract, it will receive a [ContactPanelActivatedEventArgs object](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.contactpanelactivatedeventargs).</span></span>  <span data-ttu-id="cded6-160">これには、アプリケーションが起動して操作する連絡先の ID と [ContactPanel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactpanel) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="cded6-160">This contains the ID of the Contact that your application is trying to interact with on launch, and a [ContactPanel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactpanel) object.</span></span> <span data-ttu-id="cded6-161">この ContactPanel オブジェクトへの参照を保持する必要があります。これを使ってパネルを操作できます。</span><span class="sxs-lookup"><span data-stu-id="cded6-161">You should keep a reference to this ContactPanel object, which will allow you to interact with the panel.</span></span>

<span data-ttu-id="cded6-162">ContactPanel オブジェクトには 2 つのイベントがあります。アプリケーションはこのイベントをリッスンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-162">The ContactPanel object has two events your application should listen for:</span></span>
+ <span data-ttu-id="cded6-163">**LaunchFullAppRequested** イベントは、フル アプリケーションが独自のウィンドウで起動するように要求する UI 要素をユーザーが呼び出したときに送信されます。</span><span class="sxs-lookup"><span data-stu-id="cded6-163">The **LaunchFullAppRequested** event is sent when the user has invoked the UI element that requests that your full application be launched in its own window.</span></span>  <span data-ttu-id="cded6-164">アプリケーションは、それ自体を起動して、すべての必要なコンテキストを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-164">Your application is responsible for launching itself, passing along all necessary context.</span></span>  <span data-ttu-id="cded6-165">これは好みの方法を使って行うことができます (たとえば、プロトコル起動など)。</span><span class="sxs-lookup"><span data-stu-id="cded6-165">You are free to do this however you’d like (for example, via protocol launch).</span></span>
+ <span data-ttu-id="cded6-166">**Closing イベント**は、アプリケーションが閉じられようとするときに送信されます。これにより、コンテキストを保存することができます。</span><span class="sxs-lookup"><span data-stu-id="cded6-166">The **Closing event** is sent when your application is about to be closed, allowing you to save any context.</span></span>

<span data-ttu-id="cded6-167">ContactPanel オブジェクトを使うと、連絡先パネル ヘッダーの背景色を設定することもできます (設定されない場合、既定はシステムのテーマです)。またプログラムを使って連絡先パネルを閉じることもできます。</span><span class="sxs-lookup"><span data-stu-id="cded6-167">The ContactPanel object also allows you to set the background color of the contact panel header (if not set, it will default to the system theme) and to programmatically close the contact panel.</span></span>



## <a name="the-pinnedcontactmanager-class"></a><span data-ttu-id="cded6-168">PinnedContactManager クラス</span><span class="sxs-lookup"><span data-stu-id="cded6-168">The PinnedContactManager class</span></span>

<span data-ttu-id="cded6-169">[PinnedContactManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager) は、タスク バーにピン留めされる連絡先を管理するために使用します。</span><span class="sxs-lookup"><span data-stu-id="cded6-169">The [PinnedContactManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager) is used to manage which contacts are pinned to the taskbar.</span></span> <span data-ttu-id="cded6-170">このクラスを使うと、連絡先をピン留めしたり、連絡先のピン留めを外したり、連絡先がピン留めされているかどうかを判別したり、アプリケーションが実行されているシステムで特定のサーフェスへのピン留めがサポートされているかどうかを判別したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="cded6-170">This class lets you pin and unpin contacts, determine whether a contact is pinned, and determine if pinning on a particular surface is supported by the system your application is currently running on.</span></span>

<span data-ttu-id="cded6-171">**GetDefault** メソッドを使って PinnedContactManager オブジェクトを取得できます。</span><span class="sxs-lookup"><span data-stu-id="cded6-171">You can retrieve the PinnedContactManager object using the **GetDefault** method:</span></span>

```Csharp
PinnedContactManager pinnedContactManager = PinnedContactManager.GetDefault();
```

## <a name="pinning-and-unpinning-contacts"></a><span data-ttu-id="cded6-172">連絡先をピン留めする、またはピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="cded6-172">Pinning and unpinning contacts</span></span>
<span data-ttu-id="cded6-173">作成した PinnedContactManager を使って、連絡先をピン留めしたり、ピン留めを外したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="cded6-173">You can now pin and unpin contacts using the PinnedContactManager you just created.</span></span> <span data-ttu-id="cded6-174">**RequestPinContactAsync** および **RequestUnpinContactAsync** メソッドは、ユーザーに確認ダイアログを提供します。これらのメソッドは、アプリケーション シングルスレッド アパートメント (ASTA、または UI) から呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="cded6-174">The **RequestPinContactAsync** and **RequestUnpinContactAsync** methods provide the user with confirmation dialogs, so they must be called from your Application Single-Threaded Apartment (ASTA, or UI) thread.</span></span>

```Csharp
async void PinContact (Contact contact)
{
    await pinnedContactManager.RequestPinContactAsync(contact,
                                                      PinnedContactSurface.Taskbar);
}

async void UnpinContact (Contact contact)
{
    await pinnedContactManager.RequestUnpinContactAsync(contact,
                                                        PinnedContactSurface.Taskbar);
}
```

<span data-ttu-id="cded6-175">また、同時に複数の連絡先をピン留めすることもできます。</span><span class="sxs-lookup"><span data-stu-id="cded6-175">You can also pin multiple contacts at the same time:</span></span>

```Csharp
async Task PinMultipleContacts(Contact[] contacts)
{
    await pinnedContactManager.RequestPinContactsAsync(
        contacts, PinnedContactSurface.Taskbar);
}
```

> [!Note]
> <span data-ttu-id="cded6-176">現時点では、連絡先のピン留めを外すバッチ操作はありません。</span><span class="sxs-lookup"><span data-stu-id="cded6-176">There is currently no batch operation for unpinning contacts.</span></span>

**<span data-ttu-id="cded6-177">注:</span><span class="sxs-lookup"><span data-stu-id="cded6-177">Note:</span></span>** 

## <a name="see-also"></a><span data-ttu-id="cded6-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="cded6-178">See also</span></span>
+ [<span data-ttu-id="cded6-179">マイ連絡先の共有</span><span class="sxs-lookup"><span data-stu-id="cded6-179">My People sharing</span></span>](my-people-sharing.md)
+ [<span data-ttu-id="cded6-180">マイ連絡先の通知</span><span class="sxs-lookup"><span data-stu-id="cded6-180">My People notificatons</span></span>](my-people-notifications.md)
+ [<span data-ttu-id="cded6-181">連絡先カードのサンプル</span><span class="sxs-lookup"><span data-stu-id="cded6-181">Contact Card sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)
+ [<span data-ttu-id="cded6-182">PinnedContactManager クラスのドキュメント</span><span class="sxs-lookup"><span data-stu-id="cded6-182">PinnedContactManager class documentation</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager)
