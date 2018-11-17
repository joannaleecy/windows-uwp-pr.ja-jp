---
author: TerryWarwick
title: PointOfService デバイス オブジェクト
description: PointOfService デバイス オブジェクトの作成の詳細
ms.author: jken
ms.date: 06/19/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 31af943ab4a9231f58fb2e3d5489e9ae80d8d565
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151214"
---
# <a name="pointofservice-device-objects"></a><span data-ttu-id="b233f-104">PointOfService デバイス オブジェクト</span><span class="sxs-lookup"><span data-stu-id="b233f-104">PointOfService device objects</span></span>

## <a name="creating-a-device-object"></a><span data-ttu-id="b233f-105">デバイス オブジェクトの作成</span><span class="sxs-lookup"><span data-stu-id="b233f-105">Creating a device object</span></span>
<span data-ttu-id="b233f-106">新しい列挙または保存された DeviceID のいずれかから、使用する PointOfService デバイスを特定したら、プログラムにより選択した、またはユーザーが新しい POS デバイス オブジェクトを作成するために選択した [**DeviceID**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) を使用して [**FromIdAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="b233f-106">Once you have identified the PointOfService device that you want to use, either from a fresh enumeration or a stored DeviceID, you just call [**FromIdAsync**](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescanner.fromidasync) with the[**DeviceID**](https://docs.microsoft.com/uwp/api/windows.devices.enumeration.deviceinformation.id) that you have chosen programmatically or the user has selected to create a new Point of Service device object.</span></span>

<span data-ttu-id="b233f-107">このサンプルでは、DeviceID を使用して FromIdAsync で新しい BarcodeScanner オブジェクトを作成することを試みています。</span><span class="sxs-lookup"><span data-stu-id="b233f-107">This sample attempts to create a new BarcodeScanner object with FromIdAsync using a DeviceID.</span></span> <span data-ttu-id="b233f-108">オブジェクトの作成に失敗した場合は、デバッグ メッセージが書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="b233f-108">If there is a failure creating the object a debug message is written.</span></span>

```Csharp

    BarcodeScanner barcodeScanner = await BarcodeScanner.FromIdAsync(DeviceId);

    if(barcodeScanner != null)
    {
        // after successful creation, claim the scanner for exclusive use and enable it to exchange data
    }
    else
    {
        Debug.WriteLine("Failure to create barcodeScanner object");
    }
    
```

<span data-ttu-id="b233f-109">デバイス オブジェクトを作成したら、デバイスのメソッド、プロパティ、およびイベントにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="b233f-109">Once you have a device object, you can then access the device's methods, properties and events.</span></span>  

## <a name="device-object-lifecycle"></a><span data-ttu-id="b233f-110">デバイス オブジェクトのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="b233f-110">Device object lifecycle</span></span>
<span data-ttu-id="b233f-111">Windows 8 より前は、アプリのライフサイクルは単純でした。</span><span class="sxs-lookup"><span data-stu-id="b233f-111">Before Windows 8, apps had a simple lifecycle.</span></span> <span data-ttu-id="b233f-112">Win32 アプリや .NET アプリは、実行されているか、実行されていないかのどちらかであり、PointOfService 周辺機器は通常、アプリの完全なライフ サイクルに対して要求されています。</span><span class="sxs-lookup"><span data-stu-id="b233f-112">Win32 and .NET apps are either running or not running and PointOfService peripehrals were usually claimed for the full app lifecycle.</span></span> <span data-ttu-id="b233f-113">ユーザーがアプリを最小化し、他のアプリに切り替えても、アプリは引き続き実行されています。</span><span class="sxs-lookup"><span data-stu-id="b233f-113">When a user minimizes them, or switches away from them, they continue to run.</span></span> <span data-ttu-id="b233f-114">ポータブル デバイスが台頭し、電源管理がますます重要になるまでは、これで問題はありませんでした。</span><span class="sxs-lookup"><span data-stu-id="b233f-114">This was fine until portable devices and power management became increasingly important.</span></span>

<span data-ttu-id="b233f-115">Windows 8 では、UWP アプリにより新しいアプリケーション モデルが導入されました。</span><span class="sxs-lookup"><span data-stu-id="b233f-115">Windows 8 introduced a new application model with UWP apps.</span></span> <span data-ttu-id="b233f-116">大まかに言うと、新しい中断状態が追加されました。</span><span class="sxs-lookup"><span data-stu-id="b233f-116">At a high level, a new suspended state was added.</span></span> <span data-ttu-id="b233f-117">UWP アプリは、ユーザーがアプリを最小化するか、別のアプリに切り替えた後、すぐに中断されます。</span><span class="sxs-lookup"><span data-stu-id="b233f-117">A UWP app is suspended shortly after the user minimizes it or switches to another app.</span></span> <span data-ttu-id="b233f-118">つまり、アプリのスレッドは停止し、オペレーティング システムがリソースを再利用する必要がある場合を除き、アプリはメモリ内に残ります。PointOfService 周辺機器を表すデバイス オブジェクトは自動的に終了し、他のアプリケーションが周辺機器にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="b233f-118">This means that the app's threads are stopped, the app is left in memory unless the operating system needs to reclaim resources, and any device objects representing PointOfService peripherals are automatically closed to allow other applications access to the peripherals.</span></span> <span data-ttu-id="b233f-119">ユーザーが元のアプリに切り替えると、アプリはすばやく実行中の状態に復元されます。また、PointOfService 周辺機器が再開時にまだ利用可能であれば、PointOfService 周辺機器の接続が復元されます。</span><span class="sxs-lookup"><span data-stu-id="b233f-119">When the user switches back to the app, it can be quickly restored to a running state and restore PointOfService peripherals connections provided they are still available on resume.</span></span>

<span data-ttu-id="b233f-120">何らかの理由でオブジェクトが終了したときは <DeviceObject>.Closed イベント ハンドラーを使用して検出し、今後、接続を再確立するためにデバイス ID を記録します。</span><span class="sxs-lookup"><span data-stu-id="b233f-120">You can detect when an object is closed for any reason with a <DeviceObject>.Closed event handler then make note of the device ID for re-establishing the connection in the future.</span></span>   <span data-ttu-id="b233f-121">または、アプリの一時停止通知でこれを処理し、アプリの再開通知でデバイスの接続を再確立するためにデバイス ID を保存することができます。</span><span class="sxs-lookup"><span data-stu-id="b233f-121">Alternatively, you may wish to handle this on an App Suspend notification to save the device ID's for re-establishing the device connections on App Resume notifiation.</span></span>  <span data-ttu-id="b233f-122">イベント ハンドラーでダブルアップして <DeviceObject>.Closed および App Suspend の両方でデバイス オブジェクトの操作を重複しないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="b233f-122">Make sure that you do not double up on the event handlers and duplicate actions for the device object on both <DeviceObject>.Closed and App Suspend.</span></span>

> [!TIP]
> <span data-ttu-id="b233f-123">Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリケーションのライフサイクルの詳細については、次のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="b233f-123">Please refer to the following topics for more information about Windows 10 Universal Windows Platform (UWP) application lifecycle:</span></span>
> - [<span data-ttu-id="b233f-124">Windows 10 ユニバーサル Windows プラットフォーム (UWP) アプリのライフサイクル</span><span class="sxs-lookup"><span data-stu-id="b233f-124">Windows 10 Universal Windows Platform (UWP) app lifecycle</span></span>](../launch-resume/app-lifecycle.md)
> - [<span data-ttu-id="b233f-125">アプリの中断の処理</span><span class="sxs-lookup"><span data-stu-id="b233f-125">Handle app suspension</span></span>](../launch-resume/suspend-an-app.md)
> - [<span data-ttu-id="b233f-126">アプリの再開の処理</span><span class="sxs-lookup"><span data-stu-id="b233f-126">Handle app resume</span></span>](../launch-resume/resume-an-app.md)
