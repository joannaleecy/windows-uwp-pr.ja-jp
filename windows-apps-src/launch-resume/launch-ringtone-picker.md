---
title: ms-tonepicker スキーム
description: このトピックでは、ms-tonepicker URI スキームと、このスキームを使ってトーンの選択コントロールを表示し、トーンの選択、トーンの保存、トーンのフレンドリ名を取得する方法について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 0c17e4fb-7241-4da9-b457-d6d3a7aefccb
ms.localizationpriority: medium
ms.openlocfilehash: 293c755ecaf81ce80fab148a8aca92a7e3a8fa48
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57618587"
---
# <a name="choose-and-save-tones-using-the-ms-tonepicker-uri-scheme"></a>ms-tonepicker URI スキームを使ったトーンの選択と保存

このトピックでは、使用する方法を説明します、 **ms tonepicker:** URI スキーム。 この URI スキームを使って実行できる操作は次のとおりです。
- トーンの選択コントロールがデバイスにあるかどうかを確認します。
- トーンの選択コントロールを表示して、利用可能な着信音、システム サウンド、SMS 着信音、アラーム音の一覧を表示したり、ユーザーが選択したサウンドを表すトーン トークンを取得します。
- サウンド ファイル トークンを入力として受け取り、デバイスに保存するトーン セーバーを表示します。 保存されたトーンは、トーンの選択コントロールから利用できるようになります。 トーンにはフレンドリ名を付けることもできます。
- トーン トークンをフレンドリ名に変換します。

## <a name="ms-tonepicker-uri-scheme-reference"></a>ms-tonepicker:URI スキームの参照

この URI スキームは、URI スキーム文字列を利用して引数を渡すことはせず、[ValueSet](https://msdn.microsoft.com/library/windows/apps/windows.foundation.collections.valueset.aspx) を介して引数を渡します。 すべての文字列で、大文字と小文字が区別されます。

以下のセクションでは、特定のタスクを実行するために渡される引数を示します。

## <a name="task-determine-if-the-tone-picker-is-available-on-the-device"></a>タスク:トーン ピッカーが、デバイスで使用できるかを判断します。
```cs
var status = await Launcher.QueryUriSupportAsync(new Uri("ms-tonepicker:"),     
                                     LaunchQuerySupportType.UriForResults,
                                     "Microsoft.Tonepicker_8wekyb3d8bbwe");

if (status != LaunchQuerySupportStatus.Available)
{
    // the tone picker is not available
}
```

## <a name="task-display-the-tone-picker"></a>タスク:トーン ピッカーを表示します。

トーンの選択コントロールを表示するために渡すことができる引数は、次のとおりです。

| パラメーター | 種類 | 必須 | 設定可能な値 | 説明 |
|-----------|------|----------|-------|-------------|
| アクション | string | ○ | "PickRingtone" | トーン選択コントロールを開きます。 |
| CurrentToneFilePath | string | no | 既存のトーン トークン。 | トーンの選択コントロールに現在のトーンとして表示されるトーン。 この値が設定されていない場合、既定では、一覧の最初のトーンが選ばれます。<br>これは厳密にはファイル パスではありません。 トーンの選択コントロールから返された `ToneToken` の値から、`CurrenttoneFilePath` に適した値を取得できます。  |
| TypeFilter | string | no | "Ringtones"、"Notifications"、"Alarms"、"None" | 選択コントロールに追加するトーンを選択します。 フィルターが指定されていない場合は、すべてのトーンが表示されます。 |

[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。

| 戻り値 | 種類 | 設定可能な値 | 説明 |
|--------------|------|-------|-------------|
| 結果 | Int32 | 0 - 成功しました。 <br>1 - 取り消されました。 <br>7 - 無効なパラメーターです。 <br>8 - フィルター条件に一致するトーンがありません。 <br>255 - 指定された操作が実装されていません。 | 選択コントロールの操作の結果。 |
| ToneToken | string | 選択されたトーンのトークン。 <br>ユーザーが選択コントロールで**既定**を選択している場合、この文字列は空です。 | このトークンはトースト通知のペイロードで使用したり、任意の連絡先の着信音や SMS 着信音として割り当てたりすることができます。 **Result** が 0 の場合のみ、ValueSet にパラメーターが返されます。 |
| DisplayName | string | 指定したトーンのフレンドリ名。 | ユーザーに対して表示できる、選択されたトーンを表す文字列。 **Result** が 0 の場合のみ、ValueSet にパラメーターが返されます。 |


**例:ユーザーが、トーンを選択できるように、トーン ピッカーを開きます**

``` cs
LauncherOptions options = new LauncherOptions();
options.TargetApplicationPackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";

ValueSet inputData = new ValueSet() {
    { "Action", "PickRingtone" },
    { "TypeFilter", "Ringtones" } // Show only ringtones
};

LaunchUriResult result = await Launcher.LaunchUriForResultsAsync(new Uri("ms-tonepicker:"), options, inputData);

if (result.Status == LaunchUriStatus.Success)
{
     Int32 resultCode =  (Int32)result.Result["Result"];
     if (resultCode == 0)
     {
         string token = result.Result["ToneToken"] as string;
         string name = result.Result["DisplayName"] as string;
     }
     else
     {
           // handle failure
     }
}
```

## <a name="task-display-the-tone-saver"></a>タスク:トーン スクリーン セーバーを表示します。

トーン セーバーを表示するために渡すことができる引数は、次のとおりです。

| パラメーター | 種類 | 必須 | 設定可能な値 | 説明 |
|-----------|------|----------|-------|-------------|
| アクション | string | ○ | "SaveRingtone" | 選択コントロールを開いて着信音を保存します。 |
| ToneFileSharingToken | string | ○ | 保存する着信音ファイルの [SharedStorageAccessManager](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharedstorageaccessmanager.aspx) ファイル共有トークン。 | 特定のサウンド ファイルを着信音として保存します。 サポートされるファイル コンテンツの種類は、MPEG オーディオと x-ms-wma オーディオです。 |
| DisplayName | string | no | 指定したトーンのフレンドリ名。 | 指定した着信音を保存するときに使用する表示名を設定します。 |

[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。

| 戻り値 | 種類 | 設定可能な値 | 説明 |
|--------------|------|-------|-------------|
| 結果 | Int32 | 0 - 成功しました。<br>1 - ユーザーによって取り消されました。<br>2 - 無効なファイルです。<br>3 - 無効なファイル コンテンツの種類です。<br>4 - ファイルが着信音の最大サイズ (Windows 10 では 1 MB) を超えています。<br>5 - ファイルが 40 秒の長さ制限を超えています。<br>6 - ファイルがデジタル著作権管理によって保護されています。<br>7 - 無効なパラメーターです。 | 選択コントロールの操作の結果。 |

**例:着信音としてローカルの音楽ファイルを保存します。**

``` cs
LauncherOptions options = new LauncherOptions();
options.TargetApplicationPackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";

ValueSet inputData = new ValueSet() {
    { "Action", "SaveRingtone" },
    { "ToneFileSharingToken", SharedStorageAccessManager.AddFile(myLocalFile) }
};

LaunchUriResult result = await Launcher.LaunchUriForResultsAsync(new Uri("ms-tonepicker:"), options, inputData);

if (result.Status == LaunchUriStatus.Success)
{
     Int32 resultCode = (Int32)result.Result["Result"];

     if (resultCode == 0)
     {
         // no issues
     }
     else
     {
          switch (resultCode)
          {
             case 2:
              // The specified file was invalid
              break;
              case 3:
              // The specified file's content type is invalid
              break;
              case 4:
              // The specified file was too big
              break;
              case 5:
              // The specified file was too long
              break;
              case 6:
              // The file was protected by DRM
              break;
              case 7:
              // The specified parameter was incorrect
              break;
          }
      }
 }
```

## <a name="task-convert-a-tone-token-to-its-friendly-name"></a>タスク:トーン トークンをそのフレンドリ名に変換します。

トーンのフレンドリ名を取得するために渡すことができる引数は、次のとおりです。

| パラメーター | 種類 | 必須 | 設定可能な値 | 説明 |
|-----------|------|----------|-------|-------------|
| アクション | string | ○ | "GetToneName" | トーンのフレンドリ名を取得することを示します。 |
| ToneToken | string | ○ | トーンのトークン | 表示名を取得する対象となるトーン トークン。 |

[LaunchUriResults.Result](https://msdn.microsoft.com/library/windows/apps/windows.system.launchuriresult.result.aspx) に返される値は次のとおりです。

| 戻り値 | 種類 | 設定可能な値 | 説明 |
|--------------|------|-------|-------------|
| 結果 | Int32 | 0 - 選択コントロールの操作が成功しました。<br>7 - パラメーターが正しくありません (ToneToken が指定されていないなど)。<br>9 - 指定されたトークンの名前の読み取り中にエラーが発生しました。<br>10 - 指定されたトーン トークンが見つかりません。 | 選択コントロールの操作の結果。
| DisplayName | string | トーンのフレンドリ名。 | 指定されたトーンの表示名を返します。 **Result** が 0 の場合のみ、ValueSet にこのパラメーターが返されます。 |

**例:Contact.RingToneToken からトーン トークンを取得し、連絡先カードで、わかりやすい名前を表示します。**

```cs
using (var connection = new AppServiceConnection())
{
    connection.AppServiceName = "ms-tonepicker-nameprovider";
    connection.PackageFamilyName = "Microsoft.Tonepicker_8wekyb3d8bbwe";
    AppServiceConnectionStatus connectionStatus = await connection.OpenAsync();
    if (connectionStatus == AppServiceConnectionStatus.Success)
    {
        var message = new ValueSet() {
            { "Action", "GetToneName" },
            { "ToneToken", token)
        };
        AppServiceResponse response = await connection.SendMessageAsync(message);
        if (response.Status == AppServiceResponseStatus.Success)
        {
            Int32 resultCode = (Int32)response.Message["Result"];
            if (resultCode == 0)
            {
                string name = response.Message["DisplayName"] as string;
            }
            else
            {
                // handle failure
            }
        }
        else
        {
            // handle failure
        }
    }
}
```
