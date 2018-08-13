---
author: mcleblanc
description: デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。
title: 入出力、デバイス、アプリ モデルの Windows ランタイム 8.x から UWP への移植&quot;
ms.assetid: bb13fb8f-bdec-46f5-8640-57fb0dd2d85b
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2ccc9b0d81b69a06973feac8d554aa0ab47f2af0
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "243816"
---
# <a name="porting-windows-runtime-8x-to-uwp-for-io-device-and-app-model"></a><span data-ttu-id="73778-104">入出力、デバイス、アプリ モデルの Windows ランタイム 8.x から UWP への移植</span><span class="sxs-lookup"><span data-stu-id="73778-104">Porting Windows Runtime 8.x to UWP for I/O, device, and app model</span></span>


<span data-ttu-id="73778-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="73778-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="73778-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="73778-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


<span data-ttu-id="73778-107">前のトピックは、「[XAML と UI の移植](w8x-to-uwp-porting-xaml-and-ui.md)」でした。</span><span class="sxs-lookup"><span data-stu-id="73778-107">The previous topic was [Porting XAML and UI](w8x-to-uwp-porting-xaml-and-ui.md).</span></span>

<span data-ttu-id="73778-108">デバイス自体とそのセンサーに統合するコードには、ユーザーに対する入力と出力が含まれます。</span><span class="sxs-lookup"><span data-stu-id="73778-108">Code that integrates with the device itself and its sensors involves input from, and output to, the user.</span></span> <span data-ttu-id="73778-109">また、データ処理を含むこともあります。</span><span class="sxs-lookup"><span data-stu-id="73778-109">It can also involve processing data.</span></span> <span data-ttu-id="73778-110">ただしこのコードは一般には、UI レイヤー*または*データ レイヤーのいずれにも見なされません。</span><span class="sxs-lookup"><span data-stu-id="73778-110">But, this code is not generally thought of as either the UI layer *or* the data layer.</span></span> <span data-ttu-id="73778-111">このコードには、振動コントローラー、加速度計、ジャイロスコープ、マイクとスピーカー (音声認識と音声合成で使います)、地理位置情報、およびタッチ、マウス、キーボード、ペンなどの入力モダリティとの統合が含まれます。</span><span class="sxs-lookup"><span data-stu-id="73778-111">This code includes integration with the vibration controller, accelerometer, gyroscope, microphone and speaker (which intersect with speech recognition and synthesis), (geo)location, and input modalities such as touch, mouse, keyboard, and pen.</span></span>

## <a name="application-lifecycle-process-lifetime-management"></a><span data-ttu-id="73778-112">アプリケーションのライフサイクル (プロセス ライフタイム管理)</span><span class="sxs-lookup"><span data-stu-id="73778-112">Application lifecycle (process lifetime management)</span></span>


<span data-ttu-id="73778-113">ユニバーサル 8.1 アプリでは、アプリが非アクティブになり、システムで中断イベントが発生するまでの間に、2 秒間の "デバウンス時間" があります。</span><span class="sxs-lookup"><span data-stu-id="73778-113">For a Universal 8.1 app, there is a two-second "debounce window" of time between the app becoming inactive and the system raising the suspending event.</span></span> <span data-ttu-id="73778-114">このデバウンス時間を猶予時間として使い、中断状態にさせることは安全な方法ではありません。また、ユニバーサル Windows プラットフォーム (UWP) アプリにはデバウンス時間がありません。このため、アプリが非アクティブになるとすぐに中断イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="73778-114">Using this debounce window as extra time to suspend state is unsafe, and for a Universal Windows Platform (UWP) app, there is no debounce window at all; the suspension event is raised as soon as an app becomes inactive.</span></span>

<span data-ttu-id="73778-115">詳しくは、「[アプリのライフサイクル](https://msdn.microsoft.com/library/windows/apps/mt243287)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73778-115">For more info, see [App lifecycle](https://msdn.microsoft.com/library/windows/apps/mt243287).</span></span>

## <a name="background-audio"></a><span data-ttu-id="73778-116">バックグラウンド オーディオ</span><span class="sxs-lookup"><span data-stu-id="73778-116">Background audio</span></span>


<span data-ttu-id="73778-117">[**MediaElement.AudioCategory**](https://msdn.microsoft.com/library/windows/apps/br227352) プロパティについては、**ForegroundOnlyMedia** と **BackgroundCapableMedia** が Windows 10 アプリでは使われなくなりました。</span><span class="sxs-lookup"><span data-stu-id="73778-117">For the [**MediaElement.AudioCategory**](https://msdn.microsoft.com/library/windows/apps/br227352) property, **ForegroundOnlyMedia** and **BackgroundCapableMedia** are deprecated for Windows 10 apps.</span></span> <span data-ttu-id="73778-118">代わりに Windows Phone ストア アプリ モデルを使ってください。</span><span class="sxs-lookup"><span data-stu-id="73778-118">Use the Windows Phone Store app model instead.</span></span> <span data-ttu-id="73778-119">詳しくは、「[バックグラウンド オーディオ](https://msdn.microsoft.com/library/windows/apps/mt282140)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73778-119">For more information, see [Background Audio](https://msdn.microsoft.com/library/windows/apps/mt282140).</span></span>

## <a name="detecting-the-platform-your-app-is-running-on"></a><span data-ttu-id="73778-120">アプリが実行されているプラットフォームの検出</span><span class="sxs-lookup"><span data-stu-id="73778-120">Detecting the platform your app is running on</span></span>


<span data-ttu-id="73778-121">アプリの対応に関する考え方は、Windows 10 で変わりました。</span><span class="sxs-lookup"><span data-stu-id="73778-121">The way of thinking about app-targeting changes with Windows 10.</span></span> <span data-ttu-id="73778-122">また新しい概念モデルでは、アプリはユニバーサル Windows プラットフォーム (UWP) をターゲットとし、すべての Windows デバイスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="73778-122">The new conceptual model is that an app targets the Universal Windows Platform (UWP) and runs across all Windows devices.</span></span> <span data-ttu-id="73778-123">また、特定のデバイス ファミリ専用の機能を使うように指定することができます。</span><span class="sxs-lookup"><span data-stu-id="73778-123">It can then opt to light up features that are exclusive to particular device families.</span></span> <span data-ttu-id="73778-124">必要な場合は、アプリのターゲットを 1 つまたは複数のデバイス ファミリに限定するオプションをアプリに設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="73778-124">If needed, the app also has the option to limit itself to targeting one or more device families specifically.</span></span> <span data-ttu-id="73778-125">デバイス ファミリの説明や、ターゲットにするデバイス ファミリを決定する方法について詳しくは、「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73778-125">For more info on what device families are—and how to decide which device family to target—see [Guide to UWP apps](https://msdn.microsoft.com/library/windows/apps/dn894631).</span></span>

<span data-ttu-id="73778-126">ユニバーサル 8.1 アプリが実行されているオペレーティング システムを検出するコードがそのアプリに含まれている場合、ロジックによってはそのコードの変更が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="73778-126">If you have code in your Universal 8.1 app that detects what operating system it is running on, then you may need to change that depending on the reason for the logic.</span></span> <span data-ttu-id="73778-127">アプリが値をパススルーし、その値を処理しないとき、場合によっては、オペレーティング システムに関する情報を継続して収集する必要があります。</span><span class="sxs-lookup"><span data-stu-id="73778-127">If the app is passing the value through, and not acting on it, then you may want to continue to collect the operating system info.</span></span>

<span data-ttu-id="73778-128">**注:** 機能の有無を検出する際に、オペレーティング システムやデバイス ファミリを使わないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="73778-128">**Note**   We recommend that you not use operating system or device family to detect the presence of features.</span></span> <span data-ttu-id="73778-129">通常、現在のオペレーティング システムやデバイス ファミリを識別する手法は、特定のオペレーティング システムやデバイス ファミリの機能の有無を判別する際には最適な方法ではありません。</span><span class="sxs-lookup"><span data-stu-id="73778-129">Identifying the current operating system or device family is usually not the best way to determine whether a particular operating system or device family feature is present.</span></span> <span data-ttu-id="73778-130">オペレーティング システムやデバイス ファミリ (およびバージョン番号) を検出するのではなく、機能自体の存在をテストしてください (「[条件付きコンパイルとアダプティブ コード](w8x-to-uwp-porting-to-a-uwp-project.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="73778-130">Rather than detecting the operating system or device family (and version number), test for the presence of the feature itself (see [Conditional compilation, and adaptive code](w8x-to-uwp-porting-to-a-uwp-project.md)).</span></span> <span data-ttu-id="73778-131">特定のオペレーティング システムやデバイス ファミリの情報が必要な場合は、その情報を、サポートされる最小バージョンとして使ってください。そのバージョン用のテストは設計しないでください。</span><span class="sxs-lookup"><span data-stu-id="73778-131">If you must require a particular operating system or device family, be sure to use it as a minimum supported version, rather than design the test for that one version.</span></span>

 

<span data-ttu-id="73778-132">さまざまなデバイスに合わせてアプリの UI を調整するには、推奨される方法がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="73778-132">To tailor your app's UI to different devices, there are several techniques that we recommend.</span></span> <span data-ttu-id="73778-133">これまでと同様に、自動的にサイズ調整される要素と動的レイアウト パネルを引き続き使います。</span><span class="sxs-lookup"><span data-stu-id="73778-133">Continue to use auto-sized elements and dynamic layout panels as you always have.</span></span> <span data-ttu-id="73778-134">また、XAML マークアップで、有効ピクセル (以前の表示ピクセル) 単位でサイズを引き続き使います。これにより、UI がさまざまな解像度やスケール ファクターに対応します (「[有効ピクセル、視聴距離、スケール ファクター](w8x-to-uwp-porting-xaml-and-ui.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="73778-134">In your XAML markup, continue to use sizes in effective pixels (formerly view pixels) so that your UI adapts to different resolutions and scale factors (see [Effective pixels, viewing distance, and scale factors](w8x-to-uwp-porting-xaml-and-ui.md).).</span></span> <span data-ttu-id="73778-135">Visual State Manager のアダプティブなトリガーとセッターを使って、UI をウィンドウ サイズに対応させることもできます (「[UWP アプリのガイド](https://msdn.microsoft.com/library/windows/apps/dn894631)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="73778-135">And use Visual State Manager's adaptive triggers and setters to adapt your UI to the window size (see [Guide to UWP apps](https://msdn.microsoft.com/library/windows/apps/dn894631).).</span></span>

<span data-ttu-id="73778-136">ただし、デバイス ファミリの検出が必須となるシナリオの場合は、デバイス ファミリの検出を行ってください。</span><span class="sxs-lookup"><span data-stu-id="73778-136">However, if you have a scenario where it is unavoidable to detect the device family, then you can do that.</span></span> <span data-ttu-id="73778-137">次の例では、[**AnalyticsVersionInfo**](https://msdn.microsoft.com/library/windows/apps/dn960165) クラスを使い、必要に応じてモバイル デバイス ファミリ向けに調整されたページに移動し、該当しない場合は既定のページにフォール バックします。</span><span class="sxs-lookup"><span data-stu-id="73778-137">In this example, we use the [**AnalyticsVersionInfo**](https://msdn.microsoft.com/library/windows/apps/dn960165) class to navigate to a page tailored for the mobile device family where appropriate, and we make sure to fall back to a default page otherwise.</span></span>

```csharp
   if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
        rootFrame.Navigate(typeof(MainPageMobile), e.Arguments);
    else
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

<span data-ttu-id="73778-138">アプリでは、リソースの選択に関する有効な要因に基づいて、アプリが実行されているデバイス ファミリを判別することもできます。</span><span class="sxs-lookup"><span data-stu-id="73778-138">Your app can also determine the device family that it is running on from the resource selection factors that are in effect.</span></span> <span data-ttu-id="73778-139">次の例は、この操作を命令を使って実行する方法を示しています。「[**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/br206071)」トピックには、このクラスを使い、デバイス ファミリに関する要因に基づいてデバイス ファミリ固有のリソースを読み込む場合の一般的な使用例が説明されています。</span><span class="sxs-lookup"><span data-stu-id="73778-139">The example below shows how to do this imperatively, and the [**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/br206071) topic describes the more typical use case for the class in loading device family-specific resources based on the device family factor.</span></span>

```csharp
var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
string deviceFamilyName;
bool isDeviceFamilyNameKnown = qualifiers.TryGetValue("DeviceFamily", out deviceFamilyName);
```

<span data-ttu-id="73778-140">「[条件付きコンパイルとアダプティブ コード](w8x-to-uwp-porting-to-a-uwp-project.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="73778-140">Also, see [Conditional compilation, and adaptive code](w8x-to-uwp-porting-to-a-uwp-project.md).</span></span>

## <a name="location"></a><span data-ttu-id="73778-141">位置情報</span><span class="sxs-lookup"><span data-stu-id="73778-141">Location</span></span>


<span data-ttu-id="73778-142">アプリ パッケージ マニフェストで位置情報機能を宣言するアプリを Windows 10 で実行する場合、システムはエンド ユーザーに同意を求めます。</span><span class="sxs-lookup"><span data-stu-id="73778-142">When an app that declares the Location capability in its app package manifest runs on Windows 10, the system will prompt the end-user for consent.</span></span> <span data-ttu-id="73778-143">これは、アプリが Windows Phone ストア アプリの場合でも、Windows 10 アプリの場合でも同じです。</span><span class="sxs-lookup"><span data-stu-id="73778-143">This is true whether the app is a Windows Phone Store app or a Windows 10 app.</span></span> <span data-ttu-id="73778-144">アプリが独自の同意プロンプトを表示する場合や、オン/オフ切り替えを提供する場合、エンド ユーザーの確認を 1 回のみにするためにその機能を削除できます。</span><span class="sxs-lookup"><span data-stu-id="73778-144">So, if your app displays its own custom consent prompt, or if it provides an on-off toggle, then you will want to remove that so that the end-user is only prompted once.</span></span>

 

 




