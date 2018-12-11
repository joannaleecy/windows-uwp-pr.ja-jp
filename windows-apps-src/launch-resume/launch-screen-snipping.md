---
title: 画面切り取りの起動
description: このトピックでは、ms screenclip と ms screensketch の URI スキームについて説明します。 アプリは、これらの URI スキームを使用して、切り取り領域とスケッチ アプリを起動したり、新しい切り取り領域を開いたりすることができます。
ms.date: 8/1/2017
ms.topic: article
keywords: windows 10、uwp、uri、切り取り、スケッチ
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0a90772e01885a7361cd51b54fc6e5ea9930bfbd
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8920561"
---
# <a name="launch-screen-snipping"></a><span data-ttu-id="e3b12-105">画面切り取りの起動</span><span class="sxs-lookup"><span data-stu-id="e3b12-105">Launch screen snipping</span></span>

<span data-ttu-id="e3b12-106">**Ms screenclip:** と**ms screensketch:** URI スキームでは、開始 snipping やスクリーン ショットを編集することができます。</span><span class="sxs-lookup"><span data-stu-id="e3b12-106">The **ms-screenclip:** and **ms-screensketch:** URI schemes allows you to initiate snipping or editing screenshots.</span></span>

## <a name="open-a-new-snip-from-your-app"></a><span data-ttu-id="e3b12-107">アプリから新しい切り取り領域を開く</span><span class="sxs-lookup"><span data-stu-id="e3b12-107">Open a new snip from your app</span></span>

<span data-ttu-id="e3b12-108">**Ms screenclip:** URI が自動的開き、新しい切り取り領域を開始するアプリを使用します。</span><span class="sxs-lookup"><span data-stu-id="e3b12-108">The **ms-screenclip:** URI allows your app to automatically open up and start a new snip.</span></span> <span data-ttu-id="e3b12-109">結果として得られるの切り取り領域は、ユーザーのクリップボードにコピーされますが、開いたアプリに戻るに自動的に渡されません。</span><span class="sxs-lookup"><span data-stu-id="e3b12-109">The resulting snip is copied to the user's clipboard, but is not automatically passed back to the opening app.</span></span>

<span data-ttu-id="e3b12-110">**ms screenclip:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e3b12-110">**ms-screenclip:** takes the following parameters:</span></span>

| <span data-ttu-id="e3b12-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3b12-111">Parameter</span></span> | <span data-ttu-id="e3b12-112">型</span><span class="sxs-lookup"><span data-stu-id="e3b12-112">Type</span></span> | <span data-ttu-id="e3b12-113">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="e3b12-113">Required</span></span> | <span data-ttu-id="e3b12-114">説明</span><span class="sxs-lookup"><span data-stu-id="e3b12-114">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="e3b12-115">ソース</span><span class="sxs-lookup"><span data-stu-id="e3b12-115">source</span></span> | <span data-ttu-id="e3b12-116">string</span><span class="sxs-lookup"><span data-stu-id="e3b12-116">string</span></span> | <span data-ttu-id="e3b12-117">いいえ</span><span class="sxs-lookup"><span data-stu-id="e3b12-117">no</span></span> | <span data-ttu-id="e3b12-118">URI を起動したソースを示す自由形式の文字列です。</span><span class="sxs-lookup"><span data-stu-id="e3b12-118">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="e3b12-119">delayInSeconds</span><span class="sxs-lookup"><span data-stu-id="e3b12-119">delayInSeconds</span></span> | <span data-ttu-id="e3b12-120">int</span><span class="sxs-lookup"><span data-stu-id="e3b12-120">int</span></span> | <span data-ttu-id="e3b12-121">×</span><span class="sxs-lookup"><span data-stu-id="e3b12-121">no</span></span> | <span data-ttu-id="e3b12-122">1 ~ 30 の整数値。</span><span class="sxs-lookup"><span data-stu-id="e3b12-122">An integer value, from 1 to 30.</span></span> <span data-ttu-id="e3b12-123">URI の呼び出しと snipping の開始時の間の完全な秒単位で、遅延を指定します。</span><span class="sxs-lookup"><span data-stu-id="e3b12-123">Specifies the delay, in full seconds, between the URI call and when snipping begins.</span></span> |

## <a name="launching-the-snip--sketch-app"></a><span data-ttu-id="e3b12-124">切り取り領域 & スケッチ アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="e3b12-124">Launching the Snip & Sketch App</span></span>

<span data-ttu-id="e3b12-125">**Ms screensketch:** URI では、プログラムで切り取り領域とスケッチ アプリを起動し、注釈をそのアプリで特定のイメージを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="e3b12-125">The **ms-screensketch:** URI allows you to programatically launch the Snip & Sketch app, and open a specific image in that app for annotation.</span></span>

<span data-ttu-id="e3b12-126">**ms screensketch:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="e3b12-126">**ms-screensketch:** takes the following parameters:</span></span>

| <span data-ttu-id="e3b12-127">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3b12-127">Parameter</span></span> | <span data-ttu-id="e3b12-128">型</span><span class="sxs-lookup"><span data-stu-id="e3b12-128">Type</span></span> | <span data-ttu-id="e3b12-129">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="e3b12-129">Required</span></span> | <span data-ttu-id="e3b12-130">説明</span><span class="sxs-lookup"><span data-stu-id="e3b12-130">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="e3b12-131">sharedAccessToken</span><span class="sxs-lookup"><span data-stu-id="e3b12-131">sharedAccessToken</span></span> | <span data-ttu-id="e3b12-132">string</span><span class="sxs-lookup"><span data-stu-id="e3b12-132">string</span></span> | <span data-ttu-id="e3b12-133">いいえ</span><span class="sxs-lookup"><span data-stu-id="e3b12-133">no</span></span> | <span data-ttu-id="e3b12-134">切り取り領域とスケッチ アプリで開くには、ファイルを識別するトークンです。</span><span class="sxs-lookup"><span data-stu-id="e3b12-134">A token identifying the file to open in the Snip & Sketch app.</span></span> <span data-ttu-id="e3b12-135">[SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile)から取得されます。</span><span class="sxs-lookup"><span data-stu-id="e3b12-135">Retrieved from [SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile).</span></span> <span data-ttu-id="e3b12-136">このパラメーターを省略すると、開いているファイルを使用せず、アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="e3b12-136">If this parameter is omitted, the app will be launched without a file open.</span></span> |
| <span data-ttu-id="e3b12-137">secondarySharedAccessToken</span><span class="sxs-lookup"><span data-stu-id="e3b12-137">secondarySharedAccessToken</span></span> | <span data-ttu-id="e3b12-138">string</span><span class="sxs-lookup"><span data-stu-id="e3b12-138">string</span></span> | <span data-ttu-id="e3b12-139">いいえ</span><span class="sxs-lookup"><span data-stu-id="e3b12-139">no</span></span> | <span data-ttu-id="e3b12-140">切り取り領域に関するメタデータを含む JSON ファイルを識別する文字列。</span><span class="sxs-lookup"><span data-stu-id="e3b12-140">A string identifying a JSON file with metadata about the snip.</span></span> <span data-ttu-id="e3b12-141">メタデータは、配列の x、y 座標、や[userActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) **clipPoints**フィールドを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="e3b12-141">The metadata may include a **clipPoints** field with an array of x,y coordinates, and/or a [userActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity).</span></span> |
| <span data-ttu-id="e3b12-142">ソース</span><span class="sxs-lookup"><span data-stu-id="e3b12-142">source</span></span> | <span data-ttu-id="e3b12-143">string</span><span class="sxs-lookup"><span data-stu-id="e3b12-143">string</span></span> | <span data-ttu-id="e3b12-144">いいえ</span><span class="sxs-lookup"><span data-stu-id="e3b12-144">no</span></span> | <span data-ttu-id="e3b12-145">URI を起動したソースを示す自由形式の文字列です。</span><span class="sxs-lookup"><span data-stu-id="e3b12-145">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="e3b12-146">isTemporary</span><span class="sxs-lookup"><span data-stu-id="e3b12-146">isTemporary</span></span> | <span data-ttu-id="e3b12-147">bool</span><span class="sxs-lookup"><span data-stu-id="e3b12-147">bool</span></span> | <span data-ttu-id="e3b12-148">×</span><span class="sxs-lookup"><span data-stu-id="e3b12-148">no</span></span> | <span data-ttu-id="e3b12-149">場合は、画面スケッチが True に設定は、開いた後、ファイルを削除しようとしています。</span><span class="sxs-lookup"><span data-stu-id="e3b12-149">If set to True, Screen Sketch will try to delete the file after opening it.</span></span> |

<span data-ttu-id="e3b12-150">次の例では、ユーザーのアプリからの切り取り領域とスケッチに画像を送信する[LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_)メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="e3b12-150">The following example calls the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) method to send an image to Snip & Sketch from the user's app.</span></span>

```csharp

bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken=2C37ADDA-B054-40B5-8B38-11CED1E1A2D"));

```

<span data-ttu-id="e3b12-151">次の例を示します**ms スクリーン ショット**の**secondaryFileAccessToken**パラメーターで指定されたファイルに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="e3b12-151">The following example illustrates what a file specified by the **secondaryFileAccessToken** parameter of **ms-screenshot** might contain:</span></span>

```json
{
  "clipPoints": [
    {
      "x": 0,
      "y": 0
    },
    {
      "x": 2080,
      "y": 0
    },
    {
      "x": 2080,
      "y": 780
    },
    {
      "x": 0,
      "y": 780
    }
  ],
  "userActivity": "{\"$schema\":\"http://activity.windows.com/user-activity.json\",\"UserActivity\":\"type\",\"1.0\":\"version\",\"cross-platform-identifiers\":[{\"platform\":\"windows_universal\",\"application\":\"Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge\"},{\"platform\":\"host\",\"application\":\"edge.activity.windows.com\"}],\"activationUrl\":\"microsoft-edge:https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"contentUrl\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"visualElements\":{\"attribution\":{\"iconUrl\":\"https://www.microsoft.com/favicon.ico?v2\",\"alternateText\":\"microsoft.com\"},\"description\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"backgroundColor\":\"#FF0078D7\",\"displayText\":\"Use snipping tool to capture screenshots - Windows Help\",\"content\":{\"$schema\":\"http://adaptivecards.io/schemas/adaptive-card.json\",\"type\":\"AdaptiveCard\",\"version\":\"1.0\",\"body\":[{\"type\":\"Container\",\"items\":[{\"type\":\"TextBlock\",\"text\":\"Use snipping tool to capture screenshots - Windows Help\",\"weight\":\"bolder\",\"size\":\"large\",\"wrap\":true,\"maxLines\":3},{\"type\":\"TextBlock\",\"text\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\",\"size\":\"normal\",\"wrap\":true,\"maxLines\":3}]}]}},\"isRoamable\":true,\"appActivityId\":\"https://support.microsoft.com/en-us/help/13776/windows-use-snipping-tool-to-capture-screenshots\"}"
}

```
