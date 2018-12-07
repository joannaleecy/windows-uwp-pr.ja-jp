---
title: Xbox Device Portal REST API
description: Xbox One の UWP に関する API リファレンスです。
ms.date: 10/25/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 5ae8e953-0465-487b-81dd-54a85c904daf
ms.localizationpriority: medium
ms.openlocfilehash: d8fdcf01d7d1f72624d73acf2d10ce28dfb75e04
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8797215"
---
# <a name="xbox-device-portal-rest-api"></a><span data-ttu-id="4df47-104">Xbox Device Portal REST API</span><span class="sxs-lookup"><span data-stu-id="4df47-104">Xbox Device Portal REST API</span></span>

<span data-ttu-id="4df47-105">このセクションには、コンソールの構成と管理をリモートから行うために使用する Xbox Device Portal REST API に関するリファレンス トピックが記載されています。</span><span class="sxs-lookup"><span data-stu-id="4df47-105">This section contains reference topics for the Xbox Device Portal REST API, used to remotely configure and manage your console.</span></span>

| <span data-ttu-id="4df47-106">URI</span><span class="sxs-lookup"><span data-stu-id="4df47-106">URI</span></span>        | <span data-ttu-id="4df47-107">説明</span><span class="sxs-lookup"><span data-stu-id="4df47-107">Description</span></span> |
|------------|-------------|
|[<span data-ttu-id="4df47-108">/api/app/packagemanager/register</span><span class="sxs-lookup"><span data-stu-id="4df47-108">/api/app/packagemanager/register</span></span>](wdp-loose-folder-register-api.md)| <span data-ttu-id="4df47-109">ルース フォルダーに含まれているアプリを登録します。</span><span class="sxs-lookup"><span data-stu-id="4df47-109">Registers an app that is contained in a loose folder.</span></span> |
|[<span data-ttu-id="4df47-110">/api/app/packagemanager/upload</span><span class="sxs-lookup"><span data-stu-id="4df47-110">/api/app/packagemanager/upload</span></span>](wdp-folder-upload.md)| <span data-ttu-id="4df47-111">フォルダー全体を本体にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="4df47-111">Uploads an entire folder to the console.</span></span> |
|[<span data-ttu-id="4df47-112">/ext/app/sshpins</span><span class="sxs-lookup"><span data-stu-id="4df47-112">/ext/app/sshpins</span></span>](uwp-sshpins-api.md)| <span data-ttu-id="4df47-113">信頼されたすべての SSH ピンをリモートでクリアします。</span><span class="sxs-lookup"><span data-stu-id="4df47-113">Clear all trusted SSH pins remotely.</span></span> <span data-ttu-id="4df47-114">Visual Studio UWP 開発では、PIN のペアリングをもう一度行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="4df47-114">Will require doing pin pairing again for Visual Studio UWP development.</span></span> |
|[<span data-ttu-id="4df47-115">/ext/app/deployinfo</span><span class="sxs-lookup"><span data-stu-id="4df47-115">/ext/app/deployinfo</span></span>](uwp-deployinfo-api.md)| <span data-ttu-id="4df47-116">1 つ以上のインストール パッケージの展開情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="4df47-116">Requests deployment information for one or more installed packages.</span></span> |
|[<span data-ttu-id="4df47-117">/ext/fiddler</span><span class="sxs-lookup"><span data-stu-id="4df47-117">/ext/fiddler</span></span>](wdp-fiddler-api.md)| <span data-ttu-id="4df47-118">Fiddler のネットワーク トレースを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="4df47-118">Enable and disable Fiddler network tracing.</span></span> |
|[<span data-ttu-id="4df47-119">/ext/httpmonitor/sessions</span><span class="sxs-lookup"><span data-stu-id="4df47-119">/ext/httpmonitor/sessions</span></span>](wdp-httpMonitor-api.md)| <span data-ttu-id="4df47-120">Xbox でフォーカスのあるアプリから HTTP トラフィックを取得します。</span><span class="sxs-lookup"><span data-stu-id="4df47-120">Get HTTP traffic from the focused app on Xbox.</span></span> |
|[<span data-ttu-id="4df47-121">/ext/networkcredential</span><span class="sxs-lookup"><span data-stu-id="4df47-121">/ext/networkcredential</span></span>](uwp-networkcredentials-api.md)| <span data-ttu-id="4df47-122">ネットワーク資格情報を追加、削除、または更新します。</span><span class="sxs-lookup"><span data-stu-id="4df47-122">Add, remove, or update network credentials.</span></span> |
|[<span data-ttu-id="4df47-123">/ext/remoteinput</span><span class="sxs-lookup"><span data-stu-id="4df47-123">/ext/remoteinput</span></span>](uwp-remoteinput-api.md)| <span data-ttu-id="4df47-124">キーボード、マウス、コントローラーの入力を Xbox にリモートで送信します。</span><span class="sxs-lookup"><span data-stu-id="4df47-124">Send keyboard, mouse, or controller input remotely to an Xbox.</span></span> |
|[<span data-ttu-id="4df47-125">/ext/remoteinput/controllers</span><span class="sxs-lookup"><span data-stu-id="4df47-125">/ext/remoteinput/controllers</span></span>](uwp-remoteinput-controllers-api.md)| <span data-ttu-id="4df47-126">接続された物理コントローラーの数を取得するか、またはすべての物理コントローラーをオフにします。</span><span class="sxs-lookup"><span data-stu-id="4df47-126">Get the number of attached physical controllers or turn off all physical controllers.</span></span> |
|[<span data-ttu-id="4df47-127">/ext/screenshot</span><span class="sxs-lookup"><span data-stu-id="4df47-127">/ext/screenshot</span></span>](wdp-media-capture-api.md)| <span data-ttu-id="4df47-128">現在本体に表示されている画面の PNG 画像をキャプチャします。</span><span class="sxs-lookup"><span data-stu-id="4df47-128">Captures a PNG representation of the screen currently displayed on the console.</span></span> |
|[<span data-ttu-id="4df47-129">/ext/settings</span><span class="sxs-lookup"><span data-stu-id="4df47-129">/ext/settings</span></span>](wdp-xboxsettings-api.md)| <span data-ttu-id="4df47-130">Xbox One 開発者向け設定にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="4df47-130">Accesses Xbox One developer settings.</span></span> |
|[<span data-ttu-id="4df47-131">/ext/smb/developerfolder</span><span class="sxs-lookup"><span data-stu-id="4df47-131">/ext/smb/developerfolder</span></span>](wdp-smb-api.md)| <span data-ttu-id="4df47-132">開発用 PC のエクスプローラーを使用して、本体上にある開発者向けフォルダーにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="4df47-132">Accesses the developer folder on your console through File Explorer on your development PC.</span></span> |
|[<span data-ttu-id="4df47-133">/ext/user</span><span class="sxs-lookup"><span data-stu-id="4df47-133">/ext/user</span></span>](wdp-user-management.md)| <span data-ttu-id="4df47-134">Xbox One 本体のユーザーを管理します。</span><span class="sxs-lookup"><span data-stu-id="4df47-134">Manages users on the Xbox One console.</span></span> |
|[<span data-ttu-id="4df47-135">/ext/xbox/info</span><span class="sxs-lookup"><span data-stu-id="4df47-135">/ext/xbox/info</span></span>](wdp-xboxinfo-api.md)| <span data-ttu-id="4df47-136">Xbox One デバイスに関する情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="4df47-136">Gives information about the Xbox One device.</span></span> |
|[<span data-ttu-id="4df47-137">/ext/xboxlive/sandbox</span><span class="sxs-lookup"><span data-stu-id="4df47-137">/ext/xboxlive/sandbox</span></span>](wdp-sandbox-api.md)| <span data-ttu-id="4df47-138">Xbox Live サンド ボックスを管理します。</span><span class="sxs-lookup"><span data-stu-id="4df47-138">Manages your Xbox Live sandbox.</span></span> |

## <a name="see-also"></a><span data-ttu-id="4df47-139">参照</span><span class="sxs-lookup"><span data-stu-id="4df47-139">See also</span></span>

- [<span data-ttu-id="4df47-140">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="4df47-140">UWP on Xbox One</span></span>](index.md)
- [<span data-ttu-id="4df47-141">Windows デバイス ポータル</span><span class="sxs-lookup"><span data-stu-id="4df47-141">Windows Device Portal</span></span>](../debug-test-perf/device-portal.md)