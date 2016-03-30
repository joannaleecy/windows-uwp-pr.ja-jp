---
xxxxxxxxxxx: Xxxxxxxx x xxxxx xxx xxx XXXX xxxxxxxxx xx xxxxxxxxxx x xxxxxxxxx xx xx xxxxxxx xxxxxxx xxxxxxxx. Xxxxxxxxx xxx xxxxxxx xx x XxxxxxxxXxxxxxxxxx, xxx x XxxxxxXxxxxxxx xxxxx xxxxxxxxxx xxx xxx xx xxxx xxxxxxxx xx xxx XxxxxxxxXxxxxxxxxx.
xxxxx: XxxxxxXxxxxxxx xxxxxx xxxxxxxxx
xx.xxxxxxx: XYYYYYXY-YYYY-YXXX-YYYY-YYXYYYXXXYYY
---

# {XxxxxxXxxxxxxx} xxxxxx xxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxxxx x xxxxx xxx xxx XXXX xxxxxxxxx xx xxxxxxxxxx x xxxxxxxxx xx xx xxxxxxx xxxxxxx xxxxxxxx. Xxxxxxxxx xxx xxxxxxx xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx x **XxxxxxXxxxxxxx** xxxxx xxxxxxxxxx xxx xxx xx xxxx xxxxxxxx xx xxx **XxxxxxxxXxxxxxxxxx**.

## XXXX xxxxxxxxx xxxxx

``` syntax
<object property="{StaticResource key}" .../>
```

## XXXX xxxxxx

| Xxxx | Xxxxxxxxxxx |
|------|-------------|
| xxx | Xxx xxx xxx xxx xxxxxxxxx xxxxxxxx. Xxxx xxx xx xxxxxxxxx xxxxxxxx xx xxx [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794). X xxxxxxxx xxx xxx xx xxx xxxxxx xxxxxxx xx xxx XxxxXxxx Xxxxxxx. |

## Xxxxxxx

**XxxxxxXxxxxxxx** xx x xxxxxxxxx xxx xxxxxxxxx xxxxxx xxx x XXXX xxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xx x XXXX xxxxxxxx xxxxxxxxxx. Xxxxxx xxxxx xx xxxxxx xx x xxxxxxxx xxxxxxxxxx xxxxxxx xxxx xxx xxxxxxxx xx xx xxxxxx xx xxxxxxxx xxxxxxxx xxxxxx, xx xxxxxxx x XXXX xxxxxxxx xxxxxxxxxx xx xxxx xx x XXXX xxxxxxxxx xx xxxxxxxxx xxxxxxxxx. Xx xxxxxxx xx x XXXX xxxxxxxxx xxxxxxxxx xx xxx xxxxx xxxxxxxxxx xxx x xxxxxxx. Xxxxxxx xxxxxxx xx xxxxxx xxxxxxxx xxxxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxxx.

**XxxxxxXxxxxxxx** xxxxx xxx xxxxxxxx, xxxxx xxxxxxxxx xxx xxx xxx xxx xxxxxxxxx xxxxxxxx. X xxxxxxxx xxx xx xxxxxx x xxxxxx xx Xxxxxxx Xxxxxxx XXXX. Xxx xxxx xxxx xx xxx xxx xxxxxxxx xxx xx xxxxxxxxx xxxxxxxxx, xxx [x:Xxx xxxxxxxxx](x-key-attribute.md).

Xxx xxxxx xx xxxxx x **XxxxxxXxxxxxxx** xxxxxxxx xx xx xxxx xx x xxxxxxxx xxxxxxxxxx xxx xxx xxxxxxxxx xx xxxx xxxxx. Xxxx xxxxxxx xx xxxxxxx xxx xxxxxxxxx xxx xxx xxxxxxxx xxxx xxxxx xx x xxxxxxxx, xxxxxxx xxxxxx xxxxxxxx xxxxxxxxxxxx xxx xxxx, xxx xx xx. Xxx xxxx xxxx xx xxx xx xxxxxx xxxxxxxxx xxx xxxxxxxx xxx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxxxxxxxx xxxxxx xxxx, xxx [XxxxxxxxXxxxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187273).

**Xxxxxxxxx**  
X **XxxxxxXxxxxxxx** xxxx xxx xxxxxxx xx xxxx x xxxxxxx xxxxxxxxx xx x xxxxxxxx xxxx xx xxxxxxx xxxxxxxxx xxxxxxx xxxxxx xxx XXXX xxxx. Xxxxxxxxxx xx xx xx xx xxx xxxxxxxxx. Xxxx xx xxx xxxxxxx xxxxxxxxx xxxxx'x xxxx, xxxxxx xx xxxx xxx xxxxxxx x xxxxxxxxxxx xxxxxxx. Xxx xxxx xxxxxxx, xxxxxx xxx xxxxxxxxxxx xx xxxx xxxxxxxx xxxxxxxxxxxx xx xxxx xxxxxxx xxxxxxxxxx xxx xxxxxxx.

Xxxxxxxxxx xx xxxxxxx x **XxxxxxXxxxxxxx** xx x xxx xxxx xxxxxx xxxxxxx xxxxxx x XXXX xxxxx xxxxxxxxx xx xxx xxxx. Xxxxxx xxxxx xxx xxxx xxxxx xxxxxxxx xx xxxxxx.

Xx xxx Xxxxxxx Xxxxxxx XXXX xxxxxxxxx xxxxxxxxxxxxxx, xxxxx xx xx xxxxxxx xxxxx xxxxxxxxxxxxxx xxx **XxxxxxXxxxxxxx** xxxxxxxxxxxxx. **XxxxxxXxxxxxxx** xx xxxxxxxxxxx xxx xxx xx XXXX. Xxx xxxxxxx xxxxxxxxxx xx xxxx xx xx xxx xxx xxxxxxxxxx XXX xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794), xxx xxxxxxx xxxxxxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/jj635925) xx [**XxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/jj603139).

[{XxxxxXxxxxxxx} xxxxxx xxxxxxxxx](themeresource-markup-extension.md) xx x xxxxxxx xxxxxx xxxxxxxxx xxxx xxxxxxxxxx xxxxx xxxxxxxxx xx xxxxxxx xxxxxxxx. Xxx xxxxxxxxxx xx xxxx {XxxxxXxxxxxxx} xxxxxx xxxxxxxxx xxx xxx xxxxxxx xx xxxxxx xxxxxxxxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxx xxxxx xxxx'x xxxxxx. Xxx xxxx xxxx xxx [{XxxxxXxxxxxxx} xxxxxx xxxxxxxxx](themeresource-markup-extension.md).

**XxxxxxXxxxxxxx** xx x xxxxxx xxxxxxxxx. Xxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx xxxx xxxxx xx x xxxxxxxxxxx xx xxxxxx xxxxxxxxx xxxxxx xx xx xxxxx xxxx xxxxxxx xxxxxx xx xxxxxxx xxxxx, xxx xxx xxxxxxxxxxx xx xxxx xxxxxx xxxx xxxx xxxxxxx xxxx xxxxxxxxxx xx xxxxxxx xxxxx xx xxxxxxxxxx. Xxx xxxxxx xxxxxxxxxx xx XXXX xxx xxx "\{" xxx "\}" xxxxxxxxxx xx xxxxx xxxxxxxxx xxxxxx, xxxxx xx xxx xxxxxxxxxx xx xxxxx x XXXX xxxxxxxxx xxxxxxxxxx xxxx x xxxxxx xxxxxxxxx xxxx xxxxxxx xxx xxxxxxxxx.

### Xx xxxxxxx {XxxxxxXxxxxxxx} xxxxx

Xxxx xxxxxxx XXXX xx xxxxx xxxx xxx [XXXX xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226854).

```xaml
<StackPanel Margin="5">
    <!-- Add converter as a resource to reference it from a Binding. --> 
    <StackPanel.Resources>
        <local:S2Formatter x:Key="GradeConverter"/>
    </StackPanel.Resources>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Percent grade:" Margin="5" />
    <Slider x:Name="sliderValueConverter" Minimum="1" Maximum="100" Value="70" Margin="5"/>
    <TextBlock Style="{StaticResource BasicTextStyle}" Text="Letter grade:" Margin="5"/>
    <TextBox x:Name="tbValueConverterDataBound"
      Text="{Binding ElementName=sliderValueConverter, Path=Value, Mode=OneWay,  
        Converter={StaticResource GradeConverter}}" Margin="5" Width="150"/> 
</StackPanel> 
```

Xxxx xxxxxxxxxx xxxxxxx xxxxxxx xx xxxxxx xxxx'x xxxxxx xx x xxxxxx xxxxx, xxx xxxxxxx xx xx x xxxxxxxx xx x [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794). Xx xx x xxxxx xxxxxxxx, xxxx `local:S2Formatter` xxxxxxx xxxx xxxx xxxx xx **x:Xxx** xxxxxxxxx xxxxx. Xxx xxxxx xx xxx xxxxxxxxx xx xxx xx "XxxxxXxxxxxxxx".

Xxx xxxxxxxx xx xxxx xxxxxxxxx xxxx x xxx xxxxxxx xxxx xxx XXXX, xxxxx xxx xxx `{StaticResource GradeConverter}`.

Xxxx xxx xxx {XxxxxxXxxxxxxx} xxxxxx xxxxxxxxx xxxxx xx xxxxxxx x xxxxxxxx xx xxxxxxx xxxxxx xxxxxxxxx [{Xxxxxxx} xxxxxx xxxxxxxxx](binding-markup-extension.md), xx xxxxx'x xxx xxxxxx xxxxxx xxxxxxxxx xxxxxx xxxx. Xxx xxxxx xxx xx xxxxxxxxx xxxxx, xx xxxx xxx xxxxxxxx xx xxxxxxxx xxxxx xxx xxx xx xxxx xx x xxxxx. Xxxx xxxx xxxxxxx xx xxxx xxxxx xx {Xxxxxxx} xxxxxx xxxxxxxxx.

## Xxxxxx-xxxx xxxxx xxxxxxx xxx xxx **{XxxxxxXxxxxxxx}** xxxxxx xxxxxxxxx

Xxxxxxxxx Xxxxxx Xxxxxx YYYY xxx xxxxxxx xxxxxxxx xxx xxxxxx xx xxx Xxxxxxxxx XxxxxxxXxxxx xxxxxxxxx xxxx xxx xxx xxx **{XxxxxxXxxxxxxx}** xxxxxx xxxxxxxxx xx x XXXX xxxx. Xxx xxxxxxx, xx xxxx xx xxx xxxx "{XxxxxxXxxxxxxx", xxx xx xxx xxxxxxxx xxxx xxxx xxx xxxxxxx xxxxxx xxxxx xxx xxxxxxxxx xx xxx XxxxxxxXxxxx xxxxxxxxx. Xx xxxxxxxx xx xxx xxxxxxx xxxxxxxxx xxx'x xxxx xx xxxx xxxxx ([**XxxxxxxxxXxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208740)) xxx xxx xxxxx ([**Xxxxxxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242338)), xxx xxxx xxx [XXXX xxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187274), xxx xxxxxxxxx xxxx xxx xxxxxxxxxx xxxx xxxxxxx xx xxxxx.

Xxxx x xxxxxxxx xxx xxxxxx xx xxxx xx xxx **{XxxxxxXxxxxxxx}** xxxxx, xxx **Xx Xx Xxxxxxxxxx** (XYY) xxxxxxx xxx xxxxxxx xxxx xxxxxxxx xxx xxxx xxx xxx xxxxxxxxxx xxxxx xx'x xxxxxxx. Xxx xxx xxxxx xxxxxxxxx, xxxx xxxx xx xxxxxxx.xxxx xxx xxxxxx xxxx.

## Xxxxxxx xxxxxx

* [XxxxxxxxXxxxxxxxxx xxx XXXX xxxxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [**XxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208794)
* [x:Xxx xxxxxxxxx](x-key-attribute.md)
* [{XxxxxXxxxxxxx} xxxxxx xxxxxxxxx](themeresource-markup-extension.md)

<!--HONumber=Mar16_HO1-->
