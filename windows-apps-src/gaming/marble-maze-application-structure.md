---
author: eliotcowley
title: Marble Maze のアプリケーション構造
description: DirectX ユニバーサル Windows プラットフォーム (UWP) アプリの構造は、従来のデスクトップ アプリケーションとは異なります。
ms.assetid: 6080f0d3-478a-8bbe-d064-73fd3d432074
ms.author: elcowle
ms.date: 09/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サンプル, DirectX, 構造
ms.localizationpriority: medium
ms.openlocfilehash: 1272200bf128443c82807aec9df5559f207819e1
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5569118"
---
# <a name="marble-maze-application-structure"></a>Marble Maze のアプリケーション構造




DirectX ユニバーサル Windows プラットフォーム (UWP) アプリの構造は、従来のデスクトップ アプリケーションとは異なります。 [HWND](https://msdn.microsoft.com/library/windows/desktop/aa383751) などのハンドル型や [CreateWindow](https://msdn.microsoft.com/library/windows/desktop/ms632679) などの関数は使いません。それよりも新しい、オブジェクト指向に沿った方法で UWP アプリを開発できるように、Windows ランタイムには [Windows::UI::Core::ICoreWindow](https://msdn.microsoft.com/library/windows/apps/br208296) をはじめとするインターフェイスが用意されています。 ここでは、Marble Maze アプリ コードがどのように構成されているかを確認します。

> [!NOTE]
> このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

 
## 
このドキュメントでは、ゲーム コードを構成する際に重要となるいくつかのことがらについて説明します。取り上げる内容は次のとおりです。

-   初期化フェーズでは、ゲームで使うランタイムとライブラリ コンポーネントをセットアップし、ゲーム固有のリソースを読み込みます。
-   UWP アプリは、起動から 5 秒以内にイベントの処理を開始する必要があります。 そのため、アプリを読み込むときは、主要なリソースだけを読み込みます。 大きなリソースはバックグラウンドで読み込んで、進行状況画面を表示する必要があります。
-   ゲーム ループでは、Windows イベントへの応答、ユーザー入力の読み取り、シーン オブジェクトの更新、シーンの表示を行います。
-   イベント ハンドラーを使って、ウィンドウのイベントに応答します。 これは、デスクトップ Windows アプリケーションからのウィンドウ メッセージに代わるものです。
-   ステート マシンを使って、ゲーム ロジックのフローと順序を制御します。

##  <a name="file-organization"></a>ファイルの構成


Marble Maze の一部のコンポーネントは、変更なしで、またはわずかな変更だけで、任意のゲームに再利用できます。 独自のゲームを開発する際には、これらのファイルから得られたアイデアや構造を応用できます。 次の表は、重要なソース コード ファイルについて簡単に説明しています。

| ファイル                                      | 説明                                                                                                                                                                          |
|--------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| App.h、App.cpp               | アプリのビュー (ウィンドウ、スレッド、イベント) をカプセル化する **App** クラスと **DirectXApplicationSource** クラスを定義しています。                                                     |
| Audio.h、Audio.cpp                         | オーディオ リソースを管理する **Audio** クラスを定義しています。                                                                                                                          |
| BasicLoader.h、BasicLoader.cpp             | テクスチャ、メッシュ、シェーダーの読み込みに役立つユーティリティ メソッドを提供する **BasicLoader** クラスを定義しています。                                                                  |
| BasicMath.h                                | ベクターやマトリックスのデータと計算の操作に役立つ構造と関数を定義しています。 これらの関数の多くは、HLSL シェーダーの種類と互換性があります。                     |
| BasicReaderWriter.h、BasicReaderWriter.cpp | UWP アプリのファイル データの読み取りと書き込みのために Windows ランタイムを使う **BasicReaderWriter** クラスを定義しています。                                                                    |
| BasicShapes.h、BasicShapes.cpp             | 立方体や球体などの基本的な図形を作るためのユーティリティ メソッドを提供する **BasicShapes** クラスを定義しています。 これらのファイルは、Marble Maze の実装では使用されません。 |                                                                                  |
| Camera.h、Camera.cpp                       | カメラの位置と向きを保持する **Camera** クラスを定義しています。                                                                                               |
| Collision.h、Collision.cpp                 | 大理石と、迷路などの他のオブジェクトとの衝突情報を管理します。                                                                                                       |
| DDSTextureLoader.h、DDSTextureLoader.cpp   | メモリ バッファーから .dds 形式のテクスチャを読み込む **CreateDDSTextureFromMemory** 関数を定義しています。                                                              |
| DirectXHelper.h             | 多くの DirectX UWP アプリに有用な DirectX ヘルパー関数を定義しています。                                                                            |
| LoadScreen.h、LoadScreen.cpp               | アプリの初期化時に読み込み画面を表示する **LoadScreen** クラスを定義しています。                                                                                         |
| MarbleMazeMain.h、MarbleMazeMain.cpp               | ゲーム固有のリソースを管理し、ゲーム ロジックの多くを定義する **MarbleMazeMain** クラスを定義しています。                                                                          |
| MediaStreamer.h、MediaStreamer.cpp         | メディア ファンデーションを使ってゲームによるオーディオ リソースの管理を補助する **MediaStreamer** クラスを定義しています。                                                                            |
| PersistentState.h、PersistentState.cpp     | バッキング ストアとの間でプリミティブ データ型の読み取りと書き込みを行う **PersistentState** クラスを定義しています。                                                                      |
| Physics.h、Physics.cpp                     | 大理石と迷路間の物理シミュレーションを実装する **Physics** クラスを定義しています。                                                                              |
| Primitives.h                               | ゲームで使われる幾何学型を定義しています。                                                                                                                                   |
| SampleOverlay.h、SampleOverlay.cpp         | 一般的な 2D とユーザー インターフェイスのデータと操作を提供する **SampleOverlay** クラスを定義しています。                                                                               |
| SDKMesh.h、SDKMesh.cpp                     | SDK メッシュ (.sdkmesh) 形式のメッシュを読み込んで表示する **SDKMesh** クラスを定義しています。                                                                                |
| StepTimer.h               | 合計時間と経過時間を簡単に取得できるようにする **StepTimer** クラスを定義しています。
| UserInterface.h、UserInterface.cpp         | メニュー システムやハイ スコア表などのユーザー インターフェイスに関連する機能を定義しています。                                                                        |

 

##  <a name="design-time-versus-run-time-resource-formats"></a>設計時と実行時のリソース形式


できれば、より効率的にゲームのリソースを読み込むために、設計時形式ではなく実行時形式を使います。

*設計時*形式は、リソースを設計するときに使う形式です。 通常、3D デザイナーは設計時形式で作業します。 一部の設計時形式はテキスト ベースであり、任意のテキスト ベース エディターで変更できます。 設計時形式は冗長で、ゲームが必要とするよりも多くの情報を持っている場合があります。 *実行時*形式は、ゲームが読み取るバイナリ形式です。 実行時形式は通常、対応する設計時形式よりもコンパクトで、効率的に読み込むことができます。 そのため、ゲームの大多数は実行時に実行時アセットを使います。

ゲームは設計時形式を直接読み取れますが、別の実行時形式を使うことには、いくつかの利点があります。 実行時形式は多くの場合、よりコンパクトであり、必要なディスク領域が少なく、ネットワークでの転送にかかる時間も短くなります。 また、実行時形式は通常、メモリ マップ データ構造として表されます。 そのため、XML ベースのテキスト ファイルなどよりも大幅に速くメモリに読み込むことができます。 さらに、個別の実行時形式は通常はバイナリ形式でエンコードされており、エンド ユーザーによる変更がより難しくなっています。

HLSL シェーダーは、設計時と実行時で異なる形式を使うリソースの 1 例です。 Marble Maze は、設計時形式として .hlsl、実行時形式として .cso を使います。 .hlsl ファイルはシェーダーのソース コードを保持します。.cso ファイルは対応するシェーダーのバイト コードを保持します。 オフラインで .hlsl ファイルを変換してゲームに .cso ファイルを渡すと、ゲームの読み込み時に HLSL ソース ファイルをバイト コードに変換する必要がなくなります。

教育的な理由で、Marble Maze プロジェクトには多くのリソースの設計時形式と実行時形式の両方が含まれていますが、ゲームのソース プロジェクトで保持する必要があるのは設計時形式だけです。実行時形式には、必要になったときに変換します。 このドキュメントでは、設計時形式を実行時形式に変換する方法について説明しています。

##  <a name="application-life-cycle"></a>アプリケーション ライフ サイクル


Marble Maze は、一般的な UWP アプリのライフ サイクルに従っています。 UWP アプリのライフ サイクルについて詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)」をご覧ください。

UWP ゲームの初期化時には、通常、Direct3D、Direct2D などのランタイム コンポーネントと、ゲームで使われる入力、オーディオ、または物理ライブラリが初期化されます。 また、ゲームを開始する前に必要なゲーム固有のリソースも読み込まれます。 この初期化は、ゲーム セッション中に 1 回行われます。

初期化後、ゲームは通常、*ゲーム ループ*を実行します。 このループでは、ゲームは通常、4 つの操作を実行します。それらは、Windows イベントの処理、入力の収集、シーン オブジェクトの更新、シーンの表示です。 ゲームがシーンを更新するときに、現在の入力状態をシーン オブジェクトに適用し、オブジェクトの衝突などの物理的なイベントをシミュレートすることができます。 また、効果音の再生やネットワーク経由のデータ送信など、その他のアクティビティも実行できます。 ゲームがシーンを表示するときに、シーンの現在の状態がキャプチャされ、ディスプレイ デバイスに描画されます。 以降のセクションでは、これらのアクティビティについてさらに詳しく説明します。

##  <a name="adding-to-the-template"></a>テンプレートへの追加


**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートは、Direct3D によるレンダリング先にできるコア ウィンドウを作成します。 また、テンプレートには、UWP アプリで 3D コンテンツをレンダリングする際に必要な Direct3D デバイス リソースをすべて作成する **DeviceResources** クラスも含まれています。

**App** クラスは、**MarbleMazeMain** クラス オブジェクトを作成し、リソースの読み込みを開始し、ループしてタイマーを更新し、フレームごとに **MarbleMazeMain::Render** レンダリング メソッドを呼び出します。 **App::OnWindowSizeChanged**、**App::OnDpiChanged**、および **App::OnOrientationChanged** メソッドはそれぞれ **MarbleMazeMain::CreateWindowSizeDependentResources** メソッドを呼び出し、**App::Run** メソッドは **MarbleMazeMain::Update** および **MarbleMazeMain::Render** メソッドを呼び出します。

次の例は、**App::SetWindow** メソッドが **MarbleMazeMain** クラス オブジェクトを作成する箇所を示しています。 Direct3D オブジェクトを使ってレンダリングできるように、**DeviceResources** クラスがメソッドに渡されます。

```cpp
    m_main = std::unique_ptr<MarbleMazeMain>(new MarbleMazeMain(m_deviceResources));
```

**App** クラスは、ゲームのリソースの遅延読み込みも開始します。 詳しくは、次のセクションをご覧ください。

さらに、**App** クラスは [CoreWindow](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow) イベント用のイベント ハンドラーをセットアップします。 これらのイベントのハンドラーが呼び出されると、入力が **MarbleMazeMain** クラスに渡されます。

## <a name="loading-game-assets-in-the-background"></a>バックグラウンドでのゲーム アセットの読み込み


起動後 5 秒以内にゲームがウィンドウ イベントに応答できるようにするために、ゲーム アセットは非同期的に、またはバックグラウンドで読み込むことをお勧めします。 バックグラウンドでのアセットの読み込み中、ゲームはウィンドウ イベントに応答できます。

> [!NOTE]
> また、準備ができたらメイン メニューを表示することもでき、残りのアセットをバックグラウンドで読み込み続けることができます。 すべてのリソースが読み込まれる前にユーザーがメニューのオプションを選択した場合は、進行状況バーを表示するなどして、シーン リソースが読み込み中であることを示すことができます。

 

ゲームに含まれているゲーム アセットが比較的少ない場合でも、非同期的に読み込むことをお勧めします。これには 2 つの理由があります。 1 つの理由は、すべてのデバイスとすべての構成ですべてのリソースをすばやく読み込めることを保証することが難しいことです。 また、非同期的な読み込みを早期に組み込むことによって、機能の追加による規模の拡大にもコードが対応できるようになります。

非同期のアセット読み込みは、**App::Load** メソッドで始まります。 このメソッドは [task](https://docs.microsoft.com/cpp/parallel/concrt/reference/task-class) クラスを使って、バックグラウンドでゲーム アセットを読み込みます。

```cpp
    task<void>([=]()
    {
        m_main->LoadDeferredResources(true, false);
    });
```

**MarbleMazeMain** クラスは、非同期読み込みが完了したことを示す *m\_deferredResourcesReady* フラグを定義します。 **MarbleMazeMain::LoadDeferredResources** メソッドは、ゲーム リソースを読み込んで、このフラグを設定します。 アプリの更新 (**MarbleMazeMain::Update**) フェーズとレンダリング (**MarbleMazeMain::Render**) フェーズでは、このフラグを確認します。 このフラグが設定されると、ゲームは正常に続行されます。 フラグがまだ設定されていない場合、ゲームは読み込み画面を表示します。

UWP アプリの非同期プログラミングについて詳しくは、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」をご覧ください。

> [!TIP]
> Windows ランタイム C++ ライブラリの一部であるゲーム コード (つまり DLL) を記述している場合は、アプリとその他のライブラリで使える非同期操作を作る方法を学ぶために「[UWP アプリ用に C++ で非同期操作を作成](https://docs.microsoft.com/cpp/parallel/concrt/creating-asynchronous-operations-in-cpp-for-windows-store-apps)」を読むことを検討してください。

 

## <a name="the-game-loop"></a>ゲーム ループ


**App::Run** メソッドは、メイン ゲーム ループ (**MarbleMazeMain::Update**) を実行します。 このメソッドはフレームごとに呼び出されます。

ゲーム固有のコードからビューとウィンドウのコードを分離しやすくするために、**App::Run** メソッドの実装では更新とレンダリングの呼び出しが **MarbleMazeMain** オブジェクトに転送されています。

次の例は、メイン ゲーム ループが含まれている **App::Run** メソッドを示しています。 ゲーム ループは合計時間とフレーム時間の変数を更新し、シーンの更新とレンダリングを行います。 これにより、ウィンドウが表示されているときにだけコンテンツがレンダリングされることも保証されます。

```cpp
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->
                ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->
                ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }

    // The app is exiting so do the same thing as if the app were being suspended.
    m_main->OnSuspending();

#ifdef _DEBUG
    // Dump debug info when exiting.
    DumpD3DDebug();
#endif //_DEGBUG
}
```

## <a name="the-state-machine"></a>ステート マシン


ゲームは通常、ゲーム ロジックのフローと順序を制御するために、*ステート マシン* (*有限ステート マシン*、FSM とも呼ばれます) を備えています。 ステート マシンには、特定の数の状態と、状態間を遷移する機能が含まれています。 通常、ステート マシンは*初期*状態から始まり、1 つ以上の*中間*状態に遷移し、*終端*状態で終了します。

ゲーム ループでは多くの場合、現在のゲームの状態に固有のロジックを実行できるように、ステート マシンを使います。 Marble Maze では、ゲームの各状態を定義する **GameState** 列挙が定義されています。

```cpp
enum class GameState
{
    Initial,
    MainMenu,
    HighScoreDisplay,
    PreGameCountdown,
    InGameActive,
    InGamePaused,
    PostGameResults,
};
```

たとえば、**MainMenu** 状態は、メイン メニューが表示され、ゲームがアクティブでないと定義されています。 反対に、**InGameActive** 状態は、ゲームがアクティブで、メニューが表示されていないと定義されています。 **MarbleMazeMain** クラスは、アクティブなゲームの状態を保持するために、**m\_gameState** メンバー変数を定義しています。

**MarbleMazeMain::Update** メソッドと **MarbleMazeMain::Render** メソッドは、現在の状態のロジックを実行するために、switch ステートメントを使います。 次の例は、**MarbleMazeMain::Update** メソッドでのこの switch ステートメントがどのようなものかを示しています (構造をわかりやすく示すために、細部は削除されています)。

```cpp
switch (m_gameState)
{
case GameState::MainMenu:
    // Do something with the main menu. 
    break;

case GameState::HighScoreDisplay:
    // Do something with the high-score table. 
    break;

case GameState::PostGameResults:
    // Do something with the game results. 
    break;

case GameState::InGamePaused:
    // Handle the paused state. 
    break;
}
```

ゲーム ロジックまたはレンダリングが特定のゲーム状態に依存する場合、このドキュメントではそれを強調して示しています。

## <a name="handling-app-and-window-events"></a>アプリとウィンドウのイベントの処理


Windows ランタイムには、Windows メッセージをより簡単に管理できるようにするために、オブジェクト指向のイベント処理システムが用意されています。 アプリケーションのイベントを使うには、イベントに応答するイベント ハンドラーまたはイベント処理メソッドを準備する必要があります。 また、イベント ハンドラーをイベント ソースに登録する必要もあります。 このプロセスは、一般に、イベントの関連付けと呼ばれます。

### <a name="supporting-suspend-resume-and-restart"></a>中断、再開、再起動の処理

ユーザーがアプリを切り替えた場合、または Windows が低電力状態に切り替わった場合は、Marble Maze を中断できます。 ゲームは、ユーザーがフォアグラウンドにゲームを移行した場合、または Windows が低電力状態から復帰した場合に再開されます。 通常は、アプリを閉じません。 アプリが中断状態にあり、アプリが使っているメモリなどのリソースを Windows が必要とする場合、Windows はアプリを終了できます。 アプリが中断または再開されるときに、Windows はアプリに通知しますが、終了されるときには通知しません。 そのため、アプリが中断されることを Windows がアプリに通知した時点で、アプリが再起動されるときに現在のユーザー状態を復元するために必要なすべてのデータをアプリが保存できる必要があります。 保存の負荷が高い特別なユーザー状態がアプリにある場合は、アプリが中断通知を受信する前であっても、状態を定期的に保存する必要があります。 Marble Maze は、次の 2 つの理由で、中断と再開の通知に応答します。

1.  アプリが一時停止されるときに、ゲームは現在のゲーム状態を保存し、オーディオの再生を一時停止します。 アプリが再開されるときに、ゲームはオーディオ再生を再開します。
2.  アプリが閉じられ、後で再起動されるとき、ゲームは前の状態から再開します。

Marble Maze は、中断と再開をサポートするために、次のタスクを実行します。

-   ユーザーがチェックポイントに達したときのような、ゲームの重要なポイントで、状態を固定ストレージに保存します。
-   中断の通知に対応して、状態を固定ストレージに保存します。
-   再開の通知に対応して、状態を固定ストレージから読み込みます。 起動中に、以前の状態も読み込みます。

中断と再開をサポートするために、Marble Maze は **PersistentState** クラスを定義しています。 **PersistentState.h** と **PersistentState.cpp** をご覧ください。 このクラスは、プロパティの読み取りと書き込みに [Windows::Foundation::Collections::IPropertySet](https://docs.microsoft.com/uwp/api/Windows.Foundation.Collections.IPropertySet) インターフェイスを使います。 **PersistentState** クラスには、バッキング ストアとの間でプリミティブ データ型 (**bool**、**int**、**float**、[XMFLOAT3](https://msdn.microsoft.com/library/windows/desktop/ee419475)、[Platform::String](https://docs.microsoft.com/cpp/cppcx/platform-string-class) など) の読み取りと書き込みを行うメソッドが用意されています。

```cpp
ref class PersistentState
{
internal:
    void Initialize(
        _In_ Windows::Foundation::Collections::IPropertySet^ settingsValues,
        _In_ Platform::String^ key
        );

    void SaveBool(Platform::String^ key, bool value);
    void SaveInt32(Platform::String^ key, int value);
    void SaveSingle(Platform::String^ key, float value);
    void SaveXMFLOAT3(Platform::String^ key, DirectX::XMFLOAT3 value);
    void SaveString(Platform::String^ key, Platform::String^ string);

    bool LoadBool(Platform::String^ key, bool defaultValue);
    int  LoadInt32(Platform::String^ key, int defaultValue);
    float LoadSingle(Platform::String^ key, float defaultValue);

    DirectX::XMFLOAT3 LoadXMFLOAT3(
        Platform::String^ key, 
        DirectX::XMFLOAT3 defaultValue);

    Platform::String^ LoadString(
        Platform::String^ key, 
        Platform::String^ defaultValue);

private:
    Platform::String^ m_keyName;
    Windows::Foundation::Collections::IPropertySet^ m_settingsValues;
};
```

**MarbleMazeMain** クラスは **PersistentState** オブジェクトを保持しています。 **MarbleMazeMain** コンストラクターは、このオブジェクトを初期化し、ローカル アプリケーション データ ストアをバッキング データ ストアとして提供します。

```cpp
m_persistentState = ref new PersistentState();

m_persistentState->Initialize(
    Windows::Storage::ApplicationData::Current->LocalSettings->Values,
    "MarbleMaze");
```

Marble Maze は、大理石がチェックポイントやゴールを通過したときに **MarbleMazeMain::Update** メソッドで状態を保存し、ウィンドウからフォーカスが移動されたときに **MarbleMazeMain::OnFocusChange** メソッドで状態を保存します。 中断の通知に対処できる時間は数秒しかないので、ゲームが大量の状態データを保持する場合は、同様の方法でときどき状態を固定ストレージに保存することをお勧めします。 これにより、アプリが中断通知を受け取ったときに、変更があった状態データを保存するだけで済みます。

中断と再開の通知に応答するために、**MarbleMazeMain** クラスは、中断時と再開時に呼び出される **SaveState** メソッドと **LoadState** メソッドを定義します。 **MarbleMazeMain::OnSuspending** メソッドは中断イベントを処理し、**MarbleMazeMain::OnResuming** メソッドは再開イベントを処理します。

**MarbleMazeMain::OnSuspending** メソッドはゲーム状態を保存し、オーディオを一時停止します。

```cpp
void MarbleMazeMain::OnSuspending()
{
    SaveState();
    m_audio.SuspendAudio();
}
```

**MarbleMazeMain::SaveState** メソッドは、大理石の現在位置と速度、最新のチェックポイント、ハイ スコア表など、ゲームの状態の値を保存します。

```cpp
void MarbleMazeMain::SaveState()
{
    m_persistentState->SaveXMFLOAT3(":Position", m_physics.GetPosition());
    m_persistentState->SaveXMFLOAT3(":Velocity", m_physics.GetVelocity());

    m_persistentState->SaveSingle(
        ":ElapsedTime", 
        m_inGameStopwatchTimer.GetElapsedTime());

    m_persistentState->SaveInt32(":GameState", static_cast<int>(m_gameState));
    m_persistentState->SaveInt32(":Checkpoint", static_cast<int>(m_currentCheckpoint));

    int i = 0;
    HighScoreEntries entries = m_highScoreTable.GetEntries();
    const int bufferLength = 16;
    char16 str[bufferLength];

    m_persistentState->SaveInt32(":ScoreCount", static_cast<int>(entries.size()));

    for (auto iter = entries.begin(); iter != entries.end(); ++iter)
    {
        int len = swprintf_s(str, bufferLength, L"%d", i++);
        Platform::String^ string = ref new Platform::String(str, len);

        m_persistentState->SaveSingle(
            Platform::String::Concat(":ScoreTime", string), 
            iter->elapsedTime);

        m_persistentState->SaveString(
            Platform::String::Concat(":ScoreTag", string), 
            iter->tag);
    }
}
```

ゲームの再開時に必要なのは、オーディオの再開だけです。 状態は既にメモリに読み込まれているので、固定ストレージから状態を読み込む必要はありません。

オーディオの一時停止と再開の方法は、ドキュメント「[Marble Maze のサンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)」で説明されています。

再起動をサポートするために、起動中に呼び出される **MarbleMazeMain** コンストラクターは **MarbleMazeMain::LoadState** メソッドを呼び出します。 **MarbleMazeMain::LoadState** メソッドは状態を読み取り、その状態をゲーム オブジェクトに適用します。 また、このメソッドは、ゲームが中断されたときにゲームが一時停止またはアクティブであった場合は、現在のゲームの状態を一時停止に設定します。 突然動作が始まってユーザーを驚かせることがないように、ゲームを一時停止にします。 また、ゲームが中断されたときにゲームがゲームプレイ状態でなかった場合は、メイン メニューに移動します。

```cpp
void MarbleMazeMain::LoadState()
{
    XMFLOAT3 position = m_persistentState->LoadXMFLOAT3(
        ":Position", 
        m_physics.GetPosition());

    XMFLOAT3 velocity = m_persistentState->LoadXMFLOAT3(
        ":Velocity", 
        m_physics.GetVelocity());

    float elapsedTime = m_persistentState->LoadSingle(":ElapsedTime", 0.0f);

    int gameState = m_persistentState->LoadInt32(
        ":GameState", 
        static_cast<int>(m_gameState));

    int currentCheckpoint = m_persistentState->LoadInt32(
        ":Checkpoint", 
        static_cast<int>(m_currentCheckpoint));

    switch (static_cast<GameState>(gameState))
    {
    case GameState::Initial:
        break;

    case GameState::MainMenu:
    case GameState::HighScoreDisplay:
    case GameState::PreGameCountdown:
    case GameState::PostGameResults:
        SetGameState(GameState::MainMenu);
        break;

    case GameState::InGameActive:
    case GameState::InGamePaused:
        m_inGameStopwatchTimer.SetVisible(true);
        m_inGameStopwatchTimer.SetElapsedTime(elapsedTime);
        m_physics.SetPosition(position);
        m_physics.SetVelocity(velocity);
        m_currentCheckpoint = currentCheckpoint;
        SetGameState(GameState::InGamePaused);
        break;
    }

    int count = m_persistentState->LoadInt32(":ScoreCount", 0);

    const int bufferLength = 16;
    char16 str[bufferLength];

    for (int i = 0; i < count; i++)
    {
        HighScoreEntry entry;
        int len = swprintf_s(str, bufferLength, L"%d", i);
        Platform::String^ string = ref new Platform::String(str, len);

        entry.elapsedTime = m_persistentState->LoadSingle(
            Platform::String::Concat(":ScoreTime", string), 
            0.0f);

        entry.tag = m_persistentState->LoadString(
            Platform::String::Concat(":ScoreTag", string), 
            L"");

        m_highScoreTable.AddScoreToTable(entry);
    }
}
```

> [!IMPORTANT]
> Marble Maze は、コールド スタート (つまり、以前の中断イベントがない、初めての起動) と、中断状態からの再開とを区別しません。 これは、すべての UWP アプリにお勧めする設計です。

アプリケーション データについて詳しくは、「[設定と他のアプリ データを保存して取得する](https://msdn.microsoft.com/library/windows/apps/mt299098)」をご覧ください。

##  <a name="next-steps"></a>次の手順


視覚的なリソースを扱う際の主な手法については、「[Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)
* [Marble Maze サンプルの基礎](marble-maze-sample-fundamentals.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




