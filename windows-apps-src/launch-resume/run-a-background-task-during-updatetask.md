---
author: TylerMSFT
title: UWP アプリが更新された際のバックグラウンド タスクの実行
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.author: twhitney
ms.date: 04/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、更新、バック グラウンド タスク、updatetask、バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: fcba2cb736f86cebc6d2664e2ec3b557d47c86d7
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931284"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a>UWP アプリが更新された際のバックグラウンド タスクの実行

ユニバーサル Windows プラットフォーム (UWP) ストアのアプリが更新された後に実行するバック グラウンド タスクを記述する方法について説明します。

タスクの更新のバック グラウンド タスクは、ユーザーがデバイスにインストールされているアプリケーションに更新プログラムをインストールした後、オペレーティング システムによって呼び出されます。 これにより、ユーザーが更新されたアプリを起動する前に、データベース スキーマというようの更新、新しいプッシュ通知チャネルを初期化する初期化タスクを実行するアプリケーションです。

更新タスク場合アプリに少なくとも 1 回前に実行する、**を有効にするバック グラウンド タスクを登録するために更新されますので、 [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)のトリガーを使用してバック グラウンド タスクを起動するとは異なるServicingComplete**トリガーします。  更新タスクが登録されていません、アプリケーションが実行されていないが、アップグレードするがまだ更新タスクがトリガーされるのです。

## <a name="step-1-create-the-background-task-class"></a>ステップ 1: バック グラウンド タスク クラスを作成します。

として他の種類のバック グラウンド タスクを実装するタスクの更新プログラムのバック グラウンド タスク Windows ランタイム コンポーネントとして。 このコンポーネントを作成するのには、**バック グラウンド タスク クラスを作成する**のセクション[を作成してプロセス外のバック グラウンド タスクの登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)で、手順を実行します。 手順は次のとおりです。

- Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。
- アプリからコンポーネントへの参照を作成しています。
- コンポーネントで公開、シール クラスを作成するには、 [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)が実装されています。
- 更新タスクの実行時に呼び出される必要なエントリ ポイントは、 [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811)メソッドを実装します。 バック グラウンド タスクからの非同期の呼び出しを行う場合は、[レジスタ、アウト プロセスのバック グラウンド タスクを作成および](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)**実行**メソッドで、遅延を使用する方法を説明します。

更新タスクを使用して、このバック グラウンド タスク ("を実行するバック グラウンド タスクを登録する] のセクション**を作成および登録、アウト プロセスのバック グラウンド タスク**のトピックで) を登録する必要はありません。 これは、タスクを登録するのにはアプリケーションにコードを追加する必要はありませんし、バック グラウンド タスクを登録するのには更新される前に 1 回以上実行するアプリケーションがないため、更新タスクを使用する主な理由です。

次のサンプル コードは、C# でタスクの更新プログラムのバック グラウンド タスク クラスの基本的な開始点を示しています。 バック グラウンド タスク クラス自体とバック グラウンド タスク プロジェクト内の他のすべてのクラスは、**パブリック**と**シール**する必要があります。 バック グラウンド タスク クラスは、 **IBackgroundTask**から派生し、次に示すシグネチャを持つパブリック**Run()** メソッドがある必要があります。

```cs
using Windows.ApplicationModel.Background;

namespace BackgroundTasks
{
    public sealed class UpdateTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // your app migration/update code here
        }
    }
}
```

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a>手順 2: パッケージ マニフェストでバック グラウンド タスクを宣言します。

Visual Studio のソリューション エクスプ ローラーで**Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示するのには**コードの表示**] をクリックします。 次の追加`<Extensions>`の更新タスクを宣言する XML。

```XML
<Package ...>
    ...
  <Applications>  
    <Application ...>  
        ...
      <Extensions>  
        <Extension Category="windows.updateTask"  EntryPoint="BackgroundTasks.UpdateTask">  
        </Extension>  
      </Extensions>

    </Application>  
  </Applications>  
</Package>
```

上記の xml では、確実に、 `EntryPoint` namespace.class クラスの名前、更新作業に属性を設定します。 名前は、大文字小文字を区別します。

## <a name="step-3-debugtest-your-update-task"></a>手順 3: デバッグとテストの更新タスク

配布したアプリのコンピューターに更新するのには何かを使用する必要があるようにすることを確認します。

バック グラウンド タスクの Run() メソッドにブレークポイントを設定します。

![セット ブレークポイント](images/run-func-breakpoint.png)

次に、ソリューション エクスプ ローラーでは、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、[**プロパティ**] をクリックします。 アプリケーションのプロパティ] ウィンドウで、左側の [**デバッグ**] をクリックし **、起動しないが、起動時にコードをデバッグする**を選択します。

![デバッグを設定します。](images/do-not-launch-but-debug.png)

次に、UpdateTask を発生させることを確認するには、パッケージのバージョン番号を増加します。 ソリューション エクスプ ローラーで、パッケージ デザイナーを開き、アプリの**Package.appxmanifest**ファイルをダブルクリックして、**ビルド**番号を更新し。

![バージョンを更新します。](images/bump-version.png)

2017 を Visual Studio で f5 キーを押すと、アプリ更新され、システムがバック グラウンドで UpdateTask コンポーネントをアクティブにします。 デバッガーはバック グラウンド プロセスに自動的にアタッチします。 ブレークポイントはヒットを取得し、更新プログラムのコードのロジックをステップ実行することができます。

バック グラウンド タスクが完了すると、同じデバッグ セッション内で Windows の [スタート] メニューから、フォア グラウンド アプリケーションを起動できます。 デバッガーが自動的に再試行を添付する、フォア グラウンドのプロセスには、この時間と、アプリケーションのロジックをステップ実行することができます。

> [!NOTE]
> 2015年の Visual Studio のユーザー: 上記の手順は、Visual Studio の 2017 に適用します。 2015 の Visual Studio を使用する場合は、トリガーをテストは、Visual Studio 以外の UpdateTask を添付しませんと同じ手法を使用できます。 VS 2015 で別のプロシージャでは、そのエントリ ポイントとして、UpdateTask を設定する[ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップし、フォア グラウンド アプリケーションから直接実行をトリガーします。

## <a name="see-also"></a>関連項目

[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
