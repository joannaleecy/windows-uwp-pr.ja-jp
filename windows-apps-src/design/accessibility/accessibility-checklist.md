---
Description: ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。
ms.assetid: BB8399E2-7013-4F77-AF2C-C1A0E5412856
title: アクセシビリティのチェック リスト
label: Accessibility checklist
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c9ff9760b3ae9b852fe1ae1b86d1cc48e49c5dd4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602447"
---
# <a name="accessibility-checklist"></a><span data-ttu-id="48040-104">アクセシビリティのチェック リスト</span><span class="sxs-lookup"><span data-stu-id="48040-104">Accessibility checklist</span></span>

<span data-ttu-id="48040-105">ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。</span><span class="sxs-lookup"><span data-stu-id="48040-105">Provides a checklist to help you ensure that your Universal Windows Platform (UWP) app is accessible .</span></span>

<span data-ttu-id="48040-106">ここでは、アプリをアクセシビリティ対応にするときに使用できるチェック リストを示します。</span><span class="sxs-lookup"><span data-stu-id="48040-106">Here we provide a checklist you can use to ensure that your app is accessible.</span></span>

1. <span data-ttu-id="48040-107">コンテンツやアプリの対話型の UI 要素にアクセシビリティ対応の名前 (必須) と説明 (省略可能) を設定します。</span><span class="sxs-lookup"><span data-stu-id="48040-107">Set the accessible name (required) and description (optional) for content and interactive UI elements in your app.</span></span>

    <span data-ttu-id="48040-108">アクセシビリティ対応の名前とは、スクリーン リーダーが UI 要素を読み上げるときに使う短い説明の文字列です。</span><span class="sxs-lookup"><span data-stu-id="48040-108">An accessible name is a short, descriptive text string that a screen reader uses to announce a UI element.</span></span> <span data-ttu-id="48040-109">[  **TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) や [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) などの一部の UI 要素では、既定のアクセシビリティ対応の名前としてテキスト コンテンツを昇格させるものがあります。「[基本的なアクセシビリティ情報](basic-accessibility-information.md#name_from_inner_text)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-109">Some UI elements such as [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) and [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) promote their text content as the default accessible name; see [Basic accessibility information](basic-accessibility-information.md#name_from_inner_text).</span></span>

    <span data-ttu-id="48040-110">暗黙的なアクセシビリティ対応の名前として内部テキスト コンテンツを昇格させない画像などのコントロールに対し、明示的にアクセシビリティ対応の名前を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="48040-110">You should set the accessible name explicitly for images or other controls that do not promote inner text content as an implicit accessible name.</span></span> <span data-ttu-id="48040-111">フォーム要素のラベルのテキストは、ラベルと入力を関連付けるために、Microsoft UI オートメーション モデルの [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) ターゲットとして使うことができるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="48040-111">You should use labels for form elements so that the label text can be used as a [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) target in the Microsoft UI Automation model for correlating labels and inputs.</span></span> <span data-ttu-id="48040-112">ユーザーに、通常アクセシビリティ対応の名前に含まれているものよりも詳しい UI のガイダンスを提供する場合は、アクセシビリティ対応の説明やヒントを用意すると、UI の内容がわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="48040-112">If you want to provide more UI guidance for users than is typically included in the accessible name, accessible descriptions and tooltips help users understand the UI.</span></span>

    <span data-ttu-id="48040-113">詳しくは、「[アクセシビリティ対応の名前](basic-accessibility-information.md#accessible_name)」と「[アクセシビリティ対応の説明](basic-accessibility-information.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-113">For more info, see [Accessible name](basic-accessibility-information.md#accessible_name) and [Accessible description](basic-accessibility-information.md).</span></span>

2. <span data-ttu-id="48040-114">キーボード アクセシビリティを実装します。</span><span class="sxs-lookup"><span data-stu-id="48040-114">Implement keyboard accessibility:</span></span>

    * <span data-ttu-id="48040-115">UI 用の既定のタブ インデックスの順序をテストします。</span><span class="sxs-lookup"><span data-stu-id="48040-115">Test the default tab index order for a UI.</span></span> <span data-ttu-id="48040-116">必要に応じてタブ インデックスの順序を調整します。このとき、特定のコントロールの有効化または無効化、一部の UI 要素の [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) の既定値の変更が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="48040-116">Adjust the tab index order if necessary, which may require enabling or disabling certain controls, or changing the default values of [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) on some of the UI elements.</span></span>
    * <span data-ttu-id="48040-117">コンポジット要素に方向キーのナビゲーションをサポートするコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="48040-117">Use controls that support arrow-key navigation for composite elements.</span></span> <span data-ttu-id="48040-118">既定のコントロールの場合、通常、方向キーのナビゲーションは既に実装されています。</span><span class="sxs-lookup"><span data-stu-id="48040-118">For default controls, the arrow-key navigation is typically already implemented.</span></span>
    * <span data-ttu-id="48040-119">キーボードのアクティブ化をサポートするコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="48040-119">Use controls that support keyboard activation.</span></span> <span data-ttu-id="48040-120">既定のコントロール、特に UI オートメーションの [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) パターンをサポートするものの場合は、基本的にキーボードのアクティブ化が利用できます。該当するコントロールの説明書をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-120">For default controls, particularly those that support the UI Automation [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) pattern, keyboard activation is typically available; check the documentation for that control.</span></span>
    * <span data-ttu-id="48040-121">対話式操作をサポートする UI の一部に対するアクセス キーを設定するか、ショートカット キーを実装します。</span><span class="sxs-lookup"><span data-stu-id="48040-121">Set access keys or implement accelerator keys for specific parts of the UI that support interaction.</span></span>
    * <span data-ttu-id="48040-122">UI で使うカスタム コントロールで、アクティブ化用に適切な [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) サポートを設定した状態でコントロールが実装され、アクティブ化キー、トラバーサル キー、アクセス キーまたはショートカット キーのサポートに必要なキー処理の上書きが定義されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-122">For any custom controls that you use in your UI, verify that you have implemented these controls with correct [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) support for activation, and defined overrides for key handling as needed to support activation, traversal and access or accelerator keys.</span></span>

    <span data-ttu-id="48040-123">詳しくは、「[キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-123">For more info, see [Keyboard interactions](https://msdn.microsoft.com/library/windows/apps/Mt185607).</span></span>

3. <span data-ttu-id="48040-124">テキストが読み取り可能なサイズであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-124">Ensure text is a readable size</span></span>

    * <span data-ttu-id="48040-125">Windows には、さまざまなアクセシビリティ ツールとユーザーが活用し、独自のニーズとテキストを読み取るための基本設定を調整する設定が含まれています。</span><span class="sxs-lookup"><span data-stu-id="48040-125">Windows includes various accessibility tools and settings that users can take advantage of and adjust to their own needs and preferences for reading text.</span></span> <span data-ttu-id="48040-126">次のようなクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="48040-126">These include:</span></span>
        * <span data-ttu-id="48040-127">拡大鏡ツール、UI の選択範囲を拡大します。</span><span class="sxs-lookup"><span data-stu-id="48040-127">The Magnifier tool, which enlarges a selected area of the UI.</span></span> <span data-ttu-id="48040-128">アプリ内のテキストのレイアウトが困難に拡大鏡を使用して、読み取り用に行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="48040-128">You should ensure the layout of text in your app doesn't make it difficult to use Magnifier for reading.</span></span>
        * <span data-ttu-id="48040-129">スケールと解像度の設定をグローバル**設定]、[システムの表示]-> [-> スケールとレイアウト**します。</span><span class="sxs-lookup"><span data-stu-id="48040-129">Global scale and resolution settings in **Settings->System->Display->Scale and layout**.</span></span> <span data-ttu-id="48040-130">正確にサイズ変更オプションが使用可能なディスプレイ デバイスの機能に依存とは異なります。</span><span class="sxs-lookup"><span data-stu-id="48040-130">Exactly which sizing options are available can vary as this depends on the capabilities of the display device.</span></span>
        * <span data-ttu-id="48040-131">テキスト サイズ設定\*\*設定、アクセスの容易さの表示-> \*\*します。</span><span class="sxs-lookup"><span data-stu-id="48040-131">Text size settings in **Settings->Ease of access->Display**.</span></span> <span data-ttu-id="48040-132">調整、**テキストを大きく**すべてのアプリケーションと画面 (すべての UWP テキスト コントロールは、テキストをカスタマイズまたはテンプレートなしのエクスペリエンスをスケーリングをサポート) 間でのサポート コントロールでテキストのサイズだけを指定する設定。</span><span class="sxs-lookup"><span data-stu-id="48040-132">Adjust the **Make text bigger** setting to specify only the size of text in supporting controls across all applications and screens (all UWP text controls support the text scaling experience without any customization or templating).</span></span>
        > [!NOTE]
        > <span data-ttu-id="48040-133">**すべての大きな**設定により、ユーザーのプライマリ画面のみに一般にテキストとアプリの推奨サイズを指定します。</span><span class="sxs-lookup"><span data-stu-id="48040-133">The **Make everything bigger** setting lets a user specify their preferred size for text and apps in general on their primary screen only.</span></span>

4. <span data-ttu-id="48040-134">テキスト コントラストが適切であること、ハイ コントラスト テーマで要素が正しくレンダリングされること、色が正しく使われていることを確認するため、UI を表示して検証します。</span><span class="sxs-lookup"><span data-stu-id="48040-134">Visually verify your UI to ensure that the text contrast is adequate, elements render correctly in the high-contrast themes, and colors are used correctly.</span></span>

    * <span data-ttu-id="48040-135">色分析ツールを使って、視覚的なテキストのコントラスト比が 4.5:1 以上であることを検証します。</span><span class="sxs-lookup"><span data-stu-id="48040-135">Use a color analyzer tool to verify that the visual text contrast ratio is at least 4.5:1.</span></span>
    * <span data-ttu-id="48040-136">ハイ コントラスト テーマに切り替え、アプリの UI が読みやすく使いやすいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-136">Switch to a high contrast theme and verify that the UI for your app is readable and usable.</span></span>
    * <span data-ttu-id="48040-137">UI が情報を伝える唯一の手段として色を使っていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-137">Ensure that your UI doesn’t use color as the only way to convey information.</span></span>

    <span data-ttu-id="48040-138">詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」と「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-138">For more info, see [High-contrast themes](high-contrast-themes.md) and [Accessible text requirements](accessible-text-requirements.md).</span></span>

5. <span data-ttu-id="48040-139">アクセシビリティ ツールを実行し、報告された問題に対処して、画面の読み上げを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-139">Run accessibility tools, address reported issues, and verify the screen reading experience.</span></span>

    <span data-ttu-id="48040-140">[  **Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) などのツールを使ってプログラムによるアクセスを検証し、[**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) などの診断ツールを実行して一般的なエラーを見つけます。画面の読み上げの確認には、ナレーターを使います。</span><span class="sxs-lookup"><span data-stu-id="48040-140">Use tools such as [**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) to verify programmatic access, run diagnostic tools such as [**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) to discover common errors, and verify the screen reading experience with Narrator.</span></span>

    <span data-ttu-id="48040-141">詳しくは、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-141">For more info, see [Accessibility testing](accessibility-testing.md).</span></span>

6. <span data-ttu-id="48040-142">アプリ マニフェストの設定がアクセシビリティ ガイドラインに準拠しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="48040-142">Make sure your app manifest settings follow accessibility guidelines.</span></span>

7. <span data-ttu-id="48040-143">Microsoft Store でアプリがアクセシビリティ対応であることを宣言します。</span><span class="sxs-lookup"><span data-stu-id="48040-143">Declare your app as accessible in the Microsoft Store.</span></span>

    <span data-ttu-id="48040-144">アクセシビリティ サポートの基準を実装したら、Microsoft Store でアプリがアクセシビリティ対応であることを宣言することで、より多くのユーザーにアプリを提供し、さらに良い評価を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="48040-144">If you implemented the baseline accessibility support, declaring your app as accessible in the Microsoft Store can help reach more customers and get some additional good ratings.</span></span>

    <span data-ttu-id="48040-145">詳しくは、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48040-145">For more info, see [Accessibility in the Store](accessibility-in-the-store.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="48040-146">関連トピック</span><span class="sxs-lookup"><span data-stu-id="48040-146">Related topics</span></span>  

* [<span data-ttu-id="48040-147">アクセシビリティに対応したテキストの要件</span><span class="sxs-lookup"><span data-stu-id="48040-147">Accessible text requirements</span></span>](accessible-text-requirements.md)
* [<span data-ttu-id="48040-148">テキストのスケーリング</span><span class="sxs-lookup"><span data-stu-id="48040-148">Text scaling</span></span>](../input/text-scaling.md)
* [<span data-ttu-id="48040-149">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="48040-149">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="48040-150">ユーザー補助のための設計</span><span class="sxs-lookup"><span data-stu-id="48040-150">Design for accessibility</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [<span data-ttu-id="48040-151">避ける事項</span><span class="sxs-lookup"><span data-stu-id="48040-151">Practices to avoid</span></span>](practices-to-avoid.md)
