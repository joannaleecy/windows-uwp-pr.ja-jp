---
Description: Set how long a speech recognizer ignores silence or unrecognizable sounds (babble) and continues listening for speech input.
title: 音声認識のタイムアウトの設定
ms.assetid: 58F446AC-4A56-454D-8125-62A2C4DBFCC8
label: Speech recognition timeouts
template: detail.hbs
keywords: スピーチ, 音声, 音声認識, 自然言語, ディクテーション, 入力, ユーザーの操作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 73c7e889b4633dae9e416cf7ccde13eb3f58e8ee
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8873217"
---
# <a name="set-speech-recognition-timeouts"></a><span data-ttu-id="c221a-103">音声認識のタイムアウトの設定</span><span class="sxs-lookup"><span data-stu-id="c221a-103">Set speech recognition timeouts</span></span>


<span data-ttu-id="c221a-104">音声認識エンジンが無音または認識できないサウンド (雑音) を無視し、音声入力を待機する時間の長さを設定します。</span><span class="sxs-lookup"><span data-stu-id="c221a-104">Set how long a speech recognizer ignores silence or unrecognizable sounds (babble) and continues listening for speech input.</span></span>

> <span data-ttu-id="c221a-105">**重要な API**: [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253)、[**SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)</span><span class="sxs-lookup"><span data-stu-id="c221a-105">**Important APIs**: [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253), [**SpeechRecognizerTimeouts**](https://msdn.microsoft.com/library/windows/apps/dn653230)</span></span>

## <a name="set-a-timeout"></a><span data-ttu-id="c221a-106">タイムアウトの設定</span><span class="sxs-lookup"><span data-stu-id="c221a-106">Set a timeout</span></span>


<span data-ttu-id="c221a-107">ここでは、さまざまな [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253) 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="c221a-107">Here, we specify various [**Timeouts**](https://msdn.microsoft.com/library/windows/apps/dn653253) values:</span></span>

-   <span data-ttu-id="c221a-108">InitialSilenceTimeout: SpeechRecognizer が (認識結果が生成されるまでの) 無音を検出し、音声入力が続かないと見なす時間の長さ。</span><span class="sxs-lookup"><span data-stu-id="c221a-108">InitialSilenceTimeout - The length of time that a SpeechRecognizer detects silence (before any recognition results have been generated) and assumes speech input is not forthcoming.</span></span>
-   <span data-ttu-id="c221a-109">BabbleTimeout: SpeechRecognizer が、認識できないサウンド (雑音) のリッスンを継続し、音声入力が終了したと見なし、認識処理を終了するまでの時間の長さ。</span><span class="sxs-lookup"><span data-stu-id="c221a-109">BabbleTimeout - The length of time that a SpeechRecognizer continues to listen to unrecognizable sounds (babble) before it assumes speech input has ended and finalizes the recognition operation.</span></span>
-   <span data-ttu-id="c221a-110">EndSilenceTimeout: SpeechRecognizer が (認識結果が生成された後の) 無音を検出し、音声入力が終了したと見なす時間の長さ。</span><span class="sxs-lookup"><span data-stu-id="c221a-110">EndSilenceTimeout - The length of time that a SpeechRecognizer detects silence (after recognition results have been generated) and assumes speech input has ended.</span></span>

<span data-ttu-id="c221a-111">**注:** タイムアウトは認識エンジンごとに設定できます。</span><span class="sxs-lookup"><span data-stu-id="c221a-111">**Note**Timeouts can be set on a per-recognizer basis.</span></span>

 

```CSharp
// Set timeout settings.
recognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(6.0);
recognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(4.0);
recognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(1.2);
```

## <a name="related-articles"></a><span data-ttu-id="c221a-112">関連記事</span><span class="sxs-lookup"><span data-stu-id="c221a-112">Related articles</span></span>


* <span data-ttu-id="c221a-113">[音声操作](speech-interactions.md)
**サンプル**</span><span class="sxs-lookup"><span data-stu-id="c221a-113">[Speech interactions](speech-interactions.md)
**Samples**</span></span>
* [<span data-ttu-id="c221a-114">音声認識と音声合成のサンプル</span><span class="sxs-lookup"><span data-stu-id="c221a-114">Speech recognition and speech synthesis sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=619897)
 

 




