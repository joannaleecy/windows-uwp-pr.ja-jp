---
author: TylerMSFT
title: "接続されるアプリやデバイス (\"Rome\" プロジェクト)"
description: "このセクションでは、Remote Systems プラットフォームを使って、リモート デバイスの検出、リモート デバイスでのアプリの起動、リモート デバイス上のアプリ サービスとの通信を行う方法について説明します。"
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 7f39d080-1fff-478c-8c51-526472c1326a
ms.openlocfilehash: 29b7db48f2dbd699f9c4f674a8870fe8f8ca446d
ms.sourcegitcommit: 73c61e8e409b071365a2f6ebd89bd8a769b2a7c1
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/25/2017
---
# <a name="connected-apps-and-devices-project-rome"></a><span data-ttu-id="cf4c7-104">接続されるアプリやデバイス ("Rome" プロジェクト)</span><span class="sxs-lookup"><span data-stu-id="cf4c7-104">Connected apps and devices (Project Rome)</span></span>

<span data-ttu-id="cf4c7-105">このセクションでは、"Rome" プロジェクトを使ってデバイスとプラットフォーム間でアプリを接続する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-105">This section explains how to connect apps across devices and platforms using Project "Rome."</span></span> <span data-ttu-id="cf4c7-106">リモート デバイスの検出、リモート デバイス上でのアプリの起動、リモート デバイス上のアプリ サービスとの通信を行う方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-106">Learn how to discover remote devices, launch an app on a remote device, and communicate with an app service on a remote device.</span></span>

<span data-ttu-id="cf4c7-107">ほとんどのユーザーは複数のデバイスを持っており、あるデバイスでアクティビティを始めてデバイスで終えることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-107">Most people have multiple devices and often begin an activity on one device and finish it on another.</span></span> <span data-ttu-id="cf4c7-108">これに対応するため、アプリはデバイスとプラットフォームにまたがる必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-108">To accommodate this, apps need to span devices and platforms.</span></span>

<span data-ttu-id="cf4c7-109">Windows 10 バージョン 1607 に導入された[リモート システム API](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems) を使うと、ユーザーがあるデバイスでタスクを開始して別のデバイスで終えることができるアプリを記述できます。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-109">The [Remote Systems APIs](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems) introduced in Windows 10, version 1607, enable you to write apps that allow users to start a task on one device and finish it on another.</span></span> <span data-ttu-id="cf4c7-110">タスクは中央のフォーカスに残り、ユーザーは最も便利なデバイスで作業を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-110">The task remains the central focus, and users can do their work on the device that is most convenient.</span></span> <span data-ttu-id="cf4c7-111">たとえば、車に乗りながら電話でラジオを聴きますが、帰宅したらホーム ステレオ システムに搭載した Xbox One に再生を転送することがあります。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-111">For example, you might be listening to the radio on your phone in the car, but when you get home you may want to transfer playback to your Xbox One which is hooked up to your home stereo system.</span></span>

<span data-ttu-id="cf4c7-112">コンパニオン デバイスに "Rome" プロジェクトを使う (つまり、リモート制御シナリオ) こともできます。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-112">You can also use Project Rome for companion devices, or remote control scenarios.</span></span> <span data-ttu-id="cf4c7-113">アプリ メッセージング API を使って 2 つのデバイス間にアプリ チャネルを作り、カスタム メッセージを送受信します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-113">Use the app messaging APIs to create an app channel between two devices to send and receive custom messages.</span></span> <span data-ttu-id="cf4c7-114">たとえば、テレビの再生を制御する電話用アプリや、別のアプリで視聴しているテレビ番組のキャラクターに関する情報を表示するコンパニオン アプリを記述することができます。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-114">For example, you can write an app for your phone that controls playback on your TV, or a companion app that provides information about the characters on a TV show you are watching on another app.</span></span>  

<span data-ttu-id="cf4c7-115">デバイスは、Bluetooth やワイヤレスを経由して近くで接続したり、クラウドを通じてリモートで接続したりすることができます。それらのデバイスは、デバイスを使っているユーザーの Microsoft アカウントによって接続されます。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-115">Devices can be connected proximally through Bluetooth and wireless, or remotely through the cloud, and are connected by the Microsoft account of the person using them.</span></span>

<span data-ttu-id="cf4c7-116">リモート システムを検出する方法、リモート システムでアプリを起動する方法、アプリ サービスを使って 2 つのシステム上で実行しているアプリ間でメッセージを送信する方法の例については、[リモート システムのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems )をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-116">See the [Remote Systems sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems ) for examples of how to discover remote system, launch an app on a remote system, and use app services to send messages between apps running on two systems.</span></span>

| <span data-ttu-id="cf4c7-117">トピック</span><span class="sxs-lookup"><span data-stu-id="cf4c7-117">Topic</span></span> | <span data-ttu-id="cf4c7-118">説明</span><span class="sxs-lookup"><span data-stu-id="cf4c7-118">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="cf4c7-119">リモート デバイスの検出</span><span class="sxs-lookup"><span data-stu-id="cf4c7-119">Discover remote devices</span></span>](discover-remote-devices.md)  | <span data-ttu-id="cf4c7-120">接続できるデバイスを検出する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-120">Learn how to discover devices that you can connect to.</span></span> |
| [<span data-ttu-id="cf4c7-121">リモート デバイスでのアプリの起動</span><span class="sxs-lookup"><span data-stu-id="cf4c7-121">Launch an app on a remote device</span></span>](launch-a-remote-app.md) | <span data-ttu-id="cf4c7-122">リモート デバイスでアプリを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-122">Learn how to launch an app on a remote device.</span></span>  |
| [<span data-ttu-id="cf4c7-123">リモート アプリ サービスとの通信</span><span class="sxs-lookup"><span data-stu-id="cf4c7-123">Communicate with a remote app service</span></span>](communicate-with-a-remote-app-service.md) | <span data-ttu-id="cf4c7-124">リモート デバイスのアプリを操作する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cf4c7-124">Learn how to interact with an app on a remote device.</span></span> |
