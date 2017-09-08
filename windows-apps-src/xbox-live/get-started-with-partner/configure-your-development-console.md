---
title: "Xbox 開発機本体を構成する"
author: KevinAsgari
description: "Xbox Live の開発をサポートするように Xbox 開発機本体を構成する方法について説明します。"
ms.assetid: f8fd1caa-b1e9-4882-a01f-8f17820dfb55
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 63577723e4786ce1c8bd4ca1397daefaed8accb2
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="configure-your-xbox-development-console"></a><span data-ttu-id="1a27f-104">Xbox 開発機本体を構成する</span><span class="sxs-lookup"><span data-stu-id="1a27f-104">Configure your Xbox development console</span></span>

<span data-ttu-id="1a27f-105">開発機本体を構成するには:</span><span class="sxs-lookup"><span data-stu-id="1a27f-105">To configuring your development console:</span></span>
- <span data-ttu-id="1a27f-106">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="1a27f-106">Get your IDs</span></span>
- <span data-ttu-id="1a27f-107">開発キットにサンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="1a27f-107">Set your sandbox on your development kits</span></span>
- <span data-ttu-id="1a27f-108">開発アカウントでサインインする</span><span class="sxs-lookup"><span data-stu-id="1a27f-108">Sign in with a development account</span></span>

## <a name="get-your-ids"></a><span data-ttu-id="1a27f-109">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="1a27f-109">Get your IDs</span></span>
<span data-ttu-id="1a27f-110">サンドボックスと Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a27f-110">To enable sandboxes and Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="1a27f-111">これらは同じプロセスで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="1a27f-111">These can be done with the same process.</span></span>

<span data-ttu-id="1a27f-112">「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」に従って ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-112">Follow [Xbox Live service configuration](../xbox-live-service-configuration.md) to get your IDs</span></span>

## <a name="set-your-sandbox-on-your-development-kits"></a><span data-ttu-id="1a27f-113">開発キットにサンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="1a27f-113">Set your sandbox on your development kits</span></span>
<span data-ttu-id="1a27f-114">開発キットを起動するには、サンドボックス ID を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1a27f-114">You will not be able to boot your development kit without setting your Sandbox ID.</span></span> <span data-ttu-id="1a27f-115">これを行うには、XDK で PC にインストールした "Xbox One Manager" を使用することも、XDK コマンド ウィンドウを開き、次のように構成コマンド (xbconfig.exe) を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="1a27f-115">To do this, you can use the "Xbox One Manager" that's installed on your PC by the XDK, or you can open an XDK command window and use the Configuration (xbconfig.exe) command as follows:</span></span>

<span data-ttu-id="1a27f-116">現在のサンドボックスを確認します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-116">Check your current sandbox.</span></span> <span data-ttu-id="1a27f-117">コマンド プロンプトで「xbconfig sandboxid」と入力します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-117">Type xbconfig sandboxid at the command prompt.</span></span>

<span data-ttu-id="1a27f-118">想定したものでない場合は、サンドボックス ID を変更します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-118">If it’s not what you expect, change your sandbox id.</span></span> <span data-ttu-id="1a27f-119">コマンド プロンプトで「xbconfig sandboxid=<your sandbox id>」と入力します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-119">Type xbconfig sandboxid=<your sandbox id> at the command prompt.</span></span>

<span data-ttu-id="1a27f-120">コマンド プロンプトで Reboot (xbreboot.exe) を使用してコンソールを再起動します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-120">Reboot your console using Reboot (xbreboot.exe) at the command prompt.</span></span>

<span data-ttu-id="1a27f-121">サンドボックスが正しくリセットされたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-121">Verify your sandbox has been correctly reset.</span></span> <span data-ttu-id="1a27f-122">コマンド プロンプトで「xbconfig sandboxid」と入力します。</span><span class="sxs-lookup"><span data-stu-id="1a27f-122">Type xbconfig sandboxid at the command prompt.</span></span>

## <a name="sign-in-with-a-development-account"></a><span data-ttu-id="1a27f-123">開発アカウントでサインインする</span><span class="sxs-lookup"><span data-stu-id="1a27f-123">Sign in with a development account</span></span>

<span data-ttu-id="1a27f-124">サインインに使用する開発アカウントは、[Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts) または [Windows デベロッパー センター](https://developer.microsoft.com/en-us/windows)で作成できます。</span><span class="sxs-lookup"><span data-stu-id="1a27f-124">You can create development accounts used to sign-in on [Xbox Developer Portal (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts) or [Windows Dev Center](https://developer.microsoft.com/en-us/windows)</span></span>
