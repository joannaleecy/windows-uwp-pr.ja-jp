---
title: マイ連絡先の共有
description: マイ連絡先の共有のサポートを追加する方法について説明します。
ms.date: 06/28/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91d88dc78fd02ae3f16e1d980aa207d1dd458417
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8707838"
---
# <a name="my-people-sharing"></a><span data-ttu-id="2d697-104">マイ連絡先の共有</span><span class="sxs-lookup"><span data-stu-id="2d697-104">My People sharing</span></span>

<span data-ttu-id="2d697-105">マイ連絡先の機能を使うと、ユーザーは連絡先をタスク バーにピン留めして、どのアプリケーションを使って接続している場合でも、Windows のどこからでも容易に連絡を取ることができます。</span><span class="sxs-lookup"><span data-stu-id="2d697-105">The My People feature allows users to pin contacts to their taskbar, enabling them to stay in touch easily from anywhere in Windows, no matter what application they are connected by.</span></span> <span data-ttu-id="2d697-106">ユーザーは、ファイルをエクスプローラーからピン留めされたマイ連絡先にドラッグして、ピン留めされた連絡先とコンテンツを共有できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="2d697-106">Now users can share content with their pinned contacts by dragging files from the File Explorer to their My People pin.</span></span> <span data-ttu-id="2d697-107">標準の共有チャーム経由で、Windows の連絡先ストアの任意の連絡先を共有できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="2d697-107">They can also share to any contacts in the Windows contact store via the standard share charm.</span></span> <span data-ttu-id="2d697-108">作成したアプリケーションをマイ連絡先の共有のターゲットとするための方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2d697-108">Keep reading to learn how to enable your application as a My People sharing target.</span></span>

![マイ連絡先の共有パネル](images/my-people-sharing.png)

## <a name="requirements"></a><span data-ttu-id="2d697-110">要件</span><span class="sxs-lookup"><span data-stu-id="2d697-110">Requirements</span></span>

+ <span data-ttu-id="2d697-111">Windows 10 と Microsoft Visual Studio 2017。</span><span class="sxs-lookup"><span data-stu-id="2d697-111">Windows 10 and Microsoft Visual Studio 2017.</span></span> <span data-ttu-id="2d697-112">インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d697-112">For installation details, see [Get set up with Visual Studio](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up).</span></span>
+ <span data-ttu-id="2d697-113">C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。</span><span class="sxs-lookup"><span data-stu-id="2d697-113">Basic knowledge of C# or a similar object-oriented programming language.</span></span> <span data-ttu-id="2d697-114">C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d697-114">To get started with C#, see [Create a "Hello, world" app](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal).</span></span>

## <a name="overview"></a><span data-ttu-id="2d697-115">概要</span><span class="sxs-lookup"><span data-stu-id="2d697-115">Overview</span></span>

<span data-ttu-id="2d697-116">アプリケーションをマイ連絡先の共有ターゲットとするためには、次の 3 つの手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-116">There are three steps you must take to enable your application as a My People sharing target:</span></span>

1. [<span data-ttu-id="2d697-117">アプリケーション マニフェストで shareTarget アクティブ化コントラクトのサポートを宣言します。</span><span class="sxs-lookup"><span data-stu-id="2d697-117">Declare support for the shareTarget activation contract in your application manifest.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#declaring-support-for-the-share-contract)
2. [<span data-ttu-id="2d697-118">ユーザーがアプリを使用して共有できる連絡先に注釈を付けます。</span><span class="sxs-lookup"><span data-stu-id="2d697-118">Annotate the contacts that the users can share to using your app.</span></span>](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#annotating-contacts)
3. <span data-ttu-id="2d697-119">アプリケーションの複数インスタンスの同時実行をサポートします。</span><span class="sxs-lookup"><span data-stu-id="2d697-119">Support multiple instances of the application running at the same time.</span></span>  <span data-ttu-id="2d697-120">ユーザーは、他のユーザーと共有するためにアプリケーションを使用しながら、アプリケーションの通常版を操作できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-120">Users must be able to interact with a full version of your application while also using it to share with others.</span></span> <span data-ttu-id="2d697-121">ユーザーは複数の共有ウィンドウで同時に使用できます。</span><span class="sxs-lookup"><span data-stu-id="2d697-121">They may use it in multiple share windows at once.</span></span> <span data-ttu-id="2d697-122">これをサポートするには、アプリケーションが複数のビューを同時に実行できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-122">To support this, your application needs to be able to run multiple views simultaneously.</span></span> <span data-ttu-id="2d697-123">これを行う方法については、「["アプリの複数のビューの表示](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d697-123">To learn how to do this, see the article ["show multiple views for an app"](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views).</span></span>

<span data-ttu-id="2d697-124">これを行うと、アプリケーションがマイ連絡先の共有ウィンドウで共有ターゲットに表示されます。これは次の 2 つの方法で起動できます。</span><span class="sxs-lookup"><span data-stu-id="2d697-124">When you’ve done this, your application will appear as a share target in the My People share window, which can be launched in two ways:</span></span>
1. <span data-ttu-id="2d697-125">共有チャームで連絡先を選択します。</span><span class="sxs-lookup"><span data-stu-id="2d697-125">A contact is chosen via the share charm.</span></span>
2. <span data-ttu-id="2d697-126">タスク バーにピン留めされた連絡先にファイルをドラッグ アンド ドロップします。</span><span class="sxs-lookup"><span data-stu-id="2d697-126">File(s) are dragged and dropped on a contact pinned to the taskbar.</span></span>

## <a name="declaring-support-for-the-share-contract"></a><span data-ttu-id="2d697-127">共有コントラクトのサポートを宣言する</span><span class="sxs-lookup"><span data-stu-id="2d697-127">Declaring support for the share contract</span></span>

<span data-ttu-id="2d697-128">アプリケーションでの共有ターゲットのサポートを宣言するには、まず Visual Studio でアプリケーションを開きます。</span><span class="sxs-lookup"><span data-stu-id="2d697-128">To declare support for your application as a share target, first open your application in Visual Studio.</span></span> <span data-ttu-id="2d697-129">**ソリューション エクスプローラー** で **Package.appxmanifest** を右クリックして、[**プログラムから開く**] を選択します。</span><span class="sxs-lookup"><span data-stu-id="2d697-129">From the **Solution Explorer**, right click **Package.appxmanifest** and select **Open With**.</span></span> <span data-ttu-id="2d697-130">メニューをから [**XML (テキスト) エディター**] を選び、**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="2d697-130">From the menu, select **XML (Text) Editor** and click **OK**.</span></span> <span data-ttu-id="2d697-131">マニフェストを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="2d697-131">Then, make the following changes to the manifest:</span></span>


**<span data-ttu-id="2d697-132">変更前</span><span class="sxs-lookup"><span data-stu-id="2d697-132">Before</span></span>**
```xml
<Applications>
    <Application Id="MyApp"
      Executable="$targetnametoken$.exe"
      EntryPoint="My.App">
    </Application>
</Applications>
```

**<span data-ttu-id="2d697-133">変更後</span><span class="sxs-lookup"><span data-stu-id="2d697-133">After</span></span>**

```xml
<Applications>
    <Application Id="MyApp"
      Executable="$targetnametoken$.exe"
      EntryPoint="My.App">
        <Extensions>
            <uap:Extension Category="windows.shareTarget">
                <uap:ShareTarget Description="Share with MyApp">
                    <uap:SupportedFileTypes>
                        <uap:SupportsAnyFileType/>
                    </uap:SupportedFileTypes>
                    <uap:DataFormat>Text</uap:DataFormat>
                    <uap:DataFormat>Bitmap</uap:DataFormat>
                    <uap:DataFormat>Html</uap:DataFormat>
                    <uap:DataFormat>StorageItems</uap:DataFormat>
                    <uap:DataFormat>URI</uap:DataFormat>
                </uap:ShareTarget>
            </uap:Extension>
         </Extensions>
    </Application>
</Applications>
```

<span data-ttu-id="2d697-134">このコードはすべてのファイルとデータの形式のサポートを追加しますが、サポートするファイルの種類やデータの形式を指定することを選ぶこともできます (詳しくは、「[ShareTarget クラスのドキュメント](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema/element-sharetarget)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="2d697-134">This code adds support for all files and data formats, but you can choose to specify what files types and data formats are supported (see [ShareTarget class documentation](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema/element-sharetarget) for more details).</span></span>

## <a name="annotating-contacts"></a><span data-ttu-id="2d697-135">連絡先に注釈を付ける</span><span class="sxs-lookup"><span data-stu-id="2d697-135">Annotating contacts</span></span>

<span data-ttu-id="2d697-136">マイ連絡先の共有ウィンドウでアプリケーションを連絡先の共有ターゲットとして表示するには、それを Windows 連絡先ストアに書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-136">To allow the My People share window to show your application as a share target for your contacts, you need to write them to the Windows contact store.</span></span> <span data-ttu-id="2d697-137">連絡先を書き込む方法については、「[連絡先カードの統合のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d697-137">To learn how to write contacts, see the [Contact Card Integration sample](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration).</span></span> 

<span data-ttu-id="2d697-138">連絡先を共有する場合にアプリケーションがマイ連絡先の共有ターゲットとして表示されるためには、連絡先に注釈を書き込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-138">For your application to appear as a My People share target when sharing to a contact, it must write an annotation to that contact.</span></span> <span data-ttu-id="2d697-139">注釈は、連絡先に関連付けられた、アプリケーションからのデータの一部です。</span><span class="sxs-lookup"><span data-stu-id="2d697-139">Annotations are pieces of data from your application that are associated with a contact.</span></span> <span data-ttu-id="2d697-140">注釈は、必要なビューに対応する、アクティブ化可能なクラスを、**ProviderProperties** メンバーに含む必要があります。また **Share** 操作のサポートを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2d697-140">The annotation must contain the activatable class corresponding to your desired view in its **ProviderProperties** member, and declare support for the **Share** operation.</span></span>

<span data-ttu-id="2d697-141">アプリが実行されている任意の時点で連絡先に注釈を付けることができますが、一般には、連絡先がWindows 連絡先ストアに追加されたらすぐに連絡先に注釈を付けるようにします。</span><span class="sxs-lookup"><span data-stu-id="2d697-141">You can annotate contacts at any point while your app is running, but generally you should annotate contacts as soon as they are added to the Windows contact store.</span></span>

```Csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    // Create a new contact annotation
    ContactAnnotation annotation = new ContactAnnotation();
    annotation.ContactId = myContact.Id;

    // Add appId and Share support to the annotation
    String appId = "MyApp_vqvv5s4y3scbg!App";
    annotation.ProviderProperties.Add("ContactShareAppID", appId);
    annotation.SupportedOperations = ContactAnnotationOperations::Share;

    // Save annotation to contact annotation list
    // Windows.ApplicationModel.Contacts.ContactAnnotationList 
    await contactAnnotationList.TrySaveAnnotationAsync(annotation);
}
```

<span data-ttu-id="2d697-142">“appId” はパッケージ ファミリ名の最後に ‘!’ と</span><span class="sxs-lookup"><span data-stu-id="2d697-142">The “appId” is the Package Family Name, followed by ‘!’</span></span> <span data-ttu-id="2d697-143">アクティブ化可能なクラス ID を付けたものです。</span><span class="sxs-lookup"><span data-stu-id="2d697-143">and the Activatable Class ID.</span></span> <span data-ttu-id="2d697-144">パッケージ ファミリ名を検索するには、 **Package.appxmanifest**既定のエディターを使用して開き、"Packaging"タブします。ここでは、"App"は、共有ターゲット ビューに対応するアクティブ化可能なクラスです。</span><span class="sxs-lookup"><span data-stu-id="2d697-144">To find your Package Family Name, open **Package.appxmanifest** using the default editor, and look in the “Packaging” tab. Here, “App” is the Activatable Class corresponding to the Share Target view.</span></span>

## <a name="running-as-a-my-people-share-target"></a><span data-ttu-id="2d697-145">マイ連絡先の共有ターゲットとして実行する</span><span class="sxs-lookup"><span data-stu-id="2d697-145">Running as a My People share target</span></span>

<span data-ttu-id="2d697-146">最後に、アプリを実行するには、共有ターゲットのアクティブ化を行うアプリのメイン クラスで [OnShareTargetActivated](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Application#Windows_UI_Xaml_Application_OnShareTargetActivated_Windows_ApplicationModel_Activation_ShareTargetActivatedEventArgs_) メソッドを上書きします。</span><span class="sxs-lookup"><span data-stu-id="2d697-146">Finally, to run the app, override the [OnShareTargetActivated](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Application#Windows_UI_Xaml_Application_OnShareTargetActivated_Windows_ApplicationModel_Activation_ShareTargetActivatedEventArgs_) method in your app’s main class to handle the share target activation.</span></span> <span data-ttu-id="2d697-147">[ShareTargetActivatedEventArgs.ShareOperation.Contacts](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.datatransfer.sharetarget.shareoperation#Properties) プロパティは、共有される連絡先を含むか、または (マイ連絡先の共有ではない) 標準の共有操作の場合には、空となります。</span><span class="sxs-lookup"><span data-stu-id="2d697-147">The [ShareTargetActivatedEventArgs.ShareOperation.Contacts](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.datatransfer.sharetarget.shareoperation#Properties) property will contain the contact(s) that are being shared to, or will be empty if this is a standard share operation (not a My People share).</span></span>

```Csharp
protected override void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    bool isPeopleShare = false;
    if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
    {
        // Make sure the current OS version includes the My People feature before
        // accessing the ShareOperation.Contacts property
        isPeopleShare = (args.ShareOperation.Contacts.Count > 0);
    }

    if (isPeopleShare)
    {
        // Show share UI for MyPeople contact(s)
    }
    else
    {
        // Show standard share UI for unpinned contacts
    }
}
```

## <a name="see-also"></a><span data-ttu-id="2d697-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="2d697-148">See also</span></span>
+ [<span data-ttu-id="2d697-149">マイ連絡先のサポートを追加する</span><span class="sxs-lookup"><span data-stu-id="2d697-149">Adding My People support</span></span>](my-people-support.md)
+ [<span data-ttu-id="2d697-150">ShareTarget クラス</span><span class="sxs-lookup"><span data-stu-id="2d697-150">ShareTarget Class</span></span>](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema/element-sharetarget)
+ [<span data-ttu-id="2d697-151">連絡先カードの統合のサンプル</span><span class="sxs-lookup"><span data-stu-id="2d697-151">Contact Card Integration sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)
