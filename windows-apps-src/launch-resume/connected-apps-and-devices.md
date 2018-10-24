---
author: PatrickFarley
title: 接続されるアプリやデバイス ("Rome" プロジェクト)
description: このセクションでは、Remote Systems プラットフォームを使って、リモート デバイスの検出、リモート デバイスでのアプリの起動、リモート デバイス上のアプリ サービスとの通信を行う方法について説明します。
ms.author: pafarley
ms.date: 06/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 接続されているデバイス、リモート システム、"rome"、"rome"プロジェクト
ms.assetid: 7f39d080-1fff-478c-8c51-526472c1326a
ms.localizationpriority: medium
ms.openlocfilehash: d3efb7e094ce1464028dadaa14c6f0bfb3f3b214
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5444873"
---
# <a name="connected-apps-and-devices-project-rome"></a><span data-ttu-id="c98b8-104">接続されるアプリやデバイス ("Rome" プロジェクト)</span><span class="sxs-lookup"><span data-stu-id="c98b8-104">Connected apps and devices (Project Rome)</span></span>

<span data-ttu-id="c98b8-105">このセクションでは、Rome プロジェクトを使ってデバイスとプラットフォーム間でアプリを接続する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-105">This section explains how to connect apps across devices and platforms using Project Rome.</span></span> <span data-ttu-id="c98b8-106">リモート デバイスの検出、リモート デバイス上でのアプリの起動、リモート デバイス上のアプリ サービスとの通信を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-106">Learn how to discover remote devices, launch an app on a remote device, and communicate with an app service on a remote device.</span></span>

<span data-ttu-id="c98b8-107">ほとんどのユーザーは複数のデバイスを持っており、あるデバイスでアクティビティを始めてデバイスで終えることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="c98b8-107">Most users have multiple devices and often begin an activity on one device and finish it on another.</span></span> <span data-ttu-id="c98b8-108">これに対応するため、アプリはデバイスとプラットフォームにまたがる必要があります。</span><span class="sxs-lookup"><span data-stu-id="c98b8-108">To accommodate this, apps need to span devices and platforms.</span></span>

<span data-ttu-id="c98b8-109">Windows 10 バージョン 1607 に導入された[リモート システム API](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems) を使うと、ユーザーがあるデバイスでタスクを開始して別のデバイスで終えることができるアプリを記述できます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-109">The [Remote Systems APIs](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems) introduced in Windows 10, version 1607 enable you to write apps that allow users to start a task on one device and finish it on another.</span></span> <span data-ttu-id="c98b8-110">タスクは中央のフォーカスに残り、ユーザーは最も便利なデバイスで作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-110">The task remains the central focus, and users can do their work on the device that is most convenient.</span></span> <span data-ttu-id="c98b8-111">たとえば、ユーザーが車に乗りながら電話でラジオを聴きますが、帰宅したらホーム ステレオ システムに搭載した Xbox One に再生を転送することがあります。</span><span class="sxs-lookup"><span data-stu-id="c98b8-111">For example, a user might be listening to the radio on their phone in the car, but when they get home they may want to transfer playback to their Xbox One which is hooked up to the home stereo system.</span></span>

<span data-ttu-id="c98b8-112">コンパニオン デバイスに "Rome" プロジェクトを使う (つまり、リモート制御シナリオ) こともできます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-112">You can also use Project Rome for companion devices or remote control scenarios.</span></span> <span data-ttu-id="c98b8-113">アプリ サービス メッセージング API を使って 2 つのデバイス間にアプリ チャネルを作り、カスタム メッセージを送受信します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-113">Use the app service messaging APIs to create an app channel between two devices to send and receive custom messages.</span></span> <span data-ttu-id="c98b8-114">たとえば、テレビの再生を制御する電話用アプリや、別のアプリで視聴しているテレビ番組のキャラクターに関する情報を表示するコンパニオン アプリを記述することができます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-114">For example, you can write an app for your phone that controls playback on your TV, or a companion app that provides information about the characters on a TV show you are watching through another app.</span></span>  

<span data-ttu-id="c98b8-115">デバイスは、Bluetooth やワイヤレスを経由して近くで接続したり、クラウドを通じてリモートで接続したりすることができます。それらのデバイスは、デバイスを使っているユーザーの Microsoft アカウント (MSA) によってリンクされます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-115">Devices can be connected proximally through Bluetooth and wireless, or remotely through the cloud; they are linked by the Microsoft account (MSA) of the person using them.</span></span>

<span data-ttu-id="c98b8-116">リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法の例については、[リモート システム UWP のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems )を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c98b8-116">See the [Remote Systems UWP sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems ) for examples of how to discover remote system, launch an app on a remote system, and use app services to send messages between apps running on two systems.</span></span>

<span data-ttu-id="c98b8-117">クロス プラットフォーム統合のリソースを含む、Project Rome 全般の詳細については、[aka.ms/project-rome](https://aka.ms/project-rome) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c98b8-117">For more information on Project Rome in general, including resources for cross-platform integration, go to [aka.ms/project-rome](https://aka.ms/project-rome).</span></span>

| <span data-ttu-id="c98b8-118">トピック</span><span class="sxs-lookup"><span data-stu-id="c98b8-118">Topic</span></span> | <span data-ttu-id="c98b8-119">説明</span><span class="sxs-lookup"><span data-stu-id="c98b8-119">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="c98b8-120">リモート デバイスでのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="c98b8-120">Launch an app on a remote device</span></span>](launch-a-remote-app.md) | <span data-ttu-id="c98b8-121">リモート デバイスでアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-121">Learn how to launch an app on a remote device.</span></span> <span data-ttu-id="c98b8-122">このトピックでは、最も単純な使用事例と準備段階のセットアップについて説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-122">This topic covers the simplest use case and preliminary setup.</span></span>  |
| [<span data-ttu-id="c98b8-123">リモート デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="c98b8-123">Discover remote devices</span></span>](discover-remote-devices.md)  | <span data-ttu-id="c98b8-124">接続できるデバイスを検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-124">Learn how to discover devices that you can connect to.</span></span> |
| [<span data-ttu-id="c98b8-125">リモート アプリ サービスとの通信</span><span class="sxs-lookup"><span data-stu-id="c98b8-125">Communicate with a remote app service</span></span>](communicate-with-a-remote-app-service.md) | <span data-ttu-id="c98b8-126">リモート デバイスのアプリを操作する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-126">Learn how to interact with an app on a remote device.</span></span> |
| [<span data-ttu-id="c98b8-127">リモート セッションでデバイスを接続する</span><span class="sxs-lookup"><span data-stu-id="c98b8-127">Connect devices through remote sessions</span></span>](remote-sessions.md) | <span data-ttu-id="c98b8-128">リモート セッションで複数のデバイスを結合することにより、これらのデバイス間で共有エクスペリエンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-128">Create shared experiences across multiple devices by joining them in a remote session.</span></span> |
| [<span data-ttu-id="c98b8-129">デバイス間でもユーザーのアクティビティを継続する</span><span class="sxs-lookup"><span data-stu-id="c98b8-129">Continue user activity, even across devices</span></span>](useractivities.md)| <span data-ttu-id="c98b8-130">ユーザーが何をアプリで複数のデバイス間でもを再開するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c98b8-130">Help users resume what they were doing in your app, even across multiple devices.</span></span>|
| [<span data-ttu-id="c98b8-131">ユーザー アクティビティのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="c98b8-131">User Activities best practices</span></span>](useractivities-best-practices.md)| <span data-ttu-id="c98b8-132">作成して、ユーザー アクティビティを更新するための推奨事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="c98b8-132">Learn the recommended practices for creating and updating User Activities.</span></span>|
