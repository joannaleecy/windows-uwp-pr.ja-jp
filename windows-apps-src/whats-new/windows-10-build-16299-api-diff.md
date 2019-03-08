---
title: Windows 10 Fall Creators Update API の変更点
description: 開発者は、次の一覧を使用して、Windows 10 ビルド 16299 での新しい名前空間や変更された名前空間を確認できます。
keywords: 新着情報, 新機能, 更新プログラム, Windows 10, 1709, fall, creators, api, 16299
ms.date: 11/02/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 25707dfbf6753c51b4cf47bcbe95dc66802ee781
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57647957"
---
# <a name="new-apis-in-windows-10-build-16299"></a>Windows 10 ビルド 16299 の新しい API

Windows 10 ビルド 16299 (Fall Creators Update またはバージョン 1709 とも呼ばれます) には、新規および更新された API 名前空間が開発者用に用意されています。 このリリースで追加または変更された名前空間について公開されているドキュメントの完全な一覧を以下に示します。

1 つ前の一般リリースで追加された API については、[Windows 10 Creators Update の新しい API ](windows-10-build-15063-api-diff.md)のページをご覧ください。

## <a name="windowsapplicationmodel"></a>windows.applicationmodel

### <a name="windowsapplicationmodelactivationhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivation"></a>[windows.applicationmodel.activation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation)

#### <a name="commandlineactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivationcommandlineactivatedeventargs"></a>[commandlineactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.commandlineactivatedeventargs)

commandlineactivatedeventargs <br> commandlineactivatedeventargs.kind <br> commandlineactivatedeventargs.operation <br> commandlineactivatedeventargs.previousexecutionstate <br> commandlineactivatedeventargs.splashscreen <br> commandlineactivatedeventargs.user

#### <a name="commandlineactivationoperationhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivationcommandlineactivationoperation"></a>[commandlineactivationoperation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.commandlineactivationoperation)

commandlineactivationoperation <br> commandlineactivationoperation.arguments <br> commandlineactivationoperation.currentdirectorypath <br> commandlineactivationoperation.exitcode <br> commandlineactivationoperation.getdeferral

#### <a name="icommandlineactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivationicommandlineactivatedeventargs"></a>[icommandlineactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.icommandlineactivatedeventargs)

icommandlineactivatedeventargs <br> icommandlineactivatedeventargs.operation

#### <a name="istartuptaskactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivationistartuptaskactivatedeventargs"></a>[istartuptaskactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.istartuptaskactivatedeventargs)

istartuptaskactivatedeventargs <br> istartuptaskactivatedeventargs.taskid

#### <a name="startuptaskactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelactivationstartuptaskactivatedeventargs"></a>[startuptaskactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.startuptaskactivatedeventargs)

startuptaskactivatedeventargs <br> startuptaskactivatedeventargs.kind <br> startuptaskactivatedeventargs.previousexecutionstate <br> startuptaskactivatedeventargs.splashscreen <br> startuptaskactivatedeventargs.taskid <br> startuptaskactivatedeventargs.user

### <a name="windowsapplicationmodelappointmentshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappointments"></a>[windows.applicationmodel.appointments](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appointments)

#### <a name="appointmentstorehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappointmentsappointmentstore"></a>[appointmentstore](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appointments.appointmentstore)

appointmentstore.getchangetracker

#### <a name="appointmentstorechangetrackerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappointmentsappointmentstorechangetracker"></a>[appointmentstorechangetracker](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appointments.appointmentstorechangetracker)

appointmentstorechangetracker.istracking

### <a name="windowsapplicationmodelappservicehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappservice"></a>[windows.applicationmodel.appservice](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice)

#### <a name="appservicetriggerdetailshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelappserviceappservicetriggerdetails"></a>[appservicetriggerdetails](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appservice.appservicetriggerdetails)

appservicetriggerdetails.checkcallerforcapabilityasync

### <a name="windowsapplicationmodelbackgroundhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelbackground"></a>[windows.applicationmodel.background](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background)

#### <a name="geovisittriggerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelbackgroundgeovisittrigger"></a>[geovisittrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.geovisittrigger)

geovisittrigger <br> geovisittrigger.geovisittrigger <br> geovisittrigger.monitoringscope

#### <a name="paymentappcanmakepaymenttriggerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelbackgroundpaymentappcanmakepaymenttrigger"></a>[paymentappcanmakepaymenttrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.paymentappcanmakepaymenttrigger)

paymentappcanmakepaymenttrigger <br> paymentappcanmakepaymenttrigger.paymentappcanmakepaymenttrigger

### <a name="windowsapplicationmodelcallshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcalls"></a>[windows.applicationmodel.calls](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls)

#### <a name="voipcallcoordinatorhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcallsvoipcallcoordinator"></a>[voipcallcoordinator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipcallcoordinator)

voipcallcoordinator.setupnewacceptedcall

#### <a name="voipphonecallhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcallsvoipphonecall"></a>[voipphonecall](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipphonecall)

voipphonecall.tryshowappui

### <a name="windowsapplicationmodelcontactsdataproviderhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovider"></a>[windows.applicationmodel.contacts.dataprovider](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider)

#### <a name="contactdataproviderconnectionhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovidercontactdataproviderconnection"></a>[contactdataproviderconnection](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider.contactdataproviderconnection)

contactdataproviderconnection.createorupdatecontactrequested <br> contactdataproviderconnection.deletecontactrequested

#### <a name="contactlistcreateorupdatecontactrequesthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovidercontactlistcreateorupdatecontactrequest"></a>[contactlistcreateorupdatecontactrequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider.contactlistcreateorupdatecontactrequest)

contactlistcreateorupdatecontactrequest <br> contactlistcreateorupdatecontactrequest.contact <br> contactlistcreateorupdatecontactrequest.contactlistid <br> contactlistcreateorupdatecontactrequest.reportcompletedasync <br> contactlistcreateorupdatecontactrequest.reportfailedasync

#### <a name="contactlistcreateorupdatecontactrequesteventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovidercontactlistcreateorupdatecontactrequesteventargs"></a>[contactlistcreateorupdatecontactrequesteventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider.contactlistcreateorupdatecontactrequesteventargs)

contactlistcreateorupdatecontactrequesteventargs <br> contactlistcreateorupdatecontactrequesteventargs.getdeferral <br> contactlistcreateorupdatecontactrequesteventargs.request

#### <a name="contactlistdeletecontactrequesthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovidercontactlistdeletecontactrequest"></a>[contactlistdeletecontactrequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider.contactlistdeletecontactrequest)

contactlistdeletecontactrequest <br> contactlistdeletecontactrequest.contactid <br> contactlistdeletecontactrequest.contactlistid <br> contactlistdeletecontactrequest.reportcompletedasync <br> contactlistdeletecontactrequest.reportfailedasync

#### <a name="contactlistdeletecontactrequesteventargshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactsdataprovidercontactlistdeletecontactrequesteventargs"></a>[contactlistdeletecontactrequesteventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.dataprovider.contactlistdeletecontactrequesteventargs)

contactlistdeletecontactrequesteventargs <br> contactlistdeletecontactrequesteventargs.getdeferral <br> contactlistdeletecontactrequesteventargs.request

### <a name="windowsapplicationmodelcontactshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontacts"></a>[windows.applicationmodel.contacts](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts)

#### <a name="contactchangetrackerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactscontactchangetracker"></a>[contactchangetracker](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.contactchangetracker)

contactchangetracker.istracking

#### <a name="contactlisthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactscontactlist"></a>[contactlist](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.contactlist)

contactlist.getchangetracker <br> contactlist.limitedwriteoperations

#### <a name="contactlistlimitedwriteoperationshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactscontactlistlimitedwriteoperations"></a>[contactlistlimitedwriteoperations](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.contactlistlimitedwriteoperations)

contactlistlimitedwriteoperations <br> contactlistlimitedwriteoperations.trycreateorupdatecontactasync <br> contactlistlimitedwriteoperations.trydeletecontactasync

#### <a name="contactstorehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcontactscontactstore"></a>[contactstore](https://docs.microsoft.com/uwp/api/windows.applicationmodel.contacts.contactstore)

contactstore.getchangetracker

### <a name="windowsapplicationmodelcorehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcore"></a>[windows.applicationmodel.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core)

#### <a name="applistentryhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcoreapplistentry"></a>[applistentry](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.applistentry)

applistentry.appusermodelid

#### <a name="apprestartfailurereasonhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcoreapprestartfailurereason"></a>[apprestartfailurereason](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.apprestartfailurereason)

apprestartfailurereason

#### <a name="coreapplicationhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcorecoreapplication"></a>[coreapplication](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplication)

coreapplication.requestrestartasync <br> coreapplication.requestrestartforuserasync

#### <a name="coreapplicationviewhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelcorecoreapplicationview"></a>[coreapplicationview](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.coreapplicationview)

coreapplicationview.dispatcherqueue

### <a name="windowsapplicationmodeldatatransfersharetargethttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfersharetarget"></a>[windows.applicationmodel.datatransfer.sharetarget](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharetarget)

#### <a name="shareoperationhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfersharetargetshareoperation"></a>[shareoperation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.sharetarget.shareoperation)

shareoperation.contacts

### <a name="windowsapplicationmodeldatatransferhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfer"></a>[windows.applicationmodel.datatransfer](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer)

#### <a name="datatransfermanagerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransferdatatransfermanager"></a>[datatransfermanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.datatransfermanager)

datatransfermanager.showshareui

#### <a name="shareuioptionshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfershareuioptions"></a>[shareuioptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.shareuioptions)

shareuioptions <br> shareuioptions.selectionrect <br> shareuioptions.shareuioptions <br> shareuioptions.theme

#### <a name="shareuithemehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldatatransfershareuitheme"></a>[shareuitheme](https://docs.microsoft.com/uwp/api/windows.applicationmodel.datatransfer.shareuitheme)

shareuitheme

### <a name="windowsapplicationmodelemailhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelemail"></a>[windows.applicationmodel.email](https://docs.microsoft.com/uwp/api/windows.applicationmodel.email)

#### <a name="emailmailboxhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelemailemailmailbox"></a>[emailmailbox](https://docs.microsoft.com/uwp/api/windows.applicationmodel.email.emailmailbox)

emailmailbox.getchangetracker

### <a name="windowsapplicationmodelpaymentsproviderhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentsprovider"></a>[windows.applicationmodel.payments.provider](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.provider)

#### <a name="paymentappcanmakepaymenttriggerdetailshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentsproviderpaymentappcanmakepaymenttriggerdetails"></a>[paymentappcanmakepaymenttriggerdetails](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.provider.paymentappcanmakepaymenttriggerdetails)

paymentappcanmakepaymenttriggerdetails <br> paymentappcanmakepaymenttriggerdetails.reportcanmakepaymentresult <br> paymentappcanmakepaymenttriggerdetails.request

### <a name="windowsapplicationmodelpaymentshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpayments"></a>[windows.applicationmodel.payments](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments)

#### <a name="paymentcanmakepaymentresulthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentspaymentcanmakepaymentresult"></a>[paymentcanmakepaymentresult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.paymentcanmakepaymentresult)

paymentcanmakepaymentresult <br> paymentcanmakepaymentresult.paymentcanmakepaymentresult <br> paymentcanmakepaymentresult.status

#### <a name="paymentcanmakepaymentresultstatushttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentspaymentcanmakepaymentresultstatus"></a>[paymentcanmakepaymentresultstatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.paymentcanmakepaymentresultstatus)

paymentcanmakepaymentresultstatus

#### <a name="paymentmediatorhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentspaymentmediator"></a>[paymentmediator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.paymentmediator)

paymentmediator.canmakepaymentasync

#### <a name="paymentrequesthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpaymentspaymentrequest"></a>[paymentrequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.payments.paymentrequest)

paymentrequest.id <br> paymentrequest.paymentrequest

### <a name="windowsapplicationmodeluseractivitiescorehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiescore"></a>[windows.applicationmodel.useractivities.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.core)

#### <a name="coreuseractivitymanagerhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiescorecoreuseractivitymanager"></a>[coreuseractivitymanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.core.coreuseractivitymanager)

coreuseractivitymanager <br> coreuseractivitymanager.createuseractivitysessioninbackground <br> coreuseractivitymanager.deleteuseractivitysessionsintimerangeasync

### <a name="windowsapplicationmodeluseractivitieshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivities"></a>[windows.applicationmodel.useractivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

#### <a name="iuseractivitycontentinfohttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesiuseractivitycontentinfo"></a>[iuseractivitycontentinfo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.iuseractivitycontentinfo)

iuseractivitycontentinfo <br> iuseractivitycontentinfo.tojson

#### <a name="useractivityhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivity"></a>[useractivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)

useractivity <br> useractivity.activationuri <br> useractivity.activityid <br> useractivity.contentinfo <br> useractivity.contenttype <br> useractivity.contenturi <br> useractivity.createsession <br> useractivity.fallbackuri <br> useractivity.saveasync <br> useractivity.state <br> useractivity.visualelements

#### <a name="useractivityattributionhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivityattribution"></a>[useractivityattribution](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityattribution)

useractivityattribution <br> useractivityattribution.addimagequery <br> useractivityattribution.alternatetext <br> useractivityattribution.iconuri <br> useractivityattribution.useractivityattribution <br> useractivityattribution.useractivityattribution

#### <a name="useractivitychannelhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivitychannel"></a>[useractivitychannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel)

useractivitychannel <br> useractivitychannel.deleteactivityasync <br> useractivitychannel.deleteallactivitiesasync <br> useractivitychannel.getdefault <br> useractivitychannel.getorcreateuseractivityasync

#### <a name="useractivitycontentinfohttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivitycontentinfo"></a>[useractivitycontentinfo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitycontentinfo)

useractivitycontentinfo <br> useractivitycontentinfo.fromjson <br> useractivitycontentinfo.tojson

#### <a name="useractivitysessionhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivitysession"></a>[useractivitysession](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysession)

useractivitysession <br> useractivitysession.activityid <br> useractivitysession.close

#### <a name="useractivitystatehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivitystate"></a>[useractivitystate](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitystate)

useractivitystate

#### <a name="useractivityvisualelementshttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeluseractivitiesuseractivityvisualelements"></a>[useractivityvisualelements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements)

useractivityvisualelements <br> useractivityvisualelements.attribution <br> useractivityvisualelements.backgroundcolor <br> useractivityvisualelements.content <br> useractivityvisualelements.description <br> useractivityvisualelements.displaytext

### <a name="windowsapplicationmodelhttpsdocsmicrosoftcomuwpapiwindowsapplicationmodel"></a>[windows.applicationmodel](https://docs.microsoft.com/uwp/api/windows.applicationmodel)

#### <a name="designmodehttpsdocsmicrosoftcomuwpapiwindowsapplicationmodeldesignmode"></a>[designmode](https://docs.microsoft.com/uwp/api/windows.applicationmodel.designmode)

designmode.designmode2enabled

#### <a name="packagecataloghttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpackagecatalog"></a>[packagecatalog](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packagecatalog)

packagecatalog.removeoptionalpackagesasync

#### <a name="packagecatalogremoveoptionalpackagesresulthttpsdocsmicrosoftcomuwpapiwindowsapplicationmodelpackagecatalogremoveoptionalpackagesresult"></a>[packagecatalogremoveoptionalpackagesresult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packagecatalogremoveoptionalpackagesresult)

packagecatalogremoveoptionalpackagesresult <br> packagecatalogremoveoptionalpackagesresult.extendederror <br> packagecatalogremoveoptionalpackagesresult.packagesremoved

## <a name="windowsdevices"></a>windows.devices

### <a name="windowsdevicesbluetoothgenericattributeprofilehttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetoothgenericattributeprofile"></a>[windows.devices.bluetooth.genericattributeprofile](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.genericattributeprofile)

#### <a name="gattclientnotificationresulthttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetoothgenericattributeprofilegattclientnotificationresult"></a>[gattclientnotificationresult](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.genericattributeprofile.gattclientnotificationresult)

gattclientnotificationresult.bytessent

### <a name="windowsdevicesbluetoothhttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetooth"></a>[windows.devices.bluetooth](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth)

#### <a name="bluetoothdevicehttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetoothbluetoothdevice"></a>[bluetoothdevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothdevice)

bluetoothdevice.bluetoothdeviceid

#### <a name="bluetoothdeviceidhttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetoothbluetoothdeviceid"></a>[bluetoothdeviceid](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothdeviceid)

bluetoothdeviceid.fromid

#### <a name="bluetoothledevicehttpsdocsmicrosoftcomuwpapiwindowsdevicesbluetoothbluetoothledevice"></a>[bluetoothledevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothledevice)

bluetoothledevice.bluetoothdeviceid

### <a name="windowsdevicesgeolocationhttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocation"></a>[windows.devices.geolocation](https://docs.microsoft.com/uwp/api/windows.devices.geolocation)

#### <a name="geovisithttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationgeovisit"></a>[geovisit](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisit)

geovisit <br> geovisit.position <br> geovisit.statechange <br> geovisit.timestamp

#### <a name="geovisitmonitorhttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationgeovisitmonitor"></a>[geovisitmonitor](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisitmonitor)

geovisitmonitor <br> geovisitmonitor.geovisitmonitor <br> geovisitmonitor.getlastreportasync <br> geovisitmonitor.monitoringscope <br> geovisitmonitor.start <br> geovisitmonitor.stop <br> geovisitmonitor.visitstatechanged

#### <a name="geovisitstatechangedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationgeovisitstatechangedeventargs"></a>[geovisitstatechangedeventargs](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisitstatechangedeventargs)

geovisitstatechangedeventargs <br> geovisitstatechangedeventargs.visit

#### <a name="geovisittriggerdetailshttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationgeovisittriggerdetails"></a>[geovisittriggerdetails](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.geovisittriggerdetails)

geovisittriggerdetails <br> geovisittriggerdetails.readreports

#### <a name="visitmonitoringscopehttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationvisitmonitoringscope"></a>[visitmonitoringscope](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.visitmonitoringscope)

visitmonitoringscope

#### <a name="visitstatechangehttpsdocsmicrosoftcomuwpapiwindowsdevicesgeolocationvisitstatechange"></a>[visitstatechange](https://docs.microsoft.com/uwp/api/windows.devices.geolocation.visitstatechange)

visitstatechange

### <a name="windowsdevicespointofservicehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservice"></a>[windows.devices.pointofservice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice)

#### <a name="claimedlinedisplayhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofserviceclaimedlinedisplay"></a>[claimedlinedisplay](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedlinedisplay)

claimedlinedisplay.checkhealthasync <br> claimedlinedisplay.checkpowerstatusasync <br> claimedlinedisplay.customglyphs <br> claimedlinedisplay.getattributes <br> claimedlinedisplay.getstatisticsasync <br> claimedlinedisplay.maxbitmapsizeinpixels <br> claimedlinedisplay.statusupdated <br> claimedlinedisplay.supportedcharactersets <br> claimedlinedisplay.supportedscreensizesincharacters <br> claimedlinedisplay.trycleardescriptorsasync <br> claimedlinedisplay.trycreatewindowasync <br> claimedlinedisplay.trysetdescriptorasync <br> claimedlinedisplay.trystorestoragefilebitmapasync <br> claimedlinedisplay.trystorestoragefilebitmapasync <br> claimedlinedisplay.trystorestoragefilebitmapasync <br> claimedlinedisplay.tryupdateattributesasync

#### <a name="linedisplayhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplay"></a>[linedisplay](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplay)

linedisplay.checkpowerstatusasync <br> linedisplay.statisticscategoryselector

#### <a name="linedisplayattributeshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplayattributes"></a>[linedisplayattributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplayattributes)

linedisplayattributes <br> linedisplayattributes.blinkrate <br> linedisplayattributes.brightness <br> linedisplayattributes.characterset <br> linedisplayattributes.currentwindow <br> linedisplayattributes.ischaractersetmappingenabled <br> linedisplayattributes.ispowernotifyenabled <br> linedisplayattributes.screensizeincharacters

#### <a name="linedisplaycursorhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaycursor"></a>[linedisplaycursor](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaycursor)

linedisplaycursor <br> linedisplaycursor.cancustomize <br> linedisplaycursor.getattributes <br> linedisplaycursor.isblinksupported <br> linedisplaycursor.isblocksupported <br> linedisplaycursor.ishalfblocksupported <br> linedisplaycursor.isothersupported <br> linedisplaycursor.isreversesupported <br> linedisplaycursor.isunderlinesupported <br> linedisplaycursor.tryupdateattributesasync

#### <a name="linedisplaycursorattributeshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaycursorattributes"></a>[linedisplaycursorattributes](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaycursorattributes)

linedisplaycursorattributes <br> linedisplaycursorattributes.cursortype <br> linedisplaycursorattributes.isautoadvanceenabled <br> linedisplaycursorattributes.isblinkenabled <br> linedisplaycursorattributes.position

#### <a name="linedisplaycursortypehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaycursortype"></a>[linedisplaycursortype](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaycursortype)

linedisplaycursortype

#### <a name="linedisplaycustomglyphshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaycustomglyphs"></a>[linedisplaycustomglyphs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaycustomglyphs)

linedisplaycustomglyphs <br> linedisplaycustomglyphs.sizeinpixels <br> linedisplaycustomglyphs.supportedglyphcodes <br> linedisplaycustomglyphs.tryredefineasync

#### <a name="linedisplaydescriptorstatehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaydescriptorstate"></a>[linedisplaydescriptorstate](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaydescriptorstate)

linedisplaydescriptorstate

#### <a name="linedisplayhorizontalalignmenthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplayhorizontalalignment"></a>[linedisplayhorizontalalignment](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplayhorizontalalignment)

linedisplayhorizontalalignment

#### <a name="linedisplaymarqueehttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaymarquee"></a>[linedisplaymarquee](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaymarquee)

linedisplaymarquee <br> linedisplaymarquee.format <br> linedisplaymarquee.repeatwaitinterval <br> linedisplaymarquee.scrollwaitinterval <br> linedisplaymarquee.trystartscrollingasync <br> linedisplaymarquee.trystopscrollingasync

#### <a name="linedisplaymarqueeformathttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaymarqueeformat"></a>[linedisplaymarqueeformat](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaymarqueeformat)

linedisplaymarqueeformat

#### <a name="linedisplaypowerstatushttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaypowerstatus"></a>[linedisplaypowerstatus](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaypowerstatus)

linedisplaypowerstatus

#### <a name="linedisplaystatisticscategoryselectorhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaystatisticscategoryselector"></a>[linedisplaystatisticscategoryselector](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaystatisticscategoryselector)

linedisplaystatisticscategoryselector <br> linedisplaystatisticscategoryselector.allstatistics <br> linedisplaystatisticscategoryselector.manufacturerstatistics <br> linedisplaystatisticscategoryselector.unifiedposstatistics

#### <a name="linedisplaystatusupdatedeventargshttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaystatusupdatedeventargs"></a>[linedisplaystatusupdatedeventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaystatusupdatedeventargs)

linedisplaystatusupdatedeventargs <br> linedisplaystatusupdatedeventargs.status

#### <a name="linedisplaystoredbitmaphttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaystoredbitmap"></a>[linedisplaystoredbitmap](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaystoredbitmap)

linedisplaystoredbitmap <br> linedisplaystoredbitmap.escapesequence <br> linedisplaystoredbitmap.trydeleteasync

#### <a name="linedisplayverticalalignmenthttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplayverticalalignment"></a>[linedisplayverticalalignment](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplayverticalalignment)

linedisplayverticalalignment

#### <a name="linedisplaywindowhttpsdocsmicrosoftcomuwpapiwindowsdevicespointofservicelinedisplaywindow"></a>[linedisplaywindow](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.linedisplaywindow)

linedisplaywindow.cursor <br> linedisplaywindow.marquee <br> linedisplaywindow.readcharacteratcursorasync <br> linedisplaywindow.trydisplaystoragefilebitmapatcursorasync <br> linedisplaywindow.trydisplaystoragefilebitmapatcursorasync <br> linedisplaywindow.trydisplaystoragefilebitmapatcursorasync <br> linedisplaywindow.trydisplaystoragefilebitmapatpointasync <br> linedisplaywindow.trydisplaystoragefilebitmapatpointasync <br> linedisplaywindow.trydisplaystoredbitmapatcursorasync

### <a name="windowsdevicessensorscustomhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorscustom"></a>[windows.devices.sensors.custom](https://docs.microsoft.com/uwp/api/windows.devices.sensors.custom)

#### <a name="customsensorhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorscustomcustomsensor"></a>[customsensor](https://docs.microsoft.com/uwp/api/windows.devices.sensors.custom.customsensor)

customsensor.maxbatchsize <br> customsensor.reportlatency

#### <a name="customsensorreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorscustomcustomsensorreading"></a>[customsensorreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.custom.customsensorreading)

customsensorreading.performancecount

### <a name="windowsdevicessensorshttpsdocsmicrosoftcomuwpapiwindowsdevicessensors"></a>[windows.devices.sensors](https://docs.microsoft.com/uwp/api/windows.devices.sensors)

#### <a name="accelerometerhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsaccelerometer"></a>[accelerometer](https://docs.microsoft.com/uwp/api/windows.devices.sensors.accelerometer)

accelerometer.fromidasync <br> accelerometer.getdeviceselector

#### <a name="accelerometerreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsaccelerometerreading"></a>[accelerometerreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.accelerometerreading)

accelerometerreading.performancecount <br> accelerometerreading.properties

#### <a name="altimeterhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsaltimeter"></a>[計](https://docs.microsoft.com/uwp/api/windows.devices.sensors.altimeter)

altimeter.maxbatchsize <br> altimeter.reportlatency

#### <a name="altimeterreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsaltimeterreading"></a>[altimeterreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.altimeterreading)

altimeterreading.performancecount <br> altimeterreading.properties

#### <a name="barometerhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsbarometer"></a>[バロメーターになります。](https://docs.microsoft.com/uwp/api/windows.devices.sensors.barometer)

barometer.fromidasync <br> barometer.getdeviceselector <br> barometer.maxbatchsize <br> barometer.reportlatency

#### <a name="barometerreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsbarometerreading"></a>[barometerreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.barometerreading)

barometerreading.performancecount <br> barometerreading.properties

#### <a name="compasshttpsdocsmicrosoftcomuwpapiwindowsdevicessensorscompass"></a>[Compass](https://docs.microsoft.com/uwp/api/windows.devices.sensors.compass)

compass.fromidasync <br> compass.getdeviceselector <br> compass.maxbatchsize <br> compass.reportlatency

#### <a name="compassreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorscompassreading"></a>[compassreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.compassreading)

compassreading.performancecount <br> compassreading.properties

#### <a name="gyrometerhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsgyrometer"></a>[gyrometer](https://docs.microsoft.com/uwp/api/windows.devices.sensors.gyrometer)

gyrometer.fromidasync <br> gyrometer.getdeviceselector <br> gyrometer.maxbatchsize <br> gyrometer.reportlatency

#### <a name="gyrometerreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsgyrometerreading"></a>[gyrometerreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.gyrometerreading)

gyrometerreading.performancecount <br> gyrometerreading.properties

#### <a name="inclinometerhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsinclinometer"></a>[傾斜計](https://docs.microsoft.com/uwp/api/windows.devices.sensors.inclinometer)

inclinometer.fromidasync <br> inclinometer.getdeviceselector <br> inclinometer.maxbatchsize <br> inclinometer.reportlatency

#### <a name="inclinometerreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsinclinometerreading"></a>[inclinometerreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.inclinometerreading)

inclinometerreading.performancecount <br> inclinometerreading.properties

#### <a name="lightsensorhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorslightsensor"></a>[lightsensor](https://docs.microsoft.com/uwp/api/windows.devices.sensors.lightsensor)

lightsensor.fromidasync <br> lightsensor.getdeviceselector <br> lightsensor.maxbatchsize <br> lightsensor.reportlatency

#### <a name="lightsensorreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorslightsensorreading"></a>[lightsensorreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.lightsensorreading)

lightsensorreading.performancecount <br> lightsensorreading.properties

#### <a name="magnetometerhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsmagnetometer"></a>[磁力計](https://docs.microsoft.com/uwp/api/windows.devices.sensors.magnetometer)

magnetometer.fromidasync <br> magnetometer.getdeviceselector <br> magnetometer.maxbatchsize <br> magnetometer.reportlatency

#### <a name="magnetometerreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsmagnetometerreading"></a>[magnetometerreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.magnetometerreading)

magnetometerreading.performancecount <br> magnetometerreading.properties

#### <a name="orientationsensorhttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsorientationsensor"></a>[orientationsensor](https://docs.microsoft.com/uwp/api/windows.devices.sensors.orientationsensor)

orientationsensor.fromidasync <br> orientationsensor.getdeviceselector <br> orientationsensor.getdeviceselector <br> orientationsensor.maxbatchsize <br> orientationsensor.reportlatency

#### <a name="orientationsensorreadinghttpsdocsmicrosoftcomuwpapiwindowsdevicessensorsorientationsensorreading"></a>[orientationsensorreading](https://docs.microsoft.com/uwp/api/windows.devices.sensors.orientationsensorreading)

orientationsensorreading.performancecount <br> orientationsensorreading.properties

### <a name="windowsdevicessmartcardshttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcards"></a>[windows.devices.smartcards](https://docs.microsoft.com/uwp/api/windows.devices.smartcards)

#### <a name="smartcardcryptogramgeneratorhttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcardssmartcardcryptogramgenerator"></a>[smartcardcryptogramgenerator](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardcryptogramgenerator)

smartcardcryptogramgenerator.issupported

#### <a name="smartcardemulatorhttpsdocsmicrosoftcomuwpapiwindowsdevicessmartcardssmartcardemulator"></a>[smartcardemulator](https://docs.microsoft.com/uwp/api/windows.devices.smartcards.smartcardemulator)

smartcardemulator.issupported

### <a name="windowsdeviceswifihttpsdocsmicrosoftcomuwpapiwindowsdeviceswifi"></a>[windows.devices.wifi](https://docs.microsoft.com/uwp/api/windows.devices.wifi)

#### <a name="wifiadapterhttpsdocsmicrosoftcomuwpapiwindowsdeviceswifiwifiadapter"></a>[wifiadapter](https://docs.microsoft.com/uwp/api/windows.devices.wifi.wifiadapter)

wifiadapter.connectasync <br> wifiadapter.getwpsconfigurationasync

#### <a name="wificonnectionmethodhttpsdocsmicrosoftcomuwpapiwindowsdeviceswifiwificonnectionmethod"></a>[wificonnectionmethod](https://docs.microsoft.com/uwp/api/windows.devices.wifi.wificonnectionmethod)

wificonnectionmethod

#### <a name="wifiwpsconfigurationresulthttpsdocsmicrosoftcomuwpapiwindowsdeviceswifiwifiwpsconfigurationresult"></a>[wifiwpsconfigurationresult](https://docs.microsoft.com/uwp/api/windows.devices.wifi.wifiwpsconfigurationresult)

wifiwpsconfigurationresult <br> wifiwpsconfigurationresult.status <br> wifiwpsconfigurationresult.supportedwpskinds

#### <a name="wifiwpsconfigurationstatushttpsdocsmicrosoftcomuwpapiwindowsdeviceswifiwifiwpsconfigurationstatus"></a>[wifiwpsconfigurationstatus](https://docs.microsoft.com/uwp/api/windows.devices.wifi.wifiwpsconfigurationstatus)

wifiwpsconfigurationstatus

#### <a name="wifiwpskindhttpsdocsmicrosoftcomuwpapiwindowsdeviceswifiwifiwpskind"></a>[wifiwpskind](https://docs.microsoft.com/uwp/api/windows.devices.wifi.wifiwpskind)

wifiwpskind

## <a name="windowsgaming"></a>windows.gaming

### <a name="windowsgaminginputhttpsdocsmicrosoftcomuwpapiwindowsgaminginput"></a>[windows.gaming.input](https://docs.microsoft.com/uwp/api/windows.gaming.input)

#### <a name="rawgamecontrollerhttpsdocsmicrosoftcomuwpapiwindowsgaminginputrawgamecontroller"></a>[rawgamecontroller](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller)

rawgamecontroller.displayname <br> rawgamecontroller.nonroamableid <br> rawgamecontroller.simplehapticscontrollers

### <a name="windowsgamingpreviewgamesenumerationhttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumeration"></a>[windows.gaming.preview.gamesenumeration](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration)

#### <a name="gamelisthttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumerationgamelist"></a>[gamelist](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration.gamelist)

gamelist.mergeentriesasync <br> gamelist.unmergeentryasync

#### <a name="gamelistentryhttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumerationgamelistentry"></a>[gamelistentry](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration.gamelistentry)

gamelistentry.gamemodeconfiguration <br> gamelistentry.launchablestate <br> gamelistentry.launcherexecutable <br> gamelistentry.launchparameters <br> gamelistentry.setlauncherexecutablefileasync <br> gamelistentry.setlauncherexecutablefileasync <br> gamelistentry.settitleidasync <br> gamelistentry.titleid

#### <a name="gamelistentrylaunchablestatehttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumerationgamelistentrylaunchablestate"></a>[gamelistentrylaunchablestate](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration.gamelistentrylaunchablestate)

gamelistentrylaunchablestate

#### <a name="gamemodeconfigurationhttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumerationgamemodeconfiguration"></a>[gamemodeconfiguration](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration.gamemodeconfiguration)

gamemodeconfiguration <br> gamemodeconfiguration.affinitizetoexclusivecpus <br> gamemodeconfiguration.cpuexclusivitymaskhigh <br> gamemodeconfiguration.cpuexclusivitymasklow <br> gamemodeconfiguration.isenabled <br> gamemodeconfiguration.maxcpucount <br> gamemodeconfiguration.percentgpumemoryallocatedtogame <br> gamemodeconfiguration.percentgpumemoryallocatedtosystemcompositor <br> gamemodeconfiguration.percentgputimeallocatedtogame <br> gamemodeconfiguration.relatedprocessnames <br> gamemodeconfiguration.saveasync

#### <a name="gamemodeuserconfigurationhttpsdocsmicrosoftcomuwpapiwindowsgamingpreviewgamesenumerationgamemodeuserconfiguration"></a>[gamemodeuserconfiguration](https://docs.microsoft.com/uwp/api/windows.gaming.preview.gamesenumeration.gamemodeuserconfiguration)

gamemodeuserconfiguration <br> gamemodeuserconfiguration.gamingrelatedprocessnames <br> gamemodeuserconfiguration.getdefault <br> gamemodeuserconfiguration.saveasync

### <a name="windowsgaminguihttpsdocsmicrosoftcomuwpapiwindowsgamingui"></a>[windows.gaming.ui](https://docs.microsoft.com/uwp/api/windows.gaming.ui)

#### <a name="gamechatmessageoriginhttpsdocsmicrosoftcomuwpapiwindowsgaminguigamechatmessageorigin"></a>[gamechatmessageorigin](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatmessageorigin)

gamechatmessageorigin

#### <a name="gamechatmessagereceivedeventargshttpsdocsmicrosoftcomuwpapiwindowsgaminguigamechatmessagereceivedeventargs"></a>[gamechatmessagereceivedeventargs](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatmessagereceivedeventargs)

gamechatmessagereceivedeventargs <br> gamechatmessagereceivedeventargs.appdisplayname <br> gamechatmessagereceivedeventargs.appid <br> gamechatmessagereceivedeventargs.message <br> gamechatmessagereceivedeventargs.origin <br> gamechatmessagereceivedeventargs.sendername

#### <a name="gamechatoverlayhttpsdocsmicrosoftcomuwpapiwindowsgaminguigamechatoverlay"></a>[gamechatoverlay](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatoverlay)

gamechatoverlay <br> gamechatoverlay.addmessage <br> gamechatoverlay.desiredposition <br> gamechatoverlay.getdefault

#### <a name="gamechatoverlaymessagesourcehttpsdocsmicrosoftcomuwpapiwindowsgaminguigamechatoverlaymessagesource"></a>[gamechatoverlaymessagesource](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatoverlaymessagesource)

gamechatoverlaymessagesource <br> gamechatoverlaymessagesource.gamechatoverlaymessagesource <br> gamechatoverlaymessagesource.messagereceived <br> gamechatoverlaymessagesource.setdelaybeforeclosingaftermessagereceived

#### <a name="gamechatoverlaypositionhttpsdocsmicrosoftcomuwpapiwindowsgaminguigamechatoverlayposition"></a>[gamechatoverlayposition](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamechatoverlayposition)

gamechatoverlayposition

#### <a name="gamemonitorhttpsdocsmicrosoftcomuwpapiwindowsgaminguigamemonitor"></a>[gamemonitor](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamemonitor)

gamemonitor <br> gamemonitor.getdefault <br> gamemonitor.requestpermissionasync

#### <a name="gamemonitoringpermissionhttpsdocsmicrosoftcomuwpapiwindowsgaminguigamemonitoringpermission"></a>[gamemonitoringpermission](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gamemonitoringpermission)

gamemonitoringpermission

#### <a name="gameuiprovideractivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsgaminguigameuiprovideractivatedeventargs"></a>[gameuiprovideractivatedeventargs](https://docs.microsoft.com/uwp/api/windows.gaming.ui.gameuiprovideractivatedeventargs)

gameuiprovideractivatedeventargs <br> gameuiprovideractivatedeventargs.gameuiargs <br> gameuiprovideractivatedeventargs.kind <br> gameuiprovideractivatedeventargs.previousexecutionstate <br> gameuiprovideractivatedeventargs.reportcompleted <br> gameuiprovideractivatedeventargs.splashscreen

## <a name="windowsgraphics"></a>windows.graphics

### <a name="windowsgraphicsholographichttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographic"></a>[windows.graphics.holographic](https://docs.microsoft.com/uwp/api/windows.graphics.holographic)

#### <a name="holographiccamerahttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographiccamera"></a>[holographiccamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)

holographiccamera.isprimarylayerenabled <br> holographiccamera.maxquadlayercount <br> holographiccamera.quadlayers

#### <a name="holographiccamerarenderingparametershttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographiccamerarenderingparameters"></a>[holographiccamerarenderingparameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamerarenderingparameters)

holographiccamerarenderingparameters.iscontentprotectionenabled

#### <a name="holographicdisplayhttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicdisplay"></a>[holographicdisplay](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicdisplay)

holographicdisplay.refreshrate

#### <a name="holographicframehttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicframe"></a>[holographicframe](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicframe)

holographicframe.getquadlayerupdateparameters

#### <a name="holographicquadlayerhttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicquadlayer"></a>[holographicquadlayer](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayer)

holographicquadlayer <br> holographicquadlayer.close <br> holographicquadlayer.holographicquadlayer <br> holographicquadlayer.holographicquadlayer <br> holographicquadlayer.pixelformat <br> holographicquadlayer.size

#### <a name="holographicquadlayerupdateparametershttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicquadlayerupdateparameters"></a>[holographicquadlayerupdateparameters](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicquadlayerupdateparameters)

holographicquadlayerupdateparameters <br> holographicquadlayerupdateparameters.acquirebuffertoupdatecontent <br> holographicquadlayerupdateparameters.updatecontentprotectionenabled <br> holographicquadlayerupdateparameters.updateextents <br> holographicquadlayerupdateparameters.updatelocationwithdisplayrelativemode <br> holographicquadlayerupdateparameters.updatelocationwithstationarymode <br> holographicquadlayerupdateparameters.updateviewport

#### <a name="holographicspacehttpsdocsmicrosoftcomuwpapiwindowsgraphicsholographicholographicspace"></a>[holographicspace](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicspace)

holographicspace.isconfigured

### <a name="windowsgraphicsprintingprinttickethttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticket"></a>[windows.graphics.printing.printticket](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket)

#### <a name="printticketcapabilitieshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketcapabilities"></a>[printticketcapabilities](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketcapabilities)

printticketcapabilities <br> printticketcapabilities.documentbindingfeature <br> printticketcapabilities.documentcollatefeature <br> printticketcapabilities.documentduplexfeature <br> printticketcapabilities.documentholepunchfeature <br> printticketcapabilities.documentinputbinfeature <br> printticketcapabilities.documentnupfeature <br> printticketcapabilities.documentstaplefeature <br> printticketcapabilities.getfeature <br> printticketcapabilities.getparameterdefinition <br> printticketcapabilities.jobpasscodefeature <br> printticketcapabilities.name <br> printticketcapabilities.pageborderlessfeature <br> printticketcapabilities.pagemediasizefeature <br> printticketcapabilities.pagemediatypefeature <br> printticketcapabilities.pageorientationfeature <br> printticketcapabilities.pageoutputcolorfeature <br> printticketcapabilities.pageoutputqualityfeature <br> printticketcapabilities.pageresolutionfeature <br> printticketcapabilities.xmlnamespace <br> printticketcapabilities.xmlnode

#### <a name="printticketfeaturehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketfeature"></a>[printticketfeature](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketfeature)

printticketfeature <br> printticketfeature.displayname <br> printticketfeature.getoption <br> printticketfeature.getselectedoption <br> printticketfeature.name <br> printticketfeature.options <br> printticketfeature.selectiontype <br> printticketfeature.setselectedoption <br> printticketfeature.xmlnamespace <br> printticketfeature.xmlnode

#### <a name="printticketfeatureselectiontypehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketfeatureselectiontype"></a>[printticketfeatureselectiontype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketfeatureselectiontype)

printticketfeatureselectiontype

#### <a name="printticketoptionhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketoption"></a>[printticketoption](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketoption)

printticketoption <br> printticketoption.displayname <br> printticketoption.getpropertynode <br> printticketoption.getpropertyvalue <br> printticketoption.getscoredpropertynode <br> printticketoption.getscoredpropertyvalue <br> printticketoption.name <br> printticketoption.xmlnamespace <br> printticketoption.xmlnode

#### <a name="printticketparameterdatatypehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketparameterdatatype"></a>[printticketparameterdatatype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterdatatype)

printticketparameterdatatype

#### <a name="printticketparameterdefinitionhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketparameterdefinition"></a>[printticketparameterdefinition](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterdefinition)

printticketparameterdefinition <br> printticketparameterdefinition.datatype <br> printticketparameterdefinition.name <br> printticketparameterdefinition.rangemax <br> printticketparameterdefinition.rangemin <br> printticketparameterdefinition.unittype <br> printticketparameterdefinition.xmlnamespace <br> printticketparameterdefinition.xmlnode

#### <a name="printticketparameterinitializerhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketparameterinitializer"></a>[printticketparameterinitializer](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketparameterinitializer)

printticketparameterinitializer <br> printticketparameterinitializer.name <br> printticketparameterinitializer.value <br> printticketparameterinitializer.xmlnamespace <br> printticketparameterinitializer.xmlnode

#### <a name="printticketvaluehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketvalue"></a>[printticketvalue](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketvalue)

printticketvalue <br> printticketvalue.getvalueasinteger <br> printticketvalue.getvalueasstring <br> printticketvalue.type

#### <a name="printticketvaluetypehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketprintticketvaluetype"></a>[printticketvaluetype](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.printticketvaluetype)

printticketvaluetype

#### <a name="workflowprinttickethttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketworkflowprintticket"></a>[workflowprintticket](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.workflowprintticket)

workflowprintticket <br> workflowprintticket.documentbindingfeature <br> workflowprintticket.documentcollatefeature <br> workflowprintticket.documentduplexfeature <br> workflowprintticket.documentholepunchfeature <br> workflowprintticket.documentinputbinfeature <br> workflowprintticket.documentnupfeature <br> workflowprintticket.documentstaplefeature <br> workflowprintticket.getcapabilities <br> workflowprintticket.getfeature <br> workflowprintticket.getparameterinitializer <br> workflowprintticket.jobpasscodefeature <br> workflowprintticket.mergeandvalidateticket <br> workflowprintticket.name <br> workflowprintticket.notifyxmlchangedasync <br> workflowprintticket.pageborderlessfeature <br> workflowprintticket.pagemediasizefeature <br> workflowprintticket.pagemediatypefeature <br> workflowprintticket.pageorientationfeature <br> workflowprintticket.pageoutputcolorfeature <br> workflowprintticket.pageoutputqualityfeature <br> workflowprintticket.pageresolutionfeature <br> workflowprintticket.setparameterinitializerasinteger <br> workflowprintticket.setparameterinitializerasstring <br> workflowprintticket.validateasync <br> workflowprintticket.xmlnamespace <br> workflowprintticket.xmlnode

#### <a name="workflowprintticketvalidationresulthttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingprintticketworkflowprintticketvalidationresult"></a>[workflowprintticketvalidationresult](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printticket.workflowprintticketvalidationresult)

workflowprintticketvalidationresult <br> workflowprintticketvalidationresult.extendederror <br> workflowprintticketvalidationresult.validated

### <a name="windowsgraphicsprintingworkflowhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflow"></a>[windows.graphics.printing.workflow](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow)

#### <a name="printworkflowbackgroundsessionhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowbackgroundsession"></a>[printworkflowbackgroundsession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsession)

printworkflowbackgroundsession <br> printworkflowbackgroundsession.setuprequested <br> printworkflowbackgroundsession.start <br> printworkflowbackgroundsession.status <br> printworkflowbackgroundsession.submitted

#### <a name="printworkflowbackgroundsetuprequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowbackgroundsetuprequestedeventargs"></a>[printworkflowbackgroundsetuprequestedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowbackgroundsetuprequestedeventargs)

printworkflowbackgroundsetuprequestedeventargs <br> printworkflowbackgroundsetuprequestedeventargs.configuration <br> printworkflowbackgroundsetuprequestedeventargs.getdeferral <br> printworkflowbackgroundsetuprequestedeventargs.getuserprintticketasync <br> printworkflowbackgroundsetuprequestedeventargs.setrequiresui

#### <a name="printworkflowconfigurationhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowconfiguration"></a>[printworkflowconfiguration](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowconfiguration)

printworkflowconfiguration <br> printworkflowconfiguration.jobtitle <br> printworkflowconfiguration.sessionid <br> printworkflowconfiguration.sourceappdisplayname

#### <a name="printworkflowforegroundsessionhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowforegroundsession"></a>[printworkflowforegroundsession](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsession)

printworkflowforegroundsession <br> printworkflowforegroundsession.setuprequested <br> printworkflowforegroundsession.start <br> printworkflowforegroundsession.status <br> printworkflowforegroundsession.xpsdataavailable

#### <a name="printworkflowforegroundsetuprequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowforegroundsetuprequestedeventargs"></a>[printworkflowforegroundsetuprequestedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowforegroundsetuprequestedeventargs)

printworkflowforegroundsetuprequestedeventargs <br> printworkflowforegroundsetuprequestedeventargs.configuration <br> printworkflowforegroundsetuprequestedeventargs.getdeferral <br> printworkflowforegroundsetuprequestedeventargs.getuserprintticketasync

#### <a name="printworkflowobjectmodelsourcefilecontenthttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowobjectmodelsourcefilecontent"></a>[printworkflowobjectmodelsourcefilecontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowobjectmodelsourcefilecontent)

printworkflowobjectmodelsourcefilecontent

#### <a name="printworkflowobjectmodeltargetpackagehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowobjectmodeltargetpackage"></a>[printworkflowobjectmodeltargetpackage](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowobjectmodeltargetpackage)

printworkflowobjectmodeltargetpackage

#### <a name="printworkflowsessionstatushttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowsessionstatus"></a>[printworkflowsessionstatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsessionstatus)

printworkflowsessionstatus

#### <a name="printworkflowsourcecontenthttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowsourcecontent"></a>[printworkflowsourcecontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsourcecontent)

printworkflowsourcecontent <br> printworkflowsourcecontent.getjobprintticketasync <br> printworkflowsourcecontent.getsourcespooldataasstreamcontent <br> printworkflowsourcecontent.getsourcespooldataasxpsobjectmodel

#### <a name="printworkflowspoolstreamcontenthttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowspoolstreamcontent"></a>[printworkflowspoolstreamcontent](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowspoolstreamcontent)

printworkflowspoolstreamcontent <br> printworkflowspoolstreamcontent.getinputstream

#### <a name="printworkflowstreamtargethttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowstreamtarget"></a>[printworkflowstreamtarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowstreamtarget)

printworkflowstreamtarget <br> printworkflowstreamtarget.getoutputstream

#### <a name="printworkflowsubmittedeventargshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowsubmittedeventargs"></a>[printworkflowsubmittedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedeventargs)

printworkflowsubmittedeventargs <br> printworkflowsubmittedeventargs.getdeferral <br> printworkflowsubmittedeventargs.gettarget <br> printworkflowsubmittedeventargs.operation

#### <a name="printworkflowsubmittedoperationhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowsubmittedoperation"></a>[printworkflowsubmittedoperation](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedoperation)

printworkflowsubmittedoperation <br> printworkflowsubmittedoperation.complete <br> printworkflowsubmittedoperation.configuration <br> printworkflowsubmittedoperation.xpscontent

#### <a name="printworkflowsubmittedstatushttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowsubmittedstatus"></a>[printworkflowsubmittedstatus](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowsubmittedstatus)

printworkflowsubmittedstatus

#### <a name="printworkflowtargethttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowtarget"></a>[printworkflowtarget](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtarget)

printworkflowtarget <br> printworkflowtarget.targetasstream <br> printworkflowtarget.targetasxpsobjectmodelpackage

#### <a name="printworkflowtriggerdetailshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowtriggerdetails"></a>[printworkflowtriggerdetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowtriggerdetails)

printworkflowtriggerdetails <br> printworkflowtriggerdetails.printworkflowsession

#### <a name="printworkflowuiactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowuiactivatedeventargs"></a>[printworkflowuiactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowuiactivatedeventargs)

printworkflowuiactivatedeventargs <br> printworkflowuiactivatedeventargs.kind <br> printworkflowuiactivatedeventargs.previousexecutionstate <br> printworkflowuiactivatedeventargs.printworkflowsession <br> printworkflowuiactivatedeventargs.splashscreen <br> printworkflowuiactivatedeventargs.user

#### <a name="printworkflowxpsdataavailableeventargshttpsdocsmicrosoftcomuwpapiwindowsgraphicsprintingworkflowprintworkflowxpsdataavailableeventargs"></a>[printworkflowxpsdataavailableeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.printing.workflow.printworkflowxpsdataavailableeventargs)

printworkflowxpsdataavailableeventargs <br> printworkflowxpsdataavailableeventargs.getdeferral <br> printworkflowxpsdataavailableeventargs.operation

### <a name="windowsgraphicsprinting3dhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprinting3d"></a>[windows.graphics.printing3d](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d)

#### <a name="printing3d3mfpackagehttpsdocsmicrosoftcomuwpapiwindowsgraphicsprinting3dprinting3d3mfpackage"></a>[printing3d3mfpackage](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d.printing3d3mfpackage)

printing3d3mfpackage.compression

#### <a name="printing3dpackagecompressionhttpsdocsmicrosoftcomuwpapiwindowsgraphicsprinting3dprinting3dpackagecompression"></a>[printing3dpackagecompression](https://docs.microsoft.com/uwp/api/windows.graphics.printing3d.printing3dpackagecompression)

printing3dpackagecompression

## <a name="windowsmanagement"></a>windows.management

### <a name="windowsmanagementdeploymenthttpsdocsmicrosoftcomuwpapiwindowsmanagementdeployment"></a>[windows.management.deployment](https://docs.microsoft.com/uwp/api/windows.management.deployment)

#### <a name="addpackagebyappinstalleroptionshttpsdocsmicrosoftcomuwpapiwindowsmanagementdeploymentaddpackagebyappinstalleroptions"></a>[addpackagebyappinstalleroptions](https://docs.microsoft.com/uwp/api/windows.management.deployment.addpackagebyappinstalleroptions)

addpackagebyappinstalleroptions

#### <a name="packagemanagerhttpsdocsmicrosoftcomuwpapiwindowsmanagementdeploymentpackagemanager"></a>[packagemanager](https://docs.microsoft.com/uwp/api/windows.management.deployment.packagemanager)

packagemanager.addpackageasync <br> packagemanager.addpackagebyappinstallerfileasync <br> packagemanager.provisionpackageforallusersasync <br> packagemanager.requestaddpackageasync <br> packagemanager.requestaddpackagebyappinstallerfileasync <br> packagemanager.stagepackageasync

## <a name="windowsmedia"></a>windows.media

### <a name="windowsmediaappbroadcastinghttpsdocsmicrosoftcomuwpapiwindowsmediaappbroadcasting"></a>[windows.media.appbroadcasting](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting)

#### <a name="appbroadcastingmonitorhttpsdocsmicrosoftcomuwpapiwindowsmediaappbroadcastingappbroadcastingmonitor"></a>[appbroadcastingmonitor](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingmonitor)

appbroadcastingmonitor <br> appbroadcastingmonitor.appbroadcastingmonitor <br> appbroadcastingmonitor.iscurrentappbroadcasting <br> appbroadcastingmonitor.iscurrentappbroadcastingchanged

#### <a name="appbroadcastingstatushttpsdocsmicrosoftcomuwpapiwindowsmediaappbroadcastingappbroadcastingstatus"></a>[appbroadcastingstatus](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingstatus)

appbroadcastingstatus <br> appbroadcastingstatus.canstartbroadcast <br> appbroadcastingstatus.details

#### <a name="appbroadcastingstatusdetailshttpsdocsmicrosoftcomuwpapiwindowsmediaappbroadcastingappbroadcastingstatusdetails"></a>[appbroadcastingstatusdetails](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingstatusdetails)

appbroadcastingstatusdetails <br> appbroadcastingstatusdetails.isanyappbroadcasting <br> appbroadcastingstatusdetails.isappinactive <br> appbroadcastingstatusdetails.isblockedforapp <br> appbroadcastingstatusdetails.iscaptureresourceunavailable <br> appbroadcastingstatusdetails.isdisabledbysystem <br> appbroadcastingstatusdetails.isdisabledbyuser <br> appbroadcastingstatusdetails.isgamestreaminprogress <br> appbroadcastingstatusdetails.isgpuconstrained

#### <a name="appbroadcastinguihttpsdocsmicrosoftcomuwpapiwindowsmediaappbroadcastingappbroadcastingui"></a>[appbroadcastingui](https://docs.microsoft.com/uwp/api/windows.media.appbroadcasting.appbroadcastingui)

appbroadcastingui <br> appbroadcastingui.getdefault <br> appbroadcastingui.getforuser <br> appbroadcastingui.getstatus <br> appbroadcastingui.showbroadcastui

### <a name="windowsmediaapprecordinghttpsdocsmicrosoftcomuwpapiwindowsmediaapprecording"></a>[windows.media.apprecording](https://docs.microsoft.com/uwp/api/windows.media.apprecording)

#### <a name="apprecordingmanagerhttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingmanager"></a>[apprecordingmanager](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingmanager)

apprecordingmanager <br> apprecordingmanager.getdefault <br> apprecordingmanager.getstatus <br> apprecordingmanager.recordtimespantofileasync <br> apprecordingmanager.savescreenshottofilesasync <br> apprecordingmanager.startrecordingtofileasync <br> apprecordingmanager.supportedscreenshotmediaencodingsubtypes

#### <a name="apprecordingresulthttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingresult"></a>[apprecordingresult](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingresult)

apprecordingresult <br> apprecordingresult.duration <br> apprecordingresult.extendederror <br> apprecordingresult.isfiletruncated <br> apprecordingresult.succeeded

#### <a name="apprecordingsavedscreenshotinfohttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingsavedscreenshotinfo"></a>[apprecordingsavedscreenshotinfo](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingsavedscreenshotinfo)

apprecordingsavedscreenshotinfo <br> apprecordingsavedscreenshotinfo.file <br> apprecordingsavedscreenshotinfo.mediaencodingsubtype

#### <a name="apprecordingsavescreenshotoptionhttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingsavescreenshotoption"></a>[apprecordingsavescreenshotoption](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingsavescreenshotoption)

apprecordingsavescreenshotoption

#### <a name="apprecordingsavescreenshotresulthttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingsavescreenshotresult"></a>[apprecordingsavescreenshotresult](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingsavescreenshotresult)

apprecordingsavescreenshotresult <br> apprecordingsavescreenshotresult.extendederror <br> apprecordingsavescreenshotresult.savedscreenshotinfos <br> apprecordingsavescreenshotresult.succeeded

#### <a name="apprecordingstatushttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingstatus"></a>[apprecordingstatus](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingstatus)

apprecordingstatus <br> apprecordingstatus.canrecord <br> apprecordingstatus.canrecordtimespan <br> apprecordingstatus.details <br> apprecordingstatus.historicalbufferduration

#### <a name="apprecordingstatusdetailshttpsdocsmicrosoftcomuwpapiwindowsmediaapprecordingapprecordingstatusdetails"></a>[apprecordingstatusdetails](https://docs.microsoft.com/uwp/api/windows.media.apprecording.apprecordingstatusdetails)

apprecordingstatusdetails <br> apprecordingstatusdetails.isanyappbroadcasting <br> apprecordingstatusdetails.isappinactive <br> apprecordingstatusdetails.isblockedforapp <br> apprecordingstatusdetails.iscaptureresourceunavailable <br> apprecordingstatusdetails.isdisabledbysystem <br> apprecordingstatusdetails.isdisabledbyuser <br> apprecordingstatusdetails.isgamestreaminprogress <br> apprecordingstatusdetails.isgpuconstrained <br> apprecordingstatusdetails.istimespanrecordingdisabled

### <a name="windowsmediacaptureframeshttpsdocsmicrosoftcomuwpapiwindowsmediacaptureframes"></a>[windows.media.capture.frames](https://docs.microsoft.com/uwp/api/windows.media.capture.frames)

#### <a name="mediaframereaderhttpsdocsmicrosoftcomuwpapiwindowsmediacaptureframesmediaframereader"></a>[mediaframereader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframereader)

mediaframereader.acquisitionmode

#### <a name="mediaframereaderacquisitionmodehttpsdocsmicrosoftcomuwpapiwindowsmediacaptureframesmediaframereaderacquisitionmode"></a>[mediaframereaderacquisitionmode](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframereaderacquisitionmode)

mediaframereaderacquisitionmode

#### <a name="multisourcemediaframereaderhttpsdocsmicrosoftcomuwpapiwindowsmediacaptureframesmultisourcemediaframereader"></a>[multisourcemediaframereader](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.multisourcemediaframereader)

multisourcemediaframereader.acquisitionmode

### <a name="windowsmediacapturehttpsdocsmicrosoftcomuwpapiwindowsmediacapture"></a>[windows.media.capture](https://docs.microsoft.com/uwp/api/windows.media.capture)

#### <a name="appbroadcastbackgroundservicehttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappbroadcastbackgroundservice"></a>[appbroadcastbackgroundservice](https://docs.microsoft.com/uwp/api/windows.media.capture.appbroadcastbackgroundservice)

appbroadcastbackgroundservice.broadcastchannel <br> appbroadcastbackgroundservice.broadcastchannelchanged <br> appbroadcastbackgroundservice.broadcastlanguage <br> appbroadcastbackgroundservice.broadcastlanguagechanged <br> appbroadcastbackgroundservice.broadcasttitlechanged

#### <a name="appbroadcastbackgroundservicesignininfohttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappbroadcastbackgroundservicesignininfo"></a>[appbroadcastbackgroundservicesignininfo](https://docs.microsoft.com/uwp/api/windows.media.capture.appbroadcastbackgroundservicesignininfo)

appbroadcastbackgroundservicesignininfo.usernamechanged

#### <a name="appbroadcastbackgroundservicestreaminfohttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappbroadcastbackgroundservicestreaminfo"></a>[appbroadcastbackgroundservicestreaminfo](https://docs.microsoft.com/uwp/api/windows.media.capture.appbroadcastbackgroundservicestreaminfo)

appbroadcastbackgroundservicestreaminfo.reportproblemwithstream

#### <a name="appcapturehttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappcapture"></a>[appcapture](https://docs.microsoft.com/uwp/api/windows.media.capture.appcapture)

appcapture.setallowedasync

#### <a name="appcapturemetadatapriorityhttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappcapturemetadatapriority"></a>[appcapturemetadatapriority](https://docs.microsoft.com/uwp/api/windows.media.capture.appcapturemetadatapriority)

appcapturemetadatapriority

#### <a name="appcapturemetadatawriterhttpsdocsmicrosoftcomuwpapiwindowsmediacaptureappcapturemetadatawriter"></a>[appcapturemetadatawriter](https://docs.microsoft.com/uwp/api/windows.media.capture.appcapturemetadatawriter)

appcapturemetadatawriter <br> appcapturemetadatawriter.adddoubleevent <br> appcapturemetadatawriter.addint32event <br> appcapturemetadatawriter.addstringevent <br> appcapturemetadatawriter.appcapturemetadatawriter <br> appcapturemetadatawriter.close <br> appcapturemetadatawriter.metadatapurged <br> appcapturemetadatawriter.remainingstoragebytesavailable <br> appcapturemetadatawriter.startdoublestate <br> appcapturemetadatawriter.startint32state <br> appcapturemetadatawriter.startstringstate <br> appcapturemetadatawriter.stopallstates <br> appcapturemetadatawriter.stopstate

### <a name="windowsmediacorehttpsdocsmicrosoftcomuwpapiwindowsmediacore"></a>[windows.media.core](https://docs.microsoft.com/uwp/api/windows.media.core)

#### <a name="audiostreamdescriptorhttpsdocsmicrosoftcomuwpapiwindowsmediacoreaudiostreamdescriptor"></a>[audiostreamdescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.audiostreamdescriptor)

audiostreamdescriptor.label

#### <a name="imediastreamdescriptor2httpsdocsmicrosoftcomuwpapiwindowsmediacoreimediastreamdescriptor2"></a>[imediastreamdescriptor2](https://docs.microsoft.com/uwp/api/windows.media.core.imediastreamdescriptor2)

imediastreamdescriptor2 <br> imediastreamdescriptor2.label

#### <a name="initializemediastreamsourcerequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediacoreinitializemediastreamsourcerequestedeventargs"></a>[initializemediastreamsourcerequestedeventargs](https://docs.microsoft.com/uwp/api/windows.media.core.initializemediastreamsourcerequestedeventargs)

initializemediastreamsourcerequestedeventargs <br> initializemediastreamsourcerequestedeventargs.getdeferral <br> initializemediastreamsourcerequestedeventargs.randomaccessstream <br> initializemediastreamsourcerequestedeventargs.source

#### <a name="lowlightfusionhttpsdocsmicrosoftcomuwpapiwindowsmediacorelowlightfusion"></a>[lowlightfusion](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion)

lowlightfusion <br> lowlightfusion.fuseasync <br> lowlightfusion.maxsupportedframecount <br> lowlightfusion.supportedbitmappixelformats

#### <a name="lowlightfusionresulthttpsdocsmicrosoftcomuwpapiwindowsmediacorelowlightfusionresult"></a>[lowlightfusionresult](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusionresult)

lowlightfusionresult <br> lowlightfusionresult.close <br> lowlightfusionresult.frame

#### <a name="mediasourcehttpsdocsmicrosoftcomuwpapiwindowsmediacoremediasource"></a>[mediasource](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource)

mediasource.createfrommediaframesource

#### <a name="mediasourceappserviceconnectionhttpsdocsmicrosoftcomuwpapiwindowsmediacoremediasourceappserviceconnection"></a>[mediasourceappserviceconnection](https://docs.microsoft.com/uwp/api/windows.media.core.mediasourceappserviceconnection)

mediasourceappserviceconnection <br> mediasourceappserviceconnection.initializemediastreamsourcerequested <br> mediasourceappserviceconnection.mediasourceappserviceconnection <br> mediasourceappserviceconnection.start

#### <a name="mediastreamsourcehttpsdocsmicrosoftcomuwpapiwindowsmediacoremediastreamsource"></a>[mediastreamsource](https://docs.microsoft.com/uwp/api/windows.media.core.mediastreamsource)

mediastreamsource.islive

#### <a name="msestreamsourcehttpsdocsmicrosoftcomuwpapiwindowsmediacoremsestreamsource"></a>[msestreamsource](https://docs.microsoft.com/uwp/api/windows.media.core.msestreamsource)

msestreamsource.liveseekablerange

#### <a name="sceneanalysiseffectframehttpsdocsmicrosoftcomuwpapiwindowsmediacoresceneanalysiseffectframe"></a>[sceneanalysiseffectframe](https://docs.microsoft.com/uwp/api/windows.media.core.sceneanalysiseffectframe)

sceneanalysiseffectframe.analysisrecommendation

#### <a name="sceneanalysisrecommendationhttpsdocsmicrosoftcomuwpapiwindowsmediacoresceneanalysisrecommendation"></a>[sceneanalysisrecommendation](https://docs.microsoft.com/uwp/api/windows.media.core.sceneanalysisrecommendation)

sceneanalysisrecommendation

#### <a name="videostreamdescriptorhttpsdocsmicrosoftcomuwpapiwindowsmediacorevideostreamdescriptor"></a>[videostreamdescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.videostreamdescriptor)

videostreamdescriptor.label

### <a name="windowsmediadialprotocolhttpsdocsmicrosoftcomuwpapiwindowsmediadialprotocol"></a>[windows.media.dialprotocol](https://docs.microsoft.com/uwp/api/windows.media.dialprotocol)

#### <a name="dialreceiverapphttpsdocsmicrosoftcomuwpapiwindowsmediadialprotocoldialreceiverapp"></a>[dialreceiverapp](https://docs.microsoft.com/uwp/api/windows.media.dialprotocol.dialreceiverapp)

dialreceiverapp <br> dialreceiverapp.current <br> dialreceiverapp.getadditionaldataasync <br> dialreceiverapp.setadditionaldataasync

### <a name="windowsmediamediapropertieshttpsdocsmicrosoftcomuwpapiwindowsmediamediaproperties"></a>[windows.media.mediaproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties)

#### <a name="mediaencodingprofilehttpsdocsmicrosoftcomuwpapiwindowsmediamediapropertiesmediaencodingprofile"></a>[mediaencodingprofile](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile)

mediaencodingprofile.getaudiotracks <br> mediaencodingprofile.getvideotracks <br> mediaencodingprofile.setaudiotracks <br> mediaencodingprofile.setvideotracks

### <a name="windowsmediaplaybackhttpsdocsmicrosoftcomuwpapiwindowsmediaplayback"></a>[windows.media.playback](https://docs.microsoft.com/uwp/api/windows.media.playback)

#### <a name="mediaplaybacksessionbufferingstartedeventargshttpsdocsmicrosoftcomuwpapiwindowsmediaplaybackmediaplaybacksessionbufferingstartedeventargs"></a>[mediaplaybacksessionbufferingstartedeventargs](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionbufferingstartedeventargs)

mediaplaybacksessionbufferingstartedeventargs <br> mediaplaybacksessionbufferingstartedeventargs.isplaybackinterruption

#### <a name="mediaplayerhttpsdocsmicrosoftcomuwpapiwindowsmediaplaybackmediaplayer"></a>[mediaplayer](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer)

mediaplayer.rendersubtitlestosurface <br> mediaplayer.rendersubtitlestosurface <br> mediaplayer.subtitleframechanged

### <a name="windowsmediaspeechrecognitionhttpsdocsmicrosoftcomuwpapiwindowsmediaspeechrecognition"></a>[windows.media.speechrecognition](https://docs.microsoft.com/uwp/api/windows.media.speechrecognition)

#### <a name="speechrecognizerhttpsdocsmicrosoftcomuwpapiwindowsmediaspeechrecognitionspeechrecognizer"></a>[speechrecognizer](https://docs.microsoft.com/uwp/api/windows.media.speechrecognition.speechrecognizer)

speechrecognizer.trysetsystemspeechlanguageasync

### <a name="windowsmediaspeechsynthesishttpsdocsmicrosoftcomuwpapiwindowsmediaspeechsynthesis"></a>[windows.media.speechsynthesis](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis)

#### <a name="speechsynthesizerhttpsdocsmicrosoftcomuwpapiwindowsmediaspeechsynthesisspeechsynthesizer"></a>[speechsynthesizer](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechsynthesizer)

speechsynthesizer.trysetdefaultvoiceasync

#### <a name="speechsynthesizeroptionshttpsdocsmicrosoftcomuwpapiwindowsmediaspeechsynthesisspeechsynthesizeroptions"></a>[speechsynthesizeroptions](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechsynthesizeroptions)

speechsynthesizeroptions.audiopitch <br> speechsynthesizeroptions.audiovolume <br> speechsynthesizeroptions.speakingrate

### <a name="windowsmediastreamingadaptivehttpsdocsmicrosoftcomuwpapiwindowsmediastreamingadaptive"></a>[windows.media.streaming.adaptive](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive)

#### <a name="adaptivemediasourcediagnosticavailableeventargshttpsdocsmicrosoftcomuwpapiwindowsmediastreamingadaptiveadaptivemediasourcediagnosticavailableeventargs"></a>[adaptivemediasourcediagnosticavailableeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnosticavailableeventargs)

adaptivemediasourcediagnosticavailableeventargs.extendederror

## <a name="windowsnetworking"></a>windows.networking

### <a name="windowsnetworkingbackgroundtransferhttpsdocsmicrosoftcomuwpapiwindowsnetworkingbackgroundtransfer"></a>[windows.networking.backgroundtransfer](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer)

#### <a name="backgroundtransferfilerangehttpsdocsmicrosoftcomuwpapiwindowsnetworkingbackgroundtransferbackgroundtransferfilerange"></a>[backgroundtransferfilerange](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer.backgroundtransferfilerange)

backgroundtransferfilerange

#### <a name="backgroundtransferrangesdownloadedeventargshttpsdocsmicrosoftcomuwpapiwindowsnetworkingbackgroundtransferbackgroundtransferrangesdownloadedeventargs"></a>[backgroundtransferrangesdownloadedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer.backgroundtransferrangesdownloadedeventargs)

backgroundtransferrangesdownloadedeventargs <br> backgroundtransferrangesdownloadedeventargs.addedranges <br> backgroundtransferrangesdownloadedeventargs.getdeferral <br> backgroundtransferrangesdownloadedeventargs.wasdownloadrestarted

#### <a name="downloadoperationhttpsdocsmicrosoftcomuwpapiwindowsnetworkingbackgroundtransferdownloadoperation"></a>[downloadoperation](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer.downloadoperation)

downloadoperation.currentweberrorstatus <br> downloadoperation.getdownloadedranges <br> downloadoperation.getresultrandomaccessstreamreference <br> downloadoperation.israndomaccessrequired <br> downloadoperation.rangesdownloaded <br> downloadoperation.recoverableweberrorstatuses

### <a name="windowsnetworkingconnectivityhttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivity"></a>[windows.networking.connectivity](https://docs.microsoft.com/uwp/api/windows.networking.connectivity)

#### <a name="connectionprofilehttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivityconnectionprofile"></a>[connectionprofile](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofile)

connectionprofile.getprovidernetworkusageasync

#### <a name="providernetworkusagehttpsdocsmicrosoftcomuwpapiwindowsnetworkingconnectivityprovidernetworkusage"></a>[providernetworkusage](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.providernetworkusage)

providernetworkusage <br> providernetworkusage.bytesreceived <br> providernetworkusage.bytessent <br> providernetworkusage.providerid

### <a name="windowsnetworkingnetworkoperatorshttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperators"></a>[windows.networking.networkoperators](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators)

#### <a name="mobilebroadbandantennasarhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandantennasar"></a>[mobilebroadbandantennasar](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandantennasar)

mobilebroadbandantennasar <br> mobilebroadbandantennasar.antennaindex <br> mobilebroadbandantennasar.sarbackoffindex

#### <a name="mobilebroadbandcellcdmahttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcellcdma"></a>[mobilebroadbandcellcdma](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcellcdma)

mobilebroadbandcellcdma <br> mobilebroadbandcellcdma.basestationid <br> mobilebroadbandcellcdma.basestationlastbroadcastgpstime <br> mobilebroadbandcellcdma.basestationlatitude <br> mobilebroadbandcellcdma.basestationlongitude <br> mobilebroadbandcellcdma.basestationpncode <br> mobilebroadbandcellcdma.networkid <br> mobilebroadbandcellcdma.pilotsignalstrengthindb <br> mobilebroadbandcellcdma.systemid

#### <a name="mobilebroadbandcellgsmhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcellgsm"></a>[mobilebroadbandcellgsm](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcellgsm)

mobilebroadbandcellgsm <br> mobilebroadbandcellgsm.basestationid <br> mobilebroadbandcellgsm.cellid <br> mobilebroadbandcellgsm.channelnumber <br> mobilebroadbandcellgsm.locationareacode <br> mobilebroadbandcellgsm.providerid <br> mobilebroadbandcellgsm.receivedsignalstrengthindbm <br> mobilebroadbandcellgsm.timingadvanceinbitperiods

#### <a name="mobilebroadbandcellltehttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcelllte"></a>[mobilebroadbandcelllte](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcelllte)

mobilebroadbandcelllte <br> mobilebroadbandcelllte.cellid <br> mobilebroadbandcelllte.channelnumber <br> mobilebroadbandcelllte.physicalcellid <br> mobilebroadbandcelllte.providerid <br> mobilebroadbandcelllte.referencesignalreceivedpowerindbm <br> mobilebroadbandcelllte.referencesignalreceivedqualityindbm <br> mobilebroadbandcelllte.timingadvanceinbitperiods <br> mobilebroadbandcelllte.trackingareacode

#### <a name="mobilebroadbandcellsinfohttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcellsinfo"></a>[mobilebroadbandcellsinfo](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcellsinfo)

mobilebroadbandcellsinfo <br> mobilebroadbandcellsinfo.neighboringcellscdma <br> mobilebroadbandcellsinfo.neighboringcellsgsm <br> mobilebroadbandcellsinfo.neighboringcellslte <br> mobilebroadbandcellsinfo.neighboringcellstdscdma <br> mobilebroadbandcellsinfo.neighboringcellsumts <br> mobilebroadbandcellsinfo.servingcellscdma <br> mobilebroadbandcellsinfo.servingcellsgsm <br> mobilebroadbandcellsinfo.servingcellslte <br> mobilebroadbandcellsinfo.servingcellstdscdma <br> mobilebroadbandcellsinfo.servingcellsumts

#### <a name="mobilebroadbandcelltdscdmahttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcelltdscdma"></a>[mobilebroadbandcelltdscdma](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcelltdscdma)

mobilebroadbandcelltdscdma <br> mobilebroadbandcelltdscdma.cellid <br> mobilebroadbandcelltdscdma.cellparameterid <br> mobilebroadbandcelltdscdma.channelnumber <br> mobilebroadbandcelltdscdma.locationareacode <br> mobilebroadbandcelltdscdma.pathlossindb <br> mobilebroadbandcelltdscdma.providerid <br> mobilebroadbandcelltdscdma.receivedsignalcodepowerindbm <br> mobilebroadbandcelltdscdma.timingadvanceinbitperiods

#### <a name="mobilebroadbandcellumtshttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandcellumts"></a>[mobilebroadbandcellumts](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandcellumts)

mobilebroadbandcellumts <br> mobilebroadbandcellumts.cellid <br> mobilebroadbandcellumts.channelnumber <br> mobilebroadbandcellumts.locationareacode <br> mobilebroadbandcellumts.pathlossindb <br> mobilebroadbandcellumts.primaryscramblingcode <br> mobilebroadbandcellumts.providerid <br> mobilebroadbandcellumts.receivedsignalcodepowerindbm <br> mobilebroadbandcellumts.signaltonoiseratioindb

#### <a name="mobilebroadbandmodemhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandmodem"></a>[mobilebroadbandmodem](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandmodem)

mobilebroadbandmodem.getispassthroughenabledasync <br> mobilebroadbandmodem.setispassthroughenabledasync

#### <a name="mobilebroadbandmodemconfigurationhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandmodemconfiguration"></a>[mobilebroadbandmodemconfiguration](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandmodemconfiguration)

mobilebroadbandmodemconfiguration.sarmanager

#### <a name="mobilebroadbandmodemstatushttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandmodemstatus"></a>[mobilebroadbandmodemstatus](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandmodemstatus)

mobilebroadbandmodemstatus

#### <a name="mobilebroadbandnetworkhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandnetwork"></a>[mobilebroadbandnetwork](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandnetwork)

mobilebroadbandnetwork.getcellsinfoasync

#### <a name="mobilebroadbandsarmanagerhttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandsarmanager"></a>[mobilebroadbandsarmanager](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandsarmanager)

mobilebroadbandsarmanager <br> mobilebroadbandsarmanager.antennas <br> mobilebroadbandsarmanager.disablebackoffasync <br> mobilebroadbandsarmanager.enablebackoffasync <br> mobilebroadbandsarmanager.getistransmittingasync <br> mobilebroadbandsarmanager.hysteresistimerperiod <br> mobilebroadbandsarmanager.isbackoffenabled <br> mobilebroadbandsarmanager.issarcontrolledbyhardware <br> mobilebroadbandsarmanager.iswifihardwareintegrated <br> mobilebroadbandsarmanager.revertsartohardwarecontrolasync <br> mobilebroadbandsarmanager.setconfigurationasync <br> mobilebroadbandsarmanager.settransmissionstatechangedhysteresisasync <br> mobilebroadbandsarmanager.starttransmissionstatemonitoring <br> mobilebroadbandsarmanager.stoptransmissionstatemonitoring <br> mobilebroadbandsarmanager.transmissionstatechanged

#### <a name="mobilebroadbandtransmissionstatechangedeventargshttpsdocsmicrosoftcomuwpapiwindowsnetworkingnetworkoperatorsmobilebroadbandtransmissionstatechangedeventargs"></a>[mobilebroadbandtransmissionstatechangedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandtransmissionstatechangedeventargs)

mobilebroadbandtransmissionstatechangedeventargs <br> mobilebroadbandtransmissionstatechangedeventargs.istransmitting

### <a name="windowsnetworkingsocketshttpsdocsmicrosoftcomuwpapiwindowsnetworkingsockets"></a>[windows.networking.sockets](https://docs.microsoft.com/uwp/api/windows.networking.sockets)

#### <a name="messagewebsocketcontrolhttpsdocsmicrosoftcomuwpapiwindowsnetworkingsocketsmessagewebsocketcontrol"></a>[messagewebsocketcontrol](https://docs.microsoft.com/uwp/api/windows.networking.sockets.messagewebsocketcontrol)

messagewebsocketcontrol.actualunsolicitedponginterval <br> messagewebsocketcontrol.clientcertificate <br> messagewebsocketcontrol.desiredunsolicitedponginterval <br> messagewebsocketcontrol.receivemode

#### <a name="messagewebsocketmessagereceivedeventargshttpsdocsmicrosoftcomuwpapiwindowsnetworkingsocketsmessagewebsocketmessagereceivedeventargs"></a>[messagewebsocketmessagereceivedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.sockets.messagewebsocketmessagereceivedeventargs)

messagewebsocketmessagereceivedeventargs.ismessagecomplete

#### <a name="messagewebsocketreceivemodehttpsdocsmicrosoftcomuwpapiwindowsnetworkingsocketsmessagewebsocketreceivemode"></a>[messagewebsocketreceivemode](https://docs.microsoft.com/uwp/api/windows.networking.sockets.messagewebsocketreceivemode)

messagewebsocketreceivemode

#### <a name="streamsocketcontrolhttpsdocsmicrosoftcomuwpapiwindowsnetworkingsocketsstreamsocketcontrol"></a>[streamsocketcontrol](https://docs.microsoft.com/uwp/api/windows.networking.sockets.streamsocketcontrol)

streamsocketcontrol.minprotectionlevel

#### <a name="streamwebsocketcontrolhttpsdocsmicrosoftcomuwpapiwindowsnetworkingsocketsstreamwebsocketcontrol"></a>[streamwebsocketcontrol](https://docs.microsoft.com/uwp/api/windows.networking.sockets.streamwebsocketcontrol)

streamwebsocketcontrol.actualunsolicitedponginterval <br> streamwebsocketcontrol.clientcertificate <br> streamwebsocketcontrol.desiredunsolicitedponginterval

## <a name="windowsphone"></a>windows.phone

### <a name="windowsphonenetworkingvoiphttpsdocsmicrosoftcomuwpapiwindowsphonenetworkingvoip"></a>[windows.phone.networking.voip](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip)

#### <a name="voipcallcoordinatorhttpsdocsmicrosoftcomuwpapiwindowsphonenetworkingvoipvoipcallcoordinator"></a>[voipcallcoordinator](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip.voipcallcoordinator)

voipcallcoordinator.setupnewacceptedcall

#### <a name="voipphonecallhttpsdocsmicrosoftcomuwpapiwindowsphonenetworkingvoipvoipphonecall"></a>[voipphonecall](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip.voipphonecall)

voipphonecall.tryshowappui

## <a name="windowssecurity"></a>windows.security

### <a name="windowssecurityauthenticationwebproviderhttpsdocsmicrosoftcomuwpapiwindowssecurityauthenticationwebprovider"></a>[windows.security.authentication.web.provider](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider)

#### <a name="webaccountmanagerhttpsdocsmicrosoftcomuwpapiwindowssecurityauthenticationwebproviderwebaccountmanager"></a>[webaccountmanager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider.webaccountmanager)

webaccountmanager.invalidateappcacheforaccountasync <br> webaccountmanager.invalidateappcacheforallaccountsasync

### <a name="windowssecurityenterprisedatahttpsdocsmicrosoftcomuwpapiwindowssecurityenterprisedata"></a>[windows.security.enterprisedata](https://docs.microsoft.com/uwp/api/windows.security.enterprisedata)

#### <a name="fileprotectioninfohttpsdocsmicrosoftcomuwpapiwindowssecurityenterprisedatafileprotectioninfo"></a>[fileprotectioninfo](https://docs.microsoft.com/uwp/api/windows.security.enterprisedata.fileprotectioninfo)

fileprotectioninfo.isprotectwhileopensupported

## <a name="windowsservices"></a>windows.services

### <a name="windowsservicesmapsguidancehttpsdocsmicrosoftcomuwpapiwindowsservicesmapsguidance"></a>[windows.services.maps.guidance](https://docs.microsoft.com/uwp/api/windows.services.maps.guidance)

#### <a name="guidanceroadsegmenthttpsdocsmicrosoftcomuwpapiwindowsservicesmapsguidanceguidanceroadsegment"></a>[guidanceroadsegment](https://docs.microsoft.com/uwp/api/windows.services.maps.guidance.guidanceroadsegment)

guidanceroadsegment.isscenic

### <a name="windowsservicesmapslocalsearchhttpsdocsmicrosoftcomuwpapiwindowsservicesmapslocalsearch"></a>[windows.services.maps.localsearch](https://docs.microsoft.com/uwp/api/windows.services.maps.localsearch)

#### <a name="placeinfohelperhttpsdocsmicrosoftcomuwpapiwindowsservicesmapslocalsearchplaceinfohelper"></a>[placeinfohelper](https://docs.microsoft.com/uwp/api/windows.services.maps.localsearch.placeinfohelper)

placeinfohelper <br> placeinfohelper.createfromlocallocation

### <a name="windowsservicesmapshttpsdocsmicrosoftcomuwpapiwindowsservicesmaps"></a>[windows.services.maps](https://docs.microsoft.com/uwp/api/windows.services.maps)

#### <a name="maproutehttpsdocsmicrosoftcomuwpapiwindowsservicesmapsmaproute"></a>[maproute](https://docs.microsoft.com/uwp/api/windows.services.maps.maproute)

maproute.isscenic

#### <a name="maprouteoptimizationhttpsdocsmicrosoftcomuwpapiwindowsservicesmapsmaprouteoptimization"></a>[maprouteoptimization](https://docs.microsoft.com/uwp/api/windows.services.maps.maprouteoptimization)

maprouteoptimization.scenic

#### <a name="placeinfohttpsdocsmicrosoftcomuwpapiwindowsservicesmapsplaceinfo"></a>[placeinfo](https://docs.microsoft.com/uwp/api/windows.services.maps.placeinfo)

placeinfo <br> placeinfo.create <br> placeinfo.create <br> placeinfo.createfromidentifier <br> placeinfo.createfromidentifier <br> placeinfo.createfrommaplocation <br> placeinfo.displayaddress <br> placeinfo.displayname <br> placeinfo.geoshape <br> placeinfo.identifier <br> placeinfo.isshowsupported <br> placeinfo.show <br> placeinfo.show

#### <a name="placeinfocreateoptionshttpsdocsmicrosoftcomuwpapiwindowsservicesmapsplaceinfocreateoptions"></a>[placeinfocreateoptions](https://docs.microsoft.com/uwp/api/windows.services.maps.placeinfocreateoptions)

placeinfocreateoptions <br> placeinfocreateoptions.displayaddress <br> placeinfocreateoptions.displayname <br> placeinfocreateoptions.placeinfocreateoptions

## <a name="windowsstorage"></a>windows.storage

### <a name="windowsstorageproviderhttpsdocsmicrosoftcomuwpapiwindowsstorageprovider"></a>[windows.storage.provider](https://docs.microsoft.com/uwp/api/windows.storage.provider)

#### <a name="storageproviderhydrationpolicyhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageproviderhydrationpolicy"></a>[storageproviderhydrationpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderhydrationpolicy)

storageproviderhydrationpolicy

#### <a name="storageproviderhydrationpolicymodifierhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageproviderhydrationpolicymodifier"></a>[storageproviderhydrationpolicymodifier](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderhydrationpolicymodifier)

storageproviderhydrationpolicymodifier

#### <a name="insyncpolicyhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageproviderinsyncpolicy"></a>[insyncpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderinsyncpolicy)

storageproviderinsyncpolicy

#### <a name="istorageprovideritempropertysourcehttpsdocsmicrosoftcomuwpapiwindowsstorageprovideristorageprovideritempropertysource"></a>[istorageprovideritempropertysource](https://docs.microsoft.com/uwp/api/windows.storage.provider.istorageprovideritempropertysource)

istorageprovideritempropertysource <br> istorageprovideritempropertysource.getitemproperties

#### <a name="istorageproviderpropertycapabilitieshttpsdocsmicrosoftcomuwpapiwindowsstorageprovideristorageproviderpropertycapabilities"></a>[istorageproviderpropertycapabilities](https://docs.microsoft.com/uwp/api/windows.storage.provider.istorageproviderpropertycapabilities)

istorageproviderpropertycapabilities <br> istorageproviderpropertycapabilities.ispropertysupported

#### <a name="populationpolicyhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageproviderpopulationpolicy"></a>[populationpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderpopulationpolicy)

storageproviderpopulationpolicy

#### <a name="protectionmodehttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageproviderprotectionmode"></a>[protectionmode](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderprotectionmode)

storageproviderprotectionmode

#### <a name="storageprovideritempropertieshttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovideritemproperties"></a>[storageprovideritemproperties](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovideritemproperties)

storageprovideritemproperties <br> storageprovideritemproperties.setasync

#### <a name="storageprovideritempropertyhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovideritemproperty"></a>[storageprovideritemproperty](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovideritemproperty)

storageprovideritemproperty <br> storageprovideritemproperty.iconresource <br> storageprovideritemproperty.id <br> storageprovideritemproperty.storageprovideritemproperty <br> storageprovideritemproperty.value

#### <a name="storageprovideritempropertydefinitionhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovideritempropertydefinition"></a>[storageprovideritempropertydefinition](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovideritempropertydefinition)

storageprovideritempropertydefinition <br> storageprovideritempropertydefinition.displaynameresource <br> storageprovideritempropertydefinition.id <br> storageprovideritempropertydefinition.storageprovideritempropertydefinition

#### <a name="storageprovidersyncrootinfohttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovidersyncrootinfo"></a>[storageprovidersyncrootinfo](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidersyncrootinfo)

storageprovidersyncrootinfo <br> storageprovidersyncrootinfo.allowpinning <br> storageprovidersyncrootinfo.context <br> storageprovidersyncrootinfo.displaynameresource <br> storageprovidersyncrootinfo.hydrationpolicy <br> storageprovidersyncrootinfo.hydrationpolicymodifier <br> storageprovidersyncrootinfo.iconresource <br> storageprovidersyncrootinfo.id <br> storageprovidersyncrootinfo.insyncpolicy <br> storageprovidersyncrootinfo.path <br> storageprovidersyncrootinfo.populationpolicy <br> storageprovidersyncrootinfo.protectionmode <br> storageprovidersyncrootinfo.recyclebinuri <br> storageprovidersyncrootinfo.showsiblingsasgroup <br> storageprovidersyncrootinfo.storageprovideritempropertydefinitions <br> storageprovidersyncrootinfo.storageprovidersyncrootinfo <br> storageprovidersyncrootinfo.version

#### <a name="storageprovidersyncrootmanagerhttpsdocsmicrosoftcomuwpapiwindowsstorageproviderstorageprovidersyncrootmanager"></a>[storageprovidersyncrootmanager](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidersyncrootmanager)

storageprovidersyncrootmanager <br> storageprovidersyncrootmanager.getcurrentsyncroots <br> storageprovidersyncrootmanager.getsyncrootinformationforfolder <br> storageprovidersyncrootmanager.getsyncrootinformationforid <br> storageprovidersyncrootmanager.register <br> storageprovidersyncrootmanager.unregister

### <a name="windowsstoragestreamshttpsdocsmicrosoftcomuwpapiwindowsstoragestreams"></a>[windows.storage.streams](https://docs.microsoft.com/uwp/api/windows.storage.streams)

#### <a name="fileopendispositionhttpsdocsmicrosoftcomuwpapiwindowsstoragestreamsfileopendisposition"></a>[fileopendisposition](https://docs.microsoft.com/uwp/api/windows.storage.streams.fileopendisposition)

fileopendisposition

#### <a name="filerandomaccessstreamhttpsdocsmicrosoftcomuwpapiwindowsstoragestreamsfilerandomaccessstream"></a>[filerandomaccessstream](https://docs.microsoft.com/uwp/api/windows.storage.streams.filerandomaccessstream)

filerandomaccessstream.openasync <br> filerandomaccessstream.openasync <br> filerandomaccessstream.openforuserasync <br> filerandomaccessstream.openforuserasync <br> filerandomaccessstream.opentransactedwriteasync <br> filerandomaccessstream.opentransactedwriteasync <br> filerandomaccessstream.opentransactedwriteforuserasync <br> filerandomaccessstream.opentransactedwriteforuserasync

### <a name="windowsstoragehttpsdocsmicrosoftcomuwpapiwindowsstorage"></a>[windows.storage](https://docs.microsoft.com/uwp/api/windows.storage)

#### <a name="appdatapathshttpsdocsmicrosoftcomuwpapiwindowsstorageappdatapaths"></a>[appdatapaths](https://docs.microsoft.com/uwp/api/windows.storage.appdatapaths)

appdatapaths <br> appdatapaths.cookies <br> appdatapaths.desktop <br> appdatapaths.documents <br> appdatapaths.favorites <br> appdatapaths.getdefault <br> appdatapaths.getforuser <br> appdatapaths.history <br> appdatapaths.internetcache <br> appdatapaths.localappdata <br> appdatapaths.programdata <br> appdatapaths.roamingappdata

#### <a name="storagelibraryhttpsdocsmicrosoftcomuwpapiwindowsstoragestoragelibrary"></a>[storagelibrary](https://docs.microsoft.com/uwp/api/windows.storage.storagelibrary)

storagelibrary.arefoldersuggestionsavailableasync

#### <a name="storageproviderhttpsdocsmicrosoftcomuwpapiwindowsstoragestorageprovider"></a>[storageprovider](https://docs.microsoft.com/uwp/api/windows.storage.storageprovider)

storageprovider.ispropertysupportedforpartialfileasync

#### <a name="systemdatapathshttpsdocsmicrosoftcomuwpapiwindowsstoragesystemdatapaths"></a>[systemdatapaths](https://docs.microsoft.com/uwp/api/windows.storage.systemdatapaths)

systemdatapaths <br> systemdatapaths.fonts <br> systemdatapaths.getdefault <br> systemdatapaths.programdata <br> systemdatapaths.public <br> systemdatapaths.publicdesktop <br> systemdatapaths.publicdocuments <br> systemdatapaths.publicdownloads <br> systemdatapaths.publicmusic <br> systemdatapaths.publicpictures <br> systemdatapaths.publicvideos <br> systemdatapaths.system <br> systemdatapaths.systemarm <br> systemdatapaths.systemhost <br> systemdatapaths.systemx64 <br> systemdatapaths.systemx86 <br> systemdatapaths.userprofiles <br> systemdatapaths.windows

#### <a name="userdatapathshttpsdocsmicrosoftcomuwpapiwindowsstorageuserdatapaths"></a>[userdatapaths](https://docs.microsoft.com/uwp/api/windows.storage.userdatapaths)

userdatapaths <br> userdatapaths.cameraroll <br> userdatapaths.cookies <br> userdatapaths.desktop <br> userdatapaths.documents <br> userdatapaths.downloads <br> userdatapaths.favorites <br> userdatapaths.getdefault <br> userdatapaths.getforuser <br> userdatapaths.history <br> userdatapaths.internetcache <br> userdatapaths.localappdata <br> userdatapaths.localappdatalow <br> userdatapaths.music <br> userdatapaths.pictures <br> userdatapaths.profile <br> userdatapaths.recent <br> userdatapaths.roamingappdata <br> userdatapaths.savedpictures <br> userdatapaths.screenshots <br> userdatapaths.templates <br> userdatapaths.videos

## <a name="windowssystem"></a>windows.system

### <a name="windowssystemdiagnosticshttpsdocsmicrosoftcomuwpapiwindowssystemdiagnostics"></a>[windows.system.diagnostics](https://docs.microsoft.com/uwp/api/windows.system.diagnostics)

#### <a name="diagnosticactionresulthttpsdocsmicrosoftcomuwpapiwindowssystemdiagnosticsdiagnosticactionresult"></a>[diagnosticactionresult](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.diagnosticactionresult)

diagnosticactionresult <br> diagnosticactionresult.extendederror <br> diagnosticactionresult.results

#### <a name="diagnosticactionstatehttpsdocsmicrosoftcomuwpapiwindowssystemdiagnosticsdiagnosticactionstate"></a>[diagnosticactionstate](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.diagnosticactionstate)

diagnosticactionstate

#### <a name="diagnosticinvokerhttpsdocsmicrosoftcomuwpapiwindowssystemdiagnosticsdiagnosticinvoker"></a>[diagnosticinvoker](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.diagnosticinvoker)

diagnosticinvoker <br> diagnosticinvoker.getdefault <br> diagnosticinvoker.getforuser <br> diagnosticinvoker.issupported <br> diagnosticinvoker.rundiagnosticactionasync

#### <a name="processdiagnosticinfohttpsdocsmicrosoftcomuwpapiwindowssystemdiagnosticsprocessdiagnosticinfo"></a>[processdiagnosticinfo](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.processdiagnosticinfo)

processdiagnosticinfo.getappdiagnosticinfos <br> processdiagnosticinfo.ispackaged <br> processdiagnosticinfo.trygetforprocessid

### <a name="windowssystemprofilesystemmanufacturershttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturers"></a>[windows.system.profile.systemmanufacturers](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers)

#### <a name="oemsupportinfohttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturersoemsupportinfo"></a>[oemsupportinfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.oemsupportinfo)

oemsupportinfo <br> oemsupportinfo.supportapplink <br> oemsupportinfo.supportlink <br> oemsupportinfo.supportprovider

#### <a name="systemsupportinfohttpsdocsmicrosoftcomuwpapiwindowssystemprofilesystemmanufacturerssystemsupportinfo"></a>[systemsupportinfo](https://docs.microsoft.com/uwp/api/windows.system.profile.systemmanufacturers.systemsupportinfo)

systemsupportinfo <br> systemsupportinfo.localsystemedition <br> systemsupportinfo.oemsupportinfo

### <a name="windowssystemremotesystemshttpsdocsmicrosoftcomuwpapiwindowssystemremotesystems"></a>[windows.system.remotesystems](https://docs.microsoft.com/uwp/api/windows.system.remotesystems)

#### <a name="remotesystemhttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystem"></a>[remotesystem](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem)

remotesystem.manufacturerdisplayname <br> remotesystem.modeldisplayname

#### <a name="remotesystemkindshttpsdocsmicrosoftcomuwpapiwindowssystemremotesystemsremotesystemkinds"></a>[remotesystemkinds](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemkinds)

remotesystemkinds.iot <br> remotesystemkinds.laptop <br> remotesystemkinds.tablet

### <a name="windowssystemuserprofilehttpsdocsmicrosoftcomuwpapiwindowssystemuserprofile"></a>[windows.system.userprofile](https://docs.microsoft.com/uwp/api/windows.system.userprofile)

#### <a name="globalizationpreferenceshttpsdocsmicrosoftcomuwpapiwindowssystemuserprofileglobalizationpreferences"></a>[globalizationpreferences](https://docs.microsoft.com/uwp/api/windows.system.userprofile.globalizationpreferences)

globalizationpreferences.trysethomegeographicregion <br> globalizationpreferences.trysetlanguages

### <a name="windowssystemhttpsdocsmicrosoftcomuwpapiwindowssystem"></a>[windows.system](https://docs.microsoft.com/uwp/api/windows.system)

#### <a name="appdiagnosticinfohttpsdocsmicrosoftcomuwpapiwindowssystemappdiagnosticinfo"></a>[appdiagnosticinfo](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfo)

appdiagnosticinfo.createresourcegroupwatcher <br> appdiagnosticinfo.createwatcher <br> appdiagnosticinfo.getresourcegroups <br> appdiagnosticinfo.requestaccessasync <br> appdiagnosticinfo.requestinfoforappasync <br> appdiagnosticinfo.requestinfoforappasync <br> appdiagnosticinfo.requestinfoforpackageasync

#### <a name="appdiagnosticinfowatcherhttpsdocsmicrosoftcomuwpapiwindowssystemappdiagnosticinfowatcher"></a>[appdiagnosticinfowatcher](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatcher)

appdiagnosticinfowatcher <br> appdiagnosticinfowatcher.added <br> appdiagnosticinfowatcher.enumerationcompleted <br> appdiagnosticinfowatcher.removed <br> appdiagnosticinfowatcher.start <br> appdiagnosticinfowatcher.status <br> appdiagnosticinfowatcher.stop <br> appdiagnosticinfowatcher.stopped

#### <a name="appdiagnosticinfowatchereventargshttpsdocsmicrosoftcomuwpapiwindowssystemappdiagnosticinfowatchereventargs"></a>[appdiagnosticinfowatchereventargs](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatchereventargs)

appdiagnosticinfowatchereventargs <br> appdiagnosticinfowatchereventargs.appdiagnosticinfo

#### <a name="appdiagnosticinfowatcherstatushttpsdocsmicrosoftcomuwpapiwindowssystemappdiagnosticinfowatcherstatus"></a>[appdiagnosticinfowatcherstatus](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfowatcherstatus)

appdiagnosticinfowatcherstatus

#### <a name="appmemoryreporthttpsdocsmicrosoftcomuwpapiwindowssystemappmemoryreport"></a>[appmemoryreport](https://docs.microsoft.com/uwp/api/windows.system.appmemoryreport)

appmemoryreport.expectedtotalcommitlimit

#### <a name="appresourcegroupbackgroundtaskreporthttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupbackgroundtaskreport"></a>[appresourcegroupbackgroundtaskreport](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupbackgroundtaskreport)

appresourcegroupbackgroundtaskreport <br> appresourcegroupbackgroundtaskreport.entrypoint <br> appresourcegroupbackgroundtaskreport.name <br> appresourcegroupbackgroundtaskreport.taskid <br> appresourcegroupbackgroundtaskreport.trigger

#### <a name="appresourcegroupenergyquotastatehttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupenergyquotastate"></a>[appresourcegroupenergyquotastate](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupenergyquotastate)

appresourcegroupenergyquotastate

#### <a name="appresourcegroupexecutionstatehttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupexecutionstate"></a>[appresourcegroupexecutionstate](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupexecutionstate)

appresourcegroupexecutionstate

#### <a name="appresourcegroupinfohttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupinfo"></a>[appresourcegroupinfo](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfo)

appresourcegroupinfo <br> appresourcegroupinfo.getbackgroundtaskreports <br> appresourcegroupinfo.getmemoryreport <br> appresourcegroupinfo.getprocessdiagnosticinfos <br> appresourcegroupinfo.getstatereport <br> appresourcegroupinfo.instanceid <br> appresourcegroupinfo.isshared

#### <a name="appresourcegroupinfowatcherhttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupinfowatcher"></a>[appresourcegroupinfowatcher](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfowatcher)

appresourcegroupinfowatcher <br> appresourcegroupinfowatcher.added <br> appresourcegroupinfowatcher.enumerationcompleted <br> appresourcegroupinfowatcher.executionstatechanged <br> appresourcegroupinfowatcher.removed <br> appresourcegroupinfowatcher.start <br> appresourcegroupinfowatcher.status <br> appresourcegroupinfowatcher.stop <br> appresourcegroupinfowatcher.stopped

#### <a name="appresourcegroupinfowatchereventargshttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupinfowatchereventargs"></a>[appresourcegroupinfowatchereventargs](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfowatchereventargs)

appresourcegroupinfowatchereventargs <br> appresourcegroupinfowatchereventargs.appdiagnosticinfos <br> appresourcegroupinfowatchereventargs.appresourcegroupinfo

#### <a name="appresourcegroupinfowatcherexecutionstatechangedeventargshttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupinfowatcherexecutionstatechangedeventargs"></a>[appresourcegroupinfowatcherexecutionstatechangedeventargs](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfowatcherexecutionstatechangedeventargs)

appresourcegroupinfowatcherexecutionstatechangedeventargs <br> appresourcegroupinfowatcherexecutionstatechangedeventargs.appdiagnosticinfos <br> appresourcegroupinfowatcherexecutionstatechangedeventargs.appresourcegroupinfo

#### <a name="appresourcegroupinfowatcherstatushttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupinfowatcherstatus"></a>[appresourcegroupinfowatcherstatus](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfowatcherstatus)

appresourcegroupinfowatcherstatus

#### <a name="appresourcegroupmemoryreporthttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupmemoryreport"></a>[appresourcegroupmemoryreport](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupmemoryreport)

appresourcegroupmemoryreport <br> appresourcegroupmemoryreport.commitusagelevel <br> appresourcegroupmemoryreport.commitusagelimit <br> appresourcegroupmemoryreport.privatecommitusage <br> appresourcegroupmemoryreport.totalcommitusage

#### <a name="appresourcegroupstatereporthttpsdocsmicrosoftcomuwpapiwindowssystemappresourcegroupstatereport"></a>[appresourcegroupstatereport](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupstatereport)

appresourcegroupstatereport <br> appresourcegroupstatereport.energyquotastate <br> appresourcegroupstatereport.executionstate

#### <a name="datetimesettingshttpsdocsmicrosoftcomuwpapiwindowssystemdatetimesettings"></a>[datetimesettings](https://docs.microsoft.com/uwp/api/windows.system.datetimesettings)

datetimesettings <br> datetimesettings.setsystemdatetime

#### <a name="diagnosticaccessstatushttpsdocsmicrosoftcomuwpapiwindowssystemdiagnosticaccessstatus"></a>[diagnosticaccessstatus](https://docs.microsoft.com/uwp/api/windows.system.diagnosticaccessstatus)

diagnosticaccessstatus

#### <a name="dispatcherqueuehttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueue"></a>[dispatcherqueue](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueue)

dispatcherqueue <br> dispatcherqueue.createtimer <br> dispatcherqueue.getforcurrentthread <br> dispatcherqueue.shutdowncompleted <br> dispatcherqueue.shutdownstarting <br> dispatcherqueue.tryenqueue <br> dispatcherqueue.tryenqueue

#### <a name="dispatcherqueuecontrollerhttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueuecontroller"></a>[dispatcherqueuecontroller](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuecontroller)

dispatcherqueuecontroller <br> dispatcherqueuecontroller.createondedicatedthread <br> dispatcherqueuecontroller.dispatcherqueue <br> dispatcherqueuecontroller.shutdownqueueasync

#### <a name="dispatcherqueuehandlerhttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueuehandler"></a>[dispatcherqueuehandler](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuehandler)

dispatcherqueuehandler

#### <a name="dispatcherqueuepriorityhttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueuepriority"></a>[dispatcherqueuepriority](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuepriority)

dispatcherqueuepriority

#### <a name="dispatcherqueueshutdownstartingeventargshttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueueshutdownstartingeventargs"></a>[dispatcherqueueshutdownstartingeventargs](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueueshutdownstartingeventargs)

dispatcherqueueshutdownstartingeventargs <br> dispatcherqueueshutdownstartingeventargs.getdeferral

#### <a name="dispatcherqueuetimerhttpsdocsmicrosoftcomuwpapiwindowssystemdispatcherqueuetimer"></a>[dispatcherqueuetimer](https://docs.microsoft.com/uwp/api/windows.system.dispatcherqueuetimer)

dispatcherqueuetimer <br> dispatcherqueuetimer.interval <br> dispatcherqueuetimer.isrepeating <br> dispatcherqueuetimer.isrunning <br> dispatcherqueuetimer.start <br> dispatcherqueuetimer.stop <br> dispatcherqueuetimer.tick

#### <a name="memorymanagerhttpsdocsmicrosoftcomuwpapiwindowssystemmemorymanager"></a>[memorymanager](https://docs.microsoft.com/uwp/api/windows.system.memorymanager)

memorymanager.expectedappmemoryusagelimit

## <a name="windowsui"></a>windows.ui

### <a name="windowsuicompositioneffectshttpsdocsmicrosoftcomuwpapiwindowsuicompositioneffects"></a>[windows.ui.composition.effects](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects)

#### <a name="scenelightingeffecthttpsdocsmicrosoftcomuwpapiwindowsuicompositioneffectsscenelightingeffect"></a>[scenelightingeffect](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)

scenelightingeffect.reflectancemodel

#### <a name="scenelightingeffectreflectancemodelhttpsdocsmicrosoftcomuwpapiwindowsuicompositioneffectsscenelightingeffectreflectancemodel"></a>[scenelightingeffectreflectancemodel](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel)

scenelightingeffectreflectancemodel

### <a name="windowsuicompositioninteractionshttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractions"></a>[windows.ui.composition.interactions](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions)

#### <a name="interactiontrackerhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontracker"></a>[interactiontracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker)

interactiontracker.configurevector2positioninertiamodifiers

#### <a name="interactiontrackerinertianaturalmotionhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontrackerinertianaturalmotion"></a>[interactiontrackerinertianaturalmotion](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackerinertianaturalmotion)

interactiontrackerinertianaturalmotion <br> interactiontrackerinertianaturalmotion.condition <br> interactiontrackerinertianaturalmotion.create <br> interactiontrackerinertianaturalmotion.naturalmotion

#### <a name="interactiontrackervector2inertiamodifierhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontrackervector2inertiamodifier"></a>[interactiontrackervector2inertiamodifier](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackervector2inertiamodifier)

interactiontrackervector2inertiamodifier

#### <a name="interactiontrackervector2inertianaturalmotionhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninteractionsinteractiontrackervector2inertianaturalmotion"></a>[interactiontrackervector2inertianaturalmotion](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontrackervector2inertianaturalmotion)

interactiontrackervector2inertianaturalmotion <br> interactiontrackervector2inertianaturalmotion.condition <br> interactiontrackervector2inertianaturalmotion.create <br> interactiontrackervector2inertianaturalmotion.naturalmotion

### <a name="windowsuicompositionhttpsdocsmicrosoftcomuwpapiwindowsuicomposition"></a>[windows.ui.composition](https://docs.microsoft.com/uwp/api/windows.ui.composition)

#### <a name="ambientlighthttpsdocsmicrosoftcomuwpapiwindowsuicompositionambientlight"></a>[ambientlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.ambientlight)

ambientlight.intensity

#### <a name="compositionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionanimation"></a>[compositionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimation)

compositionanimation.initialvalueexpressions

#### <a name="compositioncolorgradientstophttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositioncolorgradientstop"></a>[compositioncolorgradientstop](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncolorgradientstop)

compositioncolorgradientstop <br> compositioncolorgradientstop.color <br> compositioncolorgradientstop.offset

#### <a name="compositioncolorgradientstopcollectionhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositioncolorgradientstopcollection"></a>[compositioncolorgradientstopcollection](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncolorgradientstopcollection)

compositioncolorgradientstopcollection <br> compositioncolorgradientstopcollection.append <br> compositioncolorgradientstopcollection.clear <br> compositioncolorgradientstopcollection.first <br> compositioncolorgradientstopcollection.getat <br> compositioncolorgradientstopcollection.getmany <br> compositioncolorgradientstopcollection.getview <br> compositioncolorgradientstopcollection.indexof <br> compositioncolorgradientstopcollection.insertat <br> compositioncolorgradientstopcollection.removeat <br> compositioncolorgradientstopcollection.removeatend <br> compositioncolorgradientstopcollection.replaceall <br> compositioncolorgradientstopcollection.setat <br> compositioncolorgradientstopcollection.size

#### <a name="compositiondropshadowsourcepolicyhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositiondropshadowsourcepolicy"></a>[compositiondropshadowsourcepolicy](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)

compositiondropshadowsourcepolicy

#### <a name="compositiongradientbrushhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositiongradientbrush"></a>[compositiongradientbrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongradientbrush)

compositiongradientbrush <br> compositiongradientbrush.anchorpoint <br> compositiongradientbrush.centerpoint <br> compositiongradientbrush.colorstops <br> compositiongradientbrush.extendmode <br> compositiongradientbrush.interpolationspace <br> compositiongradientbrush.offset <br> compositiongradientbrush.rotationangle <br> compositiongradientbrush.rotationangleindegrees <br> compositiongradientbrush.scale <br> compositiongradientbrush.transformmatrix

#### <a name="compositiongradientextendmodehttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositiongradientextendmode"></a>[compositiongradientextendmode](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongradientextendmode)

compositiongradientextendmode

#### <a name="compositionlighthttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionlight"></a>[compositionlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)

compositionlight.exclusionsfromtargets

#### <a name="compositionlineargradientbrushhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionlineargradientbrush"></a>[compositionlineargradientbrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)

compositionlineargradientbrush <br> compositionlineargradientbrush.endpoint <br> compositionlineargradientbrush.startpoint

#### <a name="compositionobjecthttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositionobject"></a>[compositionobject](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionobject)

compositionobject.dispatcherqueue

#### <a name="compositorhttpsdocsmicrosoftcomuwpapiwindowsuicompositioncompositor"></a>[コンポジター](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositor)

compositor.createcolorgradientstop <br> compositor.createcolorgradientstop <br> compositor.createlineargradientbrush <br> compositor.createspringscalaranimation <br> compositor.createspringvector2animation <br> compositor.createspringvector3animation

#### <a name="distantlighthttpsdocsmicrosoftcomuwpapiwindowsuicompositiondistantlight"></a>[distantlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.distantlight)

distantlight.intensity

#### <a name="dropshadowhttpsdocsmicrosoftcomuwpapiwindowsuicompositiondropshadow"></a>[dropshadow](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)

dropshadow.sourcepolicy

#### <a name="initialvalueexpressioncollectionhttpsdocsmicrosoftcomuwpapiwindowsuicompositioninitialvalueexpressioncollection"></a>[initialvalueexpressioncollection](https://docs.microsoft.com/uwp/api/windows.ui.composition.initialvalueexpressioncollection)

initialvalueexpressioncollection <br> initialvalueexpressioncollection.clear <br> initialvalueexpressioncollection.first <br> initialvalueexpressioncollection.getview <br> initialvalueexpressioncollection.haskey <br> initialvalueexpressioncollection.insert <br> initialvalueexpressioncollection.lookup <br> initialvalueexpressioncollection.remove <br> initialvalueexpressioncollection.size

#### <a name="layervisualhttpsdocsmicrosoftcomuwpapiwindowsuicompositionlayervisual"></a>[layervisual](https://docs.microsoft.com/uwp/api/windows.ui.composition.layervisual)

layervisual.shadow

#### <a name="naturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionnaturalmotionanimation"></a>[naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.naturalmotionanimation)

naturalmotionanimation <br> naturalmotionanimation.delaybehavior <br> naturalmotionanimation.delaytime <br> naturalmotionanimation.stopbehavior

#### <a name="pointlighthttpsdocsmicrosoftcomuwpapiwindowsuicompositionpointlight"></a>[pointlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.pointlight)

pointlight.intensity

#### <a name="scalarnaturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionscalarnaturalmotionanimation"></a>[scalarnaturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.scalarnaturalmotionanimation)

scalarnaturalmotionanimation <br> scalarnaturalmotionanimation.finalvalue <br> scalarnaturalmotionanimation.initialvalue <br> scalarnaturalmotionanimation.initialvelocity

#### <a name="spotlighthttpsdocsmicrosoftcomuwpapiwindowsuicompositionspotlight"></a>[spotlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.spotlight)

spotlight.innerconeintensity <br> spotlight.outerconeintensity

#### <a name="springscalarnaturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionspringscalarnaturalmotionanimation"></a>[springscalarnaturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.springscalarnaturalmotionanimation)

springscalarnaturalmotionanimation <br> springscalarnaturalmotionanimation.dampingratio <br> springscalarnaturalmotionanimation.period

#### <a name="springvector2naturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionspringvector2naturalmotionanimation"></a>[springvector2naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.springvector2naturalmotionanimation)

springvector2naturalmotionanimation <br> springvector2naturalmotionanimation.dampingratio <br> springvector2naturalmotionanimation.period

#### <a name="springvector3naturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionspringvector3naturalmotionanimation"></a>[springvector3naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.springvector3naturalmotionanimation)

springvector3naturalmotionanimation <br> springvector3naturalmotionanimation.dampingratio <br> springvector3naturalmotionanimation.period

#### <a name="vector2naturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionvector2naturalmotionanimation"></a>[vector2naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.vector2naturalmotionanimation)

vector2naturalmotionanimation <br> vector2naturalmotionanimation.finalvalue <br> vector2naturalmotionanimation.initialvalue <br> vector2naturalmotionanimation.initialvelocity

#### <a name="vector3naturalmotionanimationhttpsdocsmicrosoftcomuwpapiwindowsuicompositionvector3naturalmotionanimation"></a>[vector3naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.vector3naturalmotionanimation)

vector3naturalmotionanimation <br> vector3naturalmotionanimation.finalvalue <br> vector3naturalmotionanimation.initialvalue <br> vector3naturalmotionanimation.initialvelocity

### <a name="windowsuicorehttpsdocsmicrosoftcomuwpapiwindowsuicore"></a>[windows.ui.core](https://docs.microsoft.com/uwp/api/windows.ui.core)

#### <a name="corewindowhttpsdocsmicrosoftcomuwpapiwindowsuicorecorewindow"></a>[corewindow](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow)

corewindow.activationmode <br> corewindow.dispatcherqueue

#### <a name="corewindowactivationmodehttpsdocsmicrosoftcomuwpapiwindowsuicorecorewindowactivationmode"></a>[corewindowactivationmode](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindowactivationmode)

corewindowactivationmode

### <a name="windowsuiinputinkingcorehttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingcore"></a>[windows.ui.input.inking.core](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.core)

#### <a name="coreincrementalinkstrokehttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingcorecoreincrementalinkstroke"></a>[coreincrementalinkstroke](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.core.coreincrementalinkstroke)

coreincrementalinkstroke <br> coreincrementalinkstroke.appendinkpoints <br> coreincrementalinkstroke.boundingrect <br> coreincrementalinkstroke.coreincrementalinkstroke <br> coreincrementalinkstroke.createinkstroke <br> coreincrementalinkstroke.drawingattributes <br> coreincrementalinkstroke.pointtransform

#### <a name="coreinkpresenterhosthttpsdocsmicrosoftcomuwpapiwindowsuiinputinkingcorecoreinkpresenterhost"></a>[coreinkpresenterhost](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.core.coreinkpresenterhost)

coreinkpresenterhost <br> coreinkpresenterhost.coreinkpresenterhost <br> coreinkpresenterhost.inkpresenter <br> coreinkpresenterhost.rootvisual

### <a name="windowsuiinputpreviewinjectionhttpsdocsmicrosoftcomuwpapiwindowsuiinputpreviewinjection"></a>[windows.ui.input.preview.injection](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection)

#### <a name="injectedinputgamepadinfohttpsdocsmicrosoftcomuwpapiwindowsuiinputpreviewinjectioninjectedinputgamepadinfo"></a>[injectedinputgamepadinfo](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.injectedinputgamepadinfo)

injectedinputgamepadinfo <br> injectedinputgamepadinfo.buttons <br> injectedinputgamepadinfo.injectedinputgamepadinfo <br> injectedinputgamepadinfo.injectedinputgamepadinfo <br> injectedinputgamepadinfo.leftthumbstickx <br> injectedinputgamepadinfo.leftthumbsticky <br> injectedinputgamepadinfo.lefttrigger <br> injectedinputgamepadinfo.rightthumbstickx <br> injectedinputgamepadinfo.rightthumbsticky <br> injectedinputgamepadinfo.righttrigger

#### <a name="inputinjectorhttpsdocsmicrosoftcomuwpapiwindowsuiinputpreviewinjectioninputinjector"></a>[inputinjector](https://docs.microsoft.com/uwp/api/windows.ui.input.preview.injection.inputinjector)

inputinjector.initializegamepadinjection <br> inputinjector.injectgamepadinput <br> inputinjector.trycreateforappbroadcastonly <br> inputinjector.uninitializegamepadinjection

### <a name="windowsuiinputspatialhttpsdocsmicrosoftcomuwpapiwindowsuiinputspatial"></a>[windows.ui.input.spatial](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial)

#### <a name="spatialinteractioncontrollerhttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialinteractioncontroller"></a>[spatialinteractioncontroller](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractioncontroller)

spatialinteractioncontroller.trygetrenderablemodelasync

#### <a name="spatialinteractionsourcehttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialinteractionsource"></a>[spatialinteractionsource](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractionsource)

spatialinteractionsource.handedness

#### <a name="spatialinteractionsourcehandednesshttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialinteractionsourcehandedness"></a>[spatialinteractionsourcehandedness](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractionsourcehandedness)

spatialinteractionsourcehandedness

#### <a name="spatialinteractionsourcelocationhttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialinteractionsourcelocation"></a>[spatialinteractionsourcelocation](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractionsourcelocation)

spatialinteractionsourcelocation.angularvelocity <br> spatialinteractionsourcelocation.positionaccuracy <br> spatialinteractionsourcelocation.sourcepointerpose

#### <a name="spatialinteractionsourcepositionaccuracyhttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialinteractionsourcepositionaccuracy"></a>[spatialinteractionsourcepositionaccuracy](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractionsourcepositionaccuracy)

spatialinteractionsourcepositionaccuracy

#### <a name="spatialpointerinteractionsourceposehttpsdocsmicrosoftcomuwpapiwindowsuiinputspatialspatialpointerinteractionsourcepose"></a>[spatialpointerinteractionsourcepose](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialpointerinteractionsourcepose)

spatialpointerinteractionsourcepose.orientation <br> spatialpointerinteractionsourcepose.positionaccuracy

### <a name="windowsuiinputhttpsdocsmicrosoftcomuwpapiwindowsuiinput"></a>[windows.ui.input](https://docs.microsoft.com/uwp/api/windows.ui.input)

#### <a name="radialcontrollerconfigurationhttpsdocsmicrosoftcomuwpapiwindowsuiinputradialcontrollerconfiguration"></a>[radialcontrollerconfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.radialcontrollerconfiguration)

radialcontrollerconfiguration.appcontroller <br> radialcontrollerconfiguration.isappcontrollerenabled

### <a name="windowsuishellhttpsdocsmicrosoftcomuwpapiwindowsuishell"></a>[windows.ui.shell](https://docs.microsoft.com/uwp/api/windows.ui.shell)

#### <a name="adaptivecardbuilderhttpsdocsmicrosoftcomuwpapiwindowsuishelladaptivecardbuilder"></a>[adaptivecardbuilder](https://docs.microsoft.com/uwp/api/windows.ui.shell.adaptivecardbuilder)

adaptivecardbuilder <br> adaptivecardbuilder.createadaptivecardfromjson

#### <a name="iadaptivecardhttpsdocsmicrosoftcomuwpapiwindowsuishelliadaptivecard"></a>[iadaptivecard](https://docs.microsoft.com/uwp/api/windows.ui.shell.iadaptivecard)

iadaptivecard <br> iadaptivecard.tojson

#### <a name="iadaptivecardbuilderstaticshttpsdocsmicrosoftcomuwpapiwindowsuishelliadaptivecardbuilderstatics"></a>[iadaptivecardbuilderstatics](https://docs.microsoft.com/uwp/api/windows.ui.shell.iadaptivecardbuilderstatics)

iadaptivecardbuilderstatics <br> iadaptivecardbuilderstatics.createadaptivecardfromjson

#### <a name="taskbarmanagerhttpsdocsmicrosoftcomuwpapiwindowsuishelltaskbarmanager"></a>[taskbarmanager](https://docs.microsoft.com/uwp/api/windows.ui.shell.taskbarmanager)

taskbarmanager <br> taskbarmanager.getdefault <br> taskbarmanager.isapplistentrypinnedasync <br> taskbarmanager.iscurrentapppinnedasync <br> taskbarmanager.ispinningallowed <br> taskbarmanager.issupported <br> taskbarmanager.requestpinapplistentryasync <br> taskbarmanager.requestpincurrentappasync

### <a name="windowsuistartscreenhttpsdocsmicrosoftcomuwpapiwindowsuistartscreen"></a>[windows.ui.startscreen](https://docs.microsoft.com/uwp/api/windows.ui.startscreen)

#### <a name="secondarytilevisualelementshttpsdocsmicrosoftcomuwpapiwindowsuistartscreensecondarytilevisualelements"></a>[secondarytilevisualelements](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.secondarytilevisualelements)

secondarytilevisualelements.mixedrealitymodel

#### <a name="tilemixedrealitymodelhttpsdocsmicrosoftcomuwpapiwindowsuistartscreentilemixedrealitymodel"></a>[tilemixedrealitymodel](https://docs.microsoft.com/uwp/api/windows.ui.startscreen.tilemixedrealitymodel)

tilemixedrealitymodel <br> tilemixedrealitymodel.boundingbox <br> tilemixedrealitymodel.uri

### <a name="windowsuiviewmanagementcorehttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcore"></a>[windows.ui.viewmanagement.core](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core)

#### <a name="coreinputviewhttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputview"></a>[coreinputview](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputview)

coreinputview <br> coreinputview.getcoreinputviewocclusions <br> coreinputview.getforcurrentview <br> coreinputview.occlusionschanged <br> coreinputview.tryhideprimaryview <br> coreinputview.tryshowprimaryview

#### <a name="coreinputviewocclusionhttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputviewocclusion"></a>[coreinputviewocclusion](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewocclusion)

coreinputviewocclusion <br> coreinputviewocclusion.occludingrect <br> coreinputviewocclusion.occlusionkind

#### <a name="coreinputviewocclusionkindhttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputviewocclusionkind"></a>[coreinputviewocclusionkind](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewocclusionkind)

coreinputviewocclusionkind

#### <a name="coreinputviewocclusionschangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiviewmanagementcorecoreinputviewocclusionschangedeventargs"></a>[coreinputviewocclusionschangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewocclusionschangedeventargs)

coreinputviewocclusionschangedeventargs <br> coreinputviewocclusionschangedeventargs.handled <br> coreinputviewocclusionschangedeventargs.occlusions

### <a name="windowsuiwebuihttpsdocsmicrosoftcomuwpapiwindowsuiwebui"></a>[windows.ui.webui](https://docs.microsoft.com/uwp/api/windows.ui.webui)

#### <a name="webuiapplicationhttpsdocsmicrosoftcomuwpapiwindowsuiwebuiwebuiapplication"></a>[webuiapplication](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuiapplication)

webuiapplication.requestrestartasync <br> webuiapplication.requestrestartforuserasync

#### <a name="webuicommandlineactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiwebuiwebuicommandlineactivatedeventargs"></a>[webuicommandlineactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuicommandlineactivatedeventargs)

webuicommandlineactivatedeventargs <br> webuicommandlineactivatedeventargs.activatedoperation <br> webuicommandlineactivatedeventargs.kind <br> webuicommandlineactivatedeventargs.operation <br> webuicommandlineactivatedeventargs.previousexecutionstate <br> webuicommandlineactivatedeventargs.splashscreen <br> webuicommandlineactivatedeventargs.user

#### <a name="webuistartuptaskactivatedeventargshttpsdocsmicrosoftcomuwpapiwindowsuiwebuiwebuistartuptaskactivatedeventargs"></a>[webuistartuptaskactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuistartuptaskactivatedeventargs)

webuistartuptaskactivatedeventargs <br> webuistartuptaskactivatedeventargs.kind <br> webuistartuptaskactivatedeventargs.previousexecutionstate <br> webuistartuptaskactivatedeventargs.splashscreen <br> webuistartuptaskactivatedeventargs.taskid <br> webuistartuptaskactivatedeventargs.user

### <a name="windowsuixamlautomationpeershttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeers"></a>[windows.ui.xaml.automation.peers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers)

#### <a name="automationnotificationkindhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersautomationnotificationkind"></a>[automationnotificationkind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationnotificationkind)

automationnotificationkind

#### <a name="automationnotificationprocessinghttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersautomationnotificationprocessing"></a>[automationnotificationprocessing](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationnotificationprocessing)

automationnotificationprocessing

#### <a name="automationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersautomationpeer"></a>[automationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationpeer)

automationpeer.raisenotificationevent

#### <a name="colorpickersliderautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeerscolorpickersliderautomationpeer"></a>[colorpickersliderautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.colorpickersliderautomationpeer)

colorpickersliderautomationpeer <br> colorpickersliderautomationpeer.colorpickersliderautomationpeer

#### <a name="colorspectrumautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeerscolorspectrumautomationpeer"></a>[colorspectrumautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.colorspectrumautomationpeer)

colorspectrumautomationpeer <br> colorspectrumautomationpeer.colorspectrumautomationpeer

#### <a name="navigationviewitemautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersnavigationviewitemautomationpeer"></a>[navigationviewitemautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.navigationviewitemautomationpeer)

navigationviewitemautomationpeer <br> navigationviewitemautomationpeer.navigationviewitemautomationpeer

#### <a name="personpictureautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeerspersonpictureautomationpeer"></a>[personpictureautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.personpictureautomationpeer)

personpictureautomationpeer <br> personpictureautomationpeer.personpictureautomationpeer

#### <a name="ratingcontrolautomationpeerhttpsdocsmicrosoftcomuwpapiwindowsuixamlautomationpeersratingcontrolautomationpeer"></a>[ratingcontrolautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.ratingcontrolautomationpeer)

ratingcontrolautomationpeer <br> ratingcontrolautomationpeer.ratingcontrolautomationpeer

### <a name="windowsuixamlcontrolsmapshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmaps"></a>[windows.ui.xaml.controls.maps](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps)

#### <a name="mapcontrolhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapcontrol"></a>[mapcontrol](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol)

mapcontrol.layers <br> mapcontrol.layersproperty <br> mapcontrol.trygetlocationfromoffset <br> mapcontrol.trygetlocationfromoffset

#### <a name="mapcontroldatahelperhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapcontroldatahelper"></a>[mapcontroldatahelper](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontroldatahelper)

mapcontroldatahelper.createmapcontrol

#### <a name="mapelement3dhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelement3d"></a>[mapelement3d](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement3d)

mapelement3d <br> mapelement3d.heading <br> mapelement3d.headingproperty <br> mapelement3d.location <br> mapelement3d.locationproperty <br> mapelement3d.mapelement3d <br> mapelement3d.model <br> mapelement3d.pitch <br> mapelement3d.pitchproperty <br> mapelement3d.roll <br> mapelement3d.rollproperty <br> mapelement3d.scale <br> mapelement3d.scaleproperty

#### <a name="mapelementhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelement"></a>[mapelement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement)

mapelement.mapstylesheetentry <br> mapelement.mapstylesheetentryproperty <br> mapelement.mapstylesheetentrystate <br> mapelement.mapstylesheetentrystateproperty <br> mapelement.tag <br> mapelement.tagproperty

#### <a name="mapelementslayerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelementslayer"></a>[mapelementslayer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayer)

mapelementslayer <br> mapelementslayer.mapcontextrequested <br> mapelementslayer.mapelementclick <br> mapelementslayer.mapelementpointerentered <br> mapelementslayer.mapelementpointerexited <br> mapelementslayer.mapelements <br> mapelementslayer.mapelementslayer <br> mapelementslayer.mapelementsproperty

#### <a name="mapelementslayerclickeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelementslayerclickeventargs"></a>[mapelementslayerclickeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayerclickeventargs)

mapelementslayerclickeventargs <br> mapelementslayerclickeventargs.location <br> mapelementslayerclickeventargs.mapelements <br> mapelementslayerclickeventargs.mapelementslayerclickeventargs <br> mapelementslayerclickeventargs.position

#### <a name="mapelementslayercontextrequestedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelementslayercontextrequestedeventargs"></a>[mapelementslayercontextrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayercontextrequestedeventargs)

mapelementslayercontextrequestedeventargs <br> mapelementslayercontextrequestedeventargs.location <br> mapelementslayercontextrequestedeventargs.mapelements <br> mapelementslayercontextrequestedeventargs.mapelementslayercontextrequestedeventargs <br> mapelementslayercontextrequestedeventargs.position

#### <a name="mapelementslayerpointerenteredeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelementslayerpointerenteredeventargs"></a>[mapelementslayerpointerenteredeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayerpointerenteredeventargs)

mapelementslayerpointerenteredeventargs <br> mapelementslayerpointerenteredeventargs.location <br> mapelementslayerpointerenteredeventargs.mapelement <br> mapelementslayerpointerenteredeventargs.mapelementslayerpointerenteredeventargs <br> mapelementslayerpointerenteredeventargs.position

#### <a name="mapelementslayerpointerexitedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapelementslayerpointerexitedeventargs"></a>[mapelementslayerpointerexitedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelementslayerpointerexitedeventargs)

mapelementslayerpointerexitedeventargs <br> mapelementslayerpointerexitedeventargs.location <br> mapelementslayerpointerexitedeventargs.mapelement <br> mapelementslayerpointerexitedeventargs.mapelementslayerpointerexitedeventargs <br> mapelementslayerpointerexitedeventargs.position

#### <a name="maplayerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmaplayer"></a>[maplayer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.maplayer)

maplayer <br> maplayer.maplayer <br> maplayer.maptabindex <br> maplayer.maptabindexproperty <br> maplayer.visible <br> maplayer.visibleproperty <br> maplayer.zindex <br> maplayer.zindexproperty

#### <a name="mapmodel3dhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapmodel3d"></a>[mapmodel3d](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3d)

mapmodel3d <br> mapmodel3d.createfrom3mfasync <br> mapmodel3d.createfrom3mfasync <br> mapmodel3d.mapmodel3d

#### <a name="mapmodel3dshadingoptionhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapmodel3dshadingoption"></a>[mapmodel3dshadingoption](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapmodel3dshadingoption)

mapmodel3dshadingoption

#### <a name="mapstylesheetentrieshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapstylesheetentries"></a>[mapstylesheetentries](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheetentries)

mapstylesheetentries <br> mapstylesheetentries.admindistrict <br> mapstylesheetentries.admindistrictcapital <br> mapstylesheetentries.airport <br> mapstylesheetentries.area <br> mapstylesheetentries.arterialroad <br> mapstylesheetentries.building <br> mapstylesheetentries.business <br> mapstylesheetentries.capital <br> mapstylesheetentries.cemetery <br> mapstylesheetentries.continent <br> mapstylesheetentries.controlledaccesshighway <br> mapstylesheetentries.countryregion <br> mapstylesheetentries.countryregioncapital <br> mapstylesheetentries.district <br> mapstylesheetentries.drivingroute <br> mapstylesheetentries.education <br> mapstylesheetentries.educationbuilding <br> mapstylesheetentries.foodpoint <br> mapstylesheetentries.forest <br> mapstylesheetentries.golfcourse <br> mapstylesheetentries.highspeedramp <br> mapstylesheetentries.highway <br> mapstylesheetentries.indigenouspeoplesreserve <br> mapstylesheetentries.island <br> mapstylesheetentries.majorroad <br> mapstylesheetentries.medical <br> mapstylesheetentries.medicalbuilding <br> mapstylesheetentries.military <br> mapstylesheetentries.naturalpoint <br> mapstylesheetentries.nautical <br> mapstylesheetentries.neighborhood <br> mapstylesheetentries.park <br> mapstylesheetentries.peak <br> mapstylesheetentries.playingfield <br> mapstylesheetentries.point <br> mapstylesheetentries.pointofinterest <br> mapstylesheetentries.political <br> mapstylesheetentries.populatedplace <br> mapstylesheetentries.railway <br> mapstylesheetentries.ramp <br> mapstylesheetentries.reserve <br> mapstylesheetentries.river <br> mapstylesheetentries.road <br> mapstylesheetentries.roadexit <br> mapstylesheetentries.roadshield <br> mapstylesheetentries.routeline <br> mapstylesheetentries.runway <br> mapstylesheetentries.sand <br> mapstylesheetentries.shoppingcenter <br> mapstylesheetentries.stadium <br> mapstylesheetentries.street <br> mapstylesheetentries.structure <br> mapstylesheetentries.tollroad <br> mapstylesheetentries.trail <br> mapstylesheetentries.transit <br> mapstylesheetentries.transitbuilding <br> mapstylesheetentries.transportation <br> mapstylesheetentries.unpavedstreet <br> mapstylesheetentries.vegetation <br> mapstylesheetentries.volcanicpeak <br> mapstylesheetentries.walkingroute <br> mapstylesheetentries.water <br> mapstylesheetentries.waterpoint <br> mapstylesheetentries.waterroute

#### <a name="mapstylesheetentrystateshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmapsmapstylesheetentrystates"></a>[mapstylesheetentrystates](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapstylesheetentrystates)

mapstylesheetentrystates <br> mapstylesheetentrystates.disabled <br> mapstylesheetentrystates.hover <br> mapstylesheetentrystates.selected

### <a name="windowsuixamlcontrolsprimitiveshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitives"></a>[windows.ui.xaml.controls.primitives](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives)

#### <a name="colorpickersliderhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivescolorpickerslider"></a>[colorpickerslider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.colorpickerslider)

colorpickerslider <br> colorpickerslider.colorchannel <br> colorpickerslider.colorchannelproperty <br> colorpickerslider.colorpickerslider

#### <a name="colorspectrumhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivescolorspectrum"></a>[colorspectrum](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.colorspectrum)

colorspectrum <br> colorspectrum.color <br> colorspectrum.colorchanged <br> colorspectrum.colorproperty <br> colorspectrum.colorspectrum <br> colorspectrum.components <br> colorspectrum.componentsproperty <br> colorspectrum.hsvcolor <br> colorspectrum.hsvcolorproperty <br> colorspectrum.maxhue <br> colorspectrum.maxhueproperty <br> colorspectrum.maxsaturation <br> colorspectrum.maxsaturationproperty <br> colorspectrum.maxvalue <br> colorspectrum.maxvalueproperty <br> colorspectrum.minhue <br> colorspectrum.minhueproperty <br> colorspectrum.minsaturation <br> colorspectrum.minsaturationproperty <br> colorspectrum.minvalue <br> colorspectrum.minvalueproperty <br> colorspectrum.shape <br> colorspectrum.shapeproperty

#### <a name="flyoutbasehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitivesflyoutbase"></a>[flyoutbase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.flyoutbase)

flyoutbase.onprocesskeyboardaccelerators <br> flyoutbase.tryinvokekeyboardaccelerator

#### <a name="layoutinformationhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitiveslayoutinformation"></a>[layoutinformation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.layoutinformation)

layoutinformation.getavailablesize

#### <a name="listviewitempresenterhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsprimitiveslistviewitempresenter"></a>[listviewitempresenter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.listviewitempresenter)

listviewitempresenter.revealbackground <br> listviewitempresenter.revealbackgroundproperty <br> listviewitempresenter.revealbackgroundshowsabovecontent <br> listviewitempresenter.revealbackgroundshowsabovecontentproperty <br> listviewitempresenter.revealborderbrush <br> listviewitempresenter.revealborderbrushproperty <br> listviewitempresenter.revealborderthickness <br> listviewitempresenter.revealborderthicknessproperty

### <a name="windowsuixamlcontrolshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrols"></a>[windows.ui.xaml.controls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls)

#### <a name="bitmapiconsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsbitmapiconsource"></a>[bitmapiconsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.bitmapiconsource)

bitmapiconsource <br> bitmapiconsource.bitmapiconsource <br> bitmapiconsource.showasmonochrome <br> bitmapiconsource.showasmonochromeproperty <br> bitmapiconsource.urisource <br> bitmapiconsource.urisourceproperty

#### <a name="charactercasinghttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscharactercasing"></a>[charactercasing](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.charactercasing)

charactercasing

#### <a name="colorchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscolorchangedeventargs"></a>[colorchangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorchangedeventargs)

colorchangedeventargs <br> colorchangedeventargs.newcolor <br> colorchangedeventargs.oldcolor

#### <a name="colorpickerhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscolorpicker"></a>[colorpicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker)

colorpicker <br> colorpicker.color <br> colorpicker.colorchanged <br> colorpicker.colorpicker <br> colorpicker.colorproperty <br> colorpicker.colorspectrumcomponents <br> colorpicker.colorspectrumcomponentsproperty <br> colorpicker.colorspectrumshape <br> colorpicker.colorspectrumshapeproperty <br> colorpicker.isalphaenabled <br> colorpicker.isalphaenabledproperty <br> colorpicker.isalphaslidervisible <br> colorpicker.isalphaslidervisibleproperty <br> colorpicker.isalphatextinputvisible <br> colorpicker.isalphatextinputvisibleproperty <br> colorpicker.iscolorchanneltextinputvisible <br> colorpicker.iscolorchanneltextinputvisibleproperty <br> colorpicker.iscolorpreviewvisible <br> colorpicker.iscolorpreviewvisibleproperty <br> colorpicker.iscolorslidervisible <br> colorpicker.iscolorslidervisibleproperty <br> colorpicker.iscolorspectrumvisible <br> colorpicker.iscolorspectrumvisibleproperty <br> colorpicker.ishexinputvisible <br> colorpicker.ishexinputvisibleproperty <br> colorpicker.ismorebuttonvisible <br> colorpicker.ismorebuttonvisibleproperty <br> colorpicker.maxhue <br> colorpicker.maxhueproperty <br> colorpicker.maxsaturation <br> colorpicker.maxsaturationproperty <br> colorpicker.maxvalue <br> colorpicker.maxvalueproperty <br> colorpicker.minhue <br> colorpicker.minhueproperty <br> colorpicker.minsaturation <br> colorpicker.minsaturationproperty <br> colorpicker.minvalue <br> colorpicker.minvalueproperty <br> colorpicker.previouscolor <br> colorpicker.previouscolorproperty

#### <a name="colorpickerhsvchannelhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscolorpickerhsvchannel"></a>[colorpickerhsvchannel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpickerhsvchannel)

colorpickerhsvchannel

#### <a name="colorspectrumcomponentshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscolorspectrumcomponents"></a>[colorspectrumcomponents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrumcomponents)

colorspectrumcomponents

#### <a name="colorspectrumshapehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscolorspectrumshape"></a>[colorspectrumshape](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorspectrumshape)

colorspectrumshape

#### <a name="comboboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscombobox"></a>[combobox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox)

combobox.placeholderforeground <br> combobox.placeholderforegroundproperty

#### <a name="contentdialoghttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontentdialog"></a>[contentdialog](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentdialog)

contentdialog.showasync

#### <a name="contentdialogplacementhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontentdialogplacement"></a>[contentdialogplacement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentdialogplacement)

contentdialogplacement

#### <a name="controlhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolscontrol"></a>[コントロール](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control)

control.oncharacterreceived <br> control.onpreviewkeydown <br> control.onpreviewkeyup

#### <a name="disabledformattingacceleratorshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsdisabledformattingaccelerators"></a>[disabledformattingaccelerators](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.disabledformattingaccelerators)

disabledformattingaccelerators

#### <a name="fonticonsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsfonticonsource"></a>[fonticonsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.fonticonsource)

fonticonsource <br> fonticonsource.fontfamily <br> fonticonsource.fontfamilyproperty <br> fonticonsource.fonticonsource <br> fonticonsource.fontsize <br> fonticonsource.fontsizeproperty <br> fonticonsource.fontstyle <br> fonticonsource.fontstyleproperty <br> fonticonsource.fontweight <br> fonticonsource.fontweightproperty <br> fonticonsource.glyph <br> fonticonsource.glyphproperty <br> fonticonsource.istextscalefactorenabled <br> fonticonsource.istextscalefactorenabledproperty <br> fonticonsource.mirroredwhenrighttoleft <br> fonticonsource.mirroredwhenrighttoleftproperty

#### <a name="gridhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsgrid"></a>[grid](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.grid)

grid.columnspacing <br> grid.columnspacingproperty <br> grid.rowspacing <br> grid.rowspacingproperty

#### <a name="iconsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsiconsource"></a>[iconsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.iconsource)

iconsource <br> iconsource.foreground <br> iconsource.foregroundproperty

#### <a name="istexttrimmedchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsistexttrimmedchangedeventargs"></a>[istexttrimmedchangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.istexttrimmedchangedeventargs)

istexttrimmedchangedeventargs

#### <a name="mediatransportcontrolshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsmediatransportcontrols"></a>[mediatransportcontrols](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediatransportcontrols)

mediatransportcontrols.hide <br> mediatransportcontrols.isrepeatbuttonvisible <br> mediatransportcontrols.isrepeatbuttonvisibleproperty <br> mediatransportcontrols.isrepeatenabled <br> mediatransportcontrols.isrepeatenabledproperty <br> mediatransportcontrols.show <br> mediatransportcontrols.showandhideautomatically <br> mediatransportcontrols.showandhideautomaticallyproperty

#### <a name="navigationviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationview"></a>[navigationview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

navigationview <br> navigationview.alwaysshowheader <br> navigationview.alwaysshowheaderproperty <br> navigationview.autosuggestbox <br> navigationview.autosuggestboxproperty <br> navigationview.compactmodethresholdwidth <br> navigationview.compactmodethresholdwidthproperty <br> navigationview.compactpanelength <br> navigationview.compactpanelengthproperty <br> navigationview.containerfrommenuitem <br> navigationview.displaymode <br> navigationview.displaymodechanged <br> navigationview.displaymodeproperty <br> navigationview.expandedmodethresholdwidth <br> navigationview.expandedmodethresholdwidthproperty <br> navigationview.header <br> navigationview.headerproperty <br> navigationview.headertemplate <br> navigationview.headertemplateproperty <br> navigationview.ispaneopen <br> navigationview.ispaneopenproperty <br> navigationview.ispanetogglebuttonvisible <br> navigationview.ispanetogglebuttonvisibleproperty <br> navigationview.issettingsvisible <br> navigationview.issettingsvisibleproperty <br> navigationview.iteminvoked <br> navigationview.menuitemcontainerstyle <br> navigationview.menuitemcontainerstyleproperty <br> navigationview.menuitemcontainerstyleselector <br> navigationview.menuitemcontainerstyleselectorproperty <br> navigationview.menuitemfromcontainer <br> navigationview.menuitems <br> navigationview.menuitemsproperty <br> navigationview.menuitemssource <br> navigationview.menuitemssourceproperty <br> navigationview.menuitemtemplate <br> navigationview.menuitemtemplateproperty <br> navigationview.menuitemtemplateselector <br> navigationview.menuitemtemplateselectorproperty <br> navigationview.navigationview <br> navigationview.openpanelength <br> navigationview.openpanelengthproperty <br> navigationview.panefooter <br> navigationview.panefooterproperty <br> navigationview.panetogglebuttonstyle <br> navigationview.panetogglebuttonstyleproperty <br> navigationview.selecteditem <br> navigationview.selecteditemproperty <br> navigationview.selectionchanged <br> navigationview.settingsitem <br> navigationview.settingsitemproperty

#### <a name="navigationviewdisplaymodehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewdisplaymode"></a>[navigationviewdisplaymode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)

navigationviewdisplaymode

#### <a name="navigationviewdisplaymodechangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewdisplaymodechangedeventargs"></a>[navigationviewdisplaymodechangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymodechangedeventargs)

navigationviewdisplaymodechangedeventargs <br> navigationviewdisplaymodechangedeventargs.displaymode

#### <a name="navigationviewitemhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewitem"></a>[navigationviewitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)

navigationviewitem <br> navigationviewitem.compactpanelength <br> navigationviewitem.compactpanelengthproperty <br> navigationviewitem.icon <br> navigationviewitem.iconproperty <br> navigationviewitem.navigationviewitem

#### <a name="navigationviewitembasehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewitembase"></a>[navigationviewitembase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitembase)

navigationviewitembase

#### <a name="navigationviewitemheaderhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewitemheader"></a>[navigationviewitemheader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)

navigationviewitemheader <br> navigationviewitemheader.navigationviewitemheader

#### <a name="navigationviewiteminvokedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewiteminvokedeventargs"></a>[navigationviewiteminvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewiteminvokedeventargs)

navigationviewiteminvokedeventargs <br> navigationviewiteminvokedeventargs.invokeditem <br> navigationviewiteminvokedeventargs.issettingsinvoked <br> navigationviewiteminvokedeventargs.navigationviewiteminvokedeventargs

#### <a name="navigationviewitemseparatorhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewitemseparator"></a>[navigationviewitemseparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)

navigationviewitemseparator <br> navigationviewitemseparator.navigationviewitemseparator

#### <a name="navigationviewlisthttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewlist"></a>[navigationviewlist](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewlist)

navigationviewlist <br> navigationviewlist.navigationviewlist

#### <a name="navigationviewselectionchangedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsnavigationviewselectionchangedeventargs"></a>[navigationviewselectionchangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewselectionchangedeventargs)

navigationviewselectionchangedeventargs <br> navigationviewselectionchangedeventargs.issettingsselected <br> navigationviewselectionchangedeventargs.selecteditem

#### <a name="parallaxsourceoffsetkindhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsparallaxsourceoffsetkind"></a>[parallaxsourceoffsetkind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.parallaxsourceoffsetkind)

parallaxsourceoffsetkind

#### <a name="parallaxviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsparallaxview"></a>[parallaxview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.parallaxview)

parallaxview <br> parallaxview.child <br> parallaxview.childproperty <br> parallaxview.horizontalshift <br> parallaxview.horizontalshiftproperty <br> parallaxview.horizontalsourceendoffset <br> parallaxview.horizontalsourceendoffsetproperty <br> parallaxview.horizontalsourceoffsetkind <br> parallaxview.horizontalsourceoffsetkindproperty <br> parallaxview.horizontalsourcestartoffset <br> parallaxview.horizontalsourcestartoffsetproperty <br> parallaxview.ishorizontalshiftclamped <br> parallaxview.ishorizontalshiftclampedproperty <br> parallaxview.isverticalshiftclamped <br> parallaxview.isverticalshiftclampedproperty <br> parallaxview.maxhorizontalshiftratio <br> parallaxview.maxhorizontalshiftratioproperty <br> parallaxview.maxverticalshiftratio <br> parallaxview.maxverticalshiftratioproperty <br> parallaxview.parallaxview <br> parallaxview.refreshautomatichorizontaloffsets <br> parallaxview.refreshautomaticverticaloffsets <br> parallaxview.source <br> parallaxview.sourceproperty <br> parallaxview.verticalshift <br> parallaxview.verticalshiftproperty <br> parallaxview.verticalsourceendoffset <br> parallaxview.verticalsourceendoffsetproperty <br> parallaxview.verticalsourceoffsetkind <br> parallaxview.verticalsourceoffsetkindproperty <br> parallaxview.verticalsourcestartoffset <br> parallaxview.verticalsourcestartoffsetproperty

#### <a name="passwordboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspasswordbox"></a>[passwordbox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.passwordbox)

passwordbox.passwordchanging

#### <a name="passwordboxpasswordchangingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspasswordboxpasswordchangingeventargs"></a>[passwordboxpasswordchangingeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.passwordboxpasswordchangingeventargs)

passwordboxpasswordchangingeventargs <br> passwordboxpasswordchangingeventargs.iscontentchanging

#### <a name="pathiconsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspathiconsource"></a>[pathiconsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.pathiconsource)

pathiconsource <br> pathiconsource.data <br> pathiconsource.dataproperty <br> pathiconsource.pathiconsource

#### <a name="personpicturehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolspersonpicture"></a>[personpicture](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.personpicture)

personpicture <br> personpicture.badgeglyph <br> personpicture.badgeglyphproperty <br> personpicture.badgeimagesource <br> personpicture.badgeimagesourceproperty <br> personpicture.badgenumber <br> personpicture.badgenumberproperty <br> personpicture.badgetext <br> personpicture.badgetextproperty <br> personpicture.contact <br> personpicture.contactproperty <br> personpicture.displayname <br> personpicture.displaynameproperty <br> personpicture.initials <br> personpicture.initialsproperty <br> personpicture.isgroup <br> personpicture.isgroupproperty <br> personpicture.personpicture <br> personpicture.prefersmallimage <br> personpicture.prefersmallimageproperty <br> personpicture.profilepicture <br> personpicture.profilepictureproperty

#### <a name="ratingcontrolhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsratingcontrol"></a>[ratingcontrol](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingcontrol)

ratingcontrol <br> ratingcontrol.caption <br> ratingcontrol.captionproperty <br> ratingcontrol.initialsetvalue <br> ratingcontrol.initialsetvalueproperty <br> ratingcontrol.isclearenabled <br> ratingcontrol.isclearenabledproperty <br> ratingcontrol.isreadonly <br> ratingcontrol.isreadonlyproperty <br> ratingcontrol.iteminfo <br> ratingcontrol.iteminfoproperty <br> ratingcontrol.maxrating <br> ratingcontrol.maxratingproperty <br> ratingcontrol.placeholdervalue <br> ratingcontrol.placeholdervalueproperty <br> ratingcontrol.ratingcontrol <br> ratingcontrol.value <br> ratingcontrol.valuechanged <br> ratingcontrol.valueproperty

#### <a name="ratingitemfontinfohttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsratingitemfontinfo"></a>[ratingitemfontinfo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingitemfontinfo)

ratingitemfontinfo <br> ratingitemfontinfo.disabledglyph <br> ratingitemfontinfo.disabledglyphproperty <br> ratingitemfontinfo.glyph <br> ratingitemfontinfo.glyphproperty <br> ratingitemfontinfo.placeholderglyph <br> ratingitemfontinfo.placeholderglyphproperty <br> ratingitemfontinfo.pointeroverglyph <br> ratingitemfontinfo.pointeroverglyphproperty <br> ratingitemfontinfo.pointeroverplaceholderglyph <br> ratingitemfontinfo.pointeroverplaceholderglyphproperty <br> ratingitemfontinfo.ratingitemfontinfo <br> ratingitemfontinfo.unsetglyph <br> ratingitemfontinfo.unsetglyphproperty

#### <a name="ratingitemimageinfohttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsratingitemimageinfo"></a>[ratingitemimageinfo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingitemimageinfo)

ratingitemimageinfo <br> ratingitemimageinfo.disabledimage <br> ratingitemimageinfo.disabledimageproperty <br> ratingitemimageinfo.image <br> ratingitemimageinfo.imageproperty <br> ratingitemimageinfo.placeholderimage <br> ratingitemimageinfo.placeholderimageproperty <br> ratingitemimageinfo.pointeroverimage <br> ratingitemimageinfo.pointeroverimageproperty <br> ratingitemimageinfo.pointeroverplaceholderimage <br> ratingitemimageinfo.pointeroverplaceholderimageproperty <br> ratingitemimageinfo.ratingitemimageinfo <br> ratingitemimageinfo.unsetimage <br> ratingitemimageinfo.unsetimageproperty

#### <a name="ratingiteminfohttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsratingiteminfo"></a>[ratingiteminfo](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.ratingiteminfo)

ratingiteminfo <br> ratingiteminfo.ratingiteminfo

#### <a name="richeditboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsricheditbox"></a>[richeditbox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)

richeditbox.charactercasing <br> richeditbox.charactercasingproperty <br> richeditbox.copyingtoclipboard <br> richeditbox.cuttingtoclipboard <br> richeditbox.disabledformattingaccelerators <br> richeditbox.disabledformattingacceleratorsproperty <br> richeditbox.horizontaltextalignment <br> richeditbox.horizontaltextalignmentproperty

#### <a name="richtextblockhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsrichtextblock"></a>[richtextblock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richtextblock)

richtextblock.horizontaltextalignment <br> richtextblock.horizontaltextalignmentproperty <br> richtextblock.istexttrimmed <br> richtextblock.istexttrimmedchanged <br> richtextblock.istexttrimmedproperty <br> richtextblock.texthighlighters

#### <a name="richtextblockoverflowhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsrichtextblockoverflow"></a>[richtextblockoverflow](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richtextblockoverflow)

richtextblockoverflow.istexttrimmed <br> richtextblockoverflow.istexttrimmedchanged <br> richtextblockoverflow.istexttrimmedproperty

#### <a name="splitviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolssplitview"></a>[splitview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.splitview)

splitview.paneopened <br> splitview.paneopening

#### <a name="stackpanelhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsstackpanel"></a>[stackpanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.stackpanel)

stackpanel.spacing <br> stackpanel.spacingproperty

#### <a name="swipebehavioroninvokedhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipebehavioroninvoked"></a>[swipebehavioroninvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipebehavioroninvoked)

swipebehavioroninvoked

#### <a name="swipecontrolhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipecontrol"></a>[swipecontrol](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipecontrol)

swipecontrol <br> swipecontrol.bottomitems <br> swipecontrol.bottomitemsproperty <br> swipecontrol.close <br> swipecontrol.leftitems <br> swipecontrol.leftitemsproperty <br> swipecontrol.rightitems <br> swipecontrol.rightitemsproperty <br> swipecontrol.swipecontrol <br> swipecontrol.topitems <br> swipecontrol.topitemsproperty

#### <a name="swipeitemhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipeitem"></a>[swipeitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipeitem)

swipeitem <br> swipeitem.background <br> swipeitem.backgroundproperty <br> swipeitem.behavioroninvoked <br> swipeitem.behavioroninvokedproperty <br> swipeitem.command <br> swipeitem.commandparameter <br> swipeitem.commandparameterproperty <br> swipeitem.commandproperty <br> swipeitem.foreground <br> swipeitem.foregroundproperty <br> swipeitem.iconsource <br> swipeitem.iconsourceproperty <br> swipeitem.invoked <br> swipeitem.swipeitem <br> swipeitem.text <br> swipeitem.textproperty

#### <a name="swipeiteminvokedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipeiteminvokedeventargs"></a>[swipeiteminvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipeiteminvokedeventargs)

swipeiteminvokedeventargs <br> swipeiteminvokedeventargs.swipecontrol

#### <a name="swipeitemshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipeitems"></a>[swipeitems](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipeitems)

swipeitems <br> swipeitems.append <br> swipeitems.clear <br> swipeitems.first <br> swipeitems.getat <br> swipeitems.getmany <br> swipeitems.getview <br> swipeitems.indexof <br> swipeitems.insertat <br> swipeitems.mode <br> swipeitems.modeproperty <br> swipeitems.removeat <br> swipeitems.removeatend <br> swipeitems.replaceall <br> swipeitems.setat <br> swipeitems.size <br> swipeitems.swipeitems

#### <a name="swipemodehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolsswipemode"></a>[swipemode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swipemode)

swipemode

#### <a name="symboliconsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolssymboliconsource"></a>[symboliconsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.symboliconsource)

symboliconsource <br> symboliconsource.symbol <br> symboliconsource.symboliconsource <br> symboliconsource.symbolproperty

#### <a name="textblockhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextblock"></a>[textblock](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock)

textblock.horizontaltextalignment <br> textblock.horizontaltextalignmentproperty <br> textblock.istexttrimmed <br> textblock.istexttrimmedchanged <br> textblock.istexttrimmedproperty <br> textblock.texthighlighters

#### <a name="textboxhttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextbox"></a>[テキスト ボックス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox)

textbox.beforetextchanging <br> textbox.charactercasing <br> textbox.charactercasingproperty <br> textbox.copyingtoclipboard <br> textbox.cuttingtoclipboard <br> textbox.horizontaltextalignment <br> textbox.horizontaltextalignmentproperty <br> textbox.placeholderforeground <br> textbox.placeholderforegroundproperty

#### <a name="textboxbeforetextchangingeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextboxbeforetextchangingeventargs"></a>[textboxbeforetextchangingeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textboxbeforetextchangingeventargs)

textboxbeforetextchangingeventargs <br> textboxbeforetextchangingeventargs.cancel <br> textboxbeforetextchangingeventargs.newtext

#### <a name="textcontrolcopyingtoclipboardeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextcontrolcopyingtoclipboardeventargs"></a>[textcontrolcopyingtoclipboardeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textcontrolcopyingtoclipboardeventargs)

textcontrolcopyingtoclipboardeventargs <br> textcontrolcopyingtoclipboardeventargs.handled

#### <a name="textcontrolcuttingtoclipboardeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlcontrolstextcontrolcuttingtoclipboardeventargs"></a>[textcontrolcuttingtoclipboardeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textcontrolcuttingtoclipboardeventargs)

textcontrolcuttingtoclipboardeventargs <br> textcontrolcuttingtoclipboardeventargs.handled

### <a name="windowsuixamldocumentshttpsdocsmicrosoftcomuwpapiwindowsuixamldocuments"></a>[windows.ui.xaml.documents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents)

#### <a name="blockhttpsdocsmicrosoftcomuwpapiwindowsuixamldocumentsblock"></a>[block](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.block)

block.horizontaltextalignment <br> block.horizontaltextalignmentproperty

#### <a name="hyperlinkhttpsdocsmicrosoftcomuwpapiwindowsuixamldocumentshyperlink"></a>[ハイパーリンク](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.hyperlink)

hyperlink.istabstop <br> hyperlink.istabstopproperty <br> hyperlink.tabindex <br> hyperlink.tabindexproperty

#### <a name="texthighlighterhttpsdocsmicrosoftcomuwpapiwindowsuixamldocumentstexthighlighter"></a>[texthighlighter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.texthighlighter)

texthighlighter <br> texthighlighter.background <br> texthighlighter.backgroundproperty <br> texthighlighter.foreground <br> texthighlighter.foregroundproperty <br> texthighlighter.ranges <br> texthighlighter.texthighlighter

#### <a name="texthighlighterbasehttpsdocsmicrosoftcomuwpapiwindowsuixamldocumentstexthighlighterbase"></a>[texthighlighterbase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.texthighlighterbase)

texthighlighterbase

#### <a name="textrangehttpsdocsmicrosoftcomuwpapiwindowsuixamldocumentstextrange"></a>[textrange](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.textrange)

textrange

### <a name="windowsuixamlhostinghttpsdocsmicrosoftcomuwpapiwindowsuixamlhosting"></a>[windows.ui.xaml.hosting](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting)

#### <a name="designerappmanagerhttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesignerappmanager"></a>[designerappmanager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.designerappmanager)

designerappmanager <br> designerappmanager.appusermodelid <br> designerappmanager.close <br> designerappmanager.createnewviewasync <br> designerappmanager.designerappexited <br> designerappmanager.designerappmanager <br> designerappmanager.loadobjectintoappasync

#### <a name="designerappviewhttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesignerappview"></a>[designerappview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.designerappview)

designerappview <br> designerappview.applicationviewid <br> designerappview.appusermodelid <br> designerappview.close <br> designerappview.updateviewasync <br> designerappview.viewsize <br> designerappview.viewstate

#### <a name="designerappviewstatehttpsdocsmicrosoftcomuwpapiwindowsuixamlhostingdesignerappviewstate"></a>[designerappviewstate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.hosting.designerappviewstate)

designerappviewstate

### <a name="windowsuixamlinputhttpsdocsmicrosoftcomuwpapiwindowsuixamlinput"></a>[windows.ui.xaml.input](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input)

#### <a name="characterreceivedroutedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputcharacterreceivedroutedeventargs"></a>[characterreceivedroutedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.characterreceivedroutedeventargs)

characterreceivedroutedeventargs <br> characterreceivedroutedeventargs.character <br> characterreceivedroutedeventargs.handled <br> characterreceivedroutedeventargs.keystatus

#### <a name="keyboardacceleratorhttpsdocsmicrosoftcomuwpapiwindowsuixamlinputkeyboardaccelerator"></a>[keyboardaccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator)

keyboardaccelerator <br> keyboardaccelerator.invoked <br> keyboardaccelerator.isenabled <br> keyboardaccelerator.isenabledproperty <br> keyboardaccelerator.key <br> keyboardaccelerator.keyboardaccelerator <br> keyboardaccelerator.keyproperty <br> keyboardaccelerator.modifiers <br> keyboardaccelerator.modifiersproperty <br> keyboardaccelerator.scopeowner <br> keyboardaccelerator.scopeownerproperty

#### <a name="keyboardacceleratorinvokedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputkeyboardacceleratorinvokedeventargs"></a>[keyboardacceleratorinvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorinvokedeventargs)

keyboardacceleratorinvokedeventargs <br> keyboardacceleratorinvokedeventargs.element <br> keyboardacceleratorinvokedeventargs.handled

#### <a name="pointerroutedeventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputpointerroutedeventargs"></a>[pointerroutedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.pointerroutedeventargs)

pointerroutedeventargs.isgenerated

#### <a name="processkeyboardacceleratoreventargshttpsdocsmicrosoftcomuwpapiwindowsuixamlinputprocesskeyboardacceleratoreventargs"></a>[processkeyboardacceleratoreventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.processkeyboardacceleratoreventargs)

processkeyboardacceleratoreventargs <br> processkeyboardacceleratoreventargs.handled <br> processkeyboardacceleratoreventargs.key <br> processkeyboardacceleratoreventargs.modifiers

### <a name="windowsuixamlmarkuphttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkup"></a>[windows.ui.xaml.markup](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup)

#### <a name="markupextensionhttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkupmarkupextension"></a>[markupextension](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.markupextension)

markupextension <br> markupextension.markupextension <br> markupextension.providevalue

#### <a name="markupextensionreturntypeattributehttpsdocsmicrosoftcomuwpapiwindowsuixamlmarkupmarkupextensionreturntypeattribute"></a>[markupextensionreturntypeattribute](https://docs.microsoft.com/uwp/api/windows.ui.xaml.markup.markupextensionreturntypeattribute)

markupextensionreturntypeattribute <br> markupextensionreturntypeattribute.markupextensionreturntypeattribute

### <a name="windowsuixamlmediahttpsdocsmicrosoftcomuwpapiwindowsuixamlmedia"></a>[windows.ui.xaml.media](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media)

#### <a name="acrylicbackgroundsourcehttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaacrylicbackgroundsource"></a>[acrylicbackgroundsource](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.acrylicbackgroundsource)

acrylicbackgroundsource

#### <a name="acrylicbrushhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediaacrylicbrush"></a>[acrylicbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.acrylicbrush)

acrylicbrush <br> acrylicbrush.acrylicbrush <br> acrylicbrush.alwaysusefallback <br> acrylicbrush.alwaysusefallbackproperty <br> acrylicbrush.backgroundsource <br> acrylicbrush.backgroundsourceproperty <br> acrylicbrush.tintcolor <br> acrylicbrush.tintcolorproperty <br> acrylicbrush.tintopacity <br> acrylicbrush.tintopacityproperty <br> acrylicbrush.tinttransitionduration <br> acrylicbrush.tinttransitiondurationproperty

#### <a name="revealbackgroundbrushhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediarevealbackgroundbrush"></a>[revealbackgroundbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbackgroundbrush)

revealbackgroundbrush <br> revealbackgroundbrush.revealbackgroundbrush

#### <a name="revealborderbrushhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediarevealborderbrush"></a>[revealborderbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealborderbrush)

revealborderbrush <br> revealborderbrush.revealborderbrush

#### <a name="revealbrushhttpsdocsmicrosoftcomuwpapiwindowsuixamlmediarevealbrush"></a>[revealbrush](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrush)

revealbrush <br> revealbrush.alwaysusefallback <br> revealbrush.alwaysusefallbackproperty <br> revealbrush.color <br> revealbrush.colorproperty <br> revealbrush.getstate <br> revealbrush.revealbrush <br> revealbrush.setstate <br> revealbrush.stateproperty <br> revealbrush.targettheme <br> revealbrush.targetthemeproperty

#### <a name="revealbrushstatehttpsdocsmicrosoftcomuwpapiwindowsuixamlmediarevealbrushstate"></a>[revealbrushstate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.revealbrushstate)

revealbrushstate

### <a name="windowsuixamlhttpsdocsmicrosoftcomuwpapiwindowsuixaml"></a>[windows.ui.xaml](https://docs.microsoft.com/uwp/api/windows.ui.xaml)

#### <a name="frameworkelementhttpsdocsmicrosoftcomuwpapiwindowsuixamlframeworkelement"></a>[frameworkelement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement)

frameworkelement.actualtheme <br> frameworkelement.actualthemechanged <br> frameworkelement.actualthemeproperty

#### <a name="uielementhttpsdocsmicrosoftcomuwpapiwindowsuixamluielement"></a>[uielement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)

uielement.characterreceived <br> uielement.characterreceivedevent <br> uielement.getchildrenintabfocusorder <br> uielement.keyboardaccelerators <br> uielement.onprocesskeyboardaccelerators <br> uielement.previewkeydown <br> uielement.previewkeydownevent <br> uielement.previewkeyup <br> uielement.previewkeyupevent <br> uielement.processkeyboardaccelerators <br> uielement.tryinvokekeyboardaccelerator