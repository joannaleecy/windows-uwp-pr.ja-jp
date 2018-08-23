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
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2810887"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a>UWP アプリが更新された際のバックグラウンド タスクの実行

どこからでも Windows プラットフォーム (UWP) ストア アプリの更新後に実行するバック グラウンド タスクを作成する方法について説明します。

ユーザーがデバイスにインストールされているアプリに、更新プログラムをインストールした後は、オペレーティング システムでタスクを更新するバック グラウンド タスクが呼び出されます。 これにより、アプリなど、データベース スキーマに更新すると、ユーザーが更新されたアプリを起動する前に、新しいプッシュ通知チャネルを初期化初期化タスクを実行できます。

更新のタスクとは異なります、**をアクティブになるバック グラウンド タスクを登録するために更新される前に、アプリする必要があります少なくとも 1 回実行する場合は、 [ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)トリガーの使用をバック グラウンド タスクを起動します。ServicingComplete**トリガーします。  更新するタスクが登録されていないし、ようにが実行されていないはをアップグレードすると、アプリでトリガーの更新プログラムのタスクがあります。

## <a name="step-1-create-the-background-task-class"></a>手順 1: バック グラウンド タスク クラスを作成します。

として他の種類のバック グラウンド タスクを実装するタスクの更新プログラムのバック グラウンド タスク Windows ランタイム コンポーネントとしてします。 このコンポーネントを作成するには、[登録、プロセスのバック グラウンド タスクを作成および](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**バック グラウンド タスク クラスを作成する**セクションの手順に従います。 手順は次のとおりです。

- Windows ランタイム コンポーネント プロジェクトのソリューションを追加します。
- アプリからコンポーネントに参照を作成します。
- コンポーネントの公開、シール クラスを作成するには、 [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)が実装されています。
- [**実行**](https://msdn.microsoft.com/library/windows/apps/br224811)方法を実装するには、更新プログラムのタスクの実行時と呼ばれる必要なエントリ ポイントです。 場合は、バック グラウンド タスクから非同期の通話の発信する予定の場合は、 [register、プロセスのバック グラウンド タスクの作成と](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)、**実行する**方法で、遅延を使用する方法を説明します。

更新プログラムのタスクを使用してこのバック グラウンド タスク (「登録バック グラウンド タスクを実行する」のセクション**を作成してプロセスのバック グラウンド タスクに登録する**トピックの「) を登録する必要はありません。 これは、タスクを登録するアプリにコードを追加する必要はありませんし、アプリがバック グラウンド タスクを登録する更新される前に、1 回以上を実行するために、更新するタスクを使用する主な理由です。

次のサンプル コードでは、c# で基本的なタスクの更新プログラムのバック グラウンド タスク クラスの開始点を示します。 バック グラウンド タスク クラス自体とバック グラウンド タスクのプロジェクト内でその他のすべてのクラスは、**パブリック**と**シール**する必要があります。 バック グラウンド タスク クラスは、 **IBackgroundTask**から派生し、一般向けの**Run()** 方法を次に示す署名がある必要があります。

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

## <a name="step-2-declare-your-background-task-in-the-package-manifest"></a>手順 2: 背景のタスクのパッケージ マニフェストの宣言します。

Visual Studio ソリューション エクスプ ローラーでは、 **Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示するのには、**コードの表示**] をクリックします。 次の追加`<Extensions>`XML、更新プログラムのタスクを宣言するのには。

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

上記の XML] で、`EntryPoint`属性が更新タスク クラスの namespace.class 名前に設定します。 名前は区別されます。

## <a name="step-3-debugtest-your-update-task"></a>手順 3: デバッグ/テスト更新タスク

展開した場合、アプリのコンピューターに更新する必要があることを確認します。

バック グラウンド タスクの Run() メソッドでブレークポイントを設定します。

![ブレークポイントを設定します。](images/run-func-breakpoint.png)

次に、ソリューション エクスプ ローラーでは、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、[**プロパティ**] をクリックします。 アプリケーションのプロパティ ウィンドウで、左側の [**デバッグ**] をクリックし、**起動時にコードをデバッグ起動しない]** を選択します。

![デバッグを設定します。](images/do-not-launch-but-debug.png)

次に、UpdateTask が行われることを確認するには、パッケージのバージョンの数を増やします。 ソリューション エクスプ ローラーでパッケージ デザイナーを開く、アプリの**Package.appxmanifest**ファイルをダブルクリックし、[**ビルド**番号を更新し、します。

![バージョンを更新します。](images/bump-version.png)

これで、Visual Studio 2017 で f5 キーを押すと、アプリ更新され、システムがバック グラウンドで UpdateTask コンポーネントをアクティブにします。 デバッガーは、バック グラウンド プロセスに自動的に添付されます。 ブレークポイントがヒットして、コード ロジックを更新する手順を実行できます。

バック グラウンド タスクが完了したらは、同じデバッグ セッション内で、Windows のスタート メニューから前景色アプリを起動することができます。 デバッガーが自動的にもう一度、添付、フォア グラウンド プロセスには、この時間と、アプリのロジック手順を実行できます。

> [!NOTE]
> Visual Studio 2015 ユーザー: 上記の手順は、Visual Studio 2017 に適用します。 Visual Studio 2015 を使用している場合は、トリガーをテストして添付しません Visual Studio を除く、UpdateTask と同じ方法を使用することができます。 VS 2015 で手順は、エントリ ポイントでは、名前を付けて、UpdateTask を設定する[ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップを開始する前景色アプリから直接実行です。

## <a name="see-also"></a>関連項目

[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
