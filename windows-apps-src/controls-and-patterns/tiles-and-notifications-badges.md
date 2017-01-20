---
author: mijacobs
Description: "タイル、バッジ、トースト、通知を使用して、アプリへのエントリ ポイントを提供し、ユーザーに最新情報を提示する方法について説明します。"
title: "タイル、バッジ、および通知"
ms.assetid: 48ee4328-7999-40c2-9354-7ea7d488c538
label: Tiles, badges, and notifications
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: a3924fef520d7ba70873d6838f8e194e5fc96c62
ms.openlocfilehash: 465c75ccb2af9b162202a79025aa292fbd626a58

---
# <a name="badge-notifications-for-uwp-apps"></a>UWP アプリ向けのバッジ通知

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<div style="float:left; font-size:80%; text-align:left; margin: 0px 15px 15px 0px;">
<img src="images/badge-example.png" alt="A tile with a numeric badge displaying the number 63 to indicate 63 unread mails." style="padding-bottom:0.0em; margin-bottom: 2px" /><br/>タイル上の数値バッジが数字の 63 を表示して、<br/> 63 の未読メールがあることを示しています。</div>

通知バッジは、使っているアプリ特有の概要や状態情報を伝達します。 バッジは、数値 (1 ～ 99) の場合やシステムが提供するグリフの 1 つである場合があります。 バッジによってよく伝達される情報の例としては、オンライン ゲームでのネットワーク接続状態、メッセージング アプリでのユーザーの状態、メール アプリでの未読メールの数、ソーシャル メディア アプリでの新しい投稿数などがあります。 

通知バッジは、アプリが実行されているかどうかに関係なく、アプリのタスク バーのアイコンとスタート タイルの右下隅に表示されます。 バッジは、どのサイズのタイルにも表示できます。  

> [!NOTE]
> 独自のバッジ イメージを指定することはできません。システムが提供するバッジ イメージだけを使うことができます。


## <a name="numeric-badges"></a>数値バッジ

<table>
    <tr>
        <th>値</th>
        <th>バッジ</th>
        <th>XML</th>
    </tr>
    <tr>
        <td>1 ～ 99 の数字。 値 0 はグリフ値 "none" と同じであり、バッジをクリアします。</td>
        <td>![100 より小さい数値バッジ。](images/badges/badge-numeric.png)</td>
        <td>`<badge value="1"/>`</td>
    </tr>
    <tr>
        <td>99 を超える数字。</td>
        <td>![99 より大きい数値バッジ。](images/badges/badge-numeric-greater.png)</td></td>
        <td>`<badge value="100"/>`</td>
    </tr>    
</table>

## <a name="glyph-badges"></a>グリフ バッジ
バッジには、数値の代わりに拡張不可能な状態グリフ セットの 1 つを表示することもできます。 

<table>
<tr>
    <th>状態</th>
    <th>グリフ</th>
    <th>XML</th>
</tr>
<tr>
    <td>なし</td>
    <td>(バッジは表示されません。)</td>
    <td>`<badge value="none"/>`</td>
</tr>
<tr>
    <td>activity (アクティビティ)</td>
    <td>![グリフ](images/badges/badge-activity.png)</td>
    <td>`<badge value="activity"/>`</td>
</tr>
<tr>
    <td>alarm (アラーム)</td>
    <td>![グリフ](images/badges/badge-alarm.png)</td>
    <td>`<badge value="alarm"/>`</td>
</tr>
<tr>
    <td>alert (警告)</td>
    <td>![グリフ](images/badges/badge-alert.png)</td>
    <td>`<badge value="alert"/>`</td>
</tr>
<tr>
    <td>attention (注意)</td>
    <td>![グリフ](images/badges/badge-attention.png)</td>
    <td>`<badge value="attention"/>`</td>
</tr>
<tr>
    <td>available (利用可能)</td>
    <td>![グリフ](images/badges/badge-available.png)</td>
    <td>`<badge value="available"/>`</td>
</tr>
<tr>
    <td>away (離席中)</td>
    <td>![グリフ](images/badges/badge-away.png)</td>
    <td>`<badge value="away"/>`</td>
</tr>
<tr>
    <td>busy (取り込み中)</td>
    <td>![グリフ](images/badges/badge-busy.png)</td>
    <td>`<badge value="busy"/>`</td>
</tr>
<tr>
    <td>error (エラー)</td>
    <td>![グリフ](images/badges/badge-error.png)</td>
    <td>`<badge value="error"/>`</td>
</tr>
<tr>
    <td>newMessage (新しいメッセージ)</td>
    <td>![グリフ](images/badges/badge-newMessage.png)</td>
    <td>`<badge value="newMessage"/>`</td>
</tr>
<tr>
    <td>paused (一時停止)</td>
    <td>![グリフ](images/badges/badge-paused.png)</td>
    <td>`<badge value="paused"/>`</td>
</tr>
<tr>
    <td>playing (再生)</td>
    <td>![グリフ](images/badges/badge-playing.png)</td>
    <td>`<badge value="playing"/>`</td>
</tr>
<tr>
    <td>unavailable (利用不可)</td>
    <td>![グリフ](images/badges/badge-unavailable.png)</td>
    <td>`<badge value="unavailable"/>`</td>
</tr>
</table>

## <a name="create-a-badge"></a>バッジの作成

以降の例で、バッジの更新を作成する方法を示します。

### <a name="create-a-numeric-badge"></a>数値バッジの作成

````csharp
private void setBadgeNumber(int num)
{

    // Get the blank badge XML payload for a badge number
    XmlDocument badgeXml = 
        BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);

    // Set the value of the badge in the XML to our number
    XmlElement badgeElement = badgeXml.SelectSingleNode("/badge") as XmlElement;
    badgeElement.SetAttribute("value", num.ToString());

    // Create the badge notification
    BadgeNotification badge = new BadgeNotification(badgeXml);

    // Create the badge updater for the application
    BadgeUpdater badgeUpdater = 
        BadgeUpdateManager.CreateBadgeUpdaterForApplication();

    // And update the badge
    badgeUpdater.Update(badge);

}
````

### <a name="create-a-glyph-badge"></a>グリフ バッジの作成
````csharp
private void updateBadgeGlyph()
{
    string badgeGlyphValue = "alert";

    // Get the blank badge XML payload for a badge glyph
    XmlDocument badgeXml = 
        BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);

    // Set the value of the badge in the XML to our glyph value
    Windows.Data.Xml.Dom.XmlElement badgeElement = 
        badgeXml.SelectSingleNode("/badge") as Windows.Data.Xml.Dom.XmlElement;
    badgeElement.SetAttribute("value", badgeGlyphValue);

    // Create the badge notification
    BadgeNotification badge = new BadgeNotification(badgeXml);

    // Create the badge updater for the application
    BadgeUpdater badgeUpdater = 
        BadgeUpdateManager.CreateBadgeUpdaterForApplication();

    // And update the badge
    badgeUpdater.Update(badge);

}
````

### <a name="clear-a-badge"></a>バッジのクリア

````csharp
private void clearBadge()
{
    BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
}
````

## <a name="get-the-sample-code"></a>サンプル コードを入手する

* [通知のサンプル](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/Notifications)<br/> ライブ タイルを作り、バッジの更新を送信し、トースト通知を表示する方法を示します。 

## <a name="related-articles"></a>関連記事

* [アダプティブ トースト通知と対話型トースト通知](tiles-and-notifications-adaptive-interactive-toasts.md)
* [タイルの作成](tiles-and-notifications-creating-tiles.md)
* [アダプティブ タイルの作成](tiles-and-notifications-create-adaptive-tiles.md)


<!--HONumber=Dec16_HO2-->


