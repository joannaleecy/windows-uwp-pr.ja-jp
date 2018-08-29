---
author: daneuber
title: コンポジションの調整
description: UI のカスタマイズ、パフォーマンスを最適化およびユーザーの設定とデバイスの特性に対応するために構成 Api を使用します。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66384c4df3195ae0fff35ae5dd7e1b1983204068
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2919092"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a><span data-ttu-id="328d5-104">適合化の効果と Windows UI を使用しての経験</span><span class="sxs-lookup"><span data-stu-id="328d5-104">Tailoring effects & experiences using Windows UI</span></span>

<span data-ttu-id="328d5-105">Windows UI は、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="328d5-105">Windows UI provides many beautiful effects, animations, and means for differentiation.</span></span> <span data-ttu-id="328d5-106">ただし、パフォーマンスとカスタマイズ機能をユーザーの期待を満たすが成功したアプリケーションを作成するのに必要な部分です。</span><span class="sxs-lookup"><span data-stu-id="328d5-106">However, meeting user expectations for performance and customizability is still a necessary part of creating successful applications.</span></span> <span data-ttu-id="328d5-107">汎用の Windows プラットフォームでは、大規模で多様な一連のさまざまな機能と機能を持つデバイスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="328d5-107">The Universal Windows Platform supports a large, diverse family of devices, which have different features and capabilities.</span></span> <span data-ttu-id="328d5-108">すべてのユーザーに対して、包括的な経験を提供するために複数のデバイス、アプリケーションの規模を確認し、ユーザーの基本設定を尊重する必要があります。</span><span class="sxs-lookup"><span data-stu-id="328d5-108">In order to provide an inclusive experience for all your users, you need to ensure your applications scale across devices and respect user preferences.</span></span> <span data-ttu-id="328d5-109">UI の調整と、デバイスの機能を活用し、快適で包括的なユーザー環境を実現する効率的な方法を提供できます。</span><span class="sxs-lookup"><span data-stu-id="328d5-109">UI tailoring can provide an efficient way to leverage a device’s capabilities and ensure a pleasant and inclusive user experience.</span></span>

<span data-ttu-id="328d5-110">UI の調整は、パフォーマンス、次の領域を基準に美しい UI の作業時間を含むさまざまなカテゴリです。</span><span class="sxs-lookup"><span data-stu-id="328d5-110">UI tailoring is a broad category encompassing work for performant, beautiful UI with respect to the following areas:</span></span>

- <span data-ttu-id="328d5-111">尊重し、効果の設定をユーザーに対応します。</span><span class="sxs-lookup"><span data-stu-id="328d5-111">Respecting and adapting to user settings for effects</span></span>
- <span data-ttu-id="328d5-112">アニメーションのユーザー設定への対応</span><span class="sxs-lookup"><span data-stu-id="328d5-112">Accommodating user settings for animations</span></span>
- <span data-ttu-id="328d5-113">特定のハードウェア機能の UI を最適化します。</span><span class="sxs-lookup"><span data-stu-id="328d5-113">Optimizing UI for the given hardware capabilities</span></span>

<span data-ttu-id="328d5-114">ここで、効果と、上記の領域にビジュアル層を使用してアニメーションを調整する方法を説明しますは、優れたエンド ユーザー エクスペリエンスを確保するようにアプリケーションを調整する他の多くの方法があります。</span><span class="sxs-lookup"><span data-stu-id="328d5-114">Here, we'll cover how to tailor your effects and animations with the Visual Layer in the areas above, but there are many other means to tailor your application to ensure a great end user experience.</span></span> <span data-ttu-id="328d5-115">[UI のカスタマイズ](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)をさまざまなデバイスや[応答性の高い UI を作成](/design/layout/responsive-design.md)する方法のガイダンスのドキュメントを利用できます。</span><span class="sxs-lookup"><span data-stu-id="328d5-115">Guidance docs are available on how to [tailor your UI](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) for various devices and [create responsive UI](/design/layout/responsive-design.md).</span></span>

## <a name="user-effects-settings"></a><span data-ttu-id="328d5-116">ユーザー設定の効果</span><span class="sxs-lookup"><span data-stu-id="328d5-116">User effects settings</span></span>

<span data-ttu-id="328d5-117">ユーザーは、さまざまな理由から、アプリケーションが尊重しに適応する必要があります Windows のエクスペリエンスをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="328d5-117">Users may customize their Windows experience for a variety of reasons, which applications should respect and adapt to.</span></span> <span data-ttu-id="328d5-118">エンド ・ ユーザーを制御できる 1 つの領域は、システム全体で使用するを参照してください効果の種類を変更しています。</span><span class="sxs-lookup"><span data-stu-id="328d5-118">One area end users can control is changing the types of effects they see used throughout their system.</span></span>

### <a name="transparency-effects-settings"></a><span data-ttu-id="328d5-119">透明効果の設定</span><span class="sxs-lookup"><span data-stu-id="328d5-119">Transparency effects settings</span></span>

<span data-ttu-id="328d5-120">ユーザーがカスタマイズできるこのような 1 つのエフェクト設定は、透明効果をオン/オフにすること。</span><span class="sxs-lookup"><span data-stu-id="328d5-120">One such effect setting users can customize is turning transparency effects on/off.</span></span> <span data-ttu-id="328d5-121">これでパーソナル化設定アプリを参照して > 色、またはアプリケーションの設定 > の簡単 > 表示します。</span><span class="sxs-lookup"><span data-stu-id="328d5-121">This can be found in the Settings app under Personalization > Colors, or through Settings app > Ease of Access > Display.</span></span>

![設定で透明度のオプション](images/tailoring-transparency-setting.png)

<span data-ttu-id="328d5-123">オンにすると透明が使用されている任意の効果は期待どおりに表示されます。</span><span class="sxs-lookup"><span data-stu-id="328d5-123">When turned on, any effect that uses transparency will appear as expected.</span></span> <span data-ttu-id="328d5-124">これは、Acrylic、HostBackdropBrush、または完全に不透明ではない任意のカスタム効果グラフに適用されます。</span><span class="sxs-lookup"><span data-stu-id="328d5-124">This applies to Acrylic, HostBackdropBrush, or any custom effect graph that is not fully opaque.</span></span>

<span data-ttu-id="328d5-125">オフに acrylic の材料に自動的に戻さ単色 acrylic ブラシを XAML の既定でこのイベントを調査した結果であるためです。</span><span class="sxs-lookup"><span data-stu-id="328d5-125">When turned off, acrylic material will automatically fall back to a solid color because XAML's acrylic brush has listened to this event by default.</span></span> <span data-ttu-id="328d5-126">ここでは、電卓アプリケーションを適切に比較が純色の透明効果が有効になっていない場合参照してください。</span><span class="sxs-lookup"><span data-stu-id="328d5-126">Here, we see the calculator app appropriately falling back to a solid color when transparency effects are not enabled:</span></span>

![<span data-ttu-id="328d5-127">Acrylic と電卓](images/tailoring-acrylic.png)
![Acrylic の透明度の設定への対応と電卓</span><span class="sxs-lookup"><span data-stu-id="328d5-127">Calculator with Acrylic](images/tailoring-acrylic.png)
![Calculator with Acrylic Responding to Transparency Settings</span></span>](images/tailoring-acrylic-fallback.png)

<span data-ttu-id="328d5-128">ただし、ユーザー設定の効果はすべてのアプリケーションが[UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)のイベントに応答し、効果がなく、透明度を使用する効果と効果のグラフを切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="328d5-128">However, for any custom effects the application needs to respond to the [UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) property or [AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) event and switch out the effect/effect graph to use an effect that has no transparency.</span></span> <span data-ttu-id="328d5-129">この例は、以下です。</span><span class="sxs-lookup"><span data-stu-id="328d5-129">An example of this is below:</span></span>

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool advancedEffects = uisettings.AdvancedEffectsEnabled;
   uisettings.AdvancedEffectsEnabledChanged += Uisettings_AdvancedEffectsEnabledChanged;
}

private void Uisettings_AdvancedEffectsEnabledChanged(UISettings sender, object args)
{
    // TODO respond to sender.AdvancedEffectsEnabled
}
```

## <a name="animations-settings"></a><span data-ttu-id="328d5-130">アニメーションの設定</span><span class="sxs-lookup"><span data-stu-id="328d5-130">Animations settings</span></span>

<span data-ttu-id="328d5-131">同様に、アプリケーションがリッスンし、アニメーションがオンに設定] でユーザー設定に基づいて、無効するかを確認するのには[UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)プロパティに対応する必要があります > アクセスの容易さ > 表示します。</span><span class="sxs-lookup"><span data-stu-id="328d5-131">Similarly, applications should listen and respond to the [UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled) property to ensure animations are turned on or off based on user settings in Settings > Ease of Access > Display.</span></span>

![アニメーション オプションの設定](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a><span data-ttu-id="328d5-133">API の機能を活用します。</span><span class="sxs-lookup"><span data-stu-id="328d5-133">Leveraging the capabilities API</span></span>

<span data-ttu-id="328d5-134">[CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api を活用するには、どの構成機能が利用可能とパフォーマンスの高い特定のハードウェアを検出し、エンド ・ ユーザーの任意のデバイス、パフォーマンスと美しい経験を取得することを確認するのにはデザインを調整できます。</span><span class="sxs-lookup"><span data-stu-id="328d5-134">By leveraging the [CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) APIs, you can detect which composition features are available and performant on given hardware and tailor the design to ensure end users get a performant and beautiful experience on any device.</span></span> <span data-ttu-id="328d5-135">Api では、さまざまなフォーム ファクターで拡大・縮小、正常な効果を実装するためにシステム ・ ハードウェアの機能を確認する手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="328d5-135">The APIs provide a means to check hardware system capabilities in order to implement graceful effect scaling across a variety of form factors.</span></span> <span data-ttu-id="328d5-136">これにより、簡単に美しいを作成するアプリケーションとのシームレスなエンド ユーザー エクスペリエンスを適切に調整します。</span><span class="sxs-lookup"><span data-stu-id="328d5-136">This makes it easy to appropriately tailor the application to create a beautiful and seamless end user experience.</span></span>

<span data-ttu-id="328d5-137">この API は、メソッド、およびアプリケーションの UI の意思決定を拡大/縮小効果を作成するのに使用できるイベントのリスナーを提供します。</span><span class="sxs-lookup"><span data-stu-id="328d5-137">This API provides methods and an event listener that can be used to make effect scaling decisions for the application UI.</span></span> <span data-ttu-id="328d5-138">機能では、システムが複雑なコンポジションとレンダリング操作を処理する方法もを検出し、消費を簡単にモデルを利用する開発者のための情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="328d5-138">The feature detects how well the system can handle complex composition and rendering operations and then returns the information in an easy-to-consume model for developers to utilize.</span></span>

### <a name="using-composition-capabilities"></a><span data-ttu-id="328d5-139">コンポジション機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="328d5-139">Using composition capabilities</span></span>

<span data-ttu-id="328d5-140">CompositionCapabilities 機能を活用して、Acrylic 材料、位置、材料にフォールバック シナリオおよびハードウェアによって、複数の高性能な効果などの機能が既にされています。</span><span class="sxs-lookup"><span data-stu-id="328d5-140">The CompositionCapabilities functionality is already being leveraged for features like Acrylic material, where the material falls back to a more performant effect depending on the scenario and hardware.</span></span>

<span data-ttu-id="328d5-141">API は、いくつかの簡単な手順で既存のコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="328d5-141">The API can be added to existing code in a few easy steps.</span></span>

1. <span data-ttu-id="328d5-142">アプリケーションのコンス トラクター内の機能のオブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="328d5-142">Acquire the capabilities object in your application’s constructor.</span></span>

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. <span data-ttu-id="328d5-143">アプリの機能変更イベントのリスナーを登録します。</span><span class="sxs-lookup"><span data-stu-id="328d5-143">Register a capabilities changed event listener for your app.</span></span>

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. <span data-ttu-id="328d5-144">コンテンツをさまざまな機能レベルを処理するイベントのコールバック メソッドに追加します。</span><span class="sxs-lookup"><span data-stu-id="328d5-144">Add content to the event callback method to handle various capabilities levels.</span></span> <span data-ttu-id="328d5-145">これは、次の手順を以下のようなことができない場合があります。</span><span class="sxs-lookup"><span data-stu-id="328d5-145">This may or may not be similar to the next step below.</span></span>
1. <span data-ttu-id="328d5-146">効果を使用している場合は、まず機能オブジェクトを確認します。</span><span class="sxs-lookup"><span data-stu-id="328d5-146">When using effects, check the capabilities object first.</span></span> <span data-ttu-id="328d5-147">条件チェックの使用を検討するか、または効果を調整する方法に応じて、制御ステートメントを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="328d5-147">Consider using conditional checks or switch control statements, depending on how you want to tailor the effects.</span></span>

    ```cs
    if (_capabilities.AreEffectsSupported())
    {
        // Add incremental effects updates here

        if (_capabilities.AreEffectsFast())
        {
            // Add more advanced effects here where applicable
        }
    }
    ```

<span data-ttu-id="328d5-148">[Windows UI Github リポジトリの索引](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)に完全な例のコードをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="328d5-148">Full example code can be found on the [Windows UI Github repo](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities).</span></span>

## <a name="fast-vs-slow-effects"></a><span data-ttu-id="328d5-149">高速低速の効果との比較</span><span class="sxs-lookup"><span data-stu-id="328d5-149">Fast vs. slow effects</span></span>

<span data-ttu-id="328d5-150">CompositionCapabilties API で提供されている[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)および[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast)メソッドからのフィードバックに基づき、アプリケーションことができます高価なまたはサポートされていない効果をスワップとして最適化されている任意の他の効果デバイスです。</span><span class="sxs-lookup"><span data-stu-id="328d5-150">Based on feedback from the provided [AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported) and [AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast) methods in the CompositionCapabilties API, the application can decide to swap expensive or unsupported effects for other effects of their choice that are optimized for the device.</span></span> <span data-ttu-id="328d5-151">いくつかの効果として知られて一貫して他のユーザーよりもリ スを使用しにのみ使用する必要があり、その他の効果をより自由に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="328d5-151">Some effects are known to consistently be more resource intensive than others and should be used sparingly, and other effects can be used more freely.</span></span> <span data-ttu-id="328d5-152">すべてのエフェクトでは、ただし、注意するようにして効果のグラフのパフォーマンス特性を変更する場合がありますチェーンといくつかのシナリオの組み合わせとアニメーション化するとき。</span><span class="sxs-lookup"><span data-stu-id="328d5-152">For all effects, however, care should be used when chaining and animating as some scenarios or combinations may change the performance characteristics of the effect graph.</span></span> <span data-ttu-id="328d5-153">次には、個々 のエフェクトのいくつかの経験則のパフォーマンス特性を示します。</span><span class="sxs-lookup"><span data-stu-id="328d5-153">Below are some rule of thumb performance characteristics for individual effects:</span></span>

- <span data-ttu-id="328d5-154">効果の高いパフォーマンスへの影響があることがわかっているとおりです: ブラー (ガウス)、シャドウ マスク、BackDropBrush、HostBackDropBrush、およびレイヤーの視覚的です。</span><span class="sxs-lookup"><span data-stu-id="328d5-154">Effects that are known to have high performance impact are as follows – Gaussian Blur, Shadow Mask, BackDropBrush, HostBackDropBrush, and Layer Visual.</span></span> <span data-ttu-id="328d5-155">これらは、ローエンドのデバイス[(フィーチャー レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)では、お勧めしません、ハイ ・ エンド ・ デバイスで慎重に使用してください。</span><span class="sxs-lookup"><span data-stu-id="328d5-155">These are not recommended for low end devices [(feature level 9.1-9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx), and should be used judiciously on high end devices.</span></span>
- <span data-ttu-id="328d5-156">中程度のパフォーマンスへの影響、効果にカラー マトリックスでは、(明るさ、色、彩度および色相)、特定のブレンド効果 BlendModes は、スポット ライト、SceneLightingEffect、および (場合によって異なる) BorderEffect。</span><span class="sxs-lookup"><span data-stu-id="328d5-156">Effects with medium performance impact include Color Matrix, certain Blend Effect BlendModes (Luminosity, Color, Saturation, and Hue), SpotLight, SceneLightingEffect, and (depending on scenario) BorderEffect.</span></span> <span data-ttu-id="328d5-157">これらの効果は、ローエンドのデバイスでは、特定のシナリオで動作可能性がありますが、チェーンと、アニメーション化するときに、注意を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="328d5-157">These effects may work with certain scenarios on low end devices, but care should be used when chaining and animating.</span></span> <span data-ttu-id="328d5-158">2 つまたはそれ以下の使用を制限して、遷移のみをアニメーション化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="328d5-158">Recommend restricting use to two or less and animating on transitions only.</span></span>
- <span data-ttu-id="328d5-159">その他のすべての効果は低パフォーマンスへの影響があるし、をアニメートすると、チェーンのすべての適切なシナリオでの作業します。</span><span class="sxs-lookup"><span data-stu-id="328d5-159">All other effects have low performance impact and work in all reasonable scenarios when animating and chaining.</span></span>

## <a name="related-articles"></a><span data-ttu-id="328d5-160">関連記事</span><span class="sxs-lookup"><span data-stu-id="328d5-160">Related articles</span></span>

- [<span data-ttu-id="328d5-161">UWP の応答性の高い設計手法</span><span class="sxs-lookup"><span data-stu-id="328d5-161">UWP Responsive Design Techniques</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [<span data-ttu-id="328d5-162">UWP デバイスの調整</span><span class="sxs-lookup"><span data-stu-id="328d5-162">UWP Device Tailoring</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
