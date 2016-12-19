---
author: awkoren
Description: "Desktop to UWP Bridge を使用して Windows デスクトップ アプリケーション (Win32、WPF、および Windows フォーム) から変換したユニバーサル Windows プラットフォーム (UWP) アプリを展開してデバッグします。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop Bridge で変換されたアプリのデバッグ"
translationtype: Human Translation
ms.sourcegitcommit: dba00371b29b3179a6dc3bdd96a092437331e61a
ms.openlocfilehash: 537ac8e83d5f54bf83ec0e05b71be354651000f2

---

# <a name="debug-apps-converted-with-the-desktop-bridge"></a>Desktop Bridge で変換されたアプリのデバッグ

このトピックには、Desktop to UWP Bridge による変換後のアプリの正常なデバッグに役立つ情報が含まれています。 変換済みのアプリをデバッグするには、いくつかのオプションがあります。

## <a name="attach-to-process"></a>プロセスにアタッチ

Microsoft Visual Studio を "管理者として" 実行しているときは、変換済みアプリのプロジェクトで *[デバッグの開始]* コマンドと *[デバッグなしで開始]* コマンドを使えますが、起動したアプリは[中程度の整合性レベル](https://msdn.microsoft.com/library/bb625963)で実行されます (つまり、管理者特権はありません)。 起動したアプリに管理者特権を与えるには、まずショートカットまたはタイルを使って "管理者として" 起動する必要があります。 "管理者として" 実行している Microsoft Visual Studio のインスタンスからアプリを起動したら、__[プロセスにアタッチ]__ を実行して、ダイアログ ボックスからアプリのプロセスを選択します。

## <a name="f5-debug"></a>F5 デバッグ

Visual Studio では、新しいパッケージ プロジェクトがサポートされるようになりました。 新しいプロジェクトでは、アプリケーションをビルドしたときに行ったすべての更新を、アプリケーションのインストーラーでコンバーターを実行したときに作成される AppX パッケージに自動的にコピーすることができます。 パッケージ プロジェクトを構成したら、F5 キーを使って AppX パッケージを直接デバッグできます。 

>注: オプションを使って既存の Appx パッケージをデバッグすることもできます。これには、[デバッグ]、[その他のデバッグ ターゲット]、[インストールされているアプリケーション パッケージのデバッグ] の順にオプションを選びます。

手順は次のとおりです。 

1. まず、Desktop App Converter を使用するように設定していることを確認します。 詳しくは、「[Desktop App Converter](desktop-to-uwp-run-desktop-app-converter.md)」をご覧ください。

2. コンバーター、Win32 アプリケーションのインストーラーの順に実行します。 コンバーターは、レイアウトと、レジストリに加えられたすべての変更をキャプチャし、レジストリを仮想化する registery.dat とマニフェストを含む Appx を出力します。

![alt](images/desktop-to-uwp/debug-1.png)

3. [Visual Studio 2017 RC](https://www.visualstudio.com/downloads/#visual-studio-community-2017-rc) をインストールして起動します。 

4. [Visual Studio ギャラリー](http://go.microsoft.com/fwlink/?LinkId=797871)から Desktop to UWP Packaging VSIX Project をデスクトップにインストールします。 

5. Visual Studio で変換した、対応する Win32 ソリューションを開きます。
 
6. ソリューションを右クリックし、[新しいプロジェクトの追加] を選択して、新しいパッケージ プロジェクトをソリューションに追加します。 次に、[セットアップと配置] の下にある [Desktop to UWP Packaging Project] を選択します。

    ![alt](images/desktop-to-uwp/debug-2.png)

    作成されたプロジェクトは、ソリューションに追加されます。

    ![alt](images/desktop-to-uwp/debug-3.png)

    パッケージ プロジェクトでは、AppXFileList によって AppX レイアウトにファイルがマッピングされます。 参照は空で開始されていますが、手動で .exe プロジェクトにビルド順に設定する必要があります。 

7. DesktopToUWPPackaging プロジェクトのプロパティ ページで、AppX パッケージのルートと実行するタイルを構成できます。

    ![alt](images/desktop-to-uwp/debug-4.png)

    PackageLayout に、上で説明した、コンバーターによって作られた AppX のルートの場所を設定します。 次に、実行するタイルを選択します。

8.  AppXFileList.xml を開いて編集します。 このファイルでは、Win32 のデバッグ用ビルドの出力を、コンバーターでビルドされる AppX レイアウトにコピーする方法を定義します。 既定では、このファイルに、サンプルのタグとコメントが設定されたプレース ホルダーが含まれています。

    ```XML
    <?xml version="1.0" encoding="utf-8"?>
    <Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
      <ItemGroup>
    <!— Use the following syntax to copy debug output to the AppX layout
       <AppxPackagedFile Include="$(outdir)\App.exe">
          <PackagePath>App.exe</PackagePath>
        </AppxPackagedFile> 
        See http://etc...
    -->
      </ItemGroup>
    </Project>
    ```

    マッピングを作成する例を次に示します。 ここでは、.exe と .dll を Win32 のビルドの場所からパッケージのレイアウトの場所にコピーします。 

    ```XML
    <?xml version="1.0" encoding=utf-8"?>
    <Project ToolsVersion=14.0" xmlns="http://scehmas.microsoft.com/developer/msbuild/2003">
        <PropertyGroup>
            <MyProjectOutputPath>{relativepath}</MyProjectOutputPath>
        </PropertyGroup>
        <ItemGroup>
            <LayoutFile Include="$(MyProjectOutputPath)\ProjectTracker.exe">
                <PackagePath>$(PackageLayout)\VFS\Program Files (x86)\Contoso Software\Project Tracker\ProjectTracker.exe</PackagePath>
            </LayoutFile>
            <LayoutFile Include="$(MyProjectOutputPath)\ProjectTracker.Models.dll">
                <PackagePath>$(PackageLayout)\VFS\Program Files (x86)\Contoso Software\Project Tracker\ProjectTracker.Models.dll</PackagePath>
            </LayoutFile>
        </ItemGroup>
    </Project>
    ```

    このファイルは、次のように定義されています。 

    まず、Win32 プロジェクトがビルドされる場所をポイントするように、*MyProjectOutputPath* を定義します。

    ```XML
    <?xml version="1.0" encoding="utf-8"?>
    <Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
        <PropertyGroup>
            <MyProjectOutputPath>..\ProjectTracker\bin\DesktopUWP</MyProjectOutputPath>
        </PropertyGroup>
    ```

    次に、各 *LayoutFile* で、Win32 のビルドの場所から Appx パッケージのレイアウトにコピーするファイルを指定します。 ここでは、最初に .exe、次に .dll をコピーしています。 

    ```XML
        <ItemGroup>
            <LayoutFile Include="$(MyProjectOutputPath)\ProjectTracker.exe">
                <PackagePath>$(PackageLayout)\VFS\Program Files (x86)\Contoso Software\Project Tracker\ProjectTracker.exe</PackagePath>
            </LayoutFile>
            <LayoutFile Include="$(MyProjectOutputPath)\ProjectTracker.Models.dll">
                <PackagePath>$(PackageLayout)\VFS\Program Files (x86)\Contoso Software\Project Tracker\ProjectTracker.Models.dll</PackagePath>
            </LayoutFile>
        </ItemGroup>
    </Project>
    ```

9. パッケージ プロジェクトをスタートアップ プロジェクトに設定します。 以上の設定で、Win32 ファイルが AppX にコピーされ、プロジェクトをビルドして実行したときにデバッガーが起動されます。  

    ![alt](images/desktop-to-uwp/debug-5.png)

10. それでは最後に、Win32 コードにブレークポイントを設定して、F5 キーを押してデバッガーを起動しましょう。 Win32 アプリケーションで行った更新が AppX パッケージにコピーされ、Visual Studio 内から直接デバッグできるようになります。

11. アプリケーションを更新する場合は、MakeAppX を使ってアプリをもう一度パッケージ化する必要があります。 詳細については、「[アプリ パッケージ ツール (MakeAppx.exe)](https://msdn.microsoft.com/library/windows/desktop/hh446767(v=vs.85).aspx)」をご覧ください。 

複数のビルド構成がある場合 (たとえばリリース用とデバッグ用)、次を AppXFileList.xml ファイルに追加して、Win32 ビルドをさまざまな場所からコピーできます。

```XML
<PropertyGroup>
    <MyProjectOutputPath Condition="$(Configuration) == 'DesktopUWP'">C:\Users\peterfar\Desktop\ProjectTracker\ProjectTracker\bin\DesktopUWP>
    </MyProjectOutputPath>
    <MyProjectOutputPath Condition="$(Configuration) == 'ReleaseDesktopUWP'"> C:\Users\peterfar\Desktop\ProjectTracker\ProjectTracker\bin\ReleaseDesktopUWP</MyProjectOutputPath>
</PropertyGroup>
```

また、UWP 用アプリケーションは更新するが Win32 用にはそのままビルドする場合は、特定のコード パスを有効にする条件付きコンパイルを使うこともできます。 

1.  次の例では、コードは DesktopUWP 用のときにのみコンパイルされ、WinRT API を使ってタイルに表示されます。 

    ```C#
    [Conditional("DesktopUWP")]
    private void showtile()
    {
        XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text01);
        XmlNodeList textNodes = tileXml.GetElementsByTagName("text");
        textNodes[0].InnerText = string.Format("Welcome to DesktopUWP!");
        TileNotification tileNotification = new TileNotification(tileXml);
        TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
    }
    ```

2.  Configuration Manager を使用して、新しいビルド構成を追加できます。

    ![alt](images/desktop-to-uwp/debug-6.png)

    ![alt](images/desktop-to-uwp/debug-7.png)

3.  次に、プロジェクト プロパティに、条件付きコンパイル シンボルのサポートを追加します。

    ![alt](images/desktop-to-uwp/debug-8.png)

4.  追加した UWP API をターゲットとしてビルドする場合には、ビルド ターゲットを DesktopUWP に切り替えられるようになりました。

## <a name="plmdebug"></a>PLMDebug 

Visual Studio の F5 キーおよびプロセスにアタッチの機能は、実行中にアプリをデバッグするために役立ちます。 しかし場合によっては、アプリを開始する前にデバッグを行うなど、デバッグ プロセスを細かく制御する必要があります。 これらのより高度なシナリオでは、[ **PLMDebug**](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx) を使用します。 このツールは、Windows デバッガーを使って、変換済みのアプリをデバッグすることができ、中断、再開、および終了など、アプリのライフ サイクルの完全な制御を提供します。 

PLMDebug は Windows SDK に含まれています。 詳しくは、「[**PLMDebug**](https://msdn.microsoft.com/library/windows/hardware/jj680085(v=vs.85).aspx)」をご覧ください。 

## <a name="run-another-process-inside-the-full-trust-container"></a>完全な信頼コンテナー内で別のプロセスを実行する 

指定されたアプリ パッケージのコンテナー内でカスタムのプロセスを起動することができます。 これは、シナリオをテストするために役立つ場合があります (たとえば、カスタムのテスト ハーネスがあり、アプリの出力をテストする必要がある場合など)。 これを行うには、```Invoke-CommandInDesktopPackage``` PowerShell コマンドレット を使用します。 

```CMD
Invoke-CommandInDesktopPackage [-PackageFamilyName] <string> [-AppId] <string> [-Command] <string> [[-Args]
    <string>]  [<CommonParameters>]
```



<!--HONumber=Dec16_HO1-->


