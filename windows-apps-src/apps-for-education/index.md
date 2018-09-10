---
author: PatrickFarley
title: 教育機関向けのアプリを開発します。
description: このセクションでは、ウィンドウのユニバーサル アプリなリソースを利用できるように、Windows 10 プラットフォームの教育機関向けのアプリの作成について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 教育
ms.assetid: 2431f253-efe3-4895-b131-34653b61f13c
ms.localizationpriority: medium
ms.openlocfilehash: da03a3c478ca45cc2d2b518988738e510a6c5ea9
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3820816"
---
# <a name="develop-universal-windows-apps-for-education"></a>教育機関向けのユニバーサル Windows アプリを開発します。
![テスト アプリのスクリーン ショット](images/take-a-test-screen-small.png)

次のリソースを使用すると、教育機関向けのユニバーサル Windows アプリを作成できます。

### <a name="accessibility"></a>アクセシビリティ
教育機関向けのアプリにアクセスできる必要があります。 詳細については、[アクセシビリティ用アプリの開発](https://developer.microsoft.com/windows/accessible-apps)を参照してください。


### <a name="secure-assessments"></a>安全な評価
評価/テスト アプリでは、受講者がテスト中に他のコンピューターやインターネット リソースを使用することを防ぐために、*ロック ダウン*環境を生成する必要があります。 この機能は、[テスト Api](take-a-test-api.md)を使用できます。 重要なテスト用オンラインへのアクセスのロックダウン、テスト環境での例では、Windows IT センターで[テスト](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10)の web アプリを参照してください。

### <a name="user-input"></a>ユーザー入力
ユーザー入力が重要な部分の教育アプリです。UI コントロールは、応答性とそのユーザーのフォーカスを中断にならないように直感的である必要があります。 ユニバーサル Windows アプリで利用できる入力オプションの一般的な概要については、[操作の基本情報](https://docs.microsoft.com/windows/uwp/design/input/input-primer)と設計および UI のセクションで、次のトピックをご覧ください。 さらに、次のサンプル アプリは、ユニバーサル Windows プラットフォームで処理する基本的な UI を紹介します。
- [基本的な入力のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BasicInput)では、ユニバーサル Windows アプリで入力を処理する方法を示します。
- [ユーザー操作モードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/UserInteractionMode)では、検出し、そのユーザーの対話式操作モードに対応する方法を示します。
- [フォーカスの視覚効果のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlFocusVisuals)は、新しいシステム描画フォーカスの視覚効果を利用したり場合は、独自のカスタム フォーカスの視覚効果を作成する方法を示しています。 システムが描画、ニーズに合わせてものはありません。

Windows Ink プラットフォームでは、学生に慣れている入力モードに適合させることによって引き立た教育アプリを作成できます。 [ペン操作と Windows Ink](https://docs.microsoft.com/windows/uwp/design/input/pen-and-stylus-interactions)と Windows Ink をアプリに実装する包括的なガイドが次のトピックをご覧ください。 次のサンプル アプリは、この API の動作の例を示します。
- [インクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Ink)では、JavaScript を使ってユニバーサル Windows アプリでインク機能 (など、キャプチャ操作、およびし、インク ストロークを解釈する) を使用する方法を示します。
- [単純なインクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)では、c# を使ってユニバーサル Windows アプリで (ユーザー入力からのインクのキャプチャ、インク ストロークを手書き認識の実行) などのインク機能を使用する方法を示します。
- [複雑なインクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk)では、他のオブジェクト、インクの選択、コピー、貼り付け、イベントの処理とインクをインターリーブする InkPresenter の高度な機能を使用する方法を示します。 C++ では、ユニバーサル Windows プラットフォームに基づいて構築されていますが、デスクトップとモバイルの Windows 10 の Sku で実行できます。


### <a name="microsoft-store"></a>Microsoft Store
教育機関向けのアプリは多くの場合、特定の組織の特殊な状況でリリースされます。 これについては、[基幹業務アプリの企業への配布](https://msdn.microsoft.com/windows/uwp/publish/distribute-lob-apps-to-enterprises)を参照してください。

## <a name="related-topics"></a>関連トピック
- [Windows 10 for Education](https://technet.microsoft.com/edu/windows/index)では、Windows IT センター
