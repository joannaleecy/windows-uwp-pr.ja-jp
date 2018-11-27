---
title: ユニバーサル Windows プラットフォームを使用してアプリを作成する
description: Windows 10 用ユニバーサル Windows プラットフォーム (UWP) アプリの作成は、思っているよりも簡単です。
ms.date: 5/7/2018
ms.topic: article
keywords: windows 10, uwp, 概要
ms.localizationpriority: medium
ms.openlocfilehash: 2f4e38d590fc2e905221c71c1fbc6b137f5fdea0
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7702280"
---
# <a name="start-coding"></a>コーディングの開始

![アプリの構築](images/build-your-app.png)

[UWP プラットフォーム](universal-application-platform-guide.md)へようこそ。 このページで、適切な情報を作成する Windows 10 アプリのコーディングを開始する必要があるポイントしますがあります。

開発を始める前に、必ず[セットアップする](get-set-up.md)必要があります。

## <a name="learning-tracks"></a>学習トラック

次の学習トラックでは、いくつかの基本的なタスクを完了するために知っておく必要がある情報と、その情報を見つけることができる場所について説明します。 学習トラックはチュートリアルではありませんが、正しい方法で行っていることを確認するためにリファレンス コードが提供されます。

| タスク | 説明 |
| --- | --- |
| [フォームの作成](construct-form-learning-track.md) | 使いやすく、画面サイズに関係なく適切な外観になるフォームを作成する方法について説明します。 | 
| [一覧での顧客の表示](display-customers-in-list-learning-track.md) | UI でデータを表示して編集する方法について説明します。 | 
| [保存と読み込みの設定](settings-learning-track.md) | 設定を保存して取得する方法と場所について説明します。 |
| [ファイルの操作](fileio-learning-track.md) | ファイルに対する読み取りと書き込みの方法、およびアクセス権のあるフォルダーとアクセス権のないフォルダーについて説明します。 | 

すべての学習トラックは、Windows 10 に慣れようとしている経験豊富な開発者を対象としています。 始めたばかりである場合は、[新しい開発者](#For-new-developers)のためのコンテンツから始めてください。

## <a name="for-new-developers"></a>新しい開発者向け

新しい開発者の場合は、Windows 10 の開発に必要になるコードとツールの使用方法の基本について説明する多くのリソースが用意されています。 

* ["Hello World" アプリを作成する](your-first-app.md)

コーディングの基本、C# 言語、Visual Studio、またはユニバーサル Windows プラットフォームの機能に関する詳細なチュートリアルが必要な場合は、次のリソースを確認してください。

**ドキュメント:**

* [C# の概要](https://docs.microsoft.com/dotnet/csharp/getting-started/)
* [C# クイック スタート](https://docs.microsoft.com/dotnet/csharp/quick-starts/index)
* [Visual Studio の概要](https://docs.microsoft.com/visualstudio/ide/)

**ビデオ**

* [Microsoft Virtual Academy](https://mva.microsoft.com/training-topics/c-app-development#!level=Beginner&lang=1033)
* [LinkedIn Learning](https://www.linkedin.com/learning/learning-universal-windows-app-development/welcome)

## <a name="using-the-docs"></a>ドキュメントの使用

学習トラックを既に試したか、または学習トラックで説明されていないことに興味がある場合は、Microsoft のドキュメントを通じて独自のツアーを試す必要があります。 各エリアで見つけることができる内容の簡単な概要を次に示します。

| エリア | 説明 |
| --- | --- |
| **新機能** | Windows 10 の各メジャー アップデートでは、ドキュメントが新しいガイダンスで拡張されています。 これらのドキュメントには、すべてのリリースで追加した機能と開発者向けガイダンスだけでなく、新しい API の一覧に関する情報が含まれます。 </br>   [最新の Windows 10 リリースでの開発者向け新機能](../whats-new/windows-10-version-latest.md) </br> ただし、ドキュメントを更新するのはメジャー リリースのときだけではありません。 常に開発者が参照するための新しい情報が追加されています。次の最新のドキュメントで最新情報を提供します。 </br>   [ドキュメントの新着情報](../whats-new/windows-docs-latest.md) |
| **設計と UI** | アプリの外観と UI に関するすべての情報がドキュメントのこのエリアに含まれています。XAML マークアップ言語の特定の情報に興味がある場合、または自分のドキュメント用に独自の外観を作成したい場合は、ここから始めてください。 </br>   [UWP アプリの設計の基本](../design/basics/index.md) |
| **アプリを開発する** | Windows 10 の特定の機能に関する詳細情報が必要である場合、または UWP 開発で行うことができる内容を確認することにのみ関心がある場合は、ドキュメントのこのエリアを確認してください。 </br>   [UWP アプリの機能](../develop/index.md) </br> Windows 10 アプリの API リファレンスは、関連する一連のドキュメントでホストされており、以下で参照できます。 </br>   [Windows UWP 名前空間](https://docs.microsoft.com/en-us/uwp/api/) </br>   [ファイルおよび XML スキーマ](https://docs.microsoft.com/uwp/schemas/) |
| **ゲームの開発** | これらのドキュメントには、Windows または Xbox でゲームを開発する方法に関する情報が含まれます。 これには、セットアップ手順、開発者プログラム、および DirectX または Xbox の機能を使用したプログラミングに関する手順が含まれます。 </br>   [ゲーム開発の概要](../gaming/getting-started.md) |
| **公開** | これらのドキュメントには、アプリの申請から価格の設定、販売促進と顧客エンゲージメントまで、Windows ストアにアプリを公開する方法に関する情報が含まれます。 </br>   [Windows ストアでのアプリの公開](../publish/index.md) |

## <a name="other-docs"></a>その他のドキュメント

Web 開発や、Mixed Reality のような一部の専用の Windows 10 プラットフォームには、独自のドキュメントのセットがあります。 これらの機能を使用してアプリを開発することに関心がある場合は、次のドキュメントを確認してください。

| ドキュメント | 説明 |
| --- | --- |
| **Microsoft Azure** | クラウドの開発と Microsoft Azure に関する情報は、[Microsoft Azure 開発者向けドキュメント](https://docs.microsoft.com/azure/)を参照してください。 |
| **Web 開発** | Microsoft Edge、WebVR、およびその他の Windows Web 開発機能に関する情報は、[Microsoft Edge 開発者ドキュメント](https://docs.microsoft.com/microsoft-edge/)を参照してください。 |
| **Windows Mixed Reality** | Mixed Reality では、現実世界と仮想コンテンツをブレンドして物理的なオブジェクトとデジタルのオブジェクトが共存するエクスペリエンスを生み出します。 Microsoft HoloLens とその他のイマーシブ ヘッドセットのためのアプリの構築に関する情報は、[Windows Mixed Reality に関するドキュメント](https://docs.microsoft.com/en-us/windows/mixed-reality/)を参照してください。|
