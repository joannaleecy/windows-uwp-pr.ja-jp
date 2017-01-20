---
author: awkoren
Description: "Desktop to UWP Bridge について理解し、Windows デスクトップ アプリケーション (Win32、WPF、Windows フォームなど) をユニバーサル Windows プラットフォーム (UWP) アプリに変換しましょう。"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop Bridge でデスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) 用に変換する"
translationtype: Human Translation
ms.sourcegitcommit: 462d2b13cefc6abb4d7c6f814ec4ee659e4afde8
ms.openlocfilehash: 1ef54c3c45113e434333058d0f039e213ea8eed2

---

# <a name="bring-your-desktop-app-to-the-universal-windows-platform-uwp-with-the-desktop-bridge"></a>Desktop Bridge でデスクトップ アプリをユニバーサル Windows プラットフォーム (UWP) 用に変換する

Desktop to UWP Bridge について理解し、Windows デスクトップ アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換しましょう。

Desktop Bridge は、Windows デスクトップ アプリケーション (Win32、Windows フォーム、WPF など) やゲームを UWP のアプリやゲームに変換するための一連のテクノロジです。 Windows デスクトップ アプリケーションは、変換後、Windows 10 デスクトップをターゲットとする UWP アプリ パッケージ (.appx または .appxbundle) の形式でパッケージ化され、処理と展開が行われます。

デスクトップ アプリの UWP パッケージへの変換を可能にするテクノロジは、2 つあります。 1 つ目は、変換プロセスです。既存のバイナリを取り込んで、UWP パッケージとして再パッケージ化します。 コードは、同じままで、パッケージ化の方法だけが異なります。 2 つ目は、Windows Anniversary Update の各種ランタイムテクノロジーで、UWP パッケージを、アプリ コンテナーではなく完全な信頼として実行される実行可能ファイルにします。 このテクノロジにより、変換済みのアプリにパッケージ ID が与えられます。パッケージ ID は一部の UWP API を使用するときに必要です。

## <a name="benefits"></a>利点

Windows デスクトップ アプリケーションを変換する利点を以下に示します。 

**スムーズな展開プロセス**。 ブリッジを使用すると、ユーザーが安心してアプリやゲームをインストールまたは更新できる優れた展開エクスペリエンスを提供できます。 ユーザーがアプリをアンインストールすると、跡形なく完全に削除されます。 このため、セットアップ エクスペリエンスの設計や、更新プログラムの配信にかかる時間を削減できます。

**自動更新とライセンス**。 アプリは、Windows ストアの組み込みライセンスと自動更新機能に参加できます。 自動更新機能は、ファイルの変更された部分だけがダウンロードされるため、非常に信頼性が高く効率的なメカニズムです。

**リーチの拡大とシンプルな決済**。 Windows ストアからの配布なら、数百万人の Windows 10 ユーザーにリーチできます。ユーザーは、アプリとゲームの購入や、アプリ内での購入に各地域の支払い方法を使用できます。

**UWP 機能の追加**。  自分のペースで、XAML ユーザー インターフェイス、ライブ タイルの更新、UWP バックグラウンド タスク、アプリ サービスなどの多くの UWP 機能をアプリのパッケージに追加できます。

**対応デバイスの拡大**。 ブリッジを使用すると、徐々にコードをユニバーサル Windows プラットフォームに移行して、電話、Xbox One、HoloLens など、すべての Windows 10 デバイスを対象にできます。

## <a name="prepare"></a>準備

Desktop to UWP Bridge は使いやすく設計されており、変換プロセス用にアプリを準備する作業はそれほど必要ありません。 ただし、変換を行う前に注意する点がいくつかあります。 先へ進む前に「[Desktop to UWP Bridge 用にアプリを準備する](desktop-to-uwp-prepare.md)」を読み、アプリに該当する点があれば対処してください。

## <a name="convert"></a>変換

アプリを変換するには、いくつかの方法があります。

**Desktop App Converter (DAC)**。 DAC は、アプリを自動的に変換し、署名を行うツールです。 DAC の使用は便利で自動的です。アプリが多くのシステム変更を行う場合や、インストーラーについて不明確な点がある場合に役立ちます。 まず、「[Desktop App Converter](desktop-to-uwp-run-desktop-app-converter.md)」をご覧ください。 

**手動変換**。 xcopy を使用してアプリをインストールする場合や、インストーラーによるシステムへの変更点が明確である場合は、手動変換の選択が適していることがあります。 これには、マニフェスト ファイルの作成、MakeAppx.exe ツールの実行、アプリ パッケージへの署名が含まれます。 手動で変換する方法について詳しくは、「[Desktop Bridge を使って手動でアプリを UWP アプリに変換する](desktop-to-uwp-manual-conversion.md)」をご覧ください。 

**サードパーティ インストーラー**。 いくつかのよく使われるサードパーティの製品とインストーラーで、Desktop Bridge がサポートされるようになりました。数クリックで MSI インストーラーまたは変換済みのアプリ パッケージを生成できます。 該当する製品の例を以下に示します。 

* [InstallShield (提供元: Flexera)](http://www.flexerasoftware.com/producer/products/software-installation/installshield-software-installer)
* [WiX (提供元: FireGiant)](https://www.firegiant.com/r/appx) 
* [Advanced Installer (提供元: Caphyon)](http://www.advancedinstaller.com/uwp-app-package)
* [RAD Studio (提供元; Embarcadero)](https://www.embarcadero.com/products/rad-studio/windows-10-store-desktop-bridge) 
* [InstallAware](https://www.installaware.com/appx.htm)

詳しくは、各インストーラーの Web サイトをご覧ください。 

## <a name="enhance"></a>強化 

変換されたデスクトップ アプリは、広範な UWP API で強化できます。ライブ タイルやプッシュ通知など、さまざまな機能を追加することができます。 完全なコード サンプルについては、GitHub のリポジトリで[デスクトップ アプリから UWP へのブリッジのコード サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)および[ユニバーサル Windows プラットフォーム (UWP) のアプリ サンプル](https://github.com/Microsoft/Windows-universal-samples)をご覧ください。 サポートされている API の一覧については、「[Desktop Bridge で変換されたアプリでサポートされている UWP API](desktop-to-uwp-supported-api.md)」をご覧ください。 

UWP API の呼び出しのほか、変換されたアプリだけがアクセスできる機能でアプリを拡張することもできます。 ユーザーのログオン時のプロセスの起動やエクスプローラーの統合などに対応した機能があり、元のデスクトップ アプリと UWP アプリのフル パッケージの間でのスムーズな移行を目的として設計されています。 詳しくは、「[Desktop Bridge アプリの拡張機能](desktop-to-uwp-extensions.md)」をご覧ください。 

## <a name="migrate"></a>移行

ブリッジを使用すると、Windows デスクトップでアプリを実行および公開する機能を維持しつつ、コードを徐々に UWP に移行できます。 UWP に完全に移行 (アプリに WPF/Win32 コンポーネントが含まれていない状態に) すると、スマートフォン、Xbox One、HoloLens などすべての Windows デバイスでの使用が可能になります。

## <a name="debug"></a>デバッグ

アプリは、Visual Studio を使ってデバッグできます。 詳しくは、「[Desktop Bridge で変換されたアプリのデバッグ](desktop-to-uwp-debug.md)」をご覧ください。 

Desktop Bridge の内部的なしくみについては、「[Desktop Bridge の内側](desktop-to-uwp-behind-the-scenes.md)」をご覧ください。 

## <a name="distribute"></a>配布

アプリは、Windows ストアまたはサイドローディングを使用して配布できます。 詳しくは、「[Desktop Bridge で変換されたアプリの配布](desktop-to-uwp-distribute.md)」をご覧ください。 アプリは、ユーザー用に展開する前に、署名する必要があります。 手順については、「[Desktop Bridge を使用して変換したアプリに署名する](desktop-to-uwp-signing.md)」をご覧ください。 

## <a name="support-and-feedback"></a>サポートとフィードバック

アプリの変換で問題が発生した場合、ヘルプのために[フォーラム](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/home?forum=wpdevelop)を利用できます。 

フィードバックを提供したり、機能の提案を行うには、[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) で項目を提出するか賛成票を投じてください。 

## <a name="in-this-section"></a>このセクションの内容

| トピック | 説明 |
|-------|-------------|
| [Desktop App Converter](desktop-to-uwp-run-desktop-app-converter.md) | Desktop App Converter を実行する方法が説明されています。 |
| [Desktop Bridge を使って手動でアプリを UWP アプリに変換する](desktop-to-uwp-manual-conversion.md) | 手動でアプリ パッケージとマニフェストを作成する方法について説明します。 |
| [Desktop Bridge アプリの拡張機能](desktop-to-uwp-extensions.md) | 拡張機能を使って、スタートアップ タスクやエクスプローラー統合などの機能を有効にして、変換済みのアプリを強化します。 |
| [Desktop Bridge で変換されたアプリでサポートされている UWP API](desktop-to-uwp-supported-api.md) | 変換されたデスクトップ アプリで利用可能な UWP API を確認します。 |
| [Desktop Bridge で変換されたアプリのデバッグ](desktop-to-uwp-debug.md) | 変換済みのアプリをデバッグするためのオプションについて説明します。 | 
| [Desktop Bridge を使用して変換したアプリに署名する](desktop-to-uwp-signing.md) | 証明書を使って変換済みのアプリ パッケージに署名する方法について説明します。 |
| [Desktop Bridge で変換されたアプリの配布](desktop-to-uwp-distribute.md) | 変換済みのアプリをユーザーに配布する方法を確認します。  |
| [Desktop Bridge の内側](desktop-to-uwp-behind-the-scenes.md) | Desktop to UWP Bridge の内部的な処理について詳しく説明します。 | 
| [Desktop Bridge に関する既知の問題](desktop-to-uwp-known-issues.md) | Desktop to UWP Bridge に関する既知の問題について説明します。 | 
| [デスクトップ アプリから UWP へのブリッジのコード サンプル](https://github.com/Microsoft/DesktopBridgeToUWP-Samples) | 変換されたアプリの機能を示す GitHub のコード サンプルです。 |


<!--HONumber=Dec16_HO3-->


