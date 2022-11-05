using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal interface IcapaDatos
    {
        int NumeroUsuario();
        bool BorraUsuario(string _cuenta);
        bool BorraUsuario(int _identificador);
    }
}