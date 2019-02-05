---
description: Windows.ApplicationModel.Contacts 名前空間を使うと、連絡先を選ぶ複数のオプションがあります。
title: 連絡先の選択
ms.assetid: 35FEDEE6-2B0E-4391-84BA-5E9191D4E442
keywords: 連絡先, 単一の連絡先の選択, 複数の連絡先の選択, 複数の選択, 特定の連絡先データ連絡先の選択, 特定のデータ連絡先の選択, 特定のフィールドの選択
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c44f05b5d67fe094859ea0eacfb57c0012004d14
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9047597"
---
# <a name="select-contacts"></a><span data-ttu-id="8a700-104">連絡先の選択</span><span class="sxs-lookup"><span data-stu-id="8a700-104">Select contacts</span></span>



<span data-ttu-id="8a700-105">[**Windows.ApplicationModel.Contacts**](https://msdn.microsoft.com/library/windows/apps/BR225002) 名前空間では、複数の方法で連絡先を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="8a700-105">Through the [**Windows.ApplicationModel.Contacts**](https://msdn.microsoft.com/library/windows/apps/BR225002) namespace, you have several options for selecting contacts.</span></span> <span data-ttu-id="8a700-106">ここでは、1 つまたは複数の連絡先を選ぶ方法について説明します。また、アプリで必要な連絡先情報だけを取得するように連絡先ピッカーを構成する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="8a700-106">Here, we'll show you how to select a single contact or multiple contacts, and we'll show you how to configure the contact picker to retrieve only the contact information that your app needs.</span></span>

## <a name="set-up-the-contact-picker"></a><span data-ttu-id="8a700-107">連絡先ピッカーを設定する</span><span class="sxs-lookup"><span data-stu-id="8a700-107">Set up the contact picker</span></span>

<span data-ttu-id="8a700-108">[**Windows.ApplicationModel.Contacts.ContactPicker**](https://msdn.microsoft.com/library/windows/apps/BR224913) のインスタンスを作成し、変数に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="8a700-108">Create an instance of [**Windows.ApplicationModel.Contacts.ContactPicker**](https://msdn.microsoft.com/library/windows/apps/BR224913) and assign it to a variable.</span></span>

```cs
var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
```

## <a name="set-the-selection-mode-optional"></a><span data-ttu-id="8a700-109">選択モードを設定する (省略可能)</span><span class="sxs-lookup"><span data-stu-id="8a700-109">Set the selection mode (optional)</span></span>

<span data-ttu-id="8a700-110">連絡先ピッカーの既定の動作では、ユーザーが選んだ連絡先について、利用可能なすべてのデータが取得されます。</span><span class="sxs-lookup"><span data-stu-id="8a700-110">By default, the contact picker retrieves all of the available data for the contacts that the user selects.</span></span> <span data-ttu-id="8a700-111">[**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) プロパティを使うと、アプリに必要なデータ フィールドだけを取得するように連絡先ピッカーを構成できます。</span><span class="sxs-lookup"><span data-stu-id="8a700-111">The [**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) property lets you configure the contact picker to retrieve only the data fields that your app needs.</span></span> <span data-ttu-id="8a700-112">利用可能な連絡先データのうちの一部だけが必要な場合は、この方法で連絡先ピッカーを使うと効率的です。</span><span class="sxs-lookup"><span data-stu-id="8a700-112">This is a more efficient way to use the contact picker if you only need a subset of the available contact data.</span></span>

<span data-ttu-id="8a700-113">最初に、[**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) プロパティを **Fields** に設定します。</span><span class="sxs-lookup"><span data-stu-id="8a700-113">First, set the [**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) property to **Fields**:</span></span>

```cs
contactPicker.SelectionMode = Windows.ApplicationModel.Contacts.ContactSelectionMode.Fields;
```

<span data-ttu-id="8a700-114">次に、[**DesiredFieldsWithContactFieldType**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.desiredfieldswithcontactfieldtype) プロパティを使って、連絡先ピッカーで取得するフィールドを指定します。</span><span class="sxs-lookup"><span data-stu-id="8a700-114">Then, use the [**DesiredFieldsWithContactFieldType**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.desiredfieldswithcontactfieldtype) property to specify the fields that you want the contact picker to retrieve.</span></span> <span data-ttu-id="8a700-115">次の例では、メール アドレスを取得するように連絡先ピッカーを構成しています。</span><span class="sxs-lookup"><span data-stu-id="8a700-115">This example configures the contact picker to retrieve email addresses:</span></span>

``` cs
contactPicker.DesiredFieldsWithContactFieldType.Add(Windows.ApplicationModel.Contacts.ContactFieldType.Email);
```

## <a name="launch-the-picker"></a><span data-ttu-id="8a700-116">ピッカーを起動する</span><span class="sxs-lookup"><span data-stu-id="8a700-116">Launch the picker</span></span>

```cs
Contact contact = await contactPicker.PickContactAsync();
```

<span data-ttu-id="8a700-117">ユーザーが連絡先を複数選べるようにする場合は、[**PickContactsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.pickcontactsasync) を使います。</span><span class="sxs-lookup"><span data-stu-id="8a700-117">Use [**PickContactsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.pickcontactsasync) if you want the user to select one or more contacts.</span></span>

```cs
public IList<Contact> contacts;
contacts = await contactPicker.PickContactsAsync();
```

## <a name="process-the-contacts"></a><span data-ttu-id="8a700-118">連絡先を処理する</span><span class="sxs-lookup"><span data-stu-id="8a700-118">Process the contacts</span></span>

<span data-ttu-id="8a700-119">ピッカーから制御が戻ったら、ユーザーが連絡先を選んだかどうかを調べ、</span><span class="sxs-lookup"><span data-stu-id="8a700-119">When the picker returns, check whether the user has selected any contacts.</span></span> <span data-ttu-id="8a700-120">選んでいた場合は連絡先情報を処理します。</span><span class="sxs-lookup"><span data-stu-id="8a700-120">If so, process the contact information.</span></span>

<span data-ttu-id="8a700-121">1 つの連絡先を処理する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8a700-121">This example shows how to processes a single contact.</span></span> <span data-ttu-id="8a700-122">この例では、連絡先の名前を取得し、*OutputName* と呼ばれる [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) コントロールにコピーしています。</span><span class="sxs-lookup"><span data-stu-id="8a700-122">Here we retrieve the contact's name and copy it into a [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) control called *OutputName*.</span></span>

```cs
if (contact != null)
{
    OutputName.Text = contact.DisplayName;
}
else
{
    rootPage.NotifyUser("No contact was selected.", NotifyType.ErrorMessage);
}
```

<span data-ttu-id="8a700-123">複数の連絡先を処理する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8a700-123">This example shows how to process multiple contacts.</span></span>

```cs
if (contacts != null && contacts.Count > 0)
{
    foreach (Contact contact in contacts)
    {
        // Do something with the contact information.
    }
}
```

## <a name="complete-example-single-contact"></a><span data-ttu-id="8a700-124">完全な例 (1 つの連絡先)</span><span class="sxs-lookup"><span data-stu-id="8a700-124">Complete example (single contact)</span></span>

<span data-ttu-id="8a700-125">この例では、連絡先ピッカーを使って、1 つの連絡先の名前、メール アドレス、電話番号、住所を取得しています。</span><span class="sxs-lookup"><span data-stu-id="8a700-125">This example uses the contact picker to retrieve a single contact's name along with an email address, location or phone number.</span></span>

```cs
// ...
using Windows.ApplicationModel.Contacts;
// ...

private async void PickAContactButton-Click(object sender, RoutedEventArgs e)
{
    ContactPicker contactPicker = new ContactPicker();

    contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
    contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Address);
    contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

    Contact contact = await contactPicker.PickContactAsync();

    if (contact != null)
    {
        OutputFields.Visibility = Visibility.Visible;
        OutputEmpty.Visibility = Visibility.Collapsed;

        OutputName.Text = contact.DisplayName;

        AppendContactFieldValues(OutputEmails, contact.Emails);
        AppendContactFieldValues(OutputPhoneNumbers, contact.Phones);
        AppendContactFieldValues(OutputAddresses, contact.Addresses);
    }
    else
    {
        OutputEmpty.Visibility = Visibility.Visible;
        OutputFields.Visibility = Visibility.Collapsed;
    }
}

private void AppendContactFieldValues<T>(TextBlock content, IList<T> fields)
{
    if (fields.Count > 0)
    {
        StringBuilder output = new StringBuilder();

        if (fields[0].GetType() == typeof(ContactEmail))
        {
            foreach (ContactEmail email in fields as IList<ContactEmail>)
            {
                output.AppendFormat("Email: {0} ({1})\n", email.Address, email.Kind);
            }
        }
        else if (fields[0].GetType() == typeof(ContactPhone))
        {
            foreach (ContactPhone phone in fields as IList<ContactPhone>)
            {
                output.AppendFormat("Phone: {0} ({1})\n", phone.Number, phone.Kind);
            }
        }
        else if (fields[0].GetType() == typeof(ContactAddress))
        {
            List<String> addressParts = null;
            string unstructuredAddress = "";

            foreach (ContactAddress address in fields as IList<ContactAddress>)
            {
                addressParts = (new List<string> { address.StreetAddress, address.Locality, address.Region, address.PostalCode });
                unstructuredAddress = string.Join(", ", addressParts.FindAll(s => !string.IsNullOrEmpty(s)));
                output.AppendFormat("Address: {0} ({1})\n", unstructuredAddress, address.Kind);
            }
        }

        content.Visibility = Visibility.Visible;
        content.Text = output.ToString();
    }
    else
    {
        content.Visibility = Visibility.Collapsed;
    }
}
```

## <a name="complete-example-multiple-contacts"></a><span data-ttu-id="8a700-126">完全な例 (複数の連絡先)</span><span class="sxs-lookup"><span data-stu-id="8a700-126">Complete example (multiple contacts)</span></span>

<span data-ttu-id="8a700-127">次の例では、連絡先ピッカーを使って複数の連絡先を取得し、`OutputContacts` という名前の [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) コントロールに追加しています。</span><span class="sxs-lookup"><span data-stu-id="8a700-127">This example uses the contact picker to retrieve multiple contacts and then adds the contacts to a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) control called `OutputContacts`.</span></span>

```cs
MainPage rootPage = MainPage.Current;
public IList<Contact> contacts;

private async void PickContactsButton-Click(object sender, RoutedEventArgs e)
{
    var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
    contactPicker.CommitButtonText = "Select";
    contacts = await contactPicker.PickContactsAsync();

    // Clear the ListView.
    OutputContacts.Items.Clear();

    if (contacts != null && contacts.Count > 0)
    {
        OutputContacts.Visibility = Windows.UI.Xaml.Visibility.Visible;
        OutputEmpty.Visibility = Visibility.Collapsed;

        foreach (Contact contact in contacts)
        {
            // Add the contacts to the ListView.
            OutputContacts.Items.Add(new ContactItemAdapter(contact));
        }
    }
    else
    {
        OutputEmpty.Visibility = Visibility.Visible;
    }         
}
```

``` cs
public class ContactItemAdapter
{
    public string Name { get; private set; }
    public string SecondaryText { get; private set; }

    public ContactItemAdapter(Contact contact)
    {
        Name = contact.DisplayName;
        if (contact.Emails.Count > 0)
        {
            SecondaryText = contact.Emails[0].Address;
        }
        else if (contact.Phones.Count > 0)
        {
            SecondaryText = contact.Phones[0].Number;
        }
        else if (contact.Addresses.Count > 0)
        {
            List<string> addressParts = (new List<string> { contact.Addresses[0].StreetAddress,
              contact.Addresses[0].Locality, contact.Addresses[0].Region, contact.Addresses[0].PostalCode });
              string unstructuredAddress = string.Join(", ", addressParts.FindAll(s => !string.IsNullOrEmpty(s)));
            SecondaryText = unstructuredAddress;
        }
    }
}
```

## <a name="summary-and-next-steps"></a><span data-ttu-id="8a700-128">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="8a700-128">Summary and next steps</span></span>

<span data-ttu-id="8a700-129">ここでは、連絡先ピッカーを使って連絡先情報を取得する基本的な方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="8a700-129">Now you have a basic understanding of how to use the contact picker to retrieve contact information.</span></span> <span data-ttu-id="8a700-130">連絡先や連絡先選択ツールの使い方に関するその他の例については、GitHub から [ユニバーサル Windows アプリのサンプル](https://go.microsoft.com/fwlink/p/?linkid=619979) をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="8a700-130">Download the [Universal Windows app samples](https://go.microsoft.com/fwlink/p/?linkid=619979) from GitHub to see more examples of how to use contacts and the contact picker.</span></span>
