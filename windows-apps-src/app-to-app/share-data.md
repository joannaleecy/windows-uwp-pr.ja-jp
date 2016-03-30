---
xxxxxxxxxxx: Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxx Xxxxx xxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.
xxxxx: Xxxxx xxxx
xx.xxxxxxx: YYYYYXYX-XXYY-YXYY-YYXX-YXYYYYXYYYYY
---

# Xxxxx xxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxx xxxxxxxx xxx xx xxxxxxx xxx Xxxxx xxxxxxxx xx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx. Xxx Xxxxx xxxxxxxx xx xx xxxx xxx xx xxxxxxx xxxxx xxxx, xxxx xx xxxx, xxxxx, xxxxxx, xxx xxxxxx, xxxxxxx xxxx. Xxx xxxxxxx, x xxxx xxxxx xxxx xx xxxxx x xxxxxxx xxxx xxxxx xxxxxxx xxxxx x xxxxxx xxxxxxxxxx xxx, xx xxxx x xxxx xx x xxxxx xxx xx xxxxx xx xxxxx.

## Xxx xx xx xxxxx xxxxxxx

Xxx x [**XxxxXxxxxxxxx**][DataRequested] xxxxx xxxxxxx xx xx xxxxxx xxxxxxxx x xxxx xxxxxxx xxxxx. Xxxx xxx xxxxx xxxxxx xxxx xxx xxxx xxxx x xxxxxxx xx xxxx xxx (xxxx xx x xxxxxx xx xxx xxx xxxxxxx) xx xxxxxxxxxxxxx xx x xxxxxxxx xxxxxxxx (xx xxx xxxx xxxxxxxx x xxxxx xxx xxxx x xxxx xxxxx, xxx xxxxxxx).

[!xxxx-xx[Xxxx](./code/share_data/cs/MainPage.xaml.cs#SnippetPrepareToShare)]

Xxxx x [**XxxxXxxxxxxxx**][DataRequested] xxxxx xxxxxx, xxxx xxx xxxxxxxx x [**XxxxXxxxxxx**][DataRequest] xxxxxx. Xxxx xxxxxxxx x [**XxxxXxxxxxx**][DataPackage] xxxx xxx xxx xxx xx xxxxxxx xxx xxxxxxx xxxx xxx xxxx xxxxx xx xxxxx. Xxx xxxx xxxxxxx x xxxxx xxx xxxx xx xxxxx. X xxxxxxxxxxx xx xxxxxxxx, xxx xxxxxxxxxxx.

[!xxxx-xx[Xxxx](./code/share_data/cs/MainPage.xaml.cs#SnippetCreateRequest)]

## Xxxxxx xxxx

Xxx xxx xxxxx xxxxxxx xxxxx xx xxxx, xxxxxxxxx:

-   Xxxxx xxxx
-   Xxxxxxx Xxxxxxxx Xxxxxxxxxxx (XXXx)
-   XXXX
-   Xxxxxxxxx xxxx
-   Xxxxxxx
-   Xxxxx xxxx
-   Xxxxx
-   Xxxxxx xxxxxxxxx-xxxxxxx xxxx

Xxx [**XxxxXxxxxxx**][DataPackage] xxxxxx xxx xxxxxxx xxx xx xxxx xx xxxxx xxxxxxx, xx xxx xxxxxxxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx xxxxxxx xxxx.

[!xxxx-xx[Xxxx](./code/share_data/cs/MainPage.xaml.cs#SnippetSetContent)]

## Xxx xxxxxxxxxx

Xxxx xxx xxxxxxx xxxx xxx xxxxxxx, xxx xxx xxxxxx x xxxxxxx xx xxxxxxxxxx xxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx xxxxx xxx xxxxxxx xxxxx xxxxxx. Xxxxx xxxxxxxxxx xxxx xxxxxx xxxx xxxxxxx xxx xxxx xxxxxxxxxx. Xxx xxxxxxx, x xxxxxxxxxxx xxxxx xxxx xxx xxxx xx xxxxxxx xxxxxxx xxxx xxxx xxxx xxx xxx. Xxxxxx x xxxxxxxxx xxxx xxxxxxx xx xxxxx xx x xxxx xx x xxx xxxx xxxxxxxx x xxxxxx xxxxxxxxx xx xxx xxxx. Xxx xxxx xxxxxxxxxxx, xxx [**XxxxXxxxxxx.XxxxXxxxxxxXxxxxxxxXxx**][DataPackagePropertySet].

Xxx xxxxxxxxxx xxxxxx xxx xxxxx xxx xxxxxxxx. Xxx xxxxx xxxxxxxx xx xxxxxxxxx xxx xxxx xx xxx.

[!xxxx-xx[Xxxx](./code/share_data/cs/MainPage.xaml.cs#SnippetSetProperties)]

## Xxxxxx xxx xxxxx XX

X XX xxx xxxxxxx xx xxxxxxxx xx xxx xxxxxx. Xx xxxxxx xx, xxxx xxx [**XxxxXxxxxXX**][ShowShareUi] xxxxxx.

[!xxxx-xx[Xxxx](./code/share_data/cs/MainPage.xaml.cs#SnippetShowUI)]

## Xxxxxx xxxxxx

Xx xxxx xxxxx, xxxxxxx xxxxxxx xx x xxxxxxxxxxxxxxx xxxxxxx. Xxxxxxx, xxxxx'x xxxxxx x xxxxxx xxxx xxxxxxxxx xxxxxxxxxx xxxxx xxxxxx. Xxx xxxxxxx, xxx xxx xxxxx xxxxxxx xxx xxxx xx xxxxxx xxxxxxx xxx xxxxxxx xxx xxx xxxx xxxx'x xxxxxx xxx. Xx xxxxxx xxxxx xxxxxxxxxx, xxx xxx [**XxxxXxxxXxxxxxxXxxx**][FailWithDisplayText] xxxxxx, xxxxx xxxx xxxxxxx x xxxxxxx xx xxx xxxx xx xxxxxxxxx xxxx xxxxx.

## Xxxxx xxxxx xxxx xxxxxxxxx

Xxxxxxxxx, xx xxxxx xxx xxxx xxxxx xx xxxxxxx xxx xxxx xxxx xxx xxxx xxxxx xx xxxxx xxxxx xxxx. Xxx xxxxxxx, xx xxxx xxx xxxxxxxx xxxxxxx x xxxxx xxxxx xxxx xx xxxxxxx xxxxxxxxx xxxxxxxx xxxxxxx, xx'x xxxxxxxxxxx xx xxxxxx xxx xxxxx xxxxxx xxxxxx xxx xxxx xxxxx xxxxx xxxxxxxxx.

Xx xxxxx xxxx xxxxxxx, x [**XxxxXxxxxxx**][DataPackage] xxx xxxxxxx x xxxxxxxx — x xxxxxxxx xxxx xx xxxxxx xxxx xxx xxxxxxxxx xxx xxxxxxxx xxxx. Xx xxxxxxxxx xxxxx x xxxxxxxx xxx xxxx xxxx xxx xxxx x xxxx xxxxx xx xxxxx xx xxxxxxxx-xxxxxxxxx.

<!-- For some reason, this snippet was inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
async void OnDeferredImageRequestedHandler(DataProviderRequest request)
{
    // Provide updated bitmap data using delayed rendering
    if (this.imageStream != null)
    {
        DataProviderDeferral deferral = request.GetDeferral();
        InMemoryRandomAccessStream inMemoryStream = new InMemoryRandomAccessStream();

        // Decode the image.
        BitmapDecoder imageDecoder = await BitmapDecoder.CreateAsync(this.imageStream);

        // Re-encode the image at 50% width and height.
        BitmapEncoder imageEncoder = await BitmapEncoder.CreateForTranscodingAsync(inMemoryStream, imageDecoder);
        imageEncoder.BitmapTransform.ScaledWidth = (uint)(imageDecoder.OrientedPixelHeight * 0.5);
        imageEncoder.BitmapTransform.ScaledHeight = (uint)(imageDecoder.OrientedPixelHeight * 0.5);
        await imageEncoder.FlushAsync();

        request.SetData(RandomAccessStreamReference.CreateFromStream(inMemoryStream));
        deferral.Complete();
    }
}
```

## Xxxxxxx xxxxxx
* [Receive data](receive-data.md)<!-- LINKS -->
* [DataPackage]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackage.aspx 
* [DataPackagePropertySet]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datapackagepropertyset.aspx 
* [DataRequest]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.aspx 
* [DataRequested]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.datarequested.aspx 
* [FailWithDisplayText]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datarequest.failwithdisplaytext.aspx
* [ShowShareUi]: https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.datatransfer.datatransfermanager.showshareui.aspx
 

<!--HONumber=Mar16_HO1-->
