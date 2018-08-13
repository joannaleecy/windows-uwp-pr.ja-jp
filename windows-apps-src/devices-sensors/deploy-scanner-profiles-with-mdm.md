---
title: MDM によるバーコード スキャナー プロファイルの展開
author: PatrickFarley
description: バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。
ms.assetid: 99ED3BD8-022C-40C2-9C65-F599186548FE
ms.author: pafarley
ms.date: 09/26/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: ef7f1029573d2ff98e744ceb44b108a67a7c0d0b
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1018085"
---
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a><span data-ttu-id="08878-104">MDM によるバーコード スキャナー プロファイルの展開</span><span class="sxs-lookup"><span data-stu-id="08878-104">Deploy barcode scanner profiles with MDM</span></span>

<span data-ttu-id="08878-105">**注:**  この機能は、Windows 10 Mobile 以降を必要とします。</span><span class="sxs-lookup"><span data-stu-id="08878-105">**Note**  This feature requires Windows 10 Mobile or later.</span></span>

<span data-ttu-id="08878-106">バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。</span><span class="sxs-lookup"><span data-stu-id="08878-106">Barcode scanner profiles can be deployed with an MDM server.</span></span> <span data-ttu-id="08878-107">プロファイルを展開するには、[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) の *OemProfile* を使用して、\\Data\\SharedData\\OEM\\Public\\Profile フォルダーにプロファイルを配置します。</span><span class="sxs-lookup"><span data-stu-id="08878-107">To deploy the profiles, use *OemProfile* in the [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) to place them into the \\Data\\SharedData\\OEM\\Public\\Profile folder.</span></span> <span data-ttu-id="08878-108">ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。</span><span class="sxs-lookup"><span data-stu-id="08878-108">These scanner profiles can then be used by driver manufacturers to configure settings that are not exposed through the API surface.</span></span>

<span data-ttu-id="08878-109">Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。</span><span class="sxs-lookup"><span data-stu-id="08878-109">Microsoft does not define the specifics of a scanner profile or how to implement them.</span></span>

## <a name="related-topics"></a><span data-ttu-id="08878-110">関連トピック</span><span class="sxs-lookup"><span data-stu-id="08878-110">Related topics</span></span>
- [<span data-ttu-id="08878-111">EnterpriseExtFileSystem CSP</span><span class="sxs-lookup"><span data-stu-id="08878-111">EnterpriseExtFileSystem CSP</span></span>](https://msdn.microsoft.com/library/windows/hardware/mt157025)
- [<span data-ttu-id="08878-112">バーコード スキャナー デバイスのサポート</span><span class="sxs-lookup"><span data-stu-id="08878-112">Barcode scanner device support</span></span>](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-device-support#barcode-scanner)