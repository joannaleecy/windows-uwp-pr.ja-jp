---
author: jwmsft
title: "条件付き XAML"
description: "以前のバージョンとの互換性を保ちながら、XAML マークアップで新しい API を使います"
ms.author: jimwalk
ms.date: 07/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: b6fad82b8610367f5a69b236c1783106454374f3
ms.sourcegitcommit: 73ea31d42a9b352af38b5eb5d3c06504b50f6754
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/27/2017
---
# <a name="conditional-xaml"></a><span data-ttu-id="511a8-104">条件付き XAML</span><span class="sxs-lookup"><span data-stu-id="511a8-104">Conditional XAML</span></span>

<span data-ttu-id="511a8-105">*条件付き XAML* は、XAML マークアップで [ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsApiContractPresent_System_String_System_UInt16_) メソッドを使う方法を提供するものです。</span><span class="sxs-lookup"><span data-stu-id="511a8-105">*Conditional XAML* provides a way to use the [ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation#Windows_Foundation_Metadata_ApiInformation_IsApiContractPresent_System_String_System_UInt16_) method in XAML markup.</span></span> <span data-ttu-id="511a8-106">これにより、分離コードを使わなくても、API の有無に基づいてマークアップでプロパティの設定やオブジェクトのインスタンス化を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="511a8-106">This lets you set properties and instantiate objects in markup based on the presence of an API without needing to use code behind.</span></span> <span data-ttu-id="511a8-107">要素や属性が選択的に解析され、実行時に利用できるかどうかが判断されます。</span><span class="sxs-lookup"><span data-stu-id="511a8-107">It selectively parses elements or attributes to determine whether they will be available at runtime.</span></span> <span data-ttu-id="511a8-108">条件ステートメントは実行時に評価されます。条件付き XAML タグで修飾された要素は、**true** と評価された場合に解析され、そうでない場合は無視されます。</span><span class="sxs-lookup"><span data-stu-id="511a8-108">Conditional statements are evaluated at runtime, and elements qualified with a conditional XAML tag are parsed if evaluated to **true**; otherwise, they are ignored.</span></span>

<span data-ttu-id="511a8-109">条件付き XAML は Creators Update (Version 1703、ビルド 15063) 以降で使用できます。</span><span class="sxs-lookup"><span data-stu-id="511a8-109">Conditional XAML is available starting with the Creators Update (version 1703, build 15063).</span></span> <span data-ttu-id="511a8-110">条件付き XAML を使用するには、Visual Studio プロジェクトの最小バージョンとしてビルド 15063 (Creators Update) 以降を選択し、ターゲット バージョンを最小バージョンよりも後のバージョンに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-110">To use conditional XAML, the Minimum Version of your Visual Studio project must be set to build 15063 (Creators Update) or later, and the Target Version be set to a later version than the Minimum.</span></span> <span data-ttu-id="511a8-111">Visual Studio プロジェクトの構成について詳しくは、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="511a8-111">See [Version adaptive apps](version-adaptive-apps.md) for more info about configuring your Visual Studio project.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="511a8-112">**プレリリース | Fall Creators Update が必要**: 条件付き XAML を使うには、[Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) をターゲットとし、[Insider ビルド 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) 以降を実行している必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-112">**PRERELEASE | Requires Fall Creators Update**: You must target [Insider SDK 16225](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) and be running [Insider build 16226](https://blogs.windows.com/windowsexperience/2017/06/21/announcing-windows-10-insider-preview-build-16226-pc/) or later to use conditional XAML.</span></span>

> [!NOTE]
> <span data-ttu-id="511a8-113">ビルド 15063 より前のバージョンを最小バージョンとするバージョン アダプティブ アプリを作成するには、XAML ではなく[バージョン アダプティブ コード](version-adaptive-code.md)を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-113">To create a version adaptive app with a Minimum Version less than build 15063, you must use [version adaptive code](version-adaptive-code.md), not XAML.</span></span>

<span data-ttu-id="511a8-114">ApiInformation に関する重要な背景情報と API コントラクトについては、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="511a8-114">For important background info about ApiInformation and API contracts, see [Version adaptive apps](version-adaptive-apps.md).</span></span>

## <a name="conditional-namespaces"></a><span data-ttu-id="511a8-115">条件付き名前空間</span><span class="sxs-lookup"><span data-stu-id="511a8-115">Conditional namespaces</span></span>

<span data-ttu-id="511a8-116">XAML で条件を使うには、最初にページの最上部で条件付き [XAML 名前空間](../xaml-platform/xaml-namespaces-and-namespace-mapping.md) を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-116">To use a conditional in XAML, you must first declare a conditional [XAML namespace](../xaml-platform/xaml-namespaces-and-namespace-mapping.md) at the top of your page.</span></span> <span data-ttu-id="511a8-117">条件付き名前空間の擬似コード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="511a8-117">Here's a psuedo-code example of a conditional namespace:</span></span>

```xaml
xmlns:myNamespace="schema?conditionalMethod(parameter)"
```

<span data-ttu-id="511a8-118">条件付き名前空間は、'?' を区切り文字として 2 つの部分に分けられます。</span><span class="sxs-lookup"><span data-stu-id="511a8-118">A conditional namespace can be broken down into two parts separated by the '?' delimiter.</span></span> <span data-ttu-id="511a8-119">区切り文字の前のコンテンツには、参照しようとしている API を含む名前空間またはスキーマを指定します。</span><span class="sxs-lookup"><span data-stu-id="511a8-119">The content preceding the delimiter indicates the namespace or schema that contains the API being referenced.</span></span> <span data-ttu-id="511a8-120">区切り文字 '?' の後のコンテンツは、条件付き名前空間が **true** と **false** のどちらに評価されるかを決定する条件メソッドを表します。</span><span class="sxs-lookup"><span data-stu-id="511a8-120">The content after the '?' delimiter represents the conditional method that determines whether the conditional namespace evaluates to **true** or **false**.</span></span>

<span data-ttu-id="511a8-121">ほとんどの場合、スキーマは、次に示す既定の XAML 名前空間になります。</span><span class="sxs-lookup"><span data-stu-id="511a8-121">In most cases, the schema will be the default XAML namespace:</span></span>

```xaml
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
```

<span data-ttu-id="511a8-122">条件付き XAML では、次の条件メソッドがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="511a8-122">Conditional XAML supports the following conditional methods:</span></span>

<span data-ttu-id="511a8-123">メソッド</span><span class="sxs-lookup"><span data-stu-id="511a8-123">Method</span></span> | <span data-ttu-id="511a8-124">逆条件</span><span class="sxs-lookup"><span data-stu-id="511a8-124">Inverse</span></span>
------ | -------
<span data-ttu-id="511a8-125">IsApiContractPresent(ContractName, VersionNumber)</span><span class="sxs-lookup"><span data-stu-id="511a8-125">IsApiContractPresent(ContractName, VersionNumber)</span></span> | <span data-ttu-id="511a8-126">IsApiContractNotPresent(ContractName, VersionNumber)</span><span class="sxs-lookup"><span data-stu-id="511a8-126">IsApiContractNotPresent(ContractName, VersionNumber)</span></span>
<span data-ttu-id="511a8-127">IsTypePresent(ControlType)</span><span class="sxs-lookup"><span data-stu-id="511a8-127">IsTypePresent(ControlType)</span></span> | <span data-ttu-id="511a8-128">IsTypeNotPresent(ControlType)</span><span class="sxs-lookup"><span data-stu-id="511a8-128">IsTypeNotPresent(ControlType)</span></span>
<span data-ttu-id="511a8-129">IsPropertyPresent(ControlType, PropertyName)</span><span class="sxs-lookup"><span data-stu-id="511a8-129">IsPropertyPresent(ControlType, PropertyName)</span></span> | <span data-ttu-id="511a8-130">IsPropertyNotPresent(ControlType, PropertyName)</span><span class="sxs-lookup"><span data-stu-id="511a8-130">IsPropertyNotPresent(ControlType, PropertyName)</span></span>

<span data-ttu-id="511a8-131">(各メソッドの詳細は以降のセクションで説明します。)</span><span class="sxs-lookup"><span data-stu-id="511a8-131">(More on these methods in the sections below.)</span></span>

> [!NOTE] 
> <span data-ttu-id="511a8-132">Microsoft では、IsApiContractPresent と IsApiContractNotPresent を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="511a8-132">We recommend you use IsApiContractPresent and IsApiContractNotPresent.</span></span> <span data-ttu-id="511a8-133">その他の条件は、Visual Studio のデザイン エクスペリエンスでは完全にはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="511a8-133">Other conditionals are not fully supported in the Visual Studio design experience.</span></span>

## <a name="create-a-namespace-and-set-a-property"></a><span data-ttu-id="511a8-134">名前空間の作成とプロパティの設定</span><span class="sxs-lookup"><span data-stu-id="511a8-134">Create a namespace and set a property</span></span>

<span data-ttu-id="511a8-135">この例では、アプリが Windows Insider Preview (Fall Creators Update) で実行されている場合に、テキスト ブロックのコンテンツとして "Hello, Windows Insider" と表示します。以前のバージョンで実行されている場合、コンテンツは何も表示されません。</span><span class="sxs-lookup"><span data-stu-id="511a8-135">In this example, you’ll display, "Hello, Windows Insider", as the content of a text block if the app runs on the Windows Insider Preview (Fall Creators Update), and default to no content if it's on a previous version.</span></span>

<span data-ttu-id="511a8-136">まず、"insider" というプレフィックスのカスタム名前空間を定義し、[TextBlock.Text](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock#Windows_UI_Xaml_Controls_TextBlock_Text) プロパティを含むスキーマとして、既定の XAML 名前空間 (http://schemas.microsoft.com/winfx/2006/xaml/presentation) を使います。</span><span class="sxs-lookup"><span data-stu-id="511a8-136">First, define a custom namespace with the prefix 'insider' and use the default XAML namespace (http://schemas.microsoft.com/winfx/2006/xaml/presentation) as the schema containing the [TextBlock.Text](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock#Windows_UI_Xaml_Controls_TextBlock_Text) property.</span></span> <span data-ttu-id="511a8-137">これを条件付き名前空間にするために、スキーマの後に区切り文字 '?' </span><span class="sxs-lookup"><span data-stu-id="511a8-137">To make this a conditional namespace, add the ‘?’</span></span> <span data-ttu-id="511a8-138">を追加します。</span><span class="sxs-lookup"><span data-stu-id="511a8-138">delimiter after the schema.</span></span>

<span data-ttu-id="511a8-139">次に、Windows Insider Preview 以降を実行しているデバイスで **true** を返す条件を定義します。</span><span class="sxs-lookup"><span data-stu-id="511a8-139">You then define a conditional that returns **true** on devices that are running the Windows Insider Preview or later.</span></span> <span data-ttu-id="511a8-140">ApiInformation の **IsApiContractPresent** メソッドを使って、UniversalApiContract の 5 番目のバージョンをチェックします。</span><span class="sxs-lookup"><span data-stu-id="511a8-140">You use the ApiInformation method **IsApiContractPresent** to check for the 5th version of the UniversalApiContract.</span></span> <span data-ttu-id="511a8-141">バージョン 5 の UniversalApiContract は Windows Insider Preview (Fall Creators Update) でリリースされました。</span><span class="sxs-lookup"><span data-stu-id="511a8-141">Version 5 of the UniversalApiContract was released with the Windows Insider Preview (Fall Creators Update).</span></span>

```xaml
xmlns:insider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
```

<span data-ttu-id="511a8-142">名前空間を定義したら、TextBox の Text プロパティに名前空間プレフィックスを追加して、実行時に条件付きで設定されるプロパティとなるように指定します。</span><span class="sxs-lookup"><span data-stu-id="511a8-142">After the namespace is defined, you prepend the namespace prefix to the Text property of your TextBox to qualify it as a property that should be set conditionally at runtime.</span></span>

```xaml
<TextBlock insider:Text="Hello, Windows Insider"/>
```

<span data-ttu-id="511a8-143">XAML 全体は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="511a8-143">Here's the complete XAML.</span></span>

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:insider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock x:Name="textBlock" insider:Text="Hello, Windows Insider"/>
    </Grid>
</Page>
```

<span data-ttu-id="511a8-144">この例を Insider Preview で実行すると、"Hello, Windows Insider" というテキストが表示されます。Creators Update で実行した場合、テキストは何も表示されません。</span><span class="sxs-lookup"><span data-stu-id="511a8-144">When you run this example on the Insider Preview, the text, “I am a Windows Insider” is shown; when you run it on the Creators Update, no text is shown.</span></span>

<span data-ttu-id="511a8-145">条件付き XAML を使うと、以前にはコードで実行していた API チェックをマークアップ内で実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="511a8-145">Conditional XAML lets you perform the API checks you can do in code in your markup instead.</span></span> <span data-ttu-id="511a8-146">同じチェックを実行するコードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="511a8-146">Here's the equivalent code for this check.</span></span>

```csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    textBlock.Text = "Hello, Windows Insider";
}
```

<span data-ttu-id="511a8-147">IsApiContractPresent メソッドは *contractName* パラメーターとして文字列を受け取りますが、XAML 名前空間の宣言では引用符 (" ") を付けないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="511a8-147">Notice that even though the IsApiContractPresent method takes a string for the *contractName* parameter, you don't put it in quotes (" ") in the XAML namespace declaration.</span></span>

## <a name="use-ifelse-conditions"></a><span data-ttu-id="511a8-148">if/else 条件の使用</span><span class="sxs-lookup"><span data-stu-id="511a8-148">Use if/else conditions</span></span>

<span data-ttu-id="511a8-149">前の例では、アプリが Insider Preview で実行されている場合にのみ Text プロパティが設定されます。</span><span class="sxs-lookup"><span data-stu-id="511a8-149">In the previous example, the Text property is set only when the app runs on the Insider Preview.</span></span> <span data-ttu-id="511a8-150">では、Creators Update での実行時に別のテキストを表示したい場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="511a8-150">But what if you want to show different text when it runs on the Creators Update?</span></span> <span data-ttu-id="511a8-151">たとえば、次のように条件修飾子のない Text プロパティを設定したとします。</span><span class="sxs-lookup"><span data-stu-id="511a8-151">You could try to set the Text property without a conditional qualifier, like this.</span></span>

```xaml
<!-- DO NOT USE -->
<TextBlock Text="Hello, World" insider:Text="Hello, Windows Insider"/>
```

<span data-ttu-id="511a8-152">これは Creators Update で実行した場合は正しく動作しますが、Insider Preview で実行すると、Text プロパティが複数回設定されているというエラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="511a8-152">This will work when it’s run on the Creators Update, but when it runs on the Insider Preview, you’ll get an error saying that the Text property is set more than once.</span></span>

<span data-ttu-id="511a8-153">異なるバージョンの Windows 10 でアプリが実行されているときに別のテキストを設定するには、別の条件を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-153">To set different text when the app runs on different versions of Windows 10, you need another condition.</span></span> <span data-ttu-id="511a8-154">条件付き XAML では、このような if/else 条件のシナリオを作成できるように、サポートされている ApiInformation メソッドのそれぞれに対して反対の判定を行うメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="511a8-154">Conditional XAML provides an inverse of each supported ApiInformation method to let you create if/else conditional scenarios like this.</span></span>
 
<span data-ttu-id="511a8-155">IsApiContractPresent メソッドは、指定したコントラクトとバージョン番号が現在のデバイスに含まれている場合に **true** を返します。</span><span class="sxs-lookup"><span data-stu-id="511a8-155">The IsApiContractPresent method returns **true** if the current device contains the specified contract and version number.</span></span> <span data-ttu-id="511a8-156">たとえば、ユニバーサル API コントラクトの 4 番目のバージョンである Creators Update でアプリが実行されているとします。</span><span class="sxs-lookup"><span data-stu-id="511a8-156">For example, assume your app is running on the Creators Update, which has the 4th version of the universal API Contract.</span></span>

<span data-ttu-id="511a8-157">このとき、パラメーターを変えて IsApiContractPresent を呼び出すと、結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="511a8-157">Various calls to IsApiContractPresent would have these results:</span></span>

- <span data-ttu-id="511a8-158">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 5) = **false**</span><span class="sxs-lookup"><span data-stu-id="511a8-158">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 5) = **false**</span></span>
- <span data-ttu-id="511a8-159">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 4) = true</span><span class="sxs-lookup"><span data-stu-id="511a8-159">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 4) = true</span></span>
- <span data-ttu-id="511a8-160">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 3) = true</span><span class="sxs-lookup"><span data-stu-id="511a8-160">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 3) = true</span></span>
- <span data-ttu-id="511a8-161">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 2) = true</span><span class="sxs-lookup"><span data-stu-id="511a8-161">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 2) = true</span></span>
- <span data-ttu-id="511a8-162">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 1) = true</span><span class="sxs-lookup"><span data-stu-id="511a8-162">IsApiContractPresent(Windows.Foundation.UniversalApiContract, 1) = true.</span></span>

<span data-ttu-id="511a8-163">IsApiContractNotPresent は、IsApiContractPresent の反対の結果を返します。</span><span class="sxs-lookup"><span data-stu-id="511a8-163">IsApiContractNotPresent returns the inverse of IsApiContractPresent.</span></span> <span data-ttu-id="511a8-164">IsApiContractNotPresent の呼び出し結果は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="511a8-164">Calls to IsApiContractNotPresent would have these results:</span></span>

- <span data-ttu-id="511a8-165">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 5) = **true**</span><span class="sxs-lookup"><span data-stu-id="511a8-165">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 5) = **true**</span></span>
- <span data-ttu-id="511a8-166">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 4) = false</span><span class="sxs-lookup"><span data-stu-id="511a8-166">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 4) = false</span></span>
- <span data-ttu-id="511a8-167">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 3) = false</span><span class="sxs-lookup"><span data-stu-id="511a8-167">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 3) = false</span></span>
- <span data-ttu-id="511a8-168">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 2) = false</span><span class="sxs-lookup"><span data-stu-id="511a8-168">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 2) = false</span></span>
- <span data-ttu-id="511a8-169">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 1) = false</span><span class="sxs-lookup"><span data-stu-id="511a8-169">IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 1) = false</span></span>

<span data-ttu-id="511a8-170">逆条件を使うには、**IsApiContractNotPresent** 条件を使う 2 つ目の条件付き XAML 名前空間を作成します。</span><span class="sxs-lookup"><span data-stu-id="511a8-170">To use the inverse condition, you create a second conditional XAML namespace that uses the **IsApiContractNotPresent** conditional.</span></span> <span data-ttu-id="511a8-171">この例では、"notInsider" というプレフィックスを使います。</span><span class="sxs-lookup"><span data-stu-id="511a8-171">Here, it has the prefix 'notInsider'.</span></span>

```xaml
xmlns:insider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"

xmlns:notInsider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)"
```

<span data-ttu-id="511a8-172">両方の名前空間を定義し、次のようにプロパティをプレフィックスで修飾すれば、実行時には一方のプロパティだけが設定されるため、Text プロパティを 2 回記述することができます。</span><span class="sxs-lookup"><span data-stu-id="511a8-172">With both namespaces defined, you can set the Text property twice as long as you prefix them with qualifiers that ensure only one property setting is used at runtime, like this:</span></span>

```xaml
<TextBlock notInsider:Text="Hello, World" 
           insider:Text="Hello, Windows Insider"/>
```

<span data-ttu-id="511a8-173">別の例として、ボタンの背景を設定する場合を考えます。</span><span class="sxs-lookup"><span data-stu-id="511a8-173">Here's another example that sets the background of a button.</span></span> <span data-ttu-id="511a8-174">Insider Preview (Fall Creators Update) 以降では[アクリル素材](../style/acrylic.md)機能を利用できるので、アプリが Insider Preview で実行されているときは、背景にアクリルを適用することにします。</span><span class="sxs-lookup"><span data-stu-id="511a8-174">The [Acrylic material](../style/acrylic.md) feature is available starting with the Insider Preview (Fall Creators Update), so you’ll use Acrylic for the background when the app runs on the Insider Preview.</span></span> <span data-ttu-id="511a8-175">この機能は以前のバージョンでは利用できないため、その場合は背景を赤に設定します。</span><span class="sxs-lookup"><span data-stu-id="511a8-175">It's not available on earlier versions, so in those cases, you set the background to red.</span></span>

```xaml
<Button Content="Button"
        notInsider:Background="Red"
        insider:Background="{ThemeResource SystemControlAcrylicElementBrush}"/>
```

## <a name="create-controls-and-bind-properties"></a><span data-ttu-id="511a8-176">コントロールの作成とプロパティのバインド</span><span class="sxs-lookup"><span data-stu-id="511a8-176">Create controls and bind properties</span></span>

<span data-ttu-id="511a8-177">ここまでは条件付き XAML を使ってプロパティを設定する方法を見てきましたが、実行時に利用できる API コントラクトに基づいて、条件付きでコントロールをインスタンス化することもできます。</span><span class="sxs-lookup"><span data-stu-id="511a8-177">So far, you’ve seen how to set properties using conditional XAML, but you can also conditionally instantiate controls based on the API contract available at runtime.</span></span>

<span data-ttu-id="511a8-178">ここでは、アプリが Insider Preview で実行されている場合に、Insider Preview で利用できる [ColorPicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker) コントロールをインスタンス化します。</span><span class="sxs-lookup"><span data-stu-id="511a8-178">Here, a [ColorPicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker) is instantiated when the app runs on the Insider Preview where the control is available.</span></span> <span data-ttu-id="511a8-179">ColorPicker は Insider Preview より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、[ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) を使って色を選択する簡単なインターフェイスをユーザーに提示します。</span><span class="sxs-lookup"><span data-stu-id="511a8-179">The ColorPicker isn't available prior to the Insider Preview, so when the app runs on earlier versions, you use a [ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) to provide simplified color choices to the user.</span></span>

```xaml
<insider:ColorPicker x:Name="colorPicker" Grid.Column="1"/>

<notInsider:ComboBox x:Name="colorComboBox" PlaceholderText="Pick a color"
                     Grid.Column="1" VerticalAlignment="Center">
```

<span data-ttu-id="511a8-180">条件修飾子は、さまざまな形式の [XAML プロパティ構文](../xaml-platform/xaml-syntax-guide.md)で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="511a8-180">You can use conditional qualifiers with different forms of [XAML property syntax](../xaml-platform/xaml-syntax-guide.md).</span></span> <span data-ttu-id="511a8-181">次の例では、四角形の Fill プロパティを設定するために、Insider Preview に対してはプロパティ要素構文を使い、以前のバージョンに対しては属性構文を使っています。</span><span class="sxs-lookup"><span data-stu-id="511a8-181">Here, the rectangle’s Fill property is set using property element syntax for the Insider Preview, and using attribute syntax for previous versions.</span></span>

```xaml
<Rectangle x:Name="colorRectangle" Width="200" Height="200"
           notInsider:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
    <insider:Rectangle.Fill>
        <SolidColorBrush insider:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
    </insider:Rectangle.Fill>
</Rectangle>
```

<span data-ttu-id="511a8-182">あるプロパティを、条件付き名前空間に依存する別のプロパティにバインドする場合は、両方のプロパティで同じ条件を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="511a8-182">When you bind a property to another property that depends on a conditional namespace, you must use the same condition on both properties.</span></span> <span data-ttu-id="511a8-183">次の例では、`colorPicker.Color` は "insider" 条件付き名前空間に依存するため、SolidColorBrush.Color プロパティにも "insider" プレフィックスを付ける必要があります </span><span class="sxs-lookup"><span data-stu-id="511a8-183">Here, `colorPicker.Color` depends on the 'insider' conditional namespace, so you must also place the 'insider' prefix on the SolidColorBrush.Color property.</span></span> <span data-ttu-id="511a8-184">(または、Color プロパティの代わりに SolidColorBrush に "insider" プレフィックスを付けることもできます)。そうしないと、コンパイル時エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="511a8-184">(Or, you can place the 'insider' prefix on the SolidColorBrush instead of on the Color property.) If you don’t, you’ll get a compile-time error.</span></span>

```xaml
<SolidColorBrush insider:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
```

<span data-ttu-id="511a8-185">以下に、これらのシナリオを実装した XAML 全体を示します。</span><span class="sxs-lookup"><span data-stu-id="511a8-185">Here's the complete XAML that demonstrates these scenarios.</span></span> <span data-ttu-id="511a8-186">この例には、1 つの四角形と、その四角形の色を設定する UI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="511a8-186">This example contains a rectangle and a UI that lets you set the color of the rectangle.</span></span>

<span data-ttu-id="511a8-187">アプリが Insider Preview で実行された場合は、ColorPicker を使って色をユーザーが設定できるようにします。</span><span class="sxs-lookup"><span data-stu-id="511a8-187">When the app runs on the Insider Preview, you use a ColorPicker to let the user set the color.</span></span> <span data-ttu-id="511a8-188">ColorPicker は Insider Preview より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、コンボ ボックスを使って色を選択する簡単なインターフェイスをユーザーに提示します。</span><span class="sxs-lookup"><span data-stu-id="511a8-188">The ColorPicker isn't available prior to the Insider Preview, so when the app runs on earlier versions, you use a combo box to provide simplified color choices to the user.</span></span>

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:insider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
    xmlns:notInsider="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <Rectangle x:Name="colorRectangle" Width="200" Height="200"
                   notInsider:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
            <insider:Rectangle.Fill>
                <SolidColorBrush insider:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
            </insider:Rectangle.Fill>
        </Rectangle>

        <insider:ColorPicker x:Name="colorPicker" Grid.Column="1"/>

        <notInsider:ComboBox x:Name="colorComboBox" PlaceholderText="Pick a color"
                     Grid.Column="1" VerticalAlignment="Center">
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
        </notInsider:ComboBox>
    </Grid>
</Page>
```

## <a name="related-articles"></a><span data-ttu-id="511a8-189">関連記事</span><span class="sxs-lookup"><span data-stu-id="511a8-189">Related articles</span></span>

- [<span data-ttu-id="511a8-190">UWP アプリ ガイド</span><span class="sxs-lookup"><span data-stu-id="511a8-190">Guide to UWP apps</span></span>](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)
- [<span data-ttu-id="511a8-191">API コントラクトを使った機能の動的な検出</span><span class="sxs-lookup"><span data-stu-id="511a8-191">Dynamically detecting features with API contracts</span></span>](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
- <span data-ttu-id="511a8-192">[API コントラクト](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 のビデオ)</span><span class="sxs-lookup"><span data-stu-id="511a8-192">[API Contracts](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 video)</span></span>