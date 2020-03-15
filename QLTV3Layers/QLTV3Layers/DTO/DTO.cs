using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nghe
    {
        public static string _maNghe, _tenNghe;
        
        // Properties
        public string MaNghe
        {
            get { return _maNghe; }
            set { _maNghe = value; }
        }
        public string TenNghe
        {
            get { return _tenNghe; }
            set { _tenNghe = value; }
        }
    }

}
