---
title: マルチユーザー サポートを Unity ゲームに追加する
author: KevinAsgari
description: Xbox Live Unity プラグインを使用して、マルチユーザー サポートを Unity ゲームに追加する
ms.assetid: ''
ms.author: heba
ms.date: 07/14/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, マルチユーザー
ms.localizationpriority: medium
ms.openlocfilehash: cc59d014bae8553cbbc9a4aca1db954872d28029
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4750632"
---
# <a name="add-multi-user-support-to-your-unity-game"></a>マルチユーザー サポートを Unity ゲームに追加する
> [!IMPORTANT]
> Xbox Live Unity プラグインでは、実績とオンライン マルチプレイヤーがサポートされていないため、[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。

現在、マルチユーザー サポートは Xbox Live Unity プラグインによって利用することができ、複数のローカル プレイヤーが参加するシナリオに対応しています。 マルチユーザー サポートでは、各プレイヤーは、統計やサインインで自分の Xbox Live アカウントを使うことができます。 また、ユーザーのゲストが Xbox Live アカウントを持っていない場合でも、ゲームをプレイすることができます。 この機能は、Xbox 本体でのみサポートされます。

このチュートリアルでは、マルチユーザー サポートをさまざまな Xbox Live プレハブに追加する方法について、順を追って説明します。

> [!IMPORTANT]
> マルチユーザー シナリオは、Xbox 本体でのみサポートされます。 この機能は PC では動作しません。

## <a name="prerequisites"></a>前提条件
[作業を始める](configure-xbox-live-in-unity.md)ためのチュートリアルに従って、Xbox Live を有効にし、構成してください。

## <a name="adding-and-signing-in-multiple-xbox-live-users"></a>複数の Xbox Live ユーザーの追加とサインイン

1. **Assets** > **Xbox Live** > **Prefabs** フォルダーから、追加するプレイヤーの数と同じ数の **XboxLiveUser** プレハブ インスタンスをシーンにドラッグします。 このチュートリアルでは、2 人のプレイヤーを追加するので、2 つの **XboxLiveUser** インスタンスをシーンに追加します。 便宜上、これらのインスタンスを **XboxLiveUser** および **XboxLiveUser2** と表します。

2. ユーザーの追加とサインインを適切に行うには、**UserProfile** プレハブの 2 つのインスタンスを、各 **XboxLiveUser** インスタンスに対応するように、シーンに追加します。 シーンに `XboxLiveServices` プレハブのインスタンスがあることを確認してください。 また、2 つの **UserProfile** オブジェクトをシーン上で移動し、これらのオブジェクトが別のオブジェクトであることを示してください。 これらのプレハブは Unity Eventsystem を使用するため、`EventSystem` のインスタンスがシーンにあることを確認してください。

    ![Xbox Live Unity プラグインでのマルチユーザー サポートの階層を示すチュートリアル プロジェクト](../images/unity/MUA-Tutorial-Hierarchy.png)

    ![Xbox Live Unity プラグインでのマルチユーザー サポートのゲーム シーンを示すチュートリアル プロジェクト](../images/unity/MUA-Tutorial-GameScene.png)

3. シーンにある **XboxLiveUser** プレハブの各インスタンスを、**UserProfile** オブジェクトのそれぞれに割り当てます。

    ![マルチ ユーザー サポートでの UserProfile プレハブ](../images/unity/user-profile-for-mua.png)

4. マルチユーザー アプリケーションは Xbox One デバイスでのみサポートされるため、コントローラー サポートを **UserProfile** オブジェクトに追加する必要があります。 それぞれの **UserProfile** オブジェクトには、`InputControllerButton` という名前のフィールドがあります。このフィールドでは、各 **UserProfile** がリッスンするジョイスティックとボタン番号を指定できます。

このチュートリアルでは、プレイヤー 1 に割り当てられている **UserProfile** で `joystick 1 button 0` を使用し、プレイヤー 2 に割り当てられている 2 番目の **UserProfile** ゲーム オブジェクトでは `joystick 2 button 0` を使用します。 これにより、2 つのコントローラーの `A` ボタンが、**UserProfile** を操作するために割り当てられます。

> [!Note]
> Xbox Live Unity プラグインでの Xbox コントローラー サポートについて詳しくは、「[コントローラー サポートを Xbox Live プレハブに追加する](add-controller-support-to-xbox-live-prefabs.md)」をご覧ください。

5. エディターでシーンを実行し、各ボタンを押してその実行状況を調べ、すべてが正しく構成されていること確認してください。

    ![Unity エディターでのマルチ ユーザー サポートのテスト](../images/unity/run-example-mua.png)

## <a name="building-and-testing-the-uwp"></a>UWP の構築とテスト

1. 「[Unity を使用してクリエーターズ タイトルを開発する](configure-xbox-live-in-unity.md)」チュートリアルで説明した手順を実行した後で、エクスポートした UWP ソリューションを Visual Studio で開きます。

2. ゲームの UWP プロジェクトで、`package.appxmanifest.xml` ファイルを右クリックし、**[コードの表示]** を選択します。

3. `<Properties></Properties>` セクションで、`<uap:SupportedUsers>multiple</uap:SupportedUsers>` を追加します。これにより、アプリでマルチユーザー入力が可能になります。

4. Xbox でテストするには、「[Xbox の開発環境に UWP を設定する](https://docs.microsoft.com/en-us/windows/uwp/xbox-apps/development-environment-setup)」チュートリアルの説明に従ってください。

## <a name="using-the-other-xbox-live-prefabs-with-multiple-users"></a>他の Xbox Live プレハブを複数のユーザーで使用する

プラグインの **Examples** フォルダーには、さまざまなプレハブで **XboxLiveUser** インスタンスを使用して、各ユーザーに固有の情報を表示する方法を示す、**MultiUserExample** シーンが用意されています。
