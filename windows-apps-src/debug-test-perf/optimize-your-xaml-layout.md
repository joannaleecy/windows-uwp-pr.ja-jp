---
xx.xxxxxxx: YYXXYYYY-YYXX-YYXX-XYYX-YYXYYYYXYXYY
xxxxx: Xxxxxxxx xxxx XXXX xxxxxx
xxxxxxxxxxx: Xxxxxx xxx xx xx xxxxxxxxx xxxx xx x XXXX xxx&\#YYYY;xxxx xx XXX xxxxx xxx xxxxxx xxxxxxxx. Xxxx xxx xxxx xxxxxx xxxxx xxx xxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxxxxxx xx xxxx XXXX xxx.
---
# Xxxxxxxx xxxx XXXX xxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Xxxxxxxxx XXXx**

-   [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/BR227511)

Xxxxxx xx xxx xxxxxxx xx xxxxxxxx xxx xxxxxx xxxxxxxxx xxx xxxx XX. Xxx xxxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxxxx xx XXXX xx xxxxxxx xxxxxx, xxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxxx xxx xx xxxxxxxx xxx xxxxxxx xxx XX xxxxxxxx xxxxxx xxxx. Xxxxxx xxx xx xx xxxxxxxxx xxxx xx x XXXX xxx—xxxx xx XXX xxxxx xxx xxxxxx xxxxxxxx. Xxxx xxx xxxx xxxxxx xxxxx xxx xxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxxxxxx xx xxxx XXXX xxx.

## Xxxxxx xxxxxx xxxxxxxxx

Xxx xxxxxxx xxxx xx xxxxxx xxxxxxxxxxx xxxxx xxxx xxxxxxxxxxx xxx xxxxxxxxxxxx xxxxxxxxx xx xxx xxxx xx XX xxxxxxxx. Xxxxxx xxxxx xx xxx xxxxxx xxxx, xxx xxxx xxx xxxxxxxxxx xxxxxxxx, xxx *xxxxx xxxxxxxxx xxxxxxxx* xxxx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209265) xx x [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR243371). Xxxxxxxxxxx xxx xxxx xx xxxxxxxx xxx xxxxxx xx xxx-xxxxx-xxxxxxxxx xxxxxxxx xxxxxxxxx xxxxxxxx x xxxxxxxxxxx xxxxxxxxxxx xxxxxxxx.

Xxxx XXx xxx xxxxxxxxxxx xx xxxxxxx xxxxxx xxxxx xxxxxxx xx xxxx, xxxxxxx xxxxx xx xxxxxx xxx xxxxxxxx. Xx xx xxxxxxxxxx xx xxxx xxxxxx, xxx xx xxxx xxxxx xxx xxxx XX xxx xx xxxxxxxx xxxx x xxxx xxxxxxx xxxxxx xxxxx. Xxxxx x xxxxxx xxxxx xxxxxxxx xxxxxx xxxxxxxxxxx.

### Xxxx xx xxxxxx xxxxxx xxxxxxxxx

Xxxxxxxx xxxxxx xxxxxxxxx xx x xxxxxxx xxx—xxx xxxxxxx, xxxxxxxx xxx xxxxxx xxxxx xxxx xxxx xxx-xxxxx xxxx—xxxx xxx xxxx x xxxxxxxxxx xxxxxx.

Xxx xxxxxxx xxxxxxxxxxx xxxxx xxxx xxxx xxxxxxxx xxxxxx xxxxxxxxx xxxx'x xxxxxxxx xx xxx XX, xxxx xx x [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242878) xx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/BR242705). Xxxxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242803) xxxxxxxx xxx x [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242348), xxxxx xxxxxxx x xxxxxxx xx XX xxxxxxxx xxxx xx xxxxxxxxxxxx xxxx xxxxx. Xxxx xxx xxxx xxxxxxx xx xxxxx xxxxxxxxxx xxxx xxxxx xx xxxx xxx, xxx xxxxxxxxxxxx xx xxx xxxxxxxxxxx xx xxxx xxxxxxx xxx x xxxxxxxxxxxxxx xxxxxx xx xxx xxxxxxx xxxxxxxxxxx xx xxxx xxx.

### Xxxxxxxx

Xxxxxxxx xxx xxxxxxxxx XX.

![Xxxx xxxxxx xxxxxxx](images/layout-perf-ex1.png)

Xxxxx xxxxxxxx xxxxx Y xxxx xx xxxxxxxxxxxx xxx xxxx XX. Xxxx xxxxxxxxxxxxxx xxxxxx xxxxxxx xx xxxxxx xxxxxxxxx xxxxxx xx xxx xxxxxx, xxx xxxxxxx xxxxxxxxxxxxx xx xxx xxxxxxxxxxxxxx xxxxxxx.

XxxxxxY: Xxxxxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209635) xxxxxxxx

Xxxxxxxx xxxx xx xxx xxxxxxxx xxxxx, xx xxxx Y xxxxx xxxxxxxx xxx xxxxxxx xx xxxxxxxxxxx xxxxxxxx.

```xml
  <StackPanel>
  <TextBlock Text="Options:" />
  <StackPanel Orientation="Horizontal">
      <CheckBox Content="Power User" />
      <CheckBox Content="Admin" Margin="20,0,0,0" />
  </StackPanel>
  <TextBlock Text="Basic information:" />
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Name:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Email:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Password:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <Button Content="Save" />
</StackPanel>
```

Xxxxxx Y: X xxxxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704)

Xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704) xxxx xxxx xxxxxxxxxx, xxx xxxx xxxx x xxxxxx xxxxx xxxxxxx.

```
  <Grid>
  <Grid.RowDefinitions>
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
      <ColumnDefinition Width="Auto" />
      <ColumnDefinition Width="Auto" />
  </Grid.ColumnDefinitions>
  <TextBlock Text="Options:" Grid.ColumnSpan="2" />
  <CheckBox Content="Power User" Grid.Row="1" Grid.ColumnSpan="2" />
  <CheckBox Content="Admin" Margin="150,0,0,0” Grid.Row="1" Grid.ColumnSpan="2" />
  <TextBlock Text="Basic information:" Grid.Row="2" Grid.ColumnSpan="2" />
  <TextBlock Text="Name:" Width="75" Grid.Row="3" />
  <TextBox Width="200" Grid.Row="3" Grid.Column="1" />
  <TextBlock Text="Email:" Width="75" Grid.Row="4" />
  <TextBox Width="200" Grid.Row="4" Grid.Column="1" />
  <TextBlock Text="Password:" Width="75" Grid.Row="5" />
  <TextBox Width="200" Grid.Row="5" Grid.Column="1" />
  <Button Content="Save" Grid.Row="6" />
</Grid>
```

Xxxxxx Y: X xxxxxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn879546):

Xxxx xxxxxx xxxxx xx xxxx x xxx xxxx xxxxxxx xxxx xxxxx xxxxxx xxxxxx, xxx xxx xx xxxxxx xx xxxxxxxxxx xxx xxxxxxxx xxxx x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704).

```xml
<RelativePanel>
  <TextBlock Text="Options:" x:Name="Options" />
  <CheckBox Content="Power User" x:Name="PowerUser" RelativePanel.Below="Options" />
  <CheckBox Content="Admin" Margin="20,0,0,0" 
            RelativePanel.RightOf="PowerUser" RelativePanel.Below="Options" />
  <TextBlock Text="Basic information:" x:Name="BasicInformation"
           RelativePanel.Below="PowerUser" />
  <TextBlock Text="Name:" RelativePanel.AlignVerticalCenterWith="NameBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="NameBox"               
           RelativePanel.Below="BasicInformation" />
  <TextBlock Text="Email:"  RelativePanel.AlignVerticalCenterWith="EmailBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="EmailBox"
           RelativePanel.Below="NameBox" />
  <TextBlock Text="Password:" RelativePanel.AlignVerticalCenterWith="PasswordBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="PasswordBox"
           RelativePanel.Below="EmailBox" />
  <Button Content="Save" RelativePanel.Below="PasswordBox" />
</RelativePanel>
```

Xx xxxxx xxxxxxxx xxxx, xxxxx xxx xxxx xxxx xx xxxxxxxxx xxx xxxx XX. Xxx xxxxxx xxxxxx xx xxxxxxxxx xxxxxxxxxxx xxx xxx xxxxxxxxx, xxxxxxxxx xxxxxxxxxxx, xxxxxxxxxxx, xxx xxxxxxxxxxxxxxx.

## Xxx xxxxxx-xxxx xxxxx xxx xxxxxxxxxxx XX

X xxxxxx XX xxxxxxxxxxx xx xx xxxx x xxxxxx xxxxx xxxxxxxx xxxxxxx xxxx xxxxx. Xxxxxxxxx xxxxxxx, xxxxxxx, xxxxxxxxxx, xxx xxxxxxxxxx xxx xxxx xx xxxxxxxx xxx xxxxxxxx xxxx xxx. Xxx XXXX [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704) xxxxxxx xx xxxxxxxxx xx xxxxxxx xxxxxx xxxxxxxxxxx xxx xxxxxxxx xxxx xxxxxxx.

**Xxxxxxxxx**  Xx xxx xxx xxxxxxxxxxx, xxx x xxxxxx-xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704). Xx xxx xxxxxx [**XxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704-rowdefinitions) xx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704-columndefinitions).

### Xxxxxxxx

```xml
<Grid>
    <Ellipse Fill="Red" Width="200" Height="200" />
    <TextBlock Text="Test" 
               HorizontalAlignment="Center" 
               VerticalAlignment="Center" />
</Grid>
```

![Xxxx xxxxxxxx xx x xxxxxx](images/layout-perf-ex2.png)

```xml
<Grid Width="200" BorderBrush="Black" BorderThickness="1">
    <TextBlock Text="Test1" HorizontalAlignment="Left" />
    <TextBlock Text="Test2" HorizontalAlignment="Right" />
</Grid>
```

![Xxx xxxx xxxxxx xx x xxxx](images/layout-perf-ex3.png)

## Xxx x xxxxx'x xxxxx-xx xxxxxx xxxxxxxxxx

[
            **Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704), [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209635), [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn879546), xxx [**XxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209378) xxxxxxxx xxxx xxxxx-xx xxxxxx xxxxxxxxxx xxxx xxx xxx xxxx x xxxxxx xxxxxx xxxx xxxxxxx xxxxxx xx xxxxxxxxxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209250) xxxxxxx xx xxxx XXXX. Xxx xxx xxxxxxxxxx xxxx xxxxxxx xxx xxxxx-xx xxxxxx xxx: **XxxxxxXxxxx**, **XxxxxxXxxxxxxxx**, **XxxxxxXxxxxx**, xxx **Xxxxxxx**. Xxxx xx xxxxx xx x [**XxxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR242362), xx xxx xxx xxx xxxx xxxx xxxxxxxx xxx xxxxxxxxxx. Xxxx’xx xxxxxxxx xx xx x xxxx xxxxxxxxxxx xxx x xxxxxxxx **Xxxxxx** xxxxxxx.

Xx xxxx XX xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209250) xxxxxxxx xxxxxx xxxxx xxxxxx, xxx xxx xxxxx-xx xxxxxx xxxxxxx, xxxxx xxxxx xx xxxxx xxxxxxx xx xxx xxxxxx xxxxxxxxx xx xxxx xxx. Xx xxxxxxxxx xxxxxxxxxx, xxxx xxx xx x xxxxxxxxxxx xxxxxxx, xxxxxxxxxx xx xxx xxxx xx xxxxxxxx XX.

### Xxxxxxxx

```xml
<RelativePanel BorderBrush="Red" BorderThickness="2" CornerRadius="10" Padding="12">
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

## Xxx **XxxxXxxxxxx** xxxxxx xx xxxxxxx xx xxxxxx xxxxxxx

Xxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706) xxxxx xxxxxxx xxx xxxxxxx xxxxxx xxx xxxxxxxxxx xx xxxxxx xxxxxxx: [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706-layoutupdated) xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706-sizechanged). Xxx xxxxx xx xxxxx xxx xx xxxxx xxxxxx xx xxxxxxx xxxxxxxxxxxx xxxx xx xxxxxxx xx xxxxxxx xxxxxx xxxxxx. Xxx xxxxxxxxx xx xxx xxx xxxxxx xxx xxxxxxxxx, xxx xxxxx xxx xxxxxxxxx xxxxxxxxxxx xxxxxxxxxxxxxx xx xxxxxxxx xxxxxxx xxxx.

Xxx xxxx xxxxxxxxxxx, [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706-sizechanged) xx xxxxxx xxxxxx xxx xxxxx xxxxxx. **XxxxXxxxxxx** xxx xxxxxxxxx xxxxxxxxx. Xx xx xxxxxx xxxxxx xxxxxx xxxx xxx xxxx xx xxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706) xxx xxxx xxxxxxx.

[
            **XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208706-layoutupdated) xx xxxx xxxxxx xxxxxx xxxxxx, xxx xx xxx xxxxxx xxxxxxxxx—xx xx xxxxxx xx xxxxx xxxxxxx xxxxxxxx xxx xxxxxxx xx xxxxxxx. Xx xx xxxxxxx xx xxxx xx xxxxx xxxxxxxxxx xx xxx xxxxx xxxxxxx, xx xxxxx xxxx xxx xxxx xx xxx xxxx xxxxx xxxx xxxxxx. Xxx **XxxxxxXxxxxxx** xxxx xx xxx xxxx xx xxxx xxxx xx xxxxxxx xx xxxxxxxxxxxx xxxxxxx xxxxxxxx xxxx (xxxxx xx xxxxxxxx).

## Xxxxxxxx xxxxxxx xxxxxx

Xxxxxxxxxxx xx xxxxxxxxx xxx x xxxxxxxxxxxxx xxxx xxxxxxxx xxxxxxx xxxxxxxxxx xxxxxx. Xxxx xxxxxx xx xxxxxxxxx xxxx xx xxxxxxxxxxx xxxxx xxxxx xxxxxxxx xxx xxxxxx xxxxxxxx xxxx xx xxxxxxx xx xxx XX xxx’xx xxxxxxxxxxxx. Xxx xxxxxxx, xx xxx’xx xxxxxxxx xxxxxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/BR242704), [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR209635) , xxx [**XxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn879546), xxx xxxxxx xxxxxx xxx xxxxx xxxx xxxxxxxx xxx xxxxxxx xxxxxxx xx xxxx xxxxxx xxxxx xx xxx xxxxxxxxxxxxxx.

Xxxxx XXXX xxxxx xx xxxxxxxxx xxx xxxx xxxxxxxxxxx, xxx xxx xxx xxxxxx xxxxxxx xxxxxxx xxxxxxxxxxx xxx xxxxxxx XX.

<!--HONumber=Mar16_HO1-->
