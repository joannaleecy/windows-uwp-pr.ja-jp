---
author: TylerMSFT
title: Microsoft Store アプリの起動
description: ここでは、ms-windows-store URI スキームについて説明します。 アプリは、この URI スキームを使用して、ストア内の特定のページに Microsoft Store アプリを起動することができます。
ms.assetid: 9A9C6576-1637-47D1-AC3B-D1A20D49E0FF
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 42dfecd7d1bc2c298a70fec2bdebfc4c4f9dd66c
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5685075"
---
# <a name="launch-the-microsoft-store-app"></a><span data-ttu-id="e4d90-105">Microsoft Store アプリの起動</span><span class="sxs-lookup"><span data-stu-id="e4d90-105">Launch the Microsoft Store app</span></span>



<span data-ttu-id="e4d90-106">ここでは、**ms-windows-store:** URI スキームについて説明します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-106">This topic describes the **ms-windows-store:** URI scheme.</span></span> <span data-ttu-id="e4d90-107">アプリは、この URI スキームを使用して、 [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)メソッドを使用して、ストア内の特定のページに Microsoft Store アプリを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="e4d90-107">Your app can use this URI scheme to launch the Microsoft Store app to specific pages in the store by using the [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) method.</span></span>

<span data-ttu-id="e4d90-108">この例では、ゲームのページにストアを開く方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-108">This example shows how to open the Store to the Games page:</span></span>

```cs
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://navigatetopage/?Id=Games"));
```

## <a name="ms-windows-store-uri-scheme-reference"></a><span data-ttu-id="e4d90-109">ms-windows-store: URI スキーム リファレンス</span><span class="sxs-lookup"><span data-stu-id="e4d90-109">ms-windows-store: URI scheme reference</span></span>

<table>
<tr><th><span data-ttu-id="e4d90-110">説明</span><span class="sxs-lookup"><span data-stu-id="e4d90-110">Description</span></span></th><th></th><th><span data-ttu-id="e4d90-111">URI スキーム</span><span class="sxs-lookup"><span data-stu-id="e4d90-111">URI scheme</span></span></th></tr>
<tr><td><span data-ttu-id="e4d90-112">ストアのホーム ページを起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-112">Launches the home page of the Store.</span></span></td><td /><td><span data-ttu-id="e4d90-113">ms-windows-store://home</span><span class="sxs-lookup"><span data-stu-id="e4d90-113">ms-windows-store://home</span></span></td></tr>
<tr><td><span data-ttu-id="e4d90-114">ストア内の最上位レベルのカテゴリを起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-114">Launches a top-level vertical in the Store.</span></span><p><span data-ttu-id="e4d90-115">注: すべてのユーザーがすべてのカテゴリにアクセスできるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="e4d90-115">Note: Not all users have access to all verticals.</span></span></p>
</td><td /><td>
<p><span data-ttu-id="e4d90-116">ms-windows-store://navigatetopage/?Id=Apps</span><span class="sxs-lookup"><span data-stu-id="e4d90-116">ms-windows-store://navigatetopage/?Id=Apps</span></span> </p>
<p><span data-ttu-id="e4d90-117">ms-windows-store://navigatetopage/?Id=Games</span><span class="sxs-lookup"><span data-stu-id="e4d90-117">ms-windows-store://navigatetopage/?Id=Games</span></span></p>
<p><span data-ttu-id="e4d90-118">ms-windows-store://navigatetopage/?Id=Music</span><span class="sxs-lookup"><span data-stu-id="e4d90-118">ms-windows-store://navigatetopage/?Id=Music</span></span></p>
<p><span data-ttu-id="e4d90-119">ms-windows-store://navigatetopage/?Id=Video</span><span class="sxs-lookup"><span data-stu-id="e4d90-119">ms-windows-store://navigatetopage/?Id=Video</span></span></p>
<p><span data-ttu-id="e4d90-120">ms-windows-store://navigatetopage/?Id=LOB</span><span class="sxs-lookup"><span data-stu-id="e4d90-120">ms-windows-store://navigatetopage/?Id=LOB</span></span></p>
</td>
</tr>
<tr>
<td rowspan="4"><span data-ttu-id="e4d90-121">製品の詳細ページ (PDP) を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-121">Launches the product details page (PDP) for a product.</span></span> <p><span data-ttu-id="e4d90-122">ストア ID を使う方法は Windows 10 のユーザー向けに推奨される一方ですべての OS バージョンで動作しますが、以前の方法 (PFN など) も使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4d90-122">Store ID is recommended for customers on Windows 10, and will work on all OS versions, but the earlier ways of doing it (ex: PFN) are still supported.</span></span></p>
<p><span data-ttu-id="e4d90-123">Windows デベロッパー センター ダッシュボードにある各アプリの [アプリ管理] セクションの <a href="https://msdn.microsoft.com/library/windows/apps/mt148561.aspx">[アプリ ID]</a> ページでこれらの値を表示できます。</span><span class="sxs-lookup"><span data-stu-id="e4d90-123">These values can be found in the Windows Dev Center dashboard on the <a href="https://msdn.microsoft.com/library/windows/apps/mt148561.aspx">App identity</a> page in the App management section for each app.</span></span></p>
</td>
<td>
<span data-ttu-id="e4d90-124">ストア ID</span><span class="sxs-lookup"><span data-stu-id="e4d90-124">Store ID</span></span> <p><span data-ttu-id="e4d90-125">(推奨)</span><span class="sxs-lookup"><span data-stu-id="e4d90-125">(Recommended)</span></span></p>
</td>
<td>
<p><span data-ttu-id="e4d90-126">ms-windows-store://pdp/?ProductId=9WZDNCRFHVJL</span><span class="sxs-lookup"><span data-stu-id="e4d90-126">ms-windows-store://pdp/?ProductId=9WZDNCRFHVJL</span></span></p>
</td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-127">パッケージ ファミリ名 (PFN)</span><span class="sxs-lookup"><span data-stu-id="e4d90-127">Package Family Name (PFN)</span></span></td>
<td><span data-ttu-id="e4d90-128">ms-windows-store://pdp/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="e4d90-128">ms-windows-store://pdp/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe</span></span>
</td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-129">製品 ID (Windows Phone 7.x/8.x)</span><span class="sxs-lookup"><span data-stu-id="e4d90-129">Product ID (Windows Phone 7.x/8.x)</span></span></td>
<td><span data-ttu-id="e4d90-130">ms-windows-store://pdp/?PhoneAppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d</span><span class="sxs-lookup"><span data-stu-id="e4d90-130">ms-windows-store://pdp/?PhoneAppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-131">製品 ID (Windows 8.x)</span><span class="sxs-lookup"><span data-stu-id="e4d90-131">Product ID (Windows 8.x)</span></span></td>
<td><span data-ttu-id="e4d90-132">ms-windows-store://pdp/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117</span><span class="sxs-lookup"><span data-stu-id="e4d90-132">ms-windows-store://pdp/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117</span></span>
</td>
</tr>
<tr>
<td rowspan="4"><span data-ttu-id="e4d90-133">製品のレビューを書くエクスペリエンスを起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-133">Launches the write a review experience for a product.</span></span></td>
<td><span data-ttu-id="e4d90-134">ストア ID</span><span class="sxs-lookup"><span data-stu-id="e4d90-134">Store ID</span></span> <p><span data-ttu-id="e4d90-135">(推奨)</span><span class="sxs-lookup"><span data-stu-id="e4d90-135">(Recommended)</span></span></p></td>
<td><span data-ttu-id="e4d90-136">ms-windows-store://review/?ProductId=9WZDNCRFHVJL</span><span class="sxs-lookup"><span data-stu-id="e4d90-136">ms-windows-store://review/?ProductId=9WZDNCRFHVJL</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-137">パッケージ ファミリ名 (PFN)</span><span class="sxs-lookup"><span data-stu-id="e4d90-137">Package Family Name (PFN)</span></span></td>
<td><span data-ttu-id="e4d90-138">ms-windows-store://review/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe</span><span class="sxs-lookup"><span data-stu-id="e4d90-138">ms-windows-store://review/?PFN= Microsoft.Office.OneNote_8wekyb3d8bbwe</span></span>
</td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-139">製品 ID (Windows Phone 7.x/8.x)</span><span class="sxs-lookup"><span data-stu-id="e4d90-139">Product ID (Windows Phone 7.x/8.x)</span></span></td>
<td><span data-ttu-id="e4d90-140">ms-windows-store://reviewapp/?AppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d</span><span class="sxs-lookup"><span data-stu-id="e4d90-140">ms-windows-store://reviewapp/?AppId=ca05b3ab-f157-450c-8c49-a1f127f5e71d</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-141">製品 ID (Windows 8.x)</span><span class="sxs-lookup"><span data-stu-id="e4d90-141">Product ID (Windows 8.x)</span></span></td>
<td><span data-ttu-id="e4d90-142">ms-windows-store://review/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117</span><span class="sxs-lookup"><span data-stu-id="e4d90-142">ms-windows-store://review/?AppId=f022389f-f3a6-417e-ad23-704fbdf57117</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-143">ファイル拡張子に関連付けられた製品の検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-143">Launches a search for products associated with a file extension.</span></span> </td>
<td />
<td><span data-ttu-id="e4d90-144">ms-windows-store://assoc/?FileExt=pdf</span><span class="sxs-lookup"><span data-stu-id="e4d90-144">ms-windows-store://assoc/?FileExt=pdf</span></span>
</td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-145">プロトコルに関連付けられた製品の検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-145">Launches a search for products associated with a protocol.</span></span></td>
<td />
<td><span data-ttu-id="e4d90-146">ms-windows-store://assoc/?Protocol=ms-word</span><span class="sxs-lookup"><span data-stu-id="e4d90-146">ms-windows-store://assoc/?Protocol=ms-word</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-147">1 つまたは複数のタグに関連付けられた製品の検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-147">Launches a search for products associated with one or more tags.</span></span> <span data-ttu-id="e4d90-148">タグはコンマで区切る必要があります。</span><span class="sxs-lookup"><span data-stu-id="e4d90-148">Tags should be separated by commas.</span></span>
</td>
<td />
<td>
<p><span data-ttu-id="e4d90-149">ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit</span><span class="sxs-lookup"><span data-stu-id="e4d90-149">ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit</span></span> </p>
<p><span data-ttu-id="e4d90-150">ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit, Camera_Capture_App</span><span class="sxs-lookup"><span data-stu-id="e4d90-150">ms-windows-store://assoc/?Tags=Photos_Rich_Media_Edit, Camera_Capture_App</span></span></p>
</td>
</tr>
<tr>
<td>
<span data-ttu-id="e4d90-151">指定されたクエリの検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-151">Launches a search for the specified query.</span></span> <span data-ttu-id="e4d90-152">クエリ内で空白文字を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4d90-152">Spaces in the query are allowed.</span></span>
</td>
<td />
<td><span data-ttu-id="e4d90-153">ms-windows-store://search/?query=OneNote</span><span class="sxs-lookup"><span data-stu-id="e4d90-153">ms-windows-store://search/?query=OneNote</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-154">カテゴリ内で製品の検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-154">Launches a search for products in a category.</span></span></td>
<td />
<td>
<p><span data-ttu-id="e4d90-155">ms-windows-store://browse/?type=Apps&amp;cat=Productivity</span><span class="sxs-lookup"><span data-stu-id="e4d90-155">ms-windows-store://browse/?type=Apps&amp;cat=Productivity</span></span></p>
<p><span data-ttu-id="e4d90-156">ms-windows-store://browse/?type=Apps&amp;cat=Health+%26+fitness</span><span class="sxs-lookup"><span data-stu-id="e4d90-156">ms-windows-store://browse/?type=Apps&amp;cat=Health+%26+fitness</span></span> </p>
</td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-157">指定した発行元からの製品の検索を起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-157">Launches a search for products from the specified publisher.</span></span> <span data-ttu-id="e4d90-158">名前には空白文字を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="e4d90-158">Spaces in the name are allowed.</span></span>
</td>
<td />
<td><span data-ttu-id="e4d90-159">ms-windows-store://publisher/?name=Microsoft Corporation</span><span class="sxs-lookup"><span data-stu-id="e4d90-159">ms-windows-store://publisher/?name=Microsoft Corporation</span></span>
</td>
</tr>
<tr><td><span data-ttu-id="e4d90-160">ダウンロードと更新プログラムに関するページを起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-160">Launches the downloads and updates page.</span></span></td>
<td />
<td><span data-ttu-id="e4d90-161">ms-windows-store://downloadsandupdates</span><span class="sxs-lookup"><span data-stu-id="e4d90-161">ms-windows-store://downloadsandupdates</span></span> </td>
</tr>
<tr>
<td><span data-ttu-id="e4d90-162">ストアの設定ページを起動します。</span><span class="sxs-lookup"><span data-stu-id="e4d90-162">Launches the Store settings page.</span></span></td>
<td />
<td><span data-ttu-id="e4d90-163">ms-windows-store://settings</span><span class="sxs-lookup"><span data-stu-id="e4d90-163">ms-windows-store://settings</span></span> </td>
</tr>
</table>

 

 
