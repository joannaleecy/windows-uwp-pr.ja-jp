---
author: jwmsft
title: バージョン アダプティブ コード
description: ApiInformation を使って、以前のバージョンとの互換性を保ちながら新しい API を利用します
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 3293e91e-6888-4cc3-bad3-61e5a7a7ab4e
ms.localizationpriority: medium
ms.openlocfilehash: e25a3bd447519ce344a95a1c335451f731552487
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5931196"
---
# <a name="version-adaptive-code"></a><span data-ttu-id="0c9af-104">バージョン アダプティブ コード</span><span class="sxs-lookup"><span data-stu-id="0c9af-104">Version adaptive code</span></span>

<span data-ttu-id="0c9af-105">アダプティブ コードの記述については、[アダプティブ UI の作成](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml)と同じように考えることができます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-105">You can think about writing adaptive code similarly to how you think about [creating an adaptive UI](https://msdn.microsoft.com/windows/uwp/layout/layouts-with-xaml).</span></span> <span data-ttu-id="0c9af-106">最小画面で実行するように基本 UI を設計し、より大きな画面でアプリが実行されていることを検出したときに要素を移動または追加できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-106">You might design your base UI to run on the smallest screen, and then move or add elements when you detect that your app is running on a larger screen.</span></span> <span data-ttu-id="0c9af-107">アダプティブ コードの場合、最小の OS バージョンで実行するように基本コードを記述し、新機能が提供されているより高いバージョンでアプリが実行されていることを検出したときに、機能を手動で選んで追加できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-107">With adaptive code, you write your base code to run on the lowest OS version, and you can add hand-selected features when you detect that your app is running on a higher version where the new feature is available.</span></span>

<span data-ttu-id="0c9af-108">ApiInformation に関する重要な背景情報、API コントラクト、Visual Studio の構成については、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c9af-108">For important background info about ApiInformation, API contracts, and configuring Visual Studio, see [Version adaptive apps](version-adaptive-apps.md).</span></span>

### <a name="runtime-api-checks"></a><span data-ttu-id="0c9af-109">ランタイム API チェック</span><span class="sxs-lookup"><span data-stu-id="0c9af-109">Runtime API checks</span></span>

<span data-ttu-id="0c9af-110">呼び出す API が存在するかどうかをテストするために、コードの条件で [Windows.Foundation.Metadata.ApiInformation](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.aspx) クラスを使います。</span><span class="sxs-lookup"><span data-stu-id="0c9af-110">You use the [Windows.Foundation.Metadata.ApiInformation](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.aspx) class in a condition in your code to test for the presence of the API you want to call.</span></span> <span data-ttu-id="0c9af-111">このテストの条件は、アプリの実行時に必ず評価されますが、API が存在するデバイスに対してのみ **true** と評価され、呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-111">This condition is evaluated wherever your app runs, but it evaluates to **true** only on devices where the API is present and therefore available to call.</span></span> <span data-ttu-id="0c9af-112">これにより、特定の OS バージョンでのみ利用できる API を使うアプリを作成するためのバージョン アダプティブ コードを記述できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-112">This lets you write version adaptive code in order to create apps that use APIs that are available only on certain OS versions.</span></span>

<span data-ttu-id="0c9af-113">ここでは、Windows Insider Preview の新機能をターゲットにするための具体的な例を示します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-113">Here, we look at specific examples for targeting new features in the Windows Insider Preview.</span></span> <span data-ttu-id="0c9af-114">**ApiInformation** を使う場合の一般的な概要については、[デバイス ファミリの概要に関する記事](https://docs.microsoft.com/en-us/uwp/extension-sdks/device-families-overview#writing-code)と [API コントラクトを使った機能の動的な検出に関するブログの投稿](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c9af-114">For a general overview of using **ApiInformation**, see [Device families overview](https://docs.microsoft.com/en-us/uwp/extension-sdks/device-families-overview#writing-code) and the blog post [Dynamically detecting features with API contracts](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/).</span></span>

> [!TIP]
> <span data-ttu-id="0c9af-115">さまざまなランタイム API チェックが、アプリのパフォーマンスに影響する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-115">Numerous runtime API checks can affect the performance of your app.</span></span> <span data-ttu-id="0c9af-116">それらの例では、チェックをインラインで示します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-116">We show the checks inline in these examples.</span></span> <span data-ttu-id="0c9af-117">運用コードでは、チェックを一度実行してから結果をキャッシュし、キャッシュされた結果をアプリ全体で使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-117">In production code, you should perform the check once and cache the result, then used the cached result throughout your app.</span></span> 

### <a name="unsupported-scenarios"></a><span data-ttu-id="0c9af-118">サポートされていないシナリオ</span><span class="sxs-lookup"><span data-stu-id="0c9af-118">Unsupported scenarios</span></span>

<span data-ttu-id="0c9af-119">ほとんどの場合、アプリの最小バージョンを SDK バージョン 10240 に設定したままにし、アプリがそれより新しいバージョンで実行されたときに、ランタイム チェックを使って新しい API を有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-119">In most cases, you can keep your app's Minimum Version set to SDK version 10240 and use runtime checks to enable any new APIs when your app runs on later a version.</span></span> <span data-ttu-id="0c9af-120">ただし、新機能を使うためにアプリの最小バージョンを上げることが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-120">However, there are some cases where you must increase your app's Minimum Version in order to use new features.</span></span>

<span data-ttu-id="0c9af-121">アプリの最小バージョンを上げる必要があるのは、以下を使う場合です。</span><span class="sxs-lookup"><span data-stu-id="0c9af-121">You must increase your app's Minimum Version if you use:</span></span>
- <span data-ttu-id="0c9af-122">以前のバージョンでは使うことができない機能を必要とする新しい API。</span><span class="sxs-lookup"><span data-stu-id="0c9af-122">a new API that requires a capability that isn't available in an earlier version.</span></span> <span data-ttu-id="0c9af-123">サポートされる最小バージョンを、その機能が含まれているバージョンに上げる必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-123">You must increase the minimum supported version to one that includes that capability.</span></span> <span data-ttu-id="0c9af-124">詳しくは、「[アプリ機能の宣言](../packaging/app-capability-declarations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c9af-124">For more info, see [App capability declarations](../packaging/app-capability-declarations.md).</span></span>
- <span data-ttu-id="0c9af-125">generic.xaml に追加された新しいリソース キーのうち、以前のバージョンでは使うことができないリソース キー。</span><span class="sxs-lookup"><span data-stu-id="0c9af-125">any new resource keys added to generic.xaml and not available in a previous version.</span></span> <span data-ttu-id="0c9af-126">実行時に使われる generic.xaml のバージョンは、デバイスで実行されている OS バージョンによって決まります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-126">The version of generic.xaml used at runtime is determined by the OS version the device is running on.</span></span> <span data-ttu-id="0c9af-127">ランタイム API チェックを使って XAML リソースの有無を確認することはできません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-127">You can't use runtime API checks to determine the presence of XAML resources.</span></span> <span data-ttu-id="0c9af-128">そのため、アプリがサポートする最小バージョンで利用できるリソース キーのみを使う必要があります。そうしないと、[XAMLParseException](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.markup.xamlparseexception.aspx) が原因で実行時にアプリがクラッシュします。</span><span class="sxs-lookup"><span data-stu-id="0c9af-128">So, you must only use resource keys that are available in the minimum version that your app supports or a [XAMLParseException](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.markup.xamlparseexception.aspx) will cause your app to crash at runtime.</span></span>

### <a name="adaptive-code-options"></a><span data-ttu-id="0c9af-129">アダプティブ コードのオプション</span><span class="sxs-lookup"><span data-stu-id="0c9af-129">Adaptive code options</span></span>

<span data-ttu-id="0c9af-130">アダプティブ コードを作成するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-130">There are two ways to create adaptive code.</span></span> <span data-ttu-id="0c9af-131">ほとんどの場合、アプリのマークアップを最小バージョンで実行するように記述してから、アプリ コードを使ってより新しい OS 機能 (存在する場合) を活用します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-131">In most cases, you write your app markup to run on the Minimum version, then use your app code to tap into newer OS features when present.</span></span> <span data-ttu-id="0c9af-132">ただし、表示状態でプロパティを更新する必要があり、OS バージョン間でプロパティ値と列挙値の変更のみがある場合、API の存在に基づいてアクティブ化される拡張可能な状態トリガーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-132">However, if you need to update a property in a visual state, and there is only a property or enumeration value change between OS versions, you can create an extensible state trigger that’s activated based on the presence of an API.</span></span>

<span data-ttu-id="0c9af-133">ここで、以下のオプションを比較します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-133">Here, we compare these options.</span></span>

**<span data-ttu-id="0c9af-134">アプリケーション コード</span><span class="sxs-lookup"><span data-stu-id="0c9af-134">App code</span></span>**

<span data-ttu-id="0c9af-135">使う状況:</span><span class="sxs-lookup"><span data-stu-id="0c9af-135">When to use:</span></span>
- <span data-ttu-id="0c9af-136">すべてのアダプティブ コード シナリオにお勧めします。ただし、拡張可能なトリガー用に以下に定義されている特定のケースは除きます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-136">Recommended for all adaptive code scenarios except for specific cases defined below for extensible triggers.</span></span>

<span data-ttu-id="0c9af-137">利点:</span><span class="sxs-lookup"><span data-stu-id="0c9af-137">Benefits:</span></span>
- <span data-ttu-id="0c9af-138">API の相違をマークアップに結び付ける際の開発者のオーバーヘッドや複雑さを回避できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-138">Avoids developer overhead/complexity of tying API differences into markup.</span></span>

<span data-ttu-id="0c9af-139">欠点:</span><span class="sxs-lookup"><span data-stu-id="0c9af-139">Drawbacks:</span></span>
- <span data-ttu-id="0c9af-140">デザイナーがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-140">No Designer support.</span></span>

**<span data-ttu-id="0c9af-141">状態トリガー</span><span class="sxs-lookup"><span data-stu-id="0c9af-141">State Triggers</span></span>**

<span data-ttu-id="0c9af-142">使う状況:</span><span class="sxs-lookup"><span data-stu-id="0c9af-142">When to use:</span></span>
- <span data-ttu-id="0c9af-143">OS バージョン間で、ロジックを変更する必要のない、表示状態に関連付けられているプロパティまたは列挙値のみに変更がある場合に使います。</span><span class="sxs-lookup"><span data-stu-id="0c9af-143">Use when there is only a property or enum change between OS versions that doesn’t require logic changes, and is connected to a visual state.</span></span>

<span data-ttu-id="0c9af-144">利点:</span><span class="sxs-lookup"><span data-stu-id="0c9af-144">Benefits:</span></span>
- <span data-ttu-id="0c9af-145">API の存在に基づいてトリガーされる特定の表示状態を作成できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-145">Lets you create specific visual states that are triggered based on the presence of an API.</span></span>
- <span data-ttu-id="0c9af-146">一部のデザイナー サポートを利用できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-146">Some designer support available.</span></span>

<span data-ttu-id="0c9af-147">欠点:</span><span class="sxs-lookup"><span data-stu-id="0c9af-147">Drawbacks:</span></span>
- <span data-ttu-id="0c9af-148">カスタム トリガーの使用は表示状態に限定されるため、複雑なアダプティブ レイアウトには適していません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-148">Use of custom triggers is restricted to visual states, which doesn’t lend itself to complicated adaptive layouts.</span></span>
- <span data-ttu-id="0c9af-149">セッターを使って値の変更を指定する必要があるため、単純な変更だけを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-149">Must use Setters to specify value changes, so only simple changes are possible.</span></span>
- <span data-ttu-id="0c9af-150">カスタム状態トリガーを設定して使うには、非常に細かい設定が必要です。</span><span class="sxs-lookup"><span data-stu-id="0c9af-150">Custom state triggers are fairly verbose to set up and use.</span></span>

## <a name="adaptive-code-examples"></a><span data-ttu-id="0c9af-151">アダプティブ コードの例</span><span class="sxs-lookup"><span data-stu-id="0c9af-151">Adaptive code examples</span></span>

<span data-ttu-id="0c9af-152">このセクションでは、Windows 10 バージョン 1607 (Windows Insider Preview) で新しく追加された API を使うアダプティブ コードの例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-152">In this section, we show several examples of adaptive code that use APIs that are new in Windows 10, version 1607 (Windows Insider Preview).</span></span>

### <a name="example-1-new-enum-value"></a><span data-ttu-id="0c9af-153">例 1: 新しい列挙値</span><span class="sxs-lookup"><span data-stu-id="0c9af-153">Example 1: New enum value</span></span>

<span data-ttu-id="0c9af-154">Windows 10 バージョン 1607 では、[InputScopeNameValue](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.inputscopenamevalue.aspx) 列挙体に新しい値 **ChatWithoutEmoji** が追加されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-154">Windows 10, version 1607 adds a new value to the [InputScopeNameValue](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.inputscopenamevalue.aspx) enumeration: **ChatWithoutEmoji**.</span></span> <span data-ttu-id="0c9af-155">この新しい入力スコープの入力動作は、**Chat** 入力スコープ (スペルチェック、オートコンプリート、大文字の自動設定) と同じですが、絵文字ボタンのないタッチ キーボードにマップされます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-155">This new input scope has the same input behavior as the **Chat** input scope (spellchecking, auto-complete, auto-capitalization), but it maps to a touch keyboard without an emoji button.</span></span> <span data-ttu-id="0c9af-156">これは、独自の絵文字ピッカーを作成し、タッチ キーボードに組み込まれている絵文字ボタンを無効にする場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="0c9af-156">This is useful if you create your own emoji picker and want to disable the built-in emoji button in the touch keyboard.</span></span> 

<span data-ttu-id="0c9af-157">次の例は、**ChatWithoutEmoji** 列挙値が存在するかどうかを確認し、存在する場合は **TextBox** の [InputScope](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.inputscope.aspx) プロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-157">This example shows how to check if the **ChatWithoutEmoji** enum value is present and sets the [InputScope](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.inputscope.aspx) property of a **TextBox** if it is.</span></span> <span data-ttu-id="0c9af-158">アプリが実行されているシステムにこの列挙値が存在しない場合、**InputScope** は **Chat** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-158">If it’s not present on the system the app is run on, the **InputScope** is set to **Chat** instead.</span></span> <span data-ttu-id="0c9af-159">ここに示されているコードは、Page コンストラクターまたは Page.Loaded イベント ハンドラーに配置できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-159">The code shown could be placed in a Page consructor or Page.Loaded event handler.</span></span>

> [!TIP]
> <span data-ttu-id="0c9af-160">API をチェックするときは、.NET 言語機能を使うのではなく静的な文字列を使います。そうしないと、アプリは定義されていない型にアクセスしようとして、実行時にクラッシュすることがあります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-160">When you check an API, use static strings instead of relying on .NET language features, otherwise your app might try to access a type that isn’t defined and crash at runtime.</span></span>

**<span data-ttu-id="0c9af-161">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-161">C#</span></span>**
```csharp
// Create a TextBox control for sending messages 
// and initialize an InputScope object.
TextBox messageBox = new TextBox();
messageBox.AcceptsReturn = true;
messageBox.TextWrapping = TextWrapping.Wrap;
InputScope scope = new InputScope();
InputScopeName scopeName = new InputScopeName();

// Check that the ChatWithEmoji value is present.
// (It's present starting with Windows 10, version 1607,
//  the Target version for the app. This check returns false on earlier versions.)         
if (ApiInformation.IsEnumNamedValuePresent("Windows.UI.Xaml.Input.InputScopeNameValue", "ChatWithoutEmoji"))
{
    // Set new ChatWithoutEmoji InputScope if present.
    scopeName.NameValue = InputScopeNameValue.ChatWithoutEmoji;
}
else
{
    // Fall back to Chat InputScope.
    scopeName.NameValue = InputScopeNameValue.Chat;
}

// Set InputScope on messaging TextBox.
scope.Names.Add(scopeName);
messageBox.InputScope = scope;

// For this example, set the TextBox text to show the selected InputScope.
messageBox.Text = messageBox.InputScope.Names[0].NameValue.ToString();

// Add the TextBox to the XAML visual tree (rootGrid is defined in XAML).
rootGrid.Children.Add(messageBox);
```

<span data-ttu-id="0c9af-162">前の例では、TextBox が作成され、コードにすべてのプロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-162">In the previous example, the TextBox is created and all properties are set in code.</span></span> <span data-ttu-id="0c9af-163">ただし、既存の XAML があり、新しい値がサポートされているシステムで InputScope プロパティのみを変更する必要がある場合、次に示すように、XAML を変更せずにその操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-163">However, if you have existing XAML, and just need to change the InputScope property on systems where the new value is supported, you can do that without changing your XAML, as shown here.</span></span> <span data-ttu-id="0c9af-164">XAML で既定値を **Chat** に設定しますが、**ChatWithoutEmoji** 値が存在する場合はコードでそれをオーバーライドします。</span><span class="sxs-lookup"><span data-stu-id="0c9af-164">You set the default value to **Chat** in XAML, but you override it in code if the **ChatWithoutEmoji** value is present.</span></span>

**<span data-ttu-id="0c9af-165">XAML</span><span class="sxs-lookup"><span data-stu-id="0c9af-165">XAML</span></span>**
```xaml
<TextBox x:Name="messageBox"
         AcceptsReturn="True" TextWrapping="Wrap"
         InputScope="Chat"
         Loaded="messageBox_Loaded"/>
```

**<span data-ttu-id="0c9af-166">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-166">C#</span></span>**
```csharp
private void messageBox_Loaded(object sender, RoutedEventArgs e)
{
    if (ApiInformation.IsEnumNamedValuePresent("Windows.UI.Xaml.Input.InputScopeNameValue", "ChatWithoutEmoji"))
    {
        // Check that the ChatWithEmoji value is present.
        // (It's present starting with Windows 10, version 1607,
        //  the Target version for the app. This code is skipped on earlier versions.)
        InputScope scope = new InputScope();
        InputScopeName scopeName = new InputScopeName();
        scopeName.NameValue = InputScopeNameValue.ChatWithoutEmoji;
        // Set InputScope on messaging TextBox.
        scope.Names.Add(scopeName);
        messageBox.InputScope = scope;
    }

    // For this example, set the TextBox text to show the selected InputScope.
    // This is outside of the API check, so it will happen on all OS versions.
    messageBox.Text = messageBox.InputScope.Names[0].NameValue.ToString();
}
```

<span data-ttu-id="0c9af-167">既に具体例があるので、ターゲット バージョンと最小バージョンの設定がどのように適用されるのかを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="0c9af-167">Now that we have a concrete example, let’s see how the Target and Minimum version settings apply to it.</span></span>

<span data-ttu-id="0c9af-168">これらの例では、XAML またはチェックを含まないコードで Chat 列挙値を使うことができます。これは、Chat 列挙値がサポートされる最小の OS バージョンに存在するためです。</span><span class="sxs-lookup"><span data-stu-id="0c9af-168">In these examples, you can use the Chat enum value in XAML, or in code without a check, because it’s present in the minimum supported OS version.</span></span> 

<span data-ttu-id="0c9af-169">XAML またはチェックを含まないコードで ChatWithoutEmoji 値を使うと、ChatWithoutEmoji 値がターゲットの OS バージョンに存在するためエラーなしでコンパイルされます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-169">If you use the ChatWithoutEmoji value in XAML, or in code without a check, it will compile without error because it's present in the Target OS version.</span></span> <span data-ttu-id="0c9af-170">また、ターゲットの OS バージョンが含まれたシステムで、エラーなしで実行されます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-170">It will also run without error on a system with the Target OS version.</span></span> <span data-ttu-id="0c9af-171">ただし、アプリが最小バージョンを使っている OS を含むシステムで実行されると、ChatWithoutEmoji 列挙値が存在しないため実行時にクラッシュします。</span><span class="sxs-lookup"><span data-stu-id="0c9af-171">However, when the app runs on a system with an OS using the Minimum version, it will crash at runtime because the ChatWithoutEmoji enum value is not present.</span></span> <span data-ttu-id="0c9af-172">そのため、コードでのみこの値を使って、この値が現在のシステムでサポートされている場合だけ呼び出されるように、ランタイム API チェックにラップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-172">Therefore, you must use this value only in code, and wrap it in a runtime API check so it’s called only if it’s supported on the current system.</span></span>

### <a name="example-2-new-control"></a><span data-ttu-id="0c9af-173">例 2: 新しいコントロール</span><span class="sxs-lookup"><span data-stu-id="0c9af-173">Example 2: New control</span></span>

<span data-ttu-id="0c9af-174">通常、新しいバージョンの Windows では、プラットフォームに新機能をもたらす新しいコントロールが UWP API サーフェスに追加されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-174">A new version of Windows typically brings new controls to the UWP API surface that bring new functionality to the platform.</span></span> <span data-ttu-id="0c9af-175">新しいコントロールを活用するには、[ApiInformation.IsTypePresent](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="0c9af-175">To leverage the presence of a new control, use the  [ApiInformation.IsTypePresent](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) method.</span></span>

<span data-ttu-id="0c9af-176">Windows 10 バージョン 1607 には、[**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) と呼ばれる新しいメディア コントロールが導入されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-176">Windows 10, version 1607 introduces a new media control called [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx).</span></span> <span data-ttu-id="0c9af-177">このコントロールは、[MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) クラスに基づいて作成されているため、バックグラウンド オーディオに簡単に結び付けることができるような機能が追加され、メディア スタックの向上したアーキテクチャを活用しています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-177">This control builds on the [MediaPlayer](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.aspx) class, so it brings features like the ability to easily tie into background audio, and it makes use of architectural improvements in the media stack.</span></span>

<span data-ttu-id="0c9af-178">ただし、アプリが Windows 10 バージョン 1607 より古いバージョンを実行しているデバイスで実行される場合、新しい **MediaPlayerElement** コントロールではなく、[**MediaElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaelement.aspx) コントロールを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-178">However, if the app runs on a device that’s running a version of Windows 10 older than version 1607, you must use the [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaelement.aspx) control instead of the new **MediaPlayerElement** control.</span></span> <span data-ttu-id="0c9af-179">[**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) メソッドを使って実行時に MediaPlayerElement コントロールが存在するかどうかをチェックし、アプリが実行されているシステムに適しているコントロールを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-179">You can use the [**ApiInformation.IsTypePresent**](https://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.apiinformation.istypepresent.aspx) method to check for the presence of the MediaPlayerElement control at runtime, and load whichever control is suitable for the system where the app is running.</span></span>

<span data-ttu-id="0c9af-180">この例は、新しい MediaPlayerElement または古い MediaElement を使うアプリを作成する方法を示しています。どちらを使うかは、MediaPlayerElement 型が存在するかどうかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-180">This example shows how to create an app that uses either the new MediaPlayerElement or the old MediaElement depending on whether MediaPlayerElement type is present.</span></span> <span data-ttu-id="0c9af-181">このコードでは、[UserControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol.aspx) クラスを使って、コントロール、およびそれに関連する UI とコードをコンポーネント化し、OS バージョンに基づいて切り替えることができるようにしています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-181">In this code, you use the [UserControl](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.usercontrol.aspx) class to componentize the controls and their related UI and code so that you can switch them in and out based on the OS version.</span></span> <span data-ttu-id="0c9af-182">また、このシンプルな例に必要なものよりも機能的でカスタムの動作を提供するカスタム コントロールを使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-182">As an alternative, you can use a custom control, which provides more functionality and custom behavior than what’s needed for this simple example.</span></span>
 
**<span data-ttu-id="0c9af-183">MediaPlayerUserControl</span><span class="sxs-lookup"><span data-stu-id="0c9af-183">MediaPlayerUserControl</span></span>** 

<span data-ttu-id="0c9af-184">`MediaPlayerUserControl` は、**MediaPlayerElement** と、フレーム単位でメディアを飛ばすために使われるいくつかのボタンをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-184">The `MediaPlayerUserControl` encapsulates a **MediaPlayerElement** and several buttons that are used to skip through the media frame by frame.</span></span> <span data-ttu-id="0c9af-185">UserControl を使うと、これらのコントロールを単一のエンティティとして扱って、以前のシステムの MediaElement と簡単に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-185">The UserControl lets you treat these controls as a single entity and makes it easier to switch with a MediaElement on older systems.</span></span> <span data-ttu-id="0c9af-186">このユーザー コントロールは、MediaPlayerElement が存在するシステムでのみ使う必要があるため、このユーザー コントロール内のコードでは ApiInformation チェックを使いません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-186">This user control should be used only on systems where MediaPlayerElement is present, so you don’t use ApiInformation checks in the code inside this user control.</span></span>

> [!NOTE]
> <span data-ttu-id="0c9af-187">この例をシンプルなままにし、集中して取り組むために、フレーム ステップ ボタンはメディア プレーヤーの外部に配置されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-187">To keep this example simple and focused, the frame step buttons are placed outside of the media player.</span></span> <span data-ttu-id="0c9af-188">ユーザー エクスペリエンスを向上するためには、MediaTransportControls をカスタマイズしてカスタム ボタンを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-188">For a better user experiance, you should customize the MediaTransportControls to include your custom buttons.</span></span> <span data-ttu-id="0c9af-189">詳しくは、「[カスタム トランスポート コントロールを作成する](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/custom-transport-controls)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0c9af-189">See [Custom transport controls](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/custom-transport-controls) for more info.</span></span> 

**<span data-ttu-id="0c9af-190">XAML</span><span class="sxs-lookup"><span data-stu-id="0c9af-190">XAML</span></span>**
```xaml
<UserControl
    x:Class="MediaApp.MediaPlayerUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MediaApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="300"
    d:DesignWidth="400">

    <Grid x:Name="MPE_grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <StackPanel Orientation="Horizontal" 
                    HorizontalAlignment="Center" Grid.Row="1">
            <RepeatButton Click="StepBack_Click" Content="Step Back"/>
            <RepeatButton Click="StepForward_Click" Content="Step Forward"/>
        </StackPanel>
    </Grid>
</UserControl>
```

**<span data-ttu-id="0c9af-191">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-191">C#</span></span>**
```csharp
using System;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MediaApp
{
    public sealed partial class MediaPlayerUserControl : UserControl
    {
        public MediaPlayerUserControl()
        {
            this.InitializeComponent();
            
            // The markup code compiler runs against the Minimum OS version so MediaPlayerElement must be created in app code
            MPE = new MediaPlayerElement();
            Uri videoSource = new Uri("ms-appx:///Assets/UWPDesign.mp4");
            MPE.Source = MediaSource.CreateFromUri(videoSource);
            MPE.AreTransportControlsEnabled = true;
            MPE.MediaPlayer.AutoPlay = true;

            // Add MediaPlayerElement to the Grid
            MPE_grid.Children.Add(MPE);

        }

        private void StepForward_Click(object sender, RoutedEventArgs e)
        {
            // Step forward one frame, only available using MediaPlayerElement.
            MPE.MediaPlayer.StepForwardOneFrame();
        }

        private void StepBack_Click(object sender, RoutedEventArgs e)
        {
            // Step forward one frame, only available using MediaPlayerElement.
            MPE.MediaPlayer.StepForwardOneFrame();
        }
    }
}
```

**<span data-ttu-id="0c9af-192">MediaElementUserControl</span><span class="sxs-lookup"><span data-stu-id="0c9af-192">MediaElementUserControl</span></span>**
 
<span data-ttu-id="0c9af-193">`MediaElementUserControl` は **MediaElement** コントロールをカプセル化します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-193">The `MediaElementUserControl` encapsulates a **MediaElement** control.</span></span>

**<span data-ttu-id="0c9af-194">XAML</span><span class="sxs-lookup"><span data-stu-id="0c9af-194">XAML</span></span>**
```xaml
<UserControl
    x:Class="MediaApp.MediaElementUserControl"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MediaApp"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    d:DesignHeight="300"
    d:DesignWidth="400">

    <Grid>
        <MediaElement AreTransportControlsEnabled="True" 
                      Source="Assets/UWPDesign.mp4"/>
    </Grid>
</UserControl>
```

> [!NOTE]
> <span data-ttu-id="0c9af-195">`MediaElementUserControl` のコード ページには、生成されたコードのみが含まれているため、ここでは示しません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-195">The code page for `MediaElementUserControl` contains only generated code, so it's not shown.</span></span>

**<span data-ttu-id="0c9af-196">IsTypePresent に基づいてコントロールを初期化する</span><span class="sxs-lookup"><span data-stu-id="0c9af-196">Initialize a control based on IsTypePresent</span></span>**

<span data-ttu-id="0c9af-197">実行時に、**ApiInformation.IsTypePresent** を呼び出して、MediaPlayerElement の有無を確認します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-197">At runtime, you call **ApiInformation.IsTypePresent** to check for MediaPlayerElement.</span></span> <span data-ttu-id="0c9af-198">MediaPlayerElement が存在する場合は `MediaPlayerUserControl` を読み込み、存在しない場合は `MediaElementUserControl` を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-198">If it's present, you load `MediaPlayerUserControl`, if it's not, you load `MediaElementUserControl`.</span></span>

**<span data-ttu-id="0c9af-199">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-199">C#</span></span>**
```csharp
public MainPage()
{
    this.InitializeComponent();

    UserControl mediaControl;

    // Check for presence of type MediaPlayerElement.
    if (ApiInformation.IsTypePresent("Windows.UI.Xaml.Controls.MediaPlayerElement"))
    {
        mediaControl = new MediaPlayerUserControl();
    }
    else
    {
        mediaControl = new MediaElementUserControl();
    }

    // Add mediaControl to XAML visual tree (rootGrid is defined in XAML).
    rootGrid.Children.Add(mediaControl);
}
```

> [!IMPORTANT]
> <span data-ttu-id="0c9af-200">このチェックでは `mediaControl` オブジェクトを `MediaPlayerUserControl` または `MediaElementUserControl` に設定するだけです。</span><span class="sxs-lookup"><span data-stu-id="0c9af-200">Remember that this check only sets the `mediaControl` object to either `MediaPlayerUserControl` or `MediaElementUserControl`.</span></span> <span data-ttu-id="0c9af-201">コード内の MediaPlayerElement API と MediaElement API のどちらを使うのかを判断する必要がある他の場所でこれらの条件付きチェックを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-201">You need to perform these conditional checks anywhere else in your code that you need to determine whether to use MediaPlayerElement or MediaElement APIs.</span></span> <span data-ttu-id="0c9af-202">チェックを一度実行してから結果をキャッシュし、キャッシュされた結果をアプリ全体で使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="0c9af-202">You should perform the check once and cache the result, then used the cached result throughout your app.</span></span>

## <a name="state-trigger-examples"></a><span data-ttu-id="0c9af-203">状態トリガーの例</span><span class="sxs-lookup"><span data-stu-id="0c9af-203">State trigger examples</span></span>

<span data-ttu-id="0c9af-204">拡張可能な状態トリガーでは、マークアップとコードを一緒に使って、コードでチェックする条件 (ここでは、特定の API が存在するかどうか) に基づいて表示状態の変更をトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-204">Extensible state triggers let you use markup and code together to trigger visual state changes based on a condition that you check in code; in this case, the presence of a specific API.</span></span> <span data-ttu-id="0c9af-205">関係するオーバーヘッドと、表示状態のみへの制限があるため、一般的なアダプティブ コード シナリオで状態トリガーを使うことはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="0c9af-205">We don’t recommend state triggers for common adaptive code scenarios because of the overhead involved, and the restriction to only visual states.</span></span> 

<span data-ttu-id="0c9af-206">コントロール上のプロパティ値や列挙値の変更など、残りの UI に影響しない、異なる OS バージョン間での小さな UI の変更がある場合のみ、アダプティブ コードに状態トリガーを使ってください。</span><span class="sxs-lookup"><span data-stu-id="0c9af-206">You should use state triggers for adaptive code only when you have small UI changes between different OS versions that won’t impact the remaining UI, such as a property or enum value change on a control.</span></span>

### <a name="example-1-new-property"></a><span data-ttu-id="0c9af-207">例 1: 新しいプロパティ</span><span class="sxs-lookup"><span data-stu-id="0c9af-207">Example 1: New property</span></span>

<span data-ttu-id="0c9af-208">拡張可能な状態トリガーを設定する最初の手順は、[StateTriggerBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.statetriggerbase.aspx) クラスのサブクラスを作成して、API の有無に基づいてアクティブになるカスタム トリガーを作成することです。</span><span class="sxs-lookup"><span data-stu-id="0c9af-208">The first step in setting up an extensible state trigger is subclassing the [StateTriggerBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.statetriggerbase.aspx) class to create a custom trigger that will be active based on the presence of an API.</span></span> <span data-ttu-id="0c9af-209">この例は、プロパティの有無が XAML に設定されている `_isPresent` 変数に一致する場合にアクティブ化されるトリガーを示しています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-209">This example shows a trigger that activates if the property presence matches the `_isPresent` variable set in XAML.</span></span>

**<span data-ttu-id="0c9af-210">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-210">C#</span></span>**
```csharp
class IsPropertyPresentTrigger : StateTriggerBase
{
    public string TypeName { get; set; }
    public string PropertyName { get; set; }

    private Boolean _isPresent;
    private bool? _isPropertyPresent = null;

    public Boolean IsPresent
    {
        get { return _isPresent; }
        set
        {
            _isPresent = value;
            if (_isPropertyPresent == null)
            {
                // Call into ApiInformation method to determine if property is present.
                _isPropertyPresent =
                ApiInformation.IsPropertyPresent(TypeName, PropertyName);
            }

            // If the property presence matches _isPresent then the trigger will be activated;
            SetActive(_isPresent == _isPropertyPresent);
        }
    }
}
```

<span data-ttu-id="0c9af-211">次の手順は、XAML で表示状態トリガーを設定して、2 つの異なる表示状態が API の有無に基づいた結果になるようにします。</span><span class="sxs-lookup"><span data-stu-id="0c9af-211">The next step is setting up the visual state trigger in XAML so that two different visual states result based on the presence of the API.</span></span> 

<span data-ttu-id="0c9af-212">Windows 10 バージョン 1607 では、ユーザーがコントロールを操作するときにそのコントロールがフォーカスを取得するかどうかを判断する [AllowFocusOnInteraction](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.allowfocusoninteraction.aspx) と呼ばれる [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) クラスに新しいプロパティが導入されています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-212">Windows 10, version 1607 introduces a new property on the [FrameworkElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.aspx) class called [AllowFocusOnInteraction](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.allowfocusoninteraction.aspx) that determines whether a control takes focus when  a user interacts with it.</span></span> <span data-ttu-id="0c9af-213">これは、ユーザーがボタンをクリックしたときに、データ入力用のテキスト ボックスにフォーカスを保持する (タッチ キーボードを表示したままにする) のに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-213">This is useful if you want to keep focus on a text box for data entry (and keep the touch keyboard showing) while the user clicks a button.</span></span>

<span data-ttu-id="0c9af-214">この例のトリガーは、プロパティが存在するかどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="0c9af-214">The trigger in this example checks if the property is present.</span></span> <span data-ttu-id="0c9af-215">プロパティが存在する場合、Button の **AllowFocusOnInteraction** プロパティが **false** に設定されます。プロパティが存在しない場合は、Button はその元の状態を保持します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-215">If the property is present it sets the **AllowFocusOnInteraction** property on a Button to **false**; if the property isn’t present, the Button retains its original state.</span></span> <span data-ttu-id="0c9af-216">TextBox は、コードの実行時にこのプロパティの影響をわかりやすくするために含まれています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-216">The TextBox is included to make it easier to see the effect of this property when you run the code.</span></span>

**<span data-ttu-id="0c9af-217">XAML</span><span class="sxs-lookup"><span data-stu-id="0c9af-217">XAML</span></span>**
```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <StackPanel>
        <TextBox Width="300" Height="36"/>
        <!-- Button to set the new property on. -->
        <Button x:Name="testButton" Content="Test" Margin="12"/>
    </StackPanel>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="propertyPresentStateGroup">
            <VisualState>
                <VisualState.StateTriggers>
                    <!--Trigger will activate if the AllowFocusOnInteraction property is present-->
                    <local:IsPropertyPresentTrigger 
                        TypeName="Windows.UI.Xaml.FrameworkElement" 
                        PropertyName="AllowFocusOnInteraction" IsPresent="True"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="testButton.AllowFocusOnInteraction" 
                            Value="False"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```

### <a name="example-2-new-enum-value"></a><span data-ttu-id="0c9af-218">例 2: 新しい列挙値</span><span class="sxs-lookup"><span data-stu-id="0c9af-218">Example 2: New enum value</span></span>

<span data-ttu-id="0c9af-219">次の例は、値が存在するかどうかに基づいてさまざまな列挙値を設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0c9af-219">This example shows how to set different enumeration values based on whether a value is present.</span></span> <span data-ttu-id="0c9af-220">カスタム状態トリガーを使って、前のチャットの例と同じ結果を実現します。</span><span class="sxs-lookup"><span data-stu-id="0c9af-220">It uses a custom state trigger to achieve the same result as the previous chat example.</span></span> <span data-ttu-id="0c9af-221">この例では、デバイスが Windows 10 バージョン 1607 を実行している場合に、新しい ChatWithoutEmoji 入力スコープを使います。それ以外の場合、**Chat** 入力スコープが使われます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-221">In this example, you use the new ChatWithoutEmoji input scope if the device is running Windows 10, version 1607, otherwise the **Chat** input scope is used.</span></span> <span data-ttu-id="0c9af-222">このトリガーを使う表示状態は、新しい列挙値の有無に基づいて入力スコープが選択される *if-else* スタイルで設定されます。</span><span class="sxs-lookup"><span data-stu-id="0c9af-222">The visual states that use this trigger are set up in an *if-else* style where the input scope is chosen based on the presence of the new enum value.</span></span>

**<span data-ttu-id="0c9af-223">C#</span><span class="sxs-lookup"><span data-stu-id="0c9af-223">C#</span></span>**
```csharp
class IsEnumPresentTrigger : StateTriggerBase
{
    public string EnumTypeName { get; set; }
    public string EnumValueName { get; set; }

    private Boolean _isPresent;
    private bool? _isEnumValuePresent = null;

    public Boolean IsPresent
    {
        get { return _isPresent; }
        set
        {
            _isPresent = value;

            if (_isEnumValuePresent == null)
            {
                // Call into ApiInformation method to determine if value is present.
                _isEnumValuePresent =
                ApiInformation.IsEnumNamedValuePresent(EnumTypeName, EnumValueName);
            }

            // If the property presence matches _isPresent then the trigger will be activated;
            SetActive(_isPresent == _isEnumValuePresent);
        }
    }
}
```

**<span data-ttu-id="0c9af-224">XAML</span><span class="sxs-lookup"><span data-stu-id="0c9af-224">XAML</span></span>**
```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <TextBox x:Name="messageBox"
     AcceptsReturn="True" TextWrapping="Wrap"/>


    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="EnumPresentStates">
            <!--if-->
            <VisualState x:Name="isPresent">
                <VisualState.StateTriggers>
                    <local:IsEnumPresentTrigger 
                        EnumTypeName="Windows.UI.Xaml.Input.InputScopeNameValue" 
                        EnumValueName="ChatWithoutEmoji" IsPresent="True"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="messageBox.InputScope" Value="ChatWithoutEmoji"/>
                </VisualState.Setters>
            </VisualState>
            <!--else-->
            <VisualState x:Name="isNotPresent">
                <VisualState.StateTriggers>
                    <local:IsEnumPresentTrigger 
                        EnumTypeName="Windows.UI.Xaml.Input.InputScopeNameValue" 
                        EnumValueName="ChatWithoutEmoji" IsPresent="False"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="messageBox.InputScope" Value="Chat"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```

## <a name="related-articles"></a><span data-ttu-id="0c9af-225">関連記事</span><span class="sxs-lookup"><span data-stu-id="0c9af-225">Related articles</span></span>

- [<span data-ttu-id="0c9af-226">デバイス ファミリの概要</span><span class="sxs-lookup"><span data-stu-id="0c9af-226">Device families overview</span></span>](https://docs.microsoft.com/uwp/extension-sdks/device-families-overview)
- [<span data-ttu-id="0c9af-227">API コントラクトを使った機能の動的な検出</span><span class="sxs-lookup"><span data-stu-id="0c9af-227">Dynamically detecting features with API contracts</span></span>](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
