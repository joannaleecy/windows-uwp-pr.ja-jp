---
author: normesta
description: Windows.ApplicationModel.Contacts 名前空間を使うと、連絡先を選ぶ複数のオプションがあります。
title: 連絡先の選択
ms.assetid: 35FEDEE6-2B0E-4391-84BA-5E9191D4E442
keywords: 連絡先, 単一の連絡先の選択, 複数の連絡先の選択, 複数の選択, 特定の連絡先データ連絡先の選択, 特定のデータ連絡先の選択, 特定のフィールドの選択
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a721e618864155e4eec66d222e8eeafa2e0ca038
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5840446"
---
# <a name="select-contacts"></a>連絡先の選択



[**Windows.ApplicationModel.Contacts**](https://msdn.microsoft.com/library/windows/apps/BR225002) 名前空間では、複数の方法で連絡先を選ぶことができます。 ここでは、1 つまたは複数の連絡先を選ぶ方法について説明します。また、アプリで必要な連絡先情報だけを取得するように連絡先ピッカーを構成する方法についても説明します。

## <a name="set-up-the-contact-picker"></a>連絡先ピッカーを設定する

[**Windows.ApplicationModel.Contacts.ContactPicker**](https://msdn.microsoft.com/library/windows/apps/BR224913) のインスタンスを作成し、変数に割り当てます。

```cs
var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
```

## <a name="set-the-selection-mode-optional"></a>選択モードを設定する (省略可能)

連絡先ピッカーの既定の動作では、ユーザーが選んだ連絡先について、利用可能なすべてのデータが取得されます。 [**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) プロパティを使うと、アプリに必要なデータ フィールドだけを取得するように連絡先ピッカーを構成できます。 利用可能な連絡先データのうちの一部だけが必要な場合は、この方法で連絡先ピッカーを使うと効率的です。

最初に、[**SelectionMode**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.selectionmode) プロパティを **Fields** に設定します。

```cs
contactPicker.SelectionMode = Windows.ApplicationModel.Contacts.ContactSelectionMode.Fields;
```

次に、[**DesiredFieldsWithContactFieldType**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.desiredfieldswithcontactfieldtype) プロパティを使って、連絡先ピッカーで取得するフィールドを指定します。 次の例では、メール アドレスを取得するように連絡先ピッカーを構成しています。

``` cs
contactPicker.DesiredFieldsWithContactFieldType.Add(Windows.ApplicationModel.Contacts.ContactFieldType.Email);
```

## <a name="launch-the-picker"></a>ピッカーを起動する

```cs
Contact contact = await contactPicker.PickContactAsync();
```

ユーザーが連絡先を複数選べるようにする場合は、[**PickContactsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.contacts.contactpicker.pickcontactsasync) を使います。

```cs
public IList<Contact> contacts;
contacts = await contactPicker.PickContactsAsync();
```

## <a name="process-the-contacts"></a>連絡先を処理する

ピッカーから制御が戻ったら、ユーザーが連絡先を選んだかどうかを調べ、 選んでいた場合は連絡先情報を処理します。

1 つの連絡先を処理する例を次に示します。 この例では、連絡先の名前を取得し、*OutputName* と呼ばれる [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) コントロールにコピーしています。

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

複数の連絡先を処理する例を次に示します。

```cs
if (contacts != null && contacts.Count > 0)
{
    foreach (Contact contact in contacts)
    {
        // Do something with the contact information.
    }
}
```

## <a name="complete-example-single-contact"></a>完全な例 (1 つの連絡先)

この例では、連絡先ピッカーを使って、1 つの連絡先の名前、メール アドレス、電話番号、住所を取得しています。

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

## <a name="complete-example-multiple-contacts"></a>完全な例 (複数の連絡先)

次の例では、連絡先ピッカーを使って複数の連絡先を取得し、`OutputContacts` という名前の [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) コントロールに追加しています。

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

## <a name="summary-and-next-steps"></a>要約と次のステップ

ここでは、連絡先ピッカーを使って連絡先情報を取得する基本的な方法について説明しました。 連絡先や連絡先選択ツールの使い方に関するその他の例については、GitHub から [ユニバーサル Windows アプリのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619979) をダウンロードしてください。
