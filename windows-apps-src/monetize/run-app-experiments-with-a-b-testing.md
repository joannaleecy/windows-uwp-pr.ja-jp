---
author: mcleanbyron
Description: "Windows デベロッパー センター ダッシュボードを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリの A/B テストを実行することができます。"
title: "A/B テストを使用してアプリの試験的機能を実行する"
ms.assetid: 790B4B37-C72D-4CEA-97AF-D226B2216DCC
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 88fd0516e3c10b657884b93377480b62c1758992

---

# A/B テストを使用してアプリの試験的機能を実行する

Windows デベロッパー センター ダッシュボードを使用して、ユニバーサル Windows プラットフォーム (UWP) アプリの A/B テストを実行することができます。

A/B テストでは、デベロッパー センターを通じてアプリのプログラムの変数割り当てを検証します。 A/B テストが可能なプログラムの変数にアプリのロジックを構築することによって、ユーザーのランダム化されたセグメント向けにアプリのバリエーションを有効にすることができます。 A/B テストの目的は、アプリ内購入が増えるなど、コンバージョン率を上げる可能性のあるバリエーションを識別することです。

ビジネス目標に最も適したバリエーションを識別したら、アプリを再公開しなくても、すぐに試験的機能を終了してデベロッパー センター ダッシュボードからユーザー全体にそのバリエーションを有効にすることができます。

## A/B テストを作成および実行する

A/B テストを作成および実行するには、次の手順に従います。

1. [デベロッパー センター ダッシュボードで試験的機能を定義します](define-your-experiment-in-the-dev-center-dashboard.md)。 試験的機能はそれぞれ、以下のもので構成されます。
  * ビュー イベントは試験的機能の一部であるバリエーションのチェックをユーザーが開始することを示します。**
  * コンバージョン イベントによる 1 つ以上の目標では、いつ目標に達したかを示します。**
  * 1 つ以上のバリエーションでは、試験的機能で使用する設定を定義します。**
2. [アプリで試験的機能のコードを記述します](code-your-experiment-in-your-app.md)。 Microsoft Store Engagement and Monetization SDK にある API を使用して、実験のバリエーション設定を取得します。次にこのデータを使用して、テストしている機能の動作を変更します。そしてビュー イベントおよびコンバージョン イベントをデベロッパー センターへ送信します。
3. [デベロッパー センター ダッシュボードで試験的機能を実行および管理します](manage-your-experiment.md)。 ダッシュボードを使用して、試験的機能の結果を確認し、試験的機能を完了します。

エンド ツー エンドのプロセスを示すチュートリアルについては、「[A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)」をご覧ください。

## 必要条件

Windows デベロッパー センターの A/B テストは、UWP アプリのみでサポートされています。

A/B テストを実行する前に、開発用コンピューターを設定する必要があります。

* [ここ](../get-started/get-set-up.md)で説明する指示に従って、UWP 開発のための開発用コンピューターを設定します。
* [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) をインストールします。 試験的機能用の API に加えて、この SDK は広告を表示したり、アプリのフィードバックを収集するフィードバック Hub にユーザーを誘導するなど、その他の機能のための API も提供します。 この SDK について詳しくは、「[Store Engagement and Monetization SDK によるアプリ収益の獲得](monetize-your-app-with-the-microsoft-store-engagement-and-monetization-sdk.md)」をご覧ください。

## ベスト プラクティス

最も有用な結果を得るには、A/B テストを実行しているときに、次の推奨事項に従うことをお勧めします。

* バリエーションの割り当て用に、ランダム化された 50/50 分割の配布による 2 つのみのバリエーションで試験的機能を実行することを検討してください。
* 統計的に重要でアクション可能なデータを十分収集するために、少なくとも 2 ～ 4 週間はテストを実行します。

## 関連トピック

* [デベロッパー センター ダッシュボードで試験的機能を定義する](define-your-experiment-in-the-dev-center-dashboard.md)
* [アプリで試験的機能のコードを記述する](code-your-experiment-in-your-app.md)
* [デベロッパー センター ダッシュボードで試験的機能を管理する](manage-your-experiment.md)
* [A/B テストを使用して最初の試験的機能を作成および実行する](create-and-run-your-first-experiment-with-a-b-testing.md)



<!--HONumber=Jun16_HO4-->


