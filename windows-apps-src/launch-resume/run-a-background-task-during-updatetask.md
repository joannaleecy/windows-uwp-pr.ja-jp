---
author: TylerMSFT
title: UWP アプリが更新された際のバックグラウンド タスクの実行
description: ユニバーサル Windows プラットフォーム (UWP) アプリが更新された際に実行されるバックグラウンド タスクの作成方法を説明します。
ms.author: twhitney
ms.date: 04/21/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 更新, バック グラウンド タスク、updatetask, バック グラウンド タスク
ms.localizationpriority: medium
ms.openlocfilehash: fcba2cb736f86cebc6d2664e2ec3b557d47c86d7
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4508773"
---
# <a name="run-a-background-task-when-your-uwp-app-is-updated"></a>UWP アプリが更新された際のバックグラウンド タスクの実行

ユニバーサル Windows プラットフォーム (UWP) アプリが更新された後に実行されるバック グラウンド タスクを作成する方法について説明します。

ユーザーがデバイスにインストールされているアプリに更新プログラムをインストールした後、オペレーティング システムによって更新タスクのバック グラウンド タスクが呼び出されます。 これにより、データベース スキーマというようの更新、ユーザーが、更新されたアプリを起動する前に、新しいプッシュ通知チャネルの初期化などの初期化のタスクを実行するアプリができます。

更新タスクとは異なります[ServicingComplete](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Background.SystemTriggerType)トリガーを使用して、その場合は、アプリする必要があります実行するために少なくとも 1 回、**がアクティブ化されるバック グラウンド タスクを登録するために更新される前に、バック グラウンド タスクを起動します。ServicingComplete**トリガーします。  更新タスクが登録されていないし、ためが実行されていないがをアップグレードすると、アプリがまだその更新タスクがトリガーされます。

## <a name="step-1-create-the-background-task-class"></a>手順 1: バック グラウンド タスク クラスを作成します。

として他の種類のバック グラウンド タスクとして実装する更新タスクのバック グラウンド タスクの Windows ランタイム コンポーネント。 このコンポーネントを作成するには、[作成と登録、アウト プロセス バック グラウンド タスク](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**バック グラウンド タスク クラスを作成する**セクションの手順に従います。 手順は次のとおりです。

- Windows ランタイム コンポーネント プロジェクトをソリューションに追加します。
- アプリからコンポーネントへの参照を作成します。
- [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)を実装するコンポーネントのパブリック、シール クラスを作成します。
- 更新タスクの実行時に呼び出される必須のエントリ ポイントは、 [**Run**](https://msdn.microsoft.com/library/windows/apps/br224811)メソッドを実装します。 バック グラウンド タスクからの非同期呼び出しを行う場合は[の作成と登録、アウト プロセス バック グラウンド タスク](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)の**Run**メソッドで、保留を使用する方法について説明します。

更新のタスクを使用する (「を実行するバック グラウンド タスクの登録」のセクション**の作成と登録、アウト プロセス バック グラウンド タスク**のトピックで)、このバック グラウンド タスクを登録する必要はありません。 これは、タスクを登録するアプリにコードを追加する必要はなく、アプリがバック グラウンド タスクを登録するように更新されている前に、1 回以上実行がないために、更新タスクを使用する主な理由です。

次のサンプル コードでは、c# で更新タスクのバック グラウンド タスク クラスの基本的な開始点を示します。 バック グラウンド タスク クラス自体とバック グラウンド タスク プロジェクトの他のすべてのクラスには、**パブリック**にして**シール**必要があります。 バック グラウンド タスク クラスでは、 **IBackgroundTask**から派生を次に示すシグネチャを持つパブリック**Run()** メソッドがある必要があります。

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

Visual Studio のソリューション エクスプ ローラーでは、 **Package.appxmanifest**を右クリックし、パッケージ マニフェストを表示する**コードの表示**] をクリックします。 次の追加`<Extensions>`、更新プログラムのタスクを宣言する XML:

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

上記の XML で、 `EntryPoint` namespace.class 名更新タスク クラスの属性を設定します。 名前が区別されます。

## <a name="step-3-debugtest-your-update-task"></a>手順 3: デバッグ/テスト、更新タスク

展開したアプリをコンピューターに更新する必要があるようにを確認します。

バック グラウンド タスクの Run() メソッドにブレークポイントを設定します。

![一連のブレークポイント](images/run-func-breakpoint.png)

次に、ソリューション エクスプ ローラーで、アプリのプロジェクト (バック グラウンド タスク プロジェクトではない) を右クリックし、**プロパティ**] をクリックします。 アプリケーションのプロパティ] ウィンドウで、左側で、[**デバッグ**] をクリックし、選択 **、起動しないが開始時にマイ コードをデバッグ**します。

![デバッグを設定します。](images/do-not-launch-but-debug.png)

次に、UpdateTask がトリガーされることを確認するには、パッケージのバージョン番号を大ききます。 ソリューション エクスプ ローラーでは、パッケージ デザイナーを開き、アプリの**Package.appxmanifest**ファイルをダブルクリックしてし、**ビルド**番号を更新します。

![バージョンを更新します。](images/bump-version.png)

これで、Visual Studio 2017 で f5 キーを押すと、アプリを更新し、システムがバック グラウンドで UpdateTask コンポーネントをアクティブ化します。 デバッガーは、自動的にバック グラウンド プロセスにアタッチします。 ブレークポイントがヒットを取得して、更新プログラムのコード ロジックをステップ実行することができます。

バック グラウンド タスクが完了したら、同じデバッグ セッションで Windows のスタート メニューからフォア グラウンド アプリを起動できます。 デバッガーはもう一度自動的にアタッチ、今度は、フォア グラウンド プロセスと、アプリのロジックをステップ実行することができます。

> [!NOTE]
> Visual Studio 2015 ユーザー: 上記の手順は、Visual Studio 2017 に適用します。 Visual Studio 2015 を使用している場合は、トリガーとそれに Visual Studio を除く、UpdateTask を添付しませんテストを同じ手法を使用することができます。 VS 2015 での手順では、設定のエントリ ポイント、UpdateTask [ApplicationTrigger](https://docs.microsoft.com/windows/uwp/launch-resume/trigger-background-task-from-app)をセットアップし、フォア グラウンド アプリから直接実行をトリガーします。

## <a name="see-also"></a>関連項目

[アウトプロセス バックグラウンド タスクの作成と登録](https://docs.microsoft.com/windows/uwp/launch-resume/create-and-register-a-background-task)
