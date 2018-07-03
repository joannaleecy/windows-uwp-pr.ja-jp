---
author: normesta
description: このガイドは、WPF および Windows フォーム アプリケーションで直接 Fluent ベースの UWP UI を作成するのに役立ちます。
title: WPF および Windows フォーム アプリケーションで UWP コントロールをホストする
ms.author: normesta
ms.date: 05/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp, windows forms, wpf
keywords: windows 10, uwp, windows, フォーム, wpf
ms.localizationpriority: medium
ms.openlocfilehash: 4823654bce3373ace5b04ced8ec14c4b6c1b6f1d
ms.sourcegitcommit: 3500825bc2e5698394a8b1d2efece7f071f296c1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/09/2018
ms.locfileid: "1862071"
---
# <a name="host-uwp-controls-in-wpf-and-windows-forms-applications"></a>WPF および Windows フォーム アプリケーションで UWP コントロールをホストする

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

Fluent Design 機能を使用して既存の WPF または Windows アプリケーションの外観や機能を高めることができるように、UWP コントロールをデスクトップに追加しています。 これには 2 つの方法があります。

まず、コントロールを直接 WPF または Windows フォーム プロジェクトのデザイン サーフェイスに追加し、それをデザイナーの他のコントロールと同様に使用することができます。  新しい **WebView** コントロールで今すぐこれをお試しください。 このコントロールは、Microsoft Edge レンダリング エンジンを使用しています。また、これまで、このコントロールは UWP アプリケーションでのみ利用可能でした。 [Windows コミュニティ ツールキット](https://docs.microsoft.com/windows/uwpcommunitytoolkit/) の最新リリースで **WebView** を参照できます。

間もなく、Fluent Design のその他の機能にアクセスできます。さまざまな UWP コントロールをホストできるコントロールを提供する予定です。 Windows コミュニティ ツールキットの今後のリリースでこのコントロールとその他の多くのコントロールを確認してください。

これらのコントロールがアーキテクチャ的に編成されるしくみの概要を次に示します。 この図で使用される名前は変更されることがあります。  

![ホスト コントロール アーキテクチャ](images/host-controls.png)

この図の下部に表示されている API は、Windows SDK に付属しています。  デザイナーに追加するコントロールは、Windows コミュニティ ツールキットで Nuget パッケージとしてリリースされます。

これらの新しいコントロールには制限事項があるため、それらを使用する前に、まだサポートされていない機能、また回避策を使用してのみ動作する機能を少し時間を取って確認してください。

### <a name="whats-supported"></a>サポートされている内容

ほとんどの場合、次の一覧で明示されていない限り、すべてがサポートされます。

### <a name="whats-supported-only-with-workarounds"></a>回避策を使用した場合にのみサポートされている内容

:heavy_check_mark: 複数のウィンドウの内部での複数のインボックス コントロールのホスティング。 独自のスレッドに各ウィンドウを配置する必要があります。

:heavy_check_mark: ホストされたコントロールでの ``x:Bind`` の使用。 .NET Standard ライブラリ内でデータ モデルを宣言する必要があります。

:heavy_check_mark: C# ベースのサードパーティのコントロール。 サードパーティのコントロールへのソース コードがある場合は、それに対してコンパイルできます。

### <a name="whats-not-yet-supported"></a>まだサポートされていない内容

:no_entry_sign: アプリケーションおよびホストされたコントロールでシームレスに動作するアクセシビリティ ツール。

:no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーションに追加するコントロール内のローカライズされたコンテンツ。

: no_entry_sign: Windows アプリ パッケージが含まれていないアプリケーション内で XAML で行われたアセット参照。

:no_entry_sign:  DPI と倍率の変更に適切に対応するコントロール。

:no_entry_sign: カスタム ユーザー コントロールへの **WebView** コントロールの追加 (スレッド上、オフ スレッド、proc 外のいずれか)

:no_entry_sign: [表示ハイライト](https://docs.microsoft.com/windows/uwp/design/style/reveal)  の Fluent 効果。

:no_entry_sign: 入力コントロールのためのインライン インク、@Places
、@People。

:no_entry_sign: ショートカット キーの割り当て。

:no_entry_sign: C++ ベースのサードパーティのコントロール。

:no_entry_sign: カスタム ユーザー コントロールのホスティング。

Fluent をデスクトップに導入するエクスペリエンスの向上を続けていくうえで、この一覧の項目は変更される可能性があります。  
