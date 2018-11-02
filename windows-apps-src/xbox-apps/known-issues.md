---
author: Mtoepke
title: Xbox 開発者プログラムの UWP の既知の問題
description: Xbox 開発者プログラムの UWP の既知の問題を示します。
ms.author: mstahl
ms.date: 03/29/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: a7b82570-1f99-4bc3-ac78-412f6360e936
ms.localizationpriority: medium
ms.openlocfilehash: 798192dd898af5a7107087b4a9708e1a1d0cb9b5
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5938985"
---
# <a name="known-issues-with-uwp-on-xbox-developer-program"></a>Xbox 開発者プログラムの UWP の既知の問題

このトピックでは、Xbox One 開発者プログラムの UWP の既知の問題について説明します。 このプログラムについて詳しくは、「[Xbox One の UWP](index.md)」をご覧ください。 

\[API リファレンス トピックのリンクからこのページを見つけた、ユニバーサル デバイス ファミリの API の情報を探している方は、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/?LinkID=760755)」をご覧ください。\]

以下では、発生する可能性のある既知の問題を示していますが、すべての問題は網羅されていません。 

**お客様からのフィードバックは重要ですので**、問題が見つかりましたら[ユニバーサル Windows プラットフォーム アプリの開発](https://social.msdn.microsoft.com/forums/windowsapps/home?forum=wpdevelop)フォーラムでご報告ください。 

行き詰まった場合は、このトピックの情報をお読みください。「[よく寄せられる質問](frequently-asked-questions.md)」を利用することも、フォーラムに質問を投稿することもできます。

 
## <a name="deploying-from-vs-fails-with-parental-controls-turned-on"></a>[保護者による制限] を有効にしたことにより VS からの展開に失敗する

本体で [設定] の [保護者による制限] を有効にした場合、VS からのアプリの起動が失敗します。

この問題を回避するには、[保護者による制限] を一時的に無効にするか、次の操作を行います。
1. [保護者による制限] を無効にして、本体にアプリを展開します。
2. [保護者による制限] 有効にします。
3. 本体からアプリを起動します。
4. アプリを起動できるように、PIN またはパスワードを入力します。
5. アプリが起動します。
6. アプリを閉じます。
7. F5 キーを使用して VS から起動すると、プロンプトを表示せずにアプリが起動します。

この時点では、アプリのアンインストールと再インストールを行っても、ユーザーをサインアウトさせるまで、アクセス許可は_固定_されます。
 
お子様のアカウントのみで利用できる、不適切なコンテンツの除外方法もあります。 お子様のアカウントでは、保護者がサインインしてアクセス許可を付与する必要がありますが、アクセス許可を付与するときに、保護者は、お子様によるアプリの起動を**常に許可**するように選ぶこともできます。 このような除外の情報はクラウドに保存され、お子様がサインアウトして、もう一度サインインした場合でも、維持されます。

## <a name="storagefilecopyasync-fails-to-copy-encrypted-files-to-unencrypted-destination"></a>StorageFile.CopyAsync で暗号化されていない宛先に暗号化されたファイルをコピーできない 

StorageFile.CopyAsync を使用して、暗号化されていない宛先に暗号化されたファイルをコピーする場合、次の例外が発生して呼び出しは失敗します。

```
System.UnauthorizedAccessException: Access is denied. (Excep_FromHResult 0x80070005)
```

これは、Xbox 開発者が、アプリ パッケージの一部として展開されているファイルを別の場所にコピーする場合に影響を及ぼす可能性があります。 この原因は、パッケージの内容が、Xbox の開発者モードではなく、リテール モードで暗号化されることです。 その結果、アプリは、開発およびテスト中には期待どおりに動作しているように見えますが、公開され、製品版の Xbox にインストールされると動作しない可能性があります。
 

## <a name="blocked-networking-ports-on-xbox-one"></a>Xbox One のネットワーク ポートのブロック

Xbox One デバイスでは、範囲 [57344, 65535] に含まれるポートへのユニバーサル Windows プラットフォーム (UWP) アプリのバインドは制限されています。 実行時にはこの範囲のポートへのバインドは成功しているように見えても、ネットワーク トラフィックはアプリに到達する前にエラーや警告なしで破棄される可能性があります。 できる限りポート 0 にアプリをバインドし、システムによってローカル ポートが選択されるようにしてください。 使用するポートを指定する必要がある場合は、範囲 [1025, 49151] 内のポート番号を使用する必要があります。この場合、IANA レジストリと競合しないように、確認してください。 詳しくは、[サービス名およびトランスポート プロトコル ポート番号のレジストリ](http://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml)についてのページをご覧ください。

## <a name="uwp-api-coverage"></a>UWP API カバレッジ

Xbox では、すべての UWP API がサポートされているわけではありません。 動作しないことが確認されている API の一覧については、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkId=760755)」をご覧ください。 他の API に問題が見つかった場合は、フォーラムでご報告ください。 


## <a name="navigating-to-wdp-causes-a-certificate-warning"></a>WDP に移動すると証明書の警告が表示される

提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One 本体によって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。 Windows Device Portal にアクセスするには、**[このサイトの閲覧を続行する]** をクリックします。

![Web サイトのセキュリティ証明書の警告](images/security_cert_warning.jpg)


## <a name="knownfoldersmediaserverdevices-caveat-on-xbox"></a>Xbox での KnownFolders.MediaServerDevices の注意事項

デスクトップでは、メディア サーバーが PC と "ペアリング" されており、どのサーバーが現在オンラインかをデバイス関連付けサービスが常に追跡しているため、初期ファイル システム クエリが現在オンラインのペアリング済みサーバーの一覧をすぐに返すことができます。

Xbox では、サーバーを追加または削除する UI がないため、初期ファイル システム クエリは常に空の一覧を返します。 クエリを作成して ContentsChanged イベントにサブスクライブし、通知を受け取るたびにクエリを更新する必要があります。 サーバーは少しずつ明らかになり、ほとんどは 3 秒以内に検出されます。

シンプルなサンプル コード:

```
namespace TestDNLA {

    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private async void FindFiles_Click(object sender, RoutedEventArgs e) {
            try {
                StorageFolder library = KnownFolders.MediaServerDevices;
                var folderQuery = library.CreateFolderQuery();
                folderQuery.ContentsChanged += FolderQuery_ContentsChanged;
                IReadOnlyList<StorageFolder> rootFolders = await folderQuery.GetFoldersAsync();
                if (rootFolders.Count == 0) {
                    Debug.WriteLine("No Folders found");
                } else {
                    Debug.WriteLine("Folders found");
                }
            } catch (Exception ex) {
                Debug.WriteLine("Error: " + ex.Message);
            } finally {
                Debug.WriteLine("Done");
            }
        }

        private async void FolderQuery_ContentsChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args) {
            Debug.WriteLine("Folder added " + sender.Folder.Name);
            IReadOnlyList<StorageFolder> topLevelFolders = await sender.Folder.GetFoldersAsync();
            foreach (StorageFolder topLevelFolder in topLevelFolders) {
                Debug.WriteLine(topLevelFolder.Name);
            }
        }
    }
}
```

## <a name="see-also"></a>関連項目
- [よく寄せられる質問](frequently-asked-questions.md)
- [Xbox One の UWP](index.md)
