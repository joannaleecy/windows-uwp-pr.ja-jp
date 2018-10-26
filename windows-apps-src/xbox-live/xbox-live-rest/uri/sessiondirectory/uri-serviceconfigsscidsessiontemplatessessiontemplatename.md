---
title: /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}
assetID: cc306ca0-57f8-f676-6d4b-f9ddd716dcc0
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatename.html
author: KevinAsgari
description: " /serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 52c7396db75d44a46b6ec03c592b29ea87224301
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5568785"
---
# <a name="serviceconfigsscidsessiontemplatessessiontemplatename"></a>/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}
セッション テンプレート名のセットを取得する GET 操作をサポートしています。 
<a id="ID4EO"></a>

 
## <a name="domain"></a>ドメイン
sessiondirectory.xboxlive.com  
<a id="ID4ET"></a>

 
## <a name="uri-parameters"></a>URI パラメーター
 
| パラメーター| 型| 説明| 
| --- | --- | --- | 
| scid| GUID| サービス構成の識別子 (SCID)。 パート 1 セッションの id。| 
| sessionTemplateName| string| セッション テンプレートの現在のインスタンスの名前です。 パート 2、セッションの id。 | 
  
<a id="ID4EYB"></a>

 
## <a name="valid-methods"></a>有効なメソッド

[GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName})](uri-serviceconfigsscidsessiontemplatessessiontemplatenameget.md)

&nbsp;&nbsp;一連のセッション テンプレート名を取得します。
 
<a id="ID4ECC"></a>

 
## <a name="see-also"></a>関連項目
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a>Parent 

[セッション ディレクトリ URI](atoc-reference-sessiondirectory.md)

   