---
title: XIM プロジェクト構成
author: KevinAsgari
description: Xbox Integrated Multiplayer (XIM) で使用する UWP アプリ マニフェストを構成する方法について説明します。
ms.assetid: 5d0ed7bd-9527-42a3-ae09-8cc9012c1111
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Integrated Multiplayer, マニフェスト
ms.localizationpriority: medium
ms.openlocfilehash: f83cad8ffc78fa34d5b5198d53dd024e363ff038
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6023158"
---
# <a name="xim-project-configuration"></a><span data-ttu-id="cdd23-104">XIM プロジェクト構成</span><span class="sxs-lookup"><span data-stu-id="cdd23-104">XIM Project Configuration</span></span>

## <a name="required-appxmanifest-capability-content"></a><span data-ttu-id="cdd23-105">必要な AppXManifest 機能の内容</span><span class="sxs-lookup"><span data-stu-id="cdd23-105">Required AppXManifest capability content</span></span>

<span data-ttu-id="cdd23-106">本質的に XIM を使用するアプリケーションでは、インターネット経由とローカル ネットワーク経由の両方でネットワーク リソースに接続し、ネットワーク リソースからの接続を受け入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="cdd23-106">An application using XIM inherently requires connecting to and accepting connections from network resources both over the Internet and the local network.</span></span> <span data-ttu-id="cdd23-107">また、ボイス チャットをサポートするマイク デバイスへのアクセスも必要です。</span><span class="sxs-lookup"><span data-stu-id="cdd23-107">It also requires access to microphone devices to support voice chat.</span></span> <span data-ttu-id="cdd23-108">そのため、アプリの AppXManifest では、"internetClientServer" 機能、"privateNetworkClientServer" 機能、"microphone" デバイス機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cdd23-108">As a result, the app should declare the "internetClientServer" and "privateNetworkClientServer" capabilities, and the "microphone" device capability in its AppXManifest.</span></span> <span data-ttu-id="cdd23-109">それぞれの詳細については、プラットフォームのドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cdd23-109">See the platform documentation for more detail on each.</span></span> <span data-ttu-id="cdd23-110">次のスニペットでは、Package/Capabilities ノードの下に対象のノードが存在する必要があり、それ以外の場合は接続とチャットがブロックされることを示しています。</span><span class="sxs-lookup"><span data-stu-id="cdd23-110">The following snippet shows the nodes that should exist under the Package/Capabilities node or else connectivity and chat will be blocked:</span></span>

```xml
 <?xml version="1.0" encoding="utf-8"?>
 <Package ...>
   <Identity ... />
   ...
   <Capabilities>
     <Capability Name="internetClientServer" />
     <Capability Name="privateNetworkClientServer" />
     <DeviceCapability Name="microphone" />
   </Capabilities>
 </Package>
```

## <a name="universal-windows-application-xbox-live-multiplayer-invite-protocol-activation-extension"></a><span data-ttu-id="cdd23-111">ユニバーサル Windows アプリケーションでの Xbox Live マルチプレイヤー招待プロトコルのアクティブ化拡張機能</span><span class="sxs-lookup"><span data-stu-id="cdd23-111">Universal Windows application Xbox Live multiplayer invite protocol activation extension</span></span>

<span data-ttu-id="cdd23-112">Xbox Live マルチプレイヤー アプリケーションでは、ゲームへの招待をサポートすることが求められます。</span><span class="sxs-lookup"><span data-stu-id="cdd23-112">Xbox Live multiplayer applications are expected to support game invitations.</span></span> <span data-ttu-id="cdd23-113">ローカル ユーザーが受け入れた招待は、アプリのプロトコルのアクティブ化の形で到着します (プロトコルのアクティブ化については、プラットフォームのドキュメントをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="cdd23-113">Invites accepted by local users arrive in the form of protocol activation of the app (see the platform documentation for more information regarding protocol activation).</span></span> <span data-ttu-id="cdd23-114">帯域外予約を通じて管理されている XIM ネットワーク以外の XIM を使用するアプリは、`xim::extract_protocol_activation_information()` メソッドを呼び出して実行時にプロトコルのアクティブ化処理を支援しますが、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでは、このような "ms-xbl-multiplayer" アクティブ化がシステムによってサポートされるということを AppXManifest "windows.protocol" 拡張機能でも静的に宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cdd23-114">Apps that use XIM other than for XIM networks managed through out-of-band reservations invoke the `xim::extract_protocol_activation_information()` method to assist in handling protocol activation at run-time, but Universal Windows Platform (UWP) applications must also statically declare via an AppXManifest "windows.protocol" extension that they support such "ms-xbl-multiplayer" activations by the system.</span></span> <span data-ttu-id="cdd23-115">これは、次のスニペットに示す方法で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="cdd23-115">This can be done as seen in the following snippet:</span></span>

```xml
 <?xml version="1.0" encoding="utf-8"?>
 <Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10" xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10" IgnorableNamespaces="uap">
   <Applications>
     <Application ...>
       <Extensions>
         ...
          <uap:Extension Category="windows.protocol">
             <uap:Protocol Name="ms-xbl-multiplayer"/>
          </uap:Extension>
       </Extensions>
     </Application>
   </Applications>
 </Package>
```

<span data-ttu-id="cdd23-116">これが必要なのは、ユニバーサル Windows アプリケーションだけです。</span><span class="sxs-lookup"><span data-stu-id="cdd23-116">This is only required for universal Windows applications.</span></span> <span data-ttu-id="cdd23-117">Xbox One の排他リソース ("XDK") アプリケーションでは、プロトコルのアクティブ化拡張機能を明示的に宣言しません。これらは、Xbox Live タイトル ID 拡張機能を宣言することによって自動的に登録されます。</span><span class="sxs-lookup"><span data-stu-id="cdd23-117">Xbox One exclusive resource ("XDK") applications do not explicitly declare a protocol activation extension as they are automatically registered by declaring their Xbox Live title ID extension.</span></span>

## <a name="xbox-one-exclusive-resource-application-network-manifest-templates"></a><span data-ttu-id="cdd23-118">Xbox One 排他リソース アプリケーション ネットワーク マニフェスト テンプレート</span><span class="sxs-lookup"><span data-stu-id="cdd23-118">Xbox One exclusive resource application network manifest templates</span></span>

<span data-ttu-id="cdd23-119">XIM を使用する Xbox One 排他リソース アプリケーションは、AppXManifest の "ネットワーク マニフェスト" 拡張機能に特定のソケット記述およびテンプレート コンテンツが含まれることを確認する必要があります (ネットワーク マニフェストについて詳しくは、プラットフォームのドキュメントをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="cdd23-119">Any Xbox One exclusive resource application that uses XIM must ensure certain socket description and template content is included in its "network manifest" extension of the AppXManifest (see the platform documentation for more detail on network manifests).</span></span> <span data-ttu-id="cdd23-120">アプリに他のテンプレートが存在する可能性もありますが、次のスニペットは存在する必要があり、存在しないと XIM ネットワークへの移動は失敗します。</span><span class="sxs-lookup"><span data-stu-id="cdd23-120">The app may have other templates as well, but the following snippet must be present or else moving to a XIM network will fail:</span></span>

```xml

 <?xml version="1.0" encoding="utf-8"?>
 <Package xmlns="http://schemas.microsoft.com/appx/2010/manifest" xmlns:mx="http://schemas.microsoft.com/appx/2013/xbox/manifest" IgnorableNamespaces="mx">
   <Applications>
     <Application ...>
       <Extensions>
         ...
         <mx:Extension Category="windows.xbox.networking">
           <mx:XboxNetworkingManifest>
             <mx:SocketDescriptions>
               <mx:SocketDescription Name="Xim_client_v1" SecureIpProtocol="Udp" BoundPort="17181-17183">
                 <mx:AllowedUsages>
                   <mx:SecureDeviceSocketUsage Type="Initiate" />
                   <mx:SecureDeviceSocketUsage Type="Accept" />
                   <mx:SecureDeviceSocketUsage Type="SendChat" />
                   <mx:SecureDeviceSocketUsage Type="SendGameData" />
                   <mx:SecureDeviceSocketUsage Type="ReceiveChat" />
                   <mx:SecureDeviceSocketUsage Type="ReceiveGameData" />
                 </mx:AllowedUsages>
               </mx:SocketDescription>
               <mx:SocketDescription Name="Xim_relay_acceptor_v1" SecureIpProtocol="Udp" BoundPort="17191-17390">
                 <mx:AllowedUsages>
                   <mx:SecureDeviceSocketUsage Type="Accept" />
                   <mx:SecureDeviceSocketUsage Type="SendChat" />
                   <mx:SecureDeviceSocketUsage Type="SendGameData" />
                   <mx:SecureDeviceSocketUsage Type="ReceiveChat" />
                   <mx:SecureDeviceSocketUsage Type="ReceiveGameData" />
                 </mx:AllowedUsages>
               </mx:SocketDescription>
             </mx:SocketDescriptions>
             <mx:SecureDeviceAssociationTemplates>
               <mx:SecureDeviceAssociationTemplate Name="Xim_relay_v1" InitiatorSocketDescription="Xim_client_v1" AcceptorSocketDescription="Xim_relay_acceptor_v1" MultiplayerSessionRequirement="Required">
                 <mx:AllowedUsages>
                   <mx:SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
                   <mx:SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
                   <mx:SecureDeviceAssociationUsage Type="AcceptOnXboxLiveCompute" />
                 </mx:AllowedUsages>
               </mx:SecureDeviceAssociationTemplate>
               <mx:SecureDeviceAssociationTemplate Name="Xim_peer_v1" InitiatorSocketDescription="Xim_client_v1" AcceptorSocketDescription="Xim_client_v1" MultiplayerSessionRequirement="Required">
                 <mx:AllowedUsages>
                   <mx:SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
                   <mx:SecureDeviceAssociationUsage Type="AcceptOnMicrosoftConsole" />
                   <mx:SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
                   <mx:SecureDeviceAssociationUsage Type="AcceptOnWindowsDesktop" />
                 </mx:AllowedUsages>
               </mx:SecureDeviceAssociationTemplate>
             </mx:SecureDeviceAssociationTemplates>
           </mx:XboxNetworkingManifest>
         </mx:Extension>
       </Extensions>
     </Application>
   </Applications>
 </Package>
```

## <a name="universal-windows-application-uwp-network-manifest-templates"></a><span data-ttu-id="cdd23-121">ユニバーサル Windows アプリケーション (UWP) ネットワーク マニフェスト テンプレート</span><span class="sxs-lookup"><span data-stu-id="cdd23-121">Universal Windows application (UWP) network manifest templates</span></span>

<span data-ttu-id="cdd23-122">XIM を使用するユニバーサル Windows アプリケーションでは、"ネットワーク マニフェスト" ファイル (パッケージ ルート ディレクトリの networkmanifest.xml ファイル) に特定のソケット記述およびテンプレートの内容が含まれている必要があります (ネットワーク マニフェストについて詳しくは、プラットフォームのドキュメントをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="cdd23-122">Any universal Windows application that uses XIM must ensure certain socket description and template content is included in its "network manifest" file (networkmanifest.xml file in the package root directory, see the platform documentation for more detail on network manifests).</span></span> <span data-ttu-id="cdd23-123">アプリに他のテンプレートが存在する可能性もありますが、次のスニペットは存在する必要があり、存在しないと XIM ネットワークへの移動は失敗します。</span><span class="sxs-lookup"><span data-stu-id="cdd23-123">The app may have other templates as well, but the following snippet must be present or else moving to a XIM network will fail:</span></span>

```xml
 <?xml version="1.0" encoding="utf-8"?>
 <NetworkManifest xmlns="http://schemas.microsoft.com/xbox/2012/networkmanifest">
   <SocketDescriptions>
     <SocketDescription Name="Xim_client_v1" SecureIpProtocol="Udp" BoundPort="17181-17183">
       <AllowedUsages>
         <SecureDeviceSocketUsage Type="Initiate" />
         <SecureDeviceSocketUsage Type="Accept" />
         <SecureDeviceSocketUsage Type="SendChat" />
         <SecureDeviceSocketUsage Type="SendGameData" />
         <SecureDeviceSocketUsage Type="ReceiveChat" />
         <SecureDeviceSocketUsage Type="ReceiveGameData" />
       </AllowedUsages>
     </SocketDescription>
     <SocketDescription Name="Xim_relay_acceptor_v1" SecureIpProtocol="Udp" BoundPort="17191-17390">
       <AllowedUsages>
         <SecureDeviceSocketUsage Type="Accept" />
         <SecureDeviceSocketUsage Type="SendChat" />
         <SecureDeviceSocketUsage Type="SendGameData" />
         <SecureDeviceSocketUsage Type="ReceiveChat" />
         <SecureDeviceSocketUsage Type="ReceiveGameData" />
       </AllowedUsages>
     </SocketDescription>
   </SocketDescriptions>
   <SecureDeviceAssociationTemplates>
     <SecureDeviceAssociationTemplate Name="Xim_relay_v1" InitiatorSocketDescription="Xim_client_v1" AcceptorSocketDescription="Xim_relay_acceptor_v1" MultiplayerSessionRequirement="Required">
       <AllowedUsages>
         <SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
         <SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
         <SecureDeviceAssociationUsage Type="AcceptOnXboxLiveCompute" />
       </AllowedUsages>
     </SecureDeviceAssociationTemplate>
     <SecureDeviceAssociationTemplate Name="Xim_peer_v1" InitiatorSocketDescription="Xim_client_v1" AcceptorSocketDescription="Xim_client_v1" MultiplayerSessionRequirement="Required">
       <AllowedUsages>
         <SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
         <SecureDeviceAssociationUsage Type="AcceptOnMicrosoftConsole" />
         <SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
         <SecureDeviceAssociationUsage Type="AcceptOnWindowsDesktop" />
       </AllowedUsages>
     </SecureDeviceAssociationTemplate>
   </SecureDeviceAssociationTemplates>
 </NetworkManifest>
```
