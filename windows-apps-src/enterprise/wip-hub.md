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
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6454905"
---
# <a name="windows-information-protection-wip"></a><span data-ttu-id="a27c9-103">Windows 情報保護 (WIP)</span><span class="sxs-lookup"><span data-stu-id="a27c9-103">Windows Information Protection (WIP)</span></span>

<span data-ttu-id="a27c9-104">__注__ Windows 情報保護 (WIP) ポリシーは、Windows 10 Version 1607 に適用することができます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-104">__Note__ Windows Information Protection (WIP) policy can be applied to Windows 10, version 1607.</span></span>

<span data-ttu-id="a27c9-105">WIP では、組織で定義されているポリシーを適用することによって、組織に属しているデータを保護します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-105">WIP protects data that belongs to an organization by enforcing policies that are defined by the organization.</span></span> <span data-ttu-id="a27c9-106">アプリがこれらのポリシーに含まれている場合、アプリによって生成されたすべてのデータにはポリシーの制限が適用されます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-106">If your app is included in those polices, all data produced by your app is subject to policy restrictions.</span></span> <span data-ttu-id="a27c9-107">このトピックは、ユーザーの個人データに影響を与えずに、これらのポリシーをより適切に適用するアプリを作成する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-107">This topic helps you to build apps that more gracefully enforce these policies without having any impact on the user's personal data.</span></span>
<iframe src="https://channel9.msdn.com/Blogs/Windows-Development-for-the-Enterprise/Securing-Enterprise-Data-with-Windows-Information-Protection/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

## <a name="first-what-is-wip"></a><span data-ttu-id="a27c9-108">WIP とは</span><span class="sxs-lookup"><span data-stu-id="a27c9-108">First, what is WIP?</span></span>

<span data-ttu-id="a27c9-109">WIP とは、組織のモバイル デバイス管理 (MDM) およびモバイル アプリケーション管理 (MAM) システムをサポートするデスクトップ、ノート PC、タブレット、および電話で使用できる一連の機能です。</span><span class="sxs-lookup"><span data-stu-id="a27c9-109">WIP is a set of features on desktops, laptops, tablets, and phones that support the organization's Mobile Device Management (MDM) and Mobile Application Management (MAM) system.</span></span>

<span data-ttu-id="a27c9-110">WIP と MDM により、組織は、組織で管理しているデバイスでのデータの処理方法をより細かく制御できます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-110">WIP together with MDM gives the organization greater control over how its data is handled on devices that the organization manages.</span></span> <span data-ttu-id="a27c9-111">ユーザーは、仕事で使用しているデバイスを組織の MDM に登録しないことがあります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-111">Sometimes users bring devices to work and do not enroll them in the organization's MDM.</span></span>  <span data-ttu-id="a27c9-112">この場合、組織は MAM を利用することで、ユーザーのデバイスにインストールされた特定の基幹業務アプリ上でのデータの処理方法を詳細に制御できるようになります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-112">In those cases, organizations can use MAM to achieve greater control over how their data is handled on specific line of business apps that users install on their device.</span></span>

<span data-ttu-id="a27c9-113">MDM または MAM を利用すると、管理者は、組織に属しているファイルにアクセスできるアプリを特定したり、ユーザーがそれらのファイルからデータをコピーし、個人用のドキュメントに貼り付けることができるかどうかを指定したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-113">using MDM or MAM, administrators can identify which apps are allowed to access files that belong to the organization and whether users can copy data from those files and then paste that data into personal documents.</span></span>

<span data-ttu-id="a27c9-114">しくみは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a27c9-114">Here's how it works.</span></span> <span data-ttu-id="a27c9-115">ユーザーは、組織のモバイル デバイス管理 (MDM) システムにデバイスを登録します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-115">Users enroll their devices into the organization's mobile device management (MDM) system.</span></span> <span data-ttu-id="a27c9-116">管理側の組織の管理者は、Microsoft Intune や System Center Configuration Manager (SCCM) を使用して、ポリシーを定義し、登録されているデバイスにポリシーを展開します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-116">An administrator in the managing organization uses Microsoft Intune or System Center Configuration Manager (SCCM) to define and then deploy a policy to the enrolled devices.</span></span>

<span data-ttu-id="a27c9-117">ユーザーがデバイスを登録する必要がない場合、管理者は MAM システムを使って特定のアプリに適用するポリシーを定義および展開することになります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-117">If users aren't required to enroll their devices, administrators will use their MAM system to define and deploy a policy that applies to specific apps.</span></span> <span data-ttu-id="a27c9-118">ユーザーは、MAM 対象のいずれかのアプリをインストールした際に、関連のあるポリシーを受け取ることになります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-118">When users install any of those apps, they'll receive the associated policy.</span></span>

<span data-ttu-id="a27c9-119">そのポリシーでは、企業データにアクセスできるアプリを指定します (ポリシーの*許可リスト*と呼ばれます)。</span><span class="sxs-lookup"><span data-stu-id="a27c9-119">That policy identifies the apps that can access enterprise data (called the policy's *allowed list*).</span></span> <span data-ttu-id="a27c9-120">これらのアプリは、企業の保護されたファイル、仮想プライベート ネットワーク (VPN)、クリップボードにある企業データにアクセスできます。また、共有コントラクトを使用して、企業データにアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-120">These apps can access enterprise protected files, Virtual Private Networks (VPN) and enterprise data on the clipboard or through a share contract.</span></span> <span data-ttu-id="a27c9-121">ポリシーでは、データを管理する規則も定義します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-121">The policy also defines the rules that govern the data.</span></span> <span data-ttu-id="a27c9-122">たとえば、企業が所有するファイルからデータをコピーして、企業以外の者が所有するファイルに貼り付けることができるかどうかなどを制御します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-122">For example, whether data can be copied from enterprise-owned files and then pasted into non enterprise-owned files.</span></span>

<span data-ttu-id="a27c9-123">ユーザーが組織の MDM システムからデバイスを登録解除した場合や、組織の MAM システムで指定されているアプリをアンインストールした場合、管理者はそのデバイスの企業データをリモートでワイプできます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-123">If users unenroll their device from the organization's MDM system, or uninstall apps identified by the organizations MAM system, administrators can remotely wipe enterprise data from the device.</span></span>

![WIP のライフサイクル](images/wip-lifecycle.png)

> **<span data-ttu-id="a27c9-125">WIP について詳しくは、以下をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a27c9-125">Read more about WIP</span></span>** <br>
* [<span data-ttu-id="a27c9-126">Introducing Windows Information Protection (Windows 情報保護の概要)</span><span class="sxs-lookup"><span data-stu-id="a27c9-126">Introducing Windows Information Protection</span></span>](https://blogs.technet.microsoft.com/windowsitpro/2016/06/29/introducing-windows-information-protection/)
* [<span data-ttu-id="a27c9-127">Windows 情報保護 (WIP) を使用した企業データの保護</span><span class="sxs-lookup"><span data-stu-id="a27c9-127">Protect your enterprise data using Windows Information Protection (WIP)</span></span>](https://technet.microsoft.com/library/dn985838(v=vs.85).aspx)

<span data-ttu-id="a27c9-128">アプリが許可リストに登録されている場合、アプリによって生成されたすべてのデータにはポリシーの制限が適用されます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-128">If your app is on the allowed list, all data produced by your app is subject to policy restrictions.</span></span> <span data-ttu-id="a27c9-129">つまり、管理者が企業データへのユーザー アクセスを無効にすると、それらのユーザーは、アプリによって生成されたすべてのデータへアクセスできなくなります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-129">That means that if administrators revoke the user's access to enterprise data, those users lose access to all of the data that your app produced.</span></span>

<span data-ttu-id="a27c9-130">これは、アプリが企業での使用のみを目的として設計されている場合は、問題ありません。</span><span class="sxs-lookup"><span data-stu-id="a27c9-130">This is fine if your app is designed only for enterprise use.</span></span> <span data-ttu-id="a27c9-131">ただし、ユーザーが個人用のデータであると見なすことができるデータをアプリが生成する場合は、企業データと個人データをインテリジェントに区別するようにアプリを*対応させる*必要があります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-131">But if your app creates data that users consider personal to them, you'll want to *enlighten* your app to intelligently discern between enterprise and personal data.</span></span> <span data-ttu-id="a27c9-132">この種類のアプリは、"*エンタープライズ対応*" と呼ばれます。それは、ユーザーの個人データの整合性を維持したまま、企業のポリシーを適切に適用できるためです。</span><span class="sxs-lookup"><span data-stu-id="a27c9-132">We call this type of an app *enterprise-enlightened* because it can gracefully enforce enterprise policy while preserving the integrity of the user's personal data.</span></span>

## <a name="create-an-enterprise-enlightened-app"></a><span data-ttu-id="a27c9-133">エンタープライズ対応アプリの作成</span><span class="sxs-lookup"><span data-stu-id="a27c9-133">Create an enterprise-enlightened app</span></span>

<span data-ttu-id="a27c9-134">WIP API を使用してアプリを対応させてから、アプリをエンタープライズ対応として宣言します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-134">Use WIP APIs to enlighten your app, and then declare your app as enterprise-enlightened.</span></span>

<span data-ttu-id="a27c9-135">アプリを組織用と個人用の両方の目的で使用する場合に、アプリの対応を行ってください。</span><span class="sxs-lookup"><span data-stu-id="a27c9-135">Enlighten your app if it'll be used for both organizational and personal purposes.</span></span>

<span data-ttu-id="a27c9-136">また、ポリシー要素の適用を適切に処理する必要がある場合にも、アプリの対応を行ってください。</span><span class="sxs-lookup"><span data-stu-id="a27c9-136">Enlighten your app if you want to gracefully handle the enforcement of policy elements.</span></span>

<span data-ttu-id="a27c9-137">たとえば、ポリシーで、ユーザーが企業データを個人ドキュメントに貼り付けることが許可されている場合、データを貼り付ける前に、ユーザーが同意ダイアログに応答する必要がないように設定できます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-137">For example, if policy allows users to paste enterprise data into a personal document, you can prevent users from having to respond to a consent dialog before they paste the data.</span></span> <span data-ttu-id="a27c9-138">同様に、このようなイベントへの応答で、カスタムの情報を示すダイアログ ボックスを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-138">Similarly, you can present custom informational dialog boxes in response to these sorts of events.</span></span>

<span data-ttu-id="a27c9-139">アプリを対応させる準備ができたら、以下のガイドのいずれかをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a27c9-139">If you're ready to enlighten your app, see one of these guides:</span></span>

**<span data-ttu-id="a27c9-140">C# を使用してビルドするユニバーサル Windows プラットフォーム (UWP) アプリの場合</span><span class="sxs-lookup"><span data-stu-id="a27c9-140">For Universal Windows Platform (UWP) apps that you build by using C#</span></span>**

<span data-ttu-id="a27c9-141">[Windows 情報保護 (WIP) 開発者向けガイド](wip-dev-guide.md)。</span><span class="sxs-lookup"><span data-stu-id="a27c9-141">[Windows Information Protection (WIP) developer guide](wip-dev-guide.md).</span></span>

**<span data-ttu-id="a27c9-142">C++ を使用して作成するデスクトップ アプリの場合</span><span class="sxs-lookup"><span data-stu-id="a27c9-142">For Desktop apps that you build by using C++</span></span>**

<span data-ttu-id="a27c9-143">[Windows 情報保護 (WIP) 開発者向けガイド (C++)](http://go.microsoft.com/fwlink/?LinkId=822192)。</span><span class="sxs-lookup"><span data-stu-id="a27c9-143">[Windows Information Protection (WIP) developer guide (C++)](http://go.microsoft.com/fwlink/?LinkId=822192).</span></span>


## <a name="create-non-enlightened-enterprise-app"></a><span data-ttu-id="a27c9-144">エンタープライズ非対応アプリの作成</span><span class="sxs-lookup"><span data-stu-id="a27c9-144">Create non-enlightened enterprise app</span></span>

<span data-ttu-id="a27c9-145">個人用途向けではない基幹業務 (LOB) アプリを作成している場合は、それを対応アプリにする必要はない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-145">if you're creating an Line of Business (LOB) app that is not intended for personal use, you might not have to enlighten it.</span></span>

### <a name="windows-desktop-apps"></a><span data-ttu-id="a27c9-146">Windows デスクトップ アプリ</span><span class="sxs-lookup"><span data-stu-id="a27c9-146">Windows desktop apps</span></span>
<span data-ttu-id="a27c9-147">Windows デスクトップ アプリを対応させる必要はありません。ただし、ポリシー下でアプリが適切に動作することを確認するためにアプリをテストすることは必要になります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-147">You don't need to enlighten a Windows desktop app but you should test your app to ensure that it functions properly under policy.</span></span> <span data-ttu-id="a27c9-148">たとえば、アプリを起動して使用した後に、MDM からデバイスを登録解除します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-148">For example, start your app, use it, then unenroll the device from MDM.</span></span> <span data-ttu-id="a27c9-149">その後、アプリが再び起動することを確認します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-149">Then, make sure the app can start again.</span></span> <span data-ttu-id="a27c9-150">アプリの動作に重要なファイルが暗号化されていると、アプリが起動しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-150">If files critical to the operation of the app are encrypted, the app might not start.</span></span> <span data-ttu-id="a27c9-151">また、ユーザーの個人的なファイルがアプリにより誤って暗号化されないように、アプリでやり取りするファイル確認します。</span><span class="sxs-lookup"><span data-stu-id="a27c9-151">Also, review the files that your app interacts with to ensure that your app won't inadvertently encrypt files that are personal to the user.</span></span> <span data-ttu-id="a27c9-152">これには、メタデータ ファイルや画像などの要素も含まれます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-152">This might include metadata files, images and other things.</span></span>

<span data-ttu-id="a27c9-153">アプリをテストしたら、次のフラグをリソース ファイルまたはプロジェクトに追加し、アプリを再コンパイルします。</span><span class="sxs-lookup"><span data-stu-id="a27c9-153">After you've tested your app, add this flag to the resource file or your project, and then recompile the app.</span></span>

```cpp
MICROSOFTEDPAUTOPROTECTIONALLOWEDAPPINFO EDPAUTOPROTECTIONALLOWEDAPPINFOID
BEGIN
    0x0001
END
```
<span data-ttu-id="a27c9-154">MDM ポリシーではこのフラグは必要ありませんが、MAM ポリシーでは必要になります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-154">While MDM policies don't require the flag, MAM policies do.</span></span>

### <a name="uwp-apps"></a><span data-ttu-id="a27c9-155">UWP アプリ</span><span class="sxs-lookup"><span data-stu-id="a27c9-155">UWP apps</span></span>

<span data-ttu-id="a27c9-156">アプリが MAM ポリシーの対象になることが予想される場合はアプリを対応させます。</span><span class="sxs-lookup"><span data-stu-id="a27c9-156">If you expect your app to be included in a MAM policy, you should enlighten it.</span></span> <span data-ttu-id="a27c9-157">MDM 対象のデバイスに展開するポリシーで対応化が必要になることはありませんが、アプリを組織のユーザーに配布する場合、どの種類のポリシー管理システムがアプリで使用されるか判別するのは、不可能ではないにしても困難です。</span><span class="sxs-lookup"><span data-stu-id="a27c9-157">Policies deployed to devices under MDM won't require it, but if you distribute your app to organizational consumers, it's difficult if not impossible to determine what type of policy management system they'll use.</span></span> <span data-ttu-id="a27c9-158">両方のポリシー管理システム (MDM および MAM) でアプリの動作を実現するには、アプリを対応させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="a27c9-158">To ensure that your app will work in both types of policy management systems (MDM and MAM), you should enlighten your app.</span></span>






 
