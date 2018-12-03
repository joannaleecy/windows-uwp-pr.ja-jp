---
title: 自然な動作のアニメーション
description: 自然な動作のアニメーション、およびそれらをアプリの UI で使用する方法について説明します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10、UWP、アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 7fde0cbf5335b4f5c3da2f21f692fc2c23455776
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8458882"
---
# <a name="natural-motion-animations"></a>自然な動作のアニメーション

この記事では、NaturalMotionAnimation 領域の概要ついて説明します。また、こうした種類のアニメーションを UI で使用する場合、概念的にどのように考えたらよいかについても説明します。

## <a name="making-motion-feel-familiar-and-natural"></a>見慣れた自然なモーションの作成

優れたアプリとは、ユーザーの興味を引き付けて離さないような操作感を実現し、作業の際にユーザーをガイドできるアプリです。 モーションは、ユーザー インターフェイスをユーザー エクスペリエンスと区別する重要な差別化要因です。モーションによって、ユーザーとユーザーが操作するアプリケーションとの関係が導き出されます。 この関係が適切であれば、エンド ユーザーのエンゲージメントと満足度を高めることができます。

モーションを利用してこの関係を構築するための 1 つの方法として、ユーザーにとって親しみやすい外観を提供するエクスペリエンスの作成があります。 ユーザーは、モーションが実生活での経験にどの程度基づいているかということを無意識に想定しています。 物体が床を横切って移動する動作、テーブルから落ちる動作、物体同士が跳ね返る動作、ばねによる振動などは、多くの人が理解し、想定できる動作です。 実際の物理法則に基づいて、こうした動作の想定を活用するモーションは、目で見たときに自然な感じがします。 モーションはより自然で対話的になりますが、さらに重要なことは、エクスペリエンス全体が覚えやすく、魅力的になるということです。

![アニメーションを使用しない拡大/縮小モーション](images/animation/scale-no-animation.gif)
![3 次ベジエを使用した拡大/縮小モーション](images/animation/scale-cubic-bezier.gif)
![ばねアニメーションを使用した拡大/縮小モーション](images/animation/scale-spring.gif)

最終的には、アプリに対するユーザー エンゲージメントとユーザーの維持率が高まります。

## <a name="balancing-control-and-dynamism"></a>制御とダイナミズムのバランス

従来の UI では、[KeyFrameAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.keyframeanimation) がモーションを記述するための主要な方法となっています。 KeyFrame を使用すると、設計者や開発者は、開始、終了、補間の定義を完全に制御することができます。 多くの場合、KeyFrame は非常に便利な方法ですが、KeyFrame アニメーションは動的な表現が弱いアニメーションです。また、モーションはアダプティブではなく、どのような状況でも同じように見えてしまいます。

これとは対照的に、ゲームや物理エンジンでよく見られるシミュレーションがあります。 多くの場合、これらのエクスペリエンスでは、ユーザーが操作するときに非常にリアルで動きのある表現が実現されます。ユーザーが現実世界で感じる雰囲気や偶然性の感覚が作り出されるのです。 モーションはよりアクティブで動的なものとなりますが、設計者や開発者は制御できる要素が少なくなり、従来の UI に統合するのが難しくなります。

![制御の程度を示す図](images/animation/natural-motion-diagram.png)

[NaturalMotionAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.naturalmotionanimation) は、このギャップを橋渡しすることができます。アニメーションの重要な要素 (開始/終了など) に対する制御のバランスを取りながら、自然で動的な表現を実現するモーションを維持することができます。

> [!NOTE]
> NaturalMotionAnimations は KeyFrame アニメーションに置き換わるものではありません。Fluent Design 言語では、KeyFrame が推奨される状況がまだあります。 NaturalMotionAnimations は、モーションは必要であるが、KeyFrame アニメーションでは動的な表現をするのに十分ではない場合に使用されることを目的としています。

## <a name="using-naturalmotionanimations"></a>NaturalMotionAnimations の使用

Fall Creators Update 以降、新しいモーション エクスペリエンスである "**ばねアニメーション**" にアクセスできます。 ばねのモーションに関する詳しいチュートリアルについては、「[ばねアニメーション](spring-animations.md)」をご覧ください。

このモーションの種類は、新しい NaturalMotionAnimation を使用して実行できます。 NaturalMotionAnimation は新しい種類のアニメーションで、制御とダイナミズムのバランスを取りながら、開発者が見慣れた自然なモーションを UI に組み込むことができるようにすることを重視しています。 次のような機能を備えています。

- 開始と終了の値を定義する。
- InitialVelocity を定義し、InteractionTracker を使用して入力に関連付ける。
- モーション固有のプロパティ (ばね用の DampingRatio など) を定義する。

最初に作成する一般的な式:

1. **Create** メソッドのいずれかを使用して、Compositor から NaturalMotionAnimation します。
1. アニメーションのプロパティを定義します。
1. NaturalMotionAnimation を、パラメーターとして CompositionObject からの StartAnimation 呼び出しに渡します。
    - または、InteractionTracker の InertiaModifier が持つ Motion プロパティに設定します。

ばねの NaturalMotionAnimation を使用して、新しい X オフセットの場所に "ばね" のモーションを表示する基本的な例を次に示します。

```csharp
_springAnimation = _compositor.CreateSpringScalarAnimation();
_springAnimation.Period = TimeSpan.FromSeconds(0.07);
_springAnimation.DelayTime = TimeSpan.FromSeconds(1);
_springAnimation.EndPoint = 500f;
sectionNav.StartAnimation("Offset.X", _springAnimation);
```
