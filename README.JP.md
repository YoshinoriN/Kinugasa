# Kinugasa - 衣笠

自分向けのオレオレ.NET Frameworkライブラリ。

# 目的
* コード設計のお勉強
* 英語のお勉強
    * コードのコメントからドキュメントまで基本英語で記述するように頑張る。
* .NET FrameworkとC#のお勉強
* 各種CIサービスの利用と連携を試してみる

# CI ステータス

|目的|利用サービス|状態|備考|
|---|---|---|---|
|ビルドとテスト|AppVeyor|[![Build status](https://ci.appveyor.com/api/projects/status/mk3thjjapkd1u444/branch/master?svg=true)](https://ci.appveyor.com/project/YoshinoriN/kinugasa)|UWPがなぜかビルド通らないのでいつも落ちてる|
|monoでのビルド|TravisCI|計画中||
|静的解析|CodeClimate|[![Issue Count](https://codeclimate.com/github/YoshinoriN/Kinugasa/badges/issue_count.svg)](https://codeclimate.com/github/YoshinoriN/Kinugasa)||
|静的解析|SonarQube|計画中||
|テストカバー率|Coveralls|計画中||

# 開発環境
* C# 6
* Visual Studio Community 2015
* MSTest （Visual Studio Community 2015 のものを使用）

# 対応 .NET Framework バージョン
* 4.5 以上

# 外部依存ライブラリ
現状なし。

# アプリケーションのビルドパス
全てのプロジェクトのアセンブリファイルは `root/bin/` ディレクトリ配下に出力されます。