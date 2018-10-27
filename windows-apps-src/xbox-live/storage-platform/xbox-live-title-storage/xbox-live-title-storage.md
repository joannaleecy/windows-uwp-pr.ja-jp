---
title: Xbox Live タイトル ストレージ
author: KevinAsgari
description: Xbox Live タイトル ストレージがクラウドにあるタイトルのゲーム情報を使う方法について説明します。
ms.assetid: a4182bc8-d232-4e77-93ae-97fe17ac71b1
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4186a0fe6d6023703c3e1e88e2d78519f793e9e6
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5681982"
---
# <a name="xbox-live-title-storage"></a><span data-ttu-id="db440-104">Xbox Live タイトル ストレージ</span><span class="sxs-lookup"><span data-stu-id="db440-104">Xbox Live Title Storage</span></span>

<span data-ttu-id="db440-105">Xbox Live タイトル ストレージ サービスでは、タイトルのゲーム情報をクラウドに格納できます。</span><span class="sxs-lookup"><span data-stu-id="db440-105">The Xbox Live title storage service provides a way to store game information for a title in the cloud.</span></span> <span data-ttu-id="db440-106">どのプラットフォームで実行されるゲームでも、このサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="db440-106">Games running on all platforms can use this service.</span></span>

<a name="ID4EW"></a>

## <a name="features-of-xbox-live-title-storage"></a><span data-ttu-id="db440-107">Xbox Live タイトル ストレージの機能</span><span class="sxs-lookup"><span data-stu-id="db440-107">Features of Xbox Live title storage</span></span>

<span data-ttu-id="db440-108">Xbox Live タイトル ストレージの高レベルの機能としては、次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="db440-108">Some of the high-level features of Xbox Live title storage include, but are not limited to:</span></span>

-   <span data-ttu-id="db440-109">ユーザー間、タイトル間、およびさまざまなプラットフォーム間で共有できます</span><span class="sxs-lookup"><span data-stu-id="db440-109">Can be shared across users, titles, and various platforms</span></span>
-   <span data-ttu-id="db440-110">JSON、バイナリ、および構成ファイルをサポートします</span><span class="sxs-lookup"><span data-stu-id="db440-110">Supports JSON, binary, and configuration files</span></span>

<span data-ttu-id="db440-111">以下のセクションでは、Xbox Live タイトル ストレージの主要な機能について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="db440-111">The main features of Xbox Live title storage are explained in more detail in the following sections:</span></span>

-   [<span data-ttu-id="db440-112">ストレージ タイプ</span><span class="sxs-lookup"><span data-stu-id="db440-112">Types of storage</span></span>](#ID4ETB)
-   [<span data-ttu-id="db440-113">データの種類</span><span class="sxs-lookup"><span data-stu-id="db440-113">Types of data</span></span>](#ID4ECF)
-   [<span data-ttu-id="db440-114">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="db440-114">Title storage URIs</span></span>](#ID4EBEAC)
-   [<span data-ttu-id="db440-115">調整の制限</span><span class="sxs-lookup"><span data-stu-id="db440-115">Throttle Limit</span></span>](#ID4ETEAC)

<a name="ID4ETB"></a>

<span data-ttu-id="db440-116">対象パートナーおよび ID@Xbox メンバー向け:</span><span class="sxs-lookup"><span data-stu-id="db440-116">For managed partners and ID@Xbox members:</span></span>

| <span data-ttu-id="db440-117">記憶域の種類</span><span class="sxs-lookup"><span data-stu-id="db440-117">Storage Type</span></span>       | <span data-ttu-id="db440-118">クォータ (管理対象 Partners/ID@Xbox)</span><span class="sxs-lookup"><span data-stu-id="db440-118">Quota (Managed Partners/ID@Xbox)</span></span> | <span data-ttu-id="db440-119">クォータ (Xbox Live クリエーターズ プログラム)</span><span class="sxs-lookup"><span data-stu-id="db440-119">Quota (Xbox Live Creators Program)</span></span> |  <span data-ttu-id="db440-120">目的</span><span class="sxs-lookup"><span data-stu-id="db440-120">Purpose</span></span>                                                                                                                                                      | <span data-ttu-id="db440-121">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="db440-121">Platforms</span></span>                                                                                           | <span data-ttu-id="db440-122">ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-122">Users</span></span>                                       |
|--------------------|--------------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------|
| <span data-ttu-id="db440-123">信頼されたプラットフォーム</span><span class="sxs-lookup"><span data-stu-id="db440-123">Trusted Platform</span></span>   | <span data-ttu-id="db440-124">256 MB/ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-124">256 MB per user</span></span> | <span data-ttu-id="db440-125">64 MB/ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-125">64 MB per user</span></span>    | <span data-ttu-id="db440-126">セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-126">Per-user data such as saved games or game state for play/pause/resume.</span></span> <span data-ttu-id="db440-127">セキュリティは高くなりますが、プラットフォームの制限があります。</span><span class="sxs-lookup"><span data-stu-id="db440-127">More secure, but with platform restrictions.</span></span> | <span data-ttu-id="db440-128">読み取りはすべてのプラットフォームで可能ですが、書き込みは Xbox One、Xbox 360、または Windows Phone だけが可能です。</span><span class="sxs-lookup"><span data-stu-id="db440-128">Any platform may read, but only Xbox One, Xbox 360, or Windows Phone may write.</span></span>  | <span data-ttu-id="db440-129">パブリックまたは所有者のみに構成できます。</span><span class="sxs-lookup"><span data-stu-id="db440-129">Configurable to public or owner only.</span></span>       |
| <span data-ttu-id="db440-130">ユニバーサル プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="db440-130">Universal Platform</span></span> | <span data-ttu-id="db440-131">64 MB/ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-131">64 MB per user</span></span> | <span data-ttu-id="db440-132">64 MB/ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-132">64 MB per user</span></span>    | <span data-ttu-id="db440-133">セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-133">Per-user data such as saved games or game state for play/pause/resume.</span></span> | <span data-ttu-id="db440-134">書き込みはすべてのプラットフォームで可能ですが、読み取りは Xbox One、Xbox 360、または Windows Phone 以外のプラットフォームだけが可能です。</span><span class="sxs-lookup"><span data-stu-id="db440-134">Any platform may write, but only platforms other than Xbox One, Xbox 360 or Windows Phone may read.</span></span> | <span data-ttu-id="db440-135">パブリックまたは所有者のみに構成できます。</span><span class="sxs-lookup"><span data-stu-id="db440-135">Configurable to public or owner only.</span></span>       |
| <span data-ttu-id="db440-136">グローバル</span><span class="sxs-lookup"><span data-stu-id="db440-136">Global</span></span>             | <span data-ttu-id="db440-137">256 MB</span><span class="sxs-lookup"><span data-stu-id="db440-137">256 MB</span></span> | <span data-ttu-id="db440-138">256 MB</span><span class="sxs-lookup"><span data-stu-id="db440-138">256 MB</span></span>            | <span data-ttu-id="db440-139">ロスター、マップ、チャレンジ、アート リソースなど、だれでも読み取ることができるデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-139">Data that everyone can read, such as rosters, maps, challenges, or art resources.</span></span> | <span data-ttu-id="db440-140">のみ Xbox デベロッパー ポータルまたは Windows デベロッパー センター経由で書き込み可能な任意のプラットフォームが読み取れます。</span><span class="sxs-lookup"><span data-stu-id="db440-140">Only writeable via the Xbox Developer Portal or Windows Dev Center, any platform may read.</span></span>                                | <span data-ttu-id="db440-141">すべてのユーザーが読み取れます。</span><span class="sxs-lookup"><span data-stu-id="db440-141">All users may read.</span></span>

### <a name="deprecated-storage-types"></a><span data-ttu-id="db440-142">推奨されなくなった記憶域の種類</span><span class="sxs-lookup"><span data-stu-id="db440-142">Deprecated storage Types</span></span>

<span data-ttu-id="db440-143">次の記憶域の種類は推奨されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="db440-143">The following storage types are deprecated.</span></span> <span data-ttu-id="db440-144">現在使用しているタイトルでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="db440-144">They are supported only for titles that are currently using them.</span></span> <span data-ttu-id="db440-145">新規タイトルには使用できません。</span><span class="sxs-lookup"><span data-stu-id="db440-145">They are not available for new titles.</span></span>

| <span data-ttu-id="db440-146">記憶域の種類</span><span class="sxs-lookup"><span data-stu-id="db440-146">Storage Type</span></span>       | <span data-ttu-id="db440-147">クォータ</span><span class="sxs-lookup"><span data-stu-id="db440-147">Quota</span></span>  |   <span data-ttu-id="db440-148">目的</span><span class="sxs-lookup"><span data-stu-id="db440-148">Purpose</span></span>                                                                                                                                                      | <span data-ttu-id="db440-149">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="db440-149">Platforms</span></span>                                                                                           | <span data-ttu-id="db440-150">ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-150">Users</span></span>                                       |
|--------------------|--------------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------|
| <span data-ttu-id="db440-151">JSON</span><span class="sxs-lookup"><span data-stu-id="db440-151">JSON</span></span>               | <span data-ttu-id="db440-152">64 MB/ユーザー</span><span class="sxs-lookup"><span data-stu-id="db440-152">64 MB per user</span></span>     | <span data-ttu-id="db440-153">セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-153">Per-user data such as saved games or game state for play/pause/resume.</span></span> <span data-ttu-id="db440-154">セキュリティは高く、プラットフォームの制限はありませんが、データ形式に制限があります (JSON のみ)。</span><span class="sxs-lookup"><span data-stu-id="db440-154">More secure, no platform restrictions, but with data format restrictions (JSON only).</span></span> | <span data-ttu-id="db440-155">すべてのプラットフォームで読み取り/書き込みが可能です。</span><span class="sxs-lookup"><span data-stu-id="db440-155">Any platform may read or write.</span></span>                                                                     | <span data-ttu-id="db440-156">パブリックまたは所有者のみに構成できます。</span><span class="sxs-lookup"><span data-stu-id="db440-156">Configurable to public or owner only.</span></span>       |
| <span data-ttu-id="db440-157">デバイス</span><span class="sxs-lookup"><span data-stu-id="db440-157">Device</span></span>             | <span data-ttu-id="db440-158">64 MB/デバイス</span><span class="sxs-lookup"><span data-stu-id="db440-158">64 MB per device</span></span>   | <span data-ttu-id="db440-159">設定やデバイスの優先設定など、デバイスに固有のデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-159">Data specific to a device such as settings or device preferences.</span></span>                                                                                            | <span data-ttu-id="db440-160">書き込みは、Xbox One、Xbox 360、または Windows Phone だけが可能です。</span><span class="sxs-lookup"><span data-stu-id="db440-160">Only Xbox One, Xbox 360, or Windows Phone may write.</span></span> <span data-ttu-id="db440-161">読み取りは、データを書き込んだデバイスだけが可能です。</span><span class="sxs-lookup"><span data-stu-id="db440-161">Only the device that wrote the data may read.</span></span>  | <span data-ttu-id="db440-162">すべてのユーザーが読み取れます。</span><span class="sxs-lookup"><span data-stu-id="db440-162">All users may read.</span></span>                         |
| <span data-ttu-id="db440-163">セッション ストレージ</span><span class="sxs-lookup"><span data-stu-id="db440-163">Session Storage</span></span>    | <span data-ttu-id="db440-164">256 MB/セッション</span><span class="sxs-lookup"><span data-stu-id="db440-164">256 MB per session</span></span> | <span data-ttu-id="db440-165">特定のマルチプレイヤー ゲーム セッションに参加しているユーザーのデータ。</span><span class="sxs-lookup"><span data-stu-id="db440-165">Data for anyone joined to a particular multiplayer game session.</span></span>                                                                                             | <span data-ttu-id="db440-166">セッションに参加できるプラットフォーム。</span><span class="sxs-lookup"><span data-stu-id="db440-166">Any platform that may join the session.</span></span>                                                             | <span data-ttu-id="db440-167">セッションのすべてのユーザーが読み取りまたは書き込みできます。</span><span class="sxs-lookup"><span data-stu-id="db440-167">All users in the session may read or write.</span></span> |


<a name="ID4ECF"></a>

## <a name="types-of-data"></a><span data-ttu-id="db440-168">データの種類</span><span class="sxs-lookup"><span data-stu-id="db440-168">Types of data</span></span>

<span data-ttu-id="db440-169">ゲームでは、GET または PUT メソッドの **{type}** パラメーターで、使用するデータの種類を指定します。</span><span class="sxs-lookup"><span data-stu-id="db440-169">Games specify the type of data to use in the **{type}** parameter of a GET or PUT method.</span></span> <span data-ttu-id="db440-170">サポートされている 3 つの種類について以下に説明します。</span><span class="sxs-lookup"><span data-stu-id="db440-170">The following section describes the three supported types:</span></span>

-   [<span data-ttu-id="db440-171">バイナリ情報</span><span class="sxs-lookup"><span data-stu-id="db440-171">Binary Information</span></span>](#ID4ENF)
-   [<span data-ttu-id="db440-172">JSON 情報</span><span class="sxs-lookup"><span data-stu-id="db440-172">JSON Information</span></span>](#ID4EUF)
-   [<span data-ttu-id="db440-173">構成情報</span><span class="sxs-lookup"><span data-stu-id="db440-173">Configuration information</span></span>](#ID4ECAAC)

<a name="ID4ENF"></a>

#### <a name="binary-information"></a><span data-ttu-id="db440-174">バイナリ情報</span><span class="sxs-lookup"><span data-stu-id="db440-174">Binary Information</span></span>

<span data-ttu-id="db440-175">イメージ、サウンド、およびカスタム データにはバイナリ型を使用します。</span><span class="sxs-lookup"><span data-stu-id="db440-175">Images, sounds, and custom data use the binary type.</span></span> <span data-ttu-id="db440-176">HTTP 経由でバイナリ データを転送する必要があるので、バイナリ データを HTTP で許可される文字にエンコードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="db440-176">Because the data must be transmitted over HTTP, binary data must be encoded into characters that HTTP accepts.</span></span> <span data-ttu-id="db440-177">たとえば、データを 16 進数の文字列に変換するか、または base64 エンコードを使用できます。</span><span class="sxs-lookup"><span data-stu-id="db440-177">For example, you can convert the data to hexadecimal strings or use base64 encoding.</span></span> <span data-ttu-id="db440-178">タイトル ストレージ システムはエンコードされたデータを処理しないため、ゲームでは、タイトル ストレージの読み取り時と書き込み時のデータのエンコードとデコードに、同じ方式を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="db440-178">The title storage system does not process the encoded data, so your game must use the same scheme for encoding and decoding data when reading from and writing to title storage.</span></span>

<a name="ID4EUF"></a>

#### <a name="json-information"></a><span data-ttu-id="db440-179">JSON 情報</span><span class="sxs-lookup"><span data-stu-id="db440-179">JSON Information</span></span>

<span data-ttu-id="db440-180">構造化されたデータには JSON 型を使用できます。</span><span class="sxs-lookup"><span data-stu-id="db440-180">Structured data can use the JSON type.</span></span> <span data-ttu-id="db440-181">JSON オブジェクトをサポートする JavaScript などの言語では、JSON オブジェクトを直接使用できます。</span><span class="sxs-lookup"><span data-stu-id="db440-181">JSON objects can be directly used in languages, like JavaScript, that support them.</span></span> <span data-ttu-id="db440-182">JSON ファイルからデータを取得するときに、ゲームは *select* パラメーターを提供して、構造内の特定の項目を返すことができます。</span><span class="sxs-lookup"><span data-stu-id="db440-182">When retrieving data from JSON files, the game can supply a *select* parameter to return specific items within the structure.</span></span> <span data-ttu-id="db440-183">たとえば、次の情報を含む JSON 形式のファイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="db440-183">For example, use a JSON formatted file that contains the following information:</span></span>

    {
    "difficulty" : 1,
    "level" :
        [
            { "number" : "1", "quest" : "swords" },
            { "number" : "2", "quest" : "iron" },
            { "number" : "3", "quest" : "gold" },
            { "number" : "4", "quest" : "queen" }
         ],
    "weapon" :
        {
             "name" : "poison",
             "timeleft" : "2mins"
        }
    }


| <span data-ttu-id="db440-184">注</span><span class="sxs-lookup"><span data-stu-id="db440-184">Note</span></span>                                                                                                                                              |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="db440-185">セキュリティ上の理由から、JSON データの最初の要素を配列にしないでください。</span><span class="sxs-lookup"><span data-stu-id="db440-185">For security purposes, the first element of the JSON data must not be an array.</span></span> <span data-ttu-id="db440-186">ルートの配列で送信される JSON データは、サービスによって拒否されます。</span><span class="sxs-lookup"><span data-stu-id="db440-186">JSON data submitted with an array at the root will be rejected by the service.</span></span> |

<span data-ttu-id="db440-187">ゲームは、次のようなクエリによって、この構造の各部分を選択できます。</span><span class="sxs-lookup"><span data-stu-id="db440-187">Games can select portions of this structure with a query like this:</span></span>

             GET https://titlestorage.xboxlive.com/users/xuid(1234)/storage/titlestorage/titlegroups/
             faa29d21-2b49-4908-96bf-b953157ac4fe/data/save1.dat,json?select=weapon.name
             Content-Type: application/octet-stream
             x-xbl-contract-version: 1
             Authorization: XBL3.0 x=<userHash>;<STSTokenString>
             Connection: Keep-Alive

<span data-ttu-id="db440-188">このクエリに対する応答の本文は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="db440-188">The response body for this query is:</span></span>

    {
        "name" : "poison"
    }

<span data-ttu-id="db440-189">配列にアクセスするには、次のようなクエリを使用します。</span><span class="sxs-lookup"><span data-stu-id="db440-189">The array can be accessed with a query like this:</span></span>

      GET https://titlestorage.xboxlive.com//users/xuid(1234)/storage/titlestorage/titlegroups/
      faa29d21-2b49-4908-96bf-b953157ac4fe/data/save1.dat,json?select=levels[3].quest
      Content-Type: application/octet-stream
      x-xbl-contract-version: 1
      Authorization: XBL3.0 x=<userHash>;<STSTokenString>
      Connection: Keep-Alive

<span data-ttu-id="db440-190">このクエリに対する応答の本文は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="db440-190">The response body for this query is:</span></span>

    {
        "quest" : "queen"
    }

<span data-ttu-id="db440-191">JSON データには次の長さ制限が適用されます。</span><span class="sxs-lookup"><span data-stu-id="db440-191">The following length restrictions are enforced for JSON data:</span></span>

-   <span data-ttu-id="db440-192">数値、最大長 = 32</span><span class="sxs-lookup"><span data-stu-id="db440-192">Numeric value, maximum length = 32</span></span>
-   <span data-ttu-id="db440-193">文字列値、最大長 = 1024</span><span class="sxs-lookup"><span data-stu-id="db440-193">String value, maximum length = 1024</span></span>
-   <span data-ttu-id="db440-194">プロパティ名、最大長 = 64</span><span class="sxs-lookup"><span data-stu-id="db440-194">Property name, maximum length = 64</span></span>
-   <span data-ttu-id="db440-195">階層、最大深度 = 16</span><span class="sxs-lookup"><span data-stu-id="db440-195">Hierarchy, maximum depth = 16</span></span>
-   <span data-ttu-id="db440-196">配列、最大サイズ = 1024</span><span class="sxs-lookup"><span data-stu-id="db440-196">Array, maximum size = 1024</span></span>
-   <span data-ttu-id="db440-197">子プロパティ、オブジェクト内の最大数 = 1024</span><span class="sxs-lookup"><span data-stu-id="db440-197">Child properties, maximum in an object = 1024</span></span>

<a name="ID4ECAAC"></a>

#### <a name="configuration-information"></a><span data-ttu-id="db440-198">構成情報</span><span class="sxs-lookup"><span data-stu-id="db440-198">Configuration information</span></span>

<span data-ttu-id="db440-199">**{type}** を **config** にすると、データが構成 BLOB であることを示すことができます。</span><span class="sxs-lookup"><span data-stu-id="db440-199">The **{type}** can be **config** to indicate that the data is a configuration blob.</span></span> <span data-ttu-id="db440-200">構成 BLOB は、グローバル タイトル ストレージに格納されるデータ構造です。</span><span class="sxs-lookup"><span data-stu-id="db440-200">Configuration blobs are data structures that are stored in global title storage.</span></span> <span data-ttu-id="db440-201">BLOB の形式は JSON オブジェクトに似ています。</span><span class="sxs-lookup"><span data-stu-id="db440-201">The format of the blob is similar to a JSON object.</span></span>

<span data-ttu-id="db440-202">構成 BLOB には、候補リストからの設定を返す仮想ノードを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="db440-202">Configuration blobs can include virtual nodes that return a setting from a list of possibilities.</span></span> <span data-ttu-id="db440-203">仮想ノードは、タイトルやロケールなどの特定の状況に応じた設定を提供する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="db440-203">Virtual nodes are useful for providing settings for specific situations, such as for a title or locale.</span></span> <span data-ttu-id="db440-204">仮想ノードには、いくつかの使用可能な設定値と、それらの値から選択するための条件が含まれます。</span><span class="sxs-lookup"><span data-stu-id="db440-204">The virtual node includes several possible settings along with values and conditions for selecting from the values.</span></span> <span data-ttu-id="db440-205">次の例では、**defaultCardDesign** 設定を、仮想ノード内のいずれかの値にすることができます。</span><span class="sxs-lookup"><span data-stu-id="db440-205">In the following example, the **defaultCardDesign** setting can have one of the values in the virtual node.</span></span>

    {
      "defaultCardDesign":
      {
        "_virtualNode":
       {
          "_selectBy":"titleId",
          "_sourceNodes":
          [
            {"_selector":"123456799", "_data":"RobotUnicornCard.png,binary"},
            {"_selector":"default", "_data":"StandardCard.png,binary"}
          ]
        }
      },
    }

<span data-ttu-id="db440-206">ゲームがこのファイルを読み取ると、システムは **\_sourceNodes** 配列の値の 1 つを選択します。</span><span class="sxs-lookup"><span data-stu-id="db440-206">When a game reads this file, the system selects one of the values from the **\_sourceNodes** array.</span></span> <span data-ttu-id="db440-207">この場合は、ゲームのタイトル ID に基づいて項目が選択されます。</span><span class="sxs-lookup"><span data-stu-id="db440-207">In this case, the item is selected based on the title ID of the game.</span></span> <span data-ttu-id="db440-208">ゲーム **12456799** をプレイしているユーザーの場合は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="db440-208">Users playing the game **12456799** see:</span></span>

    {
      "defaultCardDesign":"RobotUnicornCard.png,binary",
      "_sourceNodes":["defaultCardDesign:titleID:1234567899"]
    }

<span data-ttu-id="db440-209">それ以外のユーザーの場合は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="db440-209">The rest of the users see:</span></span>

    {
      "defaultCardDesign":"StandardCard.png,binary",
      "_sourceNodes":["defaultCardDesign:titleID:default"]
    }

<span data-ttu-id="db440-210">ゲームでは、要求内のパラメーターと一致するカスタム セレクターを定義できます。</span><span class="sxs-lookup"><span data-stu-id="db440-210">Games can define custom selectors that match a parameter in the request.</span></span> <span data-ttu-id="db440-211">たとえば、次の構成 BLOB をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="db440-211">For example, in this config blob:</span></span>

    {
        "defaultCardDesign":
        {
            "_virtualNode":
            {
                "_selectBy":"custom:gameMode",
                "_sourceNodes":
                [
                    {"_selector":"silly", "_data":"RobotUnicornCard.png,binary"},
                    {"_selector":"serious", "_data":"SeriousCard.png,binary"},
                    {"_selector":"default", "_data":"StandardCard.png,binary"}
                 ]
            }
        },
        "backgroundColor":"green",
        "dealerHitsOnSoft17":true
    }

<span data-ttu-id="db440-212">ゲームは **customSelector** パラメーターで文字列を渡して、返す項目を選択します。</span><span class="sxs-lookup"><span data-stu-id="db440-212">Games pass a string the **customSelector** parameter to select which item to return.</span></span> <span data-ttu-id="db440-213">たとえば、2 つ目のオプションを取得する場合、ゲームは次のように要求します。</span><span class="sxs-lookup"><span data-stu-id="db440-213">For example, to get the second option, a game requests:</span></span>

      GET https://titlestorage.xboxlive.com/media/titlegroups/faa29d21-2b49-4908-96bf-b953157ac4fe
      /storage/data/config.json,config?customSelector=gameMode.serious
      Content-Type: application/octet-stream
      x-xbl-contract-version: 1
      Authorization: XBL3.0 x=<userHash>;<STSTokenString>
      Connection: Keep-Alive

<span data-ttu-id="db440-214">**\_selectBy** 値は実行する選択の種類を示し、**\_selector** 値は選択で使用するデータを示します。</span><span class="sxs-lookup"><span data-stu-id="db440-214">The **\_selectBy** value indicates what type of selection to do and the **\_selector** value indicates the data to use in the selection.</span></span> <span data-ttu-id="db440-215">設定できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="db440-215">The possible values are:</span></span>

<table>
<thead>
<tr>
<th><span data-ttu-id="db440-216">_selectBy</span><span class="sxs-lookup"><span data-stu-id="db440-216">_selectBy</span></span></th>
<th><span data-ttu-id="db440-217">説明</span><span class="sxs-lookup"><span data-stu-id="db440-217">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr>
<td ><span data-ttu-id="db440-218">titleId</span><span class="sxs-lookup"><span data-stu-id="db440-218">titleId</span></span></td>
<td ><p><span data-ttu-id="db440-219"><strong>_selector</strong> は、提供されたクレームのタイトル ID と一致します。</span><span class="sxs-lookup"><span data-stu-id="db440-219">The <strong>_selector</strong> matches the title ID in the provided claim.</span></span></p></td>
</tr>
<tr>
<td ><span data-ttu-id="db440-220">locale</span><span class="sxs-lookup"><span data-stu-id="db440-220">locale</span></span></td>
<td ><p><span data-ttu-id="db440-221"><strong>_selector</strong> は、Accept-Language ヘッダーのロケール文字列と一致します。</span><span class="sxs-lookup"><span data-stu-id="db440-221">The <strong>_selector</strong> matches the locale string from the Accept-Language header.</span></span></p></td>
</tr>
<tr>
<td ><span data-ttu-id="db440-222">custom</span><span class="sxs-lookup"><span data-stu-id="db440-222">custom</span></span></td>
<td ><p><span data-ttu-id="db440-223"><strong>_selector</strong> は、<strong>customSelector</strong> クエリ パラメーターで渡されるカスタム文字列と一致します。</span><span class="sxs-lookup"><span data-stu-id="db440-223">The <strong>_selector</strong> matches a custom string passed in the <strong>customSelector</strong> query parameter.</span></span> <span data-ttu-id="db440-224"><strong>customSelector</strong> には、コンマで区切られた 1 つ以上のクエリが含まれます。</span><span class="sxs-lookup"><span data-stu-id="db440-224">The <strong>customSelector</strong> contains one or more queries separated by commas.</span></span> <span data-ttu-id="db440-225">各クエリは、<strong>selectBy</strong> 要素からの名前と <strong>_selector</strong> 要素からの値です。</span><span class="sxs-lookup"><span data-stu-id="db440-225">Each query is the name from the <strong>selectBy</strong> element and the value from the <strong>_selector</strong> element.</span></span></p></td>
</tr>
</tbody>
</table>

<a name="ID4EBEAC"></a>

## <a name="title-storage-uris"></a><span data-ttu-id="db440-226">タイトル ストレージ URI</span><span class="sxs-lookup"><span data-stu-id="db440-226">Title storage URIs</span></span>

<span data-ttu-id="db440-227">タイトル ストレージ URI の形式は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="db440-227">Title storage URIs are formatted as follows:</span></span>

    https://titlestorage.xboxlive.com/{path}

<span data-ttu-id="db440-228">URI の **{path}** 部分は、作成する要求の種類を指定し、245 文字以内にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="db440-228">The **{path}** portion of the URI is the type of request being made and must be 245 characters or fewer.</span></span>

<a name="ID4ETEAC"></a>

## <a name="throttle-limit"></a><span data-ttu-id="db440-229">調整の制限</span><span class="sxs-lookup"><span data-stu-id="db440-229">Throttle Limit</span></span>

<span data-ttu-id="db440-230">タイトルが 1 分間に実行できる読み取りまたは書き込みの回数に決まった制限はありませんが、一般に、1 時間のセッションで 1 分あたり平均 1 回を超えることはできません。</span><span class="sxs-lookup"><span data-stu-id="db440-230">There are no fixed limits on how many reads or writes a title can make per minute, but it generally cannot make more than one per minute on average in a one-hour session.</span></span> <span data-ttu-id="db440-231">たとえば、タイトルがセッションの冒頭に 60 回の読み取りまたは書き込みを行うと、その 1 時間の残りの期間はそれ以上の読み取りまたは書き込みを行えません。</span><span class="sxs-lookup"><span data-stu-id="db440-231">For example, a title can make 60 reads or writes at the beginning of a session but no more for the remainder of the hour.</span></span> <span data-ttu-id="db440-232">Xbox LIVE サービスが要求の調整を必要とする場合は、後の方で多くの呼び出しを行えるようにタイトルを強化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="db440-232">Titles should be hardened against more calls later, in case Xbox LIVE Services needs to throttle the requests.</span></span>

<span data-ttu-id="db440-233">タイトルに、追加の読み取りや書き込みなどの特殊なパーティション要件がある場合は、マイクロソフトにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="db440-233">If your title has special partitioning requirements, such as extra reads or writes, contact Microsoft.</span></span>

<a name="ID4E5EAC"></a>

## <a name="using-title-storage"></a><span data-ttu-id="db440-234">タイトル ストレージの使用方法</span><span class="sxs-lookup"><span data-stu-id="db440-234">Using title storage</span></span>

<span data-ttu-id="db440-235">タイトル ストレージを利用する場合は、最初に、格納するデータの種類を決定します。</span><span class="sxs-lookup"><span data-stu-id="db440-235">To get started with title storage, first determine what kind of data you want to store.</span></span> <span data-ttu-id="db440-236">セーブ データ、ゲーム状態、デイリー チャレンジ、ゲーム マップ、アート リソースなどがあります。</span><span class="sxs-lookup"><span data-stu-id="db440-236">Some examples include saved games, game state, daily challenges, game maps, and art resources.</span></span>

<span data-ttu-id="db440-237">次に、データにアクセスする必要があるタイトルとプラットフォームを決定します。</span><span class="sxs-lookup"><span data-stu-id="db440-237">Next determine what titles and platforms will need to access the data.</span></span> <span data-ttu-id="db440-238">タイトル ストレージは、単一プラットフォーム上の単一タイトルから、および複数プラットフォーム上の複数タイトルからのクラウド データ アクセスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="db440-238">Title storage supports cloud data access from a single title on a single platform, and from multiple titles on multiple platforms.</span></span>

<span data-ttu-id="db440-239">最後に、このセクションのトピックを使用して、ストレージを構成し、データをアップロードし、選択した内容に基づいて適切にアクセス許可を設定します。</span><span class="sxs-lookup"><span data-stu-id="db440-239">Finally, use the topics in this section to configure your storage, upload your data, and set access permissions appropriately based on your choices.</span></span>

<a name="ID4EJFAC"></a>

## <a name="in-this-section"></a><span data-ttu-id="db440-240">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="db440-240">In this section</span></span>

[<span data-ttu-id="db440-241">Xbox Live タイトル ストレージ内の構成 BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="db440-241">Reading a Configuration Blob in Xbox Live Title Storage</span></span>](reading-configuration-blobs.md)  
<span data-ttu-id="db440-242">Xbox Live タイトル ストレージから構成 BLOB を読み取る方法を示します。</span><span class="sxs-lookup"><span data-stu-id="db440-242">Demonstrates reading configuration blobs from Xbox Live title storage.</span></span>

[<span data-ttu-id="db440-243">Xbox Live タイトル ストレージへのバイナリ BLOB の保存</span><span class="sxs-lookup"><span data-stu-id="db440-243">Storing a Binary Blob in Xbox Live Title Storage</span></span>](storing-binary-blobs.md)  
<span data-ttu-id="db440-244">Xbox Live タイトル ストレージにバイナリ BLOB を保存する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="db440-244">Demonstrates storing binary blobs in Xbox Live title storage.</span></span>

[<span data-ttu-id="db440-245">Xbox Live タイトル ストレージ内のバイナリ BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="db440-245">Reading a Binary Blob in Xbox Live Title Storage</span></span>](reading-binary-blobs.md)  
<span data-ttu-id="db440-246">Xbox Live タイトル ストレージからバイナリ BLOB を読み取る方法を示します。</span><span class="sxs-lookup"><span data-stu-id="db440-246">Demonstrates reading binary blobs from Xbox Live title storage.</span></span>

[<span data-ttu-id="db440-247">Xbox Live タイトル ストレージへの JSON BLOB の保存</span><span class="sxs-lookup"><span data-stu-id="db440-247">Storing a JSON Blob in Xbox Live Title Storage</span></span>](storing-jsonblobs.md)  
<span data-ttu-id="db440-248">Xbox Live タイトル ストレージに JSON BLOB を保存する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="db440-248">Demonstrates storing JSON blobs in Xbox Live title storage.</span></span>

[<span data-ttu-id="db440-249">Xbox Live タイトル ストレージ内の JSON BLOB の読み取り</span><span class="sxs-lookup"><span data-stu-id="db440-249">Reading a JSON Blob in Xbox Live Title Storage</span></span>](reading-jsonblobs.md)  
<span data-ttu-id="db440-250">Xbox Live タイトル ストレージから JSON BLOB を読み取る方法を示します。</span><span class="sxs-lookup"><span data-stu-id="db440-250">Demonstrates reading JSON blobs from Xbox Live title storage.</span></span>

<a name="ID4E4FAC"></a>
