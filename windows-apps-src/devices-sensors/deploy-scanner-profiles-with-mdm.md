---
title: "MDM によるバーコード スキャナー プロファイルの展開"
author: PatrickFarley
description: "バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。"
ms.assetid: 99ED3BD8-022C-40C2-9C65-F599186548FE
ms.openlocfilehash: a63a09e64b6e2b935963a3f49ed7cbc6b82bdcef
ms.sourcegitcommit: d2ec178103f49b198da2ee486f1681e38dcc8e7b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/28/2017
---
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a><span data-ttu-id="2cbba-103">MDM によるバーコード スキャナー プロファイルの展開</span><span class="sxs-lookup"><span data-stu-id="2cbba-103">Deploy barcode scanner profiles with MDM</span></span>

<span data-ttu-id="2cbba-104">**注:**  この機能は、Windows 10 Mobile 以降を必要とします。</span><span class="sxs-lookup"><span data-stu-id="2cbba-104">**Note**  This feature requires Windows 10 Mobile or later.</span></span>

<span data-ttu-id="2cbba-105">バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。</span><span class="sxs-lookup"><span data-stu-id="2cbba-105">Barcode scanner profiles can be deployed with an MDM server.</span></span> <span data-ttu-id="2cbba-106">プロファイルを展開するには、[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) の *OemProfile* を使用して、\\Data\\SharedData\\OEM\\Public\\Profile フォルダーにプロファイルを配置します。</span><span class="sxs-lookup"><span data-stu-id="2cbba-106">To deploy the profiles, use *OemProfile* in the [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) to place them into the \\Data\\SharedData\\OEM\\Public\\Profile folder.</span></span> <span data-ttu-id="2cbba-107">ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。</span><span class="sxs-lookup"><span data-stu-id="2cbba-107">These scanner profiles can then be used by driver manufacturers to configure settings that are not exposed through the API surface.</span></span>

<span data-ttu-id="2cbba-108">Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。</span><span class="sxs-lookup"><span data-stu-id="2cbba-108">Microsoft does not define the specifics of a scanner profile or how to implement them.</span></span>

## <a name="related-topics"></a><span data-ttu-id="2cbba-109">関連トピック</span><span class="sxs-lookup"><span data-stu-id="2cbba-109">Related topics</span></span>
[<span data-ttu-id="2cbba-110">バーコード スキャナー</span><span class="sxs-lookup"><span data-stu-id="2cbba-110">Barcode Scanner</span></span>](barcode-scanner.md)

[<span data-ttu-id="2cbba-111">EnterpriseExtFileSystem CSP</span><span class="sxs-lookup"><span data-stu-id="2cbba-111">EnterpriseExtFileSystem CSP</span></span>](https://msdn.microsoft.com/library/windows/hardware/mt157025)