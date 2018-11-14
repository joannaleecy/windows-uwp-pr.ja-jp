---
author: TylerMSFT
title: Windows 設定アプリの起動
description: アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。
ms.assetid: C84D4BEE-1FEE-4648-AD7D-8321EAC70290
ms.author: twhitney
ms.date: 03/20/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b86298ca671282dea201e3088bc60845231fe007
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6448677"
---
# <a name="launch-the-windows-settings-app"></a>Windows 設定アプリの起動


**重要な API**

-   [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)

Windows 設定アプリを起動する方法について説明します。 ここでは、**ms-settings:** URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。

設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。 アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。 詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。

## <a name="how-to-launch-the-settings-app"></a>設定アプリを起動する方法

**設定**アプリを起動するには、次の例に示されているように `ms-settings:` URI スキームを使います。

この例では、ハイパーリンク XAML コントロールで `ms-settings:privacy-microphone` URI を使って、マイクのプライバシー設定ページを起動します。

```xml
<!--Set Visibility to Visible when access to the microphone is denied -->
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic"
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access the microphone. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-microphone">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the microphone privacy settings."/>
</TextBlock>
```

また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードから**設定**アプリを起動することもできます。 次の例は、`ms-settings:privacy-webcam` URI を使って、カメラのプライバシー設定ページを起動する方法を示しています。

```cs
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
```

上記のコードでは、カメラのプライバシー設定ページが起動されます。

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

URI の起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。

## <a name="ms-settings-uri-scheme-reference"></a>ms-settings: URI スキーム リファレンス

設定アプリのさまざまなページ開くには、次の URI を使います。

> 設定ページを使用できるかどうかは、Windows の SKU によって異なることに注意してください。 デスクトップの Windows 10 で利用可能な設定ページのすべてを Windows 10 Mobile で利用できるとは限りません。またその逆も同様です。 注の列には、ページが使用可能となるための追加の要件も記されています。

## <a name="accounts"></a>アカウント

|［設定］ページ| URI |
|-------------|-----|
| 職場または学校にアクセスする | ms-settings:workplace |
| メール & アプリのアカウント  | ms-settings:emailandaccounts |
| 家族とその他のユーザー | ms-settings:otherusers |
| サインイン オプション | ms-settings:signinoptions<br>ms-settings:signinoptions-dynamiclock |
| 設定の同期 | ms-settings:sync |
| Windows Hello セットアップ | ms-settings:signinoptions-launchfaceenrollment<br>ms-settings:signinoptions-launchfingerprintenrollment |
| お使いのアカウント | ms-settings:yourinfo |

## <a name="apps"></a>Apps

|［設定］ページ| URI |
|-------------|-----|
| アプリと機能 | ms-settings:appsfeatures |
| アプリの機能 | ms-settings:appsfeatures-app (アプリのリセット、アドオンの管理およびダウンロード可能なコンテンツなど)|
| Web サイト用のアプリ | ms-settings:appsforwebsites |
| 既定のアプリ | ms-settings:defaultapps |
| オプション機能の管理 | ms-settings:optionalfeatures |
| オフライン マップ | ms-settings:maps |
| スタートアップ アプリ | ms-settings:startupapps |
| ビデオ再生 | ms-settings:videoplayback |

## <a name="cortana"></a>Cortana

|[設定] ページ| URI |
|-------------|-----|
| アクセス許可と履歴 | ms-settings:cortana-permissions |
| 詳細 | ms-settings:cortana-moredetails |
| 自分のデバイス間での Cortana | ms-settings:cortana-notifications |
| Cortana に話す | ms-settings:cortana-language |

> [!NOTE] 
> デスクトップでは、この設定セクションときに呼び出される検索場所 Cortana が現在利用可能でないや Cortana は無効になっている領域に PC を設定します。 この場合、Cortana に固有のページ ([デバイス間での Cortana) と Cortana に話すは表示されません。 

## <a name="devices"></a>デバイス

|[設定] ページ| URI |
|-------------|-----|
| オーディオと音声認識 | ms-settings:holographic-audio (Microsoft Store で入手可能な Mixed Reality ポータル アプリがインストールされている場合のみ利用可能) |
| 自動再生 | ms-settings:autoplay |
| Bluetooth | ms-settings:bluetooth |
| 接続されたデバイス | ms-settings:connecteddevices |
| 既定のカメラ | ms-settings:camera |
| マウスとタッチパッド | ms-settings:mousetouchpad (タッチパット設定は、タッチパッドが搭載されているデバイスでのみ利用可能) |
| ペンと Windows Ink | ms-settings:pen |
| プリンターとスキャナー | ms-settings:printers |
| タッチパッド | ms-settings:devices-touchpad (タッチパッド ハードウェアが搭載されている場合のみ利用可能) |
| 入力 | ms-settings:typing |
| USB | ms-settings:usb |
| ホイール | ms-settings:wheel (Dial がペアリングされている場合のみ利用可能) |
| 同期電話 | ms-settings:mobile-devices  |

## <a name="ease-of-access"></a>コンピューターの簡単操作

|［設定］ページ| URI |
|-------------|-----|
| オーディオ | ms-settings:easeofaccess-audio |
| クローズド キャプション | ms-settings:easeofaccess-closedcaptioning |
| カラー フィルター | ms-設定: easeofaccess-colorfilter |
| Display | ms-settings:easeofaccess-display |
| 視線制御 | ms-settings:easeofaccess-eyecontrol |
| フォント | ms-settings:fonts |
| ハイ コントラスト | ms-settings:easeofaccess-highcontrast |
| ホログラフィック ヘッドセット | ms-settings:holographic-headset (ホログラフィック ハードウェアが必要) |
| キーボード | ms-settings:easeofaccess-keyboard |
| 拡大鏡 | ms-settings:easeofaccess-magnifier |
| マウス | ms-settings:easeofaccess-mouse |
| ナレーター | ms-settings:easeofaccess-narrator |
| その他のオプション | ms-settings:easeofaccess-otheroptions |
| 音声認識 | ms-settings:easeofaccess-speechrecognition |

## <a name="extras"></a>Extras

|[設定] ページ| URI |
|-------------|-----|
| Extras | ms-settings:extras (第三者などによる「設定アプリ」がインストールされている場合のみ利用可能) |

## <a name="gaming"></a>ゲーム

|［設定］ページ| URI |
|-------------|-----|
| ブロードキャスト | ms-settings:gaming-broadcasting |
| ゲーム バー | ms-settings:gaming-gamebar |
| ゲーム DVR | ms-settings:gaming-gamedvr |
| ゲーム モード | ms-settings:gaming-gamemode |
| ゲームの全画面表示の再生 | ms-settings:quietmomentsgame |
| TruePlay | ms-settings:gaming-trueplay |
| Xbox ネットワーク | ms-settings:gaming-xboxnetworking |

## <a name="home-page"></a>ホーム ページ

|[設定] ページ| URI |
|-------------|-----|
| 設定ホーム ページ | ms-settings: |


## <a name="network--internet"></a>ネットワークとインターネット

|[設定] ページ| URI |
|-------------|-----|
| 機内モード | ms-settings:network-airplanemode (Windows 8.x では ms-settings:proximity を使用する) |
| 携帯ネットワークと SIM | ms-settings:network-cellular |
| データ使用状況 | ms-settings:datausage |
| ダイヤルアップ | ms-settings:network-dialup |
| DirectAccess | ms-settings:network-directaccess (DirectAccess が有効な場合にのみ利用可能) |
| イーサネット | ms-settings:network-ethernet |
| 既知のネットワークの管理 | ms-settings:network-wifisettings |
| モバイル ホットスポット | ms-settings:network-mobilehotspot |
| NFC | ms-settings:nfctransactions |
| プロキシ | ms-settings:network-proxy |
| 状態 | ms-settings:network-status |
| VPN | ms-settings:network-vpn |
| Wi-Fi | ms-settings:network-wifi (デバイスに wifi アダプターがある場合にのみ利用可能) |
| Wi-Fi 通話 | ms-settings:network-wificalling (Wi-Fi 通話が有効な場合のみ利用可能) |

## <a name="personalization"></a>個人用設定

|［設定］ページ| URI |
|-------------|-----|
| 背景 | ms-settings:personalization-background |
| スタート時にどのフォルダを表示するかを選択する | ms-settings:personalization-start-places |
| 画面の色 | ms-settings:personalization-colors |
| 概要 | ms-settings:personalization-glance |
| ロック画面 | ms-settings:lockscreen |
| ナビゲーション バー | ms-settings:personalization-navbar |
| 個人用設定 (カテゴリ) | ms-settings:personalization |
| スタート | ms-settings:personalization-start |
| タスク バー | ms-settings:taskbar |
| テーマ | ms-settings:themes |

## <a name="phone"></a>Phone

|[設定] ページ| URI |
|-------------|-----|
| 同期電話 | ms-settings:mobile-devices  |

## <a name="privacy"></a>Privacy

|[設定] ページ| URI |
|-------------|-----|
| アクセサリ用アプリ | ms-settings:privacy-accessoryapps |
| アカウント情報 | ms-settings:privacy-accountinfo |
| アクティビティの履歴 | ms-settings:privacy-activityhistory |
| 広告識別子 | ms-settings:privacy-advertisingid |
| アプリの診断 | ms-settings:privacy-appdiagnostics |
| ファイルの自動ダウンロード | ms-settings:privacy-automaticfiledownloads |
| バックグラウンド アプリ | ms-settings:privacy-backgroundapps |
| カレンダー | ms-settings:privacy-calendar |
| 通話履歴 | ms-settings:privacy-callhistory |
| カメラ | ms-settings:privacy-webcam |
| 連絡先 | ms-settings:privacy-contacts |
| ドキュメント | ms-settings:privacy-documents |
| Email | ms-settings:privacy-email |
| アイ トラッカー | ms-settings:privacy-eyetracker (eyetracker ハードウェアが必要) |
| フィードバックと診断 | ms-settings:privacy-feedback |
| ファイル システム | ms-settings:privacy-broadfilesystemaccess |
| 全般的な情報 | ms-settings:privacy-general |
| 位置情報 | ms-settings:privacy-location |
| メッセージング | ms-settings:privacy-messaging |
| マイク | ms-settings:privacy-microphone |
| モーション | ms-settings:privacy-motion |
| 通知 | ms-settings:privacy-notifications |
| その他のデバイス | ms-settings:privacy-customdevices |
| ピクチャ | ms-settings:privacy-pictures |
| 電話での通話 | ms-settings:privacy-phonecall |
| 無線 | ms-settings:privacy-radios |
| 音声認識、手描き入力、入力の設定 |ms-settings:privacy-speechtyping |
| タスク | ms-settings:privacy-tasks |
| ビデオ | ms-settings:privacy-videos |

## <a name="surface-hub"></a>Surface Hub

|［設定］ページ| URI |
|-------------|-----|
| アカウント | ms-settings:surfacehub-accounts |
| セッションのクリーンアップ | ms-settings:surfacehub-sessioncleanup |
| チーム会議 | ms-settings:surfacehub-calling |
| チーム デバイス管理 | ms-settings:surfacehub-devicemanagenent |
| ようこそ画面 | ms-settings:surfacehub-welcome |

## <a name="system"></a>System

|[設定] ページ| URI |
|-------------|-----|
| バージョン情報 | ms-settings:about |
| ディスプレイの詳細設定 | ms-settings:display-advanced (詳細オプションをサポートするデバイスでのみ利用可能) |
| バッテリー節約機能 | ms-settings:batterysaver (タブレットなど、バッテリーを搭載したデバイスでのみ利用可能) |
| バッテリー節約機能の設定 | ms-settings:batterysaver-settings (タブレットなど、バッテリーを搭載したデバイスでのみ利用可能) |
| バッテリーの使用状況 | ms-settings:batterysaver-usagedetails (タブレットなど、バッテリーを搭載したデバイスでのみ利用可能) |
| 表示 | ms-settings:display |
| 既定の保存場所 | ms-settings:savelocations |
| 表示 | ms-settings:screenrotation |
| ディスプレイの複製 | ms-settings:quietmomentspresentation |
| これらの時間帯 | ms-settings:quietmomentsscheduled |
| 暗号化 | ms-settings:deviceencryption |
| 集中モード | ms-settings:quiethours <br> ms-settings:quietmomentshome |
| グラフィック設定 | ms-settings:display-advancedgraphics (詳細グラフィック オプションをサポートするデバイスでのみ利用可能) |
| メッセージング | ms-settings:messaging |
| マルチタスク | ms-settings:multitasking |
| 夜間モード設定 | ms-settings:nightlight |
| Phone | ms-settings:phone-defaultapps |
| この PC へのプロジェクション | ms-settings:project |
| 共有エクスペリエンス | ms-settings:crossdevice |
| タブレット モード | ms-settings:tabletmode |
| タスク バー | ms-settings:taskbar |
| 通知とアクション | ms-settings:notifications |
| リモート デスクトップ | ms-settings:remotedesktop |
| スマートフォン | ms-settings:phone |
| 電源とスリープ | ms-settings:powersleep |
| サウンド | ms-settings:sounds |
| Storage | ms-settings:storagesense |
| ストレージ センサー | ms-settings:storagepolicies |

## <a name="time-and-language"></a>時刻と言語

|[設定] ページ| URI |
|-------------|-----|
| 日付と時刻 | ms-settings:dateandtime |
| 日本 IME の設定 | ms-settings:regionlanguage-jpnime (Microsoft 日本語入力方式エディターがインストールされている場合に利用可能) |
| Pinyin IME の設定 | ms-settings:regionlanguage-chsime-pinyin (Microsoft Pinyin 入力方式エディターがインストールされている場合に利用可能) |
| 地域と言語 | ms-settings:regionlanguage |
| 音声認識の言語 | ms-settings:speech |
| Wubi IME の設定  | ms-settings:regionlanguage-chsime-wubi (Microsoft Wubi 入力方式エディターがインストールされている場合に利用可能) |

## <a name="update--security"></a>更新とセキュリティ

|［設定］ページ| URI |
|-------------|-----|
| ライセンス認証 | ms-settings:activation |
| バックアップ | ms-settings:backup |
| 配信の最適化 | ms-settings:delivery-optimization |
| デバイスの検索 | ms-settings:findmydevice |
| 開発者向け | ms-settings:developers |
| 回復 | ms-settings:recovery |
| トラブルシューティング | ms-settings:troubleshoot |
| Windows のセキュリティ | ms-settings:windowsdefender |
| Windows Insider Program | ms-settings:windowsinsider(ユーザーが WIP に登録されている場合にのみ存在) |
| Windows Update | ms-settings:windowsupdate<br>ms-settings:windowsupdate-action |
| Windows Update - 詳細オプション | ms-settings:windowsupdate-options |
| Windows Update - 再起動オプション | ms-settings:windowsupdate-restartoptions |
| Windows Update - 更新履歴の表示 | ms-settings:windowsupdate-history |

## <a name="user--accounts"></a>ユーザー アカウント

|[設定] ページ| URI |
|-------------|-----|
| プロビジョニング | ms-settings:workplace-provisioning (企業でプロビジョニング パッケージが展開されている場合のみ利用可能) |
| プロビジョニング | ms-settings:workplace-provisioning (企業でプロビジョニング パッケージが展開されている場合にモバイルでのみ利用可能) |
| Windows Anywhere | ms-settings:windowsanywhere (デバイスが Windows Anywhere に対応している必要がある) |
