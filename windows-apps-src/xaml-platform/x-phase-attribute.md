---
xxxxx: xXxxxx xxxxxxxxx
xxxxxxxxxxx: Xxx xXxxxx xxxx xxx xXxxx xxxxxx xxxxxxxxx xx xxxxxx XxxxXxxx xxx XxxxXxxx xxxxx xxxxxxxxxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxxx.
xx.xxxxxxx: XXYYYYYX-YXYY-YXYY-YXYY-YYYYYYYXYYYX
---

# x:Xxxxx xxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx **x:Xxxxx** xxxx xxx [{x:Xxxx} xxxxxx xxxxxxxxx](x-bind-markup-extension.md) xx xxxxxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242705) xxxxx xxxxxxxxxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxxx. **x:Xxxxx** xxxxxxxx x xxxxxxxxxxx xxx xx xxxxxxxxx xxx xxxx xxxxxx xx xxxxx xxx [**XxxxxxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298914) xxxxx xx xxxxxxxx xxxxxxx xxx xxxxxxxxx xx xxxx xxxxx. Xxxx xxx [Xxxxxx XxxxXxxx xxx XxxxXxxx xxxxx xxxxxxxxxxxxx](../debug-test-perf/optimize-gridview-and-listview.md#update-items-incrementally).

## XXXX xxxxxxxxx xxxxx


``` syntax
<object x:Phase="PhaseValue".../>
```

## XXXX xxxxxx


| Xxxx | Xxxxxxxxxxx |
|------|-------------|
| XxxxxXxxxx | X xxxxxx xxxx xxxxxxxxx xxx xxxxx xx xxxxx xxx xxxxxxx xxxx xx xxxxxxxxx. Xxx xxxxxxx xx Y. | 

## Xxxxxxx

Xx x xxxx xx xxxxxx xxxx xxxx xxxxx, xx xxxxx xxx xxxxx xxxxx, xxxx xxxxxxxxx xx xxx xxxxxxxxxx xx xxx xxxx xxxxxxxx, xxx xxxx xxx xxx xx xxxx xx xxxxxx xxxxx xxxx xxxxxx xx xxxx xx xxxx xxx xxxxx xx xxxxxxxxx. Xxxx xx xxxxxxxxxxxx xxxx xxx x xxxxxxxx xxxxxx xxxx x xxxxx-xxxxxxxxx XXX xxxx xx x xxxxx xx x xxxxxx.

Xxxxxxx xxxxxxx xxxxxxxxxxx xxxxxxxxx xx xxx xxxx xxxxxxxx xx xxxx xxx xxxxxxxx xxx xx xxxxxxxxxxx, xxx xxx xxxx xxxxxxxxx xxxxxxxx xxxxxxxx xxxxx. Xxxx xxxxxxx xxx xxxx xx xxxx xxxx xxxxxxx xxx xxxx xxxx xx xxxxxxx xxxx, xxx xxxx xxxxxx xxxx xxxxxxxx xx xxxx xxxxxxxx xx xxxx xxxxxxx.

## Xxxxxxx

```xaml
<DataTemplate x:Key="PhasedFileTemplate" x:DataType="model:FileItem">
    <Grid Width="200" Height="80">
        <Grid.ColumnDefinitions>
           <ColumnDefinition Width="75" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Image Grid.RowSpan="4" Source="{x:Bind ImageData}" MaxWidth="70" MaxHeight="70" x:Phase="3"/>
        <TextBlock Text="{x:Bind DisplayName}" Grid.Column="1" FontSize="12"/>
        <TextBlock Text="{x:Bind prettyDate}"  Grid.Column="1"  Grid.Row="1" FontSize="12" x:Phase="1"/>
        <TextBlock Text="{x:Bind prettyFileSize}"  Grid.Column="1"  Grid.Row="2" FontSize="12" x:Phase="2"/>
        <TextBlock Text="{x:Bind prettyImageSize}"  Grid.Column="1"  Grid.Row="3" FontSize="12" x:Phase="2"/>
    </Grid>
</DataTemplate>
```

Xxx xxxx xxxxxxxx xxxxxxxxx Y xxxxxx:

1.  Xxxxxxxx xxx XxxxxxxXxxx xxxx xxxxx. Xxx xxxxxxxx xxxxxxx x xxxxx xxxxxxxxx xxxx xx xxxxxxxxxx xxxxxxxxxx xx xx xxxx xx xxxxx Y.
2.  Xxxxx xxx xxxxxxXxxx xxxx xxxxx.
3.  Xxxxx xxx xxxxxxXxxxXxxx xxx xxxxxxXxxxxXxxx xxxx xxxxxx.
4.  Xxxxx xxx xxxxx.

Xxxxxxx xx x xxxxxxx xx [{x:Xxxx}](x-bind-markup-extension.md) xxxx xxxxx xxxx xxxxxxxx xxxxxxx xxxx [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242879) xxx xxxx xxxxxxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxxx xxx xxxx xxxxxxx. Xxxx xxxxxxxxx xxxx xxxxx, **XxxxXxxxXxxx** xxxxxxx x xxxxxx xxxxx xxx xxx xxxxx xx xxx xxxx xxxxxx xxxxxx xxxx xxx xxxx xxxxx. Xxx xxxxxxxxx xxxx xx xxxxxxxxx xx xxxx-xxxxxx xxxxxxx xx xxxx xx xxx xxxx xx xxxxxxxx, xxx xxxx xxxxxxxx xxx xx xx-xxxxxxxx, xxx xxx xxxxxxxxx xxx xxxxx xxxx xxx xx xxxxxx xxxxxxx.

Xxx **x:Xxxxx** xxxxxxxxx xxx xx xxxxxxxxx xx xxx xxxxxxx xx x xxxx xxxxxxxx xxxx xxxx [{x:Xxxx}](x-bind-markup-extension.md). Xxxx xx xxxxxxx xxx x xxxxx xxxxx xxxx Y, xxx xxxxxxx xxxx xx xxxxxx xxxx xxxx (xxx **Xxxxxxx**, xxx **Xxxxxxxxxx**) xxxxx xxxx xxxxx xx xxxxxxxxx xxx xxxxxxxx xxx xxxxxxx. Xxxx x [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242879)-xxxxxxx xxxxxxx xx xxxxxxxx, xx xxxx xxxxxxx xxx xxxx xxxxxxxxx xxxx xxxxx xxxx xxx xx xxxxxx xx xxxxxx xx xxxxxx xxx xxxxx xxxxxxx xxxxx. XX xxxxxxxx xxxxxx xxx xxxxxxxx xxxx xxxxxx xxxxx xxx xxxxxx xxxxx xxxx xxx xxxx-xxxxx xxxxx. Xxxxxxx xxxxxx xxxx xxxx-xxxxxxx xxxx xx xx xxxxxxx, xxx xxxxxxxxx xxxxxxx xxxxx xx xxxx xxx XX xxxxxxxx xx xxxx xxxx xxx xxxxx.

Xxxx XX xxxxxxx xxx xxxx xxxx xxx xxxxx xxxxxxxxx. Xx xx, xxxx xxxx xxxxx xx xxx xxxxxxxx xx xxx xxxxxxx. Xx x xxxxx xx xxx xxxxxxxxx, xxxxx Y xx xxxxxxx.

Xxxxx xxxxxxx xx xxx xxxx xx xx xxxxxxxxxx xxx xxx xxx xxxx xx xxx xxxxx xx [**XxxxxxxxxXxxxxxxXxxxxxxxXxxxxXxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298493). Xxx [**XxxxxxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298914) xxxxx xxxx xx xxxxxx xxx xxxx xxxxx xxxxxx xxx **x:Xxxxx** xxxxxxxx xxx xxxxxxxxx.

Xxxxxxx xxxx xxxxxxx [{x:Xxxx}](x-bind-markup-extension.md) xxxxxxxx, xxx [{Xxxxxxx}](binding-markup-extension.md) xxxxxxxx.

Xxxxxxx xxxx xxxx xxxxx xxxx xxx xxxx xxxxxxxx xx xxxxxxxx xxxxx x xxxxxxx xxxx xx xxxxx xx xxxxxxx. Xxx Xxxxxxx YY, xxxx xxxxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242705). Xxxxxxx xxxx xxx xxxxx xx xxxx xxxxxxxxx xxxx xx xxxxx xxxx xxxxxxxx, xx xxx xxxxx xxxxxxxxx xxxx xx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209369) xx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843) xxxxxxxx—xx xxxxx xxxxx, xxx xxx XX xxxxxxxx xxxx xx xxxx xxxxx xx xxxx.

<!--HONumber=Mar16_HO1-->
