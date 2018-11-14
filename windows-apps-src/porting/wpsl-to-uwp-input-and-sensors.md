---
author: stevewhims
description: デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。
title: I/O、デバイス、およびアプリ モデル WindowsPhone Silverlight から UWP への移植 '
ms.assetid: bf9f2c03-12c1-49e4-934b-e3fa98919c53
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a0041fd154a4ce32930e10e21175706e8e7ad988
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6202633"
---
#  <a name="porting-windowsphone-silverlight-to-uwp-for-io-device-and-app-model"></a>I/O、デバイス、およびアプリ モデル WindowsPhone Silverlight から UWP への移植


前のトピックは、「[XAML と UI の移植](wpsl-to-uwp-porting-xaml-and-ui.md)」でした。

デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。 また、データ処理を含むこともあります。 ただしこのコードは一般には、UI レイヤーまたはデータ レイヤーのいずれにも見なされません。 このコードには、振動コントローラー、加速度計、ジャイロスコープ、マイクとスピーカー (音声認識と音声合成で使います)、地理位置情報、およびタッチ、マウス、キーボード、ペンなどの入力モダリティとの統合が含まれます。

## <a name="application-lifecycle-process-lifetime-management"></a>アプリケーションのライフサイクル (プロセス ライフタイム管理)

WindowsPhone Silverlight アプリには、保存、廃棄と後に再アクティブ化をサポートするためにアプリケーションの状態とビュー状態を復元するためのコードが含まれています。 ユニバーサル Windows プラットフォーム (UWP) アプリのアプリのライフ サイクルが共にと WindowsPhone Silverlight アプリでは、どちらも利用可能なリソースを最大限に高めることを目的と同じ設計しているために、ユーザーが選択した任意のアプリ、任意の時点でフォア グラウンドします。 コードは、新しいシステムに合理的な容易さで適合することがわかります。

**注:** 自動的にハードウェア**戻る**] ボタンを押すと、WindowsPhone Silverlight アプリが終了します。 UWP アプリでは、モバイル デバイスのハードウェアの **[戻る]** ボタンを押しても自動的に終了*しません*。 その代わりに、アプリは一時停止します。その後、終了することができます。 ただし、そうした詳細は、アプリケーション ライフ サイクル イベントに適切に応答するアプリに対して透過です。

"デバウンス時間" は、アプリが非アクティブになり、システムで中断イベントが発生するまでの時間です。 UWP アプリにはデバウンス時間がありません。このため、アプリが非アクティブになるとすぐに中断イベントが発生します。

詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)」をご覧ください。

## <a name="camera"></a>カメラ

WindowsPhone Silverlight カメラ キャプチャ コードでは、 **Microsoft.Devices.Camera**、 **Microsoft.Devices.PhotoCamera**、または**Microsoft.Phone.Tasks.CameraCaptureTask**クラスを使います。 ユニバーサル Windows プラットフォーム (UWP) へのコードの移植では、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラスを使うことができます。 コードの例については、[**CapturePhotoToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh700836) のトピックをご覧ください。 そのメソッドでは、ストレージ ファイルに写真をキャプチャすることができ、**マイク**と**web カメラ**の[**デバイス機能**](https://msdn.microsoft.com/library/windows/apps/dn934747)をアプリ パッケージ マニフェストに設定する必要があります。

別のオプションは、**マイク**と**web カメラ**の[**デバイス機能**](https://msdn.microsoft.com/library/windows/apps/dn934747)する必要もあります[**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030)クラスです。

レンズ アプリは、UWP アプリではサポートされません。

## <a name="detecting-the-platform-your-app-is-running-on"></a>アプリが実行されているプラットフォームの検出

Windows 10 でアプリのターゲット設定の変更に関する思考方法です。 また新しい概念モデルでは、アプリはユニバーサル Windows プラットフォーム (UWP) をターゲットとし、すべての Windows デバイスで実行されます。 また、特定のデバイス ファミリ専用の機能を使うように指定することができます。 必要な場合は、アプリのターゲットを 1 つまたは複数のデバイス ファミリに限定するオプションをアプリに設定することもできます。 デバイス ファミリの説明や、ターゲットにするデバイス ファミリを決定する方法について詳しくは、「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。

**注:** 機能の有無を検出するのには、オペレーティング システムやデバイス ファミリをしない使用することをお勧めします。 通常、現在のオペレーティング システムやデバイス ファミリを識別する手法は、特定のオペレーティング システムやデバイス ファミリの機能の有無を判別する際には最適な方法ではありません。 オペレーティング システムやデバイス ファミリ (およびバージョン番号) を検出するのではなく、機能自体の存在をテストしてください (「[条件付きコンパイルとアダプティブ コード](wpsl-to-uwp-porting-to-a-uwp-project.md)」をご覧ください)。 特定のオペレーティング システムやデバイス ファミリの情報が必要な場合は、その情報を、サポートされる最小バージョンとして使ってください。そのバージョン用のテストは設計しないでください。

さまざまなデバイスに合わせてアプリの UI を調整するには、推奨される方法がいくつかあります。 これまでと同様に、自動的にサイズ調整される要素と動的レイアウト パネルを引き続き使います。 また、XAML マークアップで、有効ピクセル (以前の表示ピクセル) 単位のサイズを引き続き使います。これにより、UI がさまざまな解像度やスケール ファクターに対応します (「[表示/有効ピクセル、視聴距離、スケール ファクター](wpsl-to-uwp-porting-xaml-and-ui.md)」をご覧ください)。 Visual State Manager のアダプティブなトリガーとセッターを使って、UI をウィンドウ サイズに対応させることもできます (「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください)。

ただし、デバイス ファミリの検出が必須となるシナリオの場合は、デバイス ファミリの検出を行ってください。 次の例では、[**AnalyticsVersionInfo**](https://msdn.microsoft.com/library/windows/apps/dn960165) クラスを使い、必要に応じてモバイル デバイス ファミリ向けに調整されたページに移動し、該当しない場合は既定のページにフォール バックします。

```csharp
   if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
        rootFrame.Navigate(typeof(MainPageMobile), e.Arguments);
    else
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

アプリでは、リソースの選択に関する有効な要因に基づいて、アプリが実行されているデバイス ファミリを判別することもできます。 次の例は、この操作を命令を使って実行する方法を示しています。「[**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/br206071)」トピックには、このクラスを使い、デバイス ファミリに関する要因に基づいてデバイス ファミリ固有のリソースを読み込む場合の一般的な使用例が説明されています。

```csharp
var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
string deviceFamilyName;
bool isDeviceFamilyNameKnown = qualifiers.TryGetValue("DeviceFamily", out deviceFamilyName);
```

「[条件付きコンパイルとアダプティブ コード](wpsl-to-uwp-porting-to-a-uwp-project.md)」もご覧ください。

## <a name="device-status"></a>デバイスの状態

WindowsPhone Silverlight アプリでは、 **Microsoft.Phone.Info.DeviceStatus**クラスを使用して、アプリが実行されているデバイスに関する情報を取得します。 **Microsoft.Phone.Info** 名前空間に直接相当する UWP の要素はありませんが、ここでは **DeviceStatus** クラスのメンバーを呼び出す代わりに、UWP アプリで使うことができるプロパティとイベントがいくつかあります。

| Windows Phone Silverlight                                                               | UWP                                                                                                                                                                                                                                                                                                                                |
|-----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **ApplicationCurrentMemoryUsage** プロパティと **ApplicationCurrentMemoryUsageLimit** プロパティ | [**MemoryManager.AppMemoryUsage**](https://msdn.microsoft.com/library/windows/apps/dn633832) プロパティと [**AppMemoryUsageLimit**](https://msdn.microsoft.com/library/windows/apps/dn633836) プロパティ                                                                                                                                    |
| **ApplicationPeakMemoryUsage** プロパティ                                                 | Visual Studio のメモリ プロファイル ツールを使います。 詳しくは、「[メモリ使用率の分析](http://msdn.microsoft.com/library/windows/apps/dn645469.aspx)」をご覧ください。                                                                                                                                                                          |
| **DeviceFirmwareVersion** プロパティ                                                      | [**EasClientDeviceInformation.SystemFirmwareVersion**](https://msdn.microsoft.com/library/windows/apps/dn608144) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                             |
| **DeviceHardwareVersion** プロパティ                                                      | [**EasClientDeviceInformation.SystemHardwareVersion**](https://msdn.microsoft.com/library/windows/apps/dn608145) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                             |
| **DeviceManufacturer** プロパティ                                                         | [**EasClientDeviceInformation.SystemManufacturer**](https://msdn.microsoft.com/library/windows/apps/hh701398) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                                |
| **DeviceName** プロパティ                                                                 | [**EasClientDeviceInformation.SystemProductName**](https://msdn.microsoft.com/library/windows/apps/hh701401) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                                 |
| **DeviceTotalMemory** プロパティ                                                          | 相当する要素なし                                                                                                                                                                                                                                                                                                                      |
| **IsKeyboardDeployed** プロパティ                                                         | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| **IsKeyboardPresent** プロパティ                                                          | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| **KeyboardDeployedChanged** イベント                                                       | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| **PowerSource** プロパティ                                                                | 相当する要素なし                                                                                                                                                                                                                                                                                                                      |
| **PowerSourceChanged** イベント                                                            | [**RemainingChargePercentChanged**](https://msdn.microsoft.com/library/windows/apps/jj207240) イベントを処理します (モバイル デバイス ファミリのみ)。 このイベントは、[**RemainingChargePercent**](https://msdn.microsoft.com/library/windows/apps/jj207239) プロパティ (モバイル デバイス ファミリのみ) の値が 1% 減少すると発生します。 |

## <a name="location"></a>位置情報

位置情報機能をアプリ パッケージ マニフェストで宣言するアプリは、windows 10 で実行しているシステムに同意をエンドユーザーが求められます。 アプリが独自の同意プロンプトを表示する場合や、オン/オフ切り替えを提供する場合、エンド ユーザーの確認を 1 回のみにするためにその機能を削除できます。

## <a name="orientation"></a>向き

UWP アプリで **PhoneApplicationPage.SupportedOrientations** プロパティと **Orientation** プロパティに相当するのは、アプリ パッケージ マニフェストの [**uap:InitialRotationPreference**](https://msdn.microsoft.com/library/windows/apps/dn934798) 要素です。 まだ選択されていない場合は、**[アプリケーション]** タブを選択し、設定を記録するために **[サポートされる回転]** の 1 つ以上のチェック ボックスをオンにします。

ただし、デバイスの向きと画面サイズにかかわらず、UWP アプリの UI が適切に表示されるように設計することをお勧めします。 詳しくは、次の次のトピック「[フォーム ファクターとユーザー エクスペリエンスの移植](wpsl-to-uwp-form-factors-and-ux.md)」をご覧ください。

次のトピックは、「[ビジネス レイヤーとデータ レイヤーの移植](wpsl-to-uwp-business-and-data.md)」です。

