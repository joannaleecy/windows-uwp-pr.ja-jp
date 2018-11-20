---
title: MDM によるバーコード スキャナー プロファイルの展開
author: PatrickFarley
description: バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。
ms.assetid: 99ED3BD8-022C-40C2-9C65-F599186548FE
ms.author: pafarley
ms.date: 09/26/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: cfd9692620273952483ec7da65a69b643cb5bf4f
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7296957"
---
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a>MDM によるバーコード スキャナー プロファイルの展開

**注:** この機能は、windows 10 Mobile を必要とまたはそれ以降。

バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。 プロファイルを展開するには、[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) の *OemProfile* を使用して、\\Data\\SharedData\\OEM\\Public\\Profile フォルダーにプロファイルを配置します。 ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。

Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。

## <a name="related-topics"></a>関連トピック
- [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025)
- [バーコード スキャナーのデバイスのサポート](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-device-support#barcode-scanner)