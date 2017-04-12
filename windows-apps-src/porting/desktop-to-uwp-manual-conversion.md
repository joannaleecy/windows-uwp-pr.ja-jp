---
author: normesta
Description: "手動で Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をユニバーサル Windows プラットフォーム (UWP) アプリに変換する方法を示します。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge と手動での変換"
ms.author: normesta
ms.date: 03/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: e8c2a803-9803-47c5-b117-73c4af52c5b6
ms.openlocfilehash: 8d09a0349620e071f5c4d680df18f716e3b10a8e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-manual-conversion"></a>Desktop to UWP Bridge: 手動での変換

[Desktop App Converter (DAC)](desktop-to-uwp-run-desktop-app-converter.md) を使用すると簡単な操作で自動的に変換されるため、インストーラーの処理について不明確な点がある場合に便利です。 ただし、アプリが Xcopy を使用してインストールされる場合や、アプリのインストーラーがシステムに加える変更について詳しい知識がある場合は、アプリ パッケージとマニフェストを手動で作成することもできます。 ここでは、パッケージを手動で作成する手順を紹介します。 また、DAC ではプレートなしのアセットをアプリに追加することはできませんが、これを手動で実行する方法についても説明します。

ここでは、手動で変換する方法について説明します。 .NET アプリがあり、Visual Studio を使用している場合は、代わりに、「[Visual Studio による .NET デスクトップ アプリ用のデスクトップ ブリッジ パッケージ ガイド](desktop-to-uwp-packaging-dot-net.md)」をご覧ください。  

## <a name="create-a-manifest-by-hand"></a>マニフェストを手動で作成する

_appxmanifest.xml_ ファイルには、(少なくとも) 次のような内容が必要です。 \*\*\*THIS\*\*\* のような形式のプレースホルダーは、アプリケーションの実際の値に変更してください。

```XML
    <?xml version="1.0" encoding="utf-8"?>
    <Package
       xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
       xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
       xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities">
      <Identity Name="***YOUR_PACKAGE_NAME_HERE***"
        ProcessorArchitecture="x64"
        Publisher="CN=***COMPANY_NAME***, O=***ORGANIZATION_NAME***, L=***CITY***, S=***STATE***, C=***COUNTRY***"
        Version="***YOUR_PACKAGE_VERSION_HERE***" />
      <Properties>
        <DisplayName>***YOUR_PACKAGE_DISPLAY_NAME_HERE***</DisplayName>
        <PublisherDisplayName>Reserved</PublisherDisplayName>
        <Description>No description entered</Description>
        <Logo>***YOUR_PACKAGE_RELATIVE_DISPLAY_LOGO_PATH_HERE***</Logo>
      </Properties>
      <Resources>
        <Resource Language="en-us" />
      </Resources>
      <Dependencies>
        <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14316.0" MaxVersionTested="10.0.14316.0" />
      </Dependencies>
      <Capabilities>
        <rescap:Capability Name="runFullTrust"/>
      </Capabilities>
      <Applications>
        <Application Id="***YOUR_PRAID_HERE***" Executable="***YOUR_PACKAGE_RELATIVE_EXE_PATH_HERE***" EntryPoint="Windows.FullTrustApplication">
          <uap:VisualElements
           BackgroundColor="#464646"
           DisplayName="***YOUR_APP_DISPLAY_NAME_HERE***"
           Square150x150Logo="***YOUR_PACKAGE_RELATIVE_PNG_PATH_HERE***"
           Square44x44Logo="***YOUR_PACKAGE_RELATIVE_PNG_PATH_HERE***"
           Description="***YOUR_APP_DESCRIPTION_HERE***" />
        </Application>
      </Applications>
    </Package>
```

追加したいプレートなしのアセットがありますか。 その手順については、この記事の「[プレートなしのアセット](#unplated-assets)」のセクションをご覧ください。

## <a name="run-the-makeappx-tool"></a>MakeAppX ツールを実行する

[アプリ パッケージ ツール (MakeAppx.exe)](https://msdn.microsoft.com/library/windows/desktop/hh446767(v=vs.85).aspx) を使用して、プロジェクトの Windows アプリ パッケージを生成します。 MakeAppx.exe は Windows 10 SDK に同梱されています。

MakeAppx を実行するには、まず前の手順で説明したマニフェスト ファイルを作成していることを確認します。

次に、マッピング ファイルを作成します。 このファイルは、**[Files]** から始まり、ディスク上の各ソース フィルのリスト、パッケージ内のターゲット パスが続きます。 次に例を示します。

```
[Files]
"C:\MyApp\StartPage.htm"     "default.html"
"C:\MyApp\readme.txt"        "doc\readme.txt"
"\\MyServer\path\icon.png"   "icon.png"
"MyCustomManifest.xml"       "AppxManifest.xml"
```

最後に、以下のコマンドを実行します。

```cmd
MakeAppx.exe pack /f mapping_filepath /p filepath.appx
```

## <a name="sign-your-appx-package"></a>AppX パッケージに署名する

Add-AppxPackage コマンドレットを使うには、展開するアプリケーション パッケージ (.appx) が署名されている必要があります。 Windows アプリ パッケージに署名するには、Microsoft Windows 10 SDK に付属している [SignTool.exe](https://msdn.microsoft.com/library/windows/desktop/aa387764(v=vs.85).aspx) を使います。

使用例:

```cmd
C:\> MakeCert.exe -r -h 0 -n "CN=<publisher_name>" -eku 1.3.6.1.5.5.7.3.3 -pe -sv <my.pvk> <my.cer>
C:\> pvk2pfx.exe -pvk <my.pvk> -spc <my.cer> -pfx <my.pfx>
C:\> signtool.exe sign -f <my.pfx> -fd SHA256 -v .\<outputAppX>.appx
```
MakeCert.exe を実行したときにパスワードの入力を求められたら、**[なし]** を選択します。 証明書と署名について詳しくは、以下をご覧ください。

- [方法: 開発中に使う一時的な証明書を作成する](https://msdn.microsoft.com/library/ms733813.aspx)
- [SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764.aspx)
- [SignTool.exe (署名ツール)](https://msdn.microsoft.com/library/8s9b9yaz.aspx)

<span id="unplated-assets" />
## <a name="add-unplated-assets"></a>プレートなしのアセットを追加する

タスク バーに表示されるアプリの 44 x 44 アセットを任意で構成する方法を次に示します。

1. 正しい 44 x 44 画像を取得し、画像保存用のフォルダー (つまり、Assets) にコピーします。

2. 各 44 x 44 画像のコピーを同じフォルダーに作成し、ファイル名の末尾に *.targetsize-44_altform-unplated* を追加します。 これにより、同じ画像で異なる名前のアイコンが、2 つずつフォルダーに保存されます。 たとえばプロセスを完了すると、assets フォルダーに *MYAPP_44x44.png* と *MYAPP_44x44.targetsize-44_altform-unplated.png* ができます (注: 前者は、VisualElements 属性 *Square44x44Logo* の下の appxmanifest で参照されるアイコン)。

3.    AppXManifest で、作業対象のすべてのアイコンの BackgroundColor を透明に設定します。 この属性は、各アプリケーションの VisualElements の下にあります。

4.    CMD を開き、パッケージのルート フォルダーにディレクトリを変更した後、コマンド ```makepri createconfig /cf priconfig.xml /dq en-US``` を実行して priconfig.xml ファイルを作成します。

5.    CMD を使い、ディレクトリはパッケージのルート フォルダーのまま、コマンド ```makepri new /pr <PHYSICAL_PATH_TO_FOLDER> /cf <PHYSICAL_PATH_TO_FOLDER>\priconfig.xml``` を使って resources.pri ファイルを作成します。 たとえば、アプリのコマンドは、```makepri new /pr c:\MYAPP /cf c:\MYAPP\priconfig.xml``` のようになります。

6.    次の手順の説明に従って Windows アプリ パッケージをパッケージ化し、結果を確認します。
