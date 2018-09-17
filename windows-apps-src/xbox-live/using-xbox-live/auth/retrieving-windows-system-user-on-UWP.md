---
title: UWP での Windows システム ユーザーの取得
author: KevinAsgari
description: ユニバーサル Windows プラットフォーム (UWP) ゲームで Windows システム ユーザーを取得する方法について説明します。
ms.author: kevinasg
ms.date: 06/07/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, システム ユーザー
ms.localizationpriority: medium
ms.openlocfilehash: 0533e9f63453ee2a7a8a7cb77f6f253e2d9c0e23
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3989508"
---
# <a name="retrieving-the-windows-system-user-in-a-universal-windows-platform-uwp-title"></a><span data-ttu-id="1e794-104">ユニバーサル Windows プラットフォーム (UWP) での Windows システム ユーザーの取得</span><span class="sxs-lookup"><span data-stu-id="1e794-104">Retrieving the Windows System User in a Universal Windows Platform (UWP) title</span></span>

## <a name="windowssystemuser"></a><span data-ttu-id="1e794-105">Windows.System.User</span><span class="sxs-lookup"><span data-stu-id="1e794-105">Windows.System.User</span></span>

<span data-ttu-id="1e794-106">[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) オブジェクトはローカル Windows ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="1e794-106">A [Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) object represents a local Windows user.</span></span> <span data-ttu-id="1e794-107">Xbox コンソールでは、1 つの対話型セッションで複数の Windows ユーザーを同時に記録できます。アプリがマルチ ユーザー アプリケーションの場合、Windows.System.User オブジェクトはライブ サービスにアクセスするために XboxLiveUser を構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1e794-107">On Xbox console, it allows multiple windows user to be logged in at the same time in a single interactive session, if your app is a multi-user application, then a Windows.System.User object would be required to construct a XboxLiveUser in order to access live services.</span></span> <span data-ttu-id="1e794-108">PC やスマートフォンなどの他の Windows プラットフォームでは、1 台のデバイスまたは 1 つの対話型セッションで 1 人の Windows ユーザーのみが許可されます。Windows.System.User を渡して XboxLiveUser を構築する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1e794-108">On other windows platforms like PC or phone, it's either only allow one windows user on one device or one interactive session, passing in a Windows.System.User to construct an XboxLiveUser is not required.</span></span>

## <a name="ways-to-retrieve-windows-system-user"></a><span data-ttu-id="1e794-109">Windows システム ユーザーの取得方法</span><span class="sxs-lookup"><span data-stu-id="1e794-109">Ways to retrieve Windows System User</span></span>

* **<span data-ttu-id="1e794-110">[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) クラスの静的メソッドを使う。</span><span class="sxs-lookup"><span data-stu-id="1e794-110">Using static methods from [Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) class.</span></span>**

  <span data-ttu-id="1e794-111">[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) クラスには、Windows.System.User オブジェクトを取得するための一連の静的メソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="1e794-111">[Windows.System.User](https://docs.microsoft.com/en-us/uwp/api/windows.system.user) class provides a set of static method to help retrieving Windows.System.User objects.</span></span> <span data-ttu-id="1e794-112">たとえば、FindAllAsync を呼び出してアクティブな Windows ユーザーをすべて取得できます。</span><span class="sxs-lookup"><span data-stu-id="1e794-112">For instance you may call FindAllAsync to get all active windows users.</span></span>

* **[<span data-ttu-id="1e794-113">UserPicker</span><span class="sxs-lookup"><span data-stu-id="1e794-113">UserPicker</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.system.userpicker)**

  <span data-ttu-id="1e794-114">[Windows.System.UserPicker](https://docs.microsoft.com/en-us/uwp/api/windows.system.userpicker) クラスには、ユーザー ピッカー UI を起動し、複数のユーザー シナリオで Windows システム ユーザーを選択するメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="1e794-114">[Windows.System.UserPicker](https://docs.microsoft.com/en-us/uwp/api/windows.system.userpicker) class provides methods to launch user picker UI and select a windows system user in multi-user scenarios.</span></span>

* **[<span data-ttu-id="1e794-115">IGameController</span><span class="sxs-lookup"><span data-stu-id="1e794-115">IGameController</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.igamecontroller)**

  <span data-ttu-id="1e794-116">[Windows.Gaming.Input.IGameController](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.igamecontroller) は、すべてのコントローラー デバイス (ゲームパッド、レーシング ハンドル、フライト スティックなど) のコア インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="1e794-116">[Windows.Gaming.Input.IGameController](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.igamecontroller) is the core interface for all controller devices(gamepad, racing wheel, flight stick etc.).</span></span> <span data-ttu-id="1e794-117">User プロパティを呼び出すことによって、ゲーム コントローラーに関連付けられている Windows.System.User オブジェクトを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="1e794-117">You may get the Windows.System.User object associated with the game controller by calling its User property.</span></span>  

  <span data-ttu-id="1e794-118">Windows により実装されているゲーム コントローラーには、[ArcadeStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[Gamepad](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamepad), [RacingWheel](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.racingwheel) などがあります。</span><span class="sxs-lookup"><span data-stu-id="1e794-118">Here are couple game controller implemented by windows [ArcadeStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.arcadestick), [FlightStick](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick), [Gamepad](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamepad), [RacingWheel](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.racingwheel).</span></span>

* **[<span data-ttu-id="1e794-119">UserDeviceAssociation</span><span class="sxs-lookup"><span data-stu-id="1e794-119">UserDeviceAssociation</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.system.userdeviceassociation)**

  <span data-ttu-id="1e794-120">静的メソッド FindUserFromDeviceId を呼び出して、関連するユーザーとデバイス ID を検索することができます。デバイス ID は通常、[Windows.UI.Xaml.Input.KeyRoutedEventArgs](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Input.KeyRoutedEventArgs)、[Windows.UI.Core.KeyEventArgs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.core.keyeventargs) などの Windows 入力イベントから取得できます。</span><span class="sxs-lookup"><span data-stu-id="1e794-120">You may call static method FindUserFromDeviceId to find the associated user with the device id. You can usually get the device id from windows input events, like [Windows.UI.Xaml.Input.KeyRoutedEventArgs](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Input.KeyRoutedEventArgs), [Windows.UI.Core.KeyEventArgs](https://docs.microsoft.com/en-us/uwp/api/windows.ui.core.keyeventargs)</span></span>
