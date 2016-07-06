---
author: msatranjr
title: "Bluetooth アドバタイズ"
description: "このセクションでは、API の AdvertisementWatcher と AdvertisementPublisher を使って、ユニバーサル Windows プラットフォーム (UWP) アプリに Bluetooth 低エネルギー (LE) アドバタイズを統合する方法に関する記事を取り上げています。"
ms.sourcegitcommit: 62e97bdb8feb78981244c54c76a00910a8442532
ms.openlocfilehash: a419ad04fe4f21867f2f1bd1664fbce39a7da792

---

# Bluetooth アドバタイズ

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

** 重要な API ** 

-   [**Windows.Devices.Bluetooth.Advertisement**](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.aspx)

この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリ向けの Bluetooth アドバタイズ (ビーコン) の概要を示します。  

## 概要

開発者がアドバタイズ API を使って実行できる機能には、主に次の 2 つがあります。

-   [アドバタイズ ウォッチャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementwatcher.aspx): 近くのビーコンをリッスンし、ペイロードまたは近接度に基づいてフィルター処理します。  
-   [アドバタイズ パブリッシャー](https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.advertisement.bluetoothleadvertisementpublisher.aspx): 開発者に代わって、Windows のペイロードを定義してアドバタイズします。  

完全なサンプル コードについては、Github の [Bluetooth アドバタイズ サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619990)をご覧ください。



<!--HONumber=Jun16_HO5-->


