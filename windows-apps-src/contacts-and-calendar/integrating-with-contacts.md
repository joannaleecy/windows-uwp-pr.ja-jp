---
author: normesta
description: 連絡先カードの操作の横にアプリを追加する方法を説明する
MSHAttr: PreferredLib:/library/windows/apps
title: アプリを連絡先カードの操作に接続する
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 連絡先, 連絡先カード, 注釈
ms.assetid: 0edabd9c-ecfb-4525-bc38-53f219d744ff
ms.localizationpriority: medium
ms.openlocfilehash: eb1c01a4fe370f899da185dc39b7d3abe6a1904e
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6654954"
---
# <a name="connect-your-app-to-actions-on-a-contact-card"></a><span data-ttu-id="b50b9-104">アプリを連絡先カードの操作に接続する</span><span class="sxs-lookup"><span data-stu-id="b50b9-104">Connect your app to actions on a contact card</span></span>

<span data-ttu-id="b50b9-105">アプリは、連絡先カードまたはミニ連絡先カードの操作の横に表示できます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-105">Your app can appear next to actions on a contact card or mini contact card.</span></span> <span data-ttu-id="b50b9-106">ユーザーは、プロファイル ページを開く、通話を行う、メッセージを送信するなど、操作を実行するアプリを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-106">Users can choose your app to perform an action such as open a profile page, place a call, or send a message.</span></span>

![連絡先カードとミニ連絡先カード](images/all-contact-cards.png)

<span data-ttu-id="b50b9-108">最初に、既存の連絡先を検索するか、新しい連絡先を作成します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-108">To get started, find existing contacts or create new ones.</span></span> <span data-ttu-id="b50b9-109">次に、*注釈*といくつかのパッケージ マニフェスト エントリを作成して、アプリがサポートする操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-109">Next, create an *annotation* and a few package manifest entries to describe which actions your app supports.</span></span> <span data-ttu-id="b50b9-110">その後、操作を実行するコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-110">Then, write code that perform the actions.</span></span>

<span data-ttu-id="b50b9-111">完全なサンプルについては、[連絡先カードの統合のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b50b9-111">For a more complete sample, see [Contact Card Integration Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration).</span></span>

## <a name="find-or-create-a-contact"></a><span data-ttu-id="b50b9-112">連絡先を検索または作成する</span><span class="sxs-lookup"><span data-stu-id="b50b9-112">Find or create a contact</span></span>

<span data-ttu-id="b50b9-113">他のユーザーとつながるのをサポートするアプリの場合、Windows で連絡先を検索してから注釈を付けます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-113">If your app helps people connect with others, search Windows for contacts and then annotate them.</span></span> <span data-ttu-id="b50b9-114">連絡先を管理するアプリの場合、連絡先を Windows 連絡先リストに追加してから、注釈を付けることができます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-114">If your app manages contacts, you can add them to a Windows contact list and then annotate them.</span></span>

### <a name="find-a-contact"></a><span data-ttu-id="b50b9-115">連絡先を検索する</span><span class="sxs-lookup"><span data-stu-id="b50b9-115">Find a contact</span></span>

<span data-ttu-id="b50b9-116">連絡先は、名前、メール アドレス、または電話番号を使って検索します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-116">Find contacts by using a name, email address, or phone number.</span></span>

```cs
ContactStore contactStore = await ContactManager.RequestStoreAsync();

IReadOnlyList<Contact> contacts = null;

contacts = await contactStore.FindContactsAsync(emailAddress);

Contact contact = contacts[0];
```

### <a name="create-a-contact"></a><span data-ttu-id="b50b9-117">連絡先を作成する</span><span class="sxs-lookup"><span data-stu-id="b50b9-117">Create a contact</span></span>

<span data-ttu-id="b50b9-118">アドレス帳のようなアプリの場合、連絡先を作成してから連絡先一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-118">If your app is more like an address book, create contacts and then add them to a contact list.</span></span>

```cs
Contact contact = new Contact();
contact.FirstName = "TestContact";

ContactEmail email = new ContactEmail();
email.Address = "TestContact@contoso.com";
email.Kind = ContactEmailKind.Other;
contact.Emails.Add(email);

ContactPhone phone = new ContactPhone();
phone.Number = "4255550101";
phone.Kind = ContactPhoneKind.Mobile;
contact.Phones.Add(phone);

ContactStore store = await
    ContactManager.RequestStoreAsync(ContactStoreAccessType.AppContactsReadWrite);

ContactList contactList;

IReadOnlyList<ContactList> contactLists = await store.FindContactListsAsync();

if (0 == contactLists.Count)
    contactList = await store.CreateContactListAsync("TestContactList");
else
    contactList = contactLists[0];

await contactList.SaveContactAsync(contact);

```

## <a name="tag-each-contact-with-an-annotation"></a><span data-ttu-id="b50b9-119">注釈を使って各連絡先にタグを付ける</span><span class="sxs-lookup"><span data-stu-id="b50b9-119">Tag each contact with an annotation</span></span>

<span data-ttu-id="b50b9-120">アプリで実行できる操作 (例: ビデオ通話やメッセージング) の一覧を使って各連絡先にタグを付けます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-120">Tag each contact with a list of actions (operations) that your app can perform (for example: video calls and messaging).</span></span>

<span data-ttu-id="b50b9-121">その後、連絡先の ID を、アプリがそのユーザーを識別するために内部で使っている ID に関連付けます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-121">Then, associate the ID of a contact to an ID that your app uses internally to identify that user.</span></span>

```cs
ContactAnnotationStore annotationStore = await
   ContactManager.RequestAnnotationStoreAsync(ContactAnnotationStoreAccessType.AppAnnotationsReadWrite);

ContactAnnotationList annotationList;

IReadOnlyList<ContactAnnotationList> annotationLists = await annotationStore.FindAnnotationListsAsync();
if (0 == annotationLists.Count)
    annotationList = await annotationStore.CreateAnnotationListAsync();
else
    annotationList = annotationLists[0];

ContactAnnotation annotation = new ContactAnnotation();
annotation.ContactId = contact.Id;
annotation.RemoteId = "user22";

annotation.SupportedOperations = ContactAnnotationOperations.Message |
  ContactAnnotationOperations.AudioCall |
  ContactAnnotationOperations.VideoCall |
 ContactAnnotationOperations.ContactProfile;

await annotationList.TrySaveAnnotationAsync(annotation);
```

## <a name="register-for-each-operation"></a><span data-ttu-id="b50b9-122">各操作を登録する</span><span class="sxs-lookup"><span data-stu-id="b50b9-122">Register for each operation</span></span>

<span data-ttu-id="b50b9-123">パッケージ マニフェストに、注釈を記載した各操作を登録します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-123">In your package manifest, register for each operation that you listed in your annotation.</span></span>

<span data-ttu-id="b50b9-124">登録するには、プロトコル ハンドラーをマニフェストの ``Extensions`` 要素に追加します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-124">Register by adding protocol handlers to the ``Extensions`` element of the manifest.</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-contact-profile">
      <uap:DisplayName>TestProfileApp</uap:DisplayName>
    </uap:Protocol>
  </uap:Extension>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-ipmessaging">
      <uap:DisplayName>TestMsgApp</uap:DisplayName>
    </uap:Protocol>
  </uap:Extension>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-voip-video">
      <uap:DisplayName>TestVideoApp</uap:DisplayName>
    </uap:Protocol>
  </uap:Extension>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-voip-call">
      <uap:DisplayName>TestCallApp</uap:DisplayName>
    </uap:Protocol>
  </uap:Extension>
</Extensions>
```
<span data-ttu-id="b50b9-125">Visual Studio のマニフェスト デザイナーの **[宣言]** タブで追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-125">You can also add these in the **Declarations** tab of the manifest designer in Visual Studio.</span></span>

![マニフェスト デザイナーの [宣言] タブ](images/manifest-designer-protocols.png)

## <a name="find-your-app-next-to-actions-in-a-contact-card"></a><span data-ttu-id="b50b9-127">連絡先カードの操作の横にあるアプリを見つける</span><span class="sxs-lookup"><span data-stu-id="b50b9-127">Find your app next to actions in a contact card</span></span>

<span data-ttu-id="b50b9-128">People アプリを開きます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-128">Open the People app.</span></span> <span data-ttu-id="b50b9-129">アプリは、注釈とパッケージ マニフェストで指定した各操作の横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-129">Your app appears next to each action (operation) that you specified in your annotation and package manifest.</span></span>

![連絡先カード](images/a-contact-card.png)

<span data-ttu-id="b50b9-131">ユーザーが操作のためにアプリを選ぶと、次回ユーザーが連絡先カードを開いたときに、そのアプリがその操作用の既定のアプリとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-131">If users choose your app for an action, it appears as the default app for that action the next time users open a contact card.</span></span>

## <a name="find-your-app-next-to-actions-in-a-mini-contact-card"></a><span data-ttu-id="b50b9-132">ミニ連絡先カードの操作の横にあるアプリを見つける</span><span class="sxs-lookup"><span data-stu-id="b50b9-132">Find your app next to actions in a mini contact card</span></span>

<span data-ttu-id="b50b9-133">ミニ連絡先カードでは、操作を表すタブにアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-133">In mini contact cards, your app appears in tabs that represent actions.</span></span>

![ミニ連絡先カード](images/mini-contact-card.png)

<span data-ttu-id="b50b9-135">ミニ連絡先カードは、**メール** アプリなどのアプリで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-135">Apps such as the **Mail** app open mini contact cards.</span></span> <span data-ttu-id="b50b9-136">お使いのアプリでミニ連絡先カードを開くこともできます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-136">Your app can open them too.</span></span> <span data-ttu-id="b50b9-137">次のコードは、その方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="b50b9-137">This code shows you how to do that.</span></span>

```cs
public async void OpenContactCard(object sender, RoutedEventArgs e)
{
    // Get the selection rect of the button pressed to show contact card.
    FrameworkElement element = (FrameworkElement)sender;

    Windows.UI.Xaml.Media.GeneralTransform buttonTransform = element.TransformToVisual(null);
    Windows.Foundation.Point point = buttonTransform.TransformPoint(new Windows.Foundation.Point());
    Windows.Foundation.Rect rect =
        new Windows.Foundation.Rect(point, new Windows.Foundation.Size(element.ActualWidth, element.ActualHeight));

   // helper method to find a contact just for illustrative purposes.
    Contact contact = await findContact("contoso@contoso.com");

    ContactManager.ShowContactCard(contact, rect, Windows.UI.Popups.Placement.Default);

}
```

<span data-ttu-id="b50b9-138">ミニ連絡先カードを使った例について詳しくは、[連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCards)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b50b9-138">To see more examples with mini contact cards, see [Contact cards sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCards).</span></span>

<span data-ttu-id="b50b9-139">連絡先カードと同様、ユーザーが前回使ったアプリを各タブが記憶しているため、アプリに簡単に戻ることができます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-139">Just like the contact card, each tab remembers the app that the user last used so it's easy for them to return to your app.</span></span>

## <a name="perform-operations-when-users-select-your-app-in-a-contact-card"></a><span data-ttu-id="b50b9-140">ユーザーが連絡先カードでアプリを選んだときに操作を実行する</span><span class="sxs-lookup"><span data-stu-id="b50b9-140">Perform operations when users select your app in a contact card</span></span>

<span data-ttu-id="b50b9-141">**App.cs** ファイル内の [Application.OnActivated](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドをオーバーライドし、ユーザーをアプリ内のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-141">Override the [Application.OnActivated](https://msdn.microsoft.com/library/windows/apps/br242330) method  in your **App.cs** file and navigate users to a page in your app.</span></span> <span data-ttu-id="b50b9-142">それを行う方法の 1 つについては、[連絡先カードの統合のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b50b9-142">The [Contact Card Integration Sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration) shows one way to do that.</span></span>

<span data-ttu-id="b50b9-143">ページのコード ビハインド ファイルで、[Page.OnNavigatedTo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.onnavigatedto.aspx) メソッドをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="b50b9-143">In the code behind file of the page, override the [Page.OnNavigatedTo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.onnavigatedto.aspx) method.</span></span> <span data-ttu-id="b50b9-144">連絡先カードは、このメソッドに操作の名前とユーザーの ID を渡します。</span><span class="sxs-lookup"><span data-stu-id="b50b9-144">The contact card passes this method the name of operation and the ID of the user.</span></span>

<span data-ttu-id="b50b9-145">ビデオ通話や音声通話を開始するには、[VoIP のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/VoIP)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b50b9-145">To start a video or audio call, see this sample: [VoIP sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/VoIP).</span></span> <span data-ttu-id="b50b9-146">[WIndows.ApplicationModel.Calls](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.calls.aspx) 名前空間にすべての API が見つかります。</span><span class="sxs-lookup"><span data-stu-id="b50b9-146">You'll find the complete API in the [WIndows.ApplicationModel.Calls](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.calls.aspx) namespace.</span></span>

<span data-ttu-id="b50b9-147">メッセージングを容易にするには、[Windows.ApplicationModel.Chat](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.aspx) 名前空間をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b50b9-147">To facilitate messaging, see the [Windows.ApplicationModel.Chat](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.aspx) namespace.</span></span>

<span data-ttu-id="b50b9-148">別のアプリを起動することもできます。</span><span class="sxs-lookup"><span data-stu-id="b50b9-148">You can also start another app.</span></span> <span data-ttu-id="b50b9-149">これを行うのが次のコードです。</span><span class="sxs-lookup"><span data-stu-id="b50b9-149">That's what this code does.</span></span>

```cs
protected override async void OnNavigatedTo(NavigationEventArgs e)
{
    base.OnNavigatedTo(e);

    var args = e.Parameter as ProtocolActivatedEventArgs;
    // Display the result of the protocol activation if we got here as a result of being activated for a protocol.

    if (args != null)
    {
        var options = new Windows.System.LauncherOptions();
        options.DisplayApplicationPicker = true;

        options.TargetApplicationPackageFamilyName = “ContosoApp”;

        string launchString = args.uri.Scheme + ":" + args.uri.Query;
        var launchUri = new Uri(launchString);
        await Windows.System.Launcher.LaunchUriAsync(launchUri, options);
    }
}
```

<span data-ttu-id="b50b9-150">```args.uri.scheme``` プロパティには操作の名前、```args.uri.Query``` プロパティにはユーザーの ID が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b50b9-150">The ```args.uri.scheme``` property contains the name of the operation, and the ```args.uri.Query``` property contains the ID of the user.</span></span>
