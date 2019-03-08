---
Description: 配布パッケージのデスクトップ アプリケーション (デスクトップ ブリッジ)
Search.Product: eADQiWindows 10XVcnh
title: Microsoft Store またはサイドロードにパッケージ化されたデスクトップ アプリケーションを発行して 1 つまたは複数のデバイスにします。
ms.date: 05/18/2018
ms.topic: article
keywords: windows 10, uwp
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.localizationpriority: medium
ms.openlocfilehash: 8968864a0ff4bcf9e27f75a44a0a500736bb54b8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57619697"
---
# <a name="distribute-a-packaged-desktop-application"></a>パッケージ化されたデスクトップ アプリケーションを配布します。

Microsoft Store またはサイドロードにパッケージ化されたデスクトップ アプリケーションを発行して 1 つまたは複数のデバイスにします。  

> [!NOTE]
> ユーザーをパッケージ化されたアプリケーションに移行する方法を計画していますか。 アプリを配布する前に、このガイドの「[パッケージ アプリにユーザーを移行する](#transition-users)」セクションを参照して、アイデアを得てください。

## <a name="distribute-your-application-by-publishing-it-to-the-microsoft-store"></a>Microsoft Store に公開することによって、アプリケーションを配布します。

[Microsoft Store](https://www.microsoft.com/store/apps) は、お客様がアプリを取得する場合に最も便利な方法です。

広範な対象ユーザーに到達する Microsoft Store にアプリケーションを発行します。 組織の顧客がを通じて、組織に内部的に配布するアプリケーションを取得することも、[ビジネス向け Microsoft Store](https://www.microsoft.com/business-store)します。

Microsoft Store への公開を計画している場合は、申請プロセスの一部としていくつかの追加の質問をされます。 これは、パッケージ マニフェストが **runFullTrust** という名前の制限付き機能を宣言し、弊社でアプリケーションによるその機能の使用を承認する必要があるためです。 詳細については、ここで、この要件。[機能が制限されている](https://docs.microsoft.com/windows/uwp/packaging/app-capability-declarations#restricted-capabilities)します。

ストアに送信する前に、アプリケーションに署名する必要はありません。

>[!IMPORTANT]
> Microsoft Store にアプリケーションを発行する場合は、Windows 10 s. を実行するデバイスで、アプリケーションが正しく動作確認します。これは、ストアの要件です。 「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

<a id="side-load" />

## <a name="distribute-your-application-without-placing-it-onto-the-microsoft-store"></a>Microsoft Store に配置することがなく、アプリケーションを配布します。

ストアを使用せず、アプリケーション配布ではなく場合、は、1 つまたは複数のデバイスにアプリを手動で配布できます。

この方法は、配布エクスペリエンスをきめ細かく制御する必要がある場合や、Microsoft Store の認定プロセスへの関与が望ましくない場合などに有効です。

ストアに配置することがなく、他のデバイスにアプリケーションを配布するには、証明書を取得するには、アプリケーションをそれらのデバイスにその証明書、および、サイドローディングを使用して、アプリケーションの署名があります。

[証明書を作成](../packaging/create-certificate-package-signing.md)することも、[Verisign](https://www.verisign.com/) などのポピュラーなベンダーから取得することもできます。

Windows 10 S を実行しているデバイスにアプリケーションを配布する場合は、これらのデバイスにアプリケーションを配布する前に、ストア提出プロセスを経由する必要があるありますので、Microsoft Store で署名するアプリケーションを持ちます。

証明書を作成する場合は、アプリを実行する各デバイスの証明書ストア ("**信頼されたルート**" または "**信頼されたユーザー**") にインストールする必要があります。 ポピュラーなベンダーから証明書を取得する場合、システムにはアプリの他に何もインストールする必要はありません。  

> [!IMPORTANT]
> 証明書の発行元名がアプリの発行者名と一致することを確認してください。

アプリケーションへの署名証明書を使用してを参照してください。 [SignTool を使用して、アプリケーション パッケージに署名](../packaging/sign-app-package-using-signtool.md)します。

サイドローディングを行う他のデバイスにアプリケーションを参照してください[サイドローディングを行う基幹業務アプリと Windows 10 で](https://technet.microsoft.com/itpro/windows/deploy/sideload-apps-in-windows-10)します。

**動画**

|Microsoft Store にアプリケーションを発行します。 |エンタープライズ アプリケーションを配布します。  |
|---|---|
|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Windows-Store-Publication-3cWyG5WhD_5506218965"      width="426" height="472" allowFullScreen frameBorder="0"></iframe>|<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Video-Distribution-for-Enterprise-Apps-XJ5Hd5WhD_1106218965" width="426" height="472" allowFullScreen frameBorder="0"></iframe>|

<a id="transition-users" />

## <a name="transition-users-to-your-packaged-app"></a>パッケージ アプリへのユーザーの移行

ユーザーによってパッケージ アプリが使用されるようにするには、アプリを配布する前に、パッケージ マニフェストにいくつかの拡張機能を追加することを検討してください。 次のようなことができます。

* 既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する。
* パッケージ化されたアプリケーションをファイルの種類のセットに関連付けます。
* 既定で特定の種類のファイルを開き、パッケージ化されたアプリケーションを作成します。

拡張機能の完全な一覧と使用方法のガイダンスについては、「[アプリにユーザーを移行する](desktop-to-uwp-extensions.md#transition-users-to-your-app)」を参照してください。

また、これらのタスクが実行されるパッケージ化されたアプリケーションにコードを追加することを検討してください。

* デスクトップ アプリケーションをパッケージ化されたアプリの適切なフォルダーの場所に関連付けられているユーザー データを移行します。
* アプリのデスクトップ バージョンをアンインストールするためのオプションをユーザーに示します。

これらのタスクについて、それぞれ説明します。 ユーザー データの移行から開始します。

### <a name="migrate-user-data"></a>ユーザー データの移行

ユーザー データを移行するコードを追加しようとしている場合は、アプリケーションが初めて起動した場合にのみ、そのコードを実行することをお勧めします。 ユーザー データを移行する前に、ユーザーに対してダイアログ ボックスを表示して、何が起こっているか、なぜ移行が推奨されるのか、既存のデータにどのような影響があるかを説明します。

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

最初に許可を求めることがなく、ユーザーのデスクトップ アプリケーションをアンインストールすることをお勧めします。 ユーザーに許可を求めるには、そのためのダイアログ ボックスを表示します。 ユーザーによって、アプリのデスクトップ バージョンをアンインストールしないように指定されることも考えられます。 このような場合は、デスクトップ アプリケーションの使用状況をブロックまたは両方のアプリのサイド バイ サイドでの使用をサポートするかどうかを決定する必要があります。

例として、.NET ベースのパッケージ アプリでの方法を次に示します。

このスニペットの完全なコンテキストを確認するには、「[WPF picture viewer with transition/migration/uninstallation](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)」というサンプルの **MainWindow.cs** ファイルを参照してください。

```csharp
private void RemoveDesktopApp()
{              
    //Typically, you can find your uninstall string at this location.
    String uninstallString = (String)Microsoft.Win32.Registry.GetValue
        (@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion" +
         @"\Uninstall\{7AD02FB8-B85E-44BC-8998-F4803BA5A0E3}\", "UninstallString", null);

    //Detect if the previous version of the Desktop application is installed.
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
                //Uninstallation was unsuccessful - You can choose to block the application here.
            }
        }
    }

}
```

### <a name="video"></a>Video

<iframe src="https://mva.microsoft.com/en-US/training-courses-embed/developers-guide-to-the-desktop-bridge-17373/Demo-Transition-Taskbar-Pins-Start-Tiles-File-Type-Associations-and-Protocol-Handlers-MD5mv5WhD_2406218965" width="636" height="480" allowFullScreen frameBorder="0"></iframe>

## <a name="next-steps"></a>次のステップ

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

Microsoft Store へのアプリの公開で問題が発生した場合は、この[ブログ投稿](https://blogs.msdn.microsoft.com/appconsult/2017/09/25/preparing-a-desktop-bridge-application-for-the-store-submission/)で役に立つヒントを参照できます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
