---
title: ms-tonepicker スキーム
description: このトピックでは、ms-tonepicker URI スキームと、このスキームを使ってトーンの選択コントロールを表示し、トーンの選択、トーンの保存、トーンのフレンドリ名を取得する方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 0c17e4fb-7241-4da9-b457-d6d3a7aefccb
ms.localizationpriority: medium
ms.openlocfilehash: 293c755ecaf81ce80fab148a8aca92a7e3a8fa48
ms.sourcegitcommit: c01c29cd97f1cbf050950526e18e15823b6a12a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8694334"
---
# <a name="choose-and-save-tones-using-the-ms-tonepicker-uri-scheme"></a><span data-ttu-id="51483-104">ms-tonepicker URI スキームを使ったトーンの選択と保存</span><span class="sxs-lookup"><span data-stu-id="51483-104">Choose and save tones using the ms-tonepicker URI scheme</span></span>

<span data-ttu-id="51483-105">ここでは、**ms-tonepicker:** URI スキームの使い方について説明します。</span><span class="sxs-lookup"><span data-stu-id="51483-105">This topic describes how to use the **ms-tonepicker:** URI scheme.</span></span> <span data-ttu-id="51483-106">この URI スキームを使って実行できる操作は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-106">This URI scheme can be used to:</span></span>
- <span data-ttu-id="51483-107">トーンの選択コントロールがデバイスにあるかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="51483-107">Determine if the tone picker is available on the device.</span></span>
- <span data-ttu-id="51483-108">トーンの選択コントロールを表示して、利用可能な着信音、システム サウンド、SMS 着信音、アラーム音の一覧を表示したり、ユーザーが選択したサウンドを表すトーン トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="51483-108">Display the tone picker to list available ringtones, system sounds, text tones, and alarm sounds; and get a tone token which represents the sound the user selected.</span></span>
- <span data-ttu-id="51483-109">サウンド ファイル トークンを入力として受け取り、デバイスに保存するトーン セーバーを表示します。</span><span class="sxs-lookup"><span data-stu-id="51483-109">Display the tone saver, which takes a sound file token as input and saves it to the device.</span></span> <span data-ttu-id="51483-110">保存されたトーンは、トーンの選択コントロールから利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="51483-110">Saved tones are then available via the tone picker.</span></span> <span data-ttu-id="51483-111">トーンにはフレンドリ名を付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="51483-111">Users can also give the tone a friendly name.</span></span>
- <span data-ttu-id="51483-112">トーン トークンをフレンドリ名に変換します。</span><span class="sxs-lookup"><span data-stu-id="51483-112">Convert a tone token to its friendly name.</span></span>

## <a name="ms-tonepicker-uri-scheme-reference"></a><span data-ttu-id="51483-113">ms-tonepicker: URI スキーム リファレンス</span><span class="sxs-lookup"><span data-stu-id="51483-113">ms-tonepicker: URI scheme reference</span></span>

<span data-ttu-id="51483-114">この URI スキームは、URI スキーム文字列を利用して引数を渡すことはせず、[ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を介して引数を渡します。</span><span class="sxs-lookup"><span data-stu-id="51483-114">This URI scheme does not pass arguments via the URI scheme string, but instead passes arguments via a [ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx).</span></span> <span data-ttu-id="51483-115">すべての文字列で、大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="51483-115">All strings are case-sensitive.</span></span>

<span data-ttu-id="51483-116">以下のセクションでは、特定のタスクを実行するために渡される引数を示します。</span><span class="sxs-lookup"><span data-stu-id="51483-116">The sections below indicate which arguments should be passed to accomplish the specified task.</span></span>

## <a name="task-determine-if-the-tone-picker-is-available-on-the-device"></a><span data-ttu-id="51483-117">タスク: トーンの選択コントロールがデバイスにあるかどうかを確認する</span><span class="sxs-lookup"><span data-stu-id="51483-117">Task: Determine if the tone picker is available on the device</span></span>
```cs
var status = await Launcher.QueryUriSupportAsync(new Uri("ms-tonepicker:"),     
                                     LaunchQuerySupportType.UriForResults,
                                     "Microsoft.Tonepicker_8wekyb3d8bbwe");

if (status != LaunchQuerySupportStatus.Available)
{
    // the tone picker is not available
}
```

## <a name="task-display-the-tone-picker"></a><span data-ttu-id="51483-118">タスク: トーンの選択コントロールを表示する</span><span class="sxs-lookup"><span data-stu-id="51483-118">Task: Display the tone picker</span></span>

<span data-ttu-id="51483-119">トーンの選択コントロールを表示するために渡すことができる引数は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-119">The arguments you can pass to display the tone picker are as follows:</span></span>

| <span data-ttu-id="51483-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="51483-120">Parameter</span></span> | <span data-ttu-id="51483-121">型</span><span class="sxs-lookup"><span data-stu-id="51483-121">Type</span></span> | <span data-ttu-id="51483-122">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="51483-122">Required</span></span> | <span data-ttu-id="51483-123">値</span><span class="sxs-lookup"><span data-stu-id="51483-123">Possible values</span></span> | <span data-ttu-id="51483-124">説明</span><span class="sxs-lookup"><span data-stu-id="51483-124">Description</span></span> |
|-----------|------|----------|-------|-------------|
| <span data-ttu-id="51483-125">Action</span><span class="sxs-lookup"><span data-stu-id="51483-125">Action</span></span> | <span data-ttu-id="51483-126">string</span><span class="sxs-lookup"><span data-stu-id="51483-126">string</span></span> | <span data-ttu-id="51483-127">はい</span><span class="sxs-lookup"><span data-stu-id="51483-127">yes</span></span> | <span data-ttu-id="51483-128">"PickRingtone"</span><span class="sxs-lookup"><span data-stu-id="51483-128">"PickRingtone"</span></span> | <span data-ttu-id="51483-129">トーン選択コントロールを開きます。</span><span class="sxs-lookup"><span data-stu-id="51483-129">Opens the tone picker.</span></span> |
| <span data-ttu-id="51483-130">CurrentToneFilePath</span><span class="sxs-lookup"><span data-stu-id="51483-130">CurrentToneFilePath</span></span> | <span data-ttu-id="51483-131">string</span><span class="sxs-lookup"><span data-stu-id="51483-131">string</span></span> | <span data-ttu-id="51483-132">いいえ</span><span class="sxs-lookup"><span data-stu-id="51483-132">no</span></span> | <span data-ttu-id="51483-133">既存のトーン トークン。</span><span class="sxs-lookup"><span data-stu-id="51483-133">An existing tone token.</span></span> | <span data-ttu-id="51483-134">トーンの選択コントロールに現在のトーンとして表示されるトーン。</span><span class="sxs-lookup"><span data-stu-id="51483-134">The tone to show as the current tone in the tone picker.</span></span> <span data-ttu-id="51483-135">この値が設定されていない場合、既定では、一覧の最初のトーンが選ばれます。</span><span class="sxs-lookup"><span data-stu-id="51483-135">If this value is not set, the first tone on the list is selected by default.</span></span><br><span data-ttu-id="51483-136">これは厳密にはファイル パスではありません。</span><span class="sxs-lookup"><span data-stu-id="51483-136">This is not, strictly speaking, a file path.</span></span> <span data-ttu-id="51483-137">トーンの選択コントロールから返された `ToneToken` の値から、`CurrenttoneFilePath` に適した値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="51483-137">You can get a suitable value for `CurrenttoneFilePath` from the `ToneToken` value returned from the tone picker.</span></span>  |
| <span data-ttu-id="51483-138">TypeFilter</span><span class="sxs-lookup"><span data-stu-id="51483-138">TypeFilter</span></span> | <span data-ttu-id="51483-139">string</span><span class="sxs-lookup"><span data-stu-id="51483-139">string</span></span> | <span data-ttu-id="51483-140">いいえ</span><span class="sxs-lookup"><span data-stu-id="51483-140">no</span></span> | <span data-ttu-id="51483-141">"Ringtones"、"Notifications"、"Alarms"、"None"</span><span class="sxs-lookup"><span data-stu-id="51483-141">"Ringtones", "Notifications", "Alarms", "None"</span></span> | <span data-ttu-id="51483-142">選択コントロールに追加するトーンを選択します。</span><span class="sxs-lookup"><span data-stu-id="51483-142">Selects which tones to add to the picker.</span></span> <span data-ttu-id="51483-143">フィルターが指定されていない場合は、すべてのトーンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="51483-143">If no filter is specified then all tones are displayed.</span></span> |

<span data-ttu-id="51483-144">[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-144">The values that are returned in [LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx):</span></span>

| <span data-ttu-id="51483-145">戻り値</span><span class="sxs-lookup"><span data-stu-id="51483-145">Return values</span></span> | <span data-ttu-id="51483-146">型</span><span class="sxs-lookup"><span data-stu-id="51483-146">Type</span></span> | <span data-ttu-id="51483-147">値</span><span class="sxs-lookup"><span data-stu-id="51483-147">Possible values</span></span> | <span data-ttu-id="51483-148">説明</span><span class="sxs-lookup"><span data-stu-id="51483-148">Description</span></span> |
|--------------|------|-------|-------------|
| <span data-ttu-id="51483-149">Result</span><span class="sxs-lookup"><span data-stu-id="51483-149">Result</span></span> | <span data-ttu-id="51483-150">Int32</span><span class="sxs-lookup"><span data-stu-id="51483-150">Int32</span></span> | <span data-ttu-id="51483-151">0 - 成功しました。</span><span class="sxs-lookup"><span data-stu-id="51483-151">0-success.</span></span> <br><span data-ttu-id="51483-152">1 - 取り消されました。</span><span class="sxs-lookup"><span data-stu-id="51483-152">1-cancelled.</span></span> <br><span data-ttu-id="51483-153">7 - 無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="51483-153">7-invalid parameters.</span></span> <br><span data-ttu-id="51483-154">8 - フィルター条件に一致するトーンがありません。</span><span class="sxs-lookup"><span data-stu-id="51483-154">8 - no tones match the filter criteria.</span></span> <br><span data-ttu-id="51483-155">255 - 指定された操作が実装されていません。</span><span class="sxs-lookup"><span data-stu-id="51483-155">255 - specified action is not implemented.</span></span> | <span data-ttu-id="51483-156">選択コントロールの操作の結果。</span><span class="sxs-lookup"><span data-stu-id="51483-156">The result of the picker operation.</span></span> |
| <span data-ttu-id="51483-157">ToneToken</span><span class="sxs-lookup"><span data-stu-id="51483-157">ToneToken</span></span> | <span data-ttu-id="51483-158">string</span><span class="sxs-lookup"><span data-stu-id="51483-158">string</span></span> | <span data-ttu-id="51483-159">選択されたトーンのトークン。</span><span class="sxs-lookup"><span data-stu-id="51483-159">The selected tone's token.</span></span> <br><span data-ttu-id="51483-160">ユーザーが選択コントロールで**既定**を選択している場合、この文字列は空です。</span><span class="sxs-lookup"><span data-stu-id="51483-160">The string is empty if the user selects **default** in the picker.</span></span> | <span data-ttu-id="51483-161">このトークンはトースト通知のペイロードで使用したり、任意の連絡先の着信音や SMS 着信音として割り当てたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="51483-161">This token can be used in a toast notification payload, or can be assigned as a contact’s ringtone or text tone.</span></span> <span data-ttu-id="51483-162">**Result** が 0 の場合のみ、ValueSet にパラメーターが返されます。</span><span class="sxs-lookup"><span data-stu-id="51483-162">The parameter is returned in the ValueSet only if **Result** is 0.</span></span> |
| <span data-ttu-id="51483-163">DisplayName</span><span class="sxs-lookup"><span data-stu-id="51483-163">DisplayName</span></span> | <span data-ttu-id="51483-164">string</span><span class="sxs-lookup"><span data-stu-id="51483-164">string</span></span> | <span data-ttu-id="51483-165">指定したトーンのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="51483-165">The specified tone’s friendly name.</span></span> | <span data-ttu-id="51483-166">ユーザーに対して表示できる、選択されたトーンを表す文字列。</span><span class="sxs-lookup"><span data-stu-id="51483-166">A string that can be shown to the user to represent the selected tone.</span></span> <span data-ttu-id="51483-167">**Result** が 0 の場合のみ、ValueSet にパラメーターが返されます。</span><span class="sxs-lookup"><span data-stu-id="51483-167">The parameter is returned in the ValueSet only if **Result** is 0.</span></span> |


**<span data-ttu-id="51483-168">例: ユーザーがトーンを選択できるようにトーンの選択コントロールを開く</span><span class="sxs-lookup"><span data-stu-id="51483-168">Example: Open the tone picker so that the user can select a tone</span></span>**

``` cs
LauncherOptions options = new LauncherOptions();
options.TargetApplicationPackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";

ValueSet inputData = new ValueSet() {
    { "Action", "PickRingtone" },
    { "TypeFilter", "Ringtones" } // Show only ringtones
};

LaunchUriResult result = await Launcher.LaunchUriForResultsAsync(new Uri("ms-tonepicker:"), options, inputData);

if (result.Status == LaunchUriStatus.Success)
{
     Int32 resultCode =  (Int32)result.Result["Result"];
     if (resultCode == 0)
     {
         string token = result.Result["ToneToken"] as string;
         string name = result.Result["DisplayName"] as string;
     }
     else
     {
           // handle failure
     }
}
```

## <a name="task-display-the-tone-saver"></a><span data-ttu-id="51483-169">タスク: トーン セーバーを表示する</span><span class="sxs-lookup"><span data-stu-id="51483-169">Task: Display the tone saver</span></span>

<span data-ttu-id="51483-170">トーン セーバーを表示するために渡すことができる引数は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-170">The arguments you can pass to display the tone saver are as follows:</span></span>

| <span data-ttu-id="51483-171">パラメーター</span><span class="sxs-lookup"><span data-stu-id="51483-171">Parameter</span></span> | <span data-ttu-id="51483-172">型</span><span class="sxs-lookup"><span data-stu-id="51483-172">Type</span></span> | <span data-ttu-id="51483-173">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="51483-173">Required</span></span> | <span data-ttu-id="51483-174">値</span><span class="sxs-lookup"><span data-stu-id="51483-174">Possible values</span></span> | <span data-ttu-id="51483-175">説明</span><span class="sxs-lookup"><span data-stu-id="51483-175">Description</span></span> |
|-----------|------|----------|-------|-------------|
| <span data-ttu-id="51483-176">Action</span><span class="sxs-lookup"><span data-stu-id="51483-176">Action</span></span> | <span data-ttu-id="51483-177">string</span><span class="sxs-lookup"><span data-stu-id="51483-177">string</span></span> | <span data-ttu-id="51483-178">はい</span><span class="sxs-lookup"><span data-stu-id="51483-178">yes</span></span> | <span data-ttu-id="51483-179">"SaveRingtone"</span><span class="sxs-lookup"><span data-stu-id="51483-179">"SaveRingtone"</span></span> | <span data-ttu-id="51483-180">選択コントロールを開いて着信音を保存します。</span><span class="sxs-lookup"><span data-stu-id="51483-180">Opens the picker to save a ringtone.</span></span> |
| <span data-ttu-id="51483-181">ToneFileSharingToken</span><span class="sxs-lookup"><span data-stu-id="51483-181">ToneFileSharingToken</span></span> | <span data-ttu-id="51483-182">string</span><span class="sxs-lookup"><span data-stu-id="51483-182">string</span></span> | <span data-ttu-id="51483-183">はい</span><span class="sxs-lookup"><span data-stu-id="51483-183">yes</span></span> | <span data-ttu-id="51483-184">保存する着信音ファイルの [SharedStorageAccessManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.aspx) ファイル共有トークン。</span><span class="sxs-lookup"><span data-stu-id="51483-184">[SharedStorageAccessManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.aspx) file sharing token for the ringtone file to save.</span></span> | <span data-ttu-id="51483-185">特定のサウンド ファイルを着信音として保存します。</span><span class="sxs-lookup"><span data-stu-id="51483-185">Saves a specific sound file as a ringtone.</span></span> <span data-ttu-id="51483-186">サポートされるファイル コンテンツの種類は、MPEG オーディオと x-ms-wma オーディオです。</span><span class="sxs-lookup"><span data-stu-id="51483-186">The supported content types for the file are mpeg audio and x-ms-wma audio.</span></span> |
| <span data-ttu-id="51483-187">DisplayName</span><span class="sxs-lookup"><span data-stu-id="51483-187">DisplayName</span></span> | <span data-ttu-id="51483-188">string</span><span class="sxs-lookup"><span data-stu-id="51483-188">string</span></span> | <span data-ttu-id="51483-189">いいえ</span><span class="sxs-lookup"><span data-stu-id="51483-189">no</span></span> | <span data-ttu-id="51483-190">指定したトーンのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="51483-190">The specified tone’s friendly name.</span></span> | <span data-ttu-id="51483-191">指定した着信音を保存するときに使用する表示名を設定します。</span><span class="sxs-lookup"><span data-stu-id="51483-191">Sets the display name to use when saving the specified ringtone.</span></span> |

<span data-ttu-id="51483-192">[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-192">The values that are returned in [LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx):</span></span>

| <span data-ttu-id="51483-193">戻り値</span><span class="sxs-lookup"><span data-stu-id="51483-193">Return values</span></span> | <span data-ttu-id="51483-194">型</span><span class="sxs-lookup"><span data-stu-id="51483-194">Type</span></span> | <span data-ttu-id="51483-195">値</span><span class="sxs-lookup"><span data-stu-id="51483-195">Possible values</span></span> | <span data-ttu-id="51483-196">説明</span><span class="sxs-lookup"><span data-stu-id="51483-196">Description</span></span> |
|--------------|------|-------|-------------|
| <span data-ttu-id="51483-197">Result</span><span class="sxs-lookup"><span data-stu-id="51483-197">Result</span></span> | <span data-ttu-id="51483-198">Int32</span><span class="sxs-lookup"><span data-stu-id="51483-198">Int32</span></span> | <span data-ttu-id="51483-199">0 - 成功しました。</span><span class="sxs-lookup"><span data-stu-id="51483-199">0-success.</span></span><br><span data-ttu-id="51483-200">1 - ユーザーによって取り消されました。</span><span class="sxs-lookup"><span data-stu-id="51483-200">1-cancelled by user.</span></span><br><span data-ttu-id="51483-201">2 - 無効なファイルです。</span><span class="sxs-lookup"><span data-stu-id="51483-201">2-Invalid file.</span></span><br><span data-ttu-id="51483-202">3 - 無効なファイル コンテンツの種類です。</span><span class="sxs-lookup"><span data-stu-id="51483-202">3-Invalid file content type.</span></span><br><span data-ttu-id="51483-203">4 - ファイルが着信音の最大サイズ (Windows 10 では 1 MB) を超えています。</span><span class="sxs-lookup"><span data-stu-id="51483-203">4-file exceeds maximum ringtone size (1MB in Windows 10).</span></span><br><span data-ttu-id="51483-204">5 - ファイルが 40 秒の長さ制限を超えています。</span><span class="sxs-lookup"><span data-stu-id="51483-204">5-File exceeds 40 second length limit.</span></span><br><span data-ttu-id="51483-205">6 - ファイルがデジタル著作権管理によって保護されています。</span><span class="sxs-lookup"><span data-stu-id="51483-205">6-File is protected by digital rights management.</span></span><br><span data-ttu-id="51483-206">7 - 無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="51483-206">7-invalid  parameters.</span></span> | <span data-ttu-id="51483-207">選択コントロールの操作の結果。</span><span class="sxs-lookup"><span data-stu-id="51483-207">The result of the picker operation.</span></span> |

**<span data-ttu-id="51483-208">例: ローカルの音楽ファイルを着信音として保存する</span><span class="sxs-lookup"><span data-stu-id="51483-208">Example: Save a local music file as a ringtone</span></span>**

``` cs
LauncherOptions options = new LauncherOptions();
options.TargetApplicationPackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";

ValueSet inputData = new ValueSet() {
    { "Action", "SaveRingtone" },
    { "ToneFileSharingToken", SharedStorageAccessManager.AddFile(myLocalFile) }
};

LaunchUriResult result = await Launcher.LaunchUriForResultsAsync(new Uri("ms-tonepicker:"), options, inputData);

if (result.Status == LaunchUriStatus.Success)
{
     Int32 resultCode = (Int32)result.Result["Result"];

     if (resultCode == 0)
     {
         // no issues
     }
     else
     {
          switch (resultCode)
          {
             case 2:
              // The specified file was invalid
              break;
              case 3:
              // The specified file's content type is invalid
              break;
              case 4:
              // The specified file was too big
              break;
              case 5:
              // The specified file was too long
              break;
              case 6:
              // The file was protected by DRM
              break;
              case 7:
              // The specified parameter was incorrect
              break;
          }
      }
 }
```

## <a name="task-convert-a-tone-token-to-its-friendly-name"></a><span data-ttu-id="51483-209">タスク: トーン トークンをフレンドリ名に変換する</span><span class="sxs-lookup"><span data-stu-id="51483-209">Task: Convert a tone token to its friendly name</span></span>

<span data-ttu-id="51483-210">トーンのフレンドリ名を取得するために渡すことができる引数は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-210">The arguments you can pass to get the friendly name of a tone are as follows:</span></span>

| <span data-ttu-id="51483-211">パラメーター</span><span class="sxs-lookup"><span data-stu-id="51483-211">Parameter</span></span> | <span data-ttu-id="51483-212">型</span><span class="sxs-lookup"><span data-stu-id="51483-212">Type</span></span> | <span data-ttu-id="51483-213">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="51483-213">Required</span></span> | <span data-ttu-id="51483-214">値</span><span class="sxs-lookup"><span data-stu-id="51483-214">Possible values</span></span> | <span data-ttu-id="51483-215">説明</span><span class="sxs-lookup"><span data-stu-id="51483-215">Description</span></span> |
|-----------|------|----------|-------|-------------|
| <span data-ttu-id="51483-216">Action</span><span class="sxs-lookup"><span data-stu-id="51483-216">Action</span></span> | <span data-ttu-id="51483-217">string</span><span class="sxs-lookup"><span data-stu-id="51483-217">string</span></span> | <span data-ttu-id="51483-218">はい</span><span class="sxs-lookup"><span data-stu-id="51483-218">yes</span></span> | <span data-ttu-id="51483-219">"GetToneName"</span><span class="sxs-lookup"><span data-stu-id="51483-219">"GetToneName"</span></span> | <span data-ttu-id="51483-220">トーンのフレンドリ名を取得することを示します。</span><span class="sxs-lookup"><span data-stu-id="51483-220">Indicates that you want to get the friendly name of a tone.</span></span> |
| <span data-ttu-id="51483-221">ToneToken</span><span class="sxs-lookup"><span data-stu-id="51483-221">ToneToken</span></span> | <span data-ttu-id="51483-222">string</span><span class="sxs-lookup"><span data-stu-id="51483-222">string</span></span> | <span data-ttu-id="51483-223">はい</span><span class="sxs-lookup"><span data-stu-id="51483-223">yes</span></span> | <span data-ttu-id="51483-224">トーンのトークン</span><span class="sxs-lookup"><span data-stu-id="51483-224">The tone token</span></span> | <span data-ttu-id="51483-225">表示名を取得する対象となるトーン トークン。</span><span class="sxs-lookup"><span data-stu-id="51483-225">The tone token from which to obtain a display name.</span></span> |

<span data-ttu-id="51483-226">[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="51483-226">The values that are returned in [LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx):</span></span>

| <span data-ttu-id="51483-227">戻り値</span><span class="sxs-lookup"><span data-stu-id="51483-227">Return value</span></span> | <span data-ttu-id="51483-228">型</span><span class="sxs-lookup"><span data-stu-id="51483-228">Type</span></span> | <span data-ttu-id="51483-229">値</span><span class="sxs-lookup"><span data-stu-id="51483-229">Possible values</span></span> | <span data-ttu-id="51483-230">説明</span><span class="sxs-lookup"><span data-stu-id="51483-230">Description</span></span> |
|--------------|------|-------|-------------|
| <span data-ttu-id="51483-231">Result</span><span class="sxs-lookup"><span data-stu-id="51483-231">Result</span></span> | <span data-ttu-id="51483-232">Int32</span><span class="sxs-lookup"><span data-stu-id="51483-232">Int32</span></span> | <span data-ttu-id="51483-233">0 - 選択コントロールの操作が成功しました。</span><span class="sxs-lookup"><span data-stu-id="51483-233">0-The picker operation succeeded.</span></span><br><span data-ttu-id="51483-234">7 - パラメーターが正しくありません (ToneToken が指定されていないなど)。</span><span class="sxs-lookup"><span data-stu-id="51483-234">7-Incorrect parameter (for example, no ToneToken provided).</span></span><br><span data-ttu-id="51483-235">9 - 指定されたトークンの名前の読み取り中にエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="51483-235">9-Error reading the name for the specified token.</span></span><br><span data-ttu-id="51483-236">10 - 指定されたトーン トークンが見つかりません。</span><span class="sxs-lookup"><span data-stu-id="51483-236">10-Unable to find specified tone token.</span></span> | <span data-ttu-id="51483-237">選択コントロールの操作の結果。</span><span class="sxs-lookup"><span data-stu-id="51483-237">The result of the picker operation.</span></span>
| <span data-ttu-id="51483-238">DisplayName</span><span class="sxs-lookup"><span data-stu-id="51483-238">DisplayName</span></span> | <span data-ttu-id="51483-239">string</span><span class="sxs-lookup"><span data-stu-id="51483-239">string</span></span> | <span data-ttu-id="51483-240">トーンのフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="51483-240">The tone's friendly name.</span></span> | <span data-ttu-id="51483-241">指定されたトーンの表示名を返します。</span><span class="sxs-lookup"><span data-stu-id="51483-241">Returns the selected tone's display name.</span></span> <span data-ttu-id="51483-242">**Result** が 0 の場合のみ、ValueSet にこのパラメーターが返されます。</span><span class="sxs-lookup"><span data-stu-id="51483-242">This parameter is only returned in the ValueSet if **Result** is 0.</span></span> |

**<span data-ttu-id="51483-243">例: Contact.RingToneToken からトーン トークンを取得して、連絡先カードにそのフレンドリ名を表示する</span><span class="sxs-lookup"><span data-stu-id="51483-243">Example: Retrieve a tone token from Contact.RingToneToken and display its friendly name in the contact card.</span></span>**

```cs
using (var connection = new AppServiceConnection())
{
    connection.AppServiceName = "ms-tonepicker-nameprovider";
    connection.PackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";
    AppServiceConnectionStatus connectionStatus = await connection.OpenAsync();
    if (connectionStatus == AppServiceConnectionStatus.Success)
    {
        var message = new ValueSet() {
            { "Action", "GetToneName" },
            { "ToneToken", token)
        };
        AppServiceResponse response = await connection.SendMessageAsync(message);
        if (response.Status == AppServiceResponseStatus.Success)
        {
            Int32 resultCode = (Int32)response.Message["Result"];
            if (resultCode == 0)
            {
                string name = response.Message["DisplayName"] as string;
            }
            else
            {
                // handle failure
            }
        }
        else
        {
            // handle failure
        }
    }
}
```
