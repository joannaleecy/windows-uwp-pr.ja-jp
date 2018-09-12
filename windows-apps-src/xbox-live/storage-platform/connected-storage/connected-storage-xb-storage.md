---
title: ローカル接続ストレージの管理
author: aablackm
description: 開発環境でローカル接続ストレージ データを管理する方法について説明します。
ms.assetid: 630cb5fc-5d48-4026-8d6c-3aa617d75b2e
ms.author: aablackm
ms.date: 02/27/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, 接続ストレージ
ms.localizationpriority: medium
ms.openlocfilehash: 5185ae50b428302c26b7a38389e4b925dcecd552
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3934052"
---
# <a name="managing-local-connected-storage"></a><span data-ttu-id="c1a71-104">ローカル接続ストレージの管理</span><span class="sxs-lookup"><span data-stu-id="c1a71-104">Managing local Connected Storage</span></span>
<span data-ttu-id="c1a71-105">接続ストレージは、ゲーム データをクラウドに保存するために使用されますが、接続ストレージ サービスへのローカル ストレージ コンポーネントもあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-105">While Connected Storage is used to store your game data in the cloud, there is also a local storage component to the Connected Storage service.</span></span> <span data-ttu-id="c1a71-106">PC を使っているか本体を使っているかに関係なく、接続ストレージ データのローカル キャッシュが存在し、クラウドに同期されたデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c1a71-106">Whether you are on a PC or console there is a local cache of the Connected Storage data which contains the data synced to the cloud.</span></span> <span data-ttu-id="c1a71-107">XDK タイトルを作成するのか UWP タイトルを作成するのかに関係なく、ローカルの接続ストレージ データを管理できるツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c1a71-107">Whether you are creating an XDK or UWP title there is a tool to allow you to manage your local Connected Storage data.</span></span>

<span data-ttu-id="c1a71-108">ローカルにキャッシュされた接続ストレージ データを管理するのに適したツールを見つけるには、次の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-108">Refer to the following table to find the appropriate tool to manage your locally cached Connected Storage data:</span></span>

|<span data-ttu-id="c1a71-109">タイトル分類</span><span class="sxs-lookup"><span data-stu-id="c1a71-109">Title Classification</span></span>  |<span data-ttu-id="c1a71-110">デバイス</span><span class="sxs-lookup"><span data-stu-id="c1a71-110">Device</span></span>  |<span data-ttu-id="c1a71-111">ローカル ストレージ ツール</span><span class="sxs-lookup"><span data-stu-id="c1a71-111">Local Storage Tool</span></span>  |
|---------|---------|---------|
|<span data-ttu-id="c1a71-112">XDK</span><span class="sxs-lookup"><span data-stu-id="c1a71-112">XDK</span></span>     |<span data-ttu-id="c1a71-113">Xbox One 本体</span><span class="sxs-lookup"><span data-stu-id="c1a71-113">Xbox One Console</span></span>     |*<span data-ttu-id="c1a71-114">xbstorage</span><span class="sxs-lookup"><span data-stu-id="c1a71-114">xbstorage</span></span>*         |
|<span data-ttu-id="c1a71-115">UWP</span><span class="sxs-lookup"><span data-stu-id="c1a71-115">UWP</span></span>     |<span data-ttu-id="c1a71-116">PC</span><span class="sxs-lookup"><span data-stu-id="c1a71-116">PC</span></span>         |*<span data-ttu-id="c1a71-117">gamesaveutil</span><span class="sxs-lookup"><span data-stu-id="c1a71-117">gamesaveutil</span></span>*         |
|<span data-ttu-id="c1a71-118">UWP</span><span class="sxs-lookup"><span data-stu-id="c1a71-118">UWP</span></span>     |<span data-ttu-id="c1a71-119">Xbox One 本体</span><span class="sxs-lookup"><span data-stu-id="c1a71-119">Xbox One Console</span></span>     |<span data-ttu-id="c1a71-120">Xbox Device Portal (XDP)</span><span class="sxs-lookup"><span data-stu-id="c1a71-120">Xbox Device Portal(XDP</span></span> |<span data-ttu-id="c1a71-121">)</span><span class="sxs-lookup"><span data-stu-id="c1a71-121">)</span></span>

- <span data-ttu-id="c1a71-122">*Xbstorage* は、Xbox One 本体でローカルにキャッシュされた接続ストレージを管理するためのコマンド ライン ツールで、XDK コマンド プロンプトから実行します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-122">*Xbstorage* is a command line tool, run from the XDK command prompt, for managing locally cached Connected Storage on the Xbox One Console.</span></span> <span data-ttu-id="c1a71-123">*xbstorage* ツールは、パス **/Program Files (x86)/Microsoft Durango XDK/bin/xbstorage.exe** の Xbox One XDK にあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-123">The *xbstorage* tool can be found in the Xbox One XDK under the file path: **/Program Files (x86)/Microsoft Durango XDK/bin/xbstorage.exe**</span></span>
- <span data-ttu-id="c1a71-124">*Gamesaveutil* は、PC のローカルにキャッシュされた UWP の接続ストレージを管理するためのコマンド ライン ツールです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-124">*Gamesaveutil* is a command line tool for managing UWP locally cached Connected Storage on PC.</span></span> <span data-ttu-id="c1a71-125">*gamesaveutil* ツールは、Fall Creators Update 以降 (ビルド 10.0.16299.15 以降) の [Windows 10 SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk) に付属しています。</span><span class="sxs-lookup"><span data-stu-id="c1a71-125">The *gamesaveutil* tool comes packaged with the [Windows 10 SDK](https://developer.microsoft.com/en-US/windows/downloads/windows-10-sdk) for Fall Creators Update and later( build 10.0.16299.15 and later).</span></span> <span data-ttu-id="c1a71-126">該当するバージョンの Windows 10 SDK をインストールすると、フォルダー **ProgramFiles(x86)/Windows Kits/10/bin/[SDK Version]/x64/gamesaveutil.exe** に *gamesaveutil* が配置されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-126">Once you've installed the appropriate version of the Windows 10 SDK, *gamesaveutil* can be found under the folder: **ProgramFiles(x86)/Windows Kits/10/bin/[SDK Version]/x64/gamesaveutil.exe**.</span></span>
- <span data-ttu-id="c1a71-127">*Xbox Device Portal (XDP)* は、Xbox One 本体のローカルにキャッシュされた接続ストレージ UWP データを管理できるオンライン ポータルです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-127">*Xbox Device Portal(XDP)* is an online portal that allows you to manage the locally cached Connected Storage UWP data on your Xbox One Console.</span></span> <span data-ttu-id="c1a71-128">この記事では、XDP の使用については取り上げません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-128">This article does not cover XDP usage.</span></span> <span data-ttu-id="c1a71-129">XDP の使い方については、[Xbox 用のデバイス ポータルに関するページ](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-xbox)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-129">To learn to use XDP read [Device Portal for Xbox](https://docs.microsoft.com/en-us/windows/uwp/debug-test-perf/device-portal-xbox).</span></span>

## <a name="xbstorage"></a><span data-ttu-id="c1a71-130">Xbstorage</span><span class="sxs-lookup"><span data-stu-id="c1a71-130">Xbstorage</span></span>

<span data-ttu-id="c1a71-131">*Xbstorage* では、ローカルにキャッシュされた接続ストレージ データをハード ドライブから消去したり、XML ファイルを使用して接続ストレージ領域からのユーザーまたはコンピューターのデータをインポートおよびエクスポートしたりできます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-131">*Xbstorage* allows clearing locally cached data Connected Storage data from the hard drive, as well as importing and exporting of data for users or machines from Connected Storage spaces by using XML files.</span></span>

<span data-ttu-id="c1a71-132">*xbstorage* ツールを使ってローカル データに対して操作が実行されると、その操作がアプリケーション自体によって実行されたかのようにシステムが動作するため、接続ストレージ領域からローカル ファイルにデータを読み取る処理によってコピー前にクラウドとの同期が発生します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-132">When an operation is performed on local data using the *xbstorage* tool, the system will behave as if that operation had been performed by the app itself, so the act of reading the data from a Connected Storage space to a local file will cause synchronization with the cloud prior to copying.</span></span>

<span data-ttu-id="c1a71-133">同様に、開発用 PC 上の XML ファイルから Xbox One 開発キット上の接続ストレージ コンテナーにデータをコピーすると、本体がデータをクラウドにアップロードし始めます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-133">Similarly, a copy of data from an XML file on the development PC to a Connected Storage container on the Xbox One dev kit will cause the console to start uploading that data to the cloud.</span></span> <span data-ttu-id="c1a71-134">ただし、これが発生しない状況があります。開発キットがロックを取得できないか、本体上のコンテナーとクラウド内のコンテナーの間でデータの競合がある場合、保持するコンテナーの 1 つのバージョンを選ぶことによって競合を解決しないことをユーザーが決定したかのように本体は動作します。また本体は、次回タイトルが開始されるまで、ユーザーがオフラインでプレイしているかのように動作します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-134">However, there are conditions in which this will not occur: if the dev kit cannot acquire the lock, or if there is a data conflict between the containers on the console and those in the cloud, the console will behave as if the user had decided not to resolve the conflict by picking one version of the container to keep, and the console will behave as if the user is playing offline until the next time the title is started.</span></span>

<span data-ttu-id="c1a71-135">これらのコマンドの 1 つの例外は **reset\*\*\*\*/force** です。これは、すべての SCID およびユーザーのセーブ データのローカル ストレージを消去しますが、クラウドに格納されているデータは変更しません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-135">The one exception to these commands is **reset** **/force** which clears the local storage of saved data for all SCIDs and users, but does not alter the data stored in the cloud.</span></span> <span data-ttu-id="c1a71-136">これは、タイトルのプレイ時にユーザーが本体にローミングしてクラウドからデータをダウンロードする場合の状態に本体を移行させるのに便利です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-136">This is useful for putting a console into the state it would be in if a user was roaming to a console and downloading data from the cloud upon playing a title.</span></span>

### <a name="xbstorage-commands"></a><span data-ttu-id="c1a71-137">Xbstorage のコマンド</span><span class="sxs-lookup"><span data-stu-id="c1a71-137">Xbstorage commands</span></span>

<span data-ttu-id="c1a71-138">Xbstorage には、開発者が XDK コマンド プロンプトで使うことができる以下の 6 つのコマンドがあり、Xbox One 開発キットでローカル データを管理できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-138">Xbstorage has the following six commands developers can use with the XDK command prompt to manage local data on their Xbox One Development Kit:</span></span>

<a id="xbstorage_reset"></a>

|<span data-ttu-id="c1a71-139">コマンド</span><span class="sxs-lookup"><span data-stu-id="c1a71-139">Command</span></span>  |<span data-ttu-id="c1a71-140">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-140">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-141">reset</span><span class="sxs-lookup"><span data-stu-id="c1a71-141">reset</span></span>    |<span data-ttu-id="c1a71-142">接続ストレージを工場出荷時の状態にリセットします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-142">Performs a factory reset on Connected Storage.</span></span>         |
|<span data-ttu-id="c1a71-143">import</span><span class="sxs-lookup"><span data-stu-id="c1a71-143">import</span></span>   |<span data-ttu-id="c1a71-144">指定された XML ファイルから接続ストレージ領域にデータをインポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-144">Imports data from the specified XML file to a Connected Storage space.</span></span>         |
|<span data-ttu-id="c1a71-145">export</span><span class="sxs-lookup"><span data-stu-id="c1a71-145">export</span></span>   |<span data-ttu-id="c1a71-146">接続ストレージ領域から指定された XML ファイルにデータをエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-146">Exports data from a Connected Storage space to the specified XML file.</span></span>         |
|<span data-ttu-id="c1a71-147">delete</span><span class="sxs-lookup"><span data-stu-id="c1a71-147">delete</span></span>   |<span data-ttu-id="c1a71-148">接続ストレージ領域からデータを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-148">Deletes data from a Connected Storage space.</span></span>         |
|<span data-ttu-id="c1a71-149">generate</span><span class="sxs-lookup"><span data-stu-id="c1a71-149">generate</span></span> |<span data-ttu-id="c1a71-150">ダミー データを生成し、指定された XML ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-150">Generates dummy data and saves to the specified XML file.</span></span>         |
|<span data-ttu-id="c1a71-151">simulate</span><span class="sxs-lookup"><span data-stu-id="c1a71-151">simulate</span></span> |<span data-ttu-id="c1a71-152">ストレージの領域不足状態をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-152">Simulates out of storage space conditions.</span></span>         |

### <a name="xbstorage-reset"></a><span data-ttu-id="c1a71-153">Xbstorage reset</span><span class="sxs-lookup"><span data-stu-id="c1a71-153">Xbstorage reset</span></span>

`xbstorage reset [/force]`

<span data-ttu-id="c1a71-154">ローカル本体から接続ストレージ内のすべてのローカル データを消去し、工場出荷時の設定に戻します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-154">Erases all local data in Connected Storage from the local console, restoring it to factory settings.</span></span> <span data-ttu-id="c1a71-155">クラウドに保持されているデータは変更されず、必要に応じて再びダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-155">Data that has been persisted to the cloud is not modified and will be downloaded again as necessary.</span></span>

|<span data-ttu-id="c1a71-156">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-156">Option</span></span>  |<span data-ttu-id="c1a71-157">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-157">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-158">/force</span><span class="sxs-lookup"><span data-stu-id="c1a71-158">/force</span></span>   |<span data-ttu-id="c1a71-159">接続ストレージをリセットする必要があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-159">Confirms that Connected Storage should be reset.</span></span> <span data-ttu-id="c1a71-160">**/force** を指定しないで reset コマンドを実行すると、次のメッセージが表示されます。接続ストレージを出荷時の状態にリセットすることは破壊的な操作である可能性があるため、このコマンドは **/force** フラグが存在しない限りリセットを実行しません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-160">Running the reset command without specifying **/force** causes the following message to be displayed:   As Connected Storage factory reset is a potentially destructive operation this command does not perform the reset unless the **/force** flag is present.</span></span> |

<a id="xbstorage_import"></a>

### <a name="xbstorage-import"></a><span data-ttu-id="c1a71-161">Xbstorage import</span><span class="sxs-lookup"><span data-stu-id="c1a71-161">Xbstorage import</span></span>

`xbstorage import *file-name* [/scid:*SCID*] [/machine] [/msa:*account*] [/replace] [/verbose]`

<span data-ttu-id="c1a71-162">*filename* に指定されたデータを接続ストレージ領域にインポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-162">Imports data specified in *filename* to a Connected Storage space.</span></span>
<span data-ttu-id="c1a71-163">このファイルはデータが含まれる XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-163">The file is an XML file that contains the data.</span></span> <span data-ttu-id="c1a71-164">例については、「[xbstorage generate](#xbstorage_generate)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-164">For an example, see [xbstorage generate](#xbstorage_generate).</span></span> <span data-ttu-id="c1a71-165">ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-165">For more information about the file's XML format, see [Import and export file format](#xbstorage_fileformat), later in this topic.</span></span>
<span data-ttu-id="c1a71-166">接続ストレージ領域を指定するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-166">There are two ways to specify the Connected Storage space:</span></span>

- <span data-ttu-id="c1a71-167">入力ファイルに **ContextDescription** セクションがあり適切に入力されている場合は、これを使用して接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-167">If the input file has a **ContextDescription** section that is correctly populated, then this will be used to specify the Connected Storage space.</span></span>
- <span data-ttu-id="c1a71-168">ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは入力ファイルに指定されているストレージ領域の対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-168">The storage space can also be partially or fully specified via command-line parameters, which take precedence over the respective elements of the storage space specified in the input file.</span></span>

<span data-ttu-id="c1a71-169">使用法の例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-169">Examples of usage:</span></span>

```cmd
  xbstorage import mydata.xml
  xbstorage import mydata.xml /replace
  xbstorage import mydata.xml /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage import mydata.xml /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage import mydata.xml /verbose 
```

> [!NOTE]
> <span data-ttu-id="c1a71-170">指定された接続ストレージ領域にインポートする前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-170">Before importing to the specified Connected Storage space, the system will attempt to synchronize with the cloud using the same logic that runs when a Connected Storage space is acquired by a running app.</span></span>
>
> <span data-ttu-id="c1a71-171">同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-171">If an application with the same Primary SCID is running, this operation could cause a race condition, and the contents of the Connected Storage space could be in an indeterminate state.</span></span>
>
> <span data-ttu-id="c1a71-172">**/replace** が指定されていない場合、入力ファイルに指定されている BLOB を書き込む前に、入力ファイルに指定されたコンテナーが消去されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-172">If **/replace** is not specified, the containers specified in the input file will be erased before writing the blobs specified in the input file.</span></span> <span data-ttu-id="c1a71-173">入力ファイルに指定されていない接続ストレージ領域内のコンテナーはそのまま維持されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-173">Containers in the Connected Storage space not specified in the input file will remain untouched.</span></span>

|<span data-ttu-id="c1a71-174">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-174">Option</span></span>  |<span data-ttu-id="c1a71-175">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-175">Description</span></span>  |
|---------|---------|
|*<span data-ttu-id="c1a71-176">file-name</span><span class="sxs-lookup"><span data-stu-id="c1a71-176">file-name</span></span>*     |<span data-ttu-id="c1a71-177">インポートするデータが含まれている XML ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-177">Specifies an XML file that contains the data to import.</span></span>         |
|<span data-ttu-id="c1a71-178">/scid:*SCID*</span><span class="sxs-lookup"><span data-stu-id="c1a71-178">/scid:*SCID*</span></span>    |<span data-ttu-id="c1a71-179">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-179">Specifies the Service Configuration Identifier (SCID).</span></span>         |
|<span data-ttu-id="c1a71-180">/machine</span><span class="sxs-lookup"><span data-stu-id="c1a71-180">/machine</span></span>        |<span data-ttu-id="c1a71-181">コンピューターごとの接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-181">Specifies a per-machine Connected Storage space.</span></span>  <span data-ttu-id="c1a71-182">このオプションと **/msa** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-182">This option cannot be used simultaneously with the **/msa** option.</span></span>         |
|<span data-ttu-id="c1a71-183">/msa:*account*</span><span class="sxs-lookup"><span data-stu-id="c1a71-183">/msa:*account*</span></span>  |<span data-ttu-id="c1a71-184">ユーザーごとの接続ストレージに使用するアカウントを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-184">Specifies an account to use for per-user Connected Storage.</span></span> <span data-ttu-id="c1a71-185">ユーザーが領域を使用するには、本体にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-185">The user must be signed in to the console for the space to be used.</span></span>  <span data-ttu-id="c1a71-186">このオプションと **/machine** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-186">This option cannot be used simultaneously with the **/machine** option.</span></span>         |
|<span data-ttu-id="c1a71-187">/replace</span><span class="sxs-lookup"><span data-stu-id="c1a71-187">/replace</span></span>        |<span data-ttu-id="c1a71-188">インポートを実行する前に、指定された接続ストレージ領域内のすべてのコンテナーを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-188">Deletes all containers in the specified Connected Storage space before importing.</span></span>         |
|<span data-ttu-id="c1a71-189">/verbose</span><span class="sxs-lookup"><span data-stu-id="c1a71-189">/verbose</span></span>        |<span data-ttu-id="c1a71-190">インポートの状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-190">Displays the status of the importation.</span></span>         |


 <a id="xbstorage_export"></a>

### <a name="xbstorage-export"></a><span data-ttu-id="c1a71-191">Xbstorage export</span><span class="sxs-lookup"><span data-stu-id="c1a71-191">Xbstorage export</span></span>

`xbstorage export *outfile* [/context:*input-file*] [/scid:*SCID*] [/machine] [/msa:*account*] [/verbose]`

<span data-ttu-id="c1a71-192">接続ストレージ領域から、**outfile** によって指定されたファイルにデータをエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-192">Exports data from a Connected Storage space to the file specified by **outfile**.</span></span>    <span data-ttu-id="c1a71-193">このファイルはデータが含まれる XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-193">The file is an XML file that contains the data.</span></span> <span data-ttu-id="c1a71-194">例を生成する方法については「[xbstorage generate](#xbstorage_generate)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-194">See [xbstorage generate](#xbstorage_generate) to see how to generate an example.</span></span> <span data-ttu-id="c1a71-195">ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-195">For more information about the file's XML format, see [Import and export file format](#xbstorage_fileformat), later in this topic.</span></span> <span data-ttu-id="c1a71-196">接続ストレージ領域を指定するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-196">There are two ways to specify the Connected Storage space:</span></span>

- <span data-ttu-id="c1a71-197">**/context** パラメーターが使用され、\<infile> によって指定された名前のファイルに **ContextDescription** セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用して接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-197">If the **/context** parameter is used, and the file name specified by \<infile> has a **ContextDescription** section that is correctly populated, then that file will be used to specify the Connected Storage space.</span></span>
- <span data-ttu-id="c1a71-198">ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは **/context** ファイルに指定されているストレージ領域の対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-198">The storage space can also be partially or fully specified via command-line parameters, which take precedence over the respective elements of the storage space specified in the **/context** file.</span></span>

<span data-ttu-id="c1a71-199">使用法の例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-199">Examples of usage:</span></span>

```cmd
  xbstorage export exporteddata.xml /context:space.xml
  xbstorage export exporteddata.xml /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage export exporteddata.xml /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage export exporteddata.xml /context:space.xml /verbose
```

> [!NOTE]
> <span data-ttu-id="c1a71-200">指定された接続ストレージ領域をエクスポートする前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-200">Before exporting the specified Connected Storage space, the system will attempt to synchronize with the cloud using the same logic that runs when a Connected Storage space is acquired by a running app.</span></span>
>
> <span data-ttu-id="c1a71-201">同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-201">If an application with the same Primary SCID is running, this operation could cause a race condition, and the contents of the Connected Storage space could be in an indeterminate state.</span></span>

|<span data-ttu-id="c1a71-202">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-202">Option</span></span>  |<span data-ttu-id="c1a71-203">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-203">Description</span></span>  |
|---------|---------|
|*<span data-ttu-id="c1a71-204">outfile</span><span class="sxs-lookup"><span data-stu-id="c1a71-204">outfile</span></span>*             |<span data-ttu-id="c1a71-205">データのエクスポート先となる XML ファイル。</span><span class="sxs-lookup"><span data-stu-id="c1a71-205">XML file the data will be exported to.</span></span>         |
|<span data-ttu-id="c1a71-206">/context:*input-file*</span><span class="sxs-lookup"><span data-stu-id="c1a71-206">/context:*input-file*</span></span> |<span data-ttu-id="c1a71-207">領域情報を読み取る入力ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-207">Specifies an input file from which to read the space information.</span></span>         |
|<span data-ttu-id="c1a71-208">/scid:*SCID*</span><span class="sxs-lookup"><span data-stu-id="c1a71-208">/scid:*SCID*</span></span>          |<span data-ttu-id="c1a71-209">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-209">Specifies the service configuration identifier (SCID).</span></span>         |
|<span data-ttu-id="c1a71-210">/machine</span><span class="sxs-lookup"><span data-stu-id="c1a71-210">/machine</span></span>              |<span data-ttu-id="c1a71-211">コンピューターごとの接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-211">Specifies a per-machine Connected Storage space.</span></span>  <span data-ttu-id="c1a71-212">このオプションと **/msa** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-212">This option cannot be used simultaneously with the **/msa** option.</span></span>         |
|<span data-ttu-id="c1a71-213">/msa:*account*</span><span class="sxs-lookup"><span data-stu-id="c1a71-213">/msa:*account*</span></span>        |<span data-ttu-id="c1a71-214">ユーザーごとの接続ストレージに使用するアカウントを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-214">Specifies an account to use for per-user Connected Storage.</span></span> <span data-ttu-id="c1a71-215">ユーザーが領域を使用するには、本体にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-215">The user must be signed in to the console for the space to be used.</span></span>  <span data-ttu-id="c1a71-216">このオプションと **/machine** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-216">This option cannot be used simultaneously with the **/machine** option.</span></span>         |
|<span data-ttu-id="c1a71-217">/verbose</span><span class="sxs-lookup"><span data-stu-id="c1a71-217">/verbose</span></span>              |<span data-ttu-id="c1a71-218">エクスポート操作の状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-218">Displays the status of the export operation.</span></span>         |

<a id="xbstorage_delete"></a>

### <a name="xbstorage-delete"></a><span data-ttu-id="c1a71-219">Xbstorage delete</span><span class="sxs-lookup"><span data-stu-id="c1a71-219">Xbstorage delete</span></span>

`xbstorage delete [/context:*input-file*] [/scid:*SCID*] [/machine] [/msa:*account*] [/verbose]`

<span data-ttu-id="c1a71-220">接続ストレージ領域からすべてのデータを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-220">Deletes all data from a Connected Storage space.</span></span>
<span data-ttu-id="c1a71-221">接続ストレージ領域を指定するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-221">There are two ways to specify the Connected Storage space:</span></span>

- <span data-ttu-id="c1a71-222">**/context** パラメーターが使用され、\<infile> によって指定された名前のファイルに **ContextDescription** セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用して接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-222">If the **/context** parameter is used, and the file name specified by \<infile> has a **ContextDescription** section that is correctly populated, then that file will be used to specify the Connected Storage space.</span></span>
- <span data-ttu-id="c1a71-223">ストレージ領域はコマンドライン パラメーターによって部分的または完全に指定することもでき、これは **/context** ファイルに指定されているストレージ領域の対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-223">The storage space can also be partially or fully specified via command-line parameters, which take precedence over the respective elements of the storage space specified in the **/context** file.</span></span>

<span data-ttu-id="c1a71-224">使用法の例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-224">Examples of usage:</span></span>

```cmd
  xbstorage delete /context:space.xml
  xbstorage delete /machine /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage delete /msa:user@domain.com /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
  xbstorage delete /context:space.xml /verbose
```

> [!NOTE]
> <span data-ttu-id="c1a71-225">指定された接続ストレージ領域を削除する前に、システムは、実行中のアプリが接続ストレージ領域を取得するときに実行するのと同じロジックを使用して、クラウドとの同期を試みます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-225">Before deleting the specified Connected Storage space, the system will attempt to synchronize with the cloud using the same logic that runs when a Connected Storage space is acquired by a running app.</span></span>
>> <span data-ttu-id="c1a71-226">同じプライマリー SCID を持つアプリケーションが実行中である場合、この操作は競合状態を引き起こす可能性があり、接続ストレージ領域の内容が不確定な状態になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-226">If an application with the same Primary SCID is running, this operation could cause a race condition, and the contents of the Connected Storage space could be in an indeterminate state.</span></span>

|<span data-ttu-id="c1a71-227">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-227">Option</span></span>  |<span data-ttu-id="c1a71-228">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-228">Description</span></span> |
|---------|---------|
|<span data-ttu-id="c1a71-229">/context:*input-file*</span><span class="sxs-lookup"><span data-stu-id="c1a71-229">/context:*input-file*</span></span>     |<span data-ttu-id="c1a71-230">領域情報を読み取る入力ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-230">Specifies an input file from which to read the space information.</span></span>         |
|<span data-ttu-id="c1a71-231">/scid:*SCID*</span><span class="sxs-lookup"><span data-stu-id="c1a71-231">/scid:*SCID*</span></span>              |<span data-ttu-id="c1a71-232">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-232">Specifies the service configuration identifier (SCID).</span></span>         |
|<span data-ttu-id="c1a71-233">/machine</span><span class="sxs-lookup"><span data-stu-id="c1a71-233">/machine</span></span>                  |<span data-ttu-id="c1a71-234">コンピューターごとの接続ストレージ領域を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-234">Specifies a per-machine Connected Storage space.</span></span>  <span data-ttu-id="c1a71-235">このオプションと **/msa** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-235">This option cannot be used simultaneously with the **/msa** option.</span></span>         |
|<span data-ttu-id="c1a71-236">/msa:*account*</span><span class="sxs-lookup"><span data-stu-id="c1a71-236">/msa:*account*</span></span>            |<span data-ttu-id="c1a71-237">ユーザーごとの接続ストレージに使用するアカウントを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-237">Specifies an account to use for per-user Connected Storage.</span></span> <span data-ttu-id="c1a71-238">ユーザーが領域を使用するには、本体にサインインする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-238">The user must be signed in to the console for the space to be used.</span></span>  <span data-ttu-id="c1a71-239">このオプションと **/machine** オプションを同時に使用することはできません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-239">This option cannot be used simultaneously with the **/machine** option.</span></span>         |
|<span data-ttu-id="c1a71-240">/verbose</span><span class="sxs-lookup"><span data-stu-id="c1a71-240">/verbose</span></span>                  |<span data-ttu-id="c1a71-241">削除操作の状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-241">Displays the status of the delete operation.</span></span>         |

 <a id="xbstorage_generate"></a>

### <a name="xbstorage-generate"></a><span data-ttu-id="c1a71-242">Xbstorage generate</span><span class="sxs-lookup"><span data-stu-id="c1a71-242">Xbstorage generate</span></span>

`xbstorage generate *file-name* [/containers:*n*] [/blobs:*n*] [/blobsize:*n*]`

<span data-ttu-id="c1a71-243">ダミー データを生成し、\<filename> によって指定されたファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-243">Generates dummy data and saves to a file specified by \<filename>.</span></span> <span data-ttu-id="c1a71-244">ファイルの XML 形式の詳細については、後の「[インポートおよびエクスポートのファイル形式](#xbstorage_fileformat)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-244">For more information about the file's XML format, see [Import and export file format](#xbstorage_fileformat), later in this topic.</span></span>    <span data-ttu-id="c1a71-245">サービス構成 ID (SCID) は 00000000-0000-0000-0000-000000000000 に設定され、コンピューターごとの接続ストレージ領域用にアカウントが設定されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-245">The service configuration identifier (SCID) will be set to 00000000-0000-0000-0000-000000000000, and the account will be set for a per-machine Connected Storage space.</span></span> <span data-ttu-id="c1a71-246">これらの値を変更する場合は、生成された後のファイルを直接編集できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-246">If you want to change those values, you can edit the file directly after it is generated.</span></span>

<span data-ttu-id="c1a71-247">使用法の例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-247">Examples of usage:</span></span>

```cmd
  xbstorage generate dummydata.xml
  xbstorage generate dummydata.xml /containers:4
  xbstorage generate dummydata.xml /blobs:10
  xbstorage generate dummydata.xml /containers:4 /blobs:10
  xbstorage generate dummydata.xml /containers:4 /blobs:10 /blobsize:512
```

> [!NOTE]
> <span data-ttu-id="c1a71-248">バイト データは単純な昇順です。たとえば、5 バイトの BLOB は 00 01 02 03 04 のようなバイトで構成されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-248">The byte data is a simple ascending sequence; for example, a five-byte blob would have the following bytes: 00 01 02 03 04.</span></span> <span data-ttu-id="c1a71-249">>>  ユーザーごとの接続ストレージ領域を指定する場合は、XML ファイルの **Account** ノードを次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-249">>>  If you want to specify a per-user Connected Storage space, change the **Account** node in the XML file to something like the following:</span></span>
>  ```
>    <Account msa="user@domain.com"/>
>  ```

|<span data-ttu-id="c1a71-250">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-250">Option</span></span>  |<span data-ttu-id="c1a71-251">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-251">Description</span></span>  |
|---------|---------|
|*<span data-ttu-id="c1a71-252">file-name</span><span class="sxs-lookup"><span data-stu-id="c1a71-252">file-name</span></span>*     | <span data-ttu-id="c1a71-253">データの書き込み先となる XML ファイル。</span><span class="sxs-lookup"><span data-stu-id="c1a71-253">XML file the data will be written to.</span></span> |
|<span data-ttu-id="c1a71-254">/containers:*n*</span><span class="sxs-lookup"><span data-stu-id="c1a71-254">/containers:*n*</span></span> | <span data-ttu-id="c1a71-255">生成するコンテナーの数を *n* で指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-255">Specifies the number, *n*, of containers to generate.</span></span> <span data-ttu-id="c1a71-256">既定値は 2 です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-256">The default count is 2.</span></span>  |
|<span data-ttu-id="c1a71-257">/blobs:*n*</span><span class="sxs-lookup"><span data-stu-id="c1a71-257">/blobs:*n*</span></span>      | <span data-ttu-id="c1a71-258">生成する BLOB の数を *n* で指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-258">Specifies the number, *n*, of blobs to generate.</span></span> <span data-ttu-id="c1a71-259">既定値は 3 です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-259">The default count is 3.</span></span>  |
|<span data-ttu-id="c1a71-260">/blobsize:*n*</span><span class="sxs-lookup"><span data-stu-id="c1a71-260">/blobsize:*n*</span></span>   | <span data-ttu-id="c1a71-261">BLOB ごとのバイト数を *n* で指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-261">Specifies the number, *n*, of bytes per blob.</span></span> <span data-ttu-id="c1a71-262">既定のサイズは 1024 バイトです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-262">The default size is 1024 bytes.</span></span>  |

 <a id="xbstorage_simulate"></a>

### <a name="xbstorage-simulate"></a><span data-ttu-id="c1a71-263">Xbstorage simulate</span><span class="sxs-lookup"><span data-stu-id="c1a71-263">Xbstorage simulate</span></span>

`xbstorage simulate [/reserveremainingspace] [/forceoutoflocalstorage] [/stop] [/verbose]`

<span data-ttu-id="c1a71-264">接続ストレージ サービスのローカル ストレージが不足した状態をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-264">Simulates out of local storage conditions for the Connected Storage service.</span></span>

|<span data-ttu-id="c1a71-265">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-265">Option</span></span>  |<span data-ttu-id="c1a71-266">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-266">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-267">/reserveremainingspace</span><span class="sxs-lookup"><span data-stu-id="c1a71-267">/reserveremainingspace</span></span> | <span data-ttu-id="c1a71-268">接続ストレージの残りのすべての領域を予約します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-268">Reserves all remaining space in Connected Storage.</span></span> <span data-ttu-id="c1a71-269">接続ストレージからデータを削除すると、使用できる領域が増加します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-269">Deleting something from ConnectedStorage will open up space that you can use.</span></span> |

<span data-ttu-id="c1a71-270">|/forceoutoflocalstorage | 利用可能な領域が接続ストレージ サービスに残っていない状態をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-270">|/forceoutoflocalstorage | Simulates the Connected Storage Service having no available space left.</span></span> <span data-ttu-id="c1a71-271">接続ストレージからデータを削除しても、引き続き接続ストレージ サービスからメモリー不足が報告されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-271">Deleting something from Connected Storage will not change the Connected storage service from reporting out of memory.</span></span> |

<span data-ttu-id="c1a71-272">|/stop | すべてのシミュレーションを停止します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-272">|/stop | Stops all simulations.</span></span> |

<span data-ttu-id="c1a71-273">|/verbose | シミュレーション操作の状態を表示します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-273">|/verbose | Displays the status of the simulated operation.</span></span> |

 <a id="ID4E4MAC"></a>

### <a name="common-options"></a><span data-ttu-id="c1a71-274">共通のオプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-274">Common Options</span></span>

`xbstorage [/?] [/X*:address* [*+accesskey*] ]`

|<span data-ttu-id="c1a71-275">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-275">Option</span></span>  |<span data-ttu-id="c1a71-276">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-276">Description</span></span>  |
|---------|---------|
| <span data-ttu-id="c1a71-277">/?</span><span class="sxs-lookup"><span data-stu-id="c1a71-277">/?</span></span>                           |  <span data-ttu-id="c1a71-278">xbstorage.exe のヘルプを表示します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-278">Displays help for xbstorage.exe</span></span> |
| <span data-ttu-id="c1a71-279">/X *:address* [*+accesskey*]</span><span class="sxs-lookup"><span data-stu-id="c1a71-279">/X *:address* [*+accesskey*]</span></span>  | <span data-ttu-id="c1a71-280">ターゲットの本体のホスト名またはアドレス (本体に **Tools IP** として表示されます) を指定しますが、既定の本体は変更しません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-280">Specifies the host name or address (shown as **Tools IP** on the console) of a targeted console, but does not change the default console.</span></span> <span data-ttu-id="c1a71-281">このオプションを使用しない場合、既定の本体が使用されます。*Accesskey* は、アクセス キーを知っている人だけに本体へのアクセスを制限するために使用できる文字列です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-281">If you do not use this option, the default console is used.*Accesskey* is a string that you can use to restrict access to a console to only those people who know the access key.</span></span> <span data-ttu-id="c1a71-282">**xbconfig** \**accesskey=\*\*\*your-key* コマンドを使用して、アクセス キーを設定します。その後、本体を再起動してアクセス キーを有効にします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-282">Set the access key by using the command **xbconfig** \**accesskey=\*\*\*your-key*; then, restart your console to make the access key effective.</span></span> <span data-ttu-id="c1a71-283">アクセス キーが設定されている本体にアクセスするには、本体の IP アドレスまたはホスト名の後にプラス記号 (+) とアクセス キーを付け加える必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-283">To access a console that is configured with an access key, you must include a plus sign (+) and the access key after the IP address or host name of the console.</span></span>
> [!NOTE]
> <span data-ttu-id="c1a71-284">xbconnect で既定の本体を設定するときにアクセス キーを指定した場合、アクセス キーは既定の本体アドレスの一部として保存されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-284">If an access key is provided when the default console is set by xbconnect, then the access key is stored as part of the address of the default console.</span></span>
|

## <a name="gamesaveutil"></a><span data-ttu-id="c1a71-285">Gamesaveutil</span><span class="sxs-lookup"><span data-stu-id="c1a71-285">Gamesaveutil</span></span>

<span data-ttu-id="c1a71-286">*Gamesaveutil* を使うと、アプリのローカルにキャッシュされた接続ストレージを管理できます。*xbstorage* と同じ関数をすべて使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-286">*Gamesaveutil* allows you to manage locally cached Connected Storage for your app with all of the same functions that *xbstorage* provides.</span></span> <span data-ttu-id="c1a71-287">xbstorage ツールと同様、*gamesaveutil* には同じ 6 つのデータ管理関数が用意されていますが、動作がいくらか異なります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-287">Just like the xbstorage tool, *gamesaveutil* offers the same six data managing functions, with some differences in behavior.</span></span> <span data-ttu-id="c1a71-288">import、export、delete、reset の各コマンドを使うには、Xbox Live ユーザーがサインインしている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-288">The import, export, delete, and reset commands require an Xbox Live user to be signed in.</span></span> <span data-ttu-id="c1a71-289">Windows 10 で Xbox アプリを使うと、現在のユーザーを表示および変更できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-289">You can use the Xbox App in Windows 10 to view and change the current user.</span></span>

### <a name="commands"></a><span data-ttu-id="c1a71-290">コマンド</span><span class="sxs-lookup"><span data-stu-id="c1a71-290">Commands</span></span>

|<span data-ttu-id="c1a71-291">コマンド</span><span class="sxs-lookup"><span data-stu-id="c1a71-291">Command</span></span>  |<span data-ttu-id="c1a71-292">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-292">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-293">import</span><span class="sxs-lookup"><span data-stu-id="c1a71-293">import</span></span>   |<span data-ttu-id="c1a71-294">指定された XML ファイルからデータをインポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-294">Imports data from the specified XML file</span></span>         |
|<span data-ttu-id="c1a71-295">export</span><span class="sxs-lookup"><span data-stu-id="c1a71-295">export</span></span>   |<span data-ttu-id="c1a71-296">指定された xml ファイルにデータをエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-296">Exports data to the specified xml file</span></span>         |
|<span data-ttu-id="c1a71-297">delete</span><span class="sxs-lookup"><span data-stu-id="c1a71-297">delete</span></span>   |<span data-ttu-id="c1a71-298">指定されたアプリからデータを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-298">Deletes data from the specified app</span></span>        |
|<span data-ttu-id="c1a71-299">reset</span><span class="sxs-lookup"><span data-stu-id="c1a71-299">reset</span></span>    |<span data-ttu-id="c1a71-300">指定されたアプリのローカル データのみ削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-300">deletes local data only for the specified app</span></span>         |
|<span data-ttu-id="c1a71-301">generate</span><span class="sxs-lookup"><span data-stu-id="c1a71-301">generate</span></span> |<span data-ttu-id="c1a71-302">ダミー データを生成し、指定された xml ファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-302">generates dummy data and saves to the specified xml file</span></span>         |
|<span data-ttu-id="c1a71-303">simulate</span><span class="sxs-lookup"><span data-stu-id="c1a71-303">simulate</span></span> |<span data-ttu-id="c1a71-304">テストすることが難しい特殊な条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-304">simulates special conditions that are difficult to test</span></span>         |

### <a name="gamesaveutil-import"></a><span data-ttu-id="c1a71-305">Gamesaveutil import</span><span class="sxs-lookup"><span data-stu-id="c1a71-305">Gamesaveutil import</span></span>

`gamesaveutil import <filename> [/pfn:<PFN>] [/scid:<SCID>] [/replace]`

<span data-ttu-id="c1a71-306">\<filename> で指定されたデータをインポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-306">Imports data specified in \<filename></span></span>

<span data-ttu-id="c1a71-307">このファイルはデータが含まれる XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-307">The file is an XML file that contains the data.</span></span> <span data-ttu-id="c1a71-308">「`gamesaveutil help generate`」と入力すると、例の生成方法を参照できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-308">Type `gamesaveutil help generate` to see how to generate an example.</span></span>

<span data-ttu-id="c1a71-309">データが保存されるアプリの PFN と SCID を指定する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-309">There are two ways to specify the app PFN and SCID where the data is saved:</span></span>

<span data-ttu-id="c1a71-310">入力ファイルに ContextDescription セクションがあり適切に入力されている場合は、これを使用してターゲット アプリの PFN と SCID を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-310">If the input file has a ContextDescription section that is correctly populated, then this will be used to specify the target app PFN and SCID.</span></span>

<span data-ttu-id="c1a71-311">PFN と SCID は、コマンドライン パラメーターによって部分的または完全に指定することができ、これは入力ファイルで指定されている PFN と SCID の対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-311">The PFN and SCID can be partially or fully specified via command-line parameters, which take precedence over the respective elements of the specified PFN and SCID from the input file.</span></span>

|<span data-ttu-id="c1a71-312">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-312">Option</span></span>  |<span data-ttu-id="c1a71-313">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-313">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-314">/pfn:\<PFN></span><span class="sxs-lookup"><span data-stu-id="c1a71-314">/pfn:\<PFN></span></span>       |<span data-ttu-id="c1a71-315">アプリがインポートを実行するパッケージ ファミリ名 (PFN) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-315">Specifies the Package Family Name(PFN) for the app to perform the import for.</span></span> <span data-ttu-id="c1a71-316">アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-316">The app must be installed.</span></span>         |
|<span data-ttu-id="c1a71-317">/scid:\<SCID></span><span class="sxs-lookup"><span data-stu-id="c1a71-317">/scid:\<SCID></span></span>     |<span data-ttu-id="c1a71-318">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-318">Specifies the Service Configuration Identifier (SCID).</span></span> <span data-ttu-id="c1a71-319">これは、Xbox Live 構成から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-319">This is from your Xbox Live configuration.</span></span>         |
|<span data-ttu-id="c1a71-320">/replace</span><span class="sxs-lookup"><span data-stu-id="c1a71-320">/replace</span></span>         |<span data-ttu-id="c1a71-321">インポートを実行する前に、すべてのコンテナーを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-321">Delete all containers before performing the import.</span></span>         |

<span data-ttu-id="c1a71-322">使用例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-322">Example Usages:</span></span>

```cmd
gamesaveutil import mydata.xml
gamesaveutil import mydata.xml /replace
gamesaveutil import mydata.xml /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> <span data-ttu-id="c1a71-323">インポートするには、アプリがインストールされていて、データが既に同期されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-323">The app must be installed and have synced data already in order to import.</span></span>
> 
> <span data-ttu-id="c1a71-324">/replace が指定されていない場合、入力ファイルで指定された場合を除き既存のコンテナーは変更されません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-324">If /replace is not specified, existing containers will not be touched unless they are specified in the input file.</span></span>

### <a name="gamesaveutil-export"></a><span data-ttu-id="c1a71-325">Gamesaveutil export</span><span class="sxs-lookup"><span data-stu-id="c1a71-325">Gamesaveutil export</span></span>

`gamesaveutil export <outfile> [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

<span data-ttu-id="c1a71-326">\<outfile> により指定されたファイルにデータをエクスポートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-326">Exports data to the file specified by \<outfile>.</span></span>

<span data-ttu-id="c1a71-327">このファイルはデータが含まれる XML ファイルです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-327">The file is an XML file that contains the data.</span></span> <span data-ttu-id="c1a71-328">「gamesaveutil」と入力すると、例の生成方法を参照できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-328">Type gamesaveutil help generate to see how to generate an example.</span></span>

<span data-ttu-id="c1a71-329">データをエクスポートする場所を指定する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-329">There are two ways to specify the location of the data to export:</span></span>

<span data-ttu-id="c1a71-330">/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-330">If the /context parameter is used, and the filename specified by \<infile> has a ContextDescription section that is correctly populated, then that file will be used to specify the location of the source data.</span></span>

<span data-ttu-id="c1a71-331">場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-331">The location can also be specified via command-line parameters, which take precedence over the respective elements specified by the /context file.</span></span>

|<span data-ttu-id="c1a71-332">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-332">Option</span></span>  |<span data-ttu-id="c1a71-333">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-333">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-334">/context:\<infile></span><span class="sxs-lookup"><span data-stu-id="c1a71-334">/context:\<infile></span></span>     |<span data-ttu-id="c1a71-335">指定したファイルを使って、アプリの PFN と SCID を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-335">Use the specified file to specify the app PFN and SCID.</span></span>         |
|<span data-ttu-id="c1a71-336">/pfn:\<PFN></span><span class="sxs-lookup"><span data-stu-id="c1a71-336">/pfn:\<PFN></span></span>            |<span data-ttu-id="c1a71-337">アプリがエクスポートを実行するパッケージ ファミリ名 (PFN) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-337">Specifies the Package Family Name(PFN) for the app to perform the export from.</span></span> <span data-ttu-id="c1a71-338">アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-338">The app must be installed.</span></span>       |
|<span data-ttu-id="c1a71-339">/scid:\<SCID></span><span class="sxs-lookup"><span data-stu-id="c1a71-339">/scid:\<SCID></span></span>          |<span data-ttu-id="c1a71-340">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-340">Specifies the Service Configuration Identifier (SCID).</span></span> <span data-ttu-id="c1a71-341">これは、Xbox Live 構成から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-341">This is from your Xbox Live configuration.</span></span>        |

<span data-ttu-id="c1a71-342">使用例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-342">Example Usages:</span></span>

```cmd
gamesaveutil export exporteddata.xml /context:target.xml
gamesaveutil export exporteddata.xml /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> <span data-ttu-id="c1a71-343">エクスポートするには、アプリがインストールされていて、データが既に同期されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-343">The app must be installed and have synced data already in order to export.</span></span>

### <a name="gamesaveutil-delete"></a><span data-ttu-id="c1a71-344">Gamesaveutil delete</span><span class="sxs-lookup"><span data-stu-id="c1a71-344">Gamesaveutil delete</span></span>

`gamesaveutil delete [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

<span data-ttu-id="c1a71-345">指定した PFN と SCID のすべてのデータを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-345">Deletes all data for the specified PFN and SCID.</span></span>

<span data-ttu-id="c1a71-346">データを削除する場所を指定する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-346">There are two ways to specify the location of the data to delete:</span></span>

<span data-ttu-id="c1a71-347">/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-347">If the /context parameter is used, and the filename specified by \<infile> has a ContextDescription section that is correctly populated, then that file will be used to specify the location of the source data.</span></span>

<span data-ttu-id="c1a71-348">場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-348">The location can also be specified via command-line parameters, which take precedence over the respective elements specified by the /context file.</span></span>

|<span data-ttu-id="c1a71-349">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-349">Option</span></span>  |<span data-ttu-id="c1a71-350">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-350">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-351">/context:\<infile></span><span class="sxs-lookup"><span data-stu-id="c1a71-351">/context:\<infile></span></span>     |<span data-ttu-id="c1a71-352">指定したファイルを使って、アプリの PFN と SCID を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-352">Use the specified file to specify the app PFN and SCID.</span></span>         |
|<span data-ttu-id="c1a71-353">/pfn:\<PFN></span><span class="sxs-lookup"><span data-stu-id="c1a71-353">/pfn:\<PFN></span></span>            |<span data-ttu-id="c1a71-354">アプリがデータを削除するパッケージ ファミリ名 (PFN) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-354">Specifies the Package Family Name(PFN) for the app to delete the data from.</span></span> <span data-ttu-id="c1a71-355">アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-355">The app must be installed.</span></span>       |
|<span data-ttu-id="c1a71-356">/scid:\<SCID></span><span class="sxs-lookup"><span data-stu-id="c1a71-356">/scid:\<SCID></span></span>          |<span data-ttu-id="c1a71-357">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-357">Specifies the Service Configuration Identifier (SCID).</span></span> <span data-ttu-id="c1a71-358">これは、Xbox Live 構成から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-358">This is from your Xbox Live configuration.</span></span>        |

<span data-ttu-id="c1a71-359">使用例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-359">Example Usages:</span></span>

```cmd
gamesaveutil delete /context:target.xml
gamesaveutil delete /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> <span data-ttu-id="c1a71-360">コンテナーを削除するには、アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-360">The app must be installed in order to delete containers.</span></span>

### <a name="gamesaveutil-reset"></a><span data-ttu-id="c1a71-361">Gamesaveutil reset</span><span class="sxs-lookup"><span data-stu-id="c1a71-361">Gamesaveutil reset</span></span>

`gamesaveutil reset [/pfn:<PFN>] [/scid:<SCID>] [/context:<infile>]`

<span data-ttu-id="c1a71-362">指定した PFN と SCID のすべてのローカル データを削除します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-362">Deletes all local data for the specified PFN and SCID.</span></span>

<span data-ttu-id="c1a71-363">データを削除する場所を指定する方法は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-363">There are two ways to specify the location of the data to delete:</span></span>

<span data-ttu-id="c1a71-364">/context パラメーターが使用され、\<infile> によって指定されたファイル名に ContextDescription セクションが存在し、そのセクションに正しい情報が入力されている場合、そのファイルを使用してソース データの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-364">If the /context parameter is used, and the filename specified by \<infile> has a ContextDescription section that is correctly populated, then that file will be used to specify the location of the source data.</span></span>

<span data-ttu-id="c1a71-365">場所はコマンドライン パラメーターによって指定することもでき、これは /context ファイルによって指定されている対応する要素よりも優先されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-365">The location can also be specified via command-line parameters, which take precedence over the respective elements specified by the /context file.</span></span>

|<span data-ttu-id="c1a71-366">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-366">Option</span></span>  |<span data-ttu-id="c1a71-367">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-367">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-368">/context:\<infile></span><span class="sxs-lookup"><span data-stu-id="c1a71-368">/context:\<infile></span></span>     |<span data-ttu-id="c1a71-369">指定したファイルを使って、アプリの PFN と SCID を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-369">Use the specified file to specify the app PFN and SCID.</span></span>         |
|<span data-ttu-id="c1a71-370">/pfn:\<PFN></span><span class="sxs-lookup"><span data-stu-id="c1a71-370">/pfn:\<PFN></span></span>            |<span data-ttu-id="c1a71-371">アプリがデータを削除するパッケージ ファミリ名 (PFN) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-371">Specifies the Package Family Name(PFN) for the app to delete the data from.</span></span> <span data-ttu-id="c1a71-372">アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-372">The app must be installed.</span></span>       |
|<span data-ttu-id="c1a71-373">/scid:\<SCID></span><span class="sxs-lookup"><span data-stu-id="c1a71-373">/scid:\<SCID></span></span>          |<span data-ttu-id="c1a71-374">サービス構成 ID (SCID) を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-374">Specifies the Service Configuration Identifier (SCID).</span></span> <span data-ttu-id="c1a71-375">これは、Xbox Live 構成から取得されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-375">This is from your Xbox Live configuration.</span></span>        |

<span data-ttu-id="c1a71-376">使用例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-376">Example Usages:</span></span>

```cmd
gamesaveutil reset /context:target.xml
gamesaveutil reset /pfn:MyGame_xxxxxx /scid:2AAEB34B-DAB2-4879-B625-D970069C1D22
```


> [!NOTE]
> <span data-ttu-id="c1a71-377">ローカル データを削除するには、アプリがインストールされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-377">The app must be installed in order to delete local data.</span></span>

### <a name="gamesaveutil-generate"></a><span data-ttu-id="c1a71-378">Gamesaveutil generate</span><span class="sxs-lookup"><span data-stu-id="c1a71-378">Gamesaveutil generate</span></span>

`gamesaveutil generate <filename> [/containers:<n>] [/blobs:<n>] [/blobsize:<n>]`

<span data-ttu-id="c1a71-379">ダミー データを生成し、\<filename> によって指定されたファイルに保存します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-379">Generates dummy data and saves to a file specified by \<filename>.</span></span>
<span data-ttu-id="c1a71-380">サービス構成 ID (SCID) は、00000000-0000-0000-0000-000000000000 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-380">The Service Configuration Identifier (SCID) will be set to 00000000-0000-0000-0000-000000000000.</span></span> <span data-ttu-id="c1a71-381">必要に応じて、生成後にファイルを手動で編集してそれらの値を変更します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-381">Edit the file manually after generation to change those values if you desire.</span></span>

|<span data-ttu-id="c1a71-382">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-382">Option</span></span>  |<span data-ttu-id="c1a71-383">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-383">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-384">/containers:\<n></span><span class="sxs-lookup"><span data-stu-id="c1a71-384">/containers:\<n></span></span>     |<span data-ttu-id="c1a71-385">生成するコンテナーの数を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-385">Specifies how many containers to generate.</span></span> <span data-ttu-id="c1a71-386">既定値は 2 です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-386">Default is 2.</span></span>         |
|<span data-ttu-id="c1a71-387">/blobs:\<n></span><span class="sxs-lookup"><span data-stu-id="c1a71-387">/blobs:\<n></span></span>          |<span data-ttu-id="c1a71-388">生成するコンテナーごとの BLOB 数を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-388">Specifies how many blobs per container to generate.</span></span> <span data-ttu-id="c1a71-389">既定値は 3 です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-389">Default is 3.</span></span>        |
|<span data-ttu-id="c1a71-390">/blobsize:\<n></span><span class="sxs-lookup"><span data-stu-id="c1a71-390">/blobsize:\<n></span></span>       |<span data-ttu-id="c1a71-391">BLOB ごとのバイト数を指定します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-391">Specifies how many bytes per blob.</span></span> <span data-ttu-id="c1a71-392">既定値は 1024 です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-392">Default is 1024.</span></span>         |

<span data-ttu-id="c1a71-393">使用例:</span><span class="sxs-lookup"><span data-stu-id="c1a71-393">Example Usages:</span></span>

```cmd
gamesaveutil generate dummydata.xml
gamesaveutil generate dummydata.xml /containers:4
gamesaveutil generate dummydata.xml /blobs:10
gamesaveutil generate dummydata.xml /containers:4 /blobs:10
gamesaveutil generate dummydata.xml /containers:4 /blobs:10 /blobsize:512
```


> [!NOTE]
> <span data-ttu-id="c1a71-394">バイト データは単純な昇順です。つまり 5 バイトの BLOB は 00 01 02 03 04 のようなバイトで構成されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-394">The byte data is a simple ascending sequence, i.e. a five byte blob would have the bytes 00 01 02 03 04.</span></span>

### <a name="gamesaveutil-simulate"></a><span data-ttu-id="c1a71-395">Gamesaveutil simulate</span><span class="sxs-lookup"><span data-stu-id="c1a71-395">Gamesaveutil simulate</span></span>

`gamesaveutil simulate [/markcontainerschanged] [/stop]`

<span data-ttu-id="c1a71-396">特定のシナリオをテストするための特殊な条件をシミュレートします。</span><span class="sxs-lookup"><span data-stu-id="c1a71-396">Simulates special conditions for testing certain scenarios.</span></span>

|<span data-ttu-id="c1a71-397">オプション</span><span class="sxs-lookup"><span data-stu-id="c1a71-397">Option</span></span>  |<span data-ttu-id="c1a71-398">説明</span><span class="sxs-lookup"><span data-stu-id="c1a71-398">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="c1a71-399">/markcontainerschanged</span><span class="sxs-lookup"><span data-stu-id="c1a71-399">/markcontainerschanged</span></span>     |<span data-ttu-id="c1a71-400">アプリが一時停止から再開して新しいプロバイダーを取得したときに、すべてのコンテナーが変更されたように見えるよう強制します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-400">Forces all containers to look like they have been changed when an app resumes from suspend and gets a new provider.</span></span> <span data-ttu-id="c1a71-401">/stop でクリアされるまですべてのアプリに影響します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-401">Affects all apps until cleared with /stop.</span></span>      |
|<span data-ttu-id="c1a71-402">/stop</span><span class="sxs-lookup"><span data-stu-id="c1a71-402">/stop</span></span>                      |<span data-ttu-id="c1a71-403">すべてのシミュレーションを停止します。</span><span class="sxs-lookup"><span data-stu-id="c1a71-403">Stops all simulations.</span></span>         |


 <a id="xbstorage_fileformat"></a>

## <a name="import-and-export-file-format"></a><span data-ttu-id="c1a71-404">インポートおよびエクスポートのファイル形式</span><span class="sxs-lookup"><span data-stu-id="c1a71-404">Import and export file format</span></span>

<span data-ttu-id="c1a71-405">*xbstorage* ツールの **import**、**export**、**generate** の各コマンドで使用される XML ファイルは、次の例に示す形式になります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-405">The XML file used with the **import**, **export**, and **generate** commands with the *xbstorage* tool has the format shown in the following example.</span></span>

```xml
<?xml version="1.0" encoding="UTF-8"?>
  <XbConnectedStorageSpace>
    <ContextDescription>
      <Account msa="user@domain.com" />
      <Title scid="00000000-0000-0000-0000-000000000000" />
    </ContextDescription>
    <Data>
      <Containers>
        <Container name="Container1" displayName="Optional Display Name">
          <Blobs>
            <Blob name="Blob1">
              <![CDATA[... ] ]>
            </Blob>
            ...
            <Blob name="BlobN">
              <![CDATA[... ] ]>
            </Blob>
          </Blobs>
        </Container>
        ...
        <Container name="ContainerN">
        ...
        </Container>
      </Containers>
    </Data>
  </XbConnectedStorageSpace>
```

<span data-ttu-id="c1a71-406">*gamesaveutil* で **import**、**export**、**generate** に合わせてこの xml の形式を設定するには、\<ContextDescription> ノードの \<Account> メンバー ノードを \<PackageFamilyName> ノードに置き換えるだけでかまいません。</span><span class="sxs-lookup"><span data-stu-id="c1a71-406">The only change needed to format this xml for **import**, **export**, and **generate** in *gamesaveutil* is to replace the \<Account> member node of the \<ContextDescription> node with a \<PackageFamilyName> node.</span></span>
<span data-ttu-id="c1a71-407">これにより、\<ContextDescription> ノードが変更されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-407">This will change the \<ContextDescription> node from this:</span></span>

```xml
<ContextDescription>
    <Account msa="user@domain.com" />
    <Title scid="00000000-0000-0000-0000-000000000000" />
</ContextDescription>
```

<span data-ttu-id="c1a71-408">変更後は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c1a71-408">to this:</span></span>

```xml
<ContextDescription>
    <PackageFamilyName pfn="MyGame_xxxxxx" />
    <Title scid="00000000-0000-0000-0000-000000000000" />
</ContextDescription>
```

> [!NOTE]
> <span data-ttu-id="c1a71-409">これらの XML ファイルのデータ形式は、プラットフォームと同じではありません。インポートおよびエクスポート目的でのみ使います。</span><span class="sxs-lookup"><span data-stu-id="c1a71-409">The format of data in these XML files is not identical to what's on the platform, it is for import and export purposes only.</span></span> <span data-ttu-id="c1a71-410">これらの XML ファイルのデータ形式は、今後変更される可能性があるため、アーカイブ形式ではなく、中間形式またはユーティリティ形式として扱う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-410">The data format for these XML files could potentially change in the future, so they should be treated as an intermediate or utility format, not an archival format.</span></span>

<span data-ttu-id="c1a71-411">**ContextDescription** ノードは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="c1a71-411">The **ContextDescription** node is optional.</span></span> <span data-ttu-id="c1a71-412">コンピューターの接続ストレージ領域を作成している場合は、`<Account machine="true"/>` の代わりに `<Account msa="user@domain.com"/>` を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-412">If you are making a Connected Storage space for a machine, you can use `<Account machine="true"/>` instead of `<Account msa="user@domain.com"/>`.</span></span> <span data-ttu-id="c1a71-413">これを使用しない場合は、インポートのコマンド ラインでコンテキストを指定できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-413">Otherwise, the context can be specified on the command line for importation.</span></span>
<span data-ttu-id="c1a71-414">BLOB およびコンテナーは、そのファイルの生成対象であるゲームまたはアプリケーションによって与えられた対応する名前を持つ必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1a71-414">Blobs and containers should have the corresponding names given to them by the game or application for which the file is being generated.</span></span>
<span data-ttu-id="c1a71-415">各 BLOB の内容は、**CDATA** タグでラップされた文字列である必要があります。これは、**CRYPT_STRING_BASE64** フラグを指定して **CryptBinaryToStringW** を呼び出し、その BLOB のデータを RAW バイト配列として提供することによって生成されます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-415">The contents of each blob should be a string wrapped in a **CDATA** tag, which is generated by calling **CryptBinaryToStringW** with the flag **CRYPT_STRING_BASE64** providing the data for that blob as a raw byte array.</span></span> <span data-ttu-id="c1a71-416">逆に、**CryptStringToBinary** を呼び出し、元の暗号化された文字列を提供することによって、BLOB データを元の状態に変換できます。</span><span class="sxs-lookup"><span data-stu-id="c1a71-416">Conversely, blob data can be converted back by calling **CryptStringToBinary** and providing the formerly encrypted string.</span></span> <span data-ttu-id="c1a71-417">これら 2 つの関数の使用例については、Visual Studio の MSDN フォーラムの「[CryptBinaryToString returns invalid bytes](http://social.msdn.microsoft.com/Forums/vstudio/en-US/9acac904-c226-4ae0-9b7f-261993b9fda2/cryptbinarytostring-returns-invalid-bytes?forum=vcgeneral)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1a71-417">An example of using these two functions is shown in [CryptBinaryToString returns invalid bytes](http://social.msdn.microsoft.com/Forums/vstudio/en-US/9acac904-c226-4ae0-9b7f-261993b9fda2/cryptbinarytostring-returns-invalid-bytes?forum=vcgeneral) in the MSDN forums for Visual Studio.</span></span>

<a id="ID4EWBAE"></a>