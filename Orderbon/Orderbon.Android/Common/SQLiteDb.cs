﻿using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Orderbon.Droid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Orderbon.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}

