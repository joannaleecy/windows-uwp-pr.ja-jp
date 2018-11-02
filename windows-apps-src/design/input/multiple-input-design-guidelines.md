---
author: Karl-Bridge-Microsoft
Description: Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.
title: 複数の入力の設計ガイドライン
ms.assetid: 03EB5388-080F-467C-B272-C92BE00F2C69
label: Multiple inputs
template: detail.hbs
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 670caf5c519fcf1b7ff57b47781541d98358aa50
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5935169"
---
# <a name="multiple-inputs"></a><span data-ttu-id="1a9df-103">複数の入力</span><span class="sxs-lookup"><span data-stu-id="1a9df-103">Multiple inputs</span></span>


<span data-ttu-id="1a9df-104">人がお互いにコミュニケーションをとる際に音声とジェスチャを組み合わせて使うように、アプリの操作では、複数の種類とモードの入力を使うと便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="1a9df-104">Just as people use a combination of voice and gesture when communicating with each other, multiple types and modes of input can also be useful when interacting with an app.</span></span>


<span data-ttu-id="1a9df-105">できるだけ多くのユーザーやデバイスに対応するため、可能な限り多くの入力の種類 (ジェスチャ、音声、タッチ、タッチパッド、マウス、キーボード) で作業できるようにアプリを設計することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1a9df-105">To accommodate as many users and devices as possible, we recommend that you design your apps to work with as many input types as possible (gesture, speech, touch, touchpad, mouse, and keyboard).</span></span> <span data-ttu-id="1a9df-106">これにより、柔軟性、操作性、アクセシビリティが最大限に高まります。</span><span class="sxs-lookup"><span data-stu-id="1a9df-106">Doing so will maximize flexibility, usability, and accessibility.</span></span>

<span data-ttu-id="1a9df-107">最初に、アプリで入力を処理するさまざまなシナリオを検討します。</span><span class="sxs-lookup"><span data-stu-id="1a9df-107">To begin, consider the various scenarios in which your app handles input.</span></span> <span data-ttu-id="1a9df-108">アプリ全体で一貫性を保つようにし、プラットフォーム コントロールでは、複数の入力の種類に対応する組み込みサポートを用意します。</span><span class="sxs-lookup"><span data-stu-id="1a9df-108">Try to be consistent throughout your app, and remember that the platform controls provide built-in support for multiple input types.</span></span>

-   <span data-ttu-id="1a9df-109">ユーザーは、複数の入力デバイスを使ってアプリケーションを操作できますか?</span><span class="sxs-lookup"><span data-stu-id="1a9df-109">Can users interact with the application through multiple input devices?</span></span>
-   <span data-ttu-id="1a9df-110">すべての入力方法が常にサポートされていますか?</span><span class="sxs-lookup"><span data-stu-id="1a9df-110">Are all input methods supported at all times?</span></span> <span data-ttu-id="1a9df-111">特定のコントロールでサポートされていますか?</span><span class="sxs-lookup"><span data-stu-id="1a9df-111">With certain controls?</span></span> <span data-ttu-id="1a9df-112">特定の時間や環境でサポートされていますか?</span><span class="sxs-lookup"><span data-stu-id="1a9df-112">At specific times or circumstances?</span></span>
-   <span data-ttu-id="1a9df-113">1 つの入力方法が優先されますか?</span><span class="sxs-lookup"><span data-stu-id="1a9df-113">Does one input method take priority?</span></span>

## <a name="single-or-exclusive-mode-interactions"></a><span data-ttu-id="1a9df-114">単一 (排他) モードの操作</span><span class="sxs-lookup"><span data-stu-id="1a9df-114">Single (or exclusive)-mode interactions</span></span>


<span data-ttu-id="1a9df-115">単一モードの操作では、複数の入力の種類がサポートされますが、1 つのアクションで使用できるのは、1 つのみです。</span><span class="sxs-lookup"><span data-stu-id="1a9df-115">With single-mode interactions, multiple input types are supported, but only one can be used per action.</span></span> <span data-ttu-id="1a9df-116">たとえば、コマンドに音声認識、ナビゲーションにジェスチャなどです。または近接度に応じて、タッチかジェスチャを使用してテキストを入力します。</span><span class="sxs-lookup"><span data-stu-id="1a9df-116">For example, speech recognition for commands, and gestures for navigation; or, text entry using touch or gestures, depending on proximity.</span></span>

## <a name="multimodal-interactions"></a><span data-ttu-id="1a9df-117">マルチモーダル操作</span><span class="sxs-lookup"><span data-stu-id="1a9df-117">Multimodal interactions</span></span>

<span data-ttu-id="1a9df-118">マルチモーダル操作では、1 つのアクションを完了するために複数の入力方法が順番に使われます。</span><span class="sxs-lookup"><span data-stu-id="1a9df-118">With multimodal interactions, multiple input methods in sequence are used to complete a single action.</span></span>

<span data-ttu-id="1a9df-119">音声認識 + ジェスチャ</span><span class="sxs-lookup"><span data-stu-id="1a9df-119">Speech + gesture</span></span>  
<span data-ttu-id="1a9df-120">ユーザーは製品をポイントし、「カートに追加」と言います。</span><span class="sxs-lookup"><span data-stu-id="1a9df-120">The user points to a product, and then says “Add to cart.”</span></span>

<span data-ttu-id="1a9df-121">音声認識 + タッチ</span><span class="sxs-lookup"><span data-stu-id="1a9df-121">Speech + touch</span></span>  
<span data-ttu-id="1a9df-122">ユーザーは長押しを使用して写真を選択し、「写真の送信」と言います。</span><span class="sxs-lookup"><span data-stu-id="1a9df-122">The user selects a photo using press and hold, and then says “Send photo.”</span></span>



