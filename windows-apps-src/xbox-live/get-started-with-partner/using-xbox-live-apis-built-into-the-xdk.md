---
title: XDK に組み込まれている Xbox Live API を使用する
author: KevinAsgari
description: Xbox 開発キット (XDK) プロジェクトで、組み込みの Xbox Live API を使用する方法について説明します。
ms.assetid: 539caca3-58bc-49d9-8432-ca8e57755be2
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 527a62af7ca31a401da47eb10e59c1593f62e433
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4055679"
---
# <a name="using-xbox-live-apis-built-into-the-xdk"></a><span data-ttu-id="d7e56-104">XDK に組み込まれている Xbox Live API を使用する</span><span class="sxs-lookup"><span data-stu-id="d7e56-104">Using Xbox Live APIs built into the XDK</span></span>

1. <span data-ttu-id="d7e56-105">Visual Studio でプロジェクトを右クリックし、[参照] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d7e56-105">Right click on your project in Visual Studio, and choose "References".</span></span>
1. <span data-ttu-id="d7e56-106">[新しい参照の追加] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d7e56-106">Choose "Add New Reference"</span></span>
1. <span data-ttu-id="d7e56-107">左側のパネルで [Durango.<build number>]</span><span class="sxs-lookup"><span data-stu-id="d7e56-107">Click on "Durango.<build number>"</span></span> <span data-ttu-id="d7e56-108"> と [拡張機能] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d7e56-108">and "Extensions" on the left panel</span></span>
1. <span data-ttu-id="d7e56-109">中央のパネルで、次のいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="d7e56-109">In the middle, choose either:</span></span>
- <span data-ttu-id="d7e56-110">WinRT XSAPI API を使用する場合は、[Xbox Services API] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d7e56-110">If you want to use the WinRT XSAPI API, choose "Xbox Services API"</span></span>
- <span data-ttu-id="d7e56-111">C++ XSAPI API を使用する場合は、[Xbox Services API Cpp] を選択します。</span><span class="sxs-lookup"><span data-stu-id="d7e56-111">If you want to use the C++ XSAPI API, choose "Xbox Services API Cpp"</span></span>
1. <span data-ttu-id="d7e56-112">[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d7e56-112">Click OK</span></span>

<span data-ttu-id="d7e56-113">注: ビルド システムが props ファイルをサポートしていない場合は、次に示すように、プリプロセッサの定義とライブラリを手動で追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7e56-113">Note: If your build system doesn't support props files, you must manually add the preprocessor definitions and libraries as seen in</span></span>
`%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox.Services.API.Cpp\8.0\DesignTime\CommonConfiguration\Neutral\Xbox.Services.API.Cpp.props`
