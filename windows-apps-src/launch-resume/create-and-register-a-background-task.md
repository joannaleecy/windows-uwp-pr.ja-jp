---
author: TylerMSFT
title: アウトプロセス バックグラウンド タスクの作成と登録
description: アウトプロセスのバックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合に実行されるように登録します。
ms.assetid: 4F98F6A3-0D3D-4EFB-BA8E-30ED37AE098B
ms.author: twhitney
ms.date: 07/02/2018
ms.topic: article
keywords: バック グラウンド タスクの windows 10, uwp,
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 8d32b4559e91cc898944f3767d4b082935359d49
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6051536"
---
# <a name="create-and-register-an-out-of-process-background-task"></a>アウトプロセス バックグラウンド タスクの作成と登録

**重要な API**

-   [**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794)
-   [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768)
-   [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781)

バックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合にも実行されるように登録します。 このトピックでは、アプリのプロセスとは別のプロセスで実行されるバックグラウンド タスクを作成して登録する方法について説明します。 フォアグラウンド アプリケーションで直接バックグラウンド作業を実行する方法については、「[インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)」をご覧ください。

> [!NOTE]
> バックグラウンド タスクを使ってバックグラウンドでメディアを再生する場合、Windows 10 バージョン 1607 で簡単に行うことができる機能強化について、「[バックグラウンドでのメディアの再生](https://msdn.microsoft.com/windows/uwp/audio-video-camera/background-audio)」をご覧ください。

## <a name="create-the-background-task-class"></a>バックグラウンド タスク クラスを作る

[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装するクラスを作ると、コードをバックグラウンドで実行できます。 このコードは、使用すると、たとえば、 [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)または[**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517)特定のイベントがトリガーされたときに実行されます。

次の手順では、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを記述する方法について説明します。

1.  バックグラウンド タスク用に新しいプロジェクトを作ってソリューションに追加します。 これを行うには、**ソリューション エクスプ ローラー**で、ソリューション ノードを右クリックし、[**追加** \> **新しいプロジェクト**です。 **Windows ランタイム コンポーネント**プロジェクトの種類、プロジェクトに名前を選択し、[ok] をクリックします。
2.  ユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトからバックグラウンド タスク プロジェクトを参照します。 C# または C++ アプリの場合、アプリ プロジェクトで**参照**で右クリックし、**新しい参照の追加**を選択します。 **[ソリューション]** で、**[プロジェクト]** を選び、バックグラウンド タスク プロジェクトの名前を選んで **[OK]** をクリックします。
3.  バック グラウンド タスク プロジェクトでは、 [**IBackgroundTask**](/uwp/api/Windows.ApplicationModel.Background.IBackgroundTask)インターフェイスを実装する新しいクラスを追加します。 [**IBackgroundTask.Run**](/uwp/api/windows.applicationmodel.background.ibackgroundtask.run)メソッドが呼び出される、指定のイベントがトリガーされると、必須のエントリ ポイントです。すべてのバック グラウンド タスクでは、以下のメソッドが必要です。

> [!NOTE]
> バック グラウンド タスク クラス自体&mdash;と、バック グラウンド タスク プロジェクトで他のすべてのクラス&mdash; **sealed** (または**最終的な**) は**パブリック**クラスを使用する必要があります。

次のサンプル コードでは、バック グラウンド タスク クラスの場合は、非常に基本的な開始点を示します。

```csharp
// ExampleBackgroundTask.cs
using Windows.ApplicationModel.Background;

namespace Tasks
{
    public sealed class ExampleBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            
        }        
    }
}
```

```cppwinrt
// First, add ExampleBackgroundTask.idl, and then build.
// ExampleBackgroundTask.idl
namespace Tasks
{
    [default_interface]
    runtimeclass ExampleBackgroundTask : Windows.ApplicationModel.Background.IBackgroundTask
    {
        ExampleBackgroundTask();
    }
}

// ExampleBackgroundTask.h
#pragma once

#include "ExampleBackgroundTask.g.h"

namespace winrt::Tasks::implementation
{
    struct ExampleBackgroundTask : ExampleBackgroundTaskT<ExampleBackgroundTask>
    {
        ExampleBackgroundTask() = default;

        void Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance);
    };
}

namespace winrt::Tasks::factory_implementation
{
    struct ExampleBackgroundTask : ExampleBackgroundTaskT<ExampleBackgroundTask, implementation::ExampleBackgroundTask>
    {
    };
}

// ExampleBackgroundTask.cpp
#include "pch.h"
#include "ExampleBackgroundTask.h"

namespace winrt::Tasks::implementation
{
    void ExampleBackgroundTask::Run(Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance)
    {
        throw hresult_not_implemented();
    }
}
```

```cpp
// ExampleBackgroundTask.h
#pragma once

using namespace Windows::ApplicationModel::Background;

namespace Tasks
{
    public ref class ExampleBackgroundTask sealed : public IBackgroundTask
    {

    public:
        ExampleBackgroundTask();

        virtual void Run(IBackgroundTaskInstance^ taskInstance);
        void OnCompleted(
            BackgroundTaskRegistration^ task,
            BackgroundTaskCompletedEventArgs^ args
        );
    };
}

// ExampleBackgroundTask.cpp
#include "ExampleBackgroundTask.h"

using namespace Tasks;

void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
{
}
```

4.  バックグラウンド タスクで非同期コードを実行する場合は、バックグラウンド タスクで遅延を使う必要があります。 遅延を使わない場合、バック グラウンド タスクの処理を終了できます予期せず、非同期処理の実行が完了する前に、 **Run**メソッドが返す場合。

非同期メソッドを呼び出す前に、 **Run**メソッドでは、保留を要求します。 非同期メソッドからアクセスできるように、クラスのデータ メンバーに、遅延を保存します。 非同期コードが完了した後、遅延を完了するように宣言します。

次のサンプル コードは、保留を取得するには、保存、および非同期コードが完了したら、それを解放します。

```csharp
BackgroundTaskDeferral _deferral; // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation
public async void Run(IBackgroundTaskInstance taskInstance)
{
    _deferral = taskInstance.GetDeferral()
    //
    // TODO: Insert code to start one or more asynchronous methods using the
    //       await keyword, for example:
    //
    // await ExampleMethodAsync();
    //

    _deferral.Complete();
}
```

```cppwinrt
// ExampleBackgroundTask.h
...
private:
    Windows::ApplicationModel::Background::BackgroundTaskDeferral m_deferral{ nullptr };

// ExampleBackgroundTask.cpp
...
Windows::Foundation::IAsyncAction ExampleBackgroundTask::Run(
    Windows::ApplicationModel::Background::IBackgroundTaskInstance const& taskInstance)
{
    m_deferral = taskInstance.GetDeferral(); // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation.
    // TODO: Modify the following line of code to call a real async function.
    co_await ExampleCoroutineAsync(); // Run returns at this point, and resumes when ExampleCoroutineAsync completes.
    m_deferral.Complete();
}
```

```cpp
void ExampleBackgroundTask::Run(IBackgroundTaskInstance^ taskInstance)
{
    m_deferral = taskInstance->GetDeferral(); // Note: defined at class scope so that we can mark it complete inside the OnCancel() callback if we choose to support cancellation.

    //
    // TODO: Modify the following line of code to call a real async function.
    //       Note that the task<void> return type applies only to async
    //       actions. If you need to call an async operation instead, replace
    //       task<void> with the correct return type.
    //
    task<void> myTask(ExampleFunctionAsync());

    myTask.then([=]() {
        m_deferral->Complete();
    });
}
```

> [!NOTE]
> C# では、**async/await** キーワードを使ってバックグラウンド タスクの非同期メソッドを呼び出すことができます。 C++/cli CX、同様の結果は、タスク チェーンを使用して実現できます。

非同期パターンについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。 遅延を使ってバックグラウンド タスクの早期停止を防ぐ方法に関するその他の例については、[バックグラウンド タスクのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=618666)をご覧ください。

次の手順はいずれかのアプリ クラス (MainPage.xaml.cs など) で実行します。

> [!NOTE]
> バック グラウンド タスクを登録するための専用の関数を作成することもできます。&mdash;[バック グラウンド タスクの登録](register-a-background-task.md)を参照してください。 その場合は、次の 3 つの手順ではなく単にトリガーを作成して、タスク名、タスクのエントリ ポイント、および (必要に応じて) 条件併せて登録関数に提供できます。

## <a name="register-the-background-task-to-run"></a>実行するバックグラウンド タスクを登録する

1.  [**BackgroundTaskRegistration.AllTasks**](https://msdn.microsoft.com/library/windows/apps/br224787)プロパティを反復処理して、バック グラウンド タスクが既に登録されているかどうかについて説明します。 この確認は重要です。既にあるバックグラウンド タスクの二重登録をアプリで確認しなかった場合、同じタスクが何度も登録され、パフォーマンスが低下したり、タスクの CPU 時間を使い切って処理を完了できなくなるなどの問題が生じます。

次の例では、 **AllTasks**プロパティを反復処理し、タスクが既に登録されている場合は true にフラグ変数を設定します。

```csharp
var taskRegistered = false;
var exampleTaskName = "ExampleBackgroundTask";

foreach (var task in BackgroundTaskRegistration.AllTasks)
{
    if (task.Value.Name == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }
}
```

```cppwinrt
std::wstring exampleTaskName{ L"ExampleBackgroundTask" };

auto allTasks{ Windows::ApplicationModel::Background::BackgroundTaskRegistration::AllTasks() };

bool taskRegistered{ false };
for (auto const& task : allTasks)
{
    if (task.Value().Name() == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }
}

// The code in the next step goes here.
```

```cpp
boolean taskRegistered = false;
Platform::String^ exampleTaskName = "ExampleBackgroundTask";

auto iter = BackgroundTaskRegistration::AllTasks->First();
auto hascur = iter->HasCurrent;

while (hascur)
{
    auto cur = iter->Current->Value;

    if(cur->Name == exampleTaskName)
    {
        taskRegistered = true;
        break;
    }

    hascur = iter->MoveNext();
}
```

2.  バックグラウンド タスクがまだ登録されていない場合は、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) を使ってバックグラウンド タスクのインスタンスを作成します。 タスクのエントリ ポイントには、名前空間を含めてバックグラウンド タスク クラスの名前を指定します。

バックグラウンド タスク トリガーは、バックグラウンド タスクが実行されるタイミングを制御します。 指定できるトリガーの一覧については、「[**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839)」をご覧ください。

たとえば、このコードは、新しいバック グラウンド タスクを作成し、 **TimeZoneChanged**トリガーが発生したときに実行するように設定します。

```csharp
var builder = new BackgroundTaskBuilder();

builder.Name = exampleTaskName;
builder.TaskEntryPoint = "Tasks.ExampleBackgroundTask";
builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
```

```cppwinrt
if (!taskRegistered)
{
    Windows::ApplicationModel::Background::BackgroundTaskBuilder builder;
    builder.Name(exampleTaskName);
    builder.TaskEntryPoint(L"Tasks.ExampleBackgroundTask");
    builder.SetTrigger(Windows::ApplicationModel::Background::SystemTrigger{
        Windows::ApplicationModel::Background::SystemTriggerType::TimeZoneChange, false });
    // The code in the next step goes here.
}
```

```cpp
auto builder = ref new BackgroundTaskBuilder();

builder->Name = exampleTaskName;
builder->TaskEntryPoint = "Tasks.ExampleBackgroundTask";
builder->SetTrigger(ref new SystemTrigger(SystemTriggerType::TimeZoneChange, false));
```

3.  トリガー イベントの発生後、どのようなときにタスクを実行するかという条件を追加することもできます (省略可能)。 たとえば、ユーザーが存在するときにだけタスクを実行する場合、**UserPresent** という条件を使います。 指定できる条件の一覧については、「[**SystemConditionType**](https://msdn.microsoft.com/library/windows/apps/br224835)」をご覧ください。

次のサンプル コードでは、"ユーザーの存在" を条件として割り当てています。

```csharp
builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));
```

```cppwinrt
builder.AddCondition(Windows::ApplicationModel::Background::SystemCondition{ Windows::ApplicationModel::Background::SystemConditionType::UserPresent });
// The code in the next step goes here.
```

```cpp
builder->AddCondition(ref new SystemCondition(SystemConditionType::UserPresent));
```

4.  [**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで Register メソッドを呼び出してバックグラウンド タスクを登録します。 [**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) の結果は、次の手順に備えて保存します。

バックグラウンド タスクを登録し、その結果を保存するコードを次に示します。

```csharp
BackgroundTaskRegistration task = builder.Register();
```

```cppwinrt
Windows::ApplicationModel::Background::BackgroundTaskRegistration task{ builder.Register() };
```

```cpp
BackgroundTaskRegistration^ task = builder->Register();
```

> [!NOTE]
> ユニバーサル Windows アプリは、どの種類のバックグラウンド トリガーを登録する場合でも、先に [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) を呼び出す必要があります。

更新プログラムのリリース後にユニバーサル Windows アプリが引き続き適切に実行されるようにするには、**ServicingComplete** ([SystemTriggerType](https://msdn.microsoft.com/library/windows/apps/br224839) に関するページをご覧ください) トリガーを使って、アプリのデータベースの移行やバックグラウンド タスクの登録などの更新後の構成の変更を実行します。 現時点で、アプリの以前のバージョンに関連付けられたバックグラウンド タスクの登録を解除してから ([**RemoveAccess**](https://msdn.microsoft.com/library/windows/apps/hh700471) に関するページをご覧ください)、アプリの新しいバージョンのバックグラウンド タスクを登録する ([**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) に関するページをご覧ください) ことをお勧めします。

詳しくは、「[バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)」をご覧ください。

## <a name="handle-background-task-completion-using-event-handlers"></a>イベント ハンドラーでバックグラウンド タスクの完了を処理する

アプリからバックグラウンド タスクの結果を取得できるように、[**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) にメソッドを登録します。 アプリが起動、または再開するときは、前回がアプリをフォア グラウンドからバック グラウンド タスクが完了した場合マークされたメソッドが呼び出されます。 (アプリがフォアグラウンドにある間にバックグラウンド タスクが終了した場合は、OnCompleted メソッドが直ちに呼び出されます)。

1.  バックグラウンド タスクの完了を処理する OnCompleted メソッドを記述します。 たとえば、バックグラウンド タスクの結果により UI を更新できます。 ここに示すメソッドのフットプリントは、この例では *args* パラメーターは使われていませんが、OnCompleted イベント ハンドラー メソッドで必須になります。

次のサンプル コードは、バックグラウンド タスクの完了を認識し、メッセージ文字列を使う UI 更新メソッドの例を呼び出します。

```csharp
private void OnCompleted(IBackgroundTaskRegistration task, BackgroundTaskCompletedEventArgs args)
{
    var settings = Windows.Storage.ApplicationData.Current.LocalSettings;
    var key = task.TaskId.ToString();
    var message = settings.Values[key].ToString();
    UpdateUI(message);
}
```

```cppwinrt
void UpdateUI(winrt::hstring const& message)
{
    MyTextBlock().Dispatcher().RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal, [=]()
    {
        MyTextBlock().Text(message);
    });
}

void OnCompleted(
    Windows::ApplicationModel::Background::BackgroundTaskRegistration const& sender,
    Windows::ApplicationModel::Background::BackgroundTaskCompletedEventArgs const& /* args */)
{
    // You'll previously have inserted this key into local settings.
    auto settings{ Windows::Storage::ApplicationData::Current().LocalSettings().Values() };
    auto key{ winrt::to_hstring(sender.TaskId()) };
    auto message{ winrt::unbox_value<winrt::hstring>(settings.Lookup(key)) };

    UpdateUI(message);
}
```

```cpp
void MainPage::OnCompleted(BackgroundTaskRegistration^ task, BackgroundTaskCompletedEventArgs^ args)
{
    auto settings = ApplicationData::Current->LocalSettings->Values;
    auto key = task->TaskId.ToString();
    auto message = dynamic_cast<String^>(settings->Lookup(key));
    UpdateUI(message);
}
```

> [!NOTE]
> UI の更新は、UI スレッドを拘束することがないように、非同期で実行する必要があります。 例については、[バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)の UpdateUI メソッドを参照してください。

2.  バックグラウンド タスクを登録した位置に戻ります。 そのコード行の後に、新しい [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) オブジェクトを追加します。 **BackgroundTaskCompletedEventHandler** コンストラクターのパラメーターとして OnCompleted メソッドを指定します。

次のサンプル コードにより、[**BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) に [**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) が追加されます。

```csharp
task.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);
```

```cppwinrt
task.Completed({ this, &MainPage::OnCompleted });
```

```cpp
task->Completed += ref new BackgroundTaskCompletedEventHandler(this, &MainPage::OnCompleted);
```

## <a name="declare-in-the-app-manifest-that-your-app-uses-background-tasks"></a>アプリがバック グラウンド タスクを使うことをアプリ マニフェストで宣言します。

アプリでバックグラウンド タスクを実行する前に、各バックグラウンド タスクをアプリ マニフェストで宣言する必要があります。 アプリがマニフェストに記載されていないトリガーでバック グラウンド タスクを登録しようとすると、バック グラウンド タスクの登録は"ランタイム クラスが登録されていない"というエラーで失敗します。

1.  Package.appxmanifest という名前のファイルを開いて、パッケージ マニフェスト デザイナーを開きます。
2.  **[宣言]** タブを開きます。
3.  **[使用可能な宣言]** ボックスの一覧の **[バックグラウンド タスク]** を選び、**[追加]** をクリックします。
4.  **[システム イベント]** チェック ボックスをオンにします。
5.  **エントリ ポイント:** textbox、この例では、Tasks.ExampleBackgroundTask のバック グラウンド クラスの名前と名前空間を入力します。
6.  マニフェスト デザイナーを閉じます。

バック グラウンド タスクを登録するために、次の Extensions 要素が Package.appxmanifest ファイルに追加されます。

```xml
<Extensions>
  <Extension Category="windows.backgroundTasks" EntryPoint="Tasks.ExampleBackgroundTask">
    <BackgroundTasks>
      <Task Type="systemEvent" />
    </BackgroundTasks>
  </Extension>
</Extensions>
```

## <a name="summary-and-next-steps"></a>要約と次のステップ

ここでは、バックグラウンド タスク クラスの記述方法、アプリ内からバックグラウンド タスクを登録する方法、バックグラウンド タスクが完了したことをアプリで認識する方法の基本について学習しました。 また、アプリで適切にバックグラウンド タスクを登録できるように、アプリ マニフェストを更新する方法についても学習しました。

> [!NOTE]
> [バックグラウンド タスクのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、バックグラウンド タスクを使う完全で堅牢な UWP アプリのコンテキストで類似のコード例を確認してください。

API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。

## <a name="related-topics"></a>関連トピック

**バックグラウンド タスクに関する手順を詳しく説明するトピック**

* [バックグラウンド タスクによるシステム イベントへの応答](respond-to-system-events-with-background-tasks.md)
* [バックグラウンド タスクの登録](register-a-background-task.md)
* [バックグラウンド タスクを実行するための条件の設定](set-conditions-for-running-a-background-task.md)
* [メンテナンス トリガーの使用](use-a-maintenance-trigger.md)
* [取り消されたバックグラウンド タスクの処理](handle-a-cancelled-background-task.md)
* [バックグラウンド タスクの進捗状況と完了の監視](monitor-background-task-progress-and-completion.md)
* [タイマーでのバックグラウンド タスクの実行](run-a-background-task-on-a-timer-.md)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)。
* [アウトプロセスのバックグラウンド タスクをインプロセスのバックグラウンド タスクへ変換](convert-out-of-process-background-task.md)  

**バックグラウンド タスクのガイダンス**

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バックグラウンド タスクのデバッグ](debug-a-background-task.md)
* [UWP アプリで一時停止イベント、再開イベント、バックグラウンド イベントをトリガーする方法 (デバッグ時)](http://go.microsoft.com/fwlink/p/?linkid=254345)

**バックグラウンド タスクの API リファレンス**

* [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)
