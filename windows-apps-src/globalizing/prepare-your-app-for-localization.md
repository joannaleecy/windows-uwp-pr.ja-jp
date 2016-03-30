---
Xxxxxxxxxxx: Xxxxxxx xxxx xxx xxx xxxxxxxxxxxx xx xxxxx xxxxxxx, xxxxxxxxx, xx xxxxxxx.
xxxxx: Xxxxxxx xxxx xxx xxx xxxxxxxxxxxx
xx.xxxxxxx: YYXYXYXX-YYXX-YXYY-YYXX-YXXYYXYXYYXY
xxxxx: Xxxxxxx xxxx xxx xxx xxxxxxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxx xxxx xxx xxx xxxxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxxx xxx xxx xxxxxxxxxxxx xx xxxxx xxxxxxx, xxxxxxxxx, xx xxxxxxx. Xxxxxx xxx xxx xxxxxxx, xx xxxx xx xxxx xxxxxxx xxx [xx'x xxx xxx'xx](guidelines-and-checklist-for-globalizing-your-app.md).

## <span id="use_resource_files_and_qualifiers.">
            </span>
            <span id="USE_RESOURCE_FILES_AND_QUALIFIERS.">
            </span>Xxx xxxxxxxx xxxxx xxx xxxxxxxxxx.


Xx xxxx xx xxxxxxx xxx XX xxxxxxx xx xxxx xxx xx xxxxxxxx xxxxx, xxxxxxx xx xxxxxxx xxxx xx xxxx xxxx. Xxx xxxx xxxxxx, xxx [Xxx XX xxxxxxx xxxx xxxxxxxxx](put-ui-strings-into-resources.md).

Xxxxxxx xxxxxx xx xxxxx xxxx xxxxxxxxx xxxx xxx xxxxxxxxxxx xxxxxxxx xxx xx xxxxx xxxx xx xxxxxx. Xx xxxxx xxxx xx xxxxx x xxxxxxxxxxx xxxxxx xx xxxxxx xxxxxxxxx xx xxxxxxxx xxxxxx, xxxxx, xxx xxxxx, xx xx’x xxxx xx xxx xxxxxxx xxxxx xxxxxx xxxxxxxx xxx xxx. Xx xxxxx xxxx, xxx [Xxx xx xxxx xxxxxxxxx xxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324).

## <span id="add_contextual_comments.">
            </span>
            <span id="ADD_CONTEXTUAL_COMMENTS.">
            </span>Xxx xxxxxxxxxx xxxxxxxx.


Xxx xxxxxxxxxxxx xxxxxxxx xx xxxx xxx xxxxxxxx xxxxx. Xxx xxxxxxxx xxx xxxxxxx xx xxx xxxxxxxxx, xxx xxxxxx xxxxxxx xxxxxxxxxx xxxxxxxxxxx xxxx xxxxx xxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxx xxx xxxxxxxxx. Xxx xxxxxxxx xxxxxx xxxx xxxxxxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxxx xx xxx xxxxxxxx, xx xxxx xxxxxxxxxxx xxxx xxx xxxxx xxx xxxxxxxx. Xxxxxxxxxx, xxx xxxxxxxx xxx xx xxxxxx xx xxx Xxxxxxx.xxx xxxx.

**XXXX:** Xxxx xxxxx (xxxxxxxxx xxxxxxx xx Xxxxxx Xxxxxx xxx xxxx xxxxx XXXX) xxxx x xxxxxxx xxxxxxx. Xxx xxxxxxx:

```XAML
<data name="String1">
    <value>Hello World</value>
    <comment>A greeting (This is a comment to the localizer)</comment>
</data>
```

**XXXX:** Xxxxxxx xxxxx (xxxxxxxxx xxxxxxx xx Xxxxxx Xxxxxx xxx xxxx xxxxx XXXX) xxxxx xxxxxxxx xx xxxxxx xxxx xxxxx xxxx xx xxxxxxxxxx, xxxx xx xxxxxxxx:

```json
{
    "String1"  : "Hello World",
    "_String1.comment" : "A greeting (This is a comment to the localizer)"
}
```

## <span id="localize_sentences_instead_of_words.">
            </span>
            <span id="LOCALIZE_SENTENCES_INSTEAD_OF_WORDS.">
            </span>Xxxxxxxx xxxxxxxxx xxxxxxx xx xxxxx.


Xxxxxxxx xxx xxxxxxxxx xxxxxx: "Xxx {Y} xxxxx xxx xx xxxxxxxxxxxx."

X xxxxxxx xx xxxxx xxxxx xxxxxxx {Y}, xxxx xx xxxxxxxxxxx, xxxx, xx xxxxxxxx. Xxxxx xxxx xxxxxxx xxxxx xxxxxx xx xxxx xxx xxx Xxxxxxx xxxxxxxx, xx xxxx xxx xxxx xx xxx xxxxx xxx xxx xxxxxxxxxxxxx xxxxxxxx xx Xxxxxx. Xxxxxx xxxx xx xxx xxxxxxxxx Xxxxxx xxxxxxxxx, xxxx xx xxx xxxxx xx xxx xxxxxxxx xxxxxx ("Xxx", "Xxx", "Xxx") xxxx xx xxxxx xxx xxxxxxxxxxxxx xxxx:

| Xxxxxxx                                    | Xxxxxx                                           |
|:------------------------------------------ |:------------------------------------------------ |
| Xxx xxxxxxxxxxx xxxxx xxx xx xxxxxxxxxxxx. | Xxx Xxxxxx xxxxxx xxxxx xxxxxxxxxxxxxx xxxxxx.   |
| Xxx xxxx xxxxx xxx xx xxxxxxxxxxxx.        | Xxx Xxxxxxx xxxxxx xxxxx xxxxxxxxxxxxxx xxxxxx.  |
| Xxx xxxxxxxx xxxxx xxx xx xxxxxxxxxxxx.    | Xxx Xxxxxxxx xxxxxx xxxxx xxxxxxxxxxxxxx xxxxxx. |

 

Xx xxxxxxx xxxxxxx, xxxxxxxx xxx xxxxxxxx "Xxxxxx xx xx {Y} xxxxxx(x)." Xxxxx xxxxx "xxxxxx(x)" xxxxx xxx xxx Xxxxxxx xxxxxxxx, xxxxx xxxxxxxxx xxxxx xxx xxxxxxxxx xxxxx. Xxx xxxxxxx, xxx Xxxxxx xxxxxxxx xxxx "xxxxxx", "xxxxxx", xx "xxxxx" xxxxxxxxx xx xxx xxxxxxx.

Xx xxxxx xxxx xxxxxxx, xxxxxxxx xxx xxxxxx xxxxxxxx, xxxxxx xxxx x xxxxxx xxxx. Xxxxx xxxx xxx xxxx xxxx xxxxx xxxx xxx xx xxxxxxxxx xxxxxxxx, xxx xx xx xxx xxxx xxxxxxxx xxxxxxx:

-   X xxxxx xxxxx xxxxxxx xxxx xx xxxxxxxxx xxx xxx xxxxxxxxx.
-   Xxxx xxxxxxxxx xxxx xxx xxxx xx xxx xxxxx xxxx xxx xxxxxxx xxxx xx xxxxxxxx xxxx.
-   Xxx xxxx xxx xxxx xx xxxxxxxxx x xxxxxx xxxx xxx xxxx x xxxxxxx xxxx xxxx xxxxxxxx xxxxx xxxx xxx xx xxxxxxxxx.

## <span id="ensure_the_correct_parameter_order.">
            </span>
            <span id="ENSURE_THE_CORRECT_PARAMETER_ORDER.">
            </span>Xxxxxx xxx xxxxxxx xxxxxxxxx xxxxx.


Xxx'x xxxxxx xxxx xxx xxxxxxxxx xxx xxxxxxxxxx xx xxx xxxx xxxxx. Xxx xxxxxxx, xxxxxxxx xxx xxxxxx "Xxxxx %x %x", xxxxx xxx xxxxx %x xx xxxxxxxx xx xxx xxxx xx x xxxxx, xxx xxx xxxxxx %x xx xxxxxxxx xx xxx xxxx xx x xxxxx. Xxxx xxxxxxx xxxxx xxx xxx Xxxxxxx xxxxxxxx, xxx xxxx xxxx xxxx xxx xxx xx xxxxxxxxx xxxx xxx Xxxxxx xxxxxxxx, xxxxx xxx xxxx xxx xxxxx xxx xxxxxxxxx xx xxx xxxxxxx xxxxx.

Xx xxxxx xxxx xxxxxxx, xxxxxx xxx xxxxxx xx "Xxxxx %Y %Y", xx xxxx xxx xxxxx xx xxxxxxxxxxxxxxx xxxxxxxxx xx xxx xxxxxxxx.

## <span id="don_t_over_localize.">
            </span>
            <span id="DON_T_OVER_LOCALIZE.">
            </span>Xxx’x xxxx xxxxxxxx.


Xxxxxxxx xxxxxxxx xxxxxxx, xxx xxxx. Xxxxxxxx xxx xxxxxxxxx xxxxxxxx:

| Xxxx-xxxxxxxxx xxxxxx                   | Xxxxxxxxx-xxxxxxxxx xxxxxx |
|:--------------------------------------- |:-------------------------- |
| &xx;xxxx&xx;xxxxx xx xxx&xx;/xxxx&xx;   | xxxxx xx xxx               |
| &xx;xxxx&xx;xxxxxxx xxxxxx&xx;/xxxx&xx; | xxxxxxx xxxxxx             |

 

Xxxxxxxxx xxx xxxxx &xx;xxxx&xx; xxx xx xxx xxxxxxxxx xxxxx xxxx xx xxx xxxx xx xxxxxxxxx. Xxxx xxxxxxx xxx xxx xxx xxxxx. Xxxx xxx xxxxxxx xxxxxxxxxx xxxxxx xx xxxxxxxxx. Xxxxxxxxx, xxx xxxxxx xxxxx xx xxxx xx xxxx xxxx xxxxxx xx xxxx xxxxxxxx xxxx xxxxxxxxxxx xxxxxxx. Xxxxxxx, xxxx xxxx xxxxxxx xxxxxx xxxxxxx xxxxxx xx xxxx xxxxxxx xxx xxxxxx xxxxxxxx.

## <span id="do_not_use_the_same_strings_in_dissimilar_contexts.">
            </span>
            <span id="DO_NOT_USE_THE_SAME_STRINGS_IN_DISSIMILAR_CONTEXTS.">
            </span>Xx xxx xxx xxx xxxx xxxxxxx xx xxxxxxxxxx xxxxxxxx.


Xxxxxxx x xxxxxx xxx xxxx xxxx xxx xxxx xxxxxxxx, xxx xx xxx xxxxx xxxxxxxxxxxx xxxxxxxx xx xxx xxxx xxxx xx xxxxxx xxx xxxx xxxxxxxxx xxxxxxxx xx xxxxxxxx.

Xxx xxx xxxxx xxxxxxx xx xxx xxx xxxxxxxx xxx xxx xxxx. Xxx xxxxxxxx, xxx xxx xxxxx xxx xxxxxx "Xxxxxx" xxx xxxx xxxxx xxxxxx xxxxxx xxx xxxxx xxxxxx xxxxxxx xxxx xxxxx xx xxxxxxxxx xx xxxxx. Xxx xxxxxx xxx xxxxx xxxx xxxx xxxxxx xxxx xxxxxxxxx xx x xxxx xxxx xxxxxx xxxxxxx xxx xxxxxxx xxx xxxxxxx xxx xxxxxxxxx, xxx xxx xxxx xxxxx xx xxxxxxxxxx xxxxxxxxxxx.

Xxxxxxx xxxxxxx xx xxx xxx xx xxx xxxxxxx "xx" xxx "xxx". Xx xxx Xxxxxxx xxxxxxxx, "xx" xxx "xxx" xxx xx xxxx xxx x xxxxxx xxx Xxxxxx Xxxx, Xxxxxxxxx, xxx xxxxxxx. Xxx xx Xxxxxxx, xxx xxxxxxxxxxx xxxxxxx xx xxx xxxxxxx xx xxxx xx xxxxx xxxxxx xx xxx xxx. Xxx xxxxx xxxx xx xxxxxx x xxxx xx xxxxxxx xxx xxxx xxxxxxx.

Xxxxxxxxxxxx, x xxxxxx xxxx "xxxx" xx "xxx" xxxxx xx xxxx xx xxxx x xxxx xxx x xxxx xx xxx Xxxxxxx xxxxxxxx, xxxxx xxx xxxxxxx xxx xxxxxxxxxxx xxxxxxx. Xxxxxxx, xxxxxx x xxxxxxxx xxxxxx xxx xxxx xxx xxxx xxx xxxx xxxxxx. Xxxx xxx'xx xxx xxxx xxxxxxx xxx xxxxxxxx xxx xxx xxxx, xxx xx xxx xxxx xxxx xxx xxx x xxxxxxxx xxxxxx.

## <span id="identify_resources_with_unique_attributes.">
            </span>
            <span id="IDENTIFY_RESOURCES_WITH_UNIQUE_ATTRIBUTES.">
            </span>Xxxxxxxx xxxxxxxxx xxxx xxxxxx xxxxxxxxxx.


Xxxxxxxx xxxxxxxxxxx xxx xxxx xxxxxxxxxxx xxx xxxx xx xxxxxx xxx xxxxxxxx xxxx. Xxxx xxxxxxxxx x xxxxxxxx, xxx xxx xxxxxxxx xxxxxxxxxx, xxx xxx xxxxxx xxxxx xx xxx xxxxxxxx. Xxxxxxxx xxxxxxxxxxx xxx'x xxxxxx, xxx xxx xxxxxx xxxxxx xx xxx xxxxxxxxx xx xxxxxx xxxxxxxxx xx xxx xxxxxxxx.

Xx xxxx xx xxx xxxxxxxxxx xxxxxxxx xxxxxxxxxxx xx xxxxxxx xxxxxxxxxx xxxxxxx xxx xxxxxxxxxxx.

Xxx'x xxxxxx xxx xxxxxxxx xxxxxxxxxxx xxxxx xxx xxxxxx xxxxxxxxx xxx xxxx xx xxxxxxxxxxx. Xxxxxxxxxxxx xxxxx xxx xxx xxxxxxxx xxxxxxxxxx xx xxxxx xxxxxxxxx, xxxxxxxxx, xxx xxxxxxx xx xxx xxxxxxxxx. Xxxxxxx xx xxxxxxxx xxxxxxxxxxx—xxxx xxxxx xx "xxxxxxxx xxxxxxxxxxx xxxxx"—xxxxxxx xxxxxxx xx xx xxxxxxxxxxxx, xxxxxxx xx xxxx xxxxxx xx xxxxxx xxxxxxx xxxx xxxxxxx xxx xxxxxx xxxxx.

## <span id="choose_an_appropriate_translation_approach.">
            </span>
            <span id="CHOOSE_AN_APPROPRIATE_TRANSLATION_APPROACH.">
            </span>Xxxxxx xx xxxxxxxxxxx xxxxxxxxxxx xxxxxxxx.


Xxxxx xxxxxxx xxx xxxxxxxxx xxxx xxxxxxxx xxxxx, xxxx xxx xx xxxxxxxxxx. Xxx xxxxx xxxx xx xxxxxxxxx xxxxxxx xx xxxxx xxx xxxxxxx xx xxxx xxxxxxx xxx xxxxxxxxx, xxxxx xxxxxxx xxxxxxx xxxxxx xxx xxx xx x xxxxxxx. Xxx xxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxx xx xxxxxx xx xxxx. Xxxx xxx xxxxxx xx xxx xxxxxx xx xxxxxxx xx xx xxxxxxxxxx, xxx xxxxxx xx xxxxxxxxx xx xx xxxxxxxxxx, xxx xxx xxx xxxxxxxxxxx xxxx xx xxxx (xxxx xx xx-xxxxx xxxxxx xxxxxx xx xxxxxxxx xxxxxx).

Xxxxxxxx xxx xxxxxxxxx xxxxxxx:

-   **Xxx xxxxxxxx xxxxx xxx xx xxxxxxxxxx xx xxxxxxx xxxx xxxxxxxx xx xxx xxxxxxx.** Xxxx xxxxxxxx xxxxx xxxx xxx x xxxxxxx xxxx xxx x xxxxx xxxxxx xx xxxxxxx xxx xxxx xxxxx xx xx xxxxxxxxxx xxxx xxx xx xxxxx xxxxxxxxx. Xx xxxxx xx xxxxxxxx xxx x xxxxxxxx xxxxx x xxxxxxxxx xxxxxx xxxx xxxx xxx xxxxxxxx xxx xx xxxxxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxx. Xxxx xxxxxxxx xxxxxxxx xx xxxxx xxxxx, xxxxxxxx xx xxxxx, xxx xxxxxxxxx xxx xxxx xx xxxxxxxxxxxxxxx, xxx xx xx xxx xxxxxxxx. Xx xxxxxxxxxx, xxx xxxxxxxxx xx xxxxxxxxx xxxxxxxxx xxx xxxxxx xxx xxx xx xxxx, xxxxxxx xxx xxxx xxxxxxxxxxx xxx xxxxxxxxxxx xxxxxxxxx.
-   **Xxx xxxxxx xxxxxxxx xxxxx xxx xx XXX xx XxxXXXX xxxx xxxxxx, xx xxxxx xx xxxxxx xxx xxx xxxxxxxxxxx xxxxx xxx xxxx xxxxxx. Xxx xxxxxxxxxx xxxxx xxxxx xxxx xx xxxxxx xxxx xxxx xxx xxxxxxx.** Xxxx xxxxxxxx xxxxxxx x xxxx xx xxxxxxxxxxx xxxxxxxxxxxx xxxxxxx xxx XXX xxxx, xxx xx xxxx xxxxxxxxxxx xxxx xxxx xxxxx xxxxxxx xx xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxxxxx. Xxxx xxxxxxxx xxxxx xxxx xxxx xxx xxxxxxxx xxxx xxxx xx xx xxxxxxxxxx xxxx x xxxxx xxxxxx xx xxxxxxxxx. Xxx XXXXX xxxxxx xx xx XXX xxxxxx xxxxxxxxxxxx xxxxxxxx xxx xxx xx xxxxxxxxxxxx, xxx xxxxxx xx xxxx xxxxxxxxx xx xxxx xxxxxxxxxxxx xxxxxxx xx xxxxxxxxxxxx xxxxx. Xxx xxx xxx xxx [Xxxxxxxxxxxx Xxx Xxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj572370.aspx) xx xxxxxxxx XXXXX xxxxx xxxx xxxxx xxxxxxxx xxxxx, xxxx xx .xxxx xx .xxxxxxx.

Xxxxxxxx xx xxxxxxxxxx xxx xxxx xx xxxxx xxx xxxxx xxxxx, xxxx xx xxxxxx xx xxxxx xxxxx. Xxxxxxxxx, xx xxx'x xxxxxxxxx xxxxxxxx xxxxxxxxxx xxxxxxxxx xxxxx xxxxxxx xxxx xxx xx xxxxxxxxx xx xxxxxxxx.

Xxxxxxxxxxxx, xxxxxxxx xxx xxxxxxxxx xxxxxxxxxxx:

-   **Xxx x xxxxxxxxxxxx xxxx.** X xxxxxx xx xxxxxxxxxxxx xxxxx xxx xxxxxxxxx xxx xxxxxxx xxxxxxxx xxxxx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxx xx xx xxxxxx xx xxxxxxxxxxx. Xxxx xxxxxxxx xxxxxxx xxx xxxx xx x xxxxxxxxxx xxxxxxxxxxxx xxxxxxx xxx XXX xxxx. Xxx xx xxx xxx xxxxxxxx xx xxxxxxxxxxx x xxx xxxx xxx xxxxxxx xx xxx xxxxxxxxxxxx xxxxxxx. X xxxxxxxxxxxx xxxx xx xxxx xxx xxxxxxxx xxxx x xxxxx xxxxxx xx xxxxxxx, xxx x xxxxx xxxxxx xx xxxxxxxxx. Xx xxxxx xxxx, xxx [Xxx xx xxx xxx Xxxxxxxxxxxx Xxx Xxxxxxx](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj572370.aspx).
-   **Xxx x xxxxxxxxxxxx xxxxxx.** Xxxxxxxx xxxxx x xxxxxxxxxxxx xxxxxx xx xxxx xxxxxxx xxxxxxxx x xxxxx xxxxxx xx xxxxxxx xxx xxxxx xx xx xxxxxxxxxx xxx xxxx xxxxxxxxx. X xxxxxxxxxxxx xxxxxx xxx xxxx xxxxxx xxxxx xxxxx xxx xxxxxxxxx, xx xxxx xx xxxxxxxxxxx xxxx xxxxxxxx xxxxx. Xxxx xx xx xxxxx xxxxxxxx, xxx xx xxxx xxx xxxx xxxxxx xxxxxx, xxx xxx xxxxxxxx xxx xxxxxxxxxx xxxx xxx xxxx xxxxxxxxxx xxxxxxx.
-   **Xxxx xxxx xxxxxxxxxx xxxxxxxx.** Xxxxxx xxxxxxxxxx xx xxxxxxx xxxx xxx xx xxxxxxxxxx x xxxx xx x xxxx. Xxxxxxx xxxxxxxxxx xxxxx xx xxxx xxxxxxxxxx xx xxxxx xxxxxxxxxxx xxxxx. Xxxx xxxxxxx xxxxxxxxxxxxx xxxxxxx, xxxxxxxxxxx, xxx xx xxxxxxxxxxxx xx xxxxxxxx xx xxxxx xxxxxxxxx.

## <span id="keep_access_keys_and_labels_consistent.">
            </span>
            <span id="KEEP_ACCESS_KEYS_AND_LABELS_CONSISTENT.">
            </span>Xxxx xxxxxx xxxx xxx xxxxxx xxxxxxxxxx.


Xx xx x xxxxxxxxx xx "xxxxxxxxxxx" xxx xxxxxx xxxx xxxx xx xxxxxxxxxxxxx xxxx xxx xxxxxxx xx xxx xxxxxxxxx xxxxxx xxxx, xxxxxxx xxx xxx xxxxxx xxxxxxxxx xxx xxxxxxxxxxx xx xxx xxxxxxxx xxxxxxxx. Xx xxxx xx xxxxxxx xxxxxxxx xxx xxx xxxxx xxxxxx xxxx xx: `Make sure that the emphasized shortcut key  is synchronized with the access key.`

**XXXX:**

Xxx xxx xxxxxx xxx xxxxxxxxxxxxxx xxxxx xxxxx. Xxxxx, xx xxxx xx xxxxxxxx xxxxxxx xxx xxxxx xxxxxx xx xxxx xx xx xxx xxxxxx xxx xxxxxxxxxx.

```HTML
<label id="theLabel" data-win-res="{accessKey: 'theLabelAccessKey'}" for="xPrinterRedirection" accessKey="L">The <u>L</u>abel</label>
<input type="checkbox" value="OFF" id="xPrinterRedirection" name="xPrinterRedirection" />
```

## <span id="support_furigana_for_japanese_strings_that_can_be_sorted.">
            </span>
            <span id="SUPPORT_FURIGANA_FOR_JAPANESE_STRINGS_THAT_CAN_BE_SORTED.">
            </span>Xxxxxxx Xxxxxxxx xxx Xxxxxxxx xxxxxxx xxxx xxx xx xxxxxx.


Xxxxxxxx Xxxxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxxxx xx xxxxxx xxxx xxxx xxx xxxxxxxxxxxxx xxxxxxxxx xx xxx xxxx xxx xxxxxxx xxxx xxx xxxx xx. Xxxx xxxxx xx xxxxxxxx xxxx xxx xxx xx xxxx Xxxxxxxx xxxxx xxxxxxx, xxxx xx xxxxxxxxxxx xxxxx, xxxxx, xxxxx, xxx xx xx. Xxxxxxxx Xxxxx xxxx, xx xxx xxxx, xxxxxxx xxxx xxxxxx xx x xxxxxxx-xxxxxxxxxxxxxx xxxxx xxxxxx XXXX. Xxxxxxxxxxxxx, xxxxxxx xxxx xxxxxxx xxxxx xx xxx xxxxxxxx xx xx xxx xxxx xxxxxx xxx xxxxxx.

Xxxxxxxx xxxxx xxxxxx xxxx xxxxxxx xx xxxxxxxx xxx xxxx xx xxxxxxx xx xxxxxxx xxx xxxxxxxxx xxx xxx xxxxxxxxxx xxxx xxx xxxxx. Xx xxx xxx xxx xxxxxxxxx xxxxxxxxx xx xxx Xxxxxxxx xx xxxx xxx xxxx, xxx xxx xxxxxx xxxx xx xx xxxxxx xx xxx xxxxxx xxxxxxxx xx xxx xxx xxxx. Xx xxxx xxx xxxx xxxxxxxx Xxxxx xxxxxxxxxx xxx Xxxxxxxx xx xxx xxxxxxxx xxxx xxx xxxx’x XX xxxxxxxx xx xxx xxxx xxxxx xx xxx xx Xxxxxxxx, Xxxxxxx xxxxx xxx xxxx xxxxxx xx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxxxxx. Xxxxxxx, xxxxx xx x xxxxxxxxxxx xxx xxx xxxxx xxxxxxxxxx xxxx xx xxxxxx xxxxxxxx xx xx xxxxxx xxxxx x xxxx xxxxxx xxxxxxx xxxxxxx. Xxxxxxxxx, xxx xxxx xxxxxxxx xxx Xxxxxxxx xxxxxxxxxxxx (xxxxxxxxxx xxxxx xxxxxxxxxx Xxxxx xxxxxxxxxx xx xxxxx xxxxx) xx xx xxxxxxx x Xxxxxxxx xxxxxxx xx xxxxx xxx xxxx xx xxxx xx xxx Xxxxxxxx xxxxxxxxxxxx xxxxxxx.

1.  Xxx "xx-xxxxxxxx:Xxxxxxx" xx xxx Xxxxxxx Xxxxxxx Xxxx xxx xxx Xxxxxxxxxxx Xxxxxxx Xxxx.
2.  Xxxxxx x xx-XX xxxxxx xxxxx xxxxxxx, xxx xxx xxx xxxxxxxx xxxxx xx xxxxxxx:

    ``` syntax
    strings\
        en-us\
        ja-jp\
            Resources.altform-msft-phonetic.resw
            Resources.resw
    ```

3.  Xx Xxxxxxxxx.xxxx xxx xxxxxxx xx-XX: Xxx x xxxxxx xxxxxxxx xxx Xxxxxxx "希蒼"
4.  Xx Xxxxxxxxx.xxxxxxx-xxxx-xxxxxxxx.xxxx xxx Xxxxxxxx xxxxxxxx xxxxxxxxx: Xxx Xxxxxxxx xxxxx xxx XxxXxxx "のあ"

Xxx xxxx xxx xxxxxx xxx xxx xxx xxxx "希蒼" xxxxx xxxx xxx Xxxxxxxx xxxxx "のあ" (xxx),　xxx xxx xxxxxxxx xxxxx (xxxxx xxx **XxxXxxxxxxx** xxxxxxxx xxxx Xxxxx Xxxxxx Xxxxxx (XXX)) "まれあお" (xxxx-xx).

Xxxxxxx xxxxxxx xxx **Xxxxxxxx Xxxxxxx Xxxxx** xxxxxx:

-   Xxxxx Xxxxxxxx xxxx xxxxxx,
    -   Xx Xxxxxxxx xx xxxxxxx, xxx "希蒼" xx xxxxxx xxxxx "の".
    -   Xx Xxxxxxxx xx xxxxxxx, xxx "希蒼" xx xxxxxx xxxxx "ま".
-   Xxxxx xxx-Xxxxxxxx xxxx xxxxxx,
    -   Xx Xxxxxxxx xx xxxxxxx, xxx "希蒼" xx xxxxxx xxxxx "の".
    -   Xx Xxxxxxxx xx xxxxxxx, xxx "希蒼" xx xxxxxx xxxxx "漢字".

## <span id="related_topics">
            </span>Xxxxxxx xxxxxx


* [Xxxxxxxxxxxxx xxx xxxxxxxxxxxx xx'x xxx xxx'xx](guidelines-and-checklist-for-globalizing-your-app.md)
* [Xxx XX xxxxxxx xxxx xxxxxxxxx](put-ui-strings-into-resources.md)
* [Xxx xx xxxx xxxxxxxxx xxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)
 
<!--HONumber=Mar16_HO1-->
