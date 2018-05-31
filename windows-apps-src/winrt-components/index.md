---
author: msatranjr
title: Windows ランタイム コンポーネント
description: Windows ランタイム コンポーネントは自己完結型オブジェクトで、C#、Visual Basic、JavaScript、C++ など、すべての言語からインスタンス化して使用することができます。
ms.assetid: 55887622-828b-4318-87f2-25592268f7c1
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: cc6d955ac77409f37b7701bef8c1fa4d93c97e3c
ms.sourcegitcommit: 54c2cd58fde08af889093a0c85e7297e33e6a0eb
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/19/2018
ms.locfileid: "1664935"
---
# <a name="windows-runtime-components"></a>Windows ランタイム コンポーネント



Windows ランタイム コンポーネントは自己完結型オブジェクトで、C#、Visual Basic、JavaScript、C++ など、すべての言語からインスタンス化して使用することができます。

Visual Studio と C#、Visual Basic、または C++ を使って、ユニバーサル Windows プラットフォーム (UWP) アプリで使用できる Windows ランタイム コンポーネントを作成できます。

| トピック | 説明 |
|-------|-------------|
| [C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md) | この記事では、C++ を使って Windows ランタイム コンポーネントを作成する方法を示します。このコンポーネントは、JavaScript (または C#、Visual Basic、C++) を使って構築したユニバーサル Windows アプリから呼び出すことができる DLL です。 |
| [チュートリアル: C++ での基本的な Windows ランタイム コンポーネントの作成と JavaScript または C# からの呼び出し](walkthrough-creating-a-basic-windows-runtime-component-in-cpp-and-calling-it-from-javascript-or-csharp.md) | このチュートリアルでは、JavaScript、C#、または Visual Basic から呼び出すことができる基本的な Windows ランタイム コンポーネント DLL を作成する方法について説明します。 このチュートリアルを開始する前に、抽象バイナリ インターフェイス (ABI)、ref クラス、Visual C++ コンポーネント拡張などの概念を必ず理解しておいてください。ref クラスの操作が容易になります。 詳しくは、「[C++ での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-cpp.md)」および「[Visual C++ の言語リファレンス (C++/CX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx)」をご覧ください。 |
| [C# および Visual Basic での Windows ランタイム コンポーネントの作成](creating-windows-runtime-components-in-csharp-and-visual-basic.md) | .NET Framework 4.5 以降では、マネージ コードを使って独自の Windows ランタイム型を作成し、Windows ランタイム コンポーネントにパッケージ化することができます。 また、C++、JavaScript、Visual Basic、C# を利用することで、ユニバーサル Windows プラットフォーム (UWP) アプリでコンポーネントを使うことができます。 この記事では、コンポーネントを作成するための規則を示し、Windows ランタイム向けの .NET Framework のサポートをいくつか説明します。 このサポートは、通常、.NET Framework のプログラマが意識しなくても利用できるように設計されています。 ただし、JavaScript や C++ で使うコンポーネントを作成する場合は、これらの言語が Windows ランタイムをサポートする方法の違いに注意する必要があります。 |
| [チュートリアル: 単純な Windows ランタイム コンポーネントの作成と JavaScript からの呼び出し](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md) | このチュートリアルでは、Visual Basic または C# で .NET Framework を使って、Windows ランタイム コンポーネントにパッケージ化される独自の Windows ランタイム型を作成する方法と、JavaScript を使って Windows 用にビルドされたユニバーサル Windows アプリからコンポーネントを呼び出す方法について説明します。 |
| [Windows ランタイム コンポーネントでイベントを生成する](raising-events-in-windows-runtime-components.md) | Windows ランタイム コンポーネントを使って、ユーザー定義のデリゲート型のイベントをバック グラウンド スレッド (ワーカー スレッド) で発生させ、このイベントを JavaScript で受け取る場合、以下のいずれかの方法でイベントを実装し、発生させることができます。 | 
| [サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー](brokered-windows-runtime-components-for-side-loaded-windows-store-apps.md) | このトピックでは、ビジネスに欠かせない重要な操作を実行する既存のコードを、タッチ対応の .NET アプリで使用できるようにする機能について説明します。これは、Windows 10 更新プログラム以降でサポートされるエンタープライズ向けの機能です。 |
