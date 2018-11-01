---
author: TerryWarwick
title: カメラ バーコード スキャナーの構成
description: カメラ バーコード スキャナーの有効化と無効化
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 35666f64c88ad56b8f5bd3052ebbee069ccaecfc
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5886568"
---
# <a name="enable-or-disable-the-software-decoder-that-ships-with-windows"></a><span data-ttu-id="f193d-104">Windows に付属するソフトウェア デコーダーを有効または無効にします。</span><span class="sxs-lookup"><span data-stu-id="f193d-104">Enable or disable the software decoder that ships with Windows</span></span>
<span data-ttu-id="f193d-105">Windows 10 バージョン 1803 では、ソフトウェア デコーダーがインストールされ、既定で有効になっています。</span><span class="sxs-lookup"><span data-stu-id="f193d-105">In Windows 10, version 1803, the software decoder is installed and enabled by default.</span></span>  <span data-ttu-id="f193d-106">カメラ バーコード スキャナーを使用しない場合、Windows.Devices.PointOfService.BarcodeScanner API で動作するサード パーティ製のデコーダーを入手した場合、およびそのどちらも使用しない場合は、ソフトウェア デコーダーを無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="f193d-106">You can disable the software decoder that ships with Windows if you do not want to use Camera Barcode Scanner or if you have acquired a 3rd party decoder that works with Windows.Devices.PointOfService.BarcodeScanner APIs and do not want to use both.</span></span>

## <a name="enable-or-disable-using-the-system-registry"></a><span data-ttu-id="f193d-107">システム レジストリを使用して有効または無効にする</span><span class="sxs-lookup"><span data-stu-id="f193d-107">Enable or disable using the system registry</span></span>
<span data-ttu-id="f193d-108">システム レジストリを使用して、Windows に付属するソフトウェア デコーダーを有効または無効にするには、*HKLM\Software\Microsoft\PointOfService\BarcodeScanner* の下にレジストリ キー *InboxDecoder* を追加し、*Enable* の値を以下に示すように設定します。</span><span class="sxs-lookup"><span data-stu-id="f193d-108">The software decoder that ships with Windows can be enabled or disabled via the system registry by adding the registry key *InboxDecoder* under *HKLM\Software\Microsoft\PointOfService\BarcodeScanner* and setting the *Enable* value as described below.</span></span>

| <span data-ttu-id="f193d-109">値の名前</span><span class="sxs-lookup"><span data-stu-id="f193d-109">Value name</span></span>  | <span data-ttu-id="f193d-110">値の種類</span><span class="sxs-lookup"><span data-stu-id="f193d-110">Value Type</span></span> | <span data-ttu-id="f193d-111">値</span><span class="sxs-lookup"><span data-stu-id="f193d-111">Value</span></span> | <span data-ttu-id="f193d-112">状態</span><span class="sxs-lookup"><span data-stu-id="f193d-112">Status</span></span> |
| ----------- | --------- | -------|--------|
| <span data-ttu-id="f193d-113">Enable</span><span class="sxs-lookup"><span data-stu-id="f193d-113">Enable</span></span>      | <span data-ttu-id="f193d-114">DWORD</span><span class="sxs-lookup"><span data-stu-id="f193d-114">DWORD</span></span>     | <span data-ttu-id="f193d-115">1 (既定)</span><span class="sxs-lookup"><span data-stu-id="f193d-115">1 (default)</span></span><br/><span data-ttu-id="f193d-116">0</span><span class="sxs-lookup"><span data-stu-id="f193d-116">0</span></span> |  <span data-ttu-id="f193d-117">Windows に付属するソフトウェア デコーダーを有効にします。</span><span class="sxs-lookup"><span data-stu-id="f193d-117">Enables the software decoder that ships with Windows</span></span> <br/> <span data-ttu-id="f193d-118">Windows に付属するソフトウェア デコーダーを無効にします。</span><span class="sxs-lookup"><span data-stu-id="f193d-118">Disables the software decoder that ships with Windows</span></span> |


<span data-ttu-id="f193d-119">Windows に付属するソフトウェア デコーダーを**無効にする**ために使用できるレジストリ ファイルの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f193d-119">Here is an example registry file that you can use to **disable** the software decoder that ships with Windows:</span></span>

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PointOfService\BarcodeScanner\InboxDecoder]
"Enable"=dword:0000000


```  
    
<span data-ttu-id="f193d-120">次のレジストリ ファイルの例を使用すると、Windows に付属するソフトウェア デコーダーを**有効にする**ことができます。</span><span class="sxs-lookup"><span data-stu-id="f193d-120">Use this example registry file to **enable** the software decoder that ships with Windows:</span></span>

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PointOfService\BarcodeScanner\InboxDecoder]
"Enable"=dword:0000001


```  

> [!Warning] 
> <span data-ttu-id="f193d-121">誤ってレジストリを変更すると、重大な問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f193d-121">Serious problems might occur if you modify the registry incorrectly.</span></span>  <span data-ttu-id="f193d-122">さらに安全を考慮して、レジストリのバックアップをとってから変更を行ってください。</span><span class="sxs-lookup"><span data-stu-id="f193d-122">For added protection, back up the registry before you modify it.</span></span>  <span data-ttu-id="f193d-123">バックアップがあれば、問題が生じた場合でもレジストリを復元できます。</span><span class="sxs-lookup"><span data-stu-id="f193d-123">Then, you can restore the registry if a problem occurs.</span></span>  <span data-ttu-id="f193d-124">バックアップおよび復元方法の詳細を参照するには、以下の Microsoft サポート技術情報番号をクリックしてください。</span><span class="sxs-lookup"><span data-stu-id="f193d-124">For more information about how to back up and restore the registry, click the following article number to view the article in the Microsoft Knowledge Base:</span></span> <br/><br/> <span data-ttu-id="f193d-125">[322756](http://support.microsoft.com/kb/322756) Windows でレジストリをバックアップおよび復元する方法</span><span class="sxs-lookup"><span data-stu-id="f193d-125">[322756](http://support.microsoft.com/kb/322756) How to back up and restore the registry in Windows.</span></span>

> [!NOTE]
> <span data-ttu-id="f193d-126">Windows 10 に付属するソフトウェア デコーダーは、[**Digimarc Corporation**](https://www.digimarc.com/) から無料で提供されています。</span><span class="sxs-lookup"><span data-stu-id="f193d-126">The software decoder built into Windows 10 is provided courtesy of  [**Digimarc Corporation**](https://www.digimarc.com/).</span></span>
