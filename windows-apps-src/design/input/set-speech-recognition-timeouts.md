---
Description: 音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。
title: 音声認識のタイムアウトの設定
ms.assetid: 58F446AC-4A56-454D-8125-62A2C4DBFCC8
label: Speech recognition timeouts
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 679c2632fd5793ae083b2a79e29de3a3e9da04cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627167"
---
# <a name="set-speech-recognition-timeouts"></a>音声認識のタイムアウトの設定


音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。

> **重要な Api**:[**タイムアウト**](https://msdn.microsoft.com/library/windows/apps/dn653253)、 [ **SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)

## <a name="set-a-timeout"></a>タイムアウトの設定


ここでは、さまざまな [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253) 値を指定します。

-   InitialSilenceTimeout: SpeechRecognizer が (認識結果が生成されるまでの) 無音を検出し、音声入力が続かないと見なす時間の長さ。
-   BabbleTimeout: SpeechRecognizer が、認識できないサウンド (雑音) のリッスンを継続し、音声入力が終了したと見なし、認識処理を終了するまでの時間の長さ。
-   EndSilenceTimeout: SpeechRecognizer が (認識結果が生成された後の) 無音を検出し、音声入力が終了したと見なす時間の長さ。

**注**  あたり認識エンジンごとにタイムアウトを設定することができます。

 

```CSharp
// Set timeout settings.
recognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(6.0);
recognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(4.0);
recognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(1.2);
```

## <a name="related-articles"></a>関連記事


* [音声操作](speech-interactions.md)
**サンプル**
* [音声認識と音声合成のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




