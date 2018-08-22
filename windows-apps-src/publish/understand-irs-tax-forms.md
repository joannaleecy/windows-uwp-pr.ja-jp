---
author: jnHs
Description: Learn about the tax forms issued by Microsoft, including who will receive them and when they are made available.
title: マイクロソフトが発行する IRS の税関連の書類について
ms.author: wdg-dev-content
ms.date: 03/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 課税, irs, 米国内国歳入庁, 税, 所得税, 1099
ms.assetid: 1e475b96-f953-457c-864f-b6f4cb4c309f
ms.localizationpriority: medium
ms.openlocfilehash: ffefc1d645a79296989e95c2fa033b8848e91c3b
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2794313"
---
# <a name="understand-irs-tax-forms-issued-by-microsoft"></a>マイクロソフトが発行する IRS の税関連の書類について

開発者は、所在地および受け取っている売上高や支払い額に応じて、毎年マイクロソフトから 1 種類以上の税関連の書類を受け取る可能性があります。 マイクロソフトはこれらの書類を発行し、米国内国歳入庁 (IRS) に提出する必要があります。

ここでは、どのような開発者が書類を受け取り、いつ利用可能になるのかなど、これらの書類について詳しく説明します。

## <a name="types-of-tax-forms"></a>税関連の書類の種類

| IRS の税関連の書類 | 説明 | 利用可能時期 |
|--------------|-------------|--------------|
|1099-MISC、1099-K | マイクロソフトのマーケットプレースへの参加に関する販売アクティビティや開発者への支払いに関連します。 | 書類には **1 月 31 日**までの消印が押されます。また、同時に .pdf コピーがデベロッパー センターで利用可能になります (**[ダッシュボード]、[アカウント設定]、[税プロファイル]** の順に移動します)。 |
|1042-S | 米国の源泉徴収税の対象になる開発者への支払いに関連します。 | 書類には **3 月 15 日**までの消印が押されます。また、同時に .pdf コピーがデベロッパー センターで利用可能になります (**[ダッシュボード]、[アカウント設定]、[税プロファイル]** の順に移動します)。 |

> [!NOTE]
> 注: IRS の税関連書類に記載される住所には、[税プロファイル](setting-up-your-payout-account-and-tax-forms.md#tax-forms)内の住所が利用されます。 住所を変更した場合は、**[税プロファイル]** の住所も変更するようにしてください。

## <a name="for-developers-located-in-the-united-states"></a>米国在住の開発者の場合

<table>
  <tr>
     <th>米国在住の開発者で有料アプリを販売しており、以下の条件を満たす場合 </th>
     <th> 以下の書類を受け取る</th>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、<b>アプリの販売数が 200 個を上回り</b>、アプリ販売の合計購入金額が <b>20,000 米国ドルを超えました</b> (Windows 10 の Microsoft Store 経由でブラジルおよび中国で販売された数は<b>含まれません</b>)。</td>
    <td valign="top"><b>1099-K</b>:<br>
提出者: Microsoft Corporation<br>
EIN: \*\*\*\*\*4442<br>
<br>
**重要:** フォーム 1099 K には、開発者に支払われた金額ではなく、**仕入総額**が記載されます。</td>
  </tr>
  <tr> 
     <td valign="top">(i) Windows 10 の Microsoft Store 経由でブラジルおよび中国で販売したアプリまたは (ii) Minecraft Marketplace マーケットプレースでの売り上げについて、<b>10 ドル以上の支払い額</b>を受け取りました。<br>
<br>
**または**<br>
<br>
適用される税年度に、アプリの売り上げと関連のない 600 ドル以上の支払いをマイクロソフトから受け取りました (インセンティブ支払いや、コンテストまたはプロモーションによる支払いなど)。</td>
    <td valign="top"><b>1099-MISC</b> :<br>
支払者: Microsoft Corporation<br>
EIN: \*\*\*\*\*4442<br>
<br>
**重要:** 一部のビジネス エンティティは、マイクロソフトから支払い金額を受け取っているかどうかに関係なく、1099-MISC フォームを受け取りません。  詳細については、税務の専門家にお問い合わせください。</td>
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
     <th>米国在住の開発者で有料アプリを販売しており、以下の条件を満たす場合 </th>
     <th> 以下の書類を受け取る</th>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、アプリ内広告によって <b>600 ドル以上の支払い</b>を受け取りました。</td>
    <td valign="top"><b>1099-MISC</b>:<br>
支払い人: Microsoft Online Inc<br>
EIN: \*\*\*\*\*0505<br>
<br>
**重要:** 一部のビジネス エンティティは、マイクロソフトから支払い金額を受け取っているかどうかに関係なく、1099-MISC フォームを受け取りません。  詳細については、税務の専門家にお問い合わせください。  </td>
  </tr>
  <tr> 
     <td valign="top">適用される税年度に、アプリ内広告によって <b>600 ドル未満の支払い</b>を受け取りました。</td>
     <td valign="top">なし</td>
  </tr>
</table>


## <a name="for-developers-located-outside-of-the-united-states"></a>米国外に在住する開発者の場合

<table>
  <tr>
    <td valign="top"><b>マイクロソフトから 1042-S フォームを受け取りました。 これは何のためですか。</b></td>
    <td valign="top">マイクロソフトが 1042-S フォームを送った理由は、米国の税務当局に申告義務があると見なされている、源泉徴収税の対象になった収益を、マイクロソフトが開発者に対して支払ったためです。  フォーム 1042-S は、この報告義務のために使用されます。</td>
  </tr>
  <tr>
    <td valign="top"><b>この書類にどのように対応する必要がありますか。</b></td>
    <td valign="top">一般的に、開発者側で特別な対応は必要ありません。 フォーム 1402-S は、開発者が管轄の税務当局に任意の形式の税額控除を申請する場合に役立つ可能性があります。  このトピックについて詳しくは、税金アドバイザーにお問い合わせください。</td>
  </tr>
  <tr>
    <td valign="top"><b>W8 フォームをすべて記入した際に支払いが源泉徴収されたのはなぜですか。</b></td>
    <td valign="top">税金は次のいずれかの場合に源泉徴収されます。<br>
     1. W8 の租税条約の項がすべて正しく記載されていなかった場合<br>
     2. 米国との租税条約がない国に在住している場合

     You can visit Dev Center at any time to submit an updated W8 form.<br>
     <br>
     **Note:** Not all income is subject to tax withholding.</td>
  </tr>
  <tr>
    <td valign="top"><b>適切な条約情報を使って更新した W8 フォームを提出しました。 マイクロソフトは源泉徴収された税金を払い戻してくれますか。</b></td>
    <td valign="top">源泉徴収された税金を払い戻すことはできません。 これらの税金について地域で控除を請求できるかどうか、または IRS から払い戻しを求められるかどうかについては、税金アドバイザーにご相談ください。</td>
  </tr>
  <tr>
    <td valign="top"><b>フォーム 104-S ではどのような売り上げが報告されますか。</b></td>
    <td valign="top"><b>源泉徴収の対象として分類された、米国在住の購入者に対する</b>売り上げのみ報告義務があります。  その他の売り上げはすべて報告義務があるとは見なされていません。</td>
  </tr>
  <tr>
    <td valign="top"><b>同じフォーム 1042-S が 3 部同封されていたのはなぜですか。</b></td>
    <td valign="top">IRS 規則により、次の 3 つの目的で書類を 3 部提供する必要があります。
<ul>
<li>受取人の記録のため</li>
<li>米国連邦政府の所得税申告に提出するため (該当する場合)</li>
<li>米国の所得税申告に提出するため (該当する場合)</li>
</ul></td>
  </tr>
</table>


> [!NOTE]
> **IRS の税関連の書類**に関する質問や懸案事項が他にもある場合は、[サポート チケット](http://aka.ms/storesupport)を作成してください。 マイクロソフトは特定の税金の事情に関する質問にはお答えできません。これらの質問については、税務の専門家にお問い合わせください。
