---
author: mtoepke
title: アプリの起動と再開 (DirectX と C++)
description: ユニバーサル Windows プラットフォーム (UWP) DirectX アプリを起動、一時停止、再開する方法について説明します。
ms.assetid: c35025f8-0450-2f61-fe84-070fd7379622
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, DirectX, 起動, 再開
ms.openlocfilehash: c3557a11f8f18262f0b5e0c6ad6cac88d5274f73
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243059"
---
# <a name="launching-and-resuming-apps-directx-and-c"></a><span data-ttu-id="2349f-104">アプリの起動と再開 (DirectX と C++)</span><span class="sxs-lookup"><span data-stu-id="2349f-104">Launching and resuming apps (DirectX and C++)</span></span>


<span data-ttu-id="2349f-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="2349f-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="2349f-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]</span><span class="sxs-lookup"><span data-stu-id="2349f-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="2349f-107">ユニバーサル Windows プラットフォーム (UWP) DirectX アプリを起動、一時停止、再開する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2349f-107">Learn how to launch, suspend, and resume your Universal Windows Platform (UWP) DirectX app.</span></span>

| <span data-ttu-id="2349f-108">トピック</span><span class="sxs-lookup"><span data-stu-id="2349f-108">Topic</span></span> | <span data-ttu-id="2349f-109">説明</span><span class="sxs-lookup"><span data-stu-id="2349f-109">Description</span></span> |
|---------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| [<span data-ttu-id="2349f-110">アプリをアクティブ化する方法</span><span class="sxs-lookup"><span data-stu-id="2349f-110">How to activate an app</span></span>](how-to-activate-an-app-directx-and-cpp.md) | <span data-ttu-id="2349f-111">ここでは、UWP DirectX アプリのアクティブ化エクスペリエンスを定義する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2349f-111">This topic shows how to define the activation experience for a UWP DirectX app.</span></span> |
| [<span data-ttu-id="2349f-112">アプリを一時停止する方法</span><span class="sxs-lookup"><span data-stu-id="2349f-112">How to suspend an app</span></span>](how-to-suspend-an-app-directx-and-cpp.md) | <span data-ttu-id="2349f-113">ここでは、UWP DirectX アプリをシステムが一時停止するときに重要なシステム状態とアプリ データを保存する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2349f-113">This topic shows how to save important system state and app data when the system suspends your UWP DirectX app.</span></span> |
| [<span data-ttu-id="2349f-114">アプリを再開する方法</span><span class="sxs-lookup"><span data-stu-id="2349f-114">How to resume an app</span></span>](how-to-resume-an-app-directx-and-cpp.md) | <span data-ttu-id="2349f-115">ここでは、UWP DirectX アプリをシステムが再開するときに重要なアプリケーション データを復元する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="2349f-115">This topic shows how to restore important application data when the system resumes your UWP DirectX app.</span></span> |
 

 

 




