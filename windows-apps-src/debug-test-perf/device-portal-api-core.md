---
ms.assetid: bfabd3d5-dd56-4917-9572-f3ba0de4f8c0
title: Device Portal core API reference
description: Learn about the Windows Device Portal core REST API's that you can use to access the data and control your device programmatically.
---

# Device Portal core API reference

Everything in the Windows Device Portal is built on top of REST API's that you can use to access the data and control your device programmatically.

## App deployment

---
### Install an app

**Request**

You can install an app by using the following request format.

Method      | Request URI
:------     | :-----
POST | /api/appx/packagemanager/package

**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
package   | (**required**) The file name of the package to be installed.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Get app installation status

**Request**

You can get the status of an app installation that is currently in progress by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/appx/packagemanager/state

**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Uninstall an app

**Request**

You can uninstall an app by using the following request format.
 
Method      | Request URI
:------     | :-----
DELETE | /api/appx/packagemanager/package


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Get installed apps

**Request**

You can get a list of apps installed on the system by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/appx/packagemanager/packages


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

The response includes a list of installed packages with associated details.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Device manager
---
### Get the installed devices on the machine

**Request**

You can get a list of devices that are installed on the machine by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/devicemanager/devices


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes a JSON structure that contains a hierarchical device tree.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* IoT

---
## Dump collection
---
### Get the list of all crash dumps for apps

**Request**

You can get the list of all the available crash dumps for all sideloaded apps by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/usermode/dumps


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes a list of crash dumps for each sideloaded application.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Get the crash dump collection settings for an app

**Request**

You can get the crash dump collection settings for a sideloaded app by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/usermode/crashcontrol


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
packageFullname   | (**required**) The full name of the package for the sideloaded app.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Delete a crash dump for a sideloaded app

**Request**

You can delete a sideloaded app's crash dump by using the following request format.
 
Method      | Request URI
:------     | :-----
DELETE | /api/debug/dump/usermode/crashdump


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
packageFullname   | (**required**) The full name of the package for the sideloaded app.
fileName   | (**required**) The name of the dump file that should be deleted.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Disable crash dumps for a sideloaded app

**Request**

You can disable crash dumps for a sideloaded app by using the following request format.
 
Method      | Request URI
:------     | :-----
DELETE | /api/debug/dump/usermode/crashcontrol


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
packageFullname   | (**required**) The full name of the package for the sideloaded app.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Download the crash dump for a sideloaded app

**Request**

You can download a sideloaded app's crash dump by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/usermode/crashdump


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
packageFullname   | (**required**) The full name of the package for the sideloaded app.
fileName   | (**required**) The name of the dump file that you want to download.

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes a dump file. You can use WinDbg or Visual Studio to examine the dump file.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Enable crash dumps for a sideloaded app

**Request**

You can enable crash dumps for a sideloaded app by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/debug/dump/usermode/crashcontrol


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
packageFullname   | (**required**) The full name of the package for the sideloaded app.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Get the list of bugcheck files

**Request**

You can get the list of bugcheck minidump files by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/kernel/dumplist


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes a list of dump file names and the sizes of these files.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Download a bugcheck dump file

**Request**

You can download a bugcheck dump file by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/kernel/dump


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
filename   | (**required**) The file name of the dump file. You can find this by using the API to get the dump list.

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the dump file. You can inspect this file using WinDbg.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get the bugcheck crash control settings

**Request**

You can get the bugcheck crash control settings by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/kernel/crashcontrol


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the crash control settings. For more information about CrashControl, see the [CrashControl](https://technet.microsoft.com/library/cc951703.aspx) article.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get a live kernel dump

**Request**

You can get a live kernel dump by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/livekernel


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the full kernel mode dump. You can inspect this file using WinDbg.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get a dump from a live user process

**Request**

You can get the dump for live user process by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/debug/dump/usermode/live


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
pid   | (**required**) The unique process id for the process you are interested in.

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the process dump. You can inspect this file using WinDbg or Visual Studio.

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Set the bugcheck crash control settings

**Request**

You can set the settings for collecting bugcheck data by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/debug/dump/kernel/crashcontrol


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
autoreboot   | (**optional**) True or false. This indicates whether the system restarts automatically after it fails or locks.
dumptype   | (**optional**) The dump type. For the supported values, see the [CrashDumpType Enumeration](https://msdn.microsoft.com/library/azure/microsoft.azure.management.insights.models.crashdumptype.aspx).
maxdumpcount   | (**optional**) The maximum number of dumps to save.
overwrite   | (**optional**) True of false. This indicates whether or not to overwrite old dumps when the dump counter limit specified by *maxdumpcount* has been reached.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
## ETW
---
### Create a realtime ETW session over a websocket

**Request**

You can create a realtime ETW session by using the following request format. This will be managed over a websocket.
 
Method      | Request URI
:------     | :-----
GET/WebSocket | /api/etw/session/realtime


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the ETW events from the enabled providers.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Enumerate the registered ETW providers

**Request**

You can enumerate through the registered providers by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/etw/providers


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the list of ETW providers. The list will include the friendly name and GUID for each provider.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
## Networking
---
### Get the current IP configuration

**Request**

You can get the current IP configuration by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/networking/ipconfig


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the IP configuration

**Status code**

The following table shows possible additional status codes that can be returned as a result of this operation.

HTTP status code      | Description
:------     | :-----
200 | The operation completed successfully
500 | There was an internal server error

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## OS information
---
### Get the machine name

**Request**

You can get the name of a machine by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/os/machinename


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Get the operating system information

**Request**

You can get the OS information for a machine by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/os/info


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Set the machine name

**Request**

You can set the name of a machine by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/os/machinename


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
name | (**required**) The new name for the machine.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Performance data
---
### Get the list of running processes

**Request**

You can get the list of currently running processes by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/resourcemanager/processes


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes a list of processes with details for each process. The information is in JSON format.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Get the system performance statistics

**Request**

You can get the system performance statistics by using the following request format. This includes information such as read and write cycles and how much memory has been used.
 
Method      | Request URI
:------     | :-----
GET | /api/resourcemanager/systemperf


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The response includes the performance statistics for the system such as CPU and GPU usage, memory access, and network access. This information is in JSON format.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Power
---
### Get the current battery state

**Request**

You can get the current state of the battery by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/power/battery


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Get the active power scheme

**Request**

You can get the active power scheme by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/power/activecfg


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get the sub-value for a power scheme

**Request**

You can get the sub-value for a power scheme by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/power/cfg/*<power scheme path>*


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get the power state of the system

**Request**

You can check the power state of the system by using the following request format. This will let you check to see if it is in a low power state.
 
Method      | Request URI
:------     | :-----
GET | /api/power/state


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Get a sleep study report

**Request**

You can get a sleep study report by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/power/sleepstudy/reports


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
FileName | (**required**) The file name of sleep study report that you want to download.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Set the active power scheme

**Request**

You can set the active power scheme by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/power/activecfg


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
scheme | (**required**) The GUID of the scheme you want to set as the active power scheme for the system.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Set the sub-value for a power scheme

**Request**

You can set the sub-value for a power scheme by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/power/cfg/*<power scheme path>*


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
valueAC | (**required**) The value to use for A/C power.
valueDC | (**required**) The value to use for battery power.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Enumerate the available sleep study reports

**Request**

You can enumerate the available sleep study reports by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/power/sleepstudy/reports


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
### Get the sleep study transform

**Request**

You can get the sleep study transform by using the following request format. This transform is an XSLT that converts the sleep study report into an XML format that can be read by a person.
 
Method      | Request URI
:------     | :-----
GET | /api/power/sleepstudy/reports


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* IoT

---
## Remote control
---
### Restart the target computer

**Request**

You can restart the target computer by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/control/restart


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Shut down the target computer

**Request**

You can shut down the target computer by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/control/shutdown


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Task manager
---
### Start a modern app

**Request**

You can start a modern app by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/taskmanager/app


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
appid   | (**required**) The PRAID for the app you want to start. This value should be hex64 encoded.
package   | (**required**) The full name for the app package you want to start. This value should be hex64 encoded.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Stop a modern app

**Request**

You can stop a modern app by using the following request format.
 
Method      | Request URI
:------     | :-----
DELETE | /api/taskmanager/app


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
package   | (**required**) The full name of the app packages that you want to stop. This value should be hex64 encoded.
forcestop   | (**optional**) A value of **yes** indicates that the system should force all processes to stop.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## WiFi
---
### Enumerate wireless network interfaces

**Request**

You can enumerate the available wireless network interfaces by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wifi/interfaces


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- A list of the available wireless interfaces with details. The details will include items such as GUID, description, friendly name, and more.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Enumerate wireless networks

**Request**

You can enumerate the list of wireless networks on the specified interface by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wifi/networks


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
interface   | (**required**) The GUID for the network interface to use to search for wireless networks.

**Request headers**

- None

**Request body**

- None

**Response**

- The list of wireless networks found on the provided *interface*. This includes details for the networks.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Connect and disconnect to a Wi-Fi network.

**Request**

You can connect or disconnect to a Wi-Fi network by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/wifi/network


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
interface   | (**required**) The GUID for the network interface you use to connect to the network.
op   | (**required**) Indicates the action to take. Possible values are connect or disconnect.
ssid   | (**required if *op* == connect**) The SSID to connect to.
key   | (**required if *op* == connect**) The shared key.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
### Delete a Wi-Fi profile

**Request**

You can delete a profile associated with a network on a specific interface by using the following request format.
 
Method      | Request URI
:------     | :-----
DELETE | /api/wifi/network


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
interface   | (**required**) The GUID for the network interface associated with the profile to delete.
profile   | (**required**) The name of the profile to delete.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* Xbox
* HoloLens
* IoT

---
## Windows Error Reporting (WER)
---
### Download a Windows error reporting (WER) file

**Request**

You can download a WER file by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wer/reports/file


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
user   | (**required**) The user name associated with the report.
type   | (**required**) The type of report. This can be either **queried** or **archived**.
name   | (**required**) The name of the report.
file   | (**required**) The name of the file to download from the report.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### Enumerate files in a Windows error reporting (WER) report

**Request**

You can enumerate the files in a WER report by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wer/reports/files


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
user   | (**required**) The user associated with the report.
type   | (**required**) The type of report. This can be either **queried** or **archived**.
name   | (**required**) The name of the report.

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
### List the Windows error reporting (WER) reports

**Request**

You can get the WER reports by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wer/reports


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- None

**Status code**

- Standard status codes.

**Available device families**

* Windows Desktop
* HoloLens
* IoT

---
## Windows Performance Recorder (WPR) 
---
### Start tracing with a custom profile

**Request**

You can upload a WPR profile and start tracing using that profile by using the following request format.
 
Method      | Request URI
:------     | :-----
POST | /api/wpr/customtrace


**URI parameters**

- None

**Request headers**

- None

**Request body**

- A multi-part conforming http body that contains the custom WPR profile.

**Response**

- Returns the WPR session status.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Start a boot performance tracing session

**Request**

You can start a boot WPR tracing session by using the following request format. This is also known as a performance tracing session.
 
Method      | Request URI
:------     | :-----
POST | /api/wpr/boottrace


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
profile   | (**required**) This parameter is required on start. The name of the profile that should start a performance tracing session. The possible profiles are stored in perfprofiles/profiles.json.

**Request headers**

- None

**Request body**

- None

**Response**

- On start, this API returns the WPR session status.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Stop a boot performance tracing session

**Request**

You can stop a boot WPR tracing session by using the following request format. This is also known as a performance tracing session.
 
Method      | Request URI
:------     | :-----
GET | /api/wpr/boottrace


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- Returns the trace ETL file.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Start a performance tracing session

**Request**

You can start a WPR tracing session by using the following request format. This is also known as a performance tracing session.
 
Method      | Request URI
:------     | :-----
POST | /api/wpr/trace


**URI parameters**

You can specify the following additional parameters on the request URI:

URI parameter | Description
:---          | :---
profile   | (**required**) The name of the profile that should start a performance tracing session. The possible profiles are stored in perfprofiles/profiles.json.

**Request headers**

- None

**Request body**

- None

**Response**

- On start, this API returns the WPR session status.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Stop a performance tracing session

**Request**

You can stop a WPR tracing session by using the following request format. This is also known as a performance tracing session.
 
Method      | Request URI
:------     | :-----
GET | /api/wpr/trace


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- Returns the trace ETL file.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT

---
### Retrieve the status of a tracing session

**Request**

You can retrieve the status of the current WPR session by using the following request format.
 
Method      | Request URI
:------     | :-----
GET | /api/wpr/status


**URI parameters**

- None

**Request headers**

- None

**Request body**

- None

**Response**

- The status of the WPR tracing session.

**Status code**

- Standard status codes.

**Available device families**

* Windows Mobile
* Windows Desktop
* HoloLens
* IoT


<!--HONumber=Mar16_HO5-->


