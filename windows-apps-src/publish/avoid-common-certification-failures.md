---
author: jnHs
Description: Review this list to help avoid issues that frequently prevent apps from getting certified, or that might be identified during a spot check after the app is published.
title: 一般的な認定エラーの回避
ms.assetid: 9E9E3841-2F9B-42D4-B5F8-4C7C31E42E3D
ms.author: wdg-dev-content
ms.date: 06/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 283856ad163d2e67078c61559f6f8ec667e92b87
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4621808"
---
# <a name="avoid-common-certification-failures"></a><span data-ttu-id="d1dc5-103">一般的な認定エラーの回避</span><span class="sxs-lookup"><span data-stu-id="d1dc5-103">Avoid common certification failures</span></span>


<span data-ttu-id="d1dc5-104">アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-104">Review this list to help avoid issues that frequently prevent apps from getting certified, or that might be identified during a spot check after the app is published.</span></span>

> [!NOTE]
> <span data-ttu-id="d1dc5-105">必ず、アプリがすべての要件を満たしていることを確認する[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を確認してください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-105">Be sure to review the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies) to ensure your app meets all of the requirements listed there.</span></span>

-   <span data-ttu-id="d1dc5-106">アプリを申請するのは、アプリが完成した場合だけにします。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-106">Submit your app only when it's finished.</span></span> <span data-ttu-id="d1dc5-107">アプリの説明を使って今後の機能を言及することをお勧めしますが、不完全なセクションや、作成中の Web ページへのリンクなど、アプリが不完全であるという印象をユーザーに与えるものをアプリに含めないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-107">You're welcome to use your app's description to mention upcoming features, but make sure that your app doesn't contain incomplete sections, links to web pages that are under construction, or anything else that would give a customer the impression that your app is incomplete.</span></span>

-   <span data-ttu-id="d1dc5-108">アプリを申請する前に、[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md)します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-108">[Test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit your app.</span></span>

-   <span data-ttu-id="d1dc5-109">できるだけアプリの安定性が高くなるように、複数の異なる構成でアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-109">Test your app on several different configurations to ensure that it's as stable as possible.</span></span>

-   <span data-ttu-id="d1dc5-110">ネットワークに接続できない状況でもアプリがクラッシュしないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-110">Ensure that your app doesn't crash without network connectivity.</span></span> <span data-ttu-id="d1dc5-111">実際に使うためには接続を必要とするアプリであっても、接続が存在しない状態で正常に動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-111">Even if a connection is required to actually use your app, it needs to perform appropriately when no connection is present.</span></span>

-   <span data-ttu-id="d1dc5-112">テスト アカウントのユーザー名とパスワード (ユーザーがサービスにログインする必要のあるアプリの場合) や、非表示の機能やロックされている機能へのアクセスに必要な手順など、アプリを使うために [必要な情報を提供](notes-for-certification.md) してください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-112">[Provide any necessary info](notes-for-certification.md) required to use your app, such as the user name and password for a test account if your app requires users to log in to a service, or any steps required to access hidden or locked features.</span></span>

-   <span data-ttu-id="d1dc5-113">アプリが何かしらの方法で個人情報にアクセスする、または法律で義務付けられている場合など、アプリに[プライバシー ポリシー](create-app-store-listings.md#privacy-policy)が必要な場合は提供してください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-113">Include a [privacy policy](create-app-store-listings.md#privacy-policy) if your app requires one; for example, if your app accesses any kind of personal information in any way or is otherwise required by law.</span></span> <span data-ttu-id="d1dc5-114">アプリにプライバシー ポリシーが必要とかどうかを判断するためには、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)と[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)を確認します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-114">To help determine if your app requires a privacy policy, review the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) and the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span>

-   <span data-ttu-id="d1dc5-115">アプリの内容を明確に表せるように、アプリの説明はできるだけ詳しく記載します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-115">Make sure that your app's description clearly represents what your app does.</span></span> <span data-ttu-id="d1dc5-116">ヘルプが必要な場合は、[アプリに関する優れた説明を記載する](write-a-great-app-description.md) ためのガイダンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-116">For help, see our guidance on [writing a great app description](write-a-great-app-description.md).</span></span>

-   <span data-ttu-id="d1dc5-117">[年齢区分](age-ratings.md)のセクションのすべての質問に正確で完全な回答を入力してください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-117">Provide complete and accurate responses to all of the questions in the [Age ratings](age-ratings.md) section.</span></span>

-   <span data-ttu-id="d1dc5-118">アクセシビリティのシナリオを想定して具体的な設計とテストを行っていない限り、[アプリをアクセシビリティ対応として宣言](app-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines)しないでください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-118">Don't [declare your app as accessible](app-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines) unless you have specifically engineered and tested it for accessibility scenarios.</span></span>

-   <span data-ttu-id="d1dc5-119">アプリが [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間から商取引 API を使う場合、アプリを必ずテストして、一般的な例外が処理されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-119">If your app uses the commerce APIs from the [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) namespace, make sure to test the app and verify that it handles typical exceptions.</span></span> <span data-ttu-id="d1dc5-120">また、アプリがテスト用途のみの [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) クラスではなく、[**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使っていることも確認してください。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-120">Also, make sure that your app uses the [**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) class and not the [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) class, which is for testing purposes only.</span></span> <span data-ttu-id="d1dc5-121">(アプリが Windows 10 バージョン 1607 以降のバージョンをターゲットにする場合は、Windows.ApplicationModel.Store 名前空間ではなく、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間を使用することをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="d1dc5-121">(Note that if your app targets Windows 10, version 1607 or later, we recommend that you use members of the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace instead of the Windows.ApplicationModel.Store namespace.)</span></span>


 

 




