---
author: drewbatgit
ms.assetid: 
description: "この記事では、アプリがバックグラウンドで実行されているときにメディアを再生する方法を示します。"
title: "バックグラウンドでのメディアの再生"
translationtype: Human Translation
ms.sourcegitcommit: c8cbc538e0979f48b657197d59cb94a90bc61210
ms.openlocfilehash: a477827553ac1780ac625deeee08d84ab638d4c2

---

# バックグラウンドでのメディアの再生
この記事では、アプリをフォアグラウンドからバックグラウンドに移動してもメディアの再生を続行できるように、アプリを構成する方法について説明します。 バックグラウンドでの再生とは、ユーザーがアプリを最小化してホーム画面に戻った後や、それ以外の方法でアプリから離れた後も、アプリでオーディオの再生を続行できることを意味します。 

バックグラウンド オーディオ再生のシナリオには次のものがあります。

-   **長時間にわたって実行されるプレイリスト:** ユーザーは、フォアグラウンド アプリを一時的に表示し、プレイリストを選んで再生を開始します。その後、プレイリストはバックグラウンドで再生を続行します。

-   **タスク スイッチャーの使用:** ユーザーは、オーディオの再生を開始するためにフォアグラウンド アプリを一時的に表示した後、タスク スイッチャーを使って別の開いているアプリに切り替えます。 ユーザーは、バックグラウンドでオーディオの再生が継続することを期待します。

この記事で説明されているバックグラウンド オーディオの実装を使うと、モバイル、デスクトップ、Xbox を含むすべての Windows デバイスで、アプリをユニバーサルに実行できます。

> [!NOTE]
> この記事のコードは、UWP の[バックグラウンド オーディオのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=800141)を基にしています。

## 1 プロセス モデルの説明
Windows 10 バージョン 1607 では、新しいシングル プロセス モデルが導入され、バックグラウンド オーディオを実現するプロセスが大幅に簡略化されました。 以前は、アプリで、フォアグラウンド アプリに加えてバックグラウンド プロセスも管理し、2 つのプロセス間の状態変更を手動で通信する必要がありました。 新しいモデルでは、アプリ マニフェストにバックグラウンド オーディオ機能を追加するだけで、アプリはバックグラウンドに移行しても、自動的にオーディオ再生を続行します。 2 つ新しいアプリケーション ライフサイクル イベント、[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) によって、バックグラウンドへの移行とバックグラウンドからの移行をアプリに通知できます。 アプリがバックグラウンドに遷移またはバックグラウンドから遷移する場合、システムによって適用されるメモリの制約が変化する場合があるため、これらのイベントを使用して現在のメモリ消費量を確認し、制限値を下回るようにリソースを解放できます。

複雑なプロセス間通信と状態の管理を排除することによって、新しいモデルでは、コードを大幅に削減し、より簡単にバックグラウンド オーディオを実装することができます。 ただし、下位互換性のために、現在のリリースでは 2 プロセス モデルも引き続きサポートされています。 詳しくは、「[従来のバックグラウンド オーディオ モデル](background-audio.md)」をご覧ください。

## バックグラウンド オーディオの要件
アプリは、アプリがバックグラウンドで実行されている場合のオーディオ再生について、以下の要件を満たしている必要があります。

* アプリ マニフェストに**バックグラウンド メディア再生**機能を追加します。その方法については、後で説明します。
* アプリで、**MediaPlayer** のシステム メディア トランスポート コントロール (SMTC) との自動統合を無効にしている場合 ([**CommandManager.IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) プロパティを false に設定するなど)、バックグラウンド メディア再生を有効にするために、SMTC との手動統合を実装する必要があります。 **MediaPlayer** 以外の API ([**AudioGraph**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioGraph) など) を使用してオーディオを再生している場合も、アプリがバックグラウンドに移動したときにオーディオを再生し続けるには、手動で SMTC と統合する必要があります。 SMTC 統合の最小要件については、「[システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)」の「バックグラウンド オーディオに対してシステム メディア トランスポート コントロールを使う」セクションをご覧ください。
* アプリがバックグラウンドにある場合、システムによって設定されたバックグラウンド アプリのメモリ使用量の制限を維持する必要があります。 バックグラウンドでのメモリ管理のガイダンスについては、後で示します。

## バックグラウンド メディア再生のマニフェストの機能
バックグラウンド オーディオを有効には、バックグラウンド メディア再生機能をアプリ マニフェスト ファイル (Package.appxmanifest) に追加する必要があります。 

**マニフェスト デザイナーを使って、アプリ マニフェストに機能を追加するには**

1.  Microsoft Visual Studio では、**ソリューション エクスプローラー**で **package.appxmanifest** 項目をダブルクリックし、アプリケーション マニフェストのデザイナーを開きます。
2.  **[機能]** タブをクリックします。
3.  **[バックグラウンド メディア再生]** チェック ボックスをオンにします。

アプリ マニフェスト xml を手動で編集して機能を設定するには、最初に *uap3* 名前空間プレフィックスが **Package** 要素で定義されていることを確認します。 定義されていない場合は、次に示すように追加します。
```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap uap3 mp">
```

次に、*backgroundMediaPlayback* 機能を **Capabilities** 要素に追加します。
```xml
<Capabilities>
    <uap3:Capability Name="backgroundMediaPlayback"/>
</Capabilities>
```

##フォアグラウンドとバックグラウンドの間の移行の処理
アプリがフォアグラウンドからバックグラウンドに移動すると、[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生します。 また、アプリがフォアグラウンドに戻るときには、[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベントが発生します。 これらは、アプリのライフサイクル イベントであるために、アプリを作成するときに、これらのイベントのハンドラーを登録する必要があります。 既定のプロジェクト テンプレートでは、これは、App.xaml.cs の **App** クラス コンストラクターに追加することを意味します。 バックグラウンドで実行すると、システムによってアプリが保持することを許可されているメモリ リソースが減少するため、[**AppMemoryUsageIncreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageIncreased) と [**AppMemoryUsageLimitChanging**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageLimitChanging) イベントについても登録する必要があります。これらは、アプリの現在のメモリ使用量と、現在の制限を確認するために使用されます。 これらのイベントのハンドラーを、次の例に示します。 UWP アプリのアプリケーション ライフサイクルについて詳しくは、「[アプリのライフサイクル](../\launch-resume\app-lifecycle.md)」をご覧ください。

[!code-cs[RegisterEvents](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetRegisterEvents)]

バックグラウンドで現在実行しているかどうかを追跡する変数を作成します。

[!code-cs[DeclareBackgroundMode](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetDeclareBackgroundMode)]

[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生したときに、現在バックグラウンドで実行していることを示す追跡変数を設定します。 **EnteredBackground** イベントで長時間のタスクは実行しないでください。ユーザーに対して、バックグラウンドへの移行が遅いように見える可能性があります。

[!code-cs[EnteredBackground](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetEnteredBackground)]

アプリがバックグラウンドに移行するときに、現在のフォアグラウンド アプリが応答性の高いユーザー エクスペリエンスを提供するために十分なリソースを確保できるように、システムによってアプリのメモリ制限が低減されます。 [**AppMemoryUsageLimitChanging**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageLimitChanging) イベント ハンドラーによって、割り当てられたメモリが削減されたことをアプリに通知することができ、ハンドラーに渡されるイベント引数で新しい制限を提供します。 アプリの現在のメモリ使用量を提供する [**MemoryManager.AppMemoryUsage**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsage) プロパティと、新しい制限を指定するイベント引数の [**NewLimit**](https://msdn.microsoft.com/library/windows/apps/Windows.System.AppMemoryUsageLimitChangingEventArgs.NewLimit) プロパティを比較してください。 メモリ使用量が制限を超えている場合は、メモリ使用量を削減する必要があります。 この例では、この処理はヘルパー メソッド **ReduceMemoryUsage** で実行されます。このメソッドの定義については、後で説明します。

[!code-cs[MemoryUsageLimitChanging](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetMemoryUsageLimitChanging)]

> [!NOTE] 
> デバイス構成によって、システム リソースが不足するまで新しいメモリ制限でアプリケーションの実行を続けることができる場合とできない場合があります。 特に Xbox では、アプリが 2 秒以内にメモリ使用量を新しい制限未満に減らさない場合、アプリは中断または終了されます。 つまり、このイベントを使用して、イベントの発生から 2 秒以内にリソースの使用量を制限未満に減らすことにより、幅広いデバイスで最適なエクスペリエンスを提供できます。


アプリが最初にバックグラウンドに移行したときは、メモリ使用量がバックグラウンド アプリのメモリ制限を下回っていたが、しばらくしてその使用量が増加し、制限に近づき始める場合があります。 [**AppMemoryUsageIncreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageIncreased) ハンドラーによって、メモリ使用量が増加したときに現在の使用量を確認し、必要に応じて、メモリを解放する機会を得ることができます。 [**AppMemoryUsageLevel**](https://msdn.microsoft.com/library/windows/apps/Windows.System.AppMemoryUsageLevel) が **High** または **OverLimit** になっていないかどうかを確認し、これらの値になっている場合はメモリ使用量を減らします。 繰り返しになりますが、この例では、この処理はヘルパー メソッド **ReduceMemoryUsage** によって行われます。 [**AppMemoryUsageDecreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageDecreased) イベントを受信登録して、アプリのメモリ使用量が制限未満であるかどうかを確認でき、制限未満である場合は追加のリソースを割り当てることができます。

[!code-cs[MemoryUsageIncreased](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetMemoryUsageIncreased)]

**ReduceMemoryUsage** は、アプリがバックグラウンドで実行されるアプリのメモリ使用量の制限を超えている場合に、メモリを解放するために実装できるヘルパー メソッドです。 メモリを解放する方法はアプリの仕様によって異なりますが、推奨されるメモリ解放の方法の 1 つは、UI と、アプリ ビューに関連付けられている他のリソースを破棄することです。 最初に、バックグラウンド モードで実行されていることを確認した後、アプリのウィンドウの [**Content**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Window.Content) プロパティを null に設定します。 **GC.Collect** を呼び出して、解放されたメモリをすぐに再利用するようにシステムに指示します。

[!code-cs[UnloadViewContent](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetUnloadViewContent)]

ウィンドウのコンテンツが収集されると、各フレームでは、その切断プロセスが開始されます。 ビジュアル オブジェクト ツリーで、ウィンドウのコンテンツの下に Page がある場合、これらはその [**Unloaded**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.FrameworkElement.Unloaded) イベントを発生させ始めます。 Page は、Page へのすべての参照を削除しない限り、メモリから完全には消去できません。 **Unloaded** コールバックでは、メモリが直ちに解放されるように次の処理を行います。
* Page 内の大規模なデータ構造体を消去して null に設定します。
* Page 内でコールバック メソッドを持つすべてのイベント ハンドラーの登録を解除します。 Page の Loaded イベント ハンドラーで、これらのコールバックを確実に登録します。 Loaded イベントは、UI が再構築され、Page がビジュアル オブジェクト ツリーに追加されたときに発生します。
* Unloaded コールバックの最後に **GC.Collect** を呼び出して、先ほど null に設定した大規模なデータ構造体のガベージ コレクションをすばやく実行します。

[!code-cs[Unloaded](./code/BackgroundAudio_RS1/cs/MainPage.xaml.cs#SnippetUnloaded)]

[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベント ハンドラーで、アプリがバックグラウンドで実行されなくなったことを示すために追跡変数を設定する必要があります。 次に、現在のウィンドウの [**Content**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Window.Content) が null であるかどうかを確認します。バックグラウンドでの実行中にメモリを消去するためにアプリ ビューを破棄した場合は、null になります。 ウィンドウのコンテンツが null の場合は、アプリ ビューを再構築します。 この例では、ウィンドウのコンテンツは、**CreateRootFrame** ヘルパー メソッドで作成されます。

[!code-cs[LeavingBackground](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetLeavingBackground)]

**CreateRootFrame** ヘルパー メソッドは、アプリ ビューのコンテンツを再作成します。 このメソッドのコードは、既定のプロジェクト テンプレートで提供される [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーのコードと同じです。 1 つ異なる点は、**Launching** ハンドラーが [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Activation.LaunchActivatedEventArgs) の [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Activation.LaunchActivatedEventArgs.PreviousExecutionState) プロパティから以前の実行状態を特定するのに対して、**CreateRootFrame** メソッドは単に引数として渡される以前の実行状態を取得します。 重複するコードを最小限に抑えるには、既定の **Launching** イベント ハンドラーのコードをリファクタリングして、必要に応じて **CreateRootFrame** を呼び出します。

[!code-cs[CreateRootFrame](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetCreateRootFrame)]

## バックグラウンド メディア アプリのネットワークの可用性
すべてのネットワーク対応メディア ソース (ストリームやファイルから作成されないソース) は、リモート コンテンツの取得中はアクティブなネットワーク接続を維持し、リモート コンテンツを取得していないときはネットワーク接続を解放します。 [**MediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaStreamSource) は、具体的には、アプリケーションを利用して、[**SetBufferedRange**](https://msdn.microsoft.com/library/windows/apps/dn282762) を使用して適切にバッファー処理された範囲をプラットフォームに適切に報告します。 コンテンツ全体が完全にバッファー処理されると、ネットワークはアプリ用に予約されなくなります。

メディアをダウンロードしていないときに、バックグラウンドでネットワーク呼び出しを行う必要がある場合は、[**ApplicationTrigger**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.ApplicationTrigger)、[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.MaintenanceTrigger)、[**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.TimeTrigger) などの適切なタスクでこれらの呼び出しをラップする必要があります。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/en-us/windows/uwp/launch-resume/support-your-app-with-background-tasks)」をご覧ください。

## 関連トピック
* [メディア再生](media-playback.md)
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)
* [バックグラウンド オーディオのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundMediaPlayback)

 

 







<!--HONumber=Aug16_HO3-->


