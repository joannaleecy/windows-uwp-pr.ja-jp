---
author: normesta
Description: Distribute a packaged desktop app (Desktop Bridge)
Search.Product: eADQiWindows 10XVcnh
title: パッケージ デスクトップ アプリは、Microsoft Store に公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。
ms.author: normesta
ms.date: 05/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.localizationpriority: medium
ms.openlocfilehash: fe36fec72645558c539dd8270fd15d35d92b66b5
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207188"
---
# <a name="distribute-a-packaged-desktop-app-desktop-bridge"></a>パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)

パッケージ デスクトップ アプリは、Windows ストアに公開することも、1 台以上のデバイスにサイドローディングで展開することもできます。  

> [!NOTE]
> パッケージ アプリにユーザーを移行する方法について、計画はありますか?  アプリを配布する前に、このガイドの「[パッケージ アプリにユーザーを移行する](#transition-users)」セクションを参照して、アイデアを得てください。

## <a name="distribute-your-app-by-publishing-it-to-the-microsoft-store"></a>Microsoft Store に公開してアプリを配布する

[Microsoft Store](https://www.microsoft.com/store/apps) は、お客様がアプリを取得する場合に最も便利な方法です。

Microsoft Store では、幅広いお客様を対象にしてアプリを公開できます。 また、組織のお客様は[ビジネス向け Microsoft Store](https://www.microsoft.com/business-store) を通じてアプリを入手し、組織内で配布できます。

Microsoft Store への公開を計画している場合は、申請プロセスの一部としていくつかの追加の質問をされます。 これは、パッケージ マニフェストが **runFullTrust** という名前の制限付き機能を宣言し、弊社でアプリケーションによるその機能の使用を承認する必要があるためです。 この要件の詳細については、「[制限付き機能](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#restricted-capabilities)」を参照してください。

Microsoft Store に提出する前に、アプリに署名する必要はありません。

>[!IMPORTANT]
> Microsoft Store にアプリを公開する場合は、Windows 10 S を実行するデバイスでアプリが正しく動作することを確認してください。これは、Store 要件です。 「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

<a id="side-load" />

## <a name="distribute-your-app-without-placing-it-onto-the-microsoft-store"></a>Microsoft Store に掲載せずにアプリを配布する

Microsoft Store を使用せずにアプリを配布する場合は、1 台または複数のデバイスにアプリを手動で配布できます。

この方法は、配布エクスペリエンスをきめ細かく制御する必要がある場合や、Microsoft Store の認定プロセスへの関与が望ましくない場合などに有効です。

アプリをストアに掲載せずに他のデバイスに配布するには、証明書を取得し、その証明書を使ってアプリに署名して、各デバイスにアプリをサイドローディング展開する必要があります。

[証明書を作成](../packaging/create-certificate-package-signing.md)することも、[Verisign](https://www.verisign.com/) などのポピュラーなベンダーから取得することもできます。

Windows 10 S を実行するデバイスへのアプリ配布を計画している場合、Microsoft Store によるアプリへの署名が必要であるため、デバイスへのアプリ配布を開始する前に、Microsoft Store 提出プロセスを実施する必要があります。

証明書を作成する場合は、アプリを実行する各デバイスの証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールする必要があります。 ポピュラーなベンダーから証明書を取得する場合、システムにはアプリの他に何もインストールする必要はありません。  

> [!IMPORTANT]
> 証明書の発行元名がアプリの発行者名と一致することを確認してください。

証明書を使ってアプリに署名する方法については、「[SignTool を使ってアプリ パッケージに署名する](../packaging/sign-app-package-using-signtool.md)」をご覧ください。

他のデバイスにアプリをサイドローディング展開する方法については、「[Windows 10 での LOB アプリのサイドローディング](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)」をご覧ください。

**ビデオ**

|Microsoft Store へのアプリ公開 |エンタープライズ アプリの配布  |
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Windows-Store-Publication-3cWyG5WhD_5506218965"      width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Distribution-for-Enterprise-Apps-XJ5Hd5WhD_1106218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<a id="transition-users" />

## <a name="transition-users-to-your-packaged-app"></a>パッケージ アプリへのユーザーの移行

ユーザーによってパッケージ アプリが使用されるようにするには、アプリを配布する前に、パッケージ マニフェストにいくつかの拡張機能を追加することを検討してください。 次のようなことができます。

* 既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する。
* パッケージ アプリを一連のファイルの種類に関連付ける。
* 特定の種類のファイルが既定でパッケージ アプリによって開かれるように設定する。

拡張機能の完全な一覧と使用方法のガイダンスについては、「[アプリにユーザーを移行する](desktop-to-uwp-extensions.md#transition-users-to-your-app)」を参照してください。

また、次のようなタスクを実行するコードをパッケージ アプリに追加することも検討してください。

* パッケージ アプリの適切なフォルダーに、デスクトップ アプリに関連付けられているユーザー データを移行します。
* アプリのデスクトップ バージョンをアンインストールするためのオプションをユーザーに示します。

これらのタスクについて、それぞれ説明します。 ユーザー データの移行から開始します。

### <a name="migrate-user-data"></a>ユーザー データの移行

ユーザー データを移行するためのコードを追加する場合、そのコードはアプリを初めて起動したときにのみ実行することをお勧めします。 ユーザー データを移行する前に、ユーザーに対してダイアログ ボックスを表示して、何が起こっているか、なぜ移行が推奨されるのか、既存のデータにどのような影響があるかを説明します。

例として、.NET ベースのパッケージ アプリでの方法を次に示します。

```csharp
private void MigrateUserData()
{
    String sourceDir = Environment.GetFolderPath
        (Environment.SpecialFolder.ApplicationData) + "\\AppName";

    if (sourceDir != null)
    {
        DialogResult migrateResult = MessageBox.Show
            ("Would you like to migrate your data from the previous version of this app?",
             "Data Migration", MessageBoxButtons.YesNo);

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

例として、.NET ベースのパッケージ アプリでの方法を次に示します。

このスニペットの完全なコンテキストを確認するには、「[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)」というサンプルの **MainWindow.cs** ファイルを参照してください。

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
        DialogResult uninstallResult = MessageBox.Show
            ("To have the best experience, consider uninstalling the "
              + " previous version of this app. Would you like to do that now?",
              "Uninstall the previous version", MessageBoxButtons.YesNo);

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

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

Microsoft Store へのアプリの公開で問題が発生した場合は、この[ブログ投稿](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/)で役に立つヒントを参照できます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
