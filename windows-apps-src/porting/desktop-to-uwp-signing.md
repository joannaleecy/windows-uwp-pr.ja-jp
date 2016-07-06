# 変換済みのデスクトップ アプリに署名する

この記事では、ユニバーサル Windows プラットフォーム (UWP) に変換したデスクトップ アプリに署名する方法について説明します。 .appx パッケージを展開する前に、証明書で署名する必要があります。

## .appx パッケージに署名する

最初に MakeCert.exe を使用して証明書を作成します。 パスワードの入力を求められた場合は、[なし] を選択します。 

```cmd
C:\> MakeCert.exe -r -h 0 -n "CN=<publisher_name>" -eku 1.3.6.1.5.5.7.3.3 -pe -sv <my.pvk> <my.cer>
```

次に、pvk2pfx.exe を使用して公開キーと秘密キーの情報を証明書にコピーします。 

```cmd
C:\> pvk2pfx.exe -pvk <my.pvk> -spc <my.cer> -pfx <my.pfx>
```
最後に、SignTool.exe を使用して、証明書で .appx に署名します。

```cmd
C:\> signtool.exe sign -f <my.pfx> -fd SHA256 -v .\<outputAppX>.appx
``` 

詳しくは、「[SignTool を使ってアプリ パッケージに署名する方法](https://msdn.microsoft.com/en-us/library/windows/desktop/jj835835(v=vs.85).aspx)」をご覧ください。 

上記の 3 つのツールはすべて Microsoft Windows 10 SDK に含まれています。 これらのツールを直接呼び出すには、コマンド プロンプトから ```C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat``` スクリプトを呼び出します。

## 一般的なエラー

### Authenticode 署名が破損しているか、形式が正しくない

このセクションでは、AppX パッケージ内の移植可能な実行可能ファイル (PE) で、Authenticode 署名が破損しているかまたは形式が正しくない問題を特定する方法について説明します。 任意のバイナリ形式 (.exe、.dll、.chm など) の PE ファイルに対する無効な Authenticode 署名によって、パッケージが正しく署名されない場合や、AppX パッケージから展開できない場合があります。 

PE ファイルの Authenticode 署名の場所は、Optional Header Data Directories の Certificate Table エントリおよび関連付けられている Attribute Certificate Table で指定されます。 署名を検証する場合、これらの構造体で指定されている情報を使用して、PE ファイルの署名を検出します。 これらの値が壊れている場合、ファイルの署名が無効であるように見える可能性があります。 

Authenticode 署名が正しいと見なされるには、Authenticode 署名が次の条件を満たしている必要があります。

- PE ファイル内の **WIN_CERTIFICATE** エントリの先頭は、実行可能ファイルの終わりを超えて拡張できない
- **WIN_CERTIFCATE** エントリは、イメージの最後に置かれている必要がある
- **WIN_CERTIFICATE** エントリのサイズは正の値である必要がある
- **WIN_CERTIFICATE** エントリは、32 ビット実行可能ファイルの場合は **IMAGE_NT_HEADERS32** 構造体の後、64 ビット実行可能ファイルの場合は IMAGE_NT_HEADERS64 構造体の後にある必要がある

詳しくは、[移植可能な実行可能ファイルの Authenticode 署名の仕様に関するドキュメント](http://download.microsoft.com/download/9/c/5/9c5b2167-8017-4bae-9fde-d599bac8184a/Authenticode_PE.docx)と [PE ファイル形式の仕様に関するページ](https://msdn.microsoft.com/en-us/windows/hardware/gg463119.aspx)をご覧ください。 

AppX パッケージに署名するときに、SignTool.exe で、壊れているバイナリや形式が正しくないバイナリの一覧を出力できます。 これを行うには、環境変数 APPXSIP_LOG を 1 に設定して (例: ```set APPXSIP_LOG=1```) 詳細なログを有効にし、SignTool.exe を再度実行します。

これらの形式が正しくないバイナリを修正するには、上記の要件に準拠していることを確認します。

## 参照

- [SignTool](https://msdn.microsoft.com/library/windows/desktop/aa387764(v=vs.85).aspx)
- [SignTool.exe (署名ツール)](https://msdn.microsoft.com/library/8s9b9yaz(v=vs.110).aspx)
- [SignTool を使ってアプリ パッケージに署名する方法](https://msdn.microsoft.com/en-us/library/windows/desktop/jj835835(v=vs.85).aspx)

<!--HONumber=Jun16_HO5-->


