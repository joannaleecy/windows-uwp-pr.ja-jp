---
author: DelfCo
Description: "このトピックでは、エンタープライズ データ保護 (EDP) のシナリオでネットワーク接続を作成する前に、保護されたスレッド コンテキストを作成する方法を説明します。"
MS-HAID: dev\_networking.tagging\_network\_connections\_with\_edp\_identity
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "EDP ID を使ったネットワーク接続のタグ付け"
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 2b960bbb5cf58991778e5c20bb915a202ecf6e04

---

# EDP ID を使ったネットワーク接続のタグ付け

__注__ Windows 10 バージョン 1511 (ビルド 10586) またはそれ以前のバージョンでは、エンタープライズ データ保護 (EDP) ポリシーを適用できません。

このトピックでは、エンタープライズ データ保護 (EDP) のシナリオでネットワーク接続を作成する前に、保護されたスレッド コンテキストを作成する方法を説明します。 EDP とファイル、ストリーム、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係についての開発者向けの詳しい情報については、「[エンタープライズ データ保護 (EDP)](../enterprise/edp-hub.md)」をご覧ください。

**注**  [エンタープライズ データ保護 (EDP) のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)に関するページでは、多くの EDP のシナリオを紹介しています。



## 前提条件


-   **EDP の設定を行う**

    「[EDP のためのコンピューターの設定](../enterprise/edp-hub.md#set-up-your-computer-for-EDP)」をご覧ください。

-   **エンタープライズ対応アプリの作成に取り組む**

    企業データがそれを管理する企業の制御下に置かれている状態が自律的に確保されるアプリをエンタープライズ対応アプリと呼びます。 対応アプリは非対応アプリより強力かつスマートで、柔軟性と信頼性の面でもより優れています。 アプリが対応アプリであることをシステムに知らせるには、制限された **enterpriseDataPolicy** 機能を宣言します。 ただし、アプリを対応アプリにするために必要なことは機能の設定だけではありません。 詳しくは、「[エンタープライズ対応アプリ](../enterprise/edp-hub.md#enterprise-enlightened-apps)」をご覧ください。

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C\# や Visual Basic での非同期アプリの作成方法については、「[C\# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

## ネットワーク経由で企業リソースへのアクセス


このシナリオでは、先進的なメール アプリで、企業と個人の両方のメールボックスが混在している一連のメールボックスを同期しています。 このアプリは、ユーザーの ID を [**ProtectionPolicyManager.CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706025) の呼び出しに渡して、保護されたスレッド コンテキストを作成します。 これにより、同じスレッドでそれ以降作成されるすべてのネットワーク接続にその ID のタグが付けられ、企業のポリシーでのアクセス制御されている企業ネットワークのリソースへのアクセスが許可されます。

ここでの "企業" は、ユーザー ID が属している企業を指します。 [
              **CreateCurrentThreadNetworkContext**
            ](https://msdn.microsoft.com/library/windows/apps/dn706025) は、ポリシーの実施とは関係なく、[**ThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706029) オブジェクトを返します。 一般的に、アプリで混在リソースを処理することが予想される場合、すべての ID について **CreateCurrentThreadNetworkContext** を呼び出すことができます。 ネットワーク リソースを取得した後、アプリは **ThreadNetworkContext** の **Dispose** を呼び出して、現在のスレッドからすべての ID タグを消去します。 コンテキスト オブジェクトを破棄するためのパターンは、プログラミング言語によって異なります。

ID が不明な場合は、アプリで [**ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync**](https://msdn.microsoft.com/library/windows/apps/dn706027) API を使って、リソースのネットワーク アドレスからエンタープライズ ポリシーで管理される ID を照会できます。

**注**  コード例に示されているように、[**CreateCurrentThreadNetworkContext**](https://msdn.microsoft.com/library/windows/apps/dn706025) の正しい使用パターンは、有効なスコープを最小限にしておくことです。 エンタープライズ ネットワーク コンテキストを設定し、ネットワーク接続を作成したら、コンテキストを元に戻してから、その接続を使います。その後、接続を閉じます。 その詳細は次のコード例で示しています。 重要なのは、エンタープライズ ネットワーク コンテキストがスレッドで設定されている間は、そのスレッドでファイルを作成しないことです。 作成すると、そのファイルは個人用であるかどうかに関係なく、自動的に暗号化されます。 これは、できる限り早くコンテキストを戻すことをお勧めしている理由の 1 つです。



```CSharp
using Windows.Data.Xml.Dom;
using Windows.Networking;
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;
using Windows.Web.Http;

...

public static async void SyncMailbox(string identity)
{
    HttpClient client = null;
    // Create a protected network context for "identity" on the current
    // thread. Network connections made after this call will be tagged
    // to "identity", and will have policy enforced. This is required
    // to access enterprise network resources for "identity".
    using (ThreadNetworkContext threadNetworkContext = 
        ProtectionPolicyManager.CreateCurrentThreadNetworkContext(identity))
    {
        // Retrieve new mail.
        client = new HttpClient();
    }

    string xmlResponse = await client.GetStringAsync
        (new Uri("https://contosomail/getnewmail?user=" + identity));

    // Now, process mail data received.
    var xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(xmlResponse);
    foreach (IXmlNode mailNode in xmlDocument.GetElementsByTagName("mail"))
    {
        // Code to process text data in mail (body, recipients etc.)
        // would go here ...

        // Processes resource links in mail body.
        foreach (IXmlNode childNode in mailNode.ChildNodes)
        {
            if (childNode.NodeName == "resource")
            {
                var resourceUri = new Uri(childNode.InnerText);

                // Check if the resource is on an enterprise-managed endpoint.
                string resourceIdentity =
                    await ProtectionPolicyManager.GetPrimaryManagedIdentityForNetworkEndpointAsync
                        (new HostName(resourceUri.Host));
                if (!string.IsNullOrEmpty(resourceIdentity))
                {
                    using (ThreadNetworkContext threadNetworkContext =
                        ProtectionPolicyManager.CreateCurrentThreadNetworkContext(resourceIdentity))
                    {
                        client = new HttpClient();
                    }
                    IBuffer data = await client.GetBufferAsync(resourceUri);
                    // Code to process retrieved resource data would go here...
                }
            }
        }
    }
}
```

**注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。



## 関連トピック


[エンタープライズ データ保護 (EDP) のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData 名前空間**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 






<!--HONumber=Jun16_HO4-->


