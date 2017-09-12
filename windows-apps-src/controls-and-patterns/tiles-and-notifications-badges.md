---
author: mijacobs
Description: "タイル、バッジ、トースト、通知を使用して、アプリへのエントリ ポイントを提供し、ユーザーに最新情報を提示する方法について説明します。"
title: "UWP アプリ向けのバッジ通知"
ms.assetid: 48ee4328-7999-40c2-9354-7ea7d488c538
label: Tiles, badges, and notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: 73866ab5ef6001ccac96d2b9d782477fbe18156a
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="badge-notifications-for-uwp-apps"></a><span data-ttu-id="9eee1-104">UWP アプリ向けのバッジ通知</span><span class="sxs-lookup"><span data-stu-id="9eee1-104">Badge notifications for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<div style="float:left; font-size:80%; text-align:left; margin: 0px 15px 15px 0px;">
<img src="images/badge-example.png" alt="A tile with a numeric badge displaying the number 63 to indicate 63 unread mails." style="padding-bottom:0.0em; margin-bottom: 2px" /><br/><span data-ttu-id="9eee1-105">タイル上の数値バッジが数字の 63 を表示して、</span><span class="sxs-lookup"><span data-stu-id="9eee1-105">A tile with a numeric badge displaying</span></span><br/> <span data-ttu-id="9eee1-106">63 の未読メールがあることを示しています。</span><span class="sxs-lookup"><span data-stu-id="9eee1-106">the number 63 to indicate 63 unread mails.</span></span></div>

<span data-ttu-id="9eee1-107">通知バッジは、使っているアプリ特有の概要や状態情報を伝達します。</span><span class="sxs-lookup"><span data-stu-id="9eee1-107">A notification badge conveys summary or status information specific to your app.</span></span> <span data-ttu-id="9eee1-108">バッジは、数値 (1 ～ 99) の場合やシステムが提供するグリフの 1 つである場合があります。</span><span class="sxs-lookup"><span data-stu-id="9eee1-108">They can be numeric (1-99) or one of a set of system-provided glyphs.</span></span> <span data-ttu-id="9eee1-109">バッジによってよく伝達される情報の例としては、オンライン ゲームでのネットワーク接続状態、メッセージング アプリでのユーザーの状態、メール アプリでの未読メールの数、ソーシャル メディア アプリでの新しい投稿数などがあります。</span><span class="sxs-lookup"><span data-stu-id="9eee1-109">Examples of information best conveyed through a badge include network connection status in an online game, user status in a messaging app, number of unread mails in a mail app, and number of new posts in a social media app.</span></span> 

<span data-ttu-id="9eee1-110">通知バッジは、アプリが実行されているかどうかに関係なく、アプリのタスク バーのアイコンとスタート タイルの右下隅に表示されます。</span><span class="sxs-lookup"><span data-stu-id="9eee1-110">Notification badges appear on your app's taskbar icon and in the lower-right corner of its start tile, regardless of whether the app is running.</span></span> <span data-ttu-id="9eee1-111">バッジは、どのサイズのタイルにも表示できます。</span><span class="sxs-lookup"><span data-stu-id="9eee1-111">Badges can be displayed on all tile sizes.</span></span>  

> [!NOTE]
> <span data-ttu-id="9eee1-112">独自のバッジ イメージを指定することはできません。システムが提供するバッジ イメージだけを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9eee1-112">You cannot provide your own badge image; only system-provided badge images can be used.</span></span>


## <a name="numeric-badges"></a><span data-ttu-id="9eee1-113">数値バッジ</span><span class="sxs-lookup"><span data-stu-id="9eee1-113">Numeric badges</span></span>

<table>
    <tr>
        <th><span data-ttu-id="9eee1-114">値</span><span class="sxs-lookup"><span data-stu-id="9eee1-114">Value</span></span></th>
        <th><span data-ttu-id="9eee1-115">バッジ</span><span class="sxs-lookup"><span data-stu-id="9eee1-115">Badge</span></span></th>
        <th><span data-ttu-id="9eee1-116">XML</span><span class="sxs-lookup"><span data-stu-id="9eee1-116">XML</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="9eee1-117">1 ～ 99 の数字。</span><span class="sxs-lookup"><span data-stu-id="9eee1-117">A number from 1 to 99.</span></span> <span data-ttu-id="9eee1-118">値 0 はグリフ値 "none" と同じであり、バッジをクリアします。</span><span class="sxs-lookup"><span data-stu-id="9eee1-118">A value of 0 is equivalent to the glyph value "none" and will clear the badge.</span></span></td>
        <td>![100 より小さい数値バッジ。](images/badges/badge-numeric.png)</td>
        <td>`<badge value="1"/>`</td>
    </tr>
    <tr>
        <td><span data-ttu-id="9eee1-120">99 を超える数字。</span><span class="sxs-lookup"><span data-stu-id="9eee1-120">Any number greater than 99.</span></span></td>
        <td>![99 より大きい数値バッジ。](images/badges/badge-numeric-greater.png)</td></td>
        <td>`<badge value="100"/>`</td>
    </tr>    
</table>

## <a name="glyph-badges"></a><span data-ttu-id="9eee1-122">グリフ バッジ</span><span class="sxs-lookup"><span data-stu-id="9eee1-122">Glyph badges</span></span>
<span data-ttu-id="9eee1-123">バッジには、数値の代わりに拡張不可能な状態グリフ セットの 1 つを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="9eee1-123">Instead of a number, a badge can display one of a non-extensible set of status glyphs.</span></span> 

<table>
<tr>
    <th><span data-ttu-id="9eee1-124">状態</span><span class="sxs-lookup"><span data-stu-id="9eee1-124">Status</span></span></th>
    <th><span data-ttu-id="9eee1-125">グリフ</span><span class="sxs-lookup"><span data-stu-id="9eee1-125">Glyph</span></span></th>
    <th><span data-ttu-id="9eee1-126">XML</span><span class="sxs-lookup"><span data-stu-id="9eee1-126">XML</span></span></th>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-127">なし</span><span class="sxs-lookup"><span data-stu-id="9eee1-127">none</span></span></td>
    <td><span data-ttu-id="9eee1-128">(バッジは表示されません。)</span><span class="sxs-lookup"><span data-stu-id="9eee1-128">(No badge shown.)</span></span></td>
    <td>`<badge value="none"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-129">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="9eee1-129">activity</span></span></td>
    <td>![グリフ](images/badges/badge-activity.png)</td>
    <td>`<badge value="activity"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-131">alarm (アラーム)</span><span class="sxs-lookup"><span data-stu-id="9eee1-131">alarm</span></span></td>
    <td>![グリフ](images/badges/badge-alarm.png)</td>
    <td>`<badge value="alarm"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-133">alert (警告)</span><span class="sxs-lookup"><span data-stu-id="9eee1-133">alert</span></span></td>
    <td>![グリフ](images/badges/badge-alert.png)</td>
    <td>`<badge value="alert"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-135">attention (注意)</span><span class="sxs-lookup"><span data-stu-id="9eee1-135">attention</span></span></td>
    <td>![グリフ](images/badges/badge-attention.png)</td>
    <td>`<badge value="attention"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-137">available (利用可能)</span><span class="sxs-lookup"><span data-stu-id="9eee1-137">available</span></span></td>
    <td>![グリフ](images/badges/badge-available.png)</td>
    <td>`<badge value="available"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-139">away (離席中)</span><span class="sxs-lookup"><span data-stu-id="9eee1-139">away</span></span></td>
    <td>![グリフ](images/badges/badge-away.png)</td>
    <td>`<badge value="away"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-141">busy (取り込み中)</span><span class="sxs-lookup"><span data-stu-id="9eee1-141">busy</span></span></td>
    <td>![グリフ](images/badges/badge-busy.png)</td>
    <td>`<badge value="busy"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-143">error (エラー)</span><span class="sxs-lookup"><span data-stu-id="9eee1-143">error</span></span></td>
    <td>![グリフ](images/badges/badge-error.png)</td>
    <td>`<badge value="error"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-145">newMessage (新しいメッセージ)</span><span class="sxs-lookup"><span data-stu-id="9eee1-145">newMessage</span></span></td>
    <td>![グリフ](images/badges/badge-newMessage.png)</td>
    <td>`<badge value="newMessage"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-147">paused (一時停止)</span><span class="sxs-lookup"><span data-stu-id="9eee1-147">paused</span></span></td>
    <td>![グリフ](images/badges/badge-paused.png)</td>
    <td>`<badge value="paused"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-149">playing (再生)</span><span class="sxs-lookup"><span data-stu-id="9eee1-149">playing</span></span></td>
    <td>![グリフ](images/badges/badge-playing.png)</td>
    <td>`<badge value="playing"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="9eee1-151">unavailable (利用不可)</span><span class="sxs-lookup"><span data-stu-id="9eee1-151">unavailable</span></span></td>
    <td>![グリフ](images/badges/badge-unavailable.png)</td>
    <td>`<badge value="unavailable"/>`</td>
</tr>
</table>

## <a name="create-a-badge"></a><span data-ttu-id="9eee1-153">バッジの作成</span><span class="sxs-lookup"><span data-stu-id="9eee1-153">Create a badge</span></span>

<span data-ttu-id="9eee1-154">以降の例で、バッジの更新を作成する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9eee1-154">These examples show you how to to create a badge update.</span></span>

### <a name="create-a-numeric-badge"></a><span data-ttu-id="9eee1-155">数値バッジの作成</span><span class="sxs-lookup"><span data-stu-id="9eee1-155">Create a numeric badge</span></span>

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

### <a name="create-a-glyph-badge"></a><span data-ttu-id="9eee1-156">グリフ バッジの作成</span><span class="sxs-lookup"><span data-stu-id="9eee1-156">Create a glyph badge</span></span>
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

### <a name="clear-a-badge"></a><span data-ttu-id="9eee1-157">バッジのクリア</span><span class="sxs-lookup"><span data-stu-id="9eee1-157">Clear a badge</span></span>

````csharp
private void clearBadge()
{
    BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
}
````

## <a name="get-the-sample-code"></a><span data-ttu-id="9eee1-158">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="9eee1-158">Get the sample code</span></span>

* [<span data-ttu-id="9eee1-159">通知のサンプル</span><span class="sxs-lookup"><span data-stu-id="9eee1-159">Notifications sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/Notifications)<br/> <span data-ttu-id="9eee1-160">ライブ タイルを作り、バッジの更新を送信し、トースト通知を表示する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9eee1-160">Shows how to create live tiles, send badge updates, and display toast notifications.</span></span> 

## <a name="related-articles"></a><span data-ttu-id="9eee1-161">関連記事</span><span class="sxs-lookup"><span data-stu-id="9eee1-161">Related articles</span></span>

* [<span data-ttu-id="9eee1-162">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="9eee1-162">Adaptive and interactive toast notifications</span></span>](tiles-and-notifications-adaptive-interactive-toasts.md)
* [<span data-ttu-id="9eee1-163">タイルの作成</span><span class="sxs-lookup"><span data-stu-id="9eee1-163">Create tiles</span></span>](tiles-and-notifications-creating-tiles.md)
* [<span data-ttu-id="9eee1-164">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="9eee1-164">Create adaptive tiles</span></span>](tiles-and-notifications-create-adaptive-tiles.md)