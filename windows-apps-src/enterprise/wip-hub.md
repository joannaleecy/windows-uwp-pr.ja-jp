---
author: normesta
Description: This is a hub topic covering the full developer picture of how Windows Information Protection (WIP) relates to files, buffers, clipboard, networking, background tasks, and data protection under lock.
MS-HAID: dev\_enterprise.edp\_hub
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: Windows 情報保護 (WIP)
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, Windows 情報保護, 企業データ, エンタープライズ データ保護, EDP, 対応アプリ
ms.assetid: 08f0cfad-f15d-46f7-ae7c-824a8b1c44ea
ms.localizationpriority: medium
ms.openlocfilehash: dec05e663e6ca7390dc3974b8a3cde2971b50426
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5640925"
---
# <a name="windows-information-protection-wip"></a>Windows 情報保護 (WIP)

__注__ Windows 情報保護 (WIP) ポリシーは、Windows 10 Version 1607 に適用することができます。

WIP では、組織で定義されているポリシーを適用することによって、組織に属しているデータを保護します。 アプリがこれらのポリシーに含まれている場合、アプリによって生成されたすべてのデータにはポリシーの制限が適用されます。 このトピックは、ユーザーの個人データに影響を与えずに、これらのポリシーをより適切に適用するアプリを作成する際に役立ちます。
<iframe src="https://channel9.msdn.com/Blogs/Windows-Development-for-the-Enterprise/Securing-Enterprise-Data-with-Windows-Information-Protection/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

## <a name="first-what-is-wip"></a>WIP とは

WIP とは、組織のモバイル デバイス管理 (MDM) およびモバイル アプリケーション管理 (MAM) システムをサポートするデスクトップ、ノート PC、タブレット、および電話で使用できる一連の機能です。

WIP と MDM により、組織は、組織で管理しているデバイスでのデータの処理方法をより細かく制御できます。 ユーザーは、仕事で使用しているデバイスを組織の MDM に登録しないことがあります。  この場合、組織は MAM を利用することで、ユーザーのデバイスにインストールされた特定の基幹業務アプリ上でのデータの処理方法を詳細に制御できるようになります。

MDM または MAM を利用すると、管理者は、組織に属しているファイルにアクセスできるアプリを特定したり、ユーザーがそれらのファイルからデータをコピーし、個人用のドキュメントに貼り付けることができるかどうかを指定したりすることができます。

しくみは次のとおりです。 ユーザーは、組織のモバイル デバイス管理 (MDM) システムにデバイスを登録します。 管理側の組織の管理者は、Microsoft Intune や System Center Configuration Manager (SCCM) を使用して、ポリシーを定義し、登録されているデバイスにポリシーを展開します。

ユーザーがデバイスを登録する必要がない場合、管理者は MAM システムを使って特定のアプリに適用するポリシーを定義および展開することになります。 ユーザーは、MAM 対象のいずれかのアプリをインストールした際に、関連のあるポリシーを受け取ることになります。

そのポリシーでは、企業データにアクセスできるアプリを指定します (ポリシーの*許可リスト*と呼ばれます)。 これらのアプリは、企業の保護されたファイル、仮想プライベート ネットワーク (VPN)、クリップボードにある企業データにアクセスできます。また、共有コントラクトを使用して、企業データにアクセスすることもできます。 ポリシーでは、データを管理する規則も定義します。 たとえば、企業が所有するファイルからデータをコピーして、企業以外の者が所有するファイルに貼り付けることができるかどうかなどを制御します。

ユーザーが組織の MDM システムからデバイスを登録解除した場合や、組織の MAM システムで指定されているアプリをアンインストールした場合、管理者はそのデバイスの企業データをリモートでワイプできます。

![WIP のライフサイクル](images/wip-lifecycle.png)

> **WIP について詳しくは、以下をご覧ください。** <br>
* [Introducing Windows Information Protection (Windows 情報保護の概要)](https://blogs.technet.microsoft.com/windowsitpro/2016/06/29/introducing-windows-information-protection/)
* [Windows 情報保護 (WIP) を使用した企業データの保護](https://technet.microsoft.com/library/dn985838(v=vs.85).aspx)

アプリが許可リストに登録されている場合、アプリによって生成されたすべてのデータにはポリシーの制限が適用されます。 つまり、管理者が企業データへのユーザー アクセスを無効にすると、それらのユーザーは、アプリによって生成されたすべてのデータへアクセスできなくなります。

これは、アプリが企業での使用のみを目的として設計されている場合は、問題ありません。 ただし、ユーザーが個人用のデータであると見なすことができるデータをアプリが生成する場合は、企業データと個人データをインテリジェントに区別するようにアプリを*対応させる*必要があります。 この種類のアプリは、"*エンタープライズ対応*" と呼ばれます。それは、ユーザーの個人データの整合性を維持したまま、企業のポリシーを適切に適用できるためです。

## <a name="create-an-enterprise-enlightened-app"></a>エンタープライズ対応アプリの作成

WIP API を使用してアプリを対応させてから、アプリをエンタープライズ対応として宣言します。

アプリを組織用と個人用の両方の目的で使用する場合に、アプリの対応を行ってください。

また、ポリシー要素の適用を適切に処理する必要がある場合にも、アプリの対応を行ってください。

たとえば、ポリシーで、ユーザーが企業データを個人ドキュメントに貼り付けることが許可されている場合、データを貼り付ける前に、ユーザーが同意ダイアログに応答する必要がないように設定できます。 同様に、このようなイベントへの応答で、カスタムの情報を示すダイアログ ボックスを表示することができます。

アプリを対応させる準備ができたら、以下のガイドのいずれかをご覧ください。

**ユニバーサル Windows プラットフォーム (UWP) アプリは、c# を使用してビルドします。**

[Windows 情報保護 (WIP) 開発者向けガイド](wip-dev-guide.md)。

**C++ を使用して作成するデスクトップ アプリの場合**

[Windows 情報保護 (WIP) 開発者向けガイド (C++)](http://go.microsoft.com/fwlink/?LinkId=822192)。


## <a name="create-non-enlightened-enterprise-app"></a>エンタープライズ非対応アプリの作成

個人用途向けではない基幹業務 (LOB) アプリを作成している場合は、それを対応アプリにする必要はない可能性があります。

### <a name="windows-desktop-apps"></a>Windows デスクトップ アプリ
Windows デスクトップ アプリを対応させる必要はありません。ただし、ポリシー下でアプリが適切に動作することを確認するためにアプリをテストすることは必要になります。 たとえば、アプリを起動して使用した後に、MDM からデバイスを登録解除します。 その後、アプリが再び起動することを確認します。 アプリの動作に重要なファイルが暗号化されていると、アプリが起動しない可能性があります。 また、ユーザーの個人的なファイルがアプリにより誤って暗号化されないように、アプリでやり取りするファイル確認します。 これには、メタデータ ファイルや画像などの要素も含まれます。

アプリをテストしたら、次のフラグをリソース ファイルまたはプロジェクトに追加し、アプリを再コンパイルします。

```cpp
MICROSOFTEDPAUTOPROTECTIONALLOWEDAPPINFO EDPAUTOPROTECTIONALLOWEDAPPINFOID
BEGIN
    0x0001
END
```
MDM ポリシーではこのフラグは必要ありませんが、MAM ポリシーでは必要になります。

### <a name="uwp-apps"></a>UWP アプリ

アプリが MAM ポリシーの対象になることが予想される場合はアプリを対応させます。 MDM 対象のデバイスに展開するポリシーで対応化が必要になることはありませんが、アプリを組織のユーザーに配布する場合、どの種類のポリシー管理システムがアプリで使用されるか判別するのは、不可能ではないにしても困難です。 両方のポリシー管理システム (MDM および MAM) でアプリの動作を実現するには、アプリを対応させる必要があります。






 
