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
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a>MDM によるバーコード スキャナー プロファイルの展開

**注:**  この機能は、Windows 10 Mobile 以降を必要とします。

バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。 プロファイルを展開するには、[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) の *OemProfile* を使用して、\\Data\\SharedData\\OEM\\Public\\Profile フォルダーにプロファイルを配置します。 ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。

Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。

## <a name="related-topics"></a>関連トピック
- [EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025)
- [バーコード スキャナー デバイスのサポート](https://docs.microsoft.com/en-us/windows/uwp/devices-sensors/pos-device-support#barcode-scanner)