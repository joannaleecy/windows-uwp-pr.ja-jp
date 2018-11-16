---
author: msatranjr
title: Windows ランタイム コンポーネント
description: Windows ランタイム コンポーネントは自己完結型オブジェクトで、C#、Visual Basic、JavaScript、C++ など、すべての言語からインスタンス化して使用することができます。
ms.assetid: 55887622-828b-4318-87f2-25592268f7c1
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b93b3028c7968c417d4476a6f183805cdec797b0
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6670424"
---
# <a name="windows-runtime-components"></a>Windows ランタイム コンポーネント
Windows ランタイム コンポーネントは自己完結型オブジェクトで、C#、Visual Basic、JavaScript、C++ など、すべての言語からインスタンス化して使用することができます。

Visual Studio と C#、Visual Basic、または C++ を使って、ユニバーサル Windows プラットフォーム (UWP) アプリで使用できる Windows ランタイム コンポーネントを作成できます。

| トピック | 説明 |
|-------|-------------|
| [C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md) | このトピックでは、C++ を使用する方法を示しています。 + CX コンポーネントは c#、Visual Basic、C++、または Javascript を使って構築されたユニバーサル Windows アプリから呼び出すことができるのは Windows ランタイム コンポーネントを作成します。 |
| [チュートリアル: C++ での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md) | このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。 このチュートリアルを開始する前に、抽象バイナリ インターフェイス (ABI)、ref クラス、Visual C++ コンポーネント拡張などの概念を必ず理解しておいてください。ref クラスの操作が容易になります。 詳しくは、「[C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)」および「[Visual C++ の言語リファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)」をご覧ください。 |
| [C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md) | .NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。 また、C++、JavaScript、Visual Basic、C# を利用することで、ユニバーサル Windows プラットフォーム (UWP) アプリでコンポーネントを使うことができます。 このトピックでは、コンポーネントを作成するための規則について説明し、Windows ランタイムの .NET Framework のサポートの一部の側面を説明します。 このサポートは、通常、.NET Framework のプログラマが意識しなくても利用できるように設計されています。 ただし、JavaScript や C++ で使うコンポーネントを作成する場合は、これらの言語が Windows ランタイムをサポートする方法の違いに注意する必要があります。 |
| [チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md) | このチュートリアルでは、Visual Basic または C# で .NET Framework を使って、Windows ランタイム コンポーネントにパッケージ化される独自の Windows ランタイム型を作成する方法と、JavaScript を使って Windows 用にビルドされたユニバーサル Windows アプリからコンポーネントを呼び出す方法について説明します。 |
| [Windows ランタイム コンポーネントでイベントを生成する](raising-events-in-windows-runtime-components.md) | Windows ランタイム コンポーネントを使って、ユーザー定義のデリゲート型のイベントをバック グラウンド スレッド (ワーカー スレッド) で発生させ、このイベントを JavaScript で受け取る場合、以下のいずれかの方法でイベントを実装し、発生させることができます。 | 
| [サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー](brokered-windows-runtime-components-for-side-loaded-windows-store-apps.md) | このトピックでは、ビジネスに欠かせない重要な操作を実行する既存のコードを、タッチ対応の .NET アプリで使用できるようにする機能について説明します。これは、Windows 10 更新プログラム以降でサポートされるエンタープライズ向けの機能です。 |
