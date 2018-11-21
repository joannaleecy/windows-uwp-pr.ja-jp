---
author: QuinnRadich
title: 画面切り取りの起動
description: このトピックでは、ms screenclip と ms screensketch URI スキームについて説明します。 アプリは、これらの URI スキームを使用して、切り取り領域とスケッチ アプリを起動したり、新しい切り取り領域を開いたりすることができます。
ms.author: quradic
ms.date: 8/1/2017
ms.topic: article
keywords: windows 10、uwp、uri、切り取り、スケッチ
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: ef83c3b5c23b703fcd40f7e4a7570b263cbc8e00
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7556801"
---
# <a name="launch-screen-snipping"></a><span data-ttu-id="f85ac-105">画面切り取りの起動</span><span class="sxs-lookup"><span data-stu-id="f85ac-105">Launch screen snipping</span></span>

<span data-ttu-id="f85ac-106">**Ms screenclip:** と**ms screensketch:** URI スキームでは、開始 snipping やスクリーン ショットを編集することができます。</span><span class="sxs-lookup"><span data-stu-id="f85ac-106">The **ms-screenclip:** and **ms-screensketch:** URI schemes allows you to initiate snipping or editing screenshots.</span></span>

## <a name="open-a-new-snip-from-your-app"></a><span data-ttu-id="f85ac-107">アプリから新しい切り取り領域を開く</span><span class="sxs-lookup"><span data-stu-id="f85ac-107">Open a new snip from your app</span></span>

<span data-ttu-id="f85ac-108">**Ms screenclip:** URI が自動的開き、新しい切り取り領域を開始するアプリを使用します。</span><span class="sxs-lookup"><span data-stu-id="f85ac-108">The **ms-screenclip:** URI allows your app to automatically open up and start a new snip.</span></span> <span data-ttu-id="f85ac-109">結果として得られるの切り取り領域は、ユーザーのクリップボードにコピーされますが、開いたアプリに戻るに自動的に渡されません。</span><span class="sxs-lookup"><span data-stu-id="f85ac-109">The resulting snip is copied to the user's clipboard, but is not automatically passed back to the opening app.</span></span>

<span data-ttu-id="f85ac-110">**ms screenclip:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f85ac-110">**ms-screenclip:** takes the following parameters:</span></span>

| <span data-ttu-id="f85ac-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f85ac-111">Parameter</span></span> | <span data-ttu-id="f85ac-112">型</span><span class="sxs-lookup"><span data-stu-id="f85ac-112">Type</span></span> | <span data-ttu-id="f85ac-113">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="f85ac-113">Required</span></span> | <span data-ttu-id="f85ac-114">説明</span><span class="sxs-lookup"><span data-stu-id="f85ac-114">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="f85ac-115">ソース</span><span class="sxs-lookup"><span data-stu-id="f85ac-115">source</span></span> | <span data-ttu-id="f85ac-116">string</span><span class="sxs-lookup"><span data-stu-id="f85ac-116">string</span></span> | <span data-ttu-id="f85ac-117">いいえ</span><span class="sxs-lookup"><span data-stu-id="f85ac-117">no</span></span> | <span data-ttu-id="f85ac-118">フリー フォーム URI を起動したソースを指定する文字列。</span><span class="sxs-lookup"><span data-stu-id="f85ac-118">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="f85ac-119">delayInSeconds</span><span class="sxs-lookup"><span data-stu-id="f85ac-119">delayInSeconds</span></span> | <span data-ttu-id="f85ac-120">int</span><span class="sxs-lookup"><span data-stu-id="f85ac-120">int</span></span> | <span data-ttu-id="f85ac-121">×</span><span class="sxs-lookup"><span data-stu-id="f85ac-121">no</span></span> | <span data-ttu-id="f85ac-122">1 ~ 30 の整数値。</span><span class="sxs-lookup"><span data-stu-id="f85ac-122">An integer value, from 1 to 30.</span></span> <span data-ttu-id="f85ac-123">URI の呼び出しと snipping の開始時の間の完全な秒単位で、遅延を指定します。</span><span class="sxs-lookup"><span data-stu-id="f85ac-123">Specifies the delay, in full seconds, between the URI call and when snipping begins.</span></span> |

## <a name="launching-the-snip--sketch-app"></a><span data-ttu-id="f85ac-124">切り取り領域 & スケッチ アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="f85ac-124">Launching the Snip & Sketch App</span></span>

<span data-ttu-id="f85ac-125">**Ms screensketch:** URI を使用すると、プログラムで切り取り領域とスケッチのアプリを起動し、注釈をそのアプリで特定のイメージを開きます。</span><span class="sxs-lookup"><span data-stu-id="f85ac-125">The **ms-screensketch:** URI allows you to programatically launch the Snip & Sketch app, and open a specific image in that app for annotation.</span></span>

<span data-ttu-id="f85ac-126">**ms screensketch:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f85ac-126">**ms-screensketch:** takes the following parameters:</span></span>

| <span data-ttu-id="f85ac-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f85ac-127">Parameter</span></span> | <span data-ttu-id="f85ac-128">型</span><span class="sxs-lookup"><span data-stu-id="f85ac-128">Type</span></span> | <span data-ttu-id="f85ac-129">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="f85ac-129">Required</span></span> | <span data-ttu-id="f85ac-130">説明</span><span class="sxs-lookup"><span data-stu-id="f85ac-130">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="f85ac-131">sharedAccessToken</span><span class="sxs-lookup"><span data-stu-id="f85ac-131">sharedAccessToken</span></span> | <span data-ttu-id="f85ac-132">string</span><span class="sxs-lookup"><span data-stu-id="f85ac-132">string</span></span> | <span data-ttu-id="f85ac-133">いいえ</span><span class="sxs-lookup"><span data-stu-id="f85ac-133">no</span></span> | <span data-ttu-id="f85ac-134">切り取り領域とスケッチ アプリで開くには、ファイルを識別するトークンです。</span><span class="sxs-lookup"><span data-stu-id="f85ac-134">A token identifying the file to open in the Snip & Sketch app.</span></span> <span data-ttu-id="f85ac-135">[SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile)から取得されます。</span><span class="sxs-lookup"><span data-stu-id="f85ac-135">Retrieved from [SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile).</span></span> <span data-ttu-id="f85ac-136">このパラメーターを省略すると、開いているファイルを使用せずに、アプリが起動されます。</span><span class="sxs-lookup"><span data-stu-id="f85ac-136">If this parameter is omitted, the app will be launched without a file open.</span></span> |
| <span data-ttu-id="f85ac-137">ソース</span><span class="sxs-lookup"><span data-stu-id="f85ac-137">source</span></span> | <span data-ttu-id="f85ac-138">string</span><span class="sxs-lookup"><span data-stu-id="f85ac-138">string</span></span> | <span data-ttu-id="f85ac-139">いいえ</span><span class="sxs-lookup"><span data-stu-id="f85ac-139">no</span></span> | <span data-ttu-id="f85ac-140">フリー フォーム URI を起動したソースを指定する文字列。</span><span class="sxs-lookup"><span data-stu-id="f85ac-140">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="f85ac-141">isTemporary</span><span class="sxs-lookup"><span data-stu-id="f85ac-141">isTemporary</span></span> | <span data-ttu-id="f85ac-142">bool</span><span class="sxs-lookup"><span data-stu-id="f85ac-142">bool</span></span> | <span data-ttu-id="f85ac-143">×</span><span class="sxs-lookup"><span data-stu-id="f85ac-143">no</span></span> | <span data-ttu-id="f85ac-144">場合は、画面スケッチが True に設定は、開いた後、ファイルを削除しようとしています。</span><span class="sxs-lookup"><span data-stu-id="f85ac-144">If set to True, Screen Sketch will try to delete the file after opening it.</span></span> |

<span data-ttu-id="f85ac-145">次の例では、ユーザーのアプリからの切り取り領域とスケッチに画像を送信する[LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f85ac-145">The following example calls the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) method to send an image to Snip & Sketch from the user's app.</span></span>

```csharp

bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken=2C37ADDA-B054-40B5-8B38-11CED1E1A2D"));

```
