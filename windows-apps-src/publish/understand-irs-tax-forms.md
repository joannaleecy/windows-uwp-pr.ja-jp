---
Description: マイクロソフトが発行する税関連の書類について、どのような開発者がその書類を受け取るのか、いつ書類が利用できるようになるのかなどを説明します。
title: マイクロソフトが発行する IRS の税関連の書類について
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, 課税, irs, 米国内国歳入庁, 税, 所得税, 1099
ms.assetid: 1e475b96-f953-457c-864f-b6f4cb4c309f
ms.localizationpriority: medium
ms.openlocfilehash: fb25887d9bc40bd9c596cd437b7d2d6d06047020
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639287"
---
# <a name="understand-irs-tax-forms-issued-by-microsoft"></a>マイクロソフトが発行する IRS の税関連の書類について

開発者は、所在地および受け取っている売上高や支払い額に応じて、毎年マイクロソフトから 1 種類以上の税関連の書類を受け取る可能性があります。 マイクロソフトはこれらの書類を発行し、米国内国歳入庁 (IRS) に提出する必要があります。

ここでは、どのような開発者が書類を受け取り、いつ利用可能になるのかなど、これらの書類について詳しく説明します。

## <a name="types-of-tax-forms"></a>税関連の書類の種類

| IRS の税関連の書類 | 説明 | 対象 |
|--------------|-------------|--------------|
|1099-MISC、1099-K | マイクロソフトのマーケットプレースへの参加に関する販売アクティビティや開発者への支払いに関連します。 | 以前に印刷されるフォームを消印が**1 月 31 日**、.pdf のコピーで利用できる[パートナー センター](https://partner.microsoft.com/dashboard) (で**アカウント設定 > プロファイルの税**) と同時に |
|1042-S | 米国の源泉徴収税の対象になる開発者への支払いに関連します。 | 以前に印刷されるフォームを消印が**3 月 15 日**、.pdf のコピーは、パートナー センターで利用可能になります (で**アカウント設定 > プロファイルの税**) と同時に |

> [!NOTE]
> 内のアドレスからの IRS 税金申告フォームで使用してこのアドレスは、[税プロファイル](setting-up-your-payout-account-and-tax-forms.md#tax-forms)します。 住所を変更した場合は、**[税プロファイル]** の住所も変更するようにしてください。

税金申告フォームは、次のアドレスから送信します。

**米国市民:**
<table>
<tr><th>ビジネス グループ</th><th>法人</th><th>Address</th></tr>
<tr><td>Windows、Office、Azure</td><td>Microsoft Corporation</td><td>One Microsoft Way<br>Redmond WA 98052 USA</td></tr>
<tr><td>広告</td><td>Microsoft Online Inc.</td><td>6100 Neil Road<br>Reno, NV 89511 USA</td></tr>
<table> 

**米国以外の市民:**
<table>
<tr><th>ビジネス グループ</th><th>法人</th><th>Address</th></tr>
<tr><td>Windows、Office、Azure</td><td>Microsoft Ireland Operations Limited (支払いを行った Microsoft Ireland 経由で Microsoft Corporation によって Microsoft Corporation の修飾の仲介役として機能する)</td><td>1 つの Microsoft の場所<br>南&nbsp;郡&nbsp;ビジネス&nbsp;Park<br>Leopardstown、アイルランドの Dublin 18</td></tr>
<tr><td>広告 *</td><td>Microsoft Ireland Operations Limited (支払いを行った Microsoft Ireland 経由で Microsoft Online Inc. によって Microsoft オンライン Inc. の払い戻し金額エージェントとして機能する)</td><td>1 つの Microsoft の場所<br>南&nbsp;郡&nbsp;ビジネス&nbsp;Park<br>Leopardstown、アイルランドの Dublin 18</td></tr>
<tr><td>広告</td><td>Microsoft Online Inc.</td><td>6100 Neil Road<br>Reno, NV 89511 USA</td></tr>
<tr><td colspan="3">* 広告収益を獲得する次の国の市民は支払いを Microsoft Ireland Operations Limited 経由。オーストリア、ベルギー、ブルガリア、クロアチア、キプロス、チェコ共和国、デンマーク、エストニア、フィンランド、フランス、ドイツ、ギリシャ、ハンガリー、アイルランド、マン島、イタリア、ラトビア、リヒテンシュタイン、リトアニア、ルクセンブルグ、マルタ、モナコ、オランダ、ノルウェー、ポーランド、ポルトガル、ルーマニア、スロバキア、スロベニア、南アフリカ、スペイン、スウェーデン、スイス、英国</td></tr>
</table>

## <a name="for-developers-located-in-the-united-states"></a>米国在住の開発者の場合

<table>
  <tr>
     <th>米国在住の開発者で有料アプリを販売しており、以下の条件を満たす場合 </th>
     <th> 以下の書類を受け取る</th>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、<b>アプリの販売数が 200 個を上回り</b>、アプリ販売の合計購入金額が <b>20,000 米国ドルを超えました</b> (Windows 10 の Microsoft Store 経由でブラジルおよび中国で販売された数は<b>含まれません</b>)。</td>
    <td valign="top"><b>1099-K</b>:<br>フィルター:Microsoft Corporation<br>EIN: *****4442<br><br><b>重要な</b>:フォーム 1099 K が含まれます<b>購入の総</b>金額、いない支払いができるようになります。</td>
  </tr>
  <tr> 
     <td valign="top">(i) Windows 10 の Microsoft Store 経由でブラジルおよび中国で販売したアプリまたは (ii) Minecraft Marketplace マーケットプレースでの売り上げについて、<b>10 ドル以上の支払い額</b>を受け取りました。<br>
<br>
<b>OR</b><br>
<br>
適用される税年度に、アプリの売り上げと関連のない 600 ドル以上の支払いをマイクロソフトから受け取りました (インセンティブ支払いや、コンテストまたはプロモーションによる支払いなど)。</td>
    <td valign="top"><b>1099-MISC</b>:<br>納税者:Microsoft Corporation<br>EIN: *****4442<br><br><b>重要な</b>:特定のビジネス エンティティは、Microsoft から受け取った支払い金額に関係なく 1099-MISC フォームを受信しません。  詳細については、税務の専門家にお問い合わせください。</td>
  </tr>
  <tr>
    <td valign="top">上のいずれの理由も該当しません。</td>
    <td valign="top">なし</td>
  </tr>
  <tr>
    <td valign="top">&nbsp;</td>
    <td valign="top">&nbsp;</td>
  </tr>
  <tr>
     <th>米国開発者はアプリの広告を販売しているかどうかとしています. </th>
     <th> 以下の書類を受け取る</th>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、アプリ内広告によって <b>600 ドル以上の支払い</b>を受け取りました。</td>
    <td valign="top"><b>1099-MISC</b>:<br>納税者:Microsoft Online Inc<br>EIN: *****0505<br><br><b>重要な</b>:特定のビジネス エンティティは、Microsoft から受け取った支払い金額に関係なく 1099-MISC フォームを受信しません。  詳細については、税務の専門家にお問い合わせください。</td>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、アプリ内広告によって <b>600 ドル未満の支払い</b>を受け取りました。</td>
     <td valign="top">なし</td>
  </tr>
</table>


## <a name="for-developers-located-outside-of-the-united-states"></a>米国外に在住する開発者の場合

<table>
  <tr>
    <td valign="top"><b>フォーム 1042-s Microsoft から受け取りました。それには何か</b></td>
    <td valign="top">マイクロソフトが 1042-S フォームを送った理由は、米国の税務当局に申告義務があると見なされている、源泉徴収税の対象になった収益を、マイクロソフトが開発者に対して支払ったためです。  フォーム 1042-S は、この報告義務のために使用されます。</td>
  </tr>
  <tr>
    <td valign="top"><b>フォームにはどうすればでしょうか。</b></td>
    <td valign="top">一般的に、開発者側で特別な対応は必要ありません。 フォーム 1402-S は、開発者が管轄の税務当局に任意の形式の税額控除を申請する場合に役立つ可能性があります。  このトピックについて詳しくは、税金アドバイザーにお問い合わせください。</td>
  </tr>
  <tr>
    <td valign="top"><b>支払の源泉徴収 W8 フォームを完了する税がされました</b></td>
    <td valign="top">税金は次のいずれかの場合に源泉徴収されます。<br>
     1. W8 の税条約セクションを正常に完了しなかったか、<br>
     2. 米国の税条約がない国に常駐するいるとしています。<br><br>パートナー センターは、更新された W8 フォームを送信するには、いつでもアクセスできます。<br><br><b>注意</b>:すべての収益と源泉徴収されるは。</td>
  </tr>
  <tr>
    <td valign="top"><b>有効な条約情報で更新された W8 フォームを送信しました。Microsoft 返金 me 源泉徴収される税額でしょうか。</b></td>
    <td valign="top">源泉徴収された税金を払い戻すことはできません。 これらの税金について地域で控除を請求できるかどうか、または IRS から払い戻しを求められるかどうかについては、税金アドバイザーにご相談ください。</td>
  </tr>
  <tr>
    <td valign="top"><b>どのような売上 1042 s が報告されるでしょうか。</b></td>
    <td valign="top"><b>源泉徴収の対象として分類された、米国在住の購入者に対する</b>売り上げのみ報告義務があります。  その他の売り上げはすべて報告義務があるとは見なされていません。</td>
  </tr>
  <tr>
    <td valign="top"><b>同じフォーム 1042 S の 3 つのコピーを 1 つのエンベロープで取得しました</b></td>
    <td valign="top">IRS 規則により、次の 3 つの目的で書類を 3 部提供する必要があります。
<ul>
<li>受取人の記録のため</li>
<li>米国連邦政府の所得税申告に提出するため (該当する場合)</li>
<li>米国の所得税申告に提出するため (該当する場合)</li>
</ul></td>
  </tr>
</table>


> [!NOTE]
> **IRS の税関連の書類**に関する質問や懸案事項が他にもある場合は、[サポート チケット](https://aka.ms/storesupport)を作成してください。 マイクロソフトは特定の税金の事情に関する質問にはお答えできません。これらの質問については、税務の専門家にお問い合わせください。
