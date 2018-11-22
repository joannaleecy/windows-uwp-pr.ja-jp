---
author: jwmsft
title: 入力駆動型アニメーション
description: アプリの UI で入力アニメーションを使用する方法について説明します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 04eabb4c70143a08f5b850e6444f7f3d21a9dd4a
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7576596"
---
# <a name="input-driven-animations"></a>入力駆動型アニメーション

この記事では、InputAnimation API について簡単に説明し、UI でこれらの種類のアニメーションを使用するための推奨方法を紹介します。

## <a name="prerequisites"></a>前提条件

ここでは、以下の記事で説明されている概念を理解していることを前提とします。

- [関係ベース アニメーション](relation-animations.md)

## <a name="smooth-motion-driven-from-user-interactions"></a>ユーザーの操作で駆動するスムーズなモーション

Fluent Design 言語では、エンド ユーザーとアプリの間で行われる操作は最も重要なことです。 アプリは操作の一部に注目していればよいわけではありません。アプリを操作するユーザーに対して、自然で動的な反応をする必要があります。 つまり、指が画面上に置かれた場合、UI は入力の変更の程度に応じて適切に対応する必要があります。スクロールはスムーズに実行し、画面をパンする指を追跡する必要があります。

ユーザー入力に対して動的で滑らかな反応を構築することで、ユーザー エンゲージメントを向上させることができます。現代では、モーションは見栄えが良いだけでなく、ユーザーがさまざまな UI エクスペリエンスを操作する場合に、自然で適切な操作感を実現することが求められます。 これにより、エンド ユーザーはアプリケーションを簡単に利用できるようになり、エクスペリエンスはより覚えやすく魅力的なものになります。

## <a name="expanding-past-just-touch"></a>従来のタッチ操作からの拡張

タッチは、エンド ユーザーが UI コンテンツを操作する際に利用する一般的なインターフェイスの 1 つですが、マウスやペンなど他のさまざまな入力方式も使用されます。 こうした状況では、使用される入力方式に関係なく、UI が入力に対して動的に反応することをエンド ユーザーが認識できるようにすることが重要となります。 入力駆動型のモーション エクスペリエンスを設計する場合は、さまざまな入力方式を理解している必要があります。

## <a name="different-input-driven-motion-experiences"></a>さまざまな入力駆動型のモーション エクスペリエンス

InputAnimation 領域によって、動的な反応を示すモーションを作成するためさまざまなエクスペリエンスが提供されます。 他の Windows UI アニメーション システムと同様に、これらの入力駆動型アニメーションは、動的なモーション エクスペリエンスの作成に役立つ独立したスレッド上で動作します。 ただし、エクスペリエンスが既存の XAML コントロールとコンポーネントを利用する場合は、それらのエクスペリエンスの構成要素が UI スレッドによって制約を受けます。

動的な入力駆動型のモーションを示すアニメーションを構築するときに作成する、3 つの主要なエクスペリエンスがあります。

1. 既存の ScrollView を強化したエクスペリエンス – XAML ScrollViewer の位置によって動的なアニメーション エクスペリエンスを駆動できるようにします。
1. ポインターの位置で駆動するエクスペリエンス – ヒット テストが行われた UIElement 上のカーソル位置を利用して、動的なアニメーション エクスペリエンスを駆動します。
1. InteractionTracker を使用したカスタム操作エクスペリエンス – InteractionTracker を使用して、完全にカスタマイズされた、オフスレッドの操作エクスペリエンスを作成します (スクロールやズームが可能なキャンバスなど)。

## <a name="enhancing-existing-scrollviewer-experiences"></a>既存の ScrollViewer を強化したエクスペリエンス

より動的なエクスペリエンスを作成するための一般的な方法の 1 つとして、既存の XAML ScrollViewer コントロールの最上位に構築する方法があります。 このような方法では、ScrollViewer のスクロール位置を利用して、単純なスクロール エクスペリエンスをより動的なものにする追加の UI コンポーネントを作成します。 これらのエクスペリエンスの例として、固定ヘッダー/シャイ ヘッダー、視差などがあります。

![視差を利用したリスト ビュー](images/animation/parallax.gif)

![シャイ ヘッダー](images/animation/shy-header.gif)

このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。

1. アニメーションを駆動する XAML ScrollViewer から ScrollManipulationPropertySet にアクセスします。
    - ElementCompositionPreview.GetScrollViewerManipulationPropertySet(UIElement 要素) API を使用してアクセスします
    - **Translation** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます
1. Translation プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。
1. CompositionObject のプロパティでアニメーションを開始します。

これらのエクスペリエンスの作成方法について詳しくは、「[既存の ScrollViewer エクスペリエンスを強化する](scroll-input-animations.md)」をご覧ください。

## <a name="pointer-position-driven-experiences"></a>ポインターの位置で駆動するエクスペリエンス

よく利用される動的なエクスペリエンスの 1 つです。入力を使用し、マウス カーソルなどのポインターの位置に基づいてアニメーションを駆動します。 このようなエクスペリエンスでは、開発者は、スポットライト表示のようなエクスペリエンスの作成を可能にする XAML UIElement でヒット テストが行われたときのカーソルの位置を利用します。

![ポインター スポットライトの例](images/animation/spotlight-reveal.gif)

![ポインターに基づく回転の例](images/animation/pointer-rotate.gif)

このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。

1. ヒット テストが行われたときにカーソルの位置を把握するための XAML UIElement から PointerPositionPropertySet にアクセスします。
    - ElementCompositionPreview.GetPointerPositionPropertySet(UIElement 要素) API を使用してアクセスします
    - **Position** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます
1. Position プロパティを参照する式を使用して、CompositionExpressionAnimation を作成します。
1. CompositionObject のプロパティでアニメーションを開始します。

## <a name="custom-manipulation-experiences-with-interactiontracker"></a>InteractionTracker を使用したカスタム操作エクスペリエンス

XAML ScrollViewer を利用する際の問題の 1 つは、UI スレッドによって制約を受けるということです。 そのため、UI スレッドがビジー状態になると、スクロールやズームのエクスペリエンスで遅延やジッターが発生する場合があり、その結果、ユーザーの興味を引かないエクスペリエンスとなってしまう可能性があります。 また、ScrollViewer エクスペリエンスの多くの側面はカスタマイズすることができません。 InteractionTracker は、これらの問題を解決するために作成されました。そのために、独立したスレッド上で実行されるカスタム操作エクスペリエンスを作成するための構成要素のセットが提供されます。

![3D 操作の例](images/animation/interactions-3d.gif)

![引き出されるようなアニメーション化の例](images/animation/pull-to-animate.gif)

InteractionTracker を使用してエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。

1. InteractionTracker オブジェクトを作成し、そのプロパティを定義します。
1. InteractionTracker で使用される入力をキャプチャする CompositionVisual 用の VisualInteractionSources を作成します。
1. InteractionTracker の Position プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。
1. InteractionTracker で駆動される、Composition の Visual のプロパティでアニメーションを開始します。
