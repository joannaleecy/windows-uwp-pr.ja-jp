---
xx.xxxxxxx: YYYXYXYY-XXYY-YYXY-YYXY-YXYXYYYXYXYY
xxxxx: Xxxxxxxx xxxx XXXX xxxxxx
xxxxxxxxxxx: Xxxxxxx XXXX xxxxxx xx xxxxxxxxx xxxxxxx xx xxxxxx xx xxxx-xxxxxxxxx xxx x xxxxxxx XX. Xxxx xxx xxxx xxxxxx xxx xxx xx xx xxxxxxx XXXX xxxxxx xxxxx xxx xxxx xxxx xxx xxxxxx xxxxxxxxxx xxx xxxx xxx.
---
# Xxxxxxxx xxxx XXXX xxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxxx XXXX xxxxxx xx xxxxxxxxx xxxxxxx xx xxxxxx xx xxxx-xxxxxxxxx xxx x xxxxxxx XX. Xxxx xxx xxxx xxxxxx xxx xxx xx xx xxxxxxx XXXX xxxxxx xxxxx xxx xxxx xxxx xxx xxxxxx xxxxxxxxxx xxx xxxx xxx.

Xx xxx xxxxxxx, xxxxx xxx XXXX xxxxxx xxxx xx xxxxxx xx xxxx xxxx xxx xxxx xxx xxxx xxxxxxx XX. Xxxxxxx xxx xxxxxx xx xxxx xxxxxxx xxxx xxx xxxxxxx xx xxxxxxxx xxxxxxx xxxx xx xxxxx'x xxxx. Xx x xxxx xxxxxxxxxx x xxxx xxxxxxx xx x xxxxxxxx xxxxxxx xx x xxxxxxxxx xxxx, xxxx xxx xxxxxxxxx xxxxxx xxxx xxxx, xxx.

Xx xxxx xxxxxxx, xxxxxxx XxxxxxxXxxx.xxxx xxxx xxx xxxxxxxx xxxx XxxxxxxXxxxxxxxXxxxxxxxxx.xxxx, xxx xxxxx xx XxxxxxxXxxxxxxxXxxxxxxxxx.xxxx xxxx xx xxxxxx xx xxxxxxx.

**XxxxxxxXxxx.xxxx.**

```xml
<Page x:Class="ExampleNamespace.InitialPage" ...> 
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="ExampleResourceDictionary.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>

    <Grid>
        <TextBox Foreground="{StaticResource TextBrush}"/>
    </Grid>
</Page>
```

**XxxxxxxXxxxxxxxXxxxxxxxxx.xxxx.**

```xml
<ResourceDictionary>
    <SolidColorBrush x:Key="TextBrush" Color="#FF3F42CC"/>

    <!--This ResourceDictionary contains many other resources that
    used in the app, but not during startup.-->
</ResourceDictionary>
```

Xx xxx xxx x xxxxxxxx xx xxxx xxxxx xxxxxxxxxx xxxx xxx, xxxx xxxxxxx xx xx Xxx.xxxx xx x xxxx xxxxxxxx, xxx xxxxxx xxxxxxxxxxx. Xxx Xxx.xxxx xx xxxxxx xx xxx xxxxxxx xx xxx xxxxxxxx xxxx xx xxxx xx xxxx xxx xxxx (xxxxxx xxxx xxxx xx xxx xxxxxxx xxxx) xxxxxx xx xxx xxxx xxx xxxx'x xxxxx xxxxxxxxx. Xxxx xxxxxxx-xxxxxxx xxxxx Xxx.xxxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxx xx xxxx xxx xxxx (xxxx'x xxx xxx xxxxxxx xxxx). Xxxx xxxxxxxxxx xxxxxxxxx xxx xxxxxxx xxxx.

**XxxxxxxXxxx.xxxx.**

```xml
<Page ...>  <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->   
    <StackPanel>  
        <TextBox Foreground="{StaticResource InitialPageTextBrush}"/> 
    </StackPanel> 
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**XxxxxxXxxx.xxxx.**

```xml
<Page ...>  <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <StackPanel> 
        <Button Content="Submit" Foreground="{StaticResource SecondPageTextBrush}" /> 
    </StackPanel> 
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**Xxx.xxxx**

```xml
<Application ...> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
     <Application.Resources>  
        <SolidColorBrush x:Key="DefaultAppTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="InitialPageTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="SecondPageTextBrush" Color="#FF3F42CC"/> 
        <SolidColorBrush x:Key="ThirdPageTextBrush" Color="#FF3F42CC"/> 
    </Application.Resources> 
</Application> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

Xxx xxx xx xxxx xxx xxxxx xxxxxxx-xxxxxxx xxxx xxxxxxxxx xx xx xxxx `SecondPageTextBrush` xxxx XxxxxxXxxx.xxxx xxx xx xxxx `ThirdPageTextBrush` xxxx XxxxxXxxx.xxxx. `InitialPageTextBrush` xxx xxxxxx xx Xxx.xxxx xxxxxxx xxxxxxxxxxx xxxxxxxxx xxxx xx xxxxxx xx xxx xxxxxxx xx xxx xxxx.

## Xxxxxxxx xxxxxxx xxxxx

Xxxxxxxx xxx XXXX xxxxxxxx xx xxxxxxx xx xxxxxxxxxx xxxxx xxxxxxx xx xxxxxxxx, xxx xxx xxxx xxxx xxx xxx xxx xxx xxxxxx xxxxxx xx xxxxx xxx xxxxxx xxxxxx xx xxxxxxxx xx xxxxxxx xxx xxxxxxx xxx xxxx.

-   Xxxxxx xxxxxx xxxx x [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227512) xxxxxxxx xx xxxxx'x xx xxxx xx xxx x [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243371) xx xxxxx xx x Xxxxx xxxx xx xxxxx xx.

**Xxxxxxxxxxx.**

```xml
<Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
        <Rectangle Fill="Black"/> 
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**Xxxxxxxxx.**

```xml
<Grid Background="Black"/>
```

-   Xx xxx xxxxx xxx xxxx xxxxxx-xxxxx xxxxxxx xxxxxx xxxxx, xx xxxxxxx xxxx xxxxxxxxx xx xxx xx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242752) xxxxxxx xxxxxxx. Xxxxxx-xxxxx xxxxxxxx xxx xx xxxx xxxxxxxxx xxxxxxx xxx XXX xxxx xxxxxx xxxx xxxxxxxxxx xxxxxxx xxxxxxxxxx. Xxx xxxxx xxxx xxxxx xx xx xxxxxxx xxxx xxxx.

## Xxxxxxxxxxx xxxxxxxx xxxxxxx xxxx xxxx xxx xxxx xxxx xxx xxxxxxxx

Xxx XXXX xxxxxxxx xxxxx xx xxxxx xxxxxxxx-xxxx xxxxxxx xx xxxx xxxx xxx xx xxxxxx xx xxxxx xx xxxxxxxx. Xxx XXXX xxxxxx xxxxxx xxxx xx x xxxxx xxxxxxxx xx xxx xxxxx xx xxxxxx xx xxx xxxx xx x xxxxx xxxxxxxx xx xxxxxxx. Xxx xxxxxxx xxxx xxxx [**XxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242962) xx xxxxxxxxxxx, xxx xxx xxxx xx xxxx xxxxxx xxx xxxx xxxxxxxxx xxxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210068).

**Xxxxxxxxxxx.**

```xml
<Page ... > <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <StackPanel>  
        <TextBlock>  
            <TextBlock.Foreground>  
                <SolidColorBrush Color="#FFFFA500"/> 
            </TextBlock.Foreground> 
        </TextBox> 
        <Button Content="Submit"> 
            <Button.Foreground> 
                <SolidColorBrush Color="#FFFFA500"/> 
            </Button.Foreground> 
        </Button> 
    </StackPanel> 
</Page> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

Xxxx xxxxx xxx xxxxxxx xxxx xxx xxxxxxxxxx xxxxxx: `"Orange"` xxx `"#FFFFA500"` xxx xxx xxxx xxxxx. Xx xxx xxx xxxxxxxxxxx, xxxxxx xxx xxxxx xx x xxxxxxxx. Xx xxxxxxxx xx xxxxx xxxxx xxx xxx xxxx xxxxx, xxxx xx xx Xxx.xxxx.

**Xxxxxxxxx.**

```xml
<Page ... >
    <Page.Resources>
        <SolidColorBrush x:Key="BrandBrush" Color="#FFFFA500"/>
    </Page.Resources>
    
    <StackPanel>
        <TextBlock Foreground="{StaticResource BrandBrush}" />
        <Button Content="Submit" Foreground="{StaticResource BrandBrush}" />
    </StackPanel>
</Page>
```

## Xxxxxxxx xxxxxxxxxxx

Xxxxxxxxxxx xx xxxxx xxxx xxxx xxx xxxxxx xx xxxxx xx xxx xxxx xxxxxx xxxxxx. Xxxx xxxx xxxxx xx xxxxxxxxx x xxxxx-xxx xxxxxxx xxxx xxxxxxxx xxx xxx xxxxxx xx xxxxxxxx xxxxxxx xxxxx.

-   Xx xx xxxxxxx xxx'x xxxxxxx xxxxxxx xx'x xxxxxxxxxxx xx xxxxxx xxxxxx xxxxx xxxxxxxx, xxx xx'x xxx xxxxxxxxxxxx xx xxxxxx, xxxx xxxxxx xx. Xx xxx xxxxxxx xx xxx xxxxxxx xx xxx xxxxxxx xxxxxx xxxxx xxx xx xx xxxxxxx xx xxxxx xxxxxx xxxxxx xxxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208992) xx **Xxxxxxxxx** xx xxx xxxxxxx xxxxxx xxx xxxxxx xxx xxxxx xx **Xxxxxxx** xx xxx xxxxxxxxxxx xxxxxx. Xxxxx xxxx xx xxxxxxxxxx xx xxxx xxxxxxxxx: xx xxxxxxx, xxx xxxxx x xxxxxxxx xxx xx xxx xxxxx xx xxxxxx xxxxxx xx xxxx xxx xxxxxxx xx xxx xxxxxxx.
-   Xxx x xxxxxxxxx xxxxxxx xxxxxxx xx xxxxxxxx xxxxxxxx xxxxxxxx xx xxxxxx xx xxxxxx. Xx xxxx xxxxxxx, xxx xxxxxx xx x xxx-xxxxx xxxxx xxxxx xxx xxx xxxx xx xxxxx (xxxx xxx xxxxxxxxxx xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704)) xxx xxx xxxxxx xxxx xx xxxx (xxxx xxx xxxx-xxxxxxxxxxx xxxxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243371) xxxxx-xxxxxxx xxxx xxx xxxxx xxxxxxxxxx xx xxx **Xxxx**). Xxxx, YYY% xx xxx xxxxxx xxxxxxxxx xx xxxxxxx xxx xxxxxx xxx xxxxx xxxxxx.

**Xxxxxxxxxxx.**
    
```xml
    <Grid Background="Black"> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
        <Grid.RowDefinitions> 
            <RowDefinition Height="*"/> 
            <RowDefinition Height="*"/> 
        </Grid.RowDefinitions> 
        <Rectangle Grid.Row="1" Fill="White" Opacity=".5"/> 
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**Xxxxxxxxx.**

```xml
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Rectangle Fill="Black"/>
        <Rectangle Grid.Row="1" Fill="#FF7F7F7F"/>
    </Grid>
```

-   X xxxxxx xxxxx xxx xxxx xxx xxxxxxxx: xx xxxxx xx xxxx, xxx xx xxx xxx xxxxx xxxxxxxx. Xx xx xxxxxxx xxxxxxx xxxx xx x-xxxxx xx xxxxxxx xxxxxxxx xx xxxx xxxx x xxxxxx xxxxx xx xxxxx xxxx xxx xxxx xx xxxxx xxxx xxxx: xxxxxxx xx xxx xxxx xxxxx xx xxxxxx xxx xxx xxxxxxxx. Xxxx'x xx xxxxxxx.

**Xxxxxxxxxxx.**

```xml
    <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <GridView Background="Blue">  
        <GridView.ItemTemplate> 
            <DataTemplate> 
                <Grid Background="Blue"/> 
            </DataTemplate> 
        </GridView.ItemTemplate> 
    </GridView> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**Xxxxxxxxx.**

```xml
    <GridView Background="Blue">  
        <GridView.ItemTemplate> 
            <DataTemplate> 
                <Grid/> 
            </DataTemplate>
        </GridView.ItemTemplate>
    </GridView> 
```

Xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704) xxx xx xx xxx-xxxxxxxx xxxx xxx x xxxxxxxxxx xxxxx xx xxxxxxxxxxx xx xx.

-   Xxx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209253) xxxxxxx xx xxxx x xxxxxx xxxxxx xx xxxxxx. Xx xxxx xxxxxxx, x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704) xx xxxx xx x xxxxxxxxx xxxxxx xxxxxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/BR209683). Xxx xxx xxx xxxxxx xx xxx xxxxxx xxxx xxx xxxxxxxxx.

**Xxxxxxxxxxx.**

```xml
    <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
    <Grid Background="Blue" Width="300" Height="45"> 
        <Grid.RowDefinitions> 
            <RowDefinition Height="5"/> 
            <RowDefinition/> 
            <RowDefinition Height="5"/> 
        </Grid.RowDefinitions> 
        <Grid.ColumnDefinitions> 
            <ColumnDefinition Width="5"/> 
            <ColumnDefinition/> 
            <ColumnDefinition Width="5"/> 
        </Grid.ColumnDefinitions> 
        <TextBox Grid.Row="1" Grid.Column="1"></TextBox> 
    </Grid> <!-- NOTE: EXAMPLE OF INEFFICIENT CODE; DO NOT COPY-PASTE.-->
```

**Xxxxxxxxx.**

```xml
    <Border BorderBrush="Blue" BorderThickness="5" Width="300" Height="45">
        <TextBox/>
    </Border>
```

-   Xx xxxxx xx xxxxxxx. Xxx xxxxxxxxxxx xxxxxxxx xxxx xxxxxxx (xxxxxxxx xxxxxxxxxxxx) xx xxxxxxxx xxxxxxx xxxxxx xxxx xxxxxxx’x xxxxxx xxxxxx xxx xxxxx xxxxxxxxxxx.

Xxx [**XxxxxXxxxxxxx.XxXxxxxxxxXxxxXxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Hh701823) xx x xxxxxx xxxxxxxxxx. Xxx xxx xxxx xxxxxxx xxxxx xxxxx xxxx xxx xxxxx'x xxxxx xxxx xx xxx xxxxx.

## Xxxxx xxxxxx xxxxxxx

Xxxxxxx xxxxxx xx xxxxxxxxxxx xx x xxxxx xxxx xxxx xxxx xxxxxxxxxxx xxxxxxxx. Xx xxx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR228084) xx **XxxxxxXxxxx** xx xxx [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208911) xxxx xxxxxxxx xxx xxxxxxxxx xxxxx xxxx xxx xxxxxxxx xxxxxxx xxx xxxxxxx xx x xxxxxx xxxx xxx xxxx xxxx xxxx xxxxxx xxxx xxxxx xxxxxxx xx xxxxxxxxxxx.

**Xxxxxxxxxxx.**

```xml
<Canvas Background="White">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

![Xxxx xxxxxxx xxxx xxxxx xxxxx xxxxxxx](images/solidvenn.png)

Xxx xxxxx xxxxx xx xxx xxxxxx, xxx xxxx'x x xxx xx xxx xxxxxxxxx xxxxxxx. Xxxxxx xxx xxxxxxxxx xxxxxx xxxxxxx xx xxxxxxxx.

![Xxxx xxxxxxx xxxx xxxxx xxxxxxxxxxx xxxxx](images/translucentvenn.png)

**Xxxxxxxxx.**

```xml
<Canvas Background="White" CacheMode="BitmapCache">
    <Ellipse Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Left="21" Height="40" Width="40" Fill="Blue"/>
    <Ellipse Canvas.Top="13" Canvas.Left="10" Height="40" Width="40" Fill="Blue"/>
</Canvas>
```

Xxxx xxx xxx xx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR228084). Xxx'x xxx xxxx xxxxxxxxx xx xxx xx xxx xxx-xxxxxx xxxxxxx xxxxxxx xxx xxxxxx xxxxx xxxx xxxxxx xxxx xx xx xxxxxxxxxxx xxxxx xxxxx, xxxxxxxxx xxx xxxxxxx.

## XxxxxxxxXxxxxxxxxxxx

XxxxxxxxXxxxxxxxxxxx xxx xxxxxxxxx xxxx xx xxxxx xxxx xxxxxxxxx xx x xxxxxxxx xxxxxx xxxxx. Xxxxxxxxx xxxx xxxx xxx xxxxx xx xxxxxxxxx xx xxxxxxxx xxxxxx. Xxx xxxxxxx, xxxxxx, xxxxxxx, xxxxxxxxx, xxx xx xx. Xx xxxxxxx, xx xxxx xxxxxxxxx XxxxxxxxXxxxxxxxxxxx xx xxx xxxxxxxxxxx xxxxxxxxx xxxxxx xxxx'xx xxxxx xxx. Xxx xxxxx xxx xxx xxxxxx xxxxx xxx xxxx xx xx x xxxxxx xxxxxxx.

**Xxxxxxxx xxxx x:Xxxx**. Xxx xxxxxxxx xxxx x:Xxxx xxxx xxx xxxxxxx xxxx xxx xxxxxxxx xxxxxxxxxxxx, xxx xxxxxxx xx xxxx xx xxxxxxxxxxxx xx xxxx xx xxx XxxxxxxxXxxxxxxxxx xx xxxxxxx. Xxxx xxxxxxx xxxxxxx x:Xxxx xxxxx xxx xxxxxxxx xxxx xxxx xxx xxxxx xxxxx xxxxxx xx xxxx xxxxxxxx, xx xxx xxxxxxxx xxxxx xx xxxxxx xxxxxxxxx xx xxxxxx x xxxxxxxxx xx.

**XxxxxxxxXxxxxxxxxxxx xx x XxxxXxxxxxx**. XxxxxxxxXxxxxxxxxxxx xxxxxxx xxxxxx xx x XxxxXxxxxxx xxxxx x xxxxxxx. Xxx xxxxxxxx xxxx xxxxxx x xxxx xx xxxx x XxxxxxxxXxxxxxxxxx xxx xxxxx xxxxxxxx xx xxx XxxxXxxxxxx. Xx xxx xxxx x XxxxXxxxxxx xxxx xx xxxx x xxx, xxxx xxxx xxx XxxxxxxxXxxxxxxxxx xxx xx xxx XxxxXxxxxxx xxx xxx xx xxx xxxx xxxxx.

## Xxx XXXY

XXXY xx x xxxxxx xxxxxxxxxxxxxx xx XXXX xxxxxx xxxx xxxxxx xxx xxxx-xxxxxxx xxxxx xx xxxxxxx. Xx xxxx xxxxxxxxx xxxx xxxxxx xxx xxxx xxx xxxx xxxxxxxx, xxx xxxxxx "xxxx-xxxx" xxx XXXX xxxxx xx xxxxxxx xxxx xxx xxxxxx xxxxxxxx xxxxx, xxx xxxxxxx XXX, XxxxxxxxXxxxxxxxxx, Xxxxxx, xxx xx xx. Xx xx xxxxxxxxxx xxxxxx-xxxxxx xx xxxxx xx xx xxxx xxxxxxxxx xxx xxxxxxx xxx xxxxxxx x XXXX Xxxx. Xx xxxxxxxx, xx xxxxxxx xxx xxxx xxxxxxxxx xx xxxxxx XXXX xxxxx xx xx xxxx. XXXY xx x xxxx xxxxxxx xxxxxxxxxxxxxx xxx xx xxx xxxxxx xxxx xxxxxxxxx xx xxxxxxxxxxx XXXX/XXXY xxxxx xx xx xx YY%. Xxx xxxxxxx, xxx xxxxx-xx Xxxxxx xxx xxx xxxxxx x YY% xxxxxxxxx xxxxx xxxxxxxxxx xx XXXY xxxxxxxx xxxx xxxxxx ~Yxx xx XXXY xxxxxx xx ~YYYxx xx XXXY xxxxxx. Xx xxxx xxxx xxxx xxxx xxxxxxx xxxxxxxx xxxx YY xx YY% xx XXX xxx YY xx YY% xx XxxYY xxxx.

XXXX xxxxx-xx xxxxxxxx xxx xxxxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxx xxx xxxxxxx xxxxx XXXY-xxxxxxx. Xxx xxxx xxx xxx, xxxxxx xxxx xxxx xxxxxxx xxxx xxxxxxxx XxxxxxXxxxxxxxXxxxxxx Y.Y xx xxxxx.

Xx xxxxx xxxxxxx xxx xxxx XXXY, xxxx xxxx xxx xx x xxxxxx xxxxxx; xxx YYxx xxx YYxx xxxxx xxx YY YY xx xxx xxxx XXXY.

<!--HONumber=Mar16_HO1-->
