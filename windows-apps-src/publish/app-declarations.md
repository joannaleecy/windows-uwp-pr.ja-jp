---
author: jnHs
Description: Product declarations help make sure your app is displayed appropriately in the Microsoft Store and offered to the right set of customers.
title: 製品の宣言
ms.assetid: 3AF618F3-2B47-4A57-B7E8-1DF979D4A82C
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: de519f37c5eacfa64f23d0f438701d4ae9dbc934
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7168517"
---
# <a name="product-declarations"></a><span data-ttu-id="cab6b-103">製品の宣言</span><span class="sxs-lookup"><span data-stu-id="cab6b-103">Product declarations</span></span>

<span data-ttu-id="cab6b-104">[申請プロセス](app-submissions.md)の [[プロパティ](enter-app-properties.md)] ページの**製品の宣言**」セクションでは、アプリが適切に表示され、顧客、およびアプリの使用方法をわかりやすくの適切なセットに提供されることを確認するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="cab6b-104">The **Product declarations** section of the [Properties](enter-app-properties.md) page of the [submission process](app-submissions.md) helps make sure your app is displayed appropriately and offered to the right set of customers, and helps them understand how they can use your app.</span></span>

<span data-ttu-id="cab6b-105">以下のセクションでは、いくつかの宣言と各宣言がアプリに適用するかどうかを決定するときに考慮する必要があるについて説明します。</span><span class="sxs-lookup"><span data-stu-id="cab6b-105">The following sections describe some of the declarations and what you need to consider when determining whether each declaration applies to your app.</span></span> <span data-ttu-id="cab6b-106">これらの宣言の 2 つが選ばれて既定 (以下のとおりです。) に注意してください。製品のカテゴリ、に応じて追加の宣言を確認することも可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-106">Note that two of these declarations are checked by default (as described below.) Depending on your product's category, you may also see additional declarations.</span></span> <span data-ttu-id="cab6b-107">必ずすべての宣言を確認し、申請が正確に反映されることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="cab6b-107">Be sure to review all of the declarations and ensure they accurately reflect your submission.</span></span>

## <a name="this-app-allows-users-to-make-purchases-but-does-not-use-the-microsoft-store-commerce-system"></a><span data-ttu-id="cab6b-108">このアプリは、購入を行うことができますが、Microsoft Store コマース システムを使用できません。</span><span class="sxs-lookup"><span data-stu-id="cab6b-108">This app allows users to make purchases, but does not use the Microsoft Store commerce system.</span></span>

<span data-ttu-id="cab6b-109">ほぼすべての申請では、このチェック ボックスをオフのままにする必要があります、アプリを購入する機会を提供するためはまたは消費またはアプリ内で使用できる項目は、アドオンの申請を作成して Microsoft Store アプリ内購入 API を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-109">For nearly every submission, you should leave this box unchecked, since apps which offer opportunities to purchase items which are or can be consumed or used within your app must use the Microsoft Store in-app purchase API to create and submit the add-ons.</span></span> <span data-ttu-id="cab6b-110">購入機能、[に準拠している限り、Microsoft のコマース エンジンを使用せず、アプリ内購入機能を提供する続けることが作成され、2015 年 6 月 29 日より前に提出されたアプリごと、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies#108-financial-transactions)します。</span><span class="sxs-lookup"><span data-stu-id="cab6b-110">Per the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement), apps that were created and submitted prior to June 29, 2015, could continue to offer in-app purchasing functionality without using Microsoft's commerce engine, so long as the purchase functionality complies with the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies#108-financial-transactions).</span></span> <span data-ttu-id="cab6b-111">アプリがこれに該当する場合、このチェック ボックスをオンにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-111">If this applies to your app, you must check this box.</span></span> <span data-ttu-id="cab6b-112">それ以外の場合は、オフのままにします。</span><span class="sxs-lookup"><span data-stu-id="cab6b-112">Otherwise, leave it unchecked.</span></span>

## <a name="this-app-has-been-tested-to-meet-accessibility-guidelines"></a><span data-ttu-id="cab6b-113">このアプリは、アクセシビリティ ガイドラインを満していることがテストされました。</span><span class="sxs-lookup"><span data-stu-id="cab6b-113">This app has been tested to meet accessibility guidelines.</span></span>

<span data-ttu-id="cab6b-114">このボックスをオンにすると、ストアでアクセシビリティ対応アプリを明確に探しているユーザーが、そのアプリを見つけることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-114">Checking this box makes your app discoverable to customers who are specifically looking for accessible apps in the Store.</span></span>

<span data-ttu-id="cab6b-115">このチェック ボックスは、次の項目のすべてを行った場合のみオンにしてください。</span><span class="sxs-lookup"><span data-stu-id="cab6b-115">You should only check this box if you have done all of the following items:</span></span>

-   <span data-ttu-id="cab6b-116">すべての UI 要素に、対応するアクセシビリティ情報 (アクセシビリティに対応した名前など) を設定した。</span><span class="sxs-lookup"><span data-stu-id="cab6b-116">Set all the relevant accessibility info for UI elements, such as accessible names.</span></span>
-   <span data-ttu-id="cab6b-117">タブ オーダー、キーボードのアクティブ化、方向キーによるナビゲーション、ショートカットを考慮して、キーボードのナビゲーションと操作を実装した。</span><span class="sxs-lookup"><span data-stu-id="cab6b-117">Implemented keyboard navigation and operations, taking into account tab order, keyboard activation, arrow keys navigation, shortcuts.</span></span>
-   <span data-ttu-id="cab6b-118">4.5:1 のテキスト コントラスト比を守っているなど、視覚表現がアクセシビリティに対応していて、ユーザーに情報を伝えるときに色だけに依存していない。</span><span class="sxs-lookup"><span data-stu-id="cab6b-118">Ensured an accessible visual experience by including such things as a 4.5:1 text contrast ratio, and don't rely on color alone to convey info to the user.</span></span>
-   <span data-ttu-id="cab6b-119">Inspect、AccChecker などのアクセシビリティ テスト ツールを使ってアプリを検証し、ツールによって検出された優先度の高いすべてのエラーを解決した。</span><span class="sxs-lookup"><span data-stu-id="cab6b-119">Used accessibility testing tools, such as Inspect or AccChecker, to verify your app, and resolve all high-priority errors detected by those tools.</span></span>
-   <span data-ttu-id="cab6b-120">アプリの主要なシナリオの全体にわたって、ナレーター、拡大鏡、スクリーン キーボード、ハイ コントラスト、高 DPI などの機能やツールの動作を確認した。</span><span class="sxs-lookup"><span data-stu-id="cab6b-120">Verified the app’s key scenarios from end to end using such facilities and tools as Narrator, Magnifier, On Screen Keyboard, High Contrast, and High DPI.</span></span>

<span data-ttu-id="cab6b-121">アプリをアクセシビリティ対応として宣言すると、障碍を持つユーザーも含めてすべてのユーザーがアプリにアクセスできることに同意したことになります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-121">When you declare your app as accessible, you agree that your app is accessible to all customers, including those with disabilities.</span></span> <span data-ttu-id="cab6b-122">たとえば、アプリをハイ コントラスト モードやスクリーン リーダーでテストしたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="cab6b-122">For example, this means you have tested the app with high-contrast mode and with a screen reader.</span></span> <span data-ttu-id="cab6b-123">ユーザー インターフェイスがキーボード、拡大鏡、その他のアクセシビリティ ツールで適切に機能することも検証しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-123">You've also verified that the user interface functions correctly with a keyboard, the Magnifier, and other accessibility tools.</span></span>

<span data-ttu-id="cab6b-124">詳しくは、[アクセシビリティ](../design/accessibility/accessibility.md)、[アクセシビリティのテスト](../design/accessibility/accessibility-testing.md)、および[ストア内のアクセシビリティ](../design/accessibility/accessibility-in-the-store.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cab6b-124">For more info, see [Accessibility](../design/accessibility/accessibility.md), [Accessibility testing](../design/accessibility/accessibility-testing.md), and [Accessibility in the Store](../design/accessibility/accessibility-in-the-store.md).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="cab6b-125">具体的にはエンジニア リングし、その目的のためにテストがない限り、アプリがアクセシビリティ対応の一覧をしないでください。</span><span class="sxs-lookup"><span data-stu-id="cab6b-125">Don't list your app as accessible unless you have specifically engineered and tested it for that purpose.</span></span> <span data-ttu-id="cab6b-126">アプリをアクセシビリティ対応と宣言しているのにアクセシビリティを実際にサポートしていないと、コミュニティから否定的なフィードバックを受けるおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-126">If your app is declared as accessible, but it doesn’t actually support accessibility, you'll probably receive negative feedback from the community.</span></span>

## <a name="customers-can-install-this-app-to-alternate-drives-or-removable-storage"></a><span data-ttu-id="cab6b-127">ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="cab6b-127">Customers can install this app to alternate drives or removable storage.</span></span>

<span data-ttu-id="cab6b-128">既定では、ユーザーを外部ドライブなどのメディアや、SD カードなど、非システム ボリュームにドライブまたは外部のリムーバブル ストレージにアプリをインストールできるように、このチェック ボックスがオンです。</span><span class="sxs-lookup"><span data-stu-id="cab6b-128">This box is checked by default, to allow customers to install your app to external or removable storage media such as an SD card, or to a non-system volume drive such as an external drive.</span></span>

<span data-ttu-id="cab6b-129">アプリが代替ドライブやリムーバブル記憶域にインストールされていることを防ぐのみがデバイスに内部ハード ドライブへのインストールを許可する場合は、このチェック ボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="cab6b-129">If you want to prevent your app from being installed to alternate drives or removable storage, and only allow installation to the internal hard drive on their device, uncheck this box.</span></span> <span data-ttu-id="cab6b-130">(注アプリ*だけ*が参照できるように、インストールを制限するオプションがないことは、リムーバブル記憶域メディアにインストールする)。</span><span class="sxs-lookup"><span data-stu-id="cab6b-130">(Note that there is no option to restrict installation so that an app can *only* be installed to removable storage media.)</span></span>


## <a name="windows-can-include-this-apps-data-in-automatic-backups-to-onedrive"></a><span data-ttu-id="cab6b-131">Windows では、このアプリのデータを OneDrive への自動バックアップに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="cab6b-131">Windows can include this app's data in automatic backups to OneDrive.</span></span>

<span data-ttu-id="cab6b-132">このボックスは、Windows が OneDrive に自動バックアップすることをユーザーが選んだ場合にアプリのデータを含めることができるように、既定でオンになっています。</span><span class="sxs-lookup"><span data-stu-id="cab6b-132">This box is checked by default, to allow your app's data to be included when a customer chooses to have Windows make automated backups to OneDrive.</span></span>

<span data-ttu-id="cab6b-133">アプリのデータが自動バックアップに含まれないようにする場合は、このボックスをオフにします。</span><span class="sxs-lookup"><span data-stu-id="cab6b-133">If you want to prevent your app's data from being included in automated backups, uncheck this box.</span></span>


## <a name="this-app-sends-kinect-data-to-external-services"></a><span data-ttu-id="cab6b-134">このアプリは、外部サービスに Kinect データを送信します。</span><span class="sxs-lookup"><span data-stu-id="cab6b-134">This app sends Kinect data to external services.</span></span> 

<span data-ttu-id="cab6b-135">アプリが Kinect データを使用して、でも外部サービスに送信された場合は、このボックスをオンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cab6b-135">If your app uses Kinect data and sends it to any external service, you must check this box.</span></span>



 

 

 




