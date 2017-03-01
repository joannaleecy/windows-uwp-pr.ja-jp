---
author: mcleblanc
ms.assetid: bf0a8b01-79f1-4944-9d78-9741e235dbe9
title: "Xbox 用 Device Portal"
description: "Xbox One 向けの Device Portal を有効にする方法について説明します。"
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 4321e799e8633dc31cc0d73889a0b0b6056f6d3b
ms.lasthandoff: 02/07/2017

---
# <a name="device-portal-for-xbox"></a>Xbox 用 Device Portal


## <a name="set-up-device-portal-on-xbox"></a>Xbox で Device Portal をセットアップする

### <a name="enable-device-portal"></a>Device Portal を有効にする

**Device Portal を有効にするには**

1. ホーム画面で [Dev Home] タイルを選択します (画像を参照)。  
![Device Portal の DevHome](images/device-portal/xbox-dev-home-tile.png)
2. [Dev Home] 内の **[Remote Management]** ツールに移動します ![Device Portal RemoteManagement ツール](images/device-portal/xbox-remote-management-tool.png)
3. **[Manage Windows Device Portal** (Windows Device Portal の管理]) を選択し、**[A]** を押します。
4. **[Enable Windows Device Portal]** (Windows Device Portal を有効にする) 設定をオンにします。
5. ブラウザーから devkit へのアクセスを認証するために使うユーザー名とパスワードを入力し、保存します。
6. 設定ページを閉じ、[Remote Management] (リモート管理) ツールに表示された URL を記録します。
7. URL をブラウザーに入力し、構成した資格情報でサインインします。
8. 提供された証明書に関して、次の図のような警告が表示されます。 プレビューで Windows Device Portal にアクセスするには、**[このサイトの閲覧を続行する]** をクリックする必要があります。
![Device Portal の証明書エラー](images/device-portal/xbox-certificate-error.png)

## <a name="device-portal-pages"></a>Device Portal のページ

Xbox の Device Portal では、一連の標準ページが提供されます。 詳しい説明については、「[Windows Device Portal の概要](device-portal.md)」をご覧ください。

- アプリ
- パフォーマンス
- ネットワーク

