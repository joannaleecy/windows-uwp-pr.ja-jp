---
title: ARM での x86 および ARM32 エミュレーションのしくみ
author: msatranjr
description: ARM での x86 アプリのエミュレーションの概要。
ms.author: misatran
ms.date: 02/15/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での x86 エミュレーション
ms.localizationpriority: medium
ms.openlocfilehash: 6b596ab9abd31fa10d0ca07dec973082b495262e
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6043345"
---
# <a name="how-x86-emulation-works-on-arm"></a><span data-ttu-id="66d5e-104">ARM での x86 エミュレーション</span><span class="sxs-lookup"><span data-stu-id="66d5e-104">How x86 emulation works on ARM</span></span>
<span data-ttu-id="66d5e-105">x86 アプリのエミュレーションにより、Win32 アプリのリッチなエコシステムが ARM で利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="66d5e-105">Emulation for x86 apps makes the rich ecosystem of Win32 apps available on ARM.</span></span> <span data-ttu-id="66d5e-106">これにより、アプリに変更を加えなくても、ユーザーが既存の x86 win32 アプリを問題なく実行できるようになります。</span><span class="sxs-lookup"><span data-stu-id="66d5e-106">This provides the user the magical experience of running an existing x86 win32 app without any modifications to the app.</span></span> <span data-ttu-id="66d5e-107">アプリは、固有の API ([IsWoW64Process2](https://msdn.microsoft.com/en-us/library/windows/desktop/mt804318.aspx)) を呼び出すことを除いて、ARM PC の Windows で実行されていることを認識することもありません。</span><span class="sxs-lookup"><span data-stu-id="66d5e-107">The app doesn’t even know that it is running on a Windows on ARM PC, unless it calls specific APIs ([IsWoW64Process2](https://msdn.microsoft.com/en-us/library/windows/desktop/mt804318.aspx)).</span></span>

<span data-ttu-id="66d5e-108">Windows 10 の [WOW64](https://msdn.microsoft.com/en-us/library/windows/desktop/aa384249(v=vs.85).aspx) レイヤーを使うと、ARM64 バージョンの Windows 10 で x86 コードを実行できます。</span><span class="sxs-lookup"><span data-stu-id="66d5e-108">The [WOW64](https://msdn.microsoft.com/en-us/library/windows/desktop/aa384249(v=vs.85).aspx) layer of Windows 10 allows x86 code to run on the ARM64 version of Windows 10.</span></span> <span data-ttu-id="66d5e-109">x86 エミュレーションは、パフォーマンスを高める最適化によって x86 命令のブロックを ARM64 命令にコンパイルすることで機能します。</span><span class="sxs-lookup"><span data-stu-id="66d5e-109">x86 emulation works by compiling blocks of x86 instructions into ARM64 instructions with optimizations to improve performance.</span></span> <span data-ttu-id="66d5e-110">サービスは、変換されたこれらのコード ブロックをキャッシュして命令変換のオーバーヘッドを減らし、コードをもう一度実行するときの最適化を実現します。</span><span class="sxs-lookup"><span data-stu-id="66d5e-110">A service caches these translated blocks of code to reduce the overhead of instruction translation and allow for optimization when the code runs again.</span></span> <span data-ttu-id="66d5e-111">キャッシュはモジュールごとに生成されるため、他のアプリが初回起動時にそれらを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="66d5e-111">The caches are produced for each module so that other apps can make use of them on first launch.</span></span> 

<span data-ttu-id="66d5e-112">これらのテクノロジについて詳しくは、[ARM 版 Windows 10](https://channel9.msdn.com/Events/Build/2017/P4171) Channel9 ビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="66d5e-112">For more details about these technologies, see the [Windows 10 on ARM](https://channel9.msdn.com/Events/Build/2017/P4171) Channel9 video.</span></span> 