---
title: 予約済みのファイルと URI スキーム名
description: URI の関連付けを使用すると、別のアプリで特定の URI スキームを起動したときに自分のアプリを自動的に起動できます。
ms.assetid: 7428C4A2-1380-4EBB-9C2A-7DF7B5C468AE
---
# 予約済みのファイルと URI スキーム名


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


URI の関連付けを使用すると、別のアプリで特定の URI スキームを起動したときに自分のアプリを自動的に起動できます。 ただし、使用できない URI の関連付けとして、予約済みの関連付けがいくつかあります。 アプリが予約済みの関連付けを登録する場合、その登録は無視されます。 ここでは、アプリで利用できない予約済みのファイルと予約済みの URI スキーム名の一覧を示します。

## 予約済みのファイルの種類


予約済みのファイルの種類には、組み込みアプリ用に予約されているファイルの種類と、オペレーティング システム用に予約されているファイルの種類です。 組み込みアプリ用に予約されたファイルの種類を起動された場合、組み込みアプリだけが起動します。 そのファイルの種類にアプリを登録しようとすると無視されます。 同様に、オペレーティング システム用に予約されたファイルの種類にアプリを登録しようとした場合も無視されます。

組み込みアプリ用に予約済みのファイルの種類

| .aac  | .icon    | .pem  | .wdp   |
|-------|----------|-------|--------|
| .aetx | .jpeg    | .png  | .wmv   |
| .asf  | .jxr     | .pptm | .xap   |
| .bmp  | .m4a     | .pptx | .xht   |
| .cer  | .m4r     | .qcp  | .xhtml |
| .dotm | .m4v     | .rtf  | .xltm  |
| .dotx | .mov     | .tif  | .xltx  |
| .gif  | .mp3     | .tiff | .xml   |
| .hdp  | .mp4     | .txt  | .xsl   |
| .htm  | .one     | .url  | .zip   |
| .html | .onetoc2 | .vcf  |        |
| .ico  | .p7b     | .wav  |        |
 

## オペレーティング システム用に予約済みのファイルの種類


オペレーティング システム用に次のファイルの種類が予約されています。

| .accountpicture-ms | .its      | .ops           | .url      |
|--------------------|----------|----------------|-----------|
| .ade               | .jar     | .pcd           | .vb       |
| .adp               | .js      | .pif           | .vbe      |
| .app               | .jse     | .pl            | .vbp      |
| .appx              | .ksh     | .plg           | .vbs      |
| .application       | .lnk     | .plsc          | .vhd      |
| .appref-ms         | .mad     | .prf           | .vhdx     |
| .asp               | .maf     | .prg           | .vsmacros |
| .bas               | .mag     | .printerexport | .vsw      |
| .bat               | .mam     | .provxml       | .webpnp   |
| .cab               | .maq     | .ps1           | .ws       |
| .chm               | .mar     | .ps1xml        | .wsc      |
| .cmd               | .mas     | .ps2           | .wsf      |
| .cnt               | .mat     | .ps2xml        | .wsh      |
| .com               | .mau     | .psc1          | .xaml     |
| .cpf               | .mav     | .psc2          | .xdp      |
| .cpl               | .maw     | .psm1          | .xip      |
| .crd               | .mcf     | .pst           | .xnk      |
| .crds              | .mda     | .pvw           |           |
| .crt               | .mdb     | .py            |           |
| .csh               | .mde     | .pyc           |           |
| .der               | .mdt     | .pyo           |           |
| .dll               | .mdw     | .rb            |           |
| .drv               | .mdz     | .rbw           |           |
| .exe               | .msc     | .rdp           |           |
| .fxp               | .msh     | .reg           |           |
| .fon               | .msh1    | .rgu           |           |
| .gadget            | .msh1xml | .scf           |           |
| .grp               | .msh2    | .scr           |           |
| .hlp               | .msh2xml | .shb           |           |
| .hme               | .mshxml  | .shs           |           |
| .hpj               | .msi     | .sys           |           |
| .hta               | .msp     | .theme         |           |
| .inf               | .mst     | .tmp           |           |
| .ins               | .msu     | .tsk           |           |
| .isp               | .ocx     | .ttf           |           |
 

## 予約済みの URI スキーム名


| application.manifest                        | internetshortcut                      | ms-settings:network-mobilehotspot | shbfile                 |
|---------------------------------------------|---------------------------------------|-----------------------------------|-------------------------|
| application.reference                       | JavaScript                            | ms-settings:network-proxy         | shcmdfile               |
| batfile                                     | jscript                               | ms-settings:network-wifi          | shsfile                 |
| bing.                                        | jsefile                               | ms-settings:nfctransactions       | smb                     |
| blob                                        | ldap                                  | ms-settings:notifications         | stickynotes             |
| callto                                      | lnkfile                               | ms-settings:personalization       | sysfile                 |
| cerfile                                     | mailto                                | ms-settings:privacy-calendar      | tel                     |
| chm.filecmdfilecomfile                      | マップ                                  | ms-settings:privacy-contacts      | telnet                  |
| cplfile                                     | microsoft.powershellscript.1          | ms-settings:privacy-customdevices | tn3270                  |
| dllfile                                     | ms-accountpictureprovider             | ms-settings:privacy-feedback      | ttffile                 |
| drvfile                                     | ms-appdata                            | ms-settings:privacy-location      | unknown                 |
| dtmf                                        | ms-appx                               | ms-settings:privacy-messaging     | usertileprovider        |
| exefile                                     | ms-autoplay                           | ms-settings:privacy-microphone    | vbefile                 |
| explorer.assocactionid.burnselection        | ms-excel                              | ms-settings:privacy-speechtyping  | vbscript                |
| explorer.assocactionid.closesession         | msi.package                           | ms-settings:privacy-webcam        | vbsfile                 |
| explorer.assocactionid.erasedisc            | msi.patch                             | ms-settings:proximity             | wallet                  |
| explorer.assocactionid.zipselection         | ms-powerpoint                         | ms-settings:regionlanguage        | windows.gadget          |
| explorer.assocprotocol.search-ms            | ms-settings                           | ms-settings:screenrotation        | windowsmediacenterapp   |
| explorer.burnselection                      | ms-settings:batterysaver              | ms-settings:speech                | windowsmediacenterssl   |
| explorer.burnselectionexplorer.closesession | ms-settings:batterysaver-settings     | ms-settings:storagesense          | windowsmediacenterweb   |
| explorer.closesession                       | ms-settings:batterysaver-usagedetails | ms-settings:windowsupdate         | wmp11.assocprotocol.mms |
| explorer.erasedisc                          | ms-settings:bluetooth                 | ms-settings:workplace             | wsffile                 |
| explorer.zipselection                       | ms-settings:connecteddevices          | ms-windows-store                  | wsfile                  |
| ファイル                                        | ms-settings:cortanasearch             | ms-word                           | wshfile                 |
| fonfile                                     | ms-settings:datasense                 | ocxfile                           | xbls                    |
| hlpfile                                     | ms-settings:dateandtime               | office                            | zune                    |
| htafile                                     | ms-settings:display                   | onenote                           |                         |
| http                                        | ms-settings:lockscreen                | piffile                           |                         |
| https                                       | ms-settings:maps                      | regfile                           |                         |
| iehistory                                   | ms-settings:network-airplanemode      | res                               |                         |
| ierss                                       | ms-settings:network-cellular          | rlogin                            |                         |
| inffile                                     | ms-settings:network-dialup            | scrfile                           |                         |
| insfile                                     | ms-settings:network-ethernet          | scriptletfile                     |                         |

 

 

 





<!--HONumber=Mar16_HO1-->


