---
Description: Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.
title: 複数の入力の設計ガイドライン
ms.assetid: 03EB5388-080F-467C-B272-C92BE00F2C69
label: Multiple inputs
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c67430680854e7940d12af15ecd3c07dcd976802
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8323556"
---
# <a name="multiple-inputs"></a>複数の入力


人がお互いにコミュニケーションをとる際に音声とジェスチャを組み合わせて使うように、アプリの操作では、複数の種類とモードの入力を使うと便利な場合があります。


できるだけ多くのユーザーやデバイスに対応するため、可能な限り多くの入力の種類 (ジェスチャ、音声、タッチ、タッチパッド、マウス、キーボード) で作業できるようにアプリを設計することをお勧めします。 これにより、柔軟性、操作性、アクセシビリティが最大限に高まります。

最初に、アプリで入力を処理するさまざまなシナリオを検討します。 アプリ全体で一貫性を保つようにし、プラットフォーム コントロールでは、複数の入力の種類に対応する組み込みサポートを用意します。

-   ユーザーは、複数の入力デバイスを使ってアプリケーションを操作できますか?
-   すべての入力方法が常にサポートされていますか? 特定のコントロールでサポートされていますか? 特定の時間や環境でサポートされていますか?
-   1 つの入力方法が優先されますか?

## <a name="single-or-exclusive-mode-interactions"></a>単一 (排他) モードの操作


単一モードの操作では、複数の入力の種類がサポートされますが、1 つのアクションで使用できるのは、1 つのみです。 たとえば、コマンドに音声認識、ナビゲーションにジェスチャなどです。または近接度に応じて、タッチかジェスチャを使用してテキストを入力します。

## <a name="multimodal-interactions"></a>マルチモーダル操作

マルチモーダル操作では、1 つのアクションを完了するために複数の入力方法が順番に使われます。

音声認識 + ジェスチャ  
ユーザーは製品をポイントし、「カートに追加」と言います。

音声認識 + タッチ  
ユーザーは長押しを使用して写真を選択し、「写真の送信」と言います。



