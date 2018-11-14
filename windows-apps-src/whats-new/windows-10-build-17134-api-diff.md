---
author: QuinnRadich
title: Windows 10 ビルド 17134 の API の変更
description: 開発者は、次の一覧を使用して、Windows 10 ビルド 17134 での新しい名前空間や変更された名前空間を確認できます。
keywords: 新着情報, 新機能, 更新プログラム, Windows 10, 最新, api, 17134
ms.author: quradic
ms.date: 4/10/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 40a5621dbd5729d31e2b288b912b10c638ca4f36
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6182346"
---
# <a name="new-apis-in-windows-10-build-17134"></a>Windows 10 ビルド 17134 の新しい API

Windows 10 ビルド 17134 (April Update またはバージョン 1803 とも呼ばれます) には、新規および更新された API 名前空間が開発者用に用意されています。 このリリースで追加または変更された名前空間について公開されているドキュメントの完全な一覧を以下に示します。

1 つ前の一般リリースで追加された API については、「[Windows 10 Fall Creators Update の新しい API](windows-10-build-16299-api-diff.md)」をご覧ください。

## <a name="windowsai"></a>windows.ai

### [<a name="windowsaimachinelearningpreview"></a>windows.ai.machinelearning.preview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview)

#### [<a name="featureelementkindpreview"></a>featureelementkindpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.featureelementkindpreview)

featureelementkindpreview

#### [<a name="ilearningmodelvariabledescriptorpreview"></a>ilearningmodelvariabledescriptorpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.ilearningmodelvariabledescriptorpreview)

ilearningmodelvariabledescriptorpreview <br> ilearningmodelvariabledescriptorpreview.description <br> ilearningmodelvariabledescriptorpreview.modelfeaturekind <br> ilearningmodelvariabledescriptorpreview.name <br> ilearningmodelvariabledescriptorpreview.required

#### [<a name="imagevariabledescriptorpreview"></a>imagevariabledescriptorpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.imagevariabledescriptorpreview)

imagevariabledescriptorpreview <br> imagevariabledescriptorpreview.bitmappixelformat <br> imagevariabledescriptorpreview.description <br> imagevariabledescriptorpreview.modelfeaturekind <br> imagevariabledescriptorpreview.name

#### [<a name="inferencingoptionspreview"></a>inferencingoptionspreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.inferencingoptionspreview)

inferencingoptionspreview <br> inferencingoptionspreview.istracingenabled <br> inferencingoptionspreview.maxbatchsize <br> inferencingoptionspreview.minimizememoryallocation <br> inferencingoptionspreview.preferreddevicekind <br> inferencingoptionspreview.reclaimmemoryafterevaluation

#### [<a name="learningmodelbindingpreview"></a>learningmodelbindingpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodelbindingpreview)

learningmodelbindingpreview <br> learningmodelbindingpreview.bind <br> learningmodelbindingpreview.clear

#### [<a name="learningmodeldescriptionpreview"></a>learningmodeldescriptionpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodeldescriptionpreview)

learningmodeldescriptionpreview <br> learningmodeldescriptionpreview.author <br> learningmodeldescriptionpreview.description <br> learningmodeldescriptionpreview.domain <br> learningmodeldescriptionpreview.inputfeatures <br> learningmodeldescriptionpreview.metadata <br> learningmodeldescriptionpreview.name <br> learningmodeldescriptionpreview.outputfeatures <br> learningmodeldescriptionpreview.version

#### [<a name="learningmodeldevicekindpreview"></a>learningmodeldevicekindpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodeldevicekindpreview)

learningmodeldevicekindpreview

#### [<a name="learningmodelevaluationresultpreview"></a>learningmodelevaluationresultpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodelevaluationresultpreview)

learningmodelevaluationresultpreview <br> learningmodelevaluationresultpreview.correlationid <br> learningmodelevaluationresultpreview.outputs

#### [<a name="learningmodelfeaturekindpreview"></a>learningmodelfeaturekindpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodelfeaturekindpreview)

learningmodelfeaturekindpreview

#### [<a name="learningmodelpreview"></a>learningmodelpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.learningmodelpreview)

learningmodelpreview <br> learningmodelpreview.description <br> learningmodelpreview.evaluatefeaturesasync <br> learningmodelpreview.inferencingoptions <br> learningmodelpreview.loadmodelfromstoragefileasync <br> learningmodelpreview.loadmodelfromstreamasync

#### [<a name="mapvariabledescriptorpreview"></a>mapvariabledescriptorpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.mapvariabledescriptorpreview)

mapvariabledescriptorpreview <br> mapvariabledescriptorpreview.description <br> mapvariabledescriptorpreview.fields <br> mapvariabledescriptorpreview.keykind <br> mapvariabledescriptorpreview.modelfeaturekind <br> mapvariabledescriptorpreview.name

#### [<a name="sequencevariabledescriptorpreview"></a>sequencevariabledescriptorpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.sequencevariabledescriptorpreview)

sequencevariabledescriptorpreview <br> sequencevariabledescriptorpreview.description <br> sequencevariabledescriptorpreview.elementtype <br> sequencevariabledescriptorpreview.modelfeaturekind <br> sequencevariabledescriptorpreview.name

#### [<a name="tensorvariabledescriptorpreview"></a>tensorvariabledescriptorpreview](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.tensorvariabledescriptorpreview)

tensorvariabledescriptorpreview <br> tensorvariabledescriptorpreview.datatype <br> tensorvariabledescriptorpreview.description <br> tensorvariabledescriptorpreview.modelfeaturekind <br> tensorvariabledescriptorpreview.name <br> tensorvariabledescriptorpreview.shape

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.ai.machinelearning.preview.windows)

windows.ai.machinelearning.preview

## <a name="windowsapplicationmodel"></a>windows.applicationmodel

### [<a name="windowsapplicationmodelactivation"></a>windows.applicationmodel.activation](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation)

#### [<a name="barcodescannerpreviewactivatedeventargs"></a>barcodescannerpreviewactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.barcodescannerpreviewactivatedeventargs)

barcodescannerpreviewactivatedeventargs <br> barcodescannerpreviewactivatedeventargs.connectionid <br> barcodescannerpreviewactivatedeventargs.kind <br> barcodescannerpreviewactivatedeventargs.previousexecutionstate <br> barcodescannerpreviewactivatedeventargs.splashscreen <br> barcodescannerpreviewactivatedeventargs.user

#### [<a name="ibarcodescannerpreviewactivatedeventargs"></a>ibarcodescannerpreviewactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.ibarcodescannerpreviewactivatedeventargs)

ibarcodescannerpreviewactivatedeventargs <br> ibarcodescannerpreviewactivatedeventargs.connectionid

### [<a name="windowsapplicationmodelbackground"></a>windows.applicationmodel.background](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background)

#### [<a name="backgroundaccessrequestkind"></a>backgroundaccessrequestkind](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundaccessrequestkind)

backgroundaccessrequestkind

#### [<a name="backgroundexecutionmanager"></a>backgroundexecutionmanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.backgroundexecutionmanager)

backgroundexecutionmanager.requestaccesskindasync

#### [<a name="customsystemeventtrigger"></a>customsystemeventtrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.customsystemeventtrigger)

customsystemeventtrigger <br> customsystemeventtrigger.customsystemeventtrigger <br> customsystemeventtrigger.recurrence <br> customsystemeventtrigger.triggerid

#### [<a name="customsystemeventtriggerrecurrence"></a>customsystemeventtriggerrecurrence](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.customsystemeventtriggerrecurrence)

customsystemeventtriggerrecurrence

#### [<a name="mobilebroadbandpcodatachangetrigger"></a>mobilebroadbandpcodatachangetrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.mobilebroadbandpcodatachangetrigger)

mobilebroadbandpcodatachangetrigger <br> mobilebroadbandpcodatachangetrigger.mobilebroadbandpcodatachangetrigger

#### [<a name="networkoperatordatausagetrigger"></a>networkoperatordatausagetrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.networkoperatordatausagetrigger)

networkoperatordatausagetrigger <br> networkoperatordatausagetrigger.networkoperatordatausagetrigger

#### [<a name="storagelibrarychangetrackertrigger"></a>storagelibrarychangetrackertrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.storagelibrarychangetrackertrigger)

storagelibrarychangetrackertrigger <br> storagelibrarychangetrackertrigger.storagelibrarychangetrackertrigger

#### [<a name="tetheringentitlementchecktrigger"></a>tetheringentitlementchecktrigger](https://docs.microsoft.com/uwp/api/windows.applicationmodel.background.tetheringentitlementchecktrigger)

tetheringentitlementchecktrigger <br> tetheringentitlementchecktrigger.tetheringentitlementchecktrigger

### [<a name="windowsapplicationmodelcallsprovider"></a>windows.applicationmodel.calls.provider](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.provider)

#### [<a name="phonecalloriginmanager"></a>phonecalloriginmanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.provider.phonecalloriginmanager)

phonecalloriginmanager

### [<a name="windowsapplicationmodelcalls"></a>windows.applicationmodel.calls](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls)

#### [<a name="voipcallcoordinator"></a>voipcallcoordinator](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipcallcoordinator)

voipcallcoordinator.requestnewappinitiatedcall <br> voipcallcoordinator.requestnewincomingcall

#### [<a name="voipphonecall"></a>voipphonecall](https://docs.microsoft.com/uwp/api/windows.applicationmodel.calls.voipphonecall)

voipphonecall.notifycallaccepted

### [<a name="windowsapplicationmodelcore"></a>windows.applicationmodel.core](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core)

#### [<a name="applistentry"></a>applistentry](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.applistentry)

applistentry.launchforuserasync

### [<a name="windowsapplicationmodelstorepreviewinstallcontrol"></a>windows.applicationmodel.store.preview.installcontrol](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol)

#### [<a name="appinstallitem"></a>appinstallitem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallitem)

appinstallitem.launchafterinstall

#### [<a name="appinstallmanager"></a>appinstallmanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallmanager)

appinstallmanager.getispackageidentityallowedtoinstallasync <br> appinstallmanager.getispackageidentityallowedtoinstallforuserasync <br> appinstallmanager.searchforallupdatesasync <br> appinstallmanager.searchforallupdatesforuserasync <br> appinstallmanager.searchforupdatesasync <br> appinstallmanager.searchforupdatesforuserasync <br> appinstallmanager.startproductinstallasync <br> appinstallmanager.startproductinstallforuserasync

#### [<a name="appinstalloptions"></a>appinstalloptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstalloptions)

appinstalloptions <br> appinstalloptions.allowforcedapprestart <br> appinstalloptions.appinstalloptions <br> appinstalloptions.catalogid <br> appinstalloptions.forceuseofnonremovablestorage <br> appinstalloptions.launchafterinstall <br> appinstalloptions.repair <br> appinstalloptions.targetvolume

#### [<a name="appinstallstatus"></a>appinstallstatus](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appinstallstatus)

appinstallstatus.isstaged

#### [<a name="appupdateoptions"></a>appupdateoptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.preview.installcontrol.appupdateoptions)

appupdateoptions <br> appupdateoptions.allowforcedapprestart <br> appupdateoptions.appupdateoptions <br> appupdateoptions.catalogid

### [<a name="windowsapplicationmodeluseractivities"></a>windows.applicationmodel.useractivities](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities)

#### [<a name="useractivity"></a>useractivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity)

useractivity.tojson <br> useractivity.tojsonarray <br> useractivity.tryparsefromjson <br> useractivity.tryparsefromjsonarray <br> useractivity.useractivity

#### [<a name="useractivitychannel"></a>useractivitychannel](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitychannel)

useractivitychannel.disableautosessioncreation <br> useractivitychannel.getrecentuseractivitiesasync <br> useractivitychannel.getsessionhistoryitemsforuseractivityasync <br> useractivitychannel.trygetforwebaccount

#### [<a name="useractivityrequest"></a>useractivityrequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequest)

useractivityrequest <br> useractivityrequest.setuseractivity

#### [<a name="useractivityrequestedeventargs"></a>useractivityrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequestedeventargs)

useractivityrequestedeventargs <br> useractivityrequestedeventargs.getdeferral <br> useractivityrequestedeventargs.request

#### [<a name="useractivityrequestmanager"></a>useractivityrequestmanager](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequestmanager)

useractivityrequestmanager <br> useractivityrequestmanager.useractivityrequested

#### [<a name="useractivitysessionhistoryitem"></a>useractivitysessionhistoryitem](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivitysessionhistoryitem)

useractivitysessionhistoryitem <br> useractivitysessionhistoryitem.endtime <br> useractivitysessionhistoryitem.starttime <br> useractivitysessionhistoryitem.useractivity

#### [<a name="useractivityvisualelements"></a>useractivityvisualelements](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityvisualelements)

useractivityvisualelements.attributiondisplaytext

### [<a name="windowsapplicationmodel"></a>windows.applicationmodel](https://docs.microsoft.com/uwp/api/windows.applicationmodel)

#### [<a name="addresourcepackageoptions"></a>addresourcepackageoptions](https://docs.microsoft.com/uwp/api/windows.applicationmodel.addresourcepackageoptions)

addresourcepackageoptions

#### [<a name="appinstance"></a>appinstance](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance)

appinstance <br> appinstance.findorregisterinstanceforkey <br> appinstance.getactivatedeventargs <br> appinstance.getinstances <br> appinstance.iscurrentinstance <br> appinstance.key <br> appinstance.recommendedinstance <br> appinstance.redirectactivationto <br> appinstance.unregister

#### [<a name="packagecatalog"></a>packagecatalog](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packagecatalog)

packagecatalog.addresourcepackageasync <br> packagecatalog.removeresourcepackagesasync

#### [<a name="packagecatalogaddresourcepackageresult"></a>packagecatalogaddresourcepackageresult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packagecatalogaddresourcepackageresult)

packagecatalogaddresourcepackageresult <br> packagecatalogaddresourcepackageresult.extendederror <br> packagecatalogaddresourcepackageresult.iscomplete <br> packagecatalogaddresourcepackageresult.package

#### [<a name="packagecatalogremoveresourcepackagesresult"></a>packagecatalogremoveresourcepackagesresult](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packagecatalogremoveresourcepackagesresult)

packagecatalogremoveresourcepackagesresult <br> packagecatalogremoveresourcepackagesresult.extendederror <br> packagecatalogremoveresourcepackagesresult.packagesremoved

#### [<a name="packageinstallprogress"></a>packageinstallprogress](https://docs.microsoft.com/uwp/api/windows.applicationmodel.packageinstallprogress)

packageinstallprogress

## <a name="windowsdevices"></a>windows.devices

### [<a name="windowsdevicesbluetooth"></a>windows.devices.bluetooth](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth)

#### [<a name="bluetoothadapter"></a>bluetoothadapter](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothadapter)

bluetoothadapter.areclassicsecureconnectionssupported <br> bluetoothadapter.arelowenergysecureconnectionssupported

#### [<a name="bluetoothdevice"></a>bluetoothdevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothdevice)

bluetoothdevice.wassecureconnectionusedforpairing

#### [<a name="bluetoothledevice"></a>bluetoothledevice](https://docs.microsoft.com/uwp/api/windows.devices.bluetooth.bluetoothledevice)

bluetoothledevice.wassecureconnectionusedforpairing

### [<a name="windowsdevicesdisplay"></a>windows.devices.display](https://docs.microsoft.com/uwp/api/windows.devices.display)

#### [<a name="displaymonitor"></a>displaymonitor](https://docs.microsoft.com/uwp/api/windows.devices.display.displaymonitor)

displaymonitor <br> displaymonitor.blueprimary <br> displaymonitor.connectionkind <br> displaymonitor.deviceid <br> displaymonitor.displayadapterdeviceid <br> displaymonitor.displayadapterid <br> displaymonitor.displayadaptertargetid <br> displaymonitor.displayname <br> displaymonitor.fromidasync <br> displaymonitor.frominterfaceidasync <br> displaymonitor.getdescriptor <br> displaymonitor.getdeviceselector <br> displaymonitor.greenprimary <br> displaymonitor.maxaveragefullframeluminanceinnits <br> displaymonitor.maxluminanceinnits <br> displaymonitor.minluminanceinnits <br> displaymonitor.nativeresolutioninrawpixels <br> displaymonitor.physicalconnector <br> displaymonitor.physicalsizeininches <br> displaymonitor.rawdpix <br> displaymonitor.rawdpiy <br> displaymonitor.redprimary <br> displaymonitor.usagekind <br> displaymonitor.whitepoint

#### [<a name="displaymonitorconnectionkind"></a>displaymonitorconnectionkind](https://docs.microsoft.com/uwp/api/windows.devices.display.displaymonitorconnectionkind)

displaymonitorconnectionkind

#### [<a name="displaymonitordescriptorkind"></a>displaymonitordescriptorkind](https://docs.microsoft.com/uwp/api/windows.devices.display.displaymonitordescriptorkind)

displaymonitordescriptorkind

#### [<a name="displaymonitorphysicalconnectorkind"></a>displaymonitorphysicalconnectorkind](https://docs.microsoft.com/uwp/api/windows.devices.display.displaymonitorphysicalconnectorkind)

displaymonitorphysicalconnectorkind

#### [<a name="displaymonitorusagekind"></a>displaymonitorusagekind](https://docs.microsoft.com/uwp/api/windows.devices.display.displaymonitorusagekind)

displaymonitorusagekind

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.devices.display.windows)

windows.devices.display

### [<a name="windowsdevicesinputpreview"></a>windows.devices.input.preview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview)

#### [<a name="gazedeviceconfigurationstatepreview"></a>gazedeviceconfigurationstatepreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedeviceconfigurationstatepreview)

gazedeviceconfigurationstatepreview

#### [<a name="gazedevicepreview"></a>gazedevicepreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicepreview)

gazedevicepreview <br> gazedevicepreview.cantrackeyes <br> gazedevicepreview.cantrackhead <br> gazedevicepreview.configurationstate <br> gazedevicepreview.getbooleancontroldescriptions <br> gazedevicepreview.getnumericcontroldescriptions <br> gazedevicepreview.id <br> gazedevicepreview.requestcalibrationasync

#### [<a name="gazedevicewatcheraddedprevieweventargs"></a>gazedevicewatcheraddedprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcheraddedprevieweventargs)

gazedevicewatcheraddedprevieweventargs <br> gazedevicewatcheraddedprevieweventargs.device

#### [<a name="gazedevicewatcherpreview"></a>gazedevicewatcherpreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherpreview)

gazedevicewatcherpreview <br> gazedevicewatcherpreview.added <br> gazedevicewatcherpreview.enumerationcompleted <br> gazedevicewatcherpreview.removed <br> gazedevicewatcherpreview.start <br> gazedevicewatcherpreview.stop <br> gazedevicewatcherpreview.updated

#### [<a name="gazedevicewatcherremovedprevieweventargs"></a>gazedevicewatcherremovedprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherremovedprevieweventargs)

gazedevicewatcherremovedprevieweventargs <br> gazedevicewatcherremovedprevieweventargs.device

#### [<a name="gazedevicewatcherupdatedprevieweventargs"></a>gazedevicewatcherupdatedprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazedevicewatcherupdatedprevieweventargs)

gazedevicewatcherupdatedprevieweventargs <br> gazedevicewatcherupdatedprevieweventargs.device

#### [<a name="gazeenteredprevieweventargs"></a>gazeenteredprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeenteredprevieweventargs)

gazeenteredprevieweventargs <br> gazeenteredprevieweventargs.currentpoint <br> gazeenteredprevieweventargs.handled

#### [<a name="gazeexitedprevieweventargs"></a>gazeexitedprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeexitedprevieweventargs)

gazeexitedprevieweventargs <br> gazeexitedprevieweventargs.currentpoint <br> gazeexitedprevieweventargs.handled

#### [<a name="gazeinputsourcepreview"></a>gazeinputsourcepreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazeinputsourcepreview)

gazeinputsourcepreview <br> gazeinputsourcepreview.createwatcher <br> gazeinputsourcepreview.gazeentered <br> gazeinputsourcepreview.gazeexited <br> gazeinputsourcepreview.gazemoved <br> gazeinputsourcepreview.getforcurrentview

#### [<a name="gazemovedprevieweventargs"></a>gazemovedprevieweventargs](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazemovedprevieweventargs)

gazemovedprevieweventargs <br> gazemovedprevieweventargs.currentpoint <br> gazemovedprevieweventargs.getintermediatepoints <br> gazemovedprevieweventargs.handled

#### [<a name="gazepointpreview"></a>gazepointpreview](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.gazepointpreview)

gazepointpreview <br> gazepointpreview.eyegazeposition <br> gazepointpreview.headgazeposition <br> gazepointpreview.hidinputreport <br> gazepointpreview.sourcedevice <br> gazepointpreview.timestamp

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.devices.input.preview.windows)

windows.devices.input.preview

### [<a name="windowsdevicespointofserviceprovider"></a>windows.devices.pointofservice.provider](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider)

#### [<a name="barcodescannerdisablescannerrequest"></a>barcodescannerdisablescannerrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerdisablescannerrequest)

barcodescannerdisablescannerrequest <br> barcodescannerdisablescannerrequest.reportcompletedasync <br> barcodescannerdisablescannerrequest.reportfailedasync

#### [<a name="barcodescannerdisablescannerrequesteventargs"></a>barcodescannerdisablescannerrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerdisablescannerrequesteventargs)

barcodescannerdisablescannerrequesteventargs <br> barcodescannerdisablescannerrequesteventargs.getdeferral <br> barcodescannerdisablescannerrequesteventargs.request

#### [<a name="barcodescannerenablescannerrequest"></a>barcodescannerenablescannerrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerenablescannerrequest)

barcodescannerenablescannerrequest <br> barcodescannerenablescannerrequest.reportcompletedasync <br> barcodescannerenablescannerrequest.reportfailedasync

#### [<a name="barcodescannerenablescannerrequesteventargs"></a>barcodescannerenablescannerrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerenablescannerrequesteventargs)

barcodescannerenablescannerrequesteventargs <br> barcodescannerenablescannerrequesteventargs.getdeferral <br> barcodescannerenablescannerrequesteventargs.request

#### [<a name="barcodescannergetsymbologyattributesrequest"></a>barcodescannergetsymbologyattributesrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannergetsymbologyattributesrequest)

barcodescannergetsymbologyattributesrequest <br> barcodescannergetsymbologyattributesrequest.reportcompletedasync <br> barcodescannergetsymbologyattributesrequest.reportfailedasync <br> barcodescannergetsymbologyattributesrequest.symbology

#### [<a name="barcodescannergetsymbologyattributesrequesteventargs"></a>barcodescannergetsymbologyattributesrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannergetsymbologyattributesrequesteventargs)

barcodescannergetsymbologyattributesrequesteventargs <br> barcodescannergetsymbologyattributesrequesteventargs.getdeferral <br> barcodescannergetsymbologyattributesrequesteventargs.request

#### [<a name="barcodescannerhidevideopreviewrequest"></a>barcodescannerhidevideopreviewrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerhidevideopreviewrequest)

barcodescannerhidevideopreviewrequest <br> barcodescannerhidevideopreviewrequest.reportcompletedasync <br> barcodescannerhidevideopreviewrequest.reportfailedasync

#### [<a name="barcodescannerhidevideopreviewrequesteventargs"></a>barcodescannerhidevideopreviewrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerhidevideopreviewrequesteventargs)

barcodescannerhidevideopreviewrequesteventargs <br> barcodescannerhidevideopreviewrequesteventargs.getdeferral <br> barcodescannerhidevideopreviewrequesteventargs.request

#### [<a name="barcodescannerproviderconnection"></a>barcodescannerproviderconnection](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerproviderconnection)

barcodescannerproviderconnection <br> barcodescannerproviderconnection.close <br> barcodescannerproviderconnection.companyname <br> barcodescannerproviderconnection.disablescannerrequested <br> barcodescannerproviderconnection.enablescannerrequested <br> barcodescannerproviderconnection.getbarcodesymbologyattributesrequested <br> barcodescannerproviderconnection.hidevideopreviewrequested <br> barcodescannerproviderconnection.id <br> barcodescannerproviderconnection.name <br> barcodescannerproviderconnection.reporterrorasync <br> barcodescannerproviderconnection.reporterrorasync <br> barcodescannerproviderconnection.reportscanneddataasync <br> barcodescannerproviderconnection.reporttriggerstateasync <br> barcodescannerproviderconnection.setactivesymbologiesrequested <br> barcodescannerproviderconnection.setbarcodesymbologyattributesrequested <br> barcodescannerproviderconnection.start <br> barcodescannerproviderconnection.startsoftwaretriggerrequested <br> barcodescannerproviderconnection.stopsoftwaretriggerrequested <br> barcodescannerproviderconnection.supportedsymbologies <br> barcodescannerproviderconnection.version <br> barcodescannerproviderconnection.videodeviceid

#### [<a name="barcodescannerprovidertriggerdetails"></a>barcodescannerprovidertriggerdetails](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerprovidertriggerdetails)

barcodescannerprovidertriggerdetails <br> barcodescannerprovidertriggerdetails.connection

#### [<a name="barcodescannersetactivesymbologiesrequest"></a>barcodescannersetactivesymbologiesrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetactivesymbologiesrequest)

barcodescannersetactivesymbologiesrequest <br> barcodescannersetactivesymbologiesrequest.reportcompletedasync <br> barcodescannersetactivesymbologiesrequest.reportfailedasync <br> barcodescannersetactivesymbologiesrequest.symbologies

#### [<a name="barcodescannersetactivesymbologiesrequesteventargs"></a>barcodescannersetactivesymbologiesrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetactivesymbologiesrequesteventargs)

barcodescannersetactivesymbologiesrequesteventargs <br> barcodescannersetactivesymbologiesrequesteventargs.getdeferral <br> barcodescannersetactivesymbologiesrequesteventargs.request

#### [<a name="barcodescannersetsymbologyattributesrequest"></a>barcodescannersetsymbologyattributesrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetsymbologyattributesrequest)

barcodescannersetsymbologyattributesrequest <br> barcodescannersetsymbologyattributesrequest.attributes <br> barcodescannersetsymbologyattributesrequest.reportcompletedasync <br> barcodescannersetsymbologyattributesrequest.reportfailedasync <br> barcodescannersetsymbologyattributesrequest.symbology

#### [<a name="barcodescannersetsymbologyattributesrequesteventargs"></a>barcodescannersetsymbologyattributesrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannersetsymbologyattributesrequesteventargs)

barcodescannersetsymbologyattributesrequesteventargs <br> barcodescannersetsymbologyattributesrequesteventargs.getdeferral <br> barcodescannersetsymbologyattributesrequesteventargs.request

#### [<a name="barcodescannerstartsoftwaretriggerrequest"></a>barcodescannerstartsoftwaretriggerrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstartsoftwaretriggerrequest)

barcodescannerstartsoftwaretriggerrequest <br> barcodescannerstartsoftwaretriggerrequest.reportcompletedasync <br> barcodescannerstartsoftwaretriggerrequest.reportfailedasync

#### [<a name="barcodescannerstartsoftwaretriggerrequesteventargs"></a>barcodescannerstartsoftwaretriggerrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstartsoftwaretriggerrequesteventargs)

barcodescannerstartsoftwaretriggerrequesteventargs <br> barcodescannerstartsoftwaretriggerrequesteventargs.getdeferral <br> barcodescannerstartsoftwaretriggerrequesteventargs.request

#### [<a name="barcodescannerstopsoftwaretriggerrequest"></a>barcodescannerstopsoftwaretriggerrequest](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstopsoftwaretriggerrequest)

barcodescannerstopsoftwaretriggerrequest <br> barcodescannerstopsoftwaretriggerrequest.reportcompletedasync <br> barcodescannerstopsoftwaretriggerrequest.reportfailedasync

#### [<a name="barcodescannerstopsoftwaretriggerrequesteventargs"></a>barcodescannerstopsoftwaretriggerrequesteventargs](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannerstopsoftwaretriggerrequesteventargs)

barcodescannerstopsoftwaretriggerrequesteventargs <br> barcodescannerstopsoftwaretriggerrequesteventargs.getdeferral <br> barcodescannerstopsoftwaretriggerrequesteventargs.request

#### [<a name="barcodescannertriggerstate"></a>barcodescannertriggerstate](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodescannertriggerstate)

barcodescannertriggerstate

#### [<a name="barcodesymbologyattributesbuilder"></a>barcodesymbologyattributesbuilder](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.barcodesymbologyattributesbuilder)

barcodesymbologyattributesbuilder <br> barcodesymbologyattributesbuilder.barcodesymbologyattributesbuilder <br> barcodesymbologyattributesbuilder.createattributes <br> barcodesymbologyattributesbuilder.ischeckdigittransmissionsupported <br> barcodesymbologyattributesbuilder.ischeckdigitvalidationsupported <br> barcodesymbologyattributesbuilder.isdecodelengthsupported

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.provider.windows)

windows.devices.pointofservice.provider

### [<a name="windowsdevicespointofservice"></a>windows.devices.pointofservice](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice)

#### [<a name="barcodescannerreport"></a>barcodescannerreport](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.barcodescannerreport)

barcodescannerreport.barcodescannerreport

#### [<a name="claimedbarcodescanner"></a>claimedbarcodescanner](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.claimedbarcodescanner)

claimedbarcodescanner.hidevideopreview <br> claimedbarcodescanner.isvideopreviewshownonenable <br> claimedbarcodescanner.showvideopreviewasync

#### [<a name="unifiedposerrordata"></a>unifiedposerrordata](https://docs.microsoft.com/uwp/api/windows.devices.pointofservice.unifiedposerrordata)

unifiedposerrordata.unifiedposerrordata

## <a name="windowsfoundation"></a>windows.foundation

### [<a name="windowsfoundationnumerics"></a>windows.foundation.numerics](https://docs.microsoft.com/uwp/api/windows.foundation.numerics)

#### [<a name="rational"></a>rational](https://docs.microsoft.com/uwp/api/windows.foundation.numerics.rational)

rational

## <a name="windowsglobalization"></a>windows.globalization

### [<a name="windowsglobalization"></a>windows.globalization](https://docs.microsoft.com/uwp/api/windows.globalization)

#### [<a name="applicationlanguages"></a>applicationlanguages](https://docs.microsoft.com/uwp/api/windows.globalization.applicationlanguages)

applicationlanguages.getlanguagesforuser

#### [<a name="language"></a>language](https://docs.microsoft.com/uwp/api/windows.globalization.language)

language.layoutdirection

#### [<a name="languagelayoutdirection"></a>languagelayoutdirection](https://docs.microsoft.com/uwp/api/windows.globalization.languagelayoutdirection)

languagelayoutdirection

## <a name="windowsgraphics"></a>windows.graphics

### [<a name="windowsgraphicscapture"></a>windows.graphics.capture](https://docs.microsoft.com/uwp/api/windows.graphics.capture)

#### [<a name="direct3d11captureframe"></a>direct3d11captureframe](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframe)

direct3d11captureframe <br> direct3d11captureframe.close <br> direct3d11captureframe.contentsize <br> direct3d11captureframe.surface <br> direct3d11captureframe.systemrelativetime

#### [<a name="direct3d11captureframepool"></a>direct3d11captureframepool](https://docs.microsoft.com/uwp/api/windows.graphics.capture.direct3d11captureframepool)

direct3d11captureframepool <br> direct3d11captureframepool.close <br> direct3d11captureframepool.create <br> direct3d11captureframepool.createcapturesession <br> direct3d11captureframepool.dispatcherqueue <br> direct3d11captureframepool.framearrived <br> direct3d11captureframepool.recreate <br> direct3d11captureframepool.trygetnextframe

#### [<a name="graphicscaptureitem"></a>graphicscaptureitem](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscaptureitem)

graphicscaptureitem <br> graphicscaptureitem.closed <br> graphicscaptureitem.displayname <br> graphicscaptureitem.size

#### [<a name="graphicscapturepicker"></a>graphicscapturepicker](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturepicker)

graphicscapturepicker <br> graphicscapturepicker.graphicscapturepicker <br> graphicscapturepicker.picksingleitemasync

#### [<a name="graphicscapturesession"></a>graphicscapturesession](https://docs.microsoft.com/uwp/api/windows.graphics.capture.graphicscapturesession)

graphicscapturesession <br> graphicscapturesession.close <br> graphicscapturesession.issupported <br> graphicscapturesession.startcapture

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.graphics.capture.windows)

windows.graphics.capture

### [<a name="windowsgraphicsdisplay"></a>windows.graphics.display](https://docs.microsoft.com/uwp/api/windows.graphics.display)

#### [<a name="advancedcolorinfo"></a>advancedcolorinfo](https://docs.microsoft.com/uwp/api/windows.graphics.display.advancedcolorinfo)

advancedcolorinfo <br> advancedcolorinfo.blueprimary <br> advancedcolorinfo.currentadvancedcolorkind <br> advancedcolorinfo.greenprimary <br> advancedcolorinfo.isadvancedcolorkindavailable <br> advancedcolorinfo.ishdrmetadataformatcurrentlysupported <br> advancedcolorinfo.maxaveragefullframeluminanceinnits <br> advancedcolorinfo.maxluminanceinnits <br> advancedcolorinfo.minluminanceinnits <br> advancedcolorinfo.redprimary <br> advancedcolorinfo.sdrwhitelevelinnits <br> advancedcolorinfo.whitepoint

#### [<a name="advancedcolorkind"></a>advancedcolorkind](https://docs.microsoft.com/uwp/api/windows.graphics.display.advancedcolorkind)

advancedcolorkind

#### [<a name="brightnessoverridesettings"></a>brightnessoverridesettings](https://docs.microsoft.com/uwp/api/windows.graphics.display.brightnessoverridesettings)

brightnessoverridesettings <br> brightnessoverridesettings.createfromdisplaybrightnessoverridescenario <br> brightnessoverridesettings.createfromlevel <br> brightnessoverridesettings.createfromnits <br> brightnessoverridesettings.desiredlevel <br> brightnessoverridesettings.desirednits

#### [<a name="coloroverridesettings"></a>coloroverridesettings](https://docs.microsoft.com/uwp/api/windows.graphics.display.coloroverridesettings)

coloroverridesettings <br> coloroverridesettings.createfromdisplaycoloroverridescenario <br> coloroverridesettings.desireddisplaycoloroverridescenario

#### [<a name="displaybrightnessoverridescenario"></a>displaybrightnessoverridescenario](https://docs.microsoft.com/uwp/api/windows.graphics.display.displaybrightnessoverridescenario)

displaybrightnessoverridescenario

#### [<a name="displaycoloroverridescenario"></a>displaycoloroverridescenario](https://docs.microsoft.com/uwp/api/windows.graphics.display.displaycoloroverridescenario)

displaycoloroverridescenario

#### [<a name="displayenhancementoverride"></a>displayenhancementoverride](https://docs.microsoft.com/uwp/api/windows.graphics.display.displayenhancementoverride)

displayenhancementoverride <br> displayenhancementoverride.brightnessoverridesettings <br> displayenhancementoverride.canoverride <br> displayenhancementoverride.canoverridechanged <br> displayenhancementoverride.coloroverridesettings <br> displayenhancementoverride.displayenhancementoverridecapabilitieschanged <br> displayenhancementoverride.getcurrentdisplayenhancementoverridecapabilities <br> displayenhancementoverride.getforcurrentview <br> displayenhancementoverride.isoverrideactive <br> displayenhancementoverride.isoverrideactivechanged <br> displayenhancementoverride.requestoverride <br> displayenhancementoverride.stopoverride

#### [<a name="displayenhancementoverridecapabilities"></a>displayenhancementoverridecapabilities](https://docs.microsoft.com/uwp/api/windows.graphics.display.displayenhancementoverridecapabilities)

displayenhancementoverridecapabilities <br> displayenhancementoverridecapabilities.getsupportednitranges <br> displayenhancementoverridecapabilities.isbrightnesscontrolsupported <br> displayenhancementoverridecapabilities.isbrightnessnitscontrolsupported

#### [<a name="displayenhancementoverridecapabilitieschangedeventargs"></a>displayenhancementoverridecapabilitieschangedeventargs](https://docs.microsoft.com/uwp/api/windows.graphics.display.displayenhancementoverridecapabilitieschangedeventargs)

displayenhancementoverridecapabilitieschangedeventargs <br> displayenhancementoverridecapabilitieschangedeventargs.capabilities

#### [<a name="displayinformation"></a>displayinformation](https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation)

displayinformation.advancedcolorinfochanged <br> displayinformation.getadvancedcolorinfo

#### [<a name="hdrmetadataformat"></a>hdrmetadataformat](https://docs.microsoft.com/uwp/api/windows.graphics.display.hdrmetadataformat)

hdrmetadataformat

#### [<a name="nitrange"></a>nitrange](https://docs.microsoft.com/uwp/api/windows.graphics.display.nitrange)

nitrange

### [<a name="windowsgraphicsholographic"></a>windows.graphics.holographic](https://docs.microsoft.com/uwp/api/windows.graphics.holographic)

#### [<a name="holographiccamera"></a>holographiccamera](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamera)

holographiccamera.canoverrideviewport

#### [<a name="holographiccamerapose"></a>holographiccamerapose](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographiccamerapose)

holographiccamerapose.overrideprojectiontransform <br> holographiccamerapose.overrideviewport <br> holographiccamerapose.overrideviewtransform

#### [<a name="holographicframepresentationmonitor"></a>holographicframepresentationmonitor](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicframepresentationmonitor)

holographicframepresentationmonitor <br> holographicframepresentationmonitor.close <br> holographicframepresentationmonitor.readreports

#### [<a name="holographicframepresentationreport"></a>holographicframepresentationreport](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicframepresentationreport)

holographicframepresentationreport <br> holographicframepresentationreport.appgpuduration <br> holographicframepresentationreport.appgpuoverrun <br> holographicframepresentationreport.compositorgpuduration <br> holographicframepresentationreport.missedpresentationopportunitycount <br> holographicframepresentationreport.presentationcount

#### [<a name="holographicspace"></a>holographicspace](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicspace)

holographicspace.createframepresentationmonitor <br> holographicspace.userpresence <br> holographicspace.userpresencechanged <br> holographicspace.waitfornextframeready <br> holographicspace.waitfornextframereadywithheadstart

#### [<a name="holographicspaceuserpresence"></a>holographicspaceuserpresence](https://docs.microsoft.com/uwp/api/windows.graphics.holographic.holographicspaceuserpresence)

holographicspaceuserpresence

### [<a name="windowsgraphicsprintingoptiondetails"></a>windows.graphics.printing.optiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails)

#### [<a name="printbindingoptiondetails"></a>printbindingoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printbindingoptiondetails)

printbindingoptiondetails.description <br> printbindingoptiondetails.warningtext

#### [<a name="printborderingoptiondetails"></a>printborderingoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printborderingoptiondetails)

printborderingoptiondetails.description <br> printborderingoptiondetails.warningtext

#### [<a name="printcollationoptiondetails"></a>printcollationoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcollationoptiondetails)

printcollationoptiondetails.description <br> printcollationoptiondetails.warningtext

#### [<a name="printcolormodeoptiondetails"></a>printcolormodeoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcolormodeoptiondetails)

printcolormodeoptiondetails.description <br> printcolormodeoptiondetails.warningtext

#### [<a name="printcopiesoptiondetails"></a>printcopiesoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcopiesoptiondetails)

printcopiesoptiondetails.description <br> printcopiesoptiondetails.warningtext

#### [<a name="printcustomitemlistoptiondetails"></a>printcustomitemlistoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcustomitemlistoptiondetails)

printcustomitemlistoptiondetails.additem <br> printcustomitemlistoptiondetails.description <br> printcustomitemlistoptiondetails.warningtext

#### [<a name="printcustomtextoptiondetails"></a>printcustomtextoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcustomtextoptiondetails)

printcustomtextoptiondetails.description <br> printcustomtextoptiondetails.warningtext

#### [<a name="printcustomtoggleoptiondetails"></a>printcustomtoggleoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printcustomtoggleoptiondetails)

printcustomtoggleoptiondetails <br> printcustomtoggleoptiondetails.description <br> printcustomtoggleoptiondetails.displayname <br> printcustomtoggleoptiondetails.errortext <br> printcustomtoggleoptiondetails.optionid <br> printcustomtoggleoptiondetails.optiontype <br> printcustomtoggleoptiondetails.state <br> printcustomtoggleoptiondetails.trysetvalue <br> printcustomtoggleoptiondetails.value <br> printcustomtoggleoptiondetails.warningtext

#### [<a name="printduplexoptiondetails"></a>printduplexoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printduplexoptiondetails)

printduplexoptiondetails.description <br> printduplexoptiondetails.warningtext

#### [<a name="printholepunchoptiondetails"></a>printholepunchoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printholepunchoptiondetails)

printholepunchoptiondetails.description <br> printholepunchoptiondetails.warningtext

#### [<a name="printmediasizeoptiondetails"></a>printmediasizeoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printmediasizeoptiondetails)

printmediasizeoptiondetails.description <br> printmediasizeoptiondetails.warningtext

#### [<a name="printmediatypeoptiondetails"></a>printmediatypeoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printmediatypeoptiondetails)

printmediatypeoptiondetails.description <br> printmediatypeoptiondetails.warningtext

#### [<a name="printorientationoptiondetails"></a>printorientationoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printorientationoptiondetails)

printorientationoptiondetails.description <br> printorientationoptiondetails.warningtext

#### [<a name="printpagerangeoptiondetails"></a>printpagerangeoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printpagerangeoptiondetails)

printpagerangeoptiondetails <br> printpagerangeoptiondetails.description <br> printpagerangeoptiondetails.errortext <br> printpagerangeoptiondetails.optionid <br> printpagerangeoptiondetails.optiontype <br> printpagerangeoptiondetails.state <br> printpagerangeoptiondetails.trysetvalue <br> printpagerangeoptiondetails.value <br> printpagerangeoptiondetails.warningtext

#### [<a name="printqualityoptiondetails"></a>printqualityoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printqualityoptiondetails)

printqualityoptiondetails.description <br> printqualityoptiondetails.warningtext

#### [<a name="printstapleoptiondetails"></a>printstapleoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printstapleoptiondetails)

printstapleoptiondetails.description <br> printstapleoptiondetails.warningtext

#### [<a name="printtaskoptiondetails"></a>printtaskoptiondetails](https://docs.microsoft.com/uwp/api/windows.graphics.printing.optiondetails.printtaskoptiondetails)

printtaskoptiondetails.createtoggleoption

### [<a name="windowsgraphicsprinting"></a>windows.graphics.printing](https://docs.microsoft.com/uwp/api/windows.graphics.printing)

#### [<a name="printpagerange"></a>printpagerange](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printpagerange)

printpagerange <br> printpagerange.firstpagenumber <br> printpagerange.lastpagenumber <br> printpagerange.printpagerange <br> printpagerange.printpagerange

#### [<a name="printpagerangeoptions"></a>printpagerangeoptions](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printpagerangeoptions)

printpagerangeoptions <br> printpagerangeoptions.allowallpages <br> printpagerangeoptions.allowcurrentpage <br> printpagerangeoptions.allowcustomsetofpages

#### [<a name="printtaskoptions"></a>printtaskoptions](https://docs.microsoft.com/uwp/api/windows.graphics.printing.printtaskoptions)

printtaskoptions.custompageranges <br> printtaskoptions.pagerangeoptions

#### [<a name="standardprinttaskoptions"></a>standardprinttaskoptions](https://docs.microsoft.com/uwp/api/windows.graphics.printing.standardprinttaskoptions)

standardprinttaskoptions.custompageranges

## <a name="windowsmanagement"></a>windows.management

### [<a name="windowsmanagementdeployment"></a>windows.management.deployment](https://docs.microsoft.com/uwp/api/windows.management.deployment)

#### [<a name="packagemanager"></a>packagemanager](https://docs.microsoft.com/uwp/api/windows.management.deployment.packagemanager)

packagemanager.requestaddpackageasync

### [<a name="windowsmanagementupdate"></a>windows.management.update](https://docs.microsoft.com/uwp/api/windows.management.update)

#### [<a name="previewbuildsmanager"></a>previewbuildsmanager](https://docs.microsoft.com/uwp/api/windows.management.update.previewbuildsmanager)

previewbuildsmanager <br> previewbuildsmanager.arepreviewbuildsallowed <br> previewbuildsmanager.getcurrentstate <br> previewbuildsmanager.getdefault <br> previewbuildsmanager.issupported <br> previewbuildsmanager.syncasync

#### [<a name="previewbuildsstate"></a>previewbuildsstate](https://docs.microsoft.com/uwp/api/windows.management.update.previewbuildsstate)

previewbuildsstate <br> previewbuildsstate.properties

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.management.update.windows)

windows.management.update

## <a name="windowsmedia"></a>windows.media

### [<a name="windowsmediaaudio"></a>windows.media.audio](https://docs.microsoft.com/uwp/api/windows.media.audio)

#### [<a name="audiograph"></a>audiograph](https://docs.microsoft.com/uwp/api/windows.media.audio.audiograph)

audiograph.createmediasourceaudioinputnodeasync <br> audiograph.createmediasourceaudioinputnodeasync

#### [<a name="audiographsettings"></a>audiographsettings](https://docs.microsoft.com/uwp/api/windows.media.audio.audiographsettings)

audiographsettings.maxplaybackspeedfactor

#### [<a name="audiostatemonitor"></a>audiostatemonitor](https://docs.microsoft.com/uwp/api/windows.media.audio.audiostatemonitor)

audiostatemonitor <br> audiostatemonitor.createforcapturemonitoring <br> audiostatemonitor.createforcapturemonitoring <br> audiostatemonitor.createforcapturemonitoring <br> audiostatemonitor.createforcapturemonitoringwithcategoryanddeviceid <br> audiostatemonitor.createforrendermonitoring <br> audiostatemonitor.createforrendermonitoring <br> audiostatemonitor.createforrendermonitoring <br> audiostatemonitor.createforrendermonitoringwithcategoryanddeviceid <br> audiostatemonitor.soundlevel <br> audiostatemonitor.soundlevelchanged

#### [<a name="createmediasourceaudioinputnoderesult"></a>createmediasourceaudioinputnoderesult](https://docs.microsoft.com/uwp/api/windows.media.audio.createmediasourceaudioinputnoderesult)

createmediasourceaudioinputnoderesult <br> createmediasourceaudioinputnoderesult.node <br> createmediasourceaudioinputnoderesult.status

#### [<a name="mediasourceaudioinputnode"></a>mediasourceaudioinputnode](https://docs.microsoft.com/uwp/api/windows.media.audio.mediasourceaudioinputnode)

mediasourceaudioinputnode <br> mediasourceaudioinputnode.addoutgoingconnection <br> mediasourceaudioinputnode.addoutgoingconnection <br> mediasourceaudioinputnode.close <br> mediasourceaudioinputnode.consumeinput <br> mediasourceaudioinputnode.disableeffectsbydefinition <br> mediasourceaudioinputnode.duration <br> mediasourceaudioinputnode.effectdefinitions <br> mediasourceaudioinputnode.emitter <br> mediasourceaudioinputnode.enableeffectsbydefinition <br> mediasourceaudioinputnode.encodingproperties <br> mediasourceaudioinputnode.endtime <br> mediasourceaudioinputnode.loopcount <br> mediasourceaudioinputnode.mediasource <br> mediasourceaudioinputnode.mediasourcecompleted <br> mediasourceaudioinputnode.outgoingconnections <br> mediasourceaudioinputnode.outgoinggain <br> mediasourceaudioinputnode.playbackspeedfactor <br> mediasourceaudioinputnode.position <br> mediasourceaudioinputnode.removeoutgoingconnection <br> mediasourceaudioinputnode.reset <br> mediasourceaudioinputnode.seek <br> mediasourceaudioinputnode.start <br> mediasourceaudioinputnode.starttime <br> mediasourceaudioinputnode.stop

#### [<a name="mediasourceaudioinputnodecreationstatus"></a>mediasourceaudioinputnodecreationstatus](https://docs.microsoft.com/uwp/api/windows.media.audio.mediasourceaudioinputnodecreationstatus)

mediasourceaudioinputnodecreationstatus

### [<a name="windowsmediacaptureframes"></a>windows.media.capture.frames](https://docs.microsoft.com/uwp/api/windows.media.capture.frames)

#### [<a name="audiomediaframe"></a>audiomediaframe](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.audiomediaframe)

audiomediaframe <br> audiomediaframe.audioencodingproperties <br> audiomediaframe.framereference <br> audiomediaframe.getaudioframe

#### [<a name="mediaframeformat"></a>mediaframeformat](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframeformat)

mediaframeformat.audioencodingproperties

#### [<a name="mediaframereference"></a>mediaframereference](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframereference)

mediaframereference.audiomediaframe

#### [<a name="mediaframesourcecontroller"></a>mediaframesourcecontroller](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourcecontroller)

mediaframesourcecontroller.audiodevicecontroller

#### [<a name="mediaframesourceinfo"></a>mediaframesourceinfo](https://docs.microsoft.com/uwp/api/windows.media.capture.frames.mediaframesourceinfo)

mediaframesourceinfo.profileid <br> mediaframesourceinfo.videoprofilemediadescription

### [<a name="windowsmediacapture"></a>windows.media.capture](https://docs.microsoft.com/uwp/api/windows.media.capture)

#### [<a name="capturedframe"></a>capturedframe](https://docs.microsoft.com/uwp/api/windows.media.capture.capturedframe)

capturedframe.bitmapproperties <br> capturedframe.controlvalues

#### [<a name="mediacapturesettings"></a>mediacapturesettings](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapturesettings)

mediacapturesettings.direct3d11device

#### [<a name="mediacapturevideoprofile"></a>mediacapturevideoprofile](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapturevideoprofile)

mediacapturevideoprofile.framesourceinfos <br> mediacapturevideoprofile.properties

#### [<a name="mediacapturevideoprofilemediadescription"></a>mediacapturevideoprofilemediadescription](https://docs.microsoft.com/uwp/api/windows.media.capture.mediacapturevideoprofilemediadescription)

mediacapturevideoprofilemediadescription.properties <br> mediacapturevideoprofilemediadescription.subtype

### [<a name="windowsmediacore"></a>windows.media.core](https://docs.microsoft.com/uwp/api/windows.media.core)

#### [<a name="audiostreamdescriptor"></a>audiostreamdescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.audiostreamdescriptor)

audiostreamdescriptor.copy

#### [<a name="mediabindingeventargs"></a>mediabindingeventargs](https://docs.microsoft.com/uwp/api/windows.media.core.mediabindingeventargs)

mediabindingeventargs.setdownloadoperation

#### [<a name="mediasource"></a>mediasource](https://docs.microsoft.com/uwp/api/windows.media.core.mediasource)

mediasource.createfromdownloadoperation <br> mediasource.downloadoperation

#### [<a name="timedmetadatastreamdescriptor"></a>timedmetadatastreamdescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.timedmetadatastreamdescriptor)

timedmetadatastreamdescriptor <br> timedmetadatastreamdescriptor.copy <br> timedmetadatastreamdescriptor.encodingproperties <br> timedmetadatastreamdescriptor.isselected <br> timedmetadatastreamdescriptor.label <br> timedmetadatastreamdescriptor.language <br> timedmetadatastreamdescriptor.name <br> timedmetadatastreamdescriptor.timedmetadatastreamdescriptor

#### [<a name="videostreamdescriptor"></a>videostreamdescriptor](https://docs.microsoft.com/uwp/api/windows.media.core.videostreamdescriptor)

videostreamdescriptor.copy

### [<a name="windowsmediadevices"></a>windows.media.devices](https://docs.microsoft.com/uwp/api/windows.media.devices)

#### [<a name="videodevicecontroller"></a>videodevicecontroller](https://docs.microsoft.com/uwp/api/windows.media.devices.videodevicecontroller)

videodevicecontroller.videotemporaldenoisingcontrol

#### [<a name="videotemporaldenoisingcontrol"></a>videotemporaldenoisingcontrol](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingcontrol)

videotemporaldenoisingcontrol <br> videotemporaldenoisingcontrol.mode <br> videotemporaldenoisingcontrol.supported <br> videotemporaldenoisingcontrol.supportedmodes

#### [<a name="videotemporaldenoisingmode"></a>videotemporaldenoisingmode](https://docs.microsoft.com/uwp/api/windows.media.devices.videotemporaldenoisingmode)

videotemporaldenoisingmode

### [<a name="windowsmediadialprotocol"></a>windows.media.dialprotocol](https://docs.microsoft.com/uwp/api/windows.media.dialprotocol)

#### [<a name="dialreceiverapp"></a>dialreceiverapp](https://docs.microsoft.com/uwp/api/windows.media.dialprotocol.dialreceiverapp)

dialreceiverapp.getuniquedevicenameasync

### [<a name="windowsmediaeffects"></a>windows.media.effects](https://docs.microsoft.com/uwp/api/windows.media.effects)

#### [<a name="videotransformeffectdefinition"></a>videotransformeffectdefinition](https://docs.microsoft.com/uwp/api/windows.media.effects.videotransformeffectdefinition)

videotransformeffectdefinition.sphericalprojection

#### [<a name="videotransformsphericalprojection"></a>videotransformsphericalprojection](https://docs.microsoft.com/uwp/api/windows.media.effects.videotransformsphericalprojection)

videotransformsphericalprojection <br> videotransformsphericalprojection.frameformat <br> videotransformsphericalprojection.horizontalfieldofviewindegrees <br> videotransformsphericalprojection.isenabled <br> videotransformsphericalprojection.projectionmode <br> videotransformsphericalprojection.vieworientation

### [<a name="windowsmediamediaproperties"></a>windows.media.mediaproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties)

#### [<a name="audioencodingproperties"></a>audioencodingproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.audioencodingproperties)

audioencodingproperties.copy

#### [<a name="containerencodingproperties"></a>containerencodingproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.containerencodingproperties)

containerencodingproperties.copy

#### [<a name="imageencodingproperties"></a>imageencodingproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.imageencodingproperties)

imageencodingproperties.copy

#### [<a name="mediaencodingprofile"></a>mediaencodingprofile](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingprofile)

mediaencodingprofile.gettimedmetadatatracks <br> mediaencodingprofile.settimedmetadatatracks

#### [<a name="mediaencodingsubtypes"></a>mediaencodingsubtypes](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.mediaencodingsubtypes)

mediaencodingsubtypes.p010

#### [<a name="timedmetadataencodingproperties"></a>timedmetadataencodingproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.timedmetadataencodingproperties)

timedmetadataencodingproperties <br> timedmetadataencodingproperties.copy <br> timedmetadataencodingproperties.getformatuserdata <br> timedmetadataencodingproperties.properties <br> timedmetadataencodingproperties.setformatuserdata <br> timedmetadataencodingproperties.subtype <br> timedmetadataencodingproperties.timedmetadataencodingproperties <br> timedmetadataencodingproperties.type

#### [<a name="videoencodingproperties"></a>videoencodingproperties](https://docs.microsoft.com/uwp/api/windows.media.mediaproperties.videoencodingproperties)

videoencodingproperties.copy

### [<a name="windowsmediaplayback"></a>windows.media.playback](https://docs.microsoft.com/uwp/api/windows.media.playback)

#### [<a name="mediaplaybacksession"></a>mediaplaybacksession](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksession)

mediaplaybacksession.getoutputdegradationpolicystate <br> mediaplaybacksession.playbackrotation

#### [<a name="mediaplaybacksessionoutputdegradationpolicystate"></a>mediaplaybacksessionoutputdegradationpolicystate](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionoutputdegradationpolicystate)

mediaplaybacksessionoutputdegradationpolicystate <br> mediaplaybacksessionoutputdegradationpolicystate.videoconstrictionreason

#### [<a name="mediaplaybacksessionvideoconstrictionreason"></a>mediaplaybacksessionvideoconstrictionreason](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplaybacksessionvideoconstrictionreason)

mediaplaybacksessionvideoconstrictionreason

#### [<a name="mediaplayer"></a>mediaplayer](https://docs.microsoft.com/uwp/api/windows.media.playback.mediaplayer)

mediaplayer.audiostatemonitor

### [<a name="windowsmediaspeechsynthesis"></a>windows.media.speechsynthesis](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis)

#### [<a name="speechappendedsilence"></a>speechappendedsilence](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechappendedsilence)

speechappendedsilence

#### [<a name="speechpunctuationsilence"></a>speechpunctuationsilence](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechpunctuationsilence)

speechpunctuationsilence

#### [<a name="speechsynthesizeroptions"></a>speechsynthesizeroptions](https://docs.microsoft.com/uwp/api/windows.media.speechsynthesis.speechsynthesizeroptions)

speechsynthesizeroptions.appendedsilence <br> speechsynthesizeroptions.punctuationsilence

### [<a name="windowsmediastreamingadaptive"></a>windows.media.streaming.adaptive](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive)

#### [<a name="adaptivemediasourcediagnosticavailableeventargs"></a>adaptivemediasourcediagnosticavailableeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcediagnosticavailableeventargs)

adaptivemediasourcediagnosticavailableeventargs.resourcecontenttype <br> adaptivemediasourcediagnosticavailableeventargs.resourceduration

#### [<a name="adaptivemediasourcedownloadcompletedeventargs"></a>adaptivemediasourcedownloadcompletedeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcedownloadcompletedeventargs)

adaptivemediasourcedownloadcompletedeventargs.resourcecontenttype <br> adaptivemediasourcedownloadcompletedeventargs.resourceduration

#### [<a name="adaptivemediasourcedownloadfailedeventargs"></a>adaptivemediasourcedownloadfailedeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcedownloadfailedeventargs)

adaptivemediasourcedownloadfailedeventargs.resourcecontenttype <br> adaptivemediasourcedownloadfailedeventargs.resourceduration

#### [<a name="adaptivemediasourcedownloadrequestedeventargs"></a>adaptivemediasourcedownloadrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.media.streaming.adaptive.adaptivemediasourcedownloadrequestedeventargs)

adaptivemediasourcedownloadrequestedeventargs.resourcecontenttype <br> adaptivemediasourcedownloadrequestedeventargs.resourceduration

### [<a name="windowsmedia"></a>windows.media](https://docs.microsoft.com/uwp/api/windows.media)

#### [<a name="videoframe"></a>videoframe](https://docs.microsoft.com/uwp/api/windows.media.videoframe)

videoframe.copytoasync <br> videoframe.createasdirect3d11surfacebacked <br> videoframe.createasdirect3d11surfacebacked <br> videoframe.createwithdirect3d11surface <br> videoframe.createwithsoftwarebitmap

## <a name="windowsnetworking"></a>windows.networking

### [<a name="windowsnetworkingbackgroundtransfer"></a>windows.networking.backgroundtransfer](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer)

#### [<a name="downloadoperation"></a>downloadoperation](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer.downloadoperation)

downloadoperation.makecurrentintransfergroup

#### [<a name="uploadoperation"></a>uploadoperation](https://docs.microsoft.com/uwp/api/windows.networking.backgroundtransfer.uploadoperation)

uploadoperation.makecurrentintransfergroup

### [<a name="windowsnetworkingconnectivity"></a>windows.networking.connectivity](https://docs.microsoft.com/uwp/api/windows.networking.connectivity)

#### [<a name="cellularapncontext"></a>cellularapncontext](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.cellularapncontext)

cellularapncontext.profilename

#### [<a name="connectionprofilefilter"></a>connectionprofilefilter](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.connectionprofilefilter)

connectionprofilefilter.purposeguid

#### [<a name="wwanconnectionprofiledetails"></a>wwanconnectionprofiledetails](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.wwanconnectionprofiledetails)

wwanconnectionprofiledetails.ipkind <br> wwanconnectionprofiledetails.purposeguids

#### [<a name="wwannetworkipkind"></a>wwannetworkipkind](https://docs.microsoft.com/uwp/api/windows.networking.connectivity.wwannetworkipkind)

wwannetworkipkind

### [<a name="windowsnetworkingnetworkoperators"></a>windows.networking.networkoperators](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators)

#### [<a name="esim"></a>esim](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esim)

esim <br> esim.availablememoryinbytes <br> esim.deleteprofileasync <br> esim.downloadprofilemetadataasync <br> esim.eid <br> esim.firmwareversion <br> esim.getprofiles <br> esim.mobilebroadbandmodemdeviceid <br> esim.policy <br> esim.profilechanged <br> esim.resetasync <br> esim.state

#### [<a name="esimaddedeventargs"></a>esimaddedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimaddedeventargs)

esimaddedeventargs <br> esimaddedeventargs.esim

#### [<a name="esimauthenticationpreference"></a>esimauthenticationpreference](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimauthenticationpreference)

esimauthenticationpreference

#### [<a name="esimdownloadprofilemetadataresult"></a>esimdownloadprofilemetadataresult](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimdownloadprofilemetadataresult)

esimdownloadprofilemetadataresult <br> esimdownloadprofilemetadataresult.profilemetadata <br> esimdownloadprofilemetadataresult.result

#### [<a name="esimmanager"></a>esimmanager](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimmanager)

esimmanager <br> esimmanager.serviceinfo <br> esimmanager.serviceinfochanged <br> esimmanager.trycreateesimwatcher

#### [<a name="esimoperationresult"></a>esimoperationresult](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimoperationresult)

esimoperationresult <br> esimoperationresult.status

#### [<a name="esimoperationstatus"></a>esimoperationstatus](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimoperationstatus)

esimoperationstatus

#### [<a name="esimpolicy"></a>esimpolicy](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimpolicy)

esimpolicy <br> esimpolicy.shouldenablemanagingui

#### [<a name="esimprofile"></a>esimprofile](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofile)

esimprofile <br> esimprofile.class <br> esimprofile.disableasync <br> esimprofile.enableasync <br> esimprofile.id <br> esimprofile.nickname <br> esimprofile.policy <br> esimprofile.providericon <br> esimprofile.providerid <br> esimprofile.providername <br> esimprofile.setnicknameasync <br> esimprofile.state

#### [<a name="esimprofileclass"></a>esimprofileclass](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofileclass)

esimprofileclass

#### [<a name="esimprofileinstallprogress"></a>esimprofileinstallprogress](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofileinstallprogress)

esimprofileinstallprogress

#### [<a name="esimprofilemetadata"></a>esimprofilemetadata](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofilemetadata)

esimprofilemetadata <br> esimprofilemetadata.confirminstallasync <br> esimprofilemetadata.confirminstallasync <br> esimprofilemetadata.denyinstallasync <br> esimprofilemetadata.id <br> esimprofilemetadata.isconfirmationcoderequired <br> esimprofilemetadata.policy <br> esimprofilemetadata.postponeinstallasync <br> esimprofilemetadata.providericon <br> esimprofilemetadata.providerid <br> esimprofilemetadata.providername <br> esimprofilemetadata.state <br> esimprofilemetadata.statechanged

#### [<a name="esimprofilemetadatastate"></a>esimprofilemetadatastate](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofilemetadatastate)

esimprofilemetadatastate

#### [<a name="esimprofilepolicy"></a>esimprofilepolicy](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofilepolicy)

esimprofilepolicy <br> esimprofilepolicy.candelete <br> esimprofilepolicy.candisable <br> esimprofilepolicy.ismanagedbyenterprise

#### [<a name="esimprofilestate"></a>esimprofilestate](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimprofilestate)

esimprofilestate

#### [<a name="esimremovedeventargs"></a>esimremovedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimremovedeventargs)

esimremovedeventargs <br> esimremovedeventargs.esim

#### [<a name="esimserviceinfo"></a>esimserviceinfo](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimserviceinfo)

esimserviceinfo <br> esimserviceinfo.authenticationpreference <br> esimserviceinfo.isesimuienabled

#### [<a name="esimstate"></a>esimstate](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimstate)

esimstate

#### [<a name="esimupdatedeventargs"></a>esimupdatedeventargs](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimupdatedeventargs)

esimupdatedeventargs <br> esimupdatedeventargs.esim

#### [<a name="esimwatcher"></a>esimwatcher](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimwatcher)

esimwatcher <br> esimwatcher.added <br> esimwatcher.enumerationcompleted <br> esimwatcher.removed <br> esimwatcher.start <br> esimwatcher.status <br> esimwatcher.stop <br> esimwatcher.stopped <br> esimwatcher.updated

#### [<a name="esimwatcherstatus"></a>esimwatcherstatus](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.esimwatcherstatus)

esimwatcherstatus

#### [<a name="mobilebroadbandantennasar"></a>mobilebroadbandantennasar](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandantennasar)

mobilebroadbandantennasar.mobilebroadbandantennasar

#### [<a name="mobilebroadbandmodem"></a>mobilebroadbandmodem](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandmodem)

mobilebroadbandmodem.isinemergencycallmode <br> mobilebroadbandmodem.isinemergencycallmodechanged <br> mobilebroadbandmodem.trygetpcoasync

#### [<a name="mobilebroadbandmodemisolation"></a>mobilebroadbandmodemisolation](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandmodemisolation)

mobilebroadbandmodemisolation <br> mobilebroadbandmodemisolation.addallowedhost <br> mobilebroadbandmodemisolation.addallowedhostrange <br> mobilebroadbandmodemisolation.applyconfigurationasync <br> mobilebroadbandmodemisolation.clearconfigurationasync <br> mobilebroadbandmodemisolation.mobilebroadbandmodemisolation

#### [<a name="mobilebroadbandpco"></a>mobilebroadbandpco](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandpco)

mobilebroadbandpco <br> mobilebroadbandpco.data <br> mobilebroadbandpco.deviceid <br> mobilebroadbandpco.iscomplete

#### [<a name="mobilebroadbandpcodatachangetriggerdetails"></a>mobilebroadbandpcodatachangetriggerdetails](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.mobilebroadbandpcodatachangetriggerdetails)

mobilebroadbandpcodatachangetriggerdetails <br> mobilebroadbandpcodatachangetriggerdetails.updateddata

#### [<a name="networkoperatordatausagenotificationkind"></a>networkoperatordatausagenotificationkind](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.networkoperatordatausagenotificationkind)

networkoperatordatausagenotificationkind

#### [<a name="networkoperatordatausagetriggerdetails"></a>networkoperatordatausagetriggerdetails](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.networkoperatordatausagetriggerdetails)

networkoperatordatausagetriggerdetails <br> networkoperatordatausagetriggerdetails.notificationkind

#### [<a name="tetheringentitlementchecktriggerdetails"></a>tetheringentitlementchecktriggerdetails](https://docs.microsoft.com/uwp/api/windows.networking.networkoperators.tetheringentitlementchecktriggerdetails)

tetheringentitlementchecktriggerdetails <br> tetheringentitlementchecktriggerdetails.allowtethering <br> tetheringentitlementchecktriggerdetails.denytethering <br> tetheringentitlementchecktriggerdetails.networkaccountid

### [<a name="windowsnetworkingsockets"></a>windows.networking.sockets](https://docs.microsoft.com/uwp/api/windows.networking.sockets)

#### [<a name="messagewebsocket"></a>messagewebsocket](https://docs.microsoft.com/uwp/api/windows.networking.sockets.messagewebsocket)

messagewebsocket.sendfinalframeasync <br> messagewebsocket.sendnonfinalframeasync

#### [<a name="servermessagewebsocket"></a>servermessagewebsocket](https://docs.microsoft.com/uwp/api/windows.networking.sockets.servermessagewebsocket)

servermessagewebsocket <br> servermessagewebsocket.close <br> servermessagewebsocket.close <br> servermessagewebsocket.closed <br> servermessagewebsocket.control <br> servermessagewebsocket.information <br> servermessagewebsocket.messagereceived <br> servermessagewebsocket.outputstream

#### [<a name="servermessagewebsocketcontrol"></a>servermessagewebsocketcontrol](https://docs.microsoft.com/uwp/api/windows.networking.sockets.servermessagewebsocketcontrol)

servermessagewebsocketcontrol <br> servermessagewebsocketcontrol.messagetype

#### [<a name="servermessagewebsocketinformation"></a>servermessagewebsocketinformation](https://docs.microsoft.com/uwp/api/windows.networking.sockets.servermessagewebsocketinformation)

servermessagewebsocketinformation <br> servermessagewebsocketinformation.bandwidthstatistics <br> servermessagewebsocketinformation.localaddress <br> servermessagewebsocketinformation.protocol

#### [<a name="serverstreamwebsocket"></a>serverstreamwebsocket](https://docs.microsoft.com/uwp/api/windows.networking.sockets.serverstreamwebsocket)

serverstreamwebsocket <br> serverstreamwebsocket.close <br> serverstreamwebsocket.close <br> serverstreamwebsocket.closed <br> serverstreamwebsocket.information <br> serverstreamwebsocket.inputstream <br> serverstreamwebsocket.outputstream

#### [<a name="serverstreamwebsocketinformation"></a>serverstreamwebsocketinformation](https://docs.microsoft.com/uwp/api/windows.networking.sockets.serverstreamwebsocketinformation)

serverstreamwebsocketinformation <br> serverstreamwebsocketinformation.bandwidthstatistics <br> serverstreamwebsocketinformation.localaddress <br> serverstreamwebsocketinformation.protocol

### [<a name="windowsnetworkingvpn"></a>windows.networking.vpn](https://docs.microsoft.com/uwp/api/windows.networking.vpn)

#### [<a name="vpnchannel"></a>vpnchannel](https://docs.microsoft.com/uwp/api/windows.networking.vpn.vpnchannel)

vpnchannel.addandassociatetransport <br> vpnchannel.currentrequesttransportcontext <br> vpnchannel.getslottypefortransportcontext <br> vpnchannel.replaceandassociatetransport <br> vpnchannel.startreconnectingtransport <br> vpnchannel.startwithtrafficfilter

#### [<a name="vpnpacketbuffer"></a>vpnpacketbuffer](https://docs.microsoft.com/uwp/api/windows.networking.vpn.vpnpacketbuffer)

vpnpacketbuffer.transportcontext

## <a name="windowsphone"></a>windows.phone

### [<a name="windowsphonenetworkingvoip"></a>windows.phone.networking.voip](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip)

#### [<a name="voipcallcoordinator"></a>voipcallcoordinator](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip.voipcallcoordinator)

voipcallcoordinator.requestnewappinitiatedcall <br> voipcallcoordinator.requestnewincomingcall

#### [<a name="voipphonecall"></a>voipphonecall](https://docs.microsoft.com/uwp/api/windows.phone.networking.voip.voipphonecall)

voipphonecall.notifycallaccepted

## <a name="windowssecurity"></a>windows.security

### [<a name="windowssecurityauthenticationwebcore"></a>windows.security.authentication.web.core](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core)

#### [<a name="findallaccountsresult"></a>findallaccountsresult](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.findallaccountsresult)

findallaccountsresult <br> findallaccountsresult.accounts <br> findallaccountsresult.providererror <br> findallaccountsresult.status

#### [<a name="findallwebaccountsstatus"></a>findallwebaccountsstatus](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.findallwebaccountsstatus)

findallwebaccountsstatus

#### [<a name="webauthenticationcoremanager"></a>webauthenticationcoremanager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager)

webauthenticationcoremanager.findallaccountsasync <br> webauthenticationcoremanager.findallaccountsasync <br> webauthenticationcoremanager.findsystemaccountproviderasync <br> webauthenticationcoremanager.findsystemaccountproviderasync <br> webauthenticationcoremanager.findsystemaccountproviderasync

### [<a name="windowssecurityauthenticationwebprovider"></a>windows.security.authentication.web.provider](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider)

#### [<a name="webprovidertokenrequest"></a>webprovidertokenrequest](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.provider.webprovidertokenrequest)

webprovidertokenrequest.applicationpackagefamilyname <br> webprovidertokenrequest.applicationprocessname <br> webprovidertokenrequest.checkapplicationforcapabilityasync

### [<a name="windowssecuritycredentials"></a>windows.security.credentials](https://docs.microsoft.com/uwp/api/windows.security.credentials)

#### [<a name="webaccountprovider"></a>webaccountprovider](https://docs.microsoft.com/uwp/api/windows.security.credentials.webaccountprovider)

webaccountprovider.issystemprovider

## <a name="windowsservices"></a>windows.services

### [<a name="windowsservicesmaps"></a>windows.services.maps](https://docs.microsoft.com/uwp/api/windows.services.maps)

#### [<a name="maproutedrivingoptions"></a>maproutedrivingoptions](https://docs.microsoft.com/uwp/api/windows.services.maps.maproutedrivingoptions)

maproutedrivingoptions.departuretime

#### [<a name="placeinfo"></a>placeinfo](https://docs.microsoft.com/uwp/api/windows.services.maps.placeinfo)

placeinfo.createfromaddress <br> placeinfo.createfromaddress

### [<a name="windowsservicesstore"></a>windows.services.store](https://docs.microsoft.com/uwp/api/windows.services.store)

#### [<a name="storecanacquirelicenseresult"></a>storecanacquirelicenseresult](https://docs.microsoft.com/uwp/api/windows.services.store.storecanacquirelicenseresult)

storecanacquirelicenseresult <br> storecanacquirelicenseresult.extendederror <br> storecanacquirelicenseresult.licensablesku <br> storecanacquirelicenseresult.status

#### [<a name="storecanlicensestatus"></a>storecanlicensestatus](https://docs.microsoft.com/uwp/api/windows.services.store.storecanlicensestatus)

storecanlicensestatus

#### [<a name="storecontext"></a>storecontext](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext)

storecontext.canacquirestorelicenseasync <br> storecontext.canacquirestorelicenseforoptionalpackageasync <br> storecontext.cansilentlydownloadstorepackageupdates <br> storecontext.downloadandinstallstorepackagesasync <br> storecontext.getassociatedstorequeueitemsasync <br> storecontext.getstoreproductsasync <br> storecontext.getstorequeueitemsasync <br> storecontext.requestdownloadandinstallstorepackagesasync <br> storecontext.requestuninstallstorepackageasync <br> storecontext.requestuninstallstorepackagebystoreidasync <br> storecontext.trysilentdownloadandinstallstorepackageupdatesasync <br> storecontext.trysilentdownloadstorepackageupdatesasync <br> storecontext.uninstallstorepackageasync <br> storecontext.uninstallstorepackagebystoreidasync

#### [<a name="storepackageinstalloptions"></a>storepackageinstalloptions](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageinstalloptions)

storepackageinstalloptions <br> storepackageinstalloptions.allowforcedapprestart <br> storepackageinstalloptions.storepackageinstalloptions

#### [<a name="storepackageupdateresult"></a>storepackageupdateresult](https://docs.microsoft.com/uwp/api/windows.services.store.storepackageupdateresult)

storepackageupdateresult.storequeueitems

#### [<a name="storeproductoptions"></a>storeproductoptions](https://docs.microsoft.com/uwp/api/windows.services.store.storeproductoptions)

storeproductoptions <br> storeproductoptions.actionfilters <br> storeproductoptions.storeproductoptions

#### [<a name="storequeueitem"></a>storequeueitem](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitem)

storequeueitem <br> storequeueitem.completed <br> storequeueitem.getcurrentstatus <br> storequeueitem.installkind <br> storequeueitem.packagefamilyname <br> storequeueitem.productid <br> storequeueitem.statuschanged

#### [<a name="storequeueitemcompletedeventargs"></a>storequeueitemcompletedeventargs](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitemcompletedeventargs)

storequeueitemcompletedeventargs <br> storequeueitemcompletedeventargs.status

#### [<a name="storequeueitemextendedstate"></a>storequeueitemextendedstate](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitemextendedstate)

storequeueitemextendedstate

#### [<a name="storequeueitemkind"></a>storequeueitemkind](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitemkind)

storequeueitemkind

#### [<a name="storequeueitemstate"></a>storequeueitemstate](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitemstate)

storequeueitemstate

#### [<a name="storequeueitemstatus"></a>storequeueitemstatus](https://docs.microsoft.com/uwp/api/windows.services.store.storequeueitemstatus)

storequeueitemstatus <br> storequeueitemstatus.extendederror <br> storequeueitemstatus.packageinstallextendedstate <br> storequeueitemstatus.packageinstallstate <br> storequeueitemstatus.updatestatus

#### [<a name="storeuninstallstorepackageresult"></a>storeuninstallstorepackageresult](https://docs.microsoft.com/uwp/api/windows.services.store.storeuninstallstorepackageresult)

storeuninstallstorepackageresult <br> storeuninstallstorepackageresult.extendederror <br> storeuninstallstorepackageresult.status

#### [<a name="storeuninstallstorepackagestatus"></a>storeuninstallstorepackagestatus](https://docs.microsoft.com/uwp/api/windows.services.store.storeuninstallstorepackagestatus)

storeuninstallstorepackagestatus

## <a name="windowsstorage"></a>windows.storage

### [<a name="windowsstoragefileproperties"></a>windows.storage.fileproperties](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties)

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.storage.fileproperties.windows)

windows.storage.fileproperties

### [<a name="windowsstorageprovider"></a>windows.storage.provider](https://docs.microsoft.com/uwp/api/windows.storage.provider)

#### [<a name="istorageproviderurisource"></a>istorageproviderurisource](https://docs.microsoft.com/uwp/api/windows.storage.provider.istorageproviderurisource)

istorageproviderurisource.getcontentinfoforpath <br> istorageproviderurisource.getpathforcontenturi

#### [<a name="storageprovidergetcontentinfoforpathresult"></a>storageprovidergetcontentinfoforpathresult](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidergetcontentinfoforpathresult)

storageprovidergetcontentinfoforpathresult <br> storageprovidergetcontentinfoforpathresult.contentid <br> storageprovidergetcontentinfoforpathresult.contenturi <br> storageprovidergetcontentinfoforpathresult.status <br> storageprovidergetcontentinfoforpathresult.storageprovidergetcontentinfoforpathresult

#### [<a name="storageprovidergetpathforcontenturiresult"></a>storageprovidergetpathforcontenturiresult](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidergetpathforcontenturiresult)

storageprovidergetpathforcontenturiresult <br> storageprovidergetpathforcontenturiresult.path <br> storageprovidergetpathforcontenturiresult.status <br> storageprovidergetpathforcontenturiresult.storageprovidergetpathforcontenturiresult

#### [<a name="storageproviderhardlinkpolicy"></a>storageproviderhardlinkpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderhardlinkpolicy)

storageproviderhardlinkpolicy

#### [<a name="storageproviderhydrationpolicy"></a>storageproviderhydrationpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderhydrationpolicy)

storageproviderhydrationpolicy

#### [<a name="storageproviderhydrationpolicymodifier"></a>storageproviderhydrationpolicymodifier](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderhydrationpolicymodifier)

storageproviderhydrationpolicymodifier

#### [<a name="storageproviderinsyncpolicy"></a>storageproviderinsyncpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderinsyncpolicy)

storageproviderinsyncpolicy

#### [<a name="storageproviderpopulationpolicy"></a>storageproviderpopulationpolicy](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderpopulationpolicy)

storageproviderpopulationpolicy

#### [<a name="storageproviderprotectionmode"></a>storageproviderprotectionmode](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderprotectionmode)

storageproviderprotectionmode

#### [<a name="storageprovidersyncrootinfo"></a>storageprovidersyncrootinfo](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageprovidersyncrootinfo)

storageprovidersyncrootinfo.hardlinkpolicy

#### [<a name="storageproviderurisourcestatus"></a>storageproviderurisourcestatus](https://docs.microsoft.com/uwp/api/windows.storage.provider.storageproviderurisourcestatus)

storageproviderurisourcestatus

### [<a name="windowsstoragesearch"></a>windows.storage.search](https://docs.microsoft.com/uwp/api/windows.storage.search)

#### [<a name="storagelibrarychangetrackertriggerdetails"></a>storagelibrarychangetrackertriggerdetails](https://docs.microsoft.com/uwp/api/windows.storage.search.storagelibrarychangetrackertriggerdetails)

storagelibrarychangetrackertriggerdetails <br> storagelibrarychangetrackertriggerdetails.changetracker <br> storagelibrarychangetrackertriggerdetails.folder

### [<a name="windowsstorage"></a>windows.storage](https://docs.microsoft.com/uwp/api/windows.storage)

#### [<a name="storagefolder"></a>storagefolder](https://docs.microsoft.com/uwp/api/windows.storage.storagefolder)

storagefolder.trygetchangetracker

## <a name="windowssystem"></a>windows.system

### [<a name="windowssystemdiagnosticsdeviceportal"></a>windows.system.diagnostics.deviceportal](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.deviceportal)

#### [<a name="deviceportalconnection"></a>deviceportalconnection](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnection)

deviceportalconnection.getservermessagewebsocketforrequest <br> deviceportalconnection.getservermessagewebsocketforrequest <br> deviceportalconnection.getservermessagewebsocketforrequest <br> deviceportalconnection.getserverstreamwebsocketforrequest <br> deviceportalconnection.getserverstreamwebsocketforrequest

#### [<a name="deviceportalconnectionrequestreceivedeventargs"></a>deviceportalconnectionrequestreceivedeventargs](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.deviceportal.deviceportalconnectionrequestreceivedeventargs)

deviceportalconnectionrequestreceivedeventargs.getdeferral <br> deviceportalconnectionrequestreceivedeventargs.iswebsocketupgraderequest <br> deviceportalconnectionrequestreceivedeventargs.websocketprotocolsrequested

### [<a name="windowssystemdiagnostics"></a>windows.system.diagnostics](https://docs.microsoft.com/uwp/api/windows.system.diagnostics)

#### [<a name="diagnosticinvoker"></a>diagnosticinvoker](https://docs.microsoft.com/uwp/api/windows.system.diagnostics.diagnosticinvoker)

diagnosticinvoker.rundiagnosticactionfromstringasync

### [<a name="windowssysteminventory"></a>windows.system.inventory](https://docs.microsoft.com/uwp/api/windows.system.inventory)

#### [<a name="installeddesktopapp"></a>installeddesktopapp](https://docs.microsoft.com/uwp/api/windows.system.inventory.installeddesktopapp)

installeddesktopapp <br> installeddesktopapp.displayname <br> installeddesktopapp.displayversion <br> installeddesktopapp.getinventoryasync <br> installeddesktopapp.id <br> installeddesktopapp.publisher <br> installeddesktopapp.tostring

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.system.inventory.windows)

windows.system.inventory

### [<a name="windowssystemprofile"></a>windows.system.profile](https://docs.microsoft.com/uwp/api/windows.system.profile)

#### [<a name="analyticsinfo"></a>analyticsinfo](https://docs.microsoft.com/uwp/api/windows.system.profile.analyticsinfo)

analyticsinfo.getsystempropertiesasync

### [<a name="windowssystemremotesystems"></a>windows.system.remotesystems](https://docs.microsoft.com/uwp/api/windows.system.remotesystems)

#### [<a name="remotesystem"></a>remotesystem](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystem)

remotesystem.platform

#### [<a name="remotesystemenumerationcompletedeventargs"></a>remotesystemenumerationcompletedeventargs](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemenumerationcompletedeventargs)

remotesystemenumerationcompletedeventargs

#### [<a name="remotesystemplatform"></a>remotesystemplatform](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemplatform)

remotesystemplatform

#### [<a name="remotesystemwatcher"></a>remotesystemwatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemwatcher)

remotesystemwatcher.enumerationcompleted

#### [<a name="remotesystemwatchererror"></a>remotesystemwatchererror](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemwatchererror)

remotesystemwatchererror

### [<a name="windowssystemuserprofile"></a>windows.system.userprofile](https://docs.microsoft.com/uwp/api/windows.system.userprofile)

#### [<a name="globalizationpreferences"></a>globalizationpreferences](https://docs.microsoft.com/uwp/api/windows.system.userprofile.globalizationpreferences)

globalizationpreferences.getforuser

#### [<a name="globalizationpreferencesforuser"></a>globalizationpreferencesforuser](https://docs.microsoft.com/uwp/api/windows.system.userprofile.globalizationpreferencesforuser)

globalizationpreferencesforuser <br> globalizationpreferencesforuser.calendars <br> globalizationpreferencesforuser.clocks <br> globalizationpreferencesforuser.currencies <br> globalizationpreferencesforuser.homegeographicregion <br> globalizationpreferencesforuser.languages <br> globalizationpreferencesforuser.user <br> globalizationpreferencesforuser.weekstartson

### [<a name="windowssystem"></a>windows.system](https://docs.microsoft.com/uwp/api/windows.system)

#### [<a name="appactivationresult"></a>appactivationresult](https://docs.microsoft.com/uwp/api/windows.system.appactivationresult)

appactivationresult <br> appactivationresult.appresourcegroupinfo <br> appactivationresult.extendederror

#### [<a name="appdiagnosticinfo"></a>appdiagnosticinfo](https://docs.microsoft.com/uwp/api/windows.system.appdiagnosticinfo)

appdiagnosticinfo.launchasync

#### [<a name="appexecutionstatechangeresult"></a>appexecutionstatechangeresult](https://docs.microsoft.com/uwp/api/windows.system.appexecutionstatechangeresult)

appexecutionstatechangeresult <br> appexecutionstatechangeresult.extendederror

#### [<a name="appresourcegroupinfo"></a>appresourcegroupinfo](https://docs.microsoft.com/uwp/api/windows.system.appresourcegroupinfo)

appresourcegroupinfo.startresumeasync <br> appresourcegroupinfo.startsuspendasync <br> appresourcegroupinfo.startterminateasync

#### [<a name="autoupdatetimezonestatus"></a>autoupdatetimezonestatus](https://docs.microsoft.com/uwp/api/windows.system.autoupdatetimezonestatus)

autoupdatetimezonestatus

#### [<a name="timezonesettings"></a>timezonesettings](https://docs.microsoft.com/uwp/api/windows.system.timezonesettings)

timezonesettings.autoupdatetimezoneasync

## <a name="windowsui"></a>windows.ui

### [<a name="windowsuicompositioncore"></a>windows.ui.composition.core](https://docs.microsoft.com/uwp/api/windows.ui.composition.core)

#### [<a name="compositorcontroller"></a>compositorcontroller](https://docs.microsoft.com/uwp/api/windows.ui.composition.core.compositorcontroller)

compositorcontroller <br> compositorcontroller.close <br> compositorcontroller.commit <br> compositorcontroller.commitneeded <br> compositorcontroller.compositor <br> compositorcontroller.compositorcontroller <br> compositorcontroller.ensurepreviouscommitcompletedasync

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.ui.composition.core.windows)

windows.ui.composition.core

### [<a name="windowsuicompositiondesktop"></a>windows.ui.composition.desktop](https://docs.microsoft.com/uwp/api/windows.ui.composition.desktop)

#### [<a name="desktopwindowtarget"></a>desktopwindowtarget](https://docs.microsoft.com/uwp/api/windows.ui.composition.desktop.desktopwindowtarget)

desktopwindowtarget <br> desktopwindowtarget.istopmost

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.ui.composition.desktop.windows)

windows.ui.composition.desktop

### [<a name="windowsuicompositiondiagnostics"></a>windows.ui.composition.diagnostics](https://docs.microsoft.com/uwp/api/windows.ui.composition.diagnostics)

#### [<a name="compositiondebugheatmaps"></a>compositiondebugheatmaps](https://docs.microsoft.com/uwp/api/windows.ui.composition.diagnostics.compositiondebugheatmaps)

compositiondebugheatmaps <br> compositiondebugheatmaps.showmemoryusage <br> compositiondebugheatmaps.showoverdraw

#### [<a name="compositiondebugoverdrawcontentkinds"></a>compositiondebugoverdrawcontentkinds](https://docs.microsoft.com/uwp/api/windows.ui.composition.diagnostics.compositiondebugoverdrawcontentkinds)

compositiondebugoverdrawcontentkinds

#### [<a name="compositiondebugsettings"></a>compositiondebugsettings](https://docs.microsoft.com/uwp/api/windows.ui.composition.diagnostics.compositiondebugsettings)

compositiondebugsettings <br> compositiondebugsettings.heatmaps <br> compositiondebugsettings.trygetsettings

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.ui.composition.diagnostics.windows)

windows.ui.composition.diagnostics

### [<a name="windowsuicomposition"></a>windows.ui.composition](https://docs.microsoft.com/uwp/api/windows.ui.composition)

#### [<a name="animationcontroller"></a>animationcontroller](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationcontroller)

animationcontroller <br> animationcontroller.maxplaybackrate <br> animationcontroller.minplaybackrate <br> animationcontroller.pause <br> animationcontroller.playbackrate <br> animationcontroller.progress <br> animationcontroller.progressbehavior <br> animationcontroller.resume

#### [<a name="animationcontrollerprogressbehavior"></a>animationcontrollerprogressbehavior](https://docs.microsoft.com/uwp/api/windows.ui.composition.animationcontrollerprogressbehavior)

animationcontrollerprogressbehavior

#### [<a name="bouncescalarnaturalmotionanimation"></a>bouncescalarnaturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.bouncescalarnaturalmotionanimation)

bouncescalarnaturalmotionanimation <br> bouncescalarnaturalmotionanimation.acceleration <br> bouncescalarnaturalmotionanimation.restitution

#### [<a name="bouncevector2naturalmotionanimation"></a>bouncevector2naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.bouncevector2naturalmotionanimation)

bouncevector2naturalmotionanimation <br> bouncevector2naturalmotionanimation.acceleration <br> bouncevector2naturalmotionanimation.restitution

#### [<a name="bouncevector3naturalmotionanimation"></a>bouncevector3naturalmotionanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.bouncevector3naturalmotionanimation)

bouncevector3naturalmotionanimation <br> bouncevector3naturalmotionanimation.acceleration <br> bouncevector3naturalmotionanimation.restitution

#### [<a name="compositioncontainershape"></a>compositioncontainershape](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncontainershape)

compositioncontainershape <br> compositioncontainershape.shapes

#### [<a name="compositionellipsegeometry"></a>compositionellipsegeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionellipsegeometry)

compositionellipsegeometry <br> compositionellipsegeometry.center <br> compositionellipsegeometry.radius

#### [<a name="compositiongeometry"></a>compositiongeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositiongeometry)

compositiongeometry <br> compositiongeometry.trimend <br> compositiongeometry.trimoffset <br> compositiongeometry.trimstart

#### [<a name="compositionlight"></a>compositionlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)

compositionlight.isenabled

#### [<a name="compositionlinegeometry"></a>compositionlinegeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlinegeometry)

compositionlinegeometry <br> compositionlinegeometry.end <br> compositionlinegeometry.start

#### [<a name="compositionobject"></a>compositionobject](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionobject)

compositionobject.trygetanimationcontroller

#### [<a name="compositionpath"></a>compositionpath](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionpath)

compositionpath <br> compositionpath.compositionpath

#### [<a name="compositionpathgeometry"></a>compositionpathgeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionpathgeometry)

compositionpathgeometry <br> compositionpathgeometry.path

#### [<a name="compositionrectanglegeometry"></a>compositionrectanglegeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionrectanglegeometry)

compositionrectanglegeometry <br> compositionrectanglegeometry.offset <br> compositionrectanglegeometry.size

#### [<a name="compositionroundedrectanglegeometry"></a>compositionroundedrectanglegeometry](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionroundedrectanglegeometry)

compositionroundedrectanglegeometry <br> compositionroundedrectanglegeometry.cornerradius <br> compositionroundedrectanglegeometry.offset <br> compositionroundedrectanglegeometry.size

#### [<a name="compositionshape"></a>compositionshape](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionshape)

compositionshape <br> compositionshape.centerpoint <br> compositionshape.offset <br> compositionshape.rotationangle <br> compositionshape.rotationangleindegrees <br> compositionshape.scale <br> compositionshape.transformmatrix

#### [<a name="compositionshapecollection"></a>compositionshapecollection](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionshapecollection)

compositionshapecollection <br> compositionshapecollection.append <br> compositionshapecollection.clear <br> compositionshapecollection.first <br> compositionshapecollection.getat <br> compositionshapecollection.getmany <br> compositionshapecollection.getview <br> compositionshapecollection.indexof <br> compositionshapecollection.insertat <br> compositionshapecollection.removeat <br> compositionshapecollection.removeatend <br> compositionshapecollection.replaceall <br> compositionshapecollection.setat <br> compositionshapecollection.size

#### [<a name="compositionspriteshape"></a>compositionspriteshape](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionspriteshape)

compositionspriteshape <br> compositionspriteshape.fillbrush <br> compositionspriteshape.geometry <br> compositionspriteshape.isstrokenonscaling <br> compositionspriteshape.strokebrush <br> compositionspriteshape.strokedasharray <br> compositionspriteshape.strokedashcap <br> compositionspriteshape.strokedashoffset <br> compositionspriteshape.strokeendcap <br> compositionspriteshape.strokelinejoin <br> compositionspriteshape.strokemiterlimit <br> compositionspriteshape.strokestartcap <br> compositionspriteshape.strokethickness

#### [<a name="compositionstrokecap"></a>compositionstrokecap](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionstrokecap)

compositionstrokecap

#### [<a name="compositionstrokedasharray"></a>compositionstrokedasharray](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionstrokedasharray)

compositionstrokedasharray <br> compositionstrokedasharray.append <br> compositionstrokedasharray.clear <br> compositionstrokedasharray.first <br> compositionstrokedasharray.getat <br> compositionstrokedasharray.getmany <br> compositionstrokedasharray.getview <br> compositionstrokedasharray.indexof <br> compositionstrokedasharray.insertat <br> compositionstrokedasharray.removeat <br> compositionstrokedasharray.removeatend <br> compositionstrokedasharray.replaceall <br> compositionstrokedasharray.setat <br> compositionstrokedasharray.size

#### [<a name="compositionstrokelinejoin"></a>compositionstrokelinejoin](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionstrokelinejoin)

compositionstrokelinejoin

#### [<a name="compositionviewbox"></a>compositionviewbox](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionviewbox)

compositionviewbox <br> compositionviewbox.horizontalalignmentratio <br> compositionviewbox.offset <br> compositionviewbox.size <br> compositionviewbox.stretch <br> compositionviewbox.verticalalignmentratio

#### [<a name="compositor"></a>compositor](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositor)

compositor.comment <br> compositor.createbouncescalaranimation <br> compositor.createbouncevector2animation <br> compositor.createbouncevector3animation <br> compositor.createcontainershape <br> compositor.createellipsegeometry <br> compositor.createlinegeometry <br> compositor.createpathgeometry <br> compositor.createpathgeometry <br> compositor.createpathkeyframeanimation <br> compositor.createrectanglegeometry <br> compositor.createroundedrectanglegeometry <br> compositor.createshapevisual <br> compositor.createspriteshape <br> compositor.createspriteshape <br> compositor.createviewbox <br> compositor.globalplaybackrate <br> compositor.maxglobalplaybackrate <br> compositor.minglobalplaybackrate <br> compositor.requestcommitasync

#### [<a name="pathkeyframeanimation"></a>pathkeyframeanimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.pathkeyframeanimation)

pathkeyframeanimation <br> pathkeyframeanimation.insertkeyframe <br> pathkeyframeanimation.insertkeyframe

#### [<a name="pointlight"></a>pointlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.pointlight)

pointlight.maxattenuationcutoff <br> pointlight.minattenuationcutoff

#### [<a name="shapevisual"></a>shapevisual](https://docs.microsoft.com/uwp/api/windows.ui.composition.shapevisual)

shapevisual <br> shapevisual.shapes <br> shapevisual.viewbox

#### [<a name="spotlight"></a>spotlight](https://docs.microsoft.com/uwp/api/windows.ui.composition.spotlight)

spotlight.maxattenuationcutoff <br> spotlight.minattenuationcutoff

### [<a name="windowsuicore"></a>windows.ui.core](https://docs.microsoft.com/uwp/api/windows.ui.core)

#### [<a name="corecomponentinputsource"></a>corecomponentinputsource](https://docs.microsoft.com/uwp/api/windows.ui.core.corecomponentinputsource)

corecomponentinputsource.dispatcherqueue

#### [<a name="coreindependentinputsource"></a>coreindependentinputsource](https://docs.microsoft.com/uwp/api/windows.ui.core.coreindependentinputsource)

coreindependentinputsource.dispatcherqueue

#### [<a name="icorepointerinputsource2"></a>icorepointerinputsource2](https://docs.microsoft.com/uwp/api/windows.ui.core.icorepointerinputsource2)

icorepointerinputsource2 <br> icorepointerinputsource2.dispatcherqueue

### [<a name="windowsuiinputcore"></a>windows.ui.input.core](https://docs.microsoft.com/uwp/api/windows.ui.input.core)

#### [<a name="radialcontrollerindependentinputsource"></a>radialcontrollerindependentinputsource](https://docs.microsoft.com/uwp/api/windows.ui.input.core.radialcontrollerindependentinputsource)

radialcontrollerindependentinputsource.dispatcherqueue

### [<a name="windowsuiinputinking"></a>windows.ui.input.inking](https://docs.microsoft.com/uwp/api/windows.ui.input.inking)

#### [<a name="inkdrawingattributes"></a>inkdrawingattributes](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkdrawingattributes)

inkdrawingattributes.modelerattributes

#### [<a name="inkinputconfiguration"></a>inkinputconfiguration](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkinputconfiguration)

inkinputconfiguration <br> inkinputconfiguration.iseraserinputenabled <br> inkinputconfiguration.isprimarybarrelbuttoninputenabled

#### [<a name="inkmodelerattributes"></a>inkmodelerattributes](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkmodelerattributes)

inkmodelerattributes <br> inkmodelerattributes.predictiontime <br> inkmodelerattributes.scalingfactor

#### [<a name="inkpresenter"></a>inkpresenter](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter)

inkpresenter.inputconfiguration

### [<a name="windowsuiinputspatial"></a>windows.ui.input.spatial](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial)

#### [<a name="spatialinteractioncontroller"></a>spatialinteractioncontroller](https://docs.microsoft.com/uwp/api/windows.ui.input.spatial.spatialinteractioncontroller)

spatialinteractioncontroller.trygetbatteryreport

### [<a name="windowsuinotifications"></a>windows.ui.notifications](https://docs.microsoft.com/uwp/api/windows.ui.notifications)

#### [<a name="scheduledtoastnotification"></a>scheduledtoastnotification](https://docs.microsoft.com/uwp/api/windows.ui.notifications.scheduledtoastnotification)

scheduledtoastnotification.expirationtime

### [<a name="windowsuitext"></a>windows.ui.text](https://docs.microsoft.com/uwp/api/windows.ui.text)

#### [<a name="contentlinkinfo"></a>contentlinkinfo](https://docs.microsoft.com/uwp/api/windows.ui.text.contentlinkinfo)

contentlinkinfo <br> contentlinkinfo.contentlinkinfo <br> contentlinkinfo.displaytext <br> contentlinkinfo.id <br> contentlinkinfo.linkcontentkind <br> contentlinkinfo.secondarytext <br> contentlinkinfo.uri

#### [<a name="richedittextrange"></a>richedittextrange](https://docs.microsoft.com/uwp/api/windows.ui.text.richedittextrange)

richedittextrange <br> richedittextrange.canpaste <br> richedittextrange.changecase <br> richedittextrange.character <br> richedittextrange.characterformat <br> richedittextrange.collapse <br> richedittextrange.contentlinkinfo <br> richedittextrange.copy <br> richedittextrange.cut <br> richedittextrange.delete <br> richedittextrange.endof <br> richedittextrange.endposition <br> richedittextrange.expand <br> richedittextrange.findtext <br> richedittextrange.formattedtext <br> richedittextrange.getcharacterutf32 <br> richedittextrange.getclone <br> richedittextrange.getindex <br> richedittextrange.getpoint <br> richedittextrange.getrect <br> richedittextrange.gettext <br> richedittextrange.gettextviastream <br> richedittextrange.gravity <br> richedittextrange.inrange <br> richedittextrange.insertimage <br> richedittextrange.instory <br> richedittextrange.isequal <br> richedittextrange.length <br> richedittextrange.link <br> richedittextrange.matchselection <br> richedittextrange.move <br> richedittextrange.moveend <br> richedittextrange.movestart <br> richedittextrange.paragraphformat <br> richedittextrange.paste <br> richedittextrange.scrollintoview <br> richedittextrange.setindex <br> richedittextrange.setpoint <br> richedittextrange.setrange <br> richedittextrange.settext <br> richedittextrange.settextviastream <br> richedittextrange.startof <br> richedittextrange.startposition <br> richedittextrange.storylength <br> richedittextrange.text

### [<a name="windowsuiviewmanagementcore"></a>windows.ui.viewmanagement.core](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core)

#### [<a name="coreinputview"></a>coreinputview](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputview)

coreinputview.trytransferxyfocustoprimaryview <br> coreinputview.xyfocustransferredtoprimaryview <br> coreinputview.xyfocustransferringfromprimaryview

#### [<a name="coreinputviewtransferringxyfocuseventargs"></a>coreinputviewtransferringxyfocuseventargs](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewtransferringxyfocuseventargs)

coreinputviewtransferringxyfocuseventargs <br> coreinputviewtransferringxyfocuseventargs.direction <br> coreinputviewtransferringxyfocuseventargs.keepprimaryviewvisible <br> coreinputviewtransferringxyfocuseventargs.origin <br> coreinputviewtransferringxyfocuseventargs.transferhandled

#### [<a name="coreinputviewxyfocustransferdirection"></a>coreinputviewxyfocustransferdirection](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.core.coreinputviewxyfocustransferdirection)

coreinputviewxyfocustransferdirection

### [<a name="windowsuiwebui"></a>windows.ui.webui](https://docs.microsoft.com/uwp/api/windows.ui.webui)

#### [<a name="webuistartuptaskactivatedeventargs"></a>webuistartuptaskactivatedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.webui.webuistartuptaskactivatedeventargs)

webuistartuptaskactivatedeventargs.activatedoperation

### [<a name="windowsuixamlautomationpeers"></a>windows.ui.xaml.automation.peers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers)

#### [<a name="automationheadinglevel"></a>automationheadinglevel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationheadinglevel)

automationheadinglevel

#### [<a name="automationpeer"></a>automationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.automationpeer)

automationpeer.getheadinglevel <br> automationpeer.getheadinglevelcore

#### [<a name="autosuggestboxautomationpeer"></a>autosuggestboxautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.autosuggestboxautomationpeer)

autosuggestboxautomationpeer.invoke

#### [<a name="calendardatepickerautomationpeer"></a>calendardatepickerautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.calendardatepickerautomationpeer)

calendardatepickerautomationpeer <br> calendardatepickerautomationpeer.calendardatepickerautomationpeer <br> calendardatepickerautomationpeer.invoke <br> calendardatepickerautomationpeer.isreadonly <br> calendardatepickerautomationpeer.setvalue <br> calendardatepickerautomationpeer.value

#### [<a name="treeviewitemautomationpeer"></a>treeviewitemautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.treeviewitemautomationpeer)

treeviewitemautomationpeer <br> treeviewitemautomationpeer.collapse <br> treeviewitemautomationpeer.expand <br> treeviewitemautomationpeer.expandcollapsestate <br> treeviewitemautomationpeer.treeviewitemautomationpeer

#### [<a name="treeviewlistautomationpeer"></a>treeviewlistautomationpeer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.peers.treeviewlistautomationpeer)

treeviewlistautomationpeer <br> treeviewlistautomationpeer.treeviewlistautomationpeer

### [<a name="windowsuixamlautomation"></a>windows.ui.xaml.automation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation)

#### [<a name="automationelementidentifiers"></a>automationelementidentifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationelementidentifiers)

automationelementidentifiers.headinglevelproperty

#### [<a name="automationproperties"></a>automationproperties](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties)

automationproperties.getheadinglevel <br> automationproperties.headinglevelproperty <br> automationproperties.setheadinglevel

### [<a name="windowsuixamlcontrolsmaps"></a>windows.ui.xaml.controls.maps](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps)

#### [<a name="mapcontrol"></a>mapcontrol](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapcontrol)

mapcontrol.region <br> mapcontrol.regionproperty

#### [<a name="mapelement"></a>mapelement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.maps.mapelement)

mapelement.isenabled <br> mapelement.isenabledproperty

### [<a name="windowsuixamlcontrolsprimitives"></a>windows.ui.xaml.controls.primitives](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives)

#### [<a name="appbarbuttontemplatesettings"></a>appbarbuttontemplatesettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.appbarbuttontemplatesettings)

appbarbuttontemplatesettings <br> appbarbuttontemplatesettings.keyboardacceleratortextminwidth

#### [<a name="appbartogglebuttontemplatesettings"></a>appbartogglebuttontemplatesettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.appbartogglebuttontemplatesettings)

appbartogglebuttontemplatesettings <br> appbartogglebuttontemplatesettings.keyboardacceleratortextminwidth

#### [<a name="menuflyoutitemtemplatesettings"></a>menuflyoutitemtemplatesettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.menuflyoutitemtemplatesettings)

menuflyoutitemtemplatesettings <br> menuflyoutitemtemplatesettings.keyboardacceleratortextminwidth

### [<a name="windowsuixamlcontrols"></a>windows.ui.xaml.controls](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls)

#### [<a name="appbarbutton"></a>appbarbutton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)

appbarbutton.keyboardacceleratortextoverride <br> appbarbutton.keyboardacceleratortextoverrideproperty <br> appbarbutton.templatesettings

#### [<a name="appbartogglebutton"></a>appbartogglebutton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton)

appbartogglebutton.keyboardacceleratortextoverride <br> appbartogglebutton.keyboardacceleratortextoverrideproperty <br> appbartogglebutton.templatesettings

#### [<a name="contentlinkchangedeventargs"></a>contentlinkchangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentlinkchangedeventargs)

contentlinkchangedeventargs <br> contentlinkchangedeventargs.changekind <br> contentlinkchangedeventargs.contentlinkinfo <br> contentlinkchangedeventargs.textrange

#### [<a name="contentlinkchangekind"></a>contentlinkchangekind](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.contentlinkchangekind)

contentlinkchangekind

#### [<a name="handwritingpanelclosedeventargs"></a>handwritingpanelclosedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingpanelclosedeventargs)

handwritingpanelclosedeventargs

#### [<a name="handwritingpanelopenedeventargs"></a>handwritingpanelopenedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingpanelopenedeventargs)

handwritingpanelopenedeventargs

#### [<a name="handwritingpanelplacementalignment"></a>handwritingpanelplacementalignment](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingpanelplacementalignment)

handwritingpanelplacementalignment

#### [<a name="handwritingview"></a>handwritingview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.handwritingview)

handwritingview <br> handwritingview.arecandidatesenabled <br> handwritingview.arecandidatesenabledproperty <br> handwritingview.closed <br> handwritingview.handwritingview <br> handwritingview.isopen <br> handwritingview.isopenproperty <br> handwritingview.opened <br> handwritingview.placementalignment <br> handwritingview.placementalignmentproperty <br> handwritingview.placementtarget <br> handwritingview.placementtargetproperty <br> handwritingview.tryclose <br> handwritingview.tryopen

#### [<a name="mediatransportcontrols"></a>mediatransportcontrols](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.mediatransportcontrols)

mediatransportcontrols.iscompactoverlaybuttonvisible <br> mediatransportcontrols.iscompactoverlaybuttonvisibleproperty <br> mediatransportcontrols.iscompactoverlayenabled <br> mediatransportcontrols.iscompactoverlayenabledproperty

#### [<a name="menuflyoutitem"></a>menuflyoutitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.menuflyoutitem)

menuflyoutitem.keyboardacceleratortextoverride <br> menuflyoutitem.keyboardacceleratortextoverrideproperty <br> menuflyoutitem.templatesettings

#### [<a name="navigationview"></a>navigationview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)

navigationview.backrequested <br> navigationview.isbackbuttonvisible <br> navigationview.isbackbuttonvisibleproperty <br> navigationview.isbackenabled <br> navigationview.isbackenabledproperty <br> navigationview.paneclosed <br> navigationview.paneclosing <br> navigationview.paneopened <br> navigationview.paneopening <br> navigationview.panetitle <br> navigationview.panetitleproperty

#### [<a name="navigationviewbackbuttonvisible"></a>navigationviewbackbuttonvisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)

navigationviewbackbuttonvisible

#### [<a name="navigationviewbackrequestedeventargs"></a>navigationviewbackrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewbackrequestedeventargs)

navigationviewbackrequestedeventargs

#### [<a name="navigationviewpaneclosingeventargs"></a>navigationviewpaneclosingeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewpaneclosingeventargs)

navigationviewpaneclosingeventargs <br> navigationviewpaneclosingeventargs.cancel

#### [<a name="refreshcontainer"></a>refreshcontainer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshcontainer)

refreshcontainer <br> refreshcontainer.pulldirection <br> refreshcontainer.pulldirectionproperty <br> refreshcontainer.refreshcontainer <br> refreshcontainer.refreshrequested <br> refreshcontainer.requestrefresh <br> refreshcontainer.visualizer <br> refreshcontainer.visualizerproperty

#### [<a name="refreshinteractionratiochangedeventargs"></a>refreshinteractionratiochangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshinteractionratiochangedeventargs)

refreshinteractionratiochangedeventargs <br> refreshinteractionratiochangedeventargs.interactionratio

#### [<a name="refreshpulldirection"></a>refreshpulldirection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshpulldirection)

refreshpulldirection

#### [<a name="refreshrequestedeventargs"></a>refreshrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshrequestedeventargs)

refreshrequestedeventargs <br> refreshrequestedeventargs.getdeferral

#### [<a name="refreshstatechangedeventargs"></a>refreshstatechangedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshstatechangedeventargs)

refreshstatechangedeventargs <br> refreshstatechangedeventargs.newstate <br> refreshstatechangedeventargs.oldstate

#### [<a name="refreshvisualizer"></a>refreshvisualizer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshvisualizer)

refreshvisualizer <br> refreshvisualizer.content <br> refreshvisualizer.contentproperty <br> refreshvisualizer.infoproviderproperty <br> refreshvisualizer.orientation <br> refreshvisualizer.orientationproperty <br> refreshvisualizer.refreshrequested <br> refreshvisualizer.refreshstatechanged <br> refreshvisualizer.refreshvisualizer <br> refreshvisualizer.requestrefresh <br> refreshvisualizer.state <br> refreshvisualizer.stateproperty

#### [<a name="refreshvisualizerorientation"></a>refreshvisualizerorientation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshvisualizerorientation)

refreshvisualizerorientation

#### [<a name="refreshvisualizerstate"></a>refreshvisualizerstate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.refreshvisualizerstate)

refreshvisualizerstate

#### [<a name="richeditbox"></a>richeditbox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.richeditbox)

richeditbox.contentlinkbackgroundcolor <br> richeditbox.contentlinkbackgroundcolorproperty <br> richeditbox.contentlinkchanged <br> richeditbox.contentlinkforegroundcolor <br> richeditbox.contentlinkforegroundcolorproperty <br> richeditbox.contentlinkinvoked <br> richeditbox.contentlinkproviders <br> richeditbox.contentlinkprovidersproperty <br> richeditbox.handwritingview <br> richeditbox.handwritingviewproperty <br> richeditbox.ishandwritingviewenabled <br> richeditbox.ishandwritingviewenabledproperty

#### [<a name="textbox"></a>textbox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textbox)

textbox.handwritingview <br> textbox.handwritingviewproperty <br> textbox.ishandwritingviewenabled <br> textbox.ishandwritingviewenabledproperty

#### [<a name="treeview"></a>treeview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeview)

treeview <br> treeview.collapse <br> treeview.collapsed <br> treeview.expand <br> treeview.expanding <br> treeview.iteminvoked <br> treeview.rootnodes <br> treeview.selectall <br> treeview.selectednodes <br> treeview.selectionmode <br> treeview.selectionmodeproperty <br> treeview.treeview

#### [<a name="treeviewcollapsedeventargs"></a>treeviewcollapsedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewcollapsedeventargs)

treeviewcollapsedeventargs <br> treeviewcollapsedeventargs.node

#### [<a name="treeviewexpandingeventargs"></a>treeviewexpandingeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewexpandingeventargs)

treeviewexpandingeventargs <br> treeviewexpandingeventargs.node

#### [<a name="treeviewitem"></a>treeviewitem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitem)

treeviewitem <br> treeviewitem.collapsedglyph <br> treeviewitem.collapsedglyphproperty <br> treeviewitem.expandedglyph <br> treeviewitem.expandedglyphproperty <br> treeviewitem.glyphbrush <br> treeviewitem.glyphbrushproperty <br> treeviewitem.glyphopacity <br> treeviewitem.glyphopacityproperty <br> treeviewitem.glyphsize <br> treeviewitem.glyphsizeproperty <br> treeviewitem.isexpanded <br> treeviewitem.isexpandedproperty <br> treeviewitem.treeviewitem <br> treeviewitem.treeviewitemtemplatesettings <br> treeviewitem.treeviewitemtemplatesettingsproperty

#### [<a name="treeviewiteminvokedeventargs"></a>treeviewiteminvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewiteminvokedeventargs)

treeviewiteminvokedeventargs <br> treeviewiteminvokedeventargs.handled <br> treeviewiteminvokedeventargs.invokeditem

#### [<a name="treeviewitemtemplatesettings"></a>treeviewitemtemplatesettings](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewitemtemplatesettings)

treeviewitemtemplatesettings <br> treeviewitemtemplatesettings.collapsedglyphvisibility <br> treeviewitemtemplatesettings.collapsedglyphvisibilityproperty <br> treeviewitemtemplatesettings.dragitemscount <br> treeviewitemtemplatesettings.dragitemscountproperty <br> treeviewitemtemplatesettings.expandedglyphvisibility <br> treeviewitemtemplatesettings.expandedglyphvisibilityproperty <br> treeviewitemtemplatesettings.indentation <br> treeviewitemtemplatesettings.indentationproperty <br> treeviewitemtemplatesettings.treeviewitemtemplatesettings

#### [<a name="treeviewlist"></a>treeviewlist](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewlist)

treeviewlist <br> treeviewlist.treeviewlist

#### [<a name="treeviewnode"></a>treeviewnode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewnode)

treeviewnode <br> treeviewnode.children <br> treeviewnode.content <br> treeviewnode.contentproperty <br> treeviewnode.depth <br> treeviewnode.depthproperty <br> treeviewnode.haschildren <br> treeviewnode.haschildrenproperty <br> treeviewnode.hasunrealizedchildren <br> treeviewnode.isexpanded <br> treeviewnode.isexpandedproperty <br> treeviewnode.parent <br> treeviewnode.treeviewnode

#### [<a name="treeviewselectionmode"></a>treeviewselectionmode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.treeviewselectionmode)

treeviewselectionmode

#### [<a name="webview"></a>webview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webview)

webview.separateprocesslost

#### [<a name="webviewseparateprocesslosteventargs"></a>webviewseparateprocesslosteventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.webviewseparateprocesslosteventargs)

webviewseparateprocesslosteventargs

### [<a name="windowsuixamldocuments"></a>windows.ui.xaml.documents](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents)

#### [<a name="contactcontentlinkprovider"></a>contactcontentlinkprovider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.contactcontentlinkprovider)

contactcontentlinkprovider <br> contactcontentlinkprovider.contactcontentlinkprovider

#### [<a name="contentlink"></a>contentlink](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.contentlink)

contentlink <br> contentlink.background <br> contentlink.backgroundproperty <br> contentlink.contentlink <br> contentlink.cursor <br> contentlink.cursorproperty <br> contentlink.elementsoundmode <br> contentlink.elementsoundmodeproperty <br> contentlink.focus <br> contentlink.focusstate <br> contentlink.focusstateproperty <br> contentlink.gotfocus <br> contentlink.info <br> contentlink.invoked <br> contentlink.istabstop <br> contentlink.istabstopproperty <br> contentlink.lostfocus <br> contentlink.tabindex <br> contentlink.tabindexproperty <br> contentlink.xyfocusdown <br> contentlink.xyfocusdownnavigationstrategy <br> contentlink.xyfocusdownnavigationstrategyproperty <br> contentlink.xyfocusdownproperty <br> contentlink.xyfocusleft <br> contentlink.xyfocusleftnavigationstrategy <br> contentlink.xyfocusleftnavigationstrategyproperty <br> contentlink.xyfocusleftproperty <br> contentlink.xyfocusright <br> contentlink.xyfocusrightnavigationstrategy <br> contentlink.xyfocusrightnavigationstrategyproperty <br> contentlink.xyfocusrightproperty <br> contentlink.xyfocusup <br> contentlink.xyfocusupnavigationstrategy <br> contentlink.xyfocusupnavigationstrategyproperty <br> contentlink.xyfocusupproperty

#### [<a name="contentlinkinvokedeventargs"></a>contentlinkinvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.contentlinkinvokedeventargs)

contentlinkinvokedeventargs <br> contentlinkinvokedeventargs.contentlinkinfo <br> contentlinkinvokedeventargs.handled

#### [<a name="contentlinkprovider"></a>contentlinkprovider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.contentlinkprovider)

contentlinkprovider <br> contentlinkprovider.contentlinkprovider

#### [<a name="contentlinkprovidercollection"></a>contentlinkprovidercollection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.contentlinkprovidercollection)

contentlinkprovidercollection <br> contentlinkprovidercollection.append <br> contentlinkprovidercollection.clear <br> contentlinkprovidercollection.contentlinkprovidercollection <br> contentlinkprovidercollection.first <br> contentlinkprovidercollection.getat <br> contentlinkprovidercollection.getmany <br> contentlinkprovidercollection.getview <br> contentlinkprovidercollection.indexof <br> contentlinkprovidercollection.insertat <br> contentlinkprovidercollection.removeat <br> contentlinkprovidercollection.removeatend <br> contentlinkprovidercollection.replaceall <br> contentlinkprovidercollection.setat <br> contentlinkprovidercollection.size

#### [<a name="placecontentlinkprovider"></a>placecontentlinkprovider](https://docs.microsoft.com/uwp/api/windows.ui.xaml.documents.placecontentlinkprovider)

placecontentlinkprovider <br> placecontentlinkprovider.placecontentlinkprovider

### [<a name="windowsuixamlinput"></a>windows.ui.xaml.input](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input)

#### [<a name="focusmanager"></a>focusmanager](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmanager)

focusmanager.tryfocusasync <br> focusmanager.trymovefocusasync <br> focusmanager.trymovefocusasync

#### [<a name="focusmovementresult"></a>focusmovementresult](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.focusmovementresult)

focusmovementresult <br> focusmovementresult.succeeded

#### [<a name="gettingfocuseventargs"></a>gettingfocuseventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.gettingfocuseventargs)

gettingfocuseventargs.trycancel <br> gettingfocuseventargs.trysetnewfocusedelement

#### [<a name="keyboardacceleratorinvokedeventargs"></a>keyboardacceleratorinvokedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorinvokedeventargs)

keyboardacceleratorinvokedeventargs.keyboardaccelerator

#### [<a name="keyboardacceleratorplacementmode"></a>keyboardacceleratorplacementmode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode)

keyboardacceleratorplacementmode

#### [<a name="losingfocuseventargs"></a>losingfocuseventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.losingfocuseventargs)

losingfocuseventargs.trycancel <br> losingfocuseventargs.trysetnewfocusedelement

### [<a name="windowsuixamlmedia"></a>windows.ui.xaml.media](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media)

#### [<a name="compositiontarget"></a>compositiontarget](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.compositiontarget)

compositiontarget.rendered

#### [<a name="renderedeventargs"></a>renderedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.renderedeventargs)

renderedeventargs <br> renderedeventargs.frameduration

### [<a name="windowsuixaml"></a>windows.ui.xaml](https://docs.microsoft.com/uwp/api/windows.ui.xaml)

#### [<a name="bringintoviewoptions"></a>bringintoviewoptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.bringintoviewoptions)

bringintoviewoptions.horizontalalignmentratio <br> bringintoviewoptions.horizontaloffset <br> bringintoviewoptions.verticalalignmentratio <br> bringintoviewoptions.verticaloffset

#### [<a name="bringintoviewrequestedeventargs"></a>bringintoviewrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.bringintoviewrequestedeventargs)

bringintoviewrequestedeventargs <br> bringintoviewrequestedeventargs.animationdesired <br> bringintoviewrequestedeventargs.handled <br> bringintoviewrequestedeventargs.horizontalalignmentratio <br> bringintoviewrequestedeventargs.horizontaloffset <br> bringintoviewrequestedeventargs.targetelement <br> bringintoviewrequestedeventargs.targetrect <br> bringintoviewrequestedeventargs.verticalalignmentratio <br> bringintoviewrequestedeventargs.verticaloffset

#### [<a name="elementsoundplayer"></a>elementsoundplayer](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementsoundplayer)

elementsoundplayer.spatialaudiomode

#### [<a name="elementspatialaudiomode"></a>elementspatialaudiomode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.elementspatialaudiomode)

elementspatialaudiomode

#### [<a name="uielement"></a>uielement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement)

uielement.bringintoviewrequested <br> uielement.bringintoviewrequestedevent <br> uielement.contextrequestedevent <br> uielement.keyboardacceleratorplacementmode <br> uielement.keyboardacceleratorplacementmodeproperty <br> uielement.keyboardacceleratorplacementtarget <br> uielement.keyboardacceleratorplacementtargetproperty <br> uielement.keytiptarget <br> uielement.keytiptargetproperty <br> uielement.onbringintoviewrequested <br> uielement.onkeyboardacceleratorinvoked <br> uielement.registerasscrollport

## <a name="windowsweb"></a>windows.web

### [<a name="windowswebuiinterop"></a>windows.web.ui.interop](https://docs.microsoft.com/uwp/api/windows.web.ui.interop)

#### [<a name="webviewcontrol"></a>webviewcontrol](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrol)

webviewcontrol <br> webviewcontrol.acceleratorkeypressed <br> webviewcontrol.bounds <br> webviewcontrol.buildlocalstreamuri <br> webviewcontrol.cangoback <br> webviewcontrol.cangoforward <br> webviewcontrol.capturepreviewtostreamasync <br> webviewcontrol.captureselectedcontenttodatapackageasync <br> webviewcontrol.close <br> webviewcontrol.containsfullscreenelement <br> webviewcontrol.containsfullscreenelementchanged <br> webviewcontrol.contentloading <br> webviewcontrol.defaultbackgroundcolor <br> webviewcontrol.deferredpermissionrequests <br> webviewcontrol.documenttitle <br> webviewcontrol.domcontentloaded <br> webviewcontrol.framecontentloading <br> webviewcontrol.framedomcontentloaded <br> webviewcontrol.framenavigationcompleted <br> webviewcontrol.framenavigationstarting <br> webviewcontrol.getdeferredpermissionrequestbyid <br> webviewcontrol.goback <br> webviewcontrol.goforward <br> webviewcontrol.invokescriptasync <br> webviewcontrol.isvisible <br> webviewcontrol.longrunningscriptdetected <br> webviewcontrol.movefocus <br> webviewcontrol.movefocusrequested <br> webviewcontrol.navigate <br> webviewcontrol.navigatetolocalstreamuri <br> webviewcontrol.navigatetostring <br> webviewcontrol.navigatewithhttprequestmessage <br> webviewcontrol.navigationcompleted <br> webviewcontrol.navigationstarting <br> webviewcontrol.newwindowrequested <br> webviewcontrol.permissionrequested <br> webviewcontrol.process <br> webviewcontrol.refresh <br> webviewcontrol.scale <br> webviewcontrol.scriptnotify <br> webviewcontrol.settings <br> webviewcontrol.source <br> webviewcontrol.stop <br> webviewcontrol.unsafecontentwarningdisplaying <br> webviewcontrol.unsupportedurischemeidentified <br> webviewcontrol.unviewablecontentidentified <br> webviewcontrol.webresourcerequested

#### [<a name="webviewcontrolacceleratorkeypressedeventargs"></a>webviewcontrolacceleratorkeypressedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolacceleratorkeypressedeventargs)

webviewcontrolacceleratorkeypressedeventargs <br> webviewcontrolacceleratorkeypressedeventargs.eventtype <br> webviewcontrolacceleratorkeypressedeventargs.keystatus <br> webviewcontrolacceleratorkeypressedeventargs.routingstage <br> webviewcontrolacceleratorkeypressedeventargs.virtualkey

#### [<a name="webviewcontrolacceleratorkeyroutingstage"></a>webviewcontrolacceleratorkeyroutingstage](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolacceleratorkeyroutingstage)

webviewcontrolacceleratorkeyroutingstage

#### [<a name="webviewcontrolmovefocusreason"></a>webviewcontrolmovefocusreason](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolmovefocusreason)

webviewcontrolmovefocusreason

#### [<a name="webviewcontrolmovefocusrequestedeventargs"></a>webviewcontrolmovefocusrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolmovefocusrequestedeventargs)

webviewcontrolmovefocusrequestedeventargs <br> webviewcontrolmovefocusrequestedeventargs.reason

#### [<a name="webviewcontrolprocess"></a>webviewcontrolprocess](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolprocess)

webviewcontrolprocess <br> webviewcontrolprocess.createwebviewcontrolasync <br> webviewcontrolprocess.enterpriseid <br> webviewcontrolprocess.getwebviewcontrols <br> webviewcontrolprocess.isprivatenetworkclientservercapabilityenabled <br> webviewcontrolprocess.processexited <br> webviewcontrolprocess.processid <br> webviewcontrolprocess.terminate <br> webviewcontrolprocess.webviewcontrolprocess <br> webviewcontrolprocess.webviewcontrolprocess

#### [<a name="webviewcontrolprocesscapabilitystate"></a>webviewcontrolprocesscapabilitystate](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolprocesscapabilitystate)

webviewcontrolprocesscapabilitystate

#### [<a name="webviewcontrolprocessoptions"></a>webviewcontrolprocessoptions](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.webviewcontrolprocessoptions)

webviewcontrolprocessoptions <br> webviewcontrolprocessoptions.enterpriseid <br> webviewcontrolprocessoptions.privatenetworkclientservercapability <br> webviewcontrolprocessoptions.webviewcontrolprocessoptions

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.web.ui.interop.windows)

windows.web.ui.interop

### [<a name="windowswebui"></a>windows.web.ui](https://docs.microsoft.com/uwp/api/windows.web.ui)

#### [<a name="iwebviewcontrol"></a>iwebviewcontrol](https://docs.microsoft.com/uwp/api/windows.web.ui.iwebviewcontrol)

iwebviewcontrol <br> iwebviewcontrol.buildlocalstreamuri <br> iwebviewcontrol.cangoback <br> iwebviewcontrol.cangoforward <br> iwebviewcontrol.capturepreviewtostreamasync <br> iwebviewcontrol.captureselectedcontenttodatapackageasync <br> iwebviewcontrol.containsfullscreenelement <br> iwebviewcontrol.containsfullscreenelementchanged <br> iwebviewcontrol.contentloading <br> iwebviewcontrol.defaultbackgroundcolor <br> iwebviewcontrol.deferredpermissionrequests <br> iwebviewcontrol.documenttitle <br> iwebviewcontrol.domcontentloaded <br> iwebviewcontrol.framecontentloading <br> iwebviewcontrol.framedomcontentloaded <br> iwebviewcontrol.framenavigationcompleted <br> iwebviewcontrol.framenavigationstarting <br> iwebviewcontrol.getdeferredpermissionrequestbyid <br> iwebviewcontrol.goback <br> iwebviewcontrol.goforward <br> iwebviewcontrol.invokescriptasync <br> iwebviewcontrol.longrunningscriptdetected <br> iwebviewcontrol.navigate <br> iwebviewcontrol.navigatetolocalstreamuri <br> iwebviewcontrol.navigatetostring <br> iwebviewcontrol.navigatewithhttprequestmessage <br> iwebviewcontrol.navigationcompleted <br> iwebviewcontrol.navigationstarting <br> iwebviewcontrol.newwindowrequested <br> iwebviewcontrol.permissionrequested <br> iwebviewcontrol.refresh <br> iwebviewcontrol.scriptnotify <br> iwebviewcontrol.settings <br> iwebviewcontrol.source <br> iwebviewcontrol.stop <br> iwebviewcontrol.unsafecontentwarningdisplaying <br> iwebviewcontrol.unsupportedurischemeidentified <br> iwebviewcontrol.unviewablecontentidentified <br> iwebviewcontrol.webresourcerequested

#### [<a name="webviewcontrolcontentloadingeventargs"></a>webviewcontrolcontentloadingeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolcontentloadingeventargs)

webviewcontrolcontentloadingeventargs <br> webviewcontrolcontentloadingeventargs.uri

#### [<a name="webviewcontroldeferredpermissionrequest"></a>webviewcontroldeferredpermissionrequest](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontroldeferredpermissionrequest)

webviewcontroldeferredpermissionrequest <br> webviewcontroldeferredpermissionrequest.allow <br> webviewcontroldeferredpermissionrequest.deny <br> webviewcontroldeferredpermissionrequest.id <br> webviewcontroldeferredpermissionrequest.permissiontype <br> webviewcontroldeferredpermissionrequest.uri

#### [<a name="webviewcontroldomcontentloadedeventargs"></a>webviewcontroldomcontentloadedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontroldomcontentloadedeventargs)

webviewcontroldomcontentloadedeventargs <br> webviewcontroldomcontentloadedeventargs.uri

#### [<a name="webviewcontrollongrunningscriptdetectedeventargs"></a>webviewcontrollongrunningscriptdetectedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrollongrunningscriptdetectedeventargs)

webviewcontrollongrunningscriptdetectedeventargs <br> webviewcontrollongrunningscriptdetectedeventargs.executiontime <br> webviewcontrollongrunningscriptdetectedeventargs.stoppagescriptexecution

#### [<a name="webviewcontrolnavigationcompletedeventargs"></a>webviewcontrolnavigationcompletedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolnavigationcompletedeventargs)

webviewcontrolnavigationcompletedeventargs <br> webviewcontrolnavigationcompletedeventargs.issuccess <br> webviewcontrolnavigationcompletedeventargs.uri <br> webviewcontrolnavigationcompletedeventargs.weberrorstatus

#### [<a name="webviewcontrolnavigationstartingeventargs"></a>webviewcontrolnavigationstartingeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolnavigationstartingeventargs)

webviewcontrolnavigationstartingeventargs <br> webviewcontrolnavigationstartingeventargs.cancel <br> webviewcontrolnavigationstartingeventargs.uri

#### [<a name="webviewcontrolnewwindowrequestedeventargs"></a>webviewcontrolnewwindowrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolnewwindowrequestedeventargs)

webviewcontrolnewwindowrequestedeventargs <br> webviewcontrolnewwindowrequestedeventargs.handled <br> webviewcontrolnewwindowrequestedeventargs.referrer <br> webviewcontrolnewwindowrequestedeventargs.uri

#### [<a name="webviewcontrolpermissionrequest"></a>webviewcontrolpermissionrequest](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolpermissionrequest)

webviewcontrolpermissionrequest <br> webviewcontrolpermissionrequest.allow <br> webviewcontrolpermissionrequest.defer <br> webviewcontrolpermissionrequest.deny <br> webviewcontrolpermissionrequest.id <br> webviewcontrolpermissionrequest.permissiontype <br> webviewcontrolpermissionrequest.state <br> webviewcontrolpermissionrequest.uri

#### [<a name="webviewcontrolpermissionrequestedeventargs"></a>webviewcontrolpermissionrequestedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolpermissionrequestedeventargs)

webviewcontrolpermissionrequestedeventargs <br> webviewcontrolpermissionrequestedeventargs.permissionrequest

#### [<a name="webviewcontrolpermissionstate"></a>webviewcontrolpermissionstate](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolpermissionstate)

webviewcontrolpermissionstate

#### [<a name="webviewcontrolpermissiontype"></a>webviewcontrolpermissiontype](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolpermissiontype)

webviewcontrolpermissiontype

#### [<a name="webviewcontrolscriptnotifyeventargs"></a>webviewcontrolscriptnotifyeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolscriptnotifyeventargs)

webviewcontrolscriptnotifyeventargs <br> webviewcontrolscriptnotifyeventargs.uri <br> webviewcontrolscriptnotifyeventargs.value

#### [<a name="webviewcontrolsettings"></a>webviewcontrolsettings](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolsettings)

webviewcontrolsettings <br> webviewcontrolsettings.isindexeddbenabled <br> webviewcontrolsettings.isjavascriptenabled <br> webviewcontrolsettings.isscriptnotifyallowed

#### [<a name="webviewcontrolunsupportedurischemeidentifiedeventargs"></a>webviewcontrolunsupportedurischemeidentifiedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolunsupportedurischemeidentifiedeventargs)

webviewcontrolunsupportedurischemeidentifiedeventargs <br> webviewcontrolunsupportedurischemeidentifiedeventargs.handled <br> webviewcontrolunsupportedurischemeidentifiedeventargs.uri

#### [<a name="webviewcontrolunviewablecontentidentifiedeventargs"></a>webviewcontrolunviewablecontentidentifiedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolunviewablecontentidentifiedeventargs)

webviewcontrolunviewablecontentidentifiedeventargs <br> webviewcontrolunviewablecontentidentifiedeventargs.mediatype <br> webviewcontrolunviewablecontentidentifiedeventargs.referrer <br> webviewcontrolunviewablecontentidentifiedeventargs.uri

#### [<a name="webviewcontrolwebresourcerequestedeventargs"></a>webviewcontrolwebresourcerequestedeventargs](https://docs.microsoft.com/uwp/api/windows.web.ui.webviewcontrolwebresourcerequestedeventargs)

webviewcontrolwebresourcerequestedeventargs <br> webviewcontrolwebresourcerequestedeventargs.getdeferral <br> webviewcontrolwebresourcerequestedeventargs.request <br> webviewcontrolwebresourcerequestedeventargs.response

#### [<a name="windows"></a>windows](https://docs.microsoft.com/uwp/api/windows.web.ui.windows)

windows.web.ui

