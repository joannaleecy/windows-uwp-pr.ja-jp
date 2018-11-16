---
author: PatrickFarley
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: Visual Studio を使った Surface Hub アプリのテスト
description: Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。
ms.author: pafarley
ms.date: 10/26/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 63214ce47bffc5a0b13f421e5185d06cd810ea34
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6977373"
---
# <a name="test-surface-hub-apps-using-visual-studio"></a>Visual Studio を使った Surface Hub アプリのテスト
Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。 シミュレーターが Surface Hub と同じユーザー インターフェイスを使用していませんが、アプリの外観し、Surface Hub の画面サイズと解像度で動作をテストするために便利です。

シミュレーター ツールについて詳しくは一般に、 [UWP アプリの実行、シミュレーターで](https://docs.microsoft.com/visualstudio/debugger/run-windows-store-apps-in-the-simulator)を参照してください。

## <a name="add-surface-hub-resolutions-to-the-simulator"></a>Surface Hub の解像度をシミュレーターに追加する
Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。

1. 55 インチ用の構成を作成*hardwareconfigurations SurfaceHub55.xml*という名前のファイルを次の XML コードを保存して Surface Hub します。  

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

2. 84 インチ用の構成を作成*hardwareconfigurations SurfaceHub84.xml*という名前のファイルを次の XML コードを保存して Surface Hub します。

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

3. この 2 つの XML ファイルを *C:\Program Files (x86) \Common Files\Microsoft Shared\Windows Simulator\\&lt;バージョン番号&gt;\HardwareConfigurations* にコピーします。

   > [!NOTE]
   > このフォルダーにファイルを保存するには、管理者特権が必要です。

4. Visual Studio シミュレーターでアプリを実行します。 パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > [!TIP]
   > Surface Hub のエクスペリエンスをシミュレート[タブレット モードを有効に](http://windows.microsoft.com/windows-10/getstarted-like-a-tablet)向上します。

## <a name="deploy-apps-to-a-surface-hub-device-from-visual-studio"></a>Visual Studio からアプリを Surface Hub デバイスに展開します。
Surface Hub にアプリを手動で展開は、単純なプロセスです。

### <a name="enable-developer-mode"></a>開発者モードを有効にする
既定では、Surface Hub はアプリを Microsoft Store からのみインストールします。 他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。

> [!NOTE]
> 開発者モードが有効にすると、もう一度これを無効にする場合に、Surface Hub をリセットする必要があります。 デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。

1. Surface Hub の**スタート** メニューから設定アプリを開きます。

   > [!NOTE]
   > Surface Hub で設定アプリにアクセスするには、管理者特権が必要です。

2. 移動**更新とセキュリティ \ > 開発者向け**します。

3. **[開発者モード]** を選択し、警告メッセージに同意します。

### <a name="deploy-your-app-from-visual-studio"></a>Visual Studio からアプリを展開する
展開プロセスの詳細については一般を参照してください[の展開と UWP アプリをデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)します。

   > [!NOTE]
   > この機能では、最新の最新バージョンの Visual Studio を使用することをお勧めしますが、Visual Studio 2015 Update 1 日以降が必要です。 最新の Visual Studio のインスタンスは、セキュリティ更新プログラムとするすべての最新の開発 gibe されます。

1. **[デバッグの開始]** ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. Surface Hub ハブの IP アドレスを入力します。 **[ユニバーサル]** 認証モードが選択されていることを確認します。

   > [!TIP] 
   > 開発者モードを有効にした後、ようこそ画面に、Surface Hub の IP アドレスを見つけることができます。

3. **デバッグの開始 (F5)** を展開して、Surface Hub にアプリをデバッグする] を選択または Ctrl + f5 キーを押してだけアプリを展開します。

   > [!TIP]
   > Surface Hub がようこそ画面を表示している場合は、いずれかのボタンを選択して閉じます。
