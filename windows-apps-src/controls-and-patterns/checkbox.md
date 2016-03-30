---
Xxxxxxxxxxx: Xxxx xx xxxxxx xx xxxxxxxx xxxxxx xxxxx. Xxx xx xxxx xxx x xxxxxx xxxx xxxx xx xxx xxxxxxxx xxxx xxxxx.
xxxxx: Xxxxx xxxxx
xx.xxxxxxx: YYYYXYYY-YYYX-YYXX-XXYX-YYXYXXYYYYYY
xxxxx: Xxxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxx xxxxx

X xxxxx xxx xx xxxx xx xxxxxx xx xxxxxxxx xxxxxx xxxxx, xxx xxx xx xxxx xxx x xxxxxx xxxx xxxx xx xxx xxxxxxxx xxxx xxxxx. Xxx xxxxxxx xxx xxxxx xxxxxxxxxx xxxxxx: xxxxxxxxxx, xxxxxxxx, xxx xxxxxxxxxxxxx. Xxx xxxxxxxxxxxxx xxxxx xxxxxxx xxxx x xxxxxxxxxx xx xxx-xxxxxxx xxxx xxxx xxxxxxxxxx xxx xxxxxxxx xxxxxx.

![Xxxxxxx xx xxxxx xxx xxxx xxxx xxxxxx](images/checkboxstates.png)

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>
-   [**XxxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209316) 

## Xxxxxxx

Xxxx xxxxxxxx xxxx xxxxx xxxxx xx xxxxxx x xxxxxxxx xxxx.

![X xxxxxxxxx xxxxxxxxxxxx xxx xxxxxxxx xxxxxxxx xxxxxxx](images/CheckBox_Standard.png)

## <a name="is-this-the-right-control">
            </a>Xx xxxx xxx xxxxx xxxxxxx?

Xxx x xxxxxx xxxxx xxx xxx x xxxxxx xxx/xx xxxxxx, xxxx xx xxxx x "Xxxxxxxx xx?" xxxxx xxxxxxxx xx xxxx x xxxxx xx xxxxxxx xxxxxxxxx.

![X xxxxxx xxxxx xxx xxxx xxx xx xxxxxxxxxx xxxxxx](images/checkbox1.png)

Xxx xxxxxxxx xxxxx xxxxx xxx xxxxx-xxxxxx xxxxxxxxx xx xxxxx x xxxx xxxxxxx xxx xx xxxx xxxxx xxxx x xxxxx xx xxxxxxx xxxx xxx xxx xxxxxxxx xxxxxxxxx.

Xxx x xxxxxx xxxxxx, xxx xxxx xxxxxxxxxx xxxxxxx x xxxxx xxx xxx x xxxxxx xxxxxx xx xxxx xxx xxxxx xxx xx xxx xxxxxx xxx xxx xxxxxx xxxxxx xx xxx xxxxxx. Xxx xxx xxxxx xxxxxxxxxx x xxxxx xxx xxxxxxxxxxx (xx xxxx xx x xxxx xxxxxx, xxx xxxxxxx) xxxxx xxx xxxxxx xxxxxxxxxxx xxxxxx x xxxxxx xxxxxx xxxxxxxxxxx. Xxxx, xxxx xxxxx xxxxx xxxxx xxx xxxxx-xxxxxxxxx.

Xxxxxx x xxxxx xx xxxxx xxxxx xxxx xxxxx xxx xxxxxx xxx xxxxxxxxxxx xx xxxxxxx.

![Xxxxxxxxx xxxxxxxx xxxxxxx xxxx xxxxx xxxxx](images/checkbox2.png)

Xxxxxx xxxxx xxxxxxx, xxxxx x xxxxx xx xxxxx xxxxxxx xxxxxxxxxx x xxxxxx xxxxxx, xxxx xxxxx xxx xx x xxxxx xxxxxxxxxx x xxxxxxxx, xxxxxxxxxxx xxxxxx. Xxxx xxxxx xx xxxx xxxx xxx xxxxxx xxx xxxx xxx xxx xx xxxxxxxx, xxx x xxxxx xxxxxx xxxxxxx.

Xxxx xx xxxxxx xxxxxxx xx xxxx xxxx xxx xxxxxx, xxx xxx xxx x xxxxx xxx xx xxxxxxxx xxxxxxx xxx xxxxxx xxxxxxx xx xxx, xxxx, xx xxxx xx xxxxx xxxxxxx. Xxxx xxx xxxxxx xxxxxxx xx xxxx, xxx xxx xxx, xx xxxxx xxxxxxx, xxx xxx xxxxx xxx'x xxxxxxxxxxxxx xxxxx xx xxxxxxxxx x xxxxx xxxxxx. Xxx xxxxxxx xx x xxxxx xxxxxx xxxxx xxx xx x "Xxxxxx xxx" xxxxx xxx xxxx xxxxxxx xxxxxxxxxxxxx xxxx x xxxx xxxxxxx xxxx, xxx xxx xxx, xxx-xxxxx.

![Xxxxx xxxxx xxxx xx xxxx x xxxxx xxxxxx](images/checkbox3.png)

Xxx xxxx xxxx, xxx xxx [**Xxxxxxxxxxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/br209797).

## Xxxxxx x xxxxxxxx

Xx xxxxxx x xxxxxxxx, xxx xxx xxx XxxxxXxx xxxxxx. 
-   X XxxxxXxx xxx xx x xxxxx xx xxx xxxxxxx xxxxxxx. Xxx xxxxxxx xxx x xxxxxxxx xx x xxxxx xx xxxxx, xxxx xx x XxxxxXxxxx xx x Xxxx. 
-   Xx xxxxxx x xxxxx xx xxx xxxxxxxx, xxx xxx Xxxxxxx xxxxxxxx. Xxx xxxxx xxxxxxxx xxxx xx xxx xxxxxxxx. 
-   Xx xxxxxxx xx xxxxxx xxxx xxx xxxxx xxx xxxxx xxxxxxx, xxx x xxxxxxx xxx xxx Xxxxx xxxxx. Xxx xxxxx xxx xxx Xxxxxxx xxxxx xxxxxxx xxxxxxx, xxx xx xxxx xxxxx xxxx x xxxxxxxx xxxxxxx xxxx xxxxxxxxx xx xxxxxxx, xxxxx xxx Xxxxx xxxxx xxxxx xxxxxxxx xxx xxxxxxx xxxxx xxxxxxx, xxxxxx xx x xxx xxxx xxxxxx. 

Xxxxxxxx xxxxxxxxxx xxx xxxxx xxx xxxx xxxxx xxxxxxx. 
Xxxx xxxxxxx xxxxxxx xxxx xxxxxxxxxx xxx xxxxxxxxx xxxxx xxxxxxxx. Xxx xxxx xxxxxxxxxx xxxxx xxx xxxx Xxxxx xxxxx xxxxxxx. 



```XAML
<StackPanel>
    <CheckBox Content="Pepperoni" x:Name="pepperoniCheckbox" 
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Beef" x:Name="beefCheckbox" 
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Mushrooms" x:Name="mushroomsCheckbox"
        Checked="pizzaToppingCheckBox_Checked">
    </CheckBox>
    <CheckBox Content="Onions" x:Name="onionsCheckbox"
        Checked="pizzaToppingCheckBox_Checked" >
    </CheckBox>

    <!-- Display the selected toppings. -->
    <TextBlock>Toppings selected:</TextBlock>
    <TextBlock x:Name="toppingsList"></TextBlock>
</StackPanel>
```

Xxx xxxxxxx xxxxx xxx xxxxx xxxxxxx xxx xxx Xxxxx xxxxx. Xxxxx xxxx x xxxxxxxx xx xxxxxxx, xx xxxxxxxx xxx xxxxxxxxxx xx xxx xxxxx xxxx xxx xxxxxxx.

```C#
private void pizzaToppingCheckBox_Clicked(
    object sender, RoutedEventArgs e)
{
    CheckBox selectedCheckbox = sender as CheckBox;

    string selectedToppingsText = "";
    CheckBox[] checkboxes = 
        new CheckBox[] { pepperoniCheckbox, beefCheckbox, 
                         mushroomsCheckbox, onionsCheckbox };
    foreach(CheckBox c in checkboxes)
    {
        if (c.IsChecked == true)
        {
            if (selectedToppingsText.Length > 1)
            {
                selectedToppingsText += ", ";
            }
            selectedToppingsText += c.Content;
        }
     }
     toppingsList.Text = selectedToppingsText;
}
```



## <a name="dos-and-donts">
            </a>Xx'x xxx xxx'xx 

-   Xxxxxx xxxx xxx xxxxxxx xxx xxxxxxx xxxxx xx xxx xxxxx xxx xx xxxxx.
-   Xxxxx xxxxx xxx xxxx xxxxxxx xx xx xxxx xxxx xxx xxxxx.
-   Xxxx xxx xxxxxxxx xxxxx xx x xxxxxxxxx xxxx xxx xxxxx xxxx xxxxx xxxx xxx xxx xxxxxxx xx x xxxxx xxxx xxxxx xxxxx.
-   Xxx xxx xxxxxxx xxxx xxxxxx xxxx xxxxx xxxxxxxxxx xxxx xxx xx xxx xxxxxxx.
-   Xx xxxxx xxx xxxxxxx xxxxxxx xx xxxxxxx, xxxxxxxx xxxxx x [xxxxxx xxxxxx](scroll-controls.md) xxxxxxx xxxx x xxxxxx xxxxx xxxxxx xx.
-   Xxx xxx xxxxxxxxxxxxx xxxxx xx xxxxxxxx xxxx xx xxxxxx xx xxx xxx xxxx, xxx xxx xxx, xxx-xxxxxxx.
-   Xxxx xxxxx xxxxxxxxxxxxx xxxxx, xxx xxxxxxxxxxx xxxxx xxxxx xx xxxx xxxxx xxxxxxx xxx xxxxxxxx xxx xxxxx xxx xxx. Xxxxxx xxx XX xx xxxx xxx xxxx xxx xxx xxx xxx xxx-xxxxxxx.
-   Xx xxx xxxx xxxxxxx xx xxxxxxx, xxxxxxxx xxx xxx xxxxxxx xxxx xxxxxx xxx xxxx xxxx xxxxxx xx xxxxxxx xxxxxx xx.
-   Xx xxxxx xxx xxx xx xxxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xxxxx xx xxxxxx, xxxxxxxx xxxxx [xxxxx xxxxxxx](radio-button.md).
-   Xxx'x xxx xxx xxxxx xxx xxxxxx xxxx xx xxxx xxxxx. Xxx xxxxx xxxxxx xx xxxxxxxx xxx xxxxxx.
-   Xxx'x xxx x xxxxx xxx xx xx xx/xxx xxxxxxx xx xx xxxxxxx x xxxxxxx; xxxxxxx, xxx x xxxxxx xxxxxx.
-   Xxx'x xxx x xxxxx xxx xx xxxxxxx xxxxx xxxxxxxx, xxxx xx x xxxxxx xxx.
-   Xxx'x xxx xxx xxxxxxxxxxxxx xxxxx xx xxxxxxxxx x xxxxx xxxxx. Xxx xxxxxxxxxxxxx xxxxx xx xxxx xx xxxxxxxx xxxx xx xxxxxx xx xxx xxx xxxx, xxx xxx xxx, xxx-xxxxxxx. Xx, xxx'x xxxxx xxxxx xx xxx xx xxxxxxxxxxxxx xxxxx xxxxxxxx. Xxx xx xxxxxxx xx xxxx xxx xx xx, xxxx xxxxx xxx xxxx xxx xxxxxxxxxxxxx xxxxx xx xxxxxxxx xxxxxx xxxxxxxxx:

    ![Xx xxxxxxxxxxxxx xxxxx xxx](images/checkbox4_spicy.png)

    Xxxxxxx, xxx x xxxxx xxxxxx xxxxx xxxx xxx xxxxx xxxxxxx: Xxx xxxxx, Xxxxx, xxx Xxxxx xxxxx.

    ![Xxxxx xxxxxx xxxxx xxxx xxxxx xxxxxxx: Xxx xxxxx, Xxxxx, xxx Xxxxx xxxxx](images/spicyoptions.png)


## Xxxxxxx xxxxxxxx

-   [**XxxxxXxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209316) 


<!--HONumber=Mar16_HO1-->
