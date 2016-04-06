---
Description: Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.
title: Multiple inputs design guidelines
ms.assetid: 03EB5388-080F-467C-B272-C92BE00F2C69
label: Multiple inputs
template: detail.hbs
---

# Multiple inputs


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.


To accommodate as many users and devices as possible, we recommend that you design your apps to work with as many input types as possible (gesture, speech, touch, touchpad, mouse, and keyboard). Doing so will maximize flexibility, usability, and accessibility.

To begin, consider the various scenarios in which your app handles input. Try to be consistent throughout your app, and remember that the platform controls provide built-in support for multiple input types.

-   Can users interact with the application through multiple input devices?
-   Are all input methods supported at all times? With certain controls? At specific times or circumstances?
-   Does one input method take priority?

## <span id="Single__or_exclusive_-mode_interactions_"></span><span id="single__or_exclusive_-mode_interactions_"></span><span id="SINGLE__OR_EXCLUSIVE_-MODE_INTERACTIONS_"></span>Single (or exclusive)-mode interactions


With single-mode interactions, multiple input types are supported, but only one can be used per action. For example, speech recognition for commands, and gestures for navigation; or, text entry using touch or gestures, depending on proximity.

## <span id="Multimodal_interactions"></span><span id="multimodal_interactions"></span><span id="MULTIMODAL_INTERACTIONS"></span>Multimodal interactions


With multimodal interactions, multiple input methods in sequence are used to complete a single action.

<span id="Speech___gesture"></span><span id="speech___gesture"></span><span id="SPEECH___GESTURE"></span>Speech + gesture  
The user points to a product, and then says “Add to cart.”

<span id="Speech___touch"></span><span id="speech___touch"></span><span id="SPEECH___TOUCH"></span>Speech + touch  
The user selects a photo using press and hold, and then says “Send photo.”





<!--HONumber=Mar16_HO1-->


