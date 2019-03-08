---
title: ゲーマーアイコン URI
assetID: 811ab696-c433-aa54-90d8-66614ad09901
permalink: en-us/docs/xboxlive/rest/atoc-reference-gamerpic.html
description: " ゲーマーアイコン URI"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a8ba79784ed73ae62e7fe8d65c626c3ebc6003a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618387"
---
# <a name="gamerpic-uris"></a>ゲーマーアイコン URI
 
このセクションの Xbox Live サービスから Gamerpic Universal Resource Identifier (URI) アドレスおよび関連付けられているハイパー テキスト転送プロトコル (HTTP) メソッドの詳細を提供する*gamerpics*します。
 
これらの Uri のドメインが`gamerpics.xboxlive.com`します。
 
タイトルのゲームの文字の gamerpic を生成するユーザーを許可する権限を付与することより多くのパーソナル化オプションをユーザーに付与する Gamerpic サービスは設計されています (このシナリオでのゲームの文字を指す、ゲームの主役は、ユーザーがある可能性があります、自動車、宇宙船、またはその他のエンティティのタイトルにユーザーを制御する)。
 
タイトル gamerpic を生成する基本的な流れは次のとおりです。
 
   * タイトルは、ゲーム内の文字のイメージを作成することができます、ユーザーを提供します。 
     * それ以外の場合は、ユーザーが適切な特権がありませんできますし、メッセージのタイトル。
     * 場合は、ユーザーには、特権がある、ユーザーはその文字 gamerpic を作成するを続けることができます。
  
   * ユーザーがイメージを作成し、タイトルが gamerpic サービスに 1080 x 1080 の .png ファイルを送信します。
   * イメージが格納され、ユーザーの新しい gamerpic としてイメージを設定します。
   * 更新されたイメージは、ユーザーの gamerpic の呼び出しのエクスペリエンスが表示されます。
  
タイトル gamerpic を設定する機能は、強制専用特権 (211) によって制御されます。 強制では、権限を取り消します、ユーザーは、タイトル gamerpic を保存できませんし、サービスには、403 が返されます。 タイトルは、コンテンツ (priv 211) を共有するユーザーが許可されていることを確認する CheckPrivilege を呼び出す必要があります。
 
現在、このサービスを使用するには、タイトルは、ホワイト リストに登録をする必要があります。 承認を要求する電子メール`slsgamerpics@microsoft.com`します。
 
<a id="ID4EGC"></a>

 
## <a name="in-this-section"></a>このセクションの内容

[/users/me/gamerpic](uri-usersmegamerpic.md)

&nbsp;&nbsp;1080 x 1080 gamerpic にアクセスします。
 
<a id="ID4EMC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a>Parent 

[Universal Resource Identifier (URI) のリファレンス](../atoc-xboxlivews-reference-uris.md)

   