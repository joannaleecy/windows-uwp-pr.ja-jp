---
ms.assetid: 3a3ea86e-fa47-46ee-9e2e-f59644c0d1db
description: この記事では、アプリがバックグラウンドに移動したときにメモリ使用量を削減する方法について説明します。
title: アプリがバックグラウンド状態に移行したときのメモリ使用量の削減
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c9716483d7df51c2c02d2f9c88e5a4cec05437cc
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8730735"
---
# <a name="free-memory-when-your-app-moves-to-the-background"></a>アプリがバックグラウンドに移動したときのメモリの解放

この記事では、アプリが一時停止にされたり、場合によっては終了にされたりすることがないように、バックグラウンド状態に移行したアプリで使用するメモリの量を削減する方法を説明します。

## <a name="new-background-events"></a>新しいバックグラウンド イベント

Windows 10 バージョン 1607 では、2 つ新しいアプリケーション ライフ サイクル イベント [**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) および [**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) が導入されています。 これらのイベントによって、バックグラウンドへの移行とバックグラウンドからの移行をアプリに通知できます。

アプリがバックグラウンドに移行すると、システムにより強制されるメモリ制限が変化する場合があります。 これらのイベントを使用することで、バックグラウンドに移行しているアプリが中断されたり、場合によっては終了されたりしないように、現在のメモリ消費量を確認してリソースを解放し、制限値を下回っている状態を保ちます。

### <a name="events-for-controlling-your-apps-memory-usage"></a>アプリのメモリ使用量を制御するイベント

[MemoryManager.AppMemoryUsageLimitChanging](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.appmemoryusagelimitchanging.aspx) は、アプリで使用できる合計メモリの制限が変更される直前に発生します。 たとえば、アプリがバックグラウンドに移行し、それが Xbox 上である場合、メモリ制限が 1024 MB から 128 MB に変更されます。  
プラットフォームによってアプリが中断または終了されることを回避するには、このイベントを処理することが最も重要になります。

[MemoryManager.AppMemoryUsageIncreased](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.appmemoryusageincreased.aspx) は、アプリのメモリ消費量が [AppMemoryUsageLevel](https://msdn.microsoft.com/library/windows/apps/windows.system.appmemoryusagelevel.aspx) 列挙値の高い値まで増加したときに発生します。 たとえば、**Low** から **Medium** まで増加した場合です。 このイベントの処理は省略可能ですが、制限未満に留まることについてはまだアプリに責任があるため、処理することをお勧めします。

[MemoryManager.AppMemoryUsageDecreased](https://msdn.microsoft.com/library/windows/apps/windows.system.memorymanager.appmemoryusagedecreased.aspx) は、アプリのメモリ消費量が **AppMemoryUsageLevel** 列挙値の低い値まで減少したときに発生します。 たとえば、**High** から **Low** まで減少した場合です。 このイベントの処理は省略可能ですが、処理することによって必要に応じてアプリで追加のメモリを割り当てられる可能性があることが示されます。

## <a name="handle-the-transition-between-foreground-and-background"></a>フォアグラウンドとバックグラウンドの間の移行の処理

アプリがフォアグラウンドからバックグラウンドに移動すると、[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生します。 アプリがフォアグラウンドに戻るときには、[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベントが発生します。 アプリの作成時にこれらのイベントのハンドラーを登録できます。 既定のプロジェクト テンプレートでは、これは、App.xaml.cs の **App** クラス コンストラクターで行われます。

バックグラウンドで実行すると、アプリが保持することを許可されているメモリ リソースが減少するため、[**AppMemoryUsageIncreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageIncreased) と [**AppMemoryUsageLimitChanging**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageLimitChanging) イベントについても登録する必要があります。これらは、アプリの現在のメモリ使用量と、現在の制限を確認するために使用できます。 これらのイベントのハンドラーを、次の例に示します。 UWP アプリのアプリケーション ライフサイクルについて詳しくは、「[アプリのライフサイクル](..//launch-resume/app-lifecycle.md)」をご覧ください。

[!code-cs[RegisterEvents](./code/ReduceMemory/cs/App.xaml.cs#SnippetRegisterEvents)]

[**EnteredBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.EnteredBackground) イベントが発生したときに、現在バックグラウンドで実行していることを示す追跡変数を設定します。 これは、メモリ使用量を削減するためのコードを記述する際に役立ちます。

[!code-cs[EnteredBackground](./code/ReduceMemory/cs/App.xaml.cs#SnippetEnteredBackground)]

アプリがバックグラウンドに移行するときに、現在のフォアグラウンド アプリが応答性の高いユーザー エクスペリエンスを提供するために十分なリソースを確保できるように、システムによってアプリのメモリ制限が低減されます。

[**AppMemoryUsageLimitChanging**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageLimitChanging) イベント ハンドラーによって、割り当てられたメモリが削減されたことをアプリに通知することができ、ハンドラーに渡されるイベント引数で新しい制限を提供します。 アプリの現在のメモリ使用量を提供する [**MemoryManager.AppMemoryUsage**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsage) プロパティと、新しい制限を指定するイベント引数の [**NewLimit**](https://msdn.microsoft.com/library/windows/apps/Windows.System.AppMemoryUsageLimitChangingEventArgs.NewLimit) プロパティを比較してください。 メモリ使用量が制限を超えている場合は、メモリ使用量を削減する必要があります。

この例では、この処理はヘルパー メソッド **ReduceMemoryUsage** で実行されます。このメソッドの定義については、後で説明します。

[!code-cs[MemoryUsageLimitChanging](./code/ReduceMemory/cs/App.xaml.cs#SnippetMemoryUsageLimitChanging)]

> [!NOTE]
> デバイス構成によって、システム リソースが不足するまで新しいメモリ制限でアプリケーションの実行を続けることができる場合とできない場合があります。 特に Xbox では、アプリが 2 秒以内にメモリ使用量を新しい制限未満に減らさない場合、アプリは中断または終了されます。 つまり、このイベントを使用して、イベントの発生から 2 秒以内にリソースの使用量を制限未満に減らすことにより、幅広いデバイスで最適なエクスペリエンスを提供できます。

アプリが最初にバックグラウンドに移行した時点でアプリの現在のメモリ使用量がバックグラウンド アプリのメモリ制限を下回っていても、時間の経過と共にメモリ消費量が増加し、この制限に接近し始める可能性があります。 [**AppMemoryUsageIncreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageIncreased) ハンドラーによって、メモリ使用量が増加したときに現在の使用量を確認し、必要に応じて、メモリを解放する機会を得ることができます。

[**AppMemoryUsageLevel**](https://msdn.microsoft.com/library/windows/apps/Windows.System.AppMemoryUsageLevel) が **High** または **OverLimit** になっていないかどうかを確認し、これらの値になっている場合はメモリ使用量を減らします。 この例では、これはヘルパー メソッド **ReduceMemoryUsage** によって処理されます。 [**AppMemoryUsageDecreased**](https://msdn.microsoft.com/library/windows/apps/Windows.System.MemoryManager.AppMemoryUsageDecreased) イベントを受信登録して、アプリのメモリ使用量が制限未満であるかどうかを確認でき、制限未満である場合は追加のリソースを割り当てることができます。

[!code-cs[MemoryUsageIncreased](./code/ReduceMemory/cs/App.xaml.cs#SnippetMemoryUsageIncreased)]

**ReduceMemoryUsage** は、バックグラウンドで実行されているアプリがメモリ使用量の制限を超えている場合にメモリを解放するために実装できるヘルパー メソッドです。 メモリを解放する方法はアプリの仕様によって異なりますが、推奨されるメモリ解放の方法の 1 つは、UI と、アプリ ビューに関連付けられている他のリソースを破棄することです。 そのためには、バックグラウンド状態で実行されていることを確認してから、アプリのウィンドウの [**Content**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Window.Content) プロパティを `null` に設定します。次に、UI イベント ハンドラーを登録解除し、存在する可能性があるそのページへのその他の参照をすべて削除します。 UI イベント ハンドラーの登録を解除しないで、存在する可能性があるそのページへのその他の参照をすべてクリアすると、ページ リソースが解放されません。 次に、**GC.Collect** を呼び出して、解放されたメモリをすぐに再利用します。 通常、ガベージ コレクションはシステムが処理するため、強制的に実行したくはありません。 この特定のケースでは、アプリケーションをバックグラウンドに移行する際にこのアプリケーションに割り当てられるメモリ量を減らすことで、メモリを再利用するためにアプリケーションを終了する必要があるとシステムが判断する可能性を減らしています。

[!code-cs[UnloadViewContent](./code/ReduceMemory/cs/App.xaml.cs#SnippetUnloadViewContent)]

ウィンドウのコンテンツが収集されると、各フレームでは、その切断プロセスが開始されます。 ビジュアル オブジェクト ツリーで、ウィンドウのコンテンツの下に Page がある場合、これらはその Unloaded イベントを発生を開始します。 Page は、Page へのすべての参照を削除しない限り、メモリから完全には消去できません。 Unloaded コールバックでは、メモリが直ちに解放されるように次の処理を行います。
* Page 内の大規模なデータ構造体を消去して `null` に設定します。
* Page 内でコールバック メソッドを持つすべてのイベント ハンドラーの登録を解除します。 Page の Loaded イベント ハンドラーで、これらのコールバックを確実に登録します。 Loaded イベントは、UI が再構築され、Page がビジュアル オブジェクト ツリーに追加されたときに発生します。
* Unloaded コールバックの最後に `GC.Collect` を呼び出して、先ほど `null` に設定した大規模なデータ構造体のガベージ コレクションをすばやく実行します。 通常、ガベージ コレクションはシステムが処理するため、強制的に実行したくはありません。 この特定のケースでは、アプリケーションをバックグラウンドに移行する際にこのアプリケーションに割り当てられるメモリ量を減らすことで、メモリを再利用するためにアプリケーションを終了する必要があるとシステムが判断する可能性を減らしています。

[!code-cs[MainPageUnloaded](./code/ReduceMemory/cs/App.xaml.cs#SnippetMainPageUnloaded)]

[**LeavingBackground**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Core.CoreApplication.LeavingBackground) イベント ハンドラーで、アプリがバックグラウンドで実行されなくなったことを示すために追跡変数 (`isInBackgroundMode`) を設定する必要があります。 次に、現在のウィンドウの [**Content**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Window.Content) が `null` であるかどうかを確認します。バックグラウンドでの実行中にメモリを消去するためにアプリ ビューを破棄した場合は、null になります。 ウィンドウのコンテンツが `null` の場合は、アプリ ビューを再構築します。 この例では、ウィンドウのコンテンツは、**CreateRootFrame** ヘルパー メソッドで作成されます。

[!code-cs[LeavingBackground](./code/ReduceMemory/cs/App.xaml.cs#SnippetLeavingBackground)]

**CreateRootFrame** ヘルパー メソッドは、アプリ ビューのコンテンツを再作成します。 このメソッドのコードは、既定のプロジェクト テンプレートで提供される [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) ハンドラーのコードとほぼ同じです。 1 つ異なる点は、**Launching** ハンドラーが [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Activation.LaunchActivatedEventArgs) の [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.Activation.LaunchActivatedEventArgs.PreviousExecutionState) プロパティから以前の実行状態を特定するのに対して、**CreateRootFrame** メソッドは単に引数として渡される以前の実行状態を取得します。 重複するコードを最小限に抑えるには、既定の **Launching** イベント ハンドラーのコードをリファクタリングして、**CreateRootFrame** を呼び出します。

[!code-cs[CreateRootFrame](./code/ReduceMemory/cs/App.xaml.cs#SnippetCreateRootFrame)]

## <a name="guidelines"></a>ガイドライン

### <a name="moving-from-the-foreground-to-the-background"></a>フォアグラウンドからバックグラウンドへの移動

アプリがフォアグラウンドからバックグラウンドに移動すると、アプリの代わりにシステムによって、必要のないバックグラウンドのリソースを解放する動作が実行されます。 たとえば、アプリに代わって UI フレームワークによってキャッシュ済みのテクスチャがフラッシュされ、ビデオ サブシステムによって割り当て済みのメモリが解放されます。 ただし、システムによって中断されたり終了されたりすることを避けるために、アプリでは引き続きメモリ使用量を注意深く監視する必要があります。

アプリがフォアグラウンドからバックグラウンドに移動すると、アプリはまず **EnteredBackground** イベントを受け取り、次に **AppMemoryUsageLimitChanging** イベントを受け取ります。

- **必ず**、**EnteredBackground** イベントを使用して、バックグラウンドでの実行中にアプリで必要とされないことがわかっている UI リソースを解放します。 たとえば、曲のカバー アート画像を解放できます。
- **必ず**、**AppMemoryUsageLimitChanging** イベントを使用して、アプリで使用しているメモリが新しいバックグラウンド制限を下回っていることを確認します。 下回っていない場合は必ずリソースを解放します。 解放しなければ、デバイス固有のポリシーに従ってアプリが中断または終了される可能性があります。
- **必ず**、**AppMemoryUsageLimitChanging** イベントの発生時にアプリで新しいメモリ制限を超えている場合は手動でガーベジ コレクターを呼び出します。
- メモリ使用量の変化が予測される場合は、**必ず**、**AppMemoryUsageIncreased** イベントを使用して、バックグラウンドで実行中のアプリのメモリ使用量を継続的に監視します。 **AppMemoryUsageLevel** が **High** または **OverLimit** の場合は、リソースが解放されるようにします。
- パフォーマンス最適化として、**EnteredBackground** ハンドラーではなく、**AppMemoryUsageLimitChanging** イベント ハンドラーで UI リソースを解放することを**考慮**します。 **EnteredBackground/LeavingBackground** イベント ハンドラーでブール値セットを使用し、アプリがバックグラウンドで動作しているかフォアグラウンドで動作しているかを追跡します。 次に、**AppMemoryUsageLimitChanging** イベント ハンドラーで、**AppMemoryUsage** が制限を超えていて、アプリがバックグラウンドで動作している場合は (ブール値に基づく)、UI リソースを解放します。
- **EnteredBackground** イベントでは時間がかかる操作を実行**しないでください**。アプリケーション間の移行がユーザーに対して遅く表示される可能性があるためです。

### <a name="moving-from-the-background-to-the-foreground"></a>バックグラウンドからフォアグラウンドへの移動

アプリがバックグラウンドからフォアグラウンドに移動すると、アプリはまず **AppMemoryUsageLimitChanging** イベントを受け取り、次に **LeavingBackground** イベントを受け取ります。

- **必ず**、**LeavingBackground** イベントを使用して、バックグラウンドに移動したときに破棄した UI リソースを再作成します。

## <a name="related-topics"></a>関連トピック

* [バックグラウンド メディア再生のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=800141) - アプリがバックグラウンド状態に移行するときにメモリを解放する方法を説明します。
* [診断ツール](https://blogs.msdn.microsoft.com/visualstudioalm/2015/01/16/diagnostic-tools-debugger-window-in-visual-studio-2015/) - 診断ツールを使用して、ガベージ コレクション イベントを監視し、予想される方法によりアプリでメモリが解放されているかどうかを検証します。
