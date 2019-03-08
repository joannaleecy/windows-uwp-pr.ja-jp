---
Description: アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。
title: 一般的な認定エラーの回避
ms.assetid: 9E9E3841-2F9B-42D4-B5F8-4C7C31E42E3D
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 62c99c159ff68201919fa15baded999e3b6a2477
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625797"
---
# <a name="avoid-common-certification-failures"></a><span data-ttu-id="f8914-104">一般的な認定エラーの回避</span><span class="sxs-lookup"><span data-stu-id="f8914-104">Avoid common certification failures</span></span>


<span data-ttu-id="f8914-105">アプリの認定の妨げになることが多い問題、またはアプリの公開後のスポット チェックで識別された問題を回避するために、このリストを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8914-105">Review this list to help avoid issues that frequently prevent apps from getting certified, or that might be identified during a spot check after the app is published.</span></span>

> [!NOTE]
> <span data-ttu-id="f8914-106">確認してください、 [Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)アプリが一覧表示の要件をすべてを満たしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8914-106">Be sure to review the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies) to ensure your app meets all of the requirements listed there.</span></span>

-   <span data-ttu-id="f8914-107">アプリを申請するのは、アプリが完成した場合だけにします。</span><span class="sxs-lookup"><span data-stu-id="f8914-107">Submit your app only when it's finished.</span></span> <span data-ttu-id="f8914-108">アプリの説明を使って今後の機能を言及することをお勧めしますが、不完全なセクションや、作成中の Web ページへのリンクなど、アプリが不完全であるという印象をユーザーに与えるものをアプリに含めないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="f8914-108">You're welcome to use your app's description to mention upcoming features, but make sure that your app doesn't contain incomplete sections, links to web pages that are under construction, or anything else that would give a customer the impression that your app is incomplete.</span></span>

-   <span data-ttu-id="f8914-109">アプリを提出する前に、[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md)します。</span><span class="sxs-lookup"><span data-stu-id="f8914-109">[Test your app with the Windows App Certification Kit](../debug-test-perf/windows-app-certification-kit.md) before you submit your app.</span></span>

-   <span data-ttu-id="f8914-110">できるだけアプリの安定性が高くなるように、複数の異なる構成でアプリをテストします。</span><span class="sxs-lookup"><span data-stu-id="f8914-110">Test your app on several different configurations to ensure that it's as stable as possible.</span></span>

-   <span data-ttu-id="f8914-111">ネットワークに接続できない状況でもアプリがクラッシュしないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8914-111">Ensure that your app doesn't crash without network connectivity.</span></span> <span data-ttu-id="f8914-112">実際に使うためには接続を必要とするアプリであっても、接続が存在しない状態で正常に動作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8914-112">Even if a connection is required to actually use your app, it needs to perform appropriately when no connection is present.</span></span>

-   <span data-ttu-id="f8914-113">テスト アカウントのユーザー名とパスワード (ユーザーがサービスにログインする必要のあるアプリの場合) や、非表示の機能やロックされている機能へのアクセスに必要な手順など、アプリを使うために [必要な情報を提供](notes-for-certification.md) してください。</span><span class="sxs-lookup"><span data-stu-id="f8914-113">[Provide any necessary info](notes-for-certification.md) required to use your app, such as the user name and password for a test account if your app requires users to log in to a service, or any steps required to access hidden or locked features.</span></span>

-   <span data-ttu-id="f8914-114">含める、[プライバシー ポリシー URL](enter-app-properties.md#privacy-policy-url)アプリでは、1 つ; が必要な場合など、アプリのあらゆる種類の任意の方法で個人情報にアクセスまたはそれ以外の場合は、法律によって必要とします。</span><span class="sxs-lookup"><span data-stu-id="f8914-114">Include a [privacy policy URL](enter-app-properties.md#privacy-policy-url) if your app requires one; for example, if your app accesses any kind of personal information in any way or is otherwise required by law.</span></span> <span data-ttu-id="f8914-115">アプリのプライバシー ポリシーが必要かどうかを判断するためには、確認、[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)と[Microsoft Store ポリシー](https://docs.microsoft.com/legal/windows/agreements/store-policies)します。</span><span class="sxs-lookup"><span data-stu-id="f8914-115">To help determine if your app requires a privacy policy, review the [App Developer Agreement](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement) and the [Microsoft Store Policies](https://docs.microsoft.com/legal/windows/agreements/store-policies).</span></span>

-   <span data-ttu-id="f8914-116">アプリの内容を明確に表せるように、アプリの説明はできるだけ詳しく記載します。</span><span class="sxs-lookup"><span data-stu-id="f8914-116">Make sure that your app's description clearly represents what your app does.</span></span> <span data-ttu-id="f8914-117">ヘルプが必要な場合は、[アプリに関する優れた説明を記載する](write-a-great-app-description.md) ためのガイダンスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f8914-117">For help, see our guidance on [writing a great app description](write-a-great-app-description.md).</span></span>

-   <span data-ttu-id="f8914-118">[年齢区分](age-ratings.md)のセクションのすべての質問に正確で完全な回答を入力してください。</span><span class="sxs-lookup"><span data-stu-id="f8914-118">Provide complete and accurate responses to all of the questions in the [Age ratings](age-ratings.md) section.</span></span>

-   <span data-ttu-id="f8914-119">アクセシビリティのシナリオを想定して具体的な設計とテストを行っていない限り、[アプリをアクセシビリティ対応として宣言](product-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines)しないでください。</span><span class="sxs-lookup"><span data-stu-id="f8914-119">Don't [declare your app as accessible](product-declarations.md#this-app-has-been-tested-to-meet-accessibility-guidelines) unless you have specifically engineered and tested it for accessibility scenarios.</span></span>

-   <span data-ttu-id="f8914-120">アプリが [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間から商取引 API を使う場合、アプリを必ずテストして、一般的な例外が処理されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f8914-120">If your app uses the commerce APIs from the [**Windows.ApplicationModel.Store**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) namespace, make sure to test the app and verify that it handles typical exceptions.</span></span> <span data-ttu-id="f8914-121">また、アプリがテスト用途のみの [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) クラスではなく、[**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) クラスを使っていることも確認してください。</span><span class="sxs-lookup"><span data-stu-id="f8914-121">Also, make sure that your app uses the [**CurrentApp**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp) class and not the [**CurrentAppSimulator**](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentAppSimulator) class, which is for testing purposes only.</span></span> <span data-ttu-id="f8914-122">(アプリが Windows 10 バージョン 1607 以降のバージョンをターゲットにする場合は、Windows.ApplicationModel.Store 名前空間ではなく、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間を使用することをお勧めします)。</span><span class="sxs-lookup"><span data-stu-id="f8914-122">(Note that if your app targets Windows 10, version 1607 or later, we recommend that you use members of the [Windows.Services.Store](https://docs.microsoft.com/uwp/api/windows.services.store) namespace instead of the Windows.ApplicationModel.Store namespace.)</span></span>


 

 




