---
title: ウィンドウ モードと全画面表示モード
description: Direct3D アプリケーションは、ウィンドウ モードと全画面表示モードのどちらでも実行できます。
ms.assetid: EE8B9F87-822B-4576-A446-CA603E786862
keywords:
- ウィンドウ モードと全画面表示モード
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d84bbebfaf19b756e6abc6c592187b6b0ee92200
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8692973"
---
# <a name="span-iddirect3dconceptswindowedvsfull-screenmodespanwindowed-vs-full-screen-mode"></a><span id="direct3dconcepts.windowed_vs__full-screen_mode"></span>ウィンドウ モードと全画面表示モード


Direct3D アプリケーションは、ウィンドウ モードと全画面表示モードのどちらでも実行できます。 *ウィンドウ モード*では、アプリケーションは実行中のすべてのアプリケーションとデスクトップの利用可能な画面領域を共有します。 "全画面表示モード"** では、アプリケーションを実行するウィンドウがデスクトップ全体に表示され、実行中の他のアプリケーションはすべて (開発環境も含めて) 見えなくなります。 通常、ゲームは既定で全画面表示モードになり、実行中のアプリケーションをすべて隠してユーザーがゲームに完全に没頭できるようにするのが一般的です。

全画面表示モードとウィンドウ モードのコードの違いはごくわずかです。

全画面表示モードで動作するアプリケーションは画面を占有するため、アプリケーションのデバッグには、別のモニターかリモート デバッガーを使う必要があります。 ウィンドウ モード アプリケーションの利点の 1 つは、複数のモニターやリモート デバッガーを使わなくても、コードをステップ実行できることにあります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[デバイス](devices.md)

 

 




