---
title: ウィンドウ モードと全画面表示モード
description: Direct3D アプリケーションは、ウィンドウ モードと全画面表示モードのどちらでも実行できます。
ms.assetid: EE8B9F87-822B-4576-A446-CA603E786862
keywords:
- ウィンドウ モードと全画面表示モード
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d84bbebfaf19b756e6abc6c592187b6b0ee92200
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7841115"
---
# <a name="span-iddirect3dconceptswindowedvsfull-screenmodespanwindowed-vs-full-screen-mode"></a><span data-ttu-id="e64af-104"><span id="direct3dconcepts.windowed_vs__full-screen_mode"></span>ウィンドウ モードと全画面表示モード</span><span class="sxs-lookup"><span data-stu-id="e64af-104"><span id="direct3dconcepts.windowed_vs__full-screen_mode"></span>Windowed vs. full-screen mode</span></span>


<span data-ttu-id="e64af-105">Direct3D アプリケーションは、ウィンドウ モードと全画面表示モードのどちらでも実行できます。</span><span class="sxs-lookup"><span data-stu-id="e64af-105">Direct3D applications can run in either of two modes: windowed or full-screen.</span></span> <span data-ttu-id="e64af-106">*ウィンドウ モード*では、アプリケーションは実行中のすべてのアプリケーションとデスクトップの利用可能な画面領域を共有します。</span><span class="sxs-lookup"><span data-stu-id="e64af-106">In *windowed mode*, the application shares the available desktop screen space with all running applications.</span></span> <span data-ttu-id="e64af-107">"全画面表示モード"\*\* では、アプリケーションを実行するウィンドウがデスクトップ全体に表示され、実行中の他のアプリケーションはすべて (開発環境も含めて) 見えなくなります。</span><span class="sxs-lookup"><span data-stu-id="e64af-107">In *full-screen mode*, the window that the application runs in covers the entire desktop, hiding all running applications (including your development environment).</span></span> <span data-ttu-id="e64af-108">通常、ゲームは既定で全画面表示モードになり、実行中のアプリケーションをすべて隠してユーザーがゲームに完全に没頭できるようにするのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="e64af-108">Games typically default to full-screen mode to fully immerse the user in the game by hiding all running applications.</span></span>

<span data-ttu-id="e64af-109">全画面表示モードとウィンドウ モードのコードの違いはごくわずかです。</span><span class="sxs-lookup"><span data-stu-id="e64af-109">Code differences between full-screen mode and windowed mode are very small.</span></span>

<span data-ttu-id="e64af-110">全画面表示モードで動作するアプリケーションは画面を占有するため、アプリケーションのデバッグには、別のモニターかリモート デバッガーを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="e64af-110">Because an application running in full-screen mode takes over the screen, debugging the application requires either a separate monitor or the use of a remote debugger.</span></span> <span data-ttu-id="e64af-111">ウィンドウ モード アプリケーションの利点の 1 つは、複数のモニターやリモート デバッガーを使わなくても、コードをステップ実行できることにあります。</span><span class="sxs-lookup"><span data-stu-id="e64af-111">One advantage of a windowed-mode application is that you can step through the code in a debugger without multiple monitors or a remote debugger.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e64af-112"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e64af-112"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e64af-113">デバイス</span><span class="sxs-lookup"><span data-stu-id="e64af-113">Devices</span></span>](devices.md)

 

 




