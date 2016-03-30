---
Xxxxxxxxxxx: Xxxx xxx xxx xxxxxxxx xxx xxxxxxxxxx xxx xxx xx xxxxxx xxxxxxxx xxxxx.
xxxxx: Xxxxxxxx xxxx xxxxxx xxx xxxxxxxxx
xx.xxxxxxx: YYYXXYYX-YYXY-YYXX-XXYY-YYYYYYXXYYXY
xxxxx: Xxxxxxxx xxxx xxxxxx xxx xxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxx xxxx xxxxxxxxx: xxxxxx xxx xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxx xxx xxxxxxxx xxx xxxxxxxxxx xxx xxx xx xxxxxx xxxxxxxx xxxxx. Xxx xxxxxxxxxxxx xxx xxxxxxxx, xxx [Xxxxxx xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md).

## <span id="tile_element">
            </span>
            <span id="TILE_ELEMENT">
            </span>xxxx xxxxxxx


``` syntax
<tile>
  
  <!-- Child elements -->
  visual
  
</tile>
```

## <span id="visual_element">
            </span>
            <span id="VISUAL_ELEMENT">
            </span>xxxxxx xxxxxxx


``` syntax
<visual
  version? = integer
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string >
    
  <!-- Child elements -->
  binding+

</visual>
```

## <span id="binding_element">
            </span>
            <span id="BINDING_ELEMENT">
            </span>xxxxxxx xxxxxxx


``` syntax
<binding
  template = tileTemplateNameV3
  fallback? = tileTemplateNameV1
  lang? = string
  baseUri? = anyURI
  branding? = "none" | "logo" | "name" | "nameAndLogo"
  addImageQuery? = boolean
  contentId? = string
  displayName? = string
  hint-textStacking? = "top" | "center" | "bottom"
  hint-overlay? = [0-100] >

  <!-- Child elements -->
  ( image
  | text
  | group
  )*

</binding>
```

## <span id="image_element">
            </span>
            <span id="IMAGE_ELEMENT">
            </span>xxxxx xxxxxxx


``` syntax
<image
  src = string
  placement? = "inline" | "background" | "peek"
  alt? = string
  addImageQuery? = boolean
  hint-crop? = "none" | "circle"
  hint-removeMargin? = boolean
  hint-align? = "stretch" | "left" | "center" | "right" />
```

## <span id="text_element">
            </span>
            <span id="TEXT_ELEMENT">
            </span>xxxx xxxxxxx


``` syntax
<text
  lang? = string
  hint-style? = textStyle
  hint-wrap? = boolean
  hint-maxLines? = integer
  hint-minLines? = integer
  hint-align? = "left" | "center" | "right" >

  <!-- text goes here -->

</text>
```

xxxxXxxxx xxxxxx: xxxxxxx xxxxxxxXxxxxx xxxx xxxxXxxxxx xxxx xxxxXxxxxx xxxxxxxx xxxxxxxxXxxxxx xxxxx xxxxxXxxxxx xxxxxXxxxxxx xxxxxxxxx xxxxxxxxxXxxxxx xxxxxxxxxXxxxxxx xxxxxx xxxxxxXxxxxx xxxxxxXxxxxx

## <span id="group_element">
            </span>
            <span id="GROUP_ELEMENT">
            </span>xxxxx xxxxxxx


``` syntax
<group>

  <!-- Child elements -->
  subgroup+

</group>
```

## <span id="subgroup_element">
            </span>
            <span id="SUBGROUP_ELEMENT">
            </span>xxxxxxxx xxxxxxx


``` syntax
<subgroup
  hint-weight? = [0-100]
  hint-textStacking? = "top" | "center" | "bottom" >

  <!-- Child elements -->
  ( text
  | image
  )*

</subgroup>
```

**Xxxx**  
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Xxxxxxx xxxxxx


* [Xxxxxx xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md)
 

 




<!--HONumber=Mar16_HO1-->
