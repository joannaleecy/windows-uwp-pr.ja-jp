---
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) の相当する WindowsPhone Silverlight Api の包括的なマッピングを提供します。
title: UWP の名前空間とクラス マッピングに WindowsPhone Silverlight
ms.assetid: 33f06706-4790-48f3-a2e4-ebef9ddb61a4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 0072aa814e0bcb22806cad764b5f365770961ac3
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7970086"
---
# <a name="windowsphone-silverlight-to-uwp-api-mappings"></a>WindowsPhone Silverlight UWP API へのマッピングから


このトピックでは、ユニバーサル Windows プラットフォーム (UWP) の相当する WindowsPhone Silverlight Api の包括的なマッピングを提供します。 一般に、機能の 1 対 1 での対応関係はありませんが、いずれかのプラットフォームが、名前空間またはクラス内で他方のプラットフォームの対応する API よりも持っている機能が多い場合や少ない場合があります。

UWP プロジェクトで作業しているし、WindowsPhone Silverlight プロジェクトからのソース コードを再使用している場合、このマッピング表ではやすくなります。 2 つのプラットフォーム間で、名前空間とクラス (UI コントロールを含む) の名前に違いがあります。 多くの場合、名前空間名を簡単に変更するだけでコードはコンパイルします。 名前空間名に加えて、クラス名または API 名も変更される場合があります。 マッピングに若干の追加作業が必要になり、まれにアプローチの変更が必要になることもあります。

**テーブルを使用する方法:** まず、使うクラスの名前を検索します。 マッピングで単純な名前空間名の変更よりも複雑になる場合は常に、クラスが示されています。 クラスが示されていない場合は、マッピングは名前空間の変更のみです。 したがって、クラスの名前空間名を探すことで、相当する UWP の名前空間名が見つかります。 目的のクラスはその名前空間に含まれています。 名前空間が示されていない場合は、その名前は変更されていません。

**注:** と .NET Framework より多く、Windows Phone ストア アプリは windows 10 をサポートします。 たとえば、windows 10 にはいくつかの System.ServiceModel.\* 名前空間、System.Net、System.Net.NetworkInformation、および system.net.sockets があります。
また、windows 10 アプリでのメリットは .NET ネイティブを MSIL をネイティブに実行可能なマシン コードに変換する事前コンパイル テクノロジです。 .NET ネイティブ アプリは、MSIL アプリに比べて、すばやく起動し、メモリ使用量やバッテリ使用量は少なくなります。

| WindowsPhone Silverlight | Windows ランタイム |
| ------------------------- | --------------- |
| 広告 | |
| **Microsoft.Advertising.Mobile.UI.AdControl** クラス | [AdControl](http://msdn.microsoft.com/library/advertising-windows-sdk-api-reference-adcontrol.aspx) クラス |
| アラーム、リマインダー、バックグラウンド エージェント | |
| **Microsoft.Phone.BackgroundAgent** クラス | [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラス |
| **Microsoft.Phone.Scheduler** 名前空間 | [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847) 名前空間 |
| **Microsoft.Phone.Scheduler.Alarm** クラス | [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスと [**ToastNotificationManager**](https://msdn.microsoft.com/library/windows/apps/br208642) クラス |
| **Microsoft.Phone.Scheduler.PeriodicTask**、**ScheduledAction**、**ScheduledActionService**、**ScheduledTask**、**ScheduledTaskAgent** クラス | [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラス |
| **Microsoft.Phone.Scheduler.Reminder** クラス | [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) クラスと [**ToastNotificationManager**](https://msdn.microsoft.com/library/windows/apps/br208642) クラス |
| **Microsoft.Phone.PictureDecoder** クラス | [**BitmapDecoder**](https://msdn.microsoft.com/library/windows/apps/br226176) クラス |
| **Microsoft.Phone.BackgroundAudio** 名前空間 | [**Windows.Media.Playback**](https://msdn.microsoft.com/library/windows/apps/dn640562) 名前空間 |
| **Microsoft.Phone.BackgroundTransfer** 名前空間 | [**Windows.Networking.BackgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) 名前空間 |
| アプリ モデルと環境 | |
| **System.AppDomain** クラス | 直接相当する要素はなし。 [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) クラスと [**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016) クラスをご覧ください。 |
| **System.Environment** クラス | 直接相当する要素はなし |
| **System.ComponentModel.Annotations** クラス  | 直接相当する要素はなし |
| **System.ComponentModel.BackgroundWorker** クラス | [**ThreadPool**](https://msdn.microsoft.com/library/windows/apps/br229621) クラス |
| **System.ComponentModel.DesignerProperties** クラス | [**DesignMode**](https://msdn.microsoft.com/library/windows/apps/br224664) クラス |
| **System.Threading.Thread**、**System.Threading.ThreadPool** クラス | [**ThreadPool**](https://msdn.microsoft.com/library/windows/apps/br229621) クラス |
| (ST = **System.Threading**) <br/> **ST.Thread.MemoryBarrier** メソッド | (ST = **System.Threading**) <br/> **ST.Interlocked.MemoryBarrier** メソッド |
| (ST = **System.Threading**) <br/> **ST.Thread.ManagedThreadId** プロパティ | (S = **System**) <br/> **S.Environment.ManagedThreadId** プロパティ |
| **System.Threading.Timer** クラス | [**ThreadPoolTimer**](https://msdn.microsoft.com/library/windows/apps/br230587) クラス |
| (SWT = **System.Windows.Threading**) <br/> **SWT.Dispatcher** クラス | [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) クラス |
| (SWT = **System.Windows.Threading**) <br/> **SWT.DispatcherTimer** クラス | [**DispatcherTimer**](https://msdn.microsoft.com/library/windows/apps/br244250) クラス |
| Blend for Visual Studio | |
| (MEDC = **Microsoft.Expression.Drawing.Core**) <br/> **MEDC.GeometryHelper** クラス | 直接相当する要素はなし |
| **Microsoft.Expression.Interactivity** 名前空間 | [Microsoft.Xaml.Interactivity](http://go.microsoft.com/fwlink/p/?LinkId=328776) 名前空間 |
| **Microsoft.Expression.Interactivity.Core** 名前空間 | [Microsoft.Xaml.Interactions.Core](http://go.microsoft.com/fwlink/p/?LinkId=328773) 名前空間 |
| (MEIC = **Microsoft.Expression.Interactivity.Core**) <br/> **MEIC.ExtendedVisualStateManager** クラス | 直接相当する要素はなし |
| **Microsoft.Expression.Interactivity.Input** 名前空間 | 直接相当する要素はなし |
| **Microsoft.Expression.Interactivity.Media** 名前空間 | [Microsoft.Xaml.Interactions.Media](http://go.microsoft.com/fwlink/p/?LinkId=328775) 名前空間 |
| **Microsoft.Expression.Shapes** 名前空間 | 直接相当する要素はなし |
| (MI = **Microsoft.Internal**) <br/> **MI.IManagedFrameworkInternalHelper** インターフェイス | 直接相当する要素はなし |
| 連絡先とカレンダーのデータ | |
| **Microsoft.Phone.UserData** 名前空間 | [**Windows.ApplicationModel.Contacts**](https://msdn.microsoft.com/library/windows/apps/br225002)、[**Windows.ApplicationModel.Appointments**](https://msdn.microsoft.com/library/windows/apps/dn263359) 名前空間 |
| (MPU = **Microsoft.Phone.UserData**) <br/> **MPU.Account**、**ContactAddress**、**ContactCompanyInformation**、**ContactEmailAddress**、**ContactPhoneNumber** クラス | [**Contact**](https://msdn.microsoft.com/library/windows/apps/br224849) クラス |
| (MPU = **Microsoft.Phone.UserData**) <br/> **MPU.Appointments** クラス | [**AppointmentCalendar**](https://msdn.microsoft.com/library/windows/apps/dn596134) クラス |
| (MPU = **Microsoft.Phone.UserData**) <br/> **MPU.Contacts** クラス | [**ContactStore**](https://msdn.microsoft.com/library/windows/apps/dn624859) クラス |
| コントロールと UI インフラストラクチャ | |
| **ControlTiltEffect.TiltEffect** クラス | Windows ランタイム アニメーション ライブラリのアニメーションは、共通のコントロールの既定のスタイルに組み込まれています。 「[アニメーション](wpsl-to-uwp-porting-xaml-and-ui.md)」をご覧ください。 |
| **Microsoft.Phone.Controls** 名前空間 | [**Windows.UI.Xaml.Controls**](https://msdn.microsoft.com/library/windows/apps/br227716) 名前空間 |
| (MPC = **Microsoft.Phone.Controls**) <br/> **MPC.ContextMenu** クラス | [**PopupMenu**](https://msdn.microsoft.com/library/windows/apps/br208693) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.DatePickerPage** クラス | [**DatePickerFlyout**](https://msdn.microsoft.com/library/windows/apps/dn625013) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.GestureListener** クラス | [**GestureRecognizer**](https://msdn.microsoft.com/library/windows/apps/br241937) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.LongListSelector** クラス | [**SemanticZoom**](https://msdn.microsoft.com/library/windows/apps/hh702601) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.ObscuredEventArgs** クラス | [**SystemProtection**](https://msdn.microsoft.com/library/windows/apps/jj585394)、[**WindowActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br208377) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.Panorama** クラス | [**Hub**](https://msdn.microsoft.com/library/windows/apps/dn251843) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.PhoneApplicationFrame** クラス、<br/>(SWN = **System.Windows.Navigation**) <br/>**SWN.NavigationService** クラス | [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.PhoneApplicationPage** クラス | [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.TiltEffect** クラス | [**PointerDownThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/hh969164) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.TimePickerPage** クラス | [**TimePickerFlyout**](https://msdn.microsoft.com/library/windows/apps/dn608313) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.WebBrowser** クラス | [**WebView**](https://msdn.microsoft.com/library/windows/apps/br227702) クラス |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.WebBrowserExtensions** クラス | 直接相当する要素はなし |
| (MPC = **Microsoft.Phone.Controls**) <br/>**MPC.WrapPanel** クラス | 一般的なレイアウトの目的で直接相当する要素はありません。 [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/dn298849) と [**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/br227717) は、アイテム コントロールのアイテム パネル テンプレートで使うことができます。 |
| (MPD = **Microsoft.Phone.Data**) <br/>**MPD.Linq** 名前空間 | 直接相当する要素はなし |
| (MPD = **Microsoft.Phone.Data**) <br/>**MPD.Linq.Mapping** 名前空間 | 直接相当する要素はなし |
| **Microsoft.Phone.Globalization** 名前空間 | 直接相当する要素はなし |
| (MPI = **Microsoft.Phone.Info**) <br/>**MPI.DeviceExtendedProperties**、**DeviceStatus** クラス | [**EasClientDeviceInformation**](https://msdn.microsoft.com/library/windows/apps/hh701390)、[**MemoryManager**](https://msdn.microsoft.com/library/windows/apps/dn633831) クラス 詳しくは、「[デバイスの状態](wpsl-to-uwp-input-and-sensors.md)」をご覧ください。 |
| (MPI = **Microsoft.Phone.Info**) <br/>**MPI.MediaCapabilities** クラス | 直接相当する要素はなし |
| (MPI = **Microsoft.Phone.Info**) <br/>**MPI.UserExtendedProperties** クラス | [**AdvertisingManager**](https://msdn.microsoft.com/library/windows/apps/dn363391) クラス |
| **System.Windows** 名前空間 | [**Windows.UI.Xaml**](https://msdn.microsoft.com/library/windows/apps/br209045) 名前空間 |
| **System.Windows.Automation** 名前空間 | [**Windows.UI.Xaml.Automation**](https://msdn.microsoft.com/library/windows/apps/br209179) 名前空間 |
| **System.Windows.Controls**、**System.Windows.Input** 名前空間 | [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)、[**Windows.UI.Input**](https://msdn.microsoft.com/library/windows/apps/br242084)、[**Windows.UI.Xaml.Controls**](https://msdn.microsoft.com/library/windows/apps/br227716) 名前空間 |
| **System.Windows.Controls.DrawingSurface**、**DrawingSurfaceBackgroundGrid** クラス | [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) クラス |
| **System.Windows.Controls.RichTextBox** クラス | [**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/br227548) クラス |
| **System.Windows.Controls.WrapPanel** クラス | 一般的なレイアウトの目的で直接相当する要素はありません。 [**ItemsWrapGrid**](https://msdn.microsoft.com/library/windows/apps/dn298849) と [**WrapGrid**](https://msdn.microsoft.com/library/windows/apps/br227717) は、アイテム コントロールのアイテム パネル テンプレートで使うことができます。 |
| **System.Windows.Controls.Primitives** 名前空間 | [**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) 名前空間 |
| **System.Windows.Controls.Shapes** 名前空間 | [**Windows.UI.Xaml.Controls.Shapes**](/uwp/api/Windows.UI.Xaml.Shapes) 名前空間 |
| **System.Windows.Data** 名前空間 | [**Windows.UI.Xaml.Data**](https://msdn.microsoft.com/library/windows/apps/br209917) 名前空間 |
| **System.Windows.Documents** 名前空間 | [**Windows.UI.Xaml.Documents**](https://msdn.microsoft.com/library/windows/apps/br209984) 名前空間 |
| **System.Windows.Ink** 名前空間 | 直接相当する要素はなし |
| **System.Windows.Markup** 名前空間 | [**Windows.UI.Xaml.Markup**](https://msdn.microsoft.com/library/windows/apps/br228046) 名前空間 | 
| **System.Windows.Navigation** 名前空間 | [**Windows.UI.Xaml.Navigation**](https://msdn.microsoft.com/library/windows/apps/br243300) 名前空間 |
| **System.Windows.UIElement.Tap** イベント、**EventHandler&lt;GestureEventArgs&gt;** デリゲート | [**Tapped**](https://msdn.microsoft.com/library/windows/apps/br208985) イベント、[**TappedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br227993) デリゲート |
| データとサービス |  |
| **System.Data.Linq.DataContext** クラス | 直接相当する要素はなし |
| **System.Data.Linq.Mapping.ColumnAttribute** クラス | 直接相当する要素はなし |
| **System.Data.Linq.SqlClient.SqlHelpers** クラス | 直接相当する要素はなし |
| デバイス | |
| **Microsoft.Devices**、**Microsoft.Devices.Sensors** 名前空間 | [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/br225459)、[**Windows.Devices.Enumeration.Pnp**](https://msdn.microsoft.com/library/windows/apps/br225517)、[**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)、[**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/br206408) 名前空間 |
| **Microsoft.Devices.Camera**、**Microsoft.Devices.PhotoCamera** クラス | [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラス。 また [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) クラス (Windows のみ)。 |
| **Microsoft.Devices.CameraButtons** クラス | [**HardwareButtons**](https://msdn.microsoft.com/library/windows/apps/jj207557) クラス |
| **Microsoft.Devices.CameraVideoBrushExtensions** クラス | [**CaptureElement**](https://msdn.microsoft.com/library/windows/apps/br209278) クラス |
| **Microsoft.Devices.Environment** クラス | 直接相当する要素はなし。 回避策として、条件付きコンパイルを使って、カスタム シンボルを定義します。 または、[IsAttached](http://msdn.microsoft.com/library/e299w87h.aspx) プロパティを使って回避策を作成できます。 |
| **Microsoft.Devices.MediaHistory** クラス | 直接相当する要素はなし |
| **Microsoft.Devices.VibrateController** クラス | [**VibrationDevice**](https://msdn.microsoft.com/library/windows/apps/jj207230) クラス |
| **Microsoft.Devices.Radio.FMRadio** クラス | 直接相当する要素はなし |
| **Microsoft.Devices.Sensors.Accelerometer**、**Compass** クラス | [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/br206408) 名前空間内 |
| **Microsoft.Devices.Sensors.Gyroscope** クラス | [**Gyrometer**](https://msdn.microsoft.com/library/windows/apps/br225718) クラス |
| **Microsoft.Devices.Sensors.Motion** クラス | [**Inclinometer**](https://msdn.microsoft.com/library/windows/apps/br225766) クラス |
| グローバリゼーション | |
| **System.Globalization** 名前空間 | [**Windows.Globalization**](https://msdn.microsoft.com/library/windows/apps/br206813) 名前空間 |
| (ST = **System.Threading**) <br/> **ST.Thread.CurrentCulture** プロパティ | (SG = **System.Globalization**) <br/> **S.CultureInfo.CurrentCulture** プロパティ |
| (ST = **System.Threading**) <br/> **ST.Thread.CurrentUICulture** プロパティ | (SG = **System.Globalization**) <br/> **S.CultureInfo.CurrentUICulture** プロパティ |
| グラフィックスとアニメーション | |
| **Microsoft.Xna.Framework.\*** 名前空間、[XNA Framework クラス ライブラリ](http://go.microsoft.com/fwlink/p/?LinkId=263769)、[Content Pipeline クラス ライブラリ](http://go.microsoft.com/fwlink/p/?LinkId=263770) | 直接相当する要素はなし。 一般的に、C++ と共に [Microsoft DirectX](https://msdn.microsoft.com/library/windows/desktop/ee663274) を使います。 「[ゲームの開発](https://msdn.microsoft.com/library/windows/apps/hh452744)」と「[DirectX と XAML の相互運用機能](https://msdn.microsoft.com/library/windows/apps/hh825871)」をご覧ください。 |
| **Microsoft.Xna.Framework.Audio.Microphone** クラス | [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラス |
| **Microsoft.Xna.Framework.Audio.SoundEffect** クラス | [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) クラス |
| **Microsoft.Xna.Framework.GamerServices** 名前空間 | (WPS = **Windows.Phone.System**) <br/> [**WPS.UserProfile.GameServices.Core**](https://msdn.microsoft.com/library/windows/apps/jj207609) 名前空間 |
| **Microsoft.Xna.Framework.GamerServices.Guide** クラス | 直接相当する要素はなし |
| **Microsoft.Xna.Framework.Input.GamePad** クラス | [**HardwareButtons**](https://msdn.microsoft.com/library/windows/apps/jj207557) クラス |
| **Microsoft.Xna.Framework.Input.Touch.TouchPanel** クラス | [**GestureRecognizer**](https://msdn.microsoft.com/library/windows/apps/br241937) クラス |
| (MXFM = **Microsoft.Xna.Framework.Media**) <br/> **MXFM.MediaLibrary**、**MXFM.PhoneExtensions.MediaLibraryExtensions** クラス | [**KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) クラス |
| **Microsoft.Xna.Framework.Media.MediaQueue** クラス | [**SystemMediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/dn278677) クラス |
| **Microsoft.Xna.Framework.Media.Playlist** クラス | [**BackgroundMediaPlayer**](https://msdn.microsoft.com/library/windows/apps/dn652527) クラス |
| **System.Windows.Media** 名前空間 | [**Windows.UI.Xaml.Media**](/uwp/api/Windows.UI.Xaml.Media) 名前空間 |
| **System.Windows.Media.RadialGradientBrush** クラス | 直接相当する要素はなし。 「[メディアとグラフィックス](wpsl-to-uwp-porting-xaml-and-ui.md)」をご覧ください。 |
| **System.Windows.Media.Animation** 名前空間 | [**Windows.UI.Xaml.Media.Animation**](https://msdn.microsoft.com/library/windows/apps/br243232) 名前空間 |
| **System.Windows.Media.Effects** 名前空間 | 直接相当する要素はなし |
| **System.Windows.Media.Imaging** 名前空間 | [**Windows.UI.Xaml.Media.Imaging**](https://msdn.microsoft.com/library/windows/apps/br243258) 名前空間 |
| **System.Windows.Media.Media3D** 名前空間 | [**Windows.UI.Xaml.Media.Media3D**](https://msdn.microsoft.com/library/windows/apps/br243274) 名前空間 |
| **System.Windows.Shapes** 名前空間 | [**Windows.UI.Xaml.Shapes**](/uwp/api/Windows.UI.Xaml.Shapes) 名前空間 |
| ランチャーとセレクター | |
| **Microsoft.Phone.Tasks.AddressChooserTask**、**EmailAddressChooserTask**、**PhoneNumberChooserTask** クラス | [**ContactPicker**](https://msdn.microsoft.com/library/windows/apps/br224913) クラス |
| **Microsoft.Phone.Tasks.AddWalletItemTask**、**AddWalletItemResult** クラス | [**Windows.ApplicationModel.Wallet**](https://msdn.microsoft.com/library/windows/apps/dn631399) 名前空間 |
| **Microsoft.Phone.Tasks.BingMapsDirectionsTask**、**BingMapsTask** クラス | 直接相当する要素はなし |
| **Microsoft.Phone.Tasks.CameraCaptureTask** クラス | [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) クラス。 また [**CameraCaptureUI**](https://msdn.microsoft.com/library/windows/apps/br241030) クラス (Windows のみ)。 |
| **Microsoft.Phone.Tasks.MarketplaceDetailTask** | [**CurrentApp**](https://msdn.microsoft.com/library/windows/apps/hh779765) クラス ([**RequestAppPurchaseAsync**](https://msdn.microsoft.com/library/windows/apps/hh967813) メソッド) |
| **Microsoft.Phone.Tasks.ConnectionSettingsTask**、**MarketplaceHubTask**、**MarketplaceReviewTask**、**MarketplaceSearchTask**、**MediaPlayerLauncher**、**SearchTask**、**SmsComposeTask**、**WebBrowserTask** クラス | [**Launcher**](https://msdn.microsoft.com/library/windows/apps/br241801) クラス |
| **Microsoft.Phone.Tasks.EmailComposeTask** クラス | [**EmailMessage**](https://msdn.microsoft.com/library/windows/apps/dn631270) クラス |
| **Microsoft.Phone.Tasks.GameInviteTask** クラス | 直接相当する要素はなし |
| **Microsoft.Phone.Tasks.MapDownloaderTask**、**MapsDirectionsTask**、**MapsTask**、**MapUpdaterTask** クラス | 直接相当する要素はなし |
| **Microsoft.Phone.Tasks.PhoneCallTask** クラス | [**PhoneCallManager**](https://msdn.microsoft.com/library/windows/apps/dn624832) クラス |
| **Microsoft.Phone.Tasks.PhotoChooserTask** クラス | [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラス |
| **Microsoft.Phone.Tasks.SaveAppointmentTask** クラス | [**AppointmentManager**](https://msdn.microsoft.com/library/windows/apps/dn297254) クラス |
| **Microsoft.Phone.Tasks.SaveContactTask**、**SaveEmailAddressTask**、**SavePhoneNumberTask** クラス | [**StoredContact**](https://msdn.microsoft.com/library/windows/apps/jj207727) クラス (Windows Phone のみ) | 
| **Microsoft.Phone.Tasks.SaveRingtoneTask** クラス | 直接相当する要素はなし |
| **Microsoft.Phone.Tasks.ShareLinkTask**、**ShareMediaTask**、**ShareStatusTask** クラス | [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/br205873) クラス |
| 位置情報 | |
| **System.Device.Location** 名前空間 | [**Windows.Devices.Geolocation**](https://msdn.microsoft.com/library/windows/apps/br225603) 名前空間 |
| **System.Device.GeoCoordinateWatcher** クラス | [**Geolocator**](https://msdn.microsoft.com/library/windows/apps/br225534) クラス |
| マップ | |
| **Microsoft.Phone.Maps** 名前空間 | [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間 |
| **Microsoft.Phone.Maps.Controls** 名前空間 | [**Windows.UI.Xaml.Controls.Maps**](https://msdn.microsoft.com/library/windows/apps/dn610751) 名前空間 |
| **Microsoft.Phone.Maps.Controls.Map** クラス | [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) クラス |
| **Microsoft.Phone.Maps.Services** 名前空間 | [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間 |
| **Microsoft.Phone.Maps.Services.GeocodeQuery**、**ReverseGeocodeQuery** クラス | [**MapLocationFinder**](https://msdn.microsoft.com/library/windows/apps/dn627550) クラス |
| **System.Device.Location.GeoCoordinate** クラス | [**Geopoint**](https://msdn.microsoft.com/library/windows/apps/dn263675) クラス |
| **Microsoft.Phone.Maps.Services.Route** クラス | [**MapRoute**](https://msdn.microsoft.com/library/windows/apps/dn636937) クラス |
| **Microsoft.Phone.Maps.Services.RouteQuery** クラス | [**MapRouteFinder**](https://msdn.microsoft.com/library/windows/apps/dn636938) クラス |
| 収益化 | |
| **Microsoft.Phone.Marketplace** 名前空間 | [**Windows.ApplicationModel.Store**](https://msdn.microsoft.com/library/windows/apps/br225197) 名前空間 |
| メディア | |
| **Microsoft.Phone.Media** 名前空間 | [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) クラス |
| ネットワーク | |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.DeviceNetworkInformation** クラス | [**Hostname**](https://msdn.microsoft.com/library/windows/apps/br207113)、[**NetworkInformation**](https://msdn.microsoft.com/library/windows/apps/br207293) クラス |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.NetworkInterface** クラス | [**NetworkInformation**](https://msdn.microsoft.com/library/windows/apps/br207293) クラス |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.NetworkInterfaceInfo** クラス | [**ConnectionProfile**](https://msdn.microsoft.com/library/windows/apps/br207249) クラス |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.NetworkInterfaceList** クラス | [**NetworkInformation**](https://msdn.microsoft.com/library/windows/apps/br207293) クラス |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.SocketExtensions** クラス | 直接相当する要素はなし |
| (MPNN = **Microsoft.Phone.Net.NetworkInformation**) <br/> **MPNN.WebRequestExtensions** クラス | 直接相当する要素はなし |
| **Microsoft.Phone.Networking.Voip** 名前空間 | 直接相当する要素はなし |
| **System.Net.CookieCollection** クラス | 引き続きサポートされますが、一部のプロパティは含まれていません (たとえば、IsReadOnly) |
| **System.Net.DownloadProgressChangedEventArgs** クラスと、**System.Net.WebClient** に関連する同様のクラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx))。 [System.Net.Http.StreamContent](https://msdn.microsoft.com/library/system.net.http.streamcontent.aspx) から派生し、進捗状況を測定します。 |
| **System.Net.DnsEndPoint**、**IPAddress** クラス | これらのクラスは引き続きサポートされますが、一部のプロパティは含まれていません。 代わりに、[**HostName**](https://msdn.microsoft.com/library/windows/apps/br207113) クラスに移行してください。 |
| **System.Net.HttpUtility** クラス | [**HtmlFormatHelper**](https://msdn.microsoft.com/library/windows/apps/hh738437) クラス |
| **System.Net.HttpWebRequest** クラス | 部分的にサポートされますが、お勧めできません。将来的な代替案は [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) を使って HTTP 要求を表します。 |
| **System.Net.HttpWebResponse** クラス | 引き続きサポートされますが、Close() の代わりに Dispose() を使います。 お勧めできる将来的な代替案は [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpResponseMessage](https://msdn.microsoft.com/library/system.net.http.httpresponsemessage.aspx) を使って HTTP 応答を表します。 |
| (SNN = **System.Net.NetworkInformation**) <br/> **SNN.NetworkChange** クラス | コンストラクター以外は引き続きサポートされます。 |
| **System.Net.OpenReadCompletedEventArgs** クラスと、**System.Net.WebClient** に関連する同様のクラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient.aspx)) |
| **System.Net.Sockets.Socket** クラス | 引き続きサポートされますが、Close() の代わりに Dispose() を使います。 代わりに、[**StreamSocket**](https://msdn.microsoft.com/library/windows/apps/br226882) クラスに移行してください。 |
| **System.Net.Sockets.SocketException** クラス | 引き続きサポートされますが、ErrorCode の代わりに SocketErrorCode プロパティを使います。 |
| **System.Net.Sockets.UdpAnySourceMulticastClient**、**UdpSingleSourceMulticastClient** クラス | [**DatagramSocket**](https://msdn.microsoft.com/library/windows/apps/br241319) クラス |
| **System.Net.UploadProgressChangedEventArgs** クラスと、**System.Net.WebClient** に関連する同様のクラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient.aspx)) |
| **System.Net.WebClient** クラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient.aspx)) |
| **System.Net.WebRequest** クラス | 部分的にサポートされます (プロパティのセットが異なる) が、お勧めできません。将来的な代替案は [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpRequestMessage](https://msdn.microsoft.com/library/system.net.http.httprequestmessage.aspx) を使って HTTP 要求を表します。 |
| **System.Net.WebResponse** クラス | 引き続きサポートされますが、Close() の代わりに Dispose() を使います。 お勧めできる将来的な代替案は [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient(v=vs.118).aspx)) です。 これらの API では、[System.Net.Http.HttpResponseMessage](https://msdn.microsoft.com/library/system.net.http.httpresponsemessage.aspx) を使って HTTP 応答を表します。 |
| (SN = **System.Net**) <br/> **SN.WriteStreamClosedEventArgs** クラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient.aspx)) |
| (SN = **System.Net**) <br/> **SN.WriteStreamClosedEventHandler** クラス | [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) クラス (または [System.Net.Http.HttpClient](https://msdn.microsoft.com/library/system.net.http.httpclient.aspx)) |
| **System.UriFormatException** クラス | **System.FormatException** クラス |
| 通知 | |
| MPN = **Microsoft.Phone.Notification** 名前空間 | [**Windows.UI.Notifications**](https://msdn.microsoft.com/library/windows/apps/br208661)、[**Windows.Networking.PushNotifications**](https://msdn.microsoft.com/library/windows/apps/br241307) 名前空間 |
| MPN = **Microsoft.Phone.Notification** <br/> **MPN.HttpNotification** クラス | [**TileNotification**](https://msdn.microsoft.com/library/windows/apps/br208616) クラス |
| MPN = **Microsoft.Phone.Notification** <br/> **MPN.HttpNotificationChannel** クラス | [**PushNotificationChannel**](https://msdn.microsoft.com/library/windows/apps/br241283) クラス |
| プログラミング | |
| **System** 名前空間 | [**Windows.Foundation**](https://msdn.microsoft.com/library/windows/apps/br226021) 名前空間 |
| **System.Diagnostics.StackFrame**、**StackTrace** クラス | 直接相当する要素はなし |
| **System.Diagnostics** 名前空間 | [**Windows.Foundation.Diagnostics**](https://msdn.microsoft.com/library/windows/apps/br206677) 名前空間 |
| **System.ICloneable** インターフェイス | 適切な型を返すカスタム メソッド。 |
| **System.Reflection.Emit.ILGenerator** クラス | 直接相当する要素はなし |
| Reactive Extensions | |
| **Microsoft.Phone.Reactive** 名前空間 | 直接相当する要素はなし |
| リフレクション | |
| **System.Type** クラス | **System.Reflection.TypeInfo** クラス。 「[UWP アプリのための .NET Framework でのリフレクション](https://msdn.microsoft.com/library/hh535795.aspx)」を参照してください。 |
| リソース | |
| **System.Resources.ResourceManager** クラス | (WA = **Windows.ApplicationModel**)<br/>[**WA.Resources.Core**](https://msdn.microsoft.com/library/windows/apps/br225039) および [**WA.Resources**](https://msdn.microsoft.com/library/windows/apps/br206022) 名前空間、[**ResourceManager**](https://msdn.microsoft.com/library/windows/apps/br206078) クラス。 「[Windows ランタイム アプリのリソースの作成と取得](https://msdn.microsoft.com/library/windows/apps/xaml/hh694557.aspx)」をご覧ください。 |
| セキュリティ要素 | |
| (MPS = **Microsoft.Phone.SecureElement**) <br/> **MPS.SecureElementChannel**、**MPS.SecureElementSession** クラス | [**SmartCardConnection**](https://msdn.microsoft.com/library/windows/apps/dn608002) クラス |
| (MPS = **Microsoft.Phone.SecureElement**) <br/> **MPS.SecureElementReader** クラス | [**SmartCardReader**](https://msdn.microsoft.com/library/windows/apps/dn263857) クラス |
| セキュリティ | |
| (SSC = **System.Security.Cryptography**) <br/> **SSC.Aes**、**SSC.RSA** クラス | [**CryptographicEngine**](https://msdn.microsoft.com/library/windows/apps/br241490) クラス |
| (SSC = **System.Security.Cryptography**) <br/> **SSC.HMACSHA256**、**SSC.SHA256** クラス | [**HashAlgorithmProvider**](https://msdn.microsoft.com/library/windows/apps/br241511) クラス |
| (SSC = **System.Security.Cryptography**) <br/> **SSC.ProtectedData** クラス | [**DataProtectionProvider**](https://msdn.microsoft.com/library/windows/apps/br241559) クラス |
| (SSC = **System.Security.Cryptography**) <br/> **SSC.RandomNumberGenerator** クラス | [**CryptographicBuffer**](https://msdn.microsoft.com/library/windows/apps/br227092) クラス |
| (SSC = **System.Security.Cryptography**) <br/> **SSC.X509Certificates.X509Certificate** クラス | [**CertificateEnrollmentManager**](https://msdn.microsoft.com/library/windows/apps/br212075) クラス |
| Shell (シェル) | |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ApplicationBar** クラス | [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/dn279427) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ApplicationBarIconButton** クラス | [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/dn279244) クラス ([**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/dn279430) プロパティ内で使う場合) |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ApplicationBarMenuItem** クラス | [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/dn279244) クラス ([**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/dn279434) プロパティ内で使う場合) |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.CycleTileData**、**MPSh.FlipTileData**、**MPSh.IconicTileData**、**MPSh.ShellTileData**、**MPSh.StandardTileData** クラス | [**TileTemplateType**](https://msdn.microsoft.com/library/windows/apps/br208621) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.PhoneApplicationService** クラス | [**CoreApplication**](https://msdn.microsoft.com/library/windows/apps/br225016)、[**DisplayRequest**](https://msdn.microsoft.com/library/windows/apps/br241816) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ProgressIndicator** クラス | [**StatusBarProgressIndicator**](https://msdn.microsoft.com/library/windows/apps/dn633865) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ShellTile** クラス | [**SecondaryTile**](https://msdn.microsoft.com/library/windows/apps/br242183) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ShellTileSchedule** クラス | [**TileUpdater**](https://msdn.microsoft.com/library/windows/apps/br208628) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.ShellToast** クラス | [**ToastNotificationManager**](https://msdn.microsoft.com/library/windows/apps/br208642) クラス |
| (MPSh = **Microsoft.Phone.Shell**) <br/> **MPSh.SystemTray** クラス | [**StatusBar**](https://msdn.microsoft.com/library/windows/apps/dn633864) クラス |
| ストレージと I/O | |
| **Microsoft.Phone.Storage.ExternalStorage**、**ExternalStorageDevice**、**ExternalStorageFile**、**ExternalStorageFolder** クラス | [**KnownFolders**](https://msdn.microsoft.com/library/windows/apps/br227151) クラス |
| **System.IO** 名前空間 | [**Windows.Storage**](https://msdn.microsoft.com/library/windows/apps/br227346)、[**Windows.Storage.Streams**](https://msdn.microsoft.com/library/windows/apps/br241791) 名前空間 |
| **System.IO.Directory** クラス | [**StorageFolder**](https://msdn.microsoft.com/library/windows/apps/br227230) クラス |
| **System.IO.File** クラス | [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) クラスと [**PathIO**](https://msdn.microsoft.com/library/windows/apps/hh701663) クラス
| (SII = **System.IO.IsolatedStorage**) <br/> **SII.IsolatedStorageFile** クラス |[**ApplicationData.LocalFolder**](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティ |
| (SII = **System.IO.IsolatedStorage**) <br/> **SII.IsolatedStorageSettings** クラス | [**ApplicationData.LocalSettings**](https://msdn.microsoft.com/library/windows/apps/windows.storage.applicationdata.localsettings.aspx) プロパティ |
| **System.IO.Stream** クラス | 引き続きサポートされますが、BeginRead()/EndRead() と BeginWrite()/EndWrite() の代わりに ReadAsync() と WriteAsync() を使います。 |
| ウォレット | |
| **Microsoft.Phone.Wallet** 名前空間 | [**Windows.ApplicationModel.Wallet**](https://msdn.microsoft.com/library/windows/apps/dn631399) 名前空間 |
| Xml | |
| (SX = **System.Xml**) | **SX.XmlConvert.ToDateTime** メソッド |
| (SX = **System.Xml**) | **SX.XmlConvert.ToDateTimeOffset** メソッド |


次のトピックは「[プロジェクトの移植](wpsl-to-uwp-porting-to-a-uwp-project.md)」です。

