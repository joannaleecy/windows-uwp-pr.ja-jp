---
author: awkoren
Description: "手動で Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をユニバーサル Windows プラットフォーム (UWP) アプリに変換する方法を示します。"
Search.Product: eADQiWindows 10XVcnh
title: "手動で Windows デスクトップ アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換する"
translationtype: Human Translation
ms.sourcegitcommit: fe96945759739e9260d0cdfc501e3e59fb915b1e
ms.openlocfilehash: 6ca48fd829b7437fe2db8aa1251f6ed8976919ab

---

# Desktop Bridge を使って手動でアプリを UWP アプリに変換する

Desktop App Converter (DAC) を使用すると簡単な操作で自動的に変換されるため、インストーラーの処理について不明確な点がある場合に便利です。 ただし、アプリが Xcopy を使用してインストールされる場合や、アプリのインストーラーがシステムに加える変更について詳しい知識がある場合は、アプリ パッケージとマニフェストを手動で作成することもできます。

ここでは、パッケージを手動で作成する手順を紹介します。

## マニフェストを手動で作成する

_appxmanifest.xml_ ファイルには、(少なくとも) 次のような内容が必要です。 \*\*\*THIS\*\*\* のような形式のプレースホルダーは、アプリの実際の値に変更してください。

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

## MakeAppX ツールを実行する

[アプリ パッケージ ツール (MakeAppx.exe)](https://msdn.microsoft.com/library/windows/desktop/hh446767(v=vs.85).aspx) を使用して、プロジェクトの AppX を生成します。 MakeAppx.exe は Windows 10 SDK に同梱されています。 

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

## AppX パッケージに署名する

Add-AppxPackage コマンドレットを使うには、展開するアプリケーション パッケージ (.appx) が署名されている必要があります。 .appx パッケージに署名するには、Microsoft Windows 10 SDK に付属している [SignTool.exe](https://msdn.microsoft.com/library/windows/desktop/aa387764(v=vs.85).aspx) を使います。

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




<!--HONumber=Nov16_HO1-->


