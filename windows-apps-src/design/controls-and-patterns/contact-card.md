---
Description: A button gives the user a way to trigger an immediate action.
title: 連絡先カード
ms.date: 03/07/2018
ms.topic: article
keywords: windows 10, UWP
pm-contact: kele
design-contact: tbd
dev-contact: tbd
doc-status: not-published
ms.localizationpriority: medium
ms.openlocfilehash: b04a8f616e9f6c7726a222f4a7264b9580ddee3a
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8749731"
---
# <a name="contact-card"></a><span data-ttu-id="0dd94-103">連絡先カード</span><span class="sxs-lookup"><span data-stu-id="0dd94-103">Contact card</span></span>

<span data-ttu-id="0dd94-104">連絡先カードには、[Contact](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact) の名前、電話番号、住所などの連絡先情報が表示されます (個人や企業を表すためにメカニズム UWP によって使用される)。</span><span class="sxs-lookup"><span data-stu-id="0dd94-104">The contact card displays contact information, such as the name, phone number, and address, for a [Contact](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact) (the mechanism UWP uses to represent people and businesses).</span></span>  <span data-ttu-id="0dd94-105">連絡先カードを使用して、ユーザーは連絡先情報を編集することもできます。</span><span class="sxs-lookup"><span data-stu-id="0dd94-105">The contact card also lets the user edit contact info.</span></span> <span data-ttu-id="0dd94-106">コンパクトな連絡先カードを表示するか、追加の情報を含む完全な連絡先カードを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="0dd94-106">You can choose to display a compact contact card, or a full contact card that contains additional information.</span></span>

> <span data-ttu-id="0dd94-107">**重要な API**: [ShowContactCard メソッド](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_),   [ShowFullContactCard メソッド](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_ApplicationModel_Contacts_FullContactCardOptions_),  [IsShowContactCardSupported メソッド](/uwp/api/windows.applicationmodel.contacts.contactmanager.IsShowContactCardSupported),  [Contact クラス](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact)</span><span class="sxs-lookup"><span data-stu-id="0dd94-107">**Important APIs**: [ShowContactCard method](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_),   [ShowFullContactCard method](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_ApplicationModel_Contacts_FullContactCardOptions_),  [IsShowContactCardSupported method](/uwp/api/windows.applicationmodel.contacts.contactmanager.IsShowContactCardSupported),  [Contact class](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact)</span></span>  

<span data-ttu-id="0dd94-108">連絡先カードを表示する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="0dd94-108">There are two ways to display the contact card:</span></span>  
* <span data-ttu-id="0dd94-109">簡易非表示に対応したポップアップに表示される標準的な連絡先カード -- ユーザーが連作先カードの外部をクリックすると、連絡先カードは消えます。</span><span class="sxs-lookup"><span data-stu-id="0dd94-109">As a standard contact card that appears in a flyout that is light-dismissable--the contact card dissapears when the user clicks outside of it.</span></span> 
* <span data-ttu-id="0dd94-110">多くのスペースを使用し、簡易非表示に対応していない完全な連絡先カード -- 閉じるにはユーザーが **[閉じる]** をクリックする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0dd94-110">As a full contact card that takes up more space and is not light-dismissable--the user must click **close** to close it.</span></span> 


<figure>
    <img src="images/contact-card/contact-card-standard.png" alt="The full contact card">
    <figcaption><span data-ttu-id="0dd94-111">標準の連絡先カード</span><span class="sxs-lookup"><span data-stu-id="0dd94-111">The standard contact card</span></span></figcaption>
</figure>

<figure>
    <img src="images/contact-card/contact-card-full.png" alt="The full contact card">
    <figcaption><span data-ttu-id="0dd94-112">完全な連絡先カード</span><span class="sxs-lookup"><span data-stu-id="0dd94-112">The full contact card</span></span></figcaption>
</figure>


## <a name="is-this-the-right-control"></a><span data-ttu-id="0dd94-113">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="0dd94-113">Is this the right control?</span></span>

<span data-ttu-id="0dd94-114">連絡先の連絡先情報を表示する場合は、連絡先カードを使用します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-114">Use the contact card when you want to display contact info for a contact.</span></span> <span data-ttu-id="0dd94-115">連絡先の名前と画像のみを表示する場合は、[ユーザー画像コントロール](person-picture.md) を使用します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-115">If you only want to display the contact's name and picture, use the [person picture control](person-picture.md).</span></span> 


<!-- TODO: Add examples back when the contact card has been added. -->

<!-- ## Examples

<table>
<th align="left">XAML Controls Gallery<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Button">open the app and see the Button in action</a>.</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a></li>
    </ul>
</td>
</tr>
</table> -->

## <a name="show-a-standard-contact-card"></a><span data-ttu-id="0dd94-116">標準の連絡先カードの表示</span><span class="sxs-lookup"><span data-stu-id="0dd94-116">Show a standard contact card</span></span>

1. <span data-ttu-id="0dd94-117">通常、ユーザーが何らかのボタンや場合によって [ユーザー画像コントロール](person-picture.md) をクリックしたときに、連絡先カードが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0dd94-117">Typically, you show a contact card because the user clicked something: a button or perhaps the [person picture control](person-picture.md).</span></span> <span data-ttu-id="0dd94-118">要素は非表示にされません。</span><span class="sxs-lookup"><span data-stu-id="0dd94-118">We don't want to hide the element.</span></span> <span data-ttu-id="0dd94-119">非表示にされないようにするには、要素の位置情報やサイズについて記述した [Rect](/uwp/api/windows.foundation.rect) を作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0dd94-119">To avoid hiding it, we need to create a [Rect](/uwp/api/windows.foundation.rect) that describes the location and size of the element.</span></span> 

    <span data-ttu-id="0dd94-120">これを実行するユーティリティ関数を作成しましょう。このユーティリティ関数は後で使用します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-120">Let's create a utility function that does that for us--we'll use it later.</span></span>
    ```csharp
    // Gets the rectangle of the element 
    public static Rect GetElementRectHelper(FrameworkElement element) 
    { 
        // Passing "null" means set to root element. 
        GeneralTransform elementTransform = element.TransformToVisual(null); 
        Rect rect = elementTransform.TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight)); 
        return rect; 
    } 

    ```

2. <span data-ttu-id="0dd94-121">[ContactManager.IsShowContactCardSupported](/uwp/api/windows.applicationmodel.contacts.contactmanager.IsShowContactCardSupported) メソッドを呼び出して連絡先カードを表示できるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-121">Determine whether you can display the contact card by calling the [ContactManager.IsShowContactCardSupported](/uwp/api/windows.applicationmodel.contacts.contactmanager.IsShowContactCardSupported) method.</span></span> <span data-ttu-id="0dd94-122">サポートされていない場合は、エラー メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0dd94-122">If it's not supported, display an error message.</span></span> <span data-ttu-id="0dd94-123">(この例では、クリック イベントに応じて連絡先カードが表示されることを前提としています)</span><span class="sxs-lookup"><span data-stu-id="0dd94-123">(This example assumes that you'll be showing the contact card in response to a click event .)</span></span>
    ```csharp
    // Contact and Contact Managers are existing classes 
    private void OnUserClickShowContactCard(object sender, RoutedEventArgs e) 
    { 
        if (ContactManager.IsShowContactCardSupported()) 
        { 

    ```

3. <span data-ttu-id="0dd94-124">手順 1 で作成したユーティリティ関数を使用して、イベントを発生させたコントロールの境界を取得します (連絡先カードで非表示にされません)。</span><span class="sxs-lookup"><span data-stu-id="0dd94-124">Use the utility function you created in step 1 to get the bounds of the control that fired the event (so we don't cover it up with the contact card).</span></span>

    ```csharp
            Rect selectionRect = GetElementRect((FrameworkElement)sender); 
    ```

4. <span data-ttu-id="0dd94-125">表示する [Contact](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-125">Get the [Contact](//docs.microsoft.com/uwp/api/Windows.ApplicationModel.Contacts.Contact) object you want to display.</span></span> <span data-ttu-id="0dd94-126">この例では、単に連絡先を作成しますが、コードでは実際の連絡先を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0dd94-126">This example just creates a simple contact, but your code should retrieve an actual contact.</span></span> 

    ```csharp
                // Retrieve the contact to display
                var contact = new Contact(); 
                var email = new ContactEmail(); 
                email.Address = "jsmith@contoso.com"; 
                contact.Emails.Add(email); 
    ```
5. <span data-ttu-id="0dd94-127">連絡先カードを表示するには [ShowContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-127">Show the contact card by calling the  [ShowContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_) method.</span></span> 

    ```csharp
            ContactManager.ShowFullContactCard(
                contact, selectionRect, Placement.Default); 
        } 
    } 
    ```

<span data-ttu-id="0dd94-128">コード例の全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-128">Here's the complete code example:</span></span>

```csharp
// Gets the rectangle of the element 
public static Rect GetElementRect(FrameworkElement element) 
{ 
    // Passing "null" means set to root element. 
    GeneralTransform elementTransform = element.TransformToVisual(null); 
    Rect rect = elementTransform.TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight)); 
    return rect; 
} 
 
// Display a contact in response to an event
private void OnUserClickShowContactCard(object sender, RoutedEventArgs e) 
{ 
    if (ContactManager.IsShowContactCardSupported()) 
    { 
        Rect selectionRect = GetElementRect((FrameworkElement)sender);

        // Retrieve the contact to display
        var contact = new Contact(); 
        var email = new ContactEmail(); 
        email.Address = "jsmith@contoso.com"; 
        contact.Emails.Add(email); 
    
        ContactManager.ShowContactCard(
            contact, selectionRect, Placement.Default); 
    } 
} 

```

## <a name="show-a-full-contact-card"></a><span data-ttu-id="0dd94-129">完全な連絡先カードの表示</span><span class="sxs-lookup"><span data-stu-id="0dd94-129">Show a full contact card</span></span>

<span data-ttu-id="0dd94-130">完全な連絡先カードを表示するには、[ShowContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_) メソッドではなく [ShowFullContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_ApplicationModel_Contacts_FullContactCardOptions_) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-130">To show the full contact card, call the [ShowFullContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_ApplicationModel_Contacts_FullContactCardOptions_) method instead of [ShowContactCard](/uwp/api/windows.applicationmodel.contacts.contactmanager#Windows_ApplicationModel_Contacts_ContactManager_ShowFullContactCard_Windows_ApplicationModel_Contacts_Contact_Windows_Foundation_Rect_).</span></span>

```csharp
private void onUserClickShowContactCard() 
{ 
   
    Contact contact = new Contact(); 
    ContactEmail email = new ContactEmail(); 
    email.Address = "jsmith@hotmail.com"; 
    contact.Emails.Add(email); 
 
 
    // Setting up contact options.     
    FullContactCardOptions fullContactCardOptions = new FullContactCardOptions(); 
 
    // Display full contact card on mouse click.   
    // Launch the People’s App with full contact card  
    fullContactCardOptions.DesiredRemainingView = ViewSizePreference.UseLess; 
     
 
    // Shows the full contact card by launching the People App. 
    ContactManager.ShowFullContactCard(contact, fullContactCardOptions); 
} 

```

## <a name="retrieving-real-contacts"></a><span data-ttu-id="0dd94-131">"実際の” 連絡先の取得</span><span class="sxs-lookup"><span data-stu-id="0dd94-131">Retrieving "real" contacts</span></span>

<span data-ttu-id="0dd94-132">この記事の例では、単純な連絡先を作成します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-132">The examples in this article create a simple contact.</span></span> <span data-ttu-id="0dd94-133">実際のアプリでは、おそらく既存の連絡先を取得します。</span><span class="sxs-lookup"><span data-stu-id="0dd94-133">In a real app, you'd probably want to retrieve an existing contact.</span></span> <span data-ttu-id="0dd94-134">手順については、[連絡先とカレンダーの記事](/windows/uwp/contacts-and-calendar/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0dd94-134">For instructions, see the [Contacts and calendar article](/windows/uwp/contacts-and-calendar/).</span></span>




## <a name="related-articles"></a><span data-ttu-id="0dd94-135">関連記事</span><span class="sxs-lookup"><span data-stu-id="0dd94-135">Related articles</span></span>
- [<span data-ttu-id="0dd94-136">連絡先とカレンダー</span><span class="sxs-lookup"><span data-stu-id="0dd94-136">Contacts and calendar</span></span>](/windows/uwp/contacts-and-calendar/)
- [<span data-ttu-id="0dd94-137">連絡先カードのサンプル</span><span class="sxs-lookup"><span data-stu-id="0dd94-137">Contact cards sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=624040)
- [<span data-ttu-id="0dd94-138">ユーザー画像コントロール</span><span class="sxs-lookup"><span data-stu-id="0dd94-138">People picture control</span></span>](/windows/uwp/controls-and-patterns/person-picture/)
