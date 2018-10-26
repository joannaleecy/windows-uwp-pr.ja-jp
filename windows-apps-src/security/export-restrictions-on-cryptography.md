---
title: 暗号化に関する輸出制限の順守
description: アプリでの暗号化が、Microsoft Store に登録されない可能性がある方法で使われていないかどうかを判断する場合に、この情報を利用してください。
ms.assetid: 204C7D1D-6F08-4AEE-A333-434D715E7617
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: a29c4aeb5a5928e04e0018d68884fdb4a4876332
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5557154"
---
# <a name="export-restrictions-on-cryptography"></a><span data-ttu-id="c739d-104">暗号化に関する輸出制限の順守</span><span class="sxs-lookup"><span data-stu-id="c739d-104">Export restrictions on cryptography</span></span>



<span data-ttu-id="c739d-105">アプリでの暗号化が、Microsoft Store に登録されない可能性がある方法で使われていないかどうかを判断する場合に、この情報を利用してください。</span><span class="sxs-lookup"><span data-stu-id="c739d-105">Use this info to determine if your app uses cryptography in a way that might prevent it from being listed in the Microsoft Store.</span></span>

<span data-ttu-id="c739d-106">米国商務省産業安全保障局は、一部の種類の暗号化を使う技術の輸出を規制しています。</span><span class="sxs-lookup"><span data-stu-id="c739d-106">The Bureau of Industry and Security in the United States Department of Commerce regulates the export of technology that uses certain types of encryption.</span></span> <span data-ttu-id="c739d-107">アプリ ファイルは米国内に保存することができるため、Microsoft Store に登録されているすべてのアプリはこれらの法律と規制に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c739d-107">All apps listed in the Microsoft Store must comply with these laws and regulations because the app files can be stored in the United States.</span></span> <span data-ttu-id="c739d-108">米国以外の国で配布することを目的として他の国からアプリ開発者によってアップロードされたアプリについても、これらの規制に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="c739d-108">Even apps that are uploaded by app developers from other countries for distribution outside of the United States must comply with these regulations.</span></span> <span data-ttu-id="c739d-109">このため、アプリを Microsoft Store に提出する場合、すべてのアプリ開発者はこれらの規制で制限されている技術がアプリに含まれていないことを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c739d-109">Consequently, when submitting an app to the Microsoft Store, all app developers must make sure that their apps don't contain any technology that is restricted by these regulations.</span></span>

> <span data-ttu-id="c739d-110">**注:** ここに記載された情報は、いくつかのガイダンスを提供しますが、アプリがすべての法律と規制に準拠しているかどうかを確認する、Microsoft Store でアプリを公開するアプリ開発者としてご自身の責任です。</span><span class="sxs-lookup"><span data-stu-id="c739d-110">**Note**The information provided here provides some guidance, but it is your responsibility as the app developer who is publishing apps in the Microsoft Store to make sure that your app complies with all applicable laws and regulations.</span></span>

 

<span data-ttu-id="c739d-111">米国商務省と産業安全保障局の詳しい情報については、[産業安全保障局の Web サイト](http://go.microsoft.com/fwlink/p/?LinkID=245644)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c739d-111">For more info about the U.S. Department of Commerce and the Bureau of Industry and Security, see [About the Bureau of Industry and Security](http://go.microsoft.com/fwlink/p/?LinkID=245644).</span></span>

<span data-ttu-id="c739d-112">暗号化を含む技術の輸出を管理する輸出管理規制 (EAR) の情報については、[暗号化技術を使う品目に対する輸出管理規制に関する Web ページ](http://go.microsoft.com/fwlink/p/?LinkID=245645)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c739d-112">For info about the Export Administration Regulations (EAR) that govern the export of technology that includes encryption, see [EAR Controls for Items That Use Encryption](http://go.microsoft.com/fwlink/p/?LinkID=245645).</span></span>

## <a name="governed-uses"></a><span data-ttu-id="c739d-113">管理対象の使用</span><span class="sxs-lookup"><span data-stu-id="c739d-113">Governed uses</span></span>

<span data-ttu-id="c739d-114">まず、輸出管理規制の対象となる暗号化の種類をアプリが使っているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="c739d-114">First, determine if your app uses a type of cryptography that is governed by the Export Administration Regulations.</span></span> <span data-ttu-id="c739d-115">この質問には、ここで一覧に示している例も含まれていますが、この一覧が暗号化の応用のすべてではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c739d-115">The question includes the examples shown in the list here; but remember that this list doesn't include every possible application of cryptography.</span></span>

> <span data-ttu-id="c739d-116">**重要な**、アプリもすべてのソフトウェア ライブラリ、ユーティリティ、およびオペレーティング システム コンポーネント、アプリが含まれていますかへのリンクを記述したコードだけでなくを検討してください。</span><span class="sxs-lookup"><span data-stu-id="c739d-116">**Important**Consider not only the code you wrote for your app, but also all the software libraries, utilities and operating system components that your app includes or links to.</span></span>

-   <span data-ttu-id="c739d-117">認証、整合性チェックなどの、デジタル署名の使用</span><span class="sxs-lookup"><span data-stu-id="c739d-117">Any use of a digital signature, such as authentication or integrity checking</span></span>
-   <span data-ttu-id="c739d-118">アプリが使ったりアクセスしたりするデータまたはファイルの暗号化</span><span class="sxs-lookup"><span data-stu-id="c739d-118">Encryption of any data or files that your app uses or accesses</span></span>
-   <span data-ttu-id="c739d-119">キー管理、証明書管理、または公開キー インフラストラクチャとやり取りのある操作</span><span class="sxs-lookup"><span data-stu-id="c739d-119">Key management, certificate management, or anything that interacts with a public key infrastructure</span></span>
-   <span data-ttu-id="c739d-120">NTLM、Kerberos、Secure Sockets Layer (SSL)、トランスポート層セキュリティ (TLS) などの、セキュリティで保護された通信チャネルの使用</span><span class="sxs-lookup"><span data-stu-id="c739d-120">Using a secure communication channel such as NTLM, Kerberos, Secure Sockets Layer (SSL), or Transport Layer Security (TLS)</span></span>
-   <span data-ttu-id="c739d-121">暗号化パスワードなどによる情報セキュリティ</span><span class="sxs-lookup"><span data-stu-id="c739d-121">Encrypting passwords or other forms of information security</span></span>
-   <span data-ttu-id="c739d-122">コピー防止やデジタル著作権管理 (DRM)</span><span class="sxs-lookup"><span data-stu-id="c739d-122">Copy protection or digital rights management (DRM)</span></span>
-   <span data-ttu-id="c739d-123">ウイルス対策機能</span><span class="sxs-lookup"><span data-stu-id="c739d-123">Antivirus protection</span></span>

<span data-ttu-id="c739d-124">暗号化の適用に関する最新の一覧については、[暗号化技術を使う品目に対する輸出管理規制に関する Web ページ](http://go.microsoft.com/fwlink/p/?LinkID=245645)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c739d-124">For the complete and current list of cryptographic applications, see [EAR Controls for Items That Use Encryption](http://go.microsoft.com/fwlink/p/?LinkID=245645).</span></span>

## <a name="non-restricted-uses"></a><span data-ttu-id="c739d-125">制限なしの使用</span><span class="sxs-lookup"><span data-stu-id="c739d-125">Non-restricted uses</span></span>

<span data-ttu-id="c739d-126">一部の暗号化の適用は制限されていません。</span><span class="sxs-lookup"><span data-stu-id="c739d-126">Note that some of the applications of cryptography are not restricted.</span></span> <span data-ttu-id="c739d-127">次のタスクは、制限を受けません。</span><span class="sxs-lookup"><span data-stu-id="c739d-127">Here are the unrestricted tasks:</span></span>

-   <span data-ttu-id="c739d-128">パスワードの暗号化</span><span class="sxs-lookup"><span data-stu-id="c739d-128">Password encryption</span></span>
-   <span data-ttu-id="c739d-129">コピー防止</span><span class="sxs-lookup"><span data-stu-id="c739d-129">Copy protection</span></span>
-   <span data-ttu-id="c739d-130">認証</span><span class="sxs-lookup"><span data-stu-id="c739d-130">Authentication</span></span>
-   <span data-ttu-id="c739d-131">デジタル著作権管理</span><span class="sxs-lookup"><span data-stu-id="c739d-131">Digital rights management</span></span>
-   <span data-ttu-id="c739d-132">デジタル署名の使用</span><span class="sxs-lookup"><span data-stu-id="c739d-132">Using digital signatures</span></span>

<span data-ttu-id="c739d-133">暗号化の適用に関する最新の一覧については、[暗号化技術を使う品目に対する輸出管理規制に関する Web ページ](http://go.microsoft.com/fwlink/p/?LinkID=245645)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c739d-133">For the complete and current list of cryptographic applications, see [EAR Controls for Items That Use Encryption](http://go.microsoft.com/fwlink/p/?LinkID=245645).</span></span>

<span data-ttu-id="c739d-134">アプリがこの一覧に含まれないタスクについて暗号化を呼び出す、サポートする、組み込む、または使う場合は、輸出規制品目番号 (ECCN) が必要です。</span><span class="sxs-lookup"><span data-stu-id="c739d-134">If your app calls, supports, contains, or uses cryptography or encryption for any task that is not in this list, it needs an Export Commodity Classification Number (ECCN).</span></span>

<span data-ttu-id="c739d-135">ECCN を持っていない場合は、[ECCN についての質問とその回答が掲載された Web ページ](http://go.microsoft.com/fwlink/p/?LinkID=245646)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c739d-135">If you don't have an ECCN, see [ECCN Questions and Answers](http://go.microsoft.com/fwlink/p/?LinkID=245646).</span></span>
