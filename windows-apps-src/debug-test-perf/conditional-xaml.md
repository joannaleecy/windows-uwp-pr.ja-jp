---
author: jwmsft
title: 条件付き XAML
description: 以前のバージョンとの互換性を保ちながら、XAML マークアップで新しい API を使います
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 46954968f11f000025ee352676d3f0d17ecb9621
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7100868"
---
# <a name="conditional-xaml"></a><span data-ttu-id="f8140-104">条件付き XAML</span><span class="sxs-lookup"><span data-stu-id="f8140-104">Conditional XAML</span></span>

<span data-ttu-id="f8140-105">*条件付き XAML* は、XAML マークアップで [ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent) メソッドを使う方法を提供するものです。</span><span class="sxs-lookup"><span data-stu-id="f8140-105">*Conditional XAML* provides a way to use the [ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent) method in XAML markup.</span></span> <span data-ttu-id="f8140-106">これにより、分離コードを使わなくても、API の有無に基づいてマークアップでプロパティの設定やオブジェクトのインスタンス化を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8140-106">This lets you set properties and instantiate objects in markup based on the presence of an API without needing to use code behind.</span></span> <span data-ttu-id="f8140-107">要素や属性が選択的に解析され、実行時に利用できるかどうかが判断されます。</span><span class="sxs-lookup"><span data-stu-id="f8140-107">It selectively parses elements or attributes to determine whether they will be available at runtime.</span></span> <span data-ttu-id="f8140-108">条件ステートメントは実行時に評価されます。条件付き XAML タグで修飾された要素は、**true** と評価された場合に解析され、そうでない場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="f8140-108">Conditional statements are evaluated at runtime, and elements qualified with a conditional XAML tag are parsed if they evaluate to **true**; otherwise, they are ignored.</span></span>

<span data-ttu-id="f8140-109">条件付き XAML は Creators Update (Version 1703、ビルド 15063) 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8140-109">Conditional XAML is available starting with the Creators Update (version 1703, build 15063).</span></span> <span data-ttu-id="f8140-110">条件付き XAML を使用するには、Visual Studio プロジェクトの最小バージョンとしてビルド 15063 (Creators Update) 以降を選択し、ターゲット バージョンを最小バージョンよりも後のバージョンに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8140-110">To use conditional XAML, the Minimum Version of your Visual Studio project must be set to build 15063 (Creators Update) or later, and the Target Version be set to a later version than the Minimum.</span></span> <span data-ttu-id="f8140-111">Visual Studio プロジェクトの構成について詳しくは、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8140-111">See [Version adaptive apps](version-adaptive-apps.md) for more info about configuring your Visual Studio project.</span></span>

> [!NOTE]
> <span data-ttu-id="f8140-112">ビルド 15063 より前のバージョンを最小バージョンとするバージョン アダプティブ アプリを作成するには、XAML ではなく[バージョン アダプティブ コード](version-adaptive-code.md)を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8140-112">To create a version adaptive app with a Minimum Version less than build 15063, you must use [version adaptive code](version-adaptive-code.md), not XAML.</span></span>

<span data-ttu-id="f8140-113">ApiInformation に関する重要な背景情報と API コントラクトについては、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8140-113">For important background info about ApiInformation and API contracts, see [Version adaptive apps](version-adaptive-apps.md).</span></span>

## <a name="conditional-namespaces"></a><span data-ttu-id="f8140-114">条件付き名前空間</span><span class="sxs-lookup"><span data-stu-id="f8140-114">Conditional namespaces</span></span>

<span data-ttu-id="f8140-115">XAML で条件メソッドを使うには、最初にページの最上部で条件付き [XAML 名前空間](../xaml-platform/xaml-namespaces-and-namespace-mapping.md)を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8140-115">To use a conditional method in XAML, you must first declare a conditional [XAML namespace](../xaml-platform/xaml-namespaces-and-namespace-mapping.md) at the top of your page.</span></span> <span data-ttu-id="f8140-116">条件付き名前空間の擬似コード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f8140-116">Here's a psuedo-code example of a conditional namespace:</span></span>

```xaml
xmlns:myNamespace="schema?conditionalMethod(parameter)"
```

<span data-ttu-id="f8140-117">条件付き名前空間は、'?' を区切り文字として 2 つの部分に分けられます。</span><span class="sxs-lookup"><span data-stu-id="f8140-117">A conditional namespace can be broken down into two parts separated by the '?' delimiter.</span></span> 

- <span data-ttu-id="f8140-118">区切り文字の前のコンテンツには、参照しようとしている API を含む名前空間またはスキーマを指定します。</span><span class="sxs-lookup"><span data-stu-id="f8140-118">The content preceding the delimiter indicates the namespace or schema that contains the API being referenced.</span></span> 
- <span data-ttu-id="f8140-119">区切り文字 '?' の後のコンテンツは、条件付き名前空間が **true** と **false** のどちらに評価されるかを決定する条件メソッドを表します。</span><span class="sxs-lookup"><span data-stu-id="f8140-119">The content after the '?' delimiter represents the conditional method that determines whether the conditional namespace evaluates to **true** or **false**.</span></span>

<span data-ttu-id="f8140-120">ほとんどの場合、スキーマは、次に示す既定の XAML 名前空間になります。</span><span class="sxs-lookup"><span data-stu-id="f8140-120">In most cases, the schema will be the default XAML namespace:</span></span>

```xaml
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
```

<span data-ttu-id="f8140-121">条件付き XAML では、次の条件メソッドがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f8140-121">Conditional XAML supports the following conditional methods:</span></span>

<span data-ttu-id="f8140-122">メソッド</span><span class="sxs-lookup"><span data-stu-id="f8140-122">Method</span></span> | <span data-ttu-id="f8140-123">逆条件</span><span class="sxs-lookup"><span data-stu-id="f8140-123">Inverse</span></span>
------ | -------
<span data-ttu-id="f8140-124">IsApiContractPresent(ContractName, VersionNumber)</span><span class="sxs-lookup"><span data-stu-id="f8140-124">IsApiContractPresent(ContractName, VersionNumber)</span></span> | <span data-ttu-id="f8140-125">IsApiContractNotPresent(ContractName, VersionNumber)</span><span class="sxs-lookup"><span data-stu-id="f8140-125">IsApiContractNotPresent(ContractName, VersionNumber)</span></span>
<span data-ttu-id="f8140-126">IsTypePresent(ControlType)</span><span class="sxs-lookup"><span data-stu-id="f8140-126">IsTypePresent(ControlType)</span></span> | <span data-ttu-id="f8140-127">IsTypeNotPresent(ControlType)</span><span class="sxs-lookup"><span data-stu-id="f8140-127">IsTypeNotPresent(ControlType)</span></span>
<span data-ttu-id="f8140-128">IsPropertyPresent(ControlType, PropertyName)</span><span class="sxs-lookup"><span data-stu-id="f8140-128">IsPropertyPresent(ControlType, PropertyName)</span></span> | <span data-ttu-id="f8140-129">IsPropertyNotPresent(ControlType, PropertyName)</span><span class="sxs-lookup"><span data-stu-id="f8140-129">IsPropertyNotPresent(ControlType, PropertyName)</span></span>

<span data-ttu-id="f8140-130">この記事の後のセクションで、これらのメソッドについてさらに説明します。</span><span class="sxs-lookup"><span data-stu-id="f8140-130">We discuss these methods further in later sections of this article.</span></span>

> [!NOTE]
> <span data-ttu-id="f8140-131">IsApiContractPresent と IsApiContractNotPresent を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f8140-131">We recommend you use IsApiContractPresent and IsApiContractNotPresent.</span></span> <span data-ttu-id="f8140-132">その他の条件は、Visual Studio のデザイン エクスペリエンスでは完全にはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f8140-132">Other conditionals are not fully supported in the Visual Studio design experience.</span></span>

## <a name="create-a-namespace-and-set-a-property"></a><span data-ttu-id="f8140-133">名前空間の作成とプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="f8140-133">Create a namespace and set a property</span></span>

<span data-ttu-id="f8140-134">この例では、アプリが Fall Creators Update 以降で実行されている場合に、テキスト ブロックのコンテンツとして "Hello, Conditional XAML" と表示します。以前のバージョンで実行されている場合、コンテンツは何も表示されません。</span><span class="sxs-lookup"><span data-stu-id="f8140-134">In this example, you display, "Hello, Conditional XAML", as the content of a text block if the app runs on the Fall Creators Update or later, and default to no content if it's on a previous version.</span></span>

<span data-ttu-id="f8140-135">まず、"contract5Present" というプレフィックスのカスタム名前空間を定義し、[TextBlock.Text](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.Text) プロパティを含むスキーマとして、既定の XAML 名前空間 (http://schemas.microsoft.com/winfx/2006/xaml/presentation) を使います。</span><span class="sxs-lookup"><span data-stu-id="f8140-135">First, define a custom namespace with the prefix 'contract5Present' and use the default XAML namespace (http://schemas.microsoft.com/winfx/2006/xaml/presentation) as the schema containing the [TextBlock.Text](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.Text) property.</span></span> <span data-ttu-id="f8140-136">これを条件付き名前空間にするために、スキーマの後に区切り文字 '?' </span><span class="sxs-lookup"><span data-stu-id="f8140-136">To make this a conditional namespace, add the ‘?’</span></span> <span data-ttu-id="f8140-137">を追加します。</span><span class="sxs-lookup"><span data-stu-id="f8140-137">delimiter after the schema.</span></span>

<span data-ttu-id="f8140-138">次に、Fall Creators Update 以降を実行しているデバイスで **true** を返す条件を定義します。</span><span class="sxs-lookup"><span data-stu-id="f8140-138">You then define a conditional that returns **true** on devices that are running the Fall Creators Update or later.</span></span> <span data-ttu-id="f8140-139">ApiInformation の **IsApiContractPresent** メソッドを使って、UniversalApiContract の 5 番目のバージョンをチェックします。</span><span class="sxs-lookup"><span data-stu-id="f8140-139">You use the ApiInformation method **IsApiContractPresent** to check for the 5th version of the UniversalApiContract.</span></span> <span data-ttu-id="f8140-140">バージョン 5 の UniversalApiContract は Fall Creators Update (SDK 16299) でリリースされました。</span><span class="sxs-lookup"><span data-stu-id="f8140-140">Version 5 of the UniversalApiContract was released with the Fall Creators Update (SDK 16299).</span></span>

```xaml
xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
```

<span data-ttu-id="f8140-141">名前空間を定義したら、TextBox の Text プロパティに名前空間プレフィックスを追加して、実行時に条件付きで設定されるプロパティとなるように指定します。</span><span class="sxs-lookup"><span data-stu-id="f8140-141">After the namespace is defined, you prepend the namespace prefix to the Text property of your TextBox to qualify it as a property that should be set conditionally at runtime.</span></span>

```xaml
<TextBlock contract5Present:Text="Hello, Conditional XAML"/>
```

<span data-ttu-id="f8140-142">XAML 全体は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8140-142">Here's the complete XAML.</span></span>

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock contract5Present:Text="Hello, Conditional XAML"/>
    </Grid>
</Page>
```

<span data-ttu-id="f8140-143">この例を Fall Creators Update で実行すると、"Hello, Conditional XAML" というテキストが表示されます。Creators Update で実行した場合、テキストは表示されません。</span><span class="sxs-lookup"><span data-stu-id="f8140-143">When you run this example on the Fall Creators Update, the text, "Hello, Conditional XAML" is shown; when you run it on the Creators Update, no text is shown.</span></span>

<span data-ttu-id="f8140-144">条件付き XAML を使うと、以前にはコードで実行していた API チェックをマークアップ内で実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="f8140-144">Conditional XAML lets you perform the API checks you can do in code in your markup instead.</span></span> <span data-ttu-id="f8140-145">同じチェックを実行するコードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8140-145">Here's the equivalent code for this check.</span></span>

```csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    textBlock.Text = "Hello, Conditional XAML";
}
```

<span data-ttu-id="f8140-146">IsApiContractPresent メソッドは *contractName* パラメーターとして文字列を受け取りますが、XAML 名前空間の宣言では引用符 (" ") を付けないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f8140-146">Notice that even though the IsApiContractPresent method takes a string for the *contractName* parameter, you don't put it in quotes (" ") in the XAML namespace declaration.</span></span>

## <a name="use-ifelse-conditions"></a><span data-ttu-id="f8140-147">if/else 条件の使用</span><span class="sxs-lookup"><span data-stu-id="f8140-147">Use if/else conditions</span></span>

<span data-ttu-id="f8140-148">前の例では、アプリが Fall Creators Update で実行されている場合にのみ Text プロパティが設定されます。</span><span class="sxs-lookup"><span data-stu-id="f8140-148">In the previous example, the Text property is set only when the app runs on the Fall Creators Update.</span></span> <span data-ttu-id="f8140-149">では、Creators Update での実行時に別のテキストを表示したい場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="f8140-149">But what if you want to show different text when it runs on the Creators Update?</span></span> <span data-ttu-id="f8140-150">たとえば、次のように条件修飾子のない Text プロパティを設定したとします。</span><span class="sxs-lookup"><span data-stu-id="f8140-150">You could try to set the Text property without a conditional qualifier, like this.</span></span>

```xaml
<!-- DO NOT USE -->
<TextBlock Text="Hello, World" contract5Present:Text="Hello, Conditional XAML"/>
```

<span data-ttu-id="f8140-151">これは Creators Update で実行した場合は正しく動作しますが、Fall Creators Update で実行すると、Text プロパティが複数回設定されているというエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="f8140-151">This will work when it runs on the Creators Update, but when it runs on the Fall Creators Update, you get an error saying that the Text property is set more than once.</span></span>

<span data-ttu-id="f8140-152">異なるバージョンの Windows 10 でアプリが実行されているときに別のテキストを設定するには、別の条件を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8140-152">To set different text when the app runs on different versions of Windows 10, you need another condition.</span></span> <span data-ttu-id="f8140-153">条件付き XAML では、このような if/else 条件のシナリオを作成できるように、サポートされている ApiInformation メソッドのそれぞれに対して反対の判定を行うメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="f8140-153">Conditional XAML provides an inverse of each supported ApiInformation method to let you create if/else conditional scenarios like this.</span></span>

<span data-ttu-id="f8140-154">IsApiContractPresent メソッドは、指定したコントラクトとバージョン番号が現在のデバイスに含まれている場合に **true** を返します。</span><span class="sxs-lookup"><span data-stu-id="f8140-154">The IsApiContractPresent method returns **true** if the current device contains the specified contract and version number.</span></span> <span data-ttu-id="f8140-155">たとえば、ユニバーサル API コントラクトの 4 番目のバージョンである Creators Update でアプリが実行されているとします。</span><span class="sxs-lookup"><span data-stu-id="f8140-155">For example, assume your app is running on the Creators Update, which has the 4th version of the universal API Contract.</span></span>

<span data-ttu-id="f8140-156">このとき、パラメーターを変えて IsApiContractPresent を呼び出すと、結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8140-156">Various calls to IsApiContractPresent would have these results:</span></span>

- <span data-ttu-id="f8140-157">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 5) = **false**</span><span class="sxs-lookup"><span data-stu-id="f8140-157">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 5) = **false**</span></span>
- <span data-ttu-id="f8140-158">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 4) = true</span><span class="sxs-lookup"><span data-stu-id="f8140-158">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 4) = true</span></span>
- <span data-ttu-id="f8140-159">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 3) = true</span><span class="sxs-lookup"><span data-stu-id="f8140-159">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 3) = true</span></span>
- <span data-ttu-id="f8140-160">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 2) = true</span><span class="sxs-lookup"><span data-stu-id="f8140-160">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 2) = true</span></span>
- <span data-ttu-id="f8140-161">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 1) = true</span><span class="sxs-lookup"><span data-stu-id="f8140-161">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 1) = true.</span></span>

<span data-ttu-id="f8140-162">IsApiContractNotPresent は、IsApiContractPresent の反対の結果を返します。</span><span class="sxs-lookup"><span data-stu-id="f8140-162">IsApiContractNotPresent returns the inverse of IsApiContractPresent.</span></span> <span data-ttu-id="f8140-163">IsApiContractNotPresent の呼び出し結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f8140-163">Calls to IsApiContractNotPresent would have these results:</span></span>

- <span data-ttu-id="f8140-164">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 5) = **true**</span><span class="sxs-lookup"><span data-stu-id="f8140-164">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 5) = **true**</span></span>
- <span data-ttu-id="f8140-165">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 4) = false</span><span class="sxs-lookup"><span data-stu-id="f8140-165">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 4) = false</span></span>
- <span data-ttu-id="f8140-166">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 3) = false</span><span class="sxs-lookup"><span data-stu-id="f8140-166">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 3) = false</span></span>
- <span data-ttu-id="f8140-167">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 2) = false</span><span class="sxs-lookup"><span data-stu-id="f8140-167">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 2) = false</span></span>
- <span data-ttu-id="f8140-168">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 1) = false</span><span class="sxs-lookup"><span data-stu-id="f8140-168">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 1) = false</span></span>

<span data-ttu-id="f8140-169">逆条件を使うには、**IsApiContractNotPresent** 条件を使う 2 つ目の条件付き XAML 名前空間を作成します。</span><span class="sxs-lookup"><span data-stu-id="f8140-169">To use the inverse condition, you create a second conditional XAML namespace that uses the **IsApiContractNotPresent** conditional.</span></span> <span data-ttu-id="f8140-170">この例では、"contract5NotPresent" というプレフィックスを使います。</span><span class="sxs-lookup"><span data-stu-id="f8140-170">Here, it has the prefix 'contract5NotPresent'.</span></span>

```xaml
xmlns:contract5NotPresent="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)"

xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
```

<span data-ttu-id="f8140-171">両方の名前空間を定義し、次のようにプロパティをプレフィックスで修飾すれば、実行時には一方のプロパティだけが設定されるため、Text プロパティを 2 回記述することができます。</span><span class="sxs-lookup"><span data-stu-id="f8140-171">With both namespaces defined, you can set the Text property twice as long as you prefix them with qualifiers that ensure only one property setting is used at runtime, like this:</span></span>

```xaml
<TextBlock contract5NotPresent:Text="Hello, World"
           contract5Present:Text="Hello, Fall Creators Update"/>
```

<span data-ttu-id="f8140-172">別の例として、ボタンの背景を設定する場合を考えます。</span><span class="sxs-lookup"><span data-stu-id="f8140-172">Here's another example that sets the background of a button.</span></span> <span data-ttu-id="f8140-173">Fall Creators Update 以降では[アクリル素材](../design/style/acrylic.md)機能を利用できるので、アプリが Fall Creators Update で実行されているときは、背景にアクリルを適用することにします。</span><span class="sxs-lookup"><span data-stu-id="f8140-173">The [Acrylic material](../design/style/acrylic.md) feature is available starting with the Fall Creators Update, so you’ll use Acrylic for the background when the app runs on the Fall Creators Update.</span></span> <span data-ttu-id="f8140-174">この機能は以前のバージョンでは利用できないため、その場合は背景を赤に設定します。</span><span class="sxs-lookup"><span data-stu-id="f8140-174">It's not available on earlier versions, so in those cases, you set the background to red.</span></span>

```xaml
<Button Content="Button"
        contract5NotPresent:Background="Red"
        contract5Present:Background="{ThemeResource SystemControlAcrylicElementBrush}"/>
```

## <a name="create-controls-and-bind-properties"></a><span data-ttu-id="f8140-175">コントロールの作成とプロパティのバインド</span><span class="sxs-lookup"><span data-stu-id="f8140-175">Create controls and bind properties</span></span>

<span data-ttu-id="f8140-176">ここまでは条件付き XAML を使ってプロパティを設定する方法を見てきましたが、実行時に利用できる API コントラクトに基づいて、条件付きでコントロールをインスタンス化することもできます。</span><span class="sxs-lookup"><span data-stu-id="f8140-176">So far, you’ve seen how to set properties using conditional XAML, but you can also conditionally instantiate controls based on the API contract available at runtime.</span></span>

<span data-ttu-id="f8140-177">ここでは、アプリが Fall Creators Update で実行されている場合に、Fall Creators Update で利用できる [ColorPicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker) コントロールをインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="f8140-177">Here, a [ColorPicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker) is instantiated when the app runs on the Fall Creators Update where the control is available.</span></span> <span data-ttu-id="f8140-178">ColorPicker は Fall Creators Update より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、[ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) を使って色を選択する簡単なインターフェイスをユーザーに提示します。</span><span class="sxs-lookup"><span data-stu-id="f8140-178">The ColorPicker isn't available prior to the Fall Creators Update, so when the app runs on earlier versions, you use a [ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) to provide simplified color choices to the user.</span></span>

```xaml
<contract5Present:ColorPicker x:Name="colorPicker"
                              Grid.Column="1"
                              VerticalAlignment="Center"/>

<contract5NotPresent:ComboBox x:Name="colorComboBox"
                              PlaceholderText="Pick a color"
                              Grid.Column="1"
                              VerticalAlignment="Center">
```

<span data-ttu-id="f8140-179">条件修飾子は、さまざまな形式の [XAML プロパティ構文](../xaml-platform/xaml-syntax-guide.md)で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8140-179">You can use conditional qualifiers with different forms of [XAML property syntax](../xaml-platform/xaml-syntax-guide.md).</span></span> <span data-ttu-id="f8140-180">次の例では、四角形の Fill プロパティを設定するために、Fall Creators Update に対してはプロパティ要素構文を使い、以前のバージョンに対しては属性構文を使っています。</span><span class="sxs-lookup"><span data-stu-id="f8140-180">Here, the rectangle’s Fill property is set using property element syntax for the Fall Creators Update, and using attribute syntax for previous versions.</span></span>

```xaml
<Rectangle x:Name="colorRectangle" Width="200" Height="200"
           contract5NotPresent:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
    <contract5Present:Rectangle.Fill>
        <SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
    </contract5Present:Rectangle.Fill>
</Rectangle>
```

<span data-ttu-id="f8140-181">あるプロパティを、条件付き名前空間に依存する別のプロパティにバインドする場合は、両方のプロパティで同じ条件を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8140-181">When you bind a property to another property that depends on a conditional namespace, you must use the same condition on both properties.</span></span> <span data-ttu-id="f8140-182">次の例では、`colorPicker.Color` は "contract5Present" 条件付き名前空間に依存するため、SolidColorBrush.Color プロパティにも "contract5Present" プレフィックスを付ける必要があります </span><span class="sxs-lookup"><span data-stu-id="f8140-182">Here, `colorPicker.Color` depends on the 'contract5Present' conditional namespace, so you must also place the 'contract5Present' prefix on the SolidColorBrush.Color property.</span></span> <span data-ttu-id="f8140-183">(または、Color プロパティの代わりに SolidColorBrush に "contract5Present" プレフィックスを付けることもできます)。そうしないと、コンパイル時エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="f8140-183">(Or, you can place the 'contract5Present' prefix on the SolidColorBrush instead of on the Color property.) If you don’t, you’ll get a compile-time error.</span></span>

```xaml
<SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
```

<span data-ttu-id="f8140-184">以下に、これらのシナリオを実装した XAML 全体を示します。</span><span class="sxs-lookup"><span data-stu-id="f8140-184">Here's the complete XAML that demonstrates these scenarios.</span></span> <span data-ttu-id="f8140-185">この例には、1 つの四角形と、その四角形の色を設定する UI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f8140-185">This example contains a rectangle and a UI that lets you set the color of the rectangle.</span></span>

<span data-ttu-id="f8140-186">アプリが Fall Creators Update で実行された場合は、ColorPicker を使って色をユーザーが設定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f8140-186">When the app runs on the Fall Creators Update, you use a ColorPicker to let the user set the color.</span></span> <span data-ttu-id="f8140-187">ColorPicker は Fall Creators Update より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、コンボ ボックスを使って色を選択する簡単なインターフェイスをユーザーに提示します。</span><span class="sxs-lookup"><span data-stu-id="f8140-187">The ColorPicker isn't available prior to the Fall Creators Update, so when the app runs on earlier versions, you use a combo box to provide simplified color choices to the user.</span></span>

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
    xmlns:contract5NotPresent="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <Rectangle x:Name="colorRectangle" Width="200" Height="200"
                   contract5NotPresent:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
            <contract5Present:Rectangle.Fill>
                <SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
            </contract5Present:Rectangle.Fill>
        </Rectangle>

        <contract5Present:ColorPicker x:Name="colorPicker"
                                      Grid.Column="1"
                                      VerticalAlignment="Center"/>

        <contract5NotPresent:ComboBox x:Name="colorComboBox"
                                      PlaceholderText="Pick a color"
                                      Grid.Column="1"
                                      VerticalAlignment="Center">
            <ComboBoxItem>Red
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Red"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
            <ComboBoxItem>Blue
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Blue"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
            <ComboBoxItem>Green
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Green"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
        </contract5NotPresent:ComboBox>
    </Grid>
</Page>
```

## <a name="related-articles"></a><span data-ttu-id="f8140-188">関連記事</span><span class="sxs-lookup"><span data-stu-id="f8140-188">Related articles</span></span>

- [<span data-ttu-id="f8140-189">UWP アプリ ガイド</span><span class="sxs-lookup"><span data-stu-id="f8140-189">Guide to UWP apps</span></span>](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)
- [<span data-ttu-id="f8140-190">API コントラクトを使った機能の動的な検出</span><span class="sxs-lookup"><span data-stu-id="f8140-190">Dynamically detecting features with API contracts</span></span>](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
- <span data-ttu-id="f8140-191">[API コントラクト](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 のビデオ)</span><span class="sxs-lookup"><span data-stu-id="f8140-191">[API Contracts](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 video)</span></span>