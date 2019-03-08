---
title: PointOfService デバイス機能
description: PointOfService 機能は、Windows.Devices.PointOfService 名前空間の使用に必要です。
ms.date: 05/02/2018
ms.topic: article
keywords: Windows 10, UWP, 店舗販売時点管理, POS
ms.localizationpriority: medium
ms.openlocfilehash: 9c09a9093389fc0a917243773eae6803220ed610
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57634687"
---
# <a name="pointofservice-device-capability"></a><span data-ttu-id="5a007-104">PointOfService デバイス機能</span><span class="sxs-lookup"><span data-stu-id="5a007-104">PointOfService device capability</span></span>
<span data-ttu-id="5a007-105">アプリケーション パッケージのマニフェストで機能を宣言することで、PointOfService API へのアクセスを要求します。Microsoft Visual Studio のマニフェスト デザイナーを使用することで、ほとんどの機能を宣言することができます。または、手動で追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="5a007-105">You request access to the PointOfService APIs by declaring the capability in your application package manifest]  You can declare most capabilities by using the Manifest Designer, in Microsoft Visual Studio, or you can add them manually.</span></span>  

> [!Important]
> <span data-ttu-id="5a007-106">アプリケーション マニフェストで **pointOfService** 機能を宣言しない場合は、Winodws.Devices.PointOfService 名前空間で API を使用しようとすると、**System.UnauthorizedAccessException** エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5a007-106">You will receive the error **System.UnauthorizedAccessException** when you attempt to use an API in the Winodws.Devices.PointOfService namespace if you do not declare the **pointOfService** capability in your application manifest.</span></span> 

## <a name="declare-capability-using-manifest-designer"></a><span data-ttu-id="5a007-107">マニフェスト デザイナーを使用した機能の宣言</span><span class="sxs-lookup"><span data-stu-id="5a007-107">Declare capability using Manifest Designer</span></span>

1. <span data-ttu-id="5a007-108">**ソリューション エクスプローラー**で、UWP アプリケーションのプロジェクト ノードを展開します。</span><span class="sxs-lookup"><span data-stu-id="5a007-108">In **Solution Explorer**, expand the project node of your UWP application.</span></span>
2. <span data-ttu-id="5a007-109">**[Package.appxmanifest]** ファイルをダブルクリックします。</span><span class="sxs-lookup"><span data-stu-id="5a007-109">Double-click the **Package.appxmanifest** file.</span></span>  
<span data-ttu-id="5a007-110">*マニフェスト ファイルが既に XML コード ビューで開いている場合は、Visual Studio では、ファイルを閉じてするように求められます。*</span><span class="sxs-lookup"><span data-stu-id="5a007-110">*If the manifest file is already open in the XML code view, Visual Studio prompts you to close the file.*</span></span>
3. <span data-ttu-id="5a007-111">**[機能]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="5a007-111">Click the **Capabilities** tab</span></span>
4. <span data-ttu-id="5a007-112">機能の一覧で **[店舗販売時点管理 (POS)]** の横にあるチェック ボックスをオンにして、POS デバイスの機能を有効にします。</span><span class="sxs-lookup"><span data-stu-id="5a007-112">Click the checkbox next to **Point of Service** in the list of capabilities to enable the Point of Service device capability</span></span>


## <a name="declare-capability-manually"></a><span data-ttu-id="5a007-113">手動での機能の宣言</span><span class="sxs-lookup"><span data-stu-id="5a007-113">Declare capability manually</span></span>

1. <span data-ttu-id="5a007-114">**ソリューション エクスプローラー**で、UWP アプリケーションのプロジェクト ノードを展開します。</span><span class="sxs-lookup"><span data-stu-id="5a007-114">In **Solution Explorer**, expand the project node of your UWP application.</span></span>
2. <span data-ttu-id="5a007-115">**[Package.appxmanifest]** ファイルを右クリックし、**[コードの表示]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="5a007-115">Right-click the **Package.appxmanifest** file and choose **View Code**</span></span>
3. <span data-ttu-id="5a007-116">PointOfService DeviceCapability 要素をアプリケーション マニフェストの Capabilities セクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="5a007-116">Add the PointOfService DeviceCapability element to Capabilities section of your application manifest.</span></span>  

```xml
  <Capabilities>
    <DeviceCapability Name="pointOfService" />
  </Capabilities>
   ```
