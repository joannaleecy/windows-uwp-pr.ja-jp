---
Description: Provides a checklist to help you ensure that your Universal Windows Platform (UWP) app is accessible.
ms.assetid: BB8399E2-7013-4F77-AF2C-C1A0E5412856
title: アクセシビリティのチェック リスト
label: Accessibility checklist
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d63c7465234b6aebe876259ee095a183571946b2
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8928933"
---
# <a name="accessibility-checklist"></a><span data-ttu-id="eaa32-103">アクセシビリティのチェック リスト</span><span class="sxs-lookup"><span data-stu-id="eaa32-103">Accessibility checklist</span></span>



<span data-ttu-id="eaa32-104">ユニバーサル Windows プラットフォーム (UWP) アプリをアクセシビリティ対応にするために役立つチェック リストを示します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-104">Provides a checklist to help you ensure that your Universal Windows Platform (UWP) app is accessible .</span></span>

<span data-ttu-id="eaa32-105">ここでは、アプリをアクセシビリティ対応にするときに使用できるチェック リストを示します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-105">Here we provide a checklist you can use to ensure that your app is accessible.</span></span>

1.  <span data-ttu-id="eaa32-106">コンテンツやアプリの対話型の UI 要素にアクセシビリティ対応の名前 (必須) と説明 (省略可能) を設定します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-106">Set the accessible name (required) and description (optional) for content and interactive UI elements in your app.</span></span>

    <span data-ttu-id="eaa32-107">アクセシビリティ対応の名前とは、スクリーン リーダーが UI 要素を読み上げるときに使う短い説明の文字列です。</span><span class="sxs-lookup"><span data-stu-id="eaa32-107">An accessible name is a short, descriptive text string that a screen reader uses to announce a UI element.</span></span> <span data-ttu-id="eaa32-108">[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) や [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) などの一部の UI 要素では、既定のアクセシビリティ対応の名前としてテキスト コンテンツを昇格させるものがあります。「[基本的なアクセシビリティ情報](basic-accessibility-information.md#name_from_inner_text)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-108">Some UI elements such as [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) and [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) promote their text content as the default accessible name; see [Basic accessibility information](basic-accessibility-information.md#name_from_inner_text).</span></span>

    <span data-ttu-id="eaa32-109">暗黙的なアクセシビリティ対応の名前として内部テキスト コンテンツを昇格させない画像などのコントロールに対し、明示的にアクセシビリティ対応の名前を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="eaa32-109">You should set the accessible name explicitly for images or other controls that do not promote inner text content as an implicit accessible name.</span></span> <span data-ttu-id="eaa32-110">フォーム要素のラベルのテキストは、ラベルと入力を関連付けるために、Microsoft UI オートメーション モデルの [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) ターゲットとして使うことができるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="eaa32-110">You should use labels for form elements so that the label text can be used as a [**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) target in the Microsoft UI Automation model for correlating labels and inputs.</span></span> <span data-ttu-id="eaa32-111">ユーザーに、通常アクセシビリティ対応の名前に含まれているものよりも詳しい UI のガイダンスを提供する場合は、アクセシビリティ対応の説明やヒントを用意すると、UI の内容がわかりやすくなります。</span><span class="sxs-lookup"><span data-stu-id="eaa32-111">If you want to provide more UI guidance for users than is typically included in the accessible name, accessible descriptions and tooltips help users understand the UI.</span></span>

    <span data-ttu-id="eaa32-112">詳しくは、「[アクセシビリティ対応の名前](basic-accessibility-information.md#accessible_name)」と「[アクセシビリティ対応の説明](basic-accessibility-information.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-112">For more info, see [Accessible name](basic-accessibility-information.md#accessible_name) and [Accessible description](basic-accessibility-information.md).</span></span>

2.  <span data-ttu-id="eaa32-113">キーボード アクセシビリティを実装します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-113">Implement keyboard accessibility:</span></span>

    * <span data-ttu-id="eaa32-114">UI 用の既定のタブ インデックスの順序をテストします。</span><span class="sxs-lookup"><span data-stu-id="eaa32-114">Test the default tab index order for a UI.</span></span> <span data-ttu-id="eaa32-115">必要に応じてタブ インデックスの順序を調整します。このとき、特定のコントロールの有効化または無効化、一部の UI 要素の [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) の既定値の変更が必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="eaa32-115">Adjust the tab index order if necessary, which may require enabling or disabling certain controls, or changing the default values of [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) on some of the UI elements.</span></span>
    * <span data-ttu-id="eaa32-116">コンポジット要素に方向キーのナビゲーションをサポートするコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="eaa32-116">Use controls that support arrow-key navigation for composite elements.</span></span> <span data-ttu-id="eaa32-117">既定のコントロールの場合、通常、方向キーのナビゲーションは既に実装されています。</span><span class="sxs-lookup"><span data-stu-id="eaa32-117">For default controls, the arrow-key navigation is typically already implemented.</span></span>
    * <span data-ttu-id="eaa32-118">キーボードのアクティブ化をサポートするコントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="eaa32-118">Use controls that support keyboard activation.</span></span> <span data-ttu-id="eaa32-119">既定のコントロール、特に UI オートメーションの [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) パターンをサポートするものの場合は、基本的にキーボードのアクティブ化が利用できます。該当するコントロールの説明書をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-119">For default controls, particularly those that support the UI Automation [**Invoke**](https://msdn.microsoft.com/library/windows/apps/BR242582) pattern, keyboard activation is typically available; check the documentation for that control.</span></span>
    * <span data-ttu-id="eaa32-120">対話式操作をサポートする UI の一部に対するアクセス キーを設定するか、ショートカット キーを実装します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-120">Set access keys or implement accelerator keys for specific parts of the UI that support interaction.</span></span>
    * <span data-ttu-id="eaa32-121">UI で使うカスタム コントロールで、アクティブ化用に適切な [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) サポートを設定した状態でコントロールが実装され、アクティブ化キー、トラバーサル キー、アクセス キーまたはショートカット キーのサポートに必要なキー処理の上書きが定義されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-121">For any custom controls that you use in your UI, verify that you have implemented these controls with correct [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) support for activation, and defined overrides for key handling as needed to support activation, traversal and access or accelerator keys.</span></span>

    <span data-ttu-id="eaa32-122">詳しくは、「[キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-122">For more info, see [Keyboard interactions](https://msdn.microsoft.com/library/windows/apps/Mt185607).</span></span>

3.  <span data-ttu-id="eaa32-123">テキスト コントラストが適切であること、ハイ コントラスト テーマで要素が正しくレンダリングされること、色が正しく使われていることを確認するため、UI を表示して検証します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-123">Visually verify your UI to ensure that the text contrast is adequate, elements render correctly in the high-contrast themes, and colors are used correctly.</span></span>

    * <span data-ttu-id="eaa32-124">ディスプレイの 1 インチあたりのドット数 (dpi) の値を調整するシステム ディスプレイ オプションを使い、DPI の値の変更に合わせてアプリの UI が正常に拡大縮小されることを確認します </span><span class="sxs-lookup"><span data-stu-id="eaa32-124">Use the system display options that adjust the display's dots per inch (dpi) value, and ensure that your app UI scales correctly when the dpi value changes.</span></span> <span data-ttu-id="eaa32-125">(一部のユーザーはアクセシビリティ対応オプションとして DPI の値を変更します。これは、**[コンピューターの簡単操作]** から設定できます)。</span><span class="sxs-lookup"><span data-stu-id="eaa32-125">(Some users change dpi values as an accessibility option, it's available from **Ease of Access**.)</span></span>
    * <span data-ttu-id="eaa32-126">色分析ツールを使って、視覚的なテキストのコントラスト比が 4.5:1 以上であることを検証します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-126">Use a color analyzer tool to verify that the visual text contrast ratio is at least 4.5:1.</span></span>
    * <span data-ttu-id="eaa32-127">ハイ コントラスト テーマに切り替え、アプリの UI が読みやすく使いやすいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-127">Switch to a high contrast theme and verify that the UI for your app is readable and usable.</span></span>
    * <span data-ttu-id="eaa32-128">UI が情報を伝える唯一の手段として色を使っていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-128">Ensure that your UI doesn’t use color as the only way to convey information.</span></span>

    <span data-ttu-id="eaa32-129">詳しくは、「[ハイ コントラスト テーマ](high-contrast-themes.md)」と「[アクセシビリティに対応したテキストの要件](accessible-text-requirements.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-129">For more info, see [High-contrast themes](high-contrast-themes.md) and [Accessible text requirements](accessible-text-requirements.md).</span></span>

4.  <span data-ttu-id="eaa32-130">アクセシビリティ ツールを実行し、報告された問題に対処して、画面の読み上げを確認します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-130">Run accessibility tools, address reported issues, and verify the screen reading experience.</span></span>

    <span data-ttu-id="eaa32-131">[**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) などのツールを使ってプログラムによるアクセスを検証し、[**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) などの診断ツールを実行して一般的なエラーを見つけます。画面の読み上げの確認には、ナレーターを使います。</span><span class="sxs-lookup"><span data-stu-id="eaa32-131">Use tools such as [**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) to verify programmatic access, run diagnostic tools such as [**AccChecker**](https://msdn.microsoft.com/library/windows/desktop/Hh920985) to discover common errors, and verify the screen reading experience with Narrator.</span></span>

    <span data-ttu-id="eaa32-132">詳しくは、「[アクセシビリティ テスト](accessibility-testing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-132">For more info, see [Accessibility testing](accessibility-testing.md).</span></span>

5.  <span data-ttu-id="eaa32-133">アプリ マニフェストの設定がアクセシビリティ ガイドラインに準拠しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-133">Make sure your app manifest settings follow accessibility guidelines.</span></span>

6.  <span data-ttu-id="eaa32-134">Microsoft Store でアプリがアクセシビリティ対応であることを宣言します。</span><span class="sxs-lookup"><span data-stu-id="eaa32-134">Declare your app as accessible in the Microsoft Store.</span></span>

    <span data-ttu-id="eaa32-135">アクセシビリティ サポートの基準を実装したら、Microsoft Store でアプリがアクセシビリティ対応であることを宣言することで、より多くのユーザーにアプリを提供し、さらに良い評価を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="eaa32-135">If you implemented the baseline accessibility support, declaring your app as accessible in the Microsoft Store can help reach more customers and get some additional good ratings.</span></span>

    <span data-ttu-id="eaa32-136">詳しくは、「[ストア内のアクセシビリティ](accessibility-in-the-store.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="eaa32-136">For more info, see [Accessibility in the Store](accessibility-in-the-store.md).</span></span>

<span id="related_topics"/>

## <a name="related-topics"></a><span data-ttu-id="eaa32-137">関連トピック</span><span class="sxs-lookup"><span data-stu-id="eaa32-137">Related topics</span></span>  
* [<span data-ttu-id="eaa32-138">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="eaa32-138">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="eaa32-139">アクセシビリティのための設計</span><span class="sxs-lookup"><span data-stu-id="eaa32-139">Design for accessibility</span></span>](https://msdn.microsoft.com/library/windows/apps/Hh700407)
* [<span data-ttu-id="eaa32-140">避ける事項</span><span class="sxs-lookup"><span data-stu-id="eaa32-140">Practices to avoid</span></span>](practices-to-avoid.md) 
