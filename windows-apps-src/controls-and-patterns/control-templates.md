---
Xxxxxxxxxxx: Xxx xxx xxxxxxxxx x xxxxxxx'x xxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xx xxxxxxxx x xxxxxxx xxxxxxxx xx xxx XXXX xxxxxxxxx.
XX-XXXX: 'xxx\_xxxx\_xxxxxx\_xxx.xxxxxxx\_xxxxxxxxx'
XXXXxxx: 'XxxxxxxxxXxx:/xxxxxxx/xxxxxxx/xxxx'
Xxxxxx.Xxxxxxx: xXXXxXxxxxxx YYXXxxx
xxxxx: Xxxxxxx xxxxxxxxx
xx.xxxxxxx: YXYYYYYY-XYXY-YYYX-YXYX-XXXXYXYYYXXX
xxxxx: Xxxxxxx xxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxx xxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**XxxxxxxXxxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391)
-   [**Xxxxxxx.Xxxxxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.template.aspx)

Xxx xxx xxxxxxxxx x xxxxxxx'x xxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xx xxxxxxxx x xxxxxxx xxxxxxxx xx xxx XXXX xxxxxxxxx. Xxxxxxxx xxxx xxxx xxxxxxxxxx, xxxx xx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209395), [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209414), xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209404), xxxx xxx xxx xxx xx xxxxxxx xxxxxxxxx xxxxxxx xx xxx xxxxxxx'x xxxxxxxxxx. Xxx xxx xxxxxxx xxxx xxx xxx xxxx xx xxxxxxx xxxxx xxxxxxxxxx xxx xxxxxxx. Xxx xxx xxxxxxx xxxxxxxxxx xxxxxxxxxxxxxx xx xxxxxxxx x xxxxxxxx xxxxx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xxxxx. Xxxx, xx xxxx xxx xxx xx xxxxxx x **XxxxxxxXxxxxxxx** xx xxxxxxxxx xxx xxxxxxxxxx xx x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxxxx.

## Xxxxxx xxxxxxx xxxxxxxx xxxxxxx


Xx xxxxxxx, x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxxxx xxxx xxx xxxxxxx (xxx xxxxxx xx xxxxxx xxxx xx xxx **XxxxxXxx**) xx xxx xxxxx xx xxx xxxxxxxxx xxx, xxx x xxxxx xxxx xxxxxxxxx xxxx x xxxx xxxxxxxx xxx **XxxxxXxx**. Xxxxx xxxxxxxxxxxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xx xxx **XxxxxXxx**.

Xxxx'x x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxx xxx xxxxxxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xxxxx xx xxx `Unchecked`, `Checked`, xxx `Indeterminate` xxxxxx.

![xxxxxxx xxxxxxxx xxxxxxxx](images/templates-checkbox-states-default.png)

Xxx xxx xxxxxx xxxxx xxxxxxxxxxxxxxx xx xxxxxxxx x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xxx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316). Xxx xxxxxxx, xx xxx xxxx xxx xxxxxxx xx xxx xxxxx xxx xx xx xxxxx xxx xxxxxxxxx xxx, xxx xxx xxxx xx xxx xx **X** xx xxxxxxxx xxxx x xxxx xxxxxxxx xxx xxxxx xxx. Xxx xxxxxxx xxxxx xxxxxxxxxxxxxxx xx xxx **XxxxxxxXxxxxxxx** xx xxx **XxxxxXxx**.

Xx xxx x xxxxxx xxxxxxxx xxxx x xxxxxxx, xxxxxx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209465) xxxxxxxx xx xxx xxxxxxx. Xxxx'x x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxx x **XxxxxxxXxxxxxxx** xxxxxx `CheckBoxTemplate1`. Xx xxxx xxx Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX) xxx xxx **XxxxxxxXxxxxxxx** xx xxx xxxx xxxxxxx.

```XAML
<CheckBox Content="CheckBox" Template="{StaticResource CheckBoxTemplate1}" IsThreeState="True" Margin="20"/>
```

Xxxx'x xxx xxxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxx xx xxx `Unchecked`, `Checked`, xxx `Indeterminate` xxxxxx xxxxx xx xxxxx xxx xxxxxxxx.

![xxxxxx xxxxxxxx xxxxxxxx](images/templates-checkbox-states.png)

## Xxxxxxx xxx xxxxxx xxxxxxxxx xx x xxxxxxx


Xxxx xxx xxxxxx x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391), xxx xxxxxxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706) xxxxxxx xx xxxxx x xxxxxx xxxxxxx. X **XxxxxxxXxxxxxxx** xxxx xxxx xxxx xxx **XxxxxxxxxXxxxxxx** xx xxx xxxx xxxxxxx. Xxx xxxx xxxxxxx xxxxxxx xxxxxxxx xxxxx **XxxxxxxxxXxxxxxx** xxxxxxx. Xxx xxxxxxxxxxx xx xxxxxxx xxxxx xx xxx xxxxxxx'x xxxxxx xxxxxxxxx.

Xxxx XXXX xxxxxxx x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391) xxx x [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxx xxxxxxxxx xxxx xxx xxxxxxx xx xxx xxxxxxx xx xxxxx xxx xxxxxxxxx xxx. Xxx xxxx xxxxxxx xx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209250). Xxx xxxxxxx xxxxxxxxx x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br243355) xx xxxxxx xx **X** xxxx xxxxxxxxx xxxx x xxxx xxxxxxxx xxx **XxxxxXxx**, xxx xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243343) xxxx xxxxxxxxx xx xxxxxxxxxxxxx xxxxx. Xxxx xxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208962) xx xxx xx Y xx xxx **Xxxx** xxx xxx **Xxxxxxx** xx xxxx xx xxxxxxx, xxxxxxx xxxxxx.

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}" 
            BorderThickness="{TemplateBinding BorderThickness}" 
            Background="{TemplateBinding Background}">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20" 
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" 
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}" 
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph" 
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z" 
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                  FlowDirection="LeftToRight" 
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph" 
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter" 
                              ContentTemplate="{TemplateBinding ContentTemplate}" 
                              Content="{TemplateBinding Content}" 
                              Margin="{TemplateBinding Padding}" Grid.Row="1" 
                              HorizontalAlignment="Center" 
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

## Xxxxxxx xxx xxxxxx xxxxxxxx xx x xxxxxxx


X xxxxxx xxxxxxxx xxxxxxxxx xxx xxxxxxxxxx xx x xxxxxxx xxxx xx xx xx x xxxxxxx xxxxx. Xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxxxx xxx Y xxxxx xxxxxx: `Checked`, `Unchecked`, xxx `Indeterminate`. Xxx xxxxx xx xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209798) xxxxxxxx xxxxxxxxxx xxx xxxxx xx xxx **XxxxxXxx**, xxx xxx xxxxx xxxxxxxxxx xxxx xxxxxxx xx xxx xxx.

Xxxx xxxxx xxxxx xxx xxxxxxxx xxxxxx xx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209798), xxx xxxxxxxxxxxxx xxxxxx xx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316), xxx xxx xxxxxxxxxx xx xxx **XxxxxXxx**.

|                     |                    |                         |
|---------------------|--------------------|-------------------------|
| **XxXxxxxxx** xxxxx | **XxxxxXxx** xxxxx | **XxxxxXxx** xxxxxxxxxx |
| **xxxx**            | `Checked`          | Xxxxxxxx xx "X".        |
| **xxxxx**           | `Unchecked`        | Xxxxx.                  |
| **xxxx**            | `Indeterminate`    | Xxxxxxxx x xxxxxx.      |

 

Xxx xxxxxxx xxx xxxxxxxxxx xx x xxxxxxx xxxx xx xx xx x xxxxxxx xxxxx xx xxxxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xxxxxxx. X **XxxxxxXxxxx** xxxxxxxx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208817) xx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243053) xxxx xxxxxxx xxx xxxxxxxxxx xx xxx xxxxxxxx xx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391). Xxxx xxx xxxxxxx xxxxxx xxx xxxxx xxxx xxx [**XxxxxxXxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br209031) xxxxxxxx xxxxxxxxx, xxx xxxxxxxx xxxxxxx xx xxx **Xxxxxx** xx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210490) xxx xxxxxxx. Xxxx xxx xxxxxxx xxxxx xxx xxxxx, xxx xxxxxxx xxx xxxxxxx. Xxx xxx **XxxxxxXxxxx** xxxxxxx xx [**XxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209014) xxxxxxx. Xxx xxx **XxxxxxXxxxxXxxxx** xxxxxxx xx xxx [**XxxxxxXxxxxXxxxxxx.XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh738505) xxxxxxxx xxxxxxxx, xxxxx xxx xxx xx xxx xxxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208706) xx xxx **XxxxxxxXxxxxxxx**.

Xxxx XXXX xxxxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xxxxxxx xxx xxx `Checked`, `Unchecked`, xxx `Indeterminate` xxxxxx. Xxx xxxxxxx xxxx xxx [**XxxxxxXxxxxXxxxxxx.XxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh738505) xxxxxxxx xxxxxxxx xx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209250), xxxxx xx xxx xxxx xxxxxxx xx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209391). Xxx `Checked`**XxxxxxXxxxx** xxxxxxxxx xxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208962) xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br243355) xxxxx `CheckGlyph` (xxxxx xx xxxx xx xxx xxxxxxxx xxxxxxx) xx Y. Xxx `Indeterminate`**XxxxxxXxxxx** xxxxxxxxx xxxx xxx **Xxxxxxx** xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243343) xxxxx `IndeterminateGlyph` xx Y. Xxx `Unchecked`**XxxxxxXxxxx** xxx xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208817) xx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210490), xx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxxxxx xx xxx xxxxxxx xxxxxxxxxx.

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}" 
            BorderThickness="{TemplateBinding BorderThickness}" 
            Background="{TemplateBinding Background}">
            
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="CheckStates">
                <VisualState x:Name="Checked">
                    <VisualState.Setters>
                        <Setter Target="CheckGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1" 
                         Storyboard.TargetName="CheckGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
                <VisualState x:Name="Unchecked"/>
                <VisualState x:Name="Indeterminate">
                    <VisualState.Setters>
                        <Setter Target="IndeterminateGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1"
                         Storyboard.TargetName="IndeterminateGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20" 
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" 
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}" 
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph" 
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z" 
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                  FlowDirection="LeftToRight" 
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph" 
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter" 
                              ContentTemplate="{TemplateBinding ContentTemplate}" 
                              Content="{TemplateBinding Content}" 
                              Margin="{TemplateBinding Padding}" Grid.Row="1" 
                              HorizontalAlignment="Center" 
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

Xx xxxxxx xxxxxxxxxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xxxxxxx xxxx, xxxxxxxx xxxx xxxxxxx xxxx xxx [**XxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209316) xxxx xxxx xxx `Unchecked` xxxxx xx xxx `Checked` xxxxx, xxxx xx xxx `Indeterminate` xxxxx, xxx xxxx xxxx xx xxx `Unchecked` xxxxx. Xxxx xxx xxx xxxxxxxxxxx.

|                                      |                                                                                                                                                                                                                                                                                                                                                |                                                   |
|--------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| Xxxxx xxxxxxxxxx                     | Xxxx xxxxxxx                                                                                                                                                                                                                                                                                                                                   | XxxxxXxx xxxxxxxxxx xxxx xxx xxxxxxxxxx xxxxxxxxx |
| Xxxx `Unchecked` xx `Checked`.       | Xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208817) xxxxx xx xxx `Checked`[**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xx xxxxxxx, xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208962) xx `CheckGlyph` xx Y.                                                                                                                                                         | Xx X xx xxxxxxxxx.                                |
| Xxxx `Checked` xx `Indeterminate`.   | Xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208817) xxxxx xx xxx `Indeterminate`[**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xx xxxxxxx, xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208962) xx `IndeterminateGlyph` xx Y. Xxx **Xxxxxx** xxxxx xx xxx `Checked`**XxxxxxXxxxx** xx xxxxxxx, xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br228078) xx `CheckGlyph` xx Y. | X xxxxxx xx xxxxxxxxx.                            |
| Xxxx `Indeterminate` xx `Unchecked`. | Xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208817) xxxxx xx xxx `Indeterminate`[**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209007) xx xxxxxxx, xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208962) xx `IndeterminateGlyph` xx Y.                                                                                                                                           | Xxxxxxx xx xxxxxxxxx.                             |

 
Xxx xxxx xxxx xxxxx xxx xx xxxxxx xxxxxx xxxxxx xxx xxxxxxxx, xxx xx xxxxxxxxxx xxx xx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210490) xxxxx xxx xxx xxxxxxxxx xxxxx, xxx [Xxxxxxxxxxxx xxxxxxxxxx xxx xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/jj819808).

## Xxx xxxxx xx xxxx xxxx xxxxxx xxxxxx

X xxxx xxx xx xxxxx xxxxxx xx xxxx xxxxxxxx xx xx xxxxx-xxxxx xx x xxxxxxx xx xxx Xxxxxxxxx Xxxxxx Xxxxxx **Xxxxxxxx Xxxxxxx** xxx xxxxxx **Xxxx Xxxxx** xx **Xxxx Xxxxx** (xxxxxxxxx xx xxx xxxxxxx xxx xxx xxxxx-xxxxxxxx xx). Xxx xxx xxxx xxxxx xx xxxxxxxx xxxxx xx xxxxxxxxx **Xxxxx Xxxxxxxx** xx xxxxxx x xxx xxx xx xxxxxxxxx **Xxxxxx Xxxxx**.

## Xxxxxxxx xxx xxxxxxxxxxxxx

Xxxx xxx xxxxxx x xxx xxxxxxxx xxx x xxxxxxx, xx xxxxxxxx xx xxxxxxxx xxxxxxxx xxx xxxxxxx'x xxxxxxxx xxx xxxxxx xxxxxxxxxx, xxx xxxxx xxxx xx xxxxxxxx xxx xxx xxxxxxx xxxxxxxxxx xxxxxx xx xxxxxxxxxxxxx xxxxxxxxxx. Xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxxx xxx Xxxxxxxxx XX Xxxxxxxxxx xxxxxxxxx xxx xxxxxxxxxxxxx. Xxx xx xxx xxxxxxx xxxxxxxx xxx xxxxx xxxxxxxxx xxxx xxxxxxx xxx xxxxxx XX Xxxxxxxxxx xxxxxxx xxxxx xxx xxxxxxxx xxxx xxx xxxxxxxxxxx xxx xxx xxxxxxx'x xxxxxxx xxx xxxxxxxx. Xxxxx xxxxxxx xxxxx xxx xxxxxxxx xxx xxxxxxxxxxx xx XX Xxxxxxxxxx xxxxxxx xxxx xx xxxxxxxxx xxxxxxxxxxxx, xxx xxxx xxxxxxx x xxxxxxx xx xx xxxxxxxxxx xx x xxxx xx x xxxxxx xxxxxxxxxx xxx XX.

Xx xxxxxxxx xxx xxxxx xxxxxxx xxxxx xxx xxxx xx xxxxxxx xxxx xx xxx xxxxxxxxxxxxx xxxxxxxxxxxx xx XX Xxxxxxxxxx, xxxxxxx xxxxxxx xxxxxxx xxxxx xxxxxxxxxxxxx xxxxxxx xx x xxxxxxxx xxxxx, xx xxxxxxxxxx xxxx. Xxx xxxxxxxxxx xxxxx xxxxxxxxx xxxx xxxxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xxxxxxx xxx xxxxx xxxxxx xxxxxxx xxxxx xxxxx xx xxxxx xx xxx xxxxxxxxx, xx xxxx xxxxxxxxxxxxx xxxx xx xxxxxxxx xxxxxxxxx xxxxxxxxxxxx xx xxxxxx xxxxxxx xx xxxxxxx xx xxxxxxxx.

Xxxx xxx xxxxxx x xxxxxxxxxx xxx xxxxxx xxxxxxx, xxx xxxxxxxxx xxxx xxxx xxxx xx xxxxxx x xxx xxxxxxxxxx xxxx xx xx xxxxx xxxx xx. Xxx xxxx xxxx, xxx [Xxxxxx xxxxxxxxxx xxxxx](../accessibility/custom-automation-peers.md).

## Xxxxx xxxx xxxxx x xxxxxxx'x xxxxxxx xxxxxxxx

Xxx xxxxxx xxxx xxxxxxxx xxx xxxxxx xxx xxxxxxxxx xxx XXXX xxxxxxxx xxxx xxx xxxxxxxx xx xxx xxxx xxxxxxxx XXXX xxx'x xxx xx xxx xxxx xxx **Xxxx Xxxxx** xx **Xxxx Xxxxx** xxxxxxxxxx xxxxxxxxx xxxxxxxxxx. Xxxx xxxxx xxxxx xxx xxxxx xx xxx xxxxxx xxxxxx, xxx xxxxx xxxxxxxxx xxxx, xxx xxx xxxx XXXX xxx xxx xxxxx xxxx xxxxxxxx xxx xxxxxxxx. Xxx xxxxxx xxx xx xxxxxx xxxxxxxx xx xxx'xx xxxxxxx xxxxxxx xxxxxxxxx x xxxxxxxx xxx xxxx xx xxx xxxx xxx xxxxxxxx xxxxxxxx xxxxxx xxxx, xx xx xxxxxx xxxx xxxx xxx xxxxxxxx xxx xxx xx xxx xxxxxxxx xxxxx xxxxxx xxxxxx.

## Xxxxx xxxxxxxxx xx xxxxxxx xxxxxxxxx

Xxx xxxx xx xxx xxxxxxxxxx xx xxx XXXX xxxxxxxx, xxx xxx xxxx xxxxxxx xxxxxxxx xxxxxxxxxx xxxx xxx xxx [{XxxxxXxxxxxxx} xxxxxx xxxxxxxxx](../xaml-platform/themeresource-markup-extension.md). Xxxx xx x xxxxxxxxx xxxx xxxxxxx x xxxxxx xxxxxxx xxxxxxxx xx xxx xxxxxxxxx xxxx xxx xx xxxxxxxxx xxxxxx xxxxxxxxx xx xxxxx xxxxx xx xxxxxxxxx xxxxxx. Xxxx xx xxxxxxxxxxxx xxxxxxxxx xxx xxxxxxx xxx xxxxxx, xxxxxxx xxx xxxx xxxxxxx xx xxx xxxxxx xx xx xxxxxx xxxxx xx xxxxxx xxxxxxx xxxx xxxx x xxxx, xxxxx, xx xxxx xxxxxxxx xxxxx xxxxxxx xx xxx xxxxxx xxxxxxx. Xxxx xxxx xxx xxx XXXX xxxxxxxx xxxxxx xxx xxx x xxxxxxxx xxx xxxx'x xxxxxxxxxxx xxx xxxx xxxxx, xx xxxx xxx xxxxx xxxxxxx xx xx xxx'x XX xxx xxxxxxxxxx xx xxx xxxx'x xxxxxxxxxx xxxxx xxxxxx.

**Xxxx**  
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx XXX xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

 

 



<!--HONumber=Mar16_HO1-->
