---
title: Visual Studio で Unity ゲームをテストします。
description: Unity の成功したテストするためのチェックリストは、Visual Studio でビルドします。
ms.date: 03/19/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: 4d5a1a5596beba2839e01ca5be6e6d2dbff0c148
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589877"
---
# <a name="test-your-unity-game-build-in-visual-studio"></a>Visual Studio で、Unity ゲームのビルドをテストします。

実際のデータを使用して、Unity ゲームの Xbox Live 機能をテストする」の説明に従って、ゲームをビルドする必要があります、**ビルドとテスト プロジェクト**のセクション、 [Unity での Xbox Live の構成](configure-xbox-live-in-unity.md)します。 次の記事から Visual Studio で Unity ゲームのテストの完了を確保しやすく項目のチェックリストが提供されます。

1. **あなたの Unity ゲームに関連付けられた、適切に構成されたタイトルがあることを再確認します。**
    Xbox Live の関連付けウィザードでの Xbox Live を有効にした場合を理解する[パートナー センター](https://partner.microsoft.com/dashboard)します。 パートナー センターでは、Xbox Live のタイトルの設定を構成することができ、Xbox Live との通信にタイトルの順序で適切にセットアップをする必要があります。 この記事[新しい Xbox Live クリエーターズ プログラムのタイトルを作成し、テスト環境に公開](create-and-test-a-new-creators-title.md)はパートナー センターのセットアップ プロセスです。 既にある場合のセットアップを通じて、ゲーム、 **Xbox 構成ウィザード**Unity では、セクションにスキップできます[、ゲームでのサービス構成のテストの Xbox Live](create-and-test-a-new-creators-title.md#test-xbox-live-service-configuration-in-your-game)します。 パートナー センターの中に、あなたの Unity ゲームの Xbox Live 構成内の情報が、ゲームのパートナー センターの構成と一致することを確認してください。

2. **タイトルにサインインできる、タイトルにする承認済みの Microsoft Account(with gamertag) があることを確認します。**
    承認済みのアカウントを使用せずことはできませんに完全なサインインで、タイトルのテスト中にもができるその他の Xbox Live の機能を使用します。 承認済みの Microsoft アカウントとゲーマータグがあるかどうかを確認するには、読み取る[環境内でのテスト用の Xbox Live アカウントの承認](authorize-xbox-live-accounts.md)します。

3. **テストするため、タイトルが公開されていることを確認します。**
    使用する、サンド ボックスに加えると、タイトルにそれらの変更を発行する必要があります。 プッシュすることを確認、**テスト**の構成に変更を発行するボタンをクリックします。

    ![テスト イメージを発行します。](../images/creators_udc/creators_udc_xboxlive_config_test.png)

    **テスト**ボタンがある[パートナー センター](https://partner.microsoft.com/dashboard)タイトルの Xbox Live サービス設定。 プッシュする新しい承認済みのテスト アカウントの追加などの構成変更を加えた場合、**テスト**Xbox Live サービスに、新しい構成設定を発行するボタンをクリックします。

4. **お使いの PC が開発者モードで、適切な Xbox Live Sandbox を使用しているかどうかを確認することを確認します。**
    タイトル用にパブリッシュされたテストは、サンド ボックスと呼ばれる特定の環境にパブリッシュします。 サンド ボックスを使用する開発用 PC が設定されていない場合 Xbox Live の機能をテストすることはできません。 チェックし、PC のサンド ボックスに変更する方法を学習、[サンド ボックスの概要の Xbox Live](xbox-live-sandboxes-creators.md)します。

5. **X64 としてプロジェクトをビルドすることを確認、PC 上に構築するためのローカルのコンピューターを対象とするビルド**

    ![ビルド設定](../images/unity/get-started-with-creators/vsBuildSettings.JPG)