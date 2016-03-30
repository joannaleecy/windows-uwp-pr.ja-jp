---
xxxxx: Xxx xxxx/xxxxxxx xxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxx xxx xxx xxxxxxx xxx

Xxxxxxx xxxx (xxxx xxxxxx "xxx xxxx") xxxxxxx xxxxx xxxx xxxx xxxxxx xx xxxx xxx'x xxxx xxxxxx xxxxx, xxx xxx xx xxxx xx xxxx xxxxxxxx xx xxxxxxx xxxx xxx xxxxxxxx xx xxx xxxx'x xxxxxxx, xxxx xx x xxxxx xxxxxxxxx xx xxxxxxx xxxx. Xxxx xxx xxxx xx xxxx xxx xxxxxxxxxx xxxxx xxx xxxxx xx xxxxxxx xxx xxxxxxxx. Xxxxxxx xxxx xxx xx xxxx xxxx xxx xxxxxxxxxx xxxxxxx.

![Xxxxxxx xx x xxxxxxx xxx xxxx xxxxx](images/controls_appbar_icons.png)

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxxxxXxx **](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.commandbar.aspx)
-   [**XxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx)
-   [**XxxXxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx)
-   [**XxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx)

## Xx xxxx xxx xxxxx xxxxxxx

Xxx XxxxxxxXxx xxxxxxx xx x xxxxxxx-xxxxxxx, xxxxxxxx, xxxxx-xxxxxx xxxxxxx xxxx xxx xxxxxxx xxxx xxxxxxx xxxxxxx, xxxx xx xxxxxx, xxxxxxxx xxxx, xx xxxx xxxxxx, xx xxxx xx xxxxxx xxxxxxxx xxxx xx [XxxXxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarbutton.aspx), [XxxXxxXxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbartogglebutton.aspx), xxx [XxxXxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.appbarseparator.aspx) xxxxxxxx.

XXXX xxxxxxxx xxxx xxx XxxXxx xxxxxxx xxx xxx XxxxxxxXxx xxxxxxx. Xxx xxxxxx xxx xxx XxxXxx xxxx xxxx xxx xxx xxxxxxxxx x Xxxxxxxxx Xxxxxxx Y xxx xxxx xxxx xxx XxxXxx, xxx xxxx xx xxxxxxxx xxxxxxx. Xxx xxx xxxx xx Xxxxxxx YY, xx xxxxxxxxx xxxxx xxx XxxxxxxXxx xxxxxxx xxxxxxx. Xxxx xxxxxxxx xxxxxxx xxx xxx xxxxx xxx XxxxxxxXxx xxxxxxx.

## Xxxxxxxx

![Xxxxxxx Y xx xxx xxx xxxxxxxxx](images/AppbarGuidelines_Placement1.png)

## Xxxxxxx

Xx xxxxxxx, xxx xxxxxxx xxx xxxxx x xxx xx xxxx xxxxxxx xxx x "xxx xxxx" xxxxxx, xxxxx xx xxxxxxxxxxx xx xx xxxxxxxx \[•••\]. Xxxx'x xxx xxxxxxx xxx xxxxxxx xx xxx xxxxxxx xxxx xxxxx xxxxx. Xx'x xxxxx xx xxx xxxxxxx, xxxxxx, xxxxxxx xxxxx.

![X xxxxxx xxxxxxx xxx](images/command-bar-compact.png)

Xxx xxxxxxx xxx xxx xxxx xx xxxxx xx x xxxxxx, xxxxxxx xxxxx xxxx xxxxx xxxx xxxx. Xxx xxx [Xxxx xxx xxxxxx xxxxxx](#open-and-closed-states) xxxxxxx xxx xxxx xxxx. 

![X xxxxxx xxxxxxx xxx](images/command-bar-minimal.png)

Xxxx'x xxx xxxx xxxxxxx xxx xx xxx xxxx xxxxx. Xxx xxxxxx xxxxxxxx xxx xxxx xxxxx xx xxx xxxxxxx.

![X xxxxxx xxxxxxx xxx](images/commandbar_anatomy_open.png)

Xxx xxxxxxx xxx xx xxxxxxx xxxx Y xxxx xxxxx:
- Xxx "xxx xxxx" \[•••\] xxxxxx xx xxxxx xx xxx xxxxx xx xxx xxx, xxx xx xxxxxx xxxxxxx. Xxxxxxxx xxx "xxx xxxx" \[•••\] xxxxxx xxx Y xxxxxxx: xx xxxxxxx xxx xxxxxx xx xxx xxxxxxx xxxxxxx xxxxxxx, xxx xx xxxxx xxx xxxxxxxx xxxx xx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxx.
- Xxx xxxxxxx xxxx xx xxxxxxx xx xxx xxxx xxxx xx xxx xxx. Xx xx xxxxx xx xxx Xxxxxxx xxxxxxxx xx xxxxxxxxx.
- Xxx xxxxxxx xxxxxxx xxxx xx xxxxxxx xx xxx xxxxx xxxx xx xxx xxx, xxxx xx xxx "xxx xxxx" \[•••\] xxxxxx. Xx xx xxxxx xx xxx XxxxxxxXxxxxxxx xxxxxxxx xx xxxxxxxxx.  
- Xxx xxxxxxxx xxxx xx xxxxx xxxx xxxx xxx xxxxxxx xxx xx xxxx xxx xxx XxxxxxxxxXxxxxxxx xxxxxxxx xx xxxxxxxxx.

Xxx xxxxxx xx xxxxxxxx xxxx xxx [XxxxXxxxxxxxx]() xx **XxxxxXxXxxx**.

## Xxxxxx x xxxxxxx xxx
Xxxx xxxxxxx xxxxxxx xxx xxxxxxx xxx xxxxx xxxxxxxxxx.

```xaml
<CommandBar>
    <AppBarToggleButton Icon="Shuffle" Label="Shuffle" Click="AppBarButton_Click" />
    <AppBarToggleButton Icon="RepeatAll" Label="Repeat" Click="AppBarButton_Click"/>
    <AppBarSeparator/>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Forward" Label="Forward" Click="AppBarButton_Click"/>

    <CommandBar.SecondaryCommands>
        <AppBarButton Icon="Like" Label="Like" Click="AppBarButton_Click"/>
        <AppBarButton Icon="Dislike" Label="Dislike" Click="AppBarButton_Click"/>
    </CommandBar.SecondaryCommands>

    <CommandBar.Content>
        <TextBlock Text="Now playing..." Margin="12,14"/>
    </CommandBar.Content>
</CommandBar>
```

## Xxxxxxxx xxx xxxxxxx
Xxx XxxxxxxXxx xxxxxxx xxx Y xxxxxxxxxx xxx xxx xxx xx xxx xxxxxxxx xxx xxxxxxx: [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx), [**XxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx), xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.contentcontrol.content.aspx). 

Xxxx xxxxxxxxx xx xxx xxxxxxx xx xxx xxxxxxx xxx xxxxx xx xxxxx xxxxxxxx.

### Xxxxxxx xxxxxxx xxx xxxxxxxx

Xx xxxxxxx, xxxxx xxx xxx xx xxx xxxxxxx xxx xxx xxxxx xx xxx **XxxxxxxXxxxxxxx** xxxxxxxxxx. Xxxxx xxxxxxxx xxx xxxxx xx xxx xxxx xx xxx "xxx xxxx" \[•••\] xxxxxx, xx xxxx xx xxxx xxx xxxxxx xxxxx. Xxxxx xxx xxxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxx xx xxxxxx xxxxxxx xx xxx xxx, xx xxx xxxxxx xxxxx. Xx xxx xxxxxxxx xxxxxxx (YYY xxx xxxxx), xxxxxxx Y-Y xxxxx xxxx xxx xx xxx xxxxxxx xxx'x xxxxxx xxxxx, xxxxxxxxx xx xxxxx xx-xxxxxx XX.

Xxx xxx xxx xxxxxxxx xx xxx **XxxxxxxxxXxxxxxxx** xxxxxxxxxx, xxx xxxxx xxxxx xxx xxxxx xx xxx xxxxxxxx xxxx. Xxxxx xxxx xxxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxx xxxx.

Xxx xxxxxxx xxxxxxxx xxxx xx xxxxxx xx xx xxxxxxxx xxxx xxx xxx. Xxx xxx xxxxxx xxx xxxxxxx xx xxxxxxx xxx [**XxxxxxxXxxXxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.commandbaroverflowpresenterstyle.aspx) xxxxxxxx xx x [Xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) xxxx xxxxxxx xxx [**XxxxxxxXxxXxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbaroverflowpresenter.aspx).

Xxx xxx xxxxxxxxxxxxxxxx xxxx xxxxxxxx xxxxxxx xxx XxxxxxxXxxxxxxx xxx XxxxxxxxxXxxxxxxx xx xxxxxx. Xxxxxxx, xxxxxxxx xx xxx xxxxxxxxxxxxx xxxx xxxx xx xxx xx xxx xxxxxxxx xxxx xx xxx xxxxxxx xxx xxxxx xxxxxxx.

### Xxx xxx xxxxxxx

Xxxx xxx XxxxxxxXxxxxxxx xxx XxxxxxxxxXxxxxxxx xxx xx xxxxxxxxx xxxx xxxx [**XxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [**XxxXxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx), xxx [**XxxXxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) xxxxxxx xxxxxxxx. Xxxxx xxxxxxxx xxx xxxxxxxxx xxx xxx xx x xxxxxxx xxx, xxx xxxxx xxxxxxxxxx xxxxxxx xxxxxxxxx xx xxxxxxx xxx xxxxxxx xx xxxx xx xxx xxxxxx xxxxx xx xxxxxxxx xxxx.

Xxx xxx xxx xxxxxx xxxxxxxx xxx xxxxxxxxxxxxx xx xx xxxx xxx xxxxxxxxxx xxxxx. Xxxx xxxx xxx xxxxx; xxxxxx xxx xxxxxxx. Xx xxxxxxx, xxx xxxx xxxxx xx xxxxx. Xxxx xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.iscompact.aspx) xxxxxxxx xx xxx xx **xxxx**, xxx xxxx xxxxx xx xxxxxx. Xxxx xxxx xx x XxxxxxxXxx xxxxxxx, xxx xxxxxxx xxx xxxx xxx xxxxxx'x XxXxxxxxx xxxxxxxx xxxxxxxxxxxxx xx xxx xxxxxxx xxx xx xxxxxx xxx xxxxxx.

Xxxx xxx xxxxx xx xxx xxx xxxxxx xx xxx xxxxxxxx xxxx (XxxxxxxxxXxxxxxxx), xx'x xxxxx xx xxxx xxxx. Xxxx'x xxx xxxx xxx xxx xxxxxx xxxxxx xxxxx xx xxx xxxxxx xxxxx xx x xxxxxxx xxxxxxx (xxx), xxx xx xxx xxxxxxxx xxxx xx x xxxxxxxxx xxxxxxx (xxxxxx).

![Xxx xxx xxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx](images/app-bar-toggle-button-two-modes.png)

- *Xx xxxxx xx x xxxxxxx xxxx xxxxx xxxxxx xxxxxxxxxxxx xxxxxx xxxxx, xx'x xxxx xx xxxx xxxx xxxxxxx xx x xxxxxxxxxx xxxxxxxx.* 
- *Xx xxxxxxxxxxx xxxxxxx Xxxxxx, Xxx, xxx XX xxxxxxxx xx xxx xxxx xx Xxxxxx, Xx, xxx Xxxxxx. Xxxxxxxxxxx xxxxx xxxxx xxx xxxxxxxxxx xx xxxx xxxxxx xxx xxxxxx xxx xxxxx xxxx xxxxxxxx xxxxx xxxxxxxxx xx xxx xxxxxxxxxx xxxx xxx xx xxx.*

### Xxxxx xxxxxxx

Xxx xxx xxx xxx XXXX xxxxxxxx xx xxx xxxxxxx xxxx xx xxxxxxx xxx **Xxxxxxx** xxxxxxxx. Xx xxx xxxx xx xxx xxxx xxxx xxx xxxxxxx, xxx xxxx xx xxxxx xxxx xx x xxxxx xxxxxxxxx xxx xxxx xxx xxxxx xxx xxxxxx xxxxx xx xxx Xxxxxxx xxxxxxxx.

Xxxx xxxxx xxx xxxx xxxxxxx xxxxxxxx xxx xxxxxxx, xxx xxxxxxx xxxxxxxx xxxx xxxxxxxxxx xxx xxx xxxxx xxx xxxxxxx xx xx xxxxxxx.

Xxxx xxx [**XxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) xx **Xxxxxxx**, xxx xxxxxxx xxx xx xxxxxxx xx xx xx xxxxxx xxxx xxx xxxxxxx xxxx xx xxx xxxxxxx xxx. Xxx xxxxxx xxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx) xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) xxxxxx xx xxxx xx xxxx xxxxx xx xxx XX xx xxx xxxxxxx xxxx xx xxxx xxxx xxxx'x xxxxxxx. Xxx xxx [Xxxx xxx xxxxxx xxxxxx](#open-and-closed-states) xxxxxxx xxx xxxx xxxx.

### Xxxxxx xxx xxxxxxxx

Xx x xxxx xxxxx xxx xx xxx xxx xxxxxx xx xxx xxxx xx xxx xx xxx xxxx xx xxxx xxxx xx xxxxxxx xxxx, xxxxxxxxxx xxx xxxxxxx xxxxxx xx xxx xxx xxxx xx'x xxxxxx. Xxx xxx xxxxxxx x xxxx-xxxxxx xxxxxxxxx (YxYYXX) xx xxx xxxx xxx x xxxxx xx xxxx xx xxx xxxxxxxxx xxxxxxxx xxxxx x xxxx xxxxx xxxxxx xxxxx. Xx XXXX, xxx xxxxxxx xxxx xxxxx xx xxxxxx xxxxxxxx, xxxx xxxx:

```xaml
<AppBarButton Icon="Back" Label="Areally&#x00AD;longlabel"/>
```

Xxxx xxx xxxxx xxxxx xx xxx xxxxxx xxxxxxxx, xx xxxxx xxxx xxxx.

![Xxx xxx xxxxxx xxxx xxxxxxxx xxxxx](images/app-bar-button-label-wrap.png)

Xxxxxxx xxxx xxxxxx xxx xxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxx "xxx xxxx" \[•••\] xx xxxxxxx, xxxxxxxx xxxxx xxxxxxxx xxx xxxxxx xxxxx. Xxxx xxxxx xx xxxxxx xxx xxxxx xxxxx xx xxxxxxxx xxxx xxxxxx.

## Xxxx xxx xxxxxx xxxxxx

Xxx xxxxxxx xxx xxx xx xxxx xx xxxxxx. X xxxx xxx xxxxxx xxxxxxx xxxxx xxxxxx xx xxxxxxxx xxx "xxx xxxx" \[•••\] xxxxxx. Xxx xxx xxxxxx xxxxxxx xxxx xxxxxxxxxxxxxxxx xx xxxxxxx xxx [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.isopen.aspx) xxxxxxxx. Xxxx xxxx, xxx xxxxxxx xxxxxxx xxxxxxx xxx xxxxx xxxx xxxx xxxxxx xxx xxx xxxxxxxx xxxx xx xxxx xx xxxxxxxxx xxxxxxxx xxx xxxxxxx, xx xxxxx xxxxxxxxxx.

Xxx xxx xxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opening.aspx), [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.opened.aspx), [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closing.aspx), xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closed.aspx) xxxxxx xx xxxxxxx xx xxx xxxxxxx xxx xxxxx xxxxxx xx xxxxxx.  
- Xxx Xxxxxxx xxx Xxxxxxx xxxxxx xxxxx xxxxxx xxx xxxxxxxxxx xxxxxxxxx xxxxxx.
- Xxx Xxxxxx xxx Xxxxxx xxxxxx xxxxx xxxxx xxx xxxxxxxxxx xxxxxxxxx.

Xx xxxx xxxxxxx, xxx Xxxxxxx xxx Xxxxxxx xxxxxx xxx xxxx xx xxxxxx xxx xxxxxxx xx xxx xxxxxxx xxx. Xxxx xxx xxxxxxx xxx xx xxxxxx, xx'x xxxx-xxxxxxxxxxx xx xxx xxx xxxxxxxxxx xxxxx xxxxxxx. Xxxx xxx xxxxxxx xxx xx xxxxxx, xxx xxxxxxx xxx xx xxxx xxxxxx xx xxx xxxx xxx xxxxx xx xxx xxxxxxxx.

```xaml
<CommandBar Opening="CommandBar_Opening"
            Closing="CommandBar_Closing">
    <AppBarButton Icon="Accept" Label="Accept"/>
    <AppBarButton Icon="Edit" Label="Edit"/>
    <AppBarButton Icon="Save" Label="Save"/>
    <AppBarButton Icon="Cancel" Label="Cancel"/>
</CommandBar>
```

```csharp
private void CommandBar_Opening(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 1.0;
}
 
private void CommandBar_Closing(object sender, object e)
{
    CommandBar cb = sender as CommandBar;
    if (cb != null) cb.Background.Opacity = 0.5;
}

```

### XxxxxxXxxxxxxXxxx

Xxx xxx xxxxxxx xxx xxx xxxxxxx xxx xx xxxxx xx xxx xxxxxx xxxxx xx xxxxxxx xxx [**XxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.closeddisplaymode.aspx) xxxxxxxx. Xxxxx xxx Y xxxxxx xxxxxxx xxxxx xx xxxxxx xxxx:
- **Xxxxxxx**: Xxx xxxxxxx xxxx. Xxxxx xxxxxxx, xxxxxxx xxxxxxx xxxxx xxxxxxx xxxxxx, xxx xxx "xxx xxxx" \[•••\] xxxxxx.
- **Xxxxxxx**: Xxxxx xxxx x xxxx xxx xxxx xxxx xx xxx "xxx xxxx" \[•••\] xxxxxx. Xxx xxxx xxx xxxxx xxxxxxxx xx xxx xxx xx xxxx xx.
- **Xxxxxx**: Xxx xxxxxxx xxx xx xxx xxxxx xxxx xx'x xxxxxx. Xxxx xxx xx xxxxxx xxx xxxxxxx xxxxxxxxxx xxxxxxxx xxxx xx xxxxxx xxxxxxx xxx. Xx xxxx xxxx, xxx xxxx xxxx xxx xxxxxxx xxx xxxxxxxxxxxxxxxx xx xxxxxxx xxx **XxXxxx** xxxxxxxx xx xxxxxxxx xxx XxxxxxXxxxxxxXxxx xx **Xxxxxxx** xx **Xxxxxxx**. 

Xxxx, x xxxxxxx xxx xx xxxx xx xxxx xxxxxx xxxxxxxxxx xxxxxxxx xxx x [XxxxXxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx). Xxxx xxx xxxx xxx xxxxx'x xxxx xxxxx, xxx xxxxxxxxxx xxxxxxxx xxx xx xxxxxxxxxxx, xx xxxx'xx xxxxxx. Xxxx xxx xxxx xxx xx xxxxx xxxx, xxx xxxxxxx xxx'x XxxxxxXxxxxxxXxxx xx xxxxxxx xx Xxxxxxx xx xxx xxxxxxxxxx xxxxxxxx xxx xxxxxxx.

```xaml
<StackPanel Width="300" 
            GotFocus="EditStackPanel_GotFocus" 
            LostFocus="EditStackPanel_LostFocus">
    <CommandBar x:Name="FormattingCommandBar" ClosedDisplayMode="Hidden">
        <AppBarButton Icon="Bold" Label="Bold" ToolTipService.ToolTip="Bold"/>
        <AppBarButton Icon="Italic" Label="Italic" ToolTipService.ToolTip="Italic"/>
        <AppBarButton Icon="Underline" Label="Underline" ToolTipService.ToolTip="Underline"/>
    </CommandBar>
    <RichEditBox Height="200"/>
</StackPanel>
```

```csharp
private void EditStackPanel_GotFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
}

private void EditStackPanel_LostFocus(object sender, RoutedEventArgs e)
{
    FormattingCommandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Hidden;
}
```

>**Xxxx**&xxxx;&xxxx;Xxx xxxxxxxxxxxxxx xx xxx xxxxxxx xxxxxxxx xx xxxxxx xxx xxxxx xx xxxx xxxxxxx. Xxx xxxx xxxx, xxx xxx [XxxxXxxxXxx](rich-edit-box.md) xxxxxxx.

Xxxxxxxx xxx Xxxxxxx xxx Xxxxxx xxxxx xxx xxxxxx xx xxxx xxxxxxxxxx, xxxx xx xxxx xxxx xxxxxx xxx xxxxxxx xxxxx xxxxxxx xxxxx.

Xxxxxxxx xxx XxxxxxXxxxxxxXxxx xx xxxxxxx xxxx xx xxxx xx x xxxx xx xxx xxxx xxxxxxx xxx xxxxxx xx xxxxxxxxxxx xxxxxxxx. Xx xxxxxxxx, xxxx xxx XxxxxxxXxx xxxxxxxxxxx xxxxxxx xxxxxx xxx xxxx, xx xxxx xxx xxxxxx xxx xxxxxx xx xxxxx xxxxxxxx.

### XxXxxxxx

Xxxxx xxxxxxx xxx xxxxxxx xxx, xx xxx xxxx xxxxxxxxx xxxx xxx xxx xxxxxxxx xxxxxxx xx xxx xxxxxxx xxxx xx xxxxxxx xxx xxxxxxxx xxxx xx xxxxxxxxx xxx xxx xxxxxx xxx xxxxxx. Xxxxxxx xx xx xxxx xxx xx xxxxxx *xxxxx xxxxxxx*. Xxx xxx xxxxxxx xxx xxx xxx xx xxxxxxxxx xx xxxxxxx xxx [**XxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.issticky.aspx) xxxxxxxx. Xxxx xxx xxx xx xxxxxx (`IsSticky="true"`), xx'x xxx xxxxxx xx x xxxxx xxxxxxx xxxxxxx. Xxx xxx xxxxxxx xxxx xxxxx xxx xxxx xxxxxxx xxx "xxx xxxx" \[•••\] xxxxxx xx, xx xxxxxxx, xxxxxxx xx xxxx xxxx xxx xxxxxxxx xxxx.

## Xxxxxxxxxxxxxxx

### Xxxxxxxxx

Xxxxxxx xxxx xxx xx xxxxxx xx xxx xxx xx xxx xxx xxxxxx, xx xxx xxxxxx xx xxx xxx xxxxxx, xxx xxxxxx.

![Xxxxxxx Y xx xxx xxx xxxxxxxxx](images/AppbarGuidelines_Placement1.png)

-   Xxx xxxxxx xxxxxxx, xx xxx'xx xxxxxxx xxxx xxx xxxxxxx xxx xx xxxx xxx, xxx xx xx xxx xxxxxx xx xxx xxxxxx xxx xxxx xxxxxxxxxxxx. Xx xxxx xxx xxx xxxx xx xxx xxxxxx, xxxxxxxx xxxxxxx xxx xxxxxxx xxx xx xxx xxx xx xxxx xxx XX xxx'x xxx xxxxxx-xxxxx.
-   Xxx xxxxxx xxxxxxx, xx xxx'xx xxxxxxx xxxx xxx xxxxxxx xxx, xx xxxxxxxxx xxxxxxx xx xx xxx xxx xx xxx xxxxxx.
-   Xxx xxx xxxx xxxxx xxxxxxx xxxx xxxxxx, xx xxxx xxxxxx xxx xxx xxxx xxx xxxxxxxxxx xxxxxxx.

Xxxxxxx xxxx xxx xx xxxxxx xx xxx xxxxxxxxx xxxxxx xxxxxxx xx xxxxxx-xxxx xxxxxxx (xxxx xxxxxxx) xxx xx xxxxx-xxxx xxxxxxx (xxxxx xxxxxxx). Xxxxxx xxxxxxx xxxx xxx xx xxxxxx xxxxxxxx xx xxx xxxxxx xxxxx.

![Xxxxxxx Y xx xxx xxx xxxxxxxxx](images/AppbarGuidelines_Placement2.png)

>**Xxxxxx Xxxxxx Xxxxxx**: Xx xxx xxxxxxx xxx xxxx xxxxxx xxxxxxx xx x xxxx xxxx xxx xxxxx xxxxxxxx, xx Xxxx Xxxxx Xxxxx (XXX), xxxxxxx xxxx xxx xxx xxxxxx xxx xxxxxxx xxx xx xxx XxxxxxXxxXxx xxxxxxxx xx x Xxxx xxx xx xxxx xxxx xx xxxxxx xxxxxxx xxxx xxx XXX xx xxxxxxx. Xxxxxxxxx, xxx xxxxxx xxxxx xxx xxxxxxx xxx xxxxxx xxx xxxxxxxxxx xxxxxxxx xx xxxx xxx xxxxxxx. Xxxxx xxx xxxxx xxx xxxxxxx xxx xxxx xxxxxxxxx xxxxxx xxxx xxxxxxx xxx xxxx xx xxxxxx, xx xxx xxx xxxxxxx xxxx xxxx xx'x xxxxxx.

### Xxxxxxx

Xxxxxxxxxx xxx xxxxxxx xxxx xx xx xxx xxxxxxx xxx xxxxx xx xxxxx xxxxxxxxxx.

-   Xxxxx xxx xxxx xxxxxxxxx xxxxxxxx, xxx xxxx xxxx xxx xxxx xx xxxxxx xxxxxxx xx xxx xxx, xx xxx xxxxx xxx xxxxx xx xxx xxxxxx xxxxx. Xx xxx xxxxxxxx xxxxxxx (YYY xxx xxxxx), xxxxxxx Y-Y xxxxx xxxx xxx xx xxx xxxxxxx xxx'x xxxxxx xxxxx, xxxxxxxxx xx xxxxx xx-xxxxxx XX.
-   Xxxxx xxxx-xxxxxxxxx xxxxxxxx xxxxx xx xxx xxx'x xxxxxx xxxxx xx xxxxxx xxx xxxxx xxx xxxxx xx xxx xxxxxxxx xxxx. Xxxxx xxxxxxxx xxxx xx xxxxxxx xxxx xxx xxx xxx xxxxxx xxxxxx xxxx xxxxxx, xxx xxxx xxxx xxxx xxx xxxxxxxx xxxx'x xxxx-xxxx xxxx xxxx xxxxx xxx'x xxxxxx xxxx.
-   Xxxxx xxx xxxxx-xxxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxx xxxx. Xxxxx xxxxxxxx xxxx xxxxxx xxxxxx xx xxx xxxx-xxxx xxxx.

Xxxxx xx xxx xxxxxxx xxxxx xxx xx xxxxxxxxxx xxxx xxxxxx xxxxx xx xxxxxxx. Xxxx xxxx xxxxx xxxxx, xxxxxxx x xxxx xxxxx. Xxx xxxx xxxxx xxxxxxx xxxxx xxx xxxx xxxx xxx "xxx xxxx" \[•••\] xxxxxx xx xxxxxxx.

Xx xxxxx xx x xxxxxxx xxxx xxxxx xxxxxx xxxxxxxxxxxx xxxxxx xxxxx, xx'x xxxx xx xxxx xxxx xxxxxxx xx x xxxxxxxxxx xxxxxxxx. Xx xxxxxxxxxxx xxxxxxx Xxxxxx, Xxx, xxx XX xxxxxxxx xx xxx xxxx xx Xxxxxx, Xx, xxx Xxxxxx. Xxxxxxxxxxx xxxxx xxxxx xxx xxxxxxxxxx xx xxxx xxxxxx xxx xxxxxx xxx xxxxx xxxx xxxxxxxx xxxxx xxxxxxxxx xx xxx xxxxxxxxxx xxxx xxx xx xxx.

Xxxxxxxx xxx xxx xxxxx xxx xxxxxxx xxxxxx xxx xxxxxxxx xxxx xx xxxx xxxx xxx "xxx xxxx" \[•••\] xxxxxx xx xxxxxxx xx xxx xxxxxxx xxx, xxxx xx xxxx xxxx xxxxxx xxx xxxxxxx xxxxx xxxxxxx xxxxx.

### Xxxxxxx xxx xxxxxxx xxx xxxxxxxx

Xxxxxxxx xxxxxxx xxxxxxxxx xxx xxx xxxxxxxx, xxxx xx xxxxxxx Xxxxx, Xxxxx Xxx, xxx Xxxxxxx xx x Xxxxxxx xxxx.

![Xxxxxxx xx xxxxxxx xx x xxxxxxx xxx](images/AppbarGuidelines_Flyouts.png)

Xxxxxxx xxxx xxxxxx xxx xxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxx \[•••\] xx xxxxxxxx, xxxxxxxx xxxxx xxxxxxxx xxx xxxxxx xxxxx.

### Xxxxxxxx xxxx

![Xxxxxxx xx xxxxxxx xxx xxxx "Xxxx" xxxx](images/AppbarGuidelines_Illustration.png)

-   Xxx xxxxxxxx xxxx xx xxxxxxxxxxx xx xxx "xxx xxxx" \[•••\] xxxxxx, xxx xxxxxxx xxxxx xxxxx xxx xxx xxxx. Xx'x xx xxx xxx-xxxxx xx xxx xxxxxxx, xxxxxxxx xx xxxxxxx xxxxxxx.
-   Xxxx xxxxxx xx xxx xxxxxxx xxxxxx xxxxx xx xxxxxxxxxxx xx xx xxxx. Xxxxxxxxx xxx xxxxxxxx xxxx xxxxxxx xxxx xxxxxx xxx xxxx xx xxx xxxxxxx xx xxx xxxxxxx xxxxxx xxxxx.
-   Xxx xxxxxxxx xxxx xx xxxxxxxxx xxx xxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxx.
-   Xxxxxxx xxx xxxx xxx xx xxxxxxx xxx xxxxxxx xxxxxx xxxxx xxx xxx xxxxxxxx xxxx xx xxxxxxxxxxx. Xxx xxx xxxx xxxxxxxxx xxxxxxx xx xxxxxx xxxxxx xx xxx xxxxxxx xxxxxx xxxxx xxxxxxxxxx xx xxxxxx xx xxx xxxxxx xxxx.
-   Xxxxxxxxxxxx xxxx xxxxxxx xxx xxxxxx xx xxx xxxxxxxx xxxx xxxx xxxx xxx xxx xxx xx xxxxxxxx xx xxxxxx xxxxxxx.

## Xxxxxxxxxx xxxxxxxx

-   Xxx xxxx xxxxxx xx xxxxxxx xx xxx xxx xxx xxxxxx xx xxxxxxx xx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx, xxxxx xxxxxxx xxx xxxx'x xxxxxxxxx xxxx. Xxx xxxxxx xx xxxxxxx xxxxxxxxx xxxxxx xx xxxxxxxxxx xx xxx xxxxxx'x xxxxx xx xxxxxxxx xxxxxxxxxxx.
-   Xx xxxxxxxxx xxxxxxxxxxx, xxx xxx xxxx xxxxxxx xx xxx xxx xx xxx xxxx xx xxx xxxxxx xxxx xx xxx xxxxxx xxxx xxxxxxx.

\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxxxx

**Xxx xxxxxxxxx**
[Xxxxxxx xxxxxx xxxxxx xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn958433)

**Xxx xxxxxxxxxx (XXXX)**
[
            **XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn279427)

<!--HONumber=Mar16_HO1-->
