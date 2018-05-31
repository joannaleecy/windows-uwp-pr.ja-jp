---
author: normesta
Description: This article lists things you need to know before packaging your app with the Desktop Bridge. You may not need to do much to get your app ready for the packaging process.
Search.Product: eADQiWindows 10XVcnh
title: アプリのパッケージ化の準備 (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 02/21/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 71a57ca2-ca00-471d-8ad9-52f285f3022e
ms.localizationpriority: medium
ms.openlocfilehash: 1a4836992675f65773e9b5c890aca243e2a9e172
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832546"
---
# <a name="prepare-to-package-an-app-desktop-bridge"></a>アプリのパッケージ化の準備 (デスクトップ ブリッジ)

この記事では、デスクトップ アプリをパッケージ化する前に理解しておく必要のあることについて説明します。 パッケージ化プロセス用にアプリを準備するためには多くの作業を行う必要はありませんが、以下の項目のいずれかがアプリケーションに当てはまる場合には、パッケージ化の前に対処する必要があります。 ライセンスと自動更新は Microsoft Store で処理されるため、これらのタスクに関連した機能はコードベースから削除できます。

>[!IMPORTANT]
>デスクトップ ブリッジは、Windows 10 Version 1607 で導入されており、Windows 10 Anniversary Update (10.0、ビルド 14393) 以降のリリースをターゲットとする Visual Studio プロジェクトでのみ使用できます。

+ __アプリにバージョン 4.6.2 よりも前のバージョンの .NET が必要である__。 アプリが .NET 4.6.2 で実行されていることを確認します。 4.6.2 より前のバージョンを要求したり、再配布したりすることはできません。 これは、Windows 10 Anniversary Update で出荷された .NET のバージョンです。 アプリがこのバージョンで動作することを確認すると、Windows 10 の今後の更新プログラムとアプリの互換性が維持されます。  アプリが .NET Framework 4.0 以降をターゲットとしている場合、.NET 4.6.2 上で実行されることが予想されますが、テストは必要です。

+ __常に管理者特権のセキュリティ権限でアプリを実行する__。 アプリは、対話ユーザーとして実行中にも機能する必要があります。 Microsoft Store からアプリをインストールするユーザーはシステム管理者ではない可能性があります。そのため、アプリは、標準ユーザーでは正しく動作しない、管理者だけが実行できる方法で実行する必要があります。 機能の一部で昇格を必要とするアプリは、Microsoft Store では受け入れられません。

+ __アプリにカーネル モード ドライバーや Windows サービスが必要__。 ブリッジはアプリには適していますが、システム アカウントで実行する必要があるカーネル モード ドライバーや Windows サービスはサポートしていません。 Windows サービスの代わりに、[バックグラウンド タスク](https://msdn.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)を使います。

+ __アプリのモジュールが、Windows アプリ パッケージに含まれていないプロセスに読み込まれるインプロセスである__。 これは許可されていません。つまり、[シェルの拡張機能](https://msdn.microsoft.com/library/windows/desktop/dd758089.aspx)などのインプロセスの拡張機能はサポートされていません。 ただし、同じパッケージに 2 つのアプリが含まれている場合に、そのアプリ間でプロセス間通信することはできます。

+ __アプリでカスタム アプリケーション ユーザー モデル ID (AUMID) を使う__。 プロセスから [SetCurrentProcessExplicitAppUserModelID](https://msdn.microsoft.com/library/windows/desktop/dd378422.aspx) を呼び出して独自の AUMID を設定する場合、アプリ モデル環境/Windows アプリ パッケージでその目的で生成された AUMID しか使えません。 カスタムの AUMID を定義することはできません。

+ __アプリが HKEY_LOCAL_MACHINE (HKLM) レジストリ ハイブを変更する__。 アプリから HKLM キーを作成しようとしたり、変更のために開こうとしたりすると、アクセス拒否エラーが発生します。 アプリには、レジストリを仮想化した独自のプライベート ビューがあるため、ユーザーやマシン全体のレジストリ ハイブ (HKLM はこれに相当) の概念は適用されないことに注意してください。 HKLM を使って実現していたことを、HKEY_CURRENT_USER (HKCU) に書き込むなど別の方法で実現する必要があります。

+ __アプリで、別のアプリを起動する手段として ddeexec レジストリ サブキーを使っている__。 代わりに、[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474.aspx)のさまざまなアクティブ化可能* な拡張機能で構成する DelegateExecute verb ハンドラーの 1 つを使います。

+ __アプリが、別のアプリとデータを共有するために AppData フォルダーまたはレジストリに書き込みを行う__。 変換後、AppData はローカル アプリ データ ストアにリダイレクトされます。このストアは、各 UWP アプリのプライベート ストアです。

  アプリが HKEY_LOCAL_MACHINE レジストリ ハイブに書き込んだすべてのエントリが、分離されたバイナリ ファイルにリダイレクトされ、アプリが HKEY_CURRENT_USER レジストリ ハイブに書き込んだすべてのエントリが、ユーザーごと、アプリごとのプライベートな場所に配置されます。 ファイルとレジストリのリダイレクトの詳細については、「[デスクトップ ブリッジの内側](desktop-to-uwp-behind-the-scenes.md)」をご覧ください。  

  プロセス間データ共有に別の方法を使います。 詳しくは、「[設定と他のアプリ データを保存して取得する](https://msdn.microsoft.com/windows/uwp/app-settings/store-and-retrieve-app-data)」をご覧ください。

+ __アプリが、アプリのインストール ディレクトリに書き込みを行う__。 たとえば、exe と同じディレクトリに置いたログ ファイルにアプリが書き込む場合などです。 この書き込みは、サポートされていないため、ローカル アプリ データ ストアなどの別の場所にする必要があります。

+ __アプリのインストールでユーザーの対話式操作を求める__。 アプリ インストーラーはサイレント実行でき、クリーンな状態の OS イメージには既定では存在しないすべての前提条件をインストールする必要があります。

+ __アプリで現在の作業ディレクトリを使う__。 パッケージ デスクトップ アプリでは、実行時に、デスクトップで以前に指定していたのと同じ作業ディレクトリ (.LNK ショートカット) を取得しません。 アプリを正しく動作させるために現在のディレクトリを取得することが重要な場合は、実行時に CWD を変更する必要があります。

+ __アプリで UIAccess が必要__。 アプリケーションが UAC マニフェストの `requestedExecutionLevel` 要素で `UIAccess=true` を指定している場合の UWP への変換は現在サポートされていません。 詳しくは、「[UI オートメーション セキュリティの概要](https://msdn.microsoft.com/library/ms742884.aspx)」をご覧ください。

+ __COM オブジェクトをアプリで公開している__。 パッケージ内のプロセスと拡張機能は、インプロセスとアウト プロセス (OOP) の両方で、COM サーバーおよび OLE サーバーを登録して使用できます。  Creators Update では、Packaged COM のサポートが追加されています。これにより、パッケージ外部で表示されるようになった OOP COM サーバーおよび OLE サーバーを登録できるようになります。  [COM サーバーおよび OLE ドキュメントのデスクトップ ブリッジ用サポート](https://blogs.windows.com/buildingapps/2017/04/13/com-server-ole-document-support-desktop-bridge/#bjPyETFgtpZBGrS1.97)に関するブログをご覧ください。

   Packaged COM のサポートは、既存の COM API に使用できますが、Packaged COM の場所はプライベートであるため、レジストリの読み取りに直接依存するアプリケーションの拡張機能には使用できません。

+ __他のプロセスで使用できるように GAC アセンブリをアプリで公開している__。 現在のリリースでは、Windows アプリ パッケージ外部の実行可能ファイルから生成されたプロセスで使用できるようにアプリが GAC アセンブリを公開することはできません。 パッケージ内のプロセスは、通常どおり、GAC アセンブリを登録して使用できますが、外部からは認識されません。 つまり、OLE などの相互運用機能のシナリオは、外部プロセスによって呼び出された場合、機能しません。

+ __サポートされていない方法でアプリが C ランタイム ライブラリ (CRT) にリンクされている__。 Microsoft C/C++ ランタイム ライブラリは、Microsoft Windows オペレーティング システムのプログラミングのルーチンを提供します。 これらのルーチンは、C および C++ 言語では提供されない、多くの一般的なプログラミング タスクを自動化します。 アプリで C/C++ ランタイム ライブラリを使用している場合、サポートされている方法でリンクされていることを確認する必要があります。

    Visual Studio 2017 は、現在のバージョンの CRT に対して、コードで共通の DLL ファイルを使用できるようにするダイナミック リンクと、コードに直接ライブラリをリンクするスタティック リンクの両方をサポートしています。 可能であれば、アプリで VS 2017 へのダイナミック リンクを使用することをお勧めします。

    以前のバージョンの Visual Studio でのサポートは異なります。 詳しくは、次の表をご覧ください。

    <table>
    <th>Visual Studio のバージョン</td><th>ダイナミック リンク</th><th>スタティック リンク</th></th>
    <tr><td>2005 (VC 8)</td><td>サポートされない</td><td>サポートされる</td>
    <tr><td>2008 (VC 9)</td><td>サポートされない</td><td>サポートされる</td>
    <tr><td>2010 (VC 10)</td><td>サポートされる</td><td>サポートされる</td>
    <tr><td>2012 (VC 11)</td><td>サポートされる</td><td>サポートされない</td>
    <tr><td>2013 (VC 12)</td><td>サポートされる</td><td>サポートされない</td>
    <tr><td>2015 および 2017 (VC 14)</td><td>サポートされる</td><td>サポートされる</td>
    </table>

    注: いずれの場合も、最新の公開されている CRT にリンクする必要があります。

+ __アプリが Windows サイドバイサイド フォルダーからアセンブリをインストールする/読み込む__。 たとえば、アプリが C ランタイム ライブラリ VC8 または VC9 を使用しており、Windows サイドバイサイド フォルダーから動的にリンクしている、つまり、コードが共有フォルダーから共通の DLL ファイルを使用しているとします。 これはサポートされていません。 再頒布可能なライブラリ ファイルをコードに直接リンクして、静的にリンクする必要があります。

+ __アプリが、System32/SysWOW64 フォルダーの依存関係を使っている__。 DLL が機能するためには、Windows アプリ パッケージの仮想ファイル システム部分にそれらの DLL を含める必要があります。 これにより、アプリは DLL が **System32**/**SysWOW64** フォルダーにインストールされている場合と同じように動作します。 パッケージのルートで **VFS** という名前のフォルダーを作成します。 そのフォルダー内に、**SystemX64** フォルダーと **SystemX86**フォルダーを作成します。 **SystemX86** フォルダーに DLL の 32 ビット バージョンを格納し、**SystemX64** フォルダーに 64 ビット バージョンを格納します。

+ __アプリが VCLibs フレームワーク パッケージを使っている__。 VCLibs 11 ライブラリは、Windows アプリ パッケージで依存関係として定義されている場合、Microsoft Store から直接インストールできます。 たとえば、アプリが Dev11 VCLibs パッケージを使っている場合、アプリ パッケージ マニフェストに変更を加えます。`<Dependencies>` ノードで、以下のものを追加します。  
`<PackageDependency Name="Microsoft.VCLibs.110.00.UWPDesktop" MinVersion="11.0.24217.0" Publisher="CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US" />`  
Microsoft Store からインストールするとき、アプリをインストールする前に VCLibs フレームワークの適切なバージョン (x86 または x64) がインストールされます。  
アプリがサイドローディングによってインストールされる場合は、依存関係がインストールされません。 コンピューター上に依存関係を手動でインストールするには、デスクトップ ブリッジ用の適切な VCLibs フレームワーク パッケージをダウンロードしてインストールする必要があります。 これらのシナリオについて詳しくは、[Centennial プロジェクトで Visual C++ ラインタイムを使用する方法に関するページ](https://blogs.msdn.microsoft.com/vcblog/2016/07/07/using-visual-c-runtime-in-centennial-project/)をご覧ください。

  **フレームワーク パッケージ**:

  * [デスクトップ ブリッジ用の VC 14.0 フレームワーク パッケージ](https://www.microsoft.com/download/details.aspx?id=53175)
  * [デスクトップ ブリッジ用の VC 12.0 フレームワーク パッケージ](https://www.microsoft.com/download/details.aspx?id=53176)
  * [デスクトップ ブリッジ用の VC 11.0 フレームワーク パッケージ](https://www.microsoft.com/download/details.aspx?id=53340)


+ __アプリにカスタム ジャンプ リストが含まれる__。 ジャンプ リストを使用する場合は、いくつかの問題と注意事項があります。

    - __アプリのアーキテクチャが OS と一致しない。__  現在、アプリと OS のアーキテクチャが一致しない場合 (x64 Windows で実行されている x86 アプリなど)、ジャンプ リストは正しく機能しません。 現時点では、アプリを再コンパイルしてアーキテクチャを一致させる以外に回避策はありません。

    - __アプリがジャンプ リストの項目を作成して、[ICustomDestinationList::SetAppID](https://msdn.microsoft.com/library/windows/desktop/dd378403(v=vs.85).aspx) または [SetCurrentProcessExplicitAppUserModelID](https://msdn.microsoft.com/library/windows/desktop/dd378422(v=vs.85).aspx) を呼び出す__。 プログラムによって AppID をコードに設定しないでください。 そうすると、ジャンプ リストの項目が表示されません。 アプリにカスタム ID が必要な場合は、マニフェスト ファイルを使用して指定してください。 手順については、「[アプリを手動でパッケージ化する (デスクトップ ブリッジ)](desktop-to-uwp-manual-conversion.md)」を参照してください。 アプリケーションの AppID は *YOUR_PRAID_HERE* セクションに指定されます。

    - __アプリが、パッケージ内の実行可能ファイルを参照するジャンプ リスト シェル リンクを追加します__。 ジャンプ リストから直接、パッケージ内の実行可能ファイルを起動することはできません (アプリ自体の .exe の絶対パスを使用する場合は除く)。 アプリの実行エイリアスを登録し (これで、まるで PATH に指定されているかのように、キーワードを使ってパッケージ デスクトップ アプリを起動できます)、リンク先のパスにこのエイリアスを設定します。 appExecutionAlias 拡張機能の使用方法については、「[Windows 10 にアプリを統合する (デスクトップ ブリッジ)](desktop-to-uwp-extensions.md)」をご覧ください。 元の .exe に一致するジャンプ リストのリンク アセットが必要な場合は、他のカスタム項目と同様に、[**SetIconLocation**](https://msdn.microsoft.com/library/windows/desktop/bb761047(v=vs.85).aspx) を使用してアイコンなどのアセットを設定し、PKEY_Title を使用して名前を表示します。

    - __アプリが、絶体パスを使用して、アプリのパッケージ内のアセットを参照するジャンプ リスト項目を追加します__。 アプリのインストール パスが、パッケージが更新されるときに変更され、アセット (アイコン、ドキュメント、実行可能ファイルなど) の場所が変わる場合があります。 ジャンプ リストの項目が、そのようなアセットを絶対パスで参照している場合、アプリのジャンプ リストを定期的に (アプリの起動時など) 更新して、パスが正しく解決されるようにします。 または、UWP [**Windows.UI.StartScreen.JumpList**](https://msdn.microsoft.com/library/windows/apps/windows.ui.startscreen.jumplist.aspx) API を使用します。この API では、package-relative ms-resource URI スキーマ (これは言語、DPI、ハイ コントラストにも対応します) を使用して、文字列アセットと画像アセットを参照できます。

+ __タスクを実行するユーティリティがアプリによって起動される__。 PowerShell や Cmd.exe など、コマンド ユーティリティの起動は避けてください。 Windows 10 S を実行するシステムにユーザーが対象アプリをインストールした場合、アプリではこのようなユーティリティを一切起動できません。 Microsoft Store へのアプリの申請がブロックされる可能性があります。これは、Microsoft Store に申請されるすべてのアプリが Windows 10 S に対応している必要があるためです。

ユーティリティの起動は、オペレーティング システムからの情報の取得、レジストリへのアクセス、システム機能へのアクセスなどを行うための手段として便利であることが少なくありません。 ただし、このような作業を実行するには、代わりに UWP API を使用することができます。 個別の実行可能ファイルを必要としないため、これらの API の方が高効率ですが、さらに重要な点は、この方法を使用するとパッケージ外でアプリにアクセスされないよう分離できることです。 アプリの設計が、デスクトップ ブリッジ アプリで提供される分離、信頼性、セキュリティに従った形に維持されるため、Windows 10 S で実行されるシステムで、アプリを正しく実行できます。

+ __アプリで、アドイン、プラグイン、または拡張機能をホストしている__。   多くの場合、COM スタイルの拡張機能は、引き続き動作します。ただし、拡張機能がパッケージ化されておらず、完全信頼としてインストールされている場合に限られます。 これは、インストーラーによって、完全信頼機能を使用してレジストリを変更し、ホスト アプリで検出できる任意の場所に拡張機能を配置することが可能であるためです。

   ただし、これらの拡張機能がパッケージ化され、Windows アプリ パッケージとしてインストールされた場合は、各パッケージ (ホスト アプリと拡張機能) が互いに分離されるため、正しく動作しません。 デスクトップ ブリッジによってアプリケーションがシステムから分離されるしくみについては、「[デスクトップ ブリッジの内側](desktop-to-uwp-behind-the-scenes.md)」をご覧ください。

 Windows 10 S を実行するシステムにユーザーがインストールするすべてのアプリケーションおよび拡張機能は、Windows アプリ パッケージとしてインストールされる必要があります。 このため、拡張機能をパッケージ化する予定がある場合や、関係者にパッケージ化を奨励する場合は、ホスト アプリ パッケージと拡張機能パッケージの間でのやり取りをどのように実現するか、検討する必要があります。 1 つの方法として、[アプリ サービス](../launch-resume/app-services.md)を使用することもできます。

+ __アプリがコードを生成する__。 アプリは、メモリ内で消費されるコードを生成できますが、生成されたコードはディスクに書き込まないでください。このようなコードは、アプリの提出前に Windows アプリ認定プロセスで検証することができません。 また、Windows 10 S を実行するシステムでは、ディスクにコードを書き込むアプリは正しく動作しません。Microsoft Store に申請されるすべてのアプリが Windows 10 S に対応している必要があるため、Microsoft Store へのアプリの申請がブロックされる可能性があります。

>[!IMPORTANT]
> Windows アプリ パッケージを作成した後、アプリをテストして Windows 10 S を実行するシステムで正常に動作することを確認してください。Microsoft Store に提出するすべてのアプリは、Windows 10 S と互換性がある必要があります、互換性のないアプリは Microsoft Store で受け入れられません。 「[Windows アプリの Windows 10 S 対応をテストする](desktop-to-uwp-test-windows-s.md)」をご覧ください。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**デスクトップ アプリの Windows アプリ パッケージを作成する**

「[Windows アプリ パッケージを作成する](desktop-to-uwp-root.md#convert)」をご覧ください。
