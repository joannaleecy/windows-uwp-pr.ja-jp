---
author: mcleblanc
ms.assetid: A5320094-DF53-42FC-A6BA-A958F8E9210B
title: Visual Studio を使った Surface Hub アプリのテスト
description: Visual Studio シミュレーターは、UWP アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Surface Hub 用に作成されたアプリを含みます。
---

# Visual Studio を使った Surface Hub アプリのテスト
Visual Studio シミュレーターは、ユニバーサル Windows プラットフォーム (UWP) アプリの設計、開発、デバッグ、テストを行える環境を提供します。これには Microsoft Surface Hub 用に作成されたアプリを含みます。 シミュレーターでは、Surface Hub と同じユーザー インターフェイスは使用できませんが、Surface Hub の画面サイズと解像度でのアプリの外観と動作をテストするために有用です。

詳しくは、「[シミュレーターでの Windows ストア アプリの実行](https://msdn.microsoft.com/library/hh441475.aspx)」をご覧ください。

## Surface Hub の解像度をシミュレーターに追加する
Surface Hub の解像度をシミュレーターに追加するには、次の手順を実行します。

1. **HardwareConfigurations SurfaceHub55.xml** という名前のファイルに次の XML を保存して、55" Surface Hub 用の構成を作成します。  

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

2. **HardwareConfigurations SurfaceHub84.xml** という名前のファイルに次の XML を保存して、84" Surface Hub 用の構成を作成します。

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

3. この 2 つの XML ファイルを **C:\Program Files (x86) \Common Files\Microsoft Shared\Windows Simulator\\&lt;バージョン番号&gt;\HardwareConfigurations** にコピーします。

   > **注**
            &nbsp;&nbsp;このフォルダーにファイルを保存するには、管理者特権が必要です。

4. Visual Studio シミュレーターでアプリを実行します。 パレットの **[解像度の変更]** をクリックし、一覧から Surface Hub の構成を選択します。

    ![Visual Studio シミュレーターの解像度](images/vs-simulator-resolutions.png)

   > **ヒント**
            &nbsp;&nbsp;
            Surface Hub でのエクスペリエンスをより適切にシミュレートするには、[タブレット モードを有効にします](http://windows.microsoft.com/windows-10/getstarted-like-a-tablet)。

## Visual Studio から Surface Hub にアプリを展開する
アプリを手動で展開することは単純なプロセスです。

### 開発者モードを有効にする
既定では、Surface Hub はアプリを Windows ストアからのみインストールします。 他のソースによって署名されたアプリをインストールするには、開発者モードを有効にする必要があります。

> **注**
            &nbsp;&nbsp;開発者モードを有効にした後、もう一度これを無効にするには、Surface Hub をリセットする必要があります。 デバイスをリセットすると、すべてのローカル ユーザーのファイルと構成が削除され、Windows が再インストールされます。

1. Surface Hub の**スタート** メニューから設定アプリを開きます。

   >  **注**
            &nbsp;&nbsp;設定アプリにアクセスするには、管理者特権が必要です。

2. **[更新プログラムとセキュリティ]**、[開発者向け] の順に移動します。

3. **[開発者モード]** を選択し、警告メッセージに同意します。

### Visual Studio からアプリを展開する
詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリの展開とデバッグ](https://msdn.microsoft.com/windows/uwp/debug-test-perf/deploying-and-debugging-uwp-apps)」をご覧ください。

   > **注**
            &nbsp;&nbsp;この機能には、少なくとも **Visual Studio 2015 Update 1** が必要です。

1. **[デバッグの開始]**ボタンの横にあるデバッグ ターゲットのドロップダウンに移動し、**[リモート コンピューター]** を選択します。

    <!--lcap: in your screenshot, you have local machine selected-->

   ![Visual Studio のデバッグ ターゲットのドロップダウン](images/vs-debug-target.png)

2. Surface Hub ハブの IP アドレスを入力します。 **[ユニバーサル]** 認証モードが選択されていることを確認します。

   > **ヒント**
            &nbsp;&nbsp;開発者モードを有効にした後、ようこそ画面で、Surface Hub の IP アドレスを確認することができます。

3. **[デバッグの開始 (F5)]** を選択して、Surface Hub にアプリを展開してデバッグします。アプリの展開のみを行うには、Ctrl キーを押しながら F5 キーを押します。

   > **ヒント**
            &nbsp;&nbsp;Surface Hub がようこそ画面に表示された場合は、いずれかのボタンを選んで無視します。


<!--HONumber=May16_HO2-->


