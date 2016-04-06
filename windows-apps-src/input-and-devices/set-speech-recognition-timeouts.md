---
Description: Set how long a speech recognizer ignores silence or unrecognizable sounds (babble) and continues listening for speech input.
title: Set speech recognition timeouts
ms.assetid: 58F446AC-4A56-454D-8125-62A2C4DBFCC8
label: Speech recognition timeouts
template: detail.hbs
---

# Set speech recognition timeouts
Set how long a speech recognizer ignores silence or unrecognizable sounds (babble) and continues listening for speech input.

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253)
-   [**SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)


## <span id="Set_a_timeout"></span><span id="set_a_timeout"></span><span id="SET_A_TIMEOUT"></span>Set a timeout


Here, we specify various [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253) values:

-   InitialSilenceTimeout - The length of time that a SpeechRecognizer detects silence (before any recognition results have been generated) and assumes speech input is not forthcoming.
-   BabbleTimeout - The length of time that a SpeechRecognizer continues to listen to unrecognizable sounds (babble) before it assumes speech input has ended and finalizes the recognition operation.
-   EndSilenceTimeout - The length of time that a SpeechRecognizer detects silence (after recognition results have been generated) and assumes speech input has ended.

**Note**  Timeouts can be set on a per-recognizer basis.

 

```CSharp
// Set timeout settings.
recognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(6.0);
recognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(4.0);
recognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(1.2);
```

## <span id="related_topics"></span>Related articles


* [Speech interactions](speech-interactions.md)
**Samples**
* [Speech recognition and speech synthesis sample](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 






<!--HONumber=Mar16_HO1-->


