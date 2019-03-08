---
title: アウトプロセス バックグラウンド タスクの作成と登録
description: アウトプロセスのバックグラウンド タスク クラスを作り、アプリがフォアグラウンドにない場合に実行されるように登録します。
ms.assetid: 4F98F6A3-0D3D-4EFB-BA8E-30ED37AE098B
ms.date: 07/02/2018
ms.topic: article
keywords: windows 10、uwp、バック グラウンド タスク
ms.localizationpriority: medium
dev_langs:
- csharp
- cppwinrt
- cpp
ms.openlocfilehash: 9df6eef44d45db37e17610d6a5333f3a387b5cf6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592167"
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

[  **IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装するクラスを作ると、コードをバックグラウンドで実行できます。 次のコード実行など、特定のイベントを使用すると、トリガーされたときに[ **SystemTrigger** ](https://msdn.microsoft.com/library/windows/apps/br224839)または[ **MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517)します。

次の手順では、[**IBackgroundTask**](https://msdn.microsoft.com/library/windows/apps/br224794) インターフェイスを実装する新しいクラスを記述する方法について説明します。

1.  バックグラウンド タスク用に新しいプロジェクトを作ってソリューションに追加します。 これを行うには、ソリューション ノードを右クリックし、**ソリューション エクスプ ローラー**選択**追加** \> **新しいプロジェクト**します。 選択し、 **Windows ランタイム コンポーネント**プロジェクトの種類と、プロジェクトの名前、[ok] をクリックします。
2.  ユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトからバックグラウンド タスク プロジェクトを参照します。 C#を右クリックし、アプリ プロジェクトでの C++ アプリまたは**参照**選択**新しい参照の追加**します。 **[ソリューション]** で、**[プロジェクト]** を選び、バックグラウンド タスク プロジェクトの名前を選んで **[OK]** をクリックします。
3.  バック グラウンド タスク プロジェクトに実装する新しいクラスを追加、 [ **IBackgroundTask** ](/uwp/api/Windows.ApplicationModel.Background.IBackgroundTask)インターフェイス。 [ **IBackgroundTask.Run** ](/uwp/api/windows.applicationmodel.background.ibackgroundtask.run)メソッドは、指定したイベントがトリガーされたときに呼び出される必要なエントリ ポイントは、すべてのバック グラウンド タスクにこのメソッドが必要です。

> [!NOTE]
> バック グラウンド タスク クラス自体&mdash;とバック グラウンド タスクのプロジェクトで他のすべてのクラス&mdash;する必要がある**パブリック**クラス**シール**(または**最終**).

次のサンプル コードでは、バック グラウンド タスクのクラスの場合は、非常に基本的な開始点を示します。

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

4.  バックグラウンド タスクで非同期コードを実行する場合は、バックグラウンド タスクで遅延を使う必要があります。 場合、遅延を使用しない場合に、バック グラウンド タスク プロセスによって予期せず終了、**実行**非同期作業の実行が完了する前に、メソッドが返されます。

要求で遅延、**実行**メソッドが非同期のメソッドを呼び出す前にします。 非同期メソッドからアクセスできるように、クラスのデータ メンバーに、遅延を保存します。 非同期コードが完了した後、遅延を完了するように宣言します。

次のサンプル コードは、遅延を取得し、保存します、および非同期コードが完了すると、それを解放します。

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
> C# では、**async/await** キーワードを使ってバックグラウンド タスクの非同期メソッドを呼び出すことができます。 C++/cli CX、タスクのチェーンを使用して、同様の結果を実現できます。

非同期パターンについて詳しくは、「[非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187335)」をご覧ください。 遅延を使ってバックグラウンド タスクの早期停止を防ぐ方法に関するその他の例については、[バックグラウンド タスクのサンプルに関するページ](https://go.microsoft.com/fwlink/p/?LinkId=618666)をご覧ください。

次の手順はいずれかのアプリ クラス (MainPage.xaml.cs など) で実行します。

> [!NOTE]
> 専用のバック グラウンド タスクを登録する関数を作成することもできます。&mdash;を参照してください[バック グラウンド タスクを登録](register-a-background-task.md)します。 その場合は、次の 3 つの手順を使用する代わりに単に、トリガーを構築できタスク名、タスクのエントリ ポイント、および (必要に応じて) 条件と共に登録関数に提供できます。

## <a name="register-the-background-task-to-run"></a>実行するバックグラウンド タスクを登録する

1.  反復処理するバック グラウンド タスクが既に登録されているかどうかを調べる、 [ **BackgroundTaskRegistration.AllTasks** ](https://msdn.microsoft.com/library/windows/apps/br224787)プロパティ。 この確認は重要です。既にあるバックグラウンド タスクの二重登録をアプリで確認しなかった場合、同じタスクが何度も登録され、パフォーマンスが低下したり、タスクの CPU 時間を使い切って処理を完了できなくなるなどの問題が生じます。

次の例を反復処理、 **AllTasks**プロパティおよびタスクは既に登録されている場合は true にフラグ変数を設定します。

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

たとえば、このコードは新しいバック グラウンド タスクを作成し、時に実行するように設定、 **TimeZoneChanged**トリガーが発生します。

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

4.  [  **BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトで Register メソッドを呼び出してバックグラウンド タスクを登録します。 [  **BackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/br224786) の結果は、次の手順に備えて保存します。

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

アプリからバックグラウンド タスクの結果を取得できるように、[**BackgroundTaskCompletedEventHandler**](https://msdn.microsoft.com/library/windows/apps/br224781) にメソッドを登録します。 アプリが起動または再開時に前回のフォア グラウンドでのアプリがバック グラウンド タスクが完了した場合、マークされたメソッドが呼び出されます。 (アプリがフォアグラウンドにある間にバックグラウンド タスクが終了した場合は、OnCompleted メソッドが直ちに呼び出されます)。

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
> UI の更新は、UI スレッドを拘束することがないように、非同期で実行する必要があります。 例については、[バックグラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)の UpdateUI メソッドを参照してください。

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

## <a name="declare-in-the-app-manifest-that-your-app-uses-background-tasks"></a>アプリがバック グラウンド タスクを使用して、アプリ マニフェストで宣言します。

アプリでバックグラウンド タスクを実行する前に、各バックグラウンド タスクをアプリ マニフェストで宣言する必要があります。 アプリがトリガーのあるマニフェストの一覧にないバック グラウンド タスクを登録しようとすると、バック グラウンド タスクの登録は「クラスのランタイムに登録されていません」エラーで失敗します。

1.  Package.appxmanifest という名前のファイルを開いて、パッケージ マニフェスト デザイナーを開きます。
2.  **[宣言]** タブを開きます。
3.  **[使用可能な宣言]** ボックスの一覧の **[バックグラウンド タスク]** を選び、**[追加]** をクリックします。
4.  **[システム イベント]** チェック ボックスをオンにします。
5.  **エントリ ポイント:** テキスト ボックスに、この例は Tasks.ExampleBackgroundTask はバック グラウンド クラスの名前と名前空間を入力します。
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
> [バックグラウンド タスクのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=618666)をダウンロードして、バックグラウンド タスクを使う完全で堅牢な UWP アプリのコンテキストで類似のコード例を確認してください。

API リファレンス、バックグラウンド タスクの概念的ガイダンス、バックグラウンド タスクを使ったアプリの作成に関する詳しい説明については、次の関連するトピックをご覧ください。

## <a name="related-topics"></a>関連トピック

**詳細なバック グラウンド タスクの説明のトピック**

* [バック グラウンド タスクでシステム イベントに応答します。](respond-to-system-events-with-background-tasks.md)
* [バック グラウンド タスクを登録します。](register-a-background-task.md)
* [バック グラウンド タスクを実行するための条件を設定します。](set-conditions-for-running-a-background-task.md)
* [メンテナンス トリガーを使用します。](use-a-maintenance-trigger.md)
* [取り消されたバック グラウンド タスクを処理します。](handle-a-cancelled-background-task.md)
* [バック グラウンド タスクの進行状況と完了を監視します。](monitor-background-task-progress-and-completion.md)
* [タイマーでバック グラウンド タスクを実行します。](run-a-background-task-on-a-timer-.md)
* [インプロセス バックグラウンド タスクの作成と登録](create-and-register-an-inproc-background-task.md)
* [プロセス内のバック グラウンド タスクに、プロセス外のバック グラウンド タスクを変換します。](convert-out-of-process-background-task.md)  

**バック グラウンド タスクのガイダンス**

* [バックグラウンド タスクのガイドライン](guidelines-for-background-tasks.md)
* [バック グラウンド タスクをデバッグします。](debug-a-background-task.md)
* [トリガーする方法を中断、再開、および (デバッグ) 場合は、UWP アプリでイベントをバック グラウンド](https://go.microsoft.com/fwlink/p/?linkid=254345)

**バック グラウンド タスクの API リファレンス**

* [**Windows.ApplicationModel.Background**](https://msdn.microsoft.com/library/windows/apps/br224847)
