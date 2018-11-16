---
author: Mtoepke
title: マルチ ユーザー アプリケーションの概要
description: Xbox のマルチ ユーザー モデルの簡単な概要です。
ms.author: scotmi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 2dde6ed3-7f53-48a6-aebe-2605230decb8
ms.localizationpriority: medium
ms.openlocfilehash: 7534b6764bc98c415b557d100d869df186453626
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6980692"
---
# <a name="introduction-to-multi-user-applications"></a><span data-ttu-id="2590d-104">マルチ ユーザー アプリケーションの概要</span><span class="sxs-lookup"><span data-stu-id="2590d-104">Introduction to multi-user applications</span></span>

<span data-ttu-id="2590d-105">このトピックは、Xbox のマルチ ユーザー モデルの簡単な概要となるものです。</span><span class="sxs-lookup"><span data-stu-id="2590d-105">This topic is intended to be a simple high-level introduction to the Xbox multi-user model.</span></span>

<span data-ttu-id="2590d-106">Xbox One ユーザー モデルは、複数のユーザーが単一のデバイスで互いに協力しながらゲームをプレイできるゲーム機本体の要件に合わせて調整されています。</span><span class="sxs-lookup"><span data-stu-id="2590d-106">The Xbox One user model is tuned to the requirements of a gaming console that supports multiple users playing games cooperatively on a single device.</span></span> <span data-ttu-id="2590d-107">それぞれが自分のコントローラーを持つ複数のユーザーがサインインして、同時に 1 つの対話型セッションでコンソールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-107">It enables multiple users, each with their own controller, to be signed in and using the console at the same time in a single interactive session.</span></span> <span data-ttu-id="2590d-108">これは、他の Windows デバイスとは異なります。</span><span class="sxs-lookup"><span data-stu-id="2590d-108">This is different from other Windows devices.</span></span> <span data-ttu-id="2590d-109">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="2590d-109">For example:</span></span>
* <span data-ttu-id="2590d-110">**Windows のデスクトップ PC** では、同じデバイスを使用する複数のユーザーが許可されますが、各ユーザーに独自の対話型セッションがあり、各セッションはデバイス上の他のセッションから完全に独立しています。</span><span class="sxs-lookup"><span data-stu-id="2590d-110">**Windows desktop PCs** allow multiple users to use the same device, but each user has their own interactive session and each session is completely independent of the other sessions on the device.</span></span>
* <span data-ttu-id="2590d-111">**Windows Phone** では、デバイスを使用するシングル ユーザーのみを許可します。</span><span class="sxs-lookup"><span data-stu-id="2590d-111">**Windows phones** allow only a single user to use the device.</span></span> <span data-ttu-id="2590d-112">OOBE (Out-Of-Box Experience) 中にそのシングル ユーザーが決定され、ユーザーはサインイン後にサインアウトできません。</span><span class="sxs-lookup"><span data-stu-id="2590d-112">That single user is determined during the OOBE (out-of-box-experience) and the user cannot sign out after they are signed in.</span></span> <span data-ttu-id="2590d-113">事実上、別のユーザーがデバイスを使用するにはデバイスをリセットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2590d-113">In effect, if a different user wants to use the device, the device has to be reset.</span></span> 
* <span data-ttu-id="2590d-114">**Xbox One** では、複数のユーザーがサインインして、単一の対話型セッションで同時にデバイスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-114">**Xbox One** allows multiple users to be signed in and use the device at the same time in a single interactive session.</span></span>

<span data-ttu-id="2590d-115">Xbox One ユーザー モデル内の各ユーザーには、対応するローカル ユーザー アカウントがあります。</span><span class="sxs-lookup"><span data-stu-id="2590d-115">Each user in the Xbox One user model is backed by a local user account.</span></span> <span data-ttu-id="2590d-116">このローカル ユーザー アカウントは、Xbox Live アカウント (と Microsoft アカウント) に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="2590d-116">This local user account is associated with an Xbox Live account (and therefore a Microsoft account).</span></span> <span data-ttu-id="2590d-117">これは、Xbox のユーザー アカウントには Xbox Live アカウントおよび Microsoft アカウントとの厳密な 1 対 1 のマッピングがあることを意味します。</span><span class="sxs-lookup"><span data-stu-id="2590d-117">This means that there is a strict one-to-one mapping of an Xbox user account to an Xbox Live account and to a Microsoft account.</span></span>

## <a name="single-user-applications"></a><span data-ttu-id="2590d-118">シングル ユーザー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="2590d-118">Single user applications</span></span>
<span data-ttu-id="2590d-119">既定では、ユニバーサル Windows プラットフォーム (UWP) アプリは、アプリケーションを起動したユーザーのコンテキストで実行されます。</span><span class="sxs-lookup"><span data-stu-id="2590d-119">By default, Universal Windows Platform (UWP) apps run in the context of the user that launched the application.</span></span> <span data-ttu-id="2590d-120">これらの*シングル ユーザー アプリケーション* (SUA) は、その 1 人のユーザーのみを認識し、他の Windows デバイス上のユーザー モデルと互換性があるモードで実行されます。</span><span class="sxs-lookup"><span data-stu-id="2590d-120">These *single user applications* (SUAs) are only aware of that single user, and run in a mode that is compatible with the user model on other Windows devices.</span></span> <span data-ttu-id="2590d-121">この Xbox ユーザー モデルでは、アプリに関連付けられているユーザーが管理され、アプリの起動時にユーザーがサインインすることが保証されます。</span><span class="sxs-lookup"><span data-stu-id="2590d-121">The Xbox user model manages which user is associated with the app and guarantees that a user is signed in when the app is launched.</span></span> <span data-ttu-id="2590d-122">このモデルでは、UWP アプリやゲームの作成者が Xbox 上で実行するために特別な操作をする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2590d-122">In this model, UWP app and game authors do not have to do anything special to run on Xbox.</span></span> 

## <a name="multi-user-applications"></a><span data-ttu-id="2590d-123">マルチ ユーザー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="2590d-123">Multi-user applications</span></span>
<span data-ttu-id="2590d-124">UWP ゲームでは、Xbox One のマルチ ユーザー モデルを選択できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-124">UWP games can choose to opt into the Xbox One multi-user model.</span></span> <span data-ttu-id="2590d-125">これらの*マルチ ユーザー アプリケーション* (MUA) はシステム アカウント (既定のアカウントと呼ばれます) のコンテキストで実行され、Xbox One ユーザー モデルのパワーと柔軟性を最大限に活用できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-125">These *multi-user applications* (MUAs) run in the context of a system account (called the Default Account) and can take full advantage of the flexibility and power of the Xbox One user model.</span></span> <span data-ttu-id="2590d-126">この Xbox ユーザー モデルでは、ゲームに関連付けられているユーザーは管理されず、ユーザーがゲームを実行するためにサインインする必要もありません。</span><span class="sxs-lookup"><span data-stu-id="2590d-126">For these games, the Xbox user model does not manage which user is associated with the game and does not even require that a user is signed in for the game to run.</span></span> <span data-ttu-id="2590d-127">これは、ユーザー要件を明示的に認識および管理するように作成する必要があることを意味します (サインインしたユーザーが必要かどうか、現在のユーザーの概念を実装するかどうか、複数のユーザーからの入力を同時に許可するかどうかなど)。</span><span class="sxs-lookup"><span data-stu-id="2590d-127">This means that they have to be written to be explicitly aware of, and manage their user requirements: whether they require a signed-in user or not, whether they implement the concept of a current user, whether they allow simultaneous input from multiple users, and so on.</span></span>
   
<span data-ttu-id="2590d-128">マルチ ユーザー モデルを選ぶには:</span><span class="sxs-lookup"><span data-stu-id="2590d-128">To opt into the multi-user model:</span></span>   
1. <span data-ttu-id="2590d-129">Visual Studio でプロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="2590d-129">Open your project in Visual Studio.</span></span>   
2. <span data-ttu-id="2590d-130">package.appxmanifest.xml ファイルを選びます。</span><span class="sxs-lookup"><span data-stu-id="2590d-130">Select the package.appxmanifest.xml file.</span></span>   
3. <span data-ttu-id="2590d-131">右クリックして、**[コードの表示]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="2590d-131">Right-click and select **View Code**.</span></span>   
4. <span data-ttu-id="2590d-132">次の行を `<Properties></Properties>` セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="2590d-132">Add the following line in the `<Properties></Properties>` section:</span></span>

```
<uap:SupportedUsers>multiple</uap:SupportedUsers>
```

### <a name="identifying-users-and-inputs"></a><span data-ttu-id="2590d-133">ユーザーおよび入力の識別</span><span class="sxs-lookup"><span data-stu-id="2590d-133">Identifying users and inputs</span></span>
<span data-ttu-id="2590d-134">開発者は、KeyUp および KeyDown ルーティング イベントで使用される KeyRoutedEventArgs.DeviceId を使用して、さまざまな入力によって生成されるイベントを区別できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-134">Developers can use KeyRoutedEventArgs.DeviceId, used by KeyUp and KeyDown routed events, to differentiate the events generated from different inputs.</span></span>
<span data-ttu-id="2590d-135">Windows.System.UserDeviceAssociation.FindUserFromDeviceId メソッドを使用すると、特定の入力に関連付けられたユーザーを特定することができます。</span><span class="sxs-lookup"><span data-stu-id="2590d-135">Using the Windows.System.UserDeviceAssociation.FindUserFromDeviceId method will help to identify the user associated to a specific input.</span></span>

<span data-ttu-id="2590d-136">詳しくは、[KeyRoutedEventArgs.DeviceId](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.keyroutedeventargs.deviceid) のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2590d-136">See the [KeyRoutedEventArgs.DeviceId](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.input.keyroutedeventargs.deviceid) topic for more information.</span></span>


## <a name="guidance-on-which-model-to-choose"></a><span data-ttu-id="2590d-137">モデルの選択に関するガイダンス</span><span class="sxs-lookup"><span data-stu-id="2590d-137">Guidance on which model to choose</span></span>
<span data-ttu-id="2590d-138">すべての UWP アプリと、シングル ユーザーのゲームの大多数は、SUA として作成できます。</span><span class="sxs-lookup"><span data-stu-id="2590d-138">All UWP apps and the majority of single user games can be written to be SUAs.</span></span> <span data-ttu-id="2590d-139">協力型のマルチ プレーヤー ゲームについてのみ、Xbox One のマルチ ユーザー モデルを選ぶことを検討するようお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2590d-139">We recommend that only cooperative multi-player games consider opting into the Xbox One multi-user model.</span></span>

## <a name="see-also"></a><span data-ttu-id="2590d-140">参照</span><span class="sxs-lookup"><span data-stu-id="2590d-140">See also</span></span>
- [<span data-ttu-id="2590d-141">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="2590d-141">UWP on Xbox One</span></span>](index.md)
