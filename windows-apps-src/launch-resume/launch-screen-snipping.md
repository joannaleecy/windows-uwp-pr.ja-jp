---
title: 画面切り取りの起動
description: このトピックでは、ms screenclip と ms screensketch URI スキームについて説明します。 アプリは、これらの URI スキームを使用して、切り取り領域の & スケッチのアプリを起動する場合や新しい切り取り領域を開くことができます。
ms.date: 08/09/2017
ms.topic: article
keywords: windows 10、uwp、uri、切り取り領域、スケッチ
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 06e988387f574b74d511b14a2ebca24b0a149158
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57595387"
---
# <a name="launch-screen-snipping"></a><span data-ttu-id="3fbb7-105">画面切り取りの起動</span><span class="sxs-lookup"><span data-stu-id="3fbb7-105">Launch screen snipping</span></span>

<span data-ttu-id="3fbb7-106">**Ms screenclip:** と**ms screensketch:** URI スキームでは、snipping またはスクリーン ショットの編集を開始できます。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-106">The **ms-screenclip:** and **ms-screensketch:** URI schemes allows you to initiate snipping or editing screenshots.</span></span>

## <a name="open-a-new-snip-from-your-app"></a><span data-ttu-id="3fbb7-107">アプリから新しい切り取り領域を開く</span><span class="sxs-lookup"><span data-stu-id="3fbb7-107">Open a new snip from your app</span></span>

<span data-ttu-id="3fbb7-108">**Ms screenclip:** URI は、アプリを自動的に起動し、新しい切り取り領域を開始できます。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-108">The **ms-screenclip:** URI allows your app to automatically open up and start a new snip.</span></span> <span data-ttu-id="3fbb7-109">結果として得られる、切り取り領域はユーザーのクリップボードにコピーされますが、アプリを開いてが自動的に渡されない。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-109">The resulting snip is copied to the user's clipboard, but is not automatically passed back to the opening app.</span></span>

<span data-ttu-id="3fbb7-110">**ms screenclip:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-110">**ms-screenclip:** takes the following parameters:</span></span>

| <span data-ttu-id="3fbb7-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3fbb7-111">Parameter</span></span> | <span data-ttu-id="3fbb7-112">種類</span><span class="sxs-lookup"><span data-stu-id="3fbb7-112">Type</span></span> | <span data-ttu-id="3fbb7-113">必須</span><span class="sxs-lookup"><span data-stu-id="3fbb7-113">Required</span></span> | <span data-ttu-id="3fbb7-114">説明</span><span class="sxs-lookup"><span data-stu-id="3fbb7-114">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="3fbb7-115">ソース</span><span class="sxs-lookup"><span data-stu-id="3fbb7-115">source</span></span> | <span data-ttu-id="3fbb7-116">string</span><span class="sxs-lookup"><span data-stu-id="3fbb7-116">string</span></span> | <span data-ttu-id="3fbb7-117">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-117">no</span></span> | <span data-ttu-id="3fbb7-118">URI を起動したソースを示す自由形式の文字列。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-118">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="3fbb7-119">delayInSeconds</span><span class="sxs-lookup"><span data-stu-id="3fbb7-119">delayInSeconds</span></span> | <span data-ttu-id="3fbb7-120">int</span><span class="sxs-lookup"><span data-stu-id="3fbb7-120">int</span></span> | <span data-ttu-id="3fbb7-121">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-121">no</span></span> | <span data-ttu-id="3fbb7-122">1 ~ 30 の整数値。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-122">An integer value, from 1 to 30.</span></span> <span data-ttu-id="3fbb7-123">URI の呼び出しと snipping の開始時の間の完全な秒の遅延を指定します。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-123">Specifies the delay, in full seconds, between the URI call and when snipping begins.</span></span> |
| <span data-ttu-id="3fbb7-124">callbackformat</span><span class="sxs-lookup"><span data-stu-id="3fbb7-124">callbackformat</span></span> | <span data-ttu-id="3fbb7-125">string</span><span class="sxs-lookup"><span data-stu-id="3fbb7-125">string</span></span> | <span data-ttu-id="3fbb7-126">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-126">no</span></span> | <span data-ttu-id="3fbb7-127">このパラメーターは使用できません。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-127">This parameter is unavailable.</span></span> |

## <a name="launching-the-snip--sketch-app"></a><span data-ttu-id="3fbb7-128">切り取り領域とスケッチ アプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-128">Launching the Snip & Sketch App</span></span>

<span data-ttu-id="3fbb7-129">**Ms screensketch:** URI を使用すると、プログラムで、切り取り領域の & スケッチ アプリを起動し、注釈には、そのアプリで特定のイメージを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-129">The **ms-screensketch:** URI allows you to programatically launch the Snip & Sketch app, and open a specific image in that app for annotation.</span></span>

<span data-ttu-id="3fbb7-130">**ms screensketch:** は次のパラメーターを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-130">**ms-screensketch:** takes the following parameters:</span></span>

| <span data-ttu-id="3fbb7-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3fbb7-131">Parameter</span></span> | <span data-ttu-id="3fbb7-132">種類</span><span class="sxs-lookup"><span data-stu-id="3fbb7-132">Type</span></span> | <span data-ttu-id="3fbb7-133">必須</span><span class="sxs-lookup"><span data-stu-id="3fbb7-133">Required</span></span> | <span data-ttu-id="3fbb7-134">説明</span><span class="sxs-lookup"><span data-stu-id="3fbb7-134">Description</span></span> |
| --- | --- | --- | --- |
| <span data-ttu-id="3fbb7-135">sharedAccessToken</span><span class="sxs-lookup"><span data-stu-id="3fbb7-135">sharedAccessToken</span></span> | <span data-ttu-id="3fbb7-136">string</span><span class="sxs-lookup"><span data-stu-id="3fbb7-136">string</span></span> | <span data-ttu-id="3fbb7-137">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-137">no</span></span> | <span data-ttu-id="3fbb7-138">切り取り領域の & スケッチのアプリで開くファイルを識別するトークンです。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-138">A token identifying the file to open in the Snip & Sketch app.</span></span> <span data-ttu-id="3fbb7-139">取得した[SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile)します。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-139">Retrieved from [SharedStorageAccessManager.AddFile](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.addfile).</span></span> <span data-ttu-id="3fbb7-140">このパラメーターを省略した場合は、開いているファイルを使用せず、アプリが起動されます。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-140">If this parameter is omitted, the app will be launched without a file open.</span></span> |
| <span data-ttu-id="3fbb7-141">secondarySharedAccessToken</span><span class="sxs-lookup"><span data-stu-id="3fbb7-141">secondarySharedAccessToken</span></span> | <span data-ttu-id="3fbb7-142">string</span><span class="sxs-lookup"><span data-stu-id="3fbb7-142">string</span></span> | <span data-ttu-id="3fbb7-143">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-143">no</span></span> | <span data-ttu-id="3fbb7-144">切り取り領域についてのメタデータを含む JSON ファイルを識別する文字列。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-144">A string identifying a JSON file with metadata about the snip.</span></span> <span data-ttu-id="3fbb7-145">メタデータを含めることができます、 **clipPoints**フィールドに、x、y 座標の配列、または[userActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)します。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-145">The metadata may include a **clipPoints** field with an array of x,y coordinates, and/or a [userActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity).</span></span> |
| <span data-ttu-id="3fbb7-146">ソース</span><span class="sxs-lookup"><span data-stu-id="3fbb7-146">source</span></span> | <span data-ttu-id="3fbb7-147">string</span><span class="sxs-lookup"><span data-stu-id="3fbb7-147">string</span></span> | <span data-ttu-id="3fbb7-148">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-148">no</span></span> | <span data-ttu-id="3fbb7-149">URI を起動したソースを示す自由形式の文字列。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-149">A freeform string to indicate the source that launched the URI.</span></span> |
| <span data-ttu-id="3fbb7-150">IsTemporary</span><span class="sxs-lookup"><span data-stu-id="3fbb7-150">isTemporary</span></span> | <span data-ttu-id="3fbb7-151">bool</span><span class="sxs-lookup"><span data-stu-id="3fbb7-151">bool</span></span> | <span data-ttu-id="3fbb7-152">no</span><span class="sxs-lookup"><span data-stu-id="3fbb7-152">no</span></span> | <span data-ttu-id="3fbb7-153">画面のスケッチを True に設定するが開いた後、ファイルを削除しようとするとします。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-153">If set to True, Screen Sketch will try to delete the file after opening it.</span></span> |

<span data-ttu-id="3fbb7-154">次の例では、 [LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_)スケッチ (&)、切り取り領域に、ユーザーのアプリからイメージを送信する方法。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-154">The following example calls the [LaunchUriAsync](https://docs.microsoft.com/uwp/api/Windows.System.Launcher#Windows_System_Launcher_LaunchUriAsync_Windows_Foundation_Uri_) method to send an image to Snip & Sketch from the user's app.</span></span>

```csharp

bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-screensketch:edit?source=MyApp&isTemporary=false&sharedAccessToken=2C37ADDA-B054-40B5-8B38-11CED1E1A2D"));

```

<span data-ttu-id="3fbb7-155">次の例では、どのようなファイルで指定された、 **secondarySharedAccessToken**パラメーターの**ms screensketch**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="3fbb7-155">The following example illustrates what a file specified by the **secondarySharedAccessToken** parameter of **ms-screensketch** might contain:</span></span>

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
