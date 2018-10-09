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
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4468115"
---
# <a name="develop-universal-windows-apps-for-education"></a>教育機関向けのユニバーサル Windows アプリを開発します。
![テスト アプリのスクリーン ショット](images/take-a-test-screen-small.png)

次のリソースを使用すると、教育機関向けのユニバーサル Windows アプリを作成できます。

### <a name="accessibility"></a>アクセシビリティ
教育機関向けのアプリがアクセスできるようにする必要があります。 詳細については、[アクセシビリティ用アプリの開発](https://developer.microsoft.com/windows/accessible-apps)を参照してください。


### <a name="secure-assessments"></a>安全な評価
アプリの評価/テストは、受講者がテスト中に他のコンピューターやインターネット リソースを使用するを防ぐために、*ロック ダウン*環境を作成する必要があります。 この機能は、[テスト Api](take-a-test-api.md)で利用できます。 ロック ダウン厳正なテスト用オンラインへのアクセスとテスト環境の例については、Windows IT センターでの[テストでは、](https://technet.microsoft.com/edu/windows/take-tests-in-windows-10) web アプリを参照してください。

### <a name="user-input"></a>ユーザー入力
ユーザー入力が教育機関向けのアプリの重要な部分UI コントロールは、応答性と、ユーザーのフォーカスを中断にならないように直感的である必要があります。 ユニバーサル Windows アプリで利用可能な入力オプションの一般的な概要については、[入力の基本情報](https://docs.microsoft.com/windows/uwp/design/input/input-primer)と設計および UI のセクションの下にあるトピックを参照してください。 さらに、次のサンプル アプリは、ユニバーサル Windows プラットフォームで処理する基本的な UI を紹介します。
- [基本的な入力のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BasicInput)は、ユニバーサル Windows アプリで入力を処理する方法を示しています。
- [ユーザー操作モードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/UserInteractionMode)では、検出し、そのユーザーの対話式操作モードに対応する方法を示します。
- [フォーカスの視覚効果のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlFocusVisuals)は、新しいシステム描画フォーカスの視覚効果を利用したり場合は、独自のカスタム フォーカスの視覚効果を作成する方法を示しています。 システムが描画のニーズがに合わせてしないものです。

Windows Ink プラットフォームでは、受講者に慣れている入力モードと適合させることによって引き立た教育アプリを作成できます。 [ペン操作と Windows Ink](https://docs.microsoft.com/windows/uwp/design/input/pen-and-stylus-interactions)と Windows Ink をアプリに実装する包括的なガイドの下にあるトピックを参照してください。 次のサンプル アプリは、この API の動作例を示します。
- [インクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Ink)では、JavaScript を使ってユニバーサル Windows アプリでインク機能 (などのキャプチャ、操作、およびインク ストロークを解釈する) を使用する方法を示します。
- [単純なインクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleInk)では、c# を使用してユニバーサル Windows アプリで (ユーザー入力からのインクのキャプチャ、インク ストロークを手書き認識の実行) などのインク機能を使用する方法を示します。
- [複雑なインクのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ComplexInk)では、他のオブジェクト、インクの選択、コピー、貼り付け、およびイベントの処理とインクをインターリーブする InkPresenter の高度な機能を使用する方法を示します。 C++ では、ユニバーサル Windows プラットフォームを使って構築し、デスクトップとモバイルの Windows 10 の Sku で実行できます。


### <a name="microsoft-store"></a>Microsoft Store
教育アプリは、多くの場合、特定の組織の特殊な状況で解放されます。 詳細については、[基幹業務アプリの企業への配布](https://msdn.microsoft.com/windows/uwp/publish/distribute-lob-apps-to-enterprises)を参照してください。

## <a name="related-topics"></a>関連トピック
- [Windows 10 Education for](https://technet.microsoft.com/edu/windows/index) windows IT センター
