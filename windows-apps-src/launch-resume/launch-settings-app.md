---
author: TylerMSFT
title: "Windows 設定アプリの起動"
description: "アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。"
ms.assetid: C84D4BEE-1FEE-4648-AD7D-8321EAC70290
ms.author: twhitney
ms.date: 06/12/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2a30e14f7c275c48f52253157fc9c67bf05d259e
ms.sourcegitcommit: 00c3f5a1208bd0125f5b275f972cf2a82d8eb9b6
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/13/2017
---
# <a name="launch-the-windows-settings-app"></a>Windows 設定アプリの起動

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

**重要な API**

-   [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**PreferredApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**DesiredRemainingView**](https://msdn.microsoft.com/library/windows/apps/dn298314)

アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、**ms-settings:** URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。

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

また、アプリで [**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) メソッドを呼び出し、コードで**設定**アプリを起動することもできます。 次の例は、`ms-settings:privacy-webcam` URI を使って、カメラのプライバシー設定ページを起動する方法を示しています。

```cs
bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
```

上記のコードでは、カメラのプライバシー設定ページが起動されます。

![カメラのプライバシー設定。](images/privacyawarenesssettingsapp.png)

URI の起動について詳しくは、「[URI に応じた既定のアプリの起動](launch-default-app.md)」をご覧ください。

## <a name="ms-settings-uri-scheme-reference"></a>ms-settings: URI スキーム リファレンス

設定アプリのさまざまなページ開くには、次の URI を使います。

> 設定ページを使用できるかどうかは、Windows の SKU によって異なることに注意してください。 デスクトップの Windows 10 で利用可能な設定ページのすべてを Windows 10 Mobile で利用できるとは限りません。またその逆も同様です。 注の列には、ページが利用可能となるための追加の要件も記されています。

<table border="1">
 <tr>
  <th>カテゴリ</th>
  <th>設定ページ</th>
  <th>URI</th>
  <th>注</th>
 </tr>
 <tr>
  <td rowspan="6">アカウント</td>
  <td>職場または学校にアクセスする</td>
  <td>ms-settings:workplace</td>
  <td></td>
 </tr>
 <tr>
  <td>メール & アプリのアカウント</td>
  <td>ms-settings:emailandaccounts</td>
  <td></td>
 </tr>
 <tr>
  <td>家族とその他のユーザー</td>
  <td>ms-settings:otherusers</td>
  <td></td>
 </tr>
 <tr>
  <td>サインイン オプション</td>
  <td>ms-settings:signinoptions</td>
  <td></td>
 </tr>
 <tr>
  <td>設定の同期</td>
  <td>ms-settings:sync</td>
  <td></td>
 </tr>
 <tr>
  <td>ユーザーの情報</td>
  <td>ms-settings:yourinfo</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="4">アプリ</td>
  <td>アプリと機能</td>
  <td>ms-settings:appsfeatures</td>
  <td></td>
 </tr>
 <tr>
  <td>Web サイト用のアプリ</td>
  <td>ms-settings:appsforwebsites</td>
  <td></td>
 </tr>
 <tr>
  <td>既定のアプリ</td>
  <td>ms-settings:defaultapps</td>
  <td></td>
 </tr>
 <tr>
  <td>アプリと機能</td>
  <td>ms-settings:optionalfeatures</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="12">デバイス</td>
  <td>USB</td>
  <td>ms-settings:usb</td>
  <td></td>
 </tr>
 <tr>
  <td>オーディオと音声認識</td>
  <td>ms-settings:holographic-audio</td>
  <td>Mixed Reality ポータル アプリ (Windows ストアで入手可能) がインストールされている場合のみ利用可能</td>
 </tr>
 <tr>
  <td>自動再生</td>
  <td>ms-settings:autoplay</td>
  <td></td>
 </tr>
 <tr>
  <td>タッチパッド</td>
  <td>ms-settings:devices-touchpad</td>
  <td>タッチパッドのハードウェアが存在する場合にのみ利用可能</td>
 </tr>
 <tr>
  <td>ペンと Windows Ink</td>
  <td>ms-settings:pen</td>
  <td></td>
 </tr>
 <tr>
  <td>プリンターとスキャナー</td>
  <td>ms-settings:printers</td>
  <td></td>
 </tr>
 <tr>
  <td>入力</td>
  <td>ms-settings:typing</td>
  <td></td>
 </tr>
 <tr>
  <td>ホイール</td>
  <td>ms-settings:wheel</td>
  <td>Dial がペアリングされている場合のみ利用可能</td>
 </tr>
 <tr>
  <td>既定のカメラ</td>
  <td>ms-settings:camera</td>
  <td></td>
 </tr>
 <tr>
  <td>Bluetooth</td>
  <td>ms-settings:bluetooth</td>
  <td></td>
 </tr>
 <tr>
  <td>接続されたデバイス</td>
  <td>ms-settings:connecteddevices</td>
  <td></td>
 </tr>
 <tr>
  <td>マウスとタッチパッド</td>
  <td>ms-settings:mousetouchpad</td>
  <td>タッチパット設定は、タッチパッドが搭載されているデバイスでのみ利用可能</td>
 </tr>
 <tr>
  <td rowspan="7">コンピューターの簡単操作</td>
  <td>ナレーター</td>
  <td>ms-settings:easeofaccess-narrator</td>
  <td></td>
 </tr>
 <tr>
  <td>拡大鏡</td>
  <td>ms-settings:easeofaccess-magnifier</td>
  <td></td>
 </tr>
 <tr>
  <td>ハイ コントラスト</td>
  <td>ms-settings:easeofaccess-highcontrast</td>
  <td></td>
 </tr>
 <tr>
  <td>字幕</td>
  <td>ms-settings:easeofaccess-closedcaptioning</td>
  <td></td>
 </tr>
 <tr>
  <td>キーボード</td>
  <td>ms-settings:easeofaccess-keyboard</td>
  <td></td>
 </tr>
 <tr>
  <td>マウス</td>
  <td>ms-settings:easeofaccess-mouse</td>
  <td></td>
 </tr>
 <tr>
  <td>その他のオプション</td>
  <td>ms-settings:easeofaccess-otheroptions</td>
 </tr>
 <tr>
  <td>Extras</td>
  <td>Extras</td>
  <td>ms-settings:extras</td>
  <td>(サード パーティなどによる) "設定アプリ" がインストールされている場合のみ利用可能</td>
 </tr>
 <tr>
  <td rowspan="4">ゲーム</td>
  <td>ブロードキャスト</td>
  <td>ms-settings:gaming-broadcasting</td>
  <td></td>
 </tr>
 <tr>
  <td>ゲーム バー</td>
  <td>ms-settings:gaming-gamebar</td>
  <td></td>
 </tr>
 <tr>
  <td>ゲーム DVR</td>
  <td>ms-settings:gaming-gamedvr</td>
  <td></td>
 </tr>
 <tr>
  <td>ゲーム モード</td>
  <td>ms-settings:gaming-gamemode</td>
  <td></td>
 </tr>
 <tr>
  <td>ホーム ページ</td>
  <td>設定のランディング ページ</td>
  <td>ms-settings:</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="10">ネットワークとインターネット</td>
  <td>イーサネット</td>
  <td>ms-settings:network-ethernet</td>
  <td></td>
 </tr>
 <tr>
  <td>VPN</td>
  <td>ms-settings:network-vpn</td>
  <td></td>
 </tr>
 <tr>
  <td>ダイヤルアップ</td>
  <td>ms-settings:network-dialup</td>
  <td></td>
 </tr>
 <tr>
  <td>DirectAccess</td>
  <td>ms-settings:network-directaccess</td>
  <td>DirectAccess が有効な場合のみ利用可能</td>
 </tr>
 <tr>
  <td>Wi-Fi 通話</td>
  <td>ms-settings:network-wificalling</td>
  <td>Wi-Fi 通話が有効な場合のみ利用可能</td>
 </tr>
 <tr>
  <td>データ使用状況</td>
  <td>ms-settings:datausage</td>
  <td></td>
 </tr>
 <tr>
  <td>携帯ネットワーク & SIM</td>
  <td>ms-settings:network-cellular</td>
  <td></td>
 </tr>
 <tr>
  <td>モバイル ホットスポット</td>
  <td>ms-settings:network-mobilehotspot</td>
  <td></td>
 </tr>
 <tr>
  <td>プロキシ</td>
  <td>ms-settings:network-proxy</td>
  <td></td>
 </tr>
 <tr>
  <td>状態</td>
  <td>ms-settings:network-status</td>
  <td></td>
 </tr>
 <tr>
  <td>既知のネットワークの管理</td>
  <td>ms-settings:network-wifisettings</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="3">ネットワークとワイヤレス</td>
  <td>NFC</td>
  <td>ms-settings:nfctransactions</td>
  <td></td>
 </tr>
 <tr>
  <td>Wi-Fi</td>
  <td>ms-settings:network-wifi</td>
  <td>デバイスに WiFi アダプターがある場合のみ利用可能</td>
 </tr>
 <tr>
  <td>機内モード</td>
  <td>ms-settings:network-airplanemode</td>
  <td>Windows 8.x では ms-settings:proximity を使用する</td>
 </tr>
 <tr>
  <td rowspan="10">パーソナル設定</td>
  <td>スタート</td>
  <td>ms-settings:personalization-start</td>
  <td></td>
 </tr>
 <tr>
  <td>テーマ</td>
  <td>ms-settings:themes</td>
  <td></td>
 </tr>
 <tr>
  <td>概要</td>
  <td>ms-settings:personalization-glance</td>
  <td></td>
 </tr>
 <tr>
  <td>ナビゲーション バー</td>
  <td>ms-settings:personalization-navbar</td>
  <td></td>
 </tr>
 <tr>
  <td>個人用設定 (カテゴリ)</td>
   <td>ms-settings:personalization</td>
   <td></td>
 </tr>
 <tr>
  <td>背景</td>
   <td>ms-settings:personalization-background</td>
   <td></td>
 </tr>
 <tr>
  <td>画面の色</td>
   <td>ms-settings:personalization-colors</td>
   <td></td>
 </tr>
 <tr>
  <td>サウンド</td>
   <td>ms-settings:sounds</td>
   <td></td>
 </tr>
 <tr>
  <td>ロック画面</td>
   <td>ms-settings:lockscreen</td>
   <td></td>
 </tr>
 <tr>
  <td>タスク バー</td>
   <td>ms-settings:taskbar</td>
   <td></td>
 </tr>
 <tr>
  <td rowspan="22">プライバシー</td>
  <td>アプリの診断</td>
   <td>ms-settings:privacy-appdiagnostics</td>
   <td></td>
 </tr>
 <tr>
  <td>通知</td>
   <td>ms-settings:privacy-notifications</td>
   <td></td>
 </tr>
 <tr>
  <td>タスク</td>
   <td>ms-settings:privacy-tasks</td>
   <td></td>
 </tr>
 <tr>
  <td>全般</td>
   <td>ms-settings:privacy-general</td>
   <td></td>
 </tr>
 <tr>
  <td>アクセサリ用アプリ</td>
   <td>ms-settings:privacy-accessoryapps</td>
   <td></td>
 </tr>
 <tr>
  <td>広告識別子</td>
   <td>ms-settings:privacy-advertisingid</td>
   <td></td>
 </tr>
 <tr>
  <td>通話</td>
   <td>ms-settings:privacy-phonecall</td>
   <td></td>
 </tr>
 <tr>
  <td>場所</td>
   <td>ms-settings:privacy-location</td>
   <td></td>
 </tr>
 <tr>
  <td>カメラ</td>
   <td>ms-settings:privacy-webcam</td>
   <td></td>
 </tr>
 <tr>
  <td>マイク</td>
   <td>ms-settings:privacy-microphone</td>
   <td></td>
 </tr>
 <tr>
  <td>モーション</td>
   <td>ms-settings:privacy-motion</td>
   <td></td>
 </tr>
 <tr>
  <td>音声認識、手描き入力、入力の設定</td>
   <td>ms-settings:privacy-speechtyping</td>
   <td></td>
 </tr>
 <tr>
  <td>アカウント情報</td>
   <td>ms-settings:privacy-accountinfo</td>
   <td></td>
 </tr>
 <tr>
  <td>連絡先</td>
   <td>ms-settings:privacy-contacts</td>
   <td></td>
 </tr>
 <tr>
  <td>カレンダー</td>
   <td>ms-settings:privacy-calendar</td>
   <td></td>
 </tr>
 <tr>
  <td>通話履歴</td>
   <td>ms-settings:privacy-callhistory</td>
   <td></td>
 </tr>
 <tr>
  <td>メール</td>
  <td>ms-settings:privacy-email</td>
  <td></td>
 </tr>
 <tr>
  <td>メッセージング</td>
    <td>ms-settings:privacy-messaging</td>
  <td></td>
 </tr>
 <tr>
  <td>無線</td>
    <td>ms-settings:privacy-radios</td>
  <td></td>
 </tr>
 <tr>
  <td>バックグラウンド アプリ</td>
    <td>ms-settings:privacy-backgroundapps</td>
  <td></td>
 </tr>
 <tr>
  <td>他のデバイス</td>
    <td>ms-settings:privacy-customdevices</td>
  <td></td>
 </tr>
 <tr>
  <td>フィードバックと診断</td>
    <td>ms-settings:privacy-feedback</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="5">Surface Hub</td>
  <td>アカウント</td>
    <td>ms-settings:surfacehub-accounts</td>
      <td></td>
  </tr>
  <tr>
    <td>チーム会議</td>
      <td>ms-settings:surfacehub-calling</td>
      <td></td>
  </tr>
  <tr>
    <td>チーム デバイス管理</td>
      <td>ms-settings:surfacehub-devicemanagenent</td>
      <td></td>
  </tr>
  <tr>
    <td>セッションのクリーンアップ</td>
      <td>ms-settings:surfacehub-sessioncleanup</td>
      <td></td>
  </tr>
  <tr>
    <td>ようこそ画面</td>
      <td>ms-settings:surfacehub-welcome</td>
      <td></td>
  </tr>
    <td rowspan="19">システム</td>
    <td>共有エクスペリエンス</td>
      <td>ms-settings:crossdevice</td>
    <td></td>
 </tr>
 <tr>
  <td>ディスプレイ</td>
    <td>ms-settings:display</td>
  <td></td>
 </tr>
 <tr>
  <td>マルチタスク</td>
    <td>ms-settings:multitasking</td>
  <td></td>
 </tr>
 <tr>
  <td>この PC へのプロジェクション</td>
    <td>ms-settings:project</td>
  <td></td>
 </tr>
 <tr>
  <td>タブレット モード</td>
    <td>ms-settings:tabletmode</td>
  <td></td>
 </tr>
 <tr>
  <td>タスク バー</td>
    <td>ms-settings:taskbar</td>
  <td></td>
 </tr>
 <tr>
  <td>電話</td>
    <td>ms-settings:phone-defaultapps</td>
  <td></td>
 </tr>
 <tr>
  <td>ディスプレイ</td>
    <td>ms-settings:screenrotation</td>
  <td></td>
 </tr>
 <tr>
  <td>通知とアクション</td>
    <td>ms-settings:notifications</td>
  <td></td>
 </tr>
 <tr>
  <td>電話</td>
    <td>ms-settings:phone</td>
  <td></td>
 </tr>
 <tr>
  <td>メッセージング</td>
    <td>ms-settings:messaging</td>
  <td></td>
 </tr>
 <tr>
  <td>バッテリー節約機能</td>
  <td>ms-settings:batterysaver</td>
  <td>タブレットなど、バッテリーを搭載したデバイスでのみ利用可能</td>
 </tr>
 <tr>
  <td>バッテリーの使用状況</td>
  <td>ms-settings:batterysaver-usagedetails</td>
  <td>タブレットなど、バッテリーを搭載したデバイスでのみ利用可能</td>
 </tr>
 <tr>
  <td>電源とスリープ</td>
  <td>ms-settings:powersleep</td>
  <td></td>
 </tr>
 <tr>
  <td>バージョン情報</td>
    <td>ms-settings:about</td>
  <td></td>
 </tr>
 <tr>
  <td>ストレージ</td>
    <td>ms-settings:storagesense</td>
  <td></td>
 </tr>
 <tr>
  <td>ストレージ センサー</td>
    <td>ms-settings:storagepolicies</td>
  <td></td>
 </tr>
 <tr>
  <td>暗号化</td>
    <td>ms-settings:deviceencryption</td>
  <td></td>
 </tr>
 <tr>
  <td>オフライン マップ</td>
    <td>ms-settings:maps</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="5">時刻と言語</td>
  <td>日付と時刻</td>
    <td>ms-settings:dateandtime</td>
  <td></td>
 </tr>
 <tr>
  <td>地域と言語</td>
    <td>ms-settings:regionlanguage</td>
  <td></td>
 </tr>
 <tr>
     <td>音声認識の言語</td>
     <td>ms-settings:speech</td>
     <td></td>
 </tr>
 <tr>
     <td>Pinyin キーボード</td>
     <td>ms-settings:regionlanguage-chsime-pinyin</td>
     <td>Microsoft Pinyin IME がインストールされている場合に利用可能</td>
 </tr>
 <tr>
     <td>Wubi 入力モード</td>
     <td>ms-settings:regionlanguage-chsime-wubi</td>
     <td>Microsoft Wubi IME がインストールされている場合に利用可能</td>
 </tr>
 <tr>
  <td rowspan="13">更新とセキュリティ</td>
  <td>Windows Hello セットアップ</td>
    <td>ms-settings:signinoptions-launchfaceenrollment<br>ms-settings:signinoptions-launchfingerprintenrollment</td>
  </tr>
  <tr>
    <td>バックアップ</td>
      <td>ms-settings:backup</td>
    <td></td>
 </tr>
 <tr>
  <td>デバイスの検索</td>
    <td>ms-settings:findmydevice</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Insider Program</td>
  <td>ms-settings:windowsinsider</td>
  <td>ユーザーが Windows Insider Program に登録されている場合のみ利用可能</td>
 </tr>
 <tr>
  <td>Windows Update</td>
  <td>ms-settings:windowsupdate</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Update</td>
    <td>ms-settings:windowsupdate-history</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Update</td>
    <td>ms-settings:windowsupdate-options</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Update</td>
    <td>ms-settings:windowsupdate-restartoptions</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Update</td>
    <td>ms-settings:windowsupdate-action</td>
  <td></td>
 </tr>
 <tr>
  <td>ライセンス認証</td>
    <td>ms-settings:activation</td>
  <td></td>
 </tr>
 <tr>
  <td>回復</td>
    <td>ms-settings:recovery</td>
  <td></td>
 </tr>
 <tr>
  <td>トラブルシューティング</td>
    <td>ms-settings:troubleshoot</td>
  <td></td>
 </tr>
 <tr>
  <td>Windows Defender</td>
    <td>ms-settings:windowsdefender</td>
  <td></td>
 </tr>
 <tr>
  <td>開発者向け</td>
    <td>ms-settings:developers</td>
  <td></td>
 </tr>
 <tr>
  <td rowspan="2">ユーザー アカウント</td>
  <td>Windows Anywhere</td>
  <td>ms-settings:windowsanywhere</td>
  <td>デバイスが Windows Anywhere に対応している必要がある</td>
 </tr>
 <tr>
  <td>プロビジョニング</td>
  <td>ms-settings:workplace-provisioning</td>
  <td>企業でプロビジョニング パッケージが展開されている場合のみ利用可能</td>
 </tr>
</table><br/>  
