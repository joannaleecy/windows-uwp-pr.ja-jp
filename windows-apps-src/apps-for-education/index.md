---
author: PatrickFarley
title: 教育機関向けのアプリを開発します。
description: このセクションでは、Windows 10 のプラットフォームの教育機関向けのアプリを作成するに使用できるユニバーサル ウィンドウ アプリのリソースについて説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、教育機関向け
ms.assetid: 2431f253-efe3-4895-b131-34653b61f13c
ms.localizationpriority: medium
ms.openlocfilehash: da03a3c478ca45cc2d2b518988738e510a6c5ea9
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2867821"
---
# <a name="develop-universal-windows-apps-for-education"></a>教育機関向けのどこからでも Windows アプリを開発します。
![テストを取るアプリのスクリーン ショット](images/take-a-test-screen-small.png)

次のリソースを使用すると、教育機関向けのどこからでも Windows アプリを作成できます。

### <a name="accessibility"></a>アクセシビリティ
教育機関向けのアプリがアクセスできるようにする必要があります。 詳細については、[アクセシビリティ用のアプリの開発](https://developer.microsoft.com/windows/accessible-apps)を参照してください。


### <a name="secure-assessments"></a>セキュリティで保護された評価
アプリの評価/テストが学生テスト中に他のコンピューターまたはインターネット リソースを使用できないようにするために、*ロックされた*環境を作成する必要があります。 この機能は、[テストの API の実行](take-a-test-api.md)を使用します。 高無制限テスト用のオンライン アクセス ロックダウン テスト環境との例については、Windows の IT センターで[、テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)の web アプリケーションを参照してください。

### <a name="user-input"></a>ユーザー入力
教育機関向けアプリの重要な部分は、ユーザーの入力応答し、ユーザーのフォーカスを解除すると、直感的な UI コントロールがあります。 どこからでも Windows アプリで利用可能な言語のオプションの概要、[入力の概要](https://docs.microsoft.com/windows/uwp/design/input/input-primer)とデザインと UI] セクションで、その下にあるトピックを参照してください。 さらに、次のサンプル アプリは、基本的な UI がどこからでも Windows プラットフォームの処理を紹介します。
- [基本的な入力の例](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BasicInput)では、どこからでも Windows アプリでの入力を処理する方法を示します。
- [ユーザーとの対話モードの例](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/UserInteractionMode)では、検出し、ユーザーとの対話モードに応答する方法を示します。
- [フォーカス ビジュアル サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlFocusVisuals)は、新しいシステム描画フォーカス ビジュアルを利用する場合は、独自のカスタム フォーカス視覚効果を作成する方法を示しています。 描画システム ニーズにも属さないものです。

インクの Windows プラットフォームでは、入力モードであり、学生に慣れていることを調整して輝く教育機関向けのアプリを作成できます。 [ペンの相互作用し Windows のインク](https://docs.microsoft.com/windows/uwp/design/input/pen-and-stylus-interactions)とアプリで Windows インクを実装する包括的なガイドは、その下のトピックを参照してください。 次のサンプル アプリでは、この API を操作する例を示します。
- [インクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Ink)は、JavaScript を使用して、どこからでも Windows アプリで (キャプチャ、操作、およびインク ストロークを解釈する) などのインク機能を使用する方法を示します。
- [単純なインクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)は、c# を使用して、どこからでも Windows アプリで (ユーザーが入力したインクを把握して、インク ストロークに手書き認識を実行する) などのインク機能を使用する方法を示します。
- [複雑なインクの例](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk)では、InkPresenter の高度な機能を使用してに他のオブジェクト、[インク、コピー/貼り付け]、およびイベントを処理とインクを移動する方法を示します。 C でどこからでも Windows プラットフォームに組み込まれて、デスクトップとモバイル Windows 10 の Sku で実行できます。


### <a name="microsoft-store"></a>Microsoft Store
教育機関向けのアプリは、多くの場合、特定の組織に特別な状況で解放されます。 詳細については、[企業に基幹業務のアプリの配布](https://msdn.microsoft.com/windows/uwp/publish/distribute-lob-apps-to-enterprises)を参照してください。

## <a name="related-topics"></a>関連トピック
- [Windows 10 教育機関向け](https://technet.microsoft.com/edu/windows/index)windows IT センター
