---
Description: Describes the requirements for declaring your Universal Windows Platform (UWP) app as accessible in the Microsoft Store.
ms.assetid: 59FA3B87-75A6-4B30-BA7C-A0E769D68050
title: Microsoft Store 内のアクセシビリティ
label: Accessibility in the Store
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 6a9991cd4a0a3fce630b1c7be64650c79daf74e6
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8893227"
---
# <a name="accessibility-in-the-store"></a><span data-ttu-id="c340b-103">Microsoft Store 内のアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="c340b-103">Accessibility in the Store</span></span>  



<span data-ttu-id="c340b-104">ユニバーサル Windows プラットフォーム (UWP) アプリがアクセシビリティ対応であると Microsoft Store で宣言するための要件について説明します。</span><span class="sxs-lookup"><span data-stu-id="c340b-104">Describes the requirements for declaring your Universal Windows Platform (UWP) app as accessible in the Microsoft Store.</span></span>

<span data-ttu-id="c340b-105">Microsoft Store で認定を受けるためにアプリを提出している間に、アプリがアクセシビリティ対応であることを宣言することができます。</span><span class="sxs-lookup"><span data-stu-id="c340b-105">While submitting your app to the Microsoft Store for certification, you can declare your app as accessible.</span></span> <span data-ttu-id="c340b-106">アクセシビリティ対応アプリであることを宣言すると、視覚に障碍があるユーザーのように、アクセシビリティ対応アプリに興味を持っているユーザーが簡単にそのアプリを見つけられるようになります。</span><span class="sxs-lookup"><span data-stu-id="c340b-106">Declaring your app as accessible makes it easier to discover for users who are interested in accessible apps, such as users who have visual impairments.</span></span> <span data-ttu-id="c340b-107">ユーザーは、Microsoft Store での検索時に**アクセシビリティ対応**のフィルターを使うことで、アクセシビリティ対応アプリを見つけます。</span><span class="sxs-lookup"><span data-stu-id="c340b-107">Users discover accessible apps by using the **Accessible** filter while searching the Microsoft Store.</span></span> <span data-ttu-id="c340b-108">また、アクセシビリティ対応アプリであることを宣言すると、アプリの説明に**アクセシビリティ対応**のタグが追加されます。</span><span class="sxs-lookup"><span data-stu-id="c340b-108">Declaring your app as accessible also adds the **Accessible** tag to your app’s description.</span></span>

<span data-ttu-id="c340b-109">アプリがアクセシビリティ対応であることを宣言して、次のうちの 1 つ以上を使う主なシナリオでユーザーが必要とする [基本的なアクセシビリティ情報](basic-accessibility-information.md) が用意されていることを示します。</span><span class="sxs-lookup"><span data-stu-id="c340b-109">By declaring your app as accessible, you state that it has the [basic accessibility information](basic-accessibility-information.md) that users need for primary scenarios using one or more of the following:</span></span>

* <span data-ttu-id="c340b-110">キーボード。</span><span class="sxs-lookup"><span data-stu-id="c340b-110">The keyboard.</span></span>
* <span data-ttu-id="c340b-111">ハイ コントラスト テーマ。</span><span class="sxs-lookup"><span data-stu-id="c340b-111">A high contrast theme.</span></span>
* <span data-ttu-id="c340b-112">可変 DPI (1 インチあたりのドット数) の設定。</span><span class="sxs-lookup"><span data-stu-id="c340b-112">A variable dots per inch (dpi) setting.</span></span>
* <span data-ttu-id="c340b-113">Windows アクセシビリティ機能 (ナレーター、拡大鏡、スクリーン キーボードなど) のような一般的な支援技術。</span><span class="sxs-lookup"><span data-stu-id="c340b-113">Common assistive technology such as the Windows accessibility features, including Narrator, Magnifier, and On-Screen Keyboard.</span></span>

<span data-ttu-id="c340b-114">アプリをアクセシビリティ対応としてビルドし、テストした場合は、アプリをアクセシビリティ対応として宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c340b-114">You should declare your app as accessible if you built and tested it for accessibility.</span></span> <span data-ttu-id="c340b-115">これは、次のことが完了していることを意味します。</span><span class="sxs-lookup"><span data-stu-id="c340b-115">This means that you did the following:</span></span>

* <span data-ttu-id="c340b-116">名前、役割、値などの UI 要素に関するすべてのアクセシビリティ情報を設定している。</span><span class="sxs-lookup"><span data-stu-id="c340b-116">Set all the relevant accessibility information for UI elements, including name, role, value, and so on.</span></span>
* <span data-ttu-id="c340b-117">キーボードの完全なアクセシビリティを実装している。ユーザーは次のことができる。</span><span class="sxs-lookup"><span data-stu-id="c340b-117">Implemented full keyboard accessibility, enabling the user to:</span></span>
    * <span data-ttu-id="c340b-118">キーボードのみを使ってアプリの主なシナリオを達成する。</span><span class="sxs-lookup"><span data-stu-id="c340b-118">Accomplish primary app scenarios by using only the keyboard.</span></span>
    * <span data-ttu-id="c340b-119">Tab キーを使って論理的な順序で UI 要素を切り替える。</span><span class="sxs-lookup"><span data-stu-id="c340b-119">Tab among UI elements in a logical order.</span></span>
    * <span data-ttu-id="c340b-120">方向キーを使ってコントロール内の UI 要素間を移動する。</span><span class="sxs-lookup"><span data-stu-id="c340b-120">Navigate among UI elements within a control by using the arrow keys.</span></span>
    * <span data-ttu-id="c340b-121">キーボード ショートカットを使ってアプリの主な機能を利用する。</span><span class="sxs-lookup"><span data-stu-id="c340b-121">Use keyboard shortcuts to reach primary app functionality.</span></span>
    * <span data-ttu-id="c340b-122">キーボードがないデバイスで、タブと矢印を同等に扱うためにナレーターのタッチ ジェスチャを使う。</span><span class="sxs-lookup"><span data-stu-id="c340b-122">Use Narrator touch gestures for Tab and arrow equivalency for devices with no keyboard.</span></span>
* <span data-ttu-id="c340b-123">アプリの UI が視覚上のアクセシビリティに対応している。最低でも 4.5:1 のテキスト コントラスト比がある、情報を伝えるときに色だけに依存していない、など。</span><span class="sxs-lookup"><span data-stu-id="c340b-123">Ensured that your app UI is visually accessible: has a minimum text contrast ratio of 4.5:1, does not rely on color alone to convey information, and so on.</span></span>
* <span data-ttu-id="c340b-124">[**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521)、[**UIAVerify**](https://msdn.microsoft.com/library/windows/desktop/Hh920986) などのアクセシビリティ テスト ツールを使ってアクセシビリティの実装が検証されていて、このようなツールで報告される優先度 1 のエラーをすべて解決している。</span><span class="sxs-lookup"><span data-stu-id="c340b-124">Used accessibility testing tools such as [**Inspect**](https://msdn.microsoft.com/library/windows/desktop/Dd318521) and [**UIAVerify**](https://msdn.microsoft.com/library/windows/desktop/Hh920986) to verify your accessibility implementation, and resolved all priority 1 errors reported by such tools.</span></span>
* <span data-ttu-id="c340b-125">ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト テーマ、調整された DPI 設定を使って、エンド ツー エンドでアプリの主なシナリオを検証している。</span><span class="sxs-lookup"><span data-stu-id="c340b-125">Verified your app’s primary scenarios from end to end by using Narrator, Magnifier, On-Screen Keyboard, a high contrast theme, and adjusted dpi settings.</span></span>

<span data-ttu-id="c340b-126">これらの手順と、その実行に役立つリソースへのリンクを確認する場合は、「[アクセシビリティのチェック リスト](accessibility-checklist.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c340b-126">See the [Accessibility checklist](accessibility-checklist.md) for a review of these procedures and links to resources that will help you accomplish them.</span></span>

<span id="related_topics"/>

## <a name="related-topics"></a><span data-ttu-id="c340b-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c340b-127">Related topics</span></span>    
* [<span data-ttu-id="c340b-128">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="c340b-128">Accessibility</span></span>](accessibility.md) 
