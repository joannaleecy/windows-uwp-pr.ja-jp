---
author: awkoren
Description: デスクトップの変換拡張機能を使用して Windows デスクトップ アプリケーション (Win32、WPF、および Windows フォーム) から変換したユニバーサル Windows プラットフォーム (UWP) アプリを展開してデバッグします。
Search.Product: eADQiWindows 10XVcnh
title: Windows デスクトップ アプリケーションから変換したユニバーサル Windows プラットフォーム (UWP) アプリを展開してデバッグする
---

# 変換済みの UWP アプリを展開してデバッグする (Project Centennial)

\[一部の情報はリリース前の製品に関することであり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、マイクロソフトは明示または黙示を問わずいかなる保証をするものでもありません。\]

このトピックには、変換後のアプリの正常な展開とデバッグに役立つ情報が含まれています。 また、デスクトップの変換拡張機能の内部に関心をお持ちの場合にも、このトピックは役に立ちます。

## 変換済みの UWP アプリをデバッグする

変換済みのアプリを Visual Studio を使ってデバッグするには、主に 2 つの方法があります。

### プロセスにアタッチ

Microsoft Visual Studio を "管理者として" として実行しているときは、変換済みアプリのプロジェクトで __[デバッグの開始]__ コマンドと __[デバッグなしで開始]__ コマンドを使えますが、起動したアプリは[中程度の整合性レベル](https://msdn.microsoft.com/library/bb625963)で実行されます。 つまり、管理者特権は_ありません_。 起動したアプリに管理者特権を与えるには、最初に、ショートカットまたはタイルを使って "管理者として" 起動する必要があります。 "管理者として" 実行している Microsoft Visual Studio のインスタンスからアプリを起動したら、__[プロセスにアタッチ]__ を実行して、ダイアログ ボックスからアプリのプロセスを選択します。

### F5 デバッグ

現在 Visual Studio がサポートする新しいパッケージ プロジェクトでは、アプリケーションをビルドしたときに行ったすべての更新を、アプリケーションのインストーラーでコンバーターを実行したときに作成される AppX パッケージに自動的にコピーすることができます。 パッケージ プロジェクトを構成したら、すぐに F5 キーを使って AppX パッケージを直接デバッグできます。 

開始手順は次のとおりです。 

1. 最初に、Centennial を使える設定になっているか確認します。 手順については、「[Desktop App Converter のプレビュー (Project Centennial)](https://msdn.microsoft.com/windows/uwp/porting/desktop-to-uwp-run-desktop-app-converter)」をご覧ください。 

2. コンバーター、Win32 アプリケーションのインストーラーの順に実行します。 コンバーターは、レイアウトと、レジストリに加えられたすべての変更をキャプチャし、レジストリを仮想化する registery.dat とマニフェストを含む Appx を出力します。

![alt](images/desktop-to-uwp/debug-1.png)

3. [Visual Studio "15" Preview 2](https://www.visualstudio.com/downloads/visual-studio-next-downloads-vs.aspx) をインストールして起動します。 

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
            <MyProjectOutputPath>C:\{path}</MyProjectOutputPath>
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
            <MyProjectOutputPath>C:\Users\peterfar\Desktop\ProjectTracker\ProjectTracker\bin\DesktopUWP</MyProjectOutputPath>
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

11. アプリケーションを更新する場合は、MakeAppX を使ってアプリをもう一度パッケージ化する必要があります。 詳細については、「[アプリ パッケージ ツール (MakeAppx.exe)](https://msdn.microsoft.com/en-us/library/windows/desktop/hh446767(v=vs.85).aspx)」をご覧ください。 

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

4.  追加した UWP API を対象にビルドする場合は。ビルド対象を DesktopUWP に切り替えられるようになりました。

## 変換済み UWP アプリを展開する

開発中にアプリを展開するには、次の PowerShell コマンドレットを実行します。 

```Add-AppxPackage –Register AppxManifest.xml```

アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を増やして、上記のコマンドをもう一度実行します。

次の点に注意してください。 

変換済みのアプリをインストールするドライブは、NTFS 形式にフォーマットしておく必要があります。

変換済みのアプリは、常に、対話ユーザーとして実行されます。 このことは、特に .NET アプリにとって重要です。.NET アプリのマニフェストでは、__requireAdministrator__ の実行レベルを指定します。 対話ユーザーが管理者特権を持っていると、_アプリが起動されるたびに_ UAC プロンプトが表示されます。 標準ユーザーは、アプリを起動できません。

作成した証明書をインポートしていないコンピューターで Add-AppxPackage コマンドレットを実行しようとすると、エラーが発生します。

ここでは、以前に作成した証明書をインポートする方法を説明します。 証明書は、直接インストールするか、顧客と同じように、署名済みの appx からインストールすることができます。
1.  ファイル エクスプローラーで、テスト証明書で署名した appx を右クリックして、コンテンツメニューから [**プロパティ**] を選択します。
2.  [**デジタル署名**] タブをクリックまたはタップします。
3.  証明書をクリックまたはタップして、[**詳細**] を選択します。
4.  [**証明書の表示**] をクリックまたはタップします。
5.  [**証明書のインストール**] をクリックまたはタップします。
6.  [**ストアの場所**] グループで、[**ローカル マシン**] を選択します。
7.  [**次へ**] と [**OK**] をクリックまたはタップして、UAC ダイアログ ボックスを確認します。
8.  証明書のインポート ウィザードの次の画面で、選択されているオプションを [**証明書をすべて次のストアに配置する**] に変更します。
9.  **[参照]** をクリックまたはタップします。 [証明書ストアの選択] ウィンドウで下へスクロールし、**[信頼されたユーザー]** を選択してから、**[OK]** をクリックまたはタップします。
10. **[次へ]** をクリックまたはタップします。 新しい画面が表示されます。 **[完了]** をクリックまたはタップします。
11. 確認のダイアログ ボックスが表示されます。 確認のダイアログ ボックスが表示されたら、**[OK]** をクリックします。 別のダイアログが表示され、証明書に問題があることが示された場合は、証明書のトラブルシューティングを行う必要があります。

### 追加情報

Windows で証明書を信用するには、証明書を **[証明書 (ローカル コンピューター)] > [信頼されたルート証明機関] > [証明書]** ノードまたは **[証明書 (ローカル コンピューター)] > [信頼されたユーザー] > [証明書]** ノードのどちらかに配置します。 これら 2 つの場所にある証明書だけが、ローカル コンピューターのコンテキストで証明書の信頼性を検証できます。 それ以外の場合、次の文字列のようなエラー メッセージが表示されます。
```CMD
"Add-AppxPackage : Deployment failed with HRESULT: 0x800B0109, A certificate chain processed,
but terminated in a rootcertificate which is not trusted by the trust provider.
(Exception from HRESULT: 0x800B0109) error 0x800B0109: The root certificate of the signature
in the app package must be trusted."
```

### しくみ

変換済みのアプリを実行すると、UWP アプリ パッケージが \Program Files\WindowsApps\\&lt;_パッケージ名_&gt;\\&lt;_アプリ名_&gt;.exe から起動されます。 その場所を確認すると、アプリに AppxManifest.xml という名前のアプリ パッケージ マニフェストがあり、そのマニフェストから変換済みアプリで使われる特殊な xml 名前空間を参照していることが分かります。 そのマニフェスト ファイル内の __&lt;EntryPoint&gt;__ 要素で、完全に信頼できるアプリを参照します。 そのアプリは、起動されたときに、アプリ コンテナーの内部では実行されず、ユーザーが通常実行するように実行されます。

ただし、このアプリが実行される環境は特殊で、アプリがファイル システムやレジストリに行うアクセスは、すべてリダイレクトされます。 Registry.dat という名前のファイルが、レジストリのリダイレクトに使われます。 このファイルは、実際にはレジストリ ハイブであるため、Windows のレジストリ エディター (Regedit) で表示できます。 この方法では、プロセス間通信にレジストリを使用できないことに注意してください。 いずれにしても、レジストリはプロセス間通信用には設計されておらず、プロセス間通信に最適でもありません。 ファイル システムの場合は、リダイレクトされるのは AppData フォルダーのみです。このフォルダーは、すべての UWP アプリのアプリ データが格納される場所にリダイレクトされます。 この場所は、ローカル アプリ データ ストアといい、[ApplicationData.LocalFolder](https://msdn.microsoft.com/library/windows/apps/br241621) プロパティを使ってアクセスします。 これにより、何もしなくても、コードはアプリ データを読み書きするために適切な場所にアクセスします。 この場所に直接書き込むこともできます。 ファイル システムのリダイレクトの利点の 1 つは、すっきりしたアンインストールができることです。

VFS という名前のフォルダーの下に、アプリが依存している DLL を含むフォルダーがあります。 これらの DLL は、従来のデスクトップ版のアプリでは、システム フォルダーにインストールされます。 でも、UWP アプリでは、DLL はアプリのローカルなファイルです。 これにより、UWP アプリをインストールしたりアンインストールしたりしても、バージョンの問題は起きません。


<!--HONumber=May16_HO2-->


