---
author: WilliamsJason
title: UWP を開発するときに Xbox One で Fiddler を使用する方法
description: フリーウェアの Fiddler ツールを使って、UWP Xbox One 開発機でのネットワーク トラフィックを確認する方法について説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 9c133c77-fe9d-4b81-b4b3-462936333aa3
ms.localizationpriority: medium
ms.openlocfilehash: 9b0c91c2e7fa6e3076e53b0d3ae2e8d3713c81c5
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5835272"
---
# <a name="how-to-use-fiddler-with-xbox-one-when-developing-for-uwp"></a><span data-ttu-id="91a32-104">UWP を開発するときに Xbox One で Fiddler を使用する方法</span><span class="sxs-lookup"><span data-stu-id="91a32-104">How to use Fiddler with Xbox One when developing for UWP</span></span>

<span data-ttu-id="91a32-105">Fiddler は、Xbox One 開発機とインターネットの間のすべての HTTP および HTTPS トラフィックをログに記録する Web デバッグ プロキシです。</span><span class="sxs-lookup"><span data-stu-id="91a32-105">Fiddler is a web debugging proxy which logs all HTTP and HTTPS traffic between your Xbox One dev kit and the Internet.</span></span> <span data-ttu-id="91a32-106">Fiddler を使って、Xbox サービスと証明書利用者 Web サービスとの間のトラフィックをログに記録し、Web サービスの呼び出しを確認してデバッグします。</span><span class="sxs-lookup"><span data-stu-id="91a32-106">You will use it to log and inspect traffic to and from the Xbox services and relying party web services, to understand and debug web service calls.</span></span> 

<span data-ttu-id="91a32-107">通常の操作では、プロキシ経由で通信するコンソールは、プロキシによって通信内容が変更されるリスクがあり、プレイヤーによる不適切な行為が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-107">In normal operation, a console that communicates through a proxy is at risk of having its communications modified by the proxy, possibly allowing players to cheat.</span></span> <span data-ttu-id="91a32-108">そのため、コンソールはプロキシ経由の通信を許可しないように設計されています。</span><span class="sxs-lookup"><span data-stu-id="91a32-108">Thus, consoles are designed to not allow communication through a proxy.</span></span> <span data-ttu-id="91a32-109">Xbox One 開発機で Fiddler を使うには、Fiddler プロキシの使用を許可するように、開発機で特別な構成手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-109">Using Fiddler with your Xbox One dev kit requires that you perform some special configuration steps on the dev kit to allow it to use the Fiddler proxy.</span></span> 

<span data-ttu-id="91a32-110">Fiddler はフリーウェアであり、[Fiddler の Web サイト](http://www.fiddler2.com/fiddler2/)からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="91a32-110">Fiddler is freeware, and can be downloaded from the [Fiddler website](http://www.fiddler2.com/fiddler2/).</span></span> 

<span data-ttu-id="91a32-111">Fiddler は、コンソールで報告されるネットワーク ステータスに影響を与える場合があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-111">Fiddler can impact the network status reported by the console.</span></span> <span data-ttu-id="91a32-112">Fiddler を実行しているコンピューターからのアップストリーム接続が無効になっている場合、コンソールの認証の有効期限が切れるまで、コンソールでこの切断が検出されない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-112">If an upstream connection is disabled from the machine running Fiddler, the console may not detect this disconnection until the authentication of the console has expired.</span></span> <span data-ttu-id="91a32-113">Fiddler を使っている場合、Fiddler を使って切断をシミュレートするのではなく、必ずコンソールと Fiddler を実行しているコンピューターとの接続を切断してください。</span><span class="sxs-lookup"><span data-stu-id="91a32-113">If you are using Fiddler, be sure to disconnect the connection between the console and the computer running Fiddler, rather than using Fiddler to simulate a disconnect.</span></span>

### <a name="to-install-and-enable-fiddler-on-your-development-pc"></a><span data-ttu-id="91a32-114">開発用 PC に Fiddler をインストールして有効にするには</span><span class="sxs-lookup"><span data-stu-id="91a32-114">To install and enable Fiddler on your development PC</span></span>
<span data-ttu-id="91a32-115">次の手順に従って、Fiddler をインストールし、有効にして、開発機からのトラフィックを監視します。</span><span class="sxs-lookup"><span data-stu-id="91a32-115">Follow these steps to install and enable Fiddler to monitor traffic from your dev kit:</span></span>

1. <span data-ttu-id="91a32-116">[Fiddler の Web サイト](http://www.fiddler2.com/fiddler2/)に示されている手順に従って、開発用 PC に Fiddler をインストールします。</span><span class="sxs-lookup"><span data-stu-id="91a32-116">Install Fiddler on your development PC, following the directions on the [Fiddler website](http://www.fiddler2.com/fiddler2/).</span></span> 
2. <span data-ttu-id="91a32-117">Fiddler を起動し、**[Tools]** メニューの **[Fiddler Options]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="91a32-117">Launch Fiddler and select **Fiddler Options** from the **Tools** menu.</span></span> 
3. <span data-ttu-id="91a32-118">**[Connections]** タブを選択し、**[Allow remote computers to connect]** がオンになっていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="91a32-118">Select the **Connections** tab and ensure that **Allow remote computers to connect** is selected.</span></span> 
4. <span data-ttu-id="91a32-119">**[OK]** をクリックして設定の変更を確認します。</span><span class="sxs-lookup"><span data-stu-id="91a32-119">Click **OK** to accept your change to the settings.</span></span> <span data-ttu-id="91a32-120">ダイアログ ボックスが表示され、変更を有効にするには Fiddler を再起動する必要があり、ファイアウォールを手動で構成することが必要になる可能性があるというメッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="91a32-120">You will see a dialog box saying that Fiddler must be restarted for the change to take effect, and that you may need to configure your firewall manually.</span></span> <span data-ttu-id="91a32-121">このダイアログ ボックスで **[OK]** をクリックしますが、*まだ Fiddler を再起動しないでください*。</span><span class="sxs-lookup"><span data-stu-id="91a32-121">Click **OK** on this dialog, but *do not restart Fiddler yet*.</span></span>
5. <span data-ttu-id="91a32-122">リモート コンピューターに接続を許可するために必要なファイアウォール規則を構成します。</span><span class="sxs-lookup"><span data-stu-id="91a32-122">Configure the necessary firewall rule to allow remote computers to connect.</span></span> <span data-ttu-id="91a32-123">Windows ファイアウォール コントロール パネル アプレットを起動します。</span><span class="sxs-lookup"><span data-stu-id="91a32-123">Start the Windows Firewall Control Panel applet.</span></span> <span data-ttu-id="91a32-124">**[詳細設定]**、**[受信の規則]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-124">Click **Advanced Settings**, and then **Inbound Rule**.</span></span> <span data-ttu-id="91a32-125">"FiddlerProxy" という名前の規則を探し、右へスクロールして、この規則の各設定が次の表の設定と一致していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="91a32-125">Find the rule named "FiddlerProxy" and scroll to the right, verifying that each of the settings in the following table appears for that rule.</span></span>
  
  | <span data-ttu-id="91a32-126">設定</span><span class="sxs-lookup"><span data-stu-id="91a32-126">Setting</span></span>           | <span data-ttu-id="91a32-127">推奨値</span><span class="sxs-lookup"><span data-stu-id="91a32-127">Preferred Value</span></span>                |
  | ----              | ----                           |
  | <span data-ttu-id="91a32-128">名前</span><span class="sxs-lookup"><span data-stu-id="91a32-128">Name</span></span>              | <span data-ttu-id="91a32-129">FiddlerProxy</span><span class="sxs-lookup"><span data-stu-id="91a32-129">FiddlerProxy</span></span>                   |
  | <span data-ttu-id="91a32-130">グループ</span><span class="sxs-lookup"><span data-stu-id="91a32-130">Group</span></span>             | *<span data-ttu-id="91a32-131">値なし</span><span class="sxs-lookup"><span data-stu-id="91a32-131">No value</span></span>* |
  | <span data-ttu-id="91a32-132">プロファイル</span><span class="sxs-lookup"><span data-stu-id="91a32-132">Profile</span></span>           | <span data-ttu-id="91a32-133">すべて</span><span class="sxs-lookup"><span data-stu-id="91a32-133">All</span></span>                            |
  | <span data-ttu-id="91a32-134">有効</span><span class="sxs-lookup"><span data-stu-id="91a32-134">Enabled</span></span>           | <span data-ttu-id="91a32-135">はい</span><span class="sxs-lookup"><span data-stu-id="91a32-135">Yes</span></span>                            |
  | <span data-ttu-id="91a32-136">操作</span><span class="sxs-lookup"><span data-stu-id="91a32-136">Action</span></span>            | <span data-ttu-id="91a32-137">許可</span><span class="sxs-lookup"><span data-stu-id="91a32-137">Allow</span></span>                          |
  | <span data-ttu-id="91a32-138">優先</span><span class="sxs-lookup"><span data-stu-id="91a32-138">Override</span></span>          | <span data-ttu-id="91a32-139">いいえ</span><span class="sxs-lookup"><span data-stu-id="91a32-139">No</span></span>                             |
  | <span data-ttu-id="91a32-140">プログラム</span><span class="sxs-lookup"><span data-stu-id="91a32-140">Program</span></span>           | *<span data-ttu-id="91a32-141">Fiddler.exe へのパス</span><span class="sxs-lookup"><span data-stu-id="91a32-141">Path to fiddler.exe</span></span>*          |
  | <span data-ttu-id="91a32-142">ローカル アドレス</span><span class="sxs-lookup"><span data-stu-id="91a32-142">LocalAddress</span></span>      | <span data-ttu-id="91a32-143">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-143">Any</span></span>                            |
  | <span data-ttu-id="91a32-144">リモート アドレス</span><span class="sxs-lookup"><span data-stu-id="91a32-144">RemoteAddress</span></span>     | <span data-ttu-id="91a32-145">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-145">Any</span></span>                            |
  | <span data-ttu-id="91a32-146">プロトコル</span><span class="sxs-lookup"><span data-stu-id="91a32-146">Protocol</span></span>          | <span data-ttu-id="91a32-147">TCP</span><span class="sxs-lookup"><span data-stu-id="91a32-147">TCP</span></span>                            |
  | <span data-ttu-id="91a32-148">ローカル ポート</span><span class="sxs-lookup"><span data-stu-id="91a32-148">LocalPort</span></span>         | <span data-ttu-id="91a32-149">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-149">Any</span></span>                            |
  | <span data-ttu-id="91a32-150">リモート ポート</span><span class="sxs-lookup"><span data-stu-id="91a32-150">RemotePort</span></span>        | <span data-ttu-id="91a32-151">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-151">Any</span></span>                            |
  | <span data-ttu-id="91a32-152">承認されているユーザー</span><span class="sxs-lookup"><span data-stu-id="91a32-152">AllowedUsers</span></span>      | <span data-ttu-id="91a32-153">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-153">Any</span></span>                            |
  | <span data-ttu-id="91a32-154">承認されているコンピューター</span><span class="sxs-lookup"><span data-stu-id="91a32-154">AllowedComputers</span></span>  | <span data-ttu-id="91a32-155">任意</span><span class="sxs-lookup"><span data-stu-id="91a32-155">Any</span></span>                            |


6. <span data-ttu-id="91a32-156">次の手順に従って、HTTPS トラフィックのキャプチャして暗号化を解除するように Fiddler を構成します。</span><span class="sxs-lookup"><span data-stu-id="91a32-156">Configure Fiddler to capture and decrypt HTTPS traffic by doing the following:</span></span>
  1. <span data-ttu-id="91a32-157">最適なパフォーマンスを実現するために、ボタン バーの **[Stream]** ボタンをクリックして、ストリーミング モードを使用するように Fiddler を設定します。</span><span class="sxs-lookup"><span data-stu-id="91a32-157">To enable best performance, set Fiddler to use Streaming Mode by clicking the **Stream** button on the button bar.</span></span>
  2. <span data-ttu-id="91a32-158">Fiddler の **[Tools]** メニューで、**[Fiddler Options]** を選んで **[HTTPS]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-158">In the Fiddler **Tools** menu, select **Fiddler Options**, and then click **HTTPS**.</span></span>
  3. <span data-ttu-id="91a32-159">**[Decrypt HTTPS traffic]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="91a32-159">Select the **Decrypt HTTPS traffic** check box.</span></span> <span data-ttu-id="91a32-160">Windows で CA 証明書を信頼するかどうかを確認するダイアログ ボックスが表示された場合は、**[No]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-160">If a dialog box asks whether to configure Windows to trust the CA certificate, click **No**.</span></span>
  4. <span data-ttu-id="91a32-161">**[Export Root Certificate to Desktop]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-161">Click **Export Root Certificate to Desktop**.</span></span>
7. <span data-ttu-id="91a32-162">Fiddler を終了して再起動します。</span><span class="sxs-lookup"><span data-stu-id="91a32-162">Exit and restart Fiddler.</span></span>

### <a name="to-configure-a-dev-kit-to-use-fiddler-as-its-proxy-to-the-internet"></a><span data-ttu-id="91a32-163">インターネットへのプロキシとして Fiddler を使用するように開発機を構成するには</span><span class="sxs-lookup"><span data-stu-id="91a32-163">To configure a dev kit to use Fiddler as its proxy to the Internet</span></span>

1. <span data-ttu-id="91a32-164">Xbox Device Portal の UI で**ネットワーク** ツールに移動します。</span><span class="sxs-lookup"><span data-stu-id="91a32-164">Navigate to the **Network** tool in the Xbox Device Portal UI.</span></span>
2. <span data-ttu-id="91a32-165">デスクトップにエクスポートした Fiddler のルート証明書を参照します。</span><span class="sxs-lookup"><span data-stu-id="91a32-165">Browse for the Fiddler root certificate that you exported to the desktop.</span></span> 
3. <span data-ttu-id="91a32-166">Fiddler を実行している開発用 PC の IP アドレスまたはホスト名を入力します。</span><span class="sxs-lookup"><span data-stu-id="91a32-166">Type the IP address or hostname of the development PC running Fiddler.</span></span>
4. <span data-ttu-id="91a32-167">Fiddler がリッスンしているポート番号 (既定では、Fiddler はポート 8888 を使用) を入力します。</span><span class="sxs-lookup"><span data-stu-id="91a32-167">Type the port number where Fiddler is listening (by default, Fiddler uses port 8888).</span></span> 
5. <span data-ttu-id="91a32-168">**[Enable]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-168">Click **Enable**.</span></span> <span data-ttu-id="91a32-169">これにより、開発キットが再起動します。</span><span class="sxs-lookup"><span data-stu-id="91a32-169">This will restart your dev kit.</span></span>

### <a name="to-stop-using-fiddler"></a><span data-ttu-id="91a32-170">Fiddler の使用を停止するには</span><span class="sxs-lookup"><span data-stu-id="91a32-170">To stop using Fiddler</span></span>
<span data-ttu-id="91a32-171">インターネットへのプロキシとしての Fiddler の使用を停止 (し、Fiddler による開発機のすべてのネットワーク トラフィックのトレースを停止) するには、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="91a32-171">To stop using Fiddler as a proxy to the Internet (and stop Fiddler from tracing all of the dev kit's network traffic), do the following:</span></span>

1. <span data-ttu-id="91a32-172">Xbox Device Portal の UI で**ネットワーク** ツールに移動します。</span><span class="sxs-lookup"><span data-stu-id="91a32-172">Navigate to the **Network** tool in the Xbox Device Portal UI.</span></span>
2. <span data-ttu-id="91a32-173">**[無効]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="91a32-173">Click **Disable**.</span></span>

> [!NOTE]
> <span data-ttu-id="91a32-174">Fiddler がインストールされている各 PC では、異なる Fiddler ルート証明書を使用します。</span><span class="sxs-lookup"><span data-stu-id="91a32-174">Each PC with Fiddler installed uses a different Fiddler root certificate.</span></span> <span data-ttu-id="91a32-175">開発機に Fiddler プロキシを提供するために、複数の PC を使用する可能性がある場合は、PC を切り替えたときに新しいルート証明書を選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-175">If you have more than one PC that might be used to provide a Fiddler proxy for your dev kit, you will need to select the new root certificate when switching between them.</span></span> <span data-ttu-id="91a32-176">1 台の PC のみを使用している場合は、最初に Fiddler を有効にするときにのみルート証明書を選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-176">If you are using only one PC, you need to select the root certificate only the first time you enable Fiddler.</span></span> <span data-ttu-id="91a32-177">この場合も、IP アドレスとポートを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="91a32-177">You must still specify the IP address and port.</span></span>

## <a name="see-also"></a><span data-ttu-id="91a32-178">関連項目</span><span class="sxs-lookup"><span data-stu-id="91a32-178">See also</span></span>
- [<span data-ttu-id="91a32-179">Fiddler 設定 API のリファレンス</span><span class="sxs-lookup"><span data-stu-id="91a32-179">Fiddler settings API reference</span></span>](wdp-fiddler-api.md)
- [<span data-ttu-id="91a32-180">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="91a32-180">Frequently asked questions</span></span>](frequently-asked-questions.md)
- [<span data-ttu-id="91a32-181">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="91a32-181">UWP on Xbox One</span></span>](index.md)



