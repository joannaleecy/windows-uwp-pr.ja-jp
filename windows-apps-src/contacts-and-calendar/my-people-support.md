---
title: アプリケーションにマイ連絡先のサポートを追加する
description: アプリケーションにマイ連絡先のサポートを追加する方法と、連絡先をピン留めする方法およびピン留めを外す方法について説明します。
ms.date: 06/28/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 08acb2972469a84e6a37d7293ed00cae8df94dfb
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/04/2019
ms.locfileid: "9044446"
---
# <a name="adding-my-people-support-to-an-application"></a><span data-ttu-id="51b9b-104">アプリケーションにマイ連絡先のサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="51b9b-104">Adding My People support to an application</span></span>

<span data-ttu-id="51b9b-105">マイ連絡先の機能を使うと、ユーザーは、アプリケーションから直接、連絡先をタスク バーにピン留めすることができます。これにより、いろいろな方法で操作できる新しい連絡先オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-105">The My People feature allows users to pin contacts from an application directly to their taskbar, which creates a new contact object that they can interact with in several ways.</span></span> <span data-ttu-id="51b9b-106">この記事では、この機能のサポートを追加して、ユーザーがアプリから直接を連絡先をピン留めできるようにする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-106">This article shows how you can add support for this feature, allowing users to pin contacts directly from your app.</span></span> <span data-ttu-id="51b9b-107">連絡先をピン留めすると、[マイ連絡先の共有](my-people-sharing.md)や[通知](my-people-notifications.md)など、ユーザーは新しい種類の操作を利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-107">When contacts are pinned, new types of user interaction become available, such as [My People sharing](my-people-sharing.md) and [notifications](my-people-notifications.md).</span></span>

![マイ連絡先のチャット](images/my-people-chat.png)

## <a name="requirements"></a><span data-ttu-id="51b9b-109">要件</span><span class="sxs-lookup"><span data-stu-id="51b9b-109">Requirements</span></span>

+ <span data-ttu-id="51b9b-110">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="51b9b-110">Windows 10 and Microsoft Visual Studio 2017.</span></span> <span data-ttu-id="51b9b-111">インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51b9b-111">For installation details, see [Get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="51b9b-112">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="51b9b-112">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="51b9b-113">C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51b9b-113">To get started with C#, see [Create a "Hello, world" app](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="overview"></a><span data-ttu-id="51b9b-114">概要</span><span class="sxs-lookup"><span data-stu-id="51b9b-114">Overview</span></span>

<span data-ttu-id="51b9b-115">アプリケーションでマイ連絡先の機能を使えるようにするには、3 つの手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-115">There are three things you need to do to enable your application to use the My People feature:</span></span>

1. [<span data-ttu-id="51b9b-116">アプリケーション マニフェストで shareTarget アクティブ化コントラクトのサポートを宣言します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-116">Declare support for the shareTarget activation contract in your application manifest.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#declaring-support-for-the-share-contract)
2. [<span data-ttu-id="51b9b-117">ユーザーがアプリを使用して共有できる連絡先に注釈を付けます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-117">Annotate the contacts that the users can share to using your app.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#annotating-contacts)
3.  <span data-ttu-id="51b9b-118">アプリケーションの複数インスタンスの同時実行をサポートします。</span><span class="sxs-lookup"><span data-stu-id="51b9b-118">Support multiple instances of your application running at the same time.</span></span> <span data-ttu-id="51b9b-119">ユーザーは、連絡先パネルでアプリケーションを使いながら、アプリケーションの通常版を操作できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-119">Users must be able to interact with a full version of your application while using it in a contact panel.</span></span>  <span data-ttu-id="51b9b-120">ユーザーは複数の連絡先パネルを同時に使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-120">They may even use it in multiple contact panels at once.</span></span>  <span data-ttu-id="51b9b-121">これをサポートするには、アプリケーションが複数のビューを同時に実行できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-121">To support this, your application needs to be able to run multiple views simultaneously.</span></span> <span data-ttu-id="51b9b-122">これを行う方法については、「["アプリの複数のビューの表示](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51b9b-122">To learn how to do this, see the article ["show multiple views for an app"](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views).</span></span>

<span data-ttu-id="51b9b-123">これを行うと、アプリケーションは、注釈付きの連絡先のための、連絡先のパネルに表示されます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-123">When you’ve done this, your application will appear in the contact panel for annotated contacts.</span></span>

## <a name="declaring-support-for-the-contract"></a><span data-ttu-id="51b9b-124">コントラクトのサポートを宣言する</span><span class="sxs-lookup"><span data-stu-id="51b9b-124">Declaring support for the contract</span></span>

<span data-ttu-id="51b9b-125">マイ連絡先のコントラクトのサポートを宣言するには、Visual Studio でアプリケーションを開きます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-125">To declare support for the My People contract, open your application in Visual Studio.</span></span> <span data-ttu-id="51b9b-126">**ソリューション エクスプローラー** で **Package.appxmanifest** を右クリックして、[**プログラムから開く**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-126">From the **Solution Explorer**, right click **Package.appxmanifest** and select **Open With**.</span></span> <span data-ttu-id="51b9b-127">メニューをから [**XML (テキスト) エディター**] を選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="51b9b-127">From the menu, select **XML (Text) Editor)** and click **OK**.</span></span> <span data-ttu-id="51b9b-128">マニフェストを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-128">Make the following changes to the manifest:</span></span>

**<span data-ttu-id="51b9b-129">クリック前</span><span class="sxs-lookup"><span data-stu-id="51b9b-129">Before</span></span>**

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

**<span data-ttu-id="51b9b-130">クリック後</span><span class="sxs-lookup"><span data-stu-id="51b9b-130">After</span></span>**

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

<span data-ttu-id="51b9b-131">この追加により、アプリケーションは **windows.ContactPanel** コントラクトから起動できるようになります。これにより、連絡先パネルで操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-131">With this addition, your application can now be launched through the **windows.ContactPanel** contract, which allows you to interact with contact panels.</span></span>

## <a name="annotating-contacts"></a><span data-ttu-id="51b9b-132">連絡先に注釈を付ける</span><span class="sxs-lookup"><span data-stu-id="51b9b-132">Annotating contacts</span></span>

<span data-ttu-id="51b9b-133">アプリケーションの連絡先がタスク バーからマイ連絡先ウィンドウに表示されるようにするには、連絡先を Windows 連絡先ストアに書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-133">To allow contacts from your application to appear in the taskbar via the My People pane, you need to write them to the Windows contact store.</span></span>  <span data-ttu-id="51b9b-134">連絡先を書き込む方法については、「[連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="51b9b-134">To learn how to write contacts, see the [Contact Card sample](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration).</span></span>

<span data-ttu-id="51b9b-135">さらにアプリケーションは、各連絡先に注釈を書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-135">Your application must also write an annotation to each contact.</span></span> <span data-ttu-id="51b9b-136">注釈は、連絡先に関連付けられた、アプリケーションからのデータの一部です。</span><span class="sxs-lookup"><span data-stu-id="51b9b-136">Annotations are pieces of data from your application that are associated with a contact.</span></span> <span data-ttu-id="51b9b-137">注釈は、必要なビューに対応する、アクティブ化可能なクラスを、**ProviderProperties** メンバーに含む必要があります。また **ContactProfile** 操作のサポートを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-137">The annotation must contain the activatable class corresponding to your desired view in its **ProviderProperties** member, and declare support for the **ContactProfile** operation.</span></span>

<span data-ttu-id="51b9b-138">アプリが実行されている任意の時点で連絡先に注釈を付けることができますが、一般には、連絡先がWindows 連絡先ストアに追加されたらすぐに連絡先に注釈を付けるようにします。</span><span class="sxs-lookup"><span data-stu-id="51b9b-138">You can annotate contacts at any point while your app is running, but generally you should annotate contacts as soon as they are added to the Windows contact store.</span></span>

```Csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    // Create a new contact annotation
    ContactAnnotation annotation = new ContactAnnotation();
    annotation.ContactId = myContact.Id;

    // Add appId and contact panel support to the annotation
    String appId = "MyApp_vqvv5s4y3scbg!App";
    annotation.ProviderProperties.Add("ContactPanelAppID", appId);
    annotation.SupportedOperations = ContactAnnotationOperations.ContactProfile;

    // Save annotation to contact annotation list
    // Windows.ApplicationModel.Contacts.ContactAnnotationList 
    await contactAnnotationList.TrySaveAnnotationAsync(annotation));
}
```

<span data-ttu-id="51b9b-139">“appId” はパッケージ ファミリ名の最後に ‘!’ と</span><span class="sxs-lookup"><span data-stu-id="51b9b-139">The “appId” is the Package Family Name, followed by ‘!’</span></span> <span data-ttu-id="51b9b-140">アクティブ化可能なクラス ID を付けたものです。</span><span class="sxs-lookup"><span data-stu-id="51b9b-140">and the activatable class ID.</span></span> <span data-ttu-id="51b9b-141">パッケージ ファミリ名を見つけるには、既定のエディターを使って **Package.appxmanifest** を開き、"Packaging" タブを検索します。ここで、"App" は、アプリケーションのスタートアップ ビューに対応する、アクティブ化可能なクラスです。</span><span class="sxs-lookup"><span data-stu-id="51b9b-141">To find your Package Family Name, open **Package.appxmanifest** using the default editor, and look in the “Packaging” tab. Here, “App” is the activatable class corresponding to the application startup view.</span></span>

## <a name="allow-contacts-to-invite-new-potential-users"></a><span data-ttu-id="51b9b-142">連絡先が新しい潜在的なユーザーを招待できるようにする</span><span class="sxs-lookup"><span data-stu-id="51b9b-142">Allow contacts to invite new potential users</span></span>

<span data-ttu-id="51b9b-143">既定では、アプリケーションは、具体的に注釈を付けた連絡先の連絡先パネルのみに表示されます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-143">By default, your application will only appear in the contact panel for contacts that you have specifically annotated.</span></span>  <span data-ttu-id="51b9b-144">これはアプリから操作を行えない連絡先との混同を避けるためです。</span><span class="sxs-lookup"><span data-stu-id="51b9b-144">This is to avoid confusion with contacts that can’t be interacted with through your app.</span></span>  <span data-ttu-id="51b9b-145">アプリケーションが認識していない連絡先にもアプリケーションが表示されるようにする (たとえば、アカウントに連絡先を追加するようにユーザーを招待するためなど) には、マニフェストに以下を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-145">If you want your application to appear for contacts that your application doesn’t know about (to invite users to add that contact to their account, for instance), you can add the following to your manifest:</span></span>

**<span data-ttu-id="51b9b-146">変更前</span><span class="sxs-lookup"><span data-stu-id="51b9b-146">Before</span></span>**

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

**<span data-ttu-id="51b9b-147">変更後</span><span class="sxs-lookup"><span data-stu-id="51b9b-147">After</span></span>**

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

<span data-ttu-id="51b9b-148">この変更により、ユーザーがピン留めしたすべての連絡先で、利用可能なオプションとして、連絡先パネルにアプリケーションが表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-148">With this change, your application will appear as an available option in the contact panel for all contacts that the user has pinned.</span></span>  <span data-ttu-id="51b9b-149">連絡先パネル コントラクトを使用してアプリケーションがアクティブ化されている場合には、連絡先はアプリケーションが認識しているものであるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-149">When your application is activated using the contact panel contract, you should check to see if the contact is one your application knows about.</span></span>  <span data-ttu-id="51b9b-150">アプリケーションが認識していない連絡先では、アプリの新しいユーザー エクスペリエンスを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-150">If not, you should show your app’s new user experience.</span></span>

![マイ連絡先の連絡先パネル](images/my-people.png)

## <a name="support-for-email-apps"></a><span data-ttu-id="51b9b-152">メール アプリでのサポート</span><span class="sxs-lookup"><span data-stu-id="51b9b-152">Support for email apps</span></span>

<span data-ttu-id="51b9b-153">メール アプリを作成する場合、すべての連絡先に手動で注釈を付ける必要はありません。</span><span class="sxs-lookup"><span data-stu-id="51b9b-153">If you are writing an email app, you don’t need to annotate every contact manually.</span></span>  <span data-ttu-id="51b9b-154">連絡先ウィンドウおよび mailto: プロトコルのサポートを宣言すると、メール アドレスを持つユーザーで、アプリケーションが自動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-154">If you declare support for the contact pane and for the mailto: protocol, your application will automatically appear for users with an email address.</span></span>

## <a name="running-in-the-contact-panel"></a><span data-ttu-id="51b9b-155">連絡先パネルで実行する</span><span class="sxs-lookup"><span data-stu-id="51b9b-155">Running in the contact panel</span></span>

<span data-ttu-id="51b9b-156">ユーザーの一部またはすべての連絡先パネルにアプリケーションが表示されたので、連絡先パネル コントラクトのアクティブ化の処理を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-156">Now that your application appears in the contact panel for some or all users, you need to handle activation with the contact panel contract.</span></span>

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

<span data-ttu-id="51b9b-157">コントラクトを使ってアプリケーションがアクティブ化されると、[ContactPanelActivatedEventArgs オブジェクト](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.contactpanelactivatedeventargs)を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-157">When your application is activated with this contract, it will receive a [ContactPanelActivatedEventArgs object](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.contactpanelactivatedeventargs).</span></span>  <span data-ttu-id="51b9b-158">これには、アプリケーションが起動して操作する連絡先の ID と [ContactPanel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactpanel) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="51b9b-158">This contains the ID of the Contact that your application is trying to interact with on launch, and a [ContactPanel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactpanel) object.</span></span> <span data-ttu-id="51b9b-159">この ContactPanel オブジェクトへの参照を保持する必要があります。これを使ってパネルを操作できます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-159">You should keep a reference to this ContactPanel object, which will allow you to interact with the panel.</span></span>

<span data-ttu-id="51b9b-160">ContactPanel オブジェクトには 2 つのイベントがあります。アプリケーションはこのイベントをリッスンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-160">The ContactPanel object has two events your application should listen for:</span></span>
+ <span data-ttu-id="51b9b-161">**LaunchFullAppRequested** イベントは、フル アプリケーションが独自のウィンドウで起動するように要求する UI 要素をユーザーが呼び出したときに送信されます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-161">The **LaunchFullAppRequested** event is sent when the user has invoked the UI element that requests that your full application be launched in its own window.</span></span>  <span data-ttu-id="51b9b-162">アプリケーションは、それ自体を起動して、すべての必要なコンテキストを渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-162">Your application is responsible for launching itself, passing along all necessary context.</span></span>  <span data-ttu-id="51b9b-163">これは好みの方法を使って行うことができます (たとえば、プロトコル起動など)。</span><span class="sxs-lookup"><span data-stu-id="51b9b-163">You are free to do this however you’d like (for example, via protocol launch).</span></span>
+ <span data-ttu-id="51b9b-164">**Closing イベント**は、アプリケーションが閉じられようとするときに送信されます。これにより、コンテキストを保存することができます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-164">The **Closing event** is sent when your application is about to be closed, allowing you to save any context.</span></span>

<span data-ttu-id="51b9b-165">ContactPanel オブジェクトを使うと、連絡先パネル ヘッダーの背景色を設定することもできます (設定されない場合、既定はシステムのテーマです)。またプログラムを使って連絡先パネルを閉じることもできます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-165">The ContactPanel object also allows you to set the background color of the contact panel header (if not set, it will default to the system theme) and to programmatically close the contact panel.</span></span>

## <a name="supporting-notification-badging"></a><span data-ttu-id="51b9b-166">通知バッジをサポートする</span><span class="sxs-lookup"><span data-stu-id="51b9b-166">Supporting notification badging</span></span>

<span data-ttu-id="51b9b-167">ユーザーに関連する新しい通知がアプリから届いたときに、タスク バーにピン留めされた連絡先にバッジを表示する場合は、[トースト通知](https://docs.microsoft.com/en-us/windows/uwp/shell/tiles-and-notifications/adaptive-interactive-toasts)と表現力豊かな[マイ連絡先の通知](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-notifications)に **hint-people** パラメーターを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-167">If you want contacts pinned to the taskbar to be badged when new notifications arrive from your app that are related to that person, then you must include the **hint-people** parameter in your [toast notifications](https://docs.microsoft.com/en-us/windows/uwp/shell/tiles-and-notifications/adaptive-interactive-toasts) and expressive [My People notifications](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-notifications).</span></span>

![連絡先の通知でのバッジの表示](images/my-people-badging.png)

<span data-ttu-id="51b9b-169">連絡先にバッジを表示するには、トップ レベルのトースト ノードに hint-people パラメーターを含めて、送信連絡先を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-169">To badge a contact, the top-level toast node must include the hint-people parameter to indicate the sending or related contact.</span></span> <span data-ttu-id="51b9b-170">このパラメーターには次の値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-170">This parameter can have any of the following values:</span></span>
+ **<span data-ttu-id="51b9b-171">メール アドレス</span><span class="sxs-lookup"><span data-stu-id="51b9b-171">Email address</span></span>** 
    + <span data-ttu-id="51b9b-172">例:</span><span class="sxs-lookup"><span data-stu-id="51b9b-172">E.g.</span></span> <span data-ttu-id="51b9b-173">mailto:johndoe@mydomain.com</span><span class="sxs-lookup"><span data-stu-id="51b9b-173">mailto:johndoe@mydomain.com</span></span>
+ **<span data-ttu-id="51b9b-174">電話番号</span><span class="sxs-lookup"><span data-stu-id="51b9b-174">Telephone number</span></span>** 
    + <span data-ttu-id="51b9b-175">例:</span><span class="sxs-lookup"><span data-stu-id="51b9b-175">E.g.</span></span> <span data-ttu-id="51b9b-176">tel:888-888-8888</span><span class="sxs-lookup"><span data-stu-id="51b9b-176">tel:888-888-8888</span></span>
+ **<span data-ttu-id="51b9b-177">リモート ID</span><span class="sxs-lookup"><span data-stu-id="51b9b-177">Remote ID</span></span>** 
    + <span data-ttu-id="51b9b-178">例:</span><span class="sxs-lookup"><span data-stu-id="51b9b-178">E.g.</span></span> <span data-ttu-id="51b9b-179">remoteid:1234</span><span class="sxs-lookup"><span data-stu-id="51b9b-179">remoteid:1234</span></span>

<span data-ttu-id="51b9b-180">特定のユーザーに関連するトースト通知を識別する方法の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-180">Here is an example of how to identify a toast notification is related to a specific person:</span></span>
```XML
<toast hint-people="mailto:johndoe@mydomain.com">
    <visual lang="en-US">
        <binding template="ToastText01">
            <text>John Doe posted a comment.</text>
        </binding>
    </visual>
</toast>
```

> [!NOTE]
> <span data-ttu-id="51b9b-181">[ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) を使ったアプリで [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact.RemoteId) プロパティを使い、PC に保存されている連絡先とリモートに保存されている連絡先とを関連付ける場合、RemoteId プロパティの値は不変かつ一意であることが不可欠です。</span><span class="sxs-lookup"><span data-stu-id="51b9b-181">If your app uses the [ContactStore APIs](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactstore) and uses the [StoredContact.RemoteId](https://docs.microsoft.com/en-us/uwp/api/Windows.Phone.PersonalInformation.StoredContact.RemoteId) property to link contacts stored on the PC with contacts stored remotely, it is essential that the value for the RemoteId property is both stable and unique.</span></span> <span data-ttu-id="51b9b-182">つまり、リモート ID は、PC にある他の連絡先 (他のアプリが所有する連絡先も含む) のリモート ID と決して競合しないよう、常に同じユーザー アカウントを一意に識別し、固有のタグを保持している必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-182">This means that the remote ID must consistently identify a single user account and should contain a unique tag to guarantee that it does not conflict with the remote IDs of other contacts on the PC, including contacts that are owned by other apps.</span></span>
> <span data-ttu-id="51b9b-183">アプリで使われるリモート ID の不変性と一意性に確証がない場合、このトピックの中で後述する RemoteIdHelper クラスを使うと、システムに追加するすべてのリモート ID にあらかじめ一意のタグを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-183">If the remote IDs used by your app are not guaranteed to be stable and unique, you can use the RemoteIdHelper class shown later in this topic in order to add a unique tag to all of your remote IDs before you add them to the system.</span></span> <span data-ttu-id="51b9b-184">または、RemoteId プロパティを一切使わない代わりに、カスタムの拡張プロパティを作成し、そこに連絡先のリモート ID を格納する方法もあります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-184">Or you can choose to not use the RemoteId property at all and instead you create a custom extended property in which to store remote IDs for your contacts.</span></span>

## <a name="the-pinnedcontactmanager-class"></a><span data-ttu-id="51b9b-185">PinnedContactManager クラス</span><span class="sxs-lookup"><span data-stu-id="51b9b-185">The PinnedContactManager class</span></span>

<span data-ttu-id="51b9b-186">[PinnedContactManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager) は、タスク バーにピン留めされる連絡先を管理するために使用します。</span><span class="sxs-lookup"><span data-stu-id="51b9b-186">The [PinnedContactManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager) is used to manage which contacts are pinned to the taskbar.</span></span> <span data-ttu-id="51b9b-187">このクラスを使うと、連絡先をピン留めしたり、連絡先のピン留めを外したり、連絡先がピン留めされているかどうかを判別したり、アプリケーションが実行されているシステムで特定のサーフェスへのピン留めがサポートされているかどうかを判別したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-187">This class lets you pin and unpin contacts, determine whether a contact is pinned, and determine if pinning on a particular surface is supported by the system your application is currently running on.</span></span>

<span data-ttu-id="51b9b-188">**GetDefault** メソッドを使って PinnedContactManager オブジェクトを取得できます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-188">You can retrieve the PinnedContactManager object using the **GetDefault** method:</span></span>

```Csharp
PinnedContactManager pinnedContactManager = PinnedContactManager.GetDefault();
```

## <a name="pinning-and-unpinning-contacts"></a><span data-ttu-id="51b9b-189">連絡先をピン留めする、またはピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="51b9b-189">Pinning and unpinning contacts</span></span>
<span data-ttu-id="51b9b-190">作成した PinnedContactManager を使って、連絡先をピン留めしたり、ピン留めを外したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-190">You can now pin and unpin contacts using the PinnedContactManager you just created.</span></span> <span data-ttu-id="51b9b-191">**RequestPinContactAsync** および **RequestUnpinContactAsync** メソッドは、ユーザーに確認ダイアログを提供します。これらのメソッドは、アプリケーション シングルスレッド アパートメント (ASTA、または UI) から呼び出される必要があります。</span><span class="sxs-lookup"><span data-stu-id="51b9b-191">The **RequestPinContactAsync** and **RequestUnpinContactAsync** methods provide the user with confirmation dialogs, so they must be called from your Application Single-Threaded Apartment (ASTA, or UI) thread.</span></span>

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

<span data-ttu-id="51b9b-192">また、同時に複数の連絡先をピン留めすることもできます。</span><span class="sxs-lookup"><span data-stu-id="51b9b-192">You can also pin multiple contacts at the same time:</span></span>

```Csharp
async Task PinMultipleContacts(Contact[] contacts)
{
    await pinnedContactManager.RequestPinContactsAsync(
        contacts, PinnedContactSurface.Taskbar);
}
```

> [!Note]
> <span data-ttu-id="51b9b-193">現時点では、連絡先のピン留めを外すバッチ操作はありません。</span><span class="sxs-lookup"><span data-stu-id="51b9b-193">There is currently no batch operation for unpinning contacts.</span></span>

**<span data-ttu-id="51b9b-194">注:</span><span class="sxs-lookup"><span data-stu-id="51b9b-194">Note:</span></span>** 

## <a name="see-also"></a><span data-ttu-id="51b9b-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="51b9b-195">See also</span></span>
+ [<span data-ttu-id="51b9b-196">マイ連絡先の共有</span><span class="sxs-lookup"><span data-stu-id="51b9b-196">My People sharing</span></span>](my-people-sharing.md)
+ [<span data-ttu-id="51b9b-197">マイ連絡先の通知</span><span class="sxs-lookup"><span data-stu-id="51b9b-197">My People notificatons</span></span>](my-people-notifications.md)
+ [<span data-ttu-id="51b9b-198">アプリケーションへのマイ連絡先のサポートの追加に関する Channel 9 ビデオ</span><span class="sxs-lookup"><span data-stu-id="51b9b-198">Channel 9 video on adding My People support to an application</span></span>](https://channel9.msdn.com/Events/Build/2017/P4056)
+ [<span data-ttu-id="51b9b-199">マイ連絡先の統合のサンプル</span><span class="sxs-lookup"><span data-stu-id="51b9b-199">My People integration sample</span></span>](https://aka.ms/mypeoplebuild2017)
+ [<span data-ttu-id="51b9b-200">連絡先カードのサンプル</span><span class="sxs-lookup"><span data-stu-id="51b9b-200">Contact Card sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)
+ [<span data-ttu-id="51b9b-201">PinnedContactManager クラスのドキュメント</span><span class="sxs-lookup"><span data-stu-id="51b9b-201">PinnedContactManager class documentation</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager)
+ [<span data-ttu-id="51b9b-202">アプリを連絡先カードの操作に接続する</span><span class="sxs-lookup"><span data-stu-id="51b9b-202">Connect your app to actions on a contact card</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/integrating-with-contacts)
