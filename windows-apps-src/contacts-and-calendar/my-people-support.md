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
# <a name="adding-my-people-support-to-an-application"></a>アプリケーションにマイ連絡先のサポートを追加する

> [!IMPORTANT]
> **プレリリース | Fall Creators Update が必要**: マイ連絡先 API を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。

マイ連絡先の機能を使うと、ユーザーは、アプリケーションから直接、連絡先をタスク バーにピン留めすることができます。これにより、いろいろな方法で操作できる新しい連絡先オブジェクトを作成できます。 この記事では、この機能のサポートを追加して、ユーザーがアプリから直接を連絡先をピン留めできるようにする方法を説明します。 連絡先をピン留めすると、[マイ連絡先の共有](my-people-sharing.md)や[通知](my-people-notifications.md)など、ユーザーは新しい種類の操作を利用できるようになります。

![マイ連絡先のチャット](images/my-people-chat.png)

## <a name="requirements"></a>要件

+ Windows 10 と Microsoft Visual Studio 2017。 インストールについて詳しくは、「[Visual Studio のセットアップ](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)」をご覧ください。
+ C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。 C# で作業を始めるには、「["Hello, world" アプリを作成する](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)」をご覧ください。

## <a name="overview"></a>概要

アプリケーションでマイ連絡先の機能を使えるようにするには、3 つの手順を行う必要があります。

1. [アプリケーション マニフェストで shareTarget アクティブ化コントラクトのサポートを宣言します。](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#declaring-support-for-the-share-contract)
2. [ユーザーがアプリを使用して共有できる連絡先に注釈を付けます。](https://docs.microsoft.com/en-us/windows/uwp/contacts-and-calendar/my-people-sharing#annotating-contacts)
3.  アプリケーションの複数インスタンスの同時実行をサポートします。 ユーザーは、連絡先パネルでアプリケーションを使いながら、アプリケーションの通常版を操作できる必要があります。  ユーザーは複数の連絡先パネルを同時に使用することもできます。  これをサポートするには、アプリケーションが複数のビューを同時に実行できる必要があります。 これを行う方法については、「["アプリの複数のビューの表示](https://docs.microsoft.com/en-us/windows/uwp/layout/show-multiple-views)」の記事をご覧ください。

これを行うと、アプリケーションは、注釈付きの連絡先のための、連絡先のパネルに表示されます。

## <a name="declaring-support-for-the-contract"></a>コントラクトのサポートを宣言する

マイ連絡先のコントラクトのサポートを宣言するには、Visual Studio でアプリケーションを開きます。 **ソリューション エクスプローラー** で **Package.appxmanifest** を右クリックして、[**プログラムから開く**] を選択します。 メニューをから [**XML (テキスト) エディター**] を選び、**[OK]** をクリックします。 マニフェストを次のように変更します。

**変更前**

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

**変更後**

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

この追加により、アプリケーションは **windows.ContactPanel** コントラクトから起動できるようになります。これにより、連絡先パネルで操作できるようになります。

## <a name="annotating-contacts"></a>連絡先に注釈を付ける

アプリケーションの連絡先がタスク バーからマイ連絡先ウィンドウに表示されるようにするには、連絡先を Windows 連絡先ストアに書き込む必要があります。  連絡先を書き込む方法については、「[連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)」をご覧ください。

さらにアプリケーションは、各連絡先に注釈を書き込む必要があります。 注釈は、連絡先に関連付けられた、アプリケーションからのデータの一部です。 注釈は、必要なビューに対応する、アクティブ化可能なクラスを、**ProviderProperties** メンバーに含む必要があります。また **ContactProfile** 操作のサポートを宣言する必要があります。

アプリが実行されている任意の時点で連絡先に注釈を付けることができますが、一般には、連絡先がWindows 連絡先ストアに追加されたらすぐに連絡先に注釈を付けるようにします。

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

“appId” はパッケージ ファミリ名の最後に ‘!’ と アクティブ化可能なクラス ID を付けたものです。 パッケージ ファミリー名を見つけるには、既定のエディターを使って **Package.appxmanifest** を開き、“Packaging” タブを検索します。 ここで、"App"は、アプリケーションのスタートアップ ビューに対応する、アクティブ化可能なクラスです。

## <a name="allow-contacts-to-invite-new-potential-users"></a>連絡先が新しい潜在的なユーザーを招待できるようにする

既定では、アプリケーションは、具体的に注釈を付けた連絡先の連絡先パネルのみに表示されます。  これはアプリから操作を行えない連絡先との混同を避けるためです。  アプリケーションが認識していない連絡先にもアプリケーションが表示されるようにする (たとえば、アカウントに連絡先を追加するようにユーザーを招待するためなど) には、マニフェストに以下を追加することができます。

**変更前**

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

**変更後**

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

この変更により、ユーザーがピン留めしたすべての連絡先で、利用可能なオプションとして、連絡先パネルにアプリケーションが表示されるようになります。  連絡先パネル コントラクトを使用してアプリケーションがアクティブ化されている場合には、連絡先はアプリケーションが認識しているものであるかどうかを確認する必要があります。  アプリケーションが認識していない連絡先では、アプリの新しいユーザー エクスペリエンスを表示する必要があります。

![マイ連絡先の連絡先パネル](images/my-people.png)

## <a name="support-for-email-apps"></a>メール アプリでのサポート

メール アプリを作成する場合、すべての連絡先に手動で注釈を付ける必要はありません。  連絡先ウィンドウおよび mailto: プロトコルのサポートを宣言すると、メール アドレスを持つユーザーで、アプリケーションが自動的に表示されます。

## <a name="running-in-the-contact-panel"></a>連絡先パネルで実行する

ユーザーの一部またはすべての連絡先パネルにアプリケーションが表示されたので、連絡先パネル コントラクトのアクティブ化の処理を行う必要があります。

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

コントラクトを使ってアプリケーションがアクティブ化されると、[ContactPanelActivatedEventArgs オブジェクト](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.activation.contactpanelactivatedeventargs)を受け取ります。  これには、アプリケーションが起動して操作する連絡先の ID と [ContactPanel](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.contactpanel) オブジェクトが含まれています。 この ContactPanel オブジェクトへの参照を保持する必要があります。これを使ってパネルを操作できます。

ContactPanel オブジェクトには 2 つのイベントがあります。アプリケーションはこのイベントをリッスンする必要があります。
+ **LaunchFullAppRequested** イベントは、フル アプリケーションが独自のウィンドウで起動するように要求する UI 要素をユーザーが呼び出したときに送信されます。  アプリケーションは、それ自体を起動して、すべての必要なコンテキストを渡す必要があります。  これは好みの方法を使って行うことができます (たとえば、プロトコル起動など)。
+ **Closing イベント**は、アプリケーションが閉じられようとするときに送信されます。これにより、コンテキストを保存することができます。

ContactPanel オブジェクトを使うと、連絡先パネル ヘッダーの背景色を設定することもできます (設定されない場合、既定はシステムのテーマです)。またプログラムを使って連絡先パネルを閉じることもできます。



## <a name="the-pinnedcontactmanager-class"></a>PinnedContactManager クラス

[PinnedContactManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager) は、タスク バーにピン留めされる連絡先を管理するために使用します。 このクラスを使うと、連絡先をピン留めしたり、連絡先のピン留めを外したり、連絡先がピン留めされているかどうかを判別したり、アプリケーションが実行されているシステムで特定のサーフェスへのピン留めがサポートされているかどうかを判別したりすることができます。

**GetDefault** メソッドを使って PinnedContactManager オブジェクトを取得できます。

```Csharp
PinnedContactManager pinnedContactManager = PinnedContactManager.GetDefault();
```

## <a name="pinning-and-unpinning-contacts"></a>連絡先をピン留めする、またはピン留めを外す
作成した PinnedContactManager を使って、連絡先をピン留めしたり、ピン留めを外したりすることができます。 **RequestPinContactAsync** および **RequestUnpinContactAsync** メソッドは、ユーザーに確認ダイアログを提供します。これらのメソッドは、アプリケーション シングルスレッド アパートメント (ASTA、または UI) から呼び出される必要があります。

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

また、同時に複数の連絡先をピン留めすることもできます。

```Csharp
async Task PinMultipleContacts(Contact[] contacts)
{
    await pinnedContactManager.RequestPinContactsAsync(
        contacts, PinnedContactSurface.Taskbar);
}
```

> [!Note]
> 現時点では、連絡先のピン留めを外すバッチ操作はありません。

**注:** 

## <a name="see-also"></a>関連項目
+ [マイ連絡先の共有](my-people-sharing.md)
+ [マイ連絡先の通知](my-people-notifications.md)
+ [連絡先カードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/ContactCardIntegration)
+ [PinnedContactManager クラスのドキュメント](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.contacts.pinnedcontactmanager)
