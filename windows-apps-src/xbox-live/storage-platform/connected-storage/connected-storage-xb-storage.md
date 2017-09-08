---
title: "ローカル接続ストレージの管理"
author: KevinAsgari
description: "開発環境でローカル接続ストレージ データを管理する方法について説明します。"
ms.assetid: 630cb5fc-5d48-4026-8d6c-3aa617d75b2e
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ"
ms.openlocfilehash: 9acab570049922f3dbe83538d473e0e9523da4d2
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="managing-local-connected-storage"></a><span data-ttu-id="afac1-104">ローカル接続ストレージの管理</span><span class="sxs-lookup"><span data-stu-id="afac1-104">Managing local Connected Storage</span></span>

<span data-ttu-id="afac1-105">*xbStorage* は、Xbox One 開発キット上の接続ストレージのローカル データを開発用 PC から管理するための開発ツールです。</span><span class="sxs-lookup"><span data-stu-id="afac1-105">*xbStorage* is a development tool that allows managing the local data for Connected Storage on an Xbox One dev kit from a development PC.</span></span>

<span data-ttu-id="afac1-106">このツールでは、接続ストレージ領域からのローカル データをハード ドライブから消去したり、XML ファイルを使用して接続ストレージ領域からのユーザーまたはコンピューターのデータをインポートおよびエクスポートしたりできます。</span><span class="sxs-lookup"><span data-stu-id="afac1-106">It allows clearing, from the hard drive, the local data from Connected Storage Spaces, as well as importing and exporting of data for users or machines from Connected Storage Spaces by using XML files.</span></span>

<span data-ttu-id="afac1-107">接続ストレージ領域からのローカル データに対して操作が実行されると、その操作がアプリケーション自体によって実行されたかのようにシステムが動作するため、接続ストレージ領域からローカル ファイルにデータを読み取る処理によってコピー前にクラウドとの同期が発生します。</span><span class="sxs-lookup"><span data-stu-id="afac1-107">When an operation is performed on a local data from Connected Storage Space, the system will behave as if that operation had been performed by the app itself, so the act of reading the data from a Connected Storage Space to a local file will cause synchronization with the cloud prior to copying.</span></span>

<span data-ttu-id="afac1-108">同様に、開発用 PC 上の XML ファイルから Xbox One 開発キット上の接続ストレージ コンテナーにデータをコピーすると、本体がデータをクラウドにアップロードし始めます。</span><span class="sxs-lookup"><span data-stu-id="afac1-108">Similarly, a copy of data from an XML file on the development PC to a Connected Storage Container on the Xbox One dev kit will cause the console to start uploading that data to the cloud.</span></span> <span data-ttu-id="afac1-109">ただし、これが発生しない状況があります。開発キットがロックを取得できないか、本体上のコンテナーとクラウド内のコンテナーの間でデータの競合がある場合、保持するコンテナーの 1 つのバージョンを選ぶことによって競合を解決しないことをユーザーが決定したかのように本体は動作します。また本体は、次回タイトルが開始されるまで、ユーザーがオフラインでプレイしているかのように動作します。</span><span class="sxs-lookup"><span data-stu-id="afac1-109">However, there are conditions in which this will not occurr: if the dev kit cannot acquire the lock, or if there is a data conflict between the Containers on the console and those in the cloud, the console will behave as if the user had decided not to resolve the conflict by picking one version of the Container to keep, and the console will behave is if the user is playing offline until the next time the title is started.</span></span>

<span data-ttu-id="afac1-110">これらのコマンドの 1 つの例外は **reset****/f** です。これは、すべての SCID およびユーザーのセーブ データのローカル ストレージを消去しますが、クラウドに格納されているデータは変更しません。</span><span class="sxs-lookup"><span data-stu-id="afac1-110">The one exception to these commands is **reset** **/f** which clears the local storage of saved data for all SCIDs and users but does not alter the data stored in the cloud.</span></span> <span data-ttu-id="afac1-111">これは、タイトルのプレイ時にユーザーが本体にローミングしてクラウドからデータをダウンロードする場合の状態に本体を移行させるのに便利です。</span><span class="sxs-lookup"><span data-stu-id="afac1-111">This is useful for putting a console into the state it would be in if a user was roaming to a console and downloading data from the cloud upon playing a title.</span></span>

<span data-ttu-id="afac1-112">xbStorage の詳細については、XDK ドキュメントの「*接続ストレージの管理 (xbstorage.exe)*」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="afac1-112">For more information about xbStorage, see *Manage Connected Storage (xbstorage.exe)* in the XDK documentation.</span></span>
