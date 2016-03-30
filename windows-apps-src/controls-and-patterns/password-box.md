---
Xxxxxxxxxxx: X xxxxxxxx xxx xx x xxxx xxxxx xxx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxx xxxx xx xxx xxx xxxxxxx xx xxxxxxx.
xxxxx: Xxxxxxxxxx xxx xxxxxxxx xxxxx
xx.xxxxxxx: YYYXYYXY-YXXX-YYXY-YXYX-XXXYYYYXYXYY
xxx.xxxxxxx: YXXXXXXY-YXXY-YXXY-YXYY-XXYYXYXXXYXX
xxxxx: Xxxxxxxx xxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxxxxx xxx
X xxxxxxxx xxx xx x xxxx xxxxx xxx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxx xxxx xx xxx xxx xxxxxxx xx xxxxxxx. X xxxxxxxx xxx xxxxx xxxx x xxxx xxx, xxxxxx xxxx xx xxxxxxx xxxxxxxxxxx xxxxxxxxxx xx xxxxx xx xxx xxxx xxxx xxx xxxx xxxxxxx. Xxx xxx xxxxxxxxx xxx xxxxxxxxxxx xxxxxxxxx.

Xx xxxxxxx, xxx xxxxxxxx xxx xxxxxxxx x xxx xxx xxx xxxx xx xxxx xxxxx xxxxxxxx xx xxxxxxx xxxx x xxxxxx xxxxxx. Xxx xxx xxxxxxx xxx xxxxxx xxxxxx, xx xxxxxxx xx xxxxxxxxx xxxxxxxxx xx xxxxxx xxx xxxxxxxx, xxxx xx x xxxxx xxx.

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxxxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx)
-   [**Xxxxxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx)
-   [**XxxxxxxxXxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx)
-   [**XxxxxxxxXxxxxxXxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx)
-   [**XxxxxxxxXxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?

Xxx x **XxxxxxxxXxx** xxxxxxx xx xxxxxxx x xxxxxxxx xx xxxxx xxxxxxx xxxx, xxxx xx x Xxxxxx Xxxxxxxx xxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxx xxx xxxxx xxxx xxxxxxx, xxx xxx [Xxxx xxxxxxxx](text-controls.md) xxxxxxx.

## Xxxxxxxx

Xxx xxxxxxxx xxx xxx xxxxxxx xxxxxx, xxxxxxxxx xxxxx xxxxxxx xxxx.

X xxxxxxxx xxx xx xxxx xxx xxxx xxxx xxxx xx xxxx xxx xxxx xxxxx xxx xxxxxxx:

![Xxxxxxxx xxx xx xxxx xxxxx xxxx xxxx xxxx](images/passwordbox-rest-hinttext.png)

Xxxx xxx xxxx xxxxx xx x xxxxxxxx xxx, xxx xxxxxxx xxxxxxxx xx xx xxxx xxxxxxx xxxx xxxx xxx xxxx xxxxx xxxxxxx:

![Xxxxxxxx xxx xxxxx xxxxx xxxxxx xxxx](images/passwordbox-focus-typing.png)

Xxxxxxxx xxx "xxxxxx" xxxxxx xx xxx xxxxx xxxxx x xxxx xx xxx xxxxxxxx xxxx xxxxx xxxxxxx:

![Xxxxxxxx xxx xxxx xxxxxxxx](images/passwordbox-text-reveal.png)

## Xxxxxx x xxxxxxxx xxx

Xxx xxx [Xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.password.aspx) xxxxxxxx xx xxx xx xxx xxx xxxxxxxx xx xxx XxxxxxxxXxx. Xxx xxx xx xxxx xx xxx xxxxxxx xxx xxx [XxxxxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchanged.aspx) xxxxx xx xxxxxxx xxxxxxxxxx xxxxx xxx xxxx xxxxxx xxx xxxxxxxx. Xx, xxx xxx xxx xxxxxxx xxxxx, xxxx x xxxxxx [Xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx), xx xxxxxxx xxxxxxxxxx xxxxx xxx xxxx xxxxxxxxx xxx xxxx xxxxx.

Xxxx'x xxx XXXX xxx x xxxxxxxx xxx xxxxxxx xxxx xxxxxxxxxxxx xxx xxxxxxx xxxx xx xxx XxxxxxxxXxx. Xxxx xxx xxxx xxxxxx x xxxxxxxx, xxx xxxxx xx xxx xx xx'x xxx xxxxxxx xxxxx, "Xxxxxxxx". Xx xx xx, xxx xxxxxxx x xxxxxxx xx xxx xxxx.

```xaml
<StackPanel>  
  <PasswordBox x:Name="passwordBox" Width="200" MaxLength="16"
             PasswordChanged="passwordBox_PasswordChanged"/>
           
  <TextBlock x:Name="statusText" Margin="10" HorizontalAlignment="Center" />
</StackPanel>   
```

```csharp
private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
{
    if (passwordBox.Password == "Password")
    {
        statusText.Text = "'Password' is not allowed as a password.";
    }
    else
    {
        statusText.Text = string.Empty;
    }
}
```
Xxxx'x xxx xxxxxx xxxx xxxx xxxx xxxx xxx xxx xxxx xxxxxx "Xxxxxxxx".

![Xxxxxxxx xxx xxxx x xxxxxxxxxx xxxxxxx](images/passwordbox-revealed-validation.png)

### Xxxxxxxx xxxxxxxxx

Xxx xxx xxxxxx xxx xxxxxxxxx xxxx xx xxxx xxx xxxxxxxx xx xxxxxxx xxx [XxxxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordchar.aspx) xxxxxxxx. Xxxx, xxx xxxxxxx xxxxxx xx xxxxxxxx xxxx xx xxxxxxxx.

```xaml
<PasswordBox x:Name="passwordBox" Width="200" PasswordChar="*"/>
```

Xxx xxxxxx xxxxx xxxx xxxx.

![Xxxxxxxx xxx xxxx x xxxxxx xxxxxxxxx](images/passwordbox-custom-char.png)

### Xxxxxxx xxx xxxxxxxxxxx xxxx

Xxx xxx xxx xxx [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.header.aspx) xxx [XxxxxxxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.placeholdertext.aspx) xxxxxxxxxx xx xxxxxxx xxxxxxx xxx xxx XxxxxxxxXxx. Xxxx xx xxxxxxxxxx xxxxxx xxxx xxx xxxx xxxxxxxx xxxxx, xxxx xx xx x xxxx xx xxxxxx x xxxxxxxx.

```xaml
<PasswordBox x:Name="passwordBox" Width="200" Header="Password" PlaceholderText="Enter your password"/>
```

![Xxxxxxxx xxx xx xxxx xxxxx xxxx xxxx xxxx](images/passwordbox-rest-hinttext.png)

### Xxxxxxx xxxxxx

Xxxxxxx xxx xxxxxxx xxxxxx xx xxxxxxxxxx xxxx xxx xxxx xxx xxxxx xx xxxxxxx xxx [XxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.maxlength.aspx) xxxxxxxx. Xxxxx xx xx xxxxxxxx xx xxxxxxx x xxxxxxx xxxxxx, xxx xxx xxx xxxxx xxx xxxxxxxx xxxxxx, xxx xxxxxxx xxx xxxxx xxxxxxxxxx, xx xxxx xxx xxxx.

## Xxxxxxxx xxxxxx xxxx

Xxx XxxxxxxxXxx xxx x xxxxx-xx xxxxxx xxxx xxx xxxx xxx xxxxx xx xxxxxxx xxx xxxxxxxx xxxx. Xxxx'x xxx xxxxxx xx xxx xxxx'x xxxxxx. Xxxx xxx xxxx xxxxxxxx xx, xxx xxxxxxxx xx xxxxxxxxxxxxx xxxxxx xxxxx.

![Xxxxxxxx xxx xxxx xxxxxxxx](images/passwordbox-text-reveal.png)

### Xxxx xxxx

Xx xxxxxxx, xxx xxxxxxxx xxxxxx xxxxxx (xx "xxxx" xxxxxx) xx xxxxx. Xxx xxxx xxxx xxxxxxxxxxxx xxxxx xxx xxxxxx xx xxxx xxx xxxxxxxx, xx xxxx x xxxx xxxxx xx xxxxxxxx xx xxxxxxxxxx.

Xxx xxxxx xx xxx [XxxxxxxxXxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.passwordrevealmode.aspx) xxxxxxxx xx xxx xxx xxxx xxxxxx xxxx xxxxxxxxxx xxxxxxx x xxxxxxxx xxxxxx xxxxxx xx xxxxxxx xx xxx xxxx. Xxxxx xxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xx xxxxxxxxx xxxxx x xxxxxxx xxxxx, xxxxxxx xxx XxxxxxxxXxx xxx xxxxx, xxx xxxxxxx xxx xxxx xxxxx xxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxx. Xxx xxxxxxxx xxxxxx xxxxxx xx xxxxx xxxx xxxx xxx XxxxxxxxXxx xxxxxxxx xxxxx xxx xxx xxxxx xxxx xxx x xxxxxxxxx xx xxxxxxx. Xx xxx XxxxxxxxXxx xxxxx xxxxx xxx xxxx xxxxxxx xxxxx, xxx xxxxxx xxxxxx xx xxx xxxxx xxxxx xxxxxx xxx xxxxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxx xxxxxx xxxx.

> **Xxxxxxx**&xxxx;&xxxx;Xxxxx xx Xxxxxxx YY, xxx xxxxxxxx xxxxxx xxxxxx xxx xxx xxxxx xx xxxxxxx. Xx xxx xxxxxxxx xx xxxx xxx xxxxxxxx xxxx xxx xxxxxxxx xx xxxxxx xxxxxxxx, xx xxxx xx xxx XxxxxxxxXxxxxxXxxx xx Xxxxxx.

### Xxxxxx xxx Xxxxxxx xxxxx

Xxx xxxxx [XxxxxxxxXxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordrevealmode.aspx) xxxxxxxxxxx xxxxxx, **Xxxxxx** xxx **Xxxxxxx**, xxxx xxx xxxxxxxx xxxxxx xxxxxx xxx xxx xxx xxxxxxxxxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxxx xx xxxxxxxx.

Xx xxxxxx xxxxxxx xxx xxxxxxxx, xxx XxxxxxxxXxxxxxXxxx xx Xxxxxx. Xxxxxx xxx xxxx xxx xxxxxxxx xx xx xxxxxx xxxxxxxx, xxx xxx xxxxxxx x xxxxxx XX xx xxx xxx xxxx xxxxxx xxx XxxxxxxxXxxxxxXxxx xxxxxxx Xxxxxx xxx Xxxxxxx.

Xx xxxxxxxx xxxxxxxx xx Xxxxxxx Xxxxx, XxxxxxxxXxx xxxx x xxxxx xxx xx xxxxxx xxxxxxx xxx xxxxxxxx xxx xxxxxxxx. Xxx xxx xxxxxx x xxxxxxx XX xxx xxxx xxx, xx xxxxx xx xxx xxxxxxxxx xxxxxxx. Xxx xxx xxxx xxx xxxxx xxxxxxxx, xxxx [XxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx), xx xxx xxx xxxx xxxxxx xxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxx x [XxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) xx xxx x xxxx xxxxxx xxx xxxxxx xxxx xx x XxxxxxxxXxx.

```xaml
<StackPanel Width="200">
    <PasswordBox Name="passwordBox1" 
                 PasswordRevealMode="Hidden"/>
    <CheckBox Name="revealModeCheckBox" Content="Show password"
              IsChecked="False" 
              Checked="CheckBox_Changed" Unchecked="CheckBox_Changed"/>
</StackPanel>
```

```csharp
private void CheckBox_Changed(object sender, RoutedEventArgs e)
{
    if (revealModeCheckBox.IsChecked == true)
    {
        passwordBox1.PasswordRevealMode = PasswordRevealMode.Visible;
    }
    else
    {
        passwordBox1.PasswordRevealMode = PasswordRevealMode.Hidden;
    }
}
```

Xxxx XxxxxxxxXxx xxxxx xxxx xxxx.

![Xxxxxxxx xxx xxxx x xxxxxx xxxxxx xxxxxx](images/passwordbox-custom-reveal.png)
    
## Xxxxxx xxx xxxxx xxxxxxxx xxx xxxx xxxx xxxxxxx

Xx xxxx xxxxx xx xxxxx xxxx xxxxx xxx xxxxx xxxxxxxx, xx Xxxx Xxxxx Xxxxx (XXX), xxx xxx xxx xxx xxxxx xxxxx xx xxx xxxx xxxxxxx xx xxxxx xxx xxxx xx xxxx xxx xxxx xx xxxxxxxx xx xxxxx. XxxxxxxxXxx xxxxxxxx xxxx xxx **Xxxxxxxx** xxx **XxxxxxxXxx** xxxxx xxxxx xxxxxx. Xxx xxxxx xxxxx xx xxxxxxx.

Xxx xxxx xxxx xxxxx xxx xx xxx xxxxx xxxxxx, xxx [Xxx xxxxx xxxxx xx xxxxxx xxx xxxxx xxxxxxxx]().

## Xxxxxxxxxxxxxxx

-   Xxx x xxxxx xx xxxxxxxxxxx xxxx xx xxx xxxxxxx xx xxx xxxxxxxx xxx xxx'x xxxxx. X xxxxx xx xxxxxxx xxxxxxx xx xxx xxx xxxx xxxxx xxx xxx x xxxxx. Xxxxxxxxxxx xxxx xx xxxxxxxxx xxxxxx xxx xxxx xxxxx xxx xxx xxxxxxxxxx xxxx x xxxxx xxx xxxx xxxxxxx.
-   Xxxx xxx xxxxxxxx xxx xx xxxxxxxxxxx xxxxx xxx xxx xxxxx xx xxxxxx xxxx xxx xx xxxxxxx. Xxxx xxxxxx xxxxxx xxxxxxx xxxxxxxxx, xx xxxx xxxxxxxxxxxx xxxx xxxxxxx xx xxx xxxx xxxx xxx xx xx xxxxx-xxxxx.
-   Xxx'x xxx xxxxxxx xxxxxxx xxxxx xxxx xx x xxxxxxxx xxxxx xxx. Xxx xxxxxxxx xxx xxx x xxxxxxxx xxxxxx xxxxxx xxx xxxxx xx xxxxxx xxx xxxxxxxxx xxxx xxxx xxxxx, xxx xxxxxx xxxxxxx xxxxxxx xxxxx xxxx xx xx xxxxx xxxx xxxxx xxxxxxxxxxxx xxxxxx xxxxx xxxxxxxxx xxxx xxxx xxx xx xxxxxxxx xxxx xxx xxxxx xxxxxxx. Xx xxxxxxx xxxx xxxx xxxxxxxxx, xxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxx xx xxx xxx xxx xxx xxxxx xxxxxxx, xx xxx xxx xxxxx xxxxxxx xx xxx xxxx xxxx.
-   Xxxxxxxx xxxxxxxxxx xxx xxxxxxxx xxxxx xxx xxxxxxx xxxxxxxx: xxx xxx xxx xxx xxxxxxxx, xxx x xxxxxx xx xxxxxxx xxx xxx xxxxxxxx.
-   Xxxx xxxx x xxxxxx xxxxxxxx xxx xxx xxxxxx.
-   Xxxx x xxxxxxxx xxx xx xxxx xx xxxxx x XXX, xxxxxxxx xxxxxxxxx xx xxxxxxx xxxxxxxx xx xxxx xx xxx xxxx xxxxxx xx xxxxxxx xxxxxxx xx xxxxx x xxxxxxxxxxxx xxxxxx.

\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxxxx

[Xxxx xxxxxxxx](text-controls.md)

**Xxx xxxxxxxxx**
- [Xxxxxxxxxx xxx xxxxx xxxxxxxx](spell-checking-and-prediction.md)
- [Xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465231)
- [Xxxxxxxxxx xxx xxxx xxxxx](text-controls.md)

**Xxx xxxxxxxxxx (XXXX)**
- [**XxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209683)
- [**Xxxxxxx.XX.Xxxx.Xxxxxxxx XxxxxxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227519)


**Xxx xxxxxxxxxx (xxxxx)**
- [Xxxxxx.Xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/system.string.length(v=vs.110).aspx)
<!--HONumber=Mar16_HO1-->
