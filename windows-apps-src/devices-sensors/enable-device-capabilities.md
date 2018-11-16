---
author: muhsinking
ms.assetid: 949D1CE0-DD7D-420E-904D-758FADEBE85A
title: デバイス機能を有効にする
description: このチュートリアルでは、Microsoft Visual Studio のデバイス機能の宣言方法について説明します。 カメラ、マイク、位置センサー、その他のデバイスをアプリで使うことができるようにします。
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a7250c41795373b089f7a4c76b603c169b1e4dc3
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6975312"
---
# <a name="enable-device-capabilities"></a>デバイス機能を有効にする



このチュートリアルでは、Microsoft Visual Studio のデバイス機能の宣言方法について説明します。 カメラ、マイク、位置センサー、その他のデバイスをアプリで使うことができるようにします。

## <a name="specify-the-device-capabilities-your-app-will-use"></a>アプリで使うデバイス機能を指定する


Windows アプリでは、特定の種類のデバイスを使う場合にアプリ パッケージ マニフェストに指定する必要があります。 Visual Studio では、ほとんどの機能を[マニフェスト デザイナー](https://msdn.microsoft.com/library/windows/apps/xaml/br230259.aspx)で宣言できます。また、「[パッケージ マニフェストでデバイス機能を (手動で) 指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)」で説明しているように、機能を手動で追加することもできます。 このチュートリアルでは、マニフェスト デザイナーを使っていることを前提としています。

**注:** プリンター、スキャナー、センサーなどのデバイスの種類によっては、アプリ パッケージ マニフェストで宣言する必要はありません。

-   Visual Studio のソリューション エクスプローラーで、パッケージ マニフェスト ファイル **Package.appxmanifest** をダブルクリックします。
-   **[機能]** タブを開きます。
-   アプリで使うデバイス機能を選びます。 マニフェスト デザイナーに目的の機能が表示されない場合は、手動で追加します。 詳しくは、「[パッケージ マニフェストでデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263092)」をご覧ください。

| デバイス機能 | マニフェスト デザイナー | 説明 |
|-------------------|-------------------|-------------|    
| AllJoyn | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | ネットワーク上の AllJoyn 対応のアプリやデバイスは、相互に検出を行い、対話することができます。 [**Windows.Devices.AllJoyn**](https://msdn.microsoft.com/library/windows/apps/Dn894971) 名前空間の API にアクセスするすべてのアプリは、この機能を使う必要があります。 |
| ブロックされたチャット メッセージ | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリは、スパム フィルターによってブロックされている SMS メッセージや MMS メッセージを読み取ることができます。 |
| チャット メッセージ アクセス | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリはテキスト メッセージの読み取りと削除を実行できます。 また、アプリはチャット メッセージをシステム データ ストアに保存できます。 |
| コード生成 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリはコードを動的に生成することができます。 |
| エンタープライズ認証 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | この機能には Microsoft Store ポリシーが適用されます。 ドメイン資格情報を必要とする企業イントラネットのリソースに接続する機能を提供します。 通常、この機能はほとんどのアプリで必要ありません。 | 
| インターネット (クライアント) | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | インターネットや、公共の場所のネットワーク (空港、喫茶店など) への出力方向のアクセスを提供します。 たとえば、ユーザーがパブリックとして指定したイントラネット ネットワークなどです。 インターネットにアクセスする必要があるほとんどのアプリは、この機能を使います。 |
| インターネット (クライアント &amp; サーバー) | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | インターネットや、公共の場所のネットワーク (空港、喫茶店など) への入力方向と出力方向のアクセスを提供します。 この機能は、**インターネット (クライアント)** のスーパーセットです。 この機能が有効な場合は、**インターネット (クライアント)** を有効にする必要はありません。 重要なポートへの入力方向のアクセスは常にブロックされます。 |
| 位置情報| ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | 現在の位置情報にアクセスできるようにします。 これは PC 内の GPS センサーのような専用ハードウェアから取得されるか、利用可能なネットワーク情報から導き出されます。 | 
| マイク | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | マイクのオーディオ フィードにアクセスできるようにします。 これによって、アプリは接続されたマイクからオーディオを録音できます。 | 
| 音楽ライブラリ | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | ローカル PC と**ホームグループ**の PC で**音楽ライブラリ**のファイルを追加、変更、削除する機能を提供します。 | 
| 3D オブジェクト | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | ユーザーの **3D オブジェクト**へのプログラムによるアクセスを提供します。これによって、ユーザーの操作なしで、ライブラリ内のすべてのファイルを列挙してそれらのファイルにアクセスできます。 通常、この機能は、**3D オブジェクト** ライブラリ全体にアクセスする必要がある 3D アプリやゲームで使用されます。 | 
| 通話 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリは、デバイスのすべての電話回線にアクセスし、次の機能を実行できます。ユーザーに確認を求めずに、電話での通話を実行してシステムのダイヤラーを表示します。電話回線に関連するメタデータへアクセスします。電話回線に関連するトリガーへアクセスします。 ユーザーが選んだスパム フィルター アプリで、禁止一覧と呼び出し元の情報を設定し、確認することができます。 | 
| 画像ライブラリ | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | ローカル PC と**ホームグループ**の PC で**画像ライブラリ**のファイルを追加、変更、削除する機能を提供します。 | 
| POS (店舗販売時点管理) | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | POS 周辺機器へのアクセスを提供します。 [**Windows.Devices.PointOfService**](https://docs.microsoft.com/uwp/api/Windows.Devices.PointOfService) 名前空間の API にアクセスする場合は、この機能が必要になります。 | 
| プライベート ネットワーク (クライアント &amp; サーバー) | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | 認証済みドメイン コントローラーを備えたイントラネット ネットワーク、またはユーザーがホーム ネットワークや社内ネットワークのどちらかに指定したイントラネット ネットワークへの入力方向と出力方向のアクセスを提供します。 重要なポートへの入力方向のアクセスは常にブロックされます。 | 
| 近接通信 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | 近距離通信 (NFC) を使って PC の近くにあるデバイスに接続する機能を提供します。 近距離近接通信は、近くのデバイスのアプリへのファイルの送信やアプリとの通信に使用できます。 | 
| リムーバブル記憶域 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | リムーバブル記憶装置においてファイルの追加、変更、削除を行う機能を提供します。 アプリは、**ファイルの種類の関連付け**の宣言でマニフェストに定義されたリムーバブル記憶域内のファイルの種類にのみアクセスできます。 アプリは、**ホームグループ** PC 上のリムーバブル記憶域にはアクセスできません。 | 
| 共有ユーザー証明書 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | この機能には Microsoft Store ポリシーが適用されます。 ユーザー ID の確認のためにソフトウェア証明書とハードウェア証明書 (スマート カード証明書など) にアクセスする機能を提供します。 関連する API が実行時に呼び出されると、ユーザーは、カードの挿入や証明書の選択などのアクションを実行する必要があります。 **Certificates** 宣言を介してアプリにプライベート証明書を追加する場合、この機能は必要ありません。 | 
| ユーザー アカウント情報 | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリはユーザーの名前と画像にアクセスできるようになります。 [**Windows.System.UserProfile**](https://msdn.microsoft.com/library/windows/apps/BR241881) 名前空間の一部の API にアクセスする場合は、この機能が必要になります。 | 
| ビデオ ライブラリ | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | ローカル PC と**ホームグループ**の PC で**ビデオ ライブラリ**のファイルを追加、変更、削除する機能を提供します。 | 
| VOIP 呼び出し | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | アプリで [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) 名前空間の VOIP 呼び出し API にアクセスできます。 | 
| Web カメラ | ![マニフェスト デザイナーで利用できます](images/ap-tools.png) | 組み込みのカメラや接続されている Web カメラのビデオ フィードにアクセスできるようにします。 これによって、アプリはスナップショットやムービーをキャプチャできます。 | 
| USB | | カスタム USB デバイスにアクセスできるようにします。 この機能を使うには、子要素が必要です。 Windows Phone では、この機能はサポートされていません。 | 
| ヒューマン インターフェイス デバイス (HID) | | ヒューマン インターフェイス デバイス (HID) にアクセスできるようにします。 この機能を使うには、子要素が必要です。 詳しくは、「[HID のデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263091)」をご覧ください。 | 
| Bluetooth GATT | | プライマリ サービス、含まれているサービス、特性、記述子のコレクションを介して Bluetooth LE devices にアクセスできるようにします。 この機能を使うには、子要素が必要です。 詳しくは、「[Bluetooth のデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263090)」をご覧ください。 | 
| Bluetooth RFCOMM |  | Basic Rate/Extended Data Rate (BR/EDR) トランスポートをサポートする API にアクセスできるようにし、UWP アプリが Serial Port Profile (SPP) を実装するデバイスにアクセスできるようにします。 この機能を使うには、子要素が必要です。 詳細については、「[Bluetooth のデバイス機能を指定する方法](https://msdn.microsoft.com/library/windows/apps/Dn263090)」を参照してください。 |

## <a name="use-the-windows-runtime-api-for-communicating-with-your-device"></a>デバイスとの通信に Windows ランタイム API を使用する

次の表では、上記の機能の一部と Windows ランタイム API を関連付けています。

| デバイス機能        | API             | 
|--------------------------|-----------------|
| AllJoyn                  | [**Windows.Devices.AllJoyn**](https://msdn.microsoft.com/library/windows/apps/Dn894971) | 
| ブロックされたチャット メッセージ    | [**Windows.ApplicationModel.CommunicationBlocking**](https://msdn.microsoft.com/library/windows/apps/Dn974207) | 
| 位置情報                 | 詳しくは、「[マップと位置情報の概要](https://msdn.microsoft.com/library/windows/apps/Mt219699)」をご覧ください。 | 
| 通話               | [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) | 
| ユーザー アカウント情報 | [**Windows.System.UserProfile**](https://msdn.microsoft.com/library/windows/apps/BR241881) | 
| VOIP 呼び出し             | [**Windows.ApplicationModel.Calls**](https://msdn.microsoft.com/library/windows/apps/Dn297266) | 
| USB                      | [**Windows.Devices.Usb**](https://msdn.microsoft.com/library/windows/apps/Dn278466) | 
| HID                      | [**Windows.Devices.HumanInterfaceDevice**](https://msdn.microsoft.com/library/windows/apps/Dn264174) | 
| Bluetooth GATT           | [**Windows.Devices.Bluetooth.GenericAttributeProfile**](https://msdn.microsoft.com/library/windows/apps/Dn297685) | 
| Bluetooth RFCOMM         | [**Windows.Devices.Bluetooth.Rfcomm**](https://msdn.microsoft.com/library/windows/apps/Dn263529) | 
| POS (店舗販売時点管理)         | [**Windows.Devices.PointOfService**](https://msdn.microsoft.com/library/windows/apps/Dn298071) |

