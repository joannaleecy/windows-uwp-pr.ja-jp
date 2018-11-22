---
author: TerryWarwick
title: POS (店舗販売時点管理) の概要
description: この記事には、PointOfService UWP API の概要に関する情報が含まれています。
ms.author: jken
ms.date: 06/13/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 46dd1f615e42f6e89ee9a92cb980299e9a0e5205
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7580672"
---
# <a name="getting-started-with-point-of-service"></a>POS (店舗販売時点管理) の概要

## <a name="pointofservice-basics"></a>PointOfService の基本

このセクションには、すべての POS デバイス カテゴリに共通するトピックが含まれています。

|トピック |説明 |
|------|------------|
| [機能の宣言](pos-basics-capability.md)      | **pointOfService** 機能をアプリケーション マニフェストに追加する方法について説明します。  Windows.Devices.PointOfService 名前空間の使用にはこの機能が必要になります。  |
| [デバイスの列挙](pos-basics-enumerating.md)        | システムが利用できるデバイスを照会するために使用するデバイス セレクターを定義し、このセレクターを使用して POS デバイスを列挙する方法について説明します。  |
| [デバイス オブジェクトの作成](pos-basics-deviceobject.md)  | 周辺機器の読み取り専用のプロパティにアクセスできるようにする PointOfService デバイス オブジェクトを作成し、排他的使用のために周辺機器を要求する方法について説明します。 |
| [要求と有効化 ](pos-basics-claim.md)  | PointOfService 排他的使用の周辺機器を予約し、I/O 操作に対して有効にする方法について説明します。  |
| [周辺機器の共有](pos-basics-sharing.md) | ネットワークまたは Bluetooth 接続されている周辺機器を複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存している環境では、他のコンピューターと共有する方法について説明します。
| [PointOfService エンド ツー エンド](pos-get-started.md)  | これは、上記の例を使用して PointOfService 周辺機器を操作する方法のエンド ツー エンド例を示します。 |
|

## <a name="see-also"></a>関連項目

| トピック   | 説明 |
|:--------|:------------|
| [アプリケーションの配布](../publish/distribute-lob-apps-to-enterprises.md) | 企業のお客様にアプリを配布するためのオプションについて説明します。 |
| [アプリケーションのライフ サイクル](../launch-resume/app-lifecycle.md) | UWP アプリケーションのライフ サイクルと、Windows が起動、中断、およびアプリを再開するときの動作について説明します。 |
| [アプリケーション リソース](../app-resources/index.md) | パッケージを作成して、アプリの文字列、イメージ、およびファイル リソースを利用する方法について説明します。 |
| [データ バインディング](../data-binding/index.md) | データ バインディングを使って、アプリの UI でデータを表示する方法について説明します。 |
| [デバイスの列挙](enumerate-devices.md) | 周辺機器を検索する高度な使用列挙手法について説明します。|
| [バージョン アダプティブ アプリケーション](../debug-test-perf/version-adaptive-apps.md) | 複数のバージョンの Windows 10 で実行されるようにアプリを設計する方法を薄きます。|
|


## <a name="sample-code"></a>サンプル コード
+ [バーコード スキャナーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [キャッシュ ドロワーのサンプル]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [ライン ディスプレイのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [磁気ストライプ リーダーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [POS プリンターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

