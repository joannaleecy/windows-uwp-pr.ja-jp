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
# <a name="configuring-localized-strings-in-partner-center"></a>パートナー センターでローカライズされた文字列の構成

このページを使うと、すべての Xbox Live 構成をゲームでサポートされているすべての言語にローカライズすることができます。 後続の Xbox Live ページで作成したサービス構成はすべて、ダウンロードしたファイルに追加されます。

使用することができます[パートナー センター](https://partner.microsoft.com/dashboard)ゲームに関連付けられているすべての言語でローカライズされた文字列を構成します。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[Localized strings]** (ローカライズされた文字列) の順に選択して、**[Localized strings]** (ローカライズされた文字列) セクションに移動します。
2. **[ダウンロード]** をクリックすると、localization.xml ファイルがローカル コンピューターにダウンロードされます。

![パートナー センターでローカライズされた文字列の構成 ページのスクリーン ショット](../../images/dev-center/localized-strings/localized-strings-1.png)

3. 複製することにより、ローカライズされた文字列を追加することができます、 <Value locale="en-US">再生ダンジョン</Value> タグと好みの言語とローカライズされた文字列の値をロケールの値を変更します。 エラーを回避するために開発者表示ロケール内では、タグの少なくとも 1 つの値が必要です。

![ローカライズされた文字列の編集](../../images/dev-center/localized-strings/localized-strings.gif)

4. ローカライズされた文字列をすべて追加したら、ドラッグするかローカル コンピューターを参照してファイルをアップロードできます。

![localization.xml ファイルをアップロードするボタンの画像](../../images/dev-center/localized-strings/localized-strings-2.png)

localization.xml ファイルをアップロードするときに、次のエラーが表示される可能性がある点に注意してください。

| エラー | 原因 |
|---------------------------|-------------|
| 失敗した XSD 検証:名前空間内の要素 'LocalizedString' 'http://config.mgt.xboxlive.com/schema/localization/1' テキストを含めることはできません。 必要とされる要素の一覧:名前空間には、' value' 'http://config.mgt.xboxlive.com/schema/localization/1' | これは、XML ドキュメントの形式が正しくない場合に発生します。 |
| ローカライズ文字列に開発者表示ロケールのエントリがない | これは、ローカライズされた文字列に、ロケールが開発者表示ロケールと一致しないエントリがない場合に発生します。 |
| 失敗した XSD 検証:'ロケール' 属性が無効です - 値 ''は datatype に対して無効でない'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString'-Pattern 制約に失敗しました。 | これは、ローカライズされた文字列でのロケール値が不足しているときに発生します、。 <Value> tag|
