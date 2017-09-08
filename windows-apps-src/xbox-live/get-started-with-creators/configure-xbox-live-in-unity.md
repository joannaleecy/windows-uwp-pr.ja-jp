---
title: "Unity で Xbox Live を構成する"
author: KevinAsgari
description: "Xbox Live Unity プラグインを使用して、Unity ゲームで Xbox Live を構成する方法について説明します。"
ms.assetid: 55147c41-cc49-47f3-829b-fa7e1a46b2dd
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, 構成"
ms.openlocfilehash: eecf41f579e16bca072e74d1024c355d6d156566
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="configure-xbox-live-in-unity"></a>Unity で Xbox Live を構成する

> **注:** 現在、実績とマルチプレイヤーがサポートされていないため、Xbox Live Unity プラグインは [Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。

Xbox Live Unity プラグインを使用すると、Unity ゲームに Xbox Live サポートを簡単に追加できるため、タイトルに最適な方法で Xbox Live の使用に集中できます。

このトピックでは、Unity で Xbox Live プラグインをセットアップする手順について説明します。

## <a name="prerequisites"></a>前提条件

Unity で Xbox Live を構成するには、次の前提条件があります。

* [Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)
* [Windows 10 Anniversary Update](https://microsoft.com/windows) 以降
* [Unity 5.5](https://store.unity.com/) 以降
  * インストールするときは、必ず **[Windows ストア .NET Scripting Backend]** を選択してください。
* [Visual Studio 2015](https://www.visualstudio.com/) 以降
  * Visual Studio のどのバージョンでも機能します (Community Edition を含む)。
  * インストールするときは、必ず **[ユニバーサル Windows アプリ開発ツール]** の下にあるすべての項目を選択してください。  インストールを変更して、既存のインストールにこれらの機能を追加することもできます。

## <a name="import-the-unity-plugin"></a>Unity プラグインをインポートする

新規または既存の Unity プロジェクトにプラグインをインポートするには、次の手順を実行します。

1. [https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases) の Xbox Live Unity プラグインにアクセスします。
2. XboxLive.unitypackage をダウンロードします。
3. XboxLive.unitypackage パッケージをダブルクリックするか、Unity のメニューから [Assets]、[Import Package]、[Custom Package] の順にクリックして、パッケージを Unity プロジェクトにインポートします。

![Unity パッケージのインポート](../images/unity/unity-import.png)

## <a name="unity-plugin-file-structure"></a>Unity プラグインのファイル構造

Unity プラグインのファイル構造は、次の部分に分かれています。

* __Xbox Live__ には、公開された **.unitypackage** に含まれている実際のプラグイン アセットが含まれています。
    * __Editor__ には、基本的な Unity 構成 UI を表示し、ビルド時にプロジェクトを処理するスクリプトが含まれています。
    * __Examples__ には、さまざまなプレハブを使って相互に接続する方法を示す一連のシンプルなシーン ファイルが含まれています。
    * __Images__ は、プレハブにより使用される小さいイメージ セットです。
    * __Libs__ は、Xbox Live ライブラリが保存される場所です。
    * __Prefabs__ には、Xbox Live 機能を実装するさまざまな [Unity プレハブ](https://docs.unity3d.com/Manual/Prefabs.html) オブジェクトが含まれています。
    * __Scripts__ には、プレハブから Xbox Live API を実際に呼び出すコード ファイルがすべて含まれています。  これは、Xbox Live API を正しく呼び出す方法に関する例を探すのに最適な場所です。
    * __Tools\AssociationWizard__ には、Xbox Live の関連付けウィザードが含まれています。このウィザードは、Unity 内で使用するアプリケーション構成を [Windows デベロッパー センター](https://developer.microsoft.com/windows)から取得するために使用されます。

## <a name="enable-xbox-live"></a>Xbox Live を有効にする

Unity プロジェクトで Xbox Live を実際に有効にするには、次の手順に従う必要があります。

1. **[Xbox Live]** メニューで **[Configuration]** を選択します。

    ![Xbox Live: Configuration](../images/unity/xbox-live-configuration.PNG)

2. **[Xbox Live]** ウィンドウで、**[Run Xbox Live Association Wizard]** を選択します。

    ![Xbox Live: Xbox Live を有効にする](../images/unity/enable-xbox-live.PNG)

    > **注:** Xbox Live サービスを呼び出すには、デバイスが開発者モードになっている必要があります。 Xbox Live を有効にした後、**[Switch to Developer Mode]** を選択することで開発モードに切り替えることができます。

3. **[Associate Your Game with the Windows Store]** ダイアログで、**[Next]** をクリックし、デベロッパー センター アカウントを使用してサインインします。

    ![Xbox Live: Xbox Live を有効にする](../images/unity/associate-game-with-store.png)

4. このプロジェクトに関連付けるアプリを選択し、**[Select]** をクリックします。 アプリが表示されない場合は、**[Refresh]** をクリックしてみてください。 または、名前を予約して **[Reserve]** をクリックすることで、新しいアプリを作成できます。

5. **[Enable]** をクリックして、ゲームで Xbox Live を有効にします。

    ![ゲームで Xbox Live の機能を有効にする](../images/unity/associate-your-game-with-the-windows-store.PNG)

6. **[Finish]** をクリックして構成を保存します。

7. Unity で **[Xbox Live]** ウィンドウに戻り、**[Developer Mode Configuration]** に **[Enabled]** と表示されていることを確認します。 **[Disabled]** になっている場合、**[Switch to Developer Mode]** をクリックします。

8. タイトルが配置されているサンドボックスが、デバイスが現在配置されているサンドボックスと同じであることを確認します。 タイトルが配置されているサンドボックスは **[Title Configuration]** の **[Sandbox]** で確認できます。デバイスが配置されているサンドボックスは **[Developer Mode Configuration]** の **[Developer Mode]** でかっこで囲まれて示されます。 サンドボックスの詳細、およびデバイスでサンドボックスを切り替える方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。 プラグインでは、デバイスのサンドボックスが自動的に切り替わる必要があります。

    ![有効になった Xbox Live: サンドボックスの一致](../images/unity/unity-xbl-enabled.PNG)

9. これで、Unity プロジェクトで Xbox Live が正常に有効になりました。

## <a name="build-and-test-the-project"></a>プロジェクトのビルドおよびテスト

エディターでタイトルを実行しているとき、Xbox Live の機能を使おうとすると仮のデータが表示されます。 たとえば、**SignInAndProfile** サンプル シーンで、エディターで実行してサインインしようとすると、プレースホルダー アイコンと共にプロフィール名として **"Fake User 123456789"** と表示されます。

![仮のユーザー: 123456789](../images/unity/unity-game-fake-data.PNG)

実際のプロフィールでサインインし、タイトルで Xbox Live の機能をテストするには、Visual Studio でタイトルをビルドして実行する必要があります。

1. Unity で、**[File]、[Build Settings]** の順に選択するか、**Ctrl + Shift + B** キーを押して **[Build Settings]** ウィンドウを開きます。

2. **[Scenes In Build]** で、テストするシーンがビルドに含まれていることを確認します。 一覧に表示されない場合、シーンを開いて **[Add Open Scenes]** を選択します。

3. **[Platform]** で **[Windows Store]** を選択して **[Switch Platform]** をクリックすることで、**Windows ストア** プラットフォームに切り替えます。

4. **[SDK]** で **[Universal 10]** を選択します。

5. **[Debugging]** で **[Unity C# Projects]** をオンにします。

6. **[Build]** をクリックします。

    ![ビルド設定](../images/unity/unity-build-settings.PNG)

7. エクスプローラーで、ビルドを配置するフォルダーを選択します。

8. 指定したフォルダーから **&lt;ProjectName&gt;\\&lt;ProjectName&gt;.csproj** を Visual Studio で開きます。

9. 上部にあるツールバーで、デバイスでサポートされているプラットフォームに応じて **[x64]** または **[x86]** を選択し、**[ローカル コンピュータ]** に展開します。

    ![デバッグ、x64、ローカル コンピューター](../images/unity/vs-debug-local-machine.PNG)

10. Xbox Live にサインインする方法をプロジェクトに追加した場合、サンドボックスにアクセスできるアカウントを使用してサインインします。 これで、Xbox Live がタイトルに接続されました。

## <a name="try-out-the-examples"></a>サンプルを試す

Unity プロジェクトで Xbox Live を使い始める準備ができました。 **Xbox Live/Examples** フォルダーにあるシーンを開いて、プラグインの動作と機能の使用方法の例をご自分で確認してください。 エディターでサンプルを実行するとダミー データが表示されますが、Visual Studio でプロジェクトをビルドして Microsoft アカウントをサンドボックスに関連付けた場合は、ゲーマータグでサインインすることができます。

Microsoft アカウントにサインインするには **SignInAndProfile** シーン、ランキングを作成するには **Leaderboard** シーン、統計を表示および更新するには **UpdateStat** シーンを試してみてください。

## <a name="see-also"></a>関連項目

* [Unity で Xbox Live にサインインする](sign-in-to-xbox-live-in-unity.md)
