---
author: Xansky
Description: Describes the landmarks and headings features of accessibility.
ms.assetid: 019CC63D-D915-4EBD-9442-DE899AB973C9
title: ランドマークと見出し
label: Landmarks and Headings
template: detail.hbs
ms.author: mhopkins
ms.date: 01/24/2018
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 250ed555e6fcf7dc40d31d89a40fa7a96295aacf
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6669874"
---
# <a name="landmarks-and-headings"></a>ランドマークと見出し

通常、ユーザー インターフェイスは、目が見えるユーザーが*すべて*のコンテンツを読む速度を落とさずに、興味があることにざっと目を通すことができるように視覚的に効率的な方法で編成されます。 スクリーン リーダー ユーザーにも、これと同じようにざっと目を通す機能が必要です。 ランドマークと見出しは、ユーザー インターフェイスのセクションを定義し、アクセシビリティ対応技術 (AT) のユーザーのさらに効率的なナビゲーションに役立ちます。 コンテンツをランドマークと見出しにマークすることで、スクリーン リーダー ユーザーに、目が見えるユーザーと同じようにコンテンツにざっと目を通すオプションが提供されます。

スクリーン リーダー ユーザーがすばやいナビゲーションを行えるように、Web コンテンツには長年にわたり、[ARIA ランドマーク](https://www.w3.org/WAI/GL/wiki/Using_ARIA_landmarks_to_identify_regions_of_a_page)、[ARIA 見出し](https://www.w3.org/TR/WCAG20-TECHS/ARIA12.html)、および [HTML 見出し](https://www.w3.org/TR/2016/NOTE-WCAG20-TECHS-20161007/H42.html)の概念が使用されてきました。 Web ページでは、ランドマークと見出しを使用して、AT ユーザーが大きい塊 (ランドマーク) と小さい塊 (見出し) にすばやくアクセスできるようにすることで、コンテンツをさらに使いやすくしています。 具体的には、スクリーン リーダーに、ランドマーク間で移動したり、見出しの間で移動したりできるコマンドがあります (次へ/前へ、または特定の見出しレベルへ)。 同じ理由で、アプリでランドマークと見出しを検討することが重要です。

ランドマークを使うと、コンテンツを検索、ナビゲーション、メイン コンテンツなど、さまざまなカテゴリにグループ化することができます。 グループ化すると、AT ユーザーはグループ間をすばやく移動できます。 このすばやいナビゲーションでは、以前に項目ごとに移動する必要があり、不快に感じたかなりの量のコンテンツをスキップすることができます。 

たとえば、タブ パネルを使用する際は、それをナビゲーション ランドマークと考えてください。 検索編集ボックスを使用する際は、それを検索ランドマークと考え、メイン コンテンツをメイン コンテンツランドマークとして設定することを検討してください。 ランドマークの内部でも外部でも、サブ要素を論理見出しレベルがある見出しとして設定することを検討してください。 

Windows 設定アプリに、**[簡単操作]** ページを含めることを検討してください。 

![Windows 設定アプリの [簡単操作] ページ](images/EaseOfAccessSettings.png)  

検索ランドマーク内にラップされた検索編集ボックスがあります。 左側のナビゲーション要素はナビゲーション ランドマーク内でラップされ、右側のメイン コンテンツはメイン コンテンツ ランドマーク内でラップされています。 さらに、ナビゲーション ランドマーク内に、見出しレベル 1 が **[簡単操作]** であるメイン グループの見出しがあります。 その下に、サブ オプションの **[視覚]**、**[聴覚]** などがあります。 これらの下に見出しレベル 2 があります。 見出しの設定はメイン コンテンツ内でも続き、メイン サブジェクトの **[表示]** を見出しレベル 1 として設定し、**[画面上のすべてのものを大きくする]** などのサブ グループを見出しレベル 2 として設定します。 

ランドマークや見出しがなくても設定アプリにアクセスできますが、これらがある方がより使いやすくなります。 スクリーン リーダー ユーザーは、必要なグループ (ランドマーク) に迅速かつ簡単にアクセスでき、サブ グループ (見出し) にも同様にアクセスできます。 

[AutomationProperties.LandmarkTypeProperty](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.LandmarkTypeProperty) を使用して、目的の[ランドマークの種類](https://msdn.microsoft.com/library/windows/desktop/mt759299)として UI 要素を設定します。 このランドマーク UI 要素は、そのランドマークに応じた他のすべての UI 要素をカプセル化します。 

[AutomationProperties.LocalizedLandmarkTypeProperty](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.LocalizedLandmarkTypeProperty) を使用して、ランドマークに具体的に名前を付けます。 メインやナビゲーションなど、定義済みのランドマークの種類を選択した場合は、それらの名前がランドマーク名に使用されます。 しかし、ランドマークの種類をカスタムに設定した場合は、このプロパティを使用してランドマークに具体的に名前を付ける必要があります。 このプロパティを使用して、カスタムでないランドマークの種類から設定される既定の名前を上書きすることもできます。 

[AutomationProperties.HeadingLevel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.headinglevelproperty) を使用して、UI 要素を *Level1* ～ *Level9* の特定のレベルの見出しとして設定します。

