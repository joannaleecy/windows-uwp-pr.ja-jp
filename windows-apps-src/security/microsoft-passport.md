---
title: Windows Hello
description: この記事では、Windows 10 オペレーティング システムの一部としてリリースされる新しい Windows Hello テクノロジについて説明します。また、開発者がこのテクノロジを実装して、ユニバーサル Windows プラットフォーム (UWP) アプリやバックエンド サービスを保護する方法についても説明します。 従来の資格情報を使用する際に生じる脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows 10 ロールアウトに含まれるこれらのテクノロジの設計と展開について説明します。
ms.assetid: 0B907160-B344-4237-AF82-F9D47BCEE646
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: b81bf3c55b493d8e36f186ec56b68367c6245cc7
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4535266"
---
# <a name="windows-hello"></a><span data-ttu-id="d7be9-105">Windows Hello</span><span class="sxs-lookup"><span data-stu-id="d7be9-105">Windows Hello</span></span>




<span data-ttu-id="d7be9-106">この記事では、Windows 10 オペレーティング システムの一部としてリリースされる新しい Windows Hello テクノロジについて説明します。また、開発者がこのテクノロジを実装して、ユニバーサル Windows プラットフォーム (UWP) アプリやバックエンド サービスを保護する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-106">This article describes the new Windows Hello technology that is shipping as part of the Windows 10 operating system and discusses how developers can implement this technology to protect their Universal Windows Platform (UWP) apps and backend services.</span></span> <span data-ttu-id="d7be9-107">従来の資格情報を使用する際に生じる脅威を軽減するこれらのテクノロジの特定の機能に着目し、Windows 10 ロールアウトに含まれるこれらのテクノロジの設計と展開について説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-107">It highlights specific capabilities of these technologies that help mitigate threats that arise from using conventional credentials and provides guidance about designing and deploying these technologies as part of a Windows 10 rollout.</span></span>

<span data-ttu-id="d7be9-108">この記事では、アプリの開発に焦点を当てていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-108">Note that this article focuses on app development.</span></span> <span data-ttu-id="d7be9-109">Windows Hello のアーキテクチャおよび実装について詳しくは、「[TechNet の Windows Hello ガイド](https://technet.microsoft.com/library/mt589441.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-109">For information on the architecture and implementation details of Windows Hello, see the [Windows Hello Guide on TechNet](https://technet.microsoft.com/library/mt589441.aspx).</span></span>

<span data-ttu-id="d7be9-110">完全なコード サンプルについては、「[GitHub の Windows Hello コード サンプル](http://go.microsoft.com/fwlink/?LinkID=717812)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-110">For a complete code sample, see the [Windows Hello code sample on GitHub](http://go.microsoft.com/fwlink/?LinkID=717812).</span></span>

<span data-ttu-id="d7be9-111">Windows Hello と背後の認証サービスを使って UWP アプリを作成する具体的な手順については、「[Windows Hello ログイン アプリ](microsoft-passport-login.md)」と「[Windows Hello ログイン サービス](microsoft-passport-login-auth-service.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-111">For a step-by-step walkthrough on creating a UWP app using Windows Hello and the backing authentication service, see the [Windows Hello login app](microsoft-passport-login.md) and [Windows Hello login service](microsoft-passport-login-auth-service.md) articles.</span></span>

## <a name="1-introduction"></a><span data-ttu-id="d7be9-112">1 はじめに</span><span class="sxs-lookup"><span data-stu-id="d7be9-112">1 Introduction</span></span>


<span data-ttu-id="d7be9-113">情報セキュリティの基本的前提は、システムで使用ユーザーを識別できることです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-113">A fundamental assumption about information security is that a system can identify who is using it.</span></span> <span data-ttu-id="d7be9-114">ユーザーを識別することにより、システムでは、ユーザーが適切に識別されているかどうかを判断し (認証と呼ばれるプロセス)、適切に認証されたユーザーが実行できる内容を決定できます (承認と呼ばれるプロセス)。</span><span class="sxs-lookup"><span data-stu-id="d7be9-114">Identifying a user allows the system to decide whether the user is identified appropriately (a process known as authentication), and then decide what a properly authenticated user should be able to do (authorization).</span></span> <span data-ttu-id="d7be9-115">世界中に展開されたコンピューター システムの大部分は、認証と承認の判断を行う際にユーザーの資格情報に依存しています。つまり、これらのシステムにおけるセキュリティの基盤は、ユーザーが作成した再利用可能なパスワードに依存しています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-115">The overwhelming majority of computer systems deployed throughout the world depend on user credentials for making authentication and authorization decisions, which means that these systems depend on reusable, user-created passwords as the basis for their security.</span></span> <span data-ttu-id="d7be9-116">認証に「記憶によるもの、持ち物によるもの、本人の特長によるもの」を含めることができるということが、ある問題をしっかりと浮き彫りにしているとよく言われます。それは、再利用可能なパスワードは認証要素そのものであるため、パスワードを手に入れたユーザーは、元の所有者を偽装できるという点です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-116">The oft-cited maxim that authentication can involve "something you know, something you have, or something you are" neatly highlights the issue: a reusable password is an authentication factor all by itself, so anyone who knows the password can impersonate the user who owns it.</span></span>

## <a name="11-problems-with-traditional-credentials"></a><span data-ttu-id="d7be9-117">1.1 従来の資格情報の問題</span><span class="sxs-lookup"><span data-stu-id="d7be9-117">1.1 Problems with traditional credentials</span></span>


<span data-ttu-id="d7be9-118">1960 年代中ごろから、Fernando Corbató と Massachusetts Institute of Technology の彼のチームはパスワードの導入を提唱し、ユーザーと管理者はユーザーの認証と承認用のパスワードの使用に対応する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="d7be9-118">Ever since the mid-1960s, when Fernando Corbató and his team at the Massachusetts Institute of Technology championed the introduction of the password, users and administrators have had to deal with the use of passwords for user authentication and authorization.</span></span> <span data-ttu-id="d7be9-119">時間の経過と共に、最新のパスワードの保存と使用方法が少しずつ進化してきましたが (安全なハッシュ化とソルトなど)、未だに 2 つの問題に直面しています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-119">Over time, the state of the art for password storage and use has advanced somewhat (with secure hashing and salting, for example), but we are still faced with two problems.</span></span> <span data-ttu-id="d7be9-120">パスワードは簡単に複製でき、簡単に盗むことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-120">Passwords are easy to clone and they are easy to steal.</span></span> <span data-ttu-id="d7be9-121">さらに、実装を失敗すると、パスワードが危険にさらされてしまう可能性があり、ユーザーは利便性とセキュリティの難しい舵取りを強いられます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-121">In addition, implementation faults may render them insecure, and users have a hard time balancing convenience and security.</span></span>

## <a name="111-credential-theft"></a><span data-ttu-id="d7be9-122">1.1.1 資格情報の盗難</span><span class="sxs-lookup"><span data-stu-id="d7be9-122">1.1.1 Credential theft</span></span>


<span data-ttu-id="d7be9-123">パスワードの最大のリスクは単純です。攻撃者がパスワードを簡単に盗むことができる点です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-123">The biggest risk of passwords is simple: an attacker can steal them easily.</span></span> <span data-ttu-id="d7be9-124">パスワードの入力、処理、または保存を行うすべての場所に脆弱性があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-124">Every place a password is entered, processed, or stored is vulnerable.</span></span> <span data-ttu-id="d7be9-125">たとえば、攻撃者が、アプリケーション サーバーへのネットワーク トラフィックを傍受したり、アプリケーションやデバイスにマルウェアを埋め込んだり、デバイスへのユーザーのキーボード操作をログに記録したり、ユーザーが入力する文字を観察したりして、認証サーバーから一連のパスワードまたはハッシュを盗むことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-125">For example, an attacker can steal a collection of passwords or hashes from an authentication server by eavesdropping on network traffic to an application server, by implanting malware in an application or on a device, by logging user keystrokes on a device, or by watching to see which characters a user types.</span></span> <span data-ttu-id="d7be9-126">これらは、最も一般的な攻撃の方法です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-126">These are just the most common attack methods.</span></span>

<span data-ttu-id="d7be9-127">資格情報再生に関連するリスクがもう 1 つあります。この場合、攻撃者がセキュリティで保護されていないネットワークを傍受して有効な資格情報を取得し、後でその資格情報を再生して有効なユーザーを偽装します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-127">Another related risk is that of credential replay, in which an attacker captures a valid credential by eavesdropping on an insecure network, and then replays it later to impersonate a valid user.</span></span> <span data-ttu-id="d7be9-128">ほとんどの認証プロトコル (Kerberos や OAuth など) は、資格情報交換プロセスにタイム スタンプを追加して再生攻撃を防いでいますが、この方法で保護されるのは、認証システムが発効したトークンだけであり、ユーザーが最初にチケットを取得するために入力したパスワードは保護されません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-128">Most authentication protocols (including Kerberos and OAuth) protect against replay attacks by including a time stamp in the credential exchange process, but that tactic only protects the token that the authentication system issues, not the password that the user provides to get the ticket in the first place.</span></span>

## <a name="112-credential-reuse"></a><span data-ttu-id="d7be9-129">1.1.2 資格情報の再利用</span><span class="sxs-lookup"><span data-stu-id="d7be9-129">1.1.2 Credential reuse</span></span>




<span data-ttu-id="d7be9-130">ユーザー名としてメール アドレスを使う一般的な手法により、問題がさらに悪化します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-130">The common approach of using an email address as the username makes a bad problem worse.</span></span> <span data-ttu-id="d7be9-131">侵入したシステムからユーザー名とパスワードのペアをうまく復元した攻撃者は、この同じペアを他のシステムに試してみることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-131">An attacker who successfully recovers a username–password pair from a compromised system can then try that same pair on other systems.</span></span> <span data-ttu-id="d7be9-132">非常に多くの場合、この方法によって、攻撃者は侵入したシステムから別のシステムに入り込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-132">This tactic works surprisingly often to allow attackers to springboard from a compromised system into other systems.</span></span> <span data-ttu-id="d7be9-133">ユーザー名にメール アドレスを使用すると、他の問題が発生します。それについては、このガイドの後半で説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-133">The use of email addresses as usernames leads to additional problems that we will explore later in this guide.</span></span>

## <a name="12-solving-credential-problems"></a><span data-ttu-id="d7be9-134">1.2 資格情報の問題解決</span><span class="sxs-lookup"><span data-stu-id="d7be9-134">1.2 Solving credential problems</span></span>


<span data-ttu-id="d7be9-135">パスワードが原因で発生する問題の解決は簡単ではありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-135">Solving the problems that passwords pose is tricky.</span></span> <span data-ttu-id="d7be9-136">パスワード ポリシーのみを強化しても役に立ちません。ユーザーは、単にパスワードを再利用、共有、またはメモしてしまう場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-136">Tightening password policies alone will not do it; users may just recycle, share, or write down passwords.</span></span> <span data-ttu-id="d7be9-137">ユーザーの教育は認証セキュリティにとって重要ですが、教育だけでも問題を取り除けません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-137">Although user education is critical for authentication security, education alone does not eliminate the problem either.</span></span>

<span data-ttu-id="d7be9-138">Windows Hello では、パスワードに代わって強固な 2 要素認証 (2FA) が利用されます。この認証は、既存の資格情報の確認、およびユーザーのジェスチャ (生体認証または PIN ベース) で保護されるデバイス固有の資格情報の作成によって実現されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-138">Windows Hello replaces passwords with strong two-factor authentication (2FA) by verifying existing credentials and by creating a device-specific credential that a biometric or PIN-based user gesture protects.</span></span> 


## <a name="2-what-is-windows-hello"></a><span data-ttu-id="d7be9-139">2 Windows Hello とは</span><span class="sxs-lookup"><span data-stu-id="d7be9-139">2 What is Windows Hello?</span></span>


<span data-ttu-id="d7be9-140">Windows Hello は、Microsoft が Windows 10 に組み込まれた新しい生体認証サインイン システムに付けた名前です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-140">Windows Hello is the name Microsoft has given to the new biometric sign-in system built into Windows 10.</span></span> <span data-ttu-id="d7be9-141">Windows Hello はオペレーティング システムに直接組み込まれているため、顔または指紋を識別して、ユーザーのデバイスのロックを解除できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-141">Because it is built directly into the operating system, Windows Hello allows face or fingerprint identification to unlock users’ devices.</span></span> <span data-ttu-id="d7be9-142">ユーザーが自分固有の生体認証識別子を入力して、デバイス固有の資格情報にアクセスする場合に認証が行われます。つまり、攻撃者がデバイスを盗んでも、PIN がない限りデバイスにログオンすることはできません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-142">Authentication happens when the user supplies his or her unique biometric identifier to access the device-specific credentials, which means that an attacker who steals the device can’t log on to it unless that attacker has the PIN.</span></span> <span data-ttu-id="d7be9-143">Windows のセキュリティ保護された資格情報ストアは、デバイス上の生体認証データを保護します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-143">The Windows secure credential store protects biometric data on the device.</span></span> <span data-ttu-id="d7be9-144">Windows Hello を使ってデバイスのロックを解除することで、承認済みユーザーは、Windows エクスペリエンス、アプリ、データ、Web サイト、およびサービスのすべてにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-144">By using Windows Hello to unlock a device, the authorized user gains access to all of his or her Windows experience, apps, data, websites, and services.</span></span>

<span data-ttu-id="d7be9-145">Windows Hello 認証システムは、Hello と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-145">The Windows Hello authenticator is known as a Hello.</span></span> <span data-ttu-id="d7be9-146">Hello は、個々のデバイスと特定のユーザーの組み合わせに対して一意です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-146">A Hello is unique to the combination of an individual device and a specific user.</span></span> <span data-ttu-id="d7be9-147">これは、デバイス間でローミングされず、サーバーまたは呼び出し元のアプリとは共有されず、デバイスから簡単に抽出することはできません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-147">It does not roam across devices, is not shared with a server or calling app, and cannot easily be extracted from a device.</span></span> <span data-ttu-id="d7be9-148">複数のユーザーがデバイスを共有している場合、各ユーザーは自分のアカウントを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-148">If multiple users share a device, each user needs to set up his or her own account.</span></span> <span data-ttu-id="d7be9-149">各アカウントには、そのデバイス用の一意の Hello が与えられます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-149">Every account gets a unique Hello for that device.</span></span> <span data-ttu-id="d7be9-150">Hello は、保存されている資格情報のロック解除 (またはリリース) に使用できるトークンのようなものと考えることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-150">You can think of a Hello as a token you can use to unlock (or release) a stored credential.</span></span> <span data-ttu-id="d7be9-151">Hello 自体は、アプリまたはサービスに対する認証を行わず、認証できる資格情報をリリースします。</span><span class="sxs-lookup"><span data-stu-id="d7be9-151">The Hello itself does not authenticate you to an app or service, but it releases credentials that can.</span></span> <span data-ttu-id="d7be9-152">つまり、Hello はユーザーの資格情報ではなく、認証プロセス用の 2 番目の要素となります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-152">In other words, the Hello is not a user credential but it is a second factor for the authenticating process.</span></span>

## <a name="21-windows-hello-authentication"></a><span data-ttu-id="d7be9-153">2.1 Windows Hello 認証</span><span class="sxs-lookup"><span data-stu-id="d7be9-153">2.1 Windows Hello authentication</span></span>


<span data-ttu-id="d7be9-154">Windows Hello は、個々のユーザーを認識するための堅牢な方法をデバイスに提供します。これにより、ユーザーと要求されたサービス (またはデータ項目) との間のパスの最初の部分が処理されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-154">Windows Hello provides a robust way for a device to recognize an individual user, which addresses the first part of the path between a user and a requested service or data item.</span></span> <span data-ttu-id="d7be9-155">デバイスがユーザーを認識しても、要求されたリソースへのアクセス権を与えるかどうかを決める前に、ユーザーをまだ認証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-155">After the device has recognized the user, it still must authenticate the user before determining whether to grant access to a requested resource.</span></span> <span data-ttu-id="d7be9-156">Windows Hello は強力な 2FA で、Windows に完全に組み込まれています。これにより、再利用可能なパスワードが、特定のデバイスと生体認証ジェスチャや PIN の組み合わせに置き換わります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-156">Windows Hello provides strong 2FA that is fully integrated into Windows and replaces reusable passwords with the combination of a specific device, and a biometric gesture or PIN.</span></span>

<span data-ttu-id="d7be9-157">Windows Hello は、従来の 2FA システムの単なる代替機能ではありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-157">Windows Hello is not just a replacement for traditional 2FA systems, though.</span></span> <span data-ttu-id="d7be9-158">概念的にはスマート カードと似ています。Windows Hello では、文字列比較ではなく、暗号化プリミティブを使って認証が行われます。また、ユーザーのキー マテリアルは、改ざんされにくいハードウェア内でセキュリティ保護されています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-158">It is conceptually similar to smart cards: authentication is performed by using cryptographic primitives instead of string comparisons, and the user’s key material is secure inside tamper-resistant hardware.</span></span> <span data-ttu-id="d7be9-159">Windows Hello ではスマート カード展開に必要なインフラストラクチャ コンポーネントも追加する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-159">Windows Hello does not require the extra infrastructure components required for smart card deployment, either.</span></span> <span data-ttu-id="d7be9-160">具体的には、現在、公開キー基盤 (PKI) を所持していない場合は、証明書を管理するための PKI は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-160">In particular, you do not need a Public Key Infrastructure (PKI) to manage certificates, if you do not currently have one.</span></span> <span data-ttu-id="d7be9-161">Windows Hello では、スマート カードの主な利点である、仮想スマート カードの展開の柔軟性と物理スマート カードの堅牢なセキュリティを組み合わせ、それぞれの欠点を排除しています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-161">Windows Hello combines the major advantages of smart cards—deployment flexibility for virtual smart cards and robust security for physical smart cards—without any of their drawbacks.</span></span>

## <a name="22-how-windows-hello-works"></a><span data-ttu-id="d7be9-162">2.2 Windows Hello のしくみ</span><span class="sxs-lookup"><span data-stu-id="d7be9-162">2.2 How Windows Hello works</span></span>


<span data-ttu-id="d7be9-163">ユーザーがコンピューターで Windows Hello をセットアップするとき、デバイスの新しい公開/秘密キーのペアが生成されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-163">When the user sets up Windows Hello on his or her machine, it generates a new public–private key pair on the device.</span></span> <span data-ttu-id="d7be9-164">[トラステッド プラットフォーム モジュール](https://technet.microsoft.com/itpro/windows/keep-secure/trusted-platform-module-overview) (TPM) はこの秘密キーを生成し、保護します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-164">The [trusted platform module](https://technet.microsoft.com/itpro/windows/keep-secure/trusted-platform-module-overview) (TPM) generates and protects this private key.</span></span> <span data-ttu-id="d7be9-165">デバイスに TPM チップが搭載されていない場合、秘密キーはソフトウェアによって暗号化され、保護されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-165">If the device does not have a TPM chip, the private key is encrypted and protected by software.</span></span> <span data-ttu-id="d7be9-166">また、TPM が有効なデバイスでは、キーが TPM にバインドされていることを証明する際に使われるデータ ブロックが生成されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-166">In addition TPM-enabled devices generate a block of data that can be used to attest that a key is bound to TPM.</span></span> <span data-ttu-id="d7be9-167">この証明情報をソリューションで利用し、たとえば、さまざまな認証レベルをユーザーに付与するかどうかを決定することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-167">This attestation information can be used in your solution to decide if the user is granted a different authorization level for example.</span></span>

<span data-ttu-id="d7be9-168">デバイスで Windows Hello を有効にするには、Azure Active Directory アカウントまたは Windows の設定で関連付けられた Microsoft アカウントが必要です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-168">To enable Windows Hello on a device, the user must have either their Azure Active Directory account or Microsoft Account connected in Windows settings.</span></span>

## <a name="221-how-keys-are-protected"></a><span data-ttu-id="d7be9-169">2.2.1 キーを保護する方法</span><span class="sxs-lookup"><span data-stu-id="d7be9-169">2.2.1 How keys are protected</span></span>


<span data-ttu-id="d7be9-170">キー マテリアルを生成する場合は、常に攻撃から保護する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-170">Any time key material is generated, it must be protected against attack.</span></span> <span data-ttu-id="d7be9-171">これを実現する最も堅牢な方法は、ハードウェアをカスタマイズすることです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-171">The most robust way to do this is through specialized hardware.</span></span> <span data-ttu-id="d7be9-172">セキュリティ クリティカルなアプリケーションのキーの生成、保存、および処理には、これまでずっとハードウェア セキュリティ モジュール (HSM) を使用してきました。</span><span class="sxs-lookup"><span data-stu-id="d7be9-172">There is a long history of using hardware security modules (HSMs) to generate, store, and process keys for security-critical applications.</span></span> <span data-ttu-id="d7be9-173">スマート カードは特別な種類の HSM で、Trusted Computing Group TPM 標準に準拠しているデバイスでもあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-173">Smart cards are a special type of HSM, as are devices that are compliant with the Trusted Computing Group TPM standard.</span></span> <span data-ttu-id="d7be9-174">可能であれば、Windows Hello 実装では、オンボード TPM ハードウェアを活用して、キーの生成、保存、および処理を行います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-174">Wherever possible, the Windows Hello implementation takes advantage of onboard TPM hardware to generate, store, and process keys.</span></span> <span data-ttu-id="d7be9-175">ただし、Windows Hello と Windows Hello for Work にはオンボード TPM は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-175">However, Windows Hello and Windows Hello for Work do not require an onboard TPM.</span></span>

<span data-ttu-id="d7be9-176">可能であれば、TPM ハードウェアを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d7be9-176">Whenever feasible, Microsoft recommends the use of TPM hardware.</span></span> <span data-ttu-id="d7be9-177">TPM は、PIN のブルート フォース攻撃など、さまざまな既知の潜在的な攻撃を防げます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-177">The TPM protects against a variety of known and potential attacks, including PIN brute-force attacks.</span></span> <span data-ttu-id="d7be9-178">アカウント ロックアウト後も、TPM はさらなる保護を追加します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-178">The TPM provides an additional layer of protection after an account lockout as well.</span></span> <span data-ttu-id="d7be9-179">TPM がキー マテリアルをロックしている場合、ユーザーは PIN をリセットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-179">When the TPM has locked the key material, the user must reset the PIN.</span></span> <span data-ttu-id="d7be9-180">PIN をリセットすると、古いキー マテリアルで暗号化されたすべてのキーと証明書は削除されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-180">Resetting the PIN means that all keys and certificates encrypted with the old key material will be removed.</span></span>

## <a name="222-authentication"></a><span data-ttu-id="d7be9-181">2.2.2 認証</span><span class="sxs-lookup"><span data-stu-id="d7be9-181">2.2.2 Authentication</span></span>


<span data-ttu-id="d7be9-182">ユーザーが保護されたキー マテリアルにアクセスする場合、認証プロセスでは、最初に "キーのリリース" と呼ばれるプロセスが行われ、ユーザーは PIN または生体認証ジェスチャを入力してデバイスのロックを解除します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-182">When a user wants to access protected key material, the authentication process begins with the user entering a PIN or biometric gesture to unlock the device, a process sometimes called "releasing the key".</span></span>

<span data-ttu-id="d7be9-183">アプリケーションは、別のアプリケーションからのキーを使うことはできません。また、だれも別のユーザーからのキーを使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-183">An application can never use the keys from another application, nor can someone ever use the keys from another user.</span></span> <span data-ttu-id="d7be9-184">これらのキーを使って、ID プロバイダー (IDP) に送信される要求に署名し、指定したリソースへのアクセスを要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-184">These keys are used to sign requests that are sent to the identity provider or IDP, seeking access to specified resources.</span></span> <span data-ttu-id="d7be9-185">アプリケーションは特定の API を使って、特定の動作でキー マテリアルを必要とする操作を要求できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-185">Applications can use specific APIs to request operations that require key material for particular actions.</span></span> <span data-ttu-id="d7be9-186">これらの API 使ってアクセスする場合、ユーザーのジェスチャを利用した明示的な検証が必要になります。キー マテリアルは要求元のアプリケーションに公開されません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-186">Access through these APIs does require explicit validation through a user gesture, and the key material is not exposed to the requesting application.</span></span> <span data-ttu-id="d7be9-187">代わりに、アプリケーションはデータへの署名などの特定の操作を要求し、Windows Hello レイヤーは、実際の作業を処理して、結果を返します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-187">Rather, the application asks for a specific action like signing a piece of data, and the Windows Hello layer handles the actual work and returns the results.</span></span>

## <a name="23-getting-ready-to-implement-windows-hello"></a><span data-ttu-id="d7be9-188">2.3 Windows Hello を実装するための準備</span><span class="sxs-lookup"><span data-stu-id="d7be9-188">2.3 Getting ready to implement Windows Hello</span></span>


<span data-ttu-id="d7be9-189">以上で、Windows Hello のしくみの基本について学習しました。次に、Windows Hello をアプリケーションに実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-189">Now that we have a basic understanding of how Windows Hello works, let us take a look at how to implement them in our own applications.</span></span>

<span data-ttu-id="d7be9-190">Windows Hello を使った実装については、さまざまなシナリオがあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-190">There are different scenarios we can implement using Windows Hello.</span></span> <span data-ttu-id="d7be9-191">たとえば、デバイスでアプリにログオンする場合が挙げられます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-191">For example, just logging on to your app on a device.</span></span> <span data-ttu-id="d7be9-192">他の一般的なシナリオとしては、サービスに対して認証を行うシナリオがあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-192">The other common scenario would be to authenticate against a service.</span></span> <span data-ttu-id="d7be9-193">ログオン名とパスワードを使う代わりに、Windows Hello を使います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-193">Instead of using a logon name and password, you will be using Windows Hello.</span></span> <span data-ttu-id="d7be9-194">以降の章では、いくつかの異なるシナリオの実装について説明します。Windows Hello を使いサービスに対して認証する方法や、既にあるユーザー名/パスワード システムから Windows Hello システムへの変換方法などについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-194">In the following chapters, we will discuss implementing a couple of different scenarios, including how to authenticate against your services with Windows Hello, and how to convert from an existing username/password system to a Windows Hello system.</span></span>

<span data-ttu-id="d7be9-195">最後に、Windows Hello API については、アプリを使用するオペレーティング システムと一致する Windows 10 SDK を使用する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-195">Finally, be aware that the Windows Hello APIs require the use of the Windows 10 SDK that matches the operating system the app will be used on.</span></span> <span data-ttu-id="d7be9-196">つまり、Windows 10 に展開するアプリには 10.0.10240 Windows SDK を使用する必要があり、Windows 10 バージョン 1511 に展開するアプリには 10.0.10586 を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-196">In other words, the 10.0.10240 Windows SDK must be used for apps that will be deployed to Windows 10 and the 10.0.10586 must be used for apps that will be deployed to Windows 10, version 1511.</span></span>

## <a name="3-implementing-windows-hello"></a><span data-ttu-id="d7be9-197">3 Windows Hello の実装</span><span class="sxs-lookup"><span data-stu-id="d7be9-197">3 Implementing Windows Hello</span></span>


<span data-ttu-id="d7be9-198">この章では、認証システムがない新規のシナリオから始め、Windows Hello を実装する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-198">In this chapter, we begin with a greenfield scenario with no existing authentication system, and we explain how to implement Windows Hello.</span></span>

<span data-ttu-id="d7be9-199">次のセクションでは、既存のユーザー名/パスワード システムから移行する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-199">The next section covers how to migrate from an existing username/password system.</span></span> <span data-ttu-id="d7be9-200">ただし、次の章の方に興味がある場合でも、この章に目を通して、必要なプロセスとコードの基本を理解することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d7be9-200">However, even if that chapter interests you more, you may want to look through this one to get a basic understanding of the process and the code required.</span></span>

## <a name="31-enrolling-new-users"></a><span data-ttu-id="d7be9-201">3.1 新しいユーザーの登録</span><span class="sxs-lookup"><span data-stu-id="d7be9-201">3.1 Enrolling new users</span></span>


<span data-ttu-id="d7be9-202">まず、新しいデバイスにサインアップしようとしている新しいユーザーを仮定して、Windows Hello を使用する新しいサービスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-202">We begin with a brand new service that will use Windows Hello, and a hypothetical new user who is ready to sign up on a new device.</span></span>

<span data-ttu-id="d7be9-203">最初に、ユーザーが Windows Hello を使用できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-203">The first step is to verify that the user is able to use Windows Hello.</span></span> <span data-ttu-id="d7be9-204">アプリは、ユーザー設定とコンピューターの機能を調べ、ユーザー ID キーを作成できることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-204">The app verifies user settings and machine capabilities to make sure it can create user ID keys.</span></span> <span data-ttu-id="d7be9-205">アプリは、ユーザーがまだ Windows Hello を有効にしていないと判断した場合、アプリを使う前に、ユーザーに対して Windows Hello をセットアップするように求めます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-205">If the app determines the user has not yet enabled Windows Hello, it prompts the user to set this up before using the app.</span></span>

<span data-ttu-id="d7be9-206">ユーザーが Out of Box Experience (OOBE) で PIN をセットアップしていない場合、Windows Hello を有効にするには、ユーザーは Windows 設定で PIN をセットアップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-206">To enable Windows Hello, the user just needs to set up a PIN in Windows settings, unless the user set it up during the Out of Box Experience (OOBE).</span></span>

<span data-ttu-id="d7be9-207">次のコード行は、ユーザーが Windows Hello をセットアップしたかどうかを調べるための簡単な方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-207">The following lines of code show a simple way to check if the user is set up for Windows Hello.</span></span>

```cs
var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
if (!keyCredentialAvailable)
{
   // User didn't set up PIN yet
   return;
}
```

<span data-ttu-id="d7be9-208">次の手順では、サービスにサインアップするための情報をユーザーに要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-208">The next step is to ask the user for information to sign up with your service.</span></span> <span data-ttu-id="d7be9-209">氏名、メール アドレス、および一意のユーザー名などをユーザーに要求できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-209">You may choose to ask the user for first name, last name, email address, and a unique username.</span></span> <span data-ttu-id="d7be9-210">メール アドレスを一意の識別子として使うこともできます。これは任意に指定できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-210">You could use the email address as the unique identifier; it is up to you.</span></span>

<span data-ttu-id="d7be9-211">このシナリオでは、ユーザーの一意の識別子としてメール アドレスを使用します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-211">In this scenario, we use the email address as the unique identifier for the user.</span></span> <span data-ttu-id="d7be9-212">ユーザーがサインアップしたら、アドレスが有効であることを確認するために確認メールを送信することを検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-212">Once the user signs up, you should consider sending a validation email to ensure the address is valid.</span></span> <span data-ttu-id="d7be9-213">これにより、必要な場合にアカウントをリセットすることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-213">This gives you a mechanism to reset the account if necessary.</span></span>

<span data-ttu-id="d7be9-214">ユーザーが自分の PIN をセットアップすると、アプリはユーザーの [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-214">If the user has set up his or her PIN, the app creates the user’s [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029).</span></span> <span data-ttu-id="d7be9-215">また、アプリは、オプションでキーの構成証明情報も取得して、キーが TPM で生成されたことを示す暗号証明を入手します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-215">The app also gets the optional key attestation information to acquire cryptographic proof that the key is generated on the TPM.</span></span> <span data-ttu-id="d7be9-216">生成された公開キーと、キーの構成証明 (任意に指定) をバックエンド サーバーに送信して、使われているデバイスを登録します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-216">The generated public key, and optionally the attestation, is sent to the backend server to register the device being used.</span></span> <span data-ttu-id="d7be9-217">各デバイスで生成されたすべてのキーのペアは一意になります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-217">Every key pair generated on every device will be unique.</span></span>

<span data-ttu-id="d7be9-218">[**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成するコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-218">The code to create the [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) looks like this:</span></span>

```cs
var keyCreationResult = await KeyCredentialManager
    .RequestCreateAsync(AccountId, KeyCredentialCreationOption.ReplaceExisting);
```

<span data-ttu-id="d7be9-219">[**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) では、公開キーと秘密キーの作成を行います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-219">The [**RequestCreateAsync**](https://msdn.microsoft.com/library/windows/apps/dn973048) is the part that creates the public and private key.</span></span> <span data-ttu-id="d7be9-220">デバイスに適切な TPM チップが搭載されている場合、API は、秘密キーと公開キーの作成およびその結果の保存を TPM チップに要求します。TPM チップが利用できない場合は、OS によって、コードでキーのペアが作成されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-220">If the device has the right TPM chip, the APIs will request the TPM chip to create the private and public key and store the result; if there is no TPM chip available, the OS will create the key pair in code.</span></span> <span data-ttu-id="d7be9-221">作成した秘密キーにアプリが直接アクセスする方法はありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-221">There is no way for the app to access the created private keys directly.</span></span> <span data-ttu-id="d7be9-222">キーのペアを作成する処理によって、構成証明情報も生成されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-222">Part of the creation of the key pairs is also the resulting Attestation information.</span></span> <span data-ttu-id="d7be9-223">(構成証明について詳しくは、次のセクションをご覧ください。)</span><span class="sxs-lookup"><span data-stu-id="d7be9-223">(See the next section for more information about attestation.)</span></span>

<span data-ttu-id="d7be9-224">デバイスでキーのペアと構成証明情報が作成されたら、公開キー、オプションの構成証明情報、および一意の識別子 (メール アドレスなど) をバックエンドの登録サービスに送信し、バックエンドに保存する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-224">After the key pair and attestation information are created on the device, the public key, the optional attestation information, and the unique identifier (such as the email address) need to be sent to the backend registration service and stored in the backend.</span></span>

<span data-ttu-id="d7be9-225">ユーザーが複数のデバイスでアプリにアクセスできるようにする場合、バックエンド サービスでは、同じユーザーに対して複数のキーを保存できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-225">To allow the user to access the app on multiple devices, the backend service needs to be able to store multiple keys for the same user.</span></span> <span data-ttu-id="d7be9-226">すべてのキーは各デバイスで一意であるため、これらすべてのキーを同じユーザーに関連付けて保存します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-226">Because every key is unique for every device, we will store all these keys connected to the same user.</span></span> <span data-ttu-id="d7be9-227">デバイス識別子を使うと、ユーザーを認証するときに、サーバー部分を最適化することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-227">A device identifier is used to help optimize the server part when authenticating users.</span></span> <span data-ttu-id="d7be9-228">これについては、次の章で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-228">We talk about this in more detail in the next chapter.</span></span>

<span data-ttu-id="d7be9-229">バックエンドでこの情報を保存するサンプルのデータベース スキーマは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-229">A sample database schema to store this information at the backend might look like this:</span></span>

![Windows Hello のサンプル データベース スキーマ](images/passport-db.png)

<span data-ttu-id="d7be9-231">登録のロジックは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-231">The registration logic might look like this:</span></span>

![Windows Hello の登録ロジック](images/passport-registration.png)

<span data-ttu-id="d7be9-233">収集する登録情報はもちろん、この単純なシナリオよりも多くの識別情報を含む場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-233">The registration information you collect may of course include a lot more identifying information than we include in this simple scenario.</span></span> <span data-ttu-id="d7be9-234">たとえば、アプリが、バンキング用などのセキュリティで保護されたサービスにアクセスする場合、サインアップ プロセスの一部として ID やその他の項目の証明を要求する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-234">For example, if your app accesses a secured service such as one for banking, you would need to request proof of identity and other things as part of the sign-up process.</span></span> <span data-ttu-id="d7be9-235">すべての条件が満たされると、ユーザーの公開キーがバックエンドに保存され、次回ユーザーがサービスを利用するときの検証でこの公開キーが使われます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-235">Once all the conditions are met, the public key of this user will be stored in the backend and used to validate the next time the user uses the service.</span></span>

```cs
using System;
using System.Runtime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Security.Credentials;

static async void RegisterUser(string AccountId)
{
    var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
    if (!keyCredentialAvailable)
    {
        // The user didn't set up a PIN yet
        return;
    }

    var keyCreationResult = await KeyCredentialManager.RequestCreateAsync(AccountId, KeyCredentialCreationOption.ReplaceExisting);
    if (keyCreationResult.Status == KeyCredentialStatus.Success)
    {
        var userKey = keyCreationResult.Credential;
        var publicKey = userKey.RetrievePublicKey();
        var keyAttestationResult = await userKey.GetAttestationAsync();
        IBuffer keyAttestation = null;
        IBuffer certificateChain = null;
        bool keyAttestationIncluded = false;
        bool keyAttestationCanBeRetrievedLater = false;

        keyAttestationResult = await userKey.GetAttestationAsync();
        KeyCredentialAttestationStatus keyAttestationRetryType = 0;

        if (keyAttestationResult.Status == KeyCredentialAttestationStatus.Success)
        {
            keyAttestationIncluded = true;
            keyAttestation = keyAttestationResult.AttestationBuffer;
            certificateChain = keyAttestationResult.CertificateChainBuffer;
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.TemporaryFailure)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.TemporaryFailure;
            keyAttestationCanBeRetrievedLater = true;
        }
        else if (keyAttestationResult.Status == KeyCredentialAttestationStatus.NotSupported)
        {
            keyAttestationRetryType = KeyCredentialAttestationStatus.NotSupported;
            keyAttestationCanBeRetrievedLater = true;
        }
    }
    else if (keyCreationResult.Status == KeyCredentialStatus.UserCanceled ||
        keyCreationResult.Status == KeyCredentialStatus.UserPrefersPassword)
    {
        // Show error message to the user to get confirmation that user
        // does not want to enroll.
    }
}
```

## <a name="311-attestation"></a><span data-ttu-id="d7be9-236">3.1.1 構成証明</span><span class="sxs-lookup"><span data-stu-id="d7be9-236">3.1.1 Attestation</span></span>


<span data-ttu-id="d7be9-237">キーのペアを作成するときに、TPM チップで生成される構成証明情報を要求することもできます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-237">When creating the key pair, there is also an option to request the attestation information, which is generated by the TPM chip.</span></span> <span data-ttu-id="d7be9-238">このオプションの情報は、サインアップ プロセスの一環としてサーバーに送信できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-238">This optional information can be sent to the server as part of the sign-up process.</span></span> <span data-ttu-id="d7be9-239">TPM キーの構成証明は、キーが TPM にバインドされていることを暗号で証明するプロトコルです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-239">TPM key attestation is a protocol that cryptographically proves that a key is TPM-bound.</span></span> <span data-ttu-id="d7be9-240">この種類の構成証明を使うことで、特定の暗号化操作が特定のコンピューターの TPM で行われたことを保証できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-240">This type of attestation can be used to guarantee that a certain cryptographic operation occurred in the TPM of a particular computer.</span></span>

<span data-ttu-id="d7be9-241">生成された RSA キー、構成証明ステートメント、および AIK 証明書をサーバーが受け取った場合、サーバーは次の項目を確認します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-241">When it receives the generated RSA key, the attestation statement, and the AIK certificate, the server verifies the following conditions:</span></span>

-   <span data-ttu-id="d7be9-242">AIK 証明書の署名が有効であること。</span><span class="sxs-lookup"><span data-stu-id="d7be9-242">The AIK certificate signature is valid.</span></span>
-   <span data-ttu-id="d7be9-243">AIK 証明書チェーンをたどって、信頼されたルートに到達できること。</span><span class="sxs-lookup"><span data-stu-id="d7be9-243">The AIK certificate chains up to a trusted root.</span></span>
-   <span data-ttu-id="d7be9-244">AIK 証明書とそのチェーンが、EKU OID "2.23.133.8.3" (フレンドリ名は "認証 ID キーの証明書") に対して有効になっていること。</span><span class="sxs-lookup"><span data-stu-id="d7be9-244">The AIK certificate and its chain is enabled for EKU OID "2.23.133.8.3" (friendly name is "Attestation Identity Key Certificate").</span></span>
-   <span data-ttu-id="d7be9-245">AIK 証明書の期間が有効であること。</span><span class="sxs-lookup"><span data-stu-id="d7be9-245">The AIK certificate is time valid.</span></span>
-   <span data-ttu-id="d7be9-246">チェーンに含まれている発行元の CA の証明書がすべて有効期間内にあり、失効していないこと。</span><span class="sxs-lookup"><span data-stu-id="d7be9-246">All issuing CA certificates in the chain are time-valid and not revoked.</span></span>
-   <span data-ttu-id="d7be9-247">構成証明ステートメントが正しい形式になっていること。</span><span class="sxs-lookup"><span data-stu-id="d7be9-247">The attestation statement is formed correctly.</span></span>
-   <span data-ttu-id="d7be9-248">[**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) BLOB の署名は、AIK 公開キーを使います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-248">The signature on [**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) blob uses an AIK public key.</span></span>
-   <span data-ttu-id="d7be9-249">[**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) BLOB に含まれる公開キーは、クライアントが構成証明ステートメントと共に送信した公開 RSA キーと一致します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-249">The public key included in the [**KeyAttestation**](https://msdn.microsoft.com/library/windows/apps/dn298288) blob matches the public RSA key that client sent alongside the attestation statement.</span></span>

<span data-ttu-id="d7be9-250">アプリは、これらの条件によって、さまざまな認証レベルをユーザーに割り当てる場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-250">Your app might assign the user a different authorization level, depending on these conditions.</span></span> <span data-ttu-id="d7be9-251">たとえば、これらの確認項目のいずれかが適切でない場合、ユーザーを登録しない、またはユーザーが実行できる操作を制限することがあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-251">For instance, if one of these checks fail, it might not enroll the user or it might limit what the user can do.</span></span>

## <a name="32-logging-on-with-windows-hello"></a><span data-ttu-id="d7be9-252">3.2 Windows Hello でのログオン</span><span class="sxs-lookup"><span data-stu-id="d7be9-252">3.2 Logging on with Windows Hello</span></span>


<span data-ttu-id="d7be9-253">ユーザーがシステムに登録されると、そのユーザーはアプリを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-253">Once the user is enrolled in your system, he or she can use the app.</span></span> <span data-ttu-id="d7be9-254">シナリオによっては、アプリの使用を開始する前にユーザーに認証を求めたり、バックエンド サービスの使用を開始するときにだけユーザーに認証を求めたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-254">Depending on the scenario, you can ask users to authenticate before they can start using the app or just ask them to authenticate once they start using your backend services.</span></span>

## <a name="33-force-the-user-to-sign-in-again"></a><span data-ttu-id="d7be9-255">3.3 もう一度サインインするようにユーザーに強制する</span><span class="sxs-lookup"><span data-stu-id="d7be9-255">3.3 Force the user to sign in again</span></span>


<span data-ttu-id="d7be9-256">いくつかのシナリオでは、ユーザーが、アプリにアクセスする前、または場合によってはアプリ内の特定の操作を実行する前に、そのユーザーが現在サインインしている人であることの証明を必要とすることがあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-256">For some scenarios, you may want the user to prove he or she is the person who is currently signed in, before accessing the app or sometimes before performing a certain action inside of your app.</span></span> <span data-ttu-id="d7be9-257">たとえば、バンキング アプリが送金のコマンドをサーバーに送信する前に、使用者がユーザー本人であり、ログインされたデバイスを見つけて取引を行おうとしている他の人物ではないことを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-257">For example, before a banking app sends the transfer money command to the server, you want to make sure it is the user, rather than someone who found a logged-in device, attempting to perform a transaction.</span></span> <span data-ttu-id="d7be9-258">[**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) クラスを使って、アプリにもう一度サインインするようにユーザーに強制することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-258">You can force the user to sign in again in your app by using the [**UserConsentVerifier**](https://msdn.microsoft.com/library/windows/apps/dn279134) class.</span></span> <span data-ttu-id="d7be9-259">次のコード行では、資格情報の入力をユーザーに強制します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-259">The following line of code will force the user to enter their credentials.</span></span>

<span data-ttu-id="d7be9-260">次のコード行では、資格情報の入力をユーザーに強制します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-260">The following line of code will force the user to enter their credentials.</span></span>

```cs
UserConsentVerificationResult consentResult = await UserConsentVerifier.RequestVerificationAsync("userMessage");
if (consentResult.Equals(UserConsentVerificationResult.Verified))
{
   // continue
}
```

<span data-ttu-id="d7be9-261">また、サーバーのチャレンジ応答メカニズムを使うこともできます。このメカニズムでは、PIN コードや生体認証の資格情報を入力するようにユーザーに要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-261">Of course, you can also use the challenge response mechanism from the server, which requires a user to enter his or her PIN code or biometric credentials.</span></span> <span data-ttu-id="d7be9-262">シナリオによっては、開発者はこのメカニズムを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-262">It depends on the scenario you as a developer need to implement.</span></span> <span data-ttu-id="d7be9-263">このメカニズムについては、次のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-263">This mechanism is described in the following section.</span></span>

## <a name="34-authentication-at-the-backend"></a><span data-ttu-id="d7be9-264">3.4 バックエンドでの認証</span><span class="sxs-lookup"><span data-stu-id="d7be9-264">3.4 Authentication at the backend</span></span>


<span data-ttu-id="d7be9-265">保護されているバックエンド サービスにアプリがアクセスしようとするとき、そのサービスはチャレンジをアプリに送信します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-265">When the app attempts to access a protected backend service, the service sends a challenge to the app.</span></span> <span data-ttu-id="d7be9-266">アプリはユーザーの秘密キーを使ってチャレンジに署名し、サーバーに返信します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-266">The app uses the private key from the user to sign the challenge and sends it back to the server.</span></span> <span data-ttu-id="d7be9-267">サーバーではそのユーザーの公開キーが保存されているため、標準的な暗号 API を使って、メッセージが適切な秘密キーによって実際に署名されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-267">Since the server has stored the public key for that user, it uses standard crypto APIs to make sure the message was indeed signed with the correct private key.</span></span> <span data-ttu-id="d7be9-268">クライアントでは、署名は Windows Hello の API によって実行され、開発者はどのユーザーの秘密キーにもアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-268">On the client, the signing is done by the Windows Hello APIs; the developer will never have access to any user’s private key.</span></span>

<span data-ttu-id="d7be9-269">キーを確認するだけでなく、サービスでは、キーの構成証明を確認し、デバイスでのキーの保存方法について適用される制限があるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-269">In addition to checking the keys, the service can also check the key attestation and discern if there are any limitations invoked on how the keys are stored on the device.</span></span> <span data-ttu-id="d7be9-270">たとえば、デバイスが TPM を使ってキーを保護する場合は、デバイスが TPM を使わずにキーを保護する場合よりも安全性は高くなります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-270">For example, when the device uses TPM to protect the keys, it is more secure than devices storing the keys without TPM.</span></span> <span data-ttu-id="d7be9-271">また、バックエンド ロジックで、たとえば TPM を使わない場合は、リスクを軽減するためにユーザーに対して一定金額の送金を許可するように指定することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-271">The backend logic could decide, for example, that the user is only allowed to transfer a certain amount of money when no TPM is used to reduce the risks.</span></span>

<span data-ttu-id="d7be9-272">構成証明は、バージョン 2.0 以上の TPM チップを搭載しているデバイスでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-272">Attestation is only available for devices with a TPM chip that’s version 2.0 or higher.</span></span> <span data-ttu-id="d7be9-273">そのため、この構成証明情報がすべてのデバイスで利用できるわけではないということを考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-273">Therefore, you need to take into account that this information might not be available on every device.</span></span>

<span data-ttu-id="d7be9-274">クライアントのワークフローは、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-274">The client workflow might look like the following chart:</span></span>

![Windows Hello クライアントのワークフロー](images/passport-client-workflow.png)

<span data-ttu-id="d7be9-276">アプリがバックエンドでサービスを呼び出すと、サーバーはチャレンジを送信します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-276">When the app calls the service on the backend, the server sends a challenge.</span></span> <span data-ttu-id="d7be9-277">チャレンジは、次のコードで署名されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-277">The challenge is signed with the following code:</span></span>

```cs
var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);

if (openKeyResult.Status == KeyCredentialStatus.Success)
{
    var userKey = openKeyResult.Credential;
    var publicKey = userKey.RetrievePublicKey();
    var signResult = await userKey.RequestSignAsync(message);
    
    if (signResult.Status == KeyCredentialStatus.Success)
    {
        return signResult.Result;
    }
    else if (signResult.Status == KeyCredentialStatus.UserPrefersPassword)
    {
        
    }
}
```

<span data-ttu-id="d7be9-278">最初の行の [**KeyCredentialManager.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn973046) では、キー ハンドルを開くように OS に要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-278">The first line, [**KeyCredentialManager.OpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn973046), will ask the OS to open the key handle.</span></span> <span data-ttu-id="d7be9-279">これが正常に実行された場合、[**KeyCredential.RequestSignAsync**](https://msdn.microsoft.com/library/windows/apps/dn973058) メソッドにより、OS が Windows Hello を利用してユーザーの PIN や生体認証の情報を要求するようにトリガーされるため、チャレンジ メッセージに署名することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-279">If that is done successfully, you can sign the challenge message with the [**KeyCredential.RequestSignAsync**](https://msdn.microsoft.com/library/windows/apps/dn973058) method will trigger the OS to request the user’s PIN or biometrics through Windows Hello.</span></span> <span data-ttu-id="d7be9-280">開発者は、ユーザーの秘密キーにはアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-280">At no time will the developer have access to the private key of the user.</span></span> <span data-ttu-id="d7be9-281">秘密キーに対する処理は、API を使うことにより安全性が保たれます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-281">This is all kept secure through the APIs.</span></span>

<span data-ttu-id="d7be9-282">この API を使って、OS に対して秘密キーを使ってチャレンジに署名するように要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-282">The APIs request the OS to sign the challenge with the private key.</span></span> <span data-ttu-id="d7be9-283">システムでは、PIN コードや構成済みの生体認証ログオンをユーザーに求めます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-283">The system then asks the user for a PIN code or a configured biometric logon.</span></span> <span data-ttu-id="d7be9-284">適切な情報が入力されると、システムは、暗号化関数を実行してチャレンジに署名するように TPM に要求します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-284">When the correct information is entered, the system can ask the TPM chip to perform the cryptographic functions and sign the challenge.</span></span> <span data-ttu-id="d7be9-285">(TPM を利用できない場合は、フォールバック ソフトウェア ソリューションを使います)。</span><span class="sxs-lookup"><span data-stu-id="d7be9-285">(Or use the fallback software solution, if no TPM is available).</span></span> <span data-ttu-id="d7be9-286">クライアントは、署名されたチャレンジをサーバーに返信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-286">The client must send the signed challenge back to the server.</span></span>

<span data-ttu-id="d7be9-287">チャレンジ – 応答の基本フローを次のシーケンス図に示します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-287">A basic challenge–response flow is shown in this sequence diagram:</span></span>

![Windows Hello のチャレンジ応答](images/passport-challenge-response.png)

<span data-ttu-id="d7be9-289">次に、サーバーは署名を検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-289">Next, the server must validate the signature.</span></span> <span data-ttu-id="d7be9-290">公開キーを要求し、以降の検証用にサーバーに送ると、そのキーは ASN.1 でエンコードされた publicKeyInfo BLOB に格納されます。[GitHub の Windows Hello コード サンプル](http://go.microsoft.com/fwlink/?LinkID=717812)では、Crypt32 の関数をラップしてヘルパー クラスを作成し、ASN.1 エンコードされた BLOB をよく使われる CNG BLOB に変換するために使っています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-290">When you request the public key and send it to the server to use for future validation, it is in an ASN.1-encoded publicKeyInfo blob.If you look at the [Windows Hello code sample on GitHub](http://go.microsoft.com/fwlink/?LinkID=717812), you will see there are helper classes to wrap Crypt32 functions to translate the ASN.1-encoded blob to a CNG blob, which is more commonly used.</span></span> <span data-ttu-id="d7be9-291">この BLOB には、RSA と RSA 公開キーに関する公開キー アルゴリズムが格納されています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-291">The blob contains the public key algorithm, which is RSA, and the RSA public key.</span></span>

<span data-ttu-id="d7be9-292">CNG BLOB を作成したら、署名されたチャレンジをユーザーの公開キーに対して検証する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-292">Once you have the CNG blob, you need to validate the signed challenge against the public key of the user.</span></span> <span data-ttu-id="d7be9-293">各ユーザーは独自のシステムまたはバックエンド テクノロジを使うので、このロジックを実装する汎用的な方法はありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-293">Since everyone uses his or her own system or backend technology, there is no generic way to implement this logic.</span></span> <span data-ttu-id="d7be9-294">ハッシュ アルゴリズムとして SHA256 が使われ、また SignaturePadding の Pkcs1 も使われているので、クライアントからの署名済み応答を検証するときに何を使うかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-294">We are using SHA256 as the hash algorithm and Pkcs1 for SignaturePadding, so make sure that’s what you use when you validate the signed response from the client.</span></span> <span data-ttu-id="d7be9-295">また、.NET 4.6 でサーバー側のこのロジックを実装するための方法に関するサンプルが示されていますが、一般的には次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-295">Again, refer to the sample for a way to do it on your server in .NET 4.6, but in general it will look something like this:</span></span>

```cs
using (RSACng pubKey = new RSACng(publicKey))
{
   retval = pubKey.VerifyData(originalChallenge, responseSignature,  HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1); 
}
```

<span data-ttu-id="d7be9-296">保存されている公開キー (RSA キー) を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-296">We read the stored public key, which is an RSA key.</span></span> <span data-ttu-id="d7be9-297">署名されたチャレンジ メッセージを公開キーを使って検証し、これが確認できたら、ユーザーが承認されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-297">We validate the signed challenge message with the public key and if this checks out, we authorize the user.</span></span> <span data-ttu-id="d7be9-298">ユーザーが認証されると、アプリは通常どおりバックエンド サービスを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-298">If the user is authenticated, the app can call the backend services as normal.</span></span>

<span data-ttu-id="d7be9-299">完全なコードは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-299">The complete code might look something like the following:</span></span>

```cs
using System;
using System.Runtime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Security.Credentials;

static async Task<IBuffer> GetAuthenticationMessageAsync(IBuffer message, String AccountId)
{
    var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);

    if (openKeyResult.Status == KeyCredentialStatus.Success)
    {
        var userKey = openKeyResult.Credential;
        var publicKey = userKey.RetrievePublicKey();
        var signResult = await userKey.RequestSignAsync(message);
        if (signResult.Status == KeyCredentialStatus.Success)
        {
            return signResult.Result;
        }
        else if (signResult.Status == KeyCredentialStatus.UserCanceled)
        {
            // Launch app-specific flow to handle the scenario 
            return null;
        }
    }
    else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
    {
        // PIN reset has occurred somewhere else and key is lost.
        // Repeat key registration
        return null;
    }
    else
    {
        // Show custom UI because unknown error has happened.
        return null;
    }
}
```

<span data-ttu-id="d7be9-300">適切なチャレンジ – 応答メカニズムの実装は、このドキュメントでは説明しません。ただし、このトピックでは、リプレイ攻撃や man-in-the-middle 攻撃などを回避する安全なメカニズムを作成するために注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-300">Implementing the correct challenge–response mechanism is outside the scope of this document, but this topic is something that requires attention in order to successfully create a secure mechanism to prevent things like replay attacks or man-in-the-middle attacks.</span></span>

## <a name="35-enrolling-another-device"></a><span data-ttu-id="d7be9-301">3.5 別のデバイスの登録</span><span class="sxs-lookup"><span data-stu-id="d7be9-301">3.5 Enrolling another device</span></span>


<span data-ttu-id="d7be9-302">今日では、ユーザーが所有している複数のデバイスに同じアプリがインストールされていることが一般的になっています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-302">Nowadays, it is common for users to have multiple devices with the same apps installed.</span></span> <span data-ttu-id="d7be9-303">複数のデバイスで Windows Hello を使うとどのように機能するのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="d7be9-303">How does this work when using Windows Hello with multiple devices?</span></span>

<span data-ttu-id="d7be9-304">Windows Hello を使うと、各デバイスで、固有の秘密キーと公開キーのセットが作成されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-304">When using Windows Hello every device will create a unique private and public key set.</span></span> <span data-ttu-id="d7be9-305">これは、ユーザーが複数のデバイスを使えるようにするには、バックエンドでこのユーザーの複数の公開キーを保存できる必要があることを意味します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-305">This means that if you want a user to be able to use multiple devices, your backend must be able to store multiple public keys from this user.</span></span> <span data-ttu-id="d7be9-306">テーブル構造の例としては、セクション 2.1 のデータベースの図をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7be9-306">Refer to the database diagram in section 2.1 for an example of the table structure.</span></span>

<span data-ttu-id="d7be9-307">別のデバイスの登録は、ユーザーを初めて登録する方法とほとんど同じです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-307">Registering another device is almost the same as registering a user for the first time.</span></span> <span data-ttu-id="d7be9-308">デバイスを登録するユーザーが、登録を求めている本人であるかどうかを確認する必要がまだあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-308">You still need to be sure the user registering for this new device is really the user he or she claims to be.</span></span> <span data-ttu-id="d7be9-309">この確認は、現在使っている 2 要素認証メカニズムに基づいて行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-309">You can do so with any two-factor authentication mechanism that is used today.</span></span> <span data-ttu-id="d7be9-310">セキュリティで保護された手段を利用してこの確認を行う方法はいくつかありますが、</span><span class="sxs-lookup"><span data-stu-id="d7be9-310">There are several ways to accomplish this in a secure way.</span></span> <span data-ttu-id="d7be9-311">どの方法を採用するかは、シナリオによって異なります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-311">It all depends on your scenario.</span></span>

<span data-ttu-id="d7be9-312">たとえば、ログイン名とパスワードによる認証方法を使っている場合は、その方法を利用してユーザーを認証し、SMS やメールなどの検証方法の 1 つを使用するようユーザーに求めることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-312">For example, if you still use login name and password you can use that to authenticate the user and ask them to use one of their verification methods like SMS or email.</span></span> <span data-ttu-id="d7be9-313">ログイン名とパスワードを使っていない場合は、既に登録されているいずれかのデバイスを使い、そのデバイス上のアプリに通知を送信することもできます </span><span class="sxs-lookup"><span data-stu-id="d7be9-313">If you don’t have a login name and password, you can also use one of the already registered devices and send a notification to the app on that device.</span></span> <span data-ttu-id="d7be9-314">その一例として MSA 認証アプリがあります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-314">The MSA authenticator app is an example of this.</span></span> <span data-ttu-id="d7be9-315">つまり、一般的な 2FA メカニズムを使って、ユーザーの追加のデバイスを登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-315">In short, you should use a common 2FA mechanism to register extra devices for the user.</span></span>

<span data-ttu-id="d7be9-316">新しいデバイスを登録するコードは、(アプリ内から) ユーザーを初めて登録する場合とまったく同じになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-316">The code to register the new device is exactly the same as registering the user for the first time (from within the app).</span></span>

```cs
var keyCreationResult = await KeyCredentialManager.RequestCreateAsync(
    AccountId, KeyCredentialCreationOption.ReplaceExisting);
```

<span data-ttu-id="d7be9-317">登録されているデバイスをユーザーが簡単に認識できるようにするために、登録の一環として、デバイス名や他の識別子を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-317">To make it easier for the user to recognize which devices are registered, you can choose to send the device name or another identifier as part of the registration.</span></span> <span data-ttu-id="d7be9-318">これは、たとえばサービスをバックエンドに実装する場合、デバイスを紛失したためにユーザーがデバイスの登録を解除するときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-318">This is also useful, for example, if you want to implement a service on your backend where users can unregister devices when a device is lost.</span></span>

## <a name="36-using-multiple-accounts-in-your-app"></a><span data-ttu-id="d7be9-319">3.6 アプリでの複数のアカウントの使用</span><span class="sxs-lookup"><span data-stu-id="d7be9-319">3.6 Using multiple accounts in your app</span></span>


<span data-ttu-id="d7be9-320">1 つのアカウントに対して複数のデバイスをサポートすることに加え、1 つのアプリで複数のアカウントをサポートすることも一般的です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-320">In addition to supporting multiple devices for a single account, it is also common to support multiple accounts in a single app.</span></span> <span data-ttu-id="d7be9-321">たとえば、1 つのアプリから複数の Twitter アカウントに接続している場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-321">For example, maybe you are connecting to multiple Twitter accounts from within your app.</span></span> <span data-ttu-id="d7be9-322">Windows Hello を利用すれば、キーのペアを複数作成し、アプリ内で複数のアカウントをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-322">With Windows Hello, you can create multiple key pairs and support multiple accounts inside your app.</span></span>

<span data-ttu-id="d7be9-323">そのための方法の 1 つは、前の章で説明したユーザー名や一意の識別子を分離ストレージに保存する方法です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-323">One way of doing this is keeping the username or unique identifier described in the previous chapter in isolated storage.</span></span> <span data-ttu-id="d7be9-324">したがって、新しいアカウントを作成するたびに、アカウント ID を分離ストレージに保存します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-324">Therefore, every time you create a new account, you store the account ID in isolated storage.</span></span>

<span data-ttu-id="d7be9-325">アプリの UI では、ユーザーが、事前に作成済みのアカウントのいずれかを選べるか、または新しいアカウントでサインアップできるようにします。</span><span class="sxs-lookup"><span data-stu-id="d7be9-325">In the app UI, you allow the user to either choose one of the previously created accounts or sign up with a new one.</span></span> <span data-ttu-id="d7be9-326">新しいアカウントを作成するフローは、前に説明したフローと同じになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-326">The flow of creating a new account is the same as described before.</span></span> <span data-ttu-id="d7be9-327">アカウントを選ぶ場合は、保存されているアカウントの一覧を画面に表示する方法が課題となります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-327">Choosing an account is a matter of listing the stored accounts on the screen.</span></span> <span data-ttu-id="d7be9-328">ユーザーがアカウントを選ぶと、そのアカウント ID で、ユーザーはアプリにログオンします。</span><span class="sxs-lookup"><span data-stu-id="d7be9-328">Once the user selects an account, use the account ID to log on the user in your app:</span></span>

```cs
var openKeyResult = await KeyCredentialManager.OpenAsync(AccountId);
```

<span data-ttu-id="d7be9-329">フローの他の部分は、前に説明したフローと同じになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-329">The rest of the flow is the same as described earlier.</span></span> <span data-ttu-id="d7be9-330">もちろん、これらすべてのアカウントは同じ PIN または生体認証ジェスチャによって保護されます。このシナリオでは、これらは、同じ Windows アカウントを用いて 1 つのデバイス上で使われているためです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-330">To be clear, all these accounts are protected by the same PIN or biometric gesture since in this scenario they are being used on a single device with the same Windows Account.</span></span>

## <a name="4-migrating-an-existing-system-to-windows-hello"></a><span data-ttu-id="d7be9-331">4 既存のシステムを Windows Hello に移行する</span><span class="sxs-lookup"><span data-stu-id="d7be9-331">4 Migrating an Existing System to Windows Hello</span></span>


<span data-ttu-id="d7be9-332">この短いセクションでは、ユニバーサル Windows プラットフォーム アプリが既にあり、ユーザー名とハッシュされたパスワードが保存されているデータベースを使うバックエンド システムがある場合を扱います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-332">In this short section, we will address an existing Universal Windows Platform app and backend system that uses a database that stores the username and hashed password.</span></span> <span data-ttu-id="d7be9-333">これらのアプリでは、起動時にユーザーから資格情報を収集し、バックエンド システムが認証チャレンジを返すときに、これらの資格情報を使います。</span><span class="sxs-lookup"><span data-stu-id="d7be9-333">These apps collect credentials from the user when the app starts and use them when the backend system returns the authentication challenge.</span></span>

<span data-ttu-id="d7be9-334">ここでは、Windows Hello が動作するためには、何を変更し、何を置き換える必要があるかを説明します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-334">Here, we will describe what pieces need to be changed or replaced to make Windows Hello work.</span></span>

<span data-ttu-id="d7be9-335">ほとんどの手法については、これまでの章で既に説明しました。</span><span class="sxs-lookup"><span data-stu-id="d7be9-335">We have already described most of the techniques in the earlier chapters.</span></span> <span data-ttu-id="d7be9-336">既存のシステムに Windows Hello を追加する場合、コード上の登録と認証の部分にいくつかの異なるフローを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-336">Adding Windows Hello to your existing system involves adding a couple of different flows in the registration and authentication part of your code.</span></span>

<span data-ttu-id="d7be9-337">1 つのアプローチとして、いつアップグレードするかをユーザーが選べるようにする方法があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-337">One approach is to let the user choose when to upgrade.</span></span> <span data-ttu-id="d7be9-338">ユーザーがアプリにログオンし、アプリと OS が Windows Hello をサポートできることを検出した後で、この最新かつセキュリティ保護されたシステムを使うために、資格情報をアップグレードするかどうかをユーザーに問い合わせる方法があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-338">After the user logs on to the app and you detect that the app and OS are capable of supporting Windows Hello, you can ask the user if he or she wants to upgrade credentials to use this modern and more secure system.</span></span> <span data-ttu-id="d7be9-339">次のコードを利用して、ユーザーが Windows Hello を使うことができるかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-339">You can use the following code to check whether the user is capable of using Windows Hello.</span></span>

```cs
var keyCredentialAvailable = await KeyCredentialManager.IsSupportedAsync();
```

<span data-ttu-id="d7be9-340">UI は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-340">The UI might look something like this:</span></span>

![Windows Hello の UI](images/passport-ui.png)

<span data-ttu-id="d7be9-342">ユーザーが Windows Hello を使うことにした場合、前に説明した [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-342">If the user elects to start using Windows Hello, you create the [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) described before.</span></span> <span data-ttu-id="d7be9-343">バックエンドの登録サーバーでは、公開キーとオプションの構成証明ステートメントをデータベースに追加します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-343">The backend registration server adds the public key and optional attestation statement to the database.</span></span> <span data-ttu-id="d7be9-344">ユーザーはユーザー名とパスワードで既に認証されているため、サーバーではこの新しい資格情報をデータベース内の現在のユーザー情報にリンクできます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-344">Because the user is already authenticated with username and password, the server can link the new credentials to the current user information in the database.</span></span> <span data-ttu-id="d7be9-345">データベース モデルは、前に説明した例と同じである場合があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-345">The database model could be the same as the example described earlier.</span></span>

<span data-ttu-id="d7be9-346">アプリは、ユーザーの [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029) を作成できた場合、アプリを再起動したときにユーザーが一覧からアカウントを選ぶことができるように、ユーザー ID を分離ストレージに保存します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-346">If the app was able to create the users [**KeyCredential**](https://msdn.microsoft.com/library/windows/apps/dn973029), it stores the user ID in isolated storage so the user can pick this account from the list once the app is started again.</span></span> <span data-ttu-id="d7be9-347">これ以降、フローはこれまでの章で説明した例とまったく同じものとなります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-347">From this point on, the flow exactly follows the examples described in earlier chapters.</span></span>

<span data-ttu-id="d7be9-348">Windows Hello の完全なシナリオへ移行する最後の手順では、アプリでログオン名とパスワードのオプションを無効にし、保存されているハッシュ済みのパスワードをデータベースから削除します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-348">The final step in migrating to a full Windows Hello scenario is disabling the logon name and password option in the app and removing the stored hashed passwords from your database.</span></span>

## <a name="5-summary"></a><span data-ttu-id="d7be9-349">5 まとめ</span><span class="sxs-lookup"><span data-stu-id="d7be9-349">5 Summary</span></span>


<span data-ttu-id="d7be9-350">Windows 10 には、簡単に実現できる、高いレベルのセキュリティが導入されています。</span><span class="sxs-lookup"><span data-stu-id="d7be9-350">Windows 10 introduces a higher level of security that is also simple to put into practice.</span></span> <span data-ttu-id="d7be9-351">Windows Hello によって、ユーザーを認識する新しい生体認証サインイン システムが提供されます。また、Windows Hello を使うことで、正しい ID を意図的に回避するような操作をアクティブに阻止することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-351">Windows Hello provides a new biometric sign-in system that recognizes the user and actively defeats efforts to circumvent proper identification.</span></span> <span data-ttu-id="d7be9-352">この結果、キーと証明書に関する複数の層を提供できます。これらの層は、トラステッド プラットフォーム モジュールの外部で公開されたり、使われたりすることは決してありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-352">It can then deliver multiple layers of keys and certificates that can never be revealed or used outside the trusted platform module.</span></span> <span data-ttu-id="d7be9-353">また、より詳細なセキュリティ レイヤーを、オプションである構成証明識別キーや証明書の利用時に使うことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-353">In addition, a further layer of security is available through the optional use of attestation identity keys and certificates.</span></span>

<span data-ttu-id="d7be9-354">これらのテクノロジの設計や展開を行うときに開発者がこのガイダンスを利用すると、セキュリティ保護された認証を Windows 10 のロールアウトに簡単に追加して、アプリやバックエンド サービスを保護することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-354">As a developer, you can use this guidance on design and deployment of these technologies to easily add secure authentication to your Windows 10 rollouts to protect apps and backend services.</span></span> <span data-ttu-id="d7be9-355">必要なコードは最小限に抑えられ、簡単に理解することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-355">The code required is minimal and easy to understand.</span></span> <span data-ttu-id="d7be9-356">難しい処理は、Windows 10 が実行します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-356">Windows 10 does the heavy lifting.</span></span>

<span data-ttu-id="d7be9-357">柔軟な実装オプションによって、Windows Hello は、既にある認証システムに合わせて、置き換えを行ったり、動作したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-357">Flexible implementation options allow Windows Hello to replace or work alongside your existing authentication system.</span></span> <span data-ttu-id="d7be9-358">展開エクスペリエンスは簡単で経済的に行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-358">The deployment experience is painless and economical.</span></span> <span data-ttu-id="d7be9-359">Windows 10 のセキュリティを展開する際に、追加のインフラストラクチャは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="d7be9-359">No additional infrastructure is needed to deploy Windows 10 security.</span></span> <span data-ttu-id="d7be9-360">Microsoft Hello はオペレーティング システムに組み込まれており、Windows 10 によって、現代の開発者が直面する認証の問題に対して安全性が最も高いソリューションが提供されます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-360">With Microsoft Hello built in to the operating system, Windows 10 offers the most secure solution to the authentication problems facing the modern developer.</span></span>

<span data-ttu-id="d7be9-361">任務完了!</span><span class="sxs-lookup"><span data-stu-id="d7be9-361">Mission accomplished!</span></span> <span data-ttu-id="d7be9-362">これでインターネットがより安全な場所になりました!</span><span class="sxs-lookup"><span data-stu-id="d7be9-362">You just made the Internet a safer place!</span></span>

## <a name="6-resources"></a><span data-ttu-id="d7be9-363">6 リソース</span><span class="sxs-lookup"><span data-stu-id="d7be9-363">6 Resources</span></span>


### <a name="61-articles-and-sample-code"></a><span data-ttu-id="d7be9-364">6.1 記事とサンプル コード</span><span class="sxs-lookup"><span data-stu-id="d7be9-364">6.1 Articles and sample code</span></span>

-   [<span data-ttu-id="d7be9-365">Windows Hello の概要</span><span class="sxs-lookup"><span data-stu-id="d7be9-365">Windows Hello overview</span></span>](http://windows.microsoft.com/windows-10/getstarted-what-is-hello)
-   [<span data-ttu-id="d7be9-366">Windows Hello の実装の詳細</span><span class="sxs-lookup"><span data-stu-id="d7be9-366">Implementation details for Windows Hello</span></span>](https://msdn.microsoft.com/library/mt589441)
-   [<span data-ttu-id="d7be9-367">GitHub の Windows Hello コード サンプル</span><span class="sxs-lookup"><span data-stu-id="d7be9-367">Windows Hello code sample on GitHub</span></span>](http://go.microsoft.com/fwlink/?LinkID=717812)

### <a name="62-terminology"></a><span data-ttu-id="d7be9-368">6.2 用語</span><span class="sxs-lookup"><span data-stu-id="d7be9-368">6.2 Terminology</span></span>

|                     |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|---------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="d7be9-369">AIK</span><span class="sxs-lookup"><span data-stu-id="d7be9-369">AIK</span></span>                 | <span data-ttu-id="d7be9-370">構成証明識別キー (AIK) を使って、暗号証明 (TPM キーの構成証明) などを提供します。そのためには、移行不可能なキーのプロパティに署名し、そのプロパティと署名を検証のために証明書利用者に提供します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-370">An attestation identity key is used to provide such a cryptographic proof (TPM key attestation) by signing the properties of the non-migratable key and providing the properties and signature to the relying party for verification.</span></span> <span data-ttu-id="d7be9-371">このプロパティへの署名は、"構成証明ステートメント" と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-371">The resulting signature is called an “attestation statement.”</span></span> <span data-ttu-id="d7be9-372">署名は AIK 秘密キー (このキーを作成した TPM でのみ利用できます) を使って作成されるため、証明書利用者は、証明されたキーが実際に移行不可能であり、TPM の外部で利用できないことを信頼することができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-372">Since the signature is created using the AIK private key—which can only be used in the TPM that created it—the relying party can trust that the attested key is truly non-migratable and cannot be used outside that TPM.</span></span> |
| <span data-ttu-id="d7be9-373">AIK 証明書</span><span class="sxs-lookup"><span data-stu-id="d7be9-373">AIK Certificate</span></span>     | <span data-ttu-id="d7be9-374">AIK 証明書は、TPM 内に AIK が存在すること証明するために使われます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-374">An AIK certificate is used to attest to the presence of an AIK within a TPM.</span></span> <span data-ttu-id="d7be9-375">また、特定の TPM の AIK によって認証された他のキーを証明する場合にも使われます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-375">It is also used to attest that other keys certified by the AIK originated from that particular TPM.</span></span>                                                                                                                                                                                                                                                                                                                                              |
| <span data-ttu-id="d7be9-376">IDP</span><span class="sxs-lookup"><span data-stu-id="d7be9-376">IDP</span></span>                 | <span data-ttu-id="d7be9-377">IDP とは ID プロバイダーを表します。</span><span class="sxs-lookup"><span data-stu-id="d7be9-377">An IDP is an identity provider.</span></span> <span data-ttu-id="d7be9-378">例として、Microsoft アカウント用に Microsoft が作成した IDP があります。</span><span class="sxs-lookup"><span data-stu-id="d7be9-378">An example is the IDP build by Microsoft for Microsoft Accounts.</span></span> <span data-ttu-id="d7be9-379">アプリケーションで MSA を使った認証を行うたびに、MSA IDP を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-379">Every time an application needs to authenticate with an MSA, it can call the MSA IDP.</span></span>                                                                                                                                                                                                                                                                                                                                        |
| <span data-ttu-id="d7be9-380">PKI</span><span class="sxs-lookup"><span data-stu-id="d7be9-380">PKI</span></span>                 | <span data-ttu-id="d7be9-381">公開キー基盤 (PKI) は、一般的に、組織によってホストされ、キーの作成やキーの失効などを行う環境を示す際に使われる用語です。</span><span class="sxs-lookup"><span data-stu-id="d7be9-381">Public key infrastructure is commonly used to point to an environment hosted by an organization itself and being responsible for creating keys, revoking keys, etc.</span></span>                                                                                                                                                                                                                                                                                                                                                           |
| <span data-ttu-id="d7be9-382">TPM</span><span class="sxs-lookup"><span data-stu-id="d7be9-382">TPM</span></span>                 | <span data-ttu-id="d7be9-383">トラステッド プラットフォーム モジュール (TPM) を使って、暗号化された公開/秘密キーのペアを作成できます。作成された秘密キーは、TPM の外部で公開されたり、使われたりすることは決してありません (つまり、キーは移行できません)。</span><span class="sxs-lookup"><span data-stu-id="d7be9-383">The trusted platform module can be used to create cryptographic public/private key pairs in such a way that the private key can never be revealed or used outside the TPM (that is, the key is non-migratable).</span></span>                                                                                                                                                                                                                                                                                                               |
| <span data-ttu-id="d7be9-384">TPM キーの構成証明</span><span class="sxs-lookup"><span data-stu-id="d7be9-384">TPM Key Attestation</span></span> | <span data-ttu-id="d7be9-385">キーが TPM にバインドされていることを暗号で証明するプロトコルです。</span><span class="sxs-lookup"><span data-stu-id="d7be9-385">A protocol that cryptographically proves that a key is TPM-bound.</span></span> <span data-ttu-id="d7be9-386">この種類の構成証明を使うことで、特定の暗号化操作が特定のコンピューターの TPM で行われたことを保証できます。</span><span class="sxs-lookup"><span data-stu-id="d7be9-386">This type of attestation can be used to guarantee that a certain cryptographic operation occurred in the TPM of a particular computer</span></span>                                                                                                                                                                                                                                                                                                                       |

 

## <a name="related-topics"></a><span data-ttu-id="d7be9-387">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d7be9-387">Related topics</span></span>

* [<span data-ttu-id="d7be9-388">Windows Hello ログイン アプリ</span><span class="sxs-lookup"><span data-stu-id="d7be9-388">Windows Hello login app</span></span>](microsoft-passport-login.md)
* [<span data-ttu-id="d7be9-389">Windows Hello ログイン サービス</span><span class="sxs-lookup"><span data-stu-id="d7be9-389">Windows Hello login service</span></span>](microsoft-passport-login-auth-service.md)