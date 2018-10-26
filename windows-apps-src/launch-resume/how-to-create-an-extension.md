---
author: TylerMSFT
title: アプリ拡張機能の作成と利用
description: ユニバーサル Windows プラットフォーム (UWP) アプリの拡張機能を作成してホストすると、Microsoft Store からユーザーがインストールできるパッケージを介してアプリを拡張できます。
keywords: アプリの拡張機能, アプリ サービス, バック グラウンド
ms.author: twhitney
ms.date: 10/05/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a1722c22c717ec1a349f6e7d48c1e151209eab2c
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5642145"
---
# <a name="create-and-host-an-app-extension"></a><span data-ttu-id="fa30c-104">アプリ拡張機能の作成とホスト</span><span class="sxs-lookup"><span data-stu-id="fa30c-104">Create and host an app extension</span></span>

<span data-ttu-id="fa30c-105">この記事では、UWP アプリの拡張機能を作成し、UWP アプリ内でホストする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-105">This article shows you how to create a UWP app extension and host it in a UWP app.</span></span>

<span data-ttu-id="fa30c-106">この記事には、コード サンプルが付属しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-106">This article is accompanied by a code sample:</span></span>
- <span data-ttu-id="fa30c-107">[Math Extension コード サンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip)をダウンロードして解凍します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-107">Download and unzip [Math Extension code sample](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip).</span></span>
- <span data-ttu-id="fa30c-108">Visual Studio 2017 で MathExtensionSample.sln ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-108">In Visual Studio 2017, open MathExtensionSample.sln.</span></span> <span data-ttu-id="fa30c-109">ビルドの種類を x86 に設定します (両方のプロジェクトで、**[ビルド]** > **[構成マネージャー]** を選択し、**[プラットフォーム]** を **[x86]** に変更します)。</span><span class="sxs-lookup"><span data-stu-id="fa30c-109">Set the build type to x86 (**Build** > **Configuration Manager**, then change **Platform** to **x86** for both projects).</span></span>
- <span data-ttu-id="fa30c-110">ソリューションの展開: **[ビルド]** > **[ソリューションの配置]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-110">Deploy the solution: **Build** > **Deploy Solution**.</span></span>

## <a name="introduction-to-app-extensions"></a><span data-ttu-id="fa30c-111">アプリ拡張機能の概要</span><span class="sxs-lookup"><span data-stu-id="fa30c-111">Introduction to app extensions</span></span>

<span data-ttu-id="fa30c-112">ユニバーサル Windows プラットフォーム (UWP) では、アプリ拡張機能により、プラグイン、アドイン、アドオンが他のプラットフォームで実行する処理に類似した機能が提供されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-112">In the Universal Windows Platform (UWP), app extensions provide functionality similar to what plug-ins, add-ins, and add-ons do on other platforms.</span></span> <span data-ttu-id="fa30c-113">たとえば、Microsoft Edge 拡張機能は、UWP アプリ拡張機能です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-113">Microsoft Edge extensions are UWP app extensions, for example.</span></span> <span data-ttu-id="fa30c-114">UWP アプリ拡張機能は、Windows 10 Anniversary エディション (Version 1607、ビルド 10.0.14393) で導入されました。</span><span class="sxs-lookup"><span data-stu-id="fa30c-114">UWP app extensions were introduced in the Windows 10 Anniversary edition (version 1607, build 10.0.14393).</span></span>

<span data-ttu-id="fa30c-115">UWP アプリ拡張機能は、コンテンツと展開イベントをホスト アプリと共有するための拡張宣言を持つ UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="fa30c-115">UWP app extensions are UWP apps that have an extension declaration that allows them to share content and deployment events with a host app.</span></span> <span data-ttu-id="fa30c-116">拡張アプリは、複数の拡張機能を提供できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-116">An extension app can provide multiple extensions.</span></span>

<span data-ttu-id="fa30c-117">アプリ拡張機能も UWP アプリであるため、別のアプリ パッケージを作成することなく、これらは完全に機能するアプリとして使用でき、拡張機能をホストすることも、他のアプリに拡張機能を提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-117">Because app extensions are just UWP apps, they can also be fully functional apps, host extensions, and provide extensions to other apps--all without creating separate app packages.</span></span>

<span data-ttu-id="fa30c-118">アプリ拡張機能のホストを作成することは、アプリ周辺のエコシステムを構築するチャンスであり、自分では予測しなかった形態または用意できないリソースによって他の開発者にアプリを強化してもらうことも可能になります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-118">When you create an app extension host, you create an opportunity to develop an ecosystem around your app in which other developers can enhance your app in ways that you may not have expected or had the resources for.</span></span> <span data-ttu-id="fa30c-119">Microsoft Office 拡張機能、Visual Studio 拡張機能、ブラウザー拡張機能などについて考えてみてください。これらは、各アプリに当初含まれていた機能を越えて、より充実したエクスペリエンスを生み出しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-119">Consider Microsoft Office extensions, Visual Studio extensions, browser extensions, etc. These create richer experiences for those apps that go beyond the functionality they shipped with.</span></span> <span data-ttu-id="fa30c-120">拡張機能を利用すると、アプリに価値を付加し、アプリの寿命を延ばすことができます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-120">Extensions can add value and longevity to your app.</span></span>

**<span data-ttu-id="fa30c-121">概要</span><span class="sxs-lookup"><span data-stu-id="fa30c-121">Overview</span></span>**

<span data-ttu-id="fa30c-122">大まかに言うと、アプリ拡張機能の関係をセットアップするために、次の作業を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-122">At a high level, to set up an app extension relationship, we need to:</span></span>

1. <span data-ttu-id="fa30c-123">拡張機能のホストとなるアプリを宣言します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-123">Declare an app to be an extension host.</span></span>
2. <span data-ttu-id="fa30c-124">拡張機能となるアプリを宣言します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-124">Declare an app to be an extension.</span></span>
3. <span data-ttu-id="fa30c-125">拡張機能をアプリ サービス、バック グラウンド タスク、またはその他のいずれとして実装するのかを決定します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-125">Decide whether to implement the extension as an app service, background task, or some other way.</span></span>
4. <span data-ttu-id="fa30c-126">ホストと拡張機能の通信方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-126">Define how the hosts and its extensions will communicate.</span></span>
5. <span data-ttu-id="fa30c-127">ホスト アプリ内で拡張機能にアクセスするために、[Windows.ApplicationModel.AppExtensions](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.AppExtensions) API を使用します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-127">Use the [Windows.ApplicationModel.AppExtensions](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.AppExtensions) API in the host app to access the extensions.</span></span>

<span data-ttu-id="fa30c-128">これがどのように行われるのか、[Math Extension コード サンプル](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip)で見てみましょう。このコードでは仮想計算機を実装していますが、拡張機能を使用してこの計算機に新しい関数を追加できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-128">Let's see how this is done by examining the [Math Extension code sample](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/MathExtensionSample.zip) which implements a hypothetical calculator that you can add new functions to by using extensions.</span></span> <span data-ttu-id="fa30c-129">Microsoft Visual Studio 2017 で、コード サンプルから **MathExtensionSample.sln** を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-129">In Microsoft Visual Studio 2017, load **MathExtensionSample.sln** from the code sample.</span></span>

![Math Extension コード サンプル](images/mathextensionhost-calctab.png)

## <a name="declare-an-app-to-be-an-extension-host"></a><span data-ttu-id="fa30c-131">アプリを拡張機能のホストとして宣言する</span><span class="sxs-lookup"><span data-stu-id="fa30c-131">Declare an app to be an extension host</span></span>

<span data-ttu-id="fa30c-132">アプリの Package.appxmanifest ファイル内で `<AppExtensionHost>` 要素を宣言すると、そのアプリは自身をアプリ拡張機能のホストとして認識します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-132">An app identifies itself as an app extension host by declaring the `<AppExtensionHost>` element in its Package.appxmanifest file.</span></span> <span data-ttu-id="fa30c-133">その方法については、**MathExtensionHost** プロジェクトの **Package.appxmanifest** ファイルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-133">See the **Package.appxmanifest** file in the **MathExtensionHost** project to see how this is done.</span></span>

_<span data-ttu-id="fa30c-134">MathExtensionHost プロジェクト内の Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="fa30c-134">Package.appxmanifest in the MathExtensionHost project</span></span>_
```xml
<Package
  ...
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap uap3 mp">
  ...
    <Applications>
      <Application Id="App" ... >
        ...
        <Extensions>
            <uap3:Extension Category="windows.appExtensionHost">
                <uap3:AppExtensionHost>
                  <uap3:Name>microsoft.com.MathExt</uap3:Name>
                </uap3:AppExtensionHost>
          </uap3:Extension>
        </Extensions>
      </Application>
    </Applications>
    ...
</Package>
```

<span data-ttu-id="fa30c-135">`xmlns:uap3="http://..."` という記述があり、`IgnorableNamespaces` に `uap3` が指定されています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-135">Notice the `xmlns:uap3="http://..."` and the presence of `uap3` in `IgnorableNamespaces`.</span></span> <span data-ttu-id="fa30c-136">これらは、uap3 名前空間を使用するために必要な記述です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-136">These are necessary because we are using the uap3 namespace.</span></span>

`<uap3:Extension Category="windows.appExtensionHost">` <span data-ttu-id="fa30c-137">は、このアプリを拡張機能のホストとして識別します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-137">identifies this app as an extension host.</span></span>

<span data-ttu-id="fa30c-138">`<uap3:AppExtensionHost>` の **Name** 要素は、_拡張機能コントラクト_名です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-138">The **Name** element in `<uap3:AppExtensionHost>` is the _extension contract_ name.</span></span> <span data-ttu-id="fa30c-139">拡張機能が同じ拡張機能コントラクト名を指定していれば、ホストからの検出が可能になります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-139">When an extension specifies the same extension contract name, the host will be able to find it.</span></span> <span data-ttu-id="fa30c-140">慣例として、他の拡張機能コントラクト名との競合を回避するため、アプリ名または発行元の名前を使用して拡張機能コントラクト名を作成するようお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fa30c-140">By convention, we recommend building the extension contract name using your app or publisher name to avoid potential collisions with other extension contract names.</span></span>

<span data-ttu-id="fa30c-141">同じアプリで、複数のホストと複数の拡張機能を定義できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-141">You can define multiple hosts and multiple extensions in the same app.</span></span> <span data-ttu-id="fa30c-142">この例では、1 つのホストを宣言します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-142">In this example, we declare one host.</span></span> <span data-ttu-id="fa30c-143">拡張機能は、別のアプリで定義します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-143">The extension is defined in another app.</span></span>

## <a name="declare-an-app-to-be-an-extension"></a><span data-ttu-id="fa30c-144">アプリを拡張機能として宣言する</span><span class="sxs-lookup"><span data-stu-id="fa30c-144">Declare an app to be an extension</span></span>

<span data-ttu-id="fa30c-145">アプリの **Package.appxmanifest** ファイル内で `<uap3:AppExtension>` 要素を宣言すると、そのアプリは自身をアプリ拡張機能のホストとして認識します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-145">An app identifies itself as an app extension by declaring the `<uap3:AppExtension>` element in its **Package.appxmanifest** file.</span></span> <span data-ttu-id="fa30c-146">その方法については、**MathExtension** プロジェクトの **Package.appxmanifest** ファイルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-146">Open the **Package.appxmanifest** file in the **MathExtension** project to see how this is done.</span></span>

_<span data-ttu-id="fa30c-147">MathExtension プロジェクト内の Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="fa30c-147">Package.appxmanifest in the MathExtension project:</span></span>_
```xml
<Package
  ...
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap uap3 mp">
  ...
    <Applications>
      <Application Id="App" ... >
        ...
        <Extensions>
          ...
          <uap3:Extension Category="windows.appExtension">
            <uap3:AppExtension Name="Microsoft.com.MathExt"
                               Id="power"
                               DisplayName="x^y"
                               Description="Exponent"
                               PublicFolder="Public">
              <uap3:Properties>
                <Service>com.microsoft.powservice</Service>
              </uap3:Properties>
              </uap3:AppExtension>
          </uap3:Extension>
        </Extensions>
      </Application>
    </Applications>
    ...
</Package>
```

<span data-ttu-id="fa30c-148">ここでも、`xmlns:uap3="http://..."` という記述があり、`IgnorableNamespaces` に `uap3` が指定されています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-148">Again, notice the `xmlns:uap3="http://..."` line, and the presence of `uap3` in `IgnorableNamespaces`.</span></span> <span data-ttu-id="fa30c-149">これらは、`uap3` 名前空間を使用するために必要な記述です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-149">These are necessary because we are using the `uap3` namespace.</span></span>

`<uap3:Extension Category="windows.appExtension">` <span data-ttu-id="fa30c-150">は、このアプリを拡張機能として識別します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-150">identifies this app as an extension.</span></span>

<span data-ttu-id="fa30c-151">`<uap3:AppExtension>` 属性の意味は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="fa30c-151">The meaning of the `<uap3:AppExtension>` attributes are as follows:</span></span>

|<span data-ttu-id="fa30c-152">属性</span><span class="sxs-lookup"><span data-stu-id="fa30c-152">Attribute</span></span>|<span data-ttu-id="fa30c-153">説明</span><span class="sxs-lookup"><span data-stu-id="fa30c-153">Description</span></span>|<span data-ttu-id="fa30c-154">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="fa30c-154">Required</span></span>|
|---------|-----------|:------:|
|**<span data-ttu-id="fa30c-155">Name</span><span class="sxs-lookup"><span data-stu-id="fa30c-155">Name</span></span>**|<span data-ttu-id="fa30c-156">これは、拡張機能コントラクト名です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-156">This is the extension contract name.</span></span> <span data-ttu-id="fa30c-157">ホストで宣言されている **Name** と一致すれば、ホストがこの拡張機能を検出できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-157">When it matches the **Name** declared in a host, that host will be able to find this extension.</span></span>| <span data-ttu-id="fa30c-158">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="fa30c-158">:heavy_check_mark:</span></span> |
|**<span data-ttu-id="fa30c-159">ID</span><span class="sxs-lookup"><span data-stu-id="fa30c-159">ID</span></span>**| <span data-ttu-id="fa30c-160">このアプリを拡張機能を一意に識別します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-160">Uniquely identifies this extension.</span></span> <span data-ttu-id="fa30c-161">複数の拡張機能で同じ拡張機能コントラクト名が使用されることも考えられるため (たとえば、ペイント アプリでは複数の拡張機能がサポートされています)、ID を使用して区別できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-161">Because there can be multiple extensions that use the same extension contract name (imagine a paint app that supports several extensions), you can use the ID to tell them apart.</span></span> <span data-ttu-id="fa30c-162">アプリ拡張機能のホストは、ID を使用して拡張機能の種類を推測できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-162">App extension hosts can use the ID to infer something about the type of extension.</span></span> <span data-ttu-id="fa30c-163">たとえば、1 つ目の拡張機能がデスクトップ用、2 つ目の拡張機能がモバイル用に設計されている場合に、これらを ID で区別できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-163">For example, you could have one Extension designed for desktop and another for mobile, with the ID being the differentiator.</span></span> <span data-ttu-id="fa30c-164">この目的で **Properties** 要素を使用することもできます (以下をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="fa30c-164">You could also use the **Properties** element, discussed below, for that.</span></span>| <span data-ttu-id="fa30c-165">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="fa30c-165">:heavy_check_mark:</span></span> |
|**<span data-ttu-id="fa30c-166">DisplayName</span><span class="sxs-lookup"><span data-stu-id="fa30c-166">DisplayName</span></span>**| <span data-ttu-id="fa30c-167">ユーザーが拡張機能を識別できるように、ホスト アプリから使用できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-167">Can be used from your host app to identify the extension to the user.</span></span> <span data-ttu-id="fa30c-168">照会が可能であり、ローカライズ用に[新しいリソース管理システム](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) を使用できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-168">It is queryable from, and can use, the [new resource management system](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) for localization.</span></span> <span data-ttu-id="fa30c-169">ローカライズされたコンテンツは、ホスト アプリからではなく、アプリ拡張機能から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-169">The localized content is loaded from the app extension package, not the host app.</span></span> | |
|**<span data-ttu-id="fa30c-170">Description</span><span class="sxs-lookup"><span data-stu-id="fa30c-170">Description</span></span>** | <span data-ttu-id="fa30c-171">ユーザーに対して拡張機能を説明するために、ホスト アプリから使用できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-171">Can be used from your host app to describe the extension to the user.</span></span> <span data-ttu-id="fa30c-172">照会が可能であり、ローカライズ用に[新しいリソース管理システム](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) を使用できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-172">It is queryable from, and can use, the [new resource management system](https://docs.microsoft.com/windows/uwp/app-resources/using-mrt-for-converted-desktop-apps-and-games) (`ms-resource:TokenName`) for localization.</span></span> <span data-ttu-id="fa30c-173">ローカライズされたコンテンツは、ホスト アプリからではなく、アプリ拡張機能から読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-173">The localized content is loaded from the app extension package, not the host app.</span></span> | |
|**<span data-ttu-id="fa30c-174">PublicFolder</span><span class="sxs-lookup"><span data-stu-id="fa30c-174">PublicFolder</span></span>**|<span data-ttu-id="fa30c-175">パッケージのルートを基準としたフォルダーの名前です。このフォルダーでは、コンテンツを拡張機能のホストと共有できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-175">The name of a folder, relative to the package root, where you can share content with the extension host.</span></span> <span data-ttu-id="fa30c-176">この名前は、慣例では "Public" ですが、拡張機能内のフォルダーと一致する名前であれば、任意の名前を使用できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-176">By convention the name is "Public", but you can use any name that matches a folder in your extension.</span></span>| <span data-ttu-id="fa30c-177">:heavy_check_mark:</span><span class="sxs-lookup"><span data-stu-id="fa30c-177">:heavy_check_mark:</span></span> |

`<uap3:Properties>` <span data-ttu-id="fa30c-178">は、実行時にホストが読み取ることができるカスタム メタデータが含まれた省略可能な要素です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-178">is an optional element that contains custom metadata that hosts can read at runtime.</span></span> <span data-ttu-id="fa30c-179">コード サンプルでは拡張機能がアプリ サービスとして実装されるため、ホストでは、そのアプリ サービスを呼び出すことができるように、名前を取得する方法が必要になります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-179">In the code sample, the extension is implemented as an app service so host needs a way to get the name of that app service so it can call it.</span></span> <span data-ttu-id="fa30c-180">アプリ サービスの名前は、<Service> 要素で定義されています (任意の名前を定義できます)。</span><span class="sxs-lookup"><span data-stu-id="fa30c-180">The name of the app service is defined in the <Service> element, which we defined (we could have called it anything we wanted).</span></span> <span data-ttu-id="fa30c-181">コード サンプルのホストは、実行時にこのプロパティを探して、アプリ サービスの名前を取得します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-181">The host in the code sample looks for this property at runtime to learn the name of the app service.</span></span>

## <a name="decide-how-you-will-implement-the-extension"></a><span data-ttu-id="fa30c-182">拡張機能の実装方法を決定する</span><span class="sxs-lookup"><span data-stu-id="fa30c-182">Decide how you will implement the extension.</span></span>

<span data-ttu-id="fa30c-183">[アプリ拡張機能に関する Build 2016 セッション](https://channel9.msdn.com/Events/Build/2016/B808)では、ホストと拡張機能の間で共有されるパブリック フォルダーの使用方法を説明しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-183">The [Build 2016 session about app extensions](https://channel9.msdn.com/Events/Build/2016/B808) demonstrates how to use the public folder that is shared between the host and the extensions.</span></span> <span data-ttu-id="fa30c-184">その例では、ホストが呼び出す Javascript ファイル (パブリック フォルダーに格納されている) によって拡張機能が実装されています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-184">In that example, the extension is implemented by a Javascript file that is stored in the public folder, which the host invokes.</span></span> <span data-ttu-id="fa30c-185">このアプローチには、軽量でありコンパイルを必要としないという利点があります。また、拡張機能の使用方法やアプリの Microsoft Store ページのリンクが記載された既定のランディング ページの作成もサポートされます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-185">That approach has the advantage of being lightweight, does not require compilation, and can support making the default landing page that provides instructions for the extension and a link to the host app's Microsoft Store page.</span></span> <span data-ttu-id="fa30c-186">詳しくは、[Build 2016 のアプリ拡張機能コード サンプル](https://github.com/Microsoft/App-Extensibility-Sample)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-186">See the [Build 2016 app extension code sample](https://github.com/Microsoft/App-Extensibility-Sample) for details.</span></span> <span data-ttu-id="fa30c-187">具体的には、**InvertImageExtension** プロジェクトと、**ExtensibilitySample** プロジェクトに含まれる ExtensionManager.cs の `InvokeLoad()` をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-187">Specifically, see the **InvertImageExtension** project and `InvokeLoad()` in ExtensionManager.cs in the **ExtensibilitySample** project.</span></span>

<span data-ttu-id="fa30c-188">この例では、アプリ サービスを使用して拡張機能を実装します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-188">In this example, we'll use an app service to implement the extension.</span></span> <span data-ttu-id="fa30c-189">アプリ サービスには、次の利点があります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-189">App services have the following advantages:</span></span>

- <span data-ttu-id="fa30c-190">ホスト アプリは自身のプロセス内で実行されるため、拡張機能がクラッシュしても、ホスト アプリはダウンしません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-190">If the extension crashes, it won't take down the host app because the host app runs in its own process.</span></span>
- <span data-ttu-id="fa30c-191">好みの言語を使用してサービスを実装できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-191">You can use the language of your choice to implement the service.</span></span> <span data-ttu-id="fa30c-192">ホスト アプリの実装に使用する言語と一致する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-192">It doesn't have to match language used to implement the host app.</span></span>
- <span data-ttu-id="fa30c-193">アプリ サービスは、自身用のアプリ コンテナーにアクセスできます。ホストの機能とは異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-193">The app service has access to its own app container--which may have different capabilities than the host has.</span></span>
- <span data-ttu-id="fa30c-194">使用中のデータとホスト アプリが分離されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-194">There is isolation between data in service and the host app.</span></span>

### <a name="host-app-service-code"></a><span data-ttu-id="fa30c-195">アプリ サービスのコードをホストする</span><span class="sxs-lookup"><span data-stu-id="fa30c-195">Host app service code</span></span>

<span data-ttu-id="fa30c-196">拡張機能のアプリ サービスを呼び出すホスト コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-196">Here is the host code that invokes the extension's app service:</span></span>

_<span data-ttu-id="fa30c-197">MathExtensionHost プロジェクト内の ExtensionManager.cs</span><span class="sxs-lookup"><span data-stu-id="fa30c-197">ExtensionManager.cs in the MathExtensionHost project</span></span>_
```cs
public async Task<double> Invoke(ValueSet message)
{
    if (Loaded)
    {
        try
        {
            // make the app service call
            using (var connection = new AppServiceConnection())
            {
                // service name is defined in appxmanifest properties
                connection.AppServiceName = _serviceName;
                // package Family Name is provided by the extension
                connection.PackageFamilyName = AppExtension.Package.Id.FamilyName;

                // open the app service connection
                AppServiceConnectionStatus status = await connection.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    Debug.WriteLine("Failed App Service Connection");
                }
                else
                {
                    // Call the app service
                    AppServiceResponse response = await connection.SendMessageAsync(message);
                    if (response.Status == AppServiceResponseStatus.Success)
                    {
                        ValueSet answer = response.Message as ValueSet;
                        if (answer.ContainsKey("Result")) // When our app service returns "Result", it means it succeeded
                        {
                            return (double)answer["Result"];
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
             Debug.WriteLine("Calling the App Service failed");
        }
    }
    return double.NaN; // indicates an error from the app service
}
```

<span data-ttu-id="fa30c-198">これは、アプリ サービスを呼び出すための一般的なコードです。</span><span class="sxs-lookup"><span data-stu-id="fa30c-198">This is typical code for invoking an app service.</span></span> <span data-ttu-id="fa30c-199">アプリ サービスの実装方法と呼び出し方法について詳しくは、「[アプリ サービスの作成と利用の方法](how-to-create-and-consume-an-app-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-199">For details on how to implement and call an app service, see [How to create and consume an app service](how-to-create-and-consume-an-app-service.md).</span></span>

<span data-ttu-id="fa30c-200">1 点、呼び出すアプリ サービスの名前の決定方法に注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-200">One thing to note is how the name of the app service to call is determined.</span></span> <span data-ttu-id="fa30c-201">ホストは、拡張機能の実装に関する情報を持っていないため、拡張機能が自身のアプリ サービスの名前を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-201">Because the host doesn't have information about the implementation of the extension, the extension needs to provide the name of its app service.</span></span> <span data-ttu-id="fa30c-202">コード サンプルでは、拡張機能がアプリ サービスの名前を自身のファイル内の `<uap3:Properties>` 要素で宣言しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-202">In the code sample, the extension declares the name of the app service in its  file in the `<uap3:Properties>` element:</span></span>

_<span data-ttu-id="fa30c-203">MathExtension プロジェクト内の Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="fa30c-203">Package.appxmanifest in the MathExtension project</span></span>_
```xml
    ...
    <uap3:Extension Category="windows.appExtension">
      <uap3:AppExtension ...>
        <uap3:Properties>
          <Service>com.microsoft.powservice</Service>
        </uap3:Properties>
        </uap3:AppExtension>
    </uap3:Extension>
```

<span data-ttu-id="fa30c-204">`<uap3:Properties>` 要素では、独自の XML を定義できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-204">You can define your own XML in the `<uap3:Properties>` element.</span></span> <span data-ttu-id="fa30c-205">ここでは、拡張機能を呼び出すときにホストが参照できるよう、アプリ サービスの名前を定義しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-205">In this case, we define the name of the app service so that the host can it when it invokes the extension.</span></span>

<span data-ttu-id="fa30c-206">ホストが拡張機能を読み込むと、このようなコードによって、拡張機能の Package.appxmanifest で定義されているプロパティから、サービスの名前が抽出されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-206">When the host loads an extension, code like this extracts the name of the service from the properties defined in the extension's Package.appxmanifest:</span></span>

_`Update()` <span data-ttu-id="fa30c-207">(MathExtensionHost プロジェクト内の ExtensionManager.cs に含まれている)</span><span class="sxs-lookup"><span data-stu-id="fa30c-207">in ExtensionManager.cs, in the MathExtensionHost project</span></span>_
```cs
...
var properties = await ext.GetExtensionPropertiesAsync() as PropertySet;

...
#region Update Properties
// update app service information
_serviceName = null;
if (_properties != null)
{
   if (_properties.ContainsKey("Service"))
   {
       PropertySet serviceProperty = _properties["Service"] as PropertySet;
       this._serviceName = serviceProperty["#text"].ToString();
   }
}
#endregion
```

<span data-ttu-id="fa30c-208">アプリ サービスの名前が `_serviceName` に格納されていれば、ホストはこれを使用して、アプリ サービスを起動できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-208">With the name of the app service stored in `_serviceName`, the host is able to use it to invoke the app service.</span></span>

<span data-ttu-id="fa30c-209">アプリ サービスを呼び出すには、そのアプリ サービスが含まれるパッケージのファミリ名も必要です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-209">Calling an app service also requires the family name of the package that contains the app service.</span></span> <span data-ttu-id="fa30c-210">この情報は、以下の行で取得され、アプリ拡張機能 API によって提供されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-210">Fortunately, the app extension API provides this information which is obtained in the line:</span></span> `connection.PackageFamilyName = AppExtension.Package.Id.FamilyName;`

### <a name="define-how-the-host-and-the-extension-will-communicate"></a><span data-ttu-id="fa30c-211">ホストと拡張機能の通信方法を定義する</span><span class="sxs-lookup"><span data-stu-id="fa30c-211">Define how the host and the extension will communicate</span></span>

<span data-ttu-id="fa30c-212">アプリ サービスは [ValueSet](https://docs.microsoft.com/uwp/api/windows.foundation.collections.valueset) を使って情報を交換します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-212">App services use a [ValueSet](https://docs.microsoft.com/uwp/api/windows.foundation.collections.valueset) to exchange information.</span></span> <span data-ttu-id="fa30c-213">ホストの作成者は、拡張機能と通信するための柔軟なプロトコルを用意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-213">As the author of the host, you need to come up with a protocol for communicating with extensions that is flexible.</span></span> <span data-ttu-id="fa30c-214">コード サンプルでは、将来的に拡張機能が 1 つまたは 2 つ、あるいはそれ以上の引数を受け取る可能性を考慮しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-214">In the code sample, that means accounting for extensions that may take 1, 2, or more arguments in the future.</span></span>

<span data-ttu-id="fa30c-215">この例では、引数のプロトコルは 'Arg' + 引数番号 (`Arg1`、`Arg2` など) という名前のキー値ペアが含まれる **ValueSet** です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-215">For this example, the protocol for the arguments is a **ValueSet** containing the key value pairs named 'Arg' + the argument number, e.g. `Arg1` and `Arg2`.</span></span> <span data-ttu-id="fa30c-216">ホストはすべての引数を **ValueSet** で渡し、拡張機能はそのうち必要なものを利用します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-216">The host passes all of the arguments in the **ValueSet**, and the extension makes use of the ones that it needs.</span></span> <span data-ttu-id="fa30c-217">拡張機能が結果を計算できる場合、拡張機能から返された **ValueSet** に `Result` という名前のキーがあり計算値が含まれていることをホストが想定します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-217">If the extension is able to calculate a result, then the host expects the **ValueSet** returned from the extension to have a key named `Result` that contains the value of the calculation.</span></span> <span data-ttu-id="fa30c-218">そのキーが存在しない場合、ホストでは、拡張機能が計算を完了できなかったと見なします。</span><span class="sxs-lookup"><span data-stu-id="fa30c-218">If that key is not present, the host assumes that the extension couldn't complete the calculation.</span></span>

### <a name="extension-app-service-code"></a><span data-ttu-id="fa30c-219">拡張機能のアプリ サービス コード</span><span class="sxs-lookup"><span data-stu-id="fa30c-219">Extension app service code</span></span>

<span data-ttu-id="fa30c-220">コード サンプルでは、拡張機能のアプリ サービスは、バック グラウンド タスクとして実装されていません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-220">In the code sample, the extension's app service is not implemented as a background task.</span></span> <span data-ttu-id="fa30c-221">代わりに、単一プロセスのアプリ サービス モデルが使用されており、アプリ サービスは、ホスト元の拡張機能アプリと同じプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-221">Instead, it uses the single proc app service model in which the app service runs in the same process as the extension app that hosts it.</span></span> <span data-ttu-id="fa30c-222">これは、ホスト アプリとは別のプロセスであり、拡張機能プロセスと、アプリ サービスが実装されたバックグラウンド プロセスとの間でのプロセス間通信を回避することで、パフォーマンス上のメリットと共にプロセス分離のメリットも得ることができます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-222">This is still a different process from the host app, providing the benefits of process separation, while gaining some performance benefits by avoiding cross-process communication between the extension process and the background process that implements the app service.</span></span> <span data-ttu-id="fa30c-223">アプリ サービスをバックグラウンド タスクとして実行する場合と同じプロセスで実行する場合の相違点については、「[ホスト アプリと同じプロセスで実行するようにアプリ サービスを変換する](convert-app-service-in-process.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-223">See [Convert an app service to run in the same process as its host app](convert-app-service-in-process.md) to see the difference between an app service that runs as a background task versus in the same process.</span></span>

<span data-ttu-id="fa30c-224">アプリ サービスが有効になると、`OnBackgroundActivate()` が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-224">The system makes to `OnBackgroundActivate()` when the app service is activated.</span></span> <span data-ttu-id="fa30c-225">このコードでは、`OnAppServiceRequestReceived()` に到達すると実際のアプリ サービスの呼び出しを処理すると共にハウスキーピング イベントを扱う (取り消しイベントや終了イベントを処理する保留オブジェクトの取得など) ためのイベント ハンドラーをセットアップします。</span><span class="sxs-lookup"><span data-stu-id="fa30c-225">That code sets up event handlers to handle the actual app service call when it comes (`OnAppServiceRequestReceived()`) as well as deal with housekeeping events such as getting a deferral object handling a cancel or closed event.</span></span>

_<span data-ttu-id="fa30c-226">MathExtension プロジェクト内の App.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="fa30c-226">App.xaml.cs in the MathExtension project.</span></span>_
```cs
protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
{
    base.OnBackgroundActivated(args);

    if ( _appServiceInitialized == false ) // Only need to setup the handlers once
    {
        _appServiceInitialized = true;

        IBackgroundTaskInstance taskInstance = args.TaskInstance;
        taskInstance.Canceled += OnAppServicesCanceled;

        AppServiceTriggerDetails appService = taskInstance.TriggerDetails as AppServiceTriggerDetails;
        _appServiceDeferral = taskInstance.GetDeferral();
        _appServiceConnection = appService.AppServiceConnection;
        _appServiceConnection.RequestReceived += OnAppServiceRequestReceived;
        _appServiceConnection.ServiceClosed += AppServiceConnection_ServiceClosed;
    }
}
```

<span data-ttu-id="fa30c-227">拡張機能の作業を行うコードは、`OnAppServiceRequestReceived()` に記述されています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-227">The code that does the work of the extension is in `OnAppServiceRequestReceived()`.</span></span> <span data-ttu-id="fa30c-228">この関数は、アプリ サービスの起動時に呼び出され、計算を実行します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-228">This function is called when the app service is invoked to perform a calculation.</span></span> <span data-ttu-id="fa30c-229">必要な値を **ValueSet** から抽出し、</span><span class="sxs-lookup"><span data-stu-id="fa30c-229">It extracts the values it needs from the **ValueSet**.</span></span> <span data-ttu-id="fa30c-230">計算を実行できる場合は、ホストから返される **ValueSet** の中で、**Result** というキーを使用して結果を出力します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-230">If it can do the calculation, it puts the result, under a key named **Result**, in the **ValueSet** that is returned to the host.</span></span> <span data-ttu-id="fa30c-231">このホストと拡張機能の通信方法について定義されているプロトコルにより、**Result** キーがあれば成功、それ以外の場合は失敗を示します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-231">Recall that according to the protocol defined for how this host and its extensions will communicate, the presence of a **Result** key will indicate success; otherwise failure.</span></span>

_<span data-ttu-id="fa30c-232">MathExtension プロジェクト内の App.xaml.cs</span><span class="sxs-lookup"><span data-stu-id="fa30c-232">App.xaml.cs in the MathExtension project.</span></span>_
```cs
private async void OnAppServiceRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
{
    // Get a deferral because we use an awaitable API below (SendResponseAsync()) to respond to the message
    // and we don't want this call to get cancelled while we are waiting.
    AppServiceDeferral messageDeferral = args.GetDeferral();
    ValueSet message = args.Request.Message;
    ValueSet returnMessage = new ValueSet();

    double? arg1 = Convert.ToDouble(message["arg1"]);
    double? arg2 = Convert.ToDouble(message["arg2"]);
    if (arg1.HasValue && arg2.HasValue)
    {
        returnMessage.Add("Result", Math.Pow(arg1.Value, arg2.Value)); // For this sample, the presence of a "Result" key will mean the call succeeded
    }

    await args.Request.SendResponseAsync(returnMessage);
    messageDeferral.Complete();
}
```

## <a name="manage-extensions"></a><span data-ttu-id="fa30c-233">拡張機能を管理する</span><span class="sxs-lookup"><span data-stu-id="fa30c-233">Manage extensions</span></span>

<span data-ttu-id="fa30c-234">ここまで、ホストと拡張機能の間の関係を実装する方法を見てきました。次に、システムにインストールされている拡張機能をホストが検出し、拡張機能を含むパッケージの追加と削除に対応する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="fa30c-234">Now that we've seen how to implement the relationship between a host and its extensions, let's see how a host finds  extensions installed on the system and reacts to the addition and removal of packages containing extensions.</span></span>

<span data-ttu-id="fa30c-235">Microsoft Store では、拡張機能がパッケージとして提供されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-235">The Microsoft Store delivers extensions as packages.</span></span> <span data-ttu-id="fa30c-236">[AppExtensionCatalog](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions.appextensioncatalog) は、ホストの拡張機能コントラクト名に一致する拡張機能が含まれたインストール済みパッケージを検出し、ホストに関連するアプリ拡張機能パッケージがインストールまたは削除された場合に発生するイベントを提供します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-236">The [AppExtensionCatalog](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions.appextensioncatalog) finds installed packages that contain extensions matching the host's extension contract name, and supplies events that fire when an app extension package relevant to the host is installed or removed.</span></span>

<span data-ttu-id="fa30c-237">コード サンプルの `ExtensionManager` クラス (**MathExtensionHost** プロジェクトの **ExtensionManager.cs** に定義されている) は、拡張機能を読み込み、拡張機能パッケージのインストールおよびアンインストールに応答するためのロジックをラップしています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-237">In the code sample, the `ExtensionManager` class (defined in **ExtensionManager.cs** in the **MathExtensionHost** project) wraps the logic for loading extensions and responding to extension package installs and uninstalls.</span></span>

<span data-ttu-id="fa30c-238">`ExtensionManager` コンストラクターは `AppExtensionCatalog` を使用して、ホストと同じ拡張機能コントラクト名を持つアプリ拡張機能をシステム上で検出します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-238">The `ExtensionManager` constructor uses the `AppExtensionCatalog` to find the app extensions on the system that have the same extension contract name as the host:</span></span>

_<span data-ttu-id="fa30c-239">MathExtensionHost プロジェクト内の ExtensionManager.cs</span><span class="sxs-lookup"><span data-stu-id="fa30c-239">ExtensionManager.cs in the MathExtensionHost project.</span></span>_
```cs
public ExtensionManager(string extensionContractName)
{
   // catalog & contract
   ExtensionContractName = extensionContractName;
   _catalog = AppExtensionCatalog.Open(ExtensionContractName);
   ...
}
```

<span data-ttu-id="fa30c-240">拡張機能パッケージがインストールされると、`ExtensionManager` は、ホストと同じ拡張機能コントラクト名を持つパッケージ内の拡張機能に関する情報を収集します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-240">When an extension package is installed, the `ExtensionManager` gathers information about the extensions in the package that have the same extension contract name as the host.</span></span> <span data-ttu-id="fa30c-241">インストールに更新プログラムが含まれている場合もあり、その場合は影響を受ける拡張機能の情報も更新されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-241">An install may represent an update in which case the affected extension's information is updated.</span></span> <span data-ttu-id="fa30c-242">拡張機能パッケージがアンインストールされると、`ExtensionManager` は、どの拡張機能が利用できなくなったのかをユーザーが認識できるように、影響を受ける拡張機能に関する情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-242">When an extension package is uninstalled, the `ExtensionManager` removes information about the affected extensions so that the user knows which extensions are no longer available.</span></span>

<span data-ttu-id="fa30c-243">`Extension` クラス (**MathExtensionHost** プロジェクトの **ExtensionManager.cs** で定義されている) は、コード サンプルで拡張機能の ID、説明、ロゴ、およびアプリ固有の情報 (ユーザーによって拡張機能が有効化されているかどうかなど) にアクセスするために作成されました。</span><span class="sxs-lookup"><span data-stu-id="fa30c-243">The `Extension` class (defined in **ExtensionManager.cs** in the **MathExtensionHost** project) was created for the code sample to access an extension's ID, description, logo, and app specific information such as whether the user has enabled the extension.</span></span>

<span data-ttu-id="fa30c-244">拡張機能が読み込まれている (**ExtensionManager.cs** の `Load()` をご覧ください) とは、パッケージの状態が正常であり、その拡張機能の ID、ロゴ、説明、パブリック フォルダー (このサンプルでは使用しませんが取得方法のみ示しています) が取得済みであるということを指します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-244">To say that the extension is loaded (see `Load()` in **ExtensionManager.cs**) means that the package status is fine and that we've obtained its ID, logo, description, and public folder (which we don't use in this sample-its just to show how you get it).</span></span> <span data-ttu-id="fa30c-245">拡張機能パッケージ自体は読み込まれません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-245">The extension package itself isn't being loaded.</span></span>

<span data-ttu-id="fa30c-246">どの拡張機能についてユーザーへの提示を停止するかを追跡するには、アンロードの概念を使用します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-246">The concept of unloading is used for keeping track of which extensions should no longer be presented to the user.</span></span>

<span data-ttu-id="fa30c-247">`ExtensionManager` は、拡張機能、名前、説明、ロゴを UI にデータ バインドできるように、コレクション `Extension` のインスタンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-247">The `ExtensionManager` provides a collection `Extension` instances so that the extensions, their names, descriptions, and logos can be data bound to UI.</span></span> <span data-ttu-id="fa30c-248">**ExtensionsTab** ページは、このコレクションにバインドされ、拡張機能の有効化、無効化、削除を行うための UI を提供します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-248">The **ExtensionsTab** page binds to this collection and provides UI for enabling/disabling extensions as well as removing them.</span></span>

![[拡張機能] タブの UI 例](images/mathextensionhost-extensiontab.png)

 <span data-ttu-id="fa30c-250">拡張機能が削除されると、システムは、この拡張機能が含まれる (他の拡張機能が含まれている可能性もある) パッケージをアンインストールするかどうかの確認をユーザーに求めるメッセージを表示します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-250">When an extension is removed, the system prompts the user to verify that they want to uninstall the package that contains the extension (and possibly contains other extensions).</span></span> <span data-ttu-id="fa30c-251">ユーザーが同意するとパッケージがアンインストールされ、アンインストールされたパッケージ内の拡張機能が、ホスト アプリで利用可能な拡張機能の一覧から `ExtensionManager` によって削除されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-251">If the user agrees, the package is uninstalled and the `ExtensionManager` removes the extensions in the uninstalled package from the list of extensions available to the host app.</span></span>

 ![アンインストール用 UI](images/mathextensionhost-uninstall.png)

## <a name="debugging-app-extensions-and-hosts"></a><span data-ttu-id="fa30c-253">アプリ拡張機能とホストのデバッグ</span><span class="sxs-lookup"><span data-stu-id="fa30c-253">Debugging app extensions and hosts</span></span>

<span data-ttu-id="fa30c-254">拡張機能のホストと拡張機能は、同じソリューションに属していないことが一般的です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-254">Often, the extension host and extension are not part of the same solution.</span></span> <span data-ttu-id="fa30c-255">この場合、ホストと拡張機能をデバッグするには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="fa30c-255">In that case, to debug the host and the extension:</span></span>

1. <span data-ttu-id="fa30c-256">Visual Studio の 1 つ目のインスタンスでホスト プロジェクトを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-256">Load your host project in one instance of Visual Studio.</span></span>
2. <span data-ttu-id="fa30c-257">Visual Studio の 2 つ目のインスタンスで拡張機能を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-257">Load your extension in another instance of Visual Studio.</span></span>
3. <span data-ttu-id="fa30c-258">デバッガーでホスト アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-258">Launch your host app in the debugger.</span></span>
4. <span data-ttu-id="fa30c-259">デバッガーで拡張機能アプリを起動します </span><span class="sxs-lookup"><span data-stu-id="fa30c-259">Launch the extension app in the debugger.</span></span> <span data-ttu-id="fa30c-260">(拡張機能のデバッグではなく展開を行う場合、ホストのパッケージ インストール イベントをテストするには、**[ビルド] &gt; [ソリューションの配置]** を選択します)。</span><span class="sxs-lookup"><span data-stu-id="fa30c-260">(If you want to deploy the extension, rather than debug it, to test the host's package install event, do **Build &gt; Deploy Solution**, instead).</span></span>

<span data-ttu-id="fa30c-261">これで、ホスト内と拡張機能内のブレークポイントにヒットできます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-261">Now you will be able to hit breakpoints in the host and the extension.</span></span>
<span data-ttu-id="fa30c-262">拡張機能アプリ自体のデバッグを開始すると、アプリ用に空白のウィンドウが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-262">If you start debugging the extension app itself, you will see a blank window for the app.</span></span> <span data-ttu-id="fa30c-263">空白のウィンドウが表示されないようにするには、拡張機能プロジェクトのデバッグ設定で、開始時にアプリが起動ではなくデバッグされるように変更できます (拡張機能プロジェクトを右クリックし、**[プロパティ]** > **[デバッグ]** > **[起動しないが、開始時にコードをデバッグ]** を選択)。この場合も拡張機能プロジェクトのデバッグを開始 (**F5**) する必要がありますが、開始は、ホストが拡張機能をアクティブ化し、拡張機能内のブレークポイントがヒットした後になります。</span><span class="sxs-lookup"><span data-stu-id="fa30c-263">If you don't want to see the blank window, you can change the debugging settings for the extension project to not launch the app but instead debug it when it starts (right-click the extension project, **Properties** > **Debug** > select **Do not launch, but debug my code when it starts**)  You'll still need to start debugging (**F5**) the extension project, but it will  wait until the host activates the extension and then your breakpoints in the extension will be hit.</span></span>

**<span data-ttu-id="fa30c-264">コード サンプルをデバッグする</span><span class="sxs-lookup"><span data-stu-id="fa30c-264">Debug the code sample</span></span>**

<span data-ttu-id="fa30c-265">コード サンプルでは、ホストと拡張機能が同じソリューションに属しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-265">In the code sample, the host and the extension are in the same solution.</span></span> <span data-ttu-id="fa30c-266">デバッグを行うには、以下の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="fa30c-266">Do the following to debug:</span></span>

1. <span data-ttu-id="fa30c-267">**MathExtensionHost** がスタートアップ プロジェクトに設定されていることを確認します (**MathExtensionHost** プロジェクトを右クリックし、**[スタートアップ プロジェクトに設定]** をクリック)。</span><span class="sxs-lookup"><span data-stu-id="fa30c-267">Ensure that **MathExtensionHost** is the startup project (right-click the **MathExtensionHost** project, click **Set as StartUp project**).</span></span>
2. <span data-ttu-id="fa30c-268">**MathExtensionHost** プロジェクトに含まれる ExtensionManager.cs 内で、`Invoke` にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-268">Put a breakpoint on `Invoke` in ExtensionManager.cs, in the **MathExtensionHost** project.</span></span>
3. <span data-ttu-id="fa30c-269">**F5** キーを押して **MathExtensionHost** プロジェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-269">**F5** to run the **MathExtensionHost** project.</span></span>
4. <span data-ttu-id="fa30c-270">**MathExtension** プロジェクトに含まれる App.xaml.cs 内で、`OnAppServiceRequestReceived` にブレークポイントを設定します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-270">Put a breakpoint on `OnAppServiceRequestReceived` in App.xaml.cs in the **MathExtension** project.</span></span>
5. <span data-ttu-id="fa30c-271">**MathExtension** プロジェクトのデバッグを開始します (**MathExtension** プロジェクトで右クリックし、**[デバッグ] > [新しいインスタンスを開始]** を選択)。これにより、プロジェクトが展開され、ホスト内のパッケージ インストール イベントがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-271">Start debugging the **MathExtension** project (right-click the **MathExtension** project, **Debug > Start new instance**) which will deploy it and trigger the package install event in the host.</span></span>
6. <span data-ttu-id="fa30c-272">**MathExtensionHost** アプリで、**[Calculation]** (計算) ページに移動し、**[x^y]** をクリックして拡張機能を有効化します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-272">In the **MathExtensionHost** app, navigate to the **Calculation** page, and click **x^y** to activate the extension.</span></span> <span data-ttu-id="fa30c-273">最初に `Invoke()` ブレークポイントがヒットし、拡張機能のアプリ サービス呼び出しが行われたことを確認できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-273">The `Invoke()` breakpoint is hit first and you can see the extensions app service call being made.</span></span> <span data-ttu-id="fa30c-274">次に、拡張機能内の `OnAppServiceRequestReceived()` メソッドがヒットし、アプリ サービスによって結果が計算され、返されることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-274">Then the `OnAppServiceRequestReceived()` method in the extension is hit, and you can see the app service calculate the result and return it.</span></span>

**<span data-ttu-id="fa30c-275">アプリ サービスとして実装された拡張機能のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="fa30c-275">Troubleshooting extensions implemented as an app service</span></span>**

<span data-ttu-id="fa30c-276">拡張機能のホストが拡張機能のアプリ サービスに接続できない場合は、`<uap:AppService Name="...">` 属性が `<Service>` 要素の設定に一致しているか確認してください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-276">If your extension host has trouble connecting to the app service for your extension, ensure that the `<uap:AppService Name="...">` attribute matches what you put in your `<Service>` element.</span></span> <span data-ttu-id="fa30c-277">これらが一致していないと、拡張機能からホストに渡されるサービス名が、実装されているサービス名に一致せず、ホストは拡張機能を有効化できません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-277">If they don't match, the service name that your extension provides the host won't match the app service name you implemented, and the host won't be able to activate your extension.</span></span>

_<span data-ttu-id="fa30c-278">MathExtension プロジェクト内の Package.appxmanifest</span><span class="sxs-lookup"><span data-stu-id="fa30c-278">Package.appxmanifest in the MathExtension project:</span></span>_
```xml
<Extensions>
   <uap:Extension Category="windows.appService">
     <uap:AppService Name="com.microsoft.sqrtservice" />      <!-- This must match the contents of <Service>...</Service> -->
   </uap:Extension>
   <uap3:Extension Category="windows.appExtension">
     <uap3:AppExtension Name="Microsoft.com.MathExt" Id="sqrt" DisplayName="Sqrt(x)" Description="Square root" PublicFolder="Public">
       <uap3:Properties>
         <Service>com.microsoft.powservice</Service>   <!-- this must match <uap:AppService Name=...> -->
       </uap3:Properties>
     </uap3:AppExtension>
   </uap3:Extension>
</Extensions>   
```

## <a name="a-checklist-of-basic-scenarios-to-test"></a><span data-ttu-id="fa30c-279">基本的なテスト シナリオのチェックリスト</span><span class="sxs-lookup"><span data-stu-id="fa30c-279">A checklist of basic scenarios to test</span></span>

<span data-ttu-id="fa30c-280">拡張機能のホストをビルドして、拡張機能のサポートをテストする準備ができたら、次の基本的なシナリオを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="fa30c-280">When you build an extension host and are ready to test how well it supports extensions, here are some basic scenarios to try:</span></span>

- <span data-ttu-id="fa30c-281">ホストを実行してから拡張機能アプリを展開する</span><span class="sxs-lookup"><span data-stu-id="fa30c-281">Run the host and then deploy an extension app</span></span>  
    - <span data-ttu-id="fa30c-282">ホストでは、呼び出された新しい拡張機能を実行中に検出できますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-282">Does the host pick up new extensions that come along while its running?</span></span>  
- <span data-ttu-id="fa30c-283">拡張機能アプリを展開してからホストを実行する</span><span class="sxs-lookup"><span data-stu-id="fa30c-283">Deploy the extension app and then deploy and run the host.</span></span>
    - <span data-ttu-id="fa30c-284">ホストでは、以前から存在する拡張機能を検出できますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-284">Does the host pick up previously-existing extensions?</span></span>  
- <span data-ttu-id="fa30c-285">ホストを実行してから拡張機能アプリを削除する</span><span class="sxs-lookup"><span data-stu-id="fa30c-285">Run the host and then remove extension app.</span></span>
    - <span data-ttu-id="fa30c-286">ホストでは、削除を正しく検出できますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-286">Does the host detect the removal correctly?</span></span>
- <span data-ttu-id="fa30c-287">ホストを実行し、拡張機能アプリを新しいバージョンに更新する</span><span class="sxs-lookup"><span data-stu-id="fa30c-287">Run the host and then update the extension app to a newer version.</span></span>
    - <span data-ttu-id="fa30c-288">ホストでは変化を検出し、拡張機能の古いバージョンを正しくアンロードできますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-288">Does the host pick up the change and unload the old versions of the extension properly?</span></span>  

**<span data-ttu-id="fa30c-289">高度なテスト シナリオ</span><span class="sxs-lookup"><span data-stu-id="fa30c-289">Advanced scenarios to test:</span></span>**

- <span data-ttu-id="fa30c-290">ホストを実行し、拡張機能アプリをリムーバブル メディアに移動して、そのメディアを取り外す</span><span class="sxs-lookup"><span data-stu-id="fa30c-290">Run the host, move the extension app to removable media, remove the media</span></span>
    - <span data-ttu-id="fa30c-291">ホストでは、パッケージ状態の変化を検出し、拡張機能を無効にできますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-291">Does the host detect the change in package status and disable the extension?</span></span>
- <span data-ttu-id="fa30c-292">ホストを実行してから、拡張機能アプリを無効化する (無効に設定する、別の署名を使用するなど)</span><span class="sxs-lookup"><span data-stu-id="fa30c-292">Run the host, then corrupt the extension app (make it invalid, signed differently, etc.)</span></span>
    - <span data-ttu-id="fa30c-293">ホストでは、改ざんされた拡張機能を検出し、適切に処理できますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-293">Does the host detect the tampered extension and handle it correctly?</span></span>
- <span data-ttu-id="fa30c-294">ホストを実行し、無効なコンテンツまたはプロパティを持つ拡張機能アプリを展開する</span><span class="sxs-lookup"><span data-stu-id="fa30c-294">Run the host, then deploy an extension app that has invalid content or properties</span></span>
    - <span data-ttu-id="fa30c-295">ホストでは、無効なコンテンツを検出し、適切に処理できますか?</span><span class="sxs-lookup"><span data-stu-id="fa30c-295">Does the host detect invalid content and handle it correctly?</span></span>

## <a name="design-considerations"></a><span data-ttu-id="fa30c-296">設計時の考慮事項</span><span class="sxs-lookup"><span data-stu-id="fa30c-296">Design considerations</span></span>

- <span data-ttu-id="fa30c-297">利用可能な拡張機能をユーザーに提示し、ユーザーによる有効化/無効化を可能にするための UI を用意します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-297">Provide UI that shows the user which extensions are available and allows them to enable/disable them.</span></span> <span data-ttu-id="fa30c-298">パッケージがオフラインになったなどの理由で利用不可能になった拡張機能を示すグリフの追加も検討します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-298">You might also consider adding glyphs for extensions that become unavailable because a package goes offline, etc.</span></span>
- <span data-ttu-id="fa30c-299">拡張機能を入手できる場所にユーザーを誘導します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-299">Direct the user to where they can get extensions.</span></span> <span data-ttu-id="fa30c-300">拡張機能のページに Microsoft Store 検索クエリを設置して、対象のアプリと共に使用できる拡張機能の一覧が提示されるようにしておくこともできます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-300">Perhaps your extension page can provide a Microsoft Store search query that brings up a list of extensions that can be used with your app.</span></span>
- <span data-ttu-id="fa30c-301">拡張機能の追加と削除をユーザーに通知する方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-301">Consider how to notify the user of the addition and removal of extensions.</span></span> <span data-ttu-id="fa30c-302">新しい拡張機能がインストールされた場合の通知を作成し、その拡張機能の有効化をユーザーに案内することもできます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-302">You might create a notification for when a new extension is installed and invite the user to enable it.</span></span> <span data-ttu-id="fa30c-303">ユーザーによる管理を尊重できるように、拡張機能は既定で無効にします。</span><span class="sxs-lookup"><span data-stu-id="fa30c-303">Extensions should be disabled by default so that users are in control.</span></span>

## <a name="how-app-extensions-differ-from-optional-packages"></a><span data-ttu-id="fa30c-304">アプリ拡張機能とオプション パッケージの相違点</span><span class="sxs-lookup"><span data-stu-id="fa30c-304">How app extensions differ from optional packages</span></span>

<span data-ttu-id="fa30c-305">[オプション パッケージ](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)とアプリ拡張機能との大きな相違点は、エコシステムが開いているか閉じているかという点と、パッケージが従属しているか独立しているかという点です。</span><span class="sxs-lookup"><span data-stu-id="fa30c-305">The key differentiator between [optional packages](https://docs.microsoft.com/windows/uwp/packaging/optional-packages) and app extensions are open ecosystem versus closed ecosystem, and dependent package versus independent package.</span></span>

<span data-ttu-id="fa30c-306">アプリ拡張機能は、開いたエコシステムに属しています。</span><span class="sxs-lookup"><span data-stu-id="fa30c-306">App extensions participate in an open ecosystem.</span></span> <span data-ttu-id="fa30c-307">アプリでアプリ拡張機能をホストできる場合、拡張機能からの情報の請け渡し方法に従って、そのホストに対する拡張機能をだれでも作成できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-307">If your app can host app extensions, anyone can write an extension for your host as long as they comply with your method of passing/receiving information from the extension.</span></span> <span data-ttu-id="fa30c-308">この点が、閉じたエコシステムに属しているオプション パッケージと異なります。閉じたエコシステムでは、そのアプリと連携できるオプション パッケージをだれが作成できるのかを発行元が決定します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-308">This differs from optional packages which participate in a closed ecosystem where the publisher decides who is allowed to make an optional package that can be used with the app.</span></span>

<span data-ttu-id="fa30c-309">アプリ拡張機能は、独立したパッケージであり、スタンドアロン アプリにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-309">App extensions are independent packages and can be standalone apps.</span></span> <span data-ttu-id="fa30c-310">展開に関して別のアプリに依存することはできません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-310">They cannot have a deployment dependency on another app.</span></span><span data-ttu-id="fa30c-311">一方、オプション パッケージは、プライマリ パッケージを必要とし、プライマリ パッケージがないと実行できません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-311">Optional packages require the primary package and cannot run without it.</span></span>

<span data-ttu-id="fa30c-312">オプション パッケージの好例はゲームの拡張機能パックです。ゲームに緊密にバインドされ、ゲームから独立して実行することはできません。また、拡張機能パックは開発者エコシステム内のだれが開発してもよいというものではありません。</span><span class="sxs-lookup"><span data-stu-id="fa30c-312">An expansion pack for a game would be a good candidate for an optional package because it's tightly bound to the game, it can't run independently of the game, and you may not want expansion packs to be created by just any developer in the ecosystem.</span></span>

<span data-ttu-id="fa30c-313">このゲームにカスタマイズ可能な UI アドオンまたはテーマがある場合は、アプリ拡張機能の使用をお勧めします。拡張機能を提供するアプリは単独で実行でき、どのサード パーティでもそのようなアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-313">If that same game had customizable UI add-ons or theming, then an app extension could be a good choice because the app providing the extension could run on its own, and any 3rd party could make them.</span></span>

## <a name="remarks"></a><span data-ttu-id="fa30c-314">解説</span><span class="sxs-lookup"><span data-stu-id="fa30c-314">Remarks</span></span>

<span data-ttu-id="fa30c-315">このトピックでは、アプリ拡張機能を紹介します。</span><span class="sxs-lookup"><span data-stu-id="fa30c-315">This topic provides an introduction to app extensions.</span></span> <span data-ttu-id="fa30c-316">重要な点として、ホストを作成して Package.appxmanifest ファイル内でホストとしてマークすること、拡張機能を作成して Package.appxmanifest ファイル内で拡張機能としてマークすること、拡張機能の実装方法 (アプリ サービス、バックグラウンド タスク、その他の方法) を決定すること、ホストと拡張機能との間の通信方法を定義すること、拡張機能へのアクセスと管理に [AppExtensions API](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions) を使用することが挙げられます。</span><span class="sxs-lookup"><span data-stu-id="fa30c-316">The key things to note are the creation of the host and marking it as such in its Package.appxmanifest file, creating the extension and marking it as such in its Package.appxmanifest file, determining how to implement the extension (such as an app service, background task, or other means), defining how the host will communicate with extensions, and using the [AppExtensions API](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions) to access and manage extensions.</span></span>

## <a name="related-topics"></a><span data-ttu-id="fa30c-317">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fa30c-317">Related topics</span></span>

* [<span data-ttu-id="fa30c-318">アプリ拡張機能の概要</span><span class="sxs-lookup"><span data-stu-id="fa30c-318">Introduction to App Extensions</span></span>](https://blogs.msdn.microsoft.com/appinstaller/2017/05/01/introduction-to-app-extensions/)
* [<span data-ttu-id="fa30c-319">アプリ拡張機能に関する Build 2016 セッション</span><span class="sxs-lookup"><span data-stu-id="fa30c-319">Build 2016 session about app extensions</span></span>](https://channel9.msdn.com/Events/Build/2016/B808)
* [<span data-ttu-id="fa30c-320">Build 2016 のアプリ拡張機能コード サンプル</span><span class="sxs-lookup"><span data-stu-id="fa30c-320">Build 2016 app extension code sample</span></span>](https://github.com/Microsoft/App-Extensibility-Sample)
* [<span data-ttu-id="fa30c-321">バックグラウンド タスクによるアプリのサポート</span><span class="sxs-lookup"><span data-stu-id="fa30c-321">Support your app with background tasks</span></span>](support-your-app-with-background-tasks.md)
* <span data-ttu-id="fa30c-322">[アプリ サービスの作成と利用の方法](how-to-create-and-consume-an-app-service.md)</span><span class="sxs-lookup"><span data-stu-id="fa30c-322">[How to create and consume an app service](how-to-create-and-consume-an-app-service.md).</span></span>
* [<span data-ttu-id="fa30c-323">AppExtensions 名前空間</span><span class="sxs-lookup"><span data-stu-id="fa30c-323">AppExtensions namespace</span></span>](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appextensions)
* [<span data-ttu-id="fa30c-324">サービス、拡張機能、パッケージでアプリを拡張する</span><span class="sxs-lookup"><span data-stu-id="fa30c-324">Extend your app with services, extensions, and packages</span></span>](https://docs.microsoft.com/windows/uwp/launch-resume/extend-your-app-with-services-extensions-packages)
