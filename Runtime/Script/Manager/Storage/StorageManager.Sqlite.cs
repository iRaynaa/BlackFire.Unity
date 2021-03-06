/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.DB;

namespace BlackFire.Unity
{
    public sealed partial class StorageManager
    {
        public IConnection CreateConnection(string connectionAlias, string databasePath)
        {
            return m_SqliteModule.CreateConnection(connectionAlias, databasePath);
        }

        public IConnection AcquireConnection(string connectionAlias)
        {
            return m_SqliteModule.AcquireConnection(connectionAlias);
        }

        public void CloseConnection(string connectionAlias)
        {
            m_SqliteModule.CloseConnection(connectionAlias);
        }
    }        
}