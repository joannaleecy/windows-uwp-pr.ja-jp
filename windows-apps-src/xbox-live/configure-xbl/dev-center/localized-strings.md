---
title: ローカライズされた文字列
author: shrutimundra
description: Windows デベロッパー センターで文字列をローカライズする方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 11/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ローカライズされた文字列, Windows デベロッパー センター
ms.openlocfilehash: fac642adad099bf930a4ddabba151384a83db17c
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4690827"
---
# <a name="configuring-localized-strings-on-windows-dev-center"></a><span data-ttu-id="f1f9b-104">Windows デベロッパー センターでのローカライズされた文字列の構成</span><span class="sxs-lookup"><span data-stu-id="f1f9b-104">Configuring Localized strings on Windows Dev Center</span></span>

<span data-ttu-id="f1f9b-105">このページを使うと、すべての Xbox Live 構成をゲームでサポートされているすべての言語にローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-105">You can use this page to localize all your Xbox Live configurations to all the languages that your game supports.</span></span> <span data-ttu-id="f1f9b-106">後続の Xbox Live ページで作成したサービス構成はすべて、ダウンロードしたファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-106">All of the service configurations that you have created on any of the subsequent Xbox Live pages will be added to the file that you would download.</span></span>

<span data-ttu-id="f1f9b-107">[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)を使い、ゲームに関連付けられているすべての言語のローカライズされた文字列を構成できます。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-107">You can use [Windows Dev Center](https://developer.microsoft.com/dashboard) to configure the localized strings in all languages associated with your game.</span></span> <span data-ttu-id="f1f9b-108">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-108">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="f1f9b-109">**[サービス]** > **[Xbox Live]** > **[Localized strings]** (ローカライズされた文字列) の順に選択して、**[Localized strings]** (ローカライズされた文字列) セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-109">Navigate to the **Localized strings** section for your title, located under **Services** > **Xbox Live** > **Localized strings**.</span></span>
2. <span data-ttu-id="f1f9b-110">**[ダウンロード]** をクリックすると、localization.xml ファイルがローカル コンピューターにダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-110">Click the **Download** button which will download a localization.xml file on your local machine.</span></span>

![デベロッパー センターのローカライズされた文字列構成ページのスクリーンショット](../../images/dev-center/localized-strings/localized-strings-1.png)

3. <span data-ttu-id="f1f9b-112">ローカライズされた文字列を追加するには複製することにより、</span><span class="sxs-lookup"><span data-stu-id="f1f9b-112">You can add the localized strings by duplicating the</span></span> <Value locale="en-US"><span data-ttu-id="f1f9b-113">迷路の再生</span><span class="sxs-lookup"><span data-stu-id="f1f9b-113">Mazes Played</span></span></Value> <span data-ttu-id="f1f9b-114">タグとロケールの値を好みの言語とローカライズされた文字列の値に変更します。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-114">tag and changing the value of the locale to the language of your choice and the value of the localized string.</span></span> <span data-ttu-id="f1f9b-115">エラーを回避するには、開発者表示ロケール内に少なくとも 1 つの値タグが必要です。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-115">You must have atleast one value tag within the developer display locale to avoid errors.</span></span>

![ローカライズされた文字列の編集](../../images/dev-center/localized-strings/localized-strings.gif)

4. <span data-ttu-id="f1f9b-117">ローカライズされた文字列をすべて追加したら、ドラッグするかローカル コンピューターを参照してファイルをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-117">Once you have added all the localized strings, you can upload the file by dragging or browsing your local machine.</span></span>

![localization.xml ファイルをアップロードするボタンの画像](../../images/dev-center/localized-strings/localized-strings-2.png)

<span data-ttu-id="f1f9b-119">localization.xml ファイルをアップロードするときに、次のエラーが表示される可能性がある点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-119">Please note the following errors might appear when you upload the localization.xml file:</span></span>

| <span data-ttu-id="f1f9b-120">エラー</span><span class="sxs-lookup"><span data-stu-id="f1f9b-120">Error</span></span> | <span data-ttu-id="f1f9b-121">原因</span><span class="sxs-lookup"><span data-stu-id="f1f9b-121">Reason</span></span> |
|---------------------------|-------------|
| <span data-ttu-id="f1f9b-122">XSD 検証の失敗: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の要素 'LocalizedString' にテキストを含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-122">Failed XSD Validation: The element 'LocalizedString' in namespace 'http://config.mgt.xboxlive.com/schema/localization/1' cannot contain text.</span></span> <span data-ttu-id="f1f9b-123">指定できる要素の一覧: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の 'Value'</span><span class="sxs-lookup"><span data-stu-id="f1f9b-123">List of possible elements expected: 'Value' in namespace 'http://config.mgt.xboxlive.com/schema/localization/1'</span></span> | <span data-ttu-id="f1f9b-124">これは、XML ドキュメントの形式が正しくない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-124">This occurs when the XML document is malformed</span></span> |
| <span data-ttu-id="f1f9b-125">ローカライズ文字列に開発者表示ロケールのエントリがない</span><span class="sxs-lookup"><span data-stu-id="f1f9b-125">Localization string is missing an entry for the developer display locale</span></span> | <span data-ttu-id="f1f9b-126">これは、ローカライズされた文字列に、ロケールが開発者表示ロケールと一致しないエントリがない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-126">This occurs when a localized string is missing an entry whose locale does not match the dev display locale</span></span> |
| <span data-ttu-id="f1f9b-127">XSD 検証の失敗: 'locale' 属性が無効 - データ型 'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString' によると 値 ' ' が無効です - パターン制約に失敗しました。</span><span class="sxs-lookup"><span data-stu-id="f1f9b-127">Failed XSD Validation: The 'locale' attribute is invalid - The value ' ' is invalid according to its datatype 'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString' - The Pattern constraint failed.</span></span> | <span data-ttu-id="f1f9b-128">ローカライズされた文字列のロケールの値がない場合にこれが発生する、</span><span class="sxs-lookup"><span data-stu-id="f1f9b-128">This occurs when a localized string is missing the locale value in the</span></span> <Value> <span data-ttu-id="f1f9b-129">tag</span><span class="sxs-lookup"><span data-stu-id="f1f9b-129">tag</span></span>|