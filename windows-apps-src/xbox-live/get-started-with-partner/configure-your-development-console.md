---
title: Xbox 開発機本体を構成する
author: KevinAsgari
description: Xbox Live の開発をサポートするように Xbox 開発機本体を構成する方法について説明します。
ms.assetid: f8fd1caa-b1e9-4882-a01f-8f17820dfb55
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b5a9c86e9fd56bab3e4eb30206f64debdf6ac9bf
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5822681"
---
# <a name="configure-your-xbox-development-console"></a><span data-ttu-id="cabf0-104">Xbox 開発機本体を構成する</span><span class="sxs-lookup"><span data-stu-id="cabf0-104">Configure your Xbox development console</span></span>

<span data-ttu-id="cabf0-105">開発機本体を構成するには:</span><span class="sxs-lookup"><span data-stu-id="cabf0-105">To configuring your development console:</span></span>
- <span data-ttu-id="cabf0-106">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="cabf0-106">Get your IDs</span></span>
- <span data-ttu-id="cabf0-107">開発キットにサンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="cabf0-107">Set your sandbox on your development kits</span></span>
- <span data-ttu-id="cabf0-108">開発アカウントでサインインする</span><span class="sxs-lookup"><span data-stu-id="cabf0-108">Sign in with a development account</span></span>

## <a name="get-your-ids"></a><span data-ttu-id="cabf0-109">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="cabf0-109">Get your IDs</span></span>
<span data-ttu-id="cabf0-110">サンドボックスと Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cabf0-110">To enable sandboxes and Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="cabf0-111">これらは同じプロセスで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="cabf0-111">These can be done with the same process.</span></span>

<span data-ttu-id="cabf0-112">「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」に従って ID を取得します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-112">Follow [Xbox Live service configuration](../xbox-live-service-configuration.md) to get your IDs</span></span>

## <a name="set-your-sandbox-on-your-development-kits"></a><span data-ttu-id="cabf0-113">開発キットにサンドボックスを設定する</span><span class="sxs-lookup"><span data-stu-id="cabf0-113">Set your sandbox on your development kits</span></span>
<span data-ttu-id="cabf0-114">開発キットを起動するには、サンドボックス ID を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cabf0-114">You will not be able to boot your development kit without setting your Sandbox ID.</span></span> <span data-ttu-id="cabf0-115">これを行うには、XDK で PC にインストールした "Xbox One Manager" を使用することも、XDK コマンド ウィンドウを開き、次のように構成コマンド (xbconfig.exe) を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="cabf0-115">To do this, you can use the "Xbox One Manager" that's installed on your PC by the XDK, or you can open an XDK command window and use the Configuration (xbconfig.exe) command as follows:</span></span>

<span data-ttu-id="cabf0-116">現在のサンドボックスを確認します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-116">Check your current sandbox.</span></span> <span data-ttu-id="cabf0-117">コマンド プロンプトで「xbconfig sandboxid」と入力します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-117">Type xbconfig sandboxid at the command prompt.</span></span>

<span data-ttu-id="cabf0-118">想定していたサンドボックスでない場合は、サンドボックス ID を変更します。コマンド プロンプトで、「xbconfig sandboxid=<your sandbox id>」と入力します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-118">If it’s not what you expect, change your sandbox id. Type xbconfig sandboxid=<your sandbox id> at the command prompt.</span></span>

<span data-ttu-id="cabf0-119">コマンド プロンプトで Reboot (xbreboot.exe) を使用してコンソールを再起動します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-119">Reboot your console using Reboot (xbreboot.exe) at the command prompt.</span></span>

<span data-ttu-id="cabf0-120">サンドボックスが正しくリセットされたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-120">Verify your sandbox has been correctly reset.</span></span> <span data-ttu-id="cabf0-121">コマンド プロンプトで「xbconfig sandboxid」と入力します。</span><span class="sxs-lookup"><span data-stu-id="cabf0-121">Type xbconfig sandboxid at the command prompt.</span></span>

## <a name="sign-in-with-a-development-account"></a><span data-ttu-id="cabf0-122">開発アカウントでサインインする</span><span class="sxs-lookup"><span data-stu-id="cabf0-122">Sign in with a development account</span></span>

<span data-ttu-id="cabf0-123">サインインに使用する開発アカウントは、[Xbox デベロッパー ポータル (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts) または [Windows デベロッパー センター](https://developer.microsoft.com/en-us/windows)で作成できます。</span><span class="sxs-lookup"><span data-stu-id="cabf0-123">You can create development accounts used to sign-in on [Xbox Developer Portal (XDP)](https://xdp.xboxlive.com/User/Contact/MyAccess?selectedMenu=devaccounts) or [Windows Dev Center](https://developer.microsoft.com/en-us/windows)</span></span>
