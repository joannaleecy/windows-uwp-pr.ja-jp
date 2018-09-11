---
author: PatrickFarley
ms.assetid: 1526FF4B-9E68-458A-B002-0A5F3A9A81FD
title: Windows アプリ認定キットのテスト
description: Windows アプリ認定キット テスト アプリが Microsoft Store に公開する準備ができていることを確認に役立ついくつか含まれます。
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリの認定
ms.localizationpriority: medium
ms.openlocfilehash: 49ecc472c8c1d4adebd8376fce9d2d5e6e2a955e
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3850962"
---
# <a name="windows-app-certification-kit-tests"></a>Windows アプリ認定キットのテスト


[Windows アプリ認定キット](windows-app-certification-kit.md)には、さまざまな Microsoft Store に公開する準備ができたらを保証するためのテストが含まれています。 テストは、条件の詳細については、次の一覧し、操作が失敗した場合の推奨されます。

## <a name="deployment-and-launch-tests"></a>展開と起動のテスト

認証テスト中にアプリを監視して、アプリがクラッシュやハングを起こしたタイミングを記録します。

### <a name="background"></a>背景

応答しなくなったアプリやクラッシュしたアプリは、データが失われたり操作性が低下したりする原因になることがあります。

アプリは、Windows の互換モードや AppHelp メッセージ、互換性修正プログラムを使わずにフル機能することが求められています。

アプリは、HKEY\-LOCAL\-MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows\\AppInit\-DLLs レジストリ キーに読み込む DLL を一覧する必要はありません。

### <a name="test-details"></a>テストの詳細

認定テストを通じて、アプリの復元性や安定性をテストします。

Windows アプリ認定キットで [**IApplicationActivationManager::ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903) を呼び出し、アプリを起動します。 **ActivateApplication** でアプリを起動する場合は、ユーザー アカウント制御 (UAC) を有効にし、画面解像度を 1024 x 768 または 768 x 1024 以上にする必要があります。 どちらの条件も満たされない場合は、アプリはこのテストに合格しません。

### <a name="corrective-actions"></a>問題への対応

テスト コンピューターで UAC が有効になっていることを確認します。

十分な大きさの画面を備えたコンピューターでテストを実行していることを確認します。

テスト プラットフォームが [**ActivateApplication**](https://msdn.microsoft.com/library/windows/desktop/Hh706903) の前提条件を満たしているにもかかわらずアプリの起動に失敗する場合は、アクティブ化イベント ログを確認して問題のトラブルシューティングを行うことができます。 イベント ログでこのようなエントリを見つけるには、次の手順を実行します。

1.  eventvwr.exe を開き、アプリケーションとサービス ログ\\Microsoft\\Windows\\Immersive-Shell フォルダーに移動します。
2.  ビューをフィルター処理してイベント ID 5900 ～ 6000 を表示します。
3.  アプリが起動しなかった理由を説明している可能性のある情報のログ エントリを確認します。

問題のあるファイルをトラブルシューティングして問題を特定し、修正します。 アプリをリビルドして再テストします。 また、ダンプ ファイルが Windows アプリ認定キットのログ フォルダーに生成されたかどうかを確認します。ダンプ ファイルもアプリのデバッグに使用できます。

## <a name="platform-version-launch-test"></a>プラットフォーム バージョン起動テスト

Windows アプリを将来のバージョンの OS で実行できることを確認します。 これまで、このテストはデスクトップ アプリ ワークフローにのみ適用されてきましたが、ストアおよびユニバーサル Windows プラットフォーム (UWP) のワークフローに有効になりました。

### <a name="background"></a>背景

オペレーティング システムのバージョン情報は、Microsoft ストアの使用量を制限されています。 これは、アプリが OS のバージョンに固有の機能をユーザーに提供できるように、アプリによって OS バージョンを確認する目的で誤って使用されることがよくありました。

### <a name="test-details"></a>テストの詳細

Windows アプリ認定キットは、HighVersionLie を使って、アプリが OS のバージョンを確認する方法を検出します。 アプリがクラッシュした場合は、このテストに合格しません。

### <a name="corrective-action"></a>問題への対応

アプリは、バージョン API ヘルパー関数を使ってこれを確認する必要があります。 詳しくは、「[オペレーティング システムのバージョン](https://msdn.microsoft.com/library/windows/desktop/ms724832)」をご覧ください。

## <a name="background-tasks-cancellation-handler-validation"></a>バックグラウンド タスクの取り消しハンドラーの検証

宣言されているバックグラウンド タスクの取り消しハンドラーがアプリにあることを確認します。 タスクが取り消されたときに呼び出される専用の関数が必要です。 このテストは、展開済みのアプリにのみ適用されます。

### <a name="background"></a>背景

ストア アプリは、バック グラウンドで実行されるプロセスを登録できます。 たとえば、メール アプリはときどき ping を実行することがあります。 しかし、OS がこれらのリソースを必要とする場合は、バックグラウンド タスクが取り消され、アプリはこの取り消しを適切に処理する必要があります。 取り消しハンドラーがないアプリはクラッシュする可能性や、ユーザーがアプリを閉じようとしても終了しない可能性があります。

### <a name="test-details"></a>テストの詳細

アプリが起動して中断され、アプリの非バックグラウンド部分が終了します。 このアプリに関連付けられたバックグラウンド タスクは取り消されます。 アプリの状態が確認され、アプリがまだ実行中の場合はこのテストに合格しません。

### <a name="corrective-action"></a>問題への対応

アプリに取り消しハンドラーを追加します。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/library/windows/apps/Mt299103)」をご覧ください。

## <a name="app-count"></a>アプリ カウント

アプリ パッケージ (APPX、アプリ バンドル) に 1 つのアプリケーションが含まれていることを確認します。 これは、キットでスタンドアロン テストに変更されました。

### <a name="background"></a>背景

このテストは、ストア ポリシーに従って実装されていました。

### <a name="test-details"></a>テストの詳細

Windows Phone 8.1 アプリの場合は、テストにより、バンドル内の appx パッケージの合計数が 512 個未満であること、バンドル内に含まれるメイン パッケージが 1 個だけであること、そしてバンドル内のメイン パッケージのアーキテクチャが ARM またはニュートラルとしてマークされていることを確認します。

Windows 10 アプリの場合は、テストでは、バンドルのバージョンのリビジョン番号が 0 に設定されていることを確認します。

### <a name="corrective-action"></a>問題への対応

アプリ パッケージとバンドルが、テストの詳細で上記の要件を満たしていることを確認します。

## <a name="app-manifest-compliance-test"></a>アプリ マニフェストの適合性のテスト

アプリ マニフェストのコンテンツをテストし、コンテンツが正しいかどうかを確認します。

### <a name="background"></a>背景

アプリ マニフェストは正しい形式でなければならない

### <a name="test-details"></a>テストの詳細

「[アプリ パッケージの要件](https://msdn.microsoft.com/library/windows/apps/Mt148525)」の説明に従って、アプリ マニフェストを調べてコンテンツが正しいかどうかを確認します。

-   **ファイル拡張子とプロトコル**

    アプリは、関連付ける必要があるファイル拡張子を宣言できます。 ただし不当に使用されると、アプリは大量のファイル拡張子 (しかも大半が使うことのない拡張子) を宣言することがあり、ユーザー エクスペリエンスが低下する可能性があります。 このテストで追加されるチェックにより、アプリに関連付けることができるファイル拡張子の数を制限できます。

-   **フレームワークの依存関係規則**

    このテストは、アプリと UWP の依存関係が適切かどうかをチェックします。 不適切な依存関係がある場合は、このテストは失敗します。

    アプリが動作する OS のバージョンと依存関係のあるフレームワークとの間に不整合がある場合は、テストは失敗します。 アプリがフレーム ワーク DLL の Preview 版を参照している場合にも、テストは失敗します。

-   **プロセス間通信 (IPC) の確認**

    このテストでは、UWP アプリがデスクトップ コンポーネントとアプリ コンテナーの外側に通信しない要件が適用されます。 プロセス間通信は、サイドローディングが行われたアプリのみを対象としています。 DesktopApplicationPath と同じ名前で [**ActivatableClassAttribute**](https://msdn.microsoft.com/library/windows/apps/BR211414) を指定しているアプリは、このテストに合格しません。

### <a name="corrective-action"></a>問題への対応

「[アプリ パッケージの要件](https://msdn.microsoft.com/library/windows/apps/Mt148525)」で説明されている要件に照らして、アプリのマニフェストを確認します。

## <a name="windows-security-features-test"></a>Windows のセキュリティ機能のテスト

### <a name="background"></a>背景

Windows 既定のセキュリティ保護を変更すると、ユーザーが危険にさらされるリスクが増大します。

### <a name="test-details"></a>テストの詳細

[BinScope Binary Analyzer](#binscope-binary-analyzer-tests) を起動して、アプリのセキュリティをテストします。

BinScope Binary Analyzer テストでは、アプリのバイナリ ファイルを検査して、攻撃や悪用に対してアプリの強度を上げるコーディングとビルドの手法をチェックします。

BinScope Binary Analyzer テストは、次のセキュリティ関連の機能が適切に使われているかをチェックします。

-   BinScope Binary Analyzer テスト
-   プライベート コードの署名

### <a name="binscope-binary-analyzer-tests"></a>BinScope Binary Analyzer テスト


[BinScope Binary Analyzer](https://www.microsoft.com/en-us/download/details.aspx?id=44995) テストは、アプリのバイナリ ファイルを検査して、攻撃や悪用からアプリを守るコーディングとビルドの手法をチェックします。

BinScope Binary Analyzer テストは、次のセキュリティ関連機能が適切に使われているかをチェックします。

-   [AllowPartiallyTrustedCallersAttribute](#binscope-1)
-   [/SafeSEH 例外処理の保護](#binscope-2)
-   [データ実行防止](#binscope-3)
-   [アドレス空間レイアウトのランダム化](#binscope-4)
-   [共有されている PE セクションの読み取り/書き込み](#binscope-5)
-   [AppContainerCheck](#appcontainercheck)
-   [ExecutableImportsCheck](#binscope-7)
-   [WXCheck](#binscope-8)

### <a name="span-idbinscope-1spanallowpartiallytrustedcallersattribute"></a><span id="binscope-1"></span>AllowPartiallyTrustedCallersAttribute

**Windows アプリ認定キットのエラー メッセージ:** APTCACheck Test failed

AllowPartiallyTrustedCallersAttribute (APTCA) 属性を使うと、署名されたアセンブリで、部分的に信頼されたコードから完全に信頼されたコードにアクセスできます。 アセンブリに APTCA 属性を適用すると、アセンブリが有効な間は、部分的に信頼された呼び出し元からそのアセンブリにアクセスできます。これにより、セキュリティが侵害されるおそれがあります。

**アプリがこのテストに合格しなかった場合の対処方法**

プロジェクトに必要で、リスクをよく認識している場合を除いて、厳密な名前の付いたアセンブリでは APTCA 属性を使わないでください。 APTCA 属性を使う必要がある場合は、すべての API が適切なコード アクセス セキュリティ要求によって保護されていることを確認します。 アセンブリがユニバーサル Windows プラットフォーム (UWP) アプリの一部となっている場合は、APTCA の影響はありません。

**注釈**

このテストは、マネージ コード (C#、.NET など) でのみ実行されます。

### <a name="span-idbinscope-2spansafeseh-exception-handling-protection"></a><span id="binscope-2"></span>/SafeSEH 例外処理の保護

**Windows アプリ認定キットのエラー メッセージ:** SafeSEHCheck Test failed

例外ハンドラーは、アプリがゼロ除算エラーなどの例外的な状況に陥った場合に実行されます。 関数が呼び出されると例外ハンドラーのアドレスがスタックに格納されるため、悪意のあるソフトウェアがスタックを上書きしようとした場合は、バッファー オーバーフローによる攻撃を受けやすくなることがあります。

**アプリがこのテストに合格しなかった場合の対処方法**

アプリをビルドするときに、リンカー コマンドの /SAFESEH オプションを有効にします。 Visual Studio のリリース構成では、既定で、このオプションが有効になっています。 このオプションが、アプリのすべての実行可能モジュールに対するビルド手順で有効になっていることを確認します。

**注釈**

このテストは、64 ビット バイナリまたは ARM チップセット バイナリでは実行されません。例外ハンドラーのアドレスがスタックに格納されないためです。

### <a name="span-idbinscope-3spandata-execution-prevention"></a><span id="binscope-3"></span>データ実行防止

**Windows アプリ認定キットのエラー メッセージ:** NXCheck Test failed

このテストでは、データ セグメントに格納されたコードが、アプリで実行されないことを確認します。

**アプリがこのテストに合格しなかった場合の対処方法**

アプリをビルドするときに、リンカー コマンドの /NXCOMPAT オプションを有効にします。 Data Execution Prevention (DEP) をサポートするリンカー バージョンでは、既定で、このオプションが有効になっています。

**注釈**

DEP 対応の CPU でアプリをテストし、DEP の結果として見つかったエラーをすべて修正することをお勧めします。

### <a name="span-idbinscope-4spanaddress-space-layout-randomization"></a><span id="binscope-4"></span>アドレス空間レイアウトのランダム化

**Windows アプリ認定キットのエラー メッセージ:** DBCheck Test failed

アドレス空間レイアウトのランダム化 (ASLR) を使うと、実行可能なイメージがメモリの予測不可能な場所に読み込まれます。これにより、特定の仮想アドレスにプログラムを読み込むことを想定している悪意のあるソフトウェアは、計画どおりに動作しにくくなります。 アプリとアプリで使うすべてのコンポーネントは、ASLR をサポートする必要があります。

**アプリがこのテストに合格しなかった場合の対処方法**

アプリをビルドするときに、リンカー コマンドの /DYNAMICBASE オプションを有効にします。 アプリで使うすべてのモジュールでも、このリンカー オプションを使っていることを確認します。

**注釈**

通常、ASLR がパフォーマンスに影響を与えることはありません。 ただし、場合によっては、32 ビット システムでわずかにパフォーマンスが向上することがあります。 多くの画像がさまざまなメモリに読み込まれた非常に密集したシステムでは、パフォーマンスが低下する可能性があります。

このテストは、C や C++ などのアンマネージ言語で記述されたアプリでのみ実行されます。

### <a name="span-idbinscope-5spanreadwrite-shared-pe-section"></a><span id="binscope-5"></span>共有されている PE セクションの読み取り/書き込み

**Windows アプリ認定キットのエラー メッセージ:** SharedSectionsCheck Test failed.

共有されている書き込み可能なセクションがあるバイナリ ファイルは、セキュリティの脅威です。 共有する書き込み可能なセクションを含むアプリは、必須の場合を除き、ビルドしないでください。 [**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) または [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) を使って適切に保護された共有メモリ オブジェクトを作成します。

**アプリがこのテストに合格しなかった場合の対処方法**

アプリからすべての共有セクションを削除し、適切なセキュリティ属性を指定した [**CreateFileMapping**](https://msdn.microsoft.com/library/windows/desktop/Aa366537) または [**MapViewOfFile**](https://msdn.microsoft.com/library/windows/desktop/Aa366761) を呼び出して共有メモリ オブジェクトを作成し、アプリをリビルドします。

**注釈**

このテストは、C や C++ などのアンマネージ言語で記述されたアプリでのみ実行されます。

### <a name="appcontainercheck"></a>AppContainerCheck

**Windows アプリ認定キットのエラー メッセージ:** AppContainerCheck Test failed.

AppContainerCheck は、実行可能なバイナリの PE (Portable Executable) ヘッダーに **appcontainer** ビットが設定されているかを検証します。 すべての .exe ファイルとすべてのアンマネージ DLL で **appcontainer** ビットが設定されていないと、アプリは正しく動作しません。

**アプリがこのテストに合格しなかった場合の対処方法**

ネイティブの実行可能ファイルでテストが不合格になった場合は、最新のコンパイラとリンカーを使ってファイルをビルドし、リンカーで */appcontainer* フラグを使います。

マネージ実行可能ファイルには、テストが失敗した場合は、最新のコンパイラとリンカー、Microsoft Visual Studio などを使用した UWP アプリを構築することを確認します。

**注釈**

このテストは、すべての .exe ファイル、およびアンマネージ DLL で実行されます。

### <a name="span-idbinscope-7spanexecutableimportscheck"></a><span id="binscope-7"></span>ExecutableImportsCheck

**Windows アプリ認定キットのエラー メッセージ:** ExecutableImportsCheck Test failed.

移植可能な実行可能ファイル (PE) イメージで、実行可能コード セクションにインポート テーブルが置かれていると、このテストが不合格になります。 これは、Visual C++ リンカーの */merge* フラグを "*/merge:.rdata=.text*" に設定して、PE イメージの .rdata マージを有効にすると生じることがあります。

**アプリがこのテストに合格しなかった場合の対処方法**

インポート テーブルを実行可能コード セクションにマージしないでください。 Visual C++ リンカーの */merge* フラグをチェックして、.rdata セクションがコード セクションにマージされる設定になっていないことを確認します。

**注釈**

このテストは、純粋なマネージ アセンブリを除き、すべてのバイナリ コードで実行されます。

### <a name="span-idbinscope-8spanwxcheck"></a><span id="binscope-8"></span>WXCheck

**Windows アプリ認定キットのエラー メッセージ:** WXCheck Test failed.

このチェックでは、書き込み可能または実行可能としてマップされたページがバイナリに含まれていないことを確認します。 これが不合格になるのは、書き込み可能または実行可能なセクションがバイナリに含まれている場合と、バイナリの *SectionAlignment* が *PAGE\-SIZE* よりも小さい場合です。

**アプリがこのテストに合格しなかった場合の対処方法**

書き込み可能または実行可能なセクションがバイナリに含まれていないこと、バイナリの *SectionAlignment* の値が *PAGE\-SIZE* の値以上であることを確認します。

**注釈**

このテストは、すべての .exe ファイル、およびネイティブのアンマネージ DLL で実行されます。

書き込み可能または実行可能なセクションは、エディット コンティニュ (/ZI) を有効にしてビルドした実行可能ファイルに含まれることがあります。 エディット コンティニュを無効にすると、無効なセクションは含まれなくなります。

*PAGE\-SIZE* は実行可能ファイルの既定の *SectionAlignment* です。

### <a name="private-code-signing"></a>プライベート コードの署名

アプリ パッケージ内にプライベート コードの署名バイナリが存在するかテストします。

### <a name="background"></a>背景

プライベート コードの署名ファイルは、セキュリティが侵害された場合は、悪用される可能性があるため、プライベートにしておく必要があります。

### <a name="test-details"></a>テストの詳細

アプリ パッケージ内でプライベート署名キーを含むことを示す .pfx または .snk という拡張子を持つファイルについてテストします。

### <a name="corrective-actions"></a>問題への対応

パッケージからプライベート コードの署名キー (.pfx ファイルや .snk ファイルなど) を削除します。

## <a name="supported-api-test"></a>サポートされる API のテスト

アプリで非標準 API が使われていないかどうかをテストします。

### <a name="background"></a>背景

アプリでは、UWP アプリ (Windows ランタイムまたはサポートされている Win32 Api)、Microsoft Store の認定を受けるの Api を使用する必要があります。 このテストでは、管理されたバイナリが承認済みのプロファイル外部の機能に依存している状況も特定されます。

### <a name="test-details"></a>テストの詳細

-   アプリ パッケージ内の各バイナリがバイナリのインポート アドレス テーブルをチェックして、UWP アプリの開発のサポートされていない Win32 API に依存関係がないことを確認します。
-   アプリ パッケージ内の管理された各バイナリが承認済みのプロファイル外部の機能に依存していないことを確認します。

### <a name="corrective-actions"></a>問題への対応

アプリが、デバッグ用のビルドではなくリリース用ビルドとしてコンパイルされていることを確認します。

> **注:** アプリが[UWP アプリ用の Api](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx)のみを使っている場合でも、デバッグ用ビルドのアプリにはこのテストは失敗します。

[UWP アプリ用 API](https://msdn.microsoft.com/library/windows/apps/xaml/bg124285.aspx)ではないアプリを使用して、API を識別するエラー メッセージを確認します。

> **注:** 構成が UWP アプリの場合のみ、Windows SDK の Api を使っている場合でも、デバッグ構成で構築された C++ アプリにはこのテストは失敗します。 詳しくは、 [UWP アプリでの Windows api の代替手段](http://go.microsoft.com/fwlink/p/?LinkID=244022)を表示します。

## <a name="performance-tests"></a>パフォーマンスのテスト

軽快かつ柔軟なユーザー エクスペリエンスとなるように、アプリはユーザー操作とシステム コマンドに速やかに応答する必要があります。

テストを実行するコンピューターの特性がテスト結果に影響することがあります。 アプリ認定のパフォーマンス テストのしきい値は、ユーザーの高速で滑らかなエクスペリエンスへの期待が低電力コンピューターでも満たされるように設定されています。 アプリのパフォーマンスを確認するには、アプリを低電力コンピューター (たとえば画面の解像度が 1366 x 768 またはそれ以上で、回転式ハード ドライブを搭載した Intel Atom プロセッサ ベースのコンピューター) 上でテストすることをお勧めします。

### <a name="bytecode-generation"></a>バイトコードの作成

JavaScript の実行時間を短縮するパフォーマンスの最適化として、アプリの展開時、末尾が .js 拡張子の JavaScript ファイルによりバイトコードが生成されます。 そのため、JavaScript 操作の開始時間と実行継続時間が大幅に短縮されます。

### <a name="test-details"></a>テストの詳細

アプリの展開をチェックして、すべての .js ファイルがバイトコードに変換されたことをチェックします。

### <a name="corrective-action"></a>問題への対応

このテストに合格しなかった場合は、問題の対処に際して次の点を考慮します。

-   イベント ログが有効になっていることを確認します。
-   すべての JavaScript ファイルが構文的に正しいことを確認します。
-   以前のバージョンのアプリがすべてアンインストールされていることを確認します。
-   識別されたファイルをアプリ パッケージから除外します。

### <a name="optimized-binding-references"></a>最適化されたバインディング参照

バインディングを使うときは、メモリ使用率を最適化するために WinJS.Binding.optimizeBindingReferences を true に設定する必要があります。

### <a name="test-details"></a>テストの詳細

WinJS.Binding.optimizeBindingReferences の値を確認します。

### <a name="corrective-action"></a>問題への対応

アプリの JavaScript で WinJS.Binding.optimizeBindingReferences を "**true**" に設定します。

## <a name="app-manifest-resources-test"></a>アプリ マニフェストのリソースのテスト

### <a name="app-resources-validation"></a>アプリ リソースの検証

アプリのマニフェストで宣言されている文字列や画像に誤りがある場合は、そのアプリはインストールされない可能性があります。 これらのエラーがあるアプリをインストールすると、アプリが使用するアプリのロゴなどの画像が適切に表示されません。

### <a name="test-details"></a>テストの詳細

アプリ マニフェストで定義されているリソースを調べて、それらのリソースが存在し有効であることを確認します。

### <a name="corrective-action"></a>問題への対応

次の表をガイダンスとして使います。

<table>
<tr><th>エラー メッセージ</th><th>コメント</th></tr>
<tr><td>
<p>The image {image name} defines both Scale and TargetSize qualifiers; you can define only one qualifier at a time. (イメージ {image name} には Scale 修飾子と TargetSize 修飾子が定義されていますが、一度に定義可能な修飾子は 1 つだけです。)</p>
</td><td>
<p>さまざまな解像度に合わせて画像をカスタマイズできます。</p>
<p>実際のメッセージでは、{imageName} にエラーの発生した画像の名前が入ります。</p>
<p> 各画像で Scale と TargetSize のいずれかが修飾子として定義されていることを確認します。</p>
</td></tr>
<tr><td>
<p>The image {image name} failed the size restrictions. (イメージ {image name} がサイズ制限を超えました。)</p>
</td><td>
<p>すべてのアプリ画像が適切なサイズ制限に従っていることを確認します。</p>
<p>実際のメッセージでは、{imageName} にエラーの発生した画像の名前が入ります。</p>
</td></tr>
<tr><td>
<p>The image {image name} is missing from the package. (イメージ {image name} がパッケージ内に見つかりません。)</p>
</td><td>
<p>必要な画像がありません。</p>
<p>実際のメッセージでは、{image name} に見つからない画像の名前が入ります。</p>
</td></tr>
<tr><td>
<p>The image {image name} is not a valid image file. (イメージ {image name} は有効なイメージ ファイルではありません。)</p>
</td><td>
<p>すべてのアプリ画像が適切なファイルの種類の制限に従っていることを確認します。</p>
<p>実際のメッセージでは、{image name} に画像の色として無効な値が入ります。</p>
</td></tr>
<tr><td>
<p>The image "BadgeLogo" has an ABGR value {value} at position (x, y) that is not valid. (画像 "BadgeLogo" の位置 (x, y) の ABGR 値 {value} が無効です。) The pixel must be white (##FFFFFF) or transparent (00######) (このピクセルは、白 (##FFFFFF) または透明 (00######) である必要があります。)</p>
</td><td>
<p>バッジ ロゴはロック画面でアプリを識別するためにバッジ通知の横に表示される画像です。 この画像はモノクロである必要があります (含めることができるのは白または透明のピクセルだけです)。</p>
<p>実際のメッセージでは、{value} に画像の色として無効な値が入ります。</p>
</td></tr>
<tr><td>
<p>The image “BadgeLogo” has an ABGR value {value} at position (x, y) that is not valid for a high-contrast white image. (画像 "BadgeLogo" の位置 (x, y) にハイコントラストの白い画像には無効な ABGR 値 {value} があります。) The pixel must be (##2A2A2A) or darker, or transparent (00######). (ピクセルは (##2A2A2A) か、それより暗いか、透明 (00######) である必要があります。)</p>
</td><td>
<p>バッジ ロゴはロック画面でアプリを識別するためにバッジ通知の横に表示される画像です。   "ハイコントラスト 白" ではバッジ ロゴが白い背景に表示されるため、通常のバッジ ロゴの濃いバージョンを使う必要があります。 "ハイコントラスト 白" でバッジ ロゴに含めることができるピクセルは、(##2A2A2A) より濃い色か透明のピクセルだけです。</p>
<p>実際のメッセージでは、{value} に画像の色として無効な値が入ります。</p>
</td></tr>
<tr><td>
<p>The image must define at least one variant without a TargetSize qualifier. (画像では、TargetSize 修飾子がないバージョンが少なくとも 1 つ定義されている必要があります。) It must define a Scale qualifier or leave Scale and TargetSize unspecified, which defaults to Scale-100. (Scale 修飾子が定義されているか、または Scale と TargetSize が指定されていないままである必要があり、既定では Scale-100 です。)</p>
</td><td>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/dn958435.aspx">UWP アプリ用レスポンシブ デザイン 101</a>」と「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">アプリ リソースのガイドライン</a>」をご覧ください。</p>
</td></tr>
<tr><td>
<p>The package is missing a "resources.pri" file. (パッケージに "resources.pri" ファイルがありません。)</p>
</td><td>
<p>アプリ マニフェストにローカライズ可能なコンテンツがある場合は、アプリのパッケージに有効な resources.pri ファイルが含まれていることを確認します。</p>
</td></tr>
<tr><td>
<p>The "resources.pri" file must contain a resource map with a name that matches the package name {package full name} ("resources.pri" ファイルには、パッケージ名 {package full name} と名前が一致するリソース マップが含まれている必要があります。)</p>
</td><td>
<p>このエラーが表示される場合は、マニフェストが変更され、resources.pri 内のリソース マップの名前がマニフェストのパッケージ名と一致しなくなった可能性があります。</p>
<p>実際のメッセージでは、{package full name} には resources.pri に含まれている必要があるパッケージ名が入ります。</p>
<p>この問題を解決するには、resources.pri をリビルドする必要があります。その場合は、アプリのパッケージをリビルドするのが最も簡単です。</p>
</td></tr>
<tr><td>
<p>The "resources.pri" file must not have AutoMerge enabled. ("resources.pri" ファイルは AutoMerge を有効にしないでください。)</p>
</td><td>
<p>MakePRI.exe では、<strong>AutoMerge</strong> というオプションがサポートされています。 <strong>AutoMerge</strong> の規定値は "<strong>off</strong>" です。 オンにすると、<strong>AutoMerge</strong> が実行時にアプリの言語パックを単一の resources.pri にマージします。 これは、Microsoft Store を通じて配布する予定のアプリの推奨されません。 Microsoft Store で配布するアプリの resources.pri は、アプリのパッケージのルートし、アプリがサポートする言語のリファレンスをすべて含める必要があります。</p>
</td></tr>
<tr><td>
<p>The string {string} failed the max length restriction of {number} characters. (文字列 {string} が {number} 文字の最大文字数の制限を満たしていません。)</p>
</td><td>
<p>「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">アプリ パッケージの要件</a>」をご覧ください。</p>
<p>実際のメッセージでは、{string} が問題の文字列に置き換わり、{number} に最大文字数が入ります。</p>
</td></tr>
<tr><td>
<p>The string {string} must not have leading/trailing whitespace. (文字列 {string} の先頭または末尾を空白にすることはできません。)</p>
</td><td>
<p>アプリ マニフェストの要素のスキーマでは、先頭および末尾の空白は許可されていません。</p>
<p>実際のメッセージでは、{string} が問題の文字列に置き換わります。</p>
<p>resources.pri のマニフェスト フィールドのローカライズされた値において、先頭または末尾にスペースが挿入されていないことを確認します。</p>
</td></tr>
<tr><td>
<p>The string must be non-empty (greater than zero in length) (文字列を空にすることはできません (文字数が 0 より大きい必要があります)。)</p>
</td><td>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/mt148525.aspx">アプリ パッケージの要件</a>」をご覧ください。</p>
</td></tr>
<tr><td>
<p>There is no default resource specified in the "resources.pri" file. ("resources.pri" ファイルで指定された既定のリソースがありません。)</p>
</td><td>
<p>詳しくは、「<a href="https://msdn.microsoft.com/library/windows/apps/xaml/hh465241.aspx">アプリ リソースのガイドライン</a>」をご覧ください。</p>
<p>既定のビルド構成では、Visual Studio はバンドル生成時に 200% スケールの画像リソースのみをアプリ パッケージ内に組み込み、その他のリソースはリソース パッケージ内に配置します。 200% スケールの画像リソースを組み込むか、または持っているリソースを組み込むようにプロジェクトを構成してください。</p>
</td></tr>
<tr><td>
<p>There is no resource value specified in the "resources.pri" file. ("resources.pri" ファイルに指定されたリソース値がありません。)</p>
</td><td>
<p>resources.pri でアプリ マニフェストの有効なリソースが定義されていることを確認します。</p>
</td></tr>
<tr><td>
<p>The image file {filename} must be smaller than 204800 bytes.\*\* (イメージ ファイル {filename} は、204,800 バイト未満である必要があります。)</p>
</td><td>
<p>指定の画像のサイズを小さくします。</p>
</td></tr>
<tr><td>
<p>The {filename} file must not contain a reverse map section.\*\* ({filename} ファイルには、リバース マップ セクションを含めることはできません。)</p>
</td><td>
<p>逆マップは Visual Studio の F5 デバッグ時に makepri.exe を呼び出すと生成されますが、pri ファイルの生成時に /m パラメーターなしで makepri.exe を実行すると削除することができます。</p>
</td></tr>
<tr><td colspan="2">
<p>\*\* Windows 8.1 用の Windows アプリ認定キット 3.3 に追加されたテストであり、そのバージョン以降のキットを使う場合にのみ適用されます。</p>
</td></tr>
</table>



 

### <a name="branding-validation"></a>ブランドの検証

UWP アプリは、完成していて完全に機能するされる予定です。 既定の画像 (テンプレートまたは SDK サンプルの画像) を使ったアプリは、ユーザー エクスペリエンスが貧弱であることを示しているため、ストア カタログであまり識別されない可能性があります。

### <a name="test-details"></a>テストの詳細

このテストは、アプリで使われている画像が SDK サンプルまたは Visual Studio の既定の画像でないことを検証します。

### <a name="corrective-actions"></a>問題への対応

既定の画像を、もっとアプリを明確に表すものに置き換えます。

## <a name="debug-configuration-test"></a>デバッグ構成のテスト

アプリをテストして、デバッグ用のビルドでないことを確認します。

### <a name="background"></a>背景

Microsoft Store の認定を受けるアプリにコンパイルせずデバッグ用とデバッグ版の実行可能ファイルを参照しないようにする必要があります。 また、アプリがこのテストに合格するよう最適化されたコードをビルドする必要もあります。

### <a name="test-details"></a>テストの詳細

アプリをテストして、デバッグ用のビルドでないことと、どのデバッグ用のフレームワークにもリンクされていないことを確認します。

### <a name="corrective-actions"></a>問題への対応

-   Microsoft Store に提出する前に、リリース用ビルドとして、アプリをビルドします。
-   適切なバージョンの .NET フレームワークがインストールされていることを確認します。
-   アプリがフレームワークのデバッグ バージョンにリンクされていないことと、リリース バージョンで構築されたことを確認します。 このアプリに .NET コンポーネントが含まれている場合は、適切なバージョンの .NET Framework がインストールされていることを確認します。

## <a name="file-encoding-test"></a>ファイル エンコードのテスト

### <a name="utf-8-file-encoding"></a>UTF-8 ファイル エンコード

### <a name="background"></a>背景

バイトコード キャッシュを活用して特定の実行時エラー状態を避けるには、HTML、CSS、JavaScript の各ファイルが、対応するバイト オーダー マーク (BOM) を持つ UTF-8 形式でエンコードされている必要があります。

### <a name="test-details"></a>テストの詳細

アプリ パッケージのコンテンツをテストし、正しいファイル エンコードが使われていることを確認します。

### <a name="corrective-action"></a>問題への対応

Visual Studio で、影響を受けるファイルを開き、**[ファイル]** メニューの **[名前を付けて保存]** を選択します。 **[保存]** ボタンの横のドロップダウン コントロールを選び、**[エンコード付きで保存]** をクリックします。 **[保存オプションの詳細設定]** ダイアログ ボックスで、Unicode (シグネチャを含む UTF-8) オプションを選び、**[OK]** をクリックします。

## <a name="direct3d-feature-level-test"></a>Direct3D の機能レベルのテスト

### <a name="direct3d-feature-level-support"></a>Direct3D の機能レベルのサポート

Microsoft Direct3D アプリをテストして、以前のグラフィックス ハードウェアを搭載したデバイスでクラッシュしないことを確認します。

### <a name="background"></a>背景

Microsoft Store では、すべてのアプリケーションが Direct3D を使用して正しくレンダリングされるか、機能レベル 9 \-1 グラフィックス カードで適切に失敗する必要があります。

アプリのインストール後にユーザーのデバイスのグラフィックス ハードウェアがユーザーによって変更されることもあるため、最小機能レベルを 9\-1 よりも高くする場合は、現在のハードウェアが最小要件を満たしているかどうかをアプリの起動時に検出するようにしなければなりません。 最小要件が満たされていない場合は、アプリでは Direct3D の要件に関する詳しいメッセージをユーザーに表示する必要があります。 また、アプリが互換性のないデバイスでダウンロードされた場合は、起動時にそれを検出し、要件について説明するメッセージをユーザーに表示する必要もあります。

### <a name="test-details"></a>テストの詳細

このテストは、アプリが機能レベル 9\-1 で正確にレンダリングされるかどうかを検証します。

### <a name="corrective-action"></a>問題への対応

高い機能レベルで実行されると予想される場合でも、アプリが Direct3D 機能レベル 9\-1 で正しくレンダリングされることを確認します。 詳しくは、「[機能レベルが異なる Direct3D の開発](http://go.microsoft.com/fwlink/p/?LinkID=253575)」をご覧ください。

### <a name="direct3d-trim-after-suspend"></a>中断後の Direct3D トリミング

> **注:** このテストは、Windows 8.1 以降に開発された UWP アプリにのみ適用されます。

### <a name="background"></a>背景

アプリが Direct3D デバイスで [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) を呼び出さない場合は、アプリは前の 3D 作業に割り当てられたメモリを解放しません。 この結果、システムのメモリ不足のためにアプリが終了するリスクが増加します。

### <a name="test-details"></a>テストの詳細

アプリが d3d 要件を満たしているかどうか、そして中断コールバック時に新しい [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API を呼び出すかどうかを確認します。

### <a name="corrective-action"></a>問題への対応

アプリは中断されそうになった時は常に [**Trim**](https://msdn.microsoft.com/library/windows/desktop/Dn280345) インターフェイスで [**IDXGIDevice3**](https://msdn.microsoft.com/library/windows/desktop/Dn280346) API を呼び出す必要があります。

## <a name="app-capabilities-test"></a>アプリ機能のテスト

### <a name="special-use-capabilities"></a>特殊な用途の機能

### <a name="background"></a>背景

特殊な用途の機能は、特殊なシナリオ向けの機能です。 会社アカウントだけがこれらの機能を使うことができます。

### <a name="test-details"></a>テストの詳細

アプリが次のいずれかの機能を宣言することを検証します。

-   EnterpriseAuthentication
-   SharedUserCertificates
-   DocumentsLibrary

これらの機能のいずれかが宣言される場合は、テストにより警告がユーザーに表示されます。

### <a name="corrective-actions"></a>問題への対応

アプリが必要としない場合は、特殊な用途の機能を削除することを検討してください。 さらに、これらの機能は、追加の登録ポリシー レビューの対象となります。

## <a name="windows-runtime-metadata-validation"></a>Windows ランタイム メタデータ検証

### <a name="background"></a>背景

アプリに付属するコンポーネントが、UWP 型システムに準拠していることを確認します。

### <a name="test-details"></a>テストの詳細

パッケージの **.winmd** ファイルが UWP 規則に準拠していることを確認します。

### <a name="corrective-actions"></a>問題への対応

-   **ExclusiveTo 属性のテスト:** UWP クラスに別の ExclusiveTo クラスとしてマークされたインターフェイスが実装されていないことを確認します。
-   **型の場所のテスト:** UWP のすべての型のメタデータが、アプリ パッケージで最も長い名前空間対応の名前を持つ winmd ファイルにあることを確認します。
-   **型名の大文字小文字の区別のテスト:** すべての UWP 型のアプリ パッケージ内に大文字と小文字が区別されない一意の名前が存在することを確認します。 また、UWP 型名が、アプリ パッケージ内で名前空間名として使われていないことも確認します。
-   **型名の正確性のテスト:** グローバル名前空間または Windows の最上位名前空間に UWP 型がないことを確認します。
-   **一般的なメタデータの正確性のテスト:** 型の生成に使っているコンパイラが UWP の仕様に従って最新の状態になっていることを確認します。
-   **プロパティのテスト:** UWP クラスのすべてのプロパティに get メソッドがあることを確認します (set メソッドは省略可能です)。 UWP 型のすべてのプロパティについて、get メソッドの戻り値の型が set メソッドの入力パラメーターの型に一致することを確認します。

## <a name="package-sanity-tests"></a>パッケージ サニティ テスト

### <a name="platform-appropriate-files-test"></a>プラットフォーム対応ファイル テスト

混在するバイナリをインストールするアプリは、ユーザーのプロセッサ アーキテクチャによってはクラッシュしたり、正しく動作しない場合があります。

### <a name="background"></a>背景

このテストでは、アーキテクチャが競合していないか、アプリ パッケージのバイナリを検証します。 アプリ パッケージには、マニフェストに指定されたプロセッサ アーキテクチャで使用できないバイナリを含めることができません。 サポートされていないバイナリが含まれると、アプリがクラッシュしたり、アプリのパッケージ サイズが不必要に大きくなったりする可能性があります。

### <a name="test-details"></a>テストの詳細

アプリ パッケージのプロセッサ アーキテクチャ宣言と相互参照される場合に、各ファイルの PE ヘッダー内のビット "bitness" が適切かどうかを検証します。

### <a name="corrective-action"></a>問題への対応

アプリ マニフェストで指定されたアーキテクチャでサポートされるファイルのみをアプリ パッケージが含むことを確認するために、次のガイドラインに従ってください。

-   アプリのターゲット プロセッサ アーキテクチャがニュートラル プロセッサ タイプの場合、アプリ パッケージは、x86、x64、または ARM のバイナリ タイプまたはイメージ タイプのファイルを含むことはできません。

-   アプリのターゲット プロセッサ アーキテクチャが x86 プロセッサ タイプの場合、アプリ パッケージは、x86 バイナリ タイプまたはイメージ タイプのファイルのみを含む必要があります。 パッケージが x64 ないし ARM バイナリ形式またはイメージ形式を含む場合は、アプリはテストに合格しません。

-   アプリのターゲット プロセッサ アーキテクチャが x64 プロセッサ タイプの場合、アプリ パッケージは、x64 バイナリ タイプまたはイメージ タイプのファイルを含む必要があります。 この場合は、パッケージに x86 ファイルを含めることもできますが、主なアプリ エクスペリエンスでは x64 バイナリを使ってください。

    ただし、パッケージが ARM バイナリ タイプまたはイメージ タイプのファイルを含む場合、または x86 バイナリ タイプまたはイメージ タイプのファイルのみを含む場合、パッケージはテストに合格しません。

-   アプリのターゲット プロセッサ アーキテクチャが ARM プロセッサ タイプの場合、アプリ パッケージは、ARM バイナリ タイプまたはイメージ タイプのファイルのみを含む必要があります。 パッケージが x64 または x86 バイナリ形式またはイメージ形式のファイルを含む場合は、パッケージはテストに合格しません。

### <a name="supported-directory-structure-test"></a>サポートされるディレクトリ構造のテスト

アプリケーションがインストールの一部として MAX\-PATH より長いサブディレクトリを作成しないことを検証します。

### <a name="background"></a>背景

OS コンポーネント (Trident、WWAHost など) は、ファイル システム パスの MAX\-PATH に内部的に制限され、長いパスでは正しく機能しません。

### <a name="test-details"></a>テストの詳細

アプリのインストール ディレクトリ内のどのパスも MAX\-PATH を超えていないことを確認します。

### <a name="corrective-action"></a>問題への対応

短いディレクトリ構造やファイル名にします。

## <a name="resource-usage-test"></a>リソース使用率テスト

### <a name="winjs-background-task-test"></a>WinJS バックグラウンド タスクのテスト

WinJS バックグラウンド タスクのテストは、JavaScript アプリに適切な close ステートメントがあるため、アプリがバッテリを消費しないことを確認します。

### <a name="background"></a>背景

JavaScript のバックグラウンド タスクがあるアプリは、バックグラウンド タスクの最後のステートメントとして Close() を呼び出す必要があります。 これがないアプリの場合は、システムがコネクト スタンバイ モードに戻らないため、バッテリを消耗する可能性があります。

### <a name="test-details"></a>テストの詳細

マニフェストで指定されたバックグラウンド タスク ファイルがアプリにない場合、テストに合格します。 それ以外の場合は、テストはアプリ パッケージで指定された JavaScript バックグラウンド タスク ファイルを解析し、Close() ステートメントを探します。 見つかった場合はテストに合格します。見つからない場合はテストに合格しません。

### <a name="corrective-action"></a>問題への対応

バックグラウンドの JavaScript コードを更新して、Close() を正しく呼び出します。


## <a name="related-topics"></a>関連トピック

* [Windows デスクトップ ブリッジ アプリのテスト](windows-desktop-bridge-app-tests.md)
* [Microsoft Store ポリシー](https://msdn.microsoft.com/library/windows/apps/Dn764944)
 
