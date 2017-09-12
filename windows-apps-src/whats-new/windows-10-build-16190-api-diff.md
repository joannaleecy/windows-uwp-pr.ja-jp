---
author: QuinnRadich
title: "Windows 10 ビルド 16190 の API の変更"
description: "開発者は、次の一覧を使用して、Windows 10 SDK Preview Build 16190 で追加または変更された名前空間を確認することができます。"
keywords: "新着情報, 新機能, 更新, フライト, フライト, API, 15021"
ms.author: quradic
ms.date: 5/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.assetid: 6932c7cb-300b-4558-a346-dd6d18a969f6
redirect_url: windows-10-latest-preview-api-diff
ms.openlocfilehash: ed99c7e883a1dff96362f82b0907588fe9513795
ms.sourcegitcommit: 11664964e548a2af30d6e176c515cdbf330934ac
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/28/2017
---
# <a name="new-apis-in-the-windows-10-sdk-preview-build-16190"></a>Windows 10 SDK Preview Build 16190 の新しい API

Windows 10 SDK Preview Build 16190 で追加および更新された API 名前空間を [Windows Insider](https://insider.windows.com/) が利用できるようになりました。 このリリースは、[Microsoft Build 2017 開発者カンファレンス](https://developer.microsoft.com/windows/projects/events/build/2017?ocid=wdgbld17_intreferral_devcenterhp_null_null_devcenter_hppost&utm_campaign=wdgbld17&utm_medium=internalreferral&utm_source=devcenterhp&utm_content=devcenter_hppost)に付随するものです。

Windows 10 の最新の公開リリースである [Version 1703](windows-10-version-1703-api-diff.md) 以降に追加または変更された名前空間について公開されたプレリリース版のドキュメントの一覧を次に示します。 プレリリース版のドキュメントは、完全なものではなく、変更される可能性があることに注意してください。

## <a name="windowsapplicationmodel"></a>windows.applicationmodel

### [<a name="windowsapplicationmodelactivation"></a>windows.applicationmodel.activation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation)

#### [<a name="activationkind"></a>activationkind](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.activationkind)

activationkind

#### [<a name="consoleactivatedeventargs"></a>consoleactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.consoleactivatedeventargs)

consoleactivatedeventargs <br> consoleactivatedeventargs.arguments <br> consoleactivatedeventargs.kind <br> consoleactivatedeventargs.previousexecutionstate <br> consoleactivatedeventargs.splashscreen

#### [<a name="iconsoleactivatedeventargs"></a>iconsoleactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.iconsoleactivatedeventargs)

iconsoleactivatedeventargs <br> iconsoleactivatedeventargs.arguments

### [<a name="windowsapplicationmodelcards"></a>windows.applicationmodel.cards](https://docs.microsoft.com/uwp/api/windows.applicationmodel.cards)

#### [<a name="cardbuilder"></a>cardbuilder](https://docs.microsoft.com/uwp/api/windows.applicationmodel.cards.cardbuilder)

cardbuilder <br> cardbuilder.createcardelementfromjson

#### [<a name="icardbuilderstatics"></a>icardbuilderstatics](https://docs.microsoft.com/uwp/api/windows.applicationmodel.cards.icardbuilderstatics)

icardbuilderstatics <br> icardbuilderstatics.createcardelementfromjson

#### [<a name="icardelement"></a>icardelement](https://docs.microsoft.com/uwp/api/windows.applicationmodel.cards.icardelement)

icardelement <br> icardelement.tojson

### [<a name="windowsapplicationmodelcore"></a>windows.applicationmodel.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core)

#### [<a name="coreapplication"></a>coreapplication](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplication)

coreapplication.requestrestartasync <br> coreapplication.requestrestartforuserasync

#### [<a name="coreapplicationview"></a>coreapplicationview](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationview)

coreapplicationview.dispatcherqueue

#### [<a name="restartresult"></a>restartresult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.restartresult)

restartresult

### [<a name="windowsapplicationmodeldatatransfersharetarget"></a>windows.applicationmodel.datatransfer.sharetarget](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharetarget)

#### [<a name="shareoperation"></a>shareoperation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharetarget.shareoperation)

shareoperation.contacts

### [<a name="windowsapplicationmodeldatatransfer"></a>windows.applicationmodel.datatransfer](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer)

#### [<a name="datatransfermanager"></a>datatransfermanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datatransfermanager)

datatransfermanager.showshareui

#### [<a name="idatatransfermanagerstatics3"></a>idatatransfermanagerstatics3](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.idatatransfermanagerstatics3)

idatatransfermanagerstatics3 <br> idatatransfermanagerstatics3.showshareui

#### [<a name="shareuioptions"></a>shareuioptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.shareuioptions)

shareuioptions <br> shareuioptions.invocationrect <br> shareuioptions.sharetheme <br> shareuioptions.shareuioptions

#### [<a name="shareuitheme"></a>shareuitheme](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.shareuitheme)

shareuitheme

### [<a name="windowsapplicationmodelpayments"></a>windows.applicationmodel.payments](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments)

#### [<a name="paymentmediator"></a>paymentmediator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.paymentmediator)

paymentmediator.canmakepaymentasync

### [<a name="windowsapplicationmodeluseractivitiescore"></a>windows.applicationmodel.useractivities.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.core)

#### [<a name="coreuseractivitymanager"></a>coreuseractivitymanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.core.coreuseractivitymanager)

coreuseractivitymanager <br> coreuseractivitymanager.createuseractivitysessioninbackground

### [<a name="windowsapplicationmodeluseractivities"></a>windows.applicationmodel.useractivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

#### [<a name="useractivity"></a>useractivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)

useractivity <br> useractivity.activationuri <br> useractivity.activityid <br> useractivity.contentmetadata <br> useractivity.contenttype <br> useractivity.contenturi <br> useractivity.createsession <br> useractivity.fallbackuri <br> useractivity.saveasync <br> useractivity.state <br> useractivity.visualelements

#### [<a name="useractivitychannel"></a>useractivitychannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel)

useractivitychannel <br> useractivitychannel.getdefault <br> useractivitychannel.getorcreateuseractivityasync <br> useractivitychannel.getorcreateuseractivityasync

#### [<a name="useractivitysession"></a>useractivitysession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysession)

useractivitysession <br> useractivitysession.activityid <br> useractivitysession.close

#### [<a name="useractivitystate"></a>useractivitystate](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitystate)

useractivitystate

#### [<a name="useractivityvisualelements"></a>useractivityvisualelements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements)

useractivityvisualelements <br> useractivityvisualelements.backgroundcolor <br> useractivityvisualelements.content <br> useractivityvisualelements.description <br> useractivityvisualelements.displaytext <br> useractivityvisualelements.imageicon

## <a name="windowsdevices"></a>windows.devices

### [<a name="windowsdevicesbluetoothgenericattributeprofile"></a>windows.devices.bluetooth.genericattributeprofile](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.genericattributeprofile)

#### [<a name="gattclientnotificationresult"></a>gattclientnotificationresult](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.genericattributeprofile.gattclientnotificationresult)

gattclientnotificationresult.bytessent

### [<a name="windowsdevicesbluetooth"></a>windows.devices.bluetooth](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth)

#### [<a name="bluetoothdevice"></a>bluetoothdevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothdevice)

bluetoothdevice.bluetoothdeviceid

#### [<a name="bluetoothdeviceid"></a>bluetoothdeviceid](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothdeviceid)

bluetoothdeviceid.fromid

#### [<a name="bluetoothledevice"></a>bluetoothledevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothledevice)

bluetoothledevice.bluetoothdeviceid

## <a name="windowsgraphics"></a>windows.graphics

### [<a name="windowsgraphicsprintingprintticket"></a>windows.graphics.printing.printticket](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket)

#### [<a name="printticketcapabilities"></a>printticketcapabilities](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketcapabilities)

printticketcapabilities <br> printticketcapabilities.documentbindingfeature <br> printticketcapabilities.documentcollatefeature <br> printticketcapabilities.documentduplexfeature <br> printticketcapabilities.documentholepunchfeature <br> printticketcapabilities.documentinputbinfeature <br> printticketcapabilities.documentnupfeature <br> printticketcapabilities.documentstaplefeature <br> printticketcapabilities.getfeature <br> printticketcapabilities.getparameterdefinition <br> printticketcapabilities.jobpasscodefeature <br> printticketcapabilities.name <br> printticketcapabilities.pageborderlessfeature <br> printticketcapabilities.pagemediasizefeature <br> printticketcapabilities.pagemediatypefeature <br> printticketcapabilities.pageorientationfeature <br> printticketcapabilities.pageoutputcolorfeature <br> printticketcapabilities.pageoutputqualityfeature <br> printticketcapabilities.pageresolutionfeature <br> printticketcapabilities.xmlnamespace <br> printticketcapabilities.xmlnode

#### [<a name="printticketfeature"></a>printticketfeature](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketfeature)

printticketfeature <br> printticketfeature.displayname <br> printticketfeature.getoption <br> printticketfeature.getselectedoption <br> printticketfeature.name <br> printticketfeature.options <br> printticketfeature.selectiontype <br> printticketfeature.setselectedoption <br> printticketfeature.xmlnamespace <br> printticketfeature.xmlnode

#### [<a name="printticketfeatureselectiontype"></a>printticketfeatureselectiontype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketfeatureselectiontype)

printticketfeatureselectiontype

#### [<a name="printticketoption"></a>printticketoption](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketoption)

printticketoption <br> printticketoption.displayname <br> printticketoption.getpropertynode <br> printticketoption.getpropertyvalue <br> printticketoption.getscoredpropertynode <br> printticketoption.getscoredpropertyvalue <br> printticketoption.name <br> printticketoption.xmlnamespace <br> printticketoption.xmlnode

#### [<a name="printticketparameterdatatype"></a>printticketparameterdatatype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterdatatype)

printticketparameterdatatype

#### [<a name="printticketparameterdefinition"></a>printticketparameterdefinition](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterdefinition)

printticketparameterdefinition <br> printticketparameterdefinition.datatype <br> printticketparameterdefinition.name <br> printticketparameterdefinition.rangemax <br> printticketparameterdefinition.rangemin <br> printticketparameterdefinition.unittype <br> printticketparameterdefinition.xmlnamespace <br> printticketparameterdefinition.xmlnode

#### [<a name="printticketparameterinitializer"></a>printticketparameterinitializer](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterinitializer)

printticketparameterinitializer <br> printticketparameterinitializer.name <br> printticketparameterinitializer.value <br> printticketparameterinitializer.xmlnamespace <br> printticketparameterinitializer.xmlnode

#### [<a name="printticketvalue"></a>printticketvalue](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketvalue)

printticketvalue <br> printticketvalue.getvalueasinteger <br> printticketvalue.getvalueasstring <br> printticketvalue.type

#### [<a name="printticketvaluetype"></a>printticketvaluetype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketvaluetype)

printticketvaluetype

#### [<a name="workflowprintticket"></a>workflowprintticket](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.workflowprintticket)

workflowprintticket <br> workflowprintticket.documentbindingfeature <br> workflowprintticket.documentcollatefeature <br> workflowprintticket.documentduplexfeature <br> workflowprintticket.documentholepunchfeature <br> workflowprintticket.documentinputbinfeature <br> workflowprintticket.documentnupfeature <br> workflowprintticket.documentstaplefeature <br> workflowprintticket.getcapabilities <br> workflowprintticket.getfeature <br> workflowprintticket.getparameterinitializer <br> workflowprintticket.jobpasscodefeature <br> workflowprintticket.mergeandvalidateticket <br> workflowprintticket.name <br> workflowprintticket.notifyxmlchangedasync <br> workflowprintticket.pageborderlessfeature <br> workflowprintticket.pagemediasizefeature <br> workflowprintticket.pagemediatypefeature <br> workflowprintticket.pageorientationfeature <br> workflowprintticket.pageoutputcolorfeature <br> workflowprintticket.pageoutputqualityfeature <br> workflowprintticket.pageresolutionfeature <br> workflowprintticket.setparameterinitializerasinteger <br> workflowprintticket.setparameterinitializerasstring <br> workflowprintticket.validateasync <br> workflowprintticket.xmlnamespace <br> workflowprintticket.xmlnode

#### [<a name="workflowprintticketvalidationresult"></a>workflowprintticketvalidationresult](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.workflowprintticketvalidationresult)

workflowprintticketvalidationresult <br> workflowprintticketvalidationresult.extendederror <br> workflowprintticketvalidationresult.validated

### [<a name="windowsgraphicsprintingworkflow"></a>windows.graphics.printing.workflow](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow)

#### [<a name="printworkflowbackgroundsession"></a>printworkflowbackgroundsession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession)

printworkflowbackgroundsession <br> printworkflowbackgroundsession.setuprequested <br> printworkflowbackgroundsession.start <br> printworkflowbackgroundsession.status <br> printworkflowbackgroundsession.submitted

#### [<a name="printworkflowbackgroundsetuprequestedeventargs"></a>printworkflowbackgroundsetuprequestedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsetuprequestedeventargs)

printworkflowbackgroundsetuprequestedeventargs <br> printworkflowbackgroundsetuprequestedeventargs.configuration <br> printworkflowbackgroundsetuprequestedeventargs.getdeferral <br> printworkflowbackgroundsetuprequestedeventargs.getuserprintticketasync <br> printworkflowbackgroundsetuprequestedeventargs.setrequiresui

#### [<a name="printworkflowconfiguration"></a>printworkflowconfiguration](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowconfiguration)

printworkflowconfiguration <br> printworkflowconfiguration.jobtitle <br> printworkflowconfiguration.sourceapplicationexecutablename

#### [<a name="printworkflowforegroundsession"></a>printworkflowforegroundsession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession)

printworkflowforegroundsession <br> printworkflowforegroundsession.setuprequested <br> printworkflowforegroundsession.start <br> printworkflowforegroundsession.status <br> printworkflowforegroundsession.xpsdataavailable

#### [<a name="printworkflowforegroundsetuprequestedeventargs"></a>printworkflowforegroundsetuprequestedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsetuprequestedeventargs)

printworkflowforegroundsetuprequestedeventargs <br> printworkflowforegroundsetuprequestedeventargs.configuration <br> printworkflowforegroundsetuprequestedeventargs.getdeferral <br> printworkflowforegroundsetuprequestedeventargs.getuserprintticketasync

#### [<a name="printworkflowobjectmodelsourcefilecontent"></a>printworkflowobjectmodelsourcefilecontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowobjectmodelsourcefilecontent)

printworkflowobjectmodelsourcefilecontent

#### [<a name="printworkflowobjectmodeltargetpackage"></a>printworkflowobjectmodeltargetpackage](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowobjectmodeltargetpackage)

printworkflowobjectmodeltargetpackage

#### [<a name="printworkflowsessionstatus"></a>printworkflowsessionstatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsessionstatus)

printworkflowsessionstatus

#### [<a name="printworkflowsourcecontent"></a>printworkflowsourcecontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsourcecontent)

printworkflowsourcecontent <br> printworkflowsourcecontent.getjobprintticketasync <br> printworkflowsourcecontent.getsourcespooldataasstreamcontent <br> printworkflowsourcecontent.getsourcespooldataasxpsobjectmodel

#### [<a name="printworkflowspoolstreamcontent"></a>printworkflowspoolstreamcontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowspoolstreamcontent)

printworkflowspoolstreamcontent <br> printworkflowspoolstreamcontent.getinputstream

#### [<a name="printworkflowstreamtarget"></a>printworkflowstreamtarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowstreamtarget)

printworkflowstreamtarget <br> printworkflowstreamtarget.getoutputstream

#### [<a name="printworkflowsubmittedeventargs"></a>printworkflowsubmittedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedeventargs)

printworkflowsubmittedeventargs <br> printworkflowsubmittedeventargs.getdeferral <br> printworkflowsubmittedeventargs.gettarget <br> printworkflowsubmittedeventargs.operation

#### [<a name="printworkflowsubmittedoperation"></a>printworkflowsubmittedoperation](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation)

printworkflowsubmittedoperation <br> printworkflowsubmittedoperation.complete <br> printworkflowsubmittedoperation.configuration <br> printworkflowsubmittedoperation.xpscontent

#### [<a name="printworkflowsubmittedstatus"></a>printworkflowsubmittedstatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedstatus)

printworkflowsubmittedstatus

#### [<a name="printworkflowtarget"></a>printworkflowtarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtarget)

printworkflowtarget <br> printworkflowtarget.targetasstream <br> printworkflowtarget.targetasxpsobjectmodelpackage

#### [<a name="printworkflowtriggerdetails"></a>printworkflowtriggerdetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails)

printworkflowtriggerdetails <br> printworkflowtriggerdetails.printworkflowsession

#### [<a name="printworkflowuiactivatedeventargs"></a>printworkflowuiactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowuiactivatedeventargs)

printworkflowuiactivatedeventargs <br> printworkflowuiactivatedeventargs.kind <br> printworkflowuiactivatedeventargs.previousexecutionstate <br> printworkflowuiactivatedeventargs.printworkflowsession <br> printworkflowuiactivatedeventargs.splashscreen <br> printworkflowuiactivatedeventargs.user

#### [<a name="printworkflowxpsdataavailableeventargs"></a>printworkflowxpsdataavailableeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowxpsdataavailableeventargs)

printworkflowxpsdataavailableeventargs <br> printworkflowxpsdataavailableeventargs.getdeferral <br> printworkflowxpsdataavailableeventargs.operation

### [<a name="windowsgraphicsprinting3d"></a>windows.graphics.printing3d](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d)

#### [<a name="printing3d3mfpackage"></a>printing3d3mfpackage](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d.printing3d3mfpackage)

printing3d3mfpackage.compression

#### [<a name="printing3dpackagecompression"></a>printing3dpackagecompression](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d.printing3dpackagecompression)

printing3dpackagecompression

## <a name="windowsmedia"></a>windows.media

### [<a name="windowsmediacore"></a>windows.media.core](https://docs.microsoft.com/uwp/api/windows.media.core)

#### [<a name="mediastreamsource"></a>mediastreamsource](https://docs.microsoft.com/uwp/api/windows.media.core.mediastreamsource)

mediastreamsource.islive

#### [<a name="msestreamsource"></a>msestreamsource](https://docs.microsoft.com/uwp/api/windows.media.core.msestreamsource)

msestreamsource.liveseekablerange

### [<a name="windowsmediaplayback"></a>windows.media.playback](https://docs.microsoft.com/uwp/api/windows.media.playback)

#### [<a name="mediaplaybacksessionbufferingstartedeventargs"></a>mediaplaybacksessionbufferingstartedeventargs](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionbufferingstartedeventargs)

mediaplaybacksessionbufferingstartedeventargs <br> mediaplaybacksessionbufferingstartedeventargs.isplaybackinterruption

#### [<a name="mediaplayer"></a>mediaplayer](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer)

mediaplayer.rendersubtitlestosurface <br> mediaplayer.rendersubtitlestosurface <br> mediaplayer.subtitleframechanged

### [<a name="windowsmediaprotectionplayready"></a>windows.media.protection.playready](https://docs.microsoft.com/uwp/api/windows.media.protection.playready)

#### [<a name="playreadyencryptionalgorithm"></a>playreadyencryptionalgorithm](https://docs.microsoft.com/uwp/api/windows.media.protection.playready.playreadyencryptionalgorithm)

playreadyencryptionalgorithm

#### [<a name="playreadyhardwaredrmfeatures"></a>playreadyhardwaredrmfeatures](https://docs.microsoft.com/uwp/api/windows.media.protection.playready.playreadyhardwaredrmfeatures)

playreadyhardwaredrmfeatures

### [<a name="windowsmediastreamingadaptive"></a>windows.media.streaming.adaptive](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive)

#### [<a name="adaptivemediasourcediagnosticavailableeventargs"></a>adaptivemediasourcediagnosticavailableeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnosticavailableeventargs)

adaptivemediasourcediagnosticavailableeventargs.extendederror

#### [<a name="adaptivemediasourcediagnostictype"></a>adaptivemediasourcediagnostictype](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnostictype)

adaptivemediasourcediagnostictype

## <a name="windowssecurity"></a>windows.security

### [<a name="windowssecurityauthenticationwebprovider"></a>windows.security.authentication.web.provider](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider)

#### [<a name="webaccountmanager"></a>webaccountmanager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider.webaccountmanager)

webaccountmanager.invalidateappcacheasync <br> webaccountmanager.invalidateappcacheasync

## <a name="windowsstorage"></a>windows.storage

### [<a name="windowsstorage"></a>windows.storage](https://docs.microsoft.com/uwp/api/windows.storage)

#### [<a name="storagelibrary"></a>storagelibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)

storagelibrary.arefoldersuggestionsavailableasync

## <a name="windowssystem"></a>windows.system

### [<a name="windowssystemdiagnostics"></a>windows.system.diagnostics](https://docs.microsoft.com/uwp/api/windows.system.diagnostics)

#### [<a name="processdiagnosticinfo"></a>processdiagnosticinfo](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.processdiagnosticinfo)

processdiagnosticinfo.ispackaged <br> processdiagnosticinfo.trygetappdiagnosticinfo <br> processdiagnosticinfo.trygetforprocessid

### [<a name="windowssystemuserprofile"></a>windows.system.userprofile](https://docs.microsoft.com/uwp/api/windows.system.userprofile)

#### [<a name="globalizationpreferences"></a>globalizationpreferences](https://docs.microsoft.com/uwp/api/windows.system.userprofile.globalizationpreferences)

globalizationpreferences.trysethomegeographicregion <br> globalizationpreferences.trysetlanguages

### [<a name="windowssystem"></a>windows.system](https://docs.microsoft.com/uwp/api/windows.system)

#### [<a name="appdiagnosticinfo"></a>appdiagnosticinfo](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfo)

appdiagnosticinfo.createresourcegroupwatcher <br> appdiagnosticinfo.createwatcher <br> appdiagnosticinfo.getresourcegroups <br> appdiagnosticinfo.requestinfoforappasync <br> appdiagnosticinfo.requestinfoforpackageasync <br> appdiagnosticinfo.requestpermissionasync

#### [<a name="appdiagnosticinfowatcher"></a>appdiagnosticinfowatcher](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatcher)

appdiagnosticinfowatcher <br> appdiagnosticinfowatcher.added <br> appdiagnosticinfowatcher.enumerationcompleted <br> appdiagnosticinfowatcher.removed <br> appdiagnosticinfowatcher.start <br> appdiagnosticinfowatcher.status <br> appdiagnosticinfowatcher.stop <br> appdiagnosticinfowatcher.stopped

#### [<a name="appdiagnosticinfowatchereventargs"></a>appdiagnosticinfowatchereventargs](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatchereventargs)

appdiagnosticinfowatchereventargs <br> appdiagnosticinfowatchereventargs.appdiagnosticinfo

#### [<a name="appdiagnosticinfowatcherstatus"></a>appdiagnosticinfowatcherstatus](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatcherstatus)

appdiagnosticinfowatcherstatus

#### [<a name="backgroundtaskreport"></a>backgroundtaskreport](https://docs.microsoft.com/uwp/api/windows.system.backgroundtaskreport)

backgroundtaskreport <br> backgroundtaskreport.name <br> backgroundtaskreport.trigger

#### [<a name="diagnosticpermission"></a>diagnosticpermission](https://docs.microsoft.com/uwp/api/windows.system.diagnosticpermission)

diagnosticpermission

#### [<a name="dispatcherqueue"></a>dispatcherqueue](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueue)

dispatcherqueue <br> dispatcherqueue.createtimer <br> dispatcherqueue.getforcurrentthread <br> dispatcherqueue.tryenqueue <br> dispatcherqueue.tryenqueue

#### [<a name="dispatcherqueuecontroller"></a>dispatcherqueuecontroller](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuecontroller)

dispatcherqueuecontroller <br> dispatcherqueuecontroller.createqueuewithdedicatedthread <br> dispatcherqueuecontroller.dispatcherqueue <br> dispatcherqueuecontroller.queueshutdown <br> dispatcherqueuecontroller.shutdownqueueasync

#### [<a name="dispatcherqueuehandler"></a>dispatcherqueuehandler](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuehandler)

dispatcherqueuehandler

#### [<a name="dispatcherqueuepriority"></a>dispatcherqueuepriority](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuepriority)

dispatcherqueuepriority

#### [<a name="dispatcherqueuetimer"></a>dispatcherqueuetimer](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuetimer)

dispatcherqueuetimer <br> dispatcherqueuetimer.interval <br> dispatcherqueuetimer.isrepeating <br> dispatcherqueuetimer.isstarted <br> dispatcherqueuetimer.start <br> dispatcherqueuetimer.stop <br> dispatcherqueuetimer.tick

#### [<a name="energyquotastate"></a>energyquotastate](https://docs.microsoft.com/uwp/api/windows.system.energyquotastate)

energyquotastate

#### [<a name="executionstate"></a>executionstate](https://docs.microsoft.com/uwp/api/windows.system.executionstate)

executionstate

#### [<a name="memoryreport"></a>memoryreport](https://docs.microsoft.com/uwp/api/windows.system.memoryreport)

memoryreport <br> memoryreport.commitusagelevel <br> memoryreport.commitusagelimit <br> memoryreport.privatecommitusage <br> memoryreport.totalcommitusage

#### [<a name="resourcegroupinfo"></a>resourcegroupinfo](https://docs.microsoft.com/uwp/api/windows.system.resourcegroupinfo)

resourcegroupinfo <br> resourcegroupinfo.getbackgroundtaskreports <br> resourcegroupinfo.getmemoryreport <br> resourcegroupinfo.getprocessdiagnostics <br> resourcegroupinfo.getstatereport <br> resourcegroupinfo.instanceid <br> resourcegroupinfo.isshared

#### [<a name="resourcegroupinfowatcher"></a>resourcegroupinfowatcher](https://docs.microsoft.com/uwp/api/windows.system.resourcegroupinfowatcher)

resourcegroupinfowatcher <br> resourcegroupinfowatcher.added <br> resourcegroupinfowatcher.enumerationcompleted <br> resourcegroupinfowatcher.executionstatechanged <br> resourcegroupinfowatcher.removed <br> resourcegroupinfowatcher.start <br> resourcegroupinfowatcher.status <br> resourcegroupinfowatcher.stop <br> resourcegroupinfowatcher.stopped

#### [<a name="resourcegroupinfowatchereventargs"></a>resourcegroupinfowatchereventargs](https://docs.microsoft.com/uwp/api/windows.system.resourcegroupinfowatchereventargs)

resourcegroupinfowatchereventargs <br> resourcegroupinfowatchereventargs.appdiagnosticinfo <br> resourcegroupinfowatchereventargs.resourcegroupinfo

#### [<a name="resourcegroupinfowatcherexecutionstatechangedeventargs"></a>resourcegroupinfowatcherexecutionstatechangedeventargs](https://docs.microsoft.com/uwp/api/windows.system.resourcegroupinfowatcherexecutionstatechangedeventargs)

resourcegroupinfowatcherexecutionstatechangedeventargs <br> resourcegroupinfowatcherexecutionstatechangedeventargs.appdiagnosticinfo <br> resourcegroupinfowatcherexecutionstatechangedeventargs.resourcegroupinfo

#### [<a name="resourcegroupinfowatcherstatus"></a>resourcegroupinfowatcherstatus](https://docs.microsoft.com/uwp/api/windows.system.resourcegroupinfowatcherstatus)

resourcegroupinfowatcherstatus

#### [<a name="statereport"></a>statereport](https://docs.microsoft.com/uwp/api/windows.system.statereport)

statereport <br> statereport.energyquotastate <br> statereport.executionstate

## <a name="windowsui"></a>windows.ui

### [<a name="windowsuicompositioneffects"></a>windows.ui.composition.effects](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects)

#### [<a name="scenelightingeffect"></a>scenelightingeffect](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)

scenelightingeffect.brdftype

#### [<a name="scenelightingeffectbrdftype"></a>scenelightingeffectbrdftype](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffectbrdftype)

scenelightingeffectbrdftype

### [<a name="windowsuicomposition"></a>windows.ui.composition](https://docs.microsoft.com/uwp/api/windows.ui.composition)

#### [<a name="ambientlight"></a>ambientlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.ambientlight)

ambientlight.intensity

#### [<a name="compositionanchor"></a>compositionanchor](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanchor)

compositionanchor

#### [<a name="compositionanimation"></a>compositionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimation)

compositionanimation.expressionproperties

#### [<a name="compositiondropshadowsourcepolicy"></a>compositiondropshadowsourcepolicy](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)

compositiondropshadowsourcepolicy

#### [<a name="compositionisland"></a>compositionisland](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionisland)

compositionisland <br> compositionisland.actualsize <br> compositionisland.actualsizechanged <br> compositionisland.primarydpiscale <br> compositionisland.rasterizationscale <br> compositionisland.rasterizationscaleanchor <br> compositionisland.requestedsize <br> compositionisland.scalechanged <br> compositionisland.snaptopixeladjustment <br> compositionisland.snaptopixeladjustmentchanged <br> compositionisland.visibilityhintschanged <br> compositionisland.visiblityhints

#### [<a name="compositionislandeventargs"></a>compositionislandeventargs](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionislandeventargs)

compositionislandeventargs

#### [<a name="compositionislandvisibilityhints"></a>compositionislandvisibilityhints](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionislandvisibilityhints)

compositionislandvisibilityhints

#### [<a name="compositionlight"></a>compositionlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)

compositionlight.exclusions

#### [<a name="compositor"></a>compositor](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositor)

compositor.createvisualislandsite <br> compositor.createvisualtreeisland

#### [<a name="distantlight"></a>distantlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.distantlight)

distantlight.intensity

#### [<a name="dropshadow"></a>dropshadow](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)

dropshadow.sourcepolicy

#### [<a name="expressionproperties"></a>expressionproperties](https://docs.microsoft.com/uwp/api/windows.ui.composition.expressionproperties)

expressionproperties <br> expressionproperties.clear <br> expressionproperties.first <br> expressionproperties.getview <br> expressionproperties.haskey <br> expressionproperties.insert <br> expressionproperties.lookup <br> expressionproperties.remove <br> expressionproperties.size

#### [<a name="framedislandsite"></a>framedislandsite](https://docs.microsoft.com/uwp/api/windows.ui.composition.framedislandsite)

framedislandsite <br> framedislandsite.connectisland

#### [<a name="hwndislandsite"></a>hwndislandsite](https://docs.microsoft.com/uwp/api/windows.ui.composition.hwndislandsite)

hwndislandsite <br> hwndislandsite.connectisland <br> hwndislandsite.placementanchor <br> hwndislandsite.placementanchorpoint

#### [<a name="icompositionislandsite"></a>icompositionislandsite](https://docs.microsoft.com/uwp/api/windows.ui.composition.icompositionislandsite)

icompositionislandsite <br> icompositionislandsite.connectisland

#### [<a name="ivisual3"></a>ivisual3](https://docs.microsoft.com/uwp/api/windows.ui.composition.ivisual3)

ivisual3 <br> ivisual3.createanchor

#### [<a name="pointlight"></a>pointlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.pointlight)

pointlight.intensity

#### [<a name="popupislandsite"></a>popupislandsite](https://docs.microsoft.com/uwp/api/windows.ui.composition.popupislandsite)

popupislandsite <br> popupislandsite.connectisland <br> popupislandsite.placementanchor <br> popupislandsite.placementanchorpoint

#### [<a name="spotlight"></a>spotlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.spotlight)

spotlight.innerconeintensity <br> spotlight.outerconeintensity

#### [<a name="visual"></a>visual](https://docs.microsoft.com/uwp/api/windows.ui.composition.visual)

visual.createanchor

#### [<a name="visualislandsite"></a>visualislandsite](https://docs.microsoft.com/uwp/api/windows.ui.composition.visualislandsite)

visualislandsite <br> visualislandsite.actualsize <br> visualislandsite.connectisland <br> visualislandsite.requestedsize <br> visualislandsite.requestedsizechanged <br> visualislandsite.sitevisual

#### [<a name="visualislandsiteeventargs"></a>visualislandsiteeventargs](https://docs.microsoft.com/uwp/api/windows.ui.composition.visualislandsiteeventargs)

visualislandsiteeventargs

#### [<a name="visualtreeisland"></a>visualtreeisland](https://docs.microsoft.com/uwp/api/windows.ui.composition.visualtreeisland)

visualtreeisland <br> visualtreeisland.children

### [<a name="windowsuicore"></a>windows.ui.core](https://docs.microsoft.com/uwp/api/windows.ui.core)

#### [<a name="corewindow"></a>corewindow](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow)

corewindow.dispatcherqueue

### [<a name="windowsuiviewmanagement"></a>windows.ui.viewmanagement](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement)

#### [<a name="coreinputview"></a>coreinputview](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreinputview)

coreinputview <br> coreinputview.frameworkoccludinginputviewschanged <br> coreinputview.getforcurrentview <br> coreinputview.occludinginputviews <br> coreinputview.occludinginputviewschanged <br> coreinputview.tryhideprimaryview <br> coreinputview.tryshowprimaryview

#### [<a name="coreinputviewframeworkoccludinginputviewschangedeventargs"></a>coreinputviewframeworkoccludinginputviewschangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreinputviewframeworkoccludinginputviewschangedeventargs)

coreinputviewframeworkoccludinginputviewschangedeventargs <br> coreinputviewframeworkoccludinginputviewschangedeventargs.handled <br> coreinputviewframeworkoccludinginputviewschangedeventargs.occludinginputviews

#### [<a name="coreinputviewoccludinginputviewschangedeventargs"></a>coreinputviewoccludinginputviewschangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreinputviewoccludinginputviewschangedeventargs)

coreinputviewoccludinginputviewschangedeventargs <br> coreinputviewoccludinginputviewschangedeventargs.handled <br> coreinputviewoccludinginputviewschangedeventargs.occludinginputviews

#### [<a name="coreoccludinginputview"></a>coreoccludinginputview](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreoccludinginputview)

coreoccludinginputview

#### [<a name="coreoccludinginputviews"></a>coreoccludinginputviews](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreoccludinginputviews)

coreoccludinginputviews <br> coreoccludinginputviews.first

#### [<a name="coreoccludinginputviewtype"></a>coreoccludinginputviewtype](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.coreoccludinginputviewtype)

coreoccludinginputviewtype

#### [<a name="viewmodepreferences"></a>viewmodepreferences](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.viewmodepreferences)

viewmodepreferences.custommaxsize <br> viewmodepreferences.customminsize

### [<a name="windowsuiwebui"></a>windows.ui.webui](https://docs.microsoft.com/uwp/api/windows.ui.webui)

#### [<a name="webuiconsoleactivatedeventargs"></a>webuiconsoleactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiconsoleactivatedeventargs)

webuiconsoleactivatedeventargs <br> webuiconsoleactivatedeventargs.activatedoperation <br> webuiconsoleactivatedeventargs.arguments <br> webuiconsoleactivatedeventargs.kind <br> webuiconsoleactivatedeventargs.previousexecutionstate <br> webuiconsoleactivatedeventargs.splashscreen

### [<a name="windowsuixamlcontrols"></a>windows.ui.xaml.controls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls)

#### [<a name="colorchangedeventargs"></a>colorchangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorchangedeventargs)

colorchangedeventargs <br> colorchangedeventargs.newcolor <br> colorchangedeventargs.oldcolor

#### [<a name="colorchannel"></a>colorchannel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorchannel)

colorchannel

#### [<a name="colorpicker"></a>colorpicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker)

colorpicker <br> colorpicker.color <br> colorpicker.colorchanged <br> colorpicker.colorpicker <br> colorpicker.colorproperty <br> colorpicker.colorspectrumcomponents <br> colorpicker.colorspectrumcomponentsproperty <br> colorpicker.colorspectrumshape <br> colorpicker.colorspectrumshapeproperty <br> colorpicker.isalphaenabled <br> colorpicker.isalphaenabledproperty <br> colorpicker.isalphaslidervisible <br> colorpicker.isalphaslidervisibleproperty <br> colorpicker.isalphatextinputvisible <br> colorpicker.isalphatextinputvisibleproperty <br> colorpicker.iscolorchanneltextinputvisible <br> colorpicker.iscolorchanneltextinputvisibleproperty <br> colorpicker.iscolorpreviewvisible <br> colorpicker.iscolorpreviewvisibleproperty <br> colorpicker.iscolorslidervisible <br> colorpicker.iscolorslidervisibleproperty <br> colorpicker.iscolorspectrumvisible <br> colorpicker.iscolorspectrumvisibleproperty <br> colorpicker.ishexinputvisible <br> colorpicker.ishexinputvisibleproperty <br> colorpicker.ismorebuttonvisible <br> colorpicker.ismorebuttonvisibleproperty <br> colorpicker.maxhue <br> colorpicker.maxhueproperty <br> colorpicker.maxsaturation <br> colorpicker.maxsaturationproperty <br> colorpicker.maxvalue <br> colorpicker.maxvalueproperty <br> colorpicker.minhue <br> colorpicker.minhueproperty <br> colorpicker.minsaturation <br> colorpicker.minsaturationproperty <br> colorpicker.minvalue <br> colorpicker.minvalueproperty <br> colorpicker.previouscolor <br> colorpicker.previouscolorproperty

#### [<a name="colorpickerslider"></a>colorpickerslider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpickerslider)

colorpickerslider <br> colorpickerslider.colorchannel <br> colorpickerslider.colorchannelproperty <br> colorpickerslider.colorpickerslider

#### [<a name="colorpickersliderautomationpeer"></a>colorpickersliderautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpickersliderautomationpeer)

colorpickersliderautomationpeer <br> colorpickersliderautomationpeer.colorpickersliderautomationpeer

#### [<a name="colorspectrum"></a>colorspectrum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrum)

colorspectrum <br> colorspectrum.alpha <br> colorspectrum.alphaproperty <br> colorspectrum.color <br> colorspectrum.colorchanged <br> colorspectrum.colorproperty <br> colorspectrum.colorspectrum <br> colorspectrum.components <br> colorspectrum.componentsproperty <br> colorspectrum.hsvcolor <br> colorspectrum.hsvcolorproperty <br> colorspectrum.maxhue <br> colorspectrum.maxhueproperty <br> colorspectrum.maxsaturation <br> colorspectrum.maxsaturationproperty <br> colorspectrum.maxvalue <br> colorspectrum.maxvalueproperty <br> colorspectrum.minhue <br> colorspectrum.minhueproperty <br> colorspectrum.minsaturation <br> colorspectrum.minsaturationproperty <br> colorspectrum.minvalue <br> colorspectrum.minvalueproperty <br> colorspectrum.shape <br> colorspectrum.shapeproperty

#### [<a name="colorspectrumautomationpeer"></a>colorspectrumautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrumautomationpeer)

colorspectrumautomationpeer <br> colorspectrumautomationpeer.colorspectrumautomationpeer

#### [<a name="colorspectrumcomponents"></a>colorspectrumcomponents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrumcomponents)

colorspectrumcomponents

#### [<a name="colorspectrumshape"></a>colorspectrumshape](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrumshape)

colorspectrumshape

#### [<a name="control"></a>control](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control)

control.onpreviewkeydown <br> control.onpreviewkeyup

#### [<a name="displaymodechangedeventargs"></a>displaymodechangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.displaymodechangedeventargs)

displaymodechangedeventargs <br> displaymodechangedeventargs.displaymode <br> displaymodechangedeventargs.displaymodechangedeventargs

#### [<a name="hsvcolor"></a>hsvcolor](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.hsvcolor)

hsvcolor

#### [<a name="navigationmenuitem"></a>navigationmenuitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationmenuitem)

navigationmenuitem <br> navigationmenuitem.compactpanelength <br> navigationmenuitem.icon <br> navigationmenuitem.iconproperty <br> navigationmenuitem.invoked <br> navigationmenuitem.isselected <br> navigationmenuitem.isselectedproperty <br> navigationmenuitem.navigationmenuitem <br> navigationmenuitem.text <br> navigationmenuitem.textproperty

#### [<a name="navigationmenuitemautomationpeer"></a>navigationmenuitemautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationmenuitemautomationpeer)

navigationmenuitemautomationpeer <br> navigationmenuitemautomationpeer.navigationmenuitemautomationpeer

#### [<a name="navigationmenuitembase"></a>navigationmenuitembase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationmenuitembase)

navigationmenuitembase <br> navigationmenuitembase.navigationmenuitembase

#### [<a name="navigationmenuitembaseobservablecollection"></a>navigationmenuitembaseobservablecollection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationmenuitembaseobservablecollection)

navigationmenuitembaseobservablecollection <br> navigationmenuitembaseobservablecollection.append <br> navigationmenuitembaseobservablecollection.clear <br> navigationmenuitembaseobservablecollection.first <br> navigationmenuitembaseobservablecollection.getat <br> navigationmenuitembaseobservablecollection.getmany <br> navigationmenuitembaseobservablecollection.getview <br> navigationmenuitembaseobservablecollection.indexof <br> navigationmenuitembaseobservablecollection.insertat <br> navigationmenuitembaseobservablecollection.removeat <br> navigationmenuitembaseobservablecollection.removeatend <br> navigationmenuitembaseobservablecollection.replaceall <br> navigationmenuitembaseobservablecollection.setat <br> navigationmenuitembaseobservablecollection.size <br> navigationmenuitembaseobservablecollection.vectorchanged

#### [<a name="navigationmenuitemseparator"></a>navigationmenuitemseparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationmenuitemseparator)

navigationmenuitemseparator <br> navigationmenuitemseparator.navigationmenuitemseparator

#### [<a name="navigationview"></a>navigationview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

navigationview <br> navigationview.alwaysshowheader <br> navigationview.alwaysshowheaderproperty <br> navigationview.compactmodethresholdwidth <br> navigationview.compactmodethresholdwidthproperty <br> navigationview.compactpanelength <br> navigationview.compactpanelengthproperty <br> navigationview.displaymode <br> navigationview.displaymodechanged <br> navigationview.displaymodeproperty <br> navigationview.expandedmodethresholdwidth <br> navigationview.expandedmodethresholdwidthproperty <br> navigationview.header <br> navigationview.headerproperty <br> navigationview.headertemplate <br> navigationview.headertemplateproperty <br> navigationview.ispaneopen <br> navigationview.ispaneopenproperty <br> navigationview.ispanetogglebuttonvisible <br> navigationview.ispanetogglebuttonvisibleproperty <br> navigationview.issettingsvisible <br> navigationview.issettingsvisibleproperty <br> navigationview.menuitems <br> navigationview.menuitemsproperty <br> navigationview.navigationview <br> navigationview.openpanelength <br> navigationview.openpanelengthproperty <br> navigationview.panefooter <br> navigationview.panefooterproperty <br> navigationview.panetogglebuttonstyle <br> navigationview.panetogglebuttonstyleproperty <br> navigationview.settingsinvoked

#### [<a name="navigationviewdisplaymode"></a>navigationviewdisplaymode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)

navigationviewdisplaymode

#### [<a name="parallaxsourceoffsetkind"></a>parallaxsourceoffsetkind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.parallaxsourceoffsetkind)

parallaxsourceoffsetkind

#### [<a name="parallaxview"></a>parallaxview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.parallaxview)

parallaxview <br> parallaxview.child <br> parallaxview.childproperty <br> parallaxview.horizontalshift <br> parallaxview.horizontalshiftproperty <br> parallaxview.horizontalsourceendoffset <br> parallaxview.horizontalsourceendoffsetproperty <br> parallaxview.horizontalsourceoffsetkind <br> parallaxview.horizontalsourceoffsetkindproperty <br> parallaxview.horizontalsourcestartoffset <br> parallaxview.horizontalsourcestartoffsetproperty <br> parallaxview.ishorizontalshiftclamped <br> parallaxview.ishorizontalshiftclampedproperty <br> parallaxview.isverticalshiftclamped <br> parallaxview.isverticalshiftclampedproperty <br> parallaxview.maxhorizontalshiftratio <br> parallaxview.maxhorizontalshiftratioproperty <br> parallaxview.maxverticalshiftratio <br> parallaxview.maxverticalshiftratioproperty <br> parallaxview.parallaxview <br> parallaxview.refreshautomatichorizontaloffsets <br> parallaxview.refreshautomaticverticaloffsets <br> parallaxview.source <br> parallaxview.sourceproperty <br> parallaxview.verticalshift <br> parallaxview.verticalshiftproperty <br> parallaxview.verticalsourceendoffset <br> parallaxview.verticalsourceendoffsetproperty <br> parallaxview.verticalsourceoffsetkind <br> parallaxview.verticalsourceoffsetkindproperty <br> parallaxview.verticalsourcestartoffset <br> parallaxview.verticalsourcestartoffsetproperty

#### [<a name="personpicture"></a>personpicture](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture)

personpicture <br> personpicture.badgeglyph <br> personpicture.badgeglyphproperty <br> personpicture.badgeimagesource <br> personpicture.badgeimagesourceproperty <br> personpicture.badgenumber <br> personpicture.badgenumberproperty <br> personpicture.badgetext <br> personpicture.badgetextproperty <br> personpicture.contact <br> personpicture.contactproperty <br> personpicture.displayname <br> personpicture.displaynameproperty <br> personpicture.initials <br> personpicture.initialsproperty <br> personpicture.isgroup <br> personpicture.isgroupproperty <br> personpicture.personpicture <br> personpicture.prefersmallimage <br> personpicture.prefersmallimageproperty <br> personpicture.profilepicture <br> personpicture.profilepictureproperty

#### [<a name="personpictureautomationpeer"></a>personpictureautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpictureautomationpeer)

personpictureautomationpeer <br> personpictureautomationpeer.personpictureautomationpeer

#### [<a name="ratingscontrol"></a>ratingscontrol](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingscontrol)

ratingscontrol <br> ratingscontrol.caption <br> ratingscontrol.captionproperty <br> ratingscontrol.initialsetvalue <br> ratingscontrol.initialsetvalueproperty <br> ratingscontrol.isclearenabled <br> ratingscontrol.isclearenabledproperty <br> ratingscontrol.isreadonly <br> ratingscontrol.isreadonlyproperty <br> ratingscontrol.maxrating <br> ratingscontrol.maxratingproperty <br> ratingscontrol.placeholdervalue <br> ratingscontrol.placeholdervalueproperty <br> ratingscontrol.ratingscontrol <br> ratingscontrol.value <br> ratingscontrol.valuechanged <br> ratingscontrol.valueproperty

#### [<a name="ratingscontrolautomationpeer"></a>ratingscontrolautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingscontrolautomationpeer)

ratingscontrolautomationpeer <br> ratingscontrolautomationpeer.ratingscontrolautomationpeer


#### [<a name="reveallistviewitempresenter"></a>reveallistviewitempresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.reveallistviewitempresenter)

reveallistviewitempresenter <br> reveallistviewitempresenter.reveallistviewitempresenter

#### [<a name="treeview"></a>treeview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)

treeview <br> treeview.collapsenode <br> treeview.expanding <br> treeview.expandnode <br> treeview.itemclicked <br> treeview.listcontrol <br> treeview.rootnode <br> treeview.rootnodeproperty <br> treeview.treeview

#### [<a name="treeviewexpandingeventargs"></a>treeviewexpandingeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewexpandingeventargs)

treeviewexpandingeventargs <br> treeviewexpandingeventargs.node

#### [<a name="treeviewitem"></a>treeviewitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitem)

treeviewitem <br> treeviewitem.treeviewitem

#### [<a name="treeviewitemautomationpeer"></a>treeviewitemautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitemautomationpeer)

treeviewitemautomationpeer <br> treeviewitemautomationpeer.treeviewitemautomationpeer

#### [<a name="treeviewitemclickeventargs"></a>treeviewitemclickeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitemclickeventargs)

treeviewitemclickeventargs <br> treeviewitemclickeventargs.clickeditem <br> treeviewitemclickeventargs.ishandled

#### [<a name="treeviewlist"></a>treeviewlist](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewlist)

treeviewlist <br> treeviewlist.treeviewlist

#### [<a name="treeviewlistautomationpeer"></a>treeviewlistautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewlistautomationpeer)

treeviewlistautomationpeer <br> treeviewlistautomationpeer.treeviewlistautomationpeer

#### [<a name="treeviewnode"></a>treeviewnode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewnode)

treeviewnode <br> treeviewnode.append <br> treeviewnode.clear <br> treeviewnode.data <br> treeviewnode.depth <br> treeviewnode.depthproperty <br> treeviewnode.first <br> treeviewnode.getat <br> treeviewnode.getview <br> treeviewnode.hasitems <br> treeviewnode.hasitemsproperty <br> treeviewnode.hasunrealizeditems <br> treeviewnode.indexof <br> treeviewnode.insertat <br> treeviewnode.isexpanded <br> treeviewnode.isexpandedchanged <br> treeviewnode.isexpandedproperty <br> treeviewnode.parentnode <br> treeviewnode.removeat <br> treeviewnode.removeatend <br> treeviewnode.setat <br> treeviewnode.size <br> treeviewnode.treeviewnode <br> treeviewnode.vectorchanged

#### [<a name="xamlbooleantovisibilityconverter"></a>xamlbooleantovisibilityconverter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.xamlbooleantovisibilityconverter)

xamlbooleantovisibilityconverter <br> xamlbooleantovisibilityconverter.convert <br> xamlbooleantovisibilityconverter.convertback <br> xamlbooleantovisibilityconverter.xamlbooleantovisibilityconverter

#### [<a name="xamlintegertoindentationconverter"></a>xamlintegertoindentationconverter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.xamlintegertoindentationconverter)

xamlintegertoindentationconverter <br> xamlintegertoindentationconverter.convert <br> xamlintegertoindentationconverter.convertback <br> xamlintegertoindentationconverter.xamlintegertoindentationconverter

### [<a name="windowsuixamldocuments"></a>windows.ui.xaml.documents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents)

#### [<a name="hyperlink"></a>hyperlink](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.hyperlink)

hyperlink.istabstop <br> hyperlink.istabstopproperty <br> hyperlink.tabindex <br> hyperlink.tabindexproperty

### [<a name="windowsuixamlmedia"></a>windows.ui.xaml.media](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media)

#### [<a name="acrylicbackgroundsource"></a>acrylicbackgroundsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.acrylicbackgroundsource)

acrylicbackgroundsource

#### [<a name="acrylicbrush"></a>acrylicbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.acrylicbrush)

acrylicbrush <br> acrylicbrush.acrylicbrush <br> acrylicbrush.backgroundsource <br> acrylicbrush.backgroundsourceproperty <br> acrylicbrush.fallbackforced <br> acrylicbrush.fallbackforcedproperty <br> acrylicbrush.tintcolor <br> acrylicbrush.tintcolorproperty <br> acrylicbrush.tintopacity <br> acrylicbrush.tintopacityproperty

#### [<a name="revealbackgroundbrush"></a>revealbackgroundbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)

revealbackgroundbrush <br> revealbackgroundbrush.revealbackgroundbrush

#### [<a name="revealborderbrush"></a>revealborderbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)

revealborderbrush <br> revealborderbrush.revealborderbrush

#### [<a name="revealbrush"></a>revealbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)

revealbrush <br> revealbrush.color <br> revealbrush.colorproperty <br> revealbrush.fallbackforced <br> revealbrush.fallbackforcedproperty <br> revealbrush.revealbrush <br> revealbrush.targettheme <br> revealbrush.targetthemeproperty

#### [<a name="revealbrushhelper"></a>revealbrushhelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelper)

revealbrushhelper <br> revealbrushhelper.getstate <br> revealbrushhelper.setstate <br> revealbrushhelper.stateproperty

#### [<a name="revealbrushhelperstate"></a>revealbrushhelperstate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushhelperstate)

revealbrushhelperstate

#### [<a name="xamlambientlight"></a>xamlambientlight](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlambientlight)

xamlambientlight <br> xamlambientlight.color <br> xamlambientlight.colorproperty <br> xamlambientlight.getistarget <br> xamlambientlight.istargetproperty <br> xamlambientlight.setistarget <br> xamlambientlight.xamlambientlight

### [<a name="windowsuixaml"></a>windows.ui.xaml](https://docs.microsoft.com/uwp/api/windows.ui.xaml)

#### [<a name="uielement"></a>uielement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)

uielement.previewkeydown <br> uielement.previewkeydownevent <br> uielement.previewkeyup <br> uielement.previewkeyupevent

