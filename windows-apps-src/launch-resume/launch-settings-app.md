---
author: TylerMSFT
title: "Windows 設定アプリの起動"
description: "アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。"
ms.assetid: C84D4BEE-1FEE-4648-AD7D-8321EAC70290
ms.sourcegitcommit: 3cf9dd4ab83139a2b4b0f44a36c2e57a92900903
ms.openlocfilehash: e52a4245e8697a68bfc5c5605dc54e5ea510c662

---

# Windows 設定アプリの起動


\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]


**重要な API**

-   [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)

アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、**ms-settings:** URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。

設定アプリの起動は、個人データにアクセスするアプリの開発の重要な部分です。 アプリが機密性の高いリソースにアクセスできない場合、そのリソースのプライバシー設定への便利なリンクをユーザーに提供することをお勧めします。 詳しくは、「[個人データにアクセスするアプリのガイドライン](https://msdn.microsoft.com/library/windows/apps/hh768223)」をご覧ください。

## 設定アプリを起動する方法


プライバシー設定でアプリが機密性の高いリソースにアクセスすることを許可していない場合は、**設定**アプリのプライバシー設定へのリンクを示すことをお勧めします。 これにより、ユーザーが設定を変更することが容易になります。

直接、**設定**アプリを起動するには、次の例に示されているように `ms-settings:` URI スキームを使います。

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

また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。

```cs
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
```

次の例は、`ms-settings:privacy-webcam` URI を使って、カメラのプライバシー設定ページを起動する方法を示しています。

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

URI の起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。

## ms-settings: URI スキーム リファレンス


設定アプリのさまざまなページ開くには、次の URI を使います。 "サポートされている SKU" 列は、Windows 10 デスクトップ エディション (Home、Pro、Enterprise、Education) と Windows 10 Mobile のいずれか、またはその両方に設定ページがあるかどうかを示しています。

| カテゴリ           | 設定ページ                          | サポートされている SKU | URI                                       |
|--------------------|----------------------------------------|----------------|-------------------------------------------|
| ホーム ページ          | 設定のランディング ページ              | 両方           | ms-settings:                              |
| システム             | ディスプレイ                                | 両方           | ms-settings:screenrotation                |
|                    | 通知とアクション                | 両方           | ms-settings:notifications                 |
|                    | 電話                                  | モバイルのみ    | ms-settings:phone                         |
|                    | メッセージング                              | モバイルのみ    | ms-settings:messaging                     |
|                    | バッテリー節約機能                          | タブレットなどのバッテリを備えたデバイス上のモバイルおよびデスクトップ    | ms-settings:batterysaver                  |
|                    | バッテリー節約機能/バッテリー節約機能の設定 | タブレットなどのバッテリを備えたデバイス上のモバイルおよびデスクトップ | ms-settings:batterysaver-settings         |
|                    | バッテリー節約機能/バッテリーの使用状況            | タブレットなどのバッテリを備えたデバイス上のモバイルおよびデスクトップ    | ms-settings:batterysaver-usagedetails     |
|                    | 電源とスリープ                          | デスクトップのみ   | ms-settings:powersleep                    |
|                    | デスクトップ: バージョン情報                         | 両方           | ms-settings:deviceencryption              |
|                    |                                        |                |                                           |
|                    | モバイル: デバイスの暗号化              |                |                                           |
|                    | オフライン マップ                           | 両方           | ms-settings:maps                          |
|                    | バージョン情報                                  | 両方           | ms-settings:about                         |
| デバイス            | 既定のカメラ                         | モバイルのみ    | ms-settings:camera                        |
|                    | Bluetooth                              | デスクトップのみ   | ms-settings:bluetooth                     |
|                    | マウスとタッチパッド                       | 両方           | ms-settings:mousetouchpad                 |
|                    | NFC                                    | 両方           | ms-settings:nfctransactions               |
| ネットワークとワイヤレス | Wi-Fi                                  | 両方           | ms-settings:network-wifi                  |
|                    | 機内モード                          | 両方           | ms-settings:network-airplanemode          |
| ネットワークとインターネット | データ使用状況                             | 両方           | ms-settings:datausage                     |
|                    | 携帯ネットワーク & SIM                         | 両方           | ms-settings:network-cellular              |
|                    | モバイル ホットスポット                         | 両方           | ms-settings:network-mobilehotspot         |
|                    | プロキシ                                  | 両方           | ms-settings:network-proxy                 |
| 個人用設定    | パーソナル設定 (カテゴリ)             | 両方           | ms-settings:personalization               |
|                    | 背景                             | デスクトップのみ   | ms-settings:personalization-background    |
|                    | カラー                                 | 両方           | ms-settings:personalization-colors        |
|                    | サウンド                                 | モバイルのみ    | ms-settings:sounds                        |
|                    | ロック画面                            | 両方           | ms-settings:lockscreen                    |
| アカウント           | 電子メールとアカウント                | 両方           | ms-settings:emailandaccounts              |
|                    | 職場のアクセス                            | 両方           | ms-settings:workplace                     |
|                    | 設定の同期                     | 両方           | ms-settings:sync                          |
| 時刻と言語  | 日付と時刻                            | 両方           | ms-settings:dateandtime                   |
|                    | 地域と言語                      | デスクトップのみ   | ms-settings:regionlanguage                |
| コンピューターの簡単操作     | ナレーター                               | 両方           | ms-settings:easeofaccess-narrator         |
|                    | 拡大鏡                              | 両方           | ms-settings:easeofaccess-magnifier        |
|                    | ハイ コントラスト                          | 両方           | ms-settings:easeofaccess-highcontrast     |
|                    | 字幕                        | 両方           | ms-settings:easeofaccess-closedcaptioning |
|                    | キーボード                               | 両方           | ms-settings:easeofaccess-keyboard         |
|                    | マウス                                  | 両方           | ms-settings:easeofaccess-mouse            |
|                    | その他のオプション                          | 両方           | ms-settings:easeofaccess-otheroptions     |
| プライバシー            | 位置情報                               | 両方           | ms-settings:privacy-location              |
|                    | カメラ                                 | 両方           | ms-settings:privacy-webcam                |
|                    | マイク                             | 両方           | ms-settings:privacy-microphone            |
|                    | アニメーション                                 | 両方           | ms-settings:privacy-motion                |
|                    | 音声認識、手書き入力、タイピング                | 両方           | ms-settings:privacy-speechtyping          |
|                    | アカウント情報                           | 両方           | ms-settings:privacy-accountinfo           |
|                    | 連絡先                               | 両方           | ms-settings:privacy-contacts              |
|                    | カレンダー                               | 両方           | ms-settings:privacy-calendar              |
|                    | 通話履歴                           | 両方           | ms-settings:privacy-callhistory           |
|                    | メール                                  | 両方           | ms-settings:privacy-email                 |
|                    | メッセージング                              | 両方           | ms-settings:privacy-messaging             |
|                    | 無線                                 | 両方           | ms-settings:privacy-radios                |
|                    | バックグラウンド アプリ                        | 両方           | ms-settings:privacy-backgroundapps        |
|                    | 他のデバイス                          | 両方           | ms-settings:privacy-customdevices         |
|                    | フィードバックと診断                 | 両方           | ms-settings:privacy-feedback              |
| 更新とセキュリティ  | 開発者向け                         | 両方           | ms-settings:developers                    |
 



<!--HONumber=Jun16_HO4-->


