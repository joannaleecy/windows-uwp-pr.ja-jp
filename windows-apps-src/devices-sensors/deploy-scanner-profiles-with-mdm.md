---
title: "MDM によるバーコード スキャナー プロファイルの展開"
author: mukin
description: "バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。"
ms.assetid: 99ED3BD8-022C-40C2-9C65-F599186548FE
ms.openlocfilehash: 51d3b90dd7f202fd86285bb3f95c78ded4a8b6d8
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="deploy-barcode-scanner-profiles-with-mdm"></a>MDM によるバーコード スキャナー プロファイルの展開

**注:**  この機能は、Windows 10 Mobile 以降を必要とします。

バーコード スキャナー プロファイルは、MDM サーバーを使って展開できます。 プロファイルを展開するには、[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025) の *OemProfile* を使用して、\\Data\\SharedData\\OEM\\Public\\Profile フォルダーにプロファイルを配置します。 ドライバーの製造元では、これらのスキャナー プロファイルを使用して、API サーフェスを通じて公開されていない設定を構成できます。

Microsoft では、スキャナーのプロファイルやそれらを実装する方法の詳細を定義していません。

## <a name="related-topics"></a>関連トピック
[バーコード スキャナー](barcode-scanner.md)

[EnterpriseExtFileSystem CSP](https://msdn.microsoft.com/library/windows/hardware/mt157025)