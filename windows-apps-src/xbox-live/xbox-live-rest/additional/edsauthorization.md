---
title: EDS 承認
assetID: bd0bdc8e-084a-7140-98da-6d3721bda112
permalink: en-us/docs/xboxlive/rest/edsauthorization.html
author: KevinAsgari
description: " EDS 承認"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7f160711474c3ec99bcfbbbf0dc94830a8600d3b
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4749034"
---
# <a name="eds-authorization"></a>EDS 承認
 
  * [概要](#ID4EN)
  * [承認プロセス](#ID4EFB)
  * [3.0 トークン: マルチ ユーザーと単一のユーザー](#ID4EEC)
  * [EDS は複数のユーザーをサポートしますか。](#ID4EYC)
 
<a id="ID4EN"></a>

 
## <a name="introduction"></a>概要
 
エンターテイメント探索サービス (EDS) 3.1 は、匿名トラフィックをサポートしていません。 認証は、すべての要求を EDS 必要があります。 EDS には、クライアントを適切に認証を呼び出し元から、XToken が必要です。 これらのトークンは、XSTS によって生成し、さまざまな Xbox 認証サービス (XAS) を通じて取得できます。 デバイス、ユーザーとタイトルはすべて、トークンの id を定義する別の認証サービスがあります。
 
XSTS では、Xbox LIVE のゲートキーパーです。 最初の行の防御の Xbox LIVE サービスに接続するユーザーまたはデバイスが承認されているかどうかを確認することをお勧めします。 ユーザーを認証するには後、は、XSTS は、サービスのコンポーネントを安全に識別に使用できる XToken を生成します。 この XToken では、passport LIVE にです。
 
ユーザーとサービスを使用することです。 ほとんどのそれらモ ノと people サービスを使用できるようにします。 しかし、どのようにことを確認することが、ユーザーに装ったいないし、ユーザーが実際に身元がでしょうか。 それらを提供し他のユーザーに識別するために使用するトークンを使用します。
 
これらのトークンは、XSTS によって生成されたされ、Xtoken として一般的に参照されます。 XToken は、さまざまな異なる場合がありますが格納されている多くの異なる形式でトークンを対象に使用される広範な用語が、すべて作成、署名されている、必要に応じて、XSTS サーバーによって暗号化します。 内部では、XSTS では、MXAN を使用して作成し、トークンの書式を設定します。 MXAN は、これまで、XToken から情報を抽出する唯一のコンポーネントです。 トークンを使用するサービスを解読する MXAN に要求ヘッダーを渡します。 トークンが処理され、検証し、トークンで表されるクレームがサービスに返されます。 サービスは、これらの要求、呼び出し元のユーザーまたはデバイスを識別し、その情報に基づいてアクションを実行する値を使用します。
 
基本的な id トークンのユーザー、デバイス、およびタイトルのについて、Xbox 認証サービス (XAS) によってが提供されます。 各 XAS を担当しているさまざまな要求の値を指定する id トークンを生成します。
 
   * XASD (デバイスの XAS): デバイスの id を提供する DToken を作成します。
   * XASU (ユーザーの XAS): ユーザー id を提供する UToken を作成します。
   * XAST (XAS のタイトル): タイトルの id を提供する TToken を作成します。
   
<a id="ID4EFB"></a>

 
## <a name="authorization-process"></a>承認プロセス
 
   * 1 つまたは複数のユーザー トークンを取得します。 最大で 1 つずつ D、U、および T トークンを含む XToken を要求することができます。 D、または U の少なくとも 1 つを提供する必要があります。 
     * XASD からデバイスの認証の詳細を提供することによって、DToken を要求します。
     * ユーザーの認証の形式を使った XASU から、UToken を要求します。 ユーザーの認証は MSA (RPS) トークンの形式で提供される可能性があります。
     * XAST から、TToken を要求します。 使用可能なタイトルは、現在実行して、DToken XAST に提供することもする必要があるため、プラットフォームによって異なります。
  
   * XSTS 要求を作成します。
 
     * トークンを要求している証明書利用者パーティーを定義します。
     * D、U や T トークンと要求プロパティを設定します。
    * XSTS 要求を実行し、結果として得られる XToken をキャッシュします。 返された XToken が含まれています (ほとんど) のすべての id トークンと追加の要求 (サブスクリプションの現在の状態、ユーザーのグループなど) からデバイス、ユーザー、およびタイトル id の情報の。
   
<a id="ID4EEC"></a>

 
## <a name="30-tokens-multiuser-vs-single-user"></a>3.0 トークン: マルチ ユーザーと単一のユーザー
 
これは、3.0 トークンの形式です。 `XBL3.0 x=&lt;hash>;&lt;token>`
 
によって、&lt;ハッシュ >、トークンが異なる方法で処理します。
 
   * 場合&lt;ハッシュ > に等しい * (アスタリスク) し、特定のユーザーが要求を実行していないトークン内のすべてのユーザーが逆シリアル化されたプリンシパルに存在します。 これは、true のマルチ ユーザーの形式です。
   * 場合&lt;ハッシュ > - (dash) に等しいが要求を実行しているユーザーがありません。 逆シリアル化されたプリンシパル内のユーザーは削除されます。
   * 場合&lt;ハッシュ > と等しくない * または - トークンにユーザーが要求を行っていることを示す識別子がします。 表示されているユーザーのみが逆シリアル化されたプリンシパルになります。 その他のすべてのユーザーは削除されます。これは、シングル ユーザー 3.0 トークンです。
   
<a id="ID4EYC"></a>

 
## <a name="does-eds-support-multi-users"></a>EDS は複数のユーザーをサポートしますか。
 * 答えはノーです。 記載されている場合は、コンソールは 1 人のユーザー トークンを常に送信されます。 複数のユーザーがサインインがある場合でも、指定された「、呼び出し元」その他のすべての id が削除されますが必要があります。
  
<a id="ID4E6C"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EBD"></a>

 
##### <a name="parent"></a>Parent  

[その他の参照情報](atoc-xboxlivews-reference-additional.md)

  
<a id="ID4END"></a>

 
##### <a name="further-information"></a>詳細情報 

[マーケットプレース URI](../uri/marketplace/atoc-reference-marketplace.md)

   