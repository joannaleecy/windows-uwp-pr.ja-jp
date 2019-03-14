---
Description: 追加し、アカウントのユーザーを管理するために、組織の Azure Active Directory で最初に、パートナー センター アカウントを関連付ける必要があります。
title: Azure Active Directory をパートナー センター アカウントに関連付ける
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: medium
ms.openlocfilehash: aacfdb0044fa9b9368ecbd032629ed5e572ece99
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605317"
---
# <a name="associate-azure-active-directory-with-your-partner-center-account"></a>Azure Active Directory をパートナー センター アカウントに関連付ける

[を追加し、アカウントのユーザーを管理する](add-users-groups-and-azure-ad-applications.md)、最初に、組織の Azure Active Directory で、パートナー センター アカウントを関連付ける必要があります。 

[パートナー センター](https://partner.microsoft.com/dashboard)マルチ ユーザー アカウントのアクセスと管理のために Azure AD を活用します。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合、作成、新しい Azure AD テナントからパートナー センター内で無料になります。

> [!TIP]
> このトピックでは、Windows アプリ開発者プログラムに特定されて[パートナー センター](https://partner.microsoft.com/dashboard)、Windows デスクトップ アプリケーションにアカウントのテナントに関連付けると、ユーザーの管理は同様に (を参照してください[Windowsデスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)詳細については) と、Windows ハードウェア開発者プログラム (場所への参照、 **Manager**ロールとハードウェアのアカウントにも適用、**管理者**ロール; を参照してください[ダッシュ ボード管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)の詳細)。

1 つの Azure AD テナントが複数のパートナー センター アカウントに関連付けることができます。 複数のアカウント ユーザーを追加するには、パートナー センター アカウントに関連付けられている 1 つの Azure AD テナントを設定するだけで済みますが、1 つのパートナー センター アカウントに複数の Azure AD テナントを追加するオプションもあります。 すべてのユーザーが、 **Manager**ロール、パートナー センター アカウントには追加し、アカウントから Azure AD テナントを削除することが可能です。

> [!IMPORTANT]
> パートナー センター アカウントを関連付けるには、Azure AD テナントと、追加し、そのテナント内のアカウント ユーザーを管理するためにする必要があります、同じテナントを持つユーザーとして、パートナー センターにサインインする、 **Manager**ロール。


## <a name="associate-your-partner-center-account-with-your-organizations-existing-azure-ad-tenant"></a>パートナー センター アカウントを組織の既存の Azure AD テナントに関連付ける

組織が既に Azure AD を使用する場合は、パートナー センター アカウントをリンクする次の手順に従います。

1.  [パートナー センター](https://partner.microsoft.com/dashboard)、ダッシュ ボードの上部の右下隅) の近くの歯車アイコンを選択し、**開発者設定が**します。 **設定**メニューの **テナント**します。
2.  選択**Azure AD に関連付けられた、パートナー センター アカウント**します。
3.  関連付けるテナントの Azure AD 資格情報を入力します。
4.  Azure AD テナントの組織とドメイン名を確認します。 関連付けを完了するには、**[確認]** を選びます。
5.  追加し、アカウントのユーザーを管理する準備ができます、アソシエーションが成功した場合、**ユーザー**パートナー センターの「します。

> [!IMPORTANT]
> 新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles)を持つアカウントを使ってその Azure AD にサインインする必要があります。 ただし、またはそのテナントで、パートナー センター アカウントに既に存在するユーザーを追加する、テナントを関連付けるためには、グローバル管理者のアクセス許可を必要はありません。


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account"></a>パートナー センター アカウントに関連付ける新しい Azure AD を作成します。

パートナー センター アカウントとリンクする新しい Azure AD を設定する必要がある場合は次の手順に従います。

1.  [パートナー センター](https://partner.microsoft.com/dashboard)、ダッシュ ボードの上部の右下隅) の近くの歯車アイコンを選択し、**開発者設定が**します。 **設定**メニューの **テナント**します。
2.  **[新しい Azure AD の作成]** を選びます。
3.  新しい Azure AD のディレクトリ情報を入力します。
    - **ドメイン名**:と共に、Azure AD ドメインを使用する一意の名前". onmicrosoft.com"。 たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。
    - **連絡先の電子メール**:電子メール アドレスをお送りするため、アカウントに関する必要な場合。
    - **グローバル管理者ユーザー アカウント情報**:名、姓、ユーザー名、および新しいのグローバル管理者アカウントを使用するパスワード。
4.  **[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。
5.  新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。


## <a name="manage-azure-ad-tenant-associations"></a>Azure AD テナントの関連付けの管理

パートナー センター アカウントと Azure AD テナントを関連付けた後は、新しいテナントを追加または既存のテナントからの削除、**テナント**ページ。


### <a name="add-multiple-azure-ad-tenants-to-your-partner-center-account"></a>パートナー センター アカウントに複数の Azure AD テナントを追加します。

あるユーザーに対して、 **Manager**パートナー センター アカウントのロールは、アカウントを使用して Azure AD テナントを関連付けることができます。

新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。 関連付ける Azure AD テナントの資格情報が求められる点に注意してください。


### <a name="remove-an-azure-ad-tenant-from-your-partner-center-account"></a>パートナー センター アカウントから Azure AD テナントを削除します。

あるユーザーに対して、 **Manager**パートナー センター アカウントのロールは、アカウントからの Azure AD テナントを削除することができます。

> [!IMPORTANT]
> テナントを削除すると、パートナー センター アカウントにそのテナントから追加されたすべてのユーザーは、アカウントにサインインすることできなきます。 

テナントを削除するには、上の名前を検索、**テナント**ページ (で**アカウント設定**) を選択し、**削除**します。 テナントの削除を確認するメッセージが表示されます。 そうと、パートナー センター アカウントにサインインすることはそのテナント内のユーザーはありませんし、それらのユーザー用に構成したすべてのアクセス許可は削除されます。

> [!TIP]
> 現在にサインインするパートナー センター アカウントを使用して、同じテナント内の場合は、テナントを削除できません。 テナントを削除するにはパートナー センターにサインインする必要があります、 **Manager**アカウントに関連付けられている別のテナント。 アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。


