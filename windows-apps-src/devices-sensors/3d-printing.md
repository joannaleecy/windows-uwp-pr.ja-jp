---
author: PatrickFarley
ms.assetid: 551d4e70-312d-4b40-8d3e-336ce934e0ad
title: 3D 印刷
description: このセクションでは、ユニバーサル Windows アプリで 3D 印刷機能を使用する方法について説明します。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: af636e445d2cad70922b8f846140e0886cf7ef28
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243251"
---
# <a name="3d-printing"></a><span data-ttu-id="1f8d8-104">3D 印刷</span><span class="sxs-lookup"><span data-stu-id="1f8d8-104">3D Printing</span></span>

<span data-ttu-id="1f8d8-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="1f8d8-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="1f8d8-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="1f8d8-107">このセクションでは、[3D 印刷 API](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.aspx) を使って、ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-107">This section describes how to utilize the [3D print API](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.aspx) to add 3D printing functionality to your Universal Windows app.</span></span>  

<!-- ![the 3D printing from Unity sample uses Windows 3D print APIs to facilitate the printing of a textured model asset from Unity software](images/unity-app-screenshot-002.png) -->

<span data-ttu-id="1f8d8-108">ハードウェア パートナー向けのリソース、コミュニティのディスカッション フォーラム、および 3D 印刷機能に関する一般的な情報など、Windows 10 による 3D 印刷について詳しくは、ハードウェア デベロッパー センターの「[Windows 10 による 3D 印刷](https://developer.microsoft.com/windows/hardware/3d-print-support-windows-10)」のサイトをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-108">For more information on 3D printing with Windows 10, including resources for hardware partners, community discussion forums, and general info on 3D print capabilities, see the [3D printing with Windows 10](https://developer.microsoft.com/windows/hardware/3d-print-support-windows-10) site on the Hardware Dev Center.</span></span>

| <span data-ttu-id="1f8d8-109">トピック</span><span class="sxs-lookup"><span data-stu-id="1f8d8-109">Topic</span></span> | <span data-ttu-id="1f8d8-110">説明</span><span class="sxs-lookup"><span data-stu-id="1f8d8-110">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="1f8d8-111">アプリからの 3D 印刷</span><span class="sxs-lookup"><span data-stu-id="1f8d8-111">3D print from your app</span></span>](3d-print-from-app.md) | <span data-ttu-id="1f8d8-112">ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-112">Learn how to add 3D printing functionality to your Universal Windows app.</span></span> <span data-ttu-id="1f8d8-113">このトピックでは、3D モデルが印刷可能であり、正しい形式になっていることを確認した後で 3D 印刷ダイアログを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-113">This topic covers how to launch the 3D print dialog after ensuring your 3D model is printable and in the correct format.</span></span> |
| [<span data-ttu-id="1f8d8-114">3MF パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="1f8d8-114">Generate a 3MF package</span></span>](generate-3mf.md) | <span data-ttu-id="1f8d8-115">3D Manufacturing Format (3MF) のファイルの種類の構造について説明し、その作成方法と Windows.Graphics.Printing3D API による操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="1f8d8-115">Describes the structure of the 3D Manufacturing Format file type and how it can be created and manipulated with the Windows.Graphics.Printing3D API.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="1f8d8-116">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1f8d8-116">Related topics</span></span>

* [<span data-ttu-id="1f8d8-117">Windows 10 による 3D 印刷 (ハードウェア デベロッパー センター)</span><span class="sxs-lookup"><span data-stu-id="1f8d8-117">3D printing with Windows 10 (Hardware Dev Center)</span></span>](https://developer.microsoft.com/windows/hardware/3d-print-support-windows-10)
* [<span data-ttu-id="1f8d8-118">UWP 3D 印刷サンプル</span><span class="sxs-lookup"><span data-stu-id="1f8d8-118">UWP 3D print sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)
* [<span data-ttu-id="1f8d8-119">Unity サンプルからの UWP 3D 印刷</span><span class="sxs-lookup"><span data-stu-id="1f8d8-119">UWP 3D printing from Unity sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrintingFromUnity)

 
