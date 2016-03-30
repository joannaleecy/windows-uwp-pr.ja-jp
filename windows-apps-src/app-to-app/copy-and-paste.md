---
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxxx xxx xxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxx xxx xxxxxxxxx.
xxxxx: Xxxx xxx xxxxx
xx.xxxxxxx: XYYYXXYY-XYYX-YYYY-XYYX-XYYYXXYYYXXX
---
#Xxxx xxx xxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxxx xxx xxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxxx xxx xxxxxxxxx. Xxxx xxx xxxxx xx xxx xxxxxxx xxx xx xxxxxxxx xxxx xxxxxx xxxxxxx xxxx, xx xxxxxx xx xxx, xxx xxxxxx xxxxx xxx xxx xxxxxxx xxxxxxxxx xxxxxxxxxx xx xxxx xxxxxx.

## Xxxxx xxx xxxxx-xx xxxxxxxxx xxxxxxx


Xx xxxx xxxxx, xxx xx xxx xxxx xx xxxxx xxxx xx xxxxxxx xxxxxxxxx xxxxxxxxxx. Xxxx xx xxx xxxxxxx XXXX xxxxxxxx xxx xxx xxx xx xxxxxx xxxx xxxxxxx xxxxxxx xxxxxxxxx xxxxxxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxxxx xxxxxxxx xxx xxxxxxxxx, xxx xxx [xxxxxxxx xxxx][ControlsList].

## Xxx xxx xx

Xxxxx, xxxxxxx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.XxxxXxxxxxxx**][DataTransfer] xxxxxxxxx xx xxxx xxx. Xxxx, xxx xx xxxxxxxx xx xxx [**XxxxXxxxxxx**][DataPackage] xxxxxx. Xxxx xxxxxx xxxxxxxx xxxx xxx xxxx xxx xxxx xxxxx xx xxxx xxx xxx xxxxxxxxxx (xxxx xx x xxxxxxxxxxx) xxxx xxx xxxx xx xxxxxxx.

<!-- For some reason, the snippets in this file are all inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
DataPackage dataPackage = new DataPackage();
```

## Xxxx xxx xxx

Xxxx xxx xxx (xxxx xxxxxxxx xx xx xxxx) xxxx xxxxxx xxxxxxx xxx xxxx. Xxxxxx xxxxx xxxxxxxxx xxx xxxx xxxxx xxx [**XxxxXxxxxxx.XxxxxxxxxXxxxxxxxx**][XxxxxxxxxXxxxxxxxx] xxxxxxxx.

```xx
// xxxx 
xxxxXxxxxxx.XxxxxxxxxXxxxxxxxx = XxxxXxxxxxxXxxxxxxxx.Xxxx;
// xx xxx
xxxxXxxxxxx.XxxxxxxxxXxxxxxxxx = XxxxXxxxxxxXxxxxxxxx.Xxxx;
```

Xxxx, xxx xxx xxx xxx xxxx xxxx x xxxx xxx xxxxxxxx xx xxx [**XxxxXxxxxxx**][XxxxXxxxxxx] xxxxxx. Xx xxxx xxxx xx xxxxxxxxx xx xxx **XxxxXxxxxxx** xxxxx, xxx xxx xxx xxx xx xxx xxxxxxxxxxxxx xxxxxxx xx xxx **XxxxXxxxxxx** xxxxxx. Xxxx'x xxx xx xxx xxxx:

```xx
xxxxXxxxxxx.XxxXxxx("Xxxxx Xxxxx!");
```

Xxx xxxx xxxx xx xx xxx xxx [**XxxxXxxxxxx**][XxxxXxxxxxx] xx xxx xxxxxxxxx xx xxxxxxx xxx xxxxxx [**Xxxxxxxxx.XxxXxxxxxx**][XxxXxxxxxx] xxxxxx.

```xx
Xxxxxxxxx.XxxXxxxxxx(xxxxXxxxxxx);
```
## Xxxxx

Xx xxx xxx xxxxxxxx xx xxx xxxxxxxxx, xxxx xxx xxxxxx [**Xxxxxxxxx.XxxXxxxxxx**[XxxXxxxxxx] xxxxxx. Xxxx xxxxxx xxxxxxx x [**XxxxXxxxxxxXxxx**][XxxxXxxxxxxXxxx] xxxx xxxxxxxx xxx xxxxxxx. Xxxx xxxxxx xx xxxxxx xxxxxxxxx xx x [**XxxxXxxxxxx**][XxxxXxxxxxx] xxxxxx, xxxxxx xxxx xxx xxxxxxxx xxx xxxx-xxxx. Xxxx xxxx xxxxxx, xxx xxx xxx xxxxxx xxx [**XxxxxxxxxXxxxxxx**][XxxxxxxxxXxxxxxx] xx xxx [**Xxxxxxxx**][Xxxxxxxx] xxxxxx xx xxxxxxxx xxxx xxxxxxx xxx xxxxxxxxx. Xxxx, xxx xxx xxxx xxx xxxxxxxxxxxxx **XxxxXxxxxxxXxxx** xxxxxx xx xxx xxx xxxx.

```xx
XxxxXxxxxxxXxxx xxxxXxxxxxxXxxx = Xxxxxxxxx.XxxXxxxxxx();
xx (xxxxXxxxxxxXxxx.Xxxxxxxx(XxxxxxxxXxxxXxxxxxx.Xxxx))
{
    xxxxxx xxxx = xxxxx xxxxXxxxxxxXxxx.XxxXxxxXxxxx();
    // Xx xxxxxx xxx xxxx xxxx xxxx xxxxxxx, xxx xxxx x XxxxXxxxx xxxxxxx
    XxxxXxxxxx.Xxxx = "Xxxxxxxxx xxx xxxxxxxx: " + xxxx;
}
```

## Xxxxx xxxxxxx xx xxx xxxxxxxxx

Xx xxxxxxxx xx xxxx xxx xxxxx xxxxxxxx, xxx xxx xxxx xxxx xx xxxxx xxxxxxxxx xxxxxxx. Xx xxxx xx xxxxxxxx xxx xxxxxxxxx'x [**Xxxxxxxxx.XxxxxxxXxxxxxx**][XxxxxxxXxxxxxx] xxxxx.

```cs
Clipboard.ContentChanged += (s, e) => 
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        string text = await dataPackageView.GetTextAsync();
        // To output the text from this example, you need a TextBlock control
        TextOutput.Text = "Clipboard now contains: " + text;
    }
}
```

<!-- LINKS --> 
[DataTransfer]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.aspx 
[DataPackage]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx 
[DataPackageView]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.aspx
[DataPackagePropertySet]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx 
[DataRequest]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx 
[DataRequested]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx 
[FailWithDisplayText]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx
[ShowShareUi]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx
[RequestedOperation]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.requestedoperation.aspx 
[ControlsList]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/mt185406.aspx 
[SetContent]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.setcontent.aspx 
[GetContent]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.getcontent.aspx
[AvailableFormats]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.availableformats.aspx 
[Contains]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackageview.contains.aspx
[ContentChanged]: https://msdn.microsoft.com/en-us/library/windows/apps/xaml/windows.applicationmodel.datatransfer.clipboard.contentchanged.aspx 

<!--HONumber=Mar16_HO1-->
