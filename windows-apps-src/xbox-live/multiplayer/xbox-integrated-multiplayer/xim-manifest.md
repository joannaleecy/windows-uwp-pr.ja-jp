---
title: XIM プロジェクト構成
description: Xbox Integrated Multiplayer (XIM) で使用する UWP アプリ マニフェストを構成する方法について説明します。
ms.assetid: 5d0ed7bd-9527-42a3-ae09-8cc9012c1111
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Xbox Integrated Multiplayer, マニフェスト
ms.localizationpriority: medium
ms.openlocfilehash: 926cc4495236fc4762f9b3176a5d6a4a579e2e2e
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8779019"
---
# <a name="xim-project-configuration"></a>XIM プロジェクト構成

## <a name="required-appxmanifest-capability-content"></a>必要な AppXManifest 機能の内容

本質的に XIM を使用するアプリケーションでは、インターネット経由とローカル ネットワーク経由の両方でネットワーク リソースに接続し、ネットワーク リソースからの接続を受け入れる必要があります。 また、ボイス チャットをサポートするマイク デバイスへのアクセスも必要です。 そのため、アプリの AppXManifest では、"internetClientServer" 機能、"privateNetworkClientServer" 機能、"microphone" デバイス機能を宣言する必要があります。 それぞれの詳細については、プラットフォームのドキュメントをご覧ください。 次のスニペットでは、Package/Capabilities ノードの下に対象のノードが存在する必要があり、それ以外の場合は接続とチャットがブロックされることを示しています。

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

## <a name="universal-windows-application-xbox-live-multiplayer-invite-protocol-activation-extension"></a>ユニバーサル Windows アプリケーションでの Xbox Live マルチプレイヤー招待プロトコルのアクティブ化拡張機能

Xbox Live マルチプレイヤー アプリケーションでは、ゲームへの招待をサポートすることが求められます。 ローカル ユーザーが受け入れた招待は、アプリのプロトコルのアクティブ化の形で到着します (プロトコルのアクティブ化については、プラットフォームのドキュメントをご覧ください)。 帯域外予約を通じて管理されている XIM ネットワーク以外の XIM を使用するアプリは、`xim::extract_protocol_activation_information()` メソッドを呼び出して実行時にプロトコルのアクティブ化処理を支援しますが、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでは、このような "ms-xbl-multiplayer" アクティブ化がシステムによってサポートされるということを AppXManifest "windows.protocol" 拡張機能でも静的に宣言する必要があります。 これは、次のスニペットに示す方法で行うことができます。

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

これが必要なのは、ユニバーサル Windows アプリケーションだけです。 Xbox One の排他リソース ("XDK") アプリケーションでは、プロトコルのアクティブ化拡張機能を明示的に宣言しません。これらは、Xbox Live タイトル ID 拡張機能を宣言することによって自動的に登録されます。

## <a name="xbox-one-exclusive-resource-application-network-manifest-templates"></a>Xbox One 排他リソース アプリケーション ネットワーク マニフェスト テンプレート

XIM を使用する Xbox One 排他リソース アプリケーションは、AppXManifest の "ネットワーク マニフェスト" 拡張機能に特定のソケット記述およびテンプレート コンテンツが含まれることを確認する必要があります (ネットワーク マニフェストについて詳しくは、プラットフォームのドキュメントをご覧ください)。 アプリに他のテンプレートが存在する可能性もありますが、次のスニペットは存在する必要があり、存在しないと XIM ネットワークへの移動は失敗します。

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

## <a name="universal-windows-application-uwp-network-manifest-templates"></a>ユニバーサル Windows アプリケーション (UWP) ネットワーク マニフェスト テンプレート

XIM を使用するユニバーサル Windows アプリケーションでは、"ネットワーク マニフェスト" ファイル (パッケージ ルート ディレクトリの networkmanifest.xml ファイル) に特定のソケット記述およびテンプレートの内容が含まれている必要があります (ネットワーク マニフェストについて詳しくは、プラットフォームのドキュメントをご覧ください)。 アプリに他のテンプレートが存在する可能性もありますが、次のスニペットは存在する必要があり、存在しないと XIM ネットワークへの移動は失敗します。

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
