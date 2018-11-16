---
author: mijacobs
Description: Learn how to use tiles, badges, toasts, and notifications to provide entry points into your app and keep users up-to-date.
title: UWP アプリ向けのバッジ通知
ms.assetid: 48ee4328-7999-40c2-9354-7ea7d488c538
label: Tiles, badges, and notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 667efeb67c956f8d4378b0e7e4011f7e06977519
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7101829"
---
# <a name="badge-notifications-for-uwp-apps"></a><span data-ttu-id="0a10b-103">UWP アプリ向けのバッジ通知</span><span class="sxs-lookup"><span data-stu-id="0a10b-103">Badge notifications for UWP apps</span></span>

 

<div style="float:left; font-size:80%; text-align:left; margin: 0px 15px 15px 0px;">
<img src="images/badge-example.png" alt="A tile with a numeric badge displaying the number 63 to indicate 63 unread mails." style="padding-bottom:0.0em; margin-bottom: 2px" /><br/><span data-ttu-id="0a10b-104">タイル上の数値バッジが数字の 63 を表示して、</span><span class="sxs-lookup"><span data-stu-id="0a10b-104">A tile with a numeric badge displaying</span></span><br/> <span data-ttu-id="0a10b-105">63 の未読メールがあることを示しています。</span><span class="sxs-lookup"><span data-stu-id="0a10b-105">the number 63 to indicate 63 unread mails.</span></span></div>

<span data-ttu-id="0a10b-106">通知バッジは、使っているアプリ特有の概要や状態情報を伝達します。</span><span class="sxs-lookup"><span data-stu-id="0a10b-106">A notification badge conveys summary or status information specific to your app.</span></span> <span data-ttu-id="0a10b-107">バッジは、数値 (1 ～ 99) の場合やシステムが提供するグリフの 1 つである場合があります。</span><span class="sxs-lookup"><span data-stu-id="0a10b-107">They can be numeric (1-99) or one of a set of system-provided glyphs.</span></span> <span data-ttu-id="0a10b-108">バッジによってよく伝達される情報の例としては、オンライン ゲームでのネットワーク接続状態、メッセージング アプリでのユーザーの状態、メール アプリでの未読メールの数、ソーシャル メディア アプリでの新しい投稿数などがあります。</span><span class="sxs-lookup"><span data-stu-id="0a10b-108">Examples of information best conveyed through a badge include network connection status in an online game, user status in a messaging app, number of unread mails in a mail app, and number of new posts in a social media app.</span></span> 

<span data-ttu-id="0a10b-109">通知バッジは、アプリが実行されているかどうかに関係なく、アプリのタスク バーのアイコンとスタート タイルの右下隅に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a10b-109">Notification badges appear on your app's taskbar icon and in the lower-right corner of its start tile, regardless of whether the app is running.</span></span> <span data-ttu-id="0a10b-110">バッジは、どのサイズのタイルにも表示できます。</span><span class="sxs-lookup"><span data-stu-id="0a10b-110">Badges can be displayed on all tile sizes.</span></span>  

> [!NOTE]
> <span data-ttu-id="0a10b-111">独自のバッジ イメージを指定することはできません。システムが提供するバッジ イメージだけを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="0a10b-111">You cannot provide your own badge image; only system-provided badge images can be used.</span></span>


## <a name="numeric-badges"></a><span data-ttu-id="0a10b-112">数値バッジ</span><span class="sxs-lookup"><span data-stu-id="0a10b-112">Numeric badges</span></span>

<table>
    <tr>
        <th><span data-ttu-id="0a10b-113">値</span><span class="sxs-lookup"><span data-stu-id="0a10b-113">Value</span></span></th>
        <th><span data-ttu-id="0a10b-114">バッジ</span><span class="sxs-lookup"><span data-stu-id="0a10b-114">Badge</span></span></th>
        <th><span data-ttu-id="0a10b-115">XML</span><span class="sxs-lookup"><span data-stu-id="0a10b-115">XML</span></span></th>
    </tr>
    <tr>
        <td><span data-ttu-id="0a10b-116">1 ～ 99 の数字。</span><span class="sxs-lookup"><span data-stu-id="0a10b-116">A number from 1 to 99.</span></span> <span data-ttu-id="0a10b-117">値 0 はグリフ値 "none" と同じであり、バッジをクリアします。</span><span class="sxs-lookup"><span data-stu-id="0a10b-117">A value of 0 is equivalent to the glyph value "none" and will clear the badge.</span></span></td>
        <td><img src="images/badges/badge-numeric.png" alt="A numeric badge less than 100." /></td>
        <td>`<badge value="1"/>`</td>
    </tr>
    <tr>
        <td><span data-ttu-id="0a10b-118">99 を超える数字。</span><span class="sxs-lookup"><span data-stu-id="0a10b-118">Any number greater than 99.</span></span></td>
        <td><img src="images/badges/badge-numeric-greater.png" alt="A numeric badge greater than 99." /></td></td>
        <td>`<badge value="100"/>`</td>
    </tr>    
</table>

## <a name="glyph-badges"></a><span data-ttu-id="0a10b-119">グリフ バッジ</span><span class="sxs-lookup"><span data-stu-id="0a10b-119">Glyph badges</span></span>
<span data-ttu-id="0a10b-120">バッジには、数値の代わりに拡張不可能な状態グリフ セットの 1 つを表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="0a10b-120">Instead of a number, a badge can display one of a non-extensible set of status glyphs.</span></span> 

<table>
<tr>
    <th><span data-ttu-id="0a10b-121">状態</span><span class="sxs-lookup"><span data-stu-id="0a10b-121">Status</span></span></th>
    <th><span data-ttu-id="0a10b-122">グリフ</span><span class="sxs-lookup"><span data-stu-id="0a10b-122">Glyph</span></span></th>
    <th><span data-ttu-id="0a10b-123">XML</span><span class="sxs-lookup"><span data-stu-id="0a10b-123">XML</span></span></th>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-124">なし</span><span class="sxs-lookup"><span data-stu-id="0a10b-124">none</span></span></td>
    <td><span data-ttu-id="0a10b-125">(バッジは表示されません。)</span><span class="sxs-lookup"><span data-stu-id="0a10b-125">(No badge shown.)</span></span></td>
    <td>`<badge value="none"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-126">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="0a10b-126">activity</span></span></td>
    <td><img src="images/badges/badge-activity.png" alt="Glyph" /></td>
    <td>`<badge value="activity"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-127">alarm (アラーム)</span><span class="sxs-lookup"><span data-stu-id="0a10b-127">alarm</span></span></td>
    <td><img src="images/badges/badge-alarm.png" alt="Glyph" /></td>
    <td>`<badge value="alarm"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-128">alert (警告)</span><span class="sxs-lookup"><span data-stu-id="0a10b-128">alert</span></span></td>
    <td><img src="images/badges/badge-alert.png" alt="Glyph" /></td>
    <td>`<badge value="alert"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-129">attention (注意)</span><span class="sxs-lookup"><span data-stu-id="0a10b-129">attention</span></span></td>
    <td><img src="images/badges/badge-attention.png" alt="Glyph" /></td>
    <td>`<badge value="attention"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-130">available (利用可能)</span><span class="sxs-lookup"><span data-stu-id="0a10b-130">available</span></span></td>
    <td><img src="images/badges/badge-available.png" alt="Glyph" /></td>
    <td>`<badge value="available"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-131">away (離席中)</span><span class="sxs-lookup"><span data-stu-id="0a10b-131">away</span></span></td>
    <td><img src="images/badges/badge-away.png" alt="Glyph" /></td>
    <td>`<badge value="away"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-132">busy (取り込み中)</span><span class="sxs-lookup"><span data-stu-id="0a10b-132">busy</span></span></td>
    <td><img src="images/badges/badge-busy.png" alt="Glyph" /></td>
    <td>`<badge value="busy"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-133">error (エラー)</span><span class="sxs-lookup"><span data-stu-id="0a10b-133">error</span></span></td>
    <td><img src="images/badges/badge-error.png" alt="Glyph" /></td>
    <td>`<badge value="error"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-134">newMessage (新しいメッセージ)</span><span class="sxs-lookup"><span data-stu-id="0a10b-134">newMessage</span></span></td>
    <td><img src="images/badges/badge-newMessage.png" alt="Glyph" /></td>
    <td>`<badge value="newMessage"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-135">paused (一時停止)</span><span class="sxs-lookup"><span data-stu-id="0a10b-135">paused</span></span></td>
    <td><img src="images/badges/badge-paused.png" alt="Glyph" /></td>
    <td>`<badge value="paused"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-136">playing (再生)</span><span class="sxs-lookup"><span data-stu-id="0a10b-136">playing</span></span></td>
    <td><img src="images/badges/badge-playing.png" alt="Glyph" /></td>
    <td>`<badge value="playing"/>`</td>
</tr>
<tr>
    <td><span data-ttu-id="0a10b-137">unavailable (利用不可)</span><span class="sxs-lookup"><span data-stu-id="0a10b-137">unavailable</span></span></td>
    <td><img src="images/badges/badge-unavailable.png" alt="Glyph" /></td>
    <td>`<badge value="unavailable"/>`</td>
</tr>
</table>

## <a name="create-a-badge"></a><span data-ttu-id="0a10b-138">バッジの作成</span><span class="sxs-lookup"><span data-stu-id="0a10b-138">Create a badge</span></span>

<span data-ttu-id="0a10b-139">これらの例では、バッジの更新プログラムを作成する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="0a10b-139">These examples show you how to create a badge update.</span></span>

### <a name="create-a-numeric-badge"></a><span data-ttu-id="0a10b-140">数値バッジの作成</span><span class="sxs-lookup"><span data-stu-id="0a10b-140">Create a numeric badge</span></span>

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

### <a name="create-a-glyph-badge"></a><span data-ttu-id="0a10b-141">グリフ バッジの作成</span><span class="sxs-lookup"><span data-stu-id="0a10b-141">Create a glyph badge</span></span>
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

### <a name="clear-a-badge"></a><span data-ttu-id="0a10b-142">バッジのクリア</span><span class="sxs-lookup"><span data-stu-id="0a10b-142">Clear a badge</span></span>

````csharp
private void clearBadge()
{
    BadgeUpdateManager.CreateBadgeUpdaterForApplication().Clear();
}
````

## <a name="get-the-sample-code"></a><span data-ttu-id="0a10b-143">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="0a10b-143">Get the sample code</span></span>

* [<span data-ttu-id="0a10b-144">通知のサンプル</span><span class="sxs-lookup"><span data-stu-id="0a10b-144">Notifications sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/Notifications)<br/> <span data-ttu-id="0a10b-145">ライブ タイルを作り、バッジの更新を送信し、トースト通知を表示する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0a10b-145">Shows how to create live tiles, send badge updates, and display toast notifications.</span></span> 

## <a name="related-articles"></a><span data-ttu-id="0a10b-146">関連記事</span><span class="sxs-lookup"><span data-stu-id="0a10b-146">Related articles</span></span>

* [<span data-ttu-id="0a10b-147">アダプティブ トースト通知と対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="0a10b-147">Adaptive and interactive toast notifications</span></span>](adaptive-interactive-toasts.md)
* [<span data-ttu-id="0a10b-148">タイルの作成</span><span class="sxs-lookup"><span data-stu-id="0a10b-148">Create tiles</span></span>](creating-tiles.md)
* [<span data-ttu-id="0a10b-149">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="0a10b-149">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
