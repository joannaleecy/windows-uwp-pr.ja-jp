---
author: mijacobs
description: ユーザー画像を利用できる場合はユーザーのアバター画像を表示します。利用できない場合は、ユーザーの頭文字か汎用アイコンを表示します。
title: ユーザー画像コントロール
template: detail.hbs
label: Parallax View
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
pm-contact: trestar
design-contact: kimsea
dev-contact: kefodero
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: eadc0763e7f99930bee3d2a388a881c52e89f609
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5637783"
---
# <a name="person-picture-control"></a><span data-ttu-id="e3f4f-104">ユーザー画像コントロール</span><span class="sxs-lookup"><span data-stu-id="e3f4f-104">Person picture control</span></span>

<span data-ttu-id="e3f4f-105">ユーザー画像コントロールは、ユーザー画像を利用できる場合はユーザーのアバター画像を表示します。利用できない場合は、ユーザーの頭文字か汎用アイコンを表示します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-105">The person picture control displays the avatar image for a person, if one is available; if not, it displays the person's initials or a generic glyph.</span></span> <span data-ttu-id="e3f4f-106">このコントロールを使うと、ユーザーの連絡先情報を管理するオブジェクトである [Contact オブジェクト](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact)を表示できます。また、表示名やプロフィール画像などの連絡先情報は手動で提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-106">You can use the control to display a [Contact object](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact),  an object that manages a person's contact info, or you can manually provide contact information, such as a display name and profile picture.</span></span>  

> <span data-ttu-id="e3f4f-107">**重要な API**: [PersonPicture クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture)、[Contact クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact)、[ContactManager クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager)</span><span class="sxs-lookup"><span data-stu-id="e3f4f-107">**Important APIs**: [PersonPicture class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture), [Contact class](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact), [ContactManager class](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager)</span></span>

<span data-ttu-id="e3f4f-108">この図は、ユーザーの名前を表示する 2 つの[テキスト ブロック](text-block.md) 要素が付属している 2 つのユーザー画像コントロールを示しています。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-108">This illustration shows two person picture controls accompanied by two [text block](text-block.md) elements that display the users' names.</span></span> 
![ユーザー画像コントロール](images/person-picture/person-picture_hero.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="e3f4f-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="e3f4f-110">Is this the right control?</span></span>

<span data-ttu-id="e3f4f-111">ユーザーと連絡先情報を表示するときはユーザー画像を使います。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-111">Use the person picture when you want to represent a person and their contact information.</span></span> <span data-ttu-id="e3f4f-112">このコントロールの使用例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-112">Here are some examples of when you might use the control:</span></span>
* <span data-ttu-id="e3f4f-113">現在のユーザーを表示する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-113">To display the current user</span></span>
* <span data-ttu-id="e3f4f-114">アドレス帳の連絡先を表示する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-114">To display contacts in an address book</span></span>
* <span data-ttu-id="e3f4f-115">メッセージの送信者を表示する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-115">To display the sender of a message</span></span> 
* <span data-ttu-id="e3f4f-116">ソーシャル メディアの連絡先を表示する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-116">To display a social media contact</span></span>

<span data-ttu-id="e3f4f-117">この図では、連絡先リストのユーザー画像コントロールを示しています。![ユーザー画像コントロール</span><span class="sxs-lookup"><span data-stu-id="e3f4f-117">The illustration shows person picture control in a list of contacts: ![The person picture control</span></span>](images/person-picture/person-picture-control.png)

## <a name="examples"></a><span data-ttu-id="e3f4f-118">例</span><span class="sxs-lookup"><span data-stu-id="e3f4f-118">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="e3f4f-119">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="e3f4f-119">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="e3f4f-120"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/PersonPicture">アプリを開き、PersonPicture の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-120">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/PersonPicture">open the app and see the PersonPicture in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="e3f4f-121">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="e3f4f-121">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="e3f4f-122">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-122">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="how-to-use-the-person-picture-control"></a><span data-ttu-id="e3f4f-123">ユーザー画像コントロールの使用方法</span><span class="sxs-lookup"><span data-stu-id="e3f4f-123">How to use the person picture control</span></span>

<span data-ttu-id="e3f4f-124">ユーザー画像を作成するには、PersonPicture クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-124">To create a person picture, you use the PersonPicture class.</span></span> <span data-ttu-id="e3f4f-125">この例では、PersonPicture コントロールを作成し、ユーザーの表示名、プロフィール画像、および頭文字を手動で提供します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-125">This example creates a PersonPicture control and manually provides the person's display name, profile picture, and initials:</span></span>

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

## <a name="using-the-person-picture-control-to-display-a-contact-object"></a><span data-ttu-id="e3f4f-126">ユーザー画像コントロールを使用して、Contact オブジェクトを表示する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-126">Using the person picture control to display a Contact object</span></span>

<span data-ttu-id="e3f4f-127">ユーザー選択コントロールを使用して、[Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) オブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-127">You can use the person picker control to display a [Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) object:</span></span> 

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
> <span data-ttu-id="e3f4f-128">コードを簡潔にするために、この例では新しい Contact オブジェクトを作成しています。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-128">To keep the code simple, this example creates a new Contact object.</span></span> <span data-ttu-id="e3f4f-129">実際のアプリでは、ユーザーに連絡先を選択してもらうか、[ContactManager](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager) を使用して連絡先リストを照会します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-129">In a real app, you'd let the user select a contact or you'd use a [ContactManager](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.ContactManager) to query for a list of contacts.</span></span> <span data-ttu-id="e3f4f-130">連絡先の取得と管理については、[連絡先とカレンダーの記事](../../contacts-and-calendar/index.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-130">For info on retrieving and managing contacts, see the [Contacts and calendar articles](../../contacts-and-calendar/index.md).</span></span> 

## <a name="determining-which-info-to-display"></a><span data-ttu-id="e3f4f-131">表示する情報の決定</span><span class="sxs-lookup"><span data-stu-id="e3f4f-131">Determining which info to display</span></span>

<span data-ttu-id="e3f4f-132">[Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) オブジェクトを提供すると、ユーザー画像コントロールによってそのオブジェクトが評価され、表示できる情報が判断されます。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-132">When you provide a [Contact](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Contacts.Contact) object, the person picture control evaluates it to determine which info it can display.</span></span> 

<span data-ttu-id="e3f4f-133">画像を利用できる場合、コントロールでは次の優先順位で最初に見つかった画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-133">If an image is available, the control displays the first image it finds, in this order:</span></span>

1. <span data-ttu-id="e3f4f-134">LargeDisplayPicture</span><span class="sxs-lookup"><span data-stu-id="e3f4f-134">LargeDisplayPicture</span></span>
1. <span data-ttu-id="e3f4f-135">SmallDisplayPicture</span><span class="sxs-lookup"><span data-stu-id="e3f4f-135">SmallDisplayPicture</span></span>
1. <span data-ttu-id="e3f4f-136">Thumbnail</span><span class="sxs-lookup"><span data-stu-id="e3f4f-136">Thumbnail</span></span>

<span data-ttu-id="e3f4f-137">選択される画像は、PreferSmallImage プロパティを true に設定することで変更できます。このように設定すると、SmallDisplayPicture の優先順位が LargeDisplayPicture よりも高くなります。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-137">You can change which image is chosen by setting the PreferSmallImage property to true; this gives the SmallDisplayPicture a higher priority than LargeDisplayPicture.</span></span>

<span data-ttu-id="e3f4f-138">画像がない場合、コントロールは連絡先の名前か頭文字を表示します。名前のデータがない場合、コントロールはメール アドレスや電話番号などの連絡先データを表示します。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-138">If there isn't an image, the control displays the contact's name or initials; if there's isn't any name data, the control displays contact data, such as an email address or phone number.</span></span> 

## <a name="get-the-sample-code"></a><span data-ttu-id="e3f4f-139">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="e3f4f-139">Get the sample code</span></span>

- <span data-ttu-id="e3f4f-140">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="e3f4f-140">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="e3f4f-141">関連記事</span><span class="sxs-lookup"><span data-stu-id="e3f4f-141">Related articles</span></span>

* [<span data-ttu-id="e3f4f-142">連絡先とカレンダー</span><span class="sxs-lookup"><span data-stu-id="e3f4f-142">Contacts and calendar</span></span>](../../contacts-and-calendar/index.md)
* [<span data-ttu-id="e3f4f-143">連絡先カードのサンプル</span><span class="sxs-lookup"><span data-stu-id="e3f4f-143">Contact cards sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=624040)
