---
author: TerryWarwick
title: POS (店舗販売時点管理) の概要
description: この記事には、PointOfService UWP API の概要に関する情報が含まれています。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: a0583adbcef9e45dfe0b2e56e03ce7e0451ac5bb
ms.sourcegitcommit: ce45a2bc5ca6794e97d188166172f58590e2e434
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/06/2018
ms.locfileid: "1983545"
---
# <a name="getting-started-with-point-of-service"></a>POS (店舗販売時点管理) の概要

このセクションには、すべての POS デバイス カテゴリに共通するトピックが含まれています。

|トピック |説明 |
|------|------------|
| [機能の宣言](pos-basics-capability.md)      | **pointOfService** 機能をアプリケーション マニフェストに追加する方法について説明します。  Windows.Devices.PointOfService 名前空間の使用にはこの機能が必要になります。  |
| [デバイスの列挙](pos-basics-enumerating.md)        | システムが利用できるデバイスを照会するために使用するデバイス セレクターを定義し、このセレクターを使用して POS デバイスを列挙する方法について説明します。  |
| [デバイス オブジェクトの作成](pos-basics-deviceobject.md)  | 周辺機器の読み取り専用のプロパティにアクセスできるようにする PointOfService デバイス オブジェクトを作成し、排他的使用のために周辺機器を要求する方法について説明します。 |
| [排他的使用のためのデバイスの要求 ](pos-basics-claim.md)  | PointOfService 要求モデルを使用して排他的使用のために PointOfService 周辺機器を予約し、同じコンピューター上の他のアプリケーションが排他的使用を必要とするときに PointOfService 周辺機器にアクセスできるようにします。  |
|

## <a name="see-also"></a>関連項目
[Windows.Devices.PointOfService の概要](pos-get-started.md)


## <a name="sample-code"></a>サンプル コード
+ [バーコード スキャナーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [キャッシュ ドロワーのサンプル]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [ライン ディスプレイのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [磁気ストライプ リーダーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [POS プリンターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

