---
author: TylerMSFT
title: "Windows 設定アプリの起動"
description: "アプリから Windows 設定アプリを起動する方法について説明します。 ここでは、ms-settings URI スキームについて説明します。 Windows 設定アプリを起動して特定の設定ページを表示するには、この URI スキームを使います。"
ms.assetid: C84D4BEE-1FEE-4648-AD7D-8321EAC70290
translationtype: Human Translation
ms.sourcegitcommit: 1135feec72510e6cbe955161ac169158a71097b9
ms.openlocfilehash: f762d7eb70a0e9119f32350a815691109f994c75

---

# <a name="launch-the-windows-settings-app"></a>Windows 設定アプリの起動

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

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

設定アプリのさまざまなページ開くには、次の URI を使います。 "サポートされている SKU" 列は、Windows 10 デスクトップ エディション (Home、Pro、Enterprise、Education) と Windows 10 Mobile のいずれか、またはその両方に設定ページがあるかどうかを示しています。

<table border="1">
    <tr>
        <th>カテゴリ</th>
        <th>設定ページ</th>
        <th>サポートされている SKU</th>
        <th>URI</th>
    </tr>
    <tr>
        <td>ホーム ページ</td>
        <td>設定のランディング ページ</td>
        <td>両方</td>
        <td>ms-settings:</td>
    </tr>
    <tr>
        <td rowspan="10">システム</td>
        <td>ディスプレイ</td>
        <td>両方</td>
        <td>ms-settings:screenrotation</td>
    </tr>
    <tr>
        <td>通知とアクション</td>
        <td>両方</td>
        <td>ms-settings:notifications</td>
    </tr>
    <tr>
        <td>電話</td>
        <td>モバイルのみ</td>
        <td>ms-settings:phone</td>
    </tr>
    <tr>
        <td>メッセージング</td>
        <td>モバイルのみ</td>
        <td>ms-settings:messaging</td>
    </tr>
    <tr>
        <td>バッテリー節約機能</td>
        <td>両方<br>タブレットなど、バッテリを搭載したデバイスでのみ利用可能</td>
        <td>ms-settings:batterysaver</td>
    </tr>
    <tr>
        <td>バッテリーの使用状況</td>
        <td>両方<br>タブレットなど、バッテリを搭載したデバイスでのみ利用可能</td>
        <td>ms-settings:batterysaver-usagedetails</td>
    </tr>
    <tr>
        <td>電源とスリープ</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:powersleep</td>
    </tr>
    <tr>
        <td>バージョン情報</td>
        <td>両方</td>
        <td>ms-settings:about</td>
    </tr>
    <tr>
        <td>暗号化</td>
        <td>両方</td>
        <td>ms-settings:deviceencryption</td>
    </tr>
    <tr>
        <td>オフライン マップ</td>
        <td>両方</td>
        <td>ms-settings:maps</td>
    </tr>
    <tr>
        <td rowspan="4">デバイス</td>
        <td>既定のカメラ</td>
        <td>モバイルのみ</td>
        <td>ms-settings:camera</td>
    </tr>
    <tr>
        <td>Bluetooth</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:bluetooth</td>
    </tr>
    <tr>
        <td>接続されたデバイス</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:connecteddevices</td>
    </tr>
    <tr>
        <td>マウスとタッチパッド</td>
        <td>両方<br>タッチパット設定は、タッチパッドが搭載されているデバイスでのみ利用可能</td>
        <td>ms-settings:mousetouchpad</td>
    </tr>
    <tr>
        <td rowspan="3">ネットワークとワイヤレス</td>
        <td>NFC</td>
        <td>両方</td>
        <td>ms-settings:nfctransactions</td>
    </tr>
    <tr>
        <td>Wi-Fi</td>
        <td>両方</td>
        <td>ms-settings:network-wifi</td>
    </tr>
    <tr>
        <td>機内モード</td>
        <td>両方</td>
        <td>ms-settings:network-airplanemode</td>
    </tr>
    <tr>
        <td rowspan="5">ネットワークとインターネット</td>
        <td>データ使用状況</td>
        <td>両方</td>
        <td>ms-settings:datausage</td>
    </tr>
    <tr>
        <td>携帯ネットワーク & SIM</td>
        <td>両方</td>
        <td>ms-settings:network-cellular</td>
    </tr>
    <tr>
        <td>モバイルホットスポット</td>
        <td>両方</td>
        <td>ms-settings:network-mobilehotspot</td>
    </tr>
    <tr>
        <td>プロキシ</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:network-proxy</td>
    </tr>
    <tr>
        <td>状態</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:network-status</td>
    </tr>
    <tr>
        <td rowspan="5">個人用設定</td>
        <td>個人用設定 (カテゴリ)</td>
        <td>両方</td>
        <td>ms-settings:personalization</td>
    </tr>
    <tr>
        <td>背景</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:personalization-background</td>
    </tr>
    <tr>
        <td>カラー</td>
        <td>両方</td>
        <td>ms-settings:personalization-colors</td>
    </tr>
    <tr>
        <td>サウンド</td>
        <td>モバイルのみ </td>
        <td>ms-settings:sounds</td>
    </tr>
    <tr>
        <td>ロック画面</td>
        <td>両方</td>
        <td>ms-settings:lockscreen</td>
    </tr>
    <tr>
        <td rowspan="7">アカウント</td>
        <td>職場または学校にアクセスする</td>
        <td>両方</td>
        <td>ms-settings:workplace</td>
    </tr>
    <tr>
        <td>メール & アプリのアカウント</td>
        <td>両方</td>
        <td>ms-settings:emailandaccounts</td>
    </tr>
    <tr>
        <td>家族とその他のユーザー</td>
        <td>両方</td>
        <td>ms-settings:otherusers</td>
    </tr>
    <tr>
        <td>サインイン オプション</td>
        <td>両方</td>
        <td>ms-settings:signinoptions</td>
    </tr>
    <tr>
        <td>設定の同期</td>
        <td>両方</td>
        <td>ms-settings:sync</td>
    </tr>
    <tr>
        <td>他のユーザー</td>
        <td>両方</td>
        <td>ms-settings:otherusers</td>
    </tr>
    <tr>
        <td>ユーザーの情報</td>
        <td>両方</td>
        <td>ms-settings:yourinfo</td>
    </tr>
    <tr>
        <td rowspan="2">時刻と言語</td>
        <td>日付と時刻</td>
        <td>両方</td>
        <td>ms-settings:dateandtime</td>
    </tr>
    <tr>
        <td>地域と言語</td>
        <td>デスクトップのみ</td>
        <td>ms-settings:regionlanguage</td>
    </tr>
    <tr>
        <td rowspan="7">コンピューターの簡単操作</td>
        <td>ナレーター</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-narrator</td>
    </tr>
    <tr>
        <td>拡大鏡</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-magnifier</td>
    </tr>
    <tr>
        <td>ハイ コントラスト </td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-highcontrast</td>
    </tr>
    <tr>
        <td>字幕</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-closedcaptioning</td>
    </tr>
    <tr>
        <td>キーボード</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-keyboard</td>
    </tr>
    <tr>
        <td>マウス</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-mouse</td>
    </tr>
    <tr>
        <td>その他のオプション</td>
        <td>両方</td>
        <td>ms-settings:easeofaccess-otheroptions</td>
    </tr>
    <tr>
        <td rowspan="15">プライバシー</td>
        <td>位置情報</td>
        <td>両方</td>
        <td>ms-settings:privacy-location</td>
    </tr>
    <tr>
        <td>カメラ</td>
        <td>両方</td>
        <td>ms-settings:privacy-webcam</td>
    </tr>
    <tr>
        <td>マイク</td>
        <td>両方</td>
        <td>ms-settings:privacy-microphone</td>
    </tr>
    <tr>
        <td>アニメーション</td>
        <td>両方</td>
        <td>ms-settings:privacy-motion</td>
    </tr>
    <tr>
        <td>音声認識、手書き入力、タイピング</td>
        <td>両方</td>
        <td>ms-settings:privacy-speechtyping</td>
    </tr>
    <tr>
        <td>アカウント情報</td>
        <td>両方</td>
        <td>ms-settings:privacy-accountinfo</td>
    </tr>
    <tr>
        <td>連絡先</td>
        <td>両方</td>
        <td>ms-settings:privacy-contacts</td>
    </tr>
    <tr>
        <td>カレンダー</td>
        <td>両方</td>
        <td>ms-settings:privacy-calendar</td>
    </tr>
    <tr>
        <td>通話履歴</td>
        <td>両方</td>
        <td>ms-settings:privacy-callhistory</td>
    </tr>
    <tr>
        <td>メール</td>
        <td>両方</td>
        <td>ms-settings:privacy-email</td>
    </tr>
    <tr>
        <td>メッセージング</td>
        <td>両方</td>
        <td>ms-settings:privacy-messaging</td>
    </tr>
    <tr>
        <td>無線</td>
        <td>両方</td>
        <td>ms-settings:privacy-radios</td>
    </tr>
    <tr>
        <td>バックグラウンド アプリ</td>
        <td>両方</td>
        <td>ms-settings:privacy-backgroundapps</td>
    </tr>
    <tr>
        <td>他のデバイス</td>
        <td>両方</td>
        <td>ms-settings:privacy-customdevices</td>
    </tr>
    <tr>
        <td>フィードバックと診断</td>
        <td>両方</td>
        <td>ms-settings:privacy-feedback</td>
    </tr>
    <tr>
        <td>更新とセキュリティ</td>
        <td>開発者向け</td>
        <td>両方</td>
        <td>ms-settings:developers</td>
    </tr>
</table><br/>



<!--HONumber=Dec16_HO1-->


