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
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5763618"
---
# <a name="midi"></a><span data-ttu-id="ed626-104">MIDI</span><span class="sxs-lookup"><span data-stu-id="ed626-104">MIDI</span></span>



<span data-ttu-id="ed626-105">この記事では、MIDI (Musical Instrument Digital Interface) デバイスを列挙する方法と、ユニバーサル Windows アプリとの間で MIDI メッセージを送受信する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ed626-105">This article shows you how to enumerate MIDI (Musical Instrument Digital Interface) devices and send and receive MIDI messages from a Universal Windows app.</span></span> <span data-ttu-id="ed626-106">Windows 10 は、USB (クラスに準拠したと最も独自のドライバー)、Bluetooth LE 経由で MIDI 経由で MIDI をサポートしています (Windows 10 Anniversary Edition 以降)、およびサード パーティ製品の自由に利用可能なイーサネット上の MIDI、ルーティング MIDI 経由します。</span><span class="sxs-lookup"><span data-stu-id="ed626-106">Windows 10 supports MIDI over USB (class-compliant and most proprietary drivers), MIDI over Bluetooth LE (Windows 10 Anniversary Edition and later), and through freely-available third-party products, MIDI over Ethernet and routed MIDI.</span></span>

## <a name="enumerate-midi-devices"></a><span data-ttu-id="ed626-107">MIDI デバイスの列挙</span><span class="sxs-lookup"><span data-stu-id="ed626-107">Enumerate MIDI devices</span></span>

<span data-ttu-id="ed626-108">MIDI デバイスを列挙して使う前に、次の名前空間をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-108">Before enumerating and using MIDI devices, add the following namespaces to your project.</span></span>

[!code-cs[Using](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetUsing)]

<span data-ttu-id="ed626-109">XAML ページに [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) コントロールを追加して、システムに接続されている MIDI 入力デバイスのいずれかをユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed626-109">Add a [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) control to your XAML page that will allow the user to select one of the MIDI input devices attached to the system.</span></span> <span data-ttu-id="ed626-110">また、MIDI 出力の一覧を表示する別のコントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-110">Add another one to list the MIDI output devices.</span></span>

[!code-xml[MidiListBoxes](./code/MIDIWin10/cs/MainPage.xaml#SnippetMidiListBoxes)]

<span data-ttu-id="ed626-111">[**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) メソッドの [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) クラスは、Windows によって認識される多くの異なる種類のデバイスを列挙するのに使われます。</span><span class="sxs-lookup"><span data-stu-id="ed626-111">The [**FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) method [**DeviceInformation**](https://msdn.microsoft.com/library/windows/apps/br225393) class is used to enumerate many different types of devices that are recognized by Windows.</span></span> <span data-ttu-id="ed626-112">メソッドで MIDI 入力デバイスだけを検索するよう指定するには、[**MidiInPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894779) によって返されるセレクター文字列を使います。</span><span class="sxs-lookup"><span data-stu-id="ed626-112">To specify that you only want the method to find MIDI input devices, use the selector string returned by [**MidiInPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894779).</span></span> <span data-ttu-id="ed626-113">**FindAllAsync** は、システムに登録されている各 MIDI 入力デバイスの **DeviceInformation** が格納された [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) を返します。</span><span class="sxs-lookup"><span data-stu-id="ed626-113">**FindAllAsync** returns a [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) that contains a **DeviceInformation** for each MIDI input device registered with the system.</span></span> <span data-ttu-id="ed626-114">返されたコレクションに項目が含まれていない場合、利用可能な MIDI 入力デバイスはありません。</span><span class="sxs-lookup"><span data-stu-id="ed626-114">If the returned collection contains no items, then there are no available MIDI input devices.</span></span> <span data-ttu-id="ed626-115">コレクションに項目が含まれる場合は、**DeviceInformation** オブジェクトのループ処理を行い、各デバイスの名前を MIDI 入力デバイスの **ListBox** に追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-115">If there are items in the collection, loop through the **DeviceInformation** objects and add the name of each device to the MIDI input device **ListBox**.</span></span>

[!code-cs[EnumerateMidiInputDevices](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetEnumerateMidiInputDevices)]

<span data-ttu-id="ed626-116">MIDI 出力デバイスの列挙も入力デバイスの列挙とまったく同じように動作しますが、**FindAllAsync** を呼び出すときに、[**MidiOutPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894845) によって返されるセレクター文字列を指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed626-116">Enumerating MIDI output devices works the exact same way as enumerating input devices, except that you should specify the selector string returned by [**MidiOutPort.GetDeviceSelector**](https://msdn.microsoft.com/library/windows/apps/dn894845) when calling **FindAllAsync**.</span></span>

[!code-cs[EnumerateMidiOutputDevices](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetEnumerateMidiOutputDevices)]



## <a name="create-a-device-watcher-helper-class"></a><span data-ttu-id="ed626-117">デバイス ウォッチャーのヘルパー クラスを作成する</span><span class="sxs-lookup"><span data-stu-id="ed626-117">Create a device watcher helper class</span></span>

<span data-ttu-id="ed626-118">[**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/br225459) 名前空間の [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) は、システムにデバイスが追加されるか削除された場合、またはデバイスの情報が更新された場合に、アプリに通知を送信できます。</span><span class="sxs-lookup"><span data-stu-id="ed626-118">The [**Windows.Devices.Enumeration**](https://msdn.microsoft.com/library/windows/apps/br225459) namespace provides the [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) which can notify your app if devices are added or removed from the system, or if the information for a device is updated.</span></span> <span data-ttu-id="ed626-119">MIDI 対応アプリでは通常、入力デバイスと出力デバイスの両方に関心があるため、この例では、**DeviceWatcher** パターンを実装するヘルパー クラスを作成して、同じコードを複製することなく MIDI 入力デバイスと MIDI 出力デバイスの両方に使えるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed626-119">Since MIDI-enabled apps typically are interested in both input and output devices, this example creates a helper class that implements the **DeviceWatcher** pattern, so that the same code can be used for both MIDI input and MIDI output devices, without the need for duplication.</span></span>

<span data-ttu-id="ed626-120">デバイス ウォッチャーとして機能する新しいクラスをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-120">Add a new class to your project to serve as your device watcher.</span></span> <span data-ttu-id="ed626-121">この例では、クラスの名前は **MyMidiDeviceWatcher** です。</span><span class="sxs-lookup"><span data-stu-id="ed626-121">In this example the class is named **MyMidiDeviceWatcher**.</span></span> <span data-ttu-id="ed626-122">このセクションのコードの残りの部分は、ヘルパー クラスの実装に使われます。</span><span class="sxs-lookup"><span data-stu-id="ed626-122">The rest of the code in this section is used to implement the helper class.</span></span>

<span data-ttu-id="ed626-123">クラスにいくつかのメンバー変数を追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-123">Add some member variables to the class:</span></span>

-   <span data-ttu-id="ed626-124">デバイスの変更を監視する [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ed626-124">A [**DeviceWatcher**](https://msdn.microsoft.com/library/windows/apps/br225446) object that will monitor for device changes.</span></span>
-   <span data-ttu-id="ed626-125">1 つのインスタンスには MIDI 入力ポートのセレクター文字列、もう 1 つのインスタンスには MIDI 出力ポートのセレクター文字列が格納される、デバイス セレクター文字列。</span><span class="sxs-lookup"><span data-stu-id="ed626-125">A device selector string that will contain the MIDI in port selector string for one instance and the MIDI out port selector string for another instance.</span></span>
-   <span data-ttu-id="ed626-126">利用可能なデバイスの名前が格納される [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) コントロール。</span><span class="sxs-lookup"><span data-stu-id="ed626-126">A [**ListBox**](https://msdn.microsoft.com/library/windows/apps/br242868) control that will be populated with the names of the available devices.</span></span>
-   <span data-ttu-id="ed626-127">UI スレッド以外のスレッドから UI を更新するために必要な [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211)。</span><span class="sxs-lookup"><span data-stu-id="ed626-127">A [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) that is required to update the UI from a thread other than the UI thread.</span></span>

[!code-cs[WatcherVariables](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherVariables)]

<span data-ttu-id="ed626-128">ヘルパー クラスの外部からのデバイスの現在の一覧にアクセスするのに使われる [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) プロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-128">Add a [**DeviceInformationCollection**](https://msdn.microsoft.com/library/windows/apps/br225395) property that is used to access the current list of devices from outside the helper class.</span></span>

[!code-cs[DeclareDeviceInformationCollection](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetDeclareDeviceInformationCollection)]

<span data-ttu-id="ed626-129">クラスのコンストラクターで、呼び出し元は MIDI デバイスのセレクター文字列、デバイスの一覧を表示する **ListBox**、および UI の更新に必要な **Dispatcher** を渡します。</span><span class="sxs-lookup"><span data-stu-id="ed626-129">In class constructor, the caller passes in the MIDI device selector string, the **ListBox** for listing the devices, and the **Dispatcher** needed to update the UI.</span></span>

<span data-ttu-id="ed626-130">MIDI デバイスのセレクター文字列を渡して [**DeviceInformation.CreateWatcher**](https://msdn.microsoft.com/library/windows/apps/br225427) を呼び出し、**DeviceWatcher** クラスの新しいインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ed626-130">Call [**DeviceInformation.CreateWatcher**](https://msdn.microsoft.com/library/windows/apps/br225427) to create a new instance of the **DeviceWatcher** class, passing in the MIDI device selector string.</span></span>

<span data-ttu-id="ed626-131">ウォッチャーのイベント ハンドラーに対してハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="ed626-131">Register handlers for the watcher's event handlers.</span></span>

[!code-cs[WatcherConstructor](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherConstructor)]

<span data-ttu-id="ed626-132">**DeviceWatcher** には次のイベントがあります。</span><span class="sxs-lookup"><span data-stu-id="ed626-132">The **DeviceWatcher** has the following events:</span></span>

-   <span data-ttu-id="ed626-133">[**Added**](https://msdn.microsoft.com/library/windows/apps/br225450) - システムに新しいデバイスが追加されると発生します。</span><span class="sxs-lookup"><span data-stu-id="ed626-133">[**Added**](https://msdn.microsoft.com/library/windows/apps/br225450) - Raised when a new device is added to the system.</span></span>
-   <span data-ttu-id="ed626-134">[**Removed**](https://msdn.microsoft.com/library/windows/apps/br225453) - システムからデバイスが削除されると発生します。</span><span class="sxs-lookup"><span data-stu-id="ed626-134">[**Removed**](https://msdn.microsoft.com/library/windows/apps/br225453) - Raised when a device is removed from the system.</span></span>
-   <span data-ttu-id="ed626-135">[**Updated**](https://msdn.microsoft.com/library/windows/apps/br225458) - 既存のデバイスに関連付けられた情報が更新されると発生します。</span><span class="sxs-lookup"><span data-stu-id="ed626-135">[**Updated**](https://msdn.microsoft.com/library/windows/apps/br225458) - Raised when the information associated with an existing device is updated.</span></span>
-   <span data-ttu-id="ed626-136">[**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) - ウォッチャーで要求されたデバイスの種類の列挙が完了すると発生します。</span><span class="sxs-lookup"><span data-stu-id="ed626-136">[**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) - Raised when the watcher has completed its enumeration of the requested device type.</span></span>

<span data-ttu-id="ed626-137">これらの各イベントのイベント ハンドラーで、ヘルパー メソッド **UpdateDevices** が呼び出され、現在のデバイスの一覧で **ListBox** が更新されます。</span><span class="sxs-lookup"><span data-stu-id="ed626-137">In the event handler for each of these events, a helper method, **UpdateDevices**, is called to update the **ListBox** with the current list of devices.</span></span> <span data-ttu-id="ed626-138">**UpdateDevices** は UI 要素を更新し、これらのイベント ハンドラーは UI スレッドでは呼び出されないため、各呼び出しを [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317) の呼び出しにラップすることで、指定したコードが UI スレッドで実行されるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed626-138">Because **UpdateDevices** updates UI elements and these event handlers are not called on the UI thread, each call must be wrapped in a call to [**RunAsync**](https://msdn.microsoft.com/library/windows/apps/hh750317), which causes the specified code to be run on the UI thread.</span></span>

[!code-cs[WatcherEventHandlers](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherEventHandlers)]

<span data-ttu-id="ed626-139">**UpdateDevices** ヘルパー メソッドは、[**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) を呼び出し、この記事の前半で説明したように、返されたデバイスの名前で **ListBox** を更新します。</span><span class="sxs-lookup"><span data-stu-id="ed626-139">The **UpdateDevices** helper method calls [**DeviceInformation.FindAllAsync**](https://msdn.microsoft.com/library/windows/apps/br225432) and updates the **ListBox** with the names of the returned devices as described previously in this article.</span></span>

[!code-cs[WatcherUpdateDevices](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherUpdateDevices)]

<span data-ttu-id="ed626-140">**DeviceWatcher** オブジェクトの [**Start**](https://msdn.microsoft.com/library/windows/apps/br225454) メソッドを使って、ウォッチャーを起動するメソッドを追加し、[**Stop**](https://msdn.microsoft.com/library/windows/apps/br225456) メソッドを使ってウォッチャーを停止するメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="ed626-140">Add methods to start the watcher, using the **DeviceWatcher** object's [**Start**](https://msdn.microsoft.com/library/windows/apps/br225454) method, and to stop the watcher, using the [**Stop**](https://msdn.microsoft.com/library/windows/apps/br225456) method.</span></span>

[!code-cs[WatcherStopStart](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherStopStart)]

<span data-ttu-id="ed626-141">ウォッチャーのイベント ハンドラーの登録を解除し、デバイス ウォッチャーを null に設定する、デストラクターを用意します。</span><span class="sxs-lookup"><span data-stu-id="ed626-141">Provide a destructor to unregister the watcher event handlers and set the device watcher to null.</span></span>

[!code-cs[WatcherDestructor](./code/MIDIWin10/cs/MyMidiDeviceWatcher.cs#SnippetWatcherDestructor)]

## <a name="create-midi-ports-to-send-and-receive-messages"></a><span data-ttu-id="ed626-142">メッセージを送受信する MIDI ポートを作成する</span><span class="sxs-lookup"><span data-stu-id="ed626-142">Create MIDI ports to send and receive messages</span></span>

<span data-ttu-id="ed626-143">ページの分離コードで、**MyMidiDeviceWatcher** ヘルパー クラスの 2 つのインスタンスを保持するメンバー変数を宣言します。1 つは入力デバイス用、もう 1 つは出力デバイス用です。</span><span class="sxs-lookup"><span data-stu-id="ed626-143">In the code behind for your page, declare member variables to hold two instances of the **MyMidiDeviceWatcher** helper class, one for input devices and one for output devices.</span></span>

[!code-cs[DeclareDeviceWatchers](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetDeclareDeviceWatchers)]

<span data-ttu-id="ed626-144">ウォッチャー ヘルパー クラスの新しいインスタンスを作成し、デバイスのセレクター文字列、格納する **ListBox**、およびページの **Dispatcher** プロパティでアクセスできる **CoreDispatcher** オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="ed626-144">Create a new instance of the watcher helper classes, passing in the device selector string, the **ListBox** to be populated, and the **CoreDispatcher** object that can be accessed through the page's **Dispatcher** property.</span></span> <span data-ttu-id="ed626-145">次に、各オブジェクトの **DeviceWatcher** を起動するメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ed626-145">Then, call the method to start each object's **DeviceWatcher**.</span></span>

<span data-ttu-id="ed626-146">各 **DeviceWatcher** は起動するとすぐに、現在システムに接続されているデバイスの列挙を完了し、[**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) イベントを発生させます。これにより、各 **ListBox** が現在の MIDI デバイスで更新されます。</span><span class="sxs-lookup"><span data-stu-id="ed626-146">Shortly after each **DeviceWatcher** is started, it will finish enumerating the current devices connected to the system and raise its [**EnumerationCompleted**](https://msdn.microsoft.com/library/windows/apps/br225451) event, which will cause each **ListBox** to be updated with the current MIDI devices.</span></span>

[!code-cs[StartWatchers](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetStartWatchers)]

<span data-ttu-id="ed626-147">ユーザーが MIDI 入力 **ListBox** の項目を選択すると、[**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="ed626-147">When the user selects an item in the MIDI input **ListBox**, the [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) event is raised.</span></span> <span data-ttu-id="ed626-148">このイベントのハンドラーで、ヘルパー クラスの **DeviceInformationCollection** プロパティにアクセスして、デバイスの現在の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="ed626-148">In the handler for this event, access the **DeviceInformationCollection** property of the helper class to get the current list of devices.</span></span> <span data-ttu-id="ed626-149">一覧にエントリが含まれている場合は、**ListBox** コントロールの [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/br209768) に対応するインデックスを持つ **DeviceInformation** オブジェクトを選択します。</span><span class="sxs-lookup"><span data-stu-id="ed626-149">If there are entries in the list, select the **DeviceInformation** object with the index corresponding to the **ListBox** control's [**SelectedIndex**](https://msdn.microsoft.com/library/windows/apps/br209768).</span></span>

<span data-ttu-id="ed626-150">選択したデバイスの [**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) プロパティを渡して [**MidiInPort.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn894776) を呼び出すことにより、選択した入力デバイスを表す [**MidiInPort**](https://msdn.microsoft.com/library/windows/apps/dn894770) オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ed626-150">Create the [**MidiInPort**](https://msdn.microsoft.com/library/windows/apps/dn894770) object representing the selected input device by calling [**MidiInPort.FromIdAsync**](https://msdn.microsoft.com/library/windows/apps/dn894776), passing in the [**Id**](https://msdn.microsoft.com/library/windows/apps/br225437) property of the selected device.</span></span>

<span data-ttu-id="ed626-151">指定されたデバイスで MIDI メッセージが受信されるたびに発生する [**MessageReceived**](https://msdn.microsoft.com/library/windows/apps/dn894781) イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="ed626-151">Register a handler for the [**MessageReceived**](https://msdn.microsoft.com/library/windows/apps/dn894781) event, which is raised whenever a MIDI message is received through the specified device.</span></span>

[!code-cs[DeclareMidiPorts](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetDeclareMidiPorts)]

[!code-cs[InPortSelectionChanged](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetInPortSelectionChanged)]

<span data-ttu-id="ed626-152">**MessageReceived** ハンドラーが呼び出されると、**MidiMessageReceivedEventArgs** の [**Message**](https://msdn.microsoft.com/library/windows/apps/dn894783) プロパティにメッセージが格納されます。</span><span class="sxs-lookup"><span data-stu-id="ed626-152">When the **MessageReceived** handler is called, the message is contained in the [**Message**](https://msdn.microsoft.com/library/windows/apps/dn894783) property of the **MidiMessageReceivedEventArgs**.</span></span> <span data-ttu-id="ed626-153">メッセージ オブジェクトの [**Type**](https://msdn.microsoft.com/library/windows/apps/dn894726) は、受信したメッセージの種類を示す [**MidiMessageType**](https://msdn.microsoft.com/library/windows/apps/dn894786) 列挙体の値です。</span><span class="sxs-lookup"><span data-stu-id="ed626-153">The [**Type**](https://msdn.microsoft.com/library/windows/apps/dn894726) of the message object is a value from the [**MidiMessageType**](https://msdn.microsoft.com/library/windows/apps/dn894786) enumeration indicating the type of message that was received.</span></span> <span data-ttu-id="ed626-154">メッセージのデータは、メッセージの種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="ed626-154">The data of the message depends on the type of the message.</span></span> <span data-ttu-id="ed626-155">この例では、メッセージがノートオン メッセージであるかどうかを確認し、そうである場合は、メッセージの MIDI チャネル、ノート、およびベロシティを出力します。</span><span class="sxs-lookup"><span data-stu-id="ed626-155">This example checks to see if the message is a note on message and, if so, outputs the midi channel, note, and velocity of the message.</span></span>

[!code-cs[MessageReceived](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetMessageReceived)]

<span data-ttu-id="ed626-156">出力デバイス **ListBox** の [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) ハンドラーは、入力デバイスのハンドラーと同じように動作しますが、イベント ハンドラーは登録されません。</span><span class="sxs-lookup"><span data-stu-id="ed626-156">The [**SelectionChanged**](https://msdn.microsoft.com/library/windows/apps/br209776) handler for the output device **ListBox** works the same as the handler for input devices, except no event handler is registered.</span></span>

[!code-cs[OutPortSelectionChanged](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetOutPortSelectionChanged)]

<span data-ttu-id="ed626-157">出力デバイスが作成されたら、送信するメッセージの種類に対する新しい [**IMidiMessage**](https://msdn.microsoft.com/library/windows/apps/dn911508) を作成して、メッセージを送信できます。</span><span class="sxs-lookup"><span data-stu-id="ed626-157">Once the output device is created, you can send a message by creating a new [**IMidiMessage**](https://msdn.microsoft.com/library/windows/apps/dn911508) for the type of message you want to send.</span></span> <span data-ttu-id="ed626-158">この例では、メッセージは [**NoteOnMessage**](https://msdn.microsoft.com/library/windows/apps/dn894817) です。</span><span class="sxs-lookup"><span data-stu-id="ed626-158">In this example, the message is a [**NoteOnMessage**](https://msdn.microsoft.com/library/windows/apps/dn894817).</span></span> <span data-ttu-id="ed626-159">[**IMidiOutPort**](https://msdn.microsoft.com/library/windows/apps/dn894727) オブジェクトの [**SendMessage**](https://msdn.microsoft.com/library/windows/apps/dn894730) メソッドが呼び出されて、メッセージを送信します。</span><span class="sxs-lookup"><span data-stu-id="ed626-159">The [**SendMessage**](https://msdn.microsoft.com/library/windows/apps/dn894730) method of the [**IMidiOutPort**](https://msdn.microsoft.com/library/windows/apps/dn894727) object is called to send the message.</span></span>

[!code-cs[SendMessage](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetSendMessage)]

<span data-ttu-id="ed626-160">アプリが非アクティブ化になったときは、必ずアプリのリソースをクリーンアップしてください。</span><span class="sxs-lookup"><span data-stu-id="ed626-160">When your app is deactivated, be sure to clean up your apps resources.</span></span> <span data-ttu-id="ed626-161">イベント ハンドラーの登録を解除し、MIDI の入力ポート オブジェクトと出力ポート オブジェクトを null に設定します。</span><span class="sxs-lookup"><span data-stu-id="ed626-161">Unregister your event handlers and set the MIDI in port and out port objects to null.</span></span> <span data-ttu-id="ed626-162">デバイス ウォッチャーを停止し、null に設定します。</span><span class="sxs-lookup"><span data-stu-id="ed626-162">Stop the device watchers and set them to null.</span></span>

[!code-cs[CleanUp](./code/MIDIWin10/cs/MainPage.xaml.cs#SnippetCleanUp)]

## <a name="using-the-built-in-windows-general-midi-synth"></a><span data-ttu-id="ed626-163">組み込みの Windows General MIDI シンセサイザーを使用する</span><span class="sxs-lookup"><span data-stu-id="ed626-163">Using the built-in Windows General MIDI synth</span></span>

<span data-ttu-id="ed626-164">上記で説明した手法を使用して MIDI 出力デバイスを列挙すると、アプリは、"Microsoft GS Wavetable Synth" という MIDI デバイスを検出します。</span><span class="sxs-lookup"><span data-stu-id="ed626-164">When you enumerate output MIDI devices using the technique described above, your app will discover a MIDI device called "Microsoft GS Wavetable Synth".</span></span> <span data-ttu-id="ed626-165">このデバイスは、アプリから使用できる組み込みの General MIDI シンセサイザーです。</span><span class="sxs-lookup"><span data-stu-id="ed626-165">This is a built-in General MIDI synthesizer that you can play from your app.</span></span> <span data-ttu-id="ed626-166">ただし、組み込みのシンセサイザーの SDK 拡張機能をプロジェクトに含めていない限り、このデバイスへの MIDI アウトポートを作成しようとすると失敗します。</span><span class="sxs-lookup"><span data-stu-id="ed626-166">However, attempting to create a MIDI outport to this device will fail unless you have included the SDK extension for the built-in synth in your project.</span></span>

**<span data-ttu-id="ed626-167">General MIDI シンセサイザーの SDK 拡張機能をアプリ プロジェクトに含めるには、次の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="ed626-167">To include the General MIDI Synth SDK extension in your app project</span></span>**

1.  <span data-ttu-id="ed626-168">**ソリューション エクスプローラー**で、プロジェクトの下にある **[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ed626-168">In **Solution Explorer**, under your project, right-click **References** and select **Add reference...**</span></span>
2.  <span data-ttu-id="ed626-169">**[Universal Windows]** ノードを展開します。</span><span class="sxs-lookup"><span data-stu-id="ed626-169">Expand the **Universal Windows** node.</span></span>
3.  <span data-ttu-id="ed626-170">**[拡張機能]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ed626-170">Select **Extensions**.</span></span>
4.  <span data-ttu-id="ed626-171">拡張機能の一覧から **[Microsoft General MIDI DLS for Universal Windows Apps]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ed626-171">From the list of extensions, select **Microsoft General MIDI DLS for Universal Windows Apps**.</span></span>
    > [!NOTE] 
    > <span data-ttu-id="ed626-172">複数のバージョンの拡張機能がある場合、アプリのターゲットと一致するバージョンを選んでください。</span><span class="sxs-lookup"><span data-stu-id="ed626-172">If there are multiple versions of the extension, be sure to select the version that matches the target for your app.</span></span> <span data-ttu-id="ed626-173">プロジェクトのプロパティの **[アプリケーション]** タブで、アプリがターゲットとしている SDK バージョンを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ed626-173">You can see which SDK version your app is targeting on the **Application** tab of the project Properties.</span></span>

 

 




