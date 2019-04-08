---
Description: 名前を予約してアプリを作成したら、そのアプリを公開するための作業を開始できます。 まず、申請を作成します。
title: アプリの申請
ms.assetid: 363BB9E4-4437-4238-A80F-ABDFC70D96E4
keywords: チェックリスト, windows, uwp, 申請, 提出, ゲーム, アプリ, 送信
ms.date: 10/31/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: b98ea7f1d28c4fcd63cd2d4706905578b240e126
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57643287"
---
# <a name="app-submissions"></a>アプリの申請


[名前を予約してアプリを作成](create-your-app-by-reserving-a-name.md)したら、そのアプリを公開するための作業を開始できます。 まず、**申請**を作成します。

申請は、アプリが完成して公開する準備ができたときに開始できます。または、1 行のコードを記述する前でも情報を入力し始めることができます。 返され、準備ができたときに作業できるように、お客様の提出に行った変更が保存されます。

> [!NOTE]
> 有効である必要があります[開発者アカウント](https://go.microsoft.com/fwlink/p/?LinkId=615100)で[パートナー センター](https://partner.microsoft.com/dashboard) Microsoft Store にアプリを送信するためにします。

アプリが発行された後は、パートナー センターで別の送信を作成して、更新されたバージョンを発行できます。 新しい申請を作成すると、新しいパッケージをアップロードするときでも、価格やカテゴリなどの情報を変更するだけのときでも、必要な変更を加えて公開することができます。 発行されたアプリの新規サブミッションを作成する をクリックして**Update**で示すように、最新の送信の横にあるその**概要**ページ。 できます[ストアからアプリを削除](guidance-for-app-package-management.md#removing-an-app-from-the-store)かどうかに行う (および、使用できるように、後でもう一度たい場合) 必要があります。

> [!NOTE]
> ドキュメントのこのセクションでは、パートナー センターでアプリの提出を作成する方法について説明します。 ここで説明する方法以外に、[Microsoft Store 申請 API](../monetize/create-and-manage-submissions-using-windows-store-services.md) を使用してアプリ申請を自動化することもできます。

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)します。

## <a name="app-submission-checklist"></a>アプリの申請用チェック リスト

ここでは、アプリの申請を作成するときに提供できる詳細情報と、それぞれの詳細へのリンクを示します。

提供または指定する情報には、必須のものと 省略可能なものがあります。提供されている既定値は必要に応じて変更できます。 ここで表示する順序でこれらのセクションで作業する必要はありません。

### <a name="pricing-and-availability-page"></a>[価格と使用可能状況] ページ
| フィールド名                    | メモ                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **市場**                   | 既定:すべての可能な市場  | [価格と市場の選択範囲を定義します。](define-pricing-and-market-selection.md)         |
| **対象ユーザー**                | 既定:パブリック対象ユーザー | [対象ユーザー](choose-visibility-options.md#audience) |
| **見つけやすさ**                | 既定:ストアで使用可能な探索可能なこのアプリを作成します。 | [見つけやすさ](choose-visibility-options.md#discoverability) |
| **スケジュール**                  | 既定:できるだけ早くリリース        | [正確なリリースのスケジュール設定を構成します。](configure-precise-release-scheduling.md) |
| **基本料金**                | 必須                                    | [設定し、アプリの価格のスケジュール設定](set-and-schedule-app-pricing.md)              |
| **無料試用版**                | 既定:無料の試用版なし                      | [無料試用版](set-app-pricing-and-availability.md#free-trial)              |
| **セール価格**              | 省略可能                                    | [アプリとアドオンを販売する](put-apps-and-add-ons-on-sale.md)           |
| **組織のライセンス**    | 既定:組織でボリュームの取得を許可します。 | [組織のライセンス オプション](organizational-licensing.md)        |
      |


### <a name="properties-page"></a>[プロパティ] ページ

| フィールド名                    | メモ                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **カテゴリとサブカテゴリ**  | 必須                                    | [Category と subcategory テーブル](category-and-subcategory-table.md)       |
| **プライバシー ポリシー URL**            | 多くのアプリでは必須。 「[アプリ開発者契約](https://docs.microsoft.com/legal/windows/agreements/app-developer-agreement)」と「[Microsoft Store ポリシー](https://docs.microsoft.com/en-us/legal/windows/agreements/store-policies#105-personal-information)」をご覧ください | [プライバシー ポリシー URL](enter-app-properties.md#privacy-policy-url)        |
| **Web サイト**                   | 省略可能                                    | [Web サイト](enter-app-properties.md#website)                   |
| **サポートの連絡先情報**      | 製品が Xbox で使用可能な場合は必須。それ以外の場合は省略可能 (ただし推奨)                                   | [サポートの連絡先情報](enter-app-properties.md#support-contact-info)              |
| **ゲームの設定**             | 省略可能 (ゲームにのみ適用)         | [ゲームの設定](enter-app-properties.md#game-settings) |
| **表示モード**             | 省略可能                   | [表示モード](enter-app-properties.md#display-mode) |
| **製品の宣言**          | 既定:お客様は、別のドライブまたはリムーバブル記憶域です。 このアプリをインストールできます。Windows は、OneDrive への自動バックアップでこのアプリのデータを含めることができます。 | [製品の宣言](app-declarations.md) |
| **システム要件**      | 省略可能                                    | [システム要件](enter-app-properties.md#system-requirements)      |

<span/>

### <a name="age-ratings-page"></a>[年齢区分] ページ

| フィールド名                    | メモ                                       | 詳しい情報                          |
|-------------------------------|---------------------------------------------|----------------------------------------|
| **年齢別規制**               | 必須                                    | [年齢別規制](age-ratings.md)          |

<span/>

### <a name="packages-page"></a>[パッケージ] ページ

| フィールド名                    | メモ                                  | 詳しい情報                          |
|-------------------------------|----------------------------------------|----------------------------------------|
| **パッケージのアップロード コントロール**    | 必須 (パッケージが 1 つ以上)        | [アプリ パッケージをアップロードします。](upload-app-packages.md) |
| **デバイス ファミリの可用性** | 既定値: パッケージに基づく       | [デバイス ファミリの可用性](device-family-availability.md) |
| **パッケージの段階的なロールアウト**   | 省略可能 (更新プログラムのみ)            | [パッケージの段階的なロールアウト](gradual-package-rollout.md) |
| **必須の更新プログラム**          | 省略可能 (更新プログラムのみ)            | [必須の更新プログラム](upload-app-packages.md#mandatory-update)


### <a name="store-listings"></a>ストア登録情報

必須情報のすべてを、アプリでサポートする言語のうち、少なくとも 1 つの言語で用意する必要があります。 [Store 登録情報](create-app-store-listings.md)は、アプリでサポートするすべての言語で用意することをお勧めします。また[追加の言語で Store 登録情報を用意](create-app-store-listings.md#store-listing-languages)することもできます。 同じ製品の複数の登録情報を管理しやすくするため、[Store 登録情報をインポートおよびエクスポート](import-and-export-store-listings.md)することができます。

| フィールド名                    | メモ                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **説明**               | 必須                                    | [優れたアプリを記述します。](write-a-great-app-description.md) |
| **このバージョンの新機能新機能**   | 省略可能                                 | [リリース ノート](create-app-store-listings.md#whats-new-in-this-version)       |
| **アプリの機能**              | 省略可能                                    | [製品の機能](create-app-store-listings.md#product-features)         |
| **スクリーン ショット**               | 必須 (スクリーンショット 1 つ以上。4 つ以上を推奨)          | [スクリーン ショット](app-screenshots-and-images.md#screenshots)          |
| **ストア ロゴ**               | 推奨。一部の OS バージョンで必須 | [ストア ロゴ](app-screenshots-and-images.md#store-logos)             |
| **トレーラー**                  | 省略可能                                    | [トレーラー](app-screenshots-and-images.md#trailers)                | 
| **Windows 10 と Xbox のイメージ (16:9 のスーパー ヒーロー アート)**     | 推奨        | [Windows 10 および Xbox イメージ (16:9 のスーパー ヒーロー アート)
(app-screenshots-and-images.md#windows-10-and-xbox-image-169-super-hero-art) |
| **Xbox のイメージ**     | Xbox を発行する場合に必要な適切な表示        | [Xbox イメージ
(アプリのスクリーン ショット-images.md #xbox-イメージ) |
| **補足的なフィールド**  | 省略可能                                    | [補足的なフィールド](create-app-store-listings.md#supplemental-fields) 
| **検索語句**              | 省略可能                                    | [検索語句](create-app-store-listings.md#search-terms)         |
| **著作権と商標情報** | 省略可能                                 | [著作権と商標情報](create-app-store-listings.md#copyright-and-trademark-info) |
| **追加ライセンス条項**  | 省略可能                                    | [追加ライセンス条項](create-app-store-listings.md#additional-license-terms) |
| **開発されました。**              | 省略可能                                    | [開発されました。](create-app-store-listings.md#developed-by)                   |


<span/>

### <a name="submission-options-page"></a>申請オプション ページ

| フィールド名                    | メモ                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **発行の保留オプション**     | 既定:証明書を渡す (またはスケジュール セクションで、選択した日付ごと) とすぐにこの提出を発行します。      | [発行の保留オプション](manage-submission-options.md#publishing-hold-options)    
| **認定のノート**     | 推奨          | [認定のノート](notes-for-certification.md)             |
| **制限された機能**     | お使いの製品をいずれかの宣言に必要な[機能の制限](../packaging/app-capability-declarations.md#restricted-capabilities)    | [制限された機能](manage-submission-options.md#publishing-hold-options)       

<span/>

> [!NOTE]
> 基幹業務 (LOB) アプリを企業に直接公開する方法については、「[LOB アプリの企業への配布](distribute-lob-apps-to-enterprises.md)」をご覧ください。
