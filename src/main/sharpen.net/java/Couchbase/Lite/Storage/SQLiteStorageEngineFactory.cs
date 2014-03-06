/**
 * Couchbase Lite for .NET
 *
 * Original iOS version by Jens Alfke
 * Android Port by Marty Schoch, Traun Leyden
 * C# Port by Zack Gramana
 *
 * Copyright (c) 2012, 2013, 2014 Couchbase, Inc. All rights reserved.
 * Portions (c) 2013, 2014 Xamarin, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using Couchbase.Lite.Storage;
using Sharpen;

namespace Couchbase.Lite.Storage
{
	public class SQLiteStorageEngineFactory
	{
		public static SQLiteStorageEngine CreateStorageEngine()
		{
			// Attempt to load a Storage Engine service.
			foreach (SQLiteStorageEngine storageEngine in ServiceLoader.Load<SQLiteStorageEngine
				>())
			{
				return storageEngine;
			}
			// Attempt to load a Storage Engine based on runtime.
			Properties properties = Runtime.GetProperties();
			string runtime = properties.GetProperty("java.runtime.name");
			if (runtime != null)
			{
				if (runtime.ToLower().Contains("android"))
				{
					return new AndroidSQLiteStorageEngine();
				}
			}
			// No Storage Engine found so return null.
			return null;
		}
	}
}