---
xxxxx: Xxxxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxxxx
X xxxxxx xxxxx xxx xxxx x xxx xx xxxxxxx xx xxxxxxxxx xxxxxx.

![Xxxxxxx xx xxxxxxx](images/controls_button_example.png)


<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**Xxxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)
-   [**XxxxxxXxxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx)
-   [**Xxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx)

## Xxxxxxx

Xxxx xxxxxxx xxxx xxx xxxxxxx, xxxxxx xxx xxxxxx, xx x xxxxxx. 

![Xxxxxxx xx xxxxxxx, xxxx xx x xxxxxx](images/controls_button_example_dialog.png)

## Xx xxxx xxx xxxxx xxxxxxx?

X xxxxxx xxxx xxx xxxx xxxxxxxx xx xxxxxxxxx xxxxxx, xxxx xx xxxxxxxxxx x xxxx.

Xxx'x xxx x xxxxxx xxxx xxx xxxxxx xx xx xxxxxxxx xx xxxxxxx xxxx; xxx x xxxx xxxxxxx. Xxx [Xxxxxxxxxx](hyperlinks.md) xxx xxxx xxxx.

> Xxxxxxxxx: Xxx xxxxxx xxxxxxxxxx, xxx xxxxxxx xxxxxxx "Xxxx" xxx "Xxxx". Xxx xxxxx xxxxx xx xxxxxxxxx xxxxxxxxxx xx xxxxxxxxxx xx xx xxxxx xxxxx, xxx x xxxx xxxxxx.

## Xxxxxx x xxxxxx

Xxxx xxxxxxx xxxxx x xxxxxx xxxx xxxxxxxx xx x xxxxx. 

Xxxxxx xxx xxxxxx xx XXXX.

```xaml
<Button Content="Submit" Click="SubmitButton_Click"/>
```

Xx xxxxxx xxx xxxxxx xx xxxx.

```csharp
Button submitButton = new Button();
submitButton.Content = "Submit";
submitButton.Click += SubmitButton_Click;

// Add the button to a parent container in the visual tree.
stackPanel1.Children.Add(submitButton);
```

Xxxxxx xxx Xxxxx xxxxx.

```csharp
private async void SubmitButton_Click(object sender, RoutedEventArgs e)
{
    // Call app specific code to submit form. For example:
    // form.Submit();
    Windows.UI.Popups.MessageDialog messageDialog = 
        new Windows.UI.Popups.MessageDialog("Thank you for your submission.");
    await messageDialog.ShowAsync();
}
```

### Xxxxxx xxxxxxxxxxx

Xxxx xxx xxx x Xxxxxx xxxx x xxxxxx xx xxxxxx, xx xxxxx x xxxx xxxxx xxxxxx xxxxx xxx xxxxxxx xx xxxx xx, xxx xxxxxx xxxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) xxxxx. Xx x xxxxxx xxx xxxxxxxx xxxxx, xxxxxxxx xxx Xxxxx xxx xx xxx Xxxxxxxx xxx xxxx xxxxxx xxx Xxxxx xxxxx.

Xxx xxxxxxxxx xxx'x xxxxxx xxx-xxxxx [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.pointerpressed.aspx) xxxxxx xx x Xxxxxx xxxxxxx xx xxx xxx Xxxxx xxxxxxxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/mt185584.aspx).

Xxx xxx xxxxxx xxx x xxxxxx xxxxxx xxx Xxxxx xxxxx xx xxxxxxxx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.clickmode.aspx) xxxxxxxx. Xxx xxxxxxx XxxxxXxxx xxxxx xx **Xxxxxxx**. Xx XxxxxXxxx xx **Xxxxx**, xxx Xxxxx xxxxx xxx'x xx xxxxxx xxxx xxx xxxxxxxx xx xxxxx. 


### Xxxxxx xxxxxxx

Xxxxxx xx x [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.aspx). Xxx XXXX xxxxxxx xxxxxxxx xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx), xxxxx xxxxxxx x xxxxxx xxxx xxxx xxx XXXX: `<Button>A button's content</Button>`. Xxx xxx xxx xxx xxxxxx xx xxx xxxxxx'x xxxxxxx. Xx xxx xxxxxxx xx x [XXXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.aspx), xx xx xxxxxxxx xx xxx xxxxxx. Xx xxx xxxxxxx xx xxxxxxx xxxx xx xxxxxx, xxx xxxxxx xxxxxxxxxxxxxx xx xxxxx xx xxx xxxxxx.

Xxxx, x **XxxxxXxxxx** xxxx xxxxxxxx xx xxxxx xx x xxxxxx xxx xxxx xx xxx xx xxx xxxxxxx xx x xxxxxx.

```xaml
<Button Click="Button_Click" 
        Background="#FF0D6AA3" 
        Height="100" Width="80">
    <StackPanel>
        <Image Source="Assets/Slices.png" Height="62"/>
        <TextBlock Text="Orange"  Foreground="White"
                   HorizontalAlignment="Center"/>
    </StackPanel>
</Button>
```

Xxx xxxxxx xxxxx xxxx xxxx.

![X xxxxxx xxxx xxxxx xxx xxxx xxxxxxx](images/button-orange.png)

## Xxxxxx x xxxxxx xxxxxx

X [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.aspx) xx x xxxxxx xxxx xxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) xxxxxx xxxxxxxxxx xxxx xxx xxxx xx'x xxxxxxx xxxxx xx'x xxxxxxxx. Xxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.delay.aspx) xxxxxxxx xx xxxxxxx xxx xxxx xxxx xxx XxxxxxXxxxxx xxxxx xxxxx xx xx xxxxxxx xxxxxx xx xxxxxx xxxxxxxxx xxx xxxxx xxxxxx. Xxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.repeatbutton.interval.aspx) xxxxxxxx xx xxxxxxx xxx xxxx xxxxxxx xxxxxxxxxxx xx xxx xxxxx xxxxxx. Xxxxx xxx xxxx xxxxxxxxxx xxx xxxxxxxxx xx xxxxxxxxxxxx.

Xxx xxxxxxxxx xxxxxxx xxxxx xxx XxxxxxXxxxxx xxxxxxxx xxxxx xxxxxxxxxx Xxxxx xxxxxx xxx xxxx xx xxxxxxxx xxx xxxxxxxx xxx xxxxx xxxxx xx x xxxx xxxxx.

```xaml
<StackPanel>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Increase_Click">Increase</RepeatButton>
    <RepeatButton Width="100" Delay="500" Interval="100" Click="Decrease_Click">Decrease</RepeatButton>
    <TextBlock x:Name="clickTextBlock" Text="Number of Clicks:" />
</StackPanel>
```

```csharp
private static int _clicks = 0;
private void Increase_Click(object sender, RoutedEventArgs e)
{
    _clicks += 1;
    clickTextBlock.Text = "Number of Clicks: " + _clicks;
}

private void Decrease_Click(object sender, RoutedEventArgs e)
{
    if(_clicks > 0)
    {
        _clicks -= 1;
        clickTextBlock.Text = "Number of Clicks: " + _clicks;
    }
}
```

## Xxxxxxxxxxxxxxx

-   Xxxx xxxx xxx xxxxxxx xxx xxxxx xx x xxxxxx xxx xxxxx xx xxx xxxx.
-   Xxx x xxxxxxx, xxxxxxxx, xxxx-xxxxxxxxxxx xxxx xxxx xxxxxxx xxxxxxxxx xxx xxxxxx xxxx xxx xxxxxx xxxxxxxx. Xxxxxxx xxxxxx xxxx xxxxxxx xx x xxxxxx xxxx, x xxxx.
-   Xx xxx xxxxxx'x xxxx xxxxxxx xx xxxxxxx, xxx xxxxxxx, xx xx xxxxxxxxx, xxxxxxxx xxx xxx xxxxxx xxxx xxxxxx xxx xxxx xxxx xxxxxx xx xxxxxxxx xxxxxx xx.
-   Xxx xxxxxxx xxxxxxx xxxx xxxx xxxxxxx, xxx x xxxxxxx xxxxxx xxxxx.
-   Xxxxx xxxxxx, xxxxx, xx xxxx xxxxxxx xxxxxxx xxxx xxxx xxxxxxx.
-   Xxx xxx xxxxxxx xxxx xxxxxx xxxx xxxxx xxxxxxxxxx xxxx xxx xx xxx xxxxxxxxx xxxxxxxxx.
-   Xxx xx xxxxxx xxxx xxxxx xx xx xxxxxxxxx xxxxxx xxxxxxxx xxxxx xxxxxx xxxx xxx, xxxxxxx xx xxxxxxxxxxx x xxxxxx xx xxxxxxxx xxxxx, xxxxxxxx xxxxx x [xxxxxx xxx xxx](app-bars.md).
-   Xxxxxx xxxx xxx xx xxx xxxxxxx xx xxx xxxx xx x xxxx, xxx xxxxxxx, Xxxxxx xxx Xxxxxx. Xx xxx xxxx xx xxxxxx xxxx xxxxxxx xx xxx xxxx, xxxxxxxx xxxxx [xxxxxxxxxx](checkbox.md) xx [xxxxx xxxxxxx](radio-button.md) xxxx xxxxx xxx xxxx xxx xxxxxx xxxxxxx, xxxx x xxxxxx xxxxxxx xxxxxx xx xxxxxxx xxxxx xxxxxxx.
-   Xxx xxx xxxxxxx xxxxxxx xxxxxx xx xxxxxxxx xxx xxxx xxxxxx xx xxxxxxxxxxx xxxxxx.
-   Xxxxxxxx xxxxxxxxxxx xxxx xxxxxxx. X xxxxxx'x xxxxx xx xxxxxxxxxxx xx xxxxxxx, xxx xxx xxx xxxxxxxxx xxx xxxxxxx xxxx xxxx xx xxx xxxxxx'x xxxxxxxxxx. X xxxxxx'x xxxxxxx xx xxxxxxx xxxx—xxx xxxxxxx, Xxxxxx xx Xxxxxx—xxx xxx xxxxx xxxxxxx xxx xxxx xxxx xx xxxx, xx xxx xx xxxx xxxx xxxx.
-   Xxxx xxxx xxxx xx xxx xxxx xxxxxxxxx xxxx x xxxxxx, xxx xxxxxx xxxxxxx xxxxx xxx xxxxxxxxxx xx xxxxxxx xxxxxxxx xx xxx xxxx. Xxxxxx, xxxxxxx, xxx xxxxxxxx xxx xxxxxxxx xx xxxxxx xxxxxx.
-   Xxxxxxx xxx xxxxxx'x xxxxxx xxxx xxx xxxx xxxx xx xxxxxxx xxx xxxxxx. Xxxxxxx xxx xxxxxx xx xxxxxxxxx xxxx xxx xxxx xxxxxxxx xxx xxxxxx, xxx xxx xxxx xxx xxx x xxxxxx'x xxxxxx xx xxxxxxx xxxx x xxxxxx xxxxx xxxxxxx xx.
-   Xxx'x xxx x xxxxxxx xxxxxx xx xxx xxxxx.
-   Xxx'x xxxxxx xxxxxx xxxx xxxxx xxx xxx xx xxxxxxx; xxx xxxxxxx, xxx'x xxxxxx xxx xxxx xx x xxxxxx xxxx xxxx "Xxxx" xx "Xxxxxxxx".
-   Xxx'x xxxx xxx xxxxxxx xxxxxx, xxxxx, xxx xxxxxx xxxxxx.
-   Xxx'x xxx xxx xxxx xxxxxxx xxxxxx x xxxxxx. Xxxx xxx xxxxxxx xxxxxxx xxx xxxx xx xxxxxxxxxx (xxxxxxx xxxx xxxx x xxxxxxx xxx xxxx xxxx).

## Xxxx xxxxxxx
Xxx xxxx xxxxxx xx x xxxxxx-xxxxxxxx XX xxxxxxxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxxxx xxxxxxx xxxxxx xxx xxxx xxxxx xx xxxxxxxxxx xxxxxxx xx xxx xxxx.

Xxx xxxxx xx xxx xxxxxxxxxx xxxxxxx (xxxxxxx xx-xxx xx xxxxxx) xxxxxxx xx xxx xxxxxx xxx xxxxxx xxxx.

## <span id="examples">
            </span>
            <span id="EXAMPLES">
            </span>Xxxxxxx


Xxx XX xxx xxx xxxxxx xxxx xxxxxx xx xxxxxxxxx xxx xxxx xxxxxx xxx xxxxx xxxx, xxx xxx xxxxxxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxxxxxxx xxxxxx xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xxxxx xxxxxxxxx xxxxxxxxxxx xxxxxxx:

Xxxxxxx
Xxxxx
![xxxxxx xxxx xx x xxxxx](images/nav-back-phone.png)
-   Xxxxxx xxxxxxx.
-   X xxxxxxxx xx xxxxxxxx xxxxxx xx xxx xxxxxx xx xxx xxxxxx.
-   Xxxxxx xxxx xxxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx xxxx.

<span id="Tablet">
            </span>
            <span id="tablet">
            </span>
            <span id="TABLET">
            </span>Xxxxxx
![xxxxxx xxxx xx x xxxxxx (xx xxxxxx xxxx)](images/nav-back-tablet.png)
-   Xxxxxx xxxxxxx xx Xxxxxx xxxx.

    Xxx xxxxxxxxx xx Xxxxxxx xxxx. Xxxxx xxx xxxx xxxxxx xxx xx xxxxxxx, xxxxxxx. Xxx [XX, Xxxxxx, Xxxxxx](#PC).

    Xxxxx xxx xxxxxx xxxxxxx xxxxxxx xx Xxxxxx xxxx xxx Xxxxxxx xxxx xx xxxxx xx **Xxxxxxxx &xx; Xxxxxx &xx; Xxxxxx xxxx** xxx xxxxxxx **Xxxx Xxxxxxx xxxx xxxxx-xxxxxxxx xxxx xxxxx xxxx xxxxxx xx x xxxxxx**.

-   X xxxxxxxx xxxxxx xx xxx xxxxxxxxxx xxx xx xxx xxxxxx xx xxx xxxxxx.
-   Xxxxxx xxxx xxxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx xxxx.

<span id="PC">
            </span>
            <span id="pc">
            </span>XX, Xxxxxx, Xxxxxx
![xxxxxx xxxx xx x xx xx xxxxxx](images/nav-back-pc.png)
-   Xxxxxxxx xx Xxxxxxx xxxx.

    Xxx xxxxxxxxx xx Xxxxxx xxxx. Xxx [Xxxxxx](#Tablet).

    Xxxxxxxx xx xxxxxxx. Xxxx xxx xx xx xxxxxx xx.

    Xxxxx xxx xxxxxx xxxxxxx xxxxxxx xx Xxxxxx xxxx xxx Xxxxxxx xxxx xx xxxxx xx **Xxxxxxxx &xx; Xxxxxx &xx; Xxxxxx xxxx** xxx xxxxxxx **Xxxx Xxxxxxx xxxx xxxxx-xxxxxxxx xxxx xxxxx xxxx xxxxxx xx x xxxxxx**.

-   X xxxxxxxx xxxxxx xx xxx xxxxx xxx xx xxx xxx.
-   Xxxx xxxxxxxxxx xxxxxx xxx xxx xxxx. Xxxx xxx xxxxxxx xxx-xx-xxx xxxxxxxxxx.

Xxxxxxx Xxx
![xxxxxx xxxx xx x xxxxxxx xxx](images/nav-back-surfacehub.png)
-   Xxxxxx xxxxxxx.
-   X xxxxxxxx xxxxxx xx xxx xxxxxx xx xxx xxxxxx.
-   Xxxx xxxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx xxxx.

 

## <span id="Recommendations">
            </span>
            <span id="recommendations">
            </span>
            <span id="RECOMMENDATIONS">
            </span>Xxxxxxxxxxxxxxx


-   Xxxxxx xxxx xxxxxxxxxx.

    Xx xxxx xxxxxxxxxx xx xxx xxxxxxx, xxxx xxx xx xxxxxxxx xx xxx xxxxxx xxxx xxxxx, xxx xx-xxx xxxx xxxxxxxxxx xxxxxxx xx xxx xxxxxxxxxx.

-   Xxxxxx xxx xxxxx xxx xxxx xxxxxx xx Xxxxxxx xxxx.

    Xx-xxx xxxx xxxxxxxxxx xxxxxxx xx xxxxxxxxxx, xxx-xx-xxx xxxx xxxxxxxxxx xx xxx xxxxxxxxx.

    **Xxxx**  Xx Xxxxxx xxxx, xxx xxxxx xxx xx xxxxxxxxx xxxx x xxxx xxxxxx xxxx xxxx xxx xxx xx xxx xxxxxx xx xxxxx x xxxxx xxxxxxx xxxx xxx xxx xx xxx xxxxxx. Xx xxxxx xxxxxxxxxxx xxx xxxxxxxxx, xxx xxxxx xxx xxxx xxxxxx xx xxx xxxxxxxxx xx Xxxxxx xxxx.

     

-   Xxxx xx xxxxxxx xxx xxxxx xxx xxxx xxxxxx xx Xxxxxxx xxxx xxxx xx-xxx xxxxxxxxxx xxxxxxx xx xxxxxxxx xx xxxxxxxxxxx.

    Xxxxxxxx x xxxxx xxxxxxxxxx xx xxx xxxx xxxx xxxx xxxx xxxxxxxxx xxxx xx xxx xx xxxxxxxx.

-   Xxxx xxxx xxxxxxx xxxxxx xx xxxx xxx xxxx xx xxx xxxx xxxxx, xx, xx xxx xx Xxxxxxx xxxx, xx xxx xxxxxxxxxxx xxxxxxxxx xxx.

    Xxxxx xxxxx xxx xxxxxxxx xx xxxx xxxxxxxxxx xx xxx xxxxxxxxx, xxxxxxxxxx, xxx xxxxxxxxxxx.

## Xxxxxxx xxxxxxxx

- [Xxxxx xxxxxxx](radio-button.md)
- [Xxxxxx xxxxxxxx](toggles.md)
- [Xxxxx xxxxx](checkbox.md)

**Xxx xxxxxxxxxx (XXXX)**
- [**Xxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.button.aspx)


<!--HONumber=Mar16_HO1-->
