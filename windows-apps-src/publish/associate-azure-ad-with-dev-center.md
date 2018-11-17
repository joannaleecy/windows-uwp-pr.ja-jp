---
author: jnHs
Description: In order to add and manage account users, you must first associate your Partner Center account with your organization's Azure Active Directory.
title: パートナー センターのアカウントを Azure Active Directory を関連付ける
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: medium
ms.openlocfilehash: 9f44d5bc0e07ab40a396c103d2a8ba6db5427ae8
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7149632"
---
# <a name="associate-azure-active-directory-with-your-partner-center-account"></a>パートナー センターのアカウントを Azure Active Directory を関連付ける

アカウント ユーザーを[追加および管理](add-users-groups-and-azure-ad-applications.md)の順序で、組織の Azure Active Directory で最初に、パートナー センター アカウントを関連付ける必要があります。 

[パートナー センター](https://partner.microsoft.com/dashboard)では、複数のユーザー アカウントのアクセスや管理に Azure AD を活用します。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合、作成、新しい Azure AD テナントからパートナー センター内で追加料金なし。

> [!TIP]
> このトピックでは、[パートナー センター](https://partner.microsoft.com/dashboard)では、Windows アプリ開発者プログラムに固有ですが、テナントの関連付けとユーザーの管理は同様に Windows デスクトップ アプリケーション プログラムでのアカウント ( [Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)を参照してください。詳しくは) と Windows ハードウェア開発者プログラム (**マネージャー**の役割への参照も**管理者**ロールを持つハードウェア アカウントに適用されます。 詳しくは、[ダッシュ ボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)を参照してください)。

1 つの Azure AD テナントを複数のパートナー センター アカウントに関連付けることができます。 複数のアカウント ユーザーを追加するために、パートナー センター アカウントに関連付けられている 1 つの Azure AD テナントにのみ必要がありますが、1 つのパートナー センター アカウントに複数の Azure AD テナントを追加するオプションもあります。 します。 パートナー センター アカウントに**マネージャー**の役割を持つすべてのユーザーを追加し、アカウントから Azure AD テナントを削除するオプションとなります。

> [!IMPORTANT]
> パートナー センターのアカウントを Azure AD テナントに関連付けることを追加し、そのテナントでアカウント ユーザーを管理するためにする必要があります**マネージャー**の役割を持つ同じテナントのユーザーとしてパートナー センターにサインインします。


## <a name="associate-your-partner-center-account-with-your-organizations-existing-azure-ad-tenant"></a>パートナー センターのアカウントを組織の既存の Azure AD テナントに関連付ける

既に組織では、Azure AD を使用する場合は、パートナー センター アカウントにリンクする次の手順に従います。

1.  [パートナー センター](https://partner.microsoft.com/dashboard)では、(右上隅のダッシュ ボードの) 近くにある歯車アイコンを選択し、**開発者の設定**を選択します。 **Settings** ] メニューでは、**テナント**を選択します。
2.  **Azure AD をパートナー センター アカウントの関連付け**を選択します。
3.  関連付けるテナントの Azure AD 資格情報を入力します。
4.  Azure AD テナントの組織とドメイン名を確認します。 関連付けを完了するには、**[確認]** を選びます。
5.  関連付けが成功した場合は、ことができます追加し、パートナー センターで**ユーザー**のセクションでアカウント ユーザーの管理を準備します。

> [!IMPORTANT]
> 新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles)を持つアカウントを使ってその Azure AD にサインインする必要があります。 ただし、パートナー センター アカウントにテナントに既に存在しているユーザーを追加するか、テナントを関連付けたり、グローバル管理者のアクセス許可を必要はありません。


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-partner-center-account"></a>パートナー センター アカウントに関連付ける新しい Azure AD を作成します。

パートナー センター アカウントをリンクする新しい Azure AD を設定する必要がある場合は次の手順に従います。

1.  [パートナー センター](https://partner.microsoft.com/dashboard)では、(右上隅のダッシュ ボードの) 近くにある歯車アイコンを選択し、**開発者の設定**を選択します。 **Settings** ] メニューでは、**テナント**を選択します。
2.  **[新しい Azure AD の作成]** を選びます。
3.  新しい Azure AD のディレクトリ情報を入力します。
    - **[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。 たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。
    - **[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。
    - **[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。
4.  **[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。
5.  新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。


## <a name="manage-azure-ad-tenant-associations"></a>Azure AD テナントの関連付けの管理

Azure AD テナントは、パートナー センター アカウントに関連付けられているが後、は、新しいテナントを追加または**テナント**ページから既存のテナントを削除できます。


### <a name="add-multiple-azure-ad-tenants-to-your-partner-center-account"></a>パートナー センター アカウントに複数の Azure AD テナントを追加します。

パートナー センターのアカウント**マネージャー**の役割を持つユーザーは、Azure AD テナントをアカウントに関連付けることができます。

新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。 関連付ける Azure AD テナントの資格情報が求められる点に注意してください。


### <a name="remove-an-azure-ad-tenant-from-your-partner-center-account"></a>パートナー センター アカウントから Azure AD テナントを削除します。

パートナー センターのアカウント**マネージャー**の役割を持つユーザーは、アカウントから Azure AD テナントを削除することができます。

> [!IMPORTANT]
> テナントを削除すると、そのテナントからパートナー センター アカウントに追加されたすべてのユーザーができなくアカウントにサインインします。 

テナントを削除するには、[**テナント**] ページ (**アカウントの設定**) でその名前を検索し、**削除**を選択します。 テナントの削除を確認するメッセージが表示されます。 これを行うと、そのテナント内のユーザーは、パートナー センター アカウントにサインインできなくし、それらのユーザー用に構成したすべてのアクセス許可は削除されます。

> [!TIP]
> 現在サインインしているパートナー センターに同じテナントのアカウントを使っている場合は、テナントを削除することはできません。 テナントを削除するには、必要がありますにサインインするパートナー センター**マネージャー**として別のテナントのアカウントに関連付けられています。 アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。


