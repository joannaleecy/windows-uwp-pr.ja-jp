---
title: アプリ オブジェクトと DirectX
description: DirectX を使ったユニバーサル Windows プラットフォーム (UWP) ゲームでは、Windows UI ユーザー インターフェイスの要素とオブジェクトの多くが使われません。
ms.assetid: 46f92156-29f8-d65e-2587-7ba1de5b48a6
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、DirectX、アプリ オブジェクト
ms.localizationpriority: medium
ms.openlocfilehash: e12ad6ce221440e8840006b3883980721b899ae6
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7693153"
---
# <a name="the-app-object-and-directx"></a>アプリ オブジェクトと DirectX



DirectX を使ったユニバーサル Windows プラットフォーム (UWP) ゲームでは、Windows UI ユーザー インターフェイスの要素とオブジェクトの多くが使われません。 逆に、それらのアプリは Windows ランタイム スタックの下位レベルで実行されることから、アプリ オブジェクトに直接アクセスして相互運用するという基本的な方法でユーザー インターフェイス フレームワークと相互運用する必要があります。 ここでは、この相互運用をいつどのように行うかと、DirectX 開発者が UWP アプリの開発でこのモデルを効果的に使う方法を説明します。

[Direct3D グラフィックスの用語集](../graphics-concepts/index.md)グラフィックスなじみのない用語や読み取り中に発生する概念に関する情報を参照してください。

## <a name="the-important-core-user-interface-namespaces"></a>重要なコア ユーザー インターフェイスの名前空間


最初に、UWP アプリに (**using** を使って) 必要な Windows ランタイムの名前空間を示します。 後で詳しく説明します。

-   [**Windows.ApplicationModel.Core**](https://msdn.microsoft.com/library/windows/apps/br205865)
-   [**Windows.ApplicationModel.Activation**](https://msdn.microsoft.com/library/windows/apps/br224766)
-   [**Windows.UI.Core**](https://msdn.microsoft.com/library/windows/apps/br208383)
-   [**Windows.System**](https://msdn.microsoft.com/library/windows/apps/br241814)
-   [**Windows.Foundation**](https://msdn.microsoft.com/library/windows/apps/br226021)

> **注:**  UWP アプリを開発していない場合は、JavaScript または XAML 専用のライブラリとこれらの名前空間で提供される型ではなく、名前空間で提供されるユーザー インターフェイス コンポーネントを使用します。

 

## <a name="the-windows-runtime-app-object"></a>Windows ランタイム アプリ オブジェクト


UWP アプリでは、ウィンドウとビュー プロバイダーを取得します。これらはビューの取得元となり、スワップ チェーン (表示バッファー) の接続先となります。 このビューは、実行中のアプリでウィンドウ固有のイベントにフックすることもできます。 アプリ オブジェクトの親ウィンドウ ([**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) 型で定義) を取得するには、前のコード スニペットで行ったように、[**IFrameworkViewSource**](https://msdn.microsoft.com/library/windows/apps/hh700482) を実装する型を作成します。

コア ユーザー インターフェイス フレームワークを使ってウィンドウを取得する基本的な手順を次に示します。

1.  [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を実装する型を作成します。 これがビューになります。

    この型で次のメソッドを定義します。

    -   [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッド。[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) のインスタンスをパラメーターとして使います。 この型のインスタンスを取得するには、[**CoreApplication.CreateNewView**](https://msdn.microsoft.com/library/windows/apps/dn297278) を呼び出します。 アプリ オブジェクトは、アプリ起動時にこのメソッドを呼び出します。
    -   [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509) メソッド。[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) のインスタンスをパラメーターとして使います。 この型のインスタンスを取得するには、新しい [**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) インスタンスの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) プロパティにアクセスします。
    -   [**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501) メソッド。エントリ ポイントの文字列を唯一のパラメーターとして使います。 このメソッドを呼び出すと、アプリ オブジェクトからエントリ ポイントの文字列が提供されます。 ここでリソースをセットアップします。 ここでデバイス リソースを作成します。 アプリ オブジェクトは、アプリ起動時にこのメソッドを呼び出します。
    -   [**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッド。[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトをアクティブ化し、ウィンドウ イベント ディスパッチャーを開始します。 アプリ オブジェクトは、アプリのプロセスが開始されたときにこのメソッドを呼び出します。
    -   [**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523) メソッド。[**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)  の呼び出しでセットアップされたリソースをクリーンアップします。 アプリ オブジェクトは、アプリ終了時にこのメソッドを呼び出します。

2.  [**IFrameworkViewSource**](https://msdn.microsoft.com/library/windows/apps/hh700482) を実装する型を作成します。 これがビュー プロバイダーになります。

    この型で次のメソッドを定義します。

    -   [**CreateView**](https://msdn.microsoft.com/library/windows/apps/hh700491) メソッド。手順 1. で作成した [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) 実装のインスタンスを返します。

3.  ビュー プロバイダーのインスタンスを、**main** から [**CoreApplication.Run**](https://msdn.microsoft.com/library/windows/apps/hh700469) に渡します。

上記の基本事項を踏まえて、このアプローチを拡張するその他のオプションを説明します。

## <a name="core-user-interface-types"></a>コア ユーザー インターフェイスの型


Windows ランタイムには、他にも次のような便利なコア ユーザー インターフェイスの型があります。

-   [**Windows.ApplicationModel.Core.CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017)
-   [**Windows.UI.Core.CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)
-   [**Windows.UI.Core.CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211)

これらの型を使って、アプリのビュー、具体的にはアプリの親ウィンドウのコンテンツを描画するビットにアクセスし、そのウィンドウで発生したイベントを処理できます。 アプリ ウィンドウのプロセスは、すべてのコールバックを処理する独立した *アプリケーション シングルスレッド アパートメント* (ASTA) です。

アプリのビューは、アプリ ウィンドウのビュー プロバイダーによって生成され、ほとんどの場合、特定のフレームワーク パッケージまたはシステム自体によって実装されるため、手動で実装する必要はありません。 DirectX の場合は、既に説明したように手動でシン ビュー プロバイダーを実装する必要があります。 次のコンポーネントと動作の間には、明確な一対一の関係があります。

-   アプリのビュー。[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) 型で表され、ウィンドウを更新するためのメソッドを定義します。
-   ASTA。その属性で、アプリのスレッド動作を定義します。 ASTA で COM STA 属性型のインスタンスを作成することはできません。
-   ビュー プロバイダー。これはアプリがシステムから取得するか、手動で実装します。
-   親ウィンドウ。[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) 型で表されます。
-   すべてのアクティブ化イベントのソースです。 ビューとウィンドウの両方に、独立したアクティブ化イベントがあります。

要するに、アプリ オブジェクトがビュー プロバイダー ファクトリを提供します。 このファクトリがビュー プロバイダーを作成し、アプリの親ウィンドウをインスタンス化します。 ビュー プロバイダーが、アプリの親ウィンドウに対してアプリのビューを定義します。 次に、ビューと親ウィンドウについて詳しく説明します。

## <a name="coreapplicationview-behaviors-and-properties"></a>CoreApplicationView の動作とプロパティ


[**CoreApplicationView**](https://msdn.microsoft.com/library/windows/apps/br225017) は、現在のアプリ ビューを表します。 アプリ ビューは、初期化時にアプリ シングルトンによって作成されますが、アクティブ化されるまでアクティブになりません。 ビューを表示する [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を取得するには、そのビューの [**CoreApplicationView.CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br225019) プロパティにアクセスします。また、ビューのアクティブ化イベントと非アクティブ化イベントを処理するには、[**CoreApplicationView.Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) イベントにデリゲートを登録します。

## <a name="corewindow-behaviors-and-properties"></a>CoreWindow の動作とプロパティ


アプリ オブジェクトが初期化されるときに、[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) インスタンスである親ウィンドウが作成され、ビュー プロバイダーに渡されます。 アプリに表示するウィンドウがある場合はそれが表示され、そうでない場合はビューの初期化のみが行われます。

[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) では、入力および基本のウィンドウ動作専用のイベントを多数提供しています。 これらのイベントを処理するには、イベントに自分専用のデリゲートを登録します。

ウィンドウに使うウィンドウ イベント ディスパッチャーを取得することもできます。そのためには、[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) のインスタンスを提供する [**CoreWindow.Dispatcher**](https://msdn.microsoft.com/library/windows/apps/br208264) プロパティにアクセスします。

## <a name="coredispatcher-behaviors-and-properties"></a>CoreDispatcher の動作とプロパティ


[**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) 型のウィンドウに使うイベント ディスパッチのスレッド動作を決定できます。 この型には、ウィンドウ イベント処理を開始する特に重要なメソッド [**CoreDispatcher.ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) があります。 アプリで間違ったオプションを指定してこのメソッドを呼び出すと、さまざまな予期しないイベント処理動作が発生する可能性があります。

| CoreProcessEventsOption のオプション                                                           | 説明                                                                                                                                                                                                                                  |
|------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [**CoreProcessEventsOption.ProcessOneAndAllPending**](https://msdn.microsoft.com/library/windows/apps/br208217) | 現在キューに入っているすべてのイベントをディスパッチします。 保留中のイベントがない場合は、次の新しいイベントを待ちます。                                                                                                                                 |
| [**CoreProcessEventsOption.ProcessOneIfPresent**](https://msdn.microsoft.com/library/windows/apps/br208217)     | キュー内で保留中のイベントを 1 つだけディスパッチします。 保留中のイベントがない場合は、新しいイベントの発生を待たずに直ちに制御を返します。                                                                                          |
| [**CoreProcessEventsOption.ProcessUntilQuit**](https://msdn.microsoft.com/library/windows/apps/br208217)        | 新しいイベントを待ち、発生したイベントをすべてディスパッチします。 この動作を、ウィンドウが閉じられるか、アプリが [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) インスタンスで [**Close**](https://msdn.microsoft.com/library/windows/apps/br208260) メソッドを呼び出すまで継続します。 |
| [**CoreProcessEventsOption.ProcessAllIfPresent**](https://msdn.microsoft.com/library/windows/apps/br208217)     | 現在キューに入っているすべてのイベントをディスパッチします。 保留中のイベントがない場合は、直ちに制御を返します。                                                                                                                                          |

 

DirectX を使った UWP アプリでは、[**CoreProcessEventsOption.ProcessAllIfPresent**](https://msdn.microsoft.com/library/windows/apps/br208217) オプションを使って、グラフィックスの更新を中断する可能性があるブロック動作を防ぐ必要があります。

## <a name="asta-considerations-for-directx-devs"></a>DirectX 開発者向けの ASTA の考慮事項


DirectX を使った UWP アプリの実行時の形式を定義するアプリ オブジェクトは、アプリケーション シングルスレッド アパートメント (ASTA) というスレッド モデルを使ってアプリの UI ビューをホストします。 DirectX を使った UWP アプリを開発している場合、そのアプリからディスパッチするすべてのスレッドは [**Windows::System::Threading**](https://msdn.microsoft.com/library/windows/apps/br229642) API または [**CoreWindow::CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) を使う必要があるので、ASTA のプロパティについては十分に理解していると考えられます  (アプリから [**CoreWindow::GetForCurrentThread**](https://msdn.microsoft.com/library/windows/apps/hh701589) を呼び出すことで ASTA の [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを取得できます)。

DirectX を使った UWP アプリの開発者として、気を付ける必要のある最も重要なことは、**Platform::MTAThread** を **main()** 上で設定して、アプリ スレッドが MTA スレッドをディスパッチできるようにする必要があるということです。

```cpp
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto myDXAppSource = ref new MyDXAppSource(); // your view provider factory 
    CoreApplication::Run(myDXAppSource);
    return 0;
}
```

DirectX を使った UWP アプリのアプリ オブジェクトは、アクティブ化されると、UI ビューに使われる ASTA を作成します。 新しい ASTA スレッドは、ビュー プロバイダー ファクトリを呼び出して、アプリ オブジェクトのビュー プロバイダーを作成します。その結果、ビュー プロバイダー コードがこの ASTA スレッド上で実行されます。

また、ASTA から分離するスレッドは MTA にある必要があります。 分離する MTA スレッドには、引き続き再入の問題が発生して、デッドロックとなる可能性があることに注意してください。

ASTA スレッドで実行するために元のコードを移植している場合、これらの考慮事項に注意してください。

-   [**CoWaitForMultipleObjects**](https://msdn.microsoft.com/library/windows/desktop/hh404144) などの待機プリミティブは、STA 内と ASTA 内とで動作が異なります。
-   COM 呼び出しモーダル ループの動作は ASTA では異なります。 呼び出しの進行中は、無関係な呼び出しを受け取ることができなくなります。 たとえば、次の動作は ASTA からデッドロックを引き起こします (さらに、即座にアプリがクラッシュします)。
    1.  ASTA が MTA オブジェクトを呼び出し、インターフェイス ポインター P1 を渡します。
    2.  その後で、ASTA が同じ MTA オブジェクトを呼び出します。 MTA オブジェクトは、ASTA に制御を返す前に P1 を呼び出します。
    3.  P1 は、無関係な呼び出しがブロックされているため、ASTA に入ることができません。 しかし、MTA スレッドは P1 の呼び出しを試みるのでブロックされます。

    これは次の方法で解決できます。
    -   並列パターン ライブラリ (PPLTasks.h) で定義された **async** パターンを使います。
    -   できるだけ早くアプリの ASTA (アプリのメイン スレッド) から [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を呼び出して、任意の呼び出しを許可します。

    しかし、アプリの ASTA への無関係な呼び出しの即時の配信に頼ることはできません。 非同期呼び出しの詳細について、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

全体的に見れば、UWP アプリをデザインする場合、自分で MTA スレッドを作って管理しようとするのではなく、アプリの [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) の [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) と [**CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を使ってすべての UI スレッドを処理します。 **CoreDispatcher** で処理できない個別のスレッドが必要な場合、非同期パターンを使い、再入の問題を回避するために前のガイドに従います。

 

 




