using LibreriaDeClases;
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
        bool ContainsUsuario(Usuario usuario);
        bool ContainsUsuario(int id);
        Usuario LeeUsuario(int id);
        Usuario LeeUsuario(string email);
        bool BorraUsuario(string email);
        bool BorrarUsuario(Usuario usuario);
        bool BorrarUsuario(int _identificador);
        bool InsertarUsuario(Usuario usuario);

        int NumeroEntradas();
        bool ContieneEntrada(Entrada entrada);
        bool ContieneEntrada(int id);
        Entrada LeeEntrada(int id);
        bool BorraEntrada(int id);
        bool BorraEntrada(Entrada entrada);
        bool InsertarEntrada(Entrada entrada);


        int NumeroEntradasLog();
        bool ContainsEntradaLog(EntradaLog entradaLog);
        bool ContainsEntradaLog(int id);
        EntradaLog LeeEntradaLog(int id);
        bool BorraEntradaLog(int id);
        bool BorraEntradaLog(EntradaLog entradaLog);
        bool InsertarEntradaLog(EntradaLog entradalog);
    }
}