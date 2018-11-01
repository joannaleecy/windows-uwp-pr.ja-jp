---
author: mcleblanc
ms.assetid: B48E21AB-0EA5-444B-8333-393DD8D1B76D
title: エンタープライズ共有記憶域
description: エンタープライズ共有記憶域は、基幹業務アプリのデータ共有のための、ローカルのデータの場所を定義します。
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5236767d4c02d873106c7b1799c8428d84cccd53
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5920102"
---
# <a name="enterprise-shared-storage"></a><span data-ttu-id="0e4e3-104">エンタープライズ共有記憶域</span><span class="sxs-lookup"><span data-stu-id="0e4e3-104">Enterprise Shared Storage</span></span>

<span data-ttu-id="0e4e3-105">共有記憶域は、2 つの場所で構成されています。この場所では、制限された機能 **enterpriseDeviceLockdown** とエンタープライズ証明書を持つアプリは、完全な読み取り/書き込みアクセスがあります。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-105">The shared storage consists of two locations, where apps with the restricted capability  **enterpriseDeviceLockdown** and an Enterprise certificate have full read and write access.</span></span> <span data-ttu-id="0e4e3-106">**enterpriseDeviceLockdown** を使うと、アプリは、デバイスのロック ダウン API を利用したり、企業で共有している保存フォルダーにアクセスしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-106">Note that the **enterpriseDeviceLockdown** capability allows apps to use the device lock down API and access the enterprise shared storage folders.</span></span> <span data-ttu-id="0e4e3-107">API について詳しくは、「[**Windows.Embedded.DeviceLockdown**](http://go.microsoft.com/fwlink/?LinkId=699331) 名前空間」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-107">For more information about the API, see [**Windows.Embedded.DeviceLockdown**](http://go.microsoft.com/fwlink/?LinkId=699331) namespace.</span></span>  

<span data-ttu-id="0e4e3-108">これらの場所は、次のローカル ドライブに設定されます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-108">These locations are set on the local drive:</span></span>
- <span data-ttu-id="0e4e3-109">\Data\SharedData\Enterprise\Persistent</span><span class="sxs-lookup"><span data-stu-id="0e4e3-109">\Data\SharedData\Enterprise\Persistent</span></span>
- <span data-ttu-id="0e4e3-110">\Data\SharedData\Enterprise\Non-Persistent</span><span class="sxs-lookup"><span data-stu-id="0e4e3-110">\Data\SharedData\Enterprise\Non-Persistent</span></span>

## <a name="scenarios"></a><span data-ttu-id="0e4e3-111">シナリオ</span><span class="sxs-lookup"><span data-stu-id="0e4e3-111">Scenarios</span></span>

<span data-ttu-id="0e4e3-112">エンタープライズ共有記憶域は、次のシナリオをサポートします。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-112">Enterprise shared storage provides support for the following scenarios.</span></span>

- <span data-ttu-id="0e4e3-113">1 つのアプリの 1 つのインスタンス内、同じアプリの複数のインスタンス間、また適切な機能と証明書を持つ複数のアプリ間で、データを共有できます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-113">You can share data within an instance of an app, between instances of the same app, or even between apps assuming they both have the appropriate capability and certificate.</span></span>
- <span data-ttu-id="0e4e3-114">ローカルのハード ドライブの \Data\SharedData\Enterprise\Persistent フォルダーにデータを保存でき、これはデバイスのリセット後も保持されます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-114">You can store data on the local hard drive in the \Data\SharedData\Enterprise\Persistent folder and it persists even after the device has been reset.</span></span>
- <span data-ttu-id="0e4e3-115">モバイル デバイス管理 (MDM) サービスを使用して、デバイス上のファイルの読み取り、書き込み、削除などのファイル操作を行えます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-115">Manipulate files, including read, write, and delete of files on a device via Mobile Device Management (MDM) service.</span></span> <span data-ttu-id="0e4e3-116">MDM サービスを使ったエンタープライズ共有記憶域の使用方法について詳しくは、「[EnterpriseExtFileSystem CSP](http://go.microsoft.com/fwlink/?LinkId=699333)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-116">For more information on how to use enterprise shared storage through the MDM service, see [EnterpriseExtFileSystem CSP](http://go.microsoft.com/fwlink/?LinkId=699333).</span></span>

## <a name="access-enterprise-shared-storage"></a><span data-ttu-id="0e4e3-117">エンタープライズ共有記憶域へのアクセス</span><span class="sxs-lookup"><span data-stu-id="0e4e3-117">Access enterprise shared storage</span></span>

<span data-ttu-id="0e4e3-118">次の例では、パッケージ マニフェストでエンタープライズ共有記憶域へのアクセス機能を宣言する方法、および Windows.Storage.StorageFolder クラスを使って共有保存フォルダーにアクセスする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-118">The following example shows how to declare the capability to access enterprise shared storage in the package manifest, and how to access the shared storage folders by using the Windows.Storage.StorageFolder class.</span></span>

<span data-ttu-id="0e4e3-119">アプリ パッケージ マニフェストに次の機能を含めます。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-119">In your app package manifest, include the following capability:</span></span>

```xml
<Package
  xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
  xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
  IgnorableNamespaces="uap mp rescap">

…

<Capabilities>
    <rescap:Capability Name="enterpriseDeviceLockdown"/>
</Capabilities>
```

<span data-ttu-id="0e4e3-120">共有データの場所にアクセスするには、アプリで次のコードを使います。</span><span class="sxs-lookup"><span data-stu-id="0e4e3-120">To access the shared data location, your app would use the following code.</span></span>

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Storage;

…

// Get the Enterprise Shared Storage folder.
var enterprisePersistentFolderRoot = @"C:\Data\SharedData\Enterprise\Persistent";

StorageFolder folder =
    await StorageFolder.GetFolderFromPathAsync(enterprisePersistentFolderRoot);

// Get the files in the folder.
IReadOnlyList<StorageFile> sortedItems =
    await folder.GetFilesAsync();

// Iterate over the results and print the list of files
// to the Visual Studio Output window.
foreach (StorageFile file in sortedItems)
    Debug.WriteLine(file.Name + ", " + file.DateCreated);
```

