---
title: カメラ バーコード スキャナーの構成
description: カメラ バーコード スキャナーの有効化と無効化
ms.date: 4/8/2019
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: da0379109dcf56de505f2a56317258e0ab597f94
ms.sourcegitcommit: bad7ed6def79acbb4569de5a92c0717364e771d9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59244368"
---
# <a name="enable-or-disable-the-software-decoder-that-ships-with-windows"></a><span data-ttu-id="dc2f2-104">Windows に付属するソフトウェア デコーダーを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-104">Enable or disable the software decoder that ships with Windows</span></span>

<span data-ttu-id="dc2f2-105">Windows 10 バージョン 1803 では、ソフトウェア デコーダーがインストールされ、既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-105">In Windows 10, version 1803, the software decoder is installed and enabled by default.</span></span>  <span data-ttu-id="dc2f2-106">カメラ バーコード スキャナーを使用しない場合、Windows.Devices.PointOfService.BarcodeScanner API で動作するサード パーティ製のデコーダーを入手した場合、およびそのどちらも使用しない場合は、ソフトウェア デコーダーを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-106">You can disable the software decoder that ships with Windows if you do not want to use Camera Barcode Scanner or if you have acquired a 3rd party decoder that works with Windows.Devices.PointOfService.BarcodeScanner APIs and do not want to use both.</span></span>

## <a name="enable-or-disable-using-the-system-registry"></a><span data-ttu-id="dc2f2-107">システム レジストリを使用して有効または無効にする</span><span class="sxs-lookup"><span data-stu-id="dc2f2-107">Enable or disable using the system registry</span></span>

<span data-ttu-id="dc2f2-108">システム レジストリを使用して、Windows に付属するソフトウェア デコーダーを有効または無効にするには、*HKLM\Software\Microsoft\PointOfService\BarcodeScanner* の下にレジストリ キー *InboxDecoder* を追加し、*Enable* の値を以下に示すように設定します。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-108">The software decoder that ships with Windows can be enabled or disabled via the system registry by adding the registry key *InboxDecoder* under *HKLM\Software\Microsoft\PointOfService\BarcodeScanner* and setting the *Enable* value as described below.</span></span>

| <span data-ttu-id="dc2f2-109">値の名前</span><span class="sxs-lookup"><span data-stu-id="dc2f2-109">Value name</span></span>  | <span data-ttu-id="dc2f2-110">値の種類</span><span class="sxs-lookup"><span data-stu-id="dc2f2-110">Value Type</span></span> | <span data-ttu-id="dc2f2-111">値</span><span class="sxs-lookup"><span data-stu-id="dc2f2-111">Value</span></span> | <span data-ttu-id="dc2f2-112">状況</span><span class="sxs-lookup"><span data-stu-id="dc2f2-112">Status</span></span> |
| ----------- | --------- | -------|--------|
| <span data-ttu-id="dc2f2-113">Enable</span><span class="sxs-lookup"><span data-stu-id="dc2f2-113">Enable</span></span>      | <span data-ttu-id="dc2f2-114">DWORD</span><span class="sxs-lookup"><span data-stu-id="dc2f2-114">DWORD</span></span>     | <span data-ttu-id="dc2f2-115">1 (既定)</span><span class="sxs-lookup"><span data-stu-id="dc2f2-115">1 (default)</span></span><br/><span data-ttu-id="dc2f2-116">0</span><span class="sxs-lookup"><span data-stu-id="dc2f2-116">0</span></span> |  <span data-ttu-id="dc2f2-117">Windows に付属するソフトウェア デコーダーを有効にします。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-117">Enables the software decoder that ships with Windows</span></span> <br/> <span data-ttu-id="dc2f2-118">Windows に付属するソフトウェア デコーダーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-118">Disables the software decoder that ships with Windows</span></span> |

<span data-ttu-id="dc2f2-119">Windows に付属するソフトウェア デコーダーを**無効にする**ために使用できるレジストリ ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-119">Here is an example registry file that you can use to **disable** the software decoder that ships with Windows:</span></span>

```text
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PointOfService\BarcodeScanner\InboxDecoder]
"Enable"=dword:0000000
```  

<span data-ttu-id="dc2f2-120">次のレジストリ ファイルの例を使用すると、Windows に付属するソフトウェア デコーダーを**有効にする**ことができます。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-120">Use this example registry file to **enable** the software decoder that ships with Windows:</span></span>

```text
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PointOfService\BarcodeScanner\InboxDecoder]
"Enable"=dword:0000001
```  

> [!Warning]
> <span data-ttu-id="dc2f2-121">誤ってレジストリを変更すると、重大な問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-121">Serious problems might occur if you modify the registry incorrectly.</span></span>  <span data-ttu-id="dc2f2-122">さらに安全を考慮して、レジストリのバックアップをとってから変更を行ってください。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-122">For added protection, back up the registry before you modify it.</span></span>  <span data-ttu-id="dc2f2-123">バックアップがあれば、問題が生じた場合でもレジストリを復元できます。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-123">Then, you can restore the registry if a problem occurs.</span></span>  <span data-ttu-id="dc2f2-124">バックアップおよび復元方法の詳細を参照するには、以下の Microsoft サポート技術情報番号をクリックしてください。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-124">For more information about how to back up and restore the registry, click the following article number to view the article in the Microsoft Knowledge Base:</span></span> <br/><br/> <span data-ttu-id="dc2f2-125">[322756](https://support.microsoft.com/kb/322756) Windows でレジストリをバックアップおよび復元する方法</span><span class="sxs-lookup"><span data-stu-id="dc2f2-125">[322756](https://support.microsoft.com/kb/322756) How to back up and restore the registry in Windows.</span></span>

> [!NOTE]
> <span data-ttu-id="dc2f2-126">Windows 10 に付属するソフトウェア デコーダーは、[**Digimarc Corporation**](https://www.digimarc.com/) から無料で提供されています。</span><span class="sxs-lookup"><span data-stu-id="dc2f2-126">The software decoder built into Windows 10 is provided courtesy of  [**Digimarc Corporation**](https://www.digimarc.com/).</span></span>
