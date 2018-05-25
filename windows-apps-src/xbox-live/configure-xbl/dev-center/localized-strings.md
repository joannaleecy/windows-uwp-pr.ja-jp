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
ms.localizationpriority: low
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ローカライズされた文字列, Windows デベロッパー センター
ms.openlocfilehash: 216ae763ed136e5762166f6bc098282598b5fe32
ms.sourcegitcommit: 6618517dc0a4e4100af06e6d27fac133d317e545
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/28/2018
---
# <a name="configuring-localized-strings-on-windows-dev-center"></a>Windows デベロッパー センターでのローカライズされた文字列の構成

このページを使うと、すべての Xbox Live 構成をゲームでサポートされているすべての言語にローカライズすることができます。 後続の Xbox Live ページで作成したサービス構成はすべて、ダウンロードしたファイルに追加されます。

[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)を使い、ゲームに関連付けられているすべての言語のローカライズされた文字列を構成できます。 次の手順に従って、構成を追加します。

1. **[サービス]** > **[Xbox Live]** > **[Localized strings]** (ローカライズされた文字列) の順に選択して、**[Localized strings]** (ローカライズされた文字列) セクションに移動します。
2. **[ダウンロード]** をクリックすると、localization.xml ファイルがローカル コンピューターにダウンロードされます。

![デベロッパー センターのローカライズされた文字列構成ページのスクリーンショット](../../images/dev-center/localized-strings/localized-strings-1.png)

3. ローカライズされた文字列を追加するには、<Value locale="en-US">Mazes Played</Value> タグを複製し、ロケールの値を選択した言語とローカライズされた文字列の値に変更します。 エラーを回避するには、開発者表示ロケール内に少なくとも 1 つの値タグが必要です。

![ローカライズされた文字列の編集](../../images/dev-center/localized-strings/localized-strings.gif)

4. ローカライズされた文字列をすべて追加したら、ドラッグするかローカル コンピューターを参照してファイルをアップロードできます。

![localization.xml ファイルをアップロードするボタンの画像](../../images/dev-center/localized-strings/localized-strings-2.png)

localization.xml ファイルをアップロードするときに、次のエラーが表示される可能性がある点に注意してください。

| エラー | 原因 |
|---------------------------|-------------|
| XSD 検証の失敗: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の要素 'LocalizedString' にテキストを含めることはできません。 指定できる要素の一覧: 名前空間 'http://config.mgt.xboxlive.com/schema/localization/1' の 'Value' | これは、XML ドキュメントの形式が正しくない場合に発生します。 |
| ローカライズ文字列に開発者表示ロケールのエントリがない | これは、ローカライズされた文字列に、ロケールが開発者表示ロケールと一致しないエントリがない場合に発生します。 |
| XSD 検証の失敗: 'locale' 属性が無効 - データ型 'http://config.mgt.xboxlive.com/schema/localization/1:NonEmptyString' によると 値 ' ' が無効です - パターン制約に失敗しました。 | これは、ローカライズされた文字列に <Value> タグのロケール値がない場合に発生します。|