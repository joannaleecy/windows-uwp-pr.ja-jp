---
author: TerryWarwick
title: PointOfService デバイス機能
description: PointOfService 機能は、Windows.Devices.PointOfService 名前空間の使用に必要です。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 564c7686cef4815e9ca1bfd0af82c4577852b8a4
ms.sourcegitcommit: 633dd07c3a9a4d1c2421b43c612774c760b4ee58
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/05/2018
ms.locfileid: "1976753"
---
# <a name="pointofservice-device-capability"></a>PointOfService デバイス機能
アプリケーション パッケージのマニフェストで機能を宣言することで、PointOfService API へのアクセスを要求します。Microsoft Visual Studio のマニフェスト デザイナーを使用することで、ほとんどの機能を宣言することができます。または、手動で追加することもできます。  

> [!Important]
> アプリケーション マニフェストで **pointOfService** 機能を宣言しない場合は、Winodws.Devices.PointOfService 名前空間で API を使用しようとすると、**System.UnauthorizedAccessException** エラーが発生します。 

## <a name="declare-capability-using-manifest-designer"></a>マニフェスト デザイナーを使用した機能の宣言

1. **ソリューション エクスプローラー**で、UWP アプリケーションのプロジェクト ノードを展開します。
2. **[Package.appxmanifest]** ファイルをダブルクリックします。  
*マニフェスト ファイルが既に XML コード ビューで開かれている場合は、ファイルを閉じるよう指示するプロンプトが Visual Studio で表示されます。*
3. **[機能]** タブをクリックします。
4. 機能の一覧で **[店舗販売時点管理 (POS)]** の横にあるチェック ボックスをオンにして、POS デバイスの機能を有効にします。


## <a name="declare-capability-manually"></a>手動での機能の宣言

1. **ソリューション エクスプローラー**で、UWP アプリケーションのプロジェクト ノードを展開します。
2. **[Package.appxmanifest]** ファイルを右クリックし、**[コードの表示]** を選択します。
3. PointOfService DeviceCapability 要素をアプリケーション マニフェストの Capabilities セクションに追加します。  

```xml
  <Capabilities>
    <DeviceCapability Name="pointOfService" />
  </Capabilities>
   ```
