---
author: Karl-Bridge-Microsoft
Description: "音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。"
title: "音声認識のタイムアウトの設定"
ms.assetid: 58F446AC-4A56-454D-8125-62A2C4DBFCC8
label: Speech recognition timeouts
template: detail.hbs
ms.sourcegitcommit: a2ec5e64b91c9d0e401c48902a18e5496fc987ab
ms.openlocfilehash: 99ead02e8886ae79b8e8423ac0f78609b4fa1f6f

---

# 音声認識のタイムアウトの設定
音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。

**重要な API**

-   [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253)
-   [**SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)


## タイムアウトの設定


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

## 関連記事


* [音声操作](speech-interactions.md)
            
          
            **サンプル**
* [音声認識と音声合成のサンプル](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 







<!--HONumber=Jun16_HO5-->


