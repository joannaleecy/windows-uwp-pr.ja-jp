---
author: TerryWarwick
title: カメラ バーコード スキャナーのシステム要件
description: この記事では、UWP アプリからカメラ バーコード スキャナーを使用するための要件を説明します。
ms.author: jken
ms.date: 05/1/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: f0dcbe28107bb8c6918e4e0ac63698f1f9692005
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1833243"
---
# <a name="camera-barcode-scanner-system-requirements"></a><span data-ttu-id="b37ac-104">カメラ バーコード スキャナーのシステム要件</span><span class="sxs-lookup"><span data-stu-id="b37ac-104">Camera barcode scanner system requirements</span></span>
<span data-ttu-id="b37ac-105">Windows 10 バージョン 1803 以降では、ユニバーサル Windows アプリケーションから標準のカメラ レンズでバーコードを読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="b37ac-105">Starting with Windows 10, version 1803, you can read barcodes through a standard camera lens from a Universal Windows Application.</span></span>

## <a name="supported-windows-editions"></a><span data-ttu-id="b37ac-106">サポートされている Windows エディション</span><span class="sxs-lookup"><span data-stu-id="b37ac-106">Supported Windows Editions</span></span>
- <span data-ttu-id="b37ac-107">Windows 10 Professional (S モード)</span><span class="sxs-lookup"><span data-stu-id="b37ac-107">Windows 10 Professional in S mode</span></span>
- <span data-ttu-id="b37ac-108">Windows 10 Professional</span><span class="sxs-lookup"><span data-stu-id="b37ac-108">Windows 10 Professional</span></span>
- <span data-ttu-id="b37ac-109">Windows 10 Enterprise</span><span class="sxs-lookup"><span data-stu-id="b37ac-109">Windows 10 Enterprise</span></span>
- <span data-ttu-id="b37ac-110">Windows 10 IOT Core</span><span class="sxs-lookup"><span data-stu-id="b37ac-110">Windows 10 IOT Core</span></span>


## <a name="webcam-requirements"></a><span data-ttu-id="b37ac-111">Web カメラの要件</span><span class="sxs-lookup"><span data-stu-id="b37ac-111">Webcam Requirements</span></span>
| <span data-ttu-id="b37ac-112">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="b37ac-112">Category</span></span>      | <span data-ttu-id="b37ac-113">推奨</span><span class="sxs-lookup"><span data-stu-id="b37ac-113">Recommendation</span></span>           | <span data-ttu-id="b37ac-114">コメント</span><span class="sxs-lookup"><span data-stu-id="b37ac-114">Comments</span></span> |
| ------------- | ------------------------ | -------- |
| <span data-ttu-id="b37ac-115">フォーカス</span><span class="sxs-lookup"><span data-stu-id="b37ac-115">Focus</span></span>         | <span data-ttu-id="b37ac-116">オート フォーカス</span><span class="sxs-lookup"><span data-stu-id="b37ac-116">Auto Focus</span></span>               | <span data-ttu-id="b37ac-117">固定焦点はお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="b37ac-117">Fixed focus is not recommended</span></span> |
| <span data-ttu-id="b37ac-118">解像度</span><span class="sxs-lookup"><span data-stu-id="b37ac-118">Resolution</span></span>    | <span data-ttu-id="b37ac-119">1920 x 1440 以上</span><span class="sxs-lookup"><span data-stu-id="b37ac-119">1920 x 1440 or higher</span></span>    | <span data-ttu-id="b37ac-120">1920 x 1440 以上の解像度に対応したカメラで最適なエクスペリエンスが得られました。</span><span class="sxs-lookup"><span data-stu-id="b37ac-120">We have had best experience with cameras that are capable of 1920 x 1440 resolution or higher.</span></span>  <span data-ttu-id="b37ac-121">バーコードが十分な大きさで印刷されている場合、これより解像度の低いカメラでも標準的なバーコードを読み取ることができる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b37ac-121">Some lower resolution cameras can read standard barcodes if the barcode is printed large enough.</span></span> <span data-ttu-id="b37ac-122">バーコードの要素が細い場合は、より高い解像度のカメラが必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b37ac-122">Barcodes with thinner elements may require higher resolution cameras.</span></span> |
|
