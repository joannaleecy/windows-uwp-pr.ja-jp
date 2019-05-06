---
title: コンポジションの調整
description: 合成 Api を使用すると、UI を調整、パフォーマンスを最適化およびユーザー設定とデバイスの特性に対応します。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: bcc9a6d89a143d8fd03d73dbd83b832ed9513ee2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644417"
---
# <a name="tailoring-effects--experiences-using-windows-ui"></a><span data-ttu-id="03814-104">効果 & Windows UI を使用してエクスペリエンスを調整すること</span><span class="sxs-lookup"><span data-stu-id="03814-104">Tailoring effects & experiences using Windows UI</span></span>

<span data-ttu-id="03814-105">Windows UI は、差別化要因の多くの美しい効果、アニメーション、および手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="03814-105">Windows UI provides many beautiful effects, animations, and means for differentiation.</span></span> <span data-ttu-id="03814-106">ただし、パフォーマンスとカスタマイズ性のためのユーザーの期待を満たすが成功したアプリケーションを作成するのに必要です。</span><span class="sxs-lookup"><span data-stu-id="03814-106">However, meeting user expectations for performance and customizability is still a necessary part of creating successful applications.</span></span> <span data-ttu-id="03814-107">ユニバーサル Windows プラットフォームには、さまざまな機能と機能が含まれる、デバイスの大規模で多様なファミリがサポートしています。</span><span class="sxs-lookup"><span data-stu-id="03814-107">The Universal Windows Platform supports a large, diverse family of devices, which have different features and capabilities.</span></span> <span data-ttu-id="03814-108">すべてのユーザーに対して、包括的なエクスペリエンスを提供するためには、デバイス間で、アプリケーションのスケールをことを確認し、ユーザー設定を尊重する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03814-108">In order to provide an inclusive experience for all your users, you need to ensure your applications scale across devices and respect user preferences.</span></span> <span data-ttu-id="03814-109">UI を調整することと、デバイスの機能を活用し、快適になり、包括的なユーザー エクスペリエンスを実現する効率的な方法を提供できます。</span><span class="sxs-lookup"><span data-stu-id="03814-109">UI tailoring can provide an efficient way to leverage a device’s capabilities and ensure a pleasant and inclusive user experience.</span></span>

<span data-ttu-id="03814-110">パフォーマンスの高い、美しい UI に関して、次の領域の作業を包括的な広範なカテゴリは、UI を調整すること。</span><span class="sxs-lookup"><span data-stu-id="03814-110">UI tailoring is a broad category encompassing work for performant, beautiful UI with respect to the following areas:</span></span>

- <span data-ttu-id="03814-111">尊重し、効果のユーザー設定に合わせて調整</span><span class="sxs-lookup"><span data-stu-id="03814-111">Respecting and adapting to user settings for effects</span></span>
- <span data-ttu-id="03814-112">アニメーションのユーザー設定への対応</span><span class="sxs-lookup"><span data-stu-id="03814-112">Accommodating user settings for animations</span></span>
- <span data-ttu-id="03814-113">特定のハードウェア機能の UI を最適化します。</span><span class="sxs-lookup"><span data-stu-id="03814-113">Optimizing UI for the given hardware capabilities</span></span>

<span data-ttu-id="03814-114">ここでは、効果と、上の領域でビジュアル層でアニメーションを調整する方法について説明しますは、アプリケーションに優れたエンド ユーザー エクスペリエンスを調整するその他の多くの方法があります。</span><span class="sxs-lookup"><span data-stu-id="03814-114">Here, we'll cover how to tailor your effects and animations with the Visual Layer in the areas above, but there are many other means to tailor your application to ensure a great end user experience.</span></span> <span data-ttu-id="03814-115">Docs のガイダンスにする方法で使用可能な[、UI を調整](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)さまざまなデバイス用と[レスポンシブ UI を作成](/windows/uwp/design/layout/responsive-design)です。</span><span class="sxs-lookup"><span data-stu-id="03814-115">Guidance docs are available on how to [tailor your UI](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design) for various devices and [create responsive UI](/windows/uwp/design/layout/responsive-design).</span></span>

## <a name="user-effects-settings"></a><span data-ttu-id="03814-116">ユーザー設定の効果</span><span class="sxs-lookup"><span data-stu-id="03814-116">User effects settings</span></span>

<span data-ttu-id="03814-117">ユーザーは、さまざまな理由から、アプリケーションが尊重しに適応する必要があります Windows エクスペリエンスをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="03814-117">Users may customize their Windows experience for a variety of reasons, which applications should respect and adapt to.</span></span> <span data-ttu-id="03814-118">エンド ユーザーを制御できる 1 つの領域は、システム全体で使用される表示の副作用の種類を変更します。</span><span class="sxs-lookup"><span data-stu-id="03814-118">One area end users can control is changing the types of effects they see used throughout their system.</span></span>

### <a name="transparency-effects-settings"></a><span data-ttu-id="03814-119">透明度の設定の効果</span><span class="sxs-lookup"><span data-stu-id="03814-119">Transparency effects settings</span></span>

<span data-ttu-id="03814-120">ユーザーがカスタマイズできるこのような効果設定を 1 つは、透明効果オン/オフにすることです。</span><span class="sxs-lookup"><span data-stu-id="03814-120">One such effect setting users can customize is turning transparency effects on/off.</span></span> <span data-ttu-id="03814-121">パーソナル化の下で、設定アプリで確認できます > 色、または [設定] アプリを使用 > コンピューターの簡単操作 > 表示します。</span><span class="sxs-lookup"><span data-stu-id="03814-121">This can be found in the Settings app under Personalization > Colors, or through Settings app > Ease of Access > Display.</span></span>

![透明度オプションの設定](images/tailoring-transparency-setting.png)

<span data-ttu-id="03814-123">オンにすると、期待どおりに透明度を使用する影響が表示されます。</span><span class="sxs-lookup"><span data-stu-id="03814-123">When turned on, any effect that uses transparency will appear as expected.</span></span> <span data-ttu-id="03814-124">これは、アクリル、HostBackdropBrush、または完全に不透明でない任意のカスタム効果グラフに適用されます。</span><span class="sxs-lookup"><span data-stu-id="03814-124">This applies to Acrylic, HostBackdropBrush, or any custom effect graph that is not fully opaque.</span></span>

<span data-ttu-id="03814-125">オフのときアクリル素材が自動的にフォールバックを純色ため、XAML の acrylic ブラシが既定でこのイベントをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="03814-125">When turned off, acrylic material will automatically fall back to a solid color because XAML's acrylic brush has listened to this event by default.</span></span> <span data-ttu-id="03814-126">ここでは、電卓アプリケーションを適切にフォールバックを純色を透明効果が有効になっていないときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="03814-126">Here, we see the calculator app appropriately falling back to a solid color when transparency effects are not enabled:</span></span>

<span data-ttu-id="03814-127">![アクリル電卓](images/tailoring-acrylic.png)
![アクリル透明度の設定への応答での計算ツール](images/tailoring-acrylic-fallback.png)</span><span class="sxs-lookup"><span data-stu-id="03814-127">![Calculator with Acrylic](images/tailoring-acrylic.png)
![Calculator with Acrylic Responding to Transparency Settings](images/tailoring-acrylic-fallback.png)</span></span>

<span data-ttu-id="03814-128">ただし、任意のカスタム エフェクト アプリケーションの必要がありますに応答する、 [UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)プロパティまたは[AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged)イベントとスイッチ アウト影響/影響透過性がない効果を使用するグラフ。</span><span class="sxs-lookup"><span data-stu-id="03814-128">However, for any custom effects the application needs to respond to the [UISettings.AdvancedEffectsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) property or [AdvancedEffectsEnabledChanged](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.advancedeffectsenabledchanged) event and switch out the effect/effect graph to use an effect that has no transparency.</span></span> <span data-ttu-id="03814-129">この例を次に。</span><span class="sxs-lookup"><span data-stu-id="03814-129">An example of this is below:</span></span>

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

## <a name="animations-settings"></a><span data-ttu-id="03814-130">アニメーションの設定</span><span class="sxs-lookup"><span data-stu-id="03814-130">Animations settings</span></span>

<span data-ttu-id="03814-131">同様に、アプリケーションがリッスンして、応答する必要があります、 [UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled)アニメーションのことを確認するプロパティがオンまたはオフに設定でユーザー設定に基づいて > コンピューターの簡単操作 > 表示します。</span><span class="sxs-lookup"><span data-stu-id="03814-131">Similarly, applications should listen and respond to the [UISettings.AnimationsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.animationsenabled) property to ensure animations are turned on or off based on user settings in Settings > Ease of Access > Display.</span></span>

![アニメーション設定のオプション](images/tailoring-animations-setting.png)

```cs
public MainPage()
{
   var uisettings = new UISettings();
   bool animationsEnabled = uisettings.AnimationsEnabled;
   // TODO respond to animations settings
}

```

## <a name="leveraging-the-capabilities-api"></a><span data-ttu-id="03814-133">API の機能を活用します。</span><span class="sxs-lookup"><span data-stu-id="03814-133">Leveraging the capabilities API</span></span>

<span data-ttu-id="03814-134">利用して、 [CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) Api どの合成で各機能は使用とパフォーマンスの高い特定のハードウェアを検出してエンドユーザーの高性能、美しいエクスペリエンスを取得することを確認するデザインの調整デバイスです。</span><span class="sxs-lookup"><span data-stu-id="03814-134">By leveraging the [CompositionCapabilities](/uwp/api/windows.ui.composition.compositioncapabilities) APIs, you can detect which composition features are available and performant on given hardware and tailor the design to ensure end users get a performant and beautiful experience on any device.</span></span> <span data-ttu-id="03814-135">Api は、正常な効果がさまざまなフォーム ファクターでスケーリングを実装するためにハードウェア システムの機能を確認するための手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="03814-135">The APIs provide a means to check hardware system capabilities in order to implement graceful effect scaling across a variety of form factors.</span></span> <span data-ttu-id="03814-136">これにより、簡単に美しいを作成するアプリケーションとシームレスなエンド ユーザー エクスペリエンスを適切に調整できます。</span><span class="sxs-lookup"><span data-stu-id="03814-136">This makes it easy to appropriately tailor the application to create a beautiful and seamless end user experience.</span></span>

<span data-ttu-id="03814-137">この API は、メソッドと効果をアプリケーションの UI の決定事項を評価に使用できるイベント リスナーを提供します。</span><span class="sxs-lookup"><span data-stu-id="03814-137">This API provides methods and an event listener that can be used to make effect scaling decisions for the application UI.</span></span> <span data-ttu-id="03814-138">機能は、システムが複雑な構成と、レンダリング操作を処理する方法もを検出し、使いやすいモデルを利用する開発者向けの情報を返します。</span><span class="sxs-lookup"><span data-stu-id="03814-138">The feature detects how well the system can handle complex composition and rendering operations and then returns the information in an easy-to-consume model for developers to utilize.</span></span>

### <a name="using-composition-capabilities"></a><span data-ttu-id="03814-139">コンポジション機能を使用してください。</span><span class="sxs-lookup"><span data-stu-id="03814-139">Using composition capabilities</span></span>

<span data-ttu-id="03814-140">CompositionCapabilities 機能は既にアクリル素材を場所、マテリアルはフォールバックして、シナリオとハードウェアに応じてより高いパフォーマンス効果などの機能の活用されています。</span><span class="sxs-lookup"><span data-stu-id="03814-140">The CompositionCapabilities functionality is already being leveraged for features like Acrylic material, where the material falls back to a more performant effect depending on the scenario and hardware.</span></span>

<span data-ttu-id="03814-141">API は、いくつかの簡単な手順で既存のコードに追加できます。</span><span class="sxs-lookup"><span data-stu-id="03814-141">The API can be added to existing code in a few easy steps.</span></span>

1. <span data-ttu-id="03814-142">アプリケーションのコンストラクターで機能オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="03814-142">Acquire the capabilities object in your application’s constructor.</span></span>

    ```cs
    _capabilities = CompositionCapabilities.GetForCurrentView();
    ```

1. <span data-ttu-id="03814-143">アプリの機能変更イベント リスナーを登録します。</span><span class="sxs-lookup"><span data-stu-id="03814-143">Register a capabilities changed event listener for your app.</span></span>

    ```cs
    _capabilities.Changed += HandleCapabilitiesChanged;
    ```

1. <span data-ttu-id="03814-144">コンテンツは、さまざまな機能レベルを処理するイベントのコールバック メソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="03814-144">Add content to the event callback method to handle various capabilities levels.</span></span> <span data-ttu-id="03814-145">これは、次の手順を次のようなことができない可能性がありますもかまいません。</span><span class="sxs-lookup"><span data-stu-id="03814-145">This may or may not be similar to the next step below.</span></span>
1. <span data-ttu-id="03814-146">効果を使用する場合は、まず機能オブジェクトを確認します。</span><span class="sxs-lookup"><span data-stu-id="03814-146">When using effects, check the capabilities object first.</span></span> <span data-ttu-id="03814-147">条件付きチェックの使用を検討するか、または効果を調整する方法に応じて、コントロール ステートメントを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="03814-147">Consider using conditional checks or switch control statements, depending on how you want to tailor the effects.</span></span>

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

<span data-ttu-id="03814-148">全体のコード例で確認できます、 [Windows UI の Github リポジトリ](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities)します。</span><span class="sxs-lookup"><span data-stu-id="03814-148">Full example code can be found on the [Windows UI Github repo](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2015063/CompCapabilities).</span></span>

## <a name="fast-vs-slow-effects"></a><span data-ttu-id="03814-149">低速の効果と高速</span><span class="sxs-lookup"><span data-stu-id="03814-149">Fast vs. slow effects</span></span>

<span data-ttu-id="03814-150">提供されたフィードバックに基づく[AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported)と[AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast) CompositionCapabilities API のメソッドは、アプリケーションは、のコストがかかったり、サポートされていない効果をスワップすることもできますその他の効果の任意のデバイス用に最適化されます。</span><span class="sxs-lookup"><span data-stu-id="03814-150">Based on feedback from the provided [AreEffectsSupported](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectssupported) and [AreEffectsFast](/uwp/api/windows.ui.composition.compositioncapabilities.areeffectsfast) methods in the CompositionCapabilities API, the application can decide to swap expensive or unsupported effects for other effects of their choice that are optimized for the device.</span></span> <span data-ttu-id="03814-151">効果をいくつかが明らかに一貫して他のユーザーよりもリソースを使用し、適度に使用する必要があり、その他の効果をより自由に使用できます。</span><span class="sxs-lookup"><span data-stu-id="03814-151">Some effects are known to consistently be more resource intensive than others and should be used sparingly, and other effects can be used more freely.</span></span> <span data-ttu-id="03814-152">すべての効果のただし、注意する必要があります使用効果グラフのパフォーマンス特性を変更することがありますチェーンといくつかのシナリオの組み合わせとアニメーション化するときに。</span><span class="sxs-lookup"><span data-stu-id="03814-152">For all effects, however, care should be used when chaining and animating as some scenarios or combinations may change the performance characteristics of the effect graph.</span></span> <span data-ttu-id="03814-153">次には、個々 のエフェクトのいくつかの経験則パフォーマンス特性を示します。</span><span class="sxs-lookup"><span data-stu-id="03814-153">Below are some rule of thumb performance characteristics for individual effects:</span></span>

- <span data-ttu-id="03814-154">高パフォーマンスの影響を与えることがわかっている効果、次のように – ガウスぼかしシャドウ マスク、BackDropBrush、HostBackDropBrush、ビジュアル レイヤー。</span><span class="sxs-lookup"><span data-stu-id="03814-154">Effects that are known to have high performance impact are as follows – Gaussian Blur, Shadow Mask, BackDropBrush, HostBackDropBrush, and Layer Visual.</span></span> <span data-ttu-id="03814-155">これらは、ローエンド デバイスの場合は推奨されません[(機能レベル 9.1 9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx)、ハイ エンド デバイスで慎重に使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03814-155">These are not recommended for low end devices [(feature level 9.1-9.3)](https://msdn.microsoft.com/library/windows/desktop/ff476876(v=vs.85).aspx), and should be used judiciously on high end devices.</span></span>
- <span data-ttu-id="03814-156">中程度のパフォーマンスへの影響を効果にカラー行列を特定ブレンド効果 BlendModes (光度、色、鮮やかさ、および Hue) は、スポット ライト、SceneLightingEffect、および (シナリオによって異なる) BorderEffect します。</span><span class="sxs-lookup"><span data-stu-id="03814-156">Effects with medium performance impact include Color Matrix, certain Blend Effect BlendModes (Luminosity, Color, Saturation, and Hue), SpotLight, SceneLightingEffect, and (depending on scenario) BorderEffect.</span></span> <span data-ttu-id="03814-157">ローエンドのデバイスで特定のシナリオでこれらの効果が動作しますが、チェーンとアニメーション化するときに、注意を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="03814-157">These effects may work with certain scenarios on low end devices, but care should be used when chaining and animating.</span></span> <span data-ttu-id="03814-158">以下に 2 つの使用を制限して、遷移のみをアニメーション化をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="03814-158">Recommend restricting use to two or less and animating on transitions only.</span></span>
- <span data-ttu-id="03814-159">他のすべての効果は、低パフォーマンスに影響し、アニメーション化すると、チェーンのすべての妥当なシナリオでは機能します。</span><span class="sxs-lookup"><span data-stu-id="03814-159">All other effects have low performance impact and work in all reasonable scenarios when animating and chaining.</span></span>

## <a name="related-articles"></a><span data-ttu-id="03814-160">関連記事</span><span class="sxs-lookup"><span data-stu-id="03814-160">Related articles</span></span>

- [<span data-ttu-id="03814-161">UWP のレスポンシブ デザイン手法</span><span class="sxs-lookup"><span data-stu-id="03814-161">UWP Responsive Design Techniques</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/responsive-design)
- [<span data-ttu-id="03814-162">UWP デバイスの調整</span><span class="sxs-lookup"><span data-stu-id="03814-162">UWP Device Tailoring</span></span>](https://docs.microsoft.com/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
