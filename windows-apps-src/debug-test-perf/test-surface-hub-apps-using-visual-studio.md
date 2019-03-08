---
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: Visual Studio を使った Surface Hub アプリのテスト
description: Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。
ms.date: 10/26/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: db481fac1bdcb9e79762f52aee48574e987c4cbb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601017"
---
# <a name="test-surface-hub-apps-using-visual-studio"></a>Visual Studio を使った Surface Hub アプリのテスト
Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。 シミュレーターが Surface Hub、として、同じユーザー インターフェイスを使用しないが、アプリの外観し、動作、Surface Hub の画面サイズと解像度をテストするために便利です。

シミュレーターのツールの詳細については一般に、表示[シミュレーターでアプリの実行の UWP](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator)します。

## <a name="add-surface-hub-resolutions-to-the-simulator"></a>Surface Hub の解像度をシミュレーターに追加する
Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。

1. 55"の構成の作成という名前のファイルに次の XML コードを保存することによって、Surface Hub *HardwareConfigurations SurfaceHub55.xml*します。  

    ```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <ArrayOfHardwareConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                                  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <HardwareConfiguration>
            <Name>SurfaceHub55</Name>
            <DisplayName>Surface Hub 55"</DisplayName>
            <Resolution>
                <Height>1080</Height>
                <Width>1920</Width>
            </Resolution>
            <DeviceSize>55</DeviceSize>
            <DeviceScaleFactor>100</DeviceScaleFactor>
        </HardwareConfiguration>
    </ArrayOfHardwareConfiguration>
    ```

2. 84"の構成の作成という名前のファイルに次の XML コードを保存することによって、Surface Hub *HardwareConfigurations SurfaceHub84.xml*します。

    ```xml
    <?xml version="1.0" encoding="UTF-8"?>
    <ArrayOfHardwareConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                                  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
        <HardwareConfiguration>
            <Name>SurfaceHub84</Name>
            <DisplayName>Surface Hub 84"</DisplayName>
            <Resolution>
                <Height>2160</Height>
                <Width>3840</Width>
            </Resolution>
            <DeviceSize>84</DeviceSize>
            <DeviceScaleFactor>150</DeviceScaleFactor>
        </HardwareConfiguration>
    </ArrayOfHardwareConfiguration>
    ```

3. 2 つの XML ファイルをコピー *C:\Program Files (x86) \common Shared\Windows シミュレーター\\&lt;バージョン番号&gt;\HardwareConfigurations*します。

   > [!NOTE]
   > このフォルダーにファイルを保存するのには、管理者特権が必要です。

4. Visual Studio シミュレーターでアプリを実行します。 パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > [!TIP]
   > [タブレット モードを有効に](https://windows.microsoft.com/windows-10/getstarted-like-a-tablet)Surface Hub のエクスペリエンスをより正確にシミュレートします。

## <a name="deploy-apps-to-a-surface-hub-device-from-visual-studio"></a>Visual Studio から Surface Hub のデバイスにアプリをデプロイします。
Surface hub アプリの手動展開は、単純なプロセスです。

### <a name="enable-developer-mode"></a>開発者モードを有効にする
既定では、Surface Hub はのみ Microsoft Store からアプリをインストールします。 他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。

> [!NOTE]
> 開発者モードが有効にすると、再度無効にする場合は、Surface Hub をリセットする必要があります。 デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。

1. Surface Hub の**スタート** メニューから設定アプリを開きます。

   > [!NOTE]
   > Surface Hub で [設定] アプリへのアクセスには、管理者特権が必要です。

2. 移動します**更新とセキュリティ\>開発者向け**します。

3. **[開発者モード]** を選択し、警告メッセージに同意します。

### <a name="deploy-your-app-from-visual-studio"></a>Visual Studio からアプリを展開する
一般に、表示、展開プロセスの詳細については[の展開と UWP アプリのデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)します。

   > [!NOTE]
   > この機能では、最新の最新バージョンの Visual Studio を使用することをお勧めします。 ただし、Visual Studio 2015 Update 1 以降が必要です。 最新の Visual Studio インスタンスには、する最新のすべての開発とセキュリティ更新プログラムを gibe は。

1. **[デバッグの開始]** ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. Surface Hub ハブの IP アドレスを入力します。 **[ユニバーサル]** 認証モードが選択されていることを確認します。

   > [!TIP] 
   > 開発者モードを有効にした後は、[ようこそ] 画面 Surface Hub の IP アドレスが見つかります。

3. 選択**デバッグ (F5) で開始**を展開し、Surface Hub でアプリをデバッグまたは単にアプリをデプロイするには、Ctrl + F5 キーを押します。

   > [!TIP]
   > Surface Hub は、ようこそ画面を表示している場合は、いずれかのボタンを選択して閉じます。
