---
title: PlayerAuthentication プレハブを使用してサインイン
description: Unity のプラグイン PlayerAuthentication プレハブの概要
ms.date: 05/08/2018
ms.topic: get-started-article
keywords: xbox live、xbox、ゲーム、uwp、windows 10、1 つ xbox、unity
ms.openlocfilehash: ea161ff801e2004569d88d53c78ae963e91b4ce6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605737"
---
# <a name="easy-sign-in-with-the-playerauthentication-prefab"></a>PlayerAuthentication プレハブを使用して簡単なサインイン

PlayerAuthentication プレハブは、Xbox Live の認証、タイトルを追加する最も簡単な方法です。 サインイン ページに新しいシーンから移動する 3 つの簡単な手順だけかかります。

1. PlayerAuthentication プレハブをシーンにドラッグします。
2. XboxLiveServices プレハブをシーンにドラッグします。
3. EventSystem、シーンを追加 (PlayerAuthentication 技術的には作成されますが、EventSystem が存在しないが、推奨は、追加する場合。)

これで完了です。 シーンに PlayerAuthentication プレハブをクリックして XboxLive に、タイトルのプレーヤーを署名することができますようになりました。 Unity で再生 ボタンをクリックして、シーンをテストする、プレハブ仮のデータを生成すると、これは、Unity プレーヤーが Xbox Live サービスに接続できないためです。 実際のサインインを確認するためには、Visual Studio でローカルで実行するプロジェクトをビルドする必要があります。 タイトルが構成されている場合、パートナー センターとお客様が、タイトルにサインインする Microsoft アカウント/ゲーマータグを承認し、サインイン、Visual Studio のビルドで、承認されたアカウントのいずれかのことができます。

PlayerAuthentication プレハブのスクリプトでは、インスペクターでは、そのビューから操作できるいくつかの設定があります。

![PlayerAuthentication インスペクターのスクリーン ショット](../images/unity/playerauthentication_prefab_inspector.JPG)

* プレーヤー数 - サインイン パネルにリンクされているプレーヤーを決定します。
* テーマ - がの場合、ユーザー サインインまたはサインアウトのサインインがパネルの配色を変更します。この設定は、明るいまたは暗いオプションです。
* 有効にするコント ローラーからの入力がプレーヤーでは、このチェック ボックスをサインインおよびサインアウト PlayerAuthentication プレハブを使用して、Xbox コント ローラーを使用します。
* ジョイスティック数 - コント ローラーがサインインできるこの出力を決定する、プレハブを使用します。
* ボタン - ユーザーのサインイン Xbox コント ローラーでは、どのボタンを選択することができるドロップダウンにサインインします。
* ボタン - ユーザーをサインアウト Xbox コント ローラーでは、どのボタンを選択することができますをドロップダウンからサインアウトします。

## <a name="multiplayer-scenario"></a>マルチ プレーヤー シナリオ

サインインの 1 つのプレーヤーだけでなく Xbox One のコンソールのタイトルにローカルのマルチ プレーヤーを実装するために複数の PlayerAuthentication プレハブを使用することもできます。 プレハブの複数のインスタンスを追加し、それぞれのプレーヤー数の属性を変更して、タイトルに複数のユーザーにサインインすることができます。

> [!WARNING]
> 署名で複数のゲーマータグは Windows 10 Pc では許可されません。 複数のユーザーにサインインするためには、Xbox 1 つのコンソール ゲームをテストする必要があります。

マルチ プレーヤーを許可するシーンを作成するでは、多少困難 PlayerAuthentication プレハブを使用してのみです。

1. PlayerAuthentication プレハブのインスタンスをシーンにドラッグします。
2. チェック、**コント ローラーの入力を有効にする**プレハブのインスペクターのボックスです。
3. 確認、**プレーヤー数**と**ジョイスティック数**1 に設定されます。
4. 割り当てる、**記号のボタン**ドロップ ダウン メニューから。
5. 割り当てる、**サインイン ボタンをクリック**ドロップ ダウン メニューから。
6. ドラッグ、 *2 番目*シーンに PlayerAuthentication プレハブのインスタンス。
7. チェック、**コント ローラーの入力を有効にする**プレハブのインスペクターのボックスです。
8. 確認、**プレーヤー数**と**ジョイスティック数**2 に設定されます。
9. 割り当てる、**記号のボタン**ドロップ ダウン メニューから。
10. 割り当てる、**サインイン ボタンをクリック**ドロップ ダウン メニューから。
11. XboxLiveServices プレハブをシーンにドラッグします。
12. EventSystem をシーンに追加します。

プレハブを Unity プレーヤーで再生のキーを押してして正常に動作し、プレハブをクリックするとことを確認します。 これらは、Unity プレーヤーが Xbox Live に接続できないように予定されている仮のデータを返します。 さまざまなプレイヤーと、Visual Studio でゲームをビルドする準備が整ったらジョイスティックするように構成 PlayerAuthentication プレハブの 2 つのインスタンスが適切でテストできます、Xbox コンソール。 ゲームの構築後は、ゲームのマルチ ユーザー サポートを有効にする必要がありますが、Visual Studio でソリューション ファイルを開きます。
これには、次の手順を実行します。

1. Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。
2. ファイルを右クリックし、コードの表示
3. で、`<Properties><\/Properties>`セクションで、次の行を追加します: ' < uap:SupportedUsers > 複数 <\/uap:SupportedUsers >。
4. お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。 Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。

> [!NOTE]
> 構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。

動作がアーティクルと共にスクリプトのサインインの詳細を学べるようになったら、PlayerAuthentication prefab [Unity でのサインイン マネージャーを使用してサインイン](sign-in-manager.md)します。