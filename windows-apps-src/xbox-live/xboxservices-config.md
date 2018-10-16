---
title: XboxServices.config
author: KevinAsgari
description: UWP ゲームを Xbox Live 構成に関連付けるための XboxServices.config ファイルについて説明します。
ms.author: kevinasg
ms.date: 03/29/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, サービス構成, xboxservices.config
ms.localizationpriority: medium
ms.openlocfilehash: db4e1dca1bf3968dc62b2ba60eac1033ad759663
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4623369"
---
# <a name="xboxservicesconfig-file-description"></a><span data-ttu-id="15d66-104">XboxServices.config ファイルの説明</span><span class="sxs-lookup"><span data-stu-id="15d66-104">XboxServices.config file description</span></span>

<span data-ttu-id="15d66-105">Xbox Live 対応の UWP ゲームを開発する場合、プロジェクトに XboxServices.config ファイルを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="15d66-105">When you develop an Xbox Live enabled UWP game, your project must include an XboxServices.config file.</span></span>  <span data-ttu-id="15d66-106">このファイルは、Xbox Live SDK がゲームとデベロッパー センター アプリおよび Xbox Live サービス構成を関連付けることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="15d66-106">This file enables the Xbox Live SDK to associate your game with your Dev Center app and your Xbox Live services configuration.</span></span> <span data-ttu-id="15d66-107">このファイルには、サービス構成 ID、タイトル ID など情報が詳細に記述された JSON オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="15d66-107">This file contains a JSON object that details information such as the service configuration ID, title ID, etc.</span></span>

<span data-ttu-id="15d66-108">Xbox Live プラグインを使うことで、Unity を使って Xbox Live クリエーターズ プログラムを設計する場合、このファイルは Xbox Live の関連付けウィザードによって自動的に作成されます。</span><span class="sxs-lookup"><span data-stu-id="15d66-108">If you are using Unity to design an Xbox Live Creators Program game by using the Xbox Live plug-in, this file is automatically created for you by the Xbox Live Association Wizard.</span></span>

## <a name="xboxservicesconfig-fields"></a><span data-ttu-id="15d66-109">XboxServices.config のフィールド</span><span class="sxs-lookup"><span data-stu-id="15d66-109">XboxServices.config fields</span></span>

>[!NOTE]
> <span data-ttu-id="15d66-110">Xbox Live 関連付けウィザードによって作成されたファイルには、以下で説明するフィールド以外のフィールドも含まれていることがありますが、サービスによって使用されません。</span><span class="sxs-lookup"><span data-stu-id="15d66-110">The file created by the Xbox Live Association Wizard may include additional fields beyond the ones described below, but they are not used by the service.</span></span>

<span data-ttu-id="15d66-111">構成ファイル内の JSON オブジェクトでは、次のフィールドが定義されています。</span><span class="sxs-lookup"><span data-stu-id="15d66-111">The following fields are defined in the JSON object in the config file:</span></span>

<span data-ttu-id="15d66-112">フィールド</span><span class="sxs-lookup"><span data-stu-id="15d66-112">Field</span></span> | <span data-ttu-id="15d66-113">説明</span><span class="sxs-lookup"><span data-stu-id="15d66-113">Description</span></span>
--- | ---
<span data-ttu-id="15d66-114">PrimaryServiceConfigId</span><span class="sxs-lookup"><span data-stu-id="15d66-114">PrimaryServiceConfigId</span></span>  |  <span data-ttu-id="15d66-115">Xbox Live サービス構成 ID (SCID)。</span><span class="sxs-lookup"><span data-stu-id="15d66-115">The Xbox Live service configuration ID (SCID).</span></span> <span data-ttu-id="15d66-116">[デベロッパー センター ダッシュボード](https://developer.microsoft.com/en-us/dashboard)では、アプリの **[サービス]** セクションにある **[Xbox Live]** ページ (クリエーターズ プログラムの場合) または **[Xbox Live Setup]** (Xbox Live のセットアップ) ページ (フル Xbox Live ゲームの場合) でこの値を確認できます。</span><span class="sxs-lookup"><span data-stu-id="15d66-116">On the [Dev Center dashboard](https://developer.microsoft.com/en-us/dashboard), you can find this value on the **Xbox Live** page (for Creators Program) or **Xbox Live Setup** page (for full Xbox Live games), under the **Services** section for your app.</span></span>
<span data-ttu-id="15d66-117">TitleId</span><span class="sxs-lookup"><span data-stu-id="15d66-117">TitleId</span></span>  |  <span data-ttu-id="15d66-118">アプリの 10 進数のタイトル ID。</span><span class="sxs-lookup"><span data-stu-id="15d66-118">The decimal Title ID for your app.</span></span> <span data-ttu-id="15d66-119">[デベロッパー センター ダッシュボード](https://developer.microsoft.com/en-us/dashboard)では、アプリの **[サービス]** セクションにある **[Xbox Live]** ページ (クリエーターズ プログラムの場合) または **[Xbox Live Setup]** (Xbox Live のセットアップ) ページ (フル Xbox Live ゲームの場合) でこの値を確認できます。</span><span class="sxs-lookup"><span data-stu-id="15d66-119">On the [Dev Center dashboard](https://developer.microsoft.com/en-us/dashboard), you can find this value on the **Xbox Live** page (for Creators Program) or **Xbox Live Setup** page (for full Xbox Live games), under the **Services** section for your app.</span></span>
<span data-ttu-id="15d66-120">XboxLiveCreatorsTitle</span><span class="sxs-lookup"><span data-stu-id="15d66-120">XboxLiveCreatorsTitle</span></span>  |  <span data-ttu-id="15d66-121">"true" の場合、アプリが Xbox Live クリエーターズ プログラム アプリであることを示します。</span><span class="sxs-lookup"><span data-stu-id="15d66-121">If "true", indicates that the app is an Xbox Live Creators Program app.</span></span> <span data-ttu-id="15d66-122">それ以外の場合は "false" です。</span><span class="sxs-lookup"><span data-stu-id="15d66-122">Otherwise, "false".</span></span>
<span data-ttu-id="15d66-123">Scope</span><span class="sxs-lookup"><span data-stu-id="15d66-123">Scope</span></span>  |  <span data-ttu-id="15d66-124">**(省略可能)** アプリによって使用される機能のスコープを定義します。</span><span class="sxs-lookup"><span data-stu-id="15d66-124">**(Optional)** Defines the scope of functionality used by the app.</span></span> <span data-ttu-id="15d66-125">詳細については、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="15d66-125">See below for further description.</span></span>

### <a name="scope-field"></a><span data-ttu-id="15d66-126">Scope フィールド</span><span class="sxs-lookup"><span data-stu-id="15d66-126">Scope field</span></span>

<span data-ttu-id="15d66-127">**Scope** フィールドは、ゲームで使用されている機能を示すために使用できるオプション フィールドです。</span><span class="sxs-lookup"><span data-stu-id="15d66-127">The **Scope** field is an optional field that you can use to indicate the functionality used by your game.</span></span>


<span data-ttu-id="15d66-128">**Scope** フィールドが指定されない場合、次の表で説明するように、スコープは **XboxLiveCreatorsTitle** フィールドの値に応じて既定値に設定されます。</span><span class="sxs-lookup"><span data-stu-id="15d66-128">If the **Scope** field is not specified, then the scope is set to a default value that depends on the value of the **XboxLiveCreatorsTitle** field, as described in the following table:</span></span>

<span data-ttu-id="15d66-129">XboxLiveCreatorsTitle 値</span><span class="sxs-lookup"><span data-stu-id="15d66-129">XboxLiveCreatorsTitle value</span></span> | <span data-ttu-id="15d66-130">既定のスコープ値</span><span class="sxs-lookup"><span data-stu-id="15d66-130">Default Scope value</span></span>
--- | ---
<span data-ttu-id="15d66-131">"true"</span><span class="sxs-lookup"><span data-stu-id="15d66-131">"true"</span></span>  |  <span data-ttu-id="15d66-132">"xbl.signin xbl.friends"</span><span class="sxs-lookup"><span data-stu-id="15d66-132">"xbl.signin xbl.friends"</span></span>
<span data-ttu-id="15d66-133">"false"</span><span class="sxs-lookup"><span data-stu-id="15d66-133">"false"</span></span>  |  <span data-ttu-id="15d66-134">"xboxlive.signin"</span><span class="sxs-lookup"><span data-stu-id="15d66-134">"xboxlive.signin"</span></span>



<span data-ttu-id="15d66-135">次の一覧では、**Scope** フィールドの有効な値について説明しています。</span><span class="sxs-lookup"><span data-stu-id="15d66-135">The following list describes the valid values for the **Scope** field.</span></span>

<span data-ttu-id="15d66-136">スコープの値</span><span class="sxs-lookup"><span data-stu-id="15d66-136">Scope value</span></span> | <span data-ttu-id="15d66-137">説明</span><span class="sxs-lookup"><span data-stu-id="15d66-137">Description</span></span>
--- | ---
<span data-ttu-id="15d66-138">xbl.signin</span><span class="sxs-lookup"><span data-stu-id="15d66-138">xbl.signin</span></span>  | <span data-ttu-id="15d66-139">クリエーターズ プログラム ゲームのサインイン機能が含まれます。</span><span class="sxs-lookup"><span data-stu-id="15d66-139">Includes the sign in functionality for Creators Program games.</span></span> <span data-ttu-id="15d66-140">クリエーターズ プログラム ゲームでは必須です。</span><span class="sxs-lookup"><span data-stu-id="15d66-140">Required for Creators Program games.</span></span>
<span data-ttu-id="15d66-141">xbl.friends</span><span class="sxs-lookup"><span data-stu-id="15d66-141">xbl.friends</span></span> | <span data-ttu-id="15d66-142">クリエーターズ プログラム ゲームのフレンドとソーシャル ランキング機能が含まれます。</span><span class="sxs-lookup"><span data-stu-id="15d66-142">Includes the friends and social leaderboards functionality for Creators Program games.</span></span>
<span data-ttu-id="15d66-143">xboxlive.signin</span><span class="sxs-lookup"><span data-stu-id="15d66-143">xboxlive.signin</span></span> | <span data-ttu-id="15d66-144">Xbox Live の機能すべてにアクセスするゲームのサインイン機能が含まれます。</span><span class="sxs-lookup"><span data-stu-id="15d66-144">Includes the sign in functionality for games that access the full functionality of Xbox Live.</span></span> <span data-ttu-id="15d66-145">クリエーターズ プログラム以外のゲームでは必須です。</span><span class="sxs-lookup"><span data-stu-id="15d66-145">Required for non-Creators Program games.</span></span>

<span data-ttu-id="15d66-146">現在のところ、**Scope** フィールドを指定するのは Xbox Live クリエーターズ プログラム ゲームを作成しており、ゲームがフレンド リストやソーシャル ランキング (スコープがフレンドのランキング) にアクセスする必要がない場合だけです。</span><span class="sxs-lookup"><span data-stu-id="15d66-146">Currently, the only reason to specify the **Scope** field is if you are making an Xbox Live Creators Program game, and your game does not need to access friends lists or social leaderboards (leaderboards which are scoped to your friends).</span></span> <span data-ttu-id="15d66-147">このような場合、XboxServices.config ファイルに次の行を追加できます。</span><span class="sxs-lookup"><span data-stu-id="15d66-147">If this is the case, you can add the following line to your XboxServices.config file:</span></span>

```
  "Scope" : "xbl.signin"
```

<span data-ttu-id="15d66-148">この行を追加すると、アプリを初めて起動するときに、UWP アプリがフレンド リストにアクセスするためのアクセス許可を要求できなくなります。</span><span class="sxs-lookup"><span data-stu-id="15d66-148">Adding this line prevents the UWP app from requesting permission to access friend lists when you start the app for the first time.</span></span>

## <a name="example-xboxservicesconfig-file"></a><span data-ttu-id="15d66-149">XboxServices.config ファイルの例</span><span class="sxs-lookup"><span data-stu-id="15d66-149">Example XboxServices.config file</span></span>

```
{
  "PrimaryServiceConfigId": "00000000-0000-0000-0000-000064382e34",
  "TitleId": 9039138423,
  "XboxLiveCreatorsTitle": true,
  "Scope" : "xbl.signin xbl.friends"
}
```
