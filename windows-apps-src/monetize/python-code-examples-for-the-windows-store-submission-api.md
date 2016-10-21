---
author: mcleanbyron
ms.assetid: 8AC56AAF-8D8C-4193-A6B3-BB5D0669D994
description: "このセクションの Python コード例を使用して、Windows ストア申請 API を使用する方法をご確認ください。"
title: "Windows ストア申請 API の Python コード例"
translationtype: Human Translation
ms.sourcegitcommit: bd8c8cbf6ed10a583d2008e8b01a499b4d400c11
ms.openlocfilehash: 52fd41ca41628d41140c8c24047e2a50ea72bf40

---

# Windows ストア申請 API の Python コード例

この記事では、*Windows ストア申請 API* を使用するための Python コード例を紹介します。 この API について詳しくは、[Windows ストア サービスを使用した申請の作成と管理に関するページ](create-and-manage-submissions-using-windows-store-services.md)をご覧ください。

ここでは、次のタスクに対応するコード例を示します。

* [Azure AD アクセス トークンの取得](python-code-examples-for-the-windows-store-submission-api.md#token)。
* [アドオンの作成](python-code-examples-for-the-windows-store-submission-api.md#create-add-on)。
* [パッケージ フライトの作成](python-code-examples-for-the-windows-store-submission-api.md#create-package-flight)。
* [アプリの申請の作成とコミット](python-code-examples-for-the-windows-store-submission-api.md#create-app-submission)。
* [アドオンの申請の作成とコミット](python-code-examples-for-the-windows-store-submission-api.md#create-add-on-submission)。
* [パッケージ フライトの申請の作成とコミット](python-code-examples-for-the-windows-store-submission-api.md#create-flight-submission)。

<span id="token" />
## Azure AD アクセス トークンの取得

次の例は、[Azure AD アクセス トークンを取得](create-and-manage-submissions-using-windows-store-services.md#obtain-an-azure-ad-access-token)する方法を示しています。

```python
import http.client, json

tenantId = ""  # Your tenant ID
clientId = ""  # Your client ID
clientSecret = ""  # Your client secret

tokenEndpoint = "https://login.microsoftonline.com/{0}/oauth2/token"
tokenResource = "https://manage.devcenter.microsoft.com"

tokenRequestBody = "grant_type=client_credentials&client_id={0}&client_secret={1}&resource={2}".format(clientId, clientSecret, tokenResource)
headers = {"Content-Type": "application/x-www-form-urlencoded; charset=utf-8"}
tokenConnection = http.client.HTTPSConnection("login.microsoftonline.com")
tokenConnection.request("POST", "/{0}/oauth2/token".format(tenantId), tokenRequestBody, headers=headers)

tokenResponse = tokenConnection.getresponse()
print(tokenResponse.status)
tokenJson = json.loads(tokenResponse.read().decode())
print(tokenJson["access_token"])

tokenConnection.close()
```

<span id="create-add-on" />
## アドオンの作成

次の例は、[新しいアドオンを作成](manage-add-ons.md)する方法を示しています (アドオンは "アプリ内製品"、略して "IAP" とも呼ばれます)。

```python
import http.client, json

accessToken = ""  # Your access token
iapRequestJson = ""  # Your in-app-product request JSON

headers = {"Authorization": "Bearer " + accessToken,
           "Content-type": "application/json",
           "User-Agent": "Python"}
ingestionConnection = http.client.HTTPSConnection("manage.devcenter.microsoft.com")

# Create a new in-app-product
ingestionConnection.request("POST", "/v1.0/my/inappproducts", iapRequestJson, headers)
createIapResponse = ingestionConnection.getresponse()
print(createIapResponse.status)
print(createIapResponse.reason)
print(createIapResponse.headers["MS-CorrelationId"])  # Log correlation ID

iapJsonObject = json.loads(createIapResponse.read().decode())
inAppProductId = iapJsonObject["id"]

# Delete created in-app-product
ingestionConnection.request("DELETE", "/v1.0/my/inappproducts/" + inAppProductId, "", headers)
deleteIapResponse = ingestionConnection.getresponse()
print(deleteIapResponse.status)
print(deleteIapResponse.headers["MS-CorrelationId"])  # Log correlation ID

ingestionConnection.close()
```

<span id="create-package-flight" />
## パッケージ フライトの作成

次の例は、[新しいパッケージ フライトを作成](manage-flights.md)する方法を示しています。

```python
import http.client, json, requests, time

accessToken = ""  # Your access token
applicationId = ""  # Your application ID
flightRequestJson = ""  # Your flight request JSON

headers = {"Authorization": "Bearer " + accessToken,
           "Content-type": "application/json",
           "User-Agent": "Python"}
ingestionConnection = http.client.HTTPSConnection("manage.devcenter.microsoft.com")

# Create a new flight, a flight submission will be created together with the flight

```python
ingestionConnection.request("POST", "/v1.0/my/applications/{0}/flights".format(applicationId), flightRequestJson, headers)
createFlightResponse = ingestionConnection.getresponse()
print(createFlightResponse.status)
print(createFlightResponse.reason)
print(createFlightResponse.headers["MS-CorrelationId"])  # Log correlation ID

flightJsonObject = json.loads(createFlightResponse.read().decode())
flightId = flightJsonObject["flightId"]
submissionId = flightJsonObject["pendingFlightSubmission"]["id"]

# Delete created flight
ingestionConnection.request("DELETE", "/v1.0/my/applications/{0}/flights/{1}".format(applicationId, flightId), "", headers)
deleteFlightResponse = ingestionConnection.getresponse()
print(deleteFlightResponse.status)
print(deleteFlightResponse.headers["MS-CorrelationId"])  # Log correlation ID

ingestionConnection.close()
```

<span id="create-app-submission" />
## アプリの申請の作成とコミット

次の例は、[新しいアプリの申請を作成](manage-app-submissions.md)する方法を示しています。

```python
import http.client, json, requests, time

accessToken = ""  # Your access token
applicationId = ""  # Your application ID
appSubmissionRequestJson = "";  # Your submission request JSON
zipFilePath = r'*.zip'  # Your zip file path

headers = {"Authorization": "Bearer " + accessToken,
           "Content-type": "application/json",
           "User-Agent": "Python"}
ingestionConnection = http.client.HTTPSConnection("manage.devcenter.microsoft.com")

# Get application
ingestionConnection.request("GET", "/v1.0/my/applications/{0}".format(applicationId), "", headers)
appResponse = ingestionConnection.getresponse()
print(appResponse.status)
print(appResponse.headers["MS-CorrelationId"])  # Log correlation ID

# Delete existing in-progress submission
appJsonObject = json.loads(appResponse.read().decode())
if "pendingApplicationSubmission" in appJsonObject :
    submissionToRemove = appJsonObject["pendingApplicationSubmission"]["id"]
    ingestionConnection.request("DELETE", "/v1.0/my/applications/{0}/submissions/{1}".format(applicationId, submissionToRemove), "", headers)
    deleteSubmissionResponse = ingestionConnection.getresponse()
    print(deleteSubmissionResponse.status)
    print(deleteSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
    deleteSubmissionResponse.read()

# Create submission
ingestionConnection.request("POST", "/v1.0/my/applications/{0}/submissions".format(applicationId), "", headers)
createSubmissionResponse = ingestionConnection.getresponse()
print(createSubmissionResponse.status)
print(createSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID

submissionJsonObject = json.loads(createSubmissionResponse.read().decode())
submissionId = submissionJsonObject["id"]
fileUploadUrl = submissionJsonObject["fileUploadUrl"]
print(submissionId)
print(fileUploadUrl)

# Update submission
ingestionConnection.request("PUT", "/v1.0/my/applications/{0}/submissions/{1}".format(applicationId, submissionId), appSubmissionRequestJson, headers)
updateSubmissionResponse = ingestionConnection.getresponse()
print(updateSubmissionResponse.status)
print(updateSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
updateSubmissionResponse.read()

# Upload images and packages in a zip file. Note that large file might need to be handled differently
f = open(zipFilePath, 'rb')
uploadResponse = requests.put(fileUploadUrl.replace("+", "%2B"), f, headers={"x-ms-blob-type": "BlockBlob"})
print(uploadResponse.status_code)


# Commit submission
ingestionConnection.request("POST", "/v1.0/my/applications/{0}/submissions/{1}/commit".format(applicationId, submissionId), "", headers)
commitResponse = ingestionConnection.getresponse()
print(commitResponse.status)
print(commitResponse.headers["MS-CorrelationId"])  # Log correlation ID
print(commitResponse.read())

# Pull submission status until commit process is completed
ingestionConnection.request("GET", "/v1.0/my/applications/{0}/submissions/{1}/status".format(applicationId, submissionId), "", headers)
getSubmissionStatusResponse = ingestionConnection.getresponse()
submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
while submissionJsonObject["status"] == "CommitStarted":
    time.sleep(60)
    ingestionConnection.request("GET", "/v1.0/my/applications/{0}/submissions/{1}/status".format(applicationId, submissionId), "", headers)
    getSubmissionStatusResponse = ingestionConnection.getresponse()
    submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
    print(submissionJsonObject["status"])

print(submissionJsonObject["status"])
print(submissionJsonObject)

ingestionConnection.close()
```

<span id="create-add-on-submission" />
## アドオンの申請の作成とコミット

次の例は、[新しいアドオンの申請を作成し、コミット](manage-add-on-submissions.md)する方法を示しています (アドオンは "アプリ内製品"、略して "IAP" とも呼ばれます)。

```python
import http.client, json, requests, time

accessToken = ""  # Your access token
inAppProductId = ""  # Your in-app-product ID
updateSubmissionRequestBody = "";  # Your in-app-product submission request JSON
zipFilePath = r'*.zip'  # Your zip file path

headers = {"Authorization": "Bearer " + accessToken,
           "Content-type": "application/json",
           "User-Agent": "Python"}
ingestionConnection = http.client.HTTPSConnection("manage.devcenter.microsoft.com")

# Get in-app-product
ingestionConnection.request("GET", "/v1.0/my/inappproducts/{0}".format(inAppProductId), "", headers)
iapResponse = ingestionConnection.getresponse()
print(iapResponse.status)
print(iapResponse.headers["MS-CorrelationId"])  # Log correlation ID

# Delete existing in-progress submission
iapJsonObject = json.loads(iapResponse.read().decode())
if "pendingInAppProductSubmission" in iapJsonObject :
    submissionToRemove = iapJsonObject["pendingInAppProductSubmission"]["id"]
    ingestionConnection.request("DELETE", "/v1.0/my/inappproducts/{0}/submissions/{1}".format(inAppProductId, submissionToRemove), "", headers)
    deleteSubmissionResponse = ingestionConnection.getresponse()
    print(deleteSubmissionResponse.status)
    print(deleteSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
    deleteSubmissionResponse.read()

# Create submission
ingestionConnection.request("POST", "/v1.0/my/inappproducts/{0}/submissions".format(inAppProductId), "", headers)
createSubmissionResponse = ingestionConnection.getresponse()
print(createSubmissionResponse.status)
print(createSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID

submissionJsonObject = json.loads(createSubmissionResponse.read().decode())
submissionId = submissionJsonObject["id"]
fileUploadUrl = submissionJsonObject["fileUploadUrl"]
print(submissionId)
print(fileUploadUrl)

# Update submission
ingestionConnection.request("PUT", "/v1.0/my/inappproducts/{0}/submissions/{1}".format(inAppProductId, submissionId), updateSubmissionRequestBody, headers)
updateSubmissionResponse = ingestionConnection.getresponse()
print(updateSubmissionResponse.status)
print(updateSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
updateSubmissionResponse.read()

# Upload images and packages in a zip file. Note that large file might need to be handled differently
f = open(zipFilePath, 'rb')
uploadResponse = requests.put(fileUploadUrl.replace("+", "%2B"), f, headers={"x-ms-blob-type": "BlockBlob"})
print(uploadResponse.status_code)

# Commit submission
ingestionConnection.request("POST", "/v1.0/my/inappproducts/{0}/submissions/{1}/commit".format(inAppProductId, submissionId), "", headers)
commitResponse = ingestionConnection.getresponse()
print(commitResponse.status)
print(commitResponse.headers["MS-CorrelationId"])  # Log correlation ID
print(commitResponse.read())

# Pull submission status until commit process is completed
ingestionConnection.request("GET", "/v1.0/my/inappproducts/{0}/submissions/{1}/status".format(inAppProductId, submissionId), "", headers)
getSubmissionStatusResponse = ingestionConnection.getresponse()
submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
while submissionJsonObject["status"] == "CommitStarted":
    time.sleep(60)
    ingestionConnection.request("GET", "/v1.0/my/inappproducts/{0}/submissions/{1}/status".format(inAppProductId, submissionId), "", headers)
    getSubmissionStatusResponse = ingestionConnection.getresponse()
    submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
    print(submissionJsonObject["status"])

print(submissionJsonObject["status"])
print(submissionJsonObject)

ingestionConnection.close()
```

<span id="create-flight-submission" />
## パッケージ フライトの申請の作成とコミット

次の例は、[新しいパッケージ フライトの申請を作成し、コミット](manage-flight-submissions.md)する方法を示しています。

```python
import http.client, json, requests, time, zipfile

accessToken = ""  # Your access token
applicationId = ""  # Your application ID
flightId = ""  # Your flight ID
flightSubmissionRequestJson = ""  # Your submission request JSON
zipFilePath = r'*.zip'  # Your zip file path

headers = {"Authorization": "Bearer " + accessToken,
           "Content-type": "application/json",
           "User-Agent": "Python"}
ingestionConnection = http.client.HTTPSConnection("manage.devcenter.microsoft.com")

# Get flight
ingestionConnection.request("GET", "/v1.0/my/applications/{0}/flights/{1}".format(applicationId, flightId), "", headers)
flightResponse = ingestionConnection.getresponse()
print(flightResponse.status)
print(flightResponse.headers["MS-CorrelationId"])  # Log correlation ID

# Delete existing in-progress submission
flightJsonObject = json.loads(flightResponse.read().decode())
if "pendingFlightSubmission" in flightJsonObject :
    submissionToRemove = flightJsonObject["pendingFlightSubmission"]["id"]
    ingestionConnection.request("DELETE", "/v1.0/my/applications/{0}/flights/{1}/submissions/{2}".format(applicationId, flightId, submissionToRemove), "", headers)
    deleteSubmissionResponse = ingestionConnection.getresponse()
    print(deleteSubmissionResponse.status)
    print(deleteSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
    deleteSubmissionResponse.read()

# Create submission
ingestionConnection.request("POST", "/v1.0/my/applications/{0}/flights/{1}/submissions".format(applicationId, flightId), "", headers)
createSubmissionResponse = ingestionConnection.getresponse()
print(createSubmissionResponse.status)
print(createSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID

submissionJsonObject = json.loads(createSubmissionResponse.read().decode())
submissionId = submissionJsonObject["id"]
fileUploadUrl = submissionJsonObject["fileUploadUrl"]
print(submissionId)
print(fileUploadUrl)

# Update submission
ingestionConnection.request("PUT", "/v1.0/my/applications/{0}/flights/{1}/submissions/{2}".format(applicationId, flightId, submissionId), flightSubmissionRequestJson, headers)
updateSubmissionResponse = ingestionConnection.getresponse()
print(updateSubmissionResponse.status)
print(updateSubmissionResponse.headers["MS-CorrelationId"])  # Log correlation ID
updateSubmissionResponse.read()

# Upload images and packages in a zip file. Note that large file might need to be handled differently
f = open(zipFilePath, 'rb')
uploadResponse = requests.put(fileUploadUrl.replace("+", "%2B"), f, headers={"x-ms-blob-type": "BlockBlob"})
print(uploadResponse.status_code)


# Commit submission
ingestionConnection.request("POST", "/v1.0/my/applications/{0}/flights/{1}/submissions/{2}/commit".format(applicationId, flightId, submissionId), "", headers)
commitResponse = ingestionConnection.getresponse()
print(commitResponse.status)
print(commitResponse.headers["MS-CorrelationId"])  # Log correlation ID
print(commitResponse.read())

# Pull submission status until commit process is completed
ingestionConnection.request("GET", "/v1.0/my/applications/{0}/flights/{1}/submissions/{2}/status".format(applicationId, flightId, submissionId), "", headers)
getSubmissionStatusResponse = ingestionConnection.getresponse()
submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
while submissionJsonObject["status"] == "CommitStarted":
    time.sleep(60)
    ingestionConnection.request("GET", "/v1.0/my/applications/{0}/flights/{1}/submissions/{2}/status".format(applicationId, flightId, submissionId), "", headers)
    getSubmissionStatusResponse = ingestionConnection.getresponse()
    submissionJsonObject = json.loads(getSubmissionStatusResponse.read().decode())
    print(submissionJsonObject["status"])

print(submissionJsonObject["status"])
print(submissionJsonObject)

ingestionConnection.close()
```

## 関連トピック

* [Windows ストア サービスを使用した申請の作成と管理](create-and-manage-submissions-using-windows-store-services.md)



<!--HONumber=Aug16_HO5-->


