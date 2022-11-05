using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Sockets;
using LibreriaDeClases;

//POR QUE NO ME ACEPTA EL PAQUETE DE LIBRERIA DE CLASES ??????

namespace DBPruebas
{
    public class DBPruebas : IcapaDatos
    {
        //Lista user , lista entradas ,EntradaLog 

        private int idUser = -1;
        private int idEntrada = -1;
        private int idLog = -1;
        private SortedList<int, Usuario> tblUsuario = new SortedList<int, Usuario>();
        private SortedList<int, Entrada> tblEntrada = new SortedList<int, Entrada>();
        private SortedList<int, EntradaLog> tblEntradaLog = new SortedList<int, EntradaLog>();


        /// <summary>
        ///NUMERO DE USUARIOS 
        /// </summary>
        /// <returns></returns>
        public int NumeroUsuario()
        {
            return tblUsuario.Count;
        }

        /// <summary>
        /// NUMERO DE ENTRADAS
        /// </summary>
        /// <returns></returns>
        public int NumeroEntradas()
        {
            return tblEntrada.Count;
        }

        /// <summary>
        ///NUMERO DE ENTRADAS LOG
        /// </summary>
        /// <returns></returns>
        public int NumeroEntradasLog()
        {
            return tblEntradaLog.Count;
        }

        /// <summary>
        /// Devulve si la entrada esta en la lista, por entrada.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public bool ContieneEntrada(Entrada entrada)
        {
            if (entrada == null)
            {
                return false;
            }
            return tblEntrada.ContainsValue(entrada);
        }

        /// <summary>
        /// Devuelve si la entrada esta en la lista, por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContieneEntrada(int id)
        {
            if (id < 0) {
                return false;
            }
            return tblEntrada.ContainsKey(id);
        }

        /// <summary>
        /// Devuelve si la entradaLog esta en la lista, por entradaLog.
        /// </summary>
        /// <param name="entradalog"></param>
        /// <returns></returns>
        public bool ContainsEntradaLog(EntradaLog entradaLog)
        {
            if (entradaLog == null)
            {
                return false;
            }
            return tblEntradaLog.ContainsValue(entradaLog);
        }

        /// <summary>
        /// Devuelve si la entradaLog esta en la lista, por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContainsEntradaLog(int id)
        {
            if (id < 0)
            {
                return false;
            }
            return tblEntradaLog.ContainsKey(id);
        }

        /// <summary>
        /// Devuelve si el usuario esta en la lista, por usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ContainsUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            return tblUsuario.ContainsValue(usuario);
        }

        /// <summary>
        /// Devuelve si el usuario esta en la lista, por id.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ContainsUsuario(int id)
        {
            if (id < 0)
            {
                return false;
            }
            return tblUsuario.ContainsKey(id);
        }

        public bool ContainsUsuario(string eMail)
        {
            if (eMail == null)
            {
                return false;
            }
            var userList = tblUsuario.Where(usuario => usuario.Value.EMail == eMail);
            return userList.Count() >= 1;
        }

        /// <summary>
        /// Lee la entrada por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entrada LeeEntrada(int id)
        {
            if (id < 0 || !ContieneEntrada(id))
            {
                return null;
            }
            return tblEntrada[id];
        }

        /// <summary>
        /// Lee la entradaLog por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EntradaLog LeeEntradaLog(int id)
        {
            if (id < 0 || !ContainsEntradaLog(id))
            {
                return null;
            }
            return tblEntradaLog[id];
        }

        /// <summary>
        /// Lee usuario por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario LeeUsuario(int id)
        {
            if (id < 0 || !ContainsUsuario(id))
            {
                return null;
            }
            return tblUsuario[id];
        }

        /// <summary>
        /// Lee usuario por email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Usuario LeeUsuario(string email)
        {
            if (email == null)
            {
                return null;
            }
            if (ContainsUsuario(email))
            {
                var userList = tblUsuario.Where(usuario => usuario.Value.EMail == email);
                Usuario u = userList.First().Value;
                return LeeUsuario(u.IdUsuario);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Borra al usuario por email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool BorraUsuario(string email)
        {
            if(email == null)
            {
                return false;
            }
            Usuario u = LeeUsuario(email);
            return BorrarUsuario(u);
        }

        /// <summary>
        /// Borra al usuario por id.
        /// </summary>
        /// <param name="_identificador"></param>
        /// <returns></returns>
        public bool BorraUsuario(int _identificador)
        {
            if(!tblUsuario.ContainsKey(_identificador))
            {
                return false;
            }
            Usuario u = LeeUsuario(_identificador);
            return BorrarUsuario(u);
        }

        /// <summary>
        /// Borra al usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool BorrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return false;
            }
            if (!ContainsUsuario(usuario))
            {
                return false;
            }
            
            IList<Entrada> entradas = tblEntrada.Values;

            foreach (Entrada entrada in entradas)
            {
                bool isUsuario = entrada.DeleteUser(usuario);

                if (!isUsuario)
                {                  
                    return false;
                }
            }

            return tblUsuario.Remove(usuario.IdUsuario);
        }

        /// <summary>
        /// Borrar entrada por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BorraEntrada(int id)
        {
            if (!ContieneEntrada(id))
            {
                return false;
            }
            return tblEntrada.Remove(id);
        }

        /// <summary>
        /// Borrar entrada por valor.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public bool BorraEntrada(Entrada entrada)
        {
            if (!ContieneEntrada(entrada))
            {
                return false;
            }
            return BorraEntrada(entrada.IdEntrada);
        }

        /// <summary>
        /// Borrar entradaLog por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BorraEntradaLog(int id)
        {
            if (!ContainsEntradaLog(id))
            {
                return false;
            }
            return tblEntradaLog.Remove(id);
        }

        /// <summary>
        /// Borrar entradaLog por valor.
        /// </summary>
        /// <param name="entradaLog"></param>
        /// <returns></returns>
        public bool BorraEntradaLog(EntradaLog entradaLog)
        {
            if (!ContainsEntradaLog(entradaLog))
            {
                return false;
            }
            return BorraEntradaLog(entradaLog.IdLog);
        }

        /// <summary>
        /// Insertar entrada en su lista.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public bool InsertarEntrada(Entrada entrada)
        {
            if (ContieneEntrada(entrada) || entrada == null)
            {
                return false;
            }
            else if (ContieneEntrada(entrada.IdEntrada))
            {
                EntradaLog entradaLog = new EntradaLog(entrada.Usuario, entrada, TipoAcceso.Escritura);
                InsertarEntradaLog(entradaLog);
                tblEntrada[entrada.IdEntrada] = entrada;
                return true;
            }
            else
            {
                EntradaLog entradaLog = new EntradaLog(entrada.Usuario, entrada, TipoAcceso.Escritura);
                InsertarEntradaLog(entradaLog);
                tblEntrada.Add(entrada.IdEntrada, entrada);
                return true;
            }
        }
        
        /// <summary>
        /// Insertar un usuario en su lista
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertarUsuario(Usuario usuario)
        {
            if (ContainsUsuario(usuario) || usuario == null)
            {
                return false;
            }
            else if (ContainsUsuario(usuario.EMail))
            {
                return false;
            }
            else if (ContainsUsuario(usuario.IdUsuario))
            {
                tblUsuario[usuario.IdUsuario] = usuario;
                return true;
            } 
            else
            {
                tblUsuario.Add(usuario.IdUsuario, usuario);
                return true;
            }
        }

        /// <summary>
        /// Insertar una entradaLog en su lista.
        /// </summary>
        /// <param name="entradalog"></param>
        /// <returns></returns>
        public bool InsertarEntradaLog(EntradaLog entradalog)
        {
            if (ContainsEntradaLog(entradalog) || entradalog == null)
            {
                return false;
            }
            else if (ContainsEntradaLog(entradalog.IdLog))
            {
                tblEntradaLog[entradalog.IdLog] = entradalog;
                return true;
            }
            else
            {
                tblEntradaLog.Add(entradalog.IdLog, entradalog);
                return true;
            }
        }

    }
}