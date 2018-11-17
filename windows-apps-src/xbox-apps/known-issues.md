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
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7173575"
---
# <a name="known-issues-with-uwp-on-xbox-developer-program"></a><span data-ttu-id="04915-104">Xbox 開発者プログラムの UWP の既知の問題</span><span class="sxs-lookup"><span data-stu-id="04915-104">Known issues with UWP on Xbox Developer Program</span></span>

<span data-ttu-id="04915-105">このトピックでは、Xbox One 開発者プログラムの UWP の既知の問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="04915-105">This topic describes known issues with the UWP on Xbox One Developer Program.</span></span> <span data-ttu-id="04915-106">このプログラムについて詳しくは、「[Xbox One の UWP](index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04915-106">For more information about this program, see [UWP on Xbox](index.md).</span></span> 

<span data-ttu-id="04915-107">\[API リファレンス トピックのリンクからこのページを見つけた、ユニバーサル デバイス ファミリの API の情報を探している方は、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/?LinkID=760755)」をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="04915-107">\[If you came here from a link in an API reference topic, and are looking for Universal device family API information, please see [UWP features that aren't yet supported on Xbox](http://go.microsoft.com/fwlink/?LinkID=760755).\]</span></span>

<span data-ttu-id="04915-108">以下では、発生する可能性のある既知の問題を示していますが、すべての問題は網羅されていません。</span><span class="sxs-lookup"><span data-stu-id="04915-108">The following list highlights some known issues that you may encounter, but this list is not exhaustive.</span></span> 

<span data-ttu-id="04915-109">**お客様からのフィードバックは重要ですので**、問題が見つかりましたら[ユニバーサル Windows プラットフォーム アプリの開発](https://social.msdn.microsoft.com/forums/windowsapps/home?forum=wpdevelop)フォーラムでご報告ください。</span><span class="sxs-lookup"><span data-stu-id="04915-109">**We want to get your feedback**, so please report any issues that you find on the [Developing Universal Windows Platform apps](https://social.msdn.microsoft.com/forums/windowsapps/home?forum=wpdevelop) forum.</span></span> 

<span data-ttu-id="04915-110">行き詰まった場合は、このトピックの情報をお読みください。「[よく寄せられる質問](frequently-asked-questions.md)」を利用することも、フォーラムに質問を投稿することもできます。</span><span class="sxs-lookup"><span data-stu-id="04915-110">If you get stuck, read the information in this topic, see [Frequently asked questions](frequently-asked-questions.md), and use the forums to ask for help.</span></span>

 
## <a name="deploying-from-vs-fails-with-parental-controls-turned-on"></a><span data-ttu-id="04915-111">[保護者による制限] を有効にしたことにより VS からの展開に失敗する</span><span class="sxs-lookup"><span data-stu-id="04915-111">Deploying from VS fails with Parental Controls turned on</span></span>

<span data-ttu-id="04915-112">本体で [設定] の [保護者による制限] を有効にした場合、VS からのアプリの起動が失敗します。</span><span class="sxs-lookup"><span data-stu-id="04915-112">Launching your app from VS will fail if the console has Parental Controls turned on in Settings.</span></span>

<span data-ttu-id="04915-113">この問題を回避するには、[保護者による制限] を一時的に無効にするか、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="04915-113">To work around this issue, either temporarily disable Parental Controls, or:</span></span>
1. <span data-ttu-id="04915-114">[保護者による制限] を無効にして、本体にアプリを展開します。</span><span class="sxs-lookup"><span data-stu-id="04915-114">Deploy your app to the console with Parental Controls turned off.</span></span>
2. <span data-ttu-id="04915-115">[保護者による制限] 有効にします。</span><span class="sxs-lookup"><span data-stu-id="04915-115">Turn on Parental Controls.</span></span>
3. <span data-ttu-id="04915-116">本体からアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="04915-116">Launch your app from the console.</span></span>
4. <span data-ttu-id="04915-117">アプリを起動できるように、PIN またはパスワードを入力します。</span><span class="sxs-lookup"><span data-stu-id="04915-117">Enter a PIN or password to allow the app to launch.</span></span>
5. <span data-ttu-id="04915-118">アプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="04915-118">App will launch.</span></span>
6. <span data-ttu-id="04915-119">アプリを閉じます。</span><span class="sxs-lookup"><span data-stu-id="04915-119">Close the app.</span></span>
7. <span data-ttu-id="04915-120">F5 キーを使用して VS から起動すると、プロンプトを表示せずにアプリが起動します。</span><span class="sxs-lookup"><span data-stu-id="04915-120">Launch from VS using F5, and the app will launch with no prompting.</span></span>

<span data-ttu-id="04915-121">この時点では、アプリのアンインストールと再インストールを行っても、ユーザーをサインアウトさせるまで、アクセス許可は_固定_されます。</span><span class="sxs-lookup"><span data-stu-id="04915-121">At this point the permission is _sticky_ until you sign the user out, even if you uninstall and reinstall the app.</span></span>
 
<span data-ttu-id="04915-122">お子様のアカウントのみで利用できる、不適切なコンテンツの除外方法もあります。</span><span class="sxs-lookup"><span data-stu-id="04915-122">There is another type of exemption that is only available for child accounts.</span></span> <span data-ttu-id="04915-123">お子様のアカウントでは、保護者がサインインしてアクセス許可を付与する必要がありますが、アクセス許可を付与するときに、保護者は、お子様によるアプリの起動を**常に許可**するように選ぶこともできます。</span><span class="sxs-lookup"><span data-stu-id="04915-123">A child account requires a parent to sign in to grant permission, but when they do, the parent has the option of choosing to **Always** allow the child to launch the app.</span></span> <span data-ttu-id="04915-124">このような除外の情報はクラウドに保存され、お子様がサインアウトして、もう一度サインインした場合でも、維持されます。</span><span class="sxs-lookup"><span data-stu-id="04915-124">That exemption is stored in the cloud and will persist even if the child signs out and signs back in.</span></span>

## <a name="storagefilecopyasync-fails-to-copy-encrypted-files-to-unencrypted-destination"></a><span data-ttu-id="04915-125">StorageFile.CopyAsync で暗号化されていない宛先に暗号化されたファイルをコピーできない</span><span class="sxs-lookup"><span data-stu-id="04915-125">StorageFile.CopyAsync fails to copy encrypted files to unencrypted destination</span></span> 

<span data-ttu-id="04915-126">StorageFile.CopyAsync を使用して、暗号化されていない宛先に暗号化されたファイルをコピーする場合、次の例外が発生して呼び出しは失敗します。</span><span class="sxs-lookup"><span data-stu-id="04915-126">When StorageFile.CopyAsync is used to copy a file that is encrypted to a destination that is not encrypted, the call will fail with the following exception:</span></span>

```
System.UnauthorizedAccessException: Access is denied. (Excep_FromHResult 0x80070005)
```

<span data-ttu-id="04915-127">これは、Xbox 開発者が、アプリ パッケージの一部として展開されているファイルを別の場所にコピーする場合に影響を及ぼす可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04915-127">This can affect Xbox developers who want to copy files that are deployed as part of their app package to another location.</span></span> <span data-ttu-id="04915-128">この原因は、パッケージの内容が、Xbox の開発者モードではなく、リテール モードで暗号化されることです。</span><span class="sxs-lookup"><span data-stu-id="04915-128">The reason for this is that the package contents are encrypted on an Xbox in retail mode, but not in Dev Mode.</span></span> <span data-ttu-id="04915-129">その結果、アプリは、開発およびテスト中には期待どおりに動作しているように見えますが、公開され、製品版の Xbox にインストールされると動作しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04915-129">As a result, the app may appear to work as expected during development and testing, but then fail once it has been published and then installed to a retail Xbox.</span></span>
 

## <a name="blocked-networking-ports-on-xbox-one"></a><span data-ttu-id="04915-130">Xbox One のネットワーク ポートのブロック</span><span class="sxs-lookup"><span data-stu-id="04915-130">Blocked networking ports on Xbox One</span></span>

<span data-ttu-id="04915-131">Xbox One デバイスでは、範囲 [57344, 65535] に含まれるポートへのユニバーサル Windows プラットフォーム (UWP) アプリのバインドは制限されています。</span><span class="sxs-lookup"><span data-stu-id="04915-131">Universal Windows Platform (UWP) apps on Xbox One devices are restricted from binding to ports in the range [57344, 65535], inclusive.</span></span> <span data-ttu-id="04915-132">実行時にはこの範囲のポートへのバインドは成功しているように見えても、ネットワーク トラフィックはアプリに到達する前にエラーや警告なしで破棄される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="04915-132">Although binding to these ports might appear to succeed at run-time, network traffic can be silently dropped before reaching your app.</span></span> <span data-ttu-id="04915-133">できる限りポート 0 にアプリをバインドし、システムによってローカル ポートが選択されるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="04915-133">Your app should bind to port 0 wherever possible, which allows the system to select the local port.</span></span> <span data-ttu-id="04915-134">使用するポートを指定する必要がある場合は、範囲 [1025, 49151] 内のポート番号を使用する必要があります。この場合、IANA レジストリと競合しないように、確認してください。</span><span class="sxs-lookup"><span data-stu-id="04915-134">If you need to use a specific port, the port number must be in the range [1025, 49151], and you should check and avoid conflicts with the IANA registry.</span></span> <span data-ttu-id="04915-135">詳しくは、[サービス名およびトランスポート プロトコル ポート番号のレジストリ](http://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml)についてのページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04915-135">For more information, see the [Service Name and Transport Protocol Port Number Registry](http://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml).</span></span>

## <a name="uwp-api-coverage"></a><span data-ttu-id="04915-136">UWP API カバレッジ</span><span class="sxs-lookup"><span data-stu-id="04915-136">UWP API coverage</span></span>

<span data-ttu-id="04915-137">Xbox では、すべての UWP API がサポートされているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="04915-137">Not all UWP APIs are supported on Xbox.</span></span> <span data-ttu-id="04915-138">動作しないことが確認されている API の一覧については、「[Xbox でまだサポートされていない UWP 機能](http://go.microsoft.com/fwlink/p/?LinkId=760755)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04915-138">For the list of APIs that we know don’t work, see [UWP features that aren't yet supported on Xbox](http://go.microsoft.com/fwlink/p/?LinkId=760755).</span></span> <span data-ttu-id="04915-139">他の API に問題が見つかった場合は、フォーラムでご報告ください。</span><span class="sxs-lookup"><span data-stu-id="04915-139">If you find issues with other APIs, please report them on the forums.</span></span> 


## <a name="navigating-to-wdp-causes-a-certificate-warning"></a><span data-ttu-id="04915-140">WDP に移動すると証明書の警告が表示される</span><span class="sxs-lookup"><span data-stu-id="04915-140">Navigating to WDP causes a certificate warning</span></span>

<span data-ttu-id="04915-141">提供された証明書についての、次のスクリーン ショットのような警告が表示されます。これは、Xbox One 本体によって署名されたセキュリティ証明書が、既知の信頼された発行元とは見なされないためです。</span><span class="sxs-lookup"><span data-stu-id="04915-141">You will receive a warning about the certificate that was provided, similar to the following screenshot, because the security certificate signed by your Xbox One console is not considered a well-known trusted publisher.</span></span> <span data-ttu-id="04915-142">Windows Device Portal にアクセスするには、**[このサイトの閲覧を続行する]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="04915-142">To access the Windows Device Portal, click **Continue to this website**.</span></span>

![Web サイトのセキュリティ証明書の警告](images/security_cert_warning.jpg)


## <a name="knownfoldersmediaserverdevices-caveat-on-xbox"></a><span data-ttu-id="04915-144">Xbox での KnownFolders.MediaServerDevices の注意事項</span><span class="sxs-lookup"><span data-stu-id="04915-144">KnownFolders.MediaServerDevices caveat on Xbox</span></span>

<span data-ttu-id="04915-145">デスクトップでは、メディア サーバーが PC と "ペアリング" されており、どのサーバーが現在オンラインかをデバイス関連付けサービスが常に追跡しているため、初期ファイル システム クエリが現在オンラインのペアリング済みサーバーの一覧をすぐに返すことができます。</span><span class="sxs-lookup"><span data-stu-id="04915-145">On Desktop, media servers are “paired” with the PC, and the Device Association Service is constantly tracking which of the servers are currently on-line, so an initial file system query can immediately return a list of the paired servers that are currently online.</span></span>

<span data-ttu-id="04915-146">Xbox では、サーバーを追加または削除する UI がないため、初期ファイル システム クエリは常に空の一覧を返します。</span><span class="sxs-lookup"><span data-stu-id="04915-146">On Xbox, there is no UI to add or remove servers, so the initial file system query will always return empty.</span></span> <span data-ttu-id="04915-147">クエリを作成して ContentsChanged イベントにサブスクライブし、通知を受け取るたびにクエリを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04915-147">You must create a query and subscribe to the ContentsChanged event and refresh the query each time you get a notification.</span></span> <span data-ttu-id="04915-148">サーバーは少しずつ明らかになり、ほとんどは 3 秒以内に検出されます。</span><span class="sxs-lookup"><span data-stu-id="04915-148">Servers will trickle in and most will have been discovered within 3 seconds.</span></span>

<span data-ttu-id="04915-149">シンプルなサンプル コード:</span><span class="sxs-lookup"><span data-stu-id="04915-149">Simple example code:</span></span>

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

## <a name="see-also"></a><span data-ttu-id="04915-150">関連項目</span><span class="sxs-lookup"><span data-stu-id="04915-150">See also</span></span>
- [<span data-ttu-id="04915-151">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="04915-151">Frequently asked questions</span></span>](frequently-asked-questions.md)
- [<span data-ttu-id="04915-152">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="04915-152">UWP on Xbox One</span></span>](index.md)
