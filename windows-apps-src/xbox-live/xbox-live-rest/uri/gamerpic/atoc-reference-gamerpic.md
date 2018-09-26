---
title: ゲーマーアイコン URI
assetID: 811ab696-c433-aa54-90d8-66614ad09901
permalink: en-us/docs/xboxlive/rest/atoc-reference-gamerpic.html
author: KevinAsgari
description: " ゲーマーアイコン URI"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d612f2fe9cb327b792ed3ab73ad17421f394a030
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4209281"
---
# <a name="gamerpic-uris"></a>ゲーマーアイコン URI
 
このセクションでは、*人々*用の Xbox Live サービスからゲーマー アイコン ユニバーサル Resource Identifier (URI) アドレスと関連付けられているハイパー テキスト トランスポート プロトコル (HTTP) 方法に関する詳細を提供します。
 
これらの Uri のドメインが`gamerpics.xboxlive.com`します。
 
ゲーマー アイコン サービスは、ユーザーが、ゲーム キャラクターのゲーマー アイコンを生成できるようにする機能をタイトルに付与することによってその他の [パーソナル設定] オプションをユーザーに提供する設計されています (このシナリオでのゲームの文字は、ゲーム内で主役は、ユーザーがある可能性があります、自動車、宇宙船、またはタイトルでユーザーを制御するその他のエンティティ)。
 
タイトルのゲーマー アイコンを生成する基本的なフローは次のとおりです。
 
   * タイトルがゲーム内で文字のイメージを作成する機能をユーザーに提供します。 
     * 必要でない場合は、タイトルでは適切な特権がないユーザーがメッセージしことができます。
     * ユーザー特権がある場合、は、ユーザーがその文字ゲーマー アイコンを作成する続けることができます。
  
   * ユーザーは、イメージを作成し、タイトルは、ゲーマー アイコン サービスに 1080 x 1080 .png ファイルを送信します。
   * サービスは、画像を保存し、ユーザーの新しいゲーマー アイコンとして、画像を設定します。
   * ユーザーのゲーマー アイコンの呼び出し、エクスペリエンスでは、更新後の画像を取得します。
  
ゲーマー アイコンがタイトルを設定する機能は、実施専用特権 (211) によって制御されます。 強制では、特権を取り消します、ユーザーがされなくなりますタイトル ゲーマー アイコン、保存し、サービスには、403 が返されます。 タイトルは、コンテンツ (priv 211) を共有するユーザーが許可されていることを確認する CheckPrivilege を呼び出す必要があります。
 
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

   