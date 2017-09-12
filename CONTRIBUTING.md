# <a name="contributing-to-uwp-conceptual-documentation"></a>UWP の概念に関するドキュメントへの投稿

ユニバーサル Windows プラットフォーム (UWP) に関するドキュメントに関心をお寄せいただき、ありがとうございます。 ドキュメントへのフィードバック、編集、追加に感謝いたします。

このページでは、当社の開発者向けドキュメントへの投稿の基本的な手順について説明します。

## <a name="public-and-private-repos"></a>パブリックおよびプライベートのリポジトリ

UWP の概念に関するドキュメントは、2 つの異なるリポジトリでホストされ、それらがマージされて 1 つのサイトとして更新されます。1 つはすべてのユーザーが投稿できるリポジトリで、もう 1 つはマイクロソフトの従業員専用のリポジトリです。

マイクロソフトの従業員***ではない***場合は、[パブリック コンテンツ リポジトリ](https://github.com/MicrosoftDocs/windows-uwp)をご利用ください。

マイクロソフトの従業員***である***場合は、パブリック リポジトリと[プライベート コンテンツ リポジトリ](https://cpubwin.visualstudio.com/_git/windows-uwp)のどちらでも作業できます。 従業員は、プライベート リポジトリを投稿することによって若干速く変更を反映することや、当分の間、非公開にしておく必要がある変更については[特定のブランチ](https://review.docs.microsoft.com/en-us/windows-authoring-guide/uwp/conceptual/setup-local-repo-for-large-changes#what-branch-should-i-use-for-my-authoring)を使用することができます。

## <a name="editing-topics-on-the-public-repo"></a>パブリック リポジトリにあるトピックの編集

既存のファイルの編集ができるだけ簡単になるように努めてきました。 
- 既にリポジトリをご利用の場合は、ファイルに移動し、**[編集]** ボタンをクリックするだけです。  
- ブラウザーで Docs.microsoft.com ページを表示している場合は、ページの右上にある **[編集]** ボタンをクリックします。 リポジトリ内の適切なマークダウン ソース ファイルにリダイレクトされ、**[編集]** ボタンをクリックできます。 

GitHub では、公式のリポジトリが個人用 GitHub アカウントに自動的にフォークされ、そのアカウントで変更を加えることができます。 完了したら、"docs" ブランチに戻すプル要求を提出します。 プル要求を作成した後、UWP ドキュメント チームのメンバーが変更内容を確認します。 要求が受理された場合、更新が https://docs.microsoft.com/windows/ に公開されます。

マークダウンの基本事項はほんの数分で学習できます。  最初に、[マークダウンの概要に関するページ](https://guides.github.com/features/mastering-markdown/)をご覧ください。

## <a name="making-more-substantial-changes"></a>さらに大幅な変更を加える

既存の記事を大幅に変更する、画像を追加または変更する、新しい記事を投稿する場合は、マイクロソフトのプライベート リポジトリのローカルの複製を作成する必要があります。 [Windows オーサリング ガイドの手順](https://review.docs.microsoft.com/en-us/windows-authoring-guide/uwp/conceptual/)に従ってください。 まだ GitHub アカウントを設定していない場合や、Microsoft エイリアスをドメインに参加していない場合は、[ここから開始](https://review.docs.microsoft.com/en-us/windows-authoring-guide/github-account)します。

## <a name="using-issues-to-provide-feedback-on-uwp-conceptual-documentation"></a>懸案事項を使用して UWP の概念に関するドキュメントへのフィードバックを提供する

実際のドキュメント ページを直接変更するではなく、フィードバックを提供する場合は、[パブリック リポジトリで懸案事項を作成](https://github.com/MicrosoftDocs/windows-uwp/issues)します。 [Issues] (懸案事項) タブをクリックし、**[New issue]** (新しい懸案事項) ボタンをクリックします。 必ずトピックのタイトルとページの URL を含めてください。

UWP ドキュメント チームのメンバーが懸案事項を定期的に確認し、懸案事項の優先順位付け、割り当てを行い、適切に対処します。

*内部の懸案事項については、WDG Content Request Tool ([http://aka.ms/pubrequest](http://aka.ms/pubrequest)) を利用してください。 
