---
title: ローカライズされた文字列
description: パートナー センターで文字列をローカライズする方法について説明します
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.date: 11/17/2017
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox Live、Xbox、ゲーム、uwp、windows 10、Xbox、ローカライズ文字列、パートナー センター
ms.openlocfilehash: 127f566dc5ae57b920d396623b6a84ff5d5eed96
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57656597"
---
# <a name="configuring-localized-strings-in-partner-center"></a><span data-ttu-id="13f7a-104">パートナー センターでローカライズされた文字列の構成</span><span class="sxs-lookup"><span data-stu-id="13f7a-104">Configuring Localized strings in Partner Center</span></span>

<span data-ttu-id="13f7a-105">このページを使うと、すべての Xbox Live 構成をゲームでサポートされているすべての言語にローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="13f7a-105">You can use this page to localize all your Xbox Live configurations to all the languages that your game supports.</span></span> <span data-ttu-id="13f7a-106">後続の Xbox Live ページで作成したサービス構成はすべて、ダウンロードしたファイルに追加されます。</span><span class="sxs-lookup"><span data-stu-id="13f7a-106">All of the service configurations that you have created on any of the subsequent Xbox Live pages will be added to the file that you would download.</span></span>

<span data-ttu-id="13f7a-107">使用することができます[パートナー センター](https://partner.microsoft.com/dashboard)ゲームに関連付けられているすべての言語でローカライズされた文字列を構成します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-107">You can use [Partner Center](https://partner.microsoft.com/dashboard) to configure the localized strings in all languages associated with your game.</span></span> <span data-ttu-id="13f7a-108">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-108">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="13f7a-109">**[サービス]** > **[Xbox Live]** > **[Localized strings]** (ローカライズされた文字列) の順に選択して、**[Localized strings]** (ローカライズされた文字列) セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-109">Navigate to the **Localized strings** section for your title, located under **Services** > **Xbox Live** > **Localized strings**.</span></span>
2. <span data-ttu-id="13f7a-110">**[ダウンロード]** をクリックすると、localization.xml ファイルがローカル コンピューターにダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="13f7a-110">Click the **Download** button which will download a localization.xml file on your local machine.</span></span>

![パートナー センターでローカライズされた文字列の構成 ページのスクリーン ショット](../../images/dev-center/localized-strings/localized-strings-1.png)

3. <span data-ttu-id="13f7a-112">複製することにより、ローカライズされた文字列を追加することができます、</span><span class="sxs-lookup"><span data-stu-id="13f7a-112">You can add the localized strings by duplicating the</span></span> <Value locale="en-US"><span data-ttu-id="13f7a-113">再生ダンジョン</span><span class="sxs-lookup"><span data-stu-id="13f7a-113">Mazes Played</span></span></Value> <span data-ttu-id="13f7a-114">タグと好みの言語とローカライズされた文字列の値をロケールの値を変更します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-114">tag and changing the value of the locale to the language of your choice and the value of the localized string.</span></span> <span data-ttu-id="13f7a-115">エラーを回避するために開発者表示ロケール内では、タグの少なくとも 1 つの値が必要です。</span><span class="sxs-lookup"><span data-stu-id="13f7a-115">You must have at least one value tag within the developer display locale to avoid errors.</span></span>

![ローカライズされた文字列の編集](../../images/dev-center/localized-strings/localized-strings.gif)

4. <span data-ttu-id="13f7a-117">ローカライズされた文字列をすべて追加したら、ドラッグするかローカル コンピューターを参照してファイルをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="13f7a-117">Once you have added all the localized strings, you can upload the file by dragging or browsing your local machine.</span></span>

![localization.xml ファイルをアップロードするボタンの画像](../../images/dev-center/localized-strings/localized-strings-2.png)

<span data-ttu-id="13f7a-119">localization.xml ファイルをアップロードするときに、次のエラーが表示される可能性がある点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="13f7a-119">Please note the following errors might appear when you upload the localization.xml file:</span></span>

| <span data-ttu-id="13f7a-120">エラー</span><span class="sxs-lookup"><span data-stu-id="13f7a-120">Error</span></span> | <span data-ttu-id="13f7a-121">原因</span><span class="sxs-lookup"><span data-stu-id="13f7a-121">Reason</span></span> |
|---------------------------|-------------|
| <span data-ttu-id="13f7a-122">失敗した XSD 検証:名前空間内の要素 'LocalizedString' 'http://config.mgt.xboxlive.com/schema/localization/1' テキストを含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="13f7a-122">Failed XSD Validation: The element 'LocalizedString' in namespace 'http://config.mgt.xboxlive.com/schema/localization/1' cannot contain text.</span></span> <span data-ttu-id="13f7a-123">必要とされる要素の一覧:名前空間には、' value' 'http://config.mgt.xboxlive.com/schema/localization/1'</span><span class="sxs-lookup"><span data-stu-id="13f7a-123">List of possible elements expected: 'Value' in namespace 'http://config.mgt.xboxlive.com/schema/localization/1'</span></span> | <span data-ttu-id="13f7a-124">これは、XML ドキュメントの形式が正しくない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-124">This occurs when the XML document is malformed</span></span> |
| <span data-ttu-id="13f7a-125">ローカライズ文字列に開発者表示ロケールのエントリがない</span><span class="sxs-lookup"><span data-stu-id="13f7a-125">Localization string is missing an entry for the developer display locale</span></span> | <span data-ttu-id="13f7a-126">これは、ローカライズされた文字列に、ロケールが開発者表示ロケールと一致しないエントリがない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="13f7a-126">This occurs when a localized string is missing an entry whose locale does not match the dev display locale</span></span> |
| <span data-ttu-id="13f7a-127">失敗した XSD 検証:'ロケール' 属性が無効です - 値 ''は datatype に対して無効でない'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString'-Pattern 制約に失敗しました。</span><span class="sxs-lookup"><span data-stu-id="13f7a-127">Failed XSD Validation: The 'locale' attribute is invalid - The value ' ' is invalid according to its datatype 'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString' - The Pattern constraint failed.</span></span> | <span data-ttu-id="13f7a-128">これは、ローカライズされた文字列でのロケール値が不足しているときに発生します、。</span><span class="sxs-lookup"><span data-stu-id="13f7a-128">This occurs when a localized string is missing the locale value in the</span></span> <Value> <span data-ttu-id="13f7a-129">tag</span><span class="sxs-lookup"><span data-stu-id="13f7a-129">tag</span></span>|
