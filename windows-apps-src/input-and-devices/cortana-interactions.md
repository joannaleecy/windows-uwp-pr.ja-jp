---
Description: Extend the basic functionality of Cortana with voice commands that launch and execute a single action in an external application.
title: Cortana interactions
ms.assetid: 4C11A7CF-DA26-4CA1-A9B9-FE52670101F5
label: Cortana
template: detail.hbs
---

# Cortana interactions in UWP apps


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Extend the basic functionality of **Cortana** with voice commands that launch and execute a single action in an external application. 


**Other speech components**

-   See the [Speech design guidelines](speech-interactions.md) if integrating speech recognition and text-to-speech (also known as TTS, or speech synthesis) directly into your app.

> **Note**  
> A voice command is a single utterance with a specific intent, defined in a Voice Command Definition (VCD) file, directed at an installed app through **Cortana**.

> A VCD file defines one or more voice commands, each with a unique intent.

> A voice command definition can vary in complexity. It can support anything from a single, constrained utterance to a collection of more flexible, natural language utterances, all denoting the same intent.


The target app can be launched in the foreground (the app takes focus and **Cortana** is dismissed) or activated in the background (**Cortana** retains focus but provides results from the app), depending on the complexity of the interaction. For example, voice commands that require additional context or user input are best handled in a foreground app, while basic commands can be handled in **Cortana** through a background app.

 

By integrating the basic functionality of your app, and providing a central entry point for the user to accomplish most of the tasks without opening your app directly, **Cortana** becomes a liaison between your app and the user. Providing this shortcut to app functionality and reducing the need to switch apps can save the user significant time and effort.


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Article</th>
<th align="left">Description</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[Design guidelines](cortana-design-guidelines.md)</p></td>
<td align="left"><p>These guidelines and recommendations describe how your app can best use **Cortana** to interact with the user, help them accomplish a task, and communicate clearly how it's all happening.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Launch a foreground app with voice commands](launch-a-foreground-app-with-voice-commands-in-cortana.md)</p></td>
<td align="left"><p>In addition to using voice commands within <strong>Cortana</strong> to access system features, you can also use voice commands through <strong>Cortana</strong> to launch a foreground app and specify an action or command to execute within the app.</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Dynamically modify VCD phrase lists](dynamically-modify-voice-command-definition--vcd--phrase-lists.md)</p></td>
<td align="left"><p>Learn how to access and update the list of supported phrases (<strong>PhraseList</strong> elements) in a VCD file using the speech recognition result at run time.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Launch a background app with voice commands](launch-a-background-app-with-voice-commands-in-cortana.md)</p></td>
<td align="left"><p>In addition to using voice commands within <strong>Cortana</strong> to access system features, you can also extend <strong>Cortana</strong> with features and functionality from a background app using voice commands that specify an action or command to execute within the app.</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Interact with a background app](interact-with-a-background-app-in-cortana.md)</p></td>
<td align="left"><p>Learn how a user can interact with a background app through the <strong>Cortana</strong> voice and canvas during the execution of a voice command.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Deep link to a background app](deep-link-into-your-app-from-cortana.md)</p></td>
<td align="left"><p>Provide deep links from the background app service in <strong>Cortana</strong> to launch the app to the foreground in a specific state or context.</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[Support natural language voice commands](support-natural-language-voice-commands-in-cortana.md)</p></td>
<td align="left"><p>Learn how to extend <strong>Cortana</strong> with more flexible and natural voice commands, so a user can say your app's name anywhere in the command.</p></td>
</tr>
</tbody>
</table>

 

## <span id="related_topics"></span>Related articles


* [**VCD elements and attributes v1.2**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Designers**
* [Speech design guidelines](https://msdn.microsoft.com/library/windows/apps/dn596121)
* [Cortana design guidelines](https://msdn.microsoft.com/library/windows/apps/dn974233)

**Samples**
* [Cortana voice command sample](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 






<!--HONumber=Mar16_HO4-->


