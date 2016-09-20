---
author: mcleblanc
description: "デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。"
title: "I/O、デバイス、アプリ モデルの Windows Phone Silverlight から UWP への移植"
ms.assetid: bf9f2c03-12c1-49e4-934b-e3fa98919c53
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 6b29e741c9cad68083502b25445b965fc266ef6e

---

#  I/O、デバイス、アプリ モデルの Windows Phone Silverlight から UWP への移植

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

前のトピックは、「[XAML と UI の移植](wpsl-to-uwp-porting-xaml-and-ui.md)」でした。

デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。 また、データ処理を含むこともあります。 ただしこのコードは一般には、UI レイヤーまたはデータ レイヤーのいずれにも見なされません。 このコードには、振動コントローラー、加速度計、ジャイロスコープ、マイクとスピーカー (音声認識と音声合成で使います)、地理位置情報、およびタッチ、マウス、キーボード、ペンなどの入力モダリティとの統合が含まれます。

## アプリケーションのライフサイクル (プロセス ライフタイム管理)

Windows Phone Silverlight アプリには、破棄後に再アクティブ化をサポートするために、該当するアプリケーションの状態とビュー状態を保存、復元するためのコードが含まれます。 ユニバーサル Windows プラットフォーム (UWP) アプリのアプリ ライフサイクルと Windows Phone Silverlight アプリのライフサイクルには大きな関係性がありますが、共に同様に、任意の時点でユーザーが選ぶフォアグラウンドの任意のアプリで利用可能なリソースを最大化することを目的として設計されています。 コードは、新しいシステムに合理的な容易さで適合することがわかります。


            **注:** ハードウェアの **[戻る]** ボタンを押すと、Windows Phone Silverlight アプリが自動的に終了します。 UWP アプリでは、モバイル デバイスのハードウェアの **[戻る]** ボタンを押しても自動的に終了*しません*。 その代わりに、アプリは一時停止します。その後、終了することができます。 ただし、そうした詳細は、アプリケーション ライフ サイクル イベントに適切に応答するアプリに対して透過です。

"デバウンス時間" は、アプリが非アクティブになり、システムで中断イベントが発生するまでの時間です。 UWP アプリにはデバウンス時間がありません。このため、アプリが非アクティブになるとすぐに中断イベントが発生します。

詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)」をご覧ください。

## カメラ

Windows Phone Silverlight カメラ キャプチャ コードでは、**Microsoft.Devices.Camera** クラス、**Microsoft.Devices.PhotoCamera** クラス、**Microsoft.Phone.Tasks.CameraCaptureTask** クラスを使います。 ユニバーサル Windows プラットフォーム (UWP) へのコードの移植では、[**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラスを使うことができます。 コードの例については、[**CapturePhotoToStorageFileAsync**](https://msdn.microsoft.com/library/windows/apps/hh700836) のトピックをご覧ください。 このメソッドでは、ストレージ ファイルに写真をキャプチャできます。また、アプリ パッケージ マニフェストに**マイク**と **Web カメラ**の[**デバイス機能**](https://msdn.microsoft.com/library/windows/apps/dn934747)を設定する必要があります。

もう 1 つのオプションは、[**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) クラスです。このクラスでも、**マイク**と **Web カメラ**の[**デバイス機能**](https://msdn.microsoft.com/library/windows/apps/dn934747)が必要です。

レンズ アプリは、UWP アプリではサポートされません。

## アプリが実行されているプラットフォームの検出

アプリの対応に関する考え方は、Windows 10 で変わりました。 また新しい概念モデルでは、アプリはユニバーサル Windows プラットフォーム (UWP) をターゲットとし、すべての Windows デバイスで実行されます。 また、特定のデバイス ファミリ専用の機能を使うように指定することができます。 必要な場合は、アプリのターゲットを 1 つまたは複数のデバイス ファミリに限定するオプションをアプリに設定することもできます。 デバイス ファミリの説明や、ターゲットにするデバイス ファミリを決定する方法について詳しくは、「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。


            **注:** 機能の有無を検出する際に、オペレーティング システムやデバイス ファミリを使わないことをお勧めします。 通常、現在のオペレーティング システムやデバイス ファミリを識別する手法は、特定のオペレーティング システムやデバイス ファミリの機能の有無を判別する際には最適な方法ではありません。 オペレーティング システムやデバイス ファミリ (およびバージョン番号) を検出するのではなく、機能自体の存在をテストしてください (「[条件付きコンパイルとアダプティブ コード](wpsl-to-uwp-porting-to-a-uwp-project.md#conditional-compilation)」をご覧ください)。 特定のオペレーティング システムやデバイス ファミリの情報が必要な場合は、その情報を、サポートされる最小バージョンとして使ってください。そのバージョン用のテストは設計しないでください。

さまざまなデバイスに合わせてアプリの UI を調整するには、推奨される方法がいくつかあります。 これまでと同様に、自動的にサイズ調整される要素と動的レイアウト パネルを引き続き使います。 また、XAML マークアップで、有効ピクセル (以前の表示ピクセル) 単位のサイズを引き続き使います。これにより、UI がさまざまな解像度やスケール ファクターに対応します (「[表示/有効ピクセル、視聴距離、スケール ファクター](wpsl-to-uwp-porting-xaml-and-ui.md#effective-pixels)」をご覧ください)。 Visual State Manager のアダプティブなトリガーとセッターを使って、UI をウィンドウ サイズに対応させることもできます (「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください)。

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

「[条件付きコンパイルとアダプティブ コード](wpsl-to-uwp-porting-to-a-uwp-project.md#conditional-compilation)」もご覧ください。

## デバイスの状態

Windows Phone Silverlight アプリでは、アプリが実行中のデバイスに関する情報を取得するために **Microsoft.Phone.Info.DeviceStatus** クラスを使うことができます。 **Microsoft.Phone.Info** 名前空間に直接相当する UWP の要素はありませんが、ここでは **DeviceStatus** クラスのメンバーを呼び出す代わりに、UWP アプリで使うことができるプロパティとイベントがいくつかあります。

| Windows Phone Silverlight                                                               | UWP                                                                                                                                                                                                                                                                                                                                |
|-----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 
            **ApplicationCurrentMemoryUsage** プロパティと **ApplicationCurrentMemoryUsageLimit** プロパティ | 
            [
              **MemoryManager.AppMemoryUsage**
            ](https://msdn.microsoft.com/library/windows/apps/dn633832) プロパティと [**AppMemoryUsageLimit**](https://msdn.microsoft.com/library/windows/apps/dn633836) プロパティ                                                                                                                                    |
| 
            **ApplicationPeakMemoryUsage** プロパティ                                                 | Visual Studio のメモリ プロファイル ツールを使います。 詳しくは、「[メモリ使用率の分析](http://msdn.microsoft.com/library/windows/apps/dn645469.aspx)」をご覧ください。                                                                                                                                                                          |
| 
            **DeviceFirmwareVersion** プロパティ                                                      | 
            [
              **EasClientDeviceInformation.SystemFirmwareVersion**
            ](https://msdn.microsoft.com/library/windows/apps/dn608144) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                             |
| 
            **DeviceHardwareVersion** プロパティ                                                      | 
            [
              **EasClientDeviceInformation.SystemHardwareVersion**
            ](https://msdn.microsoft.com/library/windows/apps/dn608145) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                             |
| 
            **DeviceManufacturer** プロパティ                                                         | 
            [
              **EasClientDeviceInformation.SystemManufacturer**
            ](https://msdn.microsoft.com/library/windows/apps/hh701398) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                                |
| 
            **DeviceName** プロパティ                                                                 | 
            [
              **EasClientDeviceInformation.SystemProductName**
            ](https://msdn.microsoft.com/library/windows/apps/hh701401) プロパティ (デスクトップ デバイス ファミリのみ)                                                                                                                                                                                 |
| 
            **DeviceTotalMemory** プロパティ                                                          | 相当する要素なし                                                                                                                                                                                                                                                                                                                      |
| 
            **IsKeyboardDeployed** プロパティ                                                         | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| 
            **IsKeyboardPresent** プロパティ                                                          | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| 
            **KeyboardDeployedChanged** イベント                                                       | 相当する要素なし。 このプロパティは、モバイル デバイスのハードウェア キーボードに関する情報を提供します。                                                                                                                                                                                                        |
| 
            **PowerSource** プロパティ                                                                | 相当する要素なし                                                                                                                                                                                                                                                                                                                      |
| 
            **PowerSourceChanged** イベント                                                            | [**RemainingChargePercentChanged**](https://msdn.microsoft.com/library/windows/apps/jj207240) イベントを処理します (モバイル デバイス ファミリのみ)。 このイベントは、[**RemainingChargePercent**](https://msdn.microsoft.com/library/windows/apps/jj207239) プロパティ (モバイル デバイス ファミリのみ) の値が 1% 減少すると発生します。 |

## 位置情報

アプリ パッケージ マニフェストで位置情報機能を宣言するアプリを Windows 10 で実行する場合、システムはエンド ユーザーに同意を求めます。 アプリが独自の同意プロンプトを表示する場合や、オン/オフ切り替えを提供する場合、エンド ユーザーの確認を 1 回のみにするためにその機能を削除できます。

## 向き

UWP アプリで **PhoneApplicationPage.SupportedOrientations** プロパティと **Orientation** プロパティに相当するのは、アプリ パッケージ マニフェストの [**uap:InitialRotationPreference**](https://msdn.microsoft.com/library/windows/apps/dn934798) 要素です。 まだ選択されていない場合は、**[アプリケーション]** タブを選択し、設定を記録するために **[サポートされる回転]** の 1 つ以上のチェック ボックスをオンにします。

ただし、デバイスの向きと画面サイズにかかわらず、UWP アプリの UI が適切に表示されるように設計することをお勧めします。 詳しくは、次の次のトピック「[フォーム ファクターとユーザー エクスペリエンスの移植](wpsl-to-uwp-form-factors-and-ux.md)」をご覧ください。

次のトピックは、「[ビジネス レイヤーとデータ レイヤーの移植](wpsl-to-uwp-business-and-data.md)」です。




<!--HONumber=Jun16_HO4-->


