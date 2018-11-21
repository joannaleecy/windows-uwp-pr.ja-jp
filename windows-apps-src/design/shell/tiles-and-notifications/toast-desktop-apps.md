---
author: andrewleader
Description: Discover the different options desktop Win32 apps have for sending toast notifications
title: デスクトップ アプリからのトースト通知
label: Toast notifications from desktop apps
template: detail.hbs
ms.author: mijacobs
ms.date: 05/01/2018
ms.topic: article
keywords: windows 10, uwp, win32, デスクトップ, トースト通知, デスクトップ ブリッジ, トーストの送信のオプション, com サーバー, com アクティベーター, com, 偽の com, com なし, com なし, トーストの送信
ms.localizationpriority: medium
ms.openlocfilehash: 2ee44d990ef29fa8281a14c8ad03b6c6ff16a4cf
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7442107"
---
# <a name="toast-notifications-from-desktop-apps"></a><span data-ttu-id="5b3fd-103">デスクトップ アプリからのトースト通知</span><span class="sxs-lookup"><span data-stu-id="5b3fd-103">Toast notifications from desktop apps</span></span>

<span data-ttu-id="5b3fd-104">デスクトップ アプリ (デスクトップ ブリッジと従来の Win32) は、ユニバーサル Windows プラットフォーム (UWP) アプリと同様の対話型トースト通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-104">Desktop apps (both Desktop Bridge and classic Win32) can send interactive toast notifications just like Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="5b3fd-105">ただし、異なるアクティブ化スキームのために、いくつかの異なるデスクトップ アプリのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-105">However, there are a few different options for desktop apps due to the different activation schemes.</span></span>

<span data-ttu-id="5b3fd-106">この記事では、Windows 10 でトースト通知の送信に使用するためのオプションを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-106">In this article, we list out the options you have for sending a toast notification on Windows 10.</span></span> <span data-ttu-id="5b3fd-107">すべてのオプションでは、以下が完全にサポートされています。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-107">Every option fully supports...</span></span>

* <span data-ttu-id="5b3fd-108">アクション センター内での保持</span><span class="sxs-lookup"><span data-stu-id="5b3fd-108">Persisting in Action Center</span></span>
* <span data-ttu-id="5b3fd-109">ポップアップとアクション センター内の両方からアクティブ化可能</span><span class="sxs-lookup"><span data-stu-id="5b3fd-109">Being activatable from both the popup and inside Action Center</span></span>
* <span data-ttu-id="5b3fd-110">EXE が実行されていないときにアクティブ化可能</span><span class="sxs-lookup"><span data-stu-id="5b3fd-110">Being activatable while your EXE isn't running</span></span>

## <a name="all-options"></a><span data-ttu-id="5b3fd-111">すべてのオプション</span><span class="sxs-lookup"><span data-stu-id="5b3fd-111">All options</span></span>

<span data-ttu-id="5b3fd-112">次の表は、デスクトップ アプリ内のトーストをサポートするためのオプション、および対応するサポートされる機能を示しています。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-112">The table below illustrates your options for supporting toasts within your desktop app, and the corresponding supported features.</span></span> <span data-ttu-id="5b3fd-113">この表を使用してシナリオに最適なオプションを選択します。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-113">You can use the table to select the best option for your scenario.</span></span><br/><br/>

| <span data-ttu-id="5b3fd-114">オプション</span><span class="sxs-lookup"><span data-stu-id="5b3fd-114">Option</span></span> | <span data-ttu-id="5b3fd-115">視覚効果</span><span class="sxs-lookup"><span data-stu-id="5b3fd-115">Visuals</span></span> | <span data-ttu-id="5b3fd-116">アクション</span><span class="sxs-lookup"><span data-stu-id="5b3fd-116">Actions</span></span> | <span data-ttu-id="5b3fd-117">入力</span><span class="sxs-lookup"><span data-stu-id="5b3fd-117">Inputs</span></span> | <span data-ttu-id="5b3fd-118">プロセス内でのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="5b3fd-118">Activates in-process</span></span> |
| -- | -- | -- | -- | -- |
| [<span data-ttu-id="5b3fd-119">COM アクティベーター</span><span class="sxs-lookup"><span data-stu-id="5b3fd-119">COM activator</span></span>](#preferred-option---com-activator) | <span data-ttu-id="5b3fd-120">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-120">✔️</span></span> | <span data-ttu-id="5b3fd-121">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-121">✔️</span></span> | <span data-ttu-id="5b3fd-122">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-122">✔️</span></span> | <span data-ttu-id="5b3fd-123">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-123">✔️</span></span> |
| [<span data-ttu-id="5b3fd-124">COM なし / Stub CLSID</span><span class="sxs-lookup"><span data-stu-id="5b3fd-124">No COM / Stub CLSID</span></span>](#alternative-option---no-com--stub-clsid) | <span data-ttu-id="5b3fd-125">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-125">✔️</span></span> | <span data-ttu-id="5b3fd-126">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-126">✔️</span></span> | <span data-ttu-id="5b3fd-127">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-127">❌</span></span> | <span data-ttu-id="5b3fd-128">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-128">❌</span></span> |


## <a name="preferred-option---com-activator"></a><span data-ttu-id="5b3fd-129">推奨されるオプション - COM アクティベーター</span><span class="sxs-lookup"><span data-stu-id="5b3fd-129">Preferred option - COM activator</span></span>

<span data-ttu-id="5b3fd-130">これは、デスクトップ ブリッジと従来の Win32 の両方に対して機能し、すべての通知機能をサポートする推奨されるオプションです。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-130">This is the preferred option that works for both Desktop Bridge and classic Win32, and supports all notification features.</span></span> <span data-ttu-id="5b3fd-131">"COM アクティベーター" について心配することはありません。以前に COM サーバーを記述したことがない場合でも、これを非常に簡単にするライブラリ [C#](send-local-toast-desktop.md) および [C++ アプリ](send-local-toast-desktop-cpp-wrl.md)があります。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-131">Don't be afraid of the "COM activator"; we have a library [for C#](send-local-toast-desktop.md) and [C++ apps](send-local-toast-desktop-cpp-wrl.md) that makes this very straightforward, even if you've never written a COM server before.</span></span><br/><br/>

| <span data-ttu-id="5b3fd-132">視覚効果</span><span class="sxs-lookup"><span data-stu-id="5b3fd-132">Visuals</span></span> | <span data-ttu-id="5b3fd-133">アクション</span><span class="sxs-lookup"><span data-stu-id="5b3fd-133">Actions</span></span> | <span data-ttu-id="5b3fd-134">入力</span><span class="sxs-lookup"><span data-stu-id="5b3fd-134">Inputs</span></span> | <span data-ttu-id="5b3fd-135">プロセス内でのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="5b3fd-135">Activates in-process</span></span> |
| -- | -- | -- | -- |
| <span data-ttu-id="5b3fd-136">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-136">✔️</span></span> | <span data-ttu-id="5b3fd-137">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-137">✔️</span></span> | <span data-ttu-id="5b3fd-138">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-138">✔️</span></span> | <span data-ttu-id="5b3fd-139">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-139">✔️</span></span> |

<span data-ttu-id="5b3fd-140">COM アクティベーター オプションでは、アプリで次の通知テンプレートとライセンス認証の種類を使用できます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-140">With the COM activator option, you can use the following notification templates and activation types in your app.</span></span><br/><br/>

| <span data-ttu-id="5b3fd-141">テンプレートとライセンス認証の種類</span><span class="sxs-lookup"><span data-stu-id="5b3fd-141">Template and activation type</span></span> | <span data-ttu-id="5b3fd-142">デスクトップ ブリッジ</span><span class="sxs-lookup"><span data-stu-id="5b3fd-142">Desktop Bridge</span></span> | <span data-ttu-id="5b3fd-143">従来の Win32</span><span class="sxs-lookup"><span data-stu-id="5b3fd-143">Classic Win32</span></span> |
| -- | -- | -- |
| <span data-ttu-id="5b3fd-144">ToastGeneric フォアグラウンド</span><span class="sxs-lookup"><span data-stu-id="5b3fd-144">ToastGeneric Foreground</span></span> | <span data-ttu-id="5b3fd-145">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-145">✔️</span></span> | <span data-ttu-id="5b3fd-146">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-146">✔️</span></span> |
| <span data-ttu-id="5b3fd-147">ToastGeneric バックグラウンド</span><span class="sxs-lookup"><span data-stu-id="5b3fd-147">ToastGeneric Background</span></span> | <span data-ttu-id="5b3fd-148">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-148">✔️</span></span> | <span data-ttu-id="5b3fd-149">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-149">✔️</span></span> |
| <span data-ttu-id="5b3fd-150">ToastGeneric プロトコル</span><span class="sxs-lookup"><span data-stu-id="5b3fd-150">ToastGeneric Protocol</span></span> | <span data-ttu-id="5b3fd-151">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-151">✔️</span></span> | <span data-ttu-id="5b3fd-152">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-152">✔️</span></span> |
| <span data-ttu-id="5b3fd-153">レガシ テンプレート</span><span class="sxs-lookup"><span data-stu-id="5b3fd-153">Legacy templates</span></span> | <span data-ttu-id="5b3fd-154">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-154">✔️</span></span> | <span data-ttu-id="5b3fd-155">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-155">❌</span></span> |

> [!NOTE]
> <span data-ttu-id="5b3fd-156">COM アクティベーターを既存のデスクトップ ブリッジ アプリに追加すると、フォアグラウンド/バックグラウンドおよび従来の通知のアクティブ化により、コマンド ラインではなく COM アクティベーターがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-156">If you add the COM activator to your existing Desktop Bridge app, Foreground/Background and Legacy notification activations will now activate your COM activator instead of your command line.</span></span>

<span data-ttu-id="5b3fd-157">このオプションを使用する方法については、「[デスクトップ C# アプリからのローカル トースト通知の送信](send-local-toast-desktop.md)」または「[デスクトップ C++ WRL アプリからのローカル トースト通知の送信](send-local-toast-desktop-cpp-wrl.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-157">To learn how to use this option, see [Send a local toast notification from destkop C# apps](send-local-toast-desktop.md) or [Send a local toast notification from destkop C++ WRL apps](send-local-toast-desktop-cpp-wrl.md).</span></span>


## <a name="alternative-option---no-com--stub-clsid"></a><span data-ttu-id="5b3fd-158">代替オプション - COM なし / Stub CLSID</span><span class="sxs-lookup"><span data-stu-id="5b3fd-158">Alternative option - No COM / Stub CLSID</span></span>

<span data-ttu-id="5b3fd-159">これは、COM アクティベーターを実装できない場合の代替オプションです。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-159">This is an alternative option if you cannot implement a COM activator.</span></span> <span data-ttu-id="5b3fd-160">ただし、入力サポート (トーストでのテキスト ボックス) やプロセス内でのアクティブ化など、いくつかの機能が犠牲になります。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-160">However, you will sacrifice a few features, such as input support (text boxes on toasts) and activating in-process.</span></span><br/><br/>

| <span data-ttu-id="5b3fd-161">視覚効果</span><span class="sxs-lookup"><span data-stu-id="5b3fd-161">Visuals</span></span> | <span data-ttu-id="5b3fd-162">アクション</span><span class="sxs-lookup"><span data-stu-id="5b3fd-162">Actions</span></span> | <span data-ttu-id="5b3fd-163">入力</span><span class="sxs-lookup"><span data-stu-id="5b3fd-163">Inputs</span></span> | <span data-ttu-id="5b3fd-164">プロセス内でのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="5b3fd-164">Activates in-process</span></span> |
| -- | -- | -- | -- |
| <span data-ttu-id="5b3fd-165">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-165">✔️</span></span> | <span data-ttu-id="5b3fd-166">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-166">✔️</span></span> | <span data-ttu-id="5b3fd-167">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-167">❌</span></span> | <span data-ttu-id="5b3fd-168">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-168">❌</span></span> |

<span data-ttu-id="5b3fd-169">このオプションでは、従来の Win32 をサポートする場合、次に示すように、使用できる通知テンプレートとライセンス認証の種類がはるかに制限されます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-169">With this option, if you support classic Win32, you are much more limited in the notification templates and activation types that you can use, as seen below.</span></span><br/><br/>

| <span data-ttu-id="5b3fd-170">テンプレートとライセンス認証の種類</span><span class="sxs-lookup"><span data-stu-id="5b3fd-170">Template and activation type</span></span> | <span data-ttu-id="5b3fd-171">デスクトップ ブリッジ</span><span class="sxs-lookup"><span data-stu-id="5b3fd-171">Desktop Bridge</span></span> | <span data-ttu-id="5b3fd-172">従来の Win32</span><span class="sxs-lookup"><span data-stu-id="5b3fd-172">Classic Win32</span></span> |
| -- | -- | -- |
| <span data-ttu-id="5b3fd-173">ToastGeneric フォアグラウンド</span><span class="sxs-lookup"><span data-stu-id="5b3fd-173">ToastGeneric Foreground</span></span> | <span data-ttu-id="5b3fd-174">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-174">✔️</span></span> | <span data-ttu-id="5b3fd-175">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-175">❌</span></span> |
| <span data-ttu-id="5b3fd-176">ToastGeneric バックグラウンド</span><span class="sxs-lookup"><span data-stu-id="5b3fd-176">ToastGeneric Background</span></span> | <span data-ttu-id="5b3fd-177">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-177">✔️</span></span> | <span data-ttu-id="5b3fd-178">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-178">❌</span></span> |
| <span data-ttu-id="5b3fd-179">ToastGeneric プロトコル</span><span class="sxs-lookup"><span data-stu-id="5b3fd-179">ToastGeneric Protocol</span></span> | <span data-ttu-id="5b3fd-180">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-180">✔️</span></span> | <span data-ttu-id="5b3fd-181">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-181">✔️</span></span> |
| <span data-ttu-id="5b3fd-182">レガシ テンプレート</span><span class="sxs-lookup"><span data-stu-id="5b3fd-182">Legacy templates</span></span> | <span data-ttu-id="5b3fd-183">✔️</span><span class="sxs-lookup"><span data-stu-id="5b3fd-183">✔️</span></span> | <span data-ttu-id="5b3fd-184">❌</span><span class="sxs-lookup"><span data-stu-id="5b3fd-184">❌</span></span> |

<span data-ttu-id="5b3fd-185">今後、このオプションを使用する方法を示すドキュメントを公開する予定です。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-185">We'll be publishing docs in the future showing how to use this option.</span></span> <span data-ttu-id="5b3fd-186">基本的には、デスクトップ ブリッジ アプリでは、UWP アプリで行うのと同様にトースト通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-186">Essentially, for Desktop Bridge apps, just send toast notifications like a UWP app would.</span></span> <span data-ttu-id="5b3fd-187">ユーザーがトーストをクリックすると、アプリは、トーストで指定した起動引数でコマンド ラインから起動されます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-187">When the user clicks on your toast, your app will be command line launched with the launch args that you specified in the toast.</span></span>

<span data-ttu-id="5b3fd-188">従来の Win32 アプリでは、トースト通知を送信し、ショートカットで CLSID を指定できるように AUMID を設定します。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-188">For classic Win32 apps, set up the AUMID so that you can send toasts, and then also specify a CLSID on your shortcut.</span></span> <span data-ttu-id="5b3fd-189">ランダムな GUID を指定できます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-189">This can be any random GUID.</span></span> <span data-ttu-id="5b3fd-190">COM サーバー/アクティベーターを追加しないでください。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-190">Don't add the COM server/activator.</span></span> <span data-ttu-id="5b3fd-191">"stub" COM CLSID を追加することで、アクション センターで通知が保持されます。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-191">You're adding a "stub" COM CLSID, which will cause Action Center to persist the notification.</span></span> <span data-ttu-id="5b3fd-192">スタブ CLSID は他のトーストのアクティブ化を中断するため、プロトコルのアクティブ化のトーストのみを使用できる点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-192">Note that you can only use protocol activation toasts, as the stub CLSID will break activation of any other toast activations.</span></span> <span data-ttu-id="5b3fd-193">そのため、プロトコルのアクティブ化をサポートするようにアプリを更新し、トースト プロトコルで各自のアプリをアクティブ化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5b3fd-193">Therefore, you have to update your app to support protocol activation, and have the toasts protocol activate your own app.</span></span>


## <a name="resources"></a><span data-ttu-id="5b3fd-194">リソース</span><span class="sxs-lookup"><span data-stu-id="5b3fd-194">Resources</span></span>

* [<span data-ttu-id="5b3fd-195">デスクトップ C# アプリからのローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="5b3fd-195">Send a local toast notification from destkop C# apps</span></span>](send-local-toast-desktop.md)
* [<span data-ttu-id="5b3fd-196">デスクトップ C++ WRL アプリからのローカル トースト通知の送信</span><span class="sxs-lookup"><span data-stu-id="5b3fd-196">Send a local toast notification from destkop C++ WRL apps</span></span>](send-local-toast-desktop-cpp-wrl.md)
* [<span data-ttu-id="5b3fd-197">トースト コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="5b3fd-197">Toast content documentation</span></span>](adaptive-interactive-toasts.md)