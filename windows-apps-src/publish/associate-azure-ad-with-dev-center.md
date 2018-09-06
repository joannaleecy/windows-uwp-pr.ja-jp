---
author: jnHs
Description: In order to add and manage account users, you must first associate your Dev Center account with your organization's Azure Active Directory.
title: Azure Active Directory とデベロッパー センター アカウントとの関連付け
ms.author: wdg-dev-content
ms.date: 08/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント
ms.localizationpriority: medium
ms.openlocfilehash: dd729d76705849c981516109da39bbd27c140286
ms.sourcegitcommit: 914b38559852aaefe7e9468f6f53a7465bf36e30
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3398464"
---
# <a name="associate-azure-active-directory-with-your-dev-center-account"></a>Azure Active Directory とデベロッパー センター アカウントとの関連付け

[アカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。 

Windows デベロッパー センターでは、複数のユーザー アカウントのアクセスと管理に Azure AD を利用します。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、デベロッパー センター内から新しい Azure AD テナントを追加料金なしで作成できます。

> [!TIP]
> このトピックは Windows アプリ開発者プログラムに固有の内容ですが、テナントの関連付けとユーザーの管理は Windows デスクトップ アプリケーション プログラム (詳しくは「[Windows デスクトップ アプリケーション プログラム](https://docs.microsoft.com/windows/desktop/appxpkg/windows-desktop-application-program#add-and-manage-account-users)」を参照) のアカウントでも Windows ハードウェア開発者プログラム (**マネージャー** ロールという記述は、**管理者**ロールのハードウェア アカウントにも適用されます。詳しくは「[ダッシュボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)」を参照) のアカウントでも同様に機能します。

1 つの Azure AD テナントを複数のデベロッパー センター アカウントに関連付けることもできます。 複数のアカウント ユーザーを追加には 1 つの Azure AD テナントをデベロッパー センター アカウントに関連付けるだけでかまいませんが、複数の Azure AD テナントを 1 つのデベロッパー センター アカウントに追加することもできます。 デベロッパー センター アカウントで**マネージャー** ロールを持つすべてのユーザーは、Azure AD テナントの追加と削除を行うことができます。

> [!IMPORTANT]
> デベロッパー センター アカウントを Azure AD テナントと関連付けた後、そのテナントでアカウント ユーザーを追加および管理するには、**マネージャー** ロールを持つ同じテナントのユーザーとしてデベロッパー センターにサインインする必要があります。


## <a name="associate-your-dev-center-account-with-your-organizations-existing-azure-ad-tenant"></a>デベロッパー センター アカウントと組織の既存の Azure AD テナントを関連付ける

組織で既に Azure AD が使用されている場合は、次の手順に従ってデベロッパー センター アカウントをリンクします。

1.  [Windows デベロッパー センター ダッシュ ボード](https://partner.microsoft.com/dashboard)では、(ダッシュ ボードの上部の右上隅) 近くにある歯車アイコンを選択し、[**アカウント設定**] を選択します。 [**設定**] メニューで、**テナント**を選択します。
2.  **[Azure AD と デベロッパー センター アカウントの関連付け]** を選びます。
3.  関連付けるテナントの Azure AD 資格情報を入力します。
4.  Azure AD テナントの組織とドメイン名を確認します。 関連付けを完了するには、**[確認]** を選びます。
5.  関連付けができたら、デベロッパー センターの **[ユーザー]** ページで、いつでもアカウント ユーザーを追加して管理することができます。

> [!IMPORTANT]
> 新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](https://docs.microsoft.com/azure/active-directory/users-groups-roles/directory-assign-admin-roles)を持つアカウントを使ってその Azure AD にサインインする必要があります。 ただし、テナントを関連付けたり、そのテナントに既に存在しているユーザーをデベロッパー センター アカウントに追加したりする場合、グローバル管理者のアクセス許可は必要ありません。


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account"></a>デベロッパー センター アカウントに関連付ける新しい Azure AD を作成する

デベロッパー センター アカウントをリンクする Azure AD を準備する必要がある場合は、次の手順に従います。

1.  [Windows デベロッパー センター ダッシュ ボード](https://partner.microsoft.com/dashboard)では、(ダッシュ ボードの上部の右上隅) 近くにある歯車アイコンを選択し、[**アカウント設定**] を選択します。 [**設定**] メニューで、**テナント**を選択します。
2.  **[新しい Azure AD の作成]** を選びます。
3.  新しい Azure AD のディレクトリ情報を入力します。
    - **[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。 たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。
    - **[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。
    - **[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。
4.  **[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。
5.  新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。


## <a name="manage-azure-ad-tenant-associations"></a>Azure AD テナントの関連付けの管理

Azure AD テナントをデベロッパー センター アカウントに関連付けると、新しいテナントを追加したり、**[テナント]** ページから既存のテナントを削除したりすることができます。


### <a name="add-multiple-azure-ad-tenants-to-your-dev-center-account"></a>デベロッパー センター アカウントへの複数の Azure AD テナントの追加

デベロッパー センター アカウントの**マネージャー** ロールを持つユーザーは、Azure AD テナントをアカウントに関連付けることができます。

新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。 関連付ける Azure AD テナントの資格情報が求められる点に注意してください。


### <a name="remove-an-azure-ad-tenant-from-your-dev-center-account"></a>デベロッパー センター アカウントからの Azure AD テナントの削除

デベロッパー センター アカウントの**マネージャー** ロールを持つユーザーは、Azure AD テナントをアカウントから削除することができます。

> [!IMPORTANT]
> テナントを削除すると、そのテナントからデベロッパー センター アカウントに追加されたすべてのユーザーはアカウントにサインインできなくなります。 

テナントを削除するには、(**アカウントの設定**) で、[**テナント**] ページでその名前を検索し、**削除**を選択します。 テナントの削除を確認するメッセージが表示されます。 これを行うと、そのテナント内のどのデベロッパー センター ユーザーもデベロッパー センター アカウントにログインできなくなり、それらのユーザー用に構成したすべてのアクセス許可が削除されます。

> [!TIP]
> 現在、同じテナントのアカウントを使ってデベロッパー センターにサインインしている場合、テナントを削除することはできません。 テナントを削除するには、アカウントに関連付けられた別のテナントの**マネージャー**としてデベロッパー センターにサインインする必要があります。 アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。


