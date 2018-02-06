---
author: jnHs
Description: In order to add and manage account users, you must first associate your Dev Center account with your organization's Azure Active Directory.
title: "Azure Active Directory とデベロッパー センター アカウントとの関連付け"
ms.author: wdg-dev-content
ms.date: 01/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "windows 10, uwp, azure ad, azure テナント, aad テナント, azure ad テナント, テナント管理, テナント"
ms.localizationpriority: high
ms.openlocfilehash: ef53a8b339f7f6444373d7445721b641926f00a3
ms.sourcegitcommit: 446fe2861651f51a129baa80791f565f81b4f317
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/12/2018
---
# <a name="associate-azure-active-directory-with-your-dev-center-account"></a>Azure Active Directory とデベロッパー センター アカウントとの関連付け

[アカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。 

Windows デベロッパー センターでは、複数のユーザー アカウントのアクセスと管理に Azure AD を利用します。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、デベロッパー センター内から新しい Azure AD テナントを追加料金なしで作成できます。

> [!TIP]
> このトピックは、Windows アプリ開発者プログラムに固有の内容ですが、テナントの関連付けとユーザーの管理は Windows ハードウェア開発者プログラムのアカウントでも同様に機能します。 このセクションでは、**マネージャー**の役割への言及は、**管理者**の役割を持つハードウェア アカウントにも適用されます。 ハードウェア開発者プログラムでのユーザー管理について詳しくは、「[ダッシュボードの管理](https://docs.microsoft.com/windows-hardware/drivers/dashboard/dashboard-administration)」をご覧ください。

1 つの Azure AD テナントを複数のデベロッパー センター アカウントに関連付けることができます。 複数のアカウント ユーザーを追加には 1 つの Azure AD テナントをデベロッパー センター アカウントに関連付けるだけでかまいませんが、複数の Azure AD テナントを 1 つのデベロッパー センター アカウントに追加することもできます。 デベロッパー センター アカウントで**マネージャー**の役割を持つすべてのユーザーは、Azure AD テナントの追加と削除を行うことができます。

> [!IMPORTANT]
> デベロッパー センター アカウントを Azure AD テナントと関連付けた後、そのテナントでアカウント ユーザーを追加および管理するには、**マネージャー**の役割を持つ同じテナントのユーザーとしてデベロッパー センターにサインインする必要があります。


## <a name="associate-your-dev-center-account-with-your-organizations-existing-azure-ad-tenant"></a>デベロッパー センター アカウントと組織の既存の Azure AD テナントを関連付ける

組織で既に Azure AD が使用されている場合は、次の手順に従ってデベロッパー センター アカウントをリンクします。

1.  **[アカウント設定]** に移動して、**[テナント]** をクリックします。
2.  **[Azure AD と デベロッパー センター アカウントの関連付け]** を選びます。
3.  関連付けるテナントの Azure AD 資格情報を入力します。
4.  Azure AD テナントの組織とドメイン名を確認します。 関連付けを完了するには、**[確認]** を選びます。
5.  関連付けができたら、デベロッパー センターの **[ユーザー]** ページで、いつでもアカウント ユーザーを追加して管理することができます。

> [!IMPORTANT]
> 新しいユーザーを作成したり、Azure AD に他の変更を加えたりするには、[グローバル管理者のアクセス許可](http://go.microsoft.com/fwlink/?LinkId=746654)を持つアカウントを使ってその Azure AD にサインインする必要があります。 ただし、テナントを関連付けたり、そのテナントに既に存在しているユーザーをデベロッパー センター アカウントに追加したりする場合、グローバル管理者のアクセス許可は必要ありません。


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account"></a>デベロッパー センター アカウントに関連付ける新しい Azure AD を作成する

デベロッパー センター アカウントをリンクする Azure AD を準備する必要がある場合は、次の手順に従います。

1.  **[アカウント設定]** に移動して、**[テナント]** をクリックします。
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

デベロッパー センター アカウントの**マネージャー**の役割を持つユーザーは、Azure AD テナントをアカウントに関連付けることができます。

新しいテナントを関連付けるには、**[別の Azure AD テナントの関連付け]** を選び、上記の手順に従います。 関連付ける Azure AD テナントの資格情報が求められる点に注意してください。


### <a name="remove-an-azure-ad-tenant-from-your-dev-center-account"></a>デベロッパー センター アカウントからの Azure AD テナントの削除

デベロッパー センター アカウントの**マネージャー**の役割を持つユーザーは、Azure AD テナントをアカウントから削除することができます。

> [!IMPORTANT]
> テナントを削除すると、そのテナントからデベロッパー センター アカウントに追加されたすべてのユーザーはアカウントにサインインできなくなります。 

テナントを削除するには、**[テナント]** ページでその名前を検索し、**[削除]** を選びます。 テナントの削除を確認するメッセージが表示されます。 これを行うと、そのテナント内のどのデベロッパー センター ユーザーもデベロッパー センター アカウントにログインできなくなり、それらのユーザー用に構成したすべてのアクセス許可が削除されます。

> [!TIP]
> 現在、同じテナントのアカウントを使ってデベロッパー センターにサインインしている場合、テナントを削除することはできません。 テナントを削除するには、アカウントに関連付けられた別のテナントの**マネージャー**としてデベロッパー センターにサインインする必要があります。 アカウントにテナントが 1 つだけ関連付けられている場合、アカウントを開いた Microsoft アカウントを使ってサインインした後のみそのテナントを削除できます。


