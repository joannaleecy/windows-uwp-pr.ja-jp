---
author: msatranjr
ms.assetid: 26834A51-512B-485B-84C8-ABF713787588
title: NFC スマート カード アプリの作成
description: Windows Phone 8.1 では、SIM ベースのセキュア エレメントを使用する NFC カード エミュレーション アプリがサポートされていましたが、このモデルでは、安全な支払いアプリと移動体通信事業者 (MNO) 様との密接な連携が必要でした。
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: bf8d5f1587cc27082944cf0fc63edc274cb2bc7d
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6971116"
---
# <a name="create-an-nfc-smart-card-app"></a><span data-ttu-id="5ec65-104">NFC スマート カード アプリの作成</span><span class="sxs-lookup"><span data-stu-id="5ec65-104">Create an NFC Smart Card app</span></span>


<span data-ttu-id="5ec65-105">**重要な**このトピックでは windows 10 Mobile にのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-105">**Important**This topic applies to Windows10 Mobile only.</span></span>

<span data-ttu-id="5ec65-106">Windows Phone 8.1 では、SIM ベースのセキュア エレメントを使用する NFC カード エミュレーション アプリがサポートされていましたが、このモデルでは、安全な支払いアプリと移動体通信事業者 (MNO) 様との密接な連携が必要でした。</span><span class="sxs-lookup"><span data-stu-id="5ec65-106">Windows Phone 8.1 supported NFC card emulation apps using a SIM-based secure element, but that model required secure payment apps to be tightly coupled with mobile-network operators (MNO).</span></span> <span data-ttu-id="5ec65-107">このことにより、MNO 様と連携していないために、他の事業者様や開発者様によるさまざまな支払いソリューションの可能性が制限されていました。</span><span class="sxs-lookup"><span data-stu-id="5ec65-107">This limited the variety of possible payment solutions by other merchants or developers that are not coupled with MNOs.</span></span> <span data-ttu-id="5ec65-108">Windows 10 Mobile では、ホスト カード エミュレーション (HCE) と呼ばれる新しいカード エミュレーション テクノロジを導入しましたがあります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-108">In Windows10 Mobile, we have introduced a new card emulation technology called, Host Card Emulation (HCE).</span></span> <span data-ttu-id="5ec65-109">HCE テクノロジを使用すると、アプリが NFC カード リーダーと直接通信することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-109">HCE technology allows your app to directly communicate with an NFC card reader.</span></span> <span data-ttu-id="5ec65-110">このトピックでは、windows 10 Mobile のデバイスでのホスト カード エミュレーション (HCE) のしくみし、ユーザーがアクセスできるように、サービスを通じて、物理的なカードではなく、自分の電話を MNO と連携せず、HCE アプリを開発する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-110">This topic illustrates how Host Card Emulation (HCE) works on Windows10 Mobile devices and how you can develop an HCE app so that your customers can access your services through their phone instead of a physical card without collaborating with an MNO.</span></span>

## <a name="what-you-need-to-develop-an-hce-app"></a><span data-ttu-id="5ec65-111">HCE アプリの開発に必要な要素</span><span class="sxs-lookup"><span data-stu-id="5ec65-111">What you need to develop an HCE app</span></span>


<span data-ttu-id="5ec65-112">Windows 10 mobile では、HCE ベースのカード エミュレーション アプリを開発するには、開発環境のセットアップを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-112">To develop an HCE-based card emulation app for Windows10 Mobile, you will need to get your development environment setup.</span></span> <span data-ttu-id="5ec65-113">Windows 開発者ツールと、windows 10 Mobile エミュレーター NFC エミュレーションがサポートを含む Microsoft Visual Studio2015 をインストールすることによって設定を取得することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-113">You can get set up by installing Microsoft Visual Studio2015, which includes the Windows developer tools and the Windows10 Mobile emulator with NFC emulation support.</span></span> <span data-ttu-id="5ec65-114">セットアップの詳細については、「[準備](https://msdn.microsoft.com/library/windows/apps/Dn726766)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-114">For more information about getting setup, see, [Get set up](https://msdn.microsoft.com/library/windows/apps/Dn726766)</span></span>

<span data-ttu-id="5ec65-115">必要に応じて、windows 10 Mobile エミュレーターではなく実際の windows 10 Mobile デバイスをテストする場合は、次の項目も必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-115">Optionally, if you want to test with a real Windows10 Mobile device instead of the included Windows10 Mobile emulator, you will also need the following items.</span></span>

-   <span data-ttu-id="5ec65-116">NFC HCE サポートを持つ windows 10 Mobile デバイス。</span><span class="sxs-lookup"><span data-stu-id="5ec65-116">A Windows10 Mobile device with NFC HCE support.</span></span> <span data-ttu-id="5ec65-117">現時点で、NFC HCE アプリをサポートするハードウェアは Lumia 730、830、640、640 XL に搭載されています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-117">Currently, the Lumia 730, 830, 640, and the 640 XL have the hardware to support NFC HCE apps.</span></span>
-   <span data-ttu-id="5ec65-118">プロトコルとして ISO/IEC 14443-4 および ISO/IEC 7816-4 をサポートするリーダー端末。</span><span class="sxs-lookup"><span data-stu-id="5ec65-118">A reader terminal that supports protocols ISO/IEC 14443-4 and ISO/IEC 7816-4</span></span>

<span data-ttu-id="5ec65-119">Windows 10 Mobile では、次の機能を提供する HCE サービスを実装します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-119">Windows10 Mobile implements an HCE service that provides the following functionalities.</span></span>

-   <span data-ttu-id="5ec65-120">エミュレートするカード用のアプレット識別子 (AID) をアプリで登録できる。</span><span class="sxs-lookup"><span data-stu-id="5ec65-120">Apps can register the applet identifiers (AIDs) for the cards they would like to emulate.</span></span>
-   <span data-ttu-id="5ec65-121">外部リーダー カードの選択とユーザー設定に基づいて、アプリケーション プロトコル データ ユニット (APDU) のコマンドと応答のペアをいずれかの登録済みアプリにルーティングし、競合を解決する。</span><span class="sxs-lookup"><span data-stu-id="5ec65-121">Conflict resolution and routing of the Application Protocol Data Unit (APDU) command and response pairs to one of the registered apps based on the external reader card selection and user preference.</span></span>
-   <span data-ttu-id="5ec65-122">ユーザー操作の結果としてイベントとアプリへの通知を処理する。</span><span class="sxs-lookup"><span data-stu-id="5ec65-122">Handling of events and notifications to the apps as a result of user actions.</span></span>

<span data-ttu-id="5ec65-123">Windows 10 には、ISO DEP に基づくスマート カードのエミュレーションがサポートしています (ISO-IEC 14443-4) で定義されている ISO-IEC 7816-4 仕様の Apdu を使用した通信とします。</span><span class="sxs-lookup"><span data-stu-id="5ec65-123">Windows10 supports emulation of smart cards that are based on ISO-DEP (ISO-IEC 14443-4) and communicates using APDUs as defined in the ISO-IEC 7816-4 specification.</span></span> <span data-ttu-id="5ec65-124">Windows 10 では、HCE アプリ用 ISO/IEC 14443-4 Type A テクノロジをサポートします。</span><span class="sxs-lookup"><span data-stu-id="5ec65-124">Windows10 supports ISO/IEC 14443-4 Type A technology for HCE apps.</span></span> <span data-ttu-id="5ec65-125">Type B、Type F、非 ISO-DEP (MIFARE など) のテクノロジは、既定では SIM にルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-125">Type B, type F, and non-ISO-DEP (eg MIFARE) technologies are routed to the SIM by default.</span></span>

<span data-ttu-id="5ec65-126">カード エミュレーション機能では、windows 10 Mobile デバイスのみが有効になります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-126">Only Windows10 Mobile devices are enabled with the card emulation feature.</span></span> <span data-ttu-id="5ec65-127">SIM ベースおよび HCE ベースのカード エミュレーションは、他のバージョンの windows 10 では使用できません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-127">SIM-based and HCE-based card emulation is not available on other versions of Windows10.</span></span>

<span data-ttu-id="5ec65-128">HCE および SIM ベースのカード エミュレーションのサポートのアーキテクチャを、次の図に示します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-128">The architecture for HCE and SIM based card emulation support is shown in the diagram below.</span></span>

![HCE および SIM カード エミュレーションのアーキテクチャ](./images/nfc-architecture.png)

## <a name="app-selection-and-aid-routing"></a><span data-ttu-id="5ec65-130">アプリの選択と AID ルーティング</span><span class="sxs-lookup"><span data-stu-id="5ec65-130">App selection and AID routing</span></span>

<span data-ttu-id="5ec65-131">HCE アプリを開発するには、windows 10 Mobile デバイス Aid ルーティングされるしくみ、特定のアプリをユーザーが複数のさまざまな HCE アプリをインストールできるためを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-131">To develop an HCE app, you must understand how Windows10 Mobile devices route AIDs to a specific app because users can install multiple different HCE apps.</span></span> <span data-ttu-id="5ec65-132">各アプリは、HCE ベースおよび SIM ベースのカードを複数登録できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-132">Each app can register multiple HCE and SIM-based cards.</span></span> <span data-ttu-id="5ec65-133">SIM ベースである従来の Windows Phone 8.1 アプリは引き続き、ユーザーが NFC 設定メニューで、既定の支払い用カードとして「SIM カード」オプションを選択している限り、windows 10 Mobile で動作します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-133">Legacy Windows Phone 8.1 apps that are SIM-based will continue to work on Windows10 Mobile as long as the user chooses the "SIM Card" option as their default payment card in the NFC Setting menu.</span></span> <span data-ttu-id="5ec65-134">これは、初めてデバイスに電源を入れると既定で設定される構成です。</span><span class="sxs-lookup"><span data-stu-id="5ec65-134">This is set by default when turning the device on for the first time.</span></span>

<span data-ttu-id="5ec65-135">ユーザーが自分の windows 10 Mobile デバイスを端末にタップと、データは自動的にデバイスにインストールされている適切なアプリにルーティングします。</span><span class="sxs-lookup"><span data-stu-id="5ec65-135">When the user taps their Windows10 Mobile device to a terminal, the data is automatically routed to the proper app installed on the device.</span></span> <span data-ttu-id="5ec65-136">このルーティングは、5 ～ 16 バイトの識別子であるアプレット ID (AID) に基づいています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-136">This routing is based on the applet IDs (AIDs) which are 5-16 byte identifiers.</span></span> <span data-ttu-id="5ec65-137">タップが発生すると、外部端末は SELECT コマンドの APDU を送出し、後続のすべての APDU コマンドのルーティング先とする AID を指定します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-137">During a tap, the external terminal will transmit a SELECT command APDU to specify the AID it would like all subsequent APDU commands to be routed to.</span></span> <span data-ttu-id="5ec65-138">後続の SELECT コマンドでは、ルーティング先を再度変更できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-138">Subsequent SELECT commands, will change the routing again.</span></span> <span data-ttu-id="5ec65-139">アプリとユーザー設定によって登録されている AID に基づいて、APDU トラフィックが特定のアプリにルーティングされます。ルーティング先のアプリは、応答の APDU を送信します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-139">Based on the AIDs registered by apps and user settings, the APDU traffic is routed to a specific app, which will send a response APDU.</span></span> <span data-ttu-id="5ec65-140">端末側では同じタップで異なる複数のアプリとの通信を必要としている場合もあるので注意してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-140">Be aware that a terminal may want to communicate with several different apps during the same tap.</span></span> <span data-ttu-id="5ec65-141">このため、別のアプリのバックグラウンド タスクが APDU に応答する余地ができるように、アプリのバックグラウンド タスクは、非アクティブ化されたらできる限り早く終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-141">So you must ensure your app's background task exits as quickly as possible when deactivated to make room for another app's background task to respond to the APDU.</span></span> <span data-ttu-id="5ec65-142">バックグラウンド タスクについては、後で説明します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-142">We will discuss background tasks later in this topic.</span></span>

<span data-ttu-id="5ec65-143">HCE アプリは、AID の APDU を受信できるように、対応が可能な特定の AID に自身を登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-143">HCE apps must register themselves with particular AIDs they can handle so they will receive APDUs for an AID.</span></span> <span data-ttu-id="5ec65-144">アプリは、AID グループを使用して AID を宣言します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-144">Apps decalre AIDs by using AID groups.</span></span> <span data-ttu-id="5ec65-145">AID グループは、概念的には個々の物理カードに相当します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-145">An AID group is conceptually equivalent to an individual physical card.</span></span> <span data-ttu-id="5ec65-146">たとえば、2 枚のカードの AID が同じであっても、1 枚目のクレジット カードは 1 つ目の AID グループ、別の銀行から発行された 2 枚目のクレジット カードは 2 つ目の AID グループで登録されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-146">For example, one credit card is declared with an AID group and a second credit card from a different bank is declared with a different, second AID group, even though both of them may have the same AID.</span></span>

## <a name="conflict-resolution-for-payment-aid-groups"></a><span data-ttu-id="5ec65-147">支払い AID グループの競合の解決</span><span class="sxs-lookup"><span data-stu-id="5ec65-147">Conflict resolution for payment AID groups</span></span>

<span data-ttu-id="5ec65-148">アプリで物理カード (AID グループ) を登録する際には、AID グループのカテゴリを "Payment" または "Other" として宣言します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-148">When an app registers physical cards (AID groups), it can declare the AID group category as either "Payment" or "Other."</span></span> <span data-ttu-id="5ec65-149">同時に複数の支払い AID グループが登録されることはあり得ますが、"タップして支払い" 用に同時に有効にできる支払い AID グループは、ユーザーによって選択された 1 つのグループのみです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-149">While there can be multiple payment AID groups registered at any given time, only one of these payment AID groups may be enabled for Tap and Pay at a time, which is selected by the user.</span></span> <span data-ttu-id="5ec65-150">これは、デバイスを端末にタップしたときに意図しないカードで支払われることのないよう、単一の支払い用カード、クレジット カード、またはデビット カードをユーザーが自分の意志で選択できるようにするためです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-150">This behavior exists because the user expects be in control of consciously choosing a single payment, credit, or debit card to use so they don't pay with a different unintended card when tapping their device to a terminal.</span></span>

<span data-ttu-id="5ec65-151">ただし、"Other" として登録されている複数の AID グループは、ユーザー操作なしに同時に有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-151">However, multiple AID groups registered as "Other" can be enabled at the same time without user interaction.</span></span> <span data-ttu-id="5ec65-152">これは、他の種類のカード (ロイヤルティ、クーポン、交通機関用など) については、電話をタップするだけで特に操作やユーザー入力を必要とせず役割が果たされるようにするためです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-152">This behavior exists because other types of cards like loyalty, coupons, or transit are expected to just work without any effort or prompting whenever they tap their phone.</span></span>

<span data-ttu-id="5ec65-153">"Payment" として登録された AID グループはすべて、NFC 設定ページのカード一覧に表示されます。この一覧で、ユーザーは既定の支払い用カードを選択できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-153">All the AID groups that are registered as "Payment" appear in the list of cards in the NFC Settings page, where the user can select their default payment card.</span></span> <span data-ttu-id="5ec65-154">既定の支払い用カードが選択されると、この支払い AID グループを登録したアプリが既定の支払いアプリになります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-154">When a default payment card is selected, the app that registered this payment AID group becomes the default payment app.</span></span> <span data-ttu-id="5ec65-155">既定の支払いアプリは、登録されている任意の AID グループをユーザー操作なしで有効または無効に切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-155">Default payment apps can enable or disable any of their AID groups without user interaction.</span></span> <span data-ttu-id="5ec65-156">ユーザーが既定の支払いアプリを確認するメッセージで確認を拒否した場合は、現在の既定の支払いアプリ (ある場合) が引き続き既定として使用されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-156">If the user declines the default payment app prompt, then the current default payment app (if any) continues to remain as default.</span></span> <span data-ttu-id="5ec65-157">次のスクリーン ショットは、NFC 設定ページを示しています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-157">The following screenshot shows the NFC Settings page.</span></span>

![NFC 設定ページのスクリーン ショット](./images/nfc-settings.png)

<span data-ttu-id="5ec65-159">上のスクリーンショットで説明すると、ユーザーが既定の支払い用カードを変更して、"HCE Application 1" によって登録されていない別のカードに切り替えた場合、システムはユーザーによる同意を求めて確認プロンプトを表示します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-159">Using the example screenshot above, if the user changes his default payment card to another card that is not registered by "HCE Application 1," the system creates a confirmation prompt for the user’s consent.</span></span> <span data-ttu-id="5ec65-160">ユーザーが既定の支払い用カードを変更して、"HCE Application 1" によって登録されている別のカードに切り替えた場合、"HCE Application 1" は既に既定の支払いアプリであるため、システムはユーザーに対する確認プロンプトを表示しません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-160">However, if the user changes his default payment card to another card that is registered by "HCE Application 1," the system does not create a confirmation prompt for the user, because "HCE Application1" is already the default payment app.</span></span>

## <a name="conflict-resolution-for-non-payment-aid-groups"></a><span data-ttu-id="5ec65-161">支払い以外の AID グループの競合の解決</span><span class="sxs-lookup"><span data-stu-id="5ec65-161">Conflict resolution for non-payment AID groups</span></span>

<span data-ttu-id="5ec65-162">支払い用以外として "Other" というカテゴリに設定されているカードは、NFC 設定ページには表示されません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-162">Non-payment cards categorized as "Other" do not appear in the NFC settings page.</span></span>

<span data-ttu-id="5ec65-163">アプリでは、支払い AID グループと同じ方法で、支払い用以外の AID グループを作成、登録、有効化することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-163">Your app can create, register and enable non-payment AID groups in the same manner as payment AID groups.</span></span> <span data-ttu-id="5ec65-164">主な違いは、支払い用以外の AID グループについてはエミュレーション カテゴリを "Payment" ではなく "Other" に設定する点です。</span><span class="sxs-lookup"><span data-stu-id="5ec65-164">The main difference is that for non-payment AID groups the emulation category is set to "Other" as opposed to "Payment".</span></span> <span data-ttu-id="5ec65-165">AID グループをシステムに登録した後は、AID グループが NFC トラフィックを受信できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-165">After registering the AID group with the system, you need to enable the AID group to receive NFC traffic.</span></span> <span data-ttu-id="5ec65-166">支払い用以外の AID グループについてトラフィックの受信を有効化する場合、別のアプリによって既にシステムに登録されている AID との競合がない限り、ユーザーに対する確認プロンプトは表示されません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-166">When you try to enable a non-payment AID group to receive traffic, the user is not prompted for a confirmation unless there is a conflict with one of the AIDs already registered in the system by a different app.</span></span> <span data-ttu-id="5ec65-167">競合が存在すると、新しく登録された AID グループの有効化をユーザーが選択した場合に、どのカードと関連するアプリが無効になるかを示す情報と共にユーザーへの確認メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-167">If there is a conflict, the user will be prompted with information about which card and it's associated app will be disabled if the user chooses to enable the newly registered AID group.</span></span>

**<span data-ttu-id="5ec65-168">SIM ベースの NFC アプリケーションとの共存</span><span class="sxs-lookup"><span data-stu-id="5ec65-168">Coexistence with SIM based NFC applications</span></span>**

<span data-ttu-id="5ec65-169">Windows 10 Mobile では、システムは、コント ローラー レイヤーでルーティングの決定に使用される NFC コント ローラー ルーティング テーブルを設定します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-169">In Windows10 Mobile, the system sets up the NFC controller routing table that is used to make routing decisions at the controller layer.</span></span> <span data-ttu-id="5ec65-170">このテーブルには、ルーティング情報として次のアイテムが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-170">The table contains routing information for the following items.</span></span>

-   <span data-ttu-id="5ec65-171">個別の AID ルート。</span><span class="sxs-lookup"><span data-stu-id="5ec65-171">Individual AID routes.</span></span>
-   <span data-ttu-id="5ec65-172">プロトコルに基づくルート (ISO DEP)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-172">Protocol based route (ISO-DEP).</span></span>
-   <span data-ttu-id="5ec65-173">テクノロジに基づくルーティング (NFC-A/B/F)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-173">Technology based routing (NFC-A/B/F).</span></span>

<span data-ttu-id="5ec65-174">外部リーダーにより "SELECT AID" コマンドが送信されると、NFC コントローラーはまずルーティング テーブルに一致する AID ルートがないか確認します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-174">When an external reader sends a "SELECT AID" command, the NFC controller first checks AID routes in the routing table for a match.</span></span> <span data-ttu-id="5ec65-175">一致がない場合、ISO-DEP (14443-4-A) トラフィックに対する既定のルートとしては、プロトコル ベースのルートが使用されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-175">If there is no match, it will use the protocol-based route as the default route for ISO-DEP (14443-4-A) traffic.</span></span> <span data-ttu-id="5ec65-176">その他、非 ISO-DEP のトラフィックについては、テクノロジ ベースのルーティングが使用されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-176">For any other non-ISO-DEP traffic it will use the technology based routing.</span></span>

<span data-ttu-id="5ec65-177">Windows 10 Mobile では、引き続きレガシ Windows Phone 8.1 SIM ベース アプリは登録しないで、Aid システムを使用する NFC 設定ページのメニュー オプション「SIM カード」を提供します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-177">Windows10 Mobile provides a menu option "SIM Card" in the NFC Settings page to continue to use legacy Windows Phone 8.1 SIM-based apps, which do not register their AIDs with the system.</span></span> <span data-ttu-id="5ec65-178">ユーザーが既定の支払い用カードとして "SIM カード" を選択すると、ISO-DEP ルートが UICC に設定されます (ドロップダウン メニュー内の他の選択肢ではすべて、ISO-DEP ルート先はホスト)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-178">If the user selects "SIM card" as their default payment card, then the ISO-DEP route is set to UICC, for all other selections in the drop-down menu the ISO-DEP route is to the host.</span></span>

<span data-ttu-id="5ec65-179">SE 対応の SIM カード デバイスが windows 10 Mobile で初めて起動したときのデバイスの「SIM カード」に、ISO-DEP ルートが設定されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-179">The ISO-DEP route is set to "SIM Card" for devices that have an SE enabled SIM card when the device is booted for the first time with Windows10 Mobile.</span></span> <span data-ttu-id="5ec65-180">ユーザーが HCE 対応のアプリをインストールし、そのアプリでなんらかの HCE AID グループ登録が有効になった場合は、ISO-DEP ルート先がホストになります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-180">When the user installs an HCE enabled app and that app enables any HCE AID group registrations, the ISO-DEP route will be pointed to the host.</span></span> <span data-ttu-id="5ec65-181">新しい SIM ベースのアプリケーションでは、特定の AID ルートがコントローラーのルーティング テーブルに設定されるように、AID を SIM に登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-181">New SIM-based applications need to register the AIDs in the SIM in order for the specific AID routes to be populated in the controller routing table.</span></span>

## <a name="creating-an-hce-based-app"></a><span data-ttu-id="5ec65-182">HCE ベース アプリの作成</span><span class="sxs-lookup"><span data-stu-id="5ec65-182">Creating an HCE based app</span></span>

<span data-ttu-id="5ec65-183">HCE アプリには、2 つの部分があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-183">Your HCE app has two parts.</span></span>

-   <span data-ttu-id="5ec65-184">メインのフォアグラウンド アプリ (ユーザー操作用)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-184">The main foreground app for the user interaction.</span></span>
-   <span data-ttu-id="5ec65-185">指定された AID について APDU を処理するためにシステムによってトリガーされるバックグラウンド タスク。</span><span class="sxs-lookup"><span data-stu-id="5ec65-185">A background task that is triggered by the system to process APDUs for a given AID.</span></span>

<span data-ttu-id="5ec65-186">NFC タップへの応答としてバックグラウンド タスクを読み込む際にはきわめて高いパフォーマンスが求められるため、バックグラウンド タスク全体 (必要な依存関係、参照、ライブラリなどをすべて含めて) を C# やマネージ コードではなく、C++/CX のネイティブ コードで実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5ec65-186">Because of the extremely tight performance requirements for loading your background task in response to an NFC tap, we recommend that your entire background task be implementing in C++/CX native code (including any dependencies, references, or libraries you depend on) rather than C# or managed code.</span></span> <span data-ttu-id="5ec65-187">C# およびマネージ コードは、通常はパフォーマンスに優れていますが、.NET CLR の読み込みなどによるオーバーヘッドが発生します。C++/CX では、これを回避することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-187">While C# and managed code normally performs well, there is overhead, like loading the .NET CLR, that can be avoided by writing it in C++/CX.</span></span>
## <a name="create-and-register-your-background-task"></a><span data-ttu-id="5ec65-188">バックグラウンド タスクの作成と登録</span><span class="sxs-lookup"><span data-stu-id="5ec65-188">Create and register your background task</span></span>

<span data-ttu-id="5ec65-189">システムによってルーティングされた APDU を処理し、これに応答するために、バックグラウンド タスクを HCE アプリに作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-189">You need to create a background task in your HCE app for processing and responding to APDUs routed to it by the system.</span></span> <span data-ttu-id="5ec65-190">アプリが初めて起動される際には、次のコードに示すように [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/BR224803) インターフェイスを実装する HCE バックグラウンド タスクがフォアグラウンドによって登録されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-190">During the first time your app is launched, the foreground registers an HCE background task that implements the [**IBackgroundTaskRegistration**](https://msdn.microsoft.com/library/windows/apps/BR224803) interface as shown in the following code.</span></span>

```csharp
var taskBuilder = new BackgroundTaskBuilder();
taskBuilder.Name = bgTaskName;
taskBuilder.TaskEntryPoint = taskEntryPoint;
taskBuilder.SetTrigger(new SmartCardTrigger(SmartCardTriggerType.EmulatorHostApplicationActivated));
bgTask = taskBuilder.Register();
```

<span data-ttu-id="5ec65-191">タスクのトリガーが [**SmartCardTriggerType**](https://msdn.microsoft.com/library/windows/apps/Dn608017).</span><span class="sxs-lookup"><span data-stu-id="5ec65-191">Notice that the task trigger is set to [**SmartCardTriggerType**](https://msdn.microsoft.com/library/windows/apps/Dn608017).</span></span> <span data-ttu-id="5ec65-192">**EmulatorHostApplicationActivated** に設定されていることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-192">**EmulatorHostApplicationActivated**.</span></span> <span data-ttu-id="5ec65-193">これは、OS で受信した SELECT AID コマンドの APDU がアプリに解決されるたびに、バックグラウンド タスクが起動されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-193">This means that whenever a SELECT AID command APDU is received by the OS resolving to your app, your background task will be launched.</span></span>

## <a name="receive-and-respond-to-apdus"></a><span data-ttu-id="5ec65-194">APDU の受信と応答</span><span class="sxs-lookup"><span data-stu-id="5ec65-194">Receive and respond to APDUs</span></span>

<span data-ttu-id="5ec65-195">アプリをターゲットとする APDU があると、システムは、このアプリのバックグラウンド タスクを起動します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-195">When there is an APDU targeted for your app, the system will launch your background task.</span></span> <span data-ttu-id="5ec65-196">バックグラウンド タスクは、[**SmartCardEmulatorApduReceivedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894640) オブジェクトの [**CommandApdu**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorapdureceivedeventargs.commandapdu.aspx) プロパティを通じて渡された APDU を受信し、同じオブジェクトの [**TryRespondAsync**](https://msdn.microsoft.com/library/windows/apps/mt634299.aspx) メソッドを使用して APDU に応答します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-196">Your background task receives the APDU passed through the [**SmartCardEmulatorApduReceivedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894640) object’s [**CommandApdu**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorapdureceivedeventargs.commandapdu.aspx) property and responds to the APDU using the [**TryRespondAsync**](https://msdn.microsoft.com/library/windows/apps/mt634299.aspx) method of the same object.</span></span> <span data-ttu-id="5ec65-197">パフォーマンスを考慮して、バックグラウンド タスクは軽量な操作に留めるよう検討してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-197">Consider keeping your background task for light operations for performance reasons.</span></span> <span data-ttu-id="5ec65-198">たとえば、すべての処理が完了したら、直ちに APDU に応答し、バックグラウンド タスクを終了してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-198">For example, respond to the APDUs immediately and exit your background task when all processing is complete.</span></span> <span data-ttu-id="5ec65-199">NFC トランザクションの性質から、ユーザーがリーダーに対してデバイスをかざす時間はきわめて短時間に限られています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-199">Due to the nature of NFC transactions, users tend to hold their device against the reader for only a very short amount of time.</span></span> <span data-ttu-id="5ec65-200">バックグラウンド タスクは、接続が無効になるまで継続的にリーダーからトラフィックを受信し、接続が無効になると [**SmartCardEmulatorConnectionDeactivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894644) オブジェクトを受信します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-200">Your background task will continue to receive traffic from the reader until your connection is deactivated, in which case you will receive a [**SmartCardEmulatorConnectionDeactivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/Dn894644) object.</span></span> <span data-ttu-id="5ec65-201">接続は、[**SmartCardEmulatorConnectionDeactivatedEventArgs.Reason**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorconnectiondeactivatedeventargs.reason) プロパティで示されるように次の理由で無効になります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-201">Your connection can be deactivated because of the following reasons as indicated in the [**SmartCardEmulatorConnectionDeactivatedEventArgs.Reason**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardemulatorconnectiondeactivatedeventargs.reason) property.</span></span>

-   <span data-ttu-id="5ec65-202">**ConnectionLost** 値で接続が無効になった場合は、ユーザーがリーダーからデバイスを離したことを意味します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-202">If the connection is deactivated with the **ConnectionLost** value, it means that the user pulled their device away from the reader.</span></span> <span data-ttu-id="5ec65-203">アプリでユーザーが端末にタップする時間を長くする必要がある場合は、フィードバックと共にプロンプトを表示することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-203">If your app needs the user to tap to the terminal longer, you might want to consider prompting them with feedback.</span></span> <span data-ttu-id="5ec65-204">ユーザーが再度タップしたときに、直前のバックグラウンド タスクが終了するまで待機したために遅延が生じることのないよう、バックグラウンド タスクは (保留を終了することで) 直ちに終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-204">You should terminate your background task quickly (by completing your deferral) to ensure if they tap again it won’t be delayed waiting for the previous background task to exit.</span></span>
-   <span data-ttu-id="5ec65-205">**ConnectionRedirected** で接続が無効になった場合は、端末によって新しい SELECT AID コマンドの APDU が送信され、別の AID に転送されたことを意味します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-205">If the connection is deactivated with the **ConnectionRedirected**, it means that the terminal sent a new SELECT AID command APDU directed to a different AID.</span></span> <span data-ttu-id="5ec65-206">この場合、別のバックグラウンド タスクが実行できるように、アプリは直ちに (保留を終了することで) バックグラウンド タスクを終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-206">In this case, your app should exit the background task immediately (by completing your deferral) to allow another background task to run.</span></span>

<span data-ttu-id="5ec65-207">バックグラウンド タスクは、[**IBackgroundTaskInstance インターフェイス**](https://msdn.microsoft.com/library/windows/apps/BR224797)の [**Canceled イベント**](https://msdn.microsoft.com/library/windows/apps/BR224798)にも登録し、同様に (保留を終了することで) バックグラウンド タスクを直ちに終了する必要があります。このイベントは、バックグラウンド タスクの終了時にシステムによって発生するためです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-207">The background task should also register for the [**Canceled event**](https://msdn.microsoft.com/library/windows/apps/BR224798) on [**IBackgroundTaskInstance interface**](https://msdn.microsoft.com/library/windows/apps/BR224797), and likewise quickly exit the background task (by completing your deferral) because this event is fired by the system when it is finished with your background task.</span></span> <span data-ttu-id="5ec65-208">次のコードでは、HCE アプリのバックグラウンド タスクのデモを示しています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-208">Below is code that demonstrates an HCE app background task.</span></span>

```csharp
void BgTask::Run(
    IBackgroundTaskInstance^ taskInstance)
{
    m_triggerDetails = static_cast<SmartCardTriggerDetails^>(taskInstance->TriggerDetails);
    if (m_triggerDetails == nullptr)
    {
        // May be not a smart card event that triggered us
        return;
    }

    m_emulator = m_triggerDetails->Emulator;
    m_taskInstance = taskInstance;

    switch (m_triggerDetails->TriggerType)
    {
    case SmartCardTriggerType::EmulatorHostApplicationActivated:
        HandleHceActivation();
        break;

    case SmartCardTriggerType::EmulatorAppletIdGroupRegistrationChanged:
        HandleRegistrationChange();
        break;

    default:
        break;
    }
}

void BgTask::HandleHceActivation()
{
 try
 {
        auto lock = m_srwLock.LockShared();
        // Take a deferral to keep this background task alive even after this "Run" method returns
        // You must complete this deferal immediately after you have done processing the current transaction
        m_deferral = m_taskInstance->GetDeferral();

        DebugLog(L"*** HCE Activation Background Task Started ***");

        // Set up a handler for if the background task is cancelled, we must immediately complete our deferral
        m_taskInstance->Canceled += ref new Windows::ApplicationModel::Background::BackgroundTaskCanceledEventHandler(
            [this](
            IBackgroundTaskInstance^ sender,
            BackgroundTaskCancellationReason reason)
        {
            DebugLog(L"Cancelled");
            DebugLog(reason.ToString()->Data());
            EndTask();
        });

        if (Windows::Phone::System::SystemProtection::ScreenLocked)
        {
            auto denyIfLocked = Windows::Storage::ApplicationData::Current->RoamingSettings->Values->Lookup("DenyIfPhoneLocked");
            if (denyIfLocked != nullptr && (bool)denyIfLocked == true)
            {
                // The phone is locked, and our current user setting is to deny transactions while locked so let the user know
                // Denied
                DoLaunch(Denied, L"Phone was locked at the time of tap");

                // We still need to respond to APDUs in a timely manner, even though we will just return failure
                m_fDenyTransactions = true;
            }
        }
        else
        {
            m_fDenyTransactions = false;
        }

        m_emulator->ApduReceived += ref new TypedEventHandler<SmartCardEmulator^, SmartCardEmulatorApduReceivedEventArgs^>(
            this, &BgTask::ApduReceived);

        m_emulator->ConnectionDeactivated += ref new TypedEventHandler<SmartCardEmulator^, SmartCardEmulatorConnectionDeactivatedEventArgs^>(
                [this](
                SmartCardEmulator^ emulator,
                SmartCardEmulatorConnectionDeactivatedEventArgs^ eventArgs)
            {
                DebugLog(L"Connection deactivated");
                EndTask();
            });

  m_emulator->Start();
        DebugLog(L"Emulator started");
 }
 catch (Exception^ e)
 {
        DebugLog(("Exception in Run: " + e->ToString())->Data());
        EndTask();
 }
}
```
## <a name="create-and-register-aid-groups"></a><span data-ttu-id="5ec65-209">AID グループの作成と登録</span><span class="sxs-lookup"><span data-stu-id="5ec65-209">Create and register AID groups</span></span>

<span data-ttu-id="5ec65-210">カードのプロビジョニング時にアプリケーションを初めて起動すると、AID グループが作成され、システムに登録されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-210">During the first launch of your application when the card is being provisioned, you will create and register AID groups with the system.</span></span> <span data-ttu-id="5ec65-211">システムは、外部リーダーが対話する必要のあるアプリを判断し、登録されている AID とユーザー設定に基づいて APDU をルーティングします。</span><span class="sxs-lookup"><span data-stu-id="5ec65-211">The system determines the app that an external reader would like to talk to and route APDUs accordingly based on the registered AIDs and user settings.</span></span>

<span data-ttu-id="5ec65-212">ほとんどの支払い用カードは、追加の支払い用ネットワーク カード固有の AID と共に同じ AID (PPSE AID) に登録されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-212">Most of the payment cards register for the same AID (which is PPSE AID) along with additional payment network card specific AIDs.</span></span> <span data-ttu-id="5ec65-213">各 AID グループはカードを表し、ユーザーがそのカードを有効にすると、グループ内のすべての AID が有効になります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-213">Each AID group represents a card and when the user enables the card, all AIDs in the group are enabled.</span></span> <span data-ttu-id="5ec65-214">同様に、ユーザーがカードを無効にすると、そのグループ内のすべての AID が無効になります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-214">Similarly, when the user deactivates the card, all AIDs in the group are disabled.</span></span>

<span data-ttu-id="5ec65-215">AID グループを登録するには、[**SmartCardAppletIdGroup**](https://msdn.microsoft.com/library/windows/apps/Dn910955) オブジェクトを作成し、HCE ベースの支払い用カードであることが反映されるようにプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-215">To register an AID group, you need to create a [**SmartCardAppletIdGroup**](https://msdn.microsoft.com/library/windows/apps/Dn910955) object and set its properties to reflect that this is an HCE-based payment card.</span></span> <span data-ttu-id="5ec65-216">表示名は、NFC 設定メニューにもユーザー プロンプトにも使用されるため、ユーザーにわかりやすい名前にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-216">Your display name should be descriptive to the user because it will show up in the NFC settings menu as well as user prompts.</span></span> <span data-ttu-id="5ec65-217">HCE 支払い用カードの場合、[**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) プロパティは **Payment** に、[**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) プロパティは **Host** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-217">For HCE payment cards, the [**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) property should be set to **Payment** and the [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) property should be set to **Host**.</span></span>

```csharp
public static byte[] AID_PPSE =
        {
            // File name "2PAY.SYS.DDF01" (14 bytes)
            (byte)'2', (byte)'P', (byte)'A', (byte)'Y',
            (byte)'.', (byte)'S', (byte)'Y', (byte)'S',
            (byte)'.', (byte)'D', (byte)'D', (byte)'F', (byte)'0', (byte)'1'
        };

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_PPSE.AsBuffer()},
                                SmartCardEmulationCategory.Payment,
                                SmartCardEmulationType.Host);
```

<span data-ttu-id="5ec65-218">支払い用以外の HCE カードの場合、[**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) プロパティは **Other** に、[**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) プロパティは **Host** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-218">For non-payment HCE cards, the [**SmartCardEmulationCategory**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationcategory.aspx) property should be set to **Other** and the [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.smartcardappletidgroup.smartcardemulationtype) property should be set to **Host**.</span></span>

```csharp
public static byte[] AID_OTHER =
        {
            (byte)'1', (byte)'2', (byte)'3', (byte)'4',
            (byte)'5', (byte)'6', (byte)'7', (byte)'8',
            (byte)'O', (byte)'T', (byte)'H', (byte)'E', (byte)'R'
        };

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_OTHER.AsBuffer()},
                                SmartCardEmulationCategory.Other,
                                SmartCardEmulationType.Host);
```

<span data-ttu-id="5ec65-219">各 AID グループには、最大 9 個の AID (それぞれの長さは 5 ～ 16 バイト) を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-219">You can include up to 9 AIDs (of length 5-16 bytes each) per AID group.</span></span>

<span data-ttu-id="5ec65-220">AID グループをシステムに登録するには、[**RegisterAppletIdGroupAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894656) メソッドを使用します。このメソッドからは [**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-220">Use the [**RegisterAppletIdGroupAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894656) method to register your AID group with the system, which will return a [**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) object.</span></span> <span data-ttu-id="5ec65-221">既定では、登録オブジェクトの [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) プロパティは **Disabled** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-221">By default, the [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) property of the registration object is set to **Disabled**.</span></span> <span data-ttu-id="5ec65-222">つまり、AID がシステムに登録されていても、この時点では有効になっておらず、トラフィックを受信しません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-222">This means even though your AIDs are registered with the system, they are not enabled yet and won’t receive traffic.</span></span>

```csharp
reg = await SmartCardEmulator.RegisterAppletIdGroupAsync(appletIdGroup);
```

<span data-ttu-id="5ec65-223">登録済みのカード (AID グループ) は、次に示されているように [**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) クラスの [**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) メソッドを使用して有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-223">You can enable your registered cards (AID groups) by using the [**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) method of the[**SmartCardAppletIdGroupRegistration**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) class as shown below.</span></span> <span data-ttu-id="5ec65-224">システムで一度に有効にできる支払い用カードは 1 枚だけであるため、支払い AID グループの [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) を **Enabled** に設定することは、既定の支払い用カードを設定することと同じ意味になります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-224">Because only a single payment card can be enabled at a time on the system, setting the [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) of a payment AID group to **Enabled** is the same as setting the default payment card.</span></span> <span data-ttu-id="5ec65-225">既定の支払い用カードが既に選択されているかどうかに関係なく、このカードを既定の支払い用カードとして設定するかどうかをユーザーに確認するメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-225">The user will be prompted to allow this card as a default payment card, regardless of whether there is a default payment card already selected or not.</span></span> <span data-ttu-id="5ec65-226">アプリが既に既定の支払いアプリケーションであり、単に AID グループ間で変更する場合、この記述は該当しません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-226">This statement is not true if your app is already the default payment application, and is merely changing between it’s own AID groups.</span></span> <span data-ttu-id="5ec65-227">アプリごとに最大で 10 の AID グループを登録することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-227">You can register up to 10 AID groups per app.</span></span>

```csharp
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.Enabled);
```

<span data-ttu-id="5ec65-228">[**GetAppletIdGroupRegistrationsAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894654) メソッドを使用すると、OS に対してアプリの登録済み AID グループを照会し、アクティブ化ポリシーを確認できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-228">You can query your app’s registered AID groups with the OS and check their activation policy using the [**GetAppletIdGroupRegistrationsAsync**](https://msdn.microsoft.com/library/windows/apps/Dn894654) method.</span></span>

<span data-ttu-id="5ec65-229">支払い用カードのアクティブ化ポリシーを **Disabled** から **Enabled** に変更する場合にユーザーに確認が求められるのは、アプリがまだ既定の支払いアプリになっていない場合のみです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-229">Users will be prompted when you change the activation policy of a payment card from **Disabled** to **Enabled**, only if your app is not already the default payment app.</span></span> <span data-ttu-id="5ec65-230">支払い用以外のカードのアクティブ化ポリシーを **Disabled** から **Enabled** に変更する場合にユーザーに確認が求められるのは、AID の競合が存在する場合のみです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-230">Users will only be prompted when you change the activation policy of a non-payment card from **Disabled** to **Enabled** if there is an AID conflict.</span></span>

```csharp
var registrations = await SmartCardEmulator.GetAppletIdGroupRegistrationsAsync();
    foreach (var registration in registrations)
    {
registration.RequestActivationPolicyChangeAsync (AppletIdGroupActivationPolicy.Enabled);
    }
```

**<span data-ttu-id="5ec65-231">アクティブ化ポリシー変更時のイベント通知</span><span class="sxs-lookup"><span data-stu-id="5ec65-231">Event notification when activation policy change</span></span>**

<span data-ttu-id="5ec65-232">バックグラウンド タスクでは、アプリの外でいずれかの AID グループ登録のアクティブ化ポリシーが変更された場合に備えてイベントを受信できるように登録できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-232">In your background task, you can register to receive events for when the activation policy of one of your AID group registrations changes outside of your app.</span></span> <span data-ttu-id="5ec65-233">たとえばユーザーは、NFC 設定メニューで既定の支払いアプリを元のカードから、別のアプリでホストされている別のカードに変更することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-233">For example, the user may change the default payment app through the NFC settings menu from one of your cards to another card hosted by another app.</span></span> <span data-ttu-id="5ec65-234">ライブ タイルの更新など、内部セットアップ用にこの変更をアプリで認識する必要がある場合は、この変更のイベント通知を受信し、その通知に応じてアプリ内で対処することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-234">If your app needs to know about this change for internal setup such as updating live tiles, you can receive event notifications for this change and take action in your app accordingly.</span></span>

```csharp
var taskBuilder = new BackgroundTaskBuilder();
taskBuilder.Name = bgTaskName;
taskBuilder.TaskEntryPoint = taskEntryPoint;
taskBuilder.SetTrigger(new SmartCardTrigger(SmartCardTriggerType.EmulatorAppletIdGroupRegistrationChanged));
bgTask = taskBuilder.Register();
```

## <a name="foreground-override-behavior"></a><span data-ttu-id="5ec65-235">フォアグラウンドのオーバーライド動作</span><span class="sxs-lookup"><span data-stu-id="5ec65-235">Foreground override behavior</span></span>

<span data-ttu-id="5ec65-236">アプリがフォアグラウンドになっている間は、ユーザーに確認することなく AID グループ登録の [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) を **ForegroundOverride** に変更することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-236">You can change the [**ActivationPolicy**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) of any of your AID group registrations to **ForegroundOverride** while your app is in the foreground without prompting the user.</span></span> <span data-ttu-id="5ec65-237">アプリがフォアグラウンドになっている間にユーザーがデバイスで端末をタップすると、ユーザーがいずれの支払い用カードも既定の支払い用カードとして選択していなくても、トラフィックはアプリにルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-237">When the user taps their device to a terminal while your app is in the foreground, the traffic is routed to your app even if none of your payment cards were chosen by the user as their default payment card.</span></span> <span data-ttu-id="5ec65-238">カードのアクティブ化ポリシーを **ForegroundOverride** に変更した場合、この変更はアプリがフォアグラウンドから移行するまでの一時的なものであり、ユーザーによって設定された現在の既定支払い用カードは変更されません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-238">When you change a card’s activation policy to **ForegroundOverride**, this change is only temporary until your app leaves the foreground and it will not change the current default payment card set by the user.</span></span> <span data-ttu-id="5ec65-239">支払い用カードまたは支払い用以外のカードの **ActivationPolicy** は、フォアグラウンド アプリから次のように変更できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-239">You can change the **ActivationPolicy** of your payment or non-payment cards from your foreground app as follows.</span></span> <span data-ttu-id="5ec65-240">[**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) メソッドを呼び出すことができるのはフォアグラウンド アプリからのみであり、バックグラウンド タスクから呼び出すことはできない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="5ec65-240">Note that the [**RequestActivationPolicyChangeAsync**](https://docs.microsoft.com/en-us/uwp/api/windows.devices.smartcards.smartcardappletidgroupregistration) method can only be called from a foreground app and cannot be called from a background task.</span></span>

```csharp
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.ForegroundOverride);
```

<span data-ttu-id="5ec65-241">また、長さ 0 の単一 AID から成る AID グループを登録することもできます。その場合は、SELECT AID コマンドの受信前に送信されたコマンドの APDU もすべて含めて、AID に関係なくすべての APDU がルーティングされます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-241">Also, you can register an AID group consisting of a single 0-length AID which will cause the system to route all APDUs regardless of the AID and including any command APDUs sent before a SELECT AID command is received.</span></span> <span data-ttu-id="5ec65-242">ただし、このような AID グループは **ForegroundOverride** にしか設定できず、常に有効にしておくことはできないため、機能するのはアプリがフォアグラウンドになっている間のみです。</span><span class="sxs-lookup"><span data-stu-id="5ec65-242">However, such an AID group only works while your app is in the foreground because it can only be set to **ForegroundOverride** and cannot be permanently enabled.</span></span> <span data-ttu-id="5ec65-243">また、すべてのトラフィックを HCE バックグラウンド タスクまたは SIM カードにルーティングするために、このメカニズムは [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639) 列挙の値が **Host** の場合と **UICC** の場合の両方に使用できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-243">Also, this mechanism works both for **Host** and **UICC** values of the [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639) enumeration to either route all traffic to your HCE background task, or to the SIM card.</span></span>

```csharp
public static byte[] AID_Foreground =
        {};

var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_Foreground.AsBuffer()},
                                SmartCardEmulationCategory.Other,
                                SmartCardEmulationType.Host);
reg = await SmartCardEmulator.RegisterAppletIdGroupAsync(appletIdGroup);
reg.RequestActivationPolicyChangeAsync(AppletIdGroupActivationPolicy.ForegroundOverride);
```

## <a name="check-for-nfc-and-hce-support"></a><span data-ttu-id="5ec65-244">NFC および HCE サポートの確認</span><span class="sxs-lookup"><span data-stu-id="5ec65-244">Check for NFC and HCE support</span></span>

<span data-ttu-id="5ec65-245">アプリでは、デバイスに NFC ハードウェアがあるかどうか、カード エミュレーション機能がサポートされているかどうか、これらの機能をユーザーに提供する前にホスト カード エミュレーションがサポートされるかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-245">Your app should check whether a device has NFC hardware, supports the card emulation feature, and supports host card emulation prior to offering such features to the user.</span></span>

<span data-ttu-id="5ec65-246">NFC スマート カード エミュレーション機能は、windows 10 Mobile では、windows 10 の他のバージョンでスマート カード エミュレーター Api を使用しようとするためにのみ有効には、エラーが発生します。</span><span class="sxs-lookup"><span data-stu-id="5ec65-246">The NFC smart card emulation feature is only enabled on Windows10 Mobile, so trying to use the smart card emulator APIs in any other versions of Windows10, will cause errors.</span></span> <span data-ttu-id="5ec65-247">次のコード スニペットでは、スマート カード API のサポートを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-247">You can check for smart card API support in the following code snippet.</span></span>

```csharp
Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.SmartCards.SmartCardEmulator");
```

<span data-ttu-id="5ec65-248">さらに、[**SmartCardEmulator.GetDefaultAsync**](https://msdn.microsoft.com/library/windows/apps/Dn608008) メソッドから null が返されるかどうかを確認することによって、なんらかの形でカード エミュレーションが可能な NFC ハードウェアがデバイスに存在するかどうかを確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-248">You can additionally check to see if the device has NFC hardware capable of some form of card emulation by checking if the [**SmartCardEmulator.GetDefaultAsync**](https://msdn.microsoft.com/library/windows/apps/Dn608008) method returns null.</span></span> <span data-ttu-id="5ec65-249">null が返される場合、そのデバイスでは NFC カード エミュレーションがサポートされません。</span><span class="sxs-lookup"><span data-stu-id="5ec65-249">If it does, then no NFC card emulation is supported on the device.</span></span>

```csharp
var smartcardemulator = await SmartCardEmulator.GetDefaultAsync();<
```

<span data-ttu-id="5ec65-250">HCE ベースおよび AID ベースの UICC ルーティングは、Lumia 730、830、640、640 XL など最近発売されたデバイスでのみサポートされます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-250">Support for HCE and AID-based UICC routing is only available on recently launched devices such as the Lumia 730, 830, 640, and 640 XL.</span></span> <span data-ttu-id="5ec65-251">Windows 10 Mobile を実行している新しい NFC 対応デバイスとした後、HCE をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-251">Any new NFC capable devices running Windows10 Mobile and after should support HCE.</span></span> <span data-ttu-id="5ec65-252">アプリでは、次のようにして HCE サポートを確認できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-252">Your app can check for HCE support as follows.</span></span>

```csharp
Smartcardemulator.IsHostCardEmulationSupported();
```

## <a name="lock-screen-and-screen-off-behavior"></a><span data-ttu-id="5ec65-253">ロック画面と画面オフの動作</span><span class="sxs-lookup"><span data-stu-id="5ec65-253">Lock screen and screen off behavior</span></span>

<span data-ttu-id="5ec65-254">Windows 10 Mobile は、デバイス レベルのカード エミュレーション設定は、携帯電話会社またはデバイスの製造元によって設定できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-254">Windows10 Mobile has device-level card emulation settings, which can be set by the mobile operator or the manufacturer of the device.</span></span> <span data-ttu-id="5ec65-255">既定では、"タップして支払い" のトグルがオフになっており "デバイス レベルでの有効化ポリシー" が "常時" に設定されています (通信事業者または OEM パートナーによってこれらの値が上書きされていない場合)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-255">By default, "tap to pay" toggle is disabled and the "enablement policy at device level" is set to "Always", unless the MO or OEM overwrites these values.</span></span>

<span data-ttu-id="5ec65-256">アプリケーションでは、デバイス レベルで [**EnablementPolicy**](https://msdn.microsoft.com/library/windows/apps/Dn608006) の値を照会し、それぞれの状態で望ましいアプリの動作に基づいて、各ケースに対処することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-256">Your application can query the value of the [**EnablementPolicy**](https://msdn.microsoft.com/library/windows/apps/Dn608006) at device level and take action for each case depending on the desired behavior of your app in each state.</span></span>

```csharp
SmartCardEmulator emulator = await SmartCardEmulator.GetDefaultAsync();

switch (emulator.EnablementPolicy)
{
case Never:
// you can take the user to the NFC settings to turn "tap and pay" on
await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-nfctransactions:"));
break;

 case Always:
return "Card emulation always on";

 case ScreenOn:
 return "Card emulation on only when screen is on";

 case ScreenUnlocked:
 return "Card emulation on only when screen unlocked";
}
```

<span data-ttu-id="5ec65-257">電話がロックされている場合または画面がオフの場合、あるいはその両方に該当する場合も、アプリのバックグラウンド タスクが起動されます (そのアプリに解決される AID が外部リーダーによって選択された場合のみ)。</span><span class="sxs-lookup"><span data-stu-id="5ec65-257">Your app's background task will be launched even if the phone is locked and/or the screen is off only if the external reader selects an AID that resolves to your app.</span></span> <span data-ttu-id="5ec65-258">リーダーからのコマンドにはバックグラウンドで応答できますが、ユーザーによる操作が必要である場合や、ユーザーにメッセージを表示する必要がある場合は、いくつかの引数を指定してフォアグラウンド アプリを起動することができます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-258">You can respond to the commands from the reader in your background task, but if you need any input from the user or if you want to show a message to the user, you can launch your foreground app with some arguments.</span></span> <span data-ttu-id="5ec65-259">バックグラウンド タスクでは、次の動作でフォアグラウンド アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-259">Your background task can launch your foreground app with the following behavior.</span></span>

-   <span data-ttu-id="5ec65-260">デバイスのロック画面下で起動 (ユーザーがフォアグラウンド アプリを目にするのはデバイスのロックを解除した後)</span><span class="sxs-lookup"><span data-stu-id="5ec65-260">Under the device lock screen (the user will see your foreground app only after she unlocks the device)</span></span>
-   <span data-ttu-id="5ec65-261">デバイスのロック画面上で起動 (ユーザーがアプリを終了した後も、デバイスはロックされた状態)</span><span class="sxs-lookup"><span data-stu-id="5ec65-261">Above the device lock screen (after the user dismisses your app, the device is still in locked state)</span></span>

```csharp
        if (Windows::Phone::System::SystemProtection::ScreenLocked)
        {
            // Launch above the lock with some arguments
            var result = await eventDetails.TryLaunchSelfAsync("app-specific arguments", SmartCardLaunchBehavior.AboveLock);
        }
```

## <a name="aid-registration-and-other-updates-for-sim-based-apps"></a><span data-ttu-id="5ec65-262">SIM ベース アプリに関する AID 登録およびその他の更新</span><span class="sxs-lookup"><span data-stu-id="5ec65-262">AID registration and other updates for SIM based apps</span></span>

<span data-ttu-id="5ec65-263">セキュア エレメントとして SIM を使用するカード エミュレーション アプリは Windows サービスに登録して、SIM でサポートされている AID を宣言できます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-263">Card emulation apps that use the SIM as the secure element can register with the Windows service to declare the AIDs supported on the SIM.</span></span> <span data-ttu-id="5ec65-264">この登録は、HCE ベースのアプリ登録とよく似ています。</span><span class="sxs-lookup"><span data-stu-id="5ec65-264">This registration is very similar to an HCE-based app registration.</span></span> <span data-ttu-id="5ec65-265">唯一の違いは [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639) です。SIM ベースのアプリの場合は、これを Uicc に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5ec65-265">The only difference is the [**SmartCardEmulationType**](https://msdn.microsoft.com/library/windows/apps/Dn894639), which should be set to Uicc for SIM-based apps.</span></span> <span data-ttu-id="5ec65-266">支払い用カードを登録した結果、カードの表示名が NFC 設定メニューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="5ec65-266">As the result of the payment card registration, the display name of the card will also be populated in the NFC setting menu.</span></span>

```csharp
var appletIdGroup = new SmartCardAppletIdGroup(
                        "Example DisplayName",
                                new List<IBuffer> {AID_PPSE.AsBuffer()},
                                SmartCardEmulationCategory.Payment,
                                SmartCardEmulationType.Uicc);
```

<span data-ttu-id="5ec65-267">\* \* 重要な \* \*新しい windows 10 Mobile SMS を使用できる証明書利用者従来の Windows Phone 8.1 アプリを更新する必要がありますが、Windows Phone 8.1 のレガシ バイナリ SMS インターセプト サポートは廃止され、windows 10 Mobile では新しい広範な SMS サポートに置き換えられますApi です。</span><span class="sxs-lookup"><span data-stu-id="5ec65-267">\*\* Important \*\* The legacy binary SMS intercept support in Windows Phone 8.1 has been removed and replaced with new broader SMS support in Windows10 Mobile, but any legacy Windows Phone 8.1 apps relying on that must update to use the new Windows10 Mobile SMS APIs.</span></span>
