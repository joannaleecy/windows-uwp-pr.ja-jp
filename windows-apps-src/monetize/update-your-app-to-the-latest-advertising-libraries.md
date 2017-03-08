---
author: mcleanbyron
description: "サポートされている最新の Microsoft Advertising ライブラリを使用し、アプリで引き続きバナー広告を受信できるように、アプリを更新する方法について説明します。"
title: "最新の Microsoft Advertising ライブラリを使用するようにアプリを更新する"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, 広告, 宣伝, AdControl, AdMediatorControl, 移行"
ms.assetid: f8d5b2ad-fcdb-4891-bd68-39eeabdf799c
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 3cdb1f41fda7bd4e4af1ce9e5f8fb4396da53f63
ms.lasthandoff: 02/08/2017

---

# <a name="update-your-app-to-the-latest-microsoft-advertising-libraries"></a>最新の Microsoft Advertising ライブラリを使用するようにアプリを更新する

**AdControl** または **AdMediatorControl** を使ってアプリ内に Microsoft Advertising のバナー広告を表示する場合、次の SDK だけがサポートされます。

* [Microsoft Store Services SDK](http://aka.ms/store-services-sdk) (UWP アプリ向け)
* [Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 および Windows Phone 8.x アプリ向け)

これらの SDK が提供される以前には、Windows アプリと Windows Phone アプリ向けに、いくつかの古い広告 SDK がリリースされていました。 このような以前の広告 SDK リリースはサポートされなくなりました。 今後、以前の SDK を使っているアプリへのバナー広告の提供は停止される予定です。

**AdControl** または **AdMediatorControl** を使ってバナー広告を表示する既存のアプリ (ストアに公開済みまたは開発中) がある場合、今後も引き続きアプリでバナー広告を受信するには、ターゲット プラットフォーム向けの最新の Advertising SDK を使うようにアプリの更新が必要になることがあります。 ここに記載されている手順に従って、この変更による影響をアプリが受けるかどうかを判断し、必要であればアプリの更新方法を確認してください。

この変更の影響を受けるアプリでは、最新の Advertising SDK を使うようにアプリを更新しないと、サポート対象外の広告 SDK リリースを使用しているアプリへのバナー広告の提供が停止されたときに、動作が次のように変更されます。

* アプリ内の **AdControl** コントロールや **AdMediatorControl** コントロールにバナー広告が提供されず、これらのコントロールから広告収入を得ることができなくなります。

* アプリ内の **AdControl** または **AdMediatorControl** から新しい広告が要求されると、コントロールの **ErrorOccurred** イベントが発生し、イベント引数の **ErrorCode** プロパティに **NoAdAvailable** という値が設定されます。

この変更に関する追加のコンテキストを提供するために、最小限の機能セットに対応していない以前の広告 SDK リリースはサポートされなくなりました。必要な機能には、Interactive Advertising Bureau (IAB) の [Mobile Rich-media Ad Interface Definitions (MRAID) 1.0 仕様](http://www.iab.com/wp-content/uploads/2015/08/IAB_MRAID_VersionOne.pdf)を通じて HTML5 リッチ メディアを処理する機能などが含まれます。 多くの広告主様がこれらの機能を必要とされているため、Microsoft ではこの変更を行うことで、より魅力的なアプリのエコシステムを広告主様に提供し、開発者様の収益アップを図ります。

問題が発生した場合やサポートが必要な場合は、[サポートにお問い合わせください](http://go.microsoft.com/fwlink/?LinkId=393643)。

>**注:**&nbsp;&nbsp;アプリで既に [Microsoft Store Services SDK](http://aka.ms/store-services-sdk) (UWP アプリ向け) または [Windows および Windows Phone 8.x 用 Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 アプリおよび Windows Phone 8.x アプリ向け) を使っている場合、またはこれらの SDK のいずれかを使うようにアプリを更新済みである場合は、利用可能な最新の SDK が既に使われているため、それ以上の変更をアプリに加える必要はありません。

## <a name="prerequisites"></a>前提条件

* **AdControl** または **AdMediatorControl** を使用しているアプリの完全なソース コードおよび Visual Studio プロジェクト ファイル。

* アプリの .appx パッケージまたは .xap パッケージ。

  >**注:**&nbsp;&nbsp;アプリの .appx パッケージまたは .xap パッケージがなくなっていても、このアプリの構築に使用したバージョンの Visual Studio と Advertising SDK がインストールされた状態の開発用コンピューターがあれば、Visual Studio で .appx パッケージまたは .xap パッケージを再生成できます。

<span id="part-1" />
## <a name="part-1-determine-whether-you-need-to-update-your-app"></a>パート 1: アプリを更新する必要があるかどうかを決定する

以下のセクションの手順に従い、アプリの更新が必要かどうかを調べます。

### <a name="your-app-uses-adcontrol"></a>アプリで AdControl を使用している場合

アプリでバナー広告の表示に **AdControl** を使用している場合は、次の手順に従います。

**Windows 10 用 UWP アプリ**

1. 元のファイルを損なわないようにアプリの .appx パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。

2. アプリ パッケージから抽出した内容を確認します。

  * Microsoft.Advertising.dll ファイルがある場合は、アプリで以前の SDK が使用されているため、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

  * Microsoft.Advertising.dll ファイルがない場合は、最新の利用可能な Advertising SDK が既に UWP アプリで使用されているため、プロジェクトに変更を加える必要はありません。

<span/>

**Windows 8.1 アプリまたは Windows Phone 8.x アプリ**

1. 元のファイルを損なわないようにアプリの .appx パッケージまたは .xap パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。

2. XAML アプリまたは JavaScript/HTML アプリについて、アプリ パッケージから抽出した内容を確認します。

  * Microsoft.Advertising.winmd ファイルが含まれていて、UniversalXamlAdControl.\*.dll ファイル (XAML アプリの場合) または UniversalSharedLibrary.Windows.dll ファイル (JavaScript/HTML アプリの場合) が含まれていなければ、アプリで以前の SDK が使用されているため、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

  * それ以外の場合は、次の手順に進みます。

2. Windows PowerShell を開き、以下のコマンドを入力して、アプリ パッケージの内容への完全パスを ```-Path``` 引数に割り当てます。 このコマンドを実行すると、プロジェクトから参照されているすべての Advertising ライブラリと各ライブラリのバージョンが表示されます。

  > [!div class="tabbedCodeSnippets"]
  ```syntax
  get-childitem -Path "<path to your extracted package>" * -Recurse -include *advert*.dll,*admediator*.dll,*xamladcontrol*.dll,*universalsharedlibrary*.dll | where-object {$_.Name -notlike "*resources*" -and $_.Name -notlike "*design*" } | foreach-object { "{0}`t{1}" -f $_.FullName, [System.Diagnostics.FileVersionInfo]::GetVersionInfo($_).FileVersion }
  ```

2. 出力されたファイルを以下の表でアプリの対象プラットフォームについて特定し、そのファイルの実際のバージョンと表内のバージョンを比較します。

  <table>
    <colgroup>
      <col width="33%" />
      <col width="33%" />
      <col width="33%" />
    </colgroup>
    <thead>
      <tr class="header">
        <th align="left">対象プラットフォーム</th>
        <th align="left">ファイル</th>
        <th align="left">バージョン</th>
      </tr>
    </thead>
    <tbody>
      <tr class="odd">
        <td align="left"><p>Windows 8.1 XAML</p></td>
        <td align="left"><p>UniversalXamlAdControl.Windows.dll</p></td>
        <td align="left"><p>8.5.1601.07018</p></td>
      </tr>
      <tr class="odd">
        <td align="left"><p>Windows Phone 8.1 XAML</p></td>
        <td align="left"><p>UniversalXamlAdControl.WindowsPhone.dll</p></td>
        <td align="left"><p>8.5.1601.07018</p></td>
      </tr>
      <tr class="odd">
        <td align="left"><p>Windows 8.1 JavaScript/HTML<br/>Windows Phone 8.1 JavaScript/HTML</p></td>
        <td align="left"><p>UniversalSharedLibrary.Windows.dll</p></td>
        <td align="left"><p>8.5.1601.07018</p></td>
      </tr>
      <tr class="odd">
        <td align="left"><p>Windows Phone 8.1 Silverlight</p></td>
        <td align="left"><p>Microsoft.Advertising.\*.dll</p></td>
        <td align="left"><p>8.1.50112.0</p></td>
      </tr>
      <tr class="odd">
        <td align="left"><p>Windows Phone 8.0 Silverlight</p></td>
        <td align="left"><p>Microsoft.Advertising.\*.dll</p></td>
        <td align="left"><p>6.2.40501.0</p></td>
      </tr>
    </tbody>
  </table>

3. 実際のファイルのバージョンが、表に示されているバージョン以降であれば、プロジェクトに変更を加える必要はありません。

  実際のファイルのバージョンの方が低い場合は、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

<span/>

**Windows 8.0 アプリ**

* Windows 8.0 をターゲットとするアプリへのバナー広告の提供は終了しました。 インプレッション数が失われないように、Windows 10 をターゲットとする UWP アプリにプロジェクトを変換することをお勧めします。 現在、ほとんどの Windows 8.0 アプリのトラフィックは Windows 10 デバイスで送受信されています。

<span/>

**Windows Phone 7.x アプリ**

* Windows Phone 7.x をターゲットとするアプリへのバナー広告の提供は終了しました。 インプレッション数が失われないように、プロジェクトを Windows Phone 8.1 アプリに変換するか、Windows 10 をターゲットとする UWP アプリに変換することをお勧めします。 現在、ほとんどの Windows 7.x アプリ トラフィックが Windows Phone 8.1 または Windows 10 のデバイスで送受信されています。

<span/>

### <a name="your-app-uses-admediatorcontrol"></a>アプリで AdMediatorControl を使用している場合

アプリでバナー広告の表示に **AdMediatorControl** を使用している場合は、次の手順に従い、アプリの更新が必要かどうかを判断してください。

**Windows 10 用 UWP アプリ**

* **AdMediatorControl** は UWP アプリ用にサポートされなくなりました。 以下のセクションの手順に従い、**AdControl** の使用に移行する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

<span/>

**Windows 8.1 アプリまたは Windows Phone 8.1 アプリ**

1. 元のファイルを損なわないようにアプリの .appx パッケージまたは .xap パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。

2. Windows PowerShell を開き、以下のコマンドを入力して、アプリ パッケージの内容への完全パスを ```-Path``` 引数に割り当てます。 このコマンドを実行すると、プロジェクトから参照されているすべての Advertising ライブラリと各ライブラリのバージョンが表示されます。

  > [!div class="tabbedCodeSnippets"]
  ```syntax
  get-childitem -Path "<path to your extracted package>" * -Recurse -include *advert*.dll,*admediator*.dll,*xamladcontrol*.dll,*universalsharedlibrary*.dll | where-object {$_.Name -notlike "*resources*" -and $_.Name -notlike "*design*" } | foreach-object { "{0}`t{1}" -f $_.FullName, [System.Diagnostics.FileVersionInfo]::GetVersionInfo($_).FileVersion }
  ```

2. 出力に表示された Microsoft.AdMediator.\*.dll ファイルのバージョンが 2.0.1603.18005 以降であれば、プロジェクトに変更を加える必要はありません。

  ファイルのバージョンの方が低い場合は、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

<span id="part-2" />
## <a name="part-2-install-the-latest-sdk"></a>パート 2: 最新の SDK をインストールする

アプリで以前の SDK リリースが使用されている場合は、次の手順に従って、開発用コンピューターに最新の SDK がインストールされているかどうかを確認します。

1. 開発用コンピューターに Visual Studio 2015 (UWP、Windows 8.1、Windows Phone 8.x のプロジェクトの場合) または Visual Studio 2013 (Windows 8.1 または Windows Phone 8.x プロジェクトの場合) がインストールされていることを確認します。

  >**注:**&nbsp;&nbsp;開発用コンピューターで Visual Studio が開いている場合は、閉じてから、以下の手順を実行します。

1.    開発用コンピューターから、以前のバージョンの Microsoft Advertising SDK および Ad Mediator SDK をアンインストールします。

2.    **コマンド プロンプト** ウィンドウを開き、次のコマンドを実行することによって、Visual Studio と共にインストールされている以前の SDK のバージョンをすべて削除します。これらのバージョンは、コンピューターにインストールされているプログラムの一覧には表示されない可能性があります。

  > [!div class="tabbedCodeSnippets"]
  ```syntax
  MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
  MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
  MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
  ```

3.    アプリに対応する最新の SDK をインストールします。
  * Windows 10 の UWP アプリの場合は、[Microsoft Store Services SDK](http://aka.ms/store-services-sdk) をインストールします。
  * 以前の OS バージョンをターゲットとするアプリの場合は、[Windows および Windows Phone 8.x の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。

## <a name="part-3-update-your-project"></a>パート 3: プロジェクトを更新する

以下の手順に従ってプロジェクトを更新します。

### <a name="uwp-projects-for-windows-10"></a>Windows 10 用 UWP プロジェクト

<span/>

アプリで **AdMediatorControl** が使用されている場合は、代わりに [AdControl が使用されるようにアプリのリファクタリングを行います](migrate-from-admediatorcontrol-to-adcontrol.md)。 **AdMediatorControl** は UWP アプリ用にサポートされなくなりました。

アプリで **AdControl** が使用されている場合は、プロジェクトから Microsoft Advertising ライブラリへの既存の参照をすべて削除し、[XAML の AdControl](adcontrol-in-xaml-and--net.md) に関するページまたは [HTML の AdControl](adcontrol-in-html-5-and-javascript.md) に関するページの手順に従って、必要な参照を追加します。 これにより、プロジェクトで適切なライブラリが確実に使用されるようになります。 既存の XAML マークアップとコードを保持することもできます。

<span/>

### <a name="windows-81-or-windows-phone-81-xaml-or-javascripthtml-projects"></a>Windows 8.1 または Windows Phone 8.1 (XAML または JavaScript/HTML) のプロジェクト

<span/>

1. プロジェクトから、Microsoft.Advertising.\* および Microsoft.AdMediator.\* の参照をすべて削除します。 ユニバーサル プロジェクト テンプレートを使用していれば、2 つ (Windows と Windows Phone に対して 1 つずつ) の参照が含まれている場合があります。

2. アプリに **AdMediatorControl** が使用されている場合は、「[広告の仲介コントロールの追加と使用](https://msdn.microsoft.com/library/windows/apps/xaml/dn864355.aspx)」の手順に従ってライブラリ参照を追加します。 アプリに **AdControl** が使用されている場合は、[XAML の AdControl に関するページ](adcontrol-in-xaml-and--net.md)または [HTML の AdControl に関するページ](adcontrol-in-html-5-and-javascript.md)の手順に従ってライブラリ参照を追加します。

<span/>

次の点に注意してください。

* アプリが **Any CPU** プラットフォーム用にコンパイル済みであれば、アーキテクチャ固有のプラットフォーム (x86、x64、ARM) 用にプロジェクトを再コンパイルする必要があります。

* **Microsoft.Advertising.Mobile.UI** 名前空間で **AdControl** クラスが定義されているバージョンの SDK を以前に使用していた Windows Phone 8.x XAML アプリがある場合は、**Microsoft.Advertising.WinRT.UI** 名前空間の **AdControl** クラス (新しい SDK リリースでは、このクラスが含まれる名前空間が変更されました) が参照されるように、コードを更新する必要があります。

* 上記の点を除くと、既存の XAML マークアップとコードを保持できます。

<span/>

### <a name="windows-phone-8x-silverlight-projects"></a>Windows Phone 8.x Silverlight プロジェクト

<span/>

1. プロジェクトから、Microsoft.Advertising.\* および Microsoft.AdMediator.\* の参照をすべて削除します。

2. アプリに **AdMediatorControl** が使用されている場合は、「[広告の仲介コントロールの追加と使用](https://msdn.microsoft.com/library/windows/apps/xaml/dn864355.aspx)」の手順に従ってライブラリ参照を追加します。 アプリに **AdControl** が使用されている場合は、「[Windows Phone silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」の手順に従ってライブラリ参照を追加します。

<span/>

次の点に注意してください。

* 既存の XAML マークアップとコードを保持することもできます。

* **ソリューション エクスプ ローラー**で、プロジェクトに含まれる **Microsoft.Advertising.Mobile.UI** 参照のプロパティを調べます。 アプリのターゲットが Windows Phone 8.0 の場合はバージョン 6.2.40501.0、アプリのターゲットが Windows Phone 8.1 の場合はバージョン 8.1.50112.0 である必要があります。

* Windows Phone 8.x Silverlight アプリでは、エミュレーターでの実稼働ユニットのテストはサポートされていません。 デバイスでのテストをお勧めします。

## <a name="part-4-test-and-republish-your-app"></a>パート 4: アプリのテストと再公開を行う

アプリをテストし、バナーが正常に提供されることを確認します。

アプリの前のバージョンが既にストアに公開されている場合は、Windows デベロッパー センターのダッシュボードで、更新されたアプリの[申請を新しく作成](../publish/app-submissions.md)して、アプリを再公開します。





 

