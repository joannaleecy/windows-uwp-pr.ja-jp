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
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4466840"
---
# <a name="xboxservicesconfig-file-description"></a>XboxServices.config ファイルの説明

Xbox Live 対応の UWP ゲームを開発する場合、プロジェクトに XboxServices.config ファイルを含める必要があります。  このファイルは、Xbox Live SDK がゲームとデベロッパー センター アプリおよび Xbox Live サービス構成を関連付けることができるようにします。 このファイルには、サービス構成 ID、タイトル ID など情報が詳細に記述された JSON オブジェクトが含まれています。

Xbox Live プラグインを使うことで、Unity を使って Xbox Live クリエーターズ プログラムを設計する場合、このファイルは Xbox Live の関連付けウィザードによって自動的に作成されます。

## <a name="xboxservicesconfig-fields"></a>XboxServices.config のフィールド

>[!NOTE]
> Xbox Live 関連付けウィザードによって作成されたファイルには、以下で説明するフィールド以外のフィールドも含まれていることがありますが、サービスによって使用されません。

構成ファイル内の JSON オブジェクトでは、次のフィールドが定義されています。

フィールド | 説明
--- | ---
PrimaryServiceConfigId  |  Xbox Live サービス構成 ID (SCID)。 [デベロッパー センター ダッシュボード](https://developer.microsoft.com/en-us/dashboard)では、アプリの **[サービス]** セクションにある **[Xbox Live]** ページ (クリエーターズ プログラムの場合) または **[Xbox Live Setup]** (Xbox Live のセットアップ) ページ (フル Xbox Live ゲームの場合) でこの値を確認できます。
TitleId  |  アプリの 10 進数のタイトル ID。 [デベロッパー センター ダッシュボード](https://developer.microsoft.com/en-us/dashboard)では、アプリの **[サービス]** セクションにある **[Xbox Live]** ページ (クリエーターズ プログラムの場合) または **[Xbox Live Setup]** (Xbox Live のセットアップ) ページ (フル Xbox Live ゲームの場合) でこの値を確認できます。
XboxLiveCreatorsTitle  |  "true" の場合、アプリが Xbox Live クリエーターズ プログラム アプリであることを示します。 それ以外の場合は "false" です。
Scope  |  **(省略可能)** アプリによって使用される機能のスコープを定義します。 詳細については、以下をご覧ください。

### <a name="scope-field"></a>Scope フィールド

**Scope** フィールドは、ゲームで使用されている機能を示すために使用できるオプション フィールドです。


**Scope** フィールドが指定されない場合、次の表で説明するように、スコープは **XboxLiveCreatorsTitle** フィールドの値に応じて既定値に設定されます。

XboxLiveCreatorsTitle 値 | 既定のスコープ値
--- | ---
"true"  |  "xbl.signin xbl.friends"
"false"  |  "xboxlive.signin"



次の一覧では、**Scope** フィールドの有効な値について説明しています。

スコープの値 | 説明
--- | ---
xbl.signin  | クリエーターズ プログラム ゲームのサインイン機能が含まれます。 クリエーターズ プログラム ゲームでは必須です。
xbl.friends | クリエーターズ プログラム ゲームのフレンドとソーシャル ランキング機能が含まれます。
xboxlive.signin | Xbox Live の機能すべてにアクセスするゲームのサインイン機能が含まれます。 クリエーターズ プログラム以外のゲームでは必須です。

現在のところ、**Scope** フィールドを指定するのは Xbox Live クリエーターズ プログラム ゲームを作成しており、ゲームがフレンド リストやソーシャル ランキング (スコープがフレンドのランキング) にアクセスする必要がない場合だけです。 このような場合、XboxServices.config ファイルに次の行を追加できます。

```
  "Scope" : "xbl.signin"
```

この行を追加すると、アプリを初めて起動するときに、UWP アプリがフレンド リストにアクセスするためのアクセス許可を要求できなくなります。

## <a name="example-xboxservicesconfig-file"></a>XboxServices.config ファイルの例

```
{
  "PrimaryServiceConfigId": "00000000-0000-0000-0000-000064382e34",
  "TitleId": 9039138423,
  "XboxLiveCreatorsTitle": true,
  "Scope" : "xbl.signin xbl.friends"
}
```
