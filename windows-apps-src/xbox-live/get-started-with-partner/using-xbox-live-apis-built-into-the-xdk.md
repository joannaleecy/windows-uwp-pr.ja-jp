---
title: XDK に組み込まれている Xbox Live API を使用する
description: Xbox 開発キット (XDK) プロジェクトで、組み込みの Xbox Live API を使用する方法について説明します。
ms.assetid: 539caca3-58bc-49d9-8432-ca8e57755be2
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c762dd8abbbc80948d232610e4123b6e4893936d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598407"
---
# <a name="using-xbox-live-apis-built-into-the-xdk"></a><span data-ttu-id="9ad5a-104">XDK に組み込まれている Xbox Live API を使用する</span><span class="sxs-lookup"><span data-stu-id="9ad5a-104">Using Xbox Live APIs built into the XDK</span></span>

1. <span data-ttu-id="9ad5a-105">Visual Studio でプロジェクトを右クリックし、[参照] を選択します。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-105">Right click on your project in Visual Studio, and choose "References".</span></span>
1. <span data-ttu-id="9ad5a-106">[新しい参照の追加] を選択します。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-106">Choose "Add New Reference"</span></span>
1. <span data-ttu-id="9ad5a-107">左側のパネルで [Durango.<build number>]</span><span class="sxs-lookup"><span data-stu-id="9ad5a-107">Click on "Durango.<build number>"</span></span> <span data-ttu-id="9ad5a-108"> と [拡張機能] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-108">and "Extensions" on the left panel</span></span>
1. <span data-ttu-id="9ad5a-109">中央のパネルで、次のいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-109">In the middle, choose either:</span></span>
- <span data-ttu-id="9ad5a-110">WinRT XSAPI API を使用する場合は、[Xbox Services API] を選択します。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-110">If you want to use the WinRT XSAPI API, choose "Xbox Services API"</span></span>
- <span data-ttu-id="9ad5a-111">C++ XSAPI API を使用する場合は、[Xbox Services API Cpp] を選択します。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-111">If you want to use the C++ XSAPI API, choose "Xbox Services API Cpp"</span></span>
1. <span data-ttu-id="9ad5a-112">[OK] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="9ad5a-112">Click OK</span></span>

<span data-ttu-id="9ad5a-113">注:プリプロセッサの定義とに示すようにライブラリを追加する必要があります手動でビルド システムがプロパティ ファイルをサポートしていない場合 `%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox.Services.API.Cpp\8.0\DesignTime\CommonConfiguration\Neutral\Xbox.Services.API.Cpp.props`</span><span class="sxs-lookup"><span data-stu-id="9ad5a-113">Note: If your build system doesn't support props files, you must manually add the preprocessor definitions and libraries as seen in `%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox.Services.API.Cpp\8.0\DesignTime\CommonConfiguration\Neutral\Xbox.Services.API.Cpp.props`</span></span>
