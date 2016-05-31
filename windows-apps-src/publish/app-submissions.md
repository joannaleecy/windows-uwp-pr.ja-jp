---
author: jnHs Description: 名前を予約してアプリを作ったら、公開の作業を開始できます。 まず、申請を作成します。
title: アプリの申請 ms.assetid: 363BB9E4-4437-4238-A80F-ABDFC70D96E4 keywords: アプリの申請 keywords: 必須情報 keywords: 必須フィールド keywords: 必須データ keywords: チェック リスト
---

# アプリの申請


[名前を予約してアプリを作ったら](create-your-app-by-reserving-a-name.md)、公開の作業を開始できます。 まず、**申請**を作成します。

申請は、アプリが完成して公開する準備ができたときに開始できます。または、1 行のコードを記述する前でも情報を入力し始めることができます。 申請はダッシュボードに保存されるため、準備できたらいつでも作業できます。

アプリが公開された後は、ダッシュボードで別の申請を作成して更新バージョンを公開できます。 新しい申請を作成すると、新しいパッケージをアップロードするときでも、価格やカテゴリなどの情報を変更するだけのときでも、必要な変更を加えて公開することができます。 アプリの新しい申請を作成するには、[アプリの概要] ページに表示されている前回の申請の横にある **[更新]** をクリックします。

## アプリの申請用チェック リスト


ここで示しているのは、アプリの申請を作成するときに提供できる詳細情報と、詳細情報のリンクです。

提供または指定する情報は必須のものと、 省略可能なものがあります。提供されている既定値は必要に応じて変更できます。

### [価格設定] ページ
| フィールド名                    | コメント                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **基本価格**                | 必須                                    | [基本価格](set-app-pricing-and-availability.md#base-price)              |
| **無料試用版**                | 既定値: 無料の試用版なし                      | [お試し版とアプリ内購入の追加](https://msdn.microsoft.com/library/windows/apps/jj193599)  |
| **市場と特別価格** | 既定値: 対象となるすべての市場、カスタム価格なし | [価格と市場の選択の定義](define-pricing-and-market-selection.md)              |
| **セール価格**              | 省略可能                                    | [アプリと IAP の販売](put-apps-and-iaps-on-sale.md)                                       |
| **Distribution and visibility (配布と表示)** | 既定値: このアプリをストアで提供する | [Distribution and visibility (配布と表示)](set-app-pricing-and-availability.md#distribution-and-visibility) | 
| **Windows 10 デバイス ファミリ**  | 既定値: すべての動作可能な Windows 10 デバイスへアプリをダウンロードできます | [Windows 10 デバイス ファミリ](set-app-pricing-and-availability.md#windows-10-device-families) | 
| **組織のライセンス**    | 既定値: このアプリの組織単位でのボリューム購入を許可します | [組織のライセンス オプション](organizational-licensing.md)                        | 
| **公開日**                | 既定値: できるだけ早く公開      | [公開日](set-app-pricing-and-availability.md#publish-date)          |



### [アプリケーションのプロパティ] ページ

| フィールド名                    | コメント                                       | 詳しい情報                                                             |
|-------------------------------|---------------------------------------------|---------------------------------------------------------------------------|
| **カテゴリとサブカテゴリ**  | 必須                                    | [カテゴリとサブカテゴリの一覧](category-and-subcategory-table.md)       |
| **Hardware preferences (ハードウェアの基本設定)**      | 省略可能                                    | [Hardware preferences (ハードウェアの基本設定)](enter-app-properties.md#hardware_preferences)      |
| **アプリの宣言**          | 既定値: ユーザーは、代替ドライブやリムーバブル ストレージにこのアプリをインストールできます。Windows はこのアプリのデータを OneDrive に自動的にバックアップできます | [アプリの宣言](app-declarations.md) |



### [年齢区分] ページ

| フィールド名                    | コメント                                       | 詳しい情報                          |
|-------------------------------|---------------------------------------------|----------------------------------------|
| **年齢区分**               | 必須                                    | [年齢区分](age-ratings.md)          |



### [パッケージ] ページ

| フィールド名                    | コメント                                       | 詳しい情報                          |
|-------------------------------|---------------------------------------------|----------------------------------------|
| **パッケージのアップロード制御**    | 必須 (パッケージが 1 つ以上)             | [アプリ パッケージのアップロード](upload-app-packages.md) | 



### [説明] ページ

必須情報のすべてを、アプリでサポートする言語のうち、少なくとも 1 つの言語で用意する必要があります。 利用可能なすべての言語で説明を用意することをお勧めします。

| フィールド名                    | コメント                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **説明**               | 必須                                    | [人の心をつかむアプリの説明を書く](write-a-great-app-description.md) | 
| **リリース ノート**             | 省略可能                                    | [リリース ノート](create-app-descriptions.md#release-notes)         |
| **スクリーンショット**               | 必須 (スクリーンショットが 1 つ以上)          | [アプリのスクリーンショットと画像](app-screenshots-and-images.md)       |
| **アプリのタイル アイコン**             | 省略可能、ただし Windows Phone 8.1 では強く推奨 | [アプリのタイル アイコン](create-app-descriptions.md#app-tile-icon) | 
| **Promotional artwork (プロモーション用のアートワーク)**       | 省略可能                                    | [アプリのスクリーンショットと画像](app-screenshots-and-images.md)       | 
| **アプリの機能**              | 省略可能                                    | [機能](create-app-descriptions.md#app-features)               |
| **推奨されるハードウェア**      | 省略可能                                    | [推奨されるハードウェア](create-app-descriptions.md#recommended-hardware) | 
| **キーワード**                  | 省略可能                                    | [キーワード](create-app-descriptions.md#keywords)                   |
| **著作権と商標の情報** | 省略可能                                 | [著作権と商標の情報](create-app-descriptions.md#copyright-and-trademark-info) | 
| **追加のライセンス条項**  | 省略可能                                    | [追加のライセンス条項](create-app-descriptions.md#additional-license-terms) | 
| **Web サイト**                   | 省略可能                                    | [Web サイト](create-app-descriptions.md#website)                     |
| **サポートの問い合わせ先情報**      | 省略可能                                    | [サポートの問い合わせ先情報](create-app-descriptions.md)                | 
| **プライバシー ポリシー**            | 一部のアプリでは必須。 「[アプリ開発者契約書](https://msdn.microsoft.com/library/windows/apps/hh694058)」と「[Windows ストア ポリシー](https://msdn.microsoft.com/library/windows/apps/dn764944.aspx#pol_10_5_1)」をご覧ください | [プライバシー ポリシー](create-app-descriptions.md#privacy-policy) | 
| **Platform-specific descriptions (プラットフォーム固有の説明)** | 省略可能                               | [プラットフォーム固有の説明の作成](create-platform-specific-descriptions.md) |



### [認定を求めるにあたってのコメント] ページ

| フィールド名                    | コメント                                       | 詳しい情報                                                     |
|-------------------------------|---------------------------------------------|-------------------------------------------------------------------|
| **コメント**                     | 省略可能                                    | [認定を求めるにあたってのコメント](notes-for-certification.md)             |

 
**注**  基幹業務 (LOB) アプリを企業に直接公開する方法については、「[LOB アプリの企業への配布](distribute-lob-apps-to-enterprises.md)」をご覧ください。


<!--HONumber=May16_HO2-->


