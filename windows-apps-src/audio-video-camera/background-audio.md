---
ms.assetid: b7333924-d641-4ba5-92a2-65925b44ccaa
description: この記事では、アプリがバックグラウンドで実行されているときにメディアを再生する方法を示します。
title: バックグラウンドでのメディアの再生
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b8a859f27ff24dba15f7e4fde66a8d54a84a8bf4
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8925786"
---
# <a name="play-media-in-the-background"></a>バックグラウンドでのメディアの再生
この記事では、アプリをフォアグラウンドからバックグラウンドに移動してもメディアの再生を続行できるように、アプリを構成する方法について説明します。 バックグラウンドでの再生とは、ユーザーがアプリを最小化してホーム画面に戻った後や、それ以外の方法でアプリから離れた後も、アプリでオーディオの再生を続行できることを意味します。 

バックグラウンド オーディオ再生のシナリオには次のものがあります。

-   **長時間にわたって実行されるプレイリスト:** ユーザーは、フォアグラウンド アプリを一時的に表示し、プレイリストを選んで再生を開始します。その後、プレイリストはバックグラウンドで再生を続行します。

-   **タスク スイッチャーの使用:** ユーザーは、オーディオの再生を開始するためにフォアグラウンド アプリを一時的に表示した後、タスク スイッチャーを使って別の開いているアプリに切り替えます。 ユーザーは、バックグラウンドでオーディオの再生が継続することを期待します。

この記事で説明されているバックグラウンド オーディオの実装を使うと、モバイル、デスクトップ、Xbox を含むすべての Windows デバイスで、アプリをユニバーサルに実行できます。

> [!NOTE]
> この記事のコードは、UWP の[バックグラウンド オーディオのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=800141)を基にしています。

## <a name="explanation-of-one-process-model"></a>1 プロセス モデルの説明
Windows 10 バージョン 1607 では、新しいシングル プロセス モデルが導入され、バックグラウンド オーディオを実現するプロセスが大幅に簡略化されました。 以前は、アプリで、フォアグラウンド アプリに加えてバックグラウンド プロセスも管理し、2 つのプロセス間の状態変更を手動で通信する必要がありました。 新しいモデルでは、アプリ マニフェストにバックグラウンド オーディオ機能を追加するだけで、アプリはバックグラウンドに移行しても、自動的にオーディオ再生を続行します。 2 つ新しいアプリケーション ライフサイクル イベント、[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) と [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) によって、バックグラウンドへの移行とバックグラウンドからの移行をアプリに通知できます。 アプリがバックグラウンドに遷移またはバックグラウンドから遷移する場合、システムによって適用されるメモリの制約が変化する場合があるため、これらのイベントを使用して現在のメモリ消費量を確認し、制限値を下回るようにリソースを解放できます。

複雑なプロセス間通信と状態の管理を排除することによって、新しいモデルでは、コードを大幅に削減し、より簡単にバックグラウンド オーディオを実装することができます。 ただし、下位互換性のために、現在のリリースでは 2 プロセス モデルも引き続きサポートされています。 詳しくは、「[従来のバックグラウンド オーディオ モデル](legacy-background-media-playback.md)」をご覧ください。

## <a name="requirements-for-background-audio"></a>バックグラウンド オーディオの要件
アプリは、アプリがバックグラウンドで実行されている場合のオーディオ再生について、以下の要件を満たしている必要があります。

* アプリ マニフェストに**バックグラウンド メディア再生**機能を追加します。その方法については、後で説明します。
* アプリで、**MediaPlayer** のシステム メディア トランスポート コントロール (SMTC) との自動統合を無効にしている場合 ([**CommandManager.IsEnabled**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Playback.MediaPlaybackCommandManager.IsEnabled) プロパティを false に設定するなど)、バックグラウンド メディア再生を有効にするために、SMTC との手動統合を実装する必要があります。 **MediaPlayer** 以外の API ([**AudioGraph**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Audio.AudioGraph) など) を使用してオーディオを再生している場合も、アプリがバックグラウンドに移動したときにオーディオを再生し続けるには、手動で SMTC と統合する必要があります。 SMTC 統合の最小要件については、「[システム メディア トランスポート コントロールの手動制御](system-media-transport-controls.md)」の「バックグラウンド オーディオに対してシステム メディア トランスポート コントロールを使う」セクションをご覧ください。
* アプリがバックグラウンドにある場合、システムによって設定されたバックグラウンド アプリのメモリ使用量の制限を維持する必要があります。 バックグラウンドでのメモリ管理のガイダンスについては、後で示します。

## <a name="background-media-playback-manifest-capability"></a>バックグラウンド メディア再生のマニフェストの機能
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

## <a name="handle-transitioning-between-foreground-and-background"></a>フォアグラウンドとバックグラウンドの間の移行の処理
アプリがフォアグラウンドからバックグラウンドに移動すると、[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生します。 また、アプリがフォアグラウンドに戻るときには、[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベントが発生します。 これらは、アプリのライフサイクル イベントであるために、アプリを作成するときに、これらのイベントのハンドラーを登録する必要があります。 既定のプロジェクト テンプレートでは、これは、App.xaml.cs の **App** クラス コンストラクターに追加することを意味します。 

[!code-cs[RegisterEvents](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetRegisterEvents)]

バックグラウンドで現在実行しているかどうかを追跡する変数を作成します。

[!code-cs[DeclareBackgroundMode](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetDeclareBackgroundMode)]

[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生したときに、現在バックグラウンドで実行していることを示す追跡変数を設定します。 **EnteredBackground** イベントで長時間のタスクは実行しないでください。ユーザーに対して、バックグラウンドへの移行が遅いように見える可能性があります。

[!code-cs[EnteredBackground](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetEnteredBackground)]

[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベント ハンドラーで、アプリがバックグラウンドで実行されなくなったことを示すために追跡変数を設定する必要があります。

[!code-cs[LeavingBackground](./code/BackgroundAudio_RS1/cs/App.xaml.cs#SnippetLeavingBackground)]

### <a name="memory-management-requirements"></a>メモリ管理の要件
フォアグラウンドとバックグラウンドの間の移行処理で最も重要な部分は、アプリが使うメモリの管理です。 バックグラウンドで実行すると、システムによってアプリが保持することを許可されているメモリ リソースが減少するため、[**AppMemoryUsageIncreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageIncreased) と [**AppMemoryUsageLimitChanging**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageLimitChanging) イベントについても登録する必要があります。 これらのイベントが発生したとき、アプリの現在のメモリ使用量と、現在の制限を確認し、必要に応じて、メモリ使用量を減らしてください。 バックグラウンドで実行中にメモリ使用量を減らす方法については、[アプリがバックグラウンドに移動したときにメモリを解放する方法に関するページ](../launch-resume/reduce-memory-usage.md)をご覧ください。

## <a name="network-availability-for-background-media-apps"></a>バックグラウンド メディア アプリのネットワークの可用性
すべてのネットワーク対応メディア ソース (ストリームやファイルから作成されないソース) は、リモート コンテンツの取得中はアクティブなネットワーク接続を維持し、リモート コンテンツを取得していないときはネットワーク接続を解放します。 [**MediaStreamSource**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Core.MediaStreamSource) は、具体的には、アプリケーションを利用して、[**SetBufferedRange**](https://msdn.microsoft.com/library/windows/apps/dn282762) を使用して適切にバッファー処理された範囲をプラットフォームに適切に報告します。 コンテンツ全体が完全にバッファー処理されると、ネットワークはアプリ用に予約されなくなります。

メディアをダウンロードしていないときに、バックグラウンドでネットワーク呼び出しを行う必要がある場合は、[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.MaintenanceTrigger) や [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Background.TimeTrigger) などの適切なタスクでこれらの呼び出しをラップする必要があります。 詳しくは、「[バックグラウンド タスクによるアプリのサポート](https://msdn.microsoft.com/windows/uwp/launch-resume/support-your-app-with-background-tasks)」をご覧ください。

## <a name="related-topics"></a>関連トピック
* [メディア再生](media-playback.md)
* [MediaPlayer を使ったオーディオとビデオの再生](play-audio-and-video-with-mediaplayer.md)
* [システム メディア トランスポート コントロールとの統合](integrate-with-systemmediatransportcontrols.md)
* [バックグラウンド オーディオのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/BackgroundMediaPlayback)

 

 




