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
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7417168"
---
# <a name="connect-your-app-to-actions-on-a-contact-card"></a>アプリを連絡先カードの操作に接続する

アプリは、連絡先カードまたはミニ連絡先カードの操作の横に表示できます。 ユーザーは、プロファイル ページを開く、通話を行う、メッセージを送信するなど、操作を実行するアプリを選ぶことができます。

![連絡先カードとミニ連絡先カード](images/all-contact-cards.png)

最初に、既存の連絡先を検索するか、新しい連絡先を作成します。 次に、*注釈*といくつかのパッケージ マニフェスト エントリを作成して、アプリがサポートする操作について説明します。 その後、操作を実行するコードを記述します。

完全なサンプルについては、[連絡先カードの統合のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration)をご覧ください。

## <a name="find-or-create-a-contact"></a>連絡先を検索または作成する

他のユーザーとつながるのをサポートするアプリの場合、Windows で連絡先を検索してから注釈を付けます。 連絡先を管理するアプリの場合、連絡先を Windows 連絡先リストに追加してから、注釈を付けることができます。

### <a name="find-a-contact"></a>連絡先を検索する

連絡先は、名前、メール アドレス、または電話番号を使って検索します。

```cs
ContactStore contactStore = await ContactManager.RequestStoreAsync();

IReadOnlyList<Contact> contacts = null;

contacts = await contactStore.FindContactsAsync(emailAddress);

Contact contact = contacts[0];
```

### <a name="create-a-contact"></a>連絡先を作成する

アドレス帳のようなアプリの場合、連絡先を作成してから連絡先一覧に追加します。

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

## <a name="tag-each-contact-with-an-annotation"></a>注釈を使って各連絡先にタグを付ける

アプリで実行できる操作 (例: ビデオ通話やメッセージング) の一覧を使って各連絡先にタグを付けます。

その後、連絡先の ID を、アプリがそのユーザーを識別するために内部で使っている ID に関連付けます。

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

## <a name="register-for-each-operation"></a>各操作を登録する

パッケージ マニフェストに、注釈を記載した各操作を登録します。

登録するには、プロトコル ハンドラーをマニフェストの ``Extensions`` 要素に追加します。

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
Visual Studio のマニフェスト デザイナーの **[宣言]** タブで追加することもできます。

![マニフェスト デザイナーの [宣言] タブ](images/manifest-designer-protocols.png)

## <a name="find-your-app-next-to-actions-in-a-contact-card"></a>連絡先カードの操作の横にあるアプリを見つける

People アプリを開きます。 アプリは、注釈とパッケージ マニフェストで指定した各操作の横に表示されます。

![連絡先カード](images/a-contact-card.png)

ユーザーが操作のためにアプリを選ぶと、次回ユーザーが連絡先カードを開いたときに、そのアプリがその操作用の既定のアプリとして表示されます。

## <a name="find-your-app-next-to-actions-in-a-mini-contact-card"></a>ミニ連絡先カードの操作の横にあるアプリを見つける

ミニ連絡先カードでは、操作を表すタブにアプリが表示されます。

![ミニ連絡先カード](images/mini-contact-card.png)

ミニ連絡先カードは、**メール** アプリなどのアプリで開くことができます。 お使いのアプリでミニ連絡先カードを開くこともできます。 次のコードは、その方法を示しています。

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

ミニ連絡先カードを使った例について詳しくは、[連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCards)をご覧ください。

連絡先カードと同様、ユーザーが前回使ったアプリを各タブが記憶しているため、アプリに簡単に戻ることができます。

## <a name="perform-operations-when-users-select-your-app-in-a-contact-card"></a>ユーザーが連絡先カードでアプリを選んだときに操作を実行する

**App.cs** ファイル内の [Application.OnActivated](https://msdn.microsoft.com/library/windows/apps/br242330) メソッドをオーバーライドし、ユーザーをアプリ内のページに移動します。 それを行う方法の 1 つについては、[連絡先カードの統合のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ContactCardIntegration)をご覧ください。

ページのコード ビハインド ファイルで、[Page.OnNavigatedTo](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.onnavigatedto.aspx) メソッドをオーバーライドします。 連絡先カードは、このメソッドに操作の名前とユーザーの ID を渡します。

ビデオ通話や音声通話を開始するには、[VoIP のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/VoIP)をご覧ください。 [WIndows.ApplicationModel.Calls](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.calls.aspx) 名前空間にすべての API が見つかります。

メッセージングを容易にするには、[Windows.ApplicationModel.Chat](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.chat.aspx) 名前空間をご覧ください。

別のアプリを起動することもできます。 これを行うのが次のコードです。

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

```args.uri.scheme``` プロパティには操作の名前、```args.uri.Query``` プロパティにはユーザーの ID が含まれています。
