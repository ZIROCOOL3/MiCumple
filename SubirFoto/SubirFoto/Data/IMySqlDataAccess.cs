using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubirFoto.Data
{
    public interface IMySqlDataAccess
    {
        Task SaveData<T>(string sql, T parameters, string connectionString);
    }
}
