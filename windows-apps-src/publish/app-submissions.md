---
author: jnHs
Description: Once you've created your app by reserving a name, you can start working on getting it published. The first step is to create a submission.
title: アプリの申請
ms.assetid: 363BB9E4-4437-4238-A80F-ABDFC70D96E4
keywords: チェックリスト, windows, uwp, 申請, 提出, ゲーム, アプリ, 送信
ms.author: wdg-dev-content
ms.date: 04/03/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: high
ms.openlocfilehash: 1ec4201060adf4a9f5c2916d605b3c995cd44fc6
ms.sourcegitcommit: 9f059b37e45099b4314c96a0b604449e966d3c3c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/04/2018
---
# <a name="app-submissions"></a>アプリの申請


[名前を予約してアプリを作成](create-your-app-by-reserving-a-name.md)したら、そのアプリを公開するための作業を開始できます。 まず、**申請**を作成します。

申請は、アプリが完成して公開する準備ができたときに開始できます。または、1 行のコードを記述する前でも情報を入力し始めることができます。 申請はダッシュボードに保存されるため、準備できたらいつでも作業できます。

アプリが公開された後は、ダッシュボードで別の申請を作成して更新バージョンを公開できます。 新しい申請を作成すると、新しいパッケージをアップロードするときでも、価格やカテゴリなどの情報を変更するだけのときでも、必要な変更を加えて公開することができます。 公開されているアプリに対して新しい申請を作成するには、[アプリの概要] ページに表示されている前回の申請の横にある **[更新]** をクリックします。

> [!NOTE]
> このセクションでは、デベロッパー センター ダッシュボードでアプリの申請を作成する方法について説明します。 ここで説明する方法以外に、[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアプリ申請を自動化することもできます。

## <a name="app-submission-checklist"></a>アプリの申請用チェック リスト

ここで示しているのは、アプリの申請を作成するときに提供できる詳細情報と、詳細情報のリンクです。

提供または指定する情報は必須のものと、 省略可能なものがあります。提供されている既定値は必要に応じて変更できます。

### <a name="pricing-and-availability-page"></a>[価格と使用可能状況] ページ
| フィールド名                    | コメント                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **市場**                   | 既定値: 対象となるすべての市場  | [[価格設定と市場設定] セクション](define-pricing-and-market-selection.md)         |
| **対象ユーザー**                | 既定値: パブリック対象ユーザー | [対象ユーザー](choose-visibility-options.md#audience) |
| **見つけやすさ**                | 既定値: この製品を Microsoft Store で提供し、検索可能にします | [見つけやすさ](choose-visibility-options.md#discoverability) |
| **スケジュール**                  | 既定値: 最短でリリース        | [正確なリリース スケジュールの構成](configure-precise-release-scheduling.md) |
| **基本価格**                | 必須                                    | [アプリの価格の設定とスケジュール](set-and-schedule-app-pricing.md)              |
| **無料試用版**                | 既定値: 無料の試用版なし                      | [無料試用版](set-app-pricing-and-availability.md#free-trial)              |
| **セール価格**              | 省略可能                                    | [アプリとアドオンの販売](put-apps-and-add-ons-on-sale.md)           |
| **組織のライセンス**    | 既定値: 組織単位でのボリューム購入を許可する | [組織のライセンス オプション](organizational-licensing.md)        |
      |


### <a name="properties-page"></a>[プロパティ] ページ

| フィールド名                    | コメント                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **カテゴリとサブカテゴリ**  | 必須                                    | [カテゴリとサブカテゴリの一覧](category-and-subcategory-table.md)       |
| **プライバシー ポリシーの URL**            | 多くのアプリでは必須。 「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」と「[Microsoft Store ポリシー](https://docs.microsoft.com/en-us/legal/windows/agreements/store-policies#105-personal-information)」をご覧ください | [プライバシー ポリシーの URL](enter-app-properties.md#privacy-policy-url)        |
| **Web サイト**                   | 省略可能                                    | [Web サイト](enter-app-properties.md#website)                   |
| **サポートの問い合わせ先情報**      | 製品が Xbox で使用可能な場合は必須。それ以外の場合は省略可能 (ただし推奨)                                   | [サポートの問い合わせ先情報](enter-app-properties.md#support-contact-info)              |
| **ゲーム設定**             | 省略可能 (ゲームにのみ適用)         | [ゲーム設定](enter-app-properties.md#game-settings) |
| **表示モード**             | 省略可能                   | [表示モード](enter-app-properties.md#display-mode) |
| **製品の宣言**          | 既定値: ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。Windows はこのアプリのデータを OneDrive に自動的にバックアップできます | [製品の宣言](app-declarations.md) |
| **システム要件**      | 省略可能                                    | [システム要件](enter-app-properties.md#system-requirements)      |

<span/>

### <a name="age-ratings-page"></a>[年齢区分] ページ

| フィールド名                    | コメント                                       | 詳しい情報                          |
|-------------------------------|---------------------------------------------|----------------------------------------|
| **年齢区分**               | 必須                                    | [年齢区分](age-ratings.md)          |

<span/>

### <a name="packages-page"></a>[パッケージ] ページ

| フィールド名                    | コメント                                  | 詳しい情報                          |
|-------------------------------|----------------------------------------|----------------------------------------|
| **パッケージのアップロード制御**    | 必須 (パッケージが 1 つ以上)        | [アプリ パッケージのアップロード](upload-app-packages.md) |
| **デバイス ファミリの利用可否** | 既定値: パッケージに基づく       | [デバイス ファミリの利用可否](device-family-availability.md) |
| **段階的なパッケージのロールアウト**   | 省略可能 (更新プログラムのみ)            | [段階的なパッケージのロールアウト](gradual-package-rollout.md) |
| **必須の更新プログラム**          | 省略可能 (更新プログラムのみ)            | [必須の更新プログラム](upload-app-packages.md#mandatory-update)


### <a name="store-listings"></a>ストア登録情報

必須情報のすべてを、アプリでサポートする言語のうち、少なくとも 1 つの言語で用意する必要があります。 [Store 登録情報](create-app-store-listings.md)は、アプリでサポートするすべての言語で用意することをお勧めします。また[追加の言語で Store 登録情報を用意](create-app-store-listings.md#store-listing-languages)することもできます。 同じ製品の複数の登録情報を管理しやすくするため、[Store 登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することができます。

| フィールド名                    | コメント                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **説明**               | 必須                                    | [人の心をつかむアプリの説明を書く](write-a-great-app-description.md) |
| **今回のバージョンでの新機能**   | 省略可能                                 | [リリース ノート](create-app-store-listings.md#whats-new-in-this-version)       |
| **アプリの機能**              | 省略可能                                    | [アプリの機能](create-app-store-listings.md#app-features)         |
| **スクリーンショット**               | 必須 (スクリーンショット 1 つ以上。4 つ以上を推奨)          | [スクリーンショット](app-screenshots-and-images.md#screenshots)          |
| **Microsoft Store ロゴ**               | 推奨。一部の OS バージョンで必須 | [Microsoft Store ロゴ](app-screenshots-and-images.md#store-logos)             |
| **追加のアート資産**     | 推奨 (特に一部の OS バージョンで推奨)         | [追加のアート資産](app-screenshots-and-images.md#additional-art-assets) |
| **トレーラー**                  | 省略可能                                    | [トレーラー](app-screenshots-and-images.md#trailers)                | 
| **補足情報**  | 省略可能                                    | [補足情報](create-app-store-listings.md#supplemental-information) 
| **検索語句**              | 省略可能                                    | [検索語句](create-app-store-listings.md#search-terms)         |
| **著作権と商標の情報** | 省略可能                                 | [著作権と商標の情報](create-app-store-listings.md#copyright-and-trademark-info) |
| **追加のライセンス条項**  | 省略可能                                    | [追加のライセンス条項](create-app-store-listings.md#additional-license-terms) |
| **Developed by (開発元)**              | 省略可能                                    | [Developed by (開発元)](create-app-store-listings.md#developed-by)                   |
| **プラットフォーム固有の Store 登録情報** | 省略可能                               | [プラットフォーム固有の Store 登録情報の作成](create-platform-specific-store-listings.md)  |

<span/>

### <a name="submission-options-page"></a>申請オプション ページ

| フィールド名                    | コメント                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **公開の保留オプション**                | 既定: この申請が認定されたら、すぐに申請を公開します (または [スケジュール] セクションで選択した各日付で公開します)      | [公開の保留オプション](manage-submission-options.md#publishing-hold-options)    
| **認定の注意書き**                     | 推奨                                    | [認定の注意書き](notes-for-certification.md)             |

<span/>

> [!NOTE]
> 基幹業務 (LOB) アプリを企業に直接公開する方法については、「[LOB アプリの企業への配布](distribute-lob-apps-to-enterprises.md)」をご覧ください。
