---
author: normesta
Description: "パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)"
Search.Product: eADQiWindows 10XVcnh
title: "パッケージ デスクトップ アプリは、Windows ストアに公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.openlocfilehash: 24a005309271a91d669322787fb8d341e1a6d6ad
ms.sourcegitcommit: 77bbd060f9253f2b03f0b9d74954c187bceb4a30
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/11/2017
---
# <a name="distribute-a-packaged-desktop-app-desktop-bridge"></a>パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)

パッケージ デスクトップ アプリは、Windows ストアに公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。  

> [!NOTE]
> パッケージ アプリにユーザーを移行する方法について、計画はありますか?  アプリを配布する前に、このガイドの「[デスクトップ ブリッジ アプリにユーザーを移行する](#transition-users)」セクションを参照して、アイデアを得てください。

## <a name="distribute-your-app-by-publishing-it-to-the-windows-store"></a>Windows ストアに公開してアプリを配布する

[Windows ストア](https://www.microsoft.com/store/apps)は、お客様がアプリを取得する場合に最も便利な方法です。

<div style="float: left; padding: 10px">
    ![ストアのアイコン](images/desktop-to-uwp/store.png)
</div>
ストアでは、幅広いお客様を対象にしてアプリを公開できます。 また、組織のお客様は[ビジネス向け Windows ストア](https://www.microsoft.com/business-store)を通じてアプリを入手し、組織内で配布できます。

Windows ストアへの公開を計画していて、まだマイクロソフトにご連絡いただいていない場合は、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)にご記入ください。オンボード プロセスについて、マイクロソフトからご連絡させていただきます。

ストアに提出する前に、アプリに署名する必要はありません。

>[!IMPORTANT]
> Windows ストアにアプリを公開する場合は、Windows 10 S を実行するデバイスでアプリが正しく動作することを確認してください。これは、ストア要件です。 「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

## <a name="distribute-your-app-without-placing-it-onto-the-windows-store"></a>Windows ストアに掲載せずにアプリを配布する

ストアを使用せずにアプリを配布する場合は、1 台または複数のデバイスにアプリを手動で配布できます。

この方法は、配布エクスペリエンスをきめ細かく制御する必要がある場合や、Windows ストアの認定プロセスへの関与が望ましくない場合などに有効です。

アプリをストアに掲載せずに他のデバイスに配布するには、証明書を取得し、その証明書を使ってアプリに署名して、各デバイスにアプリをサイドローディング展開する必要があります。

[証明書を作成](../packaging/create-certificate-package-signing.md)することも、[Verisign](https://www.verisign.com/) などのポピュラーなベンダーから取得することもできます。

Windows 10 S を実行するデバイスへのアプリ配布を計画している場合、Windows ストアによるアプリへの署名が必要であるため、デバイスへのアプリ配布を開始する前に、Windows ストア提出プロセスを実施する必要があります。

証明書を作成する場合は、アプリを実行する各デバイスの証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールする必要があります。 ポピュラーなベンダーから証明書を取得する場合、システムにはアプリの他に何もインストールする必要はありません。  

> [!IMPORTANT]
> 証明書の発行元名がアプリの発行者名と一致することを確認してください。

証明書を使ってアプリに署名する方法については、「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。

他のデバイスにアプリをサイドローディング展開する方法については、「[Windows 10 での LOB アプリのサイドローディング](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)」をご覧ください。

**ビデオ**

|Windows ストアへのアプリ公開 |エンタープライズ アプリの配布  |
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Windows-Store-Publication-3cWyG5WhD_5506218965"      width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Distribution-for-Enterprise-Apps-XJ5Hd5WhD_1106218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<span id="transition-users" />
## <a name="transition-users-to-your-desktop-bridge-app"></a>デスクトップ ブリッジ アプリにユーザーを移行する

ユーザーによってデスクトップ ブリッジ アプリが使用されるようにするには、アプリを配布する前に、パッケージ マニフェストにいくつかの拡張機能を追加することを検討してください。 次のようなことができます。

* 既存のスタート タイルとタスク バー ボタンの参照先をデスクトップ ブリッジ アプリに設定します。
* パッケージ アプリを一連のファイルの種類に関連付けます。
* 特定の種類のファイルが既定でデスクトップ ブリッジ アプリによって開かれるように設定します。

拡張機能の完全な一覧と使用方法のガイダンスについては、「[アプリにユーザーを移行する](desktop-to-uwp-extensions.md#transition-users-to-your-app)」をご覧ください。

また、次のようなタスクを実行するコードをデスクトップ ブリッジ アプリに追加することも検討してください。

* デスクトップ ブリッジ アプリの適切なフォルダーに、デスクトップ アプリに関連付けられているユーザー データを移行します。
* アプリのデスクトップ バージョンをアンインストールするためのオプションをユーザーに示します。

これらのタスクについて、それぞれ説明します。 ユーザー データの移行から開始します。

### <a name="migrate-user-data"></a>ユーザー データの移行

ユーザー データを移行するためのコードを追加する場合、そのコードはアプリを初めて起動したときにのみ実行することをお勧めします。 ユーザー データを移行する前に、ユーザーに対してダイアログ ボックスを表示して、何が起こっているか、なぜ移行が推奨されるのか、既存のデータにどのような影響があるかを説明します。

例として、.NET ベースのデスクトップ ブリッジ アプリでの方法を次に示します。

```csharp
private void MigrateUserData()
{
    String sourceDir = Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData) + "\\AppName";

    if (sourceDir != null)
    {
        String migrateMessage =
            "Would you like to migrate your data from the previous version of this app?";

        DialogResult migrateResult = MessageBox.Show
            (migrateMessage, "Data Migration", MessageBoxButtons.YesNo);

        if (migrateResult.Equals(DialogResult.Yes))
        {
            String destinationDir =
                Windows.Storage.ApplicationData.Current.LocalFolder.Path + "\\AppName";

            Process process = new Process();
            process.StartInfo.FileName = "robocopy.exe";
            process.StartInfo.Arguments = "%LOCALAPPDATA%\\AppName " + destinationDir + " /move";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode > 1)
            {
                //Migration was unsuccessful -- you can choose to block/retry/other action
            }
        }
    }
}
```

### <a name="uninstall-the-desktop-version-of-your-app"></a>アプリのデスクトップ バージョンをアンインストールする

先に許可を求めずにユーザーのデスクトップ アプリをアンインストールすることは、好ましくありません。 ユーザーに許可を求めるには、そのためのダイアログ ボックスを表示します。 ユーザーによって、アプリのデスクトップ バージョンをアンインストールしないように指定されることも考えられます。 その場合に、デスクトップ アプリの使用をブロックするか、両方のアプリのサイド バイ サイド使用をサポートするかを決定する必要があります。

例として、.NET ベースのデスクトップ ブリッジ アプリでの方法を次に示します。

このスニペットの完全なコンテキストを確認するには、「[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)」というサンプルの**MainWindow.cs** ファイルをご覧ください。

```csharp
private void RemoveDesktopApp()
{              
    //Typically, you can find your uninstall string at this location.
    String uninstallString = (String)Microsoft.Win32.Registry.GetValue
        (@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion" +
         @"\Uninstall\{7AD02FB8-B85E-44BC-8998-F4803BA5A0E3}\", "UninstallString", null);

    //Detect if the previous version of the Desktop App is installed.
    if (uninstallString != null)
    {
        String uninstallMessage = "To have the best experience, consider uninstalling the "
            +" previous version of this app. Would you like to do that now?";

        DialogResult uninstallResult = MessageBox.Show
            (uninstallMessage, "Uninstall the previous version", MessageBoxButtons.YesNo);

        if (uninstallResult.Equals(DialogResult.Yes))
        {
                    string[] uninstallArgs = uninstallString.Split(' ');

            Process process = new Process();
            process.StartInfo.FileName = uninstallArgs[0];
            process.StartInfo.Arguments = uninstallArgs[1];
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                //Uninstallation was unsuccessful - You can choose to block the app here.
            }
        }
    }

}
```

### <a name="video"></a>ビデオ

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Transition-Taskbar-Pins-Start-Tiles-File-Type-Associations-and-Protocol-Handlers-MD5mv5WhD_2406218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="next-steps"></a>次のステップ

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。
