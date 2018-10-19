---
author: daneuber
title: コンポジションの調整
description: UI を調整する、パフォーマンスを最適化して、ユーザー設定とデバイスの特性を調整するには、コンポジション Api を使用します。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 66384c4df3195ae0fff35ae5dd7e1b1983204068
ms.sourcegitcommit: 310a4555fedd4246188a98b31f6c094abb33ec60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5130459"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a><span data-ttu-id="3ef68-104">効果と Windows UI を使用して、エクスペリエンスを調整します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-104">Tailoring effects & experiences using Windows UI</span></span>

<span data-ttu-id="3ef68-105">Windows UI では、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-105">Windows UI provides many beautiful effects, animations, and means for differentiation.</span></span> <span data-ttu-id="3ef68-106">ただし、パフォーマンスとカスタマイズのユーザーの期待を会議が成功したアプリケーションを作成するのに必要な部分です。</span><span class="sxs-lookup"><span data-stu-id="3ef68-106">However, meeting user expectations for performance and customizability is still a necessary part of creating successful applications.</span></span> <span data-ttu-id="3ef68-107">ユニバーサル Windows プラットフォームには、大規模なさまざまなデバイス ファミリのさまざまな機能や機能がサポートしています。</span><span class="sxs-lookup"><span data-stu-id="3ef68-107">The Universal Windows Platform supports a large, diverse family of devices, which have different features and capabilities.</span></span> <span data-ttu-id="3ef68-108">すべてのユーザーの包括的なエクスペリエンスを実現するためには、デバイス間で、アプリケーションのスケールをことを確認し、ユーザーの優先順位を考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-108">In order to provide an inclusive experience for all your users, you need to ensure your applications scale across devices and respect user preferences.</span></span> <span data-ttu-id="3ef68-109">UI の調整と、デバイスの機能を活用し、快適で包括的なユーザー エクスペリエンスを確保する効率的な方法を提供できます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-109">UI tailoring can provide an efficient way to leverage a device’s capabilities and ensure a pleasant and inclusive user experience.</span></span>

<span data-ttu-id="3ef68-110">パフォーマンスと、以下の点に関して美しい UI の作業を含むさまざまなカテゴリは、UI を調整します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-110">UI tailoring is a broad category encompassing work for performant, beautiful UI with respect to the following areas:</span></span>

- <span data-ttu-id="3ef68-111">尊重し、効果のユーザーの設定への対応</span><span class="sxs-lookup"><span data-stu-id="3ef68-111">Respecting and adapting to user settings for effects</span></span>
- <span data-ttu-id="3ef68-112">アニメーションのユーザーの設定への対応</span><span class="sxs-lookup"><span data-stu-id="3ef68-112">Accommodating user settings for animations</span></span>
- <span data-ttu-id="3ef68-113">特定のハードウェア機能の UI の最適化</span><span class="sxs-lookup"><span data-stu-id="3ef68-113">Optimizing UI for the given hardware capabilities</span></span>

<span data-ttu-id="3ef68-114">ここでは、上記の領域でビジュアル レイヤーのアニメーション、効果を調整する方法を説明しますが、優れたエンド ユーザー エクスペリエンスを確実にアプリケーションを調整するその他の多くの方法があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-114">Here, we'll cover how to tailor your effects and animations with the Visual Layer in the areas above, but there are many other means to tailor your application to ensure a great end user experience.</span></span> <span data-ttu-id="3ef68-115">さまざまなデバイスと[応答性の高い UI を作成](/design/layout/responsive-design.md)する[UI を調整](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)する方法に関するガイダンス ドキュメントを利用できます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-115">Guidance docs are available on how to [tailor your UI](/design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) for various devices and [create responsive UI](/design/layout/responsive-design.md).</span></span>

## <a name="user-effects-settings"></a><span data-ttu-id="3ef68-116">ユーザーの効果の設定</span><span class="sxs-lookup"><span data-stu-id="3ef68-116">User effects settings</span></span>

<span data-ttu-id="3ef68-117">ユーザーは、さまざまな理由から、アプリケーションが尊重し、対応する必要があります Windows エクスペリエンスをカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-117">Users may customize their Windows experience for a variety of reasons, which applications should respect and adapt to.</span></span> <span data-ttu-id="3ef68-118">1 つの領域をエンドユーザーが制御できますが、システム全体で使用される、表示効果の種類を変更します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-118">One area end users can control is changing the types of effects they see used throughout their system.</span></span>

### <a name="transparency-effects-settings"></a><span data-ttu-id="3ef68-119">透明効果の設定</span><span class="sxs-lookup"><span data-stu-id="3ef68-119">Transparency effects settings</span></span>

<span data-ttu-id="3ef68-120">ユーザーがカスタマイズできるこのような効果設定を 1 つは、透明効果をオン/オフにするとします。</span><span class="sxs-lookup"><span data-stu-id="3ef68-120">One such effect setting users can customize is turning transparency effects on/off.</span></span> <span data-ttu-id="3ef68-121">これは、[パーソナル設定] の下の設定アプリで見つけることができます > 色、または設定アプリ経由 > 簡単 > 表示します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-121">This can be found in the Settings app under Personalization > Colors, or through Settings app > Ease of Access > Display.</span></span>

![設定で透明度オプション](images/tailoring-transparency-setting.png)

<span data-ttu-id="3ef68-123">オンにすると、透明度を使用する任意の効果は、期待どおりに表示されます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-123">When turned on, any effect that uses transparency will appear as expected.</span></span> <span data-ttu-id="3ef68-124">これは、アクリル、HostBackdropBrush、または完全に不透明なではない任意のカスタム効果グラフに適用されます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-124">This applies to Acrylic, HostBackdropBrush, or any custom effect graph that is not fully opaque.</span></span>

<span data-ttu-id="3ef68-125">無効にアクリル素材は自動的にフォールバック単色を XAML のアクリル ブラシは、既定ではこのイベントをリッスンがあるためです。</span><span class="sxs-lookup"><span data-stu-id="3ef68-125">When turned off, acrylic material will automatically fall back to a solid color because XAML's acrylic brush has listened to this event by default.</span></span> <span data-ttu-id="3ef68-126">ここでは、適切にフォールバックする単色透明効果が有効になっていない電卓アプリを表示します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-126">Here, we see the calculator app appropriately falling back to a solid color when transparency effects are not enabled:</span></span>

![<span data-ttu-id="3ef68-127">アクリルを使用した電卓](images/tailoring-acrylic.png)
![透明度の設定への応答アクリルを使用した電卓</span><span class="sxs-lookup"><span data-stu-id="3ef68-127">Calculator with Acrylic](images/tailoring-acrylic.png)
![Calculator with Acrylic Responding to Transparency Settings</span></span>](images/tailoring-acrylic-fallback.png)

<span data-ttu-id="3ef68-128">ただし、すべてのカスタム効果のアプリケーションが[UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)イベントに応答し、透明度を持たない特殊効果を使う効果/効果グラフを切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-128">However, for any custom effects the application needs to respond to the [UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) property or [AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) event and switch out the effect/effect graph to use an effect that has no transparency.</span></span> <span data-ttu-id="3ef68-129">この例では、以下です。</span><span class="sxs-lookup"><span data-stu-id="3ef68-129">An example of this is below:</span></span>

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

## <a name="animations-settings"></a><span data-ttu-id="3ef68-130">アニメーションの設定</span><span class="sxs-lookup"><span data-stu-id="3ef68-130">Animations settings</span></span>

<span data-ttu-id="3ef68-131">同様に、アプリケーションがリッスンし、アニメーションがオンまたはオフの設定でユーザーの設定に基づくことを確認する[UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)プロパティに応答する必要があります > 簡単 > 表示します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-131">Similarly, applications should listen and respond to the [UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled) property to ensure animations are turned on or off based on user settings in Settings > Ease of Access > Display.</span></span>

![設定オプションのアニメーション](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a><span data-ttu-id="3ef68-133">API の機能を活用します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-133">Leveraging the capabilities API</span></span>

<span data-ttu-id="3ef68-134">[CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api を利用して、どのコンポジション機能利用可能なとパフォーマンスの高いで特定のハードウェアを検出し、エンドユーザーが任意のデバイスで、パフォーマンスに優れたと美しいエクスペリエンスを取得することを確認する設計を調整できます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-134">By leveraging the [CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) APIs, you can detect which composition features are available and performant on given hardware and tailor the design to ensure end users get a performant and beautiful experience on any device.</span></span> <span data-ttu-id="3ef68-135">Api は、さまざまなフォーム ファクターでスケーリング正常な効果を実装するためにハードウェア システム機能を確認する手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-135">The APIs provide a means to check hardware system capabilities in order to implement graceful effect scaling across a variety of form factors.</span></span> <span data-ttu-id="3ef68-136">これにより、美しいを作成するアプリケーションとシームレスなエンド ユーザー エクスペリエンスを適切に調整するのには簡単です。</span><span class="sxs-lookup"><span data-stu-id="3ef68-136">This makes it easy to appropriately tailor the application to create a beautiful and seamless end user experience.</span></span>

<span data-ttu-id="3ef68-137">この API には、メソッドに効果をアプリケーションの UI に意思決定をスケーリング使用できるイベント リスナーが用意されています。</span><span class="sxs-lookup"><span data-stu-id="3ef68-137">This API provides methods and an event listener that can be used to make effect scaling decisions for the application UI.</span></span> <span data-ttu-id="3ef68-138">機能は、システムが複雑なコンポジションとレンダリング操作を処理する方法もを検出し、開発者を利用するため、消費する簡単なモデルでは、情報を返します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-138">The feature detects how well the system can handle complex composition and rendering operations and then returns the information in an easy-to-consume model for developers to utilize.</span></span>

### <a name="using-composition-capabilities"></a><span data-ttu-id="3ef68-139">コンポジションの機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-139">Using composition capabilities</span></span>

<span data-ttu-id="3ef68-140">CompositionCapabilities 機能を活用して、アクリル素材、場所、素材にフォールバック シナリオとハードウェアによって複数のパフォーマンスに優れた効果などの機能が既にされています。</span><span class="sxs-lookup"><span data-stu-id="3ef68-140">The CompositionCapabilities functionality is already being leveraged for features like Acrylic material, where the material falls back to a more performant effect depending on the scenario and hardware.</span></span>

<span data-ttu-id="3ef68-141">API は、いくつかの簡単な手順の既存のコードを追加できます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-141">The API can be added to existing code in a few easy steps.</span></span>

1. <span data-ttu-id="3ef68-142">アプリケーションのコンス トラクターで capabilities オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-142">Acquire the capabilities object in your application’s constructor.</span></span>

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. <span data-ttu-id="3ef68-143">アプリの機能の変更イベント リスナーを登録します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-143">Register a capabilities changed event listener for your app.</span></span>

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. <span data-ttu-id="3ef68-144">さまざまな機能レベルを処理するイベントのコールバック メソッドにコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-144">Add content to the event callback method to handle various capabilities levels.</span></span> <span data-ttu-id="3ef68-145">これは、次の手順を次のようなことができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-145">This may or may not be similar to the next step below.</span></span>
1. <span data-ttu-id="3ef68-146">効果を使用する場合は、まず capabilities オブジェクトを確認します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-146">When using effects, check the capabilities object first.</span></span> <span data-ttu-id="3ef68-147">条件チェックを使うことを検討するか、効果を調整する方法に応じて、コントロールのステートメントを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-147">Consider using conditional checks or switch control statements, depending on how you want to tailor the effects.</span></span>

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

<span data-ttu-id="3ef68-148">完全な例のコードは、 [Windows UI の Github リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)で確認できます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-148">Full example code can be found on the [Windows UI Github repo](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities).</span></span>

## <a name="fast-vs-slow-effects"></a><span data-ttu-id="3ef68-149">高速低速な効果との比較</span><span class="sxs-lookup"><span data-stu-id="3ef68-149">Fast vs. slow effects</span></span>

<span data-ttu-id="3ef68-150">CompositionCapabilties API で提供されている[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)と[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast)メソッドからのフィードバックに基づいて、最適化された任意の他の効果のコストやサポートされていない効果を交換するアプリケーションを決定できます。デバイス。</span><span class="sxs-lookup"><span data-stu-id="3ef68-150">Based on feedback from the provided [AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported) and [AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast) methods in the CompositionCapabilties API, the application can decide to swap expensive or unsupported effects for other effects of their choice that are optimized for the device.</span></span> <span data-ttu-id="3ef68-151">一部の効果他と比べてリソース負荷の高いを一貫することがわかって多用する必要がありますおよびその他の効果を自由に使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3ef68-151">Some effects are known to consistently be more resource intensive than others and should be used sparingly, and other effects can be used more freely.</span></span> <span data-ttu-id="3ef68-152">すべてのエフェクトのただし、注意するようにしてチェーンと一部のシナリオやの組み合わせとしてアニメーション化が効果グラフのパフォーマンス特性を変更可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-152">For all effects, however, care should be used when chaining and animating as some scenarios or combinations may change the performance characteristics of the effect graph.</span></span> <span data-ttu-id="3ef68-153">次には、個々 のエフェクトのいくつかの経験則パフォーマンス特性を示します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-153">Below are some rule of thumb performance characteristics for individual effects:</span></span>

- <span data-ttu-id="3ef68-154">高パフォーマンスの影響を与えることがわかっている効果は、とおり – ガウスぼかし、シャドウ マスク、BackDropBrush、HostBackDropBrush、ビジュアル レイヤーです。</span><span class="sxs-lookup"><span data-stu-id="3ef68-154">Effects that are known to have high performance impact are as follows – Gaussian Blur, Shadow Mask, BackDropBrush, HostBackDropBrush, and Layer Visual.</span></span> <span data-ttu-id="3ef68-155">これらは、ローエンドのデバイス[(機能レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)には推奨されず、ハイエンド デバイスでは慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-155">These are not recommended for low end devices [(feature level 9.1-9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx), and should be used judiciously on high end devices.</span></span>
- <span data-ttu-id="3ef68-156">普通サイズのパフォーマンスへの影響を効果には、カラー マトリックス (明るさ、色、彩度、および色相) 特定のブレンド効果 BlendModes スポット ライト、SceneLightingEffect、および (シナリオによって異なります) BorderEffect します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-156">Effects with medium performance impact include Color Matrix, certain Blend Effect BlendModes (Luminosity, Color, Saturation, and Hue), SpotLight, SceneLightingEffect, and (depending on scenario) BorderEffect.</span></span> <span data-ttu-id="3ef68-157">これらの効果は、ローエンドのデバイスで特定のシナリオと機能可能性がありますが、チェーンとアニメーション化するとき、注意を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3ef68-157">These effects may work with certain scenarios on low end devices, but care should be used when chaining and animating.</span></span> <span data-ttu-id="3ef68-158">以内に 2 つの使用を制限して、切り替えのみでアニメーション化することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="3ef68-158">Recommend restricting use to two or less and animating on transitions only.</span></span>
- <span data-ttu-id="3ef68-159">その他のすべての効果は、低パフォーマンスの影響し、アニメーション化とチェーンのすべての適切なシナリオで動作します。</span><span class="sxs-lookup"><span data-stu-id="3ef68-159">All other effects have low performance impact and work in all reasonable scenarios when animating and chaining.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3ef68-160">関連記事</span><span class="sxs-lookup"><span data-stu-id="3ef68-160">Related articles</span></span>

- [<span data-ttu-id="3ef68-161">UWP のレスポンシブ デザイン テクニック</span><span class="sxs-lookup"><span data-stu-id="3ef68-161">UWP Responsive Design Techniques</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [<span data-ttu-id="3ef68-162">UWP デバイスの調整</span><span class="sxs-lookup"><span data-stu-id="3ef68-162">UWP Device Tailoring</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
