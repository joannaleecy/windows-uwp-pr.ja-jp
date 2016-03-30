---
Xxxxxxxxxxx: Xxx x XxxxXxxxXxxxx xxxx XxxxXxxxXxxxxXxxxxxxx xxxxxxxx xx xxxxxx xxxxxxxx xxxx xxxxxxx.
xxxxx: XxxxXxxxXxxxx
xx.xxxxxxx: XYXXYXYX-YYYX-YYYY-YYXY-YYXYYXXXYXYY
xxxxx: Xxxx xxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxx xxxx xxxxx
Xxxx xxxx xxxxxx xxxxxxx xxxxxxx xxxxxxxx xxx xxxxxxxx xxxx xxxxxx xxxx xxx xxx xxx xxxx xxx xxxx xxxxxxx xxx xxxxxxxxxx, xxxxxx XX xxxxxxxx, xx xxxxxxx xxxx xxxxxxx.


<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxXxxxXxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx)
-   [**XxxxXxxxXxxxxXxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx)
-   [**Xxxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx)
-   [**Xxxxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?

Xxx x **XxxxXxxxXxxxx** xxxx xxx xxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxx, xxxxx-xxxxxx xx xxxxx xxxxxxx xxxx xxxxxxx, xx xxxxxx XX xxxxxxxx xxxx xxxxxx.

Xxx x **XxxxXxxxx** xx xxxxxxx xxxx xxxx-xxxx xxxx xx xxxx xxx. Xxx xxx xxx xx xx xxxxxxx xxxxxx-xxxx xx xxxxx-xxxx xxxx, xxxxxx xxxxxxxxxx, xxx xxxx xxxx xxxxxxxxxx xxxx xxxx, xxxxxx, xx xxxxxxxxxx. XxxxXxxxx xxxxxxxx x xxxxxxx xxxxxxx xxxxx, xx xx’x xxxxxxxxx xxxxxx xx xxx, xxx xx xxx xxxxxxx xxxxxx xxxx xxxxxxxxx xxxxxxxxxxx xxxx XxxxXxxxXxxxx. Xx'x xxxxxxxxx xxx xxxx xxx XX xxxx. Xxxxxxxx xxx xxx xxx xxxx xxxxxx xx xxx xxxx, XxxxXxxxx xx xxxxxxxx xx xxxxxxx x xxxxxx xxxxxxxxx xxx xxxxx’x xxxxxxx xxxx xxxxxxxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxx xxx xxxxx xxxx xxxxxxx, xxx xxx [Xxxx xxxxxxxx](text-controls.md) xxxxxxx.

## Xxxxxxxx


## Xxxxxx x xxxx xxxx xxxxx

Xxx xxxxxxx xxxxxxxx xx XxxxXxxxXxxxx xx xxx [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.blocks.aspx) xxxxxxxx, xxxxx xxxxxxxx xxxxxxxxx xxxxx xxxx xxx xxx [Xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) xxxxxxx. Xx xxxxx'x xxxx x **Xxxx** xxxxxxxx xxxx xxx xxx xxx xx xxxxxx xxxxxx xxx xxxxxxx'x xxxx xxxxxxx xx xxxx xxx. Xxxxxxx, XxxxXxxxXxxxx xxxxxxxx xxxxxxx xxxxxx xxxxxxxx xxxx XxxxXxxxx xxxxx’x xxxxxxx. 

XxxxXxxxXxxxx xxxxxxxx:
- Xxxxxxxx xxxxxxxxxx. Xxx xxx xxxxxxxxxxx xxx xxxxxxxxxx xx xxxxxxx xxx [XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) xxxxxxxx.
- Xxxxxx XX xxxxxxxx. Xxx xx [XxxxxxXXXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) xx xxxxxxx XX xxxxxxxx, xxxx xx xxxxxx, xxxxxx xxxx xxxx xxxx.
- Xxxxxxxx xxxxxxxxxx. Xxx [XxxxXxxxXxxxxXxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) xxxxxxxx xx xxxxxx xxxxx-xxxxxx xxxx xxxxxxx.

### Xxxxxxxxxx

Xxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.aspx) xxxxxxxx xx xxxxxx xxx xxxxxx xx xxxx xx xxxxxxx xxxxxx x XxxxXxxxXxxxx xxxxxxx. Xxxxx XxxxXxxxXxxxx xxxxxx xxxxxxx xx xxxxx xxx Xxxxxxxxx. 

Xxx xxx xxx xxx xxxxxx xxxxxx xxx xxx xxxxxxxxxx xx x XxxxXxxxXxxxx xx xxxxxxx xxx [XxxxXxxxXxxxx.XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.textindent.aspx) xxxxxxxx. Xxx xxx xxxxxxxx xxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxx xx x XxxxXxxxXxxxx xx xxxxxxx xxx [Xxxxxxxxx.XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.paragraph.textindent.aspx) xxxxxxxx xx x xxxxxxxxx xxxxx.

```xaml
<RichTextBlock TextIndent="12">
  <Paragraph TextIndent="24">First paragraph.</Paragraph>
  <Paragraph>Second paragraph.</Paragraph>
  <Paragraph>Third paragraph. <Bold>With an inline.</Bold></Paragraph>
</RichTextBlock>
```

### Xxxxxx XX xxxxxxxx

Xxx [**XxxxxxXXXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.inlineuicontainer.aspx) xxxxx xxxx xxx xxxxx xxx XXXxxxxxx xxxxxx xxxx xxxx xxxx. X xxxxxx xxxxxxxx xx xx xxxxx xx Xxxxx xxxxxx xxxx xxxx xxxx, xxx xxx xxx xxxx xxx xxxxxxxxxxx xxxxxxxx, xxxx x Xxxxxx xx XxxxxXxx.

Xx xxx xxxx xx xxxxx xxxx xxxx xxx xxxxxxx xxxxxx xx xxx xxxx xxxxxxxx, xxxxxxxx xxxxx x xxxxx xx xxx xxxxxx XxxxxxXXXxxxxxxxx xxxxx, xxx xxxx xxxxx xxx xxxxxxxx xxxxxxxx xxxxxx xxxx xxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxx xx XxxxxxXXXxxxxxxxx xx xxxxxx xx xxxxx xxxx x XxxxXxxxXxxxx. 

```xaml
<RichTextBlock>
    <Paragraph>
        <Italic>This is an inline image.</Italic>
        <InlineUIContainer>
            <Image Source="Assets/Square44x44Logo.png" Height="30" Width="30"/>
        </InlineUIContainer>
        Mauris auctor tincidunt auctor.
    </Paragraph>
</RichTextBlock>
```

## Xxxxxxxx xxxxxxxxxx

Xxx xxx xxx x XxxxXxxxXxxxx xxxx [**XxxxXxxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblockoverflow.aspx) xxxxxxxx xx xxxxxx xxxxx-xxxxxx xx xxxxx xxxxxxxx xxxx xxxxxxx. Xxx xxxxxxx xxx x XxxxXxxxXxxxxXxxxxxxx xxxxxxx xxxxxx xxxxx xxxx x XxxxXxxxXxxxx xxxxxxx. Xxx xxxx XxxxXxxxXxxxxXxxxxxxx xxxxxxxx xx xxxxxxx xxxx xx xxx XxxxxxxxXxxxxxxXxxxxx xx x XxxxXxxxXxxxx xx xxxxxxx XxxxXxxxXxxxxXxxxxxxx.

Xxxx'x x xxxxxx xxxxxxx xxxx xxxxxxx x xxx xxxxxx xxxxxx. Xxx xxx Xxxxxxxx xxxxxxx xxx x xxxx xxxxxxx xxxxxxx.

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <RichTextBlock Grid.Column="0" 
                   OverflowContentTarget="{Binding ElementName=overflowContainer}" >
        <Paragraph>
            Proin ac metus at quam luctus ultricies.
        </Paragraph>
    </RichTextBlock>
    <RichTextBlockOverflow x:Name="overflowContainer" Grid.Column="1"/>
</Grid>
```

## Xxxxxxxxxx xxxx

Xxxxxxxx xxx XxxxXxxxXxxxx xxxxxx xxxxx xxxx, xxx xxx xxxxx xxxxxxx xxxxxxxxxx xxxxxxx xx xxxxxxxxx xxx xxx xxxx xx xxxxxxxx xx xxxx xxx. Xxx xxx xxx xxxxxxxx xxxxxxx xxxxxxxxxx xxxx XxxxXxxxxx, XxxxXxxx, XxxxXxxxx, Xxxxxxxxxx, xxx XxxxxxxxxXxxxxxx xx xxxxxx xxx xxxx xx xxx xxxx. Xxx xxx xxxx xxx xxxxxx xxxx xxxxxxxx xxx Xxxxxxxxxx xxxxxxxx xxxxxxxxxx xx xxxxxx xxxx xxxx. Xxxxx xxxxxxx xxxxxx xxxx xxx xxx XxxxXxxxXxxxx xxxxxxxx xxx xxxx xxxxxxx, xx xx xxx xxxx xxx xxxxx xxx xxxx xxxx x xxxx xxxx xxxxxxx, xxx xxxxxxx, xx xxxxxxxxxx xx xxxxxxx.

### Xxxxxx xxxxxxxx

Xxx [Xxxxxxx.XX.Xxxx.Xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.aspx) xxxxxxxxx xxxxxxxx x xxxxxxx xx xxxxxx xxxx xxxxxxxx xxxx xxx xxx xxx xx xxxxxx xxxx xxxx, xxxx xx Xxxx, Xxxxxx, Xxx, Xxxx, xxx XxxxXxxxx. X xxxxxxx xxx xx xxxxx xxxxxxxxxx xx xxxxxxxx xx xxxx xx xx xxxxx xxx xxxx xx x Xxx xx Xxxx xxxxxxx, xxx xxxx xxx xxxxxxxxxx xx xxxx xxxxxxx.

Xxxx'x x Xxxxxxxxx xxxx xxx xxxxx xxxxxx xxxxx xx xxxx, xxxx, YYxx xxxx.

```xaml
<Paragraph>
    <Bold><Span Foreground="DarkSlateBlue" FontSize="16">Lorem ipsum dolor sit amet</Span></Bold>
    , consectetur adipiscing elit.
</Paragraph>
```

### Xxxxxxxxxx

Xxx xxxxxxxx xxxxxxxxxx xx xxx [Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.documents.typography.aspx) xxxxx xxxxxxx xxxxxx xx x xxx xx Xxxxxxxxx XxxxXxxx xxxxxxxxxx xxxxxxxxxx. Xxx xxx xxx xxxxx xxxxxxxx xxxxxxxxxx xxxxxx xx xxx XxxxXxxxXxxxx, xx xx xxxxxxxxxx xxxxxx xxxx xxxxxxxx, xx xxxxx xxxx.

```xaml
<RichTextBlock Typography.StylisticSet4="True">
    <Paragraph>
        <Span Typography.Capitals="SmallCaps">Lorem ipsum dolor sit amet</Span>
        , consectetur adipiscing elit.
    </Paragraph>
</RichTextBlock>
```

## Xxxxxxxxxxxxxxx

Xxx Xxxxxxxxxx xxx Xxxxxxxxxx xxx xxxxx.

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
