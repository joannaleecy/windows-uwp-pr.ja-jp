---
title: Xbox Live タイトル ストレージ
author: KevinAsgari
description: Xbox Live タイトル ストレージがクラウドにあるタイトルのゲーム情報を使う方法について説明します。
ms.assetid: a4182bc8-d232-4e77-93ae-97fe17ac71b1
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 49f0f88a7e64ce57462b3ee7b07676280d91fb41
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4507168"
---
# <a name="xbox-live-title-storage"></a>Xbox Live タイトル ストレージ

Xbox Live タイトル ストレージ サービスでは、タイトルのゲーム情報をクラウドに格納できます。 どのプラットフォームで実行されるゲームでも、このサービスを使用できます。

<a name="ID4EW"></a>

## <a name="features-of-xbox-live-title-storage"></a>Xbox Live タイトル ストレージの機能

Xbox Live タイトル ストレージの高レベルの機能としては、次のようなものがあります。

-   ユーザー間、タイトル間、およびさまざまなプラットフォーム間で共有できます
-   JSON、バイナリ、および構成ファイルをサポートします

以下のセクションでは、Xbox Live タイトル ストレージの主要な機能について詳しく説明します。

-   [ストレージ タイプ](#ID4ETB)
-   [データの種類](#ID4ECF)
-   [タイトル ストレージ URI](#ID4EBEAC)
-   [調整の制限](#ID4ETEAC)

<a name="ID4ETB"></a>

対象パートナーおよび ID@Xbox メンバー向け:

| 記憶域の種類       | クォータ (管理対象 Partners/ID@Xbox) | クォータ (Xbox Live クリエーターズ プログラム) |  目的                                                                                                                                                      | プラットフォーム                                                                                           | ユーザー                                       |
|--------------------|--------------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------|
| 信頼されたプラットフォーム   | 256 MB/ユーザー | 64 MB/ユーザー    | セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。 セキュリティは高くなりますが、プラットフォームの制限があります。 | 読み取りはすべてのプラットフォームで可能ですが、書き込みは Xbox One、Xbox 360、または Windows Phone だけが可能です。  | パブリックまたは所有者のみに構成できます。       |
| ユニバーサル プラットフォーム | 64 MB/ユーザー | 64 MB/ユーザー    | セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。 | 書き込みはすべてのプラットフォームで可能ですが、読み取りは Xbox One、Xbox 360、または Windows Phone 以外のプラットフォームだけが可能です。 | パブリックまたは所有者のみに構成できます。       |
| グローバル             | 256 MB | 256 MB            | ロスター、マップ、チャレンジ、アート リソースなど、だれでも読み取ることができるデータ。 | のみ Xbox デベロッパー ポータルまたは Windows デベロッパー センター経由で書き込み可能な任意のプラットフォームが読み取れます。                                | すべてのユーザーが読み取れます。

### <a name="deprecated-storage-types"></a>推奨されなくなった記憶域の種類

次の記憶域の種類は推奨されなくなりました。 現在使用しているタイトルでのみサポートされます。 新規タイトルには使用できません。

| 記憶域の種類       | クォータ  |   目的                                                                                                                                                      | プラットフォーム                                                                                           | ユーザー                                       |
|--------------------|--------------------|---------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------|---------------------------------------------|
| JSON               | 64 MB/ユーザー     | セーブ データやゲーム状態 (再生/一時停止/再開) などのユーザー単位のデータ。 セキュリティは高く、プラットフォームの制限はありませんが、データ形式に制限があります (JSON のみ)。 | すべてのプラットフォームで読み取り/書き込みが可能です。                                                                     | パブリックまたは所有者のみに構成できます。       |
| デバイス             | 64 MB/デバイス   | 設定やデバイスの優先設定など、デバイスに固有のデータ。                                                                                            | 書き込みは、Xbox One、Xbox 360、または Windows Phone だけが可能です。 読み取りは、データを書き込んだデバイスだけが可能です。  | すべてのユーザーが読み取れます。                         |
| セッション ストレージ    | 256 MB/セッション | 特定のマルチプレイヤー ゲーム セッションに参加しているユーザーのデータ。                                                                                             | セッションに参加できるプラットフォーム。                                                             | セッションのすべてのユーザーが読み取りまたは書き込みできます。 |


<a name="ID4ECF"></a>

## <a name="types-of-data"></a>データの種類

ゲームでは、GET または PUT メソッドの **{type}** パラメーターで、使用するデータの種類を指定します。 サポートされている 3 つの種類について以下に説明します。

-   [バイナリ情報](#ID4ENF)
-   [JSON 情報](#ID4EUF)
-   [構成情報](#ID4ECAAC)

<a name="ID4ENF"></a>

#### <a name="binary-information"></a>バイナリ情報

イメージ、サウンド、およびカスタム データにはバイナリ型を使用します。 HTTP 経由でバイナリ データを転送する必要があるので、バイナリ データを HTTP で許可される文字にエンコードする必要があります。 たとえば、データを 16 進数の文字列に変換するか、または base64 エンコードを使用できます。 タイトル ストレージ システムはエンコードされたデータを処理しないため、ゲームでは、タイトル ストレージの読み取り時と書き込み時のデータのエンコードとデコードに、同じ方式を使用する必要があります。

<a name="ID4EUF"></a>

#### <a name="json-information"></a>JSON 情報

構造化されたデータには JSON 型を使用できます。 JSON オブジェクトをサポートする JavaScript などの言語では、JSON オブジェクトを直接使用できます。 JSON ファイルからデータを取得するときに、ゲームは *select* パラメーターを提供して、構造内の特定の項目を返すことができます。 たとえば、次の情報を含む JSON 形式のファイルを使用します。

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


| 注                                                                                                                                              |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| セキュリティ上の理由から、JSON データの最初の要素を配列にしないでください。 ルートの配列で送信される JSON データは、サービスによって拒否されます。 |

ゲームは、次のようなクエリによって、この構造の各部分を選択できます。

             GET https://titlestorage.xboxlive.com/users/xuid(1234)/storage/titlestorage/titlegroups/
             faa29d21-2b49-4908-96bf-b953157ac4fe/data/save1.dat,json?select=weapon.name
             Content-Type: application/octet-stream
             x-xbl-contract-version: 1
             Authorization: XBL3.0 x=<userHash>;<STSTokenString>
             Connection: Keep-Alive

このクエリに対する応答の本文は次のようになります。

    {
        "name" : "poison"
    }

配列にアクセスするには、次のようなクエリを使用します。

      GET https://titlestorage.xboxlive.com//users/xuid(1234)/storage/titlestorage/titlegroups/
      faa29d21-2b49-4908-96bf-b953157ac4fe/data/save1.dat,json?select=levels[3].quest
      Content-Type: application/octet-stream
      x-xbl-contract-version: 1
      Authorization: XBL3.0 x=<userHash>;<STSTokenString>
      Connection: Keep-Alive

このクエリに対する応答の本文は次のようになります。

    {
        "quest" : "queen"
    }

JSON データには次の長さ制限が適用されます。

-   数値、最大長 = 32
-   文字列値、最大長 = 1024
-   プロパティ名、最大長 = 64
-   階層、最大深度 = 16
-   配列、最大サイズ = 1024
-   子プロパティ、オブジェクト内の最大数 = 1024

<a name="ID4ECAAC"></a>

#### <a name="configuration-information"></a>構成情報

**{type}** を **config** にすると、データが構成 BLOB であることを示すことができます。 構成 BLOB は、グローバル タイトル ストレージに格納されるデータ構造です。 BLOB の形式は JSON オブジェクトに似ています。

構成 BLOB には、候補リストからの設定を返す仮想ノードを含めることができます。 仮想ノードは、タイトルやロケールなどの特定の状況に応じた設定を提供する場合に役立ちます。 仮想ノードには、いくつかの使用可能な設定値と、それらの値から選択するための条件が含まれます。 次の例では、**defaultCardDesign** 設定を、仮想ノード内のいずれかの値にすることができます。

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

ゲームがこのファイルを読み取ると、システムは **\_sourceNodes** 配列の値の 1 つを選択します。 この場合は、ゲームのタイトル ID に基づいて項目が選択されます。 ゲーム **12456799** をプレイしているユーザーの場合は、次のようになります。

    {
      "defaultCardDesign":"RobotUnicornCard.png,binary",
      "_sourceNodes":["defaultCardDesign:titleID:1234567899"]
    }

それ以外のユーザーの場合は、次のようになります。

    {
      "defaultCardDesign":"StandardCard.png,binary",
      "_sourceNodes":["defaultCardDesign:titleID:default"]
    }

ゲームでは、要求内のパラメーターと一致するカスタム セレクターを定義できます。 たとえば、次の構成 BLOB をご覧ください。

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

ゲームは **customSelector** パラメーターで文字列を渡して、返す項目を選択します。 たとえば、2 つ目のオプションを取得する場合、ゲームは次のように要求します。

      GET https://titlestorage.xboxlive.com/media/titlegroups/faa29d21-2b49-4908-96bf-b953157ac4fe
      /storage/data/config.json,config?customSelector=gameMode.serious
      Content-Type: application/octet-stream
      x-xbl-contract-version: 1
      Authorization: XBL3.0 x=<userHash>;<STSTokenString>
      Connection: Keep-Alive

**\_selectBy** 値は実行する選択の種類を示し、**\_selector** 値は選択で使用するデータを示します。 設定できる値は次のとおりです。

<table>
<thead>
<tr>
<th>_selectBy</th>
<th>説明</th>
</tr>
</thead>
<tbody>
<tr>
<td >titleId</td>
<td ><p><strong>_selector</strong> は、提供されたクレームのタイトル ID と一致します。</p></td>
</tr>
<tr>
<td >locale</td>
<td ><p><strong>_selector</strong> は、Accept-Language ヘッダーのロケール文字列と一致します。</p></td>
</tr>
<tr>
<td >custom</td>
<td ><p><strong>_selector</strong> は、<strong>customSelector</strong> クエリ パラメーターで渡されるカスタム文字列と一致します。 <strong>customSelector</strong> には、コンマで区切られた 1 つ以上のクエリが含まれます。 各クエリは、<strong>selectBy</strong> 要素からの名前と <strong>_selector</strong> 要素からの値です。</p></td>
</tr>
</tbody>
</table>

<a name="ID4EBEAC"></a>

## <a name="title-storage-uris"></a>タイトル ストレージ URI

タイトル ストレージ URI の形式は次のとおりです。

    https://titlestorage.xboxlive.com/{path}

URI の **{path}** 部分は、作成する要求の種類を指定し、245 文字以内にする必要があります。

<a name="ID4ETEAC"></a>

## <a name="throttle-limit"></a>調整の制限

タイトルが 1 分間に実行できる読み取りまたは書き込みの回数に決まった制限はありませんが、一般に、1 時間のセッションで 1 分あたり平均 1 回を超えることはできません。 たとえば、タイトルがセッションの冒頭に 60 回の読み取りまたは書き込みを行うと、その 1 時間の残りの期間はそれ以上の読み取りまたは書き込みを行えません。 Xbox LIVE サービスが要求の調整を必要とする場合は、後の方で多くの呼び出しを行えるようにタイトルを強化する必要があります。

タイトルに、追加の読み取りや書き込みなどの特殊なパーティション要件がある場合は、マイクロソフトにお問い合わせください。

<a name="ID4E5EAC"></a>

## <a name="using-title-storage"></a>タイトル ストレージの使用方法

タイトル ストレージを利用する場合は、最初に、格納するデータの種類を決定します。 セーブ データ、ゲーム状態、デイリー チャレンジ、ゲーム マップ、アート リソースなどがあります。

次に、データにアクセスする必要があるタイトルとプラットフォームを決定します。 タイトル ストレージは、単一プラットフォーム上の単一タイトルから、および複数プラットフォーム上の複数タイトルからのクラウド データ アクセスをサポートします。

最後に、このセクションのトピックを使用して、ストレージを構成し、データをアップロードし、選択した内容に基づいて適切にアクセス許可を設定します。

<a name="ID4EJFAC"></a>

## <a name="in-this-section"></a>このセクションの内容

[Xbox Live タイトル ストレージ内の構成 BLOB の読み取り](reading-configuration-blobs.md)  
Xbox Live タイトル ストレージから構成 BLOB を読み取る方法を示します。

[Xbox Live タイトル ストレージへのバイナリ BLOB の保存](storing-binary-blobs.md)  
Xbox Live タイトル ストレージにバイナリ BLOB を保存する方法を示します。

[Xbox Live タイトル ストレージ内のバイナリ BLOB の読み取り](reading-binary-blobs.md)  
Xbox Live タイトル ストレージからバイナリ BLOB を読み取る方法を示します。

[Xbox Live タイトル ストレージへの JSON BLOB の保存](storing-jsonblobs.md)  
Xbox Live タイトル ストレージに JSON BLOB を保存する方法を示します。

[Xbox Live タイトル ストレージ内の JSON BLOB の読み取り](reading-jsonblobs.md)  
Xbox Live タイトル ストレージから JSON BLOB を読み取る方法を示します。

<a name="ID4E4FAC"></a>
