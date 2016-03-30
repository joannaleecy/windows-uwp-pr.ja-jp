---
Xxxxxxxxxxx: Xxxxxxxx xxxx xxxxxxxxx xxx x xxx xxxxxxx xx Xxxxxxx YY, xxxxxxxx xxx xx xxxxxx xxxx xxx xxxx xxxxxxxxxxxx xxxxxxx xxxxx x xxxxxx xxx xxxxxxxx xxxxxx xxxxxxxx xxxx xxxxxx xx xxxxxxxxx xxxxxx xxxxxxxxx.
xxxxx: Xxxxxx xxxxxxxx xxxxx
xx.xxxxxxx: YYYYXYYX-XYXY-YYXY-XXYX-YYYXYYYYYYXY
xxxxx: Xxxxxx xxxxxxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxx xxxxxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxxx xxxx xxxxxxxxx xxx x xxx xxxxxxx xx Xxxxxxx YY, xxxxxxxx xxx xx xxxxxx xxxx xxx xxxx xxxxxxxxxxxx xxxxxxx xxxxx x xxxxxx xxx xxxxxxxx xxxxxx xxxxxxxx xxxx xxxxxx xx xxxxxxxxx xxxxxx xxxxxxxxx. Xxxx xxxxxxx xxxxx xxx xxx xx xxxxxx xxxxxxxx xxxx xxxxx xxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx. Xxx xxx xxxxxxxx xxxx xx xxxxxxxx xxxxxxxx xxx xxxxxxxxxx, xxx xxx [Xxxxxxxx xxxxx xxxxxx](tiles-and-notifications-adaptive-tiles-schema.md).

(Xx xxx'x xxxx, xxx xxx xxxxx xxx xxx xxxxxx xxxxxxxxx xxxx xxx [Xxxxxxx Y xxxx xxxxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh761491) xxxx xxxxxxxxx xxxxxxxxxxxxx xxx Xxxxxxx YY.)

## <span id="Getting_started">
            </span>
            <span id="getting_started">
            </span>
            <span id="GETTING_STARTED">
            </span>Xxxxxxx xxxxxxx


**Xxxxxxx XxxxxxxxxxxxxXxxxxxxxxx.** Xx xxx'x xxxx xx xxx X# xxxxxxx xx XXX xx xxxxxxxx xxxxxxxxxxxxx, xxxxxxx xxx XxXxx xxxxxxx xxxxx [XxxxxxxxxxxxxXxxxxxxxxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki). Xxx X# xxxxxxx xxxxxxxx xx xxxx xxxxxxx xxx XxxxxxxxxxxxxXxxxxxxxxx.

**Xxxxxxx Xxxxxxxxxxxxx Xxxxxxxxxx.** Xxxx xxxx XXX xxx xxxxx xxx xxxxxx xxxxxxxx xxxx xxxxx xx xxxxxxxxx xx xxxxxxx xxxxxx xxxxxxx xx xxxx xxxx xx xxx xxxx xx, xxxxxxx xx Xxxxxx Xxxxxx'x XXXX xxxxxx/xxxxxx xxxx. Xxx xxx xxxx [xxxx xxxx xxxx](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/09/22/introducing-notifications-visualizer-for-windows-10.aspx) xxx xxxx xxxxxxxxxxx, xxx xxx xxx xxxxxxxx Xxxxxxxxxxxxx Xxxxxxxxxx [xxxx](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1).

## <span id="Usage_guidance">
            </span>
            <span id="usage_guidance">
            </span>
            <span id="USAGE_GUIDANCE">
            </span>Xxxxx xxxxxxxx


Xxxxxxxx xxxxxxxxx xxx xxxxxxxx xx xxxx xxxxxx xxxxxxxxx xxxx xxxxxxx xxx xxxxxxxxxxxx xxxxx. Xxxxxxxx xxxx xx xxxxx xxx xxxxxxxx xxxx xxxxxxxx xxxxxxx xxx xxx'x xxxxx x xxxxxxxxxx xxxxxx xxxxxxxx xx xxxxx xxx. Xxx xxxxx xxxxxxxxxx xx x xxxxxxxxxxxx xxxxxx xx xxxxx xx xxx xxxxxxxx xxxxxx xx xxxxx xx xxxx xxxxxx, xxxxxxx xx'x xxxxx, xxxxxx, xx xxxxxxx, xx xxxxxxx xxxxxx.

Xxxxx xxx xxxxxxxx xxxxxxxxxx xxxx xxx xx xxxxx xx xxxxxxxx xx xxxxx xx xxxxxxx x xxxxxxxx xxxxxx xxxxxxxx. Xxxxx xxx xx xxxxxx-xxxxxxxx xx xxxxxxxxxxxx-xxxxxxxx.

## <span id="A_basic_example">
            </span>
            <span id="a_basic_example">
            </span>
            <span id="A_BASIC_EXAMPLE">
            </span>X xxxxx xxxxxxx


Xxxx xxxxxxx xxxxxxxxxxxx xxxx xxx xxxxxxxx xxxx xxxxxxxxx xxx xxxxxxx.

```XML
<tile>
  <visual>
  
    <binding template="TileMedium">
      ...
    </binding>
  
    <binding template="TileWide">
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </binding>
  
    <binding template="TileLarge">
      ...
    </binding>
  
  </visual>
</tile>
```

```CSharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = ...
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = "Jennifer Parker",
                        Style = TileTextStyle.Subtitle
                    },
  
                    new TileText()
                    {
                        Text = "Photos from our trip",
                        Style = TileTextStyle.CaptionSubtle
                    },
  
                    new TileText()
                    {
                        Text = "Check out these awesome photos I took while in New Zealand!",
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            }
        },
  
        TileLarge = ...
    }
};
```

**Xxxxxx:**

![xxxxx xxxxxx xxxx](images/adaptive-tiles-quicksample.png)

## <span id="Tile_sizes">
            </span>
            <span id="tile_sizes">
            </span>
            <span id="TILE_SIZES">
            </span>Xxxx xxxxx


Xxxxxxx xxx xxxx xxxx xxxx xx xxxxxxxxxxxx xxxxxxxxx xx xxxxxxxx [&xx;xxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxxx xxxxxx xxx XXX xxxxxxx. Xxxxxx xxx xxxxxx xxxx xx xxxxxxx xxx xxxxxxxx xxxxxxxxx xx xxx xx xxx xxxxxxxxx xxxxxx:

-   XxxxXxxxx
-   XxxxXxxxxx
-   XxxxXxxx
-   XxxxXxxxx (xxxx xxx xxxxxxx)

Xxx x xxxxxx xxxx xxxxxxxxxxxx XXX xxxxxxx, xxxxxxx &xx;xxxxxxx&xx; xxxxxxxx xxx xxxx xxxx xxxx xxxx xxx'x xxxx xx xxxxxxx, xx xxxxx xx xxxx xxxxxxx:

```XML
<tile>
  <visual>
  
    <binding template="TileSmall">
      <text>Small</text>
    </binding>
  
    <binding template="TileMedium">
      <text>Medium</text>
    </binding>
  
    <binding template="TileWide">
      <text>Wide</text>
    </binding>
  
    <binding template="TileLarge">
      <text>Large</text>
    </binding>
  
  </visual>
</tile>
```

```CSharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileSmall = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText() { Text = "Small" }
                }
            }
        },
  
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText() { Text = "Medium" }
                }
            }
        },
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText() { Text = "Wide" }
                }
            }
        },
  
        TileLarge = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new TileText() { Text = "Large" }
                }
            }
        }
    }
};
```

**Xxxxxx:**

![xxxxxxxx xxxx xxxxx: xxxxx, xxxxxx, xxxx, xxx xxxxx](images/adaptive-tiles-sizes.png)

## <span id="Branding">
            </span>
            <span id="branding">
            </span>
            <span id="BRANDING">
            </span>Xxxxxxxx


Xxx xxx xxxxxxx xxx xxxxxxxx xx xxx xxxxxx xx x xxxx xxxx (xxx xxxxxxx xxxx xxx xxxxxx xxxx) xx xxxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxx. Xxx xxx xxxxxx xx xxxxxxx "xxxx," xxxx xxx "xxxx," xxxx xxx "xxxx," xx xxxx xxxx "xxxxXxxXxxx."

**Xxxx**  Xxxxxxx Xxxxx xxxxx'x xxxxxxx xxx xxxxxx xxxx, xx "xxxx" xxx "xxxxXxxXxxx" xxxxxxx xx "xxxx" xx xxxxx.

 

```XML
<visual branding="logo">
  ...
</visual>
```

```CSharp
new TileVisual()
{
    Branding = TileBranding.Logo,
    ...
}

new TileVisual()
{
    Branding = TileBranding.Logo,
    ...
}
```

**Xxxxxx:**

![xxxxxxxx xxxxx, xxxx xxx xxxx](images/adaptive-tiles-namelogo.png)

Xxxxxxxx xxx xx xxxxxxx xxx xxxxxxxx xxxx xxxxx xxx xx xxx xxxx:

1. Xx xxxxxxxx xxx xxxxxxxxx xx xxx [&xx;xxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx
2. Xx xxxxxxxx xxx xxxxxxxxx xx xxx [&xx;xxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx, xxxxx xxxxxxx xxx xxxxxx xxxxxxxxxxxx xxxxxxx
Xx xxx xxx'x xxxxxxx xxxxxxxx xxx x xxxxxxx, xx xxxx xxx xxx xxxxxxxx xxxx'x xxxxxxxx xx xxx xxxxxx xxxxxxx.

```XML
<tile>
  <visual branding="nameAndLogo">
 
    <binding template="TileMedium" branding="logo">
      ...
    </binding>
 
    <!--Inherits branding from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```CSharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,
 
        TileMedium = new TileBinding()
        {
            Branding = TileBranding.Logo,
            ...
        },
 
        // Inherits branding from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**Xxxxxxx xxxxxxxx xxxxxx:**

![xxxxxxx xxxxxxxx xx xxxxx](images/adaptive-tiles-defaultbranding.png)

Xx xxx xxx'x xxxxxxx xxx xxxxxxxx xx xxxx xxxxxxxxxxxx xxxxxxx, xxx xxxx xxxx'x xxxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxx. Xx xxx xxxx xxxx xxxxx xxx xxxxxxx xxxx, xxxx xxx xxxxxxxx xxxx xxxxxxx xx "xxxx." Xxxxxxxxx, xxx xxxxxxxx xxxx xxxxxxx xx "xxxx" xx xxx xxxxxxx xxxx xxx'x xxxxx.

**Xxxx**   Xxxx xx x xxxxxx xxxx Xxxxxxx Y.x, xx xxxxx xxx xxxxxxx xxxxxxxx xxx "xxxx."

 

## <span id="Display_name">
            </span>
            <span id="display_name">
            </span>
            <span id="DISPLAY_NAME">
            </span>Xxxxxxx xxxx


Xxx xxx xxxxxxxx xxx xxxxxxx xxxx xx x xxxxxxxxxxxx xx xxxxxxxx xxx xxxx xxxxxx xx xxxx xxxxxx xxxx xxx **xxxxxxxXxxx** xxxxxxxxx. Xx xxxx xxxxxxxx, xxx xxx xxxxxxx xxxx xx xxx [&xx;xxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx, xxxxx xxxxxxx xxx xxxxxx xxxxxxxxxxxx xxxxxxx, xx xx xxx [&xx;xxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx, xxxxx xxxx xxxxxxx xxxxxxxxxx xxxxx.

```XML
<tile>
  <visual branding="nameAndLogo" displayName="Wednesday 22">
 
    <binding template="TileMedium" displayName="Wed. 22">
      ...
    </binding>
 
    <!--Inherits displayName from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```CSharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,
        DisplayName = "Wednesday 22",
 
        TileMedium = new TileBinding()
        {
            DisplayName = "Wed. 22",
            ...
        },
 
        // Inherits DisplayName from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**Xxxxxx:**

![xxxxxxxx xxxxx xxxxxxx xxxx](images/adaptive-tiles-displayname.png)

## <span id="Text">
            </span>
            <span id="text">
            </span>
            <span id="TEXT">
            </span>Xxxx


Xxx [&xx;xxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx xx xxxx xx xxxxxxx xxxx. Xxx xxx xxx xxxxx xx xxxxxx xxx xxxx xxxxxxx.

```XML
<text>This is a line of text</text></code></pre></td>
</tr>
</tbody>
</table>
```

<span codelanguage="CSharp"></span>
```CSharp
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C#</th>
</tr>
</thead>
<tbody>
<tr class="odd">
new TileText()
{
    Text = "This is a line of text"
};
```

**Xxxxxx:**

![xxxxxxxx xxxx xxxx](images/adaptive-tiles-text.png)

## <span id="Text_wrapping">
            </span>
            <span id="text_wrapping">
            </span>
            <span id="TEXT_WRAPPING">
            </span>Xxxx xxxxxxxx


Xx xxxxxxx, xxxx xxxxx'x xxxx xxx xxxx xxxxxxxx xxx xxx xxxx xx xxx xxxx. Xxx xxx **xxxx-xxxx** xxxxxxxxx xx xxx xxxx xxxxxxxx xx x xxxx xxxxxxx. Xxx xxx xxxx xxxxxxx xxx xxxxxxx xxx xxxxxxx xxxxxx xx xxxxx xx xxxxx **xxxx-xxxXxxxx** xxx **xxxx-xxxXxxxx**, xxxx xx xxxxx xxxxxx xxxxxxxx xxxxxxxx.

```XML
<text hint-wrap="true">This is a line of wrapping text</text></code></pre></td>
</tr>
</tbody>
</table>
```

<span codelanguage="CSharp"></span>
```CSharp
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C#</th>
</tr>
</thead>
<tbody>
<tr class="odd">
new TileText()
{
    Text = "This is a line of wrapping text",
    Wrap = true
};
```

**Xxxxxx:**

![xxxxxxxx xxxx xxxx xxxx xxxxxxxx](images/adaptive-tiles-textwrapping.png)

## <span id="Text_styles">
            </span>
            <span id="text_styles">
            </span>
            <span id="TEXT_STYLES">
            </span>Xxxx xxxxxx


Xxxxxx xxxxxxx xxx xxxx xxxx, xxxxx, xxx xxxxxx xx xxxx xxxxxxxx. Xxxxx xxx x xxxxxx xx xxxxxxxxx xxxxxx, xxxxxxxxx x "xxxxxx" xxxxxxxxx xx xxxx xxxxx xxxx xxxx xxx xxxxxxx xx YY%, xxxxx xxxxxxx xxxxx xxx xxxx xxxxx x xxxxx xx xxxxx xxxx.

```XML
<text hint-style="base">Header content</text>
<text hint-style="captionSubtle">Subheader content</text>
```

```CSharp
new TileText()
{
    Text = "Header content",
    Style = TileTextStyle.Base
},
 
new TileText()
{
    Text = "Subheader content",
    Style = TileTextStyle.CaptionSubtle
}
```

**Xxxxxx:**

![xxxxxxxx xxxxx xxxx xxxxxx](images/adaptive-tiles-textstyles.png)

**Xxxx**  Xxx xxxxx xxxxxxxx xx xxxxxxx xx xxxx-xxxxx xxx'x xxxxxxxxx.

 

**Xxxxx xxxx xxxxxx**

|                                |                           |             |
|--------------------------------|---------------------------|-------------|
| &xx;xxxx xxxx-xxxxx="\*" /&xx; | Xxxx xxxxxx               | Xxxx xxxxxx |
| xxxxxxx                        | YY xxxxxxxxx xxxxxx (xxx) | Xxxxxxx     |
| xxxx                           | YY xxx                    | Xxxxxxx     |
| xxxx                           | YY xxx                    | Xxxxxxxx    |
| xxxxxxxx                       | YY xxx                    | Xxxxxxx     |
| xxxxx                          | YY xxx                    | Xxxxxxxxx   |
| xxxxxxxxx                      | YY xxx                    | Xxxxx       |
| xxxxxx                         | YY xxx                    | Xxxxx       |

 

**Xxxxxxx xxxx xxxxx xxxxxxxxxx**

Xxxxx xxxxxxxxxx xxxxxx xxx xxxx xxxxxx xx xxxx xxxxxxx xxxxx xxx xxxxx xxxx xxxx xxxxxx xx xxx xxxx.

|                  |
|------------------|
| xxxxxXxxxxxx     |
| xxxxxxxxxXxxxxxx |
| xxxxxxXxxxxxx    |

 

**Xxxxxx xxxx xxxxx xxxxxxxxxx**

Xxxx xxxxx xxx x xxxxxx xxxxxxxxx xxxx xxxxx xxx xxxx x YY% xxxxxxx, xxxxx xxxxxxx xxxxx xxx xxxx xxxxx x xxxxx xx xxxxx xxxx.

|                        |
|------------------------|
| xxxxxxxXxxxxx          |
| xxxxXxxxxx             |
| xxxxXxxxxx             |
| xxxxxxxxXxxxxx         |
| xxxxxXxxxxx            |
| xxxxxXxxxxxxXxxxxx     |
| xxxxxxxxxXxxxxx        |
| xxxxxxxxxXxxxxxxXxxxxx |
| xxxxxxXxxxxx           |
| xxxxxxXxxxxxxXxxxxx    |

 

## <span id="Text_alignment">
            </span>
            <span id="text_alignment">
            </span>
            <span id="TEXT_ALIGNMENT">
            </span>Xxxx xxxxxxxxx


Xxxx xxx xx xxxxxxxxxxxx xxxxxxx xxxx, xxxxxx, xx xxxxx. Xx xxxx-xx-xxxxx xxxxxxxxx xxxx Xxxxxxx, xxxx xxxxxxxx xx xxxx-xxxxxxx. Xx xxxxx-xx-xxxx xxxxxxxxx xxxx Xxxxxx, xxxx xxxxxxxx xx xxxxx-xxxxxxx. Xxx xxx xxxxxxxx xxx xxxxxxxxx xxxx xxx **xxxx-xxxxx** xxxxxxxxx xx xxxxxxxx.

```XML
<text hint-align="center">Hello</text></code></pre></td>
</tr>
</tbody>
</table>
```

<span codelanguage="CSharp"></span>
```CSharp
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C#</th>
</tr>
</thead>
<tbody>
<tr class="odd">
new TileText()
{
    Text = "Hello",
    Align = TileTextAlign.Center
};
```

**Xxxxxx:**

![xxxxxxxx xxxxx xxxx xxxxxxxxx](images/adaptive-tiles-textalignment.png)

## <span id="Groups_and_subgroups">
            </span>
            <span id="groups_and_subgroups">
            </span>
            <span id="GROUPS_AND_SUBGROUPS">
            </span>Xxxxxx xxx xxxxxxxxx


Xxxxxx xxxxx xxx xx xxxxxxxxxxxx xxxxxxx xxxx xxx xxxxxxx xxxxxx xxx xxxxx xx xxxxxxx xxx xxxx xx xxxxxxxxx xx xxx xxxxxxxx xxx xxx xxxxxxx xx xxxx xxxxx. Xxx xxxxxxx, xxx xxxxx xxxx xxx xxxx xxxxxxxx, x xxxxxx, xxx x xxxxxxxxx, xxx xx xxxxx xxx xxxx xxxxx xxx xxxx xxx xxxxxx xx xx xxxxx. Xx xxxxxxxx xxxxx xxxxxxxx xxxxxx x xxxxxxxx, xxx xxxxxxxx xxxx xxxxxx xxx xx xxxxxxxxx (xx xxxx xxx xxx) xx xxx xx xxxxxxxxx xx xxx (xxxxxxx xxxx xxx'x xxx).

Xx xxxxxxx xxx xxxx xxxxxxxxxx xxxxxx xxxxxxx xxx xxxxxxx, xxxxxxx xxxxxxxx xxxxxx. Xxxxxx xxxxxxxx xxxxxx xxxxxx xxxx xxxx xx xxxxx xx xxxxxx xxxxxxx.

**Xxxx**  Xxx xxxx xxxxx xxxxx xx x xxxxx xx x xxxxxxxx.

 

```XML
...
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup>
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </subgroup>
  </group>
 
  <text />
 
  <group>
    <subgroup>
      <text hint-style="subtitle">Steve Bosniak</text>
      <text hint-style="captionSubtle">Build 2015 Dinner</text>
      <text hint-style="captionSubtle">Want to go out for dinner after Build tonight?</text>
    </subgroup>
  </group>
</binding>
...
```

```CSharp
...
 
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            CreateGroup(
                from: "Jennifer Parker",
                subject: "Photos from our trip",
                body: "Check out these awesome photos I took while in New Zealand!"),
 
            // For spacing
            new TileText(),
 
            CreateGroup(
                from: "Steve Bosniak",
                subject: "Build 2015 Dinner",
                body: "Want to go out for dinner after Build tonight?")
        }
    }
}
 
...
 
 
private static TileGroup CreateGroup(string from, string subject, string body)
{
    return new TileGroup()
    {
        Children =
        {
            new TileSubgroup()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = from,
                        Style = TileTextStyle.Subtitle
                    },
 
                    new TileText()
                    {
                        Text = subject,
                        Style = TileTextStyle.CaptionSubtle
                    },
 
                    new TileText()
                    {
                        Text = body,
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            }
        }
    };
}
```

**Xxxxxx:**

![xxxxxxxx xxxxx xxxxxx xxx xxxxxxxxx](images/adaptive-tiles-groups-subgroups.png)

## <span id="Subgroups__columns_">
            </span>
            <span id="subgroups__columns_">
            </span>
            <span id="SUBGROUPS__COLUMNS_">
            </span>Xxxxxxxxx (xxxxxxx)


Xxxxxxxxx xxxx xxxxx xxx xx xxxxxx xxxx xxxx xxxxxxxx xxxxxxxx xxxxxx x xxxxx. Xxx xxxx xxxxx, xxxx xxxxxxxx xxxxxxxxxx xx xxxxxxx.

Xxx **xxxx-xxxxxx** xxxxxxxxx xxxx xxx xx xxxxxxx xxx xxxxxx xx xxxxxxx. Xxx xxxxx xx **xxxx-xxxxxx** xx xxxxxxxxx xx x xxxxxxxx xxxxxxxxxx xx xxxxxxxxx xxxxx, xxxxx xx xxxxxxxxx xx **XxxxXxxxXxxx.Xxxx** xxxxxxxx. Xxx xxxxx-xxxxx xxxxxxx, xxxxxx xxxx xxxxxx xx Y.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">xxxx-xxxxxx</td>
<td align="left">Xxxxxxxxxx xx xxxxx</td>
</tr>
<tr class="even">
<td align="left">Y</td>
<td align="left">YY%</td>
</tr>
<tr class="odd">
<td align="left">Y</td>
<td align="left">YY%</td>
</tr>
<tr class="even">
<td align="left">Y</td>
<td align="left">YY%</td>
</tr>
<tr class="odd">
<td align="left">Y</td>
<td align="left">YY%</td>
</tr>
<tr class="even">
<td align="left">Xxxxx xxxxxx: Y</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![xxxxxxxxx, xxxx xxxxxxx](images/adaptive-tiles-subgroups01.png)

Xx xxxx xxx xxxxxx xxxxx xx xxxxx xx xxxxxxx xxxxxx, xxxxxx xxx xxxxxxx xxxxxx x xxxxxx xx Y xxx xxx xxxxxx xxxxxx x xxxxxx xx Y.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">xxxx-xxxxxx</td>
<td align="left">Xxxxxxxxxx xx xxxxx</td>
</tr>
<tr class="even">
<td align="left">Y</td>
<td align="left">YY.Y%</td>
</tr>
<tr class="odd">
<td align="left">Y</td>
<td align="left">YY.Y%</td>
</tr>
<tr class="even">
<td align="left">Xxxxx xxxxxx: Y</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![xxxxxxxxx, xxx xxxxxx xxxxx xxx xxxx xx xxx xxxxx](images/adaptive-tiles-subgroups02.png)

Xx xxx xxxx xxxx xxxxx xxxxxx xx xxxx xx YY% xx xxx xxxxx xxxxx xxx xxxx xxxxxx xxxxxx xx xxxx xx YY% xx xxx xxxxx xxxxx, xxxxxx xxx xxxxx xxxxxx xx YY xxx xxx xxxxxx xxxxxx xx YY. Xx xxxx xxxxx xxxxxxx xxxxx YYY, xxxx'xx xxx xx xxxxxxxxxxx.

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">xxxx-xxxxxx</td>
<td align="left">Xxxxxxxxxx xx xxxxx</td>
</tr>
<tr class="even">
<td align="left">YY</td>
<td align="left">YY%</td>
</tr>
<tr class="odd">
<td align="left">YY</td>
<td align="left">YY%</td>
</tr>
<tr class="even">
<td align="left">Xxxxx xxxxxx: YYY</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![xxxxxxxxx, xxxx xxxxxxx xxxxxxxxx YYY](images/adaptive-tiles-subgroups03.png)

**Xxxx**  Xx Y-xxxxx xxxxxx xx xxxxxxxxxxxxx xxxxx xxxxxxx xxx xxxxxxx.

 

Xxxx xxx xxxx xxxx xxxx xxx xxxxxxxxx, xxx xxxxxx xxxxxxx xxx **xxxx-xxxxxx**, xxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxx. Xx xxx xxx'x xxxxxxx xxxx-xxxxxx xxx xxx xxxxx xxxxxxxx, xx xxxx xx xxxxxxxx x xxxxxx xx YY. Xxx xxxx xxxxxxxx xxxx xxxxx'x xxxx x xxxxxxxxx xxxx-xxxxxx xxxx xx xxxxxxxx x xxxxxx xxxxx xx YYY xxxxx xxx xxx xx xxx xxxxxxxxx xxxxxxx, xx xx Y xx xxx xxxxxx xx xxxx. Xxx xxxxxxxxx xxxxxxxxx xxxx xxx'x xxxx xxxxxxxxx xxxx-xxxxxxx xxxx xx xxxxxxxx x xxxxxx xx Y.

Xxxx'x xxxxxx xxxx xxx x xxxxxxx xxxx xxxx xxxxx xxx xxx xxx xxxxxxx x xxxx xxxx xxxx xxxxxxx xx xxxxx xxxxx:

```XML
...
<binding template="TileWide" displayName="Seattle" branding="name">
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Tue</text>
      <image src="Assets\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-align="center" hint-style="captionsubtle">38°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Wed</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">59°</text>
      <text hint-align="center" hint-style="captionsubtle">43°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Thu</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">62°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Fri</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">71°</text>
      <text hint-align="center" hint-style="captionsubtle">66°</text>
    </subgroup>
  </group>
</binding>
...
```

```CSharp
...
TileWide = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
 
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°"),
 
                    CreateSubgroup("Wed", "Sunny.png", "59°", "43°"),
 
                    CreateSubgroup("Thu", "Sunny.png", "62°", "42°"),
 
                    CreateSubgroup("Fri", "Sunny.png", "71°", "66°")
                }
            }
        }
    }
}
...
 
 
private static TileSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new TileSubgroup()
    {
        Weight = 1,
 
        Children =
        {
            new TileText()
            {
                Text = day,
                Align = TileTextAlign.Center
            },
 
            new TileImage()
            {
                Source = new TileImageSource("Assets/Weather/" + image),
                RemoveMargin = true
            },
 
            new TileText()
            {
                Text = highTemp,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = lowTemp,
                Align = TileTextAlign.Center,
                Style = TileTextStyle.CaptionSubtle
            }
        }
    };
}
```

**Xxxxxx:**

![xxxxxxx xx x xxxxxxx xxxx](images/adaptive-tiles-weathertile.png)

## <span id="Images">
            </span>
            <span id="images">
            </span>
            <span id="IMAGES">
            </span>Xxxxxx


Xxx &xx;xxxxx&xx; xxxxxxx xx xxxx xx xxxxxxx xxxxxx xx xxx xxxx xxxxxxxxxxxx. Xxxxxx xxx xx xxxxxx xxxxxx xxxxxx xxx xxxx xxxxxxx (xxxxxxx), xx x xxxxxxxxxx xxxxx xxxxxx xxxx xxxxxxx, xx xx x xxxx xxxxx xxxx xxxxxxxx xx xxxx xxx xxx xx xxx xxxxxxxxxxxx.

**Xxxx**   Xxxxx xxx [xxxxxxxxxxxx xx xxx xxxx xxxx xxx xxxxxxxxxx xx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh781198).

 

Xxxx xx xxxxx xxxxxxxxx xxxxxxxxx, xxxxxx xxxx xxxxxxxxx xxxxxx xx xxxxxx xx xxxx xxx xxxxxxxxx xxxxx. Xxx xxxxxx xxxxx xxxxx x xxxx xxxxx xxx xxxxxxx xxx xxxxxx xxxxxx. Xxx xxxxxx xxxxxx xxxxxxx xx xxxx xxx xxxxx xx xxx xxxxxx.

```XML
...
<binding template="TileMedium" displayName="Seattle" branding="name">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Apps\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Apps\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionSubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
...
```

```CSharp
...
TileMedium = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
 
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°")
                }
            }
        }
    }
}
...
 
 
private static TileSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new TileSubgroup()
    {
        Children =
        {
            new TileText()
            {
                Text = day,
                Align = TileTextAlign.Center
            },
 
            new TileImage()
            {
                Source = new TileImageSource("Assets/Weather/" + image),
                RemoveMargin = true
            },
 
            new TileText()
            {
                Text = highTemp,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = lowTemp,
                Align = TileTextAlign.Center,
                Style = TileTextStyle.CaptionSubtle
            }
        }
    };
}
```

**Xxxxxx:**

![xxxxx xxxxxxx](images/adaptive-tiles-images01.png)

Xxxxxx xxxxxx xx xxx &xx;xxxxxxx&xx; xxxx, xx xx xxx xxxxx xxxxx, xxxx xxxx xxxxxxx xx xxx xxx xxxxxxxxx xxxxxx.

### <span id="Image_alignment">
            </span>
            <span id="image_alignment">
            </span>
            <span id="IMAGE_ALIGNMENT">
            </span>Xxxxx xxxxxxxxx

Xxxxxx xxx xx xxx xx xxxxx xxxx, xxxxxx, xx xxxxx xxxxx xxx **xxxx-xxxxx** xxxxxxxxx. Xxxx xxxx xxxx xxxxx xxxxxx xx xxxxxxx xx xxxxx xxxxxx xxxxxxxxxx xxxxxxx xx xxxxxxxxxx xx xxxx xxxxx.

```XML
...
<binding template="TileLarge">
  <image src="Assets/fable.jpg" hint-align="center"/>
</binding>
...
```

```CSharp
...
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new TileImage()
            {
                Source = new TileImageSource("Assets/fable.jpg"),
                Align = TileImageAlign.Center
            }
        }
    }
}
...
```

**Xxxxxx:**

![xxxxx xxxxxxxxx xxxxxxx (xxxx, xxxxxx, xxxxx)](images/adaptive-tiles-imagealignment.png)

### <span id="Image_margins">
            </span>
            <span id="image_margins">
            </span>
            <span id="IMAGE_MARGINS">
            </span>Xxxxx xxxxxxx

Xx xxxxxxx, xxxxxx xxxxxx xxxx xx Y-xxxxx xxxxxx xxxxxxx xxx xxxxxxx xxxxx xx xxxxx xxx xxxxx. Xxxx xxxxxx xxx xx xxxxxxx xx xxxxx xxx **xxxx-xxxxxxXxxxxx** xxxxxxxxx xx xxx xxxxx. Xxxxxxx, xxxxxx xxxxxx xxxxxx xxx Y-xxxxx xxxxxx xxxx xxx xxxx xx xxx xxxx, xxx xxxxxxxxx (xxxxxxx) xxxxxx xxxxxx xxx Y-xxxxx xxxxxxx xxxxxxx xxxxxxx.

```XML
...
<binding template="TileMedium" branding="none">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Numbers\4.jpg" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Numbers\3.jpg" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionsubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
...
```

```CSharp
...
 
TileMedium = new TileBinding()
{
    Branding = TileBranding.None,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "4.jpg", "63°", "42°"),
 
                    CreateSubgroup("Tue", "3.jpg", "57°", "38°")
                }
            }
        }
    }
}
 
...
 
 
private static TileSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new TileSubgroup()
    {
        Weight = 1,
 
        Children =
        {
            new TileText()
            {
                Text = day,
                Align = TileTextAlign.Center
            },
 
            new TileImage()
            {
                Source = new TileImageSource("Assets/Numbers/" + image),
                RemoveMargin = true
            },
 
            new TileText()
            {
                Text = highTemp,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = lowTemp,
                Align = TileTextAlign.Center,
                Style = TileTextStyle.CaptionSubtle
            }
        }
    };
}
```

![xxxx xxxxxx xxxxxx xxxxxxx](images/adaptive-tiles-removemargin.png)

### <span id="Image_cropping">
            </span>
            <span id="image_cropping">
            </span>
            <span id="IMAGE_CROPPING">
            </span>Xxxxx xxxxxxxx

Xxxxxx xxx xx xxxxxxx xxxx x xxxxxx xxxxx xxx **xxxx-xxxx** xxxxxxxxx, xxxxx xxxxxxxxx xxxx xxxxxxxx xxx xxxxxx "xxxx" (xxxxxxx) xx "xxxxxx."

```XML
...
<binding template="TileLarge" hint-textStacking="center">
  <group>
    <subgroup hint-weight="1"/>
    <subgroup hint-weight="2">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-weight="1"/>
  </group>
 
  <text hint-style="title" hint-align="center">Hi,</text>
  <text hint-style="subtitleSubtle" hint-align="center">MasterHip</text>
</binding>
...
```

```CSharp
...
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
 
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    new TileSubgroup() { Weight = 1 },
 
                    new TileSubgroup()
                    {
                        Weight = 2,
                        Children =
                        {
                            new TileImage()
                            {
                                Source = new TileImageSource("Assets/Apps/Hipstame/hipster.jpg"),
                                Crop = TileImageCrop.Circle
                            }
                        }
                    },
 
                    new TileSubgroup() { Weight = 1 }
                }
            },
 
 
            new TileText()
            {
                Text = "Hi,",
                Style = TileTextStyle.Title,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = "MasterHip",
                Style = TileTextStyle.SubtitleSubtle,
                Align = TileTextAlign.Center
            }
        }
    }
}
...
```

**Xxxxxx:**

![xxxxx xxxxxxxx xxxxxxx](images/adaptive-tiles-imagecropping.png)

### <span id="Background_image">
            </span>
            <span id="background_image">
            </span>
            <span id="BACKGROUND_IMAGE">
            </span>Xxxxxxxxxx xxxxx

Xx xxx x xxxxxxxxxx xxxxx, xxxxx xx xxxxx xxxxxxx xx xxx xxxx xx xxx &xx;xxxxxxx&xx; xxx xxx xxx xxxxxxxxx xxxxxxxxx xx "xxxxxxxxxx."

```XML
...
<binding template="TileWide">
  <image src="Assets\Mostly Cloudy-Background.jpg" placement="background"/>
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    ...
  </group>
</binding>
...
```

```CSharp
...
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = new TileImageSource("Assets/Mostly Cloudy-Background.jpg")
        },
 
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°")
                    ...
                }
            }
        }
    }
}
...
 
 
private static TileSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new TileSubgroup()
    {
        Weight = 1,
 
        Children =
        {
            new TileText()
            {
                Text = day,
                Align = TileTextAlign.Center
            },
 
            new TileImage()
            {
                Source = new TileImageSource("Assets/Weather/" + image),
                RemoveMargin = true
            },
 
            new TileText()
            {
                Text = highTemp,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = lowTemp,
                Align = TileTextAlign.Center,
                Style = TileTextStyle.CaptionSubtle
            }
        }
    };
}
```

**Xxxxxx:**

![xxxxxxxxxx xxxxx xxxxxxx](images/adaptive-tiles-backgroundimage.png)

Xxxxxxxxxxxx, xxx xxx xxx x xxxxx xxxxxxx xx xxxx xxxxxxxxxx xxxxx xxxxx **xxxx-xxxxxxx**, xxxxx xxxxxxx xxxxxxxx xxxx Y-YYY, xxxx Y xxxxx xx xxxxxxx xxx YYY xxxxx xxxx xxxxx xxxxxxx. Xxx xxxxxxx xxxxx xx YY.

```XML
...
<binding template="TileWide" hint-overlay="60">
  <image src="Assets\Mostly Cloudy-Background.jpg" placement="background"/>
  ...
</binding>
...
```

```CSharp
...
 
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = new TileImageSource("Assets/Mostly Cloudy-Background.jpg"),
            Overlay = 60
        },
 
        ...
    }
}
 
...
```

**xxxx-xxxxxxx Xxxxxx:**

![xxxxxxx xx xx xxxxx xxxx xxxxxxx](images/adaptive-tiles-image-hintoverlay.png)

### <span id="Peek_image">
            </span>
            <span id="peek_image">
            </span>
            <span id="PEEK_IMAGE">
            </span>Xxxx xxxxx

Xxx xxx xxxxxxx xx xxxxx xxxx "xxxxx" xx xxxx xxx xxx xx xxx xxxx. Xxx xxxx xxxxx xxxx xx xxxxxxxxx xx xxxxx xxxx/xx xxxx xxx xxx xx xxx xxxx, xxxxxxx xxxx xxxx, xxx xxxx xxxxx xxxxxxx xxxx xxx xx xxxxxx xxx xxxx xxxxxxx xx xxx xxxx. Xx xxx x xxxx xxxxx, xxxxx xx xxxxx xxxxxxx xx xxx xxxx xx xxx &xx;xxxxxxx&xx;, xxx xxx xxx xxxxxxxxx xxxxxxxxx xx "xxxx."

```XML
...
<binding template="TileMedium" branding="name">
  <image placement="peek" src="Assets/Apps/Hipstame/hipster.jpg"/>
  <text>New Message</text>
  <text hint-style="captionsubtle" hint-wrap="true">Hey, have you tried Windows 10 yet?</text>
</binding>
...
```

```CSharp
...
 
TileWide = new TileBinding()
{
    Branding = TileBranding.Name,
 
    Content = new TileBindingContentAdaptive()
    {
        PeekImage = new TilePeekImage()
        {
            Source = new TileImageSource("Assets/Apps/Hipstame/hipster.jpg")
        },
 
        Children =
        {
            new TileText()
            {
                Text = "New Message"
            },
 
            new TileText()
            {
                Text = "Hey, have you tried Windows 10 yet?",
                Style = TileTextStyle.CaptionSubtle,
                Wrap = true
            }
        }
    }
}
 
...
```

![xxxxxxxx xx xxxxxxx xxxxxx](images/adaptive-tiles-imagepeeking.png)

**Xxxxxx xxxx xxx xxxx xxx xxxxxxxxxx xxxxxx**

Xxx xxx xxxxxxxxx xxxxxxxxx xx xxxx xxx xxxxxxxxxx xxxxxx xx xx x xxxxxx xxxx:

xxxx-xxxx="xxxxxx"

Xxx xxxxxx xxxx xxxx xxxx xxxx:

![xxxxxx xxxx xxx xxxx xxx xxxxxxxxxx xxxxx](images/circlecrop-image.png)

**Xxx xxxx xxxx xxx xxxxxxxxxx xxxxx**

Xx xxx xxxx x xxxx xxx x xxxxxxxxxx xxxxx xx x xxxx xxxxxxxxxxxx, xxxxxxx xxxx x xxxx xxxxx xxx x xxxxxxxxxx xxxxx xx xxxx xxxxxxxxxxxx xxxxxxx.

Xxx xxxxxx xxxx xxxx xxxx xxxx:

![xxxx xxx xxxxxxxxxx xxxxx xxxx xxxxxxxx](images/peekandbackground.png)

**Xxx xxxx-xxxxxxx xx x xxxx xxxxx**

Xxx xxx xxx **xxxx-xxxxxxx** xx x xxxx xxxxx xx xxx xxxxxxx xxx xxxx xxx xxxx'x xxxxxxx xxxx xxxx xxxxxxx. Xx xxx xxxxxxx **xxxx-xxxxxxx** xx xxx &xx;xxxxxxx&xx; xxxxxxx, xxx xxxxxxx xxxx xx xxxxxxx xx xxxx xxx xxxxxxxxxx xxx xxx xxxx xxxxx.

Xxx xxx xxxx xxxxx **xxxx-xxxxxxx** xx xx &xx;xxxxx&xx; xxxxxxx xxxx xxx xxxxxxxxx="xxxx" xx xxxxxxxxx="xxxxxxxxxx" xx xxxx xxxxxxxx xxxxxxx xxxxxx xxx xxxx xx xxxxx xxxxxx. Xx xxx xxx'x xxxxxxx xx xxxxxxx, xxx xxxxxxxxxx xxxxx xxxxxxx xxxxxxxx xx YY% xxx xxx xxxx xxxxx xxxxxxx xxxxxxxx xx Y%.

Xxxx xxxxxxx xxxxx x xxxxxxxxxx xxxxx xx YY% xxxxxxx (xxxx) xxx xx Y% xxxxxxx (xxxxx):

![xxxx-xxxxxxx xx x xxxx xxxxx](images/hintoverlay.png)

## <span id="Vertical_alignment__text_stacking_">
            </span>
            <span id="vertical_alignment__text_stacking_">
            </span>
            <span id="VERTICAL_ALIGNMENT__TEXT_STACKING_">
            </span>Xxxxxxxx xxxxxxxxx (xxxx xxxxxxxx)


Xxx xxx xxxxxxx xxx xxxxxxxx xxxxxxxxx xx xxxxxxx xx xxxx xxxx xx xxxxx xxx **xxxx-xxxxXxxxxxxx** xxxxxxxxx xx xxxx xxx [&xx;xxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx xxx [&xx;xxxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxxxx. Xx xxxxxxx, xxxxxxxxxx xx xxxxxxxxxx xxxxxxx xx xxx xxx, xxx xxx xxx xxxx xxxxx xxxxxxx xx xxx xxxxxx xx xxxxxx.

### <span id="Text_stacking_on_binding_element">
            </span>
            <span id="text_stacking_on_binding_element">
            </span>
            <span id="TEXT_STACKING_ON_BINDING_ELEMENT">
            </span>Xxxx xxxxxxxx xx xxxxxxx xxxxxxx

Xxxx xxxxxxx xx xxx [&xx;xxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxx, xxxx xxxxxxxx xxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxxxxxxxxx xxxxxxx xx x xxxxx, xxxxxxxx xx xxx xxxxxxxxx xxxxxxxx xxxxx xxxxx xxx xxxxxxxx/xxxxx xxxx.

```XML
...
<binding template="TileMedium" hint-textStacking="center" branding="logo">
  <text hint-style="base" hint-align="center">Hi,</text>
  <text hint-style="captionSubtle" hint-align="center">MasterHip</text>
</binding>
...
```

```CSharp
...
 
TileMedium = new TileBinding()
{
    Branding = TileBranding.Logo,
 
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
 
        Children =
        {
            new TileText()
            {
                Text = "Hi,",
                Style = TileTextStyle.Base,
                Align = TileTextAlign.Center
            },
 
            new TileText()
            {
                Text = "MasterHip",
                Style = TileTextStyle.CaptionSubtle,
                Align = TileTextAlign.Center
            }
        }
    }
}
 
...
```

![xxxx xxxxxxxx xx xxxxxxx xxxxxxx](images/adaptive-tiles-textstack-bindingelement.png)

### <span id="Text_stacking_on_subgroup_element">
            </span>
            <span id="text_stacking_on_subgroup_element">
            </span>
            <span id="TEXT_STACKING_ON_SUBGROUP_ELEMENT">
            </span>Xxxx xxxxxxxx xx xxxxxxxx xxxxxxx

Xxxx xxxxxxx xx xxx [&xx;xxxxxxxx&xx;](tiles-and-notifications-adaptive-tiles-schema.md) xxxxx, xxxx xxxxxxxx xxxx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxxxxx (xxxxxx) xxxxxxx, xxxxxxxx xx xxx xxxxxxxxx xxxxxxxx xxxxx xxxxxx xxx xxxxxx xxxxx.

```XML
...
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup hint-weight="33">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-textStacking="center">
      <text hint-style="subtitle">Hi,</text>
      <text hint-style="bodySubtle">MasterHip</text>
    </subgroup>
  </group>
</binding>
...
```

```CSharp
...
 
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
 
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new TileGroup()
            {
                Children =
                {
                    // Image column
                    new TileSubgroup()
                    {
                        Weight = 33,
                        Children =
                        {
                            new TileImage()
                            {
                                Source = new TileImageSource("Assets/Apps/Hipstame/hipster.jpg"),
                                Crop = TileImageCrop.Circle
                            }
                        }
                    },
 
                    // Text column
                    new TileSubgroup()
                    {
                        // Vertical align its contents
                        TextStacking = TileTextStacking.Center,
 
                        Children =
                        {
                            new TileText()
                            {
                                Text = "Hi,",
                                Style = TileTextStyle.Subtitle
                            },
 
                            new TileText()
                            {
                                Text = "MasterHip",
                                Style = TileTextStyle.BodySubtle
                            }
                        }
                    }
                }
            }
        }
    }
}
 
...
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxxxxxx xxxxx xxxxxx](tiles-and-notifications-adaptive-tiles-schema.md)
* [XxxxxxxxxxxxxXxxxxxxxxx xx XxxXxx](https://github.com/WindowsNotifications/NotificationsExtensions/wiki)
* [Xxxxxxx xxxx xxxxxxxxx xxxxxxx](tiles-and-notifications-special-tile-templates-catalog.md)
 

 




<!--HONumber=Mar16_HO1-->
