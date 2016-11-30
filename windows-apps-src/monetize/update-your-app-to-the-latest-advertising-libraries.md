---
author: mcleanbyron
description: "サポートされている最新の Microsoft Advertising ライブラリを使用し、アプリで引き続きバナー広告を受信できるように、アプリを更新する方法について説明します。"
title: "最新の Microsoft Advertising ライブラリを使用するようにアプリを更新する"
translationtype: Human Translation
ms.sourcegitcommit: 9bd83a41ea4ec4ec7a75ef89e9c92f73d86cc731
ms.openlocfilehash: 710a5f4a3ae566550939fe783af7e97d20dd1b28


---

# 最新の Microsoft Advertising ライブラリを使用するようにアプリを更新する

2017 年 1 月から、以前の Advertising SDK リリースを使用しているアプリでは、Microsoft からバナー広告が提供されません。 **AdControl** または **AdMediatorControl** を使用してバナーを表示する既存アプリ (ストアに公開済みまたは開発中) がある場合に、2017 年 1 月以降も引き続きアプリでバナー広告を受信するには、最新の Advertising SDK を使用できるようにアプリの更新が必要になることがあります。 ここに記載されている手順に従って、この変更による影響をアプリが受けるかどうかを判断し、必要であればアプリの更新方法を確認してください。

この変更による影響を受けるアプリで、最新の Advertising SDK を使用できるように更新を行わなかった場合、2017 年 1 月以降の動作が次のようになります。

* アプリ内の **AdControl** コントロールや **AdMediatorControl** コントロールにはバナー広告が提供されず、これらのコントロールから広告収入を得ることができなくなります。

* アプリ内の **AdControl** または **AdMediatorControl** から新しい広告が要求されると、コントロールの **ErrorOccurred** イベントが発生し、イベント引数の **ErrorCode** プロパティに **NoAdAvailable** という値が設定されます。

この変更に関する追加のコンテキストを提供できるように、Interactive Advertising Bureau (IAB) の [Mobile Rich-media Ad Interface Definitions (MRAID) 1.0 仕様](http://www.iab.com/wp-content/uploads/2015/08/IAB_MRAID_VersionOne.pdf)を通じて HTML5 リッチ メディアを処理する機能を含む最小限の機能に対応していない、以前の Advertising SDK リリースのサポートが廃止されます。 多くの広告主様がこれらの機能を必要とされているため、Microsoft ではこの変更を行うことで、より魅力的なアプリのエコシステムを広告主様に提供し、開発者様の収益アップを図ります。

問題が発生した場合やサポートが必要な場合は、[サポートにお問い合わせください](http://go.microsoft.com/fwlink/?LinkId=393643)。

>**注:**&nbsp;&nbsp;[Microsoft Store Services SDK](http://aka.ms/store-services-sdk) (UWP アプリ用) または [Windows および Windows Phone 8.x 用の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) (Windows 8.1 アプリおよび Windows Phone 8.x アプリ用) を使用できるようにアプリを更新済みの場合、アプリでは既に最新の Advertising SDK が使用されているため、アプリをさらに変更する必要はありません。

## 前提条件

* **AdControl** または **AdMediatorControl** を使用しているアプリの完全なソース コードおよび Visual Studio プロジェクト ファイル。

* アプリの .appx パッケージまたは .xap パッケージ。

  >**注:**&nbsp;&nbsp;アプリの .appx パッケージまたは .xap パッケージがなくなっていても、このアプリの構築に使用したバージョンの Visual Studio と Advertising SDK がインストールされた状態の開発用コンピューターがあれば、Visual Studio で .appx パッケージまたは .xap パッケージを再生成できます。

<span id="part-1" />
## パート 1: アプリを更新する必要があるかどうかを決定する

以下のセクションの手順に従い、アプリの更新が必要かどうかを調べます。

### アプリで AdControl を使用している場合

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

    ```
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

* Windows 8.0 をターゲットとするアプリには、2017 年 1 月以降、バナー広告は提供されません。 インプレッション数が失われないように、Windows 10 をターゲットとする UWP アプリにプロジェクトを変換することをお勧めします。 現在、ほとんどの Windows 8.0 アプリ トラフィックが Windows 10 デバイスで送受信されています。

<span/>

**Windows Phone 7.x アプリ**

* 2017 年 1 月以降、Windows Phone 7.x をターゲットとするアプリにはバナー広告が提供されません。 インプレッション数が失われないように、プロジェクトを Windows Phone 8.1 アプリに変換するか、Windows 10 をターゲットとする UWP アプリに変換することをお勧めします。 現在、ほとんどの Windows 7.x アプリ トラフィックが Windows Phone 8.1 または Windows 10 のデバイスで送受信されています。

<span/>

### アプリで AdMediatorControl を使用している場合

アプリでバナー広告の表示に **AdMediatorControl** を使用している場合は、次の手順に従い、アプリの更新が必要かどうかを判断してください。

**Windows 10 用 UWP アプリ**

* **AdMediatorControl** は UWP アプリ用にサポートされなくなりました。 以下のセクションの手順に従い、**AdControl** の使用に移行する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

<span/>

**Windows 8.1 アプリまたは Windows Phone 8.1 アプリ**

1. 元のファイルを損なわないようにアプリの .appx パッケージまたは .xap パッケージのコピーを作成し、コピーの名前を変更して .zip 拡張子を付け、このファイルの内容を抽出します。

2. Windows PowerShell を開き、以下のコマンドを入力して、アプリ パッケージの内容への完全パスを ```-Path``` 引数に割り当てます。 このコマンドを実行すると、プロジェクトから参照されているすべての Advertising ライブラリと各ライブラリのバージョンが表示されます。

    ```
    get-childitem -Path "<path to your extracted package>" * -Recurse -include *advert*.dll,*admediator*.dll,*xamladcontrol*.dll,*universalsharedlibrary*.dll | where-object {$_.Name -notlike "*resources*" -and $_.Name -notlike "*design*" } | foreach-object { "{0}`t{1}" -f $_.FullName, [System.Diagnostics.FileVersionInfo]::GetVersionInfo($_).FileVersion }
    ```

2. 出力に表示された Microsoft.AdMediator.\*.dll ファイルのバージョンが 2.0.1603.18005 以降であれば、プロジェクトに変更を加える必要はありません。

  ファイルのバージョンの方が低い場合は、以下のセクションの手順に従ってプロジェクトを更新する必要があります。 [パート 2](update-your-app-to-the-latest-advertising-libraries.md#part-2) に進みます。

<span id="part-2" />
## パート 2: 最新の SDK をインストールする

アプリで以前の SDK リリースが使用されている場合は、次の手順に従って、開発用コンピューターに最新の SDK がインストールされているかどうかを確認します。

1. 開発用コンピューターに Visual Studio 2015 (UWP、Windows 8.1、Windows Phone 8.x のプロジェクトの場合) または Visual Studio 2013 (Windows 8.1 または Windows Phone 8.x プロジェクトの場合) がインストールされていることを確認します。

  >**注:**&nbsp;&nbsp;開発用コンピューターで Visual Studio が開いている場合は、閉じてから、以下の手順を実行します。

1.  開発用コンピューターから、以前のバージョンの Microsoft Advertising SDK および Ad Mediator SDK をアンインストールします。

2.  **コマンド プロンプト** ウィンドウを開き、次のコマンドを実行することによって、Visual Studio と共にインストールされている以前の SDK のバージョンをすべて削除します。これらのバージョンは、コンピューターにインストールされているプログラムの一覧には表示されない可能性があります。

  ```
  MsiExec.exe /x{5C87A4DB-31C7-465E-9356-71B485B69EC8}
  MsiExec.exe /x{6AB13C21-C3EC-46E1-8009-6FD5EBEE515B}
  MsiExec.exe /x{6AC81125-8485-463D-9352-3F35A2508C11}
  ```

3.  アプリに対応する最新の SDK をインストールします。
  * Windows 10 の UWP アプリの場合は、[Microsoft Store Services SDK](http://aka.ms/store-services-sdk) をインストールします。
  * 以前の OS バージョンをターゲットとするアプリの場合は、[Windows および Windows Phone 8.x の Microsoft Advertising SDK](http://aka.ms/store-8-sdk) をインストールします。

## パート 3: プロジェクトを更新する

以下の手順に従ってプロジェクトを更新します。

### Windows 10 用 UWP プロジェクト

<span/>

アプリで **AdMediatorControl** が使用されている場合は、代わりに [AdControl が使用されるようにアプリのリファクタリングを行います](migrate-from-admediatorcontrol-to-adcontrol.md)。 **AdMediatorControl** は UWP アプリ用にサポートされなくなりました。

アプリで **AdControl** が使用されている場合は、プロジェクトから Microsoft Advertising ライブラリへの既存の参照をすべて削除し、[XAML の AdControl](adcontrol-in-xaml-and--net.md) に関するページまたは [HTML の AdControl](adcontrol-in-html-5-and-javascript.md) に関するページの手順に従って、必要な参照を追加します。 これにより、プロジェクトで適切なライブラリが確実に使用されるようになります。 既存の XAML マークアップとコードを保持することもできます。

<span/>

### Windows 8.1 または Windows Phone 8.1 (XAML または JavaScript/HTML) のプロジェクト

<span/>

1. プロジェクトから、Microsoft.Advertising.\* および Microsoft.AdMediator.\* の参照をすべて削除します。 ユニバーサル プロジェクト テンプレートを使用していれば、2 つ (Windows と Windows Phone に対して 1 つずつ) の参照が含まれている場合があります。

2. アプリに **AdMediatorControl** が使用されている場合は、「[広告の仲介コントロールの追加と使用](https://msdn.microsoft.com/library/windows/apps/xaml/dn864355.aspx)」の手順に従ってライブラリ参照を追加します。 アプリに **AdControl** が使用されている場合は、[XAML の AdControl に関するページ](adcontrol-in-xaml-and--net.md)または [HTML の AdControl に関するページ](adcontrol-in-html-5-and-javascript.md)の手順に従ってライブラリ参照を追加します。

<span/>

次の点に注意してください。

* アプリが **Any CPU** プラットフォーム用にコンパイル済みであれば、アーキテクチャ固有のプラットフォーム (x86、x64、ARM) 用にプロジェクトを再コンパイルする必要があります。

* **Microsoft.Advertising.Mobile.UI** 名前空間で **AdControl** クラスが定義されているバージョンの SDK を以前に使用していた Windows Phone 8.x XAML アプリがある場合は、**Microsoft.Advertising.WinRT.UI** 名前空間の **AdControl** クラス (新しい SDK リリースでは、このクラスが含まれる名前空間が変更されました) が参照されるように、コードを更新する必要があります。

* 上記の点を除くと、既存の XAML マークアップとコードを保持できます。

<span/>

### Windows Phone 8.x Silverlight プロジェクト

<span/>

1. プロジェクトから、Microsoft.Advertising.\* および Microsoft.AdMediator.\* の参照をすべて削除します。

2. アプリに **AdMediatorControl** が使用されている場合は、「[広告の仲介コントロールの追加と使用](https://msdn.microsoft.com/library/windows/apps/xaml/dn864355.aspx)」の手順に従ってライブラリ参照を追加します。 アプリに **AdControl** が使用されている場合は、「[Windows Phone silverlight の AdControl](adcontrol-in-windows-phone-silverlight.md)」の手順に従ってライブラリ参照を追加します。

<span/>

次の点に注意してください。

* 既存の XAML マークアップとコードを保持することもできます。

* **ソリューション エクスプ ローラー**で、プロジェクトに含まれる **Microsoft.Advertising.Mobile.UI** 参照のプロパティを調べます。 アプリのターゲットが Windows Phone 8.0 の場合はバージョン 6.2.40501.0、アプリのターゲットが Windows Phone 8.1 の場合はバージョン 8.1.50112.0 である必要があります。

* Windows Phone 8.x Silverlight アプリでは、エミュレーターでの実稼働ユニットのテストはサポートされていません。 デバイスでのテストをお勧めします。

## パート 4: アプリのテストと再公開を行う

アプリをテストし、バナーが正常に提供されることを確認します。

アプリの前のバージョンが既にストアに公開されている場合は、Windows デベロッパー センターのダッシュボードで、更新されたアプリの[申請を新しく作成](https://msdns.microsoft.com/windows/uwp/publish/app-submissions)して、アプリを再公開します。





 



<!--HONumber=Nov16_HO1-->


