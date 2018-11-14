---
title: ローカライズされた文字列
author: shrutimundra
description: パートナー センターで文字列をローカライズする方法について説明します
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 11/17/2017
ms.topic: article
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, uwp, windows 10, Xbox one, ローカライズされた文字列, パートナー センター
ms.openlocfilehash: b7d8f53656f60932c0f27f492f3769ddae8434ba
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6251459"
---
# <a name="configuring-localized-strings-in-partner-center"></a>パートナー センターのローカライズされた文字列を構成します。

このページを使うと、すべての Xbox Live 構成をゲームでサポートされているすべての言語にローカライズすることができます。 後続の Xbox Live ページで作成したサービス構成はすべて、ダウンロードしたファイルに追加されます。

[パートナー センター](https://partner.microsoft.com/dashboard)を使用して、ゲームに関連付けられているすべての言語でローカライズされた文字列を構成することができます。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[Localized strings]** (ローカライズされた文字列) の順に選択して、**[Localized strings]** (ローカライズされた文字列) セクションに移動します。
2. **[ダウンロード]** をクリックすると、localization.xml ファイルがローカル コンピューターにダウンロードされます。

![パートナー センターのローカライズされた文字列構成ページのスクリーン ショット](../../images/dev-center/localized-strings/localized-strings-1.png)

3. ローカライズされた文字列を追加するには複製することにより、 <Value locale="en-US">迷路の再生</Value> タグとロケールの値を好みの言語とローカライズされた文字列の値に変更します。 エラーを回避するには、開発者表示ロケール内に少なくとも 1 つの値タグが必要です。

![ローカライズされた文字列の編集](../../images/dev-center/localized-strings/localized-strings.gif)

4. ローカライズされた文字列をすべて追加したら、ドラッグするかローカル コンピューターを参照してファイルをアップロードできます。

![localization.xml ファイルをアップロードするボタンの画像](../../images/dev-center/localized-strings/localized-strings-2.png)

localization.xml ファイルをアップロードするときに、次のエラーが表示される可能性がある点に注意してください。

| エラー | 原因 |
|---------------------------|-------------|
| XSD 検証の失敗: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の要素 'LocalizedString' にテキストを含めることはできません。 指定できる要素の一覧: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の 'Value' | これは、XML ドキュメントの形式が正しくない場合に発生します。 |
| ローカライズ文字列に開発者表示ロケールのエントリがない | これは、ローカライズされた文字列に、ロケールが開発者表示ロケールと一致しないエントリがない場合に発生します。 |
| XSD 検証の失敗: 'locale' 属性が無効 - データ型 'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString' によると 値 ' ' が無効です - パターン制約に失敗しました。 | ローカライズされた文字列のロケールの値がない場合にこれが発生する、 <Value> tag|