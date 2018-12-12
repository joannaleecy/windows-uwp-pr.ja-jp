---
description: カスタム リソース検索の実装から取得されたリソースの参照を評価して、任意の XAML 属性の値を提供します。 リソース検索は、CustomXamlResourceLoader クラスの実装によって実行されます。
title: CustomResource マークアップ拡張
ms.assetid: 3A59A8DE-E805-4F04-B9D9-A91E053F3642
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7eabcb188aa1687d36d4b4e6f432783aa68969de
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8934049"
---
# <a name="customresource-markup-extension"></a><span data-ttu-id="9e70f-105">{CustomResource} マークアップ拡張</span><span class="sxs-lookup"><span data-stu-id="9e70f-105">{CustomResource} markup extension</span></span>


<span data-ttu-id="9e70f-106">カスタム リソース検索の実装から取得されたリソースの参照を評価して、任意の XAML 属性の値を提供します。</span><span class="sxs-lookup"><span data-stu-id="9e70f-106">Provides a value for any XAML attribute by evaluating a reference to a resource that comes from a custom resource-lookup implementation.</span></span> <span data-ttu-id="9e70f-107">リソース検索は、[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) クラスの実装によって実行されます。</span><span class="sxs-lookup"><span data-stu-id="9e70f-107">Resource lookup is performed by a [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) class implementation.</span></span>

## <a name="xaml-attribute-usage"></a><span data-ttu-id="9e70f-108">XAML 属性の使用方法</span><span class="sxs-lookup"><span data-stu-id="9e70f-108">XAML attribute usage</span></span>

``` syntax
<object property="{CustomResource key}" .../>
```

## <a name="xaml-values"></a><span data-ttu-id="9e70f-109">XAML 値</span><span class="sxs-lookup"><span data-stu-id="9e70f-109">XAML values</span></span>

| <span data-ttu-id="9e70f-110">用語</span><span class="sxs-lookup"><span data-stu-id="9e70f-110">Term</span></span> | <span data-ttu-id="9e70f-111">説明</span><span class="sxs-lookup"><span data-stu-id="9e70f-111">Description</span></span> |
|------|-------------|
| <span data-ttu-id="9e70f-112">key</span><span class="sxs-lookup"><span data-stu-id="9e70f-112">key</span></span> | <span data-ttu-id="9e70f-113">要求されたリソースのキー。</span><span class="sxs-lookup"><span data-stu-id="9e70f-113">The key for the requested resource.</span></span> <span data-ttu-id="9e70f-114">キーが最初にどのように割り当てられるかは、現在使用が登録されている [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) クラスの実装に固有のものです。</span><span class="sxs-lookup"><span data-stu-id="9e70f-114">How the key is initially assigned is specific to the implementation of the [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) class that is currently registered for use.</span></span> |

## <a name="remarks"></a><span data-ttu-id="9e70f-115">注釈</span><span class="sxs-lookup"><span data-stu-id="9e70f-115">Remarks</span></span>

<span data-ttu-id="9e70f-116">**CustomResource** は、カスタム リソース リポジトリのどこかで定義されている値を取得するための手法です。</span><span class="sxs-lookup"><span data-stu-id="9e70f-116">**CustomResource** is a technique for obtaining values that are defined elsewhere in a custom resource repository.</span></span> <span data-ttu-id="9e70f-117">この手法は比較的高度なものであり、Windows ランタイム アプリのほとんどのシナリオでは使われていません。</span><span class="sxs-lookup"><span data-stu-id="9e70f-117">This technique is relatively advanced and isn't used by most Windows Runtime app scenarios.</span></span>

<span data-ttu-id="9e70f-118">**CustomResource** がどのようにリソース辞書に解決されるかについては、[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) の実装方法によって異なるため、このトピックでは説明しません。</span><span class="sxs-lookup"><span data-stu-id="9e70f-118">How a **CustomResource** resolves to a resource dictionary is not described in this topic, because that can vary widely depending on how [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) is implemented.</span></span>

<span data-ttu-id="9e70f-119">[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) 実装の [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) メソッドは、Windows ランタイム XAML パーサーがマークアップ内で `{CustomResource}` の使用を検出するたびに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="9e70f-119">The [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) method of the [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) implementation is called by the Windows Runtime XAML parser whenever it encounters a `{CustomResource}` usage in markup.</span></span> <span data-ttu-id="9e70f-120">**GetResource** に渡される *resourceId* は *key* 引数から与えられ、他の入力パラメーターはコンテキスト (たとえば、使用が適用されたプロパティ) から与えられます。</span><span class="sxs-lookup"><span data-stu-id="9e70f-120">The *resourceId* that is passed to **GetResource** comes from the *key* argument, and the other input parameters come from context, such as which property the usage is applied to.</span></span>

<span data-ttu-id="9e70f-121">`{CustomResource}` の使用は既定では機能しません ([**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) の基本実装が不完全です)。</span><span class="sxs-lookup"><span data-stu-id="9e70f-121">A `{CustomResource}` usage doesn't work by default (the base implementation of [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) is incomplete).</span></span> <span data-ttu-id="9e70f-122">`{CustomResource}` の有効な参照を行うには、次の各手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e70f-122">To make a valid `{CustomResource}` reference, you must perform each of these steps:</span></span>

1.  <span data-ttu-id="9e70f-123">[**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) からカスタム クラスを派生し、[**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) メソッドをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="9e70f-123">Derive a custom class from [**CustomXamlResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br243327) and override [**GetResource**](https://msdn.microsoft.com/library/windows/apps/br243340) method.</span></span> <span data-ttu-id="9e70f-124">実装で基本メソッドを呼び出さないでください。</span><span class="sxs-lookup"><span data-stu-id="9e70f-124">Do not call base in the implementation.</span></span>
2.  <span data-ttu-id="9e70f-125">初期化ロジックでクラスを参照するために [**CustomXamlResourceLoader.Current**](https://msdn.microsoft.com/library/windows/apps/br243328) を設定します。</span><span class="sxs-lookup"><span data-stu-id="9e70f-125">Set [**CustomXamlResourceLoader.Current**](https://msdn.microsoft.com/library/windows/apps/br243328) to reference your class in initialization logic.</span></span> <span data-ttu-id="9e70f-126">これは、`{CustomResource}` 拡張の使用が含まれるページ レベルの XAML が読み込まれる前に行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="9e70f-126">This must happen before any page-level XAML that includes the `{CustomResource}` extension usage is loaded.</span></span> <span data-ttu-id="9e70f-127">**CustomXamlResourceLoader.Current** を設定する場所の 1 つは、App.xaml コード ビハインド テンプレートで生成される [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) サブクラス コンストラクター内です。</span><span class="sxs-lookup"><span data-stu-id="9e70f-127">One place to set **CustomXamlResourceLoader.Current** is in the [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) subclass constructor that's generated for you in the App.xaml code-behind templates.</span></span>
3.  <span data-ttu-id="9e70f-128">これで、アプリでページとして読み込む XAML 内で、XAML リソース ディクショナリ内から、`{CustomResource}` 拡張を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9e70f-128">Now you can use `{CustomResource}` extensions in the XAML that your app loads as pages, or from within XAML resource dictionaries.</span></span>

<span data-ttu-id="9e70f-129">**CustomResource** はマークアップ拡張です。</span><span class="sxs-lookup"><span data-stu-id="9e70f-129">**CustomResource** is a markup extension.</span></span> <span data-ttu-id="9e70f-130">通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。</span><span class="sxs-lookup"><span data-stu-id="9e70f-130">Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties.</span></span> <span data-ttu-id="9e70f-131">XAML のすべてのマークアップ拡張では、それぞれの属性構文で "\{" と "\}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。</span><span class="sxs-lookup"><span data-stu-id="9e70f-131">All markup extensions in XAML use the "\{" and "\}" characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute.</span></span>

## <a name="related-topics"></a><span data-ttu-id="9e70f-132">関連トピック</span><span class="sxs-lookup"><span data-stu-id="9e70f-132">Related topics</span></span>

* [<span data-ttu-id="9e70f-133">ResourceDictionary と XAML リソースの参照</span><span class="sxs-lookup"><span data-stu-id="9e70f-133">ResourceDictionary and XAML resource references</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [**<span data-ttu-id="9e70f-134">CustomXamlResourceLoader</span><span class="sxs-lookup"><span data-stu-id="9e70f-134">CustomXamlResourceLoader</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243327)
* [**<span data-ttu-id="9e70f-135">GetResource</span><span class="sxs-lookup"><span data-stu-id="9e70f-135">GetResource</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243340)

