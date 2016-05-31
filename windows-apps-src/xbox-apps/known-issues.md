---
author: Mtoepke
title: Xbox One Developer Preview の UWP の既知の問題
description: 
area: Xbox
---

# Xbox Developer Preview の UWP の既知の問題

このトピックでは、Xbox Developer Preview の UWP の既知の問題について説明します。 
この開発者プレビューについて詳しくは、「[Xbox One の UWP](index.md)」をご覧ください。 

\[API リファレンス トピックのリンクからこのページを見つけた、ユニバーサル デバイス ファミリの API の情報を探している方は、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/?LinkID=760755)」をご覧ください。\]

Xbox Developer Preview のシステム更新プログラムには、実験的な初期プレリリース版のソフトウェアが含まれています。 
このため、一部の人気ゲームやアプリが想定どおりに動作しなかったり、クラッシュやデータの損失が発生する可能性があります。 
開発者プレビューへの参加を終了する場合は、本体を出荷時の設定にリセットするため、ゲーム、アプリ、コンテンツをすべて再インストールする必要があります。

つまり、すべての開発者ツールと API が開発者の期待どおりに機能するわけではありません。 
また、最終リリース向けのすべての機能が含まれているわけでも、リリース品質に到達しているわけでもありません。 
**特に、このプレビューのシステム パフォーマンスは、最終リリースのシステム パフォーマンスを反映していません。**

以降に、このリリースで発生する可能性のある既知の問題を示していますが、すべての問題は網羅されていません。 

**お客様からのフィードバックは重要ですので**、問題が見つかりましたら[ユニバーサル Windows アプリの開発](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/home?forum=wpdevelop)フォーラムでご報告ください。 

行き詰まった場合は、このトピックの情報をお読みください。「[よく寄せられる質問](frequently-asked-questions.md)」を利用することも、フォーラムに質問を投稿することもできます。


## ゲームの開発

### x86 と x64

今年後半のリリースまでは、x86 と x64 の両方がサポートされ、このプレビューでは、x86 がサポートされます。 
ただし、これまでに x64 に対して多くのテストが行われているため (現在、コンソールで実行されている Xbox のシェルとすべてのアプリは x64 です)、プロジェクトで x64 を使用することをお勧めします。 
これは、特にゲームに当てはまります。

x86 を使用する場合、問題が見つかったらフォーラムでご報告ください。

このページの「[ビルドの種類を切り替えると展開が失敗する可能性がある](known-issues.md#switching-build-flavors-can-cause-deployment-failures)」もご覧ください。

### ゲーム エンジン

いくつかの一般的なゲーム エンジンをテストしていますが、すべてのエンジンはテストしていません。このプレビューのテスト カバレッジは包括的なものではありません。 
実際のメリットはケースによって異なります。 

次のゲーム エンジンは動作が確認されています。
* [Construct 2](https://www.scirra.com/)

これ以外にも動作するエンジンがある可能性があります。 お客様からのフィードバックは重要です。 
見つかった問題をフォーラムでご報告ください。

### DirectX 12 のサポート

Xbox One の UWP は、DirectX 11 の機能レベル 10 をサポートしています。 
現時点では DirectX 12 はサポートされていません。 
Xbox One は、従来のすべてのゲーム コンソールと同じように、その潜在的な機能を最大限に利用するために特定の SDK を必要とする特殊なハードウェアです。 
Xbox One のハードウェアの機能を最大限に利用する必要があるゲームを開発している場合、[ID@XBOX](http://www.xbox.com/en-us/Developers/id) プログラムに登録することで、DirectX 12 のサポートを含む SDK にアクセスできます。

### Xbox One Developer Preview では Windows 10 にゲームをストリーム配信できない

コンソールで Xbox One Developer Preview をアクティブ化すると、コンソールがリテール モードに設定されている場合でも、Xbox One から Windows 10 上の Xbox アプリにゲームをストリーム配信できなくなります。 ゲームのストリーム配信機能を復元するには、開発者プレビューから離れる必要があります。

### テレビのセーフ エリアに関する既知の問題

既定では、Xbox 上の UWP アプリの表示領域は、テレビのセーフ エリアによって挿入される必要があります。 ただし、Xbox One Developer Preview には、テレビのセーフ エリアが [_offset_, _offset_] ではなく [0, 0] で開始されるという既知のバグがあります。

テレビのセーフ エリアについて詳しくは、[https://msdn.microsoft.com/windows/uwp/input-and-devices/designing-for-tv](https://msdn.microsoft.com/windows/uwp/input-and-devices/designing-for-tv) をご覧ください。 

この問題に対処するための最も簡単な方法として、次の JavaScript の例に示すように、テレビのセーフ エリアを無効にします。

    var applicationView = Windows.UI.ViewManagement.ApplicationView.getForCurrentView();

    applicationView.setDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.useCoreWindow);

### マウス モードがまだサポートされていない

[https://msdn.microsoft.com/en-us/windows/uwp/input-and-devices/designing-for-tv] (https://msdn.microsoft.com/en-us/windows/uwp/input-and-devices/designing-for-tv?f=255&MSPPError=-2147217396#mouse-mode) トピックに説明されている_マウス モード_機能は Xbox One Developer Preview でサポートされていません。

## Xbox One 上の UWP アプリとゲームのシステム リソース

Xbox One で実行されている UWP アプリとゲームはシステムやその他のアプリとリソースを共有するため、システムによって、1 つのゲームやアプリで利用できるリソースが制御されます。 
これにより、メモリまたはパフォーマンスに問題が発生することがあります。 
詳しくは、「[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)」をご覧ください。


## 従来のソケットを使用するネットワーク

この開発者プレビューでは、従来の TCP/UDP ソケット (WinSock、Windows.Networking.Sockets) を使用するコンソールからの入力方向と出力方向のネットワーク アクセスが利用できません。 
開発者は、引き続き HTTP と WebSocket を使用できます。 


## UWP API カバレッジ

このプレビューの Xbox では、すべての UWP API が意図したとおりに機能するわけではありません。 
動作しないことが確認されている API の一覧については、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkId=760755)」をご覧ください。 
他の API に問題が見つかった場合は、フォーラムでご報告ください。 

## XAML コントロールは Xbox One のシェルのコントロールに似ていない、または同じように機能しない

この開発者プレビューでは、XAML コントロールは最終的な形態ではありません。 特に、次の点で異なります。
* ゲームパッドの X 軸 Y 軸両方向のナビゲーションは、すべてのコントロールに対して確実に機能するわけではありません。
* コントロールは、Xbox のシェルのコントロールに似ていません。 この相違点には、コントロールのフォーカス用の四角形が含まれます。
* コントロール間を移動しても、"ナビゲーション サウンド" は自動的に鳴りません。

これらの問題については、将来の開発者プレビューで対応します。

## Visual Studio と展開の問題

### ビルドの種類を切り替えると展開が失敗する可能性がある

デバッグ ビルドとリリース ビルドの切り替え、x86 と x64 の切り替え、または管理ビルドと .Net ネイティブ ビルドの切り替えが展開の失敗を引き起こす場合があります。 

このプレビューでこれらの問題を回避する最も簡単な方法は、デバッグ ビルドで 1 つのアーキテクチャを使用し続けることです。 

この問題が発生した場合、通常、Xbox One のコレクション アプリからアプリをアンインストールすると問題が解決します。

> **注**
            &nbsp;&nbsp;Windows Device Portal (WDP) からアプリをアンインストールしても、問題は解決しません。

問題が解決しない場合は、アプリやゲームをコレクション アプリからアンインストールして、開発者モードからリテール モードに切り替えて再起動し、さらに開発者モードに戻します。

詳しくは、「[よく寄せられる質問](frequently-asked-questions.md)」の「展開の失敗を修正する」セクションをご覧ください。

### Visual Studio でアプリをデバッグしている際のアプリのアンインストールは警告なしに失敗する

WDP の “Installed Apps” ツールを介して、デバッガーで実行されているアプリをアンインストールしようとすると、アンインストールが警告なしに失敗します。 
この問題を回避するには、WDP を介してアプリを削除する前に、Visual Studio でアプリのデバッグを停止します。

### Visual Studio/Xbox の PIN のペアリングの失敗

Visual Studio と Xbox One 間の PIN のペアリングが同期しなくなる状態が発生する可能性があります。 
PIN のペアリングが失敗した場合は、Dev Home の [Remove all pairings] ボタンを使用して、Xbox One を再起動し、開発用 PC を再起動してから、再試行してください。 


## Windows Device Portal (WDP) プレビュー

### Dev Home から WDP を起動すると Dev Home がクラッシュする

Dev Home で WDP を起動するとき、ユーザー名とパスワードを入力して **[保存]** を選択すると、Dev Home がクラッシュします。 
資格情報は保存されますが、WDP は開始されません。 
Xbox One を再起動すると、WDP を開始できます。 

### Dev Home で WDP を無効にできない

Dev Home で WDP を無効にすると、WDP がオフになります。 
ただし、Xbox One を再起動すると、WDP を再開できます。 
この問題を回避するには、**[Reset and keep my games & apps]** を使用して、Xbox One に保存されている状態を削除します。 
[設定]、[システム]、[Console info & updates]、[Reset console] の順に選択し、**[Reset and keep my games & apps]** ボタンを選択します。

> **注意**
            &nbsp;&nbsp;これにより、ワイヤレス設定、ユーザー アカウント、クラウド ストレージに保存されていないゲーム進行状況など、Xbox One に保存されたすべての設定が削除されます。

> **注意**
            &nbsp;&nbsp;**[Reset and remove everything]** ボタンを押さないでください。
これにより、ゲーム、アプリ、設定とコンテンツのすべてが削除され、開発者モードが非アクティブ化され、コンソールは Developer Preview グループから削除されます。

### [Running Apps] テーブルの列が予想どおりに更新されない 

テーブルの列を並べ替えると、この問題が解決する場合があります。

### Internet Explorer 11 で WDP UI が正しく表示されない 

既定では、Internet Explorer 11 を使用している場合、ブラウザーで WDP UI が正しく表示されません。 
WDP で Internet Explorer 11 の互換表示をオフにすると、この問題を解決できます。

### WDP に移動すると証明書の警告が表示される

提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One コンソールによって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。 
[このサイトの閲覧を続行する] をクリックして、Windows Device Portal にアクセスします。

![Web サイトのセキュリティ証明書の警告](images/security_cert_warning.jpg)

## Dev Home

場合によっては、Dev Home で [Manage Windows Device Portal] オプションを選択すると、Dev Home はメッセージを表示せずに [ホーム] 画面になります。 
この問題は、コンソールの WDP インフラストラクチャのエラーによって発生します。コンソールを再起動すると、この問題を解決できます。

## 参照
- [よく寄せられる質問](frequently-asked-questions.md)
- [Xbox One の UWP](index.md)


<!--HONumber=May16_HO2-->


