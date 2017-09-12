---
author: jnHs
Description: "アカウント ユーザーを追加および管理するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。"
title: "Azure Active Directory とデベロッパー センター アカウントとの関連付け"
ms.author: wdg-dev-content
ms.date: 07/17/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: ace9470cc707206461baa8c3dd72828ea68a8eb4
ms.sourcegitcommit: eaacc472317eef343b764d17e57ef24389dd1cc3
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/17/2017
---
# <a name="associate-azure-active-directory-with-your-dev-center-account"></a>Azure Active Directory とデベロッパー センター アカウントとの関連付け

[アカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)するには、まずデベロッパー センター アカウントを組織の Azure Active Directory に関連付けます。 

Windows デベロッパー センターでは、複数のユーザーの管理と役割の割り当てに Azure AD を利用します。 組織で Office 365 または Microsoft の他のビジネス サービスが既に使用されている場合は、既に Azure AD をお持ちです。 それ以外の場合は、デベロッパー センター内から新しい Azure AD テナントを追加料金なしで作成できます。

> [!IMPORTANT]
> Azure AD とデベロッパー センター アカウントを関連付けるには、Azure AD テナントに[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)アカウントでサインインする必要があります。
> 
> アカウント ユーザーを追加および管理するには、デベロッパー センター アカウントを Azure AD に関連付けた後、必ず Azure AD グローバル管理者アカウント (個人の Microsoft アカウントではありません) を使ってデベロッパー センターにサインインする必要があります。

Azure AD テナントに関連付けることができるデベロッパー センター アカウントは 1 つのみであることに注意してください。 同様に、デベロッパー センター アカウントに関連付けることができる Azure AD テナントは 1 つのみです。 一度関連付けを確立すると、関連付けを解除するには、必ずサポートへの問い合わせが必要になります。


## <a name="associate-your-dev-center-account-with-your-organizations-existing-azure-ad-tenant"></a>デベロッパー センター アカウントと組織の既存の Azure AD テナントを関連付ける

組織で既に Azure AD が使用されている場合は、次の手順に従ってデベロッパー センター アカウントをリンクします。

1.  **[アカウント設定]** に移動して、**[ユーザーの管理]** をクリックします。
2.  **[Azure AD をデベロッパー センター アカウントに関連付ける]** ボタンをクリックします。
3.  Azure AD アカウントにサインインします。 関連付けを設定するには、このアカウントに[全体管理者](http://go.microsoft.com/fwlink/?LinkId=746654)のアクセス許可が割り当てらレ低流必要があります。
4.  Azure AD テナントの組織とドメイン名を確認します。 関連付けを完了するには、**[確認]** をクリックします。
5.  関連付けができたら、デベロッパー センターの **[ユーザーの管理]** ページで、いつでもアカウント ユーザーを追加して管理することができます。


## <a name="create-a-brand-new-azure-ad-to-associate-with-your-dev-center-account"></a>デベロッパー センター アカウントに関連付ける新しい Azure AD を作成する

デベロッパー センター アカウントをリンクする Azure AD を準備する必要がある場合は、次の手順に従います。

1.  **[アカウント設定]** に移動して、**[ユーザーの管理]** をクリックします。
2.  **[新しい Azure AD の作成]** ボタンをクリックします。
3.  新しい Azure AD のディレクトリ情報を入力します。
 - **[ドメイン名]**: ".onmicrosoft.com" との組み合わせで Azure AD ドメインを示す一意の名前。 たとえば、「example」と入力した場合、Azure AD ドメインは "example.onmicrosoft.com" になります。
 - **[連絡先の電子メール]**: アカウントに関して連絡が必要になったときに連絡可能なメール アドレス。
 - **[全体管理者のユーザー アカウント]**: 新しい全体管理者アカウントに使用する名、姓、ユーザー名、およびパスワード。
4.  **[作成]** をクリックして、新しいドメインとアカウントの情報を確定します。
5.  新しい Azure AD 全体管理者のユーザー名とパスワードでサインインすると、[追加のアカウント ユーザーを追加および管理](add-users-groups-and-azure-ad-applications.md)を開始できます。



