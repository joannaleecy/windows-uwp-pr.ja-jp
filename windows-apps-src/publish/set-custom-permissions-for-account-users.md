---
author: jnHs
Description: "アカウント ユーザーのカスタムのアクセス許可を設定します。"
title: "アカウント ユーザーのカスタムのアクセス許可の設定"
ms.assetid: 99f3aa18-98b4-4919-bd7b-d78356b0bf78
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: 5645eee3dc2ef67b5263b08800b0f96eb8a0a7da
ms.openlocfilehash: 23d8c14bfdbfc05a1397fa67cb831d38ec092233
ms.lasthandoff: 02/08/2017

---

# <a name="set-custom-permissions-for-account-users"></a>アカウント ユーザーのカスタムのアクセス許可の設定

ユーザーに自分のアカウントを追加する場合、ユーザーに[標準の役割](manage-account-users.md#roles-and-permissions)を付与するか、またはアクセス許可をカスタマイズして、ユーザーに適切なレベルのアクセスを提供することを選択できます。 これらのアクセス許可の一部はアカウント全体に適用したり、すべての製品に付与する、または特定の製品に制限したりすることができます。 

標準の役割ではなく、カスタムのアクセス許可を使用するには、ユーザー アカウントを追加または編集するときに、**[役割]** セクションの **[アクセス許可のカスタマイズ]** をクリックします。 

> **注:**ユーザー、グループ、または Azure AD アプリケーションを追加するかどうかに関係なく同じアクセス許可を適用することができます。

ユーザーのアクセス許可を有効にするには、ボックスを適切な設定に切り替えます。 

![アクセス設定のガイド](images/permission_key.png)

- **アクセス権なし**: ユーザーは指定されたアクセス許可を持っていません。
- **読み取り専用**: ユーザーは指定された領域に関連する機能を表示できますが、変更はできません。
- **読み取り/書き込み**: ユーザーは、領域の表示と領域に関連付けられている変更を実行できます。
- **混合**: このオプションを直接選択することはできませんが、該当のアクセス許可に対して組み合わせたアクセスを許可している場合は、**[混合]** インジケーターが表示されます。 たとえば、**[すべての製品]** に対して**[価格と使用可能状況]** への**読み取り専用**アクセスを付与しているときに、ある特定の製品に対して **[価格と使用可能状況]** への**読み取り/書き込み**アクセスを付与する場合は、**[すべての製品]** の **[価格と使用可能状況]** インジケーターが [混合] として表示されます。 これは、一部の製品にアクセス許可の**アクセス権なし**が設定されているときに、他の製品に**読み取り/書き込み**と**読み取り専用**の両方またはそのいずれかのアクセスが設定されている場合も、同様に適用されます。

分析データの表示に関連するものなど、一部のアクセス許可で付与できるのは、**読み取り専用**アクセスのみです。 現在の実装では、**読み取り専用**と**読み取り/書き込み**のアクセスが区別されないアクセス許可もありますので注意してください。 **読み取り専用**と**読み取り/書き込み**のアクセスによって付与される特定の機能を理解するには、各アクセス許可の詳細を確認してください。

それぞれのアクセス許可に関する特定の詳細については、下記の表で説明します。

## <a name="account-level-permissions"></a>アカウント レベルのアクセス許可

このセクションのアクセス許可を特定の製品に対して制限することはできません。 これらのアクセス許可にアクセス権を付与すると、ユーザーはアカウント全体に対して該当するアクセス許可を持つことができます。

<table>
    <colgroup>
    <col width="20%" />
    <col width="40%" />
    <col width="40%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">アクセス許可名</th>
    <th align="left">読み取り専用</th>
    <th align="left">読み取り/書き込み</th>
    </tr>
    </thead>
    <tbody>
<tr><td align="left">    **アカウント設定**                    </td><td align="left">  [連絡先情報](managing-your-profile.md)など、**[アカウント設定]** セクションのすべてのページを表示できます。       </td><td align="left">  **アカウント設定**セクションのすべてのページを表示できます。 [連絡先情報](managing-your-profile.md)と他のページを変更できますが、支払いアカウントや税プロファイルは変更できません (アクセス許可が個別に付与されている場合を除く)。            </td></tr>
<tr><td align="left">    **アカウント ユーザー**                       </td><td align="left">  **[ユーザーの管理]** セクションでアカウントに追加されているユーザーを表示できます。          </td><td align="left">  **[ユーザーの管理]** セクションで、ユーザーのアカウントへの追加と既存のユーザーの変更ができます。             </td></tr>
<tr><td align="left">    **アカウント レベルの広告パフォーマンス レポート** </td><td align="left">  アカウント レベルの[広告パフォーマンス レポート](advertising-performance-report.md#account-level-advertising-performance-report)を表示できます。 (アクセス許可が個別に付与されている場合を除き、個々の製品の広告パフォーマンス レポートを表示することはできません。)       </td><td align="left">  該当なし   </td></tr>
<tr><td align="left">    **広告キャンペーン**                        </td><td align="left">  アカウントで作成した[広告キャンペーン](create-an-ad-campaign-for-your-app.md)を表示できます。      </td><td align="left">  アカウントで作成した[広告キャンペーン](create-an-ad-campaign-for-your-app.md)を作成、管理、および表示できます。          </td></tr>
<tr><td align="left">    **広告仲介**                        </td><td align="left">  アカウント内のすべての製品の[広告仲介の構成](https://msdn.microsoft.com/library/windows/apps/xaml/mt149935.aspx)を表示できます。    </td><td align="left">  アカウント内のすべての製品の[広告仲介の構成](https://msdn.microsoft.com/library/windows/apps/xaml/mt149935.aspx)の表示と変更ができます。        </td></tr>
<tr><td align="left">    **広告仲介レポート**                </td><td align="left">  アカウント内のすべての製品の[広告仲介レポート](ad-mediation-report.md)を表示できます。    </td><td align="left">  該当なし    </td></tr>
<tr><td align="left">    **広告パフォーマンス レポート**              </td><td align="left">  アカウント内のすべての製品の[広告パフォーマンス レポート](advertising-performance-report.md)を表示できます。 (アクセス許可が個別に付与されている場合を除き、アカウント レベルの[広告パフォーマンス レポート](advertising-performance-report.md#account-level-advertising-performance-report)を表示することはできません。)       </td><td align="left">  アカウント内のすべての製品の[広告パフォーマンス レポート](advertising-performance-report.md)を表示できます。 (アクセス許可が個別に付与されている場合を除き、アカウント レベルの[広告パフォーマンス レポート](advertising-performance-report.md#account-level-advertising-performance-report)を表示することはできません。)         </td></tr>
<tr><td align="left">    **広告ユニット**                            </td><td align="left">  アカウント用に作成された[広告ユニット](monetize-with-ads.md)を表示できます。    </td><td align="left">  アカウントの[広告ユニット](monetize-with-ads.md)を作成、管理、および表示できます。             </td></tr>
<tr><td align="left">    **アフィリエイト広告**                       </td><td align="left">  アカウント内のすべての製品で[アフィリエイト広告](about-affiliate-ads.md)の利用状況を表示できます。    </td><td align="left">  アカウント内のすべての製品に対して[アフィリエイト広告](about-affiliate-ads.md)の利用状況の管理と表示ができます。                </td></tr>
<tr><td align="left">    **アフィリエイト パフォーマンス レポート**      </td><td align="left">  アカウント内のすべての製品の[アフィリエイト パフォーマンス レポート](affiliates-performance-report.md)を表示できます。   </td><td align="left">  該当なし   </td></tr>
<tr><td align="left">    **アプリ インストール広告レポート**             </td><td align="left">  アカウント内のすべての製品の[アプリ インストール広告レポート](app-install-ads-reports.md)を表示できます。           </td><td align="left">  該当なし   </td></tr>
<tr><td align="left">    **コミュニティ広告**                       </td><td align="left">  アカウント内のすべての製品の無料[コミュニティ広告](about-community-ads.md)の利用状況を表示できます。          </td><td align="left">  アカウント内のすべての製品の無料[コミュニティ広告](about-community-ads.md)の利用状況を作成、管理、および表示できます。               </td></tr>
<tr><td align="left">    **連絡先情報**                        </td><td align="left">  [アカウント設定] セクションで[連絡先情報](managing-your-profile.md)を表示できます。        </td><td align="left">  [アカウント設定] セクションで[連絡先情報](managing-your-profile.md)の編集と表示ができます。            </td></tr>
<tr><td align="left">    **COPPA 準拠**                    </td><td align="left">  アカウント内のすべての製品の [COPPA 準拠](monetize-with-ads.md#coppa-compliance)の選択 (製品が13歳未満の子供を対象とするかどうかを示す) を表示できます。                                            </td><td align="left">  アカウント内のすべての製品の [COPPA 準拠](monetize-with-ads.md#coppa-compliance)の選択 (製品が13歳未満の子供を対象とするかどうかを示す) の編集と表示ができます。         </td></tr>
<tr><td align="left">    **顧客グループ**                     </td><td align="left">  **[顧客]** セクションで[顧客グループ](create-customer-groups.md) (セグメントとフライト グループ) を表示できます。      </td><td align="left">  **[顧客]** セクションで[顧客グループ](create-customer-groups.md) (セグメントとフライト グループ) を作成、編集、および表示できます。       </td></tr>
<tr><td align="left">    **新しいアプリ**                            </td><td align="left">  新しいアプリの作成ページを表示できますが、実際にはアカウントに新しいアプリを作成することはできません。    </td><td align="left">  新しいアプリの名前を予約することで、アカウントで[新しいアプリを作成](create-your-app-by-reserving-a-name.md)できます。また、申請を作成してアプリをストアに提出できます。     </td></tr>
<tr><td align="left">    **新しいバンドル**&nbsp;*                       </td><td align="left">  新しいバンドルの作成ページを表示できますが、実際にはアカウントに新しいバンドルを作成することはできません。     </td><td align="left">  製品の新しいバンドルを作成できます。          </td></tr>
<tr><td align="left">    **パートナー サービス**&nbsp;*                  </td><td align="left">  XToken を取得するサービスをインストールするための証明書を表示できます。     </td><td align="left">  XToken を取得するサービスをインストールするための証明書の管理と表示ができます。       </td></tr>
<tr><td align="left">    **支払いアカウント**                      </td><td align="left">  **[アカウント設定]** に[支払いアカウントの情報](setting-up-your-payout-account-and-tax-forms.md#payout-account)を表示できます。     </td><td align="left">  **[アカウント設定]** で [支払いアカウントの情報](setting-up-your-payout-account-and-tax-forms.md#payout-account) の編集と表示ができます。       </td></tr>
<tr><td align="left">    **支払いの概要**                      </td><td align="left">  [支払いの概要](payout-summary.md)を表示して、支払いレポート情報にアクセスしてダウンロードできます。       </td><td align="left">  [支払いの概要](payout-summary.md)を表示して、支払いレポート情報にアクセスしてダウンロードできます。   </td></tr>
<tr><td align="left">    **証明書利用者**&nbsp;*                   </td><td align="left">  XToken を取得する証明書利用者を表示できます。    </td><td align="left">  XToken を取得する証明書利用者の管理と表示ができます。     </td></tr>
<tr><td align="left">    **サンドボックス**&nbsp;*                         </td><td align="left">  **サンドボックス** ページにアクセスして、アカウント内のサンドボックスとそれらのサンドボックスに適用可能なすべての構成を表示できます。 適切な製品レベルのアクセス許可が付与されている場合を除き、サンドボックスごとに製品と申請を表示することはできません。 </td><td align="left">  **サンドボックス** ページにアクセスして、サンドボックスの作成と削除、およびサンドボックスの構成の管理など、アカウントでサンドボックスを表示して管理できます。 適切な製品レベルのアクセス許可が付与されている場合を除き、サンドボックスごとに製品と申請を表示することはできません。    </td></tr>
<tr><td align="left">    **税プロファイル**                         </td><td align="left">  **[アカウント設定]** に[税プロファイルの情報とフォーム](setting-up-your-payout-account-and-tax-forms.md#tax-forms)を表示できます。     </td><td align="left">  **[アカウント設定]** で税フォームに入力して、[税プロファイル情報](setting-up-your-payout-account-and-tax-forms.md#tax-forms)を更新できます。     </td></tr>
<tr><td align="left">    **テスト アカウント**&nbsp;*                     </td><td align="left">  Xbox Live の構成をテストするためのアカウントを表示できます。      </td><td align="left">  Xbox Live の構成をテストするためのアカウントを作成、管理、および表示できます。      </td></tr>
<tr><td align="left">    **Xbox デバイス**                        </td><td align="left">  **[アカウント設定]** セクションでアカウントに対して有効にされている Xbox 開発コンソールを表示できます。       </td><td align="left">  **[アカウント設定]** セクションでアカウントに対して有効にされている Xbox 開発コンソールを追加、削除、および表示できます。     </td></tr>
    </tbody>
    </table>

\* アスタリスク (*) でマークされているアクセス許可は、一部のアカウントで利用できない機能にアクセス権を付与します。 これらの機能に対してアカウントが有効になっていない場合は、これらのアクセス許可の選択内容には一切影響はありません。   

## <a name="product-level-permissions"></a>製品レベルのアクセス許可

このセクションのアクセス許可は、アカウント内のすべての製品に付与するか、または 1 つ以上の特定の製品に対してのみアクセス許可を付与するようにカスタマイズできます。 これらのアクセス許可は 4 つのカテゴリにグループ分けされます: **分析**、**収益化**、**公開**、および **Xbox Live**。 各カテゴリを展開して、カテゴリごとに個々のアクセス許可を表示できます。 

アカウント内のすべての製品にアクセス許可を付与するには、**[すべての製品]** とマークされている行でアクセス許可 (**読み取り専用**、**読み取り/書き込み**、または**アクセス権なし**) を選択します。 
 
> **ヒント:** **[すべての製品]** に対する選択内容は、現在アカウント内にあるすべての製品だけでなく、アカウント内で作成される将来の製品にも適用されます。

**[すべての製品]** 行の下に、別の行に記載されているアカウントに各製品が表示されます。 特定の製品にのみアクセス許可を付与するには、該当する製品の行でアクセス許可を選択します。

各アドオンは、親製品の下で個々の行と **[すべてのアドオン]** 行に一覧表示されます。 **[すべてのアドオン]** に対する選択内容は、その製品に対するすべての現在のアドオンだけでなく、その製品用に作成される将来のアドオンにも適用されます。

アドオンに対して設定できないアクセス許可もありますので注意してください。 これは、アクセス許可がアドオン (**カスタマー フィードバック** アクセス許可など) に適用されない、または親製品レベルで付与されたアクセス許可がその製品のすべてのアドオン (**プロモーション コード**など) に適用されるためです。 ただし、アドオンに対して適用可能なすべてのアクセス許可は個別に設定する必要があることに注意してください。アドオンは親製品に対する選択内容を継承しません。 たとえば、ユーザーがアドオンの価格と使用可能状況をを選択できるようにする場合、親製品に **[価格と使用可能状況]** アクセス許可を付与しているかどうかに関係なく、アドオン (または **[すべてのアドオン]**) に対して **[価格と使用可能状況]** アクセス許可を有効にする必要があります。 

### <a name="analytics"></a>分析

<table>
    <thead>
    <tr class="header">
    <th align="left">アクセス許可名&nbsp;</th>
    <th align="left">読み取り専用&nbsp;</th>
    <th align="left">読み取り/書き込み</th>
    <th align="left">読み取り専用&nbsp;(アドオン)&nbsp; </th>
    <th align="left">読み取り/書き込み&nbsp;(アドオン)</th>
    </tr>
    </thead>
    <tbody>
    <tr><td align="left">    **取得**     </td><td>    製品の[取得](acquisitions-report.md)レポートと[アドオンの取得](add-on-acquisitions-report.md)レポートを表示できます。        </td><td>    該当なし    </td><td>    該当なし (親製品の設定には、アドオンの取得レポートが含まれます)        </td><td>    該当なし                         </td></tr>
    <tr><td align="left">    **利用状況** </td><td>    製品の[利用状況レポート](usage-report.md)を表示できます。     </td><td>    該当なし       </td><td>    該当なし     </td><td>    該当なし         </td></tr>
    <tr><td align="left">    **正常性** </td><td>    製品の[正常性レポート](health-report.md)を表示できます。    </td><td>    該当なし     </td><td>    該当なし     </td><td>    該当なし         </td></tr>
    <tr><td align="left">    **カスタマー フィードバック**    </td><td>    製品の[評価](ratings-report.md)、[レビュー](reviews-report.md)、および[フィードバック](feedback-report.md) レポートを表示できます。       </td><td>    該当なし (フィードバックやレビューに返信するには、**[顧客への連絡]** アクセス許可を付与する必要があります)   </td><td>    該当なし     </td><td>    該当なし         </td></tr>
    <tr><td align="left">    **Xbox 分析** </td><td>    製品の Xbox 分析レポートを表示できます。 (注: このレポートはまだ利用できません。)    </td><td>    該当なし   </td><td>    該当なし       </td><td>    該当なし          </td></tr>
    <tr><td align="left">    **リアルタイム**   </td><td>    製品のリアルタイム レポートを表示できます。       </td><td>    該当なし   </td><td>    該当なし     </td><td>    該当なし                 </td></tr>
    </tbody>
    </table>

### <a name="monetization"></a>収益化

<table>
    <thead>
    <tr class="header">
    <th align="left">アクセス許可名&nbsp;</th>
    <th align="left">読み取り専用&nbsp;</th>
    <th align="left">読み取り/書き込み</th>
    <th align="left">読み取り専用&nbsp;(アドオン)&nbsp; </th>
    <th align="left">読み取り/書き込み&nbsp;(アドオン)</th>
    </tr>
    </thead>
    <tbody>
    <tr><td align="left">    **顧客への連絡**  </td><td>    **カスタマー フィードバック** アクセス許可も付与されている限り、[カスタマー フィードバックへの返信](respond-to-customer-feedback.md)と[カスタマー レビューへの返信](respond-to-customer-reviews.md)を表示できます。 製品に対して作成された[ターゲット通知](send-push-notifications-to-your-apps-customers.md)も表示できます。    </td><td>    **カスタマー フィードバック** アクセス許可も付与されている限り、[カスタマー フィードバックへの返信](respond-to-customer-feedback.md)と[カスタマー レビューへの返信](respond-to-customer-reviews.md)ができます。 製品に対する[ターゲット通知の作成と送信](send-push-notifications-to-your-apps-customers.md)もできます。                   </td><td>    該当なし         </td><td>    該当なし                          </td></tr>
    <tr><td align="left">    **実験**</td><td>    製品の[実験 (A/Bテスト)](../monetize/run-app-experiments-with-a-b-testing.md)と実験データを表示できます。   </td><td>    製品の[実験 (A/B テスト)](../monetize/run-app-experiments-with-a-b-testing.md) の作成、管理、および表示と、実験データの表示ができます。     </td><td>    該当なし  </td><td>    該当なし                 </td></tr>
    <tr><td align="left">    **プロモーション コード**     </td><td>    製品とそのアドオンの[プロモーション コード](generate-promotional-codes.md)の注文と利用状況の情報、また利用状況情報を表示できます。         </td><td>    製品とそのアドオンの[プロモーション コード](generate-promotional-codes.md)の注文の表示、管理、および作成、また利用状況情報の表示ができます。          </td><td>    該当なし (すべてのアドオンに親製品の設定が適用されます)     </td><td>    該当なし (すべてのアドオンに親製品の設定が適用されます)     </td></tr>
    </tbody>
    </table>

### <a name="publishing"></a>公開 

<table>
    <thead>
    <tr class="header">
    <th align="left">アクセス許可名&nbsp;</th>
    <th align="left">読み取り専用&nbsp;</th>
    <th align="left">読み取り/書き込み</th>
    <th align="left">読み取り専用&nbsp;(アドオン)&nbsp; </th>
    <th align="left">読み取り/書き込み&nbsp;(アドオン)</th>
    </tr>
    </thead>
    <tbody>
    <tr><td align="left">    **価格と使用可能状況**  </td><td>    製品申請の[価格と使用可能状況](set-app-pricing-and-availability.md)ページを表示できます。     </td><td>    製品申請の[価格と使用可能状況](set-app-pricing-and-availability.md)ページの表示と編集ができます。 </td><td>    アドオン申請の[価格と使用可能状況](set-add-on-pricing-and-availability.md)ページを表示できます。   </td><td>    アドオン申請の[価格と使用可能状況](set-add-on-pricing-and-availability.md)ページの表示と編集ができます。          </td></tr>
    <tr><td align="left">    **プロパティ**   </td><td>    製品申請の[プロパティ](enter-app-properties.md) ページを表示できます。      </td><td>    製品申請の[プロパティ](enter-app-properties.md) ページの表示と編集ができます。       </td><td>    アドオン申請の[プロパティ](enter-add-on-properties.md) ページを表示できます。     </td><td>    アドオン申請の[プロパティ](enter-add-on-properties.md) ページの表示と編集ができます。               </td></tr>
    <tr><td align="left">    **年齢区分**    </td><td>    製品申請の[年齢区分](age-ratings.md)ページを表示できます。       </td><td>    製品申請の [年齢区分](age-ratings.md) ページの表示と編集ができます。    </td><td>    * アドオン申請の年齢区分ページを表示できます。          </td><td>    * アドオン申請の年齢区分ページの表示と編集ができます。       </td></tr>
    <tr><td align="left">    **パッケージ**        </td><td>    製品申請の[パッケージ](upload-app-packages.md)ページを表示できます。  </td><td>    パッケージのアップロードなど、製品申請の[パッケージ](upload-app-packages.md)ページの表示と編集ができます。     </td><td>    * アドオン申請のデバイス ファミリのターゲット設定とパッケージを表示できます (該当する場合)。   </td><td>    * パッケージのアップロードなど、アドオン申請のデバイス ファミリのターゲット設定の表示と編集ができます (該当する場合)。             </td></tr>
    <tr><td align="left">    **ストア登録情報**  </td><td>    製品申請の[ストア登録情報ページ](create-app-store-listings.md)を表示できます。  </td><td>    製品申請の[ストア登録情報ページ](create-app-store-listings.md)の表示と編集と、さまざまな言語に対して新しいストア登録情報の追加ができます。     </td><td>    アドオン申請の[ストア登録情報ページ](create-add-on-store-listings.md)を表示できます。            </td><td>    アドイン申請の[ストア登録情報ページ](create-add-on-store-listings.md)の表示と編集と、さまざまな言語に対してストア登録情報の追加ができます。                 </td></tr>
    <tr><td align="left">    **ストアへの申請**     </td><td>    このアクセス許可が読み取り専用に設定されている場合は、アクセスは一切付与されません。           </td><td>    ストアに製品を提出して、証明レポートを表示できます。 新規および更新済みの両方の申請が含まれます。 </td><td>このアクセス許可が読み取り専用に設定されている場合は、アクセスは一切付与されません。     </td><td>    ストアにアドオンを提出して、証明レポートを表示できます。 新規および更新済みの両方の申請が含まれます。</td></tr>
    <tr><td align="left">    **新しい申請の作成**       </td><td>    このアクセス許可が読み取り専用に設定されている場合は、アクセスは一切付与されません。        </td><td>    製品の新しい[申請](app-submissions.md)を作成できます。  </td><td>    このアクセス許可が読み取り専用に設定されている場合は、アクセスは一切付与されません。   </td><td>    アドオンの新しい[申請](add-on-submissions.md)を作成できます。        </td></tr>
    <tr><td align="left">    **新しいアドオン**    </td><td>    このアクセス許可が読み取り専用に設定されている場合は、アクセスは一切付与されません。 </td><td>    製品の[新しいアドオンを作成](set-your-add-on-product-id.md)できます。 </td><td>    該当なし    </td><td>    該当なし        </td></tr>
    <tr><td align="left">    **名前の予約**   </td><td>    製品の[アプリ名の管理](manage-app-names.md)ページを表示できます。</td><td>    追加の名前の予約や予約済みの名前の削除など、製品の[アプリ名の管理](manage-app-names.md)ページの表示と編集ができます。 </td><td>   * アドオンの予約済みの名前を表示できます。    </td><td>   * アドオンの予約済みの名前の表示と編集ができます。          </td></tr>
    </tbody>
    </table>

### <a name="xbox-live-"></a>Xbox Live \*

<table>
    <thead>
    <tr class="header">
    <th align="left">アクセス許可名&nbsp;</th>
    <th align="left">読み取り専用&nbsp;</th>
    <th align="left">読み取り/書き込み</th>
    <th align="left">読み取り専用&nbsp;(アドオン)&nbsp; </th>
    <th align="left">読み取り/書き込み&nbsp;(アドオン)</th>
    </tr>
    </thead>
    <tbody>
    <tr><td align="left">    **Xbox サービス構成**&nbsp;\*    </td><td>    製品の実績、マルチプレーヤー、ランキング、および他の Xbox Live の構成に関連する設定を表示できます。  </td><td>    製品の実績、マルチプレーヤー、ランキング、および他の Xbox Live の構成に関連する設定の表示と編集ができます。  </td><td>    該当なし     </td><td>    該当なし                      </td></tr>
    <tr><td align="left">    **アプリ チャンネル**&nbsp;\*</td><td>    該当なし  </td><td>    OneGuide を通じて表示するために、Xbox コンソールにプロモーション用のビデオ チャンネルを公開できます。  </td><td>  該当なし </td><td> 該当なし </td></tr>
</tbody>
</table>

\* アスタリスク (*) でマークされているアクセス許可は、一部のアカウントで利用できない機能にアクセス権を付与します。 これらの機能に対してアカウントが有効になっていない場合は、これらのアクセス許可の選択内容には一切影響はありません。  

