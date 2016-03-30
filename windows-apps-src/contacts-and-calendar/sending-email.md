---
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxxx xxxxx xxxxxx xx xxxxx xxx xxxx xx xxxx xx xxxxx xxxxxxx. Xxx xxx xxx-xxxxxxxx xxx xxxxxx xx xxx xxxxx xxxx xxxx xxxxxx xxxxxxx xxx xxxxxx. Xxx xxxxxxx xxxx xxx xx xxxx xxxxx xxx xxxx xxxx xxx xxxx xxxxxx.
xxxxx: Xxxx xxxxx
xx.xxxxxxx: YYYYYXYY-YYYY-YYYX-XYXX-YYXYYYXYYYXY
xxxxxxxx: xxxxxxxx, xxxxx, xxxx
---

# Xxxx xxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxx xxx xx xxxxxx xxx xxxxxxx xxxxx xxxxxx xx xxxxx xxx xxxx xx xxxx xx xxxxx xxxxxxx. Xxx xxx xxx-xxxxxxxx xxx xxxxxx xx xxx xxxxx xxxx xxxx xxxxxx xxxxxxx xxx xxxxxx. Xxx xxxxxxx xxxx xxx xx xxxx xxxxx xxx xxxx xxxx xxx xxxx xxxxxx.

**Xx xxxx xxxxxxx**

-   [Xxxxxx xxx xxxxxxx xxxxx xxxxxx](#launch-the-compose-email-dialog)
-   [Xxxxxxx xxx xxxx xxxxx](#summary-and-next-steps)
-   [Xxxxxxx xxxxxx](#related-topics)

## Xxxxxx xxx xxxxxxx xxxxx xxxxxx

Xxxxxx x xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn631270) xxxxxx xxx xxx xxx xxxx xxxx xxx xxxx xx xx xxx-xxxxxxxxx xx xxx xxxxxxx xxxxx xxxxxx. Xxxx [**XxxxXxxxxxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn631269) xx xxxx xxx xxxxxx.

``` cs
private async void ComposeEmail(Windows.ApplicationModel.Contacts.Contact recipient, 
    string messageBody, 
    StorageFile attachmentFile)
{
    var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
    emailMessage.Body = messageBody;

    if (attachmentFile != null)
    {
        var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

        var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
            attachmentFile.Name,
            stream);

        emailMessage.Attachments.Add(attachment);
    }

    var email = recipient.Emails.FirstOrDefault&lt;Windows.ApplicationModel.Contacts.ContactEmail&gt;();
    if (email != null)
    {
        var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
        emailMessage.To.Add(emailRecipient);
    }

    await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        
}
```

## Xxxxxxx xxx xxxx xxxxx

Xxxx xxxxx xxx xxxxx xxx xxx xx xxxxxx xxx xxxxxxx xxxxx xxxxxx. Xxx xxxxxxxxxxx xx xxxxxxxxx xxxxxxxx xx xxx xx xxxxxxxxxx xxx xx xxxxx xxxxxxx, xxx [Xxxxxx xxxxxxxx](selecting-contacts.md). Xxx [**XxxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/JJ635275) xx xxxxxx x xxxx xx xxx xx xx xxxxx xxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxxxxxxxx xxxxxxxx](selecting-contacts.md)
* [Xxx xx xxxxxxxx xxxx Xxxxxxx Xxxxx xxx xxxxx xxxxxxx x xxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/Dn614994)
 

 




<!--HONumber=Mar16_HO1-->
