---
xxxxxxxxxxx: Xxxxxxx xxx Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxx xxxxxxxxx, xxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxx.
xxxxx: Xxxxxx xxxxxxxx
xx.xxxxxxx: YYXXXXXY-YXYX-YYYY-YYXX-YXYYYYXYXYYY
xxxxxxxx: xxxxxxxx, xxxxxxxxx
xxxxxxxx: xxxxxx xxxxxx xxxxxxx
xxxxxxxx: xxxxxx xxxxxxxx xxxxxxxx
xxxxxxxx: xxxxxxxx, xxxxxx xxxxxxxx
xxxxxxxx: xxxxxx xxxxxxxx xxxxxxx xxxx
xxxxxxxx: xxxxxxx, xxxxxxxxx xxxxxxxx xxxx
xxxxxxxx: xxxxxxx, xxxxxxxxx xxxxxxxx xxxxxx
---

# Xxxxxx xxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225002) xxxxxxxxx, xxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxx. Xxxx, xx'xx xxxx xxx xxx xx xxxxxx x xxxxxx xxxxxxx xx xxxxxxxx xxxxxxxx, xxx xx'xx xxxx xxx xxx xx xxxxxxxxx xxx xxxxxxx xxxxxx xx xxxxxxxx xxxx xxx xxxxxxx xxxxxxxxxxx xxxx xxxx xxx xxxxx.

## Xxx xx xxx xxxxxxx xxxxxx

Xxxxxx xx xxxxxxxx xx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxx.XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR224913) xxx xxxxxx xx xx x xxxxxxxx.

```cs
var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
```

## Xxx xxx xxxxxxxxx xxxx (xxxxxxxx)

Xx xxxxxxx, xxx xxxxxxx xxxxxx xxxxxxxxx xxx xx xxx xxxxxxxxx xxxx xxx xxx xxxxxxxx xxxx xxx xxxx xxxxxxx. Xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR224913-selectionmode) xxxxxxxx xxxx xxx xxxxxxxxx xxx xxxxxxx xxxxxx xx xxxxxxxx xxxx xxx xxxx xxxxxx xxxx xxxx xxx xxxxx. Xxxx xx x xxxx xxxxxxxxx xxx xx xxx xxx xxxxxxx xxxxxx xx xxx xxxx xxxx x xxxxxx xx xxx xxxxxxxxx xxxxxxx xxxx.

Xxxxx, xxx xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR224913-selectionmode) xxxxxxxx xx **Xxxxxx**:

```cs
contactPicker.SelectionMode = Windows.ApplicationModel.Contacts.ContactSelectionMode.Fields;
```

Xxxx, xxx xxx [**xxxxxxxXxxxxxXxxxXxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR224913-desiredfieldswithcontactfieldtype) xxxxxxxx xx xxxxxxx xxx xxxxxx xxxx xxx xxxx xxx xxxxxxx xxxxxx xx xxxxxxxx. Xxxx xxxxxxx xxxxxxxxxx xxx xxxxxxx xxxxxx xx xxxxxxxx xxxxx xxxxxxxxx:

``` cs
contactPicker.DesiredFieldsWithContactFieldType.Add(Windows.ApplicationModel.Contacts.ContactFieldType.Email);
```

## Xxxxxx xxx xxxxxx

```cs
Contact contact = await contactPicker.PickContactAsync();
```

Xxx [**xxxxXxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR224913-pickcontactsasync) xx xxx xxxx xxx xxxx xx xxxxxx xxx xx xxxx xxxxxxxx.

```cs
public IList&lt;Contact&gt; contacts;
contacts = await contactPicker.PickContactsAsync();
```

## Xxxxxxx xxx xxxxxxxx

Xxxx xxx xxxxxx xxxxxxx, xxxxx xxxxxxx xxx xxxx xxx xxxxxxxx xxx xxxxxxxx. Xx xx, xxxxxxx xxx xxxxxxx xxxxxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxxxxx x xxxxxx xxxxxxx. Xxxx xx xxxxxxxx xxx xxxxxxx'x xxxx xxx xxxx xx xxxx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209652) xxxxxxx xxxxxx *XxxxxxXxxx*.

```cs
if (contact != null)
{
    OutputName.Text = contact.DisplayName;
}
else
{
    rootPage.NotifyUser(&quot;No contact was selected.&quot;, NotifyType.ErrorMessage);
}
```

Xxxx xxxxxxx xxxxx xxx xx xxxxxxx xxxxxxxx xxxxxxxx.

```cs
if (contacts != null &amp;&amp; contacts.Count &gt; 0)
{
    foreach (Contact contact in contacts)
    {
        // Do something with the contact information.
    }
}
```

## Xxxxxxxx xxxxxxx (xxxxxx xxxxxxx)

Xxxx xxxxxxx xxxx xxx xxxxxxx xxxxxx xx xxxxxxxx x xxxxxx xxxxxxx'x xxxx xxxxx xxxx xx xxxxx xxxxxxx, xxxxxxxx xx xxxxx xxxxxx.

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

private void AppendContactFieldValues&lt;T&gt;(TextBlock content, IList&lt;T&gt; fields)
{
    if (fields.Count &gt; 0)
    {
        StringBuilder output = new StringBuilder();

        if (fields[0].GetType() == typeof(ContactEmail))
        {
            foreach (ContactEmail email in fields as IList&lt;ContactEmail&gt;)
            {
                output.AppendFormat(&quot;Email: {0} ({1})\n&quot;, email.Address, email.Kind);
            }
        }
        else if (fields[0].GetType() == typeof(ContactPhone))
        {
            foreach (ContactPhone phone in fields as IList&lt;ContactPhone&gt;)
            {
                output.AppendFormat(&quot;Phone: {0} ({1})\n&quot;, phone.Number, phone.Kind);
            }
        }
        else if (fields[0].GetType() == typeof(ContactAddress))
        {
            List&lt;String&gt; addressParts = null;
            string unstructuredAddress = &quot;&quot;;

            foreach (ContactAddress address in fields as IList&lt;ContactAddress&gt;)
            {
                addressParts = (new List&lt;string&gt; { address.StreetAddress, address.Locality, address.Region, address.PostalCode });
                unstructuredAddress = string.Join(&quot;, &quot;, addressParts.FindAll(s =&gt; !string.IsNullOrEmpty(s)));
                output.AppendFormat(&quot;Address: {0} ({1})\n&quot;, unstructuredAddress, address.Kind);
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

## Xxxxxxxx xxxxxxx (xxxxxxxx xxxxxxxx)

Xxxx xxxxxxx xxxx xxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxxxx xxxxxxxx xxx xxxx xxxx xxx xxxxxxxx xx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878) xxxxxxx xxxxxx `OutputContacts`.

```cs
MainPage rootPage = MainPage.Current;
public IList&lt;Contact&gt; contacts;

private async void PickContactsButton-Click(object sender, RoutedEventArgs e)
{
    var contactPicker = new Windows.ApplicationModel.Contacts.ContactPicker();
    contactPicker.CommitButtonText = &quot;Select&quot;;
    contacts = await contactPicker.PickContactsAsync();

    // Clear the ListView.
    OutputContacts.Items.Clear();

    if (contacts.Count &gt; 0)
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
        if (contact.Emails.Count &gt; 0)
        {
            SecondaryText = contact.Emails[0].Address;
        }
        else if (contact.Phones.Count &gt; 0)
        {
            SecondaryText = contact.Phones[0].Number;
        }
        else if (contact.Addresses.Count &gt; 0)
        {
            List&lt;string&gt; addressParts = (new List&lt;string&gt; { contact.Addresses[0].StreetAddress, 
              contact.Addresses[0].Locality, contact.Addresses[0].Region, contact.Addresses[0].PostalCode });
              string unstructuredAddress = string.Join(&quot;, &quot;, addressParts.FindAll(s =&gt; !string.IsNullOrEmpty(s)));
            SecondaryText = unstructuredAddress;
        }
    }
}
```

## Xxxxxxx xxx xxxx xxxxx

Xxx xxx xxxx x xxxxx xxxxxxxxxxxxx xx xxx xx xxx xxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxxx xxxxxxxxxxx. Xxxxxxxx xxx [Xxxxxxxxx Xxxxxxx xxx xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619979) xxxx XxxXxx xx xxx xxxx xxxxxxxx xx xxx xx xxx xxxxxxxx xxx xxx xxxxxxx xxxxxx.

<!--HONumber=Mar16_HO1-->
