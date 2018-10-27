---
title: ゲーマーアイコン URI
assetID: 811ab696-c433-aa54-90d8-66614ad09901
permalink: en-us/docs/xboxlive/rest/atoc-reference-gamerpic.html
author: KevinAsgari
description: " ゲーマーアイコン URI"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7b45f4556628b64726b96b47b373b3408cf6ddf3
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5684275"
---
# <a name="gamerpic-uris"></a>ゲーマーアイコン URI
 
このセクションでは、*人々*用の Xbox Live サービスから、ゲーマー アイコン ユニバーサル リソース識別子 (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。
 
これらの Uri のドメインが`gamerpics.xboxlive.com`します。
 
ゲーマー アイコン サービスは、ユーザーが、ゲーム キャラクターのゲーマー アイコンを生成できるようにする機能をタイトルに付与することによって、その他の [パーソナル設定] オプションをユーザーに提供する設計されています (このシナリオでゲームの文字は、ゲーム内の主役は、ユーザーがある可能性があります、自動車、宇宙船、またはタイトルでユーザーを制御するその他のエンティティ)。
 
ゲーマー アイコンがタイトルを生成する基本的なフローは次のとおりです。
 
   * タイトルは、ゲーム内の文字のイメージを作成することで、ユーザーを提供します。 
     * 必要でない場合は、タイトルでは適切な特権がないユーザーがメッセージしことができます。
     * ユーザー特権がある場合、は、ユーザーが、文字ゲーマー アイコンを作成する続けることができます。
  
   * ユーザーは、イメージを作成し、タイトルは、ゲーマー アイコン サービスに 1080 x 1080 の .png ファイルを送信します。
   * サービスは、画像を保存し、ユーザーの新しいゲーマー アイコンとして、イメージを設定します。
   * ユーザーのゲーマー アイコンの呼び出しのエクスペリエンスでは、更新後の画像を取得します。
  
ゲーマー アイコンがタイトルを設定する機能は、実施専用特権 (211) によって制御されます。 強制では、特権を取り消します、ユーザーがされなくなりますタイトルのゲーマー アイコンを保存し、サービスには、403 が返されます。 タイトルは、コンテンツ (priv 211) を共有するユーザーが許可されていることを確認する CheckPrivilege を呼び出す必要があります。
 
現在、このサービスを使用するために、タイトルではホワイト リスト化される必要があります。 承認を要求するには、メール`slsgamerpics@microsoft.com`します。
 
<a id="ID4EGC"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/gamerpic](uri-usersmegamerpic.md)

&nbsp;&nbsp;1080 x 1080 ゲーマー アイコンにアクセスします。
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[ユニバーサル リソース識別子 (URI) リファレンス](../atoc-xboxlivews-reference-uris.md)

   