---
author: Karl-Bridge-Microsoft
Description: "音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。"
title: "音声認識のタイムアウトの設定"
ms.assetid: 58F446AC-4A56-454D-8125-62A2C4DBFCC8
label: Speech recognition timeouts
template: detail.hbs
keywords: "スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作"
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: 482530931fe5764f65d2564107318c272c5c7b7f
ms.openlocfilehash: 770a34c7c190540456a2748290b0aa557fcc1800

---

# <a name="set-speech-recognition-timeouts"></a>音声認識のタイムアウトの設定
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。

<div class="important-apis" >
<b>重要な API</b><br/>
<ul>
<li>[**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253)</li>
<li>[**SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)</li>
</ul>
</div>

## <a name="set-a-timeout"></a>タイムアウトの設定


ここでは、さまざまな [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253) 値を指定します。

-   InitialSilenceTimeout: SpeechRecognizer が (認識結果が生成されるまでの) 無音を検出し、音声入力が続かないと見なす時間の長さ。
-   BabbleTimeout: SpeechRecognizer が、認識できないサウンド (雑音) のリッスンを継続し、音声入力が終了したと見なし、認識処理を終了するまでの時間の長さ。
-   EndSilenceTimeout: SpeechRecognizer が (認識結果が生成された後の) 無音を検出し、音声入力が終了したと見なす時間の長さ。

**注**  タイムアウトは認識エンジンごとに設定できます。

 

```CSharp
// Set timeout settings.
recognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(6.0);
recognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(4.0);
recognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(1.2);
```

## <a name="related-articles"></a>関連記事


* [音声操作](speech-interactions.md)
**サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 







<!--HONumber=Dec16_HO3-->


