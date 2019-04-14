# Mk0.Tools.SQLiteTools
(C) 2019 mk0.at

Connect to SQLite DB
Usage: SQLiteConnection sql; sql.SQLiteConnect(fileName);

Disconnect from SQLite DB
Usage: sql.SQLiteDisconnect();

Disconnect from SQLite DB with VACCUM before disconnection
Usage: sql.SQLiteDisconnect(true);

Execute Query in SQLite DB (all but INSERTs)
Usage: sql.SQLiteExecute("query");
