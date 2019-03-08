---
title: MDM によるバーコード スキャナー プロファイルの展開
description: バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。
ms.assetid: 99ED3BD8-022C-40C2-9C65-F599186548FE
ms.date: 09/26/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: dbcaa683e2c7a2bb18d88fcba03e10fa951d4459
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57626157"
---
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a><span data-ttu-id="a2415-104">MDM によるバーコード スキャナー プロファイルの展開</span><span class="sxs-lookup"><span data-stu-id="a2415-104">Deploy barcode scanner profiles with MDM</span></span>

<span data-ttu-id="a2415-105">**注**  この機能では Windows 10 Mobile 以降。</span><span class="sxs-lookup"><span data-stu-id="a2415-105">**Note**  This feature requires Windows 10 Mobile or later.</span></span>

<span data-ttu-id="a2415-106">バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。</span><span class="sxs-lookup"><span data-stu-id="a2415-106">Barcode scanner profiles can be deployed with an MDM server.</span></span> <span data-ttu-id="a2415-107">使用して、プロファイルを展開する*OemProfile*で、 [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025)に配置することに、\\データ\\SharedData\\OEM\\パブリック\\プロファイル フォルダー。</span><span class="sxs-lookup"><span data-stu-id="a2415-107">To deploy the profiles, use *OemProfile* in the [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) to place them into the \\Data\\SharedData\\OEM\\Public\\Profile folder.</span></span> <span data-ttu-id="a2415-108">ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。</span><span class="sxs-lookup"><span data-stu-id="a2415-108">These scanner profiles can then be used by driver manufacturers to configure settings that are not exposed through the API surface.</span></span>

<span data-ttu-id="a2415-109">Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。</span><span class="sxs-lookup"><span data-stu-id="a2415-109">Microsoft does not define the specifics of a scanner profile or how to implement them.</span></span>

## <a name="related-topics"></a><span data-ttu-id="a2415-110">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a2415-110">Related topics</span></span>
- [<span data-ttu-id="a2415-111">EnterpriseExtFileSystem CSP</span><span class="sxs-lookup"><span data-stu-id="a2415-111">EnterpriseExtFileSystem CSP</span></span>](https://msdn.microsoft.com/library/windows/hardware/mt157025)
- [<span data-ttu-id="a2415-112">バーコード スキャナのデバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="a2415-112">Barcode scanner device support</span></span>](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-device-support#barcode-scanner)