---
author: drewbatgit
ms.assetid: 9146212C-8480-4C16-B74C-D7F08C7086AF
description: この記事では、MIDI (Musical Instrument Digital Interface) デバイスを列挙する方法と、ユニバーサル Windows アプリとの間で MIDI メッセージを送受信する方法について説明します。
title: MIDI
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 36d1e4afd620b871d4273699aea5c02cc9faec80
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5642503"
---
# <a name="midi"></a>MIDI



この記事では、MIDI (Musical Instrument Digital Interface) デバイスを列挙する方法と、ユニバーサル Windows アプリとの間で MIDI メッセージを送受信する方法について説明します。 Windows 10 は、USB (クラスに準拠したと最も独自のドライバー)、Bluetooth LE 経由で MIDI 経由で MIDI をサポートしています (Windows 10 Anniversary Edition 以降)、およびサード パーティ製品の自由に利用可能なイーサネット上の MIDI、ルーティング MIDI 経由します。

## <a name="enumerate-midi-devices"></a>MIDI デバイスの列挙

MIDI デバイスを列挙して使う前に、次の名前空間をプロジェクトに追加します。

[!code-cs[Using](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetUsing)]

XAML ページに [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) コントロールを追加して、システムに接続されている MIDI 入力デバイスのいずれかをユーザーが選択できるようにします。 また、MIDI 出力の一覧を表示する別のコントロールを追加します。

[!code-xml[MidiListBoxes](./code/MIDIWin10/cs/MainPage.xaml#SnippetMidiListBoxes)]

[**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) メソッドの [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) クラスは、Windows によって認識される多くの異なる種類のデバイスを列挙するのに使われます。 メソッドで MIDI 入力デバイスだけを検索するよう指定するには、[**MidiInPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894779) によって返されるセレクター文字列を使います。 **FindAllAsync** は、システムに登録されている各 MIDI 入力デバイスの **DeviceInformation** が格納された [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) を返します。 返されたコレクションに項目が含まれていない場合、利用可能な MIDI 入力デバイスはありません。 コレクションに項目が含まれる場合は、**DeviceInformation** オブジェクトのループ処理を行い、各デバイスの名前を MIDI 入力デバイスの **ListBox** に追加します。

[!code-cs[EnumerateMidiInputDevices](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetEnumerateMidiInputDevices)]

MIDI 出力デバイスの列挙も入力デバイスの列挙とまったく同じように動作しますが、**FindAllAsync** を呼び出すときに、[**MidiOutPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894845) によって返されるセレクター文字列を指定する必要があります。

[!code-cs[EnumerateMidiOutputDevices](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetEnumerateMidiOutputDevices)]



## <a name="create-a-device-watcher-helper-class"></a>デバイス ウォッチャーのヘルパー クラスを作成する

[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/br225459) 名前空間の [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) は、システムにデバイスが追加されるか削除された場合、またはデバイスの情報が更新された場合に、アプリに通知を送信できます。 MIDI 対応アプリでは通常、入力デバイスと出力デバイスの両方に関心があるため、この例では、**DeviceWatcher** パターンを実装するヘルパー クラスを作成して、同じコードを複製することなく MIDI 入力デバイスと MIDI 出力デバイスの両方に使えるようにします。

デバイス ウォッチャーとして機能する新しいクラスをプロジェクトに追加します。 この例では、クラスの名前は **MyMidiDeviceWatcher** です。 このセクションのコードの残りの部分は、ヘルパー クラスの実装に使われます。

クラスにいくつかのメンバー変数を追加します。

-   デバイスの変更を監視する [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) オブジェクト。
-   1 つのインスタンスには MIDI 入力ポートのセレクター文字列、もう 1 つのインスタンスには MIDI 出力ポートのセレクター文字列が格納される、デバイス セレクター文字列。
-   利用可能なデバイスの名前が格納される [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) コントロール。
-   UI スレッド以外のスレッドから UI を更新するために必要な [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211)。

[!code-cs[WatcherVariables](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherVariables)]

ヘルパー クラスの外部からのデバイスの現在の一覧にアクセスするのに使われる [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) プロパティを追加します。

[!code-cs[DeclareDeviceInformationCollection](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetDeclareDeviceInformationCollection)]

クラスのコンストラクターで、呼び出し元は MIDI デバイスのセレクター文字列、デバイスの一覧を表示する **ListBox**、および UI の更新に必要な **Dispatcher** を渡します。

MIDI デバイスのセレクター文字列を渡して [**DeviceInformation.CreateWatcher**](https://msdn.microsoft.com/library/windows/apps/br225427) を呼び出し、**DeviceWatcher** クラスの新しいインスタンスを作成します。

ウォッチャーのイベント ハンドラーに対してハンドラーを登録します。

[!code-cs[WatcherConstructor](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherConstructor)]

**DeviceWatcher** には次のイベントがあります。

-   [**Added**](https://msdn.microsoft.com/library/windows/apps/br225450) - システムに新しいデバイスが追加されると発生します。
-   [**Removed**](https://msdn.microsoft.com/library/windows/apps/br225453) - システムからデバイスが削除されると発生します。
-   [**Updated**](https://msdn.microsoft.com/library/windows/apps/br225458) - 既存のデバイスに関連付けられた情報が更新されると発生します。
-   [**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) - ウォッチャーで要求されたデバイスの種類の列挙が完了すると発生します。

これらの各イベントのイベント ハンドラーで、ヘルパー メソッド **UpdateDevices** が呼び出され、現在のデバイスの一覧で **ListBox** が更新されます。 **UpdateDevices** は UI 要素を更新し、これらのイベント ハンドラーは UI スレッドでは呼び出されないため、各呼び出しを [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出しにラップすることで、指定したコードが UI スレッドで実行されるようにする必要があります。

[!code-cs[WatcherEventHandlers](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherEventHandlers)]

**UpdateDevices** ヘルパー メソッドは、[**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) を呼び出し、この記事の前半で説明したように、返されたデバイスの名前で **ListBox** を更新します。

[!code-cs[WatcherUpdateDevices](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherUpdateDevices)]

**DeviceWatcher** オブジェクトの [**Start**](https://msdn.microsoft.com/library/windows/apps/br225454) メソッドを使って、ウォッチャーを起動するメソッドを追加し、[**Stop**](https://msdn.microsoft.com/library/windows/apps/br225456) メソッドを使ってウォッチャーを停止するメソッドを追加します。

[!code-cs[WatcherStopStart](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherStopStart)]

ウォッチャーのイベント ハンドラーの登録を解除し、デバイス ウォッチャーを null に設定する、デストラクターを用意します。

[!code-cs[WatcherDestructor](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherDestructor)]

## <a name="create-midi-ports-to-send-and-receive-messages"></a>メッセージを送受信する MIDI ポートを作成する

ページの分離コードで、**MyMidiDeviceWatcher** ヘルパー クラスの 2 つのインスタンスを保持するメンバー変数を宣言します。1 つは入力デバイス用、もう 1 つは出力デバイス用です。

[!code-cs[DeclareDeviceWatchers](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetDeclareDeviceWatchers)]

ウォッチャー ヘルパー クラスの新しいインスタンスを作成し、デバイスのセレクター文字列、格納する **ListBox**、およびページの **Dispatcher** プロパティでアクセスできる **CoreDispatcher** オブジェクトを渡します。 次に、各オブジェクトの **DeviceWatcher** を起動するメソッドを呼び出します。

各 **DeviceWatcher** は起動するとすぐに、現在システムに接続されているデバイスの列挙を完了し、[**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) イベントを発生させます。これにより、各 **ListBox** が現在の MIDI デバイスで更新されます。

[!code-cs[StartWatchers](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetStartWatchers)]

ユーザーが MIDI 入力 **ListBox** の項目を選択すると、[**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) イベントが発生します。 このイベントのハンドラーで、ヘルパー クラスの **DeviceInformationCollection** プロパティにアクセスして、デバイスの現在の一覧を取得します。 一覧にエントリが含まれている場合は、**ListBox** コントロールの [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/br209768) に対応するインデックスを持つ **DeviceInformation** オブジェクトを選択します。

選択したデバイスの [**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) プロパティを渡して [**MidiInPort.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn894776) を呼び出すことにより、選択した入力デバイスを表す [**MidiInPort**](https://msdn.microsoft.com/library/windows/apps/dn894770) オブジェクトを作成します。

指定されたデバイスで MIDI メッセージが受信されるたびに発生する [**MessageReceived**](https://msdn.microsoft.com/library/windows/apps/dn894781) イベントのハンドラーを登録します。

[!code-cs[DeclareMidiPorts](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetDeclareMidiPorts)]

[!code-cs[InPortSelectionChanged](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetInPortSelectionChanged)]

**MessageReceived** ハンドラーが呼び出されると、**MidiMessageReceivedEventArgs** の [**Message**](https://msdn.microsoft.com/library/windows/apps/dn894783) プロパティにメッセージが格納されます。 メッセージ オブジェクトの [**Type**](https://msdn.microsoft.com/library/windows/apps/dn894726) は、受信したメッセージの種類を示す [**MidiMessageType**](https://msdn.microsoft.com/library/windows/apps/dn894786) 列挙体の値です。 メッセージのデータは、メッセージの種類によって異なります。 この例では、メッセージがノートオン メッセージであるかどうかを確認し、そうである場合は、メッセージの MIDI チャネル、ノート、およびベロシティを出力します。

[!code-cs[MessageReceived](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetMessageReceived)]

出力デバイス **ListBox** の [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) ハンドラーは、入力デバイスのハンドラーと同じように動作しますが、イベント ハンドラーは登録されません。

[!code-cs[OutPortSelectionChanged](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetOutPortSelectionChanged)]

出力デバイスが作成されたら、送信するメッセージの種類に対する新しい [**IMidiMessage**](https://msdn.microsoft.com/library/windows/apps/dn911508) を作成して、メッセージを送信できます。 この例では、メッセージは [**NoteOnMessage**](https://msdn.microsoft.com/library/windows/apps/dn894817) です。 [**IMidiOutPort**](https://msdn.microsoft.com/library/windows/apps/dn894727) オブジェクトの [**SendMessage**](https://msdn.microsoft.com/library/windows/apps/dn894730) メソッドが呼び出されて、メッセージを送信します。

[!code-cs[SendMessage](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetSendMessage)]

アプリが非アクティブ化になったときは、必ずアプリのリソースをクリーンアップしてください。 イベント ハンドラーの登録を解除し、MIDI の入力ポート オブジェクトと出力ポート オブジェクトを null に設定します。 デバイス ウォッチャーを停止し、null に設定します。

[!code-cs[CleanUp](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetCleanUp)]

## <a name="using-the-built-in-windows-general-midi-synth"></a>組み込みの Windows General MIDI シンセサイザーを使用する

上記で説明した手法を使用して MIDI 出力デバイスを列挙すると、アプリは、"Microsoft GS Wavetable Synth" という MIDI デバイスを検出します。 このデバイスは、アプリから使用できる組み込みの General MIDI シンセサイザーです。 ただし、組み込みのシンセサイザーの SDK 拡張機能をプロジェクトに含めていない限り、このデバイスへの MIDI アウトポートを作成しようとすると失敗します。

**General MIDI シンセサイザーの SDK 拡張機能をアプリ プロジェクトに含めるには、次の手順に従います。**

1.  **ソリューション エクスプローラー**で、プロジェクトの下にある **[参照設定]** を右クリックし、**[参照の追加]** を選択します。
2.  **[Universal Windows]** ノードを展開します。
3.  **[拡張機能]** を選択します。
4.  拡張機能の一覧から **[Microsoft General MIDI DLS for Universal Windows Apps]** を選択します。
    > [!NOTE] 
    > 複数のバージョンの拡張機能がある場合、アプリのターゲットと一致するバージョンを選んでください。 プロジェクトのプロパティの **[アプリケーション]** タブで、アプリがターゲットとしている SDK バージョンを確認できます。

 

 




