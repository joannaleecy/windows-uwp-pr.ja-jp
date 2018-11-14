---
author: TylerMSFT
title: 予約済みのファイルと URI スキーム名
description: ここでは、アプリで利用できない予約済みのファイルと予約済みの URI スキーム名の一覧を示します。
ms.assetid: 7428C4A2-1380-4EBB-9C2A-7DF7B5C468AE
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91732a6c4abc082283dc397fb87ad38d9de452b8
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6452353"
---
# <a name="reserved-file-and-uri-scheme-names"></a>予約済みのファイルと URI スキーム名


URI の関連付けを使用すると、別のアプリで特定の URI スキームを起動したときに自分のアプリを自動的に起動できます。 ただし、予約済みであるために使用できない URI の関連付けがいくつかあります。 アプリが予約済みの関連付けを登録する場合、その登録は無視されます。 ここでは、アプリで利用できない予約済みのファイルと予約済みの URI スキーム名の一覧を示します。

## <a name="reserved-file-types"></a>予約済みのファイルの種類

予約済みのファイルの種類には、組み込みアプリ用に予約されているファイルの種類と、オペレーティング システム用に予約されているファイルの種類です。 組み込みアプリ用に予約されたファイルの種類を起動された場合、組み込みアプリだけが起動します。 そのファイルの種類にアプリを登録しようとすると無視されます。 同様に、オペレーティング システム用に予約されたファイルの種類にアプリを登録しようとした場合も無視されます。

組み込みアプリ用に予約済みのファイルの種類

<table>
<tr><td>.aac</td><td>.icon</td><td>.pem</td><td>.wdp</td></tr>
<tr><td>.aetx</td><td>.jpeg</td><td>.png</td><td>.wmv</td></tr>
<tr><td>.asf</td><td>.jxr</td><td>.pptm</td><td>.xap</td></tr>
<tr><td>.bmp</td><td>.m4a</td><td>.pptx</td><td>.xht</td></tr>
<tr><td>.cer</td><td>.m4r</td><td>.qcp</td><td>.xhtml</td></tr>
<tr><td>.dotm</td><td>.m4v</td><td>.rtf</td><td>.xltm</td></tr>
<tr><td>.dotx</td><td>.mov</td><td>.tif</td><td>.xltx</td></tr>
<tr><td>.gif</td><td>.mp3</td><td>.tiff</td><td>.xml</td></tr>
<tr><td>.hdp</td><td>.mp4</td><td>.txt</td><td>.xsl</td></tr>
<tr><td>.htm</td><td>.one</td><td>.url</td><td>.zip</td></tr>
<tr><td>.html</td><td>.onetoc2</td><td>.vcf</td><td></td></tr>
<tr><td>.ico</td><td>.p7b</td><td>.wav</td><td></td></tr>
</table> 

## <a name="file-types-reserved-for-the-operating-system"></a>オペレーティング システム用に予約済みのファイルの種類

オペレーティング システム用に次のファイルの種類が予約されています。

<table>
<tr><td>.accountpicture-ms</td><td>.its</td><td>.ops</td><td>.url</td></tr>
<tr><td>.ade</td><td>.jar</td><td>.pcd</td><td>.vb</td></tr>
<tr><td>.adp</td><td>.js</td><td>.pif</td><td>.vbe</td></tr>
<tr><td>.app</td><td>.jse</td><td>.pl</td><td>.vbp</td></tr>
<tr><td>.appx</td><td>.ksh</td><td>.plg</td><td>.vbs</td></tr>
<tr><td>.application</td><td>.lnk</td><td>.plsc</td><td>.vhd</td></tr>
<tr><td>.appref-ms</td><td>.mad</td><td>.prf</td><td>.vhdx</td></tr>
<tr><td>.asp</td><td>.maf</td><td>.prg</td><td>.vsmacros</td></tr>
<tr><td>.bas</td><td>.mag</td><td>.printerexport</td><td>.vsw</td></tr>
<tr><td>.bat</td><td>.mam</td><td>.provxml</td><td>.webpnp</td></tr>
<tr><td>.cab</td><td>.maq</td><td>.ps1</td><td>.ws</td></tr>
<tr><td>.chm</td><td>.mar</td><td>.ps1xml</td><td>.wsc</td></tr>
<tr><td>.cmd</td><td>.mas</td><td>.ps2</td><td>.wsf</td></tr>
<tr><td>.cnt</td><td>.mat</td><td>.ps2xml</td><td>.wsh</td></tr>
<tr><td>.com</td><td>.mau</td><td>.psc1</td><td>.xaml</td></tr>
<tr><td>.cpf</td><td>.mav</td><td>.psc2</td><td>.xdp</td></tr>
<tr><td>.cpl</td><td>.maw</td><td>.psm1</td><td>.xip</td></tr>
<tr><td>.crd</td><td>.mcf</td><td>.pst</td><td>.xnk</td></tr>
<tr><td>.crds</td><td>.mda</td><td>.pvw</td><td></td></tr>
<tr><td>.crt</td><td>.mdb</td><td>.py</td><td></td></tr>
<tr><td>.csh</td><td>.mde</td><td>.pyc</td><td></td></tr>
<tr><td>.der</td><td>.mdt</td><td>.pyo</td><td></td></tr>
<tr><td>.dll</td><td>.mdw</td><td>.rb</td><td></td></tr>
<tr><td>.drv</td><td>.mdz</td><td>.rbw</td><td></td></tr>
<tr><td>.exe</td><td>.msc</td><td>.rdp</td><td></td></tr>
<tr><td>.fxp</td><td>.msh</td><td>.reg</td><td></td></tr>
<tr><td>.fon</td><td>.msh1</td><td>.rgu</td><td></td></tr>
<tr><td>.gadget</td><td>.msh1xml</td><td>.scf</td><td></td></tr>
<tr><td>.grp</td><td>.msh2</td><td>.scr</td><td></td></tr>
<tr><td>.hlp</td><td>.msh2xml</td><td>.shb</td><td></td></tr>
<tr><td>.hme</td><td>.mshxml</td><td>.shs</td><td></td></tr>
<tr><td>.hpj</td><td>.msi</td><td>.sys</td><td></td></tr>
<tr><td>.hta</td><td>.msp</td><td>.theme</td><td></td></tr>
<tr><td>.inf</td><td>.mst</td><td>.tmp</td><td></td></tr>
<tr><td>.ins</td><td>.msu</td><td>.tsk</td><td></td></tr>
<tr><td>.isp</td><td>.ocx</td><td>.ttf</td><td></td></tr>
</table>

## <a name="reserved-uri-scheme-names"></a>予約済みの URI スキーム名

<table>
<tr><td>application.manifest</td><td>internetshortcut</td><td>ms-settings:network-mobilehotspot</td><td>shbfile</td></tr>
<tr><td>application.reference</td><td>JavaScript</td><td>ms-settings:network-proxy</td><td>shcmdfile</td></tr>
<tr><td>batfile</td><td>jscript</td><td>ms-settings:network-wifi</td><td>shsfile</td></tr>
<tr><td>bing.</td><td>jsefile</td><td>ms-settings:nfctransactions</td><td>smb</td></tr>
<tr><td>blob</td><td>ldap</td><td>ms-settings:notifications</td><td>stickynotes</td></tr>
<tr><td>callto</td><td>lnkfile</td><td>ms-settings:personalization</td><td>sysfile</td></tr>
<tr><td>cerfile</td><td>mailto</td><td>ms-settings:privacy-calendar</td><td>tel</td></tr>
<tr><td>chm.filecmdfilecomfile</td><td>マップ</td><td>ms-settings:privacy-contacts</td><td>telnet</td></tr>
<tr><td>cplfile</td><td>microsoft.powershellscript.1</td><td>ms-settings:privacy-customdevices</td><td>tn3270</td></tr>
<tr><td>dllfile</td><td>ms-accountpictureprovider</td><td>ms-settings:privacy-feedback</td><td>ttffile</td></tr>
<tr><td>drvfile</td><td>ms-appdata</td><td>ms-settings:privacy-location</td><td>unknown</td></tr>
<tr><td>dtmf</td><td>ms-appx</td><td>ms-settings:privacy-messaging</td><td>usertileprovider</td></tr>
<tr><td>exefile</td><td>ms-autoplay</td><td>ms-settings:privacy-microphone</td><td>vbefile</td></tr>
<tr><td>explorer.assocactionid.burnselection</td><td>ms-excel</td><td>ms-settings:privacy-speechtyping</td><td>vbscript</td></tr>
<tr><td>explorer.assocactionid.closesession</td><td>msi.package</td><td>ms-settings:privacy-webcam</td><td>vbsfile</td></tr>
<tr><td>explorer.assocactionid.erasedisc</td><td>msi.patch</td><td>ms-settings:proximity</td><td>wallet</td></tr>
<tr><td>explorer.assocactionid.zipselection</td><td>ms-powerpoint</td><td>ms-settings:regionlanguage</td><td>windows.gadget</td></tr>
<tr><td>explorer.assocprotocol.search-ms</td><td>ms-settings</td><td>ms-settings:screenrotation</td><td>windowsmediacenterapp</td></tr>
<tr><td>explorer.burnselection</td><td>ms-settings:batterysaver</td><td>ms-settings:speech</td><td>windowsmediacenterssl</td></tr>
<tr><td>explorer.burnselectionexplorer.closesession</td><td>ms-settings:batterysaver-settings</td><td>ms-settings:storagesense</td><td>windowsmediacenterweb</td></tr>
<tr><td>explorer.closesession</td><td>ms-settings:batterysaver-usagedetails</td><td>ms-settings:windowsupdate</td><td>wmp11.assocprotocol.mms</td></tr>
<tr><td>explorer.erasedisc</td><td>ms-settings:bluetooth</td><td>ms-settings:workplace</td><td>wsffile</td></tr>
<tr><td>explorer.zipselection</td><td>ms-settings:connecteddevices</td><td>ms-windows-store</td><td>wsfile</td></tr>
<tr><td>ファイル</td><td>ms-settings:cortanasearch</td><td>ms-word</td><td>wshfile</td></tr>
<tr><td>fonfile</td><td>ms-settings:datasense</td><td>ocxfile</td><td>xbls</td></tr>
<tr><td>hlpfile</td><td>ms-settings:dateandtime</td><td>office</td><td>zune</td></tr>
<tr><td>htafile</td><td>ms-settings:display</td><td>onenote</td><td></td></tr>
<tr><td>http</td><td>ms-settings:lockscreen</td><td>piffile</td><td></td></tr>
<tr><td>https</td><td>ms-settings:maps</td><td>regfile</td><td></td></tr>
<tr><td>iehistory</td><td>ms-settings:network-airplanemode</td><td>res</td><td></td></tr>
<tr><td>ierss</td><td>ms-settings:network-cellular</td><td>rlogin</td><td></td></tr>
<tr><td>inffile</td><td>ms-settings:network-dialup</td><td>scrfile</td><td></td></tr>
<tr><td>insfile</td><td>ms-settings:network-ethernet</td><td>scriptletfile</td><td></td></tr>
</table>
