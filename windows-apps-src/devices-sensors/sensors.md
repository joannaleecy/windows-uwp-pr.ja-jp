---
author: muhsinking
ms.assetid: 415F4107-0612-4235-9722-0F5E4E26F957
title: センサー
description: センサーは、デバイスとその周囲の実際の世界の関係をアプリに通知します。 つまり、デバイスの方角や向き、動きをアプリに伝えることができます。
ms.author: mukin
ms.date: 06/06/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0e05c18bd2c8fa2ddd7d6a9bc8e474d02f27a93e
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7304834"
---
# <a name="sensors"></a>センサー



センサーは、デバイスとその周囲の実際の世界の関係をアプリに通知します。 つまり、デバイスの方角や向き、動きをアプリに伝えることができます。 こうしたセンサーは、デバイスのモーションを使って画面上に文字を配置すること、コックピット内のハンドルとしてデバイスのユーザー操作をシミュレートすることなど、ユニークな入力形態を提供することにより、ゲーム、拡張現実アプリ、ユーティリィティ アプリをより有用かつ対話的にするために役立ちます。

一般に、アプリがセンサーのみに依存するかどうか、またはセンサーにより追加制御機構が提供されているかどうかを最初に特定しておきます。 たとえば、仮想ハンドルとしてデバイスを使うドライビング ゲームで、代わりに画面上の GUI を通じた制御が可能な場合が考えられます。この場合、システムでセンサーが使用できるかどうかにかかわらずアプリが動作します。 それに対して、ビー玉傾斜迷路ゲームでは、適切なセンサーを備えるシステムでのみ動作するようにコーディングされる場合も考えられます。 センサーに完全に依存するかどうかについて、戦略的な選択を行う必要があります。 マウス/タッチ制御スキームでは、没入感とより微細な制御性が両立しないことに注意してください。

| トピック                                                       | 説明  |
|-------------------------------------------------------------|--------------|
| [センサーの調整](calibrate-sensors.md)                   | デバイスの磁力計 (コンパス、傾斜計、方位センサー) に基づくセンサーは、環境の要因に応じて調整が必要になることがあります。 [<strong>MagnetometerAccuracy</strong>](https://msdn.microsoft.com/library/windows/apps/Dn297552) 列挙値は、デバイスの調整が必要になる場合の対応策を決めるのに役立ちます。 |
| [センサーの向き](sensor-orientation.md)                 | [<strong>OrientationSensor</strong>](https://msdn.microsoft.com/library/windows/apps/BR206371) クラスのセンサー データは、基準軸によって定義されます。 これらの軸はデバイスの横長の向きで定義され、ユーザーがデバイスの向きを変えると、デバイスと共に回転します。 |
| [加速度計の使用](use-the-accelerometer.md)           | 加速度計を使ってユーザーの動きに応答する方法を説明します。 |
| [コンパスの使用](use-the-compass.md)                       | コンパスを使って現在の方位を検出する方法を説明します。 |
| [ジャイロメーターの使用](use-the-gyrometer.md)                   | ジャイロメーターを使ってユーザーの動きの変化を検出する方法を説明します。 | 
| [傾斜計の使用](use-the-inclinometer.md)             | 傾斜計を使ってピッチ、ロール、ヨーを検出する方法を説明します。 |
| [光センサーの使用](use-the-light-sensor.md)             | 環境光センサーを使って環境光の変化を検出する方法を説明します。 |
| [方位センサーの使用](use-the-orientation-sensor.md) | 方位センサーを使ってデバイスの向きを判断する方法について説明します。|

## <a name="sensor-batching"></a>センサーの一括処理

一部のセンサーは、一括処理の概念をサポートします。 このサポートは、利用できる個々のセンサーによって異なります。 センサーが一括処理を実装すると、指定された期間のいくつかのポイントでデータを収集してから、そのすべてのデータを一度に転送します。 これは、センサーによる読み取りと同時に検出結果が報告されるといった通常の動作とは異なります。 次の図について考えてみましょう。この図では、データがどのように収集され、配信されるかが示されています。最初に示されているのが通常の配信で、次に一括処理による配信が示されています。

![センサーの一括処理による収集](images/batchsample.png)

センサーで一括処理を行う主な利点は、バッテリの寿命が延長されることです。 データを直ちに送信しない場合は、プロセッサの電力が節約され、データをすぐに処理する必要がなくなります。 システムの一部は、必要とされるまでスリープ状態になる場合があり、消費電力の大幅な削減につながります。

待機時間を調整すると、一括処理によるデータをセンサーが送信する頻度が影響を受けます。 たとえば、[**Accelerometer**](https://msdn.microsoft.com/library/windows/apps/BR225687) センサーには [**ReportLatency**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.reportlatency) プロパティがあります。 このプロパティをアプリケーション用に設定すると、センサーは指定された時間の経過後にデータを送信します。 [**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.reportinterval) プロパティを設定することで、指定の待機時間に対して蓄積されるデータ量を制御できます。

待機時間の設定について注意事項がいくつかあります。 最初の注意事項は、各センサーの [**MaxBatchSize**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.maxbatchsize.aspx) プロパティによるサポートは、センサー自体に基づいて実行されるという点です。 このプロパティは、強制的にイベントが送信されるまでにセンサーがキャッシュできるイベントの数を表します。 **MaxBatchSize** に [**ReportInterval**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.reportinterval) を乗算すると、[**ReportLatency**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.reportlatency) の最大値が決まります。 この値よりも高い値を指定した場合は、データが失われないようにするために、最大待機時間が使われます。 また、複数のアプリケーションのそれぞれで、目的の待機時間を設定できます。 ただし、すべてのアプリケーションのニーズに対応するために、最短の待機時間が使われます。 このため、アプリケーションで設定した待機時間が実際の待機時間とは一致しない場合があります。

センサーで一括処理のレポートを使う場合は、[**GetCurrentReading**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.accelerometer.getcurrentreading) を呼び出すことによって、現在の一括処理のデータが消去され、新しい待機時間が開始されます。

## <a name="accelerometer"></a>加速度計

[**Accelerometer**](https://msdn.microsoft.com/library/windows/apps/BR225687) センサーは、デバイスの X、Y、Z 軸に沿った重力加速度値を測定するもので、簡単なモーション ベースのアプリに適しています。 重力加速度値には、重力による加速度が含まれることに注意してください。 デバイスがテーブルの上にあり [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) が **FaceUp** である場合、加速度計の読み取り値は Z 軸で -1 G になります。 したがって、加速度計では必ずしも座標での加速度 (速度の変化率) のみを測定するわけではありません。 加速度計を使う場合、重力によるベクターと、モーションによる直線加速度ベクターとを区別する必要があります。 静止するデバイスでは重力ベクターを 1 に正規化する必要があることに注意してください。

次に、図でこれを説明します。

-   V1 = ベクター 1 = 重力
-   V2 = ベクター 2 = デバイス シャーシの -Z 軸 (画面の背面方向)
-   Θi = 傾斜角 (傾き) = デバイス シャーシと重力ベクターの Z 軸間の角度

![加速度計](images/accelerometer1.png)![加速度計の測定](images/accelerometer2.png)

加速度計センサーを使うアプリとしては、デバイスを傾けた方向 (重力ベクター) に画面のビー玉が転がるゲームなどが考えられます。 このタイプの機能は、[**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/BR225766) の機能を厳密に反映したもので、ピッチとロールの組み合わせによりセンサーを扱うこともできます。 この処理は、加速度計の重力ベクターを使い、デバイスの傾きに対して簡単に数学的に操作されたベクターを提供することにより、ある程度簡素化されます。 もう 1 つの例としては、ユーザーが空中でデバイスをすばやく動かしたときに (直線加速度ベクター)、むちを打つ音を出すアプリが挙げられます。

実装例については、[加速度計センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Accelerometer)をご覧ください。

## <a name="activity-sensor"></a>アクティビティ センサー

[**Activity**](https://msdn.microsoft.com/library/windows/apps/Dn785096) センサーは、センサーに取り付けられたデバイスの現在の状態を特定します。 このセンサーはフィットネス アプリによく使用されます。デバイスを携帯するユーザーがランニングやウォーキングを行う場合に追跡します。 このセンサー API で検出できるアクティビティの一覧については、[**ActivityType**](https://msdn.microsoft.com/library/windows/apps/Dn785128) をご覧ください。

実装例については、[アクティビティ センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ActivitySensor)をご覧ください。

## <a name="altimeter"></a>高度計

[**Altimeter**](https://msdn.microsoft.com/library/windows/apps/Dn858893) センサーは、センサーの高度を示す値を返します。 これにより、海面からの高さの変化をメートルで追跡できます。 これを使う可能性のあるアプリの 1 例としてランニング用アプリがあります。消費カロリーの計算時に高さの変化を追跡します。 この場合、このセンサー データを [**Activity**](https://msdn.microsoft.com/library/windows/apps/Dn785096) センサーと組み合わせて、より正確な追跡情報を提供できます。

実装例については、[高度計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Altimeter)をご覧ください。

## <a name="barometer"></a>気圧計

[**Barometer**](https://msdn.microsoft.com/library/windows/apps/Dn872405) センサーを使用すると、アプリで気圧の値を取得できます。 天気予報のアプリはこの情報を使用して、現在の気圧を提供できます。 これを利用して、詳細な情報を提供し、天気変化の可能性を予想できます。

実装例については、[気圧計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Barometer)をご覧ください。

## <a name="compass"></a>コンパス

[**Compass**](https://msdn.microsoft.com/library/windows/apps/BR225705) センサーは、地球の水平面に基づいて、磁北を基準にした 2 次元の方位を返します。 コンパス センサーは、特定のデバイスの向きを特定するため、または 3 次元空間での何らかの要素を表すために使用しないでください。 地理的な特徴により、方位に自然なずれが生じる場合があります。したがって、一部のシステムでは、[**HeadingMagneticNorth**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.compassreading.headingmagneticnorth.aspx) と [**HeadingTrueNorth**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.compassreading.headingtruenorth.aspx) を共にサポートしています。 それぞれのアプリでいずれが好ましいかを考えてください。ただし、すべてのシステムで真北値がレポートされるとは限らないことに注意してください。 ジャイロメーターおよび磁力計 (磁気の強度を測定するデバイス) センサーは、コンパスの方位を生成するためにデータを組み合わせます。これは最終的に、データを安定させる効果があります (電気的なシステム コンポーネントのために、磁場の強さは非常に不安定です)。

![磁北を基準にしたコンパスの読み取り値](images/compass.png)

羅針図の表示、地図のナビゲートを行うアプリは通常、コンパス センサーを使います。

実装例については、[コンパスのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Compass)をご覧ください。

## <a name="gyrometer"></a>ジャイロメーター

[**Gyrometer**](https://msdn.microsoft.com/library/windows/apps/BR225718) センサーは、X 軸、Y 軸、Z 軸に沿った角速度を測定します。 これは、デバイスの向きにかかわらず、さまざまな速度でのデバイスの回転を検出する簡単なモーション ベースのアプリで非常に便利です。 ジャイロメーターでは、データのノイズ、または 1 つ以上の軸に沿った一定のバイアスの影響を受ける場合があります。 ジャイロメーターがバイアスの影響を受けているかどうかを判断するために、加速度計を照会してデバイスが移動しているかどうかを確認する必要があります。その結果に応じてアプリで補正が必要になります。

![ピッチ、ロール、ヨーに対応するジャイロメーター](images/gyrometer.png)

ジャイロメーター センサーを使うアプリの例としては、デバイスの急な回転の動きに基づいてルーレットのホイールを回転させるゲームなどが考えられます。

実装例については、[ジャイロメーターのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Gyrometer)をご覧ください。

## <a name="inclinometer"></a>傾斜計

[**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/BR225766) センサーは、デバイスのヨー、ピッチ、ロール値を示すもので、空間内でデバイスがどのように位置しているかを検出するアプリに最適な機能を提供します。 ピッチとロールは、加速度計の重力ベクターを読み取り、ジャイロメーターからのデータを統合することにより算出されます。 ヨーは、磁力計とジャイロメーターのデータから確定します (コンパスの方位と同様です)。 傾斜計は、理解しやすい方法で詳細な方向データを提供します。 デバイスの方向が必要であっても、センサー データを操作する必要がない場合は、傾斜計を使用します。

![ピッチ、ロール、ヨーのデータを提供する傾斜計](images/inclinometer.png)

デバイスの方向に合わせてビューを変更するアプリでは、傾斜計センサーを使うことができます。 また、デバイスのヨー、ピッチ、ロールに合わせて飛行機を表示するアプリでも、傾斜計の読み取り値を使います。

実装例について、傾斜計のサンプルをご覧ください。[https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Inclinometer](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Inclinometer)します。

## <a name="light-sensor"></a>光センサー

[**Light**](https://msdn.microsoft.com/library/windows/apps/BR225790) センサーは、センサー周囲の環境光を測定することができます。 これにより、アプリはデバイス周囲の光源設定が変化すると測定を行います。 たとえば、スレート デバイスを持つユーザーが屋内から晴れた屋外に出たとします。 優れたアプリはこの値を使用し、レンダリングされるフォントと背景のコントラストを強めることができます。 それにより、明るい屋外設定で文字が変わらず読みやすくなります。

実装例については、[光センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/LightSensor)をご覧ください。

## <a name="orientation-sensor"></a>方位センサー

デバイスの方位は、四元数と回転マトリックスの両方で表されます。 [**OrientationSensor**](https://msdn.microsoft.com/library/windows/apps/BR206371) では、空間内で絶対方位を基準にしてデバイスがどのように位置しているかを高い精度で決定できます。 **OrientationSensor** のデータは、加速度計、ジャイロメーター、磁力計から取得されます。 このため、傾斜計とコンパスの両センサーの値を四元数から取得できます。 四元数および回転マトリックスは高度な数学的演算に適しており、グラフィカル プログラミングでよく使われます。 複雑な演算を使うアプリでは、多数の変換が四元数および回転マトリックスに基づくために、方位センサーを選択してください。

![方位センサーのデータ](images/orientation-sensor.png)

方位センサーは、デバイスの背面の方向に基づいて、周囲にオーバーレイして描画する高度な拡張現実アプリでよく使われます。

実装例については、[方位センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/OrientationSensor)をご覧ください。

## <a name="pedometer"></a>万歩計

[**Pedometer**](https://msdn.microsoft.com/library/windows/apps/Dn878203) は、接続したデバイスを持ち運ぶユーザーが歩いた歩数を記録します。 このセンサーを構成すると、任意の時間の歩数を記録できます。 いくつかのフィットネス アプリでは、ユーザーがさまざまなゴールを設定してそれを達成できるように、歩いた歩数を記録します。 この情報を収集して保存すると、時間の経過と共に進み具合を表示することができます。

実装例については、[万歩計のサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Pedometer)をご覧ください。

## <a name="proximity-sensor"></a>近接センサー

[**Proximity**](https://msdn.microsoft.com/library/windows/apps/Dn872427) センサーを使用すると、このセンサーで物体を検出できるかどうかを示すことができます。 デバイスの範囲内に物体があるかどうかを特定するだけでなく、近接センサーは、検出物体までの距離を特定することもできます。 これを使用する可能性のある 1 例として、ユーザーが指定範囲内に入ったら、スリープ状態から復帰するアプリケーションがあります。 このデバイスは、近接センサーが物体を検出するまで低電力のスリープ状態で、その後、よりアクティブな状態に移行します。

実装例については、[近接センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/ProximitySensor)をご覧ください。

## <a name="simple-orientation"></a>簡易方位

[**SimpleOrientationSensor**](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.simpleorientationsensor.aspx) は、指定のデバイスの現在の象限方位 (表向きまたは裏向き) を検出します。 6 つの可能な [**SimpleOrientation**](https://msdn.microsoft.com/library/windows/apps/BR206399) の状態があります (**NotRotated**、**Rotated90**、**Rotated180**、**Rotated270**、**FaceUp**、**FaceDown**)。

デバイスが水平または垂直のいずれで保持されているかに基づいて表示を変更するリーダー アプリでは、デバイスがどのように保持されているかを決定するために SimpleOrientationSensor からの値を使います。

実装例については、[簡易方位センサーのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/SimpleOrientationSensor)をご覧ください。
