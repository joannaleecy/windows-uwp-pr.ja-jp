---
Description: During text entry and editing, spell checking informs the user that a word is misspelled by highlighting it with a red squiggle and providing a way for the user to correct the misspelling.
title: Spell checking and text prediction
ms.assetid: B867C956-5AB2-4207-A8DE-179CE7871180
label: Spell checking and text prediction
template: detail.hbs
---

# Guidelines for spell checking

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

During text entry and editing, spell checking informs the user that a word is misspelled by highlighting it with a red squiggle and provides a way for the user to correct the misspelling.

**Important APIs**

-   [**IsSpellCheckEnabled property (XAML)**](https://msdn.microsoft.com/library/windows/apps/br209688)


## <span id="checklist_section"></span><span id="CHECKLIST_SECTION"></span>Recommendations


-   Use spell checking to help users as they enter words or sentences into text input controls. Spell checking works with touch, mouse, and keyboard inputs.
-   Don't use spell checking when a word is not likely to be in the dictionary or if users wouldn't value spell checking. For example, don't turn it on for input boxes of passwords, telephone numbers, or names. Spell checking is disabled by default for these controls.
-   Don't disable spell checking just because the current spell checking engine doesn't support your app language. When the spell checker doesn't support a language, it doesn't do anything, so there's no harm in leaving the option on. Also, some users might use an Input Method Editor (IME) to enter another language into your app, and that language might be supported. For example, when building a Japanese language app, even though the spell checking engine might not currently recognize that language, don't turn spell checking off. The user may switch to an English IME and type English into the app; if spell checking is enabled, the English will get spell checked.

## <span id="Additional_usage_guidance"></span><span id="additional_usage_guidance"></span><span id="ADDITIONAL_USAGE_GUIDANCE"></span>Additional usage guidance


Windows Store apps provide a built-in spell checker for multiline and single text input boxes, and elements that have their **contentEditable** property set to **true**. Here's an example of the built-in spell checker:

![the built-in spell checker](images/spellchecking.png)

For more info, see the [**TextBox class**](https://msdn.microsoft.com/library/windows/apps/br209683).

Use spell checking with text input controls for these two purposes:

-   **To auto-correct misspellings**

    The spell checking engine automatically corrects misspelled words when it's confident about the correction. For example, the engine automatically changes "teh" to "the."

-   **To show alternate spellings**

    When the spell checking engine is not confident about the corrections, it adds a red line under the misspelled word and displays the alternates in a context menu when you tap or right-click the word.

For JavaScript controls, spell checking is turned on by default for multi-line text input controls and turned off for single-line controls. You can manually turn it on for single-line controls by setting the control's **spellcheck** property to **true**. You can disable spell checking for a control by setting its **spellcheck** property to **false**.

For XAML TextBox controls, spell checking is turned off by default. You can turn it on by setting the **IsSpellCheckEnabled** property to **true**.

\[This article contains information that is specific to Universal Windows Platform (UWP) apps and Windows 10. For Windows 8.1 guidance, please download the [Windows 8.1 guidelines PDF](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## <span id="related_topics"></span>Related articles

* [Text and text controls](text-controls.md)
* [Guidelines for text input](https://msdn.microsoft.com/library/windows/apps/hh750315)
* [Guidelines for text and typography](https://msdn.microsoft.com/library/windows/apps/hh700394)
**For developers (XAML)**
* [**TextBox.IsSpellCheckEnabled property**](https://msdn.microsoft.com/library/windows/apps/br209688)
* [**TextBox class**](https://msdn.microsoft.com/library/windows/apps/br209683)

 






<!--HONumber=Mar16_HO1-->


