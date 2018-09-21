---
title: Xbox Live Account Tool
author: KevinAsgari
description: Xbox Live Account Tool を使って Xbox Live 対応タイトルをテストするためのテスト アカウントをすばやく作成する方法について説明します。
ms.assetid: ec5959f9-1c60-4aa4-94a6-5d8bdcf77a96
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, テスト, テスト アカウント
ms.localizationpriority: medium
ms.openlocfilehash: 55e2d46f59a8ecd2d8bac77e8ce61834a4249a88
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4111883"
---
# <a name="xbox-live-account-tool"></a>Xbox Live Account Tool

## <a name="what-is-xbox-live-account-tool"></a>Xbox Live Account Tool とは
Xbox Live Account Tool は、タイトル デベロッパーが既存のデベロッパー アカウントをゲーム シナリオのテスト用にセットアップするときに使用できるように作られています。 たとえば、Xbox Live Account Tool を使用すると、デベロッパー アカウントのゲーマータグを変更したり、アカウントのフレンド リストに 1000 人のフォロワーをすばやく追加したりできます。

## <a name="what-can-i-do-with-xbox-live-account-tool"></a>Xbox Live Account Tool の機能
以下が可能です。
  1. ユーザーのプロフィール設定、XUID、アクティブな権限を表示する
  2. フォロワーのリストをテキスト ファイルまたは Xbox 開発者向けプラットフォーム csv からユーザーのソーシャル グラフに追加します。
  3. ユーザーのフレンド リストを管理する: フォローしているユーザーのお気に入り登録、お気に入り解除、ブロック、ブロック解除、およびそのユーザーにフォローされているかどうかの確認
  4. 開発ユーザーの評判を変更する (および、未処理の評判統計値をすぐに表示する)
  5. ユーザーのゲーマータグを変更する

## <a name="where-can-i-find-xbox-live-account-tool"></a>Xbox Live Account Tool の入手方法
Xbox Live ツール パッケージの一部として Xbox Live Account Tool が見つかりません[https://aka.ms/xboxliveuwptools](https://aka.ms/xboxliveuwptools)します。

## <a name="how-do-i-log-in"></a>ログイン方法
管理対象のユーザーの資格情報が必要であり、正しいサンドボックスを指定する必要があります。 デベロッパー アカウントにサンドボックスへのアクセス権があることを確認してください。アクセス権がないとログインできません。 このツールは、サンドボックスを使用するデベロッパー アカウントを想定して設計されています。

## <a name="can-i-use-a-retail-account-or-does-it-have-to-be-a-sandboxed-account"></a>リテール アカウントを使用できますか? サンドボックス アカウントを使用する必要がありますか?
Xbox Live Account Tool を使用してリテール アカウントを管理できますが、すべての機能がサポートされるわけではありません。 たとえば、リテール ユーザーの評判を変更することはできません。

## <a name="how-do-i-change-a-dev-users-gamertag"></a>開発ユーザーのゲーマータグを変更する方法
[Gamertag] タブに移動してゲーマータグを入力します。 ゲーマータグに使用できるのは英数字と空白文字のみで、長さは 15 文字以下でなければなりません。 デベロッパー アカウント ゲーマータグは、2 で始まっている必要があります。 現在は 1 つの変更のみサポートされています。

## <a name="how-do-i-see-my-block-list"></a>ブロック リストを表示する方法
[People] タブに移動し、[Blocked] 列見出しを選択して、現在ブロックされているユーザーで並べ替えます。

## <a name="how-do-i-follow-a-large-group-of-users"></a>大きいユーザー グループをフォローする方法
フォローする必要のある XUID のリストがある場合、それをテキスト ファイルにコピーします。 [Follow] タブに移動し、[Import list] を選択して、ファイルを選択します。 XUID がリスト ビューに設定されます。 [commit changes] をクリックしてユーザーをフォローします。

## <a name="how-do-i-block-someone"></a>ユーザーをブロックする方法
[People] タブに移動し、ブロックするユーザー (1 人または複数) を選択します。 [block] ボタンをクリックすると、まとめてブロックされます。 エラーが発生する場合は、後でやり直してください。

## <a name="how-do-i-change-my-dev-accounts-repuation"></a>開発アカウントの評判を変更する方法
[Reputation] タブに移動します。適切な既定値を選択し、[Commit changes] ボタンをクリックして要求を送信します。 要求が成功した場合、評判の統計値が変更されます。

## <a name="what-do-the-values-in-the-reputation-tab-mean"></a>[Reputation] タブの値の意味
総合的な評判は、フェアプレイ (マルチプレイヤーでの行動)、ユーザー作成コンテンツ (ビデオ クリップなど)、コミュニケーション (メッセージと音声) という 3 つの下位評判から計算されます。 各カテゴリー未処理の値は 0 ～ 75 の範囲の値で、値が高いほどユーザーの評判が良いことを意味します。 OverallStatIsBad は、ユーザーの評判が "敬遠対象" かどうかを示します。

## <a name="whats-the-black-area-at-the-bottom"></a>下部の黒い領域は何のためにあるのですか?
情報提供のために、UI にデバッグ出力を表示すると役に立つと考えました。 この領域には、ツールの動作状態および発生したエラーが表示されます。

## <a name="wheres-my-gamerpic"></a>ゲーマーアイコンはどこにありますか?
アカウント作成時に一部の開発アカウントのゲーマーアイコンが自動的に生成されないというバグが確認されています。

## <a name="why-are-things-happening-so-slowly"></a>処理速度が非常に遅いのはなぜですか?
バッチ操作 (フォロワーの追加など) の場合、ツールは自動的にバッチを実行して要求のサイズが大きくなるのを防ぎます。

## <a name="how-do-i-run-xbox-live-account-tool"></a>Xbox Live Account Tool の実行方法
Xbox Live SDK をフォルダーに展開し、Tools\XboxLiveAccountTool.exe ファイルをダブルクリックして実行します。

## <a name="i-have-a-feature-request-how-do-i-get-my-feature-incorporated"></a>搭載してほしい機能があります。 どうすれば機能を組み込んでもらえますか?
マイクロソフトの担当者に機能をお伝えいただければ、検討いたします。
