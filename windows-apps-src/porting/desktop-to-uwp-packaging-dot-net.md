---
author: normesta
Description: "このガイドでは、デスクトップ ブリッジに関して、デスクトップ アプリを編集、デバッグ、パッケージ化するために Visual Studio ソリューションを構成する方法について説明します。"
Search.Product: eADQiWindows 10XVcnh
title: "Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 07/20/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.openlocfilehash: d8919448b965f18ff7f8fdaeda325889e495ef85
ms.sourcegitcommit: f6dd9568eafa10ee5cb2b849c0d82d84a1c5fb93
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/02/2017
---
# <a name="package-an-app-by-using-visual-studio-desktop-bridge"></a>Visual Studio を使ったアプリのパッケージ化 (デスクトップ ブリッジ)

Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。 その後、そのパッケージを Windows ストアに公開したり、1 台以上の PC にサイドローディングしたりすることができます。

このガイドでは、ソリューションをセットアップして、デスクトップ アプリケーションのパッケージを生成する方法を説明します。

## <a name="first-consider-how-youll-distribute-your-app"></a>まず、アプリの配布方法を検討する

アプリを [Windows ストア](https://www.microsoft.com/store/apps)に公開する予定であれば、[このフォーム](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)への記入から開始します。 Microsoft から、オンボード プロセスを開始するための連絡があります。 このプロセスでは、ストア内の名前を予約し、アプリをパッケージ化するための情報を取得します。

## <a name="add-a-packaging-project-to-your-solution"></a>パッケージ プロジェクトをソリューションに追加する

1. Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。

2. ソリューションに JavaScript の **[空白のアプリ (ユニバーサル Windows)]** プロジェクトを追加します。

   コードを追加する必要はありません。 プロジェクトを追加したのは単にパッケージを生成するためです。 このプロジェクトを "パッケージ プロジェクト" と呼びます。

   ![JavaScript の UWP プロジェクト](images/desktop-to-uwp/javascript-uwp-project.png)

   >[!IMPORTANT]
   >通常、このプロジェクトには JavaScript バージョンを使用する必要があります。  C#、VB.NET、および C++ バージョンにはいくつかの問題があります。これらを使用する場合は、作業を行う前に[既知の問題](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor)のガイドをご覧ください。

## <a name="add-the-desktop-application-binaries-to-the-packaging-project"></a>デスクトップ アプリケーション バイナリをパッケージ プロジェクトに追加する

パッケージ プロジェクトにバイナリを直接追加します。

1. **ソリューション エクスプローラー**で、パッケージ プロジェクト フォルダーを展開し、サブフォルダーを作成して、任意の名前 (**win32** など) を付けます。

2. サブフォルダーを右クリックし、**[既存項目の追加]** を選択します。

3. **[既存項目の追加]** ダイアログ ボックスで、デスクトップ アプリケーションの出力フォルダーのファイルを見つけて、追加します。 これには、実行可能ファイルだけでなく、そのフォルダー内にある dll ファイルや .config ファイルも含まれます。

   ![実行可能ファイルの参照](images/desktop-to-uwp/cpp-exe-reference.png)

   デスクトップ アプリケーション プロジェクトに変更を加えるたびに、これらのファイルの新しいバージョンをパッケージ プロジェクトにコピーする必要があります。 この作業を自動化するには、パッケージ プロジェクトのプロジェクト ファイルにビルド後のイベントを追加します。 次に例を示します。

   ```XML
   <Target Name="PostBuildEvent">
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.exe"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.exe.config"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyWindowsFormsApplication.pdb"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyBusinessLogicLibrary.dll"
       DestinationFolder="win32" />
     <Copy SourceFiles="..\MyWindowsFormsApplication\bin\Debug\MyBusinessLogicLibrary.pdb"
       DestinationFolder="win32" />
   </Target>
   ```

## <a name="modify-the-package-manifest"></a>パッケージ マニフェストの変更

パッケージ プロジェクトには、パッケージの設定を記述したファイルが含まれます。 既定では、このファイルには UWP アプリが記述されています。そのため、完全信頼で実行されるデスクトップ アプリケーションがパッケージに含まれていることをシステムで認識するように、このファイルを変更する必要があります。  

1. **ソリューション エクスプ ローラー**で、パッケージ プロジェクトを展開し、**package.appxmanifest** ファイルを右クリックして、**[コードの表示]** を選択します。

   ![.NET プロジェクトの参照](images/desktop-to-uwp/reference-dotnet-project.png)

2. 次の名前空間をファイルの先頭に追加してから、``IgnorableNamespaces`` のリストに名前空間のプレフィックスを追加します。

   ```XML
   xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
   ```
   作業が完了すると、名前空間の宣言は次のようになります。

   ```XML
   <Package
     xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
     xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
     xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
     xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
     IgnorableNamespaces="uap mp rescap">
   ```

3. ``TargetDeviceFamily`` 要素を見つけて、``Name`` 属性を **Windows.Desktop** に、``MinVersion`` 属性をパッケージ プロジェクトの最小バージョンに、``MaxVersionTested`` をパッケージ プロジェクトのターゲット バージョンにそれぞれ設定します。

   ```XML
   <TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.10586.0" MaxVersionTested="10.0.15063.0" />
   ```

   最小バージョンとターゲット バージョンは、パッケージ プロジェクトのプロパティ ページで確認できます。

   ![最小バージョンとターゲット バージョンの設定](images/desktop-to-uwp/min-target-version-settings.png)


4. ``Application`` 要素から ``StartPage`` 属性を削除します。 次に、``Executable`` 属性と ``EntryPoint`` 属性を追加します。

   ``Application`` 要素は次のようになります。

   ```XML
   <Application Id="App"  Executable=" " EntryPoint=" ">
   ```

5. ``Executable`` 属性を、デスクトップ アプリケーションの実行可能ファイルの名前に設定します。 次に、``EntryPoint`` 属性を **Windows.FullTrustApplication** に設定します。

   ``Application`` 要素は、次のようになります。

   ```XML
   <Application Id="App"  Executable="win32\MyWindowsFormsApplication.exe" EntryPoint="Windows.FullTrustApplication">
   ```
6. ``runFullTrust`` 機能を ``Capabilities`` 要素に追加します。

   ```XML
     <rescap:Capability Name="runFullTrust"/>
   ```
   この宣言の下に青い波線マークが表示される可能性がありますが、これは無視して問題ありません。

   >[!IMPORTANT]
   C++ デスクトップ アプリケーションのパッケージを作成する場合は、アプリと共に Visual C++ ランタイムを展開できるように、マニフェスト ファイルにいくつか追加の変更を加えることが必要になります。 [デスクトップ ブリッジ プロジェクトでの Visual C++ ランタイムの使用に関するページ](https://blogs.msdn.microsoft.com/vcblog/2016/07/07/using-visual-c-runtime-in-centennial-project/)をご覧ください。

7. パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。

8. パッケージをテストする場合は、「[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md)」をご覧ください。

   その後、このガイドに戻ったら、次のセクションを確認してパッケージを生成します。

## <a name="generate-a-package"></a>パッケージの生成

アプリのパッケージを生成する方法については、「[UWP アプリのパッケージ化](..\packaging\packaging-uwp-apps.md)」のトピックのガイダンスに従ってください。

**[パッケージの選択と構成]** 画面が表示されたら、いずれかのチェック ボックスを選択する前に、パッケージに含まれているバイナリの種類について少し考える必要があります。

* C#、C++、または VB.NET ベースのユニバーサル Windows プラットフォーム プロジェクトをソリューションに追加してデスクトップ アプリケーションを[拡張](desktop-to-uwp-extend.md)している場合は、**[x86]** および **[x64]** のチェック ボックスをオンにします。  

* それ以外の場合は、**[ニュートラル]** チェック ボックスをオンにします。

>[!NOTE]
サポート対象の各プラットフォームを明示的に選択することが必要になるのは、拡張したソリューションに、UWP プロジェクト用とデスクトップ プロジェクト用という、2 種類のバイナリが含まれているためです。 これらはバイナリの種類が異なるため、.NET Native ではプラットフォームごとにネイティブ バイナリを明示的に生成する必要があります。

パッケージを生成しようとするとエラーが表示される場合は、[既知の問題](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-known-issues#known-issues-anchor)のガイドをご覧ください。発生している問題がリスト内に見つからない場合は、その問題について[こちら](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)でお知らせください。

## <a name="next-steps"></a>次のステップ

**アプリを実行する/問題を検出して修正する**

「[パッケージ デスクトップ アプリの実行、デバッグ、テスト (デスクトップ ブリッジ)](desktop-to-uwp-debug.md)」をご覧ください。

**UWP API を追加してデスクトップ アプリを強化する**

「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。

**UWP コンポーネントを追加してデスクトップ アプリを拡張する**

「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。

**アプリを配布する**

「[パッケージ デスクトップ アプリの配布 (デスクトップ ブリッジ)](desktop-to-uwp-distribute.md)」をご覧ください。

**特定の質問に対する回答を見つける**

マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。

**この記事に関するフィードバックを送信する**

下のコメント セクションをご利用ください。
