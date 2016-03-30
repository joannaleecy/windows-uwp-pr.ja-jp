---
xxxxxxxxxxx: Xxxx xxxxx xxxxx xxx xxx xx xxxxxx xxx xxxxxxx XXX xxxxxx xx xxxxx xxx xxxx xx xxxx xx XXX xxxxxxx. Xxx xxx xxx-xxxxxxxx xxx xxxxxx xx xxx XXX xxxx xxxx xxxxxx xxxxxxx xxx xxxxxx. Xxx xxxxxxx xxxx xxx xx xxxx xxxxx xxx xxxx xxxx xxx xxxx xxxxxx.
xxxxx: Xxxx xx XXX xxxxxxx
xx.xxxxxxx: YXYXYYYX-YXXY-YYYY-YYYY-XYYXYYYYXYXY
xxxxxxxx: xxxxxxxx, XXX, xxxx
---

# Xxxx xx XXX xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxx xxxxx xxx xxx xx xxxxxx xxx xxxxxxx XXX xxxxxx xx xxxxx xxx xxxx xx xxxx xx XXX xxxxxxx. Xxx xxx xxx-xxxxxxxx xxx xxxxxx xx xxx XXX xxxx xxxx xxxxxx xxxxxxx xxx xxxxxx. Xxx xxxxxxx xxxx xxx xx xxxx xxxxx xxx xxxx xxxx xxx xxxx xxxxxx.

## Xxxxxx xxx xxxxxxx XXX xxxxxx

Xxxxxx x xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642160) xxxxxx xxx xxx xxx xxxx xxxx xxx xxxx xx xx xxx-xxxxxxxxx xx xxx xxxxxxx xxxxx xxxxxx. Xxxx [**XxxxXxxxxxxXxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn642160manager-showcomposesmsmessageasync) xx xxxx xxx xxxxxx.

```cs
private async void ComposeSms(Windows.ApplicationModel.Contacts.Contact recipient, 
    string messageBody, 
    StorageFile attachmentFile, 
    string mimeType)
{
    var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
    chatMessage.Body = messageBody;

    if (attachmentFile != null)
    {
        var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);

        var attachment = new Windows.ApplicationModel.Chat.ChatMessageAttachment(
            mimeType,
            stream);

        chatMessage.Attachments.Add(attachment);
    }

    var phone = recipient.Phones.FirstOrDefault&lt;Windows.ApplicationModel.Contacts.ContactPhone&gt;();
    if (phone != null)
    {
        chatMessage.Recipients.Add(phone.Number);
    }
    await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
}
```

## Xxxxxxx xxx xxxx xxxxx

Xxxx xxxxx xxx xxxxx xxx xxx xx xxxxxx xxx xxxxxxx XXX xxxxxx. Xxx xxxxxxxxxxx xx xxxxxxxxx xxxxxxxx xx xxx xx xxxxxxxxxx xxx xx XXX xxxxxxx, xxx [Xxxxxx xxxxxxxx](selecting-contacts.md). Xxxxxxxx xxx [Xxxxxxxxx Xxxxxxx xxx xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619979) xxxx XxxXxx xx xxx xxxx xxxxxxxx xx xxx xx xxxx xxx xxxxxxx XXX xxxxxxxx xx xxxxx x xxxxxxxxxx xxxx.

## Xxxxxxx xxxxxx

* [Xxxxxx xxxxxxxx](selecting-contacts.md)


<!--HONumber=Mar16_HO1-->
