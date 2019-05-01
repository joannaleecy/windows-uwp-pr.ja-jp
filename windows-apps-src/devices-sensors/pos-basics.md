---
title: POS (店舗販売時点管理) の概要
description: この記事には、PointOfService UWP API の概要に関する情報が含まれています。
ms.date: 06/13/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: f1e58dbf8bae22df0652ada6ff8aafff6d30e8aa
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63817402"
---
# <a name="getting-started-with-point-of-service"></a>POS (店舗販売時点管理) の概要

## <a name="pointofservice-basics"></a>PointOfService の基礎

このセクションには、すべての POS デバイス カテゴリに共通するトピックが含まれています。

|トピック |説明 |
|------|------------|
| [機能の宣言](pos-basics-capability.md)      | **pointOfService** 機能をアプリケーション マニフェストに追加する方法について説明します。  Windows.Devices.PointOfService 名前空間の使用にはこの機能が必要になります。  |
| [デバイスの列挙](pos-basics-enumerating.md)        | システムが利用できるデバイスを照会するために使用するデバイス セレクターを定義し、このセレクターを使用して POS デバイスを列挙する方法について説明します。  |
| [デバイス オブジェクトを作成します。](pos-basics-deviceobject.md)  | 周辺機器の読み取り専用のプロパティにアクセスできるようにする PointOfService デバイス オブジェクトを作成し、排他的使用のために周辺機器を要求する方法について説明します。 |
| [要求と有効にします。 ](pos-basics-claim.md)  | 排他的に使用周辺 PointOfService を予約し、I/O 操作を有効にする方法について説明します。  |
| [周辺機器を他のユーザーと共有](pos-basics-sharing.md) | 複数の Pc が各コンピューターに接続されている専用の周辺機器ではなく、共有の周辺機器に依存する、環境内の他のコンピューターとネットワークまたは接続されている Bluetooth 周辺機器を共有する方法について説明します。
| [PointOfService エンド ツー エンド](pos-get-started.md)  | これは、上記の例を利用する PointOfService 周辺機器と対話する方法のエンド ツー エンド例です。 |
|

## <a name="see-also"></a>関連項目

| トピック   | 説明 |
|:--------|:------------|
| [アプリケーションの配布](../publish/distribute-lob-apps-to-enterprises.md) | 企業のお客様にアプリを配信するためのオプションについて説明します。 |
| [アプリケーションのライフ サイクル](../launch-resume/app-lifecycle.md) | UWP アプリケーションのライフ サイクルと Windows を起動、中断、およびアプリが再開されるときの動作について説明します。 |
| [アプリケーション リソース](../app-resources/index.md) | 作成、パッケージ、およびアプリの文字列、イメージ、およびファイルのリソースを使用する方法について説明します。 |
| [データ バインディング](../data-binding/index.md) | データ バインディングを使用して、アプリの UI にデータを表示する方法について説明します。 |
| [デバイスの列挙](enumerate-devices.md) | 周辺機器を検索する詳細な使用する列挙型の手法について説明します。|
| [適応型アプリケーションのバージョン](../debug-test-perf/version-adaptive-apps.md) | 複数のバージョンの Windows 10 上で実行されるようにアプリを設計する方法をリーンします。|
|


## <a name="sample-code"></a>サンプル コード
+ [バーコード スキャナーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BarcodeScanner)
+ [現金引き出しサンプル]( https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CashDrawer)
+ [ライン サンプルを表示](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LineDisplay)
+ [磁気ストライプ リーダーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/MagneticStripeReader)
+ [POSPrinter サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/PosPrinter)

