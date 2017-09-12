---
author: mijacobs
description: 
title: "ユーザー画像コントロール"
template: detail.hbs
label: Parallax View
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
pm-contact: kevjey
design-contact: kimsea
dev-contact: kefodero
doc-status: Published
ms.openlocfilehash: c71fdf3d19c8c8e43666620df53258825c4a8eb1
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="person-picture-control"></a><span data-ttu-id="34c1a-103">ユーザー画像コントロール</span><span class="sxs-lookup"><span data-stu-id="34c1a-103">Person picture control</span></span>

> [!IMPORTANT]
> <span data-ttu-id="34c1a-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="34c1a-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="34c1a-105">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="34c1a-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="34c1a-106">ユーザー画像コントロールは、ユーザー画像を利用できる場合はユーザーのアバター画像を表示します。利用できない場合は、ユーザーの頭文字か汎用アイコンを表示します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-106">The person picture control displays the avatar image for a person, if one is available; if not, it displays the person's initials or a generic glyph.</span></span> <span data-ttu-id="34c1a-107">このコントロールを使うと、ユーザーの連絡先情報を管理するオブジェクトである [Contact オブジェクト](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact)を表示できます。また、表示名やプロフィール画像などの連絡先情報は手動で提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="34c1a-107">You can use the control to display a [Contact object](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact),  an object that manages a person's contact info, or you can manually provide contact information, such as a display name and profile picture.</span></span>  

> <span data-ttu-id="34c1a-108">**重要な API**: [PersonPicture クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture)、[Contact クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact)、[ContactManager クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager)</span><span class="sxs-lookup"><span data-stu-id="34c1a-108">**Important APIs**: [PersonPicture class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture), [Contact class](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact), [ContactManager class](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager)</span></span>

![ユーザー画像コントロール](images/person-picture/person-picture_hero.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="34c1a-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="34c1a-110">Is this the right control?</span></span>

<span data-ttu-id="34c1a-111">ユーザーと連絡先情報を表示するときはユーザー画像を使います。</span><span class="sxs-lookup"><span data-stu-id="34c1a-111">Use the person picture when you want to represent a person and their contact information.</span></span> <span data-ttu-id="34c1a-112">このコントロールの使用例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-112">Here are some examples of when you might use the control:</span></span>
* <span data-ttu-id="34c1a-113">現在のユーザーを表示する</span><span class="sxs-lookup"><span data-stu-id="34c1a-113">To display the current user</span></span>
* <span data-ttu-id="34c1a-114">アドレス帳の連絡先を表示する</span><span class="sxs-lookup"><span data-stu-id="34c1a-114">To display contacts in an address book</span></span>
* <span data-ttu-id="34c1a-115">メッセージの送信者を表示する</span><span class="sxs-lookup"><span data-stu-id="34c1a-115">To display the sender of a message</span></span> 
* <span data-ttu-id="34c1a-116">ソーシャル メディアの連絡先を表示する</span><span class="sxs-lookup"><span data-stu-id="34c1a-116">To display a social media contact</span></span>

<span data-ttu-id="34c1a-117">この図では、連絡先リストのユーザー画像コントロールを示しています。![ユーザー画像コントロール</span><span class="sxs-lookup"><span data-stu-id="34c1a-117">The illustration shows person picture control in a list of contacts: ![The person picture control</span></span>](images/person-picture/person-picture-control.png)

## <a name="how-to-use-the-person-picture-control"></a><span data-ttu-id="34c1a-118">ユーザー画像コントロールの使用方法</span><span class="sxs-lookup"><span data-stu-id="34c1a-118">How to use the person picture control</span></span>

<span data-ttu-id="34c1a-119">ユーザー画像を作成するには、PersonPicture クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-119">To create a person picture, you use the PersonPicture class.</span></span> <span data-ttu-id="34c1a-120">この例では、PersonPicture コントロールを作成し、ユーザーの表示名、プロフィール画像、および頭文字を手動で提供します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-120">This example creates a PersonPicture control and manually provides the person's display name, profile picture, and initials:</span></span>

```xaml
<Page
    x:Class="App2.ExamplePage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:App2"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <StackPanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <PersonPicture
            DisplayName="Betsy Sherman"
            ProfilePicture="Assets\BetsyShermanProfile.png"
            Initials="BS" />
    </StackPanel>
</Page>
```

## <a name="using-the-person-picture-control-to-display-a-contact-object"></a><span data-ttu-id="34c1a-121">ユーザー画像コントロールを使用して、Contact オブジェクトを表示する</span><span class="sxs-lookup"><span data-stu-id="34c1a-121">Using the person picture control to display a Contact object</span></span>

<span data-ttu-id="34c1a-122">ユーザー選択コントロールを使用して、[Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) オブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="34c1a-122">You can use the person picker control to display a [Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) object:</span></span> 

```xaml
<Page
    x:Class="SampleApp.PersonPictureContactExample"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:SampleApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <StackPanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

        <PersonPicture
            Contact="{x:Bind CurrentContact, Mode=OneWay}" />
            
        <Button Click="LoadContactButton_Click">Load contact</Button>
    </StackPanel>
</Page>
```

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Contacts;

namespace SampleApp
{
    public sealed partial class PersonPictureContactExample : Page, System.ComponentModel.INotifyPropertyChanged
    {
        public PersonPictureContactExample()
        {
            this.InitializeComponent();
        }

        private Windows.ApplicationModel.Contacts.Contact _currentContact; 
        public Windows.ApplicationModel.Contacts.Contact CurrentContact
        {
            get => _currentContact;
            set
            {
                _currentContact = value;
                PropertyChanged?.Invoke(this,
                    new System.ComponentModel.PropertyChangedEventArgs(nameof(CurrentContact)));
            }

        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public static async System.Threading.Tasks.Task<Windows.ApplicationModel.Contacts.Contact> CreateContact()
        {

            var contact = new Windows.ApplicationModel.Contacts.Contact();
            contact.FirstName = "Betsy";
            contact.LastName = "Sherman";

            // Get the app folder where the images are stored.
            var appInstalledFolder = 
                Windows.ApplicationModel.Package.Current.InstalledLocation;
            var assets = await appInstalledFolder.GetFolderAsync("Assets");
            var imageFile = await assets.GetFileAsync("betsy.png");
            contact.SourceDisplayPicture = imageFile;

            return contact;
        }

        private async void LoadContactButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentContact = await CreateContact();
        }
    }
}
```

> [!NOTE]
> <span data-ttu-id="34c1a-123">コードを簡潔にするために、この例では新しい Contact オブジェクトを作成しています。</span><span class="sxs-lookup"><span data-stu-id="34c1a-123">To keep the code simple, this example creates a new Contact object.</span></span> <span data-ttu-id="34c1a-124">実際のアプリでは、ユーザーに連絡先を選択してもらうか、[ContactManager](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager) を使用して連絡先リストを照会します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-124">In a real app, you'd let the user select a contact or you'd use a [ContactManager](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager) to query for a list of contacts.</span></span> <span data-ttu-id="34c1a-125">連絡先の取得と管理については、[連絡先とカレンダーの記事](../contacts-and-calendar/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="34c1a-125">For info on retrieving and managing contacts, see the [Contacts and calendar articles](../contacts-and-calendar/index.md).</span></span> 

## <a name="determining-which-info-to-display"></a><span data-ttu-id="34c1a-126">表示する情報の決定</span><span class="sxs-lookup"><span data-stu-id="34c1a-126">Determining which info to display</span></span>

<span data-ttu-id="34c1a-127">[Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) オブジェクトを提供すると、ユーザー画像コントロールによってそのオブジェクトが評価され、表示できる情報が判断されます。</span><span class="sxs-lookup"><span data-stu-id="34c1a-127">When you provide a [Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) object, the person picture control evaluates it to determine which info it can display.</span></span> 

<span data-ttu-id="34c1a-128">画像を利用できる場合、コントロールでは次の優先順位で最初に見つかった画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-128">If an image is available, the control displays the first image it finds, in this order:</span></span>

1.    <span data-ttu-id="34c1a-129">LargeDisplayPicture</span><span class="sxs-lookup"><span data-stu-id="34c1a-129">LargeDisplayPicture</span></span>
2.    <span data-ttu-id="34c1a-130">SmallDisplayPicture</span><span class="sxs-lookup"><span data-stu-id="34c1a-130">SmallDisplayPicture</span></span>
3.    <span data-ttu-id="34c1a-131">Thumbnail</span><span class="sxs-lookup"><span data-stu-id="34c1a-131">Thumbnail</span></span>

<span data-ttu-id="34c1a-132">選択される画像は、PreferSmallImage プロパティを true に設定することで変更できます。このように設定すると、SmallDisplayPicture の優先順位が LargeDisplayPicture よりも高くなります。</span><span class="sxs-lookup"><span data-stu-id="34c1a-132">You can change which image is chosen by setting the PreferSmallImage property to true; this gives the SmallDisplayPicture a higher priority than LargeDisplayPicture.</span></span>

<span data-ttu-id="34c1a-133">画像がない場合、コントロールは連絡先の名前か頭文字を表示します。名前のデータがない場合、コントロールはメール アドレスや電話番号などの連絡先データを表示します。</span><span class="sxs-lookup"><span data-stu-id="34c1a-133">If there isn't an image, the control displays the contact's name or initials; if there's isn't any name data, the control displays contact data, such as an email address or phone number.</span></span> 

## <a name="related-articles"></a><span data-ttu-id="34c1a-134">関連記事</span><span class="sxs-lookup"><span data-stu-id="34c1a-134">Related articles</span></span>

* [<span data-ttu-id="34c1a-135">連絡先とカレンダー</span><span class="sxs-lookup"><span data-stu-id="34c1a-135">Contacts and calendar</span></span>](../contacts-and-calendar/index.md)
* [<span data-ttu-id="34c1a-136">連絡先カードのサンプル</span><span class="sxs-lookup"><span data-stu-id="34c1a-136">Contact cards sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=624040)




